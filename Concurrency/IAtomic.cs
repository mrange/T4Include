namespace Source.Concurrency
{
    partial interface IAtomic<T>
    {
        bool CompareExchange (T newValue, T comparand);
        T Value { get; }
    }
}
