# WP-16 study: Report → Stock Report (desktop `RP_STOCK`) and the web today

Paths: desktop files are in `unified/src/csharp/DataCareNext/`. Web paths are relative to `web/`.
"Line" numbers are 1-based lines of the decompiled source. Where I did not open the lines, the text says so.

## Scope

- **Menu caption:** Report → Stock Report. Desktop form `RP_STOCK` (6,408 lines in the index; the catalog calls it 6,407).
  The summary engine is `Stock_Summ` (`RP_STOCK.cs:4277 {{private void Stock_Summ(string RptType)}}`), the grid fill is
  `DGV_FILL` (`RP_STOCK.cs:4695 {{private void DGV_FILL()}}`), the drill-down is `DGV_DoubleClick`
  (`RP_STOCK.cs:2816 {{private void DGV_DoubleClick(object sender, EventArgs e)}}`).
- **Menu dispatch:** `MDI_FORM.cs:8881 {{case "Stock Report":}}` creates the form with `MDI_FORM.cs:8883 {{RP_STOCK rP_STOCK = new RP_STOCK();}}`
  and sets the window text with `MDI_FORM.cs:8886 {{((Form)rP_STOCK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);}}`.
  The menu-level rights check happens before this dispatch; I did not read it (see Open questions).
- **F3 entry (`MDI_FORM.cs:5574 {{"F3     Stock Report "}}`):** handler `ShoF3Stock_Click` sets the rights key itself with
  `MDI_FORM.cs:13946 {{DC_Main.MsUserRightForm = "Stock Report";}}`, then reads `USER_SET` with an extra `FRM_VIEW = 'Y'` condition. If no row is found it
  shows `MDI_FORM.cs:13952 {{You Have No Rights.....}}` (five dots) and shows `PanelImage`, then returns. On success it calls `PanalImage_Hide()`,
  creates the same `RP_STOCK` and names the window with `MDI_FORM.cs:13957 {{RP_STOCK rP_STOCK = new RP_STOCK();}}` followed by
  `MDI_FORM.cs:13962 {{((Form)rP_STOCK).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);}}`.
  So F3 differs only in (a) an explicit `FRM_VIEW='Y'` check with its own message and (b) the window title uses the rights key "Stock Report" instead of `MsSideBtn`.
  The form itself then loads the same way.
- **Editions:** `RP_STOCK.cs` contains no `MsSoftType` check (searched: no match). The menu row is in the Lite edition (`docs/handbook/menu-editions.json`, entry
  "Stock Report", `"edition": "L"`). All eight dimensions are therefore available in Lite. Registration-serial special cases exist and are listed under Open questions.
- **Template named in the packet:** `ItmStkBalance.rpt` does not occur in `RP_STOCK.cs` or `MDI_FORM.cs`. MISSING: any source that links that template to this form.
  The templates the form really uses are in the Print section.
- **Out of scope:** Tag Stock (`RP_TAG`), the UAE variant, `RP_STOCK_FINE` and `RP_STOCK_VALUE` (separate forms with their own layouts), code and tests.

## Screen

Controls come from `InitializeComponent` (`RP_STOCK.cs lines 1535-2811`). Tab indices are the designer values; the form does not set a custom tab order in code.

| Control | Caption (source) | Type | TabIndex | Notes |
|---|---|---|---|---|
| `lblBook` | `RP_STOCK.cs:2049 {{Stock Report}}`-title label | Label | 6 | Form title. |
| `mFromDt` | Date (`Label2`) | MaskedTextBox | 0 | Default `RP_STOCK.cs:3705 {{mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);}}` (opening date of the year). |
| `mToDt` | (same row) | MaskedTextBox | 1 | Default `RP_STOCK.cs:3706 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}` (system date). |
| `tSerchAll` | (no caption) | DevExpress TextEdit | 2 | Name filter over the result grid, see Keyboard/Rules. |
| `cboItemTyp` | `Label3` "Item Type" | ComboBox | 3 | Items: blank, Gold, Silver, Diamond, Real Stone, Emitation, Other, Platinum (`RP_STOCK.cs lines 3620-3627`). Default Gold when `MsMetalType` is G, else Silver (`RP_STOCK.cs:3628 {{if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)}}`). |
| `cboStockType` | `Label1` "Stock Type" | ComboBox | 4 | Items `RP_STOCK.cs:3636 {{cboStockType.Items.Add((object)"All");}}`, Tag, Item. Default All (index 0) except registration `DD008NPDD`, which starts on Tag (`RP_STOCK.cs line 3639`). |
| `BtnItem` | `&Item` | Button | 5 | Dimension Item. |
| `BtnProduct` | `&Product` | Button | 6 | Dimension Product. |
| `BtnGroup` | `&Group` | Button | 7 | Dimension Group. |
| `BtnDesign` | `&Design` | Button | 8 | Dimension Design. |
| `BtnSafe` | `&Safe` (renamed "Item Lot" when `MsItmWitLotStk` or `MsMeltingLotGenrate` is Y: `RP_STOCK.cs:3703 {{BtnSafe.Text = "Item Lot";}}`) | Button | 9 | Dimension Safe / Lot. |
| `BtnTable` | `&Counter` | Button | 10 | Dimension Counter (table). |
| `BtnTrading` | `T&rading` | Button | 11 | Dimension Trading type. |
| `BtnSiz` | `&Size` | Button | 1177 | Dimension Size. |
| `chkWtType` | `RP_STOCK.cs:2576 {{((ButtonBase)chkWtType).Text = "Gross Wise Weight";}}` | CheckBox | 1136 | Default unchecked; checked when `MsStkRptType` is G: `RP_STOCK.cs:3647 {{if (Operators.CompareString(DC_Main.MsStkRptType, "G", false) == 0)}}`. |
| `tGrCode` | `Label10` "Gr Code" | TextBox | 1166 | Group filter, Enter opens help. |
| `tPrCode` | `Label9` "Pr Code" | TextBox | 1163 | Product filter. |
| `tItCode` | `Label8` "It Code" | TextBox | 1180 | Item filter. |
| `tDesignNo` | `Label11` "Design" | TextBox | 1182 | Design filter. |
| `cboSafe` | `Label14` "Safe" | ComboBox | 1170 | Filled from `SELECT SAFE_NAME FROM ITEM_MAST ... GROUP BY SAFE_NAME`, first entry blank (`RP_STOCK.cs line 3655`). |
| `cboTable` | `Label5` "Counter" | ComboBox | 1172 | Filled from `TABLE_MAST` for the company and LC, first entry blank (`RP_STOCK.cs line 3669`). |
| `tTagNo` | `Label6` "TagNo" | TextBox | 1174 | Exact tag filter. |
| `tAcCode` | `Label7` "AcCode" | TextBox | 1178 | Account filter. |
| `tLcCode` | (hidden) | TextBox | 1176 | Visible only when `MsLcBoxShow` (`RP_STOCK.cs line 3693`); default is the current LC (`RP_STOCK.cs:3692 {{tLcCode.Text = DC_Main.MLc_code;}}`), so the LC filter is applied even while the box is hidden. |
| `BtnPrint` | `Print` | Button | 0 (bottom panel) | |
| `BtnSave` | `Excel` | Button | 1 | Excel export, Print-right protected. |
| `BtnCancel` | `&Cancel` | Button | 2 | Clears the form (`CLEAR_DATA`). |
| `BtnDelete` | `RP_STOCK.cs:1977 {{&InOut}}` | Button | 3 | Opens the item picker panel (`PnlIt`) for the item-ledger print. |
| `BtnExit` | `E&xit`; becomes `&Back` while a drill-down is open | Button | 4 | |
| `btnWithOth` | `OthDtl` | Button | 11 | Hidden by default; shown only for three registration serials (`RP_STOCK.cs line 3697`). |
| `DGV` | summary grid | DataGridViewX | 2 | 22 columns, see Calculations. |
| `DGV_VCH` | movement grid (drill-down), visible instead of `DGV` | DataGridViewX | n/a | 16 columns, see Lifecycle. |
| `PnlIt` / `DGV_ITM` / `btnAll` / `btnOk` / `btnItCancel` | item picker: check column "Ok", "Sr", "Itm Name", "It Code" | panel | 1206 | Hidden until `BtnDelete` is pressed. |

Summary grid columns (`RP_STOCK.cs:4727 {{((DataGridView)DGV).ColumnCount = 22;}}`): 0 SrNo, 1 Code (hidden), 2 "Item Name" (shows the name of whichever dimension is active),
3 ItType (hidden), 4/5 OpPcs/OpWt, 6/7 PrPcs/PrWt, 8/9 InPcs/InWt, 10/11 OutPcs/OutWt (captions "OuPcs"/"OuWt"), 12/13 SlPcs/SlWt, 14/15 ClPcs/ClWt, 16-19 TuOPcs/TuOWt/TuInPcs/TuInWt (hidden),
20/21 TPanPcs/TPanWt (hidden, no data property). Weight columns carry `RP_STOCK.cs:4757 {{DefaultCellStyle.Format = "N3"}}` (the same format on every weight column, 4757-4799).
Zero values in columns 4-21 display as blank (`RP_STOCK.cs:3790 {{((ConvertEventArgs)e).Value.ToString(), "0", false) == 0}}`).

Drill-down grid headers (`RP_STOCK.cs:3081 {{((DataGridView)DGV_VCH).ColumnCount = 16;}}`): SrNo, Vchtype, Party Name, VchNo, VchDate, TagNo (or "Itm Lot"), ItName, Pcs, GrWt, NetWt, Fine, Sign, then four hidden columns Book, BooKName, ItCode, AcCode.

## Keyboard

- Form key press: every typed character is upper-cased; NUL and the apostrophe are swallowed (`RP_STOCK.cs:3948 {{if (num == 0 || num == 39)}}`).
- Form key down (`RP_STOCK_KeyDown`, `RP_STOCK.cs line 3954`): key code 71 (G) runs `BtnGroup_Click` (`RP_STOCK.cs:3971 {{if ((int)keyCode != 71)}}`), 73 (I) runs `BtnItem_Click`, 80 (P) runs `BtnProduct_Click`; each then focuses its button.
  There are no keys for Design, Safe, Counter, Trading or Size. The dimension keys fire from any control because the code is on the form (the form's `KeyPreview` value was not read; see Open questions).
- Esc (27, `RP_STOCK.cs:3992 {{if ((int)e.KeyCode == 27)}}`): when `BtnExit.Text` is `&Back` it closes the drill-down and shows the summary grid again; otherwise it closes the form (`RP_STOCK.cs:4006 {{((Form)this).Close();}}`).
- Up (38) or Down (40) moves focus to `DGV` (`RP_STOCK.cs:4009 {{if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))}}`).
- Date boxes: Enter runs `DC_Main.SetDate`; if the date is valid it sends Tab (`RP_STOCK.cs lines 5177-5192`, `RP_STOCK.cs lines 5193-5208`).
- Enter in `tPrCode`, `tGrCode`, `tItCode`, `tDesignNo`, `tAcCode`, `tLcCode`: validates the code against its master; when it is not found, opens the `MS_HELP` list and writes the selected code back
  (`RP_STOCK.cs:5730 {{Select * From PRODUCT_MAST WHERE CO_CODE}}`, `RP_STOCK.cs:6011 {{Select * From LOCT_MAST WHERE  CO_CODE}}`, `RP_STOCK.cs:6188 {{Select DESIGN_NO From MAIN_STOCK WHERE CO_CODE}}`).
- Double click on a summary cell opens the drill-down for that cell's column (see Lifecycle); double click on a movement row zooms to the voucher (`DGV_VCH_DoubleClick`, `RP_STOCK.cs line 5221`).
- `tSerchAll` text change: empty text refills the full grid (`DGV_FILL()`); otherwise filters `RsStkSum` by name: `RP_STOCK.cs:3837 {{dataView.RowFilter = "Name Like  '%" + ((TextEdit)tSerchAll).Text + "%' ";}}`.
- Alt-letter accelerators come from the `&` in the captions: Exit E, InOut I, Cancel C, Back B, Group G, Product P, Item I, Design D, Safe S, Counter C, Trading R, Size S.
  (Alt+I and Alt+C, Alt+S are shared by two captions each; the source does not say which wins.)
- Choosing a dimension button or ticking Gross Wise Weight clears an open drill-down (`RP_STOCK.cs:5710 {{private void chkWtType_Click(object sender, EventArgs e)}}`). Note: ticking the box does NOT refresh the summary; the operator must press a dimension button again.

## Rules

| Rule | Exact message | Source | Focus after |
|---|---|---|---|
| Excel without print right | `You Have No Print Rights.....` (five dots) | `RP_STOCK.cs:3237 {{You Have No Print Rights.....}}` | Not set; returns. |
| Print without print right | same text | `RP_STOCK.cs:4024 {{You Have No Print Rights.....}}` | Not set; returns. |
| OthDtl print without print right | same text | `RP_STOCK.cs:6218 {{You Have No Print Rights.....}}` | Not set; returns. |
| Zoom into a voucher the user may not view | `You Have No Rights...` (three dots) | `RP_STOCK.cs:5248 {{You Have No Rights...}}` | Stays on the movement grid. |
| Zoom into an item-wise opening voucher (voucher number shorter than 3 characters) | `This Is a Item Wise Opening Stock Voucher You Cant Zoom ....` | `RP_STOCK.cs:5263 {{This Is a Item Wise Opening Stock Voucher You Cant Zoom ....}}` | Stays on the movement grid. |
| Item picker confirmed with nothing ticked | `Item Selection Not Done...` | `RP_STOCK.cs:5942 {{Item Selection Not Done...}}` | The picker panel is hidden. |
| Safe print offers the summary template | `Safe Wise Summ Report` (a Yes/No box; Yes = 6) | `RP_STOCK.cs:4172 {{Safe Wise Summ Report}}` | n/a |
| Future-dated entries exist | `Please Check Voucher Date in Entry Because Entry Date > Curent Date... Book = ` followed by book name, ` And VchNo = ` and the number (the tail of the line was not copied; read it from the source) | `RP_STOCK.cs:3713 {{Please Check Voucher Date in Entry Because Entry Date > Curent Date... Book = }}` | `mToDt` is set to that voucher's date, and `CurActCtrl` becomes `mFromDt` (`RP_STOCK.cs line 3717`). |

There is no check that the from date is not after the to date, and no message for an empty result. An empty result simply leaves the grid blank: `RP_STOCK.cs:4712 {{if (dataView.Count <= 0)}}`.

## Calculations

All numbers are plain SUMs in SQL, with no rounding in the query. The only rounding calls are the display format "N3" and the Excel export `Math.Round(..., 3)` (`RP_STOCK.cs:3306 {{Math.Round(Convert.ToDouble(((DataGridView)DGV)[l, DC_Main.i].Value.ToString()), 3)}}`).
There is NO fine column, no touch/purity multiplication and no loss/ghat column in the summary grid: fine is shown only in the drill-down (below). Nothing in `RP_STOCK.cs` computes net × touch / 100; the fine values are the stored `KR_FINE` and `ITM_FINE` of `MAIN_STOCK`.

**Weight basis.** `RP_STOCK.cs:4280 {{string text2 = ((!chkWtType.Checked) ? "A.ITM_NWT" : "A.ITM_GWT");}}`: unchecked = net, checked = gross, for every weight column.

**Row set (every dimension).** `FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)` plus one dimension-specific join, `WHERE`:
- company: `A.CO_CODE = '<code>'` unless `MsCoStockMerge` is Y (`RP_STOCK.cs:4284 {{DC_Main.MsCoStockMerge, "Y", false) == 0, (object)""}}`),
- LC: `A.LC_CODE = '<tLcCode>'` when the box is not empty,
- year: `A.CO_YEAR = '<MCo_year>'`,
- data type: `AND A.DATA_TYPE = '<MsDataType>'` unless `MsDataType` is C (`RP_STOCK.cs:4284 {{AND A.DATA_TYPE = '" + DC_Main.MsDataType}}`),
- items marked hidden are excluded: `RP_STOCK.cs:4284 {{ AND B.STK_DISPLAY <> 'N'}}`.
Because every column is a conditional SUM over the same rows, a movement is counted under exactly the dimension value of its own row.

**Per-column formulas** (the Group query at `RP_STOCK.cs line 4284`; the other seven dimensions repeat it with a different key). Let FROM = the from date and TO = the to date, both formatted `MM/dd/yyyy`, `W` = the weight column above:
- Opening pcs/wt (OpPcs, OpWt): rows with `A.VCH_DATE <  FROM`, signed: `{{THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END)}}`.
  Every row dated before FROM counts, in this company, LC and year only (there is no lower bound other than the year filter).
- Purchase (PrPcs, PrWt): `FROM <= VCH_DATE <= TO`, only rows with `ITM_SIGN = '+' AND TR_TYPE = 'P'`, unsigned.
- Inward (InPcs, InWt): `ITM_SIGN = '+' AND TR_TYPE = 'I'`, unsigned.
- Outward (OutPcs, OutWt): `ITM_SIGN = '-' AND TR_TYPE = 'O'`, unsigned (positive numbers).
- Sale (SlPcs, SlWt): `ITM_SIGN = '-' AND TR_TYPE = 'S'`, unsigned.
- Transfer in (TInPcs, TInWt): `ITM_SIGN = '+' AND TR_TYPE = 'T'`; transfer out (TOutPcs, TOutWt): `ITM_SIGN = '-' AND TR_TYPE = 'T'`. Both are loaded into hidden columns 16-19 and appear only in the totals row and the print.
- Closing (ClPcs, ClWt): `A.VCH_DATE <=  TO`, signed, with no lower bound: `RP_STOCK.cs:4284 {{AS ClPcs}}` is `SUM(CASE WHEN A.VCH_DATE <= TO THEN (CASE WHEN ITM_SIGN = '+' THEN W ELSE -W END) ELSE 0 END)`.
  The closing figure is computed independently of the other columns. It equals Opening + all signed movements to TO. It equals Opening + Pr + In − Out − Sl ± Tr only when every movement has one of the TR_TYPE values P, I, O, S, T; any other `TR_TYPE` still reaches Opening and Closing but no middle column.
- Row order: by the dimension's name column (`ORDER BY C.GR_NAME` etc., see below).

**Dimensions** (`StkType` is set by each button; each calls `Stock_Summ(<name>)` and then `DGV_FILL()`):

| Button | `StkType` / `Stock_Summ` case | Code column (hidden) → Name column | Extra join | GROUP BY / ORDER BY |
|---|---|---|---|---|
| Group | Group | `B.GR_CODE` → `C.GR_NAME` | `LEFT JOIN GROUP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.GR_CODE` | `RP_STOCK.cs:4329 {{GROUP BY B.GR_CODE,C.GR_NAME,B.IT_TYPE ORDER BY C.GR_NAME}}` |
| Product | Product | `B.PR_CODE` → `C.PR_NAME` | `LEFT JOIN PRODUCT_MAST AS C` on `PR_CODE` | `RP_STOCK.cs:4378 {{GROUP BY B.PR_CODE,C.PR_NAME,B.IT_TYPE ORDER BY C.PR_NAME}}` |
| Item | Item | `B.IT_CODE` → `B.IT_NAME` | none | `RP_STOCK.cs:4427 {{GROUP BY B.IT_CODE,B.IT_NAME,B.IT_TYPE ORDER BY B.IT_NAME}}` |
| Safe | ItmSafe | `B.SAFE_NAME` → `B.SAFE_NAME` | none | `RP_STOCK.cs:4489 {{GROUP BY B.SAFE_NAME,B.SAFE_NAME,B.IT_TYPE ORDER BY B.SAFE_NAME}}` |
| Item Lot (same button when `MsItmWitLotStk` or `MsMeltingLotGenrate` is Y) | ItmSafe | `A.ITM_LOT` → `A.ITM_LOT` | none | `RP_STOCK.cs:4485 {{GROUP BY A.ITM_LOT,A.ITM_LOT,B.IT_TYPE ORDER BY A.ITM_LOT}}` |
| Size | ItmSize | `A.ITM_SIZE` → same | none | `RP_STOCK.cs:4539 {{GROUP BY A.ITM_SIZE,A.ITM_SIZE,B.IT_TYPE ORDER BY A.ITM_SIZE}}` |
| Design | Design | `A.DESIGN_NO` → same | none | `RP_STOCK.cs:4588 {{GROUP BY A.DESIGN_NO,A.DESIGN_NO,B.IT_TYPE ORDER BY A.DESIGN_NO}}` |
| Counter | Table | `A.TBL_CODE` → `C.TABLE_NAME` | `LEFT JOIN TABLE_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TBL_CODE = C.TABLE_CODE` | `RP_STOCK.cs:4637 {{GROUP BY A.TBL_CODE,C.TABLE_NAME,B.IT_TYPE ORDER BY C.TABLE_NAME}}` |
| Trading | Trad | `B.TRAD_TYPE` → `C.TRAD_NAME` | `LEFT JOIN BAL_GR AS C ON B.CO_CODE = C.CO_CODE AND B.TRAD_TYPE = C.TRAD_TYPE` | `RP_STOCK.cs:4688 {{GROUP BY B.TRAD_TYPE,C.TRAD_NAME,B.IT_TYPE ORDER BY C.TRAD_NAME}}` |

Every dimension also groups by `B.IT_TYPE`, so one name can yield several rows (one per metal type) when the Item Type filter is blank.
The Group case is the first to be dispatched; the dispatch for `StkType` buttons is `RP_STOCK.cs:5139 {{StkType = "Group";}}`, `RP_STOCK.cs:5156 {{StkType = "Product";}}`, `RP_STOCK.cs:5173 {{StkType = "Item";}}`,
`RP_STOCK.cs:5800 {{StkType = "Table";}}`, `RP_STOCK.cs:5817 {{StkType = "Design";}}`, `RP_STOCK.cs:5834 {{StkType = "ItmSafe";}}`, `RP_STOCK.cs:5851 {{StkType = "Trad";}}`, `RP_STOCK.cs:6088 {{StkType = "ItmSize";}}`.
The Trading case first runs a write (see Lifecycle).

**Filters** (all appended with `AND`, identical in every case; Trading builds the same list in a different order):
- Stock Type "Tag": `RP_STOCK.cs:4287 {{DC_Main.RsQry += "AND A.TAG_NO <> 'N'";}}`; "Item": `RP_STOCK.cs:4291 {{DC_Main.RsQry += "AND A.TAG_NO = 'N'";}}` (the value `N` is the "no tag" marker; All adds nothing).
- Account: `RP_STOCK.cs:4295 {{"AND A.AC_CODE =  '" + tAcCode.Text + "'"}}`.
- Tag no: `RP_STOCK.cs:4299 {{"AND A.TAG_NO =  '" + tTagNo.Text + "'"}}`.
- Item Type (when not blank): `RP_STOCK.cs:4303 {{"AND  B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"}}` (first letter, so Gold=G, Silver=S, Diamond=D, Real Stone=R, Emitation=E, Other=O, Platinum=P).
- Product: `RP_STOCK.cs:4307 {{"AND B.PR_CODE =  '" + tPrCode.Text + "'"}}`; Group: `RP_STOCK.cs:4311 {{"AND B.GR_CODE =  '" + tGrCode.Text + "'"}}`.
- Item code: `RP_STOCK.cs:4315 {{"AND A.IT_CODE =  '" + tItCode.Text + "'"}}`; design: `RP_STOCK.cs:4319 {{"AND A.DESIGN_NO =  '" + tDesignNo.Text + "'"}}`.
- Safe: `RP_STOCK.cs:4323 {{"AND B.SAFE_NAME =  '" + cboSafe.Text + "'"}}`; counter: `RP_STOCK.cs:4327 {{"AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'"}}`.
- Note for the Item Type default: the screen opens with Gold (or Silver), so the first summary already filters to that metal.

**Totals.** After the rows, `DGV_FILL` appends two blank rows and writes a "Total :" row (`RP_STOCK.cs:5052 {{((DataGridView)DGV).Rows[num24].Cells[2].Value = "Total :";}}`). Each total is the arithmetic sum of the grid column
(`RP_STOCK.cs line 5028`), including the hidden transfer columns; the sum uses `Conversion.Val` on the cell text, so there is no rounding beyond the "N3" display. SrNo is renumbered from 1 per row. Opening and closing totals are therefore plain sums of signed row values.

**Approval ("EMP ISU") adjustment.** `DGV_FILL` first reads `APR_DETL` rows with `BOOK_NAME = 'EMP ISU'` (`RP_STOCK.cs:4729 {{SELECT VCH_NO FROM APR_DETL WHERE CO_CODE}}`).
When such tag rows exist, for each summary row it re-queries `APR_DETL` and adjusts Opening (cols 4/5), Inward (8/9), Outward (10/11) and Closing (14/15) so that tags issued to staff are reported as out of stock
(`RP_STOCK.cs:4915 {{FROM APR_DETL}}` and the cell updates at `RP_STOCK.cs line 4995`). The full arithmetic (EmOpSl/EmOpWt/EmSlPcs/EmSlWt, TurInPcs/TurInWt) was read but is not restated here; the case-list worker should treat it as a separate conditional block, only active when an `EMP ISU` tag exists.
A registration-specific branch (`RP_STOCK.cs:4869 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "HM303NEKU", false) == 0)}}`) uses a simpler adjustment; out of scope.

## Lifecycle and write set

This is a report. It has no create/edit/delete/cancel. The only writes are housekeeping and print staging:

- **On load** (`RP_STOCK.cs:3651 {{UPDATE ITEM_MAST SET STK_DISPLAY = 'Y' WHERE CO_CODE}}`): sets `STK_DISPLAY='Y'` where NULL; `RP_STOCK.cs:3652 {{UPDATE ITEM_MAST SET SAFE_NAME = 'MAIN' WHERE CO_CODE}}` sets `SAFE_NAME='MAIN'` where NULL;
  `RP_STOCK.cs:3653 {{UPDATE MAIN_STOCK SET TBL_CODE = '001' WHERE CO_CODE}}` sets `TBL_CODE='001'` where NULL or blank. Keys: `CO_CODE` (see weakness 2 for line 3653).
- **On the Trading view** (`RP_STOCK.cs:4641 {{UPDATE A SET A.TRAD_TYPE = B.TRAD_TYPE FROM ITEM_MAST AS A,GROUP_MAST AS B}}`): copies the group's `TRAD_TYPE` onto items where it is NULL or blank, scoped by company, before the select.
- **On Print**, when `EMP ISU` tags exist: `RP_STOCK.cs:4058 {{DELETE FROM REPORT_DATA WHERE CO_CODE}}`, then one `INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1..COL_15)` per grid row except the last two (`RP_STOCK.cs line 4064`),
  SR_NO formatted `0000`, columns COL_1..COL_15 = grid columns 1..15 in order; the template then reads `REPORT_DATA` ordered by `SR_NO` (`RP_STOCK.cs:4069 {{SELECT * FROM REPORT_DATA WHERE CO_CODE}}`).
- **`btnWithOth`** (hidden except three serials) deletes and fills `REPORT_DATA` too (`RP_STOCK.cs line 6222`, inserts at 6351, 6356, 6368, 6373); out of scope.

### Drill-down (double click on a summary cell)

`RP_STOCK.cs lines 2831-2833` hides `DGV`, disables the search box and sets `BtnExit.Text = "&Back"`. The clicked column decides the movement set, and the row's code and item type are the first two conditions:
the dimension key is `C.IT_CODE`, `C.PR_CODE`, `C.GR_CODE`, `C.SAFE_NAME` (or `A.ITM_LOT`), `A.ITM_SIZE`, `A.DESIGN_NO`, `A.TBL_CODE` or `C.TRAD_TYPE` (`RP_STOCK.cs lines 2836-2885`), compared with `((DataGridView)DGV)[1, index].Value` and `C.IT_TYPE` with column 3.
All queries select from `MAIN_STOCK AS A` joined to `BOOK_DATA` (book short name), `ITEM_MAST` and `AC_MAST`:
`RP_STOCK.cs:2896 {{SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_LOT,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT}}`.
Fine in this view: `RP_STOCK.cs:2896 {{CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END As ItmFine}}`; it is the posted fine, taken from `KR_FINE` for inward rows and `ITM_FINE` for outward rows, with no touch computation.

| Columns clicked | Movement set (added to the key, company, LC, data type) | Line |
|---|---|---|
| 4, 5 (Opening) | `A.VCH_DATE < FROM` (`RP_STOCK.cs:2896 {{ AND A.VCH_DATE < '}}`) | 2896 |
| 6, 7 (Purchase) | `RP_STOCK.cs:2900 {{ AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'P' AND A.VCH_DATE >= '}}` and `<= TO` | 2900 |
| 8, 9 (Inward) | `+` and `TR_TYPE = 'I'`, dated FROM..TO | 2904 |
| 10, 11 (Outward) | `-` and `TR_TYPE = 'O'`, dated FROM..TO; ordered by `F.VCH_DATE` (a different alias, see weakness) | 2908 |
| 12, 13 (Sale) | `-` and `TR_TYPE = 'S'`, dated FROM..TO | 2912 |
| 14, 15 (Closing) | `RP_STOCK.cs:2916 {{ AND A.VCH_DATE <= '}}` TO | 2916 |

Any other column (SrNo, name, transfer columns) returns without drilling (`RP_STOCK.cs:2892 {{default:}}`). The same filters as the summary (stock type, account, tag, item, design, product, group, safe, counter) are appended (`RP_STOCK.cs lines 2919-2958`), then `ORDER BY A.VCH_DATE`.
Note the drill-down omits the Item Type combo and applies `ITM_SIGN` text, not the `STK_DISPLAY` rule, so a drill-down total can differ from its summary cell.
Drill-down totals: a "Total :" row under Pcs/GrWt/NetWt/Fine (columns 7-10). For the Opening and Closing clicks (4/5 and 14/15) each row's value is added when Sign (column 11) is `+` and subtracted otherwise (`RP_STOCK.cs:3175 {{if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[11].Value, (object)""), (object)"+", false))}}`);
for the in-period columns all rows are added (`RP_STOCK.cs lines 3200-3227`, final write `RP_STOCK.cs:3220 {{((DataGridView)DGV_VCH).Rows[num6].Cells[7].Value = num;}}` and the next three lines for gross, net and fine).
When `EMP ISU` tags exist (or serial `HM303NEKU`) the other branch `RP_STOCK.cs lines 2968-3146` builds a more elaborate query; not restated.

### Zoom to the voucher (`DGV_VCH_DoubleClick`, `RP_STOCK.cs lines 5221-5709`)

- Skipped when stock is merged across companies, or when the LC box differs from the current LC: `RP_STOCK.cs:5225 {{if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0 || Operators.CompareString(tLcCode.Text, DC_Main.MLc_code, false) != 0)}}`.
- Looks up `BOOK_DATA` for the movement's book (book name, type, item type, `MAIN_BOOK`, short name, in/out, `MENU_NAME`), sets `DC_Main.CurBook*`, reads the voucher number from column 3, then opens the matching entry form chosen by `MAIN_BOOK`.
  Forms named in this block: `TR_TAG_OPBL` (OPSTK, TAG GEN, JDTR TAG, MFG TAG), `TR_TAG_CAN` (TAG CANCEL, STOCK ADJUST), `TR_APR_ISU` (APR ISU, CON REC, CON ISU, APR RTN), `TR_SALE_ORD` (SALES ORDER),
  `TR_SALE_HM` or `TR_SALE` (SALES, depending on `MsSalesWithHmTax`: `RP_STOCK.cs:5318 {{if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)}}`), and further `MAIN_BOOK` values: AMT OUT, B2B PURC, B2B SALES, BILL REC, BUL WH SALE, CARD ADJUST, CON PUR, CUSTREP RECEIPT, E INVOICE, EMP JV, FINE SALE, GHAT REC,
  HEDGING FIX, ITEM SALES, ITM LOT, KARIGAR ISSUE, KARIGAR RECEIPT, LABOUR WORK, LD ADJUST, LOAN INT ENTRY, LOAN ISSUE, LOAN REC, MFG GHAT REC, MFG POLISH REC, MFG STNG ISU, OLD ITEM SALES, OTH COMM, OTH EXP, OTH INC,
  PURC RETURN, PURCHASE, SALES RETURNE, TAG PURCHASE, TAG SPLIT, TAG TRFR, TAG WT CHANGE, TOUR SALES, VP PARCEL, WH RTN, WH SALES (list collected by searching `CurBookMain, "` in the file; the target form of each was not read; the case list worker should read `RP_STOCK.cs lines 5330-5709`).
- The voucher rights check is `USER_SET` with `FRM_VIEW = 'N'` → message (see Rules).

## Print

- **Rights:** `RP_STOCK.cs:3394 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}`; the check is `RP_STOCK.cs:4022 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}`. If `USER_SET` has no row, `UserPrint` stays at its field default (not read), so the result for such a user is not established.
- **Template by dimension** (`RP_STOCK.cs lines 4029-4051`): Group → `RP_STOCK.cs:4032 {{text = "GroupStkRpt";}}`, title text "Group Wise Stock From Date  "; Product → `ProdStkRpt` ("Product Wise Stock From Date  "); Counter (Table) → `TableStkGwtRpt` ("Counter Wise Stock From Date  ");
  Safe → `SafeStkRpt` ("Safe Wise Stock From Date  "); every other dimension (Item, Size, Design, Trading, and also when none was chosen) → `ItemStkRpt` ("Item Wise Stock From Date  ").
  For Safe the form asks `Safe Wise Summ Report` as Yes/No; Yes switches to `SafeStkSumm` (`RP_STOCK.cs:4174 {{DC_Main.RptName = "SafeStkSumm";}}`).
  Template files are in the `Report\` folder: `.RPT` (`RP_STOCK.cs:4216 {{Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + text + ".RPT";}}`).
- **Variant with the grid (`ItmStkWithGrid`)** is used instead when `EMP ISU` tags exist (`RP_STOCK.cs:4083 {{DC_Main.RptName = "ItmStkWithGrid";}}`, or `ItmStkWithGrid.RPT` at 4090): it reads `REPORT_DATA` (selection `RP_STOCK.cs:4091 {{CurFormula = "{REPORT_DATA.CO_CODE} = '"}}`), which holds the grid as shown, so the figures are the grid figures.
- **Parameters:** `RptTitel` (e.g. `RP_STOCK.cs:4224 {{Cr[(short)0] = "RptTitel = '" + text2 + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")}}`; with an LC box shown it is prefixed by `'Branch - <LC> '`),
  `FromDate` and `ToDate` as Crystal `Date(y,m,d)` values (`RP_STOCK.cs:4226 {{Cr[(short)1] = "FromDate = Date("}}`, `RP_STOCK.cs:4227 {{Cr[(short)2] = "ToDate = Date("}}`). For the web renderer (`MsCrystalRptType` = N) the same three are set as named formulas (`RP_STOCK.cs:4195 {{DC_Main.MsCrForName1 = "FromDate";}}`).
- **Selection formula** (`RP_STOCK.cs lines 4119-4166`): `{MAIN_STOCK.CO_YEAR}` and `{MAIN_STOCK.VCH_DATE} <= #TO#` (`RP_STOCK.cs:4125 {{CurFormula = "{MAIN_STOCK.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MAIN_STOCK.CO_YEAR} = '"}}`; company condition dropped when stock is merged),
  then optional counter, LC, stock type, item type, product, group and safe, then data type. It does NOT carry the account, tag, item code or design filters, nor the gross-weight check box. So the print can differ from the screen when those filters are used.
  The template, not this form, computes opening, in, out and closing from `FromDate`/`ToDate`.
- **Excel** (`BtnSave`, `RP_STOCK.cs lines 3232-3340`): late-bound `Excel.Application`, header row from the visible grid (`DGV_VCH` when `BtnExit.Text` is `&Back`, otherwise `DGV`), numeric cells written as `Math.Round(value, 3)`, other cells as text. Needs the print right.
- **Item ledger print (`BtnDelete` "InOut" → `btnOk`):** template `ItemLedger.RPT` (`RP_STOCK.cs:5952 {{ItemLedger.RPT}}`), formula `{MAIN_STOCK.IT_CODE} in [<ticked items>]` with `VCH_DATE <= TO` (`RP_STOCK.cs:5958 {{CurFormula = CurFormula + " And {MAIN_STOCK.IT_CODE} in [" + SelectIt + "]";}}`). The item picker lists items of the chosen Item Type (`RP_STOCK.cs:5879 {{SELECT A.IT_CODE,A.IT_NAME FROM ITEM_MAST  AS A}}`).
- `ItmStkBalance.rpt`: MISSING (not named anywhere in the form).

## Rights

- Form rights are read once on load from `USER_SET` (`RP_STOCK.cs:3387 {{Select * From USER_SET WHERE LC_CODE}}`): `FRM_EDIT`, `FRM_DELETE` and `FRM_PRINT` go to `UserEdit`, `UserDelete`, `UserPrint` (`RP_STOCK.cs lines 3392-3394`). Only `UserPrint` is used in this form.
- Print, Excel and OthDtl need `UserPrint = Y`; message `You Have No Print Rights.....`.
- Zoom needs `FRM_VIEW` not equal `N` on the voucher's own menu row; message `You Have No Rights...` (`RP_STOCK.cs:5245 {{FRM_VIEW"], (object)""), (object)"N", false))}}`). A missing row allows the zoom.
- F3 entry needs a `USER_SET` row with `FRM_VIEW='Y'` (message `You Have No Rights.....`, `MDI_FORM.cs line 13952`).
- The catalog's rights string is `----PL` (View/Print/List only).

## Desktop weaknesses not to port

1. SQL is built by joining strings with the operator's text: `RP_STOCK.cs:4295 {{"AND A.AC_CODE =  '" + tAcCode.Text + "'"}}` (every filter; injection and quote-breaking input). The web must use parameters.
2. Unscoped write: `RP_STOCK.cs:3653 {{UPDATE MAIN_STOCK SET TBL_CODE = '001' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TBL_CODE IS NULL OR TBL_CODE = ''}}` — the `OR` makes the blank-counter half apply to every company. A report must not write this at all.
3. A report that writes masters: the three `UPDATE`s at load (3651-3653) and the Trading `UPDATE` (4641) change `ITEM_MAST` and `MAIN_STOCK` merely by opening the screen or a view. Backfill belongs to migration, not a read.
4. `REPORT_DATA` staging with a company-wide `DELETE` then per-row `INSERT` from the grid text (4058-4065): two users printing at the same time overwrite each other, and the print shows unvalidated grid text. Not to be ported; the web prints from the query.
5. The drill-down is a different query from the summary: no `STK_DISPLAY <> 'N'` and no Item Type filter (2919-2958 versus 4284), and its outward query orders by an alias `F` that exists only in the second branch (`RP_STOCK.cs:2961 {{DC_Main.RsQry += "ORDER BY F.VCH_DATE ";}}`). Summary cell and detail total should agree in the web.
6. Print selection ignores the account, tag, item and design filters and the gross-weight check box (4119-4166), so print can differ from the screen.
7. Ticking "Gross Wise Weight" does not refresh the result (`RP_STOCK.cs line 5712`), so the screen can show net while the box shows gross.
8. Registration-serial special cases (`HM303NEKU`, `DD008NPDD`, `VK178NEVK`, `HM427NEHP`, `HM641NUKU`) hard-code individual customers: `RP_STOCK.cs:3697 {{if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK178NEVK", false) == 0)}}`. Not ported.
9. `Name Like '%…%'` filter built with the typed text (`RP_STOCK.cs line 3837`).
10. Zoom through `DC_Main.CurBook*` globals (`RP_STOCK.cs lines 5235-5242`): global state. The web should navigate by voucher key.

## Web today

- `apps/web/app/(app)/reports/tag-stock/page.tsx` (210 lines): the **Tag-Stock** page with tabs in/out/stock/mrp/apr/all. Not RP_STOCK.
- `apps/web/lib/nav.ts:338 {{{ label: 'Tag-Stock Report', href: '/reports/tag-stock', ready: true },}}`: the only nav entry for this area; there is no "Stock Report" entry. Other stock-looking entries are `Stock Valuation` (`/reports/stock-valuation`), `Item-Group Stock`, `Stock by Location`, `Item Stock Ledger`, `Item Stock Level`.
- `apps/api/src/routes/txn.ts:6372 {{app.get('/reports/tag-stock', auth, async (req) => {}}`: route; `apps/api/src/modules/reports/tagStock.ts` (173 lines) builds the tabs from `BAR_DETL`, `MAIN_STOCK` and `APR_DETL`.
- `apps/api/src/modules/rbac/routePolicy.ts:992 {{route('Reports/Tag-Stock Report', ['GET /reports/tag-stock', 'GET /reports/tag-stock.csv']);}}`: rights key.
- `apps/api/src/modules/stock/stock.ts line 358` `onHandNet()`: one signed net of pcs, gross, net and fine over all `MAIN_STOCK` movements of a company/LC (`stock.ts lines 370-377`), with the stock-merge widening (`stock.ts line 367`). It has no date range, no dimension and no TR_TYPE split, and it takes fine from `ITM_FINE` for both signs, whereas the desktop drill-down takes `KR_FINE` for `+` rows. It does not match any desktop view; it is only a single closing-style total.
- `apps/api/src/modules/reports/closingStock.ts`: the balance-sheet closing valuation of `Ac_Final.Trading_Stock` (Ac_Final.cs lines 18-138). It values stock in money; it is not a stock report view and matches no `RP_STOCK` view.
- `apps/api/src/modules/reports/reports.ts line 322` `stockValuation()` (route `GET /reports/stock-valuation`, `txn.ts line 6404`): per-item snapshot of in-stock `BAR_DETL` tags, with gross/net chosen by the setting `STK_RPT_TYPE` (`reports.ts line 355`) and a fine rule from `RP_STOCK_FINE`. It has no date range, no opening/purchase/in/out/sale/closing split and no dimensions. It does not match.
- `apps/api/src/modules/shared/settingsBehavior.ts line 363` `stockReportGrossWeight`: the web already reads `STK_RPT_TYPE` (G/N), which corresponds to `MsStkRptType` (`RP_STOCK.cs line 3647`), but only for `stockValuation`.
- `apps/api/src/modules/reports/reports6.ts:177` `itemGroupStock()` and `reports7.ts:89` `stockByLocation()`: `BAR_DETL`-based snapshots by group and by LC. They match no desktop dimension (the desktop groups `MAIN_STOCK` movements, not tags).
- `apps/api/src/modules/reports/reportGridStaging.ts line 8`: mentions `RP_STOCK` as one of the forms that stage a grid into `REPORT_DATA`; a generic helper, no RP_STOCK-specific use was found.
- Tests: `apps/api/test/closingStock.db.test.ts` (closing valuation), `stockInout.db.test.ts`, `oldStockReport.db.test.ts`, `stock.test.ts`; browser: `apps/web/test/features/modules/` has `tagCancel.mjs`, `tagOpening.mjs`, `stockAdjust.mjs`, `tagPrint.mjs`. No test, route or browser module is named for RP_STOCK (search for `RP_STOCK`, `stock-report`, `stockReport` found only the comments above).
- `docs/handbook/menu-catalog.jsonl` row `Report/Stock Report` still has `"ui":["/reports/tag-stock"]` and `"status":"REPORT"` with its own gap text.

## Gaps

1. **Missing feature, route and menu.** Desktop: Report → Stock Report opens `RP_STOCK` (`MDI_FORM.cs line 8883`). Web: only `/reports/tag-stock` (`nav.ts line 338`; `routePolicy.ts line 992`), which is another form. Needs its own route, nav entry, rights key (`----PL`) and catalog `ui` change.
2. **Missing feature, eight summary dimensions.** Desktop: Group, Product, Item, Safe (or Item Lot), Size, Design, Counter, Trading (table in Calculations). Web: none; `itemGroupStock` and `stockByLocation` are tag snapshots.
3. **Missing feature, date-range columns.** Desktop: Opening / Purchase / Inward / Outward / Sale / Closing (+ hidden transfer in/out) with pcs and weight (`RP_STOCK.cs line 4284`). Web: no report has them; `onHandNet()` (`stock.ts line 358`) is one undated total.
4. **Missing feature, filters.** Desktop: account, tag, item type, stock type (All/Tag/Item), product, group, item code, design, safe, counter, LC, from/to dates. Web: tag-stock has only counter and item (`txn.ts lines 6372-6381`).
5. **Missing feature, gross-weight check box.** Desktop: `chkWtType` switches every weight column between net and gross (`RP_STOCK.cs line 4280`), default from `MsStkRptType` (`RP_STOCK.cs line 3647`). Web: the setting exists (`settingsBehavior.ts line 363`) but only affects `stockValuation` (`reports.ts line 355`); there is no per-run toggle.
6. **Wrong result risk, data source.** Desktop sums every signed `MAIN_STOCK` movement. Web snapshots read `BAR_DETL` tags (tagged stock only), so non-tag movements (item opening, lot, adjustments) are missed. Only `onHandNet()` uses `MAIN_STOCK`.
7. **Wrong result risk, fine.** Desktop drill-down fine = `KR_FINE` for `+` rows and `ITM_FINE` for `-` rows (`RP_STOCK.cs line 2896`). Web `onHandNet()` signs `ITM_FINE` for both (`stock.ts lines 370-372`). The summary grid itself has no fine column; do not add one without a desktop reason.
8. **Missing feature, drill-down.** Desktop: double click a column for opening, purchase, inward, outward, sale or closing movements, with signed totals (`RP_STOCK.cs line 2816`, `3175`). Web: none for this report.
9. **Missing feature, voucher zoom.** Desktop: double click a movement opens the originating voucher by `MAIN_BOOK` (`RP_STOCK.cs lines 5221-5709`) with the two messages in Rules. Web: none.
10. **Missing key.** Desktop: G, I and P select Group, Item, Product; Esc is Back or Exit; Up/Down focus the grid; dates validate on Enter (Keyboard). Web page: none of these exist for this report.
11. **Missing feature, item-name search box** (`RP_STOCK.cs line 3837`), the "Total :" row (`RP_STOCK.cs line 5052`) and blank zeros (`RP_STOCK.cs line 3790`).
12. **Missing feature, print and export.** Desktop: `GroupStkRpt`, `ProdStkRpt`, `TableStkGwtRpt`, `SafeStkRpt` or `SafeStkSumm`, `ItemStkRpt`, `ItmStkWithGrid`, `ItemLedger` with `RptTitel`, `FromDate`, `ToDate`; Excel with 3-decimal rounding. Web: `tag-stock.csv` only, for the other report.
13. **Missing feature, InOut item-ledger print** (`BtnDelete`, item picker, `Item Selection Not Done...`, `RP_STOCK.cs line 5942`).
14. **Missing, rights and messages:** `You Have No Print Rights.....`, `You Have No Rights...`, `You Have No Rights.....`, `This Is a Item Wise Opening Stock Voucher You Cant Zoom ....` (see Rules); the web has no such flow for this report.
15. **Missing, Employee-issue (`EMP ISU`) adjustment** to opening, inward, outward and closing when tags are issued to staff (`RP_STOCK.cs line 4729`, `4915`).
16. **Missing, settings:** `MsCoStockMerge` company-wide totals (partly present in `stock.ts line 367` for `onHandNet` only), `MsDataType` filter, `MsItmWitLotStk`/`MsMeltingLotGenrate` "Item Lot" dimension, `MsMetalType` default item type.
17. **Wrong text risk for the nav caption:** the web label is "Tag-Stock Report"; the desktop caption is "Stock Report" (`MDI_FORM.cs line 8881`).

## Open questions

1. The menu-level rights check before `MDI_FORM.cs line 8881` and the `MsSideBtn` value were not read; the F3 handler's check is read. The case-list worker should read the menu click handler that calls the dispatch (search `MsUserRightForm` above line 8800).
2. The `KeyPreview` setting of `RP_STOCK` was not read (the form-level `KeyDown` handler only fires from child controls if `KeyPreview` is true). Check `InitializeComponent` (`RP_STOCK.cs lines 1535-2811`).
3. The default value of `UserPrint` when `USER_SET` has no row for the user (field declaration, not read).
4. What `TR_TYPE` values exist besides P, I, O, S, T in `MAIN_STOCK` (needed to say whether Closing equals Opening plus the visible columns). Needs an aggregate query on `Next24`; I ran none.
5. The full `EMP ISU` adjustment arithmetic (`RP_STOCK.cs lines 4905-5000`) and the elaborate drill-down branch (`RP_STOCK.cs lines 2968-3146`) were skimmed, not transcribed; the branch is only active when `EMP ISU` tag rows exist in `APR_DETL`.
6. The target forms for the voucher zoom `MAIN_BOOK` values after `SALES` (`RP_STOCK.cs lines 5330-5709`) were not opened one by one.
7. The contents of the Crystal templates (`ItemStkRpt` and the others) are not in the repository sources I read; how they compute opening/closing from `FromDate`/`ToDate` and whether they show fine is unknown. MISSING: the `.RPT` files.
8. Whether the web should keep `stockValuation` (tag-snapshot) as a separate report: a product decision, not answerable from the source.
