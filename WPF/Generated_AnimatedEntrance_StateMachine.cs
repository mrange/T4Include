using System.Windows;


// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################






// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable InconsistentNaming
// ReSharper disable InvocationIsSkipped
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable MemberCanBeProtected.Local
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable UnusedMember.Local

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

                                   
