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

                        var count = 0;
                        using (var reader = cmd.ExecuteReader ())
                        {
                            while (reader.Read())
                            {
                                ++count;
                            
                                var fullName = reader.Get("schema", "") + "." + reader.Get("name", "");
                            
                                var typeDefinition = schema.FindTypeDefinition (fullName);

                                if (TestFor.Equality(true, typeDefinition != null, "{0} must exist".FormatWith(fullName)))
                                {
                                    TestFor.Equality(reader.Get("schema"        , "")       , typeDefinition.Schema         , "Schema must match"       );
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

                        TestFor.Equality (count, schema.TypeDefinitions.Count (), "34 schema types expected");
                    }


                    var tblObjects = schema.FindSchemaObject("dbo.tblObjects");

                }
                finally
                {
                    ExecuteScript(sqlConnection, TearDownText);                    
                }


            }
        }

        static void ExecuteScript(SqlConnection sqlConnection, string commantText)
        {
            using (var cmd = sqlConnection.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;

                var splitCommandTexts = commantText
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