using System;
using System.Threading;

using TMPro;

using TrickleCharge.DingOS.Core;

using UnityEngine;
using UnityEngine.UI;

namespace TrickleCharge.DingOS.Unity
{
[Serializable]
public class UnityTerminal : ITerminal
{
    [SerializeField]
    private TMP_Text m_outputText;

    [SerializeField]
    private ScrollRect m_scrollRect;

    // [SerializeField]
    // private Color m_errorColor;

    private SynchronizationContext _mainThreadContext;
    private int _mainThreadId;

    private void Awake()
    {
        _mainThreadContext = SynchronizationContext.Current;
        _mainThreadId = Thread.CurrentThread.ManagedThreadId;
    }

    private void WriteInternal(string text)
    {
        m_outputText.text += text;
        Canvas.ForceUpdateCanvases();
        m_scrollRect.verticalNormalizedPosition = 0f;
    }

    public void Write(string text)
    {
        if (Thread.CurrentThread.ManagedThreadId == _mainThreadId)
        {
            WriteInternal(text);
        }
        else
        {
            _mainThreadContext?.Post(_ => WriteInternal(text), null);
        }
    }

    public void WriteLine(string text) => Write(text + "\n");

    public void WriteError(string text) => Write($"<color=#FF5555>{text}</color>");

    public void WriteErrorLine(string text) => WriteLine($"<color=#FF5555>{text}</color>");

    public void Clear() => m_outputText.text = string.Empty;

    // Not used in Unity (Push-based via UI)
    public string ReadLine() => throw new NotSupportedException("Unity uses event-driven input via TMP_InputField.");
}
}