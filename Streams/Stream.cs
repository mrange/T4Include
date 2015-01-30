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

namespace Source.Streams
{
    using System;
    using System.Collections.Generic;

    partial class StreamContext
    {
        public bool IsCancelled = false;
    }

    partial interface IStream<T>
    {
        void BuildChain (StreamContext ctx, Action<T> a);
        void BuildCancellableChain (StreamContext ctx, Action<T> a);
    }

    static partial class Stream
    {

        abstract partial class BaseStream<T,U> : IStream<U>
        {
            protected readonly IStream<T> Previous;

            public BaseStream (IStream<T> s)
            {
                Previous = s;
            }

            public abstract void BuildChain(StreamContext ctx, Action<U> a);

            public abstract void BuildCancellableChain(StreamContext ctx, Action<U> a);
        }

        abstract partial class BasicStream<T,U> : BaseStream<T,U>
        {
            public BasicStream (IStream<T> s)
                : base (s)
            {
            }

            protected abstract Action<T> OnBuildAction (StreamContext ctx, Action<U> a);

            public override void BuildChain (StreamContext ctx, Action<U> a)
            {
                Previous.BuildChain (ctx, OnBuildAction (ctx, a));
            }

            public override void BuildCancellableChain (StreamContext ctx, Action<U> a)
            {
                Previous.BuildCancellableChain (ctx, OnBuildAction (ctx, a));
            }
        }

        abstract partial class CancellableStream<T,U> : BaseStream<T,U>
        {
            public CancellableStream (IStream<T> s)
                : base (s)
            {
            }

            protected abstract Action<T> OnBuildAction (StreamContext ctx, Action<U> a);

            public override void BuildChain (StreamContext ctx, Action<U> a)
            {
                Previous.BuildCancellableChain (ctx, OnBuildAction (ctx, a));
            }

            public override void BuildCancellableChain (StreamContext ctx, Action<U> a)
            {
                Previous.BuildCancellableChain (ctx, OnBuildAction (ctx, a));
            }
        }

        partial class FromArrayStream<T> : IStream<T>
        {
            readonly T[] m_values;
            public FromArrayStream (T[] values)
            {
                m_values = values;
            }

            public void BuildChain (StreamContext ctx, Action<T> a)
            {
                foreach (var v in m_values)
                {
                    a (v);
                }
            }

            public void BuildCancellableChain (StreamContext ctx, Action<T> a)
            {
                foreach (var v in m_values)
                {
                    a (v);
                    if (ctx.IsCancelled)
                    {
                        break;
                    }
                }
            }
        }

        partial class RangeIntStream : IStream<int>
        {
            readonly int m_inclusiveFrom;
            readonly int m_increment    ;
            readonly int m_exclusiveTo  ;

            public RangeIntStream (int inclusiveFrom, int increment, int exclusiveTo)
            {
                m_inclusiveFrom = inclusiveFrom ;
                m_increment     = increment     ;
                m_exclusiveTo   = exclusiveTo   ;
            }

            public void BuildChain (StreamContext ctx, Action<int> a)
            {
                for (var iter = m_inclusiveFrom; iter < m_exclusiveTo; iter += m_increment)
                {
                    a (iter);
                }
            }

            public void BuildCancellableChain (StreamContext ctx, Action<int> a)
            {
                for (var iter = m_inclusiveFrom; iter < m_exclusiveTo; iter += m_increment)
                {
                    a (iter);
                    if (ctx.IsCancelled)
                    {
                        break;
                    }
                }
            }
        }

        partial class WhereStream<T> : BasicStream<T,T>
        {
            readonly Func<T, bool>  m_predicate ;

            public WhereStream (IStream<T> s, Func<T, bool> p)
                : base (s)
            {
                m_predicate = p;
            }

            protected override Action<T> OnBuildAction(StreamContext ctx, Action<T> a)
            {
                return v => { if (m_predicate (v)) {a (v);} };
            } 
        }

        partial class SkipStream<T> : BasicStream<T,T>
        {
            readonly int m_n;

            public SkipStream (IStream<T> s, int n)
                : base (s)
            {
                m_n = n;
            }

            protected override Action<T> OnBuildAction(StreamContext ctx, Action<T> a)
            {
                var remaining = m_n;
                return v => 
                    { 
                        if (remaining > 0)
                        {
                            --remaining;
                        }
                        else
                        {
                            a (v);
                        }
                    };
            } 
        }

        partial class TakeStream<T> : CancellableStream<T,T>
        {
            readonly int m_n;

            public TakeStream (IStream<T> s, int n)
                : base (s)
            {
                m_n = n;
            }

            protected override Action<T> OnBuildAction(StreamContext ctx, Action<T> a)
            {
                var remaining = m_n;
                return v => 
                    { 
                        if (remaining >= 0)
                        {
                            --remaining;
                            a (v);
                        }
                        else
                        {
                            ctx.IsCancelled = true;
                        }
                    };
            } 
        }

        partial class SelectStream<T,U> : BasicStream<T,U>
        {
            readonly Func<T, U>  m_predicate ;

            public SelectStream (IStream<T> s, Func<T, U> p)
                : base (s)
            {
                m_predicate = p;
            }

            protected override Action<T> OnBuildAction(StreamContext ctx, Action<U> a)
            {
                return v => a (m_predicate (v));
            } 
        }

        public static IStream<T> CreateStream<T> (this T[] values)
        {
            return new FromArrayStream<T> (values);
        }

        public static IStream<int> Range (int inclusiveFrom, int increment, int exclusiveTo)
        {
            return new RangeIntStream (inclusiveFrom, increment, exclusiveTo);
        }

        public static IStream<T> Where<T> (this IStream<T> s, Func<T, bool> p)
        {
            return new WhereStream<T> (s, p);
        }

        public static IStream<U> Select<T,U> (this IStream<T> s, Func<T, U> p)
        {
            return new SelectStream<T,U> (s, p);
        }

        public static IStream<T> Skip<T> (this IStream<T> s, int n)
        {
            return new SkipStream<T> (s, n);
        }

        public static IStream<T> Take<T> (this IStream<T> s, int n)
        {
            return new TakeStream<T> (s, n);
        }

        public static int ToSum (this IStream<int> stream, int initialValue = 0)
        {
            var sum = initialValue;

            stream.BuildChain (new StreamContext (), v => sum += v);

            return sum;
        }

        public static long ToSum (this IStream<long> stream, long initialValue = 0L)
        {
            var sum = initialValue;

            stream.BuildChain (new StreamContext (), v => sum += v);

            return sum;
        }

    }
}
