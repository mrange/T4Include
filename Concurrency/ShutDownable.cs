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

using Source.Common;

namespace Source.Concurrency
{
    using System;

    partial interface IShutDownable : IDisposable
    {
        /// <summary>
        /// SignalShutDown - signals the object to shutdown
        /// Shall not Throw
        /// Shall not Block
        /// </summary>
        void SignalShutDown ();

        /// <summary>
        /// WaitForShutDown - waits for the object to shutdown
        /// Should not Throw
        /// May Block
        /// </summary>
        /// <param name="remainingTime"></param>
        void WaitForShutDown (RemainingTime remainingTime);
    }

    static partial class ShutDownable
    {
        public static void ShutDown (RemainingTime remainingTime, params IShutDownable[] shutDownables)
        {
            if (shutDownables == null)
            {
                return;
            }

            foreach (var shutDownable in shutDownables)
            {
                if (shutDownable != null)
                {
                    shutDownable.SignalShutDown ();
                }
            }
            
            foreach (var shutDownable in shutDownables)
            {
                if (shutDownable != null)
                {
                    try
                    {
                        shutDownable.WaitForShutDown (remainingTime);
                    }
                    catch (Exception exc)
                    {
                        Log.Exception ("Failed to shutdown: {0}", exc);
                    }
                }
            }
            
        }
            
    }
}