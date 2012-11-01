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

// ### INCLUDE: Log.cs

// ReSharper disable InconsistentNaming

namespace Source.Common
{
    using System;
    using System.Globalization;

    partial class Log
    {
        static readonly object s_colorLock = new object ();
        static partial void Partial_LogMessage (Level level, string message)
        {
            var now = DateTime.Now;
            var finalMessage = string.Format (
                CultureInfo.InvariantCulture,
                "{0:HHmmss} {1}:{2}",
                now,
                GetLevelMessage (level),
                message
                );
            lock (s_colorLock)
            {
                var oldColor = Console.ForegroundColor;
                Console.ForegroundColor = GetLevelColor (level);
                try
                {
                    Console.WriteLine (finalMessage);
                }
                finally
                {
                    Console.ForegroundColor = oldColor;
                }

            }
        }
    }
}
