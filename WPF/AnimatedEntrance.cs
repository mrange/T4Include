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
// ReSharper disable MemberCanBeProtected.Local
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantCaseLabel
// ReSharper disable UnassignedField.Local

// ### INCLUDE: Generated_AnimatedEntrance_DependencyProperties.cs
// ### INCLUDE: Generated_AnimatedEntrance_StateMachine.cs
// ### INCLUDE: ../Extensions/WpfExtensions.cs


using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;
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
                state.Owner     = Owner     ;
                state.Request   = Request   ;
            }

        }

        partial class State_PresentingContent
        {
            public  UIElement   Current     ;

            partial void IsEdgeValid_PresentingContent_To_Transitioning(Option presentOption, UIElement next, ref bool result)
            {
                result = 
                        !ReferenceEquals(Current, next)
                    &&  (next == null || Owner.Children.Contains(next))
                    ;
            }

            partial void TransformInto_Transitioning(Option presentOption, UIElement next, State_Transitioning nextState)
            {
                nextState.Previous      = Current       ;
                nextState.Next          = next          ;
                nextState.PresentOption = presentOption ;
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
                if (Request != null)
                {
                    Owner.SetState (
                        this, 
                        EdgeFrom_Transitioning_To_DelayingNextTransition(Next));
                }
                else
                {
                    Owner.SetState (this, EdgeFrom_Transitioning_To_PresentingContent(Next));
                }

            }

            partial void Leave_Transitioning(BaseState nextState)
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

            }

            partial void TransformInto_PresentingContent(UIElement current, State_PresentingContent nextState)
            {
                nextState.Current = current;
            }

            partial void TransformInto_DelayingNextTransition(UIElement current, State_DelayingNextTransition nextState)
            {
                nextState.Current = current;
            }

            public void Tick()
            {
                var clock = GetAnimationClock(Owner);

                switch (PresentOption)
                {
                    case Option.Fade:
                        Owner.m_current.Opacity = clock.Interpolate (PreviousOpacity_Start, PreviousOpacity_End);
                        Owner.m_next.Opacity    = clock.Interpolate (NextOpacity_Start, PreviousOpacity_End);
                        break;
                    case Option.PushFromLeft:
                    case Option.PushFromRight:
                    case Option.PushFromTop:
                    case Option.PushFromBottom:
                        PreviousTransform.UpdateFromVector(clock.Interpolate (PreviousOffset_Start, PreviousOffset_End));
                        NextTransform.UpdateFromVector(clock.Interpolate (NextOffset_Start, NextOffset_End));
                        break;
                    case Option.CoverFromLeft:
                    case Option.CoverFromRight:
                    case Option.CoverFromTop:
                    case Option.CoverFromBottom:
                        NextTransform.UpdateFromVector(clock.Interpolate (NextOffset_Start, NextOffset_End));
                        break;
                    case Option.RevealToLeft:
                    case Option.RevealToRight:
                    case Option.RevealToTop:
                    case Option.RevealToBottom:
                        PreviousTransform.UpdateFromVector(clock.Interpolate (PreviousOffset_Start, PreviousOffset_End));
                        break;
                    default:
                    case Option.Instant:
                        // TODO:
                        break;
                }
            }
        }

        partial class State_DelayingNextTransition
        {
            public  UIElement   Current     ;

            partial void IsEdgeValid_DelayingNextTransition_To_Transitioning(Option presentOption, UIElement next, ref bool result)
            {
                result = 
                        !ReferenceEquals(Current, next)
                    &&  (next == null || Owner.Children.Contains(next))
                    ;
            }

            partial void Enter_DelayingNextTransition(BaseState previousState)
            {
                Owner.m_delay.Start ();
            }

            partial void Leave_DelayingNextTransition(BaseState nextState)
            {
                Owner.m_delay.Stop ();
            }
            
        }

        sealed partial class State_Initial
        {
            partial void TransformInto_PresentingContent(UIElement current, State_PresentingContent nextState)
            {
                nextState.Owner.m_current.Child = current;
            }
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

            public override BaseState Visit_Initial(State_Initial state)
            {
                state.Request = new PendingRequest
                                    {
                                        PresentOption   = PresentOption ,
                                        Next            = Next          ,
                                    };
                return state;
            }

            public override BaseState Visit_PresentingContent(State_PresentingContent state)
            {
                state.Request = null;
                return state.EdgeFrom_PresentingContent_To_Transitioning(
                        PresentOption     ,
                        Next              
                        );
            }

            public override BaseState Visit_Transitioning(State_Transitioning state)
            {
                state.Request = new PendingRequest
                                    {
                                        PresentOption   = PresentOption ,
                                        Next            = Next          ,
                                    };
                return state;
            }

            public override BaseState Visit_DelayingNextTransition(State_DelayingNextTransition state)
            {
                state.Request = new PendingRequest
                                    {
                                        PresentOption   = PresentOption ,
                                        Next            = Next          ,
                                    };
                return state;
            }
        }


        sealed partial class AnimationClockTickVisitor : BaseNoActionStateVisitor
        {
            public override BaseState Visit_Transitioning(State_Transitioning state)
            {
                state.Tick();
                return state;
            }
        }

        sealed partial class DelayVisitor : BaseNoActionStateVisitor
        {
            public override BaseState Visit_DelayingNextTransition(State_DelayingNextTransition state)
            {
                var request = state.Request;
                if (request != null && state.IsEdgeValid_DelayingNextTransition_To_Transitioning(request.PresentOption, request.Next))
                {
                    return state.EdgeFrom_DelayingNextTransition_To_Transitioning (request.PresentOption, request.Next);
                }
                else
                {
                    return state.EdgeFrom_DelayingNextTransition_To_PresentingContent (state.Current);
                }
            }
        }

        sealed partial class InitializeVisitor : BaseThrowingStateVisitor
        {
            public override BaseState Visit_Initial(State_Initial state)
            {
                var request = state.Request;
                var firstChild = state.Owner.Children.FirstOrDefault (c => c != null);
                if (request != null && request.Next != null)
                {
                    return state.EdgeFrom_Initial_To_PresentingContent(request.Next);
                }
                else if (firstChild != null)
                {
                    return state.EdgeFrom_Initial_To_PresentingContent(firstChild);
                }
                else
                {
                    return state.EdgeFrom_Initial_To_PresentingContent(null);
                }
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

        static readonly AnimationClockTickVisitor s_animationClockTickVisitor = new AnimationClockTickVisitor();
        static readonly DelayVisitor s_delayVisitor = new DelayVisitor();

        DispatcherTimer                 m_delay             ;
        Canvas                          m_canvas;
        Border                          m_current   = new Border ();
        Border                          m_next      = new Border ();

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
            m_delay = new DispatcherTimer (
                s_delayDuration.TimeSpan,
                DispatcherPriority.ApplicationIdle,
                OnDelay,
                Dispatcher
                );
            m_currentState = new State_Initial
                                 {
                                     Owner = this,
                                 };
            Children = new ObservableCollection<UIElement> ();
        }

        void OnDelay(object sender, EventArgs e)
        {
            m_delay.Stop ();

            if (!IsValid)
            {
                return;
            }

            UpdateState(s_delayVisitor);

        }

        bool IsValid
        {
            get
            {
                return m_currentState.CurrentState != State.Initial;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            m_canvas    = GetTemplateChild(PART_Canvas) as Canvas;

            if (m_canvas != null)
            {
                m_canvas.Children.Add(m_current);
                UpdateState (new InitializeVisitor());
            }

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
            var animatedEntrance = dependencyObject as AnimatedEntrance;
            if (animatedEntrance == null)
            {
                return;
            }

            if (!animatedEntrance.IsValid)
            {
                return;
            }

            animatedEntrance.UpdateState(s_animationClockTickVisitor);
        }

        public void Present (Option option, UIElement element)
        {
            if (!IsValid)
            {
                return;
            }

            UpdateState(new PresentVisitor(option, element));
        }
    
    }

}
