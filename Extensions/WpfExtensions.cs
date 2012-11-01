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

// ### INCLUDE: ../Common/Log.cs

// ReSharper disable InconsistentNaming

namespace Source.Extensions
{
    using System;
    using System.Windows.Threading;
    using System.Windows;
    using System.Windows.Data;

    using Source.Common;

    static partial class WpfExtensions
    {
        public static void Async_Invoke (
            this Dispatcher dispatcher, 
            string actionName, 
            Action action
            )
        {
            if (action == null)
            {
                return;
            }

            Action act = () =>
                             {
#if DEBUG
                                 Log.Info ("Async_Invoke: {0}", actionName ?? "Unknown");
#endif

                                 try
                                 {
                                     action ();
                                 }
                                 catch (Exception exc)
                                 {
                                     Log.Exception ("Async_Invoke: Caught exception: {0}", exc);
                                 }
                             };

            dispatcher = dispatcher ?? Dispatcher.CurrentDispatcher;
            dispatcher.BeginInvoke (DispatcherPriority.ApplicationIdle, act);
        }

        public static void Async_Invoke (
            this DependencyObject dependencyObject, 
            string actionName, 
            Action action
            )
        {
            var dispatcher = dependencyObject == null ? Dispatcher.CurrentDispatcher : dependencyObject.Dispatcher;

            dispatcher.Async_Invoke (actionName, action);
        }

        public static BindingBase GetBindingOf (
            this DependencyObject dependencyObject, 
            DependencyProperty dependencyProperty 
            )
        {
            if (dependencyObject == null)
            {
                return null;
            }

            if (dependencyProperty == null)
            {
                return null;
            }

            return BindingOperations.GetBindingBase (dependencyObject, dependencyProperty);
        }

        public static bool IsBoundTo (
            this DependencyObject dependencyObject, 
            DependencyProperty dependencyProperty 
            )
        {
            if (dependencyObject == null)
            {
                return false;
            }

            if (dependencyProperty == null)
            {
                return false;
            }

            return BindingOperations.IsDataBound (dependencyObject, dependencyProperty);
        }

        public static void ResetBindingOf (
            this DependencyObject dependencyObject, 
            DependencyProperty dependencyProperty, 
            BindingBase binding = null
            )
        {
            if (dependencyObject == null)
            {
                return;
            }

            if (dependencyProperty == null)
            {
                return;
            }

            BindingOperations.ClearBinding (dependencyObject, dependencyProperty);

            if (binding != null)
            {
                BindingOperations.SetBinding (dependencyObject, dependencyProperty, binding);
            }
        }
    }
}
