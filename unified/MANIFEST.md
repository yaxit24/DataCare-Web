# DataCareNext `unified/` — Completeness Sign-off (Phase 0 GATE)

**Date:** 2026-06-28 · **Golden master:** `DataCareNext.exe` (Jun 2026) · **Audit:** `tools/audit_completeness.py`

## Status: PHASE-0 GATE PASSED for starting the web rebuild
The `unified/` resource center is complete for all available **file artifacts**; the data model and
per-form business logic are catalogued; the only residual gaps are documented external-blockers that
do **not** block the web build (which is gated on the catalogs, per ADR-0001).

## Completeness evidence
| Category | Present | Missing | External-blocker | Notes |
|---|---:|---:|---:|---|
| Reports (.rpt, code-referenced) | 218 | 0 | 20 | 20 confirmed unreachable (no .rpt in any source) |
| DB tables (vs DDL) | 96 | 83* | — | *DDL incomplete; recovered via code → see catalog |
| Source forms (.cs) | 204 | 0 | — | |
| Resources (.resx) | 165 | 0 | — | |
| Libs (.dll) | 135 | 0 | — | |
| Config | 10 | 0 | — | runtime conn-string is external-blocker (documented) |
| Fonts | 2 | 0 | — | Code39 barcode + locale |
**Manifest:** `project-memory/catalogs/completeness-manifest.json` (933 artifacts; 830 present).
**Verifier (CI gate):** `python3 tools/verify_manifest.py` → 830 present artifacts exist, layout intact.

## Catalogs (the web-build source of truth)
- **Data model:** `project-memory/catalogs/data-model.json` — 162 tables / 4666 columns
  (100 DDL + 62 recovered from decompiled C#); 7 unresolved flagged for optional Docker pass.
  ERD: `catalogs/erd-core.md`.
- **Business logic:** `project-memory/catalogs/forms/` — 204 per-form specs;
  `module-map.json` (txn 61 / report 45 / master 33 / utility 22 / other 43; 57 txn w/ posting);
  curated `forms/curated/TR_SALE.md` & `TR_PURC.md`.
- **Findings:** `catalogs/audit-findings.md`; **build blocker:** `catalogs/build-blocker-report.md`.

## Known external-blockers (non-blocking for web)
1. Desktop reference build (Windows + vendor DLLs) — see `build-blocker-report.md`.
2. 20 unreachable report templates (referenced in code, no `.rpt` anywhere).
3. Original runtime connection config (`Next19`/`MORVIN\\SQLEXPRESS`).

## Verify the gate
```
cd unified
python3 -m unittest discover -s tools/tests -p 'test_*.py'   # 19 tool tests OK
python3 tools/verify_manifest.py                             # OK: present artifacts intact
```
**→ Phase 1 (web foundation) may begin.** Canonical layout contract: `docs/canonical-layout.md`.
