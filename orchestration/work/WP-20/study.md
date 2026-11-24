# WP-20 study — Ledger Report residuals: the OP_LDR opening-ledger union and the fine (metal) prints

Status of the task: the browser module `accountLedger.mjs` has no blocked, pending or skipped case that names these items. Its only
non-running cases are nine `notApplicable(...)` groups (read-only report, see Web today). The residuals therefore come from the
lineage note N223/G235 (`docs/master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md`, lines 3071-3074), which states
that the OP_LDR union and the gold/silver fine prints are "not reproduced". Everything below is the desktop truth for those two items,
and what the web does today.

## Scope

- Menu caption "Ledger Report", desktop form `RP_LEDR` (11,814 lines of C#; the form index says 11,815).
- Dispatch: `MDI_FORM.cs:8871 {{case "Ledger Report":}}` then `MDI_FORM.cs:8873 {{RP_LEDR rP_LEDR = new RP_LEDR();}}`. No constructor
  argument, so there are no modes. Edition and settings change the form from inside (`MsSoftType`, `MsWorkType`, `MsMfgType`).
- Lite edition (`MsSoftType` "L", or "B"): the Time Wise button is hidden, `RP_LEDR.cs:4587 {{if ((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0))}}`
  followed by `RP_LEDR.cs:4589 {{((Control)BtnTimeWise).Visible = false;}}`. The "OD" button (bill-wise outstanding days) is shown only for
  "A" and "E": `RP_LEDR.cs:4585 {{((Control)brnOsDay).Visible = true;}}`. So in Lite the only path into `TimeLedr_Dr` (the only
  code that reads OP_LDR in this form) is by Enter in a selector while the ageing panel is already open (`RP_LEDR.cs:8194 {{if (((Control)PnlMonth).Visible)}}`
  then `RP_LEDR.cs:8197 {{TimeLedr_Dr();}}`) or the half-month tick (`RP_LEDR.cs:10374 {{TimeLedr_Dr();}}`). The panel opens only from the
  hidden button (`RP_LEDR.cs:9558 {{((Control)PnlMonth).Visible = true;}}`). **Inferred:** a Lite or Basic operator cannot reach the
  OP_LDR ageing union in the desktop. The web still exposes ageing to everyone (see Gaps 10). The owner should decide whether Lite parity means hiding it.
- The fine prints (Gold, Silver, In Out/Ac Sale, JmaUdr, Ac Purc buttons) are shown only inside the drill-down; their visibility is
  switched off on Esc (`RP_LEDR.cs:6024 {{((Control)BtnGold).Visible = false;}}`). Their Lite status is not gated by `MsSoftType`.
- In scope: (1) OP_LDR union inside `TimeLedr_Dr` (`RP_LEDR.cs:9563 {{private void TimeLedr_Dr()}}`), the only place the form reads OP_LDR; (2) the prints that stage
  `FINE_DATA` and `LEDR_AC_DATA` and call Crystal (`BtnGold_Click` 8227-8436, `Gold_Summ` 8437-8658, `Silver_Summ` 8659-8870, `BtnSilver_Click`
  8871-9067, `BtnJmaUdhar_Click` 9068-9276, `BtnDelete_Click` 3984-4087 (caption "&JmaUdr"), `BtnPrint_Click` 6097-6380).
- Out of scope: the DGV_AC/DGV_DETL/DGV_VCH grids (done in N223), Excel `BtnSave_Click` (done), Ac Purc (`BtnPurcRpt_Click`), the OD form `RP_INOUT`,
  Crystal layout content, the Rojmel OP_LDR remarks. Where OP_LDR is written (Year Create, Company, Import) is listed under Lifecycle for context only.

## Screen

Controls that matter to these items (caption, name, source):
- `RP_LEDR.cs:2425 {{BtnDelete.Text = "&JmaUdr";}}` — the money Jama/Udhar print (report `JmUdAmt`).
- `RP_LEDR.cs:2439 {{BtnGold.Text = "&Gold";}}`, `RP_LEDR.cs:2453 {{BtnSilver.Text = "&Silver";}}`, `RP_LEDR.cs:2467 {{BtnJmaUdhar.Text = "&In Out";}}`
  (renamed "Ac Sale" when `MsWorkType` is "W": `RP_LEDR.cs:4593 {{BtnJmaUdhar.Text = "Ac Sale";}}`), `RP_LEDR.cs:2923 {{BtnTimeWise.Text = "Time Wise";}}`.
- `RP_LEDR.cs:2892 {{Label5.Text = "FineType";}}` with `cboFineType` items `RP_LEDR.cs:4559 {{cboFineType.Items.Add((object)"Gold");}}` and
  `RP_LEDR.cs:4560 {{cboFineType.Items.Add((object)"Silver");}}`; index 0 is Gold, 1 is Silver (selected on load, see Calculations).
- `chkHalfMonth` " Half Month Show" (`RP_LEDR.cs:2863 {{((ButtonBase)chkHalfMonth).Text = " Half Month Show";}}`): when unticked, the 16-30, 46-60, 91-120 style
  half columns (3, 4, 5, 12, 13, 14) are hidden: `RP_LEDR.cs:9693 {{((DataGridView)DGV_MONTH).Columns[3].Visible = false;}}`.
- `PnlMonth` holds `DGV_MONTH` (ageing grid, 23 columns, 21 = AC_CODE and 22 = AC_ADD1 hidden: `RP_LEDR.cs:9689 {{((DataGridView)DGV_MONTH).Columns[22].Visible = false;}}`).
- Selectors that feed the union: `tLcCode`, `cboCity`, `tAcGrCode`, `cboAcType`, `mToDt`, and the data type (`MsDataType`). Dates default
  `RP_LEDR.cs:4597 {{mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);}}` and today for `mToDt`.
- Tab order and exact positions: not needed for this scope; not read. MISSING: none required.

## Keyboard

- F1 (key 112) focuses the search box: `RP_LEDR.cs:6008 {{if ((int)e.KeyCode == 112)}}` then `RP_LEDR.cs:6010 {{((Control)tSearch).Focus();}}`.
- Esc (27) steps back one level: from the detail ("&Back1") to the summary, `RP_LEDR.cs:6014 {{if (Operators.CompareString(BtnExit.Text, "&Back1", false) == 0)}}`,
  and it hides Gold again: `RP_LEDR.cs:6024 {{((Control)BtnGold).Visible = false;}}` (Silver, In Out, Ac Purc and JmaUdr follow in the next lines).
- Enter on city, ac type, ac group, etc. re-runs the ageing when the panel is open, else the summary: `RP_LEDR.cs:11615 {{TimeLedr_Dr();}}`
  (in `cboAcType_KeyDown`) and `RP_LEDR.cs:8197 {{TimeLedr_Dr();}}` (in `cboCity_KeyDown`).
- Typing is forced upper case and the apostrophe is swallowed: `RP_LEDR.cs:5990 {{if (num == 0 || num == 39)}}`.
- The Gold-Col tick re-fills the drill-down: `RP_LEDR.cs:11595 {{private void chkGoldCol_Click(object sender, EventArgs e)}}`.
- Alt hot keys come from the captions (&Gold = Alt+G, &Silver = Alt+S, &In Out = Alt+I, &JmaUdr = Alt+J, &Print = Alt+P).

## Rules

Every print button begins with the same right test, then the message (focus stays where it was; no control is focused in code):
- `RP_LEDR.cs:8236 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}` (Gold; the same text at 3989 JmaUdr, 6105 Print, 8880 Silver, 9073 In Out).
- Print of the summary needs a branch: `RP_LEDR.cs:6125 {{Interaction.MsgBox((object)"Please Select Lc Code and Try...", (MsgBoxStyle)0, (object)null);}}`
  when `tLcCode` is empty; `Silver_Summ` repeats it at 8667.
- Gold and Silver prints ask: `RP_LEDR.cs:8382 {{Hz Jama Udhar Gold Report}}` and `RP_LEDR.cs:9013 {{Hz Jama Udhar Silver Report}}` as a Yes/No box (style 4);
  Yes (answer 6) picks the "Hz" (horizontal) layout, No the plain one: `RP_LEDR.cs:8384 {{DC_Main.RptName = "JmUdFineHz";}}`, `RP_LEDR.cs:8388 {{DC_Main.RptName = "JmUdFine";}}`.
  The voucher-wise summary asks `RP_LEDR.cs:8625 {{Hz Jama Udhar Gold Voucher Wise Summ Report}}` and the silver summary `RP_LEDR.cs:8837 {{Silver Report Summery}}`.
- Summary print asks `RP_LEDR.cs:6226 {{Hz Repor With Gold and Silver....}}` (Yes = `AcWithWtSumm` or `AcWithWtGold`; No = plain `AcSummLdr`).
- Zoom from the voucher grid refuses an opening-ledger voucher: `RP_LEDR.cs:10665 {{This Is a Opening Ledger Voucher You Cant Zoom ....}}` (OP_LDR rows carry
  no voucher to open). The ageing panel has no message of its own; an empty result returns silently: `RP_LEDR.cs:9743 {{if (dataTable.Rows.Count == 0)}}`.
- Zoom needs view rights: `RP_LEDR.cs:10650 {{Interaction.MsgBox((object)"You Have No Rights...", (MsgBoxStyle)0, (object)null);}}`.

## Calculations

### A. The ageing (`TimeLedr_Dr`, `RP_LEDR.cs:9563 {{private void TimeLedr_Dr()}}`) with the OP_LDR union — step by step

1. Presence test, once per run: `RP_LEDR.cs:9705 {{DC_Main.RsQry = "SELECT * FROM OP_LDR WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";}}`
   and, if there is any row, `RP_LEDR.cs:9709 {{flag = true;}}`. The test uses the **session** location `MLc_code`, not the `tLcCode` box (N223 calls this a defect).
2. The account list (`dataTable`, line 9711) reads AC_DATA only and has **no OP_LDR arm and no book filter**:
   `RP_LEDR.cs:9711 {{Sum(A.CR_AMT-A.DR_AMT) as Amount}}`, to-date bound `RP_LEDR.cs:9711 {{" and VCH_DATE <= '"}}`. It is grouped per account.
3. Nine more queries are built (lines 9713-9737), each `AC_DATA arm UNION ALL OP_LDR arm`, GROUP BY AC_CODE, name, address, mobile:
   - `table` (9713): total **credit** to the to-date: `RP_LEDR.cs:9713 {{Sum(A.CR_AMT) as Amount,SUM(CASE WHEN A.IT_TYPE = 'G' THEN CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as GoldWt}}`.
   - `table2` (9716) 0-15 days: `RP_LEDR.cs:9716 {{Sum(A.DR_AMT) as Amount,SUM(CASE WHEN A.IT_TYPE = 'G' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as GoldWt}}`
     with `VCH_DATE >= ToDate-15` and **no upper bound** (`RP_LEDR.cs:9716 {{.AddDays(-15.0), "MM/dd/yyyy")}}`).
   - `table3`..`table8` (9719-9734): windows -16..-30, -31..-45, -46..-60, -61..-90, -91..-120, -121..-150 (quote `RP_LEDR.cs:9719 {{.AddDays(-16.0), "MM/dd/yyyy")}}`,
     `RP_LEDR.cs:9719 {{.AddDays(-30.0), "MM/dd/yyyy")}}`). `table9` (9737): `VCH_DATE <=` ToDate-151 (`RP_LEDR.cs:9737 {{.AddDays(-151.0), "MM/dd/yyyy")}}`).
4. The AC_DATA arm of each of the nine queries drops the opening book when OP_LDR is present: `RP_LEDR.cs:9713 {{Interaction.IIf(flag, (object)"AND A.CO_BOOK <> '000'", (object)"")}}`.
   The account-list query (step 2) does **not** carry this filter. So, when OP_LDR has rows, the net balance that selects the accounts still counts book 000, while the
   bucket totals do not; the OP_LDR rows replace book 000 inside the buckets only.
5. The OP_LDR arm (credit, line 9713): `RP_LEDR.cs:9713 {{SUM(A.CR_AMT) AS Amount,SUM(A.CR_GL_FINE) As GoldWt,SUM(A.CR_GL_FINE) As SilverWt FROM OP_LDR AS A}}`.
   Note that **silver reads the gold column CR_GL_FINE** (desktop weakness W3). Debit arms (lines 9716-9737):
   `RP_LEDR.cs:9716 {{Sum(A.DR_AMT) as Amount,SUM(A.DR_GL_FINE) as GoldWt,SUM(A.CR_GL_FINE) as SilverWt FROM OP_LDR AS A}}` — silver again reads the credit column, and
   the debit-side silver column `DR_SL_FINE` / `CR_SL_FINE` is never read by this form (the table has them: `web/packages/db/prisma/schema.prisma:4470-4471`).
6. The OP_LDR arm filters by CO_CODE, optional LC_CODE (`tLcCode`), CO_YEAR, `AC_CITY` and `AC_GR`, the same date window on `VCH_DATE`, and `DATA_TYPE` unless the type is "C". It has **no
   `AC_TYPE` condition** (the AC_DATA arm of the same query has `AND B.AC_TYPE =`, quoted `RP_LEDR.cs:9713 {{AND B.AC_TYPE = '}}`), so with an account type chosen the opening
   rows of other types leak into the sums. Only accounts already in `dataTable` are read later (row filter), so the leak shows only for accounts that pass the type filter by AC_DATA.
7. Who is listed: for the selected fine, `RP_LEDR.cs:9770 {{if (cboFineType.SelectedIndex == 0)}}`; the shown value is the negative of `Amount`, replaced by the negative fine if the fine is negative at
   three decimals: `RP_LEDR.cs:9777 {{if (Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["GoldWt"]), "0.000")) < 0.0)}}`;
   a row is added only when `RP_LEDR.cs:9793 {{if (num9 != 0.0)}}`. The debit column shows `Math.Abs(Amount)` formatted `"0"` (`RP_LEDR.cs:9815 {{obj.Value = Strings.Format(RuntimeHelpers.GetObjectValue(obj4), "0");}}` — see line number caveat in Open questions).
8. Oldest-first consumption per account: the 151+ bucket is first, `RP_LEDR.cs:9864 {{dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));}}`
   (sums the credit table), then each bucket subtracts: `RP_LEDR.cs:9886 {{if (num13 != 0.0)}}`; when the credit exceeds the bucket the remainder is shown as a **credit carry** in the
   column to its left (`RP_LEDR.cs:9892 {{((DataGridView)dGV_MONTH)[10, num7].Value = Strings.Format((object)Math.Abs(num13 - num10), "0.00");}}`); else the
   bucket reduces. The same runs for silver in column 19 with `"0.000"` and for gold, selected by `cboFineType`. Money rounds with `"0.00"`, fine with `"0.000"`
   (formats, not Math.Round). The Total columns add the buckets and the columns 11 and 20 are rolled into `num`/`DgvTot` footers.
9. Opening-ledger rows fall into a bucket only by their `VCH_DATE`. Every window in lines 9713-9737 filters on `VCH_DATE` (quote `RP_LEDR.cs:9713 {{ and VCH_DATE <= '}}`), so an OP_LDR row with a null date matches no window and is dropped, credit total included. **Inferred** from the SQL; whether real rows have null dates is open (Open questions 2).

### B. The fine prints (what is staged before Crystal opens)

- Opening and closing figures for the gold print use `Sum(CR_AMT - DR_AMT)` and signed `FINE_WT`, rounded `"0.00"`, `"0.000"`, `"0.00"`:
  `RP_LEDR.cs:8332 {{num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));}}`,
  `RP_LEDR.cs:8340 {{num5 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));}}`. Silver uses two decimals (`RP_LEDR.cs:8333 {{num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));}}`), a likely desktop typo (W6).
  These two reads come from AC_DATA only and never touch OP_LDR; opening books come through AC_DATA book 000 there.
- Fine per row (`FINE_DATA.ITM_FINE`) is the stored `ITM_FINE` where the amount is zero: `RP_LEDR.cs:8256 {{CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END}}`; money rows have `ITM_AMT <> 0` handled by other inserts.
- No new arithmetic is done in the form for the rows: they are `INSERT ... SELECT` copies (Lifecycle).

## Lifecycle and write set

This is a report. Its only writes are two staging tables, both truncated and refilled **per click, for the whole database** (no company condition):

| Statement | Table | Line and quote |
|---|---|---|
| clear | FINE_DATA | `RP_LEDR.cs:8255 {{DC_Main.ExeQuteDc("DELETE FROM FINE_DATA ");}}` (also 8441 Gold_Summ, 8664 Silver_Summ, and `RP_LEDR.cs:9150 {{DC_Main.ExeQuteDc("DELETE FROM FINE_DATA ");}}` for In Out) |
| clear | LEDR_AC_DATA | `RP_LEDR.cs:6128 {{DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA");}}` (also 11669 `BtnCancel_Click`) |
| fill | LEDR_AC_DATA | `RP_LEDR.cs:6135 {{INSERT INTO LEDR_AC_DATA (CO_CODE, LC_CODE,CO_YEAR, VCH_DT, AC_CODE, CR_AMT, DR_AMT, CR_FINE_WT, DR_FINE_WT, CR_SL_FINE, DR_SL_FINE, DATA_TYPE)}}` one row per summary grid row (14 columns per `ledgerStaging.ts:60`) |
| fill | FINE_DATA | 34 columns (`RP_LEDR.cs:8256 {{INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME}}`), one `INSERT ... SELECT` per source |

The Gold print (`BtnGold_Click`) fills FINE_DATA from these sources, each with a fixed `SR_NO` literal so the layout can group them (the SR_NO literal in the select list, e.g. 1 at line 8256, 25 and 26 at 8316-8318):
- stock rows `MAIN_STOCK` joined to `ITEM_MAST`, gold items, `A.SR_NO <> 7`, for books `RP_LEDR.cs:8256 {{BOOK_NAME IN ('TR_AC_OPBL','SALES ORDER','SALES','SALES RETURNE','WH SALES','RATE CUT','KARIGAR ISSUE','DHIRAN ISSUE','INTREST RECIVED','DHIRAN RECEIVED','PURC RETURN','TOUR SALES')}}` (opening stock book `TR_AC_OPBL` is part of this list);
- purchase `RP_LEDR.cs:8258 {{AND C.MAIN_BOOK = 'PURCHASE'}}` (line 8260 repeats it), karigar receipt `RP_LEDR.cs:8262 {{AND C.MAIN_BOOK = 'KARIGAR RECEIPT'}}`, ghat `RP_LEDR.cs:8292 {{AND C.MAIN_BOOK IN ('GHAT REC')}}`;
- money-and-metal legs from `AC_DATA` (lines 8266-8286, signs `'+'`/`'-'` literals at 8274 and 8276), `RATE_CUT_ISU` (`RP_LEDR.cs:8280 {{FROM RATE_CUT_ISU}}`), manufacturing books
  `RP_LEDR.cs:8288 {{BOOK_NAME IN ('MTL ISU','GHAT ISU','MFG GHAT REC','MFG FILE ISU','MFG FILE REC','MFG PREP ISU','MFG PREP REC','MFG NAKSHI ISU','MFG NAKSHI REC','MFG STNG ISU','MFG STNG REC','MFG MINO ISU','MFG MINO REC','MFG FILE2 ISU','MFG FILE2 REC','MFG POLISH ISU','MFG POLISH REC')}}`;
- jewellery manufacturing only (`MsMfgType` "J"): `RP_LEDR.cs:8290 {{if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)}}` adds FTNG/CHEDIYA/PARA/JDTR reads (8294-8298);
- locations: `RP_LEDR.cs:8312 {{MAIN_BOOK = 'OUTWORD'}}` and `RP_LEDR.cs:8314 {{MAIN_BOOK = 'INWORD'}}` via `LOCT_MAST`;
- labour `LBR_DATA` (8301, 8303) and the closing-balance reads above.
Column map for these inserts is already encoded in `web/apps/api/src/modules/reports/ledgerStaging.ts:22` (`FINE_DATA_COLUMNS`), which says the 34 columns follow `RP_LEDR.cs` order. The source rules (the selects) are **not** ported.

Voucher-wise summaries (`Gold_Summ` 8437-8658, `Silver_Summ` 8659-8870) read each voucher by key: `RP_LEDR.cs:8449 {{SELECT * FROM AC_DATA WHERE CO_CODE = '}}` and re-insert it with one of four row shapes by `MAIN_BOOK`. `Silver_Summ` uses `tLcCode.Text` for LC_CODE, while `Gold_Summ` uses `DC_Main.MLc_code`.

The OP_LDR table itself (write side, for context): replaced per year on Year Create: `MS_YEAR.cs:1464 {{DC_Main.ExeQuteDc("DELETE FROM OP_LDR WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");}}`;
deleted per company: `MS_COMPANY.cs:6365 {{DC_Main.ExeQuteDc("DELETE FROM OP_LDR WHERE  CO_CODE = '" + tCoCode.Text + "'");}}`, `MS_COMPANY.cs:7085 {{DC_Main.ExeQuteDc("DELETE FROM OP_LDR WHERE CO_CODE = '" + DC_Main.MCo_code + "'");}}`;
refilled by the import utility: `UT_IMPORT.cs:3495 {{DC_Main.ExeQuteDc("DELETE FROM OP_LDR WHERE CO_CODE = '" + DC_Main.MCo_code + "'");}}`. In this form it is **read only**.

## Print

| Button | Rights check | Template and parameters |
|---|---|---|
| Print, summary | `RP_LEDR.cs:6105 {{You Have No Print Rights.....}}` (message above) | `RP_LEDR.cs:6179 {{DC_Main.RptName = "AcSummLdr";}}` (staging LEDR_AC_DATA); with the gold+silver Yes: `RP_LEDR.cs:6256 {{DC_Main.RptName = "AcWithWtSumm";}}` or `RP_LEDR.cs:6260 {{DC_Main.RptName = "AcWithWtGold";}}` |
| Print, detail | same | `RP_LEDR.cs:6313 {{DC_Main.RptName = "AcLedger";}}` |
| JmaUdr | `RP_LEDR.cs:3989 {{You Have No Print Rights.....}}` | `RP_LEDR.cs:4050 {{DC_Main.RptName = "JmUdAmt";}}`; parameters `RP_LEDR.cs:4065 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num, "0.00")) ?? "";}}` |
| Gold | `RP_LEDR.cs:8236 {{You Have No Print Rights.....}}` | `JmUdFineHz` (Yes) / `JmUdFine` (No), `RP_LEDR.cs:8395 {{\\Report\\JmUdFineHz.RPT";}}`; summary: `RP_LEDR.cs:8627 {{\\Report\\JmUdFineHzSummVch.RPT";}}` / `RP_LEDR.cs:8631 {{\\Report\\JmUdFineHzSumm.RPT";}}` |
| Silver | `RP_LEDR.cs:8880 {{You Have No Print Rights.....}}` | `RP_LEDR.cs:9015 {{DC_Main.RptName = "JmUdFineSlHz";}}`, `RP_LEDR.cs:9019 {{DC_Main.RptName = "JmUdFineSl";}}`; summary `RP_LEDR.cs:8839 {{\\Report\\JmUdFineSlSum.RPT";}}` / `RP_LEDR.cs:8843 {{\\Report\\JmUdFineSlHz.RPT";}}` |
| In Out / Ac Sale | `RP_LEDR.cs:9073 {{You Have No Print Rights.....}}` | `RP_LEDR.cs:9116 {{DC_Main.RptName = "AcSaleWhRpt";}}` (selection on `MAIN_STOCK`, `RP_LEDR.cs:9092 {{AND {MAIN_STOCK.CO_BOOK} <> '018' AND {MAIN_STOCK.ITM_SIGN} = '-'}}`) or `RP_LEDR.cs:9235 {{DC_Main.RptName = "LedrInOut";}}` |

Gold parameters (always eight, the same names): `RptTitel`, `FromDate`, `ToDate`, `OpBal`, `ClBal`, `OpAmtBal`, `ClAmtBal`, `DataType`:
`RP_LEDR.cs:8411 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num2, "0.000")) ?? "";}}`, `RP_LEDR.cs:8414 {{Cr[(short)6] = ("ClAmtBal = " + Strings.Format((object)num4, "0.00")) ?? "";}}`.
Title text: `RP_LEDR.cs:8363 {{Ledr With Gold Fine Report As On }}` (`Branch - <lc> ` prefix when `MsLcBoxShow`). The Crystal selection formula is on `{FINE_DATA.*}`:
`RP_LEDR.cs:8344 {{CurFormula = "{FINE_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {FINE_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {FINE_DATA.AC_CODE} = '" + tAcCode.Text + "'}}`
with `VCH_DATE` from/to and optional `LC_CODE` and `DATA_TYPE` ("A" or "B" only; "C" means all). The print destination follows `MsCrystalRptType`: "N" opens `UT_REPORT` (the new viewer) with the formula in `DC_Main.RptFormula`.

## Rights

- Each print button reads `UserPrint`, loaded from `USER_SET`: `RP_LEDR.cs:4148 {{DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";}}`
  then `RP_LEDR.cs:4156 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}`. Message "You Have No Print Rights.....". When there is no USER_SET row,
  `UserPrint` stays at its default (not read here; see Open questions 3).
- Zoom uses another menu's view right: `RP_LEDR.cs:10650 {{You Have No Rights...}}`, message "You Have No Rights...".
- OD button: `RP_LEDR.cs:11632 {{DC_Main.MsUserRightForm = "Bill Os Day";}}`, message at 11638 "You Have No Rights.....".
- Opening-ledger refusal (not a right): `RP_LEDR.cs:10665 {{This Is a Opening Ledger Voucher You Cant Zoom ....}}`.

## Desktop weaknesses not to port

- W1 SQL built by joining strings, with the user's city/type/group text inside quotes: `RP_LEDR.cs:9713 {{AND B.AC_CITY = '" + cboCity.Text + "'"}}`. Use parameters.
- W2 Unscoped staging deletes (`RP_LEDR.cs:8255 {{DELETE FROM FINE_DATA }}`, `RP_LEDR.cs:6128 {{DELETE FROM LEDR_AC_DATA}}`): two operators printing at once overwrite each other, and every company's rows go. The web helper scopes by tenant and company (`ledgerStaging.ts:159`).
- W3 Silver read from the gold credit column in the OP_LDR arm (`RP_LEDR.cs:9713 {{UNION ALL SELECT A.AC_CODE}}` and `9716` quoted above): silver ageing for opening rows is wrong; never read `DR_SL_FINE`.
- W4 The OP_LDR presence test uses `MLc_code`, the AC_DATA arm uses `tLcCode` (`RP_LEDR.cs:9705 {{SELECT * FROM OP_LDR WHERE CO_CODE = '}}`, N223 already fixed the location scope in the web).
- W5 The youngest bucket has no upper bound (`RP_LEDR.cs:9716 {{SUM(A.DR_GL_FINE) as GoldWt}}`): future-dated rows land in 0-15 (fixed in the web).
- W6 Silver balance rounded to two decimals while gold uses three (`RP_LEDR.cs:8333 {{"SilverWt"]), "0.00"));}}`).
- W7 `AC_TYPE` is not applied to the OP_LDR arm (step 6).
- W8 The account list ignores the opening-book switch (step 4): book 000 counted for who is listed, not for the buckets.
- W9 Only the account in `tAcCode` is staged for the gold print but the delete is global (`RP_LEDR.cs:8344 {{CurFormula = "{FINE_DATA.CO_CODE} = '"}}` selection vs `8255`).

## Web today

- `web/apps/api/src/modules/reports/accountLedgerQueries.ts:423` `ageingDataset`: one SQL over `AC_DATA` only (`:447 {{FROM "AC_DATA" d}}`), buckets by age in days, signed per leg, FIFO via `accountLedgerShared.ts:236`. No OP_LDR read anywhere in the reports module.
- `web/apps/api/src/modules/reports/accountLedgerShared.ts:255` `acDataScope` excludes the carried-opening leg (`notCarriedOpening`, `web/apps/api/src/modules/shared/carriedOpening.ts:19`) and applies company, location and DATA_TYPE.
- `web/apps/api/src/modules/reports/ledgerStaging.ts:168` `stageFineDataTx` and `:218` `stageLedgerAcDataTx`: typed, company-scoped clear-then-fill helpers. **Nothing calls them** except `web/apps/api/test/ledgerStaging.db.test.ts`.
- `web/apps/api/src/modules/masters/configTables.ts:347` `setOpeningLedger`: replaces the tenant's `OP_LDR` rows for a year (reader for the web is only this module and the schema `web/packages/db/prisma/schema.prisma:4451`).
- `web/apps/api/src/routes/accountLedger.ts:161-236`: `GET /reports/account-ledger`, `export.csv`, `export.xlsx`, `export.pdf` and the two account-in-path aliases. No Gold, Silver, JmaUdr or In Out route.
- `web/apps/web/app/(app)/reports/account-ledger/page.tsx:23` views (summary, detail, voucher-summary, ageing), `:115` fine selector (Gold/Silver) for ageing only, `:144` Print/PDF/Excel/CSV; no Gold, Silver, In Out, JmaUdr buttons.
- `web/apps/web/test/features/modules/accountLedger.mjs:42` `notApplicable` helper and nine not-applicable groups: T07 create, T08 reopen, T09 edit, T10 delete, T12 concurrency, T13 retry, T14 rollback (all "RP_LEDR writes nothing") and T02 field-route
  (covered by T03/T04/T06). **There is no `blocked`, `pending` or `skip` call in the module** (searched `blocked`, `pending`, `skip`; none). The not-applicable T07-T14 groups become wrong the day the fine prints stage rows (Gap 8).
- `web/apps/api/test/accountLedgerReport.db.test.ts:183` ageing scenario F uses AC_DATA only (no OP_LDR rows seeded).
- Lineage rows: G235/N223 (`12-lineage-verification-2026-10-01.md:250` and `:3071-3074`) says the OP_LDR union and the staging prints "are not reproduced, because an unscoped staging write is unsafe in a multi-tenant web app", and `:3085` says "Desktop-runtime comparison and parent acceptance remain open". No other open G-row names RP_LEDR.

## Gaps

1. **OP_LDR ageing union missing (missing feature).** Desktop: debit and credit bucket queries are `AC_DATA UNION ALL OP_LDR` (`RP_LEDR.cs:9713 {{UNION ALL SELECT A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,SUM(A.CR_AMT) AS Amount}}`) with the AC_DATA arm skipping book 000 when OP_LDR exists (`RP_LEDR.cs:9713 {{AND A.CO_BOOK <> '000'}}`).
   Web: `accountLedgerQueries.ts:447` reads `AC_DATA` only; a tenant that loaded OP_LDR (via `configTables.ts:347`) sees none of it in ageing. Fix: add a parameterised OP_LDR arm in `ageingDataset` (same company, location, year, city, group, data-type, dates; money Cr/Dr, gold Cr/Dr_GL_FINE, silver Cr/Dr_SL_FINE), and skip the legs of book 000 that the desktop skips when the tenant has OP_LDR rows for the location.
2. **Silver of the opening rows (wrong result in the desktop; decide before porting).** Desktop reads `CR_GL_FINE` for silver (`RP_LEDR.cs:9716 {{SUM(A.CR_GL_FINE) as SilverWt FROM OP_LDR AS A}}`). Web will not have the quirk. Fix: use `*_SL_FINE` and record the difference as deliberate; needs the owner's yes (Open questions 1).
3. **Carried-opening interplay (wrong result risk).** Web excludes the carried opening leg (`accountLedgerShared.ts:270`), so ageing today ignores both book 000 carried openings and OP_LDR; a tenant with only carried openings sees an ageing without its opening debits. Desktop with no OP_LDR rows still counts book 000 (`RP_LEDR.cs:9711 {{Sum(A.CR_AMT-A.DR_AMT) as Amount}}`, no `CO_BOOK` filter). Fix: the case list must decide which of the three sources (hand-keyed 000 legs, carried legs, OP_LDR rows) ages, and test each alone and together.
4. **Account list vs buckets disagree (desktop defect).** Desktop lists accounts by an AC_DATA-only net (step 2) but buckets with OP_LDR instead of book 000. Fix: list accounts by the same combined set as the buckets; tests with one account that is debit only in OP_LDR and one that is debit only in book 000.
5. **Fine prints missing: Gold (missing feature).** Desktop `BtnGold_Click` stages FINE_DATA and prints `JmUdFine`/`JmUdFineHz` (`RP_LEDR.cs:8388 {{DC_Main.RptName = "JmUdFine";}}`). Web has the helper `ledgerStaging.ts:168` but no caller, no route and no button (`page.tsx:144` only has Print/PDF/Excel/CSV). Fix: a read-only resolver that builds the same rows in memory (no shared table write) for the selected account and dates, with opening and closing figures, rendered as PDF/Excel; keep the helper for Crystal-layout parity only if the owner needs it.
6. **Fine prints missing: Silver (missing feature).** Desktop `RP_LEDR.cs:9019 {{DC_Main.RptName = "JmUdFineSl";}}` and `JmUdFineSlHz`; same row sources as Gold with the silver item filter, and `Silver_Summ` using `tLcCode` for location (`RP_LEDR.cs:8667 {{Please Select Lc Code and Try...}}`). Web: nothing. Fix: as Gap 5; include the "Please Select Lc Code and Try..." refusal as a typed validation text.
7. **Voucher-wise Gold and Silver summaries missing.** Desktop `Gold_Summ` / `Silver_Summ` (`RP_LEDR.cs:8627 {{\\Report\\JmUdFineHzSummVch.RPT";}}`). Web: nothing. Fix: build from the web's voucher-summary view plus the metal rows of the vouchers.
8. **JmaUdr, In Out / Ac Sale prints missing.** Desktop `JmUdAmt` (`RP_LEDR.cs:4050 {{DC_Main.RptName = "JmUdAmt";}}`), `LedrInOut` (`RP_LEDR.cs:9235 {{DC_Main.RptName = "LedrInOut";}}`), `AcSaleWhRpt` (`RP_LEDR.cs:9116 {{DC_Main.RptName = "AcSaleWhRpt";}}`; selection `{MAIN_STOCK.CO_BOOK} <> '018'`). Web: none. Fix: add the money-only JmaUdr print first (no staging table); In Out needs FINE_DATA rows.
9. **Print rights text and rights check missing (wrong text).** Desktop refuses with `RP_LEDR.cs:8236 {{You Have No Print Rights.....}}` per button (six in all). The web has a view-vs-print rights case for the existing prints only. Fix: each new print route checks the print right and returns the exact text.
10. **Lite visibility of ageing (wrong behaviour).** Desktop hides Time Wise in L and B (`RP_LEDR.cs:4589 {{((Control)BtnTimeWise).Visible = false;}}`), so OP_LDR ageing is unreachable there; the web page shows "Debit Ageing" to all (`page.tsx:23`). Fix: owner decision; if parity is wanted, hide the view for Lite, else record it as a deliberate extension.
11. **Half-month columns (wrong behaviour).** Desktop hides columns 3, 4, 5, 12, 13, 14 unless "Half Month Show" is ticked (`RP_LEDR.cs:9693 {{((DataGridView)DGV_MONTH).Columns[3].Visible = false;}}`). Web has no toggle; `accountLedger.ts:103` always prints all buckets. Verify against the N223 bucket list (0-15 ... 151+); fix: add the toggle or document the difference.
12. **Opening-ledger voucher zoom (missing text).** Desktop `RP_LEDR.cs:10665 {{This Is a Opening Ledger Voucher You Cant Zoom ....}}` when the clicked voucher is an opening row. Web: no equivalent because OP_LDR rows are not in any grid; once Gap 1 or a detail union exists, add the refusal. Fix: server-side flag on the row plus the exact message.
13. **Tests: not-applicable groups T07-T14 stay valid only while nothing is written.** `accountLedger.mjs:404-441`. If Gap 5-8 are done with a staging write they must become applicable (concurrency T12, rollback T14). Fix: do the prints without a shared-table write, keep the groups, and add T05/T16/T17 cases for the new buttons.
14. **Evidence debt (verification).** `12-lineage-verification-2026-10-01.md:3085` still says desktop-runtime comparison remains open. Fix: after Gaps 1-8, record a desktop vs web comparison with OP_LDR rows loaded.

## Open questions

1. Silver of opening rows: the desktop reads the gold credit column (`RP_LEDR.cs:9716 {{SUM(A.DR_GL_FINE) as GoldWt}}`); is the owner's data meant to have silver in `*_SL_FINE` only? Real data was not read (rule 9). Aggregate-only counts of OP_LDR silver columns would answer it.
2. Do real OP_LDR rows ever have a null `VCH_DATE`? (they vanish from every bucket.) Not answerable from source.
3. The default of `UserPrint` when no USER_SET row exists is declared outside the lines read (field initialisation); not read for this scope.
4. Line numbers of a few sub-statements inside long statements (for example the `"0"` format at step 7 and the `Cr[(short)3..6]` parameter lines for Gold) were located with a search and checked by the citation tool; a reviewer should re-open `RP_LEDR.cs:9815 {{obj.Value = Strings.Format(RuntimeHelpers.GetObjectValue(obj4), "0");}}` and `8404-8416` before writing expected values.
5. Does the owner want the prints as server-built PDFs (no staging write) or the Crystal layouts bound to staging tables? The two typed helpers exist; the decision changes Gaps 5-8.
6. For `Gold_Summ` and `Silver_Summ` the four row shapes (one per `MAIN_BOOK`) were not read line by line (`RP_LEDR.cs:8449 {{SELECT * FROM AC_DATA WHERE CO_CODE = '}}`, `8680-8830`); a second study pass is needed before tests are written.
