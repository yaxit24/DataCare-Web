# KB — DataCareNext Jewellery ERP · **Transaction** Playlist (core txn screens)

> Desktop-application knowledge base built to drive an **exact web replica**. Sources per video:
> Sarvam Hindi transcript (`project-memory/video-research/transaction/<id>/transcript.sarvam.txt`) +
> scene-change keyframes (`…/<id>/keyframes/kf_*.jpg`). Cross-referenced against the decompiled desktop
> (`extracted_code/DataCareNext/…`), the web API (`web/apps/api/src/modules/**`) and web routes
> (`web/apps/web/app/(app)/txn/**`). Menu paths use the desktop menu bar
> **Home · Company · Master · Tran 1 · Tran 2 · Other · Karigar · Reports · Scheme · Dhiran · Exit**.

## Global UI chrome (applies to every screen below)
- **Title bar:** `01 - DATACARE SOFTECH - 2021-2022 - ABC - P` = CoCode · Firm · Financial-Year · Branch · mode.
- **Left sidebar** when *Tran 1* is active (the "Pro" list): Purchase · Purchase Rtn · Sales Order · Sales · Sales Return · Wh Sales · Cash Received · Cash Payment · Bank Received · Bank Payment · Contra Entry · Rate Cut.
- **Opening a book:** a Tran item opens a *book chooser* (e.g. **Gold Tax Invoice / Silver Tax Invoice**); operator double-clicks a book.
- **Voucher header pattern:** `Vch No` (+`F1` = master help) · `Vch Date` (date + time + weekday) · `Ref No` · `Party` (code + name) · `Print` template dropdown + `Set`. The selected party's running **balance** shows top/bottom-right as `NNNN.00 : Dr Amt` / `Cr Amt`.
- **F-keys / shortcuts** (left-edge arrow reveals them): **F1** = open master (Party/Item) inline · **F2** = Ledger Report · **F3** = bulk (loose) stock · **F12** = Tag-wise Stock Report. **Enter** walks field→field; **Esc** jumps cursor to the right-hand tender panel.
- **Bottom action bar** on edit forms: `◀  ▶  Print  Save  Cancel  Delete  Exit`.
- **Status bar:** colour · Live Rate · Fine Gold · Fine Silver · Rate Date · Service End.
- **Posting engine (all vouchers):** every save writes a **balanced** `AC_DATA` double entry (`ΣDR = ΣCR`, enforced by `assertBalanced`), stamped `LEDR_KEY`, `DATA_TYPE='A'`, `BOOK_NAME`, then the module's satellite tables — all inside **one transaction** (`postVoucherTx`). Delete = `reverseVoucherTx` (deletes every table by voucher key + writes a `DELETE_DATA` audit row). Vouchers dated on/before `CO_SET.LOCK_DATE` are rejected (period lock). **fine = netWt × touch ÷ 100.**

---

## Summary table

| # | Video ID | Screen | Menu path | Book(s) | Primary tables written | Web route | API module | Parity |
|---|----------|--------|-----------|---------|------------------------|-----------|-----------|--------|
| 1 | DF_P2GD9AuU | **Sales Invoice** (Gold/Silver Tax Invoice) | Tran 1 → Sales | Gold Tax Invoice, Silver Tax Invoice | SL_DATA, SL_DETL, SL_IDTL, SL_PR_DETL, MAIN_STOCK, AC_DATA, TAX_DATA, BILL_OS_DATA | `/txn/sales` | `sales/sales.ts` | matches (verify TCS/HM/tender UI) |
| 2 | tpKMyaRMlFM | **Cash Received & Cash Payment** | Tran 1 → Cash Received / Cash Payment | (single) | CASH_DATA / PAY_DATA, AC_DATA | `/txn/receipt`, `/txn/payment` | `finance/finance.ts` | matches |
| 3 | dVfvnhzWQKI | **Sales Return** (Credit Note) | Tran 1 → Sales Return | Credit Note | SL_DATA, SL_DETL_RTN, MAIN_STOCK, AC_DATA, TAX_DATA, BILL_OS_DATA | `/txn/sale-return` | `sales/salesReturn.ts` | to-verify (import-from-bill) |
| 4 | AdgxtGwjrfc | **Bank Received & Bank Payment** | Tran 1 → Bank Received / Bank Payment | per-bank books (HDFC/ICICI Rec & Pay) | CASH_DATA(BREC)/PAY_DATA(BPAY), AC_DATA | `/txn/receipt`, `/txn/payment` (bank) | `finance/finance.ts` | matches (verify per-bank book mgmt) |
| 5 | Sq-Xo4E5GTE | **Sales Order** | Tran 1 → Sales Order | (single) | SL_ORD_DATA, SL_ORD_DETL, SL_ORD_IDTL, SL_ORD_ADJ, AC_DATA | `/txn/sales-order` | `sales/salesOrder.ts` | to-verify (advance + adjust-into-sale) |
| 6 | lqJjexUe4MA | **Purchase Voucher** | Tran 1 → Purchase | Gold/Gold URD/Silver/Silver URD Purchase | PR_DATA, PR_DETL, PR_IDTL, MAIN_STOCK, AC_DATA, TAX_DATA | `/txn/purchase` | `purchase/purchase.ts` | matches (verify inline tagging) |
| 7 | wuIFZsCf4Mw | **Purchase Return** (Debit Note) | Tran 1 → Purchase Rtn | Debit Note | PR_DATA, PR_DETL, MAIN_STOCK, AC_DATA, TAX_DATA | `/txn/purchase-return` | `purchase/purchaseReturn.ts` | to-verify |
| 8 | tSRFXH2BoZ0 | **Contra Entry** | Tran 1 → Contra Entry | (single) | CONTRA_DATA, AC_DATA | `/txn/contra` | `finance/finance.ts` (postContra) | matches |
| 9 | DpdQpC7Od2M | **Approval Issue / Received** (Tour) | Tran 2 → Approval (Issue/Receive) | Approval books | APR_DATA, APR_DETL, APR_IDTL, MAIN_STOCK | `/txn/tour`, `/txn/tour-return` | `tour/tour.ts` | to-verify |
| 10 | tLThVxaKF5o | **Labour Invoice** (Karigar labour bill) | Karigar → Labour Invoice | Labour book | LBR_DATA, LBR_ISU_DETL/IDTL, AC_DATA, TAX_DATA | `/txn/labour-sale` | (labour module — verify) | to-verify |
| 11 | f2mXV47LSXk | **Other Expenses** | Tran 2 → Other Expenses / Other Purchase | (single) | PR_DATA/expense, AC_DATA, TAX_DATA | `/txn/other-purchase` | `purchase/purchase.ts` (other) | to-verify |
| 12 | sE2H-ztIINE | **Bill-Wise Amount Received** (bill-to-bill) | Tran 1 → Cash/Bank Received (bill-wise mode) | Receipt book | CASH_DATA, BILL_OS_DATA (adjust), AC_DATA | `/txn/bill-to-bill` | `finance/billToBill.ts` | to-verify |

Parity legend: **matches** = web module implements the same tables/postings; **to-verify** = module/route exists, exact field & flow parity to be confirmed against UI; **gap** = missing.

---

## 1 · Sales Invoice — Gold/Silver Tax Invoice  ·  `DF_P2GD9AuU` → `/txn/sales`

**The most complex screen in the playlist** (old-gold exchange, hallmark, TCS, GST split, multi-tender settlement). Opening line: *“आज हम … सेल्स इनवॉइस बनाना सीखेंगे”* ("today we'll learn to make a Sales Invoice").

### 1.1 Screen title + menu path
- **Menu:** `Tran 1 → Sales`. The Sales node opens a **book chooser** with two books — **Gold Tax Invoice** and **Silver Tax Invoice** (*“यहां पे आपको दो बुक्स मिल जाएंगी जैसे गोल्ड टैक्स इनवॉइस, सिल्वर टैक्स इनवॉइस”*). Operator double-clicks **Gold Tax Invoice** (kf_002). Tab caption: **Sales 1**.
- Printed document title: **Gold Tax Invoice** (kf_007).

### 1.2 Header fields (exact on-screen labels — kf_004, kf_008)
| Label | Notes |
|---|---|
| `Vch No` | auto (e.g. `00002`); `F1` button beside it opens Party master |
| `Vch Date` | auto date `15/05/2021` + time `10:36:41` + weekday `Saturday` |
| `Apr No` | approval/tour reference; `A` button beside it |
| `Ref No` | printed bill serial, e.g. `T1-00001` |
| `Party` | code box (`000201`) + name (`VIKAS BARVADIYA`). Default is **AC 45 = Cash Sales** (*“बाय डिफॉल्ट … 45 नंबर जो है कैश सेल्स का अकाउंट”*); clear it + Enter to search any account; **F1** creates a Party inline |
| `Print` | template dropdown `SalesBillA4Gst` + `Set` button |
| party balance | top-right `15000.00 : Dr Amt` (running balance before this bill) |

### 1.3 Main item grid — exact column headers (kf_008)
`Sr` · `TagNo` · `ItCode` · `Design` · `Size` · `Pcs` · `GrWt` · `LsWt` · `NetWt` · `ItRate` · `ItAmt` · `Lbr%` · `LbrRate` · `LbrAmt` · `OthAmt` · `TotAmt` · `Tax%` · `NetAmt`

- **Tag/barcode entry:** cursor lands on `TagNo`; scan a barcode **or** type/Enter to list barcoded stock. Selecting a tag (e.g. *Chain No 1*) auto-fills GrWt/NetWt and shows the item **photo** (zoomable) bottom-left.
- **Manual entry:** leave TagNo blank → `ItCode` Enter lists all items; pick item, then key Pcs/Weight manually (for non-barcoded stock).
- `ItRate` (e.g. gold `4500`/g) → computes `ItAmt`. `Lbr%` making-charge % is editable per-bill (*“12% रखा था लेकिन बिल बनाने के टाइम पे इसको 10% कर देना है”* — default 12%, overridable to 10%) → `LbrRate`/`LbrAmt`. `OthAmt` = sum of the charges sub-grid. `TotAmt`, then `Tax%`/`NetAmt`.
- **Totals row** under the grid: Pcs=`1`, GrWt=`12.650`, LsWt=`0.000`, NetWt=`12.650`. `Print Name` field (e.g. `CHAIN 916`) with hint `CHAIN 916 : It Name`. Bottom-left running totals `P= 4  G= 54.55  N= 54.55` (Pieces/Gross/Net).

### 1.4 Sub-grids
**A. Charges / labour lines** (kf_004, kf_008) — cols `Sr · ItCode · ItName · Pcs · Weight · Con% · P/W · Rate · ItAmt · NetAmt`. Observed rows: `HM · HALL MARK CHARGES · … · 300.00` and `RD · RODIAM (Rhodium) CHARGES · … · 500.00`. Their sum flows to `OthAmt` / `Other Charg` on the invoice (*“होलमार्क और ओडियम का जो चार्जेस … अदर अमाउंट में आ जाएगा”*).

**B. Old-Gold exchange (URD in)** — cols `Sr · ItCode · ItName · Pcs · GrWt · LsWt · NetWt · Touch · Fine · Rate · NetAmt`. This captures old metal the customer gives in part-exchange; **Fine = NetWt × Touch ÷ 100**, valued at `Rate` → `NetAmt` posts to `Old Gold Amt` and adds metal to stock.

### 1.5 Right-hand tender / totals panel — exact labels top→bottom (kf_004, kf_008)
`Net Amt` · `Disc Amt` · `Tax Amt` (shows `GST 3%` → rate `3.00` → amount `24.00`) · `Tcs Amt` · `Rof Amt` (round-off) · `Total Amt` (`824.00`) · `Cheque Amt` · `Card Amt` · `Order Amt` (`0.00`) · `Old Gold Amt` · `Old Silver Amt` · `Scheme Amt` · `Cash Amt` · `Cash Paid Amt` · `Kasar Amt` · `Os Amt` (outstanding, `824.00`).
Bottom-left: `Employe`(e) `001`, `Bank` (deposit-bank dropdown for cheque/card), `Vch Desc`, `CrDay` `0`. Order sub-grid to the right: `Sr · Ord No · Ord Amt`.

### 1.6 Step-by-step operator workflow (from narration)
1. `Tran 1 → Sales` → double-click **Gold Tax Invoice**.
2. `Vch No`/`Date` auto; press **Enter Enter Enter**. Default party = **Cash Sales (45)** for a no-account cash bill; otherwise clear code, Enter, search & pick party (e.g. *Vikas*) → its balance shows right. **F1** to create a new party inline, then Esc back and reselect.
3. Cursor → `TagNo`: **scan barcode** or Enter to pick from barcoded stock (e.g. *Chain No 1*) → details + photo auto-fill.
4. `ItRate` = `4500`/g → `ItAmt`. Adjust `Lbr%` (12%→10%) → labour computes. Enter through `OthAmt` (hallmark+rhodium) → `TotAmt`.
5. Enter → next grid row (add more items, or manual `ItCode` for non-barcoded).
6. Optional **Discount** (e.g. `1000`). **GST 3%** auto-adds. `Total Amt` (e.g. `64290`).
7. **Tender split** (Esc to right panel): enter `Cheque Amt` (e.g. `30000`) → pick **deposit bank** from list; `Card Amt`; `Old Gold Amt`; `Order Amt`; `Cash Amt` (e.g. `20000`). Remaining (e.g. `14290`) stays as `Os Amt` (customer outstanding). Set `CrDay`/`CR Days` (e.g. `10`) → system raises a **reminder** after due days (*“10 डेज के बाद … कंप्यूटर रिमाइंडर दे देगा”*).
8. **Save** → `View / Print / Exit`. **View** renders the Gold Tax Invoice (kf_007).

### 1.7 Effects — tables + ledger/stock (verified against `sales/sales.ts` + `posting/posting.ts`)
**Tables written (one txn):** `SL_DATA` (header: NET_AMT, DISC_AMT, TAX_PRC, TAX_AMT, CGST_TAX, SGST_TAX, IGST_TAX, ROF_AMT, TOT_AMT, CASH_AMT, CARD_AMT, UPI_AMT, CHQ_AMT, OLD_GL_AMT, BILL_OS, HM_AMT, HM_TAX_AMT, TCS_AMT, TCS_PRC, KASAR_AMT) · `SL_DETL` (per line: ITM_PCS/GWT/NWT/TOUCH/FINE/RATE/AMT, LBR_AMT, NET_AMT, ITM_CGST_AMT/SGST_AMT/IGST_AMT, TOT_AMT, HM_ID) · `SL_IDTL` (tag lines) · `SL_PR_DETL` (old-gold in, VCH_TYPE `SLOG`) · `MAIN_STOCK` (sold tag out `VCH_TYPE=TGSL, TR_TYPE='S', ITM_SIGN='-'`; old-gold in `VCH_TYPE=MIXSL, TR_TYPE='P', ITM_SIGN='+'`) · `TAX_DATA` (CGST+SGST rows intra / IGST inter, +HM tax rows) · `BILL_OS_DATA` (BILL_AMT, REC_AMT, KASAR_AMT).

**Ledger (`AC_DATA`, VCH_TYPE `SALE`) — balanced double entry:**
- **Dr** Cash (`CASH`, cash tendered) · **Dr** Bank (`BANK`/deposit acct — card+upi+cheque) · **Dr** Old-gold (`OLDGOLD`, metal received) · **Dr** Customer party (`BILL_OS` balance, incl. tax).
- **Cr** Sales income (`SALES`, taxable) — **split per group** via `GROUP_MAST.SALE_AC` (Σ legs = taxable) · **Cr** GST output (`GST`, split CGST+SGST half/half intra, or IGST inter) · **Cr** round-off (`ROUNDOFF`).
- **Hallmark charge** (if `HM_AMT>0`): Cr `HMCHRG` income + Cr `GST` on it, Dr customer.
- **TCS** (cash bill / configured %): Cr `TCS` payable, Dr customer.
- **Kasar** write-off: Dr `KASAR`, Cr customer (reduces receivable).
- **PAN gate:** a cash portion over `CO_SET.CASH_LIMIT` (₹2,00,000 default) requires a PAN.

**Ledger Report (F2)** after save shows exactly these auto-postings (narration: bank auto-gets the cheque 30000, cash-on-hand the cash, discount → discount ac, GST → GST ac, sales → sales ac, party outstanding → Dr party). **Tag-wise Stock (F12)** shows the sold tag has left `Stock Only` and appears under **Out Tag**.

### 1.8 Cross-module connections
- **Masters:** Party/Account master (**AC_MAST**, inline via F1), Item/Product master (**ITEM_MAST/PRODUCT_MAST**), **GROUP_MAST.SALE_AC** (income split), **RATE_MAST/TOUCH_MAST** (metal rate & touch), **EMP_MAST** (Employe 001), bank accounts.
- **Feeds:** Ledger Report (F2), Tag-wise Stock (F12 → Out Tag), GST reports (GSTR-1 via TAX_DATA), Bill outstanding / reminders (BILL_OS_DATA + CrDays), E-Invoice (SL_DATA), Sales Return (imports this bill).
- **Consumes:** barcoded stock created by Purchase→tagging; Sales Order advances (`Order Amt`).

### 1.9 Web parity — `/txn/sales` (`sales/sales.ts`)
`createSale()` implements the full flow verified above: voucher numbering, per-tag `issueTagTx` (double-issue-guarded), GST split + `billTotals`, per-group income legs, hallmark, TCS, kasar, multi-tender settlement, old-gold in, and writes SL_DATA/SL_DETL/SL_IDTL/SL_PR_DETL/MAIN_STOCK/TAX_DATA/BILL_OS_DATA + balanced AC_DATA. `deleteSale()` reverses all + restores tags + DELETE_DATA. **Parity = matches** at the service layer; **to-verify** the web page renders the exact grid columns (1.3), both sub-grids (1.4) and the 16-row tender panel (1.5), plus the `Old Silver Amt` / `Scheme Amt` / `Cash Paid Amt` fields.

---

## 2 · Cash Received & Cash Payment  ·  `tpKMyaRMlFM` → `/txn/receipt` + `/txn/payment`

One video covers both mirror screens (money-in / money-out in cash).

### 2.1 Screen title + menu path
- **Cash Received:** `Tran 1 → Cash Received` (tab **Cash Received 1**, banner **Cash Received**).
- **Cash Payment:** `Tran 1 → Cash Payment` (tab **Cash Payment 3**, banner **Cash Payment**).

### 2.2 Header fields + grid (kf_010 receipt, kf_031/kf_038 payment)
- **Header:** `Vch No` (`00001`) + `F1` · `Vch Date` (`15/05/2021`) + time (`13:14:18`) + weekday (`Saturday`). Right shows the selected party's running balance `20000.00 : Dr Balance`, and a working `29290.00 : Dr Amt`.
- **Main grid columns:** `Sr` · `AcCode` · `Ac Name` · `Amount` · `Kasar`. Multiple lines allowed per voucher (e.g. a single Cash Payment paying `OFFICE EXPENSES 3000` **and** `PETROL & VEHICAL EXP 2000`). Below the grid: `Total :` with column totals.
- **Footer fields:** `It Desc` (multiline narration) · `Employe`(e) code+name.
- **F1 account picker** (`DataCare Help`, kf_031) columns: `AcName` · `Mobile` · `AcCode` · `Address` · `Group`. Pre-seeded expense accounts seen: `OFFICE EXPENSES 00059`, `PETROL & VEHICAL EXP 00063`, `BANK A/C 00075`, `BANK CHARGES A/C 00048`, `ADVANCE TAX A/C 00047`, `CARD A/C 00040`, `CARD COMM A/C 00078`, `CAPITAL A/C 00002`. The narration lists default expense heads: Shop Expense, Office Expense, Electricity Bill Expense, Petrol & Vehicle.
- **Bottom bar:** `▶ · Print · Save · Cancel · Delete · Exit`. **Save → print dialog** (kf_017) with `☑ Original / ☐ Duplicate / ☐ Triplicate` and `View · Print · Exit`.

### 2.3 Operator workflow
**Cash Received:** `Tran 1 → Cash Received` → Enter Enter Enter → account list → search party (e.g. *Vikas*) → its balance shows right → Enter to `It Desc` (optional narration) → Enter to `Amount` → key received cash (e.g. `15000`) → **Save** → `View/Print/Exit` (receipt shows party opening balance, received, and due).
**Cash Payment:** `Tran 1 → Cash Payment` → Enter Enter Enter → pick an expense account (default heads pre-made, or **F1** to create) e.g. *Office Expense* → narration → `Amount` (e.g. `3000`); add more lines (e.g. Electricity/Petrol) → **Save** (receipt optional).

### 2.4 Effects (verified `finance/finance.ts`)
- **Cash Received → `postReceipt(mode='cash')`:** `AC_DATA` **Dr `CASH` / Cr party** (VCH_TYPE `CREC`); header → **`CASH_DATA`** (REC_AMT, KASAR_AMT, AC_CODE, REC_AC_CODE=`CASH`, CHQ_NO). Optional `Kasar` write-off adds Dr `KASAR`. **Cash-receipt ceiling:** amount + party's prior cash > `CO_SET.CASH_LIMIT` (₹2,00,000) is **blocked, no PAN override** (desktop `TR_CASH`).
- **Cash Payment → `postPayment(mode='cash')`:** `AC_DATA` **Dr expense/party / Cr `CASH`** (VCH_TYPE `CPAY`); header → **`PAY_DATA`** (NET_AMT, TOT_AMT, CASH_AMT, KASAR_AMT). `Kasar` (discount received) adds Cr `KASAR`.
- **Ledger Report (F2)** confirms: after cash received, cash-on-hand ↑ and the party's Dr balance ↓; after cash payment, `CASH ON HAND` fell `35000 → 30000` while `OFFICE EXPENSES 3000` + `PETROL & VEHICAL EXP 2000` posted Dr (kf_043). Ledger columns: `Party Name · Mobile · DrAmt · CrAmt · DrGold · CrGold · DrSilver · CrSilver`.

### 2.5 Cross-module connections
Party/expense accounts (**AC_MAST**, F1 inline create). Feeds **Ledger Report** (F2), day-book/RojMel, and party outstanding. No stock/tax impact (pure cash ledger vouchers).

### 2.6 Web parity — `/txn/receipt`, `/txn/payment` (`finance/finance.ts`)
`postReceipt`/`postPayment` implement the cash Dr/Cr and CASH_DATA/PAY_DATA writes, cash-limit ceiling, and Kasar. **Parity = matches** at service layer. **Gap/to-verify:** the desktop screen is a **multi-line grid** (several AcCode/Amount/Kasar rows in one voucher); confirm the web receipt/payment page supports multiple lines, the `Kasar` column, `It Desc`, `Employe`, and the Original/Duplicate/Triplicate print dialog.

---

## 3 · Sales Return — Credit Note  ·  `dVfvnhzWQKI` → `/txn/sale-return`

Requires an existing Sales Invoice first (*“सेल्स रिटर्न लेने से पहले फर्स्ट आपको एक सेल्स का इनवॉइस बनाना पड़ेगा”*).

### 3.1 Screen title + menu path
`Tran 1 → Sales Return` → tab **Sales Return 1**, banner **Credit Note**.

### 3.2 Header + grids (kf_012, kf_020)
- **Header:** `Vch No` (`00001`) + `F1` · `Vch Date` (`16/05/2021`) + time + weekday (`Sunday`) · **`Sale Bill`** = 3 boxes (bill no `00002` · year `2021-2022` · serial `026`) + `S` button · `Party` (code `000202` + `RAKESH BHAI SONI`) · `: It Name`.
- **`Sale Bill` picker** (`DataCare Help`, kf_012) columns: `VchNo` · `Date` · `PartyName` · `Book` · `BillAmt` (e.g. `00001 · 15/05/2021 · VIKAS BARVADIYA · Gold Tax Invoice · 64290.00`; `00002 · … · RAKESH BHAI SONI · … · 83430.00`). Selecting the original bill **imports all its lines** into the return.
- **On import** the software prompts to **reuse the same barcode (Yes)** or **generate a new tag (Enter)** for the returned stock.
- **Main grid columns:** `Sr` · `TagNo` · `ItCode` · `ItName` · `Design` · `Pcs` · `GrWt` · `OthWt` · `NetWt` · `ItRate` · `ItAmt` · `Lbr%` · `LbrRate` · `LbrAmt` · `OthAmt` · `NetAmt` (Total row below).
- **Charges sub-grid:** `Sr` · `ItCode` · `ItName` · `Pcs` · `KrWt` · `Weight` · `Con%` · `P/W` · `Rate` · `ItAmt` · `NetAmt`.
- **Receive-Item sub-grid** (the tag going back into stock, kf_020) columns: `Sr` · `RecCode` · `TagNo` · `Receive Item` · `Counter` · `Design` · `Size` · `Pcs` · `GrWt` · `OthWt` · `NetWt` · `Rate` · `ItAmt` · `Lbr%` · `Ltype` · `LRate` · `LAmt` · `OthAmt` · `Tag%` · `TagLRate` · `TagLAmt`. Example: `CH916 · CHG00002 · CHAIN 916 · 001 · 1 · 15.000 · 15.000 · 4800 · 72000 · LRate 600→700 · LAmt 9000`. Operator may **re-set the making charge** on the returning item (*“600 की जगह ₹700 पर ग्राम”*) and MRP if MRP-tagged.
- **Right tender/total panel:** `Net Amt` (`81000`) · `Sale Tax :` `GST 3%` → `3.00` → `2430.00` · `Total Amt :` (`83430`) · `Cheque Amt :` · `Card Amt :` · `Cash Amt :` · `Kasar Amt :` · `Os Amt :` (`83430`), with `Payment`/`Received` columns. Bottom-left `Ac Cr Amt` `81000.00` (green) / `Ac Dr Amt` `0.00` (blue), and `83430.00 : Cr` party credit.

### 3.3 Operator workflow
`Tran 1 → Sales Return` → `Sale Bill` field → pick original invoice → confirm barcode reuse/new → return lines auto-fill → optionally edit `TagLRate`/making-charge & MRP for the re-stocked item → **refund** via `Cheque/Card/Cash Amt` **or** leave blank to **credit the party's account** (*“कुछ भी अमाउंट डालना नहीं है … अकाउंट में क्रेडिट कर देना है”*) → **Save** → **View** credit-note receipt.

### 3.4 Effects
- **Tables:** `SL_DATA` (credit-note header) + `SL_DETL_RTN` (return lines) + `MAIN_STOCK` (returned tag **back in**, VCH_TYPE `CRNOT`, sign `+`) + `AC_DATA` + `TAX_DATA` (reverses output GST) + `BILL_OS_DATA` (adjusts outstanding).
- **Ledger (`AC_DATA`):** **Cr customer** for the credit-note total (e.g. `83430 Cr` to RAKESH BHAI SONI when not refunded) · **Dr Sales/Sales-Return** (reduce income, `81000`) · **Dr GST output** (`2430`, reverse). If refunded, **Dr customer / Cr Cash/Bank** instead.
- **Stock:** verified in **Tag Stock Report** (kf_044) — the returned tag re-enters as `VCH_TYPE=CRNOT · CHG00002 · CH916 · 15.000 · LbrRate 700` under the **In Tag** tab. Report tabs: `In Tag · Out Tag · Stock Tag · Mrp Tag · Apr Panding · All Tag`; columns `Vch Typ · Vch No · Stk Date · Tag No · It Code · Counter · Design · Size · Qty · Pcs · Grwt · Net Wt · Lbr Rate · Lbrprc · Lbr Amt · Oth Amt · Mrp · Kr Name · Tag Id`.

### 3.5 Cross-module connections
Depends on **Sales Invoice** (SL_DATA source), Party master, Tag/stock engine (re-issues a tag). Feeds Ledger Report (party credit), Tag Stock (In Tag), GST (credit note in GSTR-1), Bill outstanding.

### 3.6 Web parity — `/txn/sale-return` (`sales/salesReturn.ts`)
Module present. **Parity = to-verify:** confirm the web page implements the **`Sale Bill` import picker** (VchNo/Date/Party/Book/BillAmt), the barcode reuse/new prompt, the **Receive-Item re-stock grid** with editable `TagLRate`/MRP, the refund-vs-credit tender split, and that it writes `SL_DETL_RTN` + `MAIN_STOCK` (CRNOT, +) + reverses `TAX_DATA`.

---

## 4 · Bank Received & Bank Payment  ·  `AdgxtGwjrfc` → `/txn/receipt` + `/txn/payment` (bank)

Mirror of screens 2 but settled through **bank** ledgers, and it shows the **prerequisite masters**: a bank **Party account** and a per-bank **Book**.

### 4.1 Menu path
- **Bank Received:** `Tran 1 → Bank Received`; **Bank Payment:** `Tran 1 → Bank Payment`. After creating per-bank books, the node lists one entry per bank (e.g. **HDFC Bank Rec**, **ICICI Bank Rec**). Banners: **HDFC BANK REC** / **HDFC BANK PAY**.

### 4.2 Prerequisite masters (shown in-video)
- **Party Master** (`Master → Party`, kf_012) to create each bank as an account. Fields: `Ac Code` (`000203`) + `F1`/`D`/`S` · `Ac Name` (`HDFC BAN`) · `Ac Group` (Bank **Current A/C = group 22**, Bank **Saving = 23**) · `Mobile No`/`Phone No` · `Con Person`/`Ac Short` · `Address1/2/3` · `City`/`Pin Code` · `City Area` · `Country` · `Gst No` + `Local` · `Pan No` · `State` (Gujarat) · `District` · `Email`; **Opening Balance** (Amount/Gold/Silver, each Cr/Dr); tabs `Company Detail · Other Detail · Family Detl`.
- **Book Master** (`Company → Books`, kf_030/kf_048): create a **Received** book and a **Payment** book per bank. Fields: `Book Code` · `Book Name` (`HDFC BANK REC` / `HDFC BANK`) · `Book Short` (`BREC`/`BPAY`) · `Cur In Use` (Yes/No) · **`Transaction`** (`BANK REC` / `BANK PAY`) · `Item Type` (All) · `Tran In/Out` (`Inword`/`Outword`) · `Invoice Type` (Free) · `ReSet Book` (N) · `Trfr` (N) · `Vch Serice`. Sub-grid `Sr · Account Desc · AcCode · AcName` maps default legs: `BANK A/C 00075`, `KASAR JAVK/AVAK A/C`, `BANK CHARGES A/C 00048`. Names must be unique → operator suffixes `REC`/`PAY`.

### 4.3 Transaction form (kf_062 received, kf_086 payment)
- **Header:** `Vch No` + `F1` · `Vch Date` + time + weekday. Right shows party balance / `14290.00 : Dr Amt`.
- **Grid columns:** `Sr` · `AcCode` · `Ac Name` · **`Chq No`** · `Amount` · `Kasar` (the extra **`Chq No`** column vs the cash screens). Footer `It Desc`, `Employe`; **Bank Payment adds `Chq Print`** field + a **`Chq`** button on the action bar (cheque printing).
- Multiple lines allowed (e.g. Bank Payment pays `SHOP EXP. A/C` and `ELECTRIC BILL EXP.A/C` in one voucher).

### 4.4 Operator workflow
Create bank party (Master→Party, group 22/23) → create HDFC/ICICI **Rec** and **Pay** books (Company→Books, Transaction=BANK REC/PAY) → `Tran 1 → Bank Received → HDFC Bank Rec` → pick party → enter `Chq No`/RTGS ref → `Amount` (e.g. `6000`) → **Save** → View receipt. Payment mirrors it (`SHOP EXP` `3000`, cheque print optional).

### 4.5 Effects (verified `finance/finance.ts`)
- **Bank Received → `postReceipt(mode='cheque'|'bank'|'card'|'upi')`:** settlement `recAc = bankAc`; `AC_DATA` **Dr Bank / Cr party** (VCH_TYPE **`BREC`**); header → `CASH_DATA` (REC_AC_CODE = bank, `CHQ_NO`). Card mode also writes `CARD_DATA` (commission split); UPI writes `UPI_DATA`.
- **Bank Payment → `postPayment`:** `AC_DATA` **Dr party/expense / Cr Bank** (VCH_TYPE **`BPAY`**); header → `PAY_DATA` (`BANK_AC`, `CHQ_AMT`, `CHQ_NO`).
- **Ledger Report** confirms (kf_074, kf_094): `HDFC BANK` +6000 Dr on receipt, then falls to `2500` after paying `SHOP EXP 3000` + `ELECTRIC BILL EXP 500`.

### 4.6 Cross-module connections
Depends on **Party master** (bank accounts, groups 22/23) and **Book master** (per-bank BANK REC/PAY books). Feeds Ledger Report, Bank Reconciliation (`BANK_RECONCILE`), cheque printing. No stock/tax impact.

### 4.7 Web parity — `/txn/receipt`, `/txn/payment` (bank)
`finance.ts` supports `mode` = cheque/card/upi/bank with a `bankAc`, so **service parity = matches**. **Gap/to-verify:** the desktop **per-bank Book** concept (each bank = its own Received/Payment book with default KASAR/BANK-CHARGES legs) → confirm the web lets the user pick the bank ledger, exposes the `Chq No` grid column, the multi-line grid, `Chq Print`, and the cheque-print action.

---

## 5 · Sales Order  ·  `Sq-Xo4E5GTE` → `/txn/sales-order`

Records a customer order for later fulfilment (**not** a sale — no income recognised). Advance may be taken.

### 5.1 Screen title + menu path
`Tran 1 → Sales Order` → tab **Sales Order 1**, banner **Sales Order**.

### 5.2 Header + grids (kf_004)
- **Header:** `Vch No` (`00002`) + `F1` + **`All`** button · `Vch Date` (`26/05/2021`) + time + weekday (`Wednesday`) · `Ref No` · `Party` (`00020` default order-advance a/c, or a real party e.g. `VIKAS BARVADIYA`) · `: Amt`.
- **Main grid columns:** `Sr` · `TagNo` · `ItCode` · `Design` · `Size` · `Pcs` · `GrWt` · `LsWt` · `NetWt` · `ItRate` · `ItAmt` · `Lbr%` · `LbrRate` · `LbrAmt` · `OthAmt` · `TotAmt` · `Tax%` · `NetAmt` (same as the sale grid). `Remark` field beneath.
- **Charges sub-grid:** `Sr` · `ItCode` · `ItName` · `Pcs` · `Weight` · `Con%` · `P/W` · `Rate` · `ItAmt` · `NetAmt`.
- **Old-gold sub-grid:** `Sr` · `ItCode` · `ItName` · `Pcs` · `GrWt` · `NetWt` · `Touch` · `Fine` · `Rate` · `NetAmt`.
- **Right advance/total panel:** `Net Amt :` (`66780`) · `Tax Amt :` · `Total Amt :` · `Cash Amt :` · `Cheque Amt :` · `Card Amt :` · `Old Gold Amt :` · `Old Silver Amt :` · `Scheme Amt :` · **`Tot Adv Amt :`** (the advance received against the order).
- **Footer:** `Employe` · `Bank` · `Vch Date` (delivery date) · photo/scan buttons · `Vch`.

### 5.3 Operator workflow
`Tran 1 → Sales Order` → Enter×3 → default advance a/c (`20`) or pick real party → grid: pick item (tag or manual `ItCode`), key `Design`, `Size` (e.g. 18 inch), `Remark`, `Pcs`, `GrWt`, `LsWt` → **fix the rate** (e.g. gold `4800`) and **making** (`500`/g) so the order price is locked → Esc to right panel → record **advance** in `Cash/Cheque/Card Amt` (e.g. cash `30000`) → **Save** → **View** the Sales-Order receipt (with QR/photo).
**Fulfilment:** later in `Tran 1 → Sales`, the invoice has an **`Order Amt` / `Ord No`** field — key any char, Enter, pick the party's pending order; the **advance is deducted** from the bill total (`SL_ORD_ADJ`), and `F1` on the rate recalls the locked rate/making.

### 5.4 Effects (verified `sales/salesOrder.ts`)
- **Tables:** `SL_ORD_DATA` (header: NET_AMT, TAX_PRC, TAX_AMT, TOT_AMT, **ADV_AMT**, DEL_DATE) · `SL_ORD_DETL` (lines: ITM_PCS/GWT/NWT/TOUCH/FINE/RATE/AMT, LBR_AMT, NET_AMT, ITM_REMARK, DESIGN_NO) · `SL_ORD_IDTL`. Adjust-into-sale via `SL_ORD_ADJ`.
- **Ledger (`AC_DATA`, VCH_TYPE `SORD`, book `SOR`):** only if an advance is taken → **Dr `CASH` / Cr customer** (advance = customer liability). **No income leg** (order ≠ sale). `fine = net×touch/100`, `metal = fine×rate`, `making = net×making/g`.
- **Order Cancel** (`cancelSalesOrder`): removes SL_ORD_DATA/DETL/IDTL + reverses advance AC_DATA + DELETE_DATA — **blocked** if any line is already issued to manufacturing (`DESIGN_ISU='Y'`), tagged (`TAG_GEN='Y'`) or delivered (`TAG_SALE='Y'`).

### 5.5 Cross-module connections
Party master; **feeds the Sales Invoice** (advance adjust via `Ord No`/`SL_ORD_ADJ`); **Order Report** (`Reports → Order Report`, kf_008) with three views — **Order Report** (order lines/size/wt/rate), **Order Advance** (advance by mode), **Order Adjust** (pending vs cleared). Also feeds manufacturing (design issue) and Labour Invoice (order-gold credit, see §10). Order-cancel screen `/txn/order-cancel`.

### 5.6 Web parity — `/txn/sales-order` (`sales/salesOrder.ts`)
`createSalesOrder` + `cancelSalesOrder` implement the header/detail/advance-ledger and the cancel guards. **Parity = to-verify:** confirm the web page renders the full item grid (5.2), the advance tender panel incl. `Tot Adv Amt`, the delivery-date field, and that `/txn/sales` performs the **advance adjustment** (`SL_ORD_ADJ`) when an order is selected.

---

## 6 · Purchase Voucher  ·  `lqJjexUe4MA` → `/txn/purchase`

Buying metal/ornaments from a supplier/karigar, with optional inline **barcode tagging** of the bought stock.

### 6.1 Screen title + menu path
`Tran 1 → Purchase` → **book chooser** (kf_002) with **Gold Purchase (Tax)**, **Gold URD Purchase**, **Silver Purchase**, **Silver URD Purchase** (URD = Un-Registered Dealer, i.e. old metal from the public). Double-click e.g. *Gold Purchase Tax*.

### 6.2 Header + grids (exact fields captured in `wuIFZsCf4Mw` purchase-entry frames; tagging screens kf_005/kf_006)
- **Header:** `Vch No` (+`F1`) · `Vch Date` (+time+weekday) · `Ref No` · `Party` (supplier/karigar; **F1** creates inline — e.g. *ABC Jewellers*, AC group `05` = Supplier) · `Item Wt` (2 boxes) · `Sl Bil No` (supplier bill no) · right `: Amt / : Gold / : Silvr`.
- **Main grid columns:** `Sr` · `ItCode` · `ItName` · `Pcs` · `GrWt` · `OthWt` · `NetWt` · `Touch` · `West%` (wastage) · `Fine` · `Rate` · `ItAmt` · `Ltype` · `LRate` · `LAmt` · `OthAmt` · `TotAmt`. `F1` item picker columns: `ItemName · ItCode · Group`.
- **Main line entry:** pick product (e.g. **Gold Ornament** — bought in bulk/loose), `Pcs` (e.g. 2), total `GrWt` (e.g. 34 g); on `GrWt` a **detail box** opens for `Stone/Diamond/other weight` → `NetWt`; `LsWt` (less) editable; `Rate` (e.g. `4800`) → line amount; optional `Making`; `TotAmt`.
- **Right tender panel:** `Net Amt · Disc Amt · Tax Amt` (**3% GST** auto) `· Tcs Amt · Rof Amt · Total Amt · Cheque Amt · Card Amt · Cash Amt · Kasar Amt · Os Amt`; running balance (`166600`); settlement via cheque/card/cash (narration pays supplier by cheque, e.g. HDFC).
- **Inline tagging** (bottom line "Ad Menu → **Only Tag Entry**", or `Other → Only Tag Entry`, kf_006): convert the loose purchased metal into barcoded tags. Grid columns: `Sr` · `ItCode` · `TagNo` · `Counter` · `Design` · `Size` · `Pcs` · `GrWt` · `LsWt` · `NetWt` · `Lbr%` · `LbrRate` · `LbrAmt` · `OthAmt` · `PrCost` · `Mrp` · `Image` · `KrCode`; header also `Item Wt`, `It Code`, `Print file` (`QrPrint10`) + `Set`, `Lable Skip`. Sub-grid: `Sr · ItCode · ItName · Pcs · KrWt · Weight · Con% · P/W · Rate · ItAmt · NetAmt`. **Printed tag** (kf_005): `CHG00009 · G.19.400 · N.19.400 · LP:600 · 916 · DATACARE SOFTECH` + QR.

### 6.3 Operator workflow
`Tran 1 → Purchase → Gold Purchase Tax` → Enter×3 → pick/`F1`-create supplier → product = **Gold Ornament**, Pcs `2`, GrWt `34` (stone/diamond detail box) → Rate `4800` → making (optional) → 3% GST auto → settle (cheque via HDFC) → **Save**. Then **Only Tag Entry**: select the loose *Gold Ornament* lot → it shows pending pcs/weight → create each tag (Chain 916, 1 pc, 14.600 g, making) → **Save** → **View** prints QR barcodes. Repeat for each piece. Stock (F3 bulk / **F12 Tag-wise**) now shows the new tags.

### 6.4 Effects (verified `purchase/purchase.ts`)
- **Tables:** `PR_DATA` (header: NET_AMT, DISC_AMT, TAX_PRC, TAX_AMT, CGST/SGST/IGST, ROF_AMT, TOT_AMT, HM_*) · `PR_DETL` (lines, INOUT_TYPE `I`, ENTRY_TYPE `P`) · `MAIN_STOCK` (each tag **in**, VCH_TYPE `TGPR`, TR_TYPE `P`, `ITM_SIGN='+'`) · `TAX_DATA` (input register, `TAX_SIGN='-'`) · `BILL_OS_DATA` (payable). Tags created via `createTagTx` (STK_TYPE `R`).
- **Ledger (`AC_DATA`, VCH_TYPE `PURC`) — mirror of sales:** **Cr supplier** (total incl. tax) · **Dr `PURCHASE`** (taxable, split per-group via `GROUP_MAST.PURC_AC`) · **Dr `GSTINPUT`** (input GST) · **Dr `ROUNDOFF`**. Plus a **metal fine sub-ledger leg** (IT_TYPE `G`/`S`, `SIGN='+'`, `FINE_WT=Σfine`, DR=CR=0). **Hallmark purchase** (TR_PURC_HM): Dr `HMCHRG` + Dr input-GST / Cr supplier.
- **Delete** (`deletePurchase`): removes PR_DATA/PR_DETL/AC_DATA/TAX_DATA/BILL_OS_DATA/MAIN_STOCK + removes the created tags (rejects if a tag was already sold) + DELETE_DATA.

### 6.5 Cross-module connections
Supplier/karigar master (F1), Product/Item master, **Tag/stock engine** (createTag → TAG_STOCK/TAG_DATA), GST input (GSTR-2), Bill outstanding (payable), Barcode/QR printing (`QrPrint10`). Feeds the Sales screen's barcoded stock.

### 6.6 Web parity — `/txn/purchase` (`purchase/purchase.ts`)
`createPurchase` implements the mirror ledger, per-group `PURC_AC` split, metal-fine leg, hallmark, tag stock-IN, and all satellite tables. **Parity = matches** at service layer. **To-verify:** the four books (Gold/Gold-URD/Silver/Silver-URD) incl. **URD/reverse-charge** handling, the stone/diamond weight detail box, and the **Only Tag Entry** tagging screen (columns in 6.2) with QR-label printing.

---

## 7 · Purchase Return — Debit Note  ·  `wuIFZsCf4Mw` → `/txn/purchase-return`

Return bought goods to a supplier. Requires a prior purchase (video re-creates one first).

### 7.1 Screen title + menu path
`Tran 1 → Purchase Rtn` → tab **Purchase Rtn 1**, banner **Debit Note**.

### 7.2 Header + grid (kf_016–kf_028)
- **Header:** `Vch No` (`00001`) + `F1` · `Vch Date` (`28/05/2021`) + time + weekday (`Friday`) · `Ref No` · `Party` (supplier `000205` `ABC JEWELLERS`) · right `: Amt / : Gold / : Silvr`.
- **Main grid columns:** `Sr` · `TagNo` · `ItCode` · `ItName` · `Counter` · `Pcs` · `GrWt` · `OthWt` · `NetWt` · `Touch` · `West%` · `Fine` · `Rate` · `ItAmt` · `Ltype` · `LRate` · `LAmt` · `OthAmt` · … Example row: `ORG · GOLD ORNAMETNS · 1 · 12.000 · 0.000 · 12.000 · Fine 12.000 · Rate 4800 · ItAmt 57600`.
- **Footer:** `Employe` · `Bank` · `Vch Desc`.
- **Right tender panel:** `Net Amt :` (`57600`) · `Disc Amt :` · `Tax Amt :` `GST 3%` → `3.00` → `1728.00` · `Rof Amt :` · `Total Amt :` (`59328`) · `Cheque Amt :` (`HDFC BANK` `59328`) · `Card Amt :` · `Cash Amt :` · `Kasar Amt :` · `Os Amt :` (`0.00` after refund). Bottom: `59328.00 : Cr Amt`.

### 7.3 Operator workflow
`Tran 1 → Purchase Rtn` → Enter → pick supplier (`ABC JEWELLERS`) → grid: `TagNo` (if barcoded) or `ItName` (e.g. *Gold Ornament*) → Pcs `1`, NetWt `12`, `Rate` `4800` → 3% GST auto (`1728`) → in the tender panel record how the supplier settled: `Cheque Amt` `59328` → pick the receiving bank (**HDFC**) → `Os Amt` becomes `0` → **Save** → **Exit**. (Leaving tender blank instead credits the supplier's account.)

### 7.4 Effects
- **Tables:** `PR_DATA` (debit-note header) + `PR_DETL` (return lines) + `MAIN_STOCK` (goods **out** to supplier, sign `-`) + `AC_DATA` + `TAX_DATA` (reverses **input** GST) + `BILL_OS_DATA` (adjusts payable).
- **Ledger (`AC_DATA`) — reverse of a purchase:** **Dr supplier** (reduce payable / or the cash-back leg) · **Cr `PURCHASE`** (`57600`, reduce expense) · **Cr `GSTINPUT`** (`1728`, reverse input GST). When money is refunded, **Dr Bank/Cash** (`HDFC 59328`) so the supplier nets to `0` (`Os Amt 0`).
- **Stock:** the returned metal leaves inventory (loose `Gold Ornament` here; a tagged return removes the tag).

### 7.5 Cross-module connections
Depends on the original **Purchase** (PR_DATA) and supplier master; feeds Ledger Report, GST input register (GSTR-2 reversal), Bill outstanding (payable), Tag/stock.

### 7.6 Web parity — `/txn/purchase-return` (`purchase/purchaseReturn.ts`)
Module present. **Parity = to-verify:** confirm the web page implements the debit-note grid (7.2), the refund-vs-credit tender split, the reverse-purchase ledger (Dr supplier / Cr purchase + Cr input-GST, optional Dr bank), stock-out, and `TAX_DATA` reversal.

---

## 8 · Contra Entry  ·  `tSRFXH2BoZ0` → `/txn/contra`

Cash↔bank transfers (deposit cash to bank / withdraw cash from bank). **Both sides must be equal.**

### 8.1 Screen title + menu path
`Tran 1 → Contra Entry` → tab **Contra Entry 1**, banner **Contra Entry**. Primary use per narration: *“कोई कैश बैंक में डिपॉजिट करते हैं तो … कॉन्ट्रा एंट्री”* (deposit cash into bank / receive cash from bank).

### 8.2 Header + grid (kf_013–kf_026)
- **Header:** `Vch No` (`00001`) + `F1` · `Vch Date` (`28/05/2021`) + time + weekday (`Friday`).
- **Grid columns:** `Sr` · `Cr/Dr` · `AcCode` · `Ac Name` · `It Desc` · `CrAmt` · `DrAmt`. Two lines: line 1 = **DR** the destination (e.g. `000203 HDFC BANK`, DrAmt `10000`), line 2 = **CR** the source (auto `CR`, `CASH ON HAND`, CrAmt `10000`). `Total :` shows the Cr / Dr column sums; the right shows the picked account's balance (`2500.00 : Dr Amt`).
- **Footer:** `Employe`. **Save → print dialog** (Original/Duplicate/Triplicate, View/Print/Exit) — receipt usually not needed.
- **Rule:** *“दोनों अमाउंट सेम होनी कंपलसरी है”* — DrAmt must equal CrAmt or the voucher won't save.

### 8.3 Operator workflow
`Tran 1 → Contra Entry` → line 1 `Dr` → pick bank (`HDFC BANK`) → `It Desc` (optional) → `DrAmt` `10000` → Enter → line 2 auto `Cr` → pick `CASH ON HAND` → `CrAmt` `10000` (equal) → **Save**. (For a withdrawal, swap: Dr Cash / Cr Bank.)

### 8.4 Effects (verified `finance/finance.ts` → `postContra`)
- **Tables:** `CONTRA_DATA` (`SR_NO`, `AC_CODE`=toAc, `LD_CODE`=fromAc, `DR_AMT`, `CR_AMT`, VCH_TYPE `JV`, VCH_DATE) + `AC_DATA`.
- **Ledger (`AC_DATA`, VCH_TYPE `JV`, book `CON`):** **Dr `toAc` / Cr `fromAc`** for the same amount. Example (kf_035): Contra `00001` posts **`HDFC BANK` +10000 Dr** and **`CASH ON HAND` −10000** → bank balance `12500 Dr`, cash `76372 Dr`. Guards: `fromAc ≠ toAc`, amount > 0.
- No stock/tax impact.

### 8.5 Cross-module connections
Bank & cash accounts (AC_MAST). Verified in **Ledger Report** per-account (kf_035) — columns `Sr · Book · VchNo · Date · Party Name · Cr Amt · Dr Amt · Bal Amt · CrDr · Cr Gold · Dr Gold · Bal Gold`. Feeds Bank Reconciliation, day-book/RojMel. Note the desktop treats Cash Received/Payment and Bank Received/Payment as alternative ways to record the same transfers.

### 8.6 Web parity — `/txn/contra` (`finance/finance.ts` → `postContra`)
`postContra` writes the balanced Dr/Cr transfer and `CONTRA_DATA` with the `AC_CODE`/`LD_CODE` mapping and equal `DR_AMT`/`CR_AMT`. **Parity = matches.** **To-verify:** the web page exposes the two-line `Cr/Dr · AcCode · Ac Name · It Desc · CrAmt · DrAmt` grid and enforces the equal-amounts rule client-side.

---

## 9 · Approval Issue / Approval Return (Tour)  ·  `DpdQpC7Od2M` → `/txn/tour` + `/txn/tour-return`

Give tagged stock to a party/salesman **on approval** (goods out but not sold), then take back what isn't kept; bill the rest.

### 9.1 Screen title + menu path
- **Approval Issue:** `Tran 2 → Approval Isu` → tab **Approval Isu 1**, banner **Approval Issue**.
- **Approval Return:** `Tran 2 → Approval Rtn` → tab **Approval Rtn**, banner **Approval Return**.
- (Tran 2 sidebar "Pro": Approval Isu · Approval Rtn · Labour Work · Fine Jv Entry · Old Item Sales · Bill Wise Rec · Other Expenses · Other Income.)

### 9.2 Header + grid (kf_004 issue, kf_010 return)
- **Issue header:** `Vch No` (`00002`) + `F1` · `Vch Date` (`30/05/2021`) + time + weekday (`Sunday`) · `Party Code` (`RAKESH BHAI SONI`).
- **Return header:** adds **`Isu No`** (+`F1`) to pick the original issue voucher to pull items from.
- **Main grid columns (both):** `Sr` · `TagNo` · `ItCode` · `Counter` · `Design` · `Size` · `Pcs` · `GrWt` · `LsWt` · `NetWt` · `Touch` · `West%` · `Fine` · `ItRate` · `ItAmt` · `LbrRate` · `LbrAmt` · `OthAmt` · `Mrp`. Display list shows `SNO · Item Name · Pcs · Gr Wt · Net Wt · Rate · Item Amt · Oth Amt · Net Amount` (e.g. `CHG00004-CHAIN 916`, `CHG00005-CHAIN 20C`, `CHG00006-CHAIN 20C`; Total `3` pcs `42.000` g). Charges sub-grid: `Sr · ItCode · ItName · Pcs · Weight · KrWt · Con% · P/W · Rate · ItAmt · NetAmt`. Footer `Employe`, `Vch Desc`.

### 9.3 Operator workflow
**Issue:** `Tran 2 → Approval Isu` → pick party (*Rakesh Bhai Soni*) → scan/select multiple tags (Chain #4, #5, #6) → **Save** → **View** the approval-issue receipt. Stock leaves *Stock Only* → sits in **Pending Approval** (not sold).
**Return:** `Tran 2 → Approval Rtn` → `Isu No` → pick the issue voucher (all items load); **cancel-all** then scan **only the returned tags** (e.g. #4 and #6 back; #5 kept) → **Save**.
**Bill the kept item:** `Tran 1 → Sales` has an **`Apr No`** field — select the approval to pull item #5 into a Tax Invoice and bill it normally.

### 9.4 Effects
- **Tables:** `APR_DATA` (header) · `APR_DETL` (lines) · `APR_IDTL` (tag detail) · `MAIN_STOCK` (issue = tag **out** to "Pending Approval"; return = tag **back in**). **No `AC_DATA`/money** — approval is a stock-custody movement, not a sale (money only when the kept item is invoiced in Sales).
- **Stock states:** *Stock Only* → *Pending Approval* (on issue) → *Stock Only* (on return) or *Out/Sold* (when billed). Verified in Tag-wise Stock (F12) "Apr Panding" tab.

### 9.5 Cross-module connections
Depends on Tag/stock (barcoded items) + Party master. Feeds **Approval Report** (`Reports → Approval Rpt`, kf_006/kf_008) with three views: **Approval Isu** (issued, barcode-wise), **Approval InOut** (Out Pcs / In Pcs / **Panding** per item), **Approval Panding** (only pending). Feeds the Sales screen (`Apr No`) for final billing.

### 9.6 Web parity — `/txn/tour` + `/txn/tour-return` (`tour/tour.ts`)
Module present ("tour" = approval — a salesman takes goods on tour/approval). **Parity = to-verify:** confirm issue writes `APR_DATA/APR_DETL/APR_IDTL` + moves tags to a pending state (no ledger); return pulls by `Isu No` and supports **partial** return; and that `/txn/sales` can bill from an `Apr No`. Also confirm the three Approval reports.

---

## 10 · Labour Invoice (Karigar labour bill)  ·  `tLThVxaKF5o` → `/txn/labour-sale`

Bill only the **making charge** when the customer supplied the gold (via a Sales Order gold credit). **Dual GST**: 3% on the metal value + 5% on the labour — the distinguishing feature of this screen.

### 10.1 Screen title + menu path
`Tran 2 → Labour Work` → tab **Labour Work**, banner **Labour Invoice**. Prerequisite: a **Sales Order** capturing the customer's advance **old-gold credit** (kf_012/kf_024: order for *RONAK JI*, Chain 916 ~15 g, customer gave 10 g old gold).

### 10.2 Header + grids (kf_044, kf_052)
- **Header:** `Vch No` (`00001`) + `F1` · `Vch Date` (+time+weekday) · **`Item`** dropdown (`Gold`) · `Party` (`000206` `RONAK JI`) · `: It Name`.
- **Main grid columns:** `Sr` · `TagNo` · `ItCode` · `ItName` · `Design` · `Pcs` · `GrWt` · `OthWt` · `NetWt` · `Touch` · `Fine` · `LType` · `LbrRate` · `LbrAmt` · `OthAmt` · `NetAmt`. Example row: `CH916 · CHAIN 916 · 1 · 16.000 · Fine 16.000 · LbrRate 600 · LbrAmt 9600`.
- **Order-gold credit panel (bottom-left):** grid `Sr · Ord No · Ord Weight · Ord Amt` (e.g. `00002 · 10.000`); plus `Tot Wt Dr` (`16.000`) · `Tot Wt Cr` · `Order Wt` (`10.000`) · `1gm Rate` (`4800`) · `Cr Fine` · `Dr Fine` (`6.000`) · `Cr Amount` · `Dr Amount` (`28800`). Logic: item made `16 g`; order-gold credit `10 g`; **chargeable metal = 6 g × 4800 = 28800**.
- **Right dual-GST tender panel:** `Net Amt :` (`28800`) · **`Sale Tax :` `GST 3%` → `3.00` → `864.00`** (GST on metal) · `Lbr Amt :` (`9600`) · `Lbr Disc :` · **`Lbr Tax :` `GST 5%` → `5.00` → `480.00`** (GST on making) · `Total Amt :` (`39744`) · `Cheque Amt :` · `Card Amt :` · `Order Amt :` · `Cash Amt :` · `Kasar Amt :` · `Os Amt :` (`39744`), with `Payment`/`Received` columns. Metal balances shown: `10.000 : Cr Gold` / `4.000 : Cr Gold`, `10080.00 : Dr`. Footer `Cr Days`, `Employe`, `Vch Desc`.

### 10.3 Operator workflow
1. First `Tran 1 → Sales Order` for the party, capturing their **old-gold credit** (10 g) against the item to be made.
2. `Tran 2 → Labour Work` → pick party (*Ronak Ji*) → item **Chain 916** (manual or barcode), Pcs `1`, made-weight `16 g` → `LbrRate` `600`/g → `LbrAmt` `9600`.
3. In `Ord No` key any char → Enter → pick the party's order → the **10 g gold credit** is deducted (`Order Wt 10.000`); remaining `6 g` valued at `1gm Rate 4800` → `Dr Amount 28800`.
4. GST auto: **3% on `28800` = `864`** (metal) + **5% on `9600` = `480`** (labour) → `Total 39744`.
5. Settle (cheque `39744` → pick HDFC bank) → **Save** → **View** the Labour Invoice (shows gold-rate and making-charge GST separately).

### 10.4 Effects
- **Tables:** `LBR_DATA` (header) · `LBR_ISU_DETL` / `LBR_ISU_IDTL` (issue/made lines) · `LBR_REC_DETL` (metal received/credit) · `AC_DATA` · `TAX_DATA` (**two rows**: metal `GST 3%` + labour `GST 5%`) · `BILL_OS_DATA` · metal fine sub-ledger for the order-gold credit. `LBR_MAST` for labour-rate masters.
- **Ledger (`AC_DATA`):** **Dr customer / Cr Bank** for the amount paid now; **Cr labour income** (`9600`) · **Cr metal-sale** for the chargeable 6 g (`28800`) · **Cr GST** (`864` @3% + `480` @5%). The **10 g order-gold credit** posts as a metal (Cr Gold) fine-weight adjustment, not cash.

### 10.5 Cross-module connections
Depends on **Sales Order** (old-gold credit via `Ord No`), Party master, Item/rate masters, Karigar (goldsmith). Feeds Ledger, GST reports (two-rate rows), Labour Work report (`LbrWorkRpt.rpt`), metal (fine) ledger.

### 10.6 Web parity — `/txn/labour-sale`
Web route present. **Parity = to-verify / likely gap:** confirm a labour service exists (candidate: a labour module, or `manufacturing/karigar.ts`) that (a) pulls the **Sales-Order gold credit** by `Ord No`, (b) charges only the surplus metal + making, and critically (c) applies the **dual GST (3% metal + 5% labour)** with separate `Sale Tax`/`Lbr Tax` rows in `TAX_DATA`. This dual-rate GST is unique to Labour and must be replicated exactly.

---

## 11 · Other Expenses  ·  `f2mXV47LSXk` → `/txn/other-purchase`

A **non-stock** expense purchase (AC, packing, shop items…) from a GST supplier, to claim **input GST credit**. HSN-based, supports forward or reverse GST.

### 11.1 Screen title + menu path
`Tran 2 → Other Expenses` → tab **Other Expenses 1**, banner **Other Expenses**.

### 11.2 Header + grid (kf_008–kf_040)
- **Header:** `Vch No` (`00001`) + `F1` · `Vch Date` (+time+weekday) · `Bill No` (`123`) · `Bill Date` · `Party` (supplier `000207 ABC APL…`, `F1` to create — its **GST No is compulsory** for input credit) + `L` button · `Ledr Code` (expense head, default `00060 SHOP EXP. A/C`, editable) · right `: Amt / : Gold / : Silvr`.
- **Main grid columns:** `Sr` · `HsnCode` · `ItName` · `TaxCode` · `Tax%` · `NetAmt` · `TaxType` · `TaxableAmt` · `IGSTamt` · `CGSTamt` · `SGSTamt` · `TotalAmt`. Unknown HSNs prompt **“Add New HsnNo ?”** (Yes saves to an HSN master for reuse).
- **`TaxType` F vs R:** `F` = **Forward** (GST added on top: `NetAmt 30000` @28% → CGST `4200` + SGST `4200` → `TotalAmt 38400`, kf_030). `R` = **Reverse** (GST **included** in the amount, back-calculated: `NetAmt 30000` → `TaxableAmt 23437.50` + CGST `3281.25` + SGST `3281.25` → `TotalAmt 30000`, kf_036). Narration: *“रिवर्स आर … ये जीएसटी … इंक्लूड कर देना है”*.
- **Right tender panel:** `Net Amt` · `IGST Tax` · `CGST Tax` · `SGST Tax` · `Total Amt` · `Cheque Amt` · `Card Amt` · `Cash Amt` · `Kasar Amt` · `Os Amt`. Footer `Employe`, `Bank`, `Vch Desc`. Cheque → bank picker (HDFC/ICICI, kf_040).

### 11.3 Operator workflow
`Tran 2 → Other Expenses` → `Bill No`/`Bill Date` → `F1` create supplier (with GST No) → `Ledr Code` = expense head (e.g. *Shop Expense*) → grid: `HsnCode` (e.g. `12345`, add-to-master), `ItName` (`AC`), `Tax%` (`28`), `TaxType` (`F` or `R`), `NetAmt` (`30000`) → GST computes → Esc to tender → `Cheque Amt` (`30000`) via HDFC → **Save**.

### 11.4 Effects (verified `purchase/purchase.ts` → `createOtherPurchase`)
- **Tables:** `PAY_DATA` (header: NET_AMT, CGST/SGST/IGST_TAX, TOT_AMT, BILL_OS) · `TAX_DATA` (**input** register, `TRAN_TYPE 'P'`, `BOOK_NAME 'OTH PURC'`, `TAX_SIGN '-'`) · `BILL_OS_DATA` (payable). **No stock/inventory.**
- **Ledger (`AC_DATA`, VCH_TYPE `OPUR`, book `OPR`):** **Cr supplier** (total) · **Dr expense** account(s) (per line) · **Dr `GSTINPUT`** (input GST) · **Dr `ROUNDOFF`**.

### 11.5 Cross-module connections
Supplier master (GST No), expense-head ledgers, **HSN master**, GST input register (GSTR-2), Bill outstanding (payable). No tag/stock.

### 11.6 Web parity — `/txn/other-purchase` (`purchase/purchase.ts` → `createOtherPurchase`)
`createOtherPurchase` posts the Cr-supplier / Dr-expense / Dr-input-GST ledger and writes `PAY_DATA` + `TAX_DATA` + `BILL_OS_DATA`. **Parity = matches** for the forward-GST path. **Gap/to-verify:** the desktop grid is **HSN-driven** with per-line `TaxCode`/`Tax%` and a **`TaxType` F/R (forward vs reverse/inclusive)** toggle; the current web input takes plain expense lines (amount + forward GST only). Add HSN master, per-line tax rate, and the **reverse (GST-inclusive) calculation** for exact parity.

---

## 12 · Bill-Wise Amount Received (Bill-to-Bill)  ·  `sE2H-ztIINE` → `/txn/bill-to-bill`

Receive money from a party and **allocate it against that party's specific outstanding invoices** (bill-by-bill), rather than a lump credit.

### 12.1 Screen title + menu path
`Tran 2 → Bill Wise Rec` → tab **Bill Wise Rec 1**, banner **Bill Wise Received**. Prerequisite: the party has ≥1 open sales invoice (video pre-made two Gold Tax Invoices for *Piyush Ji Soni*).

### 12.2 Header + two grids (kf_016–kf_030)
- **Header:** `Vch No` (`00001`) + `F1` · `Vch Date` (+time+weekday) · `Party` (`000208 PIYUSH JI SONI`) · right `: Amt / : Gold / : Silvr`, `65000.00 : Dr Amt`, `202146.00 : Dr Balance`.
- **Top grid — how the money was received (tender):** `Sr` · `RecAc` · `Rac Ac Name` · `It Desc` · `Chq No` · `Amount` · `Kasar`. Rows: `00001 CASH ON HAND · 10000` and `000203 HDFC BANK · 15000` → `Total 25000`. (`F1` account picker: `AcName · AcCode · Address · Group`.)
- **Bottom grid — allocation across bills:** `Sr` · `BillNo` · `Book` · `BillAmt` · `RecAdj` (already received earlier) · `RecAmt` (receive now) · `KasarAmt` · `DiffAmt` (remaining). Rows: `00006 · Gold Tax Invoice · 16500 · RecAdj 6500 · RecAmt 10000 · Diff 0` (bill cleared) and `00007 · Gold Tax Invoice · 55000 · RecAmt 15000 · Diff 40000` (still due). Footer `Employe`; bottom-right `40000.00 : Dr Amt` (party's remaining balance).

### 12.3 Operator workflow
`Tran 2 → Bill Wise Rec` → pick party (*Piyush Ji Soni*) → its **open bills load** in the bottom grid → top grid: record receipts (`CASH ON HAND 10000` + `HDFC BANK 15000` with Chq No) = `25000` → bottom grid: allocate `10000` to bill `00006` (clears it) and `15000` to bill `00007` (leaves `40000`); optional `Kasar` round-off per bill → **Save** → per-bill receipts printable. Ledger then shows the party down to `40000 Dr` (kf_042).

### 12.4 Effects (verified `finance/billToBill.ts`)
- **`BILL_OS_DATA` update:** each allocation adds its `REC_AMT` + `KASAR_AMT` onto the matching bill row (keyed `CO_CODE·CO_BOOK·VCH_NO·AC_CODE`) and stamps `NEW_VCH_NO`; **overpay is rejected** (rec+kasar ≤ that bill's open balance `BILL_AMT−REC_AMT−KASAR_AMT`). `INOUT_TYPE 'O'`=receivable / `'I'`=payable. Open bills span years (not filtered by CO_YEAR).
- **Posted receipt (`AC_DATA` + `CASH_DATA`):** **Dr Cash/Bank** (Σ rec) · **Dr `KASAR`** (Σ kasar) · **Cr party** (VCH_TYPE `CREC` cash / `BREC` bank). Links settling voucher to bills via `OLD_VCH_NO`/`NEW_VCH_NO`.

### 12.5 Cross-module connections
Depends on **Sales Invoices** (BILL_OS_DATA rows) + party + cash/bank accounts. Feeds Ledger Report (party balance, kf_042), Party Outstanding report, day-book. Shares the receipt path with Cash/Bank Received (§2/§4) and Batch Receipt.

### 12.6 Web parity — `/txn/bill-to-bill` (`finance/billToBill.ts`)
`listOpenBills` + `settleBills` implement the open-bill list (`openBal` filter), per-bill `REC_AMT`/`KASAR_AMT` allocation with overpay guard + `NEW_VCH_NO` link, and post the real Dr-cash/bank + Dr-kasar / Cr-party receipt into `AC_DATA` + `CASH_DATA`. **Parity = matches.** **To-verify:** the web page shows **both grids** — the multi-line **tender** grid (RecAc/Chq No/Amount/Kasar) *and* the **allocation** grid (BillNo/Book/BillAmt/RecAdj/RecAmt/KasarAmt/DiffAmt) — and that mixed cash+bank tender in one voucher is supported (desktop allows it).

---

## Appendix · consolidated table & VCH_TYPE reference (transaction playlist)

| Screen | Header table | Detail/line tables | Stock | VCH_TYPE | Book | Ledger sense |
|---|---|---|---|---|---|---|
| Sales | SL_DATA | SL_DETL, SL_IDTL, SL_PR_DETL | MAIN_STOCK (TGSL −, MIXSL +) | SALE | SAL | Dr cash/bank/oldgold/customer · Cr sales+GST+roundoff |
| Sales Return | SL_DATA | SL_DETL_RTN | MAIN_STOCK (CRNOT +) | (credit note) | — | Cr customer · Dr sales+GST |
| Sales Order | SL_ORD_DATA | SL_ORD_DETL, SL_ORD_IDTL, SL_ORD_ADJ | — | SORD | SOR | (advance) Dr cash · Cr customer |
| Purchase | PR_DATA | PR_DETL, PR_IDTL | MAIN_STOCK (TGPR +) | PURC | PUR | Cr supplier · Dr purchase+inputGST |
| Purchase Return | PR_DATA | PR_DETL | MAIN_STOCK (−) | (debit note) | — | Dr supplier · Cr purchase+inputGST |
| Cash Received | CASH_DATA | — | — | CREC | RCT | Dr CASH · Cr party |
| Cash Payment | PAY_DATA | PAY_DETL | — | CPAY | PAY | Dr party/expense · Cr CASH |
| Bank Received | CASH_DATA (+CARD_DATA/UPI_DATA) | — | — | BREC | RCT | Dr BANK · Cr party |
| Bank Payment | PAY_DATA | — | — | BPAY | PAY | Dr party/expense · Cr BANK |
| Contra | CONTRA_DATA | — | — | JV | CON | Dr toAc · Cr fromAc |
| Approval Issue/Return | APR_DATA | APR_DETL, APR_IDTL | MAIN_STOCK (out→pending / in) | — (custody) | — | none until billed |
| Labour Invoice | LBR_DATA | LBR_ISU_DETL/IDTL, LBR_REC_DETL | fine ledger (order-gold) | — | — | Dr customer · Cr labour+metal+**GST 3%+5%** |
| Other Expenses | PAY_DATA | — | — | OPUR | OPR | Cr supplier · Dr expense+inputGST |
| Bill-to-Bill | CASH_DATA + BILL_OS_DATA (update) | — | — | CREC/BREC | RCT | Dr cash/bank+kasar · Cr party |

All post a balanced `AC_DATA` double entry (`ΣDR=ΣCR`), stamped `LEDR_KEY`/`DATA_TYPE='A'`/`BOOK_NAME`; delete = `reverseVoucherTx` + `DELETE_DATA`; period-locked dates rejected via `CO_SET.LOCK_DATE`. **fine = netWt × touch ÷ 100.**
