// ReSharper disable InconsistentNaming

using System;
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
            const string testCase = "A\r\nB\rC\nD\n\rE\n\nF\r\rG\r\r\nH\n\r\nI\r\n\rJ\n\n\rK";

            using (var stringReader = new StringReader(testCase))
            {
                var expected = stringReader.ReadLines().ToArray();
                var found = testCase.ReadLines().Select(ss => ss.ToString()).ToArray();

                TestFor.Equality(expected, found, "ReadLines should match StringReader behavior");
            }
        }
    }
}
