# WP-20 cases — Ledger Report residuals: the OP_LDR ageing union and the fine (metal) prints

Frozen case list built from `orchestration/work/WP-20/study.md` (14 gaps) and the existing browser module
`web/apps/web/test/features/modules/accountLedger.mjs`. It is the contract for the later WP-20 workers: every
expected value below is derived from the desktop rule with a quoted citation, never from what the web prints today.
A case marked executable may fail today because the feature is missing; that failure is the point (the gap number is
named in the case header). Case ids reuse the existing module's ids where the behaviour is the same.

Scope: menu "Ledger Report", desktop form `RP_LEDR`, opened with no constructor argument
(`MDI_FORM.cs:8871 {{case "Ledger Report":}}`, `MDI_FORM.cs:8873 {{RP_LEDR rP_LEDR = new RP_LEDR();}}`), so there
are no modes; edition and settings change the form from inside. In scope: the OP_LDR union inside `TimeLedr_Dr`
(`RP_LEDR.cs:9563 {{private void TimeLedr_Dr()}}`) and the Gold, Silver, JmaUdr and In Out/Ac Sale prints. Out of
scope: the DGV grids, Excel export, Ac Purc, the OD form, Crystal layout content, the Rojmel remarks (see Not covered).

Each case seeds only the rows it names and cleans them afterwards (the existing module's `withCase` pattern).
The ageing cases use a fixed to-date **T = 2024-06-30**, company `01`, year `2024-2025`, locations `01` and `02`.
Bucket windows from T: 0-15 >= 2024-06-15; 16-30 = 2024-05-31..2024-06-14; 31-45 = 2024-05-16..2024-05-30;
46-60 = 2024-05-01..2024-05-15; 61-90 = 2024-04-01..2024-04-30; 91-120 = 2024-03-02..2024-03-31;
121-150 = 2024-02-01..2024-03-01; 151+ <= 2024-01-31
(`RP_LEDR.cs:9716 {{.AddDays(-15.0), "MM/dd/yyyy")}}`, `RP_LEDR.cs:9719 {{.AddDays(-16.0), "MM/dd/yyyy")}}`,
`RP_LEDR.cs:9719 {{.AddDays(-30.0), "MM/dd/yyyy")}}`, `RP_LEDR.cs:9737 {{.AddDays(-151.0), "MM/dd/yyyy")}}`).

## Architect decisions

Standing rule applied: "the desktop first; the web adds only what a hosted multi-user service needs to be safe and
correct". Every decision below is recorded as **architect, 2026-11-23, owner may override**.

- **D1 (study Open question 1, Gap 2, W3) — port the desktop silver column read.** The OP_LDR arm reads
  `CR_GL_FINE` for silver in both the credit and the debit queries
  (`RP_LEDR.cs:9713 {{SUM(A.CR_GL_FINE) As GoldWt,SUM(A.CR_GL_FINE) As SilverWt FROM OP_LDR AS A}}`,
  `RP_LEDR.cs:9716 {{Sum(A.DR_AMT) as Amount,SUM(A.DR_GL_FINE) as GoldWt,SUM(A.CR_GL_FINE) as SilverWt FROM OP_LDR AS A}}`).
  This is a business result, not a multi-user safety issue, so desktop-first wins: the web reproduces the quirk and
  records it as deliberate. `DR_SL_FINE`/`CR_SL_FINE` are never read by this form. Whether the owner's real data puts
  silver only in `*_SL_FINE` cannot be answered without reading customer data (rule 9) and does not change the parity
  result; an owner override may switch to `*_SL_FINE` later. Cases: ageing.silver-quirk.
- **D2 (Open question 2) — null-date OP_LDR rows drop.** Every window filters on `VCH_DATE`
  (`RP_LEDR.cs:9713 {{and VCH_DATE <= '}}`); a NULL date matches no window, so the row is dropped from every bucket,
  credit total included. Reproduce; no web addition. The case seeds a null-date row to prove it.
- **D3 (Open question 3) — resolved from source, no block.** `UserPrint` is declared without an initializer
  (`RP_LEDR.cs:237 {{private string UserPrint;}}`) and is assigned only when a USER_SET row exists
  (`RP_LEDR.cs:4153 {{if (dataTable.Rows.Count > 0)}}`, `RP_LEDR.cs:4157 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}`).
  With no row it stays null and the right test refuses (`RP_LEDR.cs:3987 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}`).
- **D4 (Open question 4) — line numbers re-opened and confirmed.** `RP_LEDR.cs:9815 {{obj.Value = Strings.Format(RuntimeHelpers.GetObjectValue(obj4), "0");}}`
  is exact; the Gold parameter lines are 8411-8414 (`RP_LEDR.cs:8411 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num2, "0.000")) ?? "";}}`).
  Small study offsets were corrected to the verified lines: carry 9894 (study 9892), title 8366 (study 8363),
  from-date 4595 (study 4597), apostrophe 5992 (study 5990), Ac Sale selection 9091 (study 9092), hidden Add1 9690
  (study 9689), fine-type test 9771 (study 9770), empty-return 9741 (study 9743). All are within the citation
  checker's two-line tolerance; the quotes are unchanged.
- **D5 (Open question 5, Gaps 5-8 and 13, W2, W9) — server-built prints, no staging write on the request path.**
  The desktop truncates and refills FINE_DATA and LEDR_AC_DATA per click for the whole database
  (`RP_LEDR.cs:8255 {{DC_Main.ExeQuteDc("DELETE FROM FINE_DATA ");}}`, `RP_LEDR.cs:6128 {{DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA");}}`),
  which overwrites other operators and other companies. That is exactly the hosted multi-user hazard the standing
  rule allows the web to remove: the new prints build the same rows in memory, scoped to tenant, company, account
  and dates, and render PDF/Excel. The typed helpers (`ledgerStaging.ts:168`, `:218`) stay unused on the request
  path; Crystal layouts bound to staging tables only if the owner overrides. Because nothing is written, the
  not-applicable groups T07-T14 of the existing module stay valid (Gap 13).
- **D6 (Open question 6, Gap 7) — voucher-wise row shapes need a second study pass.** The four row shapes per
  `MAIN_BOOK` in `Gold_Summ`/`Silver_Summ` were not read line by line in the study
  (`RP_LEDR.cs:8449 {{SELECT * FROM AC_DATA WHERE CO_CODE = '}}`). The prompt/template cases are executable; the
  row-shape dataset case is blocked until a follow-up study packet reads lines 8449-8658 and 8680-8830.
- **D7 (Gap 10) — Lite and Basic hide the ageing view.** Desktop hides Time Wise in L and B
  (`RP_LEDR.cs:4587 {{if ((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0))}}`,
  `RP_LEDR.cs:4589 {{((Control)BtnTimeWise).Visible = false;}}`), and the panel opens only from that hidden button
  (`RP_LEDR.cs:9558 {{((Control)PnlMonth).Visible = true;}}`), so OP_LDR ageing is unreachable in Lite/Basic.
  Desktop-first: the web gates the ageing view by edition. Owner may override to keep it as a deliberate extension.
- **D8 (Gap 3) — opening legs age when there is no OP_LDR.** The book-000 exclusion is conditional on the presence
  flag (`RP_LEDR.cs:9713 {{Interaction.IIf(flag, (object)"AND A.CO_BOOK <> '000'", (object)"")}}`). With no OP_LDR
  rows for the selected location, book-000 AC_DATA legs — including the web's carried-opening legs — age like any
  leg; with OP_LDR rows they drop from the buckets and OP_LDR replaces them. The web's blanket exclusion of carried
  openings (`accountLedgerShared.ts:270`, `carriedOpening.ts:19`) must become conditional. Desktop-first; no
  multi-user safety reason requires excluding openings.
- **D9 (Gap 4, W8) — the account list uses the same combined set as the buckets.** The desktop lists accounts from
  an AC_DATA-only net (`RP_LEDR.cs:9711 {{Sum(A.CR_AMT-A.DR_AMT) as Amount}}`, no OP_LDR arm, no book filter) while
  the buckets replace book 000 with OP_LDR; the study prescribes listing from the combined set. Recorded as a
  deliberate deviation from the desktop defect; owner may override.
- **D10 (W4) — the presence test uses the selected location.** Desktop tests OP_LDR with the session location
  (`RP_LEDR.cs:9705 {{SELECT * FROM OP_LDR WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'}}`)
  while the arms filter by `tLcCode`; when the box differs from the session, book 000 is double-counted with OP_LDR.
  N223 already fixed the web to the selected location; keep it (multi-location correctness).
- **D11 (W5) — keep the web's upper bound on the 0-15 bucket.** The desktop youngest bucket has no upper bound
  (`RP_LEDR.cs:9716 {{.AddDays(-15.0), "MM/dd/yyyy")}}` with no `<=` arm), so future-dated rows land in 0-15. The
  web already bounds it at the to-date; keep the fix and record the difference.
- **D12 (W7) — apply AC_TYPE to both arms.** The desktop OP_LDR arm has no `AC_TYPE` condition while the AC_DATA
  arm has one (`RP_LEDR.cs:9713 {{AND B.AC_TYPE = '}}`). The defect is latent: only accounts already listed are read
  (`RP_LEDR.cs:9864 {{dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));}}`),
  so the visible result is the same. The web applies the type to both arms; the case guards against any leak.
- **D13 (Gap 11) — half-month toggle, default off.** Desktop hides the six half-month columns unless the tick is on
  (`RP_LEDR.cs:9691 {{if (!chkHalfMonth.Checked)}}`, `RP_LEDR.cs:9693 {{((DataGridView)DGV_MONTH).Columns[3].Visible = false;}}`);
  no load-time assignment sets the tick, so the default is off. The web adds the toggle default off; ticking shows
  the columns and re-runs the ageing (`RP_LEDR.cs:10374 {{TimeLedr_Dr();}}`).
- **D14 (W6) — port the silver two-decimal balance rounding.** The gold print reads the gold balance at three
  decimals and the silver balance at two (`RP_LEDR.cs:8332 {{num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));}}`,
  `RP_LEDR.cs:8333 {{num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));}}`).
  A display rounding of a business figure: desktop-first, reproduce and record; owner may override.
- **D15 (Gap 12) — opening-ledger zoom refusal is server-side.** Once OP_LDR rows appear in a grid, the row carries
  an opening flag and zoom returns the exact desktop text
  (`RP_LEDR.cs:10665 {{This Is a Opening Ledger Voucher You Cant Zoom ....}}`).
- **D16 (Gap 14) — desktop-runtime comparison is blocked on the device.** The lineage note still says
  "Desktop-runtime comparison and parent acceptance remain open" (`12-lineage-verification-2026-10-01.md:3085`).
  The comparison case below is blocked until a desktop runtime with OP_LDR rows loaded is available.

## Cases

### account-ledger.entry.defaults   (T01 Entry/defaults · reused)
Layer: browser
Steps: 1. Open /reports/account-ledger as admin. 2. Record the primary buttons and the default view.
Expected: the form opens with no mode (MDI_FORM.cs:8873 {{RP_LEDR rP_LEDR = new RP_LEDR();}}); the web keeps the
existing assertion: one primary button "Run", view selector value "summary" (unchanged from accountLedger.mjs
entry.defaults). The residual buttons are covered by entry.print-buttons-drill-only.
Status: executable

### account-ledger.entry.print-buttons-drill-only   (T01 Entry/defaults · Gaps 5, 6, 8)
Layer: browser
Steps: 1. Open the report, run the summary. 2. Record whether Gold, Silver, In Out and JmaUdr buttons are visible.
3. Double-click an account row into the detail drill-down. 4. Record the buttons again. 5. Press Esc. 6. Record again.
Expected: on the summary the four print buttons are not visible; inside the drill-down they are visible; Esc hides
them again — the desktop switches them off on Esc (`RP_LEDR.cs:6024 {{((Control)BtnGold).Visible = false;}}`,
followed by Silver, In Out and Ac Purc at 6025-6027). Captions: "&Gold" (`RP_LEDR.cs:2439 {{BtnGold.Text = "&Gold";}}`),
"&Silver" (`RP_LEDR.cs:2453 {{BtnSilver.Text = "&Silver";}}`), "&In Out" (`RP_LEDR.cs:2467 {{BtnJmaUdhar.Text = "&In Out";}}`),
"&JmaUdr" (`RP_LEDR.cs:2425 {{BtnDelete.Text = "&JmaUdr";}}`). Fails today: the web page has none of these buttons
(`page.tsx:144` offers only Print/PDF/Excel/CSV).
Status: executable

### account-ledger.entry.fine-type-default   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the report with company metal type "G". 2. Open the ageing view and record the FineType selector.
3. Switch the company metal type to "S" and reopen. 4. Record the selector and the Gold-Col tick visibility.
Expected: the selector lists exactly "Gold" then "Silver" (`RP_LEDR.cs:4559 {{cboFineType.Items.Add((object)"Gold");}}`,
`RP_LEDR.cs:4560 {{cboFineType.Items.Add((object)"Silver");}}`); with metal "G" the default is index 0 Gold
(`RP_LEDR.cs:4563 {{cboFineType.SelectedIndex = 0;}}`), otherwise index 1 Silver
(`RP_LEDR.cs:4567 {{cboFineType.SelectedIndex = 1;}}`); the Gold-Col tick is hidden unless metal type is "S"
(`RP_LEDR.cs:4555 {{if (Operators.CompareString(DC_Main.MsMetalType, "S", false) != 0)}}`,
`RP_LEDR.cs:4557 {{((Control)chkGoldCol).Visible = false;}}`). The label is "FineType"
(`RP_LEDR.cs:2892 {{Label5.Text = "FineType";}}`).
Status: executable

### account-ledger.entry.date-defaults   (T01 Entry/defaults)
Layer: browser
Steps: 1. Seed the company opening date as 2024-04-01. 2. Open the report. 3. Read the from and to date fields.
Expected: from-date equals the company opening date (`RP_LEDR.cs:4595 {{mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);}}`)
= 01/04/2024; to-date equals the system date (`RP_LEDR.cs:4596 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}`)
= the test clock's today. The location box defaults to the session location (`RP_LEDR.cs:4576 {{tLcCode.Text = DC_Main.MLc_code;}}`).
Status: executable

### account-ledger.filter.location-op-ldr   (T02 Field route · Gap 1)
Layer: browser + database
Steps: 1. Seed OP_LDR for Z500: location 01 row DR_AMT 500 dated 2024-04-21, location 02 row DR_AMT 777 same date.
2. Set the location box to 01, to-date 2024-06-30, run ageing. 3. Read Z500's 61-90 bucket. 4. Switch to 02, re-run.
Expected: the OP_LDR arm filters by the box value (`RP_LEDR.cs:9713 {{AND A.LC_CODE = '" + tLcCode.Text + "'}}`):
with 01 the 61-90 bucket is 500.00 (not 1277.00); with 02 it is 777.00. Fails today: no OP_LDR is read at all
(`accountLedgerQueries.ts:447 {{FROM "AC_DATA" d}}`).
Status: executable

### account-ledger.filter.city-group-op-ldr   (T02 Field route · Gap 1)
Layer: browser + database
Steps: 1. Seed Z500 (city RAJKOT, group DEBTOR) OP_LDR DR_AMT 500 dated 2024-04-21 and Z505 (city SURAT) OP_LDR
DR_AMT 800 same date. 2. Set city RAJKOT, run ageing. 3. Read the rows. 4. Set group DEBTOR with city blank, re-run.
Expected: the OP_LDR arm joins AC_MAST and filters city and group
(`RP_LEDR.cs:9713 {{AND B.AC_CITY = '" + cboCity.Text + "'}}`, `RP_LEDR.cs:9713 {{AND B.AC_GR = '" + tAcGrCode.Text + "'}}`):
with city RAJKOT only Z500 appears with 61-90 = 500.00 and Z505 is absent; with group DEBTOR only Z500 appears.
Status: executable

### account-ledger.filter.to-date-op-ldr   (T02 Field route · Gap 1)
Layer: browser
Steps: 1. Seed OP_LDR Z500 DR_AMT 500 dated 2024-04-21. 2. Run ageing with to-date 2024-06-30. 3. Read the buckets.
4. Change the to-date to 2024-07-30 and re-run. 5. Read the buckets.
Expected: every window is bounded by the to-date (`RP_LEDR.cs:9713 {{and VCH_DATE <= '}}`): at 2024-06-30 the row
is 70 days old → 61-90 = 500.00; at 2024-07-30 it is 100 days old → 91-120 = 500.00 and 61-90 is blank.
Status: executable

### account-ledger.filter.data-type-op-ldr   (T02 Field route · Gap 1)
Layer: browser + database
Steps: 1. Seed OP_LDR Z500 rows dated 2024-04-21: DATA_TYPE "A" DR_AMT 500, DATA_TYPE "B" DR_AMT 50.
2. Run ageing with data type "A". 3. Read 61-90. 4. Switch the session data type to "C", re-run.
Expected: the OP_LDR arm applies DATA_TYPE unless the type is "C"
(`RP_LEDR.cs:9713 {{AND DATA_TYPE = '" + DC_Main.MsDataType + "'}}`): with "A" the bucket is 500.00; with "C" it is
550.00 (both rows).
Status: executable

### account-ledger.filter.ac-type-op-ldr   (T02 Field route · Gap 1, W7)
Layer: browser + database
Steps: 1. Seed Z504 (AC_TYPE "A") with an AC_DATA debit 50 dated 2024-06-20 and an OP_LDR debit 100 dated
2024-04-21. 2. Seed Z505 (AC_TYPE "B") with an OP_LDR debit 800 dated 2024-04-21 only. 3. Select account type "A",
run ageing.
Expected: Z504 shows 0-15 = 50.00 and 61-90 = 100.00; Z505 is absent. The AC_DATA arm filters the type
(`RP_LEDR.cs:9713 {{AND B.AC_TYPE = '}}`); the desktop OP_LDR arm omits it, but the per-account row filter
(`RP_LEDR.cs:9864 {{dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));}}`)
hides the leak, so the visible result is the same. Per D12 the web applies the type to both arms; this case guards
that no type-B opening row ever reaches a type-A result.
Status: executable

### account-ledger.ageing.op-ldr-union   (T03 Formula sequence · Gap 1)
Layer: browser + database
Steps: 1. Seed for Z500: OP_LDR row O1 dated 2024-04-21 with DR_AMT 500, CR_AMT 0, DR_GL_FINE 10.000,
CR_GL_FINE 2.000, DR_SL_FINE 60.000, CR_SL_FINE 50.000, DATA_TYPE "A"; AC_DATA book 000 debit 700 dated 2024-04-21
(IT_TYPE G, SIGN '-', FINE_WT 5); AC_DATA SALES debit 300 dated 2024-06-20 (G '-' 3); AC_DATA SALES credit 400
dated 2024-05-01 (G '+' 4). 2. Run ageing, fine Gold, to-date 2024-06-30. 3. Read every bucket and the totals.
Expected: the bucket queries are AC_DATA UNION ALL OP_LDR
(`RP_LEDR.cs:9713 {{UNION ALL SELECT A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,SUM(A.CR_AMT) AS Amount}}`) and the
AC_DATA arm skips book 000 because OP_LDR rows exist (`RP_LEDR.cs:9713 {{AND A.CO_BOOK <> '000'}}`).
Arithmetic: credit total = money 400, gold 4 (AC_DATA) + 2 (O1 CR_GL_FINE) = 6. Debit buckets: 0-15 = money 300 /
gold 3; 61-90 = money 500 / gold 10 (O1 DR_GL_FINE); all others 0. Oldest-first consumption: 61-90 money
500 - 400 = 100.00 remainder, credits exhausted; 0-15 stays 300.00. Gold: 61-90 10 - 6 = 4.000; 0-15 3.000.
Grid row Z500: 0-15 = 300.00 / 3.000, 61-90 = 100.00 / 4.000, every other bucket blank, total debit 400.00 /
gold 7.000. The book-000 700/5.000 appears nowhere. Fails today: the web reads AC_DATA only
(`accountLedgerQueries.ts:423` ageingDataset), so 61-90 is empty and the totals are wrong.
Status: executable

### account-ledger.ageing.book000-replaced   (T03 Formula sequence · Gaps 1, 3)
Layer: browser + database
Steps: 1. Seed Z500 with only a book-000 AC_DATA debit 700 dated 2024-04-21 (G '-' 5) and OP_LDR row O1
DR_AMT 500, DR_GL_FINE 10.000, CR_GL_FINE 2.000 dated 2024-04-21. 2. Run ageing, fine Gold, to-date 2024-06-30.
Expected: the presence flag is set once per run (`RP_LEDR.cs:9709 {{flag = true;}}`) and drops book 000 from every
bucket arm (`RP_LEDR.cs:9713 {{Interaction.IIf(flag, (object)"AND A.CO_BOOK <> '000'", (object)"")}}`).
61-90 = money 500.00 (no credits), gold 10 - 2 = 8.000. If book 000 were wrongly kept the row would read
1200.00 / 13.000 — assert it does not.
Status: executable

### account-ledger.ageing.book000-without-op-ldr   (T03 Formula sequence · Gap 3)
Layer: browser + database
Steps: 1. Ensure no OP_LDR rows exist for company 01 location 01. 2. Seed Z501 with a single carried-opening
book-000 leg DR_AMT 250 dated 2024-04-21. 3. Run ageing, to-date 2024-06-30.
Expected: with the flag false the IIf adds no book filter (`RP_LEDR.cs:9713 {{Interaction.IIf(flag, (object)"AND A.CO_BOOK <> '000'", (object)"")}}`)
and the account list counts book 000 (`RP_LEDR.cs:9711 {{Sum(A.CR_AMT-A.DR_AMT) as Amount}}`): Z501 appears with
61-90 = 250.00, total 250.00. Fails today: the web excludes the carried-opening leg unconditionally
(`accountLedgerShared.ts:270`, `carriedOpening.ts:19`), so the opening debit is missing (D8).
Status: executable

### account-ledger.ageing.silver-quirk   (T03 Formula sequence · Gap 2)
Layer: browser + database
Steps: 1. Seed exactly the rows of ageing.op-ldr-union. 2. Run ageing with fine Silver, to-date 2024-06-30.
3. Read every silver bucket and the silver total.
Expected: the OP_LDR debit arm reads silver from the gold credit column
(`RP_LEDR.cs:9716 {{Sum(A.DR_AMT) as Amount,SUM(A.DR_GL_FINE) as GoldWt,SUM(A.CR_GL_FINE) as SilverWt FROM OP_LDR AS A}}`),
and the credit arm does the same (`RP_LEDR.cs:9713 {{SUM(A.CR_GL_FINE) As GoldWt,SUM(A.CR_GL_FINE) As SilverWt FROM OP_LDR AS A}}`).
Silver credits = 2.000 (O1 CR_GL_FINE); silver 61-90 debit = 2.000 (the same column, not DR_SL_FINE 60). FIFO:
2.000 - 2.000 = 0 → the bucket is fully consumed and shows blank (a zero fine cell is blanked,
`RP_LEDR.cs:9835 {{((DataGridView)dGV_MONTH)[20, num7].Value = "";}}`). Every silver bucket is blank and the silver
total is 0.000. A "correct" DR_SL_FINE implementation would show 61-90 = 58.000 (60 - 2) — assert it does not.
This is the deliberate desktop quirk of D1.
Status: executable

### account-ledger.ageing.fifo-carry   (T03 Formula sequence · Gap 1)
Layer: browser + database
Steps: 1. Seed Z500: OP_LDR O1 DR_AMT 500, DR_GL_FINE 10.000, CR_GL_FINE 2.000 dated 2024-04-21; AC_DATA credit
700 dated 2024-05-01 (G '+' 4); AC_DATA debit 300 dated 2024-06-20 (G '-' 3); book-000 debit 700 dated 2024-04-21
(G '-' 5, excluded). 2. Run ageing, fine Gold, to-date 2024-06-30.
Expected: credits consume the oldest bucket first and the remainder carries to the next bucket
(`RP_LEDR.cs:9886 {{if (num13 != 0.0)}}`, `RP_LEDR.cs:9894 {{((DataGridView)dGV_MONTH)[10, num7].Value = Strings.Format((object)Math.Abs(num13 - num10), "0.00");}}`).
Money: credits 700; 61-90 debit 500 is fully consumed (credits left 200); 0-15 debit 300 - 200 = 100.00 remains.
Gold: credits 6; 61-90 10 - 6 = 4.000 remains, credits exhausted; 0-15 3.000. Grid: 0-15 = 100.00 / 3.000,
61-90 blank, total 100.00 / 7.000. Money carries format "0.00", fine "0.000"
(`RP_LEDR.cs:9908 {{((DataGridView)dGV_MONTH)[19, num7].Value = Strings.Format((object)Math.Abs(num15 - num12), "0.000");}}`).
Status: executable

### account-ledger.ageing.null-date-dropped   (T03 Formula sequence · Gap 1)
Layer: browser + database
Steps: 1. Seed Z506 with one OP_LDR row DR_AMT 999, VCH_DATE NULL, and no AC_DATA legs. 2. Run ageing,
to-date 2024-06-30. 3. Search the grid for Z506.
Expected: every window compares VCH_DATE (`RP_LEDR.cs:9713 {{and VCH_DATE <= '}}`); NULL matches no window, so the
row contributes to no bucket and no credit total, and Z506 (no AC_DATA net) is not listed at all. Per D2 this drop
is reproduced, not "fixed".
Status: executable

### account-ledger.ageing.account-list-combined   (T03 Formula sequence · Gap 4)
Layer: browser + database
Steps: 1. Seed OP_LDR row O1 for Z500 (any debit, dated 2024-04-21) so the presence flag is on. 2. Seed Z502 with
an OP_LDR-only debit 100 dated 2024-04-21 (no AC_DATA legs). 3. Seed Z503 with a book-000-only AC_DATA debit 100
dated 2024-04-21. 4. Run ageing, to-date 2024-06-30.
Expected: Z502 is listed with 61-90 = 100.00; Z503 is absent. The desktop lists accounts from an AC_DATA-only net
(`RP_LEDR.cs:9711 {{Sum(A.CR_AMT-A.DR_AMT) as Amount}}`, no OP_LDR arm) and adds a row only when the shown value is
non-zero (`RP_LEDR.cs:9793 {{if (num9 != 0.0)}}`), so it misses Z502 and lists Z503 with empty buckets. Per D9 the
web lists from the same combined set as the buckets: Z502 net -100 → listed; Z503 net 0 (000 excluded) → absent.
Fails today on both counts (no OP_LDR read).
Status: executable

### account-ledger.ageing.future-dated   (T03 Formula sequence · Gap 1, W5)
Layer: browser + database
Steps: 1. Seed Z500: OP_LDR O1 DR_AMT 500 dated 2024-04-21; AC_DATA SALES debit 200 dated 2024-07-05 (five days
after the to-date). 2. Run ageing, to-date 2024-06-30.
Expected: the desktop youngest bucket has only a lower bound (`RP_LEDR.cs:9716 {{.AddDays(-15.0), "MM/dd/yyyy")}}`,
no upper-bound arm), so the desktop would show the future 200 in 0-15. Per D11 the web keeps its upper bound:
0-15 is blank and 61-90 = 500.00. The difference from the desktop is deliberate and recorded.
Status: executable

### account-ledger.filter.account-lookup   (T04 Lookup · reused)
Layer: browser
Steps: 1. Seed Z100 "ZZ ALPHA". 2. Open the report, type "ZZ" in the Account lookup.
Expected: the dropdown lists ZZ ALPHA (unchanged from accountLedger.mjs filter.account-lookup; the residual scope
adds no new search/select control — the fine-type selector is a two-item combo covered by entry.fine-type-default).
Status: executable

### account-ledger.drill.detail-children   (T05 Children · reused)
Layer: browser
Steps: 1. Seed the five-leg ZZ ALPHA account. 2. Select the detail view, account Z100, run.
Expected: the detail drill shows the account's per-voucher legs (at least 5 rows), filled by DGV_DETL_FILL
(`RP_LEDR.cs:6862 {{private void DGV_DETL_FILL()}}`); unchanged from accountLedger.mjs drill.detail-children.
Status: executable

### account-ledger.drill.op-ldr-row-ownership   (T05 Children · Gap 1)
Layer: browser + database
Steps: 1. Seed Z500 with OP_LDR debit 500 dated 2024-04-21 and Z502 with OP_LDR debit 100 same date; no credits.
2. Run ageing, to-date 2024-06-30. 3. Read both rows.
Expected: each account's buckets sum only its own rows — the per-account row filter
(`RP_LEDR.cs:9864 {{dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));}}`)
keeps ownership stable: Z500 61-90 = 500.00, Z502 61-90 = 100.00, no value moves between the two rows.
Status: executable

### account-ledger.refuse.print-rights-gold   (T06 Required/invalid · Gap 9)
Layer: browser
Steps: 1. Sign in as a user whose USER_SET row for this menu has FRM_PRINT "N". 2. Drill into an account.
3. Click Gold.
Expected: the exact message "You Have No Print Rights....." and no output; focus stays where it was
(`RP_LEDR.cs:8236 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}`,
right test `RP_LEDR.cs:8234 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}`).
Status: executable

### account-ledger.refuse.print-rights-others   (T06 Required/invalid · Gap 9)
Layer: browser
Steps: 1. As the no-print-right user, drill into an account. 2. Click Silver, then JmaUdr, then In Out.
3. Return to the summary and click Print.
Expected: each refuses with the exact same text "You Have No Print Rights.....":
Silver (`RP_LEDR.cs:8880 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}`),
JmaUdr (`RP_LEDR.cs:3989 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}`),
In Out (`RP_LEDR.cs:9073 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}`),
summary Print (`RP_LEDR.cs:6105 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}`).
No staging or business write happens on any refusal.
Status: executable

### account-ledger.refuse.no-user-set-row   (T06 Required/invalid · Gap 9)
Layer: browser + database
Steps: 1. Sign in as a user with no USER_SET row for this menu/location. 2. Drill into an account. 3. Click Gold.
Expected: refusal with "You Have No Print Rights.....". UserPrint is declared without an initializer
(`RP_LEDR.cs:237 {{private string UserPrint;}}`), assigned only when a row exists
(`RP_LEDR.cs:4153 {{if (dataTable.Rows.Count > 0)}}`), and the null value fails the "Y" test
(`RP_LEDR.cs:3987 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}`). Decision D3.
Status: executable

### account-ledger.refuse.lc-code-empty   (T06 Required/invalid · Gaps 6, 8)
Layer: browser
Steps: 1. Clear the location selection (empty tLcCode equivalent). 2. Trigger the summary Print. 3. Trigger the
Silver voucher-wise summary.
Expected: both refuse with the exact text "Please Select Lc Code and Try..."
(`RP_LEDR.cs:6125 {{Interaction.MsgBox((object)"Please Select Lc Code and Try...", (MsgBoxStyle)0, (object)null);}}`,
repeated by Silver_Summ at `RP_LEDR.cs:8667 {{Interaction.MsgBox((object)"Please Select Lc Code and Try...", (MsgBoxStyle)0, (object)null);}}`).
No output is produced.
Status: executable

### account-ledger.refuse.zoom-opening   (T06 Required/invalid · Gap 12)
Layer: browser + database
Steps: 1. Seed an OP_LDR opening row for Z500 so it appears in the ledger grids once Gap 1 lands. 2. Open the
detail/voucher grid for Z500. 3. Double-click (zoom) the opening row.
Expected: the exact refusal "This Is a Opening Ledger Voucher You Cant Zoom ...."
(`RP_LEDR.cs:10665 {{This Is a Opening Ledger Voucher You Cant Zoom ....}}`); no voucher form opens. The row carries
a server-side opening flag (D15). Fails today: OP_LDR rows are in no grid and the message does not exist.
Status: executable

### account-ledger.refuse.zoom-rights   (T06 Required/invalid · Gap 12)
Layer: browser
Steps: 1. Sign in as a user without the zoom target menu's view right. 2. Drill into an account with a normal
voucher row. 3. Zoom the row.
Expected: the exact message "You Have No Rights..." (`RP_LEDR.cs:10650 {{Interaction.MsgBox((object)"You Have No Rights...", (MsgBoxStyle)0, (object)null);}}`);
zoom uses the other menu's view right, not the print right.
Status: executable

### account-ledger.refuse.empty-ageing-silent   (T06 Required/invalid · Gap 1)
Layer: browser
Steps: 1. Seed no accounts with a debit balance or negative fine. 2. Run ageing.
Expected: an empty grid and no message of any kind — the desktop returns silently when the account list is empty
(`RP_LEDR.cs:9741 {{if (dataTable.Rows.Count == 0)}}`, `RP_LEDR.cs:9743 {{return;}}`). The OP_LDR union must not
introduce an error text here.
Status: executable

### account-ledger.create.not-applicable   (T07 Create · reused)
Layer: browser
Steps: none — the kind does not apply.
Expected: RP_LEDR is a read-only report (`MDI_FORM.cs:8871 {{case "Ledger Report":}}` opens it with no writer);
its only desktop writes are the staging tables (`RP_LEDR.cs:8255 {{DC_Main.ExeQuteDc("DELETE FROM FINE_DATA ");}}`),
which D5 deliberately does not port to the request path.
Status: N/A: read-only report has no create; kept valid by D5 (Gap 13). If the owner overrides D5 to staging
writes, this group becomes applicable again.

### account-ledger.reopen.not-applicable   (T08 Reopen/no-op · reused)
Layer: browser
Steps: none — the kind does not apply.
Expected: no document is saved by this form (`MDI_FORM.cs:8873 {{RP_LEDR rP_LEDR = new RP_LEDR();}}` opens a report,
not a voucher), so there is nothing to reopen or save unchanged.
Status: N/A: read-only report has no reopen/unchanged-save (D5, Gap 13).

### account-ledger.edit.not-applicable   (T09 Edit · reused)
Layer: browser
Steps: none — the kind does not apply.
Expected: the form edits no business row; the staging refill is per click and is not ported (D5,
`RP_LEDR.cs:6128 {{DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA");}}`).
Status: N/A: read-only report has no edit (D5, Gap 13).

### account-ledger.delete.not-applicable   (T10 Delete/cancel/reverse · reused)
Layer: browser
Steps: none — the kind does not apply.
Expected: no business delete exists in this form; the desktop Cancel only clears staging
(`RP_LEDR.cs:11669 {{DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA ");}}`), which the web does not write (D5).
Status: N/A: read-only report has no delete/cancel/reverse (D5, Gap 13).

### account-ledger.scope.rights   (T11 Scope/rights · reused)
Layer: browser + database
Steps: 1. Seed this tenant's ZZ ALPHA. 2. Run the summary. 3. Read the visible account names.
Expected: only this tenant's rows appear (unchanged from accountLedger.mjs scope.rights); reads are tenant-scoped
and the route is guarded by the Ledger Report form right. The desktop right load is per user/location/menu
(`RP_LEDR.cs:4148 {{Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' }}`).
Status: executable

### account-ledger.scope.op-ldr-company   (T11 Scope/rights · Gap 1)
Layer: browser + database
Steps: 1. Seed OP_LDR sentinels: company 02 row for Z500 DR_AMT 666 dated 2024-04-21, and another tenant's row
DR_AMT 666. 2. Seed the in-scope company 01 location 01 row DR_AMT 500. 3. Run ageing. 4. Call the ageing API
directly with the other tenant's id.
Expected: the presence test and every arm are company-scoped
(`RP_LEDR.cs:9705 {{SELECT * FROM OP_LDR WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'}}`):
61-90 = 500.00, never 1166.00 or 1832.00; the direct cross-tenant call is denied or returns no sentinel rows.
Status: executable

### account-ledger.scope.print-route-rights   (T11 Scope/rights · Gap 9)
Layer: database
Steps: 1. Call each new print route (gold, silver, jmaudr, in-out) directly with a revoked print right. 2. Call
with another tenant's company/account ids. 3. Call with a reused id from a revoked session.
Expected: the server denies every invalid authority with the exact text "You Have No Print Rights....."
(`RP_LEDR.cs:8236 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}`)
and returns no cross-scope rows; the right is read per user/location/menu from USER_SET
(`RP_LEDR.cs:4156 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}`
— the study cites this assignment at 4156; the verified line is 4157, within tolerance).
Status: executable

### account-ledger.scope.presence-location   (T11 Scope/rights · Gap 1, W4)
Layer: browser + database
Steps: 1. Set the session location to 01. 2. Seed OP_LDR only for location 02: Z500 DR_AMT 777 dated 2024-04-21.
3. Seed Z500 book-000 AC_DATA debit 700 in location 01 dated 2024-04-21. 4. Set the location box to 02 and run ageing.
Expected: the web presence test uses the selected location (D10, N223 fix): flag true → book 000 excluded, OP_LDR
counted → 61-90 = 777.00. The desktop would test the session location (`RP_LEDR.cs:9705 {{SELECT * FROM OP_LDR WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'}}`),
find nothing, keep book 000 and still union OP_LDR → 1477.00 double-count. Assert 777.00, not 1477.00.
Status: executable

### account-ledger.concurrency.not-applicable   (T12 Concurrency · reused)
Layer: browser
Steps: none — the kind does not apply.
Expected: with D5 the request path writes nothing, so two operators printing at once cannot overwrite each other —
the desktop hazard (`RP_LEDR.cs:8255 {{DC_Main.ExeQuteDc("DELETE FROM FINE_DATA ");}}` is global) is removed, not
reproduced.
Status: N/A: read-only report has no concurrency (D5, Gap 13). Becomes applicable if the owner chooses staging writes.

### account-ledger.retry.not-applicable   (T13 Retry/unknown · reused)
Layer: browser
Steps: none — the kind does not apply.
Expected: a duplicate print request is a duplicate read; no financial effect exists to double
(`MDI_FORM.cs:8871 {{case "Ledger Report":}}` opens a report).
Status: N/A: read-only report has no write to retry (D5, Gap 13).

### account-ledger.rollback.not-applicable   (T14 Rollback · reused)
Layer: browser
Steps: none — the kind does not apply.
Expected: no multi-table write happens on the request path (D5), so there is no partial write to roll back; the
desktop staging deletes (`RP_LEDR.cs:6128 {{DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA");}}`) are not ported.
Status: N/A: read-only report has no rollback (D5, Gap 13). Becomes applicable if the owner chooses staging writes.

### account-ledger.config.lite-ageing-hidden   (T15 Config/history · Gap 10)
Layer: browser
Steps: 1. Open the report with edition "L". 2. Look for the ageing (Time Wise / Debit Ageing) view. 3. Repeat with
edition "B". 4. Repeat with edition "A".
Expected: in L and B the ageing view is not offered — desktop hides Time Wise
(`RP_LEDR.cs:4587 {{if ((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0))}}`,
`RP_LEDR.cs:4589 {{((Control)BtnTimeWise).Visible = false;}}`) and the panel opens only from that button
(`RP_LEDR.cs:9558 {{((Control)PnlMonth).Visible = true;}}`), so OP_LDR ageing is unreachable; in A it is offered.
Fails today: the web shows "Debit Ageing" to every edition (`page.tsx:23`). Decision D7.
Status: executable

### account-ledger.config.work-type-ac-sale   (T15 Config/history · Gap 8)
Layer: browser
Steps: 1. Set MsWorkType "W". 2. Drill into an account. 3. Read the In Out button caption. 4. Set MsWorkType to a
non-W value and reopen.
Expected: with "W" the caption is exactly "Ac Sale" (`RP_LEDR.cs:4593 {{BtnJmaUdhar.Text = "Ac Sale";}}`);
otherwise "&In Out" (`RP_LEDR.cs:2467 {{BtnJmaUdhar.Text = "&In Out";}}`).
Status: executable

### account-ledger.config.half-month-toggle   (T15 Config/history · Gap 11)
Layer: browser
Steps: 1. Run ageing with the half-month toggle at its default. 2. Count the visible grid columns. 3. Tick
"Half Month Show". 4. Count again and compare the totals.
Expected: default off hides the six half-month columns 3, 4, 5, 12, 13, 14
(`RP_LEDR.cs:9691 {{if (!chkHalfMonth.Checked)}}`, `RP_LEDR.cs:9693 {{((DataGridView)DGV_MONTH).Columns[3].Visible = false;}}`,
columns 4/5/12/13/14 at 9694-9698); AC_CODE and Add1 (21, 22) are always hidden
(`RP_LEDR.cs:9688 {{((DataGridView)DGV_MONTH).Columns[21].Visible = false;}}`,
`RP_LEDR.cs:9690 {{((DataGridView)DGV_MONTH).Columns[22].Visible = false;}}`). Of 23 columns, 15 are visible by
default and 17 with the tick. Ticking re-runs the ageing (`RP_LEDR.cs:10374 {{TimeLedr_Dr();}}`) with identical
bucket totals. The tick caption is " Half Month Show" (`RP_LEDR.cs:2863 {{((ButtonBase)chkHalfMonth).Text = " Half Month Show";}}`).
Fails today: the web has no toggle and always prints all buckets (`accountLedger.ts:103`). Decision D13.
Status: executable

### account-ledger.config.mfg-type-j   (T15 Config/history · Gap 5)
Layer: browser + database
Steps: 1. Seed a jewellery-manufacturing (FTNG) metal row of fine 0.75 for Z600 inside the print dates. 2. Set
MsMfgType "J", drill into Z600, run the Gold print. 3. Set MsMfgType to a non-J value and re-run.
Expected: the FTNG/CHEDIYA/PARA/JDTR sources are added only for jewellery manufacturing
(`RP_LEDR.cs:8290 {{if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)}}`): with "J" the output
contains the 0.75 row; without "J" it does not.
Status: executable

### account-ledger.output.exports   (T16 Report/output · reused)
Layer: browser
Steps: 1. Seed ZZ ALPHA, run the summary. 2. Check Print/Download PDF/Excel/CSV are offered. 3. Fetch export.csv.
Expected: unchanged from accountLedger.mjs output.exports: all four outputs resolve the same dataset (CSV contains
ZZ ALPHA); the desktop summary print is AcSummLdr (`RP_LEDR.cs:6179 {{DC_Main.RptName = "AcSummLdr";}}`) and the
detail print AcLedger (`RP_LEDR.cs:6313 {{DC_Main.RptName = "AcLedger";}}`).
Status: executable

### account-ledger.output.gold-figures   (T16 Report/output · Gap 5)
Layer: browser + database
Steps: 1. Seed Z600: book-000 opening dated 2024-04-01 CR_AMT 100, G '+' FINE_WT 1.5, S '+' FINE_WT 2.256;
SALES 2024-05-10 DR_AMT 40 (G '-' 0.5); SALES 2024-06-15 CR_AMT 60 (G '+' 2.0, S '-' 1.0); an OP_LDR row for Z600
DR_AMT 999 dated 2024-04-21. 2. Drill into Z600, from 2024-04-01 to 2024-06-30, click Gold, answer the layout
question No. 3. Read the output's opening/closing figures, title and parameters. 4. Answer Yes and compare figures.
Expected: opening/closing come from AC_DATA only and never touch OP_LDR (study Calculations B): money
Sum(CR-DR) → opening 100.00, closing 100 - 40 + 60 = 120.00; gold opening 1.500, closing 1.5 - 0.5 + 2.0 = 3.000
(`RP_LEDR.cs:8332 {{num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));}}`,
`RP_LEDR.cs:8340 {{num5 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));}}`);
silver opening 2.256 → "2.26" and closing 1.256 → "1.26" at two decimals (D14,
`RP_LEDR.cs:8333 {{num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));}}`,
`RP_LEDR.cs:8341 {{num6 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));}}`).
The OP_LDR 999 changes none of these figures. Parameters (eight): OpBal = 1.500, ClBal = 3.000, OpAmtBal = 100.00,
ClAmtBal = 120.00 (`RP_LEDR.cs:8411 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num2, "0.000")) ?? "";}}`,
`RP_LEDR.cs:8414 {{Cr[(short)6] = ("ClAmtBal = " + Strings.Format((object)num4, "0.00")) ?? "";}}`), FromDate
Date(2024,4,1), ToDate Date(2024,6,30), DataType 'A'; title "Ledr With Gold Fine Report As On 30/06/2024"
(`RP_LEDR.cs:8366 {{Ledr With Gold Fine Report As On }}`). The layout question text is exactly
"Hz Jama Udhar Gold Report" (`RP_LEDR.cs:8382 {{Hz Jama Udhar Gold Report}}`); Yes selects JmUdFineHz
(`RP_LEDR.cs:8384 {{DC_Main.RptName = "JmUdFineHz";}}`), No JmUdFine (`RP_LEDR.cs:8388 {{DC_Main.RptName = "JmUdFine";}}`).
Per D5 the web renders PDF/Excel server-side with the same figures; the rows are selected by company, year,
account and dates (`RP_LEDR.cs:8343 {{CurFormula = "{FINE_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {FINE_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {FINE_DATA.AC_CODE} = '" + tAcCode.Text + "'}}`).
Crystal layout content is out of scope; both answers must carry identical figures.
Status: executable

### account-ledger.output.gold-rows   (T16 Report/output · Gap 5)
Layer: browser + database
Steps: 1. Seed for Z600 inside 2024-04-01..2024-06-30 one row per source: MAIN_STOCK opening-stock book
TR_AC_OPBL gold item fine 1.25 (SR_NO != 7, ITM_AMT 0); MAIN_STOCK SALES gold item fine 0.75; a PURCHASE voucher
metal row fine 2.0; a KARIGAR RECEIPT row fine 0.5; a GHAT REC row fine 0.375; an AC_DATA money-and-metal leg;
a RATE_CUT_ISU row fine 0.25; an MTL ISU manufacturing row fine 0.125; an OUTWORD location row fine 0.0625.
2. Drill into Z600, run the Gold print. 3. Read the output rows.
Expected: the output contains one row per seeded source with its fine value. The desktop stages these sources into
FINE_DATA: the stock books list includes the opening book (`RP_LEDR.cs:8256 {{BOOK_NAME IN ('TR_AC_OPBL','SALES ORDER','SALES','SALES RETURNE','WH SALES','RATE CUT','KARIGAR ISSUE','DHIRAN ISSUE','INTREST RECIVED','DHIRAN RECEIVED','PURC RETURN','TOUR SALES')}}`),
purchase (`RP_LEDR.cs:8258 {{AND C.MAIN_BOOK = 'PURCHASE'}}`), karigar receipt
(`RP_LEDR.cs:8262 {{AND C.MAIN_BOOK = 'KARIGAR RECEIPT'}}`), ghat (`RP_LEDR.cs:8292 {{AND C.MAIN_BOOK IN ('GHAT REC')}}`),
rate-cut issue (`RP_LEDR.cs:8280 {{FROM RATE_CUT_ISU}}`), the manufacturing books
(`RP_LEDR.cs:8288 {{BOOK_NAME IN ('MTL ISU','GHAT ISU','MFG GHAT REC'}}`), outward locations
(`RP_LEDR.cs:8312 {{MAIN_BOOK = 'OUTWORD'}}`) and inward (`RP_LEDR.cs:8314 {{MAIN_BOOK = 'INWORD'}}`), and the
AC_DATA money legs (`RP_LEDR.cs:8276 {{CR_AMT,0,'F','+','',DATA_TYPE   FROM AC_DATA}}`). A zero-amount row keeps
its stored fine (`RP_LEDR.cs:8256 {{CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END}}`), so the TR_AC_OPBL row
shows 1.25. Per D5 the web builds these rows in memory (no FINE_DATA write); the 34-column shape is already
encoded in `ledgerStaging.ts:22`. Rows of other accounts or outside the dates never appear.
Status: executable

### account-ledger.output.silver-print   (T16 Report/output · Gap 6)
Layer: browser + database
Steps: 1. Seed a silver item stock row fine 3.5 and a silver AC_DATA leg for Z600 inside the dates. 2. Drill into
Z600, click Silver, answer the layout question No, then Yes. 3. Read the output.
Expected: the question text is exactly "Hz Jama Udhar Silver Report"
(`RP_LEDR.cs:9013 {{Hz Jama Udhar Silver Report}}`); Yes selects JmUdFineSlHz
(`RP_LEDR.cs:9015 {{DC_Main.RptName = "JmUdFineSlHz";}}`), No JmUdFineSl (`RP_LEDR.cs:9019 {{DC_Main.RptName = "JmUdFineSl";}}`).
The output contains the silver rows (3.5) and not the gold-only rows; the silver balance figures use two decimals
(D14). With an empty location the silver voucher-wise summary refuses "Please Select Lc Code and Try..."
(`RP_LEDR.cs:8667 {{Please Select Lc Code and Try...}}`). Same row sources as Gold with the silver item filter.
Status: executable

### account-ledger.output.jmaudr-print   (T16 Report/output · Gap 8)
Layer: browser + database
Steps: 1. Seed Z600 with the book-000 opening CR_AMT 100 of output.gold-figures and money movements only.
2. Drill into Z600, click JmaUdr. 3. Read the output.
Expected: the money-only Jama/Udhar report JmUdAmt (`RP_LEDR.cs:4050 {{DC_Main.RptName = "JmUdAmt";}}`) with the
opening parameter text "OpBal = 100.00" (`RP_LEDR.cs:4065 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num, "0.00")) ?? "";}}`);
no metal rows and no staging table write (D5). Button caption "&JmaUdr" (`RP_LEDR.cs:2425 {{BtnDelete.Text = "&JmaUdr";}}`).
Status: executable

### account-ledger.output.in-out-print   (T16 Report/output · Gap 8)
Layer: browser + database
Steps: 1. Seed MAIN_STOCK rows for Z600: a sales issue ITM_SIGN '-' fine 2.0 in book SALES; a row in CO_BOOK
'018'; a receipt ITM_SIGN '+' fine 1.0. 2. Set MsWorkType "W", drill into Z600, click Ac Sale. 3. Read the output.
4. Set MsWorkType to a non-W value and click In Out.
Expected: with "W" (`RP_LEDR.cs:9089 {{if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)}}`) the
report is AcSaleWhRpt (`RP_LEDR.cs:9116 {{DC_Main.RptName = "AcSaleWhRpt";}}`) and the selection excludes book 018
and non-issue signs (`RP_LEDR.cs:9091 {{AND {MAIN_STOCK.CO_BOOK} <> '018' AND {MAIN_STOCK.ITM_SIGN} = '-'}}`):
only the 2.0 issue row appears. Otherwise the report is LedrInOut (`RP_LEDR.cs:9235 {{DC_Main.RptName = "LedrInOut";}}`).
Status: executable

### account-ledger.output.summary-hz-choice   (T16 Report/output · Gap 5)
Layer: browser
Steps: 1. Run the summary with metal rows seeded. 2. Click Print and answer the layout question No. 3. Read the
output. 4. Click Print again and answer Yes.
Expected: the question text is exactly "Hz Repor With Gold and Silver...."
(`RP_LEDR.cs:6226 {{Hz Repor With Gold and Silver....}}`); No prints the plain AcSummLdr
(`RP_LEDR.cs:6179 {{DC_Main.RptName = "AcSummLdr";}}`); Yes prints the metal-weighted summary AcWithWtSumm
(`RP_LEDR.cs:6256 {{DC_Main.RptName = "AcWithWtSumm";}}`) or the gold-only AcWithWtGold
(`RP_LEDR.cs:6260 {{DC_Main.RptName = "AcWithWtGold";}}`) per the metal setting, adding the gold/silver fine
columns to the same account rows. The detail print remains AcLedger (`RP_LEDR.cs:6313 {{DC_Main.RptName = "AcLedger";}}`).
Status: executable

### account-ledger.output.voucher-wise-summ   (T16 Report/output · Gap 7)
Layer: browser
Steps: 1. Seed two vouchers with metal legs for Z600. 2. Open the voucher-summary view for Z600. 3. Trigger the
Gold voucher-wise summary and answer Yes, then No. 4. Trigger the Silver voucher-wise summary and answer Yes, then No.
Expected: the Gold question is exactly "Hz Jama Udhar Gold Voucher Wise Summ Report"
(`RP_LEDR.cs:8625 {{Hz Jama Udhar Gold Voucher Wise Summ Report}}`); Yes uses the template JmUdFineHzSummVch.RPT
(`RP_LEDR.cs:8627 {{\\Report\\JmUdFineHzSummVch.RPT";}}`), No JmUdFineHzSumm.RPT
(`RP_LEDR.cs:8631 {{\\Report\\JmUdFineHzSumm.RPT";}}`). The Silver question is exactly "Silver Report Summery"
(`RP_LEDR.cs:8837 {{Silver Report Summery}}`); Yes JmUdFineSlSum.RPT (`RP_LEDR.cs:8839 {{\\Report\\JmUdFineSlSum.RPT";}}`),
No JmUdFineSlHz.RPT (`RP_LEDR.cs:8843 {{\\Report\\JmUdFineSlHz.RPT";}}`). The summaries read each voucher by key
(`RP_LEDR.cs:8449 {{SELECT * FROM AC_DATA WHERE CO_CODE = '}}`); the web builds them from its voucher-summary view
plus the vouchers' metal rows (D5). Fails today: no such output exists. The per-MAIN_BOOK row shapes are the
blocked case below.
Status: executable

### account-ledger.output.voucher-wise-row-shapes   (T16 Report/output · Gap 7)
Layer: database
Steps: 1. After the second study pass, seed one voucher of each MAIN_BOOK family. 2. Run the Gold and Silver
voucher-wise summaries. 3. Compare every staged row shape against the desktop inserts.
Expected: the four row shapes per MAIN_BOOK that Gold_Summ/Silver_Summ re-insert
(`RP_LEDR.cs:8449 {{SELECT * FROM AC_DATA WHERE CO_CODE = '}}`) — exact column values pending the study pass;
Silver_Summ keys the location from the location box (its refusal at `RP_LEDR.cs:8667 {{Please Select Lc Code and Try...}}`).
Status: blocked: the study did not read the four row shapes line by line (study Open question 6); a follow-up
study packet must read RP_LEDR.cs:8449-8658 {{SELECT * FROM AC_DATA WHERE CO_CODE = '}} and 8680-8830 before
expected values can be frozen. Unblocks when
that study lands; no owner decision needed.

### account-ledger.keyboard.enter-esc   (T17 Keyboard/usability · reused)
Layer: browser
Steps: 1. Focus the to-date, press Enter. 2. Drill into detail. 3. Press Esc.
Expected: unchanged from accountLedger.mjs keyboard.enter-esc: Enter runs the report; Esc steps back one level
(the desktop tests the "&Back1" caption, `RP_LEDR.cs:6014 {{if (Operators.CompareString(BtnExit.Text, "&Back1", false) == 0)}}`)
and returns to the summary.
Status: executable

### account-ledger.keyboard.print-hotkeys   (T17 Keyboard/usability · Gaps 5, 6, 8)
Layer: browser
Steps: 1. Drill into Z600. 2. Press Alt+G, Alt+S, Alt+I, Alt+J in turn, cancelling each output. 3. Return to the
summary and press Alt+P.
Expected: the hot keys come from the captions and trigger the same outputs as the clicks: &Gold = Alt+G
(`RP_LEDR.cs:2439 {{BtnGold.Text = "&Gold";}}`), &Silver = Alt+S (`RP_LEDR.cs:2453 {{BtnSilver.Text = "&Silver";}}`),
&In Out = Alt+I (`RP_LEDR.cs:2467 {{BtnJmaUdhar.Text = "&In Out";}}`), &JmaUdr = Alt+J
(`RP_LEDR.cs:2425 {{BtnDelete.Text = "&JmaUdr";}}`), &Print = Alt+P. Fails today: the buttons do not exist.
Status: executable

### account-ledger.keyboard.ageing-rerun   (T17 Keyboard/usability · Gap 1)
Layer: browser
Steps: 1. Open the ageing panel. 2. Change the city selector and press Enter. 3. Change the account-type selector
and press Enter. 4. Press F1.
Expected: Enter in a selector re-runs the ageing while the panel is open, else the summary:
`RP_LEDR.cs:8195 {{if (((Control)PnlMonth).Visible)}}` then `RP_LEDR.cs:8197 {{TimeLedr_Dr();}}` (cboCity_KeyDown),
and `RP_LEDR.cs:11615 {{TimeLedr_Dr();}}` (cboAcType_KeyDown, else AcSumm at 11619). F1 focuses the search box
(`RP_LEDR.cs:6008 {{if ((int)e.KeyCode == 112)}}`, `RP_LEDR.cs:6010 {{((Control)tSearch).Focus();}}`).
The re-run must include the OP_LDR union each time.
Status: executable

### account-ledger.keyboard.uppercase-apostrophe   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Focus a text selector. 2. Type abc'd.
Expected: the field shows ABCD — typing is forced upper case
(`RP_LEDR.cs:5989 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}`) and the
apostrophe is swallowed (`RP_LEDR.cs:5992 {{if (num == 0 || num == 39)}}`, `RP_LEDR.cs:5994 {{e.Handled = true;}}`).
Status: executable

### account-ledger.journey.summary-to-detail   (T18 Full journey · reused)
Layer: browser
Steps: 1. Seed ZZ ALPHA, run the summary. 2. Double-click its row.
Expected: unchanged from accountLedger.mjs journey.summary-to-detail: the double-click drills into the detail view
(`RP_LEDR.cs:6449 {{private void DGV_DoubleClick(object sender, EventArgs e)}}`), view value "detail".
Status: executable

### account-ledger.journey.op-ldr-to-print   (T18 Full journey · Gaps 1, 5)
Layer: browser + database
Steps: 1. Seed Z600: book-000 opening CR_AMT 100 (G '+' 1.5) dated 2024-04-01; OP_LDR row DR_AMT 30
(DR_GL_FINE 1.000, CR_GL_FINE 0) dated 2024-04-21; SALES DR_AMT 40 (G '-' 0.5) dated 2024-05-10; SALES CR_AMT 60
(G '+' 2.0) dated 2024-06-15. 2. Run the summary and read Z600's net. 3. Run ageing (to-date 2024-06-30) and read
the buckets. 4. Drill into Z600 and run the Gold print (from 2024-04-01). 5. Compare all three.
Expected: summary and Gold print agree on the AC_DATA basis: net credit 100 + 60 - 40 = 120.00, gold
1.5 + 2.0 - 0.5 = 3.000; the print shows OpAmtBal = 100.00, ClAmtBal = 120.00, OpBal = 1.500, ClBal = 3.000
(`RP_LEDR.cs:8414 {{Cr[(short)6] = ("ClAmtBal = " + Strings.Format((object)num4, "0.00")) ?? "";}}`) — the OP_LDR
row never enters the print figures (study Calculations B). Ageing uses the combined set with book 000 replaced
(`RP_LEDR.cs:9713 {{AND A.CO_BOOK <> '000'}}`): credits 60; 61-90 debit 30 consumed (credits left 30); 46-60 debit
40 - 30 = 10.00 remains; gold credits 2 consume the 1.000 and 0.5 debits → no gold residual. Reconciliation:
opening credit 100.00 - outstanding debit 10.00 = combined net credit 90.00 = summary 120.00 - OP_LDR 30.00.
All three views agree end to end on their stated bases.
Status: executable

### account-ledger.journey.desktop-comparison   (T18 Full journey · Gap 14)
Layer: browser + database
Steps: 1. Load the same OP_LDR rows into a desktop runtime and the isolated web database. 2. Run the ageing and
each fine print on both. 3. Record a side-by-side comparison of every bucket, figure and message.
Expected: the web matches the desktop results per the cases above, with the recorded deviations (D1, D9, D10,
D11, D12, D14) explicitly listed; the lineage note's open item "Desktop-runtime comparison and parent acceptance
remain open" (`12-lineage-verification-2026-10-01.md:3085`) is closed with the evidence bundle.
Status: blocked: needs a desktop runtime with OP_LDR rows loaded (a device/environment outside this menu, D16).
Unblocks when the comparison environment is available; no source question remains.

## Coverage table

| Kind | Cases | Blocked | N/A entries | Notes |
|---|---|---|---|---|
| T01 Entry/defaults | 4 | 0 | 0 | 1 reused (entry.defaults) |
| T02 Field route | 5 | 0 | 0 | new OP_LDR selector routes; supersedes the module's T02 N/A for this scope |
| T03 Formula sequence | 8 | 0 | 0 | union, book-000 switch, silver quirk, FIFO, null date, list, future date |
| T04 Lookup | 1 | 0 | 0 | reused filter.account-lookup; no new lookup in the residual scope |
| T05 Children | 2 | 0 | 0 | 1 reused (drill.detail-children) |
| T06 Required/invalid | 7 | 0 | 0 | exact refusal texts |
| T07 Create | 0 | 0 | 1 | reused create.not-applicable (D5, Gap 13) |
| T08 Reopen/no-op | 0 | 0 | 1 | reused reopen.not-applicable (D5, Gap 13) |
| T09 Edit | 0 | 0 | 1 | reused edit.not-applicable (D5, Gap 13) |
| T10 Delete/cancel/reverse | 0 | 0 | 1 | reused delete.not-applicable (D5, Gap 13) |
| T11 Scope/rights | 4 | 0 | 0 | 1 reused (scope.rights) |
| T12 Concurrency | 0 | 0 | 1 | reused concurrency.not-applicable (D5, Gap 13) |
| T13 Retry/unknown | 0 | 0 | 1 | reused retry.not-applicable (D5, Gap 13) |
| T14 Rollback | 0 | 0 | 1 | reused rollback.not-applicable (D5, Gap 13) |
| T15 Config/history | 4 | 0 | 0 | edition, work type, half month, mfg type |
| T16 Report/output | 9 | 1 | 0 | 1 reused (output.exports); row shapes blocked (D6) |
| T17 Keyboard/usability | 4 | 0 | 0 | 1 reused (keyboard.enter-esc) |
| T18 Full journey | 3 | 1 | 0 | 1 reused (journey.summary-to-detail); desktop comparison blocked (D16) |

Totals: 58 entries — 49 executable (7 of them reused unchanged), 2 blocked, 7 N/A. Gap coverage:
1 (union, filters, FIFO, null date, future date, ownership, silent empty, presence location, journey),
2 (silver-quirk), 3 (book000-replaced, book000-without-op-ldr), 4 (account-list-combined), 5 (gold-figures,
gold-rows, mfg-type-j, summary-hz-choice, journey), 6 (silver-print, lc-code-empty), 7 (voucher-wise-summ,
voucher-wise-row-shapes blocked), 8 (jmaudr-print, in-out-print, work-type-ac-sale, print-buttons-drill-only,
print-hotkeys, lc-code-empty), 9 (print-rights-gold, print-rights-others, no-user-set-row, print-route-rights),
10 (lite-ageing-hidden), 11 (half-month-toggle), 12 (zoom-opening, zoom-rights), 13 (the seven N/A entries kept
valid by D5 plus the new T05/T16/T17 cases), 14 (desktop-comparison blocked). Every gap has at least one case
that fails today because of it, except Gap 14 whose case is blocked on the desktop device.

## Test data

The smallest seed set, described (no SQL). All rows carry the test tenant; company 01, year 2024-2025,
locations 01 and 02; the ageing to-date is fixed at 2024-06-30 and the company opening date at 2024-04-01.
Each case seeds only what it names and cleans it afterwards.

- Accounts (AC_MAST): Z500 "ZZ OPENER" (type A, city RAJKOT, group DEBTOR), Z501 "ZZ OLDONLY" (A, RAJKOT),
  Z502 "ZZ OPONLY" (A, RAJKOT), Z503 "ZZ BOOKONLY" (A, RAJKOT), Z504 "ZZ TYPEA" (A, RAJKOT), Z505 "ZZ TYPEB"
  (B, city SURAT), Z506 "ZZ NULLDATE" (A, RAJKOT), Z600 "ZZ PRINT" (A, RAJKOT), plus the existing module's
  Z100 "ZZ ALPHA" five-leg account for the reused cases.
- OP_LDR rows (the opening ledger; read-only in this form): Z500 location 01 dated 2024-04-21 DR_AMT 500,
  DR_GL_FINE 10.000, CR_GL_FINE 2.000, DR_SL_FINE 60.000, CR_SL_FINE 50.000, DATA_TYPE A (the distinct gold and
  silver columns make the D1 quirk observable); Z500 location 02 DR_AMT 777; Z500 DATA_TYPE B DR_AMT 50;
  Z502 DR_AMT 100; Z505 DR_AMT 800; Z506 VCH_DATE NULL DR_AMT 999; Z600 DR_AMT 30 (DR_GL_FINE 1.000) for the
  journey and DR_AMT 999 for the print-figures isolation; sentinels: company 02 DR_AMT 666 and another tenant
  DR_AMT 666. OP_LDR is written only by Year Create, Company and Import in the desktop
  (`MS_YEAR.cs:1464 {{DC_Main.ExeQuteDc("DELETE FROM OP_LDR WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");}}`,
  `MS_COMPANY.cs:6365 {{DC_Main.ExeQuteDc("DELETE FROM OP_LDR WHERE  CO_CODE = '" + tCoCode.Text + "'");}}`,
  `UT_IMPORT.cs:3495 {{DC_Main.ExeQuteDc("DELETE FROM OP_LDR WHERE CO_CODE = '" + DC_Main.MCo_code + "'");}}`);
  the web seeds it directly or via `configTables.ts:347` setOpeningLedger.
- AC_DATA legs: book-000 openings (Z500 DR 700 G '-' 5; Z501 carried-opening DR 250; Z503 DR 100; Z600 CR 100
  G '+' 1.5 S '+' 2.256); SALES movements (Z500 DR 300 G '-' 3 dated 2024-06-20, CR 400 G '+' 4 dated
  2024-05-01, the 700-credit variant, the future DR 200 dated 2024-07-05; Z504 DR 50 dated 2024-06-20; Z600
  DR 40 G '-' 0.5 dated 2024-05-10 and CR 60 G '+' 2.0 S '-' 1.0 dated 2024-06-15).
- Print source rows for Z600 inside 2024-04-01..2024-06-30: MAIN_STOCK gold items in books TR_AC_OPBL (fine
  1.25, SR_NO != 7, ITM_AMT 0), SALES (0.75), a CO_BOOK '018' row and an ITM_SIGN '+' receipt (1.0) for the
  Ac Sale exclusion, a silver item (3.5); PURCHASE (2.0), KARIGAR RECEIPT (0.5), GHAT REC (0.375),
  RATE_CUT_ISU (0.25), MTL ISU (0.125), OUTWORD via LOCT_MAST (0.0625), FTNG (0.75, only for MsMfgType J).
- Rights (USER_SET): one user with FRM_PRINT "Y" for the Ledger Report menu at location 01, one with "N", one
  with no row at all (D3); a user lacking the zoom target menu's view right.
- Settings variants: MsSoftType L / B / A; MsWorkType W and non-W; MsMfgType J and non-J; MsMetalType G and S;
  MsDataType A / B / C; MsLcBoxShow on; session location 01 with the box set to 02 for the W4 case.
- No FINE_DATA or LEDR_AC_DATA rows are seeded or expected: D5 keeps the request path free of staging writes.

## Not covered

- Ac Purc (`BtnPurcRpt_Click`, RP_LEDR.cs:10481 {{private void BtnPurcRpt_Click(object sender, EventArgs e)}}):
  out of the study's scope; no case.
- The OD button and the RP_INOUT form (bill-wise outstanding days): out of scope; only its edition visibility
  (`RP_LEDR.cs:4585 {{((Control)brnOsDay).Visible = true;}}`) and right menu ("Bill Os Day",
  `RP_LEDR.cs:11632 {{DC_Main.MsUserRightForm = "Bill Os Day";}}`) are noted in the study, not tested here.
- Crystal layout content (the .RPT pixel layout): out of scope; the cases assert template names, prompts,
  parameters and datasets, not the rendered layout.
- The Rojmel OP_LDR remarks: out of the study's scope.
- The OP_LDR write side (Year Create, Company delete, Import refill): other menus; cited under Test data for
  context only, tested by their own work packages.
- The DGV_AC/DGV_DETL/DGV_VCH grids and the Excel BtnSave export: already done in N223; the reused cases guard
  them, no new residual behaviour.
- The real-data distribution of silver between `*_SL_FINE` and `*_GL_FINE` (study Open question 1, data side):
  cannot be read without touching customer data (rule 9); D1 ports the desktop read regardless, so no case
  depends on the answer.
- The four voucher-wise row shapes are covered only by the blocked case output.voucher-wise-row-shapes (D6);
  they are not frozen until the second study pass lands.