# WP-23 study: Company → Balance TrFr (desktop `BtmSchm`)

Written for the next workers (case list and database tests). Desktop citations are `FILE:LINE {{quoted text}}`; `BtmSchm.cs` is
5,639 lines in the decompiled file (the packet says 5,638). Where I did not read a range in full I say so.
Web paths are relative to `web/`. Desktop match of the web page is **0%**: nothing here is accepted.

## Scope

**Menu and form.** Caption `Balance TrFr`, tab Company, smCode 03, edition `L` (Lite) in `docs/handbook/menu-editions.json`.
The menu opens the form directly:
MDI_FORM.cs:7431-7433 {{case "Balance TrFr":}} and MDI_FORM.cs:7433 {{BtmSchm btmSchm = new BtmSchm();}}.
The Lite loader shows only MENU_DATA rows of type L: MDI_FORM.cs:11299 {{SM_TYPE = 'L'}}.

**Key finding on editions (changes the packet's premise).** `BtmSchm.cs` contains no edition check that hides a
dataset button. The only `MsSoftType` use is one branch inside the account-opening query (BtmSchm.cs:2766 {{DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E"}}). Lite is `L`
(MDI_FORM.cs:11296-11298 {{else if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)}}), so Lite takes the `else`
branch at BtmSchm.cs:2786 {{DC_Main.RsQry = "Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE As DataType,}}. What is visible is decided by the designer and by three company settings (`MsMfgType`,
`MsOsBillOrnaIsu`, a double-click). So in Lite every button except the four below is visible and clickable, even where Lite
can hold no data for it (its menu is not in Lite). I therefore classify each button by (a) whether it is hidden by the
form, and (b) whether the source menu exists in Lite (from `menu-editions.json`).

Hiding rules, all verified:
- `lblJadtarTrfr`: BtmSchm.cs:1641 {{((Control)lblJadtarTrfr).Visible = false;}}; shown when BtmSchm.cs:2073 {{DC_Main.MsMfgType, "J", false) == 0)}}.
- `btnMfgTrfr`: BtmSchm.cs:1891 {{((Control)btnMfgTrfr).Visible = false;}}; shown when BtmSchm.cs:2077 {{DC_Main.MsMfgType, "M", false) == 0)}}.
- `btnIdtl`: BtmSchm.cs:1859 {{((Control)btnIdtl).Visible = false;}}; shown only by BtmSchm.cs:5592-5594 {{private void PnlBotam_DoubleClick(object sender, EventArgs e)}} (a double-click on the bottom panel).
- `btnBillOrnaIsu`: no designer hide; BtmSchm.cs:2081 {{DC_Main.MsOsBillOrnaIsu, "N", false) == 0)}} only sets Visible = true, so it is visible in every edition.
- `MsMfgType` is a company setting, blank by default: MS_OPNCOMP.cs:4906 {{DC_Main.MsMfgType = "";}}. Whether a Lite company can have `J`/`M` is not shown by the source (open question 1).

### Button table (every button; first-row group = Lite datasets)

| Button (control) | Caption | Handler:line | Visible in Lite? | Source menu and edition | Lite dataset? |
|---|---|---|---|---|---|
| BtnAcBalence | Ac Balance | BtnAcBalence_Click :2724 | yes, no hide | Party / account ledger (Lite core) | **yes** |
| BtnItmStk | Item Stock | BtnItmStk_Click :2921 | yes | Item Opening (L) | **yes** |
| BtnTagStock | Tag Stock | BtnTagStock_Click :2169 | yes | Tag Opening (L), Tag Stock report (L) | **yes** |
| BtnOrder | Sales Order | BtnOrder_Click :3003 | yes | Sales Order (L), Order Cancel (L) | **yes** |
| BtnApr | Approval | BtnApr_Click :4116 | yes | Approval Isu / Rtn (L) | **yes** |
| SimpleButton1 | Scheme | :3336 → Rtl_Scheme | yes (no check) | Scheme menus are `P` | no (Premium) |
| BtnDhrn | Dhiran | :3602 → Rtl_Dhrn | yes (no check) | Dhiran menus are `P` | no |
| BtnLoan | Loan | :3859 → Rtl_Loan | yes (no check) | Loan Issue / Received are `P` | no |
| btnBillOs | Bill Os Trfr | :4651 | yes (no check) | Bill Wise Rec is `S` | no (Standard) |
| btnTimeLdr | Time Ldr Trfr | :4871 | yes (no check) | Time ledger; no Lite menu; copies party balances to OP_LDR | no (copies party balances to OP_LDR, BtmSchm.cs:4880 {{ExeQuteTrfr("DELETE FROM OP_LDR WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '}}) |
| lblJadtarTrfr | Jadtar Trfr | :4917 | hidden unless MsMfgType J | Mfg menus are `S` | no |
| btnBillOrnaIsu | Bill Orna Isu | :4987 | yes (no check) | Orna issue; no Lite menu | no |
| btnVptrfr | Vp Trfr | :4956 | yes (no check) | Vp Parcel is `S` | no |
| btnBulTrfr | Bullion Trfr | :5014 | yes (no check) | Bul Report is `S` | no |
| brnOrdTraking | Order Traking | :5044 | yes (no check) | Order Track is `E` | no |
| btnReparing | Reparing Trfr | :5349 | yes (no check) | Repair menus are `S` | no |
| btnLotTrfr | Item Lot Trfr | :5415 | yes (no check) | Lot Opening is `A` | no |
| btnIdtl | Tag Idtl Trfr | :5447 | hidden until double-click | tag other-detail copy | no (hidden helper) |
| btnMfgTrfr | Mfg Trfr | :5597 | hidden unless MsMfgType M | Mfg menus `S` | no |

Captions: BtmSchm.cs:1311 {{Item Stock}}, :1342 {{Tag Stock}}, :1374 {{Ac Balance}}, :1422 {{Sales Order}}, :1453 {{Dhiran}}, :1484 {{Loan}},
:1515 {{Scheme}}, :1546 {{Approval}}, :1577 {{Bill Os Trfr}}, :1608 {{Time Ldr Trfr}}, :1639 {{Jadtar Trfr}}, :1671 {{Bill Orna Isu}}, :1702 {{Vp Trfr}},
:1733 {{Bullion Trfr}}, :1764 {{Order Traking}}, :1795 {{Reparing Trfr}}, :1826 {{Item Lot Trfr}}, :1857 {{Tag Idtl Trfr}}, :1889 {{Mfg Trfr}}.
Non-Lite buttons are recorded here only; they are out of scope. The five Lite datasets are covered in full below.

**Out of scope:** Year Create (WP-22); the 14 non-Lite buttons; the Crystal print (the form has none, see Print).

**Shared preconditions for every button.** The form works on a *transfer database* chosen on load, not on the current one:
reads use `DC_Main.OpenRecordSetDc` (current year DB), writes use `ExeQuteTrfr` / `OpenRecordSetTrFr` (next year DB, `CnTr`).
Scope values: `MCo_code`, `MLc_code`, `MCo_year`, closing date `MCl_dt` (MS_OPNCOMP.cs:602 {{DC_Main.MCl_dt = Conversions.ToDate(DC_Main.Rshlp.Rows[0]["CL_DATE"]);}}),
next year code `tYearCode`, and the next year's opening date `mTrfr_dt`.

## Screen

Controls named in the designer (all in `BtmSchm.InitializeComponent`, BtmSchm.cs:955-1928 {{//IL_0012: Unknown result type (might be due to invalid IL or missing references)}}); every caption is above.
- `lblBook` (title; set at load to the menu caption: BtmSchm.cs:1947 {{lblBook.Text = CurProcess;}}; the designer caption is BtmSchm.cs:1276 {{Balance Transfer}}). During a run it shows the step: `Tag Import`, `Item Master`, `Tag Transfer`, `Party Opning`, `Party Master`, `Item Opning`, `Sales Order`, `Order Tag Booking`, `Approvel Isu` (captions listed in `.orch/index/BtmSchm.md`).
- `lblLcName` caption BtmSchm.cs:1391 {{Transfer Year}} and `tYearCode` (text box, TabIndex 1153, centred; BtmSchm.cs:1382 {{tYearCode).TabIndex = 1153;}}). `tYearCode` is filled at load with the next year code (below). It is a plain text box in the designer: I found no `ReadOnly` or `Enabled=false` line, so the operator can type over it, and the writers read `tYearCode.Text` (open question 2).
- `ProgressBar1`: BtmSchm.cs:2177 {{((Control)ProgressBar1).Visible = true;}} is set only in the Tag Stock and Tag Idtl handlers; the other handlers update `ProgressBar1.Value` without setting Visible.
- Bottom panel `PnlBotam` with `BtnExit` (E&xit, BtmSchm.cs:1211 {{BtnExit.Text = "E&xit";}}), `BtnDelete` (&Delete, :1224), `BtnCancel` (&Cancel, :1238), `BtnSave` (&Save, :1251), `BtnPrint` (&Print, :1264). Delete and Print have empty handlers (see Print and Keyboard). Save has no `Click` handler listed in the form index.
- Button tab order: BtnAcBalence TabIndex 1 (BtmSchm.cs:1373 {{((Control)BtnAcBalence).TabIndex = 1;}}), BtnItmStk 2 (:1310), BtnTagStock 3 (:1341), then BtnOrder 1155 (:1421), BtnDhrn 1156, BtnLoan 1157, SimpleButton1 1158, BtnApr 1159, btnBillOs 1160, btnTimeLdr 1161, lblJadtarTrfr 1162 (:1640), btnBillOrnaIsu 1163, btnVptrfr 1164, btnBulTrfr 1165, brnOrdTraking 1166, btnReparing 1167, btnLotTrfr 1168, btnIdtl 1169 (:1858), btnMfgTrfr 1170.
- Year code default (BtmSchm.cs:2085-2105 {{tYearCode.Text = Conversions.ToString(Operators.ConcatenateObject((object)Strings.Mid(Conv}}). Normal company: BtmSchm.cs:2091 {{AND CO_YEAR > '" + DC_Main.MCo_year + "' ORDER BY CO_YEAR}}, so the **first later year** in `YEAR_MAST`; BtmSchm.cs:2102 {{tYearCode.Text = Conversions.ToString(DC_Main.Rshlp.Rows[0]["CO_YEAR"]);}}; `mTrfr_dt` = BtmSchm.cs:2104 {{mTrfr_dt = Conversions.ToDate(DC_Main.Rshlp.Rows[0]["OP_DATE"]);}}. With `MsAlterYear = "Y"` the query is BtmSchm.cs:2087 {{ORDER BY OP_DATE DESC}} (the *latest* year) and the text is the first 4 characters of CO_YEAR plus YEAR_MONTH (BtmSchm.cs:2098 {{tYearCode.Text = Conversions.ToString(Operators.ConcatenateObject((object)Strings.Mid(Conv}}).
- Target database name from the year code (BtmSchm.cs:2110-2145 {{DC_Main.CnTr.ConnectionString = ("Data Source=" + DC_Main.SqlServer + ";Initial Catalog="}}): BtmSchm.cs:2129 {{TrfrMdbName = "Next" + Strings.Mid(tYearCode.Text, 3, 2);}} (other company types use `NxAc`/`NxAb`, :2121 and :2125; alter-year uses `Next` + 4 characters, :2117). It is computed on *Activated*, so it follows the text at that moment.
- Themes and font scaling (BtmSchm.cs:1986-2060 {{if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.Screen}}) are cosmetic; not ported.

## Keyboard

Only two form-level handlers exist.
- Esc closes the form: BtmSchm.cs:2692-2695 {{if ((int)e.KeyCode == 27)}} then {{((Form)this).Close();}}.
- KeyPress upper-cases every typed character and swallows NUL and apostrophe: BtmSchm.cs:2683 {{if (num == 0 || num == 39)}}. This applies to `tYearCode` typing.
- No Enter, F-key, Ctrl or Alt handling. Buttons are reached by Tab or mouse; `BtnExit` (E&xit) and `BtnCancel` (&Cancel) have Alt accelerators from their captions.
- Exit: BtmSchm.cs:2662 {{((Form)this).Close();}}. Cancel calls `CLEAR_DATA` (BtmSchm.cs:2705 {{CLEAR_DATA();}}), which blanks all text boxes on the form, including `tYearCode` (BtmSchm.cs:2641-2652 {{val.Text = "";}}); after Cancel the writers would run with an empty year code (a desktop weakness; see below).

## Rules

Messages (verbatim, with the exact spelling the desktop uses):
1. Confirmation, Yes/No box titled `MsgTitle`, before Ac Balance, Item Stock, Tag Stock, Sales Order, Scheme, Dhiran, Loan, Approval and Tag Idtl: BtmSchm.cs:2729 {{Are You Sure To Data Transfer to Next Year ?}} (the same text at :2174, :2926, :3008, :3341, :3607, :3864, :4121, :5452). Style 4 = Yes/No; anything other than Yes (6) returns: BtmSchm.cs:2729 {{(MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)}}. Time Ledger uses BtmSchm.cs:4876 {{Are You Sure To Transfer Time Ledger to Next Year ?}}. Bill Os, Jadtar, Vp, Bullion, Order Tracking, Repair, Lot, Mfg, Bill Orna Isu have **no** confirmation.
2. Completion: BtmSchm.cs:2755 {{Process Are Complete....}} (information icon, style 64). It is shown even when a step failed to write rows, because no step checks a result.
3. No next year: BtmSchm.cs:2142 {{There Are Not Found New Year Please Creat New Year And Try....}}, shown on *Activated* when `tYearCode` is empty (BtmSchm.cs:2113 {{if (Operators.CompareString(tYearCode.Text, "", false) != 0)}}). **Nothing disables the buttons afterwards**; the operator can click one with no year and no target database (weakness 8). Focus stays where it was.
4. Party Opening merge prompt (only editions A/E with `MsDataType = "C"`): BtmSchm.cs:2770 {{A And B Data Merge Transfer...}}. Not reached in Lite.
5. There is no rule for "year locked", "target already has vouchers", "closing year not closed" or "From = To". `YEAR_MAST` is only read for the next year (BtmSchm.cs:2087-2091 {{DC_Main.RsQry = "SELECT * FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO}}). The web page adds its own (see Gaps).
6. Message after each rule: no focus change is coded.

## Calculations

Common: money values are written as numbers built by string concatenation; amounts are rounded **by `Strings.Format`**, not `Math.Round`.

### A. Ac Balance (BtnAcBalence, BtmSchm.cs:2724-2758 {{OpenRecordSetTrFr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateOb}})
Order of work after the confirmation:
1. Current-year side effect: BtmSchm.cs:2733 {{UPDATE A SET A.AC_MAIN_GR = B.AC_MAIN_GR FROM AC_MAST AS A,AC_GROUP AS B}}.
2. Last visit per account (AC_GR 04, 15, 05, 10, 20): BtmSchm.cs:2735 {{A.AC_GR IN ('04','15','05','10','20')}}, then for each row with a book, an UPDATE of `AC_MAST` in the **next** year: BtmSchm.cs:2748 {{UPDATE AC_MAST SET LAST_VISIT = '}} and `VISIT_TRAN`.
3. `Rtl_AcMast()` (:2813): copies every `AC_MAST` row that is missing in the next year (match on AC_CODE): BtmSchm.cs:2840 {{if (dataView.Count == 0)}}; names an address field `""` when it contains an apostrophe (BtmSchm.cs:2847 {{if (Operators.CompareString(Strings.Mid(}}); keeps only the first 2 characters of `AC_GR` and 25 of `AC_AREA`; `DATA_TRFR` = `'N'`, MAIN_USER copied. Rows already in the next year are **not** updated.
4. `Rtl_AcOpbl()` (:2759): closing = per `AC_CODE` and per `DATA_TYPE`, parties only, to the closing date. Quote of the projection and filters: BtmSchm.cs:2786 {{format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount}}, BtmSchm.cs:2786 {{B.AC_MAIN_GR < '3' and VCH_DATE <=}}, BtmSchm.cs:2786 {{iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)}} (gold) and the silver twin with `'S'`. Rows are kept when BtmSchm.cs:2786 {{HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(}} of money + gold + silver + `'D'` (diamond) fine is not 0. The group is by `A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE`, so one account with two `DATA_TYPE` values (A and B ledgers) becomes **two** opening rows.
5. Sign and size of each opening row (BtmSchm.cs:2799-2801 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObje}}): skip if BtmSchm.cs:2799 {{Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["Amount"])))}} (|amount|+|gold|+|silver| = 0); insert `OP_AMT` = |amount|, `OP_SIGN` = `'C'` when amount > 0 else `'D'`; `FINE_BAL` = |gold| with `FINE_SIGN` `'C'` when gold > 0 else `'D'`; `SL_FINE_BAL` / `SL_FINE_SIGN` the same for silver. Zero values therefore get sign `D`. Credit-positive: Cr = positive. Rounding: amount to 2 decimals and weights to 3 decimals by the `format(...,'0.00' / '0.000')` text, parsed back with `Conversion.Val`. Diamond fine (`IT_TYPE 'D'`) is inside the HAVING test but is **not** carried.
6. Constants written: `CO_YEAR` = `tYearCode.Text`, `CO_BOOK` = `'000'`, `VCH_NO` = `'00000'`, `DATA_TRFR` = `'Y'`, `ADD_USER` = `''`, `ADD_DATE` NULL: see the Lifecycle section for the column list. `DATA_TYPE` is the group value (A/B/C).

### B. Item Stock (BtnItmStk, BtmSchm.cs:2921-3002 {{DC_Main.RsQry = "SELECT A.IT_CODE AS Code,B.IT_NAME AS Name,B.IT_TYPE,B.GR_CODE,B.AVG_TOUC}})
Order: `Rtl_Item()` (copies PRODUCT_MAST BtmSchm.cs:2202 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObje}}, GROUP_MAST :2222, TABLE_MAST :2254, ITEM_MAST :2273, each only if the code is missing next year), then `AvgTouch`, then delete, then insert.
- `AvgTouch` first zeroes then rewrites average fields of the **current** year: BtmSchm.cs:2931 {{DC_Main.AvgTouch(DC_Main.MsSysDate, DC_Main.MLc_code);}}; DC_Main.cs:1698 {{UPDATE ITEM_MAST SET AVG_TOUCH = 0,AVG_FINE = 0,AVG_NWT = 0,AVG_RATE = 0}}. Note it is dated `MsSysDate`, not the closing date.
- Closing stock per item (untagged only): BtmSchm.cs:2933 {{SUM(iif(ITM_SIGN = '+', ITM_PCS, -ITM_PCS)) AS ClPcs}}, {{SUM(iif(ITM_SIGN = '+',ITM_NWT,-ITM_NWT)) AS ClWt}}, {{SUM(iif(ITM_SIGN = '+',ITM_GWT,-ITM_GWT)) AS ClWtGr}}, `ItAmt` = signed `ITM_PCS*ITEM_RATE`. Filters: BtmSchm.cs:2933 {{AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE <=}} and BtmSchm.cs:2933 {{(A.TAG_NO = 'N' OR A.TAG_NO = '' OR A.TAG_NO IS NULL)}}. Source table is `MAIN_STOCK` joined to `ITEM_MAST`.
- Fine for the opening: `num` = ClWt x item AVG_TOUCH / 100, formatted: BtmSchm.cs:2960 {{num = Conversions.ToDouble(Strings.Format((object)Conversion.Val((object)(num5 * num6 / 100.0)), "0.000"));}}, only when both net weight and average touch are non-zero. The touch written is the item's `AVG_TOUCH` (taken from the current year's value just recomputed). Pcs `Format "0"`, gross and net `Format "0.000"`.
- Row skipped when BtmSchm.cs:2964 {{Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ClWtGr"])) + Conversion.Val(}} (gross + net + pcs = 0). Note the sum of **signed** values, so +5 pcs and -5 net weight would cancel and be skipped.
- Written: `CO_BOOK` `'000'`, `IT_CODE`, `VCH_NO` = item type (code from `B.IT_TYPE`), `SR_NO` = row index + 1, `ITM_PCS`, `ITM_GWT`, `ITM_NWT`, `ITM_TOUCH`, `ITM_FINE` (= `num`), `ITM_RATE` 0, `ITM_AMT` = `ItAmt`, `LBR_AMT` 0, `OTH_AMT` 0, `NET_AMT` = `ItAmt`, `DATA_TRFR` `'Y'`, `DATA_TYPE` `'A'`.

### C. Tag Stock (BtnTagStock, BtmSchm.cs:2169-2184 {{if ((int)Interaction.MsgBox((object)"Are You Sure To Data Transfer to Next Year ?", (MsgBo}} and Rtl_BarData :2319-2640)
- Items with tags: BtmSchm.cs:2327 {{AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND TAG_NO <> 'N' GROUP BY B.IT_TYPE,A.IT_CODE}}.
- Which tags are carried: a tag is carried when its signed `MAIN_STOCK` balance is positive: BtmSchm.cs:2358 {{HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0}} (it sums `VCH_SRNO`, the tag's serial, as a +/- counter; it works only because each tag has serial numbers that cancel on a sale), with `A.VCH_DATE <= closing date` (BtmSchm.cs:2362 {{A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt}}) and `A.TAG_NO <> 'N'`. With `MsCoStockMerge = "Y"` a different join is used (BtmSchm.cs:2354-2356 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObje}}, no `CO_CODE` match); not Lite.
- Each tag's **full row** is read from `BAR_DETL` of the current year (BtmSchm.cs:2349 {{ORDER BY VCH_TIME DESC,TAG_NO DESC}}), and re-inserted unchanged (every numeric through `DC_Main.Fnv`) as a new row with: `CO_YEAR` = `tYearCode`, `CO_BOOK` = `'000'`, `VCH_NO` = `text` (voucher counter), `SR_NO` and `OLD_SRNO` = running number, `VCH_DATE` = the day before the next year opens: BtmSchm.cs:2378 {{mTrfr_dt.AddDays(-1.0)}}, `STK_DATE` copied, `INOUT_TYPE` `I`, `ENTRY_TYPE` `O`. Its `BAR_IDTL` stone rows follow (BtmSchm.cs:2515 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObje}} select, :2520 insert, `ISR_NO` = R+1).
- Voucher counter: starts at `00001` (BtmSchm.cs:2324 {{string text = "00001";}}); if the next year already has opening vouchers in book 000, the counter moves to MAX+1: BtmSchm.cs:2338 {{SELECT MAX((VCH_NO)) AS CoCode  From BAR_DATA}}. After each *item* with at least one tag a `BAR_DATA` header is inserted (BtmSchm.cs:2627 {{DC_Main.RsQry = "INSERT INTO BAR_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE, AC}}, `OP_STK` `'Y'`) and the counter is incremented by one.
- No rounding here: values are copied.

### D. Sales Order (BtnOrder, BtmSchm.cs:3003-3015 {{if ((int)Interaction.MsgBox((object)"Are You Sure To Data Transfer to Next Year ?", (MsgBo}} and Rtl_Order :3016-3335)
- First `Rtl_AcMast()` (as above), then the order carry.
- Selection: open orders to the closing date: BtmSchm.cs:3024 {{A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt}}, kept when the order is not fully adjusted: BtmSchm.cs:3024 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END) + SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_GOLD ELSE - B.ORD_GOLD END)}} plus silver, `> 0`. Adjustments are `SL_ORD_ADJ` rows with `ORD_SIGN '-'`: BtmSchm.cs:3024 {{SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_AMT ELSE 0 END) AS AdjAmount}}, with gold and silver twins.
- Each open order's header is rewritten into the next year **keeping its original `CO_YEAR`, `CO_BOOK` and `VCH_NO`** (BtmSchm.cs:3048 {{object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.Concatenate}} header columns; values from `rsData`), but with the adjusted-so-far totals in the adjustment columns: `ORD_ADJ_AMT` = AdjAmount (BtmSchm.cs:3071 {{double num7 = DC_Main.Fnv(ref Value);}} reading `AdjAmount`), `ADJ_GOLD` = AdjGold (:3102-3104), `ADJ_SILVER` = AdjSilver (:3110-3112). `ADV_AMT` is copied unchanged (BtmSchm.cs:3066-3068 {{Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["ADV_AMT"]);}}).
- Lines: `SL_ORD_DETL` rows of the order (BtmSchm.cs:3127 {{FROM SL_ORD_DETL AS A LEFT JOIN BOOK_DATA}}) inserted at :3137; stone lines `SL_ORD_IDTL` at :3215-3226 (via `INSERT INTO "TrfrMdbName".dbo.SL_ORD_IDTL`, a cross-database insert executed on the *current* connection).
- Second pass, "Order Tag Booking": every detail line with `TAG_SALE = 'N'` (BtmSchm.cs:3226 {{AND TAG_SALE = 'N' ORDER BY A.SR_NO}}) that is not already in the next year (BtmSchm.cs:3241 {{SELECT VCH_NO FROM SL_ORD_DETL WHERE CO_CODE}}) is inserted too (:3245). This copies **booked-tag lines of orders that are no longer open** and, because it ignores the `HAVING`, can carry lines of fully adjusted orders (open question 3).
- No arithmetic beyond `Fnv` and the sums above. `SL_ORD_ADJ` itself is not carried (BtmSchm.cs index: read only).

### E. Approval (BtnApr, BtmSchm.cs:4116-4134 {{DC_Main.RsQry = "Update APR_DETL SET ISU_REC = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code +}} and Rtl_Approval :4135-4650)
1. **Writes in the closing year before copying** (side effects): BtmSchm.cs:4123 {{UPDATE APR_DETL SET ISU_REC = 'N'}} resets every line to "not received", BtmSchm.cs:4124 {{Update APR_DETL SET ISU_REC = 'Y'}} marks lines returned by an `APR RTN` line, a `SALES` line, or a `WH SALES`/rate-cut issue; BtmSchm.cs:4126 {{UPDATE BAR_DETL SET APR_ISU = 'N'}}, then BtmSchm.cs:4127 {{UPDATE BAR_DETL SET BAR_DETL.APR_ISU = 'Y'}} for tags whose approval line is still open (`ISU_REC = 'N'`).
2. `Rtl_AcMast()`, then `Rtl_Approval()`.
3. Selection: BtmSchm.cs:4142 {{B.MAIN_BOOK = 'APR ISU' AND ISU_REC = 'N'}}: approval issue lines that are still out. Each line is copied into the next year's `APR_DETL` with its **original** `CO_YEAR`, `CO_BOOK`, `VCH_NO`, `SR_NO` (BtmSchm.cs:4154 {{object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.Concatenate}} values), its `APR_IDTL` stones (:4286 read, :4291 insert), and a **tag stock line** in the next year's `BAR_DETL`/`BAR_IDTL` in book `218` (the "approval tag" book): BtmSchm.cs:4388 {{'218','00001'}} and BtmSchm.cs:4551 {{'218','00001'}}, `VCH_TYPE` `APRTG`, `BOOK_NAME` `APR TAG`, dated the day before the next year opens.
4. Note the stock side: the BAR_DETL line for an approval tag is built from the *current* `BAR_DETL` row of that tag (BtmSchm.cs:4383 {{SELECT * FROM BAR_DETL WHERE CO_CODE}}), and `ITM_PCS`, weights are copied without arithmetic. Because Tag Stock (C) carries only tags with a positive signed balance, whether an approved-out tag is carried by C or by E, or both, is not settled by the form (open question 4).

## Lifecycle and write set

The form has **no create, edit, delete or cancel**. `BtnSave` has no handler; `BtnDelete` is empty (BtmSchm.cs:2720-2723 {{private void BtnDelete_Click(object sender, EventArgs e)}} with an empty body); `BtnCancel` only blanks the form. "Reopen" does not exist: the only way to change a carried dataset is to **run the same button again**.

### Per dataset, in statement order (target = next-year database, `Tr`; source = current database, `Dc`)

**Ac Balance**
1. Dc: UPDATE AC_MAST.AC_MAIN_GR (twice, :2733 and :2763). Dc: UPDATE AC_DATA.DATA_TYPE = 'A' where blank (BtmSchm.cs:2765 {{UPDATE AC_DATA SET DATA_TYPE = 'A' WHERE CO_CODE}}).
2. Tr: UPDATE AC_MAST.LAST_VISIT, VISIT_TRAN per account (:2748).
3. Tr: INSERT AC_MAST for missing codes (:2891 {{INSERT INTO AC_MAST(CO_CODE,AC_CODE,LC_CODE,AC_NAME}}).
4. Tr: DELETE FROM OP_DATA: BtmSchm.cs:2764 {{DELETE FROM OP_DATA WHERE CO_CODE}} (keyed by `CO_CODE` and `LC_CODE`, **all years**, not by `CO_YEAR`).
5. Tr: INSERT OP_DATA, one row per account and `DATA_TYPE`: BtmSchm.cs:2801 {{INSERT INTO OP_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,  OP_AMT,OP_SIGN,FINE_BAL,FINE_SIGN,SL_FINE_BAL,SL_FINE_SIGN,  DATA_TYPE,MAIN_USER,ADD_USER,ADD_DATE,DATA_TRFR)}}.
   The form writes **only `OP_DATA`**; it writes no `AC_DATA` leg in the next year. How an `OP_DATA` row becomes ledger lines of the new year is not in this form (open question 5).

**Item Stock**
1. Tr: INSERT PRODUCT_MAST, GROUP_MAST, TABLE_MAST, ITEM_MAST for missing codes. 2. Dc: AvgTouch updates (ITEM_MAST, GROUP_MAST, BAL_GR). 3. Tr: BtmSchm.cs:2932 {{DELETE FROM ITM_OPBL WHERE CO_CODE}} (by company and location; all years). 4. Tr: INSERT ITM_OPBL, one row per item with stock (BtmSchm.cs:2966 {{INSERT INTO ITM_OPBL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,IT_CODE,VCH_NO,SR_NO,}}).

**Tag Stock**
1. Tr: Rtl_Item inserts. 2. Tr: three deletes limited to the opening day: BtmSchm.cs:2321 {{DELETE FROM BAR_DATA WHERE CO_CODE}}, :2322 BAR_DETL, :2323 BAR_IDTL, each `VCH_DATE = mTrfr_dt - 1 day`. 3. Per item: INSERT BAR_DETL per tag (:2378), INSERT BAR_IDTL (:2520), then INSERT BAR_DATA header (:2627).

**Sales Order**
1. Tr: Rtl_AcMast. 2. Tr: three deletes of **other years' rows**: BtmSchm.cs:3021 {{DELETE FROM SL_ORD_DATA WHERE CO_CODE}} with {{AND CO_YEAR <> '" + tYearCode.Text + "'}}; :3022 SL_ORD_DETL; :3023 SL_ORD_IDTL. 3. Tr: INSERT SL_ORD_DATA (:3048), SL_ORD_DETL (:3137), SL_ORD_IDTL (:3215), then the tag-booking pass SL_ORD_DETL (:3245) and SL_ORD_IDTL (:3324).

**Approval**
1. Dc: ISU_REC and APR_ISU updates (above). 2. Tr: Rtl_AcMast. 3. Tr: BtmSchm.cs:4138 {{DELETE FROM APR_DETL WHERE CO_CODE}} and :4139 APR_IDTL (other years), :4140 BAR_DETL and :4141 BAR_IDTL where `CO_BOOK = '218'`. 4. Tr: INSERT APR_DETL (:4154), APR_IDTL (:4291), BAR_DETL (:4388), BAR_IDTL (:4551).

### Second run (re-run rule)
| Dataset | Second run |
|---|---|
| Ac Balance, party master | OP_DATA is **deleted and rewritten** (BtmSchm.cs:2764 {{ExeQuteTrfr("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE =}}). AC_MAST rows already there are left alone, LAST_VISIT is re-updated. |
| Item Stock | ITM_OPBL **deleted and rewritten** (:2932); item masters not duplicated (existence check :2269). |
| Tag Stock | rows of the opening day deleted from BAR_DATA/DETL/IDTL (:2321-2323) and rewritten; the voucher counter restarts at `00001` unless the next year has book-000 vouchers, then continues after the highest number (:2338). Tags added to the next year **on other dates** by users are not deleted. |
| Sales Order | all rows whose `CO_YEAR` differs from the next year are deleted and rewritten (:3021-3023); because carried rows keep their *old* `CO_YEAR`, this also removes any carried-over order lines before re-adding them; orders created in the next year itself survive. |
| Approval | APR_DETL/IDTL of other years and BAR rows of book 218 deleted and rewritten. |
No button refuses a second run and none doubles its dataset, **provided each run completes**. Runs are not recorded anywhere in the form (no "already transferred" flag; `DATA_TRFR` is a column written on the new rows only).

### Transactions
There is **no transaction** in this form: `grep Transaction` finds none, and every write opens, executes and closes its own connection: BtmSchm.cs:2162-2166 {{DC_Main.CnTr.Open();}} ... {{DC_Main.Cmd.ExecuteNonQuery();}} ... {{DC_Main.CnTr.Close();}}; the current-year writes use `ExeQuteDc` the same way (DC_Main.cs:1313-1325 {{public static void ExeQuteDc(string Sql)}}). Every INSERT is auto-committed. An interruption (crash, closed window, SQL error) after the DELETE and before the last INSERT leaves **half a carry**: for Ac Balance, `OP_DATA` emptied and partially filled; for Item Stock, `ITM_OPBL` partly filled. The only recovery is to run the same button again (delete-and-rewrite). The Bill Os handler wraps its body in a VB `On Error` emulation (BtmSchm.cs:4854 {{catch (object obj) when (obj is Exception && num3 != 0 && num == 0)}}) which resumes silently after an error.

## Print

None. `BtnPrint` is empty: BtmSchm.cs:2699-2701 {{private void BtnPrint_Click(object sender, EventArgs e)}}. The form index lists 0 report templates. `UserPrint` is read (BtmSchm.cs:1953 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}) but never tested. The packet's "print" requirement has **no desktop authority**; a web Print for this menu would be an invention (open question 6).

## Rights

`USER_SET` is read once at load: BtmSchm.cs:1944 {{Select * From USER_SET WHERE LC_CODE}} with `SUB_MENU` = the menu caption; `FRM_EDIT`, `FRM_DELETE`, `FRM_PRINT` are copied (BtmSchm.cs:1951-1953 {{UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELET}}). The three fields are **never used** afterwards (`grep UserEdit` finds only the declarations at :153-157 and the assignments). So the desktop enforces no per-button rights inside the form; access depends only on the menu being visible to the user. Catalog rights string `C-----` (create only). The web uses `view` for preview and `update` for the writes (`apps/api/src/routes/txn.ts:7985` {{if (!guard(req, reply, 'view')) return;}} and :8008 {{if (!guard(req, reply, 'update')) return;}}), a different right from the catalog's.

## Desktop weaknesses not to port

1. String-built SQL everywhere, including values from the data (apostrophes in names); `Rtl_AcMast` blanks an address when it contains `'` instead of escaping (BtmSchm.cs:2847 {{if (Operators.CompareString(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(r}}).
2. No transaction: partial writes (Lifecycle).
3. Unscoped deletes: `DELETE FROM OP_DATA ... LC_CODE` ignores `CO_YEAR` (BtmSchm.cs:2764 {{ExeQuteTrfr("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE =}}); ITM_OPBL likewise (:2932). The Sales Order delete is scoped by `CO_YEAR <>`, which deletes **every other year**, including carried rows (:3021).
4. Writes into the closing year during a transfer (`AC_DATA.DATA_TYPE`, `AC_MAST.AC_MAIN_GR`, `APR_DETL.ISU_REC`, `BAR_DETL.APR_ISU`, `ITEM_MAST.AVG_*`): a "read-only" close mutates source data (BtmSchm.cs:2765 {{DC_Main.ExeQuteDc("UPDATE AC_DATA SET DATA_TYPE = 'A' WHERE CO_CODE = '" + DC_Main.MCo_cod}}, :4123-4127, :2931).
5. Item-stock skip test sums signed values (BtmSchm.cs:2964 {{if (Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ClWtGr"])) + Conve}}): offsetting pcs and weight are lost.
6. Tag carry uses `SUM(±VCH_SRNO)` as a counter (BtmSchm.cs:2358 {{DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END)}}).
7. Order tag-booking pass ignores the "still open" test (BtmSchm.cs:3226 {{DC_Main.RsQry = "SELECT A.*,B.BOOK_SNAME,B.MAIN_BOOK,B.BOOK_INOUT FROM SL_ORD_DETL AS A LE}}).
8. Buttons stay enabled with no next year or after Cancel blanks `tYearCode` (BtmSchm.cs:2142 {{Interaction.MsgBox((object)"There Are Not Found New Year Please Creat New Year And Try....}}, :2705); writers then run with `''`.
9. No result checking: "Process Are Complete...." is shown unconditionally (BtmSchm.cs:2755 {{Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);}}).
10. A `DataTable` filter built from the account code (`dataView.RowFilter = "AC_CODE = " + code`, BtmSchm.cs:2840 {{if (dataView.Count == 0)}} region) is unquoted: a non-numeric code would be a filter error.
11. `On Error Resume` pattern in Bill Os (BtmSchm.cs:4854 {{catch (object obj) when (obj is Exception && num3 != 0 && num == 0)}}).

## Web today

- `apps/web/app/(app)/company/balance-transfer/page.tsx` (326 lines): From Year and To Year inputs (defaults: session year and year+1), buttons `Preview Ac Balance`, `Transfer Ac Balance`, `Carry Party Openings`, and a list of links to other pages (Year-End Close, Year Create, Data Refresh, Tag Stock, Sales Order, Dhiran, Loan Issue, MFG Issue). It uses `window.confirm` texts of its own (page.tsx:121-123, :154-156), not the desktop confirmation.
- `apps/api/src/routes/txn.ts:7984-8021`: `POST /balance-transfer/preview|year-close|openings` (the year-close/preview pair delegates to `yearEnd.ts`; openings delegates to `masters/year.ts carryForwardOpenings`). Also the older `POST /year-end/preview|close`.
- `apps/api/src/modules/ops/yearEnd.ts` (280 lines): `yearEndPreview`, `yearEndClose`. Reads `AC_DATA` of the From Year **for every account**, no group filter and no date filter: yearEnd.ts:126 {{WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2 AND coalesce("CO_BOOK"::text,'') <> $3}}. Net = ΣDR − ΣCR (debit-positive): yearEnd.ts:121-122 {{coalesce(sum(${NN('"DR_AMT"')}),0) AS dr,}}. Fine = signed `FINE_WT`: yearEnd.ts:118 {{CASE WHEN "SIGN"::text='C' THEN -}}. Skips zeros: yearEnd.ts:141 {{if (Math.abs(balance) <= 0.005 && Math.abs(fineWt) <= 0.0005) continue;}}. Deletes the To Year `ACOP` / book `000` rows (yearEnd.ts:255-262) then writes **one `AC_DATA` leg per account** with `VCH_TYPE 'ACOP'`, `CO_BOOK '000'`, `VCH_NO '1'` (yearEnd.ts:268), in one transaction (`withTxBudget`, yearEnd.ts:250). Reports `closingStockFine` but writes **no stock**.
- `apps/api/src/modules/masters/year.ts:119` `carryForwardOpenings`: deletes `OP_DATA` of the To Year and `AC_DATA` legs of book `000` / `TR_AC_OPBL`, reads `AC_DATA` of the From Year per `AC_CODE`, and writes each party through the Party Opening writer `writePartyOpeningTx` (the desktop Party Opening, not BtmSchm). One transaction.
- Tests: `apps/api/test/yearEndCarry.db.test.ts` (269 lines, 10 tests listed by name: carry as ΣDR−ΣCR, book 000 / ACOP, zero accounts excluded, idempotent, correction re-run, book 999 excluded, metal fine, reads only the From Year, preview writes nothing, From = To refused, self-balancing). `partyOpening.db.test.ts`, `itemOpening.db.test.ts`, `tagOpeningRoundTrip.db.test.ts` and `tagOpeningStock.db.test.ts` test the *opening screens*, not the transfer. No test of `carryForwardOpenings` was found by name, and no browser module under `apps/web/test/features/modules/` mentions the menu (search found only the page itself).
- Item, tag, order and approval datasets have **no web endpoint** under this menu. The page links to other screens instead.

## Gaps

1. **Wrong source rows (Ac Balance, wrong result).** Desktop closes only parties: BtmSchm.cs:2786 {{B.AC_MAIN_GR < '3' and VCH_DATE <=}}, to the closing date, at location `LC_CODE`. `yearEnd.ts:126` takes **all** accounts, all dates and ignores `LC_CODE`; `carryForwardOpenings` (year.ts:141-144) also takes all accounts and all dates and no `AC_MAIN_GR` filter. Wrong result for non-party accounts, post-closing-date vouchers and multi-location companies.
2. **Wrong target (Ac Balance).** Desktop writes `OP_DATA` only (BtmSchm.cs:2801 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObje}}). `yearEnd.ts:268` writes `AC_DATA` `ACOP` legs, a table the desktop form never writes in this step; `carryForwardOpenings` writes `OP_DATA` **and** `AC_DATA` legs through Party Opening. The two web buttons write different tables for the same menu button, and run together they can put the same balance twice in the To Year (an `ACOP` leg and a `TR_AC_OPBL` leg, both book `000`). Wrong result / double count. A decision is needed on which one is the Ac Balance button.
3. **Grouping by `DATA_TYPE` missing (wrong result).** Desktop writes one opening per account and `DATA_TYPE` (BtmSchm.cs:2786 {{GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE}}); web groups by `AC_CODE` only (year.ts:143, yearEnd.ts:127).
4. **Metal rules (wrong result).** Desktop: gold and silver closing from `IT_TYPE` `G`/`S` only, `'+'` sign positive means Cr (BtmSchm.cs:2786 {{iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)}}), sign `C` when > 0 else `D`. `yearEnd.ts` adds `FINE_WT` of **any** item type into one number with one metal type (`max(IT_TYPE)`), so an account with both gold and silver loses one (yearEnd.ts:118, :124); also its sign test uses `SIGN='C'` while desktop uses `'+'` (yearEnd.ts:118 vs BtmSchm.cs:2796 {{while (DC_Main.M < DC_Main.Rshlp.Rows.Count)}}). `carryForwardOpenings` matches the desktop's `+` convention but gives sign `C` when gold = 0 (year.ts:163 {{goldSign: gold >= 0 ? 'C' : 'D',}}), while desktop gives `D` for a zero value (BtmSchm.cs:2801 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObje}}). Wrong sign on zero.
5. **Rounding (wrong result).** Desktop rounds by `format 0.00 / 0.000` on the grouped sum (BtmSchm.cs:2786 {{format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount}}); web uses `Math.round(x*100)/100` on JS floats (yearEnd.ts:47 {{const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;}}). Half-cases may differ; to be pinned by a vector.
6. **Skip rule (wrong result).** Desktop skips a party when |amount|+|gold|+|silver| = 0 (BtmSchm.cs:2799 {{if (Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["Amount"])}}). Web skips on `balance` and `fine` separately (yearEnd.ts:141) with a tolerance of 0.005 / 0.0005 that the desktop does not have; `carryForwardOpenings` uses exact zero after rounding (acceptable match).
7. **Delete scope (wrong result).** Desktop deletes `OP_DATA` by company and location, all years (BtmSchm.cs:2764 {{ExeQuteTrfr("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE =}}); web deletes by `CO_YEAR = toYear` (year.ts:128-131). Different; the desktop one removes openings of other years: do **not** port, but record the difference.
8. **Account master (missing feature).** Desktop copies missing `AC_MAST` rows and updates `LAST_VISIT`/`VISIT_TRAN` (BtmSchm.cs:2813 {{private void Rtl_AcMast()}}, :2743). Web has no account master carry (the web has one database for all years; confirm whether any carry is needed, open question 7).
9. **Item Stock (missing feature).** Desktop writes `ITM_OPBL` from `MAIN_STOCK` untagged stock to the closing date, with fine = net x touch / 100 to 3 decimals (BtmSchm.cs:2960 {{num = Conversions.ToDouble(Strings.Format((object)Conversion.Val((object)(num5 * num6 / 10}}). No web code, endpoint or button; `yearEnd.ts` only *reports* `closingStockFine` (yearEnd.ts:161-178) from `ITM_FINE` of all stock, tagged and untagged, which is not the opening that the desktop writes.
10. **Tag Stock (missing feature).** Desktop re-inserts every on-hand tag into the next year at the opening-day-minus-one date (BtmSchm.cs:2378 {{object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.Concatenate}}). No web code. The web's tag opening is a separate screen.
11. **Sales Order (missing feature).** Desktop carries open orders with adjusted-so-far figures (BtmSchm.cs:3024 {{DC_Main.RsQry = "SELECT A.AC_CODE,A.VCH_DATE,A.VCH_NO,A.ADV_AMT,SUM(CASE WHEN B.ORD_SIGN =}}). No web code; the page only links to the Sales Order page (page.tsx:70).
12. **Approval (missing feature).** Desktop carries open approval issues and writes their tag lines to book `218` (BtmSchm.cs:4142 {{DC_Main.RsQry = "SELECT A.* FROM APR_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.C}}, :4388). No web code.
13. **Confirmation text (wrong text).** Desktop: BtmSchm.cs:2729 {{Are You Sure To Data Transfer to Next Year ?}}; web uses its own long text (page.tsx:121-123) and no completion text `Process Are Complete....`; the page shows its own count message (page.tsx:136).
14. **No-year message (missing).** Desktop shows BtmSchm.cs:2142 {{There Are Not Found New Year Please Creat New Year And Try....}}; web shows only `To Year must differ from From Year.` / required messages (page.tsx:90-114), and lets the operator type any year. The desktop picks the next year from `YEAR_MAST` (BtmSchm.cs:2091 {{DC_Main.RsQry = "SELECT * FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO}}); web guesses `year + 1` (page.tsx:45-48).
15. **Interruption recovery (missing feature, different design).** Desktop has none (half carry possible); web runs each button in one transaction (yearEnd.ts:250, year.ts:126), which is better and must be kept. The packet's "interruption recovery" requirement is therefore *stronger* than the desktop, not a port of it. Whether the five datasets run as one or five transactions is a decision for the next worker.
16. **Closing-year side effects (not ported).** The web does not run the writes into the closing year (weakness 4). A business consequence: `APR_DETL.ISU_REC` and `BAR_DETL.APR_ISU` recomputation (BtmSchm.cs:4123-4127 {{DC_Main.RsQry = "Update APR_DETL SET ISU_REC = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code +}}) would be needed before an approval carry; do it as a computation, not as a write to the closed year.
17. **Print (no authority).** No print on the desktop; the web has none. Not a gap unless the owner decides otherwise.
18. **Rights (wrong right).** Catalog `C-----` (create); web guard uses `view`/`update` (txn.ts:7985, :8008).
19. **Keyboard (missing key).** Esc closes the form (BtmSchm.cs:2692-2695 {{//IL_0009: Invalid comparison between Unknown and I4}}); the web page has no Esc handler (searched `page.tsx` for `Escape`: none). Upper-casing of typed characters (BtmSchm.cs:2674-2688 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}) is not applied.
20. **Non-Lite buttons.** Dhiran, Loan, Scheme, Bill Os, etc. are not in the web page; they are out of scope until their menus' editions are in scope (the page lists three of them as links, page.tsx:74-76).
21. **Identity test missing.** There is no test that closing(year N) = opening(year N+1) for any dataset; `yearEndCarry.db.test.ts` checks only the web's own ΣDR−ΣCR and self-balancing.

## Open questions

1. Can a Lite company have `MsMfgType` `J`/`M` or `MsOsBillOrnaIsu` `N`? (MS_OPNCOMP.cs:4906-4929 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VS127NSVS", false) == 0)}} sets it from the registration serial, an edition-independent rule I did not trace to the end.) This decides whether `lblJadtarTrfr`, `btnMfgTrfr`, `btnBillOrnaIsu` can appear in Lite.
2. Is `tYearCode` editable at run time? The designer shows no `ReadOnly`, but lines 1379-1384 are the only ones read; the designer ranges 955-1928 were not read in full.
3. Does the second "Order Tag Booking" pass (BtmSchm.cs:3226-3335 {{object obj40 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.Concatena}}) intentionally carry detail lines of closed orders? Only a data run on the isolated database would show it.
4. Does an approved-out tag appear in both Tag Stock and Approval carries? Depends on whether `MAIN_STOCK` holds an out-movement for an approval issue (Ac_Stock was not read).
5. Which routine turns `OP_DATA` and `ITM_OPBL` of the new year into the opening ledger/stock of the new year (year open, `Ac_Ledr`, `Ac_Stock`)? Not read; needed to define "closing(N) = opening(N+1)" on `AC_DATA`.
6. Is a web Print wanted for this menu? The desktop has none.
7. In the web, a year is a column value in one database; does carrying need `AC_MAST`/`ITEM_MAST` copies at all? Owner decision (Year Create, WP-22, may settle this).
8. BtmSchm.cs ranges not read in full: the second halves of the insert column lists for `BAR_DETL` (:2378), `SL_ORD_DETL` (:3137), `APR_DETL` (:4154) and `APR_IDTL` (:4291), and `Rtl_Scheme`, `Rtl_Dhrn`, `Rtl_Loan` (:3349-4115). The next worker must read the exact value lists before writing the column-by-column test vectors.
