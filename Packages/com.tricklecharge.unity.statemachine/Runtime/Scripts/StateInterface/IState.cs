using System.Collections.Generic;

namespace TrickleCharge.StateMachine.StateInterface
{
public interface IState : IStateMachine
{
    public string Name { get; }

    public IEnumerable<IStateTransition> Transitions { get; }
}
}
