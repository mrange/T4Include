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

namespace Test_Functionality.Streams
{
    using FileInclude.Source.Common;
    using FileInclude.Source.Extensions;
    using FileInclude.Source.Streams;
    using FileInclude.Source.Testing;

    using System;
    using System.Diagnostics;
    using System.Linq;

    sealed partial class TestsFor_Streams
    {
        static Func<long, bool> wheref  ;
        static Func<long, long> selectf ;

        static WhereFunction    whereif     = new WhereFunction ();
        static SelectFunction   selectif    = new SelectFunction ();

        class Obj
        {
            public bool Where (long v)
            {
                return v % 2L == 0;
            }

            public long Select (long v)
            {
                return v + 1L;
            }
        }

        static TestsFor_Streams ()
        {
            var obj = new Obj ();
            wheref  = obj.Where;
            selectf = obj.Select;


        }
        
        static int Series (int f, int t)
        {
            return (t - f + 1)*(t + f) / 2;
        }

        static Tuple<long, T> PerfTest<T> (int count, Func<T> action)
        {
            var sw = new Stopwatch ();
            sw.Start ();

            var res = action ();

            for (var iter = 1; iter < count; ++iter)
            {
                action ();
            }

            sw.Stop ();

            return Tuple.Create (sw.ElapsedMilliseconds, res);
        }    

        public void Test_Functionality ()
        {
            {
                var sum = 
                    Stream.Range (0, 1, 101)
                    .ToSum ();

                TestFor.Equality (Series (0, 100), sum, "Testing sum of 0..100");
            }

            {
                var sum = 
                    Stream.Range (0, 1, 101)
                    .Take (10)
                    .ToSum ();

                TestFor.Equality (Series (0, 10), sum, "Testing sum of 0..10");
            }

            {
                var sum = 
                    Stream.Range (0, 1, 101)
                    .Skip (90)
                    .ToSum ();

                TestFor.Equality (Series (90, 100), sum, "Testing sum of 90..100");
            }

        }

        interface IFunction<T0, TResult>
        {
            TResult Do (T0 v0);
        }

        class WhereFunction : IFunction<long, bool>
        {
            public bool Do (long v)
            {
                return v % 2L == 0L;
            }
        }

        class SelectFunction : IFunction<long, long>
        {
            public long Do (long v)
            {
                return v + 1L;
            }
        }

        public void Test_Performance ()
        {
            var total = 50000000;
            var outers = new []
                {
                    10          ,
                    1000        ,
                    100000      ,
                    total / 5   ,
                };

            foreach (var outer in outers)
            {
                var inner = total / outer;

                Log.HighLight ("Performance run: Total: {0}, Outer: {1}, Inner: {2}", total, outer, inner);

                var data = Enumerable.Range (1, inner).Select (i => (long)i).ToArray ();

                Func<long> forSum = () => 
                    {
                        var sum = 0L;
                        foreach (var v in data)
                        {
                            if (v % 2L == 0L)
                            {
                                sum += v + 1L;
                            }
                        }

                        return sum;
                    };

                Func<long> linqSum = () => 
                    {
                        return data
                            .Where (v => v % 2L == 0L)
                            .Select (v => v + 1L)
                            .Sum ()
                            ;
                    };

                var wf = wheref;
                var sf = selectf;

                Func<long> funcSum = () => 
                    {
                        var sum = 0L;
                        foreach (var v in data)
                        {
                            if (wf (v))
                            {
                                var s = sf (v);
                                sum += s;
                            }
                        }

                        return sum;
                    };

                Func<long> interfaceSum = () => 
                    {
                        var sum = 0L;
                        foreach (var v in data)
                        {
                            if (whereif.Do (v))
                            {
                                var s = selectif.Do (v);
                                sum += s;
                            }
                        }

                        return sum;
                    };

                Func<long> streamSum = () => 
                    {
                        return data
                            .CreateStream ()
                            .Where (v => v % 2L == 0L)
                            .Select (v => v + 1L)
                            .ToSum ()
                            ;
                    };

                var testCases = new []
                    {
                        Tuple.Create ("LINQ"    , linqSum   ),
                        Tuple.Create ("For"     , forSum    ),
                        Tuple.Create ("Stream"  , streamSum ),
                        Tuple.Create ("Func"    , funcSum   ),
                        Tuple.Create ("If"      , interfaceSum   ),

                    };

                var testResults = 
                    testCases
                    .Select (t => 
                        {
                            var tt = PerfTest (outer, t.Item2);
                            return Tuple.Create (t.Item1, tt.Item1, tt.Item2);
                        })
                    .ToArray ()
                    ;

                var seqElapsed  = testResults[0].Item2;
                var seqResult   = testResults[0].Item3;

                foreach (var testResult in testResults)
                {
                    var name    = testResult.Item1;
                    var elapsed = testResult.Item2;
                    var result  = testResult.Item3;
                    Log.Info ("TestResult for: {0} - Time: {1} ms", name, elapsed);

                    TestFor.Equality (seqResult, result, "Comparing range sum: {0},{1},{2},{3}".FormatWith (name, total, outer, inner));
                }
            }
        }
    }
}
