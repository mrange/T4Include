

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





// ReSharper disable PartialTypeWithSinglePart

namespace Source.Extensions
{
    using System;
    using System.Globalization;

    static partial class NumericalExtensions
    {
        // Byte (IntLike)

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

        // Int16 (IntLike)

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

        // Int32 (IntLike)

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

        // Int64 (IntLike)

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

        // Single (FloatLike)

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

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Single result)
        {                                                  
            return Single.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out result);
        }

        // Double (FloatLike)

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

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Double result)
        {                                                  
            return Double.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out result);
        }

        // Decimal (FloatLike)

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

        public static bool TryParse (this string s, CultureInfo cultureInfo, out Decimal result)
        {                                                  
            return Decimal.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out result);
        }

    }
}


