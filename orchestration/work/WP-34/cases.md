# WP-34 cases: Tag Print residuals (PRINT_MAST label-file choice, SubTagPrint sub-report)

This is the frozen case list for Utilities → Tag Print. It covers only the two residuals named in
`orchestration/work/WP-34/study.md`: the `PRINT_MAST` print-file choice (QrPrint10, BarPrint10, BarPrint13,
GhatTagPrnt) and the `SubTagPrint.rpt` sub-report. The rest of the screen is already covered by
`web/apps/web/test/features/modules/tagPrint.mjs`; where a behaviour is the same, the case says **Reused** and names the
existing id.

Case ids are lower case, dotted, and prefixed `tag-print.` so they match the module's `C()` wrapper,
which builds each id from a dotted tail. The old study ids (`output.file-choice-per-template`,
`set.default-message-text`, …) keep their tail; the prefix is the only difference.

Sources read for this list: `orchestration/work/WP-34/study.md`; the T01–T18 matrix in
`docs/master-parity-plan-2026-09-29/04-verification-playbook.md:46-65`; `web/apps/web/test/features/modules/tagPrint.mjs`;
`unified/src/csharp/DataCareNext/UT_TAG_PRINT.cs`; the four extracted label files in `extraction_output/rpt_xml/`.

## Decisions (architect, 2026-11-23, owner may override)

The packet's standing rule is "the desktop first; the web adds only what a hosted multi-user service needs to be safe and
correct". The study's open questions are settled with it as follows. Each row is a decision the owner may override; where
even the rule cannot settle a case, the case is `blocked` with the exact question.

| Study question | Decision |
|---|---|
| OQ1 — is the web's `HUID:` line to stay? | No. None of the four label files places an HM id; the placed fields are `@ACName`, `@ItmWt`, `@Labour`, `@OtherAmt`, `@LessWt` (BarPrint13 only), `@TagNo`, `@OtherDetl`, `CO_MAST.CO_NAME`, `ITEM_MAST.GR_CODE`, `TAG_PRINT_DATA.IT_CODE`, `TAG_PRINT_DATA.TAG_NO` (BarPrint13.xml:205 {{FormulaName="{@ACName}"}} and the placed-field lists of the four files). The web's `HUID:` line is dropped. **architect, 2026-11-23, owner may override.** This changes the assertion of the existing `tag-print.journey.hm-id-reaches-the-label` case; the implementing change updates that case. |
| OQ2 — does Set need the edit right in the web? | Yes. Set changes a company-wide default, so it needs the update right. The desktop has no test (`BtnTagSet_Click`, UT_TAG_PRINT.cs:5636 {{private void BtnTagSet_Click(object sender, EventArgs e)}}), but the web is multi-user. **architect, 2026-11-23, owner may override.** |
| OQ3 — what should the web do on an empty print file at Print? | Blocked. The desktop passes the empty name to Crystal (`UT_TAG_PRINT.cs:5209 {{Cr.ReportFileName}}`) and fails with Crystal's own error; no desktop message exists (study Gap 8). The web's message is a new text the source cannot settle. |
| OQ4 — exact Crystal section positions and fonts | Not a case. The cases assert the field set and content per file; exact `Top/Left/Width`/font geometry is left to the visual protocol and the implementing change's extraction. |
| OQ5 — 19 module ids vs 18 lineage ids | Recorded in the report, not a case. The module's 19 ids are all listed in `tagPrint.mjs`; the lineage count is a bookkeeping question for the plan owner. |
| OQ6 — which files are in `PRINT_MAST` of the seed company? | A data question. The smallest seed for these cases is in **Test data**; the four known names are QrPrint10, BarPrint10, BarPrint13, GhatTagPrnt. |
| OQ7 — does GhatTagPrnt print the whole voucher's BAR_IDTL lines per label? | Yes. Its five links stop at `VCH_NO` (`GhatTagPrnt.xml:102 {{<SubReportLink LinkedParameterName="{?Pm-TAG_PRINT_DATA.VCH_NO}"}}`), so every BAR_IDTL row of the voucher prints on each label. The desktop runtime was not run, but the links are the source. **architect, 2026-11-23, owner may override.** |
| OQ8 — which blob field of QrPrint10 is the QR? | Not needed for these cases. The web generates the QR from the tag number in the sheet (Gap 10) and must not write `IMAGE_DATA`; the Crystal blob identity is not on the path. |

## T01 Entry/defaults

**Reused:** `tag-print.entry.defaults` (Load files, default marked file, Gold/Silver item type, blank grid, headers).

### tag-print.entry.combo-leading-empty   (T01 Entry/defaults) — Gap 9
Layer: browser
Steps: 1. Seed `PRINT_MAST` TAG rows `BarPrint10` (N), `BarPrint13` (Y). 2. Open `/txn/tag-print` and wait for the `Print file Name` select. 3. Read every `option` text in order and the selected value.
Expected: the option list is exactly `["", "BarPrint10", "BarPrint13"]` — the empty string is added before the files — and the selected value is `BarPrint13` (desktop: UT_TAG_PRINT.cs:4936 {{cboPrintfile.Items.Add((object)"");}} and UT_TAG_PRINT.cs:4954 {{cboPrintfile.Text = text;}}). Today the web lists only the files, so this fails.
Status: executable

### tag-print.entry.no-files-only-empty   (T01 Entry/defaults) — Gap 9
Layer: browser
Steps: 1. Delete every `PRINT_MAST` TAG row for the company. 2. Open `/txn/tag-print`. 3. Read the option list and the selected value.
Expected: the option list is exactly `[""]` and the selected value is `""` (desktop: the else branch adds only the empty item, UT_TAG_PRINT.cs:4952 {{cboPrintfile.Items.Add((object)"");}}, then UT_TAG_PRINT.cs:4954 {{cboPrintfile.Text = text;}} with `text` still `""`).
Status: executable

### tag-print.set.no-default-marked   (T01 Entry/defaults) — Gap 8
Layer: browser
Steps: 1. Seed `PRINT_MAST` TAG rows `BarPrint10` (N), `BarPrint13` (N), `GhatTagPrnt` (N) — files but none marked. 2. Open `/txn/tag-print`. 3. Read the selected value.
Expected: the selected value is `""`, not `BarPrint10`. The loop assigns `text` only for a row whose `PRINT_SET_A` is `"Y"` (UT_TAG_PRINT.cs:4942 {{["PRINT_SET_A"]}}), no row matches, and UT_TAG_PRINT.cs:4954 {{cboPrintfile.Text = text;}} sets the empty string. Today the web returns the first name (`tagPrintScreen.ts:161 {{defaultFile: marked ? text(marked.PRINT_FILE) : (names[0] ?? ''),}}`), so this fails.
Status: executable

### tag-print.entry.two-marked-last-wins   (T01 Entry/defaults)
Layer: browser
Steps: 1. Seed `PRINT_MAST` TAG rows `BarPrint10` (Y), `BarPrint13` (Y), `GhatTagPrnt` (N). 2. Open `/txn/tag-print`. 3. Read the selected value.
Expected: the selected value is `BarPrint13`, the last row in `PRINT_FILE` order whose `PRINT_SET_A` is `"Y"`. The Load loop has no `break`, so each matching row overwrites `text` (UT_TAG_PRINT.cs:4942 {{["PRINT_SET_A"]}} and UT_TAG_PRINT.cs:4954 {{cboPrintfile.Text = text;}}).
Status: executable

### tag-print.entry.tag-vs-qr-type   (T01 Entry/defaults) — Gap 10
Layer: browser
Steps: 1. Seed `PRINT_MAST` TAG rows `BarPrint10` (N), `QrPrint10` (Y) and QR rows `QrPrint10` (N), `QrPrint10-ALT` (Y). 2. With `QR_CODE_GEN` = N, open and read the options and the default. 3. Set `QR_CODE_GEN` = Y, reload and read them again.
Expected: with QR off the options are `["", "BarPrint10", "QrPrint10"]` and the default is `QrPrint10`; with QR on they are `["", "QrPrint10", "QrPrint10-ALT"]` and the default is `QrPrint10-ALT` (desktop: UT_TAG_PRINT.cs:4926 {{PRINT_TYPE = 'QR' ORDER BY PRINT_FILE}} versus UT_TAG_PRINT.cs:4930 {{PRINT_TYPE = 'TAG' ORDER BY PRINT_FILE}}).
Status: executable

## T02 Field route

### tag-print.field.file-reaches-print   (T02 Field route) — Gap 1
Layer: browser
Steps: 1. Seed the four files with `BarPrint10` marked Y. 2. Open, load voucher 88001 (TP0001–TP0003), select `BarPrint13` in `Print file Name`, click Print. 3. Inspect the `POST /stock/tag-print-screen/print` body, then open the label sheet.
Expected: the print request carries the chosen file (for example `file: "BarPrint13"`) or the staged rows carry it, and the opened sheet is BarPrint13's layout: it contains `L.0.500`, `*TP0001*` and no `GLD1 / 1235` line. The desktop uses the combo text as the template name (UT_TAG_PRINT.cs:5200 {{string text = cboPrintfile.Text;}} and UT_TAG_PRINT.cs:5209 {{Cr.ReportFileName}}). Today the web never sends the file (`tagPrintScreen.ts:494 {{export async function tagPrintStage(}}`), so the sheet is always the one web layout: this fails.
Status: executable

### tag-print.field.set-persists-default   (T02 Field route) — Gap 6
Layer: browser
Steps: 1. Seed `BarPrint10` (Y) and `BarPrint13` (N). 2. Open, select `BarPrint13`, click Set, close and reopen the screen. 3. Read the selected value and the `PRINT_MAST` rows.
Expected: `PRINT_MAST` TAG has `BarPrint13` Y and `BarPrint10` N; the reopened combo shows `BarPrint13`; the message text is exactly `Tag Print Report Default Set` (desktop: UT_TAG_PRINT.cs:5641 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'N'}} then UT_TAG_PRINT.cs:5643 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'Y'}}, message UT_TAG_PRINT.cs:5653 {{Interaction.MsgBox((object)"Tag Print Report Default Set"}}). Today the web's message is `${file} is the default label file.`, so this fails on the text.
Status: executable

### tag-print.field.qr-set-separate   (T02 Field route) — Gap 10
Layer: browser
Steps: 1. Seed TAG rows with default `BarPrint10` and QR rows with default `QrPrint10`. 2. With `QR_CODE_GEN` = Y, select `QrPrint10-ALT` and click Set. 3. Set `QR_CODE_GEN` = N, reopen and read the TAG default.
Expected: only the QR rows changed; the TAG default is still `BarPrint10`. The QR branch updates `PRINT_TYPE = 'QR'` (UT_TAG_PRINT.cs:5639 {{if (Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0)}} and UT_TAG_PRINT.cs:5641 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'N' WHERE  CO_CODE = '}}); the TAG branch is UT_TAG_PRINT.cs:5648 {{AND PRINT_TYPE = 'TAG'}} and UT_TAG_PRINT.cs:5650 {{AND PRINT_TYPE = 'TAG'";}}.
Status: executable

## T03 Formula sequence

### tag-print.calc.weights-rounding   (T03 Formula sequence)
Layer: unit
Steps: 1. Apply the placed gross formula to `ITM_GWT` = 10.500 and 10.505. 2. Apply the placed net formula to `ITM_NWT` = 10.000.
Expected: `G.10.500` and `G.10.505` (three decimals); `N.10.000`. Crystal `totext(x,3)` rounds half away from zero, so 10.5005 would print `10.501`; the fixture's 10.500 is exact (desktop: BarPrint13.xml:208 {{'G.'+totext({TAG_PRINT_DATA.ITM_GWT},3)}} and BarPrint13.xml:221 {{'N.'+totext({TAG_PRINT_DATA.ITM_NWT},3)}}).
Status: executable

### tag-print.calc.less-weight   (T03 Formula sequence) — Gap 12
Layer: unit
Steps: 1. With `ITM_GWT` = 10.500 and `ITM_NWT` = 10.000, apply BarPrint13's less-weight formula. 2. Repeat with 10.505 and 10.000.
Expected: `L.0.500` (10.500 − 10.000 = 0.500) and `L.0.505` (10.505 − 10.000 = 0.505), each with three decimals (desktop: BarPrint13.xml:217 {{'L.'+totext({TAG_PRINT_DATA.ITM_GWT}-{TAG_PRINT_DATA.ITM_NWT},3)}}).
Status: executable

### tag-print.calc.subtagprint-amount-rounding   (T03 Formula sequence) — Gap 3
Layer: unit
Steps: 1. Apply the sub-report amount formula to `IT_AMT` = 1234.50, 99.40 and 10.00. 2. Record the strings.
Expected: `1235`, `99` and `10` — `totext(x,0)` rounds half away from zero and prints no decimals (desktop: BarPrint10.xml:72 {{{BAR_IDTL.IT_CODE} &amp; " / " &amp; totext({BAR_IDTL.IT_AMT},0)}}).
Status: executable

### tag-print.calc.pcs-and-barcode   (T03 Formula sequence) — Gap 12
Layer: unit
Steps: 1. Apply the pieces formula to `ITM_PCS` = 1. 2. Apply the barcode-text formula to `TAG_NO` = `TP0001`.
Expected: `1` (no decimals) and `*TP0001*` (desktop: BarPrint13.xml:223 {{totext({TAG_PRINT_DATA.ITM_PCS},'0')}} and BarPrint13.xml:225 {{'*' + {TAG_PRINT_DATA.TAG_NO} + '*'}}).
Status: executable

## T04 Lookup

### tag-print.lookup.files-scoped-ordered   (T04 Lookup)
Layer: browser
Steps: 1. Seed TAG rows `BarPrint10`, `BarPrint13`, `GhatTagPrnt`, `QrPrint10` for company 01 and a QR row `QrPrint10-QR`. 2. Open `/txn/tag-print` with `QR_CODE_GEN` = N. 3. Read the option list.
Expected: the options are the TAG files sorted by `PRINT_FILE` — `BarPrint10`, `BarPrint13`, `GhatTagPrnt`, `QrPrint10` — plus the leading empty string; the QR row is absent (desktop: UT_TAG_PRINT.cs:4930 {{PRINT_TYPE = 'TAG' ORDER BY PRINT_FILE}}).
Status: executable

### tag-print.lookup.loaded-once   (T04 Lookup)
Layer: browser
Steps: 1. Open with `BarPrint10` in the list. 2. While the screen stays open, insert `GhatTagPrnt` into `PRINT_MAST`. 3. Read the select's options without reloading; then reload the screen and read them again.
Expected: the open select still lacks `GhatTagPrnt`; after reload it is present. The desktop fills the combo once in Load (UT_TAG_PRINT.cs:4930 {{PRINT_TYPE = 'TAG' ORDER BY PRINT_FILE}}), so there is no live refresh; the web matches.
Status: executable

## T05 Children

### tag-print.children.subtagprint-rows-per-parent   (T05 Children) — Gap 4
Layer: browser
Steps: 1. Seed TP0001 and TP0002 in voucher 88001. 2. Insert `BAR_IDTL` row `GLD1` / 1234.50 linked to TP0001 (SR_NO 1, VCH_SRNO 1) and row `GLD2` / 99.40 linked to TP0002 (SR_NO 2, VCH_SRNO 2). 3. Print `BarPrint10` and open the sheet. 4. Print `QrPrint10` and open the sheet.
Expected: BarPrint10's TP0001 label shows only `GLD1 / 1235`, and TP0002 shows only `GLD2 / 99`; QrPrint10's TP0001 label shows only `GLD1 / 1235`. No child line moves to the other tag (desktop: BarPrint10.xml:100 {{<SubReportLink LinkedParameterName="{?Pm-TAG_PRINT_DATA.TAG_NO}"}} and BarPrint10.xml:101 {{<SubReportLink LinkedParameterName="{?Pm-TAG_PRINT_DATA.VCH_SRNO}"}}; QrPrint10.xml:119 {{<SubReportLink LinkedParameterName="{?Pm-TAG_PRINT_DATA.SR_NO}"}}).
Status: executable

### tag-print.children.barprint13-no-subreport   (T05 Children) — Gap 3
Layer: browser
Steps: 1. Use the same seed as above. 2. Print `BarPrint13` and open the sheet. 3. Search each label for `GLD1`, `GLD2` and ` / `.
Expected: no sub-report line at all; `BarPrint13` declares no sub-report (desktop: BarPrint13.xml:10 {{<SubReports />}}).
Status: executable

## T06 Required/invalid

### tag-print.print.empty-file   (T06 Required/invalid) — Gap 8
Layer: browser
Steps: 1. Seed `PRINT_MAST` with no TAG rows, or with rows but none marked Y. 2. Open `/txn/tag-print`, load voucher 88001, click Print. 3. Observe the message and `TAG_PRINT_DATA`.
Expected: the web refuses and stages nothing. The desktop has no validation: it builds `<app dir>\Report\<empty>.RPT` from the empty combo text and Crystal fails at run time (UT_TAG_PRINT.cs:5209 {{Cr.ReportFileName}}); no desktop message exists.
Status: blocked: what message should the web show when `Print file Name` is empty? The desktop passes the empty name to Crystal (`UT_TAG_PRINT.cs:5209 {{Cr.ReportFileName}}`) and fails with Crystal's own error, and no desktop text exists (study Gap 8). Unblocks when the owner fixes the text.

### tag-print.required.unknown-file   (T06 Required/invalid) — Gap 2
Layer: browser
Steps: 1. Seed `BarPrint10` (Y). 2. Open, load voucher 88001, print with `BarPrint10`. 3. Delete the `BarPrint10` row from `PRINT_MAST`. 4. Repeat the print with `file: "BarPrint10"`.
Expected: HTTP 400 with the text `Unknown print file: BarPrint10`, and no `TAG_PRINT_DATA` rows are staged (architect decision: the web refuses an unknown name; the desktop would pass it to Crystal, UT_TAG_PRINT.cs:5209 {{Cr.ReportFileName}}).
Status: executable

### tag-print.required.set-empty-or-unknown   (T06 Required/invalid)
Layer: database
Steps: 1. Seed `BarPrint10` (Y). 2. `POST /stock/tag-print-screen/default-file` with `{file: ""}`. 3. `POST` the same route with `{file: "NoSuchFile"}`. 4. Read the `PRINT_MAST` rows.
Expected: both requests answer 400 and `BarPrint10` is still the only Y row; no default is cleared. The desktop would run `UPDATE ... PRINT_SET_A = 'Y'` with the unmatched text and then show `Tag Print Report Default Set` anyway (UT_TAG_PRINT.cs:5643 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'Y'}} and UT_TAG_PRINT.cs:5653 {{Interaction.MsgBox((object)"Tag Print Report Default Set"}}); that is a desktop weakness not to port.
Status: executable

## T07 Create

### tag-print.set.default-switches-only-one-file   (T07 Create) — Gap 6
Layer: database
Steps: 1. Seed `PRINT_MAST` TAG rows `BarPrint10` (Y), `BarPrint13` (N), `GhatTagPrnt` (N). 2. `POST /default-file` with `{file: "BarPrint13"}`. 3. Read every TAG row.
Expected: exactly one row is Y (`BarPrint13`); the other two are N. No other table changes (desktop: UT_TAG_PRINT.cs:5641 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'N'}} then UT_TAG_PRINT.cs:5643 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'Y'}}).
Status: executable

### tag-print.create.print-does-not-write-master   (T07 Create)
Layer: database
Steps: 1. Snapshot `PRINT_MAST` for the company. 2. Print voucher 88001. 3. Compare `PRINT_MAST` and `TAG_PRINT_DATA`.
Expected: `PRINT_MAST` is byte-identical; only `TAG_PRINT_DATA` is written. `BtnPrint_Click` writes `TAG_PRINT_DATA` (UT_TAG_PRINT.cs:5151 {{INSERT INTO TAG_PRINT_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,IT_CODE,VCH_SRNO)}}) and `IMAGE_DATA` only with QR generation on (UT_TAG_PRINT.cs:5181 {{dataRow["TAG_IMAGE"] = value;}}); it has no `PRINT_MAST` statement in :5122-5226.
Status: executable

## T08 Reopen/no-op

### tag-print.reopen.default-preserved   (T08 Reopen/no-op)
Layer: browser
Steps: 1. Set `BarPrint13` as the default. 2. Close and reopen `/txn/tag-print`. 3. Read the combo and the `PRINT_MAST` rows.
Expected: the combo shows `BarPrint13` and `PRINT_MAST` still has exactly one Y. The desktop reads the default at Load (UT_TAG_PRINT.cs:4954 {{cboPrintfile.Text = text;}}) and writes it in Set (UT_TAG_PRINT.cs:5643 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'Y'}}).
Status: executable

**Reused:** `tag-print.reprint.replaces-staging` (Print clears and rewrites `TAG_PRINT_DATA`; close/reopen does not change that).

## T09 Edit

### tag-print.set.default-message-text   (T09 Edit) — Gap 6
Layer: browser
Steps: 1. Seed `BarPrint10` (Y) and `BarPrint13` (N). 2. Select `BarPrint13`, click Set. 3. Read the on-screen message text.
Expected: exactly `Tag Print Report Default Set` — no file name, no period (desktop: UT_TAG_PRINT.cs:5653 {{Interaction.MsgBox((object)"Tag Print Report Default Set"}}). Today the web shows `${file} is the default label file.`, so this fails.
Status: executable

### tag-print.edit.switch-default-and-reprint   (T09 Edit) — Gap 1
Layer: browser
Steps: 1. Default `BarPrint10`. 2. Print voucher 88001 and capture the sheet. 3. Set `BarPrint13`, print the same voucher again and capture the sheet. 4. Compare the two sheets and `BAR_DETL`.
Expected: the first sheet has BarPrint10's `@OtherDetl` and the `GLD1 / 1235` sub-report line; the second has `L.0.500` and no sub-report line; `BAR_DETL` is unchanged by both prints. The template is the combo text at print time (UT_TAG_PRINT.cs:5200 {{string text = cboPrintfile.Text;}}).
Status: executable

### tag-print.edit.set-leaves-staging   (T09 Edit)
Layer: database
Steps: 1. Print voucher 88001 so `TAG_PRINT_DATA` holds three rows. 2. `POST /default-file` with a different file. 3. Read `TAG_PRINT_DATA`.
Expected: the same three rows, unchanged. `BtnTagSet_Click` only updates `PRINT_MAST` (UT_TAG_PRINT.cs:5641-5650 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'N'}}).
Status: executable

## T10 Delete/cancel/reverse

### tag-print.delete.no-delete   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Open `/txn/tag-print` and click the Delete button.
Expected: nothing happens; the desktop's `BtnDelete_Click` is empty (UT_TAG_PRINT.cs:5097-5100 {{private void BtnDelete_Click(object sender, EventArgs e)}}) and the residuals add no delete.
Status: N/A: Tag Print has no delete; the Delete button is empty on the desktop as well.

### tag-print.cancel.print-dialog   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Print voucher 88001 with three Y rows. 2. Close the opened label sheet (the print dialog's Cancel). 3. Request `/stock/tag-print-screen/labels` again.
Expected: `TAG_PRINT_DATA` still holds the three rows and the sheet shows them; Cancel only skips the dialog. The clear and the copies happen before the dialog (UT_TAG_PRINT.cs:5143 {{DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");}}), and the cancel branch returns at UT_TAG_PRINT.cs:5192 {{if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)}}.
Status: executable

## T11 Scope/rights

**Reused:** `tag-print.rights.print-and-edit` (FRM_PRINT refusal, Hm Id Update and Save edit rights, direct API 403s).

### tag-print.rights.set-needs-update   (T11 Scope/rights) — Gap 7
Layer: browser
Steps: 1. Insert a `USER_SET` row with `FRM_VIEW` = Y, `FRM_EDIT` = N, `FRM_PRINT` = N. 2. Sign in as that user and open `/txn/tag-print`. 3. `POST /stock/tag-print-screen/default-file` with `{file: "BarPrint13"}`.
Expected: HTTP 403 and the on-screen text `You Have No Rights.....`; `PRINT_MAST` is unchanged. The desktop has no right test in `BtnTagSet_Click` (UT_TAG_PRINT.cs:5636 {{private void BtnTagSet_Click(object sender, EventArgs e)}}), but the web keeps the update right by the architect decision above.
Status: executable

### tag-print.rights.cross-tenant-file   (T11 Scope/rights)
Layer: database
Steps: 1. Tenant A seeds `PRINT_MAST` TAG `BarPrint10` (Y). 2. Tenant B calls `GET /stock/tag-print-screen`, `POST /default-file` with `{file: "BarPrint10"}`, and `GET /stock/tag-print-screen/labels`. 3. Read tenant B's `PRINT_MAST` and `TAG_PRINT_DATA`.
Expected: B's setup lists no A file; B's Set answers 400 `Unknown print file: BarPrint10`; B's labels show only B's own staged rows (or no rows); B's `PRINT_MAST` has no new row. The desktop is single-company (its Load filters by `CO_CODE`, UT_TAG_PRINT.cs:4930 {{PRINT_TYPE = 'TAG' ORDER BY PRINT_FILE}}); the tenant scope is the web's safety addition.
Status: executable

## T12 Concurrency

### tag-print.concurrency.two-sets-one-default   (T12 Concurrency)
Layer: database
Steps: 1. Seed `BarPrint10` (Y), `BarPrint13` (N), `GhatTagPrnt` (N). 2. Two sessions load the screen. 3. Session A sets `BarPrint13` and session B sets `GhatTagPrnt` at nearly the same time. 4. Read every TAG row.
Expected: exactly one row is Y, and it is either `BarPrint13` or `GhatTagPrnt`; the other two are N. A lost clear (all N) or two Y rows is a failure. The desktop issues two statements (UT_TAG_PRINT.cs:5641 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'N'}} and UT_TAG_PRINT.cs:5643 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'Y'}}); the web's Set is one transaction.
Status: executable

## T13 Retry/unknown

**Reused:** `tag-print.retry.replayed-print` (a replayed print and a replayed Set change nothing more).

### tag-print.retry.replayed-print-with-file   (T13 Retry/unknown)
Layer: browser
Steps: 1. Print voucher 88001 with `BarPrint13` (two Y tags). 2. Replay the same `POST /stock/tag-print-screen/print` request, including the file. 3. Read `TAG_PRINT_DATA` and open the sheet.
Expected: HTTP 200, the same staged rows (no duplicates), and the sheet is still BarPrint13's layout. The desktop clears and rewrites before printing (UT_TAG_PRINT.cs:5143 {{DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");}}), so a replay is idempotent.
Status: executable

## T14 Rollback

### tag-print.rollback.set-second-statement-fails   (T14 Rollback)
Layer: database
Steps: 1. Seed `BarPrint10` (Y). 2. Create a trigger on `PRINT_MAST` that raises an exception when any row is set to `Y`. 3. `POST /default-file` with `{file: "BarPrint13"}`. 4. Read the rows and drop the trigger.
Expected: the request fails (status 400 or 500) and `PRINT_MAST` is unchanged: `BarPrint10` is still Y and `BarPrint13` is still N. The desktop's two statements are not atomic (UT_TAG_PRINT.cs:5641 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'N'}} then UT_TAG_PRINT.cs:5643 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'Y'}}); a failure between them leaves no default.
Status: executable

**Reused:** `tag-print.rollback.stage-fault` (a fault on a copied `TAG_PRINT_DATA` row rolls back the clear).

## T15 Config/history

### tag-print.config.file-is-print-time-snapshot   (T15 Config/history)
Layer: browser
Steps: 1. Seed `BarPrint10` (Y). 2. Print voucher 88001 with `BarPrint10`; capture the sheet at `/stock/tag-print-screen/labels?file=BarPrint10`. 3. Set `BarPrint13` as the default. 4. Re-request the same `labels?file=BarPrint10` URL.
Expected: the re-requested sheet still shows BarPrint10's layout (`GLD1 / 1235`, no `L.` line); a new print after the Set shows BarPrint13. The file is a print-time choice, not a column of `TAG_PRINT_DATA` (desktop: the template is the combo text at print, UT_TAG_PRINT.cs:5200 {{string text = cboPrintfile.Text;}}).
Status: executable

### tag-print.config.qr-mode-files   (T15 Config/history) — Gap 10
Layer: browser
Steps: 1. Seed TAG and QR `PRINT_MAST` rows. 2. Set `QR_CODE_GEN` = N and open; record the options and default. 3. Set `QR_CODE_GEN` = Y, reload and record them again.
Expected: with QR off the list is the TAG rows; with QR on it is the QR rows, and the default follows the QR row marked Y. No TAG row is changed by the switch (desktop: UT_TAG_PRINT.cs:4924 {{if (Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0)}} and UT_TAG_PRINT.cs:4926 {{PRINT_TYPE = 'QR' ORDER BY PRINT_FILE}}).
Status: executable

## T16 Report/output

**Reused:** `tag-print.output.label-sheet` (one label per staged row, blanks first, `G.10.500`, `N.10.000`, `MRP: 55000`) and
`tag-print.output.label-labour-lines` (MRP / LP / LF precedence).

### tag-print.output.file-choice-per-template   (T16 Report/output) — Gap 1
Layer: browser
Steps: 1. Seed all four files with `BarPrint10` marked Y. 2. For each file F in `QrPrint10`, `BarPrint10`, `BarPrint13`, `GhatTagPrnt`: select F, print voucher 88001, open the sheet, record the visible field texts. 3. Compare the four sheets.
Expected: each sheet is F's own layout and not the others':
- `QrPrint10`: a QR image; no `*TP0001*` text; `GLD1 / 1235` sub-report line.
- `BarPrint10`: `*TP0001*`; `GLD1 / 1235`; no `L.` line.
- `BarPrint13`: `*TP0001*`; `L.0.500`; no `GLD1` line.
- `GhatTagPrnt`: `*TP0001*`; both `GLD1 / 1235` and `GLD2 / 99`.
The template is the combo text (UT_TAG_PRINT.cs:5209 {{Cr.ReportFileName}}), and BarPrint13 declares no sub-report (BarPrint13.xml:10 {{<SubReports />}}). Today the web has one layout for all four, so this fails.
Status: executable

### tag-print.output.layout-per-file   (T16 Report/output) — Gap 2
Layer: browser
Steps: 1. Print each of the four files for TP0001 with the same seed. 2. Compare the visible field sets and their order.
Expected: the four sheets are not identical: QrPrint10 has a QR picture and no barcode text; BarPrint13 has `L.0.500` and no sub-report; BarPrint10 and GhatTagPrnt have the sub-report and `*TP0001*`; all four have `G.10.500`, `N.10.000`, `MRP: 55000`, `KARI-1`, `E2E SHOP`, `E1`, `TPG1`, `TP0001`. The four files place different fields (desktop: BarPrint13.xml:217 {{'L.'+totext({TAG_PRINT_DATA.ITM_GWT}-{TAG_PRINT_DATA.ITM_NWT},3)}} and BarPrint13.xml:10 {{<SubReports />}}). Today the web has a single layout, so this fails.
Status: executable

### tag-print.output.subtagprint-lines   (T16 Report/output) — Gap 3
Layer: browser
Steps: 1. Seed `BAR_IDTL` rows `GLD1` / 1234.50 and `GLD2` / 99.40 for voucher 88001. 2. Print `BarPrint10`, `QrPrint10`, `GhatTagPrnt` and `BarPrint13` in turn, opening each sheet. 3. Read the sub-report lines.
Expected: `BarPrint10`, `QrPrint10` and `GhatTagPrnt` show `GLD1 / 1235` and `GLD2 / 99` (one line per `BAR_IDTL` row, subject to their links); `BarPrint13` shows neither. The line is `{IT_CODE} & " / " & totext(IT_AMT,0)` (desktop: BarPrint10.xml:72 {{{BAR_IDTL.IT_CODE} &amp; " / " &amp; totext({BAR_IDTL.IT_AMT},0)}}); QrPrint10 and GhatTagPrnt embed the same sub-report (QrPrint10.xml:11 {{<Report Name="SubTagPrint.rpt">}} and GhatTagPrnt.xml:11 {{<Report Name="SubTagPrint.rpt">}}); BarPrint13 has none (BarPrint13.xml:10 {{<SubReports />}}). Today the web reads no `BAR_IDTL` at all, so this fails.
Status: executable

### tag-print.output.subtagprint-link-per-file   (T16 Report/output) — Gap 4
Layer: browser
Steps: 1. Use two `BAR_IDTL` rows: `GLD1` / 1234.50 on TP0001 (SR_NO 1, VCH_SRNO 1) and `GLD2` / 99.40 on TP0002 (SR_NO 2, VCH_SRNO 2), both in voucher 88001. 2. For each of the four files, print both tags and open the sheet. 3. Record the lines on each label.
Expected:
- `BarPrint10`: TP0001 shows only `GLD1 / 1235`, TP0002 only `GLD2 / 99` (links CO_CODE, TAG_NO, VCH_SRNO: BarPrint10.xml:100 {{<SubReportLink LinkedParameterName="{?Pm-TAG_PRINT_DATA.TAG_NO}"}} and BarPrint10.xml:101 {{<SubReportLink LinkedParameterName="{?Pm-TAG_PRINT_DATA.VCH_SRNO}"}}).
- `QrPrint10`: TP0001 shows only `GLD1 / 1235` (link includes SR_NO: QrPrint10.xml:119 {{<SubReportLink LinkedParameterName="{?Pm-TAG_PRINT_DATA.SR_NO}"}}).
- `GhatTagPrnt`: both labels show both `GLD1 / 1235` and `GLD2 / 99` (link stops at VCH_NO: GhatTagPrnt.xml:102 {{<SubReportLink LinkedParameterName="{?Pm-TAG_PRINT_DATA.VCH_NO}"}}).
- `BarPrint13`: neither label shows a sub-report line.
Status: executable

### tag-print.output.lable-skip-no-subreport-lines   (T16 Report/output) — Gap 4
Layer: browser
Steps: 1. Print with `Lable Skip` = 2 and voucher 88001, file `GhatTagPrnt`. 2. Open the sheet. 3. Read the two blank labels and the three real labels.
Expected: the two blank labels have no `GLD1`/`GLD2` line; each real label shows both lines. The blanks are staged with `VCH_NO` `00000` (UT_TAG_PRINT.cs:5151 {{INSERT INTO TAG_PRINT_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,IT_CODE,VCH_SRNO)}}), so the VCH_NO link of GhatTagPrnt matches no `BAR_IDTL` row (GhatTagPrnt.xml:102 {{<SubReportLink LinkedParameterName="{?Pm-TAG_PRINT_DATA.VCH_NO}"}}). Today the web prints no sub-report at all, so the real labels fail.
Status: executable

### tag-print.output.huid-line-removed   (T16 Report/output) — Gap 3
Layer: browser
Steps: 1. Seed TP0001 with `HM_ID` = `HJOURNEY`. 2. Print `BarPrint10` and `GhatTagPrnt` and open both sheets. 3. Search every label for `HUID:`.
Expected: no `HUID:` text on any sheet. None of the four files places an HM id; the placed formulas are `@ACName`, `@ItmWt`, `@Labour`, `@OtherAmt`, `@LessWt` (BarPrint13 only), `@TagNo`, `@OtherDetl`, plus `CO_MAST.CO_NAME`, `ITEM_MAST.GR_CODE`, `TAG_PRINT_DATA.IT_CODE` and `TAG_PRINT_DATA.TAG_NO` (BarPrint13.xml:205 {{FormulaName="{@ACName}"}} and BarPrint13.xml:208 {{'G.'+totext({TAG_PRINT_DATA.ITM_GWT},3)}}). Architect decision above: drop the web's `HUID:` line. Today the web prints `HUID: ` (`tagPrint.ts:481 {{HUID: }}`), so this fails.
Status: executable

### tag-print.output.qr-picture   (T16 Report/output) — Gap 10
Layer: browser
Steps: 1. Set `QR_CODE_GEN` = Y and seed a QR `PRINT_MAST` row `QrPrint10` (Y). 2. Print voucher 88001 with `QrPrint10` and open the sheet. 3. Decode each real label's QR image (for example with a QR decoder in the test) and check the blank labels.
Expected: each of the three real labels carries one QR image that decodes to its tag number (`TP0001`, `TP0002`, `TP0003`); the two blank labels carry none. The web generates the image in the sheet from the tag number; it must not write `IMAGE_DATA` or issue the unscoped `DELETE FROM IMAGE_DATA` (study weaknesses 2 and 3). The desktop writes `IMAGE_DATA` (UT_TAG_PRINT.cs:5181 {{dataRow["TAG_IMAGE"] = value;}}) and QrPrint10 prints that field (QrPrint10.xml:386 {{<Field Description="" FormulaForm="{IMAGE_DATA.TAG_IMAGE}"}}). Today the web prints no QR image, so this fails.
Status: executable

### tag-print.output.master-fields   (T16 Report/output) — Gap 11
Layer: browser
Steps: 1. Seed `CO_MAST.CO_NAME` = `E2E SHOP`, `BAR_DETL.KR_NAME` = `KARI-1`, and `ITEM_MAST.GR_CODE` = `E1` for `TPG1`. 2. Print each of the four files for TP0001 and open the sheet. 3. Search each label.
Expected: every sheet shows `KARI-1` (karigar), `E2E SHOP` (shop) and `E1` (purity group), together with `TPG1` and `TP0001`. The karigar formula is `{TAG_PRINT_DATA.KR_NAME}` (BarPrint13.xml:205 {{{TAG_PRINT_DATA.KR_NAME}}}), and all four place `CO_MAST.CO_NAME`, `ITEM_MAST.GR_CODE`, `TAG_PRINT_DATA.IT_CODE` and `TAG_PRINT_DATA.TAG_NO` (the DataSource lists of QrPrint10.xml, BarPrint10.xml, BarPrint13.xml and GhatTagPrnt.xml). Today the web's sheet selects tag, item, design, table and HM id only (`tagPrint.ts:352 {{SELECT b."TAG_NO" tag,b."IT_CODE" it,b."DESIGN_NO" dn,b."TBL_CODE" tc,b."HM_ID" hm,}}`) and prints no karigar, shop or purity, so this fails.
Status: executable

### tag-print.output.less-weight-line   (T16 Report/output) — Gap 12
Layer: browser
Steps: 1. Print `BarPrint13` for TP0001 (`ITM_GWT` 10.500, `ITM_NWT` 10.000). 2. Print `BarPrint10` for the same tag. 3. Search both sheets for `L.`.
Expected: BarPrint13 shows `L.0.500`; BarPrint10 shows no `L.` line. The formula is gross minus net with three decimals (desktop: BarPrint13.xml:217 {{'L.'+totext({TAG_PRINT_DATA.ITM_GWT}-{TAG_PRINT_DATA.ITM_NWT},3)}}). Today the web has no `L.` line, so this fails.
Status: executable

### tag-print.output.barcode-text   (T16 Report/output) — Gap 12
Layer: browser
Steps: 1. Print `BarPrint10`, `BarPrint13`, `GhatTagPrnt` and `QrPrint10` for TP0001. 2. Read each sheet's barcode area.
Expected: `BarPrint10`, `BarPrint13` and `GhatTagPrnt` show the text `*TP0001*`; `QrPrint10` shows a QR image instead and no `*TP0001*` text. The barcode text is `'*' + TAG_NO + '*'` (desktop: BarPrint13.xml:225 {{'*' + {TAG_PRINT_DATA.TAG_NO} + '*'}}); QrPrint10 prints the blob instead (QrPrint10.xml:386 {{<Field Description="" FormulaForm="{IMAGE_DATA.TAG_IMAGE}"}}). Today the web prints the bare tag number under a barcode (`tagPrint.ts` `bcnum`), not `*TP0001*`, so this fails.
Status: executable

## T17 Keyboard/usability

**Reused:** `tag-print.keyboard.desktop-keys` (Enter through Book/Vch No, Y/N, Space, arrows, Alt+S, Print with Enter, Esc) and
`tag-print.keyboard.esc-with-focus-on-the-page`.

### tag-print.keyboard.combo-set   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Open `/txn/tag-print`. 2. Focus the `Print file Name` select and choose `BarPrint13` with the standard select keys (Home/End or the first letters). 3. Press Tab and check the focus, then press Enter. 4. Read `PRINT_MAST`.
Expected: the combo changes with the standard select keys, Tab lands on the Set button, and Enter activates Set; the desktop's Set caption is `Set` (UT_TAG_PRINT.cs:1650 {{btnTagSet.Text = "Set";}}). The combo is filled at Load (UT_TAG_PRINT.cs:4936 {{cboPrintfile.Items.Add((object)"");}}); the study found no key handler of its own.
Status: executable

### tag-print.keyboard.alt-p   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Open `/txn/tag-print` and load voucher 88001. 2. Press Alt+P.
Expected: the Print button is activated and the print runs. The desktop's Print mnemonic is `&Print` (UT_TAG_PRINT.cs:1422 {{&Print}}).
Status: executable

## T18 Full journey

### tag-print.journey.chosen-file-to-label   (T18 Full journey) — Gap 1
Layer: browser
Steps: 1. Seed the four files and voucher 88001. 2. Select `BarPrint13`, print, open the sheet and record its fields. 3. Set `GhatTagPrnt`, reopen, print the same voucher, open the sheet and record its fields. 4. Read `PRINT_MAST`.
Expected: the first sheet is BarPrint13's (`L.0.500`, no sub-report line); the second is GhatTagPrnt's (`GLD1 / 1235` and `GLD2 / 99`, `*TP0001*`); `PRINT_MAST` has `GhatTagPrnt` Y and the other three N. The end-to-end chain is combo → print request → staged rows → chosen template → sheet (desktop: UT_TAG_PRINT.cs:5200 {{string text = cboPrintfile.Text;}} and UT_TAG_PRINT.cs:5209 {{Cr.ReportFileName}}). Today the second sheet is the one web layout, so this fails.
Status: executable

**Reused:** `tag-print.journey.hm-id-reaches-the-label` (an HM id reaches `BAR_DETL` and the staged row; its `HUID:` assertion is superseded by `tag-print.output.huid-line-removed` above).

## Coverage table

| Kind | New cases | Reused | Blocked | N/A |
|---|---|---|---|---|
| T01 Entry/defaults | 5 | `entry.defaults` | 0 | 0 |
| T02 Field route | 3 | 0 | 0 | 0 |
| T03 Formula sequence | 4 | 0 | 0 | 0 |
| T04 Lookup | 2 | 0 | 0 | 0 |
| T05 Children | 2 | 0 | 0 | 0 |
| T06 Required/invalid | 3 | 0 | 1 | 0 |
| T07 Create | 2 | 0 | 0 | 0 |
| T08 Reopen/no-op | 1 | `reprint.replaces-staging` | 0 | 0 |
| T09 Edit | 3 | 0 | 0 | 0 |
| T10 Delete/cancel/reverse | 2 | 0 | 0 | 1 (delete) |
| T11 Scope/rights | 2 | `rights.print-and-edit` | 0 | 0 |
| T12 Concurrency | 1 | 0 | 0 | 0 |
| T13 Retry/unknown | 1 | `retry.replayed-print` | 0 | 0 |
| T14 Rollback | 1 | `rollback.stage-fault` | 0 | 0 |
| T15 Config/history | 2 | 0 | 0 | 0 |
| T16 Report/output | 10 | `output.label-sheet`, `output.label-labour-lines` | 0 | 0 |
| T17 Keyboard/usability | 2 | `keyboard.desktop-keys`, `keyboard.esc-with-focus-on-the-page` | 0 | 0 |
| T18 Full journey | 1 | `journey.hm-id-reaches-the-label` | 0 | 0 |
| **Total** | **47** | **10** | **1** | **1** |

Every kind T01–T18 is applied. No kind is dropped silently; the only `N/A` is the delete sub-case of T10, because the
screen has no delete.

## Gap coverage

| Gap | Case(s) |
|---|---|
| 1 — the chosen print file is ignored | `tag-print.field.file-reaches-print`, `tag-print.output.file-choice-per-template`, `tag-print.edit.switch-default-and-reprint`, `tag-print.journey.chosen-file-to-label` |
| 2 — one layout for four files | `tag-print.output.layout-per-file`, `tag-print.required.unknown-file` |
| 3 — SubTagPrint not printed; HUID line added | `tag-print.output.subtagprint-lines`, `tag-print.output.huid-line-removed`, `tag-print.children.barprint13-no-subreport` |
| 4 — the sub-report link differs by file | `tag-print.output.subtagprint-link-per-file`, `tag-print.output.lable-skip-no-subreport-lines`, `tag-print.children.subtagprint-rows-per-parent` |
| 5 — stale note about the files in comments/docs | Not covered (documentation only; see below) |
| 6 — the Set message differs | `tag-print.set.default-message-text`, `tag-print.set.default-switches-only-one-file`, `tag-print.field.set-persists-default` |
| 7 — Set needs the edit right in the web only | `tag-print.rights.set-needs-update` |
| 8 — the default file when none is marked | `tag-print.set.no-default-marked`, `tag-print.print.empty-file` (blocked) |
| 9 — the combo lacks the leading empty item | `tag-print.entry.combo-leading-empty`, `tag-print.entry.no-files-only-empty` |
| 10 — QR picture and IMAGE_DATA row | `tag-print.output.qr-picture`, `tag-print.entry.tag-vs-qr-type`, `tag-print.field.qr-set-separate`, `tag-print.config.qr-mode-files` |
| 11 — karigar, shop name and purity group missing | `tag-print.output.master-fields` |
| 12 — BarPrint13 `L.` line and `*tag*` barcode text | `tag-print.output.less-weight-line`, `tag-print.output.barcode-text`, `tag-print.calc.less-weight`, `tag-print.calc.pcs-and-barcode` |
| 13 — no test covers the residuals | All new cases above; the 19 existing ids remain the base module |

## Test data

The smallest seed for the residual cases. The existing `tagPrint.mjs` helper `withCase(ctx, run, seed)` already seeds the
company, product and items; the residual cases add the four `PRINT_MAST` files and `BAR_IDTL` rows described here.

**Company and settings**

- `CO_CODE` `01`, `LC_CODE` `01`, the latest `CO_YEAR` from `YEAR_MAST` (the module's `ctx.year()`).
- `CO_MAST.METAL_TYPE` NULL for the base cases (the screen shows `Gold`); set to `S` for a Silver check.
- `CO_MAST.CO_NAME` = `E2E SHOP`.
- `CO_SET_NEW.QR_CODE_GEN` = `N` by default; set to `Y` only for the QR cases.

**Masters**

- `PRODUCT_MAST`: `PR_CODE` `TP`, `PR_NAME` `E2E TAGP`.
- `ITEM_MAST`: `TPG1` (`E2E TAG GOLD RING`, type `G`, group `E1`, product `TP`) and `TPS1` (`E2E TAG SILVER RING`, type `S`, group `E2`, product `TP`).
- The group names the lookup shows come from the same rows as the existing module (`E1` / `E2`); no extra group master is needed for the sheet, which reads `ITEM_MAST.GR_CODE` directly.

**PRINT_MAST (TAG rows, `QR_CODE_GEN` = N)**

| PRINT_FILE | PRINT_SET_A |
|---|---|
| `BarPrint10` | `Y` |
| `BarPrint13` | `N` |
| `GhatTagPrnt` | `N` |
| `QrPrint10` | `N` |

For the "none marked" and "two marked" cases, change the `PRINT_SET_A` flags as the case says. For the QR cases, seed a
second set with `PRINT_TYPE` `QR` (`QrPrint10` N, `QrPrint10-ALT` Y). The existing module's `FILES` (`E2E TAG BIG`,
`E2E TAG SMALL`) stay for the reused cases; the residual cases use the four real names above.

**BAR_DETL (voucher 88001, book `TOP`, `CO_CODE` `01`, `LC_CODE` `01`)**

| TAG_NO | SR_NO | VCH_SRNO | IT_CODE | DESIGN_NO | TBL_CODE | ITM_PCS | ITM_GWT | ITM_NWT | ITM_TOUCH | ITM_MRP | LBR_PRC | KR_NAME | HM_ID |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| `TP0001` | 1 | 1 | `TPG1` | `DSG-TP0001` | `T1` | 1 | 10.500 | 10.000 | 91.6 | 55000 | 8 | `KARI-1` | `` |
| `TP0002` | 2 | 2 | `TPG1` | `DSG-NEWER` | `T1` | 1 | 10.500 | 10.000 | 91.6 | 55000 | 8 | `KARI-1` | `` |
| `TP0003` | 3 | 3 | `TPS1` | `DSG-TP0003` | `T2` | 1 | 10.500 | 10.000 | 91.6 | 55000 | 8 | `KARI-1` | `` |

`STK_DATE` `2026-04-02`; `MAIN_STOCK` has the same three tags (the existing helper writes it). `TP0004` / `TP0005` are
only needed by the reused stock cases.

**BAR_IDTL (voucher 88001, book `TOP`, `CO_CODE` `01`, `LC_CODE` `01`)**

| SR_NO | TAG_NO | VCH_SRNO | IT_CODE | IT_AMT |
|---|---|---|---|---|
| 1 | `TP0001` | 1 | `GLD1` | 1234.50 |
| 2 | `TP0002` | 2 | `GLD2` | 99.40 |

No `BAR_IDTL` row has `VCH_NO` `00000`; the Lable Skip blanks therefore match none. The expected sub-report strings are
`GLD1 / 1235` (totext(1234.50,0) rounds half away from zero) and `GLD2 / 99` (99.40 truncates to 99 at zero decimals).

**Expected label texts for this seed**

- All four: `G.10.500`, `N.10.000`, `MRP: 55000`, `KARI-1`, `E2E SHOP`, `E1`, `TPG1`, `TP0001`.
- `BarPrint10`, `BarPrint13`, `GhatTagPrnt`: `*TP0001*`.
- `BarPrint13`: `L.0.500`; no sub-report line.
- `QrPrint10`: a QR image for `TP0001`; no `*TP0001*` text.
- `BarPrint10` / `QrPrint10` TP0001: `GLD1 / 1235`; TP0002: `GLD2 / 99`.
- `GhatTagPrnt` TP0001 and TP0002: both `GLD1 / 1235` and `GLD2 / 99`.
- No sheet has a `HUID:` line.

## Not covered

- **Study Gap 5 — the stale note about the files in `tag-print/page.tsx` and `tagLabelText.test.ts`.** These are comments and test-file prose, not browser or database behaviour; no case can fail on them. The study's fix is to correct both comments and the G240/N225 notes in the implementing change. Listed here so the gap is accounted for.
- **Study OQ4 — the exact Crystal section `Top`/`Left`/`Width`/font of every placed field.** The cases assert the field set and content; pixel geometry is left to the visual protocol and the implementing change's extraction. No case claims a position.
- **Study OQ8 — which of QrPrint10's two blob fields is the QR and which a logo.** Not on the case path: the web generates the QR from the tag number in the sheet and does not read the Crystal blob.
- **The exact barcode symbology.** The cases assert the `*tag*` text and a scannable barcode (the existing `output.label-sheet` asserts an SVG); the desktop's barcode font versus the web's Code39 renderer is a rendering detail.
- **The desktop edition check.** The study records `MISSING: a desktop edition check for this menu`; `menu-editions.json` is the authority for whether the menu is in the edition, not a case.
- **Out of scope per the study.** Voucher/stock selection, Y/N rows, Hm Id Update, the RFID writer, the Print Type box and `MordenJwTag` are already covered by `tagPrint.mjs` or are named-registration features outside this packet.