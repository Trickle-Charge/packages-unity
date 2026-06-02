using System;
using System.Collections.Generic;

using UnityEngine;

namespace TrickleCharge.Math.Waves.Demo
{
[ExecuteInEditMode]
public class WickFlicker : MonoBehaviour
{
    [SerializeField] private Wave m_wave;
    [SerializeField] private List<LightWave> m_lights;

    private void Update()
    {
        Run(Time.time);
    }

    private void Run(float time)
    {
        foreach(LightWave lightWave in m_lights)
        {
            lightWave.Run(time);
        }
    }

    public float Evaluate(float time, float position = 0)
    {
        float sum = 0;
        foreach(LightWave lightWave in m_lights)
        {
            sum += lightWave.Evaluate(time, position);
        }

        return sum;
    }

    [Serializable]
    private class LightWave
    {
        [SerializeField] private bool m_enabled = true;
        [SerializeField] private Light m_light;

        [SerializeField] private float m_brightnessOffset;
        [SerializeField] private float m_timeOffset;

        [SerializeField] private WaveCollection m_waves;

        public WaveCollection Waves => m_waves;

        public void Run(float time, float position = 0)
        {
            m_light.intensity = Evaluate(time + m_timeOffset, position) + m_brightnessOffset;
        }

        public float Evaluate(float time, float position = 0)
        {
            if(! m_enabled) { return 0; }

            float value = Waves.Evaluate(time, position);
            return value;
        }
    }
}
}
