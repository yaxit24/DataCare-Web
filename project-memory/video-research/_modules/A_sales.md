# A_sales — Sales domain UX-parity map (desktop golden master → web)

_Phase D video-research. Desktop = DataCareNext tutorial keyframes (1280px screens) + Hindi narration.
Web = `web/apps/web/app/(app)/txn/*`. Spec cross-ref = `web-implementation-spec/03_Modules/2_Sales/`._

**Corpus:** `project-memory/video-research/transaction/<id>/{transcript.txt,keyframes/kf_*.jpg}`
**Frames sampled** (evenly): Sales Invoice 1/3/4/7/8 · Sale Return 2/9/20/37/45 · Sales Order 1/4/7/8/10/12 · Labour 9/22/35/46/57/63 · Approval 1/4/6/10/12.

> **Headline finding:** the desktop sales screens are dense metal-accounting forms (main item grid +
> a CHARGES sub-grid [HM/RD] + a 2nd/3rd metal-exchange grid + an order-link grid + a ~15-row totals
> panel + live-rate ticker + party-outstanding + item photo). The web pages are thin single-grid forms.
> The spec marks variants "🟩 BUILT" at the **engine/API** level, but the **UI pages expose only a
> fraction** of the desktop fields and flows. Gaps below are UI/feature gaps against the golden master.

---

## Cross-cutting gaps (apply to most/all sales screens)

- [ ] **Live rate ticker** — every desktop frame shows a status bar: `Fine Gold : 49368 | Fine Silver : 69917 | Rate Date : 18-04-2021 | Service End`. No web equivalent and no "pull live rate into Rate cell".
- [ ] **CHARGES sub-grid (HM / RD)** — desktop has a dedicated 2nd grid for other-charge line items: `HM = HALL MARK CHARGES` and `RD = RODIAM CHARGES` (kf_004 Sales: HM 300, RD 500) feeding the line `OthAmt`. No web page has any "other charges" line concept.
- [ ] **Second/third metal grid (old-gold/old-silver exchange, multi-row)** — desktop has a full metal grid (`ItCode|ItName|Pcs|GrWt|NetWt|Touch|Fine|Rate|NetAmt`). Web at best has a single old-gold `net/touch/rate` trio (sales only).
- [ ] **Item photo** — desktop shows the tag's photo and zooms on double-click (Sales kf_003); web has none.
- [ ] **Party outstanding on select** — desktop prints e.g. `15000.00 : Dr Amt` next to the party (Sales kf_004); web shows nothing.
- [ ] **Rich totals panel** — desktop totals column includes `TCS Amt`, `ROF Amt` (round-off), `Order Amt`, `Old Gold Amt`, `Old Silver Amt`, `Scheme Amt`, `Kasar Amt`, `Cash Paid Amt`, `Os Amt` (outstanding). Web entry UIs expose at most cash/card/upi/cheque + a computed balance.
- [ ] **Print template selector + Crystal-style outputs** — desktop header has a `Print [SalesBillA4Gst ▾] [Set]` dropdown and prints "Gold Tax Invoice" / "Credit Note" / labour invoice / approval note with HSN, Other-Charg, Taxable-Value columns and signatures. Web has only a single "View Invoice PDF" link (sales) — unverified for returns/labour/order/approval; no template choice.
- [ ] **Keyboard/scanner flow** — desktop is F-key driven: `F1` new/lookup, `F2` save, Enter→next cell, barcode-scan types into `TagNo`+Enter to add a row, `F4` opens Party Master inline. Web uses mouse + `LookupPicker`; Enter-to-advance / scan-to-row not evidenced.
- [ ] **Design / Size / LsWt columns** — desktop item grids carry `Design`, `Size`, and `LsWt` (less/stone wt, so `NetWt = GrWt − LsWt`). Web grids omit Design/Size and treat NetWt as an independent input (no LsWt).

---

## 1. Sales Invoice — `DF_P2GD9AuU` → `txn/sales/page.tsx`

### (1) DESKTOP LAYOUT (kf_004, kf_008 = full entry; kf_007 = print; kf_001 = menu)
- **Header:** `Vch No`[auto]+`F1` · `Vch Date`+time+weekday · `Apr No`[approval link]+`[A]` · `Ref No` · **Party** picker (code `000201` + name `VIKAS BARVADIYA`) with **party balance** `15000.00 : Dr Amt` (red) · `Print [SalesBillA4Gst ▾]` `[Set]`.
- **Main item grid:** `Sr | TagNo | ItCode | Design | Size | Pcs | GrWt | LsWt | NetWt | ItRate | ItAmt | Lbr% | LbrRate | LbrAmt | OthAmt | TotAmt | Tax% | NetAmt` (cols confirmed kf_008). Total row beneath.
- **Print Name** field (`CHAIN 916`) + "It Name" label.
- **CHARGES sub-grid:** `Sr|ItCode|ItName|Pcs|Weight|Con%|P/W|Rate|ItAmt|NetAmt` → rows `HM / HALL MARK CHARGES / 300.00`, `RD / RODIAM CHARGES / 500.00` (kf_004).
- **2nd metal grid (old-gold exchange):** `Sr|ItCode|ItName|Pcs|GrWt|LsWt|NetWt|Touch|Fine|Rate|NetAmt`.
- **Bottom-left:** item **photo** thumbnail · `Employe`[001] · `Bank` · `Vch Desc` · `CrDay`[0].
- **Ord No grid:** `Sr | Ord No | Ord Amt` (links sales orders to adjust advance).
- **Totals panel (right):** `Net Amt 800` · `Disc Amt` · `Tax Amt [GST 3% ▾] 3.00 → 24.00` · `Tcs Amt` · `Rof Amt` · `Total Amt 824` · `Cheque Amt` · `Card Amt` · `Order Amt 0` · `Old Gold Amt` · `Old Silver Amt` · `Scheme Amt` · `Cash Amt` · `Cash Paid Amt` · `Kasar Amt` · `Os Amt 824`.
- **Toolbar:** ◄ ► · Print · Save · Cancel · Delete · Exit.

### (2) WORKFLOW + on-screen effects
- Narration: *"Transaction-1 → Sales … yahan do glass milenge — Gold ek Silver"* → choose Gold/Silver section. Vch No/Date auto. Enter to **Party**: walk-in cash OR pick account; *"F4 press karenge → Party Master open"* to create inline; on select, party balance fills.
- **TagNo**: scan barcode or type a key → barcoded-stock list; pick → weights auto-fill and the **item photo** appears (kf_003, double-click zoom). `ItRate` typed (`4500/g`); `Making 12%` *"bill banane ke time 10% kar sakte ho"* (editable per-bill); `LbrRate/LbrAmt` auto from %; HM+RD → `OthAmt`; `TotAmt` per line. Loose item via `ItCode` if untagged.
- Escape → totals. `Disc` (₹1000 demo) → `GST 3%` auto → `Total`. Tender: `Cheque 30000` → **bank-list popup** to pick deposit bank; `Card`; partial pay, remainder on credit (`CrDay`) → *"10–15 din me clear karunga"* → party `Os`.
- **Print** "Gold Tax Invoice" (kf_007): firm + `GSTIN 24ALOPV4774H2ZF`, `Invoice No T1-00001`, Billed-to block, item table `SNo|Product Description|HSN Code|Pcs|Gr Wt|Net Wt|Rate|Amount|Other Charg|Taxable Value` (row `CHG00001 - CHAIN 916 / 12.650 / 4500 / 56925 / 6492 / 63417`).
- `F2` **Ledger Report**: auto Dr bank(cheque)+cash, Disc, GST, Sales amt, party Os Dr. `F12` **Tag Stock**: sold tag leaves stock (Out Tag).

### (3) CURRENT WEB STATE (`sales/page.tsx`)
- Header: Book · Year · Location · **Party** (LookupPicker accounts) · Customer Name · `Tax %`(3) · `Discount ₹` · `Inter-state` (CGST+SGST/IGST).
- **Settlement panel:** Cash · Card · UPI · Cheque · Old Gold Net · Old Gold Touch% · Old Gold Rate → shows `Old gold ₹ · Paid ₹ · Balance due ₹`.
- **Items grid:** Item(picker) · Tag(picker, auto-fills netWt/grossWt/touch/rate) · Pcs · Gross · Net Wt · Touch% · Rate · Making/g · Fine(calc) · Amount(calc).
- Inline totals: Taxable · Tax · Total. Save → `Voucher #`, **View Invoice PDF**, totals tiles.
- calc: `fine=net×touch/100`, `metal=fine×rate`, `making=net×making/g`, `net=metal+making`.

### (4) CONCRETE GAPS
- [ ] No **Design / Size / LsWt** columns (NetWt not derived from GrWt−LsWt).
- [ ] No per-line **Lbr% / LbrRate / LbrAmt** split or editable making %; web has only a flat `Making/g`.
- [ ] No **CHARGES sub-grid (HM / RD)** → `OthAmt` cannot be itemized; invoice "Other Charg" column has no source.
- [ ] No **multi-row old-gold/old-silver metal grid** (only a single net/touch/rate trio in settlement).
- [ ] No **Approval No (`Apr No`)** field → cannot pull approved-out items into the bill (breaks approval→sale).
- [ ] No **linked Sales-Order grid (`Ord No/Ord Amt`)** → cannot adjust order advance against the bill.
- [ ] No **TCS / ROF(entry) / Order / Old-Silver / Scheme / Kasar / Os** in the settlement UI; no `Cash Paid` vs `Cash`.
- [ ] No **cheque→bank picker**; cheque is a bare amount (no deposit-account selection).
- [ ] No **Employe (salesman) / Bank / Vch Desc / Credit-Days** inputs.
- [ ] No **party-outstanding** display on select; no **item photo**; no **live-rate ticker**.
- [ ] No **Print-template selector**; grid captures no **HSN** (invoice HSN column unsourced).
- [ ] No **Gold/Silver section** switch; no **Print Name** override field.

---

## 2. Sales Return / Credit Note — `dVfvnhzWQKI` → `txn/sale-return/page.tsx`

### (1) DESKTOP LAYOUT (kf_009 blank, kf_020 filled, kf_037 print, kf_045 stock)
- **Header:** `Vch No`+`F1` · `Vch Date`+time+day · **`Sale Bill`** ref `[00002][2021-2022][026]` + `[S]` picker (links original invoice) · **Party** (`000202 RAKESH BHAI SONI`).
- **Main item grid:** `Sr|TagNo|ItCode|ItName|Design|Pcs|GrWt|OthWt|NetWt|ItRate|ItAmt|Lbr%|LbrRate|LbrAmt|OthAmt|NetAmt`.
- **Charges grid:** `Sr|ItCode|ItName|Pcs|KrWt|Weight|Con%|P/W|Rate|ItAmt|NetAmt`.
- **"Receive Item" grid** (returned goods back to stock): `Sr|RecCode|TagNo|Receive Item|Counter|Design|Size|Pcs|GrWt|OthWt|NetWt|Rate|ItAmt|Lbr%|Ltype|LRate|LAmt` (kf_020: `CH916 CHG00002 CHAIN 916 ctr 001 / 15.000 / 4800 / 72000 / LRate 600 / LAmt 9000`).
- **Old-metal grid:** `Sr|Itm|ItName|Pcs|Gwt|Con%|P/W|Rate|ItAmt|NetAmt`.
- **Totals panel — DUAL `Payment | Received` columns:** `Net Amt 81000 · Sale Tax GST 3% 2430 · Total Amt 83430 · Cheque · Card · Cash · Kasar · Os 83430`; plus `Ac Cr Amt 81000` / `Ac Dr Amt 0`, running `83430.00 : Cr`. `Employe`, `Vch Desc`.

### (2) WORKFLOW + effects
- Narration: *"Transaction → Sales Return → Credit Note"*. Pick party; **import from original sale bill** (`[S]`/Sale Bill) — *"same-to-same barcode … yes karo"*, or generate a new barcode manually. Sold line auto-fills (kf_020). *"weight change kar sakte ho — 700 gram"* and *"MRP bhi change kar sakte ho"*.
- Refund options: *"cheque me daal sakte, card, cash"* OR — *"return nahi dena, amount unke account me credit kar do"* → leave tender blank → full `83430` → `Os`/`Ac Cr`.
- Save → **Credit Note** print (kf_037): `CR-00001`, `Against Invoice No` / `Date Of Invoice` linkage, Billed-to, item table (same shape as invoice).
- `F2` Ledger: party **credited 83030/83430**. Returned tag re-enters stock — kf_045 **Tag Stock Report** shows `CRNOT 00001 CHG00002 CH916` back in stock; report tabs `In Tag | Out Tag | Stock Tag | Mrp Tag | Apr Panding | All Tag`.

### (3) CURRENT WEB STATE (`sale-return/page.tsx`)
- Header: Book `SRT` · Year · Party(picker) · Customer Name · `Orig Bill No`(free text) · Tax% · Discount · Inter-state.
- **Returned Items grid:** Item · Tag(picker auto-fill) · Pcs · Gross · Net Wt · Touch% · Rate · Making/g · Fine · Amount.
- Inline totals; Save → *"Return saved — credited ₹X to customer"* (always credit).

### (4) CONCRETE GAPS
- [ ] No **original-invoice picker (`[S]` Sale Bill)** that auto-imports sold lines/tags — web has only free-text `Orig Bill No`; operator must re-key every returned item.
- [ ] No **refund settlement** (cheque/card/cash) — web **always credits to account**; desktop offers refund-or-credit.
- [ ] No **`Payment | Received` dual-column** totals; no **Kasar**, no **Os** display, no `Ac Cr/Dr`.
- [ ] No **"Receive Item" capture** (`RecCode / Counter / Ltype / LRate / LAmt`); web restores stock via tag but drops counter/receive-code/labour-type.
- [ ] No **OthWt** column, no **charges sub-grid (HM/RD)**, no **old-metal grid**.
- [ ] No **Design/Size**, no **Lbr%/LType** split (flat Making/g), no **MRP edit** (narration edits MRP on return).
- [ ] No **Credit-Note print** wired on the return result; no `Against Invoice No`/`Date Of Invoice` linkage on output (verify `invoice.ts` handles returns).
- [ ] No **Employe / Vch Desc** fields.

---

## 3. Sales Order — `Sq-Xo4E5GTE` → `txn/sales-order/page.tsx`
_(transcript.txt empty / "no captions" — layout from frames; advance-in-gold flow corroborated by the Labour video kf_022.)_

### (1) DESKTOP LAYOUT (kf_004 entry; kf_008/010 Order Report)
- **Header:** `Vch No`+`F1`+`[All]` · `Vch Date`+time+day · `Ref No` · **Party** picker (+ party name & address shown, e.g. `VIKAS BARVADIYA / 505 SHIVALIK SATYAMEV …`).
- **Main item grid:** `Sr|TagNo|ItCode|Design|Size|Pcs|GrWt|LsWt|NetWt|ItRate|ItAmt|LType|LbrRate|LbrAmt|OthAmt|TotAmt|Tax%|NetAmt`.
- **`Remark`** field. **Charges grid** (`…Weight|Con%|P/W|Rate|ItAmt|NetAmt`). **Old-metal advance grid** (`…GrWt|NetWt|Touch|Fine|Rate|NetAmt`).
- **Bottom-left:** `Employe` · `Bank` · `Vch Date` (cheque date).
- **Totals panel:** `Net Amt 66780 · Tax Amt · Total Amt · Cash · Cheque · Card · Old Gold Amt · Old Silver Amt · Scheme Amt · Tot Adv Amt`.
- **Order Report** (Reports → Order Report, kf_008/010): filters `From/To Date · ItCode · Book · GrCode · Party · City · Area · Item Type`; columns `Order No | Order Date | Name | … | Order Adv | Order Adjust | Pending Amt` (row `00001 / VIKAS BARVADIYA / Adv 30000 / Adjust 0 / Pending 30000`); action buttons **`Order Report | Order Advance | Order Adjust`**.

### (2) WORKFLOW + effects
- Tran 1 → Sales Order; pick party (create via Party Master if new). Enter ordered items (design/size/weight/making). **Advance** may be cash/cheque/card **or old gold/old silver** (3rd metal grid + `Old Gold Amt` → `Tot Adv Amt`) — Labour video kf_022: 15g chain order with **10g old-gold advance**. Save → order booked, **no stock-out**.
- Later: **Order Advance** (add advance), **Order Adjust** (consume against a sale/labour bill); `Pending Amt` tracks the balance. Consumed by Sales/Labour via their `Ord No` grid.

### (3) CURRENT WEB STATE (`sales-order/page.tsx`)
- Header: Customer(picker) · Customer Name · `Tax %` · `Advance ₹` (single number).
- **Order Items grid:** Item · Design · Pcs · Gross · Net · Touch · Rate · Making/g · Net Amt · Remark.
- Pre-tax total; Place Order → *"Order #N — total ₹X, advance ₹Y"*. **Recent Orders** table: Order# · Date · Customer · Name · Total · Advance.

### (4) CONCRETE GAPS
- [ ] **Advance is a single ₹** — no payment-mode split and **no old-gold/old-silver advance grid** (the core jewelry flow: take metal as advance); no `Tot Adv Amt` composition.
- [ ] No **Size**, no **LsWt**, no **LType** per line (flat Making/g), no **OthAmt / charges sub-grid (HM/RD)**.
- [ ] No **Tax Amt / Total Amt** settlement panel (web shows only pre-tax total) and no Net/Tax/Total breakdown.
- [ ] No **Employe / Bank / cheque-date** fields.
- [ ] No **Order Advance / Order Adjust** post-actions and no **Pending Amt** tracking; Recent Orders has no pending/adjust column and no link to the consuming sale/labour bill.
- [ ] No **TagNo** column (desktop can reference existing tags); no **party address** display; no **print** of the order copy.

---

## 4. Labour Invoice — `tLThVxaKF5o` → `txn/labour-sale/page.tsx`
_(Tran 2 → Labour Work. Core idea per narration: customer gives gold in advance, asks to make an
ornament, pays only making + metal on any shortfall.)_

### (1) DESKTOP LAYOUT (kf_009 blank, kf_046 filled, kf_057 bank-pick, kf_063 print)
- **Header:** `Vch No`+`F1` · `Vch Date`+time+day · **`Item [Gold/Silver ▾]`** selector · **Party** picker (`000206 RONAK JI`).
- **Main item grid:** `Sr|TagNo|ItCode|ItName|Design|Pcs|GrWt|OthWt|NetWt|Touch|Fine|LType|LbrRate|LbrAmt|OthAmt|NetAmt` (kf_046: `CH916 CHAIN 916 / 16.000 / Fine 16 / LbrRate 600 / LbrAmt 9600`).
- **Charges grid** + two metal summary blocks (`: Amt / : Gold / : Silvr`).
- **Old-metal-received grid:** `Sr|ItCode|ItName|Pcs|GrWt|NetWt|Touch|Fine`.
- **`Ord No` grid:** `Sr|Ord No|Ord Weight|Ord Amt` — pulls the advance order (`00002 / 10.000`).
- **Metal reconciliation block:** `Tot Wt Dr 16 · Tot Wt Cr 0 · Order Wt 10 · 1gm Rate 4800 · Cr Fine / Dr Fine 6 · Cr Amount / Dr Amount 28800 · Diff Amount`.
- **Totals panel — DUAL `Payment | Received`:** `Net Amt 28800 · Sale Tax GST 3% → 864 · Lbr Amt 9600 · Lbr Disc · Lbr Tax GST 5% → 480 · Total Amt 39744 · Cheque 39744 · Card · Order · Cash · Kasar · Os 0`. **Bank picker popup** for cheque (kf_057: `BANK A/C / HDFC / ICICI`). `Employe · Cr Days · Vch Desc`.

### (2) WORKFLOW + effects
- Prereq Sales Order with old-gold advance (kf_022). Tran 2 → Labour Work; pick party; enter the **made item** (16g chain, making 600/g → 9600). Pull order via `Ord No` (10g). System **"less"** the 10g advance (`Less Order Gold`) leaving **`Os Gold` 6g (Dr)** → `6 × 4800 = 28800` metal due.
- **Dual GST** (narration: *"PM ke upar 3% … making 9600 ke upar 5%"*): Sale Tax 3% on metal `864` + Lbr Tax 5% on labour `480` → **Total 39744**, paid full by cheque → bank picker → `Os 0`.
- **Print** (kf_063): columns `Cr Gold | Dr Gold | Paid Amt | Received Amt`; `Gold Weight Dr 16 · Less Order Gold 10 · Os Gold 6 · Gold Rate 4800 · Net Amount 28800 · Labour Amount 9600`; GST split `CGST/SGST` for metal (1.5%+1.5%) and labour (2.5%+2.5%); `Total 39744 · Chq 39744 · Bill Outstanding 0`; party signature.

### (3) CURRENT WEB STATE (`labour-sale/page.tsx`)
- Header: **Customer (plain text — NOT a picker)** · Year · `Tax %`(5) · Inter-state.
- **Labour Lines grid:** Item(plain text) · Labour Type(fixed/per_gram/per_piece/percentage) · Net Wt · Pcs · `Rate/%/Fixed` · **Metal Amt (manual)**.
- Save → posts to `/sales` with `coBook:'LBR'`; result tiles.

### (4) CONCRETE GAPS
- [ ] No **party picker** and no **item/tag picker** (both free-text) — no master lookup.
- [ ] No **Gold/Silver** Item selector.
- [ ] **No old-gold-received grid and NO order linkage (`Ord No/Ord Weight`)** → the entire *"less the advance gold, charge only the shortfall"* mechanic is missing. **This is the core of labour billing; the web cannot perform it.**
- [ ] No **metal reconciliation** (`Tot Wt Dr/Cr · Order Wt · Cr/Dr Fine · Os Gold · Diff Amount · 1gm Rate`).
- [ ] **Single `Tax %` only** — no **dual GST** (Sale Tax 3% on metal + separate **Lbr Tax 5%** on labour) and no **Lbr Disc**; desktop bills + prints them split.
- [ ] **`Metal Amt` is manual** — desktop derives metal from Os-gold shortfall × rate.
- [ ] No **settlement** (cheque/card/cash/order) and **no bank picker** → cannot record payment.
- [ ] No **print** (Cr/Dr gold, Less Order Gold, Os Gold, signatures).
- [ ] No **OthWt / Design / Touch / Fine** columns, no **charges sub-grid**, no **Cr Days / Employe / Vch Desc**.

---

## 5. Approval Issue / Received — `DpdQpC7Od2M` → `txn/tour/page.tsx`
_(Tran 2 → Approval Isu / Approval Rtn + Reports → Approval Rpt. Web maps this to a "Tour/Approval Issue" page — **issue side only**.)_

### (1) DESKTOP LAYOUT
- **Approval Issue** (kf_004): `Vch No`+`F1` · `Vch Date`+time+day · **Party Code + Party (`RAKESH BHAI SONI`) + Mo**. Grid: `Sr|TagNo|ItCode|Counter|Design|Size|Pcs|GrWt|LsWt|NetWt|Touch|West%|Fine|ItRate|ItAmt|LbrRate|LbrAmt|OthAmt|Mrp` + charges sub-grid + `Employe/Vch Desc`. Print = approval note (`SNo|Item Name|Pcs|Gr Wt|Net Wt|Rate|Item Amt|Oth Amt|Net Amount`; e.g. chains `CHG00004/05/06`, total 3 / 42.000).
- **Approval Return** (kf_012): `Vch No`+`F1` · `Vch Date` · **`Isu No`+`[F1]`** (links the issue voucher) · Party. Same rich grid (incl. `West%`). Partial selection — returns 2 of 3 (`CHG00004` + `CHG00006`, total 26.700).
- **Approval Reports** (kf_006/010): action buttons **`Approval Isu | Approval InOut | Approval Panding`**; party-wise issue list (`Tag | Gr Wt | Net Wt | Item amt | Lbr amt | Oth amt | Bill Amt`, party total 42.000 / 25200) and **In/Out reconciliation** with a `Pending` count. (`Apr Panding` also a tab on Tag Stock — kf_045 of the return video.)

### (2) WORKFLOW + effects
- Narration: *"kisi party ko 10-15 item approval pe diye"* → **Approval Issue** to a customer; Save → issued tags **leave stock** and move to **Pending approval**.
- **Approval Return**: select `Isu No` → *"pura return lena hai? Yes"* (all) or *"No → particular tag scan/select"* (partial). Return chains 4 & 6; **chain 5 stays**.
- Remaining item billed via **Sales** using the **`Apr No`** link → tax invoice. Reports show issued vs received vs pending; stock: returned tags back, sold tag out, pending → 0.

### (3) CURRENT WEB STATE (`tour/page.tsx`)
- **"Tour / Approval Issue" — issue only.** Header: Book `TUR` · Year · Location · **Salesman/Employee** (picker) · Name · Description. Grid: Item · Tag(picker auto-fill) · Pcs · Gross · Net Wt · Touch% · Fine. Totals: Pcs/Net/Fine. Save → `/tour/issue` → `Voucher#, fine`.

### (4) CONCRETE GAPS
- [ ] **No Approval Return / Approval Result screen at all** — web only issues, never receives back. The loop cannot be closed. **(Biggest gap.)**
- [ ] No **`Isu No` linkage** for return; no **partial-tag return** selection.
- [ ] No **Approval reports** (Issue list / In-Out reconciliation / Pending).
- [ ] No **convert-to-sale (`Apr No`)** path from approval into an invoice.
- [ ] **Recipient mismodeled as "Salesman/Employee" (tour)** vs desktop **Party/customer** (approval issued to a customer, e.g. RAKESH BHAI SONI) — semantic mismatch; approval is customer-facing, not a salesman tour.
- [ ] Grid missing **Counter, Design, Size, LsWt, West%, ItRate, ItAmt, LbrRate, LbrAmt, OthAmt, Mrp** — desktop captures valuation (Mrp/rate/labour) on issue so the later bill/return stays consistent.
- [ ] No **charges sub-grid**; no **print** of the approval issue/return note.
- [ ] No **"Pending approval" stock-bucket** visibility (desktop Tag Stock `Apr Panding` tab).

---

## Spec cross-reference notes (`03_Modules/2_Sales/`)
- `TR_SALE.md` confirms canonical tables/cols: `SL_DATA/SL_DETL/SL_IDTL`, `AC_DATA` (balanced Dr/Cr), `TAX_DATA` (CGST+SGST | IGST), `BILL_OS_DATA`, `MAIN_STOCK` (TR_TYPE='S'), `TAG_STOCK`, `SL_PR_DETL` (old-gold/fixing), `SL_ORD_ADJ` (order-advance adjust).
- README form inventory marks **LBR / HM / ORD / RTN / WH / SL_ORD_ADJ** as 🟩 BUILT and says *"old-gold exchange + split tender are already in `createSale`"*. **Caveat:** that is engine/API parity — the **UI pages audited above expose only a small subset** (e.g. labour-sale UI has no order-link/metal-recon; sale-return UI has no original-bill import or refund; tour UI has no return/report). The gaps are therefore primarily **front-end wiring** to engine capability, plus genuinely-absent flows (Approval Return/Reports, Order Advance/Adjust, CHARGES sub-grid, dual-GST labour, live-rate ticker).
- Spec's own ASCII layout is itself thinner than the desktop golden master (it omits the CHARGES sub-grid, 2nd metal grid, Tcs/Rof/Kasar/Scheme/Order totals, Apr-No link, photo, rate ticker) — worth reconciling the spec to the video evidence too.
