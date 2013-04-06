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

using System.Data.SqlClient;
using FileInclude.Source.SQL;

namespace Test_Functionality.SQL
{
    sealed partial class TestsFor_Schema
    {
        public void Test_Basic()
        {
            using (var sqlConnection = new SqlConnection (@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TestData;Integrated Security=True"))
            {
                sqlConnection.Open ();

                var schema = new Schema (sqlConnection);
            }
        }
   }

}