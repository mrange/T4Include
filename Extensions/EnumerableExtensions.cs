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
            var dic = new Dictionary<TKey, TValue>(capacity, comparer);

            values = values ?? Array<T>.Empty;

            foreach (var value in values)
            {
                var key = keySelector(value);
                TValue existingValue;
                if (dic.TryGetValue(key, out existingValue))
                {
                    var newValue = duplicateResolver(existingValue, value);
                    dic[key] = newValue;
                }
                else
                {
                    var newValue = valueSelector(value);
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
            return values.ToDictionaryAndResolveDuplicates(
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
            return values.ToDictionaryAndResolveDuplicates(
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
            return values.ToDictionaryAndKeepFirst(
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

    }
}
