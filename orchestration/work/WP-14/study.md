# WP-14 study: Report → Order Report (desktop `RP_ALL`, caption "Order Report")

All desktop citations are `RP_ALL.cs`, `MDI_FORM.cs`, `DC_Main.cs` or `Module_Save.cs` under `unified/src/csharp/DataCareNext/`.
The seven Crystal templates are described from `web/apps/api/report-specs/*.spec.json` (field lists only; those files are
not quoted because the citation script reads C# lines). Web statements cite `file:line` without quotes.

## Scope

- Menu: Report → Order Report. `MDI_FORM.cs:8931 {{case "Order Report":}}` builds the form with `MDI_FORM.cs:8933 {{RP_ALL rP_ALL4 = new RP_ALL();}}`.
  No constructor argument carries the mode. The form takes its mode from the menu caption: `MDI_FORM.cs:7034 {{DC_Main.MsUserRightForm = MsSideBtn;}}` and then
  `RP_ALL.cs:6658 {{CurRpt = DC_Main.MsUserRightForm;}}`.
- Form: `RP_ALL` is 12,662 lines (12,663 in the index count). It is shared by Sales Report, Purchase Rpt, Approval Rpt, Order Report, Scheme Report, Item InOut,
  Kr, Reparing, Vp and Bul reports. Only the Order Report branch is studied here.
- Order Report panel: `RP_ALL.cs:6713-6717 {{else if (Operators.CompareString(CurRpt, "Order Report", false) == 0)}}` shows `PanelOrder` at the position of `PanelSale`
  (`RP_ALL.cs:6715 {{((Control)PanelOrder).Visible = true;}}`). Unlike the Sales branch it does not show `cboEmploy` or `chkBookSelect` and does not call `BookMast()`
  (compare `RP_ALL.cs:6680 {{((Control)cboEmploy).Visible = true;}}` in the Sales branch).
- Lite edition: no `MsSoftType` check exists in the dispatch (`MDI_FORM.cs:8931-8940 {{case "Order Report":}}`) or anywhere in the Order Report branch of `RP_ALL`. The menu catalog
  (`docs/handbook/menu-catalog.jsonl`, row `Report/Order Report`) lists the tables SL_ORD_DATA, SL_ORD_DETL, SL_ORD_ADJ, SL_DATA, AC_MAST, BOOK_DATA. The Lite gating
  of the menu is therefore not decided in these two files: see Open questions.
- The seven buttons of the panel (`RP_ALL.cs:5219-5225 {{((Control)PanelOrder).Controls.Add((Control)(object)btnbillwiseordadj);}}`) are the **data modes** of this caption:
  1. Order Report (`btnOrdRpt`, template `OrdDetlRpt`)
  2. Order Advance (`btnOrdAdvance`, `OrdAdvRpt`)
  3. Order Adjust (`btnOrdAdj`, `OrdAdvAdj`)
  4. Order Wise Bill (`btnOrdWithBill`, `OrdAdjBillWise`)
  5. Making Panding (`BtnOrdMakePan`, `OrdDetlPanding`)
  6. Making Summ (`btnDesignSumm`, `OrdDesignSumm`)
  7. Bill Wise Adjust (`btnbillwiseordadj`, `BillWiseOrderAdjust`)
- Out of scope: the Sales/Purchase/Approval panels, the Sales `btnSlWithOrder` button (`RP_ALL.cs:11735 {{private void btnSlWithOrder_Click(object sender, EventArgs e)}}`, Sales panel; mentioned only as a contrast), the Crystal rendering engine, and the
  item/employee/state selectors the Order panel does not use.

## Screen

Selectors live on the form, outside the panel; the panel holds only the seven buttons. Tab order (the form's `TabIndex`) is not the visual order.

| Caption | Control | Type | TabIndex | Default and rules |
|---|---|---|---|---|
| From / To Date | `mFromDt` | MaskedTextBox, mask `00/00/0000` | 0 | `01/01/2010` for Order Report |
| (To date) | `mToDt` | MaskedTextBox, mask `00/00/0000` | 1 | system date |
| lc Code | `tLcCode` (+ `tLcName`) | TextBox, max 8 | 2 | session location; disabled unless location is `00` |
| Book | `tBookCode` (+ `tBookName`) | TextBox, max 8 | 3 | empty |
| Pr Code | `tItCode` (+ `tItName`) | TextBox, max 8 | 4 | empty; not read by any Order Report button |
| Gr Code | `tGrCode` | TextBox, max 8 | 5 | empty; not read by any Order Report button |
| Party Code | `tAcCode` (+ `tAcName`) | TextBox, max 8 | 6 | empty |
| Cust Name | `tCustName` | TextBox, max 50 | 7 | empty |
| City | `cboCity` | ComboBox | 8 | blank item |
| Area | `cboArea` | ComboBox | 9 | blank item |
| Item Type | `cboItemTyp` | ComboBox | 10 | index 0 (blank); not read by any Order Report button |
| &Print / &Cancel / E&xit | `BtnPrint` / `BtnCancel` / `BtnExit` | buttons | 26 / 23 / 25 | see Keyboard |
| Panel buttons | `btnOrdRpt` 0, `btnOrdAdvance` 1, `btnOrdAdj` 2, `btnOrdWithBill` 3, `BtnOrdMakePan` 4, `btnDesignSumm` 5, `btnbillwiseordadj` 6 | simple buttons | as listed | |

Citations for the table:
- Labels: `RP_ALL.cs:4808 {{Label2.Text = "From / To Date";}}`, `RP_ALL.cs:4832 {{Label3.Text = "Party Code";}}`, `RP_ALL.cs:4798 {{Label1.Text = "Book";}}`,
  `RP_ALL.cs:4851 {{lblCity.Text = "City";}}`, `RP_ALL.cs:4870 {{Label17.Text = "Area";}}`, `RP_ALL.cs:4894 {{Label4.Text = "Pr Code";}}`,
  `RP_ALL.cs:4910 {{Label5.Text = "Item Type";}}`, `RP_ALL.cs:4934 {{Label6.Text = "lc Code";}}`.
- Order Report does not rename labels (only Scheme Report does, `RP_ALL.cs:6721 {{Label4.Text = "Schm Code";}}`).
- Tab order: `RP_ALL.cs:5622 {{((Control)mFromDt).TabIndex = 0;}}`, `RP_ALL.cs:5614 {{((Control)mToDt).TabIndex = 1;}}`, `RP_ALL.cs:4918 {{((Control)tLcCode).TabIndex = 2;}}`,
  `RP_ALL.cs:4782 {{((Control)tBookCode).TabIndex = 3;}}`, `RP_ALL.cs:4878 {{((Control)tItCode).TabIndex = 4;}}`, `RP_ALL.cs:5630 {{((Control)tGrCode).TabIndex = 5;}}`,
  `RP_ALL.cs:4816 {{((Control)tAcCode).TabIndex = 6;}}`, `RP_ALL.cs:5795 {{((Control)tCustName).TabIndex = 7;}}`, `RP_ALL.cs:4842 {{((Control)cboCity).TabIndex = 8;}}`,
  `RP_ALL.cs:4861 {{((Control)cboArea).TabIndex = 9;}}`, `RP_ALL.cs:4902 {{((Control)cboItemTyp).TabIndex = 10;}}`.
- Panel button tab order and captions: `RP_ALL.cs:5359 {{((Control)btnOrdRpt).TabIndex = 0;}}`, `RP_ALL.cs:5385 {{((Control)btnOrdAdvance).TabIndex = 1;}}`,
  `RP_ALL.cs:5411 {{((Control)btnOrdAdj).TabIndex = 2;}}`, `RP_ALL.cs:5333 {{((Control)btnOrdWithBill).TabIndex = 3;}}`, `RP_ALL.cs:5307 {{((Control)btnOrdMakePan).TabIndex = 4;}}`,
  `RP_ALL.cs:5281 {{((Control)btnDesignSumm).TabIndex = 5;}}`, `RP_ALL.cs:5255 {{((Control)btnbillwiseordadj).TabIndex = 6;}}`. Captions: `RP_ALL.cs:5360 {{btnOrdRpt.Text = "&Order Report";}}`,
  `RP_ALL.cs:5386 {{btnOrdAdvance.Text = "&Order Advance";}}`, `RP_ALL.cs:5412 {{btnOrdAdj.Text = "&Order Adjust";}}`, `RP_ALL.cs:5334 {{btnOrdWithBill.Text = "&Order Wise Bill ";}}`
  (note the trailing space), `RP_ALL.cs:5308 {{btnOrdMakePan.Text = "&Making Panding";}}`, `RP_ALL.cs:5282 {{btnDesignSumm.Text = "& Making Summ";}}` (note the space after `&`),
  `RP_ALL.cs:5256 {{btnbillwiseordadj.Text = "Bill Wise Adjust";}}`.
- Maximum lengths: `RP_ALL.cs:4813 {{((TextBoxBase)tAcCode).MaxLength = 8;}}`, `RP_ALL.cs:5792 {{((TextBoxBase)tCustName).MaxLength = 50;}}`. Mask: `RP_ALL.cs:5619 {{mFromDt.Mask = "00/00/0000";}}`.
- Form title label: `RP_ALL.cs:6659 {{lblBook.Text = CurRpt;}}` shows "Order Report".
- Defaults: `RP_ALL.cs:7177 {{mFromDt.Text = "01/01/2010";}}` is the first of three branches; the Order Report test is `RP_ALL.cs:7175 {{if (Operators.CompareString(CurRpt, "Order Report", false) == 0)}}`.
  `RP_ALL.cs:7203 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}`. Focus starts on From date: `RP_ALL.cs:7204 {{CurActCtrl = (Control)(object)mFromDt;}}`.
- Location: `RP_ALL.cs:6662 {{tLcCode.Text = DC_Main.MLc_code;}}` and `RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}`; the disable applies when the session location is not `00` (`RP_ALL.cs:6660 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}}`).
  So `tLcCode` is never empty at load; every report is therefore filtered by `LC_CODE` (including `00`).
- City and Area lists come from AC_MAST: `RP_ALL.cs:7121 {{SELECT AC_AREA FROM AC_MAST WHERE CO_CODE = '}}` (area) and the city query in the same block (`RP_ALL.cs:7087 {{DC_Main.RsQry = "SELECT AC_CITY FROM AC_MAST WHERE CO_CODE = '" + DC_M}}`, see Rules). An empty
  list adds one blank item (the `cboCity.Items.Add((object)"")` call in the same block).
- Item Type items for non-Scheme branches: `RP_ALL.cs:7166 {{cboItemTyp.Items.Add((object)"Gold");}}` etc. They have no effect on any Order button.
- Not shown for Order Report: `cboEmploy` is hidden by default (`RP_ALL.cs:6400 {{((Control)cboEmploy).Visible = false;}}`), `chkBookSelect` is hidden by default (`RP_ALL.cs:6539 {{((Control)chkBookSelect).Visible = false;}}`).
  The "Select Book" list is therefore unreachable in this mode.

## Keyboard

- Esc anywhere closes the form: `RP_ALL.cs:7261 {{if ((int)e.KeyCode == 27)}}` then `RP_ALL.cs:7263 {{((Form)this).Close();}}`.
- Every typed character is upper-cased and `'` (39) is swallowed: `RP_ALL.cs:7251 {{if (num == 0 || num == 39)}}`.
- Enter on `mFromDt` and `mToDt` runs `DC_Main.SetDate`; if the date is accepted a Tab is sent: `RP_ALL.cs:7517 {{DC_Main.SetDate(ref MsDate);}}`, `RP_ALL.cs:7521 {{SendKeys.Send("{tab}");}}`,
  `RP_ALL.cs:7533 {{DC_Main.SetDate(ref MsDate);}}`. `SetDate` (`DC_Main.cs:1561 {{public static void SetDate(ref MaskedTextBox MsDate)}}`) fills a short date from today and the financial year and sets `RongDate` for a bad entry.
- Enter on `tLcCode`: empty → Tab (`RP_ALL.cs:7718 {{SendKeys.Send("{tab}");}}`); typed code that exists in LOCT_MAST → name shown and Tab; unknown code → location help list (`RP_ALL.cs:7695 {{Select LC_CODE As CodeL,LC_NAME As NameL,LC_ADD1 As AddressL,LC_CITY As CityL FROM LOCT_MAST}}`).
  Selecting from the help writes both code and name; closing it leaves the field unchanged.
- Enter on `tBookCode`: empty → Tab (`RP_ALL.cs:7328 {{SendKeys.Send("{tab}");}}`); known book → name and Tab (`RP_ALL.cs:7322 {{tBookName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BOOK_NAME"], (object)""));}}`);
  unknown book → help list of books of the session location (`RP_ALL.cs:7303 {{SELECT A.BOOK_NAME As BookNameL,A.CO_BOOK As BookL FROM BOOK_DATA AS A}}`); after the help the focus returns to `tBookCode` (`RP_ALL.cs:7317 {{((Control)tBookCode).Focus();}}`).
  The book lookup (`RP_ALL.cs:7299 {{Select * From BOOK_DATA WHERE CO_CODE = '}}`) is not filtered by order books: any book of the location is accepted.
- Enter on `tAcCode` (not Scheme Report): lookup in AC_MAST (`RP_ALL.cs:7382 {{Select * From AC_MAST WHERE CO_CODE = '}}`), known code → name and Tab (`RP_ALL.cs:7421 {{tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Mai}}`);
  unknown → party help (three variants: all branches `RP_ALL.cs:7388 {{DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC}}`, other locations `RP_ALL.cs:7392 {{DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC}}`, location `00` `RP_ALL.cs:7396 {{DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC}}`), choosing writes code and name, then focus returns to `tAcCode` (`RP_ALL.cs:7416 {{((Control)tAcCode).Focus();}}`).
- Enter on `tCustName` (Order Report branch): the Order Report test is `RP_ALL.cs:9687 {{if (Operators.CompareString(CurRpt, "Order Report", false) == 0)}}`. A name found in SL_ORD_DATA (`RP_ALL.cs:9689 {{SELECT A.AC_NAME FROM SL_ORD_DATA AS A  WHERE A.CO_CODE}}`) is copied back and the focus goes to City (`RP_ALL.cs:9712 {{((Control)cboCity).Focus();}}`); an unknown name opens a help list (`RP_ALL.cs:9693 {{SELECT A.AC_NAME As CustomerNameL,A.AC_CODE AS AcCodel FROM SL_ORD_DATA AS A WHERE A.CO_CODE}}`) and the focus returns to Cust Name after it closes; an empty field goes to City (`RP_ALL.cs:9723 {{((Control)cboCity).Focus();}}`). In any other caption the typed name is cleared (`RP_ALL.cs:9717 {{tCustName.Text = "";}}`).
- Enter on `cboCity`, `cboArea`: Tab (`RP_ALL.cs:7548 {{SendKeys.Send("{tab}");}}`, `RP_ALL.cs:7558 {{SendKeys.Send("{tab}");}}`). Enter on `tItCode` when empty jumps to City (`RP_ALL.cs:7506 {{((Control)cboCity).Focus();}}`).
- Alt hot keys: the captions carry `&` marks (Order Report, Order Advance, Order Adjust and Order Wise Bill all use `&O`; Making Panding uses `&M`; Making Summ has `& ` with a space and so no hot key; Bill Wise Adjust has none). This is read from the caption text, not from a key handler. Cancel and Exit are `&Cancel` and `E&xit` (`RP_ALL.cs:4317 {{BtnCancel}}`, `RP_ALL.cs:4290 {{BtnExit}}`).
- No F-key and no Ctrl combination is handled in `RP_ALL_KeyDown` (`RP_ALL.cs:7257-7266 {{private void RP_ALL_KeyDown(object sender, KeyEventArgs e)}}`: only Esc).
- Cancel clears the form: `RP_ALL.cs:7273 {{CLEAR_DATA();}}`; `CLEAR_DATA` blanks every TextBox, resets masked boxes to `DC_Main.MMask` (`RP_ALL.cs:7221 {{val.Text = DC_Main.MMask;}}`) and does **not** reset the combo boxes
  (City, Area, Item Type keep their values) and does not restore the default dates.
- Print does nothing: `RP_ALL.cs:7267-7269 {{private void BtnPrint_Click(object sender, EventArgs e)}}` has an empty body; each panel button prints for itself. Exit closes: `RP_ALL.cs:7230 {{((Form)this).Close();}}`.

## Rules

Validation is almost absent. There are **no message boxes** in the Order Report branch except the one Yes/No prompt of Making Summ.

- No check that From ≤ To, no check that a date is valid beyond the mask and `SetDate`. A From after To gives an empty report (the filter is a range).
  `Conversions.ToDate(mFromDt.Text)` is called in every button (`RP_ALL.cs:8380 {{CurFormula = "{SL_ORD_DATA.CO_CODE} = '}}`); an incomplete mask text would raise a runtime error. *Inferred:* the source has no guard.
- Party, Book, Location existence is checked only on Enter; clicking a panel button right after typing an unknown code does not re-check it, so the filter text is used as typed
  (`RP_ALL.cs:8391 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_CODE} = '" + tAcCode.Text + "'";}}`). The report is then empty.
- Message "Only Design Summery Report.." (Yes/No, `MsgBoxStyle 4`, title `DC_Main.MsgTitle`): `RP_ALL.cs:11889 {{Only Design Summery Report..}}` (new Crystal path) and `RP_ALL.cs:11906 {{Only Design Summery Report..}}`
  (Crystal Reports ActiveX path). Yes (6) sets `OnlySumm = 'Y'`, otherwise `'N'` (`RP_ALL.cs:11892 {{DC_Main.MsCrForStr1 = "'Y'";}}`). Focus is unchanged.
- "Book Selection Not Done..." / "Book Selection is Ok..." (`RP_ALL.cs:11392 {{Interaction.MsgBox((object)"Book Selection Not Done...", (MsgBoxStyle)}}`, `RP_ALL.cs:11398 {{Interaction.MsgBox((object)"Book Selection is Ok...", (MsgBoxStyle)0, }}`) belong to `BtnOk_Click` of the Sales book list and are not reachable here (the check box is hidden, see Screen).
- Message texts with typos that must be kept if a message is ever shown: "Panding" in the captions and in the title `Order Design Issue Panding Report` (`RP_ALL.cs:10976 {{DC_Main.MsRptTitelStr = "'Order Design Issue Panding Report From " + S}}`), "Summery" in the prompt.

## Calculations

The form itself calculates **no money or weight**. It builds a Crystal record-selection formula and passes it with a title; every amount, sum and balance is computed in the template.

Selection formula, common to buttons 1 to 5 (`SL_ORD_DATA` base). The first clause (`RP_ALL.cs:8380 {{CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {}}`):
`CO_CODE = session company AND VCH_DATE >= #MM/dd/yyyy# AND VCH_DATE <= #MM/dd/yyyy#` (`RP_ALL.cs:8380 {{AND {SL_ORD_DATA.VCH_DATE} >= #}}`), then optional clauses in this fixed order:

| Order | Condition | Source line |
|---|---|---|
| 1 | `SL_ORD_DATA.LC_CODE = tLcCode` when not empty | `RP_ALL.cs:8383 {{CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";}}` |
| 2 | `SL_ORD_DATA.CO_BOOK = tBookCode` | `RP_ALL.cs:8387 {{CurFormula = CurFormula + " And {SL_ORD_DATA.CO_BOOK} = '" + tBookCode.Text + "'";}}` |
| 3 | `SL_ORD_DATA.AC_CODE = tAcCode` | `RP_ALL.cs:8391 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_CODE} = '" + tAcCode.T}}` (above) |
| 4 | `AC_MAST.AC_CITY = cboCity` | `RP_ALL.cs:8395 {{CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";}}` |
| 5 | `AC_MAST.AC_AREA = cboArea` | `RP_ALL.cs:8399 {{CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";}}` |
| 6 | `SL_ORD_DATA.AC_NAME = tCustName` (exact, case as stored) | `RP_ALL.cs:8403 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";}}` |
| 7 | `BOOK_DATA.DATA_TYPE = DC_Main.MsDataType` only when it is `A` or `B` (type `C` = all) | `RP_ALL.cs:8405 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}}`, `RP_ALL.cs:8409 {{else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)}}` |

Notes on these filters:
- There is **no year filter** on `SL_ORD_DATA` in buttons 1 to 5 (compare `RP_ALL.cs:11748 {{CurFormula = "{SL_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DETL.CO_YEAR} = '"}}` for Sales With Order, which does filter the year).
  An order from any earlier year in the date range is therefore listed.
- Party Code (`SL_ORD_DATA.AC_CODE`) is typed; Cust Name (`SL_ORD_DATA.AC_NAME`) is a name stored on the order (walk-in customers have a name but may have no ledger account).
- City and Area filter on `AC_MAST` joined by the template's link; an order with no matching account row drops out as soon as either filter is used.
- Pr Code, Gr Code, Item Type, Employee are **not** appended in any of the seven handlers.
- Titles (`RptTitel`): `RP_ALL.cs:8416 {{DC_Main.MsRptTitelStr = "'Order Report From "}}`, `RP_ALL.cs:8482 {{DC_Main.MsRptTitelStr = "'Order Advance Report From "}}`,
  `RP_ALL.cs:8548 {{DC_Main.MsRptTitelStr = "'Order Adjust Report From "}}`, `RP_ALL.cs:9774 {{DC_Main.MsRptTitelStr = "'Bill Wise Order Adjust Report From "}}`,
  `RP_ALL.cs:10976 {{DC_Main.MsRptTitelStr = "'Order Design Issue Panding Report From "}}`, `RP_ALL.cs:11887 {{DC_Main.MsRptTitelStr = "'Order Design Issue Panding Report From "}}`,
  `RP_ALL.cs:12644 {{DC_Main.MsRptTitelStr = "'Bill Wise Order Adjust Report From "}}`. Dates in titles use `dd/MM/yyyy`; in the formula `MM/dd/yyyy`. Making Summ reuses the Making Panding title, so the two reports carry the same title.
  Button 4 (Order Wise Bill, `OrdAdjBillWise`) and button 7 (Bill Wise Adjust, `BillWiseOrderAdjust`) both print the title "Bill Wise Order Adjust Report".
- Rounding: none in the form. Template totals are the sums listed under Lifecycle and write set; the Crystal engine applies the field format of each template.

## Lifecycle and write set

This is a report. The selection, per data mode:

**1. Order Report** (`btnOrdRpt`, `RP_ALL.cs:8366-8434 {{private void btnOrdRpt_Click(object sender, EventArgs e)}}`; template file `RP_ALL.cs:8378 {{\\Report\\OrdDetlRpt.RPT}}`, print name `RP_ALL.cs:8418 {{DC_Main.RptName = "OrdDetlRpt";}}`).
Rows: one per `SL_ORD_DETL` line joined to `SL_ORD_DATA`, `ITEM_MAST`, `AC_MAST`, `BOOK_DATA`. Template columns: voucher no, date, customer name, advance amount, delivery date, item code and name, design no, size, pieces, net weight,
item rate, item amount, labour rate and amount, other amount, net amount. Totals: `Sum` of `ITM_PCS` and `ITM_NWT`. It lists **all** orders in the range (open, delivered and cancelled alike): the form has no status filter.
No sign logic here.

**2. Order Advance** (`RP_ALL.cs:8435-8500 {{private void btnOrdAdvance_Click(object sender, EventArgs e)}}`, `RP_ALL.cs:8444 {{\\Report\\OrdAdvRpt.RPT}}`, `RP_ALL.cs:8484 {{DC_Main.RptName = "OrdAdvRpt";}}`). One row per order header. Template columns: customer, voucher no, date, order total (`TOT_AMT`), cash, card, cheque,
old gold, old silver, and advance (`ADV_AMT`). No grand total formula in the template; each tender column is stored on `SL_ORD_DATA`.

**3. Order Adjust** (`RP_ALL.cs:8501-8566 {{private void btnOrdAdj_Click(object sender, EventArgs e)}}`, `RP_ALL.cs:8510 {{\\Report\\OrdAdvAdj.RPT}}`, `RP_ALL.cs:8550 {{DC_Main.RptName = "OrdAdvAdj";}}`). Header joined to `SL_ORD_ADJ`. Template columns: voucher, date, customer,
`ORD_SIGN`, `ORD_AMT`, adjusting voucher keys (`ORD_LC`, `ORD_YRCD`, `ORD_DBCD`, `ORD_NO`), `ADV_AMT`, `ORD_ADJ_AMT`. The template groups by `@OrdGroup` and sums `@OrdAmt`, `@OrdAdjAmt`, `@BalAmt` per group and overall.
The sign of an adjustment is the column `ORD_SIGN`; the desktop's own balance rule is the one used by the pending queries below:
`RP_ALL.cs:10927 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  = 0}}`.

**4. Order Wise Bill** (`btnOrdWithBill`, `RP_ALL.cs:9727-9792 {{private void btnOrdWithBill_Click(object sender, EventArgs e)}}`, `RP_ALL.cs:9736 {{\\Report\\OrdAdjBillWise.RPT}}`, `RP_ALL.cs:9776 {{DC_Main.RptName = "OrdAdjBillWise";}}`). Per order, the sale bills that adjusted it
(`SL_ORD_ADJ` rows with the bill book, number, date, bill total from `SL_DATA.TOT_AMT`, party name, sign and amount); total is `Sum ({@AdjAmt}, {SL_ORD_DATA.VCH_NO})`, one total per order.

**5. Making Panding** (`BtnOrdMakePan`, `RP_ALL.cs:10912-10995 {{private void BtnOrdMakePan_Click(object sender, EventArgs e)}}`; template `RP_ALL.cs:10921 {{\\Report\\OrdDetlPanding.RPT}}`, `RP_ALL.cs:10978 {{DC_Main.RptName = "OrdDetlPanding";}}`).
**This report writes first.** In order:
1. `RP_ALL.cs:10927 {{DC_Main.RsQry = "Select A.CO_YEAR,A.CO_BOOK,A.VCH_NO FROM SL_ORD_DATA }}` selects the orders of the session company and location whose adjustments net to zero:
   {{Select A.CO_YEAR,A.CO_BOOK,A.VCH_NO FROM SL_ORD_DATA As A LEFT JOIN SL_ORD_ADJ As B On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC}} ... `GROUP BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO HAVING SUM(...) = 0`.
   An order with no `SL_ORD_ADJ` row gives a NULL sum and is **not** selected; an order whose `+` and `-` adjustments cancel (fully adjusted) **is**.
2. For each such order `RP_ALL.cs:10933 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}` runs {{UPDATE SL_ORD_DETL SET DESIGN_ISU = 'Y' WHERE CO_CODE = '}} with the key `CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO` (all lines of the order), executed one by one by `DC_Main.ExeQuteDc` (`RP_ALL.cs:10934 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}`).
   No transaction, no user check, no rights check: running a read-only report changes data.
3. `RP_ALL.cs:10937 {{SELECT TOP(5) * FROM SL_ORD_DATA WHERE CO_CODE = '}}` reads five header rows and discards them (the result `Rshlp` is not used afterwards in the cited lines).
4. The formula (`RP_ALL.cs:10940 {{CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {}}`) is the common one plus `RP_ALL.cs:10940 {{AND {SL_ORD_DETL.DESIGN_ISU} = 'N'}}`: lines whose `DESIGN_ISU` is still `N` are shown. The lines flagged `Y` in step 2 therefore disappear.
Template columns: book short name, date, voucher, customer, old gold, advance, item code and name, size, pieces, net weight, design no, tag no, year, book. Totals: `Sum` of `ITM_PCS` and `ITM_NWT`.
Because the update and the report use the same name, "Panding" here means "not yet issued to design/making". *Inferred:* the desktop marks an order as design-issued when its advance is fully adjusted, which looks accidental; it is the source's behaviour and the only source of the `Y` flag in this form.

**6. Making Summ** (`btnDesignSumm`, `RP_ALL.cs:11818-11923 {{private void btnDesignSumm_Click(object sender, EventArgs e)}}`; template `RP_ALL.cs:11831 {{\\Report\\OrdDesignSumm.RPT}}`, `RP_ALL.cs:11899 {{DC_Main.RptName = "OrdDesignSumm";}}`). The same steps 1 to 4 as button 5
(`RP_ALL.cs:11837 {{DC_Main.RsQry = "Select A.CO_YEAR,A.CO_BOOK,A.VCH_NO FROM SL_ORD_DATA }}`, `RP_ALL.cs:11843 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`, `RP_ALL.cs:11847 {{DC_Main.RsQry = "SELECT TOP(5) * FROM SL_ORD_DATA WHERE CO_CODE = '" +}}`, `RP_ALL.cs:11850 {{CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {}}`), then the Yes/No prompt and the Crystal formula parameter `OnlySumm`. Totals: `Sum` of `ITM_PCS` and `ITM_NWT` per `@VchGroup` and overall.
The template body is the same field set as button 5 (item name, book, voucher, customer, size, design, tag).

**7. Bill Wise Adjust** (`btnbillwiseordadj`, `RP_ALL.cs:12597-12663 {{private void btnbillwiseordadj_Click(object sender, EventArgs e)}}`). The base is the **sale bill** table, not the order table: `RP_ALL.cs:12608 {{CurFormula = "{SL_DATA.CO_CODE} = '}}` and the filters `RP_ALL.cs:12611 {{CurFormula = CurFormula + " And {SL_DATA.LC_CODE} = '" + tLcCode.Text + "'";}}`,
`RP_ALL.cs:12631 {{CurFormula = CurFormula + " And {SL_DATA.AC_NAME} = '" + tCustName.Text + "'";}}`. Template `RP_ALL.cs:12606 {{\\Report\\BillWiseOrderAdjust.RPT}}`, `RP_ALL.cs:12646 {{DC_Main.RptName = "BillWiseOrderAdjust";}}`.
Columns: sale party, book, bill no, date, bill total, advance on the bill, the order adjusted (year code, book code, number), adjusted amount; total `Sum ({@AdjAmt}, {SL_ORD_DATA.VCH_NO})`. Here "Cust Name" filters `SL_DATA.AC_NAME`, but the Enter-key help
of Cust Name still lists names from `SL_ORD_DATA` (`RP_ALL.cs:9689 {{DC_Main.RsQry = "SELECT A.AC_NAME FROM SL_ORD_DATA AS A  WHERE A.CO_CO}}`), which is a mismatch inherited from the shared handler.

**Open, delivered and cancelled orders.** The form has no status column and no "open/delivered/cancelled" selector. The caption of the task is therefore not a data-mode list of the desktop: the seven buttons above are. An order is "open" when its adjustments do
not net to zero (see the `HAVING` clause), and delivery against an order is visible only through `SL_ORD_ADJ`. *Inferred:* cancelled orders are the ones the Order Cancel screen refunds through `SL_ORD_ADJ`; this form does not distinguish them.

Drill-down: none. The templates are static and there is no double-click handler in the Order panel.

Tables read: `SL_ORD_DATA` (all but 7), `SL_ORD_DETL` (1, 5, 6), `SL_ORD_ADJ` (3, 4, 5, 6, 7), `SL_DATA` (4, 7), `AC_MAST`, `BOOK_DATA`, `ITEM_MAST` (via templates). Tables written: `SL_ORD_DETL.DESIGN_ISU` only (buttons 5 and 6).

## Print

- Two paths, chosen by `DC_Main.MsCrystalRptType`: `"N"` → `Module_Save.ShowReportPreview()` with `DC_Main.RptName` and `DC_Main.RptFormula` (`RP_ALL.cs:8413 {{if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)}}`,
  `RP_ALL.cs:8419 {{DC_Main.RptFormula = CurFormula;}}`); `"O"` → the old ActiveX control: report file `...\Report\<name>.RPT`, `Cr.SelectionFormula = CurFormula`, `Cr.Destination = 0` (screen), window maximised (`RP_ALL.cs:8425 {{Cr.SelectionFormula = CurFormula;}}`, `RP_ALL.cs:8430 {{Cr.Action = -1;}}`).
  `ShowReportPreview` applies the formula: `Module_Save.cs:110 {{val.RecordSelectionFormula = DC_Main.RptFormula;}}`.
- Templates and parameters:

| Button | Template | Parameter passed |
|---|---|---|
| Order Report | `OrdDetlRpt` | `RptTitel` = "Order Report From dd/MM/yyyy To dd/MM/yyyy" |
| Order Advance | `OrdAdvRpt` | `RptTitel` = "Order Advance Report From … To …" |
| Order Adjust | `OrdAdvAdj` | `RptTitel` = "Order Adjust Report From … To …" |
| Order Wise Bill | `OrdAdjBillWise` | `RptTitel` = "Bill Wise Order Adjust Report From … To …" |
| Making Panding | `OrdDetlPanding` | `RptTitel` = "Order Design Issue Panding Report From … To …" |
| Making Summ | `OrdDesignSumm` | `RptTitel` and `OnlySumm` (`'Y'` or `'N'`, `RP_ALL.cs:11892 {{DC_Main.MsCrForStr1 = "'Y'";}}`, `RP_ALL.cs:11897 {{DC_Main.MsCrForStr1 = "'N'";}}`) |
| Bill Wise Adjust | `BillWiseOrderAdjust` | `RptTitel` = "Bill Wise Order Adjust Report From … To …" |

- `MsWappPrintType` is "All" in every handler (`RP_ALL.cs:8417 {{DC_Main.MsWappPrintType = "All";}}`).
- Print-rights check: **none**. `UserPrint` is read from USER_SET (`RP_ALL.cs:6777 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}`) but no handler compares it:
  a search of `RP_ALL.cs` finds the name only in its declaration (`RP_ALL.cs:447 {{private string UserPrint;}}`) and this assignment. So FRM_PRINT does not block an Order Report on the desktop.

## Rights

- At load: `RP_ALL.cs:6656 {{Select * From USER_SET WHERE LC_CODE = '}}` with `SUB_MENU = DC_Main.MsUserRightForm`, i.e. the menu caption "Order Report" (`MDI_FORM.cs:7034 {{DC_Main.MsUserRightForm = MsSideBtn;}}`). `FRM_EDIT`, `FRM_DELETE` and `FRM_PRINT` are copied
  (`RP_ALL.cs:6775 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));}}`) and **never used**; no message is shown.
- Whether the user may open the menu at all is decided in `MDI_FORM` before the form is built (the USER_SET row for the caption); `RP_ALL` itself refuses nothing.
- Location lock: a user whose location is not `00` cannot change `tLcCode` (`RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}`), so their reports cover their own location only.

## Desktop weaknesses not to port

1. SQL and formulas are built by joining strings with typed text and no escaping: `RP_ALL.cs:8403 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";}}`. (A quote is blocked by `RP_ALL_KeyPress`, `RP_ALL.cs:7251 {{if (num == 0 || num == 39)}}`, only for typed keys.)
2. A report that writes: Making Panding and Making Summ update `SL_ORD_DETL.DESIGN_ISU` with no transaction, no rights check and no audit: `RP_ALL.cs:10933 {{UPDATE SL_ORD_DETL SET DESIGN_ISU = 'Y' WHERE CO_CODE = '}}`, one statement per order (`RP_ALL.cs:10934 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}`).
   The web report must be read-only; the flag must be derived in the query (or left to a separate, rights-checked action).
3. The update is unscoped by date and filter: it flags **every** fully adjusted order of the company and location, not only the ones in the printed range: `RP_ALL.cs:10927 {{WHERE A.CO_CODE = '}}` has no date or party clause.
4. A dead query: `RP_ALL.cs:10937 {{SELECT TOP(5) * FROM SL_ORD_DATA WHERE CO_CODE = '}}` reads five rows and uses nothing.
5. FRM_PRINT is loaded and never checked (`RP_ALL.cs:6777 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable}}`). The web must not copy the missing print rights; follow the Sales Report rule recorded for the caption.
6. No guard on dates or From > To (see Rules). The web should answer a bad date with a clear message and keep From > To as an empty report.
7. The first-run defaults `01/01/2010` (`RP_ALL.cs:7177 {{mFromDt.Text = "01/01/2010";}}`) is a hard-coded date: a year-aware default is not a desktop behaviour to keep, but the visible default is.
8. Cust Name help is built from `SL_ORD_DATA` even when the button filters `SL_DATA` (button 7).
9. Hidden/undocumented selectors: Pr Code, Gr Code and Item Type are visible for Order Report and do nothing. Do not build working filters for them; either omit them or show them disabled.

## Web today

- `web/apps/api/src/modules/reports/rpAll/` (engine, filters, `salesLayouts.ts`, `salesQuery.ts`, `exportRows.ts`, `index.ts`): the shared RP_ALL engine; `types.ts:17` declares only `RpAllBranch = 'sales'`.
  `index.ts:29-31` says Order Report is meant to add an adapter beside `sales`.
- `web/apps/api/src/routes/rpAllReport.ts`: `GET /reports/sales-report` and exports; there is no Order Report route.
- `web/apps/api/src/routes/txn.ts:1958`: `GET /sales-orders` lists orders (transaction list); `txn.ts:2217` serves the printable order confirmation (`OrderBill`, `OrdVchImg`, `OrderVch` templates), not a report.
- `web/apps/api/src/modules/reports/orderReportLayout.ts`, `orderReportValues.ts`, `orderReportImages.ts`, `reportBind.ts`: bind and render the **per-order** confirmation document; tests `web/apps/api/test/orderReport.test.ts`, `orderImageReport.test.ts`.
  These names say "order report" but implement the voucher print, not RP_ALL's Order Report.
- Seven report specs exist (`web/apps/api/report-specs/OrdDetlRpt.spec.json`, `OrdAdvRpt`, `OrdAdvAdj`, `OrdAdjBillWise`, `OrdDetlPanding`, `OrdDesignSumm`, `BillWiseOrderAdjust`) but nothing in the API reads them for this menu.
- `web/apps/web/test/features/modules/salesOrder.mjs` and `orderCancel.mjs`: browser modules for Sales Order and Order Cancel only; there is no `orderReport.mjs`. `web/apps/web/app` has no `order-report` page (a search of `web/apps` for `order-report` finds only the API's `order-report-spec-unavailable` error code at `txn.ts:2217`).
- Rights: `web/apps/api/src/modules/rbac/formCatalog.ts` has no alias for the caption "Order Report"; the lineage row G225 says it is left on purpose because the screen uses the Sales Order form (`docs/master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md:240` and `:2670`).
- Menu catalog row `Report/Order Report` (`docs/handbook/menu-catalog.jsonl:184`) says the UI is `/txn/sales-order` and the status is `REPORT`, with gap text "RP_ALL order report modes, cross-book filters, summaries and Crystal layouts are missing".

## Gaps

Open lineage rows naming this menu: **G225** (rights, `12-lineage-verification-2026-10-01.md:240`): "Not closed here: captions whose screens also use another menu's form (Company, Data Refresh, Data Import, Order Report, ..." and the text at line 2670
"Order Report → Sales Order". No other `G` row names Order Report; `N234` (line 3698) records that Order Report is to reuse the engine.

1. **No Order Report screen or route** (missing feature). Desktop: seven buttons on `PanelOrder` (`RP_ALL.cs:5219 {{((Control)PanelOrder).Controls.Add((Control)(object)btnbillwiseordadj);}}`). Web: absent; `types.ts:17` `RpAllBranch = 'sales'`, no route in `rpAllReport.ts`. Fix: add an `order` adapter (7 modes, selectors, bound SQL) and a page.
2. **Mode 1, Order Report list** (missing). Desktop: `RP_ALL.cs:8418 {{DC_Main.RptName = "OrdDetlRpt";}}`, per-line columns and totals of pieces and net weight. Web: absent. Fix: read SL_ORD_DETL joined to SL_ORD_DATA/ITEM_MAST/AC_MAST/BOOK_DATA, no status filter, no year filter.
3. **Mode 2, Order Advance** (missing). Desktop: `RP_ALL.cs:8484 {{DC_Main.RptName = "OrdAdvRpt";}}`. Web: absent. Fix: one row per order header with tender columns.
4. **Mode 3, Order Adjust** (missing). Desktop: `RP_ALL.cs:8550 {{DC_Main.RptName = "OrdAdvAdj";}}` with signed `ORD_AMT` and group subtotals. Web: absent. Fix: join SL_ORD_ADJ; sum with `ORD_SIGN` as `+` positive, otherwise negative; group per order.
5. **Mode 4, Order Wise Bill** (missing). Desktop: `RP_ALL.cs:9776 {{DC_Main.RptName = "OrdAdjBillWise";}}`. Web: absent.
6. **Mode 5, Making Panding** (missing, and wrong if ported literally). Desktop writes `DESIGN_ISU` (`RP_ALL.cs:10933 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`). Web: absent. Fix: derive "not issued" in the query: lines of orders that are not in the fully adjusted set; never update; record the decision about `DESIGN_ISU` under Open questions.
7. **Mode 6, Making Summ** (missing). Desktop: `RP_ALL.cs:11899 {{DC_Main.RptName = "OrdDesignSumm";}}` plus the Yes/No prompt `RP_ALL.cs:11889 {{Only Design Summery Report..}}`. Web: absent. Fix: same as 6 with a boolean `onlySummary` and the prompt text kept.
8. **Mode 7, Bill Wise Adjust** (missing). Desktop: `RP_ALL.cs:12646 {{DC_Main.RptName = "BillWiseOrderAdjust";}}`, base table `SL_DATA`. Web: absent. Fix: base on SL_DATA with the SL_ORD_ADJ join; Cust Name filters `SL_DATA.AC_NAME`.
9. **Selector set and defaults** (missing). Desktop defaults: From `01/01/2010`, To system date (`RP_ALL.cs:7177 {{mFromDt.Text = "01/01/2010";}}`, `RP_ALL.cs:7203 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}`), location locked unless `00` (`RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}`). Web: `filters.ts` has the Sales selectors only, with Sales defaults. Fix: reuse `filters.ts`, add `custName`; Employee, Pr Code, Gr Code, Item Type must be ignored for this branch.
10. **Rights** (wrong result when ported by caption). Desktop reads USER_SET by the caption "Order Report" (`MDI_FORM.cs:7034 {{DC_Main.MsUserRightForm = MsSideBtn;}}`). Web: `formCatalog.ts` has no alias for it (G225 not closed). Fix: add the alias to the Order Report route's own rights check, and decide whether it also needs the Sales Order form (Open questions).
11. **Print rights** (inconsistent). Desktop never checks FRM_PRINT in RP_ALL (`RP_ALL.cs:6777 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable}}`). Web: Sales Report follows the caption's rights. Fix: same as Sales Report; record the choice.
12. **Titles and prompt texts** (wrong text risk). Desktop titles are fixed (`RP_ALL.cs:8416 {{DC_Main.MsRptTitelStr = "'Order Report From " + Strings.Format((object}}`, `RP_ALL.cs:8482 {{DC_Main.MsRptTitelStr = "'Order Advance Report From " + Strings.Format}}`, `RP_ALL.cs:8548 {{DC_Main.MsRptTitelStr = "'Order Adjust Report From " + Strings.Format(}}`, `RP_ALL.cs:10976 {{DC_Main.MsRptTitelStr = "'Order Design Issue Panding Report From " + S}}`). Web: no title table for this branch; `salesLayouts.ts:289` has `titlePrefix: 'Sales With Order Report'` only. Fix: copy the titles exactly, "Panding" and "Summery" included.
13. **Cust Name help** (missing key). Desktop Enter on Cust Name offers the distinct names of SL_ORD_DATA (`RP_ALL.cs:9693 {{DC_Main.RsQry = "SELECT A.AC_NAME As CustomerNameL,A.AC_CODE AS AcCode}}`). Web: absent. Fix: a bound lookup of the same list and the Enter flow of the Keyboard section.
14. **Misleading existing names** (wrong surface). `orderReportLayout.ts` and `orderReport.test.ts` implement the voucher print; the browser/menu catalog row points at `/txn/sales-order`. Fix: name the new module `orderReportRp` or similar to avoid a mix-up; update the catalog row when the page exists.
15. **Exports** (missing). Sales has CSV/XLSX through `exportRows.ts`. Fix: the same from one shared result for each mode.

## Open questions

1. Is the Order Report menu shown in the Lite edition? No `MsSoftType` check is in the dispatch (`MDI_FORM.cs:8931-8940 {{case "Order Report":}}`); the menu visibility is built elsewhere in `MDI_FORM` (not read here: lines outside the dispatch) and in the catalog row `can` field `-----L`, whose meaning is not documented in the files read.
2. Is the "fully adjusted" rule (`HAVING SUM(...) = 0`, `RP_ALL.cs:10927 {{DC_Main.RsQry = "Select A.CO_YEAR,A.CO_BOOK,A.VCH_NO FROM SL_ORD_DATA }}`) what the owner means by "design issued"? The source has no other writer of `DESIGN_ISU` in `RP_ALL.cs` (index shows only the two UPDATE statements at `RP_ALL.cs:10933 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}` and `:11843`); `TR_SALE_ORD.cs` may set it too and was not read for this study.
3. Which orders are "cancelled"? This form has no cancel column. The Order Cancel flow (G245) is outside this study.
4. `DC_Main.MsDataType` values and meaning for A, B, C (`DC_Main.cs:1493 {{if (Operators.CompareString(MsDataType, "A", false) == 0)}}`) were read only where this form uses them; the web's data-type handling for the other RP_ALL branches should be reused as is.
5. Crystal template group/sort order: the spec files list fields and totals but this study did not read the `<Group>` and `<Sort>` definitions of each `.rpt` (`unified/reports/*.rpt`, `extraction_output/rpt_xml/*.xml`); the test-case writer must read them for row order.
6. Do the Sales Order and Order Report rights share a row? G225 leaves it open; owner decision needed.
