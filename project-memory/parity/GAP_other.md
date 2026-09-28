# GAP_other — Parity gap analysis: **Other / Utilities + Inventory Ops**

**Scope:** the 10 desktop "Other"-menu screens (11 web surfaces) owned by this module.
**Method:** each screen compared field-by-field / effect-by-effect against the KB desktop spec
(`project-memory/video-research/_kb/KB_other.md`), the actual web page
(`web/apps/web/app/(app)/…`), the backing API module (`web/apps/api/src/modules/…`) and the route
handler (`web/apps/api/src/routes/txn.ts`). High-impact gaps were re-confirmed against the decompiled
desktop `extracted_code/DataCareNext/DataCareNext/*.cs`.
**Analysis only — no application code was modified.**

Legend — Priority: **P0** blocks core desktop-equivalent use · **P1** important field/behaviour ·
**P2** polish/print/display. Effort: **S** ≤½ day · **M** 1–2 days · **L** 3+ days.

Cross-cutting note (applies to Tag Cancel & Tag Weight Change): the web pages render **Book / Year /
Location** inputs, but the routes build scope from `scopeOf(req)` (session) and **ignore** the body
`coBook/coYear/lcCode` (see `txn.ts` `/stock/tag-cancel`, `/stock/tag-weight-diff`). Either wire them
into scope or drop them from the form for honesty.

---

## 1. Daily Rate — `/txn/daily-rate` + `masters/dailyRate.ts`

**Desktop spec (KB §1):** "Rate Master" — header **Vch Date** (+**F1** rate-history), **Gold Rate
10gm**, **Silver Rate 1Kg**, **Employee**; per-group grid `Sr | GrCode | GrName | Touch | Tax% |
Rate10gm | TaxRate | PrTouch | PrRate`; writes one `RATE_MAST` row per item group per date
(`GR_RATE = fine × GR_TOUCH/100`, purchase via `GR_PURC_TOUCH`); rate valid one day (auto-blanks next
day); **Print** button. No stock/ledger.

**Web now:** `daily-rate/page.tsx` shows **only 3 inputs** (Date, Gold /10g, Silver /kg) + a
`<RateTicker/>` + result tiles (date/gold/silver/**groups count**). No per-group grid.
`dailyRate.ts postDailyRate` reads `GROUP_MAST` (`GR_CODE,GR_TYPE,GR_TOUCH,GR_PURC_TOUCH`), derives via
`deriveGroupRates` (`fine×touch/100`, purchase falls back to `GR_TOUCH`), **deletes** the date's rows
then re-inserts `RATE_MAST(GR_TOUCH,GR_RATE,FINE_GL_RATE,FINE_SL_RATE,GR_PR_TOUCH,GR_PR_RATE,
FINE_GL_PR_RATE,FINE_SL_PR_RATE,SR_NO)` — idempotent. Route `POST /daily-rate` reads only
`date/goldRate/silverRate`. Derivation itself = **Matches** (KB-verified `60886 = 72055×84.5/100`).

**GAPS:**
- No **per-group preview/edit grid** — operator cannot see or override each group's derived
  `Rate10gm`/`PrRate` before saving, and gets no read-back of what was written (only a count tile).
- No **`Tax%` / `TaxRate`** (tax-inclusive rate) capture or storage — the `RATE_MAST` INSERT writes no
  tax column.
- No **`Employee`** capture (desktop footer Employee code+name).
- No **F1 rate-history** view — there is **no GET endpoint** for `RATE_MAST` by date; you cannot view
  or edit an existing date's rates, only blind-overwrite.
- No inline **group-touch override** (desktop double-click a group → set "GR रेट टच"); web relies
  solely on `GROUP_MAST.GR_TOUCH`.
- No **Print** (rate-list print) and no surfacing of the one-day-validity rule.

**Fill plan:**
- Backend `masters/dailyRate.ts`: add `getDailyRate(coCode, date)` → join `RATE_MAST` (for the date) +
  `GROUP_MAST` names to return the grid rows (Sr/GrCode/GrName/Touch/Tax%/Rate10gm/TaxRate/PrTouch/
  PrRate); extend `postDailyRate` to accept optional per-group overrides
  `rows[{grCode,touch,rate,prTouch,prRate,taxPct,taxRate}]` and `empCode`; add `TAX%`/`TAX_RATE`
  columns to the INSERT (verify columns exist in `RATE_MAST` schema — `packages/db`) + an emp column if
  present. Add `GET /daily-rate?date=` in `txn.ts`.
- Frontend `daily-rate/page.tsx`: after gold/silver entry, GET + render the editable per-group grid
  with live re-derive; add Employee picker; add a date/history (F1) view.

**Priority: P1** · **Effort: M** (derivation core already matches; grid/tax/employee/history are
visibility + important fields).

---

## 2a. Tag Cancel — `/txn/tag-cancel` + `stock/tagOps.ts tagCancel`

**Desktop spec (KB §2):** `TR_TAG_CAN`, book **TAG CANCEL** — remove a lost/missing tag from stock
**without a bill**; one `MAIN_STOCK` OUT per tag (`ITM_SIGN '-'`, `TR_TYPE 'O'`), header/detail in
`BAR_CAN_DATA/BAR_CAN_DETL`; **no money ledger**.

**Web now:** `tag-cancel/page.tsx` — grid `Tag | Item | Pcs | Gross | Net Wt | Touch % | Fine`, tag
`LookupPicker` **with `onPick` autofill** (sets itCode/netWt/grossWt/touch/fineWt from `BAR_DETL`).
`tagOps.tagCancel` writes `MAIN_STOCK` OUT (`VCH_TYPE 'TGCAN'`, `BOOK_NAME 'TAG CANCEL'`, `TR_TYPE 'O'`,
`ITM_SIGN '-'`, `ITM_FINE = net×touch/100`), **empty `AC_DATA`**; reversible `deleteTagCancel`. Stock
effect = **Matches**.

**GAPS:**
- Desktop persists a **`BAR_CAN_DATA` / `BAR_CAN_DETL`** header+detail voucher (a cancel register); web
  writes **only `MAIN_STOCK`** — the cancellation isn't recorded as a listable voucher.
- No **Counter (`TBL_CODE`)** capture (which counter the tag leaves).
- No **in-stock guard** — web does not verify the tag is actually on-hand before cancelling (desktop
  resolves the tag from stock on select; a typo cancels a phantom).
- Header **Book/Year/Location** inputs are ignored by the route (uses session scope).

**Fill plan:**
- `tagOps.tagCancel`: additionally write `BAR_CAN_DATA` (header) + `BAR_CAN_DETL` (per-tag) rows;
  accept `tblCode`; add a pre-check reusing `stock.ts` in-stock logic (`BAR_DETL` exists AND no
  `MAIN_STOCK` `'-'`) → throw `TagNotAvailableError` if missing. Add both tables to `deleteTagCancel`
  reverse list.
- Route `/stock/tag-cancel`: read `b.coBook/coYear/lcCode` into scope (or remove those page inputs).
- Frontend: optional Counter column.

**Priority: P1** · **Effort: S–M** (stock removal matches; register + guard are behaviour/parity).

## 2b. Tag Print — `UT_TAG_PRINT` → **NO web route (missing screen)**

**Desktop spec (KB §2.3):** "Tag Print" label/barcode reprint. Header **Book · Vch No(F1) · Item
(Gold/Silver) · Gr Code · Pr Code · Print file (`QrPrint10` ▼) · Set**; grid `Sr | Y/N | TagNo |
ItCode | Counter | Design | Size | Pcs | GrWt | NetWt | Touch | West% | Fine | LbrRate | LbrAmt |
OthAmt | Mrp | KrCode`; footer **Lable Skip**. Three selection modes (by TagNo / by Product→list
in-stock tags with Y/N skip / by Book+VchNo). **Read-only** — no data mutation; Crystal label output
(`CHG00004 / G.14.300 / N.14.300 / LP:600 / 916 / QR`). Confirmed in `UT_TAG_PRINT.cs` (uses
`AxCrystalReport Cr` + `btnTagSet`; no INSERT/UPDATE).

**Web now:** **No page, no route, no API.** `integrations/barcode.ts` can generate a barcode/QR but
there is no tag-label print utility. This is the module's one **entirely absent screen**.

**GAPS:** the whole feature — (a) reprint by TagNo, (b) list a product's in-stock tags with per-row
**Y/N** skip, (c) reprint by Book+VchNo, (d) choose **Print file** (`QrPrint10`) + **Lable Skip**
offset, (e) render the QR/barcode label.

**Fill plan:**
- Backend new `stock/tagPrint.ts`: `listPrintableTags({by:'tag'|'product'|'voucher', tagNo?, prCode?,
  book?, vchNo?})` reading `BAR_DETL`/`BAR_IDTL` joined to `ITEM_MAST`/`PRODUCT_MAST`/`GROUP_MAST`;
  `renderTagLabels(tags[], {printFile, labelSkip})` → label doc (reuse `integrations/barcode.ts` for QR
  + `reports/render.ts` → PDF). Routes `GET /stock/tag-print` (list) + `GET /stock/tag-print/label`
  (PDF).
- Frontend new `txn/tag-print/page.tsx`: the 3 selection modes + Y/N grid + print-file/label-skip +
  Print; register in `lib/nav.ts`.

**Priority: P1** · **Effort: M–L** (whole screen; not a ledger/stock blocker but a real, used utility).

---

## 3. Stock Adjust — `/txn/stock-adjust` + `stock.ts stockAdjust`

**Desktop spec (KB §3):** book **STOCK ADJUST** — main grid `Sr | TagNo | ItCode | Counter | Design |
Size | Sign | Pcs | GrWt | LsWt | NetWt | Touch | West% | Fine | Mrp | KrCode` + a lower karigar
sub-grid (`ItCode|ItName|Pcs|Weight|KrWt|Con%|P/W|Rate|ItAmt|NetAmt`); **Sign +/- mandatory** (warns
if blank); signed `MAIN_STOCK`, **no ledger**.

**Web now:** `stock-adjust/page.tsx` grid `Item | Tag | +/− | Pcs | Gross | Net | Touch | Fine(derived)
| Rate` + date. `stock.ts stockAdjust` writes signed `MAIN_STOCK` (`VCH_TYPE 'STADJ'`, `BOOK_NAME
'STOCK ADJ'`, `TR_TYPE 'A'`, `ITM_SIGN` +/-, `TAG_NO 'N'` default, `TBL_CODE '000'`, `fine=net×touch/
100`, `ITM_AMT/NET_AMT=fine×rate`); reversible. Core effect = **Matches**.

**GAPS:**
- Missing columns: **Counter** (`TBL_CODE` — web hardcodes `'000'`, desktop uses MAIN STOCK `001`),
  **Design**, **Size**, **LsWt** (loss/other wt), **West%**, **Mrp**, **KrCode** (karigar).
- No lower **karigar sub-grid**.
- **Sign defaults `'+'`** in web vs desktop forcing an explicit +/- choice with a warning.
- **No tag autofill** — the `tags` LookupPicker has no `onPick`, so a tagged adjust needs the operator
  to hand-type itCode/net/touch (the lookup already returns `ITM_NWT/ITM_TOUCH/…`).
- No **Employee** / **Vch remark** footer.

**Fill plan:**
- `stock.ts StockAdjustLine`: add `tblCode`(counter, default `'001'`), `designNo`, `itmSize`, `lossWt`
  (→`ITM_OTH_WT`, adjust net), `westPct`(→`ITM_WEST`), `mrp`(→`ITM_MRP`), `krCode`.
- Frontend: add Counter picker, Design/Size/LsWt/West%/Mrp/KrCode columns; wire tag `onPick` autofill;
  remove the `'+'` default and validate a Sign is chosen.

**Priority: P1** · **Effort: M** (signed-stock matches; Counter/karigar/LsWt are real fields).

---

## 4. Physical Stock — `/txn/physical-stock` + `stock.ts physicalReconcile`

**Desktop spec (KB §4):** `TR_PHYSTK` entry (book **PHY STOCK** → `BAR_CAN_DATA/DETL`) + `RP_PHY_STOCK`
report. Entry scans tags (`TagNo|ItCode|ItName|Design|Size|Cntr|Pcs|GrWt|OthWt|NetWt|LbrAmt|OthAmt|Mrp|
KrName`) + **Reset Stock**. Report filters **From/To/Stock/ItemType/Product/Group**; grid `Sr | cTagNo
| ItName | Size | Cntr | Pcs | GrWt | Mrp | Stk | Out | Apr | Phy | Diff | DiffWt` with **All** / **Diff**
buttons + totals. (`RP_PHY_STOCK.cs` confirmed: constants `cOutQty=9`, `cAprQty=10`, `cPhyQty=12`,
`BtnDiff`, `RsOut/RsPhyStk`.)

**Web now:** `physical-stock/page.tsx` — a single **textarea** of counted tag numbers → `POST
/stock/physical-reconcile` → tiles (bookCount/countedCount/matched/missing/extra) + two lists
(missing/extra). `stock.ts physicalReconcile` compares counted tags to **`TAG_STOCK`** (presence set)
→ matched/missing/extra. Read-only; route has **no RBAC guard**.

**GAPS:**
- **Wrong book source:** reconcile reads **`TAG_STOCK`** (web-created presence tags), but the rest of
  `stock.ts` treats **`BAR_DETL`** as inventory truth (`onHand`, `listTags`). Counting real desktop
  inventory will mis-report everything as "missing/extra".
- No **Out / Apr** classification (sold vs on-approval) — web only does tag-presence matched/missing/
  extra; desktop splits Stk/Out/Apr/Phy.
- No **weights** — no `DiffWt` (shortage grams), no per-tag `ItName/Size/Cntr/Pcs/GrWt/Mrp` detail, no
  totals row.
- No **saved count voucher** (desktop persists to PHY STOCK / `BAR_CAN_DATA/DETL`) and **no Reset
  Stock**.
- No **filters** (From/To/Stock/ItemType/Product/Group), no **All/Diff** toggle, no scan-helper grid
  (plain textarea only).

**Fill plan:**
- `stock.ts physicalReconcile`: base the book set on **`BAR_DETL` in-stock** (reuse the `listTags`
  query, excluding sold), return per-tag detail + weight aggregates (`DiffWt = Σ netWt(missing)`); add
  **Out** (tags with a `MAIN_STOCK '-'` sale) and **Apr** (approval table) buckets. Add
  `savePhysicalCount(lines)` → `BAR_CAN_DATA/DETL` (book `'PHY'`) and `resetPhysicalCount(vchNo)`.
- Frontend: replace textarea with a scan/entry grid (auto-resolve tag→item/weight), add filters, a
  report grid `Stk/Out/Apr/Phy/Diff/DiffWt` + totals, **All/Diff** toggle, **Save** + **Reset Stock**.
- Add an RBAC guard on the route if it becomes a persisted voucher.

**Priority: P1** · **Effort: L** (tag-level variance works, but wrong source + no weight/Out/Apr + no
persistence).

---

## 5. Order Cancel — `/txn/order-cancel` + `sales/salesOrder.ts cancelSalesOrder`

**Desktop spec (KB §5):** `TR_SL_ORD_ADJ`, book **ORDER CANCEL** → table **`SL_ORD_ADJ`**. Lists all
**pending** orders; grid `Sr | OrdNo | AcCode | AcName | ItDesc | OrdAmt | AdjAmt | KsarAmt | PaidAmt |
PaiidAc | Paid Ac Name`. **PaidAmt** defaults to the advance; **PaiidAc** defaults **CASH ON HAND
(00001)** but the operator changes it to e.g. **HDFC BANK (000203)** to refund from bank. Save writes
`SL_ORD_ADJ` then posts the refund via `Ac_Ledr.Order_Adj_Ledr` + `Ac_Rojmel.Order_Adj_Rojmel`
(Dr customer / Cr chosen account). No stock. **Confirmed in `TR_SL_ORD_ADJ.cs`:** grid cols `KsarAmt`
(7)/`PaiidAc`(9)/`Paid Ac Name`(10); `SL_ORD_ADJ` cols `ORD_NO/ORD_AMT/ORD_SIGN/KASAR_AMT/PAID_AMT/
PAID_AC` + `ORD_LC/ORD_YRCD/ORD_DBCD`; `BtnSave_Click` sets `PAID_AC` (default "CASH ON HAND") then
calls `Ac_Ledr.Order_Adj_Ledr` / `Ac_Rojmel.Order_Adj_Rojmel`.

**Web now:** `order-cancel/page.tsx` lists `/sales-orders` (Vch/Date/Customer/Total/Advance/Delivery)
with a per-row **Cancel** button → `DELETE /sales-orders/:vchNo`. `cancelSalesOrder` **reverses**
`SL_ORD_DATA/DETL/IDTL` + `AC_DATA` **by voucher key** (undoes the original advance posting), writes
`DELETE_DATA`; **guard:** refuses if any line has `DESIGN_ISU='Y'`/`TAG_SALE='Y'`/`TAG_GEN='Y'`.
Pending-only listing + guard = **Matches**.

**GAPS (this is the crux of the screen):**
- **No operator-chosen refund account (`PaiidAc`).** Web silently reverses the original advance (money
  returns to whatever account it came from); desktop books a **fresh refund through a chosen account**
  (advance taken in cash, refunded via bank).
- **No partial adjust (`AdjAmt`), no Kasar (`KsarAmt`), no editable `PaidAmt`** — web is all-or-nothing
  reversal only.
- **No `SL_ORD_ADJ` persistence** — no ORDER CANCEL adjustment/register row
  (`ORD_NO/ORD_AMT/ADJ_AMT/KASAR_AMT/PAID_AMT/PAID_AC`).
- No **cancel detail grid** (OrdNo/ItDesc/OrdAmt/AdjAmt/KsarAmt/PaidAmt/PaiidAc) — just a button.
- Ledger **narration differs** — reversed `SORD` rows vanish vs desktop's explicit "Order Cancel" row
  in the party/bank ledger (KB kf_035).

**Fill plan:**
- `sales/salesOrder.ts`: add `cancelSalesOrderAdjust({scope, vchNo, paidAc, paidAmt, adjAmt,
  kasarAmt})` that (a) inserts `SL_ORD_ADJ` (ORD_NO=order key, ORD_AMT, ADJ_AMT, KASAR_AMT, PAID_AMT,
  PAID_AC, + ORD_LC/ORD_YRCD/ORD_DBCD), (b) posts a **balanced ORDER-CANCEL refund** via
  `postVoucherTx` — Dr customer (clear advance liability) / Cr chosen `PaiidAc` (+ any `KsarAmt` to a
  kasar a/c) — mirroring `Ac_Ledr.Order_Adj_Ledr`, (c) removes/flags the pending `SL_ORD_DATA`. Keep
  the existing key-reverse as the plain "delete order" path.
- Route: add `POST /order-cancel` (or extend the DELETE to take a body) carrying `paidAc/paidAmt/
  adjAmt/kasarAmt`.
- Frontend: expand to a cancel voucher — select order → editable PaidAmt/AdjAmt/KsarAmt + **PaiidAc
  account picker** (default CASH ON HAND) → Save.

**Priority: P0** · **Effort: M** (refund-account + partial/kasar + `SL_ORD_ADJ` are the defining
behaviour; current web cannot refund to a different account or partially).

---

## 6. Tag Transfer — `/txn/tag-transfer` + `stock.ts tagTransfer`

**Desktop spec (KB §6):** `TR_INOUT`, book **TAG TRFR** — convert a barcoded tag → bulk/loose item
(broken chain → OLD GOLD). Grid `Sr | TagNo | ItCode | Counter | Design | Size | Pcs | GrWt | LsWt |
NetWt | Touch | West% | Fine | TrfrItm | TrfrItmName` + lower sub-grid; two balanced `MAIN_STOCK` legs
(OUT tag `'-'`, IN bulk `'+'`, same net/fine), **no ledger** (metal conserved).

**Web now:** `tag-transfer/page.tsx` grid `Tag | From item | → To item | Pcs | Gross | Net | Touch |
Fine | Rate`. `stock.ts tagTransfer` emits OUT (`ITM_SIGN '-'`, `TAG_NO=tag`, `IT_CODE=fromItCode ||
toItCode`) + IN (`ITM_SIGN '+'`, `TAG_NO 'N'`, `IT_CODE=toItCode`) with equal net/fine
(`VCH_TYPE 'TAGTR'`, book `'TTR'`); reversible. Conservation = **Matches**.

**GAPS:**
- **Tag pick does NOT autofill** — the `tags` LookupPicker has **no `onPick`** (unlike tag-cancel/
  tag-weight-diff), so the operator must hand-type fromItCode/netWt/touch even though the lookup
  returns `ITM_NWT/ITM_TOUCH/…`. (KB "to-verify" → confirmed gap.)
- Because `fromItCode` is optional and **falls back to `toItCode`** on the OUT leg, a blank From-item
  books the OUT against the wrong item code (should be the tag's real `IT_CODE`).
- Missing columns: **Counter, Design, Size, LsWt, West%**; no lower sub-grid.

**Fill plan:**
- Frontend `tag-transfer/page.tsx`: wire tags `onPick` → set `fromItCode` (=`IT_CODE`), netWt/grossWt/
  touch/rate from the lookup (copy the tag-cancel pattern); add Counter/Design/Size/LsWt/West% columns.
- `stock.ts tagTransfer`: require a resolved `fromItCode` (don't silently fall back to `toItCode`);
  accept tblCode/design/size/lossWt/westPct.

**Priority: P1** · **Effort: S–M** (OUT/IN conservation matches; autofill + correct OUT item code
matter for real inventory).

---

## 7. Tag Weight Change — `/txn/tag-weight-diff` + `stock/tagOps.ts tagWeightDiff`

**Desktop spec (KB §7):** `TR_TAG_WT_DIFF` — main grid old-vs-new (`OGrWt|ONetWt|NwGwt|NwNet|DiffGWt|
DiffNWt|Lbr%|LType|LbrRate`); **absorption sub-grid** into bulk (`ItCode…Sign|Rate|ItAmt|NetAmt`);
**Party panel** (`Cr/Dr Touch`, `Cr/Dr Fine`, `1gm Rate`, `Cr/Dr Amount`, Employe, Diff Amount);
credits the **real karigar party** (`AC_MAST`) with `KR_TOUCH/KR_FINE` + optional Cash/Bank payment;
also splits sets. **Confirmed in `TR_TAG_WT_DIFF.cs`:** "Party Code" label, "Party Help", sub-grid
`Sign`(18), and `KR_NET_WT/KR_TOUCH/KR_WEST_PRC/KR_FINE/KR_LBR_RATE` columns.

**Web now:** `tag-weight-diff/page.tsx` grid `Tag | Item | Old Net Wt | New Net Wt | Touch % | Rate |
Diff | Diff Fine | Value` with tag `onPick` autofill (itCode/oldNetWt/touch/rate) + net-total footer.
`tagOps.tagWeightDiff` books `|diff|` as one signed `MAIN_STOCK` (`VCH_TYPE 'TGWD'`, `BOOK 'TAG WT
CHANGE'`) + a balanced `AC_DATA` pair against **generic `STKADJ`/`WTDIFF`** accounts
(gain⇒Dr STKADJ/Cr WTDIFF; loss⇒reverse), value=`diffFine×rate`; reversible. The source itself notes it
is "the simplified, equivalent net-of-difference form." Net-diff stock model = **Matches**.

**GAPS:**
- Credits **generic WTDIFF/STKADJ**, **not the actual karigar party** with `CR_TOUCH/CR_FINE/1gm-rate`;
  **no Party field** on the web form.
- No **absorption sub-grid** to route the diff into a chosen bulk item (OLD GOLD) with its own **Sign**
  (web keeps the diff on the same tag/item).
- No optional **Cash/Bank payment** of the karigar amount.
- No **gross/OthWt/Lbr%/LType/LbrRate** columns (net only); no Employe / Diff-Amount / Payment-Received
  panel.
- **Set-splitting** use-case absent (closer to `tag-split`/`tagSplit`).

**Fill plan:**
- `tagOps.tagWeightDiff`: add `partyAc` (credit the karigar with fine/touch/1gm-rate → replaces the
  generic account when supplied, posting Dr/Cr party like `Ac_Ledr.Tag_Wt_Diff_Ledr`), `absorbItCode`
  + `absorbSign` (a second `MAIN_STOCK` leg into OLD GOLD), and optional `payAc`+`payAmt` (Cash/Bank).
- Frontend: add Party picker + Cr Touch/Fine/1gm-Rate fields; absorption sub-grid (bulk item + Sign);
  optional payment; gross/OthWt columns.

**Priority: P1** · **Effort: M–L** (stock model matches; karigar-party credit + OLD-GOLD absorption +
payment are important behaviour).

---

## 8. Labour Update — `/masters/labour-update` + `masters/labourUpdate.ts`

**Desktop spec (KB §8):** `MS_AUTO_ITEM` "Labour and Mrp Update" — **Gr Code** picker; grid `Sr. | It
Code | It Name | OLbr | NLbr | OLbr% | NLbr% | OMrp | NMrp | OWest% | NWest%`; bulk `UPDATE ITEM_MAST`
(New only; blank = unchanged); **multiple labour slabs per `IT_CODE`**.

**Web now:** `labour-update/page.tsx` group picker + grid `Item | O.Lbr | N.Lbr | O.Lbr% | N.Lbr% |
O.MRP | N.MRP | O.West% | N.West%`; partial. `labourUpdate.ts listLabourItems(grCode)` reads
`ITEM_MAST(IT_LBR_RATE,LBR_PRC,ITEM_RATE,IT_WEST)` `ORDER BY IT_CODE`; `applyLabourUpdate` maps
`NLbr→IT_LBR_RATE, NLbr%→LBR_PRC, NMrp→ITEM_RATE, NWest%→IT_WEST`, updating only supplied cols. Column
mapping + partial semantics = **Matches**.

**GAPS:**
- **Multi-slab keying:** `listLabourItems` returns **one row per `IT_CODE`** and `applyLabourUpdate`
  does `UPDATE ITEM_MAST … WHERE CO_CODE AND IT_CODE` — it updates **every** row of that IT_CODE. If a
  deployment stores multiple labour slabs per item (desktop shows `CH916` at 12%/15%/₹500/₹700), the
  web cannot target one slab and edits collide.
- Minor: no double-confirm (desktop Yes/Yes); no post-update Tag-Print reprint link.

**Fill plan:**
- `labourUpdate.ts`: **verify** whether `ITEM_MAST` is one-row-per-item in this schema. If multi-slab
  rows exist, add a per-row key (`SR_NO` / the slab columns) to `listLabourItems` output and into the
  `UPDATE … WHERE` so each slab updates individually; frontend keys rows by that id. If single-row,
  document that the current whole-item update is correct.

**Priority: P2** · **Effort: S** (matches for single-slab; multi-slab targeting is a schema-dependent
edge — verify first).

---

## 9. Bank Reconciliation — `/txn/bank-recon` + `finance/bankRecon.ts`

**Desktop spec (KB §9):** `UT_BANK` — **From/To** (auto current month) + **Bank**; grid `Sr | BookType
| Ac Name | VchNo | VchDate | ChqNo | ClrDate | DrAmt | CrAmt | AmtBal | CrDr` with an **Op Balance**
row; **Bal Chk** = cleared balance; **F1** on ClrDate = today. Sets `AC_DATA.CLR_DATE`.

**Web now:** `bank-recon/page.tsx` Bank picker + From/To; tiles **Book / Cleared / Uncleared**; grid
`Book | Vch | Type | Date | Chq No | Dr | Cr | Cleared(checkbox) | Clr Date`. Checkbox → `POST
/bank-recon/clear` (sets today or null). `bankRecon.ts bankReconList` returns rows + `book/cleared/
uncleared` totals, `ChqNo` from `CASH_DATA`/`PAY_DATA`; `bankReconClear` sets `AC_DATA.CLR_DATE`.
Clearing + cleared/book/uncleared math = **Matches**.

**GAPS:**
- No per-row running **`AmtBal`** column (web returns aggregate totals, not a running balance) and no
  **Op Balance** opening row.
- No **`Ac Name`** column — `bankReconList` doesn't select the counter-party name per row.
- No explicit **Bal Chk** button (the Cleared tile is functionally equivalent — minor) and no F1-today
  (checkbox auto-sets today — equivalent).
- **From/To** don't auto-default to the current month.

**Fill plan:**
- `bankRecon.ts bankReconList`: compute a running `amtBal` per row (cumulative Σ(dr−cr) with opening)
  + emit an opening-balance row; join the counter-party `AC_NAME` for each voucher.
- Frontend: add `AmtBal` + `Ac Name` columns; default From/To to the current month; optional explicit
  "Bal Chk" button.

**Priority: P2** · **Effort: S–M** (clearing + balances match; AmtBal/AcName/opening are display
parity).

---

## 10a. Reminder Entry — `/utilities/reminder-entry` + `utilities/reminderEntry.ts`

**Desktop spec (KB §10.2):** `UT_REMINDER`, book **REM** → `REMARK_DATA`; pick **Account**, **Remark**,
**Rem Date**; list `Sr | AcName | Remark | EntDate | RemDate | Mobile`.

**Web now:** `reminder-entry/page.tsx` Account picker + Reminder Date + Description; list `Vch | Date |
Account | Description` + delete. `reminderEntry.ts createReminderEntry` inserts `REMARK_DATA` (book
`REM`, `AC_CODE/AC_NAME/VCH_REMARK/VCH_DATE=RemDate`); `listReminderEntries`; `deleteReminderEntry`.
Entry + persistence = **Matches**.

**GAPS:**
- List omits the **EntDate (entered-on) vs RemDate (remind-on)** distinction — web stores only one
  `VCH_DATE` (=RemDate); desktop shows both.
- No **Mobile** column.

**Fill plan:**
- `reminderEntry.ts`: store an entry date (`ENT_DATE`/`ADD_DATE`) alongside `VCH_DATE`(RemDate); return
  party mobile (join `AC_MAST`) + both dates.
- Frontend: show EntDate/RemDate/Mobile columns.

**Priority: P2** · **Effort: S** (entry matches; extra columns are display).

## 10b. Reminder Dashboard — `/txn/reminders` (+ `/utilities/reminders`) + `finance/reminders.ts`, `ops/reminders.ts`

**Desktop spec (KB §10.3):** `RP_REMINDER` "Reminder Report" — dataset buttons **Order Rem · Sales Rem
· Wh Sales Rem · Dhiran Rem · Birthday And Anv · Schm Rem · Reminder Entry · Item In Out**; From/To.
**Sales Rem** cols `SrNo | AcName | VchDate | VchType | VchNo | TotAmt | OsAmt`, aged by the **per-bill
CrDay**; **Birthday** from `AC_MAST` `BR_DATE/AN_DATE`.

**Web now:** `txn/reminders/page.tsx` shows **Receivables** (party/mobile/outstanding/gold/silver/
oldest/creditDays/status) + **Orders due** from `GET /reminders` (`finance/reminders.ts reminders`,
which ages by party `AC_MAST.AC_CR_DAYS` and **explicitly omits birthday**). Separately,
`ops/reminders.ts` provides `overdueReminders`/`birthdayReminders`/`sendReminder` (routes
`/reminders/overdue`, `/reminders/birthdays`, `/reminders/send`), and a richer `utilities/reminders/
page.tsx` (15 KB) also exists. Sales-Rem + Order-Rem + WhatsApp/SMS send = **Matches/exceeds**.

**GAPS:**
- The `/txn/reminders` dashboard surfaces only **Sales Rem** + **Order Rem** — **Birthday And Anv** is
  implemented in `ops/reminders.ts` but **not wired** onto this dashboard (it must call
  `/reminders/birthdays`; `finance/reminders.ts` deliberately omits it).
- Missing dataset views: **Wh Sales Rem**, **Dhiran Rem**, **Schm Rem**, **Item In Out**.
- **Aging basis nuance:** web ages by party-level `AC_CR_DAYS`; desktop ages a sale by its **per-bill
  CrDay**. Different due dates.
- **Sales Rem shape differs:** web is party-consolidated (party/oldest/crDays); desktop is **per-bill**
  rows (VchDate/VchType/VchNo/TotAmt/OsAmt).
- Two overlapping pages (`/txn/reminders` and `/utilities/reminders`) — needs de-dup/routing decision.

**Fill plan:**
- Frontend: unify on one dashboard with **dataset tabs** (Sales / Order / **Birthday** / WhSales /
  Dhiran / Scheme / ItemInOut); wire Birthday to `GET /reminders/birthdays` (`ops/reminders.ts`).
- Backend: add `whSalesReminders` (wholesale OS), `dhrnReminders` (`DHRN` due), `schemeReminders`
  (scheme installment due), `itemInOutReminders`; add a **per-bill** Sales-Rem list (`SrNo/AcName/
  VchDate/VchType/VchNo/TotAmt/OsAmt`) aged by **bill CrDay** to match the desktop basis.

**Priority: P1** · **Effort: M–L** (Sales/Order/Birthday exist but birthday unsurfaced + 4 datasets
missing + aging basis differs).

---

## Module summary — top gaps by priority

1. **[P0] Order Cancel — no refund-account / partial / kasar, no `SL_ORD_ADJ`** (§5). Web just
   key-reverses the advance; desktop books a fresh refund through an operator-chosen `PaiidAc` (cash→
   bank) with `AdjAmt/KsarAmt/PaidAmt` persisted in `SL_ORD_ADJ`. Confirmed in `TR_SL_ORD_ADJ.cs`.
   *Fix:* `cancelSalesOrderAdjust` + `SL_ORD_ADJ` write + balanced refund posting + account-picker UI.
   **Effort M.**
2. **[P1] Physical Stock — wrong book source + no Out/Apr/DiffWt + no persist/reset** (§4). Reconcile
   reads `TAG_STOCK` not `BAR_DETL`, has no weights, no Out/Approval split, no saved count / Reset.
   *Fix:* re-base on `BAR_DETL`, add weight + Out/Apr buckets, `savePhysicalCount`/`resetPhysicalCount`,
   filters + All/Diff grid. **Effort L.**
3. **[P1] Tag Print — entire screen missing** (§2b). No route/page/API for label reprint (by tag /
   product Y-N / voucher; print-file + Lable Skip; QR/barcode). *Fix:* new `stock/tagPrint.ts` +
   `txn/tag-print/page.tsx`. **Effort M–L.**
4. **[P1] Tag Weight Change — credits generic accounts, not the karigar party** (§7). No Party field, no
   OLD-GOLD absorption sub-grid, no Cash/Bank payment (desktop `KR_TOUCH/KR_FINE` + Party Help
   confirmed). *Fix:* add `partyAc`/`absorbItCode`+Sign/`payAc` to `tagWeightDiff` + UI. **Effort M–L.**
5. **[P1] Reminder Dashboard — birthday unsurfaced + 4 datasets missing + aging basis** (§10b). Wire
   Birthday (already in `ops/reminders.ts`) onto `/txn/reminders`; add WhSales/Dhiran/Scheme/ItemInOut;
   age Sales-Rem by per-bill CrDay. **Effort M–L.**

**Runners-up (P1):** Daily Rate per-group grid + Tax%/Employee/F1-history (§1, M); Stock Adjust
Counter/karigar-subgrid/LsWt + tag autofill (§3, M); Tag Transfer tag-pick autofill + correct OUT item
code (§6, S–M); Tag Cancel `BAR_CAN_*` register + in-stock guard (§2a, S–M).
**P2 polish:** Bank-Recon per-row AmtBal + AcName + opening row (§9); Labour Update multi-slab keying
(§8, verify schema); Reminder Entry EntDate/RemDate/Mobile columns (§10a).

**Screens that already match the desktop footprint** (verified, no functional gap): Daily Rate
*derivation*, Tag Cancel *stock effect*, Stock Adjust *signed-stock effect*, Tag Transfer *OUT/IN
conservation*, Tag Weight Change *net-diff stock model*, Labour Update *column mapping + partial*,
Bank Recon *clearing + cleared/book/uncleared math*, Reminder Entry *insert/list/delete*.
