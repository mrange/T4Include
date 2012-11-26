// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################







namespace Source.InterProcess.Test
{
    using System;
    using System.IO;

    using Source.DataStreams;

    enum MessageIds
    {
        Customer = 1001,
        Partner = 1002,
    }

    partial interface IMessageFactory : ISerializableMessageFactory<IMessage>
    {
    }

    sealed partial class MessageFactory : IMessageFactory
    {
        SerializeVisitor m_serializer = new SerializeVisitor ();
        UnserializeVisitor m_unserializer = new UnserializeVisitor ();

        public int FactoryId { get {return 19740531;}}



        public void Serialize(Serializer writer, IMessage message)
        {
            if (writer == null)
            {
                return;
            }

            if (message == null)
            {
                return;
            }

            var commit = false;            
            var pos = writer.BaseStream.Position;
            try
            {
                writer.Serialize(0);   // PlaceHolder for the length    
                writer.Serialize(message.FactoryId);   
                writer.Serialize(message.MessageId);   

                m_serializer.Writer = writer;
                message.Apply (m_serializer);    

                var newPos = writer.BaseStream.Position;
                writer.BaseStream.Position = pos;
                writer.Serialize(newPos - pos);
                writer.BaseStream.Position = newPos;
                commit = true;
            }
            finally
            {
                if (!commit)
                {
                    writer.BaseStream.Position = pos;
                }
            }
        }

        public bool TryUnserialize(Unserializer reader, out int consumedBytes, out IMessage message)
        {
            consumedBytes = 0;
            message = null;

            if (reader == null)
            {
                return false;
            }

            if (reader.BaseStream.Remaining < sizeof(int)*3)
            {
                return false;
            }

            var pos = reader.BaseStream.Position;
            var commit = false;
            try
            {
                var length = reader.Unserialize(0);
                if (reader.BaseStream.Remaining < length - sizeof(Int32))
                {
                    return false;
                }

                var factoryId = reader.Unserialize(0);
                var messageId = reader.Unserialize(0);
                if (factoryId != 19740531)
                {
                    return false;
                }

                m_unserializer.Reader = reader;

                switch ((MessageIds)messageId)
                {
                case MessageIds.Customer:
                    message = new Customer();
                    break;
                case MessageIds.Partner:
                    message = new Partner();
                    break;
                default: 
                    return false;
                }

                message.Apply(m_unserializer);
                consumedBytes = (int) (reader.BaseStream.Position - pos);
                commit = true;
                return true;
            }
            finally
            {
                if (!commit)
                {
                    reader.BaseStream.Position = pos;
                }
            }
        }
    }

    partial interface IMessage : ISerializableMessage 
    {
        void Apply (IVisitor visitor);
    }
    
    partial interface IVisitor
    {
        void Visit (Customer message);
        void Visit (Partner message);
    }

    sealed partial class SerializeVisitor : IVisitor
    {
        public Serializer Writer;
        public void Visit (Customer message)
        {
            Writer.Serialize(message.Id);
            Writer.Serialize(message.FirstName);
            Writer.Serialize(message.LastName);
            Writer.Serialize(message.BirthYear);
        }
        public void Visit (Partner message)
        {
            Writer.Serialize(message.Id);
            Writer.Serialize(message.FirstName);
            Writer.Serialize(message.LastName);
            Writer.Serialize(message.BirthYear);
            Writer.Serialize(message.OwnCustomers);
            Writer.Serialize(message.OrgCustomers);
        }
    }

    sealed partial class UnserializeVisitor : IVisitor
    {
        public Unserializer Reader;
        public IMessage Message;
        public void Visit (Customer message)
        {
            message.Id = Reader.Unserialize(default (Int64));
            message.FirstName = Reader.Unserialize(default (String));
            message.LastName = Reader.Unserialize(default (String));
            message.BirthYear = Reader.Unserialize(default (Int32));
        }
        public void Visit (Partner message)
        {
            message.Id = Reader.Unserialize(default (Int64));
            message.FirstName = Reader.Unserialize(default (String));
            message.LastName = Reader.Unserialize(default (String));
            message.BirthYear = Reader.Unserialize(default (Int32));
            message.OwnCustomers = Reader.Unserialize(default (Int32));
            message.OrgCustomers = Reader.Unserialize(default (Int32));
        }
    }

    sealed partial class Customer : IMessage
    {
        public int FactoryId { get {return 19740531;}}

        public int MessageId { get {return 1001;}}

        public void Apply(IVisitor visitor)
        {
            visitor.Visit (this);
        }

        public Int64 Id; 
        public String FirstName; 
        public String LastName; 
        public Int32 BirthYear; 
    }
    sealed partial class Partner : IMessage
    {
        public int FactoryId { get {return 19740531;}}

        public int MessageId { get {return 1002;}}

        public void Apply(IVisitor visitor)
        {
            visitor.Visit (this);
        }

        public Int64 Id; 
        public String FirstName; 
        public String LastName; 
        public Int32 BirthYear; 
        public Int32 OwnCustomers; 
        public Int32 OrgCustomers; 
    }
}
