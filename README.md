# My Devpacks of all time

## Index

| Name       | Package Name                       | Git URL                                                                                         |
|------------|------------------------------------|-------------------------------------------------------------------------------------------------|
| Art        | com.tricklecharge.unity.art        | https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.art        |
| Dev Art    | com.tricklecharge.unity.art.devart | https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.art.devart |
| Attributes | com.tricklecharge.unity.attributes | https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.attributes |
| Drone      | com.tricklecharge.unity.drone      | https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.drone      |
| Math       | com.tricklecharge.unity.math       | https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.math       |
| Physics    | com.tricklecharge.unity.physics    | https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.physics    |
| Vehicles   | com.tricklecharge.unity.vehicles   | https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.vehicles   |

## Usage

Unity seems to be a bit uncooperative with Github packages.

I'm working on setting up a proper package registry.

### Example `manifest.json`

#### Github packages

```
{
    "dependencies": {
        "com.tricklecharge.unity.art": "https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.art",
        "com.tricklecharge.unity.art.devart": "https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.art.devart",
        "com.tricklecharge.unity.attributes": "https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.attributes",
        "com.tricklecharge.unity.drone": "https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.drone",
        "com.tricklecharge.unity.math": "https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.math",
        "com.tricklecharge.unity.physics": "https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.physics",
        "com.tricklecharge.unity.vehicles": "https://github.com/pog7776/Unity-Devpacks.git?path=/Packages/com.tricklecharge.unity.vehicles"
    }
}
```

#### Scoped Registry Example

```
"scopedRegistries": [
    {
        "name": "Github Packages",
        "url": "https://npm.pkg.github.com/@pog7776/",
        "scopes": [
            "com.tricklecharge.unity"
        ]
    }
]
```

> **Note**
>
> `scopedRegistries` doesn't really seem to work for github.
>
> - https://discussions.unity.com/t/using-github-packages-registry-with-unity-package-manager/784073
> - https://discussions.unity.com/t/npm-registry-authentication/778442
> - https://docs.unity3d.com/6000.1/Documentation/Manual/upm-scoped-host.html
> - https://docs.unity3d.com/6000.1/Documentation/Manual/cus-share.html
> - https://docs.unity3d.com/6000.1/Documentation/Manual/upm-git.html
>
> Using "@" notation in url to force it as Unity does not support "@" notation in the scope.
>
> Github also does not provide a package search API.

#### Local packages

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
