using System.Collections;

namespace TrickleCharge.StateMachine.StateInterface
{
public interface IStateMachine
{
    public IState CurrentState { get; }

    public IEnumerator Evaluate();
}
}
