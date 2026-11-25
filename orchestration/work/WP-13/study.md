## Scope

This study covers Report → Approval Rpt only. The checkout has 12,663 physical lines in RP_ALL.cs (the packet also describes it as 12,662). Dispatch constructs RP_ALL, sets the MDI parent, increments the open-form counter, adds that counter to the window caption, shows it and focuses it: MDI_FORM.cs:8921 {{case "Approval Rpt":}}; MDI_FORM.cs:8923 {{RP_ALL rP_ALL5 = new RP_ALL();}}; MDI_FORM.cs:8924 {{((Form)rP_ALL5).MdiParent = (Form)(object)this;}}; MDI_FORM.cs:8925 {{DC_Main.TotOpenForm++;}}; MDI_FORM.cs:8926 {{((Form)rP_ALL5).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);}}; MDI_FORM.cs:8927 {{((Control)rP_ALL5).Show();}}; MDI_FORM.cs:8928 {{((Control)rP_ALL5).Focus();}}.

The mode actually comes from MsUserRightForm, not parsing the numbered window title: RP_ALL.cs:6658 {{CurRpt = DC_Main.MsUserRightForm;}}; RP_ALL.cs:6659 {{lblBook.Text = CurRpt;}}. Approval makes PanelApr visible and positions it over PanelSale: RP_ALL.cs:6707 {{else if (Operators.CompareString(CurRpt, "Approval Rpt", false) == 0)}}; RP_ALL.cs:6709 {{((Control)PanelApr).Visible = true;}}; RP_ALL.cs:6710 {{((Control)PanelApr).Top = ((Control)PanelSale).Top;}}; RP_ALL.cs:6711 {{((Control)PanelApr).Left = ((Control)PanelSale).Left;}}.

The complete caption-specific mode set is Approval Isu, Approval InOut and Approval Panding: RP_ALL.cs:5132 {{((Control)PanelApr).Controls.Add((Control)(object)btnAprRpt);}}; RP_ALL.cs:5133 {{((Control)PanelApr).Controls.Add((Control)(object)btnAprInOut);}}; RP_ALL.cs:5134 {{((Control)PanelApr).Controls.Add((Control)(object)BtnAprPanding);}}. A full-file search found no MsSoftType check in RP_ALL.cs, so this panel does not reduce its three buttons for Lite. That is a form-source finding, not certification of licence-dependent menu availability. Sales, Purchase, Order and other panels are outside this packet; for example Sales has its own branch: RP_ALL.cs:6676 {{if (Operators.CompareString(CurRpt, "Sales Report", false) == 0)}}.

MISSING: the packet path `web/apps/api/src/modules/reports/salesReport.ts`. Its current replacement is `web/apps/api/src/modules/reports/rpAll/index.ts`. MISSING: `.orch/index/DC_Main.md`, `.orch/index/Module_Save.md`, `.orch/index/TR_APR_ISU.md`, `.orch/index/TR_SALE.md`; bounded shared-source reads used searched method anchors or the already identified custody-update lines instead. No database, capture, environment file or binary report was opened.

Template evidence below is from the checked-in extracted XML, not a Windows render. A C# citation proves which template is selected; the accompanying XML path and literal attribute/formula prove the template-specific detail. SQL generated internally by Crystal is not present, so this study reports selection formulas, table links, groups and sorts rather than inventing SQL.

## Screen

The common selectors below are top-level controls. Their default Text is unset/empty unless a load assignment below overrides it; the designer does not set ReadOnly on their name boxes. The form enables key preview: RP_ALL.cs:6609 {{((Form)this).KeyPreview = true;}}. Tab indices are local to the parent; high-index name boxes are not silently excluded from tabbing. The control declarations use TextBox, MaskedTextBox and ComboBox: RP_ALL.cs:4158 {{tBookCode = new TextBox();}}; RP_ALL.cs:4205 {{mToDt = new MaskedTextBox();}}; RP_ALL.cs:4165 {{cboCity = new ComboBox();}}.

| Caption / controls | Type; tab index | Default and evidence |
|---|---|---|
| From / To Date — mFromDt, mToDt | MaskedTextBox; 0, 1 | RP_ALL.cs:4808 {{Label2.Text = "From / To Date";}}; RP_ALL.cs:5622 {{((Control)mFromDt).TabIndex = 0;}}; RP_ALL.cs:5614 {{((Control)mToDt).TabIndex = 1;}}; RP_ALL.cs:5619 {{mFromDt.Mask = "00/00/0000";}} |
| lc Code — tLcCode, tLcName | TextBox; 2, 1177 | RP_ALL.cs:4934 {{Label6.Text = "lc Code";}}; RP_ALL.cs:4918 {{((Control)tLcCode).TabIndex = 2;}}; RP_ALL.cs:4925 {{((Control)tLcName).TabIndex = 1177;}} |
| Book — tBookCode, tBookName | TextBox; 3, 1161 | RP_ALL.cs:4798 {{Label1.Text = "Book";}}; RP_ALL.cs:4782 {{((Control)tBookCode).TabIndex = 3;}}; RP_ALL.cs:4789 {{((Control)tBookName).TabIndex = 1161;}} |
| Pr Code — tItCode, tItName | TextBox; 4, 1172 | RP_ALL.cs:4894 {{Label4.Text = "Pr Code";}}; RP_ALL.cs:4878 {{((Control)tItCode).TabIndex = 4;}}; RP_ALL.cs:4885 {{((Control)tItName).TabIndex = 1172;}} |
| Gr Code — tGrCode, tGrName | TextBox; 5, 1184 | RP_ALL.cs:5646 {{Label7.Text = "Gr Code";}}; RP_ALL.cs:5630 {{((Control)tGrCode).TabIndex = 5;}}; RP_ALL.cs:5637 {{((Control)tGrName).TabIndex = 1184;}} |
| Party Code — tAcCode, tAcName | TextBox; 6, 1164 | RP_ALL.cs:4832 {{Label3.Text = "Party Code";}}; RP_ALL.cs:4816 {{((Control)tAcCode).TabIndex = 6;}}; RP_ALL.cs:4823 {{((Control)tAcName).TabIndex = 1164;}} |
| Cust Name — tCustName | TextBox; 7 | RP_ALL.cs:5804 {{Label8.Text = "Cust Name";}}; RP_ALL.cs:5795 {{((Control)tCustName).TabIndex = 7;}} |
| City — cboCity | ComboBox; 8 | RP_ALL.cs:4851 {{lblCity.Text = "City";}}; RP_ALL.cs:4842 {{((Control)cboCity).TabIndex = 8;}} |
| Area — cboArea | ComboBox; 9 | RP_ALL.cs:4870 {{Label17.Text = "Area";}}; RP_ALL.cs:4861 {{((Control)cboArea).TabIndex = 9;}} |
| Item Type — cboItemTyp | ComboBox; 10 | RP_ALL.cs:4910 {{Label5.Text = "Item Type";}}; RP_ALL.cs:4902 {{((Control)cboItemTyp).TabIndex = 10;}} |

Approval From defaults to 01/01/2010; To uses MsSysDate; the remembered active control is From: RP_ALL.cs:7183 {{else if (Operators.CompareString(CurRpt, "Approval Rpt", false) == 0)}}; RP_ALL.cs:7185 {{mFromDt.Text = "01/01/2010";}}; RP_ALL.cs:7203 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}; RP_ALL.cs:7204 {{CurActCtrl = (Control)(object)mFromDt;}}. Location code/name take the session location; both become disabled outside location 00: RP_ALL.cs:6660 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}}; RP_ALL.cs:6662 {{tLcCode.Text = DC_Main.MLc_code;}}; RP_ALL.cs:6663 {{tLcName.Text = DC_Main.MLc_Name;}}; RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}; RP_ALL.cs:6665 {{((Control)tLcName).Enabled = false;}}. At 00 they remain editable: RP_ALL.cs:6669 {{tLcCode.Text = DC_Main.MLc_code;}}; RP_ALL.cs:6670 {{tLcName.Text = DC_Main.MLc_Name;}}.

City and area lists are distinct company-master values ordered by their own column, not voucher snapshots: RP_ALL.cs:7087 {{SELECT AC_CITY FROM AC_MAST WHERE CO_CODE}}; RP_ALL.cs:7121 {{GROUP BY AC_AREA ORDER BY AC_AREA}}. Item Type choices are blank, Gold, Silver, Diamond, Real Stone, Emitation, Other and Platinum; blank is selected: RP_ALL.cs:7165 {{cboItemTyp.Items.Add((object)"");}}; RP_ALL.cs:7166 {{cboItemTyp.Items.Add((object)"Gold");}}; RP_ALL.cs:7167 {{cboItemTyp.Items.Add((object)"Silver");}}; RP_ALL.cs:7168 {{cboItemTyp.Items.Add((object)"Diamond");}}; RP_ALL.cs:7169 {{cboItemTyp.Items.Add((object)"Real Stone");}}; RP_ALL.cs:7170 {{cboItemTyp.Items.Add((object)"Emitation");}}; RP_ALL.cs:7171 {{cboItemTyp.Items.Add((object)"Other");}}; RP_ALL.cs:7172 {{cboItemTyp.Items.Add((object)"Platinum");}}; RP_ALL.cs:7173 {{cboItemTyp.SelectedIndex = 0;}}.

| Action / container | Tab index and caption evidence |
|---|---|
| btnAprRpt | RP_ALL.cs:5164 {{((Control)btnAprRpt).TabIndex = 0;}}; RP_ALL.cs:5165 {{btnAprRpt.Text = "&Approval Isu";}} |
| btnAprInOut | RP_ALL.cs:5190 {{((Control)btnAprInOut).TabIndex = 1;}}; RP_ALL.cs:5191 {{btnAprInOut.Text = "&Approval InOut";}} |
| BtnAprPanding | RP_ALL.cs:5216 {{((Control)BtnAprPanding).TabIndex = 2;}}; RP_ALL.cs:5217 {{BtnAprPanding.Text = "&Approval Panding";}} |
| BtnSave | RP_ALL.cs:4329 {{((Control)BtnSave).TabIndex = 22;}}; RP_ALL.cs:4330 {{BtnSave.Text = "&Save";}} |
| BtnCancel | RP_ALL.cs:4316 {{((Control)BtnCancel).TabIndex = 23;}}; RP_ALL.cs:4317 {{BtnCancel.Text = "&Cancel";}} |
| BtnDelete | RP_ALL.cs:4302 {{((Control)BtnDelete).TabIndex = 24;}}; RP_ALL.cs:4303 {{BtnDelete.Text = "&Delete";}} |
| BtnExit | RP_ALL.cs:4289 {{((Control)BtnExit).TabIndex = 25;}}; RP_ALL.cs:4290 {{BtnExit.Text = "E&xit";}} |
| BtnPrint | RP_ALL.cs:4342 {{((Control)BtnPrint).TabIndex = 26;}}; RP_ALL.cs:4343 {{BtnPrint.Text = "&Print";}} |

The approval actions are QButton controls: RP_ALL.cs:1280 {{internal virtual QButton btnAprRpt}}; RP_ALL.cs:1306 {{internal virtual QButton btnAprInOut}}; RP_ALL.cs:1332 {{internal virtual QButton BtnAprPanding}}. Bottom actions are SimpleButton controls: RP_ALL.cs:512 {{internal virtual SimpleButton BtnDelete}}; RP_ALL.cs:556 {{internal virtual SimpleButton BtnSave}}. PanelApr has tab index 1179 and the bottom action panel has index 12. All five bottom buttons are added to that panel; there is no approval-specific hiding of them: RP_ALL.cs:5138 {{((Control)PanelApr).TabIndex = 1179;}}; RP_ALL.cs:4278 {{((Control)PnlBotam).TabIndex = 12;}}; RP_ALL.cs:4266 {{((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);}}; RP_ALL.cs:4267 {{((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);}}; RP_ALL.cs:4268 {{((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);}}; RP_ALL.cs:4269 {{((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);}}; RP_ALL.cs:4270 {{((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);}}. lblBook displays the caption: RP_ALL.cs:6659 {{lblBook.Text = CurRpt;}}.

Employee/Employ, State, Select Book and its grid panel stay hidden for Approval; the Sales branch alone shown here enables employee and multi-book selection. RP_ALL.cs:6400 {{((Control)cboEmploy).Visible = false;}}; RP_ALL.cs:6411 {{((Control)lblemp).Visible = false;}}; RP_ALL.cs:6549 {{((Control)cboState).Visible = false;}}; RP_ALL.cs:6560 {{((Control)Label9).Visible = false;}}; RP_ALL.cs:6539 {{((Control)chkBookSelect).Visible = false;}}; RP_ALL.cs:6421 {{((Control)PnlIt).Visible = false;}}; RP_ALL.cs:6679 {{((Control)lblemp).Visible = true;}}; RP_ALL.cs:6680 {{((Control)cboEmploy).Visible = true;}}; RP_ALL.cs:6681 {{((Control)chkBookSelect).Visible = true;}}. Therefore no approval employee, state, multi-book or user grouping selector is established. Cust Name remains visible but is not an approval filter: non-Order Enter clears it and moves to City: RP_ALL.cs:9717 {{tCustName.Text = "";}}; RP_ALL.cs:9718 {{((Control)cboCity).Focus();}}.

## Keyboard

Esc closes the form; KeyPress uppercases input and consumes character codes 0 and 39 (apostrophe): RP_ALL.cs:7261 {{if ((int)e.KeyCode == 27)}}; RP_ALL.cs:7263 {{((Form)this).Close();}}; RP_ALL.cs:7248 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}; RP_ALL.cs:7251 {{if (num == 0 || num == 39)}}; RP_ALL.cs:7253 {{e.Handled = true;}}. No F-key or Ctrl-combination handler is present in this form; the bounded handlers below gate on Enter. The ampersands in the action captions supply Windows mnemonics (all three approval buttons share A, so do not invent unique shortcuts): RP_ALL.cs:5165 {{btnAprRpt.Text = "&Approval Isu";}}; RP_ALL.cs:5191 {{btnAprInOut.Text = "&Approval InOut";}}; RP_ALL.cs:5217 {{BtnAprPanding.Text = "&Approval Panding";}}.

Book Enter: blank or valid advances Tab; unknown nonblank opens MS_HELP, selected code/name return and focus stays on Book. The help lists company/session-location books, without an APR-family restriction: RP_ALL.cs:7293 {{if ((int)e.KeyCode != 13)}}; RP_ALL.cs:7303 {{ORDER BY A.BOOK_NAME}}; RP_ALL.cs:7309 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}; RP_ALL.cs:7314 {{tBookCode.Text = DC_Main.ColValue[1];}}; RP_ALL.cs:7315 {{tBookName.Text = DC_Main.ColValue[0];}}; RP_ALL.cs:7317 {{((Control)tBookCode).Focus();}}; RP_ALL.cs:7323 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7328 {{SendKeys.Send("{tab}");}}.

Party Enter validates AC_MAST by company/code. Unknown nonblank opens account help; all-branch setting lists all company accounts, a non-00 branch otherwise unions codes below 100 with local codes at least 200, and 00 otherwise uses local accounts. Selection restores focus to Party; valid and blank advance Tab: RP_ALL.cs:7382 {{Select * From AC_MAST WHERE CO_CODE}}; RP_ALL.cs:7386 {{if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)}}; RP_ALL.cs:7392 {{CAST(C.AC_CODE AS INT) < 100}}; RP_ALL.cs:7392 {{CAST(A.AC_CODE AS INT) >=200}}; RP_ALL.cs:7396 {{AND A.LC_CODE = '}}; RP_ALL.cs:7408 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}; RP_ALL.cs:7416 {{((Control)tAcCode).Focus();}}; RP_ALL.cs:7422 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7427 {{SendKeys.Send("{tab}");}}.

Product Enter uses PRODUCT_MAST.PR_CODE (not IT_CODE), opens help for unknown nonblank, restores Product focus after selection, tabs on valid code, and jumps directly to City when blank: RP_ALL.cs:7477 {{AND PR_CODE}}; RP_ALL.cs:7487 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}; RP_ALL.cs:7492 {{tItCode.Text = DC_Main.ColValue[1];}}; RP_ALL.cs:7493 {{tItName.Text = DC_Main.ColValue[0];}}; RP_ALL.cs:7495 {{((Control)tItCode).Focus();}}; RP_ALL.cs:7501 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7506 {{((Control)cboCity).Focus();}}. Group Enter uses GROUP_MAST, including help on an unmatched blank; selection fills group/name and SelectAll stays on the code; valid advances Tab: RP_ALL.cs:9265 {{Select * From GROUP_MAST}}; RP_ALL.cs:9277 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}; RP_ALL.cs:9282 {{tGrCode.Text = DC_Main.ColValue[1];}}; RP_ALL.cs:9283 {{tGrName.Text = DC_Main.ColValue[0];}}; RP_ALL.cs:9285 {{((TextBoxBase)tGrCode).SelectAll();}}; RP_ALL.cs:9291 {{SendKeys.Send("{tab}");}}.

Location Enter uses LOCT_MAST; unknown nonblank opens help and fills the selection, valid or blank advances Tab: RP_ALL.cs:7691 {{Select * From LOCT_MAST}}; RP_ALL.cs:7703 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}; RP_ALL.cs:7704 {{if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)}}; RP_ALL.cs:7706 {{tLcCode.Text = DC_Main.ColValue[0];}}; RP_ALL.cs:7707 {{tLcName.Text = DC_Main.ColValue[1];}}; RP_ALL.cs:7713 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7718 {{SendKeys.Send("{tab}");}}. From/To Enter call SetDate and Tab only when RongDate is false: RP_ALL.cs:7517 {{DC_Main.SetDate(ref MsDate);}}; RP_ALL.cs:7519 {{if (!DC_Main.RongDate)}}; RP_ALL.cs:7521 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7533 {{DC_Main.SetDate(ref MsDate);}}; RP_ALL.cs:7535 {{if (!DC_Main.RongDate)}}; RP_ALL.cs:7537 {{SendKeys.Send("{tab}");}}. City, Area and Item Type Enter send Tab: RP_ALL.cs:7546 {{if ((int)e.KeyCode == 13)}}; RP_ALL.cs:7548 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7556 {{if ((int)e.KeyCode == 13)}}; RP_ALL.cs:7558 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7566 {{if ((int)e.KeyCode == 13)}}; RP_ALL.cs:7568 {{SendKeys.Send("{tab}");}}.

Both date fields select all text when focused: RP_ALL.cs:9607 {{((TextBoxBase)mFromDt).SelectAll();}}; RP_ALL.cs:9612 {{((TextBoxBase)mToDt).SelectAll();}}. Save and Delete are visible but their property setters attach no click handlers, so their captions do not establish a report write operation: RP_ALL.cs:521 {{_BtnDelete = value;}}; RP_ALL.cs:565 {{_BtnSave = value;}}.

## Rules

Date errors use exactly "Date Not Valid..." and "Month Not Valid..."; they set RongDate, replace the mask with __/__/____ and SelectAll on the same date field. The form therefore does not advance after the message: DC_Main.cs:1643 {{RongDate = true;}}; DC_Main.cs:1644 {{Interaction.MsgBox((object)"Date Not Valid...", (MsgBoxStyle)0, (object)null);}}; DC_Main.cs:1645 {{MsDate.Text = "__/__/____";}}; DC_Main.cs:1646 {{((TextBoxBase)MsDate).SelectAll();}}; DC_Main.cs:1664 {{Interaction.MsgBox((object)"Month Not Valid...", (MsgBoxStyle)0, (object)null);}}; DC_Main.cs:1665 {{MsDate.Text = "__/__/____";}}; DC_Main.cs:1666 {{((TextBoxBase)MsDate).SelectAll();}}; RP_ALL.cs:7519 {{if (!DC_Main.RongDate)}}. The helper also checks day >31 and a second month substring: DC_Main.cs:1669 {{if (Conversion.Val(Strings.Mid(MsDate.Text, 1, 2)) > 31.0)}}; DC_Main.cs:1676 {{else if (Conversion.Val(Strings.Mid(MsDate.Text, 3, 2)) > 12.0)}}.

SetDate completes missing date parts using today and the financial-year convention; MsAlterYear uses first year plus one before April, UAE uses the first year, otherwise January–March uses the right-hand year. A single entered digit sets RongDate and returns without a message: DC_Main.cs:1577 {{if (Operators.CompareString(MsAlterYear, "Y", false) == 0)}}; DC_Main.cs:1581 {{FnYear = Conversions.ToString(Interaction.IIf(Conversion.Val(Strings.Mid(MsDate.Text, 4, 2)) < 4.0, (object)(Conversions.ToDouble(Strings.Left(MCo_year, 4)) + 1.0), (object)Strings.Left(MCo_year, 4)));}}; DC_Main.cs:1588 {{else if (Operators.CompareString(MCo_SName, "UAE", false) == 0)}}; DC_Main.cs:1590 {{FnYear = Strings.Left(MCo_year, 4);}}; DC_Main.cs:1594 {{FnYear = Conversions.ToString(Interaction.IIf(Conversion.Val(Strings.Mid(MsDate.Text, 4, 2)) < 4.0, (object)Strings.Right(MCo_year, 4), (object)Strings.Left(MCo_year, 4)));}}; DC_Main.cs:1600 {{if (i == 2)}}; DC_Main.cs:1602 {{RongDate = true;}}; DC_Main.cs:1608 {{MsDate.Text = DateAndTime.Today.Day.ToString("00") + "/" + DateAndTime.Today.Month.ToString("00") + "/" + FnYear;}}; DC_Main.cs:1614 {{MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(text, 4, 2) + "/" + FnYear;}}; DC_Main.cs:1626 {{MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(MsDate.Text, 4, 2) + "/" + FnYear;}}.

The report buttons do not re-run SetDate. No approval click handler checks From <= To, fiscal-year bounds, empty results, required party/product or existence of a typed filter. It directly converts dates and sets inclusive endpoints: RP_ALL.cs:8152 {{AND {APR_DETL.VCH_DATE} >= #}}; RP_ALL.cs:8227 {{AND {APR_DETL.VCH_DATE} <= #}}; RP_ALL.cs:8302 {{AND {APR_DETL.ISU_REC} = 'N'}}. Reversed valid dates therefore create an unsatisfiable selection (inference from the conjunction); malformed dates bypassing Enter may throw during conversion. Do not invent a desktop validation message for either case.

## Calculations

Calculation authority is the selected template, not arithmetic in the three click handlers: RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}; RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}; RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}. The following template formulas are not C# formulas; the explicit XML references are their authority.

**AprPartyWise** is selected by RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}.

Issue prints stored ITM_PCS, ITM_GWT, ITM_NWT, ITM_AMT, LBR_AMT, OTH_AMT and NET_AMT. It sums the first six at voucher Group and party AC_CODE; NET_AMT has a detail field but no summary definition, and the report-footer band is empty. Evidence: `extraction_output/rpt_xml/AprPartyWise.xml:763` (`DataSource="{APR_DETL.NET_AMT}"`); `extraction_output/rpt_xml/AprPartyWise.xml:289` (`FormulaName="Sum ({APR_DETL.ITM_PCS}, {@Group})"`); `extraction_output/rpt_xml/AprPartyWise.xml:300` (`FormulaName="Sum ({APR_DETL.OTH_AMT}, {APR_DETL.AC_CODE})"`).

**AprInOut** is selected by RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}.

- TagPcs = `if {BOOK_DATA.MAIN_BOOK} = 'APR ISU' then {APR_DETL.ITM_PCS}`. `extraction_output/rpt_xml/AprInOut.xml:322` (`FormulaName="{@TagPcs}"`).

- TagGwt = `if {BOOK_DATA.MAIN_BOOK} = 'APR ISU' then {APR_DETL.ITM_GWT}`. `extraction_output/rpt_xml/AprInOut.xml:311` (`FormulaName="{@TagGwt}"`).

- TagNwt = `if {BOOK_DATA.MAIN_BOOK} = 'APR ISU' then {APR_DETL.ITM_NWT}`. `extraction_output/rpt_xml/AprInOut.xml:315` (`FormulaName="{@TagNwt}"`).

- TagOth = `if {BOOK_DATA.MAIN_BOOK} = 'APR ISU' then {APR_DETL.OTH_AMT}`. `extraction_output/rpt_xml/AprInOut.xml:318` (`FormulaName="{@TagOth}"`).

- OutPcs = `if {BOOK_DATA.MAIN_BOOK} = 'APR ISU' then {APR_DETL.ITM_PCS}`. `extraction_output/rpt_xml/AprInOut.xml:300` (`FormulaName="{@OutPcs}"`).

- InPcs = `if {APR_DETL.ISU_REC} = 'Y' then {APR_DETL.ITM_PCS}`. `extraction_output/rpt_xml/AprInOut.xml:293` (`FormulaName="{@InPcs}"`).

- PanPcs = `{@OutPcs}-{@InPcs}`. `extraction_output/rpt_xml/AprInOut.xml:304` (`FormulaName="{@PanPcs}"`).

Sum TagPcs, TagGwt, TagNwt, TagOth, OutPcs, InPcs, PanPcs per product PR_CODE (header), tag Group (footer), party AC_CODE (footer), and report (Grand Total). Evidence: `extraction_output/rpt_xml/AprInOut.xml:342` (`FormulaName="Sum ({@TagPcs}, {ITEM_MAST.PR_CODE})"`); `extraction_output/rpt_xml/AprInOut.xml:355` (`FormulaName="Sum ({@PanPcs}, {@Group})"`); `extraction_output/rpt_xml/AprInOut.xml:362` (`FormulaName="Sum ({@PanPcs}, {APR_DETL.AC_CODE})"`); `extraction_output/rpt_xml/AprInOut.xml:369` (`FormulaName="Sum ({@PanPcs})"`).

**AprPan** is selected by RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}.

- TagPcs = `if {BOOK_DATA.MAIN_BOOK} = 'APR ISU' then {APR_DETL.ITM_PCS} else -{APR_DETL.ITM_PCS}`. `extraction_output/rpt_xml/AprPan.xml:364` (`FormulaName="{@TagPcs}"`).

- TagGwt = `if {BOOK_DATA.MAIN_BOOK} = 'APR ISU' then {APR_DETL.ITM_GWT} else -{APR_DETL.ITM_GWT}`. `extraction_output/rpt_xml/AprPan.xml:347` (`FormulaName="{@TagGwt}"`).

- TagNwt = `if {BOOK_DATA.MAIN_BOOK} = 'APR ISU' then {APR_DETL.ITM_NWT} else -{APR_DETL.ITM_NWT}`. `extraction_output/rpt_xml/AprPan.xml:352` (`FormulaName="{@TagNwt}"`).

- TagOth = `if {BOOK_DATA.MAIN_BOOK} = 'APR ISU' then {APR_DETL.OTH_AMT} else -{APR_DETL.OTH_AMT}`. `extraction_output/rpt_xml/AprPan.xml:358` (`FormulaName="{@TagOth}"`).

- OutPcs = `if {BOOK_DATA.MAIN_BOOK} = 'APR ISU' then {APR_DETL.ITM_PCS}`. `extraction_output/rpt_xml/AprPan.xml:336` (`FormulaName="{@OutPcs}"`).

- InPcs = `if {BOOK_DATA.MAIN_BOOK} = 'APR RTN' then {APR_DETL.ITM_PCS}`. `extraction_output/rpt_xml/AprPan.xml:332` (`FormulaName="{@InPcs}"`).

- PanPcs = `{APR_DETL.ITM_PCS}`. `extraction_output/rpt_xml/AprPan.xml:339` (`FormulaName="{@PanPcs}"`).

Sum TagPcs, TagGwt, TagNwt, TagOth, PanPcs per product PR_CODE (header), tag Group (footer), party AC_CODE (footer), and report (Grand Total). Evidence: `extraction_output/rpt_xml/AprPan.xml:393` (`FormulaName="Sum ({@TagPcs}, {ITEM_MAST.PR_CODE})"`); `extraction_output/rpt_xml/AprPan.xml:402` (`FormulaName="Sum ({@PanPcs}, {@Group})"`); `extraction_output/rpt_xml/AprPan.xml:407` (`FormulaName="Sum ({@PanPcs}, {APR_DETL.AC_CODE})"`); `extraction_output/rpt_xml/AprPan.xml:412` (`FormulaName="Sum ({@PanPcs})"`).

Apply record selection before these formulas. All modes require APR ISU, so AprPan negative non-issue branches and its APR RTN InPcs formula cannot affect this button result: RP_ALL.cs:8303 {{CurFormula += " And {BOOK_DATA.MAIN_BOOK} = 'APR ISU'";}}; `extraction_output/rpt_xml/AprPan.xml:332` (`FormulaName="{@InPcs}"`). InOut is issue-line status reporting: Out is the original pieces, In is those pieces when ISU_REC is Y, and Pending is Out−In; it does not select return vouchers or separate billed pieces. RP_ALL.cs:8228 {{CurFormula += " And {BOOK_DATA.MAIN_BOOK} = 'APR ISU'";}}; `extraction_output/rpt_xml/AprInOut.xml:293` (`FormulaName="{@InPcs}"`); `extraction_output/rpt_xml/AprInOut.xml:304` (`{@OutPcs}-{@InPcs}`).

Return and billed resolution both have source updates to Y: TR_APR_ISU.cs:6414 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}}; TR_SALE.cs:16112 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}}. The inspected Sales path is additionally restricted to approval book 018 and joins SR_NO, whereas Return joins OLD_SRNO: TR_SALE.cs:16112 {{AND APR_DETL.CO_BOOK = '018'}}; TR_SALE.cs:16112 {{APR_DETL.SR_NO = B.ISU_SRNO}}; TR_APR_ISU.cs:6414 {{APR_DETL.OLD_SRNO = B.ISU_SRNO}}. These are dependency caveats, not proposed changes to the writers.

There is no Round call in these report formulas or click handlers. MISSING: numeric display decimal/rounding metadata in the extracted XML (only object/section formatting is exposed). Preserve stored precision for calculations; do not claim that the current web toFixed(3/2) is desktop-authoritative. The packet’s pieces/gross/net/fine custody equation is a desired journey reconciliation, not four formulas found in these templates: InOut only has Out/In/Pending pieces and original gross/net; fine is absent from all three layouts. Evidence: RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}; `extraction_output/rpt_xml/AprInOut.xml:304` (`FormulaName="{@PanPcs}"`). Unused PurcTax/TotPurcTax running totals refer to an empty PurcTax formula; their evaluation group is not extracted: `extraction_output/rpt_xml/AprInOut.xml:337` (`FormulaName="{#PurcTax}"`).

## Lifecycle and write set

This branch is a read/preview workflow. Create, edit, delete and voucher reopening have no report-specific write set; the complete approval handlers finish with preview or Crystal Action rather than database statements: RP_ALL.cs:8141-8215 {{Module_Save.ShowReportPreview();}}; RP_ALL.cs:8216-8290 {{Cr.Action = -1;}}; RP_ALL.cs:8291-8365 {{Cr.Action = -1;}}. The bottom Print handler is empty; Cancel calls CLEAR_DATA, clearing top-level TextBoxes and resetting MaskedTextBoxes without resetting combos or reapplying the location/date defaults. Exit closes: RP_ALL.cs:7267-7270 {{private void BtnPrint_Click(object sender, EventArgs e)}}; RP_ALL.cs:7273 {{CLEAR_DATA();}}; RP_ALL.cs:7215 {{if (val is TextBox)}}; RP_ALL.cs:7217 {{val.Text = "";}}; RP_ALL.cs:7219 {{else if (val is MaskedTextBox)}}; RP_ALL.cs:7221 {{val.Text = DC_Main.MMask;}}; RP_ALL.cs:7230 {{((Form)this).Close();}}.

**Selection / WHERE equivalent, all modes.** The form supplies a Crystal record-selection string, not a SQL SELECT, GROUP BY or ORDER BY. Company and inclusive VCH_DATE endpoints always apply. Pending additionally requires exact N; Issue and InOut have no ISU_REC condition: RP_ALL.cs:8152 {{{APR_DETL.CO_CODE} = '}}; RP_ALL.cs:8227 {{AND {APR_DETL.VCH_DATE} >= #}}; RP_ALL.cs:8302 {{AND {APR_DETL.ISU_REC} = 'N'}}. No CO_YEAR condition is appended in these handlers; fiscal database identity is therefore distinct from the web year filter.

| Predicate | Issue evidence | InOut evidence | Pending evidence |
|---|---|---|---|
| Always MAIN_BOOK = APR ISU | RP_ALL.cs:8153 {{{BOOK_DATA.MAIN_BOOK} = 'APR ISU'}} | RP_ALL.cs:8228 {{{BOOK_DATA.MAIN_BOOK} = 'APR ISU'}} | RP_ALL.cs:8303 {{{BOOK_DATA.MAIN_BOOK} = 'APR ISU'}} |
| Location, if nonblank | RP_ALL.cs:8156 {{And {APR_DETL.LC_CODE}}} | RP_ALL.cs:8231 {{And {APR_DETL.LC_CODE}}} | RP_ALL.cs:8306 {{And {APR_DETL.LC_CODE}}} |
| Book, if nonblank | RP_ALL.cs:8160 {{And {APR_DETL.CO_BOOK}}} | RP_ALL.cs:8235 {{And {APR_DETL.CO_BOOK}}} | RP_ALL.cs:8310 {{And {APR_DETL.CO_BOOK}}} |
| Party, if nonblank | RP_ALL.cs:8164 {{And {APR_DETL.AC_CODE}}} | RP_ALL.cs:8239 {{And {APR_DETL.AC_CODE}}} | RP_ALL.cs:8314 {{And {APR_DETL.AC_CODE}}} |
| Product, if nonblank | RP_ALL.cs:8168 {{And {ITEM_MAST.PR_CODE}}} | RP_ALL.cs:8243 {{And {ITEM_MAST.PR_CODE}}} | RP_ALL.cs:8318 {{And {ITEM_MAST.PR_CODE}}} |
| City, if nonblank | RP_ALL.cs:8172 {{And {AC_MAST.AC_CITY}}} | RP_ALL.cs:8247 {{And {AC_MAST.AC_CITY}}} | RP_ALL.cs:8322 {{And {AC_MAST.AC_CITY}}} |
| Area, if nonblank | RP_ALL.cs:8176 {{And {AC_MAST.AC_AREA}}} | RP_ALL.cs:8251 {{And {AC_MAST.AC_AREA}}} | RP_ALL.cs:8326 {{And {AC_MAST.AC_AREA}}} |
| Item type, first character if nonblank | RP_ALL.cs:8180 {{Strings.Mid(cboItemTyp.Text, 1, 1)}} | RP_ALL.cs:8255 {{Strings.Mid(cboItemTyp.Text, 1, 1)}} | RP_ALL.cs:8330 {{Strings.Mid(cboItemTyp.Text, 1, 1)}} |
| Group, if nonblank | RP_ALL.cs:8184 {{And {ITEM_MAST.GR_CODE}}} | RP_ALL.cs:8259 {{And {ITEM_MAST.GR_CODE}}} | RP_ALL.cs:8334 {{And {ITEM_MAST.GR_CODE}}} |
| Data type A only when MsDataType=A | RP_ALL.cs:8188 {{{BOOK_DATA.DATA_TYPE}}} | RP_ALL.cs:8263 {{{BOOK_DATA.DATA_TYPE}}} | RP_ALL.cs:8338 {{{BOOK_DATA.DATA_TYPE}}} |
| Data type B only when MsDataType=B | RP_ALL.cs:8192 {{{BOOK_DATA.DATA_TYPE}}} | RP_ALL.cs:8267 {{{BOOK_DATA.DATA_TYPE}}} | RP_ALL.cs:8342 {{{BOOK_DATA.DATA_TYPE}}} |

No state, employee, customer-name, multi-book or summary/detail toggle is appended; the selection is sent unchanged to the chosen template: RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}}; RP_ALL.cs:8276 {{Module_Save.ShowReportPreview();}}; RP_ALL.cs:8351 {{Module_Save.ShowReportPreview();}}. Values other than A/B do not add DATA_TYPE: RP_ALL.cs:8186 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}}; RP_ALL.cs:8190 {{else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)}}.

**FROM / joins.** All three XML templates link APR_DETL left-outer to ITEM_MAST by CO_CODE+IT_CODE, BOOK_DATA by CO_CODE+LC_CODE+CO_BOOK, AC_MAST by CO_CODE+AC_CODE and CO_MAST by CO_CODE. InOut/Pending additionally link ITEM_MAST to PRODUCT_MAST by CO_CODE+PR_CODE. APR_DATA is not in these template table links, despite the packet’s broader family table list. Template selectors: RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}; RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}; RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}. Evidence: `extraction_output/rpt_xml/AprPartyWise.xml:12` (`<TableLinks>`); `extraction_output/rpt_xml/AprInOut.xml:12` (`<TableLinks>`); `extraction_output/rpt_xml/AprPan.xml:12` (`<TableLinks>`). Do not replace live master names/geography with snapshot names without recording a difference.

| Mode / template | Grouping and ascending order (GROUP BY / ORDER BY equivalent) | Evidence |
|---|---|---|
| AprPartyWise | AC_CODE → Group = CO_YEAR+CO_BOOK+VCH_NO; then SR_NO. Voucher header and detail rows, voucher footer then Party Total; no grand-total fields. | RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}; `extraction_output/rpt_xml/AprPartyWise.xml:252` (`<Groups>`); `extraction_output/rpt_xml/AprPartyWise.xml:256` (`<SortFields>`) |
| AprInOut | AC_CODE → PR_CODE → OpDate=VCH_DATE → Group=TAG_NO; then VCH_DATE. Product header sums, numeric details, tag footer sums, Party Total and Grand Total. | RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}; `extraction_output/rpt_xml/AprInOut.xml:271` (`<Groups>`); `extraction_output/rpt_xml/AprInOut.xml:277` (`<SortFields>`) |
| AprPan | AC_CODE → VchGroup=CO_YEAR+CO_BOOK+VCH_NO → PR_CODE → Group=TAG_NO; then SR_NO. Voucher header, product header sums, numeric details, tag footer sums, Party Total and Grand Total. | RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}; `extraction_output/rpt_xml/AprPan.xml:310` (`<Groups>`); `extraction_output/rpt_xml/AprPan.xml:316` (`<SortFields>`) |

All templates set ReportType to R; details suppress only when ReportType=S, which the approval handlers never set. InOut hides its date and tag headers and date/product footers; Pending hides its tag header and product/voucher footers. Pending additionally suppresses the tag-footer display when Sum(PanPcs, Group)=0; suppression does not remove the selected records or product/party/grand sums. RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}; `extraction_output/rpt_xml/AprPan.xml:936` (`EnableSuppress="Sum ({@PanPcs}, {@Group}) = 0`); `extraction_output/rpt_xml/AprPan.xml:863` (`{@ReportType} = 'S'`); `extraction_output/rpt_xml/AprInOut.xml:797` (`{@ReportType} = 'S'`). With repeated blank/N tags, the printed tag group can contain multiple lines; retain row identity for sums and reproduce the displayed grouping, rather than counting one per tag.

No custom voucher or ledger drill-down handler is wired in the approval buttons; they open a generic Crystal viewer with its report source and ToolPanelView=0: RP_ALL.cs:8276 {{Module_Save.ShowReportPreview();}}; Module_Save.cs:367 {{val3.ToolPanelView = (ToolPanelViewType)0;}}; Module_Save.cs:368 {{val3.ReportSource = val;}}. MISSING: runtime proof of Crystal built-in drill-down interactions. Do not claim a desktop voucher-navigation flow from a web link alone.

## Print

| Mode | Crystal name and exact title prefix | Evidence |
|---|---|---|
| Issue | AprPartyWise.RPT; Party Wise Approval Issue From dd/MM/yyyy To dd/MM/yyyy | RP_ALL.cs:8150 {{Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AprPartyWise.RPT";}}; RP_ALL.cs:8197 {{DC_Main.MsRptTitelStr = "'Party Wise Approval Issue From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";}} |
| InOut | AprInOut.RPT; Approval In Out Report From dd/MM/yyyy To dd/MM/yyyy | RP_ALL.cs:8225 {{Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AprInOut.RPT";}}; RP_ALL.cs:8272 {{DC_Main.MsRptTitelStr = "'Approval In Out Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";}} |
| Pending | AprPan.RPT; Panding Approval Report From dd/MM/yyyy To dd/MM/yyyy | RP_ALL.cs:8300 {{Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AprPan.RPT";}}; RP_ALL.cs:8347 {{DC_Main.MsRptTitelStr = "'Panding Approval Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";}} |

Old Crystal O clears formula slots 0–4, assigns ReportFileName, sets SelectionFormula and formula slot 0 RptTitel, uses Destination=0, WindowState=2, Action=−1 and MsPrintZoom. New N sets RptTitel, the title string, MsWappPrintType=All, RptName and RptFormula then calls ShowReportPreview. Representative Issue evidence (the other two handlers repeat this): RP_ALL.cs:8143 {{if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)}}; RP_ALL.cs:8145 {{Cr[(short)0] = "";}}; RP_ALL.cs:8149 {{Cr[(short)4] = "";}}; RP_ALL.cs:8194 {{if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)}}; RP_ALL.cs:8196 {{DC_Main.MsRptTitel = "RptTitel";}}; RP_ALL.cs:8197 {{DC_Main.MsRptTitelStr = "'Party Wise Approval Issue From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";}}; RP_ALL.cs:8198 {{DC_Main.MsWappPrintType = "All";}}; RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}; RP_ALL.cs:8200 {{DC_Main.RptFormula = CurFormula;}}; RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}}; RP_ALL.cs:8206 {{Cr.SelectionFormula = CurFormula;}}; RP_ALL.cs:8207 {{Cr[(short)0] = "RptTitel = 'Party Wise Approval Issue From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";}}; RP_ALL.cs:8208 {{Cr.Destination = (DestinationConstants)0;}}; RP_ALL.cs:8210 {{Cr.WindowState = (WindowStateConstants)2;}}; RP_ALL.cs:8211 {{Cr.Action = -1;}}; RP_ALL.cs:8212 {{Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));}}.

The shared new preview loads Report/RptName.rpt, assigns the title and record selection and opens a maximized Report Preview window: Module_Save.cs:230 {{val.Load(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + DC_Main.RptName + ".rpt");}}; Module_Save.cs:269 {{val.DataDefinition.FormulaFields[DC_Main.MsRptTitel].Text = DC_Main.MsRptTitelStr;}}; Module_Save.cs:354 {{val.RecordSelectionFormula = DC_Main.RptFormula;}}; Module_Save.cs:362 {{Text = "Report Preview - " + DC_Main.RptName,}}; Module_Save.cs:363 {{WindowState = (FormWindowState)2}}. It creates Send WhatsApp and Send Email buttons; this study does not operate those outbound actions: Module_Save.cs:378 {{Text = "Send WhatsApp",}}; Module_Save.cs:385 {{Text = "Send Email",}}.

All three extracted templates specify A4 portrait, company name/address, supplied title and page number; exact numeric precision is unresolved as noted above. RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}; RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}; RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}; `extraction_output/rpt_xml/AprPan.xml:6` (`PaperOrientation="Portrait"`). Column captions differ materially: Issue has Vch No, Date, Party_Name, Tag No, Pcs, Gr Wt, Net Wt, ItmAmt, Lbr Amt, Oth Amt, BillAmt; InOut has Vch No, Date, Party_Name, Pcs, Gr Wt, Net Wt, Oth Amt, Out Pcs, In Pcs, Panding; Pending has Vch No, Date, Tag No, Design, It Code, Item Name, Pcs, Gr Wt, Net Wt, Oth Amt, Panding. Evidence: XML Section4 of each selected template (TextObject positions establish left-to-right order).

## Rights

The Report dispatch is reached after AllBtn sets MsUserRightForm to the menu caption and queries USER_SET for session location/user/caption with FRM_VIEW=Y. No row shows exactly "You Have No Rights.....", restores PanelImage and returns (no field focus is assigned): MDI_FORM.cs:7034 {{DC_Main.MsUserRightForm = MsSideBtn;}}; MDI_FORM.cs:7041 {{AND FRM_VIEW = 'Y'}}; MDI_FORM.cs:7044 {{if (RsRight.Rows.Count == 0)}}; MDI_FORM.cs:7047 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}}; MDI_FORM.cs:7048 {{((Control)PanelImage).Visible = true;}}; MDI_FORM.cs:7049 {{return;}}; MDI_FORM.cs:7070 {{Report_Form();}}.

RP_ALL separately loads USER_SET by location/user/caption and reads FRM_EDIT, FRM_DELETE and FRM_PRINT. UserPrint is assigned but never tested elsewhere in this file; all three approval buttons call preview without a print refusal or rights message: RP_ALL.cs:6656 {{Select * From USER_SET WHERE LC_CODE}}; RP_ALL.cs:6775 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));}}; RP_ALL.cs:6776 {{UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));}}; RP_ALL.cs:6777 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}; RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}}; RP_ALL.cs:8276 {{Module_Save.ShowReportPreview();}}; RP_ALL.cs:8351 {{Module_Save.ShowReportPreview();}}. This absence is a desktop weakness, not permission to omit the web List/Print guards. The menu catalog’s ----PL is metadata, not an extra executable check found here.

## Desktop weaknesses not to port

- SQL help and record-selection strings interpolate user text; parameterize the web equivalents. RP_ALL.cs:7299 {{tBookCode.Text}}; RP_ALL.cs:8156 {{tLcCode.Text}}.

- Shared global report state carries caption, selection and title across forms; use request-local inputs. RP_ALL.cs:6658 {{CurRpt = DC_Main.MsUserRightForm;}}; RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}}.

- Print rights are read but not applied by the approval button; retain server enforcement. RP_ALL.cs:6777 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}; RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}}.

- Date conversion on click has no error guard, and SetDate has suspicious one-character comparisons against 29/30 and a substring starting at the separator; use safe date parsing while preserving verified texts. RP_ALL.cs:8152 {{Conversions.ToDate(mFromDt.Text)}}; DC_Main.cs:1641 {{if (Operators.CompareString(Strings.Mid(MsDate.Text, 1, 1), "29", false) > 0)}}; DC_Main.cs:1652 {{if (Operators.CompareString(Strings.Mid(MsDate.Text, 1, 1), "30", false) > 0)}}; DC_Main.cs:1676 {{else if (Conversion.Val(Strings.Mid(MsDate.Text, 3, 2)) > 12.0)}}.

- Cancel clears even the locked location without reapplying session scope; never allow this to widen tenant/location access. RP_ALL.cs:7217 {{val.Text = "";}}; RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}.

- Concatenated voucher group keys can collide; preserve equivalent grouping for ordinary fixed-format identifiers but retain structured internal keys. RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}; `extraction_output/rpt_xml/AprPartyWise.xml:268` (`{APR_DETL.CO_YEAR}+{APR_DETL.CO_BOOK}+{APR_DETL.VCH_NO}`).

## Web today

These are static code findings, not claims that tests or a browser journey passed in this session. No code was changed.

- `web/apps/api/src/modules/reports/reportFamilyReports.ts:23`: defaults the missing From to 2010-04-01, rejects reversed ranges, and scopedWhere adds tenant/company/date plus optional location/year.

- `web/apps/api/src/modules/reports/reportFamilyReports.ts:226`: sums InOut numeric totals using Number and toFixed (3 places for pieces/weights; 2 for other amount).

- `web/apps/api/src/modules/reports/reportFamilyReports.ts:241`: defines issue/inout/pending labels and template metadata; unknown modes fall back to issue.

- `web/apps/api/src/modules/reports/reportFamilyReports.ts:254`: is the current approval builder; all modes read APR_DETL and accept APR ISU plus legacy APPROVAL ISSUE families.

- `web/apps/api/src/modules/reports/reportFamilyReports.ts:270`: InOut treats Y and legacy web R as resolved, obtains one master row through lateral joins, and returns raw issue-line rows plus grand totals.

- `web/apps/api/src/modules/reports/reportFamilyReports.ts:355`: Pending coalesces null ISU_REC to N; Issue/Pending use ordinary joins, return flat rows without totals or product labels, and sort date/book/voucher/serial.

- `web/apps/api/src/modules/reports/reportFilters.ts:287`: binds approval filters to a, m and i, including EMP_CODE although the approval form has no employee selector.

- `web/apps/api/src/routes/txn.ts:6108`: registers GET /reports/approval-report and forwards q.mode plus readScope.

- `web/apps/api/src/routes/txn.ts:4250`: registers the family builder for exports; resolveReport shares its rows/totals across CSV/XLSX/PDF.

- `web/apps/api/src/routes/txn.ts:4412`: CSV and XLSX exports enforce print; PDF at line 4444 uses generic reportPdf output, not an approval template layout.

- `web/apps/api/src/modules/reports/reportAuthorization.ts:20`: maps the slug to Reports/Approval Report.

- `web/apps/api/src/modules/rbac/formCatalog.ts:405`: aliases Reports/Approval Report to Approval Rpt and RP_ALL, so the desktop caption already maps to this report.

- `web/apps/api/src/modules/rbac/routePolicy.ts:1040`: registers report access policy; routePolicy.test.ts line 682 pins the mapping.

- `web/apps/web/lib/nav.ts:305`: links Approval Report to /reports/approval-report.

- `web/apps/web/app/(app)/reports/[report]/page.tsx:132`: provides the generic report page with initial issue mode, blank date fields at lines 153–154, mode labels at 843–848, raw totals at 597 and generic output controls.

- `web/apps/api/src/modules/reports/rpAll/types.ts:17`: currently supports only branch sales; the shared engine/types must be extended rather than pretending Approval already uses it.

- `web/apps/api/src/modules/reports/rpAll/index.ts:83`: parses Sales modes and variants; engine.ts supplies grouping/totals, filters.ts selectors, salesLayouts.ts templates, salesQuery.ts read SQL, exportRows.ts common exports.

- `web/apps/api/src/routes/rpAllReport.ts:38`: exposes the new engine only for Sales Report and its CSV/XLSX routes.

- `web/apps/api/test/reportFamilyReports.db.test.ts:151`: checks Pending with party/product/geography and InOut pieces/product filtering, including duplicate-book and location cases.

- `web/apps/api/test/approvalInOutWebReturn.db.test.ts:188`: checks fresh issue, returned line and deletion of the return reopening pending state.

- `web/apps/api/test/reportScreens.routes.db.test.ts:126`: checks forwarding InOut mode/totals through screen, CSV and XLSX routes.

- `web/apps/api/test/reportFiltersApplied.db.test.ts:146`: pins filter binding registration; it is not an exhaustive Approval selector test.

- `web/apps/web/test/reportSurfaceLinks.test.ts:42`: pins the navigation surface link.

- `web/apps/web/test/features/modules/salesReport.mjs:1`: is the sibling feature module; no approvalReport module or approval-report match exists in the feature modules. Approval issue/return modules are writer fixtures, not report coverage.

- `web/apps/api/report-specs/AprPartyWise.spec.json, AprInOut.spec.json, AprPan.spec.json`: contain extracted layout/formula specifications; full groups, joins and suppression are in extraction_output/rpt_xml.

Reuse boundary: `rpAll/engine.ts:31–42` fixes pieces to 0, weights to 3 and money to 2 decimal places, with six-place accumulation. Approval must not inherit those as certified template precision without the missing Crystal evidence. `rpAll/index.ts:38–52` also hardcodes Sales mode/variant types; add an Approval mode contract, rather than forcing approval status into the Sales return flag.

The requested lineage-document search found no gap-table row explicitly naming Approval Rpt; its literal occurrence is the N234 shared-engine narrative at `docs/master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md:3698`. N234 at 3696–3730 remains in progress, references broad G06 and leaves screen, PDF, drill-down and runtime comparison open. G81 at line 96 concerns generic CSV encoding and N57; G37/N57 at 2893–2898 leaves broad typed-report formatting open. G242/N229 at line 257 and 3524–3585 is the upstream Approval writer dependency, with browser/rollback/Wh Sales and original-Windows work still open. G246 at line 261 is Sales Return and is not an Approval report finding. The exact Approval catalog row at `docs/handbook/menu-catalog.jsonl:174` records uncertified selectors, grouping, layouts and custody reconciliation under N22/X17/N24/X26/N57/N75. No backlog or historical document was edited.

## Gaps

1. **Wrong default date.** Desktop: From is 01/01/2010: RP_ALL.cs:7185 {{mFromDt.Text = "01/01/2010";}}. Web: `reportFamilyReports.ts:24` uses 2010-04-01 and the generic page at 153–154 shows blank dates. Fix: Initialize the dedicated selector screen to the desktop default and session system date; use the same defaults for exports.

2. **Wrong reversed-range response.** Desktop: The formula simply conjuncts inclusive endpoints: RP_ALL.cs:8152 {{AND {APR_DETL.VCH_DATE} >= #}}. Web: `reportFamilyReports.ts:26–29` throws ReportValidationError. Fix: Return an empty selection for valid reversed dates if adopting desktop behavior; keep safe malformed-date handling.

3. **Wrong pending null membership.** Desktop: Pending tests exact N: RP_ALL.cs:8302 {{AND {APR_DETL.ISU_REC} = 'N'}}. Web: `reportFamilyReports.ts:357` treats null as N. Fix: Use exact status selection; add null, blank, N, Y and legacy R fixtures with explicitly documented compatibility behavior.

4. **Missing DATA_TYPE selection.** Desktop: A/B are appended from global setting: RP_ALL.cs:8188 {{{BOOK_DATA.DATA_TYPE}}}; RP_ALL.cs:8192 {{{BOOK_DATA.DATA_TYPE}}}. Web: `reportFamilyReports.ts:263–359` and `reportFilters.ts:287` have no DATA_TYPE predicate. Fix: Resolve the shared setting contract/decision, then bind the approved data-type input; do not infer it from a client-provided SQL fragment.

5. **Missing grouping and template totals.** Desktop: The buttons select three distinct layouts: RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}; RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}; RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}; the XML groups/totals above are authoritative.. Web: `reportFamilyReports.ts:349–350` returns flat InOut lines and only grand totals; line 400 returns flat Issue/Pending rows without totals. Fix: Add Approval mode layouts/query adapter to rpAll and implement the product/header, tag/voucher and party sums, issue no-grand-total rule and zero-pending footer suppression.

6. **Wrong ordering.** Desktop: Issue/Pending sort serial within template groups and InOut sorts within party/product/date/tag: RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}; RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}; `extraction_output/rpt_xml/AprPan.xml:316` (`<SortFields>`). Web: `reportFamilyReports.ts:394` sorts Issue/Pending by date/book/voucher/serial; line 342 leaves distinct lines ungrouped. Fix: Use the template group keys and record-sort fields; retain unique source identity for accumulation.

7. **Wrong historical names.** Desktop: The templates bind live master name and book fields: RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}; `extraction_output/rpt_xml/AprPartyWise.xml:571` (`DataSource="{AC_MAST.AC_NAME}"`); `extraction_output/rpt_xml/AprPartyWise.xml:608` (`DataSource="{BOOK_DATA.BOOK_NAME}"`). Web: `reportFamilyReports.ts:295–296,366–368` prefers APR_DETL snapshot book/party names. Fix: Return live joined master labels for the template bands; test master edits after an issue.

8. **Wrong/missing screen and output text.** Desktop: Captions and title include Approval Panding and Panding Approval Report: RP_ALL.cs:5217 {{BtnAprPanding.Text = "&Approval Panding";}}; RP_ALL.cs:8347 {{DC_Main.MsRptTitelStr = "'Panding Approval Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";}}. Web: `page.tsx:843–848` uses Party Wise Issue/In Out/Pending; `reportFamilyReports.ts:243–245` omits the desktop title/date phrase; generic export renders property keys. Fix: Create the dedicated page and template-semantic output with exact captions, column order, group furniture and titles.

9. **Missing keys and lookup flow.** Desktop: Enter uses shared lookup/date handlers and Esc closes: RP_ALL.cs:7293 {{if ((int)e.KeyCode != 13)}}; RP_ALL.cs:7309 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}; RP_ALL.cs:7517 {{DC_Main.SetDate(ref MsDate);}}; RP_ALL.cs:7263 {{((Form)this).Close();}}. Web: No Approval-specific keyboard or lookup handlers/feature module were found; generic page supplies ordinary HTML inputs. Fix: Implement the verified Enter/Tab/Esc and mnemonic flow with lookup cancellation tests; do not label F1 a desktop requirement without further evidence.

10. **Selector contract differs.** Desktop: Approval only appends the listed selectors and keeps employee/state/multi-book hidden: RP_ALL.cs:6400 {{((Control)cboEmploy).Visible = false;}}; RP_ALL.cs:6549 {{((Control)cboState).Visible = false;}}; RP_ALL.cs:6539 {{((Control)chkBookSelect).Visible = false;}}; RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}}. Web: `reportFilters.ts:287–291` exposes employee binding; generic reusable selectors are not the approval-specific control set. Fix: Reuse the shared parser with an Approval allowed/ignored-filter table; retain enforced session location and deliberate year scope.

11. **Custody compatibility and journey evidence remain unverified.** Desktop: The chosen InOut template uses Y and Pending selects N: RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}; `extraction_output/rpt_xml/AprInOut.xml:293` (`if {APR_DETL.ISU_REC} = 'Y' then`); RP_ALL.cs:8302 {{AND {APR_DETL.ISU_REC} = 'N'}}. Web: `reportFamilyReports.ts:283` accepts Y/R and lines 268–269 accept legacy book families; existing tests cover a legacy return but no complete report browser journey exists. Fix: Keep compatibility explicit, exercise current approval writers plus Sales consume/reversal through the real UI, and reconcile original issue lines. Do not invent separate returned/billed fine-weight report columns.

12. **Potential duplicate amplification and scope difference.** Desktop: Template links include company/location/book, while report predicates do not add CO_YEAR: RP_ALL.cs:8152 {{{APR_DETL.CO_CODE} = '}}; `extraction_output/rpt_xml/AprPartyWise.xml:12` (`<TableLinks>`). Web: `reportFamilyReports.ts:378–386` uses ordinary master joins in Issue/Pending while InOut uses lateral single-master joins; scopedWhere at 52–54 restricts year. Fix: Test duplicate masters and previous-year custody; choose safe unique join keys. Preserve mandatory web scope unless the supervisor explicitly resolves the cross-year custody contract.

## Open questions

- MISSING: Crystal numeric display rounding/decimal metadata and original-Windows output. What precision/tie handling do the three templates actually print? This cannot be certified from Number/toFixed or the extracted ObjectFormat metadata.

- MISSING: generated Crystal SQL and runtime null-default/group-sort semantics. In particular, how do null or repeated untagged tag values render in the tag footer, and how does Crystal built-in drill-down behave? The source/template definition is covered; runtime certification remains separate.

- What approved setting supplies MsDataType in the web shared engine? The packet supplies no accepted replacement contract for the A/B global.

- Should Approval reporting deliberately span years in the one-database web or remain session-year scoped? The report formula has no year predicate, while desktop database selection and carry-forward can supply implicit year isolation. Resolve this before claiming historical custody equivalence.

- The stated gross/net/fine issued−returned−billed reconciliation goes beyond the printed piece-state formulas. Should those additional reconciliations be test-only evidence, or an explicitly approved new report surface? Do not silently alter the three desktop templates.

- The inspected Sales update uses book 018 and SR_NO; Return uses OLD_SRNO. Which current writer variants are in the required custody journey? Source evidence is recorded above; broad writer corrections remain outside this study.
