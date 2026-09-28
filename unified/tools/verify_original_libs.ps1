param(
  [Parameter(Mandatory = $true)]
  [string] $ProjectRoot
)

$required = @(
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

$libDir = Join-Path $ProjectRoot "libs\original"
$missing = @()
foreach ($name in $required) {
  $path = Join-Path $libDir $name
  if (-not (Test-Path $path)) {
    $missing += $name
  }
}

if ($missing.Count -gt 0) {
  Write-Error ("Missing original DLLs in {0}: {1}" -f $libDir, ($missing -join ", "))
  exit 1
}

Write-Host "All required original DLLs are present in $libDir"
