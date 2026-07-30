# Next_1106 Target Artifacts

The original package `Next_1106.zip` contains two .NET assemblies:

- `DataCareNext.exe`
- `NextDm.exe`

Both assemblies report assembly name `DataCareNext` and version `1.0.0.0`, but they are not identical:

- `DataCareNext.exe` has 204 extracted app source files.
- `NextDm.exe` has 199 extracted app source files.
- `DataCareNext` adds `OlockerService.cs`, `PolicyModels.cs`, `RP_STOCK_VALUE.cs`, `TR_FN_INOUT.cs`, and `UT_PWD_UPDATE.cs`.

For exact package parity, rebuild and package both executables.
For single-app parity, `DataCareNext.exe` is the primary target because `report.md` audited that executable and it contains the additional forms/services.

Acceptance must state which target is being tested:

- `DataCareNext` primary runtime parity
- `NextDm` runtime parity
- full `Next_1106.zip` package parity
