using System;
using System.Collections.Generic;

using UnityEditor;
using UnityEditor.UIElements;

using UnityEngine;
using UnityEngine.UIElements;

namespace TrickleCharge.Math.Waves.Demo
{
[ExecuteInEditMode]
public class WickFlickerGraph : MonoBehaviour
{
    [SerializeField] private WickFlicker m_wickFlicker;

    [Space(10)]
    [SerializeField] private float m_startTime;
    [SerializeField] private float m_endTime = 2 * Mathf.PI;
    [SerializeField] private float m_resolution = 0.01f;

    [Space(10)]
    [SerializeField] private float m_timeOffset;

    [Space(5)]
    [SerializeField] private bool m_play;
    //[SerializeField] private float m_playbackSpeed = 1;

    [Curve, SerializeField]
    private AnimationCurve m_animationCurve = new();
    public AnimationCurve AnimationCurve => m_animationCurve;

    private readonly List<Keyframe> _frames = new();

    private void Update()
    {
        //if(m_play) { m_timeOffset += Time.deltaTime * m_playbackSpeed; }
        if(m_play) { m_timeOffset = Time.time; }

        m_animationCurve.keys = GetFrames().ToArray();
    }

    private List<Keyframe> GetFrames()
    {
        _frames.Clear();

        if(m_wickFlicker == null) { return _frames; }

        for(float time = m_startTime; time < m_endTime; time += m_resolution)
        {
            if(m_resolution < 0.001) { m_resolution = 1; }

            float value = m_wickFlicker.Evaluate(m_timeOffset, time);
            _frames.Add(new Keyframe(time, value));
        }

        return _frames;
    }
}

public class AnimationCurveViewer : EditorWindow
{
    private static AnimationCurveViewer s_window;

    private GameObject _mTarget;
    private WickFlickerGraph _flickerGraph;

    //private AnimationCurve DrawnAnimationCurve { get; set; } = AnimationCurve.Linear(0, 0, 10, 10);
    private AnimationCurve DrawnAnimationCurve { get; set; } = new();

    private CurveField _curveField;

    [MenuItem("Tools/Curve Viewer")]
    public static void Init()
    {
        s_window = s_window ? s_window : (AnimationCurveViewer)GetWindow(typeof(AnimationCurveViewer));
        s_window.Show();
    }

    private void CreateGUI()
    {
        _curveField = CreateCurveField(DrawnAnimationCurve);
        rootVisualElement.Add(_curveField);
    }

    private static CurveField CreateCurveField(AnimationCurve curve) => new() { value = curve, style = { flexGrow = 1 } };

    // private void OnGUI()
    // {
    //      GUILayoutOption expandHeight = GUILayout.ExpandHeight(true);
    //     //UpdateSelection();
    //     //EditorGUILayout.MinMaxSlider();
    //     //EditorGUILayout.ObjectField(new SerializedObject(_waveData);
    //
    //     //DrawnAnimationCurve = EditorGUILayout.CurveField("DrawnAnimationCurve", DrawnAnimationCurve);
    //     //EditorGUILayout.CurveField("DrawnAnimationCurve", DrawnAnimationCurve, options: GUILayout.Height(rootVisualElement.contentRect.height));
    //     //EditorGUILayout.CurveField("DrawnAnimationCurve", DrawnAnimationCurve, options: GUILayout.ExpandHeight(true));
    //     //Repaint();
    //
    //     // _curveField.value = DrawnAnimationCurve;
    //     // _curveField.MarkDirtyRepaint();
    //
    //     //EditorGUILayout.CurveField()
    //     //EditorGUI.CurveField(position, property, Color.cyan, range);
    // }

    private void Update()
    {
        _curveField.value = DrawnAnimationCurve;
        _curveField.MarkDirtyRepaint();
        //Repaint();
    }

    private void OnSelectionChange() => UpdateSelection();

    private void UpdateSelection()
    {
        _mTarget = Selection.activeGameObject;

        if(_mTarget == null) { return; }

        if(_mTarget.TryGetComponent(out _flickerGraph))
        {
            SetAnimationCurve(_flickerGraph.AnimationCurve);
            Init();
        }
    }

    public void SetAnimationCurve(AnimationCurve curve) => DrawnAnimationCurve = curve;
}

[CustomPropertyDrawer(typeof(CurveAttribute))]
public class CurveDrawer : PropertyDrawer
{
    private FloatField _floatField;
    private CurveField _curveField;

    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        if(property.propertyType != SerializedPropertyType.AnimationCurve) { return null; }

        VisualElement container = new();
        container.Add(_floatField = new FloatField("Height"));
        //_floatField.
        _curveField = CreateCurveField(property.animationCurveValue);
        _curveField.BindProperty(property);
        //_curveField.style.height = _floatField.value;
        container.Add(_curveField);

        return container;
    }

    private static CurveField CreateCurveField(AnimationCurve curve) => new() { value = curve, style = { flexGrow = 1 } };

    /// <inheritdoc />
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //_curveField.value = property.animationCurveValue;
        //_curveField.MarkDirtyRepaint();
        //property.serializedObject.Update();  //not sure if required for redraw, but MY code needs it
        //EditorApplication.update.Invoke();
        //_curveField.
    }

    ///// <inheritdoc />
    //public override bool CanCacheInspectorGUI(SerializedProperty property) => false;

    // /// <inheritdoc />
    // public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    // {
    //
    //     SerializedObject childObj = new UnityEditor.SerializedObject(property.objectReferenceValue as CurveField);
    //     SerializedProperty ite = childObj.GetIterator();
    //
    //     float totalHeight = EditorGUI.GetPropertyHeight (property, label, true) + EditorGUIUtility.standardVerticalSpacing;
    //
    //     while (ite.NextVisible(true))
    //     {
    //         totalHeight += EditorGUI.GetPropertyHeight(ite, label, true) + EditorGUIUtility.standardVerticalSpacing;
    //     }
    //
    //     return totalHeight;
    // }
}

/*
[Serializable]
public class WaveData : Object
{
    [SerializeField] private WickFlicker m_wickFlicker;

    [Space(10)]
    [SerializeField] private float m_startTime;
    [SerializeField] private float m_endTime;
    [SerializeField] private float m_resolution;

    [Space(10)]
    [SerializeField] private float m_timeOffset;

    [Space(5)]
    [SerializeField] private bool m_play;
    [SerializeField] private float m_timeStep = 1;

    [Space(10)]
    [SerializeField] private bool m_openGraph;

    [FormerlySerializedAs("_mAnimationCurve")]
    [Curve]
    [SerializeField] private AnimationCurve m_mAnimationCurve;

    public AnimationCurve AnimationCurve => m_mAnimationCurve;

    private readonly List<Keyframe> _frames = new();

    private void Update()
    {
        SetFrames();

        if(m_play) { m_timeOffset += m_timeStep; }

        if(m_openGraph)
        {
            m_openGraph = false;
        }
    }

    private void SetFrames()
    {
        _frames.Clear();

        for(float time = m_startTime; time < m_endTime; time += m_resolution)
        {
            if(Mathf.Approximately(m_resolution, 0)) { m_resolution = 1; }

            float value = m_wickFlicker.Evaluate(time + m_timeOffset);
            _frames.Add(new Keyframe(time, value));
        }

        m_mAnimationCurve.keys = _frames.ToArray();
    }
}

[CustomPropertyDrawer(typeof(CurveAttribute))]
public class CurveDrawer : PropertyDrawer
{
    private const float _heightMultiplier = 4;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        CurveAttribute curve = attribute as CurveAttribute;
        if(property.propertyType != SerializedPropertyType.AnimationCurve) { return; }

        if (curve != null && curve.Enabled)
        {
            //position.height = EditorGUIUtility.singleLineHeight;
            //position.height *= _heightMultiplier;
            Rect range = new Rect(curve.PosX, curve.PosY, curve.RangeX, curve.RangeY);
            // if(range.size.magnitude > 0)
            // {
            //     EditorGUI.CurveField(position, property, Color.cyan);
            //
            //     return;
            // }
            EditorGUI.CurveField(position, property, Color.cyan, range);

            //CurveField curr = new CurveField("Graph");
            //root curr

            //property.animationCurveValue = EditorGUI.CurveField(position, label, property.animationCurveValue);
            //property.animationCurveValue.
            
        }
    }

    /// <inheritdoc />
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * _heightMultiplier;
    }
}
*/

[AttributeUsage(AttributeTargets.Field)]
public class CurveAttribute : PropertyAttribute
{
    public readonly float PosX;
    public readonly float PosY;
    public readonly float RangeX;
    public readonly float RangeY;
    public readonly bool Enabled;
    public int X;

    public CurveAttribute(float posX = 0, float posY = 0,float rangeX = Mathf.Infinity, float rangeY = Mathf.Infinity, bool enabled = true)
    {
        PosX = posX;
        PosY = posY;
        RangeX = rangeX;
        RangeY = rangeY;
        Enabled = enabled;
    }
}

// ============================= Other things ========================

[Serializable]
public class LineRendererGraph
{
    //[SerializeField] private int m_pointCount = 100;
    [SerializeField] private float m_xOffset = 0;
    [SerializeField] private float m_yOffset = 0;
    [SerializeField] private float m_xScale = 1;
    [SerializeField] private float m_yScale = 1;
    //[SerializeField] private AnimationCurve m_graph;

    // private Queue<(float time, float value)> _dataPoints;
    // private Queue<Keyframe> _keyframes;

    //private float _startTime = -1;

    [SerializeField]
    private LineRenderer m_lineRenderer;

    //private Queue<Keyframe> _dataPoints;

    public void AddPoint(float time, float value)
    {
        if(m_lineRenderer == null) { return; }

        //if(Mathf.Approximately(_startTime, -1)) { _startTime = Time.time; }
        //float elapsedTime = time - _startTime;
        
        // TODO evaluate all points in one go?

        float x = (m_xOffset + time) * m_xScale;
        float y = (m_yOffset + value) * m_yScale;
        Vector3 position = new(x, y, 0);
        m_lineRenderer.SetPosition(m_lineRenderer.positionCount-1, position);
            //.AddKey(elapsedTime, value);

        ShiftByTime(m_lineRenderer, -x);

        //if(m_graph.keys.Length > 500) { Reset(); }
    }

    private static void ShiftByTime(LineRenderer lineRenderer, float timeDelta)
    {
        for(int index = 0; index < lineRenderer.positionCount-1; index++)
        {
            //points.MoveKey()
            //_dataPoints[index].time += timeDelta;
            Vector3 position = lineRenderer.GetPosition(index + 1);
                //position.x += position.x;
            position.x += timeDelta;
            lineRenderer.SetPosition(index, position);
        }
    }

    //private float ElapsedTime(float startTime, float currentTime) => currentTime - startTime;

    // public void Reset()
    // {
    //     m_graph.keys = Array.Empty<Keyframe>();
    //     _startTime = -1;
    // }
}

[Serializable]
public class ScrollingGraph
{
    [SerializeField] private float m_timeScale = 1f;
    [SerializeField] private AnimationCurve m_graph;

    // private Queue<(float time, float value)> _dataPoints;
    // private Queue<Keyframe> _keyframes;

    private float _startTime;

    public void AddPoint(float time, float value)
    {
        if(m_graph.keys.Length == 0) { _startTime = Time.time; }
        float elapsedTime = time - _startTime;

        m_graph.AddKey(elapsedTime, value);

        if(elapsedTime > m_timeScale)
        {
            ShiftByTime(m_graph, m_graph.keys[0].time);
            m_graph.RemoveKey(0);
        }

        if(m_graph.keys.Length > 500) { Reset(); }
    }

    private void ShiftByTime(AnimationCurve graph, float timeDelta)
    {
        for(int index = 0; index < graph.keys.Length; index++)
        {
            //graph.MoveKey()
            graph.keys[index].time += timeDelta;
        }
    }

    //private float ElapsedTime(float startTime, float currentTime) => currentTime - startTime;

    public void Reset()
    {
        m_graph.keys = Array.Empty<Keyframe>();
        _startTime = 0;
    }
}
}
