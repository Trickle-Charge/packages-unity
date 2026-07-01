namespace TrickleCharge.StateMachine.StateInterface
{
public interface IStateTransition
{
    public IState TargetState { get; }

    public bool ShouldTransition { get; }
}
}
