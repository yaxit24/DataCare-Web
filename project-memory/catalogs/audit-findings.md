# Task 1 — Completeness Audit Findings

Source: `tools/audit_completeness.py` → `completeness-manifest.json` (2026-06-28).
Totals: **933 artifacts — 830 present, 83 db_table missing, 20 report external-blocker.**

## CRITICAL: `01_Schema.sql` is materially incomplete
The DDL defines only **100 `CREATE TABLE`** statements, but the table inventory lists ~179.
**~69 real, core tables are NOT in the DDL** and MUST be recovered (Task 3) from the live
backups (`database/backups/Next24.mdf`, `Next25.mdf`, `NextMain.BAK`) via a Linux Docker
`mssql` container. These include the heart of the ERP:

`AC_DATA` (ledger), `AC_MAST`, `AC_GROUP`, `AC_MAST_SRNO`, `SL_DATA`, `SL_DETL`, `SL_IDTL`,
`SL_ORD_DATA/DETL/IDTL`, `SL_PR_DETL`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `TAG_MAST`, `TAG_DATA`,
`TAG_PRINT_DATA`, `TAX_MAST`, `TAX_DATA`, `LOGIN_MAST`, `USER_SET`, `SRNO_MAST`, `YEAR_MAST`,
`EMP_MAST`, `GROUP_MAST`, `MAIN_STOCK`, `KR_DATA/DETL/IDTL`, `LOAN_ISU_DATA`, `LOAN_REC_DATA`,
`RATE_CUT_DATA/ISU/REC/ISU_REC`, `APR_DATA/DETL/IDTL`, `BAR_DATA/DETL/IDTL`, `BAR_CAN_*`,
`BOOK_DATA/DETL/IDTL`, `CASH_DATA`, `OP_DATA/DETL`, `LEDR_AC_DATA`, `ADD_MAST`, `AREA_MAST`,
`BAL_GR`, `COL_MAST`, `CONV_MAST`, `CO_SET`, `IMAGE_DATA`, `ITM_OPBL`, `LBR_ISU_DETL/IDTL`,
`LBR_REC_DETL`, `LOCT_MAST`, `MENU_DATA`, `PRINT_MAST`, `PRODUCT_MAST`, `STATE_MAST`,
`TABLE_MAST`, `TEMP_BOOK_DATA`.

## String-dump NOISE in database_tables.txt (NOT real tables — exclude in Task 3)
`Bar_Idtl` (case dup of BAR_IDTL), `Detail`, `DistinctTags`, `GroupCount`, `Please`, `RowLimit`,
`StockData`, `This`, `User`, `WebhookInbox`, `Win32_Process`, `app_ChatMessages`, `permantley`,
`sys`  → ~14 false positives (CTE aliases / system names / sentence fragments from string dumps).

## 20 reports referenced in code, absent from unified/ AND searched Raw_Source
`aprbillimg, balzoom, bankadj, billwiseos, empdaysumm, empsumm, franchisebill, jdterskt, jdtvch,
krisureport, krrecreport, loctamtvch, mainacsumm, mltingisu, purcquot, reminderschm, remindervch,
salesrtna4print, vpparcelbill, whquotation` (.rpt)

**Task 2 actions:** widen Raw_Source search (e.g. `~/Desktop/next/extracted`, `next/source`,
.exe embedded resources) before confirming as true external-blockers; some may be legacy/unreachable.

## Layout contract
`layoutCheck` in the manifest = all canonical subdirs present (see `docs/canonical-layout.md`).

## Task 2 result (report reconciliation) — 2026-06-28
- Tool: `tools/reconcile_reports.py` (dry-run). Searched Raw_Source roots `imodule-extracted/`
  (excl. `unified/`) and `~/Desktop/next/` — **255 distinct `.rpt` indexed**.
- **copied=0, conflicts=0, stillMissing=20.** The "200+ missing reports" from the legacy
  `report-md-review.md` was STALE — those were already collected into `unified/reports/`.
- The 20 reports are **CONFIRMED external-blockers** (Req 2.4): referenced in decompiled code
  but no `.rpt` exists in any available source. Likely legacy/unreachable menu items or reports
  whose templates were never shipped with the source we have. Documented; not collectible.
- All other copyable categories (lib/resx/font/config/source_form) are 100% present.
- Conclusion: `unified/` is COMPLETE w.r.t. available file artifacts. The only true content gap
  is the **schema DDL** (≈69 core tables) → recovered in Task 3, not by file collection.
- Full detail: `report-reconciliation.json`.
