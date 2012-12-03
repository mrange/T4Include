// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################







namespace Source.DataStreams
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    using Source.Common;

    [StructLayout(LayoutKind.Explicit)]
    partial struct UnionOfAll
    {
        [FieldOffset(0)]
        public Byte Offset0;  
        [FieldOffset(1)]
        public Byte Offset1;  
        [FieldOffset(2)]
        public Byte Offset2;  
        [FieldOffset(3)]
        public Byte Offset3;  
        [FieldOffset(4)]
        public Byte Offset4;  
        [FieldOffset(5)]
        public Byte Offset5;  
        [FieldOffset(6)]
        public Byte Offset6;  
        [FieldOffset(7)]
        public Byte Offset7;  
        [FieldOffset(8)]
        public Byte Offset8;  
        [FieldOffset(9)]
        public Byte Offset9;  
        [FieldOffset(10)]
        public Byte Offset10;  
        [FieldOffset(11)]
        public Byte Offset11;  
        [FieldOffset(12)]
        public Byte Offset12;  
        [FieldOffset(13)]
        public Byte Offset13;  
        [FieldOffset(14)]
        public Byte Offset14;  
        [FieldOffset(15)]
        public Byte Offset15;  
        

        [FieldOffset(0)]
        public Byte Byte;  
        [FieldOffset(0)]
        public UInt16 UInt16;  
        [FieldOffset(0)]
        public UInt32 UInt32;  
        [FieldOffset(0)]
        public UInt64 UInt64;  
        [FieldOffset(0)]
        public SByte SByte;  
        [FieldOffset(0)]
        public Int16 Int16;  
        [FieldOffset(0)]
        public Int32 Int32;  
        [FieldOffset(0)]
        public Int64 Int64;  
        [FieldOffset(0)]
        public Char Char;  
        [FieldOffset(0)]
        public Single Single;  
        [FieldOffset(0)]
        public Double Double;  
        [FieldOffset(0)]
        public Decimal Decimal;  
        

        public Byte this[int i]
        {
            get
            {
                switch (i)
                {
                case 0:
                    return Offset0;
                case 1:
                    return Offset1;
                case 2:
                    return Offset2;
                case 3:
                    return Offset3;
                case 4:
                    return Offset4;
                case 5:
                    return Offset5;
                case 6:
                    return Offset6;
                case 7:
                    return Offset7;
                case 8:
                    return Offset8;
                case 9:
                    return Offset9;
                case 10:
                    return Offset10;
                case 11:
                    return Offset11;
                case 12:
                    return Offset12;
                case 13:
                    return Offset13;
                case 14:
                    return Offset14;
                case 15:
                    return Offset15;
                default:
                    throw new ArgumentOutOfRangeException("i");
                }
            }
            set
            {
                switch (i)
                {
                case 0:
                    Offset0 = value;
                    break;
                case 1:
                    Offset1 = value;
                    break;
                case 2:
                    Offset2 = value;
                    break;
                case 3:
                    Offset3 = value;
                    break;
                case 4:
                    Offset4 = value;
                    break;
                case 5:
                    Offset5 = value;
                    break;
                case 6:
                    Offset6 = value;
                    break;
                case 7:
                    Offset7 = value;
                    break;
                case 8:
                    Offset8 = value;
                    break;
                case 9:
                    Offset9 = value;
                    break;
                case 10:
                    Offset10 = value;
                    break;
                case 11:
                    Offset11 = value;
                    break;
                case 12:
                    Offset12 = value;
                    break;
                case 13:
                    Offset13 = value;
                    break;
                case 14:
                    Offset14 = value;
                    break;
                case 15:
                    Offset15 = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("i");
                }
            }
        }
    }

    sealed partial class Unserializer : BaseDisposable
    {
        UnionOfAll m_unionOfAll;
        public readonly IDataStream BaseStream;

        public Unserializer (IDataStream baseStream)
        {
            if (baseStream == null)
            {
                throw new ArgumentNullException("baseStream");
            }
            BaseStream = baseStream;
        }

        protected override void OnDispose()
        {
            BaseStream.Dispose ();
        }

        public string Unserialize (string defaultValue)
        {
            string value;
            return TryUnserialize (out value) ? value : defaultValue;
        }

        public bool TryUnserialize (out string v)
        {
            v = "";

            Int32 length;
            if (!TryUnserialize (out length))
            {
                return false;
            }            

            var count = 2*length;
            if (BaseStream.Remaining < count)
            {
                return false;
            }

            var buffer = new Byte[count];
            for (var iter = 0; iter < count; ++iter)
            {
                buffer[iter] = BaseStream.Read ();
            }

            v = Encoding.Unicode.GetString(buffer);
            return true;
        }

        public Byte Unserialize (Byte defaultValue)
        {
            Byte value;
            return TryUnserialize (out value) ? value : defaultValue;
        }

        public bool TryUnserialize (out Byte v)
        {
            v = default(Byte);

            if (BaseStream.Remaining < 1)
            {
                return false;
            }

            m_unionOfAll.Offset0 = BaseStream.Read ();    
            v = m_unionOfAll.Byte;
            return true;
        }

        public UInt16 Unserialize (UInt16 defaultValue)
        {
            UInt16 value;
            return TryUnserialize (out value) ? value : defaultValue;
        }

        public bool TryUnserialize (out UInt16 v)
        {
            v = default(UInt16);

            if (BaseStream.Remaining < 2)
            {
                return false;
            }

            m_unionOfAll.Offset0 = BaseStream.Read ();    
            m_unionOfAll.Offset1 = BaseStream.Read ();    
            v = m_unionOfAll.UInt16;
            return true;
        }

        public UInt32 Unserialize (UInt32 defaultValue)
        {
            UInt32 value;
            return TryUnserialize (out value) ? value : defaultValue;
        }

        public bool TryUnserialize (out UInt32 v)
        {
            v = default(UInt32);

            if (BaseStream.Remaining < 4)
            {
                return false;
            }

            m_unionOfAll.Offset0 = BaseStream.Read ();    
            m_unionOfAll.Offset1 = BaseStream.Read ();    
            m_unionOfAll.Offset2 = BaseStream.Read ();    
            m_unionOfAll.Offset3 = BaseStream.Read ();    
            v = m_unionOfAll.UInt32;
            return true;
        }

        public UInt64 Unserialize (UInt64 defaultValue)
        {
            UInt64 value;
            return TryUnserialize (out value) ? value : defaultValue;
        }

        public bool TryUnserialize (out UInt64 v)
        {
            v = default(UInt64);

            if (BaseStream.Remaining < 8)
            {
                return false;
            }

            m_unionOfAll.Offset0 = BaseStream.Read ();    
            m_unionOfAll.Offset1 = BaseStream.Read ();    
            m_unionOfAll.Offset2 = BaseStream.Read ();    
            m_unionOfAll.Offset3 = BaseStream.Read ();    
            m_unionOfAll.Offset4 = BaseStream.Read ();    
            m_unionOfAll.Offset5 = BaseStream.Read ();    
            m_unionOfAll.Offset6 = BaseStream.Read ();    
            m_unionOfAll.Offset7 = BaseStream.Read ();    
            v = m_unionOfAll.UInt64;
            return true;
        }

        public SByte Unserialize (SByte defaultValue)
        {
            SByte value;
            return TryUnserialize (out value) ? value : defaultValue;
        }

        public bool TryUnserialize (out SByte v)
        {
            v = default(SByte);

            if (BaseStream.Remaining < 1)
            {
                return false;
            }

            m_unionOfAll.Offset0 = BaseStream.Read ();    
            v = m_unionOfAll.SByte;
            return true;
        }

        public Int16 Unserialize (Int16 defaultValue)
        {
            Int16 value;
            return TryUnserialize (out value) ? value : defaultValue;
        }

        public bool TryUnserialize (out Int16 v)
        {
            v = default(Int16);

            if (BaseStream.Remaining < 2)
            {
                return false;
            }

            m_unionOfAll.Offset0 = BaseStream.Read ();    
            m_unionOfAll.Offset1 = BaseStream.Read ();    
            v = m_unionOfAll.Int16;
            return true;
        }

        public Int32 Unserialize (Int32 defaultValue)
        {
            Int32 value;
            return TryUnserialize (out value) ? value : defaultValue;
        }

        public bool TryUnserialize (out Int32 v)
        {
            v = default(Int32);

            if (BaseStream.Remaining < 4)
            {
                return false;
            }

            m_unionOfAll.Offset0 = BaseStream.Read ();    
            m_unionOfAll.Offset1 = BaseStream.Read ();    
            m_unionOfAll.Offset2 = BaseStream.Read ();    
            m_unionOfAll.Offset3 = BaseStream.Read ();    
            v = m_unionOfAll.Int32;
            return true;
        }

        public Int64 Unserialize (Int64 defaultValue)
        {
            Int64 value;
            return TryUnserialize (out value) ? value : defaultValue;
        }

        public bool TryUnserialize (out Int64 v)
        {
            v = default(Int64);

            if (BaseStream.Remaining < 8)
            {
                return false;
            }

            m_unionOfAll.Offset0 = BaseStream.Read ();    
            m_unionOfAll.Offset1 = BaseStream.Read ();    
            m_unionOfAll.Offset2 = BaseStream.Read ();    
            m_unionOfAll.Offset3 = BaseStream.Read ();    
            m_unionOfAll.Offset4 = BaseStream.Read ();    
            m_unionOfAll.Offset5 = BaseStream.Read ();    
            m_unionOfAll.Offset6 = BaseStream.Read ();    
            m_unionOfAll.Offset7 = BaseStream.Read ();    
            v = m_unionOfAll.Int64;
            return true;
        }

        public Char Unserialize (Char defaultValue)
        {
            Char value;
            return TryUnserialize (out value) ? value : defaultValue;
        }

        public bool TryUnserialize (out Char v)
        {
            v = default(Char);

            if (BaseStream.Remaining < 1)
            {
                return false;
            }

            m_unionOfAll.Offset0 = BaseStream.Read ();    
            v = m_unionOfAll.Char;
            return true;
        }

        public Single Unserialize (Single defaultValue)
        {
            Single value;
            return TryUnserialize (out value) ? value : defaultValue;
        }

        public bool TryUnserialize (out Single v)
        {
            v = default(Single);

            if (BaseStream.Remaining < 4)
            {
                return false;
            }

            m_unionOfAll.Offset0 = BaseStream.Read ();    
            m_unionOfAll.Offset1 = BaseStream.Read ();    
            m_unionOfAll.Offset2 = BaseStream.Read ();    
            m_unionOfAll.Offset3 = BaseStream.Read ();    
            v = m_unionOfAll.Single;
            return true;
        }

        public Double Unserialize (Double defaultValue)
        {
            Double value;
            return TryUnserialize (out value) ? value : defaultValue;
        }

        public bool TryUnserialize (out Double v)
        {
            v = default(Double);

            if (BaseStream.Remaining < 8)
            {
                return false;
            }

            m_unionOfAll.Offset0 = BaseStream.Read ();    
            m_unionOfAll.Offset1 = BaseStream.Read ();    
            m_unionOfAll.Offset2 = BaseStream.Read ();    
            m_unionOfAll.Offset3 = BaseStream.Read ();    
            m_unionOfAll.Offset4 = BaseStream.Read ();    
            m_unionOfAll.Offset5 = BaseStream.Read ();    
            m_unionOfAll.Offset6 = BaseStream.Read ();    
            m_unionOfAll.Offset7 = BaseStream.Read ();    
            v = m_unionOfAll.Double;
            return true;
        }

        public Decimal Unserialize (Decimal defaultValue)
        {
            Decimal value;
            return TryUnserialize (out value) ? value : defaultValue;
        }

        public bool TryUnserialize (out Decimal v)
        {
            v = default(Decimal);

            if (BaseStream.Remaining < 16)
            {
                return false;
            }

            m_unionOfAll.Offset0 = BaseStream.Read ();    
            m_unionOfAll.Offset1 = BaseStream.Read ();    
            m_unionOfAll.Offset2 = BaseStream.Read ();    
            m_unionOfAll.Offset3 = BaseStream.Read ();    
            m_unionOfAll.Offset4 = BaseStream.Read ();    
            m_unionOfAll.Offset5 = BaseStream.Read ();    
            m_unionOfAll.Offset6 = BaseStream.Read ();    
            m_unionOfAll.Offset7 = BaseStream.Read ();    
            m_unionOfAll.Offset8 = BaseStream.Read ();    
            m_unionOfAll.Offset9 = BaseStream.Read ();    
            m_unionOfAll.Offset10 = BaseStream.Read ();    
            m_unionOfAll.Offset11 = BaseStream.Read ();    
            m_unionOfAll.Offset12 = BaseStream.Read ();    
            m_unionOfAll.Offset13 = BaseStream.Read ();    
            m_unionOfAll.Offset14 = BaseStream.Read ();    
            m_unionOfAll.Offset15 = BaseStream.Read ();    
            v = m_unionOfAll.Decimal;
            return true;
        }

    }

    sealed partial class Serializer : BaseDisposable
    {
        UnionOfAll m_unionOfAll;
        public readonly IDataStream BaseStream;

        protected override void OnDispose()
        {
            BaseStream.Dispose ();
        }

        public void Serialize (string v)
        {
            v = v ?? "";

            var buffer = Encoding.Unicode.GetBytes (v);
            foreach (var b in buffer)
            {
                BaseStream.Write (b);
            }
        }

        public void Serialize (Byte v)
        {
            m_unionOfAll.Byte = v;

            BaseStream.Write (m_unionOfAll.Offset0);
        }

        public void Serialize (UInt16 v)
        {
            m_unionOfAll.UInt16 = v;

            BaseStream.Write (m_unionOfAll.Offset0);
            BaseStream.Write (m_unionOfAll.Offset1);
        }

        public void Serialize (UInt32 v)
        {
            m_unionOfAll.UInt32 = v;

            BaseStream.Write (m_unionOfAll.Offset0);
            BaseStream.Write (m_unionOfAll.Offset1);
            BaseStream.Write (m_unionOfAll.Offset2);
            BaseStream.Write (m_unionOfAll.Offset3);
        }

        public void Serialize (UInt64 v)
        {
            m_unionOfAll.UInt64 = v;

            BaseStream.Write (m_unionOfAll.Offset0);
            BaseStream.Write (m_unionOfAll.Offset1);
            BaseStream.Write (m_unionOfAll.Offset2);
            BaseStream.Write (m_unionOfAll.Offset3);
            BaseStream.Write (m_unionOfAll.Offset4);
            BaseStream.Write (m_unionOfAll.Offset5);
            BaseStream.Write (m_unionOfAll.Offset6);
            BaseStream.Write (m_unionOfAll.Offset7);
        }

        public void Serialize (SByte v)
        {
            m_unionOfAll.SByte = v;

            BaseStream.Write (m_unionOfAll.Offset0);
        }

        public void Serialize (Int16 v)
        {
            m_unionOfAll.Int16 = v;

            BaseStream.Write (m_unionOfAll.Offset0);
            BaseStream.Write (m_unionOfAll.Offset1);
        }

        public void Serialize (Int32 v)
        {
            m_unionOfAll.Int32 = v;

            BaseStream.Write (m_unionOfAll.Offset0);
            BaseStream.Write (m_unionOfAll.Offset1);
            BaseStream.Write (m_unionOfAll.Offset2);
            BaseStream.Write (m_unionOfAll.Offset3);
        }

        public void Serialize (Int64 v)
        {
            m_unionOfAll.Int64 = v;

            BaseStream.Write (m_unionOfAll.Offset0);
            BaseStream.Write (m_unionOfAll.Offset1);
            BaseStream.Write (m_unionOfAll.Offset2);
            BaseStream.Write (m_unionOfAll.Offset3);
            BaseStream.Write (m_unionOfAll.Offset4);
            BaseStream.Write (m_unionOfAll.Offset5);
            BaseStream.Write (m_unionOfAll.Offset6);
            BaseStream.Write (m_unionOfAll.Offset7);
        }

        public void Serialize (Char v)
        {
            m_unionOfAll.Char = v;

            BaseStream.Write (m_unionOfAll.Offset0);
        }

        public void Serialize (Single v)
        {
            m_unionOfAll.Single = v;

            BaseStream.Write (m_unionOfAll.Offset0);
            BaseStream.Write (m_unionOfAll.Offset1);
            BaseStream.Write (m_unionOfAll.Offset2);
            BaseStream.Write (m_unionOfAll.Offset3);
        }

        public void Serialize (Double v)
        {
            m_unionOfAll.Double = v;

            BaseStream.Write (m_unionOfAll.Offset0);
            BaseStream.Write (m_unionOfAll.Offset1);
            BaseStream.Write (m_unionOfAll.Offset2);
            BaseStream.Write (m_unionOfAll.Offset3);
            BaseStream.Write (m_unionOfAll.Offset4);
            BaseStream.Write (m_unionOfAll.Offset5);
            BaseStream.Write (m_unionOfAll.Offset6);
            BaseStream.Write (m_unionOfAll.Offset7);
        }

        public void Serialize (Decimal v)
        {
            m_unionOfAll.Decimal = v;

            BaseStream.Write (m_unionOfAll.Offset0);
            BaseStream.Write (m_unionOfAll.Offset1);
            BaseStream.Write (m_unionOfAll.Offset2);
            BaseStream.Write (m_unionOfAll.Offset3);
            BaseStream.Write (m_unionOfAll.Offset4);
            BaseStream.Write (m_unionOfAll.Offset5);
            BaseStream.Write (m_unionOfAll.Offset6);
            BaseStream.Write (m_unionOfAll.Offset7);
            BaseStream.Write (m_unionOfAll.Offset8);
            BaseStream.Write (m_unionOfAll.Offset9);
            BaseStream.Write (m_unionOfAll.Offset10);
            BaseStream.Write (m_unionOfAll.Offset11);
            BaseStream.Write (m_unionOfAll.Offset12);
            BaseStream.Write (m_unionOfAll.Offset13);
            BaseStream.Write (m_unionOfAll.Offset14);
            BaseStream.Write (m_unionOfAll.Offset15);
        }

    }

}

