# Windows AI Agent Build Guide — Next_1106 Fidelity Rebuild

> **Audience:** An AI coding agent running on a Windows machine.
> **Goal:** Build `DataCareNext.exe` and `NextDm.exe` from extracted source to produce
> binaries functionally identical to the originals in `Next_1106.zip`.

---

## Table of Contents

1. [Architecture Overview](#1-architecture-overview)
2. [Prerequisites Checklist](#2-prerequisites-checklist)
3. [Phase 1 — Transfer Project to Windows](#3-phase-1--transfer-project-to-windows)
4. [Phase 2 — Install Build Toolchain](#4-phase-2--install-build-toolchain)
5. [Phase 3 — Recover Original Vendor DLLs](#5-phase-3--recover-original-vendor-dlls)
6. [Phase 4 — Register COM/ActiveX Components](#6-phase-4--register-comactivex-components)
7. [Phase 5 — Recover Report Templates](#7-phase-5--recover-report-templates)
8. [Phase 6 — Recover Runtime Config](#8-phase-6--recover-runtime-config)
9. [Phase 7 — Build DataCareNext](#9-phase-7--build-datacarenext)
10. [Phase 8 — Build NextDm](#10-phase-8--build-nextdm)
11. [Phase 9 — Post-Build Verification](#11-phase-9--post-build-verification)
12. [Phase 10 — Runtime Smoke Test](#12-phase-10--runtime-smoke-test)
13. [Phase 11 — Package for Distribution](#13-phase-11--package-for-distribution)
14. [Troubleshooting Reference](#14-troubleshooting-reference)
15. [File Inventory](#15-file-inventory)

---

## 1. Architecture Overview

```
Original Application Stack:
┌──────────────────────────────────────────────────────────┐
│  DataCareNext.exe / NextDm.exe                           │
│  Assembly Name: DataCareNext  │  Version: 1.0.0.0        │
│  Runtime: .NET Framework 4.7.2  │  Platform: x86 (PE32)  │
├──────────────────────────────────────────────────────────┤
│  UI Layer: WinForms + DevExpress v19.1 + DotNetBar2      │
│            + Qios DevSuite + Crystal ActiveX              │
│            + MSFlexGrid ActiveX                           │
├──────────────────────────────────────────────────────────┤
│  Reports: SAP Crystal Reports (.rpt templates)           │
├──────────────────────────────────────────────────────────┤
│  Data: SQL Server (Initial Catalog=Next19)               │
│        Connection: MORVIN\SQLEXPRESS                     │
│        Driver: System.Data.SqlClient                     │
├──────────────────────────────────────────────────────────┤
│  Integrations: TagitIce/TagitSDK (RFID),                 │
│                DevNet.WhatsApp.V2, Selenium WebDriver,    │
│                QRCoder, RestSharp, Newtonsoft.Json         │
└──────────────────────────────────────────────────────────┘
```

**Key facts:**
- Both `DataCareNext.exe` (24 MB) and `NextDm.exe` (23 MB) share the assembly name `DataCareNext`.
- `DataCareNext` has 5 extra forms/classes vs. `NextDm`: `OlockerService`, `PolicyModels`, `RP_STOCK_VALUE`, `TR_FN_INOUT`, `UT_PWD_UPDATE`.
- Source was decompiled from VB.NET → C# WinForms. Original build was x86/.NET Framework 4.7.2.
- **Do NOT use .NET 8 or any .NET Core runtime.** It cannot match original behavior.

---

## 2. Prerequisites Checklist

Run this on the Windows machine to verify readiness. Every item marked `REQUIRED` must pass before building.

| # | Prerequisite | Required | Verification Command |
|---|---|---|---|
| 1 | Windows 10/11 x64 | REQUIRED | `[System.Environment]::OSVersion` |
| 2 | Visual Studio 2022 Build Tools (or VS 2022 IDE with Desktop Dev workload) | REQUIRED | `& "C:\Program Files (x86)\Microsoft Visual Studio\Installer\vswhere.exe" -latest -property installationPath` |
| 3 | .NET Framework 4.7.2 Developer Pack | REQUIRED | `Test-Path "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\mscorlib.dll"` |
| 4 | .NET Framework 4.7.2 Runtime | REQUIRED | `(Get-ItemProperty "HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full").Release -ge 461808` |
| 5 | MSBuild (from VS Build Tools) | REQUIRED | `& "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\MSBuild.exe" -version` |
| 6 | Python 3.9+ (for verification scripts) | RECOMMENDED | `python --version` |
| 7 | `dotnetfile` Python package | RECOMMENDED | `pip install dotnetfile` |
| 8 | SAP Crystal Reports Runtime (13.0.x, 32-bit) | REQUIRED for runtime | System registry check below |
| 9 | SQL Server / SQL Express instance | REQUIRED for runtime | `sqlcmd -S MORVIN\SQLEXPRESS -Q "SELECT 1"` |
| 10 | Original Next_1106 Setup/Install | REQUIRED | Verification of original folder and configuration files |

### 2.1 Install .NET Framework 4.7.2 Developer Pack

If not present:

```powershell
# Download and install (interactive)
Start-Process "https://dotnet.microsoft.com/download/dotnet-framework/net472"
# Or via winget:
winget install Microsoft.DotNet.Framework.DeveloperPack_4 --version 4.7.2
```

### 2.2 Install Visual Studio 2022 Build Tools

```powershell
# Minimal install with .NET desktop build support
winget install Microsoft.VisualStudio.2022.BuildTools --override "--add Microsoft.VisualStudio.Workload.ManagedDesktopBuildTools --passive --wait"
```

### 2.3 Locate MSBuild

```powershell
$vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
$msbuildPath = & $vswhere -latest -requires Microsoft.Component.MSBuild -find "MSBuild\**\Bin\MSBuild.exe" | Select-Object -First 1
Write-Host "MSBuild: $msbuildPath"
# Set alias for later commands
Set-Alias msbuild $msbuildPath
```

### 2.4 Original Application Setup & Harvesting (Critical Pre-requisite)

> [!IMPORTANT]
> **Do you need a proper setup of the original Next_1106 application before building?**
> **YES.** The decompiled source code does NOT contain the necessary third-party vendor DLLs (DevExpress, DotNetBar, etc.) or registered ActiveX controls. 
> To obtain a successful build and 100% runtime parity, you must first install/run the original Next_1106 package on the target Windows environment. 
> This registers ActiveX components, initializes local configurations (like ODBC and local database), and provides the source directory to harvest runtime assemblies.

#### Why the Original Setup is Required
1. **Dependency Harvesting:** The 23 vendor DLLs (such as DevExpress v19.1 and DotNetBar2) are proprietary and are not included in this repository. They must be harvested from the folder where the original application is installed.
2. **ActiveX/COM Registration:** Controls like MSFlexGrid (`MSFLXGRD.OCX`) and Crystal ActiveX Viewer require proper registration on the Windows OS (`regsvr32`). Running the original setup registers these components correctly in the registry.
3. **Database and Local Config Assets:** The original installation configures ODBC properties and initializes local configurations (e.g., `C:\DcLink\DcOpen.txt`).

#### Harvesting Checklist (What to copy and where to find it)
Before you run the build, ensure the original app is set up and locate/copy the following assets from the original machine:

* **Location 1: Original App Binary Folder** (typically `C:\Program Files (x86)\DataCareNext\` or wherever the EXE runs):
  * Copy the 23 vendor DLLs (see Phase 3 list in Section 5).
  * Copy the `C:\DcLink\DcOpen.txt` file (contains server database info).
* **Location 2: Original Report Folder** (typically `<AppDir>\Report\`):
  * Copy all `.rpt` report templates (specifically the missing ~202 files).
* **Location 3: SQL Server Database Backup:**
  * Export/Backup the `Next19` SQL Server database to a `.bak` file.

---

## 3. Phase 1 — Transfer Project to Windows

### 3.1 Copy the entire project folder

Copy the `imodule-extracted` folder from the Mac to the Windows machine. Preserve the full directory structure.

Recommended target: `C:\Projects\imodule-extracted\`

```powershell
# If using a network share or USB:
Copy-Item -Recurse "\\MACSHARE\imodule-extracted" "C:\Projects\imodule-extracted"

# Or extract from a zip transfer:
Expand-Archive "C:\Users\$env:USERNAME\Downloads\imodule-extracted.zip" -DestinationPath "C:\Projects\"
```

### 3.2 Verify directory structure

```powershell
$root = "C:\Projects\imodule-extracted"

# Core project files must exist
$checks = @(
    "$root\extracted_code\DataCareNext\DataCareNext.csproj",
    "$root\extracted_code\NextDm\NextDm.csproj",
    "$root\extracted_code\DataCareNext\DataCareNext.exe.licenses",
    "$root\extracted_code\NextDm\DataCareNext.exe.licenses",
    "$root\tools\verify_original_libs.ps1",
    "$root\tools\parse_build_errors.py",
    "$root\tools\compare_manifest_resources.py",
    "$root\tools\compare_pe_identity.py",
    "$root\tools\audit_type_coverage.py",
    "$root\DataCareNext.exe",
    "$root\NextDm.exe"
)

$missing = @()
foreach ($path in $checks) {
    if (-not (Test-Path $path)) {
        $missing += $path
    }
}

if ($missing.Count -gt 0) {
    Write-Error "TRANSFER INCOMPLETE. Missing files:"
    $missing | ForEach-Object { Write-Error "  $_" }
} else {
    Write-Host "Transfer verified: all critical files present." -ForegroundColor Green
}
```

### 3.3 Verify source counts

```powershell
$dcSource = Get-ChildItem "$root\extracted_code\DataCareNext\DataCareNext\*.cs" | Measure-Object
$ndSource = Get-ChildItem "$root\extracted_code\NextDm\DataCareNext\*.cs" | Measure-Object
Write-Host "DataCareNext source files: $($dcSource.Count) (expected: 204)"
Write-Host "NextDm source files: $($ndSource.Count) (expected: 199)"
```

---

## 4. Phase 2 — Install Build Toolchain

Already covered in Section 2. Verify the framework reference assemblies are accessible:

```powershell
$refAsm = "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2"
if (Test-Path "$refAsm\System.Windows.Forms.dll") {
    Write-Host ".NET Framework 4.7.2 reference assemblies: OK" -ForegroundColor Green
} else {
    Write-Error ".NET Framework 4.7.2 Developer Pack is NOT installed."
    Write-Error "Download from: https://dotnet.microsoft.com/download/dotnet-framework/net472"
}
```

---

## 5. Phase 3 — Recover Original Vendor DLLs

> [!CAUTION]
> This is the **most critical manual step**. Without real vendor DLLs, the build will fail
> with thousands of `CS0246` (type not found) errors. Stubs are NOT acceptable for fidelity.

### 5.1 Required DLL List (23 files)

Copy **each** of these from the original installed application directory (typically
`C:\Program Files (x86)\DataCareNext\` or wherever the original app was deployed):

```
AxInterop.Crystal.dll
AxInterop.MSFlexGridLib.dll
CrystalDecisions.CrystalReports.Engine.dll
CrystalDecisions.Shared.dll
CrystalDecisions.Windows.Forms.dll
DevComponents.DotNetBar2.dll
DevExpress.Data.v19.1.dll
DevExpress.Utils.v19.1.dll
DevExpress.XtraBars.v19.1.dll
DevExpress.XtraCharts.v19.1.dll
DevExpress.XtraCharts.v19.1.UI.dll
DevExpress.XtraDialogs.v19.1.dll
DevExpress.XtraEditors.v19.1.dll
DevExpress.XtraGrid.v19.1.dll
DevNet.WhatsApp.V2.dll
Interop.Crystal.dll
Interop.MSFlexGridLib.dll
Newtonsoft.Json.dll
Qios.DevSuite.Components.dll
QRCoder.dll
RestSharp.dll
TagitIce.dll
WebDriver.dll
```

### 5.2 Copy to both project `libs\original` directories

```powershell
$root = "C:\Projects\imodule-extracted"
$originalAppDir = "D:\OriginalApp"  # <-- CHANGE THIS to the real source path

$targets = @(
    "$root\extracted_code\DataCareNext\libs\original",
    "$root\extracted_code\NextDm\libs\original"
)

foreach ($target in $targets) {
    New-Item -ItemType Directory -Force -Path $target | Out-Null
}

$dlls = @(
    "AxInterop.Crystal.dll",
    "AxInterop.MSFlexGridLib.dll",
    "CrystalDecisions.CrystalReports.Engine.dll",
    "CrystalDecisions.Shared.dll",
    "CrystalDecisions.Windows.Forms.dll",
    "DevComponents.DotNetBar2.dll",
    "DevExpress.Data.v19.1.dll",
    "DevExpress.Utils.v19.1.dll",
    "DevExpress.XtraBars.v19.1.dll",
    "DevExpress.XtraCharts.v19.1.dll",
    "DevExpress.XtraCharts.v19.1.UI.dll",
    "DevExpress.XtraDialogs.v19.1.dll",
    "DevExpress.XtraEditors.v19.1.dll",
    "DevExpress.XtraGrid.v19.1.dll",
    "DevNet.WhatsApp.V2.dll",
    "Interop.Crystal.dll",
    "Interop.MSFlexGridLib.dll",
    "Newtonsoft.Json.dll",
    "Qios.DevSuite.Components.dll",
    "QRCoder.dll",
    "RestSharp.dll",
    "TagitIce.dll",
    "WebDriver.dll"
)

$notFound = @()
foreach ($dll in $dlls) {
    $src = Join-Path $originalAppDir $dll
    if (Test-Path $src) {
        foreach ($target in $targets) {
            Copy-Item $src (Join-Path $target $dll) -Force
        }
        Write-Host "  Copied: $dll" -ForegroundColor Green
    } else {
        $notFound += $dll
        Write-Warning "  NOT FOUND: $dll at $src"
    }
}

if ($notFound.Count -gt 0) {
    Write-Error "`n$($notFound.Count) DLLs not found. Build WILL fail."
    Write-Error "Search these alternative locations:"
    Write-Error "  - GAC: C:\Windows\Microsoft.NET\assembly\GAC_MSIL\"
    Write-Error "  - Crystal: C:\Program Files (x86)\SAP BusinessObjects\"
    Write-Error "  - DevExpress: C:\Program Files (x86)\DevExpress 19.1\"
    Write-Error "  - Original app bin folder"
} else {
    Write-Host "`nAll 23 DLLs copied successfully." -ForegroundColor Green
}
```

### 5.3 Verify with the provided script

```powershell
$root = "C:\Projects\imodule-extracted"
powershell -ExecutionPolicy Bypass -File "$root\tools\verify_original_libs.ps1" -ProjectRoot "$root\extracted_code\DataCareNext"
powershell -ExecutionPolicy Bypass -File "$root\tools\verify_original_libs.ps1" -ProjectRoot "$root\extracted_code\NextDm"
```

**Expected output:**
```
All required original DLLs are present in C:\Projects\imodule-extracted\extracted_code\DataCareNext\libs\original
All required original DLLs are present in C:\Projects\imodule-extracted\extracted_code\NextDm\libs\original
```

### 5.4 Where to find DLLs if the original install is unavailable

| DLL Category | Likely Source |
|---|---|
| `DevExpress.*.v19.1.dll` | DevExpress installer v19.1 → `C:\Program Files (x86)\DevExpress 19.1\Components\Bin\Framework4\` |
| `DevComponents.DotNetBar2.dll` | DotNetBar installer → GAC or install folder |
| `CrystalDecisions.*.dll` | SAP Crystal Reports Runtime 13.0 (32-bit) → `C:\Program Files (x86)\SAP BusinessObjects\Crystal Reports\` |
| `AxInterop.Crystal.dll`, `Interop.Crystal.dll` | Generated from Crystal ActiveX OCX via `aximp`/`tlbimp` or from original build output |
| `AxInterop.MSFlexGridLib.dll`, `Interop.MSFlexGridLib.dll` | Generated from `MSFLXGRD.OCX` via `aximp` or from original build output |
| `Qios.DevSuite.Components.dll` | Qios DevSuite installer |
| `TagitIce.dll` | Tagit RFID vendor SDK |
| `DevNet.WhatsApp.V2.dll` | DevNet vendor distribution |
| `Newtonsoft.Json.dll`, `QRCoder.dll`, `RestSharp.dll`, `WebDriver.dll` | NuGet or original bin folder |

---

## 6. Phase 4 — Register COM/ActiveX Components

> [!IMPORTANT]
> The application uses COM Interop for MSFlexGrid and Crystal ActiveX.
> These ActiveX controls must be registered on the Windows machine for both
> build-time type resolution and runtime form rendering.

### 6.1 Register MSFlexGrid

```powershell
# MSFlexGrid OCX is typically at:
$ocx = "C:\Windows\SysWOW64\MSFLXGRD.OCX"
if (Test-Path $ocx) {
    Start-Process regsvr32 -ArgumentList "/s `"$ocx`"" -Verb RunAs -Wait
    Write-Host "MSFlexGrid registered." -ForegroundColor Green
} else {
    Write-Warning "MSFLXGRD.OCX not found. Install Microsoft FlexGrid Control 6.0."
    Write-Warning "Available in Visual Basic 6.0 runtime redistributables."
}
```

### 6.2 Register Crystal ActiveX Viewer

```powershell
# Crystal ActiveX is installed by SAP Crystal Reports Runtime (32-bit)
# After installing the runtime, verify:
$crystalKeys = Get-ChildItem "HKLM:\SOFTWARE\WOW6432Node\Classes\CLSID" -ErrorAction SilentlyContinue |
    Where-Object { (Get-ItemProperty $_.PSPath -ErrorAction SilentlyContinue).InprocServer32 -like "*CrystalActiveX*" }

if ($crystalKeys) {
    Write-Host "Crystal ActiveX COM registered." -ForegroundColor Green
} else {
    Write-Warning "Crystal ActiveX not found in registry."
    Write-Warning "Install SAP Crystal Reports Runtime 13.0 (32-bit) from:"
    Write-Warning "  https://wiki.scn.sap.com/wiki/display/BOBJ/Crystal+Reports+Runtime+Downloads"
}
```

---

## 7. Phase 5 — Recover Report Templates

The source code references **238 unique `.rpt` template names**. The `Next_1106.zip` package
only contains **36**. The remaining **~202 templates** must come from the original application's
`Report` directory.

### 7.1 Copy package reports (already done on Mac, verify on Windows)

```powershell
$root = "C:\Projects\imodule-extracted"
$rptCount = (Get-ChildItem "$root\Report\*.rpt" -ErrorAction SilentlyContinue | Measure-Object).Count
Write-Host "Report templates present: $rptCount (minimum: 36 from package)"

if ($rptCount -lt 36) {
    Write-Warning "Missing package reports. Copy *.rpt from project root to Report\:"
    Copy-Item "$root\*.rpt" "$root\Report\" -Force
}
```

### 7.2 Recover missing templates from original install

```powershell
$root = "C:\Projects\imodule-extracted"
$originalReportDir = "D:\OriginalApp\Report"  # <-- CHANGE THIS

if (Test-Path $originalReportDir) {
    $missing = Get-Content "$root\audit\datacarenext-missing-rpt.txt"
    $recovered = 0
    foreach ($rpt in $missing) {
        $src = Join-Path $originalReportDir $rpt
        if (Test-Path $src) {
            Copy-Item $src "$root\Report\$rpt" -Force
            $recovered++
        }
    }
    Write-Host "Recovered $recovered of $($missing.Count) missing report templates." -ForegroundColor Green
} else {
    Write-Warning "Original Report directory not found at $originalReportDir"
    Write-Warning "Report parity is BLOCKED until templates are supplied."
}
```

---

## 8. Phase 6 — Recover Runtime Config

### 8.1 Create `App.config` for DataCareNext

The original app uses `Next19ConnectionString` pointing to `MORVIN\SQLEXPRESS` with
`Initial Catalog=Next19`. Adapt the server name to your environment.

```powershell
$root = "C:\Projects\imodule-extracted"
$appConfig = @'
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
  </startup>
  <connectionStrings>
    <add name="Next19ConnectionString"
         connectionString="Data Source=MORVIN\SQLEXPRESS;Initial Catalog=Next19;Integrated Security=True"
         providerName="System.Data.SqlClient" />
  </connectionStrings>
  <appSettings>
    <add key="ReportPath" value="Report\" />
  </appSettings>
</configuration>
'@

$appConfig | Out-File "$root\extracted_code\DataCareNext\App.config" -Encoding utf8
$appConfig | Out-File "$root\extracted_code\NextDm\App.config" -Encoding utf8
Write-Host "App.config created for both projects." -ForegroundColor Green
```

> [!WARNING]
> If the original deployed `DataCareNext.exe.config` or `NextDm.exe.config` is available,
> use that instead. The above is a reconstructed approximation based on binary string analysis.
> Adjust `Data Source` to match your SQL Server instance name.

---

## 9. Phase 7 — Build DataCareNext

### 9.1 Locate MSBuild

```powershell
$vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
$msbuild = & $vswhere -latest -requires Microsoft.Component.MSBuild -find "MSBuild\**\Bin\MSBuild.exe" | Select-Object -First 1

if (-not $msbuild) {
    Write-Error "MSBuild not found. Install VS 2022 Build Tools."
    exit 1
}
Write-Host "Using MSBuild: $msbuild"
```

### 9.2 Build (Release, x86)

```powershell
$root = "C:\Projects\imodule-extracted"

# Create audit directory for build logs
New-Item -ItemType Directory -Force -Path "$root\audit" | Out-Null

# Build DataCareNext
& $msbuild "$root\extracted_code\DataCareNext\DataCareNext.csproj" `
    /p:Configuration=Release `
    /p:Platform=x86 `
    /v:normal `
    /fl `
    "/flp:logfile=$root\audit\DataCareNext-build.log;verbosity=normal"

Write-Host "`nBuild exit code: $LASTEXITCODE"
```

### 9.3 Parse build log for errors

```powershell
python "$root\tools\parse_build_errors.py" "$root\audit\DataCareNext-build.log"
```

**Expected final state:**
```
"total_errors": 0
```

### 9.4 If build fails — error classification guide

| Error Code | Root Cause | Fix |
|---|---|---|
| `CS0246` (type not found) | Missing vendor DLL in `libs\original` | Copy the real DLL — see Phase 3 |
| `CS0234` (namespace not found) | Missing framework reference | Already handled: `System.Web.Extensions` is in `.csproj` |
| `CS0621` (field modifier) | Decompiler artifact | Already fixed by `fix_field_accessed_auto_properties.py` (7,602 conversions) |
| `CS0104` (ambiguous Timer) | `System.Threading.Timer` vs `System.Windows.Forms.Timer` | Already fixed by `fix_timer_ambiguities.py` |
| `CS0596`/`CS1908` (Office interop) | Decompiled interop source files | Already excluded via `<Compile Remove="Microsoft.Office.Interop.*\**">` |
| `CS1069` (forwarded type) | `SerialPort`/`OleDb` in wrong framework | Resolves automatically under `net472` |
| `CS7036` (MySettings) | Constructor signature mismatch | Check `System.Configuration` reference; qualify attributes |
| `MSB3245` (reference not found) | DLL path incorrect | Verify `libs\original\<DLL>` exists and matches HintPath |

### 9.5 If errors persist after DLL copy

Run these diagnostic commands:

```powershell
# Count errors by code
Select-String "error CS\d+" "$root\audit\DataCareNext-build.log" |
    ForEach-Object { $_.Matches[0].Value } |
    Group-Object | Sort-Object Count -Descending |
    Format-Table Name, Count

# List unresolved type names
Select-String "error CS0246.*'([^']+)'" "$root\audit\DataCareNext-build.log" |
    ForEach-Object { $_.Matches[0].Groups[1].Value } |
    Sort-Object -Unique
```

---

## 10. Phase 8 — Build NextDm

### 10.1 Build (Release, x86)

```powershell
$root = "C:\Projects\imodule-extracted"

& $msbuild "$root\extracted_code\NextDm\NextDm.csproj" `
    /p:Configuration=Release `
    /p:Platform=x86 `
    /v:normal `
    /fl `
    "/flp:logfile=$root\audit\NextDm-build.log;verbosity=normal"

Write-Host "`nBuild exit code: $LASTEXITCODE"
```

### 10.2 Parse build log

```powershell
python "$root\tools\parse_build_errors.py" "$root\audit\NextDm-build.log"
```

### 10.3 Rename output for package parity

The original `NextDm.exe` in `Next_1106.zip` has assembly name `DataCareNext`.
The build output will be `DataCareNext.exe`. Rename it:

```powershell
$buildOutput = "$root\extracted_code\NextDm\bin\Release\net472"
if (Test-Path "$buildOutput\DataCareNext.exe") {
    Copy-Item "$buildOutput\DataCareNext.exe" "$buildOutput\NextDm.exe" -Force
    Write-Host "NextDm.exe created from DataCareNext.exe build output." -ForegroundColor Green
}
```

---

## 11. Phase 9 — Post-Build Verification

### 11.1 Manifest Resource Parity

```powershell
$root = "C:\Projects\imodule-extracted"

# DataCareNext
python "$root\tools\compare_manifest_resources.py" `
    "$root\DataCareNext.exe" `
    "$root\extracted_code\DataCareNext\bin\Release\net472\DataCareNext.exe"

# NextDm
python "$root\tools\compare_manifest_resources.py" `
    "$root\NextDm.exe" `
    "$root\extracted_code\NextDm\bin\Release\net472\DataCareNext.exe"
```

**Expected:**
```
missing=0
extra=0
```

### 11.2 PE Identity / Win32 Resource Parity

```powershell
# DataCareNext
python "$root\tools\compare_pe_identity.py" `
    "$root\DataCareNext.exe" `
    "$root\extracted_code\DataCareNext\bin\Release\net472\DataCareNext.exe"

# NextDm
python "$root\tools\compare_pe_identity.py" `
    "$root\NextDm.exe" `
    "$root\extracted_code\NextDm\bin\Release\net472\DataCareNext.exe"
```

### 11.3 Type Coverage Parity

```powershell
python "$root\tools\audit_type_coverage.py"
```

**Expected:** 0 unexplained missing TypeDef names.

### 11.4 Full Parity Audit

```powershell
python "$root\tools\audit_next1106_parity.py"
python -m json.tool "$root\audit\next1106-parity.json" | Select-String "missing_source_resources"
```

**Expected:** `"missing_source_resources": []` for both targets.

---

## 12. Phase 10 — Runtime Smoke Test

### 12.1 Required runtime environment

Before launching the rebuilt app:

- [ ] SQL Server instance running with `Next19` database restored
- [ ] Connection string in `App.config` matches your SQL instance
- [ ] Crystal Reports Runtime 13.0 (32-bit) installed
- [ ] MSFlexGrid OCX registered (see Phase 4)
- [ ] All vendor DLLs copied to the output `bin\Release\net472\` directory
- [ ] `Report\` directory with all `.rpt` templates accessible

### 12.2 Copy vendor DLLs to output directory

```powershell
$root = "C:\Projects\imodule-extracted"
$outputDir = "$root\extracted_code\DataCareNext\bin\Release\net472"

Get-ChildItem "$root\extracted_code\DataCareNext\libs\original\*.dll" |
    Copy-Item -Destination $outputDir -Force

Write-Host "Vendor DLLs copied to output directory."
```

### 12.3 Launch and verify startup flow

```powershell
Start-Process "$root\extracted_code\DataCareNext\bin\Release\net472\DataCareNext.exe"
```

**Expected startup sequence:**
1. `MS_LOGIN` form appears (login screen with original icon/layout)
2. After valid login → `MS_OPNCOMP` appears (company/year selection)
3. After company selection → `MDI_FORM` appears (main application)

### 12.4 Smoke test checklist

| Area | Form(s) | What to verify |
|---|---|---|
| Master | `MS_ACCT`, `MS_ITEM`, `MS_COMPANY` | CRUD operations work, grids display data |
| Transaction | `TR_SALE`, `TR_PURC`, `TR_TAG_OPBL` | Transaction entry, save, grid display |
| Reports | `RP_LEDR`, `RP_STOCK`, `RP_GST` | Crystal viewer opens, data renders |
| Utilities | `UT_SETTING_MAIN`, `UT_IMPORT` | Settings load/save, import works |
| Print | Any report print path | Crystal print preview works |

---

## 13. Phase 11 — Package for Distribution

### 13.1 Assemble distribution package

```powershell
$root = "C:\Projects\imodule-extracted"
$dist = "$root\dist\Next_1106-rebuilt"

New-Item -ItemType Directory -Force -Path $dist | Out-Null

# Copy rebuilt executables
Copy-Item "$root\extracted_code\DataCareNext\bin\Release\net472\DataCareNext.exe" "$dist\DataCareNext.exe" -Force
Copy-Item "$root\extracted_code\NextDm\bin\Release\net472\DataCareNext.exe" "$dist\NextDm.exe" -Force

# Copy report templates
Copy-Item "$root\Report\*.rpt" "$dist\" -Force

# Copy vendor DLLs
Copy-Item "$root\extracted_code\DataCareNext\libs\original\*.dll" "$dist\" -Force

# Copy App.config
Copy-Item "$root\extracted_code\DataCareNext\App.config" "$dist\DataCareNext.exe.config" -Force
Copy-Item "$root\extracted_code\NextDm\App.config" "$dist\NextDm.exe.config" -Force

Write-Host "Distribution package assembled at: $dist"
$fileCount = (Get-ChildItem $dist | Measure-Object).Count
Write-Host "Total files: $fileCount"
```

### 13.2 Create zip archive

```powershell
Compress-Archive -Path "$dist\*" -DestinationPath "$root\dist\Next_1106-rebuilt.zip" -Force
Write-Host "Package created: $root\dist\Next_1106-rebuilt.zip"
```

---

## 14. Troubleshooting Reference

### 14.1 "MSB3644: The reference assemblies for .NETFramework,Version=v4.7.2 were not found"

**Cause:** .NET Framework 4.7.2 Developer Pack is not installed.
**Fix:** Install from https://dotnet.microsoft.com/download/dotnet-framework/net472

### 14.2 "CS0246: The type or namespace name 'SimpleButton' could not be found"

**Cause:** DevExpress DLLs are missing from `libs\original`.
**Fix:** Copy `DevExpress.*.v19.1.dll` files from original app folder to `libs\original`.

### 14.3 "error CS0621: 'X': virtual or abstract members cannot be private"

**Cause:** Decompiler artifact — `[field: AccessedThroughProperty]` on virtual auto-properties.
**Fix:** Already resolved by `fix_field_accessed_auto_properties.py`. If new instances appear:
```powershell
python "$root\tools\fix_field_accessed_auto_properties.py" "$root\extracted_code\DataCareNext\DataCareNext" "$root\extracted_code\NextDm\DataCareNext"
```

### 14.4 "error CS0104: 'Timer' is an ambiguous reference"

**Cause:** Both `System.Threading` and `System.Windows.Forms` imported.
**Fix:** Already resolved by `fix_timer_ambiguities.py`. If new instances appear:
```powershell
python "$root\tools\fix_timer_ambiguities.py" "$root\extracted_code\DataCareNext\DataCareNext" "$root\extracted_code\NextDm\DataCareNext"
```

### 14.5 "Could not load file or assembly 'DevExpress.Data.v19.1'" at runtime

**Cause:** Vendor DLLs not in the output directory.
**Fix:** Copy all DLLs from `libs\original` to the `bin\Release\net472\` directory.

### 14.6 Crystal Reports ActiveX not working at runtime

**Cause:** SAP Crystal Reports Runtime not installed or wrong bitness.
**Fix:** Install 32-bit SAP Crystal Reports Runtime 13.0.x. The app is x86.

### 14.7 Build log parsing shows `CS0596`/`CS1908` errors

**Cause:** Office Interop `.cs` files being compiled.
**Fix:** Already excluded in `.csproj`. If errors reappear, verify these lines exist:
```xml
<Compile Remove="Microsoft.Office.Interop.Excel\**" />
<Compile Remove="Microsoft.Office.Interop.Word\**" />
<Compile Remove="Microsoft.Office.Interop.Outlook\**" />
<Compile Remove="Microsoft.Office.Core\**" />
```

---

## 15. File Inventory

### 15.1 Source tree structure (key paths)

```
imodule-extracted/
├── DataCareNext.exe                    # Original binary (24 MB)
├── NextDm.exe                          # Original binary (23 MB)
├── *.rpt                               # 36 package report templates
├── Report/                             # Canonical report directory
│   └── *.rpt                           # 36+ recovered templates
├── extracted_code/
│   ├── DataCareNext/
│   │   ├── DataCareNext.csproj         # SDK-style, net472/x86
│   │   ├── DataCareNext.exe.licenses   # Embedded license resource
│   │   ├── app.ico                     # Application icon
│   │   ├── App.config                  # Runtime config (create on Windows)
│   │   ├── DataCareNext/               # 204 .cs source files
│   │   ├── DataCareNext.My/            # VB→C# MyApplication/MySettings
│   │   ├── *.resx                      # 166 form resource files
│   │   ├── libs/
│   │   │   └── original/               # 23 vendor DLLs (copy here)
│   │   ├── Microsoft.Office.Interop.*/ # Excluded from build
│   │   └── stubs/                      # Excluded from build
│   └── NextDm/
│       ├── NextDm.csproj               # SDK-style, net472/x86
│       ├── NextDm.sln                  # Solution file
│       ├── (same structure as DataCareNext, minus 5 files)
│       └── libs/original/              # Same 23 vendor DLLs
├── tools/
│   ├── audit_next1106_parity.py        # Manifest resource audit
│   ├── audit_type_coverage.py          # TypeDef coverage audit
│   ├── compare_manifest_resources.py   # Compare original vs rebuilt
│   ├── compare_pe_identity.py          # Win32/PE resource comparison
│   ├── fix_field_accessed_auto_properties.py  # CS0621 fixer
│   ├── fix_timer_ambiguities.py        # CS0104 fixer
│   ├── parse_build_errors.py           # Build log parser
│   └── verify_original_libs.ps1        # DLL presence checker
├── audit/
│   ├── next1106-parity.json            # Parity audit output
│   ├── build-errors-baseline.json      # Pre-remediation error baseline
│   ├── type-coverage.json              # Type coverage results
│   ├── datacarenext-missing-rpt.txt    # Missing report template list
│   └── nextdm-missing-rpt.txt          # Missing report template list
└── docs/
    ├── fidelity-acceptance.md           # Acceptance checklist
    ├── windows-build-environment.md     # Environment requirements
    ├── runtime-config-parity.md         # Config recovery notes
    ├── runtime-smoke-test.md            # Runtime test plan
    ├── report-template-parity.md        # Report template status
    └── package-parity.md               # Package comparison notes
```

### 15.2 Build outputs (after successful build)

```
extracted_code/DataCareNext/bin/Release/net472/
├── DataCareNext.exe                    # Rebuilt primary executable
├── DataCareNext.exe.config             # Runtime config
└── (vendor DLLs copied here for runtime)

extracted_code/NextDm/bin/Release/net472/
├── DataCareNext.exe                    # Rebuilt secondary executable
├── NextDm.exe                          # Renamed copy for package parity
├── NextDm.exe.config                   # Runtime config
└── (vendor DLLs copied here for runtime)
```

---

## Quick Reference Card

```powershell
# === FULL BUILD SEQUENCE (run after all prerequisites are met) ===
$root = "C:\Projects\imodule-extracted"
$vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
$msbuild = & $vswhere -latest -requires Microsoft.Component.MSBuild -find "MSBuild\**\Bin\MSBuild.exe" | Select-Object -First 1

# 1. Verify DLLs
powershell -ExecutionPolicy Bypass -File "$root\tools\verify_original_libs.ps1" -ProjectRoot "$root\extracted_code\DataCareNext"
powershell -ExecutionPolicy Bypass -File "$root\tools\verify_original_libs.ps1" -ProjectRoot "$root\extracted_code\NextDm"

# 2. Build DataCareNext
& $msbuild "$root\extracted_code\DataCareNext\DataCareNext.csproj" /p:Configuration=Release /p:Platform=x86 /v:m /fl "/flp:logfile=$root\audit\DataCareNext-build.log"

# 3. Build NextDm
& $msbuild "$root\extracted_code\NextDm\NextDm.csproj" /p:Configuration=Release /p:Platform=x86 /v:m /fl "/flp:logfile=$root\audit\NextDm-build.log"

# 4. Rename NextDm output
Copy-Item "$root\extracted_code\NextDm\bin\Release\net472\DataCareNext.exe" "$root\extracted_code\NextDm\bin\Release\net472\NextDm.exe" -Force

# 5. Verify
python "$root\tools\parse_build_errors.py" "$root\audit\DataCareNext-build.log"
python "$root\tools\parse_build_errors.py" "$root\audit\NextDm-build.log"
python "$root\tools\compare_manifest_resources.py" "$root\DataCareNext.exe" "$root\extracted_code\DataCareNext\bin\Release\net472\DataCareNext.exe"
python "$root\tools\compare_manifest_resources.py" "$root\NextDm.exe" "$root\extracted_code\NextDm\bin\Release\net472\DataCareNext.exe"
```
