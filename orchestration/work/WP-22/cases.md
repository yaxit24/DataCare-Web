# WP-22 cases: Company → Year Create (desktop `MS_YEAR`), module `year-create`

Frozen case list written from `orchestration/work/WP-22/study.md` (gaps 1 to 20) and the eighteen case kinds in
`docs/master-parity-plan-2026-09-29/04-verification-playbook.md` section 3 (T01 to T18). Each case names the gap it
proves. Desktop citations use the form `FILE:LINE {{quoted text}}`; the quote is copied from the desktop file in
`unified/src/csharp/DataCareNext/`. Web citations give the path from the repository root.

Conventions used by every case:

- "Today" means the web as it stands in this worktree. A case marked "fails today" is expected to fail until its gap is
  closed; a failing run is a finding and the case stays as written. The "passes today" and "fails today" statements in
  this document were read from the web code and the study, not run against a database or browser. The executing worker
  must confirm them when the case runs.
- Expected values come from the desktop rule. Where the desktop has no rule (for example a blank year code), the case
  says so, names the web's current refusal, and lists the decision under "Not covered".
- Test dates are fixed by setting the clock of the test (the desktop reads `DateAndTime.Today`). Two clock values are used:
  **16 November 2026** (April to December branch) and **15 February 2027** (January to March branch).
- Company codes are two characters. Every case that creates a company uses a company code that does not yet exist in
  the test tenant, so the first-year copy runs.

---

## Entry and defaults (T01)

### year-create.entry.default-apr-dec   (T01 Entry/defaults)
Layer: browser
Steps: 1. Set the clock to 16 November 2026. 2. Open Company → Year Create for a company that is not alternate-year.
3. Read the year code, start month, opening date and closing date fields without typing.
Expected: year code `2026-2027`; opening date `01/04/2026`; closing date `31/03/2027`; start month `04`.
Desktop: the year is the current year `Y`, the code is `Y-(Y+1)`, the opening is `01/04/Y` and the closing is `31/03/(Y+1)`
(`MS_YEAR.cs:1037 {{tYearCode.Text = Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4) + "-" +}}`;
`MS_YEAR.cs:1038 {{mOpDate.Text = "01/04/" + Strings.Mid(tYearCode.Text, 1, 4);}}`;
`MS_YEAR.cs:1039 {{mClDate.Text = "31/03/" + Strings.Mid(tYearCode.Text, 6, 4);}}`;
`MS_YEAR.cs:1047 {{tMonth.Text = "04";}}`). Arithmetic: month 11 is above 3, so Y = 2026 and the code is 2026-2027.
Status: executable

### year-create.entry.default-jan-mar   (T01 Entry/defaults)
Layer: browser
Steps: 1. Set the clock to 15 February 2027. 2. Open Year Create for a company that is not alternate-year.
3. Read the four default fields.
Expected: year code `2026-2027`; opening date `01/04/2026`; closing date `31/03/2027`; start month `04`.
Desktop: January to March gives the code `(Y-1)-Y` with Y = 2027, so the code is 2026-2027. The opening is `01/04/(Y-1)` = 01/04/2026
and the closing is `31/03/Y` = 31/03/2027 (`MS_YEAR.cs:1043 {{tYearCode.Text = Conversions.ToString(Conversions.ToDouble(}}`;
`MS_YEAR.cs:1044 {{mOpDate.Text = "01/04/" + Strings.Mid(tYearCode.Text, 1, 4);}}`;
`MS_YEAR.cs:1045 {{mClDate.Text = "31/03/" + Strings.Mid(tYearCode.Text, 6, 4);}}`).
Status: executable

### year-create.entry.cancel-resets-defaults   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open Year Create with the clock at 16 November 2026. 2. Type `FY2030`, change the opening date to `01/07/2030`,
press Cancel. 3. Read the fields and note where focus is.
Expected: the year code is `2026-2027`, the opening date `01/04/2026`, the closing date `31/03/2027`, the start month `04`,
and focus is on the year code. Desktop: Cancel clears every text box, sets the defaults and returns focus to the year code
(`MS_YEAR.cs:1054 {{((Control)tYearCode).Focus();}}`; `MS_YEAR.cs:1049 {{EntryMode = "A";}}`).
Status: executable

### year-create.entry.focus-on-year-code   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open Company → Year Create. 2. Without clicking, type `2026-2027`.
Expected: the characters go into the year code field, so the field has focus when the screen opens. Desktop: load sets
the current control to the year code (`MS_YEAR.cs:895 {{CurActCtrl = (Control)(object)tYearCode;}}`).
Status: executable

### year-create.entry.lite-menu-visible   (T01 Entry/defaults)
Layer: browser
Steps: 1. Sign in to a Lite company. 2. Open the Company menu and look for Year Create.
Expected: the menu item Year Create is listed and opens the page. Desktop: the menu is listed as Lite and the form has no edition test
(`docs/handbook/menu-editions.json:184 {{"edition": "L",}}`; `MDI_FORM.cs:7421 {{case "Year Create":}}`).
Web (already matches, gap 20): `web/packages/core/src/editionTable.ts:58 {{'/masters/year-create': 'L',}}`.
Status: executable

### year-create.entry.uae-default   (T01 Entry/defaults)
Layer: browser
Status: N/A: the UAE calendar rule (gap 10) is out of scope; the Lite edition here is the India build. The desktop rule is
`MS_YEAR.cs:1026 {{else if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)}}`. Decision recorded in "Not covered".

---

## Field route (T02)

### year-create.field.year-code-route   (T02 Field route)
Layer: database
Steps: 1. Create company `04` (first year) with year code `2026-2027`, opening `01/04/2026`, closing `31/03/2027`, start month `04`.
2. Query `YEAR_MAST` for company `04`.
Expected: one row with `CO_YEAR` = `2026-2027` (the code exactly as typed). Desktop: a standard company stores the typed code
(`MS_YEAR.cs:1193 {{dataRow["CO_YEAR"] = tYearCode.Text;}}`).
Status: executable

### year-create.field.closing-date-route   (T02 Field route)
Layer: database
Steps: 1. Create company `04`'s first year as in the previous case. 2. Query the closing date of the row.
Expected: the closing date is 31 March 2027 (the calendar day `2027-03-31`). Desktop: the closing text is saved from the
closing field (`MS_YEAR.cs:1196 {{dataRow["CL_DATE"] = mClDate.Text;}}`).
Status: executable

### year-create.field.opening-date-stored-format   (T02 Field route)
Layer: database
Steps: 1. Create company `04`'s first year with opening `01/04/2026`. 2. Query `OP_DATE` of the row.
Expected: the value is the desktop text `01/04/2026`. Desktop: the opening text is saved as typed in the masked field
(`MS_YEAR.cs:1195 {{dataRow["OP_DATE"] = mOpDate.Text;}}`).
Web today stores `2026-04-01` (`web/apps/api/src/modules/masters/year.ts:91 {{INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE"}}`).
Status: blocked: decision. The storage format of `OP_DATE` is not one of the study's 20 gaps. The owner must decide whether
the web keeps ISO text (other screens read it) or writes the desktop text. Unblocked by that decision; then the expected value above applies.

---

## Lookup (T04)

### year-create.lookup.enter-loads-existing-year   (T04 Lookup)
Layer: browser
Steps: 1. Create year `2026-2027` for company `04`. 2. Reopen Year Create. 3. Type `2026-2027` in the year code and press Enter.
4. Read the dates and the screen's mode.
Expected: the dates `01/04/2026` and `31/03/2027` and the start month `04` are loaded from the stored row, and the next Save is an edit save.
Desktop: Enter in the year code loads the year when the code is not empty (`MS_YEAR.cs:1083 {{if ((int)e.KeyCode == 13 && Operators.CompareString(tYearCode.Text, "", false) != 0)}}`;
`MS_YEAR.cs:1085 {{DISPLAY_DATA();}}`). The web has no equivalent (gap 16).
Status: blocked: owner decision (gap 16). The owner must decide whether the web lets a user open and change an existing year. Unblocked by that decision.

---

## Validation (T06)

### year-create.validate.year-code-blank-refused   (T06 Required/invalid)
Layer: database
Steps: 1. Call `POST /years` for company `04` with an empty `coYear`. 2. Query `YEAR_MAST` and `AC_GROUP` for company `04`.
Expected: refused with the message `coYear is required`; no `YEAR_MAST` row and no copied row. Desktop: no check exists in Save
(`MS_YEAR.cs:1140 {{private void BtnSave_Click(object sender, EventArgs e)}}`; study Rule 2, inferred). Web current text kept:
`web/apps/api/src/modules/masters/year.ts:76 {{coYear is required}}`. The desktop has no refusal, so this case keeps the web refusal
and is listed under "Not covered".
Status: executable

### year-create.validate.year-code-12-chars-accepted   (T06 Required/invalid, gap 7)
Layer: browser
Steps: 1. Create company `04` with year code `2026-2027-AB` (12 characters), opening `01/04/2026`, closing `31/03/2027`.
2. Query the stored code.
Expected: accepted; stored `CO_YEAR` = `2026-2027-AB`. Desktop: the field accepts up to 15 characters
(`MS_YEAR.cs:680 {{((TextBoxBase)tYearCode).MaxLength = 15;}}`), and Save has no length check (`MS_YEAR.cs:1140 {{private void BtnSave_Click(object sender, EventArgs e)}}`).
Today: fails. The web refuses codes over nine characters: `web/apps/api/src/modules/masters/year.ts:77 {{year code is at most 9 characters}}`.
Status: blocked: storing the desktop's year code needs the CO_YEAR columns widened in about 100 tables and the web's yyyy-yyyy rule dropped; that is a schema change for its own work package and an owner decision (supervisor, 16 November 2026). Was: executable (fails today: gap 7)

### year-create.validate.year-code-stops-at-15   (T06 Required/invalid, gap 7)
Layer: browser
Steps: 1. In the year code field type `ABCDEFGHIJKLMNOP` (16 characters). 2. Read the field and the stored code after Save.
Expected: the field holds `ABCDEFGHIJKLMNO` (15 characters) and the stored code is the same 15 characters. Desktop: the control stops at 15
characters (`MS_YEAR.cs:680 {{MaxLength = 15;}}`). The letters are upper-cased (`MS_YEAR.cs:942 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}`).
Today: fails (the web refuses at nine characters and does not cap the input).
Status: blocked: storing the desktop's year code needs the CO_YEAR columns widened in about 100 tables and the web's yyyy-yyyy rule dropped; that is a schema change for its own work package and an owner decision (supervisor, 16 November 2026). Was: executable (fails today: gap 7)

### year-create.validate.year-code-any-text-accepted   (T06 Required/invalid, gap 8)
Layer: browser
Steps: 1. Create company `04` with year code `FY2027`, opening `01/04/2026`, closing `31/03/2027`. 2. Query the stored code.
Expected: accepted; stored `CO_YEAR` = `FY2027` (upper case, as typed). Desktop: the code is not checked for a form (no check in Save,
`MS_YEAR.cs:1140 {{private void BtnSave_Click(object sender, EventArgs e)}}`). Today the web refuses with
`web/packages/core/src/fiscalYear.ts:37 {{must span consecutive years}}`.
Status: blocked: storing the desktop's year code needs the CO_YEAR columns widened in about 100 tables and the web's yyyy-yyyy rule dropped; that is a schema change for its own work package and an owner decision (supervisor, 16 November 2026). Was: executable (fails today: gap 8)

### year-create.validate.closing-before-opening-refused   (T06 Required/invalid)
Layer: browser
Steps: 1. Create company `04` with opening `01/04/2026` and closing `31/03/2026`. 2. Press Save.
Expected: refused with the message `closing date 2026-03-31 must be after opening date 2026-04-01`; no row is written.
Desktop: no check (Rule 2). The web's refusal is kept as a data-protection rule and is listed under "Not covered".
Web text: `web/packages/core/src/fiscalYear.ts:65 {{must be after opening date}}`.
Status: executable

### year-create.validate.duplicate-year-refused   (T06 Required/invalid, gap 6)
Layer: browser
Steps: 1. Create company `04`'s year `2026-2027`. 2. Open Year Create again, enter the same code and the same dates, press Save.
3. Count `YEAR_MAST` rows for company `04` and copied rows in `AC_GROUP`.
Expected: refused with the message `year 2026-2027 already exists`; the row count stays 1; no copied row is added or changed.
Desktop: a duplicate create has no refusal. It overwrites the row and purges the existing database (`MS_YEAR.cs:1388 {{New Year are Created...Now ReOpen Sofware...}}`,
study Rule 4 and Desktop weakness 3–4). That behaviour is destructive and is not ported. The web refusal is kept; the wording is the web's, because the desktop has no duplicate-create text.
Web text: `web/apps/api/src/modules/masters/year.ts:86 {{already exists}}`.
Status: executable

### year-create.validate.date-day-invalid-desktop-text   (T06 Required/invalid, gap 18)
Layer: browser
Steps: 1. Open Year Create. 2. In the opening date type `32/04/2026`, press Enter.
Expected: the message `Date Not Valid...`; the field is reset to `__/__/____`; the text is selected; focus stays in the opening date.
Desktop: the day above 31 shows the message, clears the field and selects the text (`DC_Main.cs:1669 {{if (Conversion.Val(Strings.Mid(MsDate.Text, 1, 2)) > 31.0)}}`,
`DC_Main.cs:1672 {{Interaction.MsgBox((object)"Date Not Valid...", (MsgBoxStyle)0, (object)null);}}`, `DC_Main.cs:1673 {{MsDate.Text = "__/__/____";}}`).
Focus stays because the Tab is sent only when the date is valid (`MS_YEAR.cs:1107 {{if (!DC_Main.RongDate)}}`).
Today: fails (the web uses `type="date"` fields and its own text, `web/apps/web/app/(app)/masters/year-create/page.tsx:106 {{type="date"}}`).
Status: executable (fails today: gap 18)

### year-create.validate.month-invalid-desktop-text   (T06 Required/invalid, gap 18)
Layer: browser
Steps: 1. Open Year Create. 2. In the opening date type `15/13/2026`, press Enter.
Expected: the message `Month Not Valid...`; the field is reset to `__/__/____`; focus stays in the opening date.
Desktop: a month above 12 shows the month message (`DC_Main.cs:1661 {{else if (num2 > 12.0)}}`, `DC_Main.cs:1664 {{Interaction.MsgBox((object)"Month Not Valid...", (MsgBoxStyle)0, (object)null);}}`).
Today: fails (the web's text differs, see gap 18).
Status: executable (fails today: gap 18)

---

## Create footprint (T07)

### year-create.create.first-year-footprint   (T07 Create)
Layer: database
Steps: 1. Save company `04` with year `2026-2027`, opening `01/04/2026`, closing `31/03/2027`, start month `04`, operator `op1`.
2. Query `YEAR_MAST` and the 17 baseline tables for company `04`.
Expected: one `YEAR_MAST` row for company `04` with `CO_YEAR` `2026-2027`, `CL_DATE` `2027-03-31`, `OLD_METHOD` `Y`,
`YEAR_MONTH` `04`, `MAIN_USER` `op1`. The copied rows are those in the copy cases below.
Desktop: `MS_YEAR.cs:1196 {{dataRow["CL_DATE"] = mClDate.Text;}}`, `MS_YEAR.cs:1197 {{dataRow["OLD_METHOD"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(}}`
with `MS_YEAR.cs:1197 {{(object)"N", (object)"Y"}}` (the standard branch writes `Y`), `MS_YEAR.cs:1198 {{dataRow["YEAR_MONTH"] = tMonth.Text;}}`,
`MS_YEAR.cs:1199 {{dataRow["MAIN_USER"] = DC_Main.MCo_User;}}`.
Status: executable

### year-create.create.further-year-no-copy   (T07 Create)
Layer: database
Steps: 1. Company `04` has its first year `2026-2027` with the baseline copied. 2. Create `2027-2028` for company `04`.
3. Count rows in the 17 baseline tables for company `04` before and after.
Expected: the 17 counts do not change; one new `YEAR_MAST` row for `2027-2028`. Desktop: the copy runs only when `NewCompCode` is set
(`MS_YEAR.cs:1357 {{if (Operators.CompareString(DC_Main.NewCompCode, "", false) != 0)}}`), so a further year copies nothing.
Status: executable

### year-create.create.footprint-no-vouchers   (T07 Create)
Layer: database
Steps: 1. Create company `04` (first year). 2. Count rows in `AC_DATA`, `OP_DATA`, `ITM_OPBL` and `BAL_GR` for company `04`.
Expected: zero rows in `AC_DATA`, `OP_DATA` and `ITM_OPBL` (no voucher, no opening). `BAL_GR` has its copied rows (see the copy cases).
Desktop: the first-year branch (`MS_YEAR.cs:1357 {{if (Operators.CompareString(DC_Main.NewCompCode, "", false) != 0)}}`) runs the 17 copy statements and no voucher or opening statement.
The purge that deletes voucher rows (`MS_YEAR.cs:1405 {{DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_YEAR <> '"}}`) runs only for a further year (study, Lifecycle, further-year step 3), so it is not part of this footprint.
Status: executable

---

## Copy of the 17 baseline tables (T07, first-year provisioning)

Seed for every copy case is in "Test data". Each case creates a new company code (`04`, or a fresh code per case) with a first year.
Counts are the rows in the new company after the first-year create.

### year-create.copy.ac-group-rows   (T07 Create)
Layer: database
Steps: 1. Create a first year for a new company. 2. Count `AC_GROUP` rows for it.
Expected: 3 rows (all rows of company `01`). Desktop: `MS_YEAR.cs:1558 {{FROM AC_GROUP WHERE CO_CODE = '01'}}`, no filter.
Today: passes (the web copies every row of `01`; `web/apps/api/src/modules/masters/companyClone.ts:162 {{table: 'AC_GROUP',}}`).
Status: executable

### year-create.copy.ac-mast-rows   (T07 Create, gap 1)
Layer: database
Steps: 1. Create a first year for a new company. 2. List `AC_MAST` rows for it with their `AC_CODE` and `LC_CODE`.
Expected: exactly 2 rows: AC_CODE `050` and AC_CODE `100`, both LC_CODE `00`. Not copied: `101` (not below 101), `099` (LC_CODE `01`) and `2001` (not below 101).
Desktop: `MS_YEAR.cs:1560 {{FROM AC_MAST WHERE CO_CODE = '01' AND LC_CODE = '00'}}` and `MS_YEAR.cs:1560 {{AND CAST(AC_CODE AS INT) < 101}}`.
Today: fails. The web copies all 5 rows (`web/apps/api/src/modules/masters/companyClone.ts:167 {{table: 'AC_MAST',}}` with no filter; `web/apps/api/src/modules/masters/companyClone.ts:513 {{WHERE tenant_id=$1 AND "CO_CODE"=$3}}`).
Status: executable (fails today: gap 1)

### year-create.copy.ac-mast-columns   (T07 Create, gap 2)
Layer: database
Steps: 1. Use the seed where template `01` has `AC_PERSON`, `AC_ADD1`, `AC_GSTNO` and `AC_PANNO` filled in on the rows. 2. Create a first year. 3. Read those four columns and `DATA_TRFR` of the copied rows.
Expected: the four columns are NULL or empty on both copied rows; `DATA_TRFR` is `N` on both. Desktop: the insert names nine columns and writes `'N'` to `DATA_TRFR`
(`MS_YEAR.cs:1560 {{INSERT INTO AC_MAST (CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_GST_TYPE,DATA_TRFR)}}`;
`MS_YEAR.cs:1560 {{,'N' FROM AC_MAST WHERE CO_CODE = '01'}}`).
Today: fails. The web copies 26 columns and copies `DATA_TRFR` from the source (`web/apps/api/src/modules/masters/companyClone.ts:177 {{'DATA_TRFR',}}`, `web/apps/api/src/modules/masters/companyClone.ts:178 {{'AC_PERSON',}}`).
Status: executable (fails today: gap 2)

### year-create.copy.bal-gr-rows   (T07 Create)
Layer: database
Steps: 1. Create a first year. 2. Count `BAL_GR` rows.
Expected: 2 rows (all rows of `01`). Desktop: `MS_YEAR.cs:1562 {{FROM BAL_GR WHERE CO_CODE = '01'}}`.
Today: passes.
Status: executable

### year-create.copy.book-data-rows   (T07 Create, gap 1)
Layer: database
Steps: 1. Create a first year. 2. Count `BOOK_DATA` rows and read their `LC_CODE`.
Expected: 2 rows, both LC_CODE `00`. Not copied: the LC_CODE `01` row. Desktop: `MS_YEAR.cs:1564 {{FROM BOOK_DATA WHERE CO_CODE = '01' AND LC_CODE = '00'}}`.
Today: fails (the web copies 3 rows; `web/apps/api/src/modules/masters/companyClone.ts:257 {{table: 'BOOK_DATA',}}`).
Status: executable (fails today: gap 1)

### year-create.copy.book-data-columns   (T07 Create, gap 2)
Layer: database
Steps: 1. Use a template `01` `BOOK_DATA` row with `USER_EMP_CODE`, `WITH_MOBILE_ENTRY`, `MENU_NAME`, `BOOK_TBL_NAME` and `BOOK_TBL_DETL` filled in. 2. Create a first year. 3. Read those five columns of the copied row.
Expected: all five are NULL or empty. Desktop: the insert ends at `DATA_TRFR` and names no other column
(`MS_YEAR.cs:1564 {{BOOK_VCH_TYPE,MAIN_USER,BOOK_SR_NAME,RESET_BOOK,DATA_TYPE,TRFR_BOOK,DATA_TRFR)}}`).
Today: fails (the web copies those columns; `web/apps/api/src/modules/masters/companyClone.ts:257 {{table: 'BOOK_DATA',}}`).
Status: executable (fails today: gap 2)

### year-create.copy.book-detl-rows   (T07 Create, gap 1)
Layer: database
Steps: 1. Create a first year. 2. Count `BOOK_DETL` rows for it.
Expected: 3 rows (LC_CODE `00`). Not copied: the LC_CODE `01` row. Desktop: `MS_YEAR.cs:1566 {{FROM BOOK_DETL WHERE CO_CODE = '01' AND LC_CODE = '00'}}`.
Today: fails (the web copies all 4 rows).
Status: executable (fails today: gap 1)

### year-create.copy.book-detl-listed-once   (T07 Create, gap 4)
Layer: unit
Steps: 1. Read the clone table list in the web code. 2. Count the entries whose table is `BOOK_DETL`.
Expected: exactly one entry. Desktop: one `BOOK_DETL` insert with one filter (`MS_YEAR.cs:1566 {{INSERT INTO BOOK_DETL(CO_CODE,LC_CODE,CO_BOOK,SR_NO,BOOK_NAME,BOOK_SNAME,BOOK_TYPE,ITM_TYPE,BOOK_INOUT,AC_CODE,AC_NAME,MAIN_BOOK,RESET_BOOK,DATA_TYPE)}}`).
Today: fails. Two entries exist: `web/apps/api/src/modules/masters/companyClone.ts:238 {{table: 'BOOK_DETL',}}` and `web/apps/api/src/modules/masters/companyClone.ts:284 {{table: 'BOOK_DETL',}}`.
Status: executable (fails today: gap 4)

### year-create.copy.co-set-rows   (T07 Create)
Layer: database
Steps: 1. Create a first year. 2. Count `CO_SET` rows.
Expected: 1 row (all rows of `01`). Desktop: `MS_YEAR.cs:1568 {{FROM CO_SET WHERE CO_CODE = '01'}}`.
Today: passes.
Status: executable

### year-create.copy.co-set-new-rows   (T07 Create)
Layer: database
Steps: 1. Create a first year. 2. Count `CO_SET_NEW` rows.
Expected: 1 row. Desktop: `MS_YEAR.cs:1570 {{FROM CO_SET_NEW WHERE CO_CODE = '01'}}`.
Today: passes.
Status: executable

### year-create.copy.col-mast-rows   (T07 Create)
Layer: database
Steps: 1. Create a first year. 2. Count `COL_MAST` rows.
Expected: 2 rows. Desktop: `MS_YEAR.cs:1572 {{FROM COL_MAST WHERE CO_CODE = '01'}}`.
Today: passes.
Status: executable

### year-create.copy.conv-mast-rows   (T07 Create)
Layer: database
Steps: 1. Create a first year. 2. Count `CONV_MAST` rows.
Expected: 2 rows. Desktop: `MS_YEAR.cs:1574 {{FROM CONV_MAST WHERE CO_CODE = '01'}}`.
Today: passes.
Status: executable

### year-create.copy.emp-mast-rows   (T07 Create, gap 1)
Layer: database
Steps: 1. Create a first year. 2. List `EMP_CODE` of the copied `EMP_MAST` rows.
Expected: 1 row, EMP_CODE `001`. Not copied: `002`. Desktop: `MS_YEAR.cs:1576 {{FROM EMP_MAST WHERE CO_CODE = '01' AND EMP_CODE = '001'}}`.
Today: fails (the web copies 2 rows; `web/apps/api/src/modules/masters/companyClone.ts:328 {{table: 'EMP_MAST',}}`).
Status: executable (fails today: gap 1)

### year-create.copy.emp-mast-columns   (T07 Create, gap 2)
Layer: database
Steps: 1. Use a template `01` `EMP_MAST` row with `TDS_PRC`, `TDS_AMT`, `PF_PRC`, `PF_AMT`, `DAY_HOURS` filled in. 2. Create a first year. 3. Read those five columns of the copied row.
Expected: all five are NULL or empty. Desktop: the insert names eight columns and no others
(`MS_YEAR.cs:1576 {{INSERT INTO EMP_MAST (CO_CODE,EMP_CODE,EMP_NAME,USER_NAME,EMP_TYPE,EMP_AC,EMP_AMT,MAIN_USER)}}`).
Today: fails (the web copies the five columns; study Gap 2).
Status: executable (fails today: gap 2)

### year-create.copy.group-mast-rows   (T07 Create, gap 1)
Layer: database
Steps: 1. Create a first year. 2. List `GR_CODE` of the copied `GROUP_MAST` rows.
Expected: 1 row, GR_CODE `DM`. Not copied: `ZZ` (not in the desktop list). Desktop: `MS_YEAR.cs:1578 {{IN ('916','DM','EM','FGL','FSL','GO','OG','ORD','OS','OT','SL','SN')}}`.
Today: fails (the web copies 2 rows; `web/apps/api/src/modules/masters/companyClone.ts:346 {{table: 'GROUP_MAST',}}`).
Status: executable (fails today: gap 1)

### year-create.copy.group-mast-columns   (T07 Create, gap 2)
Layer: database
Steps: 1. Use a template `01` `GROUP_MAST` row with `RATE_DISPLAY` and `DATA_TRFR` filled in. 2. Create a first year. 3. Read those two columns.
Expected: both NULL or empty. Desktop: the insert ends at `DAY_CL_WT` (`MS_YEAR.cs:1578 {{DAY_CL_PCS,DAY_CL_WT)}}`).
Today: fails (study Gap 2).
Status: executable (fails today: gap 2)

### year-create.copy.item-mast-rows   (T07 Create, gap 1)
Layer: database
Steps: 1. Create a first year. 2. List `IT_CODE` of the copied `ITEM_MAST` rows.
Expected: 1 row, IT_CODE `DM`. Not copied: `AB`. Desktop: `MS_YEAR.cs:1580 {{IN ('999','DM','EM','FSL','HM','OG','ORG','ORS','OS','OT','RD','SN')}}`.
Today: fails (the web copies 2 rows; `web/apps/api/src/modules/masters/companyClone.ts:375 {{table: 'ITEM_MAST',}}`).
Status: executable (fails today: gap 1)

### year-create.copy.loct-mast-rows   (T07 Create, gap 1)
Layer: database
Steps: 1. Create a first year. 2. List `LC_CODE` of the copied `LOCT_MAST` rows.
Expected: 1 row, LC_CODE `00`. Not copied: `01`. Desktop: `MS_YEAR.cs:1582 {{FROM LOCT_MAST WHERE CO_CODE = '01' AND LC_CODE = '00'}}`.
Today: fails (the web copies 2 rows; `web/apps/api/src/modules/masters/companyClone.ts:413 {{table: 'LOCT_MAST',}}`).
Status: executable (fails today: gap 1)

### year-create.copy.print-mast-rows   (T07 Create)
Layer: database
Steps: 1. Create a first year. 2. Count `PRINT_MAST` rows.
Expected: 2 rows. Desktop: `MS_YEAR.cs:1586 {{FROM PRINT_MAST WHERE CO_CODE = '01'}}`.
Today: passes.
Status: executable

### year-create.copy.product-mast-rows   (T07 Create, gap 1)
Layer: database
Steps: 1. Create a first year. 2. List `PR_CODE` of the copied `PRODUCT_MAST` rows.
Expected: 1 row, PR_CODE `DM`. Not copied: `AB`. Desktop: `MS_YEAR.cs:1588 {{IN ('DM','EM','FN','HM','OD','OG','OR','OS','OT','RD','SN')}}`.
Today: fails (the web copies 2 rows; `web/apps/api/src/modules/masters/companyClone.ts:433 {{table: 'PRODUCT_MAST',}}`).
Status: executable (fails today: gap 1)

### year-create.copy.table-mast-rows   (T07 Create, gap 1)
Layer: database
Steps: 1. Create a first year. 2. List `TABLE_CODE` of the copied `TABLE_MAST` rows.
Expected: 1 row, TABLE_CODE `001`. Not copied: `002`. Desktop: `MS_YEAR.cs:1590 {{AND TABLE_CODE = '001'}}`.
Today: fails (the web copies 2 rows; `web/apps/api/src/modules/masters/companyClone.ts:438 {{table: 'TABLE_MAST',}}`).
Status: executable (fails today: gap 1)

### year-create.copy.tax-mast-rows   (T07 Create)
Layer: database
Steps: 1. Create a first year. 2. Count `TAX_MAST` rows.
Expected: 2 rows. Desktop: `MS_YEAR.cs:1592 {{FROM TAX_MAST WHERE CO_CODE = '01'}}`.
Today: passes.
Status: executable

### year-create.copy.ac-mast-srno-not-copied   (T07 Create, gap 3)
Layer: database
Steps: 1. Use a template `01` with one `AC_MAST_SRNO` row. 2. Create a first year. 3. Count `AC_MAST_SRNO` rows for the new company.
Expected: 0 rows. The desktop's copy list has no `AC_MAST_SRNO` insert (inferred from the 17-statement list at `MS_YEAR.cs:1557 {{DC_Main.ExeQuteDc("DELETE FROM AC_GROUP WHERE CO_CODE}}`
through `MS_YEAR.cs:1592 {{FROM TAX_MAST WHERE CO_CODE = '01'}}`; the study's Lifecycle table names 17 tables).
Today: fails. The web clones it: `web/apps/api/src/modules/masters/companyClone.ts:218 {{table: 'AC_MAST_SRNO',}}`.
Status: executable (fails today: gap 3)

### year-create.copy.bank-reconcile-not-copied   (T07 Create, gap 3)
Layer: database
Steps: 1. Use a template `01` with one `BANK_RECONCILE` row. 2. Create a first year. 3. Count `BANK_RECONCILE` rows for the new company.
Expected: 0 rows. Desktop: the purge deletes `BANK_RECONCILE` and the copy list has no insert for it (`MS_YEAR.cs:1412 {{DELETE FROM BANK_RECONCILE}}`).
Today: fails. The web clones it: `web/apps/api/src/modules/masters/companyClone.ts:227 {{table: 'BANK_RECONCILE',}}`.
Status: executable (fails today: gap 3)

### year-create.copy.import-all-party-prompt   (T07 Create, gap 5)
Layer: browser
Steps: 1. Start a new company and choose company `01` as the old company on the company screen. 2. Save the company, which opens Year Create.
Expected: a yes/no prompt with the text `Import All Party from Ac Master Of 01 Compnay...?`. Desktop: `MS_YEAR.cs:1512 {{Import All Party from Ac Master Of }}`.
The text is copied from the desktop with the typo `Compnay`.
Status: blocked: owner decision (gap 5). A hosted service copying parties between companies needs the owner's word. Unblocked by that decision.

### year-create.copy.import-all-party-copies-every-row   (T07 Create, gap 5)
Layer: database
Steps: 1. Use the seed in "Test data" (company `01` is the old company). 2. Start a new company `04`, choose `01` as the old company, and answer Yes at the prompt. 3. List the `AC_MAST` rows of company `04` with `AC_CODE` and `LC_CODE`.
Expected (Yes): 4 rows, AC_CODE `050`, `100`, `101` and `2001`, all LC_CODE `00`. Not copied: `099` (LC_CODE `01`). Arithmetic: the seed has five rows, and this branch keeps only LC_CODE `00`, which removes `099` and nothing else. Desktop: `MS_YEAR.cs:1514 {{DELETE FROM AC_MAST WHERE CO_CODE = '"}}` clears the new company first, then `MS_YEAR.cs:1515 {{AND LC_CODE = '00' ");}}` limits the copy to LC_CODE `00`. No AC_CODE filter is applied on this branch.
Expected (No, the same steps answering No): the desktop copies from `01` with `MS_YEAR.cs:1520 {{AND AC_CODE < '00101'");}}`. That is a text comparison. The text `050` sorts after `00101` because its second character `5` is greater than `0`; `100`, `101` and `2001` sort after it for the same reason. So the No branch copies 0 AC_MAST rows for this seed, not the 2 baseline rows the study assumed. This assumes `AC_MAST.AC_CODE` is a text column, as the web schema types it (`web/packages/db/prisma/schema.prisma:82 {{AC_CODE             String?   @db.VarChar(8)}}`). The result depends on the shape of the codes, so the No value must be re-derived when the owner decides.
Status: blocked: owner decision (gap 5). Both results come from the desktop source; see "Not covered" item 20.

### year-create.copy.further-year-no-import-prompt   (T07 Create)
Layer: browser
Steps: 1. Company `04` has its first year. 2. Create `2027-2028`.
Expected: no Import All Party prompt; the year is saved. Desktop: the prompt is in the copy branch only (`MS_YEAR.cs:1357 {{if (Operators.CompareString(DC_Main.NewCompCode, "", false) != 0)}}`).
Status: executable

---

## Alternate-year company (T01, T02, T07, gap 9, gap 11)

The company flag is `ALTER_YEAR` = `Y` (seed company `03`, see "Test data"). Desktop: `MS_YEAR.cs:1010 {{if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)}}`;
the flag comes from the company row (`MS_OPNCOMP.cs:475 {{DC_Main.MsAlterYear = Conversions.ToString}}`). Today the web stores the flag
(`web/packages/db/prisma/schema.prisma:1362 {{ALTER_YEAR     String? @db.VarChar(1)}}`) but no year logic reads it (gap 11).

### year-create.alt.default-apr-dec   (T01 Entry/defaults, gap 9, gap 11)
Layer: browser
Steps: 1. Set the clock to 16 November 2026. 2. Open Year Create for company `03`. 3. Read the code, the start month, the opening and the closing.
Expected: code `2026-2027`; start month `11`; opening `01/11/2026`; closing `01/11/2027`. Desktop: the month is the current month
(`MS_YEAR.cs:1012 {{tMonth.Text = Strings.Mid(Conversions.ToString(DateAndTime.Today), 4, 2);}}`), the opening is `01/MM/Y`
(`MS_YEAR.cs:1016 {{mOpDate.Text = "01/" + tMonth.Text + "/" + Strings.Mid(tYearCode.Text, 1, 4);}}`) and the closing is `01/MM/(Y+1)`
(`MS_YEAR.cs:1017 {{mClDate.Text = "01/" + tMonth.Text + "/" + Strings.Mid(tYearCode.Text, 6, 4);}}`).
Today: fails. The web's closing default is one year minus one day (`web/packages/core/src/fiscalYear.ts:58 {{Date.UTC(opening.getUTCFullYear() + 1, opening.getUTCMonth(), opening.getUTCDate() - 1)}}`), and it has no alternate-year month (gap 9).
Status: executable (fails today: gaps 9, 11)

### year-create.alt.default-jan-mar   (T01 Entry/defaults, gap 9, gap 11)
Layer: browser
Steps: 1. Set the clock to 15 February 2027. 2. Open Year Create for company `03`. 3. Read the fields.
Expected: code `2026-2027`; start month `02`; opening `01/02/2027`; closing `01/02/2028`. Desktop: January to March gives the code `(Y-1)-Y` with Y = 2027,
the opening `01/MM/Y` (`MS_YEAR.cs:1022 {{mOpDate.Text = "01/" + tMonth.Text + "/" + Strings.Mid(tYearCode.Text, 6, 4);}}`) and the closing
`01/MM/(Y+1)` with the year written by `MS_YEAR.cs:1023 {{Strings.Format((object)(Conversions.ToDouble(Strings.Mid(tYearCode.Text, 6, 4)) + 1.0), "00")}}`.
Today: fails (gaps 9, 11).
Status: executable (fails today: gaps 9, 11)

### year-create.alt.start-month-from-opening   (T02 Field route, gap 11)
Layer: browser
Steps: 1. Open Year Create for company `03` with the clock at 16 November 2026. 2. Type the opening date `01/07/2026` and press Enter.
3. Read the start month field.
Expected: start month `07`. Desktop: in alternate-year mode the month is copied from the opening date
(`MS_YEAR.cs:1111 {{tMonth.Text = Strings.Mid(mOpDate.Text, 4, 2);}}`) after the date is valid (`MS_YEAR.cs:1107 {{if (!DC_Main.RongDate)}}`).
Today: fails (no start-month field on the web's alternate-year path; gap 11).
Status: executable (fails today: gap 11)

### year-create.alt.create-footprint-apr-dec   (T07 Create, gap 11)
Layer: database
Steps: 1. Create company `03`'s first year with the default of the Apr–Dec case (clock 16 November 2026, month `11`, opening `01/11/2026`, closing `01/11/2027`), operator `op1`.
2. Query `YEAR_MAST` for company `03`.
Expected: one row with `CO_YEAR` `202611`, `OP_DATE` 01/11/2026 (the same day as the desktop text), `CL_DATE` 2027-11-01, `OLD_METHOD` `N`, `YEAR_MONTH` `11`, `MAIN_USER` `op1`.
Desktop: `MS_YEAR.cs:1189 {{dataRow["CO_YEAR"] = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;}}`,
`MS_YEAR.cs:1197 {{dataRow["OLD_METHOD"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(}}` (alternate year writes `N`), `MS_YEAR.cs:1198 {{dataRow["YEAR_MONTH"] = tMonth.Text;}}`.
Today: fails (the web writes `CO_YEAR` `2026-2027`; `web/apps/api/src/modules/masters/year.ts:91 {{INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE"}}`).
The `OP_DATE` text format is the blocked decision in `year-create.field.opening-date-stored-format`.
Status: executable (fails today: gap 11)

### year-create.alt.create-footprint-jan-mar   (T07 Create, gap 9, gap 11)
Layer: database
Steps: 1. Clock at 15 February 2027, company `03` first year, month `02`. 2. Query `YEAR_MAST`.
Expected: `CO_YEAR` `202602`; closing `2028-02-01`; opening `2027-02-01`; `OLD_METHOD` `N`; `YEAR_MONTH` `02`. Arithmetic: code 2026-2027, first four characters `2026`, month `02`.
Desktop: `MS_YEAR.cs:1189 {{dataRow["CO_YEAR"] = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;}}`.
Today: fails (gaps 9, 11).
Status: executable (fails today: gaps 9, 11)

### year-create.alt.second-year-same-month   (T07 Create, gap 11)
Layer: database
Steps: 1. Company `03` has `2026-2027` with month `11` (CO_YEAR `202611`). 2. Create year `2027-2028` with month `11` for company `03`.
Expected: a second row with `CO_YEAR` `202711`; the first row unchanged. Desktop: `MS_YEAR.cs:1189 {{dataRow["CO_YEAR"] = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;}}`.
Today: fails (the web writes `2027-2028`; gap 11).
Status: executable (fails today: gap 11)

---

## Edit and existing years (T09, gap 16)

### year-create.edit.save-dates-existing-year   (T09 Edit, gap 16)
Layer: browser
Steps: 1. Company `04` has `2026-2027`. 2. Load the year (see lookup case). 3. Change the closing date to `30/04/2027` and press Save.
4. Query the row.
Expected: the closing date of the row is 30 April 2027; no other row changes. Desktop: Save of a loaded year rewrites the row
(`MS_YEAR.cs:1173 {{DC_Main.ExeQuteMc("DELETE FROM YEAR_MAST WHERE CO_CODE}}`; `MS_YEAR.cs:1196 {{dataRow["CL_DATE"] = mClDate.Text;}}`), then
`MS_YEAR.cs:1394 {{Year Is Already Exist...Now ReOpen Sofware...}}` and exit (`MS_YEAR.cs:1395 {{Application.Exit();}}`).
Today: fails (the web cannot change an existing year).
Status: blocked: owner decision (gap 16). Editing a year that already holds vouchers needs the owner's word. Unblocked by that decision.

---

## Delete, cancel and reverse (T10)

### year-create.delete.no-delete-action   (T10 Delete/cancel/reverse, gap 14)
Layer: browser
Steps: 1. Open Year Create. 2. Look for any control named Delete. 3. Send `DELETE /years` with an operator session.
Expected: no Delete control on the screen; `DELETE /years` is not a route and returns HTTP 404. No row changes.
Web today: the rights list for the menu has three routes and none is a delete (`web/apps/api/src/modules/rbac/routePolicy.ts:918 {{['GET /years', 'POST /years', 'POST /years/carry-forward']}}`).
Desktop (not ported): the Delete button deletes a user, not a year (`MS_YEAR.cs:980 {{Are You Sure To Delete This User now?}}`,
`MS_YEAR.cs:984 {{DELETE FROM LOGIN_MAST WHERE CO_CODE}}`).
Status: executable

---

## Rights and scope (T11)

### year-create.rights.create-without-right-refused   (T11 Scope/rights)
Layer: database
Steps: 1. Create an operator without the `create` right on `Masters/Year Create`. 2. Call `POST /years` for company `04` with a valid year. 3. Count `YEAR_MAST` rows for company `04`.
Expected: refused with HTTP 403 and the body `{ error: 'forbidden', action: 'create' }`; no row written. Web: `web/apps/api/src/routes/txn.ts:6357 {{if (!guard(req, reply, 'create')) return;}}`
and `web/apps/api/src/routes/txn.ts:927 {{reply.code(403).send({ error: 'forbidden', action });}}`.
Desktop: create has no right check; the Save rights test is for edit only (`MS_YEAR.cs:1147 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}}`).
The web's create right is web-only (listed under "Not covered").
Status: executable

### year-create.rights.edit-no-rights-desktop-text   (T11 Scope/rights, gap 15, gap 16)
Layer: browser
Steps: 1. Operator without `FRM_EDIT` loads an existing year (see the lookup case). 2. Press Save.
Expected: the message `You Have No Rights.....` and no change; focus does not move. Desktop: `MS_YEAR.cs:1149 {{You Have No Rights.....}}` under the guard at `MS_YEAR.cs:1147 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}}`.
Status: blocked: owner decision (gap 16). The web has no edit path, so there is no screen on which this message can show. Unblocked by the edit decision.

### year-create.rights.create-refused-message   (T11 Scope/rights, gap 15)
Layer: browser
Steps: 1. Sign in as `op2` (no create right on `Masters/Year Create`). 2. Open Year Create, enter the year `2026-2027` with valid dates for company `04`, press Save. 3. Count `YEAR_MAST` rows for company `04`.
Expected: no row is written, and the screen shows the text `forbidden`. The API returns 403 with the body `{ error: 'forbidden', action: 'create' }` (`web/apps/api/src/routes/txn.ts:927 {{reply.code(403).send({ error: 'forbidden', action });}}`), and the page's error helper shows the body's `error` field when there is no `message` or `detail` (`web/apps/web/app/(app)/masters/year-create/page.tsx:21 {{e.body?.message || e.body?.detail || e.body?.error || e.message}}`). Desktop: no message, because the desktop has no create right; its only rights test is the edit guard (`MS_YEAR.cs:1147 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}}`). The desktop texts are not used here (see "Not covered" item 13).
Status: executable (web-only result, expected to pass today; the executing worker confirms the on-screen text). The create right itself is a web decision, listed under "Not covered" item 13.

### year-create.scope.other-company-same-year-code   (T11 Scope/rights)
Layer: database
Steps: 1. Company `02` (a second company in the tenant) has `2026-2027` (seed). 2. Company `04` creates its first year `2026-2027`. 3. Read both companies' `YEAR_MAST` rows.
Expected: company `04` gets its own `2026-2027` row with the copy; company `02`'s row is unchanged. Desktop: the existence probe has no company condition
(`MS_YEAR.cs:1164 {{SELECT * FROM YEAR_MAST WHERE  CO_YEAR}}`), which skips the restore; that weakness is not ported (Desktop weakness 2).
Today: passes (the web checks duplicates for the company only: `web/apps/api/src/modules/masters/year.ts:86 {{already exists}}`).
Status: executable

### year-create.scope.other-tenant-no-leak   (T11 Scope/rights)
Layer: database
Steps: 1. Tenant `A` has company `01` template and company `04` with `2026-2027`. 2. Tenant `B` (a different tenant) calls `GET /years` for company `04`. 3. Tenant `B` calls `POST /years` for company `04` with `2027-2028`.
Expected: the `GET` returns no row from tenant `A`; the `POST` writes one row under tenant `B` only; tenant `A`'s rows are unchanged. Web: `web/apps/api/src/routes/txn.ts:6352 {{app.get('/years', auth, async (req) => {}}` uses the request's scope.
Status: executable

### year-create.scope.body-company-ignored   (T11 Scope/rights)
Layer: database
Steps: 1. As operator of company `04`, call `POST /years` with body `CO_CODE` set to `02` and a valid year `2026-2027`.
Expected: the row is written for company `04` (the session's company); company `02` is unchanged. Desktop: the row's company is the session company (`MS_YEAR.cs:1186 {{dataRow["CO_CODE"] = DC_Main.MCo_code;}}`).
Status: executable

---

## Concurrency and retry (T12, T13)

### year-create.concurrency.same-year-two-requests   (T12 Concurrency, gap 6)
Layer: database
Steps: 1. Company `04` has no years. 2. Send two `POST /years` for `2026-2027` at the same time from two sessions.
3. Count `YEAR_MAST` rows for company `04` and copied `AC_GROUP` rows.
Expected: one row; one request succeeds (201) and the other is refused with `year 2026-2027 already exists`; `AC_GROUP` has 3 rows, copied once.
Web: `web/apps/api/src/modules/masters/year.ts:86 {{already exists}}` is a probe before the insert, so two sessions can both pass it.
`YEAR_MAST` has no unique index on the company and year (`web/packages/db/prisma/schema.prisma:6972 {{model YEAR_MAST {}}`, index only on `tenantId`, line 6983).
Today: fails if both requests insert. The duplicate check is a read before the insert (`web/apps/api/src/modules/masters/year.ts:86 {{already exists}}`), and the schema has no unique key on company and year, so the second insert is not refused by the database (`web/packages/db/prisma/schema.prisma:6983 {{@@index([tenantId])}}` is the only index; inferred for read-committed isolation). Finding: this is not one of the study's 20 gaps; it is recorded here and in the report.
Status: executable (fails today)

### year-create.retry.same-request-after-commit   (T13 Retry/unknown)
Layer: database
Steps: 1. Send `POST /years` for `2026-2027` for company `04`, and let it succeed. 2. Send the same request again as if the first acknowledgement had been lost.
3. Count `YEAR_MAST` rows and `AC_GROUP` rows for company `04`.
Expected: the second request is refused with `year 2026-2027 already exists`; one `YEAR_MAST` row; `AC_GROUP` still has 3 rows.
Desktop: a repeated Save of a new year overwrites the row and purges (`MS_YEAR.cs:1386 {{DC_Main.DataConYear();}}`, Desktop weakness 4); not ported.
Status: executable

---

## Rollback (T14)

### year-create.rollback.copy-failure-leaves-nothing   (T14 Rollback)
Layer: database
Steps: 1. Make the insert of `TAX_MAST` for the new company fail (a test-only constraint on the target table, removed after the test).
2. Call `POST /years` for company `04`. 3. Query `YEAR_MAST` and all 19 cloned tables for company `04`. 4. Read company `01`'s and company `02`'s rows.
Expected: the request fails; zero `YEAR_MAST` rows for `2026-2027` for company `04`; zero rows for company `04` in every cloned table; company `01` and company `02` rows unchanged.
Web: the year row and the copy share one transaction (`web/apps/api/src/modules/masters/year.ts:91 {{INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE"}}` and `web/apps/api/src/modules/masters/year.ts:106 {{if (firstYear && scope.coCode !== CLONE_TEMPLATE_CO_CODE)}}` inside `withTxBudget`).
Desktop (not ported): the statements are not in one transaction (Desktop weakness 8).
Status: executable

### year-create.rollback.year-row-failure-no-copy   (T14 Rollback)
Layer: database
Steps: 1. Make the `YEAR_MAST` insert fail (test constraint). 2. Call `POST /years` for company `04`. 3. Count rows in the 19 cloned tables for company `04`.
Expected: the request fails; zero rows in every cloned table for company `04`.
Web: `web/apps/api/src/modules/masters/year.ts:106 {{if (firstYear && scope.coCode !== CLONE_TEMPLATE_CO_CODE)}}` runs only after the insert succeeds.
Status: executable

---

## Journey (T18)

### year-create.journey.first-year-party-then-second-year   (T18 Full journey)
Layer: browser
Steps: 1. Save a new company `04` on the company screen; its first year `2026-2027` is created. 2. In `2026-2027`, create party `P1` on the party master and enter an opening balance of Dr 10000.00 for `P1` on the party opening screen.
3. Open Year Create and create `2027-2028`. 4. Open the party opening screen for `2026-2027` and for `2027-2028`.
Expected: `2026-2027` still shows `P1` with Dr 10000.00; `2027-2028` shows no opening for `P1`; both years are listed on Year Create.
Desktop: the new year's data is kept in its own database and the old one is not purged (`MS_YEAR.cs:1386 {{DC_Main.DataConYear();}}`, `MS_YEAR.cs:1387 {{DeleteOldYear_Data();}}`),
and openings are purged for the new year (`MS_YEAR.cs:1462 {{DELETE FROM OP_DATA WHERE CO_YEAR <>}}`).
Web: openings are keyed by `CO_YEAR`, so the second year has none.
Status: executable

### year-create.journey.party-master-shared   (T18 Full journey, gap 12)
Layer: browser
Steps: 1. After the journey above, change the address of party `P1` in `2027-2028`. 2. Open `P1` in `2026-2027`.
Expected: the desktop value and the web value differ by design: on the desktop each year has its own copy of the masters (`MS_YEAR.cs:1386 {{DC_Main.DataConYear();}}`);
on the web the master is shared. The case records the web's shared result (the change is visible in both years) and is not a pass/fail on the desktop.
Status: blocked: decision (gap 12). The owner must accept the shared-master difference before the expected value is fixed. Unblocked by that decision.

---

## Keyboard (T17)

### year-create.keyboard.enter-code-moves-to-opening   (T17 Keyboard/usability, gap 17)
Layer: browser
Steps: 1. Type `2026-2027` in the year code. 2. Press Enter.
Expected: focus moves to the opening date (the start month is hidden in standard mode and is skipped). Desktop: Enter in a non-empty year code loads and sends Tab (`MS_YEAR.cs:1086 {{SendKeys.Send("{tab}");}}`); the start month is hidden (`MS_YEAR.cs:691 {{((Control)tMonth).Visible = false;}}`).
Today: fails (the web page has no Enter handling; gap 17).
Status: executable (fails today: gap 17)

### year-create.keyboard.enter-opening-moves-to-closing   (T17 Keyboard/usability, gap 17)
Layer: browser
Steps: 1. Type `01/04/2026` in the opening date. 2. Press Enter.
Expected: focus moves to the closing date. Desktop: a valid date is followed by a Tab (`MS_YEAR.cs:1107 {{if (!DC_Main.RongDate)}}`, `MS_YEAR.cs:1113 {{SendKeys.Send("{TAB}");}}`).
Today: fails (gap 17).
Status: executable (fails today: gap 17)

### year-create.keyboard.enter-invalid-date-keeps-focus   (T17 Keyboard/usability, gap 17, gap 18)
Layer: browser
Steps: 1. Type `32/04/2026` in the opening date. 2. Press Enter. 3. Note the focused control.
Expected: the message `Date Not Valid...` is shown, focus stays in the opening date, the field shows `__/__/____` and the text is selected. Desktop: `DC_Main.cs:1672 {{Interaction.MsgBox((object)"Date Not Valid...", (MsgBoxStyle)0, (object)null);}}`, `DC_Main.cs:1673 {{MsDate.Text = "__/__/____";}}`, `DC_Main.cs:1674 {{((TextBoxBase)MsDate).SelectAll();}}`; the Tab is not sent (`MS_YEAR.cs:1107 {{if (!DC_Main.RongDate)}}`).
Today: fails (gap 17, 18).
Status: executable (fails today: gaps 17, 18)

### year-create.keyboard.esc-closes   (T17 Keyboard/usability, gap 17)
Layer: browser
Steps: 1. Open Year Create. 2. Press Esc.
Expected: the screen closes (returns to the menu). Desktop: `MS_YEAR.cs:955 {{if ((int)e.KeyCode == 27)}}` then `MS_YEAR.cs:957 {{((Form)this).Close();}}`.
Today: fails (the web page has no Esc handler; gap 17). Confirm the browser's behaviour when the run starts.
Status: executable (fails today: gap 17)

### year-create.keyboard.uppercase-entry   (T17 Keyboard/usability, gap 17)
Layer: browser
Steps: 1. In the year code type `fy2027`.
Expected: the field shows `FY2027`. Desktop: each typed character is converted to upper case (`MS_YEAR.cs:942 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}`).
Today: fails (gap 17).
Status: executable (fails today: gap 17)

### year-create.keyboard.apostrophe-blocked   (T17 Keyboard/usability, gap 17)
Layer: browser
Steps: 1. In the year code type an apostrophe `'` and then `2`.
Expected: the apostrophe does not appear; the field shows `2`. Desktop: character code 39 is swallowed (`MS_YEAR.cs:945 {{if (num == 0 || num == 39)}}`, `MS_YEAR.cs:947 {{e.Handled = true;}}`).
Today: fails (gap 17).
Status: executable (fails today: gap 17)

---

## Messages on the desktop that the web does not show (T16)

### year-create.messages.success-first-year   (T16 Report/output)
Layer: browser
Steps: 1. Save a new company's first year.
Expected: the desktop success text is `All Master And Parameter are Created...Now ReOpen Sofware...` and the program exits. The web shows its own success result; the desktop text is a decision (see "Not covered").
Desktop: `MS_YEAR.cs:1361 {{All Master And Parameter are Created...Now ReOpen Sofware...}}`, `MS_YEAR.cs:1399 {{Application.Exit();}}`.
Status: blocked: decision (the owner decides whether the web keeps its success result or copies the desktop text and exit). Unblocked by that decision.

---

## Not applicable entries

### year-create.na.print-no-button   (T16 Report/output, gap 13)
Layer: browser
Status: N/A: the desktop Print button prints nothing (`MS_YEAR.cs:961 {{private void BtnPrint_Click(object sender, EventArgs e)}}`; with the right it has no action).
The desktop has no report template (`MS_YEAR.cs` has no `.rpt` call), and the web has no Print button, so there is nothing to match. The Print rights text (`MS_YEAR.cs:966 {{You Have No Print Rights.....}}`) is therefore not shown on the web (gap 13 and 15).

### year-create.na.carry-forward-not-here   (T10 Delete/cancel/reverse, gap 19)
Layer: browser
Status: N/A: the carry-forward panel belongs to Balance TrFr. `MS_YEAR.cs` has no carry-forward code (study Gap 19). The web's carry-forward route is `web/apps/api/src/routes/txn.ts:6378 {{app.post('/years/carry-forward', auth, async (req, reply) => {}}` and is tested in its own menu.

### year-create.na.restore-and-purge   (T07 Create, gap 12)
Layer: database
Status: N/A: the desktop copies a whole previous database and purges it (`MS_YEAR.cs:1326 {{BACKUP DATABASE }}`, `MS_YEAR.cs:1333 {{CREATE DATABASE }}`, `MS_YEAR.cs:1350 {{RESTORE DATABASE }}`);
a single-database web needs neither, because each row carries `CO_YEAR`. The operator-visible consequence (masters are shared across years on the web) is the blocked journey case `year-create.journey.party-master-shared` and is listed under "Not covered".

### year-create.na.delete-user-form (T10 Delete/cancel/reverse, gap 14)
Layer: browser
Status: N/A: the desktop Delete button runs the user-form routine and is not ported (study Desktop weakness 1). The absence of a Delete action is proved by `year-create.delete.no-delete-action`.

---

## Coverage table

Cases are the entries with status `executable` or `blocked`. A kind marked N/A has its reason in the table; where an
entry exists for it, the entry's status is N/A.

| Kind | Cases | Blocked | N/A | Note |
|---|---|---|---|---|
| T01 Entry/defaults | 7 | 0 | 1 | Defaults for both branches, alternate-year defaults, Cancel, focus, Lite menu. N/A: UAE default (gap 10, `year-create.entry.uae-default`) |
| T02 Field route | 4 | 1 | 0 | Year code, closing date, alternate-year start month; opening date storage format is blocked (decision) |
| T03 Formula sequence | 0 | 0 | 1 | N/A (kind-level): no money, no rounding. Dates are one step per screen and are covered under T01 |
| T04 Lookup | 1 | 1 | 0 | Enter on an existing year code (gap 16, owner decision) |
| T05 Children | 0 | 0 | 1 | N/A (kind-level): a year has no child rows on the desktop; the 17-table copy is covered under T07 |
| T06 Required/invalid | 8 | 0 | 0 | Blank code, 12 characters, 15-character cap, any-text code, closing before opening, duplicate, day and month messages |
| T07 Create | 33 | 2 | 1 | Footprint, 17-table copy (rows, columns, tables not copied, import prompt blocked), further year, alternate year. N/A: restore and purge (gap 12) |
| T08 Reopen/no-op | 0 | 0 | 1 | N/A (kind-level): no edit path, so no save-unchanged case; reopening is part of the footprint cases |
| T09 Edit | 1 | 1 | 0 | Save of a loaded year (gap 16, owner decision) |
| T10 Delete/cancel/reverse | 1 | 0 | 2 | Delete absent (executable). N/A: carry-forward (gap 19), Delete user-form (gap 14). Cancel is under T01 |
| T11 Scope/rights | 6 | 1 | 0 | Create right, create refusal text, other company, other tenant, body company (executable). Edit no-rights message (blocked, gaps 15 and 16) |
| T12 Concurrency | 1 | 0 | 0 | Two requests for the same year |
| T13 Retry/unknown | 1 | 0 | 0 | Repeated request after commit |
| T14 Rollback | 2 | 0 | 0 | Copy failure and year-row failure |
| T15 Config/history | 0 | 0 | 1 | N/A (kind-level): no preview or saved snapshot; the copy reads the template at save time |
| T16 Report/output | 1 | 1 | 1 | Success text (blocked, decision). N/A: Print (gap 13) |
| T17 Keyboard/usability | 6 | 0 | 0 | Enter moves, invalid date keeps focus, Esc, upper case, apostrophe |
| T18 Full journey | 2 | 1 | 0 | First year, party and opening, second year (executable); shared master (blocked, gap 12) |
| **Total** | **74** | **11** | **9** | 74 cases; 5 N/A entries in this file. The N/A column also counts four kind-level N/A rows (T03, T05, T08, T15) |

Counts are from `cases.md` itself. The blocked count includes the blocked decision cases.

## Test data

Every database case runs on the isolated database started by `web/scripts/parity-test-env.mjs`. Nothing here is taken from real data.

- **Tenant A**, with the template company `01` (`CLONE_TEMPLATE_CO_CODE`, `web/apps/api/src/modules/masters/companyClone.ts:458 {{export const CLONE_TEMPLATE_CO_CODE = '01';}}`):
  - `AC_GROUP`: 3 rows.
  - `AC_MAST`: 5 rows, all `AC_CODE` numeric: `050` (LC `00`), `100` (LC `00`), `101` (LC `00`), `099` (LC `01`), `2001` (LC `00`). Each row has `AC_PERSON`, `AC_ADD1`, `AC_GSTNO` and `AC_PANNO` filled with test text, and `DATA_TRFR` set to `Y`.
  - `AC_MAST_SRNO`: 1 row. `BANK_RECONCILE`: 1 row.
  - `BAL_GR`: 2 rows.
  - `BOOK_DATA`: 3 rows (LC `00`, `00`, `01`), with `USER_EMP_CODE`, `WITH_MOBILE_ENTRY`, `MENU_NAME`, `BOOK_TBL_NAME`, `BOOK_TBL_DETL` filled.
  - `BOOK_DETL`: 4 rows (LC `00`, `00`, `00`, `01`).
  - `CO_SET`: 1 row. `CO_SET_NEW`: 1 row. `COL_MAST`: 2 rows. `CONV_MAST`: 2 rows.
  - `EMP_MAST`: 2 rows (`EMP_CODE` `001`, `002`), with `TDS_PRC`, `TDS_AMT`, `PF_PRC`, `PF_AMT`, `DAY_HOURS` filled.
  - `GROUP_MAST`: 2 rows (`GR_CODE` `DM` and `ZZ`), with `RATE_DISPLAY` and `DATA_TRFR` filled.
  - `ITEM_MAST`: 2 rows (`IT_CODE` `DM` and `AB`). `LOCT_MAST`: 2 rows (LC `00`, `01`). `PRINT_MAST`: 2 rows.
  - `PRODUCT_MAST`: 2 rows (`PR_CODE` `DM` and `AB`). `TABLE_MAST`: 2 rows (`TABLE_CODE` `001` and `002`). `TAX_MAST`: 2 rows.
- **Company `02`** in tenant A, with its own `YEAR_MAST` row `2026-2027` (ALTER_YEAR `N`).
- **Company `03`** in tenant A, with `ALTER_YEAR` = `Y` (alternate-year). No year row before the alternate-year cases.
- **Company `04`** and later fresh company codes: created in each case, with no rows, so the first-year copy runs.
- **Tenant B**, with its own company `04` and one `YEAR_MAST` row `2026-2027`, to prove isolation.
- **Operators**: `op1` with the create right on `Masters/Year Create`; `op2` without it.
- **Party**: a party master `P1` in company `04` for the journey case (entered through the screens, not seeded).
- **Clock**: 16 November 2026 for the Apr–Dec cases; 15 February 2027 for the Jan–Mar cases.

## Not covered

Each item is a behaviour in the study that no case proves as a pass or fail, or a decision the owner must make.

1. **UAE calendar year (gap 10).** No case. Out of scope for the India Lite build. The owner must decide whether UAE is a target company type.
2. **Print and print rights text (gap 13, part of gap 15).** No case. The web has no Print button and the desktop Print has no effect.
3. **Delete user-form routine (gap 14).** Not ported. Only the absence of a Delete action is tested.
4. **Carry-forward (gap 19).** No case here. It belongs to Balance TrFr.
5. **Blank year code refusal.** The desktop has no refusal (Desktop weakness 10). The case keeps the web's refusal. Decision for the owner: keep it (recommended).
6. **Closing before opening refusal.** The desktop has no check (Rule 2). The case keeps the web's refusal. Decision: keep it (recommended).
7. **Desktop accepts 31/04/2026 (inferred, not run).** The month test in `DC_Main.cs:1650 {{else if (num2 == 4.0 || num2 == 6.0 || num2 == 9.0 || num2 == 11.0)}}` compares only the first character with `30`, so the day 31 in a 30-day month passes. The web rejects it (`web/packages/core/src/fiscalYear.ts:52 {{is not a valid date}}`). Decision: keep the web's check. No case: the desktop result is not proved by running it.
8. **Stored date format (`OP_DATE`, `CL_DATE`).** The desktop stores the masked text `dd/MM/yyyy` (`MS_YEAR.cs:1195 {{dataRow["OP_DATE"] = mOpDate.Text;}}`); the web stores ISO. Blocked decision, see `year-create.field.opening-date-stored-format`. Not one of the study's 20 gaps; recorded here.
9. **Year code length and format (gaps 7 and 8).** The desktop rule (any text up to 15 characters, no format) is the expected value. The web rule (nine characters, `yyyy-yyyy`) is a web-only restriction. Decision for the owner: existing web data and other screens may rely on the nine-character format. Recommendation: keep nine characters and `yyyy-yyyy`, which is the normal form; the owner decides. The cases `year-create.validate.year-code-12-chars-accepted` and `year-create.validate.year-code-any-text-accepted` show the desktop result and fail until the owner decides.
10. **Web clones the masters for any company's first year.** The desktop copies only when a new company is saved (`MS_YEAR.cs:1357 {{if (Operators.CompareString(DC_Main.NewCompCode, "", false) != 0)}}`). The web runs `cloneCompanyTx` on the first `YEAR_MAST` row of any company (`web/apps/api/src/modules/masters/year.ts:106 {{if (firstYear && scope.coCode !== CLONE_TEMPLATE_CO_CODE)}}`). No case; decision for the owner.
11. **Duplicate create text (gap 6).** The desktop shows no text for a duplicate create; the web refuses with its own text. The case expects the web's text. Decision: keep it (recommended) or use the desktop's edit text for an edit path only.
12. **Shared masters across years (gap 12 consequence).** On the desktop each year has its own copy of masters; on the web they are shared. The journey case proves the openings are per year; the shared master behaviour is blocked (`year-create.journey.party-master-shared`).
13. **Create right (web-only).** The desktop has no create right (Desktop weakness 9). The web checks `create` (`web/apps/api/src/routes/txn.ts:6357 {{if (!guard(req, reply, 'create')) return;}}`). Decision: keep the right (recommended). The refusal shows the API's `forbidden` text (case `rights.create-refused-message`); a desktop-style text for it would be a new message the desktop never shows.
14. **Edit path and its messages (gaps 15 and 16).** Blocked; no screen exists on the web to show the desktop texts.
15. **Desktop texts for the success result (gap 15 and the success message).** Blocked decision (`year-create.messages.success-first-year`).
16. **Desktop non-transactional saves (Desktop weakness 8).** Not ported. The web's transaction is tested by the rollback cases.
17. **Restore and purge of the previous database (gap 12).** Not applicable; the web uses one database. The operator-visible result is covered by the further-year and journey cases.
18. **Purge of other companies' users (Desktop weakness 6).** Not ported; no web equivalent.
19. **Alternate-year period lock.** The desktop's period lock is `CO_SET.LOCK_DATE`; this is outside Year Create and not tested here.
20. **Import "No" branch compares codes as text (gap 5, decision).** The No branch copies `AC_MAST` with `MS_YEAR.cs:1520 {{AND AC_CODE < '00101'");}}`.
    Because the comparison is textual, the seed's 3- and 4-character codes sort after `00101` and nothing is copied: 0 rows, not the 2 baseline rows. The study's Lifecycle step 6 and Rule 9 say No copies the baseline parties; the source does not do that for these codes. Decision for the owner: which rule the import uses (for example a numeric comparison as in the default branch, `MS_YEAR.cs:1560 {{AND CAST(AC_CODE AS INT) < 101}}`). The case `year-create.copy.import-all-party-copies-every-row` keeps the desktop's 0-row result until then.
21. **Import "Yes" branch filters (study correction, gap 5).** The study says this branch "has no row filters". The source filters the copies by LC_CODE `00`: `MS_YEAR.cs:1515 {{AND LC_CODE = '00' ");}}`, `MS_YEAR.cs:1525 {{AND LC_CODE = '00'");}}` and `MS_YEAR.cs:1527 {{AND LC_CODE = '00'");}}`. The Yes result in the case uses this filter. The study itself is not changed here.

## Gap map

| Gap | Cases (or N/A entry) |
|---|---|
| 1 row selection | `copy.ac-mast-rows`, `copy.book-data-rows`, `copy.book-detl-rows`, `copy.emp-mast-rows`, `copy.group-mast-rows`, `copy.item-mast-rows`, `copy.loct-mast-rows`, `copy.product-mast-rows`, `copy.table-mast-rows` |
| 2 column sets | `copy.ac-mast-columns`, `copy.book-data-columns`, `copy.emp-mast-columns`, `copy.group-mast-columns` |
| 3 tables never copied | `copy.ac-mast-srno-not-copied`, `copy.bank-reconcile-not-copied` |
| 4 BOOK_DETL twice | `copy.book-detl-listed-once` |
| 5 import all party | `copy.import-all-party-prompt`, `copy.import-all-party-copies-every-row` (blocked; Yes and No results, see Not covered 20 and 21) |
| 6 duplicate year | `validate.duplicate-year-refused`, `concurrency.same-year-two-requests` |
| 7 year-code length | `validate.year-code-12-chars-accepted`, `validate.year-code-stops-at-15` |
| 8 year-code format | `validate.year-code-any-text-accepted` |
| 9 closing default (alternate) | `alt.default-apr-dec`, `alt.default-jan-mar`, `alt.create-footprint-jan-mar` |
| 10 UAE | `entry.uae-default` (N/A) |
| 11 alternate-year branch | `alt.default-apr-dec`, `alt.default-jan-mar`, `alt.start-month-from-opening`, `alt.create-footprint-apr-dec`, `alt.create-footprint-jan-mar`, `alt.second-year-same-month` |
| 12 restore and purge | `na.restore-and-purge` (N/A); consequence `journey.party-master-shared` (blocked) |
| 13 print | `na.print-no-button` (N/A) |
| 14 delete | `delete.no-delete-action`, `na.delete-user-form` (N/A) |
| 15 rights messages | `rights.edit-no-rights-desktop-text` (blocked), `rights.create-refused-message` (executable, web-only text) |
| 16 edit of an existing year | `lookup.enter-loads-existing-year`, `edit.save-dates-existing-year`, `rights.edit-no-rights-desktop-text` (all blocked) |
| 17 keyboard | `keyboard.enter-code-moves-to-opening`, `keyboard.enter-opening-moves-to-closing`, `keyboard.enter-invalid-date-keeps-focus`, `keyboard.esc-closes`, `keyboard.uppercase-entry`, `keyboard.apostrophe-blocked` |
| 18 date messages | `validate.date-day-invalid-desktop-text`, `validate.month-invalid-desktop-text`, `keyboard.enter-invalid-date-keeps-focus` |
| 19 carry-forward | `na.carry-forward-not-here` (N/A) |
| 20 Lite edition | `entry.lite-menu-visible` |
