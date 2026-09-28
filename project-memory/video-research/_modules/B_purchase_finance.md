# Module B — PURCHASE + FINANCE · Desktop↔Web UX-parity map

> Phase D video-research. Golden master = DataCareNext desktop (1280px tutorial keyframes + Hindi/English
> narration). Web target = `web/apps/web/app/(app)/txn/*`. Each screen: (1) desktop layout, (2) workflow +
> ledger effects, (3) current web state, (4) concrete gap checklist. Frame cites = `kf_NNN` of that video.
> Specs cross-ref: `03_Modules/3_Purchase/{TR_PURC,TR_OTH_PURC}.md`, `03_Modules/7_Finance_CashBank/{TR_CASH,TR_CONTRA,TR_CARD_REC,TR_UPI_REC}.md`, `04_Cross_Cutting_Engines/posting-and-ledger.md`.

## Menu geography (from frames)
Desktop top-bar: `Home · Company · Master · Tran 1 · Tran 2 · Other · Karigar · Reports · Scheme · Dhiran · Exit`.
- **Tran 1** (kf lqJjexUe4MA_002): Purchase, Purchase Rtn, Sales Order, Sales, Sales Return, Wh Sales, **Cash Received, Cash Payment, Bank Received, Bank Payment, Contra Entry**, Rate Cut.
- **Tran 2** (f2mXV47LSXk_014): Approval Isu/Rtn, Labour Work, Fine Jv Entry, Old Item Sales, **Bill Wise Rec, Other Expenses**, Other Income.
- Persistent status bar: live `Fine Gold` / `Fine Silver` / `Rate Date`. Every txn screen shows a live **party balance** top-right (`NNNN.00 : Dr Balance` / `: Dr Amt`) and `: Amt / : Gold / : Silvr` running tallies — a recurring web gap.

---

## 1. PURCHASE VOUCHER — "Gold Purchase Tax"  (video lqJjexUe4MA; main screen seen in wuIFZsCf4Mw_011)
Web: `txn/purchase/page.tsx` · spec `TR_PURC.md`

### (1) DESKTOP LAYOUT
Menu Tran 1 → Purchase opens a metal-type submenu: **Gold / Gold UID / Silver / Silver UID Purchase** (narration; the chosen book swaps the posting routine). Title "Gold Purchase Tax".
- **Header** (kf_011): `Vch No` (auto, 00002) + `F1` lookup · `Vch Date` + time + weekday · `Item Wt` (2 boxes) · `Ref No` · `Party` (000205 / ABC JEWELLERS, F-lookup, create-on-the-fly into group 05 VEPARI) · `Sl Bil No` (2 boxes) · running `: Amt / : Gold / : Silvr` top-right.
- **Main item grid**: `Sr · ItCode · ItName · Pcs · GrWt · OthWt · NetWt · Touch · West% · Fine · Rate · ItAmt · Ltype · LRate · LAmt · OthAmt · TotAmt` (horizontally scrolling). Example row: `ORG / GOLD ORNAMETNS / 1 / 12.000 / 0 / 12.000 / 0 / 0 / 12.000 / 4800 / 57600 / N / 0 / 0 / 0 / 57600`.
- **Sub-grid 2** (stone/diamond): `Sr · ItCode · ItName · Pcs · Weight · Con% · P/W · Rate · ItAmt · NetAmt` (opens on a key in the line per narration — "stone/diamond extra detail").
- **Sub-grid 3** (karigar/labour): `Sr · ItCode · ItName · Pcs · KrWt · Weight · Con% · P/W · Rate · ItAmt · NetAmt`.
- **Totals panel** (right): `Net Amt · Disc Amt · Tax Amt` (code `GST 3%` + `3.00` + `1728.00`) `· Tcs Amt · Rof Amt · Total Amt` (59328) **· Cheque Amt · Card Amt · Cash Amt · Kasar Amt · Os Amt** (the pay-now split). Below: `59328.00 : Cr Amt / : Gold / : Silvr`.
- **Footer**: image/`camera/▲/✂` attach box · `Employe` · `Bank` · `Vch Desc` · nav `< >` · **Print / Save / Cancel / Delete / Exit**.
- **Barcoding side** (lqJjexUe4MA_004/005): tag print `CHG00009 · G.19.400 · N.19.400 · LP:600 · 916` + QR; "Only Tag Entry" screen (Other menu) grid `ItCode·TagNo·Counter·Design·Size·Pcs·GrWt·LsWt·NetWt·Lbr%·LbrRate·LbrAmt·OthAmt·PrCost·Mrp·Image·KrCode` + `Print file = QrPrint10` + `Set`, `Lable Skip`.

### (2) WORKFLOW + EFFECTS
Pick supplier → add lines (pcs, gross→net, touch). `Fine = NetWt × Touch/100` (3 dp); `ItAmt = Fine × Rate`; labour by `Ltype` (N/per-gram/pc/%/fixed) → `LAmt`; `+OthAmt` → line net. Header `Tax% (3%) → CGST+SGST` (intra) added to taxable; `Tcs`, `Rof` round-off. Operator records how it was paid **now** via Cheque/Card/Cash split, remainder → `Os Amt` (outstanding). Save → numbers voucher, posts **balanced Cr supplier(total) / Dr purchase(taxable) + Dr input-GST + Dr round-off** (+ metal fine leg), brings metal **into stock** (tag batch + `MAIN_STOCK` in-move), records payable `BILL_OS`. Then optional **barcoding**: each purchased line is tagged (chain 96, size/design, pcs, wt 14.100, making) and printed (`916` QR), pushing pieces into tag stock (narration + lqJjexUe4MA_004/005).

### (3) CURRENT WEB STATE
`PurchaseEntryPage`: Book/Year/Location, Supplier (LookupPicker, sets interState from `AC_GST_TYPE`), Supplier Name, Bill No, Tax% (default 3), Discount ₹, Inter-state select. Items grid: `Item · Tag · Pcs · Gross · Net Wt · Touch% · Rate · Making/g · Fine · Amount`. Live `fine/metal/making/net`, `Taxable·Tax·Total`. POST `/purchases`. Shows saved Voucher # + totals tiles.

### (4) GAPS — checklist
- [ ] **No payment-now split** — desktop has Cheque/Card/Cash/Kasar + auto **Os Amt**; web has none (everything implicitly goes to outstanding). Add a pay panel → drives `BILL_OS = total − paid` and the cash/bank legs.
- [ ] **No `OthWt`, `West%`, `OthAmt`** columns; web labour is per-gram only (`Ltype` always per_gram) — add `Ltype` selector (N/per-gram/per-pc/%/fixed) + `LRate`/`LAmt`, `OthAmt`, wastage.
- [ ] **No `Tcs Amt` / `Rof Amt`** (round-off) on totals; web rounds total silently. Surface Rof + TCS.
- [ ] **No stone/diamond sub-grid** and **no karigar sub-grid** (`PR_IDTL`) — web cannot capture stone/cost breakup.
- [ ] **No barcoding / "Only Tag Entry"** flow (tag gen, size/design, QR `916`, `Print file` template, Label-skip). Web `tagNo` is a lookup of *existing* tags only; desktop *generates* tags on stock-IN. Major stock-parity gap (matches `TR_PURC.md §11`).
- [ ] **Missing header fields**: `Item Wt`, `Ref No`, `Sl Bil No`, `Party Fine`, `Employe`, `Vch Desc`, image attach, weekday/time.
- [ ] **No live party balance** (`: Cr Amt / : Gold / : Silvr`) display.
- [ ] **No metal-type book submenu** (Gold/Gold-UID/Silver/Silver-UID) — web is single generic purchase; spec confirms book switches posting (Karigar Receipt / Old Item Sales reuse the same form).
- [ ] No Print / Delete / nav (`< >`) actions on the web page.

---

## 2. PURCHASE RETURN — "Debit Note"  (video wuIFZsCf4Mw)
Web: `txn/purchase-return/page.tsx` · spec `TR_PURC.md §10` (book `PRT`/`PRTN`)

### (1) DESKTOP LAYOUT
Title "Debit Note" (Tran 1 → Purchase Rtn). Header same as purchase: `Vch No`(00001)+F1 · Date/time/day · `Ref No` · `Party`(000205 ABC JEWELLERS).
- **Grid adds `TagNo` + `Counter`** before ItCode: `Sr · TagNo · ItCode · ItName · Counter · Pcs · GrWt · OthWt · NetWt · Touch · West% · Fine · Rate · ItAmt · Ltype · LRate · LAmt · OthAmt …` (kf_018/024). So returns **pick the existing tag/counter** being sent back.
- Totals + pay panel identical to purchase: `Net 57600 · Tax GST 3% 1728 · Total 59328 · Cheque/Card/Cash/Kasar/Os` (kf_024). `Employe · Bank · Vch Desc`. `59328.00 : Cr Amt`.

### (2) WORKFLOW + EFFECTS
Narration: first a purchase must exist; open Debit Note, pick party + (if barcoded) the **tag number** to return else enter item manually. Enter pcs/wt/rate (same 800/4800 + 3% GST). The returned goods leave stock; the value is settled — if the supplier refunds by **cheque/RTGS** capture it (which bank, e.g. HDFC received) else it auto-credits the party account (`Os`). Save → **Dr supplier / Cr purchase + input-GST + round-off** (mirror of purchase), tagged goods `issueTagTx` out of stock, book `PRT`. kf_029 shows fresh Vch 00002 after save.

### (3) CURRENT WEB STATE
`PurchaseReturnPage`: identical to purchase page (Book PRT, Supplier, Orig Bill No, Tax%, Discount, Inter-state) + items grid with a `Tag` LookupPicker (entity `tags`, auto-fills wt/touch/rate). POST `/purchase-returns`. Shows "debited supplier ₹…".

### (4) GAPS — checklist
- [ ] **No `Counter` column** and no explicit refund-instrument capture (Cheque/RTGS/bank + Os split) — web only books the debit; desktop captures how the refund came back.
- [ ] Same omissions as Purchase: `OthWt/West%/Ltype/LRate/LAmt/OthAmt`, Tcs/Rof, Employe, Vch Desc, party-balance, Print/Delete.
- [ ] Web tag picker is optional/manual; desktop debit note is **tag-driven** (return the exact tag) — ensure returned tag actually leaves stock (`MAIN_STOCK '-'`).

---

## 3. OTHER EXPENSES — "Other Expenses"  (video f2mXV47LSXk)
Web: `txn/other-purchase/page.tsx` · spec `TR_OTH_PURC.md` (posts via `PAY_DATA`, GST input, **no stock**)

### (1) DESKTOP LAYOUT
Tran 2 → Other Expenses. Title "Other Expenses".
- **Header** (kf_023/032): `Vch No`(00001)+F1 · Date/time/day · **`Bill No`(123) · `Bill Date`** · `Party`(000207 ABC APL, group 05 VEPARI, GST/PAN/State on the party master kf_014) + `L` button · **`Ledr Code`(00060 / SHOP EXP. A/C)** — the expense ledger, default & changeable.
- **Grid**: `Sr · HsnCode · ItName · TaxCode · Tax% · NetAmt · TaxType · TaxableAmt · IGSTamt · CGSTamt · SGSTamt · TotalAmt`. Filled (kf_032): `12345 / AC / 14 / 28.00 / 30000 / F / 30000 / – / 4200 / 4200 / 38400`.
- **`Add New HsnNo?` Yes/No** popup (kf_023) — first-time HSN+item is saved to a master for reuse.
- **`TaxType` toggle = F (forward) / R (reverse charge / RCM)** — narration: type "reverse" to make GST RCM (input reversed). kf_040 shows recalculated CGST/SGST 3281.25 when toggled.
- **Totals**: `Net · IGST/CGST/SGST Tax · Total Amt · Cheque/Card/Cash/Kasar/Os Amt`. **Bank picker** (kf_040 DataCare Help: BANK A/C 00075 / HDFC 000203 / ICICI 000204) chooses the bank the cheque is drawn on. `Employe · Bank · Vch Desc`.

### (2) WORKFLOW + EFFECTS
Buy a non-stock item (AC for the shop). Enter supplier bill no/date, pick expense ledger, enter HSN + item name (GST mandatory — narration: "credit lena hai"), tax code/%, net amount. GST auto-splits (28% → CGST 4200 + SGST 4200 on 30000 = 38400). Optionally flip `TaxType` to RCM. Record payment (cheque 30000 from a chosen bank) → Os 0. Save → **Dr expense + Dr input-GST / Cr supplier** into `PAY_DATA`/`PAY_DETL` + `TAX_DATA` + `BILL_OS`, no stock/tag.

### (3) CURRENT WEB STATE
`OtherPurchasePage`: Supplier, Supplier Name, Bill No, Tax% (default 18), Inter-state. Expense lines: `Expense account · Description · Amount`. Footer Taxable/+tax/Total. POST `/other-purchase`. (Header banner notes "non-stock, GST input".)

### (4) GAPS — checklist
- [ ] **No `HsnCode`, `ItName`, `TaxCode`, per-line `Tax%`** — web tax is a single header %; desktop is per-line HSN-driven. Add HSN/item columns + "save new HSN" master.
- [ ] **No `TaxType` (forward vs RCM/reverse-charge)** — core feature for expense GST; web cannot do reverse charge.
- [ ] **No per-line GST display** (IGST/CGST/SGST/Total columns) — web only shows aggregate footer.
- [ ] **No `Bill Date`**, no separate **`Ledr Code`/expense ledger header** (web puts expense on each line instead — confirm posting maps to `PAY_DATA` per spec, not `PR_DATA`).
- [ ] **No payment split + bank selection** (Cheque/Card/Cash/Kasar/Os + which bank) — web always leaves full amount outstanding.
- [ ] Missing `Employe`, `Vch Desc`, party-balance, Print/Delete.

---

## 4. CASH RECEIVED & PAYMENT  (video tpKMyaRMlFM — *no transcript*, read 6 frames)
Web: `txn/receipt` + `txn/payment` → `components/PaymentForm.tsx` · spec `TR_CASH.md`

### (1) DESKTOP LAYOUT
Two menu items (Tran 1 → Cash Received / Cash Payment) sharing one screen layout. Titles "Cash Received" / "Cash Payment".
- **Header** (kf_008): `Vch No`(00001)+F1 · Date/time/day · top-right live party balance `20000.00 : Dr Balance`.
- **Multi-line grid**: `Sr · AcCode · Ac Name · Amount · Kasar` (kf_008 row `000201 / VIKAS BARVADIYA`; payment kf_037 `00059 / OFFICE EXPENSES`). Account picker DataCare Help shows AcName/Mobile/AcCode/Address/Group (kf_030: ELECTRIC BILL EXP.A/C 00051 ADMINISTRATIVE-EXPS).
- **Footer**: `Total` (Amount + Kasar) · `It Desc` (multi-line narration) · `Employe` · running `: Dr Amt` (kf_008 `29290.00`). Buttons `> · Print · Save · Cancel · Delete · Exit`.
- **Save** → print dialog `Original / Duplicate / Triplicate` + View/Print/Exit (kf_016).
- Effect verified via Ledr Report (kf_023): CASH ON HAND Dr 35000, DISCOUNT A/C Dr 1000 (= kasar), party balances move.

### (2) WORKFLOW + EFFECTS
Receipt: pick **one or more** parties, enter Amount + optional Kasar (cash discount). **Cash Received → Cr party / Dr CASH ON HAND**; Kasar → Cr party / Dr DISCOUNT (kasar) a/c. **Cash Payment → Dr party-or-expense / Cr CASH** (kf_037 OFFICE EXPENSES; kf_043 PETROL 2000). Multi-line = settle several accounts in one voucher. Counter cash/kasar accounts come from `BOOK_DETL` (see §5). Also mirrors to `ROJ_MEL_DATA` day-book.

### (3) CURRENT WEB STATE
`PaymentForm{kind}`: single `Party` + `Party Name` + single `Amount` + `Mode` select (cash/bank/card/upi/cheque) + conditional Bank AC / Cheque No / card commission / UPI id / PAN. POST `/receipts` or `/payments`. One party, one amount.

### (4) GAPS — checklist
- [ ] **No multi-line grid** — desktop receipts/payments take many account lines per voucher; web is one party/one amount.
- [ ] **No `Kasar` (cash discount) column** — desktop posts a kasar Cr-party/Dr-discount pair; web omits it (spec `TR_CASH.md §11` flags this).
- [ ] **No `It Desc` narration, no `Employe`** field, no weekday/time, no Original/Duplicate/Triplicate print.
- [ ] **No live party balance** (`Dr Balance` / running `Dr Amt`).
- [ ] **Mode model differs**: desktop Cash vs Bank vs Card vs UPI are *separate forms/books*; web collapses to one `mode` dropdown (acceptable, but loses the per-book counter-account mapping — see §5).
- [ ] Web `mode='card'/'upi'/'cheque'` mixes Card/UPI/cheque into the cash form; desktop tutorial here is **cash only**. Confirm card/UPI go through `TR_CARD_REC`/`TR_UPI_REC` (separate). 
- [ ] Payment writes web `PAY_DATA` but desktop uses one `CASH_DATA` with `INOUT_TYPE` for both directions (spec open-question).

---

## 5. BANK RECEIVED & PAYMENT  (video AdgxtGwjrfc)
Web: `txn/receipt` + `txn/payment` (bank mode) → `PaymentForm.tsx` · spec `TR_CASH.md` (Bank_Ledr)

### (1) DESKTOP LAYOUT
Setup first: **(a)** create bank accounts in **Master → Party** under group **22 = BANK CURRENT A/C** (kf_014: HDFC BANK 000203, ICICI 000204; groups 21 cash / 22 bank-current / 23 bank-savings). **(b)** **Company → Books → Book Master** create one REC + one PAY book *per bank* (kf_034 `005 HDFC BANK REC / short BREC / Transaction=BANK REC / Tran In-Out=Inword / Cur In Use=Yes`; kf_052 `011 ICICI BANK PAY / BPAY / BANK PAY / Outword`). Each book's `Account Desc` grid maps **counter accounts**: `SR 1 = BANK A/C (00075)`, `SR 2 = KASAR JAVK/AVAK A/C (00057/00042)`, `SR 3 = BANK CHARGES A/C (00048)` — this *is* the spec's `BOOK_DETL` SR_NO 1/2/3.
- **Entry screen** "HDFC BANK PAY" (kf_086): header `Vch No · Date · 6000.00 : Dr Balance`. Grid `Sr · AcCode · Ac Name · **Chq No** · Amount · Kasar` (row `00060 SHOP EXP. A/C`). Footer adds **`Chq Print`** (payee, "SHOP EXP. A/C") + `It Desc` + `Employe`. Buttons add a **`Chq`** (cheque-print) button alongside Print/Save/etc.

### (2) WORKFLOW + EFFECTS
**The bank is chosen by picking the book** (HDFC Bank Rec/Pay vs ICICI Bank Rec/Pay) — not a dropdown in the form; the book pre-binds the bank control a/c + kasar + charges. Bank Received → Cr party / Dr bank; Bank Payment → Dr expense/party / Cr bank (kf_086 SHOP EXP). Capture `Chq No` + cheque-print payee; bank legs post on **clearing date `CLR_DATE`** and add a **bank-charges** pair (Dr charges / Cr bank). Verified in Ledr Report (kf_094): BANK A/C 113430, HDFC BANK 2500 remaining; account-ledger drill-down (tSRFXH2BoZ0_033) shows `HDFC BANK PAY` / `HDFC BANK REC` rows with running Cr/Dr balance.

### (3) CURRENT WEB STATE
Same `PaymentForm` with `mode='bank'` (or cheque): single party, single amount, a free **Bank AC** LookupPicker, Cheque No (cheque mode only), PAN. No book concept.

### (4) GAPS — checklist
- [ ] **No per-bank book selection** — desktop binds bank+kasar+charges via `BOOK_DETL`; web uses a free `bankAc` lookup and hard-codes `'CASH'/'BANK'` symbolic accounts (spec `TR_CASH.md §11`). Need a tenant book→counter-account map.
- [ ] **No `Chq No` per line, no `Chq Print` payee, no `Chq` (cheque print) action**.
- [ ] **No clearing date (`CLR_DATE`)** — bank legs must post on clearing, not entry, date.
- [ ] **No bank-charges leg** and **no kasar leg** (Dr charges/kasar / Cr bank) — web posts only the single party↔bank pair.
- [ ] No multi-line grid, no `It Desc`, no `Employe`, no live balance (same as §4).
- [ ] No `ROJ_MEL_DATA` day-book write (spec gap → RojMel report + trial-balance correctness).

---

## 6. CONTRA ENTRY  (video tSRFXH2BoZ0)
Web: `txn/contra/page.tsx` · spec `TR_CONTRA.md` (CONTRA money + FINE JV metal)

### (1) DESKTOP LAYOUT
Tran 1 → Contra Entry. Title "Contra Entry".
- **Header** (kf_006): `Vch No`(00001)+F1 · Date/time/day · `: Amt`.
- **Multi-line grid**: `Sr · Cr/Dr · AcCode · Ac Name · It Desc · CrAmt · DrAmt`. Row 1 = main account; rows 2..N = counters, each with its own `Cr/Dr` flag + amount (kf_021: `DR / 000203 / HDFC BANK / DrAmt 10000`, row 2 being entered as the cash credit). Account picker (kf_014) lists every ledger (ABC JEWELLERS, BANK A/C, BANK CHARGES, CAPITAL, CARD A/C…).
- **Footer**: `Total` (CrAmt + DrAmt must net) · `Employe`. Print/Save/Cancel/Delete/Exit.

### (2) WORKFLOW + EFFECTS
Use: deposit cash to bank / withdraw / ledger↔ledger. Enter main a/c (HDFC BANK Dr 10000) then counter (CASH ON HAND Cr 10000); **both sides must equal or it won't save** (narration). Save → `Contra_Ledr` projects each `CONTRA_DATA` row to a balanced `AC_DATA` leg (paired `LDR_TYPE` 0 counter / 1 main, cross-linked by `LD_CODE`). Verified in HDFC account ledger (kf_033): `Contra Entry 00001 · CASH ON HAND · Dr 10000 · Bal −12500`. `FINE JV` variant transfers gold/silver **fine weight** (`CR_FINE/DR_FINE`) instead of money (separate book, Tran 2 → Fine Jv Entry).

### (3) CURRENT WEB STATE
`ContraPage`: just `From AC`, `To AC`, `Amount` (3 fields). POST `/contra` → one `CONTRA_DATA` row with both DR_AMT & CR_AMT = amount; dumps raw JSON result.

### (4) GAPS — checklist
- [ ] **2-account only, single amount** — desktop is **n-leg** (one main vs many counters) with per-row Cr/Dr; web cannot do multi-counter contra.
- [ ] **No `Cr/Dr` column, no `It Desc`** per line, no `Employe`.
- [ ] **No FINE JV (metal contra)** — web has no `CR_FINE/DR_FINE` path; gold/silver fine transfer unsupported (spec `TR_CONTRA.md §11`).
- [ ] **CONTRA_DATA shape mismatch** — web writes one combined row; desktop writes paired `LDR_TYPE 0/1` rows. Align before parity.
- [ ] No `ROJ_MEL_DATA` day-book write; raw JSON shown instead of a ledger/print confirmation.

---

## 7. BILL WISE AMOUNT RECEIVED  (video sE2H-ztIINE)
Web: `txn/bill-to-bill/page.tsx` · desktop `TR_BILL_TO` (no standalone spec; uses `BILL_OS_DATA`)

### (1) DESKTOP LAYOUT
Tran 2 → Bill Wise Rec. Title "Bill Wise Received". **Two stacked grids.**
- **Header**: `Vch No`(00001)+F1 · Date/time/day · `Party`(000208 PIYUSH JI SONI) · live `65000.00 : Dr Amt` (kf_008).
- **Top grid = tender / how-received**: `Sr · RecAc · Rac Ac Name · It Desc · Chq No · Amount · Kasar`. kf_034: `00001 CASH ON HAND 10000` + `000203 HDFC BANK 15000` (cheque) → Total 25000. (Same shape as a cash/bank receipt — multi-tender.)
- **Bottom grid = open bills (auto-loaded for party)**: `Sr · BillNo · Book · BillAmt · RecAdj · RecAmt · KasarAmt · DiffAmt`. kf_008: bill `00006 Gold Tax Invoice 16500 / already-recd 6500 / … / Diff` and `00007 55000 / 0 / 55000`. kf_034: bill 1 `RecAmt 10000 → DiffAmt 0` (fully cleared), bill 2 RecAmt being entered.
- Footer `Employe`; running `40000.00 : Dr Amt` after partial settle. Verified Ledr Report (kf_042) PIYUSH 40000.

### (2) WORKFLOW + EFFECTS
Party has multiple invoices. Operator (a) enters **what was received and how** in the top grid (cash 10000 + HDFC cheque 15000), then (b) **allocates** that money across specific open bills in the bottom grid: `RecAmt` = receive now against this bill, `KasarAmt` = write-off, `DiffAmt` = remaining open (= `BillAmt − RecAdj − RecAmt − Kasar`). FIFO-style or pick any bill. `RecAdj` shows prior receipts already adjusted. Top tender total must equal bottom allocation total. Save → posts a receipt (Cr party / Dr cash+bank) **and** updates `BILL_OS_DATA.REC_AMT/KASAR_AMT` per bill. Narration notes separate receipts (10000 cash, 15000 cheque) → two receipt prints.

### (3) CURRENT WEB STATE
`BillToBillPage`: Party lookup → `GET /bill-to-bill/open` lists open bills (`coBook, vchNo, billAmt, recAmt, kasarAmt, openBal`). Per-bill editable **Receive** + **Kasar (w/off)** with live **New Open** and over-pay guard. `Settle` → POST `/bill-to-bill/settle {acCode, allocations}`; refuses overpay; refreshes after settle.

### (4) GAPS — checklist
- [ ] **No tender/receipt side** — web only edits bill allocations; it never captures *how* the money arrived (cash/bank/cheque) and (per the page) only updates `REC_AMT/KASAR_AMT`, **not** a real receipt voucher (no cash/bank `AC_DATA` legs). Desktop bill-wise = full receipt **+** allocation. This is the biggest functional gap.
- [ ] **No top multi-tender grid** (`RecAc · Chq No · Amount · Kasar`), no cheque no, no tender-vs-allocation balance check.
- [ ] **No `RecAdj`/`DiffAmt`/`Book` semantics shown the desktop way** — web shows `Recd/Kasar/Open Bal/New Open`; roughly equivalent but lacks "already adjusted" vs "receive now" clarity and the `Book` per bill is shown but not the invoice type label ("Gold Tax Invoice").
- [ ] **No live party balance / running `Dr Amt`**, no `Employe`, no per-tender receipt print.
- [ ] Confirm settlement posts the same ledger as a receipt (party Cr / cash-bank Dr) — currently appears to be a bookkeeping-only update.

---

## TOP CROSS-CUTTING GAPS (priority order)
1. **Finance is single-line + tender-less.** Receipt/Payment/Bill-wise all need a **multi-line grid**, **Kasar** column, **Chq No / clearing date / bank-charges** for bank, and **bill-wise must actually post a receipt** (cash/bank legs), not just adjust `BILL_OS`. (`PaymentForm`, `bill-to-bill`.)
2. **Per-bank Book / counter-account model missing.** Desktop binds bank+kasar+charges via `BOOK_DETL` (kf AdgxtGwjrfc_034/052); web hard-codes `'CASH'/'BANK'`. Build a tenant book→counter-account map; also enables `ROJ_MEL_DATA` day-book (currently never written → RojMel/trial-balance gap).
3. **Contra is 2-account money-only.** Need n-leg (main vs many counters) with per-row Cr/Dr + `It Desc`, paired `LDR_TYPE 0/1` rows, and **FINE JV** metal transfer.
4. **Purchase/return lack the pay-now split + Os, labour/wastage/other-charges, TCS/round-off, stone & karigar sub-grids, and the barcoding/tag-generation flow** (golden-master stock-IN). Web tag field is read-only lookup, not generation.
5. **Other Expenses lacks HSN/TaxCode/per-line GST + `TaxType` (RCM/reverse-charge) + payment split + bank** — currently a flat supplier+tax%+lines form; cannot do reverse charge or per-HSN input GST.
6. **Universal UX omissions on every screen**: live party balance (`Dr Balance`/`: Cr Amt`/`: Gold`/`: Silvr`), `Employe`, `Vch Desc`/`It Desc` narration, weekday+time, Print (Original/Duplicate/Triplicate) / Delete / nav, image attach.

### Frames read (evidence)
- Purchase lqJjexUe4MA: kf_001,002,003,004,005,006 (+ purchase main screen at wuIFZsCf4Mw_011).
- Purchase Return wuIFZsCf4Mw: kf_004,011,018,024,029.
- Other Expenses f2mXV47LSXk: kf_005,014,023,032,040.
- Cash Rec/Pay tpKMyaRMlFM (no transcript): kf_008,016,023,030,037,043.
- Bank Rec/Pay AdgxtGwjrfc: kf_014,034,052,070,086,094.
- Contra tSRFXH2BoZ0: kf_006,014,021,028,033.
- Bill-wise sE2H-ztIINE: kf_008,018,026,034,042.
