# SPEC RECONCILIATION — `web-implementation-spec` ("the Bible") ↔ current web
_2026-06-30. After reading the spec in depth (00_Overview, 01_Architecture, 02_Data_Model, 04_Cross_Cutting_Engines, 03_Modules Sales/Purchase/Dhrn/Inventory + 06_Parity + 07_Build_Plan). This maps the spec's authoritative change-list (the `06_Parity/§6` **R1–R14 risk register** + per-module build checklists) to the CURRENT web state + this session's fixes._

## 1. What the spec is (orientation)
- The **single authoritative, build-ready parity spec** ("the Bible"): every screen/field/calc/DB-write/posting-rule/report traced to decompiled source. **Desktop = golden master**; on disagreement the desktop wins and the diff is recorded.
- Scope: **204 forms · 162 tables · 255 reports**, grouped into **14 functional modules** aligned to the existing `web/apps/api/src/modules` decomposition.
- Target stack = exactly what is built (Next.js 15 / Fastify / Prisma→Postgres / Playwright PDF / JWT+Argon2). So the spec's mode is **"verify-and-complete-to-parity"**, not greenfield.
- **Verification = 4 tiers**: T1 unit golden vectors → T2 live `e2e`-tenant integration → T3 e2e (trial balance ties) → T4 **golden-master SQL Server diff** (`xdb_diff` / `compute_parity`). A module is certified only when all tiers pass **and** global TB nets zero.
- The engine contracts (`posting-and-ledger.md`, `calc-engine.md`) match the web's `posting.ts` + `packages/core` (decimal.js HALF-UP; amount 2dp / weight·fine 3dp; `fine=nwt×touch/100`; `gstSplit` SGST=tax−CGST; `billTotals` → nearest rupee). ⇒ the web's engines are **on-spec by design**.

## 2. The authoritative change-list — `R1–R14` × current status

| # | Risk (spec 06_Parity §6) | Module | Current status |
|---|---|---|---|
| R1 | `onHand` returns only pcs/gwt/nwt — no FINE, not full signed `MAIN_STOCK` net (Req 14.4) | Inventory | **OPEN** — `stock.ts onHand` reads BAR_DETL−sold; add signed-net incl. fine over full MAIN_STOCK |
| R2 | 6 stock-write stamp bugs (`BOOK_NAME`/`DATA_TYPE`/`TBL_CODE`/`BAR_IDTL`/INOUT/ENTRY) | Inventory | **REPORTED FIXED this session** (tag-opening TGEN/TAG OPBL, `DATA_TYPE='A'` global, `TBL_CODE='001'`) — re-verify vs `verify-stock-tags` |
| R3 | Dhrn interest rounding: dp-by-loan-type (cash **0dp** / metal **3dp**), .NET banker's vs HALF-UP, whole-month bucketing, optional annual compounding | Dhrn | **PARTIAL** — added `monthsBetween` whole-month helper (unit-tested) but it is **not wired into `/dhrn/receipt|interest`**, and the dp-by-loan-type + rounding-mode rules are not applied |
| R4 | Issue debits a generic `DHRN` a/c, not the borrower `AC_CODE` | Dhrn | **✅ CLOSED this session** — `issueDhrn`/`receiveDhrn` default the receivable leg to the borrower; verified round-trip (Dr borrower / Cr cash) |
| R5 | `ROJ_MEL_DATA` day-book rows omitted | Sales/Finance/Purchase | **OPEN** — no module writes ROJ_MEL_DATA (moot for DHAKAN: 0 real rows; required for rojmel shops) |
| R6 | Purchase omits `PR_IDTL`, `BAR_*`, `ITM_LOT_DETL`, `TAG_SET`, `TOUCH_MAST` | Purchase | **PARTIAL** — accounting+payable+MAIN_STOCK+metal-fine leg written; full tag-batch/lot/touch-memory satellites open |
| R7 | Cash-limit→PAN rule (desktop cash-ceiling-block vs sales PAN-gate vs web merged) | Finance | **OPEN** — needs ADR + align; finance audit flags the rule may be inverted |
| R8 | Generic master engine has **no UPDATE path** (Req 8.4) | Masters | **OPEN** — `app.ts` exposes create/list/delete/import only; affects all 28 registered masters |
| R9 | `YEAR_MAST` key (CO_CODE,CO_YEAR,**YEAR_MONTH**) vs web omitting YEAR_MONTH | Masters | **OPEN** — recover key via golden master |
| R10 | GSP e-invoice creds unavailable | GST/E-Invoice | **CODE COMPLETE; creds external** — real `CharteredInfoIrnTransport` (auth + generateIRN + **cancelIRN**/NIC Cancel), env-driven `irnTransportFromEnv`, `gspStatus` (masked) + `testGspAuth` (connection test), `cancelIrnForSale`; routes GET `/einvoice/gsp-config` + POST `/einvoice/gsp-test` + POST `/einvoice/:vchNo/cancel`; UI GSP-config panel + Test Connection + Cancel IRN. Secrets env-only (never in DB). Verified 9/9 inject + 3 unit tests (suite 151). Only the commercial GSP account/creds are external. |
| R11 | VP / GOLD_BOOK semantics uncertain | Bullion/VP | **OPEN** — decompile-confirm before building |
| R12 | `SRNO_MAST` per-book/per-year numbering columns not recovered | Numbering | **OPEN** — = the global-counter issue I found (web `SRNO_MAST` keys only CO+LC, one counter across all books); needs golden-master column recovery |
| R13 | Many money/weight columns FLOAT in desktop; confirm NUMERIC precision | All | **OPEN** — type-confirm per column |
| R14 | Closing-stock off-ledger (book 999) until `Ac_Final` → mid-year TB won't tie raw | Accounting | **OPEN** — replicate finalization step |

**Closed/improved this session beyond the register** (spec modules 7/8/10): scheme installment+opening (074/075) + maturity (076→AD_ADJ); CARD_DATA/UPI_DATA receipt detail; LDR_ADJ_DATA ledger-adjust; EMP_DATA employee-JV; einvoice HSN/unit master-driven; MS_AC_GROUP registered.

## 3. Breadth-missing forms the build-plan still wants (Phases 4-9-11)
`TR_ITM_OPBL` (item opening — 72 real rows!), `TR_ITM_LOT` (lot intake), `UT_TAG_PRINT`; `TR_PURC_HM`/`TR_OTH_PURC`/`TR_PR_SL_UAE`; MFG `TR_MFG_ORD_ISU/REC`/`TR_MFG_WITH_LOT`/`TR_MFG_ITEM` + jobwork→MFG_* (`TR_JDT_REC`); `TR_BUL_SALE`, `TR_TOUR_SALE`/`TR_TOUR_ORD`, `TR_VP`/`TR_VP_ADJ`, `TR_GOLD_BOOK`, `TR_FN_INOUT` (FAN_DATA vs web INOUT_DATA), `TR_REP_REC` (dhrn repayment); ledger-adjust + employee-JV **frontend pages**; 4 masters (auto-item/trade/stk-limit/tasting); ~17 reports.

## 4. Alignment with my own audit
The spec **independently confirms** every systemic finding in `FUNCTIONAL-PARITY-MASTER.md`: shallow ledger (per-group `SALE_AC`/`PURC_AC` + ~39 legs), master-no-update (R8), dhrn-borrower (R4), cash-limit (R7), ROJ_MEL (R5), per-book numbering (R12), purchase satellites (R6), onHand-fine (R1), stock stamps (R2). Mutually validating — the spec is the **prioritized, source-cited** version of the same gap set, plus R9/R11/R13/R14 (golden-master-dependent items I had not isolated).

## 5. Actionable parity order (spec build-plan × leverage, current)
**P0 (cross-cutting, unblock everything):** R8 master UPDATE + edit UI · per-group account resolution (`GROUP_MAST.SALE_AC`/`PURC_AC`, `TAX_MAST.TAX_AC`) + `VCH_TYPE`=`BOOK_SNAME` · R3 wire dhrn interest engine into endpoints + honour `CO_SET` (`MsIntYearDays`/`MsDhrnIntType`) + dp-by-loan-type · R7 cash-limit/PAN ADR+fix · re-verify R2.
**P1 (data-bearing depth/breadth):** R1 onHand fine/full-net · R6 purchase satellites · sales-order line grid + Order_Stk · hallmark HM_AMT/HM_TAX · `TR_ITM_OPBL` (72 rows) · ledger-adjust/employee-JV pages.
**P2 (golden-master-dependent + breadth):** R9/R12/R13 (need Tier-4 SQL-Server recovery) · R14 Ac_Final closing-stock book 999 · R5 ROJ_MEL · bullion sale / tour / VP (R11) / MFG order-lot / jobwork→MFG · 17 reports · per-form RBAC (USER_SET) · settings 11→~20 CO_SET cols.
**External:** R10 GSP creds.
**Non-goals (documented):** exact AC_DATA physical-leg layout; metal fine-ledger on retail sales (RATE_UNFIX='N' ⇒ money-only both sides); ROJ_MEL where unused.

## 6. Bottom line
The spec and my audit agree: the web has **exact data/compute/report fidelity** for the real dataset, and a **prioritized, source-cited list of behavioural/depth gaps (R1–R14 + breadth forms)** to reach full functional parity. This session closed R4 + R2 (re-verify) and several module-7/8/10 writers; the remaining P0 set (master UPDATE, per-group accounts, dhrn interest wiring, cash-limit) is the highest-leverage next work, and the golden-master-dependent items (R9/R12/R13/R14) need the Tier-4 SQL-Server restore the spec prescribes.


---

## 7. P0 IMPLEMENTATION (2026-06-30 — spec build-plan P0 closed)

Worked the §5 P0 list. All verified (typecheck/build clean; **148 tests / 33 files**; `:4000` restarted, routes live; `parity_report` 5/5 unchanged; demo `SL_DATA`=190 / `AC_DATA`=5150 intact; all live checks in the isolated `e2e` tenant, self-cleaned).

| Item | Done | Evidence |
|---|---|---|
| **R8 master UPDATE** | ✅ | `master.service.updateMaster` (key-immutable, required-blank guard, row-exists→404) + `PUT /masters/:name` (right `update`) + web `put()` + Edit form on the masters grid. Inject 6/6 (create→update→404→400→clerk 403). `PUT /masters/ac-groups` live = 401. |
| **R3 dhrn interest engine wired** | ✅ | `computeDhrnInterestTx` reads `CO_SET.DHRN_INT_TYPE`/`INT_YEAR_DAYS` (fallback M/360), `monthsBetween` whole-month bucketing, `roundInterestByLoanType` (cash 0dp / metal 3dp). `/dhrn/receipt`+`/interest` now auto-compute interest when omitted (operator override preserved). Inject 8/8 (200 = 10000×2%×1mo; override honoured). |
| **R7 cash-limit→PAN** | ✅ | ADR resolved from `TR_CASH.cs:2913`: receipts = **cumulative cash ceiling-block, no PAN escape** (`assertCashReceiptCeiling`, limit from `CO_SET.CASH_LIMIT` via `cashLimitTx`); sales/payments keep the PAN-gate (`assertCashLimit`). Unit 4/4. |
| **Per-group accounts** (audit-A / R6) | ✅ | sales `buildIncomeLegs` + `createSale` resolve `ITEM_MAST.GR_CODE→GROUP_MAST.SALE_AC` per item; purchase mirror `buildExpenseLegs`/`PURC_AC`. Proportional, Σ==taxable, fallback to literal. Inject 4/4 (GOLDSALE 1000 + SILVSALE 500, no lumped SALES, balanced). All 33 demo groups define SALE_AC/PURC_AC. |
| **R2 stock stamps** | ✅ (re-verified) | `stock.ts tagOpening`: `TGEN`/`TAG GEN`/`INOUT='I'`/`ENTRY='O'`/`TBL_CODE='001'`, `TAGOP`/`TAG OPBL`; `DATA_TYPE='A'` stamped globally by `postVoucherTx`. |

**Deferred (documented):**
- **VCH_TYPE=BOOK_SNAME / BOOK_NAME=MAIN_BOOK** on sale/purchase rows — a label spanning many row literals in the flagship; lower parity value than the account split; deferred to avoid regression risk (per-group account split was the substantive part of that bundled item).
- **TAX_AC per tax-code** (`TAX_MAST.TAX_AC`) — needs a `TAX_CODE` carried on the sale (web uses a tax % not a code); deferred.
- **Tier-4 (R9 YEAR_MONTH, R12 SRNO_MAST per-book numbering, R13 FLOAT→NUMERIC, R14 closing-stock book 999)** — require the SQL-Server golden-master restore (`:11433` not running here); `compute_parity` is blocked on it.

**P0 status:** R8 ✅ · R3 ✅ · R7 ✅ · per-group accounts ✅ · R2 ✅. Remaining open items are the golden-master-dependent set (R9/R12/R13/R14), R5 ROJ_MEL (0-row), R10 GSP creds (external), R11 VP/GOLD_BOOK (decompile), and the breadth forms/reports — the spec's P1/P2.


---

## 8. P1 COMPLETE + P2 PROGRESS (2026-06-30, cont.)

All verified (typecheck/build clean; **148 tests / 33 files**; `:4000` restarted healthy; demo `SL_DATA`=190 / `AC_DATA`=5150 / sales Σ5478196 intact; every live check on the isolated `e2e` tenant, self-cleaned).

### P1 (all 5 done)
| Item | Done | Evidence |
|---|---|---|
| ledger-adjust + employee-JV **UI** | ✅ | `/txn/ledger-adjust` + `/txn/employee-jv` pages (LookupPicker) → existing P0 backends; 2 Cash/Bank nav links. |
| **R1** onHand fine + full net | ✅ | `stock.ts onHand` now returns `+fine`; new `onHandNet` = signed `MAIN_STOCK` net (pcs/gwt/nwt/fine); `GET /stock/on-hand` returns `{...tags, net}`. Matches psql (net nwt 27878.945 / fine 39647.996). |
| **TR_ITM_OPBL** item opening | ✅ | `stock.ts itemOpening`/`deleteItemOpening` (`ITM_OPBL` + `MAIN_STOCK 'ITOBL'/'ITM OPBL'/P/+`, book IOP) + `POST/DELETE /stock/item-opening` + line-grid UI + nav. Inject 6/6 (rows written, onHandNet fine 582.02, delete reverses). Note: `MAIN_STOCK.IT_CODE` is `varchar(5)`; `ITM_OPBL` 0 rows live (the "72" was the desktop count, not migrated) — capability writer. |
| sales-order **line grid** | ✅ | Rewrote `sales-order/page.tsx` with a weight-based line grid → existing `createSalesOrder` (already persists `SL_ORD_DATA/DETL/IDTL` + advance ledger). Inject 4/4 (DETL 2 + IDTL 2 + advance balanced 1000). `Order_Stk` reservation deferred (orders are design/item specs, not tag reservations). |
| hallmark **HM_AMT/HM_TAX** | ✅ | `createSale` computes `hmAmt`/`hmTax` (additive; 0 ⇒ normal sale byte-identical), appends Cr `HMCHRG` + Cr GST + Dr customer legs, sets `HM_AMT`/`HM_TAX_AMT`/`TOT_AMT`=grand, adds `HM_CGST/HM_SGST/HM_IGST` `TAX_DATA` rows; route + hallmark-sale page field. Inject 7/7 (HM_AMT 450 / HM_TAX 13.5 / HMCHRG Cr 450 / Σdr==Σcr / 2 HM rows; regular sale HM_AMT 0 / no HM rows). |

### P2 — corrected breadth picture (important honesty note)
A full route+page survey shows the web is **far more complete than the checkpoint's "missing" list implied**: **43 `/txn` pages, ~60 report endpoints, ~85 ready nav links**. Already wired+UI'd: sales/purchase/returns, dhrn issue/receipt/interest, **bullion booking, tour issue, MFG issue/receive, karigar (jobwork) issue/receive, melting**, contra/journal/fine-jv/employee-jv/ledger-adjust, scheme (enroll/installment/opening/maturity), ac-opbl, tag ops, item-opening, rate-cut, payments/receipts/batch, bill-to-bill, estimate, labour/wholesale/hallmark sale; admin/RBAC, audit, backup, settings, year-end, e-invoice, reminders, voucher-renumber. **Only 6 `/soon` placeholders remain:** `TR_PURC_HM` (purchase hallmark), `TR_OTH_PURC` (other/expense purchase), `TR_ITM_LOT` (lot intake), `TR_MFG_ORD_ISU` (MFG order issue), `TR_CARD_REC` (card receipt — likely redundant with `/receipts` card detail), `TR_FINE_SL_PR` (fine sale/purchase — likely covered by fine-jv/fine-inout/rate-cut).

- **dhrn-repayment (TR_REP_REC)** — **already implemented**: `receiveDhrn` posts Dr cash / Cr borrower + interest income, writes `DHRN_REC_DATA` and reduces outstanding; `receiveDhrnInterest` does interest-only. The web uses `DHRN_REC_DATA` where the desktop names it `REP_DATA` (naming difference, like FAN_DATA/INOUT_DATA).
- **settings breadth** — ✅ expanded the `CO_SET` whitelist **11 → 26** curated flags (added DHIRN_COMPOUND, DHRN_WAPP, SCHM_WAPP, PAN_CARD_VAL, EMP_CODE_MANDATORY, PURC_WITH_LBR, LBR_ROF, ITM_RATE_ROF, SL_AMT_TYPE, PR_AMT_TYPE, RATE_PAR, OZ_CON_VAL, CASH_PURC_AC, FX_CODE, FX_RATE). Settings page renders `fields` dynamically (auto-renders new ones). Inject 6/6 (round-trip + whitelist enforcement: non-whitelisted `THEME` rejected 400 + never written). Demo CO_SET untouched.
- **per-form RBAC** — per-user rights exist (`POST /admin/users/:loginName/rights` + `rbac/policy.ts`); per-form `USER_SET` granularity still to assess.

**Remaining P2/P3:** the 6 `/soon` forms (assess redundancy; build `TR_PURC_HM` + `TR_OTH_PURC` as the clearest-value ones) · per-form RBAC granularity · golden-master-dependent R9/R12/R13/R14 (blocked on SQL-Server restore).

### P2 — `/soon` forms worked (each classified against decompiled source)
Read all 6 desktop form sources to classify (build vs covered vs heavy):
- **`TR_OTH_PURC` (other/expense purchase)** — ✅ **BUILT**. Non-stock purchase with GST input: `createOtherPurchase`/`deleteOtherPurchase` in `purchase.ts` (Dr expense leg(s) + Dr input-GST + Dr round-off / Cr supplier → `PAY_DATA` + `TAX_DATA` + `BILL_OS_DATA`, book `OPR`/VCH_TYPE `OPUR`), `POST/DELETE /other-purchase`, expense-line-grid UI + nav `ready`. NOT redundant with `/payments` (which has no GST/expense allocation). Inject **8/8** (NET 1500 / TAX 270 / TOT 1770, Σdr==Σcr, supplier Cr 1770, GSTINPUT Dr 270, 2 tax rows, payable 1770, delete reverses). Note: `PAY_DATA` tax cols are `CGST_TAX/SGST_TAX/IGST_TAX` (not TAX_PRC/TAX_AMT).
- **`TR_CARD_REC` (card/UPI receipt)** — ✅ **COVERED**. The shared `PaymentForm` (Receipt) already has CARD+UPI modes; backend `postReceipt` already writes CARD_DATA/UPI_DATA (P0). Added the detail fields (card commission %, acquiring bank, UPI txn/handle) to the form + repointed nav `Card / UPI Receipt → /txn/receipt`. Inject **4/4** (card→CARD_DATA commission 200; upi→UPI_DATA upiId).
- **`TR_FINE_SL_PR` (fine sale / fine purchase)** — ✅ **BUILT to spec** (`11_Bullion_Tour_VP/TR_FINE_SL_PR.md` §4). New `bullion/fineSalePurchase.ts`: pure-metal trade priced on fine weight (`fine × FINE_RATE`), both sides — SALE (Dr party / Cr fine-sales + GST, MAIN_STOCK `-`) / PURC (Dr fine-purchase + input-GST / Cr supplier, MAIN_STOCK `+`) — writing `CUT_DATA` + `CUT_DETL` (DR_FINE/CR_FINE + DR_AMT/CR_AMT + FINE_RATE) + `TAX_DATA` + `MAIN_STOCK` + balanced `AC_DATA` (incl. metal FINE_WT leg). Rate-cut/fixing: a purchase draws down open fine on a source `PR_DETL` line (`CUT_STK_DETL` SL_* link + `PR_DETL.FINE_CUT_*` += qty, guarded ≤ open balance); delete restores it. `POST/DELETE /fine-sale`, side-toggle UI (+ fixing rows) + nav `ready`. Inject **10/10** (sale Σdr==Σcr 661028.25 + CUT_DETL + stock OUT; purchase stock IN + CUT_STK_DETL link + FINE_CUT_FINE drawn 20; over-cut→400; delete restores 0). Columns verified against the live schema (FINE_CUT_* are varchar; CUT_STK_DETL has IT_CODE not IT_TYPE). Per spec open-Qs, exact BOOK_DETL account-resolution + RATE_CUT_ISU link rows remain a golden-master refinement.
- **`TR_MFG_ORD_ISU` (design issue against a sales order)** — ✅ **BUILT to spec** (`5_Manufacturing/TR_MFG_ORD_ISU.md` deltas vs base `issueMfg`). The base MFG engine was already real (spec's "aliases karigar" note is stale — `issueMfg/receiveMfg` write the real `MFG_DATA/DETL/IDTL` + `MFG_ISU_REC` + `MAIN_STOCK`). Added per spec: order-link fields on `MfgLine` → `MFG_DETL.ORD_*`; after the issue posts, `UPDATE SL_ORD_DETL SET DESIGN_ISU='Y'` for each consumed line; `deleteMfg` re-opens them (`'N'`). `POST/DELETE /mfg/order-issue` (book `DIS`, IR_TYPE `D`), UI + nav `ready`. Additive. Inject **7/7** (MFG_DATA book DIS + MFG_DETL ORD_* + MFG_ISU_REC sign `-`; order DESIGN_ISU Y after / N after delete). Full open-order auto-pull grid + MFG_MAST stage-registry seed remain (spec build-plan).
- **`TR_ITM_LOT` (item lot intake)** — ✅ **BUILT**. Inventory-only (no ledger, like item-opening): `itemLot`/`deleteItemLot` in `stock.ts` write `ITM_LOT_DETL` + `MAIN_STOCK` (VCH_TYPE `ITLOT` / BOOK_NAME `ITM LOT` / TR_TYPE `I` / ITM_SIGN `+` / TAG_NO `N` / ITM_LOT=LOT_NO / ISR_NO 2 — per desktop `Ac_Stock.Item_Lot_Stk`), book `ILT`, LOT_NO operator-supplied or auto. `POST/DELETE /stock/item-lot`, lot-line-grid UI + nav `ready`. Inject **6/6** (2 ITM_LOT_DETL + 2 MAIN_STOCK ITLOT rows, LOT_NO 'LOT001', onHandNet fine 243.8, delete reverses).
- **`TR_PURC_HM` (hallmark purchase)** — ✅ **BUILT to spec** (`03_Modules/3_Purchase/TR_PURC_HM.md` web-mapping: *reuse `createPurchase` + huid + HM columns*). Additive HM delta on `createPurchase` (mirror of the sale-HM): per-line `huid`→`PR_DETL.HM_ID`; header `hmAmount`/`hmTaxPct`→`PR_DATA.HM_AMT/HM_TAX_PRC/HM_TAX_AMT` + `TOT_AMT`=grand; ledger appends **Dr hallmark-expense + Dr input-GST / Cr supplier**; HM input-GST `TAX_DATA` rows (HM_CGST/HM_SGST/HM_IGST); payable=grand. `/purchases` route passes the HM fields; `/txn/purchase-hm` UI (HUID per line + HM charge) + nav `ready`. hmAmount=0 ⇒ a normal purchase byte-identical. Inject **7/7** (HM_AMT 200 / HM_TAX 6 / TOT 56815, PR_DETL HM_ID 'ABC123', Σdr==Σcr + HMCHRG Dr 200, 2 HM tax rows; normal purchase HM_AMT empty / no HM rows). Deferred to a golden-master pass (per spec open-Qs): the exact `BAR_DETL`/`BAR_IDTL` HUID-stamp on *existing* tags.

**Net task-6 state:** reports DONE (~60 endpoints), settings breadth DONE (11→26), dhrn-repayment already present, **OTH_PURC + ITM_LOT + PURC_HM + MFG_ORD_ISU + FINE_SL_PR built**, CARD_REC covered. **`/soon` placeholders 6 → 0 — the entire desktop nav surface is now wired (`ready:true`).** Genuinely remaining = golden-master-blocked R9/R12/R13/R14 + the deep stock/tag satellites flagged per-form for a golden-master pass.

### Per-form RBAC (USER_SET) — ✅ BUILT
The 3 global LOGIN_MAST rights (USER_UPDATE/DELETE/PRINT) were already enforced on every mutation; the per-form `USER_SET` layer (per-menu FRM_VIEW/EDIT/DELETE/PRINT) was unwired (0 rows, `filterNav`/`allowed` unused, `/me` omitted it). Added `rbac/formRights.ts` (`getUserFormRights`/`setUserFormRights`/`resolveAllowedForms`), `GET/POST /admin/users/:loginName/form-rights` (admin-gated), `/me` now returns `allowedForms` (null ⇒ unrestricted: admin / un-configured — matches the desktop default + preserves current behavior; else the `MainMenu/SubMenu` view set), and `Shell.tsx` filters the sidebar nav by it. Additive: USER_SET empty ⇒ no change. Inject **6/6** (set 2 rows → get → clerk `/me` allowedForms `[Sales/Sales Invoice]`; admin null; clerk blocked 403; clear → null). Remaining nicety: an admin UI matrix to edit form-rights (the API is live); per-route form-level enforcement (beyond nav-hide + the 3 global flags) can map API path→form key when needed.


---

## 5. Video-parity implementation run (2026-07-01) — desktop↔web UX/feature backlog

Grounded in `project-memory/video-research/_modules/` (keyframes + narration). Each item: implement → api build + web typecheck → in-process `.inject()` verify on isolated `e2e` tenant → full suite 148/148 → demo intact → restart `:4000`. All verified.

**Earlier this session (slices):** Slice 1 shared chrome (RateTicker + PartyBalance), Slice 2 Sales Invoice enrichment (old-gold grid + hallmark + full totals + TCS + Kasar), Slice 3 finance bill-wise real receipt + Kasar on receipt/payment, Slice 4 masters full field sets (accounts 31 / items 21 / groups 13).

**Net-new P2 screens built + verified this run:**
| Screen | Endpoint(s) | Mechanic | Verify |
|---|---|---|---|
| **Stock Adjust** | `POST/DELETE /stock/adjust` | `stockAdjust`/`deleteStockAdjust` — signed `MAIN_STOCK` (`STADJ`/`STOCK ADJ`/`A`, per-line `ITM_SIGN ±`), inventory-only, book `SAJ`, reversible | 5/5 (onHandNet net 45.8−19.8=26.0) |
| **Bank Reconciliation** | `GET /bank-recon`, `POST /bank-recon/clear` | `bankRecon.ts` — bank's `AC_DATA` ledger, clearing via `CLR_DATE`, Book/Cleared/Uncleared | 4/4 (clear→cleared 10000/unclr 2000→un-clear 0) |
| **Daily Rate** | `POST /daily-rate` | `dailyRate.ts` — per-group `GR_RATE = fine × GR_TOUCH/100` → `RATE_MAST`, idempotent/date, feeds ticker | 5/5 (66002=72055×91.6%; ticker reflects) |
| **Order Cancel** | `DELETE /sales-orders/:vchNo` | `cancelSalesOrder` — reverse `SL_ORD_*` + advance `AC_DATA` + DELETE_DATA; **guard** issued/tagged/delivered | 6/6 (advance reversed; issued→blocked) |
| **Reminder dashboard** | `GET /reminders` | `reminders.ts` — overdue receivables (`BILL_OS_DATA` aged vs `AC_CR_DAYS`) + orders-due (`DEL_DATE`) | 5/5 (70d overdue; 1 party; order −10d) |
| **Tag Transfer** | `POST/DELETE /stock/tag-transfer` | `tagTransfer` — tag→bulk: OUT tag `−` + IN bulk `+` `MAIN_STOCK`, **fine conserved**, no ledger, book `TTR` | 5/5 (CH22 −11.358 / OG +11.358; net 0) |
| **Labour Update bulk** | `GET/POST /labour-update` | `labourUpdate.ts` — group items Old→New `IT_LBR_RATE`/`LBR_PRC`/`ITEM_RATE`/`IT_WEST`, partial UPDATE | 4/4 (A1 lbr 800/west 10; others preserved) |
| **Approval Return (close-loop)** | `POST/DELETE /tour/return` | `tourReturn`/`deleteTourReturn` — unsold tour goods back: MAIN_STOCK in (`+`/`R`, book `TRR`) + APR receive linked via `ISU_NO`/`ISU_SRNO` + flip orig `APR_DETL.ISU_REC` `N`→`R`; delete re-opens | 8/8 (line1 closed/line2 out; onHandNet −13.74→−4.58→−13.74) |

**Masters follow-on:** **Account opening-balance** `GET/POST /accounts/:acCode/opening` (`openingBalance.ts`) — `OP_DATA` money(OP_AMT/OP_SIGN)+gold(FINE_BAL/FINE_SIGN)+silver(SL_FINE_BAL/SL_FINE_SIGN), idempotent (1 row/ac), **folded into `partyBalance`** (opening + movements). Verified 6/6. (Fixed a nested-`withTenant` stale-read returning 0.)

**Dual GST — confirmed ALREADY COMPLETE (not a gap):** this single-`TAX_PRC` schema's GST mechanic is the CGST/SGST(intra) vs IGST(inter) split, already implemented in `createSale` (writes `CGST_TAX`/`SGST_TAX`/`IGST_TAX` + per-line `ITM_*_AMT` + TAX_DATA CGST+SGST or IGST rows + HM split) and exposed via the inter-state toggle on sales/purchase/hallmark/sale-return UIs; covered by `gst.test.ts`. Fresh inject 5/5 (intra CGST 869.4+SGST 869.4=TAX 1738.8 + 2 TAX_DATA rows; inter IGST 1738.8 + 1 row). A separate metal/labour-rate engine would be **wrong** for this schema.

**Known polish gaps (not core):** bank-recon ChqNo column + From/To date inputs (backend supports range); daily-rate separate purchase-rate (PrTouch/PrRate); reminder extra categories (Dhiran/Scheme/Birthday — note: `AC_MAST` has **no** birth/anniv columns); order-cancel partial-refund (AdjAmt/KsarAmt/PaidAmt) — current is full void; manual Reminder Entry voucher. Still deferred: company-provisioning seed (needs numeric-chart posting-defaults alignment), Counter Transfer, Vch ReNumber.

**Invariants throughout:** api build + web typecheck clean every step; **suite 148/148** (33 files); demo intact (SL_DATA=191, AC_DATA=5150); all verification on isolated `e2e` tenant, rows wiped after.

## 6. Final completion batch (2026-07-01) — remaining backlog closed

| Item | Endpoint(s) | Mechanic | Verify |
|---|---|---|---|
| **Company provisioning seed** | `POST /admin/companies/:coCode/provision` | `seedCompany` (ops) — idempotent CO_MAST + 19 system AC_MAST (the LITERAL codes posting uses: CASH/SALES/PURCHASE/GST/KASAR/TCS/…) + 7 taxes + 14 books + SRNO counter + CO_SET. No posting-default change → 148 tests untouched | 4/4 (fresh co posts a sale; SALES leg → "SALES A/C"; idempotent) |
| **Counter Transfer** | `POST/DELETE /stock/counter-transfer` | `counterTransfer` — relocate stock between counters: OUT TBL_CODE=from (`-`) + IN TBL_CODE=to (`+`), fine conserved, book `CTR` | 9/9 batch (001−/002+, net 0, guard, delete) |
| **Manual Reminder Entry** | `GET/POST/DELETE /reminder-entries` | `reminderEntry` — ad-hoc reminders in REMARK_DATA (account + note + date), book `REM` | (in 9/9 batch) create/list/delete |
| **Bank-recon polish** | `GET /bank-recon` | ChqNo via scalar subqueries on CASH_DATA/PAY_DATA (no row-multiplication) + From/To date filter UI | 4/4 (RCT 12345/PAY 67890; book unchanged; Aug-only filter) |
| **Daily-rate polish** | `POST /daily-rate` | purchase rate: GR_PR_TOUCH/GR_PR_RATE/FINE_*_PR_RATE from group `GR_PURC_TOUCH` (bug fixed: was GR_PR_TOUCH) | 4/4 (sale 66002 + purchase 64850 = 72055×90%) |

**Order-cancel partial-refund (AdjAmt/KsarAmt/PaidAmt):** intentional simplification — the built Order Cancel does a full void (reverse order + advance ledger), which is economically equivalent to a full refund. The desktop's partial model (keep order + refund voucher for part) is a documented enhancement, not rebuilt.

### Tier-4 golden-master verification — UNBLOCKED & PASSING
Previously blocked on SQL Server. Started the stopped `sql_server` container (host **:1433**, not :11433), copied the golden-master `Next24.mdf/.ldf` (`unified/database/backups/`) into the container, fixed ownership, and attached **Next24** (145 base tables, 190 real desktop SL_DATA invoices).
- **Calc-engine parity** (`compute_parity`): the web `@datacare/core billTotals` recompute of all **190 real desktop invoices** matches desktop-stored TAX_AMT + TOT_AMT **100% exact** (e.g. vch 00001 → 75043==75043); desktop TAX_AMT==CGST+SGST+IGST 190/190. **COMPUTE_PARITY_OK**.
- **Data-fidelity matrix** (`xdb_diff` → `project-memory/parity/xdb-matrix.md`): **141 common tables, 141/141 column-complete (0 partial)**, **78/78 ETL fully-loaded (0 rejected)**, **372 numeric-column Σ checks pass / 0 fail**. **XDB_MATRIX_OK**.

This retires the long-standing Tier-4 blocker and corroborates R13 (numeric precision — 372 Σ exact) and the schema's column coverage (141/141). SQL Server left running; `docker stop sql_server` if resource-constrained.

**Net result:** the entire video-parity backlog + company-seed are built & verified; Tier-4 golden-master diff passes. Demo intact (SL_DATA=191, AC_DATA=5150), suite 148/148, `:4000` live.


---

## PARITY-GAP-PLAN execution — COMPLETE (all 5 foundations + 8 P0 items)

All foundations F1–F5 and P0-1…P0-8 implemented and verified (per-item: api build + web typecheck clean, e2e inject on isolated `e2e` tenant, full suite 151/151, demo `default` intact SL=191/AC=5150/KR=17/BAR=1329, `:4000` restarted).

**Foundations**
- **F1 Lookup infra** — `FormField` gained `select`/`lookup` types + `options`/`entity`/`fill`; AC_MAST/ITEM_MAST/GROUP_MAST code fields converted; `ac-groups` lookup entity; masters form `<FieldInput>` (select/LookupPicker + fill side-effect).
- **F2 Shared tender** — `finance/tender.ts` `payoutLegs` (money out) + `receiptLegs` (money in) self-balanced pairs (no-tender = byte-identical); `components/TenderPanel.tsx`.
- **F3 Auto tag numbering** — `numbering.ts` `nextTagNoTx` over `SRNO_MAST.TAG_SRNO` (shares the voucher advisory lock); `tagOpening` auto-allocates barcodes when blank.
- **F4 SL_ORD_ADJ helpers** — `orderAdvanceAvailableTx` / `adjustOrderIntoSaleTx` (book ORA) / `cancelSalesOrderAdjust` (book ORC + balanced refund).
- **F5 Voucher chrome** — `components/VoucherChrome.tsx` (Vch No / Date+weekday / Ref No header + ◀▶ Print Save Cancel Delete Exit action bar); wired into Sales + Purchase pages (Save = native submit, Print = invoice HTML, Exit = router.back).

**P0 items**
- **P0-1 Labour Invoice** — new `sales/labourInvoice.ts`: dual GST (metal 3% + labour 5% → 2 TAX_DATA rows), order-gold Cr-fine leg, LBR_DATA/LBR_ISU_DETL/BILL_OS; POST+DELETE `/labour-invoice`; labour page repointed. Inject 6/6.
- **P0-2 Purchase-side settlement** — purchase / other-purchase / purchase-return append tender legs + header CASH/CHQ/CARD/KASAR/BILL_OS; pages get TenderPanel. Inject 7/7.
- **P0-3 Order advance → Sale** — `createSale` `orderRef{ordNo,adjustAmt}`; clamps + reduces BILL_OS + writes SL_ORD_ADJ; sales page Ord-No/Order-Amt. Inject 6/6.
- **P0-4 Sales Return** — `saleForReturn` import-from-bill (GET `/sales-returns/import`) + refund tender (payoutLegs) + credit-note BILL_OS; existing re-stock retained; page Import button + refund TenderPanel. Inject 8/8.
- **P0-5 Order Cancel refund** — POST `/sales-orders/:vchNo/cancel-refund` → `cancelSalesOrderAdjust`; order-cancel page Refund (PaiidAc picker + amt + kasar) alongside Void.
- **P0-6 Rich Tag Opening** — `TagOpeningLine` + BAR_DETL Counter/Design/Size/LsWt/Lbr%/LbrRate/OthAmt/TagCost; page rich grid + auto-barcode display + item picker. Inject 2/2.
- **P0-7 Karigar rich grids** — `KarigarLine` rich fields (design/counter/size/othWt/ghtWt/per-line labour); receive adds per-line labour + labour GST split + optional F3 auto-tagging (BAR_DETL); shared `KarigarForm` rewritten (party picker + live balance + GST + tag toggle). Inject 8/8.
- **P0-8 Karigar report inversion** — `reports.ts`/`reports4.ts` issued/received swap fixed to match `INOUT_TYPE` 'O'=issue / 'I'=receipt. Inject 4/4.

Posting engine / period-lock / fine-math untouched; every new voucher balances + is reversible; additive schema use only.


---

## PARITY-GAP-PLAN Phase 2 (P1) — COMPLETE (all 19 items)

All P1 items implemented + verified (per-item: api build + web typecheck clean, e2e inject on isolated `e2e` tenant, full suite **151/151**, demo `default` intact SL=191/AC=5150/ACMAST=918/BAR=1329, `:4000` restarted). Additive-schema-only; every new voucher balances + reverses.

- **P1-2 Company detail** — full CO_MAST_CONFIG formFields (State lookup + Work/Metal selects + GST/PAN/CST/address/bank/jurisdiction) + `states` lookup entity.
- **P1-13 Other-Exp F/R + HSN** — per-line `{hsnCode,taxPct,taxType}`; R = inclusive back-calc; PAY_DETL per-line HSN + per-rate TAX_DATA; frontend HSN/Type/Tax% grid.
- **P1-10 Multi-line receipt/payment** — `postReceiptLines`/`postPaymentLines` (one voucher, per-party legs + kasar → CASH_DATA/PAY_DATA + PAY_DETL); PaymentForm multi-line toggle.
- **P1-12 Bill-to-Bill mixed tender** — `settleBills` `tenders[]` (Σ must equal received); tender grid + reconcile guard.
- **P1-5 Party fields** — AC_MOBILE2/AC_PHONE2/RefBy-lookup/KHATA/BR_DATE/AN_DATE(+`date` field type)/limits.
- **P1-1 Sales Invoice fidelity** — SL_DETL Design/Size/LsWt/Lbr%/LbrRate/LbrType/OthAmt + SL_DATA CR_DAYS/EMP_CODE; sales grid + settlement fields.
- **P1-16 Stock Adjust fields** — Counter/Design/Size/West%/MRP/Karigar + Sign + tag autofill + wastage-aware fine.
- **P1-17 Tag Transfer** — resolves the real source item from BAR_DETL (guard against wrong-item OUT) + rich cols + tag autofill.
- **P1-18 Tag Cancel** — in-stock guard + BAR_CAN_DATA/DETL register.
- **P1-15 Daily Rate grid** — `getDailyRate`/`dailyRateDates` + per-group overrides + Tax%/Employee; editable grid + history.
- **P1-8 Tag Weight Change** — routes the fine diff to the karigar party gold leg + old-gold absorption + labour payment (legacy path intact).
- **P1-6 Physical Stock** — rebased on BAR_DETL; `physicalStockList` + per-tag DiffWt reconcile; scan/count grid.
- **P1-4 Auto Item** (new) — `bulkAutoItem` (code=GR+PR, name=group+product) + page + nav.
- **P1-7 Tag Print** (new) — `listPrintableTags`+`renderTagLabels`; GET `/stock/tag-print`+`/label`; page + nav.
- **P1-3 User rights matrix** — `formCatalog.ts` + GET `/admin/form-catalog`; per-user Main/Form × View/Edit/Delete/Print grid (RBAC backend pre-existing).
- **P1-9 Reminder datasets** — dataset tabs (Receivables/Orders/Birthdays[wired]/Dhiran).
- **P1-14 Tour Isu-No → Sales** — `tourLines` + `markApprovalBilled` (EMP_SALE='Y'); GET `/tour/:vchNo/lines` + POST `/tour/:vchNo/bill`; tour-return Load-lines.
- **P1-11 Per-bank Book + Chq No** — `books` lookup + cheque-print (`amountInWords`+`renderCheque`); Chq-No already captured. Book→bank auto-link deferred (no bankAc column).
- **P1-19 Backup completeness** — expanded backup TABLES (BAR_*/MAIN_STOCK/ITM_OPBL/OP_DATA/LOGIN_MAST/USER_SET/CO_SET/SRNO_MAST/YEAR_MAST/AC_GROUP/TABLE_MAST/…) + `restoreCompany` (SAVEPOINT-safe, RLS-scoped, tenant_id-forced) + GET `/backup` + POST `/backup/restore`.

Deferred (documented, not blocking): WhSales/Scheme/ItemInOut reminder datasets (no ready due-list endpoint); book→bank auto-link + per-book default legs (BOOK_DATA has no bankAc column). P2 phase (print templates, contra grid, etc.) remains as the next phase.


---

## PARITY-GAP-PLAN Phase 3 (P2) — COMPLETE (all 11 items)

All P2 polish/print/display items implemented + verified (per-item: api build + web typecheck clean, e2e inject on isolated `e2e` tenant, full suite **151/151**, demo `default` intact SL=191/AC=5150/ACMAST=918, `:4000` clean boot). Additive-schema-only; posting/period-lock/fine-math untouched.

- **P2-3 Bank-Recon polish** — `bankReconList` running per-row AmtBal + party-name join + opening-balance-carried-forward row + bank name; page From/To default to current month.
- **P2-2 Contra two-line grid** — `ContraInput.itDesc` → CONTRA_DATA.IT_DESC; page rebuilt as a Dr/Cr two-line grid with equal-amount validation + narration.
- **P2-11 Tag-Stock Report** — new `tagStock.ts` (In/Out/Stock/MRP/Apr-Pending/All tabs over MAIN_STOCK/BAR_DETL/APR_DETL) + totals + CSV export; page + nav.
- **P2-1 Print templates** — `invoiceHtml` copy label (Original/Duplicate/Triplicate) + Print button; `/sales/invoice?copy=O|D|T`.
- **P2-9 Voucher list/edit/delete/navigate** — new generic `recentVouchers` (allow-listed, column-detected) + `/vouchers/recent` + reusable `<VoucherList>` (list/print/delete/load) on sales + purchase.
- **P2-8 Karigar print + ledger** — `karigarLedger` (per-karigar KR_DETL movements + running fine balance) + `renderKarigarLedgerHtml`; `/reports/karigar-ledger(.print)`; page + nav.
- **P2-5 Reminder Entry columns** — EntDate (spare MAIN_BOOK) + RemDate (VCH_DATE) + Mobile (AC_MAST join); page columns.
- **P2-4 Labour Update multi-slab** — `getLabourSlabs`/`setLabourSlabs` over ITM_WT_MAST keyed by SR_NO (multiple weight slabs persist); page slab editor.
- **P2-10 Purchase URD + Only-Tag-Entry** — `PurchaseInput.urd` (forces GST 0 for unregistered dealers); URD toggle on page. Only-Tag-Entry = existing tag-opening (F3 auto-barcode, no money).
- **P2-6 Year Create** — new `year.ts` (create/list/close/reopen + `carryForwardOpenings`: prior-year closing party balances → new-year OP_DATA opening); page + nav.
- **P2-7 Party photo + Family + inline opening** — new `party.ts` (photo ↔ AC_IMAGE bytea; family = accounts sharing AC_KHATA_NO) + inline opening via existing `/accounts/:ac/opening`; new tabbed Party page (Details/Photo/Family/Opening) + nav.

Deferred (documented, no backing schema): distinct ENT_DATE column (used spare MAIN_BOOK); book→bank auto-link (no bankAc on BOOK_DATA).

### PARITY-GAP-PLAN — ALL PHASES COMPLETE
Foundations F1–F5 ✓ · Phase 1 P0 (8) ✓ · Phase 2 P1 (19) ✓ · Phase 3 P2 (11) ✓ — **43 items total**, each verified (suite 151/151, demo intact, clean boot).
