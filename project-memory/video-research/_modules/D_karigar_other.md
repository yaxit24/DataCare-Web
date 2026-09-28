# Module D — KARIGAR + OTHER-OPS · Desktop↔Web UX-parity map

> Phase D video-research. Golden master = DataCareNext desktop (1280px tutorial keyframes + Hindi/English
> narration). Web target = `web/apps/web/app/(app)/*`. Each screen: (1) desktop layout, (2) workflow +
> stock/ledger effects, (3) current web state, (4) concrete gap checklist. Frame cites = `kf_NNN` of that video.
> 5 of 12 videos have **no transcript** (Daily Rate, Tag Cancel, Stock Adjust, Order Cancel, Labour Update) → read from frames only.

## Menu geography (from frames)
Desktop top-bar: `Home · Company · Master · Tran 1 · Tran 2 · Other · Karigar · Reports · Scheme · Dhiran · Exit`. Persistent status bar: live `Fine Gold` / `Fine Silver` / `Rate Date` + top-right `ToDays Rate :` (driven by Daily Rate). Every txn screen shows a live party balance top-right (`NNN.NNN : Dr Gold` / `: Cr Amt` / `: Silvr`) — a recurring web gap.
- **Karigar menu** (kf Gd0TSp2OoXA_015): `Kr Issue · Kr Received · Kr Design Isu · Cust Repar · Kr Repar Isu · Kr Repar Rec · Cust Repar Isu`. (Web only builds Issue + Receive; the 5 repair/design books are absent.)
- **Other menu** (kf 5mIg4yRl0aE_008): `Daily Rate · Only Tag Entry · Tag Cancel · Tag Print · Stock Adjust · Order Cancel · Reminder · Physical Stock · Tag Transfer · Tag Wt Change` + **Extra**: `Sms · Labour Update · Counter Trfr · Bank Reconcile · Vch ReNumber`.
- In-screen **F-key quick menu** (kf yP6XAirZ36I_006): F2 Ledger · F3 Stock Report · F4 Sales Order · F5 Sales Bill · F6 Wh Sales · F7 Purchase Bill · F8 Cash Rec · F9 Cash Pay · F10 Reminder · F11 Rojmel · F12 Tag Wise Stock · Ctrl+F1 Daily Rate · Ctrl+F12 TagEstimate · Ctrl+F11 CashBank.

Karigar = a **party account in group `10` KARIGAR SUNDRY CR** (kf Gd0TSp2OoXA_023), created on-the-fly via F4 Party Master.

---

# KARIGAR

## 1. KARIGAR METAL ISSUE — "Karigar Issue"  (video Gd0TSp2OoXA)
Web: `txn/karigar-issue/page.tsx` → shared `components/KarigarForm.tsx` (mode=issue) · API `/karigar/issue`

### (1) DESKTOP LAYOUT (kf_031, kf_007@CO9Ro)
Karigar → Kr Issue. Title "Karigar Issue". Header: `Vch No`(00001)+`F1` · `Vch Date`+time+weekday · `Ref No` · `Party`(000209 / MANOJ KARIGAR, F-lookup, create via F4) · top-right `: Amt / : Gold / : Silvr`.
- **Main grid**: `Sr · TagNo · ItCode · ItName · Counter · Pcs · GrWt · OthWt · NetWt · Touch · West% · Fine · ConIt · Con% · ConWt · TotWt`. Row: `999 / 999 GOLD / Pcs 0 / GrWt 100.000 / NetWt 100.000 / Fine 100.000 / TotWt 100.000`.
- **Totals/footer**: image-attach box · `Employe` · `Bank` · `Vch Desc` · nav `< >` · full **totals panel**: `Net Amt · Disc Amt · Tax Amt · Rof Amt · Total Amt · Cheque Amt · Card Amt · Cash Amt · Kasar Amt · Os Amt`. Live `100.000 : Dr Gold`. Buttons Print/Save/Cancel/Delete/Exit.

### (2) WORKFLOW + EFFECTS
Stock first checked via Stock Report (kf_015): `999 GOLD` OpWt 300.000. Pick karigar → add metal line (999 GOLD, 100g, touch) → Fine. Save → metal **leaves shop stock** (999 GOLD 300→200, kf_015/CO9Ro_039) and posts **`Dr Gold` to the karigar ledger** (kf_038: MANOJ KARIGAR DrGold 100.000) — karigar now owes 100g fine. Pure metal move; money totals normally 0 unless a labour advance is paid via the Cheque/Cash/Os panel.

### (3) CURRENT WEB STATE
`KarigarForm{issue}`: `Karigar (AC_CODE)` free input · `Karigar Name` · metal lines grid **`Item · Net Wt · Touch %`** only · "Check balance" (issued−received fine) · Save → `/karigar/issue` returns `{vchNo, fineIssued}`.

### (4) GAPS — checklist
- [ ] **Grid is 3 columns vs desktop 16** — missing `TagNo, Counter, Pcs, GrWt, OthWt, West%, Fine(shown), ConIt/Con%/ConWt (conversion), TotWt`. No gross→net, no pieces, no wastage, no metal-conversion legs.
- [ ] **No party lookup** — `karigarAc` is a raw text box (should be a LookupPicker filtered to group 10 + create-on-the-fly).
- [ ] **No totals/payment panel** (`Net/Disc/Tax/Rof/Total/Cheque/Card/Cash/Kasar/Os`) — cannot pay a labour advance with the issue.
- [ ] **No header fields**: Vch No/Date/weekday/time, Ref No, Bank, Vch Desc, Employe, image attach.
- [ ] **No live `: Dr Gold` balance** on screen (only a manual "Check balance" button).
- [ ] No Print / Delete / `< >` nav. No Design-Issue / Repair-Issue book variants (desktop Kr Design Isu / Kr Repar Isu).

---

## 2. KARIGAR ORNAMENT RECEIVED — "Karigar Receipt"  (video CO9Ro-ZeeE8)
Web: `txn/karigar-receive/page.tsx` → `KarigarForm` (mode=receive) · API `/karigar/receive`

### (1) DESKTOP LAYOUT (kf_016, kf_024)
Karigar → Kr Received. Title "Karigar Receipt". Header same as issue + **`Item Wt`** (2 boxes) and top-right live `100.000 : Dr Gold`. **THREE grids:**
- **Grid A — ornament received**: `Sr · ItCode · ItName · Pcs · GrWt · OthWt · NetWt · GhtWt · Touch · West% · Fine · Ltype · LRate · LAmt · TotAmt · TaxPrc · NetAmt`. Row (kf_024): `ORG / GOLD ORNAMETNS / 5 / 65.000 / NetWt 65 / Touch 92 / Fine 59.800 / Ltype N / LRate 100 / LAmt 6500 / TotAmt 6500`.
- **Grid B — stone/diamond sub-grid**: `Sr · ItCode · ItName · Pcs · Weight · Con% · P/W · Rate · ItAmt · NetAmt`.
- **Grid C — barcoding/tagging sub-grid** (kf_024): `Sr · ItCode · TagNo · Counter · Design · Size · HmId · Pcs · GrWt · LsWt · NetWt · Lbr% · LbrRate · LbrAmt · OthAmt · PrCost · Mrp · Image · KrCode` — the received pieces get **tagged into stock here**.
- **Totals panel**: `Net · Disc · Tax · Tcs · Rof · Total · Cheque · Card · Cash · Kasar · Os`. Live `6500.00 : Cr Amt` (labour payable) + `100.000 : Dr Gold`. Save → Original/Duplicate/Triplicate **print dialog** (kf_032).

### (2) WORKFLOW + EFFECTS
Karigar returns finished ornaments. Enter pcs/gross/net, **GhtWt** (ghat/loss), touch → Fine (65×92% = 59.8); **labour** by `Ltype` (N/per-gm/pc/%/fixed) → LAmt (100/g×65 = 6500), +GST (TaxPrc) if any. Optionally **barcode** each received piece in Grid C (tag, design, size, MRP, making). Save → ornaments **enter stock** (GOLD ORNAMETNS +5 pcs / +65g, kf_039), karigar's `Dr Gold` reduced by fine received, **labour becomes `Cr Amt` payable** to karigar (Os 6500) — settle now via Cheque/Cash or leave outstanding. Prints a receipt voucher.

### (3) CURRENT WEB STATE
`KarigarForm{receive}`: karigar AC + name + single `Labour Amount` + lines grid **`Item · Net Wt · Touch % · Wastage %`** · Save → `/karigar/receive` returns `{vchNo, fineReceived}`.

### (4) GAPS — checklist
- [ ] **No GhtWt, Pcs, GrWt, OthWt** on the line; **no per-line labour** (`Ltype/LRate/LAmt`) — web has one header `labourAmt` for the whole voucher, no labour-type model.
- [ ] **No stone/diamond sub-grid** (Grid B) and **no barcoding/tagging sub-grid** (Grid C) — web cannot tag received pieces into barcode stock (major stock-parity gap; pairs with Module B barcoding gap).
- [ ] **No totals panel** (`Net/Tax/Tcs/Rof/Total/Cheque/Card/Cash/Kasar/Os`), **no `Cr Amt` labour-payable settlement**, no GST/TCS.
- [ ] **No Original/Duplicate/Triplicate print**, no live `Dr Gold`/`Cr Amt`, no Employe/Bank/Vch Desc/Item Wt header.
- [ ] Confirm posting clears karigar `Dr Gold` by fine received AND books labour `Cr Amt` (web only returns `fineReceived` — verify the payable + stock-in legs exist).

---

# OTHER-OPS

## 3. DAILY RATE MASTER — "Rate Master"  (video 5mIg4yRl0aE · no transcript)
Web: `masters/rates` → generic `masters/[name]/page.tsx` over `RATE_MAST` (configs.ts `rates`)

### (1) DESKTOP LAYOUT (kf_008, kf_020)
Other → Daily Rate. Title "Rate Master". Fields: **`Vch Date`**+F1 · **`Gold Rate 10gm`** input · **`Silver Rate 1Kg`** input. Grid (auto per group): `Sr · GrCode · GrName · Touch · Tax% · Rate10gm · TaxRate · PrTouch · PrRate`. Rows: `FGL FINE GOLD 100.00`, `GO GOLD ORNAMENTS 92.00`, `FSL FINE SILVER 100.00`, `SL SILVER ORNAMENTS 80.00`. `Employee`. Print/Save/Cancel/Delete/Exit. Group touch/rate config comes from Item Group Master (kf_032: Gr Rate Touch, Purc Touch, "Rate Display In Main Screen"). Effect downstream: sale uses the rate (kf_044 Gold Tax Invoice ItRate 4441).

### (2) WORKFLOW + EFFECTS
Enter the day's **Gold 10gm** + **Silver 1Kg** rate for a date → system derives each group's `Rate10gm`/`PrRate` from its touch %, and publishes the live `ToDays Rate :` / status-bar `Fine Gold`/`Fine Silver`. Every sale/purchase/karigar valuation reads this dated rate.

### (3) CURRENT WEB STATE
`masters/rates` is the **generic master CRUD** (New/Edit/Del/Import/Export) over raw `RATE_MAST` columns `CO_CODE, LC_CODE, VCH_DATE, SR_NO, GR_CODE`. No "Gold 10gm / Silver 1Kg" pair, no per-group touch→rate derivation, no live rate display.

### (4) GAPS — checklist
- [ ] **No dedicated daily-rate entry screen** — web is a raw-row table editor; build the desktop form: pick date → enter Gold 10gm + Silver 1Kg → derive per-group `Rate10gm`/`PrTouch`/`PrRate`.
- [ ] **No live rate publication** — no top-bar `ToDays Rate` / status-bar `Fine Gold`/`Fine Silver`/`Rate Date` anywhere in web (affects every valuation).
- [ ] No per-group `Touch/Tax%/TaxRate/PrTouch` grid; no "Rate Display In Main Screen" flag from group master.

---

## 4. TAG CANCEL & PRINT — "Tag Cancellation" + tag label print  (video VzkTOy9vGL0 · no transcript)
Web: `txn/tag-cancel/page.tsx` · API `/stock/tag-cancel` (tagOps.ts)

### (1) DESKTOP LAYOUT (kf_005 tag entry, kf_004 label)
Other → Tag Cancel (and Tag Print / Only Tag Entry). The **Tag Print / Only Tag Entry** grid (kf_005): `Sr · Y/N · TagNo · ItCode · Counter · Design · Size · Pcs · GrWt · NetWt · Touch · West% · Fine · LbrRate · LbrAmt · OthAmt · Mrp · KrCode` with `Book 015` / `Print file = QrPrint10` + `Set` + `Lable Skip` + scan popup. **Printed label** (kf_004): `CHG00004 · G.14.300 · N.14.300 · LP:600 · DK · 916 · QR · DATACARE SOFTECH`.

### (2) WORKFLOW + EFFECTS
Tag Cancel removes a tag from barcode stock (`MAIN_STOCK '-'`, no money ledger). The "Print" half (Tag Print) (re)prints the QR tag label (gross/net/label-price/purity + QR) using a selectable `Print file` template, with a `Y/N` select-to-print column and `Lable Skip` offset for label sheets.

### (3) CURRENT WEB STATE
`TagCancelPage`: Book/Year/Location + multi-line grid `Tag · Item · Pcs · Gross · Net Wt · Touch % · Fine` (tag LookupPicker autofills) · Save → `/stock/tag-cancel` → `{vchNo, tags}` cancelled. Solid for the **cancel** half.

### (4) GAPS — checklist
- [ ] **No tag-label print** at all — no QR `916` label (`CHG…/G./N./LP:`), no `Print file` template picker (`QrPrint10`), no `Y/N` select-to-print, no `Lable Skip` offset.
- [ ] **No "Only Tag Entry / Tag Print" screen** (the standalone barcode-generation/label screen with Counter/Design/Size/Mrp/KrCode) — distinct from cancel.
- [ ] Cancel page lacks Counter/Design/Size/Mrp and Print/Delete actions; no confirmation print after cancel.

---

## 5. STOCK ADJUST ENTRY — "Stock Adjust"  (video yP6XAirZ36I · no transcript)
Web: **closest is** `txn/physical-stock/page.tsx` (reconcile) — **the adjust voucher itself is not built**

### (1) DESKTOP LAYOUT (kf_006, kf_019, kf_025)
Other → Stock Adjust. Title "Stock Adjust". Header `Vch No`+F1 · Date/time/day. **Main grid**: `Sr · TagNo · ItCode · Counter · Design · Size · `**`Sign`**` · Pcs · GrWt · LsWt · NetWt · Touch · West% · Fine · Mrp · KrCode`. Sub-grid: `Sr · ItCode · ItName · Pcs · Weight · KrWt · Con% · P/W · Rate · ItAmt · NetAmt`. `Employe · Vch`. Print/Save/Cancel/Delete + `< >`. Example (kf_025): `OG / Counter 001 / Sign + / GrWt 1.000 / NetWt 1.000 / Fine 1.000` → adjust OLD GOLD up by 1g.

### (2) WORKFLOW + EFFECTS
Manual stock correction at tag/item level. Pick item/tag, set **`Sign` = + or −**, enter pcs/weight/touch → posts a signed `MAIN_STOCK` movement (no money ledger). Used to add/remove loose or tagged stock outside normal txns.

### (3) CURRENT WEB STATE
No stock-adjust voucher exists. `physical-stock/page.tsx` only **reconciles** (paste counted tags → shortage/surplus counts via `/stock/physical-reconcile`, read-only). API has `tagWeightDiff`, `tagCancel`, `itemLot`, `physicalReconcile` but **no signed adjust-entry** endpoint.

### (4) GAPS — checklist
- [ ] **No Stock Adjust entry screen/endpoint** — cannot post a `±Sign` manual stock correction. Build voucher: tag/item grid + `Sign` + pcs/gross/loss/net/touch/fine → signed `MAIN_STOCK`.
- [ ] No `Counter/Design/Size/Mrp/KrCode` line attributes, no sub-grid, no Print/nav.
- [ ] Reconcile page ≠ adjust: reconcile reports variance but does not write the correcting movement.

---

## 6. PHYSICAL STOCK VERIFICATION — "Physical Stock"  (video QEPhVyaV_xU)
Web: `txn/physical-stock/page.tsx` · API `/stock/physical-reconcile`

### (1) DESKTOP LAYOUT (kf_006, kf_014, kf_021, kf_028)
Other → Physical Stock. Title "Physical Stock". Header `Vch No`+F1 · Date. **Scan grid**: `Sr · TagNo · ItCode · ItName · Design · Size · Cntr · Pcs · GrWt · OthWt · NetWt · LbrAmt · OthAmt · Mrp · KrName` (scan/select present tags via DataCare Help popup, kf_014). Buttons: **`Reset Stock` · `Report` · Save · Cancel · Delete · Exit**. The **Physical Stock Report** (kf_021/028): filters From/To · Stock · Item Type · Product · Group; tabs **`All` / `Diff`**; grid `cTagNo · It Name · Size · Cntr · Pcs · GrWt · Mrp · Stk · Out · Apr · Phy · Diff · DiffWt` ("After Physical InOut"). Print/Excel.

### (2) WORKFLOW + EFFECTS
Operator **scans every physically-present tag** into the voucher, Saves. The Report compares **book stock (`Stk`) vs physically counted (`Phy`)** per tag → `Diff`/`DiffWt`; `Diff` tab isolates discrepancies (e.g. CHG00007 CHAIN 20C, 14.300, Diff 1). `Reset Stock` rebases book stock to the count.

### (3) CURRENT WEB STATE
`PhysicalStockPage`: a textarea of counted tag numbers → `/stock/physical-reconcile` → tiles `Book/Counted/Matched/Shortage(missing)/Surplus(extra)` + two lists. Captures the core matched/missing/extra idea, count-level only.

### (4) GAPS — checklist
- [ ] **No scan-grid voucher** — web pastes tag numbers; no per-tag row with item/design/size/pcs/weight, no saved verification voucher.
- [ ] **No weight-level diff** (`GrWt/NetWt/DiffWt`) — web is count-of-tags only (no weight variance).
- [ ] **No All/Diff report** with `Stk/Out/Apr/Phy/Diff` columns, no Product/Group/Item-Type filters, no Print/Excel.
- [ ] **No `Reset Stock`** action (rebase book to physical).

---

## 7. ORDER CANCEL — "Order Cancel"  ⛔ NO WEB EQUIVALENT  (video 0BXTuAzGk-c · no transcript)
Web: **not built** — `txn/sales-order/page.tsx` only **creates + lists** orders; no cancel route in `sales/salesOrder.ts`.

### (1) DESKTOP LAYOUT (kf_028, ledger effect kf_036)
Other → Order Cancel. Title "Order Cancel". Header `Vch No`+F1 · Date. Grid: `Sr · OrdNo · AcCode · Ac Name · It Desc · OrdAmt · AdjAmt · KsarAmt · PaidAmt · PaiidAc · Paid Ac Name`. Row: `OrdNo 00003 / 000210 MANOHAR JI SONI / OrdAmt 25000 / AdjAmt 25000 / Ksar 0 / PaidAmt 25000 / PaiidAc 00001 CASH ON HAND`. Live `25000.00 : Cr Amt`. `Employe`. Print/Save/Delete/`< >`. (Sales Order created at kf_008/018 with `Tot Adv Amt`.)

### (2) WORKFLOW + EFFECTS
Select an open sales order → cancel it, **refunding/adjusting the advance**: `OrdAmt` (order value), `AdjAmt` (adjusted), `KsarAmt` (write-off), `PaidAmt` refunded via a chosen `Paid Ac` (e.g. CASH ON HAND). Posts a money-ledger reversal (kf_036 Ledr Report: `Order Cancel 00001 · MANOHAR JI SONI · 25000 · Dr`) and closes/voids the order's open line(s).

### (3) CURRENT WEB STATE — **MISSING**
No Order Cancel screen, no `cancelOrder`/`order-cancel` endpoint. The web sales-order can be created but never cancelled or its advance refunded.

### (4) GAPS — checklist
- [ ] **Build Order Cancel** voucher: pick open order(s) → `OrdAmt/AdjAmt/KsarAmt/PaidAmt + Paid Ac` → post ledger reversal + close order.
- [ ] Reopen/void the consumed `SL_ORD_DETL` line(s) and reverse advance liability.
- [ ] Surface on the sales-order list (a "Cancel" action per open order).

---

## 8. TAG TRANSFER IN ITEM STOCK — "Tag Transfer"  ⛔ NO WEB EQUIVALENT  (video 1EziXFnnH7I)
Web: **not built** — task hint `txn/item-lot` is **lot intake**, the opposite operation.

### (1) DESKTOP LAYOUT (kf_006, kf_014, verify kf_027)
Other → Tag Transfer. Title "Tag Transfer". Header `Vch No`+F1 · Date. Grid: `Sr · TagNo · ItCode · Counter · Design · Size · Pcs · GrWt · LsWt · NetWt · Touch · West% · Fine · `**`TrfrItm · TrfrItmName`**. Sub-grid: `Sr · ItCode · ItName · Pcs · Weight · KrWt · Con% · P/W · Rate · ItAmt · NetAmt`. Example (kf_014): `CHG00006 / CH20C / Counter 001 / Pcs 1 / GrWt 12.400 / Fine 12.400` → `TrfrItm` = OLD GOLD.

### (2) WORKFLOW + EFFECTS
Move a **barcoded tag → a bulk/loose item** (e.g. a broken chain into OLD GOLD). The tag is **removed from barcode stock** and its weight **added to the target bulk item** (`TrfrItm`). Verified (kf_027 Stock Report): OLD GOLD `PrWt` 23.400 (was 11 + 12.4 transferred); CHAIN 20C tag count drops. Pure stock move, no money ledger. (Tag Stock Report kf_021 tracks In/Out/Stock tags.)

### (3) CURRENT WEB STATE — **MISSING**
No tag-transfer screen/endpoint. `txn/item-lot` (`/stock/item-lot`) **intakes new loose lots** into `ITM_LOT_DETL` (+`MAIN_STOCK`) — it does **not** convert an existing tag to bulk/old-gold.

### (4) GAPS — checklist
- [ ] **Build Tag Transfer**: pick existing tag → choose `TrfrItm` (target bulk/OLD GOLD item) → remove tag from barcode stock, add weight to target item (signed `MAIN_STOCK`, no money).
- [ ] Add a verification view (Tag Stock Report In/Out/Stock tabs) or reuse stock report.
- [ ] Do **not** conflate with item-lot intake; this is a barcode→bulk un-tag.

---

## 9. TAG WEIGHT CHANGE — "Tag Weight Change"  (video LiUHTEUPzEw)
Web: `txn/tag-weight-diff/page.tsx` · API `/stock/tag-weight-diff` (tagOps.ts)

### (1) DESKTOP LAYOUT (kf_010, kf_040)
Other → Tag Wt Change. Title "Tag Weight Change". Header `Vch No`+F1 · Date · `Item` (Gold). **Main grid**: `Sr · TagNo · ItCode · ItName · Size · `**`OPcs · OGrWt · OOthWt · ONetWt`** (old) · **`NwPcs · NwGwt · NOthWt · NwNet`** (new) · **`Diff GWt · Diff NWt`** · `Lbr% · LType · LbrRate`. Plus a **stone sub-grid** and a **3rd adjustment grid** (`… Touch · West% · Fine · HmFine · `**`Sign`**` · Rate · ItAmt · OthAmt · NetAmt`). **Party-settlement panel** (kf_040): `Party · Tot Wt Cr/Dr · Cr/Dr Touch · Cr/Dr Fine · 1gm Rate · Cr/Dr Amount · Cr Lbr Amt · Cr/Dr Days · Diff Amount`. **Money panel** with `Payment / Received` columns: `Net/Cheque/Card/Order/Cash/Kasar/Os`. Example (kf_040): CHG00004 CHAIN 916, ONetWt 14.300 → NwNet 14.800, Diff 0.500, LbrRate 600 → `0.500 : Cr Gold`, party = ABC APL.

### (2) WORKFLOW + EFFECTS
Correct a tag's weight (e.g. polish loss/gain). Capture **old vs new gross/oth/net + pcs**, get `Diff GWt`/`Diff NWt`; optionally assign the diff to a **party/karigar** with touch/fine/rate → `Diff Amount`, and **settle money** (Payment/Received) or leave Os; labour (`Lbr%/LType/LbrRate`) can be added. Posts signed `MAIN_STOCK` movement of the diff + valued `AC_DATA` legs against the party.

### (3) CURRENT WEB STATE
`TagWeightDiffPage`: multi-line `Tag · Item · Old Net Wt · New Net Wt · Touch % · Rate` → live `Diff / Diff Fine / Value`; Save → `/stock/tag-weight-diff` posts signed stock move + balanced `AC_DATA` value pair. Good for the **net-weight** delta.

### (4) GAPS — checklist
- [ ] **Net-only** — web ignores **gross (`OGrWt/NwGwt`, `Diff GWt`)** and **pcs change** (`OPcs/NwPcs`); desktop tracks both.
- [ ] **No party assignment** — desktop credits/debits a chosen party (`Party · Cr/Dr Touch/Fine/1gm Rate/Amount/Days · Diff Amount`); web posts to symbolic `AC_DATA` with no party picker.
- [ ] **No labour** (`Lbr%/LType/LbrRate`) and **no `Sign` adjustment sub-grid**, no stone sub-grid.
- [ ] **No money settlement** (`Payment/Received`: Cheque/Card/Cash/Kasar/Os) — web only books the value, never settles it.

---

## 10. LABOUR UPDATE — "Labour and Mrp Update"  (video 1DggmBgcA9I · no transcript)
Web: **closest is** `masters/labour` (generic CRUD over `LBR_MAST`) — **the bulk updater is not built**

### (1) DESKTOP LAYOUT (kf_016, kf_025)
Other → Extra → Labour Update. Title "Labour and Mrp Update". Filter **`Gr Code`** (916 / 916 GOLD ORNAMENTS). Bulk grid per item: `Sr · It Code · It Name · `**`OLbr · NLbr · OLbr% · NLbr% · OMrp · NMrp · OWest% · NWest%`** (Old vs New). Rows = every item/tag in the group (CH916, LR916…). Edit New columns (e.g. row 3 OLbr 500 → NLbr 800). Print/Save/Cancel/Delete. Verified on tags (kf_032 Tag Stock Report Lbr Rate 600/700/800).

### (2) WORKFLOW + EFFECTS
**Bulk-revise** flat labour, labour %, MRP and wastage % for **all items (and their tags) in a group** in one grid (Old→New). Used for price/labour revisions across a product line at once.

### (3) CURRENT WEB STATE
`masters/labour` is the generic single-row master CRUD over `LBR_MAST` (labour-rate definitions by `LBR_CODE`). There is **no group-wise bulk Old→New updater** for item/tag `Lbr/Lbr%/Mrp/West%`.

### (4) GAPS — checklist
- [ ] **No bulk Labour/MRP/Wastage updater** — build the group-filtered grid (`OLbr/NLbr · OLbr%/NLbr% · OMrp/NMrp · OWest%/NWest%`) that rewrites item + tag making/MRP/wastage in bulk.
- [ ] `LBR_MAST` CRUD ≠ this screen (it edits rate definitions, not existing items'/tags' making/MRP).
- [ ] No group picker / Print on a labour bulk-edit surface.

---

## 11. BANK RECONCILIATION — "Bank Reconcile"  ⛔ NO WEB EQUIVALENT  (video 2244Ll1nFxI)
Web: **not built** — no page under `(app)/*`, no `recon/reconcile` route (grep-confirmed).

### (1) DESKTOP LAYOUT (kf_008, kf_018, kf_037)
Other → Extra → Bank Reconcile. Filters `From/To` date + **`Bank`** picker (BANK A/C 00075, HDFC 000203, ICICI 000204, kf_008). Grid: `Sr · BookType · Ac Name · VchNo · VchDate · ChqNo · `**`ClrDate`**` · DrAmt · CrAmt · AmtBal · CrDr`. Rows (kf_018): `Op Balance Dr 217146`, `Gold Tax Inv VIKAS BARVADIYA 00009 27/06 84975 → AmtBal 302121`, `… RONAK JI 00010 28/06 72677 → 374798`. Buttons: **`Bal Chk`** · Print · Save · Cancel · Delete · Exit.

### (2) WORKFLOW + EFFECTS
Bank ledger shows book balance, but cheques take days to clear. Operator enters **`ClrDate`** against each transaction as it clears (kf_037: VIKAS BARVADIYA ClrDate 30/06 → AmtBal recomputed). **`Bal Chk`** then shows the **actually-cleared balance vs book balance** — so you know real available funds before issuing cheques. (Narration: pending cheques 27/28th not yet credited.)

### (3) CURRENT WEB STATE — **MISSING**
No bank-reconciliation screen or endpoint anywhere. (`utilities/reminders` comments reference it but no recon exists.)

### (4) GAPS — checklist
- [ ] **Build Bank Reconcile**: From/To + bank → list bank `AC_DATA` rows with `ChqNo` and an editable `ClrDate`; persist clearing date.
- [ ] **`Bal Chk`**: compute cleared-balance (only `ClrDate`≤asOf) vs book-balance; show pending (uncleared) cheques.
- [ ] Print/Excel reconciliation statement.

---

## 12. REMINDER ENTRY — "Reminder Entry" + Reminder Report  (video AN2AiLXuP28)
Web: `utilities/reminders/page.tsx` (send-tool) · API `/reminders/*` (page notes routes may be unwired)

### (1) DESKTOP LAYOUT (kf_012, kf_028, kf_056)
Other → Reminder Entry. Title "Reminder Entry" (kf_012): `Vch No`+F1 · Date/time/day · grid `Sr · AcCode · Ac Name · It Desc · Date` · Employe · Print/Save/Cancel/Delete. **Reminder Report dashboard** (kf_028, shown on Home): `From/To Date` + grid `AcName · Remark · EntDate · RemDate · Mobile` + category buttons **`Order Rem · Sales Rem · Wh Sales Rem · Dhiran Rem · Birthday And Anv · Schm Rem · Reminder Entry · Item In Out`**. Birthday/Anv feed from **Party Master → Other Detail** `Birth Date / Anv Date` (kf_056).

### (2) WORKFLOW + EFFECTS
(a) **Manual reminder voucher**: pick account → write `It Desc` → set `Date` (e.g. "deposit HDFC cheque on 07/07", kf_028 row). (b) On Home/Report, today's reminders auto-surface across categories: **Order** delivery dates, **Sales/Dhiran** payment-due, **Wh Sales**, **Scheme**, **Birthday/Anniversary**, **Item In Out**. Pure scheduling/alerting (SMS sent separately via the Sms menu).

### (3) CURRENT WEB STATE
`RemindersPage`: two tabs — **Outstanding** (overdue parties → WhatsApp/SMS send via `/reminders/send`) and **Birthdays** (party birthdays/anniversaries on a date → send), editable message templates. It is a **send tool**, and endpoints may be unwired (404-tolerant).

### (4) GAPS — checklist
- [ ] **No manual Reminder Entry voucher** (account + description + reminder date) — web has no way to create an ad-hoc reminder.
- [ ] **Missing categories**: Order, Wh Sales, Dhiran, Scheme, Item-In-Out reminders (web only does Outstanding ≈ Sales-due + Birthday/Anniversary).
- [ ] **Model mismatch**: desktop reminder = a dated dashboard/alert (view on Home); web = a WhatsApp/SMS sender. Need the entry+dashboard, not only outbound messaging.
- [ ] `/reminders/*` may be **unwired** (page handles 404) — verify backend before relying on even the send path.

---

## ⛔ DESKTOP SCREENS WITH NO WEB EQUIVALENT (build from scratch)
1. **Order Cancel** (§7) — cancel sales order + refund/adjust advance, ledger reversal. *No screen, no route.*
2. **Tag Transfer in Item Stock** (§8) — barcode tag → bulk/OLD-GOLD un-tag. *item-lot is the wrong/opposite op.*
3. **Bank Reconciliation** (§11) — ClrDate entry + Bal Chk cleared-vs-book balance. *No screen, no route.*
4. **Stock Adjust Entry** (§5) — `±Sign` manual stock correction voucher. *Only a read-only reconcile exists.*
5. **Daily Rate entry** (§3) — Gold-10gm/Silver-1Kg → per-group rate derivation + live `ToDays Rate`. *Only raw RATE_MAST CRUD.*
6. **Labour Update** (§10) — group-wise bulk Old→New Labour/Lbr%/MRP/West% editor. *Only LBR_MAST CRUD.*
7. **Reminder Entry voucher + multi-category dashboard** (§12). *Only an Outstanding/Birthday send tool.*
8. **Tag Print / Only Tag Entry** label print (§4) — QR `916` label + Print-file template. *Cancel exists; print does not.*
9. Karigar **Design-Issue / Repair (Kr Repar Isu/Rec, Cust Repar)** books (menu kf_015). *Only Issue + Receive built.*

## TOP CROSS-CUTTING GAPS (priority order)
1. **Karigar Issue/Receive are 3–4 column toys** vs the desktop's full tag/labour/stone/barcoding grids + payment panels. Receive cannot **tag pieces into stock** or book the **labour `Cr Amt` payable**; Issue cannot show/settle `Dr Gold`. (`KarigarForm.tsx` — highest-impact mfg gap.)
2. **Six dedicated "Other" vouchers are missing or wrong**: Order Cancel, Tag Transfer, Bank Reconciliation, Stock Adjust (±Sign), Labour Update (bulk), Daily Rate (entry). Each needs a real screen + endpoint.
3. **Tag-level richness missing everywhere**: `Counter · Design · Size · Mrp · KrCode · Sign` and old/new **gross + pcs** (web only ever tracks net weight) — affects Tag Wt Change, Stock Adjust, Physical Stock, Tag Cancel.
4. **No party assignment / money settlement** on metal adjustments (Tag Wt Change party Cr/Dr + Payment/Received; Karigar Os/Cr Amt).
5. **No tag-label / QR `916` printing** and no Original/Duplicate/Triplicate voucher print on any Module-D screen.
6. **No live rate or live party balance** (`ToDays Rate`, status-bar `Fine Gold/Silver/Rate Date`, on-screen `: Dr Gold`/`: Cr Amt`) — pervasive UX gap; Daily Rate is its source.
7. **Reports/verification absent**: Physical Stock All/Diff report (Stk/Phy/DiffWt), Tag Stock Report (In/Out/Stock tabs), Bank Reconcile statement.
8. **Universal omissions** (as in Modules A/B): Vch No/Date/weekday/time, Ref No, Employe, Vch Desc, image attach, Print/Delete/`< >` nav.

## Frames read (evidence)
- Karigar Issue **Gd0TSp2OoXA**: kf_006 (home menu), 015 (Karigar menu + Stock Report), 023 (Party Master grp10), 031 (Issue screen), 038 (Ledr DrGold 100).
- Karigar Receive **CO9Ro-ZeeE8**: kf_007 (issue recap), 016 (Receipt 3 grids), 024 (filled + barcoding sub-grid + Cr Amt 6500), 032 (Orig/Dup/Trip print), 039 (Stock In).
- Daily Rate **5mIg4yRl0aE**: kf_008/020 (Rate Master + Other menu), 032 (Group Master rate-touch), 044 (rate→Gold Tax Invoice).
- Tag Cancel **VzkTOy9vGL0**: kf_002/003, 004 (QR `916` label CHG00004), 005 (Tag Print/Only-Tag-Entry grid).
- Stock Adjust **yP6XAirZ36I**: kf_006 (F-key menu + Sign grid), 013, 019 (OG line), 025 (Sign + 1.000).
- Physical Stock **QEPhVyaV_xU**: kf_006 (scan grid + Reset/Report), 014 (tag picker), 021 (report filters All/Diff), 028 (Diff Stk/Phy/DiffWt).
- Order Cancel **0BXTuAzGk-c**: kf_008/018 (Sales Order + Tot Adv), 028 (Order Cancel grid), 036 (Ledr "Order Cancel" Dr 25000).
- Tag Transfer **1EziXFnnH7I**: kf_006 (TrfrItm grid), 014 (CHG00006→OLD GOLD), 021 (Tag Stock Report), 027 (Stock Report OLD GOLD 23.4).
- Tag Wt Change **LiUHTEUPzEw**: kf_010 (old/new + party panel + Payment/Received), 025, 040 (CHG00004 14.3→14.8 + party picker), 052 (scan).
- Labour Update **1DggmBgcA9I**: kf_007 (home), 016 (Labour&Mrp grid O/N), 025 (NLbr 800 + Extra menu), 032 (Tag Stock Lbr rates).
- Bank Reconcile **2244Ll1nFxI**: kf_008 (bank picker), 018 (txn list + Op Bal), 028 (Bal Chk), 037 (ClrDate entered → AmtBal).
- Reminder **AN2AiLXuP28**: kf_012 (Reminder Entry voucher), 028 (Reminder Report categories), 044 (Sales Order reminder), 056 (Party Master Birth/Anv Date).
