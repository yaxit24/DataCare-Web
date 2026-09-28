# Exact-Parity Implementation Plan (DataCareNext desktop → web)

_Authored 2026-07-27. Every count in §1–§2 was re-measured this session from
`project-memory/parity/DESKTOP-WEB-PARITY-MATRIX.json` (regenerated after the melting batch) and from the
working tree. This plan supersedes nothing: it is the execution sequence that turns the current
engineering-test state into **G5 desktop-compared** and **G6 production-certified** parity._

Authoritative source of truth for behavior remains the decompiled desktop:
`unified/src/csharp/DataCareNext/*.cs` (204 forms), the catalogs under `project-memory/catalogs/`,
`unified/reports/*.rpt` (255), and the real SQL Server databases under `SqlData/`.
Where an artifact is not extracted, the plan says **which tool extracts it** before implementation starts.

---

## 1. Verified baseline (what exists today)

| Dimension | Measured value | Source |
|---|---|---|
| Matrix rows | 720 (204 forms, 146 tables, 275 reports, 57 settings, 13 shortcuts, 25 invariants) | matrix JSON |
| API routes declared + startup-classified | 290 | matrix JSON / `routePolicy.test.ts` |
| Prisma models / mapped tables | 169 / 169 | matrix JSON |
| Migrations (immutable history) | 9, latest `20260727030000_melting_mfg_linkage`; live drift = 0 (`prisma migrate status` + `migrate diff --exit-code` output retained at `project-memory/parity/evidence/2026-07-27-migration-drift.log`) | that log |
| RLS | 169/169 ENABLE + FORCE with write checks | `packages/db/test/verify_runtime.sql` |
| API tests | 56 files / 293 tests (forced, uncached, both DB gates on) | Turbo run this session |
| Frontend pages | 91; browser smoke covers auth→sales→4 repair stages→repair images→MLT PRO→physical stock→logout | `apps/web/test/browser.smoke.mjs` |
| Desktop form layouts mined | 175 layout asset files → 163/204 distinct form IDs (79.9%) | matrix JSON |
| Report specs in web | 254 report specs vs **275 report obligations** | matrix JSON |
| Gate reality | **G5 desktop_compared = not_started for all 720 rows; G6 production_certified = not_started for all 720 rows** | matrix CSV |

Gate status distribution that actually matters:

- **Forms (204):** implemented `in_progress` 183, `not_started` 21. Tested `in_progress` 88, `not_started` 116.
- **Tables (146):** tested `in_progress` 44, `not_started` 102.
- **Reports (275):** 253 implemented-in-progress (252 of them with no test evidence, 1 in progress), **20 blocked** (referenced `.rpt` absent), 2 not started.
- **Settings (57):** only 6 have any test evidence (`LBR_TYPE`, `LOCK_DATE`, `TAX_ROF`, `DHRN_INT_TYPE`, `TRAD_FINE`, `TAX_CODE`).
- **Shortcuts (13):** `F1`, `Enter`, `Escape`, `Ctrl+Enter` in progress; **`F2 F3 F4 F5 F7 F8 F9 F11 F12` not started**.
- **Invariants (25):** 6 passed/passed. 19 remain (list in §3.E).

---

## 2. The nine parity gap classes

Ranked by how much they block "the web behaves like the desktop".

| # | Gap class | Size | Why it blocks exact parity |
|---|---|---|---|
| G-1 | **Voucher lifecycle is create+delete, not create+edit+delete** | **50 of 61** transaction forms have a create route but **no PUT**; only 3 have the full lifecycle verified in the working tree: `TR_MLT_PRO` (`/melting`), `TR_PHYSTK` (`/stock/physical-stock`), `TR_REP_REC` (four repair books, `routePolicy.ts:220-246`). `TR_INOUT` is **not** full-lifecycle — `/inout/fine` declares only POST + DELETE (`routePolicy.ts:217`); the matrix credits it a PUT only through an over-broad `/stock` prefix mapping (`build_parity_matrix.py:340-343`), which A-1 fixes | The desktop opens any voucher by number and re-saves it in place (delete write-set → rewrite, preserving `MAIN_USER`/`VCH_TIME`/hidden number). Web users cannot edit at all. |
| G-2 | **8 high-severity transaction forms have no web write path** | `TR_VP`, `TR_VP_ADJ`, `TR_GOLD_BOOK`, `TR_LOCT_AMT`, `TR_OTH_COMM`, `TR_WH_SALE_RTN`, `TR_PR_SL_UAE`, `TR_SALE_RTN_UAE`. The matrix lists 9 `no-current-evidence` transaction rows, but the ninth (`TR_REP_REC`) is a **measurement defect**, not a missing workflow — see G-9 | Whole desktop workflows (rate-cut/VP parcel, gold book, location amount, other commission, wholesale return, UAE VAT sale/return) are absent. |
| G-3 | **Form depth: layout/validation/calc/keys not mined for ~150 flagship forms** | layout coverage 163/204; `InitializeComponent` geometry unmined (`TR_SALE` = 141 `.Location` calls) | Field order, tab order, grid column order/width, enable/disable rules, per-field validation messages and F-key wiring are the visible "feels like the desktop" layer. |
| G-4 | **F-key/keyboard surface incomplete** | 9 of 13 shortcuts not started | Desktop is keyboard-first: F2 save, F3 find, F4 LOV/edit, F5 refresh/rate, F7/F8/F9 workflow actions, F11/F12 print/exit (exact map to be confirmed per form from source). |
| G-5 | **Settings semantics unproven** | 51 of 57 `CO_SET`/config flags have no test | Desktop behavior forks on these flags (rounding, fine policy, labour type, one-form mode, tag/report options). Untested flags = unproven behavior. |
| G-6 | **Report/document fidelity** | 275 obligations; 20 `.rpt` missing; Crystal geometry unread for all 255 | Bills/vouchers/labels/passbooks *are* the deliverable for shop users. Data contract known (`rpt_specs.json`, 53,520 field refs); pixel geometry is Windows-locked. |
| G-7 | **Invariant closure + real DB coverage** | 19 invariants open; 102/146 tables untested | Numbering concurrency, period lock on every path, metal/money ledger balance, signed stock, tag single-consumption, server reversal, atomicity, rounding, GST, bill outstanding. |
| G-8 | **Operational/hardware/integration certification** | hardware bridge `not_started`; observability/backup/DR/external services in progress | Scales, scanners, webcams, printers, rate feed, e-invoice, SMS/WhatsApp send-log; plus load, DR drill, cutover. |
| G-9 | **Measurement integrity (the matrix mis-credits real work in both directions)** | Under-credit: `TR_REP_REC` row shows `routes=0 pages=[] tests=[]` although four repair lifecycles, four pages and passing `repairReceipt*/repairImage` tests exist. Over-credit: `TR_INOUT` is credited a PUT it does not own, via a `/stock` prefix mapping | If the instrument is wrong, parity cannot be certified. The generator's form→web mapping must be corrected **before** any batch counts are quoted, and locked with a self-check. |

---

## 3. Workstreams

Each workstream states: objective → authoritative desktop input → work items → acceptance evidence.
"Acceptance evidence" is what must exist in the repo before the matrix may move a gate.

### A. Measurement integrity (do first — 1 batch)

**Objective:** the matrix credits exactly what exists, and refuses to under- or over-credit.

Work items:
1. Fix `project-memory/parity/build_parity_matrix.py` form→web mapping in **both** directions:
   - **Under-credit:** `TR_REP_REC` → `/txn/repair-receipt`, `/txn/repair-karigar-issue`,
     `/txn/repair-karigar-receipt`, `/txn/repair-customer-issue`, the `/repair-*` routes
     (`routePolicy.ts:220-250`), `modules/repair/*`, `repairReceipt.test.ts`, `repairReceipt.db.test.ts`,
     `repairImage.test.ts`; `TR_PHYSTK` → physical-stock lifecycle + `physicalStock.db.test.ts`; confirm
     `TR_MLT_PRO` credit includes `meltingPro.db.test.ts` and `meltingParity.test.ts`.
   - **Over-credit:** narrow `TR_INOUT` to its own `/inout` surface (`build_parity_matrix.py:340-343` currently
     also maps `/stock`, so it inherits physical stock's PUT although `/inout/fine` declares only POST + DELETE).
   - Then **re-derive and re-publish the G-1/G-2 counts from the fixed generator**. The 50 / 8 / 3 split in §2 is
     the corrected working-tree figure and must be reproduced by the tool, not carried forward by hand.
2. Add a generator self-check: every declared API route must map to ≥1 form row, and every form row with
   frontend files must map to ≥1 route or be explicitly classified; the generator fails on orphans.
3. Add a per-form **behavior contract** file convention `project-memory/contracts/<FORM>.contract.md`
   (fields, focus order, validations with exact desktop message text, calc formulas, write-set table+column
   list, reversal rule, report hooks). G2 ("understood") may only move to `passed` when this file exists and
   cites desktop line numbers.
4. Regenerate the three artifacts; assert route universe (currently 290) and model count (169) as before.

Acceptance: generator self-check passes; `TR_REP_REC` shows non-empty web evidence; row/route/model counts printed and retained.

### B. Extraction completion (2–4 batches, macOS-only except §B5)

**Objective:** nothing is implemented from assumption; every rule is traceable to extracted desktop evidence.

1. **`InitializeComponent` layout parser** (new tool, macOS): parse `.cs` for `Location/Size/TabIndex/Text/
   MaxLength/ReadOnly/Enabled`, grid column definitions and their order, per-control event wiring; emit
   `project-memory/catalogs/layouts-code/<FORM>.initcomp.json`. Target the ~150 forms whose layout is in code,
   starting with the batch order in §4 (sales, purchase, tag, mfg families).
2. **Per-form logic mining**: for each form in the current batch, extract validations, calculations, inline SQL,
   `KeyDown`/`KeyPress` VK handlers, timers, and the exact write-set order. Fill the 32 rows currently missing a
   logic spec (mostly infra classes `Cls*`, `AuthClass`, `Translator`, `OlockerService` — these are candidates for
   documented **waive/absorb**, not implementation).
3. **NextEmp decompile** (`ilspycmd unified/binaries/NextEmp.exe`) to settle the bulk-messaging/`MSG_MAST`
   send-log surface before the integrations workstream.
4. **Authoritative desktop build pinning + version diff** (macOS): `NextDm` decompiles to the same
   `DataCareNext` namespace with **0 unique forms but 123 version-drifted files**
   (`UNEXTRACTED-INVENTORY.md:30,41,69`). Diff the 8 shipped EXEs, pin **one authoritative newest build** per form,
   and record it in each contract file, so no rule is ported from a stale variant. Confirm the newest-only /
   regulatory forms (`TR_FN_INOUT`, `RP_STOCK_VALUE`, `UT_PWD_UPDATE`, `OlockerService`, `PolicyModels`,
   `UT_E_INVOICE`, `TR_UPI_REC`, `TR_PR_SL_UAE`, `TR_SALE_RTN_UAE`, `RP_HUID`) against the pinned build.
5. **Crystal geometry (Windows-only)**: run the retained procedure in
   `project-memory/parity/WINDOWS-RPT-EXTRACTION-GUIDE.md` (GitHub Actions `windows-latest` + RptToXml) to produce
   one XML per `.rpt`; commit under `project-memory/catalogs/rpt-xml/`. Also **locate the 20 missing `.rpt`**
   (`aprbillimg, balzoom, bankadj, billwiseos, empdaysumm, empsumm, franchisebill, jdterskt, jdtvch, krisureport,
   krrecreport, loctamtvch, mainacsumm, mltingisu, purcquot, reminderschm, remindervch, salesrtna4print,
   vpparcelbill, whquotation`) from another installation; until found they stay `blocked`, not `in_progress`.
6. **Image/asset store**: expand `AllImage.rar`, read `NextImage.mdf`, decide the web storage mapping
   (existing `REP_IMAGE` pattern is the precedent), and confirm `KAP139.TTF`/Code-39 font needs from the RPT XML.
7. **Remaining data/config/template artifacts** (macOS): extract or formally waive — `unified/templates/output.xlsx`
   (Excel export/import template), `unified/database/backups/NextMain.BAK` (global/multi-company data),
   `unified/config/SqlName_*.txt` (Next23/24/25 DB switching, image path, Windows-vs-SQL auth mode) and
   `unified/config/AuthToken.txt` (licensing gate, referenced by name only — never reproduce the token).
   Each item gets either a web equivalent or a recorded waiver with rationale.

Acceptance: new catalog files exist per form in scope; extraction gaps for that batch are zero before code is written.

### C. Voucher lifecycle parity — G-1 (largest workstream, 8 batches)

**Objective:** every transaction form supports the exact desktop lifecycle: **new / open-by-number / edit-in-place /
delete-with-audit / print**, under period lock, with server-derived write sets.

The reference implementation already exists and is independently reviewed: `modules/manufacturing/meltingPro.ts`
and `modules/stock/physicalStock.ts`. Both encode the desktop pattern:

```
resolve configured book (MAIN_BOOK / BOOK_TBL_NAME) → fiscal-year + period-lock check on requested date
→ (edit) load persisted header, re-check lock on persisted date, preserve MAIN_USER / VCH_TIME / hidden number
→ delete exact write-set (no DELETE_DATA on edit) → re-insert full write-set incl. TEMP_BOOK_DATA + REMARK_DATA
→ (delete) audit each live detail row into DELETE_DATA exactly once
→ all item metadata resolved from ITEM_MAST (never from the request)
```

Every batch below must reproduce that contract for its family, plus the family-specific stock/ledger/tax legs.

| Batch | Forms (desktop LOC) | Family-specific parity risk |
|---|---|---|
| C1 Sales core | TR_SALE (21 587), TR_SALE_HM (15 354), TR_WH_SALE (18 008), TR_SL_EBILL (9 955), TR_SALE_LBR (12 300) | GST split, unfixed-rate gate, old-gold `SL_PR_DETL`, bill outstanding, tag consumption, `SRNO_MAST` |
| C2 Sales adjuncts | TR_TOUR_SALE, TR_TOUR, TR_TOUR_ORD, TR_BUL_SALE, TR_BUL_BOOKING, TR_FINE_SL_PR, TR_SL_PR_ITEM, TR_PR_SL_HEDG | tour stock custody, bullion fine legs, hedge/rate-cut linkage |
| C3 Returns & orders | TR_SALE_RTN (16 924), TR_SALE_ORD, TR_SL_ORD_ADJ | linked-order flag restore, `SL_ORD_ADJ`, `BILL_OS_DATA` reversal |
| C4 Purchase | TR_PURC (17 256), TR_PURC_HM, TR_OTH_PURC | purchase-fine gate, `BAR_DATA/BAR_DETL/BAR_IDTL`, tag creation |
| C5 Tag/stock | TR_TAG_OPBL (14 665), TR_TAG_SPLIT (12 941), TR_TAG_CAN, TR_TAG_WT_DIFF, TR_ITM_LOT, TR_ITM_OPBL, TR_FN_INOUT, **TR_INOUT** (add the missing `PUT /inout/fine/:vchNo`) | signed `MAIN_STOCK` identity `(TAG_NO,VCH_SRNO,IT_CODE)`, split/cancel serial algebra |
| C6 Manufacturing | TR_MFG_ISU_REC, TR_MFG_ITEM, TR_MFG_ORD_ISU, TR_MFG_ORD_REC, TR_MFG_WITH_LOT, TR_MFG_GHAT_REC, TR_MFG_KR_ISU_REC, TR_KR_ISU, TR_JDT_REC, TR_APR_ISU | `MFG_DETL`/`MFG_ISU_REC` linkage (`CHOL_IT_CODE`, `LAST_IR_TYPE`), lot flow, wastage/ghat |
| C7 Dhiran + finance | TR_DHRN_ISU, TR_DHRN_REC, TR_DHRN_INTREC, TR_CASH, TR_CARD_REC, TR_UPI_REC, TR_CONTRA, TR_AC_OPBL, TR_BILL_TO, TR_LEDR_ADJ, TR_EMP_JV | interest accrual variants, ΣDr=ΣCr, bill-to-bill allocation, contra `LD_CODE` |
| C8 Membership | TR_MEMB_ENT, TR_MEMB_ADJ | scheme instalment/point ledger |

Per-form work items (repeat for each form in a batch):
1. Read the desktop `SAVE`/`EDIT`/`DELETE`/`CLEAR_DATA` paths and record the **ordered write-set** in the contract file.
2. Add `GET /<resource>/:vchNo`, `PUT /<resource>/:vchNo`, `DELETE` where missing; register in `routePolicy` with
   independent view/edit/delete/print rights; extend `routePolicy.test.ts` route universe.
3. Extend the web page to: open by number, load state, edit in place, delete with confirm, and preserve loaded state
   when appending grid rows (the physical-stock precedent).
4. Add a restricted-role DB test proving create → read → edit → delete over **every owned table**, with:
   old-date lock rejection on persisted date, zero `DELETE_DATA` on edit, exact audit count on delete, snapshot
   preservation, and server-resolved master metadata.
5. Extend the browser smoke with one edit+delete scenario per batch (not per form) to keep runtime bounded.

Acceptance per batch: focused tests + DB tests green on port 55433; typecheck; build; browser smoke; **independent
review verdict PASS**; matrix regenerated with the new route count.

### D. Missing workflows — G-2 (5 batches)

Scope note: these are the **8 genuinely absent** workflows. `TR_REP_REC` is already implemented (four repair books
with full lifecycle) and belongs to workstream A as a measurement fix, not here.

| Batch | Forms | Notes |
|---|---|---|
| D1 | TR_VP (7 173) + TR_VP_ADJ (3 178) | Rate-cut/VP parcel: writes `RATE_CUT_DATA/ISU/ISU_REC`, `VP_ADJ_DATA`, `SL_IDTL`, `SL_ORD_ADJ`, `SL_PR_DETL`, `MAIN_STOCK`. Business decision pending on VP variants (§6). |
| D2 | TR_GOLD_BOOK (3 158) + TR_LOCT_AMT (3 989) | `DG_GOLD_DATA`, `LOCT_AMT` + `AC_DATA`/`ROJ_MEL_DATA`/`TEMP_BOOK_DATA`. |
| D3 | TR_OTH_COMM (4 924) | `PAY_DATA/PAY_DETL` + `TAX_DATA`; 31 grid columns, 22 calcs. |
| D4 | TR_WH_SALE_RTN (9 600) | Wholesale return: 150 grid columns, `TAG_IMAGE_DATA`, `RATE_CUT_ISU_REC`. |
| D5 | TR_PR_SL_UAE (11 067) + TR_SALE_RTN_UAE (11 445) | UAE VAT variants; confirm whether the deployment needs them before building (§6 decision). |

Also in this workstream: **masters/utilities not started** — `MS_HELP` (2 402), `MS_TASTING` (381), `UT_HDD` (769),
`UT_USER_REQUEST` (460), `UT_WEB_CAM` (281), `UT_WINDOW` (2 661); and an explicit, documented **waive/absorb**
decision for the six infra classes (`ClsItemList`, `Data`, `DcClass`, `DcPrintClass`, `Translator`, `OlockerService`)
with rationale recorded in the matrix instead of silent omission.

### E. Invariant closure — G-7 (3 batches, runs alongside C)

Close these 19 with real-DB evidence, then flip the matrix rows:

| Invariant | Blocker id | Required evidence |
|---|---|---|
| voucher-numbering | C3-numbering-concurrency | N-way concurrent create per scope, zero duplicates, delete-top reuse |
| period-lock | H2-period-lock-reversal | lock rejection on create/edit/delete/reversal, on **persisted** and requested dates, every form family |
| money-ledger-balance / posting-atomicity | QA-no-real-posting-tests | ΣDr=ΣCr per voucher and per reversal; injected failure leaves zero rows in every table |
| metal-ledger-balance / fine-policy | C4-workflow-fine-policy | per-workflow fine formula vectors from desktop source; gold/silver/fine ledgers independent |
| stock-signed-movement | C1-loose-stock | signed `MAIN_STOCK` for tagged *and* loose lines on every family |
| tag-single-consumption | H3-tag-concurrency | serialized double-issue attempt fails exactly once |
| server-reversal | C2-server-derived-reversal | reversal derived only from persisted state, satellite-aware, flags restored |
| rounding-policy | ROUNDING-policy | book/company rounding flags drive money and weight rounding (ties to §G) |
| gst-tax | QA-no-desktop-gst-comparison | recompute real desktop invoices through web engine (harness exists: `compute_parity.live.mjs`) |
| bill-outstanding | POSTING-bill-allocation | allocation + reversal lifecycle over `BILL_OS_DATA` |
| report-fidelity | H7 / H10 | §F |
| schema-migration-rls (test) | — | automated fresh-deploy + upgrade-path suite in CI |
| hardware-bridge / external-services / observability / backup-dr / qa-concurrency-migration | §H | §H |

Also raise table coverage from 44/146 tested toward full: each C/D batch must add its owned tables to the tested set,
which is the only honest way to close the remaining 102.

### F. Report & document fidelity — G-6 (4+ batches, gated by B5)

1. **Data contract first (macOS, no Windows needed):** for each report, bind the web report spec to the desktop
   `rpt_specs.json` field/table refs and prove **row-level equality against real desktop data** using the retained
   cross-DB harness (`xdb_diff.mjs`, `parity_report.mjs`). Target order: 97 CRITICAL bills/vouchers/labels/passbooks
   → 9 HIGH image-embedding → ~50 MEDIUM statutory → ~99 LOW analytic.
2. **Geometry second (needs B5 XML):** rebuild each critical document layout from the RptToXml geometry —
   sections, per-field Left/Top/Width/Height, fonts (incl. Code-39 and `KAP139.TTF` Gujarati), group/sort, page setup,
   subreports — through the existing `modules/reports/render.ts` + `reportEngine.ts` pipeline.
3. **Visual diff harness:** render desktop PDF vs web PDF for the same voucher and diff at a documented pixel/SSIM
   tolerance; retain both artifacts. This is the actual G5 gate for reports.
4. Close the 2 `not_started` reports (`SalesQuotation`, `TagStkIdtlRpt`) and keep the 20 absent ones `blocked` until located.

### G. Settings, keyboard and form-depth parity — G-3/G-4/G-5 (3–4 batches)

1. **Settings:** for each of the 51 untested settings, extract the desktop read sites, implement the fork server-side,
   and add a test that flips the flag and asserts different persisted output (the `MFG_ONE_FORM='Y'/'N'` melting test is
   the template). Prioritise: rounding (`TAX_ROF`, `LBR_ROF`, `ITM_RATE_ROF`), fine (`FINE_STK_TYPE`, `TRAD_FINE`),
   labour (`LBR_TYPE`, `LBR_RATE_GEN`), scope/format (`AC_LC_CODE_LEN`, `RATE_PAR`), workflow (`SL_ROW_CHANGE`,
   `OP_DHRN`, `OP_LOAN`, `LOAN_INT_TYPE`, `INT_DAY`, `INT_YEAR_DAYS`), device (`WEIGHT_PORT`), reporting (`TAG_RPT`, `LDR_SUMM`).
2. **F-keys:** derive the exact per-form key map from the desktop `KeyDown` handlers (do not guess), extend
   `components/GridKeyboard.tsx` + `focus.ts` with the missing global actions (F2 save, F3 find/open, F4 LOV/edit,
   F5 refresh/rate, F7/F8/F9 workflow, F11 print, F12 exit as confirmed per form), and add pure decision-table tests
   plus one browser assertion per key.
3. **Form depth/appearance:** using B1 output, align field order, tab order, grid column order/widths, read-only and
   enable/disable rules, and validation message text per form. Extend the existing form-layout coverage from
   163/204 toward 204.
4. **Interaction-shell / control semantics:** the desktop uses ~20 licensed DevExpress + DotNetBar controls
   (`UNEXTRACTED-INVENTORY.md:37,73`) whose behavior users depend on — XtraGrid (in-cell edit, column
   sort/filter/summary rows), ribbon/docking shell, XtraEditors LOV dropdowns, TreeList, PivotGrid, RichEdit,
   Spreadsheet. The web currently uses native inputs/tables. For each control class, either implement the
   behavioral equivalent or record an explicit **equivalence waiver** naming the desktop behavior dropped and the
   user-visible consequence. Silent divergence is not acceptable at G5.

### H. Operations, devices, integrations, cutover — G-8 (4 batches)

1. **Device bridge** (currently absent — no `modules/devices`): a local signed agent or WebSerial/WebUSB path for
   weighing scale (`WEIGHT_PORT` semantics from desktop), barcode scanner, webcam capture (`UT_WEB_CAM`,
   DirectShow equivalent), and label/bill printers. Network-exposed agent endpoints **must** be authenticated and
   bound to localhost by default; document the threat model before shipping.
2. **External services certification:** rate feed, e-invoice (`GenIRN`/`IRNData` payloads already ported), SMS ×3
   gateways, WhatsApp Cloud API **plus** the missing `MSG_MAST` send-log; add idempotency keys, retry/reconciliation
   reports, and sandbox-credential tests. Also settle the **unported integration tail**
   (`UNEXTRACTED-INVENTORY.md:39,77`): Firebase sync (`FireSharp.dll`), QR generation (`QRCoder.dll`), and the
   desktop Selenium/WebDriver WhatsApp fallback — each either ported or waived with a written rationale, since the
   desktop can still send when the Cloud API path is unavailable.
3. **Observability/backup/DR/perf:** structured logs with request+tenant correlation, metrics/traces, invariant
   alerts, offsite backup, **automated restore drill**, documented RPO/RTO, and a load profile matching shop peak.
4. **Cutover/migration:** promote `integration/import_real.mjs` from an ad-hoc script to a supported, resumable,
   validated migration tool (per-table row counts, Σ checks, referential validation, dry-run report, rollback plan)
   using the multi-year `SqlData/Next23/24/25` databases **plus `NextMain.BAK` global data and `NextImage.mdf`
   images**, honoring the `SqlName_*.txt` multi-year switching / image-path / auth-mode semantics, and using the
   retained `xdb-matrix.md` result (141 common tables, 372 Σ checks pass) as the regression baseline.

### I. G5 desktop-comparison harness — the actual parity gate (2 batches to stand up, then continuous)

This is what makes "exact parity" a measurable claim instead of an opinion. The foundation already exists in
`web/apps/api/integration/` and is currently **outside CI**:

- `import_real.mjs` — ETL of the real `Next24` SQL Server DB into the web schema.
- `xdb_diff.mjs` — per-table column coverage + per-numeric-column Σ diff (retained: `xdb-matrix.md`).
- `parity_form.mjs` — **per-voucher, per-column diff of a web-created voucher vs a desktop voucher**, which is
  exactly the G5 per-form gate.
- `parity_sweep.mjs` — per-form multi-table footprint certification.
- `compute_parity.live.mjs` — recompute real desktop invoices through the web calc engine and compare stored tax/total.
- `apps/api/src/modules/parity/golden.ts` — dependency-free golden vectors.

Work items:
1. Stand up a reproducible desktop-side environment (SQL Server/SQL Edge with the real DBs) as a documented,
   scripted fixture; sanitize data for retention.
2. Wire the harness into a **separate, gated CI job** with retained artifacts per run (per-form diff report,
   Σ report, PDF/screenshot pairs).
3. Define the G5 pass rule per form: zero column diffs outside the documented SKIP set (keys/timestamps), zero
   Σ diffs on owned numeric columns, PDF diff within tolerance, keyboard trace equal.
4. Only after a form's G5 artifact is retained may its `desktop_compared` row move off `not_started`.
5. Desktop UI-side comparison (screenshots/keyboard traces) needs a Windows runner with the desktop app + sanitized
   data — this is an external dependency (§6), not something the plan can fake.

### J. G6 certification (final)

Load/soak results, security review + pen-test findings closed, observability SLOs, backup/restore + DR drill evidence,
device/site UAT per shop, business-owner acceptance sign-off per module. Only then may any row reach
`production_certified = passed`.

---

## 4. Sequencing

Dependencies are real: A gates measurement, B gates every implementation batch, I gates every G5 claim.

```
Phase 0  A (measurement)  ──►  B1/B2 (layout+logic mining, rolling per family)
Phase 1  C1 C4 C5         ──►  sales/purchase/tag lifecycle (highest user volume)
         E (invariants)   ──►  runs inside C batches, closes as families land
Phase 2  C6 C7 C8 C2 C3   ──►  mfg, dhiran/finance, membership, adjuncts, returns
Phase 3  D1..D5           ──►  missing workflows (+ masters/utilities, waive decisions)
Phase 4  G                ──►  settings forks, F-keys, form depth/appearance, control-shell equivalences
Phase 5  B5 + F           ──►  Crystal geometry (Windows job) then report/document fidelity
Phase 6  H                ──►  devices, integrations, observability, backup/DR, cutover tool
Phase 7  I                ──►  desktop-comparison harness in CI, per-form G5 artifacts
Phase 8  J                ──►  load/security/UAT/sign-off → G6
```

Phase exit criteria (all must be objective, all must be retained):

| Phase | Exit criteria |
|---|---|
| 0 | generator self-check passes; no under-credited implemented surface; contract convention in place |
| 1 | sales/purchase/tag forms support open/edit/delete under lock; owned tables move to tested; numbering, stock-signed, tag-single, atomicity invariants pass with real-DB tests |
| 2 | remaining transaction families same; money+metal ledger balance and server-reversal invariants pass |
| 3 | zero transaction forms with `implemented = not_started`; every omission is an explicit documented waiver |
| 4 | 57/57 settings have a behavioral test; 13/13 shortcuts implemented+tested; layout coverage 204/204 |
| 5 | 97 critical documents rebuilt from real geometry with retained PDF diffs; 20 missing RPTs located or formally waived |
| 6 | device bridge certified on real hardware; integrations idempotent+reconciled; restore drill passes; cutover dry-run on real multi-year data |
| 7 | per-form G5 artifacts retained; `desktop_compared` moves only where artifacts exist |
| 8 | load/security/DR/UAT/sign-off retained; only then G6 |

---

## 5. Working protocol (non-negotiable per batch)

This is the protocol that produced the repair-image, physical-stock and melting batches, and it stays:

1. **Extract** the authoritative desktop behavior (source + catalogs). If missing, extract it first (§B).
2. **Write the contract** file with cited desktop line numbers; resolve ambiguities from source, not assumption.
3. **Implement** server-first: server is authoritative for master data, numbering, locks, and write sets; the UI may
   never be the source of truth for item identity/type, book policy, or amounts that the desktop derives.
4. **Migrations are additive and immutable**; new columns need `schema.prisma` + migration + `rls.sql` + drift check.
5. **Test**: pure kernel vectors → restricted-role real-PostgreSQL lifecycle (port 55433, never 5432) → route policy →
   browser scenario. Negative and adversarial cases are mandatory (unknown master, spoofed type, locked period,
   tenant isolation, concurrency).
6. **Validate**: prettier, `pnpm lint`, `turbo typecheck --force`, focused tests, forced uncached root suite with
   `RUN_DB_INTEGRITY_TESTS=1 RUN_DB_SECURITY_TESTS=1`, fresh build, browser smoke, Prisma drift = 0, RLS count.
7. **Independent review** by a reviewer without the implementer's context; `NEEDS_CHANGES` findings are fixed and
   re-reviewed before the batch closes.
8. **Regenerate the parity matrix** and update the frozen route assertion in the same batch.
9. **Never** move G5/G6, claim production readiness, pixel parity, or certification without the retained artifact.

Test-flake rule: when a browser assertion is racy, harden the **test** (poll for the observable state), never weaken
application behavior — as done for the post-`Ctrl+D` focus restoration this session.

---

## 6. Decisions and external inputs required (blocking, cannot be resolved from the repo)

| # | Needed | Blocks |
|---|---|---|
| 1 | Windows runner + Crystal runtime (GitHub Actions path documented) | B5, F2–F3, report G5 |
| 2 | A second complete installation containing the 20 absent `.rpt` files | those 20 report rows stay `blocked` |
| 3 | Desktop runtime + sanitized shop data for row/keyboard/PDF comparison | all G5 rows |
| 4 | Real shop hardware (scale/scanner/webcam/printers) + service sandboxes | device + integration certification, G6 |
| 5 | Business-owner rulings on Dhiran variants, VP/GOLD_BOOK behavior, rounding policy, book variants, and whether the **UAE** forms (`TR_PR_SL_UAE`, `TR_SALE_RTN_UAE`) are in scope | D1, D2, D5, rounding invariant |
| 6 | Confirmation of the per-form F-key map where desktop source is ambiguous | G-4 completion |
| 7 | Business decision on the DevExpress/DotNetBar interaction-shell equivalences (which control behaviors must be reproduced vs waived) | §G4 |

Already satisfied (listed in the matrix as external evidence, closed by retained work): the **safe project
PostgreSQL with seeded migration/RLS fixtures** — a disposable PostgreSQL 16 instance on port 55433 with all 9
migrations, `rls.sql` and the restricted `app_user` role is the standing validation environment
(`packages/db/test/verify_runtime.sql` proving 169/169 forced RLS; drift log in
`project-memory/parity/evidence/`). Keep it scripted and disposable; never use port 5432.

Ask these once per phase, in batch, rather than blocking mid-implementation.

---

## 7. Risk register

| Risk | Impact | Mitigation |
|---|---|---|
| Editing large voucher families (TR_SALE at 21.5k LOC) introduces regressions in posting/stock | High | One family per batch; real-DB write-set diff per owned table; independent review; forced root suite each batch |
| Crystal geometry never obtained | Reports cannot reach pixel parity | Keep data-contract parity (macOS-doable) decoupled from geometry; report status honestly as `blocked` |
| Matrix drift/over-credit | False parity claims | Generator self-check + frozen count assertions + independent review of the artifacts |
| Test suite runtime growth | Slower batches | Per-family browser scenarios, not per-form; DB tests gated by env flags in CI |
| Schema churn from many families | Migration risk | Additive-only migrations, drift check every batch, RLS recount every batch |
| Scope creep from infra classes | Wasted effort | Explicit waive/absorb decisions recorded in the matrix |

---

## 8. Definition of "exact parity" for this project

A unit is at exact parity only when **all six** hold, each with a retained artifact:

1. **G1 Extracted** — desktop source/layout/report geometry for the unit exists locally.
2. **G2 Understood** — approved contract file with fields, focus order, validations, calculations, write set, reversal.
3. **G3 Implemented** — reachable UI + API + DB + report + security behavior, server-authoritative.
4. **G4 Tested** — real-PostgreSQL lifecycle, authorization, concurrency, failure/atomicity, and browser coverage in CI.
5. **G5 Desktop-compared** — same-input desktop vs web run with zero unexplained row/column/Σ diffs, PDF within
   tolerance, and equal keyboard trace.
6. **G6 Production-certified** — load, security, observability, backup/restore/DR, device/site UAT, business sign-off.

Current honest position: **G1 broad, G2/G3/G4 partial and advancing, G5 = 0/720, G6 = 0/720.**
This plan's purpose is to move rows through 2→6 in reviewed, evidence-retained batches, in the order of §4.
