# My Devpacks of all time

## Index

| Name                                                                                                                                  | Package                                                                                                             | Version                                                                                                                                 |
|---------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------|
| [TrickleCharge Art](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.art)                  | [com.tricklecharge.unity.art](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.art)               | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.art?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443)        |
| [TrickleCharge DevArt](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.art.devart)        | [com.tricklecharge.unity.art.devart](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.art.devart) | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.art.devart?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443) |
| [TrickleCharge Attributes](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.attributes)    | [com.tricklecharge.unity.attributes](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.attributes) | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.attributes?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443) |
| [TrickleCharge Drones](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.drone)             | [com.tricklecharge.unity.drone](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.drone)           | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.drone?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443)      |
| [TrickleCharge Math](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.math)                | [com.tricklecharge.unity.math](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.math)             | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.math?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443)       |
| [TrickleCharge Physics](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.physics)          | [com.tricklecharge.unity.physics](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.physics)       | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.physics?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443)    |
| [TrickleCharge Vehicle Systems](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.vehicles) | [com.tricklecharge.unity.vehicles](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.vehicles)     | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.vehicles?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443)   |

---

## Usage

These packages are hosted on a private npm registry.

To use them, you need to add the TrickleCharge Registry to your Unity project's `manifest.json` file
or via the Unity project settings:
<br>
<code>
**Project Settings** → **Package Manager** → **Scoped Registries**.
</code>

> ### Scoped registry details:
> 
> - Name: `TrickleCharge Registry`
> - URL: [https://npm.tricklecharge.dev/](https://npm.tricklecharge.dev/)
> - Scope: `com.tricklecharge`

---

### Example `manifest.json`

```
{
    "dependencies": {
        "com.tricklecharge.unity.art": "0.0.1",
        "com.tricklecharge.unity.art.devart": "0.0.5",
        "com.tricklecharge.unity.attributes": "0.0.1",
        "com.tricklecharge.unity.drone": "0.0.2",
        "com.tricklecharge.unity.math": "0.0.2",
        "com.tricklecharge.unity.physics": "0.0.2",
        "com.tricklecharge.unity.vehicles": "0.0.1",
    },
    "scopedRegistries": [
    {
      "name": "TrickleCharge Registry",
      "url": "https://npm.tricklecharge.dev/",
      "scopes": [
        "com.tricklecharge.unity"
      ]
    }
  ]
}
```

### Add as local packages

You can also clone the repo and add the packages directly:

```
{
    "dependencies": {
        "com.tricklecharge.unity.art": "file:S:/Dev/Unity/Devpacks/Packages/com.tricklecharge.unity.art",
        "com.tricklecharge.unity.art.devart": "file:S:/Dev/Unity/Devpacks/Packages/com.tricklecharge.unity.art.devart",
        "com.tricklecharge.unity.attributes": "file:S:/Dev/Unity/Devpacks/Packages/com.tricklecharge.unity.attributes",
        "com.tricklecharge.unity.drone": "file:S:/Dev/Unity/Devpacks/Packages/com.tricklecharge.unity.drone",
        "com.tricklecharge.unity.math": "file:S:/Dev/Unity/Devpacks/Packages/com.tricklecharge.unity.math",
        "com.tricklecharge.unity.physics": "file:S:/Dev/Unity/Devpacks/Packages/com.tricklecharge.unity.physics",
        "com.tricklecharge.unity.vehicles": "file:S:/Dev/Unity/Devpacks/Packages/com.tricklecharge.unity.vehicles"
    }
}
```
---
