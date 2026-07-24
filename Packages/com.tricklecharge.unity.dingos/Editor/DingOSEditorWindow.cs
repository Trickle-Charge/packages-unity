using System;
using System.Threading;
using System.Threading.Tasks;

using TrickleCharge.DingOS.Shell;
using TrickleCharge.DingOS.Terminal;
using TrickleCharge.DingOS.Unity.Editor.Views;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace TrickleCharge.DingOS.Unity.Editor
{
    public class DingOSEditorWindow : EditorWindow
    {
        private UIToolkitTerminalView _terminalView;
        private UnityTerminal _terminal;
        private ShellContextManager _contextStack;
        private CommandShell _shell;
        private TerminalHost _terminalHost;

        private TextField _inputField;
        private CancellationTokenSource _cancellationTokenSource;

        [MenuItem("Tools/DingOS Console")]
        public static void OpenWindow()
        {
            GetWindow<DingOSEditorWindow>("DingOS Console");
        }

        public void CreateGUI()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            VisualElement root = rootVisualElement;
            root.style.flexDirection = FlexDirection.Column;

            // 1. Build UI layout
            ScrollView scrollView = new()
            {
                name = "terminal-scroll",
                style = { flexGrow = 1 }
            };

            Label outputLabel = new()
            {
                name = "terminal-output",
                style = { whiteSpace = WhiteSpace.Normal }
            };
            scrollView.Add(outputLabel);

            _inputField = new TextField
            {
                name = "terminal-input"
            };

            root.Add(scrollView);
            root.Add(_inputField);

            // // Load UXML asset in EditorWindow
            // VisualTreeAsset uxml = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Packages/com.tricklecharge.unity.dingos/Editor/Views/Terminal.uxml");
            // uxml.CloneTree(root);
            //
            // // UIToolkitTerminalView automatically hooks up to the cloned UXML tree
            // _terminalView = new UIToolkitTerminalView(root);

            // 2. Initialize Terminal I/O & Adapter View
            _terminalView = new UIToolkitTerminalView(root);
            _terminal = new UnityTerminal(_terminalView);

            // 3. Setup Shell Context & Context Stack
            _contextStack = new ShellContextManager(_terminal);
            _shell = new CommandShell().WithInteractiveDefaults();

            ShellContext rootContext = new("Editor", "DingOS> ", _shell);
            _contextStack.PushContext(rootContext);

            // 4. Initialize TerminalHost (owns stdout/stderr bindings to _terminal)
            _terminalHost = new TerminalHost(_terminal, _contextStack);

            // 5. Sync active prompt & bind input handler
            UpdateInputPrompt();
            _inputField.RegisterCallback<KeyDownEvent>(OnInputKeyDown);
        }

        private void OnDisable()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _terminalHost?.Dispose();
        }

        private void OnInputKeyDown(KeyDownEvent evt)
        {
            if (evt.keyCode is not (KeyCode.Return or KeyCode.KeypadEnter)) { return; }

            string input = _inputField.value;
            if (string.IsNullOrWhiteSpace(input)) { return; }

            // Clear input box
            _inputField.value = string.Empty;

            // Echo input line with the active prompt before execution
            string prompt = _terminalHost.ContextStack.ActivePrompt;
            _terminal.WriteLine($"{prompt}{input}");

            evt.StopPropagation();

            _ = ExecuteCommandAsync(input);
        }

        private async Task ExecuteCommandAsync(string input)
        {
            try
            {
                await _terminalHost.ExecuteAsync(input, _cancellationTokenSource?.Token ?? CancellationToken.None);

                // Prompt may change if context changed (e.g., net connect / exit)
                UpdateInputPrompt();
            }
            catch (OperationCanceledException)
            {
                // Graceful cancellation on disable
            }
            catch (Exception ex)
            {
                _terminal.WriteErrorLine($"[Error] {ex.Message}");
            }
        }

        private void UpdateInputPrompt()
        {
            if (_inputField != null && _terminalHost != null)
            {
                _inputField.label = _terminalHost.ContextStack.ActivePrompt;
            }
        }
    }
}