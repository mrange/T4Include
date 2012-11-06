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
            var visitor = new Visitor();

            using (var streamReader = new StreamReader(@".\Test_Functionality.ini"))
            {
                HRON.Parse(int.MaxValue, streamReader.ReadLines(), visitor);
            }

            using (var streamReader = new StreamReader(@".\Test_Functionality.ini"))
            {
                HRONObject hron;
                HRONParseError[] errors;
                if (HRON.TryParse(int.MaxValue, streamReader.ReadLines(), out hron, out errors))
                {
                    Console.WriteLine(hron);
                    var doc = HRON.WriteDocument(hron);
                    Console.WriteLine(doc);
                }


            }
        }
    }

    class Visitor : IHRONDocumentVisitor
    {
        public void Comment(int indent, SubString comment)
        {
            Console.WriteLine("COMMENT: {0}", comment);
        }

        public void Value_Begin(SubString name)
        {
            Console.WriteLine("BEGIN_VALUE: {0}", name);
        }

        public void Value_Line(SubString line)
        {
            Console.WriteLine("VALUE: {0}", line);
        }

        public void Value_End(SubString name)
        {
            Console.WriteLine("END_VALUE: {0}", name);
        }

        public void Object_Begin(SubString name)
        {
            Console.WriteLine("BEGIN_OBJECT: {0}", name);
        }

        public void Object_End(SubString name)
        {
            Console.WriteLine("END_OBJECT: {0}", name);
        }

        public void Error(int lineNo, SubString line, HRON.ParseError parseError)
        {
            Console.WriteLine("PARSE_ERROR: {0} {1}: {2}", lineNo, line, parseError);
        }
    }
}
