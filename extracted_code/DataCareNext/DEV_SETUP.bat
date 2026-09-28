@echo off
:: ============================================================
:: DataCareNext DEV MODE SETUP SCRIPT
:: Run this as Administrator on the Windows dev machine
:: ============================================================
echo.
echo ============================================================
echo  DataCareNext Dev Mode Setup
echo ============================================================
echo.

:: Step 1: Create DcLink directory and copy config files
echo [1/6] Creating C:\DcLink directory...
if not exist "C:\DcLink" mkdir "C:\DcLink"
if not exist "C:\DcLink\Images" mkdir "C:\DcLink\Images"
echo     OK - C:\DcLink created.

:: Step 2: Copy DcOpen.txt (credentials file - blank = Windows Auth)
echo [2/6] Copying config files...
copy /Y "%~dp0DcOpen.txt" "C:\DcLink\DcOpen.txt" >nul
echo     OK - DcOpen.txt copied.

:: Step 3: Copy Crystal Reports (.rpt) files next to the exe
echo [3/6] Copying Crystal Report files...
set RPT_SOURCE=%~dp0..\..\..\..\
for %%f in ("%~dp0..\..\..\..\*.rpt") do (
    copy /Y "%%f" "%~dp0DataCareNext\" >nul 2>&1
)
echo     OK - .rpt files copied.

:: Step 4: Create the SQL Server dev database
echo [4/6] Creating SQL Server database Next_Dev...
sqlcmd -S .\SQLEXPRESS -Q "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Next_Dev') CREATE DATABASE [Next_Dev]" 2>nul
if %errorlevel% neq 0 (
    echo     WARNING: Could not auto-create database. Please create 'Next_Dev' manually in SQL Server.
) else (
    echo     OK - Database Next_Dev ready.
)

:: Step 5: Copy SqlName.txt next to the exe (output dir)
echo [5/6] Copying SqlName.txt to output directory...
if not exist "%~dp0DataCareNext\bin\Debug\net8.0-windows" mkdir "%~dp0DataCareNext\bin\Debug\net8.0-windows"
if not exist "%~dp0DataCareNext\bin\Debug\net8.0-windows\win-x64" mkdir "%~dp0DataCareNext\bin\Debug\net8.0-windows\win-x64"
copy /Y "%~dp0SqlName.txt" "%~dp0DataCareNext\bin\Debug\net8.0-windows\SqlName.txt" >nul
copy /Y "%~dp0SqlName.txt" "%~dp0DataCareNext\bin\Debug\net8.0-windows\win-x64\SqlName.txt" >nul
copy /Y "%~dp0SqlName.txt" "%~dp0DataCareNext\" >nul
echo     OK - SqlName.txt placed.

:: Step 6: Create libs folder reminder
echo [6/6] Checking libs folder...
if not exist "%~dp0DataCareNext\libs" mkdir "%~dp0DataCareNext\libs"

echo.
echo ============================================================
echo  ACTION REQUIRED: 
echo  Copy the following DLLs from the original DataCareNext
echo  installation into: %~dp0DataCareNext\libs\
echo.
echo  DevExpress DLLs (from original install folder):
echo    - DevExpress.Data.v19.1.dll
echo    - DevExpress.XtraGrid.v19.1.dll  
echo    - DevExpress.XtraBars.v19.1.dll
echo    - DevExpress.XtraEditors.v19.1.dll
echo    - DevExpress.XtraCharts.v19.1.dll
echo    - DevExpress.XtraCharts.v19.1.UI.dll
echo    - DevExpress.XtraDialogs.v19.1.dll
echo    - DevExpress.Utils.v19.1.dll
echo    - DevComponents.DotNetBar2.dll
echo    - Qios.DevSuite.Components.dll
echo    - DevNet.WhatsApp.V2.dll
echo    - TagitIce.dll
echo    - AxInterop.MSFlexGridLib.dll
echo    - AxInterop.Crystal.dll
echo    - Interop.Crystal.dll
echo    - Interop.MSFlexGridLib.dll
echo.
echo  Crystal Reports DLLs (from SAP Crystal Reports install):
echo    - CrystalDecisions.CrystalReports.Engine.dll
echo    - CrystalDecisions.Windows.Forms.dll
echo    - CrystalDecisions.Shared.dll
echo ============================================================

echo.
echo ============================================================
echo  Setup complete!
echo.
echo  NEXT STEPS:
echo  1. Place all DLLs in DataCareNext\libs\ (see above)
echo  2. Open DataCareNext.sln in Visual Studio 2022
echo  3. Build ^> Rebuild Solution
echo  4. Press F5 to run
echo  5. Login: Username=ABC, Password=SS (dev backdoor)
echo ============================================================
echo.
pause
