# WP-29 study — Purchase Rtn residuals: G95 HSN tax on the print, G96 grid Enter, the remaining blocked cases

Role: study; no code changed. Authority: `unified/src/csharp/DataCareNext/TR_KR_ISU.cs` (7061 lines), read via
`.orch/index/TR_KR_ISU.md`; every desktop statement carries a quoted citation. Web statements cite this worktree.

## Scope
- Menu caption **Transaction → Purchase Rtn**. Dispatch: MDI_FORM.cs:7893 {{case "Purchase Rtn":}}. The UAE
  company branch opens `TR_SALE_RTN_UAE` instead (MDI_FORM.cs:7894 {{if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)}});
  the ordinary branch asks for a book with MDI_FORM.cs:7907 {{DC_Main.CurBookHelp("PURC RETURN");}} and opens
  MDI_FORM.cs:7910 {{TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();}} when a book was chosen
  (MDI_FORM.cs:7908 {{if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)}}).
- One form serves three books. Load copies the book family: TR_KR_ISU.cs:4456 {{FormMainBook = DC_Main.CurBookMain;}}
  and TR_KR_ISU.cs:4454 {{FormBookType = DC_Main.CurBookType;}}. For `PURC RETURN` the tables are
  TR_KR_ISU.cs:4476-4478 {{TblData = "PR_DATA";}} with `TblDetl = "PR_DETL"`, `TblIdtl = "PR_IDTL"`; only
  `KARIGAR ISSUE`/`MTL ISU` use `KR_DATA` (TR_KR_ISU.cs:4468-4472 {{if ((Operators.CompareString(FormMainBook, "KARIGAR ISSUE", false) == 0) | (Operators.CompareString(FormMainBook, "MTL ISU", false) == 0))}}).
  This study covers the `PURC RETURN` mode only; `KARIGAR ISSUE` and `MTL ISU` are other menus.
- Edition: the menu is Lite (`docs/handbook/menu-editions.json`, `"menu": "Purchase Rtn", "edition": "L"`). The
  form's only `MsSoftType` gate is the F1 description help, allowed for editions A and E only:
  TR_KR_ISU.cs:6041 {{Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0}}. A licence gate blocks new
  entries when `MsSoftNoUse` is Y: TR_KR_ISU.cs:4954 {{Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0}}.
- In scope: G95 (print path, template, parameters, tax fields, web print today), G96 (grid Enter walk, editable
  columns, last-cell append), and the cases of `purchaseReturn.mjs` that are blocked or not yet covered. Out of
  scope: the UAE variant, the karigar/metal modes, residual-limited selection and `PR_IDTL` stone rows (decision
  D30 accepted 30 October: the desktop does neither), and the full screen layout.

## Screen
Scoped to the item grid and the buttons the two gaps touch. The grid `MSG` is an AxMSFlexGrid with 50 columns and
one fixed header row: TR_KR_ISU.cs:2943 {{mSG.Cols = 50;}} and TR_KR_ISU.cs:2944 {{mSG.FixedRows = 1;}}.
`MSG_CLEAR` builds it (TR_KR_ISU.cs:2942 {{mSG.Clear();}}). Captions are set as `mSG[0, col]`; each column also
gets a width slot and an alignment slot. In the `PURC RETURN` branch (the `else` of the KARIGAR test) the visible
columns, in column-index order, are:
| Col | Caption | Evidence |
|---|---|---|
| 0 | Sr | TR_KR_ISU.cs:2954 {{mSG[0, 0] = "Sr";}} |
| 1 | TagNo | TR_KR_ISU.cs:2957 {{mSG[0, 1] = "TagNo";}} |
| 2 | ItCode | TR_KR_ISU.cs:2960 {{mSG[0, 2] = "ItCode";}} |
| 3 | ItName | TR_KR_ISU.cs:2963 {{mSG[0, 3] = "ItName";}} |
| 4 | Counter | TR_KR_ISU.cs:2966 {{mSG[0, 4] = "Counter";}} |
| 5 | Design | TR_KR_ISU.cs:2969 {{mSG[0, 5] = "Design";}} |
| 31 | BagWt | TR_KR_ISU.cs:2972 {{mSG[0, 31] = "BagWt";}} |
| 6 | Pcs | TR_KR_ISU.cs:2975 {{mSG[0, 6] = "Pcs";}} |
| 7 | GrWt | TR_KR_ISU.cs:2978 {{mSG[0, 7] = "GrWt";}} |
| 8 | OthWt | TR_KR_ISU.cs:2981 {{mSG[0, 8] = "OthWt";}} |
| 9 | NetWt | TR_KR_ISU.cs:2984 {{mSG[0, 9] = "NetWt";}} |
| 10 | GhtWt | TR_KR_ISU.cs:2987 {{mSG[0, 10] = "GhtWt";}} |
| 11 | Touch | TR_KR_ISU.cs:2990 {{mSG[0, 11] = "Touch";}} |
| 12 | West% | TR_KR_ISU.cs:2993 {{mSG[0, 12] = "West%";}} |
| 15 | Fine | TR_KR_ISU.cs:2996 {{mSG[0, 15] = "Fine";}} |
| 24 | Rate | TR_KR_ISU.cs:3099 {{mSG[0, 24] = "Rate";}} |
| 25 | ItAmt | TR_KR_ISU.cs:3102 {{mSG[0, 25] = "ItAmt";}} |
| 26 | Ltype | TR_KR_ISU.cs:3105 {{mSG[0, 26] = "Ltype";}} |
| 27 | LRate | TR_KR_ISU.cs:3108 {{mSG[0, 27] = "LRate";}} |
| 28 | LAmt | TR_KR_ISU.cs:3111 {{mSG[0, 28] = "LAmt";}} |
| 16 | OthAmt | TR_KR_ISU.cs:3114 {{mSG[0, 16] = "OthAmt";}} |
| 29 | NetAmt | TR_KR_ISU.cs:3120 {{mSG[0, 29] = "NetAmt";}} |

Hidden in `PURC RETURN`: columns 13/14 (LesTch/LesWt, karigar-only) are zeroed
(TR_KR_ISU.cs:3074-3075 {{mSG[13] = 0;}}), the conversion columns 17–23 get width 0
(TR_KR_ISU.cs:3076-3084 {{mSG[17] = (int)Math.Round(0.0 * ColCon);}}), and the storage columns 33–49 are zeroed
(TR_KR_ISU.cs:3125-3131 {{mSG[33] = 0;}}). Column 40 (TagId) is visible only when `MsTagVchSrnoUpdate`
(TR_KR_ISU.cs:3132-3140 {{if (DC_Main.MsTagVchSrnoUpdate)}}). At run time `COL_MAST` rows for book `PURC RETURN`
rename captions and can hide any column: TR_KR_ISU.cs:3167 {{BOOK_NAME = 'PURC RETURN' AND COL_NAME =}} and
TR_KR_ISU.cs:3175-3177 {{dataView[0]["YES_NO"], (object)"N", false}}.

The floating editor `TEXT_ENTRY` is placed over the current cell and its MaxLength/format follow the column
(`MSG_PR_EnterCell`, TR_KR_ISU.cs:3772 {{((TextBoxBase)TEXT_ENTRY).ReadOnly = false;}}); e.g. TagNo allows 15
chars (TR_KR_ISU.cs:3781 {{((TextBoxBase)TEXT_ENTRY).MaxLength = 15;}}), weights format `0.000`
(TR_KR_ISU.cs:3840 {{TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");}}).
Fine (15) is editable except for registration `VK252NUST`, which makes it read-only
(TR_KR_ISU.cs:3845-3847 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0)}}).
Bottom buttons: TR_KR_ISU.cs:2317 {{BtnPrint.Text = "&Print";}}, TR_KR_ISU.cs:2330 {{BtnSave.Text = "&Save";}},
TR_KR_ISU.cs:2344 {{BtnCancel.Text = "&Cancel";}}, TR_KR_ISU.cs:2357 {{BtnDelete.Text = "&Delete";}},
TR_KR_ISU.cs:2370 {{BtnExit.Text = "E&xit";}}. In `PURC RETURN` the source-bill controls are shown and relabelled
TR_KR_ISU.cs:4480 {{lblConsiNo.Text = "Purc Bill";}}.

## Keyboard
Grid editor (`TEXT_ENTRY_KeyDown`, TR_KR_ISU.cs:3244 {{UpDown = false;}} opens the handler at :3220):
- **Ctrl+D** clears the row after a confirmation: TR_KR_ISU.cs:3248 {{if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))}},
  message TR_KR_ISU.cs:3250 {{This Row Record will Removed permantley ?}}, then
  TR_KR_ISU.cs:3262 {{Record is Deleted....}}.
- **Left/Right** move one column, Left sets `Msgleft` so the skip loop walks backwards:
  TR_KR_ISU.cs:3272 {{Msgleft = true;}}; Right stops at column 29 (TR_KR_ISU.cs:3279 {{if (mSG.Col < 29)}}).
- **Up/Down** move one row within the data rows (TR_KR_ISU.cs:3287 {{if (mSG.Row > 1)}},
  TR_KR_ISU.cs:3298 {{if (mSG.Row < mSG.Rows - 1)}}).
- **Enter** (TR_KR_ISU.cs:3306 {{if ((int)keyCode == 13)}}) switches on the column:
  - Col 1 (TagNo): resolves the tag against `MAIN_STOCK`/`BAR_DETL`
    (TR_KR_ISU.cs:3318 {{Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK}}), refuses a duplicate with
    TR_KR_ISU.cs:3363 {{Duplicate Tag No}}, fills the row from the tag, and for `PURC RETURN` with
    `SL_ROW_CHANGE=Y` (TR_KR_ISU.cs:3470 {{Operators.CompareString(DC_Main.MsSlRowChange, "Y", false) == 0}})
    appends a row when the tag landed on the last row (TR_KR_ISU.cs:3474-3481 {{if (mSG.Row == mSG.Rows - 1)}} …
    TR_KR_ISU.cs:3481 {{CommPassAdd();}}).
  - Col 2 (ItCode) and col 17: item lookup / F1-style help
    (TR_KR_ISU.cs:3503 {{Select * From ITEM_MAST WHERE CO_CODE =}}).
  - Col 7 (GrWt): a zero weight is refused unless the rate type is P (TR_KR_ISU.cs:3662 {{if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Operators.CompareString(mSG[mSG.Row, 34], "P", false) != 0))}}).
  - **Cols 19 and 29 (ConWt / NetAmt) are the row-end keys**: on the last row Enter formats the cell, recomputes,
    appends a row and restarts at column 1: TR_KR_ISU.cs:3670 {{if (mSG.Row == mSG.Rows - 1)}},
    TR_KR_ISU.cs:3677 {{mSG[mSG.Row, 19] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");}},
    TR_KR_ISU.cs:3680-3684 {{mSG.Rows += 1;}} … TR_KR_ISU.cs:3683 {{mSG.Col = 1;}} …
    TR_KR_ISU.cs:3684 {{CommPassAdd();}}. On any other row it goes to the next row, column 1
    (TR_KR_ISU.cs:3690-3691 {{mSG.Row += 1;}}).
  - Every other column: Enter advances one column (TR_KR_ISU.cs:3697-3699 {{if (mSG.Col < mSG.Cols - 1)}} …
    {{mSG.Col += 1;}}) and refocuses the editor (TR_KR_ISU.cs:3702 {{((Control)TEXT_ENTRY).Focus();}}).
- **The read-only skip lives in `MSG_PR_EnterCell`**, which fires on every column change: while the entered
  column's per-column slot is 0 it steps on (backwards when `Msgleft`), at most 10 steps:
  TR_KR_ISU.cs:3743 {{while (mSG[mSG.Col] == 0)}}, TR_KR_ISU.cs:3754 {{mSG.Col += 1;}},
  TR_KR_ISU.cs:3757 {{if (DC_Main.M > 10)}}. It also refuses the header row and zero-width cells:
  TR_KR_ISU.cs:3763 {{if (((mSG.Row == 0) | (mSG.CellWidth <= 0)) || mSG[mSG.Col] == 0)}}. The columns zeroed in
  `MSG_CLEAR` (13/14, 17–23, 33–49 in PURC RETURN) are therefore walked past, never stopped on. *Inferred:* the
  decompiler renders the width and alignment assignments identically
  (TR_KR_ISU.cs:2955-2956 {{mSG[1] = (int)Math.Round(1300.0 * ColCon);}}), so the exact AxMSFlexGrid property name
  behind the single-index slot is not provable from the text; the skip behaviour itself is explicit in the two
  cited loops.
- **KeyUp** re-selects the whole editor text after any arrow or Enter so typing replaces the cell:
  TR_KR_ISU.cs:7011 {{((int)e.KeyCode == 39) | ((int)e.KeyCode == 37)}},
  TR_KR_ISU.cs:7013 {{((TextBoxBase)TEXT_ENTRY).SelectionStart = 0;}}.

Form and header keys:
- **Esc** (`TR_KR_ISU_KeyDown`): with the grid editor visible it commits the cell, jumps to the last row and moves
  focus to the totals grid (TR_KR_ISU.cs:5403 {{if ((int)e.KeyCode == 27)}},
  TR_KR_ISU.cs:5415 {{((Control)TEXT_ENTRY_2).Focus();}}); with the totals editor visible it focuses `tEmpCode`
  (TR_KR_ISU.cs:5421 {{((Control)tEmpCode).Focus();}}); otherwise, when nothing changed, it closes the form
  (TR_KR_ISU.cs:5423-5425 {{else if (OldValTot == NewValTot)}} … {{((Form)this).Close();}}).
- **KeyPress** uppercases every character and swallows the apostrophe:
  TR_KR_ISU.cs:4919 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}},
  TR_KR_ISU.cs:4922 {{if (num == 0 || num == 39)}}.
- **Voucher No box**: F1 opens the recent-voucher list (TR_KR_ISU.cs:5719-5721 {{if ((int)e.KeyCode == 112)}} …
  {{BtnF1_Click(BtnF1, new EventArgs());}}), Up/Down step to the next/previous saved voucher
  (TR_KR_ISU.cs:5723-5729 {{BtnLast_Click(BtnLast, new EventArgs());}}), Enter reopens the typed number
  (TR_KR_ISU.cs:5731-5733 {{if ((int)e.KeyCode == 13)}} … {{DISPLAY_DATA();}}).
- **Purc Bill (tConsiNo) Enter** imports the source purchase: it reads `PR_DETL` of the named year/book/voucher
  (TR_KR_ISU.cs:6891 {{SELECT A.*,B.IT_NAME FROM PR_DETL}}), fills the party, asks
  TR_KR_ISU.cs:6910 {{All Item In This Voucher Import?}} and on Yes copies every line with its full weights
  (TR_KR_ISU.cs:6936-6942 {{DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"]}}), then focuses the party
  (TR_KR_ISU.cs:6980 {{((Control)tAcCode).Focus();}}).
- **Vch Desc Enter** enables and focuses Save (TR_KR_ISU.cs:6036-6039 {{((Control)BtnSave).Focus();}}); its F1
  help is the A/E-edition-only gate quoted in Scope.

## Rules
Save refusals, in the order `BtnSave_Click` applies them (TR_KR_ISU.cs:4928 {{private void BtnSave_Click(object sender, EventArgs e)}}).
Message texts are verbatim:
1. Licence expired, new entry: TR_KR_ISU.cs:4956 {{You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....}} — no focus move.
2. Employee mandatory and blank: TR_KR_ISU.cs:4961 {{Please Select Employee Code and Try......}} — focus `tEmpCode` (TR_KR_ISU.cs:4962 {{((Control)tEmpCode).Focus();}}).
3. Company type B, new entry: TR_KR_ISU.cs:4967 {{You Cant Save This Voucher Becouse This Company Type is B......}}.
4. Date outside the open year: TR_KR_ISU.cs:4974 {{You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...}}.
5. Date on/before the lock date: TR_KR_ISU.cs:4980 {{You Cant Save and Delete This Voucher Becouse Lock Date is =}} (the date is appended).
6. Edit without rights: TR_KR_ISU.cs:4986 {{You Have No Rights.....}} (condition TR_KR_ISU.cs:4984 {{Operators.CompareString(UserEdit, "Y", false) != 0}}).
7. Party blank: TR_KR_ISU.cs:4992 {{Please Insert Party and try}} — focus `tAcCode` (TR_KR_ISU.cs:4994 {{((Control)tAcCode).Focus();}}).
8. Voucher number blank: TR_KR_ISU.cs:4999 {{Please Insert VchNo and try}}.
9. Number already taken (new mode): the form re-numbers to MAX+1 and says
   TR_KR_ISU.cs:5017 {{Current Voucher No has been changd New Voucher No is}}
   (probe TR_KR_ISU.cs:5009-5018 {{SELECT MAX(VCH_NO) AS VchNo}}).
10. Negative stock on an untagged line when `MsNegativeStkSale=N`:
    TR_KR_ISU.cs:3919 {{Negative Stock is Not Allow Curent Stock =}}
    (guard TR_KR_ISU.cs:3917 {{Operators.CompareString(DC_Main.MsNegativeStkSale, "N", false) == 0}}).
11. Delete: lock-date refusal as rule 5 (TR_KR_ISU.cs:5363-5365 {{You Cant Save and Delete This Voucher Becouse Lock Date is =}}),
    rights refusal TR_KR_ISU.cs:5369 {{You Have No Rights.....}}, confirmation
    TR_KR_ISU.cs:5371 {{Are You Sure To Delete This Voucher now?}}, success
    TR_KR_ISU.cs:5388 {{Delete Success.}}.
12. Print rights: TR_KR_ISU.cs:5436 {{You Have No Print Rights.....}} (see Rights).

The web's own refusals differ in text by design of the API layer: no lines → `at least one return line is
required` (purchaseReturn.ts:252), UPI → `a purchase return has no UPI tender; record the refund as cheque or
card` (purchaseReturn.ts:256-259). The desktop has no UPI tender at all: the header stores only cheque, card,
cash and kasar (TR_KR_ISU.cs:5076-5079 {{dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);}}).

## Calculations
`CommPassTotal` (TR_KR_ISU.cs:3913 {{private void CommPassTotal(int CRow)}}) runs on every numeric cell leave
(`MSG_PR_LeaveCell`, TR_KR_ISU.cs:3876 {{CommPassTotal(mSG.Row);}}) in the order below. Grid columns: 6 Pcs,
7 GrWt, 8 OthWt, 9 NetWt, 10 GhtWt, 11 Touch, 12 West%, 14 LesWt, 15 Fine, 16 OthAmt, 24 Rate, 25 ItAmt,
26 Ltype, 27 LRate, 28 LAmt, 29 NetAmt, 34 RATE_TYPE.

1. Net weight = gross − other: TR_KR_ISU.cs:3925 {{Conversion.Val(mSG[mSG.Row, 7]) - Conversion.Val(mSG[mSG.Row, 8])}}, formatted `0.000`.
2. Fine = (net + ghat) × (touch + west) / 100 − less-wt:
   TR_KR_ISU.cs:3940 {{(Conversion.Val(mSG[mSG.Row, 9]) + Conversion.Val(mSG[mSG.Row, 10])) * (Conversion.Val(mSG[mSG.Row, 11]) + Conversion.Val(mSG[mSG.Row, 12])) / 100.0}}, `0.000`.
3. Item amount by `RATE_TYPE` (col 34), each rounded to whole rupees with `Math.Round(x, 0)` (midpoint-to-even):
   P → pieces × rate (TR_KR_ISU.cs:4006 {{Math.Round(Conversion.Val(mSG[mSG.Row, 6]) * Conversion.Val(mSG[mSG.Row, 24]), 0)}});
   1 → fine × rate/10 (TR_KR_ISU.cs:4009 {{Math.Round(Conversion.Val(mSG[mSG.Row, 15]) * (Conversion.Val(mSG[mSG.Row, 24]) / 10.0), 0)}});
   K → fine × rate/1000 (TR_KR_ISU.cs:4012 {{Math.Round(Conversion.Val(mSG[mSG.Row, 15]) * (Conversion.Val(mSG[mSG.Row, 24]) / 1000.0), 0)}});
   default → fine × rate (TR_KR_ISU.cs:4015 {{Math.Round(Conversion.Val(mSG[mSG.Row, 15]) * Conversion.Val(mSG[mSG.Row, 24]), 0)}}).
4. Labour by `LBR_TYPE` (col 26), whole rupees: P → pieces × rate
   (TR_KR_ISU.cs:4025 {{Math.Round(Conversion.Val(mSG[mSG.Row, 6]) * Conversion.Val(mSG[mSG.Row, 27]), 0)}});
   N → (net + ghat) × rate (TR_KR_ISU.cs:4028 {{Math.Round((Conversion.Val(mSG[mSG.Row, 9]) + Conversion.Val(mSG[mSG.Row, 10])) * Conversion.Val(mSG[mSG.Row, 27]), 0)}});
   K → (net + ghat) × rate/1000 (TR_KR_ISU.cs:4031 {{Math.Round((Conversion.Val(mSG[mSG.Row, 9]) + Conversion.Val(mSG[mSG.Row, 10])) * (Conversion.Val(mSG[mSG.Row, 27]) / 1000.0), 0)}});
   default → gross × rate (TR_KR_ISU.cs:4034 {{Math.Round(Conversion.Val(mSG[mSG.Row, 7]) * Conversion.Val(mSG[mSG.Row, 27]), 0)}}).
5. Line NetAmt = labour + other + item: TR_KR_ISU.cs:4129 {{Conversion.Val(mSG[mSG.Row, 28]) + Conversion.Val(mSG[mSG.Row, 16]) + Conversion.Val(mSG[mSG.Row, 25])}}, `0.00`.
6. `BILL_TOTAL` (TR_KR_ISU.cs:6520 {{if (Conversion.Val(MSG_TOT[0, 29]) != 0.0)}} guards it): bill net =
   round(sum of line NetAmt, 0) (TR_KR_ISU.cs:6522 {{Math.Round(Conversion.Val(MSG_TOT[0, 29]), 0)}});
   discount = sum(LAmt) × disc% / 100
   (TR_KR_ISU.cs:6525 {{Conversion.Val(MSG_TOT[0, 28]) * Conversion.Val(mSG2_TOTAL[1, 2]) / 100.0}});
   tax = round((net − discount) × tax% / 100, `MsTaxRof`)
   (TR_KR_ISU.cs:6527 {{Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof)}});
   total = round(net − discount + tax, 0)
   (TR_KR_ISU.cs:6528 {{Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]), 0)}});
   outstanding = total − cheque − card − cash − kasar
   (TR_KR_ISU.cs:6529 {{Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[5, 3])}}).
7. `MsTaxRof` comes from company setting `TAX_ROF` at company open:
   MS_OPNCOMP.cs:668-671 {{DC_Main.MsTaxRof = (int)Math.Round(a);}} reading
   MS_OPNCOMP.cs:668 {{DC_Main.Rshlp.Rows[0])["TAX_ROF"]}}; the static default is 0
   (DC_Main.cs:303 {{public static int MsTaxRof = 0;}}).

Worked vector (the module's LINE_W): net 5, touch 80 → fine 4.000; rate 1500 → item 6,000; making 40/g (N) →
labour 200; line net 6,200; tax 3% → 186.00; total 6,386. LINE_P: fine 9.160, item round(56,090.802) = 56,091,
labour 2,375, net 58,466, tax 1,753.98, total 60,220 (purchaseReturn.mjs:37-63).

## Lifecycle and write set
One handler saves new and reopened vouchers (`BtnSave_Click`). Order of statements for `PURC RETURN`:
1. Delete the voucher's `PR_DATA`, `PR_DETL`, `PR_IDTL` rows by the full key
   (TR_KR_ISU.cs:5033-5035 {{"DELETE FROM " + TblData}}).
2. Insert `TEMP_BOOK_DATA` under the hidden number `tHdVchNo`
   (TR_KR_ISU.cs:5038-5049 {{dataRow["VCH_NO"] = tHdVchNo.Text;}}).
3. Insert the `PR_DATA` header: NET_AMT (TR_KR_ISU.cs:5066 {{dataRow2["NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);}}),
   TAX_PRC (TR_KR_ISU.cs:5070-5071 {{dataRow2["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[2, 2]);}}), TAX_AMT,
   ROF_AMT and TOT_AMT (TR_KR_ISU.cs:5072-5073 {{dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);}}),
   tender CHQ/CARD/CASH/KASAR (TR_KR_ISU.cs:5076-5079 {{dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);}}),
   BILL_OS (TR_KR_ISU.cs:5080 {{dataRow2["BILL_OS"] = Conversion.Val(MSG2_TOTAL[9, 3]);}}), and the tax split:
   inter-state (`AcGstType = "I"`) puts the whole tax in IGST
   (TR_KR_ISU.cs:5093-5097 {{dataRow2["IGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]);}}), otherwise two unrounded
   halves (TR_KR_ISU.cs:5102-5103 {{dataRow2["SGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;}}); zero tax
   writes three zeros (TR_KR_ISU.cs:5108-5110 {{dataRow2["IGST_TAX"] = 0;}}). Creator:
   TR_KR_ISU.cs:5124 {{dataRow2["MAIN_USER"] = MainUser;}}. The source purchase is stored as SL_BILL_YRCD/DBCD/NO
   (TR_KR_ISU.cs:5129-5132 {{dataRow2["SL_BILL_NO"] = tConsiNo.Text;}}).
4. Insert one `PR_DETL` row per grid row with net+amount ≠ 0 and an item code
   (TR_KR_ISU.cs:5148 {{Conversion.Val(MSG[DC_Main.i, 9]) + Conversion.Val(MSG[DC_Main.i, 29]) != 0.0}});
   a blank tag stores `"N"` (TR_KR_ISU.cs:5165-5167 {{dataRow3["TAG_NO"] = "N";}});
   **the line carries no tax: `TAX_PRC = 0`** (TR_KR_ISU.cs:5206 {{dataRow3["TAX_PRC"] = 0;}}) and no per-line
   tax-amount column is written at all (the column list, TR_KR_ISU.cs:5150-5214 {{dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 24]);}}).
5. Delete and re-post the ledger `AC_DATA` via TR_KR_ISU.cs:5249 {{Ac_Ledr.Purc_Rtn_Ledr(DC_Main.MCo_Book, tVchNo.Text);}},
   the day book via TR_KR_ISU.cs:5263 {{Ac_Rojmel.Purc_Rtn_Rojmel(DC_Main.MCo_Book, tVchNo.Text);}},
   the tax rows via TR_KR_ISU.cs:5269 {{Ac_Tax.Purc_Rtn_GST(DC_Main.MCo_Book, tVchNo.Text);}},
   stock out via TR_KR_ISU.cs:5284 {{Ac_Stock.Purc_Rtn_Stk(DC_Main.MCo_Book, tVchNo.Text);}} and the loose
   diamond detail via TR_KR_ISU.cs:5285 {{Ac_Stock.Dm_PrRtn_Detl(DC_Main.MCo_Book, tVchNo.Text);}};
   each preceded by a scoped DELETE (TR_KR_ISU.cs:5237 {{DELETE FROM AC_DATA WHERE CO_CODE =}}, also :5251,
   :5265, :5271-5276). Remark: TR_KR_ISU.cs:5293 {{Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);}}.
6. Refresh the party balance (TR_KR_ISU.cs:5301-5307 {{DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));}}),
   clear the screen and **print automatically**: TR_KR_ISU.cs:5309 {{BtnPrint_Click(BtnPrint, new EventArgs());}}.

Reopen (`DISPLAY_DATA`, TR_KR_ISU.cs:4614 {{SELECT * FROM " + TblData + " WHERE CO_CODE =}}) reads the header by
the full key and keeps the clock
(TR_KR_ISU.cs:4624 {{mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_TIME"]), "HH:mm:ss");}}),
the hidden number (TR_KR_ISU.cs:4625 {{tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));}}),
the creator (TR_KR_ISU.cs:4689 {{MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));}})
and the source-bill fields (TR_KR_ISU.cs:4694-4696 {{tConsiNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["SL_BILL_NO"], (object)""));}}).
An unchanged save therefore re-writes the same identity.

Delete (`BtnDelete_Click`, TR_KR_ISU.cs:5371 {{Are You Sure To Delete This Voucher now?}} gates it): after the
confirmations it inserts one `DELETE_DATA` row per line from a SELECT over header+detail+book
(TR_KR_ISU.cs:5373 {{INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE}})
naming the deleting user, then deletes REMARK_DATA, TEMP_BOOK_DATA (hidden number), MAIN_STOCK, AC_DATA,
ROJ_MEL_DATA, TAX_DATA, DM_DATA, PR_DATA, PR_DETL, PR_IDTL, BAR_DETL and BAR_IDTL
(TR_KR_ISU.cs:5375-5387 {{DELETE FROM REMARK_DATA WHERE CO_CODE =}}, e.g.
TR_KR_ISU.cs:5385 {{"DELETE FROM " + TblIdtl}}).

Cancel (`BtnCancel_Click`, TR_KR_ISU.cs:5624-5630 {{CustOpAmt = 0.0;}} … {{CLEAR_DATA();}}) zeroes the balance
variables and clears the screen; `CLEAR_DATA` resets the grid, re-numbers to MAX+1
(TR_KR_ISU.cs:4585-4593 {{DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000")}}) and, for a tax book
(`FormBookType = "T"`), loads tax code 10 from `TAX_MAST` as the default rate
(TR_KR_ISU.cs:4563-4577 {{SELECT * FROM TAX_MAST WHERE CO_CODE =}} … {{TAX_CODE = '10'}}).

## Print
`BtnPrint_Click` (TR_KR_ISU.cs:5430 {{private void BtnPrint_Click(object sender, EventArgs e)}}), also invoked by
every save (:5309):
1. Rights gate: TR_KR_ISU.cs:5434 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}} →
   TR_KR_ISU.cs:5436 {{You Have No Print Rights.....}} and return.
2. Duplicate-print setting (TR_KR_ISU.cs:5439 {{Operators.CompareString(DC_Main.MsSlDupPrint, "Y", false) == 0}}),
   then the options dialog TR_KR_ISU.cs:5443 {{((Form)MyProject.Forms.MS_PRINT).ShowDialog();}}; CANCEL aborts
   (TR_KR_ISU.cs:5444 {{if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)}}).
3. Template choice for a return book: tax book (`FormBookType = "T"`) →
   TR_KR_ISU.cs:5517-5519 {{else if (Operators.CompareString(FormBookType, "T", false) == 0)}} …
   {{PrRtnBillGst.RPT}}; otherwise TR_KR_ISU.cs:5524 {{PrRtnBill.RPT}}. The WhatsApp/e-mail branch uses the same
   names (TR_KR_ISU.cs:5466 {{(Operators.CompareString(FormBookType, "T", false) != 0) ? "PrRtnBill" : "PrRtnBillGst"}}).
4. Selection formula is the complete voucher key:
   TR_KR_ISU.cs:5527 {{Cr.SelectionFormula = "{" + TblData + ".CO_CODE}} (CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO).
5. Formula parameters passed to the report: `OpAmt`/`ClAmt` at `0.00`
   (TR_KR_ISU.cs:5528 {{("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00"))}}, :5529), `OpGold`/`ClGold` at
   `0.000` (:5530-5531), `OpSilver`/`ClSilver` at `0.000` when `MsSilverWt3Digit=Y` else `0.00`
   (TR_KR_ISU.cs:5532 {{MsSilverWt3Digit, "Y", false}}). These are the party's opening/closing balances refreshed
   after the save (TR_KR_ISU.cs:5301-5307 {{DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));}}).
6. Copy label parameter `InVoiceType`: TR_KR_ISU.cs:5538 {{InVoiceType = 'ORIGINAL FOR RECIPIENT'}},
   TR_KR_ISU.cs:5544 {{InVoiceType = 'DUPLICATE FOR SUPPLIER'}},
   TR_KR_ISU.cs:5550 {{InVoiceType = 'TRIPLICATE FOR TRANSPORTER'}}; printer destination for PRINT
   (TR_KR_ISU.cs:5539 {{Cr.Destination = (DestinationConstants)1;}}) else maximised preview with zoom
   (TR_KR_ISU.cs:5557-5560 {{Cr.WindowState = (WindowStateConstants)2;}}).

**Where the tax on the print comes from (G95).** `PrRtnBillGst.RPT` reads the header, never line tax
(`extraction_output/rpt_xml/PrRtnBillGst.xml`, supplementary evidence, not a .cs citation):
`PR_DATA.TAX_PRC` (xml line 127), `PR_DATA.IGST_TAX`/`CGST_TAX`/`SGST_TAX` (xml 152-154); the rate captions are
formulas `'CGST : ' & {PR_DATA.TAX_PRC}/2 & '% :'` and the SGST twin (xml 609-614), IGST uses the full rate;
each tax amount section is suppressed when its header field is 0 (xml 2049, 2091, 2133). The HSN code prints per
line from `ITEM_MAST.HSN_CODE` (xml 283, 1711); the report groups by voucher (`@VchGroup`, xml 617-618) then by
`PR_DETL.SR_NO` (xml 651). `PR_DETL.TAX_PRC` is declared but unused (xml 210, UseCount 0). This matches the
write set: the desktop stores no per-line tax (TR_KR_ISU.cs:5206 {{dataRow3["TAX_PRC"] = 0;}}) and splits the
header tax into equal halves (TR_KR_ISU.cs:5102 {{dataRow2["SGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;}}).

## Rights
Loaded once at Load from `USER_SET` for the location, user and sub-menu:
TR_KR_ISU.cs:4231 {{Select * From USER_SET WHERE LC_CODE =}}; the three flags are
TR_KR_ISU.cs:4236 {{dataTable.Rows[0]["FRM_EDIT"]}}, TR_KR_ISU.cs:4237 {{dataTable.Rows[0]["FRM_DELETE"]}},
TR_KR_ISU.cs:4238 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}.

- Edit: `UsUPdate` (the voucher's own USER_UPDATE flag, loaded at
  TR_KR_ISU.cs:4690 {{UsUPdate = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_UPDATE"], (object)""));}})
  or `UserEdit` must be Y (TR_KR_ISU.cs:4984 {{Operators.CompareString(UserEdit, "Y", false) != 0}}), else
  TR_KR_ISU.cs:4986 {{You Have No Rights.....}}.
- Delete: `UsDelete` or `UserDelete` must be Y (TR_KR_ISU.cs:5367 {{Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0}}),
  else TR_KR_ISU.cs:5369 {{You Have No Rights.....}}.
- Print: `UserPrint` must be Y (TR_KR_ISU.cs:5434 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}),
  else TR_KR_ISU.cs:5436 {{You Have No Print Rights.....}}. There is no view-only gate on the desktop print; the
  right is specifically FRM_PRINT.

## Desktop weaknesses not to port
- String-built SQL everywhere, e.g. the duplicate-number probe
  TR_KR_ISU.cs:5009 {{"SELECT * FROM " + TblData + " WHERE CO_CODE = '"}} and the print contact query
  TR_KR_ISU.cs:5456 {{SELECT B.AC_EMAIL,B.AC_MOBILE FROM }}. The web uses parameterised queries.
- No transaction around the save: the deletes and inserts run statement by statement
  (TR_KR_ISU.cs:5033-5293 {{"DELETE FROM " + TblData}}); on any error the handler shows
  TR_KR_ISU.cs:5332 {{Error Found:}} and flips the form to edit mode
  (TR_KR_ISU.cs:5331 {{EntryMode = "E";}}), leaving earlier tables written. The web writer runs in one
  transaction (purchaseReturn.ts:268, purchaseReturnLifecycle.ts:209) — the rollback feature case proves it.
- Global mutable state (`DC_Main.M`, `DC_Main.i`, `DC_Main.RsQry`) reused across loops
  (e.g. TR_KR_ISU.cs:3358 {{DC_Main.X = 1;}}).
- The delete removes `BAR_DETL`/`BAR_IDTL` rows by voucher
  (TR_KR_ISU.cs:5386-5387 {{DELETE FROM BAR_DETL WHERE CO_CODE =}}) — tag provenance is destroyed rather than
  reversed; the web reverses stock and restores tag-stock-only tags (purchaseReturnLifecycle.ts:138-181, :296).
- Registration-keyed special cases hard-coded in the form (e.g. `SSRegSrNo = "VK252NUST"` making Fine read-only,
  TR_KR_ISU.cs:3845 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0)}}; `"HM437NEHP"`
  column layout, TR_KR_ISU.cs:3035 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "HM437NEHP", false) == 0)}}).
  Do not port customer-specific branches.

## Web today
- `web/apps/web/app/(app)/txn/purchase-return/page.tsx` — the screen: book select (PURC RETURN, preferred PRT),
  voucher Load/New/Delete, supplier lookup, orig-purchase Import, tax/discount/inter-state, an 8-input compact
  grid (Item, Tag, Pcs, Gross, Net Wt, Touch%, Rate, Making/g) plus computed Fine/Amount text cells
  (page.tsx:497-498), extended-mode cells, a per-row × button, TenderPanel, VoucherList with the print link
  (page.tsx:560-562). It mounts `useGridKeyboard` positionally, without `columnCount` (page.tsx:70-80).
- `web/apps/web/components/GridKeyboard.tsx` — shared grid key contract. `resolveGridKey` (:29-72) is the pure
  decision table; `walkEnter` (:179-200) already implements G96: it skips cells with no editable control
  (`EDITABLE_CONTROL`, :146-148 excludes buttons, readonly and disabled inputs), wraps to the next row and
  appends after the last row; positional addressing derives row/column from the DOM (:96-116).
- `web/apps/web/lib/purchaseReturnForm.ts` — line state, preview (`linePreview`), import/reopen mapping and the
  save command; `web/packages/core/src/purchaseReturnAmount.ts` — the return's amount basis and whole-rupee
  rounding policy (G198, N188).
- `web/apps/api/src/modules/purchase/purchaseReturn.ts` — the writer: validations (:250-260), tag resolution
  against the original purchase (:159-224), header with CGST/SGST/IGST (:496-520), per-line `TAX_PRC:
  input.taxRatePct` (:452), ledger/tender/TAX_DATA/MAIN_STOCK/DM_DATA/ROJ_MEL_DATA (:521-723), write set
  `PURCHASE_RETURN_WRITE_TABLES` (:227-236).
- `web/apps/api/src/modules/purchase/purchaseReturnLifecycle.ts` — reopen (:52-109), edit keeping number, hidden
  number, creator and clock (:201-239), delete with DELETE_DATA and tag restore (:247-299).
- `web/apps/api/src/routes/txn.ts:2706-2758` — the five routes; the print route (:2726-2748) guards `'view'`,
  loads `purchaseBillData` and renders `purchaseBillHtml` with title "Purchase Return".
- `web/apps/api/src/modules/purchase/purchaseBill.ts` — shared purchase/return document: `PR_DATA` header +
  `PR_DETL` lines with HSN from item or group (:30-37), rendered on `gstBillBody` (:85).
- `web/apps/api/src/modules/documents/docChrome.ts` — `gstBillBody` (:234-314) and **the G95 fix already in the
  tree**: `allocateHeaderTaxToHsn` (:207-229) splits the header `CGST_TAX`/`SGST_TAX`/`IGST_TAX` across HSN
  groups by taxable share, last group takes the remainder; the comment cites G95/G181 (:193-205).
- `web/apps/api/src/modules/rbac/routePolicy.ts:397-403` — all five routes under menu `Purchase/Purchase Return`;
  `authorization.ts:161` supports a `'print'` action checking `FRM_PRINT`, used by other modules
  (e.g. accountLedger.ts:171) but not by this print route.
- Tests: `web/apps/api/test/documents.test.ts` — G95 unit cases already present: purchase bill HSN carries header
  IGST (:97-134), intra-state purchase return HSN carries header CGST/SGST (:137-165), odd-paise halves (G181,
  :187). `web/apps/web/test/gridKeyboard.test.ts` — decision-table unit tests only (81 lines; Enter
  move/wrap/append at :42-58); no DOM-level test of `walkEnter`'s read-only skip.
  `web/apps/web/test/purchase-return.journey.mjs` — the zero-mock journey.
- `web/apps/web/test/features/modules/purchaseReturn.mjs` — 22 cases; today 21 active + 1 blocked. History (doc 12):
  N187 ran 15 passed / 5 failed (G198×2, G199, G200, G201) / 2 blocked (T14 G173, T15 G174), line 2155; N188
  milestone 1 fixed G198 ("20 passed, 0 failed and 2 blocked", lines 2180-2181 — the packet's "20 of 22");
  N189/N190/N191 fixed G199/G200/G201 (evidence lines 2253, 2404, 2422); G173's rollback matrix now covers this
  module (line 188), so `rollback.mid-write` (:954-982) is active. **Only blocked marker left**:
  `config.setting-variant` (:983-992, G174/N166). No Enter-walk case and no HSN-tax assertion exist in the module.

## Gaps
1. **G95 — no browser output case pins the HSN tax on a printed return (missing case; the code fix is already in
   the tree).** Desktop: a tax book's return prints `PrRtnBillGst.RPT`
   (TR_KR_ISU.cs:5519 {{PrRtnBillGst.RPT}}) whose tax fields are the header's
   (TR_KR_ISU.cs:5095 {{dataRow2["IGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]);}},
   TR_KR_ISU.cs:5102 {{dataRow2["SGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;}}); lines carry no tax
   (TR_KR_ISU.cs:5206 {{dataRow3["TAX_PRC"] = 0;}}). Web: `docChrome.ts:207-229` already allocates header tax to
   HSN groups and `documents.test.ts:137` pins it at unit level, but the browser case `print.debit-note`
   (purchaseReturn.mjs:699-726) asserts only `/Purchase Return/` and `/6,386/` (:718-719) — it would still pass
   with 0.00 in every HSN tax cell. Fix: extend `print.debit-note` or add `print.hsn-tax` (T16, output): save
   LINE_W (tax 186 → CGST 93.00, SGST 93.00), open the print popup, slice the `class="hsn"` table and assert the
   HSN row's taxable 6,200.00, CGST 93.00, SGST 93.00, Tax 186.00 and that no tax cell is `0.00`; read the HSN
   code itself from the fixture's ITEM_MAST/GROUP_MAST (the catalogue does not pin it). Add an inter-state
   variant (IGST 186.00) using `PARTIES.interState`.
2. **G95 — the print route checks view, not the desktop's print right (missing rights check).** Desktop:
   TR_KR_ISU.cs:5434 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}} with
   TR_KR_ISU.cs:5436 {{You Have No Print Rights.....}}, `UserPrint` from `FRM_PRINT`
   (TR_KR_ISU.cs:4238 {{dataTable.Rows[0]["FRM_PRINT"]}}). Web: `txn.ts:2727` guards `'view'`; the `'print'`
   action exists (`authorization.ts:161`) and is used elsewhere (`accountLedger.ts:171`). Fix: guard the print
   route with `'print'` and add a refusal case (a user with view but no FRM_PRINT gets 403 and no document).
   Note: the sales print route has the same pattern (`txn.ts:1410`), so the supervisor may want a cross-family
   decision; this packet only flags Purchase Rtn.
3. **G96 — no browser keyboard case on the purchase-return grid (missing case; the walk is already in the
   tree).** Desktop: Enter advances one column (TR_KR_ISU.cs:3697-3699 {{if (mSG.Col < mSG.Cols - 1)}}),
   the EnterCell loop walks past zeroed columns (TR_KR_ISU.cs:3743 {{while (mSG[mSG.Col] == 0)}}), and Enter on
   the last row's NetAmt appends a row and restarts at column 1
   (TR_KR_ISU.cs:3670 {{if (mSG.Row == mSG.Rows - 1)}}, TR_KR_ISU.cs:3683 {{mSG.Col = 1;}}).
   Web: `GridKeyboard.tsx:179-200` implements the skip/append and the page mounts it (page.tsx:70-80), but
   `gridKeyboard.test.ts` only tests the pure decision table and `purchaseReturn.mjs` has no Enter case. Fix:
   add `keyboard.enter-walk` (T17) modelled on `stockAdjust.mjs:1149-1207`: focus Item row 1, Enter through Tag,
   Pcs, Gross, Net Wt, Touch%, Rate, Making/g (assert focus after each), then Enter must skip the read-only Fine
   and Amount cells and the × button and land on row 2 Item (append); type a second line, Ctrl+D removes it with
   the row gone, Alt+S saves (the mnemonic is marked, page.tsx:534). Assert the persisted two lines.
4. **G96 — editable-stop difference between the desktop grid and the web compact grid (layout difference, not a
   wrong result).** Desktop Fine (15) is an editable stop except for one registration
   (TR_KR_ISU.cs:3842-3848 {{case 15:}} … {{((TextBoxBase)TEXT_ENTRY).ReadOnly = true;}}), and Rate/ItAmt/NetAmt
   (24/25/29) are editable with amount↔rate back-solving
   (TR_KR_ISU.cs:4040-4110 {{Conversion.Val(mSG[mSG.Row, 25]) != Conversion.Val(mSG[mSG.Row, 46])}}). Web: Fine
   and Amount are computed text (page.tsx:497-498); Rate is editable but there is no ItAmt override cell in
   compact mode. The Enter walk therefore stops at different cells by design of the compact layout. Fix: none in
   this packet — the new case must assert the web's editable order; full grid parity belongs to the layout
   residual (N77).
5. **T15 `config.setting-variant` is the only blocked case (missing fixture infrastructure, G174/N166).**
   Web: purchaseReturn.mjs:983-992 carries `blocked: 'No settings-variant company in the catalogue yet (G174 /
   N166).'`; `settingsManifest` (:310-313) already declares what varies: `TAX_ROF` blank → 2dp fallback and
   whole-rupee return amounts regardless of TOT_AMT_ROF/LBR_ROF. Desktop: the tax rounding is the company's
   `TAX_ROF` (MS_OPNCOMP.cs:668-671 {{DC_Main.MsTaxRof = (int)Math.Round(a);}}) applied at
   TR_KR_ISU.cs:6527 {{DC_Main.MsTaxRof}}; the row-change append is `SL_ROW_CHANGE`
   (TR_KR_ISU.cs:3470 {{Operators.CompareString(DC_Main.MsSlRowChange, "Y", false) == 0}}, loaded at
   MS_OPNCOMP.cs:673 {{DC_Main.MsSlRowChange = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_ROW_CHANGE"], (object)""));}});
   negative stock refusal is `MsNegativeStkSale`
   (TR_KR_ISU.cs:3917 {{Operators.CompareString(DC_Main.MsNegativeStkSale, "N", false) == 0}}). Fix: N166 must
   provision a second fixture company with different settings (at least TAX_ROF 0 and 3, SL_ROW_CHANGE Y/N);
   then implement the case: save LINE_P under each company and assert the stored tax/total per the desktop
   formula (e.g. TAX_ROF=0 → tax round(1,753.98, 0) = 1,754, total 60,220; TAX_ROF=3 → 1,753.980). Until the
   fixture exists the case stays blocked; do not unblock it by loosening the expectation.
6. **Stored per-line TAX_PRC differs (wrong stored value, no print effect).** Desktop writes 0 on every return
   line (TR_KR_ISU.cs:5206 {{dataRow3["TAX_PRC"] = 0;}}); the web writes the header rate on every line
   (purchaseReturn.ts:452, `TAX_PRC: input.taxRatePct`). The print is unaffected because the report reads only
   the header (PrRtnBillGst.xml declares `PR_DETL.TAX_PRC` with UseCount 0), but a write-set comparison against
   the desktop will flag it. Fix: store 0 as the desktop does, or record the deviation as an accepted web
   extension; a write-set test should pin whichever the owner chooses.
7. **Status correction for the next worker (not a code gap).** `rollback.mid-write` (T14) is no longer blocked:
   the fault matrix runs for Purchase Return's 7-table write set (purchaseReturn.mjs:19-27, :954-982; doc 12
   line 188). The desktop's non-transactional save (TR_KR_ISU.cs:5033-5293 {{"DELETE FROM " + TblData}}, error
   path TR_KR_ISU.cs:5332 {{Error Found:}}) is the behaviour the case contrasts against. The only blocked marker
   left in the module is item 5's.

## Open questions
1. The exact AxMSFlexGrid property behind the single-index slot (`mSG[col]`) cannot be proven from the
   decompiled text, which renders width and alignment assignments identically
   (TR_KR_ISU.cs:2955-2956 {{mSG[1] = (int)Math.Round(1300.0 * ColCon);}}). The skip rule is stated behaviourally
   from the two loops; a desktop run or the interop assembly would name the property. Does not change the fix.
2. Should the web's Fine/Amount cells become editable overrides as on the desktop (gap 4)? That is a layout
   decision for N77/the owner, not answerable from the source.
3. Should every voucher print route move from `'view'` to `'print'` (gap 2)? The sales print shares the pattern
   (txn.ts:1410); a cross-family decision avoids fixing one screen and breaking consistency.
4. Which settings exactly should the G174 variant company carry (TAX_ROF values, SL_ROW_CHANGE, negative-stock
   flag, LBR_WITH_GHT)? N166 owns the fixture; the source only shows where each setting acts.
5. Not verified in this session: the browser suite itself. `web/node_modules` is absent in this worktree and no
   isolated database was started, so no feature case was executed here; the pass/blocked counts above come from
   the case file's own markers and doc 12's recorded runs, not from a fresh run.