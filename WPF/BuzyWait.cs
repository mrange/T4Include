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
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    using Source.Extensions;
    
    partial class BuzyWait : FrameworkElement
    {
        const int       Spokes          = 18    ;
        const double    RadiusRadius    = 0.95  ;
        const double    MinRadius       = 0.25  ;
        const double    WidthRadius     = 1/32.0;

        readonly static DoubleAnimation s_animationClock    ;

        static readonly Drawing s_drawing;

        AnimationClock m_clock;

        static BuzyWait ()
        {
            var drawingVisual = new DrawingVisual ();
            using (var drawingContext = drawingVisual.RenderOpen())
            {
                for (var i = 0; i < Spokes; ++i)
                {
                    var t = ((double)i) / Spokes;
                    
                    drawingContext.PushOpacity (1 - t);
                    drawingContext.PushTransform (new RotateTransform (360.0 * t));

                    drawingContext.DrawRoundedRectangle(
                        Brushes.White,
                        null,
                        new Rect(MinRadius, -WidthRadius/2, RadiusRadius - MinRadius, WidthRadius),
                        WidthRadius,
                        WidthRadius
                        );

                    drawingContext.Pop ();
                    drawingContext.Pop ();
                }
                
            }

            s_drawing = drawingVisual.Drawing.FreezeObject ();

            s_animationClock = new DoubleAnimation (
                0,
                1,
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

        static partial void Changed_AnimationClock(DependencyObject dependencyObject, double oldValue, double newValue)
        {
            var buzyWait = dependencyObject as BuzyWait;
            if (buzyWait == null)
            {
                return;
            }

            var oldStep = (int)Math.Floor (oldValue * Spokes) % Spokes;
            var newStep = (int)Math.Floor (newValue * Spokes) % Spokes;

            if (oldStep != newStep)
            {
                buzyWait.InvalidateVisual(); 
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var clock = GetAnimationClock(this);
            var step = (int)Math.Floor (clock * Spokes);
            var halfWidth = ActualWidth/2;
            var halfHeight = ActualHeight/2;
            var scale = Math.Min (halfWidth, halfHeight);

            var matrix = Matrix.Identity;
            matrix.Scale (scale, scale);
            var angle = -(step*360.0)/Spokes;
            matrix.Rotate (angle);
            matrix.Translate (halfWidth, halfHeight);
    
            drawingContext.PushTransform(new MatrixTransform (matrix));
                
            drawingContext.DrawDrawing(s_drawing);
    
            drawingContext.Pop();
        }
    
    }
}
