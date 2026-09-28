# KB — "Other" playlist (Utilities / Inventory Ops) — DataCareNext Jewellery ERP

Desktop-application knowledge base derived from the YouTube tutorial corpus (Sarvam Hindi
transcripts + scene keyframes), cross-referenced against the decompiled desktop
(`extracted_code/DataCareNext/DataCareNext/*.cs`) and the web replica
(`web/apps/api/src/modules/**`, `web/apps/web/app/(app)/**`).

All ten screens live under the desktop top menu **Other** (`MENU_DATA` `BTN_NAME='Other'`,
`MAIN_SRNO='04'`), except **Labour Update** which sits under **Other → Labour Update** in the
left rail (`MS_AUTO_ITEM` bulk updater) but maps to a web `/masters/*` route. The desktop is a
VB.NET WinForms app (login title bar `01 - DATACARE SOFTECH - 2021-2022`); the persistent left
rail lists: Daily Rate · Only Tag Entry · Tag Cancel · Tag Print · Stock Adjust · Order Cancel ·
Reminder · Physical Stock · Tag Transfer · Tag Wt Change · Extra · Sms · Labour Update.

## Stock/ledger primitives (apply to every screen below)
- **Stock truth = `MAIN_STOCK`** — there is no stored balance; on-hand = Σ signed movements
  (`ITM_SIGN` `+`/`−` over `ITM_PCS/ITM_GWT/ITM_NWT/ITM_FINE`). Desktop engine `Ac_Stock.cs`
  (`INSERT INTO MAIN_STOCK …`); web `stock.ts onHandNet()`.
- **Fine** = `NetWt × Touch / 100` (grams of pure metal). Used everywhere weight is valued.
- **Money ledger = `AC_DATA`** (Dr/Cr, `SIGN` `D`/`C`); day-book mirror = `ROJ_MEL_DATA`
  (desktop `Ac_Ledr.cs` / `Ac_Rojmel.cs`). Balanced posting Σ DR = Σ CR.
- Utility voucher headers/details for TAG CANCEL / STOCK ADJUST / PHY STOCK / TAG TRFR /
  COUNTER TRFR are stored in **`BAR_CAN_DATA` / `BAR_CAN_DETL`** (`BOOK_DATA.BOOK_TBL_NAME`);
  ORDER CANCEL is stored in **`SL_ORD_ADJ`** (per `MS_UPDATE.cs` / `Mfg_Module.cs`).
- Voucher key everywhere = (`CO_CODE`,`LC_CODE`,`CO_YEAR`,`CO_BOOK`,`VCH_NO`); web reverses by key.

## Summary table

| # | Video (id) | Screen (desktop) | Menu path | Desktop form | Writes / effect | Web route | API module | Parity |
|---|-----------|------------------|-----------|--------------|-----------------|-----------|-----------|--------|
| 1 | 5mIg4yRl0aE | Daily Rate (Rate Master) | Other → Daily Rate | `MS_RATE` | `RATE_MAST` per group/date (rate10gm=fine×touch/100); feeds sale/purchase rate | `/txn/daily-rate` | `masters/dailyRate.ts` | Matches (derivation verified) |
| 2 | VzkTOy9vGL0 | Tag Cancel + Tag Print | Other → Tag Cancel / Tag Print | `TR_TAG_CAN` / `UT_TAG_PRINT` | Cancel: `MAIN_STOCK` OUT (−), no ledger; Print: none (label reprint) | `/txn/tag-cancel` | `stock/tagOps.ts` `tagCancel` | Cancel matches; **Tag Print = gap** (no web print util) |
| 3 | yP6XAirZ36I | Stock Adjust | Other → Stock Adjust | `TR_TAG_CAN`/`TR_INOUT` (book STOCK ADJUST) | Signed `MAIN_STOCK` (±), no ledger | `/txn/stock-adjust` | `stock/stock.ts` `stockAdjust` | Matches |
| 4 | QEPhVyaV_xU | Physical Stock Verification | Other → Physical Stock | `TR_PHYSTK` (+`RP_PHY_STOCK`) | Scan/verify vs book; report In/Out/Physical/Different | `/txn/physical-stock` | `stock/stock.ts` `physicalReconcile` | To-verify (web is read-only reconcile) |
| 5 | 0BXTuAzGk-c | Order Cancel | Other → Order Cancel | `TR_SL_ORD_ADJ` (book ORDER CANCEL → `SL_ORD_ADJ`) | Cancels `SL_ORD_DATA`; refunds advance (bank/cash) | `/txn/order-cancel` | `sales/salesOrder.ts` `cancelSalesOrder` | To-verify (refund-account nuance) |
| 6 | 1EziXFnnH7I | Tag Transfer (in Item Stock) | Other → Tag Transfer | `TR_INOUT` (book TAG TRFR) | `MAIN_STOCK` OUT tag / IN bulk (TrfrItm); metal conserved | `/txn/tag-transfer` | `stock/stock.ts` `tagTransfer` | Matches |
| 7 | LiUHTEUPzEw | Tag Weight Change | Other → Tag Wt Change | `TR_TAG_WT_DIFF` | Signed `MAIN_STOCK` diff + karigar `AC_DATA`/`ROJ_MEL_DATA` | `/txn/tag-weight-diff` | `stock/tagOps.ts` `tagWeightDiff` | Matches (net-diff model) |
| 8 | 1DggmBgcA9I | Labour Update | Other → Labour Update | `MS_AUTO_ITEM` (CurMast 'Labour Update') | Bulk `UPDATE ITEM_MAST` labour rate/%, MRP, wastage | `/masters/labour-update` | `masters/labourUpdate.ts` | Matches |
| 9 | 2244Ll1nFxI | Bank Reconciliation | Other → (Bank Reconciliation) | `UT_BANK` | Sets `AC_DATA.CLR_DATE`; cleared vs book balance | `/txn/bank-recon` | `finance/bankRecon.ts` | Matches |
| 10 | AN2AiLXuP28 | Reminder Entry + Reminder report | Other → Reminder | `UT_REMINDER` + `RP_REMINDER` | Entry → `REMARK_DATA`; report = overdue/orders/birthday | `/utilities/reminder-entry` + `/txn/reminders` | `utilities/reminderEntry.ts`, `ops/reminders.ts`, `finance/reminders.ts` | Entry matches; birthday/anniv = to-verify |

---

## 1. Daily Rate Master — `5mIg4yRl0aE` → `/txn/daily-rate`

### 1.1 Screen title + menu path
- Window/title band: **"Rate Master"**; tab label **"Daily Rate 1"** (kf_006, kf_016).
- Menu: **Other → Daily Rate** (left-rail first item; desktop form `MS_RATE.cs`, `MDI_FORM` case
  `"Daily Rate"`, `MENU_DATA` `SM_MAIN_NAME='Daily Rate'`).
- Narration: *"अदर मेनू में फर्स्ट ऑप्शन है यहां पे डेली रेट"* ("first option in the Other menu is Daily Rate").

### 1.2 Header fields (exact on-screen labels)
- **Vch Date** (default today `30/05/2021`) with an **F1** button (rate-history picker).
- **Gold Rate 10gm** (fine gold per 10 g) — narration ₹48000 example.
- **Silver Rate 1Kg** (fine silver per 1 kg) — narration ₹71000 example.
- Footer: **Employee** [code] [name].
- Action buttons: **Print · Save · Cancel · Delete · Exit**.
- Status strip (all screens): `Orange | Live Rate ☐ | Fine Gold : 49368 | Fine Silver : 69917 | Rate Date : 18-04-2021 11:26 | Service End : 01/01/0001`.

### 1.3 Main grid columns (exact headers, kf_006/kf_016)
`Sr. | GrCode | GrName | Touch | Tax% | Rate10gm | TaxRate | PrTouch | PrRate`

Seed rows visible: `1 FGL FINE GOLD 100.00`, `2 GO GOLD ORNAMENTS 92.00`, `3 FSL FINE SILVER 100.00`,
`4 SL SILVER ORNAMENTS 80.00` (the `Touch` column = each group's purity %). `Rate10gm` = derived
sale rate; `PrTouch/PrRate` = purchase touch/rate; `Tax%/TaxRate` = tax-inclusive variant.

### 1.4 Operator workflow (from narration)
1. Open **Other → Daily Rate**. `Vch Date` auto-fills today; **the rate is valid for that one day
   and auto-blanks the next day** (*"वन डे के लिए वैलिड … दूसरे दिन ऑटोमेटिकली ब्लैंक हो जाएगा"*).
2. Each group's **Touch %** is pre-set in the Group master (kf_024/033 **Item Group Master**:
   `Gr Rate Touch`, `Purc Touch`); e.g. 916 = 92%, 20C = 84% (narration double-clicks a group and
   sets *"GR रेट टच"*).
3. Type **Gold Rate 10gm** (₹48000) and **Silver Rate 1Kg** (₹71000) → every group's `Rate10gm`
   auto-derives = `fine × Touch/100` (e.g. 22 K/84, 916/92 fill automatically).
4. **Save**. History for any past date is viewable via **F1** (*"15 दिन पहले … क्या रेट था"*).

### 1.5 Effects (tables + valuation)
- Writes **`RATE_MAST`** — one row per item group for the `VCH_DATE` (web `postDailyRate`
  deletes that date's rows then re-inserts → idempotent). Columns written: `GR_CODE, GR_TOUCH,
  GR_RATE (=Rate10gm), FINE_GL_RATE, FINE_SL_RATE, GR_PR_TOUCH, GR_PR_RATE, FINE_GL_PR_RATE,
  FINE_SL_PR_RATE, SR_NO`.
- Reads **`GROUP_MAST`** (`GR_CODE, GR_TYPE G/S, GR_TOUCH, GR_PURC_TOUCH`).
- **Derivation (verified):** `GR_RATE = (GR_TYPE='S' ? silver : gold) × GR_TOUCH / 100`
  (purchase rate uses `GR_PURC_TOUCH`, falling back to `GR_TOUCH`). No stock/ledger movement — this
  is a rate master, not a voucher.
- **Downstream:** Sales/Purchase item rate auto-fills from `RATE_MAST`. Verified on kf_046
  **Gold Tax Invoice**: item `CH916` gets `ItRate 4410.00`, `CH20C` gets `4032.00`; narration:
  *"916 का रेट आ जाएगा ऑटोमेटिकली … 4416 … राउंड ऑफ 4410 … चेन 20 का 4032"*.

### 1.6 Cross-module connections
- **Depends on:** `GROUP_MAST` (Master → Group; `Gr Rate Touch`, `Purc Touch`, `Item Type`),
  `Employee` master.
- **Feeds:** every priced transaction — Gold/Silver Tax Invoice (Sales), Sales Order, Purchase,
  Estimate — via the per-group `Rate10gm`; also the live-rate ticker (`FINE_GL_RATE/FINE_SL_RATE`).

### 1.7 Web parity
- Route `web/apps/web/app/(app)/txn/daily-rate`; API `masters/dailyRate.ts` (`postDailyRate`,
  `deriveGroupRates`).
- **Parity = Matches.** The web derivation is documented as verified against demo data
  (`GR_RATE 60886 = FINE_GL_RATE 72055 × GR_TOUCH 84.5/100`). To-verify: the desktop `Tax%/TaxRate`
  (tax-inclusive rate) and `Employee` capture — present in the desktop grid, confirm they are
  surfaced/stored on the web form.

---

## 2. Tag Cancel + Tag Print — `VzkTOy9vGL0` → `/txn/tag-cancel`

One tutorial covers two adjacent **Other**-menu tools: **Tag Cancel** (remove a tag from stock) and
**Tag Print** (reprint a barcode label). Only Tag Cancel has a web route.

### 2.1 Screen titles + menu paths
- **Other → Tag Cancel** → desktop form `TR_TAG_CAN.cs` (`lblBook="Tag Cancel"`, form
  `Text="Tag Cancel"`, book `TAG CANCEL`). Left rail item "Tag Cancel" (kf_002).
- **Other → Tag Print** → desktop form `UT_TAG_PRINT.cs`, title **"Tag Print"**, tab "Tag Print 1"
  (kf_005).

### 2.2 Tag Cancel — purpose & workflow (narration)
- Use when *"कोई बारकोड/टैग हमारे पास पड़ा है लेकिन स्टॉक में मिसिंग है … स्टॉक में लेस कर देना है विदाउट बिल"* —
  i.e. write off a lost/missing tagged piece **without a bill**.
- Steps: Other → Tag Cancel → Enter/Enter/Enter → **Tag No** (type or scan) → select the item →
  **Save** (no View needed) → **Exit**. Verify in **Stock → Stock Tag**: the cancelled tag (chain
  #6) is gone → *"स्टॉक में से लेस"*.

### 2.3 Tag Print — form fields + grid (kf_005)
- Header: **Book** [`015` / "Only Tag Entry"] · **Vch No** [F1] · **Item** [Gold ▼ / Silver] ·
  **Gr Code** [ ] · **Pr Code** [ ] · **Print file** [`QrPrint10` ▼] [**Set**] · `: It Name`.
- Grid columns:
  `Sr | Y/N | TagNo | ItCode | Counter | Design | Size | Pcs | GrWt | NetWt | Touch | West% | Fine | LbrRate | LbrAmt | OthAmt | Mrp | KrCode`.
- Footer: **Lable Skip** [ ] (label offset for sheet printers). Buttons Print/Save/Cancel/Delete/Exit.
- Three ways to select what prints (narration): (a) type a **Tag No** directly (e.g. chain #4);
  (b) pick a **Product** (e.g. Ladies Ring) → all its in-stock tags list with a per-row **Y/N** flag
  (set N to skip an item); (c) pick a **Book + Vch No** (e.g. "Only Tag Entry" voucher 2) to reprint
  that voucher's tags. Output = QR/barcode label — kf_004 preview shows
  `CHG00004 / G.14.300 / N.14.300 / LP: 600 / DATACARE SOFTECH / DK / 916 / [QR]`
  (GrWt, NetWt, Labour-per-gram, group 916).

### 2.4 Effects
- **Tag Cancel:** one **`MAIN_STOCK`** out-movement per tag — desktop `Ac_Stock.Tag_Can_Stk`
  (`BOOK_NAME='TAG CANCEL'`, `TR_TYPE='O'`, `ITM_SIGN='-'`, `VCH_TYPE` cancel), header/detail in
  `BAR_CAN_DATA/BAR_CAN_DETL`. **No money ledger** (pure inventory removal). Signed stock ⇒ on-hand
  fine drops by `NetWt×Touch/100`.
- **Tag Print:** **no data mutation** — read-only label render (Crystal `RP_TAG` / print file
  `QrPrint10`).

### 2.5 Cross-module connections
- **Depends on** the tag inventory `BAR_DETL` / `TAG_STOCK` and item/product/group masters.
- Tag Cancel **feeds** stock reports (Stock Tag / item-wise) and any fine-stock valuation.
- Tag Print is invoked after Tag Generation / Only Tag Entry, or to reprint a damaged label.

### 2.6 Web parity
- Route `/txn/tag-cancel`; API `stock/tagOps.ts` → `tagCancel` (VCH_TYPE `TGCAN`, `BOOK_NAME
  'TAG CANCEL'`, book `TGC`, `ITM_SIGN '-'`, empty `AC_DATA`) + `deleteTagCancel` (reverse by key).
- **Parity:** Tag Cancel **matches** the desktop footprint (pure `MAIN_STOCK` OUT, no ledger).
  **Gap:** **Tag Print has no web equivalent** (no print-utility route); web relies on the reports/
  render layer — flag for the label/barcode print feature. To-verify: web tag-cancel line accepts a
  scanned `TAG_NO` and resolves item/weight from `BAR_DETL` (desktop auto-fills on tag select).

---

## 3. Stock Adjust — `yP6XAirZ36I` → `/txn/stock-adjust`

### 3.1 Screen title + menu path
- Title band **"Stock Adjust"**, tab "Stock Adjust 1" (kf_014, kf_020).
- Menu: **Other → Stock Adjust** (left rail; `MENU_DATA` `SM_NAME='Stock Adjust'`, `SM_CODE 05`).
- Desktop: book `STOCK ADJUST` handled by `TR_TAG_CAN.cs` / `TR_INOUT.cs` (the ± sign logic lives
  in `TR_INOUT.cs`: it forces `Sign` to be `+` or `-`). Header/detail in `BAR_CAN_DATA/BAR_CAN_DETL`.

### 3.2 Header fields + grid columns (exact, kf_014/kf_020)
- Header: **Vch No** [`00001`] [weekday] [**F1**] · **Vch Date** [`30/05/2021`] [time] · right caption
  `<item> : It Name`.
- Main grid columns:
  `Sr | TagNo | ItCode | Counter | Design | Size | Sign | Pcs | GrWt | LsWt | NetWt | Touch | West% | Fine | Mrp | KrCode`
- `Counter` is picked from a helper (kf_014 popup **Counter → MAIN STOCK = `001`**).
- **`Sign`** column = `+`/`−` (the crux of this screen).
- Lower sub-grid (karigar/ledger side): `Sr | ItCode | ItName | Pcs | Weight | KrWt | Con% | P/W | Rate | ItAmt | NetAmt`.
- Footer: **Employe** [code][name] · **Vch** [remark]. Buttons: ‹ › Print · Save · Cancel · Delete · Exit.

### 3.3 Operator workflow (narration)
1. **First check stock** via the F-key stock list → **Stock Report → Item wise** (kf_008). The
   stock report (title "Stock Report") has tabs `Group | Product | Item | Design | Safe | Table |
   Trading`, filters `Gross Wise Weight ☐`, `Date` range, `Item [Gold]`, `Gr`, `Pr`, `Safe Name`,
   `Table Name`, and columns
   `Sr | Item Name | OpPcs | OpWt | PrPcs | PrWt | InPcs | InWt | OuPcs | OuWt | SIPcs | SlWt | CIPcs | ClWt`
   (Opening / Purchase / In / Out / Sale / Closing). Example shows **OLD GOLD ClWt = −1.000**
   (*"−1 ग्राम … स्टॉक को एडजस्ट करके ज़ीरो कर देना है"*).
2. Open **Other → Stock Adjust**. Enter/Enter → pick **ItCode** (e.g. `OG` Old Gold) and **Counter**
   (MAIN STOCK 001).
3. Move to **Sign** and set `+` or `−`. *If left blank the software warns to choose + or −*
   (*"प्लस और माइनस कुछ ना कुछ कर दीजिए"*).
4. Enter the correction weight (**NetWt** 1 g; pieces only if adjusting pieces) → **Save** (no print).
5. Re-open the item-wise **Stock Report** → the item's closing is now corrected (kf_024/027; total
   `ClWt` moves 351.800 → 352.800 after the +1 g).

### 3.4 Effects
- One signed **`MAIN_STOCK`** movement per line — web `stockAdjust`: `VCH_TYPE 'STADJ'`,
  `BOOK_NAME 'STOCK ADJ'`, `TR_TYPE 'A'`, `ITM_SIGN` = `+`/`−`, `TAG_NO 'N'` for loose (or the tag),
  `ITM_FINE = NetWt×Touch/100`, book `SAJ`. **No money ledger** (`AC_DATA` empty) — pure inventory
  correction. On-hand fine changes by ±`Fine`. Reversible by voucher key (`deleteStockAdjust`,
  logs `DELETE_DATA`).

### 3.5 Cross-module connections
- **Depends on** Item master (`ITEM_MAST`), Counter/Table master (MAIN STOCK), and reads current
  on-hand from `MAIN_STOCK`.
- **Feeds** every stock report/valuation (item-wise, fine-stock, tag-stock). Sibling of Physical
  Stock (which finds the variance) — Stock Adjust is how you *post* a correction.

### 3.6 Web parity
- Route `/txn/stock-adjust`; API `stock/stock.ts → stockAdjust` / `deleteStockAdjust`.
- **Parity = Matches** (signed `MAIN_STOCK`, no ledger, reversible). To-verify: the desktop
  `Counter`, `Sign`, `LsWt` (loss wt), `KrCode` columns and the lower karigar sub-grid — confirm the
  web form exposes at least `sign`, `netWt`, `touch`, `pcs`, optional `tagNo` (it does) and whether
  `Counter`/`LsWt` are needed for parity.

---

## 4. Physical Stock Verification — `QEPhVyaV_xU` → `/txn/physical-stock`

### 4.1 Screen title + menu path
- Entry form title **"Physical Stock"**, tab "Physical Stock 1" (kf_007); report form title
  **"Physical Stock Report"** (kf_020/026/029).
- Menu: **Other → Physical Stock**. Desktop forms `TR_PHYSTK.cs` (entry, book `PHY STOCK`) +
  `RP_PHY_STOCK.cs` (report). Reset warning text: *"Physical Stock will Reset permantley ?"*.

### 4.2 Entry form — header + grid (kf_007/014)
- Header: **Vch No** [`00001`] [**F1**] · **Vch Date** [`30/05/2021`] [time] [weekday].
- Grid columns:
  `Sr | TagNo | ItCode | ItName | Design | Size | Cntr | Pcs | GrWt | OthWt | NetWt | LbrAmt | OthAmt | Mrp | KrName`
- Footer: **Total** row · **Employe** [code][name]. Buttons: ‹ › **Reset Stock** · **Report** ·
  Save · Cancel · Delete · Exit.
- Tag-pick helper (kf_014) lists book tags to scan/select with columns
  `TagNo | ItName | ItCode | DesignNo | GrWt | NetWt | Mrp` (e.g. `CHG00002 CHAIN 916 15.000`).

### 4.3 Report — filters + grid (kf_020/026/029)
- Filters: **From** / **To** dates · **Stock** [All ▼] · **Item Type** [Gold ▼] · **Product** [▼] ·
  **Group** [▼]. Two report buttons: **All** and **Diff**.
- Report grid columns:
  `Sr | cTagNo | It Name | Size | Cntr | Pcs | GrWt | Mrp | Stk | Out | Apr | Phy | Diff | DiffWt`
  where **Stk** = in book, **Out** = sold, **Apr** = on approval, **Phy** = physically verified,
  **Diff** = shortage (book-but-not-counted), **DiffWt** = its weight. Totals row aggregates each.
- **Diff** view filters to only the variance rows (kf_029: `CHG00007 CHAIN 20C … Diff 1 DiffWt 14.300`).

### 4.4 Operator workflow (narration)
1. **Other → Physical Stock** → Enter/Enter → **scan each physically-present tag** with the barcode
   scanner (or pick from the helper). Present pieces scan in; a piece you don't have (e.g. tag #7) is
   simply **not scanned/skipped** (*"सात नंबर फिजिकल … नहीं थी … स्कैन भी नहीं होगी"*).
2. **Save** the count voucher, then **Report** → choose **All** (full picture) or **Diff** (only the
   shortages). The report shows per tag whether it is in Stk / Out / Apr / Phy, and any **Diff**
   (e.g. the un-scanned 14.300 g chain lands in `Diff`/`DiffWt`).

### 4.5 Effects
- The entry voucher records the counted tags (`PHY STOCK` book → `BAR_CAN_DATA/BAR_CAN_DETL`); the
  report computes the variance **Stk vs Phy** (book vs counted). It surfaces shortages to act on
  (via Stock Adjust / Tag Cancel) rather than auto-posting them. **Reset Stock** clears a count.
- Fine/weight not re-valued here — this is a counting/variance screen.

### 4.6 Cross-module connections
- **Depends on** the tag book (`BAR_DETL`/`TAG_STOCK`) and sale/approval movements (to classify
  Out/Apr). **Feeds** Stock Adjust (post the correction) and management stock-accuracy reports.

### 4.7 Web parity
- Route `/txn/physical-stock`; API `stock/stock.ts → physicalReconcile(countedTags[])` returning
  `matched | missing | extra` (+counts) comparing counted tags to the `TAG_STOCK` book.
- **Parity = To-verify / partial.** The web reconcile maps `Phy≈matched`, `Diff/shortage≈missing`,
  `extra=counted-not-in-book`, but the desktop report's richer **Out / Apr** classification and the
  saved count voucher + **Reset Stock** are not yet modelled. Flag: add the Out/Approval split and a
  persisted count if full parity is required.

---

## 5. Order Cancel — `0BXTuAzGk-c` → `/txn/order-cancel`

### 5.1 Screen title + menu path
- Title **"Order Cancel"**, tab "Order Cancel 1" (kf_024). Menu **Other → Order Cancel**.
- Desktop form `TR_SL_ORD_ADJ.cs`, book `ORDER CANCEL` → table **`SL_ORD_ADJ`** (per
  `MS_UPDATE.cs`). Cancels a *pending* **Sales Order** (`TR_SALE_ORD.cs`, `SL_ORD_DATA`).

### 5.2 Pre-req — Sales Order (kf_009/016, for context)
- **Tran 1 → Sales Order**, title "Sales Order". Header: **Vch No** [F1][All] · **Vch Date** ·
  **Ref No** · **Party** (helper columns `AcName | AcCode | Group | Address | Mobile`).
- Order grid: `Sr | TagNo | ItCode | Design | Size | Pcs | GrWt | LsWt | NetWt | ItRate | ItAmt |
  LType | LbrRate | LbrAmt | OthAmt | TotAmt | Tax% | NetAmt`. Right totals panel: `Net Amt · Tax
  Amt · Total Amt · Cash Amt · Cheque Amt · Card Amt · Old Gold Amt · Old Silver Amt · Scheme Amt ·
  Tot Adv Amt`. Example: party `000210 MANOHAR JI SONI`, 1 pc `CH916` 12 g @4800 = 57600 + 6000
  making = 63600; **advance ₹25000** taken as Cash (`Tot Adv Amt 25000`, "25000.00 : Cr Amt").

### 5.3 Order Cancel — header + grid (exact, kf_024/030)
- Header: **Vch No** [`00001`] [**F1**] · **Vch Date** [`11/06/2021`] [time] [weekday].
- Grid columns:
  `Sr | OrdNo | AcCode | Ac Name | It Desc | OrdAmt | AdjAmt | KsarAmt | PaidAmt | PaiidAc | Paid Ac Name`
- Footer: **Total** row · **Employe** · `<amt> : Cr Amt`. Buttons ‹ › Print · Save · Cancel · Delete · Exit.
- Row example: `OrdNo 00003 · 000210 MANOHAR JI SONI · OrdAmt 25000 · AdjAmt 25000 · KsarAmt 0 ·
  PaidAmt 25000 · PaiidAc 00001 · CASH ON HAND` (the paid/refund amount defaults to the advance).

### 5.4 Operator workflow (narration)
1. (Setup) Take the order in **Tran 1 → Sales Order** with an advance (₹25000). Exit.
2. **Other → Order Cancel** → Enter/Enter/Enter → the grid lists **all pending orders**
   (*"जो भी ऑर्डर पेंडिंग है उसका ही लिस्ट आएगा"*). Select the order (Manohar ji).
3. **PaidAmt** auto-fills the advance (₹25000; editable). Move to **PaiidAc / Paid Ac Name** — the
   refund account. Default **CASH ON HAND (00001)**; the operator clears it and picks **HDFC BANK
   (000203)** via the helper (kf_030) to refund from bank.
4. **Save** → the bank/cash balance drops by the refund. Verify in **Ledger Report** (kf_035):
   a new row `Order Cancel · 00001 · 11/06/2021 · MANOHAR JI SONI · Cr 25,000 · Bal −192,146 Dr`
   (HDFC bank reduced from −217,146 by the 25,000 refund).

### 5.5 Effects (tables + ledger)
- Removes the pending order (`SL_ORD_DATA`/`SL_ORD_DETL`/`SL_ORD_IDTL`) and writes an ORDER CANCEL
  adjustment (`SL_ORD_ADJ`) capturing `OrdAmt/AdjAmt/KsarAmt/PaidAmt` + the refund account.
- **Ledger:** refund of the advance through the chosen account — **Dr customer / Cr bank(or cash)**
  clearing the advance liability (the advance had been Cr-customer / Dr-cash at order time). Signed
  in the day-book (`AC_DATA`/`ROJ_MEL_DATA`).
- No stock movement (an order holds no stock until issued/tagged).

### 5.6 Cross-module connections
- **Depends on** Sales Order (`SL_ORD_DATA`), Party master (`AC_MAST`), Cash/Bank accounts.
- **Feeds** the party ledger / cash-bank ledger (refund) and clears the order from pending-order
  reminders (see §10 Order reminder).

### 5.7 Web parity
- Route `/txn/order-cancel`; API `sales/salesOrder.ts → cancelSalesOrder` (reverses
  `SL_ORD_DATA/DETL/IDTL` + `AC_DATA` by voucher key; writes `DELETE_DATA`; **guard:** refuses if any
  line is issued to mfg `DESIGN_ISU='Y'`, tagged `TAG_GEN='Y'`, or delivered `TAG_SALE='Y'`).
- **Parity = To-verify (refund nuance).** The web *reverses the original advance posting* (advance
  effectively returns to the account it came from), whereas the desktop *books a fresh ORDER CANCEL
  refund through an operator-chosen `PaiidAc`* (e.g. advance taken in cash, refunded via HDFC bank)
  and stores `AdjAmt/KsarAmt/PaidAmt` in `SL_ORD_ADJ`. **Gaps to close for exact parity:** (a) let the
  operator choose the refund account; (b) capture partial adjust + kasar (rounding); (c) persist the
  `SL_ORD_ADJ` adjustment row. The pending-only listing + guard already match.

---

## 6. Tag Transfer (in Item Stock) — `1EziXFnnH7I` → `/txn/tag-transfer`

### 6.1 Screen title + menu path
- Title **"Tag Transfer"**, tab "Tag Transfer 1" (kf_008/014). Menu **Other → Tag Transfer**.
- Desktop form `TR_INOUT.cs` (book `TAG TRFR`; `TR_INOUT` handles the `TAG TRFR` grid & the
  `TrfrItm` target column). Purpose: convert a **barcoded tag → bulk/loose item** (e.g. a broken
  chain moved into **OLD GOLD**). Narration: *"बारकोड वाले स्टॉक में से रिमूव करके बल्क वाले स्टॉक में …
  ओल्ड गोल्ड में ले लेनी है"*.

### 6.2 Header + grid columns (exact, kf_008/014)
- Header: **Vch No** [`00001`] [weekday] [**F1**] · **Vch Date** [`11/06/2021`] [time] · right
  caption `<item> : It Name`.
- Grid columns:
  `Sr | TagNo | ItCode | Counter | Design | Size | Pcs | GrWt | LsWt | NetWt | Touch | West% | Fine | TrfrItm | TrfrItmName`
  — the last two, **TrfrItm / TrfrItmName**, are the **target bulk item** to receive the weight.
- Tag helper (kf_008) columns: `TagNo | ItName | ItCode | DesignNo | GrWt | NetWt | Mrp`.
- Lower sub-grid: `Sr | ItCode | ItName | Pcs | Weight | KrWt | Con% | P/W | Rate | ItAmt | NetAmt`.
- Footer: **Employe** · **Vch**. Buttons ‹ › Print · Save · Cancel · Delete · Exit.

### 6.3 Operator workflow (narration)
1. **Other → Tag Transfer** → Enter/Enter/Enter → pick the tag by key or **barcode scan**
   (e.g. `CHG00006 CHAIN 20C`, 12.400 g).
2. Press Enter → the **TrfrItm** ("Transfer Item") picker opens → choose the destination bulk item
   (**OLD GOLD**). *"ट्रांसफर आइटम … पूरा आइटम का लिस्ट … ओल्ड गोल्ड सिलेक्ट"*.
3. **Save** → **Exit**. Verify: barcode stock (**Stock → Stock Tag**) shows the tag now **Out**
   (kf_020 Tag Stock Report tabs `In Tag | Out Tag | Stock Tag | Mrp Tag | Apr Panding | All Tag`);
   bulk stock (item-wise **OLD GOLD** drill-down, kf_026) shows a new **`TAGTR` IN of 12.400 g,
   Sign +**.

### 6.4 Effects
- Two balanced **`MAIN_STOCK`** legs (metal conserved), matching web `tagTransfer`:
  - **OUT** the tag: `IT_CODE=CH20C`, `TAG_NO=CHG00006`, `ITM_SIGN '-'`, `TR_TYPE 'A'`.
  - **IN** the bulk target: `IT_CODE=OLD GOLD`, `TAG_NO 'N'`, `ITM_SIGN '+'` — same `NetWt`/`Fine`.
  - `VCH_TYPE 'TAGTR'`, `BOOK_NAME 'TAG TRFR'`, book `TTR`. **No money ledger** (pure stock move;
    value unchanged). Reversible by key (`deleteTagTransfer` + `DELETE_DATA`).
- Stock-report drill-down columns seen (kf_026):
  `SrNo | Vchtype | Party Name | VchNo | VchDate | TagNo | ItName | Pcs | GrWt | NetWt | Fine | Sign`.

### 6.5 Cross-module connections
- **Depends on** the tag inventory (`BAR_DETL`) and the destination bulk item (`ITEM_MAST`, e.g.
  OLD GOLD). **Feeds** both barcode stock (tag goes Out) and bulk/loose stock (weight In) — used
  when a piece breaks / is melted and must leave tagged inventory.

### 6.6 Web parity
- Route `/txn/tag-transfer`; API `stock/stock.ts → tagTransfer` / `deleteTagTransfer`.
- **Parity = Matches** — the web emits exactly the OUT-tag / IN-bulk `MAIN_STOCK` pair with equal
  net/fine (`VCH_TYPE 'TAGTR'`, book `TTR`, no ledger), conserving metal. To-verify: web resolves the
  tag's `fromItCode`/weight from `BAR_DETL` on scan (desktop auto-fills the grid on tag select), and
  requires `toItCode` (TrfrItm) — both present in the API contract.

---

## 7. Tag Weight Change — `LiUHTEUPzEw` → `/txn/tag-weight-diff`

### 7.1 Screen title + menu path
- Title **"Tag Weight Change"**, tab "Tag Wt Change 1" (kf_010). Menu **Other → Tag Wt Change**.
- Desktop form `TR_TAG_WT_DIFF.cs`. Two uses (narration): (a) **correct a tag's weight** (±) and
  push the difference into a bulk item / a karigar's account; (b) **split a set** (necklace + 2
  earrings) into separate tags.

### 7.2 Header + grids (exact, kf_010/022/042/050)
- Header: **Vch No** [`00001`] [**F1**] · **Vch Date** [date][time][weekday] · **Item** [Gold ▼] ·
  right caption `<item> : It Name`.
- **Main grid (old vs new weights):**
  `Sr | TagNo | ItCode | ItName | Size | OPcs | OGrWt | OthWt | ONetWt | NwPcs | NwGwt | NOthWt | NwNet | Diff GWt | Diff NWt | Lbr% | LType | LbrRate`
  (O* = old, Nw* = new; `Diff GWt`/`Diff NWt` auto-compute new − old).
- **Absorption sub-grid (into bulk stock):**
  `Sr | ItCode | ItName | Pcs | GrWt | OthWt | NetWt | Touch | West% | Fine | HmFine | Sign | Rate | ItAmt | OthAmt | NetAmt`
  (`Sign` `+`/`−`; used to book the diff into e.g. OLD GOLD).
- **Party/valuation panel (bottom-left):** `Party [code][name]` · `Tot Wt Cr / Tot Wt Dr` ·
  `Cr Touch / Dr Touch` · `Cr Fine / Dr Fine` · `1gm Rate (Cr) / 1gm Rate (Dr)` ·
  `Cr Amount / Dr Amount` · `Cr Lbr Amt` · `Employe` · `Cr Days` · `Diff Amount` · `Vch Desc`.
- **Totals panel (right):** `Payment | Received` columns over `Net Amt · Cheque Amt · Card Amt ·
  Order Amt · Cash Amt · Kasar Amt · Os Amt`; `: Amt / : Gold / : Silvr`.

### 7.3 Operator workflow (narration)
- **Case A — reduce weight into OLD GOLD (kf_022):** pick tag `CHG00003` (CH916, `ONetWt 12.600`),
  type `NwNet 12.350` → `Diff NWt −0.250`. In the sub-grid pick **OLD GOLD**, `Sign +`, 0.250 →
  that 0.250 g enters OLD GOLD stock (`0.250 : Dr Gold`). Save.
- **Case B — increase weight added by a karigar (kf_042/050):** pick tag `CHG00004`
  (`ONetWt 14.300` → `NwNet 14.800`, `Diff NWt +0.500`). Set **Party = `000205 ABC JEWELLERS`**
  (the karigar who added metal); enter **Cr Touch 92** → **Cr Fine 0.460**, **1gm Rate 4900** →
  **Cr Amount ₹2254** (`0.460 : Cr Gold`). Optionally add the karigar's making charge; the ₹2254
  posts to the karigar's account (Payment side; pay now by Cash/Bank or leave on their ledger). Save.
- Verify F12/stock: the tag's net updates (12.600 → 12.350); OLD GOLD gains 0.250; karigar credited.

### 7.4 Effects
- **Stock:** a signed **`MAIN_STOCK`** movement of the |difference| — desktop `Ac_Stock.Tag_Wt_Diff_Stk`
  replaces the whole tag (full OUT + full IN); the increase/decrease also books the counter item
  (OLD GOLD) or karigar.
- **Ledger:** desktop `Ac_Ledr.Tag_Wt_Diff_Ledr` + `Ac_Rojmel.Tag_Wt_Diff_Rojmel` — the added metal
  is valued (`fine × rate`) and **credited to the karigar party** (with optional Cash/Bank payment).
- `fine = NetWt × Touch / 100`; diff value = `diffFine × 1gm Rate`.

### 7.5 Cross-module connections
- **Depends on** the tag (`BAR_DETL`), a destination bulk item (OLD GOLD) and/or a **karigar party**
  (`AC_MAST`), plus the daily 1-gram rate. **Feeds** stock (tag re-weighed, OLD GOLD updated), the
  karigar ledger/day-book, and (if paid) cash/bank.

### 7.6 Web parity
- Route `/txn/tag-weight-diff`; API `stock/tagOps.ts → tagWeightDiff` / `deleteTagWeightDiff`
  (`VCH_TYPE 'TGWD'`, `BOOK_NAME 'TAG WT CHANGE'`, book `TWD`).
- **Parity = Matches (model) but simplified.** The web books the **net difference** as one signed
  `MAIN_STOCK` movement of `|diff|` + a balanced `AC_DATA` pair against generic counter accounts
  (`STKADJ` / `WTDIFF`): gain ⇒ Dr STKADJ / Cr WTDIFF, loss ⇒ Dr WTDIFF / Cr STKADJ, valuing
  `diffFine × rate`. **Gaps vs desktop:** (a) credit the **actual karigar party** (not a generic
  WTDIFF account) with touch/1gm-rate; (b) absorb the diff into a chosen bulk item (OLD GOLD) via the
  sub-grid `Sign`; (c) optional Cash/Bank **payment** of the karigar amount; (d) the set-splitting
  use-case (closer to `tag-split`/`tagSplit`). The web source explicitly notes it is "the simplified,
  equivalent net-of-difference form."

---

## 8. Labour Update — `1DggmBgcA9I` → `/masters/labour-update`

### 8.1 Screen title + menu path
- Title **"Labour and Mrp Update"**, tab "Labour Update 1" (kf_010/018). Menu **Other → Labour
  Update** (left-rail Extra group; siblings Counter Trfr · Bank Reconcile · Vch ReNumber).
- Desktop form `MS_AUTO_ITEM.cs` (bulk item-master updater, `CurMast = "Labour Update"`).
- Purpose (narration): change the **making charges / MRP** of *all* barcodes of an item group at once
  (*"जितने भी बारकोडिंग बने हुए है … सारे के सारे का मेकिंग चेंजेस कर देना है"*).

### 8.2 Header + grid columns (exact, kf_010/018)
- Header: **Gr Code** [`916`] [`916 GOLD ORNAMENTS`] (group picker).
- Grid columns:
  `Sr. | It Code | It Name | OLbr | NLbr | OLbr% | NLbr% | OMrp | NMrp | OWest% | NWest%`
  where **O*** = current (Old) value, **N*** = new value to apply:
  `Lbr` = labour rate per gram, `Lbr%` = labour percentage, `Mrp`, `West%` = wastage %.
- Items list per group; the same `IT_CODE` can appear on several rows for its labour slabs
  (e.g. `CH916` at 12%, 15%, ₹500/g, ₹700/g — kf_010).

### 8.3 Operator workflow (narration)
1. **Other → Labour Update** → pick **Gr Code** (916). The grid lists every 916 item with its Old
   labour rate/%, MRP, wastage.
2. Edit the **New** cells: e.g. change **OLbr 500 → NLbr 800** (kf_018) to raise the ₹500/g slab to
   ₹800/g for all matching pieces; or move a per-gram value into a **NLbr%** (percentage) instead;
   or set **NMrp** for MRP items.
3. **Save** → confirm the two prompts (**Yes**, **Yes**) → the making charges update in bulk.
4. Verify in the **Tag Stock Report** (kf_026 before / kf_032 after): `Lbr Rate` for the affected
   tags changes 500 → 800. Barcodes can then be **reprinted** (see §2 Tag Print).

### 8.4 Effects
- Bulk **`UPDATE ITEM_MAST`** — web `applyLabourUpdate` maps the New columns exactly:
  `NLbr → IT_LBR_RATE`, `NLbr% → LBR_PRC`, `NMrp → ITEM_RATE` (MRP), `NWest% → IT_WEST` (wastage %).
  **Partial update:** only the New cells that are filled are written (blank leaves Old untouched).
- No stock/ledger movement — this is a master-data bulk edit. It changes the labour/MRP used by
  future pricing and the value printed on tags.

### 8.5 Cross-module connections
- **Depends on** the Group master (`GROUP_MAST` `GR_CODE`) and Item master (`ITEM_MAST`).
- **Feeds** tag pricing / Tag Print (`Lbr Rate`, `Mrp`), invoice making-charge defaults, and stock
  valuation. Companion to Tag Print (reprint labels after updating).

### 8.6 Web parity
- Route `/masters/labour-update`; API `masters/labourUpdate.ts` (`listLabourItems(grCode)` +
  `applyLabourUpdate(rows)`), reading/writing `ITEM_MAST` (`IT_LBR_RATE, LBR_PRC, ITEM_RATE,
  IT_WEST`) by `GR_CODE`.
- **Parity = Matches** — same group-scoped list, same four editable columns, same partial-update
  semantics (blank New = unchanged). **To-verify:** the desktop grid shows multiple labour *slabs*
  per `IT_CODE` (rate + %, several bands) — confirm the web list keys rows the same way (one row per
  `ITEM_MAST` row) so a multi-slab item updates the intended row.

---

## 9. Bank Reconciliation — `2244Ll1nFxI` → `/txn/bank-recon`

### 9.1 Screen title + menu path
- Tab "Bank Reconcile 1" (kf_009). Menu **Other → Bank Reconcile** (left-rail Extra group).
  Desktop form `UT_BANK.cs`.
- Purpose (narration): a cheque takes 2–3 days to reflect in the bank; the computer shows one
  balance but some cheques are still uncleared. Bank Reconciliation shows the **actual (cleared)
  balance** so you know how much is really available before issuing a cheque.

### 9.2 Header + grid columns (exact, kf_009/018/034)
- Header: **From** [`01/06/2021`] **To** [`30/06/2021`] · **Bank** [`000203`] [`HDFC BANK`]
  (`From/To` auto-fill the current month, month-to-month).
- Grid columns:
  `Sr | BookType | Ac Name | VchNo | VchDate | ChqNo | ClrDate | DrAmt | CrAmt | AmtBal | CrDr`
- Buttons: **Bal Chk** (balance check) · Print · Save · Cancel · Delete · Exit.
- Example rows: `Op Balance 217146 Dr` · `Gold Tax Inv · VIKAS BARVADIYA · 00009 · 27/06 · Dr 84975
  · AmtBal 302121` · `Gold Tax Inv · RONAK JI · 00010 · 28/06 · Dr 72677 · AmtBal 374798`.
  Total `374798 Dr` (book balance).

### 9.3 Operator workflow (narration)
1. **Other → Bank Reconcile** → pick **Bank** (HDFC) → the month's bank transactions list with a
   running **AmtBal** (book balance 3,74,798).
2. Click **Bal Chk** → the report recomputes showing only **cleared** rows (kf_026): opening 2,17,146
   stands, the two uncleared cheques (27th/28th) drop out → **actual balance ₹2,17,146** (narration).
3. To clear a cheque: on its **ClrDate** cell press **F1** → today's date auto-fills (kf_034: row
   `VIKAS BARVADIYA 00009` gets `ClrDate 30/06/2021`). **Save**.
4. Re-open Bank Reconcile → **Bal Chk** now adds the just-cleared cheque to the cleared balance.
   *"कौन सा चेक क्लियर हो गया, कौन सा नहीं"* — track clearance per cheque.

### 9.4 Effects
- Sets/clears **`AC_DATA.CLR_DATE`** on the bank account's voucher rows (a row with a `CLR_DATE` is
  "cleared"). No new voucher — reconciliation is a status stamp on existing ledger rows.
- Balances: **book** = Σ(`DR_AMT` − `CR_AMT`) over the range; **cleared** = same Σ but only rows with
  a `CLR_DATE`; **uncleared / in-transit** = book − cleared (the desktop **Bal Chk** = cleared).

### 9.5 Cross-module connections
- **Depends on** every posting that hit the bank account: sales receipts, Bank Received/Payment,
  Contra, Order-Cancel refund (§5), etc. `ChqNo` is pulled from the receipt/payment (`CASH_DATA` /
  `PAY_DATA`). **Feeds** cash-flow decisions (available bank balance).

### 9.6 Web parity
- Route `/txn/bank-recon`; API `finance/bankRecon.ts` → `bankReconList(bankAc, {from,to})`
  (returns `rows[] + book + cleared + uncleared`, `ChqNo` from `CASH_DATA`/`PAY_DATA`) and
  `bankReconClear(bankAc, items[{coBook,vchNo,clrDate}])` (sets `AC_DATA.CLR_DATE`).
- **Parity = Matches.** Column mapping: `BookType→coBook/vchType`, `Ac Name→party`, `VchNo→vchNo`,
  `VchDate→vchDate`, `ChqNo→chqNo`, `ClrDate→clrDate`, `DrAmt→dr`, `CrAmt→cr`; the desktop **Bal Chk**
  cleared figure = web `cleared`, book total = web `book`. To-verify: expose the per-row running
  **AmtBal** (web returns aggregate book/cleared/uncleared rather than a running balance column), and
  the **F1 = today** convenience on the clear-date cell.

---

## 10. Reminder Entry + Reminder Report — `AN2AiLXuP28` → `/utilities/reminder-entry` + `/txn/reminders`

### 10.1 Screen titles + menu paths
- **Reminder Entry** — Menu **Other → Reminder Entry**, tab "Reminder Entry 1"; desktop form
  `UT_REMINDER.cs`, book `REM` → **`REMARK_DATA`**.
- **Reminder Report** — the **Home** reminder dashboard, title "Reminder Report" (kf_010); desktop
  form `RP_REMINDER.cs`. A right-hand button column selects the dataset:
  **Order Rem · Sales Rem · Wh Sales Rem · Dhiran Rem · Birthday And Anv · Schm Rem · Reminder Entry
  · Item In Out** (with a live clock).

### 10.2 Reminder Entry — fields (kf_024)
- Pick an **Account** (e.g. `HDFC BANK`), type a **Remark** (e.g. "CHQ … deposit"), and set the
  **Reminder (Rem) Date**. Stored row columns seen in the entry list:
  `Sr | AcName | Remark | EntDate | RemDate | Mobile` (EntDate = entered-on, RemDate = remind-on).
- Narration back-dates the entry (05/07 with RemDate 07/07) purely to demo that it surfaces on the
  reminder day.

### 10.3 Reminder Report — datasets + columns (kf_010/024/050/058)
- Filter: **From Date / To Date** (default today; widen From to see e.g. a 10-day window).
- **Reminder Entry** list: `Sr | AcName | Remark | EntDate | RemDate | Mobile`.
- **Sales Rem** (kf_050): outstanding sales bills — `SrNo | AcName | VchDate | VchType | VchNo |
  TotAmt | OsAmt` (e.g. `VIKAS BARVADIYA · 04/07 · TGSL · 00011 · Tot 66,000 · Os 67,980`). A bill's
  **CrDay** (credit days, e.g. 3 on the Gold Tax Invoice, kf_038) drives when it becomes due.
- **Order Rem**: pending Sales Orders by delivery date (`DEL_DATE`).
- **Birthday And Anv** (kf_058): from the **Party master** — `SrNo | AcName | BrDay | AnDay | City |
  Add | MobileNo` (e.g. `VIKAS BARVADIYA · BrDay 07/07/1995 · AHMEDABAD · 8758111027`). Set on the
  party's **Other Detail → Birth Date / Anniversary**.

### 10.4 Operator workflow (narration)
1. **Manual:** Other → Reminder Entry → account + remark + RemDate → **Save**. Open **Home** → the
   reminder shows on its RemDate (HDFC cheque-deposit reminder appears on 07/07).
2. **Sales:** make a Gold Tax Invoice kept on credit with **CrDay = 3** (kf_038) → 3 days later it
   appears under **Sales Rem** with its outstanding (`OsAmt`).
3. **Order:** take a Sales Order with a **Delivery Date** → it appears under **Order Rem**.
4. **Birthday/Anniversary:** set the party's **Birth Date** (07/07/1995) in the party master → it
   appears under **Birthday And Anv** on the day.

### 10.5 Effects
- **Reminder Entry** inserts one **`REMARK_DATA`** row (book `REM`; `AC_CODE, AC_NAME, VCH_REMARK,
  VCH_DATE`/RemDate). No ledger/stock.
- **Reminder Report** is **read-only aggregation** across `BILL_OS_DATA` (sales/wholesale
  outstanding, aged by credit days), `SL_ORD_DATA.DEL_DATE` (orders due), `AC_MAST` birthday/
  anniversary, `REMARK_DATA` (manual), schemes/dhiran, etc.

### 10.6 Cross-module connections
- **Depends on** `AC_MAST` (party + birthday/anniversary + mobile + credit days), `BILL_OS_DATA`
  (outstanding), `SL_ORD_DATA` (orders), `REMARK_DATA` (manual notes). **Feeds** the SMS/WhatsApp
  follow-up (desktop left-rail **Sms**).

### 10.7 Web parity
- Manual entry — Route `/utilities/reminder-entry`; API `utilities/reminderEntry.ts`
  (`createReminderEntry`/`list`/`delete`, `REMARK_DATA` book `REM`). **Parity = Matches.**
- Dashboard — Routes `/txn/reminders` + `/utilities/reminders`; APIs `ops/reminders.ts`
  (`overdueReminders` = BILL_OS_DATA receivables; `birthdayReminders` = `AC_MAST BR_DATE/L_BR_DATE`
  birthday + `AN_DATE` anniversary; `sendReminder` = WhatsApp/SMS) and `finance/reminders.ts`
  (`receivables` aged by `AC_MAST.AC_CR_DAYS`; `ordersDue` from `SL_ORD_DATA.DEL_DATE`).
- **Parity = Mostly matches; some datasets to-verify/gap:**
  - Sales-outstanding (**Sales Rem**) ✅, Orders-due (**Order Rem**) ✅, Birthday/Anniversary ✅
    (via `ops/reminders.ts`) — note `finance/reminders.ts` deliberately omits birthday, so the app
    must route the birthday dataset to `ops/reminders.ts`.
  - **Gaps:** desktop's **Wh Sales Rem**, **Dhiran Rem**, **Schm Rem**, **Item In Out** dataset
    buttons are not all present on the web dashboard — flag for parity.
  - **Nuance:** desktop ages a sale by its **per-bill CrDay**, while the web ages by the party-level
    `AC_CR_DAYS` — confirm the intended aging basis.
  - **Web addition:** `sendReminder` (WhatsApp/SMS send) — richer than the desktop's manual SMS.

---

## Appendix — parity backlog (quick list)
- **Tag Print**: no web print-utility route (label reprint) — **gap**.
- **Order Cancel**: add operator-chosen refund account + `AdjAmt/KsarAmt` + persist `SL_ORD_ADJ` — **gap/nuance**.
- **Tag Weight Change**: credit the real **karigar party** (touch/1gm-rate) + OLD-GOLD absorption + optional payment, vs generic STKADJ/WTDIFF — **nuance**.
- **Physical Stock**: add Out/Approval classification + persisted count + Reset — **partial**.
- **Reminder dashboard**: add Wh-Sales/Dhiran/Scheme/Item-In-Out datasets; unify birthday routing; confirm CrDay vs AC_CR_DAYS aging — **gap/nuance**.
- **Daily Rate**: confirm `Tax%`/`TaxRate` (tax-inclusive) + Employee surfaced on web — **to-verify**.
- **Bank Recon**: expose per-row running `AmtBal` + F1-today on clear date — **to-verify**.
