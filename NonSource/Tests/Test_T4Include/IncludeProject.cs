


// @@@ SKIPPING (Blacklisted): C:\temp\GitHub\T4Include\NonSource\Source\Program.cs

// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # text template file (.tt)                                                      #
// ############################################################################



// ############################################################################
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Array.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\ConsoleLog.cs
// @@@ INCLUDE_FOUND: Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ INCLUDE_FOUND: Array.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\NumericalExtensions.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\BasicExtensions.cs
// @@@ INCLUDE_FOUND: ../Common/Array.cs
// @@@ INCLUDE_FOUND: ../Common/Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\EnumerableExtensions.cs
// @@@ INCLUDE_FOUND: ../Common/Array.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Array.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Array.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Array.cs
// ############################################################################
// Certains directives such as #define and // Resharper comments has to be 
// moved to top in order to work properly    
// ############################################################################
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ############################################################################

// ############################################################################
namespace ProjectInclude
{
    // ----------------------------------------------------------------------------------------------
    // Copyright (c) Mårten Rånge.
    // ----------------------------------------------------------------------------------------------
    // This source code is subject to terms and conditions of the Microsoft Public License. A 
    // copy of the license can be found in the License.html file at the root of this distribution. 
    // If you cannot locate the  Microsoft Public License, please send an email to 
    // dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
    //  by the terms of the Microsoft Public License.
    // ----------------------------------------------------------------------------------------------
    // You must not remove this notice, or any other, from this software.
    // ----------------------------------------------------------------------------------------------
    
    namespace Source.Common
    {
        static class Array<T>
        {
            public static readonly T[] Empty = new T[0];
        }
    }
}

// ############################################################################
namespace ProjectInclude
{
    // ----------------------------------------------------------------------------------------------
    // Copyright (c) Mårten Rånge.
    // ----------------------------------------------------------------------------------------------
    // This source code is subject to terms and conditions of the Microsoft Public License. A 
    // copy of the license can be found in the License.html file at the root of this distribution. 
    // If you cannot locate the  Microsoft Public License, please send an email to 
    // dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
    //  by the terms of the Microsoft Public License.
    // ----------------------------------------------------------------------------------------------
    // You must not remove this notice, or any other, from this software.
    // ----------------------------------------------------------------------------------------------
    
    
    
    namespace Source.Common
    {
        using System;
        using System.Globalization;
    
        partial class Log
        {
            static readonly object s_colorLock = new object ();
            static partial void Partial_LogMessage (Level level, ConsoleColor levelColor, string levelMessage, string message)
            {
                var now = DateTime.Now;
                var finalMessage = string.Format (
                    CultureInfo.InvariantCulture,
                    "{0:HHmmss} {1}:{2}",
                    now,
                    levelMessage,
                    message
                    );
                lock (s_colorLock)
                {
                    var oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = levelColor;
                    try
                    {
                        Console.WriteLine (finalMessage);
                    }
                    finally
                    {
                        Console.ForegroundColor = oldColor;
                    }
    
                }
            }
        }
    }
}

// ############################################################################
namespace ProjectInclude
{
    // ----------------------------------------------------------------------------------------------
    // Copyright (c) Mårten Rånge.
    // ----------------------------------------------------------------------------------------------
    // This source code is subject to terms and conditions of the Microsoft Public License. A 
    // copy of the license can be found in the License.html file at the root of this distribution. 
    // If you cannot locate the  Microsoft Public License, please send an email to 
    // dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
    //  by the terms of the Microsoft Public License.
    // ----------------------------------------------------------------------------------------------
    // You must not remove this notice, or any other, from this software.
    // ----------------------------------------------------------------------------------------------
    
    
    
    namespace Source.Common
    {
        using System;
        using System.Globalization;
    
        static partial class Log
        {
            static partial void Partial_LogMessage (Level level, ConsoleColor levelColor, string levelMessage, string message);
            static partial void Partial_ExceptionOnLog (Level level, string format, object[] args, Exception exc);
    
            public enum Level
            {
                Success     =  1000,
                HighLight   =  2000,
                Info        =  3000,
                Warning     = 10000,
                Error       = 20000,
                Exception   = 21000,
            }
    
            static ConsoleColor GetLevelColor (Level level)
            {
                switch (level)
                {
                    case Level.Success:
                        return ConsoleColor.Green;
                    case Level.HighLight:
                        return ConsoleColor.White;
                    case Level.Info:
                        return ConsoleColor.Gray;
                    case Level.Warning:
                        return ConsoleColor.Yellow;
                    case Level.Error:
                    case Level.Exception:
                        return ConsoleColor.Red;
                    default:
                        return ConsoleColor.Magenta;
                }
            }
    
            static string GetLevelMessage (Level level)
            {
                switch (level)
                {
                    case Level.Success:
                        return "SUCCESS  ";
                    case Level.HighLight:
                        return "HIGHLIGHT";
                    case Level.Info:
                        return "INFO     ";
                    case Level.Warning:
                        return "WARNING  ";
                    case Level.Error:
                        return "ERROR    ";
                    case Level.Exception:
                        return "EXCEPTION";
                    default:
                        return "UNKNOWN  ";
                }
            }
    
            public static void LogMessage (Level level, string format, params object[] args)
            {
                try
                {
                    Partial_LogMessage (level, GetLevelColor (level), GetLevelMessage (level), GetMessage (format, args));
                }
                catch (Exception exc)
                {
                    Partial_ExceptionOnLog (level, format, args, exc);
                }
                
            }
    
            static string GetMessage (string format, object[] args)
            {
                format = format ?? "";
                args = args ?? Array<object>.Empty;
    
                try
                {
                    return args.Length == 0
                               ? format
                               : string.Format (CultureInfo.InvariantCulture, format, args)
                        ;
                }
                catch (FormatException)
                {
    
                    return format;
                }
            }
        }
    }
}

// ############################################################################
namespace ProjectInclude
{
    
    
    // ----------------------------------------------------------------------------------------------
    // Copyright (c) Mårten Rånge.
    // ----------------------------------------------------------------------------------------------
    // This source code is subject to terms and conditions of the Microsoft Public License. A 
    // copy of the license can be found in the License.html file at the root of this distribution. 
    // If you cannot locate the  Microsoft Public License, please send an email to 
    // dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
    //  by the terms of the Microsoft Public License.
    // ----------------------------------------------------------------------------------------------
    // You must not remove this notice, or any other, from this software.
    // ----------------------------------------------------------------------------------------------
    
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
    
    
    
    namespace Source.Extensions
    {
        using System;
        using System.Globalization;
    
        static partial class NumericalExtensions
        {
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
    
            public static bool TryParse (this string s, out Byte result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Byte Parse (this string s, CultureInfo cultureInfo, Byte defaultValue)
            {
                Byte value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Byte Parse (this string s, Byte defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
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
             
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Byte result)
            {
                return Byte.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out result);
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
    
            public static bool TryParse (this string s, out Int16 result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Int16 Parse (this string s, CultureInfo cultureInfo, Int16 defaultValue)
            {
                Int16 value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Int16 Parse (this string s, Int16 defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
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
             
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Int16 result)
            {
                return Int16.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out result);
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
    
            public static bool TryParse (this string s, out Int32 result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Int32 Parse (this string s, CultureInfo cultureInfo, Int32 defaultValue)
            {
                Int32 value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Int32 Parse (this string s, Int32 defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
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
             
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Int32 result)
            {
                return Int32.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out result);
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
    
            public static bool TryParse (this string s, out Int64 result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Int64 Parse (this string s, CultureInfo cultureInfo, Int64 defaultValue)
            {
                Int64 value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Int64 Parse (this string s, Int64 defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
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
             
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Int64 result)
            {
                return Int64.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out result);
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
    
            public static bool TryParse (this string s, out Single result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Single Parse (this string s, CultureInfo cultureInfo, Single defaultValue)
            {
                Single value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Single Parse (this string s, Single defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static Single Lerp (
                this Single t,
                Single from,
                Single to
                )
            {
                return t.Clamp (0,1) * (to - from) + from;
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Single result)
            {                                                  
                return Single.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out result);
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
    
            public static bool TryParse (this string s, out Double result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Double Parse (this string s, CultureInfo cultureInfo, Double defaultValue)
            {
                Double value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Double Parse (this string s, Double defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static Double Lerp (
                this Double t,
                Double from,
                Double to
                )
            {
                return t.Clamp (0,1) * (to - from) + from;
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Double result)
            {                                                  
                return Double.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out result);
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
    
            public static bool TryParse (this string s, out Decimal result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Decimal Parse (this string s, CultureInfo cultureInfo, Decimal defaultValue)
            {
                Decimal value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Decimal Parse (this string s, Decimal defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static Decimal Lerp (
                this Decimal t,
                Decimal from,
                Decimal to
                )
            {
                return t.Clamp (0,1) * (to - from) + from;
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Decimal result)
            {                                                  
                return Decimal.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out result);
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
    
            public static bool TryParse (this string s, out TimeSpan result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static TimeSpan Parse (this string s, CultureInfo cultureInfo, TimeSpan defaultValue)
            {
                TimeSpan value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static TimeSpan Parse (this string s, TimeSpan defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out TimeSpan result)
            {                                                  
                return TimeSpan.TryParse (s ?? "", cultureInfo, out result);
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
    
            public static bool TryParse (this string s, out DateTime result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static DateTime Parse (this string s, CultureInfo cultureInfo, DateTime defaultValue)
            {
                DateTime value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static DateTime Parse (this string s, DateTime defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out DateTime result)
            {                                                  
                return DateTime.TryParse (s ?? "", cultureInfo, DateTimeStyles.AssumeLocal, out result);
            }
    
    #endif // T4INCLUDE__SUPPRESS_DATETIME_NUMERICAL_EXTENSIONS
    
        }
    }
    
    
}

// ############################################################################
namespace ProjectInclude
{
    // ----------------------------------------------------------------------------------------------
    // Copyright (c) Mårten Rånge.
    // ----------------------------------------------------------------------------------------------
    // This source code is subject to terms and conditions of the Microsoft Public License. A 
    // copy of the license can be found in the License.html file at the root of this distribution. 
    // If you cannot locate the  Microsoft Public License, please send an email to 
    // dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
    //  by the terms of the Microsoft Public License.
    // ----------------------------------------------------------------------------------------------
    // You must not remove this notice, or any other, from this software.
    // ----------------------------------------------------------------------------------------------
    
    
    
    namespace Source.Extensions
    {
        using System;
        using System.Collections.Generic;
        using System.Globalization;
        using System.Text;
    
        using Source.Common;
    
        static partial class BasicExtensions
        {
            public static bool IsNullOrWhiteSpace (this string v)
            {
                return string.IsNullOrWhiteSpace (v);
            }
    
            public static bool IsNullOrEmpty (this string v)
            {
                return string.IsNullOrEmpty (v);
            }
    
            public static string DefaultTo (this string v, string defaultValue = null)
            {
                return !v.IsNullOrEmpty () ? v : (defaultValue ?? "");
            }
    
            public static IEnumerable<T> DefaultTo<T>(
                this IEnumerable<T> values, 
                IEnumerable<T> defaultValue = null
                )
            {
                return values ?? defaultValue ?? Array<T>.Empty;
            }
    
            public static T[] DefaultTo<T>(this T[] values, T[] defaultValue = null)
            {
                return values ?? defaultValue ?? Array<T>.Empty;
            }
    
            public static T DefaultTo<T>(this T v, T defaultValue = default (T))
                where T : struct, IEquatable<T>
            {
                return !v.Equals (default (T)) ? v : defaultValue;
            }
    
            public static string FormatWith (this string format, CultureInfo cultureInfo, params object[] args)
            {
                return string.Format (cultureInfo, format ?? "", args.DefaultTo ());
            }
    
            public static string FormatWith (this string format, params object[] args)
            {
                return format.FormatWith (CultureInfo.InvariantCulture, args);
            }
    
            public static TValue Lookup<TKey, TValue>(
                this IDictionary<TKey, TValue> dictionary, 
                TKey key, 
                TValue defaultValue = default (TValue))
            {
                if (dictionary == null)
                {
                    return defaultValue;
                }
    
                TValue value;
                return dictionary.TryGetValue (key, out value) ? value : defaultValue;
            }
    
            public static TValue GetOrAdd<TKey, TValue>(
                this IDictionary<TKey, TValue> dictionary, 
                TKey key, 
                TValue defaultValue = default (TValue))
            {
                if (dictionary == null)
                {
                    return defaultValue;
                }
    
                TValue value;
                if (!dictionary.TryGetValue (key, out value))
                {
                    value = defaultValue;
                    dictionary[key] = value;
                }
    
                return value;
            }
    
            public static TValue GetOrAdd<TKey, TValue>(
                this IDictionary<TKey, TValue> dictionary,
                TKey key,
                Func<TValue> valueCreator
                )
            {
                if (dictionary == null)
                {
                    return valueCreator ();
                }
    
                TValue value;
                if (!dictionary.TryGetValue (key, out value))
                {
                    value = valueCreator ();
                    dictionary[key] = value;
                }
    
                return value;
            }
    
            public static void DisposeNoThrow (this IDisposable disposable)
            {
                try
                {
                    if (disposable != null)
                    {
                        disposable.Dispose ();
                    }
                }
                catch (Exception exc)
                {
                    Log.LogMessage (Log.Level.Exception, "DisposeNoThrow: Dispose threw: {0}", exc);
                }
            }
    
            public static TTo CastTo<TTo> (object value, TTo defaultValue)
            {
                return value is TTo ? (TTo) value : defaultValue;
            }
    
            public static string Concatenate (this IEnumerable<string> values, string delimiter = null, int capacity = 16)
            {
                values = values ?? Array<string>.Empty;
                delimiter = delimiter ?? ", ";
                var first = true;
    
                var sb = new StringBuilder (capacity);     
    
                foreach (var v in values)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        sb.Append (delimiter);
                    }
    
                    sb.Append (v);
                }
    
                return sb.ToString ();
            }
        }
    }
}

// ############################################################################
namespace ProjectInclude
{
    // ----------------------------------------------------------------------------------------------
    // Copyright (c) Mårten Rånge.
    // ----------------------------------------------------------------------------------------------
    // This source code is subject to terms and conditions of the Microsoft Public License. A 
    // copy of the license can be found in the License.html file at the root of this distribution. 
    // If you cannot locate the  Microsoft Public License, please send an email to 
    // dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
    //  by the terms of the Microsoft Public License.
    // ----------------------------------------------------------------------------------------------
    // You must not remove this notice, or any other, from this software.
    // ----------------------------------------------------------------------------------------------
    
    
    
    namespace Source.Extensions
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
        using Source.Common;
    
        static partial class EnumerableExtensions
        {
            public static Dictionary<TKey, TValue> ToDictionaryAndResolveDuplicates<T, TKey, TValue>(
                this IEnumerable<T> values,
                Func<T, TKey> keySelector,
                Func<T, TValue> valueSelector,
                Func<TValue, T, TValue> duplicateResolver,
                int capacity = 0,
                IEqualityComparer<TKey> comparer = null
                )
            {
                if (keySelector == null) throw new ArgumentNullException ("keySelector");
                if (valueSelector == null) throw new ArgumentNullException ("valueSelector");
                if (duplicateResolver == null) throw new ArgumentNullException ("duplicateResolver");
    
                var dic = new Dictionary<TKey, TValue>(capacity, comparer);
    
                values = values ?? Array<T>.Empty;
    
                foreach (var value in values)
                {
                    var key = keySelector (value);
                    TValue existingValue;
                    if (dic.TryGetValue (key, out existingValue))
                    {
                        var newValue = duplicateResolver (existingValue, value);
                        dic[key] = newValue;
                    }
                    else
                    {
                        var newValue = valueSelector (value);
                        dic[key] = newValue;
                    }
    
                }
    
                return dic;
            }
    
            public static Dictionary<TKey, T> ToDictionaryAndResolveDuplicates<T, TKey>(
                this IEnumerable<T> values,
                Func<T, TKey> keySelector,
                Func<T, T, T> duplicateResolver,
                int capacity = 0,
                IEqualityComparer<TKey> comparer = null
                )
            {
                return values.ToDictionaryAndResolveDuplicates (
                    keySelector,
                    v => v,
                    duplicateResolver,
                    capacity,
                    comparer
                    );
            }
    
            public static Dictionary<TKey, TValue> ToDictionaryAndKeepFirst<T, TKey, TValue>(
                this IEnumerable<T> values,
                Func<T, TKey> keySelector,
                Func<T, TValue> valueSelector,
                int capacity = 0,
                IEqualityComparer<TKey> comparer = null
                )
            {
                return values.ToDictionaryAndResolveDuplicates (
                    keySelector,
                    valueSelector,
                    (existingValue, newValue) => existingValue,
                    capacity,
                    comparer
                    );
            }
    
            public static Dictionary<TKey, T> ToDictionaryAndKeepFirst<T, TKey>(
                this IEnumerable<T> values,
                Func<T, TKey> keySelector,
                int capacity = 0,
                IEqualityComparer<TKey> comparer = null
                )
            {
                return values.ToDictionaryAndKeepFirst (
                    keySelector,
                    v => v,
                    capacity,
                    comparer
                    );
            }
    
            public static HashSet<T> ToHashSet<T>(this IEnumerable<T> values, IEqualityComparer<T> comparer = null)
            {
                values = values ?? Array<T>.Empty;
    
                return new HashSet<T>(values, comparer);
            }
    
            sealed partial class SelectorEqualityComparer<T, TKey> : IEqualityComparer<T>
            {
                static readonly IEqualityComparer<TKey> s_defaultComparer = EqualityComparer<TKey>.Default;
    
                readonly Func<T, TKey> m_selector;
    
                public SelectorEqualityComparer (Func<T, TKey> selector)
                {
                    System.Diagnostics.Debug.Assert (selector != null);
                    m_selector = selector;
                }
    
                public bool Equals (T x, T y)
                {
                    return s_defaultComparer.Equals (m_selector (x), m_selector (y));
                }
    
                public int GetHashCode (T obj)
                {
                    return s_defaultComparer.GetHashCode (m_selector (obj));
                }
    
            }
    
            public static IEnumerable<T> Distinct<T, TKey> (
                this IEnumerable<T> values, 
                Func<T, TKey> selector)
            {
                if (selector == null) throw new ArgumentNullException ("selector");
    
                values = values ?? Array<T>.Empty;
    
                return values.Distinct (new SelectorEqualityComparer<T, TKey>(selector));
            }
    
            public static IEnumerable<T> Union<T, TKey>(
                this IEnumerable<T> values,
                IEnumerable<T> otherValue,
                Func<T, TKey> selector)
            {
                if (selector == null) throw new ArgumentNullException ("selector");
    
                values = values ?? Array<T>.Empty;
                otherValue = otherValue ?? Array<T>.Empty;
    
                return values.Union (otherValue, new SelectorEqualityComparer<T, TKey>(selector));
            }
    
            public static IEnumerable<T> Intersect<T, TKey>(
                this IEnumerable<T> values,
                IEnumerable<T> otherValue,
                Func<T, TKey> selector)
            {
                if (selector == null) throw new ArgumentNullException ("selector");
    
                values = values ?? Array<T>.Empty;
                otherValue = otherValue ?? Array<T>.Empty;
    
                return values.Intersect (otherValue, new SelectorEqualityComparer<T, TKey>(selector));
            }
    
            public static IEnumerable<T> Except<T, TKey>(
                this IEnumerable<T> values,
                IEnumerable<T> otherValue,
                Func<T, TKey> selector)
            {
                if (selector == null) throw new ArgumentNullException ("selector");
    
                values = values ?? Array<T>.Empty;
                otherValue = otherValue ?? Array<T>.Empty;
    
                return values.Except (otherValue, new SelectorEqualityComparer<T, TKey>(selector));
            }
    
            public static bool SequenceEqual<T, TKey>(
                this IEnumerable<T> values,
                IEnumerable<T> otherValue,
                Func<T, TKey> selector)
            {
                if (selector == null) throw new ArgumentNullException ("selector");
    
                values = values ?? Array<T>.Empty;
                otherValue = otherValue ?? Array<T>.Empty;
    
                return values.SequenceEqual (otherValue, new SelectorEqualityComparer<T, TKey>(selector));
            }
    
        }
    }
}

// ############################################################################
namespace ProjectInclude
{
    // ----------------------------------------------------------------------------------------------
    // Copyright (c) Mårten Rånge.
    // ----------------------------------------------------------------------------------------------
    // This source code is subject to terms and conditions of the Microsoft Public License. A 
    // copy of the license can be found in the License.html file at the root of this distribution. 
    // If you cannot locate the  Microsoft Public License, please send an email to 
    // dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
    //  by the terms of the Microsoft Public License.
    // ----------------------------------------------------------------------------------------------
    // You must not remove this notice, or any other, from this software.
    // ----------------------------------------------------------------------------------------------
    
    
    namespace Source.Extensions
    {
        using System;
        using System.Windows.Threading;
        using System.Windows;
    
        using Source.Common;
    
        static partial class WpfExtensions
        {
            public static void Async_Invoke(this Dispatcher dispatcher, string actionName, Action action)
            {
                if (action == null)
                {
                    return;
                }
    
                Action act = () =>
                                 {
    #if DEBUG
                                     Log.LogMessage(Log.Level.Info, "Async_Invoke: {0}", actionName ?? "Unknown");
    #endif
    
                                     try
                                     {
                                         action();
                                     }
                                     catch (Exception exc)
                                     {
                                         Log.LogMessage(Log.Level.Exception, "Async_Invoke: Caught exception: {0}", exc);
                                     }
                                 };
    
                dispatcher = dispatcher ?? Dispatcher.CurrentDispatcher;
                dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, act);
            }
    
            public static void Async_Invoke(this DependencyObject dependencyObject, string actionName, Action action)
            {
                var dispatcher = dependencyObject == null ? Dispatcher.CurrentDispatcher : dependencyObject.Dispatcher;
    
                dispatcher.Async_Invoke(actionName, action);
            }
        }
    }
}
// ############################################################################

// ############################################################################
namespace ProjectInclude.Include
{
    static partial class MetaData
    {
        public const string RootPath        = @"C:\temp\GitHub\T4Include\NonSource\Tests\Test_T4Include\..\..\..";
        public const string IncludeDate     = @"2012-10-31T21:36:51";

        public const string Include_0       = @"C:\temp\GitHub\T4Include\Common\Array.cs";
        public const string Include_1       = @"C:\temp\GitHub\T4Include\Common\ConsoleLog.cs";
        public const string Include_2       = @"C:\temp\GitHub\T4Include\Common\Log.cs";
        public const string Include_3       = @"C:\temp\GitHub\T4Include\Extensions\NumericalExtensions.cs";
        public const string Include_4       = @"C:\temp\GitHub\T4Include\Extensions\BasicExtensions.cs";
        public const string Include_5       = @"C:\temp\GitHub\T4Include\Extensions\EnumerableExtensions.cs";
        public const string Include_6       = @"C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs";
    }
}
// ############################################################################




