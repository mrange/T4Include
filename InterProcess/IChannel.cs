using System;
using System.Runtime.InteropServices;

namespace Source.InterProcess
{
    interface IChannel<T> :IObservable<T>
    {
        void Push(T value);
    }
}