# WP-22 study: Company → Year Create (desktop `MS_YEAR`)

Written from the source in this worktree (`agent/wp22-year-create`) on 2026-11-16. Every statement about the desktop
carries a quoted citation in the form `FILE:LINE {{quoted text}}`, and every quote is a substring of the cited line
(or of the cited range). Desktop files are in `unified/src/csharp/DataCareNext/` and are cited by file name only.
Web files and repository documents are cited from the repository root. "Inferred" marks a conclusion the source
implies but does not state.

## Scope

- **Menu.** Company → Year Create, catalog id `Company/Year Create` (`docs/handbook/menu-catalog.jsonl`). Edition:
  Lite, `docs/handbook/menu-editions.json:184 {{"edition": "L",}}`. The desktop has no edition check in the form or
  its dispatch: the dispatch is a plain case (`MDI_FORM.cs:7421 {{case "Year Create":}}`) that creates the form with no
  argument (`MDI_FORM.cs:7423 {{MS_YEAR mS_YEAR = new MS_YEAR();}}`). The form has no `MsSoftType` test, so every
  edition that shows the menu runs the same code.
- **Form.** `MS_YEAR.cs`, 1,596 lines, class `MS_YEAR.cs:23 {{public class MS_YEAR : Form}}`. Caption:
  `MS_YEAR.cs:752 {{((Form)this).Text = "Year Create";}}`.
- **Two ways in.** (1) The menu, in direct-constructor mode. (2) Straight after a new company is saved in
  `MS_COMPANY.cs`: `MS_COMPANY.cs:6196 {{DC_Main.NewCompCode = tCoCode.Text;}}` marks the company as new, then
  `MS_COMPANY.cs:6205 {{MS_YEAR mS_YEAR = new MS_YEAR();}}` opens this form for its first year.
- **Two modes.** `EntryMode` is `A` (create) or `E` (an existing year was loaded). `DISPLAY_DATA` sets `E`
  (`MS_YEAR.cs:909 {{EntryMode = "E";}}`) when the operator's year code and month match a row.
- **Alternate-year flag.** `DC_Main.MsAlterYear` is read from the company row's `ALTER_YEAR` column
  (`MS_OPNCOMP.cs:475 {{DC_Main.MsAlterYear = Conversions.ToString}}`). When it is `Y` the form uses the
  alternate-year branch (month-keyed years, one database per year). It is a company setting, not an operator choice on
  this form.
- **Facts from the brief, checked against the source:**
  1. *First year of a new company runs the 17-table copy.* Confirmed. The copy runs only when `NewCompCode` is set
     (`MS_YEAR.cs:1357 {{if (Operators.CompareString(DC_Main.NewCompCode, "", false) != 0)}}`) and calls
     `NewCompParmCreat` (`MS_YEAR.cs:1360 {{NewCompParmCreat();}}`). The web's first-year rule is different (see
     Gaps 1 and 2).
  2. *A further year restores the previous database and deletes other years' rows.* Confirmed. Restore is in the
     `flag` branch (`MS_YEAR.cs:1233 {{if (flag)}}`), and the purge is `DeleteOldYear_Data` (`MS_YEAR.cs:1387 {{DeleteOldYear_Data();}}`).
  3. *The alternate-year branch is not on the web.* Confirmed (Gap 11).
  4. *"Year Is Already Exist" is missing on the web.* Corrected. The desktop shows it only on an edit save of an
     existing year (`MS_YEAR.cs:1394 {{Year Is Already Exist...Now ReOpen Sofware...}}`), never on a duplicate create.
     A duplicate create on the desktop has no message at all (Lifecycle, Rule 4).
  5. *Delete must not be ported.* Confirmed (Desktop weaknesses, item 1).
  6. *The web has no year close or reopen.* Confirmed. `web/apps/api/src/routes/txn.ts:6375 {{There is deliberately no year close/reopen here}}`
     is not reproduced here; the web comment cites `MS_YEAR.cs:1035-1040 {{if ((DateAndTime.Month(DateAndTime.Today) > 3) & (DateAndTime.Month(DateAndTime.Today) <= 12))}}, 1196`. Nothing in this study proposes bringing it back.
- **Out of scope.** Balance transfer between years (the separate menu Balance TrFr). The web's carry-forward panel
  belongs to that menu, not to `MS_YEAR`: `MS_YEAR.cs` has no carry-forward code. Company creation itself (the rest of
  `MS_COMPANY.cs`) is covered by another study; only the hand-over into `MS_YEAR` is cited here.

## Screen

Controls in the designer (`MS_YEAR.cs:493-758 {{private void InitializeComponent()}}`, `InitializeComponent`). Tab order is the `TabIndex` value; a lower
number is visited first. Defaults are set at load by `CLEAR_DATA` → `BtnCancel_Click`.

| Control | Type | Caption / text | Tab | Default and rule | Source |
|---|---|---|---|---|---|
| `tYearCode` | TextBox | (none); label `Create New Year` | 0 | Year code. Set by Cancel from today's date. Max length 15. | `MS_YEAR.cs:683 {{((Control)tYearCode).TabIndex = 0;}}`; `MS_YEAR.cs:680 {{((TextBoxBase)tYearCode).MaxLength = 15;}}`; `MS_YEAR.cs:700 {{Label2.Text = "Create New Year";}}` |
| `tMonth` | TextBox | (none) | 1 | Start month, two characters. Hidden unless alternate-year mode; default `04`. Max length also 15. | `MS_YEAR.cs:690 {{((Control)tMonth).TabIndex = 1;}}`; `MS_YEAR.cs:691 {{((Control)tMonth).Visible = false;}}`; `MS_YEAR.cs:892 {{tMonth.Text = "04";}}` |
| `mOpDate` | MaskedTextBox | label `Opening Date` | 2 | Mask `00/00/0000`. Set by Cancel. | `MS_YEAR.cs:714 {{mOpDate.Mask = "00/00/0000";}}`; `MS_YEAR.cs:709 {{Label1.Text = "Opening Date";}}` |
| `mClDate` | MaskedTextBox | label `Closing Date` | 3 | Mask `00/00/0000`. Set by Cancel. | `MS_YEAR.cs:731 {{mClDate.Mask = "00/00/0000";}}`; `MS_YEAR.cs:726 {{Label3.Text = "Closing Date";}}` |
| `BtnSave` | Button | `&Save` | 0 (panel) | Save. Access key Alt+S. | `MS_YEAR.cs:643 {{((Control)BtnSave).TabIndex = 0;}}`; `MS_YEAR.cs:644 {{"&Save"}}` |
| `BtnCancel` | Button | `&Cancel` | 1 (panel) | Resets every field to the default. | `MS_YEAR.cs:630 {{((Control)BtnCancel).TabIndex = 1;}}`; `MS_YEAR.cs:631 {{"&Cancel"}}` |
| `BtnDelete` | Button | `&Delete` | 2 (panel) | Visible; runs the user-form routine (see Desktop weaknesses, item 1). | `MS_YEAR.cs:616 {{((Control)BtnDelete).TabIndex = 2;}}`; `MS_YEAR.cs:617 {{"&Delete"}}` |
| `BtnExit` | Button | `E&xit` | 3 (panel) | Closes the form. | `MS_YEAR.cs:603 {{((Control)BtnExit).TabIndex = 3;}}`; `MS_YEAR.cs:604 {{"E&xit"}}` |
| `BtnPrint` | Button | `&Print` | 4 (panel) | Does nothing except a rights message (see Print). | `MS_YEAR.cs:656 {{((Control)BtnPrint).TabIndex = 4;}}`; `MS_YEAR.cs:657 {{"&Print"}}` |
| `Cr` | OCX (ActiveX) | none | 10 | Hidden, 28 by 28 pixels, in the button panel. No code in `MS_YEAR.cs` calls it. | `MS_YEAR.cs:664 {{((Control)Cr).TabIndex = 10;}}`; `MS_YEAR.cs:662 {{((AxHost)Cr).OcxState}}` |
| `lblBook` | Label | `Year Create` (title bar) | 6 | Title only. | `MS_YEAR.cs:675 {{lblBook.Text = "Year Create";}}` |

**Enabled and visible rules.** Nothing is disabled at design time. The only visibility rule is `tMonth`, shown in
alternate-year mode (`MS_YEAR.cs:887 {{((Control)tMonth).Visible = true;}}`).

**What Display shows.** `DISPLAY_DATA` reads the row whose `CO_CODE`, `CO_YEAR` and `YEAR_MONTH` match the code and
month on screen (`MS_YEAR.cs:901 {{SELECT * FROM YEAR_MAST WHERE CO_CODE = '}}`). If a row is found it fills the
year code, month, opening date and closing date from it (`MS_YEAR.cs:908 {{mClDate.Text = Conversions.ToString}}`),
and sets `EntryMode` to `E`. The form shows no list of years and no grid.

**Load.** `MS_YEAR_Load` reads the operator's rights from `USER_SET` (`MS_YEAR.cs:774 {{Select * From USER_SET WHERE LC_CODE}}`)
into `UserEdit`, `UserDelete` and `UserPrint` (`MS_YEAR.cs:779 {{["FRM_EDIT"]}}`, `MS_YEAR.cs:780 {{["FRM_DELETE"]}}`,
`MS_YEAR.cs:781 {{["FRM_PRINT"]}}`). It then applies the theme and clears the fields (`MS_YEAR.cs:883 {{CLEAR_DATA();}}`). Focus
goes to the year code: `MS_YEAR.cs:895 {{CurActCtrl = (Control)(object)tYearCode;}}`.

## Keyboard

Every key the form handles, from the handlers. There are no function keys, no Ctrl or Alt chords, and no default
(Enter) button.

| Key | Where | What it does | Source |
|---|---|---|---|
| Any character | Form `KeyPress` | Converts the character to upper case. Swallows the NUL character and the apostrophe (code 39). | `MS_YEAR.cs:942 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}`; `MS_YEAR.cs:947 {{e.Handled = true;}}` |
| Esc | Form `KeyDown` | Closes the form. | `MS_YEAR.cs:955 {{if ((int)e.KeyCode == 27)}}` |
| Enter | Year code | If the code is not empty, runs Display (loads an existing year) and moves to the next field. | `MS_YEAR.cs:1083 {{if ((int)e.KeyCode == 13 && Operators.CompareString(tYearCode.Text, "", false) != 0)}}`; `MS_YEAR.cs:1085 {{DISPLAY_DATA();}}`; `MS_YEAR.cs:1086 {{SendKeys.Send("{tab}");}}` |
| Enter | Month | Moves to the next field. | `MS_YEAR.cs:1073 {{if ((int)e.KeyCode == 13)}}`; `MS_YEAR.cs:1075 {{SendKeys.Send("{tab}");}}` |
| Enter | Opening date | Validates the date (`DC_Main.SetDate`). If valid and in alternate-year mode, copies the month from the date. If valid, moves on. | `MS_YEAR.cs:1105 {{DC_Main.SetDate(ref MsDate);}}`; `MS_YEAR.cs:1111 {{tMonth.Text = Strings.Mid(mOpDate.Text, 4, 2);}}`; `MS_YEAR.cs:1113 {{SendKeys.Send("{TAB}");}}` |
| Enter | Closing date | Validates the date; if valid, moves on. | `MS_YEAR.cs:1130 {{DC_Main.SetDate(ref MsDate);}}`; `MS_YEAR.cs:1134 {{SendKeys.Send("{TAB}");}}` |
| Focus into opening date | Opening date `GotFocus` | Selects all the text, so typing replaces it. | `MS_YEAR.cs:1092 {{((TextBoxBase)mOpDate).SelectionStart = 0;}}` |
| Focus change | Form `Deactivate` | Re-establishes the active control, so focus returns to the same field. | `MS_YEAR.cs:932 {{CurActCtrl = ((ContainerControl)this).ActiveControl;}}` |

**Mnemonic keys.** The buttons carry access keys in their captions (`&Save`, `&Cancel`, `&Delete`, `E&xit`,
`&Print`; see Screen). No F-key or Ctrl+S shortcut to Save exists.

**Note on Enter in the year code.** Enter on an existing year code loads that year into edit mode, so the next
Save is an edit save (Lifecycle, edit path). The web has no equivalent key (Gaps 16).

## Rules

Every validation, message and focus rule the form or its helper applies. Message texts are copied from the source and
keep their spelling.

1. **Save needs edit rights for an existing year.** When `EntryMode` is `E` and `UserEdit` is not `Y`, Save shows
   "You Have No Rights....." and returns. Focus does not move.
   `MS_YEAR.cs:1147 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}}`;
   `MS_YEAR.cs:1149 {{You Have No Rights.....}}`.
2. **There is no other validation in Save.** Save does not check the year code (not blank, not a format), the dates
   (not blank, closing after opening, span) or the month. This is confirmed by reading `MS_YEAR.cs:1140-1400 {{private void BtnSave_Click(object sender, EventArgs e)}}`; no
   check exists. (Inferred from the absence of a check; the source has none.)
3. **Date entry messages (`DC_Main.SetDate`).** Typed dates are checked when Enter is pressed in the opening or
   closing field. A bad date or month is cleared to `__/__/____` and one of these messages is shown:
   `DC_Main.cs:1644 {{Date Not Valid...}}`, `DC_Main.cs:1655 {{Date Not Valid...}}`, `DC_Main.cs:1664 {{Month Not Valid...}}`,
   `DC_Main.cs:1672 {{Date Not Valid...}}`, `DC_Main.cs:1679 {{Month Not Valid...}}`. Focus: `SetDate` sets
   `RongDate` (`DC_Main.cs:1561 {{public static void SetDate(ref MaskedTextBox MsDate)}}` is the method, `DC_Main.cs:1568 {{RongDate = false;}}` clears it on entry); the field
   keeps focus because the Tab is sent only when `RongDate` is false (`MS_YEAR.cs:1107 {{if (!DC_Main.RongDate)}}`).
4. **Duplicate year in create mode: no message.** If the year code already exists in `YEAR_MAST` (a probe with no
   company predicate, see Desktop weaknesses, item 2) the form does not refuse. It skips the database restore, rewrites
   the row, and then runs the purge on the existing database (Lifecycle, create path). It shows the normal success
   message "New Year are Created...Now ReOpen Sofware..." (`MS_YEAR.cs:1388 {{Interaction.MsgBox((object)"New Year are Created...Now ReOpen Sofware...", (MsgBoxStyle)0, (object)null);}}`). The desktop has no duplicate refusal.
5. **Edit save of an existing year.** The row is rewritten, and then the form shows "Year Is Already Exist...Now
   ReOpen Sofware..." and exits the program (`MS_YEAR.cs:1394 {{Year Is Already Exist...Now ReOpen Sofware...}}`,
   `MS_YEAR.cs:1395 {{Application.Exit();}}`). The text is misleading: nothing was refused. It is the only place the text
   appears.
6. **Success messages.** First year of a new company: "All Master And Parameter are Created...Now ReOpen Sofware..."
   (`MS_YEAR.cs:1361 {{Interaction.MsgBox((object)"All Master And Parameter are Created...Now ReOpen Sofware...", (MsgBoxStyle)0,}}`). Further year (alternate-year or standard): "New Year are Created...Now ReOpen Sofware..."
   (`MS_YEAR.cs:1369 {{Interaction.MsgBox((object)"New Year are Created...Now ReOpen Sofware...", (MsgBoxStyle)0, (object)null);}}`, `MS_YEAR.cs:1388 {{Interaction.MsgBox((object)"New Year are Created...Now ReOpen Sofware...", (MsgBoxStyle)0, (object)null);}}`). After each, the program exits (`MS_YEAR.cs:1399 {{Application.Exit();}}`),
   so the operator reopens it to use the new year.
7. **Print rights message.** When `UserPrint` is not `Y`: "You Have No Print Rights....." (`MS_YEAR.cs:966 {{You Have No Print Rights.....}}`,
   guard at `MS_YEAR.cs:964 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}`).
8. **Delete rights message and confirmation.** When `UserDelete` is not `Y`: "You Have No Rights....." (`MS_YEAR.cs:978 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}}`).
   Otherwise: "Are You Sure To Delete This User now?" (`MS_YEAR.cs:980 {{else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This User now?", (MsgBoxStyle)4,}}`), and on success "Delete Success."
   (`MS_YEAR.cs:986 {{Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);}}`). See Desktop weaknesses, item 1.
9. **Import prompt for the 17-table copy.** When an old company code was chosen (`MsOldCoCode`), the copy asks
   "Import All Party from Ac Master Of <code> Compnay...?" (`MS_YEAR.cs:1512 {{Import All Party from Ac Master Of }}`).
   Yes (result 6) copies every party; No copies only the baseline parties (Lifecycle, copy step).
10. **Focus after Cancel.** Cancel moves focus to the year code (`MS_YEAR.cs:1054 {{((Control)tYearCode).Focus();}}`).
    Focus after a successful Save does not matter: the program exits.
11. **Lite edition.** No edition condition. The menu is listed `L` (`menu-editions.json:184`) and the form has no edition test.

## Calculations

No money is computed on this form. The only derivations are dates and text, applied in this order. Years are read
from the system clock with `DateAndTime.Today`. Numbers are added as doubles, and results are used as text, so there is
no rounding call.

**Standard year (not alternate, not UAE), from Cancel:**

1. Year `Y` = characters 7 to 10 of today's date (`MS_YEAR.cs:1037 {{Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4)}}`).
2. If the month is April to December (`MS_YEAR.cs:1035 {{DateAndTime.Month(DateAndTime.Today) > 3}}`): the code is
   `Y-(Y+1)`, the opening is `01/04/Y`, the closing is `31/03/(Y+1)` (`MS_YEAR.cs:1037-1039 {{tYearCode.Text = Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4) + "-" +}}`).
3. Otherwise (January to March, `MS_YEAR.cs:1041-1046 {{tYearCode.Text = Conversions.ToString(Conversions.ToDouble(Strings.Mid(Conversions.ToString(DateAndTime.Today)}}`): the code is `(Y-1)-Y`, the opening is `01/04/(Y-1)`, the
   closing is `31/03/Y` (`MS_YEAR.cs:1043 {{tYearCode.Text = Conversions.ToString(Conversions.ToDouble(}}`,
   `MS_YEAR.cs:1044 {{mOpDate.Text = "01/04/" + Strings.Mid(tYearCode.Text, 1, 4);}}`,
   `MS_YEAR.cs:1045 {{mClDate.Text = "31/03/" + Strings.Mid(tYearCode.Text, 6, 4);}}`).
4. Month is `04` (`MS_YEAR.cs:1047 {{tMonth.Text = "04";}}`).

**UAE company** (`MS_YEAR.cs:1026 {{else if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)}}`):
the code is `Y-(Y+1)` with `Y` always the current year, the opening is `01/01/Y`, the closing is `31/12/Y`, and the
month is `01` (`MS_YEAR.cs:1029 {{mOpDate.Text = "01/01/" + Strings.Mid(tYearCode.Text, 1, 4);}}`,
`MS_YEAR.cs:1030 {{mClDate.Text = "31/12/" + Strings.Mid(tYearCode.Text, 1, 4);}}`, `MS_YEAR.cs:1031 {{tMonth.Text = "01";}}`).
The UAE rule is the calendar year, and its closing date is in the same year as its opening date.

**Alternate-year company** (`DC_Main.MsAlterYear` is `Y`, `MS_YEAR.cs:1010 {{if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)}}`): the month is the current month
(`MS_YEAR.cs:1012 {{tMonth.Text = Strings.Mid(Conversions.ToString(DateAndTime.Today), 4, 2);}}`). Then:

- April to December: code `Y-(Y+1)`, opening `01/MM/Y`, closing `01/MM/(Y+1)` (`MS_YEAR.cs:1015-1017 {{tYearCode.Text = Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4) + "-" +}}`).
- January to March: code `(Y-1)-Y`, opening `01/MM/Y`, closing `01/MM/(Y+1)` with the year formatted as `"00"`
  (`MS_YEAR.cs:1021-1023 {{tYearCode.Text = Conversions.ToString(Conversions.ToDouble(Strings.Mid(Conversions.ToString(DateAndTime.Today)}}`; `MS_YEAR.cs:1023 {{Strings.Format((object)(Conversions.ToDouble(Strings.Mid(tYearCode.Text, 6, 4)) + 1.0), "00")}}`).

Note that the alternate-year closing date is the first day of the month one year later, not the last day of the
year before it. The standard closing date is the last day (`31/03`).

**Stored values, on save.** `OLD_METHOD` is `N` for alternate-year and `Y` for standard
(`MS_YEAR.cs:1197 {{dataRow["OLD_METHOD"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(}}`). `YEAR_MONTH` is the
month field (`MS_YEAR.cs:1198 {{dataRow["YEAR_MONTH"] = tMonth.Text;}}`). `OP_DATE` and `CL_DATE` are stored as the
text in the masked field, in `dd/MM/yyyy` form (`MS_YEAR.cs:1195 {{dataRow["OP_DATE"] = mOpDate.Text;}}`,
`MS_YEAR.cs:1196 {{dataRow["CL_DATE"] = mClDate.Text;}}`).

## Lifecycle and write set

### Create, first year of a new company (`NewCompCode` set)

1. **Probe.** The standard probe asks whether `YEAR_MAST` has the code, with no company predicate
   (`MS_YEAR.cs:1164 {{SELECT * FROM YEAR_MAST WHERE  CO_YEAR}}`). If no row is found, `flag` is set
   (`MS_YEAR.cs:1168 {{flag = true;}}`).
2. **Clear the key.** Both connections delete the year's key row: the master database
   (`MS_YEAR.cs:1179 {{DC_Main.ExeQuteMc("DELETE FROM YEAR_MAST WHERE CO_CODE}}`) and the data database
   (`MS_YEAR.cs:1180 {{DC_Main.ExeQuteDc("DELETE FROM YEAR_MAST WHERE CO_CODE}}`). The key is company, year and month.
3. **Insert the year row** into the master database (the row is built at `MS_YEAR.cs:1193 {{dataRow["CO_YEAR"] = tYearCode.Text;}}`,
   added at `MS_YEAR.cs:1200 {{DC_Main.Rshlp.Rows.Add(dataRow);}}`) and the same row into the data database
   (`MS_YEAR.cs:1211 {{DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);}}`, `MS_YEAR.cs:1228 {{DC_Main.Rshlp.Rows.Add(dataRow2);}}`).
   Columns written: `CO_CODE`, `CO_YEAR`, `OP_DATE`, `CL_DATE`, `OLD_METHOD`, `YEAR_MONTH`, `MAIN_USER`
   (`MS_YEAR.cs:1199 {{dataRow["MAIN_USER"] = DC_Main.MCo_User;}}`).
4. **Restore a database for the new year** (the desktop keeps one database per year). The standard branch (`MS_YEAR.cs:1287 {{flag = false;}}`
   inside `else` of the alternate test) backs up the current data database (`MS_YEAR.cs:1326 {{BACKUP DATABASE }}`), backs up the
   master database (`MS_YEAR.cs:1332 {{DC_Main.ExeQuteDc("BACKUP DATABASE " + DC_Main.SqlMain + " TO DISK ='" + text6 + ".BAK'");}}`), creates the new database (`MS_YEAR.cs:1333 {{CREATE DATABASE }}`), restores the
   previous year's backup into it (`MS_YEAR.cs:1350 {{RESTORE DATABASE }}`) and shrinks it (`MS_YEAR.cs:1352-1353 {{DC_Main.ExeQuteDc("USE [master]   DBCC SHRINKDATABASE (N'" + text4 + "', 95)");}}`).
   The alternate-year branch does the same with `Next` + year digits + month names (`MS_YEAR.cs:1239 {{".mdf";}}`
   area, backup `MS_YEAR.cs:1255 {{DC_Main.ExeQuteDc("BACKUP DATABASE " + DC_Main.SqlData + " TO DISK ='" + text + text5 + ".BAK' WITH COPY_ONLY");}}`, create `MS_YEAR.cs:1262 {{DC_Main.ExeQuteDc("CREATE DATABASE " + text4 + " ON PRIMARY(NAME = " + text4 + "_Data,FILENAME = '" + text2 +}}`, restore `MS_YEAR.cs:1279 {{DC_Main.RsQry = "USE [master] ALTER DATABASE [" + text4 + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE  RESTORE}}`, shrink `MS_YEAR.cs:1281-1282 {{DC_Main.ExeQuteDc("USE [master]   DBCC SHRINKDATABASE (N'" + text4 + "', 95)");}}`).
   This runs for a new company as well, because the restore sits in the `flag` branch and is not conditioned on
   `NewCompCode` (`MS_YEAR.cs:1233 {{if (flag)}}`).
5. **Copy the 17 baseline tables** (`NewCompParmCreat`, `MS_YEAR.cs:1357-1361 {{if (Operators.CompareString(DC_Main.NewCompCode, "", false) != 0)}}`). No `DataConYear` and no purge in this branch.
   The list, with the desktop line of each default-branch `INSERT`:

| # | Table | Default-branch insert line | Default row filter (`WHERE` after `FROM`) |
|---|---|---|---|
| 1 | AC_GROUP | 1558 | all rows of `01` |
| 2 | AC_MAST | 1560 | `LC_CODE = '00'` and `CAST(AC_CODE AS INT) < 101` |
| 3 | BAL_GR | 1562 | all rows of `01` |
| 4 | BOOK_DATA | 1564 | `LC_CODE = '00'` |
| 5 | BOOK_DETL | 1566 | `LC_CODE = '00'` |
| 6 | CO_SET | 1568 | all rows of `01` |
| 7 | CO_SET_NEW | 1570 | all rows of `01` |
| 8 | COL_MAST | 1572 | all rows of `01` |
| 9 | CONV_MAST | 1574 | all rows of `01` |
| 10 | EMP_MAST | 1576 | `EMP_CODE = '001'` |
| 11 | GROUP_MAST | 1578 | `GR_CODE IN ('916','DM','EM','FGL','FSL','GO','OG','ORD','OS','OT','SL','SN')` |
| 12 | ITEM_MAST | 1580 | `IT_CODE IN ('999','DM','EM','FSL','HM','OG','ORG','ORS','OS','OT','RD','SN')` |
| 13 | LOCT_MAST | 1582 (and 1584, master database) | `LC_CODE = '00'` |
| 14 | PRINT_MAST | 1586 | all rows of `01` |
| 15 | PRODUCT_MAST | 1588 | `PR_CODE IN ('DM','EM','FN','HM','OD','OG','OR','OS','OT','RD','SN')` |
| 16 | TABLE_MAST | 1590 | `TABLE_CODE = '001'` |
| 17 | TAX_MAST | 1592 | all rows of `01` |

   Each table is first deleted for the new company (for example `MS_YEAR.cs:1557 {{DELETE FROM AC_GROUP WHERE CO_CODE}}`),
   then copied. Source of the filters: `MS_YEAR.cs:1560 {{AND CAST(AC_CODE AS INT) < 101}}`,
   `MS_YEAR.cs:1576 {{AND EMP_CODE = '001'}}`, `MS_YEAR.cs:1582 {{AND LC_CODE = '00'}}`,
   `MS_YEAR.cs:1590 {{AND TABLE_CODE = '001'}}`, `MS_YEAR.cs:1578 {{AND GR_CODE  IN}}`,
   `MS_YEAR.cs:1580 {{AND IT_CODE  IN}}`, `MS_YEAR.cs:1588 {{AND PR_CODE  IN}}`.
   The copy writes `CO_CODE` as the new company and takes the source company `01` as the template.
   `AC_MAST` in this branch writes the literal `'N'` into `DATA_TRFR` (`MS_YEAR.cs:1560 {{AC_GST_TYPE,'N' FROM AC_MAST WHERE CO_CODE = '01'}}`).
6. **Alternative branch, "Import All Party" (`MsOldCoCode` set).** Copies the 17 tables from the chosen old company
   with the wider column list (`MS_YEAR.cs:1508 {{if (Operators.CompareString(DC_Main.MsOldCoCode, "", false) != 0)}}`).
   `MsOldCoCode` is set from the combo box on the company screen (`MS_COMPANY.cs:7295 {{DC_Main.MsOldCoCode = cboWithOldCoMast.Text;}}`).
   This branch has no row filters: it copies every row of the chosen company.
7. **Exit.** Save exits the program after a create (`MS_YEAR.cs:1399 {{Application.Exit();}}`).

### Create, further year (`NewCompCode` empty)

1. Same probe, delete and insert as above (`MS_YEAR.cs:1164 {{DC_Main.RsQry = "SELECT * FROM YEAR_MAST WHERE  CO_YEAR = '" + tYearCode.Text + "' ";}}`, `MS_YEAR.cs:1179-1180 {{DC_Main.ExeQuteMc("DELETE FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" +}}`, `MS_YEAR.cs:1200 {{DC_Main.Rshlp.Rows.Add(dataRow);}}`, `MS_YEAR.cs:1228 {{DC_Main.Rshlp.Rows.Add(dataRow2);}}`).
2. **Restore** the previous year's database as the new database (`MS_YEAR.cs:1233 {{if (flag)}}`), as described above.
   The alternate-year branch names the new database `Next` + two digits + month (`MS_YEAR.cs:1245 {{text4 = "Next" + Strings.Mid(tYearCode.Text, 3, 2) + tMonth.Text;}}`
   The standard branch uses the same pattern, `MS_YEAR.cs:1316-1322 {{text3 = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\SqlData\\Next" +}}`).
   A backup of the *current* data database is taken first, so the restored copy carries every row of the previous year.
3. **Point the session at the new database and purge.** Standard branch: `DC_Main.DataConYear();` (`MS_YEAR.cs:1386 {{DC_Main.DataConYear();}}`),
   then `DeleteOldYear_Data();` (`MS_YEAR.cs:1387 {{DeleteOldYear_Data();}}`), then the message (`MS_YEAR.cs:1388 {{Interaction.MsgBox((object)"New Year are Created...Now ReOpen Sofware...", (MsgBoxStyle)0, (object)null);}}`). Alternate-year branch:
   `MS_YEAR.cs:1366 {{DC_Main.SqlData = "Next" + Strings.Mid(tYearCode.Text, 3, 2) + tMonth.Text;}}`, `MS_YEAR.cs:1367 {{DC_Main.DataConYear();}}`,
   `MS_YEAR.cs:1368 {{DeleteOldYear_Data();}}`.
4. **The purge** (`DeleteOldYear_Data`, `MS_YEAR.cs:1403-1502 {{private void DeleteOldYear_Data()}}`). It deletes every row whose `CO_YEAR` is not the new
   year from the voucher, ledger, stock, opening and report tables. Examples with their lines:
   `MS_YEAR.cs:1405 {{DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");}}`,
   `MS_YEAR.cs:1443 {{DELETE FROM ITM_OPBL WHERE CO_YEAR <>}}`, `MS_YEAR.cs:1462 {{DELETE FROM OP_DATA WHERE CO_YEAR <>}}`.
   Some statements have no year filter at all (Desktop weaknesses, item 5). The purge does not touch the 17
   baseline tables, `YEAR_MAST`, `CO_SET`, `CO_SET_NEW` or any master: none of them appears in the statement list.
5. **Message and exit.** `MS_YEAR.cs:1388 {{Interaction.MsgBox((object)"New Year are Created...Now ReOpen Sofware...", (MsgBoxStyle)0, (object)null);}}` and `MS_YEAR.cs:1399 {{Application.Exit();}}`.

### Create, duplicate year (flag false)

When the probe finds the code, `flag` is false, so the restore is skipped (`MS_YEAR.cs:1233 {{if (flag)}}`). The row is still
rewritten (steps 2–3 above run unconditionally). The branch then runs the **standard purge on the existing database**:
`DataConYear` and `DeleteOldYear_Data` (`MS_YEAR.cs:1386-1387 {{DC_Main.DataConYear();}}`) and the success message (`MS_YEAR.cs:1388 {{Interaction.MsgBox((object)"New Year are Created...Now ReOpen Sofware...", (MsgBoxStyle)0, (object)null);}}`). This is
the silent behaviour described in Rule 4 and Desktop weaknesses, item 4.

### Edit (`EntryMode` `E`, row loaded by Display)

1. Rights check (`MS_YEAR.cs:1147-1149 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}}`).
2. Probe and delete/insert of the year row, both databases (`MS_YEAR.cs:1173-1180 {{DC_Main.ExeQuteMc("DELETE FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" +}}` and the inserts above). The date fields
   are written as they stand, so a changed closing date changes the stored year.
3. No restore, no purge, no company copy: the `else` at `MS_YEAR.cs:1391-1395 {{Year Is Already Exist...Now ReOpen Sofware...}}` runs, sets `NewYearCode` empty
   (`MS_YEAR.cs:1393 {{DC_Main.NewYearCode = "";}}`), shows "Year Is Already Exist...Now ReOpen Sofware..."
   (`MS_YEAR.cs:1394 {{Interaction.MsgBox((object)"Year Is Already Exist...Now ReOpen Sofware...", (MsgBoxStyle)0, (object)null);}}`) and exits (`MS_YEAR.cs:1395 {{Application.Exit();}}`).

### Delete (the Delete button)

The button does **not** delete a year. It runs the user-form routine, which deletes `LOGIN_MAST` and `USER_SET` rows
named after the year code (`MS_YEAR.cs:984 {{DC_Main.ExeQuteMc("DELETE FROM LOGIN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  LOGIN_NAME = '" +}}`, `MS_YEAR.cs:985 {{DC_Main.ExeQuteMc("DELETE FROM USER_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  USER_NAME = '" +}}`). See Desktop weaknesses, item 1. No `YEAR_MAST`,
`AC_*`, `OP_*` or any other year-scoped table is written by the button.

### Cancel (`BtnCancel_Click`)

Clears every text box (`MS_YEAR.cs:1000-1002 {{if (val is TextBox)}}` and `{{val.Text = "";}}`), sets the defaults in
the Calculations order, sets `EntryMode` to `A` (`MS_YEAR.cs:1049 {{EntryMode = "A";}}`), and if the code is not
empty runs Display (`MS_YEAR.cs:1050-1052 {{if (Operators.CompareString(tYearCode.Text, "", false) != 0)}}`). Focus returns to the year code (`MS_YEAR.cs:1054 {{((Control)tYearCode).Focus();}}`).

## Print

- **Templates.** None. `MS_YEAR.cs` contains no report or `.rpt` call. The only reference to the ActiveX control `Cr`
  is its designer declaration (`MS_YEAR.cs:662 {{((AxHost)Cr).OcxState}}`).
- **Rights check.** `BtnPrint_Click` (`MS_YEAR.cs:961-969 {{private void BtnPrint_Click(object sender, EventArgs e)}}`) checks `UserPrint`. If it is not `Y`, it shows
  "You Have No Print Rights....." (`MS_YEAR.cs:966 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}`). If it is `Y`, there is **no action** in the method.
- **Result.** The Print button has no effect, with or without the right. A print does not exist for a year on the
  desktop. The web has no Print button (Gaps 13).

## Rights

| Right (`C----L`, `docs/handbook/menu-catalog.jsonl`) | Desktop check | Message | Source |
|---|---|---|---|
| Create | None in code. The Save rights check tests edit only (`EntryMode` `E`). | None | `MS_YEAR.cs:1147 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}}` |
| Read (list) | Load reads the operator's row in `USER_SET`. | None | `MS_YEAR.cs:774 {{DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" +}}` |
| Edit | Save of an existing year (`EntryMode` `E`) requires `FRM_EDIT` = `Y`. | "You Have No Rights....." | `MS_YEAR.cs:779 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));}}`, `MS_YEAR.cs:1147-1149 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}}` |
| Delete | Delete button requires `FRM_DELETE` = `Y`. | "You Have No Rights....." | `MS_YEAR.cs:780 {{UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));}}`, `MS_YEAR.cs:976-978 {{if (Operators.CompareString(UserDelete, "Y", false) != 0)}}` |
| Print | Print button requires `FRM_PRINT` = `Y`. | "You Have No Print Rights....." | `MS_YEAR.cs:781 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}`, `MS_YEAR.cs:964-966 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}` |
| List | Not checked on this form. | None | (none) |

**Web rights.** The web rights are route-based. `web/apps/api/src/modules/rbac/routePolicy.ts:918 {{route('Masters/Year Create', ['GET /years', 'POST /years', 'POST /years/carry-forward']);}}`.
Both writes use the `create` action (`web/apps/api/src/routes/txn.ts:6357 {{if (!guard(req, reply, 'create')) return;}}` and
`web/apps/api/src/routes/txn.ts:6379 {{if (!guard(req, reply, 'create')) return;}}`). The guard returns a generic 403
body with the action name (`web/apps/api/src/routes/txn.ts:927 {{reply.code(403).send({ error: 'forbidden', action });}}`).
There is no edit, delete or print right on the web, because the web has no such action on this page.

## Desktop weaknesses not to port

1. **Delete runs the user-form routine.** The button asks "Are You Sure To Delete This User now?" (`MS_YEAR.cs:980 {{else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This User now?", (MsgBoxStyle)4,}}`),
   then deletes `LOGIN_MAST` and `USER_SET` rows by the year code (`MS_YEAR.cs:984 {{DELETE FROM LOGIN_MAST WHERE CO_CODE}}`,
   `MS_YEAR.cs:985 {{DELETE FROM USER_SET WHERE CO_CODE}}`). It deletes a user, not a year. Do not port.
2. **Existence probe has no company predicate.** `MS_YEAR.cs:1164 {{SELECT * FROM YEAR_MAST WHERE  CO_YEAR}}` finds a
   year of any company. A new company that reuses another company's year code therefore skips the restore (flag false).
3. **Silent overwrite of the year row.** Both databases delete the key row and insert a new one, in either mode
   (`MS_YEAR.cs:1173-1180 {{DC_Main.ExeQuteMc("DELETE FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" +}}`), with no check for a duplicate.
4. **Duplicate create purges the existing database.** When the probe finds a row, the restore is skipped but the purge still
   runs on the existing database (`MS_YEAR.cs:1233 {{if (flag)}}`, `MS_YEAR.cs:1386-1387 {{DC_Main.DataConYear();}}`).
5. **Unscoped and string-built purge.** The purge is built by joining strings (`MS_YEAR.cs:1405 {{DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");}}`).
   `MS_YEAR.cs:1412 {{DC_Main.ExeQuteDc("DELETE FROM BANK_RECONCILE");}}` has no `WHERE` at all.
6. **Purge removes other companies' users.** `MS_YEAR.cs:1498 {{DELETE FROM USER_DATA WHERE CO_CODE <>}}` removes every
   company's users from the copied database except the current company's.
7. **Plaintext credentials in a connection string built inline.** `MS_YEAR.cs:1265 {{Password=" + DC_Main.SqlPwd}}` and the
   same at `MS_YEAR.cs:1336 {{DC_Main.Dc.ConnectionString = ("Data Source=" + DC_Main.SqlServer + ";Initial Catalog=master;Persist Security}}`. Do not copy this pattern.
8. **Statements are not in one transaction.** `DC_Main.cs:1300 {{public static void ExeQuteMc(string Sql)}}` opens and
   closes its connection around each statement, so a failure midway leaves earlier statements committed (inferred from
   the open/close pattern; the Save makes about 100 such calls with no wrapping transaction).
9. **No create right.** Create is not checked; only edit is (`MS_YEAR.cs:1147 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}}`).
10. **No blank-code refusal.** Save does not refuse a blank year code (Rules, item 2); inferred.
11. **Restore copies everything first.** The restore copies the whole previous database, including all other data,
    before the purge removes it (`MS_YEAR.cs:1255 {{DC_Main.ExeQuteDc("BACKUP DATABASE " + DC_Main.SqlData + " TO DISK ='" + text + text5 + ".BAK' WITH COPY_ONLY");}}`, `MS_YEAR.cs:1326 {{DC_Main.ExeQuteDc("BACKUP DATABASE " + DC_Main.SqlData + " TO DISK ='" + text + text5 + ".BAK' WITH COPY_ONLY");}}`).

## Web today

| File | Lines | What it does now |
|---|---|---|
| `web/apps/web/app/(app)/masters/year-create/page.tsx` | 238 | Page `/masters/year-create`. Year code field (`placeholder="e.g. 2027-2028"`, line 87), start month (line 92), opening and closing date inputs (lines 106, 115), a live preview from `fiscalYearDates` (lines 145-147), a **Create Year** button (line 140) that posts to `/years` (line 128), and the list of years from `GET /years` (line 39). A **Carry Forward** panel (lines 195-227) posts to `/years/carry-forward`. |
| `web/apps/api/src/modules/masters/year.ts` | 172 | `listYears` (line 30); `resolveYearDates` (line 52); `createYear` (line 63): required code (line 76), length 9 (line 77), duplicate refusal (line 86), first-year detection (line 87), `YEAR_MAST` insert (line 91), clone when first year and not the template (lines 106-107); `carryForwardOpenings` (line 119). |
| `web/apps/api/src/modules/masters/companyClone.ts` | 531 | The 19 tables and their column lists (lines 23-457), template `01` (line 458), `cloneCompanyTx` (line 475) that skips a table already holding rows (line 506) and copies with `INSERT ... SELECT` (line 513). |
| `web/packages/core/src/fiscalYear.ts` | 67 (used) | `fiscalYearDates` (line 32): consecutive years (line 37), start month 1 to 12 (line 41), default opening (line 50), default closing one year minus one day (line 58), closing after opening (line 65). |
| `web/apps/api/src/routes/txn.ts` | 6352-6395 | `GET /years` (line 6352), `POST /years` with the `create` guard (lines 6356-6357), `POST /years/carry-forward` (line 6378-6379). |
| `web/apps/api/src/modules/rbac/routePolicy.ts` | 918 | Route policy for the menu. |
| `web/packages/core/src/editionTable.ts` | 58, 359 | Lite edition for the page and the menu. |
| `web/apps/web/lib/nav.ts` | 56 | Navigation entry `Year Create`. |
| `web/apps/api/test/masterSaveFidelity.db.test.ts` | 169-221 | Tests `createYear`, the duplicate refusal (line 220-221 `{{/already exists/}}`) and the year-code checks. |
| `web/apps/api/test/companySettings.db.test.ts` | 154, 198, 243, 256 | Tests `createYear` and `cloneCompany` on the isolated database. |

The web has no Print, no Delete, no year edit and no list of companies. The web's Year Create page never changes an
existing year's dates.

## Gaps

Each item says what the desktop does (cited), what the web does (file and line), and the classification. Classes:
**real work** (missing or wrong), **done on the web** (already matches), **not applicable** (a single-database web does not
need it; reason given), and **decision** (the owner must choose before work starts).

1. **Row selection of the 17-table copy (wrong result, real work).** Desktop copies only the selected rows listed in the
   Lifecycle table (for example `AC_CODE < 101` and `LC_CODE = '00'`, `MS_YEAR.cs:1560 {{DC_Main.ExeQuteDc("INSERT INTO AC_MAST (CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_GST_TYPE,}}`). The web copies every row of
   `01` for every table (`web/apps/api/src/modules/masters/companyClone.ts:513 {{WHERE tenant_id=$1 AND "CO_CODE"=$3}}`
   with no further filter). Result: the new company gets every baseline master, not the baseline set.
2. **Column sets and values (wrong result, real work).** Desktop's default branch writes a narrow column list for `AC_MAST`
   (nine columns, `MS_YEAR.cs:1560 {{DC_Main.ExeQuteDc("INSERT INTO AC_MAST (CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_GST_TYPE,}}`) and sets `DATA_TRFR` to `'N'`. The web's `AC_MAST` list has 26 columns, including
   the address, contact, GST and PAN fields (`web/apps/api/src/modules/masters/companyClone.ts:178 {{'AC_PERSON',}}` and the lines
   after it), and copies `DATA_TRFR` from the source (`web/apps/api/src/modules/masters/companyClone.ts:177 {{'DATA_TRFR',}}`). Extra columns also appear for
   `EMP_MAST` (desktop 8, web 12: `TDS_PRC`, `TDS_AMT`, `PF_PRC`, `PF_AMT`, `DAY_HOURS`), `GROUP_MAST` (`RATE_DISPLAY`,
   `DATA_TRFR`) and `BOOK_DATA` (`USER_EMP_CODE`, `WITH_MOBILE_ENTRY`, `MENU_NAME`, `BOOK_TBL_NAME`, `BOOK_TBL_DETL`).
   Do not print the values; the point is that the web copies personal and tax fields the desktop does not copy.
3. **Two tables the desktop never copies (wrong result, real work).** `AC_MAST_SRNO` (`web/apps/api/src/modules/masters/companyClone.ts:218 {{table: 'AC_MAST_SRNO',}}`) and
   `BANK_RECONCILE` (`web/apps/api/src/modules/masters/companyClone.ts:227 {{table: 'BANK_RECONCILE',}}`) are cloned by the web. The desktop's copy list has neither. The desktop's
   purge deletes `BANK_RECONCILE` (`MS_YEAR.cs:1412 {{DC_Main.ExeQuteDc("DELETE FROM BANK_RECONCILE");}}`). The web's comment for `BANK_RECONCILE` gives a reason
   (cloned "so a new company starts with the template's reconciliation state"), but that reason is not in the desktop.
4. **`BOOK_DETL` listed twice (minor, real work).** `web/apps/api/src/modules/masters/companyClone.ts:238 {{table: 'BOOK_DETL',}}` and `web/apps/api/src/modules/masters/companyClone.ts:284 {{table: 'BOOK_DETL',}}` are both `BOOK_DETL`
   with different line references (1531 and 1527). In the default (non-replace) mode the second entry is skipped because
   the first has written rows; the entry is dead code.
5. **"Import All Party" from another company (missing feature, decision).** Desktop offers it (`MS_YEAR.cs:1512 {{if ((int)Interaction.MsgBox((object)("Import All Party from Ac Master Of " + DC_Main.MsOldCoCode + "}}`) and
   takes the source from the company screen (`MS_COMPANY.cs:7295 {{DC_Main.MsOldCoCode = cboWithOldCoMast.Text;}}`). The web has no equivalent: `cloneCompanyTx` takes
   `sourceCoCode` only through its options (`web/apps/api/src/modules/masters/companyClone.ts:475 {{export async function cloneCompanyTx(}}`), and the page offers no choice. Decision: whether the
   web needs it on this page or on the company screen (another study).
6. **Duplicate year (wrong text and wrong result, decision).** Desktop: no refusal, no message; it overwrites the row and purges
   the existing database (Rules 4, Lifecycle, Desktop weaknesses 3–4). Web: refuses with `year ${coYear} already exists`
   (`web/apps/api/src/modules/masters/year.ts:86 {{if (ex[0]?.n > 0) throw new YearValidationError(`year ${coYear} already exists`);}}`). The web behaviour is the safer one and should stay. The desktop text
   "Year Is Already Exist" belongs to the edit path (Rule 5). Decision: whether the web uses that text for a duplicate create.
7. **Year-code length (wrong result, decision).** Desktop field max length is 15 (`MS_YEAR.cs:680 {{((TextBoxBase)tYearCode).MaxLength = 15;}}`); the web refuses codes
   over 9 characters (`web/apps/api/src/modules/masters/year.ts:77 {{year code is at most 9 characters}}`). Nine characters is the normal `yyyy-yyyy` length,
   which the desktop's alternate-year restore also tests for (`MS_YEAR.cs:1243 {{if (Strings.Len(DC_Main.MCo_year) == 9)}}`). Decision: keep 9.
8. **Year-code format (web-only rule, not desktop behaviour, decision).** The web requires `yyyy-yyyy` with consecutive
   years (`web/packages/core/src/fiscalYear.ts:37 {{must span consecutive years}}`). The desktop has no such check
   (Rule 2). Keep it, and record it as a web rule.
9. **Closing-date default (wrong result for alternate-year companies, real work only if that branch is in scope).**
   Standard: the web's default closing is one year minus one day (`web/packages/core/src/fiscalYear.ts:58 {{Date.UTC(opening.getUTCFullYear() + 1, opening.getUTCMonth(), opening.getUTCDate() - 1),}}`), which equals the desktop's `31/03`
   for an April start. Alternate-year desktop default is the first day of the month one year later
   (`MS_YEAR.cs:1017 {{mClDate.Text = "01/" + tMonth.Text + "/" + Strings.Mid(tYearCode.Text, 6, 4);}}`). The web has no alternate-year default.
10. **UAE calendar year (missing feature, decision).** Desktop UAE rule (`MS_YEAR.cs:1026-1031 {{else if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)}}`) uses January to December
   of the current year. The web has no UAE rule. Decision: whether UAE is a target company type.
11. **Alternate-year branch (missing feature, decision).** The desktop keys the year as the first four characters of the
   code plus the month (`MS_YEAR.cs:1189 {{dataRow["CO_YEAR"] = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;}}`),
   keeps one database per month (`MS_YEAR.cs:1239 {{string text2 = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\SqlData\\Next" +}}`), and sets the month from the open date (`MS_YEAR.cs:1111 {{tMonth.Text = Strings.Mid(mOpDate.Text, 4, 2);}}`). The web keeps
   `CO_YEAR` as typed (`web/apps/api/src/modules/masters/year.ts:91 {{`INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE","YEAR_MONTH","OLD_METHOD","MAIN_USER")}}`) and has one database. The web stores the company flag (`web/packages/db/prisma/schema.prisma:1362 {{ALTER_YEAR     String? @db.VarChar(1)}}`),
   but no year logic reads it: the only other mention is in `generated-formfields.ts`. Result: an alternate-year company
   cannot be set up on the web.
12. **Per-year database restore and purge (not applicable to a single-database web, with a consequence).** The desktop
   copies the previous year's whole database and purges it (Lifecycle). A single-database web needs neither, because each row
   carries `CO_YEAR`. **Operator-visible result on the desktop:** the new year starts with the previous year's masters and
   settings, no vouchers, no party or item openings (`AC_DATA`, `OP_DATA`, `ITM_OPBL` are purged), and no stock. The web's new
   year also starts with no openings: `createYear` writes only `YEAR_MAST` and clones only for the first year (`web/apps/api/src/modules/masters/year.ts:91 {{`INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE","YEAR_MONTH","OLD_METHOD","MAIN_USER")}}`, `web/apps/api/src/modules/masters/year.ts:106-107 {{if (firstYear && scope.coCode !== CLONE_TEMPLATE_CO_CODE)}}`).
   **Consequence to tell the owner:** on the desktop each year has its own copy of masters, so editing a master in year 2 does not
   change year 1. On the web masters are shared by all years of a company. This is not a bug to fix here; it is a difference the
   operator will see.
13. **Print (not applicable).** The desktop Print button prints nothing (Print section). The web has no Print button on this
   page. Done (nothing to match), but the rights message is also absent (item 15).
14. **Delete (not applicable, do not port).** The desktop button deletes a user (Desktop weaknesses, item 1). The web has no delete. Done.
15. **Rights messages (wrong text, decision).** The desktop shows "You Have No Rights....." and "You Have No Print Rights.....".
   The web returns `{ error: 'forbidden', action }` (`web/apps/api/src/routes/txn.ts:927 {{reply.code(403).send({ error: 'forbidden', action });}}`). Real work only if the owner wants the desktop texts.
16. **Edit of an existing year (missing feature, decision).** The desktop loads an existing year on Enter in the code
   (`MS_YEAR.cs:1085 {{DISPLAY_DATA();}}`) and rewrites its dates on Save (Lifecycle, edit path). The web lists years (`web/apps/web/app/(app)/masters/year-create/page.tsx:39 {{setYears(await get<Year[]>('/years'));}}`) but cannot
   change them. The earlier removal of year close and reopen (N90) does not cover a date change, because a date change is not a flag. Decision: whether the owner wants it.
17. **Keyboard flow (missing keys, real work).** The desktop keys are Enter to move, Enter on the code to load a year, Esc to close,
   upper-case entry and the apostrophe block (Keyboard table). The web page has none of these. Real work if the keyboard flow is in scope.
18. **Date validation messages (wrong text, decision).** Desktop masks the date fields and shows "Date Not Valid..." and
   "Month Not Valid..." (`DC_Main.cs:1644 {{Interaction.MsgBox((object)"Date Not Valid...", (MsgBoxStyle)0, (object)null);}}`, `DC_Main.cs:1664 {{Interaction.MsgBox((object)"Month Not Valid...", (MsgBoxStyle)0, (object)null);}}`). The web uses HTML date inputs (`web/apps/web/app/(app)/masters/year-create/page.tsx:106 {{type="date"}}`, `web/apps/web/app/(app)/masters/year-create/page.tsx:115 {{type="date"}}`) and
   its own messages (`web/packages/core/src/fiscalYear.ts:52 {{if (!isIsoDay(opDate)) return { error: `opening date ${opDate} is not a valid date` };}}`, `web/packages/core/src/fiscalYear.ts:63 {{if (!isIsoDay(clDate)) return { error: `closing date ${clDate} is not a valid date` };}}`, `web/packages/core/src/fiscalYear.ts:65 {{return { error: `closing date ${clDate} must be after opening date ${opDate}` };}}`). Decision: which texts to use.
19. **Carry-forward panel (not part of this menu).** It belongs to Balance TrFr. `MS_YEAR.cs` has no carry-forward code.
    Done as a separate web feature; out of scope for this study.
20. **Lite edition (done on the web).** The desktop shows the menu in Lite with no edition test; the web lists the page and the menu as `L`
    (`web/packages/core/src/editionTable.ts:58 {{'/masters/year-create': 'L',}}`, `web/packages/core/src/editionTable.ts:359 {{'Masters/Year Create': 'L',}}`). Matches.

## Open questions

1. **Which database receives the 17-table copy after a new-company save?** The `NewCompCode` branch does not call
   `DataConYear` (`MS_YEAR.cs:1357-1361 {{if (Operators.CompareString(DC_Main.NewCompCode, "", false) != 0)}}`), but the restore before it has already created a new database. The source does
   not show which database the session holds when the copy runs, nor whether the session reopens onto the new database.
   (Inferred: the copy uses the connection already open.)
2. **Is the alternate-year company type in the target business?** The flag exists (`web/packages/db/prisma/schema.prisma:1362 {{ALTER_YEAR     String? @db.VarChar(1)}}`), but no year logic reads it.
   Owner decision (Gap 11).
3. **Is UAE a target company type?** Owner decision (Gap 10).
4. **Keep the web's copy-everything, or the desktop's row selection?** The desktop business result is the row selection (Gap 1). The web's
   copy is a deliberate choice in its comment ("cloning is non-destructive by default"). Owner decision.
5. **Duplicate-create text.** Desktop has none; web refuses. Owner decision (Gap 6).
6. **`csharp_nextdm` variant.** `unified/src/csharp_nextdm/` exists, but no `MS_YEAR` file was found in it. The edition-sensitive comparison
   for this form is therefore not possible from that folder. Whether another copy of this form exists elsewhere is not established here.
