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

// ### INCLUDE: ../Common/Array.cs
// ### INCLUDE: ../Common/Log.cs

// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier

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
                Log.Exception ("DisposeNoThrow: Dispose threw: {0}", exc);
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
