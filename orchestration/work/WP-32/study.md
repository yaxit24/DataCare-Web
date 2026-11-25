# WP-32 study: Tag Opening and Only Tag Entry residuals

This study covers only the items left in WP-32: the five blocked browser cases, the tag label print, the sources of the G217 karigar block, and the COL_MAST grid. Everything else on the screen is already ported (N203, N204). Desktop file is `unified/src/csharp/DataCareNext/TR_TAG_OPBL.cs` (14,665 lines). All line numbers below are in that file unless another file is named.

## Scope

- Menus: Master → Tag Opening and Transaction → Only Tag Entry. Both open the one form `TR_TAG_OPBL`.
- Dispatch for Tag Opening: `MDI_FORM.cs:7700 {{case "Tag Opening":}}` then `MDI_FORM.cs:7701 {{DC_Main.CurBookHelp("OPSTK");}}`. Dispatch for Only Tag Entry: `MDI_FORM.cs:8574 {{case "Only Tag Entry":}}` then `MDI_FORM.cs:8575 {{DC_Main.CurBookHelp("TAG GEN");}}`. Both set the form caption from the menu text and show it as an MDI child.
- The two modes differ only by the book family. The form later tests `FormMainBook` for "TAG GEN": `TR_TAG_OPBL.cs:10813 {{(Operators.CompareString(FormMainBook, "TAG GEN", false) == 0)}}` (see Rules).
- Lite edition: the form reads `MsSoftType` in three places. The Style column shows only for editions A and E: `TR_TAG_OPBL.cs:5101 {{(Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}}`. No rule hides a mode of this form in Lite; both menus are in scope.
- Out of scope: Tag Re Number, New Tag Img, Old New Tag, Jeson Creat, LastYear Idtl, Stk to Vch Imp, Excel and RFID buttons (`:13284-14656`). They are not in the WP-32 list. The weighing scale and the order/manufacturing/lot header are covered only as karigar-block sources.
- Open lineage rows: G214, G215, G216 and G217 are implemented-unverified in `12-lineage-verification-2026-10-01.md` (N203, N204). G217's "Not covered" paragraph is the source of Gap 5. G173 (no fault injector) is the source of the rollback block (Gap 4). No other open row names these menus.

## Screen

Captions come from the form index (designer lines 3056-3844). Tab order and defaults are not read here (see Open questions).

| Caption | Control | Line | Note |
|---|---|---|---|
| Tag Oppning | lblBook | 3056 | `:3056` book label text, spelling as the desktop |
| Vch Date / Vch No | lblBDate, Label2 | 3073, 3083 | voucher number box default `00001` (`:10352`) |
| &Print, &Save, &Cancel, &Delete, E&xit | BtnPrint … BtnExit | 3122-3175 | Print is guarded by FRM_PRINT |
| Print Type, Print file Name, Set | lblPrintType, cboPrintfile, btnTagSet | 3250, 3412, 3443 | label file chooser and its default setter |
| Lable Skip | nLableSkip | 3453 | count of blank labels at the sheet start |
| Itm Code, Vch Desc, Employee, Item Wt | tItCode, tVchDesc, tEmpCode | 3492-3565 | Itm Code is the stock item for Only Tag Entry |
| HuWt, HuId2/3/4, It Type, Lot No | nHmWt…, cboItType, tLotNo | 3603-3712 | lot header feeds the karigar block |
| &Tag Re Number, New Tag Img, Old New Tag, DType, &Jeson Creat, &LastYear Idtl, Stk to Vch Imp | buttons | 3734-3824 | out of scope |

Grid (`MSG`, 112 columns): `TR_TAG_OPBL.cs:5065 {{mSG.Cols = 112;}}`. Headers are set in code and then renamed from COL_MAST (see Calculations and Gaps 6-7). Karigar columns 17-23 have headers "KrOthWt", "KrNwt", "KrGht%", "KrGht", "KrTouch", "KrWst%", "KrFine" (`:5146-5172`, e.g. `TR_TAG_OPBL.cs:5156 {{DC_Main.MsUserKrTouchHide, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) != 0)}}` zeroes the width of columns 21-23 for a non-admin).

## Keyboard

Handlers in the index: `TR_TAG_OPBL_KeyDown` 11436-11468, `TR_TAG_OPBL_KeyPress` 10709-10723, `TR_TAG_OPBL_KeyUp` 12798-12831, `TEXT_ENTRY_KeyDown` 7606-9182, `tVchNo_KeyDown` 11879-11906, `mVchDate_KeyDown` 11913-11940. The voucher number box keys are ported by N172/N203. This study did not re-read the grid key handler; the print path has one grid key effect: Enter on the last row's last cell calls the row print and the auto save: `TR_TAG_OPBL.cs:9112 {{if (Operators.CompareString(DC_Main.MsTagRowAutoPrint, "Y", false) == 0)}}` then `TR_TAG_OPBL.cs:9114 {{TagLastRowPrint((int)Math.Round(Conversion.Val(mSG[mSG.Row, 0])));}}`, after `TR_TAG_OPBL.cs:9108 {{if (Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0)}}` saves a temporary copy.

## Rules

Messages are verbatim. After each message the desktop re-enables Save (`BtnSave.Enabled = true`).

- No right to save or edit: `TR_TAG_OPBL.cs:10787 {{You Have No Rights.....}}`. The condition is `UsUPdate != "Y"` and (`UserEdit != "Y"` in edit mode), at `:10786`. Focus: none moved; Save re-enabled.
- Counter mandatory (CNTR_STK on): `TR_TAG_OPBL.cs:10793 {{if (Operators.CompareString(DC_Main.MsCntrStk, "Y", false) == 0)}}`, then per row with a blank counter cell (column 6): `TR_TAG_OPBL.cs:10801 {{Please Insert Counter Code and Try Because It is Mandatory...}}`. Focus: row M, column 6 of the grid, then the entry box.
- Only Tag Entry needs the stock item: `TR_TAG_OPBL.cs:10815 {{Stock item code Insert First...}}`, focus `tItCode`.
- Print right: `TR_TAG_OPBL.cs:11479 {{You Have No Print Rights.....}}` (BtnPrint_Click), same text at `:12998` for Excel.
- Delete right and sold-tag refusal: `TR_TAG_OPBL.cs:11383 {{You Cant Delete This Voucher Because  Tag Use in Sales Transection....}}`; confirm `TR_TAG_OPBL.cs:11387 {{Are You Sure To Delete This Voucher now?}}`; result `TR_TAG_OPBL.cs:11431 {{Delete Success.}}`.
- Default label file set: `TR_TAG_OPBL.cs:12362 {{Tag Print Report Default Set}}`.
- Other save refusals already ported by N203: `TR_TAG_OPBL.cs:10750 {{Please Change VchNo its Not Valid......}}`, `TR_TAG_OPBL.cs:10762 {{Please Select Employee Code and Try......}}`, `TR_TAG_OPBL.cs:8562 {{Duplicate Tag No}}`.

## Calculations

- Label skip count: `TR_TAG_OPBL.cs:11485 {{int num = (int)Math.Round(Conversion.Val(nLableSkip.Text));}}`. .NET `Math.Round` is banker's rounding (half to even): 2.5 gives 2, 3.5 gives 4.
- Karigar block (CommPassTotal `:6679-6826`, ported as `tagKarigarBlock`; N204): KrNwt = gross − KrOthWt; KrFine = (KrNwt + KrGht) × (KrTouch + KrWst%) / 100. Already ported; this study only adds the sources that fill the block from outside the grid (Gap 5).
- Karigar defaults from a lot header: when the row source is "A" and the lot touch is non-zero the row takes the lot touch and wastage: `TR_TAG_OPBL.cs:5579 {{if ((Operators.CompareString(mSG[mSG.Row, 69], "A", false) == 0) & (Conversion.Val(nLotTouch.Text) != 0.0))}}`. At save with no KrTouch typed: `TR_TAG_OPBL.cs:10990 {{if ((mSG[21] == 0) & (Operators.CompareString(tLotNo.Text, "", false) != 0) & (Conversion.Val(nLotTouch.Text) != 0.0))}}`, then `TR_TAG_OPBL.cs:10994 {{dataRow3["KR_TOUCH"] = Strings.Format((object)Conversion.Val(nLotTouch.Text), "0.00");}}` and `TR_TAG_OPBL.cs:10995 {{dataRow3["KR_WEST_PRC"] = Strings.Format((object)Conversion.Val(nLotWestPrc.Text), "0.00");}}`.
- Karigar fine from lot touch: `TR_TAG_OPBL.cs:10996 {{if ((Conversion.Val(mSG[DC_Main.i, 18]) != 0.0) & (Conversion.Val(nLotTouch.Text) != 0.0))}}` writes (KrNwt + KrGht) × (lot touch + lot wastage) / 100.
- Manufacturing path copies weights from the source row and derives touch: `TR_TAG_OPBL.cs:8587 {{mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");}}`, `TR_TAG_OPBL.cs:8593 {{mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");}}`, `TR_TAG_OPBL.cs:8595 {{mSG[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");}}`; with KrNwt and KrFine non-zero, touch = KrFine × 100 / KrNwt, "0.00" (`:8596-8598`).
- Order path copies design links: `TR_TAG_OPBL.cs:8336 {{mSG[DC_Main.i, 90] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ORD_SRNO"]);}}` and size and pieces at `:8331-8332`.

## Lifecycle and write set

Save and delete are already ported (N203). Residual facts needed for the print and block cases:

- Save replaces the voucher: DELETE then insert, in `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`: `TR_TAG_OPBL.cs:10858 {{DELETE FROM BAR_DATA WHERE CO_CODE}}`, `:10860` BAR_DETL, `:10862` BAR_IDTL, inside one transaction object (`Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran)`). This transaction is the source of the rollback case (Gap 4).
- Delete order: per tag `SRNO_MAST` (`TR_TAG_OPBL.cs:11421 {{DELETE FROM SRNO_MAST WHERE CO_CODE}}`) and `TAG_IMAGE_DATA` (`:11422`); then `MAIN_STOCK` (`:11426`), `LOT_DETL` (`:11427`), `BAR_DATA`, `BAR_DETL`, `BAR_IDTL` (`:11428-11430`); then the message `TR_TAG_OPBL.cs:11431 {{Delete Success.}}`. Unlike the save, these are plain `ExeQuteDc` calls, not one transaction.
- Print staging (BtnPrint_Click): `TR_TAG_OPBL.cs:11482 {{DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");}}`; then one blank row per skipped label, ending `TR_TAG_OPBL.cs:11489 {{Conversions.ToString(DC_Main.i) + ",'00',0)"}}` (IT_CODE '00', VCH_SRNO 0); then, when QR generation is on and the form is in edit mode with rows, `DELETE FROM IMAGE_DATA` and one QR picture per tag: `TR_TAG_OPBL.cs:11493 {{(Operators.CompareString(EntryMode, "E", false) == 0) & (MSG.Rows > 1)}}`; then the real rows copied from BAR_DETL with the 58-column statement at `TR_TAG_OPBL.cs:11523 {{ITM_COLOR,LBR_CODE,ITM_STYLE  FROM BAR_DETL WHERE CO_CODE}}` for voucher `CurPrnVch`.
- Single row print: `TagLastRowPrint` `TR_TAG_OPBL.cs:9189 {{DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");}}` then the same insert for one SR_NO (`:9190`), optional QR image, then direct print to the printer.
- Default label file: `BtnTagSet_Click` clears PRINT_SET_A then sets it for the chosen file: `TR_TAG_OPBL.cs:12357 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'N' WHERE  CO_CODE}}` and `TR_TAG_OPBL.cs:12359 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'Y' WHERE  CO_CODE}}` with `PRINT_TYPE = 'TAG'`; with QR generation on the same two statements use `PRINT_TYPE = 'QR'` (`:12350`, `:12352`).
- The file list: `TR_TAG_OPBL.cs:10086 {{PRINT_TYPE = 'QR' ORDER BY PRINT_FILE}}` when QR generation is on, else `TR_TAG_OPBL.cs:10090 {{PRINT_TYPE = 'TAG' ORDER BY PRINT_FILE}}`.

## Print

- Right check: `TR_TAG_OPBL.cs:11477 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}`; UserPrint comes from USER_SET `FRM_PRINT` (`TR_TAG_OPBL.cs:9834 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}`).
- Template: the Crystal file name is the one chosen in `cboPrintfile`, from the shared form `.RPT` folder: `TR_TAG_OPBL.cs:11551 {{Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath}}`. No fixed template name exists in this form; the names live in PRINT_MAST rows of type TAG or QR.
- Selection formula: `TR_TAG_OPBL.cs:11538 {{DC_Main.RptFormula = "{TAG_PRINT_DATA.CO_CODE} = '"}}`. The report reads all staged rows (`SELECT * FROM TAG_PRINT_DATA`).
- Parameters: none besides the selection formula. Preview or direct print follows the MS_PRINT dialog answer.
- Auto print per row: `MsTagRowAutoPrint` (see Keyboard).

## Rights

- `TR_TAG_OPBL.cs:9827 {{Select * From USER_SET WHERE LC_CODE}}` loads FRM_EDIT, FRM_DELETE, FRM_PRINT for the menu; the row fields are `TR_TAG_OPBL.cs:9833 {{UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));}}`.
- Per-voucher rights from the stored voucher: `TR_TAG_OPBL.cs:10414 {{UsUPdate = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["USER_UPDATE"], (object)""));}}` and `TR_TAG_OPBL.cs:10415 {{UsDelete = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["USER_DELETE"], (object)""));}}`.
- Messages: "You Have No Rights....." (save `:10787`, delete `:11374`, row delete `:4254`), "You Have No Print Rights....." (`:11479`).

## Desktop weaknesses not to port

- SQL built by joining strings everywhere, for example `TR_TAG_OPBL.cs:12359 {{AND PRINT_FILE = '" + cboPrintfile.Text + "' AND PRINT_TYPE = 'TAG}}`.
- `TR_TAG_OPBL.cs:11482 {{DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");}}` deletes the staging table with no voucher filter: the staging is shared by every user of the company. The web stages per operator scope.
- The delete of a voucher is not one transaction (`:11421-11430` use `ExeQuteDc`), while save uses `TagEntTran`. The web must delete atomically.
- The Crystal selection uses only CO_CODE, so two operators printing together can print each other's labels.

## Web today

- `web/apps/web/app/(app)/txn/tag-opening/page.tsx` (871 lines): the grid, voucher box, save, delete, scale button. There is no Print button, no label skip box, no label file list and no Set button (grep for "print" finds only comments).
- `web/apps/api/src/routes/txn.ts:4837-4883`: POST, GET, PUT and DELETE of `/stock/tag-opening`; each runs `guard(req, reply, action)` for view, create, update, delete. No print action here.
- `web/apps/api/src/modules/stock/stockVoucherLifecycle.ts:1001`, `:1304`, `:1382`: `tagOpening`, `editTagOpening`, `deleteTagOpening`.
- `web/apps/api/src/modules/stock/tagPrint.ts:21` (`TAG_PRINT_STAGING_COLUMNS`), `:213` (`stageTagPrintRowsTx`), `:221-237` (label skip, banker's rounding), `:461` (`renderTagLabels`): the shared label writer used by the UT_TAG_PRINT screen.
- `web/apps/api/src/routes/tagPrintScreen.ts`, `modules/stock/tagPrintScreen.ts:142,179`: Tag Print screen routes with the print right and PRINT_MAST TAG or QR choice; not wired to this screen.
- `web/apps/api/src/modules/rbac/routePolicy.ts:532-535`: the four tag-opening routes in the rights table.
- `web/apps/api/src/modules/shared/counterStockPolicy.ts`: the CNTR_STK rule; used only by sales and purchase (`sales.ts:786`, `purchase.ts:703`).
- `web/apps/api/src/modules/stock/tagKarigarLine.ts`: the karigar columns on the line.
- `web/apps/web/lib/columnSettings.ts`, `web/apps/api/src/modules/masters/columnSettings.ts`: COL_MAST editing (Styles master); not read by the tag grid.
- Browser module `web/apps/web/test/features/modules/tagOpening.mjs` (786 lines): 14 of 19 cases run; five are `pending` (see Gaps 1-4, 8).

## Gaps

1. **Rights case blocked** (missing feature in the fixture, plus a missing rule). Desktop: `TR_TAG_OPBL.cs:10787 {{You Have No Rights.....}}` for save, `:11374` for delete, `TR_TAG_OPBL.cs:11479 {{You Have No Print Rights.....}}` for print, from USER_SET rows (`:9827`). Web: `tagOpening.mjs:613` `pending('rights', 'T11', 'The catalogue clerk has no Tag Opening rights row yet.')`. The routes check rights through `guard` (`txn.ts:918-925`) but the route list at `routePolicy.ts:532-535` has no print entry for this screen. Fix: add a clerk rights row for the Tag Opening menu in the fixture (view only, then no delete), assert 403 on save/delete and the desktop text on screen; add the print right with Gap 6.
2. **Concurrency case blocked** (missing feature). Desktop reads the stored voucher on open and rewrites it on save with no version check. Web: `tagOpening.mjs:614-617` needs a second operator slot and a version token; `editTagOpening` (`stockVoucherLifecycle.ts:1304`) and the PUT route (`txn.ts:4854`) take no expected version, unlike the vouchers named in N51/D17. Fix: add the token to GET and PUT and a second slot to the fixture; the case expects a refusal of the stale save. Decision D17 governs the text; no desktop text exists (Open questions).
3. **Retry case blocked** (missing feature). Web: `tagOpening.mjs:619` `Idempotency (N52) is not on the stock vouchers yet.`; `idempotencyRoutePolicy.test.ts:129` lists `POST /stock/tag-opening` but the case is still pending. Fix: confirm the route reads the idempotency key and replays the first answer, then write the case: two posts with one key give one voucher and one set of stock rows.
4. **Rollback case blocked** (missing test tool, G173). Desktop: save is one transaction (`TR_TAG_OPBL.cs:10858 {{DELETE FROM BAR_DATA WHERE CO_CODE}}` through `Module_Save.ExeQuteDcSave(..., Module_Save.TagEntTran)`). Web: `tagOpening.mjs:620`. G173's update says sixteen other modules already inject a fault that raises for one table; this module has none. Fix: copy that trigger pattern and fail at MAIN_STOCK, BAR_DETL and BAR_IDTL; expect no BAR_DATA, no stock row and no tag identity.
5. **Karigar block sources not ported** (missing feature, G217 "Not covered"). Desktop fills KrNwt, KrTouch, KrWst%, KrFine from the lot header, the order pull and the manufacturing pull: `TR_TAG_OPBL.cs:5579 {{if ((Operators.CompareString(mSG[mSG.Row, 69], "A", false) == 0) & (Conversion.Val(nLotTouch.Text) != 0.0))}}`, `:8336` order link, `:8595` manufacturing fine, and at save `:10990`-`:10996`. Web: the page has no lot header (`page.tsx` has no Lot No field) and no order or manufacturing pull; `tagKarigarLine.ts` handles only typed cells. Also `MsUserKrTouchHide` (`:5156`) is not applied. Fix: split into three cases: (a) lot header with touch and wastage fills a blank-touch row at save, (b) manufacturing row copies weights and derives touch = KrFine × 100 / KrNwt "0.00", (c) KrTouch, KrWst% and KrFine hidden for a non-admin when the setting is Y. Start with (a); it writes money-related columns (KR_TOUCH, KR_WEST_PRC, KR_FINE to BAR_DETL and MAIN_STOCK).
6. **Tag label print missing** (missing feature). Desktop: BtnPrint with FRM_PRINT check, label skip, QR images, 58-column staging, file chooser and Set (`:11477`-`:11523`, `:12345-12364`). Web: the page has none of these controls; the staging writer and the label renderer exist (`tagPrint.ts:213`, `:461`) and the Tag Print screen offers the print right and file choice (`tagPrintScreen.ts:142,179`). Fix: add Print, Label Skip, file list and Set to this page calling the shared writer for the open voucher with the print right; cases: no print right gives the desktop text; skip 2.5 gives 2 blank labels then the voucher's tags; staging rows carry IT_CODE '00' and VCH_SRNO 0 for blanks. Per-row auto print (`MsTagRowAutoPrint`) is part of this item.
7. **COL_MAST grid not applied** (missing feature). Desktop: after the grid is built, each column header is looked up in COL_MAST for BOOK_NAME 'TAG_DETL': `TR_TAG_OPBL.cs:5395 {{dataView.RowFilter = "BOOK_NAME = 'TAG_DETL' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";}}`; YES_NO "N" zeroes the width (`:5398`) and the header becomes `TR_TAG_OPBL.cs:5402 {{mSG[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);}}`. The key handler maps back the other way (`TR_TAG_OPBL.cs:5618 {{dataView.RowFilter = "BOOK_NAME = 'TAG_DETL' AND COL_NEW_NAME = '"}}`). A second grid, the tag detail grid, does the same for 'TAG_IDTL' (`:4171`, `:4204`). The rows load once at start: `DC_Main.cs:1688 {{SELECT * FROM COL_MAST WHERE CO_CODE = '}}` (TAG_IDTL rows are split from the rest). Web: the page uses fixed labels (`page.tsx:111`, aria-labels such as `Tag opening ${field} row ${i + 1}`) and never reads COL_MAST, although `columnSettings.ts` edits it. Fix: serve the TAG_DETL and TAG_IDTL rows for the company to the page, hide columns with YES_NO "N", show COL_NEW_NAME as the header; keep the aria-label stable on the original name so the browser module keeps working. Case: set one column to hidden and one renamed, reload, assert the header and the save payload still carry the field.
8. **Settings case blocked** (missing feature). Desktop: `TR_TAG_OPBL.cs:10793 {{if (Operators.CompareString(DC_Main.MsCntrStk, "Y", false) == 0)}}` then `TR_TAG_OPBL.cs:10801 {{Please Insert Counter Code and Try Because It is Mandatory...}}`. Web: `tagOpening.mjs:621-624` needs a settings-variant fixture, and `stockVoucherLifecycle.ts` never calls `resolveCounterStockPolicyTx` (used only at `sales.ts:786` and `purchase.ts:703`), so the rule does not exist for this screen. Fix: wrong result today (a blank counter saves even with CNTR_STK 'Y'); add the policy to `tagOpening` and `editTagOpening` using the desktop text, then the variant case.
9. **Per-row and per-voucher auto features not ported** (missing feature). `MsTagVchAutoSave` (`:9108`) and `MsTagRowAutoPrint` (`:9112`) have no web counterpart (no setting read in `tag-opening/page.tsx`). Fix: only after Gap 6; low priority, report as a decision (Open questions).

Order of work for the next case list: 8 and 1 (rules and rights), 5a (money columns), 4 and 3 (write safety), 6, 7, 2, 9.

## Open questions

- Tab order, default values and the enabled rules of the controls are in `InitializeComponent` `:2623-3953` and were not read; the case list does not need them for these items except the Print and Set controls.
- Whether the web needs the per-voucher auto save (Gap 9) is a product decision; the desktop only saves a temporary copy (`TempSave` `:9223-9470`), which was not read.
- Concurrency (Gap 2): the desktop has no version check, so no desktop text exists. The refusal text must come from decision D17.
- The Crystal template names are data (PRINT_MAST rows), not source. Which names the Lite seed provides was not checked (no database access).
- The keyboard handlers `TEXT_ENTRY_KeyDown` (`:7606-9182`) were not read in full; the lot and order pulls (`:8330-8368`, `:8586-8600`) are mapped only for the karigar columns.
