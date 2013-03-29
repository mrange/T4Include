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

// ### INCLUDE: Generated_AccordionPanel_DependencyProperties.cs
// ### INCLUDE: ../Extensions/WpfExtensions.cs


namespace Source.WPF
{
    using Source.Extensions;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Input;

    partial class AccordionPanel : Panel
    {
        readonly static Duration        s_transitionDuration;
        readonly static DoubleAnimation s_transitionClock   ;
        readonly static IEasingFunction s_animationEase     ;

        static partial void Initialize (
            ref Duration animationDuration,
            ref IEasingFunction animationEasy
            );

        static AccordionPanel ()
        {
            var transitionDuration   = new Duration (TimeSpan.FromMilliseconds(400));
            IEasingFunction animationEase       = new ExponentialEase
                                    {
                                        EasingMode = EasingMode.EaseInOut,
                                    };

            s_transitionDuration    = transitionDuration;
            s_animationEase         = animationEase;

            Initialize (ref transitionDuration, ref animationEase);

            s_transitionDuration    = transitionDuration;
            s_animationEase         = animationEase;

            s_transitionClock       = new DoubleAnimation(
                0                       ,
                1                       ,
                s_transitionDuration    , 
                FillBehavior.Stop
                );
            
        }

        partial void Constructed__AccordionPanel()
        {
            MouseButtonEventHandler mouseButtonEventHandler = Mouse_Down;
            AddHandler (MouseDownEvent, mouseButtonEventHandler, handledEventsToo: true);
            ClipToBounds = true;
        }

        public sealed partial class State
        {
            public double               From        ;
            public double               To          ;
            public TranslateTransform   Transform   ;

            public double               GetCurrentX (double clock)
            {
                return s_animationEase.Ease(clock).Interpolate(From, To);
            }

            public void UpdateX(double x)
            {
                Transform.X = x;
            }
        }

        AnimationClock m_clock;

        protected override Size MeasureOverride(Size availableSize)
        {
            var count = Children.Count; 
            if (count == 0)
            {
                return availableSize;
            }

            var previewWidth = PreviewWidth;
            var adjustedSize = new Size (
                Math.Max (availableSize.Width - (count - 1) * previewWidth, previewWidth), 
                availableSize.Height
                );

            for (int index = 0; index < count; index++)
            {
                var child = Children[index];
                child.Measure(adjustedSize);
            }

            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var animationClock = GetAnimationClock (this);

            StopClock();

            var count = Children.Count; 
            if (count == 0)
            {
                return finalSize;
            }

            var previewWidth = PreviewWidth;
            var adjustedSize = new Size (
                Math.Max (finalSize.Width - (count - 1) * previewWidth, previewWidth), 
                finalSize.Height
                );
            var adjustedRect = adjustedSize.ToRect();

            var activeElement = ActiveElement;

            var desiredX = 0.0;

            var doAnimate = false;

            for (int index = 0; index < count; index++)
            {
                var child = Children[index];

                var state = GetChildState(child);
                if (state == null)
                {
                    state = new State
                                {
                                    Transform   = new TranslateTransform(),
                                    From        = finalSize.Width, 
                                    To          = finalSize.Width, 
                                };
                    SetChildState (child, state);
                }

                child.Arrange(adjustedRect);
                child.RenderTransform = state.Transform;

                var current = state.GetCurrentX (animationClock); 

                state.From  = current;
                state.To    = desiredX;

                state.UpdateX (current);

                doAnimate |= !state.From.IsNear (state.To);

                if (ReferenceEquals (child, activeElement))
                {
                    desiredX += adjustedSize.Width;
                }
                else
                {
                    desiredX += previewWidth;
                }
            }

            if (doAnimate)
            {
                StartClock();
            }

            return finalSize;
        }

        void StartClock()
        {
            StopClock ();
            m_clock = s_transitionClock.CreateClock();
            m_clock.Completed += Transition_Completed;
            ApplyAnimationClock(AnimationClockProperty, m_clock, HandoffBehavior.SnapshotAndReplace);
        }

        void StopClock()
        {
            if (m_clock != null)
            {
                m_clock.Completed -= Transition_Completed;
                m_clock = null;
                ApplyAnimationClock(AnimationClockProperty, null);
            }

        }

        void Transition_Completed(object sender, EventArgs e)
        {
            StopClock();
            SetAnimationClock(this, 1);
        }

        static partial void Changed_AnimationClock(DependencyObject dependencyObject, double oldValue, double newValue)
        {
            var accordionPanel = dependencyObject as AccordionPanel;
            if (accordionPanel == null)
            {
                return;
            }

            var count = accordionPanel.Children.Count;
            for (int index = 0; index < count; index++)
            {
                var child = accordionPanel.Children[index];
                var state = GetChildState(child);
                if (state != null)
                {
                    state.UpdateX (state.GetCurrentX(newValue));
                }
                else
                {
                    accordionPanel.InvalidateArrange();
                }
            }
        }

        partial void Changed_ActiveElement(UIElement oldValue, UIElement newValue)
        {
            InvalidateArrange();
        }

        void Mouse_Down(object sender, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition (this);

            var animationClock = GetAnimationClock (this);

            UIElement hit = null;
            var count = Children.Count;
            for (int index = 0; index < count; index++)
            {
                var child = Children[index];
                var state = GetChildState(child);
                var current = state.GetCurrentX(animationClock);

                if (current > pos.X)
                {
                    ActiveElement = hit;
                    return;
                }

                hit = child;
            }

            ActiveElement = hit;
        }

        partial void Coerce_PreviewWidth(double value, ref double coercedValue)
        {
            coercedValue = Math.Max(8,value);
        }

        partial void Changed_PreviewWidth(double oldValue, double newValue)
        {
            InvalidateArrange ();
        }
    }
}
