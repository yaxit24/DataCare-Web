# Reference-Build Attempt & Blocker Report (Task 5)

## Outcome: reference desktop build is an EXTERNAL BLOCKER on this (macOS) host — and is NON-BLOCKING for the web rebuild.

### What was attempted / evidenced
- The decompiled app targets **.NET Framework 4.7.2, x86, WinForms** — a Windows-only toolchain.
- It depends on proprietary vendor assemblies in `unified/libs/`: **DevExpress v19.1**, **SAP Crystal
  Reports** runtime, **DevComponents DotNetBar2**, and **COM interop** (MSFlexGrid, Crystal ActiveX).
- A prior build attempt is already on record: `build_errors.txt` (~14 MB) shows **thousands of
  unresolved third-party type errors**; `docs/report-md-review.md` states "the current project is
  not build-ready." Compilation stubs in `unified/stubs/` are smoke-test only, not runtime-faithful.
- Runtime config is unrecovered: binaries reference `Next19` / `MORVIN\SQLEXPRESS`
  (see `docs/runtime-config-parity.md`) — original deployed `.exe.config` not present.

### Why this does not block the web build
Per ADR-0001, the web rebuild is **derived from the catalogs**, not from a running desktop binary:
- `catalogs/data-model.json` (162 tables / 4666 cols) — the schema source of truth.
- `catalogs/forms/` + `module-map.json` (204 form specs) + curated `TR_SALE`/`TR_PURC` — the behavioral spec.
- `catalogs/completeness-manifest.json` — proves all file artifacts present (830) or external-blocker (20).
The golden master for parity (Task 8/21/30) is the **SQL Server data** (restored from
`database/backups/`), not a recompiled EXE.

### What would unblock a faithful desktop reference build (future, optional)
1. A Windows machine with Visual Studio 2019/2022 + MSBuild + .NET Framework 4.7.2 dev pack.
2. Licensed DevExpress v19.1 + Crystal Reports runtime installed/registered (COM).
3. Original deployed `DataCareNext.exe.config` (connection strings) + a restored SQL Server DB.
4. Follow `docs/WINDOWS_BUILD_GUIDE.md`; fix residual references; verify against `audit_next1106_parity.py`.

### Optional authoritative DB pass (Docker available, v29.4.0) — recommended before Task 7
Restore `database/backups/NextMain.BAK` / `Next24.*` in `mcr.microsoft.com/mssql/server` (Linux) and
dump `INFORMATION_SCHEMA.COLUMNS` to (a) resolve the 7 unresolved tables and (b) confirm authoritative
types for the 62 code-recovered tables, before generating the Prisma NUMERIC precision map.
