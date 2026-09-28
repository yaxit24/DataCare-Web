# Parity Gap Analysis — INVENTORY/TAGS + MANUFACTURING

_Session: `gap_inventory_mfg`. Generated 2026-06-29. Method: deep read of decompiled C# WinForms
(`extracted_code/DataCareNext/DataCareNext/*.cs`) vs web (`web/apps/api/src/modules/{stock,manufacturing}`
+ `web/apps/web/app/(app)/txn/*`). Formulas/tables cited by file:line. Analysis only — no code modified._

---

## 0. Executive summary

The web reproduces a **thin "metal-flow" abstraction** of this whole group and collapses three
genuinely-distinct desktop subsystems (karigar / manufacturing-process / job-work) into **one**
`karigar.ts` engine. Depth is ~10–15% of desktop.

- **Tag inventory**: web `tag-opening` + `stock` write a 15-column subset of a ~40-column
  `MAIN_STOCK` row and skip `TAG_SET / TAG_PRINT_DATA / SRNO_MAST / LOT_DETL / DM_DATA / TAG_IMAGE_DATA`.
- **Tag Split** (`TR_TAG_SPLIT`) and **Tag Weight-Diff** (`TR_TAG_WT_DIFF`) — two core inventory
  correction forms — **do not exist in the web at all** (no route, no page, no service).
- **Manufacturing**: the desktop MFG forms are a **multi-process, lot-tracked** system writing
  `MFG_DATA / MFG_DETL / MFG_IDTL / MFG_ISU_REC` with ghat/loss/chol/ghis reconciliation. The web
  has **no code that writes any `MFG_*` table**. `mfg-issue/mfg-receive/jobwork-issue/jobwork-receive`
  are 4 one-line pages that re-render `KarigarForm` and POST to the **karigar** endpoints (`KR_*`).
- **Melting** (`TR_MLT_PRO`): web writes `MLT_DATA/MLT_DETL` only; desktop also consumes the MFG
  process (`MFG_DETL/MFG_ISU_REC`) and posts a `MAIN_STOCK` movement.

### KEY QUESTION — are MFG / job-work genuinely distinct from karigar in the desktop?
**YES — they are different subsystems with different tables and richer logic.**

| Subsystem | Desktop tables | Per-line model | Web today |
|---|---|---|---|
| **Karigar** (`TR_KR_ISU`) | `KR_DATA / KR_DETL / KR_IDTL` (+AC_DATA, ROJ_MEL_DATA, TAX_DATA, DM_DATA, DM_KR_DATA, MAIN_STOCK) | issue fine out / receive fine in + wastage; labour amount | `karigar.ts` → `KR_DATA/KR_DETL` (partial) |
| **Manufacturing** (`TR_MFG_*`) | `MFG_DATA / MFG_DETL / MFG_IDTL / MFG_ISU_REC` (+MAIN_STOCK, AC_DATA, REMARK_DATA, TEMP_BOOK_DATA, APR_* for orders) | **process stage** (`IR_TYPE`), **lot** (`ITM_LOT`), ghat/loss/chol/ghis, diamond wt | **none** (pages alias karigar) |
| **Job-work** | Same `MFG_*` engine, job-work books | metal accountability vs an outside party across processes | **none** (pages alias karigar) |

So `MFG_*` is **not** a synonym for `KR_*`. The desktop `MFG_ISU_REC` row carries
`LOT_NO, IT_CODE, IR_TYPE (process), ITM_SIGN, IR_PCS, IR_WT, DM_WT, ITM_GWT, ITM_NWT, ITM_LOT,
ITM_GHAT, ITM_LOSS, RTN_CHOL, RTN_GHIS, KR_GHAT_WT, IR_YRCD`
(evidence: `TR_MFG_KR_ISU_REC.cs:7925, 7929, 8354, 9655`). None of this exists in `KR_DETL` or in the web.

---

## 1. Desktop computation formulas (extracted from .cs — the parity spec)

Grid columns differ per form; formulas verified by file:line.

### Karigar (`TR_KR_ISU.cs`) — grid col map: 9=NWT, 10=addl-wt, 11=TOUCH, 12=WEST%, 13=touch2, 14=FINE, 15=wastage-fine, 24=rate, 25=amt, 27=lbr-rate, 28=lbr-amt
- **Basic fine** (`:3933`): `FINE = NWT × touch / 100`
- **Wastage fine** (`:3940/3952/3964/3972`): `(NWT + addlWt) × (touch + west) / 100 − basicFine`
- **Fine incl wastage (item-master path)** (`:3579`): `NWT × (touch + west) / 100`
- **Fine → amount** (`:4012`): `amt = round(fine × rate / 1000, 0)`
- **Labour amount** (`:4031`): `lbrAmt = round((NWT + addlWt) × lbrRate / 1000, 0)`
- WEST% defaults from `KR_WEST_PRC` / `ITM_WEST_PRC` / `ITEM_MAST.IT_WEST` / `TOUCH_MAST.AC_WEST` (`:3425,3453,3613,3550`)

### Manufacturing (`TR_MFG_KR_ISU_REC.cs`) — col map: 17=NWT, 22=touch, 23=FINE, 24=touch2, 25=WEST%, 26=fine-w-wastage, 31=lbr-rate, 32=lbr-amt, 48/50=lbr%
- **Basic fine** (`:5948`): `FINE = NWT × touch / 100`
- **Fine incl wastage** (`:5933/5970/5992`): `(NWT + FINE) × (touch + west) / 100`  ← note: adds **FINE**, not addlWt
- **Labour rate from %** (`:6014`): `lbrRate = round(col48 × col50 / 100, MsLbrRof)`
- **Labour amount** (`:6043`): `lbrAmt = round((NWT + FINE) × lbrRate / 1000, 0)`
- **Reverse labour-rate** (`:6094`): `lbrRate = round(lbrAmt / (NWT+FINE) / 1000, MsLbrRof)`
- **Process reconciliation (received metal)** (`:7925/7929/8175`):
  `RecWt = IR_WT + RTN_CHOL + RTN_GHIS + ITM_GHAT + ITM_LOSS`  (issued − received per `ITM_LOT` × `IR_TYPE`)
- Process chain via `LastPorcess` / `CurProcess` over `MFG_ISU_REC` grouped by `LOT_NO, IT_CODE` (`:4298,6290`)

### MFG Ghat-Receive (`TR_MFG_GHAT_REC.cs`) — "MFG GHAT REC" / "MFG MINO ISU" modes (`:2330`); col map: 12=NWT, 13=touch, 14=FINE, 37=touch2, 38=WEST%, 39=fine-w-wastage, 17=lbr-rate, 18=lbr-amt, 43/45=lbr%
- **Basic fine** (`:3030`): `FINE = NWT × touch / 100`
- **Fine incl wastage** (`:3000/3056/3078`): `(NWT + FINE) × (touch + west) / 100`
- **Labour rate from %** (`:3151`): `lbrRate = round(col43 × col45 / 100, MsLbrRof)`
- **Labour amount** (`:3176`): `lbrAmt = round(NWT × lbrRate, 0)` ; (`:3180`) alt `round((NWT+FINE) × lbrRate/1000, 0)`
- **Reverse labour-rate** (`:3132`): `lbrRate = round(lbrAmt / (NWT+FINE) / 1000, MsLbrRof)`

### Melting (`TR_MLT_PRO.cs`) — web `melting.ts` matches the arithmetic
- `partyFine = NWT × touch / 100` ; `netFine = recoveredFine ?? partyFine × (1 − loss%/100)` ; `lossWt = partyFine − netFine`
- BUT desktop also DELETEs/writes `MFG_DETL, MFG_ISU_REC, MAIN_STOCK` (melt consumes a MFG lot + posts stock); web writes **only** `MLT_DATA/MLT_DETL`.

### `MAIN_STOCK` row shape (the stock ledger) — `Ac_Stock.cs:15` (`Itm_Opbl_Stk`), `:28` (`Tag_Opbl_Stk`), `:42` (`Item_Lot_Stk`), `:54` (`Tag_Can_Stk`), `:68` (`Apr_Isu_Stk`), `Mfg_Isu_Rec_Stk`
Full desktop column list (one dedicated routine per txn type):
```
CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,STK_DATE,VCH_TYPE,BOOK_NAME,AC_CODE,
IT_CODE,TAG_NO,VCH_SRNO,TBL_CODE,TR_TYPE,ITM_SIGN,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,
ITM_FINE,ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,ITM_MRP,NET_AMT,KR_NWT,KR_TOUCH,KR_WEST,KR_FINE,
KR_LBR_AMT,KR_OTH_AMT,KR_COST,EMP_CODE,ENT_USER,...
```
**Web writes only**: `CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,IT_CODE,TAG_NO,TR_TYPE,ITM_SIGN,ITM_QTY,ITM_PCS` (+`AC_CODE` for karigar). **All weight/touch/fine/rate/value columns are left empty** ⇒ desktop stock-fine / stock-value / movement reports cannot be reproduced from web `MAIN_STOCK`.

---

## 2. Per-form deep dive (desktop → web)

### 2.1 `TR_TAG_OPBL` — Tag Opening (619 KB)
- **Desktop writes**: `BAR_DATA` (tag batch header), `BAR_DETL` (per-tag: PCS/GWT/NWT/TOUCH/FINE/RATE/MRP + GR/PR/style/HUID), `BAR_IDTL` (item sub-detail), `MAIN_STOCK` (+ via `Tag_Opbl_Stk`), `TAG_SET`, `TAG_PRINT_DATA`, `SRNO_MAST`; reverses also touch `LOT_DETL, DM_DATA, TAG_IMAGE_DATA, TEMP_BOOK_DATA, MFG_DETL, SL_ORD_DETL`. (catalog: TR_TAG_OPBL.md; INSERT BAR_IDTL@L14269, BAR_DETL@L14410)
- **Special**: links to MFG (`MFG_DETL` update L11294) and sales-orders (`SL_ORD_DETL`), diamond detail (`DM_DATA`), lot (`LOT_DETL`), tag image, label printing, voucher renumber.
- **Web** (`stock.ts tagOpening` + `stock/page.tsx`): writes `BAR_DATA/BAR_DETL/BAR_IDTL/MAIN_STOCK` only. `fineOf = netWt×touch/100`. Reversible by voucher key.
- **GAP**: no `TAG_SET`, no `TAG_PRINT_DATA`, no `SRNO_MAST`, no `LOT_DETL`, no `DM_DATA`, no `TAG_IMAGE_DATA`; no MFG/sales-order linkage; `MAIN_STOCK` row is column-sparse; no HUID/style/GR-PR attributes on the form (only tagNo/itCode/pcs/gwt/nwt/touch/rate/mrp).

### 2.2 `TR_TAG_SPLIT` — Tag Split (530 KB) — **MISSING ENTIRELY**
- **Desktop**: splits one stock tag into N child tags. Deletes the parent's `BAR_DATA/DETL/IDTL` + its `AC_DATA / ROJ_MEL_DATA / BILL_OS_DATA / LBR_DATA / LBR_ISU_DETL / LBR_REC_DETL / MAIN_STOCK / DM_DATA`, re-inserts child `TAG_SET / TAG_PRINT_DATA`, `RATE_CUT_ISU_REC` (rate-cut/labour re-allocation), `USER_DATA`. (catalog: TR_TAG_SPLIT.md)
- **Web**: **no route, no page, no service.**
- **GAP**: 100%. High value — splitting/relabelling stock tags is a daily counter operation.

### 2.3 `TR_TAG_WT_DIFF` — Tag Weight Difference (407 KB) — **MISSING ENTIRELY**
- **Desktop**: corrects a tag's weight; `UPDATE BAR_DETL` (new wt) + `UPDATE LBR_ISU_DETL`; re-posts `RATE_CUT_ISU_REC`, and reverses `AC_DATA / ROJ_MEL_DATA / TAX_DATA / MAIN_STOCK / LBR_*`. Grid cols `cDiffGwt=14, cDiffNwt=15` (`:369,371`). (catalog: TR_TAG_WT_DIFF.md)
- **Web**: **no route, no page, no service.**
- **GAP**: 100%. Inventory weight reconciliation + the financial re-post is absent.

### 2.4 `TR_MFG_ISU_REC` / `TR_MFG_KR_ISU_REC` — MFG Issue/Receive (300 KB / 477 KB) — **MISSING ENTIRELY**
- **Desktop**: the core manufacturing engine. `MFG_DATA` (header), `MFG_DETL` (lines), `MFG_IDTL` (item sub-detail), `MFG_ISU_REC` (process movement ledger), `MAIN_STOCK`, `AC_DATA` (labour), `REMARK_DATA`, `TEMP_BOOK_DATA`; `TR_MFG_KR_ISU_REC` adds `MFG_ASMBL_DETL` (assembly) + `SL_ORD_DETL` link. Process chain (`IR_TYPE` Last/Cur), lot tracking, ghat/loss/chol/ghis (`:7925`). Stock via `Ac_Stock.Mfg_Isu_Rec_Stk` (`:9848`).
- **Web**: pages `mfg-issue`/`mfg-receive` render `<KarigarForm label="Manufacturing"/>` → POST `/manufacturing/karigar` → writes `KR_*`. **No `MFG_*` ever written.**
- **GAP**: ~95%. Missing: MFG tables, process stages, lot, ghat/loss/chol/ghis, assembly, diamond wt, per-process labour, order linkage.

### 2.5 `TR_MFG_ITEM` — MFG by Item (363 KB) — **MISSING**
- **Desktop**: item-wise MFG variant; same `MFG_*` + `ITM_LOT_DETL / LOT_DETL` (lot consume), `AC_DATA`, `MAIN_STOCK`, `SL_ORD_DETL/IDTL`. Web: none.

### 2.6 `TR_MFG_ORD_ISU` / `TR_MFG_ORD_REC` — MFG Order Issue/Receive (283 KB / 344 KB) — **MISSING**
- **Desktop**: order-driven MFG against **approval/consignment** (`APR_DATA/APR_DETL/APR_IDTL`) + `SL_ORD_DETL`. ORD_ISU writes `MFG_DETL/MFG_ISU_REC/MAIN_STOCK` + updates `SL_ORD_DETL`; ORD_REC closes back to `APR_DETL` + `AC_DATA` labour. Web: none (no APR_*, no order-MFG).

### 2.7 `TR_MFG_WITH_LOT` — MFG with Lot (302 KB) — **MISSING**
- **Desktop**: lot-centric MFG; `MFG_DATA/DETL/IDTL/MFG_ISU_REC + MAIN_STOCK + AC_DATA`. Web: none.

### 2.8 `TR_MFG_GHAT_REC` — Ghat/Mino Receive (235 KB) — **MISSING**
- **Desktop**: receives metal-reduction (ghat) / mino; updates `APR_DETL + MFG_DETL`, writes `MFG_DATA/MFG_ISU_REC + AC_DATA + MAIN_STOCK`. Formulas §1. Web: none.

### 2.9 `TR_KR_ISU` — Karigar Issue/Receive (280 KB) — **PARTIAL (~40%)**
- **Desktop writes**: `KR_DATA/KR_DETL/KR_IDTL`, `AC_DATA`, `ROJ_MEL_DATA` (day register), `TAX_DATA`, `MAIN_STOCK`, `DM_DATA/DM_KR_DATA` (diamond), `MFG_ISU_REC` link, `REMARK_DATA`, `BAR_DETL/BAR_IDTL` (when receiving as tagged stock). Formulas §1.
- **Web** (`karigar.ts`): `KR_DATA + KR_DETL + MAIN_STOCK + AC_DATA(labour only)`. Fine `nwt×touch/100`; receive `nwt×(touch+west)/100`; balance = Σissued−Σreceived.
- **GAPS**: no `KR_IDTL`, no `ROJ_MEL_DATA`, no `TAX_DATA`, no `DM_DATA/DM_KR_DATA`, no `BAR_*` on tagged receipt, no `REMARK_DATA`; `MAIN_STOCK` column-sparse (no NWT/TOUCH/FINE/KR_* cols); single labour input vs per-line labour-rate/% computation; ignores additional-weight col & `ITM_WEST_PRC` master defaults; `INOUT_TYPE` char convention flagged unverified in code comments.

### 2.10 `TR_MLT_PRO` — Melting (191 KB) — **PARTIAL (~50%)**
- **Desktop**: `MLT_DATA/MLT_DETL` + consumes `MFG_DETL/MFG_ISU_REC` + `MAIN_STOCK` + updates `SL_DATA`.
- **Web**: `MLT_DATA/MLT_DETL` only; arithmetic matches. **GAP**: no `MAIN_STOCK` movement, no MFG-lot consumption, no `SL_DATA` link.

### 2.11 `MS_UPDATE.cs` — stock-movement & reversal engine (1.1 MB)
- Central updater of `MAIN_STOCK / BAR_DATA / BAR_DETL / BAR_IDTL` and all detail tables, plus the cross-table reversal cascade used on delete (`MAIN_STOCK, LOT_DETL, DM_DATA, DM_KR_DATA, AC_DATA, ROJ_MEL_DATA, TAX_DATA, MFG_ISU_REC, LBR_*` …). The web reproduces a much smaller `reverseVoucherTx(tables[])` per engine; reversal-table coverage must match the desktop cascade per voucher type (e.g. karigar reverse should also clear `ROJ_MEL_DATA/TAX_DATA/DM_*`).

---

## 3. GAP TABLE (feature | desktop | web status | impact)

| # | Feature | Desktop behaviour (evidence) | Web status | Impact |
|---|---|---|---|---|
| 1 | **Manufacturing engine (MFG_*)** | `MFG_DATA/DETL/IDTL/MFG_ISU_REC`, process stages, lot, assembly (`TR_MFG_KR_ISU_REC.cs:7925,8354,9848`) | **Missing** — pages alias karigar→`KR_*` | **Critical**. No real MFG; metal-in-process untracked |
| 2 | **Process / lot tracking** | `IR_TYPE` Last/Cur process, `ITM_LOT/LOT_NO` grouping (`:4298,6290`) | Missing | **Critical**. Cannot track WIP across processes |
| 3 | **Ghat/Loss/Chol/Ghis reconcile** | `RecWt=IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS` (`:7925`) | Missing | **High**. Metal-loss accounting absent |
| 4 | **Tag Split** | `TR_TAG_SPLIT` full BAR_* re-issue + RATE_CUT_ISU_REC | **Missing** (no route/page) | **High**. Daily counter op |
| 5 | **Tag Weight-Diff** | `TR_TAG_WT_DIFF` UPDATE BAR_DETL + re-post AC/TAX/ROJ/stock | **Missing** | **High**. Inventory wt correction |
| 6 | **MAIN_STOCK column fidelity** | ~40 cols incl GWT/NWT/TOUCH/WEST/FINE/RATE/AMT/LBR_*/KR_* (`Ac_Stock.cs:15`) | 15 cols, weights/fine NULL | **High**. Stock-fine/value/movement reports unbuildable |
| 7 | **MFG order flow (APR_*)** | `TR_MFG_ORD_ISU/REC` write `APR_DATA/DETL/IDTL`+`SL_ORD_DETL` | Missing | **High**. Order-to-MFG & consignment broken |
| 8 | **Karigar satellites** | `KR_IDTL, ROJ_MEL_DATA, TAX_DATA, DM_DATA/DM_KR_DATA, REMARK_DATA` | Missing (only KR_DATA/DETL) | **Med-High**. Day-register/tax/diamond gaps |
| 9 | **Per-line labour rate / %** | `lbrRate=lbr%×.../100`, `lbrAmt=(NWT+FINE)×rate/1000` (`TR_MFG_KR_ISU_REC.cs:6014,6043`) | Single labourAmt input | **Med**. Labour costing imprecise |
| 10 | **Diamond weight in metal flow** | `DM_WT` separate in `MFG_ISU_REC`; `DM_DATA/DM_KR_DATA` | Missing | **Med**. Studded-jewellery wrong |
| 11 | **Tag attributes (HUID/style/GR-PR)** | `BAR_DETL` rich cols + `TAG_SET/TAG_PRINT_DATA/SRNO_MAST` | tagNo/itCode/pcs/wt/touch/rate/mrp only | **Med**. Label/print/HUID gaps |
| 12 | **Melting stock + MFG consume** | `TR_MLT_PRO` writes `MAIN_STOCK + MFG_DETL/ISU_REC + SL_DATA` | MLT_DATA/DETL only | **Med**. Melt not reflected in stock |
| 13 | **LOT_DETL / ITM_LOT_DETL** | lot create/consume in tag-open, MFG-item | Missing | **Med**. Lot inventory absent |
| 14 | **Reversal cascade parity** | `MS_UPDATE` clears full satellite set per type | per-engine subset | **Med**. Orphan rows on delete |
| 15 | **REMARK_DATA / TEMP_BOOK_DATA / TAG_PRINT_DATA** | written by every MFG/tag form | Missing | **Low-Med**. Notes/print/temp-book |

---

## 4. Prioritized remediation (top 10)

1. **Build a real Manufacturing module** (`manufacturing/mfg.ts`) writing `MFG_DATA/MFG_DETL/MFG_IDTL/MFG_ISU_REC` — stop aliasing karigar from `mfg-*`/`jobwork-*` pages.
2. **Model process stages + lots** (`IR_TYPE`, `ITM_LOT/LOT_NO`) with per-process issue/receive reconciliation.
3. **Implement ghat/loss/chol/ghis** received-weight formula (`IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS`) + the `(NWT+FINE)×(touch+west)/100` wastage variant.
4. **Enrich `MAIN_STOCK` writes** to the full ~40-column shape (GWT/NWT/TOUCH/WEST/FINE/RATE/AMT/LBR_*/KR_*/STK_DATE/ISR_NO/VCH_SRNO/EMP_CODE) across every posting engine.
5. **Build Tag Split** (`TR_TAG_SPLIT`): parent BAR_* delete → N child BAR_*/TAG_SET + RATE_CUT_ISU_REC.
6. **Build Tag Weight-Diff** (`TR_TAG_WT_DIFF`): BAR_DETL update + AC/TAX/ROJ/MAIN_STOCK re-post.
7. **Build MFG order flow** (`TR_MFG_ORD_ISU/REC`): `APR_DATA/DETL/IDTL` + `SL_ORD_DETL` linkage (job-work/consignment).
8. **Complete karigar satellites**: `KR_IDTL, ROJ_MEL_DATA, TAX_DATA, DM_DATA/DM_KR_DATA, REMARK_DATA` + per-line labour-rate/% + master WEST defaults.
9. **Wire melting into stock**: `MAIN_STOCK` movement + `MFG_DETL/MFG_ISU_REC` consume + `SL_DATA` update.
10. **Align reversal cascades** with `MS_UPDATE` per voucher type, and add `LOT_DETL/ITM_LOT_DETL` + tag attributes (HUID/style/GR-PR/TAG_PRINT_DATA/SRNO_MAST).

### Evidence index
- Web: `stock.ts` (tagOpening/onHand/listTags/physicalReconcile), `karigar.ts` (issue/receive/balance), `melting.ts` (meltLine); pages `tag-opening|stock|melting|karigar-*|mfg-*|jobwork-*`. `mfg-*`/`jobwork-*` = `KarigarForm` aliases.
- Desktop: `TR_KR_ISU.cs:3579,3933,3940,4012,4031`; `TR_MFG_KR_ISU_REC.cs:5933,5948,6014,6043,6094,7925,8354,9848`; `TR_MFG_GHAT_REC.cs:2330,3000,3030,3132,3151,3176,3180`; `Ac_Stock.cs:11,15,22,28,36,48,60,68`; catalogs `TR_TAG_OPBL/TR_TAG_SPLIT/TR_TAG_WT_DIFF/TR_MFG_*.md`, `xdb-matrix.md` (MFG_* tables exist, 0 rows in sample).
