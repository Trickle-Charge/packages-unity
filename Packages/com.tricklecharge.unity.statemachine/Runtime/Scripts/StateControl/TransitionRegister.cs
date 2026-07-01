using System;
using System.Collections;
using System.Collections.Generic;

using TrickleCharge.StateMachine.StateInterface;

using UnityEngine;

namespace TrickleCharge.StateMachine.StateControl
{
[Serializable]
public class TransitionRegister<T> : ICollection<T> where T : IStateTransition
{
    [SerializeField]
    private List<T> m_transitions = new();

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator() => m_transitions.GetEnumerator();

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)m_transitions).GetEnumerator();

    /// <inheritdoc />
    public void Add(T item) => m_transitions.Add(item);

    /// <inheritdoc />
    public void Clear() => m_transitions.Clear();

    /// <inheritdoc />
    public bool Contains(T item) => m_transitions.Contains(item);

    /// <inheritdoc />
    public void CopyTo(T[] array, int arrayIndex) => m_transitions.CopyTo(array, arrayIndex);

    /// <inheritdoc />
    public bool Remove(T item) => m_transitions.Remove(item);

    /// <inheritdoc />
    public int Count => m_transitions.Count;

    /// <inheritdoc />
    public bool IsReadOnly => false;
}
}
