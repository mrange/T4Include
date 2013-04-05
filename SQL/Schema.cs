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

namespace Source.SQL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;


    sealed partial class TypeDefinition
    {
        public readonly string  Schema      ;
        public readonly string  Name        ;
        public readonly byte    SystemTypeId;
        public readonly byte    UserTypeId  ;
        public readonly short   MaxLength   ;
        public readonly byte    Precision   ;
        public readonly byte    Scale       ;
        public readonly string  Collation   ;
        public readonly bool    IsNullable  ;

        public TypeDefinition(
            string schema, 
            string name, 
            byte systemTypeId, 
            byte userTypeId, 
            short maxLength, 
            byte precision, 
            byte scale, 
            string collation, 
            bool isNullable
            )
        {
            Schema          = schema            ?? "";
            Name            = name              ?? "";
            SystemTypeId    = systemTypeId      ;
            UserTypeId      = userTypeId        ;
            MaxLength       = maxLength         ;
            Precision       = precision         ;
            Scale           = scale             ;
            Collation       = collation         ?? "";
            IsNullable      = isNullable        ;
        }

        public string FullName
        {
            get
            {
                return Schema + "." + Name;
            }
        }

    }

    abstract partial class BaseTypedSubObject
    {
        public readonly TypeDefinition  Type    ;
        public readonly int             Ordinal ;
        public readonly string          Name    ;
        public readonly int             Length  ;
    }

    sealed partial class ColumnSubObject : BaseTypedSubObject
    {
        public readonly bool            IsNullable  ;
        
    }

    sealed partial class ParameterSubObject : BaseTypedSubObject
    {
        
    }

    sealed partial class SchemaObject
    {
        public enum SchemaType
        {
            StoredProcedure     ,
            Function            ,
            TableFunction       ,
            InlineTableFunction ,
            Table               ,
            View                ,
        }

        public readonly SchemaType  Type    ;
        public readonly string      Schema  ;
        public readonly string      Name    ;

        protected SchemaObject(SchemaType type, string schema, string name)
        {
            Type    = type              ;
            Schema  = schema    ?? ""   ;
            Name    = name      ?? ""   ;
        }
    }

    sealed partial class Schema
    {
        readonly Dictionary<string, TypeDefinition> m_typeDefinitions = new Dictionary<string, TypeDefinition> ();

        public Schema (SqlConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"

SELECT
	s.name				[Schema]		,
	t.name				Name			,
	t.system_type_id	SystemTypeId	,
	t.user_type_id		UserTypeId		,
	t.max_length		[MaxLength]		,
	t.[precision]		[Precision]		,
	t.scale				Scale			,
	t.collation_name	Collation		,
	t.is_nullable		IsNullable
	FROM SYS.types t WITH(NOLOCK)
	INNER JOIN SYS.schemas s WITH(NOLOCK) ON t.schema_id = s.schema_id


";
                using (var reader = command.ExecuteReader ())
                {
                    while (reader.Read ())
                    {
                        var type = new TypeDefinition (
                            reader.GetString(0) , 
                            reader.GetString(1) , 
                            reader.GetByte(2)   , 
                            reader.GetByte(3)   , 
                            reader.GetInt16(4)  , 
                            reader.GetByte(5)   , 
                            reader.GetByte(6)   , 
                            reader.GetString(7) , 
                            reader.GetBoolean(8) 
                            );
                        m_typeDefinitions[type.FullName] = type;
                        
                    }
                }
                
            }
        }

        public IEnumerable<TypeDefinition> TypeDefinitions
        {
            get
            {
                return m_typeDefinitions.Values;
            }
        }

        public TypeDefinition FindTypeDefinition (string fullName)
        {
            TypeDefinition typeDefinition;
            m_typeDefinitions.TryGetValue (fullName ?? "", out typeDefinition);
            return typeDefinition;
        }
    }
}
