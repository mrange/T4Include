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

// ### INCLUDE: Config.cs
// ### INCLUDE: Log.cs

// ReSharper disable InconsistentNaming

using System;
using System.Collections.Generic;
using System.IO;
using FileInclude.Source.Common;
using FileInclude.Source.Extensions;
using FileInclude.Source.HRON;
namespace Test_Functionality
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

    class Config2
    {
        public Dictionary<string, string> Common { get; set; }

        public List<Dictionary<string, string>> DataBaseConnection
        {
            get;
            set;
        }
    }

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

            using (var streamReader = new StreamReader(@".\Test_Functionality.ini"))
            {
                Config config;
                HRONParseError[] errors;
                if (HRON.TryParse(int.MaxValue, streamReader.ReadLines(), out config, out errors))
                {
                    Console.WriteLine("Success");
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
