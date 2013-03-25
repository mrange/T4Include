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
    using System.Windows.Media;

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

        public static TFreezable FreezeObject<TFreezable> (this TFreezable freezable)
            where TFreezable : Freezable
        {
            if (freezable == null)
            {
                return null;
            }

            if (!freezable.IsFrozen && freezable.CanFreeze)
            {
                freezable.Freeze ();
            }

            return freezable;
        }

        public static TranslateTransform ToTranslateTransform (this Vector v)
        {
            return new TranslateTransform (v.X, v.Y);
        }

        public static TranslateTransform UpdateFromVector (this TranslateTransform tt, Vector v)
        {
            if (tt == null)
            {
                return null;
            }

            tt.X = v.X;
            tt.Y = v.Y;

            return tt;
        }

        public static bool IsNear (this double v, double c)
        {
            return Math.Abs(v - c) < double.Epsilon * 100;            
        }

        public static double Interpolate (this double t, double from, double to)
        {
            if (t < 0)
            {
                return from;
            }

            if (t > 1)
            {
                return to;
            }

            return t*(to - from) + from;
        }
        
        public static Vector Interpolate (this double t, Vector from, Vector to)
        {
            if (t < 0)
            {
                return from;
            }

            if (t > 1)
            {
                return to;
            }

            return new Vector (
                t*(to.X - from.X) + from.X,
                t*(to.Y - from.Y) + from.Y
                );
        }

        public static Rect ToRect (this Size size)
        {
            return new Rect(0,0,size.Width, size.Height);
        }

        public static Size ScaleToFit (this Size size, Size toFit)
        {
            if (size.Height.IsNear (0))
            {
                return new Size (toFit.Width, 0);
            }

            if (toFit.Height.IsNear (0))
            {
                return new Size (toFit.Width, 0);
            }

            var ratio = size.Width / size.Height;
            var toFitRatio = toFit.Width / size.Height;

            if (ratio > toFitRatio)
            {
                return new Size(toFit.Width, toFit.Width/ratio);    
            }
            else
            {
                return new Size(toFit.Height*ratio, toFit.Height);    
            }

        }
    
    }
}
