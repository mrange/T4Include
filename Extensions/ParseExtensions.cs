
// ### INCLUDE: ../Common/Config.cs


// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################






// ReSharper disable PartialTypeWithSinglePart

namespace Source.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using Source.Common;

    static partial class ParseExtensions
    {
        static readonly Dictionary<Type, Func<string, CultureInfo, object>> s_parsers = new Dictionary<Type, Func<string, CultureInfo, object>> 
            {
#if !T4INCLUDE__SUPPRESS_BOOLEAN_PARSE_EXTENSIONS
                { typeof(Boolean)  , (s, ci) => { Boolean value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(Boolean?) , (s, ci) => { Boolean value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_CHAR_PARSE_EXTENSIONS
                { typeof(Char)  , (s, ci) => { Char value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(Char?) , (s, ci) => { Char value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_SBYTE_PARSE_EXTENSIONS
                { typeof(SByte)  , (s, ci) => { SByte value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(SByte?) , (s, ci) => { SByte value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_INT16_PARSE_EXTENSIONS
                { typeof(Int16)  , (s, ci) => { Int16 value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(Int16?) , (s, ci) => { Int16 value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_INT32_PARSE_EXTENSIONS
                { typeof(Int32)  , (s, ci) => { Int32 value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(Int32?) , (s, ci) => { Int32 value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_INT64_PARSE_EXTENSIONS
                { typeof(Int64)  , (s, ci) => { Int64 value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(Int64?) , (s, ci) => { Int64 value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_BYTE_PARSE_EXTENSIONS
                { typeof(Byte)  , (s, ci) => { Byte value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(Byte?) , (s, ci) => { Byte value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_UINT16_PARSE_EXTENSIONS
                { typeof(UInt16)  , (s, ci) => { UInt16 value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(UInt16?) , (s, ci) => { UInt16 value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_UINT32_PARSE_EXTENSIONS
                { typeof(UInt32)  , (s, ci) => { UInt32 value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(UInt32?) , (s, ci) => { UInt32 value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_UINT64_PARSE_EXTENSIONS
                { typeof(UInt64)  , (s, ci) => { UInt64 value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(UInt64?) , (s, ci) => { UInt64 value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_SINGLE_PARSE_EXTENSIONS
                { typeof(Single)  , (s, ci) => { Single value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(Single?) , (s, ci) => { Single value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_DOUBLE_PARSE_EXTENSIONS
                { typeof(Double)  , (s, ci) => { Double value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(Double?) , (s, ci) => { Double value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_DECIMAL_PARSE_EXTENSIONS
                { typeof(Decimal)  , (s, ci) => { Decimal value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(Decimal?) , (s, ci) => { Decimal value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_TIMESPAN_PARSE_EXTENSIONS
                { typeof(TimeSpan)  , (s, ci) => { TimeSpan value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(TimeSpan?) , (s, ci) => { TimeSpan value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_DATETIME_PARSE_EXTENSIONS
                { typeof(DateTime)  , (s, ci) => { DateTime value; return s.TryParse(ci, out value) ? (object)value : null;}},
                { typeof(DateTime?) , (s, ci) => { DateTime value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
            };

        public static bool CanParse (this Type type)
        {
            if (type == null)
            {
                return false;
            }

            return s_parsers.ContainsKey (type);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, Type type, out object value)
        {
            value = null;
            if (type == null)
            {
                return false;
            }                
            
            Func<string, CultureInfo, object> parser;

            if (s_parsers.TryGetValue (type, out parser))
            {
                value = parser (s, cultureInfo);
            }

            return value != null;
        }

        public static bool TryParse (this string s, Type type, out object value)
        {
            return s.TryParse (Config.DefaultCulture, type, out value);
        }

        public static object Parse (this string s, CultureInfo cultureInfo, Type type, object defaultValue)
        {
            object value;
            return s.TryParse (cultureInfo, type, out value) ? value : defaultValue;
        }

        public static object Parse (this string s, Type type, object defaultValue)
        {
            return s.Parse (Config.DefaultCulture, type, defaultValue);
        }

        // Boolean (BoolLike)

#if !T4INCLUDE__SUPPRESS_BOOLEAN_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out Boolean value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static Boolean Parse (this string s, CultureInfo cultureInfo, Boolean defaultValue)
        {
            Boolean value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static Boolean Parse (this string s, Boolean defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Boolean value)
        {
            return Boolean.TryParse (s ?? "", out value);
        }

#endif // T4INCLUDE__SUPPRESS_BOOLEAN_PARSE_EXTENSIONS

        // Char (CharLike)

#if !T4INCLUDE__SUPPRESS_CHAR_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out Char value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static Char Parse (this string s, CultureInfo cultureInfo, Char defaultValue)
        {
            Char value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static Char Parse (this string s, Char defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Char value)
        {
            return Char.TryParse (s ?? "", out value);
        }

#endif // T4INCLUDE__SUPPRESS_CHAR_PARSE_EXTENSIONS

        // SByte (IntLike)

#if !T4INCLUDE__SUPPRESS_SBYTE_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out SByte value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static SByte Parse (this string s, CultureInfo cultureInfo, SByte defaultValue)
        {
            SByte value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static SByte Parse (this string s, SByte defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out SByte value)
        {
            return SByte.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_SBYTE_PARSE_EXTENSIONS

        // Int16 (IntLike)

#if !T4INCLUDE__SUPPRESS_INT16_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out Int16 value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static Int16 Parse (this string s, CultureInfo cultureInfo, Int16 defaultValue)
        {
            Int16 value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static Int16 Parse (this string s, Int16 defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Int16 value)
        {
            return Int16.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_INT16_PARSE_EXTENSIONS

        // Int32 (IntLike)

#if !T4INCLUDE__SUPPRESS_INT32_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out Int32 value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static Int32 Parse (this string s, CultureInfo cultureInfo, Int32 defaultValue)
        {
            Int32 value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static Int32 Parse (this string s, Int32 defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Int32 value)
        {
            return Int32.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_INT32_PARSE_EXTENSIONS

        // Int64 (IntLike)

#if !T4INCLUDE__SUPPRESS_INT64_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out Int64 value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static Int64 Parse (this string s, CultureInfo cultureInfo, Int64 defaultValue)
        {
            Int64 value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static Int64 Parse (this string s, Int64 defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Int64 value)
        {
            return Int64.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_INT64_PARSE_EXTENSIONS

        // Byte (IntLike)

#if !T4INCLUDE__SUPPRESS_BYTE_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out Byte value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static Byte Parse (this string s, CultureInfo cultureInfo, Byte defaultValue)
        {
            Byte value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static Byte Parse (this string s, Byte defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Byte value)
        {
            return Byte.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_BYTE_PARSE_EXTENSIONS

        // UInt16 (IntLike)

#if !T4INCLUDE__SUPPRESS_UINT16_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out UInt16 value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static UInt16 Parse (this string s, CultureInfo cultureInfo, UInt16 defaultValue)
        {
            UInt16 value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static UInt16 Parse (this string s, UInt16 defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out UInt16 value)
        {
            return UInt16.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_UINT16_PARSE_EXTENSIONS

        // UInt32 (IntLike)

#if !T4INCLUDE__SUPPRESS_UINT32_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out UInt32 value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static UInt32 Parse (this string s, CultureInfo cultureInfo, UInt32 defaultValue)
        {
            UInt32 value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static UInt32 Parse (this string s, UInt32 defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out UInt32 value)
        {
            return UInt32.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_UINT32_PARSE_EXTENSIONS

        // UInt64 (IntLike)

#if !T4INCLUDE__SUPPRESS_UINT64_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out UInt64 value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static UInt64 Parse (this string s, CultureInfo cultureInfo, UInt64 defaultValue)
        {
            UInt64 value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static UInt64 Parse (this string s, UInt64 defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out UInt64 value)
        {
            return UInt64.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_UINT64_PARSE_EXTENSIONS

        // Single (FloatLike)

#if !T4INCLUDE__SUPPRESS_SINGLE_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out Single value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static Single Parse (this string s, CultureInfo cultureInfo, Single defaultValue)
        {
            Single value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static Single Parse (this string s, Single defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Single value)
        {                                                  
            return Single.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_SINGLE_PARSE_EXTENSIONS

        // Double (FloatLike)

#if !T4INCLUDE__SUPPRESS_DOUBLE_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out Double value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static Double Parse (this string s, CultureInfo cultureInfo, Double defaultValue)
        {
            Double value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static Double Parse (this string s, Double defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Double value)
        {                                                  
            return Double.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_DOUBLE_PARSE_EXTENSIONS

        // Decimal (FloatLike)

#if !T4INCLUDE__SUPPRESS_DECIMAL_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out Decimal value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static Decimal Parse (this string s, CultureInfo cultureInfo, Decimal defaultValue)
        {
            Decimal value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static Decimal Parse (this string s, Decimal defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Decimal value)
        {                                                  
            return Decimal.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_DECIMAL_PARSE_EXTENSIONS

        // TimeSpan (TimeSpanLike)

#if !T4INCLUDE__SUPPRESS_TIMESPAN_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out TimeSpan value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static TimeSpan Parse (this string s, CultureInfo cultureInfo, TimeSpan defaultValue)
        {
            TimeSpan value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static TimeSpan Parse (this string s, TimeSpan defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out TimeSpan value)
        {                                                  
            return TimeSpan.TryParse (s ?? "", cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_TIMESPAN_PARSE_EXTENSIONS

        // DateTime (DateTimeLike)

#if !T4INCLUDE__SUPPRESS_DATETIME_PARSE_EXTENSIONS

        public static bool TryParse (this string s, out DateTime value)
        {
            return s.TryParse (Config.DefaultCulture, out value);
        }

        public static DateTime Parse (this string s, CultureInfo cultureInfo, DateTime defaultValue)
        {
            DateTime value;

            return s.TryParse (cultureInfo, out value) ? value : defaultValue;
        }

        public static DateTime Parse (this string s, DateTime defaultValue)
        {
            return s.Parse (Config.DefaultCulture, defaultValue);
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out DateTime value)
        {                                                  
            return DateTime.TryParse (s ?? "", cultureInfo, DateTimeStyles.AssumeLocal, out value);
        }

#endif // T4INCLUDE__SUPPRESS_DATETIME_PARSE_EXTENSIONS

    }
}


