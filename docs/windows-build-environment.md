# Windows Build Environment

Exact fidelity requires Windows. macOS/Linux builds cannot provide the .NET Framework 4.7.2 reference assemblies, WinForms behavior, x86 COM interop, Crystal ActiveX, or the original OCX runtime behavior.

Install:

- Windows 10 or Windows 11 x64
- Visual Studio 2022 Build Tools
- .NET Framework 4.7.2 Developer Pack
- .NET Framework 4.7.2 runtime
- SAP Crystal Reports runtime matching the original application
- MSFlexGrid COM/ActiveX runtime
- Crystal ActiveX runtime
- DevExpress v19.1 WinForms assemblies
- DevComponents DotNetBar2
- Qios DevSuite Components
- TagitIce / TagitSDK runtime
- DevNet WhatsApp V2 runtime
- SQL Server client provider compatible with `System.Data.SqlClient`

Do not use `net8.0-windows` for the fidelity build. It is acceptable only for a non-fidelity smoke port.
