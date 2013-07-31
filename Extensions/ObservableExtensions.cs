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

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart

// ### INCLUDE: Generated_ObservableExtensions.cs

namespace Source.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    using Source.Common;

    partial interface IProducer<out T> : IObservable<T>, IDisposable
    {
        void Start ();
    }

    abstract partial class BaseProducer<T> : BaseDisposable, IProducer<T>
    {
        sealed public partial class ProducedValue
        {
            public readonly T Value;

            public ProducedValue(T value)
            {
                Value = value;
            }
        }

        sealed partial class Subscriber : BaseDisposable
        {
            readonly BaseProducer<T> m_producer;

            public Subscriber(BaseProducer<T> producer)
            {
                m_producer = producer;
            }

            protected override void OnDispose()
            {
                m_producer.Unsubscribe (this);
            }
        }

        readonly object                     m_lock                      ;
        readonly TaskFactory                m_taskFactory               ;
        readonly int                        m_maxFailureCount           ;
        readonly CancellationTokenSource    m_cancellationTokenSource   ;
        readonly CancellationToken          m_cancellationToken         ;

        readonly Dictionary<IDisposable, IObserver<T>>                  m_observers = new Dictionary<IDisposable, IObserver<T>> ();

        volatile Task m_task;

        public BaseProducer (TaskFactory taskFactory, int maxFailureCount = 10)
        {
            m_taskFactory               = taskFactory   ?? Task.Factory     ;
            m_maxFailureCount           = maxFailureCount                   ;
            m_cancellationTokenSource   = new CancellationTokenSource ()    ;
            m_cancellationToken         = m_cancellationTokenSource.Token   ;
            m_lock                      = m_observers                       ;
        }


        public IDisposable Subscribe (IObserver<T> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException ("observer");
            }
           
            var subscriber = new Subscriber (this);

            lock (m_lock)
            {
                if (IsDisposed)
                {
                    throw new ObjectDisposedException ("Producer", "Can't add new subscriber to disposed producer");
                }

                m_observers.Add (subscriber, observer);
            }

            return subscriber;
        }

        void Unsubscribe (Subscriber subscriber)
        {
            lock (m_lock)
            {
                m_observers.Remove (subscriber);
            }
        }

        protected override void OnDispose()
        {
            lock (m_lock)
            {
                try
                {
                    m_cancellationTokenSource.Cancel ();
                }
                catch (Exception exc)
                {
                    Log.Exception ("Producer.OnDispose: Cancelling cancellation token source threw exception: {0}", exc);
                }

                if (m_task != null)
                {
                    m_task.DisposeNoThrow ();
                }
            }

            TerminateObservers();
        }

        public void Start()
        {
            if (m_task != null)
            {
                return;
            }

            lock (m_lock)
            {
                if (m_task != null)
                {
                    return;
                }

                if (IsDisposed)
                {
                    throw new ObjectDisposedException ("Producer", "Can't start a disposed producer");
                }

                m_task = m_taskFactory.StartNew (OnProduce, m_cancellationToken, TaskCreationOptions.LongRunning);
            }
        }

        IObserver<T>[] CurrentObservers
        {
            get
            {
                lock (m_lock)
                {
                    return CurrentObservers_NoLock;
                }
            }
        }

        IObserver<T>[] CurrentObservers_NoLock
        {
            get { return m_observers.Select (kv => kv.Value).ToArray (); }
        }

        void OnProduce(object obj)
        {
            try
            {
                var productionError = 0;

                while (!m_cancellationToken.IsCancellationRequested && productionError <= m_maxFailureCount)
                {
                    try
                    {
                        ProducedValue value;
                        while (!m_cancellationToken.IsCancellationRequested && (value = ProduceValue (m_cancellationToken)) != null)
                        {
                            var observers = CurrentObservers;
                            for (int index = 0; !m_cancellationToken.IsCancellationRequested && index < observers.Length; index++)
                            {
                                var observer = observers[index];
                                try
                                {
                                    observer.OnNext(value.Value);
                                }
                                catch (Exception exc)
                                {
                                    Log.Exception("Producer.OnProduce: Caught exception from .OnNext: {0}", exc);
                                }
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        ++productionError;

                        var observers = CurrentObservers;
                        for (int index = 0; !m_cancellationToken.IsCancellationRequested && index < observers.Length; index++)
                        {
                            var observer = observers[index];
                            try
                            {
                                observer.OnError(exc);
                            }
                            catch (Exception innerExc)
                            {
                                Log.Exception("Producer.OnProduce: Caught exception from .OnError: {0}", innerExc);
                            }
                        }
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

        void TerminateObservers()
        {
            IObserver<T>[] observers;

            lock (m_lock)
            {
                observers = CurrentObservers_NoLock;
                m_observers.Clear ();
            }

            foreach (var observer in observers)
            {
                try
                {
                    observer.OnCompleted();
                }
                catch (Exception exc)
                {
                    Log.Exception("Producer.TerminateObservers: Caught exception from .OnCompleted: {0}", exc);
                }
            }
        }
    }

    sealed partial class EnumerableProducer<T> : BaseProducer<T>
    {
        readonly IEnumerator<T> m_enumerator;

        public EnumerableProducer(TaskFactory taskFactory, IEnumerable<T> enumerable, int maxFailureCount = 10) 
            :   base(taskFactory, maxFailureCount)
        {
            enumerable  = enumerable ?? Array<T>.Empty  ;
            m_enumerator= enumerable.GetEnumerator ()   ;
        }

        protected override ProducedValue ProduceValue (CancellationToken cancellationToken)
        {
            return !cancellationToken.IsCancellationRequested && m_enumerator.MoveNext()
                ?   new ProducedValue(m_enumerator.Current)
                :   null
                ;
        }

        protected override void OnDispose ()
        {
            base.OnDispose();

            m_enumerator.DisposeNoThrow ();
        }
    }

    sealed partial class EmptyObservable<T> : IObservable<T>
    {
        public readonly static EmptyObservable<T> Value = new EmptyObservable<T> (); 

        public IDisposable Subscribe (IObserver<T> observer)
        {
            return new ObservableExtensions.EmptyDisposable ();
        }
    }

    sealed partial class SingleObserver<T> : IObservable<T>
    {
        readonly T m_value;

        public SingleObserver (T value)
        {
            m_value = value;
        }

        public IDisposable Subscribe (IObserver<T> observer)
        {
            observer.OnNext (m_value);
            observer.OnCompleted ();
            return new ObservableExtensions.EmptyDisposable ();
        }
    }

    static partial class ObservableExtensions
    {
        public sealed partial class EmptyDisposable : IDisposable
        {
            public void Dispose ()
            {
            }
        }

        public static IObservable<T> Empty<T> ()
        {
            return EmptyObservable<T>.Value;
        }

        public static IObservable<T> Single<T> (T value)
        {
            return new SingleObserver<T> (value);
        }
    }

    partial class WhereObserver<T>
    {
        partial void Partial_OnNext (T value)
        {
            if (m_state (value))
            {
                m_observer.OnNext (value);
            }
        }
    }

    partial class SelectObserver<T, TTo>
    {
        partial void Partial_OnNext (T value)
        {
            m_observer.OnNext (m_state (value));
        }
    }

    partial class TakeObserver<T>
    {
        partial void Partial_OnNext (T value)
        {
            if (m_state > 0)
            {
                --m_state;
                m_observer.OnNext (value);
            }
        }
    }

    partial class SkipObserver<T>
    {
        partial void Partial_OnNext (T value)
        {
            if (m_state > 0)
            {
                --m_state;
            }
            else
            {
                m_observer.OnNext (value);
            }
        }
    }
}