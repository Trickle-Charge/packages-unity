using TrickleCharge.StateMachine.StateInterface;

using UnityEngine;

namespace TrickleCharge.StateMachine.Components.Transition
{
public abstract class StateTransition : MonoBehaviour, IStateTransition
{
    protected abstract bool ShouldTransitionCondition { get; }

#region IStateTransition implementation

    /// <inheritdoc />
    public abstract IState TargetState { get; }


    /// <inheritdoc />
    public bool ShouldTransition => isActiveAndEnabled && ShouldTransitionCondition;

#endregion
}
}
