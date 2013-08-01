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

using System.Collections.Concurrent;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using FileInclude.Source.Observable;
using FileInclude.Source.Testing;
using FileInclude.Source.Extensions;

namespace Test_Functionality.Observable
{
    [TestsFor]
    sealed partial class TestsFor_SkipList
    {
        const int EnumerableCount = 1000;

        public void Test_Basic ()
        {
            var test = Enumerable.Range (0, EnumerableCount);
            var producer = new EnumerableProducer<int> (Task.Factory, test);

            var queue = new ConcurrentQueue<int> ();

            var l = new object ();

            using (producer.Subscribe (
                queue.Enqueue,
                () =>
                {
                    lock (l)
                    {
                        Monitor.Pulse (l);
                    }   
                }
                ))
            {
                lock (l)
                {
                    producer.Start ();
                    Monitor.Wait (l);
                }
            }


            TestFor.Equality (EnumerableCount, queue.Count, "Queue must have expected count");

            TestFor.Equality (true, test.SequenceEqual (queue), "Queue must be equal to test sequence");


        }

    }
}
