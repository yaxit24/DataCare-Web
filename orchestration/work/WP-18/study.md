# WP-18 study: Report → HuId Report (desktop `RP_HUID` against web `/reports/huid`)

This is a read-only study. No code, test or catalog row was changed. Every statement about the desktop carries a
citation in the form `FILE.cs:line {{quoted text}}`; the quote was copied from that line and is checked by a script.
Web statements carry `path:line` references only; the web is not the authority for business behaviour.

Desktop source read: `RP_HUID.cs` lines 1329–1409, 1406–1451, 1555–1625, 1626–1751, 1752–1877, 1880–1906, 2031–2117,
2138–2223, 2224–2272, 2640–2731, and the designer lines that hold controls and captions. Lines 2273–2631 (the drill-down
branches) were read as a list of branch conditions, not line by line.

## Scope

- Menu: Report → "HuId Report". Catalog row `Report/HuId Report` (`docs/handbook/menu-catalog.jsonl`), status
  `REPORT`, phase `P1-core`, rights `----PL`.
- Desktop form: `RP_HUID`, 2,731 lines (`unified/src/csharp/DataCareNext/RP_HUID.cs`).
- Dispatch: `MDI_FORM.cs:9032 {{case "HuId Report":}}`. The case creates the form and shows it:
  `MDI_FORM.cs:9034 {{RP_HUID rP_HUID = new RP_HUID();}}`. The case has no mode argument and no edition branch
  (the block is lines 9032–9041 only), so the menu always opens this one form.
- Lite edition: the menu row is `edition: "L"` (`docs/handbook/menu-editions.json:1634`). The web agrees:
  `web/packages/core/src/editionTable.ts:94` (`'/reports/huid': 'L'`) and `:409`.
- Settings the form reads:
  - `DC_Main.MsCoStockMerge`, set from the company row: `MS_OPNCOMP.cs:706 {{Rows[0]["CO_STK_MERGE"]}}`. When it is
    `"Y"`, the Out and Stock queries drop the company filter (see Lifecycle).
- Edition checks: the form contains no `MsSoftType` reference (checked by search). Lite visibility comes only from the
  edition table above, not from code in this form.
  - `DC_Main.MsDataType`, set from a code: `MDI_FORM.cs:12740 {{DC_Main.MsDataType = "C";}}`. The form adds a
    `DATA_TYPE` filter unless the value is `"C"`. What the codes `A`, `B`, `C` mean is an open question.
  - `DC_Main.MsCrystalRptType` selects the print path (Print section).
  - `DC_Main.SSRegSrNo` hides one column for two named registrations (Desktop weaknesses, item 11).
- Views: the form has three view buttons, Stock, In and Out. The catalog also names "all". The desktop has no "All"
  view button (Gaps 1).
- Out of scope: the UAE variant (`TR_SALE_RTN_UAE`, `TR_PR_SL_UAE`), the drill-down target forms (only the dispatch
  is described), the Crystal engine, `Module_Save.ShowReportPreview`, `DC_Main.SetDate`, and every other report.

## Screen

Form caption: `RP_HUID.cs:1331 {{((XtraForm)this).Text = "Tag Stock With Huid";}}`. The header label is set at run
time to the menu name held in `DC_Main.MsUserRightForm` (`RP_HUID.cs:1409 {{lblBook.Text = CurRpt;}}`). The designer
text was `RP_HUID.cs:1067 {{lblBook.Text = "Tag Stock With HuId";}}`. Where `MsUserRightForm` is set for this menu
was not found (Open questions 11).

Controls, sorted by TabIndex. Ties are not resolved by the source; the order inside a tie is an open question.

| Control | Caption (source) | Type | TabIndex | Default at load | Enabled / visible | Citation |
|---|---|---|---|---|---|---|
| mFromDt | "Date" label; first date box | MaskedTextBox, mask `00/00/0000` | 0 | system date | enabled | `RP_HUID.cs:1268 {{((Control)mFromDt).TabIndex = 0;}}`; `RP_HUID.cs:1620 {{mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}` |
| mToDt | "Date" label; second date box | MaskedTextBox | 1 | system date | enabled | `RP_HUID.cs:1260 {{((Control)mToDt).TabIndex = 1;}}`; `RP_HUID.cs:1621 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}` |
| tSerchAll | none (search box) | SearchControl | 2 | empty | enabled | `RP_HUID.cs:1082 {{((Control)tSerchAll).TabIndex = 2;}}` |
| cboItemTyp | `RP_HUID.cs:1192 {{Label3.Text = "Item Type";}}` | ComboBox | 3 | "Gold" if MsMetalType is `G`, else "Silver" | enabled | `RP_HUID.cs:1184 {{((Control)cboItemTyp).TabIndex = 3;}}`; `RP_HUID.cs:1562 {{if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)}}` |
| cboProduct | `RP_HUID.cs:1210 {{Label1.Text = "Product";}}` | ComboBox | 4 | blank (index 0) | enabled | `RP_HUID.cs:1202 {{((Control)cboProduct).TabIndex = 4;}}` |
| cboGroup | `RP_HUID.cs:1243 {{Label4.Text = "Group";}}` | ComboBox | 5 | blank (index 0) | enabled | `RP_HUID.cs:1235 {{((Control)cboGroup).TabIndex = 5;}}` |
| tTagNo | `RP_HUID.cs:1225 {{Label2.Text = "TagNo";}}` | TextBox | 6 | empty (never assigned at load) | enabled | `RP_HUID.cs:1217 {{((Control)tTagNo).TabIndex = 6;}}` |
| DGV | none (grid) | GridControl / GridView1 | 7 | rows of the last view run | enabled; not editable | `RP_HUID.cs:1088 {{((Control)DGV).TabIndex = 7;}}`; `RP_HUID.cs:1092 {{((ColumnViewOptionsBehavior)GridView1.OptionsBehavior).Editable = false;}}` |
| BtnStock | `RP_HUID.cs:1121 {{BtnStock.Text = "&Stock Tag";}}` | QButton | 7 (same as DGV) | — | enabled | `RP_HUID.cs:1120 {{((Control)BtnStock).TabIndex = 7;}}` |
| BtnIn | `RP_HUID.cs:1177 {{BtnIn.Text = "&In Tag";}}` | QButton | 8 | — | enabled | `RP_HUID.cs:1176 {{((Control)BtnIn).TabIndex = 8;}}` |
| BtnOut | `RP_HUID.cs:1149 {{BtnOut.Text = "&Out Tag";}}` | QButton | 9 | — | enabled | `RP_HUID.cs:1148 {{((Control)BtnOut).TabIndex = 9;}}` |
| Cr | none (Crystal control) | AxCrystalReport | 10 | — | `RP_HUID.cs:1051 {{((AxHost)Cr).Enabled = true;}}` | `RP_HUID.cs:1056 {{((Control)Cr).TabIndex = 10;}}` |
| cboHuId | `RP_HUID.cs:1284 {{Label6.Text = "HuId Type";}}` (label `Label6`) | ComboBox | 134 | "All" (index 0) | enabled | `RP_HUID.cs:1276 {{((Control)cboHuId).TabIndex = 134;}}`; `RP_HUID.cs:1573 {{cboHuId.SelectedIndex = 0;}}` |
| tAcCode | `RP_HUID.cs:1293 {{Label8.Text = "AcCode";}}` | TextBox | 1180 | empty | enabled | `RP_HUID.cs:1300 {{((Control)tAcCode).TabIndex = 1180;}}` |
| BtnPrint | `RP_HUID.cs:1049 {{BtnPrint.Text = "&Print";}}` | SimpleButton (bottom panel) | 0 (same as mFromDt) | — | enabled | `RP_HUID.cs:1048 {{((Control)BtnPrint).TabIndex = 0;}}` |
| BtnSave | `RP_HUID.cs:1036 {{BtnSave.Text = "&Excel";}}` | SimpleButton | 2 (same as tSerchAll) | — | enabled | `RP_HUID.cs:1035 {{((Control)BtnSave).TabIndex = 2;}}` |
| BtnCancel | `RP_HUID.cs:1023 {{BtnCancel.Text = "&Cancel";}}` | SimpleButton | 3 | — | enabled | `RP_HUID.cs:1022 {{((Control)BtnCancel).TabIndex = 3;}}` |
| BtnDelete | `RP_HUID.cs:1009 {{BtnDelete.Text = "&Delete";}}` | SimpleButton | 4 | — | enabled; its click does nothing | `RP_HUID.cs:1008 {{((Control)BtnDelete).TabIndex = 4;}}`; empty handler `RP_HUID.cs:1369 {{private void BtnDelete_Click(object sender, EventArgs e)}}` (body is empty, 1370–1371) |
| BtnExit | `RP_HUID.cs:996 {{BtnExit.Text = "E&xit";}}` | SimpleButton | 5 | — | enabled | `RP_HUID.cs:995 {{((Control)BtnExit).TabIndex = 5;}}` |
| lblBook | header label (see above) | Label | 6 | menu name | — | `RP_HUID.cs:1066 {{((Control)lblBook).TabIndex = 6;}}` |

Labels Label3, Label1, Label2, Label4, Label5, Label6 and Label8 carry TabIndex values (124–1181) but are not focusable.
The designer sets no control to disabled and no control to hidden. The only designer `Enabled` assignment is the
Crystal control (line 1051). Two buttons (Save and Print) share TabIndex 0 or 2 with a field; WinForms resolves such
ties by z-order, which the source does not show.

Grid column captions: the designer sets no column caption (no `Caption` assignment exists in `InitializeComponent`).
The grid headers are therefore the SELECT aliases (`CoCode`, `VchTyp`, `TagNo`, `HuId2` and so on). See Gaps 18.

## Keyboard

Every key the form tests (all `KeyCode` checks use codes 13, 27, 38, 40 only; there are no function-key, Ctrl or Alt handlers):

- Enter in the From date: `RP_HUID.cs:2644 {{if ((int)e.KeyCode == 13)}}`. It calls `DC_Main.SetDate` (`RP_HUID.cs:2647 {{DC_Main.SetDate(ref MsDate);}}`)
  and, when `DC_Main.RongDate` is false, sends Tab (`RP_HUID.cs:2651 {{SendKeys.Send("{tab}");}}`). Focus moves to the next TabIndex.
- Enter in the To date: same handler `RP_HUID.cs:2660 {{if ((int)e.KeyCode == 13)}}`, same Tab.
- Date boxes select all text when they gain focus: `RP_HUID.cs:2675 {{((TextBoxBase)mFromDt).SelectionLength = Strings.Len(mFromDt.Text);}}`.
- Enter in TagNo: `RP_HUID.cs:2229 {{if ((int)e.KeyCode != 13)}}`. It looks the tag up in `BAR_DETL` for the company and
  location (`RP_HUID.cs:2233 {{Select A.TAG_NO FROM BAR_DETL AS A WHERE A.CO_CODE}}`). If no row matches, it opens the
  tag help list (`RP_HUID.cs:2244 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}`) and copies the chosen tag into the
  box (`RP_HUID.cs:2247 {{tTagNo.Text = DC_Main.ColValue[0];}}`). A tag that exists does nothing else; focus stays.
- Enter in AcCode: `RP_HUID.cs:2689 {{if ((int)e.KeyCode != 13)}}`. With text present, it looks the account up in
  `AC_MAST` (`RP_HUID.cs:2695 {{Select * From AC_MAST WHERE CO_CODE = '}}`). If not found, it opens the account help
  and puts the chosen code into the box (`RP_HUID.cs:2722 {{tAcCode.Text = DC_Main.ColValue[1];}}`), then refocuses it.
  If found, it selects the text (`RP_HUID.cs:2729 {{((TextBoxBase)tAcCode).SelectAll();}}`).
- Esc: `RP_HUID.cs:1732 {{if ((int)e.KeyCode == 27)}}`; it closes the form (`RP_HUID.cs:1734 {{((Form)this).Close();}}`).
- Up and Down arrows: `RP_HUID.cs:1736 {{if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))}}`; they move focus
  to the grid (`RP_HUID.cs:1738 {{((Control)DGV).Focus();}}`).
- Typed characters: the form is `KeyPreview` (`RP_HUID.cs:1329 {{((Form)this).KeyPreview = true;}}`), so every
  typed character is upper-cased (`RP_HUID.cs:1715 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}`);
  NUL and apostrophe are dropped (`RP_HUID.cs:1718 {{if (num == 0 || num == 39)}}`).
- Alt mnemonics come from the `&` captions: Excel, Print, Cancel, Delete, Exit, Stock Tag, In Tag, Out Tag (Screen table).
- On activation the form focuses its saved control: `RP_HUID.cs:1749 {{CurActCtrl.Focus();}}`. At load the first
  control set is the From date: `RP_HUID.cs:1622 {{CurActCtrl = (Control)(object)mFromDt;}}`.

## Rules

Validation messages (the form has exactly one `MsgBox` call: `RP_HUID.cs:1361 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}`):

- **"You Have No Print Rights....."** is shown by the **Excel** button, not by Print. Condition:
  `RP_HUID.cs:1359 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}`. The handler returns
  (`RP_HUID.cs:1362 {{return;}}`) and does not move focus.

Rules that are not messages:

- Date order is never checked. In and Out bound both dates; Stock bounds only the To date. No code compares From with To.
- Date text is parsed without a guard in the query: `RP_HUID.cs:1761 {{Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}}`.
  What happens on blank or invalid text depends on `DC_Main.SetDate`, which was not read (Open questions 6).
- An empty result shows an empty grid with no message: `RP_HUID.cs:1876 {{RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);}}`
  then `RP_HUID.cs:1877 {{DGV_FILL();}}`.
- A search with no match clears the grid and sets no data source (`RP_HUID.cs:1667 {{DGV_CLEAR();}}`, then no
  `DGV.DataSource` assignment on the last branch, `RP_HUID.cs:1687-1691 {{dataView.RowFilter = "HuId4 Like  '%" + ((TextEdit)tSerchAll).Text +}}`).
- Tag or account not found: the help list opens, no message (`RP_HUID.cs:2235 {{if (DC_Main.Rshlp.Rows.Count == 0)}}` and `RP_HUID.cs:2699 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}}` branches).
- Focus after the Excel message: unchanged (the handler returns before any focus call).

## Calculations

The form does no money arithmetic and applies no rounding in code. Its calculations are these, in the order they run:

1. **Qty per row** is the literal 1 (`RP_HUID.cs:1761 {{1 AS Qty,C.ITM_PCS as Pcs}}`), so the Qty total is the row count.
2. **Grid totals** are DevExpress summaries on eight columns, one sum each: `RP_HUID.cs:2068 {{((ColumnView)GridView1).Columns["Qty"].Summary.Add((SummaryItemType)0, "Qty", "{0}");}}`,
   then Pcs (2072), Grwt (2076), NetWt (`RP_HUID.cs:2080 {{Columns["NetWt"].Summary.Add((SummaryItemType)0, "NetWt", "{0}");}}`),
   HuWt (`RP_HUID.cs:2084 {{Columns["HuWt"].Summary.Add((SummaryItemType)0, "HuWt", "{0}");}}`), HuWt2 (2088), HuWt3 (2092) and HuWt4 (`RP_HUID.cs:2096 {{Columns["HuWt4"].Summary.Add((SummaryItemType)0, "HuWt4", "{0}");}}`).
   The format is `"{0}"`: no decimals are set. The sum type value 0 is read as Sum from the DevExpress enum (inferred).
3. **Stock availability** is a `HAVING` on movement serial numbers, not a count:
   `RP_HUID.cs:1873 {{HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0}}`.
   The sign of each movement picks the serial number up or down. This is the desktop rule as written; see Gaps 12.
4. **Date window**: In bounds `C.VCH_DATE` from From to To (`RP_HUID.cs:1761 {{AND C.TAG_NO <> 'N' AND C.VCH_DATE >= '}}`);
   Out bounds `A.VCH_DATE` (`RP_HUID.cs:1799 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`); Stock bounds only `C.STK_DATE <= To` (`RP_HUID.cs:1834 {{AND C.STK_DATE <= '}}`).
5. **Date format in SQL**: `MM/dd/yyyy` (same line 1761).

Print formulas (Crystal, `TagHuIdRpt.xml`): the template declares `@TagQty`
(`extraction_output/rpt_xml/TagHuIdRpt.xml:340 {{<FormulaFieldDefinition FormulaName="{@TagQty}"}}`), `@TagGwt`, `@TagNwt`,
`@TagPcs`, `@NewBal`, `@VchSrno`, `@FromDate` (`TagHuIdRpt.xml:324 {{<FormulaFieldDefinition FormulaName="{@FromDate}"}}`)
and `@RptTitel` (`TagHuIdRpt.xml:328 {{<FormulaFieldDefinition FormulaName="{@RptTitel}"}}`). **MISSING:** the formula
bodies were not extracted from the XML, so their arithmetic is not stated here.

## Lifecycle and write set

This is a read report. It has no create, reopen, edit, delete or cancel of a voucher. Its Cancel button clears the
screen (`RP_HUID.cs:1744 {{CLEAR_DATA();}}`), and its Delete button does nothing (`RP_HUID.cs:1369-1371 {{private void BtnDelete_Click(object sender, EventArgs e)}}`).

**Load** (`RP_HUID.cs:1373 {{private void RP_HUID_Load(object sender, EventArgs e)}}`): reads one `USER_SET` row for this menu (`RP_HUID.cs:1406 {{DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '"}}`),
then reads `PRODUCT_MAST` (`RP_HUID.cs:1574 {{SELECT PR_NAME As Product,PR_CODE as Code FROM PRODUCT_MAST}}`) and
`GROUP_MAST` (`RP_HUID.cs:1597 {{SELECT GR_NAME,GR_CODE FROM GROUP_MAST}}`) for the lists. No writes.

**View run** (`Tag_Summ`, `RP_HUID.cs:1752 {{private void Tag_Summ(string RptType)}}`), called by the Stock, In and Out buttons (`RP_HUID.cs:2153 {{Tag_Summ("Stock");}}`,
`RP_HUID.cs:2158 {{Tag_Summ("In");}}`, `RP_HUID.cs:2163 {{Tag_Summ("Out");}}`). Statements in order:

1. `RP_HUID.cs:1754 {{UPDATE BAR_DETL SET HM_ID = '' WHERE CO_CODE = '}}` plus `AND HM_ID Is NULL`.
2. `RP_HUID.cs:1755 {{UPDATE BAR_DETL SET HM_ID2 = '' WHERE CO_CODE = '}}`, then `RP_HUID.cs:1756 {{DC_Main.ExeQuteDc("UPDATE BAR_DETL SET HM_ID3 = '' WHERE CO_CODE = '"}}` for HM_ID3 and
   `RP_HUID.cs:1757 {{AND HM_ID4 Is NULL}}` for HM_ID4.
   **These four UPDATE statements write `BAR_DETL` for the whole company** (no `LC_CODE`, no `CO_YEAR`, no tag key).
   They run on every view click, before any filter. See the recommendation below.
3. The SELECT for the view is chosen by `switch (RptType)` (`RP_HUID.cs:1758 {{switch (RptType)}}`).
4. The HUID choice adds a filter (`RP_HUID.cs:1762 {{if (cboHuId.SelectedIndex == 1)}}` for In; the same pattern at 1801 Out and 1840 Stock).
5. Product, group, item type, tag and account filters are appended in the order of the view's branch.
6. `RP_HUID.cs:1876 {{RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);}}`, then `DGV_FILL` (`RP_HUID.cs:1877 {{DGV_FILL();}}`).

Base query per view. Each cell is the condition the desktop writes:

| Condition | In | Out | Stock |
|---|---|---|---|
| Driving table | `BAR_DETL` as C (`RP_HUID.cs:1761 {{from BAR_DETL AS C LEFT JOIN ITEM_MAST AS B}}`) | `MAIN_STOCK` as A joined to `BAR_DETL` as C | `MAIN_STOCK` as A joined to `BAR_DETL` as C |
| Company | `C.CO_CODE` (1761) | `A.CO_CODE` only when merge is not Y (1799 `WHERE A.CO_CODE = '`) | `A.CO_CODE` only when merge is not Y (1838) |
| Location | `C.LC_CODE` | `A.LC_CODE` (1795, 1799) | `A.LC_CODE` (1834, 1838) |
| Year | `C.CO_YEAR` | `A.CO_YEAR` | `A.CO_YEAR` (1838) |
| Tag | `C.TAG_NO <> 'N'` | `A.TAG_NO <> 'N'` | `A.TAG_NO <> 'N'` (1834, 1838) |
| Date | `C.VCH_DATE` from From to To | `A.VCH_DATE` from From to To | `C.STK_DATE` ≤ To only (no From) |
| Movement | none | `A.ITM_SIGN = '-'` (`RP_HUID.cs:1795 {{AND A.ITM_SIGN = '-'}}`) | `HAVING` sum (Calculations 3) |
| Data type | `C.DATA_TYPE` unless MsDataType is `C` (`RP_HUID.cs:1761 {{Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0}}`) | `A.DATA_TYPE` (1799) | `A.DATA_TYPE` (1838) |
| Order | `ORDER BY C.TAG_NO` (`RP_HUID.cs:1790 {{DC_Main.RsQry += "ORDER BY C.TAG_NO";}}`) | `ORDER BY C.TAG_NO` (1829) | `ORDER BY C.TAG_NO` (`RP_HUID.cs:1873 {{DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO}}`) |

Merge flag: when `MsCoStockMerge` is `"Y"`, Out and Stock use `LEFT JOIN` and drop the company filter
(`RP_HUID.cs:1795 {{WHERE  A.LC_CODE = '}}`, `RP_HUID.cs:1834 {{WHERE  A.LC_CODE = '}}`). Non-merge uses `INNER JOIN` on `A.CO_CODE = C.CO_CODE` (`RP_HUID.cs:1799 {{INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE}}`).

**Print** (`RP_HUID.cs:2189 {{private void BtnPrint_Click(object sender, EventArgs e)}}`): calls `Stk_Insert()` first (`RP_HUID.cs:2191 {{Stk_Insert();}}`). `Stk_Insert`
(`RP_HUID.cs:2166 {{private void Stk_Insert()}}`) does three things:
1. Deletes the company's staging rows: `RP_HUID.cs:2168 {{DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE}}`.
2. For each **grid row currently shown** (so a search filter changes what prints), inserts one row into `TAG_STOCK_PRINT`
   selected from `BAR_DETL` by company, year, tag and serial (`RP_HUID.cs:2179 {{FROM BAR_DETL WHERE CO_CODE = '}}`,
   `RP_HUID.cs:2179 {{AND TAG_NO ='}}`). The insert sets `ITM_SIGN` to `'+'`, `ITM_QTY` to 1 and `DATA_TYPE` to `'A'`
   (`RP_HUID.cs:2179 {{VCH_SRNO,'+',1,ITM_PCS,ITM_GWT,ITM_NWT,'A',}}`). The column list is
   `CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO, VCH_DATE, VCH_TYPE, INOUT_TYPE, BOOK_NAME, IT_CODE, TAG_NO, VCH_SRNO, ITM_SIGN, ITM_QTY, ITM_PCS, ITM_GWT, ITM_NWT, DATA_TYPE, HM_ID, HM_ID2, HM_ID3, HM_ID4, HM_ID_WT, HM_ID2_WT, HM_ID3_WT, HM_ID4_WT`
   (same line). The key used is `TAG_NO` plus `VCH_SRNO`; the source WHERE has no `LC_CODE`.
3. Reads `TAG_STOCK_PRINT` back into a local that is never used: `RP_HUID.cs:2184 {{DC_Main.RsQry = "SELECT * FROM TAG_STOCK_PRINT";}}`.

**Close** (`RP_HUID.cs:2138 {{private void RP_HUID_Closed(object sender, EventArgs e)}}`): `RP_HUID.cs:2140 {{DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT ");}}`, with no WHERE.

**Excel** (`RP_HUID.cs:1364-1366 {{string text = "output.xlsx";}}`): writes `output.xlsx` into the working folder and starts it. No database write.

**Drill-down** (double-click on the grid, `RP_HUID.cs:2252 {{private void DGV_DoubleClick(object sender, EventArgs e)}}`): skipped when merge is `"Y"` (`RP_HUID.cs:2254 {{if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)}}`).
Otherwise it reads `BOOK_DATA` by the row's `Book` (`RP_HUID.cs:2258 {{SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK}}`),
copies the book fields into global `DC_Main.CurBook*` values, stores the voucher number (`RP_HUID.cs:2272 {{DC_Main.CurBookVch = ((ColumnView)GridView1).GetFocusedRowCellValue("VchNo")}}`),
and opens a form chosen by `MAIN_BOOK`, for example `RP_HUID.cs:2273 {{if (Operators.CompareString(DC_Main.CurBookMain, "OPSTK", false) == 0)}}`,
`RP_HUID.cs:2290 {{else if (Operators.CompareString(DC_Main.CurBookMain, "TAG CANCEL", false) == 0)}}`,
`RP_HUID.cs:2325 {{else if (Operators.CompareString(DC_Main.CurBookMain, "SALES", false) == 0)}}`. About 60 branches exist (lines 2273–2631).
No write in this form.

**Recommendation on the `BAR_DETL` updates (lines 1754–1757).** Do not repeat the write on the web. Reasons:

- A hosted report must not write a stock master table under a read action. The statements change every location and
  every year of the company, because they carry only `CO_CODE`. That is an unscoped multi-location write.
- No right gates it. `UserEdit` is read (`RP_HUID.cs:1412 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.}}`) but never used, and the view paths check nothing.
- The purpose is inferred, not stated: the statements turn NULL into `''` so the later `HM_ID <> ''` and `HM_ID = ''`
  filters (`RP_HUID.cs:1764 {{DC_Main.RsQry += " AND C.HM_ID <> ''";}}`, `RP_HUID.cs:1768 {{DC_Main.RsQry += "AND C.HM_ID = '' ";}}`) work. The web does not need the rewrite. Its read rule treats NULL, empty
  and blank the same way (`web/apps/api/src/modules/reports/huid.ts:129–132`, `NULLIF(btrim(coalesce(...)))`).
- The one result difference is whitespace-only HUIDs: the desktop counts them as present, the web as absent (Gaps 11).
- If the owner wants the stored values normalised, do it as a separately approved data migration with its own write-set
  test. Do not put it in the report.

## Print

- Button: `RP_HUID.cs:2189 {{private void BtnPrint_Click(object sender, EventArgs e)}}`. It saves the staging rows (Lifecycle)
  and then chooses one of two paths.
- Path selection: `RP_HUID.cs:2194 {{if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)}}`.
  - `"O"`: the ActiveX Crystal control opens `TagHuIdRpt.RPT` (`RP_HUID.cs:2196 {{Cr.ReportFileName = }}` with `TagHuIdRpt.RPT`,
    line 2196). It sets the title parameter `RP_HUID.cs:2205 {{Cr[(short)0] = "RptTitel = '"}}`, and the selection formula
    (`RP_HUID.cs:2203 {{{TAG_STOCK_PRINT.CO_CODE} = '}}` wording, with `LC_CODE`, `CO_YEAR` and `VCH_DATE <= To`).
    It does not pass `FromDate`.
  - Other values: `RP_HUID.cs:2213 {{DC_Main.MsRptTitel = "RptTitel";}}`, `RP_HUID.cs:2215 {{DC_Main.MsCrForName1 = "FromDate";}}`,
    `RP_HUID.cs:2216 {{DC_Main.MsCrForStr1 = "Date("}}` (the From date as `Date(y,m,d)`), `RP_HUID.cs:2217 {{DC_Main.RptName = "TagHuIdRpt";}}`,
    `RP_HUID.cs:2219 {{DC_Main.RptFormula = "{TAG_STOCK_PRINT.CO_CODE} = '}}`, then `RP_HUID.cs:2220 {{Module_Save.ShowReportPreview();}}`.
- Report title: `RP_HUID.cs:2192 {{string text = "Tag Wise Huid Report As on Date ";}}`, with the To date in `dd/MM/yyyy`.
- Template: **present**, not missing. `unified/reports/TagHuIdRpt.rpt` and `extraction_output/rpt_xml/TagHuIdRpt.xml` both exist.
  The XML groups by product and group: `TagHuIdRpt.xml:312 {{<Group ConditionField="{ITEM_MAST.PR_CODE}" />}}` and
  `TagHuIdRpt.xml:313 {{<Group ConditionField="{ITEM_MAST.GR_CODE}" />}}`. It has group and report summaries on the four
  `@`-weights and the four `BAR_DETL` HUID weights (for example `Sum ({BAR_DETL.HM_ID_WT})`).
- Selection: the Crystal template reads `TAG_STOCK_PRINT` (not `BAR_DETL`), so the printed rows are the staging rows
  inserted from the grid. The date filter on print is `VCH_DATE <= To` (`RP_HUID.cs:2219 {{{TAG_STOCK_PRINT.VCH_DATE} <= #}}`
  wording, line 2219), which is the voucher date. The Stock grid filters `STK_DATE` (Gaps 2). The two can disagree.
- Print-rights check: **none**. `RP_HUID.cs:2189 {{private void BtnPrint_Click(object sender, EventArgs e)}}` and `RP_HUID.cs:2191 {{Stk_Insert();}}` contain no `UserPrint` test. The desktop
  lets a user without the Print right print the report, while Excel refuses them.

## Rights

- Read at load (`RP_HUID.cs:1406-1414 {{DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" +}}`): `FRM_EDIT`, `FRM_DELETE` and `FRM_PRINT` from `USER_SET`, keyed by location,
  user and `SUB_MENU`. `FRM_LIST` is not read. The catalog's `----PL` says Print and List.
- Used: `UserPrint` only, by the Excel button (`RP_HUID.cs:1359 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}`).
- Read but never used: `UserEdit` and `UserDelete` (`RP_HUID.cs:1412 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.}}`, `RP_HUID.cs:1413 {{UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTabl}}`); Delete is empty.
- Not checked anywhere in this form: the Print button (2189–2191), the view buttons (2151–2164), and List.
- Message on refusal: **"You Have No Print Rights....."** (Rules).

## Desktop weaknesses not to port

1. **Report writes `BAR_DETL`, company-wide.** `RP_HUID.cs:1754 {{UPDATE BAR_DETL SET HM_ID = '' WHERE CO_CODE = '}}`
   (with 1755–1757), run on every view click (`RP_HUID.cs:2153 {{Tag_Summ("Stock");}}`). Reason and recommendation in Lifecycle.
2. **Unscoped delete at close.** `RP_HUID.cs:2140 {{DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT ");}}` removes every
   company's and every user's staging rows.
3. **Shared staging table with no key for the user or session.** `RP_HUID.cs:2168 {{DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE}}`
   and the per-row insert at `RP_HUID.cs:2179 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`. Two users in one company overwrite each other's print list.
4. **Partial, row-by-row writes.** `RP_HUID.cs:2180 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}` runs once per grid row, so an
   error part-way leaves a partial staging list. (The loop is `RP_HUID.cs:2176-2181 {{while (DC_Main.X <= num)}}`.)
5. **String-built SQL from user input.** `RP_HUID.cs:2233 {{Select A.TAG_NO FROM BAR_DETL AS A WHERE A.CO_CODE}}` and
   `RP_HUID.cs:1784 {{AND C.TAG_NO = '}}`; account code at `RP_HUID.cs:1788 {{AND C.AC_CODE =}}`. An apostrophe in the
   typed text breaks the statement. The upper-casing at 1715 and the apostrophe block at 1718 are a partial guard only.
6. **Search filter built by concatenation.** `RP_HUID.cs:1669 {{dataView.RowFilter = "HuId Like}}` with the typed text
   appended; an apostrophe breaks it. The search tests the four HUID columns in turn and shows the first set that has a match
   (`RP_HUID.cs:1669-1689 {{dataView.RowFilter = "HuId Like  '%" + ((TextEdit)tSerchAll).Text +}}`), not the union.
7. **Merge flag drops the company filter.** `RP_HUID.cs:1795 {{WHERE  A.LC_CODE = '}}` and `RP_HUID.cs:1834 {{WHERE  A.LC_CODE = '}}`
   have no `CO_CODE`. With `CO_STK_MERGE = "Y"` (`MS_OPNCOMP.cs:706 {{DC_Main.MsCoStockMerge =}}`), other companies' movements can appear.
8. **Stock rule sums serial numbers.** `RP_HUID.cs:1873 {{HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0}}`
   is not a count; the result can depend on serial values (Gaps 12).
9. **Fixed Excel file name.** `RP_HUID.cs:1364 {{string text = "output.xlsx";}}` writes into the working folder and overwrites.
10. **Global state for drill-down.** `RP_HUID.cs:2264 {{DC_Main.CurBook = Conversions.ToString(}}`-style assignments, and
    `RP_HUID.cs:1451 {{DC_Main.MsUserRightForm = "";}}` in Load, share state across forms.
11. **Customer-specific column hiding.** `RP_HUID.cs:2050 {{DC_Main.SSRegSrNo, "DM086NSDG"}}` hides `StkDate` for two named
    registrations (`RP_HUID.cs:2064 {{((ColumnView)GridView1).Columns["StkDate"].Visible = false;}}`). Do not port.
12. **Stock and print use different dates.** Stock filters `C.STK_DATE` (`RP_HUID.cs:1834 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`); print filters `VCH_DATE`
    (`RP_HUID.cs:2219 {{DC_Main.RptFormula = "{TAG_STOCK_PRINT.CO_CODE}}`).
13. **Dead read.** `RP_HUID.cs:2184 {{DC_Main.RsQry = "SELECT * FROM TAG_STOCK_PRINT";}}` is read and never used.
14. **Print without rights** (`RP_HUID.cs:2189-2191 {{private void BtnPrint_Click(object sender, EventArgs e)}}`), while Excel is gated (`RP_HUID.cs:1359 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}`).

## Web today

- `web/apps/api/src/modules/reports/huid.ts` (207 lines). `huidReport(prisma, tenantId, scope, options)` (line 92):
  - Scope `CO_CODE` and `LC_CODE` only (lines 118–119). No `CO_YEAR`, no date, no tag, no account code.
  - Optional item code and counter (`TBL_CODE`) equality (lines 120–127).
  - Hallmark mode `all`, `with` or `without`, tested on all four HUID slots (lines 128–134).
  - Tab `all` (every `BAR_DETL` row) or `stock` (a net sign count over `MAIN_STOCK`, lines 136–147); tab validated at line 109.
  - Orders by `TAG_NO`, `VCH_SRNO` (line 159). Rows mapped at 161–190; totals at 191–204.
- `web/apps/api/src/routes/txn.ts`:
  - `huidOptions` (lines 858–863) passes only `tab`, `itCode`, `tblCode` and `hallmark`; dates, tag and account are dropped.
  - `REPORT_BUILDERS.huid` (lines 4182–4191) calls `huidReport`.
  - `GET /reports/huid` (lines 4524–4526) returns JSON under the `auth` pre-handler only.
  - `export.csv` (line 4450, guard 4451), `export.xlsx` (4463, guard 4464), `export.pdf` (4481, guard 4482) each require `guard(req, reply, 'print')`.
- `web/apps/web/app/(app)/reports/[report]/page.tsx` (shared report page; HUID block only):
  - Title `HUID Report` (line 56); HUID state (lines 203–206); parameters sent for slug `huid` (lines 351–357).
  - Controls for View (`All history`, `In stock`), HUID (`All`, `With HUID`, `Without HUID`), Item and Counter (lines 1388–1433).
  - Excel parameters (lines 1577–1581). Totals shown as `Total <name>` (lines 597–606).
  - From and To date boxes (lines 1461–1478) are generic and are sent for every report, including HUID, which ignores them.
  - No HUID search box, no HUID column definition, no drill-down, no keyboard handling for HUID (checked by search).
- `web/apps/web/lib/nav.ts:331` (`label: 'HUID Report', href: '/reports/huid'`).
- `web/apps/api/src/modules/rbac/routePolicy.ts:984` (`route('Reports/HuId Report', ['GET /reports/huid'])`) and
  `web/apps/api/src/modules/reports/reportAuthorization.ts:25` (slug to form mapping).
- `web/apps/api/report-specs/TagHuIdRpt.spec.json` is a layout spec. No route reads it. The only other mention of
  `TagHuIdRpt` in `web/apps` or `web/packages` is `web/apps/api/src/modules/ops/releaseCertification.ts:1054`, a list.
- Tests:
  - `web/apps/api/test/p9Reports.db.test.ts:117–146`: default All; HUID kept as text; With and Without at module level.
  - `web/apps/api/test/reportScreens.routes.db.test.ts:151–175` (G13): screen defaults, with and without modes, CSV contains
    the tag, invalid mode refused. `:176–190`: refusal without the right.
  - `web/apps/web/test/reportSlug.test.ts:21` and `web/apps/web/test/reportSurfaceLinks.test.ts:31`: slug and link only.
  - No browser module for HUID under `web/apps/web/test/features/modules/` (search for `huid` returns nothing).

## Gaps

Each item: what the desktop does (cited), what the web does (file and line), and the type.
Types: missing feature, wrong result, wrong text, missing key.

1. **Views.** Desktop: three buttons, `RP_HUID.cs:2158 {{Tag_Summ("In");}}`, `RP_HUID.cs:2163 {{Tag_Summ("Out");}}`
   and `RP_HUID.cs:2153 {{Tag_Summ("Stock");}}`; no "All" button. Web: `All history` (page.tsx:1393–1400) and `In stock`,
   and no Out view. Type: missing feature (Out) and wrong result (All has no desktop button; its nearest desktop
   equivalent is In without the date window).
2. **Date window.** Desktop: In and Out bound From and To on the voucher date (`RP_HUID.cs:1761 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`, `RP_HUID.cs:1799 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`);
   Stock bounds only To on `STK_DATE` (`RP_HUID.cs:1834 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`). Web: no date is applied (`huid.ts` has no date input;
   `txn.ts:858–863` drops `fromDate` and `toDate`). Type: wrong result (every date is returned).
3. **Financial year.** Desktop: `C.CO_YEAR` (`RP_HUID.cs:1761 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`), `A.CO_YEAR` (`RP_HUID.cs:1795 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`). Web: none
   (`huid.ts:118–119`). Type: wrong result (other years' tags appear).
4. **Tag number.** Desktop: exact `TAG_NO` filter in all three views (`RP_HUID.cs:1782-1785 {{if (Operators.CompareString(tTagNo.Text, "", false) != 0)}}`, `RP_HUID.cs:1809-1812 {{if (Operators.CompareString(tTagNo.Text, "", false) != 0)}}`,
   `RP_HUID.cs:1864-1867 {{if (Operators.CompareString(tTagNo.Text, "", false) != 0)}}`). Web: the generic Tag No box (page.tsx:1451) is not sent for HUID (`txn.ts:858–863`). Type: missing key.
5. **Account code.** Desktop: `RP_HUID.cs:1786-1789 {{if (Operators.CompareString(tAcCode.Text, "", false) != 0)}}` (In), `RP_HUID.cs:1825-1828 {{if (Operators.CompareString(tAcCode.Text, "", false) != 0)}}` (Out, on `A.AC_CODE`),
   `RP_HUID.cs:1868-1871 {{if (Operators.CompareString(tAcCode.Text, "", false) != 0)}}` (Stock, on `C.AC_CODE`), with the lookup at `RP_HUID.cs:2684 {{private void tAcCode_KeyDown(object sender, KeyEventArgs e)}}`. Web: not passed (`txn.ts:858–863`).
   Type: missing feature.
6. **Product, group and item type.** Desktop: `B.PR_CODE`, `B.GR_CODE`, `B.IT_TYPE` (`RP_HUID.cs:1770-1781 {{if (Operators.CompareString(cboProduct.Text, "", false) != 0)}}`, `RP_HUID.cs:1813-1823 {{if (Operators.CompareString(cboGroup.Text, "", false) != 0)}}`,
   `RP_HUID.cs:1848-1858 {{if (Operators.CompareString(cboProduct.Text, "", false) != 0)}}`). Web: none. Type: missing feature.
7. **Item type default.** Desktop: the box opens on "Gold" (or "Silver"), so the default filter is `B.IT_TYPE = 'G'`
   (`RP_HUID.cs:1564 {{cboItemTyp.SelectedIndex = 0;}}`; filter `RP_HUID.cs:1778 {{if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)}}`).
   Web: no item-type control; the first open shows all types. Type: wrong result on first open.
8. **Counter filter.** Desktop: `TBL_CODE` is only a column (`RP_HUID.cs:1761 {{1 AS Qty,C.ITM_PCS as Pcs}}`
   sits beside `C.TBL_CODE As Counter`); there is no counter filter. Web: the Counter box is sent and filters `TBL_CODE`
   (page.tsx:1425–1432; `huid.ts:124–126`). Type: wrong result (an extra filter).
9. **Item code filter.** Desktop: none. Web: the Item box filters `IT_CODE` (page.tsx:1416–1423; `huid.ts:120–122`). Type: wrong result (an extra filter).
10. **HUID filter column.** Desktop: With and Without test `HM_ID` only (`RP_HUID.cs:1764 {{DC_Main.RsQry += " AND C.HM_ID <> ''";}}`,
    `RP_HUID.cs:1768 {{DC_Main.RsQry += "AND C.HM_ID = '' ";}}`, and the same pair at 1803, 1807, 1842, 1846).
    Web: all four slots (`huid.ts:129–134`). A tag whose only HUID is in slot 2, 3 or 4 is "With" on the web and "Without" on the desktop. Type: wrong result.
11. **Whitespace HUID.** Desktop: `<> ''` treats a blank-looking value as present. Web: `btrim` treats it as absent
    (`huid.ts:129–132`). Type: wrong result (small). Open question 2.
12. **Stock rule.** Desktop: sum of movement serials, `RP_HUID.cs:1873 {{DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO}}`. Web: net count of `+` and `-` signs
    (`huid.ts:139–146`), starting from `BAR_DETL` (`huid.ts:155`) where the desktop starts from `MAIN_STOCK`. Type: wrong result
    possible. Desktop rule must be confirmed against the owner before the web is changed (Open questions 1).
13. **Tag "N" exclusion.** Desktop: `TAG_NO <> 'N'` in all views (`RP_HUID.cs:1761 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`, `RP_HUID.cs:1795 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`, `RP_HUID.cs:1834 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`).
    Web: none. Type: wrong result (tag numbered `N`).
14. **Data type.** Desktop: `DATA_TYPE` filter unless `MsDataType` is `C` (`RP_HUID.cs:1761 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`). Web: none. Type: missing key.
15. **Search box.** Desktop: `RP_HUID.cs:1082 {{((Control)tSerchAll).TabIndex = 2;}}`, filter at `RP_HUID.cs:1669-1689 {{dataView.RowFilter = "HuId Like  '%" + ((TextEdit)tSerchAll).Text +}}`, over the
    loaded result. Web: none. Type: missing feature.
16. **Sort.** Desktop: `ORDER BY C.TAG_NO` only (`RP_HUID.cs:1790 {{DC_Main.RsQry += "ORDER BY C.TAG_NO";}}`, `RP_HUID.cs:1829 {{DC_Main.RsQry += "ORDER BY C.TAG_NO";}}`, `RP_HUID.cs:1873 {{DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO}}`). Web: `TAG_NO`,
    `VCH_SRNO` (`huid.ts:159`). Type: wrong result (order within one tag is undefined on desktop, fixed on web).
17. **Columns.** Desktop: the Stock view's date column is `StkDate`, from `C.STK_DATE As StkDate` (`RP_HUID.cs:1838 {{C.STK_DATE As StkDate}}`);
    the In and Out views use `VchDate`. The web returns `vchDate` for every tab. Desktop: 24 columns in the SELECT (`RP_HUID.cs:1761 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`); `CoCode` hidden unless merge is Y
    (`RP_HUID.cs:2031 {{if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) != 0)}}`, `RP_HUID.cs:2038 {{((ColumnView)GridView1).Columns["CoCode"].Visible = false;}}`);
    `Book` and `BookName` hidden (`RP_HUID.cs:2042 {{((ColumnView)GridView1).Columns["Book"].Visible = false;}}`, `RP_HUID.cs:2046 {{((ColumnView)GridView1).Columns["BookName"].Visible = false;}}`); `StkDate` hidden for two registrations (2050–2064).
    The Out view returns `''` as `KrName` (`RP_HUID.cs:1795 {{'' As KrName,A.CO_BOOK As Book}}`), the web returns `KR_NAME`
    for every tab. Web: JSON fields `huid.ts:161–190`, which add `itName` (not a desktop column) and omit nothing;
    the page has no HUID column definition. Type: missing feature (column set, order and visibility) and wrong result (Out `KrName`).
18. **Headers.** Desktop: headers are the SELECT aliases, since no caption is set. Web: generic report headers. Type: wrong text
    (the desktop text is the alias, not a caption, so the owner must choose).
19. **Totals.** Desktop: separate sums of Qty, Pcs, Grwt, NetWt, HuWt, HuWt2, HuWt3, HuWt4 (`RP_HUID.cs:2068-2096 {{((ColumnView)GridView1).Columns["Qty"].Summary.Add((SummaryItemType)0,}}`).
    Web: `count`, `hallmarkedTags`, `slots`, `netWt`, `huidWt` (`huid.ts:199–203`), where `huidWt` adds all four slot
    weights together, and no Pcs or Grwt total. Shown as scalars (page.tsx:597–606). Type: missing feature (Pcs, Grwt, per-slot totals) and wrong result (`huidWt`).
20. **Search and export.** Desktop: Excel writes the grid as shown, including any search (`RP_HUID.cs:1365 {{DGV.ExportToXlsx(text);}}`).
    Web: Excel re-derives the rows (page.tsx:1564–1566). Type: missing feature, because the web has no search (item 15).
21. **Print layout.** Desktop: `TagHuIdRpt`, grouped by product and group (`TagHuIdRpt.xml:312-313 {{<Group ConditionField="{ITEM_MAST.PR_CODE}}`), title from
    `RP_HUID.cs:2192 {{string text = "Tag Wise Huid Report As on Date ";}}`. Web: no TagHuIdRpt layout; PDF is the generic route (`txn.ts:4481–4483`). Type: missing feature.
22. **Print rights.** Desktop: none on Print (`RP_HUID.cs:2189-2191 {{private void BtnPrint_Click(object sender, EventArgs e)}}`). Web: `guard(req, reply, 'print')` on CSV, Excel and PDF
    (`txn.ts:4451`, `:4464`, `:4482`). Type: difference. Decision needed: the packet addendum says refuse, the desktop does not.
23. **Drill-down.** Desktop: double-click opens the source voucher form by `MAIN_BOOK` (`RP_HUID.cs:2252-2272 {{private void DGV_DoubleClick(object sender, EventArgs e)}}`); disabled
    when merge is Y (`RP_HUID.cs:2254 {{if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)}}`). Web: none (search for `onDoubleClick` in page.tsx returns nothing). Type: missing feature.
24. **Keyboard.** Desktop: Enter in the dates, TagNo and AcCode (`RP_HUID.cs:2644 {{if ((int)e.KeyCode == 13)}}`, `RP_HUID.cs:2229 {{if ((int)e.KeyCode != 13)}}`, `RP_HUID.cs:2689 {{if ((int)e.KeyCode != 13)}}`), Esc
    (`RP_HUID.cs:1732 {{if ((int)e.KeyCode == 27)}}`), arrows to grid (`RP_HUID.cs:1736 {{if (((int)e.KeyCode == 38)}}`), upper-casing (`RP_HUID.cs:1715 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num)}}`). Web: none for HUID. Type: missing feature.
25. **Default dates.** Desktop: From and To open on today (`RP_HUID.cs:1620-1621 {{mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}`). Web: From and To start empty
    (`page.tsx:153` declares the state as an empty string). Type: wrong result on open (desktop limits to today, web does not limit).
26. **Cancel.** Desktop: clears the screen and resets the dates (`RP_HUID.cs:1744 {{CLEAR_DATA();}}`, `RP_HUID.cs:1626-1647 {{private void CLEAR_DATA()}}`). Web: no
    HUID clear control (page.tsx:1388–1433). Type: missing feature (minor).
27. **Labels.** Desktop HuId type options: `RP_HUID.cs:1571 {{cboHuId.Items.Add((object)"With HuId");}}` and
    `RP_HUID.cs:1572 {{cboHuId.Items.Add((object)"Whout HuId");}}` (the second is a typo in the source). Web: `With HUID`,
    `Without HUID` (page.tsx:1410–1412). Type: wrong text. The web wording is intended; the owner should confirm.
28. **Title.** Desktop: `RP_HUID.cs:1067 {{lblBook.Text = "Tag Stock With HuId";}}` and the form caption
    `RP_HUID.cs:1331 {{((XtraForm)this).Text = "Tag Stock With Huid";}}`. Web: `HUID Report` (page.tsx:56). Type: wrong text. Owner to choose.
29. **Rounding.** Desktop: no rounding in the form; values come from the database as stored. Web: each weight is rounded to
    `PRECISION.weight` (`huid.ts:173–175`, `r3`). Type: possible wrong result if stored values have more decimals than
    the precision. Open question 9.

## Open questions

1. **Stock rule.** Does the owner accept the desktop's serial-sum rule (`RP_HUID.cs:1873 {{DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO}}`) or the web's count rule
   (`huid.ts:139–146`)? A test needs one tag sold and returned, and one with two movements. Settle it with aggregate counts
   on the seed company only (no customer rows). Not run here.
2. **Whitespace HUIDs.** Does the desktop's "present" rule (`<> ''`) matter for any value that is blank but not empty?
   Needs an aggregate count of such values; not run here.
3. **Settings meanings.** `CO_STK_MERGE` (`MS_OPNCOMP.cs:706 {{DC_Main.MsCoStockMerge =}}`), the `MsDataType` codes `A`, `B`, `C` (`MDI_FORM.cs:12732-12740 {{DC_Main.MsDataType = "A";}}`),
   and `MsMetalType` `G` (`RP_HUID.cs:1562 {{if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)}}`). **MISSING:** `project-memory/catalogs/settings-catalog.json` has no entry
   for `CO_STK_MERGE` (a search for `StockMerge` and `DATA_TYPE` there found nothing).
4. **Drill-down targets.** Whether the target forms use `DC_Main.CurBookVch` (`RP_HUID.cs:2272 {{DC_Main.CurBookVch = ((ColumnView)GridView1).GetFocusedRowCellValue("V}}`) to open the right voucher
   was not traced. The branch list (`RP_HUID.cs:2273-2631 {{if (Operators.CompareString(DC_Main.CurBookMain, "OPSTK", false) == 0)}}`) was read, not each target.
5. **Crystal formulas.** The bodies of `@TagQty`, `@TagGwt`, `@TagNwt`, `@TagPcs`, `@NewBal` and `@VchSrno` were not
   extracted (**MISSING**). The summary and record-selection text in the XML were not fully read.
6. **`DC_Main.SetDate`.** Its behaviour on blank or invalid text, and the message if any, were not read (**MISSING** in this
   study; `DC_Main` was out of scope).
7. **Print right.** The desktop omits the check on Print (`RP_HUID.cs:2189 {{private void BtnPrint_Click(object sender, EventArgs e)}}`), while the packet addendum requires refusal.
   The owner decides which applies to the web.
8. **List right.** The catalog's `----PL` includes List, but no code in this form reads a list right. Owner decision.
9. **Stored precision.** Does the database store weights with more decimals than `PRECISION.weight`? Affects item 29.
10. **Header text.** Desktop headers are aliases (`VchTyp`, `HuId2`) because no caption is set. Confirm with a desktop
    screenshot or the video knowledge base (`project-memory/video-research/_kb`), which was not searched here.
11. **Run-time caption.** `DC_Main.MsUserRightForm` (`RP_HUID.cs:1408 {{CurRpt = DC_Main.MsUserRightForm;}}`) gives the header text. Where it is set for this
    menu was not found in `MDI_FORM.cs:9032-9041 {{case "HuId Report":}}`, which has no assignment.
12. **Tie order.** Several controls share TabIndex values (0, 2, 7). Tab order inside a tie is not in the source.
13. **Stock join key.** The desktop's `TAG_STOCK_PRINT` insert has no `LC_CODE` in its WHERE (`RP_HUID.cs:2179 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`). Whether a
    tag can exist in two locations of one company with the same serial is not checked.
