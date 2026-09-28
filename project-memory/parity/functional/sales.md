# FUNCTIONAL PARITY — SALES SUITE (field / button / flow level)

**Scope:** desktop DataCareNext (decompiled C# WinForms) vs web rebuild (Fastify + Next.js + Postgres).
**cwd:** `/Users/yakshitsavaliya/Desktop/imodule-extracted` · **READ-ONLY** (no app/DB writes).
**Date:** 2026-06-30 · **Baseline refreshed:** `project-memory/parity/audit-A-sales-posting.md` + `gap-core-sales.md` + `verify-sales-purchase.md`, re-verified against CURRENT code and the LIVE DB (`datacare`, tenant `default`).
**Forms owned:** TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_WH_SALE, TR_SL_EBILL. Engines: Ac_Ledr, Ac_Tax, Ac_Stock, Ac_Rojmel, Module_Save.
**Method:** every claim cited `file:line` on BOTH sides. Desktop SQL is `INSERT…SELECT` (statically readable); web is explicit Prisma row objects. Recordset-written desktop columns (SL_DATA/SL_DETL via `SqlDataAdapter`+`SqlCommandBuilder`, **Module_Save.cs:39/57/78**) remain **CANNOT-VERIFY** at column level.

---

## 0. WHAT CHANGED SINCE THE BASELINE (refresh delta)

Verified against current source — gaps the baseline (audit-A, 2026-06-30 AM) listed that are now **CLOSED or advanced**:

| Baseline gap | Status now | Evidence (web) |
|---|---|---|
| Rate-cut / RATE_UNFIX = **MISSING** (audit-A #28) | **IMPLEMENTED** (deep) — RATE_CUT_DATA + RATE_CUT_ISU + balanced split-leg ledger incl. **metal FINE_WT/FINE_RATE legs** (IT_TYPE 'G'/'S') | `rateCut.ts` `buildRateCutLedger`/`buildHeader`/`buildLineRows`/`postRateCut`; route `txn.ts /rate-cut`; page `txn/rate-cut/page.tsx` |
| e-Invoice / IRN = **stub only** (audit-A #21) | **IMPLEMENTED** — NIC v1.1 payload build + validate + **real Chartered Info GSP transport** + Fake transport; writes SL_DATA IRN/ACK + E_DATA; HSN read from ITEM_MAST | `einvoice.ts` `buildIrnPayload`/`submitIrnForSale`/`CharteredInfoIrnTransport`; routes `/einvoice/:vchNo`,`/einvoice/irn` |
| Sales-return: no TAX_DATA / no MAIN_STOCK (audit-A #17/8a) | **CLOSED** — writes TAX_DATA (`TRAN_TYPE 'SR'`, `TAX_SIGN '-'`, CGST/SGST split) + MAIN_STOCK IN (`GSRTN`/`I`/`+`) + reverse ledger | `salesReturn.ts:95-112` |
| Sales-order: backend single-amount only | **ADVANCED** — backend now accepts **line items** → SL_ORD_DATA/SL_ORD_DETL/SL_ORD_IDTL + advance ledger | `salesOrder.ts:52-108` (frontend still single-amount — see §4.4) |
| SL_IDTL omits INOUT_TYPE/ENTRY_TYPE (verify A4) | **CLOSED** — `INOUT_TYPE:'O'`,`ENTRY_TYPE:'S'` now set | `sales.ts:198-200` |
| AC_DATA missing LEDR_KEY/IT_TYPE/BOOK_NAME/DATA_TYPE | **CLOSED (stamps)** — `enrichLedgerLine` stamps LEDR_KEY, IT_TYPE 'A', DATA_TYPE 'A', BOOK_NAME, LD_CODE | `posting.ts` `enrichLedgerLine` |
| Period-lock (MsLockDt) not enforced | **CLOSED** — `assertPeriodOpen` reads CO_SET.LOCK_DATE inside every post | `posting.ts` `assertPeriodOpen`/`postVoucherTx` |

Still-open items from the baseline are re-stated and re-prioritised in §6 (weighted by real-data usage, §1).

---

## 1. REAL-DATA TAGGING (DHAKAN live DB) — reframes priority

Read-only queries (`SELECT set_config('app.tenant_id','default',false)` first):

| Fact | Value | Consequence |
|---|---|---|
| `SL_DATA` rows | 190, **all `RATE_UNFIX='N'`** | Desktop **leg-38 metal/fine ledger fires only `WHERE … RATE_UNFIX='Y'`** (Ac_Ledr.cs:~) → **for every DHAKAN retail sale the desktop posts NO metal leg either**. Retail sales are money-only at the ledger (**IT_TYPE 'A'**), exactly the task's note. ⇒ the baseline's headline P0 "no fine-weight ledger" is **NOT a real-data gap on the sales path**. |
| `SL_DETL.IT_TYPE` | G=133, S=109, O=3 | Line items are physically gold/silver, but income/ledger is booked as money (GROUP_MAST.ITM_TYPE='A' income path, Ac_Ledr legs 05/07). |
| `AC_DATA` FINE_WT≠0 | 174 / 5150 | Metal sub-ledger IS used — but by purchase/karigar/dhrn/rate-cut metal vouchers, **not** retail sales. |
| `ROJ_MEL_DATA` | **0 rows** | Desktop engine writes it (Ac_Rojmel.cs) but the migrated DHAKAN DB has **zero** rojmel rows ⇒ web's ROJMEL omission is **not real-data-bearing** here (day-book is derived from AC_DATA). Downgrade from P0→P3. |
| `LBR_DATA` | **0** | No labour/jobwork bills in real data ⇒ TR_SALE_LBR engine gap is **dormant** for DHAKAN. |
| `COMM_DATA` / `DM_DATA` / `SL_ORD_ADJ` / `RATE_CUT_*` | **0 / 0 / 0 / 0** | Member-commission, diamond detail, advance-adjust, rate-cut unused in real data. |
| `UPI_DATA` | 1 | Multi-UPI essentially unused. |
| `SL_ORD_DATA` | **76** | **Sales orders ARE heavily used** ⇒ TR_SALE_ORD depth gaps (frontend single-amount, no stock reservation) are the **most material real-data gap** in this suite. |
| `SL_DETL_RTN` | 1 | One real sale return. |
| `TAX_DATA.TRAN_TYPE` | S=178, P=6 | Sales tax register is the live path. |

**Net:** the suite's true real-data risk is concentrated in **sales-order depth**, **multi-tender/ledger-leg decomposition for non-trivial bills**, **GST inter/intra rule**, and **hard-coded VCH_TYPE** — not in the metal-ledger/ROJMEL items the baseline ranked P0.

---

## 2. SHARED-ENGINE PARITY (the spine under every form)

### 2.1 Ledger — `Ac_Ledr.Sales_Ledr` (Ac_Ledr.cs:61) vs `buildSaleLedger`+`enrichLedgerLine`
Desktop posts **up to 39 gross contra-leg pairs** into AC_DATA (29 cols), LEDR_KEY = `CO+LC+YR+BOOK+VCH+'NN'(+STR(SR_NO))`, **LD_CODE = contra account** (`B.AC_CODE` from BOOK_DETL SR_NO 1=party/2=cash/3=kasar/5=disc/6=labour, or `D.SALE_AC`/`D.PURC_AC`/`D.TAX_AC`):
- 01 Dr customer `TOT_AMT+DISC_AMT+TDS_AMT`; 05/07 Cr `GROUP_MAST.SALE_AC` (ITM_TYPE='A' money) ; 06/08 Cr SALE_AC (ITM_TYPE≠'A' metal); 09 Cr `TAX_MAST.TAX_AC` `TAX_AMT`; 10 TCS; 11/12 HM_AMT+HM_TAX; 13/14 TDS; 15/16 CHQ→`BANK_AC`; 17/18 CARD→`CARD_AC`; 19/20 SCHM (only `MsSoftType='L'`); 21/22 ORD adv (`SL_ORD_ADJ.ORD_AC_CODE`); 23/24 old-gold (`SL_PR_DETL`→`GROUP_MAST.PURC_AC`); 25/26 CASH; 27-30 CASH_PAID change; 31/32 `KASAR_AMT+POINT_VAL`; 33/34 DISC; **35 ROF signed** (`CASE WHEN ROF_AMT>0…`); 36/37 UPI (`UPI_DATA` n-rows); **38 FINE_WT metal leg** (`SIGN '-'`, `A.ITM_FINE`, `IT_TYPE=item`, **only `RATE_UNFIX='Y'`**); 39 member commission (`COMM_DATA`, reg-gated). `B2B_Sales_Ledr` adds PRM_AMT/PRM_DISC premium legs.
Web `buildSaleLedger` (`sales.ts:91`) posts **4–7 NET legs** (cash/bank/old-gold Dr, customer-balance Dr, sales/GST/round-off Cr); `enrichLedgerLine` (`posting.ts`) stamps LEDR_KEY=`key+pad(srno,2)`, **IT_TYPE 'A'**, **LD_CODE = line ordinal**, DATA_TYPE 'A', BOOK_NAME; `assertBalanced` enforces ΣDr=ΣCr.
**Verdict DEPTH.** Match: double-entry balance, 4 named fields, money IT_TYPE 'A', round-off leg, BOOK_NAME='SALES'. Diffs: (a) net vs gross legs — **for any bill with HM/TCS/TDS/scheme/points/multi-UPI/card/cheque/order-adv the GL contra detail is collapsed**; (b) **LD_CODE = ordinal vs contra account** (breaks contra reporting); (c) income to single `SALES` a/c vs per-GROUP_MAST `SALE_AC`; (d) `VCH_TYPE` hard-coded `'SALE'` (`sales.ts:106`) vs `B.BOOK_SNAME` (TGSL/TSSL/MIXSL); (e) AC_DATA `VCH_DATE/BILL_NO/PARTY_AC_CODE/FINE_WT/FINE_RATE/CHQ_NO` unset. **Real-data note:** for DHAKAN's all-money cash/credit retail bills the net-leg set reconciles to the same balances; the leg-detail loss bites only on multi-tender/charge bills.

### 2.2 Tax — `Ac_Tax.Sales_GST` (Ac_Tax.cs:77) vs `taxRows` (sales.ts:286)
Desktop India branch: SR1 `TAX_AMT/2` + SR2 `TAX_AMT/2` when `AC_MAST.AC_GST_TYPE<>'I'` (CGST+SGST); SR3 `TAX_AMT` when `='I'` (IGST); separate HM SR10/20/30. `TRAN_TYPE='S'`, `TAX_SIGN='+'`, `TAX_TYPE=C.TAX_GROUP`, `TAX_CODE=A.TAX_CODE`, `TAX_PRC=C.TAX_PRC`, `TOT_AMT=TOT_AMT+TDS-(HM+HM_TAX+TCS)`. Web: `interState ? [IGST] : [CGST(tax/2),SGST(tax/2)]`, `TRAN_TYPE 'S'`, `TAX_SIGN '+'`, `TAX_TYPE` literal 'CGST'/'SGST'/'IGST', `gstSplit` SGST=tax−CGST (exact, calc.ts).
**Verdict DEPTH.** Split shape + TRAN_TYPE + TAX_SIGN match. Diffs: (a) inter/intra from **web manual `interState` bool** (mapped on lookup as `AC_GST_TYPE!=='L'`) vs desktop **`AC_GST_TYPE='I'`** → web treats any non-'L' (blank/'R'/'U') as inter-state, desktop only 'I'; (b) `TAX_TYPE` literal vs `TAX_GROUP` code; (c) `TAX_CODE` omitted; (d) **no HM_TAX / OTH_TAX rows**; (e) `R_CHARG/ISR_NO/TAX_FREE_AMT/ZERO_RATED_AMT` unset.

### 2.3 Stock — `Ac_Stock.Sale_Stk` (Ac_Stock.cs:92) vs `mainStock` (sales.ts:215)
Desktop (50 cols): SR3 main sale **OUT `S/-`** from SL_DETL using **`TAG_GWT/TAG_NWT`** (or ITM_* if `MsStockRptView='OLD'`); SR4 old-gold **IN `P/+`** from SL_PR_DETL (full weights+fine); SR5 ISU_NO reversal `I/+`; SR6 ORD tag-add `I/+`; SR7/8 **tag-vs-actual wt-diff** (`TAG_GWT-ITM_GWT` O/-, `ITM_GWT-TAG_GWT` I/+) when `MsSlAndTagWtDiff='Y'`. Cols incl ITM_WEST, KR_NWT/TOUCH/WEST/FINE, TAG_COST, ITM_MRP, DESIGN_NO, ITM_SIZE, GHT_PRC, ITM_LOT, ITM_DISC. Web `mainStock` (`sales.ts:215`): **tagged lines only**, `VCH_TYPE:'TGSL', TR_TYPE:'S', ITM_SIGN:'-'`, ~16 cols; old-gold IN (`sales.ts:238`) `VCH_TYPE:'MIXSL', 'P','+'` with **only ITM_QTY/ITM_PCS** (no weights/fine).
**Verdict DEPTH.** Direction model matches. Diffs: untagged-line sales write no stock row; ~16/50 cols; no SR5/6/7/8 legs; old-gold IN missing weights+fine; `VCH_TYPE` 'TGSL'/'MIXSL' hard-coded vs BOOK_SNAME (matches book 026 by luck only).

### 2.4 Day-book — `Ac_Rojmel.Sales_Rojmel` (Ac_Rojmel.cs:29) vs (none)
Desktop writes **ROJ_MEL_DATA** (33-col, weight-bearing: ITM_PCS/GWT/NWT/FINE/RATE + MEMB_CODE/SCHM_CODE/REF_NO). Web writes **no ROJ_MEL_DATA**; day-book derived from AC_DATA at report time (`reports.ts dayBook`). **Verdict GAP — but real DB has 0 ROJ_MEL_DATA rows (§1) ⇒ P3.**

---

## 3. ENGINE-WRITE FOOTPRINT MATRIX (per voucher class)

| Table | Desktop writer | Web writer | Verdict |
|---|---|---|---|
| SL_DATA (header) | recordset (Module_Save) | `sales.ts:244` (~22 of ~56 cols) | DEPTH (thin cols) |
| SL_DETL (lines) | recordset | `sales.ts:158` (~26 cols; +INOUT/ENTRY/BOOK_NAME) | DEPTH (no ITM_WEST_PRC/KR_*/TAG_GWT/RATE_TYPE/DESIGN/MRP/SIZE/GHT/LOT) |
| SL_IDTL (tag sub) | recordset | `sales.ts:196` (+INOUT/ENTRY now) | DEPTH |
| AC_DATA (ledger) | Ac_Ledr 01-39 | `sales.ts:91`+posting.ts (4-7 legs) | DEPTH |
| TAX_DATA | Ac_Tax SR1/2/3/10/20/30 | `sales.ts:286` (CGST/SGST or IGST) | DEPTH (no HM/OTH; TAX_CODE/R_CHARG unset) |
| MAIN_STOCK | Ac_Stock SR3-8 | `sales.ts:215`+`238` (2 legs, tagged only) | DEPTH |
| SL_PR_DETL (old-gold) | recordset | `sales.ts` oldGoldDetl | DEPTH |
| BILL_OS_DATA | recordset (money OS) | `sales.ts:296` (money OS) | OK (money) / DEPTH (no metal-OS cols) |
| ROJ_MEL_DATA | Ac_Rojmel 401 INSERTs | **none** | GAP (P3 — 0 real rows) |
| UPI_DATA | recordset (n-rows) | **none** (lumped into bankAmt) | GAP (P3 — 1 real row) |
| SL_ORD_ADJ | Ac_Ledr 21/22 | **none** | GAP (P3 — 0 real rows) |
| COMM_DATA / DM_DATA | recordset / Dm_Sale_Detl | **none** | GAP (P3 — 0 real rows) |

---

## 4. PER-FORM FUNCTIONAL DELTA

### 4.1 TR_SALE — Retail Sale  →  `/sales` + `txn/sales/page.tsx`   **[DEPTH]**
Desktop save delegation **TR_SALE.cs:16118-16130 & 20736-20739**.

**(1) Frontend fields** — *present:* Book, Year, Location, Party (LookupPicker accounts → AC_GST_TYPE sets interState), Customer Name, Tax%, Discount, Inter-state select; item grid Item/Tag (LookupPicker, tag autofill nwt/gwt/touch/rate) / Pcs / Gross / Net / Touch / Rate / Making-g / Fine / Amount; settlement Cash/Card/UPI/Cheque + single Old-Gold (net/touch/rate). *Missing vs desktop form (TR_SALE grid+footer):* **WASTAGE% (ITM_WEST_PRC)**, DESIGN_NO, ITM_MRP, ITM_SIZE, GHAT% (ITM_GHT_PRC), RATE_TYPE, per-line discount, labour-TYPE in main grid, karigar block, **bill-date** (server now()), **scheme redeem**, **points redeem**, **kasar**, **round-off input**, **TCS/TDS**, **multi-UPI rows + UPI ref**, **cheque-no/bank/card-a/c**, **advance-adjust (order)**, **multi-row old-gold**, remark, B2B premium.
**(2) Buttons/actions** — *present:* Save (`POST /sales`), Add-line, delete-row (client), View Invoice PDF (`/sales/invoice`), lookups (accounts/items/tags), live totals preview. *Missing:* **delete-voucher button** (API `DELETE /sales/:vchNo` exists, no UI), **print CUSTOMER + ACCOUNT copies** (desktop `MaPirntCopy`, one generic PDF only), **e-invoice button on the sale page** (separate utilities page), **WhatsApp/SMS send** (desktop `Module_WhatsApp`/`UT_SMS`, TR_SALE.cs:13975), F-key workflow, settlement/old-gold/advance-adjust dialogs.
**(3) Validations** — *web:* acCode required (`sales.ts:121`), ≥1 line, ledger balance (`assertBalanced`), tag double-issue guard (`issueTagTx`), period-lock (`assertPeriodOpen`). *Missing vs desktop:* **credit/OS limit** (TR_SALE.cs:14957/14964), **cash-receipt limit** (14983), **defaulter-list block** (14926), licence-expiry (14918), **negative-stock block** (10398), duplicate-tag (12065/12097/12437), min-labour% (13123), HUID 6-char, rights check (11961).
**(4) Calc/flow** — fine=net×touch/100, metal=fine×rate, net=metal+labour+other, taxable=net−disc, tax=taxable×pct, CGST=SGST=tax/2 | IGST, round = `Math.round` half-up (calc.ts billTotals), BILL_OS=total−tenders. *Missing:* **wastage added to fine** (desktop fine=net×(touch+west)/100), RATE_TYPE cost basis, per-line disc, HM/OTH/TCS/TDS/scheme/points/kasar in totals, configurable signed ROF leg.
**(5) DB** — see §3. Money-correct for DHAKAN's all-`RATE_UNFIX='N'` money sales; thin columns + collapsed legs on rich bills.

### 4.2 TR_SALE_HM — Hallmark Sale  →  `/sales` (coBook 'HM') + `txn/hallmark-sale/page.tsx`   **[DEPTH]**
Desktop = same engine as TR_SALE + per-line **HUID** + **HM_AMT/HM_TAX** charged & taxed separately (Ac_Ledr legs 11/12; Ac_Tax SR10/20/30). Web adds a **HUID column** → `SL_DETL.HM_ID` (`sales.ts:158` `HM_ID:c.in.huid`), posts to generic `/sales`.
**(1)** fields: +HUID. Missing: HM charge amount, HM tax%, HM_ID2/3/4 multi-HUID, HM_ID_WT. **(2)** same buttons as 4.1. **(3)** no HUID 6-char validation. **(4)** **no hallmark-charge ledger/tax legs** — HM_AMT/HM_TAX never billed. **(5)** HUID stored only; no HM tax row in TAX_DATA.

### 4.3 TR_SALE_LBR — Labour / Jobwork  →  `/sales` (coBook 'LBR') + `txn/labour-sale/page.tsx`   **[DEPTH — engine breadth gap]**
Desktop = **distinct engine**: `Labour_Ledr` (Ac_Ledr.cs:~1201) / `Labour_Stk` (Ac_Stock.cs:225 — metal issue **OUT** `LBR_ISU_DETL O/-` + receive **IN** `LBR_REC_DETL I/+`) / `LbrWork_GST` (Ac_Tax.cs — **LBR_DATA**: SL_NET_AMT/DR_LBR/LBR_TAX_AMT/LBR_DISC_AMT/OTH_DR_AMT/TOT_DR_AMT). Web routes labour through generic `createSale` with `labourType/labourRate/labourPct/labourFixed` (calc.ts `labourCharge`).
**(1)** fields: Item, Labour Type (fixed/per-gram/per-piece/%), Net/Pcs/Value/MetalAmt. Missing: jobwork metal issue+receive grids. **(2)** Save only. **(3)** acCode required. **(4)** labour types compute correctly but **booked as a generic sale line, not a labour bill**. **(5)** **no LBR_DATA, no LBR_ISU_DETL/LBR_REC_DETL, no jobwork metal in/out, no LbrWork_GST path.** *Real-data: LBR_DATA=0 ⇒ dormant.*

### 4.4 TR_SALE_ORD — Sales Order  →  `/sales-orders` + `txn/sales-order/page.tsx`   **[DEPTH — most material, 76 real rows]**
Desktop `Order_Ledr`/`Order_Rojmel` (Ac_Rojmel.cs Order_Rojmel: ROJ_MEL_DATA adv/chq/card/old-gold/schm/UPI legs)/`Order_Stk` (Ac_Stock.cs:86 — **reserves/adds tag stock**: SL_PR_DETL `P/+`, SL_ORD_DETL `O/-` when TAG_STK_LESS='Y'). Multi-line SL_ORD_DATA/DETL/IDTL w/ design, weights, making, delivery, advance.
**Backend (web):** `salesOrder.ts:52-108` **now supports line items** (fine/metal/making per line) → SL_ORD_DATA + SL_ORD_DETL + SL_ORD_IDTL + advance ledger (Dr CASH / Cr customer).
**(1) Frontend:** **single Order Amount + Tax% + Advance ONLY** — `sales-order/page.tsx` sends `netAmount`, no line grid (backend `lines[]` unused by the UI). Missing: item grid, design, weights, delivery date, line preview.
**(2)** Place Order (`POST`), recent-orders list. Missing: delete (API has none for orders), print order voucher, advance-receipt print.
**(3)** acCode + amount required. Missing: duplicate-order guard (TR_SALE.cs:7326), order-value cap (7372).
**(4)** totals via billTotals. **(5)** **no Order_Stk reservation (MAIN_STOCK), no ROJ_MEL_DATA, no SL_ORD_ADJ link** — order book is recorded but not stock-actionable.

### 4.5 TR_SALE_RTN — Sales Return  →  `/sales-returns` + `txn/sale-return/page.tsx`   **[DEPTH]**
Desktop `SaleReturn_Ledr`/`SaleReturn_RojMel`/`Sales_Rtn_GST`/`SaleReturn_Stk` (**Ac_Stock.cs:239** — SR1 **OUT `O/-` from SL_DETL** (exchange item) + SR2 **IN `I/+` from SL_DETL_RTN** (returned goods)). Web `createSaleReturn` (`salesReturn.ts:59`): SL_DATA('SRTN') + SL_DETL_RTN + reverse ledger (Dr SALES+GST / Cr customer) + TAX_DATA(`SR`,`-`) + MAIN_STOCK(`GSRTN`,`I`,`+`).
**Return-stock direction CANNOT-VERIFY now RESOLVED:** web's single IN `'+'` **matches desktop SR2** (SL_DETL_RTN → `I/+`); desktop additionally posts SR1 OUT (exchange/replacement item) which web does not model.
**(1)** grid Item/Tag/Pcs/Gross/Net/Touch/Rate/Making + Orig Bill No + GST select. Missing: settlement/refund tender, multi original-bill pull. **(2)** Save; no print/delete-UI. **(3)** acCode + ≥1 line. **(4)** reverse-of-sale totals. **(5)** Missing: **ROJMEL reversal, BILL_OS reversal, original-bill item auto-pull, exchange-OUT leg, fine-weight ledger**.

### 4.6 TR_WH_SALE — Wholesale Sale  →  `/sales` (coBook 'WH') + `txn/wholesale-sale/page.tsx`   **[DEPTH — wrong engine/tables]**
Desktop wholesale is **NOT** an SL_DATA voucher: it uses the **RATE_CUT_ISU / RATE_CUT_REC** table family + `Wh_Sales_Ledr` + `Wh_Sale_Stk` (Ac_Stock.cs — main OUT `S/-` from RATE_CUT_ISU, rec IN `P/+` from RATE_CUT_REC, ISU reversal, wt-diff; `MAIN_BOOK IN ('WH SALES','RATE CUT','VP PARCEL','BUL WH SALE','TOUR SALES')`). Confirmed **TR_WH_SALE.cs:12441** reads `RATE_CUT_ISU`. The web wholesale page posts to **generic `/sales` → SL_DATA/SL_DETL** — i.e. **the wrong table family + wrong (net-leg) ledger engine** for the wholesale/rate-cut domain.
**(1)** same grid as retail. **(2)** Save only. **(3)** acCode + ≥1 line. **(4)** retail calc (no west%/rate-type/old-gold-type IIF). **(5)** writes SL_DATA not RATE_CUT_ISU/WH-book; no Wh_Sale_Stk, no Wh_Sales_Ledr split legs, no premium. *Real data: WH books are RATE_CUT_*-backed and currently 0 rows.*

### 4.7 TR_SL_EBILL — e-Invoice / IRN  →  `einvoice.ts` + `/einvoice/*` + `utilities/e-invoice/page.tsx`   **[OK — GSP creds = external blocker]**
Desktop generates IRN+QR via Chartered Info GSP (GenIRN.txt / UT_E_INVOICE / TR_SL_EBILL). Web `einvoice.ts`: `buildIrnPayload` (NIC v1.1, SellerDtls/BuyerDtls/ItemList/ValDtls), `validateIrnPayload`, `submitIrnForSale` (reads SL_DATA+SL_DETL+CO_MAST+AC_MAST, **HSN/unit from ITEM_MAST**, fallback 7113/GMS), `CharteredInfoIrnTransport` (auth + Invoice POST, prod/sandbox hosts), `FakeIrnTransport` (deterministic). Persists `SL_DATA.IRN_NO/ACK_NO/ACK_DATE` + `E_DATA` row.
**(1/2/3)** B2B GSTIN required (throws otherwise); routes `POST /einvoice/:vchNo` (raw payload) and `/einvoice/irn` (by voucher). **(4/5)** payload arithmetic + E_DATA write match desktop. **Verdict OK** — only the live GSP submission needs `GSP_*` creds (intentionally not wired; flagged as external blocker in code).

### 4.8 (bonus) Estimate  →  `/estimate` + `txn/estimate/page.tsx`   **[OK]**
Compute-only quotation (no ledger/voucher) — `txn.ts /estimate` runs `computeLine`+`billTotals`; page downloads an "ESTIMATE — not a tax invoice" PDF. Matches desktop estimate intent. **OK.**

### 4.9 (bonus) Rate Cut  →  `/rate-cut` + `txn/rate-cut/page.tsx`   **[DEPTH — phase-2 projections pending]**
New deep module (see §0). Writes RATE_CUT_DATA + RATE_CUT_ISU + **balanced split-leg ledger incl. metal FINE_WT/FINE_RATE** (the dual-accounting pattern the retail path lacks). Page: line grid (item/tag/net/touch/west/rate/rate-type) + cash/kasar settlement + live fine/amount totals. **Phase-2 TODO (documented in `rateCut.ts`):** SL_IDTL, **ROJ_MEL_DATA, MAIN_STOCK (Wh_Sale_Stk), DM_DATA** not yet projected; BOOK_DETL contra-accounts are configurable defaults (book 064 BOOK_DETL empty). Delete path already reverses all phase-2 tables.

---

## 5. CLASSIFICATION

**Form-level (9 surfaces):** OK = 2 (e-invoice, estimate) · DEPTH = 7 (retail, hallmark, labour, order, return, wholesale, rate-cut) · BREADTH = 0 (every desktop sales form has a web surface).

**Behaviour-level (28 scored):**
| # | Behaviour | Verdict |
|---|---|---|
| 1 | Sale header math (net/disc/taxable/tax/round/total/BILL_OS) | OK |
| 2 | Sale line math (fine/metal/labour/net) | OK |
| 3 | GST CGST/SGST/IGST split shape | OK |
| 4 | Double-entry balance enforced | OK |
| 5 | LEDR_KEY/IT_TYPE 'A'/DATA_TYPE/BOOK_NAME stamping | OK |
| 6 | Period-lock (MsLockDt) | OK |
| 7 | Tag double-issue guard | OK |
| 8 | Sale-return TAX_DATA(SR,-) + MAIN_STOCK(IN +) | OK |
| 9 | e-Invoice / IRN payload + GSP transport | OK |
| 10 | Estimate (compute-only) | OK |
| 11 | Rate-cut metal ledger (FINE_WT/FINE_RATE) | OK |
| 12 | Master lookups + tag autofill (accounts/items/tags) | OK |
| 13 | Ledger leg decomposition (gross 39 vs net 4-7) | DEPTH |
| 14 | LD_CODE = contra account | DEPTH |
| 15 | GST inter/intra from AC_GST_TYPE='I' (web uses ≠'L') | DEPTH |
| 16 | Per-item TAX_CODE/HSN + HM/OTH tax rows | DEPTH |
| 17 | MAIN_STOCK 50-col + SR5/6/7/8 + untagged + old-gold wt | DEPTH |
| 18 | Wastage% (ITM_WEST_PRC) in fine | DEPTH |
| 19 | Header HM/TCS/TDS/SCHM/POINT/KASAR/old-silver/cash-paid | DEPTH |
| 20 | VCH_TYPE = BOOK_SNAME (hard-coded SALE/TGSL/MIXSL) | DEPTH |
| 21 | Hallmark HM_AMT/HM_TAX charge | DEPTH |
| 22 | Sales-order frontend line grid + stock reservation | DEPTH |
| 23 | Sales-return ROJMEL/BILL_OS/orig-pull/exchange leg | DEPTH |
| 24 | Wholesale → RATE_CUT_ISU/Wh engine (writes SL_DATA) | DEPTH |
| 25 | Labour LBR_DATA engine + jobwork metal in/out | DEPTH |
| 26 | Validations: credit/OS/cash limit, defaulter, neg-stock | DEPTH |
| 27 | Print CUSTOMER+ACCOUNT copies / WhatsApp-SMS / delete & e-inv buttons on page | DEPTH |
| 28 | ROJ_MEL_DATA / UPI_DATA / SL_ORD_ADJ / COMM_DATA / DM_DATA satellite tables | GAP (P3, 0–1 real rows) |

**Counts: OK = 12 · DEPTH = 15 · GAP(BREADTH-of-feature) = 1.** No whole form is missing (BREADTH=0 at form level).

---

## 6. TOP 10 CONCRETE GAPS (real-data-weighted)

1. **Sales-order frontend is single-amount** — backend supports lines (`salesOrder.ts:52`) but `sales-order/page.tsx` posts only `netAmount`; **76 real orders** ⇒ highest-impact. Also no `Order_Stk` reservation (Ac_Stock.cs:86) and no order delete.
2. **Ledger leg decomposition shallow** — 4-7 net legs vs desktop's 39 gross legs; **LD_CODE = ordinal not contra account** (`posting.ts` vs Ac_Ledr.cs:61). GL contra detail collapses on any HM/TCS/TDS/scheme/points/multi-tender bill.
3. **VCH_TYPE hard-coded** `'SALE'`/`'TGSL'`/`'MIXSL'` (`sales.ts:106/167/216/238`) instead of `BOOK_DATA.BOOK_SNAME`; wrong on every non-026 book.
4. **GST inter/intra rule differs** — web `AC_GST_TYPE!=='L'` ⇒ inter (`sales/page.tsx onPick`) vs desktop **`='I'`** (Ac_Tax.cs:77); blank/'R'/'U' customers mis-tax.
5. **Wholesale writes the wrong table family** — `wholesale-sale` → `/sales` (SL_DATA) but desktop uses **RATE_CUT_ISU/REC + Wh_Sales_Ledr/Wh_Sale_Stk** (TR_WH_SALE.cs:12441); no premium/old-gold-type logic.
6. **Hallmark charge not billed** — HUID stored to `SL_DETL.HM_ID` but **HM_AMT + HM_TAX** legs/rows absent (Ac_Ledr 11/12, Ac_Tax SR10/20/30).
7. **MAIN_STOCK thin + tagged-only** — ~16/50 cols, untagged-line sales write no movement, old-gold IN carries no weights/fine, no SR5/6/7/8 (ISU/ORD/wt-diff) legs (Ac_Stock.cs:92).
8. **Wastage% (ITM_WEST_PRC) absent** from retail fine math — desktop fine = net×(touch+west)/100; web omits west (under-charges metal). (rate-cut.ts already models west — port to sales.)
9. **Header charge components missing** — TCS/TDS/scheme/points/kasar/HM/OTH/old-silver/cash-paid + configurable signed round-off not in `billTotals`/SL_DATA header (`sales.ts:244`).
10. **Counter validations + buttons missing** — credit/OS limit, cash-receipt limit, defaulter block, negative-stock block (TR_SALE.cs:14957/14983/14926/10398); plus CUSTOMER+ACCOUNT print copies, WhatsApp/SMS, on-page e-invoice & delete buttons.

**Deferred (P3, structurally absent but 0–1 real rows in DHAKAN):** ROJ_MEL_DATA, multi-UPI (UPI_DATA), SL_ORD_ADJ advance-adjust, COMM_DATA member commission, DM_DATA diamond detail, LBR_DATA labour engine. The baseline's P0 "fine-weight metal ledger on sales" is **not a real gap** for DHAKAN retail: every live sale is `RATE_UNFIX='N'`, and desktop leg-38 fires only on `RATE_UNFIX='Y'` — so both desktop and web book retail sales money-only (IT_TYPE 'A').

**CANNOT-VERIFY (unchanged):** exact desktop per-column write set for recordset tables SL_DATA/SL_DETL/SL_IDTL/SL_PR_DETL (Module_Save.cs:78 DataAdapter pattern). **RESOLVED since baseline:** SaleReturn_Stk direction (web `+` = desktop SR2 SL_DETL_RTN leg, Ac_Stock.cs:239).
