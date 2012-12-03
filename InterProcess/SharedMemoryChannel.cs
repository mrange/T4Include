// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantCaseLabel


namespace Source.InterProcess
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    using Source.Common;

    sealed partial class TodoException : Exception
    {
    }

    sealed partial class SocketListener<T> : Common.BaseObservable<SocketChannel<T>>
        where T : ISerializableMessage
    {
        readonly Socket m_socket;
        readonly int m_bufferSize;
        readonly byte[] m_messageTag;
        readonly ISerializableMessageFactory<T> m_factory;

        protected override void OnDispose()
        {
            base.OnDispose();
            m_socket.Dispose();
        }


        public SocketListener(int port, string messageTag, int bufferSize, ISerializableMessageFactory<T> factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }
            m_factory = factory;
            m_messageTag = Encoding.ASCII.GetBytes(messageTag ?? "");
            m_bufferSize = Math.Max(bufferSize, 1);

            m_socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            var endPoint = new IPEndPoint(IPAddress.Loopback, port);
            m_socket.Bind(endPoint);
            m_socket.Listen(int.MaxValue);
            m_socket.BeginAccept(int.MaxValue, OnAccept, this);
        }

        void OnAccept(IAsyncResult obj)
        {
            if (IsDisposed)
            {
                return;
            }

            try
            {
                var s = m_socket.EndAccept(obj);
                var channel = new SocketChannel<T>(s, m_messageTag, m_bufferSize, m_factory);
                Raise(channel);
            }
            catch (Exception exc)
            {
                RaiseException(exc);
            }
            finally
            {
                try
                {
                    m_socket.BeginAccept(int.MaxValue, OnAccept, this);
                }
                catch (Exception exc)
                {
                    RaiseException(exc);
                    // TODO: Socket dead
                    Dispose();
                }
            }
        }
    }

    sealed partial class SocketErrorException : Exception
    {
        public readonly SocketError ErrorCode;

        public SocketErrorException(SocketError errorCode)
        {
            ErrorCode = errorCode;
        }
    }

    sealed partial class UnserializeMessageException : Exception
    {
        public readonly byte[] Bytes;

        public UnserializeMessageException(byte[] bytes)
        {
            Bytes = bytes ?? Array<byte>.Empty;
        }
    }

    sealed partial class SocketChannel<T> : BaseChannel<T>
        where T : ISerializableMessage
    {
        readonly Socket m_socket;
        readonly byte[] m_buffer;

        public SocketChannel(Socket socket, byte[] messageTag, int bufferSize, ISerializableMessageFactory<T> factory)
            :   base (messageTag, factory)
        {
            if (socket == null)
            {
                throw new ArgumentNullException("socket");
            }

            m_buffer = new byte[bufferSize];

            m_socket = socket;
            m_socket.BeginReceive(m_buffer, 0, m_buffer.Length, SocketFlags.None, OnReceive, this);
        }

        void OnReceive(IAsyncResult ar)
        {
            if (IsDisposed)
            {
                return;
            }

            try
            {
                SocketError errorCode;
                var received = m_socket.EndReceive(ar, out errorCode);
                if (errorCode != SocketError.Success)
                {
                    RaiseException(new SocketErrorException(errorCode));
                }

                AcceptBytes(m_buffer, 0, received);

            }
            catch (Exception exc)
            {
                RaiseException(exc);
            }
            finally
            {
                try
                {
                    m_socket.BeginReceive(m_buffer, 0, m_buffer.Length, SocketFlags.None, OnReceive, this);
                }
                catch(Exception exc)
                {
                    // TODO: Socket dead
                    RaiseException(exc);
                    Dispose();
                }
                
            }
        }

        public override void Push(ISerializableMessage value)
        {
            if (IsDisposed)
            {
                return;
            }

            if (value == null)
            {
                return;
            }
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            m_socket.Dispose();
        }
    }
}
