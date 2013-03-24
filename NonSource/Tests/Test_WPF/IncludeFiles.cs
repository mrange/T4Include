
// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # text template file (.tt)                                                      #
// ############################################################################



// ############################################################################
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\AnimatedEntrance.cs
// @@@ INCLUDE_FOUND: Generated_AnimatedEntrance_DependencyProperties.cs
// @@@ INCLUDE_FOUND: Generated_AnimatedEntrance_StateMachine.cs
// @@@ INCLUDE_FOUND: ../Extensions/WpfExtensions.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_DependencyProperties.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_StateMachine.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs
// @@@ INCLUDE_FOUND: ../Common/Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ INCLUDE_FOUND: Config.cs
// @@@ INCLUDE_FOUND: Generated_Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Config.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Generated_Log.cs
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
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PossibleUnintendedReferenceComparison
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCaseLabel
// ReSharper disable RedundantCast
// ReSharper disable RedundantUsingDirective
// ReSharper disable UnassignedField.Local
// ReSharper disable UnusedMember.Local
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
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\AnimatedEntrance.cs
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
                var oldValue = (ObservableCollection<UIElement>)basevalue;
                var newValue = oldValue;
    
                instance.Coerce_Children (oldValue, ref newValue);
    
                if (newValue == null)
                {
                   newValue = new ObservableCollection<UIElement> ();
                }
    
                return newValue;
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
                var oldValue = (double)basevalue;
                var newValue = oldValue;
    
                Coerce_AnimationClock (dependencyObject, oldValue, ref newValue);
    
                return newValue;
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
            partial void Coerce_Children (ObservableCollection<UIElement> value, ref ObservableCollection<UIElement> coercedValue);
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
            static partial void Coerce_AnimationClock (DependencyObject dependencyObject, double value, ref double coercedValue);
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
    
            public static double Interpolate (this double t, double from, double to)
            {
                return t*(to - from) + from;
            }
            
            public static Vector Interpolate (this double t, Vector from, Vector to)
            {
                return new Vector (
                    t*(to.X - from.X) + from.X,
                    t*(to.Y - from.Y) + from.Y
                    );
            }
        
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs
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
        public const string IncludeDate     = @"2013-03-24T10:33:10";

        public const string Include_0       = @"C:\temp\GitHub\T4Include\WPF\AnimatedEntrance.cs";
        public const string Include_1       = @"C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_DependencyProperties.cs";
        public const string Include_2       = @"C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_StateMachine.cs";
        public const string Include_3       = @"C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs";
        public const string Include_4       = @"C:\temp\GitHub\T4Include\Common\Log.cs";
        public const string Include_5       = @"C:\temp\GitHub\T4Include\Common\Config.cs";
        public const string Include_6       = @"C:\temp\GitHub\T4Include\Common\Generated_Log.cs";
    }
}
// ############################################################################


