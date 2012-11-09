
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

    static partial class NumericalExtensions
    {
        static readonly Dictionary<Type, Func<string, CultureInfo, object>> s_parsers = new Dictionary<Type, Func<string, CultureInfo, object>> 
            {
#if !T4INCLUDE__SUPPRESS_BYTE_NUMERICAL_EXTENSIONS
                { typeof(Byte), (s, ci) => { Byte value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_INT16_NUMERICAL_EXTENSIONS
                { typeof(Int16), (s, ci) => { Int16 value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_INT32_NUMERICAL_EXTENSIONS
                { typeof(Int32), (s, ci) => { Int32 value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_INT64_NUMERICAL_EXTENSIONS
                { typeof(Int64), (s, ci) => { Int64 value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_SINGLE_NUMERICAL_EXTENSIONS
                { typeof(Single), (s, ci) => { Single value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_DOUBLE_NUMERICAL_EXTENSIONS
                { typeof(Double), (s, ci) => { Double value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_DECIMAL_NUMERICAL_EXTENSIONS
                { typeof(Decimal), (s, ci) => { Decimal value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_TIMESPAN_NUMERICAL_EXTENSIONS
                { typeof(TimeSpan), (s, ci) => { TimeSpan value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
#if !T4INCLUDE__SUPPRESS_DATETIME_NUMERICAL_EXTENSIONS
                { typeof(DateTime), (s, ci) => { DateTime value; return s.TryParse(ci, out value) ? (object)value : null;}},
#endif
            };

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

        // Byte (IntLike)

#if !T4INCLUDE__SUPPRESS_BYTE_NUMERICAL_EXTENSIONS
        public static Byte Min (this Byte left, Byte right) 
        {
            if (left < right)
            {
                return left;
            }
        
            return right;
        }

        public static Byte Max (this Byte left, Byte right) 
        {
            if (left < right)
            {
                return right;
            }
        
            return left;
        }

        public static Byte Clamp (this Byte value, Byte inclusiveMin, Byte inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return inclusiveMin;
            }
        
            if (value > inclusiveMax)
            {
                return inclusiveMax;
            }

            return value;
        }

        public static bool IsBetween (this Byte value, Byte inclusiveMin, Byte inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return false;
            }
        
            if (value > inclusiveMax)
            {
                return false;
            }

            return true;
        }

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

        public static bool IsAnyOn (this Byte value, Byte test)
        {
            return (value & test) != 0;
        }
        
        public static bool IsAnyOff (this Byte value, Byte test)
        {
            return (value & test) != test;
        }
        
        public static bool IsAllOn (this Byte value, Byte test)
        {
            return (value & test) == test;
        }
        
        public static bool IsAllOff (this Byte value, Byte test)
        {
            return (value & test) == 0;
        }
         
        public static bool TryParse (this string s, CultureInfo cultureInfo, out Byte value)
        {
            return Byte.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_BYTE_NUMERICAL_EXTENSIONS

        // Int16 (IntLike)

#if !T4INCLUDE__SUPPRESS_INT16_NUMERICAL_EXTENSIONS
        public static Int16 Min (this Int16 left, Int16 right) 
        {
            if (left < right)
            {
                return left;
            }
        
            return right;
        }

        public static Int16 Max (this Int16 left, Int16 right) 
        {
            if (left < right)
            {
                return right;
            }
        
            return left;
        }

        public static Int16 Clamp (this Int16 value, Int16 inclusiveMin, Int16 inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return inclusiveMin;
            }
        
            if (value > inclusiveMax)
            {
                return inclusiveMax;
            }

            return value;
        }

        public static bool IsBetween (this Int16 value, Int16 inclusiveMin, Int16 inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return false;
            }
        
            if (value > inclusiveMax)
            {
                return false;
            }

            return true;
        }

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

        public static bool IsAnyOn (this Int16 value, Int16 test)
        {
            return (value & test) != 0;
        }
        
        public static bool IsAnyOff (this Int16 value, Int16 test)
        {
            return (value & test) != test;
        }
        
        public static bool IsAllOn (this Int16 value, Int16 test)
        {
            return (value & test) == test;
        }
        
        public static bool IsAllOff (this Int16 value, Int16 test)
        {
            return (value & test) == 0;
        }
         
        public static bool TryParse (this string s, CultureInfo cultureInfo, out Int16 value)
        {
            return Int16.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_INT16_NUMERICAL_EXTENSIONS

        // Int32 (IntLike)

#if !T4INCLUDE__SUPPRESS_INT32_NUMERICAL_EXTENSIONS
        public static Int32 Min (this Int32 left, Int32 right) 
        {
            if (left < right)
            {
                return left;
            }
        
            return right;
        }

        public static Int32 Max (this Int32 left, Int32 right) 
        {
            if (left < right)
            {
                return right;
            }
        
            return left;
        }

        public static Int32 Clamp (this Int32 value, Int32 inclusiveMin, Int32 inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return inclusiveMin;
            }
        
            if (value > inclusiveMax)
            {
                return inclusiveMax;
            }

            return value;
        }

        public static bool IsBetween (this Int32 value, Int32 inclusiveMin, Int32 inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return false;
            }
        
            if (value > inclusiveMax)
            {
                return false;
            }

            return true;
        }

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

        public static bool IsAnyOn (this Int32 value, Int32 test)
        {
            return (value & test) != 0;
        }
        
        public static bool IsAnyOff (this Int32 value, Int32 test)
        {
            return (value & test) != test;
        }
        
        public static bool IsAllOn (this Int32 value, Int32 test)
        {
            return (value & test) == test;
        }
        
        public static bool IsAllOff (this Int32 value, Int32 test)
        {
            return (value & test) == 0;
        }
         
        public static bool TryParse (this string s, CultureInfo cultureInfo, out Int32 value)
        {
            return Int32.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_INT32_NUMERICAL_EXTENSIONS

        // Int64 (IntLike)

#if !T4INCLUDE__SUPPRESS_INT64_NUMERICAL_EXTENSIONS
        public static Int64 Min (this Int64 left, Int64 right) 
        {
            if (left < right)
            {
                return left;
            }
        
            return right;
        }

        public static Int64 Max (this Int64 left, Int64 right) 
        {
            if (left < right)
            {
                return right;
            }
        
            return left;
        }

        public static Int64 Clamp (this Int64 value, Int64 inclusiveMin, Int64 inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return inclusiveMin;
            }
        
            if (value > inclusiveMax)
            {
                return inclusiveMax;
            }

            return value;
        }

        public static bool IsBetween (this Int64 value, Int64 inclusiveMin, Int64 inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return false;
            }
        
            if (value > inclusiveMax)
            {
                return false;
            }

            return true;
        }

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

        public static bool IsAnyOn (this Int64 value, Int64 test)
        {
            return (value & test) != 0;
        }
        
        public static bool IsAnyOff (this Int64 value, Int64 test)
        {
            return (value & test) != test;
        }
        
        public static bool IsAllOn (this Int64 value, Int64 test)
        {
            return (value & test) == test;
        }
        
        public static bool IsAllOff (this Int64 value, Int64 test)
        {
            return (value & test) == 0;
        }
         
        public static bool TryParse (this string s, CultureInfo cultureInfo, out Int64 value)
        {
            return Int64.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_INT64_NUMERICAL_EXTENSIONS

        // Single (FloatLike)

#if !T4INCLUDE__SUPPRESS_SINGLE_NUMERICAL_EXTENSIONS
        public static Single Min (this Single left, Single right) 
        {
            if (left < right)
            {
                return left;
            }
        
            return right;
        }

        public static Single Max (this Single left, Single right) 
        {
            if (left < right)
            {
                return right;
            }
        
            return left;
        }

        public static Single Clamp (this Single value, Single inclusiveMin, Single inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return inclusiveMin;
            }
        
            if (value > inclusiveMax)
            {
                return inclusiveMax;
            }

            return value;
        }

        public static bool IsBetween (this Single value, Single inclusiveMin, Single inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return false;
            }
        
            if (value > inclusiveMax)
            {
                return false;
            }

            return true;
        }

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

        public static Single Lerp (
            this Single t,
            Single from,
            Single to
            )
        {
            return t.Clamp (0,1) * (to - from) + from;
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Single value)
        {                                                  
            return Single.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_SINGLE_NUMERICAL_EXTENSIONS

        // Double (FloatLike)

#if !T4INCLUDE__SUPPRESS_DOUBLE_NUMERICAL_EXTENSIONS
        public static Double Min (this Double left, Double right) 
        {
            if (left < right)
            {
                return left;
            }
        
            return right;
        }

        public static Double Max (this Double left, Double right) 
        {
            if (left < right)
            {
                return right;
            }
        
            return left;
        }

        public static Double Clamp (this Double value, Double inclusiveMin, Double inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return inclusiveMin;
            }
        
            if (value > inclusiveMax)
            {
                return inclusiveMax;
            }

            return value;
        }

        public static bool IsBetween (this Double value, Double inclusiveMin, Double inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return false;
            }
        
            if (value > inclusiveMax)
            {
                return false;
            }

            return true;
        }

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

        public static Double Lerp (
            this Double t,
            Double from,
            Double to
            )
        {
            return t.Clamp (0,1) * (to - from) + from;
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Double value)
        {                                                  
            return Double.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_DOUBLE_NUMERICAL_EXTENSIONS

        // Decimal (FloatLike)

#if !T4INCLUDE__SUPPRESS_DECIMAL_NUMERICAL_EXTENSIONS
        public static Decimal Min (this Decimal left, Decimal right) 
        {
            if (left < right)
            {
                return left;
            }
        
            return right;
        }

        public static Decimal Max (this Decimal left, Decimal right) 
        {
            if (left < right)
            {
                return right;
            }
        
            return left;
        }

        public static Decimal Clamp (this Decimal value, Decimal inclusiveMin, Decimal inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return inclusiveMin;
            }
        
            if (value > inclusiveMax)
            {
                return inclusiveMax;
            }

            return value;
        }

        public static bool IsBetween (this Decimal value, Decimal inclusiveMin, Decimal inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return false;
            }
        
            if (value > inclusiveMax)
            {
                return false;
            }

            return true;
        }

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

        public static Decimal Lerp (
            this Decimal t,
            Decimal from,
            Decimal to
            )
        {
            return t.Clamp (0,1) * (to - from) + from;
        }

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Decimal value)
        {                                                  
            return Decimal.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out value);
        }

#endif // T4INCLUDE__SUPPRESS_DECIMAL_NUMERICAL_EXTENSIONS

        // TimeSpan (TimeSpanLike)

#if !T4INCLUDE__SUPPRESS_TIMESPAN_NUMERICAL_EXTENSIONS
        public static TimeSpan Min (this TimeSpan left, TimeSpan right) 
        {
            if (left < right)
            {
                return left;
            }
        
            return right;
        }

        public static TimeSpan Max (this TimeSpan left, TimeSpan right) 
        {
            if (left < right)
            {
                return right;
            }
        
            return left;
        }

        public static TimeSpan Clamp (this TimeSpan value, TimeSpan inclusiveMin, TimeSpan inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return inclusiveMin;
            }
        
            if (value > inclusiveMax)
            {
                return inclusiveMax;
            }

            return value;
        }

        public static bool IsBetween (this TimeSpan value, TimeSpan inclusiveMin, TimeSpan inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return false;
            }
        
            if (value > inclusiveMax)
            {
                return false;
            }

            return true;
        }

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

#endif // T4INCLUDE__SUPPRESS_TIMESPAN_NUMERICAL_EXTENSIONS

        // DateTime (DateTimeLike)

#if !T4INCLUDE__SUPPRESS_DATETIME_NUMERICAL_EXTENSIONS
        public static DateTime Min (this DateTime left, DateTime right) 
        {
            if (left < right)
            {
                return left;
            }
        
            return right;
        }

        public static DateTime Max (this DateTime left, DateTime right) 
        {
            if (left < right)
            {
                return right;
            }
        
            return left;
        }

        public static DateTime Clamp (this DateTime value, DateTime inclusiveMin, DateTime inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return inclusiveMin;
            }
        
            if (value > inclusiveMax)
            {
                return inclusiveMax;
            }

            return value;
        }

        public static bool IsBetween (this DateTime value, DateTime inclusiveMin, DateTime inclusiveMax) 
        {
            if (value < inclusiveMin)
            {
                return false;
            }
        
            if (value > inclusiveMax)
            {
                return false;
            }

            return true;
        }

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

#endif // T4INCLUDE__SUPPRESS_DATETIME_NUMERICAL_EXTENSIONS

    }
}


