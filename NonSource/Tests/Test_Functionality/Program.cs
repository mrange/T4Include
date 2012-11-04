using System;
using System.IO;
using System.Reflection;
using ProjectInclude.Source.Common;
using ProjectInclude.Source.Extensions;

namespace Test_Functionality
{
    class Program
    {
        static void Main(string[] args)
        {
            IHRONParseVisitor visitor = new Visitor();
            var hron = Assembly.GetExecutingAssembly().GetResourceString("Test_Functionality.hron.txt");

            using (var stringReader = new StringReader(hron))
            {
                HRON.Parse(int.MaxValue, stringReader.ReadLines(), visitor);
            }

            using (var stringReader = new StringReader(hron))
            {
                HRONObject hronObject;
                HRONParseError[] errors;
                if (HRON.TryParse(int.MaxValue, stringReader.ReadLines(), out hronObject, out errors))
                {
                    Console.WriteLine(hronObject);
                }
            }

            using (var streamReader = new StreamReader(@".\Test_Functionality.ini"))
            {
                HRON.Parse(int.MaxValue, streamReader.ReadLines(), visitor);                
            }
        }
    }

    class Visitor : IHRONParseVisitor
    {
        #region Implementation of IHRONParseVisitor

        public void Empty(string name)
        {
            Console.WriteLine("EMPTY: {0}", name);
        }

        public void Comment(string comment)
        {
            Console.WriteLine("COMMENT: {0}", comment);
        }

        public void Value(string name, string value)
        {
            Console.WriteLine("VALUE: {0} = {1}", name, value);
        }

        public void BeginObject(string name)
        {
            Console.WriteLine("BEGIN_OBJECT: {0}", name);
        }

        public void EndObject(string name)
        {
            Console.WriteLine("END_OBJECT: {0}", name);
        }

        public void ParseError(int lineNo, string line, HRON.ParseError parseError)
        {
            Console.WriteLine("PARSE_ERROR: {0} {1}: {2}", lineNo, line, parseError);
        }

        #endregion
    }
}
