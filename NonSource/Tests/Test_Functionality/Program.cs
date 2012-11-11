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
using System.Linq;
using System.Reflection;
using FileInclude.Source.Common;

namespace Test_Functionality
{
    class Program
    {
        static void Main(string[] args)
        {
            var testResult = ExecuteTestsInAssembly(typeof(TestFor).Assembly);

            Environment.ExitCode = testResult ? 0 : 101;
        }

        static bool ExecuteTestsInAssembly(Assembly assembly)
        {
            if (assembly == null)
            {
                Log.Error("Assembly parameter is null");
                ++TestFor.FailureCount;
                return false;
            }

            var preFailureCount = TestFor.FailureCount;
            var assemblyName = assembly.GetName().Name;
            try
            {
                Log.Info("Executing tests contained in: {0}", assemblyName);

                Log.Info("Locating test classes...");
                var testClasses = assembly
                    .GetTypes()
                    .Where(t => t.Name.StartsWith("TestsFor_", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(t => t.Name)
                    .ToArray()
                    ;
                Log.HighLight("Found {0} test classes", testClasses.Length);

                foreach (var testClass in testClasses)
                {
                    var preClassFailureCount = TestFor.FailureCount;
                    var className = testClass.Name;
                    try
                    {
                        Log.Info("Executing tests contained in class: {0}", className);
                        var instance = Activator.CreateInstance(testClass, nonPublic: true);
                        using (var disposable = instance as IDisposable)
                        {
                            var testMethods = testClass
                                .GetMethods()
                                .Where(mi => mi.Name.StartsWith("Test_", StringComparison.OrdinalIgnoreCase))
                                .ToArray();

                            foreach (var testMethod in testMethods)
                            {
                                var preMethodFailureCount = TestFor.FailureCount;
                                try
                                {
                                    if (testMethod.GetParameters().Length > 0)
                                    {
                                        Log.Warning(
                                            "Can't execute test method as it has more than 0 parameters: {0}.{1}",
                                            className,
                                            testMethod.Name
                                            );

                                        continue;
                                    }

                                    Log.Info("Executing test: {0}.{1}", className, testMethod.Name);

                                    testMethod.Invoke(instance, new object[0]);
                                }
                                catch (Exception exc)
                                {
                                    Log.Exception("Caught method level exception for: {0}", exc);
                                    ++TestFor.FailureCount;
                                }
                                finally
                                {
                                    if (TestFor.FailureCount == preMethodFailureCount)
                                    {
                                        Log.Success("Executed test: {0}.{1}", className, testMethod.Name);
                                    }
                                    else
                                    {
                                        Log.Error("Executed test: {0}.{1}", className, testMethod.Name);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        Log.Exception("Caught class level exception", exc);
                        ++TestFor.FailureCount;
                    }
                    finally
                    {
                        if (preClassFailureCount == TestFor.FailureCount)
                        {
                            Log.Success("Executed tests in class: {0}", className);
                        }
                        else
                        {
                            Log.Error("Executed tests in class: {0}", className);
                        }
                    }
                }
            }
            finally
            {
                if (preFailureCount == TestFor.FailureCount)
                {
                    Log.Success("Executed tests in assembly: {0}", assemblyName);
                }
                else
                {
                    Log.Error("Executed tests in assembly: {0}", assemblyName);
                }
            }

            return preFailureCount == TestFor.FailureCount;
        }
    }
}
