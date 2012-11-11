using System.IO;
using System.Linq;
using FileInclude.Source.Common;
using FileInclude.Source.Extensions;
using FileInclude.Source.HRON;

namespace Test_Functionality.HRON
{
    sealed partial class TestsFor_HRON
    {
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
    }

}