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

namespace Source.Concurrency
{
    using System;
    using System.Diagnostics;

    partial struct RemainingTime
    {
        public readonly TimeSpan    TimeOut     ;
        readonly        Stopwatch   m_sw        ;

        public RemainingTime (TimeSpan timeOut)
        {
            TimeOut     = timeOut           ;
            m_sw        = new Stopwatch ()  ;

            m_sw.Start ();
        }

        public TimeSpan Remaining
        {
            get
            {
                var elapsed = m_sw.Elapsed;

                var remaining = TimeOut - elapsed;

                if (remaining < TimeSpan.Zero)
                {
                    return TimeSpan.Zero;
                }

                return remaining;
            }
        }

        public bool IsTimedOut
        {
            get
            {
                return Remaining == TimeSpan.Zero;
            }
        }
        
    }
}