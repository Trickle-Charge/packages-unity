using System;
using System.Collections.Generic;

using TrickleCharge.Math.Waves;

using UnityEditor;
using UnityEditor.UIElements;

using UnityEngine;
using UnityEngine.UIElements;

namespace TrickleCharge.Math.Editor.Waves
{
//[CustomPropertyDrawer(typeof(IWave))]
//[CustomPropertyDrawer(typeof(Wave))]
public class WaveDrawer : PropertyDrawer
{
    //private PropertyField _waveField;
    private readonly AnimationCurve _animationCurve = new();
    //private CurveField _curveField;

    private readonly WavePreview _wavePreview = new();

    private float _startTime;
    private float _endTime = 10;
    private float _timeOffset;
    private float _resolution = 0.001f;

    // private readonly FloatField _startTimeField  = new(label:"Start Time");
    // private readonly FloatField _endTimeField    = new(label:"End Time");
    // private readonly FloatField _timeOffsetField = new(label:"Time Offset");
    // private readonly FloatField _resolutionField = new(label:"Resolution");
    //
    // private float StartTime => _startTimeField.value;
    // private float EndTime => _endTimeField.value;
    // private float TimeOffset => _timeOffsetField.value;
    // private float Resolution
    // {
    //     get
    //     {
    //         float fieldValue = _resolutionField.value;
    //         return fieldValue < _resolutionMin ? _resolutionMin : fieldValue;
    //     }
    // }
    //
    // private const float _resolutionMin = 0.0001f;

    // public override VisualElement CreatePropertyGUI(SerializedProperty property)
    // {
    //     //if(property.propertyType != SerializedPropertyType.AnimationCurve) { return null; }
    //
    //     VisualElement container = new();
    //
    //     Wave wave = (Wave) property.boxedValue;
    //
    //     _waveField = new PropertyField(property);
    //     _waveField.BindProperty(property);
    //
    //     _curveField = CreateCurveField(_animationCurve);
    //     _curveField.BindProperty(property);
    //
    //     container.Add(_waveField);
    //     container.Add(_wavePreview.StartTimeField);
    //     container.Add(_wavePreview.EndTimeField);
    //     container.Add(_wavePreview.TimeOffsetField);
    //     container.Add(_wavePreview.ResolutionField);
    //     container.Add(_curveField);
    //
    //     return container;
    // }

    private static CurveField CreateCurveField(AnimationCurve curve) => new() { value = curve, style = { flexGrow = 1 } };

    /// <inheritdoc />
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //typeof(IWave).GetMethod("Evaluate").in
        Wave wave = (Wave) property.boxedValue;
        //IWave wave = (Wave) property.objectReferenceValue;
        _animationCurve.keys = _wavePreview.GetFrames(wave).ToArray();
        
        
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        //float spacing = EditorGUIUtility.standardVerticalSpacing;
        // Rect waveRect  = new(position.x, position.y + spacing, position.width, position.height);
        // Rect startRect = new(position.x, position.y + spacing, position.width, position.height);
        // Rect endRect   = new(position.x, position.y + spacing, position.width, position.height);
        // Rect timeRect  = new(position.x, position.y + spacing, position.width, position.height);
        // Rect resRect   = new(position.x, position.y + spacing, position.width, position.height);
        // Rect curveRect = new(position.x, position.y + spacing, position.width, position.height);

        Rect waveRect  = AutoPosition(position, 1);
        Rect startRect = AutoPosition(position, 3);
        Rect endRect   = AutoPosition(position, 5);
        Rect timeRect  = AutoPosition(position, 7);
        Rect resRect   = AutoPosition(position, 9);
        Rect curveRect = AutoPosition(position, 10);

        // Draw fields - pass GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(waveRect, property, GUIContent.none);

        _startTime  = EditorGUI.FloatField(startRect, "Start Time", _startTime);
        _endTime    = EditorGUI.FloatField(endRect, "End Time", _endTime);
        _timeOffset = EditorGUI.FloatField(timeRect, "Time Offset", _timeOffset);
        _resolution = EditorGUI.FloatField(resRect, "Resolution", _resolution);

        EditorGUI.CurveField(curveRect, _animationCurve);

        //     container.Add(_waveField);
        //     container.Add(_wavePreview.StartTimeField);
        //     container.Add(_wavePreview.EndTimeField);
        //     container.Add(_wavePreview.TimeOffsetField);
        //     container.Add(_wavePreview.ResolutionField);
        //     container.Add(_curveField);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }

    private static Rect AutoPosition(Rect position, float lineNumber)
    {
        float spacing = EditorGUIUtility.singleLineHeight * lineNumber;
        return new Rect(position.x, position.y + spacing, position.width, EditorGUIUtility.singleLineHeight);
    }

    /// <inheritdoc />
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 12;
    }

    [Serializable]
    private class WavePreview
    {
        public readonly FloatField StartTimeField  = new(label:"Start Time");
        public readonly FloatField EndTimeField    = new(label:"End Time");
        public readonly FloatField TimeOffsetField = new(label:"Time Offset");
        public readonly FloatField ResolutionField = new(label:"Resolution");

        private float StartTime => StartTimeField.value;
        private float EndTime => EndTimeField.value;
        private float TimeOffset => TimeOffsetField.value;
        private float Resolution
        {
            get
            {
                float fieldValue = ResolutionField.value;
                return fieldValue < ResolutionMin ? ResolutionMin : fieldValue;
            }
        }

        // private const float _resolutionMin = 0.0001f;
        // [SerializeField] private float m_startTime;
        // [SerializeField] private float m_endTime = 1f;
        // [SerializeField] private float m_timeOffset;
        // [SerializeField] private float m_resolution = 0.01f;
        // [SerializeField] private AnimationCurve m_curve = new();
        //
        // public float StartTime => m_startTime;
        // public float EndTime => m_endTime;
        // public float TimeOffset => m_timeOffset;
        // public float Resolution
        // {
        //     get
        //     {
        //         float fieldValue = m_resolution;
        //         return fieldValue < ResolutionMin ? ResolutionMin : fieldValue;
        //     }
        // }

        // public AnimationCurve GetCurve(IWave wave)
        // {
        //     m_curve.keys = GetFrames(wave).ToArray();
        //     return m_curve;
        // }

        public const float ResolutionMin = 0.0001f;

        private readonly List<Keyframe> _frames = new();

        public List<Keyframe> GetFrames(Wave wave)
        {
            _frames.Clear();

            if(wave == null) { return _frames; }

            for(float time = StartTime; time < EndTime; time += Resolution)
            {
                float value = wave.Evaluate(TimeOffset, time);
                _frames.Add(new Keyframe(time, value));
            }

            return _frames;
        }
    }
}
}
