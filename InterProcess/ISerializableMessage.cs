namespace Source.InterProcess
{
    using Source.DataStreams;

    partial interface ISerializableMessageFactory<T>
        where T : ISerializableMessage
    {
        int     FactoryId       { get; }
        
        void    Serialize       (Serializer serializer, T message); 
        bool    TryUnserialize  (Unserializer unserializer, out int consumedBytes, out T message);
    }

    partial interface ISerializableMessage
    {
        int FactoryId       { get; }
        int MessageId       { get; }
    }
}