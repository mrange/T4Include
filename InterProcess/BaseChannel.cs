using System;
using System.Collections.Generic;
using System.IO;
using Source.Common;
using Source.DataStreams;

namespace Source.InterProcess
{
    abstract partial class BaseChannel<T> : BaseObservable<ISerializableMessage>, IChannel<ISerializableMessage>
        where T : ISerializableMessage
    {
        readonly byte[] m_messageTag;
        readonly byte[] m_suspectedMessageTag;
        readonly ISerializableMessageFactory<T> m_factory;
        List<byte> m_message;
        Unserializer m_reader;

        protected BaseChannel(byte[] messageTag, ISerializableMessageFactory<T> factory)
        {
            m_factory = factory;
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            m_messageTag = messageTag ?? Array<byte>.Empty;
            m_suspectedMessageTag = new byte[m_messageTag.Length];
            m_message = new List<Byte> ();
            m_reader = new Unserializer(new ListDataStream(m_message));
        }

        public abstract void Push(ISerializableMessage value);

        protected void CreateBuffers(byte[] buffer)
        {
        }

        protected enum FindMessageResult
        {
            Found                   ,
            GarbageFoundUpToIndex   ,
        }

        protected FindMessageResult TryFindMessageStart(out long index, out int length)
        {
            index = 0;
            length = 0;

            var end = Math.Max((long) (m_reader.BaseStream.Remaining - m_messageTag.Length - sizeof (Int32)), 0); 

            for (var iter = 0; iter < end; ++iter)
            {
                if (IsMessageTag(iter))
                {
                    var messageStart = iter + m_messageTag.Length;
                    m_reader.BaseStream.Position = messageStart;

                    length = m_reader.Unserialize(0);

                    if (length + messageStart > m_reader.BaseStream.Remaining)
                    {
                        return FindMessageResult.GarbageFoundUpToIndex;
                    }

                    index = messageStart;
                    return FindMessageResult.Found;
                }
            }

            index = end;
            return FindMessageResult.GarbageFoundUpToIndex;
        }

        bool IsMessageTag(int pos)
        {
            if (m_messageTag.Length == 0)
            {
                return true;
            }

            m_reader.BaseStream.Position = pos;
            var length = m_suspectedMessageTag.Length;
           
            if (m_message.Read(m_suspectedMessageTag, 0, length) != length)
            {
                return false;
            }

            for (var ita = 0; ita < m_messageTag.Length; ++ita)
            {
                if (m_messageTag[ita] != m_suspectedMessageTag[ita])
                {
                    return false;
                }
            }

            return true;
        }

        protected void AcceptBytes(byte[] bytes, int offset, int count)
        {
            m_message.Write(bytes, offset, count);

            long index;
            int length;
            var result = TryFindMessageStart(out index, out length);
            try
            {
                switch (result)
                {
                    case FindMessageResult.Found:
                        m_message.Seek(index, SeekOrigin.Begin);
                        int consumedBytes;
                        T message;
                        if (m_factory.TryUnserialize(m_reader, out consumedBytes, out message) && message != null)
                        {
                            Raise(message);
                        }
                        else
                        {
                            m_message.Seek(index, SeekOrigin.Begin);
                            RaiseException(new UnserializeMessageException(m_reader.ReadBytes(length)));
                        }
                        break;
                    case FindMessageResult.GarbageFoundUpToIndex:
                    default:
                        break;
                }
            }
            finally
            {
                if (index + length > 0)
                {
                    m_message.Seek(index + length, SeekOrigin.Begin);
                    var remaining = m_reader.ReadBytes(int.MaxValue);
                    CreateBuffers(remaining);
                }
            }
        }
    }
}