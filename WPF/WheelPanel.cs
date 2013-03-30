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

// ### INCLUDE: Generated_WheelPanel_DependencyProperties.cs

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedParameter.Local

namespace Source.WPF
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    using Source.Extensions;

    partial class WheelPanel : Panel
    {
        public partial class State
        {
            public MatrixTransform  Transform   ;
            public double           FromAngle   ;
            public double           ToAngle     ;
            public double           FromScale   ;
            public double           ToScale     ;
            
            public double           GetCurrentAngle (double clock)
            {
                return s_animationEase.Ease(clock).Interpolate(FromAngle, ToAngle);
            }

            public double           GetCurrentScale (double clock)
            {
                return s_animationEase.Ease(clock).Interpolate(FromScale, ToScale);
            }

            public void             UpdateTransform (double angle, double scale, Vector centre, double radius)
            {   
                if (Transform != null)
                {
                    var transform = Matrix.Identity;
                    transform.Translate(-radius,0);
                    transform.Rotate(angle);
                    transform.Scale(scale, scale);
                    transform.Translate(centre.X, centre.Y);
                    Transform.Matrix = transform;
                }
            }
        }

        readonly static Duration        s_animationDuration ;
        readonly static DoubleAnimation s_animationClock    ;
        readonly static IEasingFunction s_animationEase     ;
        AnimationClock m_clock;

        static partial void Initialize (
            ref Duration animationDuration,
            ref IEasingFunction animationEase
            );

        static WheelPanel ()
        {
            var animationDuration   = new Duration (TimeSpan.FromMilliseconds(400));
            IEasingFunction animationEase       = new ExponentialEase
                                    {
                                        EasingMode = EasingMode.EaseInOut,
                                    };

            s_animationDuration     = animationDuration ;
            s_animationEase         = animationEase     ;

            Initialize (ref s_animationDuration, ref animationEase);

            s_animationDuration     = animationDuration ;
            s_animationEase         = animationEase;

            s_animationClock        = new DoubleAnimation(
                0                       ,
                1                       ,
                s_animationDuration     , 
                FillBehavior.Stop
                );
            
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            for (int index = 0; index < Children.Count; index++)
            {
                var child = Children[index];
                child.Measure (availableSize);
            }
            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var count = Children.Count;

            var fromAngle   = FromAngle ;
            var toAngle     = ToAngle   ;
            var stepAngle   = StepAngle ;

            var stepCount   = (int) Math.Ceiling((toAngle - fromAngle)/stepAngle);
            var maxCount    = Math.Min(count, stepCount);

            if (maxCount == 0)
            {
                return finalSize;
            }

            var toScale         = 1.0                           ;
            var fromScale      = Math.Pow(StepScale, maxCount) ;
            var stepScale = StepScale;

            var clock = GetAnimationClock (this);

            StopClock ();

            var centre = Centre;

            var currentScale    = toScale;
            var currentAngle    = toAngle;
            var currentCentre   = new Vector (centre.X * finalSize.Width, centre.Y * finalSize.Height);
            var currentRadius   = Radius*finalSize.Width        ;
            var finalRect       = finalSize.ToRect()            ;

            var doAnimate       = false;

            for (var index = 0; index < maxCount; index++)
            {
                var child = Children[index];
                var state = GetChildState(child);
                if (state == null)
                {
                    state = new State
                                {
                                    Transform   = new MatrixTransform() ,
                                    FromAngle   = fromAngle             ,
                                    ToAngle     = fromAngle             ,
                                    FromScale   = fromScale             ,
                                    ToScale     = fromScale             , 
                                };
                    SetChildState (child, state);
                }

                child.Arrange (finalRect);

                if (!state.ToScale.IsNear(currentScale) || !state.ToAngle.IsNear(currentAngle))
                {
                    var scale = state.GetCurrentScale(clock);
                    var angle = state.GetCurrentAngle(clock);

                    doAnimate = true;
                }

                currentScale    *= stepScale    ;
                currentAngle    += stepAngle    ;

            }

            return finalSize;
        }

        void StartClock()
        {
            StopClock ();
            m_clock = s_animationClock.CreateClock();
            m_clock.Completed += Animation_Completed;
            ApplyAnimationClock(AnimationClockProperty, m_clock, HandoffBehavior.SnapshotAndReplace);
        }

        void StopClock()
        {
            if (m_clock != null)
            {
                m_clock.Completed -= Animation_Completed;
                m_clock = null;
                ApplyAnimationClock(AnimationClockProperty, null);
            }

        }

        void Animation_Completed(object sender, EventArgs e)
        {
            StopClock();
            SetAnimationClock(this, 1);
        }

        partial void Coerce_FromAngle(ref double coercedValue)
        {
            coercedValue = Clamp(coercedValue, double.MinValue, ToAngle);
        }

        partial void Changed_FromAngle(double oldValue, double newValue)
        {
            InvalidateArrange();
        }

        partial void Coerce_ToAngle(ref double coercedValue)
        {
            coercedValue = Clamp(coercedValue, FromAngle, double.MaxValue);
        }

        partial void Changed_ToAngle(double oldValue, double newValue)
        {
            InvalidateArrange();
        }

        static double Clamp (double v, double f, double t)
        {
            if (v < f)
            {
                return f;
            }

            if (v > t)
            {
                return t;
            }

            return v;
        }

        partial void Coerce_StepAngle(ref double coercedValue)
        {
            coercedValue = Clamp(coercedValue, 1, double.MaxValue);
        }

        partial void Changed_StepAngle(double oldValue, double newValue)
        {
            InvalidateArrange();
        }

        partial void Changed_Centre(Point oldValue, Point newValue)
        {
            InvalidateArrange();
        }

        partial void Coerce_Radius(ref double coercedValue)
        {
            coercedValue = Clamp(coercedValue, 0, double.MaxValue);
        }

        partial void Changed_Radius(double oldValue, double newValue)
        {
            InvalidateArrange();
        }

        partial void Changed_StepScale(double oldValue, double newValue)
        {
            InvalidateArrange();
        }

    }
}
