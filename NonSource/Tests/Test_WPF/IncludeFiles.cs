
// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # text template file (.tt)                                                 #
// ############################################################################



// ############################################################################
// @@@ SKIPPING (Not found): C:\temp\GitHub\T4Include\Extensions\WPF.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\AnimatedEntrance.cs
// @@@ INCLUDE_FOUND: Generated_AnimatedEntrance_DependencyProperties.cs
// @@@ INCLUDE_FOUND: Generated_AnimatedEntrance_StateMachine.cs
// @@@ INCLUDE_FOUND: ../Extensions/WpfExtensions.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\AccordionPanel.cs
// @@@ INCLUDE_FOUND: Generated_AccordionPanel_DependencyProperties.cs
// @@@ INCLUDE_FOUND: ../Extensions/WpfExtensions.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\WatermarkTextBox.cs
// @@@ INCLUDE_FOUND: Generated_WatermarkTextBox_DependencyProperties.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\ReflectionDecorator.cs
// @@@ INCLUDE_FOUND: Generated_ReflectionDecorator_DependencyProperties.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\BuzyWait.cs
// @@@ INCLUDE_FOUND: Generated_BuzyWait_DependencyProperties.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Debug\DebugVisualTreeControl.cs
// @@@ INCLUDE_FOUND: BaseDebugTreeControl.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Debug\DebugLogicalTreeControl.cs
// @@@ INCLUDE_FOUND: BaseDebugTreeControl.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_DependencyProperties.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_StateMachine.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs
// @@@ INCLUDE_FOUND: ../Common/Array.cs
// @@@ INCLUDE_FOUND: ../Common/Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Generated_AccordionPanel_DependencyProperties.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Generated_WatermarkTextBox_DependencyProperties.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Generated_ReflectionDecorator_DependencyProperties.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Generated_BuzyWait_DependencyProperties.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Debug\BaseDebugTreeControl.cs
// @@@ INCLUDE_FOUND: Generated_BaseDebugTreeControl_DependencyProperties.cs
// @@@ INCLUDE_FOUND: DebugContainerControl.cs
// @@@ INCLUDE_FOUND: ../../Extensions/WpfExtensions.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\WPF\Debug\BaseDebugTreeControl.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Array.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ INCLUDE_FOUND: Config.cs
// @@@ INCLUDE_FOUND: Generated_Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Debug\Generated_BaseDebugTreeControl_DependencyProperties.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Debug\DebugContainerControl.cs
// @@@ INCLUDE_FOUND: ../../Extensions/WpfExtensions.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Config.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Generated_Log.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs
// ############################################################################
// Certains directives such as #define and // Resharper comments has to be 
// moved to top in order to work properly    
// ############################################################################
// ReSharper disable CompareOfFloatsByEqualityOperator
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable InconsistentNaming
// ReSharper disable InvocationIsSkipped
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable MemberCanBeProtected.Local
// ReSharper disable NotAccessedField.Local
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PossibleUnintendedReferenceComparison
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCaseLabel
// ReSharper disable RedundantCast
// ReSharper disable RedundantIfElseBlock
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantUsingDirective
// ReSharper disable UnassignedField.Local
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedParameter.Local
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\AnimatedEntrance.cs
namespace FileInclude
{
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
    
                    var clockWithEase = s_transitionEase.Ease(clock);
    
                    switch (PresentOption)
                    {
                        case Option.Fade:
                            Owner.m_next.Opacity    = clockWithEase.Interpolate (0.0, 1.0);
                            break;
                        case Option.PushFromLeft:
                        case Option.PushFromRight:
                        case Option.PushFromTop:
                        case Option.PushFromBottom:
                            PreviousTransform.UpdateFromVector(clockWithEase.Interpolate (PreviousOffset_Start, PreviousOffset_End));
                            NextTransform.UpdateFromVector(clockWithEase.Interpolate (NextOffset_Start, NextOffset_End));
                            break;
                        case Option.CoverFromLeft:
                        case Option.CoverFromRight:
                        case Option.CoverFromTop:
                        case Option.CoverFromBottom:
                            NextTransform.UpdateFromVector(clockWithEase.Interpolate (NextOffset_Start, NextOffset_End));
                            break;
                        case Option.RevealToLeft:
                        case Option.RevealToRight:
                        case Option.RevealToTop:
                        case Option.RevealToBottom:
                            PreviousTransform.UpdateFromVector(clockWithEase.Interpolate (PreviousOffset_Start, PreviousOffset_End));
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
            readonly static IEasingFunction s_transitionEase    ;
    
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
    
    
            static partial void Initialize (
                ref Duration transitionDuration,
                ref Duration delayDuration,
                ref IEasingFunction transitionEase
                );
    
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
        
                var transitionDuration    = new Duration (TimeSpan.FromMilliseconds(400));
                var delayDuration         = new Duration (TimeSpan.FromMilliseconds(200));
                IEasingFunction transitionEase        = new ExponentialEase
                                                {
                                                    EasingMode = EasingMode.EaseInOut,
                                                };
    
                s_transitionDuration      = transitionDuration  ;
                s_delayDuration           = delayDuration       ;
                s_transitionEase          = transitionEase      ;
    
                Initialize (ref transitionDuration, ref delayDuration, ref transitionEase);
    
                s_transitionDuration      = transitionDuration  ;
                s_delayDuration           = delayDuration       ;
                s_transitionEase          = transitionEase      ;
    
                s_transitionClock       = new DoubleAnimation(
                    0                       ,
                    1                       ,
                    s_transitionDuration    , 
                    FillBehavior.Stop
                    )
                    .FreezeObject ()
                    ;
    
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
    
            protected override System.Collections.IEnumerator LogicalChildren
            {
                get
                {
                    return Children.GetEnumerator();
                }
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
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\AnimatedEntrance.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\AccordionPanel.cs
namespace FileInclude
{
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
            readonly static Duration        s_animationDuration ;
            readonly static DoubleAnimation s_animationClock    ;
            readonly static IEasingFunction s_animationEase     ;
    
            static partial void Initialize (
                ref Duration animationDuration,
                ref IEasingFunction animationEase
                );
    
            static AccordionPanel ()
            {
                var animationDuration   = new Duration (TimeSpan.FromMilliseconds(400));
                IEasingFunction animationEase       = new ExponentialEase
                                        {
                                            EasingMode = EasingMode.EaseInOut,
                                        };
    
                s_animationDuration     = animationDuration;
                s_animationEase         = animationEase;
    
                Initialize (ref animationDuration, ref animationEase);
    
                s_animationDuration     = animationDuration;
                s_animationEase         = animationEase;
    
                s_animationClock       = new DoubleAnimation(
                    0                       ,
                    1                       ,
                    s_animationDuration     , 
                    FillBehavior.Stop
                    )
                    .FreezeObject ()
                    ;
                
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
    
                public void UpdateTransform(double x)
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
    
                    state.UpdateTransform (current);
    
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
                        state.UpdateTransform (state.GetCurrentX(newValue));
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
    
            partial void Coerce_PreviewWidth(ref double coercedValue)
            {
                coercedValue = Math.Max(8, coercedValue);
            }
    
            partial void Changed_PreviewWidth(double oldValue, double newValue)
            {
                InvalidateArrange ();
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\AccordionPanel.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\WatermarkTextBox.cs
namespace FileInclude
{
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
    
    
    
    namespace Source.WPF
    {
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Markup;
    
        partial class WatermarkTextBox : TextBox
        {
            const string DefaultStyle = @"
    <Style 
        xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
        TargetType=""{x:Type i:WatermarkTextBox}"">
        <Setter Property=""FocusVisualStyle"" Value=""{x:Null}""/>
        <Setter Property=""Foreground"" Value=""#000""/>
        <Setter Property=""BorderBrush"" Value=""#888""/>
        <Setter Property=""WatermarkForeground"" Value=""#888""/>
        <Setter Property=""WatermarkText"" Value=""Enter some text...""/>
        <Setter Property=""BorderThickness"" Value=""1""/>
        <Setter Property=""SnapsToDevicePixels"" Value=""true""/>
        <Setter Property=""Template"">
            <Setter.Value>
                <ControlTemplate TargetType=""{x:Type i:WatermarkTextBox}"">
                    <Grid>
                        <Border x:Name=""Border""
                            Background=""{TemplateBinding Background}""
                            BorderBrush=""{TemplateBinding BorderBrush}""
                            BorderThickness=""{TemplateBinding BorderThickness}""
                            Padding=""2""
                            CornerRadius=""2""
                            >
        
                            <Grid>
                                <!-- The implementation places the Content into the ScrollViewer. It must be named PART_ContentHost for the control to function -->
                                <ScrollViewer
                                    Margin=""0""
                                    x:Name=""PART_ContentHost""
                                    SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}""
                                />
                                <TextBlock
                                    Margin=""4,0,0,0""
                                    VerticalAlignment=""Top""
                                    x:Name=""Watermark""
                                    Foreground=""{TemplateBinding WatermarkForeground}""
                                    FontStyle=""Italic""
                                    Text=""{TemplateBinding WatermarkText}""
                                    SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}""
                                    />
                            </Grid>
                        </Border>
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property=""IsEnabled"" Value=""False"">
                            <Setter Property=""Opacity"" Value=""0.67""/>
                        </Trigger>
                        <Trigger Property=""IsFocused"" Value=""true"">
                            <Setter TargetName=""Border"" Property=""BorderBrush"" Value=""#FF9000""/>
                            <Setter TargetName=""Border"" Property=""BorderThickness"" Value=""2""/>
                            <Setter TargetName=""Border"" Property=""Margin"" Value=""-1""/>
                        </Trigger>
                        <Trigger Property=""IsWatermarkVisible"" Value=""False"">
                            <Setter Property=""Visibility"" Value=""Collapsed"" TargetName=""Watermark""/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    ";
    
            static readonly Style s_defaultStyle;
            
            static WatermarkTextBox ()
            {
                var parserContext = new ParserContext
                                {
                                    XamlTypeMapper = new XamlTypeMapper(new string[0])
                                };
            
                var type = typeof (WatermarkTextBox);
                var namespaceName = type.Namespace ?? "";
                var assemblyName = type.Assembly.FullName;
                parserContext.XamlTypeMapper.AddMappingProcessingInstruction("Internal", namespaceName, assemblyName);
                parserContext.XmlnsDictionary.Add("i", "Internal");
        
                s_defaultStyle = (Style)XamlReader.Parse(
                    DefaultStyle,
                    parserContext
                    );
                
                StyleProperty.OverrideMetadata(typeof(WatermarkTextBox), new FrameworkPropertyMetadata(s_defaultStyle));
            }
    
            protected override void OnTextChanged(TextChangedEventArgs e)
            {
                base.OnTextChanged(e);
                IsWatermarkVisible = string.IsNullOrEmpty (Text);
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\WatermarkTextBox.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\ReflectionDecorator.cs
namespace FileInclude
{
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
    
    
    
    namespace Source.WPF
    {
        using System;
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Media;
    
        using Source.Extensions;
    
        partial class ReflectionDecorator : Decorator
        {
            VisualBrush m_brush;
            LinearGradientBrush m_opacityMask;
            MatrixTransform m_transform;
    
            partial void Constructed__ReflectionDecorator()
            {
                m_opacityMask   = new LinearGradientBrush (
                    new GradientStopCollection
                        {
                            new GradientStop (Colors.Transparent                , 0     ),    
                            new GradientStop ("#2000".ParseColor(Colors.Black)  , 0.25  ),    
                            new GradientStop ("#4000".ParseColor(Colors.Black)  , 0.50  ),    
                            new GradientStop ("#8000".ParseColor(Colors.Black)  , 0.75  ),    
                            new GradientStop (Colors.Black                      , 1     ),    
                        },
                    90
                    ).FreezeObject ();    
    
                m_transform = new MatrixTransform ();
    
                VerticalAlignment = VerticalAlignment.Center;       
                HorizontalAlignment = HorizontalAlignment.Center;
            }
    
            public override UIElement Child
            {
                get
                {
                    return base.Child;
                }
                set
                {
                    base.Child = value;
                    if (value == null)
                    {
                        m_brush = null;
                    }
                    else if (m_brush == null || !ReferenceEquals (m_brush.Visual, value))
                    {
                        m_brush = new VisualBrush (value)
                                        {
                                            Stretch           = Stretch.None      ,
                                            AlignmentY        = AlignmentY.Bottom , 
                                            AutoLayoutContent = false             , 
                                            TileMode          = TileMode.None     ,
                                        }.FreezeObject ();
                    }
                }
            }
    
            protected override Size MeasureOverride(Size constraint)
            {
                var fullReflectionSize = FullReflectionSize;
                var adjustedSize = new Size (
                    constraint.Width, 
                    (constraint.Height - fullReflectionSize).LimitBy(constraint.Height)
                    );
                var measuredSize = base.MeasureOverride (adjustedSize);
    
                var result = new Size(measuredSize.Width, measuredSize.Height + fullReflectionSize).LimitBy(constraint);
    
                return result;
            }
    
            double FullReflectionSize
            {
                get
                {
                    return ReflectionSeparation + ReflectionSize;
                }
            }
    
            protected override Size ArrangeOverride(Size arrangeSize)
            {
                var fullReflectionSize = FullReflectionSize;
                var adjustedSize = new Size (
                    arrangeSize.Width, 
                    (arrangeSize.Height - fullReflectionSize).LimitBy(arrangeSize.Height)
                    );
    
                    var finalSize = base.ArrangeOverride (adjustedSize);
    
                var result = new Size(finalSize.Width, finalSize.Height + fullReflectionSize).LimitBy(arrangeSize);
    
                return result;
            }
    
            partial void Coerce_ReflectionSeparation(ref double coercedValue)
            {
                coercedValue = Math.Max (0, coercedValue);
            }
    
            partial void Changed_ReflectionSeparation(double oldValue, double newValue)
            {
                InvalidateMeasure();
            }
    
            partial void Coerce_ReflectionSize(ref double coercedValue)
            {
                coercedValue = Math.Max (0, coercedValue);
            }
    
            partial void Changed_ReflectionSize(double oldValue, double newValue)
            {
                InvalidateMeasure();
            }
    
    
            protected override void OnRender(DrawingContext drawingContext)
            {
                var child = Child;
                if (child == null)
                {
                    return;
                }
    
                if (m_brush == null)
                {
                    return;
                }
    
                var renderSize = RenderSize;
                var childRenderSize = child.RenderSize;
                var reflectionSize = ReflectionSize;
                var reflectionSeparation = ReflectionSeparation;
    
                var matrix = Matrix.Identity;
                matrix.Scale(1,-1);
                matrix.Translate (0, childRenderSize.Height + reflectionSize + reflectionSeparation);
    
                m_transform.Matrix = matrix;
    
                drawingContext.PushTransform (m_transform);
                drawingContext.PushOpacityMask (m_opacityMask);
    
                var rectangle = new Rect(
                    0, 
                    0, 
                    renderSize.Width, 
                    reflectionSize
                    );
    
                drawingContext.DrawRectangle (
                    m_brush, 
                    null, 
                    rectangle
                    );
    
                drawingContext.Pop();
                drawingContext.Pop();
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\ReflectionDecorator.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\BuzyWait.cs
namespace FileInclude
{
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
    
            partial void Changed_IsEnabled (bool oldValue, bool newValue)
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
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\BuzyWait.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\Debug\DebugVisualTreeControl.cs
namespace FileInclude
{
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
    
    
    namespace Source.WPF.Debug
    {
        using System.Collections.Generic;
        using System.Windows;
        using Source.Extensions;
    
        partial class DebugVisualTreeControl : BaseDebugTreeControl
        {
            protected override int OnGetOrdinal()
            {
                return 1000;
            }
    
            protected override string OnGetFriendlyName()
            {
                return "Visual Tree";
            }
    
            protected override IEnumerable<DependencyObject> GetChildren(DependencyObject dependencyObject)
            {
                return dependencyObject.GetVisualChildren ();
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\Debug\DebugVisualTreeControl.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\Debug\DebugLogicalTreeControl.cs
namespace FileInclude
{
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
    
    
    namespace Source.WPF.Debug
    {
        using System.Collections.Generic;
        using System.Windows;
        using Source.Extensions;
    
        partial class DebugLogicalTreeControl : BaseDebugTreeControl
        {
            protected override int OnGetOrdinal()
            {
                return 2000;
            }
    
            protected override string OnGetFriendlyName()
            {
                return "Logical Tree";
            }
    
            protected override IEnumerable<DependencyObject> GetChildren(DependencyObject dependencyObject)
            {
                return dependencyObject.GetLogicalChildren ();
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\Debug\DebugLogicalTreeControl.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_DependencyProperties.cs
namespace FileInclude
{
    
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
                                       
    
    
    namespace Source.WPF
    {
        using System.Collections;
        using System.Collections.ObjectModel;
        using System.Collections.Specialized;
    
        using System.Windows;
        using System.Windows.Media;
    
        // ------------------------------------------------------------------------
        // AnimatedEntrance
        // ------------------------------------------------------------------------
        partial class AnimatedEntrance
        {
            #region Uninteresting generated code
            static readonly DependencyPropertyKey ChildrenPropertyKey = DependencyProperty.RegisterReadOnly (
                "Children",
                typeof (ObservableCollection<UIElement>),
                typeof (AnimatedEntrance),
                new FrameworkPropertyMetadata (
                    null,
                    FrameworkPropertyMetadataOptions.None,
                    Changed_Children,
                    Coerce_Children          
                ));
    
            public static readonly DependencyProperty ChildrenProperty = ChildrenPropertyKey.DependencyProperty;
    
            static void Changed_Children (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                var instance = dependencyObject as AnimatedEntrance;
                if (instance != null)
                {
                    var oldValue = (ObservableCollection<UIElement>)eventArgs.OldValue;
                    var newValue = (ObservableCollection<UIElement>)eventArgs.NewValue;
    
                    if (oldValue != null)
                    {
                        oldValue.CollectionChanged -= instance.CollectionChanged_Children;
                    }
    
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += instance.CollectionChanged_Children;
                    }
    
                    instance.Changed_Children (oldValue, newValue);
                }
            }
    
            void CollectionChanged_Children(object sender, NotifyCollectionChangedEventArgs e)
            {
                CollectionChanged_Children (
                    sender, 
                    e.Action,
                    e.OldStartingIndex,
                    e.OldItems,
                    e.NewStartingIndex,
                    e.NewItems
                    );
            }
    
            static object Coerce_Children (DependencyObject dependencyObject, object basevalue)
            {
                var instance = dependencyObject as AnimatedEntrance;
                if (instance == null)
                {
                    return basevalue;
                }
                var value = (ObservableCollection<UIElement>)basevalue;
    
                instance.Coerce_Children (ref value);
    
                if (value == null)
                {
                   value = new ObservableCollection<UIElement> ();
                }
    
                return value;
            }
    
            public static readonly DependencyProperty AnimationClockProperty = DependencyProperty.RegisterAttached (
                "AnimationClock",
                typeof (double),
                typeof (AnimatedEntrance),
                new FrameworkPropertyMetadata (
                    default (double),
                    FrameworkPropertyMetadataOptions.None,
                    Changed_AnimationClock,
                    Coerce_AnimationClock          
                ));
    
            static void Changed_AnimationClock (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                if (dependencyObject != null)
                {
                    var oldValue = (double)eventArgs.OldValue;
                    var newValue = (double)eventArgs.NewValue;
    
                    Changed_AnimationClock (dependencyObject, oldValue, newValue);
                }
            }
    
            static object Coerce_AnimationClock (DependencyObject dependencyObject, object basevalue)
            {
                if (dependencyObject == null)
                {
                    return basevalue;
                }
                var value = (double)basevalue;
    
                Coerce_AnimationClock (dependencyObject, ref value);
    
                return value;
            }
            #endregion
    
            // --------------------------------------------------------------------
            // Constructor
            // --------------------------------------------------------------------
            public AnimatedEntrance ()
            {
                CoerceAllProperties ();
                Constructed__AnimatedEntrance ();
            }
            // --------------------------------------------------------------------
            partial void Constructed__AnimatedEntrance ();
            // --------------------------------------------------------------------
            void CoerceAllProperties ()
            {
                CoerceValue (ChildrenProperty);
                CoerceValue (AnimationClockProperty);
            }
    
    
            // --------------------------------------------------------------------
            // Properties
            // --------------------------------------------------------------------
    
               
            // --------------------------------------------------------------------
            public ObservableCollection<UIElement> Children
            {
                get
                {
                    return (ObservableCollection<UIElement>)GetValue (ChildrenProperty);
                }
                private set
                {
                    if (Children != value)
                    {
                        SetValue (ChildrenPropertyKey, value);
                    }
                }
            }
            // --------------------------------------------------------------------
            partial void Changed_Children (ObservableCollection<UIElement> oldValue, ObservableCollection<UIElement> newValue);
            partial void Coerce_Children (ref ObservableCollection<UIElement> coercedValue);
            partial void CollectionChanged_Children (object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems);
            // --------------------------------------------------------------------
    
    
               
            // --------------------------------------------------------------------
            public static double GetAnimationClock (DependencyObject dependencyObject)
            {
                if (dependencyObject == null)
                {
                    return default (double);
                }
    
                return (double)dependencyObject.GetValue (AnimationClockProperty);
            }
    
            public static void SetAnimationClock (DependencyObject dependencyObject, double value)
            {
                if (dependencyObject != null)
                {
                    if (GetAnimationClock (dependencyObject) != value)
                    {
                        dependencyObject.SetValue (AnimationClockProperty, value);
                    }
                }
            }
    
            public static void ClearAnimationClock (DependencyObject dependencyObject)
            {
                if (dependencyObject != null)
                {
                    dependencyObject.ClearValue (AnimationClockProperty);
                }
            }
            // --------------------------------------------------------------------
            static partial void Changed_AnimationClock (DependencyObject dependencyObject, double oldValue, double newValue);
            static partial void Coerce_AnimationClock (DependencyObject dependencyObject, ref double coercedValue);
            // --------------------------------------------------------------------
    
    
        }
        // ------------------------------------------------------------------------
    
    }
                                       
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_DependencyProperties.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_StateMachine.cs
namespace FileInclude
{
    using System.Windows;
    
    
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
    
    
    
    
    namespace Source.WPF
    {
        using System;
        using System.Threading;
    
        partial class AnimatedEntrance
        {
            abstract partial class BaseState
            {   
                public abstract State CurrentState {get;}
    
                // ----------------------------------------------------------------- 
                protected BaseState ()
                {
                    Constructed_BaseState();
                }
                // ----------------------------------------------------------------- 
                partial void Constructed_BaseState();
                // ----------------------------------------------------------------- 
    
                // ----------------------------------------------------------------- 
                public void InitializeState(BaseState state)
                {
                    OnInitializeState(state);
                }
    
                public void EnterState(BaseState previousState)
                {
                    OnEnterState(previousState);
                }
    
                public void LeaveState(BaseState nextState)
                {
                    OnLeaveState(nextState);
                }
    
                protected virtual void OnInitializeState(BaseState state)
                {
                    Initialize_BaseState(state);
                }
    
                protected virtual void OnEnterState(BaseState previousState)
                {
                    Enter_BaseState(previousState);
                }
    
                protected virtual void OnLeaveState(BaseState nextState)
                {
                    Leave_BaseState(nextState);
                }
                // ----------------------------------------------------------------- 
                partial void Initialize_BaseState(BaseState state);
                partial void Enter_BaseState(BaseState previousState);
                partial void Leave_BaseState(BaseState nextState);
                // ----------------------------------------------------------------- 
            }
    
    
            enum State
            {
                Initial,
                PresentingContent,
                Transitioning,
                DelayingNextTransition,
            }
    
            sealed partial class State_Initial : BaseState
            {
                // ----------------------------------------------------------------- 
                public State_Initial ()
                {
                    Constructed_State_Initial();
                }
                // ----------------------------------------------------------------- 
                partial void Constructed_State_Initial();
                // ----------------------------------------------------------------- 
    
                public override State CurrentState { get { return State.Initial; } }
    
                // ----------------------------------------------------------------- 
                protected override void OnEnterState(BaseState previousState)
                {
                    base.OnEnterState(previousState);
                    Enter_Initial(previousState);
                }
    
                protected override void OnLeaveState(BaseState nextState)
                {
                    Leave_Initial(nextState);
                    base.OnLeaveState(nextState);
                }
                // ----------------------------------------------------------------- 
                partial void Enter_Initial(BaseState previousState);
                partial void Leave_Initial(BaseState nextState);
                // ----------------------------------------------------------------- 
    
    
                // ----------------------------------------------------------------- 
                // From:    Initial
                // To:      PresentingContent
                // ----------------------------------------------------------------- 
                public bool IsEdgeValid_Initial_To_PresentingContent(UIElement current)
                {
                    var result = true;
    
                    IsEdgeValid_Initial_To_PresentingContent (current, ref result);
    
                    return result;
                }
    
    
                public BaseState EdgeFrom_Initial_To_PresentingContent(UIElement current)            
                {
                    if (!IsEdgeValid_Initial_To_PresentingContent(current))
                    {
                        return this;
                    }
    
                    var nextState = new State_PresentingContent();
    
                    InitializeState(nextState);
    
                    TransformInto_PresentingContent (current, nextState);
    
                    LeaveState(nextState);
                    nextState.EnterState(this);
                   
                    return nextState;
                }
                // ----------------------------------------------------------------- 
                partial void IsEdgeValid_Initial_To_PresentingContent (UIElement current, ref bool result);
                partial void TransformInto_PresentingContent (UIElement current, State_PresentingContent nextState);
                // ----------------------------------------------------------------- 
    
            }
    
            sealed partial class State_PresentingContent : BaseState
            {
                // ----------------------------------------------------------------- 
                public State_PresentingContent ()
                {
                    Constructed_State_PresentingContent();
                }
                // ----------------------------------------------------------------- 
                partial void Constructed_State_PresentingContent();
                // ----------------------------------------------------------------- 
    
                public override State CurrentState { get { return State.PresentingContent; } }
    
                // ----------------------------------------------------------------- 
                protected override void OnEnterState(BaseState previousState)
                {
                    base.OnEnterState(previousState);
                    Enter_PresentingContent(previousState);
                }
    
                protected override void OnLeaveState(BaseState nextState)
                {
                    Leave_PresentingContent(nextState);
                    base.OnLeaveState(nextState);
                }
                // ----------------------------------------------------------------- 
                partial void Enter_PresentingContent(BaseState previousState);
                partial void Leave_PresentingContent(BaseState nextState);
                // ----------------------------------------------------------------- 
    
    
                // ----------------------------------------------------------------- 
                // From:    PresentingContent
                // To:      Transitioning
                // ----------------------------------------------------------------- 
                public bool IsEdgeValid_PresentingContent_To_Transitioning(Option presentOption, UIElement next)
                {
                    var result = true;
    
                    IsEdgeValid_PresentingContent_To_Transitioning (presentOption, next, ref result);
    
                    return result;
                }
    
    
                public BaseState EdgeFrom_PresentingContent_To_Transitioning(Option presentOption, UIElement next)            
                {
                    if (!IsEdgeValid_PresentingContent_To_Transitioning(presentOption, next))
                    {
                        return this;
                    }
    
                    var nextState = new State_Transitioning();
    
                    InitializeState(nextState);
    
                    TransformInto_Transitioning (presentOption, next, nextState);
    
                    LeaveState(nextState);
                    nextState.EnterState(this);
                   
                    return nextState;
                }
                // ----------------------------------------------------------------- 
                partial void IsEdgeValid_PresentingContent_To_Transitioning (Option presentOption, UIElement next, ref bool result);
                partial void TransformInto_Transitioning (Option presentOption, UIElement next, State_Transitioning nextState);
                // ----------------------------------------------------------------- 
    
            }
    
            sealed partial class State_Transitioning : BaseState
            {
                // ----------------------------------------------------------------- 
                public State_Transitioning ()
                {
                    Constructed_State_Transitioning();
                }
                // ----------------------------------------------------------------- 
                partial void Constructed_State_Transitioning();
                // ----------------------------------------------------------------- 
    
                public override State CurrentState { get { return State.Transitioning; } }
    
                // ----------------------------------------------------------------- 
                protected override void OnEnterState(BaseState previousState)
                {
                    base.OnEnterState(previousState);
                    Enter_Transitioning(previousState);
                }
    
                protected override void OnLeaveState(BaseState nextState)
                {
                    Leave_Transitioning(nextState);
                    base.OnLeaveState(nextState);
                }
                // ----------------------------------------------------------------- 
                partial void Enter_Transitioning(BaseState previousState);
                partial void Leave_Transitioning(BaseState nextState);
                // ----------------------------------------------------------------- 
    
    
                // ----------------------------------------------------------------- 
                // From:    Transitioning
                // To:      PresentingContent
                // ----------------------------------------------------------------- 
                public bool IsEdgeValid_Transitioning_To_PresentingContent(UIElement current)
                {
                    var result = true;
    
                    IsEdgeValid_Transitioning_To_PresentingContent (current, ref result);
    
                    return result;
                }
    
    
                public BaseState EdgeFrom_Transitioning_To_PresentingContent(UIElement current)            
                {
                    if (!IsEdgeValid_Transitioning_To_PresentingContent(current))
                    {
                        return this;
                    }
    
                    var nextState = new State_PresentingContent();
    
                    InitializeState(nextState);
    
                    TransformInto_PresentingContent (current, nextState);
    
                    LeaveState(nextState);
                    nextState.EnterState(this);
                   
                    return nextState;
                }
                // ----------------------------------------------------------------- 
                partial void IsEdgeValid_Transitioning_To_PresentingContent (UIElement current, ref bool result);
                partial void TransformInto_PresentingContent (UIElement current, State_PresentingContent nextState);
                // ----------------------------------------------------------------- 
    
                // ----------------------------------------------------------------- 
                // From:    Transitioning
                // To:      DelayingNextTransition
                // ----------------------------------------------------------------- 
                public bool IsEdgeValid_Transitioning_To_DelayingNextTransition(UIElement current)
                {
                    var result = true;
    
                    IsEdgeValid_Transitioning_To_DelayingNextTransition (current, ref result);
    
                    return result;
                }
    
    
                public BaseState EdgeFrom_Transitioning_To_DelayingNextTransition(UIElement current)            
                {
                    if (!IsEdgeValid_Transitioning_To_DelayingNextTransition(current))
                    {
                        return this;
                    }
    
                    var nextState = new State_DelayingNextTransition();
    
                    InitializeState(nextState);
    
                    TransformInto_DelayingNextTransition (current, nextState);
    
                    LeaveState(nextState);
                    nextState.EnterState(this);
                   
                    return nextState;
                }
                // ----------------------------------------------------------------- 
                partial void IsEdgeValid_Transitioning_To_DelayingNextTransition (UIElement current, ref bool result);
                partial void TransformInto_DelayingNextTransition (UIElement current, State_DelayingNextTransition nextState);
                // ----------------------------------------------------------------- 
    
            }
    
            sealed partial class State_DelayingNextTransition : BaseState
            {
                // ----------------------------------------------------------------- 
                public State_DelayingNextTransition ()
                {
                    Constructed_State_DelayingNextTransition();
                }
                // ----------------------------------------------------------------- 
                partial void Constructed_State_DelayingNextTransition();
                // ----------------------------------------------------------------- 
    
                public override State CurrentState { get { return State.DelayingNextTransition; } }
    
                // ----------------------------------------------------------------- 
                protected override void OnEnterState(BaseState previousState)
                {
                    base.OnEnterState(previousState);
                    Enter_DelayingNextTransition(previousState);
                }
    
                protected override void OnLeaveState(BaseState nextState)
                {
                    Leave_DelayingNextTransition(nextState);
                    base.OnLeaveState(nextState);
                }
                // ----------------------------------------------------------------- 
                partial void Enter_DelayingNextTransition(BaseState previousState);
                partial void Leave_DelayingNextTransition(BaseState nextState);
                // ----------------------------------------------------------------- 
    
    
                // ----------------------------------------------------------------- 
                // From:    DelayingNextTransition
                // To:      Transitioning
                // ----------------------------------------------------------------- 
                public bool IsEdgeValid_DelayingNextTransition_To_Transitioning(Option presentOption, UIElement next)
                {
                    var result = true;
    
                    IsEdgeValid_DelayingNextTransition_To_Transitioning (presentOption, next, ref result);
    
                    return result;
                }
    
    
                public BaseState EdgeFrom_DelayingNextTransition_To_Transitioning(Option presentOption, UIElement next)            
                {
                    if (!IsEdgeValid_DelayingNextTransition_To_Transitioning(presentOption, next))
                    {
                        return this;
                    }
    
                    var nextState = new State_Transitioning();
    
                    InitializeState(nextState);
    
                    TransformInto_Transitioning (presentOption, next, nextState);
    
                    LeaveState(nextState);
                    nextState.EnterState(this);
                   
                    return nextState;
                }
                // ----------------------------------------------------------------- 
                partial void IsEdgeValid_DelayingNextTransition_To_Transitioning (Option presentOption, UIElement next, ref bool result);
                partial void TransformInto_Transitioning (Option presentOption, UIElement next, State_Transitioning nextState);
                // ----------------------------------------------------------------- 
    
                // ----------------------------------------------------------------- 
                // From:    DelayingNextTransition
                // To:      PresentingContent
                // ----------------------------------------------------------------- 
                public bool IsEdgeValid_DelayingNextTransition_To_PresentingContent(UIElement current)
                {
                    var result = true;
    
                    IsEdgeValid_DelayingNextTransition_To_PresentingContent (current, ref result);
    
                    return result;
                }
    
    
                public BaseState EdgeFrom_DelayingNextTransition_To_PresentingContent(UIElement current)            
                {
                    if (!IsEdgeValid_DelayingNextTransition_To_PresentingContent(current))
                    {
                        return this;
                    }
    
                    var nextState = new State_PresentingContent();
    
                    InitializeState(nextState);
    
                    TransformInto_PresentingContent (current, nextState);
    
                    LeaveState(nextState);
                    nextState.EnterState(this);
                   
                    return nextState;
                }
                // ----------------------------------------------------------------- 
                partial void IsEdgeValid_DelayingNextTransition_To_PresentingContent (UIElement current, ref bool result);
                partial void TransformInto_PresentingContent (UIElement current, State_PresentingContent nextState);
                // ----------------------------------------------------------------- 
    
            }
    
    
            abstract partial class BaseStateVisitor
            {
                public abstract BaseState Visit_Initial(State_Initial state);
                public abstract BaseState Visit_PresentingContent(State_PresentingContent state);
                public abstract BaseState Visit_Transitioning(State_Transitioning state);
                public abstract BaseState Visit_DelayingNextTransition(State_DelayingNextTransition state);
            }
    
            abstract partial class BaseThrowingStateVisitor : BaseStateVisitor
            {
                public override BaseState Visit_Initial(State_Initial state)
                {
                    throw new ArgumentException ("state");
                }
                public override BaseState Visit_PresentingContent(State_PresentingContent state)
                {
                    throw new ArgumentException ("state");
                }
                public override BaseState Visit_Transitioning(State_Transitioning state)
                {
                    throw new ArgumentException ("state");
                }
                public override BaseState Visit_DelayingNextTransition(State_DelayingNextTransition state)
                {
                    throw new ArgumentException ("state");
                }
            }
    
            abstract partial class BaseNoActionStateVisitor : BaseStateVisitor
            {
                public override BaseState Visit_Initial(State_Initial state)
                {
                    return state;
                }
                public override BaseState Visit_PresentingContent(State_PresentingContent state)
                {
                    return state;
                }
                public override BaseState Visit_Transitioning(State_Transitioning state)
                {
                    return state;
                }
                public override BaseState Visit_DelayingNextTransition(State_DelayingNextTransition state)
                {
                    return state;
                }
            }
    
            bool SetState (BaseState expectedState, BaseState nextState)
            {
                if (nextState == null)
                {
                    return false;
                }
    
                if (ReferenceEquals (expectedState, nextState))
                {
                    return true;
                }
    
                return ReferenceEquals(Interlocked.CompareExchange(ref m_currentState, nextState, expectedState),expectedState);
            }
    
            bool UpdateState(BaseStateVisitor visitor)
            {
                var currentState = m_currentState;
                if (visitor != null && currentState != null)
                {
                    switch (currentState.CurrentState)
                    {
                    case State.Initial:
                        return SetState (currentState, visitor.Visit_Initial((State_Initial)currentState));
                    case State.PresentingContent:
                        return SetState (currentState, visitor.Visit_PresentingContent((State_PresentingContent)currentState));
                    case State.Transitioning:
                        return SetState (currentState, visitor.Visit_Transitioning((State_Transitioning)currentState));
                    case State.DelayingNextTransition:
                        return SetState (currentState, visitor.Visit_DelayingNextTransition((State_DelayingNextTransition)currentState));
                    default:
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
    
            BaseState m_currentState;
        }
    }
    
                                       
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_StateMachine.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs
namespace FileInclude
{
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
    
    
    
    
    namespace Source.Extensions
    {
        using System;
        using System.Collections.Generic;
        using System.Globalization;
        using System.Linq;
        using System.Reflection;
        using System.Text;
        using System.Windows;
        using System.Windows.Data;
        using System.Windows.Media;
        using System.Windows.Threading;
        using System.Xml;
    
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
        
            public static string GetName (this DependencyObject dependencyObject)
            {
                var frameworkElement = dependencyObject as FrameworkElement;
                if (frameworkElement != null)
                {
                    return frameworkElement.Name ?? "";
                }
    
                var frameworkContentElement = dependencyObject as FrameworkContentElement;
                if (frameworkContentElement != null)
                {
                    return frameworkContentElement.Name ?? "";                
                }
    
                return "";
            }
    
            public static IEnumerable<DependencyProperty> GetLocalDependencyProperties (this DependencyObject dependencyObject)
            {
                if (dependencyObject == null)
                {
                    yield break;
                }
    
                var enumerator = dependencyObject.GetLocalValueEnumerator ();
                while (enumerator.MoveNext ())
                {
                    var current = enumerator.Current;
                    yield return current.Property;
                }
            }
    
            public static IEnumerable<DependencyProperty> GetClassDependencyProperties (this Type type)
            {
                if (type == null)
                {
                    return Array<DependencyProperty>.Empty;
                }
    
                if (!typeof(DependencyObject).IsAssignableFrom(type))
                {
                    return Array<DependencyProperty>.Empty;
                }
    
                return type
                        .GetFields (BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy)
                        .Where (fi => fi.FieldType == typeof (DependencyProperty))
                        .Select (fi => fi.GetValue (null) as DependencyProperty)
                        .Where (dp => dp != null)
                        ;
            }
    
            public static IEnumerable<DependencyProperty> GetClassDependencyProperties (this DependencyObject dependencyObject)
            {
                if (dependencyObject == null)
                {
                    return Array<DependencyProperty>.Empty;
                }
    
                return dependencyObject.GetType ().GetClassDependencyProperties ();
            }
    
            public static IEnumerable<DependencyProperty> GetDependencyProperties (this DependencyObject dependencyObject)
            {
                if (dependencyObject == null)
                {
                    return Array<DependencyProperty>.Empty;
                }
    
                return dependencyObject
                    .GetClassDependencyProperties ()
                    .Union (dependencyObject.GetLocalDependencyProperties ())
                    ;
            }
    
            public static IEnumerable<DependencyObject> GetVisualChildren (this DependencyObject dependencyObject)
            {
                if (dependencyObject == null)
                {
                    yield break;
                }
    
                var count = VisualTreeHelper.GetChildrenCount (dependencyObject);
                for (var iter = 0; iter < count; ++iter)
                {
                    yield return VisualTreeHelper.GetChild (dependencyObject, iter);
                }
            }
    
            public static IEnumerable<DependencyObject> GetLogicalChildren (this DependencyObject dependencyObject)
            {
                if (dependencyObject == null)
                {
                    return Array<DependencyObject>.Empty;    
                }
    
                return LogicalTreeHelper.GetChildren (dependencyObject).OfType<DependencyObject> ();
            }
    
            static string GetValueAsString (object obj)
            {
                var formattable = obj as IFormattable;
                if (formattable != null)
                {
                    return formattable.ToString ("", CultureInfo.InvariantCulture);
                }
    
                if (obj != null)
                {
                    return obj.ToString ();
                }
    
                return "";
            }
    
            static void GetTree_AsString_Impl (
                this DependencyObject dependencyObject, 
                XmlWriter xmlWriter,
                Func<DependencyObject, IEnumerable<DependencyObject>> childrenGetter 
                )
            {
                if (dependencyObject == null)
                {
                    return;
                }
                
                xmlWriter.WriteStartElement (dependencyObject.GetType().Name);
    
                var enumerator = dependencyObject.GetLocalValueEnumerator ();
                while (enumerator.MoveNext ())
                {
                    var current = enumerator.Current;
    
                    xmlWriter.WriteAttributeString (
                        current.Property.Name, 
                        GetValueAsString (current.Value)
                        );
                }
    
                foreach (var child in childrenGetter (dependencyObject))
                {
                    child.GetTree_AsString_Impl (xmlWriter, childrenGetter);
                }
    
                xmlWriter.WriteEndElement ();
    
            }
    
            static string GetTree_AsString (
                this DependencyObject dependencyObject,             
                Func<DependencyObject, IEnumerable<DependencyObject>> childrenGetter 
                )
            {
                var settings =  new XmlWriterSettings
                                    {
                                        Indent  = true  ,
                                    };
    
                var sb = new StringBuilder (128);
    
                using (var xmlWriter = XmlWriter.Create (sb, settings))
                {
                    xmlWriter.WriteStartDocument ();
    
                    dependencyObject.GetTree_AsString_Impl (xmlWriter, childrenGetter);
    
                    xmlWriter.WriteEndDocument ();
                }
    
                return sb.ToString ();            
            }
    
            public static string GetLogicalTree_AsString (this DependencyObject dependencyObject)
            {
                return dependencyObject.GetTree_AsString (d => d.GetLogicalChildren ());
            }
    
            public static string GetVisualTree_AsString (this DependencyObject dependencyObject)
            {
                return dependencyObject.GetTree_AsString (d => d.GetVisualChildren ());
            }
    
            public static IEnumerable<DependencyObject> GetVisualTree_BreadthFirst (this DependencyObject dependencyObject)
            {
                if (dependencyObject == null)
                {
                    yield break;
                }
    
                var queue = new Queue<DependencyObject> ();
                queue.Enqueue (dependencyObject);
    
                while (queue.Count > 0)
                {
                    var obj = queue.Dequeue ();
    
                    foreach (var child in obj.GetVisualChildren ())
                    {
                        if (child != null)
                        {
                            queue.Enqueue (child);
                            yield return child;                        
                        }
                    }                
                }
            }
    
            public static IEnumerable<DependencyObject> GetLogicalTree_BreadthFirst (this DependencyObject dependencyObject)
            {
                if (dependencyObject == null)
                {
                    yield break;
                }
    
                var queue = new Queue<DependencyObject> ();
                queue.Enqueue (dependencyObject);
    
                while (queue.Count > 0)
                {
                    var obj = queue.Dequeue ();
    
                    foreach (var child in obj.GetLogicalChildren ())
                    {
                        if (child != null)
                        {
                            queue.Enqueue (child);
                            yield return child;                        
                        }
                    }                
                }
            }
    
            public static double LimitBy (this double size, double constraint)
            {
                constraint = Math.Max (0, constraint);
    
                if (double.IsNaN (size))
                {
                    return size;
                }
    
                if (size < 0)
                {
                    return 0;
                }
    
                if (size > constraint)
                {
                    return constraint;
                }
    
                return size;
            }
    
            public static Size LimitBy (this Size size, Size constraint)
            {
                return new Size(
                    size.Width.LimitBy(constraint.Width), 
                    size.Height.LimitBy(constraint.Height)
                    );    
            }
    
            static byte HexColor (this char ch)
            {
                switch (ch)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        return (byte) (ch - '0');
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                        return (byte) (ch - 'a' + 10);
                    case 'A':
                    case 'B':
                    case 'C':
                    case 'D':
                    case 'E':
                    case 'F':
                        return (byte) (ch - 'A' + 10);
                    default:
                        return 0;
                }       
            }
    
            static byte ExpandNibble (this byte b)
            {
                var n = b & 0xF;
                return (byte) (n | (n << 4));
            }
    
            public static Color ParseColor (this string color, Color defaultTo)
            {
                if (string.IsNullOrEmpty (color))
                {
                    return defaultTo;                
                }
    
                if (color[0] != '#')
                {                   
                    return defaultTo;
                }
    
                switch (color.Length)
                {
                    default:
                        return defaultTo;
                    case 4:
                        // #FFF
                        return Color.FromRgb (
                            color[1].HexColor().ExpandNibble(),
                            color[2].HexColor().ExpandNibble(),
                            color[3].HexColor().ExpandNibble()
                            );
                    case 5:
                        // #FFFF
                        return Color.FromArgb (
                            color[1].HexColor().ExpandNibble(),
                            color[2].HexColor().ExpandNibble(),
                            color[3].HexColor().ExpandNibble(),
                            color[4].HexColor().ExpandNibble()
                            );
                    case 7:
                        // #FFFFFF
                        return Color.FromRgb (
                            (byte) ((color[1].HexColor() << 4) + color[2].HexColor()),
                            (byte) ((color[3].HexColor() << 4) + color[4].HexColor()),
                            (byte) ((color[5].HexColor() << 4) + color[6].HexColor())
                            );
                    case 9:
                        // #FFFFFFFF
                        return Color.FromArgb (
                            (byte) ((color[1].HexColor() << 4) + color[2].HexColor()),
                            (byte) ((color[3].HexColor() << 4) + color[4].HexColor()),
                            (byte) ((color[5].HexColor() << 4) + color[6].HexColor()),
                            (byte) ((color[7].HexColor() << 4) + color[8].HexColor())
                            );
                }
    
            }
    
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_AccordionPanel_DependencyProperties.cs
namespace FileInclude
{
    
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
                                       
    
    
    namespace Source.WPF
    {
        using System.Collections;
        using System.Collections.ObjectModel;
        using System.Collections.Specialized;
    
        using System.Windows;
        using System.Windows.Media;
    
        // ------------------------------------------------------------------------
        // AccordionPanel
        // ------------------------------------------------------------------------
        partial class AccordionPanel
        {
            #region Uninteresting generated code
            public static readonly DependencyProperty PreviewWidthProperty = DependencyProperty.Register (
                "PreviewWidth",
                typeof (double),
                typeof (AccordionPanel),
                new FrameworkPropertyMetadata (
                    32.0,
                    FrameworkPropertyMetadataOptions.None,
                    Changed_PreviewWidth,
                    Coerce_PreviewWidth          
                ));
    
            static void Changed_PreviewWidth (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                var instance = dependencyObject as AccordionPanel;
                if (instance != null)
                {
                    var oldValue = (double)eventArgs.OldValue;
                    var newValue = (double)eventArgs.NewValue;
    
                    instance.Changed_PreviewWidth (oldValue, newValue);
                }
            }
    
    
            static object Coerce_PreviewWidth (DependencyObject dependencyObject, object basevalue)
            {
                var instance = dependencyObject as AccordionPanel;
                if (instance == null)
                {
                    return basevalue;
                }
                var value = (double)basevalue;
    
                instance.Coerce_PreviewWidth (ref value);
    
    
                return value;
            }
    
            public static readonly DependencyProperty ActiveElementProperty = DependencyProperty.Register (
                "ActiveElement",
                typeof (UIElement),
                typeof (AccordionPanel),
                new FrameworkPropertyMetadata (
                    default (UIElement),
                    FrameworkPropertyMetadataOptions.None,
                    Changed_ActiveElement,
                    Coerce_ActiveElement          
                ));
    
            static void Changed_ActiveElement (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                var instance = dependencyObject as AccordionPanel;
                if (instance != null)
                {
                    var oldValue = (UIElement)eventArgs.OldValue;
                    var newValue = (UIElement)eventArgs.NewValue;
    
                    instance.Changed_ActiveElement (oldValue, newValue);
                }
            }
    
    
            static object Coerce_ActiveElement (DependencyObject dependencyObject, object basevalue)
            {
                var instance = dependencyObject as AccordionPanel;
                if (instance == null)
                {
                    return basevalue;
                }
                var value = (UIElement)basevalue;
    
                instance.Coerce_ActiveElement (ref value);
    
    
                return value;
            }
    
            public static readonly DependencyProperty ChildStateProperty = DependencyProperty.RegisterAttached (
                "ChildState",
                typeof (AccordionPanel.State),
                typeof (AccordionPanel),
                new FrameworkPropertyMetadata (
                    default (AccordionPanel.State),
                    FrameworkPropertyMetadataOptions.None,
                    Changed_ChildState,
                    Coerce_ChildState          
                ));
    
            static void Changed_ChildState (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                if (dependencyObject != null)
                {
                    var oldValue = (AccordionPanel.State)eventArgs.OldValue;
                    var newValue = (AccordionPanel.State)eventArgs.NewValue;
    
                    Changed_ChildState (dependencyObject, oldValue, newValue);
                }
            }
    
            static object Coerce_ChildState (DependencyObject dependencyObject, object basevalue)
            {
                if (dependencyObject == null)
                {
                    return basevalue;
                }
                var value = (AccordionPanel.State)basevalue;
    
                Coerce_ChildState (dependencyObject, ref value);
    
                return value;
            }
            public static readonly DependencyProperty AnimationClockProperty = DependencyProperty.RegisterAttached (
                "AnimationClock",
                typeof (double),
                typeof (AccordionPanel),
                new FrameworkPropertyMetadata (
                    default (double),
                    FrameworkPropertyMetadataOptions.None,
                    Changed_AnimationClock,
                    Coerce_AnimationClock          
                ));
    
            static void Changed_AnimationClock (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                if (dependencyObject != null)
                {
                    var oldValue = (double)eventArgs.OldValue;
                    var newValue = (double)eventArgs.NewValue;
    
                    Changed_AnimationClock (dependencyObject, oldValue, newValue);
                }
            }
    
            static object Coerce_AnimationClock (DependencyObject dependencyObject, object basevalue)
            {
                if (dependencyObject == null)
                {
                    return basevalue;
                }
                var value = (double)basevalue;
    
                Coerce_AnimationClock (dependencyObject, ref value);
    
                return value;
            }
            #endregion
    
            // --------------------------------------------------------------------
            // Constructor
            // --------------------------------------------------------------------
            public AccordionPanel ()
            {
                CoerceAllProperties ();
                Constructed__AccordionPanel ();
            }
            // --------------------------------------------------------------------
            partial void Constructed__AccordionPanel ();
            // --------------------------------------------------------------------
            void CoerceAllProperties ()
            {
                CoerceValue (PreviewWidthProperty);
                CoerceValue (ActiveElementProperty);
                CoerceValue (ChildStateProperty);
                CoerceValue (AnimationClockProperty);
            }
    
    
            // --------------------------------------------------------------------
            // Properties
            // --------------------------------------------------------------------
    
               
            // --------------------------------------------------------------------
            public double PreviewWidth
            {
                get
                {
                    return (double)GetValue (PreviewWidthProperty);
                }
                set
                {
                    if (PreviewWidth != value)
                    {
                        SetValue (PreviewWidthProperty, value);
                    }
                }
            }
            // --------------------------------------------------------------------
            partial void Changed_PreviewWidth (double oldValue, double newValue);
            partial void Coerce_PreviewWidth (ref double coercedValue);
            // --------------------------------------------------------------------
    
    
               
            // --------------------------------------------------------------------
            public UIElement ActiveElement
            {
                get
                {
                    return (UIElement)GetValue (ActiveElementProperty);
                }
                set
                {
                    if (ActiveElement != value)
                    {
                        SetValue (ActiveElementProperty, value);
                    }
                }
            }
            // --------------------------------------------------------------------
            partial void Changed_ActiveElement (UIElement oldValue, UIElement newValue);
            partial void Coerce_ActiveElement (ref UIElement coercedValue);
            // --------------------------------------------------------------------
    
    
               
            // --------------------------------------------------------------------
            public static AccordionPanel.State GetChildState (DependencyObject dependencyObject)
            {
                if (dependencyObject == null)
                {
                    return default (AccordionPanel.State);
                }
    
                return (AccordionPanel.State)dependencyObject.GetValue (ChildStateProperty);
            }
    
            public static void SetChildState (DependencyObject dependencyObject, AccordionPanel.State value)
            {
                if (dependencyObject != null)
                {
                    if (GetChildState (dependencyObject) != value)
                    {
                        dependencyObject.SetValue (ChildStateProperty, value);
                    }
                }
            }
    
            public static void ClearChildState (DependencyObject dependencyObject)
            {
                if (dependencyObject != null)
                {
                    dependencyObject.ClearValue (ChildStateProperty);
                }
            }
            // --------------------------------------------------------------------
            static partial void Changed_ChildState (DependencyObject dependencyObject, AccordionPanel.State oldValue, AccordionPanel.State newValue);
            static partial void Coerce_ChildState (DependencyObject dependencyObject, ref AccordionPanel.State coercedValue);
            // --------------------------------------------------------------------
    
    
               
            // --------------------------------------------------------------------
            public static double GetAnimationClock (DependencyObject dependencyObject)
            {
                if (dependencyObject == null)
                {
                    return default (double);
                }
    
                return (double)dependencyObject.GetValue (AnimationClockProperty);
            }
    
            public static void SetAnimationClock (DependencyObject dependencyObject, double value)
            {
                if (dependencyObject != null)
                {
                    if (GetAnimationClock (dependencyObject) != value)
                    {
                        dependencyObject.SetValue (AnimationClockProperty, value);
                    }
                }
            }
    
            public static void ClearAnimationClock (DependencyObject dependencyObject)
            {
                if (dependencyObject != null)
                {
                    dependencyObject.ClearValue (AnimationClockProperty);
                }
            }
            // --------------------------------------------------------------------
            static partial void Changed_AnimationClock (DependencyObject dependencyObject, double oldValue, double newValue);
            static partial void Coerce_AnimationClock (DependencyObject dependencyObject, ref double coercedValue);
            // --------------------------------------------------------------------
    
    
        }
        // ------------------------------------------------------------------------
    
    }
                                       
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_AccordionPanel_DependencyProperties.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_WatermarkTextBox_DependencyProperties.cs
namespace FileInclude
{
    
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
                                       
    
    
    namespace Source.WPF
    {
        using System.Collections;
        using System.Collections.ObjectModel;
        using System.Collections.Specialized;
    
        using System.Windows;
        using System.Windows.Media;
    
        // ------------------------------------------------------------------------
        // WatermarkTextBox
        // ------------------------------------------------------------------------
        partial class WatermarkTextBox
        {
            #region Uninteresting generated code
            public static readonly DependencyProperty WatermarkTextProperty = DependencyProperty.Register (
                "WatermarkText",
                typeof (string),
                typeof (WatermarkTextBox),
                new FrameworkPropertyMetadata (
                    default (string),
                    FrameworkPropertyMetadataOptions.None,
                    Changed_WatermarkText,
                    Coerce_WatermarkText          
                ));
    
            static void Changed_WatermarkText (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                var instance = dependencyObject as WatermarkTextBox;
                if (instance != null)
                {
                    var oldValue = (string)eventArgs.OldValue;
                    var newValue = (string)eventArgs.NewValue;
    
                    instance.Changed_WatermarkText (oldValue, newValue);
                }
            }
    
    
            static object Coerce_WatermarkText (DependencyObject dependencyObject, object basevalue)
            {
                var instance = dependencyObject as WatermarkTextBox;
                if (instance == null)
                {
                    return basevalue;
                }
                var value = (string)basevalue;
    
                instance.Coerce_WatermarkText (ref value);
    
    
                return value;
            }
    
            public static readonly DependencyProperty WatermarkForegroundProperty = DependencyProperty.Register (
                "WatermarkForeground",
                typeof (Brush),
                typeof (WatermarkTextBox),
                new FrameworkPropertyMetadata (
                    default (Brush),
                    FrameworkPropertyMetadataOptions.None,
                    Changed_WatermarkForeground,
                    Coerce_WatermarkForeground          
                ));
    
            static void Changed_WatermarkForeground (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                var instance = dependencyObject as WatermarkTextBox;
                if (instance != null)
                {
                    var oldValue = (Brush)eventArgs.OldValue;
                    var newValue = (Brush)eventArgs.NewValue;
    
                    instance.Changed_WatermarkForeground (oldValue, newValue);
                }
            }
    
    
            static object Coerce_WatermarkForeground (DependencyObject dependencyObject, object basevalue)
            {
                var instance = dependencyObject as WatermarkTextBox;
                if (instance == null)
                {
                    return basevalue;
                }
                var value = (Brush)basevalue;
    
                instance.Coerce_WatermarkForeground (ref value);
    
    
                return value;
            }
    
            static readonly DependencyPropertyKey IsWatermarkVisiblePropertyKey = DependencyProperty.RegisterReadOnly (
                "IsWatermarkVisible",
                typeof (bool),
                typeof (WatermarkTextBox),
                new FrameworkPropertyMetadata (
                    true,
                    FrameworkPropertyMetadataOptions.None,
                    Changed_IsWatermarkVisible,
                    Coerce_IsWatermarkVisible          
                ));
    
            public static readonly DependencyProperty IsWatermarkVisibleProperty = IsWatermarkVisiblePropertyKey.DependencyProperty;
    
            static void Changed_IsWatermarkVisible (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                var instance = dependencyObject as WatermarkTextBox;
                if (instance != null)
                {
                    var oldValue = (bool)eventArgs.OldValue;
                    var newValue = (bool)eventArgs.NewValue;
    
                    instance.Changed_IsWatermarkVisible (oldValue, newValue);
                }
            }
    
    
            static object Coerce_IsWatermarkVisible (DependencyObject dependencyObject, object basevalue)
            {
                var instance = dependencyObject as WatermarkTextBox;
                if (instance == null)
                {
                    return basevalue;
                }
                var value = (bool)basevalue;
    
                instance.Coerce_IsWatermarkVisible (ref value);
    
    
                return value;
            }
    
            #endregion
    
            // --------------------------------------------------------------------
            // Constructor
            // --------------------------------------------------------------------
            public WatermarkTextBox ()
            {
                CoerceAllProperties ();
                Constructed__WatermarkTextBox ();
            }
            // --------------------------------------------------------------------
            partial void Constructed__WatermarkTextBox ();
            // --------------------------------------------------------------------
            void CoerceAllProperties ()
            {
                CoerceValue (WatermarkTextProperty);
                CoerceValue (WatermarkForegroundProperty);
                CoerceValue (IsWatermarkVisibleProperty);
            }
    
    
            // --------------------------------------------------------------------
            // Properties
            // --------------------------------------------------------------------
    
               
            // --------------------------------------------------------------------
            public string WatermarkText
            {
                get
                {
                    return (string)GetValue (WatermarkTextProperty);
                }
                set
                {
                    if (WatermarkText != value)
                    {
                        SetValue (WatermarkTextProperty, value);
                    }
                }
            }
            // --------------------------------------------------------------------
            partial void Changed_WatermarkText (string oldValue, string newValue);
            partial void Coerce_WatermarkText (ref string coercedValue);
            // --------------------------------------------------------------------
    
    
               
            // --------------------------------------------------------------------
            public Brush WatermarkForeground
            {
                get
                {
                    return (Brush)GetValue (WatermarkForegroundProperty);
                }
                set
                {
                    if (WatermarkForeground != value)
                    {
                        SetValue (WatermarkForegroundProperty, value);
                    }
                }
            }
            // --------------------------------------------------------------------
            partial void Changed_WatermarkForeground (Brush oldValue, Brush newValue);
            partial void Coerce_WatermarkForeground (ref Brush coercedValue);
            // --------------------------------------------------------------------
    
    
               
            // --------------------------------------------------------------------
            public bool IsWatermarkVisible
            {
                get
                {
                    return (bool)GetValue (IsWatermarkVisibleProperty);
                }
                private set
                {
                    if (IsWatermarkVisible != value)
                    {
                        SetValue (IsWatermarkVisiblePropertyKey, value);
                    }
                }
            }
            // --------------------------------------------------------------------
            partial void Changed_IsWatermarkVisible (bool oldValue, bool newValue);
            partial void Coerce_IsWatermarkVisible (ref bool coercedValue);
            // --------------------------------------------------------------------
    
    
        }
        // ------------------------------------------------------------------------
    
    }
                                       
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_WatermarkTextBox_DependencyProperties.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_ReflectionDecorator_DependencyProperties.cs
namespace FileInclude
{
    
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
                                       
    
    
    namespace Source.WPF
    {
        using System.Collections;
        using System.Collections.ObjectModel;
        using System.Collections.Specialized;
    
        using System.Windows;
        using System.Windows.Media;
    
        // ------------------------------------------------------------------------
        // ReflectionDecorator
        // ------------------------------------------------------------------------
        partial class ReflectionDecorator
        {
            #region Uninteresting generated code
            public static readonly DependencyProperty ReflectionSizeProperty = DependencyProperty.Register (
                "ReflectionSize",
                typeof (double),
                typeof (ReflectionDecorator),
                new FrameworkPropertyMetadata (
                    48.0,
                    FrameworkPropertyMetadataOptions.None,
                    Changed_ReflectionSize,
                    Coerce_ReflectionSize          
                ));
    
            static void Changed_ReflectionSize (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                var instance = dependencyObject as ReflectionDecorator;
                if (instance != null)
                {
                    var oldValue = (double)eventArgs.OldValue;
                    var newValue = (double)eventArgs.NewValue;
    
                    instance.Changed_ReflectionSize (oldValue, newValue);
                }
            }
    
    
            static object Coerce_ReflectionSize (DependencyObject dependencyObject, object basevalue)
            {
                var instance = dependencyObject as ReflectionDecorator;
                if (instance == null)
                {
                    return basevalue;
                }
                var value = (double)basevalue;
    
                instance.Coerce_ReflectionSize (ref value);
    
    
                return value;
            }
    
            public static readonly DependencyProperty ReflectionSeparationProperty = DependencyProperty.Register (
                "ReflectionSeparation",
                typeof (double),
                typeof (ReflectionDecorator),
                new FrameworkPropertyMetadata (
                    4.0,
                    FrameworkPropertyMetadataOptions.None,
                    Changed_ReflectionSeparation,
                    Coerce_ReflectionSeparation          
                ));
    
            static void Changed_ReflectionSeparation (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                var instance = dependencyObject as ReflectionDecorator;
                if (instance != null)
                {
                    var oldValue = (double)eventArgs.OldValue;
                    var newValue = (double)eventArgs.NewValue;
    
                    instance.Changed_ReflectionSeparation (oldValue, newValue);
                }
            }
    
    
            static object Coerce_ReflectionSeparation (DependencyObject dependencyObject, object basevalue)
            {
                var instance = dependencyObject as ReflectionDecorator;
                if (instance == null)
                {
                    return basevalue;
                }
                var value = (double)basevalue;
    
                instance.Coerce_ReflectionSeparation (ref value);
    
    
                return value;
            }
    
            #endregion
    
            // --------------------------------------------------------------------
            // Constructor
            // --------------------------------------------------------------------
            public ReflectionDecorator ()
            {
                CoerceAllProperties ();
                Constructed__ReflectionDecorator ();
            }
            // --------------------------------------------------------------------
            partial void Constructed__ReflectionDecorator ();
            // --------------------------------------------------------------------
            void CoerceAllProperties ()
            {
                CoerceValue (ReflectionSizeProperty);
                CoerceValue (ReflectionSeparationProperty);
            }
    
    
            // --------------------------------------------------------------------
            // Properties
            // --------------------------------------------------------------------
    
               
            // --------------------------------------------------------------------
            public double ReflectionSize
            {
                get
                {
                    return (double)GetValue (ReflectionSizeProperty);
                }
                set
                {
                    if (ReflectionSize != value)
                    {
                        SetValue (ReflectionSizeProperty, value);
                    }
                }
            }
            // --------------------------------------------------------------------
            partial void Changed_ReflectionSize (double oldValue, double newValue);
            partial void Coerce_ReflectionSize (ref double coercedValue);
            // --------------------------------------------------------------------
    
    
               
            // --------------------------------------------------------------------
            public double ReflectionSeparation
            {
                get
                {
                    return (double)GetValue (ReflectionSeparationProperty);
                }
                set
                {
                    if (ReflectionSeparation != value)
                    {
                        SetValue (ReflectionSeparationProperty, value);
                    }
                }
            }
            // --------------------------------------------------------------------
            partial void Changed_ReflectionSeparation (double oldValue, double newValue);
            partial void Coerce_ReflectionSeparation (ref double coercedValue);
            // --------------------------------------------------------------------
    
    
        }
        // ------------------------------------------------------------------------
    
    }
                                       
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_ReflectionDecorator_DependencyProperties.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_BuzyWait_DependencyProperties.cs
namespace FileInclude
{
    
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
                                       
    
    
    namespace Source.WPF
    {
        using System.Collections;
        using System.Collections.ObjectModel;
        using System.Collections.Specialized;
    
        using System.Windows;
        using System.Windows.Media;
    
        // ------------------------------------------------------------------------
        // BuzyWait
        // ------------------------------------------------------------------------
        partial class BuzyWait
        {
            #region Uninteresting generated code
            public static readonly DependencyProperty AnimationClockProperty = DependencyProperty.RegisterAttached (
                "AnimationClock",
                typeof (double),
                typeof (BuzyWait),
                new FrameworkPropertyMetadata (
                    default (double),
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    Changed_AnimationClock,
                    Coerce_AnimationClock          
                ));
    
            static void Changed_AnimationClock (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                if (dependencyObject != null)
                {
                    var oldValue = (double)eventArgs.OldValue;
                    var newValue = (double)eventArgs.NewValue;
    
                    Changed_AnimationClock (dependencyObject, oldValue, newValue);
                }
            }
    
            static object Coerce_AnimationClock (DependencyObject dependencyObject, object basevalue)
            {
                if (dependencyObject == null)
                {
                    return basevalue;
                }
                var value = (double)basevalue;
    
                Coerce_AnimationClock (dependencyObject, ref value);
    
                return value;
            }
            public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.Register (
                "IsEnabled",
                typeof (bool),
                typeof (BuzyWait),
                new FrameworkPropertyMetadata (
                    default (bool),
                    FrameworkPropertyMetadataOptions.None,
                    Changed_IsEnabled,
                    Coerce_IsEnabled          
                ));
    
            static void Changed_IsEnabled (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                var instance = dependencyObject as BuzyWait;
                if (instance != null)
                {
                    var oldValue = (bool)eventArgs.OldValue;
                    var newValue = (bool)eventArgs.NewValue;
    
                    instance.Changed_IsEnabled (oldValue, newValue);
                }
            }
    
    
            static object Coerce_IsEnabled (DependencyObject dependencyObject, object basevalue)
            {
                var instance = dependencyObject as BuzyWait;
                if (instance == null)
                {
                    return basevalue;
                }
                var value = (bool)basevalue;
    
                instance.Coerce_IsEnabled (ref value);
    
    
                return value;
            }
    
            #endregion
    
            // --------------------------------------------------------------------
            // Constructor
            // --------------------------------------------------------------------
            public BuzyWait ()
            {
                CoerceAllProperties ();
                Constructed__BuzyWait ();
            }
            // --------------------------------------------------------------------
            partial void Constructed__BuzyWait ();
            // --------------------------------------------------------------------
            void CoerceAllProperties ()
            {
                CoerceValue (AnimationClockProperty);
                CoerceValue (IsEnabledProperty);
            }
    
    
            // --------------------------------------------------------------------
            // Properties
            // --------------------------------------------------------------------
    
               
            // --------------------------------------------------------------------
            public static double GetAnimationClock (DependencyObject dependencyObject)
            {
                if (dependencyObject == null)
                {
                    return default (double);
                }
    
                return (double)dependencyObject.GetValue (AnimationClockProperty);
            }
    
            public static void SetAnimationClock (DependencyObject dependencyObject, double value)
            {
                if (dependencyObject != null)
                {
                    if (GetAnimationClock (dependencyObject) != value)
                    {
                        dependencyObject.SetValue (AnimationClockProperty, value);
                    }
                }
            }
    
            public static void ClearAnimationClock (DependencyObject dependencyObject)
            {
                if (dependencyObject != null)
                {
                    dependencyObject.ClearValue (AnimationClockProperty);
                }
            }
            // --------------------------------------------------------------------
            static partial void Changed_AnimationClock (DependencyObject dependencyObject, double oldValue, double newValue);
            static partial void Coerce_AnimationClock (DependencyObject dependencyObject, ref double coercedValue);
            // --------------------------------------------------------------------
    
    
               
            // --------------------------------------------------------------------
            public bool IsEnabled
            {
                get
                {
                    return (bool)GetValue (IsEnabledProperty);
                }
                set
                {
                    if (IsEnabled != value)
                    {
                        SetValue (IsEnabledProperty, value);
                    }
                }
            }
            // --------------------------------------------------------------------
            partial void Changed_IsEnabled (bool oldValue, bool newValue);
            partial void Coerce_IsEnabled (ref bool coercedValue);
            // --------------------------------------------------------------------
    
    
        }
        // ------------------------------------------------------------------------
    
    }
                                       
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_BuzyWait_DependencyProperties.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\Debug\BaseDebugTreeControl.cs
namespace FileInclude
{
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
    
    
    
    
    using System.Collections.Generic;
    
    namespace Source.WPF.Debug
    {
        using System;
        using System.Collections.Concurrent;
        using System.ComponentModel;
        using System.Linq;
        using System.Globalization;
        using System.Text;
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Controls.Primitives;
        using System.Windows.Markup;
    
        using Source.Extensions;
    
        [TemplatePart (Name = PART_SelectButton     , Type = typeof (ButtonBase))   ]
        [TemplatePart (Name = PART_RefreshButton    , Type = typeof (ButtonBase))   ]
        [TemplatePart (Name = PART_SearchBox        , Type = typeof (TextBoxBase))  ]
        [TemplatePart (Name = PART_TreeView         , Type = typeof (TreeView))     ]
        [TemplatePart (Name = PART_PropertyDataGrid , Type = typeof (DataGrid))     ]
        abstract partial class BaseDebugTreeControl : DebugControl
        {
            public const string PART_SelectButton       = @"PART_SelectButton"      ;
            public const string PART_RefreshButton      = @"PART_RefreshButton"     ;
            public const string PART_SearchBox          = @"PART_SearchBox"         ;
            public const string PART_TreeView           = @"PART_TreeView"          ;
            public const string PART_PropertyDataGrid   = @"PART_PropertyDataGrid"  ;
    
            public const string DefaultStyle = @"
    <Style 
        xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
        TargetType=""{x:Type d:BaseDebugTreeControl}""
        >
        <Setter Property=""Template"">
            <Setter.Value>
                <ControlTemplate TargetType=""{x:Type d:BaseDebugTreeControl}"">
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition Height=""24""/>
                            <RowDefinition Height=""4""/>
                            <RowDefinition Height=""*""/>
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition />
                            <ColumnDefinition Width=""4""/>
                            <ColumnDefinition />
                        </Grid.ColumnDefinitions>
                        <StackPanel Grid.Row=""0"" Grid.Column=""0"" Orientation=""Horizontal"">
                            <Button x:Name=""PART_SelectButton""    Padding=""8,0,8,0"" Margin=""0,0,4,0"" Content=""Select""/>
                            <Button x:Name=""PART_RefreshButton""   Padding=""8,0,8,0"" Margin=""0,0,4,0"" Content=""Refresh""/>
                        </StackPanel>
                        <TextBox    Grid.Row=""0"" Grid.Column=""2"" x:Name=""PART_SearchBox""      />
                        <TreeView   Grid.Row=""2"" Grid.Column=""0"" x:Name=""PART_TreeView""  ItemsSource=""{TemplateBinding Tree}"">
                            <TreeView.ItemTemplate>
                                <HierarchicalDataTemplate
                                    ItemsSource=""{Binding Path=Children, Mode=OneTime}""
                                    >
                                    <TextBlock 
                                        Text=""{Binding Path=Name, Mode=OneTime}""
                                        ToolTip=""{Binding Path=ToolTip, Mode=OneTime}""
                                        />
                                </HierarchicalDataTemplate>
                            </TreeView.ItemTemplate>
                        </TreeView>
                        <GridSplitter
                            Grid.Column=""1""
                            Grid.RowSpan=""3""
                            HorizontalAlignment=""Stretch""
                            VerticalAlignment=""Stretch""
                            /> 
                        <DataGrid   
                            Grid.Row=""2"" 
                            Grid.Column=""2"" 
                            x:Name=""PART_PropertyDataGrid""   
                            ItemsSource=""{Binding ElementName=PART_TreeView,Path=SelectedValue.Properties}"" 
                            EnableColumnVirtualization=""False"" 
                            EnableRowVirtualization=""True"" 
                            AutoGenerateColumns=""False""                        
                            >
                            <DataGrid.Columns>
                                <DataGridTextColumn IsReadOnly=""True"" Header=""Name"" Binding=""{Binding Path=Name, Mode=OneTime}""/>
                                <DataGridTextColumn Header=""Value"" Binding=""{Binding Path=Value, Mode=TwoWay}""/>
                            </DataGrid.Columns>
                        </DataGrid>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    ";
            public class TreeNodeProperty : INotifyPropertyChanged
            {
                readonly DependencyObject   DependencyObject    ;
                readonly DependencyProperty DependencyProperty  ;
    
                public TreeNodeProperty(
                    DependencyObject dependencyObject, 
                    DependencyProperty dependencyProperty
                    )
                {
                    DependencyObject    = dependencyObject      ?? new DependencyObject ();
                    DependencyProperty  = dependencyProperty    ;
                }
    
                public bool IsReadOnly
                {
                    get
                    {
                        return DependencyProperty.ReadOnly;
                    }
                }
    
                public bool IsAttached
                {
                    get
                    {
                        var ownerType = DependencyProperty.OwnerType;
                        var type = DependencyObject.GetType ();
    
                        return !ownerType.IsAssignableFrom (type);
                    }
                }
    
                public bool HasValue
                {
                    get
                    {
                        return DependencyObject.ReadLocalValue (DependencyProperty) != null;
                    }
                }
    
                public string Name
                {
                    get
                    {
                        if (IsAttached)
                        {
                            return DependencyProperty.OwnerType.Name + "." + DependencyProperty.Name;                                                
                        }
                        else
                        {
                            return DependencyProperty.Name;                        
                        }
                    }
                }
    
                public object Value
                {
                    get
                    {
                        return DependencyObject.GetValue (DependencyProperty);    
                    }
                    set
                    {
                        if (IsReadOnly)
                        {
                        }
                        else 
                        {
                            value = value ?? "";
                            var converter = TypeDescriptor.GetConverter (DependencyProperty.PropertyType);
                            if (converter.CanConvertFrom(value.GetType ()))
                            {
                                var convertedValue = converter.ConvertFrom (null, CultureInfo.CurrentUICulture, value);
                                DependencyObject.SetValue (DependencyProperty, convertedValue);
                            }
                        }
                        OnPropertyChanged("Value");
                    }
                }
    
                public event PropertyChangedEventHandler PropertyChanged;
    
                protected virtual void OnPropertyChanged(string propertyName)
                {
                    var handler = PropertyChanged;
                    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public class TreeNode : INotifyPropertyChanged
            {
                readonly BaseDebugTreeControl   Owner               ;
                readonly DependencyObject       DependencyObject    ;
                string                          m_name              ;
                string                          m_tooltip           ;
                TreeNode[]                      m_children          ;
                TreeNodeProperty[]              m_properties        ;
    
                public TreeNode(BaseDebugTreeControl owner, DependencyObject dependencyObject)
                {
                    Owner = owner;
                    DependencyObject = dependencyObject ?? new DependencyObject ();
                }
    
                public string Name
                {
                    get
                    {
                        if (m_name == null)
                        {
                            m_name = BuildDescription(" ");
                        }
                        return m_name;
                    }
                }
    
                string BuildDescription(string separator)
                {
                    separator = separator ?? " ";
                    var type = DependencyObject.GetType();
    
                    var sb = new StringBuilder(128);
    
                    sb.Append(type.Name);
    
                    foreach (var dp in DependencyObject.GetLocalDependencyProperties().OrderBy(dp => dp.Name))
                    {
                        var value = DependencyObject.GetValue(dp);
                        if (value == null)
                        {
                            continue;
                        }
    
                        sb.Append(separator);
                        sb.Append(dp.Name);
                        sb.Append(@"=""");
                        sb.AppendFormat(CultureInfo.CurrentUICulture, "{0}", value);
                        sb.Append('"');
                    }
    
                    return sb.ToString ();
                }
    
                public string ToolTip
                {
                    get
                    {
                        if (m_tooltip == null)
                        {
                            m_tooltip = BuildDescription ("\r\n  ");
                        }
                        return m_tooltip;
                    }
                }
    
                public TreeNode[] Children
                {
                    get
                    {
                        if (m_children == null)
                        {
                            m_children = Owner.GetChildren (DependencyObject)
                                .Select(d => new TreeNode (Owner, d))
                                .ToArray()
                                ;
                        }
                        return m_children;
                    }
                }
    
                static readonly ConcurrentDictionary<Type, DependencyProperty[]> s_cachedProperties = new ConcurrentDictionary<Type, DependencyProperty[]> ();
    
                public TreeNodeProperty[] Properties
                {
                    get
                    {
                        if (m_properties == null)
                        {
                            var classProperties = s_cachedProperties.GetOrAdd (
                                DependencyObject.GetType(),
                                type => type.GetClassDependencyProperties().ToArray ()
                                );
    
                            var localProperties = DependencyObject.GetLocalDependencyProperties ();
    
                            m_properties = classProperties
                                .Union(localProperties)
                                .OrderBy (dp => dp.Name)
                                .Select (dp => new TreeNodeProperty (DependencyObject, dp))
                                .ToArray ()
                                ;
                        }
    
                        return m_properties;
                    }
                }
    
                public event PropertyChangedEventHandler PropertyChanged;
    
                protected virtual void OnPropertyChanged(string propertyName)
                {
                    var handler = PropertyChanged;      
                    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            protected abstract IEnumerable<DependencyObject> GetChildren(DependencyObject dependencyObject);
    
            readonly static Style           s_defaultStyle      ;
    
            static BaseDebugTreeControl ()
            {
                var parserContext = DebugContainerControl.GetParserContext();
    
                s_defaultStyle = (Style)XamlReader.Parse(
                    DefaultStyle,
                    parserContext
                    );            
    
                StyleProperty.OverrideMetadata(typeof(BaseDebugTreeControl), new FrameworkPropertyMetadata(s_defaultStyle));
            }
    
            partial void Constructed__BaseDebugTreeControl()
            {
                RoutedEventHandler buttonClick = Button_Click;
                AddHandler (ButtonBase.ClickEvent, buttonClick);
            }
    
            void Button_Click(object sender, RoutedEventArgs e)
            {
                var button = e.OriginalSource as ButtonBase;
                if (button == null)
                {
                    return;
                }
    
                switch (button.Name ?? "")
                {
                    case PART_SelectButton:
                        break;
                    case PART_RefreshButton:
                        PopulateTree ();
                        break;
                    default:
                        break;
                }
            }
    
            protected override void OnAttachTo(DependencyObject dependencyObject)
            {
                dependencyObject.Dispatcher.Async_Invoke (
                    "Delay tree population till application idle", 
                    PopulateTree
                    );
            }
    
            void PopulateTree()
            {
                Tree.Clear ();
                if (AttachedTo == null)
                {
                    return;
                }
                Tree.Add (new TreeNode (this, AttachedTo));
            }
    
            protected override void OnDetachFrom(DependencyObject dependencyObject)
            {
                Tree.Clear ();
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\Debug\BaseDebugTreeControl.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Common\Array.cs
namespace FileInclude
{
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
    
    namespace Source.Common
    {
        static class Array<T>
        {
            public static readonly T[] Empty = new T[0];
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Common\Array.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Common\Log.cs
namespace FileInclude
{
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
    
    
    
    namespace Source.Common
    {
        using System;
        using System.Globalization;
    
        static partial class Log
        {
            static partial void Partial_LogLevel (Level level);
            static partial void Partial_LogMessage (Level level, string message);
            static partial void Partial_ExceptionOnLog (Level level, string format, object[] args, Exception exc);
    
            public static void LogMessage (Level level, string format, params object[] args)
            {
                try
                {
                    Partial_LogLevel (level);
                    Partial_LogMessage (level, GetMessage (format, args));
                }
                catch (Exception exc)
                {
                    Partial_ExceptionOnLog (level, format, args, exc);
                }
                
            }
    
            static string GetMessage (string format, object[] args)
            {
                format = format ?? "";
                try
                {
                    return (args == null || args.Length == 0)
                               ? format
                               : string.Format (Config.DefaultCulture, format, args)
                        ;
                }
                catch (FormatException)
                {
    
                    return format;
                }
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Common\Log.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\Debug\Generated_BaseDebugTreeControl_DependencyProperties.cs
namespace FileInclude
{
    
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
                                       
    
    
    namespace Source.WPF.Debug
    {
        using System.Collections;
        using System.Collections.ObjectModel;
        using System.Collections.Specialized;
    
        using System.Windows;
        using System.Windows.Media;
    
        // ------------------------------------------------------------------------
        // BaseDebugTreeControl
        // ------------------------------------------------------------------------
        partial class BaseDebugTreeControl
        {
            #region Uninteresting generated code
            static readonly DependencyPropertyKey TreePropertyKey = DependencyProperty.RegisterReadOnly (
                "Tree",
                typeof (ObservableCollection<TreeNode>),
                typeof (BaseDebugTreeControl),
                new FrameworkPropertyMetadata (
                    null,
                    FrameworkPropertyMetadataOptions.None,
                    Changed_Tree,
                    Coerce_Tree          
                ));
    
            public static readonly DependencyProperty TreeProperty = TreePropertyKey.DependencyProperty;
    
            static void Changed_Tree (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                var instance = dependencyObject as BaseDebugTreeControl;
                if (instance != null)
                {
                    var oldValue = (ObservableCollection<TreeNode>)eventArgs.OldValue;
                    var newValue = (ObservableCollection<TreeNode>)eventArgs.NewValue;
    
                    if (oldValue != null)
                    {
                        oldValue.CollectionChanged -= instance.CollectionChanged_Tree;
                    }
    
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += instance.CollectionChanged_Tree;
                    }
    
                    instance.Changed_Tree (oldValue, newValue);
                }
            }
    
            void CollectionChanged_Tree(object sender, NotifyCollectionChangedEventArgs e)
            {
                CollectionChanged_Tree (
                    sender, 
                    e.Action,
                    e.OldStartingIndex,
                    e.OldItems,
                    e.NewStartingIndex,
                    e.NewItems
                    );
            }
    
            static object Coerce_Tree (DependencyObject dependencyObject, object basevalue)
            {
                var instance = dependencyObject as BaseDebugTreeControl;
                if (instance == null)
                {
                    return basevalue;
                }
                var value = (ObservableCollection<TreeNode>)basevalue;
    
                instance.Coerce_Tree (ref value);
    
                if (value == null)
                {
                   value = new ObservableCollection<TreeNode> ();
                }
    
                return value;
            }
    
            #endregion
    
            // --------------------------------------------------------------------
            // Constructor
            // --------------------------------------------------------------------
            public BaseDebugTreeControl ()
            {
                CoerceAllProperties ();
                Constructed__BaseDebugTreeControl ();
            }
            // --------------------------------------------------------------------
            partial void Constructed__BaseDebugTreeControl ();
            // --------------------------------------------------------------------
            void CoerceAllProperties ()
            {
                CoerceValue (TreeProperty);
            }
    
    
            // --------------------------------------------------------------------
            // Properties
            // --------------------------------------------------------------------
    
               
            // --------------------------------------------------------------------
            public ObservableCollection<TreeNode> Tree
            {
                get
                {
                    return (ObservableCollection<TreeNode>)GetValue (TreeProperty);
                }
                private set
                {
                    if (Tree != value)
                    {
                        SetValue (TreePropertyKey, value);
                    }
                }
            }
            // --------------------------------------------------------------------
            partial void Changed_Tree (ObservableCollection<TreeNode> oldValue, ObservableCollection<TreeNode> newValue);
            partial void Coerce_Tree (ref ObservableCollection<TreeNode> coercedValue);
            partial void CollectionChanged_Tree (object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems);
            // --------------------------------------------------------------------
    
    
        }
        // ------------------------------------------------------------------------
    
    }
                                       
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\Debug\Generated_BaseDebugTreeControl_DependencyProperties.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\Debug\DebugContainerControl.cs
namespace FileInclude
{
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
    
    
    using Source.Extensions;
    
    namespace Source.WPF.Debug
    {
        using System;
        using System.Linq;
        using System.Reflection;
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Markup;
    
        abstract partial class DebugControl : Control
        {
            protected DependencyObject AttachedTo;
    
            public int GetOrdinal ()
            {
                return OnGetOrdinal ();
            }
    
            protected abstract int OnGetOrdinal();
    
            public string GetFriendlyName ()
            {
                return OnGetFriendlyName ();    
            }
    
            protected abstract string OnGetFriendlyName();
    
            public void AttachTo (DependencyObject dependencyObject)
            {
                if (AttachedTo != null)
                {
                    DetachFrom ();
                }
    
                AttachedTo = dependencyObject;            
    
                if (AttachedTo != null)
                {
                    OnAttachTo (AttachedTo);
                }
            }
    
            protected abstract void OnAttachTo(DependencyObject attachedTo);
    
            public void DetachFrom ()
            {
                if (AttachedTo != null)
                {
                    OnDetachFrom (AttachedTo);
                }
            }
    
            protected abstract void OnDetachFrom(DependencyObject attachedTo);
        }
    
        [TemplatePart (Name=PART_Tabs, Type = typeof (TabControl))]
        partial class DebugContainerControl : Control
        {
            const string PART_Tabs  = @"PART_Tabs"  ;
    
            public const string DefaultStyle = @"
    <Style 
        xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
        TargetType=""{x:Type d:DebugContainerControl}""
        >
        <Setter Property=""Template"">
            <Setter.Value>
                <ControlTemplate TargetType=""{x:Type d:DebugContainerControl}"">
                    <TabControl x:Name=""PART_Tabs"">
                    </TabControl>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    ";
    
            static readonly Style       s_defaultStyle      ;
            static readonly TypeInfo[]  s_debugControlTypes ;
    
            readonly DebugControl[]     m_debugControls     ;
            TabControl                  m_tabControl        ;
    
            DependencyObject            m_attachedTo        ;
    
            static DebugContainerControl ()
            {
                var parserContext = GetParserContext();
    
                s_defaultStyle = (Style)XamlReader.Parse(
                    DefaultStyle,
                    parserContext
                    );
    
                var type = typeof (DebugContainerControl);
                s_debugControlTypes = type
                    .Assembly
                    .DefinedTypes
                    .Where (typeInfo => !typeInfo.IsAbstract && typeof(DebugControl).IsAssignableFrom (typeInfo))
                    .ToArray ()
                    ;
    
                StyleProperty.OverrideMetadata(typeof(DebugContainerControl), new FrameworkPropertyMetadata(s_defaultStyle));
            }
    
            public DebugContainerControl ()
            {
                m_debugControls = s_debugControlTypes
                    .Select (Activator.CreateInstance)
                    .OfType<DebugControl>()
                    .ToArray();
            }
    
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
    
                m_tabControl = GetTemplateChild (PART_Tabs) as TabControl;
                if (m_tabControl != null)
                {
                    var tabs = m_debugControls
                        .OrderBy (dc => dc.GetOrdinal ())
                        .Select (dc => 
                            new TabItem
                                {
                                    Header  = dc.GetFriendlyName()  ,
                                    Content = dc            ,
                                })
                        .ToArray ()
                        ;
                    m_tabControl.ItemsSource = tabs;
                }
            }
    
            internal static ParserContext GetParserContext()
            {
                var parserContext = new ParserContext
                                        {
                                            XamlTypeMapper = new XamlTypeMapper(new string[0])
                                        };
    
                var type = typeof (DebugContainerControl);
                var namespaceName = type.Namespace ?? "";
                var assemblyName = type.Assembly.FullName;
                parserContext.XamlTypeMapper.AddMappingProcessingInstruction("Debug", namespaceName, assemblyName);
                parserContext.XmlnsDictionary.Add("d", "Debug");
                return parserContext;
            }
    
            public static void ShowWindow (DependencyObject dependencyObject, string title = null)
            {
                if (dependencyObject == null)
                {
                    return;
                }
    
                dependencyObject.Dispatcher.Async_Invoke (
                    "Delay show window till application idle", 
                    () => ShowWindowImpl (dependencyObject, title)
                    );
    
            }
    
            static void ShowWindowImpl(DependencyObject dependencyObject, string title)
            {
                var debugContainerControl = new DebugContainerControl ();
                debugContainerControl.AttachTo (dependencyObject);
    
                var window = 
                    new Window
                        {
                            Title       = title ?? "Debug"      , 
                            MinHeight   = 200                   ,
                            MinWidth    = 320                   ,
                            Content     = debugContainerControl
                        };
    
                window.Show();
            }
    
            void AttachTo(DependencyObject dependencyObject)
            {
                foreach (var dc in m_debugControls)
                {
                    dc.DetachFrom ();
                }
    
                m_attachedTo = dependencyObject;
    
                if (m_attachedTo != null)
                {
                    foreach (var dc in m_debugControls)
                    {
                        dc.AttachTo (m_attachedTo);
                    }
                }
    
    
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\Debug\DebugContainerControl.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Common\Config.cs
namespace FileInclude
{
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
    
    
    namespace Source.Common
    {
        using System.Globalization;
    
        sealed partial class InitConfig
        {
            public CultureInfo DefaultCulture = CultureInfo.InvariantCulture;
        }
    
        static partial class Config
        {
            static partial void Partial_Constructed(ref InitConfig initConfig);
    
            public readonly static CultureInfo DefaultCulture;
    
            static Config ()
            {
                var initConfig = new InitConfig();
    
                Partial_Constructed (ref initConfig);
    
                initConfig = initConfig ?? new InitConfig();
    
                DefaultCulture = initConfig.DefaultCulture;
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Common\Config.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Common\Generated_Log.cs
namespace FileInclude
{
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
    
    
    
    namespace Source.Common
    {
        using System;
    
        partial class Log
        {
            public enum Level
            {
                Success = 1000,
                HighLight = 2000,
                Info = 3000,
                Warning = 10000,
                Error = 20000,
                Exception = 21000,
            }
    
            public static void Success (string format, params object[] args)
            {
                LogMessage (Level.Success, format, args);
            }
            public static void HighLight (string format, params object[] args)
            {
                LogMessage (Level.HighLight, format, args);
            }
            public static void Info (string format, params object[] args)
            {
                LogMessage (Level.Info, format, args);
            }
            public static void Warning (string format, params object[] args)
            {
                LogMessage (Level.Warning, format, args);
            }
            public static void Error (string format, params object[] args)
            {
                LogMessage (Level.Error, format, args);
            }
            public static void Exception (string format, params object[] args)
            {
                LogMessage (Level.Exception, format, args);
            }
    #if !NETFX_CORE && !SILVERLIGHT && !WINDOWS_PHONE
            static ConsoleColor GetLevelColor (Level level)
            {
                switch (level)
                {
                    case Level.Success:
                        return ConsoleColor.Green;
                    case Level.HighLight:
                        return ConsoleColor.White;
                    case Level.Info:
                        return ConsoleColor.Gray;
                    case Level.Warning:
                        return ConsoleColor.Yellow;
                    case Level.Error:
                        return ConsoleColor.Red;
                    case Level.Exception:
                        return ConsoleColor.Red;
                    default:
                        return ConsoleColor.Magenta;
                }
            }
    #endif
            static string GetLevelMessage (Level level)
            {
                switch (level)
                {
                    case Level.Success:
                        return "SUCCESS  ";
                    case Level.HighLight:
                        return "HIGHLIGHT";
                    case Level.Info:
                        return "INFO     ";
                    case Level.Warning:
                        return "WARNING  ";
                    case Level.Error:
                        return "ERROR    ";
                    case Level.Exception:
                        return "EXCEPTION";
                    default:
                        return "UNKNOWN  ";
                }
            }
    
        }
    }
    
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Common\Generated_Log.cs
// ############################################################################

// ############################################################################
namespace FileInclude.Include
{
    static partial class MetaData
    {
        public const string RootPath        = @"..\..\..";
        public const string IncludeDate     = @"2013-04-07T12:08:45";

        public const string Include_0       = @"C:\temp\GitHub\T4Include\WPF\AnimatedEntrance.cs";
        public const string Include_1       = @"C:\temp\GitHub\T4Include\WPF\AccordionPanel.cs";
        public const string Include_2       = @"C:\temp\GitHub\T4Include\WPF\WatermarkTextBox.cs";
        public const string Include_3       = @"C:\temp\GitHub\T4Include\WPF\ReflectionDecorator.cs";
        public const string Include_4       = @"C:\temp\GitHub\T4Include\WPF\BuzyWait.cs";
        public const string Include_5       = @"C:\temp\GitHub\T4Include\WPF\Debug\DebugVisualTreeControl.cs";
        public const string Include_6       = @"C:\temp\GitHub\T4Include\WPF\Debug\DebugLogicalTreeControl.cs";
        public const string Include_7       = @"C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_DependencyProperties.cs";
        public const string Include_8       = @"C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_StateMachine.cs";
        public const string Include_9       = @"C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs";
        public const string Include_10       = @"C:\temp\GitHub\T4Include\WPF\Generated_AccordionPanel_DependencyProperties.cs";
        public const string Include_11       = @"C:\temp\GitHub\T4Include\WPF\Generated_WatermarkTextBox_DependencyProperties.cs";
        public const string Include_12       = @"C:\temp\GitHub\T4Include\WPF\Generated_ReflectionDecorator_DependencyProperties.cs";
        public const string Include_13       = @"C:\temp\GitHub\T4Include\WPF\Generated_BuzyWait_DependencyProperties.cs";
        public const string Include_14       = @"C:\temp\GitHub\T4Include\WPF\Debug\BaseDebugTreeControl.cs";
        public const string Include_15       = @"C:\temp\GitHub\T4Include\Common\Array.cs";
        public const string Include_16       = @"C:\temp\GitHub\T4Include\Common\Log.cs";
        public const string Include_17       = @"C:\temp\GitHub\T4Include\WPF\Debug\Generated_BaseDebugTreeControl_DependencyProperties.cs";
        public const string Include_18       = @"C:\temp\GitHub\T4Include\WPF\Debug\DebugContainerControl.cs";
        public const string Include_19       = @"C:\temp\GitHub\T4Include\Common\Config.cs";
        public const string Include_20       = @"C:\temp\GitHub\T4Include\Common\Generated_Log.cs";
    }
}
// ############################################################################


