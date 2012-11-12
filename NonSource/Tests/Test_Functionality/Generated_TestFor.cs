// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################





namespace Test_Functionality
{
    using System;
    using System.Collections.Generic;

    partial class TestFor
    {
        public static bool Equality (IEnumerable<string> expected, IEnumerable<string> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (string expected, string found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<Boolean> expected, IEnumerable<Boolean> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (Boolean expected, Boolean found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<SByte> expected, IEnumerable<SByte> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (SByte expected, SByte found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<Int16> expected, IEnumerable<Int16> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (Int16 expected, Int16 found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<Int32> expected, IEnumerable<Int32> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (Int32 expected, Int32 found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<Int64> expected, IEnumerable<Int64> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (Int64 expected, Int64 found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<Byte> expected, IEnumerable<Byte> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (Byte expected, Byte found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<UInt16> expected, IEnumerable<UInt16> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (UInt16 expected, UInt16 found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<UInt32> expected, IEnumerable<UInt32> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (UInt32 expected, UInt32 found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<UInt64> expected, IEnumerable<UInt64> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (UInt64 expected, UInt64 found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<Single> expected, IEnumerable<Single> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (Single expected, Single found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<Double> expected, IEnumerable<Double> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (Double expected, Double found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<Decimal> expected, IEnumerable<Decimal> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (Decimal expected, Decimal found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<TimeSpan> expected, IEnumerable<TimeSpan> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (TimeSpan expected, TimeSpan found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
        public static bool Equality (IEnumerable<DateTime> expected, IEnumerable<DateTime> found, string message, bool suppressValue = false)
        {
            return SequenceEqualityImpl (expected, found, message, suppressValue);
        }

        public static bool Equality (DateTime expected, DateTime found, string message, bool suppressValue = false)
        {
            return EqualityImpl (expected, found, message, suppressValue);
        }
    }
}
