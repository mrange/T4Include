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

// ### INCLUDE: Array.cs

// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart

namespace Source.Common
{
    using System;
    using System.Globalization;

    static partial class Log
    {
        static partial void Partial_LogMessage (Level level, ConsoleColor levelColor, string levelMessage, string message);
        static partial void Partial_ExceptionOnLog (Level level, string format, object[] args, Exception exc);

        public enum Level
        {
            Success     =  1000,
            HighLight   =  2000,
            Info        =  3000,
            Warning     = 10000,
            Error       = 20000,
            Exception   = 21000,
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
                case Level.Exception:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Magenta;
            }
        }

        static string GetLevelMessage(Level level)
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

        public static void LogMessage(Level level, string format, params object[] args)
        {
            try
            {
                Partial_LogMessage(level, GetLevelColor(level), GetLevelMessage(level), GetMessage(format, args));
            }
            catch (Exception exc)
            {
                Partial_ExceptionOnLog(level, format, args, exc);
            }
            
        }

        static string GetMessage(string format, object[] args)
        {
            format = format ?? "";
            args = args ?? Array<object>.Empty;

            try
            {
                return args.Length == 0
                           ? format
                           : string.Format(CultureInfo.InvariantCulture, format, args)
                    ;
            }
            catch (FormatException)
            {

                return format;
            }
        }
    }
}
