# AUDIT A — Independent Parity Audit: Shared Posting Engine + Sales

**Scope:** Desktop (decompiled C# WinForms `DataCareNext`) vs Web (Fastify/Prisma `apps/api` + Next.js `apps/web`).
**cwd:** `/Users/yakshitsavaliya/Desktop/imodule-extracted`
**Method:** every claim cited `file:line` on BOTH sides; live DB schema pulled from `web-postgres-1`. Where the desktop write cannot be statically enumerated (ADO.NET recordset/`SqlDataAdapter` pattern) it is marked **CANNOT-VERIFY**, never assumed.
**Date:** 2026-06-30

---

## 0. Architecture (verified)

Desktop `TR_SALE` Save delegates to static engine helpers inside one SQL transaction `Module_Save.SlTran`
(verified call site **TR_SALE.cs:15944–15956**):
```
Ac_Ledr.Sales_Ledr(book,vch)    → AC_DATA      (Ac_Ledr.cs:61)
Ac_Rojmel.Sales_Rojmel(book,vch)→ ROJ_MEL_DATA (Ac_Rojmel.cs:29)
Ac_Tax.Sales_GST(book,vch)      → TAX_DATA     (Ac_Tax.cs:77)
Ac_Stock.Sale_Stk(book,vch)     → MAIN_STOCK   (Ac_Stock.cs:92)
Ac_Stock.Dm_Sale_Detl(book,vch) → diamond detl (Ac_Stock.cs)
```
Each engine runs **set-based `INSERT … SELECT`** from SL_DATA/SL_DETL/SL_PR_DETL/UPI_DATA joined to
BOOK_DETL/BOOK_DATA/ITEM_MAST/GROUP_MAST/TAX_MAST/AC_MAST. Header/detail rows (SL_DATA/SL_DETL/SL_IDTL/
TAX_DATA/BILL_OS_DATA) are persisted by the form via `SqlDataAdapter`+`SqlCommandBuilder.GetInsertCommand()`
(**Module_Save.cs:39 `OpenRecordSetDcSave`, :57 `ExeQuteDcSave`, :78 `MsInsertDataSave`**) — i.e. there is **no
literal `INSERT INTO SL_DATA`** to read; columns written = whatever the in-form DataTable carries.

Web `createSale` (**sales.ts:132**) does it all in one Prisma tx: `nextVoucherNoTx` → `computeLine` → `billTotals`
→ `issueTagTx` → builds explicit rows → `postVoucherTx` (**posting.ts:137**) which `assertBalanced`
(**posting.ts:42**), `enrichLedgerLine` (**posting.ts:61**), then `insertRowTx` (**posting.ts:47**) each table.

---

## 1. Behaviour-by-behaviour comparison

| # | Behaviour | Desktop evidence (file:line / SQL) | Web evidence (file:line) | Verdict | Notes |
|---|-----------|-----------------------------------|--------------------------|---------|-------|
| 1 | **Ledger double-entry** (AC_DATA rows/sign, LEDR_KEY/IT_TYPE/LD_CODE/BOOK_NAME) | `Ac_Ledr.Sales_Ledr` **Ac_Ledr.cs:61–173** posts **up to ~39 conditional legs**, LEDR_KEY=`CO+LC+YR+BOOK+VCH+'NN'(+STR(SR_NO))`, **LD_CODE = contra AC_CODE** (e.g. `B.AC_CODE`/`D.SALE_AC`), `IT_TYPE='A'` money / `C.IT_TYPE` metal, **SIGN=''/'-'/'+' (metal direction)**, `BOOK_NAME=B.MAIN_BOOK`, `VCH_TYPE=B.BOOK_SNAME`. DR/CR by which of CR_AMT/DR_AMT≠0. AC_DATA 29-col INSERT @ **Ac_Ledr.cs:63**. Income split per item GROUP (`D.SALE_AC`, leg '07' @ ~line 84). FINE_WT leg '38' posts `A.ITM_FINE` only when `RATE_UNFIX='Y'`. | `buildSaleLedger` **sales.ts:91** builds 4–7 NET legs (cash/bank/oldgold/customer-balance Dr; sales/GST/roundoff Cr); `enrichLedgerLine` **posting.ts:61** stamps LEDR_KEY=`key+pad(srno,2)`, `IT_TYPE='A'`, **LD_CODE=srno (ordinal)**, `BOOK_NAME`; `SIGN:'D'/'C'`; balance enforced `assertBalanced` **posting.ts:42**. | **PARTIAL** | Double-entry balance + the 4 named fields ARE stamped. But: (a) net 4–7 legs vs gross ~39; (b) **LD_CODE semantics differ** — web=line ordinal, desktop=contra account code; (c) **SIGN differs** — web `D/C`, desktop reserves SIGN for metal `+/-`; (d) **FINE_WT/FINE_RATE never populated** → no metal/fine sub-ledger; (e) single `SALES` a/c vs per-GROUP_MAST `SALE_AC`; (f) HM/TCS/TDS/SCHM/POINT/UPI-rows/ORD-adv/CASH_PAID legs absent; (g) AC_DATA **VCH_DATE, BILL_NO, PARTY_AC_CODE, MAIN_USER, IT_DESC, HD_VCH_NO, CLR_DATE not set** by web. |
| 2 | **Tax: CGST/SGST/IGST split + TAX_DATA cols (TRAN_TYPE/TAX_AMT)** | `Ac_Tax.Sales_GST` **Ac_Tax.cs:77**. India branch: SR1 `TAX_AMT/2` + SR2 `TAX_AMT/2` when `D.AC_GST_TYPE<>'I'` (CGST+SGST); SR3 `TAX_AMT` when `='I'` (IGST) — **inter/intra from AC_MAST.AC_GST_TYPE at posting** (~Ac_Tax.cs:92–96). `TRAN_TYPE='S'`, `TAX_SIGN='+'`, `TAX_TYPE=C.TAX_GROUP`, `TAX_CODE=A.TAX_CODE`, `TAX_PRC=C.TAX_PRC`. Separate HM tax SR10/20/30 (~:98–102); UAE single 'I' VAT branch (:81–87). | `taxRows` **sales.ts:287**: `interState ? [IGST]: [CGST(tax/2),SGST(tax/2)]`; `TRAN_TYPE:'S'`, `TAX_SIGN:'+'`, `TAX_TYPE:'CGST'/'SGST'/'IGST'`, `NET_AMT=taxable`, `TAX_PRC=pct/2`. `gstSplit` in `@datacare/core`. | **PARTIAL** | Split shape (CGST=SGST=tax/2, single IGST), TRAN_TYPE 'S', TAX_SIGN '+' MATCH. Diffs: (a) inter/intra from **manual `interState` bool** vs desktop deriving from `AC_MAST.AC_GST_TYPE`; (b) `TAX_TYPE` literal 'CGST'/'SGST' vs desktop `TAX_GROUP` code; (c) **TAX_CODE omitted** by web; (d) **no HM_TAX / OTH_TAX rows**; (e) `R_CHARG, ISR_NO, TAX_FREE_AMT, ZERO_RATED_AMT` not set by web; (f) TOT_AMT formula differs (desktop `TOT+TDS-(HM+HM_TAX+TCS)`). |
| 3 | **Stock: MAIN_STOCK rows, sign/INOUT, weight+fine** | `Ac_Stock.Sale_Stk` **Ac_Stock.cs:92**: SR3 main sale **OUT `TR_TYPE 'S' ITM_SIGN '-'`**, SR4 old-gold **IN `'P'/'+'`**, SR5 ISU_NO reversal `'I'/'+'`, SR6 ORD tag-add `'I'/'+'`, SR7/8 **tag-vs-actual wt-diff** (`TAG_GWT-ITM_GWT` etc, when `MsSlAndTagWtDiff='Y'`). **50-col** INSERT incl ITM_WEST, KR_NWT/KR_TOUCH/KR_WEST/KR_FINE, TAG_COST, ITM_MRP, DESIGN_NO, ITM_SIZE, GHT_PRC, ITM_LOT, ITM_DISC. | `mainStock` **sales.ts:215**: per **tagged** line, `VCH_TYPE:'TGSL', TR_TYPE:'S', ITM_SIGN:'-'`, cols ITM_PCS/GWT/NWT/TOUCH/FINE/RATE/AMT/LBR_AMT/NET_AMT (~16). Old-gold IN `oldGoldStock` **sales.ts:279** `VCH_TYPE:'MIXSL', TR_TYPE:'P', '+'` but **only ITM_QTY/ITM_PCS** (no weights). | **PARTIAL** | Direction model (sale OUT `S/-`, old-gold IN `P/+`) + core sale weights MATCH. Diffs: (a) **tagged-only** — untagged item sales write NO stock row (desktop writes for all SL_DETL); (b) ~16 of ~50 cols (no ITM_WEST/KR_*/MRP/DESIGN/SIZE/GHT/LOT/DISC/STK_DATE/ISR_NO/VCH_SRNO/TBL_CODE); (c) **no wt-diff legs (SR7/8), no ISU/ORD legs**; (d) old-gold IN missing all weights+fine; (e) VCH_TYPE hardcoded vs `B.BOOK_SNAME`. |
| 4 | **Cash / Rojmel settlement** | `Ac_Rojmel.Sales_Rojmel` **Ac_Rojmel.cs:29** writes **ROJ_MEL_DATA** (33-col, weight-bearing) — legs '01/02' sale value, '03' BILL_OS Dr, '04' BILL_OS<0 Cr, '05' TAX, '06' TCS, UAE '07' OTH '08' OTH_TAX '09' HM '10' HM_TAX '11' LBR. File has **401 `INSERT INTO ROJ_MEL_DATA`**. | **No ROJ_MEL_DATA write anywhere in `web/apps/api/src`** (only comments: `tagOps.ts:17`, `reports.ts:352`). Day-book is **derived from AC_DATA at report time** — `reports.ts:352` "Day-book / Rojmel (AC_DATA for a date range)". `createSale` writes array **sales.ts:~300** has no ROJ_MEL_DATA. | **GAP** | The parallel cash/day-book table + its **weight legs (ITM_PCS/GWT/NWT/FINE/RATE)** are not maintained. Web substitutes an AC_DATA-derived day-book report; acceptable for money day-book but loses desktop's per-item metal rojmel rows, MEMB_CODE/SCHM_CODE/REF_NO tagging. |
| 5 | **Sale header math** (net/taxable/round-off/old-gold) | SL_DATA carries NET_AMT, DISC_AMT, TAX_AMT, CGST/SGST/IGST, **HM_AMT/HM_TAX_AMT, OTH_AMT/OTH_TAX_AMT, TCS_AMT, TDS_AMT, SCHM_AMT, POINT_VAL, KASAR_AMT, ROF_AMT** (signed leg '35' @Ac_Ledr.cs ~`CASE WHEN ROF_AMT>0…`), TOT_AMT, BILL_OS, CASH/CARD/CHQ/UPI, OLD_GL_AMT/OLD_SL_AMT, CASH_PAID. (read back across Ac_Ledr.cs:61–173) | `billTotals` (`@datacare/core`) → `header` **sales.ts:~248** {NET_AMT,DISC_AMT,TAX_AMT,CGST/SGST/IGST,ROF_AMT,TOT_AMT}; settlement `Object.assign` **sales.ts:271** {CASH_AMT,CARD_AMT,UPI_AMT,CHQ_AMT,OLD_GL_AMT,BILL_OS}. round-off `Math.round`. | **PARTIAL** | Base arithmetic (taxable=net−disc, tax=taxable×pct, total, BILL_OS=total−tenders, old-gold value) MATCHES. Missing header components: **HM_AMT/HM_TAX, OTH_AMT/OTH_TAX, TCS, TDS, SCHM_AMT, POINT_VAL, KASAR_AMT, OLD_SL_AMT, CASH_PAID(change)**; round-off is `Math.round(total)` not a configurable signed ROF leg. |
| 6 | **Sale line math** (gross/net wt, fine, making, amount) | SL_DETL feeds engines with ITM_FINE, ITM_AMT, LBR_AMT, NET_AMT, **ITM_WEST_PRC (wastage)**, KR_NET_WT/KR_TOUCH/KR_WEST_PRC/KR_FINE (karigar), TAG_GWT/TAG_NWT, IT_DISC_AMT, RATE_TYPE, ITM_GHT_PRC. (cols consumed at Ac_Stock.cs:92+, Ac_Rojmel.cs:29+) | `lineFine` **sales.ts:62** (`fineWt` or `net×touch/100`); `computeLine` **sales.ts:69** (`metal = metalAmount else fine×rate`, `labour=labourCharge(...)`, `net=metal+labour+other`); `detl` **sales.ts:161** sets ITM_PCS/GWT/NWT/TOUCH/FINE/RATE/AMT, LBR_AMT, NET_AMT, ITM_CGST/SGST/IGST, IT_TAX_AMT, TOT_AMT, HM_ID. | **PARTIAL** | fine=net×touch/100, metal=fine×rate, net=metal+making+other MATCH intent. Missing: **wastage % (ITM_WEST_PRC)** — desktop adds wastage to fine; **karigar block (KR_*)**, **TAG_GWT/TAG_NWT** (tag-vs-billed), **RATE_TYPE** cost basis ('P'), **per-line discount (IT_DISC_AMT)**, LOT_NO/DESIGN_NO/ITM_SIZE/GHT, BAG_WT/ITM_OTH_WT. Making per-gram only in main UI. |
| 7 | **DB footprint — tables written** | Sale writes (verified): **AC_DATA** (Ac_Ledr 934 INSERTs), **ROJ_MEL_DATA** (Ac_Rojmel 401), **MAIN_STOCK** (Ac_Stock 97), **TAX_DATA** (Ac_Tax recordset INSERT…SELECT), + recordset SL_DATA/SL_DETL/SL_IDTL/SL_PR_DETL/UPI_DATA/SL_ORD_ADJ/COMM_DATA/BILL_OS_DATA/DM_DATA; del path DELETEs 20+ tables (TR_SALE.cs DELETE list). | `createSale` writes **sales.ts:~300**: SL_DATA, SL_DETL, SL_IDTL, MAIN_STOCK(×2), SL_PR_DETL, TAX_DATA, BILL_OS_DATA + AC_DATA. `deleteSale` reverses SL_DATA/SL_DETL/SL_IDTL/SL_PR_DETL/MAIN_STOCK/AC_DATA/TAX_DATA/BILL_OS_DATA + DELETE_DATA. | **PARTIAL** | Core tables present. **Missing tables: ROJ_MEL_DATA, UPI_DATA (multi-UPI), SL_ORD_ADJ (advance adj), COMM_DATA (member commission), DM_DATA (diamond).** BILL_OS_DATA written by both but web sets money only (BILL_AMT/REC_AMT/KASAR_AMT) — desktop schema also has BILL_GOLD/REC_GOLD/BILL_SILVER (metal OS) unset by web. |
| 7b | **DB footprint — exact desktop per-column write set on recordset tables** (SL_DATA/SL_DETL/SL_IDTL/SL_PR_DETL/BILL_OS_DATA) | Persisted via `SqlDataAdapter`+`SqlCommandBuilder` (**Module_Save.cs:78**), NOT literal SQL — column set = in-form DataTable shape; not statically enumerable from the .cs. | Web column set is explicit (sales.ts:161/248/271). | **CANNOT-VERIFY** | Desktop column-level footprint for recordset-written tables cannot be confirmed from static decompiled code; would require runtime row capture or the WinForms designer field map. Engine **read-backs** prove ≥40 SL_DATA + ≥30 SL_DETL columns are populated, but the exhaustive set is unverified. |
| 8a | **Returns** (TR_SALE_RTN) | `SaleReturn_Ledr` **Ac_Ledr.cs:1321**, `SaleReturn_RojMel` **Ac_Rojmel.cs:584**, `Sales_Rtn_GST` **Ac_Tax.cs:179**, `SaleReturn_Stk` **Ac_Stock.cs:230** (first leg `TR_TYPE 'O' ITM_SIGN '-'` from SL_DETL, MAIN_BOOK 'SALES RETURNE'). Footprint incl SL_DATA/SL_DETL_RTN/AC_DATA/TAX_DATA/ROJ_MEL_DATA/MAIN_STOCK/BILL_OS_DATA. | `createSaleReturn` **salesReturn.ts:59**: `buildReturnLedger` **:39** (Dr SALES+GST / Cr customer), SL_DETL_RTN **:74**, `taxRows` **:98** (`TRAN_TYPE:'SR', TAX_SIGN:'-'`), `mainStock` **:105** (`VCH_TYPE:'GSRTN', TR_TYPE:'I', '+'`). | **PARTIAL** | Web now DOES write TAX_DATA(SR,'-') + MAIN_STOCK + reverse ledger (prior gap doc was stale). Missing: **ROJMEL, BILL_OS reversal, original-bill item pull, fine-weight ledger, single-leg ledger**. ⚠ stock **direction CANNOT-VERIFY**: web posts IN `'+'`; desktop `SaleReturn_Stk` first leg read as `'-'/'O'` (method continues past read window). |
| 8b | **Orders** (TR_SALE_ORD) | `Order_Ledr` **Ac_Ledr.cs:28**, `Order_Rojmel` **Ac_Rojmel.cs:9**, `Order_Stk` **Ac_Stock.cs:80** (reserves/adds tag stock). Footprint SL_ORD_DATA/DETL/IDTL + AC_DATA + ROJ_MEL_DATA + MAIN_STOCK + SL_PR_DETL. | `createSalesOrder` **salesOrder.ts:47**: SL_ORD_DATA **:92**, SL_ORD_DETL **:75**, SL_ORD_IDTL, AC_DATA **only if advance** (Dr CASH/Cr cust). | **PARTIAL** | Header+detail+idtl+advance ledger present & line math (fine/metal/making) computed **salesOrder.ts:55**. Missing: **stock reservation (Order_Stk), ROJMEL, SL_PR_DETL**; frontend exposes single amount only (no line grid) — see #9. |
| 8c | **Labour/jobwork** (TR_SALE_LBR) | **Distinct engine**: `Labour_Ledr` **Ac_Ledr.cs:1201**, `Labour_RojMel` **Ac_Rojmel.cs:528**, `Labour_Stk` **Ac_Stock.cs:216** (metal issue OUT + receive IN via LBR_ISU_DETL/LBR_REC_DETL), `LbrWork_GST` **Ac_Tax.cs:147**. Writes LBR_DATA/LBR_ISU_DETL/LBR_ISU_IDTL/LBR_REC_DETL/TOUCH_MAST. | `labour-sale/page.tsx` posts to **`/sales`** (`coBook:'LBR'`); backend = generic `createSale` (sales.ts:132). `labourCharge` types exist in `@datacare/core`. **No LBR_DATA / LBR_ISU_*/REC_* writer in web.** | **GAP** | Web has no distinct labour engine: **no LBR_DATA, no jobwork metal issue/receive in+out, no LbrWork GST path**. Labour billed as a generic sale line only. |
| 8d | **Hallmark** (TR_SALE_HM) | Same engine as TR_SALE (TR_SALE_HM.cs references Sales_GST/TAX_DATA ×3) + per-line HUID + **HM_AMT/HM_TAX** charge taxed separately (Ac_Ledr legs '11'/'12'; Ac_Tax SR10/20/30 @ Ac_Tax.cs:98–102). | `hallmark-sale/page.tsx` posts to `/sales` with `huid` → `detl.HM_ID` (**sales.ts:161**, field `HM_ID: c.in.huid`). | **PARTIAL** | HUID captured to SL_DETL.HM_ID. Missing: **HM_AMT (hallmark charge) + HM_TAX (separate hallmark GST)** — no hallmark-charge ledger/tax legs; no HM_ID2/3/4 multi-HUID, no HM_ID_WT. |
| 9 | **Frontend fields** (desktop form vs web page) | TR_SALE form (per Ac_* read-backs + form): Book, Bill date, Customer(AC_MAST lookup→balance/GST/limit), grid: IT_CODE, TAG_NO(barcode→BAR_DETL autofill), DESIGN_NO, PCS, GROSS, NET, TOUCH, **WASTAGE% (ITM_WEST_PRC)**, FINE, RATE, RATE_TYPE, LBR_RATE+LBR_TYPE, OTH_AMT, ITM_MRP, ITM_SIZE, GHAT%, HUID, line DISC; footer: DISC, SCHM, POINT, multi-tender CASH/CARD/UPI×n/CHQ(+CHQ_NO/BANK/CARD_AC), OLD-GOLD multi-row, CASH_PAID, KASAR, ROF, TCS/TDS, advance-adjust, remark. | `sales/page.tsx`: Book, Year, Location, Party(`LookupPicker accounts`→sets interState from AC_GST_TYPE), Name, Tax%, Discount, Inter-state(select); settlement Cash/Card/UPI/Cheque + single Old-Gold(net/touch/rate); grid Item/Tag(LookupPicker→autofill nwt/gwt/touch/rate)/Pcs/Gross/Net/Touch/Rate/Making-g/Fine/Amount. `hallmark-sale` adds HUID; `labour-sale` labourType+value; `sale-return` grid w/o settlement; `sales-order` single amount+advance. | **PARTIAL** | Web HAS master lookups (accounts/items/tags) + tag autofill + GST-type-on-pick (**partial parity**, but maps `AC_GST_TYPE!=='L'`→interState vs desktop `='I'`→IGST — different rule). Missing fields: **wastage%, DESIGN_NO, MRP, ITM_SIZE, GHAT%, RATE_TYPE, per-line disc, labour-type(main grid), scheme, points, kasar, round-off input, TCS/TDS, CHQ_NO/bank, multi-UPI, advance-adjust, bill-date, remark, multi-row old-gold**. sales-order grid absent (backend supports lines). |

---

## 2. DB footprint detail — column-level (sale)

**AC_DATA** (29 desktop cols, Ac_Ledr.cs:63) — web sets 14: `CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_TYPE,
AC_CODE,DR_AMT,CR_AMT,SIGN,LEDR_KEY,IT_TYPE,LD_CODE,BOOK_NAME` (+tenant_id). **Web omits:** `VCH_DATE, BILL_NO,
BILL_DATE, CHQ_NO, FINE_WT, IT_DESC, ENTRY_TIME, HD_VCH_NO, CLR_DATE, DATA_TYPE, DATA_TRFR, MAIN_USER, FINE_RATE,
PARTY_AC_CODE, LDR_NAME` (15 cols). VCH_DATE-on-ledger and FINE_WT/FINE_RATE are the material omissions.

**TAX_DATA** (23 desktop cols) — web sets ~15 (key+SR_NO,BOOK_NAME,TRAN_TYPE,VCH_DATE,AC_CODE,TAX_TYPE,TAX_PRC,
NET_AMT,TAX_AMT,DISC_AMT,TOT_AMT,TAX_SIGN,PARTY_NAME). **Web omits:** `TAX_CODE, R_CHARG, ISR_NO, TAX_FREE_AMT,
ZERO_RATED_AMT, BILL_NO, BILL_DATE, BILL_DBCD, VCH_SRNO`.

**MAIN_STOCK** (50 desktop cols, Ac_Stock.cs:92) — web sets ~16. **Web omits:** `ISR_NO, STK_DATE, TBL_CODE,
ITM_WEST, LBR_RATE, OTH_AMT, ITM_MRP, KR_NWT, KR_TOUCH, KR_WEST, KR_FINE, KR_LBR_AMT, KR_OTH_AMT, KR_COST,
EMP_CODE, ENTRY_TIME, MAIN_USER, DATA_TYPE, DESIGN_NO, ITM_SIZE, ITM_DESC, GHT_PRC, ITM_LOT, ITM_DISC` (+wt-diff/ISU/ORD legs).

**BILL_OS_DATA** — web `osRow` sets money OS (BILL_AMT/REC_AMT/KASAR_AMT); desktop schema also carries
`BILL_GOLD/REC_GOLD/KASAR_GOLD/BILL_SILVER/REC_SILVER` (metal OS) — unset by web.

**Tables desktop writes that web never writes (sale):** `ROJ_MEL_DATA, UPI_DATA, SL_ORD_ADJ, COMM_DATA, DM_DATA`.

---

## 3. GAPS FOUND (prioritised)

**P0 — money/metal correctness:**
1. **No fine-weight / metal sub-ledger** — AC_DATA.FINE_WT/FINE_RATE never set; desktop leg '38' + ROJMEL carry metal. Gold trial-balance impossible. (Ac_Ledr.cs:61 vs posting.ts:61)
2. **ROJ_MEL_DATA not maintained** (behaviour 4 GAP) — day-book derived from AC_DATA only (reports.ts:352); loses per-item metal day-book legs. (Ac_Rojmel.cs:29)
3. **Ledger decomposition shallow** — ~4–7 net legs vs ~39; no HM/TCS/TDS/SCHM/POINT/multi-UPI/order-adv/CASH_PAID legs; income not split per GROUP_MAST `SALE_AC`. GL wrong for any non-trivial bill. (Ac_Ledr.cs:61–173)
4. **LD_CODE semantic mismatch** — web=line ordinal, desktop=contra account; breaks ledger contra reporting. (posting.ts:61 vs Ac_Ledr.cs:63)
5. **Labour/jobwork = GAP (8c)** — no LBR_DATA/metal issue+receive; jobwork accounting absent. (Ac_Ledr.cs:1201)

**P1 — tax & stock fidelity:**
6. **GST inter/intra from manual bool** not `AC_MAST.AC_GST_TYPE` at posting; no per-item TAX_CODE/HSN/multi-slab; no HM/OTH tax rows. (Ac_Tax.cs:77 vs sales.ts:287)
7. **MAIN_STOCK tagged-only + thin** — untagged sales = no movement; ~16/50 cols; no wt-diff/ISU/ORD legs; old-gold IN has no weights. (Ac_Stock.cs:92 vs sales.ts:215/279)
8. **Wastage % (ITM_WEST_PRC) missing** from line math — under-charges metal. (sales.ts:62/69)
9. **Header components missing** — HM/OTH/TCS/TDS/SCHM/POINT/KASAR/old-silver; round-off is `Math.round` not configurable. (sales.ts:248)

**P2 — workflow & UI:**
10. **Returns:** no ROJMEL/BILL_OS reversal/orig-bill pull; verify stock IN/OUT sign. (salesReturn.ts:59 vs Ac_Stock.cs:230)
11. **Orders:** no stock reservation (Order_Stk), no ROJMEL; frontend single-amount only. (salesOrder.ts:47 vs Ac_Stock.cs:80)
12. **Hallmark:** HM_AMT/HM_TAX charge+tax not billed (only HUID stored). (sales.ts:161 vs Ac_Tax.cs:98)
13. **Frontend missing ~18 desktop fields** (wastage, design, MRP, size, ghat, per-line disc, scheme, points, kasar, round-off, TCS/TDS, multi-UPI, cheque-no/bank, advance-adjust, bill-date, remark, multi old-gold); GST-type pick rule differs (`!=='L'` vs `='I'`). (sales/page.tsx)

**Verification gaps (CANNOT-VERIFY):**
- Exact desktop per-column write set for recordset tables SL_DATA/SL_DETL/SL_IDTL/SL_PR_DETL/BILL_OS_DATA (DataAdapter pattern, Module_Save.cs:78) — runtime capture needed.
- `SaleReturn_Stk` net stock direction (Ac_Stock.cs:230 first leg `'-'`; web posts `'+'`) — full method body beyond read window.
- Desktop BILL_OS_DATA INSERT locus (UPDATE/DELETE seen in TR_SALE.cs; INSERT via recordset) — not statically pinned.

---

AUDIT_A VERDICT: parity=0 partial=10 gap=2 cannot-verify=1
