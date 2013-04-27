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


// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart

using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using FileInclude.Source.Extensions;
using FileInclude.Source.SQL;
using FileInclude.Source.Testing;

namespace Test_Functionality.SQL
{
    sealed partial class TestsFor_Schema
    {
        const string SetupText = @"
IF EXISTS (SELECT TOP 1 1 FROM SYS.objects o WHERE o.name = 'tblObjects')
	DROP TABLE tblObjects
GO

SELECT
	TOP 0 
	*
	INTO tblObjects
	FROM SYS.objects WITH(NOLOCK)
GO

IF EXISTS (SELECT TOP 1 1 FROM SYS.objects o WHERE o.name = 'viewColumns')
	DROP VIEW viewColumns
GO

CREATE VIEW viewColumns AS
	SELECT 
		*
		FROM SYS.columns
GO

IF EXISTS (SELECT TOP 1 1 FROM SYS.objects o WHERE o.name = 'P_myProc')
	DROP PROCEDURE P_myProc 
GO

CREATE PROCEDURE P_myProc 
(
	@strName	nvarchar (128)	,
	@dtCreated	datetime		OUTPUT
)
AS
	RETURN 0

GO

IF EXISTS (SELECT TOP 1 1 FROM SYS.objects o WHERE o.name = 'F_myFunc')
	DROP FUNCTION F_myFunc 
GO

CREATE FUNCTION F_myFunc 
(
)
RETURNS bigint
AS
BEGIN
	RETURN 0
END

GO
";

        const string TearDownText = @"
IF EXISTS (SELECT TOP 1 1 FROM SYS.objects o WHERE o.name = 'tblObjects')
	DROP TABLE tblObjects
GO

IF EXISTS (SELECT TOP 1 1 FROM SYS.objects o WHERE o.name = 'viewColumns')
	DROP VIEW viewColumns
GO

IF EXISTS (SELECT TOP 1 1 FROM SYS.objects o WHERE o.name = 'P_myProc')
	DROP PROCEDURE P_myProc 
GO

IF EXISTS (SELECT TOP 1 1 FROM SYS.objects o WHERE o.name = 'F_myFunc')
	DROP FUNCTION F_myFunc 
GO
";

        const string GetTypesText = @"
SELECT
	s.name			[schema]	,
	t.name			,
	system_type_id	,
	user_type_id	,
	max_length		,
	[precision]		,
	scale			,
	is_nullable
	FROM SYS.types t WITH(NOLOCK)
	INNER JOIN SYS.schemas s WITH(NOLOCK) ON t.schema_id = s.schema_id 
";

        const string GetObjectsText = @"
SELECT
	o.object_id							,
	s.name								[schema],
	o.name								,
	o.[type]							,
	o.create_date						,
	o.modify_date						
	FROM SYS.schemas s WITH(NOLOCK)
	INNER JOIN SYS.objects o WITH(NOLOCK) ON o.schema_id = s.schema_id
	WHERE
		o.is_ms_shipped = 0
		AND
		o.type IN ('P', 'TF', 'IF', 'F', 'U', 'V')
";

        const string GetColumnsText = @"
SELECT 
	c.object_id							,
	so.name								object_schema	,
	o.name								object_name		,
	s.name								type_schema		,
	t.name								type_name		,
	ISNULL (c.name		, '')			column_name		,
	c.column_id							,
	c.max_length						,
	c.[precision]						,
	c.scale								,
	ISNULL (c.collation_name	, '')	collation_name	,
	ISNULL (c.is_nullable		, 0)	is_nullable		,
	c.is_identity						,
	c.is_computed						
	FROM SYS.objects o WITH(NOLOCK)
	INNER JOIN SYS.schemas so WITH(NOLOCK) ON o.schema_id = so.schema_id
	INNER JOIN SYS.columns c WITH(NOLOCK) ON o.object_id = c.object_id
	INNER JOIN SYS.types t WITH(NOLOCK) ON c.user_type_id = t.user_type_id AND c.system_type_id = t.system_type_id
	INNER JOIN SYS.schemas s WITH(NOLOCK) ON t.schema_id = s.schema_id
	WHERE
		o.is_ms_shipped = 0
";

        public void Test_Basic()
        {
            using (var sqlConnection = new SqlConnection (@"Data Source=.\SQLEXPRESS;Initial Catalog=tempdb;Integrated Security=True"))
            {
                sqlConnection.Open ();

                try 
                {
                    ExecuteScript(sqlConnection, SetupText);

                    var schema = new Schema (sqlConnection);

                    using (var cmd = sqlConnection.CreateCommand ())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = GetTypesText;

                        var typeCount = 0;
                        using (var reader = cmd.ExecuteReader ())
                        {
                            while (reader.Read())
                            {
                                ++typeCount;
                            
                                var fullName = reader.Get("schema", "") + "." + reader.Get("name", "");
                            
                                var typeDefinition = schema.FindTypeDefinition (fullName);

                                if (TestFor.Equality(true, typeDefinition != null, "{0} must exist".FormatWith(fullName)))
                                {
                                    TestFor.Equality(reader.Get("name"          , "")       , typeDefinition.Name           , "Name must match"         );
                                    TestFor.Equality(reader.Get("system_type_id", (byte)0)  , typeDefinition.SystemTypeId   , "SystemTypeId must match" );
                                    TestFor.Equality(reader.Get("user_type_id"  , 0)        , typeDefinition.UserTypeId     , "UserTypeId must match"   );
                                    TestFor.Equality(reader.Get("max_length"    , 0)        , typeDefinition.MaxLength      , "MaxLength must match"    );
                                    TestFor.Equality(reader.Get("precision"     , 0)        , typeDefinition.Precision      , "Precision must match"    );
                                    TestFor.Equality(reader.Get("scale"         , 0)        , typeDefinition.Scale          , "Scale must match"        );
                                    TestFor.Equality(reader.Get("is_nullable"   , false)    , typeDefinition.IsNullable     , "IsNullable must match"   );
                                
                                }

                            }
                        }

                        TestFor.Equality (typeCount, schema.TypeDefinitions.Count (), "Schema type count must match");
                    }

                    using (var cmd = sqlConnection.CreateCommand ())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = GetObjectsText;

                        var objectCount = 0;
                        using (var reader = cmd.ExecuteReader ())
                        {
                            while (reader.Read())
                            {
                                ++objectCount;
                                var fullName = reader.Get("schema", "") + "." + reader.Get("name", "");

                                var schemaObject = schema.FindSchemaObject (fullName);

                                if (TestFor.Equality(true, schemaObject != null, "{0} must exist".FormatWith(fullName)))
                                {
                                    TestFor.Equality(reader.Get("object_id"     , 0)                , schemaObject.Id                   , "Id must match"           );
                                    TestFor.Equality(reader.Get("schema"        , "")               , schemaObject.Schema               , "Schema must match"       );
                                    TestFor.Equality(reader.Get("name"          , "")               , schemaObject.Name                 , "Name must match"         );
                                    TestFor.Equality(reader.Get("type"          , "").Trim ()       , TypeToString (schemaObject.Type)  , "Type must match"         );
                                    TestFor.Equality(reader.Get("create_date"   , DateTime.MinValue), schemaObject.CreateDate           , "CreateDate must match"   );
                                    TestFor.Equality(reader.Get("modify_date"   , DateTime.MinValue), schemaObject.ModifyDate           , "ModifyDate must match"   );
                                
                                }
                            }
                        }
                        TestFor.Equality (objectCount, schema.SchemaObjects.Count (), "Object count must match");
                    }


                    using (var cmd = sqlConnection.CreateCommand ())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = GetColumnsText;

                        var columnCount = 0;
                        using (var reader = cmd.ExecuteReader ())
                        {
                            while (reader.Read())
                            {
                                ++columnCount;
                                var fullName = reader.Get("object_schema", "") + "." + reader.Get("object_name", "");
                                var ordinal = reader.Get("column_id", 0) - 1;

                                var schemaObject = schema.FindSchemaObject (fullName);
                                
                                if (
                                        TestFor.Equality(true, schemaObject != null, "{0} must exist".FormatWith(fullName))
                                    &&  TestFor.Equality(true, ordinal < schemaObject.Columns.Length, ""))
                                {
                                    var columnSubObject = schemaObject.Columns[ordinal];

                                    TestFor.Equality(ordinal                                , columnSubObject.Ordinal           , "Ordinal must match"      );
                                    TestFor.Equality(reader.Get("column_name"   , "")       , columnSubObject.Name              , "Name must match"         );
                                    TestFor.Equality(reader.Get("type_schema"   , "")       , columnSubObject.Type.Schema       , "Type.Schema must match"  );
                                    TestFor.Equality(reader.Get("type_name"     , "")       , columnSubObject.Type.Name         , "Type.Name must match"    );
                                    TestFor.Equality(reader.Get("max_length"    , (short)0) , columnSubObject.MaxLength         , "MaxLength must match"    );
                                    TestFor.Equality(reader.Get("precision"     , (short)0) , columnSubObject.Precision         , "Precision must match"    );
                                    TestFor.Equality(reader.Get("scale"         , (short)0) , columnSubObject.Scale             , "Scale must match"        );
                                    TestFor.Equality(reader.Get("collation_name", ""      ) , columnSubObject.Collation         , "Collation must match"    );
                                    TestFor.Equality(reader.Get("is_nullable"   , false)    , columnSubObject.IsNullable        , "IsNullable must match"   );
                                    TestFor.Equality(reader.Get("is_identity"   , false)    , columnSubObject.IsIdentity        , "IsIdentity must match"   );
                                    TestFor.Equality(reader.Get("is_computed"   , false)    , columnSubObject.IsComputed        , "IsComputed must match"   );
                                }
                            }
                        }
                        TestFor.Equality (columnCount, schema.SchemaObjects.SelectMany (o => o.Columns).Count (), "Column count must match");
                    }

                }
                finally
                {
                    ExecuteScript(sqlConnection, TearDownText);                    
                }


            }
        }

        static string TypeToString (SchemaObject.SchemaObjectType type)
        {
            switch (type)
            {
                case SchemaObject.SchemaObjectType.Unknown:
                    return "";
                case SchemaObject.SchemaObjectType.StoredProcedure:
                    return "P";
                case SchemaObject.SchemaObjectType.Function:
                    return "F";
                case SchemaObject.SchemaObjectType.TableFunction:
                    return "TF";
                case SchemaObject.SchemaObjectType.InlineTableFunction:
                    return "IF";
                case SchemaObject.SchemaObjectType.Table:
                    return "U";
                case SchemaObject.SchemaObjectType.View:
                    return "V";
                default:
                    return "";
            }
        }

        static void ExecuteScript(SqlConnection sqlConnection, string commandText)
        {
            using (var cmd = sqlConnection.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;

                var splitCommandTexts = commandText
                    .Split(new[] {"\r\nGO"}, StringSplitOptions.None)
                    .Select(x => x.Trim())
                    .Where(x => !x.IsNullOrWhiteSpace())
                    .ToArray();

                foreach (var splitCommandText in splitCommandTexts)
                {
                    cmd.CommandText = splitCommandText;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}