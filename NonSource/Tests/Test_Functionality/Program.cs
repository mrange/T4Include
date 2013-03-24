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

namespace Test_Functionality
{
    using System;
    using FileInclude.Source.Testing;

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var testResult = TestRunner.ExecuteTests(typeof(TestFor).Assembly);

            Environment.ExitCode = testResult ? 0 : 101;
        }

    }
}
