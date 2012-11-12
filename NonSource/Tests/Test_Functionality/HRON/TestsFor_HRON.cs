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
// ReSharper disable UnusedMember.Local
// ReSharper disable PartialTypeWithSinglePart

#pragma warning disable 0649

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
        static readonly string s_test2_hron = File.ReadAllText(@"HRON\Test2.hron");

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
            var lines = s_test2_hron.ReadLines().ToArray();
            Config config;
            HRONObjectParseError[] errors;
            var result = HRONSerializer.TryParseObject(int.MaxValue, lines, out config, out errors);
            if (TestFor.Equality(true, result, "HRON should be parsed successfully"))
            {
                var value = HRONSerializer.ObjectAsString(config);

                TestFor.Equality(
                    s_test2_hron,
                    value,
                    "HRON after deserialize/serialize to object should be identical to test case",
                    suppressValue: true
                    );
            }
        }

        public void Test_TryParseDynamic()
        {
            var lines = s_test2_hron.ReadLines().ToArray();
            HRONObject hronObject;
            HRONDynamicParseError[] errors;
            var result = HRONSerializer.TryParseDynamic(int.MaxValue, lines, out hronObject, out errors);
            if (TestFor.Equality(true, result, "HRON should be parsed successfully"))
            {
                var connections = hronObject["DataBaseConnection"].ToArray();
                if (TestFor.Equality(2, connections.Length, "Expects two database connections"))
                {
                    {
                        var connection = connections[0];

                        TestFor.Equality("CustomerDB", connection["Name"].First().Value, "Expects CustomerDB name");
                        TestFor.Equality(@"Data Source=.\SQLEXPRESS;Initial Catalog=Customers", connection["ConnectionString"].First().Value, "Expects CustomerDB connection");
                        TestFor.Equality(@"10", connection["TimeOut"].First().Value, "Expects CustomerDB connection");
                    }
                    {
                        var connection = connections[1];

                        TestFor.Equality("PartnerDB", connection["Name"].First().Value, "Expects PartnerDB name");
                        TestFor.Equality(@"Data Source=.\SQLEXPRESS;Initial Catalog=Partners", connection["ConnectionString"].First().Value, "Expects CustomerDB connection");
                        TestFor.Equality(null, connection["TimeOut"].FirstOrDefault(), "Expects CustomerDB connection");
                    }
                }
                var value = HRONSerializer.DynamicAsString(hronObject);

                TestFor.Equality(
                    s_test2_hron,
                    value,
                    "HRON after deserialize/serialize to object should be identical to test case",
                    suppressValue: true
                    );
            }
        }

        public void Test_ObjectAsString()
        {

            var dic = new Dictionary<string, object>
            {
                {"A", "AA"},
                {"B", "BB"},
                {"C", 
                    new Dictionary<string, object>
                        {
                        {"AAA", "AAAA"},
                        {"BBB", "BBBB"},
                    }},                
            };

            var value = HRONSerializer.ObjectAsString(dic);

            const string testCase = @"=A
	AA
=B
	BB
@C
	=AAA
		AAAA
	=BBB
		BBBB
";

            TestFor.Equality (testCase, value, "Serialized dictionary should have the expected value", suppressValue:true);

        }

    }

}