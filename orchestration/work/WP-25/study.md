# WP-25 study: Other → Data Import, Lite Soft only (desktop `UT_IMPORT`)

Written for the build and case-list workers. Desktop citations are `FILE:LINE {{quoted text}}` (files under
`unified/src/csharp/DataCareNext/`). Web paths are relative to `web/`. Desktop match of the web today: **0%** for this
menu (only a generic CSV master import exists, see Web today). Worktree `orchwt/specs-batch`, main as of 2026-11-23.
Nothing was run against a real `.mdb` (none exists in the repo; plan decision OD-6).

## Scope

**Menu and form.** Caption `Data Import`, tab Other, smCode 15, edition `L` (Lite) in `docs/handbook/menu-editions.json:1363-1366`
("menu": "Data Import", "edition": "L"). `UT_IMPORT.cs` is 14,467 lines (the decompiled file; packet said about 535 lines for the Lite path).
The Lite path is only these members: `BtnLite_Click` 8413-8446, `Lite_AcMast` 8694-8783, `Wh_Item` 4241-4329,
`WH_AcOpbl` 4330-4362, `Lite_BarData` 8447-8693, `WH_ItOpbl` 3887-3962 (about 535 lines in all). Everything else in the file
(Wh Soft, Retail Soft, Plus Soft, Dhrn, Schm, Loan, Approval, Chudi, Jadtar and about 35 buttons) is out of scope.

**What "Lite" means here (changes the packet's premise).** `UT_IMPORT.cs` contains **no** `MsSoftType` check at all.
"Lite" is the name of the *source* product (an old DataCare Lite Access `.mdb`), not a branch on the running edition.
The only switch inside the form is a local string set by the button: UT_IMPORT.cs:8432 {{ImpSoftType = "Lite";}}, read in
`Wh_Item` at UT_IMPORT.cs:4262 {{if (Operators.CompareString(ImpSoftType, "Lite", false) == 0)}} and UT_IMPORT.cs:4297 {{if (Operators.CompareString(ImpSoftType, "Lite", false) == 0)}}. Edition flags act only outside the form, in the menu:

- Lite (`MsSoftType` = L) loads only MENU_DATA rows of type L: MDI_FORM.cs:11296 {{else if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)}}
  and MDI_FORM.cs:11299 {{SM_TYPE = 'L'}}. The other editions load a superset: MDI_FORM.cs:11257 {{SM_TYPE IN ('E','A','P','U','S','B','L')}}.
  So Data Import (edition L) is in every edition's list.
- It is then hidden unless the operator presses Ctrl+O: MDI_FORM.cs:11872 {{if (Operators.CompareString(((AccordionControlElementBase)SL15).Hint, "Data Import", false) == 0)}}
  followed by `Visible = false`, and revealed at MDI_FORM.cs:12597 {{if (((int)e.KeyCode == 79) & e.Control)}} with
  MDI_FORM.cs:12599 {{if (Operators.CompareString(((AccordionControlElementBase)SL15).Hint, "Data Import", false) == 0)}} then `Visible = true`.
  In Lite the Other tab keeps no "Extra" group: MDI_FORM.cs:10893 {{if (!((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0)))}}.

**Dispatch.** MDI_FORM.cs:8606 {{case "Data Import":}} then MDI_FORM.cs:8608 {{UT_IMPORT uT_IMPORT2 = new UT_IMPORT();}}, shown as an MDI child:
MDI_FORM.cs:8609 {{((Form)uT_IMPORT2).MdiParent = (Form)(object)this;}}. The same form also opens for the menu `Estimate Reset`
(MDI_FORM.cs:8843 {{UT_IMPORT uT_IMPORT = new UT_IMPORT();}}); that mode is a different feature (WP for Estimate Reset), out of scope. The form reads the
menu caption as its mode: UT_IMPORT.cs:3215 {{CurProcess = DC_Main.MsUserRightForm;}} and switches only for `Estimate Reset` at
UT_IMPORT.cs:3308 {{if (Operators.CompareString(CurProcess, "Estimate Reset", false) == 0)}}.

**Out of scope and why.** (1) Other-source buttons: they read other products' databases and need their own samples.
(2) `Estimate Reset` mode. (3) The SQL-server buttons (`btnWhSql`, `BtnBillWise`, UT_IMPORT.cs:14327 {{TrfrMdbName = DC_Main.MsTrfrSvr;}}).
(4) Bulk ETL of a desktop company: covered by WP-53 `orchestration/work/WP-53/cutover-design.md` (see Overlap below).

### Overlap and differences with WP-53 (cutover design)

| Point | WP-53 cutover | WP-25 Data Import (Lite Soft) |
|---|---|---|
| Source | SQL Server `.BAK` / `.mdf` of the Next desktop (cutover-design.md section 1.2, formats A-C) | Old Lite product Access `.mdb`, Jet OLEDB: UT_IMPORT.cs:3199 {{"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="}}. WP-53 lists it as format D, "Out of scope here" (cutover-design.md:78) |
| Who runs it | Our support person, staging host, two rehearsals, reconciliation suite | The shop operator, in the app, one click |
| Scope | Every table, full year of vouchers, tag stock, users | Masters, party and item **openings**, tag stock (as opening tags). **No vouchers, no history** |
| Target | New tenant | An existing, freshly created company (it deletes first, see Lifecycle) |
| Safety | Dry run, scoped load, exact-to-paisa reconcile, rollback | None: no transaction, no preview, no reconciliation, app exits at the end |
| Shared need | Same target tables AC_MAST, ITEM_MAST, OP_DATA, ITM_OPBL, BAR_*; same rules for opening dates and gold/silver fine | Reuse WP-53's load pipeline (column coercion, scoped replace, reconciliation) and add only a Lite `.mdb` extractor and the Lite mapping below |

Both writers must produce the same rows for the same company; WP-53's L2/L3 reconcile (party balances, stock by item, tag count) is the
acceptance test for WP-25 as well, with the Lite source-side totals computed from the `.mdb`.

## Screen

The form is `Old Softwar Import`: UT_IMPORT.cs:3187 {{((Form)this).Text = "Old Softwar Import";}} (typo is in the source), key preview on:
UT_IMPORT.cs:3185 {{((Form)this).KeyPreview = true;}}, border style fixed, docked and resized to the MDI at load (line 3237 and following).
Only controls that matter for the Lite path are listed. All other buttons are on the same form and visible; they are out of scope.

| Caption | Control | Type | Tab order | Default and rules |
|---|---|---|---|---|
| Old Software Import | lblBook | Label, top dock | 6 | UT_IMPORT.cs:1991 {{lblBook.Text = "Old Software Import";}}. Overwritten with the step name while importing (below) |
| (none) | ProgressBar1 | ProgressBar, at 0,383, 1309 x 23 | 1152 | no `Visible` line in the designer, so visible; set again at UT_IMPORT.cs:8421 {{((Control)ProgressBar1).Visible = true;}}. Maximum and value reset per step |
| &Lite Soft (Alt+L) | BtnLite | DevExpress SimpleButton at 533,235, 106 x 32 | 1163 | UT_IMPORT.cs:2328 {{BtnLite.Text = "&Lite Soft";}}; tooltip UT_IMPORT.cs:2329 {{((BaseControl)BtnLite).ToolTip = "Party Help";}} (copy-paste; wrong text). Hidden only in Estimate Reset mode (UT_IMPORT.cs:3319 {{((Control)BtnLite).Visible = false;}}) |
| (file picker) | DlgOpn | OpenFileDialog | n/a | filter and title set in the click: UT_IMPORT.cs:8426 {{((FileDialog)DlgOpn).Filter = "MDB (*.mdb)|*.mdb";}}, title `Open File` |
| &Save | BtnSave | in bottom panel | 0 | UT_IMPORT.cs:1966 {{BtnSave.Text = "&Save";}}; no Click handler wired for it in this form |
| &Print | BtnPrint | bottom panel | 1 | handler empty: UT_IMPORT.cs:3432 {{private void BtnPrint_Click(object sender, EventArgs e)}} |
| &Cancel | BtnCancel | bottom panel | 2 | clears text boxes only (line 3436-3440, CLEAR_DATA) |
| &Delete | BtnDelete | bottom panel | 3 | handler empty (line 3453-3456) |
| E&xit | BtnExit | bottom panel, right | 4 | UT_IMPORT.cs:1926 {{BtnExit.Text = "E&xit";}}; closes the form |

Panel `PnlBotam` is docked at the bottom, right-to-left flow: UT_IMPORT.cs:1908 {{((Control)PnlBotam).Dock = (DockStyle)2;}}. The date box `mClDate`
(tab 0) and `btnReSet` belong to Estimate Reset and are hidden by default (UT_IMPORT.cs:2078 {{((Control)mClDate).Visible = false;}}).
There is no file path text box, no company or year selector and no option check box: the operator picks only the `.mdb`.
The target company, location, year and user come from the running session (`MCo_code`, `MLc_code`, `MCo_year`, `MCo_User`).
No default is shown; the form has no focus rule for BtnLite.

Tab order across the whole form is the designer `TabIndex` values above; BtnLite (1163) is last in the field list, so the Tab key reaches it after the
many other buttons. Operators use Alt+L instead.

## Keyboard

- Esc closes the form: UT_IMPORT.cs:3424 {{if ((int)e.KeyCode == 27)}} then `Close()` (UT_IMPORT.cs:3426 {{((Form)this).Close();}}). No confirm, even during an import
  (the import runs on the UI thread, so Esc is only seen between `Application.DoEvents()` calls).
- Every typed character is forced to upper case and apostrophes are swallowed: UT_IMPORT.cs:3415 {{if (num == 0 || num == 39)}} (39 is `'`). Irrelevant for the Lite path (no text fields).
- Alt+L presses `&Lite Soft`; Alt+S, Alt+P, Alt+C, Alt+D, Alt+X are the bottom-panel mnemonics from the `&` captions.
- Ctrl+O on the MDI shell reveals the Data Import menu (see Scope). Double-click on the form background reveals six extra hidden buttons, none Lite:
  UT_IMPORT.cs:7404 {{((Control)btnDhrnAcUPdate).Visible = true;}}.
- Enter on `mClDate` is Estimate Reset only (UT_IMPORT.cs:3360 {{if ((int)e.KeyCode == 13)}}).

## Rules

Every validation and message of the Lite path. The path has only two dialogs and no field validation.

1. **Confirmation** (Yes/No, title is the company message title): UT_IMPORT.cs:8422 {{Interaction.MsgBox((object)"Are You Sure To Import Old Software Data In Next Software ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)}}.
   `(MsgBoxStyle)4` is Yes/No. Result 6 (Yes) continues: line 8422 `== 6`. Focus: none.
2. **File dialog**: if the operator cancels, the method returns silently: UT_IMPORT.cs:8428 {{if ((int)((CommonDialog)DlgOpn).ShowDialog() != 1)}} then `return;`. No message.
3. **Completion** (Information icon, no title): UT_IMPORT.cs:8444 {{Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);}}
   followed by UT_IMPORT.cs:8445 {{Application.Exit();}}. The whole program closes; the operator must log in again.
4. **Open-form rights** (outside the form, line 7047 of MDI_FORM): MDI_FORM.cs:7047 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}}
   when the USER_SET row for the caption has no `FRM_VIEW = 'Y'`.
5. **Not validated at all**: that the `.mdb` is a Lite file; that its `CO_CODE` equals the open company (every source query filters by the open company's code, e.g.
   UT_IMPORT.cs:8697 {{WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE > '00100'}}, so a mismatch imports zero rows and still reports "Process Are Complete");
   that the target company is empty; that anything failed. There is no error handler in the Lite path (no `try` in these members), so a bad column or a
   locked file raises an unhandled exception and the import stops half-way with data already deleted.

Progress text shown in `lblBook` per step: `Lite Software Import` (line 8420), then `Item Master` (UT_IMPORT.cs:4246 {{lblBook.Text = "Item Master";}}),
`Party Opning` (UT_IMPORT.cs:4341 {{lblBook.Text = "Party Opning";}}), `Bar Data` (UT_IMPORT.cs:8470 {{lblBook.Text = "Bar Data";}}) and `Item Opning`
(UT_IMPORT.cs:3898 {{lblBook.Text = "Item Opning";}}). The party master step sets no label.

## Calculations

Formulas in the order the Lite path applies them. `Fnv` turns DBNull, null and empty into 0: DC_Main.cs:2088 {{public static double Fnv(ref object Value)}}.

1. **Account (party) master clean-up.** Each of AC_ADD1, AC_ADD2, AC_ADD3 is blanked if it contains an apostrophe (to protect the string-built SQL): UT_IMPORT.cs:8727 {{if (Operators.CompareString(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(Imp["AC_ADD1"], (object)"")), DC_Main.M, 1), "'", false) == 0)}} then `text = ""`.
   Truncations: area name to 25, phones and mobiles to 11, PAN to 10, group code to 2 (see write set). No rounding.
2. **Party opening (OP_DATA).** The source sums the party ledger up to the *source company's closing date*, per party, as text with fixed decimals:
   UT_IMPORT.cs:4333 {{format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount}}, gold and silver fine as `'0.000'`: UT_IMPORT.cs:4333 {{format(SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as GoldWt}}.
   The date filter is UT_IMPORT.cs:4333 {{VCH_DATE <= #" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "#}} (`MCl_dt` is the open company's year close date, MS_OPNCOMP.cs:602 {{DC_Main.MCl_dt = Conversions.ToDate(DC_Main.Rshlp.Rows[0]["CL_DATE"]);}}).
   Parties whose three figures all sum to zero are dropped in the query (`HAVING ... <> 0`, line 4333) and again in code: UT_IMPORT.cs:4349 {{if (Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["Amount"])))}}. Stored value is the absolute value, sign is a separate code:
   `Amount > 0` gives `'C'` else `'D'` (UT_IMPORT.cs:4351 {{Interaction.IIf(Operators.ConditionalCompareObjectGreater(rshlp.Rows[DC_Main.M]["Amount"], (object)0, false), (object)"'C'", (object)"'D'")}}). The same rule for gold and silver fine. Note the HAVING adds money, gold and silver together (units mixed), so a party whose
   money and metal cancel in the sum is dropped although each is non-zero. This is a defect (see weaknesses).
3. **Item opening (ITM_OPBL).** Closing stock per item for non-tag stock, up to `MCl_dt`: UT_IMPORT.cs:3890 {{SUM(iif(SIGN = '+', ITM_PCS, -ITM_PCS)) AS ClPcs,SUM(iif(SIGN = '+',ITM_NWT,-ITM_NWT)) AS ClWt}}, amount as pieces times item rate:
   UT_IMPORT.cs:3890 {{SUM(iif(SIGN = '+', (ITM_PCS*B.ITEM_RATE), -(ITM_PCS*B.ITEM_RATE))) AS ItAmt}}. Only rows without a tag: UT_IMPORT.cs:3890 {{(A.TAG_NO = '' OR A.TAG_NO IS NULL)}}. Fine weight: UT_IMPORT.cs:3921 {{num = Conversions.ToDouble(Strings.Format((object)Conversion.Val((object)(num5 * num6 / 100.0)), "0.000"));}}
   (net weight x average touch / 100, formatted to three decimals; computed only when both are non-zero, line 3909-3911). A row is written when pieces, gross or net weight is non-zero: UT_IMPORT.cs:3925 {{if (Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ClWtGr"]))}}.
4. **Tag voucher numbering.** One opening voucher per item, numbered from `00001`: UT_IMPORT.cs:8479 {{text = Strings.Format((object)(Conversion.Val(text) + 1.0), "00000");}}. Within an item, `SR_NO` and `OLD_SRNO` equal a running tag counter that resets after each item's header row.
5. **Opening date** of every imported tag is the open company's opening date minus one day: UT_IMPORT.cs:8506 {{Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy")}}.

No rounding call other than the `"0.000"` and `"0.00"` formats above; every other number is copied through `Fnv` as a double and concatenated into the SQL text.

## Lifecycle and write set

The Lite path has one lifecycle only: **replace the whole company's masters and openings from a file**. There is no create, edit, delete or cancel.
There is **no transaction**: each statement runs on its own connection call. `ExeQuteDc` opens, runs and closes (DC_Main.cs:1313 {{public static void ExeQuteDc(string Sql)}}),
`ExeQuteMc` does the same for the main database (DC_Main.cs:1300 {{public static void ExeQuteMc(string Sql)}}). The source `.mdb` is read through one
long-lived OLEDB connection: UT_IMPORT.cs:3199 {{cnTrAcc.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + TrfrMdbName) ?? "";}}.
`Dc` is the year database, `Mc` the main database. Target scope is always `CO_CODE = DC_Main.MCo_code` (location `MLc_code`, year `MCo_year`).

**Order of the click** (line 8432-8441): set `ImpSoftType`, then in order

| Step | Call | Line |
|---|---|---|
| 1 | `Lite_AcMast()` | UT_IMPORT.cs:8433 {{Lite_AcMast();}} |
| 2 | `Wh_Item()` | UT_IMPORT.cs:8434 {{Wh_Item();}} |
| 3 | `WH_AcOpbl()` | UT_IMPORT.cs:8435 {{WH_AcOpbl();}} |
| 4 | `Lite_BarData()` | UT_IMPORT.cs:8436 {{Lite_BarData();}} |
| 5 | `WH_ItOpbl()` | UT_IMPORT.cs:8437 {{WH_ItOpbl();}} |
| 6 | house-keeping updates | line 8438-8441 |

### Step 1: party master, `Lite_AcMast`

- Delete: UT_IMPORT.cs:8696 {{DELETE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE >= '00101'}}. Codes 00001-00100 (the seeded system accounts) are kept.
- Read from the `.mdb`: UT_IMPORT.cs:8697 {{SELECT A.*,B.AREA_NAME FROM AC_MAST AS A LEFT JOIN AREA_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_AREA = B.AREA_CODE}}, rows with `AC_CODE > '00100'`.
  It is read twice, first only to count rows for the progress bar (line 8700-8705).
- Insert, one row per source row, columns in this order (line 8763): `CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_PERSON,AC_ADD1,AC_ADD2,AC_ADD3,AC_COUNTRY,AC_STATE,AC_DISTRICT,AC_CITY,AC_AREA,AC_PIN,AC_PHONE,AC_PHONE2,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_GSTNO,AC_GST_TYPE,AC_PANNO,AC_REF_CODE,AC_KHATA_NO,BR_DATE,L_BR_DATE,AN_DATE,AC_CR_DAYS,AC_INT_PRC,DPC_PRC,BANK_NAME,BANK_AREA,BANK_AC_NO,BANK_RTGS_NO,BANK_DETL,AC_TYPE,LAST_DATE,DATA_TRFR,MAIN_USER`.
  Mapping: `AC_CODE` and `AC_NAME` copied, `LC_CODE` literal `'00'` (UT_IMPORT.cs:8763 {{"', '00','"}}), `AC_MAIN_GR` from source `AC_MAIN_GR`, `AC_GR` = first two characters of source `AC_GR`,
  `AC_STATE`, `AC_CITY` copied, `AC_AREA` = source `AREA_NAME` left 25, `AC_GSTNO` = source `GST_NO`, `AC_GST_TYPE` = source `TAX_TYPE`, `BR_DATE` and `AN_DATE` as `MM/dd/yyyy` or `Null`,
  `L_BR_DATE` null, and the tail literals `'01/01/2010','N','ABC'` give `LAST_DATE` = 01/01/2010, `DATA_TRFR` = `N`, `MAIN_USER` = `ABC` (fixed, not the logged-in user).
  `AC_SHORT`, `AC_PERSON`, `AC_COUNTRY`, `AC_DISTRICT`, `AC_REF_CODE`, `AC_KHATA_NO`, `AC_TYPE` and the bank columns are blank; `AC_CR_DAYS`, `AC_INT_PRC`, `DPC_PRC` are 0.
- After the last row only, the party serial table is rebuilt: UT_IMPORT.cs:8765 {{if (DC_Main.i == DC_Main.X)}}, then UT_IMPORT.cs:8767 {{DC_Main.ExeQuteMc("DELETE FROM AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");}}
  and UT_IMPORT.cs:8768 {{INSERT INTO AC_MAST_SRNO(CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_GR) VALUES}} with **only the last imported party** (a defect: the table is then wrong for all other parties).
- Last: UT_IMPORT.cs:8779 {{DC_Main.ExeQuteDc("UPDATE CO_SET SET VB_IMPORT = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");}} and the in-memory flag UT_IMPORT.cs:8780 {{DC_Main.MsVbImport = "Y";}}.

### Step 2: item master, `Wh_Item` (Lite branch)

1. PRODUCT_MAST: delete UT_IMPORT.cs:4248 {{DELETE FROM PRODUCT_MAST WHERE CO_CODE}}, copy all source rows, columns UT_IMPORT.cs:4253 {{INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER) VALUES}}, `MAIN_USER` = logged-in user.
   Progress bar maximum 4 (UT_IMPORT.cs:4245 {{ProgressBar1.Maximum = 4;}}).
2. GROUP_MAST: delete line 4261, then the Lite branch UT_IMPORT.cs:4268 {{INSERT INTO GROUP_MAST(CO_CODE,GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,}}
   `GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_USER,TAX_PRC,AVG_TOUCH,AVG_FINE,AVG_NWT`. Copied: GR_CODE, GR_NAME, GR_TYPE, GR_TOUCH (to GR_TOUCH only, purchase touch 0), MELTING_PRC, GR_RATE,
   SALE_AC, PURC_AC, HSN_CODE; `TRAD_TYPE` blank; `MAIN_USER` is blank here; WEST_PRC, TAX_PRC and the three averages are 0. (The non-Lite branch at line 4280 maps more columns; not used.)
3. TABLE_MAST: delete line 4286, insert UT_IMPORT.cs:4291 {{INSERT INTO TABLE_MAST(CO_CODE,LC_CODE,TABLE_CODE,TABLE_NAME,MAIN_USER) VALUES}}; the source `CO_CODE` is written (not the open company's: UT_IMPORT.cs:4291 {{Imp["CO_CODE"]}}).
4. ITEM_MAST: delete UT_IMPORT.cs:4296 {{DELETE FROM ITEM_MAST WHERE CO_CODE}}, insert UT_IMPORT.cs:4303 {{INSERT INTO ITEM_MAST(CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,}}
   `ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,MIN_STK,AVG_TOUCH,AVG_FINE,AVG_NWT,AC_ITEM,MAIN_USER,STK_DISPLAY,SAFE_NAME`. Copied: IT_CODE, IT_NAME, IT_TYPE, TAG_TYPE, PR_CODE, GR_CODE,
   UNIT_NAME, RATE_TYPE, HSN_CODE, ITEM_RATE; `AC_ITEM` = IT_CODE; `STK_DISPLAY` = `Y`, `SAFE_NAME` = `MAIN`. All other numeric columns 0, so labour percent, touch and averages are **not** carried in Lite.
   Then UT_IMPORT.cs:4308 {{return;}} leaves `Wh_Item`, so the non-Lite item branch (which joins TABLE_MAST and carries labour, min stock and average touch) never runs for Lite.

### Step 3: party opening, `WH_AcOpbl`

- Delete UT_IMPORT.cs:4332 {{DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'}} (all openings of the company, not just parties).
- Insert one row per non-zero party, UT_IMPORT.cs:4351 {{INSERT INTO OP_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,}}
  `OP_AMT,OP_SIGN,FINE_BAL,FINE_SIGN,SL_FINE_BAL,SL_FINE_SIGN,DATA_TYPE,MAIN_USER,ADD_USER,ADD_DATE`. Values: `CO_BOOK` `'000'`, `VCH_NO` `'00000'`, `OP_AMT`/`FINE_BAL`/`SL_FINE_BAL` = absolute amount, gold, silver;
  signs C or D (Calculations 2); `DATA_TYPE` `'A'`; `MAIN_USER` = logged-in user; `ADD_USER` blank; `ADD_DATE` NULL.

### Step 4: tag stock, `Lite_BarData`

- Deletes, in order: UT_IMPORT.cs:8459 {{DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'}}, line 8460 BAR_DETL, line 8461 BAR_IDTL (all years of the company).
- Source list of items with tags: UT_IMPORT.cs:8462 {{FROM MAIN_TAG_DATA AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE}}, with `A.TAG_NO <> '' AND A.IT_CODE <> ''`
  and `A.CO_YEAR = MCo_year` (the source's current year). For each item, the item's tags are read from source `MAIN_TAG_DATA` joined to `BAR_DETL`; for each tag the source's latest `BAR_DETL` row
  (UT_IMPORT.cs:8492 {{ORDER BY VCH_DATE DESC}}, only row 0 is used) and its `BAR_IDTL` stone rows (UT_IMPORT.cs:8498 {{ORDER BY A.ISR_NO}}, matched on tag number **and** net weight) are read.
- Insert `BAR_DETL`, one row per tag: UT_IMPORT.cs:8505 {{INSERT INTO BAR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,}}
  columns `VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,KR_OTH_WT,KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,TAG_SRNO,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,MAIN_USER,ADD_USER,DATA_TRFR`.
  Fixed: `CO_BOOK` `'000'`, `VCH_NO` the item's opening voucher number, `VCH_DATE`/`STK_DATE`/`VCH_TIME` = opening date minus one day, `VCH_TYPE` = source book short name, `INOUT_TYPE` `'I'`, `ENTRY_TYPE` `'O'`
  (UT_IMPORT.cs:8505 {{"','I','O','"}}), `DESIGN_NO` = source `DESIGN` left 15, `TBL_CODE` `'001'`, `APR_ISU` `'N'`, `DATA_TRFR` `'N'`. Weights, touch, fine, labour, rate, amount, MRP, karigar columns are copied via `Fnv`; `KR_NAME` from source;
  `ITM_FINE` is copied twice (also into `KR_FINE`).
- Insert `BAR_IDTL`, one row per stone line, UT_IMPORT.cs:8611 {{INSERT INTO BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,}}
  columns `VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER`.
  `DM_CODE`, `DM_SIZE`, `DM_SFNO`, `DM_LEB` are blank literals (UT_IMPORT.cs:8611 {{'','','',''}}), so stone identity is lost; the quantities and amounts are kept.
- After each item's tags (only if at least one tag was inserted): UT_IMPORT.cs:8682 {{INSERT INTO BAR_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,AC_CODE,CUST_AC,}}
  with `OP_STK` `'Y'`, `VCH_DESC` blank, `HD_VCH_NO` = same voucher number, `MAIN_USER` = logged-in user, `DATA_TRFR` `'N'`. So the header is written **after** its detail rows.
  The `BAR_DATA` row carries no totals.

### Step 5: item opening, `WH_ItOpbl`

- Delete UT_IMPORT.cs:3889 {{DELETE FROM ITM_OPBL WHERE CO_CODE = '" + DC_Main.MCo_code + "'}}.
- Insert UT_IMPORT.cs:3927 {{INSERT INTO ITM_OPBL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,IT_CODE,VCH_NO,SR_NO,}} with `ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_FINE,ITM_RATE,ITM_AMT,LBR_AMT,OTH_AMT,NET_AMT,DM_WT,DM_RATE,DM_AMT,MAIN_USER,LBR_RATE`.
  `CO_BOOK` `'000'`; `IT_CODE` = item code left 5 (UT_IMPORT.cs:3927 {{Strings.Mid(Conversions.ToString(rshlp.Rows[DC_Main.M]["Code"]), 1, 5)}}); **`VCH_NO` is written with the item type** (`G`, `S`...: the value after the item code is `IT_TYPE`), `SR_NO` = row index + 1;
  `ITM_RATE` is computed fine (Calculations 3); `ITM_AMT` and `NET_AMT` = `ItAmt`; `LBR_AMT`, `OTH_AMT`, `DM_*` are 0; `LBR_RATE` 0.
  Tagged stock is not here: it is carried by BAR_* in Step 4.

### Step 6: close-out (line 8438-8441)

- Main-year flag: UT_IMPORT.cs:8438 {{DC_Main.ExeQuteDc("UPDATE HDD_MAST SET REF_NO = 'S'");}} (no where clause; every row).
- Opening date moved to today in both databases: UT_IMPORT.cs:8439 {{DC_Main.ExeQuteMc("UPDATE YEAR_MAST SET OP_DATE = '" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "' WHERE CO_CODE  = '" + DC_Main.MCo_code + "' ");}}
  and line 8440 (same, `ExeQuteDc`). Note: the tag and opening rows above were stamped with the *old* `MOp_dt` minus one day, so the new opening date is later than the stock date.
- Licence/trial date pushed ten days: UT_IMPORT.cs:8441 {{UPDATE LOCT_MAST SET TRY_DATE}} with `AddDays(10.0)`, company `'01'`, location `'00'` fixed.
- Messages and exit (Rules 3).

### Duplicate handling, masters vs transactions vs openings

- **Duplicates**: none handled. Every target table is wiped for the company first, then rows are inserted blind. A duplicate key inside the source raises a database error (no catch), leaving a half-loaded company.
  Re-running the import is allowed and simply repeats the wipe and load (idempotent only if the source is unchanged and the first run finished).
- **Masters** (replaced): AC_MAST (codes above 00100), AC_MAST_SRNO (one row), PRODUCT_MAST, GROUP_MAST, TABLE_MAST, ITEM_MAST.
- **Openings** (replaced): OP_DATA (parties, all of the company), ITM_OPBL (non-tag stock), BAR_DATA/BAR_DETL/BAR_IDTL (tag stock written as opening tags in book `000`).
- **Transactions**: **none imported**. No AC_DATA, no sales, purchase, receipt, voucher, order, approval, scheme or loan rows. History stays in the old software; only the closing position at `MCl_dt` is carried.
- **Recalculation after import**: none. No balance rebuild, no stock total, no serial-number sync beyond the one-row `AC_MAST_SRNO`. The only follow-up is `CO_SET.VB_IMPORT = 'Y'` and a forced program exit so the next login reloads settings.
  The flag has effects elsewhere: tag-number generation for the new year, DC_Main.cs:2120 {{if (Operators.CompareString(MsVbImport, "Y", false) != 0)}} (only runs when `Y`); opening-loan rows in the party ledger are skipped when `Y`: Ac_Ledr.cs:1519 {{(Operators.CompareString(DC_Main.MsVbImport, "Y", false) != 0)}}; party-image numbering and account-form rules change in MS_ACCT.cs:6560 {{if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)}}.

## Print

None. The Lite path prints nothing and uses no Crystal template. `BtnPrint` has an empty body (line 3432). No print-rights check applies; `UserPrint` is read at load
(UT_IMPORT.cs:3223 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}) and never used by this path.

## Rights

- Form open: MDI_FORM.cs:7041 {{DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + MsSideBtn + "' AND FRM_VIEW = 'Y'";}}
  with the message `You Have No Rights.....` (Rules 4). The form is still hidden behind Ctrl+O, but Ctrl+O is not rights-checked: anyone who can press it sees the menu entry, and the rights check applies only on click.
- The form loads its own row: UT_IMPORT.cs:3213 {{DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";}}
  and keeps `UserEdit`, `UserDelete`, `UserPrint` (line 3221-3223). **None of the three is tested before the Lite import runs**: any user with view right can wipe and reload the company.
- Super-user bypass `ABC` exists for User Create only (line 7033 of MDI_FORM).

## Desktop weaknesses not to port

1. Destructive replace with no preview, no backup and no transaction: line 8696 deletes parties first, line 4332 deletes all OP_DATA, and a failure leaves the company half loaded.
2. "No" on the confirmation still ends with the completion message and `Application.Exit()`: UT_IMPORT.cs:8444 {{Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);}} is outside the `if (... == 6)` block (the closing brace is at line 8443).
3. Success is claimed even when zero rows were read (wrong `CO_CODE`) and when the source lacks tables.
4. `AC_MAST_SRNO` rebuilt with a single row (line 8765).
5. Money, gold fine and silver fine are added in the `HAVING` filter (line 4333), which can drop a non-zero party.
6. Item opening amount is pieces times item master rate (UT_IMPORT.cs:3890 {{(ITM_PCS*B.ITEM_RATE)}}), not weight times rate, and uses the *new* master's rate, which Lite does not carry past ITEM_RATE.
7. `ITM_OPBL.VCH_NO` receives the item type (line 3927) and `IT_CODE` is cut to five characters.
8. SQL built by string concatenation with apostrophes handled by blanking the whole address (line 8727); a name with an apostrophe still breaks the insert.
9. Fixed `MAIN_USER` `ABC` and `LAST_DATE` 01/01/2010 on every party (UT_IMPORT.cs:8763 {{'01/01/2010','N','ABC'}}).
10. `HDD_MAST` update has no WHERE (line 8438); `LOCT_MAST.TRY_DATE` is moved by ten days without any reason shown (line 8441).
11. Only the latest `BAR_DETL` row per tag is used; stone rows matched on tag and net weight can attach to the wrong tag when two tags share a weight (line 8498).
12. Rights `FRM_EDIT`/`FRM_DELETE` are loaded and never checked; no audit row is written.
13. Jet OLEDB 4.0 is 32-bit Windows only; the web cannot use it.

## Web today

- `apps/api/src/app.ts:980` `POST /masters/:name/import`: takes JSON `rows` and calls `importMaster`; one transaction per row, returns `created`, `failed`, first 20 errors.
- `apps/api/src/modules/masters/master.service.ts:693-727` `importMaster`: loops `createMaster` for any configured master; its doc comment names `UT_IMPORT` but it implements none of its steps.
- `apps/api/src/modules/rbac/routePolicy.ts:1277` classifies the route as the `@master` form, action by method (so create right opens import).
- `apps/web/app/(app)/masters/[name]/page.tsx:324-346` `handleImport` and `:370-377`: "Import CSV" button on every master page, `accept=".csv,text/csv"`, messages `No data rows in CSV`, `Imported N, failed M ...`, `Import failed`.
- `apps/web/app/(app)/masters/styles/page.tsx:219` and `apps/web/app/(app)/txn/sale-return/page.tsx:257`: unrelated imports (style rows; sales-return pull).
- `apps/api/integration/cutover.mjs` (576 lines) and `apps/api/test/cutover.test.ts`: SQL Server to Postgres loader, dry-run only; load is blocked by `production-cutover-load` in `packages/core/containment.mjs:96`. WP-53 replaces it. No `.mdb` support.
- `apps/api/src/modules/ops/` (audit, backup, balanceTransfer, migrationManifest, yearEnd, seedCompany, ...) has no import or cutover module; `migrationManifest.ts` is the schema-migration checksum list, not data import.
- `apps/api/src/modules/settings/settingsCatalog.ts:110` lists `CO_SET.VB_IMPORT` as `SCHEMA_ONLY` (not read by any code).
- No `Data Import` string in `apps/web/app`; no menu entry, no page, no browser feature module. `docs/parity/FEATURE-MATRIX.md:53` records the row as NOT YET VERIFIED, "no browser feature module".
- No `.mdb` reader dependency in any `package.json` (checked: `mdb-reader`, `node-adodb`, `jackcess` absent).

## Gaps

1. **Menu entry and access.** Desktop: menu `Data Import` (edition L), hidden until Ctrl+O, dispatched at MDI_FORM.cs:8606 {{case "Data Import":}}. Web: absent (no menu, no route, no page). Fix: add the menu row for Other/Data Import behind an operator-only right and a deliberate reveal (a settings switch instead of a hidden key). Missing feature.
2. **Source file and reader.** Desktop: picks one `.mdb`, filter UT_IMPORT.cs:8426 {{((FileDialog)DlgOpn).Filter = "MDB (*.mdb)|*.mdb";}}. Web: absent; only CSV in `masters/[name]/page.tsx:373`. Fix: upload endpoint with size cap, run reader in a worker (no Jet; use a pure reader library or convert server-side), never execute anything from the file. Needs the synthetic `.mdb` of OD-6. Missing feature.
3. **Confirmation text.** Desktop: UT_IMPORT.cs:8422 {{"Are You Sure To Import Old Software Data In Next Software ?"}}. Web: absent. Fix: modal with this exact text, Yes/No, and **No must stop** (the desktop does not, weakness 2). Missing feature and wrong behaviour not to copy.
4. **Completion text.** Desktop: `Process Are Complete....` then exit (line 8444). Web: absent. Fix: show the same text after a reconcile summary; do not log the user out, instead refresh company settings. Missing feature.
5. **Party master mapping.** Desktop: the 42-column insert at line 8763, only codes above `00100`, blank-on-apostrophe, truncations 25/11/11/10/2. Web: `importMaster` can create a party row by row (`master.service.ts:695`) but has no Lite mapping, no `AC_MAST` column set and no 00100 floor. Fix: Lite mapper to the party master columns with the same truncations; keep the apostrophe rule out (bind parameters). Missing feature.
6. **Party serial table.** Desktop: one-row `AC_MAST_SRNO` at line 8768. Web: model exists (`packages/db/prisma/schema.prisma:146`), nothing writes it for import. Fix: rebuild it for all imported parties (do not copy the one-row defect). Wrong result if copied.
7. **Product, group, table and item masters.** Desktop: Wh_Item Lite branch (line 4253, 4268, 4291, 4303), group and table tied by code, early `return` at 4308. Web: generic CSV create only, no product/group/table/item bundle, no order and no replace. Fix: one import step that loads the four masters in this order, with the Lite column subset. Missing feature.
8. **Party openings.** Desktop: OP_DATA insert line 4351 with absolute value and `C`/`D` signs, `DATA_TYPE` `'A'`, per-party sum to the source closing date. Web: absent. Fix: write the same rows via the web opening-balance writer, reconcile total money, gold fine and silver fine to the source. Fix the mixed-unit HAVING (weakness 5) by testing each figure. Missing feature plus wrong result if copied.
9. **Tag stock.** Desktop: BAR_DETL/BAR_IDTL/BAR_DATA at line 8505, 8611, 8682, one opening voucher per item numbered `00001`, dated `MOp_dt - 1`. Web: absent for import (tag models exist). Fix: bulk writer producing the same three tables, header after detail inside one transaction, with tag count and net weight reconcile by item. Missing feature.
10. **Item opening.** Desktop: ITM_OPBL insert line 3927 with fine = net x touch / 100 to three decimals, non-tag rows only. Web: absent. Fix: reproduce the fine formula; do not copy `VCH_NO` = item type, the five-character cut, or pieces x rate amount. Missing feature plus wrong result if copied.
11. **Whole-company replace without safety.** Desktop: deletes at line 8696, 4332, 8459-8461, 3889, no transaction. Web: `importMaster` never deletes; WP-53 loader replaces tenant-wide (`cutover.mjs:450`, unsafe). Fix: run all steps in one database transaction, require an empty or "reset-allowed" company, write a run record (counts, operator, file hash) like `DataRepairRun`. Missing feature.
12. **Source company, year and location filter.** Desktop: filters by the open company only (line 8697) and silently imports zero rows on mismatch. Web: absent. Fix: read the source company list, require the operator to pick it, fail with a clear message if the picked code has no rows. Missing feature (desktop weakness 3).
13. **Rights.** Desktop: only view right at menu click (line 7047 of MDI_FORM), `UserEdit` and `UserDelete` loaded and unused (line 3221). Web: `/masters/:name/import` rides the master create right (`routePolicy.ts:1277`). Fix: separate `data-import` right, Super Admin default only, audit row on every run. Wrong right.
14. **Flag and follow-ups.** Desktop: `CO_SET.VB_IMPORT = 'Y'` (line 8779) switches tag-number generation and loan opening rules elsewhere. Web: `settingsCatalog.ts:110` lists it as SCHEMA_ONLY, no code reads it. Fix: write it and implement the three readers (`line 2120 of DC_Main`, `line 1519 of Ac_Ledr`, `line 6560 of MS_ACCT`) or record a decision to drop them. Missing feature.
15. **Close-out updates.** Desktop: `HDD_MAST.REF_NO = 'S'`, `YEAR_MAST.OP_DATE` today in both databases, `LOCT_MAST.TRY_DATE` + 10 days (line 8438-8441). Web: absent. Fix: decide per update (see Open questions 4); do not port the trial date change. Missing feature / wrong text risk.
16. **Progress texts.** Desktop: `Item Master`, `Party Opning`, `Bar Data`, `Item Opning` (line 4246, 4341, 8470, 3898). Web: absent. Fix: show the same step names (keep the spelling for case matching, or log it as accepted deviation). Wrong text if changed silently.
17. **Estimate of generic CSV import vs this feature.** Desktop: `UT_IMPORT` is the old-software importer; Excel master import is a separate hidden button in the party form (`party/page.tsx:41` comment). Web: `importMaster`'s doc comment (`master.service.ts:694`) claims "Desktop UT_IMPORT". Fix: correct the comment so the matrix is not misread; keep CSV as an extra, not parity. Wrong text (documentation).
18. **Reconciliation and rehearsal.** Desktop: none. Web: absent; WP-53 designs it for the SQL path. Fix: reuse WP-53 L1/L2 checks for the Lite subset (party balances money / gold / silver, stock by item, tag count) and run a dry-run mode that reads the `.mdb` and returns counts without writing. Missing feature.
19. **Test source.** Desktop: real `.mdb` (none in repo). Web: no fixture. Fix: script that builds a synthetic `.mdb` with the Lite schema from the queries above (OD-6), plus one blocked case for a real file. Missing prerequisite.

## Open questions

1. Is the old Lite `.mdb` the same schema across Lite versions (was `MAIN_TAG_DATA`, `MAIN_STOCK`, `BAR_DETL.KR_*` always present)? The source does not say; needs a real sample or the old product's schema.
2. The Lite `AC_GR` first two characters and `AC_MAIN_GR`: do they map to the same group codes as the Next seed? Not shown in `UT_IMPORT.cs`; needs the account-group seed comparison.
3. Should the web import be allowed on a company that already has vouchers? The desktop never checks. Owner decision (recommended: no).
4. Which close-out updates matter on the web: `HDD_MAST.REF_NO = 'S'` (meaning not found in the form), moving `YEAR_MAST.OP_DATE` to today, and the ten-day trial date. `HDD_MAST` is not read anywhere in the form; what `REF_NO = 'S'` means is not answered by the source here.
5. Should the stock date of imported tags stay `MOp_dt - 1`, while the company opening date is changed to today (line 8439)? The result is stock dated before the new opening date; owner to confirm intended.
6. The desktop's `LC_CODE` for parties is always `'00'` and `TABLE_MAST` keeps the source `CO_CODE`; for a multi-location tenant, which location receives them?
7. Whether the party `MAIN_USER` literal `ABC` is a service account that must exist on the web (WP-53 section 3.6 says seeded accounts must not appear in imported companies).
8. Member ranges not read in full: the whole of the non-Lite 14,000 lines of `UT_IMPORT.cs`, and the long string-built numeric tails of the BAR_DETL and BAR_IDTL value lists (line 8505-8610), where I confirmed the column lists and the fixed literals but not each `Fnv` operand's exact pairing with its column.
