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

namespace Source.Observable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Source.Common;
    using Source.Extensions;

    abstract partial class BaseObservable<T> : BaseDisposable, IObservable<T>
    {
        sealed partial class Subscriber : BaseDisposable
        {
            readonly BaseObservable<T> m_observable;

            public Subscriber (BaseObservable<T> observable)
            {
                m_observable = observable;
            }

            protected override void OnDispose()
            {
                m_observable.Unsubscribe (this);
            }
        }

        protected readonly object               Lock = new object ()        ;
        protected readonly CancellationToken    CancellationToken           ;

        readonly CancellationTokenSource        m_cancellationTokenSource   ;

        readonly Dictionary<IDisposable, IObserver<T>>                      m_observers = new Dictionary<IDisposable, IObserver<T>> ();

        protected BaseObservable ()
        {
            Lock                      = m_observers                       ;
            m_cancellationTokenSource = new CancellationTokenSource ()    ;
            CancellationToken         = m_cancellationTokenSource.Token   ;
        }


        public IDisposable Subscribe (IObserver<T> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException ("observer");
            }
           
            var subscriber = new Subscriber (this);

            lock (Lock)
            {
                if (IsDisposed)
                {
                    throw new ObjectDisposedException ("BaseObservable", "Can't add new subscriber to disposed observable");
                }

                m_observers.Add (subscriber, observer);
            }

            return subscriber;
        }

        void Unsubscribe (Subscriber subscriber)
        {
            lock (Lock)
            {
                m_observers.Remove (subscriber);
            }
        }

        protected override void OnDispose()
        {
            try
            {
                m_cancellationTokenSource.Cancel ();
            }
            catch (Exception exc)
            {
                Log.Exception ("BaseObservable.OnDispose: Cancelling cancellation token source threw exception: {0}", exc);
            }
            m_cancellationTokenSource.DisposeNoThrow ();

            TerminateObservers();
        }

        protected IObserver<T>[] CurrentObservers
        {
            get
            {
                lock (Lock)
                {
                    return CurrentObservers_NoLock;
                }
            }
        }

        protected IObserver<T>[] CurrentObservers_NoLock
        {
            get { return m_observers.Select (kv => kv.Value).ToArray (); }
        }

        protected void SendValue (T value)
        {
            var observers = CurrentObservers;
            for (var index = 0; !CancellationToken.IsCancellationRequested && index < observers.Length; index++)
            {
                var observer = observers[index];
                try
                {
                    observer.OnNext(value);
                }
                catch (Exception exc)
                {
                    Log.Exception("BaseObservable.SendValue: Caught exception from .OnNext: {0}", exc);
                }
            }
        }

        protected void SendException (Exception exc)
        {
            var observers = CurrentObservers;
            for (var index = 0; !CancellationToken.IsCancellationRequested && index < observers.Length; index++)
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

        protected void TerminateObservers()
        {
            IObserver<T>[] observers;

            lock (Lock)
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
}