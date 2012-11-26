using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Source.Common;

namespace Source.InterProcess
{
    abstract partial class BaseObservable<T> : BaseDisposable, IObservable<T>
    {
        int m_id;
        readonly ConcurrentDictionary<int, IObserver<T>> m_observers = new ConcurrentDictionary<int, IObserver<T>>(); 

        public IDisposable Subscribe(IObserver<T> observer)
        {
            var id = Interlocked.Increment(ref m_id);
            var isAdded = m_observers.TryAdd(id, observer);
            if (!isAdded)
            {
                throw new TodoException();
            }

            return new RemoveObserver(m_observers, id);
        }

        KeyValuePair<int, IObserver<T>>[] GetObservers()
        {
            return m_observers.ToArray();
        }

        protected override void OnDispose()
        {
            foreach (var kv in GetObservers())
            {
                var observer = kv.Value;
                if (observer != null)
                {
                    observer.OnCompleted();
                }
            }
        }

        protected void Raise(T value)
        {
            foreach (var kv in GetObservers())
            {
                var observer = kv.Value;
                if (observer != null)
                {
                    observer.OnNext(value);
                }
            }
        }

        protected void RaiseException(Exception exception)
        {
            foreach (var kv in GetObservers())
            {
                var observer = kv.Value;
                if (observer != null)
                {
                    observer.OnError(exception);
                }
            }
        }

        sealed partial class RemoveObserver : BaseDisposable
        {
            readonly ConcurrentDictionary<int, IObserver<T>> m_obs;
            readonly int m_i;

            public RemoveObserver(ConcurrentDictionary<int, IObserver<T>> observers, int id)
            {
                m_obs = observers;
                m_i = id;
            }

            protected override void OnDispose()
            {
                IObserver<T> obs;
                m_obs.TryRemove(m_i, out obs);
                if (obs != null)
                {
                    obs.OnCompleted();
                }
            }
        }

    }
}