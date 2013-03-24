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

using System.IO;
using System.Linq;
using FileInclude.Source.Extensions;
using FileInclude.Source.Testing;
using FileInclude.Source.Text;

namespace Test_Functionality.Text
{
    sealed class TestsFor_LineToObjectExtensions
    {
        public const string TestCase = 
@"ID	FirstName	LastName
1	Bill	Gates
2	Steve	Jobs
3	Linus	Torvalds
";

        sealed class Customer
        {
            public string ID        ;
            public string FirstName ;
            public string LastName  ;

            [IgnoreMember]
            public string OtherField;
        }

        public void Test_Basic()
        {
            var expected = GetExpected(TestCase);
            var result = TestCase
                .TextToObjects<Customer>()
                .ToArray()
                ;

            if (TestFor.Equality(expected.Length, result.Length + 1, "Expected length and result length must match"))
            {
                for (var index = 0; index < result.Length; index++)
                {
                    var customer = result[index];
                    var line = expected[index + 1];
                    TestFor.Equality(line[0], customer.ID       , "ID must match for line: {0}".FormatWith(index));
                    TestFor.Equality(line[1], customer.FirstName, "FirstName must match for line: {0}".FormatWith(index));
                    TestFor.Equality(line[2], customer.LastName , "LastName must match for line: {0}".FormatWith(index));
                }
            }
        }

        static string[][] GetExpected(string testCase)
        {
            using (var ss = new StringReader(testCase ?? ""))
            {
                var lines = ss.ReadLines().ToArray();

                return lines.Select(l => l.Split('\t')).ToArray();
            }
        }
    }
}
