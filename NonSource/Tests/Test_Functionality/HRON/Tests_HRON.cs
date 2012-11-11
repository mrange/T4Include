using System;
using System.Collections.Generic;
using FileInclude.Source.Common;
using FileInclude.Source.HRON;

#pragma warning disable 0649

#if false

namespace Test_Functionality.HRON
{
    class Config
    {
        public struct UserConfig
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

        public UserConfig? User;
    }

    sealed partial class Visitor : IHRONVisitor
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

        public void Error(int lineNo, SubString line, FileInclude.Source.HRON.HRON.ParseError parseError)
        {
            Console.WriteLine("PARSE_ERROR: {0} {1}: {2}", lineNo, line, parseError);
        }
    }

}

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

            Console.WriteLine("---");

            using (var streamReader = new StreamReader(@".\Test_Functionality.ini"))
            {
                Config config;
                HRONParseError[] errors;
                if (HRON.TryParse(int.MaxValue, streamReader.ReadLines(), out config, out errors))
                {
                    var format = HRON.ToString(config);
                    Console.WriteLine(format);
                }
            }
        }
#endif
