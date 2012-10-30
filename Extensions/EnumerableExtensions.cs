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

// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier

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
