# Parity Analysis — CORE ENGINE + SALES (gap_core_sales)

Desktop: decompiled C# WinForms (DataCareNext). Web: Next.js + Fastify + Prisma (apps/api, apps/web).
Evidence cited by file + method/line. Analysis only — no code modified.

---

## 0. ARCHITECTURE FINDING (critical)

The desktop posting engine is NOT a single function. `TR_SALE.cs` Save delegates to static helpers
(evidence: TR_SALE.cs lines 16118-16137 and 20736-20739):
```
Ac_Ledr.Sales_Ledr(book, vchNo);      // AC_DATA  (ledger)        Ac_Ledr.cs:61
Ac_Rojmel.Sales_Rojmel(book, vchNo);  // ROJMEL   (day/cash book)  Ac_Rojmel.cs:29
Ac_Tax.Sales_GST(book, vchNo);        // TAX_DATA (GST register)   Ac_Tax.cs:77
Ac_Stock.Sale_Stk(book, vchNo);       // MAIN_STOCK (inventory)    Ac_Stock.cs:98
Ac_Stock.Dm_Sale_Detl(book, vchNo);   // diamond detail            Ac_Stock.cs:798
Ac_Tax.Vch_Remark(book, vchNo, 0);    // voucher remark
```
These run set-based INSERT…SELECT from SL_DATA/SL_DETL joined to BOOK_DETL/BOOK_DATA/ITEM_MAST/
GROUP_MAST/TAX_MAST/AC_MAST inside a transaction (Module_Save.SlTran). The web reimplements a
*small* subset of this in TypeScript (sales.ts createSale).

### AC_DATA real schema (29 cols) — Ac_Ledr.cs:61+
`CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY,BOOK_NAME,BILL_NO,BILL_DATE,
CHQ_NO,AC_CODE,LD_CODE,CR_AMT,DR_AMT,IT_TYPE,SIGN,FINE_WT,IT_DESC,ENTRY_TIME,HD_VCH_NO,CLR_DATE,
DATA_TYPE,DATA_TRFR,MAIN_USER,FINE_RATE,PARTY_AC_CODE,LDR_NAME`

**DUAL ACCOUNTING:** every ledger row carries FINE_WT + FINE_RATE + IT_TYPE + SIGN. The desktop is a
metal-and-money ledger: leg '38' posts ITM_FINE per line as a metal-out movement (SIGN '-'). The web
AC_DATA writes only `AC_CODE,DR_AMT,CR_AMT,SIGN,VCH_TYPE,key` — NO fine-weight ledger, NO LEDR_KEY,
NO BOOK_NAME/BILL_NO/PARTY_AC_CODE/LD_CODE. This is the single biggest structural gap.

### Ac_Ledr.Sales_Ledr posts up to ~39 conditional ledger legs per bill (LEDR_KEY suffix):
01 Dr customer (TOT_AMT+DISC_AMT+TDS_AMT) · 05-08 Cr SALE_AC (per GROUP_MAST, split ITM_TYPE 'A' vs
weight) · 09 Cr GST TAX_AMT (TAX_MAST.TAX_AC) · 10 TCS_AMT · 11/12 HM_AMT + HM_TAX_AMT (hallmark
charges) · 13/14 TDS · 15/16 CHQ_AMT (BANK_AC) · 17/18 CARD_AMT (CARD_AC) · 19/20 SCHM_AMT (scheme
redemption, SCHM_AC) · 21/22 ORD_AMT (advance adj via SL_ORD_ADJ) · 23/24 SL_PR_DETL old-gold buy
(PURC_AC) · 25/26 CASH_AMT · 27-30 CASH_PAID change · 31/32 KASAR_AMT+POINT_VAL (round + loyalty
points) · 33/34 DISC_AMT · 35 ROF_AMT (signed round-off) · 36/37 UPI_AMT (multi-row via UPI_DATA) ·
38 FINE_WT metal leg · 39 member commission fine. Contra accounts resolved from BOOK_DETL.SR_NO
(1 party,2 cash,3 kasar,4 other,5 disc,6 labour,7 gold,8 silver). RATE_UNFIX='Y' takes a different
income-recognition path (rate-cut/UAE). A `B2B_Sales_Ledr` variant adds PRM_AMT/PRM_DISC premium legs.

### Ac_Tax.Sales_GST (TAX_DATA) — Ac_Tax.cs:77
Writes SR_NO 1=CGST(TAX_AMT/2), 2=SGST(TAX_AMT/2), 3=IGST(TAX_AMT) chosen by **AC_MAST.AC_GST_TYPE**
('I'=interstate) — i.e. inter/intra is derived from the CUSTOMER MASTER's state, not a manual toggle.
TAX_GROUP/TAX_PRC from TAX_MAST; separate rows for HM_TAX (hallmark) and OTH_TAX; columns include
TAX_TYPE, R_CHARG (reverse charge), ISR_NO, TAX_FREE_AMT, ZERO_RATED_AMT, PARTY_NAME, TAX_SIGN. UAE
build emits a single 'I' VAT row + zero-rated/tax-free handling.

### Ac_Stock.Sale_Stk (MAIN_STOCK ~50 cols) — Ac_Stock.cs:98
Legs: SR3 main sale OUT (TR_TYPE 'S' SIGN '-') from SL_DETL; SR4 SL_PR_DETL old-gold IN ('P' '+');
SR5 ISU_NO reversal IN; SR6 ORD_NO order-tag stock add; SR7/8 **tag-vs-actual weight-difference**
postings (when MsSlAndTagWtDiff='Y'): writes (TAG_GWT-ITM_GWT) as O/- and ITM_GWT-TAG_GWT as I/+.
Uses MsStockRptView (OLD→ITM_GWT, else TAG_GWT). Columns include ITM_TOUCH,ITM_FINE,ITM_RATE,ITM_AMT,
LBR_RATE,LBR_AMT,OTH_AMT,ITM_MRP,NET_AMT,KR_NWT/KR_TOUCH/KR_WEST/KR_FINE (karigar), TAG_COST,EMP_CODE,
DESIGN_NO,ITM_SIZE,GHT_PRC(ghat%),ITM_LOT,ITM_DISC. Web MAIN_STOCK row has ~10 cols, 1 leg, no
weight-diff, no karigar, no MRP/design/size/lot/ghat.

(Detail tables + workflow + gap table continue below.)

---

## 1. WHAT THE WEB CURRENTLY DOES (baseline)

Backend `apps/api/src/modules/sales/`:
- **sales.ts `createSale`** — one tx: nextVoucherNoTx → computeLine per line → billTotals →
  issueTagTx (double-issue guard) → writes SL_DATA, SL_DETL, SL_IDTL(tagged), MAIN_STOCK(out + old-gold in),
  SL_PR_DETL(old gold), TAX_DATA(1 row), BILL_OS_DATA(1 row), AC_DATA(buildSaleLedger). `deleteSale`
  reverses by key + restoreTag + DELETE_DATA.
- **salesReturn.ts `createSaleReturn`** — SL_DATA(VCH_TYPE 'SRTN') + SL_DETL_RTN + AC_DATA reverse;
  createTagTx puts returned tags back. No TAX_DATA, no MAIN_STOCK, no BILL_OS.
- **salesOrder.ts `createSalesOrder`** — SL_ORD_DATA/DETL/IDTL; AC_DATA only if advance (Dr CASH/Cr cust).
- **invoice.ts** — reads SL_DATA+SL_DETL, renders one HTML/PDF (CGST/SGST/IGST/round/total + words).
- **calc engine `@datacare/core`**: fineWeight=net*touch/100; metalAmount=fine*rate;
  labourCharge(per_gram|per_piece|percentage|fixed); lineNet=metal+labour+other; billTotals(net→
  discount→tax=taxable*pct/100→half-up round→total); gstSplit(CGST=tax/2,SGST=tax−CGST | IGST).
- **stock.ts** presence-model TAG_STOCK; issue=DELETE, restore=INSERT; BAR_DETL on-hand read.

Frontend pages: `txn/sales` (book/year/lc/party/name/tax%/disc/interstate + settlement
cash/card/upi/cheque + single old-gold row + item grid item/tag/pcs/gross/net/touch/rate/making/g),
`txn/hallmark-sale` (itCode/huid/metalAmount only), `txn/labour-sale` (labourType/net/pcs/value/metalAmt),
`txn/sale-return` (itCode/metalAmount only), `txn/sales-order` (single amount + advance).
All identifiers are typed free-hand — no master lookups, no rate fetch, no F-keys, no barcode.

GST inter/intra is a **manual checkbox**; tax% is a **single manual field**; making is **per-gram only**
in the main UI. labourType variety exists in calc but only the labour-sale page exposes it.

---

## 2. TR_SALE.cs (flagship retail sale) — DEEP DIVE

**Voucher tables:** SL_DATA (header), SL_DETL (metal/item lines), SL_IDTL (tag sub-detail),
SL_PR_DETL (old-gold/purchase-against-sale), UPI_DATA (multi-UPI split), SL_ORD_ADJ (advance adj),
COMM_DATA (member commission). Posting → AC_DATA, ROJMEL, TAX_DATA, MAIN_STOCK, DELETE_DATA(on del).

**SL_DATA header columns** (reconstructed from Ac_Ledr/Ac_Tax SELECTs): CO_CODE,LC_CODE,CO_YEAR,
CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,AC_CODE,AC_NAME,NET_AMT,DISC_AMT,TAX_CODE,TAX_AMT,
CGST/SGST/IGST,TCS_CODE/TCS_AMT,TDS_CODE/TDS_AMT,HM_AMT,HM_TAX_CODE,HM_TAX_AMT,OTH_AMT,OTH_TAX_CODE,
OTH_TAX_AMT,LBR_AMT,ROF_AMT,KASAR_AMT,POINT_VAL,SCHM_AC,SCHM_AMT,CASH_AMT,CASH_PAID,CARD_AC,CARD_AMT,
CARD_ADJ,CHQ_NO,BANK_AC,CHQ_AMT,TOT_AMT,BILL_OS,RATE_UNFIX,ZERO_RATED_AMT,HD_VCH_NO,MAIN_USER.

**Operator input fields/controls:** Book, Bill date, Customer (lookup → AC_MAST, shows balance/
GST type/state), then a multi-row item grid per line: IT_CODE (item lookup), TAG_NO (tag/barcode
scan → auto-fills wt from BAR_DETL), DESIGN_NO, PCS, GROSS_WT, less-wt, NET_WT, TOUCH%, WASTAGE%
(ITM_WEST_PRC), FINE, metal RATE, making LBR_RATE+type, OTH_AMT, ITM_MRP, ITM_SIZE, GHAT%, HUID,
discount per line. Footer: discount, scheme redeem, points redeem, multi-tender (cash/card/UPI×n/
cheque/old-gold/advance-adjust), kasar, round-off, TCS/TDS.

**Computation formulas (evidence: TR_SALE.cs + engine):**
- Rate auto-fetched from RATE_MAST by date+group (GR_RATE; FINE_GL_RATE/FINE_SL_RATE) — lines
  7561, 12547, 12854, 20837. Operator need not type rate.
- Fine = NET_WT × (TOUCH + WASTAGE%)/100 (wastage adds to fine — desktop has ITM_WEST_PRC; web has NO wastage).
- Metal amount = fine × rate (or NET_WT×rate for some groups; RATE_TYPE governs cost basis 'P').
- Making (LBR_AMT) by type: per-gram, per-piece, %-of-metal, fixed, or per-fine.
- Line NET_AMT = metal + making + OTH − line discount.
- Bill: NET_AMT − DISC_AMT = taxable; TAX_AMT by TAX_MAST; CGST=SGST=TAX/2 or IGST (by customer
  AC_GST_TYPE); + HM_AMT/HM_TAX, OTH/OTH_TAX, TCS; − scheme/points/kasar; ROF round-off; TOT_AMT.
  BILL_OS = TOT_AMT − tenders.
- Old gold given by customer: SL_PR_DETL, fine=net×touch/100, reduces balance, adds metal stock IN.

**SAVE workflow (TR_SALE.cs ~16100-16140 / 20730-20740):** validate → allocate VCH_NO → INSERT
SL_DATA/SL_DETL/SL_IDTL/SL_PR_DETL/UPI_DATA (+SL_ORD_ADJ if order linked) → `Ac_Ledr.Sales_Ledr` →
`Ac_Rojmel.Sales_Rojmel` → `Ac_Tax.Sales_GST` → `Ac_Stock.Sale_Stk` → `Ac_Stock.Dm_Sale_Detl`
(diamond) → `Ac_Tax.Vch_Remark` → tag stock out / weight-diff → loyalty points accrue (MS_POINT) →
scheme adjust → print (CUSTOMER COPY + ACCOUNT COPY, lines 16538-16562) → optional e-invoice/IRN
(UT_E_INVOICE.cs / TR_SL_EBILL.cs) → optional WhatsApp/SMS bill. All in Module_Save.SlTran transaction.

**Validations/guards:** customer required & active; credit-limit check; tag must be in stock (BAR_DETL)
& not already sold; net/fine > 0; rate present (or RATE_UNFIX flag set for rate-cut); tax code resolved;
multi-tender total ≤ total (else BILL_OS); voucher-date within open period; duplicate bill guard;
HUID 6-char for hallmarked gold; round-off within limit.

**Special features:** F-key driven entry (lookups, add-line, save), barcode/tag scan auto-fill,
multi-tender incl multiple UPI rows, old-gold exchange, scheme redemption, loyalty points,
order-advance adjustment, diamond detail, SL/tag weight-difference capture, customer & account
print copies, e-invoice/IRN, WhatsApp/SMS send, B2B (premium PRM_AMT) variant.

---

## 3. OTHER FORMS (posting delegations confirmed)

- **TR_SALE_HM.cs (Hallmark sale)** — SAME engine as TR_SALE (Sales_Ledr/Sales_Rojmel/Sales_GST/
  Sale_Stk/Dm_Sale_Detl, lines 11639-11686, 15275+). Adds per-line HUID capture + HM_AMT/HM_TAX
  (hallmarking charge taxed separately). Web hallmark-sale only posts metalAmount + huid string.
- **TR_SALE_RTN.cs (Sales return)** — `SaleReturn_Ledr` / `SaleReturn_RojMel` / `SaleReturn_Stk` /
  `Sales_Rtn_GST` / `Dm_Sale_Return_Detl` (lines 13411-13463). Uses RTN_NET_AMT/RTN_TOT_AMT, reverses
  stock IN, reverses GST (TAX_SIGN '-'), links to original bill. Web does AC_DATA + SL_DETL_RTN only,
  no TAX_DATA reversal, no MAIN_STOCK, no original-bill item pull.
- **TR_SALE_LBR.cs (Labour/job sale)** — DISTINCT engine `Labour_Ledr`/`Labour_RojMel`/`Labour_Stk`/
  `LbrWork_GST`/`Dm_Sale_Lbr_Detl` (9733-9747). Writes LBR_DATA with DR_LBR, LBR_TAX_AMT, LBR_DISC_AMT,
  OTH_DR_AMT, SL_NET_AMT; stock issue/receive of metal for jobwork. Web routes labour through the
  generic /sales (computeLine labour types) — no LBR_DATA, no jobwork metal in/out.
- **TR_SALE_ORD.cs (Sales order)** — `Order_Ledr`/`Order_Rojmel`/`Order_Stk` (9560-9567). Orders DO
  touch stock (Order_Stk blocks/reserves) and post advance ledger; multi-line SL_ORD_DATA/DETL/IDTL
  with design, weights, making, delivery date, advance. Web sales-order is a single amount + advance,
  one ledger pair, no stock reservation, no line designs.
- **TR_SALE_RTN_UAE.cs** exists (VAT variant) — out of group scope but shows multi-jurisdiction.

---

## 4. GAP TABLE  (feature | desktop behavior | web status | impact)

| # | Feature | Desktop behavior (evidence) | Web status | Impact |
|---|---------|------------------------------|------------|--------|
| 1 | **Metal fine-weight ledger (dual accounting)** | AC_DATA carries FINE_WT/FINE_RATE/IT_TYPE/SIGN; leg '38' posts ITM_FINE metal-out per line (Ac_Ledr.cs) | **MISSING** | CRITICAL — no metal balance/fine ledger; gold-weight trial balance impossible |
| 2 | **Full ledger decomposition (~39 legs)** | Ac_Ledr.Sales_Ledr posts customer/sales-by-group/GST/HM/TCS/TDS/cash/card/UPI/cheque/scheme/points/kasar/disc/round/old-gold/order-adv | **PARTIAL** (cust, sales, GST, round, cash/bank/oldgold only) | CRITICAL — GL wrong for any bill with HM/TCS/TDS/scheme/points/multi-UPI/order-adv |
| 3 | **GST from customer master state** | inter/intra from AC_MAST.AC_GST_TYPE; CGST=SGST=TAX/2 or IGST; TAX_PRC/TAX_GROUP from TAX_MAST (Ac_Tax.cs:77) | **PARTIAL** (manual interState bool + manual tax%) | HIGH — wrong tax when operator forgets toggle; no per-item HSN/slab |
| 4 | **Per-item tax / HSN / multi-slab** | TAX_CODE per item via TAX_MAST, multiple SR_NO rows, HM_TAX & OTH_TAX separate | **MISSING** (one bill-level %) | HIGH — multi-rate bills (e.g. 3% gold + 5% making) impossible |
| 5 | **Rate auto-fetch from RATE_MAST** | SELECT GR_RATE/FINE_GL_RATE/FINE_SL_RATE by date+group (TR_SALE.cs 7561,12547,20837) | **MISSING** (operator types rate) | HIGH — slow, error-prone, no daily rate governance |
| 6 | **Customer master lookup** (balance, GST type, credit limit, address) | AC_MAST lookup drives GST/limit/print | **MISSING** (free-text AC_CODE) | HIGH — no validation, no credit control, GST type unknown |
| 7 | **Item/tag master lookup + barcode scan auto-fill** | TAG_NO → BAR_DETL auto-fills wt/touch/fine/MRP; ITEM_MAST lookup | **MISSING** (typed itCode/tagNo) | HIGH — core POS speed/accuracy feature absent |
| 8 | **Wastage % (ITM_WEST_PRC)** | fine includes wastage; west% per line; KR_WEST | **MISSING** | HIGH — under-charges metal; standard jewellery pricing lever |
| 9 | **MAIN_STOCK full footprint** | ~50 cols, 6-8 legs incl tag-vs-actual weight-diff (SR7/8), karigar, MRP, design, size, lot, ghat, ISU/ORD reversal (Ac_Stock.cs:98) | **PARTIAL** (1 leg, ~10 cols) | HIGH — stock valuation/movement reports inaccurate |
|10 | **Multi-tender incl multiple UPI rows** | CASH/CARD/CHQ + UPI_DATA n-rows + CASH_PAID change + CARD_ADJ (Ac_Ledr legs 15-18,25-30,36-37) | **PARTIAL** (cash/card/upi/cheque single amounts; bank lumped) | HIGH — cannot split UPI refs; card/cheque not to distinct ledgers |
|11 | **Old-gold exchange (multi-line)** | SL_PR_DETL n-rows, fine, PURC_AC posting, stock IN, balance offset (Ac_Ledr 23/24, Ac_Stock SR4) | **PARTIAL** (1 old-gold row, no PURC_AC leg) | MEDIUM-HIGH — common at counter; valuation/GL incomplete |
|12 | **Loyalty points (accrue + redeem)** | POINT_VAL leg 31/32; MS_POINT module | **MISSING** | MEDIUM-HIGH — retail loyalty unsupported |
|13 | **Scheme redemption** (chit/SIP) | SCHM_AMT/SCHM_AC legs 19/20; Module_Schm/BtmSchm | **MISSING** | MEDIUM-HIGH — scheme installments can't settle bills |
|14 | **Hallmark charge + HUID (HM_AMT/HM_TAX)** | separate HM_AMT taxed via HM_TAX_CODE; HUID per line (TR_SALE_HM) | **PARTIAL** (huid string only, no HM charge/tax) | MEDIUM-HIGH — HUID compliance + hallmark billing |
|15 | **TCS / TDS** | TCS_AMT leg 10, TDS legs 13/14 via TAX_MAST | **MISSING** | MEDIUM — high-value bills (>₹2L) legally need TCS |
|16 | **Round-off & Kasar** | ROF_AMT signed leg 35; KASAR_AMT leg 31 | **PARTIAL** (round-off in totals; no kasar, no ROUNDOFF split both signs) | MEDIUM |
|17 | **Sales return: GST reversal + stock IN + orig-bill pull** | Sales_Rtn_GST (TAX_SIGN '-'), SaleReturn_Stk, RTN_NET/RTN_TOT, link orig bill | **PARTIAL** (ledger reverse + SL_DETL_RTN; no TAX_DATA, no MAIN_STOCK, no orig pull) | HIGH — GST returns & stock wrong |
|18 | **Labour/jobwork sale (LBR_DATA)** | distinct Labour_Ledr/Labour_Stk/LbrWork_GST; metal issue+receive, DR_LBR/LBR_TAX/OTH_DR | **MISSING** (routed through generic sale) | HIGH — jobwork accounting & metal flow absent |
|19 | **Sales order: stock reservation + multi-line** | Order_Stk reserves; SL_ORD_DATA/DETL/IDTL designs/weights/delivery/advance | **PARTIAL** (amount + advance only) | MEDIUM-HIGH — order book not actionable |
|20 | **ROJMEL (day/cash book) posting** | Ac_Rojmel.Sales_Rojmel every sale | **MISSING** | MEDIUM — cash-book/day-book report gap |
|21 | **e-Invoice / IRN (GST e-invoicing)** | UT_E_INVOICE.cs / TR_SL_EBILL.cs generate IRN+QR | **MISSING** (einvoice module stub only) | MEDIUM-HIGH — B2B legal requirement |
|22 | **Print: Customer + Account copies** | MaPirntCopy CUSTOMER/ACCOUNT COPY (16538-16562); Crystal layouts | **PARTIAL** (one generic HTML/PDF) | MEDIUM |
|23 | **WhatsApp/SMS bill send** | Module_WhatsApp/UT_SMS after save | **MISSING** | MEDIUM |
|24 | **F-key keyboard workflow** | F-keys for lookup/add-line/save/print | **MISSING** | MEDIUM — counter speed |
|25 | **SL/Tag weight-difference capture** | MsSlAndTagWtDiff → MAIN_STOCK SR7/8 variance | **MISSING** | MEDIUM — shrinkage/variance tracking |
|26 | **Diamond/stone detail (Dm_Sale_Detl)** | per-stone pcs/cts/rate detail table | **MISSING** | MEDIUM — diamond jewellers |
|27 | **BILL_OS_DATA outstanding tracking** | desktop writes OS with REC/KASAR | **PARTIAL** (basic OS row) | MEDIUM |
|28 | **RATE_UNFIX / rate-cut sales** | unfixed-rate income path (Ac_Ledr RATE_UNFIX branch) | **MISSING** | LOW-MEDIUM — wholesale/rate-cut |
|29 | **B2B premium (PRM_AMT/PRM_DISC)** | B2B_Sales_Ledr premium legs | **MISSING** | LOW-MEDIUM |
|30 | **Voucher remark + audit (VCH_TIME/MAIN_USER/HD_VCH_NO)** | Vch_Remark + per-row user/time/header-vch | **PARTIAL** | LOW-MEDIUM — audit trail |

---

## 5. PRIORITIZED IMPLEMENTATION ORDER (for true parity)

P0 (correctness of money & metal): #1 fine-weight ledger, #2 full ledger legs, #3/#4 tax from
master + per-item slabs, #17 return GST+stock, #9 MAIN_STOCK footprint, #20 ROJMEL.
P1 (counter usability & pricing): #5 rate auto-fetch, #6 customer lookup+credit, #7 item/tag/barcode,
#8 wastage, #10 multi-tender/UPI, #18 labour LBR_DATA, #14 hallmark charge.
P2 (retail programs & compliance): #11 old-gold, #12 points, #13 scheme, #15 TCS/TDS, #21 e-invoice,
#19 order reservation.
P3 (polish): #22 print copies, #23 WhatsApp/SMS, #24 F-keys, #25 wt-diff, #26 diamond, #16 kasar/round.
