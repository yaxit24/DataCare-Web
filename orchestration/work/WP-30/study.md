# WP-30 study: Wh Sales residuals (TR_WH_SALE)

Items studied: (1) hand-typed item-detail rows for a loose item, (2) SL_IDTL on the print, (3) fine kasar (Ksr Fine
Dr and Cr), (4) Rojmel (day book) alignment. Citations are `File.cs:line {{quote}}`; files are in
`unified/src/csharp/DataCareNext/`. Nothing here was run against a desktop runtime. Statements marked *inferred* are
not confirmed by a desktop line.

## Scope

- Menu: Transaction → Wh Sales. Form `TR_WH_SALE`, 18,008 lines (the index counts 18,008; the packet says 18,007).
- Dispatch: `MDI_FORM.cs:8040 {{case "Wh Sales":}}` and `MDI_FORM.cs:8041 {{DC_Main.CurBookHelp("WH SALES");}}`; the
  form opens only if a book was picked: `MDI_FORM.cs:8042 {{if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)}}`
  and then `MDI_FORM.cs:8044 {{TR_WH_SALE tR_WH_SALE2 = new TR_WH_SALE();}}`.
- The same class serves Rate Cut, Wh Quotation and Tour Sales (the print choice compares `FormMainBook` with "RATE CUT": `TR_WH_SALE.cs:13749-13752 {{SELECT * FROM RATE_CUT_ISU_REC WHERE CO_CODE}}`). Only the WH SALES book is in this study.
- Lite edition (`MsSoftType` "L"): the form checks it in few places. `TR_WH_SALE.cs:11136 {{if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)}}`
  makes the item-pick branch stop before the touch lookup (`TR_WH_SALE.cs:11140 {{Select * From TOUCH_MAST WHERE CO_CODE}}`);
  the item-detail grid, the Ksr Fine boxes and the day book have no Lite check, so Lite shows them as any edition does
  (*inferred*: no other "L" test exists in the 12 `MsSoftType` lines listed by the index).
  `MsSoftType` "E" and "A" gate only the BAR_DETL/MAIN_STOCK DATA_TYPE copy and the user-data audit (`TR_WH_SALE.cs:13334 {{Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0}}`, `:13380`).
- In scope: the four items above. Out of scope (listed in Gaps 12-16 only so the next worker sees them): the voucher
  list fine columns, `cboPrintfile` variants, `@AcMobile`, silver families of the day book, interest, tax and TDS rows.
- Not in the scope: negative stock (the form has none, per document 12 N228).

## Screen

Item-detail grid `MSG_IDTL` and its edit box `TEXT_IDTL` (loose and tagged issue lines):

- Position and size: `TR_WH_SALE.cs:4900 {{((Control)MSG_IDTL).Location = new Point(12, 218);}}` and
  `TR_WH_SALE.cs:4903 {{((Control)MSG_IDTL).Size = new Size(933, 85);}}`. `TEXT_IDTL` starts hidden:
  `TR_WH_SALE.cs:4899 {{((Control)TEXT_IDTL).Visible = false;}}`.
- Columns (caption → grid column), from `MSG_IDTL_CLEAR`: `TR_WH_SALE.cs:7133 {{mSG_IDTL[0, 1] = "ItCode";}}` and the lines
  7115-7286 give: 0 Sr, 1 ItCode, 2 ItName, 3 DmCode, 4 DmName, 5 DmColor, 6 DmSize, 7 DmOrigin, 8 DmRemark (or Remark),
  9 DmSfNo, 10 Pcs, 11 PcsWt, 12 KrWt (or KrgWt), 13 KrLs% (or Krg%), 14 Weight, 15 Con%, 16 P/W, 17 Rate, 18 ItAmt,
  19 Disc%, 20 DiscAmt, 21 LbrRate, 22 LbrAmt, 23 NetAmt, 24 KrCon%, 25 ConWt, 26 tagKrWt, 27 KrConWt, 28 ItType,
  29 RowSrNo, 30 OldGwt. The three last are internal (`TR_WH_SALE.cs:7115-7286 {{mSG_IDTL[0, 29] = "RowSrNo";}}`).
  Captions can be renamed from COL_MAST: `TR_WH_SALE.cs:7267 {{BOOK_NAME = 'TAG_IDTL' AND COL_NAME = '}}`.
- Column visibility: the DmCode..DmSfNo columns are shown only for edition "E": `TR_WH_SALE.cs:7137 {{if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}}`.
- Entry into the grid: after Con% (column 15) of an issue row, `TR_WH_SALE.cs:11293 {{MSG_IDTL.Row = MSG_IDTL.Rows - 1;}}`
  moves to the last grid row and `((Control)TEXT_IDTL).Focus();` focuses the box.

Fine kasar boxes (header, left and right column of the rate-cut band):

- `nFineKsrDr` caption "Ksr Fine Dr" (`TR_WH_SALE.cs:5359 {{Ksr Fine Dr}}`), at (95,483), MaxLength 10, tab index 14,
  right aligned, Honeydew: `TR_WH_SALE.cs:5256-5263 {{((Control)nFineKsrDr).Name = "nFineKsrDr";}}`.
- `nFineKsrCr` caption "Ksr Fine Cr" (`TR_WH_SALE.cs:5369 {{Ksr Fine Cr}}`), at (286,483), tab index 15:
  `TR_WH_SALE.cs:5264-5271 {{((Control)nFineKsrCr).Name = "nFineKsrCr";}}`.
- Neither box is disabled or hidden anywhere (no `Enabled`/`Visible` line mentions them), so both are always editable.
- The tot boxes `nTotFineDr` / `nTotFineCr` (captions "Tot Fine Dr", "Tot Fine Cr") include the kasar (Calculations).

## Keyboard

- Esc (`TR_WH_SALE_KeyDown`): `TR_WH_SALE.cs:13600 {{if ((int)e.KeyCode != 27)}}` then, in order: from `TEXT_ENTRY` it
  returns to the issue grid and moves on to the receive grid (`:13606-13615`); from `TEXT_IDTL` it hides the box and
  goes back to the issue grid edit: `TR_WH_SALE.cs:13625-13630 {{else if (((Control)TEXT_IDTL).Visible)}}`; from `TEXT_PR`
  to `nAcDrAmt`; from `TEXT_ENTRY_2` to `tEmpCode`; otherwise it closes the form if nothing changed:
  `TR_WH_SALE.cs:13647-13651 {{else if (OldValTot == NewValTot)}}`.
- Enter in `nFineKsrDr` and `nFineKsrCr`: format with three decimals, recompute the bill, go to the next control:
  `TR_WH_SALE.cs:16035 {{nFineKsrDr.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineKsrDr.Text)), "0.000");}}`,
  then `BILL_TOTAL();` and `SendKeys.Send("{TAB}");` (`:16036-16037`). `nFineKsrCr` is the same at `:16047`.
- Enter in `TEXT_IDTL` (column by column, `TEXT_IDTL_KeyDown`):
  - Column 1 blank returns to the issue row Con% column: `TR_WH_SALE.cs:7408 {{MSG.Col = 16;}}`.
  - Column 1 non-blank looks the code up: `TR_WH_SALE.cs:7414 {{Select * From ITEM_MAST WHERE CO_CODE = '}}`; unknown opens the help list.
  - Column 3 looks up `DM_MAST` and fills DmName and the sale rate: `TR_WH_SALE.cs:7473 {{Select * From DM_MAST WHERE CO_CODE}}`.
  - Column 11 (PcsWt) sets Weight = Pcs × PcsWt: `TR_WH_SALE.cs:7507 {{Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) * Conversion.Val(TEXT_IDTL.Text)}}`.
  - Column 13 sets Weight = KrWt × KrLs% / 100: `TR_WH_SALE.cs:7513 {{Conversion.Val(TEXT_IDTL.Text) / 100.0}}`.
  - Column 23 (NetAmt, the last one) on the last row adds a row: `TR_WH_SALE.cs:7522 {{mSG_IDTL.Rows += 1;}}`; on an earlier row it moves to the next row.
- Ctrl+D in `TEXT_IDTL` deletes the row after a question: `TR_WH_SALE.cs:7331 {{This Row Record will Removed permantley ?}}`.
- Up/Down/Left/Right in the edit boxes select all text: `TR_WH_SALE.cs:17251 {{((TextBoxBase)TEXT_IDTL).SelectionStart = 0;}}` (`TR_WH_SALE_KeyUp`, 17202-17265).
- F1 in the bill-profit box (`nBillProfit`) runs a fine refresh: `TR_WH_SALE.cs:17973-17980 {{if ((int)e.KeyCode != 112)}}` (key 112 = F1), see Rules.

## Rules

- Delete a detail row without the delete right while editing: `TR_WH_SALE.cs:7328 {{You Have No Rights.....}}`
  (condition `TR_WH_SALE.cs:7326 {{(Operators.CompareString(UserDelete, "Y", false) != 0)}}`). Focus stays on the box.
- Delete row confirmation: `TR_WH_SALE.cs:7331 {{This Row Record will Removed permantley ?}}`; after yes, `TR_WH_SALE.cs:7356 {{Record is Deleted....}}`.
- A detail row is saved only if pieces, gross weight, tag weight or net amount is non-zero: `TR_WH_SALE.cs:13175-13190 {{DtIdtl.Rows[i][10]}}`
  (the condition adds columns 10, 14, 26 and the next, one long line; it skips an empty stone row; document 12 N228 says the same).
- Save refusals that touch these items are the ones of N220 and are unchanged: `TR_WH_SALE.cs:12787 {{You Cant Save Entry Because This Party Is in Defaulter List}}`
  and `TR_WH_SALE.cs:12848 {{You Have No Rights.....}}`. A main issue line without an item code is refused in the save: `TR_WH_SALE.cs:12894 {{Please Select Item Code In Row }}` followed by the row number and ` and Try......`, then the save returns (`TR_WH_SALE.cs:12895 {{return;}}`). That test reads the issue grid (`MSG[DC_Main.i, 3]`), not `MSG_IDTL`.
- Kasar boxes carry no validation: any number, formatted `0.000`, is accepted (`TR_WH_SALE.cs:16035 {{"0.000");}}`).

## Calculations

Item-detail row (`CommPassTotal_Idtl`, `TR_WH_SALE.cs:7750-7971 {{private void CommPassTotal_Idtl(int CRow)}}`), in the order the form applies it:

1. Weight from pieces: `TR_WH_SALE.cs:7753-7756 {{Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) * Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 11])}}`
   written with `"0.000"`.
2. Tag weight (column 26) defaults to Weight: `TR_WH_SALE.cs:7758-7761 {{mSG_IDTL[CRow, 26] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 14]), "0.000");}}`.
3. ConWt = Weight × Con%: `TR_WH_SALE.cs:7762-7766 {{mSG_IDTL[CRow, 25] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 15])), "0.000");}}`.
4. KrConWt = tag weight × KrCon% when KrCon% is above zero, otherwise tag weight × Con%: `TR_WH_SALE.cs:7773-7779 {{mSG_IDTL[CRow, 27] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 26]) * Conversion.Val(mSG_IDTL[CRow, 24])), "0.000");}}`.
5. ItAmt by the rate type in column 16: blank type with weight zero and pieces non-zero → rate × pieces; blank type otherwise → rate × weight;
   type "P" → rate × pieces; any other → rate × weight. The rounding is `Math.Round(x, 0)` (banker's, to whole rupees), formatted `"0.00"`:
   `TR_WH_SALE.cs:7790-7800 {{Math.Round(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 10]), 0), "0.00"}}`.
6. LbrAmt = LbrRate × Pcs when LbrRate is non-zero: `TR_WH_SALE.cs:7811 {{mSG_IDTL[CRow, 22] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 21]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");}}`.
7. DiscAmt = round(ItAmt × Disc% / 100, 0): `TR_WH_SALE.cs:7815 {{Math.Round(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 18]) * Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 19]) / 100.0, 0), "0.00"}}`.
8. NetAmt = ItAmt − DiscAmt + LbrAmt: `TR_WH_SALE.cs:7819 {{Conversion.Val(mSG_IDTL[CRow, 18]) - Conversion.Val(mSG_IDTL[CRow, 20]) + Conversion.Val(mSG_IDTL[CRow, 22])}}`.
9. Roll-up into the issue row (`MSG`): sum of ConWt → column 16, column 17 = column 15 − column 16, sum of KrConWt → column 46,
   column 47 = column 15 − column 46, sum of NetAmt → column 37 (`"0.00"`); silver rows (ItType "S" with no ItAmt) add weight into column 28:
   `TR_WH_SALE.cs:7852 {{MSG[MSG.Row, 16] = Strings.Format((object)num3, "0.000");}}` and
   `TR_WH_SALE.cs:7877 {{MSG[MSG.Row, 37] = Strings.Format((object)num5, "0.00");}}`.

Fine kasar (`BILL_TOTAL`, `TR_WH_SALE.cs:15369-15763 {{private void BILL_TOTAL()}}`):

- `TR_WH_SALE.cs:15633 {{nTotFineDr.Text = Strings.Format((object)(TotDrFine + Conversion.Val(nAcDrFine.Text) + Conversion.Val(nFineKsrDr.Text)}}`
- `TR_WH_SALE.cs:15634 {{nTotFineCr.Text = Strings.Format((object)(TotCrFine + Conversion.Val(nAcCrFine.Text) + Conversion.Val(nFineKsrCr.Text)}}`
- Both formatted `"0.000"`; no rounding call. `nDiffFine` is `Tot Fine Dr − Tot Fine Cr` (`TR_WH_SALE.cs:15635 {{nDiffFine.Text = Strings.Format((object)(Conversion.Val(nTotFineDr.Text) - Conversion.Val(nTotFineCr.Text)), "0.000");}}`).
- Kasar does not change the stored `SL_FINE` and `PR_FINE` (`TR_WH_SALE.cs:12975-12976 {{dataRow2["SL_FINE"] = TotDrFine + Conversion.Val(MSG_TOT[0, 39]);}}`);
  it changes only `TOT_FINE_DR` / `TOT_FINE_CR` and the kasar columns.

## Lifecycle and write set

Create or edit (`BtnSave_Click`, `TR_WH_SALE.cs:12756-13520 {{private void BtnSave_Click(object sender, EventArgs e)}}`; one transaction `Module_Save.WhTran`):

1. On edit, the old rows are deleted first: `TR_WH_SALE.cs:12935 {{DELETE FROM RATE_CUT_DATA WHERE CO_CODE}}`, then RATE_CUT_ISU (`:12936`),
   SL_IDTL (`:12937 {{DELETE FROM SL_IDTL WHERE CO_CODE}}`), TEMP_BOOK_DATA (`:12940`).
2. Header RATE_CUT_DATA insert, with the kasar: `TR_WH_SALE.cs:12980 {{dataRow2["KSR_FINE_CR"] = Conversion.Val(nFineKsrCr.Text);}}`
   and `TR_WH_SALE.cs:12981 {{dataRow2["KSR_FINE_DR"] = Conversion.Val(nFineKsrDr.Text);}}`; also `TOT_FINE_CR` / `TOT_FINE_DR` at `:12978-12979`.
3. Issue rows (RATE_CUT_ISU), receive rows (RATE_CUT_REC), then SL_IDTL:
   `TR_WH_SALE.cs:13162 {{SELECT * FROM SL_IDTL WHERE CO_CODE}}`. The grid is sorted by `RowSrNo`; the line is found by `RowSrNo = MSG column 62`;
   `ISR_NO` restarts at 1 for each line. Columns written (all `TR_WH_SALE.cs:13190-13245 {{dataRow4["CO_YEAR"] = DC_Main.MCo_year;}}`): CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, HD_VCH_NO,
   VCH_DATE, AC_CODE, VCH_TYPE, INOUT_TYPE, `ENTRY_TYPE = "W"`: `TR_WH_SALE.cs:13208 {{dataRow4["ENTRY_TYPE"] = "W";}}`, BOOK_NAME,
   SR_NO (= MSG col 62), TAG_NO, VCH_SRNO (= MSG col 57), ISR_NO, IT_CODE, DM_CODE, DM_NAME, DM_COLOR, DM_SIZE, DM_ORIGIN, DM_REMARK, DM_SFNO,
   IT_PCS, IT_PCS_WT, KR_LESS_PRC, IT_GWT, KR_WT, IT_CON_PRC, IT_RATE_TYPE, IT_RATE, IT_AMT, IT_DISC_PRC, IT_DISC_AMT, IT_LBR_RATE, IT_LBR_AMT,
   IT_NET_AMT, KR_CON_PRC, IT_CON_WT, IT_TYPE, MAIN_USER. Each row is written with `DbDataAdapter.Update` one at a time.
   Note: `KR_CON_WT` (grid col 27) is read on reopen but is not in the insert list above (*inferred* from the column list; see Open questions).
4. Ledger: `TR_WH_SALE.cs:13347 {{DELETE FROM AC_DATA WHERE CO_CODE}}` then `TR_WH_SALE.cs:13349 {{Ac_Ledr.Wh_Sales_Ledr(DC_Main.MCo_Book, tVchNo.Text);}}`.
5. Day book: `TR_WH_SALE.cs:13350 {{DELETE FROM ROJ_MEL_DATA WHERE CO_CODE}}` then `Ac_Rojmel.Wh_Sales_Rojmel(DC_Main.MCo_Book, tVchNo.Text);` (`:13352`).
6. Stock: `DELETE FROM MAIN_STOCK` (`:13353`) then `Ac_Stock.Wh_Sale_Stk` (`:13355`); then `DELETE FROM DM_DATA` (`:13356`) and
   `TR_WH_SALE.cs:13358 {{Ac_Stock.Dm_Wh_Tour_Sale_Detl(DC_Main.MCo_Book, tVchNo.Text);}}`; then `Module_Save.WhTran.Commit();`.

Fine kasar posting (shared engines):

- Ledger, `Ac_Ledr.Wh_Sales_Ledr`: four AC_DATA legs. `Ac_Ledr.cs:685 {{A.VCH_NO+'27'}}` and `Ac_Ledr.cs:687 {{A.VCH_NO+'28'}}` for `KSR_FINE_CR`
  (condition `AND B.SR_NO = 12 AND A.KSR_FINE_CR <> 0`); `Ac_Ledr.cs:703 {{A.VCH_NO+'33'}}` and `Ac_Ledr.cs:705 {{A.VCH_NO+'34'}}` for `KSR_FINE_DR`.
  Party leg: sign '+' for Cr (27) and '-' for Dr (33); the slot-12 leg takes the opposite sign (28 '-', 34 '+'): `Ac_Ledr.cs:687 {{A.IT_TYPE,'-',A.KSR_FINE_CR}}`.
- Day book, `Ac_Rojmel.Wh_Sales_Rojmel`: key '07' for `KSR_FINE_DR`, '08' for `KSR_FINE_CR` on gold, '19' and '20' on silver:
  `Ac_Rojmel.cs:235 {{A.VCH_NO+'07'}}` (`AND B.SR_NO = 12 AND A.KSR_FINE_DR <> 0 AND A.IT_TYPE = 'G'`), `Ac_Rojmel.cs:237 {{A.VCH_NO+'08'}}`,
  `Ac_Rojmel.cs:259 {{A.VCH_NO+'19'}}`, `Ac_Rojmel.cs:261 {{A.VCH_NO+'20'}}`. Name is `'KSR' + ' - ' + E.AC_NAME`, `ITM_FINE` = the kasar column, sign '-' for Dr and '+' for Cr, all amounts 0.

Reopen (`DISPLAY_DATA`, `TR_WH_SALE.cs:12180-12718 {{private void DISPLAY_DATA()}}`): header kasar is shown
`TR_WH_SALE.cs:12230 {{nFineKsrCr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["KSR_FINE_CR"]), "0.000");}}`;
detail rows are read from SL_IDTL joined to ITEM_MAST for the name:
`TR_WH_SALE.cs:12588 {{SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE}}`.
The loop `TR_WH_SALE.cs:12590-12630 {{while (DC_Main.i < RsIdtl.Rows.Count)}}` rebuilds `DtIdtl`, with `ISR_NO` into column 0 and `SR_NO` into column 29.

Delete (`BtnDelete_Click`, `TR_WH_SALE.cs:13552-13595 {{private void BtnDelete_Click(object sender, EventArgs e)}}`): rights, lock date, question `TR_WH_SALE.cs:13567 {{Are You Sure To Delete This Voucher now?}}`, then
`TR_WH_SALE.cs:13569 {{INSERT INTO DELETE_DATA}}` area (audit), deletes AC_DATA (`:13581`), ROJ_MEL_DATA (`:13582`), RATE_CUT_REC (`:13589`), SL_IDTL (`:13590`),
DM_DATA (`:13585`), and ends with `TR_WH_SALE.cs:13591 {{Delete Success.}}`. Cancel (`:13868-13884`) reloads without writes.

## Print

- Right check: `TR_WH_SALE.cs:13658 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}` then `TR_WH_SALE.cs:13660 {{You Have No Print Rights.....}}`.
- Template choice: a count of RATE_CUT_ISU_REC rows picks `RateCutBill` or the book's `cboPrintfile`: `TR_WH_SALE.cs:13749-13752 {{SELECT * FROM RATE_CUT_ISU_REC WHERE CO_CODE}}`;
  the web prints `WhSalesBill` (document 12 N220). `WhHuidPrint` and the HM378NAPK path read SL_IDTL (`TR_WH_SALE.cs:13689 {{LEFT JOIN SL_IDTL AS B}}`) — not WP-30.
- The print copies the voucher into RATE_CUT_ISU_REC first (`TR_WH_SALE.cs:13682 {{DELETE}}`, insert `:13683`, `:13722`). *Inferred*: SL_IDTL is joined by the report itself.
- The report definition (not the desktop source): `web/apps/api/report-specs/WhSalesBill.spec.json`, area index 5, kind Detail, section `Section5`, fields
  `ITEM_MAST_IDTL.IT_NAME`, `SL_IDTL.IT_PCS`, `SL_IDTL.IT_GWT`, `SL_IDTL.IT_RATE`, `SL_IDTL.IT_NET_AMT` and a `Line26` rule. No Crystal parameter of the form
  is needed for them; they come from the table link.

## Rights

- Save while editing: `TR_WH_SALE.cs:12846 {{if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0)}}` → `TR_WH_SALE.cs:12848 {{You Have No Rights.....}}`.
- Delete: `TR_WH_SALE.cs:13563 {{else if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0)}}` → the same text.
- Print: above. `UserEdit`, `UserDelete`, `UserPrint` come from USER_SET: `TR_WH_SALE.cs:11512 {{Select * From USER_SET WHERE LC_CODE}}`.
- Deleting a detail row: only the delete right (`:7326`, above).

## Desktop weaknesses not to port

- SQL built by joining strings everywhere (e.g. `TR_WH_SALE.cs:13162 {{SELECT * FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code}}`). Use parameters.
- SL_IDTL is written one row at a time with a data adapter and cleared after each row (`TR_WH_SALE.cs:13245-13250 {{RsIdtl.Clear();}}`); write it in the voucher transaction as one set.
- The day book and ledger are rebuilt by whole-voucher delete then insert with `A.VCH_DATE >= opening date` queries (`Ac_Rojmel.cs:223 {{INSERT INTO ROJ_MEL_DATA}}`); keep the voucher key, never the date filter.
- The grid sort key `RowSrNo` and the lookup `MSG[M, 62]` link detail to line by a number kept in a hidden column (`TR_WH_SALE.cs:13191 {{if ((double)num7 == Conversion.Val(MSG[DC_Main.M, 62]))}}`): a stale hidden number would attach stones to the wrong line. Use an explicit line id.
- Rounding of ItAmt to rupees (`Math.Round(x, 0)`) is business behaviour, not a weakness; keep it.
- The F1 key on `nBillProfit` runs unscoped-looking updates over RATE_CUT_ISU for every line and closes the form (`TR_WH_SALE.cs:17995 {{Kr Fine Update Please ReOpen Voucher .....}}`); not part of WP-30; do not port as is.

## Web today

- `web/apps/web/app/(app)/txn/wholesale-sale/page.tsx`: renders `WholesaleVoucherForm workflow="wholesale-sale"` for WH SALES books only.
- `web/apps/web/components/WholesaleVoucherForm.tsx`: the shared form (party header, issue grid, receive grid, rate-cut band, settlement band). No item-detail panel; the Ksr fields are absent (comment at line 958).
- `web/apps/api/src/routes/wholesaleSale.ts`: `/wholesale-sales` routes and the print; `BAND_COLUMNS` lists `KSR_FINE_CR` and `KSR_FINE_DR` (lines 33-34) for reading.
- `web/apps/api/src/modules/sales/rateCut.ts` (2731 lines): `writeRateCut` writes the header, lines, AC_DATA, ROJ_MEL_DATA, MAIN_STOCK, SL_IDTL and DM_DATA in one transaction; kasar fine is 0 there (lines 1021, 2205-2206).
- `web/apps/api/src/modules/sales/wholesaleTagStones.ts` (153 lines): builds SL_IDTL and DM_DATA rows from an issued tag's BAR_IDTL stones only.
- `web/apps/api/src/modules/sales/wholesaleSaleBill.ts` (217 lines): the WhSalesBill HTML; band formulas use `KSR_FINE_*`; no SL_IDTL detail rows (line 108).
- `web/apps/api/src/modules/shared/rojmel.ts`: `buildRateCutRojmel` builds nine row types (01, 02, 03, 04, 07, 08, 13, 22, 26) from legs; 07/08 exist but are given zero.
- `web/packages/core/src/wholesaleLine.ts:372-373`: `totFineDr` and `totFineCr` omit the kasar.
- Tests: `web/apps/api/test/wholesaleSaleStones.db.test.ts`, `wholesaleSaleBill.test.ts`, `wholesaleSaveChecks.db.test.ts`, `rateCut.test.ts`, `wholesaleRateCut*.db.test.ts`.
- Browser module `web/apps/web/test/features/modules/wholesaleSale.mjs` (1355 lines): 27 cases (`entry.book-family` … `journey.outstanding-then-cash-received`).
  The helper `blocked(...)` is defined at line 45 but **never called**; there is no skipped, focused or pending case. So 27 of 27 means none is blocked.
  The cases that touch these items: `create.tag-stones` (line 1144, tag stones only), `output.print-bill` (line 1067, title and four-column band only), `formula.bankers-rounding-and-labour` (542). No case types a kasar fine, a loose item-detail row, or checks a day-book row beyond the totals.

## Gaps

Open lineage rows: G233/N220 (done), G15 follow-up N228 (the four items below), G136/N127 (Tour Sales shares the engine; unchanged). No other
open row in document 12 names TR_WH_SALE.

1. **Loose-item detail rows, entry. Missing feature.** Desktop: after Con% the cursor enters `MSG_IDTL`
   (`TR_WH_SALE.cs:11293 {{MSG_IDTL.Row = MSG_IDTL.Rows - 1;}}`), with the row rules above. Web: `wholesaleTagStones.ts:15-16` says "Deliberately not ported: the desktop's hand-typed rows for a loose item";
   the form has no panel and the request has no detail-row field. Fix: add an item-detail dialog on every issue line (Enter after Con%, Esc back, Ctrl+D row delete with the desktop question),
   and a validated `details[]` array on each issued line in the API schema.
2. **Loose-item detail rows, arithmetic. Missing feature.** Desktop: steps 1-9 of Calculations (`TR_WH_SALE.cs:7790-7800 {{Math.Round(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 10]), 0), "0.00"}}` rounding `Math.Round(...,0)`). Web: none. Fix: put `CommPassTotal_Idtl` into `@datacare/core` (kernel vectors with desktop-derived values:
   Pcs×PcsWt, rate type blank/P, Disc round-to-rupee, NetAmt) and use it on both screen and server; roll the sums into the line's columns 16/17/37/46/47 as the desktop does.
3. **SL_IDTL write for loose rows. Missing feature.** Desktop writes every non-empty grid row (`TR_WH_SALE.cs:13162-13250 {{SELECT * FROM SL_IDTL WHERE CO_CODE}}`). Web writes only tag stones (`rateCut.ts:2257`, `wholesaleTagStones.ts:45-55`, which skips a line with no tag or instance).
   Fix: build rows from the posted `details[]` as well, `ENTRY_TYPE 'W'`, `SR_NO` the line serial, `ISR_NO` restarting per line, skip empty rows, in the same transaction; keep the DM_DATA projection (`Dm_Wh_Tour_Sale_Detl`) for OTH_DETL_POSTING items from these rows.
   A write-set test must assert every column listed under Lifecycle (including the unresolved `KR_CON_WT`, see Open questions).
4. **SL_IDTL reopen and edit. Wrong result (data loss on edit).** Desktop reloads the rows from SL_IDTL at `TR_WH_SALE.cs:12588 {{SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST AS B}}`. Web: the GET route does not return detail rows (`routes/wholesaleSale.ts` has no idtl) and edit rebuilds stones from tags only,
   so a hand-typed row would vanish on the next save. Fix: return the rows on GET and re-post them on edit; case `reopen.unchanged-save` must cover a loose row.
5. **SL_IDTL under each bill line on the print. Missing feature.** Desktop report: Detail section with `SL_IDTL.IT_PCS`, `IT_GWT`, `IT_RATE`, `IT_NET_AMT` and the item name (`WhSalesBill.spec.json`, area 5). Web: `wholesaleSaleBill.ts:108` "wait for the web to write them".
   Fix: after each issue line print its detail rows (item name from ITEM_MAST, pieces, weight, rate, net amount) in the order of `ISR_NO`; add a render test with two lines and 0, 1 and 2 detail rows.
6. **Ksr Fine Dr and Cr boxes. Missing feature.** Desktop: two always-editable boxes, tab 14 and 15, format `0.000`, Enter recomputes the bill (`TR_WH_SALE.cs:16035 {{nFineKsrDr.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineKsrDr.Text)), "0.000");}}`). Web: absent (`WholesaleVoucherForm.tsx:958`). Fix: add both boxes after Ac Fine Dr/Cr in the same tab order with the same Enter behaviour.
7. **Fine kasar in the totals. Wrong result.** Desktop: `TR_WH_SALE.cs:15633-15634 {{Conversion.Val(nFineKsrDr.Text)}}` adds the kasar into Tot Fine Dr and Cr. Web: `core/src/wholesaleLine.ts:372-373` omits it and `rateCut.ts:1021` says "fine kasar not modelled: 0". Fix: add `ksrFineDr` and `ksrFineCr` to the band inputs; Os Fine and Diff follow.
8. **Fine kasar stored. Wrong result.** Desktop stores `KSR_FINE_CR` and `KSR_FINE_DR` (`TR_WH_SALE.cs:12980-12981 {{dataRow2["KSR_FINE_CR"] = Conversion.Val(nFineKsrCr.Text);}}`). Web writes 0 (`rateCut.ts:2205-2206` for the day book; the header is read by `routes/wholesaleSale.ts:33-34`). Fix: accept both on the request, persist them, return them on GET, and show them on reopen (`:12230`).
9. **Fine kasar ledger legs. Missing feature.** Desktop: AC_DATA legs 27/28/33/34 (`Ac_Ledr.cs:685-705 {{A.VCH_NO+'27'}}`). Web: `rateCut.ts:838` lists them as deferred. Fix: add the four legs with the signs above and the slot-12 account; the voucher must stay balanced (assertBalanced).
10. **Fine kasar day-book rows. Missing feature (partly built).** Desktop: rows 07/08 (gold) and 19/20 (silver) (`Ac_Rojmel.cs:235-261 {{A.VCH_NO+'07'}}`). Web: `rojmel.ts:903-925` builds 07/08, but `rateCut.ts:2205-2206` passes 0, so nothing is written; the silver pair 19/20 does not exist. Fix: pass the stored kasar; add 19/20 only if a silver Wh Sales voucher is in scope.
11. **Fine kasar on the print. Wrong result.** Desktop band uses `KSR_FINE_*` in `@RecFine` and `@IsuFine`. Web formulas are right (`wholesaleSaleBill.ts:142-143`) but always get 0 (`:106`). Fix: none beyond 8, then add a print case with a non-zero kasar.
12. **Rojmel rows for lined vouchers. Missing feature.** Desktop writes per-line fine rows `05` (issue, from RATE_CUT_ISU: `Ac_Rojmel.cs:231 {{A.VCH_NO+'05'+Str(A.SR_NO)}}`) and `06` (receive, from RATE_CUT_REC: `Ac_Rojmel.cs:233 {{A.VCH_NO+'06'+Str(A.SR_NO)}}`),
    each carrying pieces, gross, net weight, touch, wastage and fine, when `ITM_FINE <> 0 AND ITM_AMT = 0`; type `14` (`Ac_Rojmel.cs:249 {{ABS(A.SL_BILL_OS)}}`, when `SL_BILL_OS < 0`); and `27` labour (`Ac_Rojmel.cs:275 {{'LBR' + ' - ' + A.AC_NAME}}`, `SL_LBR_AMT+SL_OTH_AMT`).
    Web: `rojmel.ts` builds none of 05/06/14/27 (`rateCut.ts:2170` "Remaining alignment ... is open"). Fix: add a line-row builder for 05/06 reading the stored line rows, plus 14 and 27, with the key `voucher + type + Str(SR_NO)`.
13. **Rojmel key and name shape. Wrong result (to be confirmed).** Desktop's line key carries the line number and the name is `B.BOOK_SNAME + ' - ' + A.AC_NAME`; `rojmel.ts` comment says no rate-cut type carries a line number and that the data, not the source, was followed.
    Rule 4 of the packet says the desktop source wins. Fix: decide with the supervisor (Question 1) before changing directions; then align and prove with a row-for-row case on keys and names.
14. **Rojmel debit/credit directions. Wrong result (to be confirmed).** `rojmel.ts` states that on five of the nine types its direction is the opposite of the source ("the data is authoritative"). Same decision as item 13; the study did not re-derive each direction.
15. **Rojmel types not built: 21, 23, 24, 25, 28, 29-40 and silver 09-12, 15-18.** Desktop: `Ac_Rojmel.cs:263 {{A.VCH_NO+'21'}}` and the list at lines 263-308. Web: nine types only (`rojmel.ts:726-757`). Cheque for sale side, card, sale kasar, labour, interest, tax and TDS are missing for Wh Sales; the live data showed none in use.
    Outside the four requested items, but they decide whether "Rojmel alignment" is complete; include in the case list as blocked-with-reason until real data or a decision exists.
16. **Other N228 leftovers (out of scope):** voucher list lacks fine and purchase columns; `cboPrintfile` variants `RateCutBill`, `WhQuotation`, `WhHuidPrint`, `WhSalesImage`; `@AcMobile` formula slip; party GST number AC_GSTNO vs AC_LSTNO.
17. **Browser cases.** There is no blocked, pending or skipped case in `wholesaleSale.mjs`. Add: `create.loose-item-detail-rows`, `reopen.loose-detail-rows-return`, `edit.loose-detail-row-change`, `delete.removes-detail-rows`, `output.print-detail-under-line`,
    `keyboard.detail-grid-enter-esc-ctrl-d`, `field.ksr-fine-dr-cr`, `formula.ksr-fine-totals`, `ledger.ksr-fine-legs`, `rojmel.ksr-fine-rows`, `rojmel.lined-voucher-rows-05-06-14-27`, `output.print-kasar-fine-row`.

## Open questions

1. Rojmel directions and keys: the web follows 66 real rows of one company and says the desktop source is a later version (`rojmel.ts` comment). Which wins for 01-04, 13, 22, 26? The packet rule says the source; the earlier slice chose the data.
2. `KR_CON_WT`: reopen reads it (`TR_WH_SALE.cs:12629 {{["KR_CON_WT"]}}`) but a search of the file shows no save line that sets it (it appears only in the five grid-load lines 10145, 10997, 12629, 17047, 17873). So the desktop never stores it and reads back 0; should the web store 0 as well? Decide before the write-set test.
3. Whether the silver pair (kasar 19/20, ledger 27/28/33/34 for IT_TYPE S) must be built now: the study found no IT_TYPE 'S' Wh Sales data.
4. Whether a detail row with no item code (`MSG_IDTL` column 1) is refused: the only item-code refusal found is for the issue grid (`TR_WH_SALE.cs:12894 {{Please Select Item Code In Row }}`); the detail-row save loop (13175-13190) shows no refusal text, so such a row seems to be written with an empty `IT_CODE` (*inferred*).
5. Whether `HM437NEHP` and `HM436NEHP` (four-decimal PcsWt registrations) apply: `TR_WH_SALE.cs:7444 {{HM437NEHP}}`. They are registration-specific; N220 excluded similar checks.
