# WP-34 study: Tag Print residuals (label-file choice, SubTagPrint sub-report)

Scope is only the two residuals the master plan lists after N225/G237/G239/G240: the PRINT_MAST label-file choice
(QrPrint10, BarPrint10, BarPrint13, GhatTagPrnt) and the SubTagPrint sub-report. The rest of the screen is already
covered by `tagPrint.mjs` (see "Web today"). Status of this study: DONE for the scope. The orchestration cite tool
(`orchestration/bin/orch.mjs`) does not exist in this worktree, so every quote was checked with a local script instead
(see the report).

## Scope

- Menu: Other → Tag Print. The dispatch opens the form directly:
  `MDI_FORM.cs:8596 {{case "Tag Print":}}` and `MDI_FORM.cs:8598 {{UT_TAG_PRINT uT_TAG_PRINT = new UT_TAG_PRINT();}}`.
- Form: `UT_TAG_PRINT.cs`, 6,267 lines (form index says 6268).
- Lite edition: the dispatch lines 8596-8605 contain no `MsSoftType` test, and `UT_TAG_PRINT.cs` has no `MsSoftType`
  reference either (grep found none). The edition decision therefore comes only from `menu-editions.json`
  (not read here): MISSING: a desktop edition check for this menu.
- In scope: how the print file is chosen, stored as default, and handed to the report; what the label files print from
  the `SubTagPrint.rpt` sub-report; how the web reproduces both.
- Out of scope: voucher/stock selection, Y/N rows, Hm Id Update (done in N225, 18 browser cases), the RFID writer
  (`BtnRfid_Click`, `UT_TAG_PRINT.cs:6008-6263 {{private void BtnRfid_Click(object sender, EventArgs e)}}`), the Print Type box and `MordenJwTag` (`:5667-6007`), because they are
  named-registration features (see Screen) and not in this packet's list.

## Screen

Only the controls that belong to the residuals:

| Caption | Control | Type | Behaviour |
|---|---|---|---|
| Print file Name | `cboPrintfile` | combo | Filled at Load from PRINT_MAST; first item is an empty string; text set to the default file. |
| Set | `btnTagSet` | button (`BtnTagSet_Click`) | Marks the chosen file as the default of its type. |
| Print Type | `cboPrintType` | combo | Visible only for named registrations; chooses the Gold/Silver/Diamond/... branch of `MordenJwTag`. |
| Rfid | `btnRfid` | button | Visible only for the same registrations. |

Citations:

- Caption text: `UT_TAG_PRINT.cs:1669 {{Print file Name}}` and `UT_TAG_PRINT.cs:1650 {{btnTagSet}}`
  (the caption of `btnTagSet` is "Set", index line 1650).
- Combo filled at Load: `UT_TAG_PRINT.cs:4936 {{cboPrintfile.Items.Add((object)"");}}`.
- Default selection: `UT_TAG_PRINT.cs:4942 {{["PRINT_SET_A"]}}` (compares to "Y") and
  `UT_TAG_PRINT.cs:4954 {{cboPrintfile.Text = text;}}`. When PRINT_MAST has no row the combo holds only the empty item:
  `UT_TAG_PRINT.cs:4952 {{cboPrintfile.Items.Add((object)"");}}`.
- `cboPrintfile.SelectedIndex = 0` is set only when rows exist: `UT_TAG_PRINT.cs:4948 {{cboPrintfile.SelectedIndex = 0;}}`,
  then overwritten by the Text assignment, so a company with files but none marked "Y" ends with an empty Print file
  name (text starts as `""`).
- Print Type and Rfid are hidden unless the registration serial matches a list:
  `UT_TAG_PRINT.cs:4957 {{case "HM340NEKU":}}` and `UT_TAG_PRINT.cs:4975 {{((Control)btnRfid).Visible = true;}}`.
- Tab order and enabled rules for the combo are not extracted here: MISSING: tab index of `cboPrintfile` (read
  `web/apps/api/form-specs/UT_TAG_PRINT.initcomp.json` if the next worker needs it).

## Keyboard

Only what touches the residuals. The form sets KeyPreview: `UT_TAG_PRINT.cs:1805 {{((Form)this).KeyPreview = true;}}`.
Esc closes the form when nothing was changed: `UT_TAG_PRINT.cs:5107 {{if (OldValTot == NewValTot)}}`. Print is reached
by `&Print` (Alt+P): `UT_TAG_PRINT.cs:1422 {{&Print}}`. The combo and Set have no key handler of their own in the member
list (no `cboPrintfile_KeyDown` member in the form index), so Enter and arrow keys are the standard combo behaviour.

## Rules

Messages that matter for the print file:

1. "You Have No Print Rights....." when the user's FRM_PRINT is not "Y", and nothing else happens:
   `UT_TAG_PRINT.cs:5131 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}`; text
   `UT_TAG_PRINT.cs:5133 {{You Have No Print Rights.....}}`. Focus does not move (the handler returns).
2. "Tag Print Report Default Set" after Set:
   `UT_TAG_PRINT.cs:5653 {{Interaction.MsgBox((object)"Tag Print Report Default Set"}}`. Focus does not move.
3. There is no validation of an empty print file. Print with an empty combo goes on and builds the report path from
   the empty text: `UT_TAG_PRINT.cs:5209 {{Cr.ReportFileName}}` (see Print). The desktop gives no message here.
4. Set does not check the Edit right. `BtnTagSet_Click` (`UT_TAG_PRINT.cs:5636-5655 {{private void BtnTagSet_Click(object sender, EventArgs e)}}`) has no `UserEdit` test, while the
   right is read at Load: `UT_TAG_PRINT.cs:4765 {{UserEdit = Conversions.ToString}}`.

## Calculations

None in the file choice. The label text formulas are in the Crystal files, already ported for the four files
(G240): `'G.'+totext(ITM_GWT,3)`, `'N.'+totext(ITM_NWT,3)`, the MRP/LP/LF line. What is not yet ported:

- BarPrint13 only: the less-weight line, `BarPrint13.xml:217 {{'L.'+totext({TAG_PRINT_DATA.ITM_GWT}-{TAG_PRINT_DATA.ITM_NWT},3)}}`
  (gross minus net, three decimals, Crystal `totext` rounds half away from zero; the web already uses that helper).
- All four files: `@TagNo` prints the barcode text `'*' + TAG_NO + '*'`:
  `BarPrint13.xml:225 {{'*' + {TAG_PRINT_DATA.TAG_NO} + '*'}}`.
- All four: `@ACName` is the karigar name: `BarPrint13.xml:205 {{{TAG_PRINT_DATA.KR_NAME}}}`
  (the quote's inner text is `{TAG_PRINT_DATA.KR_NAME}`).
- All four: `@ItemName` is `{TAG_PRINT_DATA.DESIGN}`, `@Pcs` is `totext({TAG_PRINT_DATA.ITM_PCS},'0')`
  (`BarPrint13.xml:223 {{totext({TAG_PRINT_DATA.ITM_PCS},'0')}}`).
- Sub-report line (QrPrint10, BarPrint10, GhatTagPrnt): `BarPrint10.xml:72 {{{BAR_IDTL.IT_CODE} &amp; " / " &amp; totext({BAR_IDTL.IT_AMT},0)}}`,
  one line per BAR_IDTL row: item code, " / ", amount with no decimals.

## Lifecycle and write set

Print (all of `BtnPrint_Click`, `UT_TAG_PRINT.cs:5122-5226 {{private void BtnPrint_Click(object sender, EventArgs e)}}`), in statement order:

1. Rights check (`:5131`), Hm Id check (`:5136-5142`, message "Please First Update Hmid Data and Then print").
2. `UT_TAG_PRINT.cs:5143 {{DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");}}` and
   `UT_TAG_PRINT.cs:5144 {{DC_Main.ExeQuteDc("DELETE FROM IMAGE_DATA");}}` (both unqualified).
3. The Lable Skip blanks: `UT_TAG_PRINT.cs:5147 {{Math.Round(Conversion.Val(nLableSkip.Text))}}`.
4. One INSERT into TAG_PRINT_DATA per Y row (`:5151`), copying the BAR_DETL columns.
5. Only with QR generation on (`MsQrCodeGen` = "Y"): per row a QR bitmap is built from the tag number and inserted into
   IMAGE_DATA: `UT_TAG_PRINT.cs:5165 {{QRCodeGenerator val = new QRCodeGenerator();}}`,
   `UT_TAG_PRINT.cs:5181 {{dataRow["TAG_IMAGE"] = value;}}`, keyed by tag and VCH_SRNO (`:5170` reads IMAGE_DATA by
   `TAG_NO` and `VCH_SRNO`).
6. `UT_TAG_PRINT.cs:5189 {{DC_Main.RsQry = "SELECT * FROM TAG_PRINT_DATA";}}`, then the print dialog
   `UT_TAG_PRINT.cs:5191 {{((Form)MyProject.Forms.MS_PRINT).ShowDialog();}}`; "CANCEL" returns
   (`UT_TAG_PRINT.cs:5192 {{if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)}}`).

Set (`BtnTagSet_Click`, `:5636-5655`), two statements per mode, TAG and QR are separate sets:

- QR mode: `UT_TAG_PRINT.cs:5639 {{if (Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0)}}`, clear then set.
- Clear: `UT_TAG_PRINT.cs:5641 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'N'}}`; set:
  `UT_TAG_PRINT.cs:5643 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'Y'}}`. The TAG branch does the same at `:5648` and `:5650`.
- The two updates run without a transaction, and the second matches by `PRINT_FILE` text, so an unknown or empty name
  clears the default and sets nothing.

Load reads (`:4924-4954`): `UT_TAG_PRINT.cs:4926 {{PRINT_TYPE = 'QR' ORDER BY PRINT_FILE}}` when QR is on, else
`UT_TAG_PRINT.cs:4930 {{PRINT_TYPE = 'TAG' ORDER BY PRINT_FILE}}`; the default is the file marked "Y" (last one wins in the
loop, since there is no break).

Reports: the SubTagPrint sub-report is read only, from BAR_IDTL; see Print.

## Print

- Template choice: the file name in the combo, nothing else. Crystal "O" (old) mode:
  `UT_TAG_PRINT.cs:5209 {{Cr.ReportFileName}}` is `<app dir>\Report\<cboPrintfile.Text>.RPT`, selection
  `UT_TAG_PRINT.cs:5210 {{Cr.SelectionFormula = "{TAG_PRINT_DATA.CO_CODE} = '"}}`. Crystal "N" (new) mode hands the same
  name to the report viewer: `UT_TAG_PRINT.cs:5200 {{string text = cboPrintfile.Text;}}`,
  `UT_TAG_PRINT.cs:5202 {{DC_Main.RptName = text;}}`, `UT_TAG_PRINT.cs:5203 {{DC_Main.RptFormula = "{TAG_PRINT_DATA.CO_CODE} = '"}}`.
  No parameters are passed; the print-rights check is at `:5131`.
- Files known in the repository (extracted XML): QrPrint10, BarPrint10, BarPrint13, GhatTagPrnt; each reads TAG_PRINT_DATA.
  Which names exist in PRINT_MAST of a given company is data, not source: MISSING: PRINT_MAST seed rows of the test tenant.
- **SubTagPrint.rpt is extracted.** The earlier lineage note (G240) says it is not; the XML of three label files embeds it:
  `QrPrint10.xml:11 {{<Report Name="SubTagPrint.rpt">}}`, `BarPrint10.xml:11 {{<Report Name="SubTagPrint.rpt">}}`,
  `GhatTagPrnt.xml:11 {{<Report Name="SubTagPrint.rpt">}}`. BarPrint13 has none:
  `BarPrint13.xml:10 {{<SubReports />}}`.
- Sub-report data: table BAR_IDTL, one line per row, formula
  `BarPrint10.xml:72 {{{BAR_IDTL.IT_CODE} &amp; " / " &amp; totext({BAR_IDTL.IT_AMT},0)}}`; the main report places it in a
  growable box next to the weights:
  `BarPrint10.xml:415 {{<SubreportObject Name="Subreport1" Kind="SubreportObject" Top="240" Left="780"}}`
  (QrPrint10 at `QrPrint10.xml:483`, left 2325; GhatTagPrnt at `GhatTagPrnt.xml:452`, left 780).
- The link to the main report differs per file:
  - BarPrint10 matches company, tag and VCH_SRNO: `BarPrint10.xml:100 {{<SubReportLink LinkedParameterName="{?Pm-TAG_PRINT_DATA.TAG_NO}"}}`
    and `BarPrint10.xml:101 {{<SubReportLink LinkedParameterName="{?Pm-TAG_PRINT_DATA.VCH_SRNO}"}}`.
  - QrPrint10 matches company, LC, year, book, VCH_NO and SR_NO of the staged row (not the tag):
    `QrPrint10.xml:119 {{<SubReportLink LinkedParameterName="{?Pm-TAG_PRINT_DATA.SR_NO}"}}`.
  - GhatTagPrnt matches company, LC, year, book and VCH_NO, with no SR_NO and no tag:
    `GhatTagPrnt.xml:102 {{<SubReportLink LinkedParameterName="{?Pm-TAG_PRINT_DATA.VCH_NO}"}}`.
    For the Lable Skip blanks, VCH_NO is `00000`, so they match no BAR_IDTL rows (`:5149`, see Lifecycle).
    For a real voucher, GhatTagPrnt therefore prints **every** BAR_IDTL line of the whole voucher on each label
    (inferred from the five links; no sixth link exists at lines 98-102). QrPrint10 prints the lines of that one voucher
    row (SR_NO). BarPrint10 prints the lines of that tag and VCH_SRNO. This difference is a gap for the case list.
- QrPrint10 also prints a QR picture from IMAGE_DATA:
  `QrPrint10.xml:386 {{<Field Description="" FormulaForm="{IMAGE_DATA.TAG_IMAGE}"}}` and a blob field at
  `QrPrint10.xml:576 {{<BlobFieldObject Name="Field2" Kind="BlobFieldObject" Top="45" Left="1055"}}`.
- Fields placed by each main file (DataSource list): all four place `@ACName` (karigar), `@ItmWt`, `@Labour`,
  `@OtherAmt`, `CO_MAST.CO_NAME` (shop), `ITEM_MAST.GR_CODE`, `TAG_PRINT_DATA.IT_CODE` and `TAG_PRINT_DATA.TAG_NO`;
  BarPrint13 also `@LessWt` and no sub-report; BarPrint10 and GhatTagPrnt also `@TagNo` (the `*tag*` barcode text) and
  `@OtherDetl`. Position values are in the XML (`BarPrint10.xml:424`, Field4 Labour at Top 585).

## Rights

- Load reads the user's row: `UT_TAG_PRINT.cs:4760 {{Select * From USER_SET WHERE LC_CODE}}` (the index lists USER_SET read
  at 4760), FRM_EDIT into `UserEdit` (`:4765`), FRM_DELETE (`:4766`), FRM_PRINT into
  `UT_TAG_PRINT.cs:4767 {{UserPrint = Conversions.ToString}}`.
- Print needs FRM_PRINT = "Y" (`:5131`, message above). Set and the combo have no right test (Rules item 4).

## Desktop weaknesses not to port

1. String-built SQL with the file name typed into it: `UT_TAG_PRINT.cs:5643 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'Y'}}`
   (the statement concatenates `cboPrintfile.Text`).
2. Unscoped delete: `UT_TAG_PRINT.cs:5144 {{DC_Main.ExeQuteDc("DELETE FROM IMAGE_DATA");}}` removes the pictures of every
   company and every user (the web already scopes TAG_PRINT_DATA to the tenant and leaves IMAGE_DATA alone).
3. `DELETE FROM TAG_PRINT_DATA` (`:5143`) is global too: two users printing at once overwrite each other.
4. Set is two non-atomic statements: `UT_TAG_PRINT.cs:5641 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'N'}}` then `:5643`; a
   failure between them leaves no default.
5. An empty or unknown report name is accepted (`:5209`), and the viewer fails at run time with Crystal's own error.
6. Unqualified `SELECT * FROM TAG_PRINT_DATA` (`:5189`); the filter is only the report's selection formula by CO_CODE
   (`:5210`), so rows of other users and branches (LC_CODE) are printed if present.

## Web today

- `web/apps/web/app/(app)/txn/tag-print/page.tsx`: the screen. Loads the file list into the combo, Set posts the file,
  Print stages and then opens the label sheet. The combo's value is never sent with Print.
- `web/apps/api/src/modules/stock/tagPrintScreen.ts`: `tagPrintSetup` (load files and default), `tagPrintSetDefault` (Set),
  `tagPrintStage` (Print staging, no file argument).
- `web/apps/api/src/routes/tagPrintScreen.ts`: routes `GET /stock/tag-print-screen`, `POST .../default-file`,
  `POST .../print`, `GET .../labels` (the sheet; no file parameter).
- `web/apps/api/src/modules/stock/tagPrint.ts`: the one HTML label sheet and `tagLabelLines` (G240 formulas).
- Tests: `web/apps/api/test/tagPrintScreen.db.test.ts`, `tagPrintStaging.db.test.ts`, `tagLabelText.test.ts`; browser
  module `web/apps/web/test/features/modules/tagPrint.mjs` (1,173 lines).
- Case state of `tagPrint.mjs`: the module lists 19 quoted case ids (first at line 256, last at `:1128`) and the lineage
  records 18 of 18 applicable. A search for `blocked`, `pending`, `skip` (ignoring the Lable Skip box) found no blocked,
  pending or skipped case. The residuals are therefore not tracked as cases at all: no case chooses a file, no case
  asserts a sub-report line. The ids: entry.defaults, field.every-field, field.typing-and-formats, lookup.helps,
  children.grid-rows, required.refusals, create.footprint, reprint.replaces-staging, hm.update-boxes,
  rights.print-and-edit, concurrency.last-print-wins, retry.replayed-print, rollback.stage-fault,
  history.stock-spans-years, output.label-sheet, output.label-labour-lines, keyboard.desktop-keys,
  keyboard.esc-with-focus-on-the-page, journey.hm-id-reaches-the-label.
- Lineage rows: G237 (`12-lineage-verification-2026-10-01.md:252`) says Set "marks the default label file"; G239 (`:254`) is
  Esc; G240 (`:255`) lists as "Not closed": "the PRINT_MAST file choice (the web has one sheet), the shop name, the purity
  group and the karigar name ..., the QR picture, the `SubTagPrint.rpt` sub-report (not extracted), `BarPrint13`'s `L.`
  less-weight line, and the layout sizes".

## Gaps

1. **The chosen print file is ignored (wrong result).** Desktop: the combo text selects the template:
   `UT_TAG_PRINT.cs:5209 {{Cr.ReportFileName}}`. Web: `tagPrintScreen.ts` Print takes no file
   (`tagPrintScreen.ts:494 {{export async function tagPrintStage(}}`), the route passes `book`, `labelSkip`, `tags`
   (`tagPrintScreen.ts:120 {{labelSkip: b.labelSkip,}}`), and `GET .../labels` takes none
   (`tagPrintScreen.ts:125 {{app.get('/stock/tag-print-screen/labels'}}`). Fix: send `file` with Print, store it with
   the staging or pass it to `labels`, and render one layout per file.
2. **One layout for four files (missing feature).** Desktop: four Crystal files with different content (Screen/Print
   above: `@LessWt` only in BarPrint13, `@TagNo` and sub-report in the others, QR picture only in QrPrint10). Web:
   `tagPrint.ts:460 {{Render a print-ready HTML sheet of jewellery tag labels}}` has a single layout. Fix: a per-file
   layout table (field set and positions from the XML) with the file name as the key; unknown names refuse.
3. **SubTagPrint sub-report not printed (missing feature).** Desktop: `BarPrint10.xml:72 {{{BAR_IDTL.IT_CODE} &amp; " / " &amp; totext({BAR_IDTL.IT_AMT},0)}}`
   per BAR_IDTL row in QrPrint10, BarPrint10 and GhatTagPrnt, none in BarPrint13 (`BarPrint13.xml:10 {{<SubReports />}}`).
   Web: BAR_IDTL is not read by the label code (no `BAR_IDTL` reference in `tagPrint.ts` or `tagPrintScreen.ts`), and the
   web instead prints a hallmark line `tagPrint.ts:481 {{HUID: }}`, which none of the label files has. Fix: read BAR_IDTL
   with the file's link keys (Gap 4) and print `IT_CODE / amount(0 decimals)`; keep or drop the HUID line only by decision
   (see Open questions).
4. **The sub-report link differs by file (wrong result when unmodelled).** BarPrint10 links company, tag, VCH_SRNO
   (`BarPrint10.xml:101`), QrPrint10 links the staged voucher row including SR_NO (`QrPrint10.xml:119`), GhatTagPrnt links
   only up to VCH_NO (`GhatTagPrnt.xml:102`), so it repeats the whole voucher's lines on each label (inferred). The
   Lable Skip blanks (VCH_NO 00000) print no sub-report lines. Fix: model each link as written; add a case where a voucher
   with two tags and two BAR_IDTL rows each prints per file.
5. **Sheet shows a stale note about the files (wrong text, comments and docs).** `tag-print/page.tsx:25 {{Print shows the web's label sheet because the Crystal label files are not in the repository}}`
   and `tagLabelText.test.ts:111 {{QrPrint10, BarPrint10 and GhatTagPrnt embed SubTagPrint.rpt, which is not}}` say the
   report is missing, but the XML is extracted. Fix: correct both comments and the G240 and N225 notes in document 12 and
   `menu-catalog.md` in the implementing change (not here: the packet forbids edits).
6. **The Set message differs (wrong text).** Desktop: `UT_TAG_PRINT.cs:5653 {{Interaction.MsgBox((object)"Tag Print Report Default Set"}}`.
   Web: `tag-print/page.tsx:630 {{is the default label file.}}` (full text `${file} is the default label file.`). Fix: show the
   desktop text verbatim.
7. **Set needs the edit right in the web only (deliberate difference, needs a decision).** Desktop has no right test in
   `BtnTagSet_Click`; web: `routes/tagPrintScreen.ts:109 {{if (!guard(req, reply, 'update')) return;}}`. Keep as a documented
   difference or follow the desktop; this needs the owner (see Open questions).
8. **Default file when none is marked (wrong result).** Desktop leaves the box empty (`:4954` with `text` still `""`).
   Web: `tagPrintScreen.ts:161 {{defaultFile: marked ? text(marked.PRINT_FILE) : (names[0] ?? ''),}}` picks the first file.
   Fix: return an empty default, and refuse or choose by rule for an empty file on Print (the desktop passes it to Crystal
   and fails; the web must show a message, no desktop text exists: MISSING).
9. **The combo lacks the leading empty item (missing feature).** Desktop: `UT_TAG_PRINT.cs:4936 {{cboPrintfile.Items.Add((object)"");}}`.
   Web: the select lists `files` only (`tag-print/page.tsx:845 {{{files.map((f) => (}}`).
10. **QR mode: QR picture and the IMAGE_DATA row are not produced (missing feature, QrPrint10).** Desktop writes the QR into
    IMAGE_DATA per row (`UT_TAG_PRINT.cs:5181 {{dataRow["TAG_IMAGE"] = value;}}`) and the file prints it (`QrPrint10.xml:386`). Web: the layout notes say
    "the QR picture (named registrations only) are left out" (`tagPrintScreen.ts:29`). The web must generate a QR image
    from the tag number in the sheet instead of writing IMAGE_DATA (not porting the unscoped delete, weakness 2).
11. **Karigar, shop name and purity group are not on the label (missing feature).** Desktop: `BarPrint13.xml:205 {{{TAG_PRINT_DATA.KR_NAME}}}`
    and `CO_MAST.CO_NAME`, `ITEM_MAST.GR_CODE` placed in all four. Web: `tagPrintScreen.ts:121 {{krCode: text(r.KR_NAME)}}` feeds the grid only; the sheet's own query
    (`tagPrint.ts:352`) selects tag, item, design, table and HM id, and no `krCode` is used in `tagPrint.ts` (grep).
12. **`@LessWt` of BarPrint13 and the `*tag*` barcode text (missing feature).** `BarPrint13.xml:217 {{'L.'+totext({TAG_PRINT_DATA.ITM_GWT}-{TAG_PRINT_DATA.ITM_NWT},3)}}`
    and `BarPrint13.xml:225 {{'*' + {TAG_PRINT_DATA.TAG_NO} + '*'}}`; web has no `L.` line (listed Not closed in G240).
13. **No test covers any of the above (missing test).** The 19 ids in `tagPrint.mjs` have no case that selects a file,
    prints a sub-report line, or reads Set's message text. New cases needed at least: `output.file-choice-per-template`,
    `output.subtagprint-lines` (per file), `output.subtagprint-link-per-file`, `output.lable-skip-no-subreport-lines`,
    `set.default-message-text`, `set.default-switches-only-one-file`, `set.no-default-marked`, `print.empty-file`.

Fix order for the next workers: (1) pass the file and store it; (2) the four layouts; (3) BAR_IDTL sub-report with the three
link rules; (4) messages and defaults (Gaps 6, 8, 9); (5) QR; (6) comments and documents.

## Open questions

1. Is the web's deliberate `HUID:` line to stay? The desktop files print none (G240 says the same). Needs the owner.
2. Does Set need the edit right in the web (Gap 7)? Desktop has none.
3. What should the web do on an empty print file at Print? The desktop passes an empty name to Crystal; no message exists
   (Gap 8).
4. The Crystal sections' exact positions and fonts per file (XML `Top/Left/Width` values) are available but I have not mapped
   all fields to pixel layouts; the next worker should extract them from the four XML files.
5. Count of cases: the module lists 19 ids, the lineage says 18 of 18; the extra id is unexplained.
6. Which files exist in PRINT_MAST of the seed company (data question; aggregate query only).
7. Whether GhatTagPrnt really prints the whole voucher's BAR_IDTL lines per label: derived from its five links; the
   desktop runtime was not run (`:` inferred).
8. `QrPrint10.xml:576` blob fields Field1/Field2: which of the two is the QR and which a logo/other image was not checked.
