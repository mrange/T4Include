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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileInclude.Source.Common;
using FileInclude.Source.HRON;

namespace Test_Functionality.HRON
{
    sealed partial class TestsFor_HRON
    {
        class Config
        {
            public class UserConfig
            {
                public string UserName;
                public string Password;
            }

            public class DataBaseConnectionConfig
            {
                public string Name;
                public string ConnectionString;
                public int? TimeOut;
            }

            public Dictionary<string, string> Common { get; set; }

            public List<DataBaseConnectionConfig> DataBaseConnection
            {
                get;
                set;
            }

            public UserConfig User;
        }

        static readonly string s_test_hron = File.ReadAllText(@"HRON\Test.hron");

        public void Test_Parse()
        {
            var visitor = new HRONWriterVisitor();
            var lines = s_test_hron.ReadLines().ToArray();
            HRONSerializer.Parse(
                int.MaxValue,
                lines,
                visitor
                );

            TestFor.Equality(
                s_test_hron, 
                visitor.Value,
                "HRON after deserialize/serialize should be identical to test case",
                suppressValue:true
                );

        }

        public void Test_TryParseObject()
        {
            var lines = s_test_hron.ReadLines().ToArray();
            Config config;
            HRONObjectParseError[] errors;
            var result = HRONSerializer.TryParseObject(int.MaxValue, lines, out config, out errors);
            TestFor.Equality(true, result, "HRON should be parsed successfully");

            //var value = HRONSerializer.ObjectAsString(config);

            //Log.Info(value);
        }
    }

}