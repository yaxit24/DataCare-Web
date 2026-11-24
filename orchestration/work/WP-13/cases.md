# WP-13 cases: Report → Approval Rpt (desktop `RP_ALL`, caption "Approval Rpt")

Frozen case list built from `orchestration/work/WP-13/study.md` (12 gaps). Desktop citations are
`FORM.cs:LINE {{quoted text}}`, copied from the study; template evidence is the checked-in extracted XML
(`extraction_output/rpt_xml/…`), cited as in the study. Nothing here is accepted. The dedicated approval-report
screen does not exist yet (study §Web today, gap 8); building it is inside WP-13, so the cases below are
`executable` contracts that fail today against the current web, not blocked work. Each case names the gap it
proves. Case ids start with the feature slug `approval-report` and follow the group/name style of
`web/apps/web/test/features/modules/salesReport.mjs` (the sibling RP_ALL report). No approval-report browser
module exists yet (study §Web today); the T18 journeys reuse the approval writer fixtures in
`web/apps/web/test/features/modules/approvalHelpers.mjs` (`seedApprovalTag`, `createIssue`, `createReturn`)
rather than inventing new voucher plumbing.

**Conventions.** Company `01`, session location `01`, current fiscal year `2026-27`, session system date
`MsSysDate` = 15/07/2026, `MsAlterYear` = `N`, country not UAE, `MsCrystalRptType` = `N` (the new preview path),
`MsDataType` blank and `MsAllBranchAcShow` = `N` unless a case sets them. Dates display dd/MM/yyyy. All arithmetic
is exact decimal on the stored values (never binary float, never pre-rounded); the worked sums in each case use
the seed vouchers of §Test data. Layers: `browser` = real UI; `database` = the real endpoint on the isolated
database; `unit` = a pure selection/mapping rule. The three modes are Issue (`AprPartyWise`), InOut (`AprInOut`)
and Pending (`AprPan`), selected by RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}},
RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}} and RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}.

## Decisions (architect, 2026-11-23, owner may override)

Each open question of the study is decided by the owner's standing rule: "the desktop first; the web adds only
what a hosted multi-user service needs to be safe and correct". A question the source cannot settle stays
`blocked` with the exact question.

- **D1 — numeric precision (study open question 1).** The three templates and the three click handlers contain
  no Round call; calculation authority is the template (RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}), so
  calculations preserve stored precision exactly. The printed decimal/tie format cannot be certified: the
  extracted XML exposes no numeric display metadata and there is no original-Windows render. The web's
  `toFixed(3/2)` (reportFamilyReports.ts:226) is **not** desktop-authoritative. The display-precision case is
  `blocked`; computation-precision cases assert exact stored-precision sums.
- **D2 — runtime null/group-sort and drill-down (study open question 2).** Grouping, sort and suppression follow
  the extracted template definitions (groups, sort fields, `EnableSuppress`), which are source-settled. The
  runtime rendering of a NULL tag value in the tag footer and Crystal's built-in drill-down are not provable
  from the checked-in evidence; those two cases are `blocked`. No voucher drill-down link is claimed as a
  desktop requirement: the approval buttons wire no custom drill-down and open the generic viewer with
  ToolPanelView=0 (Module_Save.cs:367 {{val3.ToolPanelView = (ToolPanelViewType)0;}}).
- **D3 — MsDataType source (study open question 3).** The desktop rule is source-settled: append
  `{BOOK_DATA.DATA_TYPE} = 'A'` when the session setting is A, `'B'` when B, nothing otherwise
  (RP_ALL.cs:8186 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}},
  RP_ALL.cs:8188 {{{BOOK_DATA.DATA_TYPE}}}, RP_ALL.cs:8190 {{else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)}},
  RP_ALL.cs:8192 {{{BOOK_DATA.DATA_TYPE}}}). No accepted web contract supplies that setting (salesReport.mjs
  settingsManifest: "not ported"). The selection-rule unit case is executable; the end-to-end binding case is
  `blocked` on the owner approving the setting source. Never infer it from a client-provided SQL fragment (gap 4).
- **D4 — year scope (study open question 4).** Keep the mandatory web session-year scope. The desktop formula
  appends no CO_YEAR predicate (RP_ALL.cs:8152 {{{APR_DETL.CO_CODE} = '}}), but the desktop runs against a
  per-year database, so year isolation is implicit; reproducing that business result in the one-database web
  requires the session-year filter. The missing CO_YEAR predicate is recorded as a deliberate, documented
  difference; cross-year custody equivalence is **not** claimed. A cross-year custody report would be a new
  surface needing owner approval (gap 12).
- **D5 — custody reconciliation (study open question 5).** The gross/net/fine issued−returned−billed
  reconciliation is **test-only journey evidence** at the database layer, not a new report surface. The three
  templates are not altered; fine is absent from all three layouts (study §Calculations), so no fine/returned/
  billed report column is invented (gap 11).
- **D6 — writer variants and compatibility (study open question 6).** The required custody journey exercises
  both desktop resolution paths: Return joins `OLD_SRNO` (TR_APR_ISU.cs:6414 {{APR_DETL.OLD_SRNO = B.ISU_SRNO}})
  and Sales consume joins `SR_NO` restricted to approval book `018` (TR_SALE.cs:16112 {{APR_DETL.SR_NO = B.ISU_SRNO}},
  TR_SALE.cs:16112 {{AND APR_DETL.CO_BOOK = '018'}}); both set ISU_REC='Y' (TR_APR_ISU.cs:6414 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}},
  TR_SALE.cs:16112 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}}). The journey runs through the current web
  writers; where a web variant differs (the web return writes legacy `R`, the web sale path joins OLD_SRNO in
  approvalSaleReferences.ts:100, provisioned companies use the `APPROVAL ISSUE` book family), the difference is
  recorded explicitly in the case evidence, never silently ported or changed. Compatibility stays explicit:
  InOut counts `Y` and legacy `R` as resolved; Pending selects exact `N` (gaps 3, 11).
- **D7 — reversed range (gap 2, standing rule).** Desktop first: valid reversed dates produce an unsatisfiable
  selection and an empty report, not a validation error (RP_ALL.cs:8152 {{AND {APR_DETL.VCH_DATE} >= #}}).
  Malformed dates are still refused safely; the desktop's unguarded conversion is a weakness not to port
  (RP_ALL.cs:8152 {{Conversions.ToDate(mFromDt.Text)}}).
- **D8 — O/N Crystal plumbing (standing rule).** The web implements the N-path business result (template,
  selection, title, maximized preview: Module_Save.cs:230 {{val.Load(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + DC_Main.RptName + ".rpt");}}).
  The O-path `Cr` control mechanics (Destination=0, WindowState=2, PageZoom) are delivery plumbing with identical
  business output; listed under Not covered.
- **D9 — Cancel scope (weakness, standing rule).** Cancel clears the fields (RP_ALL.cs:7217 {{val.Text = "";}})
  including the locked location, but the web must keep enforcing session location/tenant scope server-side; a
  cleared location box never widens access (RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}).
- **D10 — print rights (weakness, standing rule).** The desktop reads FRM_PRINT but never refuses preview
  (RP_ALL.cs:6777 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}};
  RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}}). The web retains the List/Print server guards because a
  hosted multi-user service needs them; this is a deliberate safety addition, not a desktop business result.

## T01 Entry/defaults

### approval-report.entry.menu-caption-and-panel   (T01 Entry/defaults)
Layer: browser
Steps: 1. Sign in with the menu right. 2. Open Reports → Approval Report. 3. Read the page caption and the visible action panel.
Expected: the caption is `Approval Rpt`, taken from the menu right, not a parsed window number
(RP_ALL.cs:6658 {{CurRpt = DC_Main.MsUserRightForm;}}; RP_ALL.cs:6659 {{lblBook.Text = CurRpt;}}). The approval
panel is shown over the sales panel (RP_ALL.cs:6707 {{else if (Operators.CompareString(CurRpt, "Approval Rpt", false) == 0)}};
RP_ALL.cs:6709 {{((Control)PanelApr).Visible = true;}}; RP_ALL.cs:6710 {{((Control)PanelApr).Top = ((Control)PanelSale).Top;}};
RP_ALL.cs:6711 {{((Control)PanelApr).Left = ((Control)PanelSale).Left;}}). Desktop dispatch constructs RP_ALL and
focuses it (MDI_FORM.cs:8921 {{case "Approval Rpt":}}; MDI_FORM.cs:8923 {{RP_ALL rP_ALL5 = new RP_ALL();}};
MDI_FORM.cs:8928 {{((Control)rP_ALL5).Focus();}}). Gap 8.
Status: executable

### approval-report.entry.three-approval-buttons   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the page. 2. List the approval action buttons in tab order with their exact captions.
Expected: exactly three buttons, `&Approval Isu` (tab 0), `&Approval InOut` (tab 1), `&Approval Panding` (tab 2)
— the desktop spelling "Panding" is preserved (RP_ALL.cs:5164 {{((Control)btnAprRpt).TabIndex = 0;}};
RP_ALL.cs:5165 {{btnAprRpt.Text = "&Approval Isu";}}; RP_ALL.cs:5190 {{((Control)btnAprInOut).TabIndex = 1;}};
RP_ALL.cs:5191 {{btnAprInOut.Text = "&Approval InOut";}}; RP_ALL.cs:5216 {{((Control)BtnAprPanding).TabIndex = 2;}};
RP_ALL.cs:5217 {{BtnAprPanding.Text = "&Approval Panding";}}). All three are added to PanelApr
(RP_ALL.cs:5132 {{((Control)PanelApr).Controls.Add((Control)(object)btnAprRpt);}};
RP_ALL.cs:5133 {{((Control)PanelApr).Controls.Add((Control)(object)btnAprInOut);}};
RP_ALL.cs:5134 {{((Control)PanelApr).Controls.Add((Control)(object)BtnAprPanding);}}). No MsSoftType check reduces
them for Lite (study §Scope). The web's current labels "Party Wise Issue/In Out/Pending" (page.tsx:843–848) are
wrong. Gap 8.
Status: executable

### approval-report.entry.date-defaults   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the page with MsSysDate 15/07/2026. 2. Read From, To and the focused control.
Expected: From = `01/01/2010`, To = the session system date `15/07/2026`, initial focus on From
(RP_ALL.cs:7183 {{else if (Operators.CompareString(CurRpt, "Approval Rpt", false) == 0)}};
RP_ALL.cs:7185 {{mFromDt.Text = "01/01/2010";}}; RP_ALL.cs:7203 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}};
RP_ALL.cs:7204 {{CurActCtrl = (Control)(object)mFromDt;}}). The mask is `00/00/0000`
(RP_ALL.cs:5619 {{mFromDt.Mask = "00/00/0000";}}). The web default 2010-04-01 (reportFamilyReports.ts:24) and the
blank page dates (page.tsx:153–154) are wrong; exports use the same defaults. Gap 1.
Status: executable

### approval-report.entry.location-scope-lock   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the page as a location-01 user. 2. Read lc Code/lc Name and try to edit them. 3. Repeat as a location-00 user.
Expected: lc Code/lc Name show the session location (RP_ALL.cs:6662 {{tLcCode.Text = DC_Main.MLc_code;}};
RP_ALL.cs:6663 {{tLcName.Text = DC_Main.MLc_Name;}}). Outside location 00 both are disabled
(RP_ALL.cs:6660 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}};
RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}; RP_ALL.cs:6665 {{((Control)tLcName).Enabled = false;}});
at 00 they remain editable (RP_ALL.cs:6669 {{tLcCode.Text = DC_Main.MLc_code;}};
RP_ALL.cs:6670 {{tLcName.Text = DC_Main.MLc_Name;}}).
Status: executable

### approval-report.entry.selector-set-and-hidden-controls   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the page. 2. List every visible selector and bottom button. 3. Search the DOM for employee, state, multi-book and item-panel controls.
Expected: visible selectors are From/To Date, lc Code, Book, Pr Code, Gr Code, Party Code, Cust Name, City, Area,
Item Type (labels: RP_ALL.cs:4808 {{Label2.Text = "From / To Date";}}; RP_ALL.cs:4934 {{Label6.Text = "lc Code";}};
RP_ALL.cs:4798 {{Label1.Text = "Book";}}; RP_ALL.cs:4894 {{Label4.Text = "Pr Code";}}; RP_ALL.cs:5646 {{Label7.Text = "Gr Code";}};
RP_ALL.cs:4832 {{Label3.Text = "Party Code";}}; RP_ALL.cs:5804 {{Label8.Text = "Cust Name";}};
RP_ALL.cs:4851 {{lblCity.Text = "City";}}; RP_ALL.cs:4870 {{Label17.Text = "Area";}}; RP_ALL.cs:4910 {{Label5.Text = "Item Type";}}).
Employee, State, Select Book and the item grid panel stay hidden for Approval
(RP_ALL.cs:6400 {{((Control)cboEmploy).Visible = false;}}; RP_ALL.cs:6411 {{((Control)lblemp).Visible = false;}};
RP_ALL.cs:6549 {{((Control)cboState).Visible = false;}}; RP_ALL.cs:6560 {{((Control)Label9).Visible = false;}};
RP_ALL.cs:6539 {{((Control)chkBookSelect).Visible = false;}}; RP_ALL.cs:6421 {{((Control)PnlIt).Visible = false;}});
only the Sales branch shows them (RP_ALL.cs:6679 {{((Control)lblemp).Visible = true;}};
RP_ALL.cs:6680 {{((Control)cboEmploy).Visible = true;}}; RP_ALL.cs:6681 {{((Control)chkBookSelect).Visible = true;}}).
All five bottom buttons are present, none hidden for approval (RP_ALL.cs:4266 {{((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);}};
RP_ALL.cs:4267 {{((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);}};
RP_ALL.cs:4268 {{((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);}};
RP_ALL.cs:4269 {{((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);}};
RP_ALL.cs:4270 {{((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);}}). The web exposes an EMP_CODE
binding the approval form does not have (reportFilters.ts:287). Gap 10.
Status: executable

### approval-report.entry.selector-lists   (T01 Entry/defaults)
Layer: browser
Steps: 1. Seed parties with cities C1, C2, C1 and areas AR1, AR2, AR1. 2. Open the page. 3. Read the City, Area and Item Type lists.
Expected: City lists distinct company-master AC_CITY values ordered by AC_CITY (C1, C2), not voucher snapshots
(RP_ALL.cs:7087 {{SELECT AC_CITY FROM AC_MAST WHERE CO_CODE}}); Area lists distinct AC_AREA ordered by AC_AREA
(AR1, AR2) (RP_ALL.cs:7121 {{GROUP BY AC_AREA ORDER BY AC_AREA}}). Item Type choices are exactly, in order:
blank, Gold, Silver, Diamond, Real Stone, Emitation, Other, Platinum, with blank selected
(RP_ALL.cs:7165 {{cboItemTyp.Items.Add((object)"");}}; RP_ALL.cs:7166 {{cboItemTyp.Items.Add((object)"Gold");}};
RP_ALL.cs:7167 {{cboItemTyp.Items.Add((object)"Silver");}}; RP_ALL.cs:7168 {{cboItemTyp.Items.Add((object)"Diamond");}};
RP_ALL.cs:7169 {{cboItemTyp.Items.Add((object)"Real Stone");}}; RP_ALL.cs:7170 {{cboItemTyp.Items.Add((object)"Emitation");}};
RP_ALL.cs:7171 {{cboItemTyp.Items.Add((object)"Other");}}; RP_ALL.cs:7172 {{cboItemTyp.Items.Add((object)"Platinum");}};
RP_ALL.cs:7173 {{cboItemTyp.SelectedIndex = 0;}}). The desktop spelling "Emitation" is preserved.
Status: executable

### approval-report.entry.view-right-gate   (T01 Entry/defaults)
Layer: browser
Steps: 1. Sign in as a user with no Reports/Approval Report view right. 2. Try to open the menu.
Expected: desktop dispatch queries USER_SET for the session location/user/caption with FRM_VIEW=Y
(MDI_FORM.cs:7034 {{DC_Main.MsUserRightForm = MsSideBtn;}}; MDI_FORM.cs:7041 {{AND FRM_VIEW = 'Y'}}); with no row
it shows exactly `You Have No Rights.....`, restores the image panel and returns without opening the form
(MDI_FORM.cs:7044 {{if (RsRight.Rows.Count == 0)}}; MDI_FORM.cs:7047 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}};
MDI_FORM.cs:7048 {{((Control)PanelImage).Visible = true;}}; MDI_FORM.cs:7049 {{return;}}). The web refuses the
API/page for that user (403), no report rows returned.
Status: executable

## T02 Field route

### approval-report.filters.one-at-a-time   (T02 Field route)
Layer: database
Steps: 1. Seed V1, V2, V3 (location 02), V9 (party P3). 2. Run Issue with each selector alone: location 01, book 018, party P1, product PR1, city C1, area AR1, item type Gold, group G1. 3. Compare the returned row identities.
Expected: each nonblank selector appends exactly its predicate and nothing else: location
(RP_ALL.cs:8156 {{And {APR_DETL.LC_CODE}}}), book (RP_ALL.cs:8160 {{And {APR_DETL.CO_BOOK}}}), party
(RP_ALL.cs:8164 {{And {APR_DETL.AC_CODE}}}), product on ITEM_MAST.PR_CODE (RP_ALL.cs:8168 {{And {ITEM_MAST.PR_CODE}}}),
city (RP_ALL.cs:8172 {{And {AC_MAST.AC_CITY}}}), area (RP_ALL.cs:8176 {{And {AC_MAST.AC_AREA}}}), item type
(RP_ALL.cs:8180 {{Strings.Mid(cboItemTyp.Text, 1, 1)}}), group (RP_ALL.cs:8184 {{And {ITEM_MAST.GR_CODE}}}).
Concretely: party P1 → V1's two lines only; product PR1 → V1L1 + V2L1; city C1 → P1 and P3 rows, not P2 (city
C2); group G1 → the I1 lines; location 01 excludes V3. InOut and Pending repeat the same predicates
(RP_ALL.cs:8231 {{And {APR_DETL.LC_CODE}}}; RP_ALL.cs:8306 {{And {APR_DETL.LC_CODE}}}). The web must bind an
Approval allowed-filter table, not the generic EMP_CODE set (reportFilters.ts:287). Gap 10.
Status: executable

### approval-report.filters.date-range-inclusive-and-year   (T02 Field route)
Layer: database
Steps: 1. Seed V1 (10/07), V2 (12/07), V11 (09/07), V12 (13/07), V4 (year 2025-26). 2. Run Issue From 10/07/2026 To 12/07/2026.
Expected: company and inclusive date endpoints always apply (RP_ALL.cs:8152 {{{APR_DETL.CO_CODE} = '}};
RP_ALL.cs:8152 {{AND {APR_DETL.VCH_DATE} >= #}}; RP_ALL.cs:8227 {{AND {APR_DETL.VCH_DATE} <= #}}): V1 (on From)
and V2 (on To) are included; V11 (day before) and V12 (day after) are not. The desktop formula appends no
CO_YEAR predicate; per D4 the web keeps the session-year filter, so V4 (2025-26) is excluded — a documented
difference reproducing the desktop's implicit per-year database isolation. Gap 12.
Status: executable

### approval-report.filters.item-type-first-character   (T02 Field route)
Layer: database
Steps: 1. Seed I1 (IT_TYPE G), I2 (S), I4 (R). 2. Run Issue with Item Type = Real Stone, then Gold, then Emitation, then blank.
Expected: the predicate uses the first character of the choice (RP_ALL.cs:8180 {{Strings.Mid(cboItemTyp.Text, 1, 1)}}):
Real Stone → `IT_TYPE = 'R'` (I4 lines only); Gold → `'G'` (I1 lines); Emitation → `'E'` (no rows in this seed);
blank appends no predicate (the nonblank guard RP_ALL.cs:8178 {{if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)}}). The full word is never matched.
Status: executable

### approval-report.filters.ignored-selectors   (T02 Field route)
Layer: browser
Steps: 1. Type a customer name in Cust Name and press Enter. 2. Send an API request carrying employee, state and multi-book filters. 3. Run Issue.
Expected: non-Order Enter clears Cust Name and moves focus to City (RP_ALL.cs:9717 {{tCustName.Text = "";}};
RP_ALL.cs:9718 {{((Control)cboCity).Focus();}}); Cust Name is not an approval filter. No employee, state,
multi-book or summary/detail predicate is appended (study §Lifecycle; the hidden controls of
RP_ALL.cs:6400 {{((Control)cboEmploy).Visible = false;}} and RP_ALL.cs:6539 {{((Control)chkBookSelect).Visible = false;}}).
The API ignores employee/state/multi-book inputs for this report rather than filtering on them; the selection
is sent unchanged to the template (RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}}). Gap 10.
Status: executable

### approval-report.filters.combined-and   (T02 Field route)
Layer: database
Steps: 1. Seed V1 (P1, city C1, PR1+PR2, G1+G2), V2 (P2, city C2, PR1, G1). 2. Run Issue with party P1 AND product PR1 AND city C1.
Expected: the predicates conjunct (AND): only V1L1 (P1, PR1, city C1) returns — V1L2 fails product PR1, V2L1
fails party P1 and city C1. Each predicate is appended only when its box is nonblank
(RP_ALL.cs:8162 {{if (Operators.CompareString(tAcCode.Text, "", false) != 0)}};
RP_ALL.cs:8166 {{if (Operators.CompareString(tItCode.Text, "", false) != 0)}};
RP_ALL.cs:8170 {{if (Operators.CompareString(cboCity.Text, "", false) != 0)}}).
Status: executable

### approval-report.filters.main-book-family   (T02 Field route)
Layer: database
Steps: 1. Seed V1/V2 (book 018, MAIN_BOOK APR ISU), V5 (book X1, MAIN_BOOK SALES), V6 (APR RTN), V10 (legacy APPROVAL ISSUE family). 2. Run all three modes.
Expected: every mode requires MAIN_BOOK = 'APR ISU' (RP_ALL.cs:8153 {{{BOOK_DATA.MAIN_BOOK} = 'APR ISU'}};
RP_ALL.cs:8228 {{{BOOK_DATA.MAIN_BOOK} = 'APR ISU'}}; RP_ALL.cs:8303 {{{BOOK_DATA.MAIN_BOOK} = 'APR ISU'}}), so
V5 (SALES) and V6 (APR RTN) never appear. Per D6 the web also accepts the provisioned legacy `APPROVAL ISSUE`
family (reportFamilyReports.ts:268–269); V10 appears and that compatibility is recorded explicitly, not as a
desktop rule. Gap 11.
Status: executable

### approval-report.filters.pending-exact-n   (T02 Field route)
Layer: database
Steps: 1. Seed V7 (party P3) with five lines of 1 pc each, ISU_REC = null, blank, N, Y, R. 2. Run Pending. 3. Run InOut.
Expected: Pending selects exactly `ISU_REC = 'N'` (RP_ALL.cs:8302 {{AND {APR_DETL.ISU_REC} = 'N'}}): only the N
line returns, 1 pc for P3; null, blank, Y and R are excluded. The web coalesces null→N
(reportFamilyReports.ts:357) and would return 2 pcs — wrong today. InOut has no ISU_REC selection predicate;
Out = 5 pcs, In counts resolved lines. Desktop In is Y only (AprInOut.xml:293, `if {APR_DETL.ISU_REC} = 'Y' then`);
per D6 the web also counts legacy R as resolved, so the frozen web expectation is In 2 / Pending 3 with the R
compatibility recorded as a deliberate difference (desktop-exact In 1 / Pending 4). Gaps 3, 11.
Status: executable

### approval-report.filters.data-type-selection   (T02 Field route)
Layer: unit
Steps: 1. Drive the approval selection builder with data-type input A, then B, then blank/other. 2. Inspect the generated selection.
Expected: input A appends `and {BOOK_DATA.DATA_TYPE} = 'A'`, B appends `'B'`, any other value appends nothing
(RP_ALL.cs:8186 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}};
RP_ALL.cs:8188 {{{BOOK_DATA.DATA_TYPE}}}; RP_ALL.cs:8190 {{else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)}};
RP_ALL.cs:8192 {{{BOOK_DATA.DATA_TYPE}}}). The current builder has no DATA_TYPE predicate at all
(reportFamilyReports.ts:263–359, reportFilters.ts:287), so this fails today. Gap 4.
Status: executable

### approval-report.filters.data-type-setting-source   (T02 Field route)
Layer: browser
Steps: 1. Set the approved session data-type setting to A. 2. Run Issue end to end. 3. Repeat with B.
Expected: with the session setting A the report selects only BOOK_DATA.DATA_TYPE='A' rows; with B only 'B'
rows; the input comes from the approved setting, never a client SQL fragment (D3).
Status: blocked: no accepted web contract supplies MsDataType (study open question 3; salesReport.mjs
settingsManifest "not ported"). Exact question: which approved company/session setting supplies the A/B
data-type input to the shared engine? Unblocks: owner accepts the setting-source contract; then bind it and run.
Gap 4.

## T03 Formula sequence

### approval-report.formula.issue-party-sums   (T03 Formula sequence)
Layer: database
Steps: 1. Seed V1, V2. 2. Run Issue over 01/01/2010..15/07/2026, location 01. 3. Read the voucher and party sums.
Expected: AprPartyWise sums the stored ITM_PCS, ITM_GWT, ITM_NWT, ITM_AMT, LBR_AMT, OTH_AMT at voucher Group
(CO_YEAR+CO_BOOK+VCH_NO) and party AC_CODE (RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}};
`extraction_output/rpt_xml/AprPartyWise.xml:289` (`FormulaName="Sum ({APR_DETL.ITM_PCS}, {@Group})"`);
`extraction_output/rpt_xml/AprPartyWise.xml:300` (`FormulaName="Sum ({APR_DETL.OTH_AMT}, {APR_DETL.AC_CODE})"`)).
Voucher V1: Pcs 1+2=3, GrWt 10.500+20.000=30.500, NetWt 10.000+19.000=29.000, ItmAmt 500.00+800.00=1300.00,
Lbr 50.00+80.00=130.00, Oth 10.00+20.00=30.00. Party P1 total = the V1 sums (3 / 30.500 / 29.000 / 1300.00 /
130.00 / 30.00); party P2 = 3 / 31.500 / 30.000 / 1500.00 / 150.00 / 30.00. NET_AMT prints per detail line
(560.00, 900.00, 1680.00) but has no summary; the report footer is empty — no grand total
(`extraction_output/rpt_xml/AprPartyWise.xml:763` (`DataSource="{APR_DETL.NET_AMT}"`)). The web returns flat
rows without these totals (reportFamilyReports.ts:400). Gap 5.
Status: executable

### approval-report.formula.inout-out-in-pending   (T03 Formula sequence)
Layer: database
Steps: 1. Seed V1, V2 (all N). 2. Run InOut. 3. Save return V6 resolving V1L1 (ISU_REC Y). 4. Run InOut again.
Expected: OutPcs = ITM_PCS on APR ISU lines, InPcs = ITM_PCS when ISU_REC='Y', PanPcs = Out−In
(RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}; RP_ALL.cs:8228 {{{BOOK_DATA.MAIN_BOOK} = 'APR ISU'}};
`extraction_output/rpt_xml/AprInOut.xml:300` (`FormulaName="{@OutPcs}"`);
`extraction_output/rpt_xml/AprInOut.xml:293` (`FormulaName="{@InPcs}"`);
`extraction_output/rpt_xml/AprInOut.xml:304` (`FormulaName="{@PanPcs}"`)). Before the return: V1L1 Out 1 In 0
Pending 1; V1L2 Out 2 In 0 Pending 2; V2L1 Out 3 In 0 Pending 3. After V6: V1L1 Out 1 In 1 Pending 0; the other
lines unchanged. This is issue-line status reporting — it selects no return vouchers and no separate billed
pieces (study §Calculations). Legacy R counts as In per D6. Gaps 5, 11.
Status: executable

### approval-report.formula.inout-sum-levels   (T03 Formula sequence)
Layer: database
Steps: 1. Seed V1, V2 (all N). 2. Run InOut. 3. Read product headers, tag footers, party totals and grand total.
Expected: AprInOut sums TagPcs/TagGwt/TagNwt/TagOth/OutPcs/InPcs/PanPcs per product PR_CODE (header), tag Group
(footer), party AC_CODE (footer) and report (Grand Total) (RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}};
`extraction_output/rpt_xml/AprInOut.xml:342` (`FormulaName="Sum ({@TagPcs}, {ITEM_MAST.PR_CODE})"`);
`extraction_output/rpt_xml/AprInOut.xml:355` (`FormulaName="Sum ({@PanPcs}, {@Group})"`);
`extraction_output/rpt_xml/AprInOut.xml:362` (`FormulaName="Sum ({@PanPcs}, {APR_DETL.AC_CODE})"`);
`extraction_output/rpt_xml/AprInOut.xml:369` (`FormulaName="Sum ({@PanPcs})"`)). Tag* formulas fire only for
MAIN_BOOK='APR ISU' (`extraction_output/rpt_xml/AprInOut.xml:322` (`FormulaName="{@TagPcs}"`)). Worked: PR1
header (V1L1+V2L1) TagPcs 1+3=4, TagGwt 10.500+31.500=42.000, TagNwt 10.000+30.000=40.000, TagOth 10.00+30.00=40.00,
Out 4 In 0 Pan 4; PR2 header (V1L2) TagPcs 2, TagGwt 20.000, TagNwt 19.000, TagOth 20.00, Out 2 In 0 Pan 2.
Party P1 footer Out 1+2=3 In 0 Pan 3; P2 Out 3 In 0 Pan 3. Grand Out 6 In 0 Pan 6, TagPcs 6, TagGwt 62.000,
TagNwt 59.000, TagOth 60.00. The web returns flat lines and only grand totals (reportFamilyReports.ts:349–350).
Gap 5.
Status: executable

### approval-report.formula.pending-signed-tags   (T03 Formula sequence)
Layer: database
Steps: 1. Seed V1, V2 (all N). 2. Run Pending. 3. Read the tag formulas and PanPcs.
Expected: AprPan TagPcs/TagGwt/TagNwt/TagOth = +value when MAIN_BOOK='APR ISU' else −value
(`extraction_output/rpt_xml/AprPan.xml:364` (`FormulaName="{@TagPcs}"`);
`extraction_output/rpt_xml/AprPan.xml:347` (`FormulaName="{@TagGwt}"`)), but the selection forces APR ISU
(RP_ALL.cs:8303 {{CurFormula += " And {BOOK_DATA.MAIN_BOOK} = 'APR ISU'";}}), so the negative branch and the
APR RTN InPcs formula (`extraction_output/rpt_xml/AprPan.xml:332` (`FormulaName="{@InPcs}"`)) cannot affect this
button. PanPcs = raw ITM_PCS (`extraction_output/rpt_xml/AprPan.xml:339` (`FormulaName="{@PanPcs}"`)). Sums per
PR_CODE header, tag Group footer, AC_CODE footer and Grand Total (RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}};
`extraction_output/rpt_xml/AprPan.xml:393` (`FormulaName="Sum ({@TagPcs}, {ITEM_MAST.PR_CODE})"`);
`extraction_output/rpt_xml/AprPan.xml:412` (`FormulaName="Sum ({@PanPcs})"`)). Worked: P1 PanPcs 3, P2 3, Grand 6;
TagOth P1 30.00, P2 30.00, Grand 60.00. Gap 5.
Status: executable

### approval-report.formula.pending-zero-footer-suppression   (T03 Formula sequence)
Layer: database
Steps: 1. Seed V8 (party P3, two lines TAG_NO 'Z0', ITM_PCS 0 each, OTH_AMT 5.00 and 3.00, ISU_REC N). 2. Run Pending.
Expected: the tag footer is suppressed when Sum(PanPcs, Group)=0
(`extraction_output/rpt_xml/AprPan.xml:936` (`EnableSuppress="Sum ({@PanPcs}, {@Group}) = 0"`)): tag Z0 shows no
footer (0+0=0), but its two detail rows still print and the product/party/grand sums are unchanged — P3 party
PanPcs 0, TagOth 5.00+3.00=8.00; grand TagOth gains 8.00, grand PanPcs unchanged. Suppression hides display, not
records (study §Lifecycle). Details suppress only when ReportType=S, which these handlers never set
(`extraction_output/rpt_xml/AprPan.xml:863` (`{@ReportType} = 'S'`)). Gap 5.
Status: executable

### approval-report.formula.precision-preserved   (T03 Formula sequence)
Layer: database
Steps: 1. Seed V1, V2 plus a line with OTH_AMT 0.005. 2. Run InOut and Issue. 3. Read the sums at full stored precision.
Expected: no Round call exists in the template formulas or the click handlers (study §Calculations; the handlers
only build selection and open the template, RP_ALL.cs:8216-8290 {{Cr.Action = -1;}}), so sums keep stored
precision: TagGwt 10.500+20.000+31.500=62.000 exactly (3 decimals, not pre-rounded to 2); ItmAmt
500.00+800.00+1500.00=2800.00; Oth 30.00+0.005=30.005 preserved in the computation. The web's Number/toFixed
(reportFamilyReports.ts:226) must not change the stored-precision sum. Printed display format is D1/blocked, not
asserted here. Gap 5.
Status: executable

## T04 Lookup

### approval-report.lookup.book-enter   (T04 Lookup)
Layer: browser
Steps: 1. Focus Book. 2. Press Enter blank, then with a valid code, then with an unknown code. 3. In help, pick a book; repeat and cancel.
Expected: Enter gates on key 13 (RP_ALL.cs:7293 {{if ((int)e.KeyCode != 13)}}). Blank or valid advances Tab
(RP_ALL.cs:7323 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7328 {{SendKeys.Send("{tab}");}}). Unknown nonblank opens
MS_HELP listing company/session-location books ordered by BOOK_NAME with no APR-family restriction
(RP_ALL.cs:7303 {{ORDER BY A.BOOK_NAME}}; RP_ALL.cs:7309 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}).
Selection fills code and name and focus stays on Book (RP_ALL.cs:7314 {{tBookCode.Text = DC_Main.ColValue[1];}};
RP_ALL.cs:7315 {{tBookName.Text = DC_Main.ColValue[0];}}; RP_ALL.cs:7317 {{((Control)tBookCode).Focus();}}).
Gap 9.
Status: executable

### approval-report.lookup.party-enter-and-branch-setting   (T04 Lookup)
Layer: browser
Steps: 1. Seed party 050 (<100, loc 01), P1/P2/P3 (≥200, loc 01), P4 (≥200, loc 02). 2. As a location-02 user with MsAllBranchAcShow=N, press Enter on an unknown party. 3. Set MsAllBranchAcShow=Y and repeat. 4. Repeat as location 00.
Expected: Party Enter validates AC_MAST by company/code (RP_ALL.cs:7382 {{Select * From AC_MAST WHERE CO_CODE}});
unknown nonblank opens account help (RP_ALL.cs:7408 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}). With the
all-branch setting Y the help lists all company accounts (RP_ALL.cs:7386 {{if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)}}):
050, P1, P2, P3, P4. With N at a non-00 branch it unions codes below 100 with local codes ≥200
(RP_ALL.cs:7392 {{CAST(C.AC_CODE AS INT) < 100}}; RP_ALL.cs:7392 {{CAST(A.AC_CODE AS INT) >=200}};
RP_ALL.cs:7396 {{AND A.LC_CODE = '}}): location 02 sees 050 and P4 only, not P1/P2/P3. At 00 it uses local
accounts. Selection restores focus to Party (RP_ALL.cs:7416 {{((Control)tAcCode).Focus();}}); valid and blank
advance Tab (RP_ALL.cs:7422 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7427 {{SendKeys.Send("{tab}");}}). Gap 9.
Status: executable

### approval-report.lookup.product-enter   (T04 Lookup)
Layer: browser
Steps: 1. Focus Pr Code. 2. Enter a valid PR_CODE, an unknown code, then blank.
Expected: Product Enter matches PRODUCT_MAST.PR_CODE, not IT_CODE (RP_ALL.cs:7477 {{AND PR_CODE}}); unknown
nonblank opens help (RP_ALL.cs:7487 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}); selection fills code/name
and restores Product focus (RP_ALL.cs:7492 {{tItCode.Text = DC_Main.ColValue[1];}};
RP_ALL.cs:7493 {{tItName.Text = DC_Main.ColValue[0];}}; RP_ALL.cs:7495 {{((Control)tItCode).Focus();}}); a valid
code tabs (RP_ALL.cs:7501 {{SendKeys.Send("{tab}");}}); blank jumps directly to City
(RP_ALL.cs:7506 {{((Control)cboCity).Focus();}}). Gap 9.
Status: executable

### approval-report.lookup.group-enter   (T04 Lookup)
Layer: browser
Steps: 1. Focus Gr Code. 2. Enter an unknown code, then blank, then a valid code.
Expected: Group Enter uses GROUP_MAST (RP_ALL.cs:9265 {{Select * From GROUP_MAST}}) and opens help even on an
unmatched blank (RP_ALL.cs:9277 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}); selection fills group/name
and SelectAll stays on the code (RP_ALL.cs:9282 {{tGrCode.Text = DC_Main.ColValue[1];}};
RP_ALL.cs:9283 {{tGrName.Text = DC_Main.ColValue[0];}}; RP_ALL.cs:9285 {{((TextBoxBase)tGrCode).SelectAll();}});
valid advances Tab (RP_ALL.cs:9291 {{SendKeys.Send("{tab}");}}). Gap 9.
Status: executable

### approval-report.lookup.location-enter   (T04 Lookup)
Layer: browser
Steps: 1. As a location-00 user (editable lc), focus lc Code. 2. Enter an unknown code, pick from help; then a valid code; then blank.
Expected: Location Enter uses LOCT_MAST (RP_ALL.cs:7691 {{Select * From LOCT_MAST}}); unknown nonblank opens help
(RP_ALL.cs:7703 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}) and a non-cancelled selection fills code/name
(RP_ALL.cs:7704 {{if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)}};
RP_ALL.cs:7706 {{tLcCode.Text = DC_Main.ColValue[0];}}; RP_ALL.cs:7707 {{tLcName.Text = DC_Main.ColValue[1];}});
valid or blank advances Tab (RP_ALL.cs:7713 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7718 {{SendKeys.Send("{tab}");}}).
Gap 9.
Status: executable

### approval-report.lookup.cancel-and-stale   (T04 Lookup)
Layer: browser
Steps: 1. Open party help on an unknown code and cancel it. 2. Fire two lookups quickly so the first response arrives after the second.
Expected: cancelling help leaves the field unchanged — the fill is guarded by `!DC_Main.HelpClose`
(RP_ALL.cs:7704 {{if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)}}). A
stale lookup response never overwrites a newer selection (playbook T04; the web must reject out-of-order
results). No dead field: every lookup either fills or leaves the prior value. Gap 9.
Status: executable

## T05 Children

### approval-report.grouping.issue-voucher-party-bands   (T05 Children)
Layer: database
Steps: 1. Seed V1 (P1, two lines) and V2 (P2, one line). 2. Run Issue. 3. Read the band nesting and row order.
Expected: AprPartyWise groups AC_CODE → Group=CO_YEAR+CO_BOOK+VCH_NO, then sorts SR_NO
(RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}; `extraction_output/rpt_xml/AprPartyWise.xml:252` (`<Groups>`);
`extraction_output/rpt_xml/AprPartyWise.xml:256` (`<SortFields>`); the group key is
`extraction_output/rpt_xml/AprPartyWise.xml:268` (`{APR_DETL.CO_YEAR}+{APR_DETL.CO_BOOK}+{APR_DETL.VCH_NO}`)).
Voucher header and detail rows, voucher footer then Party Total; no grand-total fields. P1's two lines stay
under V1/P1, P2's line under V2/P2 — no row moves to the wrong party. The web sorts date/book/voucher/serial
flat (reportFamilyReports.ts:394). Gap 6.
Status: executable

### approval-report.grouping.inout-party-product-date-tag   (T05 Children)
Layer: database
Steps: 1. Seed V1, V2. 2. Run InOut. 3. Read the band nesting and row order.
Expected: AprInOut groups AC_CODE → PR_CODE → OpDate=VCH_DATE → Group=TAG_NO, then sorts VCH_DATE
(RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}; `extraction_output/rpt_xml/AprInOut.xml:271` (`<Groups>`);
`extraction_output/rpt_xml/AprInOut.xml:277` (`<SortFields>`)). Product header sums, numeric details, tag footer
sums, Party Total and Grand Total. P1/PR1 holds V1L1, P1/PR2 holds V1L2, P2/PR1 holds V2L1; each line stays
under its own party/product/date/tag. Gap 6.
Status: executable

### approval-report.grouping.pending-voucher-product-tag   (T05 Children)
Layer: database
Steps: 1. Seed V1, V2. 2. Run Pending. 3. Read the band nesting and row order.
Expected: AprPan groups AC_CODE → VchGroup=CO_YEAR+CO_BOOK+VCH_NO → PR_CODE → Group=TAG_NO, then sorts SR_NO
(RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}; `extraction_output/rpt_xml/AprPan.xml:310` (`<Groups>`);
`extraction_output/rpt_xml/AprPan.xml:316` (`<SortFields>`)). Voucher header, product header sums, numeric
details, tag footer sums, Party Total and Grand Total. Gap 6.
Status: executable

### approval-report.grouping.repeated-blank-tags   (T05 Children)
Layer: database
Steps: 1. Seed V9 (party P3, two lines both TAG_NO 'N', 1 pc and 2 pcs, ISU_REC N). 2. Run InOut and Pending.
Expected: the two lines share one tag group 'N' with a single footer summing both: InOut tag 'N' Out 1+2=3,
In 0, Pan 3; Pending tag 'N' PanPcs 3. Two detail rows print under one footer — row identity is retained for
the sums, not one row per tag (study §Lifecycle). The same holds for repeated blank tags. Gap 5.
Status: executable

### approval-report.grouping.duplicate-master-no-amplification   (T05 Children)
Layer: database
Steps: 1. Seed V1, V2. 2. Add a second ITEM_MAST row sharing CO_CODE+IT_CODE with I1 (a duplicate master). 3. Run Issue, InOut, Pending.
Expected: each issue line is counted once; totals are unchanged from the no-duplicate run (V1L1 still 1 pc,
grand Out still 6). The desktop templates left-outer link APR_DETL to ITEM_MAST by CO_CODE+IT_CODE
(`extraction_output/rpt_xml/AprPartyWise.xml:12` (`<TableLinks>`); RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}),
which would amplify on a duplicate; per the standing rule the web chooses safe unique join keys so a hosted
service stays correct. The web's ordinary Issue/Pending joins (reportFamilyReports.ts:378–386) amplify today;
InOut's lateral single-master join does not. If the schema forbids the duplicate, record that constraint as the
safe-join evidence. Gap 12.
Status: executable

### approval-report.grouping.null-tag-footer   (T05 Children)
Layer: database
Steps: 1. Seed a line with TAG_NO NULL. 2. Run InOut/Pending. 3. Read the tag footer rendering.
Expected: the tag group for a NULL tag renders per Crystal's runtime null-default/group-sort semantics.
Status: blocked: MISSING generated Crystal SQL and runtime null-default/group-sort semantics (study open
question 2). Exact question: how does a NULL (vs blank vs 'N') TAG_NO render and group in the tag footer at
runtime? Unblocks: original-Windows runtime evidence or an owner decision on null-tag grouping. The repeated
blank/N grouping is covered by grouping.repeated-blank-tags; this case is only the NULL rendering.

## T06 Required/invalid

### approval-report.invalid.date-not-valid   (T06 Required/invalid)
Layer: browser
Steps: 1. Type day 32 in From (32/07/2026). 2. Press Enter.
Expected: exactly `Date Not Valid...`; RongDate is set, the mask becomes `__/__/____` and the field SelectAlls,
so it does not advance (DC_Main.cs:1643 {{RongDate = true;}}; DC_Main.cs:1644 {{Interaction.MsgBox((object)"Date Not Valid...", (MsgBoxStyle)0, (object)null);}};
DC_Main.cs:1645 {{MsDate.Text = "__/__/____";}}; DC_Main.cs:1646 {{((TextBoxBase)MsDate).SelectAll();}}; the day
check is DC_Main.cs:1669 {{if (Conversion.Val(Strings.Mid(MsDate.Text, 1, 2)) > 31.0)}}; the form tabs only when
RongDate is false, RP_ALL.cs:7519 {{if (!DC_Main.RongDate)}}). Gap 9.
Status: executable

### approval-report.invalid.month-not-valid   (T06 Required/invalid)
Layer: browser
Steps: 1. Type month 13 in To (10/13/2026). 2. Press Enter.
Expected: exactly `Month Not Valid...`; mask `__/__/____`, SelectAll, no advance
(DC_Main.cs:1664 {{Interaction.MsgBox((object)"Month Not Valid...", (MsgBoxStyle)0, (object)null);}};
DC_Main.cs:1665 {{MsDate.Text = "__/__/____";}}; DC_Main.cs:1666 {{((TextBoxBase)MsDate).SelectAll();}}; the month
check is DC_Main.cs:1676 {{else if (Conversion.Val(Strings.Mid(MsDate.Text, 3, 2)) > 12.0)}}). Gap 9.
Status: executable

### approval-report.invalid.setdate-completion   (T06 Required/invalid)
Layer: browser
Steps: 1. With company year 2026-27, MsAlterYear=N, non-UAE, today 15/07/2026, enter each partial date and press Enter. 2. Repeat the year variants with MsAlterYear=Y and with country UAE.
Expected: SetDate completes missing parts using today and the financial-year convention. Year blank, month ≥ 4:
`10/07/____` → 10/07/2026 (left year); month < 4: `10/02/____` → 10/02/2027 (right year)
(DC_Main.cs:1594 {{FnYear = Conversions.ToString(Interaction.IIf(Conversion.Val(Strings.Mid(MsDate.Text, 4, 2)) < 4.0, (object)Strings.Right(MCo_year, 4), (object)Strings.Left(MCo_year, 4)));}};
DC_Main.cs:1626 {{MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(MsDate.Text, 4, 2) + "/" + FnYear;}}).
With MsAlterYear=Y the year is first year + 1 before April, else first year: `10/02/____` → 10/02/2027,
`10/07/____` → 10/07/2026 (DC_Main.cs:1577 {{if (Operators.CompareString(MsAlterYear, "Y", false) == 0)}};
DC_Main.cs:1581 {{FnYear = Conversions.ToString(Interaction.IIf(Conversion.Val(Strings.Mid(MsDate.Text, 4, 2)) < 4.0, (object)(Conversions.ToDouble(Strings.Left(MCo_year, 4)) + 1.0), (object)Strings.Left(MCo_year, 4)));}}).
UAE always uses the first year: `10/02/____` → 10/02/2026 (DC_Main.cs:1588 {{else if (Operators.CompareString(MCo_SName, "UAE", false) == 0)}};
DC_Main.cs:1590 {{FnYear = Strings.Left(MCo_year, 4);}}). Both day and month missing → today's day/month with
FnYear, 15/07/2026 (DC_Main.cs:1608 {{MsDate.Text = DateAndTime.Today.Day.ToString("00") + "/" + DateAndTime.Today.Month.ToString("00") + "/" + FnYear;}}).
A single entered digit (e.g. `5`) sets RongDate and returns without a message; the field does not tab
(DC_Main.cs:1600 {{if (i == 2)}}; DC_Main.cs:1602 {{RongDate = true;}}). From/To tab only when RongDate is false
(RP_ALL.cs:7517 {{DC_Main.SetDate(ref MsDate);}}; RP_ALL.cs:7521 {{SendKeys.Send("{tab}");}};
RP_ALL.cs:7533 {{DC_Main.SetDate(ref MsDate);}}; RP_ALL.cs:7537 {{SendKeys.Send("{tab}");}}). Gap 9.
Status: executable

### approval-report.invalid.reversed-range-empty   (T06 Required/invalid)
Layer: database
Steps: 1. Seed V1, V2. 2. Run Issue From 12/07/2026 To 10/07/2026 (valid but reversed).
Expected: the selection conjuncts inclusive endpoints (RP_ALL.cs:8152 {{AND {APR_DETL.VCH_DATE} >= #}};
RP_ALL.cs:8227 {{AND {APR_DETL.VCH_DATE} <= #}}), so `>= 12/07 AND <= 10/07` is unsatisfiable: an empty report
with zero totals and the title carrying the reversed dates, no crash and no validation message (no handler
checks From ≤ To, study §Rules). Per D7 the web returns an empty selection; today it throws
ReportValidationError (reportFamilyReports.ts:26–29) — wrong. Gap 2.
Status: executable

### approval-report.invalid.empty-period   (T06 Required/invalid)
Layer: database
Steps: 1. Seed no vouchers in 01/01/2010..15/07/2026 for the scope. 2. Run each mode.
Expected: each handler previews unconditionally with no empty-result check (RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}};
RP_ALL.cs:8276 {{Module_Save.ShowReportPreview();}}; RP_ALL.cs:8351 {{Module_Save.ShowReportPreview();}}): an
empty report with zero totals (InOut/Pending) or no rows and no grand total (Issue), no error message.
Status: executable

### approval-report.invalid.malformed-date-safe   (T06 Required/invalid)
Layer: database
Steps: 1. Send a request with an impossible date that bypassed Enter (e.g. from=2026-02-31).
Expected: the desktop converts on click with no error guard and may throw (RP_ALL.cs:8152 {{Conversions.ToDate(mFromDt.Text)}});
that is a weakness not to port. The web refuses safely with a validation response — no 500, no partial output,
and no invented desktop message text (study §Rules: do not invent a validation message). Safe date parsing
preserves the verified texts of the Enter path (D7).
Status: executable

## T07 Create

### approval-report.source.issue-appears-in-three-modes   (T07 Create)
Layer: browser
Steps: 1. Through the real Approval Issue screen, create V1 (party P1, two lines). 2. Run Issue, InOut, Pending.
Expected: the new issue appears in all three modes: Issue prints the stored line values (V1L1 1 pc / 10.500 /
10.000 / 500.00 / 50.00 / 10.00 / 560.00); InOut shows Out 3 In 0 Pending 3 for P1; Pending selects the lines
because ISU_REC='N' (RP_ALL.cs:8302 {{AND {APR_DETL.ISU_REC} = 'N'}}). The report itself writes nothing — the
footprint is the writer's, queried after the browser save (playbook T07). Gap 11.
Status: executable

## T08 Reopen/no-op

### approval-report.reopen.none   (T08 Reopen/no-op)
Layer: n/a
Expected: the report persists no document to reopen; the handlers finish in preview/Cr.Action, not database
statements (RP_ALL.cs:8141-8215 {{Module_Save.ShowReportPreview();}}).
Status: N/A: a read/preview workflow has no saved report document; re-run identity is covered by
retry.duplicate-run-idempotent (T13) and the lifecycle by T18.

## T09 Edit

### approval-report.edit.none   (T09 Edit)
Layer: n/a
Expected: the report edits no owned field; master edits after an issue are a history effect, not a report edit.
Status: N/A: no report write set (study §Lifecycle); the live-master rename effect is covered by
history.live-master-names (T15).

## T10 Delete/cancel/reverse

### approval-report.cancel.clear-data   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Fill several selectors and dates. 2. Click Cancel. 3. Read every control and run a report.
Expected: Cancel calls CLEAR_DATA (RP_ALL.cs:7273 {{CLEAR_DATA();}}), which clears top-level TextBoxes
(RP_ALL.cs:7215 {{if (val is TextBox)}}; RP_ALL.cs:7217 {{val.Text = "";}}) and resets MaskedTextBoxes to the mask
(RP_ALL.cs:7219 {{else if (val is MaskedTextBox)}}; RP_ALL.cs:7221 {{val.Text = DC_Main.MMask;}}) without
resetting the combos or reapplying the location/date defaults. Per D9 the web must still enforce session
location/tenant scope server-side after a clear — the locked location (RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}})
is never widened by clearing it.
Status: executable

### approval-report.actions.save-delete-print-noop   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Click Save, Delete and the bottom Print on the report page. 2. Query the write set.
Expected: the desktop Save/Delete property setters attach no click handlers (RP_ALL.cs:521 {{_BtnDelete = value;}};
RP_ALL.cs:565 {{_BtnSave = value;}}) and the bottom Print handler is empty
(RP_ALL.cs:7267-7270 {{private void BtnPrint_Click(object sender, EventArgs e)}}): no report save/delete/write
operation exists. The web offers no save/delete that writes; printing happens from the preview/output controls,
not a no-op bottom button. Exit closes the form (RP_ALL.cs:7230 {{((Form)this).Close();}}).
Status: executable

## T11 Scope/rights

### approval-report.scope.tenant-company-location-sentinels   (T11 Scope/rights)
Layer: database
Steps: 1. Seed sentinel issue lines in another tenant, another company, and location 02 (V3). 2. Call the API directly with those scopes and with a cleared location box.
Expected: company always applies (RP_ALL.cs:8152 {{{APR_DETL.CO_CODE} = '}}) and location applies when nonblank
(RP_ALL.cs:8156 {{And {APR_DETL.LC_CODE}}}); the session location is enforced even if the client clears lc
(the locked box, RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}; D9). No sentinel row appears in rows,
totals or exports; cross-tenant/company calls are denied server-side. Gap 12.
Status: executable

### approval-report.scope.year-scope   (T11 Scope/rights)
Layer: database
Steps: 1. Seed V4 in year 2025-26 and V1 in 2026-27. 2. Run all modes as a 2026-27 session.
Expected: only 2026-27 rows return; V4 is excluded. Per D4 the web keeps the session-year filter
(reportFamilyReports.ts:52–54) to reproduce the desktop's implicit per-year database isolation; the desktop
formula's missing CO_YEAR predicate (RP_ALL.cs:8152 {{{APR_DETL.CO_CODE} = '}}) is a documented difference, and
cross-year custody equivalence is not claimed. Gap 12.
Status: executable

### approval-report.scope.view-print-rights   (T11 Scope/rights)
Layer: database
Steps: 1. As a user with view but no print right, run the report and request CSV/XLSX/PDF. 2. As a user with no view right, call the API.
Expected: desktop reads FRM_EDIT/FRM_DELETE/FRM_PRINT (RP_ALL.cs:6775 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));}};
RP_ALL.cs:6776 {{UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));}};
RP_ALL.cs:6777 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}})
but never refuses preview (RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}}). Per D10 the web keeps the
guards: no view right → 403 (MDI_FORM.cs:7041 {{AND FRM_VIEW = 'Y'}}); no print right → CSV/XLSX/PDF refused
(txn.ts:4412 enforces print). The desktop's unused UserPrint is a weakness, not permission to omit the guard.
Status: executable

## T12 Concurrency

### approval-report.concurrency.request-local-state   (T12 Concurrency)
Layer: database
Steps: 1. Session A runs Issue with party P1; session B runs Pending with party P2, concurrently. 2. Compare each response's mode, title and rows.
Expected: each response carries its own selection and title; A gets P1 issue rows, B gets P2 pending rows, no
cross-contamination. The desktop's shared global report state (RP_ALL.cs:6658 {{CurRpt = DC_Main.MsUserRightForm;}};
RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}}) is a weakness not to port; the web uses request-local
inputs (study §Desktop weaknesses).
Status: executable

### approval-report.concurrency.run-during-resolution   (T12 Concurrency)
Layer: database
Steps: 1. Session A runs Pending. 2. Session B saves return V6 resolving V1L1 (ISU_REC Y). 3. Read A's result and B's write set.
Expected: A sees a consistent snapshot — V1L1 either present (P1 pending 3) or absent (P1 pending 2), never a
torn row; B's return commits fully (TR_APR_ISU.cs:6414 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}}). No lost
update and no double resolution.
Status: executable

## T13 Retry/unknown

### approval-report.retry.duplicate-run-idempotent   (T13 Retry/unknown)
Layer: database
Steps: 1. Run GET /reports/approval-report?mode=inout twice and duplicate an export request. 2. Compare rows/totals and the APR_DETL write counts.
Expected: identical rows and totals on every run; no financial effect anywhere — the handlers only preview
(RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}}), so a duplicate or lost-acknowledgment retry changes
nothing durable. Write-set counts before and after are equal.
Status: executable

## T14 Rollback

### approval-report.rollback.none   (T14 Rollback)
Layer: n/a
Expected: the three handlers end in preview or Crystal Action, not database statements
(RP_ALL.cs:8141-8215 {{Module_Save.ShowReportPreview();}}; RP_ALL.cs:8216-8290 {{Cr.Action = -1;}};
RP_ALL.cs:8291-8365 {{Cr.Action = -1;}}).
Status: N/A: no write set to roll back; a failed run leaves no partial output and unrelated sentinels intact,
covered by retry.duplicate-run-idempotent (T13) and scope.tenant-company-location-sentinels (T11).

## T15 Config/history

### approval-report.history.live-master-names   (T15 Config/history)
Layer: database
Steps: 1. Create V1. 2. Rename party P1's AC_NAME and book 018's BOOK_NAME. 3. Re-run Issue.
Expected: the template bands bind live master fields — Party_Name from AC_MAST.AC_NAME
(`extraction_output/rpt_xml/AprPartyWise.xml:571` (`DataSource="{AC_MAST.AC_NAME}"`)) and book from
BOOK_DATA.BOOK_NAME (`extraction_output/rpt_xml/AprPartyWise.xml:608` (`DataSource="{BOOK_DATA.BOOK_NAME}"`)),
selected by RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}. After the rename the report shows the new
names, not the APR_DETL snapshot. The web prefers snapshot book/party names
(reportFamilyReports.ts:295–296, 366–368) — wrong today. Gap 7.
Status: executable

### approval-report.history.setting-between-runs   (T15 Config/history)
Layer: browser
Steps: 1. With MsAllBranchAcShow=N at location 01, open party help. 2. Switch the setting to Y and reopen help. 3. Add a party with a new city C3 and reopen the City list.
Expected: the lookup reflects the current setting — N lists local accounts, Y lists all company accounts
(RP_ALL.cs:7386 {{if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)}}); the City list gains
C3 because it reads distinct live master values (RP_ALL.cs:7087 {{SELECT AC_CITY FROM AC_MAST WHERE CO_CODE}}).
The report selection uses only the typed values, with no hidden global default leaking in (study §Desktop
weaknesses: request-local inputs).
Status: executable

## T16 Report/output

### approval-report.output.issue-layout-and-title   (T16 Report/output)
Layer: browser
Steps: 1. Run Issue From 01/01/2010 To 15/07/2026. 2. Read the title, column order and page furniture.
Expected: title exactly `Party Wise Approval Issue From 01/01/2010 To 15/07/2026`
(RP_ALL.cs:8197 {{DC_Main.MsRptTitelStr = "'Party Wise Approval Issue From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";}}),
template AprPartyWise.RPT (RP_ALL.cs:8150 {{Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AprPartyWise.RPT";}}).
Columns left-to-right: Vch No, Date, Party_Name, Tag No, Pcs, Gr Wt, Net Wt, ItmAmt, Lbr Amt, Oth Amt, BillAmt
(study §Print, XML Section4). A4 portrait, company name/address, supplied title, page number
(`extraction_output/rpt_xml/AprPan.xml:6` (`PaperOrientation="Portrait"`)); no grand-total band. The web omits
the desktop title/date phrase (reportFamilyReports.ts:243–245). Gaps 5, 8.
Status: executable

### approval-report.output.inout-layout-and-title   (T16 Report/output)
Layer: browser
Steps: 1. Run InOut over the same dates. 2. Read the title, columns and hidden bands.
Expected: title exactly `Approval In Out Report From 01/01/2010 To 15/07/2026`
(RP_ALL.cs:8272 {{DC_Main.MsRptTitelStr = "'Approval In Out Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";}}),
template AprInOut.RPT (RP_ALL.cs:8225 {{Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AprInOut.RPT";}}).
Columns: Vch No, Date, Party_Name, Pcs, Gr Wt, Net Wt, Oth Amt, Out Pcs, In Pcs, Panding (study §Print). InOut
hides its date and tag headers and date/product footers (study §Lifecycle;
`extraction_output/rpt_xml/AprInOut.xml:797` (`{@ReportType} = 'S'`)). Gaps 5, 8.
Status: executable

### approval-report.output.pending-layout-and-title   (T16 Report/output)
Layer: browser
Steps: 1. Run Pending over the same dates. 2. Read the title, columns and hidden bands.
Expected: title exactly `Panding Approval Report From 01/01/2010 To 15/07/2026` — the desktop spelling "Panding"
(RP_ALL.cs:8347 {{DC_Main.MsRptTitelStr = "'Panding Approval Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";}}),
template AprPan.RPT (RP_ALL.cs:8300 {{Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AprPan.RPT";}}).
Columns: Vch No, Date, Tag No, Design, It Code, Item Name, Pcs, Gr Wt, Net Wt, Oth Amt, Panding (study §Print).
Pending hides its tag header and product/voucher footers (study §Lifecycle). The button caption is
`&Approval Panding` (RP_ALL.cs:5217 {{BtnAprPanding.Text = "&Approval Panding";}}). Gap 8.
Status: executable

### approval-report.output.grid-csv-xlsx-pdf-match   (T16 Report/output)
Layer: browser
Steps: 1. Seed enough lines to span more than one page. 2. Run each mode and export CSV, XLSX and PDF. 3. Compare grid, exports and print.
Expected: grid, CSV, XLSX and PDF show the same rows and totals in desktop column order and captions across
pages, with the exact mode titles. Exports enforce the print right (txn.ts:4412); the PDF uses the approval
template layout, not generic property-key output (the web's generic reportPdf at txn.ts:4444 is wrong today).
Template authority: RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}; RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}};
RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}. Gaps 5, 8.
Status: executable

### approval-report.output.preview-window   (T16 Report/output)
Layer: browser
Steps: 1. Run a mode. 2. Read the preview window chrome.
Expected: the shared new preview loads Report/RptName.rpt, assigns title and selection and opens a maximized
window titled `Report Preview - <RptName>` (Module_Save.cs:230 {{val.Load(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + DC_Main.RptName + ".rpt");}};
Module_Save.cs:269 {{val.DataDefinition.FormulaFields[DC_Main.MsRptTitel].Text = DC_Main.MsRptTitelStr;}};
Module_Save.cs:354 {{val.RecordSelectionFormula = DC_Main.RptFormula;}};
Module_Save.cs:362 {{Text = "Report Preview - " + DC_Main.RptName,}}; Module_Save.cs:363 {{WindowState = (FormWindowState)2}}),
with no group-tree tool panel (Module_Save.cs:367 {{val3.ToolPanelView = (ToolPanelViewType)0;}};
Module_Save.cs:368 {{val3.ReportSource = val;}}). The desktop preview also creates Send WhatsApp / Send Email
buttons (Module_Save.cs:378 {{Text = "Send WhatsApp",}}; Module_Save.cs:385 {{Text = "Send Email",}}); those
outbound actions are not operated here (Not covered).
Status: executable

### approval-report.output.numeric-display-precision   (T16 Report/output)
Layer: browser
Steps: 1. Run a mode with values that exercise decimal ties. 2. Read the printed numeric format.
Expected: the printed decimal places and tie handling of the three templates.
Status: blocked: MISSING Crystal numeric display rounding/decimal metadata and original-Windows output (study
open question 1; D1). Exact question: what precision/tie handling do AprPartyWise, AprInOut and AprPan actually
print? Unblocks: an original-Windows render or extracted numeric ObjectFormat metadata. Computation precision
is covered by formula.precision-preserved; the web toFixed(3/2) is not certified as desktop precision.

### approval-report.output.drilldown   (T16 Report/output)
Layer: browser
Steps: 1. Open a report row in the preview. 2. Attempt to drill into the source voucher.
Expected: the desktop approval buttons wire no custom voucher/ledger drill-down; they open the generic Crystal
viewer (RP_ALL.cs:8276 {{Module_Save.ShowReportPreview();}}; Module_Save.cs:367 {{val3.ToolPanelView = (ToolPanelViewType)0;}}).
Status: blocked: MISSING runtime proof of Crystal built-in drill-down interactions (study open question 2; D2).
Exact question: does the generic Crystal viewer drill into vouchers at runtime, and how? Unblocks:
original-Windows runtime evidence. Do not claim a desktop voucher-navigation flow from a web link alone.

## T17 Keyboard/usability

### approval-report.keyboard.enter-walk-and-tab-order   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Open the page. 2. Walk the selectors with Enter/Tab at a supported viewport. 3. Focus each date field.
Expected: tab order is From 0, To 1, lc 2, Book 3, Pr 4, Gr 5, Party 6, Cust Name 7, City 8, Area 9, Item Type 10
(RP_ALL.cs:5622 {{((Control)mFromDt).TabIndex = 0;}}; RP_ALL.cs:5614 {{((Control)mToDt).TabIndex = 1;}};
RP_ALL.cs:4918 {{((Control)tLcCode).TabIndex = 2;}}; RP_ALL.cs:4782 {{((Control)tBookCode).TabIndex = 3;}};
RP_ALL.cs:4878 {{((Control)tItCode).TabIndex = 4;}}; RP_ALL.cs:5630 {{((Control)tGrCode).TabIndex = 5;}};
RP_ALL.cs:4816 {{((Control)tAcCode).TabIndex = 6;}}; RP_ALL.cs:5795 {{((Control)tCustName).TabIndex = 7;}};
RP_ALL.cs:4842 {{((Control)cboCity).TabIndex = 8;}}; RP_ALL.cs:4861 {{((Control)cboArea).TabIndex = 9;}};
RP_ALL.cs:4902 {{((Control)cboItemTyp).TabIndex = 10;}}). Enter advances the dates only when valid
(RP_ALL.cs:7521 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7537 {{SendKeys.Send("{tab}");}}), City/Area/Item Type
send Tab (RP_ALL.cs:7548 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7558 {{SendKeys.Send("{tab}");}};
RP_ALL.cs:7568 {{SendKeys.Send("{tab}");}}), and Cust Name Enter clears and jumps to City
(RP_ALL.cs:9717 {{tCustName.Text = "";}}; RP_ALL.cs:9718 {{((Control)cboCity).Focus();}}). Both date fields
SelectAll on focus (RP_ALL.cs:9607 {{((TextBoxBase)mFromDt).SelectAll();}}; RP_ALL.cs:9612 {{((TextBoxBase)mToDt).SelectAll();}}).
High-index name boxes are not excluded from tabbing; key preview is on (RP_ALL.cs:6609 {{((Form)this).KeyPreview = true;}}).
Gap 9.
Status: executable

### approval-report.keyboard.form-keys   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Press Esc on the open page. 2. Type lowercase letters and an apostrophe into a code box.
Expected: Esc closes the form (RP_ALL.cs:7261 {{if ((int)e.KeyCode == 27)}}; RP_ALL.cs:7263 {{((Form)this).Close();}}).
KeyPress uppercases input (RP_ALL.cs:7248 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}})
and consumes character codes 0 and 39 (apostrophe) (RP_ALL.cs:7251 {{if (num == 0 || num == 39)}};
RP_ALL.cs:7253 {{e.Handled = true;}}): typing `abc'` yields `ABC`, the apostrophe never lands. No F-key or
Ctrl-combination handler exists in this form (study §Keyboard); F1 is not a desktop requirement. Gap 9.
Status: executable

### approval-report.keyboard.mnemonics   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Read the action captions. 2. Try the Alt mnemonics.
Expected: the ampersands supply Windows mnemonics: `&Approval Isu`, `&Approval InOut`, `&Approval Panding` all
share A (RP_ALL.cs:5165 {{btnAprRpt.Text = "&Approval Isu";}}; RP_ALL.cs:5191 {{btnAprInOut.Text = "&Approval InOut";}};
RP_ALL.cs:5217 {{BtnAprPanding.Text = "&Approval Panding";}}), so no unique Alt shortcut is invented for them.
Bottom buttons: `&Save` (RP_ALL.cs:4330 {{BtnSave.Text = "&Save";}}), `&Cancel` (RP_ALL.cs:4317 {{BtnCancel.Text = "&Cancel";}}),
`&Delete` (RP_ALL.cs:4303 {{BtnDelete.Text = "&Delete";}}), `E&xit` (RP_ALL.cs:4290 {{BtnExit.Text = "E&xit";}}),
`&Print` (RP_ALL.cs:4343 {{BtnPrint.Text = "&Print";}}). Gap 9.
Status: executable

## T18 Full journey

### approval-report.journey.issue-return-reopen   (T18 Full journey)
Layer: browser
Steps: 1. Seed tags T1, T2. 2. Through the UI create issue V1 (P1, two lines). 3. Run all three reports. 4. Through the UI save return V6 resolving V1L1. 5. Re-run. 6. Delete the return through the UI. 7. Re-run.
Expected: after issue, Issue P1 total Pcs 3 / ItmAmt 1300.00; InOut P1 Out 3 In 0 Pan 3; Pending P1 3. The return
resolves V1L1 by joining OLD_SRNO and setting ISU_REC='Y' (TR_APR_ISU.cs:6414 {{APR_DETL.OLD_SRNO = B.ISU_SRNO}};
TR_APR_ISU.cs:6414 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}}): InOut P1 Out 3 In 1 Pan 2; Pending P1 2
(V1L1 dropped, RP_ALL.cs:8302 {{AND {APR_DETL.ISU_REC} = 'N'}}); Issue unchanged (Pcs 3). Deleting the return
reopens V1L1 to N: Pending P1 3 again. The original issue line's stored pcs/weights/amounts never change — only
ISU_REC toggles. Gap 11.
Status: executable

### approval-report.journey.sale-consume-reverse   (T18 Full journey)
Layer: browser
Steps: 1. Seed tag T3. 2. Through the UI create issue V2 (P2, book 018, 3 pcs). 3. Through the Sales Invoice UI consume the approval tag. 4. Run InOut and Pending. 5. Reverse the sale through the UI. 6. Re-run.
Expected: the desktop sale consumes the approval line by joining SR_NO, restricted to book 018, setting
ISU_REC='Y' (TR_SALE.cs:16112 {{APR_DETL.SR_NO = B.ISU_SRNO}}; TR_SALE.cs:16112 {{AND APR_DETL.CO_BOOK = '018'}};
TR_SALE.cs:16112 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}}): InOut P2 Out 3 In 3 Pan 0; Pending P2 absent.
Reversing the sale reopens the line to N (the web reversal writes ISU_REC='N', sales.ts:2307): Pending P2 3
again. Per D6 the journey runs through the current web writer; the web sale path joins OLD_SRNO
(approvalSaleReferences.ts:100) rather than the desktop SR_NO/book-018 — that variant difference is recorded
explicitly in the evidence, not silently ported. No separate returned/billed fine-weight column is invented
(D5). Gap 11.
Status: executable

### approval-report.journey.custody-reconcile   (T18 Full journey)
Layer: database
Steps: 1. After the two journeys, query every original issue line. 2. Reconcile issued = pending + resolved pieces/weights. 3. Reconcile fine from the stored writer rows.
Expected: issued 6 pcs (V1 3 + V2 3) = pending 2 (V1L2) + resolved 4 (V1L1 returned 1 + V2 sold 3); gross
62.000 = pending 20.000 + resolved 42.000; net 59.000 = pending 19.000 + resolved 40.000. For the gold lines
(T1, T3) the stored ITM_FINE is 9.160 each, issued fine 2 × 9.160 = 18.320 — test-only evidence from the writer
rows, never a report column (D5; fine is absent from all three layouts, study §Calculations). All owners'
custody and the three reports agree end to end; the report templates are unaltered. Gap 11.
Status: executable

## Coverage table

| Kind | Cases | Blocked | Note |
|---|---|---|---|
| T01 Entry/defaults | 7 | 0 | caption, buttons, defaults, location lock, selector set, lists, view right |
| T02 Field route | 9 | 1 | data-type-setting-source blocked (D3); data-type-selection unit case executable |
| T03 Formula sequence | 6 | 0 | issue/inout/pending sums, suppression, precision |
| T04 Lookup | 6 | 0 | book, party+branch, product, group, location, cancel/stale |
| T05 Children | 6 | 1 | null-tag-footer blocked (D2); grouping, repeated tags, duplicate masters |
| T06 Required/invalid | 6 | 0 | date/month messages, SetDate, reversed range, empty period, malformed-safe |
| T07 Create | 1 | 0 | issue appears in three modes (report writes nothing) |
| T08 Reopen/no-op | 0 | 0 | N/A: no saved report document |
| T09 Edit | 0 | 0 | N/A: no report write set; master rename under T15 |
| T10 Delete/cancel/reverse | 2 | 0 | Cancel clear-data; save/delete/print no-op |
| T11 Scope/rights | 3 | 0 | sentinels, year scope, view/print rights |
| T12 Concurrency | 2 | 0 | request-local state; run during resolution |
| T13 Retry/unknown | 1 | 0 | duplicate run idempotent, no writes |
| T14 Rollback | 0 | 0 | N/A: no write set |
| T15 Config/history | 2 | 0 | live master names; setting between runs |
| T16 Report/output | 7 | 2 | numeric-display-precision (D1) and drilldown (D2) blocked |
| T17 Keyboard/usability | 3 | 0 | Enter walk/tab order, form keys, mnemonics |
| T18 Full journey | 3 | 0 | issue→return→reopen; sale consume→reverse; custody reconcile |

Total: 64 cases, 4 blocked, 3 N/A kinds (T08, T09, T14).

Gap coverage (every gap has at least one case that fails today, or a named blocked case):
1 `entry.date-defaults`; 2 `invalid.reversed-range-empty`; 3 `filters.pending-exact-n`;
4 `filters.data-type-selection` (executable unit) + `filters.data-type-setting-source` (blocked, D3);
5 `formula.issue-party-sums`, `formula.inout-sum-levels`, `formula.pending-signed-tags`,
`formula.pending-zero-footer-suppression`, `output.*`; 6 `grouping.issue-voucher-party-bands`,
`grouping.inout-party-product-date-tag`, `grouping.pending-voucher-product-tag`; 7 `history.live-master-names`;
8 `entry.three-approval-buttons`, `output.issue-layout-and-title`, `output.inout-layout-and-title`,
`output.pending-layout-and-title`, `output.grid-csv-xlsx-pdf-match`; 9 `lookup.*`, `keyboard.*`,
`invalid.date-not-valid`, `invalid.month-not-valid`, `invalid.setdate-completion`;
10 `entry.selector-set-and-hidden-controls`, `filters.ignored-selectors`, `filters.one-at-a-time`;
11 `source.issue-appears-in-three-modes`, `formula.inout-out-in-pending`, `filters.main-book-family`,
`journey.*`; 12 `grouping.duplicate-master-no-amplification`, `scope.year-scope`,
`filters.date-range-inclusive-and-year`, `scope.tenant-company-location-sentinels`.

## Test data

Smallest seed, described (no SQL). Fixed conventions: company 01, session location 01, year 2026-27,
MsSysDate 15/07/2026, MsAlterYear N, non-UAE, MsCrystalRptType N, MsDataType blank, MsAllBranchAcShow N unless a
case changes them. Reuse the approval writer fixtures (approvalHelpers.mjs) for tags and vouchers created
through the UI.

- **Scope sentinels:** a second tenant and a second company/location (02) each holding an approval issue line;
  a prior-year (2025-26) line V4. Users: one with view+print, one with view only, one with no view right.
- **Locations:** 01 (session), 02 (other), 00 (editable-lc user). **Books:** 018 = approval issue (MAIN_BOOK
  'APR ISU'); A2 = approval return ('APR RTN'); X1 = a non-approval book ('SALES'); a legacy provisioned book
  with MAIN_BOOK 'APPROVAL ISSUE' (V10); a sales book for the consume journey.
- **Parties:** P1 (city C1, area AR1), P2 (city C2, area AR2), P3 (city C1, area AR1), all codes ≥200 at
  location 01; party 050 (code <100, location 01); P4 (≥200, location 02); P5 (≥200, location 00) for the
  branch-setting lookup case.
- **Products/items/groups:** PR1/PR2 product masters; I1 (IT_TYPE G, GR_CODE G1, PR_CODE PR1), I2 (S, G2, PR2),
  I4 (R, for Real Stone); groups G1, G2. A duplicate ITEM_MAST row sharing CO_CODE+IT_CODE with I1 for the
  amplification case.
- **Tags:** T1, T2, T3 live BAR_DETL tags, 1 pc each, gross 10.500, net 10.000, touch 91.600, fine 9.160 (gold);
  T2 carries the silver item I2 for the 2-pc line. Untagged lines use TAG_NO 'N' (V9) and 'Z0' (V8); a NULL-tag
  line for the blocked case.
- **Vouchers** (book 018, location 01, year 2026-27 unless noted): V1 (P1, 10/07/2026) line 1 I1/T1 1 pc
  G10.500 N10.000 ItAmt500.00 Lbr50.00 Oth10.00 Net560.00 ISU_REC N, line 2 I2/T2 2 pcs G20.000 N19.000
  ItAmt800.00 Lbr80.00 Oth20.00 Net900.00 N; V2 (P2, 12/07/2026) I1/T3 3 pcs G31.500 N30.000 ItAmt1500.00
  Lbr150.00 Oth30.00 Net1680.00 N; V3 (P1, location 02, 11/07) 1 pc; V4 (P1, 2025-26, 15/06/2025) 1 pc; V5 (P1,
  book X1, 10/07) 1 pc; V6 = return resolving V1L1; V7 (P3, 13/07) five 1-pc lines G1.000 N0.900 Oth0.50 with
  ISU_REC null/blank/N/Y/R; V8 (P3, 14/07) two TAG_NO 'Z0' lines 0 pc Oth5.00 and 3.00 N; V9 (P3, 14/07) two
  TAG_NO 'N' lines 1 pc and 2 pcs N; V10 (P1, legacy APPROVAL ISSUE book, 10/07) 1 pc; V11 (09/07) and V12
  (13/07) 1 pc each for the date-boundary case; a line with OTH_AMT 0.005 for the precision case.
- **Settings variants:** MsAllBranchAcShow Y/N; MsAlterYear Y/N; country UAE; MsDataType A/B (blocked binding).

## Not covered

- **O-path Crystal plumbing** (Cr control, Destination=0, WindowState=2, PageZoom MsPrintZoom): delivery
  mechanics with business output identical to the N-path; the web implements the N-path result (D8).
  RP_ALL.cs:8143 {{if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)}};
  RP_ALL.cs:8208 {{Cr.Destination = (DestinationConstants)0;}}; RP_ALL.cs:8210 {{Cr.WindowState = (WindowStateConstants)2;}};
  RP_ALL.cs:8212 {{Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));}}.
- **Send WhatsApp / Send Email preview buttons:** outbound actions the study does not operate; no desktop
  business result proven here, separate menu/decision. Module_Save.cs:378 {{Text = "Send WhatsApp",}};
  Module_Save.cs:385 {{Text = "Send Email",}}.
- **MsPrintZoom value and viewer zoom:** a desktop display setting, not a business result; web viewer zoom is a
  usability choice. RP_ALL.cs:8212 {{Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));}}.
- **MDI open-form counter in the window caption:** desktop MDI plumbing; the web page carries the menu caption
  (entry.menu-caption-and-panel), the counter is not a business result. MDI_FORM.cs:8925 {{DC_Main.TotOpenForm++;}};
  MDI_FORM.cs:8926 {{((Form)rP_ALL5).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);}}.
- **Sales/Purchase/Order and other RP_ALL panels:** outside this packet (study §Scope).
  RP_ALL.cs:6676 {{if (Operators.CompareString(CurRpt, "Sales Report", false) == 0)}}.
- **Employee/state/multi-book/user-grouping selectors:** hidden for Approval, no approval behaviour to cover;
  their absence is asserted by entry.selector-set-and-hidden-controls.
  RP_ALL.cs:6400 {{((Control)cboEmploy).Visible = false;}}; RP_ALL.cs:6549 {{((Control)cboState).Visible = false;}};
  RP_ALL.cs:6539 {{((Control)chkBookSelect).Visible = false;}}.
- **Unused PurcTax/TotPurcTax running totals in AprInOut:** they refer to an empty PurcTax formula whose
  evaluation group is not extracted; no printed effect established, so no case until extraction evidence
  (study §Calculations). `extraction_output/rpt_xml/AprInOut.xml:337` (`FormulaName="{#PurcTax}"`).
- **Fine-weight report columns:** deliberately absent from all three layouts; custody fine reconciliation is
  test-only journey evidence (D5), not a report surface.
- **Runtime NULL-tag rendering and Crystal built-in drill-down:** covered as blocked cases
  (grouping.null-tag-footer, output.drilldown), not invented behaviour (D2).