using System.Collections;

namespace TrickleCharge.StateMachine.TransitionControl
{
public abstract class TransitionCondition : IEnumerator
{
    /// <inheritdoc />
    public abstract bool MoveNext();

    /// <inheritdoc />
    public abstract void Reset();

    /// <inheritdoc />
    public abstract object Current { get; }
}
}
