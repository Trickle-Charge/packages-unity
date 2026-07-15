using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using TrickleCharge.Math.Waves;

using UnityEditor;
using UnityEngine;

namespace TrickleCharge.Math.Editor.Waves
{
    public static class WavePreviewRenderer
    {
        // Combined height: 18px (Slider) + 2px (Spacing) + 55px (Graph)
        public const float GraphHeight = 75f;

        private const int _sampleCount = 45;
        private const float _sampleRangeX = 10f;

        // Tracks independent scrub times per serialized property path field
        private static readonly Dictionary<string, float> s_scrubTimes = new();

        public static void Draw(Rect position, SerializedProperty property)
        {
            IWave wave = GetWaveInstance(property);
            if (wave == null) { return; }

            string pathKey = property.propertyPath;
            float currentTime = s_scrubTimes.GetValueOrDefault(pathKey, 0f);

            // Slice out layout rectangles lineally
            float sliderHeight = EditorGUIUtility.singleLineHeight;
            Rect sliderRect = new(position.x, position.y, position.width, sliderHeight);
            Rect curveRect = new(position.x, position.y + sliderHeight + EditorGUIUtility.standardVerticalSpacing, position.width, 55f);

            // 1. Draw interactive scrub slider
            Rect indentedSliderRect = EditorGUI.IndentedRect(sliderRect);
            s_scrubTimes[pathKey] = EditorGUI.Slider(indentedSliderRect, "Scrub Time", currentTime, 0f, 20f);

            // 2. Sample wave graph at the chosen scrub time
            AnimationCurve transientCurve = GenerateSampledCurve(wave, s_scrubTimes[pathKey]);

            // 3. Draw read-only visualizer graph
            EditorGUI.BeginDisabledGroup(true);
            Rect indentedCurveRect = EditorGUI.IndentedRect(curveRect);
            EditorGUI.CurveField(indentedCurveRect, "Shape Preview", transientCurve);
            EditorGUI.EndDisabledGroup();
        }

        private static AnimationCurve GenerateSampledCurve(IWave wave, float time)
        {
            AnimationCurve curve = new();
            float stepSize = _sampleRangeX / _sampleCount;

            for (int i = 0; i <= _sampleCount; i++)
            {
                float x = i * stepSize;
                float y = wave.Evaluate(time, x);
                curve.AddKey(x, y);
            }

            return curve;
        }

        private static IWave GetWaveInstance(SerializedProperty property)
        {
            if (property.propertyType == SerializedPropertyType.ManagedReference)
            {
                return property.managedReferenceValue as IWave;
            }

            object targetObject = property.serializedObject.targetObject;
            if (targetObject == null) { return null; }

            return GetFieldValueFromPath(targetObject, property.propertyPath) as IWave;
        }

        private static object GetFieldValueFromPath(object obj, string path)
        {
            string[] fields = path.Replace(".Array.data[", "[").Split('.');
            object currentObj = obj;

            foreach (string field in fields)
            {
                if (currentObj == null) { return null; }

                if (field.Contains("["))
                {
                    string fieldName = field.Substring(0, field.IndexOf('['));
                    int index = int.Parse(field.Substring(field.IndexOf('[') + 1).Replace("]", ""));

                    currentObj = GetFieldValue(currentObj, fieldName);
                    currentObj = GetElementAt(currentObj, index);
                    continue;
                }

                currentObj = GetFieldValue(currentObj, field);
            }

            return currentObj;
        }

        private static object GetFieldValue(object obj, string fieldName)
        {
            Type type = obj.GetType();
            FieldInfo field = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            while (field == null && type.BaseType != null)
            {
                type = type.BaseType;
                field = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            }

            return field?.GetValue(obj);
        }

        private static object GetElementAt(object obj, int index)
        {
            if (obj is IList list && index >= 0 && index < list.Count)
            {
                return list[index];
            }
            return null;
        }
    }
}