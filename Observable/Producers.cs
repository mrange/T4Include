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

// ### INCLUDE: ../Common/Log.cs
// ### INCLUDE: Observables.cs

namespace Source.Observable
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Source.Common;

    partial interface IProducer<out T> : IObservable<T>, IDisposable
    {
        void Start ();
    }

    abstract partial class BaseProducer<T> : BaseObservable<T>, IProducer<T>
    {
        sealed public partial class ProducedValue
        {
            public readonly T Value;

            public ProducedValue (T value)
            {
                Value = value;
            }
        }

        readonly TaskFactory                m_taskFactory               ;
        readonly int                        m_maxFailureCount           ;

        volatile Task m_task;

        protected BaseProducer (TaskFactory taskFactory, int maxFailureCount = 10)
        {
            m_taskFactory               = taskFactory   ?? Task.Factory     ;
            m_maxFailureCount           = maxFailureCount                   ;
        }

        protected override void OnDispose ()
        {
            base.OnDispose ();

            lock (Lock)
            {
                if (m_task != null)
                {
                    try
                    {
                        m_task.Dispose ();
                    }
                    catch (Exception exc)
                    {
                        Log.Exception ("BaseProducer.OnDispose: Disposing task threw exception: {0}", exc);
                    }
                }
            }
        }

        public void Start ()
        {
            if (m_task != null)
            {
                return;
            }

            lock (Lock)
            {
                if (m_task != null)
                {
                    return;
                }

                if (IsDisposed)
                {
                    throw new ObjectDisposedException ("Producer", "Can't start a disposed producer");
                }

                m_task = m_taskFactory.StartNew (OnProduce, CancellationToken, TaskCreationOptions.LongRunning);
            }
        }

        void OnProduce (object obj)
        {
            try
            {
                var productionError = 0;
                var done = false;

                while (!CancellationToken.IsCancellationRequested && !done)
                {
                    try
                    {
                        ProducedValue value;
                        while (!CancellationToken.IsCancellationRequested && (value = ProduceValue (CancellationToken)) != null)
                        {
                            SendValue (value.Value);
                        }

                        done = true;
                    }
                    catch (Exception exc)
                    {
                        ++productionError;
                        
                        SendException (exc);

                        done |= productionError > m_maxFailureCount;
                    }
                }

                TerminateObservers();

                if (productionError == m_maxFailureCount)
                {
                    Log.Error ("Producer.OnProduce: Producer terminated due to max failure count reached: {0}", m_maxFailureCount);
                }

            }
            catch (Exception exc)
            {
                Log.Exception ("Producer.OnProduce: Caught exception, terminating: {0}", exc);
            }
        }

        protected abstract ProducedValue ProduceValue(CancellationToken cancellationToken);
    }

    sealed partial class EnumerableProducer<T> : BaseProducer<T>
    {
        readonly IEnumerator<T> m_enumerator;

        public EnumerableProducer (TaskFactory taskFactory, IEnumerable<T> enumerable, int maxFailureCount = 10) 
            :   base (taskFactory, maxFailureCount)
        {
            enumerable  = enumerable ?? Array<T>.Empty  ;
            m_enumerator= enumerable.GetEnumerator ()   ;
        }

        protected override ProducedValue ProduceValue (CancellationToken cancellationToken)
        {
            return !cancellationToken.IsCancellationRequested && m_enumerator.MoveNext()
                ?   new ProducedValue (m_enumerator.Current)
                :   null
                ;
        }

        protected override void OnDispose ()
        {
            base.OnDispose();

            try
            {
                m_enumerator.Dispose ();
            }
            catch (Exception exc)
            {
                Log.Exception ("EnumerableProducer.OnDispose: Disposing enumerator threw exception: {0}", exc);
            }
        }
    }

}