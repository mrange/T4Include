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
// ### INCLUDE: Generated_Log.cs

// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart

namespace Source.Common
{
    using System;
    using System.Globalization;

    static partial class Log
    {
        static partial void Partial_LogLevel (Level level);
        static partial void Partial_LogMessage (Level level, string message);
        static partial void Partial_ExceptionOnLog (Level level, string format, object[] args, Exception exc);

        public static void LogMessage (Level level, string format, params object[] args)
        {
            try
            {
                Partial_LogLevel (level);
                Partial_LogMessage (level, GetMessage (format, args));
            }
            catch (Exception exc)
            {
                Partial_ExceptionOnLog (level, format, args, exc);
            }
            
        }

        static string GetMessage (string format, object[] args)
        {
            format = format ?? "";
            try
            {
                return (args == null || args.Length == 0)
                           ? format
                           : string.Format (Config.DefaultCulture, format, args)
                    ;
            }
            catch (FormatException)
            {

                return format;
            }
        }
    }
}
