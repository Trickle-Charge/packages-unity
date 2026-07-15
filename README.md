# My Devpacks of all time

## Index

| Name                                                                                                                                  | Package                                                                                                                  | Version                                                                                                                                     |
|---------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------|
| [TrickleCharge Art](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.art.core)             | [com.tricklecharge.unity.art.core](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.art.core)          | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.art.core?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443)       |
| [TrickleCharge DevArt](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.art.devart)        | [com.tricklecharge.unity.art.core.devart](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.art.devart) | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.art.devart?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443)     |
| [TrickleCharge Attributes](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.attributes)    | [com.tricklecharge.unity.attributes](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.attributes)      | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.attributes?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443)     |
| [TrickleCharge Drones](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.drone)             | [com.tricklecharge.unity.drone](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.drone)                | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.drone?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443)          |
| [TrickleCharge Math](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.math)                | [com.tricklecharge.unity.math](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.math)                  | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.math?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443)           |
| [TrickleCharge Physics](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.physics)          | [com.tricklecharge.unity.physics](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.physics)            | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.physics?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443)        |
| [TrickleCharge Vehicle Systems](https://github.com/Trickle-Charge/packages-unity/tree/main/Packages/com.tricklecharge.unity.vehicles) | [com.tricklecharge.unity.vehicles](https://npm.tricklecharge.dev/-/web/detail/com.tricklecharge.unity.vehicles)          | ![NPM Version](https://img.shields.io/npm/v/com.tricklecharge.unity.vehicles?registry_uri=https%3A%2F%2Fnpm.tricklecharge.dev%3A8443)       |

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
        "com.tricklecharge.unity.art.core": "0.0.1",
        "com.tricklecharge.unity.art.devart": "0.0.5",
        "com.tricklecharge.unity.attributes": "0.0.1",
        "com.tricklecharge.unity.drone": "0.0.2",
        "com.tricklecharge.unity.math": "0.0.3",
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
        "com.tricklecharge.unity.art.core": "file:S:/Dev/unity-packages/Packages/com.tricklecharge.unity.art.core",
        "com.tricklecharge.unity.art.devart": "file:S:/Dev/unity-packages/Packages/com.tricklecharge.unity.art.devart",
        "com.tricklecharge.unity.attributes": "file:S:/Dev/unity-packages/Packages/com.tricklecharge.unity.attributes",
        "com.tricklecharge.unity.drone": "file:S:/Dev/unity-packages/Packages/com.tricklecharge.unity.drone",
        "com.tricklecharge.unity.math": "file:S:/Dev/unity-packages/Packages/com.tricklecharge.unity.math",
        "com.tricklecharge.unity.physics": "file:S:/Dev/unity-packages/Packages/com.tricklecharge.unity.physics",
        "com.tricklecharge.unity.vehicles": "file:S:/Dev/unity-packages/Packages/com.tricklecharge.unity.vehicles"
    }
}
```
---

## Authentication

> The packages in this repository do not require authentication to access.
> 
> **You can probably ignore this section.**

If you are trying to access packages that require authentication,
Unity's package manager (UPM) requires authentication details saved in your global `.upmconfig.toml` file.

### Step 1: Get your Registry Token

1. Navigate to the [TrickleCharge Registry Dashboard](https://npm.tricklecharge.dev/).
2. Click the **Login** button and select **Login with GitHub**.
3. Once authenticated, click on the ⚙️ gear icon in the top right corner.
4. Expand the **npm** section.
5. Copy your generated **Auth Token** from the provided npm configuration snippet (Only the text within the quotes).

> #### Example
> 
> `npm config set //npm.tricklecharge.dev/:_authToken "xxxxxxxxxxx"`
> 
> "`xxxxxxxxxxx`" is your auth token.

---

### Step 2: Configure UPM

#### Automatic Scripts

**Linux / macOS / WSL:**

```bash
bash <(curl -sSL https://raw.githubusercontent.com/Trickle-Charge/packages-unity/main/scripts/configure-upm-auth.sh)
```

**Windows (PowerShell):**

```powershell
irm https://raw.githubusercontent.com/Trickle-Charge/packages-unity/main/scripts/configure-upm-auth.ps1 | iex
```

---

#### Command Line

Copy and paste the command below into your terminal.
It will prompt you for the token you copied in Step 1 and it into your configuration.

**Linux / macOS / WSL:**
```bash
printf "Enter your TrickleCharge Registry Token: " && read -r REGISTRY_TOKEN && \
cat <<EOF >> ~/.upmconfig.toml

[npmAuth."https://npm.tricklecharge.dev/"]
_authToken = "$REGISTRY_TOKEN"
alwaysAuth = true
EOF
echo -e "\nSetup complete! Configured ~/.upmconfig.toml"
```

**Windows (PowerShell):**
```powershell
& {
    $Token = Read-Host "Enter your TrickleCharge Registry Token"
    $ConfigPath = Join-Path $Home ".upmconfig.toml"
    $ConfigLines = @(
        "`n"
        '[npmAuth."https://npm.tricklecharge.dev/"]'
        "_authToken = `"$Token`""
        "alwaysAuth = true"
    )

    Add-Content -Path $ConfigPath -Value $ConfigLines
    Write-Host "Setup complete! Configured $ConfigPath" -ForegroundColor Green
}
```

---

#### Manual Setup

Create / modify your `.upmconfig.toml` and add an entry.

```toml
[npmAuth."https://npm.tricklecharge.dev/"]
token = "xxxxxxxxxxx"
alwaysAuth = true
```

`.upmconfig.toml` can be found at:

| OS      | Path                             |
|---------|----------------------------------|
| Linux   | `~/.upmconfig.toml`              |
| Windows | `%USERPROFILE%\.upmconfig.toml`  |


---