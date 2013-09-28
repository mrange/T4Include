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
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using FileInclude.Source.Common;
using FileInclude.Source.Extensions;
using FileInclude.Source.HRON;
using FileInclude.Source.Testing;

namespace Test_Functionality.HRON
{
    [TestsFor]
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
                "HRON after deserialize/serialize should be identical to test case"
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
                    "HRON after deserialize/serialize to object should be identical to test case"
                    );
            }
        }

        enum MyFlag
        {
            MyDefaultValue  ,
            MyFlagValue     ,
        }

        public void Test_TryParseDynamic()
        {
            var lines = s_test2_hron.ReadLines().ToArray();
            dynamic dyn;
            HRONDynamicParseError[] errors;
            var result = HRONSerializer.TryParseDynamic(int.MaxValue, lines, out dyn, out errors);
            if (TestFor.Equality(true, result, "HRON should be parsed successfully"))
            {
                MyFlag myFlag = dyn.Common.MyFlag;
                MyFlag myMissingFlag = dyn.Common.MyMissingFlag;
                TestFor.Equality((int)MyFlag.MyFlagValue, (int)myFlag, "Expects MyFlagValue");
                TestFor.Equality((int)MyFlag.MyDefaultValue, (int)myMissingFlag, "Expects the default MyFlag");

                dynamic connections = dyn.DataBaseConnection;
                if (TestFor.Equality(2, connections.GetCount(), "Expects two database connections"))
                {
                    {
                        var connection = connections[0];

                        string name             = connection.Name;
                        string connectionString = connection.ConnectionString;
                        string timeOut          = connection.TimeOut;
                        int    parsedTimeOut    = connection.TimeOut;
                        int?   optParsedTimeOut = connection.TimeOut;
                        int[]  arrParsedTimeOut = connection.TimeOut;
                        TestFor.Equality(
                            "CustomerDB", 
                            name, 
                            "Expects CustomerDB name"
                            );
                        TestFor.Equality(
                            @"Data Source=.\SQLEXPRESS;Initial Catalog=Customers",
                            connectionString, 
                            "Expects CustomerDB connection"
                            );
                        TestFor.Equality(
                            @"10",
                            timeOut, 
                            "Expects CustomerDB timeout"
                            );
                        TestFor.Equality(
                            10,
                            parsedTimeOut,
                            "Expects parsed CustomerDB timeout"
                            );
                        if (TestFor.Equality(
                            true,
                            optParsedTimeOut.HasValue,
                            "Expects parsed CustomerDB timeout"
                            ))
                        {
                            TestFor.Equality(
                                10,
                                optParsedTimeOut.Value,
                                "Expects parsed CustomerDB timeout"
                                );                            
                        }
                        if (TestFor.Equality(
                            1,
                            arrParsedTimeOut.Length,
                            "Expects parsed CustomerDB timeout"
                            ))
                        {
                            TestFor.Equality(
                                10,
                                arrParsedTimeOut[0],
                                "Expects parsed CustomerDB timeout"
                                );                                                        
                        }
                    }
                    {
                        var connection = connections[1];

                        string name             = connection.Name;
                        string connectionString = connection.ConnectionString;
                        string timeOut          = connection.TimeOut;
                        int    parsedTimeOut    = connection.TimeOut;
                        int?   optParsedTimeOut = connection.TimeOut;
                        int[]  arrParsedTimeOut = connection.TimeOut;

                        TestFor.Equality(
                            "PartnerDB",
                            name, 
                            "Expects PartnerDB name"
                            );
                        TestFor.Equality(
                            @"Data Source=.\SQLEXPRESS;Initial Catalog=Partners",
                            connectionString, 
                            "Expects PartnerDB connection"
                            );
                        TestFor.Equality(
                            "",
                            timeOut, 
                            "Expects no PartnerDB timeout"
                            );
                        TestFor.Equality(
                            0,
                            parsedTimeOut,
                            "Expects no parsed CustomerDB timeout"
                            );
                        TestFor.Equality(
                            false,
                            optParsedTimeOut.HasValue,
                            "Expects no parsed CustomerDB timeout"
                            );
                        TestFor.Equality(
                            0,
                            arrParsedTimeOut.Length,
                            "Expects no parsed CustomerDB timeout"
                            );
                    }
                }
                var value = HRONSerializer.DynamicAsString(dyn);

                TestFor.Equality(
                    s_test2_hron,
                    value,
                    "HRON after deserialize/serialize to object should be identical to test case"
                    );
            }
        }

        public void Test_NameValueCollection()
        {
            var nvc = new NameValueCollection
                          {
                              {"Key1", "Value1"}, 
                              {"Key1", "Value2"}, 
                              {"Key1", "Value3"}
                          };

            var value = HRONSerializer.ObjectAsString(nvc);

            // This test case is just to test that NameValueCollection doesn't crash the serializer
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
		BBBB";

            TestFor.Equality (testCase, value, "Serialized dictionary should have the expected value");

        }

        public void Test_Issue4 ()
        {
            var strings = new [] {"hello", "there"};
            var hron = HRONSerializer.ObjectAsString(strings);

            List<string> resultsStrings;
            HRONObjectParseError[] errors;

            var result = HRONSerializer.TryParseObject(
                100,
                hron.ReadLines(),
                out resultsStrings,
                out errors
                );

            TestFor.Equality (true, result, "TryParseObject should succeed");
            if (TestFor.Equality (strings.Length, resultsStrings.Count, "The length of expected and result sets should be the same"))
            {
                for (var iter = 0; iter < strings.Length; ++iter)
                {
                    TestFor.Equality (strings[iter], resultsStrings[iter], "The result set should have the same value as the expected set: {0}".FormatWith (iter));
                }
            }
        }

    }

}