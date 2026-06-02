# My Devpacks of all time

## Index

| Name       | Namespace                                   | Git URL                                                                                                    |
|------------|---------------------------------------------|------------------------------------------------------------------------------------------------------------|
| Dev Art    | com.tricklecharge.unity.packages.devpacks.art.devart | https://github.com/pog7776/Unity-Devpacks.git?path=/Art/DevArt/com.tricklecharge.unity.packages.devpacks.art.devart |
| Attributes | com.tricklecharge.unity.packages.devpacks.attributes | https://github.com/pog7776/Unity-Devpacks.git?path=/Attributes/com.tricklecharge.unity.packages.devpacks.attributes |
| Drone      | com.tricklecharge.unity.packages.devpacks.drone      | https://github.com/pog7776/Unity-Devpacks.git?path=/Drone/com.tricklecharge.unity.packages.devpacks.drone           |
| Math       | com.tricklecharge.unity.packages.devpacks.math       | https://github.com/pog7776/Unity-Devpacks.git?path=/Drone/com.tricklecharge.unity.packages.devpacks.math            |
| Physics    | com.tricklecharge.unity.packages.devpacks.physics    | https://github.com/pog7776/Unity-Devpacks.git?path=/Physics/com.tricklecharge.unity.packages.devpacks.physics       |
| Vehicles   | com.tricklecharge.unity.packages.devpacks.vehicles   | https://github.com/pog7776/Unity-Devpacks.git?path=/Vehicles/com.tricklecharge.unity.packages.devpacks.vehicles     |

## Usage

Unity seems to be a bit uncooperative with Github packages.

### Example `manifest.json`

#### Github packages

```
{
    "dependencies": {
        "com.tricklecharge.unity.packages.devpacks.art.devart": "https://github.com/pog7776/Unity-Devpacks.git?path=/Art/DevArt/com.tricklecharge.unity.packages.devpacks.art.devart",
        "com.tricklecharge.unity.packages.devpacks.attributes": "https://github.com/pog7776/Unity-Devpacks.git?path=/Attributes/com.tricklecharge.unity.packages.devpacks.attributes",
        "com.tricklecharge.unity.packages.devpacks.drone": "https://github.com/pog7776/Unity-Devpacks.git?path=/Drone/com.tricklecharge.unity.packages.devpacks.drone",
        "com.tricklecharge.unity.packages.devpacks.math": "https://github.com/pog7776/Unity-Devpacks.git?path=/Math/com.tricklecharge.unity.packages.devpacks.math",
        "com.tricklecharge.unity.packages.devpacks.physics": "https://github.com/pog7776/Unity-Devpacks.git?path=/Physics/com.tricklecharge.unity.packages.devpacks.physics",
        "com.tricklecharge.unity.packages.devpacks.vehicles": "https://github.com/pog7776/Unity-Devpacks.git?path=/Vehicles/com.tricklecharge.unity.packages.devpacks.vehicles",
    },

    "scopedRegistries": [
        {
            "name": "Github Packages",
            "url": "https://npm.pkg.github.com/@pog7776/",
            "scopes": [
                "com.tricklecharge.unity.packages.devpacks"
            ]
        }
    ]
}
```

> Note
> 
> `scopedRegistries` is not required 

#### Local packages

```
{
    "dependencies": {
        "com.tricklecharge.unity.packages.devpacks.art.devart": "file:S:/Dev/Unity/Devpacks/Art/DevArt/com.tricklecharge.unity.packages.devpacks.art.devart",
        "com.tricklecharge.unity.packages.devpacks.attributes": "file:S:/Dev/Unity/Devpacks/Attributes/com.tricklecharge.unity.packages.devpacks.attributes",
        "com.tricklecharge.unity.packages.devpacks.drone": "file:S:/Dev/Unity/Devpacks/Drone/com.tricklecharge.unity.packages.devpacks.drone",
        "com.tricklecharge.unity.packages.devpacks.math": "file:S:/Dev/Unity/Devpacks/Math/com.tricklecharge.unity.packages.devpacks.math",
        "com.tricklecharge.unity.packages.devpacks.physics": "file:S:/Dev/Unity/Devpacks/Physics/com.tricklecharge.unity.packages.devpacks.physics",
        "com.tricklecharge.unity.packages.devpacks.vehicles": "file:S:/Dev/Unity/Devpacks/Vehicles/com.tricklecharge.unity.packages.devpacks.vehicles",
    }
}
```

**Note**

`scopedRegistries` doesn't really seem to work for github.

- https://discussions.unity.com/t/using-github-packages-registry-with-unity-package-manager/784073
- https://discussions.unity.com/t/npm-registry-authentication/778442
- https://docs.unity3d.com/6000.1/Documentation/Manual/upm-scoped-host.html
- https://docs.unity3d.com/6000.1/Documentation/Manual/cus-share.html
- https://docs.unity3d.com/6000.1/Documentation/Manual/upm-git.html

Using "@" notation in url to force it as Unity does not support "@" notation in the scope. 