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



    partial class AccordionPanel : Panel
    {
        readonly static Duration        s_transitionDuration;
        readonly static DoubleAnimation s_transitionClock   ;

        static AccordionPanel ()
        {
            s_transitionDuration    = new Duration (TimeSpan.FromMilliseconds(2000));
            s_transitionClock       = new DoubleAnimation(
                0,
                1,
                s_transitionDuration, 
                FillBehavior.Stop
                );
            
        }

        public sealed partial class State
        {
            public double               From        ;
            public double               To          ;
            public TranslateTransform   Transform   ;
            public double               GetCurrent (double clock)
            {
                return clock.Interpolate(From, To);
            }

            public void Update(double x)
            {
                if (Transform != null)
                {
                    Transform.X = x;
                }
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

            var adjustedSize = new Size (
                availableSize.Width - (count - 1) * PreviewWidth, 
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
                finalSize.Width - (count - 1) * previewWidth, 
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

                var current = state.GetCurrent (animationClock); 

                state.From  = current;
                state.To    = desiredX;

                state.Update (current);

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
                    state.Update (state.GetCurrent(newValue));
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

    }
}
