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

using System;
using System.IO;
using FileInclude.Source.Common;
using FileInclude.Source.HRON;

namespace Test_FunctionalityNet20
{

    partial class Program
    {
        static void Main(string[] args)
        {
            // Basic sanity check to see if functionality that are supposed to work
            // on .NET2 compiles

            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var hron = File.ReadAllText("Test.hron");

            var visitor = new HRONWriterVisitor();

            HRONSerializer.Parse(
                int.MaxValue,
                hron.ReadLines(),
                visitor);

            Console.WriteLine (visitor.Value);
        }
    }
}
