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

// ReSharper disable InconsistentNaming

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FileInclude.Source.Extensions;
using FileInclude.Source.Testing;

namespace Test_Functionality.Collections
{
    using FileInclude.Source.Collections;

    sealed partial class TestsFor_SkipList
    {
        const int TestSetSize = 1000;

        static SkipList<int, string> GenerateFromSet (int[] set)
        {
            set = set ?? new int[0];

            var skipList = new SkipList<int, string> ();

            foreach (var v in set)
            {
                var addResult = skipList.TryAdd (v, v.ToString (CultureInfo.InvariantCulture));
                TestFor.Equality (true, addResult, "SkipList.TryAdd ({0},'{0}') must succeed".FormatWith (v));
            }

            return skipList;
        }

        public void Test_Basic ()
        {
            {
                var sortedSet       = Enumerable.Range (0, TestSetSize).ToArray ();
                var sortedInserts   = GenerateFromSet (sortedSet);

                TestSkipListContent (sortedSet, sortedInserts);
            }

            {
                var sortedSet       = Enumerable.Range (0, TestSetSize).ToArray ();
                var randomSet       = sortedSet.ToArray ();
                var random          = new Random (19740531);
                randomSet.Shuffle (random);

                var randomInserts   = GenerateFromSet (randomSet);

                TestSkipListContent (sortedSet, randomInserts);
            }
        }

        static void TestSkipListContent(int[] set, SkipList<int, string> skipList)
        {
            var result          = skipList.ToArray ();

            if (TestFor.Equality(set.Length, result.Length, "SkipList Count must match"))
            {
                for (var index = 0; index < set.Length; index++)
                {
                    var expected = set[index];
                    var found = result[index];

                    TestFor.Equality(expected, found.Key, "The key must be in the right position in skiplist");
                }
            }

            for (var index = 0; index < set.Length; index++)
            {
                var expected = set[index];
                var found = skipList.Find(expected);

                if (TestFor.Equality(true, found != null, "The key must in the skiplist".FormatWith(expected)))
                {
                    TestFor.Equality(expected, found.Key, "The found node must have the right key");
                    TestFor.Equality(expected.ToString(CultureInfo.InvariantCulture), found.Value, "The found node must have the right value");
                }
            }
        }

        bool TryAdd<TKey, TValue> (SortedDictionary<TKey, TValue> sd, TKey key, TValue value)
        {
            if (sd.ContainsKey (key))
            {
                return false;
            }

            sd.Add (key, value);
            return true;
        }

        public void Test_Clear ()
        {
            var sortedSet = Enumerable.Range (0, TestSetSize).ToArray ();

            var skipList = GenerateFromSet (sortedSet);

            TestFor.Equality (TestSetSize, skipList.Count, "SkipList Count must be correct");

            skipList.Clear ();

            TestFor.Equality (0, skipList.Count, "SkipList Count must be zero");

        }

        public void Test_CompareWithSortedDictionary ()
        {
            var sortedSet = Enumerable.Range (0, TestSetSize).ToArray ();

            var skipList = GenerateFromSet (sortedSet);
            var sortedDictionary = new SortedDictionary<int, string> ();

            foreach (var v in sortedSet)
            {
                sortedDictionary.Add (v, v.ToString (CultureInfo.InvariantCulture));
            }

            var random = new Random (19740531);

            TestSkipListContent(sortedDictionary, skipList);

            for (var iter = 0; iter < TestSetSize / 10; ++iter)
            {

                var action = random.Next (0, 2);

                var v = random.Next (0, TestSetSize * 2);
                var value = v.ToString (CultureInfo.InvariantCulture);

                switch (action)
                {
                    case 0:
                        {
                            var slResult = skipList.TryAdd (v, value);
                            var sdResult = TryAdd (sortedDictionary, v, value);

                            TestFor.Equality (sdResult, slResult, "SkipList and SortedDictionary add result must be equal");
                        }
                        break;
                    case 1:
                        {
                            var slResult = skipList.TryRemove (v);
                            var sdResult = sortedDictionary.Remove (v);

                            TestFor.Equality (sdResult, slResult, "SkipList and SortedDictionary remove result must be equal");
                        }
                        break;
                    default:
                        break;
                }

                TestSkipListContent(sortedDictionary, skipList);
            }

        }

        static void TestSkipListContent(SortedDictionary<int, string> sortedDictionary, SkipList<int, string> skipList)
        {
            if (TestFor.Equality(sortedDictionary.Count, skipList.Count, "SkipList and SortedDictionary count must be equal"))
            {
                var firstMismatch = sortedDictionary
                    .Zip(skipList, (l, r) => new {Left = l, Right = r})
                    .FirstOrDefault(uo => uo.Left.Key != uo.Right.Key)
                    ;

                var leftValue = firstMismatch != null ? firstMismatch.Left.Key : 0;
                var rightValue = firstMismatch != null ? firstMismatch.Right.Key : 0;

                TestFor.Equality(true, firstMismatch == null, "SkipList and SortedDictionary content must be equal, first mismatch: {0} != {1}".FormatWith (leftValue, rightValue));
            }
        }
    }
}
