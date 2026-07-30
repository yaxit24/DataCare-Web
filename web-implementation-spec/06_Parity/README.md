# Parity & Verification Methodology

How we **prove** the web app reproduces the desktop (the golden master) — the acceptance contract
that gates every module to "done". Requirements: Req 21 (parity verification), Req 22 (phased delivery).

## 1. Definition of parity

> For the same input data, the web app persists **the same rows** (header/detail/ledger/stock/tax),
> computes **the same values** (to the desktop's rounding precision), and produces **the same report
> datasets** as the desktop. When they differ, the difference is **recorded**, not silently accepted.

The desktop is the source of truth. The authoritative data is the SQL Server year backups
(`unified/database/backups/` — restore Next24 etc.).

## 2. The four verification tiers

| Tier | What | How | Gate |
|---|---|---|---|
| **Tier-1** | Pure logic (calc, posting, GST split, numbering) | unit tests with golden vectors (`packages/core/test`, `modules/*/test`) | all green |
| **Tier-2** | A module against a real Postgres | live integration scripts (`apps/api/integration/*.live.mjs`) on a dedicated `e2e` tenant | all green |
| **Tier-3** | End-to-end through the API/UI | login → select → create voucher → verify rows + trial balance still ties | green + Dr=Cr |
| **Tier-4** | **Golden-master parity** vs SQL Server | restore backup; recompute/compare via `packages/parity` + `apps/api/integration/xdb_diff.mjs`, `compute_parity.live.mjs` | matrix matches |

A module is **parity-certified** only when its Tier-1–3 pass **and** its Tier-4 matrix matches (where
a golden-master dataset exists), **and** the global trial balance still nets to zero.

## 3. Golden-master (Tier-4) mechanics

- Restore the desktop year DB into **Azure SQL Edge** (arm64 Docker image already pulled).
- `xdb_diff.mjs` builds a **data-fidelity matrix**: for each table, row counts, column presence, and
  Σ of key numeric columns (web Postgres vs SQL Server). Proven baseline: 141/141 cols, 371/372 Σ.
- `compute_parity.live.mjs` re-runs invoice/voucher computation and compares persisted totals. Proven: 190/190 invoices.
- `packages/parity` is the diff engine (field-level mismatch reporting). When a field differs it
  records the **inputs + the differing field** (Req 21.4) — never auto-rounds the gap away.

## 4. Per-module acceptance gate (the DoD checklist)

Each module's `03_Modules/<module>/` deep-dive ends with **Parity criteria**. The gate to mark a
module done:

- [ ] Persisted **row-set** matches desktop for representative vouchers (header, detail, sub-detail).
- [ ] **Ledger** `AC_DATA` legs match (accounts, Dr/Cr, `LEDR_KEY`, `BOOK_NAME`, `IT_TYPE`); ΣCR=ΣDR.
- [ ] **Metal (fine)** legs balance independently where applicable (Req 13.5).
- [ ] **Stock** movements + tag state match; delete restores stock + writes `DELETE_DATA`.
- [ ] **Tax** rows (`TAX_DATA`) match the desktop shape (CGST+SGST intra / IGST inter).
- [ ] **Computed values** (fine, labour, totals, round-off) match to precision (2dp money / 3dp weight-fine, HALF-UP).
- [ ] **Report datasets** equal the corresponding `.rpt` dataset for the scope.
- [ ] Global **trial balance** still nets to zero after the module's vouchers + deletes.

## 5. Per-module gate status

| Module | Doc | Tier-1/2/3 (per HANDOFF) | Tier-4 golden | Blocking parity risks (see §6) |
|---|---|---|---|---|
| Sales | 📋 | claimed green (190/190 compute) | partial | satellite rows (loyalty/UPI/card/rojmel) folded/omitted |
| Purchase | 📋 | claimed green | partial | web missing PR_IDTL/BAR_*/lots/TOUCH_MAST/ROJ_MEL_DATA |
| Inventory/Tags | 📋 | claimed green | partial | onHand omits FINE/full MAIN_STOCK net; 6 stock-write stamp bugs |
| Manufacturing | 📋 | claimed green | partial | MfgLedger source parity (MFG_ISU_REC vs KR_DETL) |
| Dhrn | 📋 | claimed green | pending | interest rounding (banker's vs HALF-UP); debits generic 'DHRN' not borrower; UNCHAK netting |
| Finance | 📋 | claimed green | pending | cash-limit→PAN rule ambiguity; payments PAY_DATA vs CASH_DATA; ROJ_MEL_DATA omitted |
| Accounting | 📋 | claimed green (Dr=Cr) | partial | mid-year TB tie needs off-ledger closing stock (book 999) |
| GST/E-Invoice | 📋 | GSTR-1 11/11; IRN payload | blocked | GSP creds external blocker; IRN field map confirm |
| Masters | 📋 | CRUD green | n/a | **no update path** in generic engine; MS_YEAR/COMPANY seeding unbuilt |
| Membership/Bullion/Tour | 📋 | partial | pending | VP & GOLD_BOOK semantics uncertain; tour book-name mismatch |
| Reports | 📋 | 16 built | partial | many datasets pending; closing-stock caveat |
| Utilities/Settings/Integ. | 📋 | wired | n/a | device-bound (web-cam/HDD/OLocker) not portable |

## 6. Consolidated parity-risk register

Gathered from the module deep-dives' §11 "open questions". Resolve each before final certification;
most need the **Docker SQL-Server golden-master pass** to confirm authoritative columns/values.

| # | Risk | Module | Action |
|---|---|---|---|
| R1 | `onHand` returns only pcs/gwt/nwt (no FINE, not full signed `MAIN_STOCK`) vs Req 14.4 | Inventory | implement signed-net incl. fine query |
| R2 | 6 stock-write stamp bugs (BOOK_NAME/DATA_TYPE/TBL_CODE/BAR_IDTL/INOUT/ENTRY) | Inventory | fix stamps to desktop values |
| R3 | Dhrn interest rounding (.NET banker's/ToEven vs web HALF-UP) + 0dp cash/3dp metal | Dhrn | match desktop rounding per loan type |
| R4 | Dhrn debits a generic `DHRN` account, desktop debits the borrower `AC_CODE` | Dhrn | post to actual borrower account |
| R5 | `ROJ_MEL_DATA` day-book rows omitted by several web modules | Sales/Finance/Purchase | add day-book writes |
| R6 | Purchase web omits `PR_IDTL`, `BAR_*`, `ITM_LOT_DETL`, `TAG_SET`, `TOUCH_MAST` | Purchase | complete stock-in/tag-lot writes |
| R7 | Cash-limit→PAN: desktop cash-ceiling-block vs sales PAN-gate vs web merged rule | Finance | ADR + align |
| R8 | Generic master engine has **no update path** | Masters | add update (Req 8.4) |
| R9 | `YEAR_MAST` key (CO_CODE,CO_YEAR,YEAR_MONTH) vs web omitting YEAR_MONTH | Masters | recover key via golden master |
| R10 | GSP e-invoice creds (aspid/password/Gstin/…) unavailable | GST/E-Invoice | external blocker — wire on creds |
| R11 | VP / GOLD_BOOK semantics uncertain | Bullion/VP | decompile-confirm before build |
| R12 | `SRNO_MAST` per-book/per-year numbering columns not recovered | Numbering | golden-master column recovery |
| R13 | Many money/weight columns stored FLOAT in desktop; types code-recovered | All | confirm NUMERIC precision per column |
| R14 | Closing-stock held off-ledger (book 999) until `Ac_Final` → mid-year TB won't tie raw | Accounting | replicate finalization step |

## 7. Regression discipline

- Live integration suites run on a dedicated **`e2e` tenant** so they never touch demo data
  (verified `SL_DATA`/`AC_MAST`/`LOGIN` unchanged before/after).
- After every module change, re-run the module's live suite **and** re-assert the global trial balance.
- Keep `project-memory/parity/latest.json` per module updated with the last Tier-4 result.
