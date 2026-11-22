# WP-30 cases — Transaction → Wh Sales residuals: frozen T01–T18 case list

This is the frozen case list for the four residual items of Transaction → Wh Sales (`TR_WH_SALE`, book `WH SALES`):
loose hand-typed item-detail rows, `SL_IDTL` on the print, fine kasar (Ksr Fine Dr/Cr) and Rojmel alignment. It is the
contract later workers are measured against. It changes no code.

The input is `orchestration/work/WP-30/study.md` and document 04 §3 (T01–T18). All desktop quotes below are copied
verbatim from the study, which copied them from `unified/src/csharp/DataCareNext/`. A quote has the form
`File.cs:N {{text}}`; N is a line in that file, and for a range the text comes from one of the lines in the range.
The desktop is the authority for business behaviour; "as the web shows" is never an expected value.

Case ids keep the `wholesale-sale.` module prefix used by `web/apps/web/test/features/modules/wholesaleSale.mjs`, so
an unchanged behaviour keeps its existing id. A case marked **REUSED** keeps its full steps and expectations in that
module; only its id and T-kind are recorded here. A case that is new for a residual item has its full layout.

`Layer` is `browser` (through the real screen), `database` (query the write set) or `unit` (kernel arithmetic vector).
`Status` is `executable`, `blocked: <reason, and what unblocks it>` or `N/A: <reason>`. A case is blocked only for a
reason outside this menu (a decision, a device, another work package), never because its code is missing today.

## Decisions on the study's open questions

Each is decided by the owner's standing rule: "the desktop first; the web adds only what a hosted multi-user service
needs to be safe and correct". Every decision is recorded as **architect, 2026-11-23, owner may override**.

1. **Rojmel directions and keys (study Q1, gaps 13 and 14).** The desktop source wins. The web's nine-type builder
   followed 66 rows of one company and called the source a later version, but the rule makes the source authoritative:
   keys carry the line number (`Ac_Rojmel.cs:231 {{A.VCH_NO+'05'+Str(A.SR_NO)}}`), names are
   `Ac_Rojmel.cs:249 {{B.BOOK_SNAME + ' - ' + A.AC_NAME}}`, and directions are the source SIGN columns. The row-for-row
   case below is executable, not blocked. **architect, 2026-11-23, owner may override**.
2. **`KR_CON_WT` (study Q2, gap 3).** The desktop never writes it; reopen only reads `TR_WH_SALE.cs:12629 {{["KR_CON_WT"]}}`.
   The web stores 0 so a read-back is identical. The write-set case asserts 0. **architect, 2026-11-23, owner may override**.
3. **Silver pair (study Q3, gap 10).** The source defines rows 19/20 (`Ac_Rojmel.cs:259 {{A.VCH_NO+'19'}}`) and the
   silver ledger legs, but the study found no `IT_TYPE 'S'` Wh Sales data and the study's Scope puts the silver families
   of the day book out of scope. The gold 07/08 case is executable; a silver case is blocked on the missing silver
   seed/decision. **architect, 2026-11-23, owner may override**.
4. **Detail row with no item code (study Q4).** The desktop's only refusal is for the issue grid,
   `TR_WH_SALE.cs:12894 {{Please Select Item Code In Row }}`; the detail loop `TR_WH_SALE.cs:13175-13190 {{DtIdtl.Rows[i][10]}}`
   has no refusal. A hand-typed detail row with a blank code is therefore written with an empty `IT_CODE`, and the
   hosted service adds no extra refusal. **architect, 2026-11-23, owner may override**.
5. **Four-decimal PcsWt registrations HM437NEHP / HM436NEHP (study Q5).** Registration-specific; N220 excluded the
   same class of check (`TR_WH_SALE.cs:7444 {{HM437NEHP}}`). Out of scope, listed under Not covered.
   **architect, 2026-11-23, owner may override**.

## Cases

### T01 Entry/defaults

Applies. The form opens only for a picked book; the residual items add default grid and box state.

- REUSED `wholesale-sale.entry.book-family` (T01 Entry/defaults) — executable. Reuse the existing case unchanged.
  Desktop dispatch: `MDI_FORM.cs:8040 {{case "Wh Sales":}}` then `MDI_FORM.cs:8041 {{DC_Main.CurBookHelp("WH SALES");}}`,
  gated by `MDI_FORM.cs:8042 {{if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)}}`.

#### wholesale-sale.entry.detail-grid-defaults   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the WH SALES voucher as admin. 2. Inspect `MSG_IDTL` and its edit box before any issue row is entered. 3. Compare position, size, initial visibility and captions with the desktop design.
Expected: the item-detail grid is at (12, 218) and sized 933×85 — `TR_WH_SALE.cs:4900 {{((Control)MSG_IDTL).Location = new Point(12, 218);}}`, `TR_WH_SALE.cs:4903 {{((Control)MSG_IDTL).Size = new Size(933, 85);}}` — with its edit box initially hidden `TR_WH_SALE.cs:4899 {{((Control)TEXT_IDTL).Visible = false;}}`. The caption of column 1 is "ItCode" `TR_WH_SALE.cs:7133 {{mSG_IDTL[0, 1] = "ItCode";}}` and columns 28–30 (`RowSrNo`, `OldGwt`) are internal, e.g. `TR_WH_SALE.cs:7115-7286 {{mSG_IDTL[0, 29] = "RowSrNo";}}`. Gap 1.
Status: executable

#### wholesale-sale.entry.fine-box-defaults   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open a blank voucher. 2. Read the two Ksr Fine boxes: caption, tab order, alignment, colour, enabled and visible state. 3. Tab from Ac Fine Dr to Ac Fine Cr.
Expected: "Ksr Fine Dr" `TR_WH_SALE.cs:5359 {{Ksr Fine Dr}}` and "Ksr Fine Cr" `TR_WH_SALE.cs:5369 {{Ksr Fine Cr}}` are the two captions; the controls are named `nFineKsrDr` `TR_WH_SALE.cs:5256-5263 {{((Control)nFineKsrDr).Name = "nFineKsrDr";}}` and `nFineKsrCr` `TR_WH_SALE.cs:5264-5271 {{((Control)nFineKsrCr).Name = "nFineKsrCr";}}`; tab indices are 14 then 15, right aligned, Honeydew, and neither is ever disabled or hidden, so both accept input in every edition. Gap 6.
Status: executable

#### wholesale-sale.entry.column-visibility-edition   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the form with `MsSoftType` "L" and type a code into the item-detail picker. 2. Open with "E" and inspect the DmCode..DmSfNo columns. 3. Reopen a saved voucher in each edition.
Expected: Lite stops the item-pick branch before the touch lookup `TR_WH_SALE.cs:11136 {{if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)}}` then `TR_WH_SALE.cs:11140 {{Select * From TOUCH_MAST WHERE CO_CODE}}`; the DmCode..DmSfNo columns are shown only for edition "E" `TR_WH_SALE.cs:7137 {{if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}}`; captions may be renamed from `TR_WH_SALE.cs:7267 {{BOOK_NAME = 'TAG_IDTL' AND COL_NAME = '}}`, but no other edition gate hides the grid or the kasar boxes.
Status: executable

### T02 Field route

Applies. The two new fields are the Ksr Fine boxes and the loose detail-row columns.

- REUSED `wholesale-sale.field.header-text` (T02 Field route) — executable. Reuse unchanged.

#### wholesale-sale.field.ksr-fine-dr-cr   (T02 Field route)
Layer: browser + database
Steps: 1. Enter a normal tag sale with Ac Fine Cr = 9.160 at rate 6500. 2. Type 0.500 into Ksr Fine Dr and 0.250 into Ksr Fine Cr and press Enter in each. 3. Save, query `RATE_CUT_DATA`, reload the voucher and read the boxes back.
Expected: Enter formats the typed value to three decimals — `TR_WH_SALE.cs:16035 {{nFineKsrDr.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineKsrDr.Text)), "0.000");}}` — so the boxes show "0.500" and "0.250". The POST carries `ksrFineDr = 0.5`, `ksrFineCr = 0.25` and the header stores `TR_WH_SALE.cs:12980 {{dataRow2["KSR_FINE_CR"] = Conversion.Val(nFineKsrCr.Text);}}` and `TR_WH_SALE.cs:12981 {{dataRow2["KSR_FINE_DR"] = Conversion.Val(nFineKsrDr.Text);}}`, so `KSR_FINE_CR = 0.25`, `KSR_FINE_DR = 0.5`. Reopen shows `TR_WH_SALE.cs:12230 {{nFineKsrCr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["KSR_FINE_CR"]), "0.000");}}` i.e. "0.250" and "0.500". Gaps 6, 8.
Status: executable

#### wholesale-sale.field.detail-row-fields   (T02 Field route)
Layer: browser + database
Steps: 1. On issue line 1 enter a loose item-detail row: item code, Pcs 2, PcsWt 1.5, Con% 10, KrCon% 5, rate type blank, rate 101, Disc% 5, LbrRate 237.5. 2. Inspect the POST `details[]` for that line. 3. Save and query `SL_IDTL` for the row.
Expected: every typed column reaches the request and the stored row: `IT_PCS = 2`, `IT_PCS_WT = 1.5`, `IT_CON_PRC = 10`, `KR_CON_PRC = 5`, `IT_RATE_TYPE = ''`, `IT_RATE = 101`, `IT_DISC_PRC = 5`, `IT_LBR_RATE = 237.5`. The write loop is `TR_WH_SALE.cs:13190-13245 {{dataRow4["CO_YEAR"] = DC_Main.MCo_year;}}` with `TR_WH_SALE.cs:13208 {{dataRow4["ENTRY_TYPE"] = "W";}}`; no typed column may be dropped between screen, request and database. Gaps 1, 3.
Status: executable

### T03 Formula sequence

Applies. The detail roll-up and the kasar totals are ordered computations.

- REUSED `wholesale-sale.formula.bankers-rounding-and-labour` (T03 Formula sequence) — executable. Reuse unchanged.

#### wholesale-sale.formula.detail-arithmetic   (T03 Formula sequence)
Layer: unit
Steps: 1. Feed the kernel `CommPassTotal_Idtl` (`TR_WH_SALE.cs:7750-7971 {{private void CommPassTotal_Idtl(int CRow)}}`) one row with Pcs 2, PcsWt 1.5, Con% 10, KrCon% 5, rate type blank, Weight 0, rate 101, Disc% 5, LbrRate 237.5, LbrAmt driven by Pcs. 2. Record each intermediate column after each of steps 1–8. 3. Repeat with KrCon% 0 and with rate type "P" to prove override precedence.
Expected, worked out: Weight = Pcs × PcsWt = 2 × 1.5 = 3.000 `TR_WH_SALE.cs:7753-7756 {{Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) * Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 11])}}`; TagWt = Weight = 3.000 `TR_WH_SALE.cs:7758-7761 {{mSG_IDTL[CRow, 26] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 14]), "0.000");}}`; ConWt = 3 × 10% = 0.300 `TR_WH_SALE.cs:7762-7766 {{mSG_IDTL[CRow, 25] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 15])), "0.000");}}`; KrConWt = TagWt × KrCon% = 3 × 5% = 0.150 because KrCon% > 0 `TR_WH_SALE.cs:7773-7779 {{mSG_IDTL[CRow, 27] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 26]) * Conversion.Val(mSG_IDTL[CRow, 24])), "0.000");}}`, and 3 × 10% = 0.300 when KrCon% = 0. Blank type with Weight 0 and Pcs ≠ 0 uses rate × Pcs; here Weight is 3 after step 1, so ItAmt = Math.Round(101 × 3, 0) = 303.00, and the banker's vector rate 101 × 2.5 = 252.5 → 252.00 (not 253) `TR_WH_SALE.cs:7790-7800 {{Math.Round(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 10]), 0), "0.00"}}`; type "P" always uses rate × Pcs, so 101 × 2 = 202.00. LbrAmt = 237.5 × 2 = 475.00 `TR_WH_SALE.cs:7811 {{mSG_IDTL[CRow, 22] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 21]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");}}`; DiscAmt = Math.Round(303 × 5/100, 0) = Math.Round(15.15, 0) = 15.00 `TR_WH_SALE.cs:7815 {{Math.Round(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 18]) * Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 19]) / 100.0, 0), "0.00"}}`; NetAmt = 303 − 15 + 475 = 763.00 `TR_WH_SALE.cs:7819 {{Conversion.Val(mSG_IDTL[CRow, 18]) - Conversion.Val(mSG_IDTL[CRow, 20]) + Conversion.Val(mSG_IDTL[CRow, 22])}}`. Gap 2.
Status: executable

#### wholesale-sale.formula.detail-rollup-to-line   (T03 Formula sequence)
Layer: browser + database
Steps: 1. Put two loose detail rows under issue line 1: row A ConWt 0.300, KrConWt 0.150, NetAmt 763.00; row B ConWt 0.200, KrConWt 0.000, NetAmt 500.00; line gross weight col15 = 5.000. 2. Read issue line column 16, 17, 37, 46 and 47 before saving. 3. Save and read the same columns from `RATE_CUT_ISU`.
Expected: col16 = sum ConWt = 0.300 + 0.200 = 0.500 `TR_WH_SALE.cs:7852 {{MSG[MSG.Row, 16] = Strings.Format((object)num3, "0.000");}}`; col17 = col15 − col16 = 5.000 − 0.500 = 4.500; col46 = sum KrConWt = 0.150 + 0.000 = 0.150; col47 = col15 − col46 = 5.000 − 0.150 = 4.850; col37 = sum NetAmt = 763.00 + 500.00 = 1263.00 `TR_WH_SALE.cs:7877 {{MSG[MSG.Row, 37] = Strings.Format((object)num5, "0.00");}}`. A silver detail row (ItType "S" with no ItAmt) adds its weight into col28 instead of col37. Gap 2.
Status: executable

#### wholesale-sale.formula.ksr-fine-totals   (T03 Formula sequence)
Layer: browser + unit
Steps: 1. Enter a tag sale whose base Tot Dr Fine and Tot Cr Fine are each 9.160. 2. Set Ksr Fine Dr = 0.500 and Ksr Fine Cr = 0.250 and press Enter. 3. Read Tot Fine Dr, Tot Fine Cr, Os Fine and the stored fine fields.
Expected: Tot Fine Dr = TotDrFine + AcDrFine + KsrFineDr = 9.160 + 0.000 + 0.500 = 9.660 `TR_WH_SALE.cs:15633 {{nTotFineDr.Text = Strings.Format((object)(TotDrFine + Conversion.Val(nAcDrFine.Text) + Conversion.Val(nFineKsrDr.Text)}}`; Tot Fine Cr = 9.160 + 0.000 + 0.250 = 9.410 `TR_WH_SALE.cs:15634 {{nTotFineCr.Text = Strings.Format((object)(TotCrFine + Conversion.Val(nAcCrFine.Text) + Conversion.Val(nFineKsrCr.Text)}}`; Os Fine = 9.660 − 9.410 = 0.250 `TR_WH_SALE.cs:15635 {{nDiffFine.Text = Strings.Format((object)(Conversion.Val(nTotFineDr.Text) - Conversion.Val(nTotFineCr.Text)), "0.000");}}`. All three use "0.000" with no rounding call. The stored `SL_FINE` stays 9.160 — `TR_WH_SALE.cs:12975-12976 {{dataRow2["SL_FINE"] = TotDrFine + Conversion.Val(MSG_TOT[0, 39]);}}` — and `PR_FINE` is unchanged; kasar changes only the kasar and Tot Fine columns. Gap 7.
Status: executable

### T04 Lookup

Applies. The item-detail box has its own item and dimension lookups.

- REUSED `wholesale-sale.lookup.sold-tag-not-offered` (T04 Lookup) — executable. Reuse unchanged.

#### wholesale-sale.lookup.detail-item-code   (T04 Lookup)
Layer: browser
Steps: 1. Enter an issue row's Con% and press Enter so focus moves into the detail box. 2. In column 1 press Enter with a blank value, then type a known item code, then an unknown code and open its help list. 3. In column 3 type a DM code and read the filled DmName and sale rate.
Expected: a blank column 1 returns the cursor to the issue row's Con% column `TR_WH_SALE.cs:7408 {{MSG.Col = 16;}}`; a non-blank column 1 searches `TR_WH_SALE.cs:7414 {{Select * From ITEM_MAST WHERE CO_CODE = '}}` and an unknown opens the help list; column 3 searches `TR_WH_SALE.cs:7473 {{Select * From DM_MAST WHERE CO_CODE}}` and fills DmName and the sale rate; a stale slow result from a previous code is rejected, so only the latest lookup fills the row. Gap 1.
Status: executable

### T05 Children

Applies. Loose detail rows and tag stones are two dissimilar child sets under a line.

- REUSED `wholesale-sale.children.two-tags-and-received-metal` (T05 Children) — executable. Reuse unchanged.
- REUSED `wholesale-sale.create.tag-stones` (T05 Children) — executable. Reuse unchanged; it proves the tag-stone `SL_IDTL` path and must keep passing when loose rows are added.

#### wholesale-sale.create.loose-item-detail-rows   (T05 Children)
Layer: browser + database
Steps: 1. On issue line 1 enter two loose detail rows (rows A and B above); on issue line 2 enter one row whose item code is blank and whose Pcs is 1, plus a fourth row that is entirely empty. 2. Save and query `SL_IDTL` ordered by `SR_NO`, `ISR_NO`. 3. Check that no row from line 1 appears under line 2.
Expected: rows are keyed by the line's serial: line 1 yields `SR_NO = 1` with `ISR_NO = 1` and `2` (A and B); line 2 yields `SR_NO = 2` with `ISR_NO = 1`; `ISR_NO` restarts at 1 for each line, and `ENTRY_TYPE = 'W'` `TR_WH_SALE.cs:13208 {{dataRow4["ENTRY_TYPE"] = "W";}}`. The fully empty row is skipped by the non-zero test `TR_WH_SALE.cs:13175-13190 {{DtIdtl.Rows[i][10]}}` (pieces, weight, tag weight or net amount must be non-zero), while the blank-code row is still written with an empty `IT_CODE` (open question 4). Ownership uses an explicit line id, not a hidden serial number: the desktop's `TR_WH_SALE.cs:13191 {{if ((double)num7 == Conversion.Val(MSG[DC_Main.M, 62]))}}` link is a weakness and must not be ported. Gaps 1, 3.
Status: executable

### T06 Required/invalid

Applies. The residual items add a row-delete right and an absence of kasar validation.

- REUSED `wholesale-sale.refusal.defaulter-with-outstanding` (T06 Required/invalid) — executable.
- REUSED `wholesale-sale.refusal.defaulter-paid-in-full-saves` (T06 Required/invalid) — executable.
- REUSED `wholesale-sale.refusal.employee-mandatory` (T06 Required/invalid) — executable.
- REUSED `wholesale-sale.refusal.company-type-b` (T06 Required/invalid) — executable.
- REUSED `wholesale-sale.refusal.cheque-without-bank` (T06 Required/invalid) — executable.
- REUSED `wholesale-sale.refusal.card-without-bank` (T06 Required/invalid) — executable.
- REUSED `wholesale-sale.refusal.date-outside-year` (T06 Required/invalid) — executable.
- REUSED `wholesale-sale.refusal.item-code-missing` (T06 Required/invalid) — executable. This refusal is for the issue grid only; the detail-row case below is different.

#### wholesale-sale.refusal.detail-row-delete-right   (T06 Required/invalid)
Layer: browser
Steps: 1. Sign in as a user whose `UserDelete` is not "Y" (clerk). 2. Open a voucher with a loose detail row, put focus in the detail box and press Ctrl+D. 3. Confirm no dialog or row removal, then repeat as admin and answer the question.
Expected: without the right, Ctrl+D answers `TR_WH_SALE.cs:7328 {{You Have No Rights.....}}` — condition `TR_WH_SALE.cs:7326 {{(Operators.CompareString(UserDelete, "Y", false) != 0)}}` — focus stays in the box and the row remains. With the right the question is `TR_WH_SALE.cs:7331 {{This Row Record will Removed permantley ?}}` and after Yes the message is `TR_WH_SALE.cs:7356 {{Record is Deleted....}}`. Gap 1.
Status: blocked: the web has no client-side source for `UserDelete` (rights are enforced by the server on save, not on a key press); unblocked by a session-rights hook, which belongs to another work package.

#### wholesale-sale.refusal.kasar-any-number   (T06 Required/invalid)
Layer: browser + database
Steps: 1. In Ksr Fine Dr type "-1", then "12.3456", then "9999999999", pressing Enter each time. 2. Read the formatted box and try to save the voucher. 3. Repeat with a non-numeric string.
Expected: there is no kasar validation: any number is accepted and formatted to three decimals `TR_WH_SALE.cs:16035 {{nFineKsrDr.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineKsrDr.Text)), "0.000");}}`, so "-1" becomes "-1.000", "12.3456" becomes "12.346" and a non-numeric string becomes "0.000"; each Enter recomputes the bill. No refusal message is defined for these boxes. Gap 6.
Status: executable

#### wholesale-sale.refusal.detail-row-no-item-code   (T06 Required/invalid)
Layer: browser + database
Steps: 1. On issue line 1 enter a loose detail row with Pcs 1 and a blank item code. 2. Save. 3. Query `SL_IDTL` for the row.
Expected: the save succeeds and the row is written with `IT_CODE = ''` (empty), because the only item-code refusal belongs to the issue grid `TR_WH_SALE.cs:12894 {{Please Select Item Code In Row }}` followed by `TR_WH_SALE.cs:12895 {{return;}}`, while the detail loop `TR_WH_SALE.cs:13175-13190 {{DtIdtl.Rows[i][10]}}` shows no refusal text. Decision 4 above. Gap 1, study open question 4.
Status: executable

### T07 Create

Applies. The write set now includes loose detail rows and the two kasar columns.

- REUSED `wholesale-sale.create.tag-sale` (T07 Create) — executable. Reuse unchanged.

#### wholesale-sale.create.loose-detail-write-set   (T07 Create)
Layer: database
Steps: 1. Save once through the browser a voucher with one tag stone row and two loose detail rows and non-zero Ksr Fine Dr/Cr. 2. Query the complete footprint of that voucher: header, issue, receive, `SL_IDTL`, `DM_DATA`, ledger, day book, stock and audit. 3. Compare every `SL_IDTL` column with the posted values.
Expected: `SL_IDTL` holds one row per non-empty detail, each with `CO_CODE`, `LC_CODE`, `CO_YEAR`, `CO_BOOK`, `VCH_NO`, `HD_VCH_NO`, `VCH_DATE`, `AC_CODE`, `VCH_TYPE`, `INOUT_TYPE`, `ENTRY_TYPE = 'W'`, `BOOK_NAME`, `SR_NO` (line serial), `TAG_NO`, `VCH_SRNO`, `ISR_NO` (restarting at 1), `IT_CODE`, `DM_CODE`, `DM_NAME`, `DM_COLOR`, `DM_SIZE`, `DM_ORIGIN`, `DM_REMARK`, `DM_SFNO`, `IT_PCS`, `IT_PCS_WT`, `KR_LESS_PRC`, `IT_GWT`, `KR_WT`, `IT_CON_PRC`, `IT_RATE_TYPE`, `IT_RATE`, `IT_AMT`, `IT_DISC_PRC`, `IT_DISC_AMT`, `IT_LBR_RATE`, `IT_LBR_AMT`, `IT_NET_AMT`, `KR_CON_PRC`, `IT_CON_WT`, `IT_TYPE`, `MAIN_USER` — the insert list is `TR_WH_SALE.cs:13190-13245 {{dataRow4["CO_YEAR"] = DC_Main.MCo_year;}}` with `TR_WH_SALE.cs:13162 {{SELECT * FROM SL_IDTL WHERE CO_CODE}}` as the desktop source. `KR_CON_WT = 0` (decision 2; `TR_WH_SALE.cs:12629 {{["KR_CON_WT"]}}` is read on reopen but never written). Each row is written in the voucher transaction, not one at a time with a cleared adapter (`TR_WH_SALE.cs:13245-13250 {{RsIdtl.Clear();}}` is a weakness). The header carries `KSR_FINE_DR = 0.5` and `KSR_FINE_CR = 0.25`. Gap 3.
Status: executable

### T08 Reopen/no-op

Applies. Reopen must not lose loose detail rows or kasar.

- REUSED `wholesale-sale.reopen.unchanged-save` (T08 Reopen/no-op) — executable. Reuse unchanged.

#### wholesale-sale.reopen.loose-detail-rows-return   (T08 Reopen/no-op)
Layer: browser + database
Steps: 1. Save a voucher with two loose detail rows and Ksr Fine Dr 0.500 / Cr 0.250. 2. Capture its full write set, close, and load the voucher by number. 3. Read the detail rows and kasar boxes, save unchanged, and compare the write set again with `SL_IDTL` included.
Expected: GET returns the detail rows joined to the item name — `TR_WH_SALE.cs:12588 {{SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE}}` — and the loop `TR_WH_SALE.cs:12590-12630 {{while (DC_Main.i < RsIdtl.Rows.Count)}}` rebuilds `DtIdtl` with `ISR_NO` into column 0 and `SR_NO` into column 29. Both loose rows reappear with the same pieces, weight, rate and net amount and the same `SR_NO`/`ISR_NO`; the kasar boxes show "0.500"/"0.250" from `TR_WH_SALE.cs:12230 {{nFineKsrCr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["KSR_FINE_CR"]), "0.000");}}`. The unchanged save leaves every `SL_IDTL` row identical, including `KR_CON_WT = 0`. Gap 4.
Status: executable

### T09 Edit

Applies. Editing must rewrite loose rows, not lose them.

- REUSED `wholesale-sale.edit.drop-a-tag` (T09 Edit) — executable. Reuse unchanged.

#### wholesale-sale.edit.loose-detail-row-change   (T09 Edit)
Layer: browser + database
Steps: 1. Save a voucher with two loose detail rows. 2. Load it, change row B's Pcs from 2 to 3 and delete row A, save. 3. Reopen and compare all `SL_IDTL` rows and the line roll-up columns.
Expected: on edit the old detail rows are deleted first `TR_WH_SALE.cs:12937 {{DELETE FROM SL_IDTL WHERE CO_CODE}}` and the rows are rewritten from the current screen via `TR_WH_SALE.cs:12588 {{SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST AS B}}`, so the result is one row with `IT_PCS = 3`, `ISR_NO = 1` and no row A; the voucher number and creating user are unchanged. Row B's NetAmt is recomputed with Pcs 3 (ItAmt = 101 × 3 = 303.00, DiscAmt = 15.00, LbrAmt = 237.5 × 3 = 712.50, NetAmt = 303 − 15 + 712.50 = 1000.50) and the line col37 becomes 1000.50. No row from another voucher changes. Gap 4.
Status: executable

### T10 Delete/cancel/reverse

Applies. Delete must remove the loose detail rows.

- REUSED `wholesale-sale.delete.audit-and-tags-back` (T10 Delete/cancel/reverse) — executable. Reuse unchanged.

#### wholesale-sale.delete.removes-detail-rows   (T10 Delete/cancel/reverse)
Layer: browser + database
Steps: 1. Save a voucher with two loose detail rows. 2. Load it, press Delete, answer No and confirm the rows remain, then press Delete and answer Yes. 3. Query `SL_IDTL`, `DM_DATA` and `DELETE_DATA` for that voucher.
Expected: the question is `TR_WH_SALE.cs:13567 {{Are You Sure To Delete This Voucher now?}}`; No leaves the rows, Yes writes the audit `TR_WH_SALE.cs:13569 {{INSERT INTO DELETE_DATA}}` and removes every `SL_IDTL` row of that voucher while leaving rows of other vouchers intact — the desktop deletes SL_IDTL by voucher (`TR_WH_SALE.cs:12937 {{DELETE FROM SL_IDTL WHERE CO_CODE}}`), never an unscoped table clear. Gap 3.
Status: executable

### T11 Scope/rights

Applies. The detail-row delete and the print each have their own right.

- REUSED `wholesale-sale.rights.clerk-no-wh-sales` (T11 Scope/rights) — executable. Reuse unchanged.

#### wholesale-sale.rights.detail-delete-and-print   (T11 Scope/rights)
Layer: browser + database
Steps: 1. As admin, make a voucher with a loose detail row. 2. As a clerk with `UserDelete` and `UserPrint` absent, call the detail-delete key and a direct print request; then try a direct POST with `details[]` and kasar. 3. Confirm no cross-scope write or read.
Expected: the clerk receives `TR_WH_SALE.cs:7328 {{You Have No Rights.....}}` for the row delete (right from `TR_WH_SALE.cs:11512 {{Select * From USER_SET WHERE LC_CODE}}`) and `TR_WH_SALE.cs:13660 {{You Have No Print Rights.....}}` guarded by `TR_WH_SALE.cs:13658 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}`; the direct POST is refused with no rows written in any tenant. Edit-save by a user without the update or edit right is refused `TR_WH_SALE.cs:12848 {{You Have No Rights.....}}` under `TR_WH_SALE.cs:12846 {{if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0)}}`. Gaps 1, 6.
Status: blocked: its Ctrl+D half needs the same client-side `UserDelete` source; its direct-POST and print-right halves are covered by the reused `rights.clerk-no-wh-sales` and `output.print-rights`.

### T12 Concurrency

Applies. Two sessions can race on the new detail rows.

- REUSED `wholesale-sale.concurrency.double-delete` (T12 Concurrency) — executable. Reuse unchanged.

#### wholesale-sale.concurrency.detail-row-race   (T12 Concurrency)
Layer: browser + database
Steps: 1. Save a voucher with two loose detail rows. 2. Open it in two sessions; session A deletes row A, session B changes row B's Pcs to 3. 3. Both save; reload and count `SL_IDTL` rows and their values.
Expected: one save wins and the other is a defined conflict (not a lost update); the result is exactly the winner's set of `SL_IDTL` rows — either two rows with row A gone and row B at Pcs 2, or two rows with row B at Pcs 3 — and never one row with values mixed from both sessions. Because edit deletes and rewrites the whole set (`TR_WH_SALE.cs:12937 {{DELETE FROM SL_IDTL WHERE CO_CODE}}`), a stale hidden number such as `TR_WH_SALE.cs:13191 {{if ((double)num7 == Conversion.Val(MSG[DC_Main.M, 62]))}}` must never attach a row to the wrong line. Gaps 3, 4.
Status: executable

### T13 Retry/unknown

Applies. A duplicate submit must not duplicate the detail set.

- REUSED `wholesale-sale.retry.double-click` (T13 Retry/unknown) — executable. Reuse unchanged.

#### wholesale-sale.retry.detail-row-double-post   (T13 Retry/unknown)
Layer: browser + database
Steps: 1. Fill a voucher with two loose detail rows and kasar, then submit the same POST twice (double-click and a replayed request after losing the reply). 2. Count vouchers and `SL_IDTL` rows. 3. Reconnect and reload the resulting voucher.
Expected: exactly one voucher exists with exactly two `SL_IDTL` rows (`ISR_NO = 1, 2`), one `KSR_FINE_DR = 0.5` header and one ledger/day-book set; the replay does not insert a second financial effect or a second audit row. The set is written once from `TR_WH_SALE.cs:13162 {{SELECT * FROM SL_IDTL WHERE CO_CODE}}` inside the single transaction of `TR_WH_SALE.cs:12756-13520 {{private void BtnSave_Click(object sender, EventArgs e)}}`. Gap 3.
Status: blocked: `POST /wholesale-sales` is not yet idempotency-guarded (listed in `NOT_YET_GUARDED`, `web/apps/api/test/idempotencyRoutePolicy.test.ts`, a WP-04 follow-up); unblocked when the route takes `Idempotency-Key`.

### T14 Rollback

Applies. A fault after the detail write must roll everything back.

- REUSED `wholesale-sale.rollback.fault-on-issue-row` (T14 Rollback) — executable. Reuse unchanged.

#### wholesale-sale.rollback.fault-on-slidtl-row   (T14 Rollback)
Layer: database
Steps: 1. Raise a database fault on the second insert into `SL_IDTL` for a voucher with two loose rows and non-zero kasar. 2. Submit through the browser. 3. Query header, issue, `SL_IDTL`, ledger, day book, stock and the hidden number table; remove the fault.
Expected: the save returns an error and no table holds a row for that voucher: the ledger, day book and stock rebuilds (`TR_WH_SALE.cs:13347 {{DELETE FROM AC_DATA WHERE CO_CODE}}`, `TR_WH_SALE.cs:13350 {{DELETE FROM ROJ_MEL_DATA WHERE CO_CODE}}`, `TR_WH_SALE.cs:13353 {{DELETE FROM MAIN_STOCK}}`) are inside the same transaction and roll back with the detail insert; the four kasar ledger legs and the day-book rows are also absent; an unrelated sentinel voucher is untouched. Gaps 3, 9, 10.
Status: executable

### T15 Config/history

Applies. Edition and configuration decide what the detail panel shows and a historic voucher keeps its own kasar.

- REUSED `wholesale-sale.config.lock-date` (T15 Config/history) — executable. Reuse unchanged.

#### wholesale-sale.config.edition-and-history   (T15 Config/history)
Layer: browser + database
Steps: 1. Save a voucher with Ksr Fine Dr 0.500 / Cr 0.250. 2. Change the company setting and the item master used by the detail row between loading and saving it. 3. Reload the historic voucher in edition "L" and again in edition "E".
Expected: the reopened voucher shows its stored "0.500"/"0.250" from `TR_WH_SALE.cs:12230 {{nFineKsrCr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["KSR_FINE_CR"]), "0.000");}}`, not a new default; changing a master between load and save follows the source's branch `TR_WH_SALE.cs:11136 {{if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)}}` and the "E" column gate `TR_WH_SALE.cs:7137 {{if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}}`; an unchanged save is refused by the lock date as in the reused case. No hidden global kasar default is used. Gaps 6, 8.
Status: executable

### T16 Report/output

Applies. The bill must show detail rows under each line and the kasar in its band.

- REUSED `wholesale-sale.output.print-bill` (T16 Report/output) — executable. Reuse unchanged; it already checks the title, the tag and the four-column band.

#### wholesale-sale.output.print-detail-under-line   (T16 Report/output)
Layer: browser + output
Steps: 1. Save three vouchers: one issue line with 0 detail rows, one with 1, and two lines carrying 0, 1 and 2 detail rows. 2. Print each and read the Issue Item section. 3. Compare the order and the item name, pieces, gross weight, rate and net amount with `SL_IDTL`.
Expected: after each issue line its detail rows print in `ISR_NO` order: item name from `ITEM_MAST`, `IT_PCS`, `IT_GWT`, `IT_RATE`, `IT_NET_AMT` (report spec `WhSalesBill.spec.json`, area 5, Section5). The desktop joins the table itself — `TR_WH_SALE.cs:13689 {{LEFT JOIN SL_IDTL AS B}}` — no Crystal parameter is needed. The 0-row voucher shows no detail under its line; the 2-row voucher shows both in order; no row appears under the wrong line. Gap 5.
Status: executable

#### wholesale-sale.output.print-kasar-fine-row   (T16 Report/output)
Layer: browser + output
Steps: 1. Save a voucher with Ksr Fine Dr 0.500 / Cr 0.250 and a base Dr/Cr fine of 9.160. 2. Print the WhSalesBill. 3. Read @RecFine, @IsuFine and the Kasar Fine column.
Expected: the band uses the stored kasar: RecFine and IsuFine are computed from `KSR_FINE_CR = 0.25` and `KSR_FINE_DR = 0.5` — values written by `TR_WH_SALE.cs:12980 {{dataRow2["KSR_FINE_CR"] = Conversion.Val(nFineKsrCr.Text);}}` and `TR_WH_SALE.cs:12981 {{dataRow2["KSR_FINE_DR"] = Conversion.Val(nFineKsrDr.Text);}}` — so the printed totals are the 9.410 and 9.660 of the formula case, with the kasar shown, not 0. Gap 11.
Status: executable

#### wholesale-sale.output.print-rights   (T16 Report/output)
Layer: browser
Steps: 1. As a user without the print right, open a saved voucher with loose detail rows and try the Print button and a direct print URL. 2. As admin, print the same voucher.
Expected: without the right the refusal is `TR_WH_SALE.cs:13660 {{You Have No Print Rights.....}}` under `TR_WH_SALE.cs:13658 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}` and no document is produced; with the right the WhSalesBill opens (the print route picks `WhSalesBill` for a WH SALES book; `TR_WH_SALE.cs:13749-13752 {{SELECT * FROM RATE_CUT_ISU_REC WHERE CO_CODE}}` chooses the template family). Gap 5.
Status: executable

### T17 Keyboard/usability

Applies. The detail grid and the kasar boxes have complete keyboard flows.

- REUSED `wholesale-sale.keyboard.alt-s-saves` (T17 Keyboard/usability) — executable. Reuse unchanged.
- REUSED `wholesale-sale.keyboard.voucher-number-keys` (T17 Keyboard/usability) — executable. Reuse unchanged.

#### wholesale-sale.keyboard.detail-grid-enter-esc-ctrl-d   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Enter an issue row's Con% and press Enter to move into the detail box. 2. Walk columns 1, 3, 11, 13 and 23 with Enter, adding a row on the last column of the last row. 3. Press Esc from the box, press Ctrl+D on a row and answer the question, then press an arrow key in the box.
Expected: after Con% the cursor moves to the last detail row `TR_WH_SALE.cs:11293 {{MSG_IDTL.Row = MSG_IDTL.Rows - 1;}}`; column 11 sets Weight = Pcs × PcsWt `TR_WH_SALE.cs:7507 {{Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) * Conversion.Val(TEXT_IDTL.Text)}}` and column 13 sets Weight = KrWt × KrLs% / 100 `TR_WH_SALE.cs:7513 {{Conversion.Val(TEXT_IDTL.Text) / 100.0}}`; column 23 on the last row adds a row `TR_WH_SALE.cs:7522 {{mSG_IDTL.Rows += 1;}}` and on an earlier row moves to the next row; Esc hides the box and returns to the issue-grid edit `TR_WH_SALE.cs:13625-13630 {{else if (((Control)TEXT_IDTL).Visible)}}`; Ctrl+D asks `TR_WH_SALE.cs:7331 {{This Row Record will Removed permantley ?}}`; arrows select all text `TR_WH_SALE.cs:17251 {{((TextBoxBase)TEXT_IDTL).SelectionStart = 0;}}`. Gap 1.
Status: executable

#### wholesale-sale.keyboard.ksr-fine-enter-tab   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Fill an ordinary tag sale. 2. In Ksr Fine Dr type "0.5" and press Enter; observe the box, bill totals and focus. 3. Repeat in Ksr Fine Cr. 4. Press F1 in the bill-profit box.
Expected: Enter formats to "0.500" `TR_WH_SALE.cs:16035 {{nFineKsrDr.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineKsrDr.Text)), "0.000");}}`, calls the bill recomputation `BILL_TOTAL()` `TR_WH_SALE.cs:15369-15763 {{private void BILL_TOTAL()}}` and sends Tab to the next control (Cr then the following field). F1 in the bill-profit box is key 112 `TR_WH_SALE.cs:17973-17980 {{if ((int)e.KeyCode != 112)}}` and runs the fine refresh whose message is `TR_WH_SALE.cs:17995 {{Kr Fine Update Please ReOpen Voucher .....}}`; that F1 effect is explicitly not part of WP-30 and must not be ported as an unscoped update. Gap 6.
Status: executable

### T18 Full journey

Applies. The new legs, day-book rows and detail rows must reconcile down the chain.

- REUSED `wholesale-sale.journey.outstanding-then-cash-received` (T18 Full journey) — executable. Reuse unchanged.

#### wholesale-sale.ledger.ksr-fine-legs   (T18 Full journey)
Layer: database + browser
Steps: 1. Save a voucher with Ksr Fine Dr 0.500 / Cr 0.250. 2. Query all `AC_DATA` legs of the voucher and run the balance assertion. 3. Reopen and save unchanged, then compare the legs.
Expected: four extra legs exist only when the corresponding kasar is non-zero. Leg 27 has key suffix `Ac_Ledr.cs:685 {{A.VCH_NO+'27'}}`, AC_CODE the party, sign '+' and `FINE_WT = KSR_FINE_CR = 0.25`; leg 28 has `Ac_Ledr.cs:687 {{A.VCH_NO+'28'}}`, AC_CODE the slot-12 account, sign '-' and fine 0.25 — `Ac_Ledr.cs:687 {{A.IT_TYPE,'-',A.KSR_FINE_CR}}`. Leg 33 has `Ac_Ledr.cs:703 {{A.VCH_NO+'33'}}`, AC_CODE the party, sign '-' and fine 0.5; leg 34 has `Ac_Ledr.cs:705 {{A.VCH_NO+'34'}}`, AC_CODE the slot-12 account, sign '+' and fine 0.5. All four carry CR_AMT = DR_AMT = 0, so the voucher stays balanced; an unchanged save leaves them identical. Gap 9.
Status: executable

#### wholesale-sale.rojmel.ksr-fine-rows   (T18 Full journey)
Layer: database
Steps: 1. Save a gold voucher with Ksr Fine Dr 0.500 / Cr 0.250. 2. Query `ROJ_MEL_DATA` rows with keys ending 07 and 08. 3. Delete and re-save, then compare the rows.
Expected: row 07 key is `Ac_Rojmel.cs:235 {{A.VCH_NO+'07'}}`, AC_NAME is `'KSR' + ' - ' + E.AC_NAME`, ITM_FINE = 0.500, SIGN '-' and every money column 0; row 08 key is `Ac_Rojmel.cs:237 {{A.VCH_NO+'08'}}`, ITM_FINE = 0.250 and SIGN '+'. Both require slot 12 and a non-zero kasar, and both disappear when the kasar is 0. The web must pass the stored kasar rather than the constant 0 it writes today. Gaps 10, 3 (silver 19/20 is blocked by decision 3).
Status: executable

#### wholesale-sale.rojmel.lined-voucher-rows-05-06-14-27   (T18 Full journey)
Layer: database
Steps: 1. Save a voucher with two issue lines and one receive row whose line carries fine but no item amount, a negative `SL_BILL_OS`, and a labour amount. 2. Query `ROJ_MEL_DATA` for types 05, 06, 14 and 27 and check key, name, sign, pieces, gross, net weight, touch, wastage and fine. 3. Delete and re-save and compare.
Expected: issue row 05 key is `Ac_Rojmel.cs:231 {{A.VCH_NO+'05'+Str(A.SR_NO)}}` with name `B.BOOK_SNAME + ' - ' + A.AC_NAME` and SIGN '-', written when `ITM_FINE <> 0 AND ITM_AMT = 0`; receive row 06 key is `Ac_Rojmel.cs:233 {{A.VCH_NO+'06'+Str(A.SR_NO)}}` with SIGN '+'; row 14 carries `Ac_Rojmel.cs:249 {{ABS(A.SL_BILL_OS)}}` when `SL_BILL_OS < 0`; row 27 is labour named `Ac_Rojmel.cs:275 {{'LBR' + ' - ' + A.AC_NAME}}` with `SL_LBR_AMT + SL_OTH_AMT`. Each key carries the line serial. Gaps 12, 13, 14.
Status: executable

#### wholesale-sale.rojmel.key-and-name-shape   (T18 Full journey)
Layer: database
Steps: 1. Using the voucher of the previous case, compare every generated `ROJ_MEL_DATA` key and AC_NAME with the source expressions for types 01–04, 05, 06, 07, 08, 13, 14, 22, 26 and 27. 2. Check the SIGN of each against the source SIGN column. 3. Verify that no row is keyed without its line number when the source carries one.
Expected: names are `Ac_Rojmel.cs:249 {{B.BOOK_SNAME + ' - ' + A.AC_NAME}}` for the line and header types (and `'KSR' + ' - ' + E.AC_NAME` for 07/08), and directions are the source signs, e.g. 05 is '-' and 06 is '+' in the quoted lines, because decision 1 gives the source priority over the web's 66-row sample. No type that carries `Str(A.SR_NO)` in the source may lose the line number. Gaps 13, 14.
Status: executable

#### wholesale-sale.rojmel.missing-types-and-silver   (T18 Full journey)
Layer: database
Steps: 1. For a Wh Sales voucher exercise types 21, 23, 24, 25, 28, 29–40 and the silver types 09–12, 15–18. 2. Compare the produced rows with the source list at lines 263–308. 3. Record which are absent.
Expected: the source defines these types, e.g. `Ac_Rojmel.cs:263 {{A.VCH_NO+'21'}}`, but the study found none of them in the live data and they are outside the four requested items; this case is kept in the frozen list so "Rojmel alignment" is not silently called complete. Gap 15.
Status: blocked: no owner decision on whether to build types 21/23/24/25/28/29–40 for Wh Sales, and no `IT_TYPE 'S'` Wh Sales seed or decision for silver types; unblocked by that decision plus a silver seed (decision 3).

## Coverage table

| Kind | Title | Cases | Reused | New | Blocked | N/A |
|---|---|---:|---:|---:|---:|---:|
| T01 | Entry/defaults | 4 | 1 | 3 | 0 | 0 |
| T02 | Field route | 3 | 1 | 2 | 0 | 0 |
| T03 | Formula sequence | 4 | 1 | 3 | 0 | 0 |
| T04 | Lookup | 2 | 1 | 1 | 0 | 0 |
| T05 | Children | 3 | 2 | 1 | 0 | 0 |
| T06 | Required/invalid | 11 | 8 | 3 | 1 | 0 |
| T07 | Create | 2 | 1 | 1 | 0 | 0 |
| T08 | Reopen/no-op | 2 | 1 | 1 | 0 | 0 |
| T09 | Edit | 2 | 1 | 1 | 0 | 0 |
| T10 | Delete/cancel/reverse | 2 | 1 | 1 | 0 | 0 |
| T11 | Scope/rights | 2 | 1 | 1 | 1 | 0 |
| T12 | Concurrency | 2 | 1 | 1 | 0 | 0 |
| T13 | Retry/unknown | 2 | 1 | 1 | 1 | 0 |
| T14 | Rollback | 2 | 1 | 1 | 0 | 0 |
| T15 | Config/history | 2 | 1 | 1 | 0 | 0 |
| T16 | Report/output | 4 | 1 | 3 | 0 | 0 |
| T17 | Keyboard/usability | 4 | 2 | 2 | 0 | 0 |
| T18 | Full journey | 6 | 1 | 5 | 1 | 0 |
| **Total** | | **58** | **27** | **31** | **4** | **0** |

Every T01–T18 kind applies to this menu, so none is N/A. All 58 case ids (27 reused, 31 new) are frozen here; the
four blocked cases are blocked on a decision, a seed, the shared rights source or the idempotency guard, none on missing code of this menu. Gap 17's twelve
requested ids are all present: `create.loose-item-detail-rows`, `reopen.loose-detail-rows-return`,
`edit.loose-detail-row-change`, `delete.removes-detail-rows`, `output.print-detail-under-line`,
`keyboard.detail-grid-enter-esc-ctrl-d`, `field.ksr-fine-dr-cr`, `formula.ksr-fine-totals`,
`ledger.ksr-fine-legs`, `rojmel.ksr-fine-rows`, `rojmel.lined-voucher-rows-05-06-14-27` and
`output.print-kasar-fine-row`.

### Gap coverage index

| Gap | Case(s) |
|---|---|
| 1 Loose rows: entry | `entry.detail-grid-defaults`, `field.detail-row-fields`, `lookup.detail-item-code`, `create.loose-item-detail-rows`, `refusal.detail-row-delete-right`, `refusal.detail-row-no-item-code`, `rights.detail-delete-and-print`, `keyboard.detail-grid-enter-esc-ctrl-d` |
| 2 Loose rows: arithmetic | `formula.detail-arithmetic`, `formula.detail-rollup-to-line` |
| 3 SL_IDTL write for loose rows | `create.loose-detail-write-set`, `delete.removes-detail-rows`, `rollback.fault-on-slidtl-row`, `retry.detail-row-double-post`, `concurrency.detail-row-race`, `field.detail-row-fields` |
| 4 SL_IDTL reopen and edit | `reopen.loose-detail-rows-return`, `edit.loose-detail-row-change`, `concurrency.detail-row-race` |
| 5 SL_IDTL under bill line | `output.print-detail-under-line`, `output.print-rights` |
| 6 Ksr Fine boxes | `entry.fine-box-defaults`, `field.ksr-fine-dr-cr`, `refusal.kasar-any-number`, `keyboard.ksr-fine-enter-tab`, `rights.detail-delete-and-print`, `config.edition-and-history` |
| 7 Kasar in totals | `formula.ksr-fine-totals` |
| 8 Kasar stored | `field.ksr-fine-dr-cr`, `config.edition-and-history` |
| 9 Kasar ledger legs | `ledger.ksr-fine-legs`, `rollback.fault-on-slidtl-row` |
| 10 Kasar day-book rows | `rojmel.ksr-fine-rows`, `rollback.fault-on-slidtl-row` |
| 11 Kasar on print | `output.print-kasar-fine-row` |
| 12 Rojmel lined rows | `rojmel.lined-voucher-rows-05-06-14-27` |
| 13 Rojmel key and name | `rojmel.lined-voucher-rows-05-06-14-27`, `rojmel.key-and-name-shape` |
| 14 Rojmel directions | `rojmel.key-and-name-shape` |
| 15 Missing Rojmel types | `rojmel.missing-types-and-silver` (blocked) |
| 16 Other N228 leftovers | Not covered (out of scope) |
| 17 Browser cases | The twelve ids are frozen above |

## Test data

The smallest seed the cases need, described rather than as SQL:

- One company with the WH SALES book `WHS` (`BOOK_SNAME 'WSALE'`, `BOOK_TBL_NAME 'RATE_CUT_DATA'`) and its `BOOK_DETL`
  slots, including slot 12 for the kasar account and slots 1, 2, 8 for the rojmel legs. Year `YYYY–YYYY+1`, opening day
  `YYYY-04-05`, voucher day `YYYY-07-15`, lock date after that day for the lock-date case only.
- Two parties: a local customer used by the defaulter, refusal and tag-sale cases, and an inter-state customer used by
  the full-journey case so a later cash receipt is not blocked by the cash limit. An admin user with save, edit, delete
  and print rights and a clerk without delete or print rights, from `USER_SET`.
- Two gold items: one ordinary and one with `OTH_DETL_POSTING = 'Y'` so the `DM_DATA` projection can be asserted. A
  silver item is needed only for the blocked silver case.
- One live gold tag per case, seeded as a tag opening leaves it: a `BAR_DETL` row plus a `+` `MAIN_STOCK` row of 10 g at
  touch 91.6 (fine 9.160), optionally with two non-empty `BAR_IDTL` stones and one empty stone. Every case seeds its
  own tag so cases never share one. A net-wise labour rate of 237.5/g is used by the rounding case.
- Loose detail rows are typed through the screen, not seeded: row A (item code, Pcs 2, PcsWt 1.5, Con% 10, KrCon% 5,
  rate type blank, rate 101, Disc% 5, LbrRate 237.5), row B (Pcs 2, NetAmt 500.00), one blank-code Pcs-1 row and one
  entirely empty row. For the print case: 0, 1 and 2 detail rows under one or two issue lines.
- Kasar values are typed through the screen: Ksr Fine Dr 0.500, Ksr Fine Cr 0.250 over base Tot Fine Dr/Cr 9.160.
- A sentinel voucher in the same book, untouched by every case, is used by the rollback and delete cases to prove no
  unscoped delete.

## Not covered

- **Gap 16 (out of scope):** the voucher list's fine and purchase columns, the `cboPrintfile` variants `RateCutBill`,
  `WhQuotation`, `WhHuidPrint`, `WhSalesImage`, the `@AcMobile` formula slip and party GST number `AC_GSTNO` vs
  `AC_LSTNO`. None is one of the four requested items.
- **Study open question 5:** the `HM437NEHP` / `HM436NEHP` four-decimal PcsWt registrations,
  `TR_WH_SALE.cs:7444 {{HM437NEHP}}`. Registration-specific and excluded by N220, so no case.
- **Silver Rojmel and kasar cases:** the silver 19/20 and 09–18 rows and the silver ledger legs are covered only by the
  blocked case; no silver Wh Sales seed exists and the silver day-book families are outside this study's Scope.
- **F1 fine refresh on `nBillProfit`:** `TR_WH_SALE.cs:17995 {{Kr Fine Update Please ReOpen Voucher .....}}` is named
  in the keyboard case only to prove it is not ported as an unscoped update; its business effect belongs to another
  work package.
