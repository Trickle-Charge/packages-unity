using System.Collections;
using System.Collections.Generic;

using TrickleCharge.StateMachine.Components.Transition;
using TrickleCharge.StateMachine.StateControl;
using TrickleCharge.StateMachine.StateInterface;

using UnityEngine;

namespace TrickleCharge.StateMachine.Components
{
public class State : MonoBehaviour, IState
{
    [SerializeField]
    private string m_stateName;

    [SerializeField]
    protected TransitionRegister<StateTransition> m_transitionRegister;

    [SerializeField]
    private State m_initialSubState;

    private StateControl.StateMachine _subStateMachine;

    private StateControl.StateMachine SubStateMachine
    {
        get
        {
            if (_subStateMachine == null && InitialState != null)
            {
                _subStateMachine = new StateControl.StateMachine(InitialState);
            }

            return _subStateMachine;
        }
    }

    private IState InitialState => m_initialSubState = m_initialSubState ? m_initialSubState : GetChildState();


    private State GetChildState()
    {
        foreach (Transform child in transform)
        {
            if(! child.TryGetComponent(out State childState)) { continue; }

            m_initialSubState = childState;
            return m_initialSubState;
        }

        return null;
    }

    private void Reset() => m_stateName = gameObject.name;

#region IState implementation

    /// <inheritdoc />
    public string Name => m_stateName;

    /// <inheritdoc />
    public IEnumerable<IStateTransition> Transitions => m_transitionRegister;

    /// <inheritdoc />
    public IState CurrentState => SubStateMachine.CurrentState;

    /// <inheritdoc />
    public IEnumerator Evaluate()
    {
        if(!isActiveAndEnabled) { yield return null; }

        Debug.Log(Name, this);

        if (SubStateMachine != null)
        {
            yield return SubStateMachine.Evaluate();
        }
        else
        {
            yield return null;
        }
    }

#endregion
}
}
