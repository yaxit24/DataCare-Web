# WP-23 cases: Company → Balance TrFr (desktop `BtmSchm`)

Frozen case list built from `orchestration/work/WP-23/study.md` (21 gaps) and the supervisor's decisions. Desktop citations are
`BtmSchm.cs:LINE {{quoted text}}`. Nothing here is accepted; the web page matches the desktop 0% today, so every
executable case below fails today (gap number named in each case).

**Conventions.** Year N = 2025-26, closing date `MCl_dt` = 2026-03-31. Year N+1 = 2026-27, `OP_DATE` 2026-04-01, so the
desktop's `mTrfr_dt.AddDays(-1.0)` is 2026-03-31. Layers: `database` = test on the isolated database through the real
endpoint; `unit` = pure mapping or decimal rule; `browser` = real UI. Money is Cr-positive as on the desktop:
`Sum(A.CR_AMT-A.DR_AMT)`. Fine sign `'+'` means Cr. All arithmetic is exact decimal (never binary float), rounding half away
from zero (VB `Format`).

**Decisions applied (supervisor).** (D1) Only the five Lite datasets. (D2) Source rows, grouping, metal, skip and rounding
rules are the desktop's. (D3) The operator-visible result is asserted: the web **Party Opening** screen reads `OP_DATA`
(`partyOpening.mjs:124` `FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`) and the balance/ledger reads `AC_DATA` legs
(`partyOpening.mjs:131`); the web **Item Opening** screen reads `ITM_OPBL` (`itemOpening.mjs:167`). (D4) A re-run
**replaces**; delete scope is the target year only. (D5) One transaction per button. (D6) Tag, Order, Approval column lists
read from the desktop. (D7) `AC_MAST` copy is `N/A`; visit and closing-year side effects are under "Not covered". (D8) Texts
verbatim, Esc closes, create right. (D9) No print.

Two facts found while reading that the study left open, used below:
- `HAVING` on the Ac Balance query adds money, gold, silver and diamond **into one signed number**: BtmSchm.cs:2786 {{HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(}}. A party with 50.00 Cr and 50.000 gold Dr sums to 0 and is dropped, although both balances are real.
- Sales Order and Approval rows are carried **with their original `CO_YEAR`** (study §D, §E). In a one-database web the carried row and its source row would share a key, so how the carry is represented is a decision (Question Q1). The column cases for those two datasets are therefore `unit` cases on the mapping; the database and browser identity cases for them are `blocked`.

## T01 Entry and defaults

### balance-transfer.entry.five-lite-buttons   (T01 Entry/defaults)
Layer: browser
Steps: 1. Sign in as a user with the menu right. 2. Open Company → Balance TrFr. 3. List every button in the transfer group in tab order.
Expected: exactly `Ac Balance`, `Item Stock`, `Tag Stock`, `Sales Order`, `Approval`, in that tab order (BtmSchm.cs:1373 {{((Control)BtnAcBalence).TabIndex = 1;}}, BtmSchm.cs:1310 {{((Control)BtnItmStk).TabIndex = 2;}}, BtmSchm.cs:1341 {{((Control)BtnTagStock).TabIndex = 3;}}). The page offers no link list to Year Create, Dhiran, Loan or MFG Issue (gap 20, D1).
Status: executable

### balance-transfer.entry.non-lite-absent   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the page. 2. Search the DOM for `Scheme`, `Dhiran`, `Loan`, `Bill Os Trfr`, `Time Ldr Trfr`, `Jadtar Trfr`, `Bill Orna Isu`, `Vp Trfr`, `Bullion Trfr`, `Order Traking`, `Reparing Trfr`, `Item Lot Trfr`, `Tag Idtl Trfr`, `Mfg Trfr`.
Expected: none present. Desktop hides the Jadtar and Mfg buttons by default (BtmSchm.cs:1641 {{((Control)lblJadtarTrfr).Visible = false;}}, BtmSchm.cs:1891 {{((Control)btnMfgTrfr).Visible = false;}}) and the others belong to menus that are not Lite. Gap 20.
Status: executable

### balance-transfer.entry.title-and-caption   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the page.
Expected: the title is `Balance TrFr` (the menu caption, BtmSchm.cs:1947 {{lblBook.Text = CurProcess;}}); the label `Transfer Year` (BtmSchm.cs:1391 {{Transfer Year}}) sits next to the target year.
Status: executable

### balance-transfer.entry.default-target-year   (T01 Entry/defaults)
Layer: browser
Steps: 1. Seed YEAR_MAST with 2025-26 (current) and 2026-27, 2027-28. 2. Open the page.
Expected: the target year shows 2026-27, the first later year: BtmSchm.cs:2091 {{AND CO_YEAR > '" + DC_Main.MCo_year + "' ORDER BY CO_YEAR}}. Not `year + 1` guessed (gap 14). Opening date used for tags is that year's `OP_DATE` (BtmSchm.cs:2104 {{mTrfr_dt = Conversions.ToDate(DC_Main.Rshlp.Rows[0]["OP_DATE"]);}}).
Status: executable

### balance-transfer.entry.initial-focus   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the page; read the focused element.
Expected: focus is on `Ac Balance`, the first tab stop (TabIndex 1, BtmSchm.cs:1373 {{((Control)BtnAcBalence).TabIndex = 1;}}).
Status: executable

## T02 Field route

### balance-transfer.field.target-year-route   (T02 Field route)
Layer: database
Steps: 1. Seed YEAR_MAST 2025-26, 2026-27, 2027-28 and a party with a balance. 2. Click `Ac Balance` and confirm. 3. Inspect the request, then `OP_DATA`.
Expected: the request names 2026-27; every written `OP_DATA` row has `CO_YEAR` 2026-27 (BtmSchm.cs:2801 {{INSERT INTO OP_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,}} with `CO_YEAR` = `tYearCode.Text`); zero rows for 2027-28.
Status: executable (gap 14)

### balance-transfer.field.target-year-not-free-text   (T02 Field route)
Layer: browser
Steps: 1. Try to type `2099-00` into the target year. 2. Call the API directly with `2099-00`.
Expected: the control is not editable; the server answers a refusal and writes nothing. The desktop text box is typeable (study, question 2) and writers read whatever is typed (BtmSchm.cs:2129 {{TrfrMdbName = "Next" + Strings.Mid(tYearCode.Text, 3, 2);}}); the web must not (deliberate difference).
Status: executable (gap 14)

## T03 Formula sequence (Ac Balance and Item Stock rules; each its own case)

### balance-transfer.ac.rule.party-only   (T03 Formula sequence)
Layer: database
Seed: P1 (`AC_MAIN_GR` '1') Cr 100.00; P2 (`AC_MAIN_GR` '2') Cr 200.00; X3 (`AC_MAIN_GR` '3') Cr 300.00; X5 cash head (`AC_MAIN_GR` '5') Dr 400.00; all in year N, dated before the closing date.
Steps: 1. Run `Ac Balance`. 2. Read `OP_DATA` year N+1.
Expected: rows for P1 (100.00 C) and P2 (200.00 C) only. X3 and X5 absent (BtmSchm.cs:2786 {{B.AC_MAIN_GR < '3' and VCH_DATE <=}}: '3' is not < '3').
Status: executable (gap 1; web takes every account)

### balance-transfer.ac.rule.closing-date-bound   (T03 Formula sequence)
Layer: database
Seed: P1 Cr 1000.00 dated 2026-03-31 (the closing date, included); P1 Dr 400.00 dated 2026-03-30; P1 Dr 999.00 dated 2026-04-01 with `CO_YEAR` N (late entry); P1 Dr 77.00 dated 2026-04-05 with `CO_YEAR` N+1.
Expected: closing = 1000.00 − 400.00 = 600.00 C. The 2026-04-01 and the N+1 vouchers are excluded (BtmSchm.cs:2786 {{B.AC_MAIN_GR < '3' and VCH_DATE <=}}; the web has one database, so the year filter also keeps N+1 vouchers out). OP_AMT 600.00, OP_SIGN 'C'.
Status: executable (gap 1)

### balance-transfer.ac.rule.location-scope   (T03 Formula sequence)
Layer: database
Seed: P1 Cr 500.00 at location L1; P1 Cr 70.00 at location L2 (same company and year). Run for L1.
Expected: OP_AMT 500.00 only (BtmSchm.cs:2786 {{FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE}} and `A.LC_CODE = '` + `MLc_code`).
Status: executable (gap 1; web ignores `LC_CODE`)

### balance-transfer.ac.rule.one-row-per-data-type   (T03 Formula sequence)
Layer: database
Seed: P2 ledger A: Cr 700.00; P2 ledger B: Dr 200.00 (`DATA_TYPE` 'A' and 'B').
Expected: two rows: (P2, 'A', OP_AMT 700.00, 'C') and (P2, 'B', OP_AMT 200.00, 'D'). Not one row of 500.00. BtmSchm.cs:2786 {{GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE}}.
Status: executable (gap 3)

### balance-transfer.ac.rule.sign-cr-positive   (T03 Formula sequence)
Layer: database
Seed: P1 Cr 80.00 (net +80.00); P2 Dr 80.00 (net −80.00).
Expected: P1 OP_AMT 80.00 'C'; P2 OP_AMT 80.00 'D'. The row amount is |amount| and the sign is 'C' when amount > 0 else 'D' (study §A.5; BtmSchm.cs:2799 {{Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["Amount"])))}}). The web's debit-positive Σ(DR−CR) flips the sign convention: wrong today.
Status: executable (gap 4)

### balance-transfer.ac.rule.gold-by-it-type   (T03 Formula sequence)
Layer: database
Seed: P3: money Cr 1000.00 and Dr 1000.00 (net 0.00); gold lines (`IT_TYPE` 'G'): Cr ('+') 10.500, Dr ('-') 2.250; silver line (`IT_TYPE` 'S'): Dr ('-') 100.000.
Expected: Amount 0.00; gold = 10.500 − 2.250 = 8.250 → FINE_BAL 8.250, FINE_SIGN 'C'; silver = −100.000 → SL_FINE_BAL 100.000, SL_FINE_SIGN 'D'. Kept (money 0 + gold 8.250 + silver −100.000 = −91.750 ≠ 0). Both metals survive on one row. BtmSchm.cs:2786 {{format(SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as GoldWt}} and BtmSchm.cs:2786 {{format(sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as SilverWt}}. The web merges both metals into one number with one type (yearEnd.ts:118, :124).
Status: executable (gap 4)

### balance-transfer.ac.rule.zero-value-sign-d   (T03 Formula sequence)
Layer: database
Seed: P3 as above (money net 0.00).
Expected: the written OP_SIGN is 'D' for the zero money value: sign is 'C' only when the value is > 0 (study §A.5). A party with money 0.00, gold +8.250 gets OP_AMT 0.00 OP_SIGN 'D', FINE_SIGN 'C'. `carryForwardOpenings` gives 'C' for a zero (year.ts:163 `goldSign: gold >= 0 ? 'C' : 'D'`).
Status: executable (gap 4)

### balance-transfer.ac.rule.non-party-metal-ignored   (T03 Formula sequence)
Layer: database
Seed: P1 with a lot line of `IT_TYPE` 'X' (other) FINE_WT 5.000 Cr and no money.
Expected: gold and silver are 0.000; Amount 0.00; |0|+|0|+|0| = 0 so no row (the 'X' type is not summed by either metal expression; BtmSchm.cs:2799 {{Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["Amount"])))}}).
Status: executable (gap 4)

### balance-transfer.ac.rule.skip-true-zero   (T03 Formula sequence)
Layer: database
Seed: P1 Cr 70.00 and Dr 70.00; P2 Dr 0.10 ×3 and Cr 0.30.
Expected: no row for P1 and none for P2 (net 0.00 exactly in decimals; in binary float 0.1+0.1+0.1 = 0.30000000000000004).
Status: executable (gap 6)

### balance-transfer.ac.rule.skip-no-tolerance   (T03 Formula sequence)
Layer: database
Seed: P1 Cr 0.004 (a three-decimal amount, only if the column keeps three decimals; else use gold 0.0004).
Expected: the grouped sum is rounded first: 0.004 → '0.00' → amount 0 → no row. And P2 Cr 0.005 → '0.01' → row OP_AMT 0.01 'C'. The web's tolerance `<= 0.005` (yearEnd.ts:141 {{if (Math.abs(balance) <= 0.005 && Math.abs(fineWt) <= 0.0005) continue;}}) would drop P2's 0.01.
Status: executable (gap 6)

### balance-transfer.ac.rule.skip-diamond-only   (T03 Formula sequence)
Layer: database
Seed: P4 with only a diamond line (`IT_TYPE` 'D') 3.000 Cr; no money, no gold, no silver.
Expected: passes the HAVING (diamond is in it) but |amount|+|gold|+|silver| = 0, so **no row** (study §A.4-5; BtmSchm.cs:2799 {{Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["Amount"])))}}). Diamond fine is not carried.
Status: executable (gap 4, gap 6)

### balance-transfer.ac.rule.having-offset-money-vs-gold   (T03 Formula sequence)
Layer: database
Seed: P5 money Cr 50.00 and gold Dr 50.000 (net money +50.00, gold −50.000).
Expected by the desktop code: HAVING sum = 50.00 − 50.000 = 0, so P5 is **dropped** (BtmSchm.cs:2786 {{HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(}}), which loses two real balances and breaks closing(N) = opening(N+1).
Status: executable, deliberate difference (Q2 decided 2026-11-22 by the architect, owner may override): the web carries both balances (50.00 C and gold 50.000 D); dropping loses data. Passes at the database layer and in the browser module.

### balance-transfer.ac.round.money-half-up-positive   (T03 Formula sequence)
Layer: unit and database
Seed: P1 Cr 10.00 and Cr 0.005 (sum 10.005).
Expected: `format(...,'0.00')` of 10.005 → 10.01 (half away from zero); OP_AMT 10.01 'C'. Binary float: 10.005×100 = 1000.4999999999999 → 10.00 (wrong). yearEnd.ts:47 {{const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;}}.
Status: executable (gap 5)

### balance-transfer.ac.round.money-half-up-negative   (T03 Formula sequence)
Layer: unit and database
Seed: P2 Dr 20.00 and Dr 0.005 (sum −20.005).
Expected: −20.005 → −20.01 (away from zero, not banker's, not toward +∞); OP_AMT 20.01 'D'.
Status: executable (gap 5)

### balance-transfer.ac.round.gold-three-decimals   (T03 Formula sequence)
Layer: unit and database
Seed: P3 gold Cr ('+') 1.2340 and Cr 0.0005 (sum 1.2345); silver Dr ('-') 2.0005.
Expected: gold 1.2345 → '1.235' → FINE_BAL 1.235 'C'; silver −2.0005 → '-2.001' → SL_FINE_BAL 2.001 'D'. Needs a fine-weight column with ≥ 4 decimals; if the column stores 3 decimals, the unit layer carries the case alone.
Status: executable (gap 5)

### balance-transfer.ac.round.group-then-round   (T03 Formula sequence)
Layer: database
Seed: P1 three vouchers Cr 0.004 each (sum 0.012).
Expected: round after grouping: 0.012 → 0.01. Rounding each voucher first would give 0.00.
Status: executable (gap 5)

### balance-transfer.item.rule.closing-worked   (T03 Formula sequence)
Layer: database
Seed: untagged item I1 (`ITEM_RATE` 50.00): IN ('+') 10 pcs, gross 100.500, net 98.250; OUT ('-') 4 pcs, gross 40.200, net 39.300; all dated up to the closing date.
Expected: ClPcs 10 − 4 = 6; ClWtGr 100.500 − 40.200 = 60.300; ClWt 98.250 − 39.300 = 58.950; ItAmt = 6 × 50.00 = 300.00. ITM_OPBL row: ITM_PCS 6, ITM_GWT 60.300, ITM_NWT 58.950, ITM_AMT 300.00, NET_AMT 300.00, ITM_RATE 0, LBR_AMT 0, OTH_AMT 0. BtmSchm.cs:2933 {{SUM(iif(ITM_SIGN = '+', ITM_PCS, -ITM_PCS)) AS ClPcs}}, BtmSchm.cs:2933 {{SUM(iif(ITM_SIGN = '+',ITM_NWT,-ITM_NWT)) AS ClWt}}.
Status: executable (gap 9)

### balance-transfer.item.rule.fine-from-touch   (T03 Formula sequence)
Layer: database
Seed: I1 as above.
Expected: ITM_FINE = Format(ITM_NWT × ITM_TOUCH / 100, "0.000") read from the **written** row: with ITM_TOUCH 91.600, 58.950 × 91.600 / 100 = 53.9982 → 53.998 (BtmSchm.cs:2960 {{num = Conversions.ToDouble(Strings.Format((object)Conversion.Val((object)(num5 * num6 / 100.0)), "0.000"));}}).
Status: executable (gap 9). Pinning ITM_TOUCH itself is the next case.

### balance-transfer.item.rule.touch-is-recomputed-average   (T03 Formula sequence)
Layer: database
Seed: I1 with all lines at touch 91.600.
Expected: ITM_TOUCH 91.600, the item's recomputed `AVG_TOUCH` (BtmSchm.cs:2931 {{DC_Main.AvgTouch(DC_Main.MsSysDate, DC_Main.MLc_code);}}).
Status: blocked: `DC_Main.AvgTouch` (DC_Main.cs:1698 {{UPDATE ITEM_MAST SET AVG_TOUCH = 0,AVG_FINE = 0,AVG_NWT = 0,AVG_RATE = 0}} onwards, several branches by `MsBalanceSheetType`) was not read in full; another work package or the owner must say which branch applies to Lite and whether it is dated `MsSysDate` or the closing date.

### balance-transfer.item.rule.fine-half-up   (T03 Formula sequence)
Layer: unit
Seed: nwt 12.345, touch 50.000 → 12.345 × 50 / 100 = 6.1725 → '6.173'; nwt 0.001, touch 50.000 → 0.0005 → '0.001'.
Expected: 6.173 and 0.001 (half away from zero, exact decimal). Binary float 12.345×50/100 can give 6.172499…
Status: executable (gap 9, gap 5)

### balance-transfer.item.rule.tagged-excluded   (T03 Formula sequence)
Layer: database
Seed: I1 untagged stock as above plus tag T001 of I1 (IN 1 pc, 5.000 g) with `TAG_NO` 'T001'.
Expected: ITM_OPBL for I1 stays 6 pcs / 58.950; the tagged piece is not in ITM_OPBL (BtmSchm.cs:2933 {{(A.TAG_NO = 'N' OR A.TAG_NO = '' OR A.TAG_NO IS NULL)}}); it is carried by Tag Stock.
Status: executable (gap 9)

### balance-transfer.item.rule.skip-sold-out   (T03 Formula sequence)
Layer: database
Seed: item I2: IN 5 pcs, gross 25.000, net 24.000; OUT 5 pcs, gross 25.000, net 24.000.
Expected: no ITM_OPBL row for I2 (gross + net + pcs = 0; BtmSchm.cs:2964 {{Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ClWtGr"])) + Conversion.Val(}}).
Status: executable (gap 9)

### balance-transfer.item.rule.skip-signed-sum-offset   (T03 Formula sequence)
Layer: database
Seed: item I3 closing pcs +5, gross −2.500, net −2.500 (a data error: more weight issued than received).
Expected by the desktop code: signed sum 5 − 2.5 − 2.5 = 0, skipped. Silently loses a stock position (weakness 5).
Status: executable, deliberate difference (Q3 decided 2026-11-22 by the architect, owner may override): the web carries the row (5 pcs, −2.500, −2.500). Passes at the database layer.

### balance-transfer.item.rule.closing-date-and-year   (T03 Formula sequence)
Layer: database
Seed: I1 with an extra IN 3 pcs dated 2026-04-02 (year N, late entry) and an extra IN 2 pcs in year N+1.
Expected: both excluded; ITM_PCS stays 6 (BtmSchm.cs:2933 {{AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE <=}}).
Status: executable (gap 9)

## T05 Children (stone rows follow their tag, order and approval line)

### balance-transfer.tag.children.stone-rows-follow-tag   (T05 Children)
Layer: database
Seed: items I4 with tag T010 (two BAR_IDTL rows: diamond 0.250 ct, stone 0.100 ct) and tag T011 (one BAR_IDTL row 0.050 ct), both in stock.
Steps: 1. Run `Tag Stock`.
Expected: next-year BAR_IDTL has 2 rows owned by T010 with `ISR_NO` 1 and 2 and 1 row owned by T011 with `ISR_NO` 1 (BtmSchm.cs:2520 {{INSERT INTO BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO}} insert; `ISR_NO` = R+1 per tag, study §C). No stone row moved to the other tag.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; this case only checks the desktop's copied rows/columns.

### balance-transfer.order.children.lines-and-stones   (T05 Children)
Layer: unit
Seed: two open orders O1 (2 detail lines, 1 stone row on line 2) and O4 (1 line).
Expected: the mapped lines keep their order's `CO_YEAR`, `CO_BOOK`, `VCH_NO` and `SR_NO`; the stone row stays on O1 line 2 (BtmSchm.cs:3137 {{INSERT INTO SL_ORD_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,}}).
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; this case only checks the desktop's copied rows/columns.

### balance-transfer.approval.children.stones-follow-line   (T05 Children)
Layer: unit
Seed: two open approval lines A1 (two stone rows) and A2 (none).
Expected: APR_IDTL carries 2 rows for A1, with their `ISR_NO`, 0 for A2 (BtmSchm.cs:4291 {{INSERT INTO APR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,}}).
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; this case only checks the desktop's copied rows/columns.

## T06 Required and invalid

### balance-transfer.invalid.no-next-year-message   (T06 Required/invalid)
Layer: browser
Steps: 1. Seed a company whose current year is the last in YEAR_MAST. 2. Open the page.
Expected: the message `There Are Not Found New Year Please Creat New Year And Try....` (BtmSchm.cs:2142 {{There Are Not Found New Year Please Creat New Year And Try....}}); the five buttons are disabled (the desktop leaves them live, weakness 8: deliberate difference); no request is sent on click.
Status: executable (gap 14)

### balance-transfer.invalid.server-refuses-no-year   (T06 Required/invalid)
Layer: database
Steps: 1. Call each of the five writes with an empty year, with the current year as target, with a year that is not in YEAR_MAST, and with an earlier year.
Expected: a refusal each time; zero rows written in any table; no change to the closing year. (Desktop writers would run with `''`; weakness 8.)
Status: executable (gap 14, gap 13)

### balance-transfer.invalid.cancel-does-not-blank-year   (T06 Required/invalid)
Layer: browser
Steps: 1. Click `Cancel`. 2. Click `Ac Balance`.
Expected: the target year is still 2026-27 (the desktop `CLEAR_DATA` blanks it: BtmSchm.cs:2641-2652 {{val.Text = "";}}, weakness 8) and the run writes to 2026-27.
Status: executable (gap 14)

### balance-transfer.invalid.confirm-no-aborts   (T06 Required/invalid)
Layer: browser
Steps: 1. Click `Ac Balance`; at the confirmation choose `No`. 2. Repeat for each button.
Expected: no request is sent, no row written, no completion message (BtmSchm.cs:2729 {{(MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)}}).
Status: executable (gap 13)

## T07 Create (first run, full footprint)

### balance-transfer.ac.create.footprint   (T07 Create)
Layer: browser then database
Seed: P1 Cr 5000.00 (2025-06-01), Dr 1200.50 (2025-07-10), Dr 300.25 (2026-03-31), Cr 999.00 dated 2026-04-01 year N (excluded).
Steps: 1. Click `Ac Balance`; confirm; read the completion message. 2. Query.
Expected: message `Process Are Complete....` (BtmSchm.cs:2755 {{Process Are Complete....}}). Closing = 5000.00 − 1200.50 − 300.25 = 3499.25 Cr. One `OP_DATA` row: CO_YEAR 2026-27, CO_BOOK '000', VCH_NO '00000', AC_CODE P1, OP_AMT 3499.25, OP_SIGN 'C', FINE_BAL 0.000 FINE_SIGN 'D', SL_FINE_BAL 0.000 SL_FINE_SIGN 'D', DATA_TYPE 'A', DATA_TRFR 'Y' (BtmSchm.cs:2801 {{INSERT INTO OP_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,}}). No row in any other table of year N.
Status: executable (gaps 2, 13)

### balance-transfer.item.create.footprint   (T07 Create)
Layer: browser then database
Seed: I1 as in `item.rule.closing-worked`.
Steps: 1. Click `Item Stock`; confirm.
Expected: one ITM_OPBL row: CO_YEAR 2026-27, CO_BOOK '000', IT_CODE I1, VCH_NO = the item's type code, SR_NO 1, ITM_PCS 6, ITM_GWT 60.300, ITM_NWT 58.950, ITM_FINE 53.998, ITM_AMT 300.00, NET_AMT 300.00, DATA_TRFR 'Y', DATA_TYPE 'A' (BtmSchm.cs:2966 {{INSERT INTO ITM_OPBL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,IT_CODE,VCH_NO,SR_NO,}}). Message `Process Are Complete....`.
Status: executable (gap 9)

### balance-transfer.tag.create.footprint   (T07 Create)
Layer: database
Seed: item I4 (type G) with tags T001 and T002 in stock and item I5 with tag T003 in stock; next year has no book-000 vouchers. T001: 5.000 gross, 4.800 net, touch 91.600, fine 4.397; T002: 7.000 / 6.500 / 91.600 / 5.954.
Steps: 1. Click `Tag Stock`; confirm.
Expected: 3 BAR_DETL rows (CO_YEAR 2026-27, CO_BOOK '000', INOUT 'I', ENTRY 'O', VCH_DATE 2026-03-31, STK_DATE copied, all weights/fine/touch copied unchanged); BAR_DATA headers: I4 → VCH_NO 00001, I5 → 00002, OP_STK 'Y' (BtmSchm.cs:2324 {{string text = "00001";}}, BtmSchm.cs:2627 {{INSERT INTO BAR_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE, AC}}). BAR_DETL for I4 carry VCH_NO 00001, SR_NO 1 and 2; I5 carries VCH_NO 00002.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; this case only checks the desktop's copied rows/columns.

### balance-transfer.tag.create.date-is-day-before-opening   (T07 Create)
Layer: database
Seed: as above.
Expected: VCH_DATE on every carried BAR_DETL and BAR_DATA row is 2026-03-31 = `OP_DATE` 2026-04-01 minus one day (BtmSchm.cs:2378 {{mTrfr_dt.AddDays(-1.0)}}).
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; this case only checks the desktop's copied rows/columns.

## T08 Reopen and no-op

### balance-transfer.reopen.party-opening-screen-shows-carry   (T08 Reopen/no-op)
Layer: browser
Steps: 1. Run `Ac Balance` (seed of `ac.create.footprint`). 2. Switch to year N+1; open Master → Party Opening and select P1.
Expected: the screen shows P1 as 3,499.25 Cr (read from `OP_DATA`, partyOpening.mjs:124). Saving it unchanged leaves the same `OP_DATA` row and the same legs (partyOpening.mjs "reload ... saving them unchanged keeps one OP_DATA row").
Status: executable (gap 21)

### balance-transfer.reopen.item-opening-screen-shows-carry   (T08 Reopen/no-op)
Layer: browser
Steps: 1. Run `Item Stock`. 2. Year N+1, Master → Item Opening, the type of I1.
Expected: I1 row 6 pcs, gross 60.300, net 58.950, amount 300.00 (read from `ITM_OPBL`, itemOpening.mjs:167).
Status: executable (gap 21)

### balance-transfer.reopen.tag-opening-screen-shows-carry   (T08 Reopen/no-op)
Layer: browser
Steps: 1. Run `Tag Stock`. 2. Year N+1, Tag Opening and Tag Stock report.
Expected: T001, T002, T003 listed with their original weights and fines; count 3.
Status: executable (Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing); browser case not built yet (needs a session-year switch).

### balance-transfer.reopen.rerun-unchanged-is-identical   (T08 Reopen/no-op)
Layer: database
Steps: 1. Run each of the five buttons twice with nothing changed in between. 2. Compare a full dump of the carried rows (all columns, including NULLs and `ADD_DATE`) between run 1 and run 2.
Expected: identical, row for row; `ADD_DATE` NULL stays NULL (study §A.6).
Status: executable for all five buttons: Ac Balance and Item Stock rewrite identical rows; Tag Stock, Sales Order and Approval write nothing (Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing). Passes at the database layer.

## T09 Edit (re-run after a change replaces, never doubles)

### balance-transfer.rerun.ac-balance-replaces   (T09 Edit)
Layer: database
Seed: `ac.create.footprint`, run once; then add P1 Dr 249.25 dated 2026-03-20 in year N; run again.
Expected: still one OP_DATA row for P1: 3499.25 − 249.25 = 3250.00 C. Never 3499.25 + 3250.00 and never two rows (BtmSchm.cs:2764 {{ExeQuteTrfr("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE =}}).
Status: executable (gap 7, gap 21)

### balance-transfer.rerun.ac-balance-removes-party-gone-to-zero   (T09 Edit)
Layer: database
Seed: run once; then add P1 Dr 3499.25 so P1 nets 0.00; run again.
Expected: no OP_DATA row for P1 after the second run (the first row is deleted, nothing rewritten).
Status: executable (gap 7)

### balance-transfer.rerun.manual-opening-edit-is-replaced   (T09 Edit)
Layer: database
Seed: run once; edit P1's opening to 1.00 Dr in the Party Opening screen of N+1; run again.
Expected: P1 is back to 3499.25 C (the carry replaces the manual edit; as the desktop deletes then rewrites). One row, one set of ledger legs.
Status: executable (gap 7)

### balance-transfer.rerun.no-double-ledger-legs   (T09 Edit)
Layer: database
Steps: 1. Run `Ac Balance` twice. 2. Sum the opening-day AC_DATA legs (book '000' and `ACOP`) of P1 in N+1.
Expected: exactly one set of legs, net 3,499.25 Cr, not 6,998.50. The web today has two writers for the same menu (`yearEnd.ts:268` ACOP leg, `carryForwardOpenings` TR_AC_OPBL leg).
Status: executable (gap 2)

### balance-transfer.rerun.item-stock-replaces   (T09 Edit)
Layer: database
Seed: `item.create.footprint` once; add an OUT of 1 pc, gross 10.000, net 9.800 to I1 dated 2026-03-25; run again.
Expected: one ITM_OPBL row: pcs 5, gross 50.300, net 49.150, amount 5 × 50.00 = 250.00 (BtmSchm.cs:2932 {{DELETE FROM ITM_OPBL WHERE CO_CODE}} then rewrite).
Status: executable (gap 9)

### balance-transfer.rerun.tag-stock-replaces-and-counter-restarts   (T09 Edit)
Layer: database
Seed: `tag.create.footprint` once; sell T002 in year N dated 2026-03-28; run again.
Expected: BAR_DETL carry rows 2 (T001, T003), BAR_DATA 2 headers: I4 → 00001, I5 → 00002 (counter restarts at 00001: BtmSchm.cs:2321 {{DELETE FROM BAR_DATA WHERE CO_CODE}}, :2322 and :2323 delete the day's rows; BtmSchm.cs:2324 {{string text = "00001";}}). No row for T002.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; no voucher counter exists. Pressing Tag Stock twice changes nothing (balanceTransferSelect.db.test.ts, passes).

### balance-transfer.rerun.tag-counter-continues-after-other-vouchers   (T09 Edit)
Layer: database
Seed: next year already holds a book-'000' BAR_DATA voucher 00007 on 2026-04-10 (a user entry, not the opening day); run `Tag Stock`.
Expected: the headers start at 00008 (MAX+1: BtmSchm.cs:2338 {{SELECT MAX((VCH_NO)) AS CoCode  From BAR_DATA}}); the 2026-04-10 voucher is untouched.
Status: blocked (WP-23 build): Q8, see `tag.create.footprint`. Also the expectation conflicts with the code: the counter moves on only when it reaches the first existing book-000 voucher (BtmSchm.cs:2369-2371 `if (text2 == text) text = text3`), so with only 00007 present two items get 00001 and 00002, not 00008; the case needs re-deriving before it runs.

### balance-transfer.rerun.sales-order-replaces   (T09 Edit)
Layer: database
Seed: `order.create.carried-set`, run twice.
Expected: the set of carried orders is the same after run 2 as after run 1; no order appears twice.
Status: executable (Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing); passes at the database layer: next year's open set equals the closing year's and two presses change nothing (balanceTransferSelect.db.test.ts).

### balance-transfer.rerun.approval-replaces   (T09 Edit)
Layer: database
Seed: `approval.create.carried-set`, run twice.
Expected: APR_DETL carried set unchanged; the book-'218' BAR_DETL rows exist once each (BtmSchm.cs:4140 {{DELETE FROM BAR_DETL WHERE CO_CODE}} and :4141 delete CO_BOOK '218' rows, then reinsert).
Status: executable (Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing); passes at the database layer: next year's open set equals the closing year's and two presses change nothing (balanceTransferSelect.db.test.ts).

## T10 Delete, cancel, reverse

### balance-transfer.delete.target-year-only   (T10 Delete/cancel/reverse)
Layer: database
Seed: OP_DATA rows for P1 in year N (a real opening) and in N+1 (stale carry); run `Ac Balance` to N+1.
Expected: the year-N row is untouched; the N+1 row is replaced. The desktop deletes the company and location across every year (BtmSchm.cs:2764 {{ExeQuteTrfr("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE =}}): deliberate difference (D4). Same for ITM_OPBL (BtmSchm.cs:2932 {{DELETE FROM ITM_OPBL WHERE CO_CODE}}).
Status: executable (gap 7)

### balance-transfer.delete.user-vouchers-in-next-year-survive   (T10 Delete/cancel/reverse)
Layer: database
Seed: N+1 holds a normal sale voucher for P1 and a Party Opening for P2 entered by a user before the carry (P2 is not in year N).
Expected: P1's sale is untouched. P2's N+1 opening: the desktop deletes all OP_DATA of the company and location, so P2's row disappears on the desktop. Web expectation: target-year `OP_DATA` is replaced, so P2's row is removed too (the carry owns the year's openings).
Status: blocked: Q4 (does a hand-keyed opening of a party with no year-N balance survive a carry? The desktop removes it; the decision says "target year only", which still removes it).

### balance-transfer.delete.print-and-delete-buttons   (T10 Delete/cancel/reverse)
Layer: browser
Expected: the page has no `Delete` and no `Print`; the desktop `Delete` handler has an empty body (BtmSchm.cs:2720-2723 {{private void BtnDelete_Click(object sender, EventArgs e)}}) and `Print` too (BtmSchm.cs:2699-2701 {{private void BtnPrint_Click(object sender, EventArgs e)}}).
Status: N/A for behaviour; the absence is checked in `entry.five-lite-buttons`.

## T11 Scope and rights

### balance-transfer.rights.create-right-required   (T11 Scope/rights)
Layer: database
Steps: 1. Call each of the five writes as a user with `view` only, as one with `update` only, and as one with `create`. 2. Check the menu entry's rights string.
Expected: only the user with the create right succeeds (catalog `C-----`); the other two get 403 and no rows are written. The web uses `view` and `update` (txn.ts:7985 {{if (!guard(req, reply, 'view')) return;}}, txn.ts:8008 {{if (!guard(req, reply, 'update')) return;}}).
Status: executable (gap 18)

### balance-transfer.scope.other-tenant-sentinel   (T11 Scope/rights)
Layer: database
Seed: a second tenant with a party balance and tags, same codes.
Expected: running every button for tenant 1 changes no row of tenant 2 and reads none of its vouchers into tenant 1's openings.
Status: executable

### balance-transfer.scope.other-company-and-location   (T11 Scope/rights)
Layer: database
Seed: company C2 and location L2 of the same tenant with balances.
Expected: a run for (C1, L1) writes only (C1, L1) rows; request bodies naming C2 or L2 are refused or ignored.
Status: executable (gap 1)

### balance-transfer.scope.reused-ids   (T11 Scope/rights)
Layer: database
Steps: 1. Send a write with a target year that belongs to another company's YEAR_MAST.
Expected: refused; nothing written.
Status: executable

## T12 Concurrency

### balance-transfer.concurrency.same-button-twice   (T12 Concurrency)
Layer: database
Steps: 1. Fire two `Ac Balance` requests for the same scope at the same time (100 repetitions).
Expected: after both finish: one row per account and `DATA_TYPE`, amounts equal the single-run result; no unique-key error shown to the user.
Status: executable (gap 15)

### balance-transfer.concurrency.carry-versus-voucher   (T12 Concurrency)
Layer: database
Steps: 1. Start `Ac Balance` while another session saves a year-N voucher for P1 dated before the closing date.
Expected: the carry reflects either all or none of that voucher (one read snapshot), never half of a voucher's legs; a run after both finishes reflects it fully.
Status: executable

### balance-transfer.concurrency.tag-sale-during-carry   (T12 Concurrency)
Layer: database
Steps: 1. Start `Tag Stock` while another session sells T001 in year N.
Expected: T001 is carried in a run that read it as in stock and not carried after the sale commits; never carried twice, and the opening is consistent with a rerun.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; the button only reads, so a sale during it cannot be half-carried.

## T13 Retry and unknown outcome

### balance-transfer.retry.duplicate-request   (T13 Retry/unknown)
Layer: database
Steps: 1. Send the same write twice with the same idempotency key (or no key). 2. Compare.
Expected: the second answer reports the same completion; carried rows identical to a single run.
Status: executable (gap 15)

### balance-transfer.retry.lost-ack-after-commit   (T13 Retry/unknown)
Layer: browser
Steps: 1. Drop the response of `Item Stock` after the server commits. 2. Click the button again and confirm.
Expected: ITM_OPBL holds the single-run result (replace, not double); the user sees `Process Are Complete....`.
Status: executable

## T14 Rollback

### balance-transfer.rollback.ac-balance-after-first-table   (T14 Rollback)
Layer: database
Seed: `ac.create.footprint` carried once; then change P1's year-N closing and inject a failure after the delete of OP_DATA and before the last insert.
Expected: the whole run rolls back: OP_DATA still shows the first carry (3499.25 C); a sentinel opening of another year unchanged; no leg half-written; the user sees an error, not `Process Are Complete....` (BtmSchm.cs:2755 {{Process Are Complete....}}; weakness 9).
Status: executable (gap 15)

### balance-transfer.rollback.item-stock-after-delete   (T14 Rollback)
Layer: database
Expected: injecting a failure after the ITM_OPBL delete leaves the previous ITM_OPBL rows intact.
Status: executable (gap 15)

### balance-transfer.rollback.tag-stock-after-bar-detl   (T14 Rollback)
Layer: database
Steps: 1. Inject a failure after the first BAR_DETL insert, once after BAR_IDTL, once after BAR_DATA.
Expected: after each: no carry rows at all (BAR_DATA, BAR_DETL, BAR_IDTL for the opening day all as before the run); a pre-existing 2026-04-10 sentinel voucher untouched.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; nothing is written, so there is nothing to roll back.

### balance-transfer.rollback.sales-order-after-header   (T14 Rollback)
Layer: database
Expected: failure after SL_ORD_DATA, after SL_ORD_DETL, after the tag-booking pass: nothing of the carry remains and the earlier carry is intact.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; nothing is written, so there is nothing to roll back.

### balance-transfer.rollback.approval-after-apr-detl   (T14 Rollback)
Layer: database
Expected: failure after APR_DETL, after APR_IDTL, after the book-'218' BAR_DETL: no part of the carry remains.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; nothing is written, so there is nothing to roll back.

### balance-transfer.rollback.closing-year-untouched   (T14 Rollback)
Layer: database
Steps: 1. Dump year N rows before and after every button (success and failure).
Expected: identical (the web does not write to the closed year; BtmSchm.cs:2765 {{DC_Main.ExeQuteDc("UPDATE AC_DATA SET DATA_TYPE = 'A' WHERE CO_CODE = '" + DC_Main.MCo_cod}} is a desktop weakness, weakness 4).
Status: executable (gap 16)

## T15 Config and history

### balance-transfer.config.opening-date-changes-tag-date   (T15 Config/history)
Layer: database
Steps: 1. Load the page (target 2026-27, `OP_DATE` 2026-04-01). 2. Change that year's `OP_DATE` to 2026-04-05 before the click. 3. Click `Tag Stock`.
Expected: VCH_DATE of carried rows is 2026-04-04 (the current `OP_DATE` minus one day), not 2026-03-31: no stale value from page load.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; this case only checks the desktop's copied rows/columns.

### balance-transfer.config.new-year-created-after-load   (T15 Config/history)
Layer: browser
Steps: 1. Open the page with no next year; message shown. 2. Create year 2026-27 in another tab. 3. Reload.
Expected: target 2026-27 offered, buttons enabled.
Status: executable (gap 14)

### balance-transfer.config.carry-after-closing-year-correction   (T15 Config/history)
Layer: database
Steps: 1. Carry. 2. Post a backdated year-N voucher. 3. Open Party Opening of N+1: still the old carry. 4. Re-run.
Expected: before re-run the carry is the old one (a carry is a snapshot, not a view); after: new.
Status: executable (gap 21)

## T16 Report and output (the operator-visible identity)

### balance-transfer.identity.ledger-opening-line-party   (T16 Report/output)
Layer: browser
Steps: 1. Seed of `ac.create.footprint`; run `Ac Balance`. 2. Year N+1: open Ledger Report for P1 from 2026-04-01.
Expected: the opening line is 3,499.25 Cr (= 5000.00 − 1200.50 − 300.25), counted once; the first N+1 transaction continues from it.
Status: executable (gaps 2, 21). How the line is produced (Party Opening writer legs as TR_AC_OPBL's AcOp_Ledr) is an implementation choice; the desktop Ac Balance button writes only `OP_DATA` (BtmSchm.cs:2801 {{INSERT INTO OP_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,}}).

### balance-transfer.identity.party-closing-equals-opening   (T16 Report/output)
Layer: database
Seed (all in year N, Cr-positive), expected opening per `AC_CODE` and `DATA_TYPE`:
P1/A: Cr 5000.00, Dr 1200.50, Dr 300.25 → **3499.25 C**.
P2/A: Cr 700.00 → **700.00 C**; P2/B: Dr 200.00 → **200.00 D**.
P3/A: gold Cr 10.500 and Dr 2.250, silver Dr 100.000, money net 0.00 → **0.00 D, gold 8.250 C, silver 100.000 D**.
P6/A: Cr 10.00 + Cr 0.005 → **10.01 C**. P7/A: Dr 20.00 + Dr 0.005 → **20.01 D**.
Expected: for every (account, DATA_TYPE) in the seed, `OP_DATA(N+1)` equals the closing computed from year N by the desktop formula; sum of all carried Cr − Dr = 3499.25 + 700.00 − 200.00 + 0.00 + 10.01 − 20.01 = 3989.25 Cr; no extra rows; party count 5 accounts, 6 rows.
Status: executable (gap 21)

### balance-transfer.identity.trial-balance-opening-column   (T16 Report/output)
Layer: browser
Steps: 1. After `Ac Balance`, open the Trial Balance for N+1 from 2026-04-01.
Expected: the opening column of the five party accounts = the figures above (net 3989.25 Cr, gold 8.250 Cr net of silver per account); the opening column total equals the N closing column total for the parties.
Status: executable (gap 21)

### balance-transfer.identity.gold-fine-closing-equals-opening   (T16 Report/output)
Layer: database
Seed: P3 and a second metal party P8: gold Cr 4.321, silver Cr 12.000.
Expected: Σ gold fine over carried rows = 8.250 + 4.321 = 12.571 Cr; Σ silver = −100.000 + 12.000 = −88.000 (88.000 net Dr).
Status: executable (gap 4)

### balance-transfer.identity.item-closing-equals-opening   (T16 Report/output)
Layer: database
Seed: I1 (6 pcs / 60.300 / 58.950 / 300.00); I6 untagged: IN 20 pcs gross 200.000 net 190.000, OUT 5 pcs gross 50.000 net 47.500, ITEM_RATE 12.50.
Expected: I6: 15 pcs, gross 150.000, net 142.500, amount 15 × 12.50 = 187.50. Item Stock report year N closing = ITM_OPBL(N+1) per item: I1 6 / 58.950, I6 15 / 142.500; totals 21 pcs, 201.450 net, 487.50.
Status: executable (gap 21)

### balance-transfer.identity.tag-closing-equals-opening   (T16 Report/output)
Layer: database
Seed: the tags of `tag.create.footprint`.
Expected: per tag: carried BAR_DETL count 3, Σ gross 5.000 + 7.000 + (T003's gross), Σ fine 4.397 + 5.954 + T003 fine; every tag number carried exactly once; the Tag Stock report of N closing lists the same 3 tags with the same weights.
Status: executable (Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing); passes at the database layer: next year's open set equals the closing year's and two presses change nothing (balanceTransferSelect.db.test.ts).

### balance-transfer.identity.order-open-equals-carried   (T16 Report/output)
Layer: database
Seed: O1 open (ordered 10,000.00, adjusted 4,000.00, advance 500.00), O2 fully adjusted (8,000.00 / 8,000.00), O3 dated 2026-04-02, O4 gold-only (5.000 ordered, 2.000 adjusted).
Expected: pending-order list of N at the closing date = {O1 balance 6,000.00, O4 gold 3.000}; the carried set = {O1, O4}; their adjusted-so-far = 4,000.00 and gold 2.000.
Status: executable (Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing); passes at the database layer: next year's open set equals the closing year's and two presses change nothing (balanceTransferSelect.db.test.ts).

### balance-transfer.identity.approval-open-equals-carried   (T16 Report/output)
Layer: database
Seed: three approval-issue lines A1, A2, A3 out; A2 returned by an APR RTN line in N; A3 sold.
Expected: only A1 is open; carried set = {A1}; the Approval pending list at N+1 start = {A1}.
Status: executable (Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing); passes at the database layer: next year's open set equals the closing year's and two presses change nothing (balanceTransferSelect.db.test.ts).

## T03 continued: Tag, Order, Approval column mapping (D6)

### balance-transfer.tag.rule.carried-when-positive   (T03 Formula sequence)
Layer: database
Seed: T001 IN ('+') VCH_SRNO 1 only (balance +1 → carried); T002 IN then OUT (VCH_SRNO 1 − 1 = 0 → not carried); T003 IN dated 2026-04-02 (excluded by date); T004 'N' (untagged, excluded by `TAG_NO <> 'N'`).
Expected: carried = {T001}. BtmSchm.cs:2358 {{HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0}}; BtmSchm.cs:2362 {{A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt}}; BtmSchm.cs:2327 {{AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND TAG_NO <> 'N' GROUP BY B.IT_TYPE,A.IT_CODE}}.
Status: executable (gap 10). A tag with VCH_SRNO 2 IN and 2 OUT cancels; a tag with VCH_SRNO 2 IN and 1 OUT (serial counter +1) is carried: a case for the serial-counter quirk (weakness 6) is in `tag.rule.serial-counter-quirk`.

### balance-transfer.tag.rule.serial-counter-quirk   (T03 Formula sequence)
Layer: database
Seed: tag T020: IN with VCH_SRNO 3, OUT with VCH_SRNO 3.
Expected by the desktop code: 3 − 3 = 0 not carried; but IN VCH_SRNO 3, OUT VCH_SRNO 1 gives +2 and the tag is carried although it was sold.
Status: blocked: Q6 (port the serial counter or carry on the real in-stock state).

### balance-transfer.tag.columns.mapping   (T02 Field route)
Layer: unit
Seed: one `BAR_DETL` source row with every column of the list filled with a distinct value (IT_CODE, TAG_NO, DESIGN_NO, TBL_CODE, ITM_SIZE, ITM_PCS 1, BAG_WT, ITM_GWT 5.000, ITM_OTH_WT, ITM_NWT 4.800, ITM_GHT_PRC, ITM_GHT_WT, ITM_TOUCH 91.600, ITM_WEST_PRC, ITM_FINE 4.397, LBR_PRC, LBR_RATE, LBR_TYPE, LBR_AMT, OTH_AMT, ITM_RATE, ITM_AMT, TAG_COST, ITM_MARGIN, ITM_MRP, ITM_REMARK, SF_NO, KR_*, TAG_SRNO, VCH_SRNO, RATE_TYPE, IT_TYPE, TAG_TYPE, PR_CODE, ORD_NO, ORD_SRNO, ORD_YRCD, ORD_DBCD, ORD_AC, OLD_VCH_NO, NEW_VCH_NO, HM_ID..HM_ID4_WT, DATA_TYPE, APP_TRFR, ITM_COLOR, MAIN_MARGIN_PRC, MAIN_MRP, JDT_*, KR_WAX_WT, EMP_ISU, LBR_CODE, DESIGN_IMG_ID, SL_TYPE, KR_OTH_RATE, KR_OTH_FINE, KR_TOT_FINE, KR_GWT_TOUCH, ITM_STYLE, ORD_LC_CODE, MFG_*).
Expected: output equals the source in every column except these changes: CO_YEAR = target year; CO_BOOK '000'; VCH_NO = counter; SR_NO and OLD_SRNO = running number; VCH_DATE = `OP_DATE` − 1 day (BtmSchm.cs:2378 {{mTrfr_dt.AddDays(-1.0)}}); INOUT_TYPE 'I' and ENTRY_TYPE 'O' (BtmSchm.cs:2378 {{(object)"','I','O','"}}); APR_ISU 'N' (BtmSchm.cs:2475 {{["PR_CODE"]), (object)"','N','"), dataView2[0]["ORD_NO"]}}); ITM_PCS, LBR_AMT, OTH_AMT, ITM_RATE, ITM_AMT, TAG_COST, ITM_MARGIN, ITM_MRP and the KR_* amounts pass through `Fnv` (NULL → 0). VCH_TYPE and BOOK_NAME are copied from the source row; `STK_DATE` copied twice (stock date and time slot as the desktop does).
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; this case only checks the desktop's copied rows/columns.

### balance-transfer.tag.columns.null-to-zero   (T03 Formula sequence)
Layer: unit
Seed: source tag with NULL `ITM_MARGIN`, `KR_OTH_AMT`, `TAG_COST`.
Expected: carried 0 in each (the `Fnv` pass: BtmSchm.cs:2381 {{double num2 = DC_Main.Fnv(ref Value);}}).
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; this case only checks the desktop's copied rows/columns.

### balance-transfer.tag.rule.multi-location-merge   (T03 Formula sequence)
Layer: database
Expected: N/A for Lite: the `MsCoStockMerge = "Y"` join (BtmSchm.cs:2354-2356 {{Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0}}) is a company setting this edition does not set; no case.
Status: N/A: company setting outside Lite.

### balance-transfer.order.rule.open-selection   (T03 Formula sequence)
Layer: database or unit
Seed (SL_ORD_ADJ per order: a '+' row for the ordered figure and '-' rows for adjustments): O1: '+' amount 10,000.00, '-' 4,000.00; O2: '+' 8,000.00, '-' 8,000.00; O3 (dated 2026-04-02): '+' 5,000.00; O4: '+' gold 5.000, '-' gold 2.000; O5: '+' silver 1.000, '-' silver 1.000; O6 header with no SL_ORD_ADJ row.
Expected: HAVING value (amount + gold + silver, '+' added, others subtracted): O1 = 6,000.00 > 0 carried; O2 = 0 not carried; O3 not carried (date); O4 = 3.000 carried; O5 = 0 not carried; O6: the LEFT JOIN row has NULL sign, so the `CASE ... ELSE - B.ORD_AMT` is NULL, the sum NULL, `NULL > 0` false: not carried. BtmSchm.cs:3024 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END) + SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_GOLD ELSE - B.ORD_GOLD END)}}; BtmSchm.cs:3024 {{A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt}}. Selection is by SQL over the seed, so the case does not depend on Q1.
Status: executable (gap 11). Whether a saved order can lack a '+' row (O6) is not read; the case is run by direct seed.

### balance-transfer.order.columns.header-mapping   (T02 Field route)
Layer: unit
Seed: open order O1: ADV_AMT 500.00; SL_ORD_ADJ '-' amount 4,000.00 and 1,000.00 (two adjustments) gold 0.500; silver 0.
Expected: header row keeps original CO_YEAR, CO_BOOK, VCH_NO and AC_CODE; ADV_AMT 500.00 unchanged; ORD_ADJ_AMT = 4,000.00 + 1,000.00 = 5,000.00; ADJ_GOLD 0.500; ADJ_SILVER 0.000. BtmSchm.cs:3024 {{SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_AMT ELSE 0 END) AS AdjAmount}}.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; this case only checks the desktop's copied rows/columns.

### balance-transfer.order.columns.detail-mapping   (T02 Field route)
Layer: unit
Seed: a SL_ORD_DETL line with all list columns filled.
Expected: copied: CO_YEAR, CO_BOOK, VCH_NO, SR_NO (also into OLD_SRNO), VCH_DATE (twice, date and time slot), VCH_TYPE = the book's `BOOK_SNAME`, INOUT_TYPE = the book's `BOOK_INOUT`, ENTRY_TYPE 'O', BOOK_NAME = `MAIN_BOOK`, AC_CODE, IT_CODE, TAG_NO, DESIGN_NO, ITM_SIZE, ITM_PCS (`Fnv`), ITM_GWT, ITM_NWT, ITM_GHT_WT, LBR_PRC, LBR_RATE, LBR_AMT, OTH_AMT, ITM_RATE, ITM_AMT, TOT_AMT, TAX_PRC, NET_AMT, ITM_REMARK, PR_CODE, DESIGN_ISU, TAG_GEN, TAG_SALE, ITM_GHT_PRC, HM_ID..HM_ID4_WT, OLD_TBL_CODE, ITM_COLOR, ORD_DEL_DATE, ORD_REC_AMT, EMP_CODE, TAG_STK_LESS, RATE_FIX, DESIGN_IMG_ID. Constants: LOT_NO, TBL_CODE blank, ITM_TOUCH 0, ITM_WEST_PRC 0, ITM_FINE 0, KR_NET_WT 0, KR_TOUCH 0, KR_WEST_PRC 0, KR_FINE 0, KR_NAME '' , RATE_TYPE '', IT_TYPE '', HD_VCH_NO = the order's VCH_NO, DATA_TRFR 'N', OLD_VCH_NO '' and NEW_VCH_NO ''. BtmSchm.cs:3137 {{INSERT INTO SL_ORD_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,}}; BtmSchm.cs:3139 {{double num20 = DC_Main.Fnv(ref Value);}}.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; this case only checks the desktop's copied rows/columns.

### balance-transfer.order.rule.tag-booking-pass   (T03 Formula sequence)
Layer: database or unit
Seed: closed order O2 (fully adjusted) with a detail line `TAG_SALE = 'N'` and an open order O1 whose line is `TAG_SALE = 'N'` and already carried by the first pass.
Expected by the code: the second pass selects every line with `TAG_SALE = 'N'` regardless of openness (BtmSchm.cs:3226 {{AND TAG_SALE = 'N' ORDER BY A.SR_NO}}) and inserts it unless the next year already has that voucher number (BtmSchm.cs:3241 {{SELECT VCH_NO FROM SL_ORD_DETL WHERE CO_CODE}}): O2's line is carried (although O2's header is not), O1's line is not duplicated.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; no order line is copied, so the Order Tag Booking pass (Q7) writes nothing in the web.

### balance-transfer.approval.rule.open-selection   (T03 Formula sequence)
Layer: database or unit
Seed: A1 (APR ISU, out); A2 (APR ISU, then returned by an APR RTN line); A3 (APR ISU, then sold by a SALES line).
Expected: ISU_REC is computed, not written to year N: A1 'N', A2 'Y', A3 'Y'; selection: only A1 (BtmSchm.cs:4142 {{B.MAIN_BOOK = 'APR ISU' AND ISU_REC = 'N'}}; closing-year rule BtmSchm.cs:4123 {{UPDATE APR_DETL SET ISU_REC = 'N'}}, BtmSchm.cs:4124 {{Update APR_DETL SET ISU_REC = 'Y'}}). Year-N rows unchanged after the run (gap 16).
Status: executable (gap 12, gap 16)

### balance-transfer.approval.columns.apr-detl-mapping   (T02 Field route)
Layer: unit
Seed: one open APR_DETL line with every listed column filled.
Expected: copied unchanged (including original CO_YEAR, CO_BOOK, VCH_NO, SR_NO, OLD_SRNO, VCH_DATE, AC_CODE, VCH_TIME, VCH_TYPE, INOUT_TYPE, ENTRY_TYPE, BOOK_NAME, IT_CODE, TAG_NO, ITM_PCS (`Fnv`), weights, touch, fine, rates, amounts, KR_*, VCH_SRNO, RATE_TYPE, IT_TYPE, PR_CODE, HD_VCH_NO, MAIN_USER, ISU_REC, ISU_NO, ISU_YRCD, ISU_DBCD, ISU_SRNO, ISU_AC_CODE, ISU_AC_NAME, MTL_COLOR, ADJ_GWT, ADJ_NWT, HM_*, ITM_COLOR, EMP_CODE, ITM_LESS_TCH, ITM_LOSS_WT, EMP_SALE, DESIGN_IMG_ID); `LOT_NO`-type blanks and the `NULL` before EMP_CODE come from the list. BtmSchm.cs:4154 {{INSERT INTO APR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,AC_CODE,VCH_TIME,}}.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; this case only checks the desktop's copied rows/columns.

### balance-transfer.approval.columns.tag-line-book-218   (T02 Field route)
Layer: unit
Seed: the open line A1 whose tag T030 has a BAR_DETL row.
Expected: a next-year BAR_DETL row for T030 with CO_BOOK '218', VCH_NO '00001', SR_NO and OLD_SRNO = the running number, VCH_DATE = `OP_DATE` − 1 day, VCH_TYPE `APRTG`, BOOK_NAME `APR TAG`, all numbers copied from the current BAR_DETL row of that tag; one BAR_IDTL row set the same way. BtmSchm.cs:4388 {{'218','00001'}}; BtmSchm.cs:4551 {{'218','00001'}}.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; this case only checks the desktop's copied rows/columns.

### balance-transfer.approval.rule.tag-in-both-carries   (T03 Formula sequence)
Layer: database
Seed: tag T030 issued on approval before the closing date, still out; its MAIN_STOCK rows as the web writes them for an `APR ISU`.
Expected: either T030 is carried by Tag Stock only, by Approval only, or by both. The two carries write BAR_DETL rows in different books ('000' vs '218'), so the web's total on-hand tag count after both carries could double count it.
Status: N/A: Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing; neither button writes BAR_DETL, so no tag can be counted in both (Q5 settled).

## T17 Keyboard and usability

### balance-transfer.keyboard.esc-closes   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Open the page. 2. Press Esc with focus on a button, then on the page background.
Expected: the page closes both times (BtmSchm.cs:2692-2695 {{if ((int)e.KeyCode == 27)}}, BtmSchm.cs:2662 {{((Form)this).Close();}}). While a run is in progress Esc does not abort it.
Status: executable (gap 19)

### balance-transfer.keyboard.tab-order-and-enter   (T17 Keyboard/usability)
Layer: browser
Steps: 1. From the first button, Tab through the page. 2. Press Enter or Space on `Item Stock`.
Expected: Tab visits Ac Balance, Item Stock, Tag Stock, Sales Order, Approval, then Exit, Cancel; Enter opens the confirmation `Are You Sure To Data Transfer to Next Year ?` (BtmSchm.cs:2926 {{Are You Sure To Data Transfer to Next Year ?}}), focus on the default answer.
Status: executable (gap 13)

### balance-transfer.keyboard.confirmation-text-verbatim   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Click each of the five buttons; read the dialog.
Expected: `Are You Sure To Data Transfer to Next Year ?` exactly (BtmSchm.cs:2729 {{Are You Sure To Data Transfer to Next Year ?}}); after `Yes` and success: `Process Are Complete....` (BtmSchm.cs:2755 {{Process Are Complete....}}). The web's own long text (page.tsx:121-123) is gone.
Status: executable (gap 13)

### balance-transfer.keyboard.upper-case-not-applicable   (T17 Keyboard/usability)
Layer: browser
Expected: the desktop upper-cases typed text (BtmSchm.cs:2683 {{if (num == 0 || num == 39)}}); the web target year is not typed, so nothing to upper-case.
Status: N/A: no typed field (decision on `target-year-not-free-text`).

## T18 Full journey

### balance-transfer.journey.party-carry-then-year-n1-business   (T18 Full journey)
Layer: browser
Steps: 1. Seed `ac.create.footprint` and run `Ac Balance`. 2. In N+1 post a receipt of 3,000.00 from P1 and a sale of 1,000.00 to P1. 3. Open P1's ledger for N+1 and the outstanding list.
Expected: running balance 3,499.25 Cr → 3,499.25 − 3,000.00 (Dr) = 499.25 Cr → 499.25 − 1,000.00 = 500.75 Dr (the sale is Dr). Outstanding list shows 500.75 Dr; the opening counted once.
Status: executable (gap 21)

### balance-transfer.journey.tag-carry-then-sale   (T18 Full journey)
Layer: browser
Steps: 1. Run `Tag Stock`. 2. In N+1 sell T001 at the counter.
Expected: the tag is found at the carried weights, sale accepted, T001 gone from the Tag Stock report of N+1, T002 still there, count 3 → 2.
Status: executable (Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing); browser case not built yet (needs a session-year switch).

### balance-transfer.journey.item-carry-then-issue   (T18 Full journey)
Layer: browser
Steps: 1. Run `Item Stock`. 2. In N+1 issue 2 pcs of I1 (gross 20.000, net 19.600).
Expected: I1 balance 6 − 2 = 4 pcs, net 58.950 − 19.600 = 39.350.
Status: executable (Q9 decided 2026-11-22 by the architect, owner may override): no web stock reader adds ITM_OPBL (stock is MAIN_STOCK of every year, `stock.ts` onHandNet), so the carry writes ITM_OPBL as the desktop does and changes no balance (database test passes); browser journey not built yet.

### balance-transfer.journey.order-carry-then-adjust   (T18 Full journey)
Layer: browser
Steps: 1. Run `Sales Order`. 2. In N+1 adjust O1 by a sale of 6,000.00.
Expected: O1 balance 6,000.00 → 0.00 and drops from the pending list; its adjusted-so-far 4,000.00 + 6,000.00 = 10,000.00.
Status: executable (Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing); browser case not built yet (needs a session-year switch).

### balance-transfer.journey.approval-carry-then-return   (T18 Full journey)
Layer: browser
Steps: 1. Run `Approval`. 2. In N+1 return A1 by an APR RTN voucher.
Expected: A1 closes; the book-'218' tag line leaves stock position (tag back in the Tag Stock count once).
Status: executable (Q1/Q8 decided 2026-11-22 by the architect, owner may override: the web is one database whose tag stock, open orders and open approvals already read every year (`stockSql.ts` barTagAvailableSql; the order and approval open queries), so these carries are implicit and the buttons write nothing); browser case not built yet (needs a session-year switch).

## Not-applicable kinds

### balance-transfer.lookup.none   (T04 Lookup)
Layer: n/a
Expected: no lookup, search or dependent selector on the desktop page (study §Screen).
Status: N/A: the form has no lookup control.

### balance-transfer.print.none   (T16 Report/output)
Layer: n/a
Expected: the form has no print: BtmSchm.cs:2699-2701 {{private void BtnPrint_Click(object sender, EventArgs e)}} is empty and the form index lists 0 report templates (D9).
Status: N/A: no print on the desktop; a web print would be an invention.

### balance-transfer.master.ac-mast-copy   (T07 Create)
Layer: n/a
Expected: the desktop copies missing `AC_MAST`, `PRODUCT_MAST`, `GROUP_MAST`, `TABLE_MAST`, `ITEM_MAST` rows into the next year (BtmSchm.cs:2840 {{if (dataView.Count == 0)}}).
Status: N/A: the web keeps one database across years (D7); the masters exist already (gap 8).

## Coverage table

| Kind | Cases | Blocked | Note |
|---|---|---|---|
| T01 Entry/defaults | 5 | 0 | |
| T02 Field route | 7 | 0 | includes the column-mapping unit cases |
| T03 Formula sequence | 32 (1 N/A) | 6 | blocked: having-offset (Q2), touch (AvgTouch), signed-sum skip (Q3), serial quirk (Q6), tag-booking pass (Q7), tag-in-both (Q5) |
| T04 Lookup | 1 | 0 | N/A: no lookup |
| T05 Children | 3 | 0 | |
| T06 Required/invalid | 4 | 0 | |
| T07 Create | 5 (1 N/A) | 0 | master copy N/A |
| T08 Reopen/no-op | 4 | 1 (part) | order and approval part of the rerun-identical case |
| T09 Edit | 9 | 2 | order and approval re-run: Q1 |
| T10 Delete/cancel/reverse | 3 | 1 | delete-user-vouchers: Q4; button absence N/A |
| T11 Scope/rights | 4 | 0 | |
| T12 Concurrency | 3 | 0 | |
| T13 Retry/unknown | 2 | 0 | |
| T14 Rollback | 6 | 2 | order and approval database layers: Q1 |
| T15 Config/history | 3 | 0 | |
| T16 Report/output | 9 (1 N/A) | 2 | identity for order and approval: Q1/Q5; print N/A |
| T17 Keyboard/usability | 4 (1 N/A) | 0 | |
| T18 Full journey | 5 | 2 | order and approval: Q1, Q5 |

Gap coverage (every gap has at least one case that fails today): 1 `ac.rule.party-only`; 2 `rerun.no-double-ledger-legs`; 3 `ac.rule.one-row-per-data-type`; 4 `ac.rule.gold-by-it-type`; 5 `ac.round.money-half-up-positive`; 6 `ac.rule.skip-no-tolerance`; 7 `delete.target-year-only`; 8 `master.ac-mast-copy` (N/A, Not covered); 9 `item.create.footprint`; 10 `tag.create.footprint`; 11 `order.rule.open-selection`; 12 `approval.rule.open-selection`; 13 `keyboard.confirmation-text-verbatim`; 14 `entry.default-target-year`; 15 `rollback.*`; 16 `rollback.closing-year-untouched`; 17 N/A (print); 18 `rights.create-right-required`; 19 `keyboard.esc-closes`; 20 `entry.non-lite-absent`; 21 `identity.*`.

## Test data

Smallest seed, described (no SQL):
- Tenant T1 with company C1, location L1, years 2025-26 (current, closing 2026-03-31), 2026-27 (opens 2026-04-01), 2027-28. A second tenant T2 and a second company or location (C2/L2) with a party balance for scope cases.
- Users: one with only `view`, one with only `update`, one with `create` on the menu.
- Parties: P1 (`AC_MAIN_GR` '1'), P2 ('2', with ledgers A and B), P3 (metal party), P5 (money and gold offsetting, for Q2), P6 and P7 (rounding), P8 (second metal party), X3 (`AC_MAIN_GR` '3'), X5 cash head ('5'), P4 (diamond only). Vouchers exactly as in each identity case; the late-dated (2026-04-01 and 2026-04-02) and the N+1 vouchers as in the date-bound cases.
- Items: I1 (rate 50.00, touch 91.600), I2 (sold out), I3 (offset, for Q3), I4 (type G, two tags with BAR_IDTL stone rows), I5 (one tag), I6 (rate 12.50). Tags T001 to T004, T010, T011, T020, T030.
- Orders O1 to O6 and approval lines A1 to A3 as listed, with their SL_ORD_ADJ rows and the APR RTN / SALES lines.
- A fine-weight column scale check (4 decimals needed for the half-case seeds).

## Not covered

- `AC_MAST`, `PRODUCT_MAST`, `GROUP_MAST`, `TABLE_MAST`, `ITEM_MAST` copy for the next year: N/A, one database (gap 8, D7). BtmSchm.cs:2840 {{if (dataView.Count == 0)}}.
- `LAST_VISIT` and `VISIT_TRAN` updates on `AC_MAST`: BtmSchm.cs:2748 {{UPDATE AC_MAST SET LAST_VISIT = '}}. Not a balance; owner decision whether any visit data is needed in the web.
- Closing-year side effects as writes (`AC_MAIN_GR`, `AC_DATA.DATA_TYPE`, `ITEM_MAST.AVG_*`, `APR_DETL.ISU_REC`, `BAR_DETL.APR_ISU`): not ported by design; the approval selection is covered as a computation (gap 16). BtmSchm.cs:4126 {{UPDATE BAR_DETL SET APR_ISU = 'N'}}, BtmSchm.cs:2931 {{DC_Main.AvgTouch(DC_Main.MsSysDate, DC_Main.MLc_code);}}.
- The `Rtl_Scheme`, `Rtl_Dhrn`, `Rtl_Loan` ranges (BtmSchm.cs:3349 {{private void Rtl_Scheme()}}, range :3349-4115) and the 14 non-Lite buttons: out of scope (D1).
- The "A and B Data Merge" prompt: BtmSchm.cs:2770 {{A And B Data Merge Transfer...}}; editions A/E only.
- The `MsCoStockMerge = "Y"` Tag Stock variant: not Lite.
- Theme and font scaling of the form: cosmetic.
- Preview endpoints of the web page (`/balance-transfer/preview`): a web addition with no desktop authority; the cases do not cover them beyond "writes nothing" being implicit in T14.
- "Year locked", "target already has vouchers" refusals: the desktop has none (study Rules 5); the web adds only the refusals in T06.

## Questions for the supervisor (the blocked cases wait on these)

- Q1: Sales Order and Approval carry rows with their **original `CO_YEAR`**; in the web's one database the carried row would equal its source. How is the carry stored and recognised (marker column, new year's CO_YEAR, a separate set)? Blocks the order and approval database, browser and re-run cases.
- Q2: the `HAVING` adds money, gold, silver and diamond into one signed number, dropping a party with offsetting balances. Port the drop, or carry the balances?
- Q3: item skip test sums signed pcs, gross and net. Port or carry?
- Q4: does a user-keyed N+1 opening for a party that has no year-N balance survive a carry?
- Q5: does an approved-out tag appear in both Tag Stock and Approval carries (depends on `MAIN_STOCK` rows for `APR ISU`, defined outside BtmSchm.cs)?
- Q6: port `SUM(±VCH_SRNO)` for the tag-in-stock test, or use the real in-stock state?
- Q7: is the order tag-booking pass meant to carry detail lines of closed orders?
