namespace Source.DataStreams
{
    using System;
    using System.Collections.Generic;
    using Source.Common;

    partial interface IDataStream : IDisposable
    {
        int Position    { get; set; }
        int Remaining   { get; }
        int TotalSize   { get; }

        Byte Read ();
        void Write (Byte value);
    }

    sealed partial class ListDataStream : IDataStream
    {
        public readonly IList<byte> Bytes;

        public ListDataStream(IList<byte> bytes)
        {
            Bytes = bytes ?? Array<Byte>.Empty;
        }

        public void Dispose()
        {
            
        }

        static int Clamp(int v, int min, int max)
        {
            if (v < min)
            {
                return min;
            }

            if (v > max)
            {
                return max;
            }

            return v;
        }

        int m_position;
        public int Position
        {
            get { return Clamp(m_position, 0, Bytes.Count); }
            set { m_position = value; }
        }

        public int Remaining
        {
            get { return Bytes.Count - Position; }
        }

        public int TotalSize    
        { 
            get { return Bytes.Count; }
        }

        public byte Read()
        {
            var read = Remaining > 0 ? Bytes[Position] : default(byte);

            ++m_position;

            return read;
        }

        public void Write(byte value)
        {
            if (Remaining > 0)
            {
                Bytes[Position] = value;
                ++m_position;
            }
            else
            {
                Bytes.Add(value);
                m_position = Bytes.Count;
            }
        }
    }

}