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
        public void Comment(SubString comment)
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
