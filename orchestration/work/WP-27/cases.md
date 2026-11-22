# WP-27 cases: Sales → Sales Return residuals (desktop `TR_SALE_RTN`)

Frozen case list built from `orchestration/work/WP-27/study.md` (8 gaps, 6 open questions). Desktop citations are
`TR_SALE_RTN.cs:LINE {{quoted text}}` unless another file is named. Module prefix `sales-return.` (the browser module
`web/apps/web/test/features/modules/salesReturn.mjs`; existing ids are reused where the behaviour is the same).
Nothing here is accepted; desktop-match coverage stays 0%.

**Layers.** `database` = a vitest file on the isolated database through the writer or the real HTTP route
(`web/apps/api/test/saleReturnResiduals*.db.test.ts`); `browser` = the feature module (not run locally in this work
package: CI or the owner's stack runs it); `unit` = pure code.

**Reference line R** (the browser module's `LINE_R`, reused by the database cases): net 10, gross 10.25, touch 91.6,
rate 6,123.45, making 237.5 per gram, ghat 0, `SL_AMT_TYPE` N (net + ghat basis, study Calculations).
- metal = round(10 × 6,123.45 = 61,234.50, 0) = **61,234** (`TR_SALE_RTN.cs:4955 {{Math.Round(num * Conversion.Val(mSG_PR[mSG_PR.Row, 19]), 0)}}`; banker's rounding, 61,234 is even)
- making = round(10 × 237.5 = 2,375, 0) = **2,375** (`TR_SALE_RTN.cs:4985 {{Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 12])}}`)
- net = 61,234 + 2,375 = **63,609**; tax = round(63,609 × 3 / 100 = 1,908.27, TAX_ROF) = **1,908.27** (`TR_SALE_RTN.cs:16402 {{Math.Round(Conversion.Val(mSG2_TOTAL[1, 3]) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof)}}`)
- total = round(63,609 + 1,908.27 = 65,517.27, 0) = **65,517** (`TR_SALE_RTN.cs:16405 {{Math.Round(Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]), 0)}}`)

**Edited line R'** = R with net 9 (gross 10.25 unchanged):
- metal = round(9 × 6,123.45 = 55,111.05, 0) = **55,111**; making = round(9 × 237.5 = 2,137.5, 0) = **2,138** (half to even: 2,138 is even)
- net = 55,111 + 2,138 = **57,249**; tax = round(57,249 × 3 / 100 = 1,717.47, 2) = **1,717.47**; total = round(58,966.47, 0) = **58,966**

## Decisions (architect, 2026-11-22, owner may override)

Applied rule: "the desktop first; the web adds only what a hosted multi-user service needs to be safe and correct".

- **D1 (study open question 1, edition branches).** The `MsSoftType` `A`/`E` branches read in the study change grid
  widths (`TR_SALE_RTN.cs:2929 {{DC_Main.MsSoftType, "E", false) == 0}}`) and the tag-register `DATA_TYPE` update
  (`TR_SALE_RTN.cs:13380 {{DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E"}}`), not a refusal, a total or a
  write the cases below assert. No case depends on the edition; no change.
- **D2 (open question 2, quantity cap).** No cap on a returned line's weight or pieces against the sold line: the desktop
  has none in the picker or the Import copy (study Gap 4d). A tagged line is already limited to one return by the tag
  identity and the `MAIN_STOCK` balance the web checks at save. No change.
- **D3 (open question 3, the second blocked case).** The module declares exactly one `blocked:` case (`edit.numeric`).
  This package makes it executable, so the module declares 0 blocked. A case blocked only at run time can be named only
  by a browser run, which this package does not do locally (machine rule); the plan row's "2 blocked" is corrected to
  "0 declared blocked, run pending".
- **D4 (open question 4, N50).** `execution-backlog.json` lists N50 as `planned` with proof "zero-value return refused".
  This package closes the Sales Return part (Gap 3) under N242; N50 keeps the schema half.
- **D5 (open question 5, `USER_DATA`).** The desktop compares every column of the reloaded header with the saved one
  (`TR_SALE_RTN.cs:13512 {{if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)""), Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.}}`)
  and writes one row per difference (`TR_SALE_RTN.cs:13541 {{INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE,ENTRY_TIME,USER_NAME,NEW_USER,BOOK_NAME,COL_TYPE,OLD_VAL,NEW_VAL,}}`).
  The web uses the shared `recordFieldChangesTx` (already used by Sales and Purchase): one row per changed `SL_DATA`
  header column, `USER_NAME` = stored creator, `NEW_USER` = editor, no row for an unchanged save.
- **D6 (Gap 4b, Import twice).** The Import of a whole bill is refused once any return of that bill exists in the same
  company and location (`TR_SALE_RTN.cs:16534 {{DC_Main.RsQry = "SELECT * FROM SL_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ISU_YRCD = '" + tIsuYrCd.Text +}}`),
  with the desktop text and the first such return's voucher number
  (`TR_SALE_RTN.cs:16540 {{This Sales Bill Is All ready Import...In...", DC_Main.Rshlp.Rows[0]["VCH_NO"]), (objec}}`), full text
  `This Sales Bill Is All ready Import...In...<VCH_NO> You Cant Re Ipmport...Please Select Single Item In Receive Item...`.
  The desktop takes `Rows[0]` of an unordered query; the web takes the lowest voucher number (deterministic). The text
  sends the operator to the single-item picker: the web offers it as "Import remaining" (D7).
- **D7 (Gap 4a, the remaining-lines picker).** The picker lists the sale's lines whose `TAG_NO` is not on any return of
  that bill (`TR_SALE_RTN.cs:3882 {{DC_Main.RsQry = "SELECT A.TAG_NO As TagNoL,C.IT_NAME As ItNameL,A.ITM_GWT As ItmGwtW,A.ITM_NWT As ItmNwtW,A.ITM_RATE As RateR,A.LBR_RATE As LbrRateR,A.IT_CODE As ItCodeL,}}`, `TAG_NO NOT IN (...)`).
  Kept literally, including the loose marker `N`: once one loose line of a bill is returned, the picker no longer
  offers that bill's loose lines. This is more restrictive than necessary but never unsafe; the study's "do not port"
  note is overruled by the desktop-first rule (owner may override).
- **D8 (Gap 4c, duplicate tag).** `Duplicate Tag No` is raised by the desktop on the sale-side grid
  (`TR_SALE_RTN.cs:8051 {{val = MSG;}}`, test `TR_SALE_RTN.cs:9306 {{if ((Operators.CompareString(val[DC_Main.X, 1], TEXT_ENTRY.Text, false) == 0) & (val.Row != DC_Main.X))}}`),
  not on the return grid. Returning one tag twice in one voucher would put the piece back into stock twice, so the web
  keeps its refusal (multi-user safety) and uses the desktop's own text for the condition:
  `TR_SALE_RTN.cs:9313 {{Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);}}`.
- **D9 (Gap 3, zero value).** Refuse when the return's whole-rupee net is 0: `nAcCrAmt` is the return grid's net
  rounded to 0 decimals (`TR_SALE_RTN.cs:16386 {{nAcCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(MSG_PR_TOT[0, 38]), 0), "0.00");}}`),
  the web form has no sale side (`nAcDrAmt` = 0) and `num6` is a single-registration hallmark term (0). An empty grid
  is the same condition and gets the same text (`TR_SALE_RTN.cs:12405 {{Please Insert Item Value and try}}`).
- **D10 (Gap 5, cash limit and defaulter).** Both desktop tests read the SALE-side column of the bill-total grid:
  cash `TR_SALE_RTN.cs:12169 {{if (Conversion.Val(MSG2_TOTAL[6, 4]) + DC_Main.AcCash > DC_Main.MsCashLimit)}}` where
  column 4 holds `CASH_AMT` and column 3 `RTN_CASH_AMT` (`TR_SALE_RTN.cs:10116 {{MSG2_TOTAL[6, 4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"])), "0.00");}}`,
  `TR_SALE_RTN.cs:10137 {{MSG2_TOTAL[6, 3] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RTN_CASH_AMT"])), "0.00");}}`);
  defaulter `TR_SALE_RTN.cs:12136 {{if ((Operators.CompareString(DC_Main.MsDefaulterAc, "Y", false) == 0) & (Conversion.Val(MSG2_TOTAL[8, 4]) > 0.0))}}`.
  A return-only voucher has no sale side, so neither can fire: the web adds neither refusal to the return. Cases assert
  the save is accepted.
- **D11 (Gap 5, bank accounts).** The cheque and card tests read both columns (`TR_SALE_RTN.cs:12195 {{if ((Conversion.Val(MSG2_TOTAL[4, 3]) + Conversion.Val(MSG2_TOTAL[4, 4]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[4, 5], "", false) == 0))}}`,
  `TR_SALE_RTN.cs:12210 {{if ((Conversion.Val(MSG2_TOTAL[5, 3]) + Conversion.Val(MSG2_TOTAL[5, 4]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[5, 5], "", false) == 0))}}`),
  so a refund by cheque or card needs its account. The web tender panel has one bank account for cheque, card and UPI;
  both texts test that account. `BANK_AC` is stored on the header as the desktop does (`TR_SALE_RTN.cs:12817 {{dataRow2["BANK_AC"] = MSG2_TOTAL[4, 5];}}`), which the lossless reopen needs.
- **D12 (Gap 1, lossless edit).** `PUT /sales-returns/:vchNo` calls `editSaleReturn` with the voucher's version token
  (`GET` returns `version`; stale → `409 voucher-version-conflict`), the web's multi-user guard already used by Sale
  (N51, D17). The `GET` returns every input the writer stores, so reopen + save unchanged rewrites identical rows.
  Labour is stored as the desktop `LBR_TYPE` code (G/N/K/P, as Sale stores it), because the old first-letter form (`p`)
  could not be read back. Edit keeps the creator (`TR_SALE_RTN.cs:10181 {{MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));}}`)
  and the clock.
- **D13 (Gap 2, the 5 s budget).** The 5 s is the plan's performance target (voucher save p95 under 5 s), not the
  transaction class (create already runs in the 20 s `voucher` class). Proven by a database test (sequential creates
  through the HTTP route, p95 < 5,000 ms) and by the load profile gaining a return-create operation; a create held past
  its budget is a retryable 503 that writes nothing. The class is not changed.
- **D14 (Gap 5, refusal order).** Refusals run in the desktop order: employee (`TR_SALE_RTN.cs:12124 {{Please Select Employee Code and Try......}}`),
  cheque, card, company type B for a new voucher (`TR_SALE_RTN.cs:12225 {{if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))}}`),
  year (`TR_SALE_RTN.cs:12255 {{if ((DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0) | (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_ClDate), Conversions.ToDate(mVchDate.Text)) < 0}}`),
  lock date (`TR_SALE_RTN.cs:12270 {{if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)}}`), zero value. All before any write;
  a refusal rolls back the transaction, so no voucher number is consumed.

## T01 Entry and defaults

### sales-return.entry.defaults   (T01 Entry/defaults)
Layer: browser (existing case, unchanged)
Steps: 1. Open Sales → Sales Return. 2. Read the book list, the mode buttons and Tax %.
Expected: only `SRT — Sales Return` (`MDI_FORM.cs:7969 {{DC_Main.CurBookHelp("SALES RETURNE");}}`); New return and Saved returns; Tax % 3.
Status: executable

### sales-return.entry.employee-field   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the New return form. 2. Look for the Employee box.
Expected: a field labelled `Employee` (`TR_SALE_RTN.cs:2647 {{Label3.Text = "Employee";}}`), empty by default. Fails today: the form has none (Gap 5).
Status: executable

## T02 Field route

### sales-return.field.employee-route   (T02 Field route)
Layer: database
Steps: 1. Create a return with `empCode` `E7` and line R. 2. Read `SL_DATA`.
Expected: `EMP_CODE` = `E7` (`TR_SALE_RTN.cs:12877 {{dataRow2["EMP_CODE"] = tEmpCode.Text;}}`). Fails today: the writer drops it (Gap 5).
Status: executable

### sales-return.field.bank-account-route   (T02 Field route)
Layer: database
Steps: 1. Create a return with line R, cheque refund 1,000, bank account `BANK1`. 2. Read `SL_DATA`.
Expected: `CHQ_AMT` 1,000 and `BANK_AC` `BANK1` (`TR_SALE_RTN.cs:12817 {{dataRow2["BANK_AC"] = MSG2_TOTAL[4, 5];}}`). Fails today: `BANK_AC` is not written (D11, Gap 1).
Status: executable

## T03 Formula

### sales-return.formula.net-basis   (T03 Formula)
Layer: browser (existing case, unchanged)
Steps: as in the module.
Expected: line R previews metal 61,234, making 2,375, net 63,609, tax 1,908.27, total 65,517 (header arithmetic).
Status: executable

### sales-return.formula.edit-recomputes   (T03 Formula)
Layer: database
Steps: 1. Create line R. 2. Edit it to R' through `PUT /sales-returns/:vchNo`.
Expected: `SL_DETL_RTN` `ITM_AMT` 55,111, `LBR_AMT` 2,138, `NET_AMT` 57,249; `SL_DATA` `TAX_AMT` 1,717.47, `TOT_AMT` 58,966 (R' arithmetic). Fails today: no PUT route (Gap 1).
Status: executable

## T04 Lookup (Import)

### sales-return.import.remaining-excludes-returned   (T04 Lookup)
Layer: database
Steps: 1. Seed sale `SAL/00001` with tagged line `TAGRT` and loose line `N`. 2. Return `TAGRT` against it. 3. Ask for the remaining lines.
Expected: the loose line only (`TAG_NO NOT IN` the returned tags, D7, `TR_SALE_RTN.cs:3882 {{DC_Main.RsQry = "SELECT A.TAG_NO As TagNoL,C.IT_NAME As ItNameL,A.ITM_GWT As ItmGwtW,A.ITM_NWT As ItmNwtW,A.ITM_RATE As RateR,A.LBR_RATE As LbrRateR,A.IT_CODE As ItCodeL,}}`). After the loose line is also returned: an empty list. Fails today: no remaining mode (Gap 4a).
Status: executable

### sales-return.import.refused-after-return   (T04 Lookup)
Layer: database + browser
Steps: 1. Seed sale `SAL/00001`. 2. Return one line of it (voucher 00008). 3. Import the whole bill again.
Expected: refused, 400, text `This Sales Bill Is All ready Import...In...00008 You Cant Re Ipmport...Please Select Single Item In Receive Item...` (D6); no write. Browser: the message shows and the grid stays empty. Fails today: the Import returns the lines (Gap 4b).
Status: executable

### sales-return.import.first-import-allowed   (T04 Lookup)
Layer: database
Steps: 1. Seed sale `SAL/00001`, no return. 2. Import it.
Expected: customer `CUST`, both sale lines (the query at `TR_SALE_RTN.cs:16534 {{A.ISU_YRCD = '" + tIsuYrCd.Text + }}` finds no return, so the Import proceeds).
Status: executable

### sales-return.create.from-bill-import   (T04 Lookup)
Layer: browser (existing case, unchanged)
Status: executable

### sales-return.refusal.import-missing-bill   (T04 Lookup)
Layer: browser (existing case, unchanged)
Status: executable

## T05 Children

### sales-return.children.duplicate-tag   (T05 Children)
Layer: database
Steps: 1. Return tag `TAGRT` twice in one request.
Expected: refused with `Duplicate Tag No` (D8, `TR_SALE_RTN.cs:9313 {{Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);}}`); no write. Fails today: text `duplicate returned tag: TAGRT` (Gap 4c).
Status: executable

### sales-return.create.two-groups   (T05 Children)
Layer: browser (existing case, unchanged)
Status: executable

## T06 Required / invalid

### sales-return.refusal.zero-value   (T06 Required/invalid)
Layer: database
Steps: 1. Save a return whose only line has net 0, rate 0, no labour.
Expected: refused with `Please Insert Item Value and try` (`TR_SALE_RTN.cs:12398 {{if (Conversion.Val(nAcCrAmt.Text) + Conversion.Val(nAcDrAmt.Text) + num6 == 0.0)}}`, D9); 0 + 0 + 0 = 0. No `SL_DATA` row, numbering not consumed (the next good save is voucher 00008). Fails today: saved with total 0 (Gap 3).
Status: executable

### sales-return.refusal.no-lines   (T06 Required/invalid)
Layer: database + browser (existing browser case; expected text tightened)
Steps: 1. Save with no item line.
Expected: refused with `Please Insert Item Value and try` (D9: an empty grid totals 0); nothing written. Fails today: text `at least one return line is required` (Gap 3).
Status: executable

### sales-return.refusal.employee-mandatory   (T06 Required/invalid)
Layer: database
Steps: 1. `CO_SET.EMP_CODE_MANDATORY` = Y. 2. Save line R without employee. 3. Save again with `E7`.
Expected: step 2 refused with `Please Select Employee Code and Try......` (`TR_SALE_RTN.cs:12124 {{Please Select Employee Code and Try......}}`), nothing written; step 3 saved. Fails today (Gap 5).
Status: executable

### sales-return.refusal.cheque-without-bank   (T06 Required/invalid)
Layer: database
Steps: 1. Save line R with cheque refund 1,000 and no bank account.
Expected: `Please Select Bank Account And Try Because Chq Rec Amt <> 0......` (`TR_SALE_RTN.cs:12202 {{Please Select Bank Account And Try Because Chq Rec Amt <> 0......}}`); nothing written. Fails today: a non-desktop posting-account text (Gap 5).
Status: executable

### sales-return.refusal.card-without-bank   (T06 Required/invalid)
Layer: database
Steps: 1. Save line R with card refund 1,000 and no bank account.
Expected: `Please Select Card Bank Account And Try Because Card Amt <> 0......` (`TR_SALE_RTN.cs:12217 {{Please Select Card Bank Account And Try Because Card Amt <> 0......}}`); nothing written. Fails today (Gap 5).
Status: executable

### sales-return.refusal.company-type-b   (T06 Required/invalid)
Layer: database
Steps: 1. `CO_MAST.CO_TYPE` = B. 2. Save a new return with line R. 3. Edit an existing return (created before the type was set).
Expected: step 2 `You Cant Save This Voucher Becouse This Company Type is B......` (`TR_SALE_RTN.cs:12232 {{Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);}}`), nothing written; step 3 is allowed (the test is `EntryMode = "A"` only, D14). Fails today (Gap 5).
Status: executable

### sales-return.refusal.date-outside-year   (T06 Required/invalid)
Layer: database
Steps: 1. Year 2024-04-01 to 2025-03-31. 2. Save with date 2025-04-02.
Expected: `You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...` (`TR_SALE_RTN.cs:12262 {{You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...}}`); nothing written. Fails today (Gap 5).
Status: executable

### sales-return.refusal.lock-date   (T06 Required/invalid)
Layer: database
Steps: 1. `CO_SET.LOCK_DATE` 2024-04-10. 2. Save a new return dated 2024-04-10.
Expected: `You Cant Save and Delete This Voucher Becouse Lock Date is = 10/04/2024 ....` (`TR_SALE_RTN.cs:12277 {{You Cant Save and Delete This Voucher Becouse Lock Date is = }}`; on or before the lock date is refused, `>= 0`); nothing written.
Status: executable (may already pass through the posting gate; the case pins the text)

### sales-return.accept.cash-refund-over-limit   (T06 Required/invalid)
Layer: database
Steps: 1. `CO_SET.CASH_LIMIT` 1,000. 2. Save line R with cash refund 65,517.
Expected: saved (D10: the desktop limit reads the sale-side cash `MSG2_TOTAL[6, 4]`, which a return-only voucher leaves 0: 0 + prior ≤ limit).
Status: executable

### sales-return.accept.defaulter-party   (T06 Required/invalid)
Layer: database
Steps: 1. Party `CUST` with `DEFAULTER_AC` Y. 2. Save line R as a credit note (no refund).
Expected: saved (D10: the defaulter test reads the sale-side `BILL_OS` `MSG2_TOTAL[8, 4]`, 0 on a return-only voucher).
Status: executable

## T07 Create

### sales-return.create.effects / create.amount-net-basis / create.records-user / create.cash-refund / create.interstate-igst   (T07 Create)
Layer: browser (existing cases, unchanged)
Status: executable

## T08 Reopen / no-op

### sales-return.reopen.lossless-no-op   (T08 Reopen/no-op)
Layer: database (HTTP route)
Steps: 1. Create a return of tagged `TAGRT` (line R values) and loose line `LOOSE` (net 1, touch 90, rate 100, fixed labour 25) against `SAL/00001`, cheque refund 1,000 to `BANK1`, employee `E7`. 2. `GET /sales-returns/00008`. 3. Snapshot every column of `SL_DATA`, `SL_DETL_RTN`, `MAIN_STOCK`, `AC_DATA`, `TAX_DATA`, `ROJ_MEL_DATA`, `BILL_OS_DATA`, `DM_DATA`, `REMARK_DATA`, `TEMP_BOOK_DATA` for the voucher (without the database `row_id`). 4. `PUT` the GET body back unchanged with its `version`. 5. Snapshot again.
Expected: snapshots equal column for column (clock, hidden number `HD_VCH_NO`, creator `MAIN_USER`, `ISU_*`, `ENTRY_TIME` included); zero `USER_DATA` rows (D5: no column differs, so the loop at `TR_SALE_RTN.cs:13512 {{Operators.ConditionalCompareObjectNotEqual}}` writes nothing). Fails today: no PUT route and the GET drops line inputs (Gap 1).
Status: executable

### sales-return.reopen.saved-panel   (T08 Reopen/no-op)
Layer: browser (existing case, unchanged)
Status: executable

## T09 Edit

### sales-return.edit.numeric   (T09 Edit)
Layer: browser (was `blocked`; made executable)
Steps: 1. Create a return of line R through the form. 2. Type its voucher number in `Open Vch No`, press Open. 3. Change Net Wt 10 → 9. 4. Save Return.
Expected: `PUT` 200; same voucher number; `SL_DETL_RTN` one row `ITM_NWT` 9, `ITM_AMT` 55,111, `LBR_AMT` 2,138, `NET_AMT` 57,249; `SL_DATA` `TOT_AMT` 58,966; `MAIN_USER` unchanged; `AC_DATA` balanced. Desktop: edit rewrites the voucher (`TR_SALE_RTN.cs:12496 {{DC_Main.ExeQuteDc("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  C}}`) under the same number. Fails today (Gap 1, Gap 8).
Status: executable

### sales-return.edit.audit-user-data   (T09 Edit)
Layer: database
Steps: 1. Create line R as user `return-owner`. 2. Edit to R' as user `editor`.
Expected: `USER_DATA` rows for `NET_AMT` (63609 → 57249), `TAX_AMT` (1908.27 → 1717.47) and `TOT_AMT` (65517 → 58966), each `USER_NAME` `return-owner`, `NEW_USER` `editor`, `ENTRY_CHECK` `N`; no row for `AC_CODE`, `VCH_DATE`, `MAIN_USER` (D5, `TR_SALE_RTN.cs:13541 {{INSERT INTO USER_DATA}}`). Fails today: none written (Gap 6).
Status: executable

### sales-return.edit.keeps-creator-and-clock   (T09 Edit)
Layer: database (existing `salesFamilyLifecycle.db.test.ts` case, unchanged)
Expected: `MAIN_USER` stays the creator (`TR_SALE_RTN.cs:10181 {{MainUser = Conversions.ToString}}`), the clock stays.
Status: executable

## T10 Delete / cancel

### sales-return.delete.reverses-once / delete.audit-user   (T10 Delete)
Layer: browser (existing cases, unchanged)
Status: executable

## T11 Scope / rights

### sales-return.rights.edit-needs-update   (T11 Scope/rights)
Layer: database (HTTP route)
Steps: 1. A user whose `USER_SET` row for `Sales Return` has `FRM_EDIT` = N sends `PUT /sales-returns/00008`.
Expected: 403; write set unchanged. Desktop: `TR_SALE_RTN.cs:12292 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}}` then `TR_SALE_RTN.cs:12299 {{You Have No Rights.....}}`.
Status: executable

### sales-return.rights.clerk-no-return   (T11 Scope/rights)
Layer: browser (existing case, unchanged)
Status: executable

## T12 Concurrency

### sales-return.concurrency.stale-edit   (T12 Concurrency)
Layer: database (HTTP route)
Steps: 1. Two sessions GET the same return (same `version`). 2. The first PUTs R'. 3. The second PUTs R with the old version.
Expected: the second is `409 voucher-version-conflict`; the voucher keeps R' (D12, web multi-user guard; the desktop has none).
Status: executable

### sales-return.concurrency.double-delete   (T12 Concurrency)
Layer: browser (existing case, unchanged)
Status: executable

## T13 Retry

### sales-return.retry.double-click   (T13 Retry)
Layer: browser (existing case, unchanged)
Status: executable

### sales-return.budget.timeout-is-retryable   (T13 Retry)
Layer: database (HTTP route)
Steps: 1. `DATACARE_TX_BUDGET_VOUCHER_MS` = 1,500. 2. Another session holds the SRT numbering lock. 3. `POST /sales-returns` line R. 4. Release, retry.
Expected: step 3 is `503 {"error":"transaction-timeout","retryable":true}` within 5 s, no row written; step 4 is 201 (D13). Fails if the create is not bounded (Gap 2).
Status: executable

## T14 Rollback

### sales-return.rollback.mid-write   (T14 Rollback)
Layer: browser (existing case, unchanged)
Status: executable

### sales-return.rollback.refused-edit-keeps-voucher   (T14 Rollback)
Layer: database
Steps: 1. Create line R. 2. Edit it to a zero-value line.
Expected: refused with `Please Insert Item Value and try`; the stored write set (all ten tables of `reopen.lossless-no-op`) is unchanged: the delete-then-rewrite of `TR_SALE_RTN.cs:12496 {{DELETE FROM SL_DATA WHERE}}` happens inside one transaction in the web (desktop weakness not ported). Fails today: the zero edit is saved (Gap 3).
Status: executable

## T15 Config / history

### sales-return.config.amount-type   (T15 Config/history)
Layer: browser (existing case, unchanged)
Status: executable

## T16 Report / output

### sales-return.print.credit-note / print.after-access-expiry   (T16 Report/output)
Layer: browser (existing cases, unchanged)
Status: executable

## T17 Keyboard

### sales-return.keyboard.alt-s-saves   (T17 Keyboard)
Layer: browser (existing case, unchanged; `TR_SALE_RTN.cs:2406 {{BtnSave.Text = "&Save";}}`)
Status: executable

### sales-return.keyboard.open-with-enter   (T17 Keyboard)
Layer: browser
Steps: 1. Type a saved voucher number in `Open Vch No`. 2. Press Enter.
Expected: the voucher loads into the form (the desktop voucher box acts on keys: `TR_SALE_RTN.cs:15495 {{if ((int)e.KeyCode == 112)}}` F1 list; the web's Enter opens the typed number). Fails today (Gap 1).
Status: executable

## T18 Journey

### sales-return.journey.sale-then-return   (T18 Journey)
Layer: browser (existing case, unchanged)
Status: executable

### sales-return.budget.create-p95   (T18 Journey)
Layer: database (HTTP route)
Steps: 1. Warm up one create. 2. Create 20 returns of line R in sequence through `POST /sales-returns`, timing each.
Expected: p95 < 5,000 ms (D13; the plan target "Voucher save p95 under the 5 s transaction budget"). The load profile (`web/scripts/load-profile.mjs`) also reports a `return_create` operation.
Status: executable

## Coverage table

| Kind | Cases | Blocked | New in WP-27 |
|---|---|---|---|
| T01 Entry/defaults | 2 | 0 | 1 |
| T02 Field route | 2 | 0 | 2 |
| T03 Formula | 2 | 0 | 1 |
| T04 Lookup | 5 | 0 | 3 |
| T05 Children | 2 | 0 | 1 |
| T06 Required/invalid | 10 | 0 | 9 |
| T07 Create | 5 | 0 | 0 |
| T08 Reopen/no-op | 2 | 0 | 1 |
| T09 Edit | 3 | 0 | 2 (edit.numeric unblocked) |
| T10 Delete/cancel | 2 | 0 | 0 |
| T11 Scope/rights | 2 | 0 | 1 |
| T12 Concurrency | 2 | 0 | 1 |
| T13 Retry | 2 | 0 | 1 |
| T14 Rollback | 2 | 0 | 1 |
| T15 Config/history | 1 | 0 | 0 |
| T16 Report/output | 2 | 0 | 0 |
| T17 Keyboard | 2 | 0 | 1 |
| T18 Journey | 2 | 0 | 1 |
| **Total** | **50** | **0** | **28** |

## Test data

- Company 01, location 01, year 2024-2025 (`YEAR_MAST` 2024-04-01 to 2025-03-31), `CO_SET` with blank lock date.
- Books `SAL` (MAIN_BOOK SALES) and `SRT` (SALES RETURNE) with `BOOK_DETL` slots 1 (control), 2 (cash), 3 (round).
- Party `CUST` (local GST), tax code 10 at 3% with account `GSTLED`, group with a sale account, items `GOLD` and `LOOSE`.
- Sale `SAL/00001`: tagged line `TAGRT` (with its `BAR_DETL` and a `MAIN_STOCK` + and − pair) and a loose `N` line.
- For the route cases: a login with full Sales Return rights, one with `FRM_EDIT` = N.
- Browser cases: the fixture catalogue as today; the voucher under test is created through the screen.

## Not covered

- Licence expiry (`TR_SALE_RTN.cs:12113 {{Your lIcence Has been Expired}}`): not a web concept.
- Counter-code mandatory (`TR_SALE_RTN.cs:12347 {{Please Insert Tag Entry Counter Code and Try Because It is Mandatory...}}`): the web return form has no counter column in its base grid; the
  counter-stock setting belongs to WP for tag stock. Recorded, not changed.
- The return header stores the return in sale-side columns (`NET_AMT`, `TOT_AMT`, `CASH_AMT`, `BILL_OS`) where the
  desktop uses `RTN_*` (`TR_SALE_RTN.cs:12707 {{dataRow2["RTN_NET_AMT"] = Conversion.Val(nAcCrAmt.Text);}}`,
  `TR_SALE_RTN.cs:12801 {{dataRow2["RTN_CASH_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);}}`): open as G246 (WP-11), out of scope here.
- Print template name (Gap 7, G127): `SalesRtnA4Gst.RPT` / `SalesRtnA4.RPT` by book type `T` (`TR_SALE_RTN.cs:15198 {{if (Operators.CompareString(FormBookType, "T", false) == 0)}}`); print is out of scope.
- Percentage labour (PR #241); the UAE form; the saved-incoming-return pipeline; ledger book slots (G116).
- Tab order and enabled rules of the screen (study open question 6): not read in this package.
- Stale delete (T12): `DELETE /sales-returns/:vchNo` takes no version yet; the double-delete case covers the
  observable risk. Left to the N51 programme.
