// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################






// ### INCLUDE: IAtomic.cs

// ReSharper disable PartialTypeWithSinglePart

namespace Source.Concurrency
{
    using System;
    using System.Threading;

    sealed partial class AtomicInt32 : IAtomic<Int32>
    {
        Int32 m_value;

        public AtomicInt32 (Int32 value = default (Int32))
        {
            m_value = value;
        }

        public bool CompareExchange (Int32 newValue, Int32 comparand)
        {
            return Interlocked.CompareExchange (ref m_value, newValue, comparand) == comparand;
        }

        public Int32 Value
        {
            get { return Interlocked.CompareExchange (ref m_value, default (Int32), default (Int32)); }
        }

    }
    sealed partial class AtomicInt64 : IAtomic<Int64>
    {
        Int64 m_value;

        public AtomicInt64 (Int64 value = default (Int64))
        {
            m_value = value;
        }

        public bool CompareExchange (Int64 newValue, Int64 comparand)
        {
            return Interlocked.CompareExchange (ref m_value, newValue, comparand) == comparand;
        }

        public Int64 Value
        {
            get { return Interlocked.CompareExchange (ref m_value, default (Int64), default (Int64)); }
        }

    }
    sealed partial class AtomicSingle : IAtomic<Single>
    {
        Single m_value;

        public AtomicSingle (Single value = default (Single))
        {
            m_value = value;
        }

        public bool CompareExchange (Single newValue, Single comparand)
        {
// ReSharper disable CompareOfFloatsByEqualityOperator
            return Interlocked.CompareExchange (ref m_value, newValue, comparand) == comparand;
// ReSharper restore CompareOfFloatsByEqualityOperator
        }

        public Single Value
        {
            get { return Interlocked.CompareExchange (ref m_value, default (Single), default (Single)); }
        }

    }
    sealed partial class AtomicDouble : IAtomic<Double>
    {
        Double m_value;

        public AtomicDouble (Double value = default (Double))
        {
            m_value = value;
        }

        public bool CompareExchange (Double newValue, Double comparand)
        {
// ReSharper disable CompareOfFloatsByEqualityOperator
            return Interlocked.CompareExchange (ref m_value, newValue, comparand) == comparand;
// ReSharper restore CompareOfFloatsByEqualityOperator
        }

        public Double Value
        {
            get { return Interlocked.CompareExchange (ref m_value, default (Double), default (Double)); }
        }

    }

    partial class Atomic<T> : IAtomic<T>
        where T : class
    {
        T m_value;

        public Atomic (T value = null)
        {
            m_value = value;
        }

        public bool CompareExchange (T newValue, T comparand)
        {
            return Interlocked.CompareExchange (ref m_value, newValue, comparand) == comparand;
        }

        public T Value
        {
            get { return Interlocked.CompareExchange (ref m_value, null, null); }
        }

    }

}

