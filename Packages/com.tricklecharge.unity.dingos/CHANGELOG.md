# Changelog

## [0.0.2] - 2026-11-25

### Added
- `TerminalComponent`: a working runtime (in-game) terminal. It wires a `CanvasTMPTerminalView` and a `TMP_InputField` to a DingOS shell through `UnityShellController` + `TerminalHost`, the same way the editor DingOS Console does. Exposes `Submit(string)` so gameplay code can drive the terminal.
- `UnityShellController.Initialize` now accepts command modules to register on the root shell, plus an `IsInitialized` flag.
- Declared the `com.unity.ugui` dependency (needed for TextMeshPro).

### Fixed
- `Terminal.prefab` still attached `UnityTerminal` and `UnityShellController` as components. They became plain classes in the view refactor, so import logged "missing ExtensionOfNativeClass" errors and the runtime terminal did nothing. The prefab now uses `CanvasTMPTerminalView` + `TerminalComponent`, with its `GameObjectModule` registered.
- `GameObjectModule`'s `active` command no longer throws when no target is assigned; it defaults to its own GameObject.
- Placeholder text on the output label is cleared when the terminal starts.
- Enabled the nullable context in `LoggingModule` (CS8632 warnings).
- Re-serialized `Terminal.uss.meta` / `Terminal.uxml.meta`, which were below the minimum supported meta version.

### Changed
- Bundled `TrickleCharge.DingOS.dll` updated to the current DingOS build (Core / Shell / Terminal / Modules namespaces).

### Notes
- Scenes that already contain a Terminal prefab instance keep a stale override for the removed `UnityShellController` component; Unity ignores it. Re-saving the scene clears it.

## [0.0.1] - 2026-07-24
- Creation.
