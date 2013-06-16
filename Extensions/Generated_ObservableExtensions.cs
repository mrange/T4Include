// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################






namespace Source.Extensions
{
    using System;


    sealed partial class WhereObservable<T> : IObservable<T>
    {
        readonly IObservable<T> m_observable;
        readonly Func<T,bool> m_state;

        public WhereObservable (IObservable<T> observable, Func<T,bool> state)
        {
            m_observable    = observable;
            m_state         = state     ;
        }

        public IDisposable Subscribe (IObserver<T> observer)
        {
            var o = new WhereObserver<T> (observer, m_state);
            return m_observable.Subscribe (o);
        }
    }

    sealed partial class WhereObserver<T> : IObserver<T>
    {
        readonly IObserver<T> m_observer;
        Func<T,bool> m_state;

        public WhereObserver (IObserver<T> observer, Func<T,bool> state)
        {
            m_observer  = observer  ;
            m_state     = state     ;
        }

        partial void Partial_OnNext (T value);

        public void OnNext (T value)
        {
            Partial_OnNext (value);
        }

        public void OnError (Exception error)
        {
            m_observer.OnError (error);
        }

        public void OnCompleted ()
        {
            m_observer.OnCompleted ();
        }

    }

    static partial class ObservableExtensions
    {
        public static IObservable<T> Where<T> (IObservable<T> observable, Func<T,bool> p)
        {
            if (observable == null)
            {
                return EmptyObservable<T>.Value;
            }

            return new WhereObservable<T> (observable, p);
        }
    }


    sealed partial class SelectObservable<T,TTo> : IObservable<TTo>
    {
        readonly IObservable<T> m_observable;
        readonly Func<T,TTo> m_state;

        public SelectObservable (IObservable<T> observable, Func<T,TTo> state)
        {
            m_observable    = observable;
            m_state         = state     ;
        }

        public IDisposable Subscribe (IObserver<TTo> observer)
        {
            var o = new SelectObserver<T,TTo> (observer, m_state);
            return m_observable.Subscribe (o);
        }
    }

    sealed partial class SelectObserver<T,TTo> : IObserver<T>
    {
        readonly IObserver<TTo> m_observer;
        Func<T,TTo> m_state;

        public SelectObserver (IObserver<TTo> observer, Func<T,TTo> state)
        {
            m_observer  = observer  ;
            m_state     = state     ;
        }

        partial void Partial_OnNext (T value);

        public void OnNext (T value)
        {
            Partial_OnNext (value);
        }

        public void OnError (Exception error)
        {
            m_observer.OnError (error);
        }

        public void OnCompleted ()
        {
            m_observer.OnCompleted ();
        }

    }

    static partial class ObservableExtensions
    {
        public static IObservable<TTo> Select<T,TTo> (IObservable<T> observable, Func<T,TTo> p)
        {
            if (observable == null)
            {
                return EmptyObservable<TTo>.Value;
            }

            return new SelectObservable<T,TTo> (observable, p);
        }
    }


    sealed partial class TakeObservable<T> : IObservable<T>
    {
        readonly IObservable<T> m_observable;
        readonly int m_state;

        public TakeObservable (IObservable<T> observable, int state)
        {
            m_observable    = observable;
            m_state         = state     ;
        }

        public IDisposable Subscribe (IObserver<T> observer)
        {
            var o = new TakeObserver<T> (observer, m_state);
            return m_observable.Subscribe (o);
        }
    }

    sealed partial class TakeObserver<T> : IObserver<T>
    {
        readonly IObserver<T> m_observer;
        int m_state;

        public TakeObserver (IObserver<T> observer, int state)
        {
            m_observer  = observer  ;
            m_state     = state     ;
        }

        partial void Partial_OnNext (T value);

        public void OnNext (T value)
        {
            Partial_OnNext (value);
        }

        public void OnError (Exception error)
        {
            m_observer.OnError (error);
        }

        public void OnCompleted ()
        {
            m_observer.OnCompleted ();
        }

    }

    static partial class ObservableExtensions
    {
        public static IObservable<T> Take<T> (IObservable<T> observable, int p)
        {
            if (observable == null)
            {
                return EmptyObservable<T>.Value;
            }

            return new TakeObservable<T> (observable, p);
        }
    }


    sealed partial class SkipObservable<T> : IObservable<T>
    {
        readonly IObservable<T> m_observable;
        readonly int m_state;

        public SkipObservable (IObservable<T> observable, int state)
        {
            m_observable    = observable;
            m_state         = state     ;
        }

        public IDisposable Subscribe (IObserver<T> observer)
        {
            var o = new SkipObserver<T> (observer, m_state);
            return m_observable.Subscribe (o);
        }
    }

    sealed partial class SkipObserver<T> : IObserver<T>
    {
        readonly IObserver<T> m_observer;
        int m_state;

        public SkipObserver (IObserver<T> observer, int state)
        {
            m_observer  = observer  ;
            m_state     = state     ;
        }

        partial void Partial_OnNext (T value);

        public void OnNext (T value)
        {
            Partial_OnNext (value);
        }

        public void OnError (Exception error)
        {
            m_observer.OnError (error);
        }

        public void OnCompleted ()
        {
            m_observer.OnCompleted ();
        }

    }

    static partial class ObservableExtensions
    {
        public static IObservable<T> Skip<T> (IObservable<T> observable, int p)
        {
            if (observable == null)
            {
                return EmptyObservable<T>.Value;
            }

            return new SkipObservable<T> (observable, p);
        }
    }

}

