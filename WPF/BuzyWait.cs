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

// ReSharper disable InconsistentNaming

// ### INCLUDE: Generated_BuzyWait_DependencyProperties.cs

namespace Source.WPF
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    using Source.Extensions;
    
    partial class BuzyWait : FrameworkElement
    {
        const int       Spokes      = 18    ;
        const double    RadiusRatio = 0.95  ;
        const double    MinRadius   = 0.25  ;
        const double    WidthRatio  = 1/16.0;

        readonly static DoubleAnimation s_animationClock    ;

        partial class Spoke
        {
            public Transform Transform  ;
            public double Offset        ;

            public double GetOpacity (double clock)
            {
                return (clock + Offset)%1.0;
            }
        }

        static readonly Spoke[] s_spokes;
        AnimationClock m_clock;

        static BuzyWait ()
        {
            s_spokes = Enumerable
                .Range (0, Spokes)
                .Select (x => ((double)x) / Spokes)
                .Select (
                    x => new Spoke
                        {
                            Transform   = new RotateTransform (360.0 * x).FreezeObject ()   ,
                            Offset      = x                                                 ,
                        })
                .ToArray ();

            s_animationClock = new DoubleAnimation (
                1,
                0,
                new Duration (TimeSpan.FromSeconds(2))
                )
                {
                    RepeatBehavior = RepeatBehavior.Forever
                };
            s_animationClock.FreezeObject ();
        }

        partial void Changed_IsWaiting(bool oldValue, bool newValue)
        {
            if (newValue)
            {
                Start ();
            }
            else
            {
                Stop ();
            }
        }

        void Start ()
        {
            Stop ();
            m_clock = s_animationClock.CreateClock ();
            ApplyAnimationClock (AnimationClockProperty, m_clock);
        }

        void Stop ()
        {
            if (m_clock != null)
            {
                ApplyAnimationClock (AnimationClockProperty, null);
                m_clock = null;
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var min = Math.Min (ActualWidth, ActualHeight);
    
            var radius      = RadiusRatio * min/2;
            var minRadius   = min * MinRadius;
            var spokeLength = radius - minRadius;
            var spokeWidth  = spokeLength * WidthRatio;
            var spokeRadius = spokeWidth / 2;
                
            var centerX = ActualWidth / 2;
            var centerY = ActualHeight / 2;

            var clock = GetAnimationClock (this);
    
            drawingContext.PushTransform (new TranslateTransform (centerX, centerY));

            for (var index = 0; index < s_spokes.Length; index++)
            {
                var spoke = s_spokes[index];
                drawingContext.PushTransform(spoke.Transform);
                drawingContext.PushOpacity(spoke.GetOpacity(clock));

                drawingContext.DrawRoundedRectangle(
                    Brushes.White,
                    null,
                    new Rect(minRadius, -spokeRadius, spokeLength, spokeWidth),
                    spokeRadius,
                    spokeRadius
                    );

                drawingContext.Pop();
                drawingContext.Pop();
            }

            drawingContext.Pop ();
        }
    
    }
}
