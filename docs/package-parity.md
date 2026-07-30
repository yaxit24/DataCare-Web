# Package Parity

Original:

- `Next_1106.zip`
- `DataCareNext.exe` SHA-256: `c85f93fd336853a2a639c6452b47748290a1dddb214e2fdf3fc78f47bc0ca6c8`
- `NextDm.exe` SHA-256: `e0fb1bf470753b88b6cb6d4c15cdf281f4e5739984d53f29351301faefc9e3da`
- Package `.rpt` count: 36

Rebuilt:

- `dist/Next_1106-rebuilt/DataCareNext.exe`
- `dist/Next_1106-rebuilt/NextDm.exe`
- Rebuilt package `.rpt` count: record after `Report/` recovery

Notes:

- Rebuilt hashes are not expected to equal original hashes because decompilation/recompilation changes PE metadata, timestamps, layout, and compiler output.
- Runtime acceptance is based on manifest resources, resolved dependencies, report template availability, UI behavior, database behavior, and workflow parity.
