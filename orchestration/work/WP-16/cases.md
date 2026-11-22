# WP-16 cases: Report → Stock Report (desktop `RP_STOCK`)

Frozen case list for the menu, built from `orchestration/work/WP-16/study.md` (17 gaps) and the supervisor's decisions.
Desktop files are in `unified/src/csharp/DataCareNext/`. Citation form: `File.cs:N {{text copied from the line}}`.
The module name for case ids is `stock-report`. The route is `/reports/stock-report`, the nav caption "Stock Report".
Every case fails today: the web has no Stock Report route, so each case names the gap(s) it proves.

## 0. How the figures are worked out

**One source.** Every figure is the sum of signed `MAIN_STOCK` movements for the company, location (LC) and year. Opening is
`VCH_DATE < FROM`; Purchase `+`/`P`, Inward `+`/`I`, Outward `-`/`O`, Sale `-`/`S` fall in `FROM..TO`; hidden Transfer in `+`/`T` and
out `-`/`T` fall in `FROM..TO`; Closing is every signed movement with `VCH_DATE <= TO`
(`RP_STOCK.cs:4284 {{AS ClPcs}}`; the signed form is `RP_STOCK.cs:4284 {{THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END)}}`).
Weight basis: unchecked "Gross Wise Weight" is net, checked is gross (`RP_STOCK.cs:4280 {{string text2 = ((!chkWtType.Checked) ? "A.ITM_NWT" : "A.ITM_GWT");}}`).
Identity asserted on every row and on the "Total :" row (hidden transfer columns included):
`Closing = Opening + Purchase + Inward − Outward − Sale + TransferIn − TransferOut`.

**What each real screen writes** (the `TR_TYPE`/sign each case relies on, from `Ac_Stock.cs`):
- Item Opening: dated the day before the year opening date, loose (`TAG_NO` = `N`), counter blank, `TR_TYPE` `P` `+`:
  `Ac_Stock.cs:15 {{'ITOBL','ITM OPBL','00000',A.IT_CODE,'N',0,'','P','+'}}` and `Ac_Stock.cs:15 {{Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy")}}`.
- Tag Opening (book OPSTK): `TR_TYPE` `P` `+`, VCH_TYPE `TAGOP`: `Ac_Stock.cs:28 {{B.MAIN_BOOK IN ('OPSTK','JDTR TAG','MFG TAG')}}`.
- Purchase: `P` `+`, loose: `Ac_Stock.cs:140 {{A.ITM_PCS-A.FINE_CUT_PCS}}`; fine is the line's `ITM_FINE` for both fine columns (`Ac_Stock.cs:140 {{A.ITM_FINE-A.FINE_CUT_FINE}}`).
- Sale of a tag (company type not `P`): `S` `-`, tag number kept, fine from the sale line, karigar fine from the tag:
  `Ac_Stock.cs:114 {{B.MAIN_BOOK IN ('SALES','B2B SALES') AND B.BOOK_INOUT = 'O'}}`.
- Sales Return: the returned line is `I` `+` with both fine columns = the return line's `ITM_FINE`: `Ac_Stock.cs:247 {{FROM  SL_DETL_RTN AS A LEFT JOIN BOOK_DATA AS B}}`.
- Purchase Return: `O` `-`: `Ac_Stock.cs:331 {{FROM  PR_DETL AS A LEFT JOIN BOOK_DATA AS B}}`.
- Stock Adjust and Tag Cancel (one writer): `Ac_Stock.cs:54 {{CASE WHEN A.ITM_SIGN = '+' THEN 'I' ELSE 'O' END}}`; Tag Cancel is `-`, so `O`.
- Approval Issue (book `APR ISU`): `O` `-`: `Ac_Stock.cs:68 {{B.MAIN_BOOK = 'APR ISU' AND B.BOOK_INOUT = 'O'}}`. Approval Return is `I` `+` (book `APR RTN`).
- Counter Transfer (`T`): `Ac_Stock.cs:543 {{public static void Tag_Counter_trfr_Stk(string StkBook, string StkVchNo)}}` posts it. That menu is not in Lite, so the two `T` rows are seeded by a database fixture.

**Dates.** `Y0` = first day of the fixture year (`MOp_dt`); this list uses `Y0 = 01/04/2026` so `Dn` = `Y0 + n days`:
D5 06/04, D6 07/04, D7 08/04, D10 11/04, D11 12/04, D12 13/04, D14 15/04, D15 16/04, D18 19/04, D20 21/04, D24 25/04, D25 26/04,
D28 29/04, D30 01/05, D33 04/05, D40 11/05. Windows: **W0** default (FROM `Y0`, TO today), **W1** D10..D40 (11/04/2026..11/05/2026),
**W2** D10..D24, **W3** D10..D14. Seed dates must be on or before today; the fixture sets the clock to `Y0 + 60 days` or later.

## 1. Seed (the movement table every figure comes from)

Items (all Item Master rows exist before any voucher). Units: pcs / gross g / net g. Touch 91.6 unless stated.

| Item | Type | Group | Product | Safe | Trading |
|---|---|---|---|---|---|
| A `GOLD RING 22K` | Gold | GR-A `GOLD ORNAMENTS` | PR-A `RING` | MAIN | TR1 `GOLD TRADE` |
| B `GOLD CHAIN 22K` | Gold | GR-A | PR-B `CHAIN` | VAULT | blank (group GR-A carries TR1) |
| S `SILVER BOWL` | Silver | GR-S `SILVER ARTICLES` | PR-S `BOWL` | MAIN | TR2 `SILVER TRADE` |

Counters: 001 `CNT-ONE`, 002 `CNT-TWO`. Parties: SUP1 (supplier), CUS1 (customer).

| # | Day | Screen | Item | Sign/Type | Pcs | Gross | Net | Fine stored (ITM / KR) | Notes |
|---|---|---|---|---|---|---|---|---|---|
| M1 | Y0−1 | Item Opening | A | +/P | 10 | 105.000 | 100.000 | 91.600 / 91.600 | counter blank |
| M2 | Y0−1 | Item Opening | B | +/P | 5 | 52.500 | 50.000 | 45.800 / 45.800 | |
| M3 | Y0−1 | Item Opening | S | +/P | 100 | 1000.000 | 950.000 | 870.200 / 870.200 | touch 91.6 |
| M4 | D5 | Tag Opening T1 | A | +/P | 1 | 12.500 | 12.000 | 10.992 / 10.800 | design D1, karigar touch 90.0 |
| M5 | D6 | Tag Opening T2 | A | +/P | 1 | 6.300 | 6.000 | 5.496 / 5.400 | |
| M6 | D7 | Tag Opening T3 | A | +/P | 1 | 8.400 | 8.000 | 7.328 / 7.200 | |
| M7 | D11 | Tag Opening T4 | A | +/P | 1 | 3.150 | 3.000 | 2.748 / 2.700 | design D1, counter 002 |
| M8 | D12 | Tag Opening T5 | B | +/P | 1 | 21.000 | 20.000 | 18.320 / 18.000 | design D2, size 7 |
| M9 | D12 | Purchase from SUP1 | A | +/P | 4 | 42.000 | 40.000 | 36.800 / 36.800 | touch 92.0, loose |
| M10 | D15 | Sales to CUS1 (tag T1) | A | −/S | 1 | 12.500 | 12.000 | 11.040 / 10.800 | sale touch 92.0 |
| M11 | D18 | Purchase from SUP1 | S | +/P | 10 | 100.000 | 95.000 | 87.400 / 87.400 | touch 92.0 |
| M12 | D20 | Counter transfer (fixture) | B | −/T | 1 | 10.500 | 10.000 | 9.160 / 9.160 | counter 001 |
| M13 | D20 | Counter transfer (fixture) | B | +/T | 1 | 10.500 | 10.000 | 9.160 / 9.160 | counter 002 |
| M14 | D20 | Sales Return from CUS1 (tag T1) | A | +/I | 1 | 12.500 | 12.000 | 11.040 / 11.040 | |
| M15 | D25 | Purchase Return to SUP1 | A | −/O | 2 | 21.000 | 20.000 | 18.400 / 18.400 | |
| M16 | D28 | Stock Adjust plus (loose) | A | +/I | 1 | 5.250 | 5.000 | 4.580 / 4.580 | |
| M17 | D28 | Stock Adjust minus (loose) | A | −/O | 1 | 2.100 | 2.000 | 1.832 / 1.832 | |
| M18 | D30 | Tag Cancel T2 | A | −/O | 1 | 6.300 | 6.000 | 5.496 / 5.400 | |
| M19 | D33 | Approval Issue to CUS1 (tag T3) | A | −/O | 1 | 8.400 | 8.000 | 7.328 / 7.200 | |

Fine values are the stored `ITM_FINE`/`KR_FINE` of each row (net × touch / 100; karigar touch 90.0 where two values are shown). The expected
values below read them as inputs; where the screen computes a different stored value the case compares to the persisted row, and the
fine difference being asserted (KR vs ITM) still holds because it is seeded.

### Worked figures (net basis, W1 = D10..D40). Gross shown in brackets.

| Item | Opening | Purchase | Inward | Outward | Sale | Closing |
|---|---|---|---|---|---|---|
| A | 13 / 126.000 (132.200) | 5 / 43.000 (45.150) | 2 / 17.000 (17.750) | 5 / 36.000 (37.800) | 1 / 12.000 (12.500) | 14 / 138.000 (144.800) |
| B | 5 / 50.000 (52.500) | 1 / 20.000 (21.000) | 0 | 0 | 0 | 6 / 70.000 (73.500) |
| S | 100 / 950.000 (1000.000) | 10 / 95.000 (100.000) | 0 | 0 | 0 | 110 / 1045.000 (1100.000) |

Arithmetic, item A: Opening = M1 10/100.000 + M4 1/12.000 + M5 1/6.000 + M6 1/8.000 = 13 pcs, 126.000 net; gross 105.000 + 12.500 + 6.300 + 8.400 = 132.200.
Purchase = M7 1/3.000 + M9 4/40.000 = 5/43.000. Inward = M14 1/12.000 + M16 1/5.000 = 2/17.000. Outward = M15 2/20.000 + M17 1/2.000 + M18 1/6.000 +
M19 1/8.000 = 5/36.000. Sale = M10 1/12.000. Closing = 13+5+2−5−1 = 14 pcs; 126+43+17−36−12 = 138.000. Independent check by tag: M1 100 + T1 (12−12+12 = 12)
+ T2 (6−6 = 0) + T3 (8−8 = 0) + T4 3 + M9 40 + net adjust (5−2 = 3) − M15 20 = 138.000 ✓. Gross: 132.200+45.150+17.750−37.800−12.500 = 144.800.
Item B: Closing = 5+1 = 6 pcs; 50+20 = 70.000 (transfer in and out cancel). Item S: Closing = 100+10 = 110; 950+95 = 1045.000.

**Item dimension "Total :" row, Item Type blank, W1:** Opening 118 / 1126.000 (gross 1184.700); Purchase 16 / 158.000 (166.150); Inward 2 / 17.000 (17.750);
Outward 5 / 36.000 (37.800); Sale 1 / 12.000 (12.500); hidden TransferIn 1 / 10.000 and TransferOut 1 / 10.000; Closing 130 / 1253.000 (1318.300).
Check: 118+16+2−5−1+1−1 = 130; 1126+158+17−36−12+10−10 = 1253; gross 1184.700+166.150+17.750−37.800−12.500 = 1318.300.
**Gold only (Item Type Gold), W1:** Opening 18 / 176.000; Purchase 6 / 63.000; Inward 2 / 17.000; Outward 5 / 36.000; Sale 1 / 12.000; Closing 20 / 208.000.
**W0 (FROM Y0, TO today), item A, Gold:** Opening 10 / 100.000 (only M1 is dated before `Y0`); Purchase 8 / 69.000 (M4 12 + M5 6 + M6 8 + M7 3 + M9 40);
Inward 2 / 17.000; Outward 5 / 36.000; Sale 1 / 12.000; Closing 10+8+2−5−1 = 14 / 100+69+17−36−12 = 138.000. Tag Opening in the window is a purchase-in
(`P`), which is why it is not Opening here.
**W2 (D10..D24), item A:** Opening 13 / 126.000; Purchase 5 / 43.000; Inward 1 / 12.000; Outward 0; Sale 1 / 12.000; Closing 13+5+1−1 = 18 / 126+43+12−12 = 169.000 (gross 177.350).

## 2. Cases

Status key: `executable`, `blocked: <reason>`, `N/A: <reason>`. "Gap n" names the study gap (1 to 17) the case proves. Every case also asserts that the
report wrote nothing (no `UPDATE`, `INSERT` or `DELETE` appears in the request's statement log), because desktop weaknesses 2 and 3 are not ported.

### T01 Entry and defaults

### stock-report.entry.route-and-caption   (T01 Entry/defaults)
Layer: browser
Steps: 1. Sign in as a user with the Stock Report View right. 2. Open the Report menu. 3. Read the caption list and click "Stock Report".
Expected: gap 1, 17. The nav shows the caption "Stock Report" (not "Tag-Stock Report") and the click opens `/reports/stock-report`
(desktop: `MDI_FORM.cs:8881 {{case "Stock Report":}}` creates `MDI_FORM.cs:8883 {{RP_STOCK rP_STOCK = new RP_STOCK();}}`). The window title is the caption plus the open-form count
(`MDI_FORM.cs:8886 {{((Form)rP_STOCK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);}}`). Fails today: no route, no caption.
Status: executable

### stock-report.entry.tag-stock-stays-separate   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open Report → Tag Stock. 2. Open Report → Stock Report in a second tab.
Expected: gap 1. `/reports/tag-stock` still opens the Tag Stock screen (desktop form `RP_TAG`, `MDI_FORM.cs` has its own `case "Tag Stock":`); `/reports/stock-report` opens the Stock Report;
the two share no grid. The rights key of the Stock Report is its own (catalog rights string `----PL`: View, Print, List).
Status: executable

### stock-report.entry.default-fields   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the screen with default settings (company metal Gold, `STK_RPT_TYPE` = N, no LC box). 2. Read every control before pressing anything.
Expected: gap 3, 4, 5. From date = year opening date (`RP_STOCK.cs:3705 {{mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);}}`); To date = system date
(`RP_STOCK.cs:3706 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}`); Item Type = Gold (`RP_STOCK.cs:3628 {{if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)}}`);
Stock Type = All; Gross Wise Weight unchecked (`RP_STOCK.cs:3647 {{if (Operators.CompareString(DC_Main.MsStkRptType, "G", false) == 0)}}` is false for N); eight dimension buttons Item, Product, Group, Design, Safe, Counter, Trading, Size;
the grid is empty until a button is pressed; focus on the From date.
Status: executable

### stock-report.entry.default-gross-from-setting   (T01 Entry/defaults)
Layer: browser
Steps: 1. Set `STK_RPT_TYPE` = G in company settings. 2. Open the screen.
Expected: gap 5, 16. "Gross Wise Weight" is ticked on open (`RP_STOCK.cs:3647 {{if (Operators.CompareString(DC_Main.MsStkRptType, "G", false) == 0)}}`); pressing Item with W1 shows item A Closing gross 144.800.
Status: executable

### stock-report.entry.item-type-default-silver   (T01 Entry/defaults)
Layer: browser
Steps: 1. Company metal type = Silver (`MsMetalType` not G). 2. Open the screen.
Expected: gap 16. Item Type defaults to Silver (the `else` of `RP_STOCK.cs:3628 {{if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)}}`); pressing Item shows only item S.
Status: executable

### stock-report.entry.item-type-list   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the Item Type list.
Expected: gap 4. Items in order: blank, Gold, Silver, Diamond, Real Stone, Emitation, Other, Platinum (`RP_STOCK.cs:3620-3627 {{cboItemTyp.Items.Add}}`; the first letter is the filter, `RP_STOCK.cs:4303 {{"AND  B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"}}`).
Status: executable

### stock-report.entry.future-dated-warning   (T01 Entry/defaults)
Layer: browser
Steps: 1. Seed one movement dated tomorrow (book "Sales" voucher 000045, fixture insert). 2. Open the screen.
Expected: gap 3, 14. A message box `Please Check Voucher Date in Entry Because Entry Date > Curent Date... Book = <book name> And VchNo = <voucher number>....`
(`RP_STOCK.cs:3713 {{Please Check Voucher Date in Entry Because Entry Date > Curent Date... Book = }}`, tail `RP_STOCK.cs:3713 {{(object)" And VchNo = "}}`); the To date becomes the voucher's date and focus is on the From date.
With no future-dated row there is no message.
Status: executable

### stock-report.entry.f3-shortcut   (T01 Entry/defaults)
Layer: browser
Steps: 1. From any screen press F3. 2. Repeat with a user whose Stock Report View right is revoked.
Expected: gap 1, 14. F3 opens the Stock Report (`MDI_FORM.cs:5574 {{"F3     Stock Report "}}`); the window title uses the rights key "Stock Report" (`MDI_FORM.cs:13962 {{((Form)rP_STOCK).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);}}`).
Without the View right the message is exactly `You Have No Rights.....` (`MDI_FORM.cs:13952 {{You Have No Rights.....}}`, five dots) and the screen does not open.
Status: executable

### stock-report.entry.menu-needs-view-right   (T01 Entry/defaults; T11 Scope/rights)
Layer: browser
Steps: 1. Revoke View on "Stock Report" for a user. 2. Click Report → Stock Report. 3. Grant View and click again.
Expected: gap 1, 14. Message `You Have No Rights.....` (`MDI_FORM.cs:7047 {{You Have No Rights.....}}`), five dots, screen stays closed; the check selects the user's rights row with the extra condition
`MDI_FORM.cs:7041 {{AND FRM_VIEW = 'Y'}}` before dispatching `MDI_FORM.cs:7070 {{Report_Form();}}`. With View granted the screen opens.
Status: executable

### T02 Field route (each filter)

### stock-report.filter.date-range   (T02 Field route)
Layer: browser
Steps: 1. Press Item with W1. 2. Change To to D24 (W2). 3. Press Item.
Expected: gap 3. W1 item A row is 13 / 126.000, 5 / 43.000, 2 / 17.000, 5 / 36.000, 1 / 12.000, 14 / 138.000. W2 row is 13 / 126.000, 5 / 43.000, 1 / 12.000, (outward blank), 1 / 12.000, 18 / 169.000.
Movements after TO (M15 to M19) leave the row; movements before FROM only move to Opening. The Closing has no lower bound (`RP_STOCK.cs:4284 {{AS ClPcs}}`).
Status: executable

### stock-report.filter.from-after-to   (T02 Field route; T06 Required/invalid)
Layer: browser
Steps: 1. From = D40, To = D10. 2. Press Item.
Expected: gap 3. There is no from/to check and no message; an empty middle range leaves the grid with rows (`RP_STOCK.cs:4712 {{if (dataView.Count <= 0)}}` is only for a result with no rows).
Gold rows A and B: Opening = every movement before D40 = 20 pcs / 208.000 (A 14 / 138.000, B 6 / 70.000); Purchase, Inward, Outward and Sale blank, because `FROM <= VCH_DATE <= TO` has no date; Closing = movements up to D10 = 18 / 176.000 (A 13 / 126.000 from M1, M4, M5, M6; B 5 / 50.000 from M2).
No crash, no message.
Status: executable

### stock-report.filter.item-type   (T02 Field route)
Layer: browser
Steps: 1. W1, Item Type blank, press Item. 2. Item Type = Gold, press Item. 3. Item Type = Silver, press Item.
Expected: gap 4. Blank: three rows (B, A, S) ordered by name `GOLD CHAIN 22K`, `GOLD RING 22K`, `SILVER BOWL` (`RP_STOCK.cs:4427 {{GROUP BY B.IT_CODE,B.IT_NAME,B.IT_TYPE ORDER BY B.IT_NAME}}`). Gold: rows B and A, Total Closing 20 / 208.000. Silver: row S, Closing 110 / 1045.000.
Status: executable

### stock-report.filter.stock-type-tag-item   (T02 Field route)
Layer: browser
Steps: 1. W2, Item Type Gold, Item dimension, Stock Type All, Tag, then Item. Read item A's row each time.
Expected: gap 4. Tag (`RP_STOCK.cs:4287 {{DC_Main.RsQry += "AND A.TAG_NO <> 'N'";}}`): Opening 3 / 26.000 (T1 12 + T2 6 + T3 8); Purchase 1 / 3.000 (T4); Inward 1 / 12.000; Sale 1 / 12.000; Closing 3+1+1−1 = 4 / 26+3+12−12 = 29.000.
Item (`RP_STOCK.cs:4291 {{DC_Main.RsQry += "AND A.TAG_NO = 'N'";}}`): Opening 10 / 100.000 (M1); Purchase 4 / 40.000 (M9); Closing 14 / 140.000. All: 13 / 126.000 ... 18 / 169.000. Tag + Item = All in every column (4+14 = 18; 29+140 = 169).
Status: executable

### stock-report.filter.account   (T02 Field route)
Layer: browser
Steps: 1. W1, Item Type blank, AcCode = CUS1, Item dimension. 2. AcCode = SUP1.
Expected: gap 4. Rule `RP_STOCK.cs:4295 {{"AND A.AC_CODE =  '" + tAcCode.Text + "'"}}`. CUS1: only A, Opening 0, Inward 1 / 12.000 (M14), Outward 1 / 8.000 (M19), Sale 1 / 12.000 (M10), Closing 1−1−1 = −1 pcs / 12−8−12 = −8.000 (gross 12.500−8.400−12.500 = −8.400); negative figures are shown with their sign.
SUP1: A Purchase 4 / 40.000 (M9), Outward 2 / 20.000 (M15), Closing 2 / 20.000; S Purchase 10 / 95.000, Closing 10 / 95.000.
Status: executable

### stock-report.filter.tag-number   (T02 Field route)
Layer: browser
Steps: 1. W1, TagNo = T1, Item dimension.
Expected: gap 4. Rule `RP_STOCK.cs:4299 {{"AND A.TAG_NO =  '" + tTagNo.Text + "'"}}`. One row, item A: Opening 1 / 12.000 (M4), Inward 1 / 12.000 (M14), Sale 1 / 12.000 (M10), Closing 1+1−1 = 1 / 12.000. Purchase and Outward blank.
Status: executable

### stock-report.filter.item-code   (T02 Field route)
Layer: browser
Steps: 1. W1, It Code = B's code, Group dimension.
Expected: gap 4. Rule `RP_STOCK.cs:4315 {{"AND A.IT_CODE =  '" + tItCode.Text + "'"}}`. One group row `GOLD ORNAMENTS`: Opening 5 / 50.000, Purchase 1 / 20.000, Closing 6 / 70.000 (not 20 / 208.000).
Status: executable

### stock-report.filter.product-group   (T02 Field route)
Layer: browser
Steps: 1. W1, Pr Code = PR-B, Item dimension. 2. Clear it, Gr Code = GR-S, Item dimension.
Expected: gap 4. Rules `RP_STOCK.cs:4307 {{"AND B.PR_CODE =  '" + tPrCode.Text + "'"}}` and `RP_STOCK.cs:4311 {{"AND B.GR_CODE =  '" + tGrCode.Text + "'"}}`. PR-B: only B (5 / 50.000 → 6 / 70.000). GR-S: only S (100 / 950.000 → 110 / 1045.000).
Status: executable

### stock-report.filter.design   (T02 Field route)
Layer: browser
Steps: 1. W3 (D10..D14), Item Type Gold, Design = D1, Item dimension.
Expected: gap 4. Rule `RP_STOCK.cs:4319 {{"AND A.DESIGN_NO =  '" + tDesignNo.Text + "'"}}`. Row A: Opening 1 / 12.000 (M4), Purchase 1 / 3.000 (M7), Closing 2 / 15.000. B (design D2) absent.
Status: executable

### stock-report.filter.safe   (T02 Field route)
Layer: browser
Steps: 1. W1, Item Type Gold, Safe = VAULT, Item dimension.
Expected: gap 4. Rule `RP_STOCK.cs:4323 {{"AND B.SAFE_NAME =  '" + cboSafe.Text + "'"}}`. Only B: 5 / 50.000, 1 / 20.000, Closing 6 / 70.000. The Safe list is the distinct safe names with a blank first entry (MAIN, VAULT).
Status: executable

### stock-report.filter.counter   (T02 Field route)
Layer: browser
Steps: 1. W1, Item Type blank, Counter = CNT-TWO, Item dimension.
Expected: gap 4. Rule `RP_STOCK.cs:4327 {{"AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'"}}`. Row A: Purchase 1 / 3.000 (M7), Closing 1 / 3.000. Row B: Purchase 0, hidden TransferIn 1 / 10.000 (M13), Closing 1 / 10.000. No other row.
Status: executable

### stock-report.filter.lc-default-and-isolation   (T02 Field route; T11 Scope/rights)
Layer: database
Steps: 1. Seed a second location (LC2) with an item-A opening of 999 pcs. 2. Run W1 for the current location with the LC box hidden.
Expected: gap 4. The LC filter is applied even while hidden: `RP_STOCK.cs:3692 {{tLcCode.Text = DC_Main.MLc_code;}}` and `RP_STOCK.cs:4284 {{A.LC_CODE = '}}`; LC2 figures never appear; item A Opening stays 13 / 126.000.
Status: executable

### stock-report.filter.gross-check-box   (T02 Field route; T03 Formula)
Layer: browser
Steps: 1. W1, Item dimension, unchecked. 2. Tick Gross Wise Weight. 3. Press Item again.
Expected: gap 5. After ticking, the grid is NOT refreshed (`RP_STOCK.cs:5710 {{private void chkWtType_Click(object sender, EventArgs e)}}`
only clears an open drill-down and does not refill the summary); the old net figures stay. After the second Item press every weight column is gross:
A Opening 132.200, Purchase 45.150, Inward 17.750, Outward 37.800, Sale 12.500, Closing 144.800; pieces unchanged. Weight columns display three decimals (`RP_STOCK.cs:4757 {{DefaultCellStyle.Format = "N3"}}`).
Status: executable

### stock-report.filter.item-name-search   (T02 Field route)
Layer: browser
Steps: 1. W1, Item dimension, type `RING` in the search box. 2. Type `ZZZ`. 3. Clear the box. 4. Type `O'BR`.
Expected: gap 11. `RING` leaves only `GOLD RING 22K` (rule `RP_STOCK.cs:3837 {{dataView.RowFilter = "Name Like  '%" + ((TextEdit)tSerchAll).Text + "%' ";}}`); `ZZZ` leaves an empty grid; clearing refills all rows (`DGV_FILL()` on empty text); the apostrophe input is treated as text by the web (parameterised) and returns an empty grid with no error (desktop weakness 9).
Status: executable

### stock-report.filter.sql-metacharacters   (T02 Field route; T06 Required/invalid)
Layer: database
Steps: 1. Send the tag filter `' OR '1'='1` and the account filter `X'; DROP TABLE "MAIN_STOCK";--` to the API.
Expected: gap 4. Both return an empty result (no rows match such a tag/account); the table is intact; the statement log shows bound parameters, not a joined string (desktop `RP_STOCK.cs:4295 {{"AND A.AC_CODE =  '" + tAcCode.Text + "'"}}` is the weakness not ported).
Status: executable

### T03 Formula sequence (columns, dimensions, totals)

### stock-report.formula.item-dimension-w1   (T03 Formula sequence)
Layer: browser
Steps: 1. W1, Item Type blank, press Item.
Expected: gap 2, 3, 6. Rows in order `GOLD CHAIN 22K`, `GOLD RING 22K`, `SILVER BOWL` with the figures of the worked table (B 5/50.000, 1/20.000, closing 6/70.000; A 13/126.000 … 14/138.000; S 100/950.000, 10/95.000, closing 110/1045.000).
Columns SrNo 1..3, Item Name, OpPcs OpWt PrPcs PrWt InPcs InWt OuPcs OuWt SlPcs SlWt ClPcs ClWt (`RP_STOCK.cs:4727 {{((DataGridView)DGV).ColumnCount = 22;}}`; hidden code, item type and four transfer columns). Zeros display blank (`RP_STOCK.cs:3790 {{((ConvertEventArgs)e).Value.ToString(), "0", false) == 0}}`), so B's Inward/Outward/Sale cells are empty.
Status: executable

### stock-report.formula.total-row   (T03 Formula sequence)
Layer: browser
Steps: 1. As above, read the last row.
Expected: gap 11. After two blank rows a row with `Total :` in the name column (`RP_STOCK.cs:5052 {{((DataGridView)DGV).Rows[num24].Cells[2].Value = "Total :";}}`) shows Opening 118 / 1126.000, Purchase 16 / 158.000, Inward 2 / 17.000, Outward 5 / 36.000, Sale 1 / 12.000, Closing 130 / 1253.000;
hidden TransferIn 1 / 10.000 and TransferOut 1 / 10.000 are summed too. The total skips its own row when summing (`RP_STOCK.cs:5028 {{(object)"Total :", false))}}`). Identity: 118+16+2−5−1+1−1 = 130.
Status: executable

### stock-report.formula.closing-identity-per-row   (T03 Formula sequence)
Layer: database
Steps: 1. Run the report API for all eight dimensions with W1 and Item Type blank. 2. For every row compute Opening + Purchase + Inward − Outward − Sale + TransferIn − TransferOut for pcs and for net and gross.
Expected: gap 3, 6. The result equals Closing on every row and the total row; Closing equals the signed `MAIN_STOCK` sum to TO computed by an independent query (pcs 130, net 1253.000, gross 1318.300).
The study's caveat holds: a `TR_TYPE` outside P, I, O, S, T would reach Opening and Closing only (`RP_STOCK.cs:4284 {{AS ClPcs}}`), so the fixture seeds none.
Status: executable

### stock-report.formula.dimension-group   (T03 Formula sequence)
Layer: browser
Steps: 1. W1, Item Type blank, press Group (or Alt+G).
Expected: gap 2. Two rows ordered by group name: `GOLD ORNAMENTS` (A+B) Opening 18 / 176.000, Purchase 6 / 63.000, Inward 2 / 17.000, Outward 5 / 36.000, Sale 1 / 12.000, Closing 20 / 208.000; `SILVER ARTICLES` Opening 100 / 950.000, Purchase 10 / 95.000, Closing 110 / 1045.000.
Query shape: `RP_STOCK.cs:4329 {{GROUP BY B.GR_CODE,C.GR_NAME,B.IT_TYPE ORDER BY C.GR_NAME}}`.
Status: executable

### stock-report.formula.dimension-product   (T03 Formula sequence)
Layer: browser
Steps: 1. W1, Item Type blank, press Product.
Expected: gap 2. Rows by product name: `BOWL` 100/950.000 → 110/1045.000; `CHAIN` 5/50.000, 1/20.000 → 6/70.000; `RING` 13/126.000 … 14/138.000. `RP_STOCK.cs:4378 {{GROUP BY B.PR_CODE,C.PR_NAME,B.IT_TYPE ORDER BY C.PR_NAME}}`.
Status: executable

### stock-report.formula.dimension-safe   (T03 Formula sequence)
Layer: browser
Steps: 1. W1, Item Type Gold, press Safe.
Expected: gap 2. Rows `MAIN` (A: 13/126.000, 5/43.000, 2/17.000, 5/36.000, 1/12.000, 14/138.000) and `VAULT` (B: 5/50.000, 1/20.000, 6/70.000). `RP_STOCK.cs:4489 {{GROUP BY B.SAFE_NAME,B.SAFE_NAME,B.IT_TYPE ORDER BY B.SAFE_NAME}}`. With Item Type blank `MAIN` has two rows (Gold and Silver), one per metal type: Gold 14/138.000 and Silver 110/1045.000 (row order inside the tie is not asserted).
Status: executable

### stock-report.formula.dimension-design   (T03 Formula sequence)
Layer: browser
Steps: 1. W3, Item Type Gold, press Design.
Expected: gap 2. Rows ordered by design: blank design: Opening 17 / 164.000 (M1 100 + M5 6 + M6 8 + M2 50), Purchase 4 / 40.000 (M9), Closing 21 / 204.000; `D1`: Opening 1 / 12.000, Purchase 1 / 3.000, Closing 2 / 15.000; `D2`: Purchase 1 / 20.000, Closing 1 / 20.000. Total Closing 24 / 239.000.
`RP_STOCK.cs:4588 {{GROUP BY A.DESIGN_NO,A.DESIGN_NO,B.IT_TYPE ORDER BY A.DESIGN_NO}}`.
Status: executable

### stock-report.formula.dimension-size   (T03 Formula sequence)
Layer: browser
Steps: 1. W3, Item Type Gold, press Size.
Expected: gap 2. Rows by size: blank: Closing 23 / 219.000 (24 − 1; 239.000 − 20.000); `7`: Purchase 1 / 20.000, Closing 1 / 20.000. `RP_STOCK.cs:4539 {{GROUP BY A.ITM_SIZE,A.ITM_SIZE,B.IT_TYPE ORDER BY A.ITM_SIZE}}`.
Status: executable

### stock-report.formula.dimension-counter   (T03 Formula sequence)
Layer: browser
Steps: 1. W1, Item Type blank, press Counter.
Expected: gap 2, 3. Rows ordered by counter name: `CNT-ONE`: Opening 118 / 1126.000, Purchase 15 / 155.000, Inward 2 / 17.000, Outward 5 / 36.000, Sale 1 / 12.000, hidden TransferOut 1 / 10.000, Closing 128 / 1240.000; `CNT-TWO`: Purchase 1 / 3.000, hidden TransferIn 1 / 10.000, Closing 2 / 13.000.
Check CNT-ONE: 118+15+2−5−1−1 = 128; 1126+155+17−36−12−10 = 1240. Sum of the two Closings = 130 / 1253.000. `RP_STOCK.cs:4637 {{GROUP BY A.TBL_CODE,C.TABLE_NAME,B.IT_TYPE ORDER BY C.TABLE_NAME}}`.
Status: executable

### stock-report.formula.counter-blank-is-001   (T03 Formula sequence; T11 Scope/rights)
Layer: database
Steps: 1. Item Opening M1 leaves the counter blank (`Ac_Stock.cs:15 {{'ITOBL','ITM OPBL','00000',A.IT_CODE,'N',0,'','P','+'}}`). 2. Run the Counter dimension twice. 3. Query `MAIN_STOCK` for blank counters.
Expected: gap 2, 16. Blank counter rows are reported under `CNT-ONE` (001) as the desktop does after its load-time backfill (`RP_STOCK.cs:3653 {{UPDATE MAIN_STOCK SET TBL_CODE = '001' WHERE CO_CODE}}`), but the web does not write: the blank rows are still blank after both runs, and a second tenant's blank rows are never touched (the `OR` of the desktop statement applies to every company).
Status: executable

### stock-report.formula.dimension-trading   (T03 Formula sequence)
Layer: browser
Steps: 1. W1, Item Type blank, press Trading.
Expected: gap 2. Rows `GOLD TRADE` (A+B; B's trading type is blank and is taken from its group GR-A; the web derives it and does not write): Opening 18 / 176.000 … Closing 20 / 208.000; `SILVER TRADE`: 100 / 950.000, 10 / 95.000, 110 / 1045.000.
Desktop copies the group's type onto blank items before the select (`RP_STOCK.cs:4641 {{UPDATE A SET A.TRAD_TYPE = B.TRAD_TYPE FROM ITEM_MAST AS A,GROUP_MAST AS B}}`); order `RP_STOCK.cs:4688 {{GROUP BY B.TRAD_TYPE,C.TRAD_NAME,B.IT_TYPE ORDER BY C.TRAD_NAME}}`. `ITEM_MAST.TRAD_TYPE` of B stays blank afterwards.
Status: executable

### stock-report.formula.dimension-item-lot   (T03 Formula sequence)
Layer: browser
Steps: 1. Enable "Item With LOT Stock". 2. Open the screen.
Expected: gap 2, 16. The Safe button is captioned "Item Lot" (`RP_STOCK.cs:3703 {{BtnSafe.Text = "Item Lot";}}`) and groups by lot (`RP_STOCK.cs:4485 {{GROUP BY A.ITM_LOT,A.ITM_LOT,B.IT_TYPE ORDER BY A.ITM_LOT}}`).
Status: blocked: whether the setting `ITM_WITH_LOT_STK` (settings catalog `CO_SET_NEW.ITM_WITH_LOT_STK`) is reachable in the Lite settings screen is not proven; unblocks when the supervisor confirms it, otherwise this case becomes N/A. No lot-bearing seed is defined for this reason.

### stock-report.formula.rows-split-by-metal   (T03 Formula sequence; T15 Config/history)
Layer: browser
Steps: 1. In Item Master move item S to group GR-A (a later master edit). 2. W1, Item Type blank, press Group.
Expected: gap 2. Every dimension also groups by item type, so `GOLD ORNAMENTS` yields two rows (`RP_STOCK.cs:4329 {{GROUP BY B.GR_CODE,C.GR_NAME,B.IT_TYPE ORDER BY C.GR_NAME}}`): Gold 20 / 208.000 and Silver 110 / 1045.000; `SILVER ARTICLES` has no row (the live master decides the group, not the voucher date).
Status: executable

### stock-report.formula.hidden-items-excluded   (T03 Formula sequence)
Layer: database
Steps: 1. Mark item B "not displayed in stock" (`STK_DISPLAY` = N). 2. Run Item, W1.
Expected: gap 3, 4. B's row and its movements vanish from every column and from the total (Closing total 124 / 1183.000 = 130−6 / 1253−70): `RP_STOCK.cs:4284 {{ AND B.STK_DISPLAY <> 'N'}}`. The drill-down of a visible row is unaffected.
Status: executable

### stock-report.formula.data-type-filter   (T03 Formula sequence; T15 Config/history)
Layer: database
Steps: 1. Seed one extra item-A purchase of 7 pcs / 70.000 net with `DATA_TYPE` `B` (D12). 2. Run with data type `A`, then with data type `C`.
Expected: gap 16. Data type `A` excludes the `B` row (Purchase 5 / 43.000 as in the table); data type `C` adds no data-type condition and includes it (Purchase 12 / 113.000, Closing 21 / 208.000): `RP_STOCK.cs:4284 {{AND A.DATA_TYPE = '" + DC_Main.MsDataType}}` with `C` meaning all.
Status: executable

### stock-report.formula.year-scope   (T03 Formula sequence; T11 Scope/rights)
Layer: database
Steps: 1. Seed an item-A purchase of 50 pcs in the previous year. 2. Run W1 for the current year.
Expected: gap 3. The previous-year movement is excluded from Opening and Closing: `RP_STOCK.cs:4284 {{A.CO_YEAR = '}}` (A Opening stays 13 / 126.000; carrying stock across years is done by the year-end balance transfer, not by this report).
Status: executable

### stock-report.formula.onhandnet-differs   (T03 Formula sequence)
Layer: unit
Steps: 1. For item A at W1 compare the new report resolver with the shared `onHandNet()` helper.
Expected: gap 7. The report returns the desktop rule; the helper (signed `ITM_FINE` for both signs, no dates) is not the oracle and is not used by the report. See "Not covered", item 1.
Status: N/A: the helper's defect is a separate finding reported to the supervisor; this case only asserts the report does not call it.

### T04 Lookup

### stock-report.lookup.code-help-on-enter   (T04 Lookup)
Layer: browser
Steps: 1. In Pr Code type a code that exists and press Enter. 2. Type an unknown code and press Enter. 3. Pick a row in the help list. 4. Repeat in Gr Code, It Code, Design, AcCode.
Expected: gap 4, 10. A known code stays; an unknown code opens the help list and the chosen code is written back (`RP_STOCK.cs:5730 {{Select * From PRODUCT_MAST WHERE CO_CODE}}`, `RP_STOCK.cs:6188 {{Select DESIGN_NO From MAIN_STOCK WHERE CO_CODE}}`); the list is scoped to the current company and location.
Status: executable

### stock-report.lookup.stale-and-cancel   (T04 Lookup)
Layer: browser
Steps: 1. Open the Pr Code help, type to filter, delay the first response, type again, cancel with Esc.
Expected: gap 4. The late first response never overwrites the second; Esc leaves the filter box unchanged and the grid untouched.
Status: executable

### stock-report.lookup.lc-code   (T04 Lookup; T11 Scope/rights)
Layer: browser
Steps: 1. Show the LC box (setting `MsLcBoxShow`), type another location's code, Enter.
Expected: gap 4. The help lists only locations the user's company owns (`RP_STOCK.cs:6011 {{Select * From LOCT_MAST WHERE  CO_CODE}}`); a second tenant's location never appears.
Status: blocked: the LC box is hidden unless `MsLcBoxShow` is set and that setting is not part of Lite; unblocks if the supervisor adds it to the Lite settings.

### T05 Children (drill-down and zoom)

Movement rows below are those of the drill-down grid: `SrNo, Vchtype, Party Name, VchNo, VchDate, TagNo, ItName, Pcs, GrWt, NetWt, Fine, Sign`
(`RP_STOCK.cs:3081 {{((DataGridView)DGV_VCH).ColumnCount = 16;}}`). Fine is `RP_STOCK.cs:2896 {{CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END As ItmFine}}`.

### stock-report.drill.opening-signed-total   (T05 Children)
Layer: browser
Steps: 1. W1, Item dimension, double-click A's OpPcs cell.
Expected: gap 8, 7. The summary hides, `BtnExit` reads `&Back` (`RP_STOCK.cs:2833 {{BtnExit.Text = "&Back";}}` caption). Rows dated before D10 in date order: M1, M4, M5, M6 with Pcs 10, 1, 1, 1; Net 100.000, 12.000, 6.000, 8.000; Fine 91.600, 10.800, 5.400, 7.200 (all `+` rows show `KR_FINE`).
"Total :" row: Pcs 13, Gross 132.200, Net 126.000, Fine 91.600+10.800+5.400+7.200 = 115.000. It equals the summary cell (13 / 126.000). Had `ITM_FINE` been used for the `+` rows the total would be 91.600+10.992+5.496+7.328 = 115.416: that value is a failure.
Signed sum rule: `RP_STOCK.cs:3175 {{if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[11].Value, (object)""), (object)"+", false))}}`.
Status: executable

### stock-report.drill.sale-uses-itm-fine   (T05 Children)
Layer: browser
Steps: 1. W1, Item dimension, double-click A's SlPcs cell.
Expected: gap 7, 8. One row, M10: party CUS1, tag T1, Pcs 1, Gross 12.500, Net 12.000, Fine 11.040 (the `ITM_FINE` of a `-` row; the stored `KR_FINE` 10.800 is not shown), Sign `-`.
Total row: 1, 12.500, 12.000, 11.040. Sale rule: `-` and `TR_TYPE = 'S'` dated FROM..TO (the purchase twin is `RP_STOCK.cs:2900 {{ AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'P' AND A.VCH_DATE >= '}}`).
Status: executable

### stock-report.drill.purchase   (T05 Children)
Layer: browser
Steps: 1. W1, Item dimension, double-click A's PrPcs cell. 2. Same on B's PrWt cell.
Expected: gap 8. A: M7 (tag T4, Pcs 1, Net 3.000, Fine 2.700) and M9 (SUP1, loose, Pcs 4, Gross 42.000, Net 40.000, Fine 36.800); total 5 / 45.150 / 43.000 / 39.500. B: M8 (tag T5) 1 / 21.000 / 20.000 / 18.000.
The weight columns (6 or 7) open the same set (columns 6, 7 = Purchase).
Status: executable

### stock-report.drill.inward-and-outward   (T05 Children)
Layer: browser
Steps: 1. W1, Item dimension. 2. Double-click A's InPcs cell. 3. Back. 4. Double-click A's OuPcs cell.
Expected: gap 8. Inward rows: M14 (Sales Return, CUS1, T1, 1 / 12.500 / 12.000 / fine 11.040) and M16 (Stock Adjust, loose, 1 / 5.250 / 5.000 / fine 4.580); total 2 / 17.750 / 17.000 / 15.620.
Outward rows in date order: M15 (SUP1, 2 / 21.000 / 20.000 / 18.400), M17 (1 / 2.100 / 2.000 / 1.832), M18 (T2, 1 / 6.300 / 6.000 / 5.496), M19 (CUS1, T3, 1 / 8.400 / 8.000 / 7.328); total 5 / 37.800 / 36.000 / 33.056 (18.400+1.832+5.496+7.328).
All `-` rows show `ITM_FINE`, so T2 shows 5.496 although its `KR_FINE` is 5.400. Outward is ordered by an alias that the desktop query lacks (`RP_STOCK.cs:2961 {{DC_Main.RsQry += "ORDER BY F.VCH_DATE ";}}`); the web orders by `VCH_DATE`.
Status: executable

### stock-report.drill.closing-signed-total   (T05 Children)
Layer: browser
Steps: 1. W1, Item dimension, double-click A's ClPcs cell.
Expected: gap 8, 7. Every movement dated up to D40 for item A (M1, M4, M5, M6, M7, M9, M10, M14, M15, M16, M17, M18, M19), 13 rows. Totals use the sign (`+` added, `-` subtracted): Pcs 14, Gross 144.800, Net 138.000.
Fine = + (91.600 + 10.800 + 5.400 + 7.200 + 2.700 + 36.800 + 11.040 + 4.580) − (11.040 + 18.400 + 1.832 + 5.496 + 7.328) = 170.120 − 44.096 = 126.024 (pcs 20 − 6 = 14; net 186.000 − 48.000 = 138.000; gross 195.100 − 50.300 = 144.800).
Equals the summary Closing cell (14 / 138.000). The final write is `RP_STOCK.cs:3220 {{((DataGridView)DGV_VCH).Rows[num6].Cells[7].Value = num;}}`.
Status: executable

### stock-report.drill.tag-filter-fine   (T05 Children)
Layer: browser
Steps: 1. W1, TagNo = T1, Item dimension, double-click ClPcs.
Expected: gap 7, 8. Rows M4 (+, fine 10.800), M10 (−, fine 11.040), M14 (+, fine 11.040): Fine total = 10.800 − 11.040 + 11.040 = 10.800; Pcs 1, Net 12.000. The shared helper `onHandNet()` (signed `ITM_FINE`) would give 10.992, which is the wrong figure.
Status: executable

### stock-report.drill.non-drill-columns   (T05 Children)
Layer: browser
Steps: 1. Double-click the SrNo cell, the name cell and the Total row.
Expected: gap 8. Nothing opens (`RP_STOCK.cs:2892 {{default:}}`); the summary stays visible.
Status: executable

### stock-report.drill.same-filters-as-summary   (T05 Children)
Layer: browser
Steps: 1. W2, Item Type Gold, Stock Type = Item, Item dimension, double-click A's OpPcs, then ClPcs.
Expected: gap 8. Only loose rows appear: Opening has one row (M1, 10 pcs / 100.000); Closing has M1 and M9 (10+4 = 14 pcs, 100+40 = 140.000). Both totals equal the summary cells of the same run (Opening 10 / 100.000, Closing 14 / 140.000), because the web drill-down repeats the summary's filters
(the desktop appends its own list: `RP_STOCK.cs:2919-2958 {{DC_Main.RsQry +=}}`). The same holds with the Item Type filter and with a hidden item (weakness 5: the desktop drill-down omits both).
Status: executable

### stock-report.drill.back-and-escape   (T05 Children; T17 Keyboard)
Layer: browser
Steps: 1. Open any drill-down. 2. Press Esc. 3. Press Esc again.
Expected: gap 8, 10. First Esc returns to the summary (`RP_STOCK.cs:3992 {{if ((int)e.KeyCode == 27)}}` with `&Back` showing); the second Esc closes the form (`RP_STOCK.cs:4006 {{((Form)this).Close();}}`). The search box is re-enabled on Back.
Status: executable

### stock-report.drill.excel-uses-visible-grid   (T05 Children; T16 Report/output)
Layer: browser
Steps: 1. Open a drill-down, press Excel.
Expected: gap 8, 12. The export is the movement grid, not the summary (`RP_STOCK.cs:3232-3340 {{((DataGridView)DGV_VCH)}}` when the button reads `&Back`); the same rows and the Total row as on screen.
Status: executable

### stock-report.zoom.lite-voucher-targets   (T05 Children)
Layer: browser
Steps: 1. Open drill-downs and double-click a row of each book: Tag Opening (M4), Purchase (M9), Sales (M10), Sales Return (M14), Purchase Return (M15), Stock Adjust (M16), Tag Cancel (M18), Approval Issue (M19).
Expected: gap 9. Each opens the entry screen of its own book on that voucher number with the voucher's data: OPSTK → Tag Opening (`RP_STOCK.cs:5265 {{else if (Operators.CompareString(DC_Main.CurBookMain, "OPSTK", false) == 0)}}`);
STOCK ADJUST (`RP_STOCK.cs:5288 {{"STOCK ADJUST"}}`) and TAG CANCEL (`RP_STOCK.cs:5281 {{"TAG CANCEL"}}`) → the tag cancel screen; APR ISU (`RP_STOCK.cs:5295 {{"APR ISU"}}`) → approval issue; SALES (`RP_STOCK.cs:5316 {{CompareString(DC_Main.CurBookMain, "SALES", false)}}`); PURCHASE (`RP_STOCK.cs:5333 {{"PURCHASE"}}`);
PURC RETURN (`RP_STOCK.cs:5350 {{"PURC RETURN"}}`); SALES RETURNE (`RP_STOCK.cs:5423 {{"SALES RETURNE"}}`). The web navigates by voucher key (book + number), not by globals (weakness 10).
Status: executable

### stock-report.zoom.non-lite-books   (T05 Children)
Layer: browser
Steps: 1. Seed movements of books `TAG SPLIT`, `TAG TRFR`, `MFG STNG ISU`, `LOAN ISSUE`, `TOUR SALES`, `CON PUR`, `KARIGAR ISSUE` by fixture and double-click each.
Expected: gap 9. These books' target menus are not in the Lite edition (`docs/handbook/menu-editions.json`: the Lite list has no Tag Split, Tag Transfer, Manufacturing, Loan, Tour, Consignment or Karigar voucher), so the zoom is N/A and the web shows no voucher for them.
Desktop: `RP_STOCK.cs:5559 {{"TAG SPLIT"}}`, `RP_STOCK.cs:5489 {{"TAG TRFR"}}`, `RP_STOCK.cs:5454 {{"LOAN ISSUE"}}`, `RP_STOCK.cs:5566 {{"TOUR SALES"}}`, `RP_STOCK.cs:5503 {{"CON PUR"}}`.
Status: N/A: target menus are outside Lite (decision 5).

### stock-report.zoom.item-opening-refused   (T05 Children; T06 Required/invalid)
Layer: browser
Steps: 1. Drill into Opening and double-click M1 (voucher number shorter than 3 characters).
Expected: gap 9, 14. Message exactly `This Is a Item Wise Opening Stock Voucher You Cant Zoom ....` (`RP_STOCK.cs:5263 {{This Is a Item Wise Opening Stock Voucher You Cant Zoom ....}}`); nothing opens; grid stays.
Status: executable

### stock-report.zoom.needs-target-read-right   (T05 Children; T11 Scope/rights)
Layer: browser
Steps: 1. Revoke View on "Sales" for the user. 2. Double-click M10. 3. Grant it and repeat. 4. Delete the user's rights row for Sales and repeat.
Expected: gap 9, 14. First: message `You Have No Rights...` (three dots, `RP_STOCK.cs:5248 {{You Have No Rights...}}`), stays on the movement grid. After granting: the Sales voucher opens. With no rights row at all the desktop allows the zoom
(`RP_STOCK.cs:5245 {{dataTable2.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual}}`); the web opens only with the target menu's Read right, so with no row the zoom is refused with the same text (decision 5: deliberate hosted-service difference).
Status: executable

### stock-report.zoom.not-from-merged-or-other-lc   (T05 Children)
Layer: browser
Steps: 1. With the LC box showing a different location than the user's current one, double-click a movement.
Expected: gap 9. Nothing opens (`RP_STOCK.cs:5225 {{if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0 || Operators.CompareString(tLcCode.Text, DC_Main.MLc_code, false) != 0)}}`).
Status: blocked: needs the LC box, which is outside Lite (see `stock-report.lookup.lc-code`).

### T06 Required, invalid, refused

### stock-report.invalid.print-without-right   (T06 Required/invalid; T11 Scope/rights)
Layer: browser
Steps: 1. Revoke Print on Stock Report. 2. Press Print. 3. Press Excel. 4. Call the print and export API URLs directly.
Expected: gap 12, 14. Both buttons show exactly `You Have No Print Rights.....` (five dots): print `RP_STOCK.cs:4024 {{You Have No Print Rights.....}}`, Excel `RP_STOCK.cs:3237 {{You Have No Print Rights.....}}`; nothing is produced; the API answers 403 with no body data.
Status: executable

### stock-report.invalid.print-right-no-rights-row   (T06 Required/invalid)
Layer: database
Steps: 1. Delete the user's rights row for Stock Report and call print.
Expected: gap 14. The desktop field is declared without a value (`RP_STOCK.cs:197 {{private string UserPrint;}}`), stays empty when `USER_SET` has no row (`RP_STOCK.cs:3394 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}`)
and the test `RP_STOCK.cs:4022 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}` is then true, so print is refused with `You Have No Print Rights.....`. The web answers the same.
Status: executable

### stock-report.invalid.empty-result   (T06 Required/invalid)
Layer: browser
Steps: 1. Filter TagNo = `NOSUCH`, press Item.
Expected: gap 4, 11. Empty grid, no message, no Total row (desktop leaves the grid blank: `RP_STOCK.cs:4712 {{if (dataView.Count <= 0)}}`); no console error.
Status: executable

### stock-report.invalid.item-picker-nothing-ticked   (T06 Required/invalid)
Layer: browser
Steps: 1. Press InOut. 2. Press Ok with no item ticked.
Expected: gap 13, 14. Message exactly `Item Selection Not Done...` (`RP_STOCK.cs:5942 {{Item Selection Not Done...}}`); the picker closes; no print starts.
Status: executable

### stock-report.invalid.bad-date-text   (T06 Required/invalid)
Layer: browser
Steps: 1. Type `31/02/2026` in From and press Enter. 2. Type `01/04/2026` and press Enter.
Expected: gap 3, 10. An invalid date does not move on (the date check is `DC_Main.SetDate`, which passes only a valid date: `RP_STOCK.cs:5177-5192 {{private void mFromDt_KeyDown}}`); the valid date moves to the next field.
Status: blocked: the `DC_Main.SetDate` rule text and its message were not read in the study; unblocks when `DC_Main.SetDate` is quoted (no message is asserted until then).

### T07 Create (stock built through real screens: the report moves with each voucher)

For each case below the fixture opens the report before and after saving the voucher through the real screen, in W1 with Item Type blank, and asserts the delta of
item A only (the other items must not move) plus the identity of section 0. The "after" figures are the worked table's cumulative figures.

### stock-report.create.item-opening   (T07 Create)
Layer: browser
Steps: 1. Save Item Opening M1 (A 10 pcs 105.000 / 100.000, touch 91.6). 2. Run W0 and W1 for A.
Expected: gap 6, 3. Delta: Opening +10 / +100.000 (dated `Y0−1`, so before any FROM on or after `Y0`: `Ac_Stock.cs:15 {{Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy")}}`); Closing +10 / +100.000; no Purchase. Only the report's item-A row is created.
Status: executable

### stock-report.create.tag-opening   (T07 Create)
Layer: browser
Steps: 1. Save Tag Opening T1 (D5, 1 pcs 12.500 / 12.000) and T4 (D11, 1 pcs 3.150 / 3.000). 2. Run W1.
Expected: gap 6. T1 enters Opening (+1 / +12.000; dated before FROM), T4 enters Purchase (+1 / +3.000; dated in the window, `TR_TYPE` P: `Ac_Stock.cs:28 {{B.MAIN_BOOK IN ('OPSTK','JDTR TAG','MFG TAG')}}`); Closing +2 / +15.000.
Status: executable

### stock-report.create.purchase   (T07 Create)
Layer: browser
Steps: 1. Save Purchase M9 (A 4 pcs, 42.000 / 40.000, touch 92.0) from SUP1 on D12. 2. Run W1.
Expected: gap 6. Purchase +4 / +40.000 (gross +42.000); Closing +4 / +40.000. The drill-down row has Party SUP1, loose tag, Fine 36.800.
Status: executable

### stock-report.create.sale   (T07 Create)
Layer: browser
Steps: 1. Save Sales M10 of tag T1 to CUS1 on D15 (sale touch 92.0). 2. Run W1.
Expected: gap 6, 7. Sale +1 / +12.000 (shown positive, `ITM_SIGN` `-`, `TR_TYPE` `S`); Closing −1 / −12.000; the drill-down fine is 11.040. A sale of tag T1 does not touch any `BAR_DETL`-based figure of another report.
Status: executable

### stock-report.create.sales-return   (T07 Create)
Layer: browser
Steps: 1. Save Sales Return M14 of tag T1 from CUS1 on D20. 2. Run W1.
Expected: gap 6. Inward +1 / +12.000; Closing +1 / +12.000; the drill-down fine is 11.040 (`Ac_Stock.cs:247 {{FROM  SL_DETL_RTN AS A LEFT JOIN BOOK_DATA AS B}}` sets both fine columns to the return line's `ITM_FINE`).
Status: executable

### stock-report.create.purchase-return   (T07 Create)
Layer: browser
Steps: 1. Save Purchase Return M15 (A 2 pcs, 21.000 / 20.000) to SUP1 on D25. 2. Run W1.
Expected: gap 6. Outward +2 / +20.000; Closing −2 / −20.000 (`Ac_Stock.cs:331 {{FROM  PR_DETL AS A LEFT JOIN BOOK_DATA AS B}}`).
Status: executable

### stock-report.create.stock-adjust   (T07 Create)
Layer: browser
Steps: 1. Save Stock Adjust M16 (plus 5.250 / 5.000, 1 pcs) and M17 (minus 2.100 / 2.000, 1 pcs) on D28. 2. Run W1.
Expected: gap 6. Plus line: Inward +1 / +5.000; minus line: Outward +1 / +2.000; Closing +0 / +3.000 (`Ac_Stock.cs:54 {{CASE WHEN A.ITM_SIGN = '+' THEN 'I' ELSE 'O' END}}`). Loose lines are visible in the report (a `BAR_DETL` snapshot would miss them).
Status: executable

### stock-report.create.tag-cancel   (T07 Create)
Layer: browser
Steps: 1. Save Tag Cancel of T2 on D30. 2. Run W1.
Expected: gap 6. Outward +1 / +6.000; Closing −1 / −6.000; drill-down row fine 5.496 (`ITM_FINE`, a `-` row).
Status: executable

### stock-report.create.approval-issue   (T07 Create)
Layer: browser
Steps: 1. Save Approval Issue of T3 to CUS1 on D33. 2. Run W1.
Expected: gap 6. Outward +1 / +8.000; Closing −1 / −8.000 (`Ac_Stock.cs:68 {{B.MAIN_BOOK = 'APR ISU' AND B.BOOK_INOUT = 'O'}}`). The tag leaves stock at issue; Approval Return puts it back (see journey).
Status: executable

### stock-report.create.counter-transfer-fixture   (T07 Create)
Layer: database
Steps: 1. Insert the two `T` rows M12/M13 by fixture. 2. Run W1 in the Item and Counter dimensions.
Expected: gap 3. Item B row unchanged (Closing 6 / 70.000, transfers cancel); Counter dimension as in `stock-report.formula.dimension-counter`; hidden columns hold 1 / 10.000 each; they appear in "Total :" only.
Status: executable

### T08 Reopen and no-op

### stock-report.reopen.runs-write-nothing   (T08 Reopen/no-op)
Layer: database
Steps: 1. Count rows and the highest update time in `ITEM_MAST`, `MAIN_STOCK`, `REPORT_DATA`. 2. Open the screen, run all eight dimensions, open a drill-down, print, export. 3. Count again for two tenants.
Expected: gap 6, 12. Nothing changes. The desktop writes at load (`RP_STOCK.cs:3651 {{UPDATE ITEM_MAST SET STK_DISPLAY = 'Y' WHERE CO_CODE}}`, `RP_STOCK.cs:3652 {{UPDATE ITEM_MAST SET SAFE_NAME = 'MAIN' WHERE CO_CODE}}`) and on print (`RP_STOCK.cs:4058 {{DELETE FROM REPORT_DATA WHERE CO_CODE}}`); the web must not.
Items with a NULL `STK_DISPLAY` are shown (treated as `Y`) and NULL `SAFE_NAME` is grouped under `MAIN`, without a write.
Status: executable

### stock-report.reopen.same-result-twice   (T08 Reopen/no-op)
Layer: browser
Steps: 1. Run W1 Item twice, close and reopen, run again.
Expected: gap 3. Identical rows and totals each time (no time dependence apart from the To default); the order is stable.
Status: executable

### stock-report.reopen.cancel-clears   (T08 Reopen/no-op)
Layer: browser
Steps: 1. Run W1 Item with filters set, press Cancel.
Expected: gap 4. Filters, grid and drill-down reset to the defaults of `stock-report.entry.default-fields` (`BtnCancel` → `CLEAR_DATA`, `RP_STOCK.cs:3759 {{BtnExit.Text = "&Exit";}}` caption restored).
Status: executable

### T09 Edit (a voucher edit moves the report)

### stock-report.edit.purchase-quantity   (T09 Edit)
Layer: browser
Steps: 1. Edit Purchase M9 from 4 pcs 42.000 / 40.000 to 3 pcs 31.500 / 30.000. 2. Run W1.
Expected: gap 6. A Purchase 4 / 33.000 (43.000 − 10.000 = M7 3 + M9 30), Closing 13 / 128.000; B and S unchanged. Gross Purchase 45.150 − 10.500 = 34.650.
Status: executable

### stock-report.edit.voucher-date-moves-column   (T09 Edit)
Layer: browser
Steps: 1. Edit Purchase M9 date from D12 to D8 (before FROM). 2. Run W1.
Expected: gap 3. The 4 / 40.000 leaves Purchase (A Purchase 1 / 3.000) and enters Opening (A Opening 17 / 166.000); Closing unchanged at 14 / 138.000.
Status: executable

### T10 Delete, cancel, reverse

### stock-report.delete.sale-restores-stock   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Delete Sales M10 (with its return M14 deleted first, if the screen requires). 2. Run W1.
Expected: gap 6. After deleting M14 then M10: Sale blank; Inward 1 / 5.000 (only M16); Outward unchanged 5 / 36.000; Closing 13+5+1−5 = 14 pcs and 126+43+5−36 = 138.000 (the sale and its return had cancelled, so Closing is unchanged while two columns lose their entry).
The deleted vouchers leave no row in any column or drill-down.
Status: executable

### stock-report.delete.tag-cancel-and-approval-return   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Save Approval Return of T3 on D35. 2. Run W1.
Expected: gap 6. Inward +1 / +8.000 (`APR RTN` posts `I` `+`): Inward 3 / 25.000; Closing 13+5+3−5−1 = 15 / 126+43+25−36−12 = 146.000; the drill-down shows the return voucher with Sign `+`. Deleting the return restores Inward 2 / 17.000 and Closing 14 / 138.000.
Status: executable

### T11 Scope and rights

### stock-report.scope.second-tenant-sentinel   (T11 Scope/rights)
Layer: database
Steps: 1. In a second tenant seed the same item codes with movements 1000 pcs and the same masters. 2. As tenant 1 run all eight dimensions, drill-downs, print and export, and call the API with tenant 2's company, location and voucher ids.
Expected: gap 1, 6. Not one row, total, drill-down line or export cell from tenant 2 appears; direct calls with another tenant's ids return empty or 403; forced row-level security answers the same.
Status: executable

### stock-report.scope.company-merge-isolation   (T11 Scope/rights)
Layer: database
Steps: 1. Set `CO_STK_MERGE` = Y for tenant 1's company group and seed a second company in the same tenant; run W1. 2. Run as tenant 2.
Expected: gap 16. With the merge, the company condition is dropped within the tenant only (`RP_STOCK.cs:4284 {{DC_Main.MsCoStockMerge, "Y", false) == 0, (object)""}}`): the second company's movements are added to every column; tenant 2's rows never are. The voucher zoom is disabled while merged (`RP_STOCK.cs:5225 {{Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0}}`).
Status: executable

### stock-report.scope.list-right   (T11 Scope/rights)
Layer: browser
Steps: 1. Remove the List right and press Item. 2. Restore.
Expected: gap 1, 14. The report row set refuses with the same no-rights text; the catalog rights `----PL` give View, Print and List only; no Add, Edit or Delete control exists on the screen.
Status: blocked: whether the desktop checks a List right in this form is not in the source (`UserEdit`/`UserDelete` are read and never used; only `UserPrint` is used: `RP_STOCK.cs:3394 {{UserPrint = Conversions.ToString}}`); unblocks when the supervisor decides the hosted List behaviour.

### T12 Concurrency

### stock-report.concurrency.two-users-print   (T12 Concurrency)
Layer: database
Steps: 1. User 1 prints W1 Group while user 2 prints W3 Group in the same instant, both with an `EMP ISU`-free company. 2. Compare outputs.
Expected: gap 12. Each print carries its own dates and figures; no shared staging table exists (the desktop `REPORT_DATA` delete-then-insert by company, `RP_STOCK.cs:4058 {{DELETE FROM REPORT_DATA WHERE CO_CODE}}`, lets two users overwrite each other).
Status: executable

### stock-report.concurrency.save-during-run   (T12 Concurrency)
Layer: database
Steps: 1. Start W1 Item and, in the same instant, save a new purchase in a second session. 2. Read the result.
Expected: gap 6. The result is either the state before or after the purchase in full, never a mix (the identity of section 0 holds on every row).
Status: N/A: a read-only report has no race outcome beyond one consistent snapshot, which the identity check in every T03 case already proves.

### T13 Retry and unknown

### stock-report.retry.duplicate-request   (T13 Retry/unknown)
Layer: database
Steps: 1. Send the same report request twice and a print request twice.
Expected: gap 12. Identical results; no extra rows anywhere.
Status: N/A: reads are idempotent by construction and the web writes nothing (covered by `stock-report.reopen.runs-write-nothing`).

### T14 Rollback

### stock-report.rollback.none   (T14 Rollback)
Layer: database
Steps: n/a
Expected: gap 12. The report has no write set, so there is nothing to roll back.
Status: N/A: no write (the web does not port the load and print writes of `RP_STOCK.cs:3653 {{UPDATE MAIN_STOCK SET TBL_CODE = '001' WHERE CO_CODE}}`, `RP_STOCK.cs:4058 {{DELETE FROM REPORT_DATA WHERE CO_CODE}}` and `RP_STOCK.cs:4641 {{UPDATE A SET A.TRAD_TYPE = B.TRAD_TYPE FROM ITEM_MAST AS A,GROUP_MAST AS B}}`).

### T15 Config and history

### stock-report.config.gross-setting-changes-default-only   (T15 Config/history)
Layer: browser
Steps: 1. Open the screen with `STK_RPT_TYPE` = N. 2. Change the setting to G while the screen is open and run Item. 3. Reopen.
Expected: gap 5, 16. The open screen keeps its box state until reopened (the default is read at load: `RP_STOCK.cs:3647 {{if (Operators.CompareString(DC_Main.MsStkRptType, "G", false) == 0)}}`); after reopening the box is ticked. No hidden global default changes a result already shown.
Status: executable

### stock-report.config.master-edit-after-voucher   (T15 Config/history)
Layer: browser
Steps: 1. Rename item A to `GOLD RING 24K` after the vouchers. 2. Run W1 Item. 3. Change item A's safe to VAULT and run Safe.
Expected: gap 2. The report uses the live master: Item row name `GOLD RING 24K`, and in the Safe dimension A joins `VAULT` (VAULT Closing 20 / 208.000, `MAIN` has no gold row). Voucher dates and figures do not change.
Status: executable

### stock-report.config.cancelled-tag-and-previous-year   (T15 Config/history)
Layer: browser
Steps: 1. After M18 (T2 cancelled) run W2 and W1. 2. Run a window ending D29 and one ending D30.
Expected: gap 6. T2 is in Opening in every window; it leaves stock only in windows that include D30: Closing to D29 includes T2 (6.000), Closing to D30 excludes it.
Status: executable

### stock-report.config.emp-isu-adjustment   (T15 Config/history)
Layer: database
Steps: 1. Seed tag T3 issued to an employee (`APR_DETL` book `EMP ISU`, 1 pcs, 8.000 net, dated D33; no `MAIN_STOCK` out row) and no `RATE_CUT_ISU` rows. 2. Run W1 Item for A without M19.
Expected: gap 15. The source says: with `EMP ISU` tags the grid is adjusted by `APR_DETL` (`RP_STOCK.cs:4907 {{SELECT TAG_NO,IT_CODE,ITM_PCS FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BOOK_NAME = 'EMP ISU' AND TAG_NO <> 'N' }}`).
Arithmetic, with the `RATE_CUT_ISU` sums empty (so `num3` = 0 and `num4` = 0): `MAIN_STOCK` alone gives A Outward 4 / 28.000 (M15 20 + M17 2 + M18 6) and Closing 15 / 146.000. Opening grid cell minus (`OpPcs`, `OpWt`) of `APR_DETL` before FROM = 13 − 0 = 13 / 126.000; Inward plus `InPcs` (EMP REC in the window, none) = 2 / 17.000;
Outward plus `OutPcs` (`EMP ISU` in the window) = 4+1 = 5 / 28+8 = 36.000 (`RP_STOCK.cs:4986 {{Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["OutPcs"]))}}`); Closing minus (`ClPcs` − `num3`) = 15 − 1 = 14 / 146 − 8 = 138.000
(`RP_STOCK.cs:4994 {{Operators.SubtractObject(DC_Main.Tbl.Rows[0]["ClPcs"], (object)num3)}}`). The adjusted row equals the figures with a normal approval issue, 14 / 138.000.
Status: blocked: the only form that writes `EMP ISU` rows is the Stock Isu menu (`MDI_FORM.cs:9299 {{DC_Main.CurBookHelp("EMP ISU");}}`), which is not in the Lite list of `docs/handbook/menu-editions.json`; Lite's Approval Isu posts book `APR ISU` (`Ac_Stock.cs:68 {{B.MAIN_BOOK = 'APR ISU' AND B.BOOK_INOUT = 'O'}}`) and its employee box is a salesperson, not an `EMP ISU` issue. Unblocks when the supervisor either confirms an `EMP ISU` entry route in Lite or approves seeding the `APR_DETL` rows by fixture.

### T16 Output (print, export, drill totals)

Template files exist in `extraction_output/rpt_xml/`: `GroupStkRpt.xml`, `ProdStkRpt.xml`, `TableStkGwtRpt.xml`, `ItemStkRpt.xml`, `SafeStkSumm.xml`, `ItmStkWithGrid.xml`, `ItemLedger.xml`. `SafeStkRpt.xml` is MISSING there (only the summary variant exists).
`ItmStkBalance.xml` exists but no line of `RP_STOCK.cs` or `MDI_FORM.cs` names it, so no case relies on it.

### stock-report.output.group-print   (T16 Report/output)
Layer: browser
Steps: 1. W1, Item Type blank, Group dimension, press Print.
Expected: gap 12. Template `GroupStkRpt` (`RP_STOCK.cs:4032 {{text = "GroupStkRpt";}}`); title `Group Wise Stock From Date  11/04/2026 To 11/05/2026` (two spaces after "Date": `RP_STOCK.cs:4224 {{Cr[(short)0] = "RptTitel = '" + text2 + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To "}}`);
rows `GOLD ORNAMENTS` and `SILVER ARTICLES`; Opening 18 / 176.000 and 100 / 950.000, Closing 20 / 208.000 and 110 / 1045.000, grand Closing 130 / 1253.000 (the same as the grid).
Status: executable

### stock-report.output.titles-by-dimension   (T16 Report/output)
Layer: browser
Steps: 1. Print each dimension in turn: Product, Counter, Safe (answer No to the summary question), Item, Size, Design, Trading.
Expected: gap 12. Template and title text: Product `ProdStkRpt` "Product Wise Stock From Date  " (`RP_STOCK.cs:4036 {{text = "ProdStkRpt";}}`); Counter `TableStkGwtRpt` "Counter Wise Stock From Date  "; Safe `SafeStkRpt` "Safe Wise Stock From Date  "; every other dimension `ItemStkRpt` "Item Wise Stock From Date  "
(`RP_STOCK.cs:4048 {{text = "ItemStkRpt";}}`). Every printed Closing equals the grid Closing for the same filters.
Status: blocked: the Safe template `SafeStkRpt` is MISSING from `extraction_output/rpt_xml/`; the Safe print case stays in the denominator until the file is added; the other dimensions are executable.

### stock-report.output.safe-summary-question   (T16 Report/output)
Layer: browser
Steps: 1. Safe dimension, Print. 2. Answer Yes. 3. Print again, answer No.
Expected: gap 12. A Yes/No box titled `Safe Wise Summ Report` (`RP_STOCK.cs:4172 {{Safe Wise Summ Report}}`); Yes selects `SafeStkSumm` (`RP_STOCK.cs:4174 {{DC_Main.RptName = "SafeStkSumm";}}`), No keeps `SafeStkRpt`.
Status: executable

### stock-report.output.print-uses-screen-filters   (T16 Report/output)
Layer: browser
Steps: 1. W1, Item Type Gold, Group dimension, TagNo = T1 (rows: only tag T1), Print. 2. Tick Gross, run, Print.
Expected: gap 12. The print equals the screen: GOLD ORNAMENTS with the T1 figures (Opening 1 / 12.000, Inward 1 / 12.000, Sale 1 / 12.000, Closing 1 / 12.000) and, after ticking gross and rerunning, 12.500 in each weight column.
The desktop selection formula omits the account, tag, item and design filters and the gross box (`RP_STOCK.cs:4125 {{CurFormula = "{MAIN_STOCK.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MAIN_STOCK.CO_YEAR} = '"}}`); that disagreement is a desktop weakness and is not ported, so this case expects screen equals print.
Status: executable

### stock-report.output.excel-export   (T16 Report/output)
Layer: browser
Steps: 1. W1 Item dimension, press Excel. 2. Open the file.
Expected: gap 12. Header row equals the visible column captions; numeric cells hold the value rounded to three decimals (`RP_STOCK.cs:3306 {{Math.Round(Convert.ToDouble(((DataGridView)DGV)[l, DC_Main.i].Value.ToString()), 3)}}`), e.g. A Closing weight 138 stored as 138.000; zeros are empty as on screen; the Total row is present; row count and totals equal the grid even when the result exceeds one page.
Status: executable

### stock-report.output.large-result-totals   (T16 Report/output)
Layer: database
Steps: 1. Seed 600 extra items with one opening each (1 pcs / 1.000 net). 2. Run Item (paged), compare the Total row and the export.
Expected: gap 3, 11, 12. Total Opening is 118 + 600 = 718 pcs and 1126.000 + 600.000 = 1726.000 on every page and in the export, covering the whole result, not the visible page.
Status: executable

### stock-report.output.item-ledger-print   (T16 Report/output)
Layer: browser
Steps: 1. Press InOut. 2. The picker lists the items of the chosen Item Type; tick A; press Ok.
Expected: gap 13. Template `ItemLedger` (`RP_STOCK.cs:5952 {{ItemLedger.RPT}}`) for items in the ticked list with movements dated up to TO (`RP_STOCK.cs:5958 {{CurFormula = CurFormula + " And {MAIN_STOCK.IT_CODE} in [" + SelectIt + "]";}}`): item A's Closing as of D40 is 14 / 138.000; items not ticked are absent. The picker lists only gold items when Item Type is Gold (`RP_STOCK.cs:5879 {{SELECT A.IT_CODE,A.IT_NAME FROM ITEM_MAST  AS A}}`); All ticks every listed item.
Status: executable

### stock-report.output.print-title-with-lc   (T16 Report/output)
Layer: browser
Steps: 1. Show the LC box (`MsLcBoxShow`), pick LC2, print.
Expected: gap 12. The title is prefixed `Branch - <LC> ` (`RP_STOCK.cs:4220 {{Cr[(short)0] = "RptTitel = 'Branch - "}}` variant).
Status: blocked: the LC box is outside Lite (see `stock-report.lookup.lc-code`).

### stock-report.output.opening-print-layout   (T16 Report/output)
Layer: browser
Steps: 1. Compare the print preview page with the `ItemStkRpt` template.
Expected: gap 12. Visual layout fidelity.
Status: N/A: layout fidelity is listed under "Not covered"; title, columns and totals are covered by the cases above.

### T17 Keyboard and usability

### stock-report.keyboard.dimension-letters   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Focus any control and press G, then I, then P.
Expected: gap 10. G runs Group, I runs Item, P runs Product and each moves focus to its button (`RP_STOCK.cs:3971 {{if ((int)keyCode != 71)}}`; I = 73 and P = 80 in the same handler); the form handles keys because `KeyPreview` is on (`RP_STOCK.cs:2797 {{((Form)this).KeyPreview = true;}}`).
Typed letters are upper-cased and apostrophes dropped (`RP_STOCK.cs:3948 {{if (num == 0 || num == 39)}}`). No keys exist for Design, Safe, Counter, Trading or Size.
Status: executable

### stock-report.keyboard.arrows-and-escape   (T17 Keyboard/usability)
Layer: browser
Steps: 1. After a summary, press Up then Down from the search box. 2. Press Esc on the summary.
Expected: gap 10. Up (38) or Down (40) moves focus to the grid (`RP_STOCK.cs:4009 {{if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))}}`); Esc with the summary showing closes the screen (`RP_STOCK.cs:4006 {{((Form)this).Close();}}`).
Status: executable

### stock-report.keyboard.full-run-without-mouse   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Keyboard only: set From and To (Enter after each), Item Type, Stock Type, press `I`, move into the grid, Enter on a cell to drill, Esc back, Esc exit. 2. Repeat at 1280×720 and 390×800 widths.
Expected: gap 10. Every step is reachable with the keyboard, focus is visible, the date Enter validates and moves on (`RP_STOCK.cs:5177-5192 {{mFromDt_KeyDown}}`); the grid scrolls inside the viewport and the Total row stays visible.
Status: executable

### stock-report.keyboard.alt-accelerators   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Press Alt with each dimension letter.
Expected: gap 10. Unique accelerators work (G Group, P Product, D Design, R Trading); the duplicated letters (I: Item and InOut; C: Counter and Cancel; S: Safe and Size) behave as the supervisor decides.
Status: blocked: the source does not say which control wins a duplicated Alt letter; unblocks when the supervisor chooses.

### T18 Full journey

### stock-report.journey.build-and-reconcile   (T18 Full journey)
Layer: browser
Steps: 1. Starting from an empty stock, save through the real screens in this order: Item Opening M1–M3, Tag Opening T1–T5, Purchases M9, M11, Sales M10, Sales Return M14, Purchase Return M15, Stock Adjust M16–M17, Tag Cancel T2, Approval Issue T3; insert the counter transfer M12–M13 by fixture.
2. After each save run W1 in all eight dimensions and the identity check. 3. At the end compare every cell with the worked table, the Total row and an independent signed `MAIN_STOCK` query.
Expected: gap 2, 3, 6, 7, 8. After the last save: A 13/126.000, 5/43.000, 2/17.000, 5/36.000, 1/12.000, 14/138.000; B 5/50.000, 1/20.000, 6/70.000; S 100/950.000, 10/95.000, 110/1045.000; Total Closing 130 / 1253.000 (gross 1318.300).
Each intermediate step moves only the columns listed in its T07 case. The independent query of signed `MAIN_STOCK` gives the same 130 pcs, 1253.000 net, 1318.300 gross.
Status: executable

### stock-report.journey.non-tag-movements-are-reported   (T18 Full journey)
Layer: database
Steps: 1. Compare the report with the tag-snapshot view of the same data (rows of `BAR_DETL` in stock).
Expected: gap 6. The report includes loose rows a tag snapshot cannot hold. Item A Closing 138.000 net = loose movements M1 100.000 + M9 40.000 + M16 5.000 − M17 2.000 − M15 20.000 = 123.000, plus the tags in stock (T1 12.000 and T4 3.000 = 15.000, the `BAR_DETL` rows in stock: T2 is cancelled and T3 issued). A report built from `BAR_DETL` alone would show 15.000.
Status: executable

### stock-report.journey.approval-round-trip   (T18 Full journey)
Layer: browser
Steps: 1. Issue T3 (D33), return it (D35), sell it (D36) to CUS1. 2. Run W1 to D40 and a window to D33.
Expected: gap 6, 3. At D33 (window to D33): Outward 5 / 36.000 including T3, Closing 14 / 138.000. After the return (D35): Inward 3 / 25.000, Closing 15 / 146.000. After the sale of T3 (D36): Sale 2 / 20.000 (M10 12.000 + 8.000),
Inward 3 / 25.000, Outward 5 / 36.000, Closing 13+5+3−5−2 = 14 pcs and 126+43+25−36−20 = 138.000 (T3 is out of stock again).
Status: executable

### T15 Config and history (continued)

### stock-report.settings.co-year-and-data-type-from-session   (T15 Config/history)
Layer: database
Steps: 1. Run the report in a session whose company year is the previous year.
Expected: gap 16. Only that year's movements appear (`RP_STOCK.cs:4284 {{A.CO_YEAR = '}}`); the figures of the current year do not leak in.
Status: executable

## Coverage table

| Kind | Cases | Blocked | N/A | Note |
|---|---|---|---|---|
| T01 Entry/defaults | 9 | 0 | 0 | route, caption, defaults, F3, menu rights |
| T02 Field route | 15 | 0 | 0 | every filter, check box, search box, injection |
| T03 Formula sequence | 17 | 1 | 1 | eight dimensions, totals, identity, settings; Item Lot blocked; the `onHandNet()` case is N/A |
| T04 Lookup | 3 | 1 | 0 | code help, stale response; LC box blocked |
| T05 Children | 15 | 1 | 1 | drill-downs, fine, zoom; merged/other-LC zoom blocked; non-Lite books N/A |
| T06 Required/invalid | 5 | 1 | 0 | messages, empty result; date text blocked |
| T07 Create | 10 | 0 | 0 | one case per source screen plus the transfer fixture |
| T08 Reopen/no-op | 3 | 0 | 0 | writes nothing, same result twice, cancel |
| T09 Edit | 2 | 0 | 0 | quantity, date |
| T10 Delete/cancel/reverse | 2 | 0 | 0 | sale and return deletion, approval return |
| T11 Scope/rights | 3 | 1 | 0 | tenant sentinel, company merge; List right blocked |
| T12 Concurrency | 2 | 0 | 1 | two users printing; save-during-run N/A |
| T13 Retry/unknown | 1 | 0 | 1 | N/A: reads are idempotent, the web writes nothing |
| T14 Rollback | 1 | 0 | 1 | N/A: no write set |
| T15 Config/history | 5 | 1 | 0 | gross setting, master edit, cancelled tag, year; EMP ISU blocked |
| T16 Report/output | 9 | 2 | 1 | Safe template missing and LC print blocked; layout N/A |
| T17 Keyboard/usability | 4 | 1 | 0 | letters, arrows, keyboard-only run; duplicate Alt letters blocked |
| T18 Full journey | 3 | 0 | 0 | build and reconcile, non-tag movements, approval round trip |
| **Total** | 109 | 9 | 6 | |

A case that names two kinds is counted once, under the first. The N/A column counts cases written with an N/A reason; no kind is dropped silently. Every kind T01 to T18 has at least one case.
Blocked cases stay in the denominator with the reason written beside the status line.

## Gap coverage

1 route and menu: entry.route-and-caption, entry.tag-stock-stays-separate, entry.menu-needs-view-right, entry.f3-shortcut, scope.second-tenant-sentinel.
2 dimensions: formula.dimension-* (eight), formula.counter-blank-is-001, formula.rows-split-by-metal.
3 date columns: filter.date-range, formula.item-dimension-w1, formula.total-row, formula.closing-identity-per-row.
4 filters: filter.* (account, tag, item type, stock type, product, group, item code, design, safe, counter, lc).
5 gross box: filter.gross-check-box, entry.default-gross-from-setting, config.gross-setting-changes-default-only.
6 data source: formula.closing-identity-per-row, journey.non-tag-movements-are-reported, create.* (all nine).
7 fine: drill.opening-signed-total, drill.sale-uses-itm-fine, drill.tag-filter-fine, drill.closing-signed-total.
8 drill-down: drill.* (nine).
9 voucher zoom: zoom.* (four).
10 keys: keyboard.* and drill.back-and-escape.
11 search, Total row, blank zeros: filter.item-name-search, formula.total-row, formula.item-dimension-w1.
12 print and export: output.* and concurrency.two-users-print.
13 InOut ledger print: output.item-ledger-print, invalid.item-picker-nothing-ticked.
14 rights and messages: invalid.print-without-right, invalid.print-right-no-rights-row, zoom.item-opening-refused, zoom.needs-target-read-right, entry.menu-needs-view-right.
15 EMP ISU: config.emp-isu-adjustment (blocked, with the arithmetic worked out).
16 settings: entry.default-gross-from-setting, entry.item-type-default-silver, formula.data-type-filter, scope.company-merge-isolation, formula.dimension-item-lot.
17 caption: entry.route-and-caption.

## Test data

Smallest seed, described (no SQL):
- One tenant `feature-e2e`, one company (type not `P`), one location, current year `2026-27` (`Y0 = 01/04/2026`; clock fixed to `Y0 + 60 days` or later); settings at Lite defaults (`STK_RPT_TYPE` N, metal Gold, no LC box, no merge, no lot).
- Masters: groups GR-A `GOLD ORNAMENTS` (trading type TR1 `GOLD TRADE`) and GR-S `SILVER ARTICLES` (TR2 `SILVER TRADE`); products PR-A `RING`, PR-B `CHAIN`, PR-S `BOWL`; items A, B, S per section 1 (B with a blank own trading type); counters 001 `CNT-ONE`, 002 `CNT-TWO`;
  parties SUP1 and CUS1; one user with every right and users with View only, with no Print, with Sales View revoked, and with no rights row.
- Vouchers M1–M19 of section 1 posted through their real screens except M12 and M13 (fixture insert, `TR_TYPE` T, counters 001 and 002).
- Extras used by single cases: one movement dated tomorrow (future-dated warning); a second location LC2 with 999 pcs (isolation); an item-A purchase with data type `B`; a previous-year purchase of 50 pcs; 600 one-piece openings (large result);
  a hidden item (`STK_DISPLAY` N); a second company in the tenant with `CO_STK_MERGE` Y; a second tenant with the same codes and 1000-piece movements; an `EMP ISU` fixture (blocked).
- Gross figures need the weights of section 1 exactly; every expected figure above is computed from these rows.

## Not covered

1. **`onHandNet()` difference (separate defect for the supervisor).** `apps/api/src/modules/stock/stock.ts` `onHandNet()` signs `ITM_FINE` for both signs and has no dates or dimensions; the report gets its own resolver (decision 3) and is not allowed to call the helper. The helper keeps feeding other screens; fixing or retiring it is not part of this packet. `stock-report.formula.onhandnet-differs` is N/A for that reason.
2. **Layout fidelity** of every Crystal print (fonts, page breaks, headers); the Crystal templates are not executable in the web. Title, columns and totals are covered.
3. **Late-bound Excel automation** of the desktop; the web exports CSV or XLSX with the same rows, rounding and Total row.
4. **`ItmStkBalance`**: no line of the form links it; no case.
5. **Registration-serial branches** (`HM303NEKU`, `DD008NPDD`, `VK178NEVK`, `HM427NEHP`, `HM641NUKU`) and `btnWithOth` (`OthDtl`): hard-coded customer behaviour, not ported.
6. **Elaborate drill-down branch and elaborate summary for `EMP ISU` with `RATE_CUT_ISU` rows** (`RP_STOCK.cs:2976 {{AND F.BOOK_NAME = 'EMP ISU' AND F.TAG_NO <> 'N' AND F.VCH_DATE <}}` (lines 2968 to 3146) and the `EmOpSl` family): only the simple case with no `RATE_CUT_ISU` rows is worked out, and it is blocked (see `stock-report.config.emp-isu-adjustment`).
7. **`MsCoStockMerge` company merge** beyond the tenant-isolation case, and the **LC box** (`MsLcBoxShow`) cases: outside Lite; blocked cases are marked.
8. **`DC_Main.SetDate` rule text** for invalid dates: not read; `stock-report.invalid.bad-date-text` is blocked.
9. **Desktop weakness 7** (ticking the gross box does not refresh): asserted as the desktop behaviour in `filter.gross-check-box`; whether the web should keep or improve it is for the supervisor.
10. **`TR_TYPE` values other than P, I, O, S, T** (open question 4 of the study): the fixture seeds none; an aggregate over a real database was not run (rule: aggregate queries only).
11. **Sale of a loose line weight rule** (`Ac_Stock.cs:112 {{DC_Main.MsStockRptView, "OLD", false) == 0, (object)"A.ITM_GWT", (object)"A.TAG_GWT"}}`): the seed sells a tagged item whose tag and line weights are equal, so the setting `STK_RPT_VIEW` is not varied.
12. **Alt-letter conflicts**, **ItemLedger content** beyond the Closing of the ticked item, and **Item Lot** figures: blocked or unspecified in the source.
