# GAP — Transaction Module (Web ⇄ Desktop parity)

> Goal: enumerate every difference so `web` can function EXACTLY like the DataCareNext desktop
> (per `project-memory/video-research/_kb/KB_transaction.md`). Each screen: **Desktop spec → Web now
> (cited) → GAPS → Fill plan → Priority/Effort**. Analysis only — no application code changed.
>
> Sources read: KB_transaction.md (full); web pages `web/apps/web/app/(app)/txn/*/page.tsx` +
> `components/PaymentForm.tsx`; API modules `sales/sales.ts`, `sales/salesReturn.ts`,
> `sales/salesOrder.ts`, `purchase/purchase.ts`, `purchase/purchaseReturn.ts`, `finance/finance.ts`,
> `finance/billToBill.ts`, `tour/tour.ts`, `posting/posting.ts`; routes `api/src/routes/txn.ts`.

## Cross-cutting facts (verified — apply to all screens)
- **Posting engine = MATCH.** `posting/posting.ts` `postVoucherTx` asserts `ΣDR=ΣCR` (`assertBalanced`),
  stamps `LEDR_KEY`/`DATA_TYPE='A'`/`LD_CODE`/`BOOK_NAME` (`enrichLedgerLine`), writes all satellite
  tables + `AC_DATA` in one tx; `reverseVoucherTx` deletes by voucher key + writes `DELETE_DATA`.
- **Period lock = MATCH.** `assertPeriodOpen` reads `CO_SET.LOCK_DATE` and throws
  `PeriodLockValidationError` for dates on/before the lock (opt-in). `fine = netWt×touch/100` implemented
  in every module (`lineFine`/`computeLine`).
- **Global UI chrome = GAP (all screens).** No voucher-header pattern is rendered anywhere: no `Vch No`
  (shown only *after* save), no `Vch Date`+time+weekday, no `Ref No`, no `Print` template dropdown +
  `Set`, no bottom action bar `◀ ▶ Print Save Cancel Delete Exit`, no status bar (Live Rate / Fine
  Gold / Fine Silver / Rate Date). No `F1/F2/F3/F12` keyboard workflow, no Enter-walk, no Esc-to-tender.
  These recur per screen below but are noted once here as a shared P1/P2 UX layer.
- **Delete/edit from UI = GAP (all screens).** Every module exports a `delete*`/reverse (wired as
  `DELETE /…/:vchNo` in `txn.ts`), but **no web page exposes edit/delete/navigate (◀▶)** — pages are
  create-only. Shared P1.

---

## 1 · Sales Invoice — `/txn/sales`  (`sales/page.tsx` + `sales/sales.ts`, `POST /sales`)

**Desktop spec (KB §1):** Gold/Silver Tax Invoice book chooser; header `Vch No·Vch Date·Apr No·Ref No·
Party (default AC 45 Cash Sales)·Print`; 18-col item grid; **two sub-grids** (charges HM/RD → OthAmt;
old-gold URD-in); **16-row tender panel**; writes SL_DATA/SL_DETL/SL_IDTL/SL_PR_DETL/MAIN_STOCK
(TGSL−, MIXSL+)/TAX_DATA/BILL_OS_DATA + balanced AC_DATA SALE.

**Web now:** `sales/sales.ts` `createSale()` is a **strong service-layer match** — voucher numbering,
per-tag `issueTagTx` (double-issue guard), `billTotals` GST split, per-group income legs via
`GROUP_MAST.SALE_AC` (`buildIncomeLegs`), hallmark (HMCHRG + its GST), TCS, kasar, multi-tender
(cash/card/upi/cheque/oldGold), old-gold-in (SL_PR_DETL `SLOG` + MAIN_STOCK `MIXSL +`), and writes
SL_DATA/SL_DETL/SL_IDTL/MAIN_STOCK(`TGSL`,`-`)/TAX_DATA(CGST+SGST | IGST + HM rows)/BILL_OS_DATA + a
balanced `AC_DATA` `SALE`; `deleteSale()` reverses all + restores tags + DELETE_DATA. The **page**
(`sales/page.tsx`) renders: header row (Book/Year/Location/Party/Customer Name/Tax %/Discount/
Inter-state), a Settlement panel (Cash/Card/UPI/Cheque/Hallmark chg/TCS %/Kasar), an Old-Gold/Silver
exchange grid (Metal/Item/Pcs/Gross/Net/Touch%/Rate/Amount), Totals tiles, and an Items grid
(Item/Tag/Pcs/Gross/Net Wt/Touch%/Rate/**Making/g**/Fine/Amount). Save → "View Invoice PDF"
(`/api/sales/invoice`).

**GAPS**
- *Header fields missing:* `Apr No` (+`A` button — pull an Approval into the bill; verified **no**
  `aprNo`/`APR_NO` anywhere in API), `Ref No` (printed bill serial e.g. `T1-00001`), `Vch Date`+time+
  weekday, **`Print` template dropdown (`SalesBillA4Gst`) + `Set`**. Default party is `WALKIN`, not the
  desktop **AC 45 = Cash Sales**. No Gold/Silver **book chooser**.
- *Item grid columns missing:* `Design`, `Size`, `LsWt` (less-wt shown separately in desktop), split
  `ItRate`/`ItAmt`, **`Lbr%` + `LbrRate` + `LbrAmt`** (web collapses labour to one `Making/g` = per-gram
  only; desktop supports **`Lbr%` percentage** and a rate), per-line `OthAmt`, `TotAmt`, per-line `Tax%`
  and `NetAmt`. No `Print Name` field, no bottom running totals `P=/G=/N=`.
- *Charges/labour sub-grid missing (KB §1.4A):* cols `Sr·ItCode·ItName·Pcs·Weight·Con%·P/W·Rate·ItAmt·
  NetAmt` (rows like `HM·HALL MARK CHARGES·300`, `RD·RODIAM CHARGES·500`) whose Σ → `OthAmt`/`Other
  Charg`. Backend only has a **scalar** `otherAmount` per line + a scalar `hallmarkAmount`; no charges
  line-items persisted.
- *Tender panel rows missing (KB §1.5, 16 rows):* **`Order Amt` / `Ord No`** (advance adjust), **`Old
  Silver Amt`** (separate from Old Gold), **`Scheme Amt`**, **`Cash Paid Amt`**, visible `Rof Amt`,
  **`Bank`** deposit-bank dropdown (which bank the cheque/card lands in — web sends a single default
  `bankAc='BANK'`), **`Employe`** (EMP_MAST 001), **`CrDay`/`CR Days`**, **`Vch Desc`**.
- *Cross-module effects missing:* **Sales-Order advance adjust** — `createSale` has no `ordNo/orderAmt`
  and **never reads/writes `SL_ORD_ADJ`** (verified: `SL_ORD_ADJ` absent from API). **CrDays reminder**
  not raised on save. **PAN gate** on a cash bill over `CO_SET.CASH_LIMIT` not enforced in `createSale`
  (only `finance.ts` payments call `assertCashLimit`).
- *UX:* no barcode-scan→autofill+photo, no zoomable item photo, no F1 inline party/item create.

**Fill plan**
- Frontend `sales/page.tsx`: add header fields (`refNo`,`aprNo`, print-template select, vchDate);
  expand the item grid to the full 18 columns incl. `Lbr%`+`LbrRate`+`LbrAmt`, `Design`, `Size`,
  `LsWt`, per-line `OthAmt`; add the **Charges sub-grid** and wire its Σ into each line's `otherAmount`;
  add tender rows `Order Amt/Ord No`, `Old Silver Amt`, `Scheme Amt`, `Cash Paid Amt`, `Bank` picker,
  `Employe`, `CR Days`, `Vch Desc`.
- Backend `sales/sales.ts`: extend `SaleInput`/`SaleLineInput` with `charges[]` (persist to a charges
  detail table / fold into `OthAmt`), `oldSilver[]` (mirror `oldGold` with `IT_TYPE='S'`), `schemeAmt`,
  `crDays`→BILL_OS due, `empCode`, `bankAc` per-tender; add `orderRef {ordNo, adjustAmt}` →
  write `SL_ORD_ADJ` + Dr the order-advance ledger against the bill; add PAN gate on cash-over-limit;
  raise a reminder row when `crDays>0`. Wire new body fields in `POST /sales` (`txn.ts`).
- **Priority P0** (Order Amt adjust — breaks Sales-Order fulfilment) + **P1** (Apr No, charges sub-grid,
  Lbr%/Old Silver/Scheme, print template). **Effort L.**

---

## 2 · Cash Received / Cash Payment — `/txn/receipt`, `/txn/payment`  (`PaymentForm.tsx` + `finance/finance.ts`)

**Desktop spec (KB §2):** mirror money-in/out; **multi-line grid** `Sr·AcCode·Ac Name·Amount·Kasar`
(one voucher pays several heads), `It Desc`, `Employe`; Save→Original/Duplicate/Triplicate print.
Cash-receipt ceiling (no PAN escape); CASH_DATA/PAY_DATA + AC_DATA (CREC/CPAY).

**Web now:** `finance.ts` `postReceipt` (Dr CASH/Cr party `CREC` + `CASH_DATA`, cash-receipt ceiling via
`assertCashReceiptCeiling`, kasar) and `postPayment` (Dr party/Cr CASH `CPAY` + `PAY_DATA`, kasar,
`assertCashLimit` PAN gate) — **service = match**. Both pages are the shared `components/PaymentForm.tsx`:
a **single** party + single `amount` + `mode` + `bankAc` + `chqNo` + `pan` + `kasar` (+ card/upi detail).

**GAPS**
- **Single-line only.** Desktop is a **multi-line grid** (e.g. one Cash Payment paying `OFFICE EXPENSES
  3000` **and** `PETROL & VEHICAL EXP 2000`). `postReceipt`/`postPayment` accept exactly one
  `partyAc`+`amount`; no line array. (`PAY_DETL` exists in the appendix but is never written.)
- Missing **`It Desc`** (narration) and **`Employe`** fields.
- Missing **Original/Duplicate/Triplicate print dialog** + receipt View/Print.
- No `Vch No`/`Vch Date`+time+weekday shown; Cash Payment has no pre-seeded default expense heads
  (Shop/Office/Electricity/Petrol) — operator must type an `AcCode`.

**Fill plan**
- Backend: add `postReceiptLines`/`postPaymentLines` (or extend inputs) accepting
  `lines:[{acCode, amount, kasar, itDesc}]`, posting one Dr/Cr per line into a single balanced voucher +
  `PAY_DETL`/multi-row `CASH_DATA`; keep the ceiling/PAN checks on the cash total.
- Frontend: replace the single amount with a line grid (AcCode picker/Amount/Kasar/It Desc) + `Employe`;
  add a print-copies dialog reusing `/render/pdf`.
- **Priority P1** (multi-line behaviour) / **P2** (It Desc, Employe, print). **Effort M.**

---

## 3 · Sales Return (Credit Note) — `/txn/sale-return`  (`sale-return/page.tsx` + `sales/salesReturn.ts`)

**Desktop spec (KB §3):** pick original **Sale Bill** (picker VchNo/Date/Party/Book/BillAmt) → **imports
all lines**; prompt barcode-reuse vs new tag; **Receive-Item re-stock sub-grid** (editable `TagLRate`,
MRP); refund via Cheque/Card/Cash **or** credit the party; writes SL_DATA+SL_DETL_RTN+MAIN_STOCK(`CRNOT`
+)+AC_DATA+TAX_DATA(reverse)+BILL_OS_DATA.

**Web now:** `salesReturn.ts` `createSaleReturn` writes SL_DATA(`SRTN`)+SL_DETL_RTN+MAIN_STOCK(`GSRTN`,
`TR_TYPE 'I'`,`+`)+TAX_DATA(`SR`,`TAX_SIGN '-'`), re-creates each tag (`createTagTx`), posts reverse
ledger **Dr SALES+GST / Cr customer** (`buildReturnLedger`). Page: header (Book/Year/Party/Customer
Name/**Orig Bill No** free-text/Tax %/Discount/Inter-state) + one Returned-Items grid
(Item/Tag/Pcs/Gross/Net Wt/Touch%/Rate/Making/g/Fine/Amount).

**GAPS**
- **No Sale-Bill import picker** — desktop has the 3-box bill-no (`00002·2021-2022·026`) + `S` button and
  a picker that **imports every original line**. Web offers only a free-text `Orig Bill No` (passed as
  `billNo`); nothing is imported.
- **No barcode reuse / generate-new-tag prompt** on import.
- **No Receive-Item re-stock sub-grid** (KB §3.2: `Sr·RecCode·TagNo·Receive Item·Counter·Design·Size·
  Pcs·GrWt·OthWt·NetWt·Rate·ItAmt·Lbr%·Ltype·LRate·LAmt·OthAmt·Tag%·TagLRate·TagLAmt`) with editable
  **`TagLRate`** (600→700) and **MRP** for the re-stocked item.
- **No charges sub-grid** (`Sr·ItCode·ItName·Pcs·KrWt·Weight·Con%·P/W·Rate·ItAmt·NetAmt`).
- **No refund-vs-credit tender panel** (`Cheque/Card/Cash Amt·Kasar·Os Amt`). `buildReturnLedger` has
  **only** the credit-the-party path (Cr customer); a **refunded** return (Dr customer / Cr Cash/Bank)
  is unsupported.
- **No `BILL_OS_DATA` adjustment** on create (KB §3.4 lists it; module writes none).
- Stock `VCH_TYPE` naming: web `GSRTN` vs KB `CRNOT` (verify downstream Tag-Stock "In Tag" report keys).

**Fill plan**
- Backend: add `importFromBill(coBook,vchNo)` returning original SL_DETL lines; add `receiveItems[]`
  (re-stock grid → `createTagTx` with new `TagLRate`/MRP or reuse barcode); add optional refund tender
  (`cashAmt/chequeAmt/cardAmt/bankAc`) → Dr customer / Cr cash-bank legs; write `BILL_OS_DATA` adjust.
- Frontend `sale-return/page.tsx`: add a bill picker (calls the import endpoint), the receive-item grid,
  the refund tender panel, and the barcode-reuse prompt.
- **Priority P0** (import-from-bill is the core workflow) + **P1** (receive-item grid, refund tender).
  **Effort L.**

---

## 4 · Bank Received / Bank Payment — `/txn/receipt`, `/txn/payment` (bank)  (`PaymentForm.tsx` + `finance/finance.ts`)

**Desktop spec (KB §4):** mirror of §2 but settled through **per-bank Books** (HDFC/ICICI Rec & Pay,
created in Company→Books with `Transaction=BANK REC/PAY` + default `BANK A/C`/`KASAR`/`BANK CHARGES`
legs); grid adds a **`Chq No`** column; Bank Payment adds **`Chq Print`** + a `Chq` cheque-print action.

**Web now:** `PaymentForm` supports `mode=bank|cheque|card|upi` with a `bankAc` lookup; `postReceipt`/
`postPayment` route `recAc/payAc = bankAc`, stamp `BREC`/`BPAY`, write CASH_DATA/PAY_DATA (+CARD_DATA/
UPI_DATA on card/upi). **Service = match.**

**GAPS**
- **No per-bank Book concept.** Desktop makes each bank its own Received/Payment book with default
  KASAR/BANK-CHARGES legs; web has **no Book master** and just picks a `bankAc` lookup — no default-leg
  mapping, no book chooser, no `BREC`/`BPAY` book management.
- **Single-line** (shares §2 gap) — no multi-line grid; the desktop **`Chq No` grid column** is only a
  single `chqNo` field (cheque mode).
- **No `Chq Print` field / cheque-print action** on Bank Payment.
- No `It Desc`/`Employe`, no print dialog.

**Fill plan**
- Add a Book master (Company→Books) with per-bank REC/PAY books + default legs; let the page pick the
  bank book (drives `bankAc` + default kasar/charges). Add multi-line grid with a `Chq No` column
  (shared with §2). Add a cheque-print template (e.g. `ChqPrint135.rpt`) behind a `Chq` action.
- **Priority P1** (per-bank book, multi-line+Chq No) / **P2** (cheque print). **Effort M–L.**

---

## 5 · Sales Order — `/txn/sales-order`  (`sales-order/page.tsx` + `sales/salesOrder.ts`)

**Desktop spec (KB §5):** records a customer order (no income); item grid like sale + charges + old-gold
sub-grids; advance panel `Cash/Cheque/Card/Old Gold/Old Silver/Scheme/**Tot Adv Amt**`; delivery date;
writes SL_ORD_DATA/SL_ORD_DETL/SL_ORD_IDTL/SL_ORD_ADJ (+advance AC_DATA `SORD`).

**Web now:** `salesOrder.ts` `createSalesOrder` writes SL_ORD_DATA (NET/TAX/TOT/**ADV_AMT**/DEL_DATE
column present) + SL_ORD_DETL (with `DESIGN_NO`,`ITM_REMARK`) + SL_ORD_IDTL; posts advance **Dr CASH /
Cr customer** (`SORD`) only when `advanceAmount>0`; `cancelSalesOrder` guards on
`DESIGN_ISU/TAG_GEN/TAG_SALE`; `GET /sales-orders` lists. Page: header (Customer/Customer Name/Tax %/
**Advance ₹** single) + grid (Item/Design/Pcs/Gross/Net/Touch/Rate/Making/g/Net Amt/Remark) + Recent
Orders list.

**GAPS**
- **Advance is a single amount.** Desktop splits it by mode: `Cash Amt/Cheque Amt/Card Amt/Old Gold Amt/
  Old Silver Amt/Scheme Amt/Tot Adv Amt`. Backend only takes `advanceAmount` → Dr CASH; no per-mode
  advance, no bank leg, no old-gold-in on the order.
- **No old-gold sub-grid** (`Sr·ItCode·ItName·Pcs·GrWt·NetWt·Touch·Fine·Rate·NetAmt`) — needed to seed
  the Labour Invoice **order-gold credit** (§10).
- **No charges sub-grid**; item grid missing `Size`, `LsWt`; no per-line `Tax%`.
- **No delivery-date field** on the page (backend column `DEL_DATE` exists but the page never sends it;
  `listSalesOrders` returns `delDate`).
- No `All` history button, `Ref No`, `Employe`, `Bank`, photo/scan; no Order Report (Order / Order
  Advance / Order Adjust) views.
- **Consumption by Sales:** the order advance is never adjusted into an invoice — no `SL_ORD_ADJ`
  read/write anywhere (cross-ref §1). This makes orders un-fulfillable end-to-end.

**Fill plan**
- Backend: extend `SalesOrderInput` with `advance:{cash,cheque,card,oldGold,oldSilver,scheme}` +
  `bankAc` (post the correct advance legs), `oldGold[]` sub-grid, `delDate`; add `adjustOrderIntoSale`
  writing `SL_ORD_ADJ` (consumed by `createSale`).
- Frontend: split advance by mode, add old-gold + charges sub-grids, delivery-date, Size/LsWt columns.
- **Priority P0** (SL_ORD_ADJ into sale, shared with §1) + **P1** (advance-by-mode, old-gold sub-grid,
  delivery date). **Effort M.**

---

## 6 · Purchase — `/txn/purchase`  (`purchase/page.tsx` + `purchase/purchase.ts`)

**Desktop spec (KB §6):** 4 books (Gold/Gold-URD/Silver/Silver-URD); header +`Sl Bil No`/`Item Wt`; grid
`Sr·ItCode·ItName·Pcs·GrWt·OthWt·NetWt·Touch·West%·Fine·Rate·ItAmt·Ltype·LRate·LAmt·OthAmt·TotAmt`;
**tender panel** (cheque/card/cash/kasar/Os + bank); **Only Tag Entry** inline tagging (QR labels);
writes PR_DATA/PR_DETL/PR_IDTL/MAIN_STOCK(`TGPR +`)/TAX_DATA(input)/BILL_OS_DATA.

**Web now:** `purchase.ts` `createPurchase` = **strong service match** — Cr supplier / Dr PURCHASE
(per-group `GROUP_MAST.PURC_AC` via `buildExpenseLegs`) / Dr GSTINPUT / Dr ROUNDOFF, a **metal fine
sub-ledger leg** (`IT_TYPE 'G'/'S'`, `SIGN '+'`, `FINE_WT`), hallmark purchase, `createTagTx`
(`STK_TYPE 'R'`), MAIN_STOCK `TGPR +`, TAX_DATA(input `TAX_SIGN '-'`), BILL_OS_DATA; `deletePurchase`
reverses + removes tags. Page: header (Book/Year/Location/Supplier/Supplier Name/Bill No/Tax %/Discount/
Inter-state) + Items grid (Item/Tag/Pcs/Gross/Net Wt/Touch%/Rate/Making/g/Fine/Amount). **No tender/
settlement panel** — only computed Taxable/Tax/Total is shown.

**GAPS**
- **No purchase settlement.** Desktop settles the supplier (cheque via HDFC/card/cash/kasar → `Os Amt`).
  Neither the page nor `createPurchase` accepts `cashAmt/chequeAmt/cardAmt/kasar/bankAc` (unlike
  `createSale`). Purchase is always booked as full payable — cannot record the payment shown in-video.
- *Item grid columns missing:* `OthWt` (stone/other wt — web only Gross/Net), **`West%`** (wastage —
  affects fine), split `Ltype/LRate/LAmt` (web single `Making/g`), per-line `OthAmt`, `TotAmt`. No
  **stone/diamond weight detail box** on `GrWt`.
- **No 4 books / URD path.** No Gold-URD/Silver-URD; **no URD / reverse-charge** handling for
  unregistered-dealer old-metal. `coBook` is free text `'PUR'`.
- **No `Only Tag Entry` inline tagging screen** (KB §6.2): convert a loose purchased lot into barcoded
  tags — cols `Sr·ItCode·TagNo·Counter·Design·Size·Pcs·GrWt·LsWt·NetWt·Lbr%·LbrRate·LbrAmt·OthAmt·
  PrCost·Mrp·Image·KrCode` + `Print file (QrPrint10)` + `Lable Skip` + charges sub-grid + QR-label
  print. Web can only attach a `tagNo` per line (no loose→tag conversion, no QR print).
- Missing header `Item Wt`, `Sl Bil No` (page has generic "Bill No"), `Kasar`, and no `Tcs`.

**Fill plan**
- Backend `purchase.ts`: add settlement inputs (`cashAmt/chequeAmt/cardAmt/kasar/bankAc`) + Cr cash/bank
  legs + `BILL_OS_DATA` REC_AMT, mirroring `createSale`; add `west%`/`othWt` to line calc & PR_DETL;
  add a URD/reverse-charge book variant.
- Add an **Only-Tag-Entry** service (loose-lot → `createTagTx` per piece with Design/Size/Mrp/KrCode) +
  QR label render (`QrPrint10`), and a page for it.
- Frontend `purchase/page.tsx`: add the tender panel + the extra grid columns + a book chooser.
- **Priority P0** (settlement panel) + **P1** (West%/OthWt/Ltype cols, URD books, Only-Tag-Entry).
  **Effort L.**

---

## 7 · Purchase Return (Debit Note) — `/txn/purchase-return`  (`purchase-return/page.tsx` + `purchase/purchaseReturn.ts`)

**Desktop spec (KB §7):** return to supplier; grid `Sr·TagNo·ItCode·ItName·Counter·Pcs·GrWt·OthWt·
NetWt·Touch·West%·Fine·Rate·ItAmt·Ltype·LRate·LAmt·OthAmt`; **refund tender** (`Cheque Amt` via HDFC →
`Os 0`) or credit supplier; writes PR_DATA/PR_DETL/MAIN_STOCK(`-`)/AC_DATA/TAX_DATA(reverse input)/
BILL_OS_DATA.

**Web now:** `purchaseReturn.ts` `createPurchaseReturn` writes PR_DATA(`PRTN`)+PR_DETL+MAIN_STOCK(`PRTN`,
`TR_TYPE 'P'`,`-`)+TAX_DATA(`P`,`TAX_SIGN '+'`), reverse ledger **Dr supplier / Cr PURCHASE + Cr
GSTINPUT** (`buildPurchaseReturnLedger`), `issueTagTx` (removes tag). Page: header + one Returned-Items
grid (Item/Tag/Pcs/Gross/Net Wt/Touch%/Rate/Making/g/Fine/Amount).

**GAPS**
- **No refund-vs-credit tender panel.** `buildPurchaseReturnLedger` only Dr-supplier; a **refunded**
  return (supplier pays back by cheque → Dr Bank/Cash so `Os Amt=0`, KB §7.3) is unsupported.
- *Item grid columns missing:* `Counter`, `OthWt`, `West%`, `Ltype/LRate/LAmt`, `OthAmt`.
- **No `BILL_OS_DATA` payable adjustment** on create.
- No original-purchase reference/import.

**Fill plan**
- Backend: add refund tender (`chequeAmt/cardAmt/cashAmt/bankAc`) + Dr Bank/Cash legs; write
  `BILL_OS_DATA` adjust; add `west%`/`othWt`/`counter` to PR_DETL.
- Frontend: add refund tender panel + the extra columns.
- **Priority P1** (refund tender, item cols) / **P2** (BILL_OS adjust). **Effort M.**

---

## 8 · Contra Entry — `/txn/contra`  (`contra/page.tsx` + `finance/finance.ts` `postContra`)

**Desktop spec (KB §8):** cash↔bank transfer; **two-line grid** `Sr·Cr/Dr·AcCode·Ac Name·It Desc·CrAmt·
DrAmt` (Dr destination, auto-Cr source); DrAmt **must equal** CrAmt; writes CONTRA_DATA + AC_DATA (`JV`).

**Web now:** `postContra` writes CONTRA_DATA (`AC_CODE=toAc`,`LD_CODE=fromAc`,`DR_AMT`,`CR_AMT`,`JV`) +
Dr toAc / Cr fromAc; guards `fromAc≠toAc`, `amount>0` — **service = match**. Page: `From AC` / `To AC` /
`Amount` (three fields, prints raw JSON on success).

**GAPS**
- **No two-line Cr/Dr grid** with per-line `It Desc`; web abstracts it to From/To/Amount (functionally
  equal but not the desktop layout; can't add a narration per leg).
- **No client-side equal-amounts rule** display (backend uses one amount so it's inherently equal, but
  desktop lets you type CrAmt/DrAmt and validates equality).
- No `Vch No`/`Vch Date`, `Employe`, print dialog (Original/Duplicate/Triplicate). Success shows raw
  JSON instead of a receipt.

**Fill plan**
- Frontend `contra/page.tsx`: render the two-line grid (Dr line + auto Cr line) with `It Desc`, an
  equal-amounts check, and a proper saved-receipt view; optionally pass `itDesc` to a CONTRA_DATA column.
- **Priority P2** (works today; this is layout/parity polish). **Effort S.**

---

## 9 · Approval Issue / Return (Tour) — `/txn/tour`, `/txn/tour-return`  (`tour/tour.ts`)

**Desktop spec (KB §9):** goods out on approval (no money); grid `Sr·TagNo·ItCode·Counter·Design·Size·
Pcs·GrWt·LsWt·NetWt·Touch·West%·Fine·ItRate·ItAmt·LbrRate·LbrAmt·OthAmt·Mrp`; Return adds **`Isu No`**
picker (loads issue, cancel-all, scan-returned); bill the kept item via Sales `Apr No`; writes
APR_DATA/APR_DETL/APR_IDTL/MAIN_STOCK (out→pending / in). No AC_DATA.

**Web now:** `tour.ts` `tourIssue` writes APR_DATA + APR_DETL + MAIN_STOCK(`TOUR`,`TR_TYPE 'O'`,`-`), **no
AC_DATA** (correct); `tourReturn` writes an APR receive (book `TRR`, `TOURR`, `INOUT_TYPE 'R'`) +
MAIN_STOCK(`+`) and **flips the original APR_DETL `ISU_REC 'N'→'R'`** (partial supported via `origSrNo`
or item/tag match) — `deleteTourReturn` re-opens them. **Core = match.** Pages: issue header
(Book/Year/Location/**Salesman/Employee**/Name/Description) + grid (Item/Tag/Pcs/Gross/Net Wt/Touch%/
Fine); return (Orig Issue Vch No free-text/Salesman/Date) + grid (Orig Sr/Item/Tag/Pcs/Gross/Net/Touch/
Fine) + `closedLines`.

**GAPS**
- *Grid columns missing:* `Counter`, `Design`, `Size`, `LsWt`, `West%`, `ItRate`, `ItAmt`, `LbrRate`,
  `LbrAmt`, `OthAmt`, `Mrp` — web tracks weight/fine only. No charges sub-grid.
- **Return has no `Isu No` picker (F1).** Web needs the operator to type the original vch no and re-key
  each line; desktop loads all issue lines then keeps only the scanned-back tags.
- **Party vs Salesman semantics.** KB issues on approval to a **Party** (`RAKESH BHAI SONI`); web labels
  the recipient **Salesman/Employee** (`salesmanAc`) — confirm the desktop stores the party in `AC_CODE`.
- **No billing from `Apr No`** in Sales (cross-ref §1) — the kept item can't flow into a Tax Invoice.
- No Approval reports (Approval Isu / Approval InOut with Out/In/Panding / Approval Panding).

**Fill plan**
- Backend: add `GET /tour/:vchNo/lines` (load an issue for the return picker); persist the extra
  descriptive/value columns (`counter/design/size/mrp/itRate/lbrRate/othAmt`) to APR_DETL/APR_IDTL; add
  the `Apr No`→sale bridge (feed selected approval lines into `createSale`, mark `EMP_SALE='Y'`).
- Frontend: add the `Isu No` picker on tour-return; add the descriptive columns; align party labelling.
- **Priority P1** (Apr No→Sales bridge, Isu No picker) / **P2** (value columns, party wording).
  **Effort M.**

---

## 10 · Labour Invoice — `/txn/labour-sale`  (`labour-sale/page.tsx` → `POST /sales`, coBook `LBR`)

**Desktop spec (KB §10):** bill only making when the customer supplied gold (via a Sales-Order gold
credit); **dual GST — 3% on metal + 5% on labour** (two `TAX_DATA` rows + `Sale Tax`/`Lbr Tax` panel
rows); order-gold credit panel (`Ord No·Ord Weight·Order Wt·1gm Rate·Cr Fine·Dr Fine·Cr/Dr Amount`);
writes LBR_DATA/LBR_ISU_DETL/LBR_ISU_IDTL/LBR_REC_DETL/AC_DATA/TAX_DATA/BILL_OS_DATA + fine sub-ledger.

**Web now:** **No dedicated labour module exists** (verified: `labour` matches in the API are only
`labourType`/`labourCharge` in `sales.ts`/`purchase.ts`/`mfg.ts`/`karigar.ts`, and `masters/
labourUpdate.ts` for rate masters). The page `labour-sale/page.tsx` posts to **`POST /sales`** with
`coBook:'LBR'`, a single `taxRatePct` (default 5), and per-line `labourType/netWt/pcs/value/metalAmount`.
So a labour bill is booked as a **plain sale** into SL_DATA.

**GAPS (this is the biggest single functional gap in the module)**
- **No dual GST.** Desktop charges **3% on metal (28800→864)** *and* **5% on labour (9600→480)** as two
  separate `TAX_DATA` rows + `Sale Tax`/`Lbr Tax` panel rows. Web sends one `taxRatePct` to `/sales` —
  a single blended rate only.
- **No Sales-Order gold credit.** No `Ord No` pull, no order-gold grid (`Sr·Ord No·Ord Weight·Ord Amt`;
  `Tot Wt Dr/Cr·Order Wt·1gm Rate·Cr Fine·Dr Fine·Cr/Dr Amount`), and no **chargeable-metal =
  made − order-gold** computation (16g−10g=6g×4800=28800). Web makes the operator type `metalAmount`
  manually; no `Cr Gold` fine adjustment.
- **No LBR_* tables.** `LBR_DATA/LBR_ISU_DETL/LBR_ISU_IDTL/LBR_REC_DETL` are never written — the voucher
  lands in `SL_DATA` as a sale.
- **No labour ledger split** (Cr labour income + Cr metal-sale + Cr GST 3% + Cr GST 5% + order-gold
  Cr-Gold fine leg). No tender panel (Cheque/Card/Order/Cash/Kasar/Os), no `Item(Gold)` dropdown,
  `Cr Days`, `Employe`, `Vch Desc`. No `LabourBillGst.rpt`.

**Fill plan**
- **New backend module `sales/labourInvoice.ts`** (or `labour/labour.ts`): `createLabourInvoice()` that
  (a) pulls the Sales-Order gold credit by `ordNo` (read SL_ORD_DETL/SL_ORD_ADJ fine), (b) charges only
  the surplus metal (`madeFine − orderFine`) × rate + making, (c) applies **two `TAX_DATA` rows** —
  `GST 3%` on metal and `GST 5%` on labour, (d) posts Dr customer/Cr bank + Cr labour + Cr metal + Cr
  GST(3%)+Cr GST(5%) + order-gold `Cr Gold` fine leg, (e) writes `LBR_DATA/LBR_ISU_DETL/LBR_ISU_IDTL/
  LBR_REC_DETL` + BILL_OS_DATA; add `POST /labour-invoice` + delete/reverse in `txn.ts`.
- Frontend `labour-sale/page.tsx`: repoint from `/sales` to `/labour-invoice`; add the order-gold credit
  panel + `Ord No` picker + separate `Sale Tax (3%)`/`Lbr Tax (5%)` totals + tender panel.
- **Priority P0** (dual GST + order-gold credit are the defining, currently-absent features).
  **Effort L.**

---

## 11 · Other Expenses — `/txn/other-purchase`  (`other-purchase/page.tsx` + `purchase/purchase.ts` `createOtherPurchase`)

**Desktop spec (KB §11):** non-stock GST expense buy; header `Bill No·Bill Date·Party(GST compulsory)·
Ledr Code`; **HSN-driven grid** `HsnCode·ItName·TaxCode·Tax%·NetAmt·TaxType(F/R)·TaxableAmt·IGSTamt·
CGSTamt·SGSTamt·TotalAmt`; **`TaxType` F=forward (add on top) / R=reverse (GST-inclusive, back-calc)**;
tender panel; writes PAY_DATA/TAX_DATA(input)/BILL_OS_DATA (`OPUR`/`OPR`). No stock.

**Web now:** `createOtherPurchase` writes PAY_DATA + TAX_DATA(input, `TRAN_TYPE 'P'`, `BOOK 'OTH PURC'`,
`TAX_SIGN '-'`) + BILL_OS_DATA, ledger Cr supplier / Dr expense(s) / Dr GSTINPUT / Dr ROUNDOFF
(`OPUR`,`OPR`) — **forward-GST path = match**. Page: header (Supplier/Supplier Name/Bill No/Tax %(18)/
Inter-state) + Expense Lines (`Expense account·Description·Amount`), forward GST only.

**GAPS**
- **Grid is plain expense lines**, not HSN-driven. Missing `HsnCode`, per-line `TaxCode`/`Tax%`, per-line
  `IGSTamt/CGSTamt/SGSTamt` columns.
- **No `TaxType` F vs R.** `createOtherPurchase` only adds GST on top (forward). The **reverse/inclusive**
  calc (e.g. `NetAmt 30000` → `TaxableAmt 23437.50` + CGST/SGST `3281.25` each → `TotalAmt 30000`) is
  absent.
- **No HSN master** ("Add New HsnNo ?" → save for reuse).
- No `Bill Date`, no header **`Ledr Code`** (default expense head `00060 SHOP EXP`, editable).
- **No tender panel** (`Cheque/Card/Cash/Kasar/Os` + bank picker). `createOtherPurchase` takes no tender
  — always full payable.
- Supplier **GST-No-compulsory** validation missing.

**Fill plan**
- Backend `createOtherPurchase`: accept per-line `{hsnCode, taxPct, taxType:'F'|'R'}`; when `R`,
  back-calculate taxable = amount×100/(100+taxPct) and split CGST/SGST(/IGST); add tender legs
  (Cr cash/bank) + BILL_OS REC_AMT; add an HSN master upsert.
- Frontend `other-purchase/page.tsx`: HSN-driven grid (HsnCode/Tax%/TaxType/computed IGST/CGST/SGST),
  Bill Date, Ledr Code header, tender panel.
- **Priority P1** (TaxType F/R + HSN per-line + tender) / **P2** (Bill Date, Ledr Code, HSN master).
  **Effort M–L.**

---

## 12 · Bill-Wise Amount Received (Bill-to-Bill) — `/txn/bill-to-bill`  (`bill-to-bill/page.tsx` + `finance/billToBill.ts`)

**Desktop spec (KB §12):** two grids — **top tender** `Sr·RecAc·Rac Ac Name·It Desc·Chq No·Amount·Kasar`
(mixed **cash + bank** in one voucher) and **bottom allocation** `Sr·BillNo·Book·BillAmt·RecAdj·RecAmt·
KasarAmt·DiffAmt`; overpay rejected; updates BILL_OS_DATA + posts CASH_DATA + AC_DATA (`CREC`/`BREC`).

**Web now:** `billToBill.ts` `listOpenBills` (openBal = `BILL_AMT−REC_AMT−KASAR_AMT`, spans years) +
`settleBills` (per-bill `REC_AMT`/`KASAR_AMT` with **overpay guard** + `NEW_VCH_NO` link, then posts a
**real** Dr cash/bank + Dr kasar / Cr party receipt into `AC_DATA` + `CASH_DATA`) — **core = match**.
Page: Party picker + **allocation grid** (Book/Voucher/Bill Amt/Recd/Kasar/Open Bal/**Receive**/**Kasar
(w/off)**/New Open) + Settle.

**GAPS**
- **No top tender grid.** Desktop records **how** the money arrived, mixing **cash + bank** in one
  voucher (`CASH ON HAND 10000` + `HDFC BANK 15000`). `settleBills` exposes only a **single** `mode`
  (`'cash'|'bank'`) — **mixed cash+bank tender is impossible**; the page sends no tender lines at all
  (the tender is implicit = one cash receipt).
- **No `Chq No`** capture per tender line; no `It Desc`, no `Employe`.
- Column naming: desktop `RecAdj` (already received) / `DiffAmt` (remaining) vs web `Recd` / `New Open`
  (equivalent, cosmetic).
- No per-bill printable receipts.

**Fill plan**
- Backend `settleBills`: accept `tenders:[{recAc, amount, chqNo, kasar, itDesc}]` and post one balanced
  receipt with a Dr per tender leg (cash **and** bank) instead of a single `mode`; keep the allocation
  overpay guard + `NEW_VCH_NO`/`OLD_VCH_NO` linkage.
- Frontend `bill-to-bill/page.tsx`: add the top tender grid (RecAc/Chq No/Amount/Kasar/It Desc) and
  reconcile Σtender vs Σallocation before enabling Settle.
- **Priority P1** (mixed cash+bank tender grid) / **P2** (Chq No, It Desc, receipts). **Effort M.**

---

## Module-level summary — top gaps by priority

| # | Gap | Screen(s) | Priority | Effort |
|---|-----|-----------|----------|--------|
| 1 | **Labour Invoice has no dual GST (3% metal + 5% labour), no Sales-Order gold credit, and writes no LBR_* tables** — it posts to `/sales` as a plain sale. Needs a dedicated `labourInvoice` module. | §10 | **P0** | L |
| 2 | **No purchase/expense/purchase-return settlement (tender) panel** — `createPurchase`, `createOtherPurchase` and `createPurchaseReturn` take no cash/cheque/card/kasar/bank and always book full payable/no-refund (unlike `createSale`). | §6, §7, §11 | **P0** | L |
| 3 | **Sales-Order advance is never consumed by the Sales invoice** — no `Ord No`/`Order Amt` in `createSale` and `SL_ORD_ADJ` is never read/written anywhere, so orders can't be fulfilled end-to-end. | §5, §1 | **P0** | M |
| 4 | **Sales Return has no import-from-bill** — no Sale-Bill picker importing the original lines, no receive-item re-stock grid (editable `TagLRate`/MRP), no refund-vs-credit tender. | §3 | **P0** | L |
| 5 | **Sales Invoice fidelity** — missing `Apr No`/`Ref No`/print-template header, the **charges sub-grid** (HM/RD → `OthAmt`), item columns `Design/Size/LsWt/Lbr%/LbrRate/OthAmt`, and tender rows `Old Silver/Scheme/Cash Paid/Order Amt/Bank/CR Days/Employe`. | §1 | **P1** (breadth ⇒ largest single-screen build) | L |

**Runner-ups (P1):** multi-line Cash/Bank receipt & payment grid + `It Desc`/`Employe` (§2/§4); per-bank
**Book** master + `Chq No` column + cheque print (§4); Bill-to-Bill **mixed cash+bank tender grid** (§12);
Other-Expenses **`TaxType` F/R (reverse/inclusive)** + HSN-driven lines (§11); Tour **`Isu No` picker** +
`Apr No`→Sales bridge + descriptive columns (§9); Purchase **URD books** + **Only-Tag-Entry** (§6).

**Already at parity (service layer, keep):** posting engine (balanced `AC_DATA`, `LEDR_KEY`, `DATA_TYPE`,
`BOOK_NAME`, reverse+`DELETE_DATA`), period lock (`assertPeriodOpen`/`CO_SET.LOCK_DATE`), Sales core
(GST split, per-group income legs, hallmark, TCS, kasar, multi-tender, old-gold-in), Purchase core
(mirror ledger, per-group `PURC_AC`, metal fine leg, hallmark, tag stock-in), Contra (`postContra`),
Cash/Bank Receipt & Payment postings incl. cash-ceiling/PAN gate + CARD_DATA/UPI_DATA, Sales-Order
header/detail/advance-ledger + cancel guards, Sales-Return & Purchase-Return reverse ledgers + stock,
Tour issue/return (no-ledger custody, partial return, `ISU_REC` flip), Bill-to-Bill open-bill list +
overpay-guarded allocation + real receipt posting.
