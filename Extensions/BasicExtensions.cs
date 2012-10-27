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

// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier

namespace Source.Extensions
{
    using System;
    using System.Collections.Generic;
    using Source.Common;

    static partial class BasicExtensions
    {
        public static bool IsNullOrEmpty (this string v)
        {
            return string.IsNullOrEmpty(v);
        }

        public static string DefaultTo (this string v, string defaultValue = "")
        {
            return !v.IsNullOrEmpty() ? v : defaultValue;
        }

        public static IEnumerable<T> DefaultTo<T>(this IEnumerable<T> v, IEnumerable<T> defaultValue = null)
        {
            return v ?? Array<T>.Empty;
        }

        public static T DefaultTo<T>(this T v, T defaultValue = default(T))
            where T : struct, IEquatable<T>
        {
            return !v.Equals(default(T)) ? v : defaultValue;
        }

        public static TValue Lookup<TKey, TValue> (IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default (TValue))
        {
            if (dictionary == null)
            {
                return defaultValue;
            }

            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }

    }
}
