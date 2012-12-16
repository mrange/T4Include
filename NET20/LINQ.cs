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

// ### INCLUDE: Common.cs

namespace System.Linq
{
    using System.Collections.Generic;

    public interface IOrderedEnumerable<TElement> : IEnumerable<TElement>
    {
        IOrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending);
    } 

    static partial class Enumerable
    {
        public static IEnumerable<T> Where<T>(
            this IEnumerable<T> source,
            Func<T, bool> predicate
            )
        {
            foreach (var v in source)
            {
                if (predicate(v))
                {
                    yield return v;
                }
            }
        }

        public static IEnumerable<TResult> Select<T>(
            this IEnumerable<T> source,
            Func<T, TResult> predicate
            )
        {
            foreach (var v in source)
            {
                yield return predicate(v);
            }
        }

    }
}
