# WP-17 cases: Report → Cash Bank (module `cash-bank-report`)

Source study: `orchestration/work/WP-17/study.md` (19 numbered gaps, Scope, Open questions).
Desktop authority: `unified/src/csharp/DataCareNext/RP_CASH_BANK.cs` (cash-and-bank mode only), `MDI_FORM.cs`, and the Crystal template `extraction_output/rpt_xml/AcLedger.xml`.
Method: `docs/master-parity-plan-2026-09-29/04-verification-playbook.md` section 3 (T01 to T18), with the Report addendum `docs/agent-prompts/lite/00b-REPORT-ADDENDUM.md`.

Scope: the cash-and-bank mode that the Lite edition reaches (`docs/handbook/menu-editions.json`, menu "Cash Bank", edition `L`). The Scheme Ledger mode, its panel, the passbook print and the JmUdr report are out of scope, as the study's Scope section records.

## How to read the cases

- **Layer.** `browser` = through the Report screen as an operator. `database` = a query of the seeded tables, or the absence of a write. `unit` = an arithmetic vector.
- **Dr and Cr columns.** These are the desktop's `DrAmt` and `CrAmt`. A line on account 00001 with `DR_AMT` 4000.00 and no `CR_AMT` is a Dr amount of 4000.00 in the grid. The running figure is `num2 - num` (Cr minus Dr), shown as an absolute value with a side (`Cr`, `Dr`, or blank when zero).
- **Zero cells.** A zero in columns 6 to 8 displays as blank. Expected values write such a cell as `blank`.
- **Opening row (`Op Balance`).** It is written only when the opening Dr plus Cr is not zero. Its Dr and Cr are added to the running sums, so the running figures and the totals include the opening. Totals are therefore opening plus period.
- **Seed A** and its variants are defined in `## Test data`. Every expected figure below is worked out from them.
- **Gap numbers** in each heading refer to the study's "Gaps" list. A case that names a gap fails on the web today because of that gap.
- **Citations.** Each desktop statement carries `FILE:LINE {{quote}}`, with the quote copied from that line. Template statements use `extraction_output/rpt_xml/AcLedger.xml`.

---

## Balance and totals (T03)

### cash-bank-report.balance.opening-row   (T03 Formula sequence; gaps 4)
Layer: browser
Steps: 1. Sign in with the right, open Report → Cash Bank. 2. Keep account 00001, From 01/11/2026, To 30/11/2026, Book empty. 3. Read the first row of the grid.
Expected: The first row has Sr 1, Book `Op Balance`, Dr `7,500.00`, Cr blank, Bal `7,500.00`, side `Dr`. Arithmetic: the pre-period lines L1 (DR 10000.00) and L2 (CR 2500.00) give CR minus DR = 2500.00 - 10000.00 = -7500.00, so DrAmt = abs(-7500.00) = 7500.00 and CrAmt = 0. Desktop rule: RP_CASH_BANK.cs:3222 {{Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) != 0.0}}; the label is RP_CASH_BANK.cs:3226 {{[1, num7].Value = "Op Balance";}}; the Dr copy is RP_CASH_BANK.cs:3227 {{[6, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"]);}}.
Status: executable

### cash-bank-report.balance.opening-zero-no-row   (T03 Formula sequence; gaps 4)
Layer: browser
Steps: 1. Open the report for account 00010 (TEST BANK) with From 01/11/2026, To 30/11/2026. Seed A has no line of 00010 before 01/11/2026. 2. Read the grid.
Expected: No `Op Balance` row. The first row is the 20/11/2026 CONTRA line (seed L5b, DR 1000.00): Sr 1, Dr `1,000.00`, Cr blank, Bal `1,000.00`, side `Dr`. The row is written only under the condition quoted in `balance.opening-row` (RP_CASH_BANK.cs:3222 {{Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) != 0.0}}).
Status: executable

### cash-bank-report.balance.opening-cr-side   (T03 Formula sequence; gaps 4, 5)
Layer: browser
Steps: 1. Use seed A plus line L10 (01/10/2026, CASH PAY, account 00001, CR 20000.00, counter-party 00102). 2. Open account 00001, From 01/11/2026, To 30/11/2026.
Expected: Opening CR minus DR = 20000.00 + 2500.00 - 10000.00 = 12500.00, so the `Op Balance` row shows Dr blank, Cr `12,500.00`, Bal `12,500.00`, side `Cr`. Desktop rule for the Cr copy: RP_CASH_BANK.cs:3228 {{[7, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"]);}}. Rows after it: R1 Dr 4000.00 gives Bal 8,500.00 Cr; R2 Cr 1500.00 gives 10,000.00 Cr; R3 Cr 1000.00 gives 11,000.00 Cr; R4 zero gives 11,000.00 Cr; R5 Dr 2000.00 gives 9,000.00 Cr. Totals Dr 6,000.00, Cr 15,000.00, Bal 9,000.00, side `Cr`. Check: 12500 - 4000 + 1500 + 1000 - 2000 = 9000.
Status: executable

### cash-bank-report.balance.running-side   (T03 Formula sequence; gaps 5)
Layer: browser
Steps: 1. Open seed A, account 00001, From 01/11/2026, To 30/11/2026. 2. Read Bal and the side of every row.
Expected: Rows (Sr, Dr, Cr, Bal, side): 1 Op 7,500.00 blank 7,500.00 Dr; 2 (05/11, voucher 3) 4,000.00 blank 11,500.00 Dr; 3 (12/11, voucher 4) blank 1,500.00 10,000.00 Dr; 4 (20/11, voucher 5) blank 1,000.00 9,000.00 Dr; 5 (22/11, voucher 7, zero) blank blank 9,000.00 Dr; 6 (25/11, voucher 6) 2,000.00 blank 11,000.00 Dr. Desktop rule: RP_CASH_BANK.cs:3296 {{((DataGridView)dGV_DETL2)[8, num7].Value = Math.Abs(num2 - num);}}; the side is RP_CASH_BANK.cs:3297 {{if (num2 - num > 0.0)}} for `Cr` and RP_CASH_BANK.cs:3301 {{else if (num2 - num < 0.0)}} for `Dr`. The web today returns no balance (gap 5).
Status: executable

### cash-bank-report.balance.zero-net-row-blank   (T03 Formula sequence; gaps 5, 7)
Layer: browser
Steps: 1. Use seed A. Voucher 7 (22/11/2026, CASH REC) has two lines on account 00001, CR 500.00 and DR 500.00, both with counter-party 00101. 2. Read the row for voucher 7.
Expected: One row (not two), Sr 5, Dr blank, Cr blank, Bal `9,000.00`, side `Dr`. The two lines are one group because the grouping key is book, voucher, date, ledger key and counter-party (see `row.grouping-one-row-per-voucher`). Net is 500.00 - 500.00 = 0, so both cells are zero and display blank: RP_CASH_BANK.cs:3360 {{Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0}}. The balance stays at the previous figure.
Status: executable

### cash-bank-report.balance.totals-row   (T03 Formula sequence; gaps 10)
Layer: browser
Steps: 1. Open seed A, account 00001, From 01/11/2026, To 30/11/2026. 2. Read the last row.
Expected: Label `Total :` in column 4, Dr `13,500.00`, Cr `2,500.00`, Bal `11,000.00`, side `Dr`. Arithmetic: Dr = opening 7500.00 + period 4000.00 + 2000.00 = 13500.00; Cr = 1500.00 + 1000.00 = 2500.00; Bal = |2500.00 - 13500.00| = 11000.00. Desktop rule: RP_CASH_BANK.cs:3321 {{Rows[num9].Cells[4].Value = "Total :";}}; RP_CASH_BANK.cs:3322 {{((DataGridView)DGV_DETL).Rows[num9].Cells[6].Value = num;}}; RP_CASH_BANK.cs:3323 {{((DataGridView)DGV_DETL).Rows[num9].Cells[7].Value = num2;}}; RP_CASH_BANK.cs:3324 {{((DataGridView)DGV_DETL).Rows[num9].Cells[8].Value = Math.Abs(num2 - num);}}. The totals include the opening because `num` and `num2` start from the opening row: RP_CASH_BANK.cs:3229 {{num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable.Rows[0]["DrAmt"]));}}.
Status: executable

### cash-bank-report.balance.totals-include-opening   (T03 Formula sequence; gaps 10)
Layer: unit
Steps: 1. Feed the kernel the seed A lines in date order, with the opening rule. 2. Compare with the grid's totals row.
Expected: Dr total 13500.00 = 7500.00 (opening) + 6000.00 (period). A total that counted only the period would be 6000.00 and is wrong. Cr total 2500.00. Vector: opening CR-DR = -7500.00; period CR-DR: -4000.00, +1500.00, +1000.00, 0.00, -2000.00; closing CR-DR = -11000.00, so side `Dr` and Bal 11000.00.
Status: executable

### cash-bank-report.balance.n2-display   (T03 Formula sequence; gaps 10)
Layer: browser
Steps: 1. Open seed A. 2. Read the Dr, Cr and Bal cells of the totals row as displayed.
Expected: `13,500.00`, `2,500.00`, `11,000.00`. Desktop rule: RP_CASH_BANK.cs:3196 {{((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N2";}}, with the same format for columns 7 and 8 at RP_CASH_BANK.cs:3200 {{((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N2";}} and RP_CASH_BANK.cs:3204 {{((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N2";}}. Two decimals always; the thousands separator follows the culture.
Status: executable

### cash-bank-report.balance.seed-a-hand-totals   (T03 Formula sequence; gaps 19)
Layer: database
Steps: 1. Load seed A in the isolated test database. 2. Run the grid query for account 00001 with the same From and To. 3. Compare every figure in every row (opening, five rows, totals) with the table in `balance.running-side`, and with a hand sum of the AC_DATA lines.
Expected: Every figure matches: opening Dr 7500.00; rows as in `balance.running-side`; totals 13500.00 / 2500.00 / 11000.00 Dr. The hand sum of `CR_AMT - DR_AMT` over the account's lines dated 01/11/2026 to 30/11/2026 is -3500.00, and the opening sum is -7500.00, so the closing sum is -11000.00 and the side is `Dr`. This is the value test that gap 19 says is missing; the other value cases in this file give the same figures per behaviour.
Status: executable

### cash-bank-report.balance.date-boundary-from-inclusive   (T03 Formula sequence; gaps 1)
Layer: browser
Steps: 1. Use seed A plus L9 (01/11/2026, CASH REC, account 00001, DR 100.00, counter-party 00101). 2. Open account 00001, From 01/11/2026, To 30/11/2026.
Expected: L9 is a detail row, not part of the opening, because the opening uses `<` From and the detail uses `>=` From. The opening is unchanged: Dr 7,500.00. Rows: 01/11 Dr 100.00 Bal 7,600.00 Dr; 05/11 Dr 4,000.00 Bal 11,600.00 Dr; 12/11 Cr 1,500.00 Bal 10,100.00 Dr; 20/11 Cr 1,000.00 Bal 9,100.00 Dr; 22/11 zero Bal 9,100.00 Dr; 25/11 Dr 2,000.00 Bal 11,100.00 Dr. Totals Dr 13,600.00, Cr 2,500.00, Bal 11,100.00 Dr. Desktop rules: opening RP_CASH_BANK.cs:3160 {{and A.VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}}; detail RP_CASH_BANK.cs:3162 {{and A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}}.
Status: executable

---

## Date window, account and book filters (T02, T06)

### cash-bank-report.filter.default-dates   (T01 Entry/defaults; gaps 1)
Layer: browser
Steps: 1. Open Report → Cash Bank from a clean session, with no changes. 2. Read From and To.
Expected: From and To both equal the system date of the session. Desktop rules: RP_CASH_BANK.cs:3103 {{mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);}} and RP_CASH_BANK.cs:3105 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}. The `01/01/2010` default is scheme mode only (RP_CASH_BANK.cs:3099 {{mFromDt.Text = "01/01/2010";}}) and must not appear. The cursor starts in From: RP_CASH_BANK.cs:3122 {{((Control)mFromDt).Focus();}}. The grid fills at activation: RP_CASH_BANK.cs:3129 {{DGV_DETL_FILL();}}.
Status: executable

### cash-bank-report.filter.date-window-from   (T02 Field route; gaps 1)
Layer: browser
Steps: 1. Use seed A. 2. Set From to 05/11/2026 and To to 30/11/2026. 3. Refill the grid by Enter in Party Code. 4. Read the rows.
Expected: The opening holds the lines dated before 05/11/2026, which are L1 and L2 only: Dr 7,500.00. Voucher 3 (05/11, Dr 4,000.00) is a detail row, because 05/11 is not before 05/11. Rows and totals then follow seed A: 13,500.00 / 2,500.00 / 11,000.00 Dr. Desktop rule: RP_CASH_BANK.cs:3162 {{and A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}}. Fails today (gap 1): the web ignores the window.
Status: executable

### cash-bank-report.filter.date-window-to   (T02 Field route; gaps 1)
Layer: browser
Steps: 1. Use seed A (it includes L8, dated 02/12/2026, DR 999.00). 2. Open account 00001, From 01/11/2026, To 30/11/2026. 3. Read the rows.
Expected: L8 does not appear, and it is not in the opening (it is after From). Totals as seed A: 13,500.00 / 2,500.00 / 11,000.00 Dr. Desktop rule: RP_CASH_BANK.cs:3162 {{AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")}}. Fails today (gap 1).
Status: executable

### cash-bank-report.filter.from-after-to   (T06 Required/invalid; gaps 1)
Layer: browser
Steps: 1. Use seed A. 2. Set From 15/11/2026 and To 10/11/2026. 3. Refill the grid by Enter in Party Code.
Expected: No message box and no refusal. The desktop has no check here: the detail rows need a date that is both on or after 15/11 and on or before 10/11, so none match. The opening is all lines before 15/11/2026: L1 -10000.00, L2 +2500.00, voucher 3 -4000.00, voucher 4 +1500.00, total -10000.00, so one `Op Balance` row with Dr `10,000.00`. No other row. The totals row is not asserted, because its second condition (RP_CASH_BANK.cs:3315 {{if (((DataGridView)DGV_DETL).Rows.Count >= 1 && Conversions.ToBoolean(}}) was not read in full. Fails today (gap 1).
Status: executable

### cash-bank-report.filter.empty-period   (T06 Required/invalid; gaps 1)
Layer: browser
Steps: 1. Use seed A plus L8 (02/12/2026, DR 999.00). 2. Set From 03/12/2026 and To 05/12/2026. 3. Refill the grid.
Expected: No detail row. The opening is all lines before 03/12/2026: -11000.00 - 999.00 = -11999.00, so one `Op Balance` row with Dr `11,999.00`. No message. Desktop rules: the opening query RP_CASH_BANK.cs:3160 {{and A.VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}} and the row condition RP_CASH_BANK.cs:3222 {{Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) != 0.0}} (quoted in `balance.opening-row`).
Status: executable

### cash-bank-report.filter.date-change-no-refresh   (T02 Field route; gaps 1)
Layer: browser
Steps: 1. Use seed A. 2. Change To to 25/11/2026 and press Enter in the To box. 3. Read the grid without pressing Enter in Party Code or Book.
Expected: Blocked (see Status). Desktop behaviour: Enter in a date box validates the date and moves on, and does not refill the grid. RP_CASH_BANK.cs:4648 {{DC_Main.SetDate(ref MsDate);}} validates, and RP_CASH_BANK.cs:4652 {{SendKeys.Send("{tab}");}} moves on. The grid refills later, on Enter in Party Code or Book, or on activation.
Status: blocked: owner decision. Whether the web refreshes on a date change is a desktop-first question. Porting the desktop as is leaves a grid that does not match the dates on screen. Decide before the case is run.

### cash-bank-report.filter.one-account-only   (T02 Field route; gaps 2)
Layer: browser
Steps: 1. Use seed A. 2. Open the report for account 00001. 3. Look for any line of account 00010 (TEST BANK), whose name contains `BANK`.
Expected: No line of 00010 appears, and the opening does not include 00010's lines. One account is shown, the one in Party Code. Desktop rule: RP_CASH_BANK.cs:3162 {{AND A.AC_CODE = '" + tAcCode.Text + "'}} and the same condition in the opening query at RP_CASH_BANK.cs:3160 {{AND A.AC_CODE = '" + tAcCode.Text + "'}} (quoted in `balance.date-boundary-from-inclusive` for the date part). Fails today (gap 2): the web merges every account whose code contains `CASH` or whose name contains `CASH` or `BANK`.
Status: executable

### cash-bank-report.filter.book-filter   (T02 Field route; gaps 3)
Layer: browser
Steps: 1. Use seed A. 2. Set Book to the CO_BOOK code of the CASH REC book. 3. Press Enter in Book. 4. Read the grid.
Expected: Opening: only L1 (CASH REC), Dr `10,000.00`, Bal `10,000.00`, side `Dr`, Sr 1. Rows: voucher 3 (05/11, Dr 4,000.00, Bal 14,000.00 Dr) and voucher 7 (zero row, Bal 14,000.00 Dr). CASH PAY, CONTRA and SALES lines are not shown. Totals Dr `14,000.00`, Cr blank (zero), Bal `14,000.00`, side `Dr`. Desktop rules: RP_CASH_BANK.cs:3162 {{AND A.CO_BOOK = '" + tBookCode.Text + "'}} and the same filter on the opening at RP_CASH_BANK.cs:3160 {{Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0}}. Fails today (gap 3): there is no book input.
Status: executable

### cash-bank-report.filter.book-empty-all   (T02 Field route; gaps 3)
Layer: browser
Steps: 1. Use seed A with Book set as in the previous case. 2. Clear Book and press Enter in Book.
Expected: The grid returns to seed A (all books): Dr 13,500.00, Cr 2,500.00, Bal 11,000.00 `Dr`. With an empty book box the filter is omitted (RP_CASH_BANK.cs:3162 {{Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0}}) and the name box is cleared: RP_CASH_BANK.cs:4728 {{tBookName.Text = "";}}.
Status: executable

### cash-bank-report.filter.book-unknown-code   (T06 Required/invalid; gaps 3)
Layer: browser
Steps: 1. Use seed A. 2. Type Book `ZZZ` (no such book) and press Enter in Book.
Expected: No message. No detail row, and no `Op Balance` row (no line of this book exists). The desktop has no check here: the refill runs the query and shows what it returns. The totals row is not written when there are no rows (RP_CASH_BANK.cs:3315 {{if (((DataGridView)DGV_DETL).Rows.Count >= 1 && Conversions.ToBoolean(}}). The grid is empty.
Status: executable

### cash-bank-report.filter.data-type-rule   (T02 Field route; gaps 3)
Layer: database
Steps: 1. Seed a company whose data type is `A`, and seed lines with data type `B`. 2. Run the grid and the print for account 00001.
Expected: Blocked (see Status). The grid applies a data-type filter for every type except `C` (RP_CASH_BANK.cs:3162 {{Operators.CompareString(DC_Main.MsDataType, "C", false) == 0}}). The print applies a filter only for `A` (RP_CASH_BANK.cs:3552 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}}) and for `B` (RP_CASH_BANK.cs:3556 {{else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)}}). The study's weakness 3 says the two rules differ.
Status: blocked: the value of DC_Main.MsDataType for a Lite company is set in MDI_FORM.cs (around lines 12732 to 12790, not read in the study), and the grid and the print rules disagree. The owner must choose one rule for the screen, the totals and the print before this case can be run.

---

## Account lookup (T04)

### cash-bank-report.account.default-00001   (T01 Entry/defaults; gaps 2)
Layer: browser
Steps: 1. Open Report → Cash Bank from a clean session. 2. Read Party Code and the name box.
Expected: Party Code `00001`, name `CASH ON HAND`. Desktop rules: RP_CASH_BANK.cs:3118 {{tAcCode.Text = "00001";}} and RP_CASH_BANK.cs:3119 {{tAcName.Text = "CASH ON HAND";}}. Fails today (gap 2): the web starts with every cash and bank account.
Status: executable

### cash-bank-report.account.enter-found   (T04 Lookup; gaps 17)
Layer: browser
Steps: 1. Use seed A. 2. Type Party Code `00010` and press Enter. 3. Read the name box and the grid.
Expected: Name `TEST BANK`, focus stays in Party Code, and the grid refills with the 00010 lines: one row, 20/11/2026, CONTRA, Dr `1,000.00`, Bal `1,000.00` `Dr`, party name `CASH ON HAND` (the counter-party of that line is 00001). Desktop rules: RP_CASH_BANK.cs:3691 {{tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));}} and RP_CASH_BANK.cs:3619 {{if ((int)e.KeyCode != 13)}}. Fails today (gap 17): there is no lookup.
Status: executable

### cash-bank-report.account.enter-not-found-help   (T04 Lookup; gaps 17)
Layer: browser
Steps: 1. Use seed A and location 01. 2. Type Party Code `99999` and press Enter. 3. Read the help list that opens.
Expected: The account help list opens as a modal dialog (RP_CASH_BANK.cs:3677 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}). For location 01 the query is a union: accounts with code below 100 (any group), and accounts with code 200 or more in groups `02, 03, 19, 21, 22, 23`. The codes below 100 are `AND CAST(C.AC_CODE AS INT) < 100` (RP_CASH_BANK.cs:3661 {{AND CAST(C.AC_CODE AS INT) < 100}}). Seed A rows: `00001 CASH ON HAND` and `00010 TEST BANK`. `00101` and `00102` are not shown, because their codes are 101 and 102. The help list's own column captions were not read and are not asserted.
Status: executable

### cash-bank-report.account.help-choose-row   (T04 Lookup; gaps 17)
Layer: browser
Steps: 1. From the help list in the previous case, choose `00001 CASH ON HAND`. 2. Read Party Code, the name box and the grid.
Expected: Code `00001`, name `CASH ON HAND`, and the grid refills for 00001 (seed A rows). The chosen row sets the code and name, then the grid refills: RP_CASH_BANK.cs:3684 {{DGV_DETL_FILL();}}.
Status: executable

### cash-bank-report.account.help-location-00   (T04 Lookup; gaps 17)
Layer: browser
Steps: 1. Set the test session to location `00`. 2. Enter an unknown Party Code and read the help list.
Expected: Blocked (see Status). For location `00` the help list is the group list only: RP_CASH_BANK.cs:3659 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}}. The text of the group-only query was not read, so the rows the list must show are not stated.
Status: blocked: the group-only query text after RP_CASH_BANK.cs:3659 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}} was not read. Read it in the desktop, then fill the expected rows.

### cash-bank-report.account.name-readonly   (T04 Lookup; gaps 17)
Layer: browser
Steps: 1. Use seed A. 2. Click into the name box and type a letter.
Expected: Blocked (see Status).
Status: blocked: owner decision. Study open question 3: the designer sets no read-only flag on `tAcName` (RP_CASH_BANK.cs:1682 {{((Control)tAcName).TabIndex = 1129;}}), so editability is inferred, not confirmed. Confirm in the desktop (run it, or read the designer's properties) before choosing the web behaviour.

---

## Columns, rows and text (T01, T02, T03)

### cash-bank-report.columns.order-and-captions   (T01 Entry/defaults; gaps 8)
Layer: browser
Steps: 1. Open seed A. 2. Read the column headers from left to right.
Expected: Ten visible columns in this order: `Sr`, `Book`, `VchNo`, `Date`, `Party Name`, `Area`, `Dr Amt`, `Cr Amt`, `Bal Amt`, `CrDr`. Desktop rules: RP_CASH_BANK.cs:3179 {{Columns.Add("", "Sr");}}, RP_CASH_BANK.cs:3183 {{Columns.Add("", "Book");}}, RP_CASH_BANK.cs:3185 {{Columns.Add("", "VchNo");}}, RP_CASH_BANK.cs:3187 {{Columns.Add("", "Date");}}, RP_CASH_BANK.cs:3189 {{Columns.Add("", "Party Name");}}, RP_CASH_BANK.cs:3191 {{Columns.Add("", "Area");}}, RP_CASH_BANK.cs:3193 {{Columns.Add("", "Dr Amt");}}, RP_CASH_BANK.cs:3197 {{Columns.Add("", "Cr Amt");}}, RP_CASH_BANK.cs:3201 {{Columns.Add("", "Bal Amt");}}, RP_CASH_BANK.cs:3205 {{Columns.Add("", "CrDr");}}. The web has no Area column and no balance column (gap 5 and gap 8).
Status: executable

### cash-bank-report.row.voucher-book-and-number   (T02 Field route; gaps 8)
Layer: browser
Steps: 1. Use seed A. 2. Read Book and VchNo of the 05/11/2026 row.
Expected: Book `CASH REC` and VchNo `3` in two separate cells (voucher 3 is seed R1). Desktop rules: RP_CASH_BANK.cs:3257 {{dataTable2.Rows[DC_Main.M]["BOOK_NAME"]}} and RP_CASH_BANK.cs:3258 {{dataTable2.Rows[DC_Main.M]["VCH_NO"]}}. Fails today (gap 8): the web prints one string `CO_BOOK/VCH_NO`.
Status: executable

### cash-bank-report.row.date-format   (T02 Field route; gaps 9)
Layer: browser
Steps: 1. Use seed A. 2. Read the Date column of every row.
Expected: Dates in `dd/MM/yyyy`; for the rows of seed A: `05/11/2026`, `12/11/2026`, `20/11/2026`, `22/11/2026`, `25/11/2026`. Desktop rule: RP_CASH_BANK.cs:3259 {{Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy")}}. Fails today (gap 9): the web returns the raw date value. How the page renders it was not checked (study open question 5).
Status: executable

### cash-bank-report.row.party-name-counter-party   (T02 Field route; gaps 6)
Layer: browser
Steps: 1. Use seed A. 2. Read Party Name for voucher 3 (CASH REC, counter-party 00101), voucher 4 (CASH PAY, counter-party 00102) and voucher 5 (CONTRA, counter-party 00010).
Expected: `PARTY ALPHA`, `PARTY BETA` and `TEST BANK`. These books are not SALES, PURCHASE or MEMB ENTRY, so the name is the account name of the counter-party. Desktop rules: the join RP_CASH_BANK.cs:3162 {{LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.LD_CODE = C.AC_CODE}} and the name RP_CASH_BANK.cs:3289 {{dataTable2.Rows[DC_Main.M]["AC_NAME"]}}. Fails today (gap 6): the web shows the name of the cash account itself.
Status: executable

### cash-bank-report.row.party-name-sales   (T02 Field route; gaps 6)
Layer: browser
Steps: 1. Use seed A. Voucher 6 is a SALES line (25/11/2026, DR 2000.00) with counter-party 00102 (PARTY BETA). The SL_DATA row for the same book and voucher has AC_NAME `PARTY ALPHA`. 2. Read Party Name of that row.
Expected: `PARTY ALPHA`, from the SL_DATA row, not from the counter-party account (`PARTY BETA`). Desktop rules: RP_CASH_BANK.cs:3261 {{(object)"SALES", false))}} takes the name from the SALES row, through RP_CASH_BANK.cs:3263 {{dataView.RowFilter = }}; the SL_DATA source is RP_CASH_BANK.cs:3154 {{SELECT CO_BOOK,VCH_NO,AC_NAME FROM SL_DATA}}. Fails today (gap 6).
Status: executable

### cash-bank-report.row.grouping-one-row-per-voucher   (T03 Formula sequence; gaps 7)
Layer: database
Steps: 1. Use seed A. 2. Count the detail rows for account 00001 in the period.
Expected: Five detail rows: vouchers 3, 4, 5, 6 and 7 (voucher 7 once, although it has two lines). The web returns one row per AC_DATA line, so it returns six rows for this period and fails (gap 7). Desktop rule: RP_CASH_BANK.cs:3162 {{GROUP BY B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.LEDR_KEY,A.LD_CODE}}.
Status: executable

### cash-bank-report.row.hidden-codes-not-shown   (T01 Entry/defaults; gaps 8)
Layer: browser
Steps: 1. Use seed A. 2. Look at every visible column. 3. Open the Excel export and check its header.
Expected: No visible column carries the book code, the account code or the main book. The desktop adds them as hidden columns: RP_CASH_BANK.cs:3208 {{((DataGridView)DGV_DETL).Columns.Add("", "CoBook");}}, RP_CASH_BANK.cs:3210 {{((DataGridView)DGV_DETL).Columns.Add("", "AcCode");}}, RP_CASH_BANK.cs:3212 {{((DataGridView)DGV_DETL).Columns.Add("", "MainBook");}}. The study states that columns 10 to 12 are hidden; the line that hides them was not read, so this case asserts the absence of the three codes on screen and nothing more. The grid also shows no fine-weight column: gold and silver are computed in the SQL, RP_CASH_BANK.cs:3162 {{As DrGold}}, but no column shows them (study Calculations, step 7).
Status: executable

---

## Title and menu (T01)

### cash-bank-report.title.banner-caption   (T01 Entry/defaults; gaps 18)
Layer: browser
Steps: 1. Open Report → Cash Bank. 2. Read the banner above the grid.
Expected: The banner reads `Cash Bank`, the menu caption. The designer text `Cash and Bank Report` (RP_CASH_BANK.cs:1667 {{lblBook.Text = "Cash and Bank Report";}}) is replaced on Load by the caption: RP_CASH_BANK.cs:2828 {{lblBook.Text = CurRpt;}}, where `CurRpt` is the caption passed from the menu: RP_CASH_BANK.cs:2827 {{CurRpt = DC_Main.MsUserRightForm;}}. The menu switch uses the same caption: MDI_FORM.cs:8941 {{case "Cash Bank":}}. Fails today (gap 18): the web title is `Cash / Bank Book`.
Status: executable

### cash-bank-report.title.menu-label   (T01 Entry/defaults; gaps 18)
Layer: browser
Steps: 1. Sign in as a Lite user with the right. 2. Read the Report menu entry and its label.
Expected: The menu entry is `Cash Bank`, and it is listed for the Lite edition. The desktop list is built with the Lite branch: MDI_FORM.cs:11296 {{else if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)}} and MDI_FORM.cs:11299 {{AND SM_TYPE = 'L' ORDER BY BTN_NAME,SM_CODE}}. The edition table row: docs/handbook/menu-editions.json:1553 {{"menu": "Cash Bank",}}, with edition `L` on the next line (docs/handbook/menu-editions.json:1554 {{"edition": "L",}}). Fails today (gap 18): the web label is `Cash / Bank Book`.
Status: executable

---

## Drill-down (T05)

### cash-bank-report.drilldown.sales   (T05 Children; gaps 12)
Layer: browser
Steps: 1. Use seed A. 2. Double-click the row of voucher 6 (SALES, 25/11/2026).
Expected: The sales voucher form opens on voucher 6. The desktop opens TR_SALE when the setting is not `Y`: RP_CASH_BANK.cs:3741 {{"SALES", false) == 0)}} selects the SALES branch, RP_CASH_BANK.cs:3743 {{if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)}} selects the HM-tax form, and RP_CASH_BANK.cs:3752 {{TR_SALE tR_SALE = new TR_SALE();}} opens the plain form. That the form then finds voucher 6 is inferred from the stored book and number (study Lifecycle step 5). Assert that the sales screen opens on voucher 6. Fails today (gap 12): the web sets no row handler.
Status: executable

### cash-bank-report.drilldown.sales-hm-tax   (T05 Children; gaps 12)
Layer: browser
Steps: 1. Set the company setting for HM tax on sales to `Y`. 2. Double-click the sales row of voucher 6.
Expected: Blocked (see Status).
Status: blocked: the Lite web sales screen for the HM-tax setting is not confirmed by this study. The desktop opens the HM-tax form on that branch (RP_CASH_BANK.cs:3743 {{if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)}}). Confirm the web screen first.

### cash-bank-report.drilldown.purchase   (T05 Children; gaps 12)
Layer: browser
Steps: 1. Use a seed with a PURCHASE line in the account's grid. 2. Double-click that row.
Expected: Blocked (see Status).
Status: blocked: the desktop branch for PURCHASE opens TR_PURC_HM or TR_PURC (RP_CASH_BANK.cs:3758 {{"PURCHASE", false) == 0)}}). The condition that chooses between them was not read in the study. Read it, then assert the form.

### cash-bank-report.drilldown.cash-rec   (T05 Children; gaps 12)
Layer: browser
Steps: 1. Use seed A. 2. Double-click the row of voucher 3 (CASH REC, 05/11/2026).
Expected: The cash and bank voucher form (TR_CASH) opens on voucher 3. Desktop rule: RP_CASH_BANK.cs:3813 {{"CASH REC", false) == 0)}} opens the cash voucher form.
Status: executable

### cash-bank-report.drilldown.cash-pay   (T05 Children; gaps 12)
Layer: browser
Steps: 1. Use seed A. 2. Double-click the row of voucher 4 (CASH PAY, 12/11/2026).
Expected: TR_CASH opens on voucher 4. Desktop rule: RP_CASH_BANK.cs:3820 {{else if (Operators.CompareString(DC_Main.CurBookMain, "CASH PAY", false) == 0)}}.
Status: executable

### cash-bank-report.drilldown.bank-rec   (T05 Children; gaps 12)
Layer: browser
Steps: 1. Use seed A plus a BANK REC line on account 00001 (26/11/2026, DR 300.00, counter-party 00010). 2. Double-click that row.
Expected: TR_CASH opens on that voucher. Desktop rule: RP_CASH_BANK.cs:3827 {{else if (Operators.CompareString(DC_Main.CurBookMain, "BANK REC", false) == 0)}}.
Status: executable

### cash-bank-report.drilldown.bank-pay   (T05 Children; gaps 12)
Layer: browser
Steps: 1. Use seed A plus a BANK PAY line on account 00001 (27/11/2026, CR 300.00, counter-party 00010). 2. Double-click that row.
Expected: TR_CASH opens on that voucher. Desktop rule: RP_CASH_BANK.cs:3834 {{else if (Operators.CompareString(DC_Main.CurBookMain, "BANK PAY", false) == 0)}}.
Status: executable

### cash-bank-report.drilldown.contra   (T05 Children; gaps 12)
Layer: browser
Steps: 1. Use seed A. 2. Double-click the row of voucher 5 (CONTRA, 20/11/2026).
Expected: The contra voucher form (TR_CONTRA) opens on voucher 5. Desktop rule: RP_CASH_BANK.cs:3848 {{"CONTRA", false) == 0)}} opens `TR_CONTRA`.
Status: executable

### cash-bank-report.drilldown.sales-order   (T05 Children; gaps 12)
Layer: browser
Steps: 1. Use seed A plus a SALES ORDER line on account 00001. 2. Double-click that row.
Expected: The sales order form (TR_SALE_ORD) opens on that voucher. Desktop rule: RP_CASH_BANK.cs:3734 {{if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)}}.
Status: executable

### cash-bank-report.drilldown.unconfirmed-books   (T05 Children; gaps 12)
Layer: browser
Steps: 1. Use a seed with a line of each book: MEMB OPENING, FINE SALE, ITEM SALES, ITEM PURC. 2. Double-click each row.
Expected: Blocked (see Status).
Status: blocked: these books open forms that are not confirmed as Lite screens, or whose forms this study did not read (study open question 2). MEMB OPENING is at RP_CASH_BANK.cs:3890 {{"MEMB OPENING", false) == 0))}}, FINE SALE at RP_CASH_BANK.cs:4117 {{"FINE SALE", false) == 0)}}, and the ITEM branches follow the study's Lifecycle list. Decide the Lite scope of each book before this case is run.

### cash-bank-report.drilldown.opening-row-no-open   (T05 Children; gaps 12)
Layer: browser
Steps: 1. Use seed A. 2. Double-click the `Op Balance` row.
Expected: Blocked (see Status).
Status: blocked: the opening row writes no value to the hidden book column (the opening writes columns 1, 6, 7, 8 and 9 only, RP_CASH_BANK.cs:3226 {{[1, num7].Value = "Op Balance";}}). The drill-down reads column 10 (RP_CASH_BANK.cs:3711 {{.Cells[10].Value}}), and the result of a book lookup with an empty key was not read. Read it, then assert that no form opens.

---

## Reset, cancel and delete (T10)

### cash-bank-report.reset.cancel-clears-all   (T10 Delete/cancel/reverse; gaps 16)
Layer: browser
Steps: 1. Use seed A with Book set to the CASH REC code and From set to 05/11/2026. 2. Click Cancel. 3. Read every control.
Expected: Book is empty; From and To equal the system date; Party Code `00001`; name `CASH ON HAND`; the grid refills for account 00001 with the default dates; focus is in From. Desktop rules: every text box is emptied (RP_CASH_BANK.cs:3089 {{val.Text = "";}}), the dates reset (RP_CASH_BANK.cs:3103 {{mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}), the account resets (RP_CASH_BANK.cs:3118 {{tAcCode.Text = "00001";}}), the grid refills (RP_CASH_BANK.cs:3120 {{DGV_DETL_FILL();}}), and the Cancel handler runs only the reset (RP_CASH_BANK.cs:3594 {{CLEAR_DATA();}}). Fails today (gap 16): the web has no reset control.
Status: executable

### cash-bank-report.reset.delete-button-inert   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Open the report. 2. Look for a Delete button. 3. Press it if one is shown.
Expected: Blocked (see Status).
Status: blocked: owner decision. The desktop shows a Delete button (RP_CASH_BANK.cs:1568 {{BtnDelete.Text = "&Delete";}}) whose click handler is empty (RP_CASH_BANK.cs:2785 {{private void BtnDelete_Click(object sender, EventArgs e)}}). Study weakness 5 says not to port a control that does nothing, so the expected web result is no Delete button. The owner must confirm before the case is run.

---

## Scope, rights and editions (T11)

### cash-bank-report.scope.company-sentinel   (T11 Scope/rights)
Layer: database
Steps: 1. Use seed A plus a company 02 line on account 00001 (05/11/2026, DR 888.00). 2. Run the grid as company 01.
Expected: The company 02 line appears nowhere: not in the grid, the opening or the totals. Totals remain 13,500.00 / 2,500.00 / 11,000.00 Dr. Desktop rule: RP_CASH_BANK.cs:3162 {{WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'}}.
Status: executable

### cash-bank-report.scope.location-sentinel   (T11 Scope/rights; gaps 11)
Layer: database
Steps: 1. Use seed A plus a location 02 line on account 00001 (05/11/2026, DR 777.00). 2. Run the grid as location 01.
Expected: The location 02 line appears nowhere. Totals remain 13,500.00 / 2,500.00 / 11,000.00 Dr. Desktop rule: RP_CASH_BANK.cs:3162 {{AND A.LC_CODE = '" + DC_Main.MLc_code + "'}}. Fails today (gap 11): the web filters only on company.
Status: executable

### cash-bank-report.scope.year-sentinel   (T11 Scope/rights; gaps 11)
Layer: database
Steps: 1. Use seed A plus a line of company year 2025-26 on account 00001 (06/11/2026, DR 333.00). 2. Run the grid and the print.
Expected: the 2025-26 line (DR 333.00) appears neither in the grid nor in the print, and neither the opening balance nor the totals include it; the figures are exactly those of seed A alone.
Status: executable (supervisor decision, 16 November 2026: the session's company year is applied on the screen and in the print, because the desktop keeps each year in its own database). Background: the desktop grid has no company-year filter (RP_CASH_BANK.cs:3162 {{WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "'}} filters on company, location and account only), but the print has one: RP_CASH_BANK.cs:3547 {{{AC_DATA.CO_YEAR} = '}}. So the screen would show the 2025-26 line and the print would not. The owner must choose one rule.

### cash-bank-report.rights.menu-no-right   (T11 Scope/rights)
Layer: browser
Steps: 1. Sign in as a user with no `USER_SET` row for Cash Bank with `FRM_VIEW = 'Y'`. 2. Open the report by its menu entry, and by a direct request to the report's route.
Expected: The report is refused: no menu entry opens and no grid rows are returned. Desktop rules: RP_CASH_BANK.cs is not involved; the Report tab check is MDI_FORM.cs:7041 {{AND FRM_VIEW = 'Y'}}, and with no row it shows MDI_FORM.cs:7047 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}}. The web's own refusal text is not given by the study; the desktop text is the reference.
Status: executable

### cash-bank-report.rights.ctrl-f11-no-right   (T11 Scope/rights)
Layer: browser
Steps: 1. As the user in the previous case, press Ctrl+F11.
Expected: The desktop message `You Have No Rights.....` and no form. Desktop rules: MDI_FORM.cs:14419 {{DC_Main.MsUserRightForm = "Cash Bank";}}, MDI_FORM.cs:14420 {{AND FRM_VIEW = 'Y'}}, and the message at MDI_FORM.cs:14425 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}}.
Status: executable

### cash-bank-report.rights.ctrl-f11-edition   (T01 Entry/defaults; gaps 2)
Layer: browser
Steps: 1. As a Lite user with the right, press Ctrl+F11.
Expected: Blocked (see Status).
Status: blocked: study open question 1. The Ctrl+F11 handler does not read the edition (MDI_FORM.cs:14416 {{private void F11CtrlCashBankToolStripMenuItem_Click(object sender, EventArgs e)}}), and whether a Lite operator can reach it depends on a menu item visibility that the study did not read.

### cash-bank-report.rights.excel-no-print   (T11 Scope/rights; gaps 14)
Layer: browser
Steps: 1. Sign in as a user with the view right and without `FRM_PRINT = 'Y'`. 2. Open the report with seed A and press Excel.
Expected: The message `You Have No Print Rights.....` and no export. Desktop rules: RP_CASH_BANK.cs:2389 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}} and the message at RP_CASH_BANK.cs:2540 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}. Web: the generic `export.xlsx` is guarded by the print right (gap 14), so a refusal exists, but its text is not the desktop's.
Status: executable

### cash-bank-report.rights.print-no-right-no-desktop-check   (T11 Scope/rights; gaps 13)
Layer: browser
Steps: 1. Sign in as a user with the view right and without the print right. 2. Press Print with seed A.
Expected: Blocked (see Status). The web must refuse the print. The desktop Print button has no right check: RP_CASH_BANK.cs:3461 {{private void BtnPrint_Click(object sender, EventArgs e)}} has no `FRM_PRINT` test. This is a deliberate difference from the desktop: the web adds a check that the desktop does not have. Note it in the pull request.
Status: blocked: owner decision on the refusal text. The desktop has no message for this case; its only print-right text is RP_CASH_BANK.cs:2540 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}.

---

## Output and print (T16)

### cash-bank-report.print.template-regions   (T16 Report/output; gaps 13)
Layer: browser
Steps: 1. Use seed A. 2. Press Print. 3. Read the regions and the column headings of the print preview.
Expected: The print uses the layout `AcLedger` (RP_CASH_BANK.cs:3570 {{DC_Main.RptName = "AcLedger";}}). Page-header column headings: `Debit Rs` (extraction_output/rpt_xml/AcLedger.xml:452 {{<Text>Debit Rs</Text>}}), `Credit Rs` (extraction_output/rpt_xml/AcLedger.xml:465 {{<Text>Credit Rs</Text>}}), `Ac Name` (extraction_output/rpt_xml/AcLedger.xml:478 {{<Text>Ac Name</Text>}}) and `Balance` (extraction_output/rpt_xml/AcLedger.xml:511 {{<Text>Balance</Text>}}). Group-header caption `Opening Balance :` (extraction_output/rpt_xml/AcLedger.xml:581 {{<Text>Opening Balance :</Text>}}). Group-footer captions `Transaction Total :` (extraction_output/rpt_xml/AcLedger.xml:836 {{<Text>Transaction Total :</Text>}}) and `Closing Balance :` (extraction_output/rpt_xml/AcLedger.xml:917 {{<Text>Closing Balance :</Text>}}). The print headings differ from the grid headings (`Dr Amt`, `Cr Amt`, `Bal Amt`); the template's captions govern the print. Fails today (gap 13): the web has no Crystal layout.
Status: executable

### cash-bank-report.print.title-parameter   (T16 Report/output; gaps 13)
Layer: browser
Steps: 1. Use seed A. 2. Press Print. 3. Read the title of the print.
Expected: Title `Cash and Bank Report From 01/11/2026 To 30/11/2026`. The desktop builds it: RP_CASH_BANK.cs:3563 {{DC_Main.MsRptTitelStr = "'Cash and Bank Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";}}. The template default `"TRIAL BALANCE AS ON DATE"` (extraction_output/rpt_xml/AcLedger.xml:349 {{"TRIAL BALANCE AS ON DATE"}}) is replaced through the `RptTitel` parameter (RP_CASH_BANK.cs:3562 {{DC_Main.MsRptTitel = "RptTitel";}}).
Status: executable

### cash-bank-report.print.opening-amount-unfiltered   (T16 Report/output; gaps 13)
Layer: browser
Steps: 1. Use seed A with Book empty. 2. Press Print. 3. Read the `Opening Balance` value.
Expected: `-7500.00` (signed, Cr positive, as the template computes it). This is the same opening as the grid (Dr 7,500.00), in the print's sign convention. Desktop rules: the opening query RP_CASH_BANK.cs:3541 {{SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE}}, formatted by RP_CASH_BANK.cs:3545 {{Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00")}}, and passed as RP_CASH_BANK.cs:3583 {{Cr[(short)3] = ("AcOpAmt = " + Strings.Format((object)num8, "0.00")) ?? "";}}. The template's opening takes this value: extraction_output/rpt_xml/AcLedger.xml:285 {{NumberVar AcBal := {@AcOpAmt} ;}}. How the sign is shown on the page (minus sign, brackets or a label) is not read from the field format, so the case asserts the value only.
Status: executable

### cash-bank-report.print.opening-with-book   (T16 Report/output; gaps 13)
Layer: browser
Steps: 1. Use seed A with Book set to CASH REC. 2. Press Print. 3. Read the `Opening Balance` value and compare with the grid's opening (Dr 10,000.00).
Expected: Blocked (see Status).
Status: blocked: owner decision (study open question 4). The desktop print opening ignores the book filter (RP_CASH_BANK.cs:3541 {{WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE < '}} has only company, location, account and date), while the grid opening applies it (RP_CASH_BANK.cs:3160 {{Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0}}). The printed opening would be -7500.00 and the grid 10,000.00 Dr. The study records that the source does not say which one the business expects.

### cash-bank-report.print.totals-and-closing   (T16 Report/output; gaps 10, 13)
Layer: browser
Steps: 1. Use seed A. 2. Press Print. 3. Read `Transaction Total` and `Closing Balance`.
Expected: Transaction Total Dr `13,500.00` and Cr `2,500.00`; Closing Balance `11,000.00`, side `Dr`. The template's totals include the opening. The Dr total is `abs({@AcOpAmt}) + Sum ({@DrRs}, {AC_DATA.AC_CODE})` when the opening is below zero: extraction_output/rpt_xml/AcLedger.xml:323 {{if {@AcOpAmt} &lt; 0 then}}. The Cr total is `{@AcOpAmt} + Sum ({@CrRs}, {AC_DATA.AC_CODE})` when the opening is above zero: extraction_output/rpt_xml/AcLedger.xml:307 {{if {@AcOpAmt} &gt; 0 then}}. For seed A: Dr 7500.00 + 6000.00 = 13500.00; Cr 2500.00 (the else branch, Sum of CrRs). The closing `BalDiff` is `{@CrTotAmt}-{@DrTotAmt}` = 2500.00 - 13500.00 = -11000.00. The side is `Dr` by the template's rule: extraction_output/rpt_xml/AcLedger.xml:350 {{if {@AcBalance} &lt; 0 then}}.
Status: executable

### cash-bank-report.print.balance-zero-side   (T16 Report/output; gaps 10)
Layer: unit
Steps: 1. Use a balance of exactly zero (for example, a line of CR 100.00 and a line of DR 100.00 with no opening).
Expected: Blocked (see Status).
Status: blocked: owner decision. The template's side formula returns `Dr` below zero and `Cr` otherwise (extraction_output/rpt_xml/AcLedger.xml:350 {{if {@AcBalance} &lt; 0 then}}, with the else branch `'Cr'`), while the grid shows a blank side for zero (RP_CASH_BANK.cs:3297 {{if (num2 - num > 0.0)}}, then the blank branch for zero). The desktop disagrees with itself. The owner must choose.

### cash-bank-report.print.balance-column-format   (T16 Report/output; gaps 10)
Layer: unit
Steps: 1. Read the Balance column of the printed page for seed A.
Expected: Blocked (see Status).
Status: blocked: the template's running balance is signed (extraction_output/rpt_xml/AcLedger.xml:277 {{AcBal := AcBal + {@CrRs} - {@DrRs};}}), while the grid shows the absolute value with a side. The number format of the printed Balance field is not in the read of the template, so the printed form cannot be asserted.

### cash-bank-report.print.excel-rows-and-totals   (T16 Report/output; gaps 14)
Layer: database
Steps: 1. Use seed A. 2. Press Excel (the right is present). 3. Open the workbook and read every row.
Expected: One row per grid row, in grid order: the `Op Balance` row, five detail rows, and the `Total :` row (seven grid rows, plus the header row). Dr and Cr totals in the last row: 13,500.00 and 2,500.00. Desktop rule: the export loop runs over the grid rows: RP_CASH_BANK.cs:2656 {{num13 = ((DataGridView)DGV_DETL).RowCount - 1;}} and RP_CASH_BANK.cs:2660 {{if (DC_Main.i <= num13)}}. Excel writes the grid, not a query of its own. Fails today (gap 14): the web exports the rows that `cashBook` returns, one per AC_DATA line.
Status: executable

### cash-bank-report.print.excel-bold-and-autofit   (T16 Report/output; gaps 14)
Layer: browser
Steps: 1. Use seed A. 2. Press Excel and open the workbook.
Expected: The first row is bold: RP_CASH_BANK.cs:2671 {{"FontStyle", new object[1] { "Bold" }}}. Columns are autofitted: RP_CASH_BANK.cs:2687 {{"AutoFit", new object[0]}}. Excel is made visible: RP_CASH_BANK.cs:2703 {{"Visible", new object[1] { true }}}. Nothing is written to the database (study Lifecycle).
Status: executable

### cash-bank-report.print.excel-column-set   (T16 Report/output; gaps 14)
Layer: browser
Steps: 1. Use seed A. 2. Press Excel. 3. Compare the set of columns in the workbook with the grid.
Expected: Blocked (see Status).
Status: blocked: the export loop runs over the column indexes from 0 to RP_CASH_BANK.cs:2645 {{num12 = ((DataGridView)DGV_DETL).ColumnCount - 1;}}, but whether hidden columns 10 to 12 are written was not read. Read the loop body that follows line 2645, then assert the column set.

### cash-bank-report.print.generic-export-layout   (T16 Report/output; gaps 14)
Layer: browser
Steps: 1. Use seed A. 2. Export CSV, Excel and PDF from the report page.
Expected: Blocked (see Status).
Status: blocked: study open question 6. The column layout of the generic CSV, Excel and PDF exports for this report was not read. Read the generic export code, then assert the layout against the desktop's grid captions.

---

## Keyboard (T17)

### cash-bank-report.keyboard.tab-order   (T17 Keyboard/usability; gaps 15)
Layer: browser
Steps: 1. Open the report. 2. Press Tab from From, and read the focused control after each press, for four presses.
Expected: Focus visits From (TabIndex 0), To (TabIndex 1), Party Code (TabIndex 2), then Print (TabIndex 3). The TabIndex values are: RP_CASH_BANK.cs:2023 {{((Control)mFromDt).TabIndex = 0;}}, RP_CASH_BANK.cs:2015 {{((Control)mToDt).TabIndex = 1;}}, RP_CASH_BANK.cs:1675 {{((Control)tAcCode).TabIndex = 2;}}, and RP_CASH_BANK.cs:1607 {{((Control)BtnPrint).TabIndex = 3;}}. The order after the button panel depends on TabIndex 1129 (name, RP_CASH_BANK.cs:1682 {{((Control)tAcName).TabIndex = 1129;}}), 1133 (grid, RP_CASH_BANK.cs:1746 {{((Control)DGV_DETL).TabIndex = 1133;}}) and 1162 (book, RP_CASH_BANK.cs:2031 {{((Control)tBookCode).TabIndex = 1162;}}), and on whether the name box takes focus (study open question 3). Assert the first four stops only.
Status: executable

### cash-bank-report.keyboard.enter-from-moves-on   (T17 Keyboard/usability; gaps 15)
Layer: browser
Steps: 1. Type `01/11/2026` in From. 2. Press Enter.
Expected: Focus moves to To, and the grid does not refill (see `filter.date-change-no-refresh`). The focus move is done directly, not with simulated keystrokes. Desktop rules: RP_CASH_BANK.cs:4645 {{if ((int)e.KeyCode == 13)}}, RP_CASH_BANK.cs:4648 {{DC_Main.SetDate(ref MsDate);}}, RP_CASH_BANK.cs:4652 {{SendKeys.Send("{tab}");}}. The web should move focus directly (study weakness 8).
Status: executable

### cash-bank-report.keyboard.enter-to-moves-on   (T17 Keyboard/usability; gaps 15)
Layer: browser
Steps: 1. Type `30/11/2026` in To. 2. Press Enter.
Expected: Focus moves to Party Code. Desktop rules: RP_CASH_BANK.cs:4661 {{if ((int)e.KeyCode == 13)}} and RP_CASH_BANK.cs:4668 {{SendKeys.Send("{tab}");}}.
Status: executable

### cash-bank-report.keyboard.enter-party-refills   (T17 Keyboard/usability; gaps 15, 17)
Layer: browser
Steps: 1. Type `00010` in Party Code. 2. Press Enter. 3. Read the name and the grid. Repeat with the keyboard only.
Expected: As in `cash-bank-report.account.enter-found`: name `TEST BANK`, grid refilled, focus stays in Party Code. Desktop rule: RP_CASH_BANK.cs:3619 {{if ((int)e.KeyCode != 13)}}.
Status: executable

### cash-bank-report.keyboard.enter-book-refills   (T17 Keyboard/usability; gaps 15)
Layer: browser
Steps: 1. Type the CASH REC book code in Book. 2. Press Enter.
Expected: The grid refills as in `filter.book-filter`. Desktop rules: RP_CASH_BANK.cs:4690 {{if ((int)e.KeyCode != 13)}} and RP_CASH_BANK.cs:4722 {{DGV_DETL_FILL();}}.
Status: executable

### cash-bank-report.keyboard.esc-closes   (T17 Keyboard/usability; gaps 15)
Layer: browser
Steps: 1. Open the report. 2. Press Esc.
Expected: The report closes. In cash mode Esc is not a scheme-mode Back. Desktop rules: RP_CASH_BANK.cs:3442 {{if ((int)e.KeyCode == 27)}} and the close RP_CASH_BANK.cs:3456 {{((Form)this).Close();}}.
Status: executable

### cash-bank-report.keyboard.enter-in-grid-no-action   (T17 Keyboard/usability; gaps 15)
Layer: browser
Steps: 1. Select a grid row with the keyboard. 2. Press Enter, then press Enter again.
Expected: Nothing happens. No drill-down opens on Enter; only a double-click drills down. The grid's only drill-down wiring is RP_CASH_BANK.cs:545 {{((Control)val2).DoubleClick += eventHandler;}}, and no KeyDown handler is set for the detail grid (study Keyboard section).
Status: executable

### cash-bank-report.keyboard.upper-case-codes   (T17 Keyboard/usability; gaps 15)
Layer: browser
Steps: 1. Type `ab` in Party Code.
Expected: Party Code shows `AB`. The desktop converts every typed letter to upper case: RP_CASH_BANK.cs:3429 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}. For codes this is kept. Study weakness 7 says not to copy the rule for text that is not a code, so the name box and any free text keep the typed case.
Status: executable

### cash-bank-report.keyboard.focus-direct   (T17 Keyboard/usability; gaps 15)
Layer: browser
Steps: 1. Type a valid date in From, press Enter, and check the focused element. 2. Repeat while another window (the help list) has focus.
Expected: Focus moves to To directly, in both cases. No keystroke is simulated. Study weakness 8: RP_CASH_BANK.cs:4652 {{SendKeys.Send("{tab}");}} misfires when another window has focus.
Status: executable

---

## History, journey and not applicable

### cash-bank-report.history.live-party-name   (T15 Config/history; gaps 6)
Layer: browser
Steps: 1. Use seed A. 2. Rename party 00101 from PARTY ALPHA to PARTY ALPHA RENAMED. 3. Reopen the report.
Expected: The CASH REC row (voucher 3) shows `PARTY ALPHA RENAMED`, because the counter-party name is read live from AC_MAST at each query: RP_CASH_BANK.cs:3162 {{LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.LD_CODE = C.AC_CODE}}. The SALES row (voucher 6) still shows `PARTY ALPHA`, because its name comes from the SL_DATA row: RP_CASH_BANK.cs:3154 {{SELECT CO_BOOK,VCH_NO,AC_NAME FROM SL_DATA}}. Fails today (gap 6).
Status: executable

### cash-bank-report.journey.cash-and-bank-entries   (T18 Full journey)
Layer: browser
Steps: 1. Start from an empty company. 2. Enter through their own screens: a cash receipt of 3000.00 from PARTY ALPHA, a cash payment of 1200.00 to PARTY BETA, a bank receipt of 5000.00 from PARTY ALPHA into TEST BANK, and a contra of 800.00 from cash to bank. 3. Open Report → Cash Bank for account 00001, then for account 00010, over a window that covers all four. 4. Read each row, the totals and the balance.
Expected: Blocked (see Status). The amounts give the figures to check: for account 00001, the cash receipt (3000.00) and the cash payment (1200.00) and the contra (800.00) must show on the sides the screens write, giving a balance of 1000.00 Dr (3000.00 Dr against 2000.00 Cr). For account 00010 the bank receipt (5000.00 Dr) and the contra (800.00 Dr) give 5800.00 Dr. Each row must carry the right side, balance and totals.
Status: blocked: the side of each AC_DATA line that the cash and contra screens write is not in this study. The voucher writer is not in `TR_CASH.cs`: its only AC_DATA mentions are a balance query (TR_CASH.cs:2702 {{Select AC_CODE,Sum(CR_AMT-DR_AMT) as Amount}}) and a delete (TR_CASH.cs:3071 {{DELETE FROM AC_DATA WHERE CO_CODE}}). Read the save path of TR_CASH and TR_CONTRA (the shared writer), then state the sides and run this case. The owner must also confirm whether the bank receipt and the contra use the same cash-line convention.

### cash-bank-report.journey.edit-and-cancel-follow   (T18 Full journey)
Layer: browser
Steps: 1. Use the journey data. 2. Edit the amount of the cash receipt. 3. Cancel the contra through its screen. 4. Reopen the report.
Expected: Blocked (see Status).
Status: blocked: depends on the edit and cancel rules of TR_CASH and TR_CONTRA, which are not in this study (see the previous case). The report itself writes nothing.

### cash-bank-report.write.create   (T07 Create)
Layer: database
Steps: 1. Not run.
Expected: N/A. The report writes nothing in cash mode: every query is a `SELECT` (study Lifecycle, "Writes in the cash-and-bank mode: none"). The only `DELETE` and `INSERT` in the form belong to the scheme passbook temporary table: RP_CASH_BANK.cs:3475 {{DELETE FROM TEMP_AD_DATA WHERE CO_CODE}}, which runs in scheme mode only.
Status: N/A: the report is read-only in cash mode, so there is no voucher to create (Report addendum: T07 to T10 and T12 to T14 do not apply to a report).

### cash-bank-report.write.reopen-no-op   (T08 Reopen/no-op)
Layer: browser
Steps: 1. Not run.
Expected: N/A. Nothing is saved, so there is no reopened document to compare. Reopening the report is covered by `cash-bank-report.filter.default-dates`.
Status: N/A: the report has no saved document.

### cash-bank-report.write.edit   (T09 Edit)
Layer: database
Steps: 1. Not run.
Expected: N/A. The report has no editable field that writes. The desktop loads the edit right and never reads it again: RP_CASH_BANK.cs:2833 {{UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));}} (the study's Rights table records the same for edit).
Status: N/A: a report writes nothing.

### cash-bank-report.lookup.stale-result   (T04 Lookup)
Layer: browser
Steps: 1. Not run.
Expected: N/A. The desktop lookup is synchronous: Enter runs the query and fills the box (RP_CASH_BANK.cs:3619 {{if ((int)e.KeyCode != 13)}} to RP_CASH_BANK.cs:3691 {{tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));}}). No delayed response exists on the desktop to reject. Stale-result rejection on the web is a web-layer concern, covered by the generic request tests.
Status: N/A: no desktop rule applies to a stale response.

### cash-bank-report.concurrency.two-sessions   (T12 Concurrency)
Layer: database
Steps: 1. Not run.
Expected: N/A. A report reads and writes nothing, so there is no state that two sessions can race over.
Status: N/A: read-only report.

### cash-bank-report.retry.unknown-ack   (T13 Retry/unknown)
Layer: database
Steps: 1. Not run.
Expected: N/A. A read has no financial effect to duplicate.
Status: N/A: read-only report.

### cash-bank-report.rollback.partial-write   (T14 Rollback)
Layer: database
Steps: 1. Not run.
Expected: N/A. There is no write, so there is no rollback path.
Status: N/A: read-only report.

---

## Not covered

Behaviours in the study that no executable case covers. Each has a reason; the owner questions are the ones the owner must answer.

1. **Ctrl+F11 for Lite operators (study open question 1).** Blocked: `cash-bank-report.rights.ctrl-f11-edition`. Owner question: may a Lite operator open the report by Ctrl+F11, or must the shortcut honour the Lite edition?
2. **Voucher forms reached by drill-down (study open question 2).** Blocked for MEMB OPENING, FINE SALE, the ITEM branches and the HM-tax variant. Owner question: which of these voucher forms belong to the Lite edition?
3. **Editability of the name box and the grid (study open question 3).** Blocked: `cash-bank-report.account.name-readonly`. Owner question: may an operator type into the name box or edit grid cells?
4. **Print opening versus grid opening when a book is selected (study open question 4).** Blocked: `cash-bank-report.print.opening-with-book`. Owner question: which opening is correct?
5. **How the web page renders dates (study open question 5).** Not read. `cash-bank-report.row.date-format` fails until it is read, so it is not a blind pass.
6. **Generic CSV, Excel and PDF layout (study open question 6).** Blocked: `cash-bank-report.print.generic-export-layout`.
7. **Data-type rule for screen, totals and print (study weakness 3).** Blocked: `cash-bank-report.filter.data-type-rule`. Owner question: which rule applies? The desktop grid and print disagree, and the Lite value of MsDataType was not read.
8. **Company year on the screen (gap 11).** Decided by the supervisor on 16 November 2026: the session's company year is applied on the screen and in the print (the desktop keeps each year in its own database). The case `cash-bank-report.scope.year-sentinel` is executable. The owner may confirm.
9. **Date change does not refill the grid (desktop behaviour).** Blocked: `cash-bank-report.filter.date-change-no-refresh`. Owner question: does the web refresh on a date change?
10. **Zero balance: the grid shows blank, the print shows `Cr`.** Blocked: `cash-bank-report.print.balance-zero-side`. Owner question: which side should a zero balance show?
11. **Visible Delete button with an empty handler (study weakness 5).** Blocked: `cash-bank-report.reset.delete-button-inert`. Owner question: should the web show a Delete button at all?
12. **Print refusal without the print right (deliberate difference).** Blocked: `cash-bank-report.rights.print-no-right-no-desktop-check`. Owner question: what text does the web show, since the desktop Print button has no check?
13. **Help list for location 00 (group-only query).** Blocked: `cash-bank-report.account.help-location-00`. The query text after RP_CASH_BANK.cs:3659 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}} was not read.
14. **Excel column set (the loop body after RP_CASH_BANK.cs:2645 {{num12 = ((DataGridView)DGV_DETL).ColumnCount - 1;}}).** Blocked: `cash-bank-report.print.excel-column-set`.
15. **Purchase form choice and HM-tax screen.** Blocked: `cash-bank-report.drilldown.purchase` and `cash-bank-report.drilldown.sales-hm-tax`.
16. **Drill-down of the opening row.** Blocked: `cash-bank-report.drilldown.opening-row-no-open`.
17. **Cash and contra voucher line sides (T18).** Blocked: `cash-bank-report.journey.cash-and-bank-entries`. The writer of the AC_DATA lines for these screens is outside this study, so a new reading of the voucher writers is needed. No owner question.
18. **Print of the scheme passbook, the Scheme Ledger mode, the JmUdr report and the hidden line-skip box.** Out of scope by the study's Scope section. No cases.
19. **Gap 19 (no value tests).** Covered by `cash-bank-report.balance.seed-a-hand-totals` and by the value cases above. Once this module's tests exist, the gap is closed by running them.

## Coverage table

| Kind | Cases | Blocked | N/A |
|---|---:|---:|---:|
| T01 Entry/defaults | 7 | 1 | 0 |
| T02 Field route | 11 | 2 | 0 |
| T03 Formula sequence | 11 | 0 | 0 |
| T04 Lookup | 6 | 2 | 1 |
| T05 Children (drill-down) | 11 | 4 | 0 |
| T06 Required/invalid | 3 | 0 | 0 |
| T07 Create | 1 | 0 | 1 |
| T08 Reopen/no-op | 1 | 0 | 1 |
| T09 Edit | 1 | 0 | 1 |
| T10 Delete/cancel/reverse | 2 | 1 | 0 |
| T11 Scope/rights | 7 | 1 | 0 |
| T12 Concurrency | 1 | 0 | 1 |
| T13 Retry/unknown | 1 | 0 | 1 |
| T14 Rollback | 1 | 0 | 1 |
| T15 Config/history | 1 | 0 | 0 |
| T16 Report/output | 11 | 5 | 0 |
| T17 Keyboard/usability | 9 | 0 | 0 |
| T18 Full journey | 2 | 2 | 0 |
| **All** | **87** | **18** | **7** |

Counts come from the case headings in this file. Blocked cases stay in the denominator. T07 to T09, T12 to T14 are N/A because the report writes nothing (Report addendum). T04 stale-result is N/A because the desktop lookup is synchronous.
The 19 gaps are each named in at least one case heading (gap 19 by `balance.seed-a-hand-totals`).

## Test data

**Seed A** (isolated test database, company `01`, location `01`, company year `2026-27`; one user with the view right and the print right; a second user with the view right and without the print right; a second company `02` and a second location `02` for the scope cases):

Accounts (code, name, group):
- `00001` CASH ON HAND, cash group (the default Party Code).
- `00010` TEST BANK, bank group.
- `00101` PARTY ALPHA, debtor group.
- `00102` PARTY BETA, debtor group.

Lines on account 00001 (CR and DR are `CR_AMT` and `DR_AMT`; the counter-party is `LD_CODE`):
- L1, book CASH REC, voucher 1, 10/10/2026, DR 10000.00, counter-party 00101. (Before From.)
- L2, book CASH PAY, voucher 2, 20/10/2026, CR 2500.00, counter-party 00102. (Before From.)
- R1, book CASH REC, voucher 3, 05/11/2026, DR 4000.00, counter-party 00101.
- R2, book CASH PAY, voucher 4, 12/11/2026, CR 1500.00, counter-party 00102.
- R3, book CONTRA, voucher 5, 20/11/2026, CR 1000.00, counter-party 00010.
- R4, book CASH REC, voucher 7, 22/11/2026, two lines: CR 500.00 and DR 500.00, both counter-party 00101 (one group, net zero).
- R5, book SALES, voucher 6, 25/11/2026, DR 2000.00, counter-party 00102. An SL_DATA row for the same book and voucher has AC_NAME `PARTY ALPHA`.
- L8, book CASH REC, voucher 8, 02/12/2026, DR 999.00, counter-party 00101. (After To.)

Lines on account 00010:
- L5b, book CONTRA, voucher 5, 20/11/2026, DR 1000.00, counter-party 00001. (The other side of the contra.)

Period for seed A: From 01/11/2026, To 30/11/2026.

Expected seed A figures: opening Dr 7500.00; period rows as in `balance.running-side`; totals Dr 13500.00, Cr 2500.00, Bal 11000.00 Dr.

**Variants** (each case says which one it uses):
- Date-boundary variant: add L9, book CASH REC, 01/11/2026, DR 100.00, counter-party 00101.
- Cr-side variant: add L10, book CASH PAY, 01/10/2026, CR 20000.00, counter-party 00102.
- Empty-period variant: the case sets From 03/12/2026 and To 05/12/2026; L8 (DR 999.00) falls in the opening.
- Sentinels: a line of company `02` on account 00001 (05/11/2026, DR 888.00); a line of location `02` on account 00001 (05/11/2026, DR 777.00); a line of company year `2025-26` on account 00001 (06/11/2026, DR 333.00), used only by the year case, which is blocked.
- Drill-down rows: a BANK REC line (26/11/2026, DR 300.00, account 00001, counter-party 00010) and a BANK PAY line (27/11/2026, CR 300.00, account 00001, counter-party 00010), each added only for its drill-down case.
- Party rename: party 00101 to `PARTY ALPHA RENAMED`, only in the history case.

Money is in rupees with two decimals. The names are fictitious test names. No real customer data is used.
