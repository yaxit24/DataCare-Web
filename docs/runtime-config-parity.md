# Runtime Config Parity

`DataCareNext_Source/Config/App.config` is not accepted as original runtime config proof. It targets `.NETFramework,Version=v4.8` and uses generic `DataCareNext` connection values.

Original binary evidence:

- `DataCareNext.exe` contains `Next19ConnectionString`
- `DataCareNext.exe` contains `MORVIN\\SQLEXPRESS`
- `DataCareNext.exe` contains `Initial Catalog=Next19`
- `NextDm.exe` contains the same settings strings

Required recovery sources:

- Original deployed `DataCareNext.exe.config`, if present
- Original deployed `NextDm.exe.config`, if present
- Original registry/config files used by the app
- Original SQL Server/database backup
- Original report path configuration

Acceptance:

- Rebuilt app starts with the same config source as the original deployment.
- Connection string names and values match original deployment, or are deliberately changed only for test database access and documented as test-only.
- Report path points to the recovered full `Report` directory.
