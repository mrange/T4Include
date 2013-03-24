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
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable RedundantCaseLabel

// ### INCLUDE: Generated_AnimatedEntrance_DependencyProperties.cs


using System.Windows.Media;
using Source.Extensions;

namespace Source.WPF
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System;
    using System.Windows.Media.Animation;

    [TemplatePart(Name = PART_Canvas    , Type = typeof(Canvas))]
    [ContentProperty("Children")]
    sealed partial class AnimatedEntrance : Control
    {
        const string PART_Canvas    = @"PART_Canvas"    ;
    
        public enum Option
        {
            Instant         ,
            Fade            ,
            PushFromLeft    ,
            PushFromRight   ,
            PushFromTop     ,
            PushFromBottom  ,
            CoverFromLeft   ,
            CoverFromRight  ,
            CoverFromTop    ,
            CoverFromBottom ,
            RevealToLeft    ,
            RevealToRight   ,
            RevealToTop     , 
            RevealToBottom  ,
        }
    
        sealed partial class PendingRequest
        {
            public Option    PresentOption  ;
            public UIElement Next           ;
        }

        abstract partial class BaseState
        {
            public AnimatedEntrance Owner       ;
            public PendingRequest   Request     ;

            partial void Initialize_BaseState(BaseState state)
            {
                state.Owner = Owner;
            }

        }

        partial class State_PresentingContent
        {
            public  UIElement   Current     ;

            partial void IsEdgeValid_PresentingContent_To_Transitioning(EdgeParam_PresentingContent_To_Transitioning p, ref bool isValid)
            {
                isValid = 
                        !ReferenceEquals(Current, p.Next)
                    &&  (p.Next == null || Owner.Children.Contains(p.Next))
                    ;
            }

            partial void TransformInto_Transitioning(EdgeParam_PresentingContent_To_Transitioning p, State_Transitioning nextState)
            {
                nextState.Previous  = Current   ;
                nextState.Next      = p.Next    ;
            }
            
        }

        partial class State_Transitioning
        {
            public UIElement        Previous                ;
            public UIElement        Next                    ;
            public Option           PresentOption           ;
            public AnimationClock   Clock                   ;

            public double           PreviousOpacity_Start   = 1;
            public double           PreviousOpacity_End     = 1;
            public double           NextOpacity_Start       = 1;
            public double           NextOpacity_End         = 1;

            public Vector           PreviousOffset_Start    ;
            public Vector           PreviousOffset_End      ;
            public Vector           NextOffset_Start        ;
            public Vector           NextOffset_End          ;

            public TranslateTransform   PreviousTransform   ;
            public TranslateTransform   NextTransform       ;

            Vector GetOffset()
            {
                switch (PresentOption)
                {
                    case Option.PushFromLeft:
                    case Option.CoverFromLeft:
                    case Option.RevealToLeft:
                        return new Vector (-Owner.ActualWidth, 0);
                    case Option.PushFromRight:
                    case Option.CoverFromRight:
                    case Option.RevealToRight:
                        return new Vector (Owner.ActualWidth, 0);
                    case Option.PushFromTop:
                    case Option.CoverFromTop:
                    case Option.RevealToTop:
                        return new Vector (0, -Owner.ActualHeight);
                    case Option.PushFromBottom:
                    case Option.CoverFromBottom:
                    case Option.RevealToBottom:
                        return new Vector (0, Owner.ActualHeight);
                    default:
                    case Option.Instant:
                    case Option.Fade:
                        return new Vector ();
                }
            }

            partial void Enter_Transitioning(BaseState previousState)
            {
                switch (PresentOption)
                {
                    case Option.Fade:                                              
                        PreviousOpacity_End = 0;
                        NextOpacity_Start   = 0;
                        break;
                    case Option.PushFromLeft:
                    case Option.PushFromRight:
                    case Option.PushFromTop:
                    case Option.PushFromBottom:
                        NextOffset_Start        = GetOffset();
                        PreviousOffset_End      = -NextOffset_Start;
                        break;
                    case Option.CoverFromLeft:
                    case Option.CoverFromRight:
                    case Option.CoverFromTop:
                    case Option.CoverFromBottom:
                        NextOffset_Start        = GetOffset();
                        break;
                    case Option.RevealToLeft:
                    case Option.RevealToRight:
                    case Option.RevealToTop:
                    case Option.RevealToBottom:
                        PreviousOffset_End      = -GetOffset();
                        break;
                    default:
                    case Option.Instant:
                        // TODO:
                        throw new ArgumentOutOfRangeException();
                }

                PreviousTransform               = PreviousOffset_Start.ToTranslateTransform();
                NextTransform                   = NextOffset_Start.ToTranslateTransform();

                Owner.m_current.Opacity         = PreviousOpacity_Start ;
                Owner.m_current.RenderTransform = PreviousTransform     ;

                Owner.m_next.Opacity            = NextOpacity_Start     ;
                Owner.m_next.RenderTransform    = NextTransform         ;

                Owner.m_next.Child  = Next;

                Clock             =  s_transitionClock.CreateClock();
                Clock.Completed   += Transition_Completed;

                switch (PresentOption)
                {
                    case Option.RevealToLeft:
                    case Option.RevealToRight:
                    case Option.RevealToTop:
                    case Option.RevealToBottom:
                        Owner.m_canvas.Children.Insert(0, Owner.m_next);
                        break;
                    case Option.Instant:
                    case Option.Fade:
                    case Option.PushFromLeft:
                    case Option.PushFromRight:
                    case Option.PushFromTop:
                    case Option.PushFromBottom:
                    case Option.CoverFromLeft:
                    case Option.CoverFromRight:
                    case Option.CoverFromTop:
                    case Option.CoverFromBottom:
                    default:
                        Owner.m_canvas.Children.Add(Owner.m_next);
                        break;
                }

                Owner.Dispatcher.Async_Invoke ("Awaiting measure/arrange before starting animation", StartAnimation);

            }

            void StartAnimation()
            {
                Owner.ApplyAnimationClock(AnimationClockProperty, Clock, HandoffBehavior.SnapshotAndReplace);
            }

            void Transition_Completed(object sender, EventArgs e)
            {
                Owner.ApplyAnimationClock(AnimationClockProperty, null);

                var tmp         = Owner.m_current;
                Owner.m_current = Owner.m_next;
                Owner.m_next    = tmp;

                Owner.m_canvas.Children.Remove(Owner.m_next);

                Owner.m_current.Opacity             = 1     ;
                Owner.m_current.RenderTransform     = null  ;

                Owner.m_next.Opacity                = 1     ;
                Owner.m_current.RenderTransform     = null  ;
                
                Owner.m_next.Child                  = null  ;

                if (Request != null)
                {
                    Owner.SetState (
                        this, 
                        EdgeFrom_Transitioning_To_DelayingNextTransition(new Edge));
                }
                else
                {
                    Owner.SetState (this, EdgeFrom_Transitioning_To_PresentingContent());
                }

            }

            public void Tick()
            {
                var clock = GetAnimationClock(Owner);

                switch (PresentOption)
                {
                    case Option.Fade:
                        Owner.m_current.Opacity = clock.Lerp(PreviousOpacity_Start, PreviousOpacity_End);
                        Owner.m_next.Opacity    = clock.Lerp(NextOpacity_Start, PreviousOpacity_End);
                        break;
                    case Option.PushFromLeft:
                    case Option.PushFromRight:
                    case Option.PushFromTop:
                    case Option.PushFromBottom:
                        PreviousTransform.UpdateFromVector(clock.Lerp (PreviousOffset_Start, PreviousOffset_End));
                        NextTransform.UpdateFromVector(clock.Lerp (NextOffset_Start, NextOffset_End));
                        break;
                    case Option.CoverFromLeft:
                    case Option.CoverFromRight:
                    case Option.CoverFromTop:
                    case Option.CoverFromBottom:
                        NextTransform.UpdateFromVector(clock.Lerp (NextOffset_Start, NextOffset_End));
                        break;
                    case Option.RevealToLeft:
                    case Option.RevealToRight:
                    case Option.RevealToTop:
                    case Option.RevealToBottom:
                        PreviousTransform.UpdateFromVector(clock.Lerp (PreviousOffset_Start, PreviousOffset_End));
                        break;
                    default:
                    case Option.Instant:
                        // TODO:
                        break;
                }
            }
        }

        partial struct EdgeParam_PresentingContent_To_Transitioning
        {
            public Option       PresentOption   ;
            public UIElement    Next            ;
        }

        partial struct EdgeParam_Transitioning_To_PresentingContent
        {
            public UIElement    Current         ;
        }

        sealed partial class PresentVisitor : BaseStateVisitor
        {
            public readonly Option      PresentOption  ;
            public readonly UIElement   Next           ;

            public PresentVisitor(Option presentOption, UIElement next)
            {
                PresentOption   = presentOption    ;
                Next            = next      ;
            }

            public override BaseState Visit_PresentingContent(State_PresentingContent state)
            {
                return state.EdgeFrom_PresentingContent_To_Transitioning(
                    new EdgeParam_PresentingContent_To_Transitioning
                    {
                        PresentOption   = PresentOption     ,
                        Next            = Next              ,
                    });
            }

            public override BaseState Visit_Transitioning(State_Transitioning state)
            {
                throw new System.NotImplementedException();
            }

            public override BaseState Visit_DelayingNextTransition(State_DelayingNextTransition state)
            {
                throw new System.NotImplementedException();
            }
        }

        sealed partial class AnimationClockTick : BaseStateVisitor
        {
            public override BaseState Visit_PresentingContent(State_PresentingContent state)
            {
            }

            public override BaseState Visit_Transitioning(State_Transitioning state)
            {
                state.Tick();
            }

            public override BaseState Visit_DelayingNextTransition(State_DelayingNextTransition state)
            {
            }
        }

        public const string DefaultStyle = @"
<Style 
xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
TargetType=""{x:Type i:AnimatedEntrance}""
>
<Setter Property=""Template"">
    <Setter.Value>
        <ControlTemplate TargetType=""{x:Type i:AnimatedEntrance}"">
            <Canvas x:Name=""PART_Canvas"">
            </Canvas>
        </ControlTemplate>
    </Setter.Value>
</Setter>
</Style>
";
    
        readonly static Style           s_defaultStyle      ;
        readonly static Duration        s_transitionDuration;
        readonly static Duration        s_delayDuration     ;
        readonly static DoubleAnimation s_transitionClock   ;
        
        Canvas m_canvas;
        Border m_current   = new Border ();
        Border m_next      = new Border ();

        static AnimatedEntrance()
        {
            var parserContext = new ParserContext
                            {
                                XamlTypeMapper = new XamlTypeMapper(new string[0])
                            };
        
            var type = typeof (AnimatedEntrance);
            var namespaceName = type.Namespace;
            var assemblyName = type.Assembly.FullName;
            parserContext.XamlTypeMapper.AddMappingProcessingInstruction("Internal", namespaceName, assemblyName);
            parserContext.XmlnsDictionary.Add("i", "Internal");
    
            s_defaultStyle = (Style)XamlReader.Parse(
                DefaultStyle,
                parserContext
                );
    
            s_transitionDuration    = new Duration (TimeSpan.FromMilliseconds(0.4));
            s_delayDuration         = new Duration (TimeSpan.FromMilliseconds(0.2));
            s_transitionClock       = new DoubleAnimation(
                0,
                1,
                s_transitionDuration, 
                FillBehavior.Stop
                );

            StyleProperty.OverrideMetadata(typeof(AnimatedEntrance), new FrameworkPropertyMetadata(s_defaultStyle));
        }
    
        partial void Constructed__AnimatedEntrance()
        {
            m_currentState = new State_PresentingContent
                                 {
                                     Owner = this,
                                 };
            Children = new ObservableCollection<UIElement> ();
        }
    
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            m_canvas    = GetTemplateChild(PART_Canvas) as Canvas;

            m_canvas.Children.Add(m_current);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            Canvas.SetRight(m_current, arrangeBounds.Width);
            Canvas.SetBottom(m_current, arrangeBounds.Height);

            Canvas.SetRight(m_next, arrangeBounds.Width);
            Canvas.SetBottom(m_next, arrangeBounds.Height);

            var result = base.ArrangeOverride(arrangeBounds);

            return result;
        }

        static partial void Changed_AnimationClock(DependencyObject dependencyObject, double oldValue, double newValue)
        {
            UpdateState(new AnimationClockTick());
        }

        public void Present (Option option, UIElement element)
        {
            UpdateState(new PresentVisitor(option, element));
        }
    
    }

}
