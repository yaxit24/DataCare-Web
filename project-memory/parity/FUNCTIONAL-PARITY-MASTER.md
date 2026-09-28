# FUNCTIONAL-PARITY MASTER (field / button / flow depth) — desktop ↔ web
_2026-06-30. Five parallel agents re-read the decompiled desktop C# forms + shared engines and compared, line-by-line (file:line both sides) + live DB, against the CURRENT web code — NOT surface coverage. Per-area detail: `project-memory/parity/functional/{sales,purchase_inventory,manufacturing,finance_dhrn,masters_reports}.md`._

## 0. Headline (the honest deep verdict)
At the **field/button/flow** level, **almost no transaction form is FULLY at parity** even when it "exists":
- **Fully-OK transaction forms: 2** (e-invoice/IRN, estimate).
- **DEPTH-partial (form exists, missing fields/legs/satellite tables/validation): ~28.**
- **BREADTH-missing (no web flow at all): ~20.**
- Behaviour-level (sales scored 28 behaviours): OK 12 · DEPTH 15 · GAP 1.

So the earlier "≈50% of forms present" is true for **breadth**, but **DEPTH parity is near-zero** — present forms persist a subset of columns/legs and expose a subset of fields/buttons. This is the gap the user is feeling. Crucially, most missing depth maps to desktop features the DHAKAN dataset never exercised (0 rows), so **data fidelity stays exact** while **behavioural/feature parity is partial**.

## 1. Per-area tally (current, post this session's fixes)

| Area | Forms | OK | DEPTH | BREADTH | Biggest gap |
|---|---|---|---|---|---|
| Sales (TR_SALE/HM/LBR/ORD/RTN/WH/EBILL) | 9 surfaces | 2 | 7 | 0 | shallow ledger; order/wholesale/hallmark depth; counter validations |
| Purchase + Inventory/Tags | 11 | 0 | 5 | 6 | PURC_HM/OTH/ITM_OPBL/ITM_LOT/PHYSTK-posting/SL_ORD_ADJ missing |
| Manufacturing + Karigar + Melting | 10 | 0 | 4 | 5+ | MFG order/with-lot/item/jobwork-as-MFG missing; stage pipeline inert |
| Finance + Dhrn + Bullion + Tour + Inout | ~21 | 0 | 12 | 9 | BUL_SALE/TOUR_SALE/ORD/REP_REC/VP missing; interest helpers unwired |
| Masters / Reports / Statutory / RBAC | masters 33 · reports 45 | — | many | masters 4 · reports 17 | **no master UPDATE**; 17 reports; settings 11/61; per-form RBAC |

## 2. Cross-cutting DEPTH themes (recurring in EVERY area — highest leverage)

1. **Masters are not editable (NEW, high-impact).** `app.ts` exposes master **create / list / delete / import only — no UPDATE (no PUT/PATCH)**; the New form renders `requiredColumns` only, grid shows 9 cols. Desktop MS_* forms all edit every field. → DEPTH gap across **all 28 registered masters**.
2. **Shallow ledger decomposition.** Web posts **4–7 net AC_DATA legs vs desktop's ~33–39 gross**; `LD_CODE` = line ordinal (desktop = contra-account code); `VCH_TYPE` hard-coded ('SALE'/'TGSL'/'TGPR'…) vs `BOOK_DATA.BOOK_SNAME`; income/purchase to a single hard-coded `SALES`/`PURCHASE`/`GSTINPUT` account vs per-`GROUP_MAST.SALE_AC/PURC_AC` + `TAX_MAST.TAX_AC`; HM/TCS/TDS/scheme/points/kasar/cash-paid sub-legs absent. (Intentional layout non-goal for byte-parity, but the **per-group account + extra legs are real feature gaps**.)
3. **`ROJ_MEL_DATA` (rojmel day-book) never written by any form** (0 rows in DHAKAN → moot for fidelity; structural gap for shops that use it).
4. **Satellite/detail tables thin.** `MAIN_STOCK` ≈16/50 cols + tagged-only (untagged lines write no stock row); `TAX_DATA` omits `TAX_CODE`/`R_CHARG`; `BILL_OS_DATA` money-only (no metal OS); `CARD_DATA` omits the bank-commission tier; `EMP_DATA` omits `TDS_PRC/PF_PRC`+attendance; `LDR_ADJ_DATA` zero-fills the metal-diff columns.
5. **Config flags not honoured at runtime.** `MsCashLimit`, `MsIntYearDays`, `MsDhrnIntType` are not read; the dhrn **whole-month interest helpers I added (`monthsBetween`/`dhrnInterest`) exist + are unit-tested but are NOT wired into `/dhrn/receipt|interest`** (those still take operator-typed interest). Honest: that fix is currently library-only.
6. **Frontend field depth.** Recurring missing inputs: wastage% (`ITM_WEST_PRC`), DESIGN_NO, MRP, ITM_SIZE, GHAT%, RATE_TYPE, per-line discount, scheme, points, kasar, configurable round-off, TCS/TDS, multi-tender (multi-UPI/cheque-bank), multi-row old-gold, bill-date, remark.
7. **Validation + buttons.** Counter guards missing: credit/OS limit, cash-limit→PAN (rule still inverted per finance agent), defaulter, negative-stock; per-form actions missing: CUSTOMER/ACCOUNT print copies, WhatsApp/SMS-on-save, on-page e-invoice + delete.

## 3. BREADTH — desktop forms with NO web flow (build list)
- **Purchase/inventory:** TR_PURC_HM (hallmark purchase), TR_OTH_PURC (expense), TR_ITM_OPBL (item opening), TR_ITM_LOT (lot), TR_PHYSTK (physical-stock *posting*), TR_SL_ORD_ADJ (order adjust/cancel).
- **Manufacturing:** TR_MFG_ORD_ISU/REC (order-linked), TR_MFG_WITH_LOT, TR_MFG_ITEM (BOM), jobwork TR_JDT_REC (web writes KR_* not MFG_*).
- **Finance/loans:** TR_BUL_SALE (bullion sale), TR_TOUR_SALE, TR_TOUR_ORD, TR_REP_REC (dhrn repayment REP_DATA), TR_VP / TR_VP_ADJ, TR_FN_INOUT (web writes INOUT_DATA not FAN_DATA — table mismatch), OP_DATA on ac-opening; ledger-adjust + employee-JV have backend routes but **no frontend page**.
- **Masters (4):** MS_AUTO_ITEM, MS_TRADE, MS_STK_LIMIT, MS_TASTING.
- **Reports (17):** RP_BILL_PROFIT, RP_OTH_DETL, RP_ADDRESS, RP_CONSI_APR, RP_MFG, RP_MFG_LEDR, RP_MFG_ZOOM, RP_JDTR_ZOOM, RP_HUID, RP_ORDER, RP_ORD_TRACK, RP_TOUR_ZOOM, RP_STK_LEVEL, RP_GRAPH, RP_TAG_IMAGE, RP_USER, RP_CUST(last-visit) + pawnbroker Form8/Form12.

## 4. CLOSED this session (verified by the agents against current code)
MS_AC_GROUP registered · e-invoice HSN/unit master-driven · purchase BOOK_NAME/TAX-split/PR_DETL stamps/zero-tax-guard/global DATA_TYPE/metal-fine leg/period-lock · tag-opening stamps · karigar INOUT direction + metal sub-ledger leg · real MFG_DATA/DETL/IDTL/ISU_REC writer · CARD_DATA/UPI_DATA/LDR_ADJ_DATA/EMP_DATA writers · dhrn borrower-ledger debit + collateral DHRN_ISU_DETL/DHRN_DATA on issue · scheme installment/opening/maturity (AD_ADJ) · sale-return TAX+stock · sales-order lines · rate-cut · location-wise-sales/customer-crm/area-wise-sales/gst-input reports · RBAC setUserRights writer.

## 5. Prioritized remediation (by leverage × real usage)
**P0 — cross-cutting, touches everything / real data:**
- Master **UPDATE** endpoint + edit UI (unblocks editing all 28 masters).
- Per-group account resolution (`GROUP_MAST.SALE_AC/PURC_AC`, `TAX_MAST.TAX_AC`) replacing hard-coded SALES/PURCHASE/GSTINPUT; `VCH_TYPE`=`BOOK_SNAME`.
- Wire dhrn interest helpers into `/dhrn/receipt|interest` (+ honour `MsIntYearDays/MsDhrnIntType`); fix cash-limit/PAN rule direction.
**P1 — high-value present-form depth:** sales-order line grid + Order_Stk reservation; hallmark HM_AMT/HM_TAX charge; wholesale → RATE_CUT_ISU/REC engine; MAIN_STOCK full columns + untagged lines; frontend field depth (wastage/scheme/points/kasar/TCS/round-off/multi-tender); ledger-adjust + employee-JV frontend pages.
**P1 — breadth (real-row or common):** item-opening (ITM_OPBL 72 rows), bullion sale, dhrn repayment, MFG order/with-lot, TR_OTH_PURC.
**P2 — breadth (0-row capability) + reports:** tour sale/order, VP, MFG item/BOM, jobwork→MFG_*, the 4 masters, the 17 reports, per-form RBAC (USER_SET), settings 11→~20 cols, GSTR-3B inward/ITC, e-invoice optional NIC sections.
**Non-goals (documented):** exact AC_DATA physical-leg layout; metal fine-weight ledger on retail sales (DHAKAN retail is RATE_UNFIX='N' → money-only both sides); ROJ_MEL_DATA (0 rows).

## 6. Bottom line for the user
- **Data/compute/report fidelity for what this company recorded: still exact.**
- **Behavioural/feature parity (every field, button, flow): partial** — ~2 forms fully match, ~28 are depth-partial, ~20 are missing, plus the cross-cutting master-edit / ledger-decomposition / config-honouring gaps. The per-area files enumerate each with file:line on both sides; §5 is the build order to reach true functional parity.
