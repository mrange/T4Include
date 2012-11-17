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
using FileInclude.Source.Common;
using FileInclude.Source.Extensions;

namespace Test_Functionality.Common
{
    sealed partial class TestsFor_SubString
    {
        public void Test_ReadLines ()
        {
            const string testCase = "A\r\nB\rC\nD\n\rE\n\nF\r\rG\r\r\nH\n\r\nI\r\n\rJ\n\n\rK\r\n";

            using (var stringReader = new StringReader(testCase))
            {
                var expected = stringReader.ReadLines().ToArray();
                var found = testCase.ReadLines().Select(ss => ss.ToString()).ToArray();

                TestFor.Equality(expected.Length + 1, found.Length, "ReadLines in the presence of ending linebreak should read one line extra compared to StringReader");
                TestFor.SequenceEquality(expected, found.Take(expected.Length), "ReadLines should otherwise match StringReader behavior");
            }
        }
    }
}
