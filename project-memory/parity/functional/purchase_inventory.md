# FUNCTIONAL-PARITY DELTA — PURCHASE + INVENTORY/TAGS

_Agent `purchase_inventory` · refreshed 2026-06-30 to CURRENT code state · cwd `/Users/yakshitsavaliya/Desktop/imodule-extracted` (READ-ONLY)._
_Baseline refreshed: `project-memory/parity/audit-B-purchase-inventory.md` (+ same-day `verify-sales-purchase.md`, `verify-stock-tags.md`)._
_Desktop = `extracted_code/DataCareNext/DataCareNext/*.cs` (line numbers RE-CITED against this copy — they differ from the baseline's `unified/` copy). Web API = `web/apps/api/src/modules/*`; Web UI = `web/apps/web/app/(app)/txn/*/page.tsx`; live DB read-only (tenant `default`, CO 01)._
_Class: **OK** = full depth+breadth · **DEPTH** = form exists, misses fields/legs/columns/flow · **BREADTH** = form/flow absent on web._

---

## 0. REFRESH HEADLINE — what changed vs the 2026-06-30 baseline

The web PURCHASE + TAG-OPENING paths were materially improved since audit-B. Verified in current code:

| Baseline finding / bug | Status NOW | Evidence (web) |
|---|---|---|
| A1 purchase `BOOK_NAME` = `PURC`/blank → must be `PURCHASE` | **FIXED** | `purchase.ts:148` detl `BOOK_NAME:'PURCHASE'`; `:207` taxBase `'PURCHASE'`; mainStock `'PURCHASE'`; `postVoucherTx({bookName:'PURCHASE'})` |
| A2 purchase `TAX_DATA` single `L/I` row → must split CGST/SGST | **FIXED** | `purchase.ts:~202-206` `interState?IGST:[CGST,SGST]`, `TRAN_TYPE:'P'`, `TAX_SIGN:'-'` |
| A3 `PR_DETL` omits INOUT_TYPE/ENTRY_TYPE/BOOK_NAME/AC_CODE | **FIXED** | `purchase.ts:146-149` `INOUT_TYPE:'I',ENTRY_TYPE:'P',BOOK_NAME:'PURCHASE',AC_CODE:input.acCode` |
| A8 zero-tax TAX_DATA row written | **FIXED** | `purchase.ts` `taxRows = totals.tax===0 ? [] : …` (guarded) |
| BUG-5 `DATA_TYPE='A'` missing on ALL stock write rows | **FIXED (global)** | `posting.ts postVoucherTx` `tableHasDataType()` → stamps `DATA_TYPE:'A'` on every write row when unset; DB confirms desktop is `A` on 1856/1856 |
| BUG-1 tag-open MAIN_STOCK `BOOK_NAME` `TAG OPENING`→`TAG OPBL` | **FIXED** | `stock.ts:243` `VCH_TYPE:'TAGOP',BOOK_NAME:'TAG OPBL',TBL_CODE:'001'` |
| BUG-2/3/4 tag-open BAR_DETL/BAR_IDTL stamps blank | **FIXED** | `stock.ts:233` `VCH_TYPE:'TGEN',BOOK_NAME:'TAG GEN',INOUT_TYPE:'I',ENTRY_TYPE:'O',TBL_CODE:'001'` (detl + idtl) |
| audit-B GAP#1 metal fine-weight ledger entirely absent | **PARTIAL (new)** | `purchase.ts:188-201` now appends 1 AC_DATA leg per metal `IT_TYPE 'G'/'S', SIGN '+', FINE_WT=Σfine, DR=CR=0` |
| (new feature) period-lock | **ADDED** | `posting.ts assertPeriodOpen` / `PeriodLockValidationError` reads `CO_SET.LOCK_DATE` |

Still-open (unchanged since baseline) and newly-confirmed gaps are detailed per-form below.

| Still-open bug | Status | Evidence |
|---|---|---|
| A5 web writes `BILL_OS_DATA` on purchase; desktop never does | **OPEN** | `purchase.ts` osRow + `{table:'BILL_OS_DATA'}` write + in `deletePurchase` reverse list; DB BILL_OS_DATA = 100% sales, **0 purchase rows** |
| A6 `VCH_TYPE` hardcoded, not `BOOK_DATA.BOOK_SNAME` | **OPEN** | `purchase.ts:82,145` `'PURC'`, mainStock `'TGPR'`; `purchaseReturn.ts:46,101` `'PRTN'`; `tagOps.ts:197` `'TGWD'`; `tagSplit.ts:110` `'TGSPL'` — DB: these 4 codes = **0 rows** |
| A7 `AC_DATA.SIGN='D'/'C'` on money legs (desktop blank) | **OPEN** | `purchase.ts:85-87` `SIGN:'C'/'D'`; pervasive |
| purchase-return `BOOK_NAME='PURC'` not `'PURCHASE'` (inconsistent w/ purchase A1 fix) | **OPEN** | `purchaseReturn.ts:91,101` `BOOK_NAME:'PURC'` |
| purchase-return MAIN_STOCK `TR_TYPE='P'` (desktop `'O'`) | **OPEN** | `purchaseReturn.ts:101` vs `Ac_Stock.Purc_Rtn_Stk` `'O','-'` |
| BUG-6 `TBL_CODE='001'` only on tag-opening, not cancel/wt-diff/split | **OPEN** | `tagOps.ts:93,197` & `tagSplit.ts:110,136` set no TBL_CODE |

---

## 1. TR_PURC.cs (17255) — Purchase Invoice → web `purchase.ts` + `txn/purchase/page.tsx` — **DEPTH**

**Real usage:** HIGH. DB PR_DATA=74, PR_DETL=103; MAIN_STOCK purchase in-moves FGPR 48 / GLURD 25 / FSPR 15 / FOGPR 6 / FOSPR 5 / TGLPR 3, all `TR_TYPE='P', ITM_SIGN='+'`.

**Frontend fields (`purchase/page.tsx`)** — present: Book, Year, Location, Supplier (AC_CODE + `LookupPicker accounts`, autofills name + interState from `AC_GST_TYPE`), Supplier Name, Bill No, Tax%, Discount ₹, Inter-state (CGST+SGST / IGST); line grid: Item (lookup), Tag (lookup autofills net/gross/touch/rate), Pcs, Gross, Net Wt, Touch%, Rate, Making/g, Fine\*, Amount\* (\*computed preview).
**Missing vs desktop** (`TR_PURC.cs` grid cols / PR_DETL writes): HD_VCH_NO, Employee, VchDesc, CrDays, **wastage% `ITM_WEST_PRC`** (`:13120`), **ghat `ITM_GHT_PRC/WT`**, less-touch `ITM_LESS_TCH`, **silver-fine `SILVER_FINE`** (`:13123`), other-fine `ITM_OTH_FINE`, **fine-cut `FINE_CUT_*`** (`:13192`), MRP, conv-rate, **cash/cheque/card** (CASH_AMT/CHQ_AMT/CARD_AMT), kasar, **TCS/TDS**, **HM (hallmark) amt+tax**, multiple labour types, RATE_UNFIX.

**Buttons/actions:** web = Add line / delete line / Save Purchase (+ delete via `DELETE /purchases/:vchNo`). Desktop adds: HM, payment split, order-adjust link, rate-unfix, print — absent.

**Validation:** web `createPurchase` requires `acCode` + ≥1 line (`PurchaseValidationError`); balance asserted (`assertBalanced`); period-lock (`assertPeriodOpen`). Desktop has richer per-field validation (CANNOT-VERIFY exact set).

**Calc/flow:** `lineFine` (`purchase.ts:51`) `fine = fineWt ?? round2(netWt*touch/100)`; `computeLine` (`:58`) `metal=metalAmount(fine,rate)`, `labour=labourCharge(...)`, `net=metal+labour+other`; `billTotals` adds discount/tax(CGST=SGST=tax/2 | IGST)/round. Matches desktop's touch-based fine **only**; desktop folds wastage+ghat+less-touch+fine-cut into `ITM_FINE` (grid event handler — exact formula CANNOT-VERIFY) and `Ac_Stock.Purc_Stk` consumes `A.ITM_FINE - A.FINE_CUT_FINE` and `ITM_WEST_PRC` (`Ac_Stock.cs Purc_Stk :134`).

**DB tables written — web vs desktop:**
| Table | Web (`purchase.ts`) | Desktop |
|---|---|---|
| PR_DATA | header ~18 cols | `TR_PURC.cs` recordset ~50 cols (VCH_TIME, EMP_CODE, CR_DAYS, OZ/FX/MTL_RATE, HM_*, TCS/TDS, RATE_UNFIX, MAIN_USER) |
| PR_DETL | ~19 cols (now incl INOUT/ENTRY/BOOK_NAME/AC_CODE) | ~60 cols `:12701-12790` (BAG_WT, ITM_GHT_*, ITM_WEST_PRC, ITM_LESS_TCH, SILVER_FINE, OTH_*, FINE_CUT_*, WITH_STOCK) |
| AC_DATA | `buildPurchaseLedger:84` Cr supplier(total)/Dr `PURCHASE`(taxable)/Dr `GSTINPUT`(tax)/Dr `ROUNDOFF` + **1 metal fine leg/metal** (`:200`) | `Ac_Ledr.Purc_Ledr:374` **~33 legs**: '01' supplier, '08/10/11' per-group `GROUP_MAST.PURC_AC`, '12' `TAX_MAST.TAX_AC`, '13' TCS, '14/15' TDS, '16/17' HM, '18-25' cheque/card/cash/kasar, '26' round, '27/28' disc, **'29/30/31' fine-weight `FINE_WT=ITM_FINE+ITM_OTH_FINE`/`SILVER_FINE` SIGN '+'**, '32/33' trad-fine |
| TAX_DATA | 1-2 rows, CGST/SGST split, `TRAN_TYPE 'P'`, `TAX_SIGN '-'`, `BOOK_NAME 'PURCHASE'` ✓ | `Ac_Tax.Purc_GST:107` CGST(C.SR_NO=1,TAX/2)+SGST(SR_NO=2,TAX/2)+IGST(SR_NO=3) `TAX_TYPE=C.TAX_GROUP`, `TRAN_TYPE 'P'`, `TAX_SIGN '-'` |
| MAIN_STOCK | tagged lines only, `VCH_TYPE 'TGPR'`(0 in DB), `BOOK_NAME 'PURCHASE'`, `TR_TYPE 'P'`, `ITM_SIGN '+'` | `Ac_Stock.Purc_Stk:134` **2 inserts**: PR_DETL `WITH_STOCK='Y'` (untagged incl `-FINE_CUT_*`) **+** BAR_DETL (tagged); `VCH_TYPE=B.BOOK_SNAME` (FGPR/TGLPR…) |
| BILL_OS_DATA | **WRITES** `INOUT_TYPE 'I'` payable | **NEVER** (grep 0 hits in TR_PURC; DB 0 purchase rows) |
| ROJ_MEL_DATA | — | `Ac_Rojmel.Purc_Rojmel` (`TR_PURC.cs:13655`) |
| LOT_DETL | — | `Ac_Stock.PrKr_Lot` (`:13687`) |

**Gaps:** hardcoded `PURCHASE`/`GSTINPUT` vs per-group `GROUP_MAST.PURC_AC`/`TAX_MAST.TAX_AC`; no cash/cheque/card/kasar/TCS/TDS/HM legs; metal fine leg is 1 aggregate/metal vs desktop per-line '29-31'; tagged-only MAIN_STOCK (misses untagged fine `TAG_NO='N'`); spurious BILL_OS_DATA; `VCH_TYPE 'TGPR'`/`SIGN D/C`; thin column footprint; wastage/ghat/fine-cut not in line math.

### 1b. Purchase Return (PURC RETURN book) → web `purchaseReturn.ts` + `txn/purchase-return/page.tsx` — **DEPTH** (best-aligned)
Web `buildPurchaseReturnLedger:40` Dr supplier(total)/Cr `PURCHASE`(taxable)/Cr `GSTINPUT`/Cr `ROUNDOFF`; TAX_DATA `:91` `TRAN_TYPE 'P', TAX_SIGN '+'`, CGST/SGST split (matches `Ac_Tax.Purc_Rtn_GST:229`); MAIN_STOCK `:101` `VCH_TYPE 'PRTN'`(0 in DB), `TR_TYPE 'P'` (desktop `Ac_Stock.Purc_Rtn_Stk` = **`'O'`**), `ITM_SIGN '-'`. Tags leave via `issueTagTx`. **Gaps:** `BOOK_NAME 'PURC'` not `'PURCHASE'` (purchase A1 fix not propagated); `TR_TYPE 'P'` vs `'O'`; no metal fine leg (asymmetric with purchase); desktop `Purc_Rtn_Ledr:481` posts ~26 legs (HM/cash/card/kasar/disc/fine '25/26/27') — web posts 2-4.

---

## 2. TR_PURC_HM.cs — Hallmark Purchase → **BREADTH (no web form)**
Desktop: HM-purchase variant; `Ac_Ledr.Purc_Ledr` HM legs '16' `HM_AMT`(`00096`)/'17' `HM_TAX_AMT` (`TAX_MAST.TAX_AC`), `Ac_Tax.Purc_GST` HM rows SR 10/20/30. Web: **no `/purchase-hm` route, no module, no HM fields** anywhere (purchase page has no hallmark inputs; PR_DATA HM_* unwritten). Real usage: HM columns exist in PR_DATA. → BREADTH.

## 3. TR_OTH_PURC.cs — Other/Expense Purchase → **BREADTH (no web form)**
Desktop `TR_OTH_PURC.cs:3817 → Ac_Ledr.Oth_Purc_Ledr` (`Ac_Ledr.cs:1600`) + `Ac_Tax.Oth_Purc_GST` (`Ac_Tax.cs:205`); writes `PAY_DATA`/`PAY_DETL` under `MAIN_BOOK='OTH EXP'` with per-line CGST/SGST/IGST tax. Web: **no expense/other-purchase module** in `apps/api/src/modules` (65 files checked); closest is `inout/fineInout.ts` (metal in/out, not expense). → BREADTH.

---

## 4. TR_TAG_OPBL.cs (14664) — Tag Opening → web `stock.ts tagOpening` + `txn/tag-opening/page.tsx` — **DEPTH** (much improved)
**Real usage:** HIGH — DB `TAGOP/P/+` = 1169 rows.
**Frontend:** Book; line grid Tag, Item, Pcs, Gross, Net, Touch%, Rate, MRP. Missing: AC_CODE, design, size, wastage, GHT, KR_*.
**Calc/flow:** `fineOf = fineWt ?? net*touch/100` (`stock.ts`). 
**DB:** web writes BAR_DATA(`OP_STK='Y'`), BAR_DETL (`:233` `TGEN/TAG GEN/I/O/TBL_CODE 001` ✓), BAR_IDTL (`TGEN/TAG GEN/I/O` ✓), MAIN_STOCK (`:243` `TAGOP/TAG OPBL/P/+/TBL_CODE 001/DATA_TYPE A` ✓). Desktop `Ac_Stock.Tag_Opbl_Stk:22` writes **3 MAIN_STOCK inserts**: ① BAR_DETL→`TAGOP/TAG OPBL/P/+`, ② TAG-GEN→`BOOK_SNAME/I/+`, ③ aggregate `STK_IT_CODE`→`O/-`. **Gaps:** web omits inserts ②③ (the TAG GEN in-leg + aggregate item out-leg), and KR_*/AC_CODE/design/size columns. Stamp parity now matches (BUG-1..6 fixed for this form).

## 5. TR_TAG_CAN.cs — Tag Cancel → web `tagOps.ts tagCancel` + `txn/tag-cancel/page.tsx` — **DEPTH**
**Real usage:** LOW — DB `TGCAN/O/-` = 2 rows; BAR_CAN_DATA/DETL = **0**.
**Frontend:** Book/Year/Loc; lines Tag(lookup autofill), Item, Pcs, Gross, Net, Touch%, Fine. Missing: reason / transfer-item, BAR_CAN doc fields.
**DB:** web MAIN_STOCK `:93` `TGCAN/TAG CANCEL/O/-` (+ ISR_NO, ITM_WEST, KR_TOUCH/KR_FINE; **no TBL_CODE** — BUG-6 open). DATA_TYPE now `A` via posting. Desktop `Ac_Stock.Tag_Can_Stk:48` reads `BAR_CAN_DETL` → `TR_TYPE = CASE ITM_SIGN`, `BOOK_NAME=B.MAIN_BOOK` (TAG CANCEL/STOCK ADJUST/TAG TRFR) + 2nd insert `TRFR_IT_CODE` re-add `I/+`. Web omits BAR_CAN_DATA/DETL/IDTL document trio + transfer re-issue leg. MAIN_STOCK VCH_TYPE/BOOK_NAME/TR_TYPE/ITM_SIGN match desktop (verified). → DEPTH (doc footprint), MAIN_STOCK row = OK.

## 6. TR_TAG_SPLIT.cs — Tag Split → web `tagSplit.ts splitTag` + `txn/tag-split/page.tsx` — **DEPTH**
**Real usage:** NONE in demo (0 `TAG SPLIT` rows) → data-to-data parity impossible; concept verified vs source.
**Frontend:** Book/Year/Loc; parent (Tag autofill, Item, Pcs, Gross, Net, Touch, Fine); children grid (Tag, Item, Pcs, Net, Touch, Fine-preview); live remaining-balance + **submit blocked until `|Σchild−parent|≤0.01`** (good conservation UI). Missing: design/size/MRP per child.
**Calc/flow:** parent OUT `SR_NO 1 O/-`, children IN `SR_NO≥2 I/+`, `fine=net*touch/100`, hard NET_TOLERANCE check. Mirrors desktop conservation. **DB:** web MAIN_STOCK only (`:110/:136` `TGSPL/TAG SPLIT`, no TBL_CODE). Desktop `TR_TAG_SPLIT.cs:10686/10692` → `Ac_Ledr.Tag_Split_Ledr` (`Ac_Ledr.cs:1951`) + `Ac_Stock.Tag_Split_Stk` (from `LBR_ISU_DETL` parent + `LBR_REC_DETL` children) + `Ac_Rojmel.Tag_Split_Rojmel`. Web omits the LBR_ISU/REC source docs + AC_DATA fine ledger + rojmel; `VCH_TYPE 'TGSPL'`=0 in DB.

## 7. TR_TAG_WT_DIFF.cs — Tag Weight Change → web `tagOps.ts tagWeightDiff` + `txn/tag-weight-diff/page.tsx` — **DEPTH** (deliberately simplified model)
**Real usage:** desktop books `TGWTC` in BAR_DETL (+ AC_DATA fine ledger IT_TYPE 'G'); **no MAIN_STOCK movement**.
**Frontend:** Book/Year/Loc; lines Tag(autofill old-net/touch/rate), Item, OldNet, NewNet, Touch%, Rate, Diff\*, DiffFine\*, Value\*.
**Calc/flow:** web books NET diff `|new−old|` as ONE signed MAIN_STOCK row (`:197` `TGWD`, `I/+`|`O/-`, `ITM_FINE=|diff|*touch/100`) + balanced AC_DATA pair on `STKADJ`/`WTDIFF` (`:220-221`, `value=diffFine*rate`). Desktop `Ac_Stock.Tag_Wt_Diff_Stk` does **full OUT** (`LBR_ISU_DETL`,`O/-`) + **full IN** (`BAR_DETL`,`I/+`) + `LBR_REC_DETL` adjust, ledger via `Ac_Ledr.Tag_Wt_Diff_Ledr`. Net metal effect equivalent; row footprint, target table (MAIN_STOCK vs BAR_DETL/IDTL), accounts (`STKADJ`/`WTDIFF` are web-invented), `VCH_TYPE 'TGWD'`(0 in DB) and TBL_CODE diverge. → DEPTH (structural, documented).

---

## 8. TR_ITM_OPBL.cs — Item (non-tag) Opening → **BREADTH (no web form)**
Desktop `TR_ITM_OPBL.cs:1455 → Ac_Stock.Itm_Opbl_Stk` (`Ac_Stock.cs:11`): maintains `ITM_OPBL`, posts MAIN_STOCK `VCH_TYPE 'ITOBL'/BOOK_NAME 'ITM OPBL'/P/+`. Real usage: DB `ITOBL/P/+` = **72 rows** (source `ITM_OPBL` table now 0 — opening already posted). Web: **no item-opening module/route/page** (`tag-opening` ≠ loose/item opening). → BREADTH.

## 9. TR_ITM_LOT.cs — Item Lot → **BREADTH (no web form)**
Desktop `TR_ITM_LOT.cs:3893 → Ac_Stock.Item_Lot_Stk` (`Ac_Stock.cs:36`): maintains `ITM_LOT_DETL`, posts MAIN_STOCK `I/+` (BOOK_NAME 'ITM LOT') + aggregate `O/-`. Real usage: `ITM_LOT_DETL` = **0** in demo. Web: **no item-lot module/route/page**. → BREADTH.

## 10. TR_PHYSTK.cs — Physical Stock → web `stock.ts physicalReconcile` + `txn/physical-stock/page.tsx` — **BREADTH (posting flow absent)**
**Frontend:** textarea of counted tag numbers → tiles (book/counted/matched/missing/extra) + missing/extra lists. **Read-only.**
**Two problems (unchanged):** (a) web posts **no** variance voucher; desktop `TR_PHYSTK.cs` posts a stock-adjustment to `BAR_CAN_DATA`/`BAR_CAN_DETL` + `BAR_DETL` (config `Mfg_Module.cs:1005` `BOOK_TBL_NAME='BAR_CAN_DATA'` for `MAIN_BOOK IN ('PHY STOCK','TAG CANCEL','STOCK ADJUST',…)`). (b) web `physicalReconcile` reconciles against **`TAG_STOCK`** (web-only, 0 rows) not the real `BAR_DETL` (1329) that the same module's `onHand`/`listTags` use → the report cannot see actual stock. → BREADTH (the adjustment voucher does not exist; only a non-functional read screen).

## 11. TR_SL_ORD_ADJ.cs — Sales Order Adjust / Order Cancel → **BREADTH (no web form)**
Desktop `TR_SL_ORD_ADJ.cs` (Form `:28`) maintains `SL_ORD_ADJ` (schema `MS_UPDATE.cs:3526`; `MAIN_BOOK='ORDER CANCEL'`, `BOOK_TBL_NAME='SL_ORD_ADJ'`), tracks order vs adjustment (`ORD_SIGN '+'/'-'`, `ORD_AMT`) consumed by sales (`TR_SALE.cs:14735`) + reports (`RP_ORDER.cs`). Web has `salesOrder.ts` (create/list orders) but **no order-adjust/cancel endpoint or `SL_ORD_ADJ` writer**. → BREADTH.

---

## 12. Shared engine parity (cited both sides)
- **Ledger** `Ac_Ledr.Purc_Ledr` (`Ac_Ledr.cs:374`) / `Purc_Rtn_Ledr` (`:481`): full multi-leg incl per-group `PURC_AC`, payment splits, TCS/TDS/HM, and **metal fine-weight sub-ledger '29/30/31'** → web `buildPurchaseLedger` (`purchase.ts:84`) reproduces money skeleton + **1 aggregate metal leg/metal** (`:200`) but omits per-group AC + payment/TCS/TDS/HM legs. PARTIAL.
- **Tax** `Ac_Tax.Purc_GST` (`Ac_Tax.cs:107`) / `Purc_Rtn_GST` (`:229`): CGST/SGST(TAX/2)+IGST split, `TRAN_TYPE 'P'`, `TAX_SIGN '-'`(purc)/`'+'`(rtn), `TAX_TYPE=C.TAX_GROUP` → web matches structure (`purchase.ts:202`, `purchaseReturn.ts:91`); minor: web uses literal `'CGST'/'SGST'`, SR ordering CGST-first.
- **Stock** `Ac_Stock.Purc_Stk` (`Ac_Stock.cs:134`): untagged(PR_DETL `WITH_STOCK='Y'`, `−FINE_CUT_*`) + tagged(BAR_DETL), `VCH_TYPE=BOOK_SNAME` → web writes tagged-only, `VCH_TYPE 'TGPR'`. PARTIAL.

## 13. DB footprint — desktop-writes vs web-writes
| Table | DB cols | Desktop writes | Web writes | Notable web gaps |
|---|---|---|---|---|
| PR_DATA | 75 | ~50 | ~18 | time/user/emp/HM/TCS/TDS/rates/RATE_UNFIX |
| PR_DETL | 113 | ~60 | ~19 (INOUT/ENTRY/BOOK_NAME/AC_CODE now ✓) | wastage/ghat/silver/other/fine-cut/WITH_STOCK/MRP |
| AC_DATA | — | ~33 legs (+fine sub-ledger) | 2-4 money + 1 metal leg/metal | per-group AC, payments, TCS/TDS/HM, mirror rows; SIGN D/C vs blank |
| TAX_DATA | — | CGST/SGST/IGST split | split ✓ (`TRAN_TYPE 'P'`,`TAX_SIGN '-'`) | TAX_CODE/R_CHARG/ISR_NO; TAX_TYPE literal |
| MAIN_STOCK | 54 | ~49, both tagged+untagged, `BOOK_SNAME` | ~20, tagged-only, `'TGPR'`(0 in DB), DATA_TYPE A ✓ | untagged fine, KR_*, EMP, DESIGN/SIZE, GHT_PRC, ITM_LOT |
| BILL_OS_DATA | — | **not on purchase** | writes `'I'` payable | web-only spurious row (remove) |
| BAR_DATA/DETL/IDTL | — | tag-opening ✓ (stamps now match) | tag-opening only | KR_*, ISR_NO, OLD_SRNO, USER_DELETE |
| BAR_CAN_* | — | tag-cancel/phystk doc | **none** | whole cancel/adjust document |
| ITM_OPBL / ITM_LOT_DETL / PAY_DETL / SL_ORD_ADJ | — | item-opbl / item-lot / oth-purc / order-adjust | **none** | whole forms (breadth) |

---

## SUMMARY (counts + top-10 gaps)
Scope = 11 owned desktop forms (+ purchase-return sub-flow). Classification at form level:
- **OK (full depth+breadth): 0.** Every implemented web path still persists a reduced column/satellite footprint.
- **DEPTH (exists, partial): 5** — TR_PURC (+purchase-return), TR_TAG_OPBL, TR_TAG_CAN, TR_TAG_SPLIT, TR_TAG_WT_DIFF.
- **BREADTH (absent): 6** — TR_PURC_HM, TR_OTH_PURC, TR_ITM_OPBL, TR_ITM_LOT, TR_PHYSTK (posting), TR_SL_ORD_ADJ.
- **Refresh win:** 9 baseline bugs FIXED (A1/A2/A3/A8 + BUG-1..6 + DATA_TYPE global); metal fine-ledger now PARTIAL; period-lock ADDED.

TOP 10 GAPS (priority):
1. **Item-opening (TR_ITM_OPBL) + item-lot (TR_ITM_LOT) not implemented** — no module/route/page; desktop posts `ITOBL` (72 rows)/`ITM LOT` MAIN_STOCK. (HIGH, BREADTH)
2. **Physical-stock posts nothing & reads wrong table** — read-only vs empty `TAG_STOCK`; desktop posts BAR_CAN_*/BAR_DETL adjustment. (HIGH, BREADTH)
3. **BILL_OS_DATA still written on purchase** — desktop never does (DB 0 purchase rows); pollutes payables. (HIGH, A5 open)
4. **TR_PURC_HM + TR_OTH_PURC + TR_SL_ORD_ADJ absent** — hallmark purchase, expense purchase (PAY_DETL), order-adjust (SL_ORD_ADJ). (HIGH, BREADTH)
5. **Purchase AC_DATA money legs incomplete** — hardcoded `PURCHASE`/`GSTINPUT` vs per-group `GROUP_MAST.PURC_AC`/`TAX_MAST.TAX_AC`; no cash/cheque/card/kasar/TCS/TDS/HM legs. (MED)
6. **MAIN_STOCK VCH_TYPE invented** `TGPR/PRTN/TGWD/TGSPL` = 0 rows in DB; must be `BOOK_DATA.BOOK_SNAME`. (MED, A6 open)
7. **Tagged-only MAIN_STOCK on purchase** — desktop also posts untagged fine (`TAG_NO='N'`, PR_DETL `WITH_STOCK='Y'`). (MED)
8. **Line math/columns miss wastage/ghat/less-touch/silver/fine-cut** — web fine = `net×touch/100` only; desktop `ITM_FINE−FINE_CUT_FINE`, `ITM_WEST_PRC`. (MED)
9. **Tag cancel/split/wt-diff omit desktop docs** (BAR_CAN_*, LBR_ISU_DETL, LBR_REC_DETL) + AC_DATA fine ledger; + TBL_CODE missing (BUG-6). (MED)
10. **Purchase-return inconsistencies** — `BOOK_NAME 'PURC'` (purchase fixed to `'PURCHASE'`), MAIN_STOCK `TR_TYPE 'P'` vs desktop `'O'`, no metal fine leg. (LOW-MED)

CANNOT-VERIFY: exact desktop grid handler deriving `PR_DETL.ITM_FINE` from touch+wastage+ghat (stored fields + downstream consumers confirmed, the in-grid formula not pinned to a line).
