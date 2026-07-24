using System;

using TMPro;

using TrickleCharge.DingOS.Shell;
using TrickleCharge.DingOS.Terminal;
using TrickleCharge.DingOS.Unity.Networking;

using UnityEngine;

namespace TrickleCharge.DingOS.Unity
{
[Serializable]
public class UnityShellController : MonoBehaviour
{
    [SerializeField]
    private string m_rootContextName = "Root";

    [SerializeField]
    private string m_promptFormat = "DingOS>";

    [SerializeField]
    private UnityTerminal m_terminal;

    [SerializeField]
    private TMP_InputField m_inputField;

    [SerializeField]
    private UnityModule[] m_commandModules;

    private TerminalHost _host;

    private void Awake()
    {
        ShellContextManager contextStack = new(m_terminal);

        CommandShell shell = new CommandShell().WithInteractiveDefaults()
            .WithModule(new NetworkModule(contextStack, new TerminalDirectory()));

        foreach(UnityModule commandModule in m_commandModules) { shell.RegisterModule(commandModule); }

        ShellContext rootContext = new(m_rootContextName, m_promptFormat, shell);
        contextStack.PushContext(rootContext);

        _host = new TerminalHost(m_terminal, contextStack);
        m_inputField.onSubmit.AddListener(OnSubmit);

        m_terminal.WriteLine($"Welcome to {Core.SystemInfo.VersionString}");
        m_terminal.WriteLine("Type 'help' for available commands or 'exit' to quit.\n");
    }

    private async void OnSubmit(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) { return; }

        // Render prompt and user input line
        m_terminal.WriteLine($"<color=#FFFFFF>{_host.ContextStack.ActivePrompt}</color> {input}");
        m_terminal.WriteLine("</color>");
        m_inputField.text = string.Empty;

        // Push input through the unified Host!
        await _host.ExecuteAsync(input, destroyCancellationToken);

        m_inputField.ActivateInputField();
        m_terminal.WriteLine("");
    }

    private void OnDestroy() => _host?.Dispose();
}
}
