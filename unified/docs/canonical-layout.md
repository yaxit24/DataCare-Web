# Canonical `unified/` Layout Contract

The completeness audit (`tools/audit_completeness.py`) validates this contract
(`layoutCheck` in the manifest). Task 5 finalizes any reorganization to match it.

| Path | Contents |
|---|---|
| `src/csharp/` | Primary decompiled C# (golden master = DataCareNext, Jun 2026) |
| `src/csharp_nextdm/` | NextDm variant decompiled C# |
| `src/vbnet/` | Original VB.NET source |
| `reports/` | Crystal `.rpt` report templates |
| `database/schema/` | SQL Server DDL (`01_Schema.sql`) |
| `database/backups/` | SQL Server `.bak/.mdf/.ldf` (golden-master data) |
| `database/csv/` | GST export CSVs |
| `libs/` | Third-party DLLs (devexpress, crystal, dotnetbar, interop, other, webdriver) |
| `resources/` | Embedded `.resx` (DataCareNext, NextDm) |
| `config/` | App/runtime configuration |
| `fonts/` | Custom fonts (barcode Code39, locale) |
| `images/` | Image assets |
| `templates/` | Excel/data templates |
| `extraction_metadata/` | Analysis artifacts (categorized, audit, string dumps, pe_info) |
| `tools/` | Build & audit scripts (incl. `audit_completeness.py`) |
| `docs/` | Documentation |
| `MANIFEST.md` | (Task 5) human-readable completeness sign-off |

Run the audit:
```
cd unified && python3 tools/audit_completeness.py
# -> ../project-memory/catalogs/completeness-manifest.json
```
