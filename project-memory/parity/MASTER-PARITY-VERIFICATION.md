# MASTER PARITY VERIFICATION — desktop (DataCareNext) ↔ web rebuild
_Run 2026-06-30 (fresh, current-state). Method: re-ran objective harnesses against the live DB+API, re-inventoried both sides, re-validated write-coverage against current code, and triaged every gap by REAL-DATA USAGE. Per-area line-by-line detail folded from the same-day 5-agent audit (audit-A..E / PARITY-AUDIT-SYNTHESIS), updated with this session's fixes._

---

## 0. HONEST TWO-LEVEL VERDICT (read this first)

Parity must be judged at two distinct levels, because they give different answers:

| Level | Question | Verdict |
|---|---|---|
| **A. Data / computation / report fidelity** (what DHAKAN actually uses) | Does the web reproduce the desktop's real saved data, math, and reports exactly? | **YES — EXACT.** 141/141 tables column-complete, 366/366 numeric Σ, 190/190 invoice compute, 5/5 report totals. |
| **B. Full feature / form CAPABILITY** (the desktop's entire form set) | Does the web implement every one of the desktop's 61 transaction forms + 45 reports + 33 masters? | **NO — a documented SUBSET.** ~30/61 txn forms present, ~14 partial, ~17 missing; ~18 reports + a few masters absent. |

**Both are true.** The user's statement ("web is not as complete as the desktop") is correct at **level B** (capability breadth). At **level A** (the data this company actually recorded) the web is at exact parity. **Critically: ~28 of the ~31 partial/missing transaction forms correspond to tables with ZERO rows in the real data** — they are *unused desktop capabilities*, not fidelity gaps. The few forms DHAKAN actually used are all present and data-faithful.

---

## 1. Objective metrics — RE-RUN THIS SESSION (live DB :5433 + API :4000)

| Metric | Result | Tool (re-run today) |
|---|---|---|
| Report totals vs real SQL data | **5/5 PASS** — sales Σ₹5,478,196 · purchase ₹2,819,954 · stock netWt 10613.077 · accounts 300 · day-book 5150 (web == sql, exact) | `parity_report.mjs` |
| Per-form multi-table footprint | **10/10 forms-with-data OK** (sales 5 tbl, purchase 4, tax 7 incl TAX_DATA+BILL_OS_DATA, tag 3, stock 1); 4 types have no demo data | `parity_sweep.mjs` |
| Unit/workflow tests | **133 pass / 32 files** (incl. new `scheme.test.ts` 8) | `vitest run` |
| Cross-DB column + Σ parity | **141/141 cols · 366/366 Σ** (from scorecard; needs MSSQL golden-master, not re-runnable here) | `xdb_diff.mjs` |
| typecheck / build | clean (api + web) | `tsc` |

---

## 2. Inventory (counted this session)

- **Web:** 149 REST endpoints (**40 voucher-creating POSTs**), 25 API modules, 38 frontend transaction pages, ~60 report endpoints.
- **Desktop:** **61 transaction** forms · 33 master · 45 report · 22 utility · 43 other (= 205 catalogued `.cs` forms).

## 3. The real "fidelity surface" — tables the demo actually populates

Only **18 transaction/master tables hold real data**; the web write-path covers all of them:

`AC_DATA` 5150 · `MAIN_STOCK` 1856 · `BAR_DETL` 1329 · `BAR_IDTL` 943 · `AC_MAST` 918 · `BILL_OS_DATA` 366 · `SL_DETL` 245 · `ITEM_MAST` 237 · `SL_DATA` 190 · `TAX_DATA` 184 · `PR_DETL` 103 · `SL_IDTL` 103 · `BAR_DATA` 94 · `SL_ORD_DATA` 76 · `PR_DATA` 74 · `AD_ADJ` 26 · `SL_PR_DETL` 25 · `KR_DATA` 17.

→ Sales (incl. old-gold + tax + bill-outstanding), Purchase, Sales-orders, Tag/stock inventory, Karigar, Member-adjust, accounts/items masters. **All present + data-faithful in the web.**

---

## 4. Transaction-form coverage matrix (all 61) — with REAL-DATA usage

Legend: ✅ present (core persisted) · 🟡 partial (variant/satellite/sub-leg gap) · ❌ missing · **rows** = real demo rows in the form's core table.

### ✅ PRESENT (~30) — all the data-bearing forms + the financial spine
TR_SALE ✅ (190) · TR_SALE_HM ✅ · TR_SALE_ORD ✅ (76) · TR_SALE_RTN ✅ · TR_PURC ✅ (74) · TR_CONTRA ✅ (0) · TR_CASH→receipts/payments ✅ (0) · TR_AC_OPBL ✅ (0) · TR_BILL_TO→bill-to-bill/settle ✅ · TR_DHRN_ISU ✅ (0) · TR_DHRN_REC ✅ (0, now writes DHRN_DATA) · TR_DHRN_INTREC ✅ (0) · TR_KR_ISU ✅ (17) · TR_MFG_ISU_REC→mfg ✅ (0) · TR_MFG_GHAT_REC→melting ✅ (0) · TR_TAG_OPBL ✅ (94) · TR_TAG_CAN ✅ · TR_TAG_SPLIT ✅ · TR_TAG_WT_DIFF ✅ · TR_PHYSTK→physical-reconcile ✅ · TR_BUL_BOOKING ✅ (0) · TR_TOUR ✅ (0) · TR_FN_INOUT ✅ (0) · TR_PR_SL_HEDG→rate-cut ✅ (0) · **TR_MEMB_ENT→scheme installment+opening ✅ (NEW this session)** · **TR_MEMB_ADJ→scheme maturity ✅ AD_ADJ 26 (NEW this session)** · TR_SL_EBILL→einvoice ✅.

### 🟡 PARTIAL (~14) — present but a desktop variant/satellite/sub-leg is not persisted
TR_SALE_LBR (labour) 🟡 · TR_WH_SALE (wholesale) 🟡 · TR_PURC_HM 🟡 · TR_CARD_REC 🟡 (no `CARD_DATA`) · TR_UPI_REC 🟡 (no `UPI_DATA`) · TR_AC_OPBL 🟡 (no `OP_DATA`) · TR_MFG_ORD_ISU/REC 🟡 (generic mfg) · TR_MFG_ITEM 🟡 · TR_MLT_PRO 🟡 · TR_INOUT 🟡 · TR_SL_ORD_ADJ 🟡 · TR_JDT_REC 🟡 · TR_APR_ISU 🟡.

### ❌ MISSING (~17) — no web writer (ALL have 0 real rows → unused capability)
TR_WH_SALE_RTN ❌ · TR_SALE_RTN_UAE ❌ · TR_PR_SL_UAE ❌ · TR_OTH_PURC ❌ · TR_LEDR_ADJ ❌ (no `LDR_ADJ_DATA`) · TR_EMP_JV ❌ (no `EMP_DATA`) · TR_REP_REC ❌ (dhrn repayment) · TR_MFG_WITH_LOT ❌ · TR_ITM_OPBL ❌ · TR_ITM_LOT ❌ · TR_BUL_SALE ❌ (booking only) · TR_TOUR_ORD ❌ · TR_TOUR_SALE ❌ · TR_FINE_SL_PR ❌ · TR_VP / TR_VP_ADJ ❌ · TR_SL_PR_ITEM ❌ · TR_OTH_COMM ❌ · TR_GOLD_BOOK ❌ · TR_LOCT_AMT ❌.

**Coverage: ~49% present · ~23% partial · ~28% missing — but every missing form maps to a 0-row table here.**

---

## 5. Write-path / DB triage — never-written tables × REAL usage

Verified live row counts (tenant `default`). This is the key triage: a "missing writer" only matters if the table has real data.

| Desktop table | Web writes? | Real rows | Materiality |
|---|---|---|---|
| `TAX_DATA`, `BILL_OS_DATA`, `MAIN_STOCK` | ✅ (sales/purchase/returns/stock) | 184 / 366 / 1856 | **covered** |
| `AD_ADJ` | ✅ **(scheme maturity — NEW)** | 26 | **covered this session** |
| `DHRN_DATA` (receipt movement) | ✅ **(now on issue+receipt)** | 0 | covered (was a gap) |
| `POINT_DATA` | ✅ (membership) | 1* | covered |
| `CARD_DATA` | ❌ | 0 | moot (unused) |
| `UPI_DATA` | ❌ | 1* | *1 stray non-demo row |
| `EMP_DATA` | ❌ | 0 | moot |
| `LDR_ADJ_DATA` | ❌ | 0 | moot |
| `OP_DATA` (ac-opening detail) | ❌ (ac-opbl writes AC_DATA only) | 0 | moot |
| `ROJ_MEL_DATA` (rojmel daybook) | ❌ (derived from AC_DATA) | 0 | moot (DHAKAN didn't use rojmel) |
| `DM_DATA`/`LOT_DETL`/`REP_DATA`/`BUL_DATA`/`APR_DATA`/`MFG_DATA`/`ITM_OPBL`/`ITM_LOT_DETL` | ❌ | 0 each | moot (unused forms) |

\* `UPI_DATA`/`POINT_DATA` single rows are 2026-dated web-test/concurrent artifacts, not desktop demo data.

**→ Of the originally-flagged 6 "never-written" tables, `AD_ADJ` is now written; the other 5 (CARD/UPI/EMP/LDR_ADJ/OP) all have 0 real rows.** No data-bearing desktop table is unwritten by the web.

---

## 6. Reports · Masters · RBAC · Settings (per audit-E, current)

- **Reports:** web exposes ~60 report endpoints; report-total parity is 5/5 on real data. audit-E found of 44 desktop `RP_*.cs`: 12 covered, 14 partial, **~18 with no web equivalent** (bill-profit, consignment/approval, mfg-jadtar, HUID, order-tracking, 7-way `RP_MOVEMENT` pivot, pawnbroker Form8/Form12). Live-computed vs desktop's REPORT_DATA materialisation — functionally equivalent where present.
- **Masters:** 31 data masters via the generic grid (full column coverage). **`MS_AC_GROUP` (account groups) NOT registered**; auto-item/trade/stk-limit/tasting absent.
- **RBAC:** web = global per-user flags (UPDATE/DELETE/PRINT on LOGIN_MAST); desktop = **per-form rights** (FRM_VIEW/EDIT/DELETE/PRINT per menu via USER_SET). Model difference, not a bug.
- **Settings:** web whitelists **11 of CO_SET's 61** columns.

---

## 7. Remediation backlog — CURRENT status (closed vs open)

### ✅ Closed this/last session (verified)
- **Scheme MEMB ENTRY (074 monthly + 075 opening)** + **MEMB ADJUST maturity (076 → AD_ADJ)** — book identity, ENT_TYPE, balanced ledger, AD_OS +/− ; 133 tests + HTTP-inject + parity_form verified.
- **AD_ADJ writer** (was in the "never-written" list).
- **DHRN_DATA on receipt** (movement gap) ; **Karigar INOUT direction + metal sub-ledger leg** (vs real KR_DETL).
- **Payment-mode cash/PAN bug** (uppercase 'CASH' mismatch).

### 🟡 Open — MATERIAL (touches real data or core correctness)
- **Dhrn correctness depth** (issue should debit borrower ledger; interest month-bucketing/compounding) — though DHRN tables are 0 rows here, so verify by round-trip.
- **De-hardcode** purchase/GST/HSN('7113')/unit('GMS') accounts → master-driven (ITEM_MAST.HSN, per-group PURC_AC, TAX_MAST). [audit A/B/E]
- **`MS_AC_GROUP` master** registration; **settings** whitelist breadth.

### 🟢 Open — CAPABILITY (forms/reports with 0 real rows — breadth, not fidelity)
- Missing writers: bullion SALE, tour SALE/ORD, ledger-adjust (LDR_ADJ_DATA), employee-JV (EMP_DATA), card/UPI receipt detail (CARD_DATA/UPI_DATA), OP_DATA on ac-opening, dhrn repayment (TR_REP_REC), MFG order/with-lot, item-opening/lot, UAE sale/return variants, VP, gold-book, commission, location-amount.
- ~18 missing reports; per-form RBAC model; full settings.

### ⚪ Intentional non-goals (documented engineering decisions)
- **Exact AC_DATA physical layout** (934 bespoke desktop projections; LD_CODE contra-code; ~39 gross legs). Web posts a cleaner balanced representation that yields identical balances/TB/day-book/ledger — **functional ledger parity achieved; byte-layout parity intentionally not pursued** (no verifiable metric improves; high regression risk).
- **Metal fine-weight sub-ledger on retail SALES** — DHAKAN sales are money-only (IT_TYPE 'A'); metal legs exist only in purchase/karigar/opening books and are handled there (karigar fixed). Not replicated on sales because the real data has none.
- **ROJ_MEL_DATA** — 0 rows; day-book derived from AC_DATA (identical totals).

---

## 8. What "exact FULL parity" (level B) would require
1. Build the ~17 missing transaction writers + ~18 missing reports (capability breadth).
2. Persist the satellite/sub-tables on partial forms (CARD/UPI/OP/LDR_ADJ/EMP detail; mfg-order/lot variants).
3. Register `MS_AC_GROUP` + remaining masters; widen settings to ~20+ CO_SET cols; per-form RBAC (USER_SET).
4. (Optional/non-goal) exact AC_DATA leg layout + metal sub-ledger on sales.
Each should be gated by `parity_form COMPARE` (web-created vs desktop voucher) — the only harness that catches write-path gaps — and prioritised by real-data usage first.

## 9. Bottom line
- **For the data DHAKAN actually recorded: the web is at exact parity** (data 141/141, compute 190/190, reports 5/5, and the used forms all persist their data-bearing tables).
- **As a full re-implementation of every desktop form: it is ~50% complete by form count**, but the gap is dominated by capabilities this company never used (0-row forms). The genuinely material open items are small (de-hardcoding, dhrn depth, MS_AC_GROUP, settings breadth); the rest is breadth + intentional layout non-goals.

---

## 10. GAP-CLOSURE ROUND 2 (2026-06-30 — never-written-table writers)

Implemented + verified this round (focus: close the "never-written desktop tables" + a material master):

| Gap | Implementation | Verify |
|---|---|---|
| **MS_AC_GROUP** master | already registered (`'ac-groups'→AC_GROUP_CONFIG` in `configs.ts`) | live: `GET /masters/ac-groups/meta` + list → 200 |
| **CARD_DATA** (TR_CARD_REC) | `postReceipt` now writes a `CARD_DATA` row on `mode='card'` (CARD_AMT/COM_PRC/COM_AMT/REC_AMT/BANK_NET_AMT) | inject: 5000 @2% → com 100, net 4900; AC_DATA balanced 5000 |
| **UPI_DATA** (TR_UPI_REC) | `postReceipt` writes a `UPI_DATA` row on `mode='upi'` (UPI_AMT/UPI_AC_CODE/UPI_ID/UPI_TYPE='R') | inject: 3000, id TXN123 |
| **LDR_ADJ_DATA** (TR_LEDR_ADJ) | NEW `finance/ledgerAdjust.ts` — balanced AC_DATA (Dr/Cr acct↔KASAR) + `LDR_ADJ_DATA` (DIFF_AMT/IT_REMARK); routes `POST/DELETE /ledger-adjust` | inject: diff 150, AC_DATA balanced, delete clean |
| **EMP_DATA** (TR_EMP_JV) | NEW `finance/employeeJv.ts` — Dr employee salary / Cr cash net + Cr TDS + Cr PF; `EMP_DATA` (SALARY/PAID/TDS/PF); routes `POST/DELETE /employee-jv` | inject: salary 20000 → net 18500, 4-leg AC_DATA balanced, delete clean |

**Verification:** api typecheck/build clean; **140 tests / 33 files** (new `financeWriters.test.ts` 7 + existing); in-process HTTP inject **15/15** (tenant `e2e`, self-cleaned); `:4000` restarted → `POST /ledger-adjust`, `/employee-jv` return 401 (live); default-tenant demo untouched (`AC_DATA`=5150, `SL_DATA`=190, new tables still 0).

**Effect on §5 "never-written" list:** of the original 6 (CARD_DATA, UPI_DATA, EMP_DATA, LDR_ADJ_DATA, OP_DATA, AD_ADJ), **5 are now written** (AD_ADJ earlier + these 4). **Only `OP_DATA`** (ac-opening detail; 0 real rows) remains unwritten. Note: these forms have 0 real rows in DHAKAN, so this is **capability breadth** (level B), not data fidelity — but the desktop tables are now fully supported by the web write-path. Routes are backend + REST; dedicated frontend pages for ledger-adjust / employee-JV / card-commission UI are a follow-up (the receipt page already exposes card/upi modes).

---

## 11. GAP-CLOSURE ROUND 3 (2026-06-30 — MATERIAL: dhrn correctness + HSN de-hardcode)

| Gap (audit ref) | Fix | Verify |
|---|---|---|
| **Dhrn issue never debits the borrower ledger** (audit-C, P0/P1) | `issueDhrn`/`receiveDhrn` now default the receivable leg to the **borrower's own account** (`loanAc ?? borrowerAc`) instead of a generic `'DHRN'` control a/c — so the loan shows on the borrower's ledger; explicit `loanAc` still routes to a control a/c. | round-trip: issue Dr BORR1 10000 / Cr CASH; receipt Dr CASH 4300 / Cr BORR1 4000 / Cr INTINC 300; outstanding 6000 (8/8) |
| **Interest lacks whole-month bucketing** (audit-C) | new `monthsBetween(from,to)` (rounds any partial month up, 1-month min) + `termInterestBetween()`; configurable `yearDays` + monthly/day-count dispatcher already existed | unit: 15-Jan→14-Feb=1, →16-Feb=2, →15-Apr=3; termInterest 600 |
| **Hardcoded HSN '7113' / unit 'GMS'** (audit-A/B/E) | `submitIrnForSale` now reads `ITEM_MAST.HSN_CODE` + `UNIT_NAME` per line item (fallback 7113/GMS). Real items carry HSN 7113/711319; blanks fall back. | typecheck + einvoice tests green (buildIrnPayload unaffected); fallback-preserving |

**Verification:** api typecheck/build clean; **142 tests / 33 files** (dhrn +2 whole-month); dhrn borrower round-trip 8/8 (tenant `e2e`, self-cleaned); `:4000` restarted (pid 60632); **parity_report 5/5** (sales 5,478,196 / purchase 2,819,954 / stock / accounts 300 / day-book 5150 — unchanged, no regression); demo intact.

**Still open (material):** per-group purchase account (`PURC_AC`) + `TAX_MAST`-driven GST account codes (NOT de-hardcoded — changes ledger account distribution; higher risk, needs master setup + COMPARE gating). Dhrn compounding (desktop default is simple 'M', so low priority). GST `hsnSummary` still uses the TAX_PRC-slab proxy (could use `ITEM_MAST.HSN_CODE`).

### Running cumulative status (this session)
Closed: scheme MEMB_ENT (074 monthly + 075 opening) · MEMB_ADJ maturity (076→AD_ADJ) · CARD_DATA · UPI_DATA · LDR_ADJ_DATA · EMP_DATA · dhrn borrower-ledger + whole-month interest · einvoice HSN/unit master-driven · MS_AC_GROUP (verified). **"Never-written desktop tables" remaining: OP_DATA only.** Data-fidelity parity (level A) remains exact; capability breadth (level B) materially improved.
