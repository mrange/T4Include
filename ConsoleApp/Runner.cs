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

// ### INCLUDE: ../Common/Config.cs
// ### INCLUDE: ../Common/Log.cs
// ### INCLUDE: ../Common/SubString.cs
// ### INCLUDE: ../Extensions/BasicExtensions.cs
// ### INCLUDE: ../Hron/HRONDynamicObjectSerializer.cs

// ReSharper disable InconsistentNaming

namespace Source.ConsoleApp
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Globalization;
    using System.Threading;

    using Source.Common;
    using Source.Extensions;
    using Source.HRON;

    enum ExitCode
    {
        Ok                  = 0         ,
        InvalidConfigFile   = 101       ,
        Unknown             = 999       ,
    }

    sealed partial class ExitCodeException : Exception
    {
        public readonly ExitCode ExitCode;

        public ExitCodeException(ExitCode exitCode)
        {
            ExitCode = exitCode;
        }
    }

    static partial class Runner
    {
        static partial void Partial_ConsoleAppStarts ();
        static partial void Partial_ConsoleAppStops ();
        static partial void Partial_Run (string[] args, dynamic config);

        public static readonly CultureInfo Default_CurrentCulture  = Thread.CurrentThread.CurrentCulture    ;
        public static readonly CultureInfo Default_CurrentUICulture= Thread.CurrentThread.CurrentUICulture  ;
        public static readonly string      Default_Directory       = Environment.CurrentDirectory           ;

        static readonly string s_consoleName = Assembly.GetExecutingAssembly().GetName().Name;

        public static void Run(string[] args)
        {
            Partial_ConsoleAppStarts ();
            try
            {
                Log.HighLight("{0} is starting...", s_consoleName);
                Thread.CurrentThread.CurrentCulture = Config.DefaultCulture;
                Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

                object config;
                var configFile = "{0}.ini".FormatWith(s_consoleName);
                if (File.Exists(configFile))
                {
                    Log.Info("Loading config file: {0}", configFile);
                    using (var streamReader = new StreamReader(configFile))
                    {
                        HRONDynamicParseError[] parserErrors;
                        if (!HRONSerializer.TryParseDynamic(
                            int.MaxValue,
                            streamReader.ReadLines().Select(x => x.ToSubString()),
                            out config,
                            out parserErrors
                            ))
                        {
                            throw new ExitCodeException(ExitCode.InvalidConfigFile);
                        }
                    }
                }
                else
                {
                    config = HRONObject.Empty;
                }

                Log.Info("Initial setup is done, executing main program");

                Partial_Run(args, config);

                Log.Success("{0} completed", s_consoleName);
            }
            catch (ExitCodeException exc)
            {
                Environment.ExitCode = (int) exc.ExitCode;
                Log.Exception(
                    "Terminated {0} {1}({2:000}), caught exception: {3}",
                    s_consoleName,
                    exc.ExitCode,
                    Environment.ExitCode,
                    exc
                    );
            }
            catch (Exception exc)
            {
                Environment.ExitCode = 999;
                Log.Exception(
                    "Terminated {0} Unknown({1:000}), caught exception: {2}",
                    s_consoleName,
                    Environment.ExitCode,
                    exc
                    );
            }
            finally
            {
                Partial_ConsoleAppStops ();
            }
        }
    }
}
