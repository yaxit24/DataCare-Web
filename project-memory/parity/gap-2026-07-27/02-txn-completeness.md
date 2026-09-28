# 02 — Transaction / Inventory / Manufacturing Completeness (desktop → CURRENT web)

**Date:** 2026-07-27 · **Scope:** 25 desktop TR_* forms mapped to current web (Fastify API `apps/api/src/modules/*` + Next UI `apps/web/app/(app)/txn/*`).
**Method:** desktop write-set from `project-memory/catalogs/forms/<FORM>.md` ("Tables written on save"), cross-checked against decompiled `unified/src/csharp/DataCareNext/<FORM>.cs`; web write-set read directly from each module's `postVoucherTx({writes:[...]})` and route wiring in `apps/api/src/routes/txn.ts`. Every row cites file:line. Prior parity docs were **not** trusted — all findings are from current source.

**Classes:** `DEDICATED` = real ported engine + UI writing the satellite tables · `GENERIC` = thin reuse of another form's endpoint / metadata scaffold only · `STUB` = route/UI exists but core posting incomplete · `MISSING` = no web counterpart.

---

## Verdict summary

- **MISSING (0):** none of the 25 are wholly absent.
- **GENERIC / thin-reuse (1):** TR_WH_SALE (posts to `/sales`, no wholesale engine).
- **STUB / behavior-incomplete (3):** TR_PHYSTK (report-only, no adjustment posting), TR_SL_ORD_ADJ (no standalone form; folded into sale), TR_MLT_PRO (records melt but posts no stock movement).
- **DEDICATED (21)** — but 12 of these have material satellite-table or sub-grid gaps (stones `SL_IDTL`/`PR_IDTL`/`BAR_IDTL`, diamond `DM_DATA`, rate-cut, `APR_*`, `MFG_ISU_REC` projection, labour re-tag).

---

## Master table

| Form | Desktop tables written (save) | Web module:line | Class | Key missing behaviors | Severity |
|---|---|---|---|---|---|
| TR_SALE | SL_DATA, SL_DETL, SL_IDTL, MAIN_STOCK, AC_DATA, TAX_DATA, ROJ_MEL_DATA, BILL_OS_DATA, UPI_DATA, CARD_DATA, POINT_DATA/POINT_MEMB, DM_DATA, CRNT_DATA, COMM_DATA, SL_PR_DETL, SL_ORD_ADJ, PRINT_MAST | `sales/sales.ts:874`; route `txn.ts:349` | DEDICATED | No `ROJ_MEL_DATA` daily-cash row; no `CARD_DATA`/`UPI_DATA` split rows (tender folded into AC_DATA legs); no loyalty `POINT_DATA`/`POINT_MEMB`; no `COMM_DATA` (agent commission); no `CRNT_DATA`; no `PRINT_MAST` copy-count. SL_IDTL stone sub-grid IS written. | MEDIUM |
| TR_SALE_LBR | LBR_DATA, LBR_ISU_DETL, LBR_REC_DETL, MAIN_STOCK, AC_DATA, TAX_DATA, BILL_OS_DATA, CARD_DATA, UPI_DATA, DM_DATA, ROJ_MEL_DATA, SL_ORD_ADJ | `sales/labourInvoice.ts:246`; route `txn.ts:523` | DEDICATED | No `LBR_REC_DETL` (labour receive/settle side); no `MAIN_STOCK` movement; no `CARD_DATA`/`UPI_DATA`/`DM_DATA`/`ROJ_MEL_DATA`; no order-adjust link. Writes LBR_DATA+LBR_ISU_DETL+TAX_DATA+BILL_OS_DATA only. | MEDIUM |
| TR_SALE_HM | SL_DATA, SL_DETL, SL_IDTL, MAIN_STOCK, AC_DATA, TAX_DATA, BILL_OS_DATA, UPI_DATA, DM_DATA, ROJ_MEL_DATA, PR_DATA/PR_DETL/PR_IDTL (old-gold buy), SL_PR_DETL, SL_ORD_ADJ | `sales/sales.ts` via `/sales` (UI `hallmark-sale/page.tsx:133`) | DEDICATED | HUID captured per line + hallmark charge + old-gold (as `SL_PR_DETL`). But old gold booked as sale sub-detail, **not** a separate PURCHASE voucher (`PR_DATA/PR_DETL/PR_IDTL`) as desktop; no dedicated HUID register write; same tender gaps as TR_SALE. | MEDIUM |
| TR_SALE_ORD | SL_ORD_DATA, SL_ORD_DETL, SL_ORD_IDTL, AC_DATA, ROJ_MEL_DATA, UPI_DATA, MAIN_STOCK, SL_ORD_ADJ, PR_DATA/DETL/IDTL, SL_PR_DETL | `sales/salesOrder.ts:148`; route `txn.ts:480` | DEDICATED | Advance receipt tender not split to `UPI_DATA`; no `ROJ_MEL_DATA`; no old-gold `PR_*`/`SL_PR_DETL` at order time. Header/detail/stone trio written. | MEDIUM |
| TR_SALE_RTN | SL_DATA, SL_DETL_RTN, SL_IDTL, MAIN_STOCK, AC_DATA, TAX_DATA, BILL_OS_DATA, BAR_DATA/BAR_DETL/BAR_IDTL, DM_DATA, RATE_CUT_ISU_REC, ROJ_MEL_DATA, TAG_SET | `sales/salesReturn.ts:467`; route `txn.ts:427` | DEDICATED | No `SL_IDTL` stones on return; no re-tag of returned goods (`BAR_DATA/BAR_DETL/BAR_IDTL` + `TAG_SET`); no `DM_DATA`; no `RATE_CUT_ISU_REC`; no `ROJ_MEL_DATA`. Writes SL_DATA+SL_DETL_RTN+MAIN_STOCK+TAX_DATA. | HIGH |
| TR_WH_SALE | AC_DATA, MAIN_STOCK, RATE_CUT_DATA, RATE_CUT_ISU/REC/ISU_REC, DM_DATA, LOT_DETL, SL_IDTL, TAX_DATA, ROJ_MEL_DATA, APR_DETL, TOUCH_MAST | **reuses** `/sales` → `sales/sales.ts` (UI `wholesale-sale/page.tsx:98`) | **GENERIC** | No wholesale engine at all: posts a plain retail `/sales`. Missing **rate-cut** issue/receive (`RATE_CUT_DATA/ISU/REC`), consignment/approval (`APR_DETL`), `LOT_DETL`, `TOUCH_MAST`. Wholesale is a distinct 730 KB desktop form (`TR_WH_SALE.cs`) collapsed to retail sale. | HIGH |
| TR_SL_ORD_ADJ | SL_ORD_ADJ, BAR_DETL, BAR_IDTL, AC_DATA, APR_DETL, MAIN_STOCK, ROJ_MEL_DATA | folded into `sales/sales.ts` `adjustOrderIntoSaleTx` (`sales.ts:~905`); cancel/refund `txn.ts:508` | **STUB** | No standalone bill-wise order-adjustment form/endpoint (desktop `BillWiseOrderAdjust.rpt`). `SL_ORD_ADJ` is only written implicitly when a sale consumes an order advance; the `order-cancel/page.tsx` only voids + refunds. No `APR_DETL`/`BAR_*` re-issue path. | MEDIUM |
| TR_PURC | PR_DATA, PR_DETL, PR_IDTL, BAR_DATA, BAR_DETL, BAR_IDTL, MAIN_STOCK, AC_DATA, TAX_DATA, ROJ_MEL_DATA, DM_DATA, ITM_LOT_DETL, LOT_DETL, SL_PR_DETL, TAG_SET, TOUCH_MAST, SRNO_MAST, APR_DETL | `purchase/purchase.ts:729`; route `txn.ts:820` | DEDICATED | No `PR_IDTL` (stone/diamond sub-grid on purchase); no `DM_DATA`; no `ITM_LOT_DETL`/`LOT_DETL` lot tracking; no `TAG_SET`/`SRNO_MAST`/`TOUCH_MAST` maintenance; no `ROJ_MEL_DATA`; `APR_DETL` (consignment) not updated. Writes PR_DATA+PR_DETL+BAR_DETL+BAR_IDTL+MAIN_STOCK+TAX_DATA+BILL_OS_DATA. | HIGH |
| TR_PURC_HM | BAR_DETL, BAR_IDTL, MAIN_STOCK, AC_DATA, TAX_DATA, DM_DATA, LOT_DETL, TAG_SET, SRNO_MAST | `purchase/purchase.ts` via `/purchases` (UI `purchase-hm/page.tsx:86`) | DEDICATED | HUID + hallmark charge captured and routed through `/purchases`; inherits all TR_PURC gaps (`PR_IDTL`, `DM_DATA`, `LOT_DETL`, `TAG_SET`). No separate hallmark-purchase book/register. | MEDIUM |
| TR_OTH_PURC | PAY_DATA, PAY_DETL, AC_DATA, TAX_DATA, ROJ_MEL_DATA | `purchase/purchase.ts:911` `createOtherPurchase`; route `txn.ts:866` | DEDICATED | Writes PAY_DATA + PAY_DETL (HSN/F-R/CGST-SGST-IGST) + TAX_DATA + AC_DATA + tender legs. Missing only `ROJ_MEL_DATA` daily-cash row. Strong parity. | LOW |
| TR_TAG_OPBL | BAR_DATA, BAR_DETL, BAR_IDTL, MAIN_STOCK, SRNO_MAST, TAG_PRINT_DATA, TAG_SET | `stock/stock.ts:509` `tagOpening` (writes `:638-641`); route `txn.ts:2030` | DEDICATED | Writes BAR_DATA+BAR_DETL+BAR_IDTL+MAIN_STOCK. Missing `SRNO_MAST` (tag-number series), `TAG_SET`, `TAG_PRINT_DATA` (label queue). | MEDIUM |
| TR_TAG_SPLIT | BAR_DATA, BAR_DETL, BAR_IDTL, MAIN_STOCK, LBR_DATA, LBR_ISU_DETL, LBR_REC_DETL, BILL_OS_DATA, DM_DATA, RATE_CUT_ISU_REC, TAG_PRINT_DATA, TAG_SET | `stock/tagSplit.ts`; route `txn.ts:2876` | DEDICATED | Splits parent tag into children (BAR_* + MAIN_STOCK). Missing labour-on-split (`LBR_DATA/LBR_ISU_DETL/LBR_REC_DETL`, `BILL_OS_DATA`), `DM_DATA`, `RATE_CUT_ISU_REC`, `TAG_PRINT_DATA`. | MEDIUM |
| TR_TAG_CAN | BAR_CAN_DATA, BAR_CAN_DETL, BAR_CAN_IDTL, MAIN_STOCK, DM_DATA, LOT_DETL, +UPDATE BAR_DETL | `stock/tagOps.ts` `tagCancel` (writes `:164-168`); route `txn.ts:2128` | DEDICATED | Writes MAIN_STOCK('-')+BAR_CAN_DATA+BAR_CAN_DETL. Missing `BAR_CAN_IDTL` (cancelled stones), `DM_DATA`, `LOT_DETL`; does **not** update/flag `BAR_DETL` (relies on MAIN_STOCK '-' guard, so tag row persists in BAR_DETL). | MEDIUM |
| TR_TAG_WT_DIFF | BAR_DETL(upd), BAR_IDTL, DM_DATA, LBR_DATA, LBR_ISU_DETL, LBR_REC_DETL, MAIN_STOCK, RATE_CUT_ISU_REC, ROJ_MEL_DATA, TAX_DATA, TAG_PRINT_DATA, AC_DATA | `stock/tagOps.ts` `tagWeightDiff` (writes `:366`); route `txn.ts:2140` | DEDICATED | Self-described "simplified net-of-difference" model: one signed `MAIN_STOCK` of |Δnet| + AC_DATA pair. Desktop replaces whole tag (full OUT + full IN). Missing full replacement, `BAR_IDTL`, `DM_DATA`, `LBR_*`, `RATE_CUT_ISU_REC`, `ROJ_MEL_DATA`, `TAX_DATA`, `TAG_PRINT_DATA`. | HIGH |
| TR_PHYSTK | BAR_DETL(ins/upd), BAR_IDTL, MAIN_STOCK(upd), TAG_PRINT_DATA, BAR_CAN_DATA/DETL, APR_DETL | `stock/stock.ts:325` `physicalReconcile` + `:417` list; route `txn.ts:2171` | **STUB** | **Report-only.** `physicalReconcile` READS `BAR_DETL` and returns matched/missing/extra + Δwt but **writes nothing** — it never posts the count adjustment to `MAIN_STOCK`/`BAR_DETL` (no write-off of shortage, no surplus-in, no per-tag weight correction). Desktop posts the reconciliation. | HIGH |
| TR_ITM_LOT | BAR_DATA, ITM_LOT_DETL, MAIN_STOCK, TAG_PRINT_DATA | `stock/stock.ts:804` `itemLot`; route `txn.ts:2055` | DEDICATED | Writes ITM_LOT_DETL + MAIN_STOCK('+'). Missing `BAR_DATA` (lot→tag master) and `TAG_PRINT_DATA`. | LOW |
| TR_ITM_OPBL | ITM_OPBL, MAIN_STOCK, DM_DATA | `stock/stock.ts:671` `itemOpening`; route `txn.ts:2038` | DEDICATED | Writes ITM_OPBL + MAIN_STOCK('+'). Missing `DM_DATA` (diamond opening). Strong parity. | LOW |
| TR_MFG_ISU_REC | MFG_DATA, MFG_DETL, MFG_IDTL, MFG_ISU_REC, MAIN_STOCK, TAG_PRINT_DATA | `manufacturing/mfg.ts:690` (issue/receive); routes `txn.ts:1592`/`1609` | DEDICATED | Full trio + MFG_ISU_REC signed metal-flow + MAIN_STOCK + lot-balance (`recWt`, `mfgLotBalance`). Missing only `TAG_PRINT_DATA` and `MENU_DATA` counters. Strong parity. | LOW |
| TR_MFG_ORD_ISU | APR_DATA, APR_DETL, APR_IDTL, MAIN_STOCK, MFG_DETL, MFG_ISU_REC, +UPDATE SL_ORD_DETL | `manufacturing/mfg.ts` `issueMfg` (book 'DIS'); route `txn.ts:1625` | DEDICATED | Marks the consumed order line (`SL_ORD_DETL.DESIGN_ISU='Y'`) and writes MFG trio+MFG_ISU_REC+MAIN_STOCK. **Missing the `APR_DATA/APR_DETL/APR_IDTL` approval-issue records** the desktop creates for the design-out. | MEDIUM |
| TR_MFG_ORD_REC | MFG_DATA, MFG_DETL, MFG_IDTL, MFG_ISU_REC, MAIN_STOCK, TAG_PRINT_DATA, +UPDATE APR_DETL | `manufacturing/mfg.ts` `receiveMfg`; route `txn.ts:1609` | DEDICATED | Writes MFG trio + MFG_ISU_REC('+') + MAIN_STOCK + labour Dr/Cr. Missing `APR_DETL` (approval close-out) and `TAG_PRINT_DATA`. No dedicated order-receive UI (uses generic mfg-receive). | MEDIUM |
| TR_MFG_WITH_LOT | MFG_DATA, MFG_DETL, MFG_IDTL, MFG_ISU_REC, MAIN_STOCK, TAG_PRINT_DATA, +UPDATE MENU_DATA | `manufacturing/mfg.ts` (lotNo + `mfgLotBalance`); routes `txn.ts:1592/1609` | DEDICATED | Lot-tracked issue/receive folded into the unified mfg engine (per-lot balance query). **No dedicated UI page** for lot-wise entry; `MENU_DATA`/`TAG_PRINT_DATA` not written. | MEDIUM |
| TR_MFG_GHAT_REC | MFG_DATA, MFG_DETL, MFG_IDTL, MFG_ISU_REC, MAIN_STOCK, +UPDATE APR_DETL | `manufacturing/mfg.ts` `receiveMfg` (IR_TYPE 'G', `itmGhat`/`rtnChol`/`rtnGhis`/`itmLoss`); route `txn.ts:1609` | DEDICATED | Ghat/casting-gate + chol/ghis/loss reconciliation computed and stored (`fineWithGhat`, `recWt`). **No dedicated ghat UI page**; ghat/wastage inputs only via generic mfg-receive body fields. `APR_DETL` not updated. | MEDIUM |
| TR_KR_ISU | MFG_ISU_REC, DM_KR_DATA, MAIN_STOCK, AC_DATA, BAR_DETL, BAR_IDTL, DM_DATA, TAX_DATA, ROJ_MEL_DATA | `manufacturing/karigar.ts:214` `issueKarigar`; route `txn.ts:1558` | DEDICATED | Writes `KR_DATA`/`KR_DETL` (own tables) + AC_DATA gold-leg + MAIN_STOCK('-'). **Divergence:** desktop projects karigar issue into `MFG_ISU_REC` (the metal-flow ledger MFG reports read) — web does not, so karigar metal is invisible to `MFG_ISU_REC`-based reports. Missing `DM_KR_DATA` (diamonds to karigar), `TAX_DATA`, `ROJ_MEL_DATA`. | MEDIUM |
| TR_MLT_PRO | MLT_DATA, MLT_DETL, MFG_DETL, MFG_ISU_REC, MAIN_STOCK, +UPDATE SL_DATA | `manufacturing/melting.ts` `meltProcess`; route `txn.ts:~1660` (`/melting`) | **STUB** | Records the melt (MLT_DATA+MLT_DETL, party/net/loss fine) but posts **no inventory movement**: no `MAIN_STOCK` (scrap OUT / recovered fine IN) and no `MFG_ISU_REC` projection. Melting does not change stock in web. | HIGH |
| TR_REP_REC | REP_DATA, REP_DETL, AC_DATA, TAX_DATA, ROJ_MEL_DATA, TEMP_BOOK_DATA | `repair/repairReceipt.ts:901`; route `txn.ts:1231` | DEDICATED | Full customer-repair workflow (receipt + karigar issue + karigar receipt stages), writes REP_DATA+REP_DETL+AC_DATA+TEMP_BOOK_DATA+ROJ_MEL_DATA, load/edit/delete/print. Strongest transaction parity in the set. | LOW |

---

## postVoucherTx vs desktop INSERT — cross-check notes

- The web posting core (`posting/posting.ts:200` `postVoucherTx`) is sound: it enforces `assertBalanced` (Σ CR = Σ DR), `assertPeriodOpen` (CO_SET.LOCK_DATE), stamps `DATA_TYPE='A'`, and writes every `writes[]` table + AC_DATA in one tenant tx. Reversal (`reverseVoucherTx:` derives CO_CODE/VCH_DATE from persisted rows before delete). These prior "critical" items (period-lock on reversal, server-derived reversal, numbering concurrency) are **CLOSED** — confirmed, not re-reported.
- The completeness gaps are **not** in the posting engine but in which satellite tables each caller passes into `writes[]`. Recurring omissions across DEDICATED forms: tender split rows (`CARD_DATA`/`UPI_DATA`), daily-cash (`ROJ_MEL_DATA`), diamond sub-ledger (`DM_DATA`), stone sub-grids on the buy/return side (`PR_IDTL`, return-side `SL_IDTL`, `BAR_CAN_IDTL`), consignment/approval (`APR_*`), rate-cut (`RATE_CUT_*`), label queue (`TAG_PRINT_DATA`).

---

## Top 10 completeness gaps (ranked)

1. **TR_WH_SALE has no engine (GENERIC).** `wholesale-sale/page.tsx:98` posts a retail `/sales`; entire wholesale rate-cut (`RATE_CUT_DATA/ISU/REC`), consignment (`APR_DETL`) and `LOT_DETL` flow of `TR_WH_SALE.cs` (730 KB) is absent. **HIGH**
2. **TR_PHYSTK is report-only (STUB).** `stock.ts:325 physicalReconcile` never writes the count adjustment (no `MAIN_STOCK`/`BAR_DETL` correction) — physical count does not fix inventory. **HIGH**
3. **TR_MLT_PRO posts no stock (STUB).** `melting.ts meltProcess` writes MLT_DATA/DETL only; no `MAIN_STOCK` scrap-out / fine-in and no `MFG_ISU_REC` — melting is invisible to stock & metal-flow. **HIGH**
4. **TR_PURC missing `PR_IDTL` + lot + diamond.** `purchase.ts:729` writes no purchase stone/diamond sub-grid (`PR_IDTL`, `DM_DATA`), no `ITM_LOT_DETL`/`LOT_DETL`, no `TAG_SET`/`SRNO_MAST`. **HIGH**
5. **TR_SALE_RTN missing re-tag + stones.** `salesReturn.ts:467` does not re-create `BAR_DATA/BAR_DETL/BAR_IDTL`(+`TAG_SET`) for returned goods, nor `SL_IDTL`/`DM_DATA`/`RATE_CUT_ISU_REC` — returned pieces are not put back as identifiable stock. **HIGH**
6. **TR_TAG_WT_DIFF over-simplified.** `tagOps.ts tagWeightDiff` books only |Δnet| instead of desktop full OUT+IN tag replacement; drops `LBR_*`, `RATE_CUT_ISU_REC`, `TAX_DATA`, `BAR_IDTL`, `ROJ_MEL_DATA`. **HIGH**
7. **TR_KR_ISU writes `KR_DATA/KR_DETL`, not `MFG_ISU_REC`.** `karigar.ts:214` — karigar-issued metal never lands in the `MFG_ISU_REC` ledger the MFG/karigar reports read; also drops `DM_KR_DATA`. **MEDIUM**
8. **MFG order flow drops `APR_*` approval records.** `TR_MFG_ORD_ISU`/`TR_MFG_ORD_REC` via `mfg.ts` update `SL_ORD_DETL` but never write `APR_DATA/APR_DETL/APR_IDTL` design-approval satellites. **MEDIUM**
9. **TR_SL_ORD_ADJ has no standalone form.** Bill-wise order-advance adjustment (`SL_ORD_ADJ`+`APR_DETL`+`BAR_*`) exists only implicitly inside `sales.ts adjustOrderIntoSaleTx`; no dedicated UI/endpoint. **MEDIUM**
10. **Tender/daily-cash & diamond satellites omitted broadly.** TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD fold cash/card/UPI into AC_DATA legs and skip `CARD_DATA`/`UPI_DATA`/`ROJ_MEL_DATA`/`DM_DATA`/`POINT_*` — day-book, card/UPI registers and loyalty diverge from desktop. **MEDIUM**

---

## 20-line summary

1. Coverage: 25/25 desktop TR_* forms have some web counterpart; **0 fully MISSING**.
2. GENERIC (thin reuse): **TR_WH_SALE** → posts plain `/sales`, no wholesale engine.
3. STUB / behavior-incomplete: **TR_PHYSTK**, **TR_SL_ORD_ADJ**, **TR_MLT_PRO**.
4. DEDICATED: 21 forms, of which 12 have material satellite/sub-grid gaps.
5. Posting core (`postVoucherTx`) verified sound: balanced ledger, period-lock, single-tx, derived reversal — prior "critical" items CLOSED.
6. Gaps are in per-form `writes[]` composition, not the engine.
7. TR_PHYSTK reconcile is **report-only** — count never adjusts `MAIN_STOCK`/`BAR_DETL` (HIGH).
8. TR_MLT_PRO records the melt but posts **no `MAIN_STOCK`/`MFG_ISU_REC`** (HIGH).
9. TR_WH_SALE loses rate-cut (`RATE_CUT_*`), consignment (`APR_DETL`), lot (`LOT_DETL`) (HIGH).
10. TR_PURC lacks `PR_IDTL` stone sub-grid, `DM_DATA`, `ITM_LOT_DETL`/`LOT_DETL` (HIGH).
11. TR_SALE_RTN does not re-tag returned goods (`BAR_*`,`TAG_SET`) or write `SL_IDTL`/`DM_DATA` (HIGH).
12. TR_TAG_WT_DIFF simplified to net-diff; drops labour, rate-cut, tax, full tag replace (HIGH).
13. TR_KR_ISU writes `KR_DATA/KR_DETL` instead of desktop `MFG_ISU_REC`; drops `DM_KR_DATA` (MEDIUM).
14. TR_MFG_ORD_ISU/REC omit `APR_DATA/APR_DETL/APR_IDTL` approval records (MEDIUM).
15. TR_MFG_WITH_LOT & TR_MFG_GHAT_REC work via the unified mfg engine but have **no dedicated UI**; ghat/wastage/lot inputs only through generic mfg-receive fields (MEDIUM).
16. TR_SL_ORD_ADJ: no standalone bill-wise adjust form; only implicit `SL_ORD_ADJ` during sale (MEDIUM).
17. Retail-sale family (TR_SALE/HM/LBR/ORD) skips `CARD_DATA`/`UPI_DATA`/`ROJ_MEL_DATA`/`DM_DATA`/`POINT_*` (MEDIUM).
18. TR_SALE_HM books old gold as `SL_PR_DETL` (sale sub-detail), not a separate `PR_*` purchase voucher (MEDIUM).
19. Strongest parity: **TR_REP_REC**, **TR_OTH_PURC**, **TR_MFG_ISU_REC**, **TR_ITM_OPBL**, **TR_ITM_LOT** (LOW).
20. Priority fixes: (a) post TR_PHYSTK & TR_MLT_PRO stock movements, (b) build a real TR_WH_SALE rate-cut/consignment engine, (c) add `PR_IDTL`/re-tag/`APR_*`/tender satellites to purchase, sale-return and MFG-order paths.
