# AUDIT_B — Purchase + Inventory/Tags parity (INDEPENDENT)

_Generated 2026-06-30. cwd `/Users/yakshitsavaliya/Desktop/imodule-extracted`._
_Rule: cite real `file:line` BOTH sides; unconfirmed → CANNOT-VERIFY. Desktop = `unified/src/csharp_nextdm/DataCareNext/*.cs`; Web API = `web/apps/api/src/modules/*`; Web UI = `web/apps/web/app/(app)/txn/*/page.tsx`._

## Architecture (why the comparison is asymmetric)

- **Desktop** `TR_PURC.cs` is a *universal* voucher form. The save handler writes the **document** tables via ADO.NET DataAdapters bound to runtime table-name variables — `TblData`/`TblDetl` set to `PR_DATA`/`PR_DETL` (`TR_PURC.cs:11481-11482`), `FormBookSname`/`FormBookInOut`/`FormMainBook` set from book config (`TR_PURC.cs:11430-11432`). It then calls shared **posting engines** for the derived tables: `Ac_Ledr.Purc_Ledr` → `AC_DATA` (`TR_PURC.cs:13234`), `Ac_Tax.Purc_GST` → `TAX_DATA` (`:13261`), `Ac_Stock.Purc_Stk`+`Dm_Purc_Detl` → `MAIN_STOCK` (`:13280-13281`), `Ac_Rojmel.Purc_Rojmel` → `ROJ_MEL_DATA`, `Ac_Stock.PrKr_Lot` → `LOT_DETL`.
- **Web** purchase/stock modules build a small, explicit row-set per voucher and post through `postVoucherTx` (`purchase.ts`, `purchaseReturn.ts`, `stock.ts`, `tagOps.ts`, `tagSplit.ts`). They are correct double-entry but populate a **subset** of columns/satellite tables.

## Summary verdict table

| # | Area | Verdict | One-line basis |
|---|------|---------|----------------|
| 1 | Purchase ledger+tax+stock footprint vs TR_PURC | **PARTIAL** | Core supplier/purchase/GST/round captured; desktop also posts per-group purchase a/c, cash/cheque/card/kasar/TCS/TDS/HM **and metal fine-weight ledger** — web omits all |
| 2 | Purchase header/line weight+fine+amount math | **PARTIAL** | `fine = net×touch/100`, `metal=fine×rate`, `net=metal+labour` match; web omits wastage(`ITM_WEST_PRC`)/ghat(`ITM_GHT`)/silver-fine/`FINE_CUT_*`. Exact desktop grid arithmetic = CANNOT-VERIFY |
| 3 | INOUT_TYPE/sign on BILL_OS_DATA + MAIN_STOCK | **PARTIAL** | MAIN_STOCK `TR_TYPE='P'/ITM_SIGN='+'` = PARITY; BILL_OS_DATA `INOUT_TYPE='I'` = **GAP** (desktop never writes BILL_OS_DATA on purchase) |
| 4 | Tag opening (TR_TAG_OPBL) footprint+weights | **PARTIAL** | Web writes BAR_DATA/BAR_DETL/BAR_IDTL/MAIN_STOCK `TAGOP/P/+`; reduced columns; BOOK_NAME `TAG OPENING` vs desktop `TAG OPBL`; desktop's 2nd/3rd (TAG GEN + aggregate) rows not replicated |
| 5 | Tag cancel (TR_TAG_CAN) reversal | **PARTIAL** | Web MAIN_STOCK `TGCAN/O/-` matches removal; omits BAR_CAN_DATA/DETL/IDTL document + transfer-item re-add leg |
| 6 | Tag weight-diff (TR_TAG_WT_DIFF) rows | **PARTIAL** | Web books NET diff + STKADJ/WTDIFF value pair; desktop does full OUT+IN tag replacement (LBR_ISU_DETL/LBR_REC_DETL/BAR_DETL); different model |
| 7 | Tag split (TR_TAG_SPLIT) conservation | **PARTIAL** | Conservation logic (Σchildren=parent) + parent-OUT/children-IN = PARITY of concept; web omits LBR_ISU_DETL/LBR_REC_DETL docs, uses invented `TGSPL` |
| 8 | Item lot/opening (TR_ITM_LOT / TR_ITM_OPBL) | **GAP** | No web implementation (no endpoint, no page) for either item-lot or item (non-tag) opening |
| 9 | Physical stock (TR_PHYSTK) variance | **GAP** | Web is read-only diff against empty/web-only TAG_STOCK; desktop posts a real stock-adjust voucher (BAR_CAN_DATA/DETL + BAR_DETL + MAIN_STOCK) |
| 10 | Purchase return TAX + stock reversal | **PARTIAL** | Web ledger/tax reversal sound (TAX_SIGN '+', CGST/SGST split); MAIN_STOCK sign '-' correct but `TR_TYPE='P'` vs desktop `'O'`; satellite footprint reduced |
| 11 | DB footprint desktop-writes-vs-web-writes column diff | **PARTIAL** | Web writes ~15-20 of PR_DATA(75)/PR_DETL(113)/BAR_DETL(110)/MAIN_STOCK(54); adds web-only TAG_STOCK + BILL_OS_DATA-on-purchase |
| 12 | Frontend fields per form | **PARTIAL** | Core fields present; desktop fields absent (HD_VCH_NO, employee, wastage%, ghat, silver-fine, hallmark, cash/card/cheque, TCS/TDS, design/size/lot on tags) |

---

## Detailed findings (cited both sides)

### (1) Purchase ledger + tax + stock footprint — PARTIAL

**Web** `purchase.ts`:
- `buildPurchaseLedger` (`purchase.ts:84-96`): `Cr supplier = totals.total` / `Dr purchase(='PURCHASE') = taxable` / `Dr GST-input(='GSTINPUT') = tax` / `Dr round-off`. Defaults `purchaseAc='PURCHASE'`, `taxAc='GSTINPUT'`, `roundAc='ROUNDOFF'` (`purchase.ts:131-133`).
- `createPurchase` writes `PR_DATA`(header), `PR_DETL`(detl), `MAIN_STOCK`(tagged only), `TAX_DATA`(1 row), `BILL_OS_DATA`(1 row) via `postVoucherTx` (rows assembled `purchase.ts` createPurchase body, ~L150-220).

**Desktop** `Ac_Ledr.Purc_Ledr` (`Ac_Ledr.cs:374-479`) posts to `AC_DATA` up to ~33 leg-types:
- `'01'` Cr supplier `A.AC_CODE = TOT_AMT+DISC_AMT` (gross; discount reversed separately).
- `'08'` Dr **`D.PURC_AC` from `GROUP_MAST` per item** = `NET_AMT` (ITM_TYPE='A'); `'10'/'11'` non-A items.
- `'12'` Dr **`D.TAX_AC` from `TAX_MAST`** = `TAX_AMT`; `'13'` TCS, `'14'/'15'` TDS, `'16'` HM_AMT, `'17'` HM_TAX_AMT.
- `'18'/'19'` cheque (`CHQ_AMT`), `'20'/'21'` card, `'22'/'23'` cash, `'24'/'25'` kasar, `'26'` round-off, `'27'/'28'` discount.
- **`'29'/'30'/'31'` metal fine-weight ledger**: `SIGN='+'`, `FINE_WT = A.ITM_FINE+A.ITM_OTH_FINE` (gold) / `SILVER_FINE` (silver) — the gold/silver fine stock-ledger.

Basis for PARTIAL: web captures the money skeleton (supplier/purchase/GST/round) but (a) uses single hardcoded `PURCHASE`/`GSTINPUT` accounts vs desktop per-item-group `GROUP_MAST.PURC_AC` and `TAX_MAST.TAX_AC`; (b) has **no metal/fine-weight ledger** (`'29'-'31'`), which is core to a bullion ledger; (c) omits cash/cheque/card/kasar/TCS/TDS/HM legs; (d) folds discount into taxable rather than a separate Dr/Cr discount leg.

### (2) Header/line weight + fine + amount math — PARTIAL (with CANNOT-VERIFY sub-aspect)

**Web**: `lineFine` (`purchase.ts:51-54`): `fine = fineWt ?? round2(netWt*touch/100)`. `computeLine` (`purchase.ts:58-65`): `metal = metalAmount(fine,rate)`, `labour = labourCharge(...)`, `net = metal+labour+other`. Frontend mirrors: `fine=net*touch/100; metal=fine*rate; mk=net*making; net=metal+mk` (`purchase/page.tsx:25`). `billTotals` adds discount/tax/round (CGST=SGST=tax/2 intra; IGST inter) via `@datacare/core`.

**Desktop**: `PR_DETL` stores `ITM_TOUCH`(grid col 18), `ITM_FINE`(col 21), `ITM_WEST_PRC`(wastage, col 19), `ITM_LESS_TCH`(col 20), `ITM_GHT_PRC/ITM_GHT_WT`(ghat, cols 16/17), `SILVER_FINE`(col 23), `ITM_OTH_FINE`(col 35), `FINE_CUT_*`(cols 57-60) — written at `TR_PURC.cs:12731-12772`. `Ac_Stock.Purc_Stk` consumes `A.ITM_FINE - A.FINE_CUT_FINE` and `ITM_WEST_PRC`.

Basis: the simple touch-based fine and amount formula matches, but the web has **no wastage%, ghat, less-touch, silver-fine, other-fine, or fine-cut** inputs. The exact desktop grid event-handler arithmetic that combines touch+wastage+ghat into `ITM_FINE` was **not located to a line** → that precise formula is **CANNOT-VERIFY**; the field-level omission is confirmed.

### (3) INOUT_TYPE / sign convention on BILL_OS_DATA + MAIN_STOCK — PARTIAL

- **MAIN_STOCK = PARITY (sign).** Desktop `Ac_Stock.Purc_Stk` (`Ac_Stock.cs` Purc_Stk; 2 inserts from `PR_DETL WITH_STOCK='Y'` and `BAR_DETL`) → `TR_TYPE='P', ITM_SIGN='+'`, `VCH_TYPE=B.BOOK_SNAME`. Web `createPurchase` mainStock → `TR_TYPE:'P', ITM_SIGN:'+'`. DB confirms purchase in-movements are `…|P|+` (FGPR 48, FSPR 15, GLURD 25, …). **Divergence:** web hardcodes `VCH_TYPE:'TGPR'` which appears **0 times** in `MAIN_STOCK` (desktop uses per-book sname).
- **BILL_OS_DATA = GAP.** Desktop `TR_PURC.cs` never references `BILL_OS_DATA` (grep: 0 hits in TR_PURC; the table is written only by `TR_SALE.cs:15564`, `TR_SALE_HM.cs:11497`, `TR_SALE_LBR.cs:9340`, `TR_SALE_RTN.cs:13104`). DB `BILL_OS_DATA` rows are 100% sales (`TGSL/MIXSL/TSSL … INOUT_TYPE='O'`); **zero PURC rows**. Web `createPurchase` writes `BILL_OS_DATA` `INOUT_TYPE:'I', ENTRY_TYPE:'N'` (purchase.ts createPurchase osRow). The `'I'` inward direction is *conceptually* right (purchase books are `BOOK_INOUT='I'`, and desktop sets `PR_DETL.INOUT_TYPE = FormBookInOut` at `TR_PURC.cs:12701`), but **the target table is wrong** — desktop reserves BILL_OS_DATA for sales receivables, not purchase payables.

### (4) Tag opening (TR_TAG_OPBL) — PARTIAL

**Web** `tagOpening` (`stock.ts`): writes `BAR_DATA{OP_STK:'Y'}`, `BAR_DETL`(SR_NO,TAG_NO,IT_CODE,ITM_PCS/GWT/NWT/TOUCH/FINE/RATE/MRP), `BAR_IDTL`(VCH_TYPE'TAGOP'), `MAIN_STOCK`(VCH_TYPE`'TAGOP'`,BOOK_NAME`'TAG OPENING'`,`TR_TYPE:'P',ITM_SIGN:'+'`); `fine = fineWt ?? net*touch/100`.
**Desktop** `Ac_Stock.Tag_Opbl_Stk`: insert#1 from `BAR_DETL`(OPSTK/JDTR TAG/MFG TAG) → `VCH_TYPE='TAGOP', BOOK_NAME='TAG OPBL', TR_TYPE='P', ITM_SIGN='+'`; insert#2 TAG GEN `TR_TYPE='I'`; insert#3 aggregate `STK_IT_CODE` `TR_TYPE='O', ITM_SIGN='-'`. DB: `TAGOP|P|+|1169`.
Basis: sign/type and BAR_* + MAIN_STOCK footprint match; web BOOK_NAME `'TAG OPENING'` ≠ desktop `'TAG OPBL'`, reduced columns, and the desktop secondary/aggregate rows are not produced.

### (5) Tag cancel (TR_TAG_CAN) — PARTIAL

**Web** `tagCancel` (`tagOps.ts`): only `MAIN_STOCK` `VCH_TYPE:'TGCAN', BOOK_NAME:'TAG CANCEL', TR_TYPE:'O', ITM_SIGN:'-'`; empty AC_DATA. `deleteTagCancel` reverses MAIN_STOCK.
**Desktop** `TR_TAG_CAN.cs`: writes `BAR_CAN_DATA`/`BAR_CAN_DETL`/`BAR_CAN_IDTL` (`:5051,:5099`), deletes+reposts `MAIN_STOCK` via `Ac_Stock.Tag_Can_Stk(:5271)` + `Dm_Tag_Cancel_Detl(:5272)`. `Tag_Can_Stk` sets `TR_TYPE = CASE WHEN ITM_SIGN='+' THEN 'I' ELSE 'O'`, `ITM_SIGN=A.ITM_SIGN` from `BAR_CAN_DETL`, plus a `TRFR_IT_CODE` re-add leg (`'I','+'`). DB: `TGCAN|O|-|2`.
Basis: removal sign matches; web omits the BAR_CAN_* cancellation document trio and the transfer-to-item re-issue leg.

### (6) Tag weight-diff (TR_TAG_WT_DIFF) — PARTIAL

**Web** `tagWeightDiff` (`tagOps.ts`): one signed `MAIN_STOCK` row of `|newNet-oldNet|` (`VCH_TYPE:'TGWD'`, `TR_TYPE:'I'/'O'`, `ITM_SIGN:'+'/'-'`, `ITM_FINE=|diff|*touch/100`) + balanced `AC_DATA` pair on `STKADJ`/`WTDIFF` (`value=diffFine*rate`).
**Desktop** `Ac_Stock.Tag_Wt_Diff_Stk`: full **OUT** from `LBR_ISU_DETL` (`'O','-'`, old whole tag) + full **IN** from `BAR_DETL` (`'I','+'`, new whole tag) + `LBR_REC_DETL` adjustment; ledger via `Ac_Ledr.Tag_Wt_Diff_Ledr`.
Basis: web's net-of-difference model is the code-documented simplification (tagOps.ts header comment) of desktop's full-replace; net stock effect equivalent for the metal but the row footprint, accounts (`STKADJ`/`WTDIFF` are web-invented), and `VCH_TYPE 'TGWD'` (0 in DB) diverge.

### (7) Tag split (TR_TAG_SPLIT) conservation — PARTIAL (concept = parity)

**Web** `splitTag` (`tagSplit.ts`): enforces `|Σchildren.netWt − parent.netWt| ≤ 0.01` (`tagSplit.ts` NET_TOLERANCE check) else throws; writes parent `MAIN_STOCK` SR_NO1 `TR_TYPE:'O',ITM_SIGN:'-'` (full wt/fine) + each child SR_NO≥2 `TR_TYPE:'I',ITM_SIGN:'+'`, `fine=net*touch/100`; empty AC_DATA. UI blocks submit until `remaining≈0` (`tag-split/page.tsx`).
**Desktop** `Ac_Stock.Tag_Split_Stk` (`Ac_Stock.cs:394`): insert#1 from `LBR_ISU_DETL` (MAIN_BOOK 'TAG SPLIT') SR_NO1 `TR_TYPE='O',ITM_SIGN='-'` (parent out); insert#2 from `LBR_REC_DETL` SR_NO2 `TR_TYPE=CASE ITM_SIGN`, `ITM_SIGN=A.ITM_SIGN` (children in).
Basis: parent-OUT/children-IN and weight conservation are faithfully reproduced (web even hard-enforces it); web omits the `LBR_ISU_DETL`/`LBR_REC_DETL` source documents and uses invented `VCH_TYPE 'TGSPL'` (0 in DB).

### (8) Item lot / item opening (TR_ITM_LOT / TR_ITM_OPBL) — GAP

**Desktop**: `TR_ITM_LOT.cs` maintains `ITM_LOT_DETL` (`:2958,:3590`) → `Ac_Stock.Item_Lot_Stk` posts `MAIN_STOCK` (`TR_TYPE='I','+'` + aggregate `'O','-'`). `TR_ITM_OPBL.cs` maintains `ITM_OPBL` (`:1286,:1414`) → `Ac_Stock.Itm_Opbl_Stk` posts `MAIN_STOCK` `VCH_TYPE='ITOBL', TR_TYPE='P', ITM_SIGN='+'` (DB: `ITOBL|P|+|72`).
**Web**: no module handles `ITM_LOT_DETL` or `ITM_OPBL`; no `txn/item-lot` or `txn/item-opbl` page exists (only `tag-opening`). Web tag-opening ≠ item (non-tag/loose & lot) opening.
Basis: feature absent on web → GAP.

### (9) Physical stock (TR_PHYSTK) variance — GAP

**Web** `physicalReconcile` (`stock.ts`): **read-only** set-diff of counted tags vs `TAG_STOCK` → `{matched,missing,extra}`. Writes nothing. UI is a textarea → counts (`physical-stock/page.tsx`).
**Desktop** `TR_PHYSTK.cs`: a stock-adjustment voucher — reads `MAIN_STOCK⋈BAR_DETL` counts (`:2582-2648`), and on save writes `BAR_CAN_DATA`/`BAR_CAN_DETL` (`:3441-3442`) and `INSERT INTO BAR_DETL(...)` (`:3583-3584`), i.e., it **posts** the physical-vs-book adjustment.
Basis: two problems — (a) web posts **no** variance adjustment; (b) web reconciles against `TAG_STOCK` which is **web-only and empty (0 rows)**, not the real `BAR_DETL` inventory (1329 rows) that the same module's `onHand`/`listTags` use → the report cannot see actual stock. GAP.

### (10) Purchase return — TAX + stock reversal — PARTIAL

**Web** `purchaseReturn.ts`: `buildPurchaseReturnLedger` (`:40-52`) = `Dr supplier total / Cr purchase taxable / Cr GST tax / Cr round`. TAX_DATA (`:90-99`): `TRAN_TYPE:'PR', TAX_SIGN:'+'`, **CGST/SGST split** (intra) or IGST (inter). MAIN_STOCK (`:103-108`): `VCH_TYPE:'PRTN', TR_TYPE:'P', ITM_SIGN:'-'`; tags leave via `issueTagTx`.
**Desktop** `Ac_Ledr.Purc_Rtn_Ledr` (`Ac_Ledr.cs:481-563`): `'01'` Dr supplier `TOT_AMT`, `'06'/'10'` Cr `PURC_AC` `NET_AMT`, `'14'` Cr `TAX_AC` `TAX_AMT`, fine legs `SIGN='-'`. `Ac_Tax.Purc_Rtn_GST` (`Ac_Tax.cs:229-249`): `TRAN_TYPE='P', TAX_SIGN='+'`, CGST/SGST split. `Ac_Stock.Purc_Rtn_Stk` (`Ac_Stock.cs:316-324`): from `PR_DETL` (PURC RETURN) `TR_TYPE='O', ITM_SIGN='-'`.
Basis: ledger sense + tax sign('+') + CGST/SGST split match well (best-aligned area); but web MAIN_STOCK uses `TR_TYPE='P'` where desktop uses `TR_TYPE='O'` (both `ITM_SIGN='-'`), `VCH_TYPE 'PRTN'` (0 in DB) vs desktop sname, and the metal fine ledger + reduced columns persist.

### (11) DB FOOTPRINT — desktop-writes vs web-writes column diff — PARTIAL

| Table | DB cols | Desktop writes (approx) | Web writes (approx) | Web-only / notable gaps |
|---|---|---|---|---|
| PR_DATA | 75 | ~50 (incl VCH_TIME, EMP_CODE, CR_DAYS, SL_BILL_*, OZ/FX/MTL rate, HM_*, TCS/TDS, RATE_UNFIX, MAIN_USER) | ~18 (key, BILL_NO, AC_*, VCH_DATE, NET/DISC/TAX/CGST/SGST/IGST/ROF/TOT_AMT, TAX_PRC) | no time/user/employee/bill-link/HM/TCS/TDS |
| PR_DETL | 113 | ~60 (`TR_PURC.cs:12701-12790`: BAG_WT, ITM_OTH_WT, ITM_LOSS_WT, ITM_GHT_*, ITM_WEST_PRC, ITM_LESS_TCH, SILVER_FINE, OTH_*, ITM_OTH_FINE, CONV_*, WITH_STOCK, FINE_CUT_*) | ~15 (key, VCH_TYPE, SR_NO, IT_CODE, TAG_NO, ITM_PCS/GWT/NWT/TOUCH/FINE/RATE/AMT, LBR_AMT, NET_AMT, TAX_PRC) | no INOUT_TYPE/ENTRY_TYPE/BOOK_NAME/HD_VCH_NO/wastage/ghat/silver/other/fine-cut/WITH_STOCK |
| BAR_DETL | 110 | ~70 (`TR_PURC.cs:12960-13050`) | ~13 (tag opening only) | KR_*, HM_ID*, APR/ORD linkage, LBR_*, DATA_* absent |
| MAIN_STOCK | 54 | ~49 (`Ac_Stock.cs` INSERT column list) | ~18-22 | KR_*, EMP_CODE, ENTRY_TIME, DESIGN_NO, ITM_SIZE, GHT_PRC, ITM_LOT, ITM_DISC absent |
| BILL_OS_DATA | — | **not written on purchase** (sales-only) | written `INOUT_TYPE='I'` | web-added row desktop never creates |
| TAG_STOCK | exists, **0 rows** | **not a desktop table** (absent from 141-table xdb set) | web presence-model table (createTag/issueTag/physicalReconcile) | web-only inventory model parallel to BAR_DETL |

### (12) Frontend fields per form — PARTIAL

| Form (page.tsx) | Web fields | Notable desktop fields missing |
|---|---|---|
| purchase | Book, Year, Loc, Supplier(+lookup), Name, Bill No, Tax%, Discount, Inter-state; lines: Item, Tag, Pcs, Gross, NetWt, Touch%, Rate, Making/g, Fine*, Amount* | HD_VCH_NO, Emp, VchDesc, CrDays, wastage%, ghat, less-touch, silver-fine, other-amt, MRP, conv-rate, cash/cheque/card, TCS/TDS, HM, multiple labour types |
| purchase-return | same as purchase + Orig Bill No | same as above |
| tag-opening | Book; lines: Tag, Item, Pcs, Gross, NetWt, Touch%, Rate, MRP | AC_CODE, design, size, west%, GHT, KR_* |
| tag-cancel | Book, Year, Loc; lines: Tag(+lookup), Item, Pcs, Gross, NetWt, Touch%, Fine | reason/transfer-item, BAR_CAN doc fields |
| tag-weight-diff | Book, Year, Loc; lines: Tag, Item, OldNet, NewNet, Touch%, Rate, Diff*, DiffFine*, Value* | full old/new tag attributes, LBR_* |
| tag-split | Book, Year, Loc; parent(Tag,Item,Pcs,Gross,Net,Touch,Fine); children(Tag,Item,Pcs,Net,Touch,Fine) | design/size/MRP per child |
| physical-stock | counted-tags textarea only | book/location filters, adjustment posting UI |
| stock | on-hand tiles; stock-in(Tag,Group,Product,Pcs,Gross,Net,MRP); in-stock list | — (utility screen, no desktop 1:1) |

\* = computed/preview field.

---

## GAPS FOUND

1. **Metal (gold/silver) fine-weight ledger is entirely absent on web.** Desktop posts `AC_DATA` fine-weight legs (`Ac_Ledr.cs` Purc_Ledr `'29'/'30'/'31'`, `SIGN '+'`, `FINE_WT`) — the metal sub-ledger that underpins a bullion business. Web's `buildPurchaseLedger` posts money only. (HIGH)
2. **BILL_OS_DATA written on web purchase but never by desktop purchase.** Web adds `INOUT_TYPE='I'` row; desktop BILL_OS_DATA is sales-receivables only (DB: 0 PURC rows). Pollutes the outstanding-bills domain. (HIGH)
3. **Item lot (TR_ITM_LOT) and item opening (TR_ITM_OPBL) not implemented on web** — no endpoint/page; desktop posts `MAIN_STOCK` `ITOBL/P/+` (72 rows) + `ITM_LOT_DETL`. (HIGH)
4. **Physical stock posts nothing and reads the wrong table.** Web `physicalReconcile` is read-only and queries empty web-only `TAG_STOCK`, not `BAR_DETL`; desktop `TR_PHYSTK` posts BAR_CAN_DATA/DETL + BAR_DETL adjustments. (HIGH)
5. **Purchase expense + GST accounts hardcoded.** Web `'PURCHASE'`/`'GSTINPUT'` vs desktop per-item-group `GROUP_MAST.PURC_AC` and `TAX_MAST.TAX_AC`. (MED)
6. **TAX_DATA shape diverges on purchase.** Web `createPurchase` writes 1 row `TRAN_TYPE='PR', TAX_TYPE='L'/'I'`; desktop+DB use `TRAN_TYPE='P'`, CGST/SGST split (`P|PURCHASE|CGST|-` & `…|SGST|-`). (Note: web `purchaseReturn` *does* split — inconsistent within web.) (MED)
7. **MAIN_STOCK VCH_TYPE values invented.** Web `'TGPR'/'PRTN'/'TGCAN'/'TGWD'/'TGSPL'` — none present in desktop `MAIN_STOCK` (desktop uses per-book `BOOK_SNAME`: FGPR/FSPR/GLURD…). Sign/`TR_TYPE` mostly correct; purchase-return `TR_TYPE` is `'P'` on web vs `'O'` desktop. (MED)
8. **Tag-cancel / weight-diff / split omit desktop document tables** (BAR_CAN_*, LBR_ISU_DETL, LBR_REC_DETL); only MAIN_STOCK (+ value ledger for wt-diff) is written. (MED)
9. **Reduced column footprint** on every shared table (see §11): wastage, ghat, KR_*, employee, time/user, lot, design/size, fine-cut, hallmark, payment splits not persisted. (MED)
10. **Wastage/ghat/silver/fine-cut not in web line math** (§2); web fine = `net×touch/100` only. (MED)

## CANNOT-VERIFY
- Exact desktop **grid arithmetic** that derives `PR_DETL.ITM_FINE` from touch+wastage(`ITM_WEST_PRC`)+ghat (the MSFlexGrid event handler) was not pinned to a line; only the stored fields and downstream consumers were confirmed.
- `ITM_OPBL` source table shows **0 rows** in this DB instance though `xdb-matrix.md` reports 72 loaded; the 72 item-opening movements are present in `MAIN_STOCK` as `ITOBL` — the empty source table vs matrix count is unreconciled here.

---

## AUDIT_B VERDICT: parity=0 partial=10 gap=2 cannot-verify=0

(12 numbered areas; items 8 and 9 = GAP; remaining 10 = PARTIAL. No area is full PARITY because every web write-path persists a reduced column/satellite footprint and omits the metal fine-weight ledger; two within-item aspects are individually CANNOT-VERIFY as noted above. Best-aligned: purchase-return ledger/tax sign and MAIN_STOCK purchase sign convention.)
