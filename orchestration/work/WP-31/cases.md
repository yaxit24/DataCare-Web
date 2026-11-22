# WP-31 cases: Contra Entry (TR_CONTRA) residuals

Frozen case list for the menu Transaction → Contra Entry. Source: `orchestration/work/WP-31/study.md` (gap numbers
G1..G22 below are the study's "Gaps" numbers, not plan ids; G23 and G24 are two gaps found while writing this list).
Module: `web/apps/web/test/features/modules/contraEntry.mjs` (25 cases today, ids kept where the behaviour is the same).
DB layer: `web/apps/api/test/contraResiduals.db.test.ts` (new, `wp31`). Unit layer: `web/apps/api/test/contraGrid.test.ts` (new).

## Decisions (architect, 2026-11-23, owner may override)

Rule used: the desktop first; the web adds only what a hosted multi-user service needs to be safe and correct.

- D1 Empty grid (study Open question 1): refused with the desktop text `Cr Value and Dr Value is not same`. The desktop saves an
  empty voucher (TR_CONTRA.cs:2692 {{Conversion.Val(MSG_TOT[0, 5]) != Conversion.Val(MSG_TOT[0, 6])}} passes at 0 = 0); an empty voucher
  has no number worth keeping in a shared service.
- D2 Row 1 is positional and its side is the user's choice (DR default). Every later row takes the opposite side (G1). A row i >= 2 with
  no account AND no amount is skipped as the desktop does (TR_CONTRA.cs:2765 {{Conversion.Val(mSG[DC_Main.i, 6]) + Conversion.Val(mSG[DC_Main.i, 5]) != 0.0}}).
  The web adds: a row with an amount but no account, a negative amount, and an account that is not in this company's AC_MAST are refused
  (the desktop drops the first silently, so the totals balance while the ledger does not; it never validates codes at save).
- D3 Amounts are stored as the desktop cell shows them: `Format(Val(text),"0.00")`, i.e. rounded to 2 decimals with `round` from core
  (TR_CONTRA.cs:1695 {{mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");}}).
- D4 Licence refusal (Rule 1): N/A, the hosted service has no `MsSoftNoUse` flag (study Open question 8). Company type B on a new voucher is ported (G6).
- D5 Per-voucher permission request (`UT_USER_REQUEST`, G14): not ported. Edit and delete need the role's update and delete right; USER_UPDATE and
  USER_DELETE are written `N` as the desktop does after a save (TR_CONTRA.cs:2814 {{dataRow2["USER_UPDATE"] = "N";}}).
- D6 "Account roles (G37)": the packet's G37 is "Report presentation" in the plan; the desktop has no account role rule beyond "any AC_MAST account of the
  company". The cases test exactly that, plus tenant and company isolation. The Contra Register presentation (the real G37 / N57 change) stays in the
  existing `contra.report.contra-register` case.
- D7 Voucher version token (hosted safety, not in the desktop): GET returns `version`; PUT sends `expectedVersion`; DELETE sends it as a query parameter. Stale or
  missing is refused before any write (409 `voucher-version-conflict`, 400 for a missing token), as purchaseVoucher.ts does. The version covers CONTRA_DATA, AC_DATA,
  ROJ_MEL_DATA and REMARK_DATA.
- D8 Edit and delete reverse the old postings exactly once, in one transaction: CONTRA_DATA, AC_DATA, ROJ_MEL_DATA, REMARK_DATA, TEMP_BOOK_DATA (edit keeps the hidden number),
  and the bank clearing marks (AC_DATA.CLR_DATE and BANK_RECONCILE by LEDR_KEY). Edit keeps a clearing mark only for a leg whose key, account and amount are unchanged;
  delete removes the marks of the voucher's keys (a deleted last number is reused by `MAX+1`, TR_CONTRA.cs:2393 {{Select MAX(VCH_NO) As VchNo  From CONTRA_DATA WHERE CO_CODE}}, and must not come back pre-cleared).
- D9 An unchanged reopen followed by Save keeps every stored column identical: VCH_DATE is the loaded date (never today), VCH_TIME clock, EMP_CODE, HD_VCH_NO, MAIN_USER,
  every IT_DESC and every amount.
- D10 Reopen never merges equal rows (study desktop weakness 9 not ported): each LDR_TYPE '0' record is a grid row.
- D11 Delete of a number that does not exist is refused (404-style "voucher not found"), not "Delete Success." (weakness 3 not ported); the delete never touches another year's rows.
- D12 F1 list: the desktop shape, one line per voucher × account × description with that group's CrAmt and DrAmt (TR_CONTRA.cs:3144 {{GROUP BY A.VCH_NO,A.VCH_DATE,B.AC_NAME,A.IT_DESC,A.MAIN_USER ORDER BY A.VCH_NO}}),
  served by a new route GET /contra/list; the shared "Recent vouchers" list stays for the other screens.
- D13 Print: the page prints the saved voucher after save when the role has the print right (TR_CONTRA.cs:2902 {{BtnPrint_Click(BtnPrint, new EventArgs());}}); the printed voucher lists every grid
  leg with its Dr and Cr and the voucher total (G23). Layout and copy labels from the Crystal file stay blocked (the file is binary: study Open question 4).
- D14 Employee: mandatory by the company setting, stored on every row, typed code must exist (G5). The prefill from `MsEmpAsUser` is blocked: the web session has no user → employee link.
- D15 Header: Day and Time are shown read-only; the voucher number box keeps the web's free typing (the double-click unlock and the hidden number box are desktop-only chrome, N/A).
- D16 Opening-balance label (G16): blocked, needs a balance-as-of-date API owner (study Open question 7).

## Seed

See "Test data". Book `CON` is a CONTRA book with BOOK_INOUT `O`; accounts `00001 CASH ON HAND`, `00008 BANK A/C`, `00009 BANK B/C`.

## Cases

### contra.entry.defaults   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open /txn/contra. 2. Read the header and the grid.
Expected: book select filled with the CONTRA book; date = today; the Day and Time read-only boxes show the weekday name and a HH:mm:ss clock (TR_CONTRA.cs:2368 {{mTime.Text = DateTime.Now.ToString("HH:mm:ss");}}); employee box present; grid row 1 side `DR`,
row 2 side `CR` read-only (TR_CONTRA.cs:1532 {{mSG[1, 1] = "DR";}}); the voucher total row reads `Total :` with `0.00` and `0.00` (TR_CONTRA.cs:1504 {{mSG_TOT[0, 3] = "Total :";}}); fails today on Day/Time, employee box, read-only side (G1, G5, G18).
Status: executable

### contra.entry.header-captions   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open /txn/contra. 2. Read the grid captions and the buttons.
Expected: grid headers `Sr, Cr/Dr, AcCode, Ac Name, It Desc, CrAmt, DrAmt` (TR_CONTRA.cs:1426 {{mSG[0, 0] = "Sr";}}, TR_CONTRA.cs:1429 {{mSG[0, 1] = "Cr/Dr";}}, TR_CONTRA.cs:1432 {{mSG[0, 2] = "AcCode";}}, TR_CONTRA.cs:1435 {{mSG[0, 3] = "Ac Name";}}, TR_CONTRA.cs:1438 {{mSG[0, 4] = "It Desc";}},
TR_CONTRA.cs:1452 {{mSG[0, 5] = "CrAmt";}}, TR_CONTRA.cs:1455 {{mSG[0, 6] = "DrAmt";}}); buttons Print, Save, Cancel, Delete, Exit (TR_CONTRA.cs:1155 {{BtnPrint.Text = "&Print";}}, TR_CONTRA.cs:1182 {{BtnCancel.Text = "&Cancel";}}). Today the grid has one Amount column (G15).
Status: executable

### contra.entry.side-readonly   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the form. 2. Add a third row. 3. Try to change the Cr/Dr cell of rows 2 and 3. 4. Change row 1 to CR.
Expected: rows 2 and 3 show the side opposite to row 1 and are read-only (TR_CONTRA.cs:1630 {{((TextBoxBase)TEXT_ENTRY).ReadOnly = true;}}); after row 1 becomes `CR` both later rows read `DR`; in a DR row the CrAmt cell is read-only and in a CR row the DrAmt cell is read-only
(TR_CONTRA.cs:1643 {{if (Operators.CompareString(mSG[mSG.Row, 1], "DR", false) == 0)}}). Fails today: every row has its own side select (G1).
Status: executable

### contra.grid.mixed-sides-refused   (T06 Required/invalid)
Layer: database
Steps: 1. POST /contra with lines DR 00008 100, DR 00001 50, CR 00009 150 (two debit rows, one credit row, totals 150 = 150). 2. Count the voucher write set.
Expected: refused with 400 and the text `A contra row after the first must take the opposite side of row 1` (web text: the desktop screen cannot produce this grid, TR_CONTRA.cs:1538 {{mSG[mSG.Row, 1] = "DR";}} fixes the sides); zero rows written in CONTRA_DATA, AC_DATA, ROJ_MEL_DATA, REMARK_DATA, TEMP_BOOK_DATA. Fails today: it saves (G1).
Status: executable

### contra.grid.row1-positional   (T06 Required/invalid)
Layer: unit
Steps: 1. contraLines with row 1 empty (no account, no amount), row 2 CR 00001 100, row 3 DR 00008 100.
Expected: the grid is not re-based: the call is refused with `You Cant Save This Voucher Becouse Cr Value and Dr Value is not same....` because row 1 is zero: totals Cr = 100 and Dr = 100 would balance only after promoting row 3 to row 1, which the desktop never does
(TR_CONTRA.cs:2781 {{dataRow2["LD_CODE"] = mSG[1, 2];}}; row 1 is always the head). Arithmetic with row 1 as typed: Dr total = 0 (row 1) + 0, Cr total = 100 (row 2) + 0; 0 != 100. Fails today (G3): the filter drops row 1 and the voucher saves with row 3 as head.
Status: executable

### contra.grid.empty-refused   (T06 Required/invalid)
Layer: unit
Steps: 1. contraLines with no lines. 2. with three rows all blank. 3. with one filled row (DR 00008 100).
Expected: all three refused with the desktop text `You Cant Save This Voucher Becouse Cr Value and Dr Value is not same....` (TR_CONTRA.cs:2694 {{You Cant Save This Voucher Becouse Cr Value and Dr Value is not same....}}). One filled row: Dr 100, Cr 0, 100 != 0. Empty: decision D1. Fails today: the web text is `a contra needs at least two accounts with positive amounts` (G4).
Status: executable

### contra.refusal.unequal-totals   (T06 Required/invalid)
Layer: browser
Steps: 1. Row 1 DR 00008 1,000; row 2 CR 00001 900. 2. Save.
Expected: the message `You Cant Save This Voucher Becouse Cr Value and Dr Value is not same....` (TR_CONTRA.cs:2694 {{You Cant Save This Voucher Becouse Cr Value and Dr Value is not same....}}); nothing is written. Existing case, kept.
Status: executable

### contra.grid.amount-without-account   (T06 Required/invalid)
Layer: database
Steps: 1. POST /contra: DR 00008 100, CR 00001 60, CR (no account) 40.
Expected: refused 400 `Account code is required on row 3` (decision D2; the desktop drops row 3 but its CrAmt still enters the totals, TR_CONTRA.cs:2765 {{Conversion.Val(mSG[DC_Main.i, 6]) + Conversion.Val(mSG[DC_Main.i, 5]) != 0.0}} would skip it, leaving Dr 100 vs ledger Cr 60). Zero rows written.
Status: executable

### contra.grid.negative-amount   (T06 Required/invalid)
Layer: unit
Steps: 1. contraLines DR 00008 -100, CR 00001 -100.
Expected: refused `Amount cannot be negative on row 1` (decision D2; the desktop text box accepts only what `Val` reads and a negative would flip the leg in `CR_AMT <> 0` posting). Fails today with the thin-grid text (G4).
Status: executable

### contra.grid.unknown-account   (T06 Required/invalid)
Layer: database
Steps: 1. POST /contra: DR 00008 100, CR 99999 100 (99999 is not in AC_MAST). 2. POST with CR 00001 of ANOTHER company or tenant.
Expected: refused 400 `Account code 99999 is not in this company`; the account of another tenant is also refused (RLS hides it); zero rows written (decision D2/D6).
Status: executable

### contra.grid.rounding   (T03 Formula sequence)
Layer: unit
Steps: 1. contraLines DR 00008 1234.567, CR 00001 1234.567 and then DR 00008 0.1, CR 00001 0.04, CR 00009 0.06.
Expected: cell format `Format(Val,"0.00")` stores 1234.57 on both sides (TR_CONTRA.cs:1695 {{mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");}}); totals are text totals re-formatted at each add:
0.04 → "0.04", + 0.06 → "0.10" (TR_CONTRA.cs:1516 {{mSG_TOT[0, 5] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 5]) + Conversion.Val(MSG[DC_Main.M, 5]))), "0.00");}}); 0.04 + 0.06 = 0.10 equals 0.1, accepted although the float sum is 0.09999999999999999.
Fails today on the first vector only if the stored amount keeps 1234.567 (G4).
Status: executable

### contra.grid.totals-formula   (T03 Formula sequence)
Layer: browser
Steps: 1. Type DR 00008 3,000.50 in row 1; CR 00001 1,000.25 in row 2; CR 00009 2,000.25 in row 3, reading the Total row after each cell.
Expected: after row 1: CrAmt total `0.00`, DrAmt total `3000.50`; after row 2: `1000.25` / `3000.50`; after row 3: Arithmetic 1000.25 + 2000.25 = 3000.50, so CrAmt `3000.50` / DrAmt `3000.50` and the indicator reads balanced (TR_CONTRA.cs:1522 {{NewValTot = Conversion.Val(MSG_TOT[0, 5]) + Conversion.Val(MSG_TOT[0, 6]);}} 3000.50 + 3000.50 = 6001.00). Existing case `formula.totals` covers two rows; the third is new. Today the page shows one en-IN number per side (G15).
Status: executable

### contra.create.two-rows   (T07 Create)
Layer: browser
Steps: 1. Row 1 DR 00008 5,000; row 2 CR 00001 5,000. 2. Save.
Expected: 201 and a number; CONTRA_DATA has 2 rows: SR 1 LDR_TYPE 0 CR 00001 CR_AMT 5000 LD_CODE 00008; SR 2 LDR_TYPE 1 CRDR_TYPE DR AC 00008 DR_AMT 5000 LD_CODE 00001 (TR_CONTRA.cs:2797 {{dataRow2["CR_AMT"] = Conversion.Val(mSG[DC_Main.i, 5]);}}, TR_CONTRA.cs:2864 {{dataRow2["DR_AMT"] = Conversion.Val(mSG[DC_Main.i, 5]);}}, SR_NO counter TR_CONTRA.cs:2778 {{dataRow2["SR_NO"] = DC_Main.R;}}); AC_DATA legs `1`+`01` credit on 00001 and `2`+`02` debit on 00008. Existing case, kept.
Status: executable

### contra.create.three-rows   (T07 Create)
Layer: browser
Steps: 1. Row 1 DR 00008 3,000.50 desc `DEPOSIT`; row 2 CR 00001 1,000.25 desc `FROM CASH`; row 3 CR 00009 2,000.25 desc `FROM B2`. 2. Save.
Expected: 4 CONTRA_DATA rows: SR1 LDR 0 CR 00001 1000.25 desc `FROM CASH`; SR2 LDR 1 DR 00008 1000.25 desc `DEPOSIT`; SR3 LDR 0 CR 00009 2000.25 desc `FROM B2`; SR4 LDR 1 DR 00008 2000.25 desc `DEPOSIT` (the mirror takes row 1's description:
TR_CONTRA.cs:2868 {{dataRow2["IT_DESC"] = mSG[1, 4];}}); AC_DATA keys 101 (Cr 00001), 202 (Dr 00008), 301 (Cr 00009), 402 (Dr 00008); balances: 00008 +3000.50 Dr, 00001 1000.25 Cr, 00009 2000.25 Cr, sum zero. Fails today on the mirror descriptions (G2).
Status: executable

### contra.create.mirror-description   (T02 Field route)
Layer: database
Steps: 1. POST the three-row grid above. 2. Read CONTRA_DATA, REMARK_DATA and the print data.
Expected: CONTRA_DATA mirrors (LDR 1) carry `DEPOSIT`, counters (LDR 0) carry their own row's text; REMARK_DATA has one row per CONTRA_DATA row with a non-empty description, ordered by SR_NO: 4 rows with texts FROM CASH, DEPOSIT, FROM B2, DEPOSIT (Ac_Tax.cs:686 {{AND A.IT_DESC <> '' ORDER BY A.SR_NO}}).
A voucher-wide narration field does not exist in the desktop (G2): a request carrying `itDesc` outside the grid is ignored; with a blank row 1 description the mirror description is empty, never the row i text.
Status: executable

### contra.create.remark-data   (T07 Create)
Layer: database
Steps: 1. POST a grid whose row 1 and row 3 have no description, row 2 has `X`. 2. Count REMARK_DATA of the voucher.
Expected: CONTRA_DATA rows with `<> ''` description only: grid rows 1 `''`, 2 `X`, 3 `''` give counters SR1 `X`, SR3 `''`, mirrors `''`, `''`: exactly 1 REMARK_DATA row (SR_NO 1). Same rule at Ac_Tax.cs:686 {{AND A.IT_DESC <> '' ORDER BY A.SR_NO}}. Fails today: 0 rows (G9).
Status: executable

### contra.create.write-set   (T07 Create)
Layer: database
Steps: 1. POST the three-row grid. 2. Read the full footprint through SQL aggregates.
Expected: CONTRA_DATA 4, AC_DATA 4, ROJ_MEL_DATA 4, REMARK_DATA 4, TEMP_BOOK_DATA 1, DELETE_DATA 0; every CONTRA_DATA row has IT_TYPE `A` (TR_CONTRA.cs:2794 {{dataRow2["IT_TYPE"] = "A";}}), DR_FINE 0, CR_FINE 0, DATA_TRFR `N`, USER_UPDATE `N`, USER_DELETE `N`, RE_TRFR not `Y`, INOUT_TYPE equal to the book's BOOK_INOUT `O`
(TR_CONTRA.cs:2774 {{dataRow2["INOUT_TYPE"] = FormBookInOut;}}); Σ DR_AMT = Σ CR_AMT over AC_DATA = 6001.00 / 2 → each side 3000.50. Fails today: INOUT_TYPE `I`, REMARK_DATA 0 (G7, G9).
Status: executable

### contra.create.item-type-fixed   (T02 Field route)
Layer: database
Steps: 1. POST with `itemType: "G"` in the body (and PUT likewise).
Expected: IT_TYPE `A` on every row of a CONTRA book (TR_CONTRA.cs:2794 {{dataRow2["IT_TYPE"] = "A";}}); the client value is ignored. Fails today on PUT (G8).
Status: executable

### contra.create.employee   (T02 Field route)
Layer: browser
Steps: 1. Type employee code `E01` (seeded, name `EMP ONE`) in the Employee box; the name fills. 2. Enter the two-row voucher and Save. 3. Read EMP_CODE of all rows.
Expected: every CONTRA_DATA row has EMP_CODE `E01` (TR_CONTRA.cs:2803 {{dataRow2["EMP_CODE"] = tEmpCode.Text;}}). Fails today: no employee box, EMP_CODE null (G5).
Status: executable

### contra.refusal.employee-mandatory   (T06 Required/invalid)
Layer: database
Steps: 1. Set CO_SET.EMP_CODE_MANDATORY `Y`. 2. POST a balanced grid without an employee. 3. POST with an unknown employee `ZZ9`.
Expected: refused `Please Select Employee Code and Try......` (TR_CONTRA.cs:2668 {{Please Select Employee Code and Try......}}) before the date and balance checks; unknown code refused `Employee ZZ9 is not in this company`; zero rows. With the setting `N` and no employee the voucher saves with EMP_CODE empty. Fails today: saves (G5).
Status: executable

### contra.refusal.company-type-b   (T06 Required/invalid)
Layer: database
Steps: 1. Set CO_MAST.CO_TYPE `B`. 2. POST a balanced grid. 3. Reopen an older voucher and save an edit (setting restored first for the older voucher).
Expected: new voucher refused `You Cant Save This Voucher Becouse This Company Type is B......` (TR_CONTRA.cs:2675 {{You Cant Save This Voucher Becouse This Company Type is B......}}), condition new entry only; the edit of an existing voucher under type B is allowed. Zero rows on the refusal. Fails today (G6).
Status: executable

### contra.refusal.check-order   (T06 Required/invalid)
Layer: database
Steps: 1. Employee mandatory and blank, date outside the year, date locked, totals unequal all at once; remove one fault at a time in the desktop order.
Expected: messages in the order employee (TR_CONTRA.cs:2668 {{Please Select Employee Code and Try......}}), company type (TR_CONTRA.cs:2675 {{You Cant Save This Voucher Becouse This Company Type is B......}}), year (TR_CONTRA.cs:2682 {{You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...}}), lock date (TR_CONTRA.cs:2688 {{You Cant Save and Delete This Voucher Becouse Lock Date is = }}), totals (TR_CONTRA.cs:2694 {{You Cant Save This Voucher Becouse Cr Value and Dr Value is not same....}}). Nothing written at any step.
Status: executable

### contra.refusal.date-outside-year   (T06 Required/invalid)
Layer: browser
Steps: 1. Set the date one day before the year start. 2. Save a balanced grid.
Expected: `You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...` (TR_CONTRA.cs:2682 {{You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...}}). Existing case, kept.
Status: executable

### contra.create.first-day-of-year   (T07 Create)
Layer: browser
Steps: 1. Date = year opening date. 2. Save.
Expected: saves (the test is `OpDate > date`, TR_CONTRA.cs:2680 {{DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0}}, equal passes). Existing case, kept.
Status: executable

### contra.settings.lock-date   (T15 Config/history)
Layer: browser
Steps: 1. Lock date = the voucher date. 2. Save a new voucher. 3. Lock date = the day before and save.
Expected: first: `You Cant Save and Delete This Voucher Becouse Lock Date is = ` + the date + ` ....` (TR_CONTRA.cs:2686 {{DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0}}: on or before the lock date refuses); second saves. Existing create case kept; edit and delete cases are below.
Status: executable

### contra.lifecycle.edit-locked-and-out-of-year   (T09 Edit)
Layer: database
Steps: 1. Save V on date D. 2. Lock date = D. 3. PUT V unchanged. 4. Clear the lock; PUT V with the date moved to year start minus one day. 5. Lock = D again and DELETE V.
Expected: step 3 refused with the lock text (TR_CONTRA.cs:2688 {{You Cant Save and Delete This Voucher Becouse Lock Date is = }}); step 4 refused with the year text (TR_CONTRA.cs:2682 {{You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...}}), checked before the lock; step 5 refused with the lock text (TR_CONTRA.cs:2953 {{You Cant Save and Delete This Voucher Becouse Lock Date is = }}); in every case the write set is byte-identical before and after (rows, row ids, AC_DATA keys). G20.
Status: executable

### contra.reopen.grid-roundtrip   (T08 Reopen/no-op)
Layer: database
Steps: 1. Save the three-row grid. 2. GET /contra/:vchNo.
Expected: `lines` = row 1 DR 00008 3000.50 desc `DEPOSIT`; row 2 CR 00001 1000.25 `FROM CASH`; row 3 CR 00009 2000.25 `FROM B2` (row 1 = Σ of the LDR 1 records 1000.25 + 2000.25 = 3000.50, TR_CONTRA.cs:2467 {{AND LDR_TYPE = '1' GROUP BY AC_CODE,AC_NAME,CRDR_TYPE,IT_DESC}}; rows 2.. from LDR 0, TR_CONTRA.cs:2541 {{AND LDR_TYPE = '0' GROUP BY AC_CODE,AC_NAME,CRDR_TYPE,IT_DESC}}); header: date, employee, hidden number, user; `version` is a 64-hex string.
Fails today: row 1 has no description and there is no employee or version.
Status: executable

### contra.reopen.equal-rows-not-merged   (T08 Reopen/no-op)
Layer: database
Steps: 1. Save DR 00008 200, CR 00001 100 `A`, CR 00001 100 `A` (two identical rows). 2. Reopen.
Expected: three grid rows come back (the desktop GROUP BY would show two: TR_CONTRA.cs:2541 {{AND LDR_TYPE = '0' GROUP BY AC_CODE,AC_NAME,CRDR_TYPE,IT_DESC}}; weakness 9 is not ported, D10); a second save of the reopened grid changes nothing.
Status: executable

### contra.edit.unchanged-save   (T08 Reopen/no-op)
Layer: database
Steps: 1. Save the three-row grid with employee `E01` on 2026-04-15 (an old date, not today). 2. GET, then PUT the same payload with the returned `version` and `expectedVersion`. 3. Compare every stored column of CONTRA_DATA, AC_DATA, ROJ_MEL_DATA, REMARK_DATA, TEMP_BOOK_DATA before and after, ignoring only row_id.
Expected: identical: VCH_DATE 2026-04-15 (never today), VCH_TIME clock, amounts 1000.25 / 2000.25 / 3000.50, descriptions, EMP_CODE `E01`, HD_VCH_NO, MAIN_USER, USER_UPDATE `N`; PUT without `vchDate` keeps the stored date; no DELETE_DATA row (TR_CONTRA.cs:2814 {{dataRow2["USER_UPDATE"] = "N";}}). Existing browser case `edit.unchanged-save` stays; this is the database proof. Fails today: EMP_CODE becomes null and a PUT without a date writes today.
Status: executable

### contra.edit.rewrite-once   (T09 Edit)
Layer: database
Steps: 1. Save DR 00008 5000 / CR 00001 5000. 2. Edit to DR 00008 5000 / CR 00009 2000 / CR 00001 3000 with a new description on row 1. 3. Read all four readers: account ledger of 00001, 00009, 00008, cash book, day book, bank reconciliation list of 00008.
Expected: ledger balances: 00001 Cr 3000, 00009 Cr 2000, 00008 Dr 5000 (the old Cr 5000 on 00001 is gone, not doubled: 00001 shows exactly one voucher line); ROJ_MEL_DATA has exactly 4 rows; REMARK_DATA 4 rows with the new texts and none of the old; TEMP_BOOK_DATA 1 row with the same hidden number; number unchanged (no renumbering in mode E: TR_CONTRA.cs:2739 {{DELETE FROM CONTRA_DATA WHERE CO_CODE}} then rows rewritten under the same number).
Status: executable

### contra.edit.version-required   (T12 Concurrency)
Layer: database
Steps: 1. Save V. 2. GET to read `version` v1. 3. PUT with no `expectedVersion`. 4. PUT with a made-up 64-hex token. 5. PUT with v1.
Expected: step 3: 400 `expectedVersion (the version returned when the voucher was opened) is required`; step 4: 409 `voucher-version-conflict` with the write set untouched; step 5 succeeds and returns a NEW version v2 != v1. Not in the desktop (weakness 4); decision D7.
Status: executable

### contra.concurrency.stale-edit   (T12 Concurrency)
Layer: database
Steps: 1. Two sessions GET V (both see v1). 2. Session A PUTs amount change with v1. 3. Session B PUTs a different change with v1.
Expected: A succeeds; B gets 409 `voucher-version-conflict`; the ledger shows exactly A's postings (one Dr and one Cr set; no double posting). Also two PUTs sent at the same time with v1: exactly one 200 and one 409.
Status: executable

### contra.concurrency.double-delete   (T12 Concurrency)
Layer: browser
Steps: 1. Open V in two pages. 2. Delete in the first, then delete in the second.
Expected: the first deletes; the second is refused (version or not found) and no second DELETE_DATA set is written. Existing case `concurrency.double-delete`, kept; the delete request now carries the version.
Status: executable

### contra.delete.version-required   (T12 Concurrency)
Layer: database
Steps: 1. DELETE with no token. 2. DELETE with a stale token (after an edit). 3. DELETE with the current token.
Expected: 400, 409, 200; after steps 1-2 every table is unchanged; after step 3 the voucher is gone. Decision D7.
Status: executable

### contra.delete.write-set   (T10 Delete/cancel/reverse)
Layer: database
Steps: 1. Save the three-row grid and reconcile (clear) the bank leg 00008: set AC_DATA.CLR_DATE and a BANK_RECONCILE row for each of its two LEDR_KEYs. 2. Delete with the current version. 3. Count all tables for that voucher and the reader results.
Expected: REMARK_DATA 0 (TR_CONTRA.cs:2963 {{DELETE FROM REMARK_DATA WHERE CO_CODE}}), TEMP_BOOK_DATA 0 (TR_CONTRA.cs:2964 {{DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_}}), AC_DATA 0 (TR_CONTRA.cs:2965 {{DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MC}}), ROJ_MEL_DATA 0 (TR_CONTRA.cs:2966 {{DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Ma}}), CONTRA_DATA 0 (TR_CONTRA.cs:2967 {{DC_Main.ExeQuteDc("DELETE FROM CONTRA_DATA WHERE CO_CODE = '" + DC_Mai}}), APR_IDTL 0 (TR_CONTRA.cs:2968 {{DELETE FROM APR_IDTL WHERE CO_CODE}}),
BANK_RECONCILE rows of the voucher's keys 0 (D8); DELETE_DATA has exactly 4 rows, one per CONTRA_DATA row, with VCH_VAL_DR / VCH_VAL_CR 0/1000.25, 1000.25/0, 0/2000.25, 2000.25/0, DELETE_USER the caller (TR_CONTRA.cs:2961 {{INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE}}).
Account ledger balances of 00001, 00009, 00008 return to their pre-voucher values; day book and cash book lose the lines. A voucher of ANOTHER year with the same number keeps all of its rows (no year-less delete: weakness 3). Fails today: REMARK_DATA and clearing marks stay (G9, D8).
Status: executable

### contra.delete.reused-number-not-precleared   (T10 Delete/cancel/reverse)
Layer: database
Steps: 1. Save V (number n, the last), clear its bank leg. 2. Delete V. 3. Save a new identical voucher (gets number n again by MAX+1). 4. Read the bank reconciliation list of 00008.
Expected: the new voucher's bank leg is NOT cleared (CLR_DATE null; uncleared = book): the old mark was removed at delete (D8). Fails today if the mark of the old LEDR_KEY survives.
Status: executable

### contra.edit.clearing-marks   (T09 Edit)
Layer: database
Steps: 1. Save DR 00008 5000 / CR 00001 5000 and clear the bank leg (CLR_DATE 2026-04-20). 2. Edit changing only the description. 3. Edit changing the amount to 4000 (both rows).
Expected: after step 2 the bank leg keeps CLR_DATE 2026-04-20 (same key, account and amount); after step 3 it is un-cleared (a changed amount is a new bank movement, D8) and no orphan BANK_RECONCILE row remains: rows with LEDR_KEY of the voucher = 0 or exactly the legs that still exist.
Status: executable

### contra.delete.audit   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Delete V through the page. 2. Read DELETE_DATA.
Expected: one row per CONTRA_DATA row with the amounts (TR_CONTRA.cs:2961 {{INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE}}). Existing case, kept. The page also shows `Delete Success.` after the deletion (TR_CONTRA.cs:2969 {{Delete Success.}}) and the confirm text is `Are You Sure To Delete This Voucher now?` (TR_CONTRA.cs:2959 {{Are You Sure To Delete This Voucher now?}}); the success text fails today (G13).
Status: executable

### contra.delete.not-found   (T06 Required/invalid)
Layer: database
Steps: 1. DELETE number 99999 that was never saved.
Expected: refused `voucher not found: 99999`, no DELETE_DATA row (decision D11; the desktop reports `Delete Success.` for it, weakness 3).
Status: executable

### contra.lifecycle.cancel   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Reopen V. 2. Change an amount. 3. Click Cancel (Alt+C).
Expected: the form is cleared exactly like a new entry (one DR row, date today, next number) and NOTHING is written: the write set of V is byte-identical (TR_CONTRA.cs:3103 {{CustOpAmt = 0.0;}} then CLEAR_DATA, TR_CONTRA.cs:2349 {{private void CLEAR_DATA()}}). Fails today: there is no Cancel button (G15).
Status: executable

### contra.rights.edit-delete-need-role   (T11 Scope/rights)
Layer: database
Steps: 1. With a role that has view and create only, PUT and DELETE V through the route. 2. With a role with update and delete rights, repeat.
Expected: step 1: 403 on both, write set unchanged (TR_CONTRA.cs:2700 {{You Have No Rights.....}} for an edit without right; TR_CONTRA.cs:2957 {{You Have No Rights.....}} for a delete); step 2 succeeds. USER_UPDATE / USER_DELETE stay `N` (D5).
Status: executable

### contra.rights.print-denied   (T11 Scope/rights)
Layer: browser
Steps: 1. As a user without the print right open /contra/:n/print and press the post-save print.
Expected: refused, the page shows `You Have No Print Rights.....` (TR_CONTRA.cs:3002 {{You Have No Print Rights.....}}); the voucher is saved anyway. Existing case checks the status; the text is new (G12).
Status: executable

### contra.rights.clerk-no-contra   (T11 Scope/rights)
Layer: browser
Steps: 1. Sign in as the clerk with no Contra view. 2. Open /txn/contra and call GET /contra/list.
Expected: the menu is refused and the list returns 403. Existing case, kept.
Status: executable

### contra.rights.voucher-list-needs-contra-view   (T11 Scope/rights)
Layer: browser
Steps: 1. As a user with Contra view and no Sales view, open the list. Existing case, kept.
Expected: lists its own vouchers only.
Status: executable

### contra.rights.fine-jv-book-refused   (T11 Scope/rights)
Layer: browser
Steps: 1. Try a FINE JV book on /txn/contra (GET, PUT, DELETE, list). Existing case, kept.
Expected: refused (TR_CONTRA.cs:1364 {{((Control)cboItemTyp).Visible = false;}} shows the Contra screen is the non-FINE JV mode; the dispatch passes `CONTRA` only: MDI_FORM.cs:8101 {{DC_Main.CurBookHelp("CONTRA");}}). The new /contra/list route is refused for a FINE JV or Journal book too.
Status: executable

### contra.accounts.any-company-account   (T11 Scope/rights)
Layer: database
Steps: 1. Save grids using a cash account, a bank account and a party (debtor) account. 2. Save one with an account of another company in the same tenant.
Expected: any AC_MAST account of THIS company is accepted (no group, cash/bank or AC_GR_NAME restriction, study "Rights"; the lookup is only `Select * From AC_MAST WHERE CO_CODE` at TR_CONTRA.cs:1926 {{Select * From AC_MAST WHERE CO_CODE = '}}); the other company's account is refused (D2, D6); a second tenant's tenant_id rows are invisible and untouched.
Status: executable

### contra.scope.cross-tenant   (T11 Scope/rights)
Layer: database
Steps: 1. Save V in tenant A. 2. As tenant B (same company codes, same book, same number) GET, PUT, DELETE and list.
Expected: 404/not found for GET, PUT and DELETE; B's list does not show V; A's rows unchanged; a voucher saved by B under the same number does not touch A's rows.
Status: executable

### contra.retry.double-click   (T13 Retry/unknown)
Layer: browser
Steps: 1. Double-click Save on a new voucher. Existing case, kept.
Expected: exactly one voucher and one set of legs.
Status: executable

### contra.retry.duplicate-request   (T13 Retry/unknown)
Layer: database
Steps: 1. Send the same POST twice with the same idempotency key (if the route has one) and, without a key, two sequential identical POSTs.
Expected: with a key one voucher; without a key two vouchers numbered n and n+1 (the desktop renumbers the second with MAX+1 rather than overwriting: TR_CONTRA.cs:2724 {{tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");}}); the second never overwrites the first.
Status: executable

### contra.rollback.atomic-write   (T14 Rollback)
Layer: database
Steps: 1. Make each write fail in turn (a trigger or constraint fault injected on CONTRA_DATA, AC_DATA, ROJ_MEL_DATA, REMARK_DATA, TEMP_BOOK_DATA) during a three-row create, an edit and a delete.
Expected: every failure leaves ALL tables exactly as before (no voucher with legs missing; all legs or none): create writes nothing; edit keeps the old voucher byte-identical; delete keeps the voucher and writes no DELETE_DATA (the desktop is not atomic: weakness 2, not ported).
Status: executable

### contra.rollback.ledger-write-fault   (T14 Rollback)
Layer: browser
Steps: 1. Existing case: a fault on the ledger write during a browser save. Kept.
Expected: nothing is written and the form keeps the typed rows.
Status: executable

### contra.balance.every-dr-has-cr   (T07 Create)
Layer: database
Steps: 1. Save the three-row grid, a five-row grid (DR 100; CR 10, 20, 30, 40) and a grid with row 1 on CR (CR 100; DR 60, DR 40). 2. For each voucher sum AC_DATA, ROJ_MEL_DATA and CONTRA_DATA by side.
Expected: AC_DATA Σ DR_AMT = Σ CR_AMT (100 = 100 for the second: 10+20+30+40 = 100); every counter row has exactly one mirror row of equal amount (rows come in pairs: SR 2k-1 LDR 0 and SR 2k LDR 1); for the CR-first grid the mirrors are CR rows of 60 and 40 on row 1's account (TR_CONTRA.cs:2859 {{dataRow2["CR_AMT"] = Conversion.Val(mSG[DC_Main.i, 6]);}}); AC_DATA keys end 01 for credits and 02 for debits.
Status: executable

### contra.ledger.legs-and-rojmel   (T07 Create)
Layer: database
Steps: 1. Save the two-row voucher (DR 00008 5000 / CR 00001 5000). 2. Read AC_DATA and ROJ_MEL_DATA keys.
Expected: AC_DATA keys `STR(SR_NO)+'01'` for the credit leg (SR 1) and `STR(SR_NO)+'02'` for the debit (SR 2) (Ac_Ledr.cs:842 {{+STR(A.SR_NO)+'01'}}, Ac_Ledr.cs:844 {{+STR(A.SR_NO)+'02'}}); ROJ_MEL_DATA keys `'01'+Str(SR_NO)` for credit and `'02'+Str(SR_NO)` for debit (Ac_Rojmel.cs:338 {{+'01'+Str(A.SR_NO)}}, Ac_Rojmel.cs:340 {{+'02'+Str(A.SR_NO)}}) — the day-book key puts the leg code first (G21, inferred: the test decides).
Status: executable

### contra.readers.account-ledger   (T16 Report/output)
Layer: database
Steps: 1. Save the three-row grid on 2026-04-15 with opening balances 0. 2. Read the Account Ledger detail view for 00001, 00009 and 00008 for April 2026, then edit and delete the voucher and read again.
Expected: 00008: one line, Dr 3000.50, closing 3000.50 Dr; 00001: one line Cr 1000.25, closing 1000.25 Cr; 00009: one line Cr 2000.25. After the edit to DR 00008 2000 / CR 00001 2000: 00008 Dr 2000.00, 00001 Cr 2000.00, 00009 no line (its 3000.50 Dr is gone); after delete all three have no line and a zero closing.
Status: executable

### contra.readers.cash-bank-book   (T16 Report/output)
Layer: database
Steps: 1. Same voucher as above. 2. Read the cash book and the bank reconciliation list of 00008.
Expected: cash book (accounts named CASH or BANK) contains the legs of 00001 (Cr 1000.25), 00009 (Cr 2000.25), 00008 (Dr 3000.50): total Dr 3000.50, total Cr 3000.50 (1000.25 + 2000.25); bank list of 00008 shows one transaction line Dr 3000.50 (two CONTRA legs of the same account net as two lines 1000.25 and 2000.25: 2 lines, book 3000.50, cleared 0, uncleared 3000.50).
Status: executable

### contra.readers.day-book   (T16 Report/output)
Layer: database
Steps: 1. Same voucher. 2. Read the day book and the Rojmel for 2026-04-15, then after delete.
Expected: the day book shows the four legs (Dr 3000.50 total, Cr 3000.50 total, counted once, not twice after an edit); after delete the date shows nothing from this voucher.
Status: executable

### contra.list.desktop-groups   (T04 Lookup)
Layer: database
Steps: 1. Save the three-row grid and the two-row voucher. 2. GET /contra/list for the book.
Expected: one line per voucher × account × description with that group's sums: voucher n1 (two-row, no descriptions): account CASH CR 5000.00 DR 0.00, account BANK DR 5000.00 CR 0.00; voucher n2: lines `FROM CASH` (CASH ON HAND, Cr 1000.25, Dr 0.00), `FROM B2` (BANK B/C, Cr 2000.25, Dr 0.00), `DEPOSIT` (BANK A/C, Cr 0.00, Dr 3000.50); columns Vch No, Vch Date as dd/mm/yyyy, Party Name, Vch Desc, User, CrAmt, DrAmt (TR_CONTRA.cs:3144 {{GROUP BY A.VCH_NO,A.VCH_DATE,B.AC_NAME,A.IT_DESC,A.MAIN_USER ORDER BY A.VCH_NO}}, TR_CONTRA.cs:3140 {{convert(NVARCHAR,A.VCH_DATE, 103)}}); ordered by voucher number; only the session's company, location, year and book (another year's voucher does not appear).
Fails today: no such route; the shared list returns one line per voucher (G17).
Status: executable

### contra.list.recent-list-total   (T04 Lookup)
Layer: browser
Steps: 1. Open the form and press F1 in the number box.
Expected: the F1 list opens with the desktop columns and the three-row voucher's three lines, and Load fills the grid with the voucher (TR_CONTRA.cs:3162 {{tVchNo.Text = DC_Main.ColValue[0];}}). Replaces the existing `reopen.recent-list-total` assertion (that case read the web's one-line-per-voucher total); the old id is kept for the reopen part.
Status: executable

### contra.keyboard.voucher-number-keys   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Existing case: Enter, F1, Up (last), Down (first) in the number box. Kept.
Expected: TR_CONTRA.cs:3223 {{if ((int)e.KeyCode == 112)}}, TR_CONTRA.cs:3227 {{if ((int)e.KeyCode == 38)}}, TR_CONTRA.cs:3231 {{if ((int)e.KeyCode == 40)}}.
Status: executable

### contra.keyboard.alt-s-saves   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Existing case: Alt+S saves. Kept.
Expected: the voucher is saved once.
Status: executable

### contra.keyboard.ctrl-d-row   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Fill three rows. 2. Focus row 2 and press Ctrl+D. 3. Accept the confirm. 4. Save.
Expected: the confirm reads `This Row Record will Removed permantley ?` (TR_CONTRA.cs:1816 {{This Row Record will Removed permantley ?}}), then the message `Please Save This Voucher Then Effect....` (TR_CONTRA.cs:1828 {{Please Save This Voucher Then Effect....}}); the row cells are blanked (skipped on save: TR_CONTRA.cs:2765 {{Conversion.Val(mSG[DC_Main.i, 6]) + Conversion.Val(mSG[DC_Main.i, 5]) != 0.0}}); the saved voucher has only the remaining rows; cancelling the confirm keeps the row. Fails today: the Remove button asks nothing (G15).
Status: executable

### contra.keyboard.enter-flow   (T17 Keyboard/usability)
Layer: browser
Steps: 1. In the DrAmt of the last row press Enter. 2. In a CR row press Enter in CrAmt with 0.
Expected: Enter on the last row's amount adds a row and focuses its account cell (TR_CONTRA.cs:2055 {{mSG.Rows += 1;}}); a zero CrAmt in a CR row keeps the focus (TR_CONTRA.cs:2032 {{Conversion.Val(TEXT_ENTRY.Text) == 0.0}}). Fails today: Enter does not walk the grid (G15).
Status: executable

### contra.keyboard.esc   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Open the form and press Esc with an untouched grid. 2. Type an amount and press Esc.
Expected: untouched → the screen closes (back to the previous page), OldValTot == NewValTot (TR_CONTRA.cs:2980 {{if (OldValTot == NewValTot)}}); after typing, Esc commits the cell, jumps to the last row and focuses the employee box (TR_CONTRA.cs:2991 {{((Control)tEmpCode).Focus();}}). Fails today (G15).
Status: executable

### contra.lookup.account-help   (T04 Lookup)
Layer: browser
Steps: 1. Type an unknown code in the account cell and press Enter. 2. Pick an account from the help list. 3. Type a known code and press Enter.
Expected: an unknown code opens the account help list (TR_CONTRA.cs:1953 {{if (DC_Main.HelpClose)}}); picking fills code and name; a known code fills the name directly (TR_CONTRA.cs:1926 {{Select * From AC_MAST WHERE CO_CODE = '}}). The "all branch accounts" and "create account" choices stay blocked (see contra.lookup.opening-balance and Not covered).
Status: executable

### contra.lookup.employee-help   (T04 Lookup)
Layer: browser
Steps: 1. Type `E01` in Employee and press Enter. 2. Type an unknown code and press Enter.
Expected: a known code fills `EMP ONE` and moves on (TR_CONTRA.cs:3399 {{SendKeys.Send("{tab}");}}); an unknown code opens the employee list.
Status: executable

### contra.lookup.opening-balance   (T04 Lookup)
Layer: browser
Steps: 1. Enter account 00008 with a Cr balance of 1,250.00 at the voucher date.
Expected: `1250.00 : Cr Amt` in blue; a Dr balance reads `: Dr Amt` in red; zero reads `: Amt` (TR_CONTRA.cs:1980 {{LOpAmt.Text = Strings.Format((object)DC_Main.MsAcAmtOpBal, "0.00") + " : Cr Amt";}}, TR_CONTRA.cs:1985 {{LOpAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtOpBal), "0.00") + " : Dr Amt";}}).
Status: blocked: needs a balance-as-of-date-and-time API (MsAcBal) owned by the Account Ledger package, not by this menu; unblocks when that API exists (D16, G16)

### contra.print.contra-voucher   (T16 Report/output)
Layer: browser
Steps: 1. Existing case: print the two-row voucher. Kept.
Expected: shows from-account, to-account and amount 5,000.00.
Status: executable

### contra.print.multi-leg   (T16 Report/output)
Layer: database
Steps: 1. Save the three-row grid. 2. Render contraVoucherHtml from the saved rows.
Expected: the document lists every leg: `BANK A/C` Dr 3,000.50 (row 1), `CASH ON HAND` Cr 1,000.25, `BANK B/C` Cr 2,000.25 with the voucher total 3,000.50 and the amount in words for 3,000.50; the descriptions DEPOSIT, FROM CASH, FROM B2 appear once each (the selection is the whole voucher: TR_CONTRA.cs:3026 {{{CONTRA_DATA.VCH_NO} = '" + CurPrnVch + "'}}). Fails today: the print takes the first Cr row and the first Dr row only, so it shows `CASH ON HAND → BANK A/C 1,000.25`, a third of the money (G23).
Status: executable

### contra.print.after-save   (T16 Report/output)
Layer: browser
Steps: 1. Save a new voucher with the print right. 2. Without the right.
Expected: with the right the print document of the saved number opens (TR_CONTRA.cs:2902 {{BtnPrint_Click(BtnPrint, new EventArgs());}}); without it `You Have No Print Rights.....` appears (TR_CONTRA.cs:3002 {{You Have No Print Rights.....}}) and the voucher stays saved. Fails today (G11).
Status: executable

### contra.print.template-and-copies   (T16 Report/output)
Layer: browser
Steps: 1. Print with copy ticks.
Expected: layout of `ContraBill.rpt` and copy labels `CUSTOMER COPY` / `ACCOUNT COPY` (TR_CONTRA.cs:3032 {{DC_Main.MaPirntCopy = "'CUSTOMER COPY'";}}, TR_CONTRA.cs:3039 {{DC_Main.MaPirntCopy = "'ACCOUNT COPY'";}}).
Status: blocked: the template is a binary Crystal file with no text export and the print-copy dialog (`MS_PRINT`) is not specified; a template-reading work package must supply a text export (study Open question 4, G12)

### contra.report.contra-register   (T16 Report/output)
Layer: browser
Steps: 1. Existing case: the Contra Register lists the voucher. Kept; extended to a three-row voucher: one register line per voucher, total Dr 3000.50.
Expected: register total equals the voucher total.
Status: executable

### contra.journey.deposit-then-withdraw   (T18 Full journey)
Layer: browser
Steps: 1. Existing case: deposit cash to bank, then withdraw part. Kept. Extend: edit the deposit to three rows and delete the withdrawal.
Expected: balances: cash opening 0, deposit 5000 (cash Cr 5000, bank Dr 5000), withdrawal 2000 (bank Cr 2000, cash Dr 2000) → cash 3000 Cr, bank 3000 Dr; after deleting the withdrawal cash 5000 Cr, bank 5000 Dr; the account ledger, cash book and day book agree.
Status: executable

### contra.create.withdrawal   (T07 Create)
Layer: browser
Steps: 1. Existing case: row 1 CR bank, row 2 DR cash. Kept.
Expected: row 1 CR 00008 2,000, row 2 DR 00001 2,000: CONTRA_DATA SR1 LDR 0 DR 00001 DR_AMT 2000; SR2 LDR 1 CRDR_TYPE CR AC 00008 CR_AMT 2000 (TR_CONTRA.cs:2859 {{dataRow2["CR_AMT"] = Conversion.Val(mSG[DC_Main.i, 6]);}}).
Status: executable

### contra.entry.header-fields-na   (T01 Entry/defaults)
Layer: browser
Steps: 1. Look for the read-only voucher number and the hidden voucher number box.
Expected: not applicable, see N/A list.
Status: N/A: the desktop unlocks the number by double-click (TR_CONTRA.cs:3206 {{((TextBoxBase)tVchNo).ReadOnly = false;}}) and shows the hidden number by double-click on the label (TR_CONTRA.cs:3416 {{((Control)tHdVchNo).Visible = true;}}); the hosted service allocates both numbers on the server and the number box stays typeable for reopening (D15)

## N/A kinds and rules

- T05 Children (insert/reorder/copy/delete of a child set under two parents): the Contra grid has no parent/child tables that can be reordered; row insert/delete is covered by `contra.keyboard.ctrl-d-row` and `contra.create.three-rows`.
- Licence expired refusal (Rule 1): N/A (D4). No case.
- `UT_USER_REQUEST` per-voucher permission flow (G14): not ported (D5); only the `N` write-back is tested (`contra.edit.unchanged-save`, `contra.rights.edit-delete-need-role`).
- Theme colours (MsCoTheme 2, 3, 4: TR_CONTRA.cs:2158 {{((Form)this).BackColor = Color.Silver;}}): visual only, out of scope.
- Fine Jv mode (N206): done in another package; only the refusal of its book is tested.

## Coverage table

| Kind | Cases | Blocked | Notes |
|---|---|---|---|
| T01 Entry/defaults | 4 | 1 | includes 1 N/A (header-fields-na) |
| T02 Field route | 3 | 0 |  |
| T03 Formula sequence | 2 | 0 |  |
| T04 Lookup | 5 | 1 | opening-balance blocked |
| T05 Children | 0 | 0 | N/A: see "N/A kinds" |
| T06 Required/invalid | 12 | 0 |  |
| T07 Create | 8 | 0 |  |
| T08 Reopen/no-op | 3 | 0 |  |
| T09 Edit | 3 | 0 |  |
| T10 Delete/cancel/reverse | 4 | 0 |  |
| T11 Scope/rights | 7 | 0 |  |
| T12 Concurrency | 4 | 0 |  |
| T13 Retry/unknown | 2 | 0 |  |
| T14 Rollback | 2 | 0 |  |
| T15 Config/history | 1 | 0 |  |
| T16 Report/output | 8 | 1 | print template blocked |
| T17 Keyboard/usability | 5 | 0 |  |
| T18 Full journey | 1 | 0 |  |

Total: 74 cases; executable 71; blocked 2 (`contra.lookup.opening-balance`, `contra.print.template-and-copies`); N/A 1 (`contra.entry.header-fields-na`). Layers: browser 36, database 34, unit 4.

## Test data

- Tenant with company `01`, location `00`, year `2026-2027` (open 2026-04-01, close 2027-03-31), CO_SET row (EMP_CODE_MANDATORY `N`, CASH_LIMIT 0).
- Book `CON` "Contra Book": BOOK_SNAME `CON`, MAIN_BOOK `CONTRA`, BOOK_INOUT `O`, CUR_USE `Y`; a second book `FJV` MAIN_BOOK `FINE JV` and `JV` MAIN_BOOK `JOURNAL` for family refusals; a Contra book of the previous year number sequence for the year-isolation case.
- Accounts: `00001 CASH ON HAND`, `00008 BANK A/C`, `00009 BANK B/C`, `00010 DEBTOR ONE` (group debtor), all opening balance 0 except where a case sets one.
- Employee `E01 EMP ONE`.
- Users and roles: the admin; a role with view+create only; a role with update+delete; a clerk with no Contra view; a user without print right.
- Second tenant `B` with the same company and book codes for the isolation case.
- Vouchers saved by the cases themselves: V1 two-row (5,000), V2 three-row (3,000.50), V3 withdrawal (2,000). Lock date and year edges are set by cases and restored.

## Not covered

- Crystal template pixels and the print-copy dialog `MS_PRINT` (blocked, G12).
- Opening-balance label colours (blocked, G16).
- The "create account" (`MS_ACCT`) and "all branch accounts" help choices (TR_CONTRA.cs:1957 {{if (DC_Main.MsCreat)}}): the web account picker is a shared component; the cases cover the lookup only.
- Prefill of the employee from `MsEmpAsUser` (D14): the web session has no user → employee link; owner decision.
- Screen theme colours, grid scroll bars (`MsGridScroll`, TR_CONTRA.cs:1479 {{if (Operators.CompareString(DC_Main.MsGridScroll, "N", false) == 0)}}) and arrow-key cell movement pixels: visual only.
- `Current Voucher No has been changd` renumbering text (G19): the web allocates numbers on the server, so a typed number cannot collide.
- Fine Jv behaviour (N206) and the Contra Register presentation beyond the existing case.
