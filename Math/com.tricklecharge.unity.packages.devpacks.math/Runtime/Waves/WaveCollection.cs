using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace TrickleCharge.Math.Waves
{
[Serializable]
public class WaveCollection : IList<Wave>, IWave
{
    [SerializeField] private bool m_enabled = true;
    [SerializeField] private List<Wave> m_waves;

    public bool Enabled
    {
        get => m_enabled;
        set => m_enabled = value;
    }

    /// <inheritdoc />
    public float Evaluate(float time, float position = 0)
    {
        if(! Enabled) { return 0; }

        float sum = 0;
        foreach(Wave wave in this)
        {
            sum  += wave.Evaluate(time, position);
        }

        return sum;
    }

    /// <inheritdoc />
    public IEnumerator<Wave> GetEnumerator() => m_waves.GetEnumerator();

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <inheritdoc />
    public void Add(Wave item) => m_waves.Add(item);

    /// <inheritdoc />
    public void Clear() => m_waves.Clear();

    /// <inheritdoc />
    public bool Contains(Wave item) => m_waves.Contains(item);

    /// <inheritdoc />
    public void CopyTo(Wave[] array, int arrayIndex) => m_waves.CopyTo(array, arrayIndex);

    /// <inheritdoc />
    public bool Remove(Wave item) => m_waves.Remove(item);

    /// <inheritdoc />
    public int Count => m_waves.Count;

    /// <inheritdoc />
    public bool IsReadOnly => false;

    /// <inheritdoc />
    public int IndexOf(Wave item) => m_waves.IndexOf(item);

    /// <inheritdoc />
    public void Insert(int index, Wave item) => m_waves.Insert(index, item);

    /// <inheritdoc />
    public void RemoveAt(int index) => m_waves.RemoveAt(index);

    /// <inheritdoc />
    public Wave this[int index]
    {
        get => m_waves[index];
        set => m_waves[index] = value;
    }
}
}
