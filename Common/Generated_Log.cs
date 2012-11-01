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

// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################





namespace Source.Common
{
    using System;

    partial class Log
    {
        public enum Level
        {
            Success = 1000,
            HighLight = 2000,
            Info = 3000,
            Warning = 10000,
            Error = 20000,
            Exception = 21000,
        }

        public static void Success (string format, params object[] args)
        {
            LogMessage (Level.Success, format, args);
        }
        public static void HighLight (string format, params object[] args)
        {
            LogMessage (Level.HighLight, format, args);
        }
        public static void Info (string format, params object[] args)
        {
            LogMessage (Level.Info, format, args);
        }
        public static void Warning (string format, params object[] args)
        {
            LogMessage (Level.Warning, format, args);
        }
        public static void Error (string format, params object[] args)
        {
            LogMessage (Level.Error, format, args);
        }
        public static void Exception (string format, params object[] args)
        {
            LogMessage (Level.Exception, format, args);
        }
        static ConsoleColor GetLevelColor (Level level)
        {
            switch (level)
            {
                case Level.Success:
                    return ConsoleColor.Green;
                case Level.HighLight:
                    return ConsoleColor.White;
                case Level.Info:
                    return ConsoleColor.Gray;
                case Level.Warning:
                    return ConsoleColor.Yellow;
                case Level.Error:
                    return ConsoleColor.Red;
                case Level.Exception:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Magenta;
            }
        }

        static string GetLevelMessage (Level level)
        {
            switch (level)
            {
                case Level.Success:
                    return "SUCCESS  ";
                case Level.HighLight:
                    return "HIGHLIGHT";
                case Level.Info:
                    return "INFO     ";
                case Level.Warning:
                    return "WARNING  ";
                case Level.Error:
                    return "ERROR    ";
                case Level.Exception:
                    return "EXCEPTION";
                default:
                    return "UNKNOWN  ";
            }
        }

    }
}

