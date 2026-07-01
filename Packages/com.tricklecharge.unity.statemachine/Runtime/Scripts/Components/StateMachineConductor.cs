using System.Collections;

using TrickleCharge.StateMachine.StateInterface;

using UnityEngine;

namespace TrickleCharge.StateMachine.Components
{
public class StateMachineConductor : MonoBehaviour, IStateMachine
{
    [SerializeField]
    private State m_initialState;

    private StateControl.StateMachine _stateMachine;

    private StateControl.StateMachine StateMachine => _stateMachine ??= new StateControl.StateMachine(m_initialState);

    private Coroutine _coroutine;

    private void OnEnable() => StartStateMachine();
    private void OnDisable() => StopStateMachine();

    private void StartStateMachine()
    {
        StopStateMachine();
        _coroutine = StartCoroutine(Evaluate());
    }

    private void StopStateMachine()
    {
        if(_coroutine == null) { return; }

        StopCoroutine(_coroutine);
        _coroutine = null;
    }

#region IStateMachine implementation

    /// <inheritdoc />
    public IState CurrentState => StateMachine.CurrentState;

    public IEnumerator Evaluate() => StateMachine.Evaluate();

#endregion
}
}
