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

namespace Source.Common
{
    using System;
    using System.Threading;

    abstract partial class BaseDisposable : IDisposable
    {
        int m_isDisposed;

        public bool IsDisposed
        {
            get { return m_isDisposed != 0; }
        }

        public void Dispose ()
        {
            if (Interlocked.Exchange (ref m_isDisposed, 1) == 0)
            {
                try
                {
                    OnDispose ();
                }
                catch (Exception exc)
                {
                    Log.Exception (
                        "BaseDisposable.Dispose for {0}, caught exception: {1}", 
                        GetType ().FullName,
                        exc
                        );
                }
            }            
        }

        protected abstract void OnDispose ();
    }

}
