
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
            PresentingContent,
            Transitioning,
            DelayingNextTransition,
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
            public bool IsEdgeValid_PresentingContent_To_Transitioning(EdgeParam_PresentingContent_To_Transitioning p = default (EdgeParam_PresentingContent_To_Transitioning))
            {
                var result = true;

                IsEdgeValid_PresentingContent_To_Transitioning (p, ref result);

                return result;
            }


            public BaseState EdgeFrom_PresentingContent_To_Transitioning(EdgeParam_PresentingContent_To_Transitioning p = default (EdgeParam_PresentingContent_To_Transitioning))            
            {
                if (!IsEdgeValid_PresentingContent_To_Transitioning(p))
                {
                    return this;
                }

                var nextState = new State_Transitioning();

                InitializeState(nextState);

                TransformInto_Transitioning (p, nextState);

                LeaveState(nextState);
                nextState.EnterState(this);
               
                return nextState;
            }
            // ----------------------------------------------------------------- 
            partial void IsEdgeValid_PresentingContent_To_Transitioning (EdgeParam_PresentingContent_To_Transitioning p, ref bool isValid);
            partial void TransformInto_Transitioning (EdgeParam_PresentingContent_To_Transitioning p, State_Transitioning nextState);
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
            public bool IsEdgeValid_Transitioning_To_PresentingContent(EdgeParam_Transitioning_To_PresentingContent p = default (EdgeParam_Transitioning_To_PresentingContent))
            {
                var result = true;

                IsEdgeValid_Transitioning_To_PresentingContent (p, ref result);

                return result;
            }


            public BaseState EdgeFrom_Transitioning_To_PresentingContent(EdgeParam_Transitioning_To_PresentingContent p = default (EdgeParam_Transitioning_To_PresentingContent))            
            {
                if (!IsEdgeValid_Transitioning_To_PresentingContent(p))
                {
                    return this;
                }

                var nextState = new State_PresentingContent();

                InitializeState(nextState);

                TransformInto_PresentingContent (p, nextState);

                LeaveState(nextState);
                nextState.EnterState(this);
               
                return nextState;
            }
            // ----------------------------------------------------------------- 
            partial void IsEdgeValid_Transitioning_To_PresentingContent (EdgeParam_Transitioning_To_PresentingContent p, ref bool isValid);
            partial void TransformInto_PresentingContent (EdgeParam_Transitioning_To_PresentingContent p, State_PresentingContent nextState);
            // ----------------------------------------------------------------- 

            // ----------------------------------------------------------------- 
            // From:    Transitioning
            // To:      DelayingNextTransition
            // ----------------------------------------------------------------- 
            public bool IsEdgeValid_Transitioning_To_DelayingNextTransition(EdgeParam_Transitioning_To_DelayingNextTransition p = default (EdgeParam_Transitioning_To_DelayingNextTransition))
            {
                var result = true;

                IsEdgeValid_Transitioning_To_DelayingNextTransition (p, ref result);

                return result;
            }


            public BaseState EdgeFrom_Transitioning_To_DelayingNextTransition(EdgeParam_Transitioning_To_DelayingNextTransition p = default (EdgeParam_Transitioning_To_DelayingNextTransition))            
            {
                if (!IsEdgeValid_Transitioning_To_DelayingNextTransition(p))
                {
                    return this;
                }

                var nextState = new State_DelayingNextTransition();

                InitializeState(nextState);

                TransformInto_DelayingNextTransition (p, nextState);

                LeaveState(nextState);
                nextState.EnterState(this);
               
                return nextState;
            }
            // ----------------------------------------------------------------- 
            partial void IsEdgeValid_Transitioning_To_DelayingNextTransition (EdgeParam_Transitioning_To_DelayingNextTransition p, ref bool isValid);
            partial void TransformInto_DelayingNextTransition (EdgeParam_Transitioning_To_DelayingNextTransition p, State_DelayingNextTransition nextState);
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
            public bool IsEdgeValid_DelayingNextTransition_To_Transitioning(EdgeParam_DelayingNextTransition_To_Transitioning p = default (EdgeParam_DelayingNextTransition_To_Transitioning))
            {
                var result = true;

                IsEdgeValid_DelayingNextTransition_To_Transitioning (p, ref result);

                return result;
            }


            public BaseState EdgeFrom_DelayingNextTransition_To_Transitioning(EdgeParam_DelayingNextTransition_To_Transitioning p = default (EdgeParam_DelayingNextTransition_To_Transitioning))            
            {
                if (!IsEdgeValid_DelayingNextTransition_To_Transitioning(p))
                {
                    return this;
                }

                var nextState = new State_Transitioning();

                InitializeState(nextState);

                TransformInto_Transitioning (p, nextState);

                LeaveState(nextState);
                nextState.EnterState(this);
               
                return nextState;
            }
            // ----------------------------------------------------------------- 
            partial void IsEdgeValid_DelayingNextTransition_To_Transitioning (EdgeParam_DelayingNextTransition_To_Transitioning p, ref bool isValid);
            partial void TransformInto_Transitioning (EdgeParam_DelayingNextTransition_To_Transitioning p, State_Transitioning nextState);
            // ----------------------------------------------------------------- 

        }


        partial struct EdgeParam_PresentingContent_To_Transitioning
        {
        }
        partial struct EdgeParam_Transitioning_To_PresentingContent
        {
        }
        partial struct EdgeParam_Transitioning_To_DelayingNextTransition
        {
        }
        partial struct EdgeParam_DelayingNextTransition_To_Transitioning
        {
        }

        abstract partial class BaseStateVisitor
        {
            public abstract BaseState Visit_PresentingContent(State_PresentingContent state);
            public abstract BaseState Visit_Transitioning(State_Transitioning state);
            public abstract BaseState Visit_DelayingNextTransition(State_DelayingNextTransition state);
        }

        abstract partial class BaseThrowingStateVisitor : BaseStateVisitor
        {
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
            return ReferenceEquals(Interlocked.CompareExchange(ref m_currentState, nextState, expectedState),expectedState);
        }

        bool UpdateState(BaseStateVisitor visitor)
        {
            var currentState = m_currentState;
            if (visitor != null && currentState != null)
            {
                switch (currentState.CurrentState)
                {
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

                                   
