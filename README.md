# My Devpacks of all time

## Index

| Name                          | Package                                                                                                                  | Version |
|-------------------------------|--------------------------------------------------------------------------------------------------------------------------|---------|
| TrickleCharge Art             | [com.tricklecharge.unity.art](https://npm.tricklecharge.dev:8443/-/web/detail/com.tricklecharge.unity.art)               | 0.0.1   |
| TrickleCharge DevArt          | [com.tricklecharge.unity.art.devart](https://npm.tricklecharge.dev:8443/-/web/detail/com.tricklecharge.unity.art.devart) | 0.0.5   |
| TrickleCharge Attributes      | [com.tricklecharge.unity.attributes](https://npm.tricklecharge.dev:8443/-/web/detail/com.tricklecharge.unity.attributes) | 0.0.1   |
| TrickleCharge Drones          | [com.tricklecharge.unity.drone](https://npm.tricklecharge.dev:8443/-/web/detail/com.tricklecharge.unity.drone)           | 0.0.2   |
| TrickleCharge Math            | [com.tricklecharge.unity.math](https://npm.tricklecharge.dev:8443/-/web/detail/com.tricklecharge.unity.math)             | 0.0.2   |
| TrickleCharge Physics         | [com.tricklecharge.unity.physics](https://npm.tricklecharge.dev:8443/-/web/detail/com.tricklecharge.unity.physics)       | 0.0.2   |
| TrickleCharge Vehicle Systems | [com.tricklecharge.unity.vehicles](https://npm.tricklecharge.dev:8443/-/web/detail/com.tricklecharge.unity.vehicles)     | 0.0.1   |

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
> - URL: [https://npm.tricklecharge.dev:8443/](https://npm.tricklecharge.dev:8443/)
> - Scope: `com.tricklecharge`

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
      "url": "https://npm.tricklecharge.dev:8443/",
      "scopes": [
        "com.tricklecharge"
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
