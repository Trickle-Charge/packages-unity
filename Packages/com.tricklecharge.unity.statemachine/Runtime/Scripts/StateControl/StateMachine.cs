using System.Collections;

using JetBrains.Annotations;

using TrickleCharge.StateMachine.StateInterface;

namespace TrickleCharge.StateMachine.StateControl
{
public class StateMachine : IStateMachine
{
    private IState InitialState { get; }

    /// <inheritdoc />
    public IState CurrentState { get; private set; }

    public StateMachine([NotNull] IState initialState) => CurrentState = InitialState = initialState;

    /// <inheritdoc />
    public IEnumerator Evaluate()
    {
        CurrentState ??= InitialState;

        while(CurrentState != null)
        {
            yield return CurrentState.Evaluate();

            foreach(IStateTransition transition in CurrentState.Transitions)
            {
                if(! transition.ShouldTransition) { continue; }

                ExecuteTransition(transition);

                break;
            }
        }
    }

    public void Reset() => CurrentState = InitialState;

    public void ExecuteTransition(IStateTransition transition) => CurrentState = transition.TargetState;
}
}
