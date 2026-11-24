# WP-31 study: Contra Entry (TR_CONTRA) residuals

Status of this document: complete for the packet's items (multi-line grid, lifecycle, list, print, account roles). The
packet says the web module is "25 of 25 passing"; section "Gaps" lists what the module still does not prove.
Fine Jv Entry shares the form (FINE JV mode) and is out of scope except where it shows the shared code path.

## Scope

- Menu: Transaction → Contra Entry. Desktop form `TR_CONTRA` (3,451 lines). Dispatch:
  MDI_FORM.cs:8100-8104 {{case "Contra Entry":}} and MDI_FORM.cs:8101 {{DC_Main.CurBookHelp("CONTRA");}} and
  MDI_FORM.cs:8104 {{TR_CONTRA tR_CONTRA = new TR_CONTRA();}}.
- The menu opens the form only when a book was chosen: MDI_FORM.cs:8102 {{if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)}}.
  The form copies the chosen book into `FormMainBook` (TR_CONTRA.cs:2310 {{FormMainBook = DC_Main.CurBookMain;}}); the same
  form opens as Fine Jv Entry with `CurBookHelp('FINE JV')` (MDI_FORM.cs:8360 {{case "Fine Jv Entry":}}).
- Editions: TR_CONTRA.cs contains no `MsSoftType` check (searched: no match), so the menu has no mode difference by
  edition. The menu is Lite: docs/handbook/menu-editions.json:1954 {{"edition": "L",}}.
- In scope: the multi-line grid, create/reopen/edit/delete/cancel, the F1 list and voucher stepping, the print, and the
  rights/account rules. Out of scope: FINE JV mode (N206, already done), the Contra Register report (separate menu),
  Crystal layout of ContraBill.rpt (a binary file; see Open questions).
- Open web gaps named in `12-lineage-verification-2026-10-01.md`: G128 (print, N119), G138 (lifecycle UI, N129),
  G204 (grid, N194), G219 (FINE JV sharing, N206), G220 (list scope, N207), G229 (year check and list total, N216), and
  the bounded G37 register-date change (N57). None is marked closed beyond "implemented-unverified"; see lines 2907-2910
  of that document ("`contra` 22 with 2 blocked") — that count is stale: the module now has 25 cases and no case is
  blocked, pending or skipped (see Web today). The module's `pending()` helper is defined (contraEntry.mjs:43 {{const pending = (name, group, reason) => ({}}) but never
  called, `baseline.json` has `"contra": []` (web/apps/web/test/features/baseline.json:16 {{"contra": [],}}).

## Screen

Controls, in the form file (tab order is the `TabIndex` value; the grid cells are driven by the `TEXT_ENTRY` box):

| Caption / name | Type | Tab | Rules |
|---|---|---|---|
| Vch No `tVchNo` | TextBox, max 8 | 0 | read-only until double-click: TR_CONTRA.cs:1123 {{((TextBoxBase)tVchNo).ReadOnly = true;}} and TR_CONTRA.cs:3206 {{((TextBoxBase)tVchNo).ReadOnly = false;}} |
| Vch Date `mVchDate` | MaskedTextBox | 1 | TR_CONTRA.cs:1095 {{mVchDate.Mask = "00/00/0000";}}; default today: TR_CONTRA.cs:2367 {{mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);}} |
| Day `mDay`, Time `mTime` | read-only text | 1133, 1132 | TR_CONTRA.cs:1140 {{((TextBoxBase)mTime).ReadOnly = true;}}; time set at clear: TR_CONTRA.cs:2368 {{mTime.Text = DateTime.Now.ToString("HH:mm:ss");}} |
| Contra Book `lblBook` | Label | – | TR_CONTRA.cs:1090 {{lblBook.Text = "Contra Book";}}; set to the book name on activation: TR_CONTRA.cs:3112 {{lblBook.Text = FormName;}} |
| `tHdVchNo` (hidden voucher no) | read-only, hidden | 1159 | TR_CONTRA.cs:1322 {{((Control)tHdVchNo).Visible = false;}}; shown by double-click on the book label: TR_CONTRA.cs:3416 {{((Control)tHdVchNo).Visible = true;}} |
| Item Type `cboItemTyp` + label | ComboBox Gold/Silver | 2 | hidden except FINE JV: TR_CONTRA.cs:1364 {{((Control)cboItemTyp).Visible = false;}}; TR_CONTRA.cs:2329 {{cboItemTyp.Items.Add((object)"Gold");}} |
| Employee `tEmpCode` / `tEmpName` | text, max 3 / 50 | 4 / 1162 | TR_CONTRA.cs:1326 {{((TextBoxBase)tEmpCode).MaxLength = 3;}}; caption TR_CONTRA.cs:1345 {{Label3.Text = "Employee";}}; prefilled with the user's employee when `MsEmpAsUser` is Y: TR_CONTRA.cs:2388 {{if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)}} |
| `LOpAmt` | Label | – | caption `OpAmt`, text `: Amt` after clear: TR_CONTRA.cs:1355 {{LOpAmt.Text = "OpAmt";}}; shows the account's opening balance (see Calculations) |
| Grid `MSG` (9 columns) and total grid `MSG_TOT` | MSFlexGrid | 1135 | TR_CONTRA.cs:1416 {{mSG.Cols = 9;}} |
| Buttons | &Print, &Save, &Cancel, &Delete, E&xit, `<` (BtnFirst), `>` (BtnLast), F1 | – | TR_CONTRA.cs:1155 {{BtnPrint.Text = "&Print";}}, TR_CONTRA.cs:1168 {{BtnSave.Text = "&Save";}}, TR_CONTRA.cs:1182 {{BtnCancel.Text = "&Cancel";}}, TR_CONTRA.cs:1195 {{BtnDelete.Text = "&Delete";}}, TR_CONTRA.cs:1208 {{BtnExit.Text = "E&xit";}}, TR_CONTRA.cs:1304 {{BtnF1.Text = "F1";}} |

Grid columns (visible; columns 7 and 8 are hidden helpers, column 7 holds the row state `A` or `E`):

- Col 0 Sr: TR_CONTRA.cs:1426 {{mSG[0, 0] = "Sr";}}. Col 1: TR_CONTRA.cs:1429 {{mSG[0, 1] = "Cr/Dr";}}.
- Col 2: TR_CONTRA.cs:1432 {{mSG[0, 2] = "AcCode";}} (max 8). Col 3: TR_CONTRA.cs:1435 {{mSG[0, 3] = "Ac Name";}} (max 50).
- Col 4: TR_CONTRA.cs:1438 {{mSG[0, 4] = "It Desc";}} (max 150).
- Col 5 and 6: TR_CONTRA.cs:1452 {{mSG[0, 5] = "CrAmt";}} and TR_CONTRA.cs:1455 {{mSG[0, 6] = "DrAmt";}} (FINE JV shows `CrFine`/`DrFine`, TR_CONTRA.cs:1443-1446 {{mSG[0, 5] = "CrFine";}}).
- Cell input caps: TR_CONTRA.cs:1614 {{((TextBoxBase)TEXT_ENTRY).MaxLength = 8;}}, TR_CONTRA.cs:1618 {{((TextBoxBase)TEXT_ENTRY).MaxLength = 150;}}, TR_CONTRA.cs:1626 {{((TextBoxBase)TEXT_ENTRY).MaxLength = 2;}}, amounts max 10 (TR_CONTRA.cs:1634 {{((TextBoxBase)TEXT_ENTRY).MaxLength = 10;}}).
- Row 1 side is `DR`; every later row takes the opposite of row 1 and its Cr/Dr cell is read-only:
  TR_CONTRA.cs:1532 {{mSG[1, 1] = "DR";}}; TR_CONTRA.cs:1538 {{mSG[mSG.Row, 1] = "DR";}};
  TR_CONTRA.cs:1630 {{((TextBoxBase)TEXT_ENTRY).ReadOnly = true;}} (column 1, row above 1).
- In a `DR` row the CrAmt cell is read-only and in a `CR` row the DrAmt cell is read-only:
  TR_CONTRA.cs:1643-1646 {{if (Operators.CompareString(mSG[mSG.Row, 1], "DR", false) == 0)}} and
  TR_CONTRA.cs:1658-1661 {{if (Operators.CompareString(mSG[mSG.Row, 1], "CR", false) == 0)}}.
- Amount cells display `0.00` (non-FINE JV): TR_CONTRA.cs:1641 {{TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");}} — not reproduced above; see lines 1634-1662.
- Total row (`MSG_TOT`): TR_CONTRA.cs:1504 {{mSG_TOT[0, 3] = "Total :";}}.
- Grid scroll bars are removed when `MsGridScroll` is N: TR_CONTRA.cs:1479 {{if (Operators.CompareString(DC_Main.MsGridScroll, "N", false) == 0)}}.

Cancel clears the voucher; the bottom panel buttons follow the theme (MsCoTheme 2, 3, 4: TR_CONTRA.cs:2158-2250 {{((Form)this).BackColor = Color.Silver;}}); these are
colours only and are out of scope.

## Keyboard

- Form: `KeyPreview` is on (TR_CONTRA.cs:1400 {{((Form)this).KeyPreview = true;}}). Every typed letter is upper-cased and
  the apostrophe is swallowed: TR_CONTRA.cs:2630 {{if (num == 0 || num == 39)}}.
- Esc (key 27): if the grid total did not change since load the form closes; otherwise, with the cell box visible, it
  commits the cell, jumps to the last row and focuses the employee box: TR_CONTRA.cs:2978 {{if ((int)e.KeyCode == 27)}},
  TR_CONTRA.cs:2980 {{if (OldValTot == NewValTot)}}, TR_CONTRA.cs:2991 {{((Control)tEmpCode).Focus();}}.
- Voucher No box: Enter opens `DISPLAY_DATA`, F1 opens the list, Up is "last" (`BtnLast`), Down is "first" (`BtnFirst`):
  TR_CONTRA.cs:3223 {{if ((int)e.KeyCode == 112)}}, TR_CONTRA.cs:3227 {{if ((int)e.KeyCode == 38)}},
  TR_CONTRA.cs:3231 {{if ((int)e.KeyCode == 40)}}, TR_CONTRA.cs:3235 {{if ((int)e.KeyCode == 13)}}.
- Date box: Enter validates through `SetDate`; when valid it jumps to grid row 1 column 1 (FINE JV: Tab). F1 in edit mode opens the
  permission-request dialog `UT_USER_REQUEST`: TR_CONTRA.cs:3254 {{if (((int)e.KeyCode == 112) & (Operators.CompareString(EntryMode, "E", false) == 0))}},
  TR_CONTRA.cs:3260 {{((Form)MyProject.Forms.UT_USER_REQUEST).ShowDialog();}}, TR_CONTRA.cs:3267 {{DC_Main.SetDate(ref MsDate);}},
  TR_CONTRA.cs:3276-3279 {{MSG.Col = 1;}}.
- Employee box: Enter looks the code up; an unknown code opens the employee help list; a known one fills the name and
  sends Tab: TR_CONTRA.cs:3375 {{Select * From EMP_MAST WHERE CO_CODE}}, TR_CONTRA.cs:3399 {{SendKeys.Send("{tab}");}}.
- Description box `tVchDesc` (the handler exists, `tVchDesc_KeyDown`): Enter enables and focuses Save: TR_CONTRA.cs:3409 {{((Control)BtnSave).Enabled = true;}}.
- Item type (FINE JV only): Enter goes to the grid: TR_CONTRA.cs:3425-3428 {{MSG.Col = 1;}}.
- Grid cell box (`TEXT_ENTRY_KeyDown`):
  - Ctrl+D deletes the row after asking: TR_CONTRA.cs:1814 {{if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))}},
    message TR_CONTRA.cs:1816 {{This Row Record will Removed permantley ?}}, then it only blanks the row cells and says
    TR_CONTRA.cs:1828 {{Please Save This Voucher Then Effect....}}.
  - Delete / Backspace set a flag so the next arrow key does not move: TR_CONTRA.cs:1832 {{else if ((int)keyCode == 46)}}.
  - Left, Right, Up, Down move between cells, never above row 1 or left of column 1: TR_CONTRA.cs:1842 {{if ((int)keyCode == 37)}},
    TR_CONTRA.cs:1859 {{if ((int)keyCode == 39)}}, TR_CONTRA.cs:1882 {{if ((int)keyCode == 38)}}, TR_CONTRA.cs:1899 {{if ((int)keyCode == 40)}}.
  - Enter (13), by column — col 2 account lookup (below); col 5: on a CR row a zero amount keeps focus:
    TR_CONTRA.cs:2032-2038 {{Conversion.Val(TEXT_ENTRY.Text) == 0.0}}; col 6: on a DR row a zero amount keeps focus; on the
    last row a new row is added and the cursor goes to its column 2, otherwise to the next row's column 1:
    TR_CONTRA.cs:2055 {{mSG.Rows += 1;}}, TR_CONTRA.cs:2059 {{CommPassAdd();}}.
- Account lookup (col 2 Enter): TR_CONTRA.cs:1926 {{Select * From AC_MAST WHERE CO_CODE = '}}. If the code is not found the
  `MS_HELP` list opens (all branches when `MsAllBranchAcShow` is Y, TR_CONTRA.cs:1930 {{if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)}});
  closing it returns (TR_CONTRA.cs:1953 {{if (DC_Main.HelpClose)}}); the "create account" choice opens `MS_ACCT`
  (TR_CONTRA.cs:1957 {{if (DC_Main.MsCreat)}}).
- Alt+S / Alt+P / Alt+C / Alt+D / Alt+X are the `&` mnemonics of the buttons (captions above). There is no other Alt or F-key.

## Rules

Save (`BtnSave_Click`, TR_CONTRA.cs:2636 {{private void BtnSave_Click(object sender, EventArgs e)}}) checks in this exact order and writes nothing before the last check. Every
message is an OK-only `MsgBox`; the button is re-enabled after each refusal.

1. Licence expired, new entry: TR_CONTRA.cs:2663 {{You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....}}
   (condition TR_CONTRA.cs:2661 {{DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0)}}).
2. Employee mandatory: TR_CONTRA.cs:2668 {{Please Select Employee Code and Try......}}; focus goes to the employee box (TR_CONTRA.cs:2670 {{((Control)tEmpCode).Focus();}}).
3. Company type B, new entry: TR_CONTRA.cs:2675 {{You Cant Save This Voucher Becouse This Company Type is B......}}.
4. Date outside the open year (before the lock check): TR_CONTRA.cs:2682 {{You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...}}
   (condition TR_CONTRA.cs:2680 {{DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0}}).
5. Lock date: TR_CONTRA.cs:2688 {{You Cant Save and Delete This Voucher Becouse Lock Date is = }} followed by the date and ` ....`
   (condition TR_CONTRA.cs:2686 {{DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0}}: on or before the lock date).
6. Cr total differs from Dr total: TR_CONTRA.cs:2694 {{You Cant Save This Voucher Becouse Cr Value and Dr Value is not same....}}
   (condition TR_CONTRA.cs:2692 {{Conversion.Val(MSG_TOT[0, 5]) != Conversion.Val(MSG_TOT[0, 6])}}).
7. Edit without right: TR_CONTRA.cs:2700 {{You Have No Rights.....}} when the voucher is not flagged `USER_UPDATE = 'Y'` and `FRM_EDIT` is not Y in edit mode
   (TR_CONTRA.cs:2698 {{Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0)}}).
8. Empty voucher number: TR_CONTRA.cs:2706 {{Please Insert VchNo and try}}.
9. New entry whose number is already taken: TR_CONTRA.cs:2723 {{Current Voucher No has been changd New Voucher No is  '}} then the next number is used
   (TR_CONTRA.cs:2724 {{tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");}});
   the same renumbering is silent for the hidden number (TR_CONTRA.cs:2735 {{tHdVchNo.Text = Strings.Format}}).
10. Any exception: TR_CONTRA.cs:2920 {{Error Found: }} (+ description + `Click Ok to Exit.`); the button is re-enabled and mode becomes E.

Notes on what the desktop does NOT check: it never checks that an account code exists in AC_MAST at save time (the lookup is
only on Enter in column 2), never requires two rows, and never blocks a zero grid: with no filled row both totals are 0, so
check 6 passes and nothing is inserted in CONTRA_DATA (rows start at index 2: TR_CONTRA.cs:2761 {{DC_Main.i = 2;}}). A single filled row 1 fails check 6.

Delete (`BtnDelete_Click`, TR_CONTRA.cs:2944 {{private void BtnDelete_Click(object sender, EventArgs e)}}): lock date first (TR_CONTRA.cs:2953 {{You Cant Save and Delete This Voucher Becouse Lock Date is = }}),
then rights: TR_CONTRA.cs:2957 {{You Have No Rights.....}} when the voucher flag `USER_DELETE` is not Y and `FRM_DELETE` is not Y
(TR_CONTRA.cs:2955 {{Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0}}),
then the confirmation TR_CONTRA.cs:2959 {{Are You Sure To Delete This Voucher now?}} (Yes/No box), then
TR_CONTRA.cs:2969 {{Delete Success.}}. There is no year check on delete.

Print: TR_CONTRA.cs:3002 {{You Have No Print Rights.....}} when `FRM_PRINT` is not Y.
Voucher stepping: TR_CONTRA.cs:3317 {{Last Record...}} when the box already holds the last number; stepping to "first" at number 1 does nothing (TR_CONTRA.cs:3285 {{if (Conversion.Val(tVchNo.Text) < 2.0)}}).

## Calculations

- Cell format: amounts are stored in the grid as `Format(Val(text), "0.00")` (FINE JV `0.000`): TR_CONTRA.cs:1695 {{mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");}}
  after leaving a cell; `CommPassTotal()` then refreshes the totals.
- Totals (`MSG_TOT_FILL`): sum column 5 and column 6 over rows 1..n, each step re-formatted to `0.00`:
  TR_CONTRA.cs:1516 {{mSG_TOT[0, 5] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 5]) + Conversion.Val(MSG[DC_Main.M, 5]))), "0.00");}};
  `NewValTot = Val(col5) + Val(col6)` (TR_CONTRA.cs:1522 {{NewValTot = Conversion.Val(MSG_TOT[0, 5]) + Conversion.Val(MSG_TOT[0, 6]);}}).
  No `Math.Round`: the comparison at save is between the two text totals converted with `Val`, i.e. two-decimal strings.
- Equality test at save: TR_CONTRA.cs:2692 {{Conversion.Val(MSG_TOT[0, 5]) != Conversion.Val(MSG_TOT[0, 6])}}.
- Row-pair split: for each row i ≥ 2 with an account and a non-zero amount (TR_CONTRA.cs:2765 {{Conversion.Val(mSG[DC_Main.i, 6]) + Conversion.Val(mSG[DC_Main.i, 5]) != 0.0}}):
  - first record (LDR_TYPE 0): CR_AMT = col 5 of row i, DR_AMT = col 6 of row i: TR_CONTRA.cs:2797 {{dataRow2["CR_AMT"] = Conversion.Val(mSG[DC_Main.i, 5]);}} and TR_CONTRA.cs:2798 {{dataRow2["DR_AMT"] = Conversion.Val(mSG[DC_Main.i, 6]);}};
  - second record (LDR_TYPE 1, row 1 mirrored): CR_AMT = row i's DrAmt when it is non-zero, else DR_AMT = row i's CrAmt: TR_CONTRA.cs:2859 {{dataRow2["CR_AMT"] = Conversion.Val(mSG[DC_Main.i, 6]);}} and TR_CONTRA.cs:2864 {{dataRow2["DR_AMT"] = Conversion.Val(mSG[DC_Main.i, 5]);}}.
  - SR_NO is one running counter across both records: TR_CONTRA.cs:2778 {{dataRow2["SR_NO"] = DC_Main.R;}} and TR_CONTRA.cs:2830 {{dataRow2["SR_NO"] = DC_Main.R;}} (1, 2 for the first row pair; 3, 4 for the next).
- Opening-balance label (`LOpAmt`): on an account's Enter, `MsAcBal(code, date+time)`; positive → `Format(bal,"0.00") + " : Cr Amt"` in blue, negative →
  `Format(Abs(bal),"0.00") + " : Dr Amt"` in red, zero → `: Amt`: TR_CONTRA.cs:1980 {{LOpAmt.Text = Strings.Format((object)DC_Main.MsAcAmtOpBal, "0.00") + " : Cr Amt";}} and
  TR_CONTRA.cs:1985 {{LOpAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtOpBal), "0.00") + " : Dr Amt";}}. The same refresh runs when the grid row changes (TR_CONTRA.cs:3178 {{DC_Main.MsAcBal(MSG[MSG.Row, 2], Conversions.ToDate(mVchDate.Text + " " + mTime.Text));}}).
- Next voucher number: `MAX(VCH_NO)+1` formatted `00000` over CONTRA_DATA of company, location, year and book:
  TR_CONTRA.cs:2393 {{Select MAX(VCH_NO) As VchNo  From CONTRA_DATA WHERE CO_CODE}} and TR_CONTRA.cs:2401 {{tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");}}; the hidden number is the same on TEMP_BOOK_DATA without the year (TR_CONTRA.cs:2405 {{SELECT MAX(VCH_NO) AS VchNo  From TEMP_BOOK_DATA}}).
- Reopen rebuilds the grid by summing: row 1 = the LDR_TYPE '1' records grouped by account, side and description (the sum over all mirrors), rows 2.. = the LDR_TYPE '0' records:
  TR_CONTRA.cs:2467 {{AND LDR_TYPE = '1' GROUP BY AC_CODE,AC_NAME,CRDR_TYPE,IT_DESC}} and TR_CONTRA.cs:2541 {{AND LDR_TYPE = '0' GROUP BY AC_CODE,AC_NAME,CRDR_TYPE,IT_DESC}}.
  Because of the GROUP BY, two rows with the same account, side and description collapse into one row on reopen.

## Lifecycle and write set

**Create (mode A) / edit (mode E) — one path, `BtnSave_Click`:**

1. Checks (Rules 1-8).
2. Add mode only: if CONTRA_DATA already holds the number, take MAX+1 with the message of Rule 9; same for TEMP_BOOK_DATA (TR_CONTRA.cs:2715-2735 {{DC_Main.RsQry = "SELECT * FROM CONTRA_DATA WHERE CO_CODE = '" + DC_Mai}}).
3. `DELETE FROM CONTRA_DATA` of the voucher number (always, even for add): TR_CONTRA.cs:2739 {{DELETE FROM CONTRA_DATA WHERE CO_CODE}}.
4. Only when the sum of both totals is not 0: `DELETE FROM TEMP_BOOK_DATA` of the hidden number (TR_CONTRA.cs:2742 {{DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE}}), then insert one TEMP_BOOK_DATA row:
   TR_CONTRA.cs:2751 {{dataRow["BOOK_NAME"] = FormName;}} (columns CO_CODE, LC_CODE, CO_BOOK, VCH_NO = hidden number, BOOK_NAME).
5. For each grid row i from 2: insert two CONTRA_DATA rows, one `Update` per row (no transaction). Columns of both: CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO,
   VCH_DATE, VCH_TYPE = book short name, INOUT_TYPE = the book's in/out flag, ENTRY_TYPE `J`, BOOK_NAME = the main book, SR_NO, CRDR_TYPE, AC_CODE, LD_CODE, LDR_TYPE,
   AC_NAME, IT_TYPE, CR_FINE, DR_FINE, CR_AMT, DR_AMT, IT_DESC, VCH_TIME (`date time`), HD_VCH_NO, EMP_CODE, MAIN_USER, DATA_TRFR `N`, RE_TRFR, USER_UPDATE `N`, USER_DELETE `N`:
   - first row: TR_CONTRA.cs:2774 {{dataRow2["INOUT_TYPE"] = FormBookInOut;}}, TR_CONTRA.cs:2781 {{dataRow2["LD_CODE"] = mSG[1, 2];}}, TR_CONTRA.cs:2782 {{dataRow2["LDR_TYPE"] = "0";}}, IT_DESC row i: TR_CONTRA.cs:2800 {{dataRow2["IT_DESC"] = mSG[DC_Main.i, 4];}}, IT_TYPE `A`: TR_CONTRA.cs:2794 {{dataRow2["IT_TYPE"] = "A";}};
   - mirror row: TR_CONTRA.cs:2832 {{dataRow2["AC_CODE"] = mSG[1, 2];}}, TR_CONTRA.cs:2833 {{dataRow2["LD_CODE"] = mSG[DC_Main.i, 2];}}, TR_CONTRA.cs:2834 {{dataRow2["LDR_TYPE"] = "1";}}, CRDR_TYPE = row 1's side (TR_CONTRA.cs:2831 {{dataRow2["CRDR_TYPE"] = mSG[1, 1];}}), IT_DESC = **row 1's** description: TR_CONTRA.cs:2868 {{dataRow2["IT_DESC"] = mSG[1, 4];}}.
   - RE_TRFR: `Y` only if the loaded voucher was transferred: TR_CONTRA.cs:2808 {{dataRow2["RE_TRFR"] = "Y";}}.
6. `DELETE FROM AC_DATA` of the voucher (TR_CONTRA.cs:2884 {{DELETE FROM AC_DATA WHERE CO_CODE}}), then `Ac_Ledr.Contra_Ledr(book, vchNo)` (TR_CONTRA.cs:2886 {{Ac_Ledr.Contra_Ledr(DC_Main.MCo_Book, tVchNo.Text);}}):
   - credit legs: Ac_Ledr.cs:842 {{+STR(A.SR_NO)+'01'}} per row with `CR_AMT <> 0` (CR_AMT, DR_AMT 0); debit legs: Ac_Ledr.cs:844 {{+STR(A.SR_NO)+'02'}} per row with `DR_AMT <> 0`;
     both only where the book is a CONTRA book with out-flag: Ac_Ledr.cs:842 {{B.MAIN_BOOK = 'CONTRA' AND B.BOOK_INOUT = 'O'}}; AC_CODE = row account, LD_CODE = counter account, IT_TYPE `A`, ENTRY_TIME = VCH_TIME, HD_VCH_NO.
   - fine legs `'03'`/`'04'` exist only for FINE JV books: Ac_Ledr.cs:846 {{B.MAIN_BOOK = 'FINE JV' AND B.BOOK_INOUT = 'I'}}.
7. `DELETE FROM ROJ_MEL_DATA` (TR_CONTRA.cs:2887 {{DELETE FROM ROJ_MEL_DATA WHERE CO_CODE}}), then `Ac_Rojmel.Contra_Rojmel` (TR_CONTRA.cs:2889 {{Ac_Rojmel.Contra_Rojmel(DC_Main.MCo_Book, tVchNo.Text);}}): the day-book rows use the key `...+'01'+Str(SR_NO)` for credit and `'02'` for debit (Ac_Rojmel.cs:338 {{+'01'+Str(A.SR_NO)}}, Ac_Rojmel.cs:340 {{+'02'+Str(A.SR_NO)}}) — the order differs from AC_DATA's `STR(SR_NO)+'01'`.
8. `Ac_Tax.Vch_Remark(book, vchNo, 3)` (TR_CONTRA.cs:2890 {{Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 3);}}) rebuilds REMARK_DATA: one row per CONTRA_DATA row whose description is not empty: Ac_Tax.cs:686 {{AND A.IT_DESC <> '' ORDER BY A.SR_NO}} (and first deletes the voucher's REMARK_DATA: Ac_Tax.cs:694 {{DELETE FROM REMARK_DATA WHERE CO_CODE}}).
9. If the form was opened from another form with a voucher number (`FormVchNo`), it clears and closes (TR_CONTRA.cs:2891-2894 {{if (Operators.CompareString(FormVchNo, "", false) != 0)}}); otherwise it reads the party balance, clears the form and **prints the saved voucher at once**: TR_CONTRA.cs:2902 {{BtnPrint_Click(BtnPrint, new EventArgs());}}.

**Reopen:** Enter in the number box → `DISPLAY_DATA` (TR_CONTRA.cs:2420 {{private void DISPLAY_DATA()}}). Reads `SELECT * FROM CONTRA_DATA ... AND VCH_NO` (TR_CONTRA.cs:2423 {{SELECT * FROM CONTRA_DATA WHERE CO_CODE}}); if found, loads
HD_VCH_NO, IT_TYPE, EMP_CODE (+ name from EMP_MAST, TR_CONTRA.cs:2440 {{SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE}}), VCH_DATE, VCH_TIME, MAIN_USER, USER_UPDATE, USER_DELETE, DATA_TRFR (RE_TRFR Y forces `Y`): TR_CONTRA.cs:2451 {{UsUPdate = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_UPDATE"], (object)""));}}.
A saved `USER_UPDATE`/`USER_DELETE` of `Y` turns the Save/Delete button green (TR_CONTRA.cs:2460 {{((BaseStyleControl)BtnSave).ForeColor = Color.Green;}}). Mode becomes `E` (TR_CONTRA.cs:2594 {{EntryMode = "E";}}); an unknown number leaves mode `A` (TR_CONTRA.cs:2602 {{EntryMode = "A";}}).

**Edit:** the same save path; number and hidden number are kept (no renumbering in mode E). The old rows are deleted and rewritten (steps 3-8), so `USER_UPDATE` is written back as `N` (TR_CONTRA.cs:2814 {{dataRow2["USER_UPDATE"] = "N";}}): a one-time permission lasts for one save.

**Delete:** after the checks of Rules above: TR_CONTRA.cs:2961 {{INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE}} (the audit copies every CONTRA_DATA row with DR_AMT as VCH_VAL_DR, CR_AMT as VCH_VAL_CR, fine columns, HD_VCH_NO, MAIN_USER, DELETE_USER = current user, description cut to 149 characters: TR_CONTRA.cs:2961 {{SUBSTRING(IT_DESC,1,149)}}), then deletes in this order:
REMARK_DATA (TR_CONTRA.cs:2963 {{DELETE FROM REMARK_DATA WHERE CO_CODE}}, no CO_YEAR filter), TEMP_BOOK_DATA by hidden number (TR_CONTRA.cs:2964 {{DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_}}), AC_DATA (TR_CONTRA.cs:2965 {{DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MC}}), ROJ_MEL_DATA (TR_CONTRA.cs:2966 {{DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Ma}}), CONTRA_DATA (TR_CONTRA.cs:2967 {{DC_Main.ExeQuteDc("DELETE FROM CONTRA_DATA WHERE CO_CODE = '" + DC_Mai}}), APR_IDTL (TR_CONTRA.cs:2968 {{DELETE FROM APR_IDTL WHERE CO_CODE}}); then `Delete Success.` and the form clears.

**Cancel (`BtnCancel_Click`):** TR_CONTRA.cs:3103-3105 {{CustOpAmt = 0.0;}} then `CLEAR_DATA()`: clears text boxes, sets date to system date, time to now, resets `EntryMode`-related flags, resets the grid to one `DR` row, fills the employee from the user when `MsEmpAsUser` is Y and computes the next voucher number (TR_CONTRA.cs:2349-2419 {{private void CLEAR_DATA()}}). Cancel writes nothing. Exit (`BtnExit_Click`, TR_CONTRA.cs:2607 {{private void BtnExit_Click(object sender, EventArgs e)}}) just closes.

**First / Last:** `BtnFirst` walks down from number−1 up to ten tries to an existing number or number 1 (TR_CONTRA.cs:3304 {{while (DC_Main.i <= 10);}}); `BtnLast` walks up to `LastVchNo`, the highest number captured at clear (TR_CONTRA.cs:2404 {{LastVchNo = tVchNo.Text;}}); both reload with `CLEAR_DATA` + `DISPLAY_DATA`.

**List (F1, `BtnF1_Click`, TR_CONTRA.cs:3135 {{private void BtnF1_Click(object sender, EventArgs e)}}):** selection (non-FINE JV): TR_CONTRA.cs:3144 {{SUM(CR_AMT) As CrAmtR,SUM(A.DR_AMT) As DrAmtR FROM CONTRA_DATA AS A LEFT JOIN AC_MAST AS B}};
filter: company, location, **year** and **book** (TR_CONTRA.cs:3144 {{AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' GROUP BY}});
grouping: TR_CONTRA.cs:3144 {{GROUP BY A.VCH_NO,A.VCH_DATE,B.AC_NAME,A.IT_DESC,A.MAIN_USER ORDER BY A.VCH_NO}} — the grouping includes the account name (joined on each row's AC_CODE) and the description, so **one voucher is listed once per distinct (account, description)** with that group's sums; columns `VchNoL`, `VchDateL` (SQL style 103, `dd/mm/yyyy`), `PartyNameL`, `VchDescL`, `UserL`, `CrAmtR`, `DrAmtR` (TR_CONTRA.cs:3140-3144 {{convert(NVARCHAR,A.VCH_DATE, 103)}}); widths TR_CONTRA.cs:3148 {{DC_Main.ColWidth[0] = 100.0;}}.
Selecting a row (`ColValue[1]` not empty) clears the form, puts `ColValue[0]` in the number box and runs `DISPLAY_DATA` (TR_CONTRA.cs:3162 {{tVchNo.Text = DC_Main.ColValue[0];}}); closing it returns focus to the number box (TR_CONTRA.cs:3168 {{((Control)tVchNo).Focus();}}).
A list from the `HelpSelect = 0` dialog has no drill-down beyond that load.

## Print

- Button `&Print`, also called automatically after a successful save (TR_CONTRA.cs:2902 {{BtnPrint_Click(BtnPrint, new EventArgs());}}).
- Right: `FRM_PRINT` from USER_SET (TR_CONTRA.cs:2123 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}); message TR_CONTRA.cs:3002 {{You Have No Print Rights.....}}. The USER_SET row is read with TR_CONTRA.cs:2116 {{Select * From USER_SET WHERE LC_CODE}}.
  Note: the auto-print after save goes through the same button, so a user without print right sees the message after every save.
- Dialog `MS_PRINT` (TR_CONTRA.cs:3005 {{((Form)MyProject.Forms.MS_PRINT).ShowDialog();}}); `CANCEL` returns.
- Template: TR_CONTRA.cs:3021 {{string rptName = ((Operators.CompareString(FormMainBook, "FINE JV", false) != 0) ? "ContraBill" : "FineJvBill");}}; the Crystal
  path (non-`N` runtime) uses TR_CONTRA.cs:3067 {{\\Report\\ContraBill.RPT}}. The file in the repository is `unified/reports/ContraBill.rpt`. There is **no `ContraVch.rpt`** anywhere in the repository (searched by name).
- Selection formula (both paths): TR_CONTRA.cs:3026 {{{CONTRA_DATA.VCH_NO} = '" + CurPrnVch + "'}} with company, location, year and book.
- Parameters: copy label. Direct/preview path (`MsCrystalRptType` = `N`): `MsPrintType = "InVoiceType"` with `MaPirntCopy` = `'CUSTOMER COPY'` when `MsPrintDup` and `'ACCOUNT COPY'` when `MsPrintOg` (TR_CONTRA.cs:3032 {{DC_Main.MaPirntCopy = "'CUSTOMER COPY'";}}, TR_CONTRA.cs:3039 {{DC_Main.MaPirntCopy = "'ACCOUNT COPY'";}}); one print per ticked copy; preview opens one window per copy (TR_CONTRA.cs:3050 {{Module_Save.ShowReportPreview();}}).
  Crystal path: `InVoiceType = 'ORIGINAL FOR RECIPIENT'` / `'DUPLICATE FOR SUPPLIER'` / `'TRIPLICATE FOR TRANSPORTER'` (TR_CONTRA.cs:3074 {{Cr[(short)1] = "InVoiceType = 'ORIGINAL FOR RECIPIENT'";}}, TR_CONTRA.cs:3080 {{Cr[(short)1] = "InVoiceType = 'DUPLICATE FOR SUPPLIER'";}}, TR_CONTRA.cs:3086 {{Cr[(short)1] = "InVoiceType = 'TRIPLICATE FOR TRANSPORTER'";}}).
- Mail/WhatsApp data for the sent copy: the e-mail and mobile of the account on the voucher's first matching row (TR_CONTRA.cs:3014 {{SELECT B.AC_EMAIL,B.AC_MOBILE FROM CONTRA_DATA AS A INNER JOIN AC_MAST AS B}}) and the opening and closing balance of the party account: TR_CONTRA.cs:3024 {{DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));}}.

## Rights

- `USER_SET` row for the user, location and the menu name: TR_CONTRA.cs:2116 {{Select * From USER_SET WHERE LC_CODE}}; columns `FRM_EDIT`, `FRM_DELETE`, `FRM_PRINT` (TR_CONTRA.cs:2121-2123 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.}}).
  When no row exists the three flags stay empty, i.e. denied (they are only set inside `if (dataTable.Rows.Count > 0)`, TR_CONTRA.cs:2119 {{if (dataTable.Rows.Count > 0)}}).
- Create needs no flag; edit needs `FRM_EDIT = Y` or the voucher's `USER_UPDATE = Y` (Rule 7); delete needs `FRM_DELETE = Y` or `USER_DELETE = Y` (Rules, Delete); print needs `FRM_PRINT = Y`.
- The per-voucher flags are granted from the date box F1 (`UT_USER_REQUEST`, TR_CONTRA.cs:3260 {{((Form)MyProject.Forms.UT_USER_REQUEST).ShowDialog();}}) — a request/approval flow for one voucher, which sets `USER_UPDATE`/`USER_DELETE` on the CONTRA_DATA rows (the form reads them back at TR_CONTRA.cs:2451-2452 {{UsUPdate = Conversions.ToString(Operators.ConcatenateObject(RsData.Row}}).
- View: opening the menu has no rights check in the form. `MsUserRightForm` is cleared after the read (TR_CONTRA.cs:2118 {{DC_Main.MsUserRightForm = "";}}).
- Account roles (the packet's "account roles"): the grid takes **any** `AC_MAST` account of the company — there is no group, cash/bank or `AC_GR_NAME` restriction. `AC_MAST`/`AC_GROUP` are read only to build the help list
  (TR_CONTRA.cs:1932 {{AC_GR_NAME AS GroupL}}). Row 1 is the "main" account whose side decides the others (Screen). "Contra" is the book family `CONTRA` (BOOK_INOUT `O`), nothing else about the roles is enforced. The packet's "G37" is the report-presentation gap (11-audit-implementation-plan-2026-10-01.md:83 {{| G37 | S2 | Report presentation | Report-specific formats and totals }}) and has no connection with account roles; see Open questions.

## Desktop weaknesses not to port

1. SQL built by joining strings everywhere (for example TR_CONTRA.cs:2739 {{DELETE FROM CONTRA_DATA WHERE CO_CODE = '}}).
2. Save is not atomic: `DELETE FROM CONTRA_DATA` (TR_CONTRA.cs:2739 {{DC_Main.ExeQuteDc("DELETE FROM CONTRA_DATA WHERE CO_CODE = '" + DC_Mai}}) runs before the new rows are inserted one `Update` at a time (TR_CONTRA.cs:2817 {{((DbDataAdapter)(object)DC_Main.Da).Update(RsData);}}); an error between them leaves a voucher without rows or without ledger (the catch only re-enables the button, TR_CONTRA.cs:2918 {{((Control)BtnSave).Enabled = true;}}).
3. Delete is allowed in add mode (no `EntryMode` check): for a number that is not saved it runs all deletes and reports TR_CONTRA.cs:2969 {{Delete Success.}}; the delete also deletes REMARK_DATA and TEMP_BOOK_DATA without CO_YEAR (TR_CONTRA.cs:2963 {{DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Mai}}, TR_CONTRA.cs:2964 {{DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_}}) so it can remove another year's rows with the same number.
4. No transaction and no version check: two users can edit the same voucher; the last save wins.
5. The mirror row copies row 1's description but not row i's, and `RE_TRFR` leaks from the first record into the mirror record (the same `dataRow2` is reused, TR_CONTRA.cs:2819-2875 {{dataRow2["CO_CODE"] = DC_Main.MCo_code;}}) — reproduce the description rule, not the leak.
6. A save with no filled grid row passes all checks and writes an empty voucher (Rules, notes).
7. Account codes are never validated at save; the lock-date message text says "Save and Delete" for both (kept as text).
8. Rows of the grid that are blanked by Ctrl+D (TR_CONTRA.cs:1824 {{mSG[mSG.Row, DC_Main.M] = "";}}) leave a hole in the Sr numbering; only the save's `Val` test hides it.
9. Reopen's `GROUP BY` collapses equal rows (Calculations); a voucher with two identical rows reopens with one.

## Web today

- `web/apps/web/app/(app)/txn/contra/page.tsx` (334 lines): one React form at `/txn/contra`: book select, date, narration (voucher-wide), grid of rows with a Dr/Cr select, account code picker, name, row narration and amount, Add/Remove row, "Balanced ✓" indicator, Save Contra / Update #n, Delete with the desktop confirm text, Recent vouchers list with Load and print link. Starts with two rows (`blankRow('DR')`, `blankRow('CR')`).
- `web/apps/api/src/modules/finance/contra.ts` (391 lines): `contraLines` (grid → lines, balance check), `contraRows` (the CONTRA_DATA pair per row), `contraLedger` (AC_DATA legs), `postContra`, `gridOfRows` (reopen), `getContra`, `editContra`, `deleteContra`.
- `web/apps/api/src/modules/finance/contraVoucher.ts` (227 lines): HTML voucher for print (`contraVoucherHtml`, also Fine Jv/Journal variants).
- `web/apps/api/src/routes/txn.ts:2811 {{app.post('/contra', auth, async (req, reply) => {}}` POST `/contra`; `:7262` GET `/contra/:vchNo`; `:7267` GET `/contra/:vchNo/print`; `:7283` PUT; `:7406` DELETE. Policy: `web/apps/api/src/modules/rbac/routePolicy.ts:454 {{route('Cash / Bank/Contra', [}}` `route('Cash / Bank/Contra', [...])` and the print list at `:1114`.
- List: `web/apps/api/src/modules/vouchers/list.ts` (shared `GET /vouchers/recent`, `/vouchers/neighbour`) and `web/apps/web/components/VoucherNumberKeys.tsx` (number-box keys).
- Tests: `web/apps/web/test/features/modules/contraEntry.mjs` (25 cases: create.two-rows, create.three-rows, refusal.unequal-totals, reopen-edit-delete, print.contra-voucher, keyboard.voucher-number-keys, create.withdrawal, formula.totals, refusal.date-outside-year, create.first-day-of-year, entry.defaults, reopen.recent-list-total, edit.unchanged-save, delete.audit, rights.voucher-list-needs-contra-view, rights.print-denied, rights.fine-jv-book-refused, rights.clerk-no-contra, concurrency.double-delete, retry.double-click, rollback.ledger-write-fault, settings.lock-date, report.contra-register, keyboard.alt-s-saves, journey.deposit-then-withdraw). **No case is blocked, pending or skipped**: `grep` finds `blocked` only in the helper (contraEntry.mjs:45 {{blocked: reason,}}) and `pending(` only at its definition (contraEntry.mjs:43 {{const pending = (name, group, reason) => ({}}). The API tests are `contraDelete.db.test.ts`, `financeLifecycle.db.test.ts`, `financeBookFamily.db.test.ts`, `financeBookSelection.routes.db.test.ts`, `voucherListScope.routes.db.test.ts`.
- The case sources cite desktop lines but none covers: employee, Ctrl+D, Esc, F1 list columns, opening-balance label, REMARK_DATA, post-save print, `INOUT_TYPE`, mixed-side rows, or the row-1 description on the mirror.

## Gaps

1. **Row sides are free in the web, fixed in the desktop (wrong result).** Desktop: row 1 `DR`, every later row the opposite and read-only: TR_CONTRA.cs:1630 {{((TextBoxBase)TEXT_ENTRY).ReadOnly = true;}}; TR_CONTRA.cs:1538 {{mSG[mSG.Row, 1] = "DR";}}. Web: each row has its own Dr/Cr select, `web/apps/web/app/(app)/txn/contra/page.tsx:219` {{onChange={(e) => setRow(i, { crdr: e.target.value === 'CR' ? 'CR' : 'DR' })}}}, and `contraLines` accepts any mix with equal totals (`web/apps/api/src/modules/finance/contra.ts:80 {{lines.filter((l) => l.crdr === side).reduce((sum, l) => sum + l.amount}}`). A voucher with two debit rows and two credit rows can be saved that no desktop screen can produce, and `gridOfRows` (contra.ts:232 {{const mirrors = rows.filter((r) => text(r.LDR_TYPE) === '1');}}) then rebuilds row 1 from summed mirrors, which is not the entered grid. Fix: server refuses a later row whose side equals row 1's; the page makes the side read-only. Also, desktop locks the CrAmt cell in a DR row and the DrAmt cell in a CR row (TR_CONTRA.cs:1643-1646 {{if (Operators.CompareString(mSG[mSG.Row, 1], "DR", false) == 0)}}).
2. **The mirror record takes the wrong description (wrong result).** Desktop: TR_CONTRA.cs:2868 {{dataRow2["IT_DESC"] = mSG[1, 4];}} (row 1's). Web: `web/apps/api/src/modules/finance/contra.ts:115` {{IT_DESC: row.itDesc ?? null,}} (row i's). It changes CONTRA_DATA, REMARK_DATA and the printed voucher. Also web `IT_DESC: row.IT_DESC ?? input.itDesc` (contra.ts:209 {{IT_DESC: row.IT_DESC ?? input.itDesc ?? null,}}) invents a voucher-wide narration the desktop screen does not have (no description box exists: the grid column is the only description). Fix: mirror takes row 1's description; drop the voucher narration or map it to row 1.
3. **The web filters row 1 away (wrong result).** Desktop uses row 1 as head even when blank (TR_CONTRA.cs:2781 {{dataRow2["LD_CODE"] = mSG[1, 2];}}); only rows ≥ 2 are skipped when empty (TR_CONTRA.cs:2765 {{if ((Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0) & (Co}}). Web `contra.ts:75` {{.filter((line) => line.acCode && Number.isFinite(line.amount) && line.amount !== 0);}} and the page (`web/apps/web/app/(app)/txn/contra/page.tsx:114-116 {{acCode: r.acCode.trim(),}}`) drop any empty row, so a blank first row promotes row 2 to the main account and flips every pairing. Fix: keep row 1 positional; refuse (as the total test would) when row 1 has no amount.
4. **Wrong text for a thin grid (wrong text).** Web: `contra.ts:77` {{throw new FinanceValidationError('a contra needs at least two accounts with positive amounts');}}. Desktop has no such message: a single filled row fails TR_CONTRA.cs:2694 {{You Cant Save This Voucher Becouse Cr Value and Dr Value is not same....}}. Negative amounts are also refused with that web text, which the desktop does not do (it uses `Val`). Fix: use the desktop text; decide the empty-grid case (Open questions).
5. **Employee is missing (missing feature + missing text).** Desktop: employee box, mandatory by setting, default from the user, EMP_CODE on every row (TR_CONTRA.cs:2668 {{Please Select Employee Code and Try......}}, TR_CONTRA.cs:2803 {{dataRow2["EMP_CODE"] = tEmpCode.Text;}}). Web: no employee field on the page; POST `/contra` drops `empCode` (`web/apps/api/src/routes/txn.ts:2811-2820 {{app.post('/contra', auth, async (req, reply) => {}}`, the object has `scope, lines, vchDate, itDesc, mainUser`), only PUT passes it (`txn.ts:7294 {{empCode: b.empCode,}}`); `contra.ts:203 {{EMP_CODE: input.empCode ?? null,}}` writes `EMP_CODE: input.empCode ?? null`; the mandatory message exists for Fine Jv (`web/apps/api/src/modules/finance/fineJv.ts:62` {{EMPLOYEE_REQUIRED: 'Please Select Employee Code and Try......',}}) but not here. Fix: reuse the Fine Jv employee check and the `MsEmpAsUser` default; add the employee box and help list (TR_CONTRA.cs:3375 {{DC_Main.RsQry = "Select * From EMP_MAST WHERE CO_CODE = '" + DC_Main.M}}).
6. **Company type B and licence refusals are missing for Contra (missing text).** Desktop TR_CONTRA.cs:2675 {{You Cant Save This Voucher Becouse This Company Type is B......}} and TR_CONTRA.cs:2663 {{Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcen}}; the web text exists in `web/apps/api/src/modules/finance/fineJv.ts:64 {{COMPANY_TYPE_B: 'You Cant Save This Voucher Becouse This Company Type }}` but `contra.ts` has no such check (searched `Company Type is B`: no match in contra.ts). Fix: add the same guard on create.
7. **INOUT_TYPE is hard-coded `I` (wrong result, inferred).** Desktop writes the book's own flag (TR_CONTRA.cs:2774 {{dataRow2["INOUT_TYPE"] = FormBookInOut;}}); Contra_Ledr only posts for books with `BOOK_INOUT = 'O'` (Ac_Ledr.cs:842 {{B.MAIN_BOOK = 'CONTRA' AND B.BOOK_INOUT = 'O'}}). Web `contra.ts:215` {{INOUT_TYPE: 'I',}}. The test must compare CONTRA_DATA.INOUT_TYPE with the seeded book's BOOK_INOUT (aggregate query only). Fix: read the configured book's flag.
8. **Item type from the client (wrong result).** Desktop writes `A` in a non-FINE JV book (TR_CONTRA.cs:2794 {{dataRow2["IT_TYPE"] = "A";}}); web `contra.ts:208` {{IT_TYPE: input.itemType ?? 'A',}} and PUT passes `b.itemType` (`txn.ts:7295 {{itemType: b.itemType,}}`). Fix: always `A` for CONTRA books.
9. **REMARK_DATA is not written for Contra (missing write).** Desktop: Vch_Remark mode 3, TR_CONTRA.cs:2890 {{Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 3);}}, row per described CONTRA_DATA row (Ac_Tax.cs:686 {{AND A.IT_DESC <> '' ORDER BY A.SR_NO}}). Web `CONTRA_WRITE_TABLES` has three tables (`contra.ts:59` {{const CONTRA_WRITE_TABLES = ['CONTRA_DATA', 'AC_DATA', 'ROJ_MEL_DATA'] as const;}}); Fine Jv writes REMARK_DATA (`web/apps/api/src/modules/finance/fineJv.ts:124` {{const DELETE_TABLES = [...WRITE_TABLES, 'REMARK_DATA', 'APR_IDTL'] as const;}}) but Contra does not, and `deleteContra` (contra.ts:333-391 {{export async function deleteContra(}}) does not delete REMARK_DATA or APR_IDTL (desktop TR_CONTRA.cs:2963 {{DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Mai}}, TR_CONTRA.cs:2968 {{DC_Main.ExeQuteDc("DELETE FROM APR_IDTL WHERE CO_CODE = '" + DC_Main.M}}). Fix: add REMARK_DATA on save/edit and REMARK_DATA + APR_IDTL on delete, test with a write-set before/after.
10. **TEMP_BOOK_DATA rule (minor wrong result).** Desktop writes the hidden-number row only when the totals sum is not 0 (TR_CONTRA.cs:2740 {{if (Conversion.Val(MSG_TOT[0, 5]) + Conversion.Val(MSG_TOT[0, 6]) != 0.0)}}); web always inserts it (`insertHiddenIdentityTx`, contra.ts:192 {{await insertHiddenIdentityTx(tx, input.scope, identity, book.name);}}). Only reachable with an empty grid; decide with Gap 4.
11. **No automatic print after save (missing feature).** Desktop TR_CONTRA.cs:2902 {{BtnPrint_Click(BtnPrint, new EventArgs());}}. Web: the page shows a result text and a print link in the list (`web/apps/web/app/(app)/txn/contra/page.tsx:326 {{printHref={(v) =>}}`), never prints after save. Fix: after a successful save open the print preview of the saved number when the user has the print right, else show the desktop print message (see Gap 12).
12. **Print template and copies (wrong reference).** Desktop prints `ContraBill` (TR_CONTRA.cs:3021 {{string rptName = ((Operators.CompareString(FormMainBook, "FINE JV", fa}}) with copy labels `CUSTOMER COPY`/`ACCOUNT COPY` (direct) or `ORIGINAL FOR RECIPIENT`/`DUPLICATE FOR SUPPLIER`/`TRIPLICATE FOR TRANSPORTER` (Crystal). Web `contraVoucher.ts:24 {{* Rendered on the shared docShell chrome as a From → To transfer vouch}}` says it mirrors `ContraVch.rpt` (a file that does not exist; `12-lineage-verification-2026-10-01.md:143` {{`unified/src/csharp/DataCareNext/ContraVch.rpt`}} cites it and N119 inherited the name) and takes the label from `standardDocumentCopy` (txn.ts:7270 {{const copyLabel = standardDocumentCopy(q.copy, reply);}}). Fix: re-derive the layout from `unified/reports/ContraBill.rpt` (Open questions), correct the G128 row, and pass the desktop labels. Print also needs the `FRM_PRINT` message `You Have No Print Rights.....` (web already refuses with a 403 policy; the case `rights.print-denied` exists) — the text shown to the operator is not tested.
13. **Delete result text (missing text).** Desktop shows `Delete Success.` (TR_CONTRA.cs:2969 {{Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)}}); the page resets silently (`web/apps/web/app/(app)/txn/contra/page.tsx:141-150 {{if (!loadedVch || !window.confirm('Are You Sure To Delete This Voucher}}`). Delete is also tested for audit (`delete.audit`) but not for the REMARK_DATA/APR_IDTL deletes or the year-less REMARK_DATA delete (do not port that).
14. **Per-voucher rights and the permission request (missing feature).** Desktop: edit/delete allowed when the voucher's `USER_UPDATE`/`USER_DELETE` is `Y` even without `FRM_EDIT`/`FRM_DELETE` (TR_CONTRA.cs:2698 {{if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.}}, TR_CONTRA.cs:2955 {{else if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operato}}), granted through F1 on the date box (TR_CONTRA.cs:3260 {{((Form)MyProject.Forms.UT_USER_REQUEST).ShowDialog();}}) and reset to `N` by the next save (TR_CONTRA.cs:2814 {{dataRow2["USER_UPDATE"] = "N";}}). Web: only the RBAC `guard(req, reply, 'update'|'delete')` (`txn.ts:7284 {{if (!guard(req, reply, 'update')) return;}}`, `txn.ts:7407 {{if (!guard(req, reply, 'delete')) return;}}`); the columns are never written by `contra.ts`. Fix: a decision is needed (Open questions); at minimum the write sets must store `N`.
15. **Grid keyboard (missing key).** Desktop Ctrl+D with two messages (TR_CONTRA.cs:1816 {{if ((int)Interaction.MsgBox((object)"This Row Record will Removed perm}}, TR_CONTRA.cs:1828 {{Interaction.MsgBox((object)"Please Save This Voucher Then Effect....",}}), Enter flow that appends a row after the last DrAmt (TR_CONTRA.cs:2055 {{mSG.Rows += 1;}}), Esc rules (TR_CONTRA.cs:2978-2991 {{if ((int)e.KeyCode == 27)}}), arrow keys. Web: a Remove button with no confirmation and a two-row minimum (`web/apps/web/app/(app)/txn/contra/page.tsx:46` {{setRows((rs) => (rs.length <= 2 ? rs : rs.filter((_, j) => j !== i)));}}), an "Add row" button (`web/apps/web/app/(app)/txn/contra/page.tsx:283 {{<button type="button" className="ghost" onClick={addRow}>}}`), no Esc handling. Only `keyboard.voucher-number-keys` and `keyboard.alt-s-saves` are tested.
16. **Opening-balance label and account help (missing feature).** Desktop shows the account's balance with `Cr Amt`/`Dr Amt` on entry and row change (TR_CONTRA.cs:1980 {{LOpAmt.Text = Strings.Format((object)DC_Main.MsAcAmtOpBal, "0.00") + "}}, TR_CONTRA.cs:3178 {{DC_Main.MsAcBal(MSG[MSG.Row, 2], Conversions.ToDate(mVchDate.Text + " }}), the help list with "all branch accounts" (TR_CONTRA.cs:1930 {{if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == }}) and "create account" (TR_CONTRA.cs:1957 {{if (DC_Main.MsCreat)}}). Web: an account code picker (`web/apps/web/app/(app)/txn/contra/page.tsx:231 {{ariaLabel={`Account row ${i + 1}`}}}`) with no balance label and no create link. Needs a balance API owner (Open questions).
17. **The F1 list groups differently (wrong result).** Desktop lists one line per voucher × account × description with that group's CR and DR (TR_CONTRA.cs:3144 {{GROUP BY A.VCH_NO,A.VCH_DATE,B.AC_NAME,A.IT_DESC,A.MAIN_USER ORDER BY A.VCH_NO}}). Web `vouchers/list.ts:97-105 {{// CONTRA_DATA (contra, fine JV, journal) has no amount column; each m}}` returns one line per voucher with `sum(DR_AMT) OVER (PARTITION BY VCH_NO)` (N216 chose "the amount transferred"). Both are defensible as a business view but they differ from the desktop; the case `reopen.recent-list-total` asserts the web's reading. Fix: decide (Open questions); if the desktop wins, list per group with columns `Vch No, Vch Date, Party Name, Vch Desc, User, CrAmt, DrAmt`.
18. **Header fields missing (missing feature).** Day, Time, hidden voucher number (double-click on the book label, TR_CONTRA.cs:3416 {{((Control)tHdVchNo).Visible = true;}}), the read-only voucher number until double-click (TR_CONTRA.cs:3206 {{((TextBoxBase)tVchNo).ReadOnly = false;}}). Web: voucher number is typed freely (`web/apps/web/app/(app)/txn/contra/page.tsx:163-168 {{<label>Voucher No</label>}}`) and has no Time/Day.
19. **Voucher number renumbering text (missing text).** Desktop TR_CONTRA.cs:2723 {{Current Voucher No has been changd New Voucher No is  '}}; the web allocates on the server and never shows it. Low value; keep only if a user can type the number.
20. **Lock date on delete and year on edit (test gap).** Desktop checks the lock date on delete (TR_CONTRA.cs:2951 {{if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Tex}}) and the year on edit (TR_CONTRA.cs:2680 {{if ((DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversi}}). The web module's `settings.lock-date` case covers create only; `contraDelete.db.test.ts` is the DB-level proof for delete. Add browser cases for: edit of a locked voucher, delete of a locked voucher, and edit moving the date out of the year.
21. **Rojmel key order (inferred, verify).** Desktop day-book key `...'01'+Str(SR_NO)` (Ac_Rojmel.cs:338 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}) vs AC_DATA `STR(SR_NO)+'01'`; `buildJournalRojmel` is shared with the Journal screen: check its key and `LD_CODE` against the desktop with a write-set test (not checked in this study).
22. **Open cases of the module.** There are none blocked, pending or skipped (Web today). The older count "22 with 2 blocked" in `12-lineage-verification-2026-10-01.md:2907 {{`cash-bank` module passes 17 cases with 4 blocked, `contra` 22 with 2 }}` is stale; the plan prose should be corrected by a later docs worker.

Suggested case list for the next workers (T-groups of `docs/.../04-verification-playbook.md` not read in this study): mixed-side refusal (Gap 1), row-1 description on the mirror (Gap 2), employee mandatory and default (Gap 5), company type B (Gap 6), INOUT_TYPE value (Gap 7), REMARK_DATA write on save, edit and delete (Gap 9), auto-print after save (Gap 11), grid Ctrl+D and Esc (Gap 15), delete message (Gap 13), locked/out-of-year edit and delete (Gap 20).

## Open questions

1. What does an empty grid (no filled row) do in the web? The desktop saves nothing but still deletes and rebuilds an empty voucher (Rules, notes); a decision is needed whether the web refuses (recommended: refuse with the Cr/Dr text).
2. Is the list to be per voucher (web today) or per voucher × account × description (desktop)? Decision owner: product owner (D-table in doc 12 §4 has no entry).
3. Does the product want the per-voucher permission request (`UT_USER_REQUEST`, Gap 14) in Phase 1? The form `UT_USER_REQUEST` was not read in this study (out of the scope's line budget); a study of that form is needed first.
4. `ContraBill.rpt` layout (fields, formulas, copy parameter) is a binary Crystal file: it needs a template-reading worker (`web/apps/api/src/modules/reports/reportBindingContract.ts` is the binding contract) before Gap 12 can be fixed. MISSING: a text export of the template.
5. "Account roles (G37)" in the packet: G37 in the plan is "Report presentation" (11-audit-implementation-plan-2026-10-01.md:83 {{| G37 | S2 | Report presentation |}}), not account roles. This study treats "account roles" as the account rules of the grid (any AC_MAST account, row 1 sets the side). If a different gap was meant (for example the cash/bank account-group filter of the Cash and Bank vouchers), the supervisor should say which.
6. Which seeded CONTRA book has `BOOK_INOUT` `O`? (Gap 7; aggregate query on Next24 only, not run here.)
7. Opening-balance label (Gap 16): is there an API for `MsAcBal` (opening plus movement to the voucher date and time)? Not searched beyond this module.
8. The desktop `MsSoftNoUse` licence check (Rule 1) — whether the web has a global licence guard for create routes was not searched.
