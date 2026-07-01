using TrickleCharge.StateMachine.StateInterface;

using UnityEngine;

namespace TrickleCharge.StateMachine.Components.Transition
{
public abstract class SingleStateTransition : StateTransition
{
    [SerializeField]
    private State m_targetState;

    [SerializeField]
    private bool m_shouldTransition;

    /// <inheritdoc />
    public override IState TargetState => m_targetState;

    /// <inheritdoc />
    protected override bool ShouldTransitionCondition => m_shouldTransition;
}
}
