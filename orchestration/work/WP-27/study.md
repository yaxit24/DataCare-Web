# WP-27 study: Sales Return residuals (TR_SALE_RTN)

Scope of this study: lossless edit, the 5-second transaction budget on create, admissibility, the residual
Sales Return gap rows in `12-lineage-verification-2026-10-01.md`, and the blocked cases in `salesReturn.mjs`.
Percentage labour on returns (PR #241) is not re-studied. Desktop citations are `TR_SALE_RTN.cs` unless a file is named.
The web suite was not run in this session (no stack); web statements come from reading source.

## Scope

- Menu caption: `Sales Return`. Form `TR_SALE_RTN`, 16,923 lines (index `.orch/index/TR_SALE_RTN.md`).
- Dispatch: `MDI_FORM.cs:7966 {{case "Sales Return":}}`. A company whose short name is UAE opens `TR_SALE_RTN_UAE`
  (`MDI_FORM.cs:7972 {{tR_SALE_RTN_UAE = (Form)(object)MyProject.Forms.TR_SALE_RTN_UAE}}`), every other company opens
  `TR_SALE_RTN` (`MDI_FORM.cs:7984 {{tR_SALE_RTN = (Form)(object)MyProject.Forms.TR_SALE_RTN}}`). Both first pick a book:
  `MDI_FORM.cs:7969 {{DC_Main.CurBookHelp("SALES RETURNE");}}`. The UAE form is out of scope (Lite is not UAE).
- Lite edition: the form branches on `MsSoftType`, for example `TR_SALE_RTN.cs:2929 {{DC_Main.MsSoftType, "E", false) == 0}}`
  (grid widths) and `TR_SALE_RTN.cs:13380 {{DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E"}}`
  (the `BAR_DETL`/`MAIN_STOCK` `DATA_TYPE` update at :13387/:13395). Edition `A`/`E` branches are tag-tracking features;
  I did not map which of them Lite hides (see Open questions).
- Modes: `EntryMode` `A` (add) and `E` (edit): `TR_SALE_RTN.cs:12240 {{EntryMode, "A", false) == 0}}`.
- Out of scope: percentage labour (PR #241), the saved-incoming-return pipeline (`incoming-*` routes, card X13),
  the UAE form, Crystal layout fidelity, ledger book-slot accounts (G116, N107).

## Screen

Only what the scope needs; the full control list is not re-derived here.
- Captions: `TR_SALE_RTN.cs:2328 {{Sales Return }}` (lblBook), `TR_SALE_RTN.cs:2345 {{Vch Date}}`, `TR_SALE_RTN.cs:2354 {{Vch No}}`, `TR_SALE_RTN.cs:2612 {{Party Code}}`,
  `TR_SALE_RTN.cs:2647 {{Employee}}`, `TR_SALE_RTN.cs:2657 {{Vch Desc}}`, `TR_SALE_RTN.cs:2789 {{Sale Bill}}` (the original-bill box), `TR_SALE_RTN.cs:2780 {{btnIsuNo.Text = "S";}}` (Import button, `btnIsuNo`).
- Buttons: `TR_SALE_RTN.cs:2406 {{BtnSave.Text = "&Save";}}`, `TR_SALE_RTN.cs:2433 {{&Delete}}`, `TR_SALE_RTN.cs:2393 {{&Print}}`, `TR_SALE_RTN.cs:2420 {{&Cancel}}`, `TR_SALE_RTN.cs:2446 {{BtnExit.Text = "E&xit";}}`.
- Grids: item grid `MSG_PR` (columns written by Import at `:16567-16613`, e.g. column 2 is the tag, 12 net weight, 19 rate, 20 amount),
  the bill-total grid `MSG2_TOTAL`, the cash/cheque/card rows.
- Tab order and enabled/visible rules: MISSING (not read; the layout JSON under `web/apps/api/form-specs/` is the place).

## Keyboard

- Esc on the form: `TR_SALE_RTN.cs:15113 {{if ((int)e.KeyCode != 27)}}` then closes the open cell editor (`TEXT_ENTRY`, `TEXT_PR`,
  `TEXT_ENTRY_2`) and returns focus to the grid or to `tEmpCode` (:15119-15161).
- Voucher number box: F1 opens the list (`TR_SALE_RTN.cs:15495 {{if ((int)e.KeyCode == 112)}}`), Up goes to the last record
  (`TR_SALE_RTN.cs:15499 {{if ((int)e.KeyCode == 38)}}` calls `BtnLast_Click`), Down to the first (`TR_SALE_RTN.cs:15503 {{if ((int)e.KeyCode == 40)}}`).
- Import box `tIsuNo`: only Enter acts: `TR_SALE_RTN.cs:16528 {{if ((int)e.KeyCode != 13)}}` returns for any other key.
- Arrow keys inside the grid editors are re-routed in `TR_SALE_RTN_KeyUp` (`:16892`, `:16902`, `:16907`).
- Alt+S is the `&Save` accelerator (caption at :2406); the web case `keyboard.alt-s-saves` covers it.

## Rules

Save order of checks in `BtnSave_Click` (`:10549-15058`), message text verbatim, focus after it:
1. `TR_SALE_RTN.cs:12113 {{You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....}}`.
2. `TR_SALE_RTN.cs:12124 {{Please Select Employee Code and Try......}}` when `MsEmpCodeMendetry = Y` and `tEmpCode` blank; focus `tEmpCode` (`TR_SALE_RTN.cs:12128 {{((Control)tEmpCode).Focus();}}`).
3. `TR_SALE_RTN.cs:12143 {{You Cant Save Entry Because This Party Is in Defaulter List...Please Change It First In AcMast...}}`
   when `TR_SALE_RTN.cs:12136 {{DC_Main.MsDefaulterAc, "Y", false) == 0) & (Conversion.Val(MSG2_TOTAL[8, 4]) > 0.0)}}`.
4. Cash limit (not in the index): `TR_SALE_RTN.cs:12176 {{Cash Recieved Limit Amount = }}` when `TR_SALE_RTN.cs:12169 {{DC_Main.AcCash > DC_Main.MsCashLimit}}`.
5. `TR_SALE_RTN.cs:12202 {{Please Select Bank Account And Try Because Chq Rec Amt <> 0......}}` and
   `TR_SALE_RTN.cs:12217 {{Please Select Card Bank Account And Try Because Card Amt <> 0......}}`.
6. `TR_SALE_RTN.cs:12232 {{You Cant Save This Voucher Becouse This Company Type is B......}}` for a new entry in a type-B company.
7. `TR_SALE_RTN.cs:12262 {{You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...}}`.
8. Lock date (not in the index): `TR_SALE_RTN.cs:12277 {{You Cant Save and Delete This Voucher Becouse Lock Date is = }}` when
   `TR_SALE_RTN.cs:12270 {{if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)}}`.
9. `TR_SALE_RTN.cs:12299 {{You Have No Rights.....}}` when the update right is not `Y`, or the edit right is not `Y` in edit mode (`:12292`).
10. `TR_SALE_RTN.cs:12314 {{Please Insert VchNo and try}}`.
11. `TR_SALE_RTN.cs:12347 {{Please Insert Tag Entry Counter Code and Try Because It is Mandatory...}}` (only when `MsCntrStk = Y`); focus `TEXT_PR` (`TR_SALE_RTN.cs:12367 {{((Control)TEXT_PR).Focus();}}`).
12. Zero value: `TR_SALE_RTN.cs:12405 {{Please Insert Item Value and try}}` when `TR_SALE_RTN.cs:12398 {{if (Conversion.Val(nAcCrAmt.Text) + Conversion.Val(nAcDrAmt.Text) + num6 == 0.0)}}`
    (the bill-level Cr + Dr + hallmark total is 0; it is not a per-line check).
- Grid: `TR_SALE_RTN.cs:9313 {{Duplicate Tag No}}` when the same tag appears on another grid row (test at `:9304`).
- Import: `TR_SALE_RTN.cs:16540 {{This Sales Bill Is All ready Import...In...}}` (see Gaps 4); `TR_SALE_RTN.cs:16554 {{All Sales Tag In This Voucher Import?}}` is a Yes/No box.
- Delete: `TR_SALE_RTN.cs:15072 {{You Have No Rights.....}}`, `TR_SALE_RTN.cs:15074 {{Are You Sure To Delete This Voucher now?}}`, `TR_SALE_RTN.cs:15103 {{Delete Success.}}`.
- Print: `TR_SALE_RTN.cs:15176 {{You Have No Print Rights.....}}`; after a save `TR_SALE_RTN.cs:13598 {{Sales Return Print... ?}}`.

## Calculations

Whole-rupee stages are already done (N181) and are recorded only to anchor the edit gap:
- Item amount: `TR_SALE_RTN.cs:4955 {{Math.Round(num * Conversion.Val(mSG_PR[mSG_PR.Row, 19]), 0)}}`; labour `TR_SALE_RTN.cs:4985 {{Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 12])}}`.
- Basis switch on `MsSlAmtType`: `TR_SALE_RTN.cs:4915 {{if (Operators.CompareString(DC_Main.MsSlAmtType, "F", false) != 0)}}`.
- Tax: `TR_SALE_RTN.cs:16402 {{Math.Round(Conversion.Val(mSG2_TOTAL[1, 3]) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof)}}`;
  total `TR_SALE_RTN.cs:16405 {{Math.Round(Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]), 0)}}`.

## Lifecycle and write set

Create (EntryMode `A`) and edit (`E`) run the same save. There is no database transaction in the form: every write is its own
`ExeQuteDc` call (weakness below). Order as read:
1. Edit only: the old voucher is deleted before the rewrite: `TR_SALE_RTN.cs:12496 {{DELETE FROM SL_DATA WHERE}}`, `TR_SALE_RTN.cs:12500 {{DELETE FROM SL_DETL WHERE}}`,
   `TR_SALE_RTN.cs:12504 {{DELETE FROM SL_IDTL WHERE}}`, and the hidden-book row `TR_SALE_RTN.cs:12515 {{DELETE FROM TEMP_BOOK_DATA WHERE}}` (key `tHdVchNo`).
2. `TEMP_BOOK_DATA` row (new row, `VCH_NO` = hidden number): `TR_SALE_RTN.cs:12547 {{dataRow["VCH_NO"] = tHdVchNo.Text;}}`.
3. `SL_DATA` header: `TR_SALE_RTN.cs:12611 {{dataRow2["HD_VCH_NO"] = tHdVchNo.Text;}}`, `TR_SALE_RTN.cs:12623 {{dataRow2["NET_AMT"] = Conversion.Val(nAcDrAmt.Text);}}`,
   `TR_SALE_RTN.cs:12679 {{dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[3, 4]);}}`, `TR_SALE_RTN.cs:12695 {{dataRow2["CASH_AMT"]}}`, `TR_SALE_RTN.cs:12719 {{dataRow2["TAX_AMT"]}}`,
   the import link `TR_SALE_RTN.cs:12825 {{dataRow2["ISU_NO"] = tIsuNo.Text;}}` and `TR_SALE_RTN.cs:12837 {{dataRow2["ISU_DBCD"] = tIsuDbCd.Text;}}`,
   and the creator `TR_SALE_RTN.cs:12908 {{dataRow2["MAIN_USER"] = MainUser;}}`. On edit `MainUser` is the stored creator, not the editor:
   `TR_SALE_RTN.cs:10181 {{MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));}}`;
   on a new voucher it is the login: `TR_SALE_RTN.cs:9966 {{MainUser = DC_Main.MCo_User;}}`.
4. Return lines: `TR_SALE_RTN.cs:13014 {{DELETE FROM SL_DETL_RTN WHERE}}` then the rows are re-added; tag registers `TR_SALE_RTN.cs:13018 {{DELETE FROM BAR_DATA WHERE}}`,
   `TR_SALE_RTN.cs:13022 {{DELETE FROM BAR_DETL WHERE}}`, `TR_SALE_RTN.cs:13026 {{DELETE FROM BAR_IDTL WHERE}}`; `BILL_OS_DATA` `TR_SALE_RTN.cs:13201 {{DELETE FROM BILL_OS_DATA WHERE}}`.
5. Tag status: `TR_SALE_RTN.cs:13387 {{UPDATE BAR_DETL SET BAR_DETL.DATA_TYPE = C.DATA_TYPE}}`, `TR_SALE_RTN.cs:13395 {{UPDATE MAIN_STOCK SET MAIN_STOCK.DATA_TYPE = C.DATA_TYPE}}`.
6. Posting, each as delete then rebuild: `AC_DATA` `TR_SALE_RTN.cs:13403 {{DELETE FROM AC_DATA WHERE}}` + `TR_SALE_RTN.cs:13411 {{Ac_Ledr.SaleReturn_Ledr(DC_Main.MCo_Book, tVchNo.Text);}}`;
   `ROJ_MEL_DATA` `:13415` + `TR_SALE_RTN.cs:13423 {{Ac_Rojmel.SaleReturn_RojMel(DC_Main.MCo_Book, tVchNo.Text);}}`;
   `MAIN_STOCK` `:13427` + `TR_SALE_RTN.cs:13435 {{Ac_Stock.SaleReturn_Stk(DC_Main.MCo_Book, tVchNo.Text);}}`;
   `TAX_DATA` `:13439` + `TR_SALE_RTN.cs:13447 {{Ac_Tax.Sales_Rtn_GST(DC_Main.MCo_Book, tVchNo.Text);}}`;
   `DM_DATA` `:13451` + `TR_SALE_RTN.cs:13459 {{Ac_Stock.Dm_Sale_Return_Detl(DC_Main.MCo_Book, tVchNo.Text);}}`; remarks `TR_SALE_RTN.cs:13463 {{Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);}}`.
7. Edit audit: `TR_SALE_RTN.cs:13541 {{INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE}}` writes one row per changed
   column (old and new value), comparing the reloaded header with the saved one (`:13512` area, the `OldVal`/`NewVal` pair).
Delete (`BtnDelete_Click`): the `DELETE_DATA` row first (`TR_SALE_RTN.cs:15076 {{INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO}}`),
then `SRNO_MAST` per grid tag (`:15084`), `REMARK_DATA` (`:15087`), `TEMP_BOOK_DATA` (`:15088`), `MAIN_STOCK` (`:15089`), `AC_DATA` (`:15090`),
`ROJ_MEL_DATA` (`:15091`), `TAX_DATA` (`:15092`), `BILL_OS_DATA` (`:15093`), `DM_DATA` (`:15094`), `SL_DATA` (`:15096`), `SL_DETL` (`:15097`),
`SL_IDTL` (`:15098`), `SL_DETL_RTN` (`:15099`), `BAR_DATA/BAR_DETL/BAR_IDTL` (`:15100-15102`).
Cancel: `TR_SALE_RTN.cs:15240 {{private void BtnCancel_Click}}` reloads without writing (not read further).

## Print

- Template choice: `TR_SALE_RTN.cs:15200 {{\\Report\\SalesRtnA4Gst.RPT}}` when `FormBookType` is `T` (`TR_SALE_RTN.cs:15198 {{if (Operators.CompareString(FormBookType, "T", false) == 0)}}`),
  otherwise `TR_SALE_RTN.cs:15204 {{\\Report\\SalesRtnA4.RPT}}`.
- Rights: `TR_SALE_RTN.cs:15176 {{You Have No Print Rights.....}}`; duplicate-print flag `TR_SALE_RTN.cs:15179 {{if (Operators.CompareString(DC_Main.MsSlDupPrint, "Y", false) == 0)}}`.
- Not in scope for edit, but note the web names a different template: see Found but out of scope in the report.

## Rights

- `USER_SET` is read on load for the form's `SUB_MENU`: `TR_SALE_RTN.cs:9574 {{Select * From USER_SET WHERE LC_CODE}}`; flags `FRM_EDIT`, `FRM_DELETE` map to
  `UserEdit`, `UserDelete` (`:9580`-area); save refuses with `TR_SALE_RTN.cs:12299 {{You Have No Rights.....}}`; print `UserPrint`; delete `:15072`.
- The saved row also carries `USER_UPDATE`/`USER_DELETE`/`DATA_TRFR` flags read back on reopen: `TR_SALE_RTN.cs:10182 {{UsUPdate = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_UPDATE"]}}`.

## Desktop weaknesses not to port

- SQL built by joining strings everywhere, e.g. `TR_SALE_RTN.cs:16534 {{A.ISU_DBCD = '" + tIsuDbCd.Text + "'}}`.
- No transaction around a save: the delete-then-insert sequence at `:12496-13463` is a series of independent statements, so a fault
  between them leaves a half-written voucher (the web wraps one transaction; keep that).
- Unscoped by year in places: the tag-return picker `:3882` filters `TAG_NO NOT IN(SELECT B.TAG_NO ...)` and excludes every loose `N` line
  once any loose line of that sale was returned, because `N` is a shared value (inferred from the query; not ported).
- Edit is delete-and-recreate, so a crash mid-edit loses the voucher.

## Web today

- `web/apps/web/app/(app)/txn/sale-return/page.tsx` (625 lines): New return form, Import from a sale, Save Return, credit-note links; embeds `SaleReturnSavedPanel`.
- `web/apps/web/components/SaleReturnSavedPanel.tsx` (named at page.tsx line 11): reopens a saved return; edits metadata only (per `salesReturn.mjs line 773`).
- `web/apps/api/src/modules/sales/salesReturn.ts` (923 lines): `createSaleReturn` (:266), `saleForReturn` (:643), `getSaleReturn` (:728),
  `editSaleReturn` (:803), `deleteSaleReturn` (:861).
- `web/apps/api/src/routes/txn.ts`: `POST /sales-returns` (:1809), `GET /sales-returns/import` (:1843), `DELETE /sales-returns/:vchNo` (:1856),
  `PUT .../incoming-metadata` (:1747), `PUT .../incoming-numeric` (:1763, only `version` and `otherAmount`), `GET /sales-returns/:vchNo` (:7328), print (:7334).
- `web/apps/api/src/modules/shared/txBudget.ts`: budget classes read 5 s, voucher 20 s, heavy 30 s.
- Tests: `web/apps/web/test/features/modules/salesReturn.mjs` (25 cases), `web/apps/api/test/salesFamilyLifecycle.db.test.ts`
  (calls `editSaleReturn` directly at :488, :663, :716), `saleReturnSource.db.test.ts`.

## Gaps

1. **Lossless edit is not reachable from the screen (missing feature).**
   Desktop: edit reloads the stored header, keeps the creator (`TR_SALE_RTN.cs:10181 {{MainUser = Conversions.ToString}}`), deletes and rewrites
   (`TR_SALE_RTN.cs:12496 {{DELETE FROM SL_DATA WHERE}}`) and logs each changed column (`TR_SALE_RTN.cs:13541 {{INSERT INTO USER_DATA}}`).
   Web: `editSaleReturn` exists (`salesReturn.ts line 803`) and keeps the creator (`:850 mainUser: text(persisted.MAIN_USER)`) and the clock
   (`:851 persistedClock`), but no route calls it; `txn.ts` has no `PUT /sales-returns/:vchNo`. The only writes on a saved return are the metadata PUT (`txn.ts line 1747`) and
   the numeric PUT, which takes just `otherAmount` (`txn.ts line 1771`). `salesReturn.mjs line 773` blocks `edit.numeric` for that reason.
   Fix: (a) add a guarded `PUT /sales-returns/:vchNo` that calls `editSaleReturn` and returns the saved voucher; (b) page: load a saved return into the New return form
   (lines, tags, cash/cheque/card, tax code) and Save as edit; (c) a database test that creates a return, reopens it, saves it unchanged and compares every column of
   `SL_DATA`, `SL_DETL_RTN`, `MAIN_STOCK`, `AC_DATA`, `TAX_DATA`, `ROJ_MEL_DATA`, `BILL_OS_DATA`, `DM_DATA`, `REMARK_DATA` before and after
   (the existing lifecycle test only checks failures and `before` equality, `salesFamilyLifecycle.db.test.ts line 31`); (d) decide the `USER_DATA` edit-audit rows. Columns that may drift (inferred, test first):
   `VCH_CLOCK`, the hidden voucher number, `ISU_*`, `USER_UPDATE`, `USER_DELETE`, `DATA_TRFR`, `ENTRY_TIME`.
2. **The 5 s budget on create (missing measurement, possibly a stale premise).**
   Desktop has no budget (no transaction). Web create already runs under the `voucher` class: `salesReturn.ts:640 {{withTxBudget(prisma, tenantId, 'voucher', run)}}`
   with 20 s total and 5 s to start (`txBudget.ts` COMMAND_TX_BUDGETS: voucher `timeout: 20_000, maxWait: 5_000`). Only the read class is 5 s
   (`saleForReturn`, `salesReturn.ts line 656`). The 5 s the plan means is the performance target "Voucher save p95 under the 5 s transaction budget" (`docs/parity/LITE-MASTER-PLAN.md line 553`);
   `web/scripts/load-profile.mjs line 330` measures only `POST /sales`, so no return create has a p95. Fix: add a return-create request to the load profile
   (one sale to return against, then N returns), assert p95 < 5 s, and run a case with a fault past the budget to confirm 503 `transaction-timeout` with full rollback.
   A heavy create path to check: three extra `SELECT`s per line for tag provenance (`salesReturn.ts line 159`), numbering and settings resolution inside the transaction (:271-285).
3. **Zero-value refusal missing, wrong text available (missing rule + wrong text; lineage G26/N50).**
   Desktop refuses a voucher whose amounts total 0 (`TR_SALE_RTN.cs:12398 {{Conversion.Val(nAcCrAmt.Text) + Conversion.Val(nAcDrAmt.Text) + num6 == 0.0}}`) with
   `TR_SALE_RTN.cs:12405 {{Please Insert Item Value and try}}`. Web: `salesReturn.ts` has no such check; the shared constant is unused and has different text
   (`desktopMessages.ts line 56 ITEM_VALUE_ZERO: 'Please Insert Item Value Nat Amount  = 0 and try'`, no other reference under `web/apps/api/src`).
   Fix: refuse in `createSaleReturn` when the voucher total is 0 using the TR_SALE_RTN text above (G26's "rows without item value" reads wider than the desktop; follow the desktop, voucher level).
4. **Admissibility of what may be returned (missing rules and wrong texts).**
   a. Already-returned lines. Desktop offers only sale lines whose tag is not already on a return of that sale:
      `TR_SALE_RTN.cs:3882 {{TAG_NO NOT IN(SELECT B.TAG_NO FROM SL_DATA AS A LEFT JOIN SL_DETL_RTN AS B}}` (keyed by `ISU_YRCD/ISU_DBCD/ISU_NO`). Web enforces it at save with
      `salesReturn.ts:251 {{tag is not currently sold or was already returned}}`; the Import response (`saleForReturn`, :643-700) does not remove already-returned lines,
      so the screen can offer a line the save then refuses. Fix: filter in `saleForReturn`; keep the save check.
   b. Whole bill imported twice. Desktop: `TR_SALE_RTN.cs:16540 {{This Sales Bill Is All ready Import...In...}}` stops a second Import of a bill that already has a return (query `:16534`).
      Web: no equivalent (grep `already` finds only :251). Fix: refuse a second all-lines import when every line is returned, with the desktop text; a partial return of the remaining lines stays allowed because the picker at :3882 allows it (inferred).
   c. Duplicate tag in one voucher. Desktop `TR_SALE_RTN.cs:9313 {{Duplicate Tag No}}`; web `salesReturn.ts:218 {{duplicate returned tag}}` (wrong text). Use the desktop text.
   d. Quantities. No quantity cap against the sold weight or pieces appears in the ranges read (`:3882`, `:16545`, Import copy `:16567-16613`); see Open questions. Web has none either; no change until confirmed.
   e. Tag provenance. Desktop copies the sale's tag, including loose `N` (`TR_SALE_RTN.cs:3917 {{mSG_PR[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"]}}`); web text `tag provenance is missing or ambiguous: ${tagNo}` (:236) has no desktop equivalent: keep as a web-only guard (the desktop would not refuse).
5. **Save-time refusals the web does not make (missing rules).** From the Rules list: the lock date (`:12277`), the cash limit (`:12176`), the voucher date outside the
   financial year (`:12262`), the employee-mandatory setting (`:12124`) and the bank-account-required messages (`:12202`, `:12217`). The shared constants exist for the defaulter and tag-counter texts
   (`desktopMessages.ts line 38`, `:72`); I did not find them used in `salesReturn.ts` (grep `desktopMessages` finds no import). Whether another layer enforces them (`assertPeriodOpen`
   is used only in edit, `salesReturn.ts line 821`) is unverified: write one refusal test per message before fixing. Fix: add the checks and texts per voucher family helper shared with Sales.
6. **No edit audit rows (missing feature).** Desktop `TR_SALE_RTN.cs:13541 {{INSERT INTO USER_DATA}}`; web `salesReturn.ts` never writes `USER_DATA` (grep). Falls under Gap 1(d).
7. **Residual lineage rows for Sales Return.** From `12-lineage-verification-2026-10-01.md`: G190 (basis and whole rupees), G191 (loose `N` line), G192 (Import covered), G193 (second delete 500), G194 (creator/deleter) are all recorded fixed in N181-N183; G116 (book slots, N107), G127 (credit-note print, N118), and G173 (rollback matrix, now running for Sales Return) are separate. Open items still naming this screen:
   - G26/N50 zero value: Gap 3 above (the row says fixed in no later note I found: MISSING confirmation of N50's status in `execution-backlog.json`).
   - G101: Sales Return book filter done by N90; nothing left.
   - G127: the desktop prints `SalesRtnA4Gst.RPT` / `SalesRtnA4.RPT` (`:15200`, `:15204`), whereas G127 and `saleReturnBill.ts line 17` name `SaleRtnBillA4Gst.rpt`. Wrong template name in the lineage; the credit-note layout should be compared against the two files the form really uses. Fix: re-point G127's desktop column, and choose A4Gst vs A4 by book type `T` as at `:15198`.
8. **The blocked cases.** `salesReturn.mjs` has exactly one `blocked:` property, `edit.numeric` (`:773`, reason: "Numeric edit of a saved return is not exposed in the web yet; it is planned in the Return programme (N10 atomic numeric update, N11 saved-return Save/reopen)"). Closed by Gap 1. The plan's "2 blocked" (N181: "23 passed, 0 failed and 2 blocked among 25 applicable cases") does not match the file: the module has 24 `C(` cases plus the spread `edit.numeric` = 25, and `rollback.mid-write` and `config.amount-type` both have bodies now (`salesReturn.mjs line 987`, `:1016`). The second blocked case is therefore either a result recorded before the T14/T15 cases were wired (N166, N181 say T15 was fixed) or a case the harness blocks at run time. Fix: run the module (`run-features.mjs`) and read the matrix; if a case is blocked at run time, name it; otherwise correct the "2" in `LITE-MASTER-PLAN.md line 466`. Make `edit.numeric` real (Gap 1) rather than loosen it.

## Open questions

1. Which `MsSoftType` values Lite is (`L`/`B`), and which of the `A`/`E` branches at `:2929`, `:3595`, `:5226`, `:10092`, `:13380` change the return rules. The source shows the tests; edition-to-setting mapping is in `docs/handbook/menu-editions.json` (not read).
2. Quantity admissibility: whether a return line's weight or pieces must be at most the sold line's. Not seen in `:3882-3920`, `:16545-16620`; the grid cell handlers (`TEXT_PR_KeyDown` `:3809-4435`, `MSG_PR_LeaveCell` `:4592-4665`) were not read for a comparison.
3. Whether the second blocked case exists at run time (Gap 8): needs a real run of `FEATURE_E2E_MODULES=sales-return`.
4. `execution-backlog.json` status of N50 (is the zero-value refusal done for Sales Return?). Not read in full.
5. What `:13512-13530` compares to decide which `USER_DATA` rows to write (field list); needed to decide Gap 1(d).
6. Tab order, enabled and visible rules (Screen section): not read; use `web/apps/api/form-specs/TR_SALE_RTN.initcomp.json`.
