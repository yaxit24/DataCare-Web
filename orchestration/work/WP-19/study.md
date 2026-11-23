# WP-19 study — Gst Report: the 12 blocked browser cases against the desktop source

Note on the count: the packet says 13 blocked cases. `web/apps/web/test/features/modules/gstReport.mjs` contains exactly
12 `blocked(` calls (lines 359, 382, 397, 458, 710, 811, 818, 895, 909, 916, 923, 998; the `const blocked` helper is at
line 46). There are 12 Gaps items below, one per call, numbered G1–G12. If a 13th case is meant, it is not in this file
on this branch (see Open questions).

## Scope

- Menu caption: "Gst Report" (`lblBook`), desktop form `RP_GST` (3,944 lines of C#; the form index says 3,945).
- Dispatch: `MDI_FORM.cs:8962-8966 {{RP_GST rP_GST = new RP_GST();}}` — the `else` branch of the caption chain after
  `rP_TAX`; the form takes no constructor argument, so there are no modes. Settings and edition change the form inside
  itself, not through the dispatch.
- Lite edition (`MsSoftType` = "L"): the GSTR-1 zoom and GSTR-3B zoom buttons do not run their on-screen grids; they
  hand over to the Crystal print buttons. `RP_GST.cs:2646-2650 {{if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)}}`
  then `BtnGstr1_Click(BtnGstr1, ...)`; `RP_GST.cs:3481-3485 {{BtnSave_Click(BtnSave, new EventArgs());}}`. So the
  on-screen sections (B2B … DOCS), the CSV buttons and the 3B grid belong to Basic and Standard, not Lite.
  Whether the web shows them to Lite is outside this study.
- UAE variant (`MCo_SName` = "UAE"): out of scope by the packet. It swaps the section list for "With Tax" / "Whout Tax":
  `RP_GST.cs:1648-1651 {{cboSectionType.Items.Add((object)"With Tax");}}`.
- In scope: the 12 blocked cases — EXP, EXEMP, DOCS sections, GSTR-3B completeness, the date helper `SetDate`, no-write
  failure behaviour, EXP/DOCS CSV, malformed CSV, the all-sections workbook, and TCS.
- Out of scope: the 57 passing cases (except where a fix would change them — each is named in Gaps), Crystal print
  layouts of `Gstr_1.RPT`/`Gstr_3.RPT` content, the UAE branch.

## Screen

Section list (cboSectionType, index = section number used by every `switch`):
`RP_GST.cs:1662-1673 {{cboSectionType.Items.Add((object)"B2B - Bill to Bill");}}`, then B2CL, B2CS, CDNR, CDNUR,
`RP_GST.cs:1668 {{cboSectionType.Items.Add((object)"EXP - Export");}}`, AT, ATADJ,
`RP_GST.cs:1671 {{cboSectionType.Items.Add((object)"EXEMP - Intra-State Supp to Unreg persons");}}`, HSN, and
`RP_GST.cs:1673 {{cboSectionType.Items.Add((object)"DOCS - Summary Of Issue Rec Bill");}}`. Index 0 is the empty item.

Buttons (captions): `RP_GST.cs:1155 {{BtnSave.Text = "Gstr 3";}}`, `RP_GST.cs:1168 {{BtnPrint.Text = "Gstr 2";}}`,
`RP_GST.cs:1181 {{BtnGstr1.Text = "Gstr 1";}}`, `RP_GST.cs:1194 {{Csv Fil}}` (typo is the desktop's), `RP_GST.cs:1435 {{Gsrt1 Csv}}`
(the all-sections Excel button). Zoom buttons: Gstr 1 / Gstr 2 / Gstr 3 (lines 1340, 1366, 1392). Other labels:
Book, From  Date, Party Code, Section Type, Lc Code, To Date (lines 1236-1417 of the form index).
Date boxes `mFromDt` / `mToDt` are masked "dd/MM/yyyy"; on load: `RP_GST.cs:1714-1715 {{mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);}}`
and `mToDt.Text` is today. The grid `MSG_VCH` is an MSFlexGrid with 19 columns; the first 15 are display columns, 15-18
are hidden key columns (width 0). Tab order and enabled/visible flags are in the designer (905-1473) and were not
needed for the 12 cases; see Open questions.

Grid result shape (all sections): rows 0-2 are title/group rows, row 3 is the column-caption row, data starts at row 4
(`DC_Main.i = 4`, `RP_GST.cs:2738 {{DC_Main.i = 4;}}`). `DGV_CLEAR` sets `Rows = 5` and hides every column, then each
section branch shows its own columns: `RP_GST.cs:2213-2218 {{mSG_VCH.Rows = 5;}}`.

## Keyboard

- Any key: upper-cased, and NUL and apostrophe are swallowed: `RP_GST.cs:1733-1746 {{if (num == 0 || num == 39)}}`.
- Esc closes the form: `RP_GST.cs:1750-1755 {{if ((int)e.KeyCode == 27)}}` → `Close()`.
- Enter in Book code / Party code / Lc code: look the code up (`tBookCode_KeyDown` 1837-1880, `tAcCode_KeyDown` 1885-1944,
  `tLcCode_KeyDown` 1945-1986); each reads one master table (BOOK_DATA, AC_MAST/AC_GROUP, LOCT_MAST). Not needed here.
- Enter in the section combo moves on: `RP_GST.cs:1987-1996 {{SendKeys.Send("{tab}");}}`.
- Enter in From / To date calls `SetDate`, and moves to the next control only when the date is valid:
  `RP_GST.cs:3035-3044 {{DC_Main.SetDate(ref MsDate);}}` and `RP_GST.cs:3042 {{if (!DC_Main.RongDate)}}` then `SendKeys.Send("{tab}")`.
  The To-date handler is identical (3049-3063).
- Date boxes select all their text on focus: `RP_GST.cs:3065-3076 {{SelectionLength = Strings.Len(mFromDt.Text);}}`.
- No F-key, Ctrl or Alt handling exists in this form.

## Rules

- No section chosen: `RP_GST.cs:2657 {{Please Select Section Type And Try...}}`; focus returns to the combo:
  `RP_GST.cs:2658 {{((Control)cboSectionType).Focus();}}`. (Raised after `DGV_CLEAR`, which only clears when index ≠ 0.)
- Empty result: `RP_GST.cs:2726-2733 {{No Record Found....}}`, focus to From date. Both are skipped while
  `bExportingAll` is true (2727, 2731). The GSTR-2 zoom has its own copies at 3185 and 3250.
- CSV success: `RP_GST.cs:3144 {{File is Generate...}}`.
- Excel failure: `RP_GST.cs:3925-3935 {{Error Exporting to Excel: }}`.
- Date messages come from `DC_Main.SetDate` (see Gaps G5): "Date Not Valid..." and "Month Not Valid...".
- There is no From > To check anywhere in the form; the query simply returns nothing and "No Record Found...." appears.

## Calculations

Only what the 12 cases need.

GSTR-1 sections 7 (AT) and 8 (ATADJ) are `Sum(A.NET_AMT)` grouped by state, tax code, rate, with `SR_NO IN (1,3)`:
`RP_GST.cs:2699-2706 {{AND A.BOOK_NAME IN ('SALES ORDER') AND A.SR_NO IN (1,3)}}` (not blocked).

GSTR-3B (`BtnGst3Zoom_Click`, 3479-3818). Every query is `TAX_DATA` filtered by `CO_CODE` only and by the **From date on
both sides**:
`RP_GST.cs:3541 {{A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.TAX_SIGN = '+' "}}`
(the same From-date-twice pattern is at 3584, 3642 and 3703). Selected columns:
`RP_GST.cs:3540 {{SUM(IIF(TAX_TYPE IN ('IGST','SGST'),A.NET_AMT,0)) As NetAmt}}` — taxable value is counted only on the
IGST and SGST rows of a voucher, so a CGST row never double counts it. Rows computed:

1. 3.1(a): sign `+`, no R_CHARG filter (3541). Figures formatted `"0.00"` (3550-3553). Running totals `num..num4` use `Conversion.Val` of the displayed text.
2. 3.1(d): same query plus `RP_GST.cs:3584 {{A.TAX_SIGN = '+' AND A.R_CHARG = 'Y'}}`; added to the same running totals (3598-3601).
3. 3.1(b), (c), (e): label only. `RP_GST.cs:3573-3580 {{OutWord Taxable Supplies (Zero rated) }}` — no figures assigned.
4. 3.1 total row: `RP_GST.cs:3614-3617 {{mSG_VCH2[DC_Main.i, 3] = Strings.Format((object)num, "0.00");}}` (taxable, igst, cgst, sgst; Cess column is "" — no cess calculation).
5. 3.2 (1) Supplies to unregistered persons: per place of supply (state), `RP_GST.cs:3642 {{AND A.TAX_SIGN = '+' AND B.AC_GSTNO = '' GROUP BY C.STATE_CODE,B.AC_STATE}}`; columns Taxable and Igst only (3653-3654). (2) composition and (3) UIN: label only (3665-3675).
6. 4(A)(5) All Other ITC: `RP_GST.cs:3703 {{AND A.TAX_SIGN = '-' AND A.R_CHARG = 'N'}}` — **no TRAN_TYPE filter**. Sales-return rows are written with sign `-` and R_CHARG `'N'`: `Ac_Tax.cs:183 {{A.TAX_CODE,'I',C.TAX_PRC,A.RTN_NET_AMT}}` (TRAN_TYPE `'S'` earlier in the statement and sign `-` later: `Ac_Tax.cs:183 {{A.TCS_AMT),'0.00'),'-',A.AC_NAME,'N'}}`), so the desktop's "All Other ITC" also contains sales-return tax.
7. 4(A)(1)-(4), 4(B), 4(C), 4(D), 5: label only (3688-3770).
8. 6.1 Payment of Tax rows: Taxpayable = totals of 3.1 (a)+(d); Paid = the ITC row; `RP_GST.cs:3789 {{mSG_VCH2[DC_Main.i, 0] = "Integrated Tax";}}` with Taxpayable `num2`, Paid Igst `num7`, Paid Cgst `num8`, Paid Sgst `num9`. "Centrel Tax" taxpayable is `num3`; `RP_GST.cs:3800-3802 {{mSG_VCH2[DC_Main.i, 0] = "State/Ut Tax";}}` also prints `num3` (the CGST total), not `num4` (the SGST total) — a desktop defect. "Cess" has no figures.
9. 6.2: `RP_GST.cs:3811-3814 {{mSG_VCH2[DC_Main.i, 0] = "TCS";}}` and "TDS" are bare labels.

Rounding: figures are `Strings.Format(x, "0.00")` (a display format of the database value); no
`Math.Round` is used in the 3B figures.

## Lifecycle and write set

A read-only report. The form index lists 11 tables, all under "Reads", none under "Writes". The only side effects are:

- CSV: deletes and recreates one file per section, `RP_GST.cs:3118-3121 {{File.Delete(strFilename);}}` then
  `File.AppendText(strFilename)`. Names (`BtnCsvFile_Click`):
  `RP_GST.cs:3081-3105 {{\\CsvFile\\B2B.csv}}`, B2CL, B2CS, CDNR, CDNUR, `RP_GST.cs:3097 {{\\CsvFile\\EXP.csv}}`, AT, ATADJ,
  `RP_GST.cs:3106 {{\\CsvFile\\HSNSUM.csv}}`. Index 9 (EXEMP) and 11 (DOCS) have no file: `RP_GST.cs:3108-3110 {{case 9:}}` then `break;`.
- Excel (`btnGstrCsv_Click` 3819-3944): creates an Excel workbook through COM; no business table is touched.

The grid query for each section is in `BtnGst1Zoom_Click` (2640-3031). Selection recap for the blocked sections:

- EXP (6): `RP_GST.cs:2700-2701 {{case 6:}}` then `return;` — before any query.
- EXEMP (9): `RP_GST.cs:2716-2717 {{case 9:}}` then `return;`.
- DOCS (11): there is **no** `case 11` in the query switch (cases present in the query switch: 1-2, 3, 4-5, 6, 7, 8, 9, 10 — 11 is absent).
  The query text falls through to the next statement: `RP_GST.cs:2723 {{DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);}}`
  with whatever string the static `DC_Main.RsQry` held from the last query run anywhere in the application.
  The row loop has no `case 11` either (cases at 2752, 2782, 2802, 2813, 2847, 2880, 2889, 2898 — and the totals switch at 2982-3012 likewise).

## Print

Not part of the 12 cases. Crystal: `RP_GST.cs:2006-2012 {{Gstr_1.RPT}}` (UAE uses `SlTaxRpt.RPT`), reached from `BtnGstr1_Click`
(the Lite path of the Gstr 1 zoom). GSTR-2 and GSTR-3 print buttons are `BtnPrint_Click` (1758) and `BtnSave_Click` (2162).
User rights are read once on load: `RP_GST.cs:1492 {{Select * From USER_SET WHERE LC_CODE}}`. Print-rights check text:
not in the ranges read (Open questions).

## Rights

`RP_GST.cs:1492-1500 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));}}`
and `FRM_DELETE`; this is a report, so edit/delete rights do not gate the grid. No rights message was found in
the reviewed ranges.

## Desktop weaknesses not to port

1. String-built SQL with dates formatted into the text (`RP_GST.cs:2664-2670 {{"MM/dd/yyyy"}}`, 3540-3704). Use parameters.
2. 3B uses the From date as both bounds: `RP_GST.cs:3541 {{A.VCH_DATE <= '}}` formatted from `mFromDt` (also 3584, 3642, 3703) — the title says `RP_GST.cs:3512 {{"Month = "}}` but only one day is summed.
3. 3B has no `CO_YEAR`, `LC_CODE`, book or party filter (3540) — year/location mixing in a multi-year company.
4. 3B 6.1 "State/Ut Tax" prints the CGST total (`RP_GST.cs:3800 {{State/Ut Tax}}` above).
5. "All Other ITC" has no `TRAN_TYPE` filter, so sales-return rows leak into ITC (`Ac_Tax.cs:183 {{'-',A.AC_NAME}}`, `RP_GST.cs:3703 {{A.TAX_SIGN = '-' AND A.R_CHARG = 'N'}}`).
6. DOCS runs a stale static query (`RP_GST.cs:2723 {{OpenRecordSetDc(DC_Main.RsQry)}}`).
7. `SetDate` weaknesses: single-character day compare for February/30-day months, silent reject for a one-digit entry, full dates not checked against the session year (see G5).
8. `SaveCSV` joins cells with commas without quoting: `RP_GST.cs:3135-3137 {{(object)",")), (object)mSG_VCH[DC_Main.R, i]));}}`.
9. `File.AppendText` into an application-relative `CsvFile` folder, overwriting silently; `btnGstrCsv_Click` creates Excel through late-bound COM with a catch that only shows a message.

## Web today

- `web/apps/api/src/modules/reports/gstReport.ts` — request parser and report builder. EXP, EXEMP, DOCS and TCS are
  refused: `web/apps/api/src/modules/reports/gstReport.ts:27 {{const BLOCKED = new Set(['EXP', 'EXEMP', 'DOCS', 'TCS']);}}` (HTTP 422 `section-not-supported`). Date range and the session-year clamp are at lines 91-112.
- `web/apps/api/src/modules/reports/gstReportQueries.ts` — SQL: tax rows, HSN rows, 3B totals, company name. The 3B query takes a From..To range plus tenant, company, location and year: `web/apps/api/src/modules/reports/gstReportQueries.ts:263-264 {{AND a."VCH_DATE">=$5::date AND a."VCH_DATE"<=$6::date}}`.
- `web/apps/api/src/modules/reports/gstReportSections.ts` — presenters: `web/apps/api/src/modules/reports/gstReportSections.ts:491-493 {{row('3.1', '(a)', 'OutWord Taxable Supplies(Other then Zero rated)', source.outward),}}` — only 3.1(a), 3.1(d) and 4(A)(5) are rows; the remaining 3B rows are listed in `blockedRows` (505-521).
- `web/apps/api/src/modules/reports/gstReportCsv.ts` — CSV with RFC-4180 quoting and formula neutralisation: `web/apps/api/src/modules/reports/gstReportCsv.ts:20-21 {{export function serializeGstCsv(report: GstReportResult): string {}}`.
- the function `gstReportSheet` in `gstReport.ts` — one-section XLSX sheet; there is no whole-workbook export.
- `web/apps/web/app/(app)/reports/gst-report/GstReportGrid.tsx` — shows the blocked-section/blocked-row notice.
- Tests: `web/apps/api/test/gstReport.test.ts`, `gstReport.db.test.ts`, `gst.test.ts`; browser module `gstReport.mjs` (70 cases).
- `web/apps/api/src/modules/reports/gstReportQueries.ts:210 {{sums IT_DISC_AMT; the web LBR_ISU_DETL has no discount column}}` — the known labour-discount gap (see "Posting paths").

## Gaps

Each item: case id; blocking reason as written in the module; what the desktop shows; expected behaviour; what the web must change.
"Verdict" says whether the case can become executable.

**G1 — `section.exp.pending` (T02, read-only).** Reason: "Desktop source does not settle EXP rows or calculations. A Windows observation or accepted decision is required; no export assumptions are frozen."
Desktop: EXP has a title and nothing else — `RP_GST.cs:2472-2477 {{mSG_VCH[0, 0] = "Summary For Exp(6)";}}`, one column (width 2000, `RP_GST.cs:2476 {{mSG_VCH[0] = (int)Math.Round(2000.0 * ColCon);}}`) — and the query switch returns before any query (`RP_GST.cs:2700-2701 {{case 6:}}` → `return;`), so no "No Record Found...." message and no data rows ever appear. The source *does* settle EXP: it is an intentionally empty section.
Expected: choosing EXP and running shows one title row "Summary For Exp(6)", no data rows, no message box, focus unchanged.
Web change: the `BLOCKED` set in `gstReport.ts` must stop refusing EXP (422) and `presentTaxSection` must return a title-only result with zero rows/totals; the grid component must show the title. Wrong result (today an error). Verdict: executable; the blocked reason is too cautious. EXP posts nothing: no writer feeds it (Ac_Tax has no export rows).

**G2 — `section.exemp.pending` (T02).** Reason: "Desktop source does not settle nil-rated, exempt, and non-GST row calculations. Do not infer them from the headings."
Desktop: header only, return before query: `RP_GST.cs:2530-2557 {{mSG_VCH[3, 1] = "Nil Rated Supply";}}` (captions "Descripition", "Nil Rated Supply", "Exmp and Non Gst Supply", "Non Gst Supply"; group row captions "Total Nil Rated Supplies", "Total Exempted Supplies", "Total Non-Gst Supplies"; title `RP_GST.cs:2532 {{Summary For Nill Rated,Exmp and Non Gst outword(8)}}`), then `RP_GST.cs:2716-2717 {{case 9:}}` → `return;`. The source confirms there is no calculation; `RP_GST.cs` never reads `TAX_FREE_AMT` or `ZERO_RATED_AMT` (zero hits in the form) although `Ac_Tax.cs:87 {{TAX_FREE_AMT,ZERO_RATED_AMT) Select}}` writes them for zero-tax sales (SR_NO 4 rows).
Expected: header-only grid with the four captions above, no data rows, no message; CSV button does nothing and no file (already covered by the passing case `output.csv-exempt-not-emitted`).
Web change: same as G1 for EXEMP, with the captions. Missing feature (today a 422). Verdict: executable as "headers only". Do not compute nil/exempt/non-GST figures — the desktop does not.

**G3 — `section.documents.pending` (T02).** Reason: "Desktop source does not settle issued/cancelled document rows. A Windows observation or owner decision is required."
Desktop: headers at `RP_GST.cs:2599-2629 {{mSG_VCH[0, 0] = "Summary of Doc. issued The Tax Period";}}` with captions "Nature Of Document", "Sr. No From", "Sr. No To", "Total Number", "Cancelled" (`RP_GST.cs:2622 {{Cancelled}}`), but the query switch has no `case 11` (cases listed in Lifecycle), so `DC_Main.RsQry` is whatever the last query was (static, shared with every form: `RP_GST.cs:2723 {{DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);}}`). The row loop has no `case 11` either, so no data row is ever written. The only observable desktop outcome is: header grid; possibly a stale "No Record Found...." popup (inferred; depends on the stale query) which must not be ported.
Expected: header-only grid with the five captions; no rows; no message; no CSV (`BtnCsvFile_Click` has no case 11); not included in the workbook (loop ends at 10, `RP_GST.cs:3911 {{while (num2 <= 10);}}`).
Web change: allow DOCS with zero rows and the five captions. Missing feature. Verdict: executable as "headers only" with the stale-query behaviour recorded as a weakness; a real documents summary (Sr. No From/To, cancelled counts) is NOT in the desktop and needs an owner decision before anyone builds it.

**G4 — `formula.gstr3b-incomplete-branches.pending` (T03).** Reason: "RP_GST does not settle all GSTR-3B branches or selector scope, and current web reports.ts explicitly implements outward supply only. Complete totals cannot be assumed."
Desktop (see Calculations): computed rows are 3.1(a), 3.1(d), the 3.1 total, 3.2(1), 4(A)(5), and the 6.1 Taxpayable/Paid figures; everything else is a label row with blank cells (3.1(b)/(c)/(e), 3.2(2)/(3), 4(A)(1)-(4), 4(B), 4(C), 4(D), 5, 6.2 TDS/TCS, Cess columns). `RP_GST.cs:3573-3580 {{OutWord Taxable Supplies (Zero rated) }}` has no figures. So "complete totals" do not exist in the desktop; the case can assert exactly: computed rows have figures, label rows are blank.
Differences the next worker must resolve with the owner (each affects statutory figures):
 a. Date scope: desktop sums one day (From date both bounds, 3541); web sums From..To (`web/apps/api/src/modules/reports/gstReportQueries.ts:263-264 {{a."VCH_DATE">=$5::date}}`). Statutory 3B is monthly, so the web range is almost certainly what the user needs, but it is not what the desktop does. Needs an owner decision (Open questions Q1).
 b. 3.1(a) has no `R_CHARG` and no `TRAN_TYPE` filter in the desktop (3541); the web adds `TRAN_TYPE='S'` and `R_CHARG<>'Y'` (`web/apps/api/src/modules/reports/gstReportQueries.ts:250 {{a."TRAN_TYPE"='S' AND a."TAX_SIGN"='+' AND COALESCE(a."R_CHARG",'N')<>'Y'}}`). A reverse-charge purchase row written with sign `+` is counted in both (a) and (d) by the desktop and only in (d) by the web.
 c. 4(A)(5): the desktop has no `TRAN_TYPE` filter (3703) so it includes sales returns; the web filters `TRAN_TYPE='P'` (`web/apps/api/src/modules/reports/gstReportQueries.ts:258 {{a."TRAN_TYPE"='P'}}`). Owner decision Q2.
 d. 3.2(1) is computed by the desktop (3642) but is neither emitted nor listed in the web's `blockedRows` (`web/apps/api/src/modules/reports/gstReportSections.ts:505-521 {{blockedRows: [}}`) — a silent omission. Missing feature.
 e. 6.1 is computed (Taxpayable/Paid) but the web lists "6.1" as blocked (`web/apps/api/src/modules/reports/gstReportSections.ts:519 {{'6.1',}}`). Missing feature. Port the figures but fix the SGST defect: the desktop prints the CGST total on the "State/Ut Tax" row (3800-3802); correct value is the SGST total. Expected-value decision Q3.
 f. 3.1 total row (3614-3617) is not in the web rows. Missing feature.
 g. Web scope adds `tenant_id`, `CO_CODE`, `LC_CODE`, `CO_YEAR`, optional book/party; the desktop uses `CO_CODE` only. Keep the web filters (tenant isolation is mandatory); the difference only matters in multi-year data.
Verdict: split into sub-cases. Executable now: label rows stay blank; 3.1(a)/(d)/(5) figures. Blocked on decisions Q1-Q3: date scope, ITC sales-return leak, 6.1 SGST. Passing cases this would change: any `formula.gstr3b-*` case asserting the current row set (three rows only) and `snapshot.*`/`journey.*` cases that read 3B.

**G5 — `invalid.setdate-and-malformed-date-message.pending` (T06, refusal).** Reason: "RP_GST does not contain the exact SetDate malformed/out-of-year message text. The case must remain blocked until that helper is traced and the desktop focus behavior is settled."
Traced (`DC_Main.cs:1561 {{public static void SetDate(ref MaskedTextBox MsDate)}}`). Messages and behaviour:
 - Day > 30 in a 30-day month (April, June, September, November), Feb day > 29: `DC_Main.cs:1640-1645 {{Interaction.MsgBox((object)"Date Not Valid...", (MsgBoxStyle)0, (object)null);}}` and after any invalid result `DC_Main.cs:1645-1646 {{MsDate.Text = "__/__/____";}}` then `DC_Main.cs:1646 {{((TextBoxBase)MsDate).SelectAll();}}`.
 - Month > 12: `DC_Main.cs:1664 {{Month Not Valid...}}` (also at 1679 for the second month test).
 - Day > 31: `DC_Main.cs:1672 {{Date Not Valid...}}`.
 - Message box has no caption/title (`(object)null`) and OK-only (`(MsgBoxStyle)0`). `RongDate` is set `true` before each message: `DC_Main.cs:1643 {{RongDate = true;}}`.
 - Focus: the form does nothing after the message. `RP_GST.cs:3042 {{if (!DC_Main.RongDate)}}` skips the Tab, so focus stays in the same date box with its text selected and cleared to `__/__/____`.
 - One-digit entry (the mask returns after 1 digit): `DC_Main.cs:1600 {{if (i == 2)}}` sets `RongDate = true` and returns **silently** (no message, text unchanged).
 - Partial dates are completed with the session financial year: `DC_Main.cs:1594 {{FnYear = Conversions.ToString(Interaction.IIf(Conversion.Val(Strings.Mid(MsDate.Text, 4, 2)) < 4.0, (object)Strings.Right(MCo_year, 4), (object)Strings.Left(MCo_year, 4)));}}` (month < 4 → second year, else first). A full 10-character date keeps the typed year: `DC_Main.cs:1634-1636 {{case 10:}}` with `Strings.Mid(MsDate.Text, 7, 10)` — **no out-of-year message exists in SetDate**.
 - Weak checks: February and 30-day tests compare only the first character of the day against "29"/"30" (`DC_Main.cs:1641 {{Strings.Mid(MsDate.Text, 1, 1), "29", false) > 0}}`), so 31/04 passes; Feb 29 in a non-leap year passes; the final test `Conversion.Val(Strings.Mid(MsDate.Text, 3, 2)) > 12.0` examines "/M" and cannot fire.
Expected: refusal case for impossible day/month: message text exactly "Date Not Valid..." or "Month Not Valid..." in an OK-only box, field cleared to the empty mask, focus remains in that box, no query is sent. Typing `31/02` style values gives "Date Not Valid...".
Web change: the date check in `gstReport.ts` (around lines 99-112) states "The exact desktop refusal text is not in this form" and rejects dates outside the session year with `date-outside-year` and `fromDate > toDate` with `invalid-date-range`. Neither is desktop behaviour (the desktop accepts a full out-of-year date and shows "No Record Found...."). The UI date field must replicate SetDate completion and the two messages; the API-edge clamp is a web adaptation that needs an accepted decision (Q4). Wrong text/missing key. Verdict: executable for the two messages and focus; the out-of-year and From>To refusals stay blocked pending Q4.

**G6 — `failure.query-or-render-no-write.pending` (T14, refusal).** Reason: "The harness has no declared query/render fault injector."
Desktop: reading `RP_GST.cs:2640 {{private void BtnGst1Zoom_Click(object sender, EventArgs e)}}` there is no `try/catch`, no transaction, and the form index shows no table writes. A failure would raise the .NET error and nothing is persisted. The expected business effect is therefore "no write", which the source settles; what is missing is only the fault injector.
Web change: none to the report (it runs inside `withTxBudget(... SNAPSHOT_READ ...)`, `web/apps/api/src/modules/reports/gstReport.ts:131 {{return withTxBudget(prisma, input.tenantId, SNAPSHOT_READ, async (tx) => {}}`, a read-only transaction). Harness change needed: MISSING: a scoped fault injector (e.g. a query-abort hook). Verdict: stays blocked until the injector exists; when it does, assert row-count sentinels of TAX_DATA, SL_DATA, AC_DATA unchanged.

**G7 — `failure.export-sentinels-intact.pending` (T14, refusal).** Reason: "The harness has no declared download/export failure injector."
Desktop: export writes only a file or a workbook: `RP_GST.cs:3118-3121 {{File.Delete(strFilename);}}`; the Excel path catches every exception and shows `RP_GST.cs:3925-3935 {{Error Exporting to Excel: }}` after `Quit` on the Excel object. No business table is written. Expected: failure leaves all sentinels intact; the web's export is a pure read plus a download, so the same holds.
Web change: none to the code; needs the same MISSING injector as G6 (download abort). Verdict: blocked on the harness only.

**G8 — `output.csv-exp.pending` (T16, output).** Reason: "EXP filename is settled, but its exact columns and rows are not. Do not certify an empty or invented CSV."
Desktop: the file name is `RP_GST.cs:3097 {{\\CsvFile\\EXP.csv}}`. `SaveCSV` writes grid rows 3..Rows-1 with only visible columns (`RP_GST.cs:3134 {{if (mSG_VCH[i] != 0)}}`, i.e. ColWidth ≠ 0), then shows "File is Generate...". For EXP the grid has `Rows = 5` and one visible column whose rows 3 and 4 are empty, so the file is two empty lines (inferred from `DGV_CLEAR` Rows = 5 and the EXP column setup; verify on Windows is not available — this is the one fact the source implies but does not display). The source answers the open question: EXP.csv has **no columns and no rows**; certifying it as "empty" is correct, not invented.
Web change: depends on G1; `serializeGstCsv` writes a header line from `report.columns`; for EXP the web must emit the same blank lines (or an agreed equivalent) and the "File is Generate..." notice. Wrong result once G1 exists. Verdict: executable after G1, with the "two empty lines" expectation flagged *inferred*.

**G9 — `output.csv-documents.pending` (T16, output).** Reason: "The desktop source does not settle a DOCS file name, rows, or byte layout."
Desktop: settled by absence: `BtnCsvFile_Click` has cases 1-8 and 10 and `case 9: break;` (`RP_GST.cs:3096-3110 {{case 6:}}`); there is no case 11 → clicking "Csv Fil" with DOCS selected does nothing: no file, no message.
Expected: DOCS emits no CSV (download count 0), same as the passing EXEMP case.
Web change: hide/disable the export for DOCS (and make the API reject a DOCS CSV request). Missing key/feature. Verdict: executable.

**G10 — `output.malformed-csv-values.pending` (T16, output).** Reason: "Desktop behavior for commas, quotes, and embedded newlines is malformed/ambiguous. Freeze no 'corrected' web escaping rule without an accepted adaptation decision."
Desktop: `SaveCSV` concatenates `text + IIf(i == 0, "", ",") + cell` with no quoting or escaping: `RP_GST.cs:3135-3137 {{(object)",")), (object)mSG_VCH[DC_Main.R, i]));}}`; `WriteLine` ends each row with the platform newline (CR LF on Windows); `File.AppendText` writes UTF-8 without BOM. A comma in a party name shifts every column to its right; a quote is written raw; a newline would split the row. The source fully describes the (broken) desktop output.
Web: `gstReportCsv.ts` deliberately applies quoting and formula neutralisation (`web/apps/api/src/modules/reports/gstReportCsv.ts:11 {{function gstCsvCell(value: unknown): string {}}`); line 117 of `03-shared-contracts.md` requires escaping against report injection, and G81 in document 12 records the adaptation. Whether an escaped file is acceptable parity is a decision, not a source fact.
Expected for an executable case: values without commas/quotes/newlines are byte-identical to the desktop; for values with them the case asserts the web's escaped form and must be labelled "adaptation", not "desktop match".
Verdict: stays blocked as a *desktop-match* case; becomes executable as an *adaptation* case once Q5 (accept RFC-4180 + formula guard as the adaptation) is answered. No web change needed if accepted.

**G11 — `output.all-sections-workbook.pending` (T16, output).** Reason: "Headless Linux cannot execute desktop Excel COM. A web XLSX adaptation and its semantic/byte contract require an accepted implementation decision."
Desktop semantic contract (settled by `RP_GST.cs:3819 {{private void btnGstrCsv_Click(object sender, EventArgs e)}}`): sheets named from `RP_GST.cs:3832-3836 {{"", "B2B", "B2CL", "B2CS", "CDNR", "CDNUR", "EXP", "AT", "ATADJ", "EXEMP",}}` and `"HSN"`; sections 1..10 run in order (`RP_GST.cs:3911 {{while (num2 <= 10);}}`; DOCS is not exported); each is produced by running the section zoom with `bExportingAll = true` so "No Record Found...." is suppressed; a sheet is added when the grid has rows (always, because `DGV_CLEAR` leaves `Rows = 5`), so empty sections give header-only sheets (EXP and EXEMP give their title/captions only); cell content is the grid's string from row 0 and visible columns only, compacted left (`RP_GST.cs:3890 {{if (mSG_VCH[j] != 0)}}`); afterwards the selected section is restored and re-run (`RP_GST.cs:3912 {{cboSectionType.SelectedIndex = selectedIndex;}}`) and Excel is made visible. Byte layout (.xlsx styling, column auto-fit) is Excel's own and not specified.
Web: `gstReportSheet` produces one sheet per request (function `gstReportSheet`); there is no whole-workbook route. Missing feature. Verdict: stays blocked until an accepted decision for the web adaptation (Q6); after that, a *semantic* case (sheet names/order, cell strings equal to the grid, empty sections as header-only sheets) is executable; a byte case is not possible.

**G12 — `journey.tcs.pending` (T18, read-only).** Reason: "RP_GST does not establish which posting rows feed TCS or how to total them. Keep blocked until posting/report source proves relevance."
Desktop: the GST report has no TCS calculation at all — 6.2 "TDS" and "TCS" are bare label rows (`RP_GST.cs:3811-3814 {{mSG_VCH2[DC_Main.i, 0] = "TCS";}}`). TCS never enters `TAX_DATA` as a tax row: the `TAX_DATA` insert has no TCS column and the voucher total written there excludes it: `Ac_Tax.cs:81 {{A.OTH_TAX_AMT+A.HM_AMT+A.HM_TAX_AMT+A.TCS_AMT),'0.00'),'+'}}`. TCS lives in the ledger: `Ac_Ledr.cs:96 {{D.TAX_AC,A.AC_CODE,TCS_AMT,0,'A'}}` (sales; the TCS account comes from `TAX_MAST.TAX_AC` of the voucher's `TCS_CODE`), `Ac_Ledr.cs:434 {{A.AC_CODE,0,TCS_AMT,'A'}}` (purchase, credit side) and `Ac_Ledr.cs:1847 {{IIF(B.MAIN_BOOK = 'E INVOICE',TCS_AMT,0)}}` (E INVOICE). So the source *does* settle the relevance question: TCS is relevant only through (1) excluding `TCS_AMT` from the `TOT_AMT` the GST sections show as invoice value, and (2) the blank 6.2 label rows.
Expected for the journey: create a sale with TCS through the real Sales screen; the GST B2B/B2CL/B2CS row invoice value excludes the TCS amount; taxable value and tax are unchanged; 3B 6.2 TDS/TCS rows show blank figures; no TCS number appears anywhere in the report.
Web change: check `web/apps/api/src/modules/shared/taxDataRows.ts` writes `TOT_AMT` without `TCS_AMT` (not verified in this study — Open questions) and that the report prints nothing for TCS. No new report feature. Verdict: executable once the TOT_AMT check is made.

### Posting paths that feed GST sections

Desktop writer of `TAX_DATA` is `Ac_Tax.cs` (insert statements at lines 81-98 sales, 183-187 sales return, plus purchase/return counterparts). Section sources:
- Sales / B2B Sales (SR_NO 1-4, 10), Sales Return (SR_NO 1-3): `Ac_Tax.cs:81 {{TCS_AMT),'0.00'),'+',A.AC_NAME}}`, `Ac_Tax.cs:183-187 {{'-',A.AC_NAME}}`. Zero-tax sales rows carry `TAX_FREE_AMT` and `ZERO_RATED_AMT` (`Ac_Tax.cs:87 {{TAX_FREE_AMT,ZERO_RATED_AMT}}`) — **no report section reads them**, so there is no EXEMP or EXP feed.
- Round-trip writers on the web: `web/apps/api/src/modules/sales/sales.ts`, `salesReturn.ts`, `labourInvoice.ts`, `wholesaleSaleReturn.ts`, `savedSaleReturn.ts`, `saleReturnNumericUpdate.ts`, `einvoice/eBillWriter.ts`, shared `shared/taxDataRows.ts` and `shared/taxPolicy.ts`.
- Labour/making: HSN section reads `LBR_ISU_DETL` with a fixed HSN `998892` (`RP_GST.cs:2719 {{998892}}`). The desktop sums labour discount: `RP_GST.cs:2719 {{LBR_DISC}}`; the web `LBR_ISU_DETL` has no discount column (`web/apps/api/src/modules/reports/gstReportQueries.ts:210 {{sums IT_DISC_AMT}}`, quoted above), so the web HSN discount column is understated for labour rows. A migration adding the column plus the labour writer (`labourInvoice.ts`) change is a prerequisite for exact HSN discounts; this changes the passing case `section.hsn-calculation` and `formula.hsn-quantity-value-tax-split` once labour rows with discount exist.
- TCS: ledger only (G12). Exempt: TAX_DATA zero-tax rows, unread. Export: none. Documents: no data source; `DOCS` would need `BOOK_DATA`/voucher number ranges, which the form never queries.

## Open questions

Q1. 3B date scope: the desktop sums only the From date (3541) although the title says "Month = …". Should the web keep From..To (statutorily sensible, differs from desktop), or reproduce one-day behaviour? Needs owner decision.
Q2. "All Other ITC" includes sales-return tax in the desktop (no TRAN_TYPE filter, `Ac_Tax.cs:183 {{'-',A.AC_NAME}}` writes returns with `-`). Reproduce, or keep the web's purchase-only filter?
Q3. 6.1 "State/Ut Tax" prints the CGST total in the desktop. The expected value should be the SGST total — confirm.
Q4. Does the web keep `date-outside-year` and `invalid-date-range` refusals as accepted adaptations, given that the desktop `SetDate` accepts a full date outside the year and has no From>To check?
Q5. Accept RFC-4180 quoting plus formula neutralisation for GST CSV as an adaptation (G10)?
Q6. Accept a web whole-workbook XLSX (sheet names/order from G11) as the adaptation of the Excel COM export?
Q7. The 13th blocked case named in the packet: I found 12 `blocked(` calls. Which one is missing?
Q8. Not read in this study: designer tab order and enabled/visible flags (905-1473), the print-rights message in `BtnPrint_Click`/`BtnSave_Click`, `tAcCode_KeyDown`/`tLcCode_KeyDown` details, whether `shared/taxDataRows.ts` excludes TCS from `TOT_AMT`, and `DC_Main.cs` value of `MsAlterYear` handling. None changes a case verdict above except the TCS check in G12.
Q9. EXP.csv byte content ("two empty lines", G8) is inferred from the grid setup, not displayed by any source line; a Windows run would confirm it.
