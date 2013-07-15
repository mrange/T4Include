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

// ### INCLUDE: Generated_ObservableExtensions.cs

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Source.Extensions
{
    using System;

    partial interface IProducer<T> : IObservable<T>, IDisposable
    {
        void Start ();
        void Stop ();
    }

    sealed partial class TaskProducer<T> : IProducer<T>
    {
        readonly TaskFactory m_taskFactory;
        readonly IEnumerable<T> m_values;
        readonly IEnumerator<T> m_enumerator;
        readonly int m_maxFailureCount;

        CancellationTokenSource m_cancellationTokenSource;
        CancellationToken m_cancellationToken;
        object m_task;

        public TaskProducer (TaskFactory taskFactory, IEnumerable<T> values, int maxFailureCount = 10)
        {
            m_taskFactory = taskFactory;
            m_values = values;
            m_enumerator = m_values.GetEnumerator ();
            m_maxFailureCount = maxFailureCount;
        }


        public IDisposable Subscribe(IObserver<T> observer)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            m_enumerator.Dispose ();
        }

        public void Start()
        {
            if (m_task != null)
            {
                return;
            }

            lock (m_taskFactory)
            {
                if (m_task != null)
                {
                    return;
                }

                m_cancellationTokenSource = new CancellationTokenSource ();
                m_cancellationToken = m_cancellationTokenSource.Token;

                m_task = m_taskFactory.StartNew (OnProduce, m_cancellationToken, TaskCreationOptions.LongRunning);
            }

            throw new NotImplementedException();
        }

        void OnProduce(object obj)
        {
            try
            {
            while (m_enumerator.MoveNext ())
            {
                    m_enumerator.Current    
                    
            }
            }
            catch (Exception exc)
            {
                    
            }
            
        }

        public void Stop()
        {
            throw new NotImplementedException();
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