namespace TrickleCharge.StateMachine.TransitionControl
{
public delegate void TransitionPredicate(bool shouldTransition);

public interface ITransitionCondition
{
    public bool ShouldTransition { get; }
}
}
