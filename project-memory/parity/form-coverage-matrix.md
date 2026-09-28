# In-depth desktop↔web coverage & workflow-footprint verification

_Generated 2026-06-29. Method: parsed all **204** desktop form catalogs for the exact tables each form writes/manages (INSERT/UPDATE + DELETE/reversed = the tables the form owns, from the decompiled `.cs`), and compared against the **75 tables the web actually writes** (grep of `INSERT/UPDATE/posting table:`). This is a depth check (does the web persist the same tables/workflow), not "is there a screen". Tool: `analyze_coverage.py`._

## Headline (honest)
The web reproduces the **financial spine exactly** (SL_DATA/PR_DATA/AC_DATA + balanced ledger + GST + 190/190 compute parity), but most transaction forms write only a SUBSET of the satellite tables the desktop writes. **No transaction form is 100% table-complete; 51/61 are partial.**

| Module | forms | full-data | partial | none(has tables) | no-core-table |
|---|---|---|---|---|---|
| transaction | 61 | 0 | **51** | 10 | 0 |
| master | 33 | 6 | 16 | 11 | 4 |
| report | 45 | 2 | 8 | 35 | 20 (read-only) |
| utility | 22 | 2 | 8 | 12 | 5 |
| other | 43 | 2 | 6 | 7 | 33 (classes) |

## The core gap — satellite tables on transactions
Flagship **TR_SALE** owns: SL_DATA, SL_DETL, SL_IDTL, AC_DATA **(web ✅)** + **TAX_DATA** (tax register), **BILL_OS_DATA** (bill outstanding), **MAIN_STOCK** (stock movement), **ROJ_MEL_DATA** (rojmel/day-register), **POINT_DATA** (loyalty accrual), **DM_DATA** (diamond detail), **BAR_DETL/BAR_IDTL** (tag/barcode), **LOT_DETL** (lot), CARD_DATA/UPI_DATA (payment split), COMM_DATA (commission), AC_MAST (running balance). The web previously wrote only the first group.

**Closed this session:** TR_SALE now also writes **TAX_DATA** + **BILL_OS_DATA** (verified: net/tax/total 50000/1500/51500; bill 51500; totals + 190/190 parity unchanged).

**Still to wire across txn engines (remediation roadmap):**
1. **MAIN_STOCK** stock-movement ledger (sale=out, purchase=in, tag ops) — note: 0 rows for DHAKAN (non-tagged), but required for tagged-inventory shops.
2. **ROJ_MEL_DATA** rojmel/day-register (mirror of AC_DATA movements).
3. **BILL_OS_DATA**/receipt allocation: receipts should reduce BILL_OS_DATA REC_AMT (bill settlement).
4. **POINT_DATA** loyalty accrual on sale (member auto-earn).
5. **DM_DATA** diamond line detail (diamond items), **BAR_DATA/DETL/IDTL** tag/barcode detail, **LOT_DETL** lot tracking.
6. Apply the same satellite set to PR (TAX_DATA/BILL_OS_DATA/MAIN_STOCK) and the other posting forms.

## Forms with NO web data coverage yet (41) — to build
- **transaction (10):** TR_APR_ISU (approval/consignment APR_*), TR_ITM_LOT (lot BAR_DATA/ITM_LOT_DETL), TR_ITM_OPBL (item opening), TR_MFG_ISU_REC/TR_MFG_ORD_ISU (MFG_DATA/DETL/IDTL — currently reuse karigar tables, not MFG_*), TR_PHYSTK (physical BAR_CAN_*), TR_TAG_CAN/TR_TAG_OPBL (tag BAR_* + LOT_DETL), TR_TOUR (tour), TR_UPI_REC (UPI_DATA).
- **master (11):** MS_AC_GROUP(AC_GROUP), MS_DESIGN_BOOK(DESIGN_DETL/IDTL), MS_GOLD_MAST(DG_GOLD_MAST), MS_MEMB(AD_MEMB), MS_STK_LIMIT(ITM_WT_MAST), MS_TRADE, MS_WINDOW_SET, …
- **utility (7):** UT_CUST_ENTRY(CUST_DATA), UT_REMINDER(REM_DATA), UT_HDD, UT_AI_TRFR, UT_TAG_PRINT(TAG_PRINT_DATA), UT_USER_REQUEST, UT_SET_ADMIN.
- **report (mostly read-only):** several materialize into REPORT_DATA/TEMP_* (we compute live instead — functionally equivalent, different mechanism).

## Verdict
- **Financial correctness: exact** (computation 190/190, ledger balanced, data fidelity 141/141 cols).
- **Workflow completeness: partial** — transactions persist the financial tables but not yet the full satellite set (tax register now added; stock/rojmel/loyalty/diamond/tag/lot pending). This is the real gap behind "many things missing."
- **Breadth:** ~52 forms with UI; 41 forms have no data coverage yet.
- **Plan:** wire the satellite tables into every posting engine + build the 41 uncovered forms, then re-run `xdb_diff` per-table Σ to certify table-level parity, not just header/ledger.
