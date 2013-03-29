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
// ReSharper disable NotAccessedField.Local
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCaseLabel
// ReSharper disable RedundantIfElseBlock
// ReSharper disable RedundantNameQualifier
// ReSharper disable UnassignedField.Local
// ReSharper disable UnusedParameter.Local

// ### INCLUDE: Generated_AnimatedEntrance_DependencyProperties.cs
// ### INCLUDE: Generated_AnimatedEntrance_StateMachine.cs
// ### INCLUDE: ../Extensions/WpfExtensions.cs


namespace Source.WPF
{
    using Source.Extensions;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Threading;

    [TemplatePart(Name = PART_Panel    , Type = typeof(Panel))]
    [ContentProperty("Children")]
    partial class AnimatedEntrance : Control
    {
        const string PART_Panel    = @"PART_Panel"    ;
    
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

            public readonly Vector  PreviousOffset_Start    = new Vector ();
            public Vector           PreviousOffset_End      ;
            public Vector           NextOffset_Start        ;
            public readonly Vector  NextOffset_End          = new Vector ();

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
                var nextOpacity = 1.0;
                switch (PresentOption)
                {
                    case Option.Fade:
                        nextOpacity = 0;                      
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
                        break;
                }

                PreviousTransform               = PreviousOffset_Start.ToTranslateTransform();
                NextTransform                   = NextOffset_Start.ToTranslateTransform();

                Owner.m_current.Opacity         = 1                     ;
                Owner.m_current.RenderTransform = PreviousTransform     ;
                Owner.m_current.IsHitTestVisible= false                 ;

                Owner.m_next.Opacity            = nextOpacity           ;
                Owner.m_next.RenderTransform    = NextTransform         ;
                Owner.m_next.IsHitTestVisible   = false                 ;

                Owner.m_next.Child  = Next;

                switch (PresentOption)
                {
                    case Option.RevealToLeft:
                    case Option.RevealToRight:
                    case Option.RevealToTop:
                    case Option.RevealToBottom:
                        Owner.m_panel.Children.Insert(0, Owner.m_next);
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
                        Owner.m_panel.Children.Add(Owner.m_next);
                        break;
                }

                if (PresentOption != Option.Instant)
                {
                    Owner.Dispatcher.Async_Invoke (
                        "AnimatedEntrance: Awaiting measure/arrange before starting animation", 
                        StartAnimation
                        );
                }
                else
                {
                    Owner.Dispatcher.Async_Invoke(
                        "AnimatedEntrance: Switching to next control instantly", 
                        ShowInstant
                        );
                }

            }

            void ShowInstant()
            {
                FollowEdge();
            }

            void StartAnimation()
            {
                Clock             =  s_transitionClock.CreateClock();
                Clock.Completed   += Transition_Completed;

                Owner.ApplyAnimationClock(AnimationClockProperty, Clock, HandoffBehavior.SnapshotAndReplace);
            }

            void Transition_Completed(object sender, EventArgs e)
            {
                FollowEdge();
            }

            void FollowEdge()
            {
                if (Request != null)
                {
                    Owner.SetState(
                        this,
                        EdgeFrom_Transitioning_To_DelayingNextTransition(Next));
                }
                else
                {
                    Owner.SetState(this, EdgeFrom_Transitioning_To_PresentingContent(Next));
                }
            }

            partial void Leave_Transitioning(BaseState nextState)
            {
                if (Clock != null)
                {
                    Clock.Completed   -= Transition_Completed;
                }
                Owner.ApplyAnimationClock(AnimationClockProperty, null);

                var tmp         = Owner.m_current;
                Owner.m_current = Owner.m_next;
                Owner.m_next    = tmp;

                Owner.m_panel.Children.Remove(Owner.m_next);

                Owner.m_current.Opacity             = 1     ;
                Owner.m_current.RenderTransform     = null  ;
                Owner.m_current.IsHitTestVisible    = true  ;

                Owner.m_next.Opacity                = 1     ;
                Owner.m_next.RenderTransform        = null  ;
                Owner.m_next.IsHitTestVisible       = true  ;
                
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
                        Owner.m_next.Opacity    = clock.Interpolate (0.0, 1.0);
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

            partial void TransformInto_PresentingContent(UIElement current, State_PresentingContent nextState)
            {
                nextState.Current = current;
            }

            partial void TransformInto_Transitioning(Option presentOption, UIElement next, State_Transitioning nextState)
            {
                nextState.Previous      = Current       ;
                nextState.Next          = next          ;
                nextState.PresentOption = presentOption ;
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
                nextState.Current = current;
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
                <Grid x:Name=""PART_Panel"">
                </Grid>
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
        static readonly InitializeVisitor s_initializeVisitor = new InitializeVisitor();

        DispatcherTimer                 m_delay             ;
        Panel                           m_panel;
        Border                          m_current   = new Border
                                                          {
                                                              HorizontalAlignment = HorizontalAlignment.Stretch,
                                                              VerticalAlignment = VerticalAlignment.Stretch,
                                                          };
        Border                          m_next      = new Border
                                                          {
                                                              HorizontalAlignment = HorizontalAlignment.Stretch,
                                                              VerticalAlignment = VerticalAlignment.Stretch,
                                                          };

        static AnimatedEntrance()
        {
            var parserContext = new ParserContext
                            {
                                XamlTypeMapper = new XamlTypeMapper(new string[0])
                            };
        
            var type = typeof (AnimatedEntrance);
            var namespaceName = type.Namespace ?? "";
            var assemblyName = type.Assembly.FullName;
            parserContext.XamlTypeMapper.AddMappingProcessingInstruction("Internal", namespaceName, assemblyName);
            parserContext.XmlnsDictionary.Add("i", "Internal");
    
            s_defaultStyle = (Style)XamlReader.Parse(
                DefaultStyle,
                parserContext
                );
    
            s_transitionDuration    = new Duration (TimeSpan.FromMilliseconds(400));
            s_delayDuration         = new Duration (TimeSpan.FromMilliseconds(200));
            s_transitionClock       = new DoubleAnimation(
                0,
                1,
                s_transitionDuration, 
                FillBehavior.Stop
                );
            s_transitionClock.EasingFunction = new ExponentialEase
                                                   {
                                                       EasingMode = EasingMode.EaseInOut,
                                                   };

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
            m_delay.Stop ();

            m_currentState = new State_Initial
                                 {
                                     Owner = this,
                                 };
            Children = new ObservableCollection<UIElement> ();
        }

        partial void Changed_Children(ObservableCollection<UIElement> oldValue, ObservableCollection<UIElement> newValue)
        {
            // TODO: Handle the situation when a displayed element is removed
        }

        void OnDelay(object sender, EventArgs e)
        {
            m_delay.Stop ();

            UpdateState(s_delayVisitor);

        }

        protected override Size MeasureOverride(Size constraint)
        {
            m_panel.Measure(constraint);
            return m_current.DesiredSize;
        }



        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            m_panel    = GetTemplateChild(PART_Panel) as Panel;

            if (m_panel != null)
            {
                m_panel.Children.Add(m_current);
                UpdateState (s_initializeVisitor);
            }

        }

        static partial void Changed_AnimationClock(DependencyObject dependencyObject, double oldValue, double newValue)
        {
            var animatedEntrance = dependencyObject as AnimatedEntrance;
            if (animatedEntrance == null)
            {
                return;
            }

            animatedEntrance.UpdateState(s_animationClockTickVisitor);
        }

        public void Present (Option option, UIElement element)
        {
            UpdateState(new PresentVisitor(option, element));
        }
    
    }

}
