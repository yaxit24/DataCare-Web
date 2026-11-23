# WP-41 family 2 study — bill tax, CGST/SGST/IGST split, HSN and round-off (Fnv)

This study gives the exact desktop methods a later packet must copy into
`web/scripts/desktop-oracle/tax-hsn/Oracle.cs` (LITE-MASTER-PLAN.md §6 O2, family 2). Family 1 already copied
`TR_SALE.CommPassTotal` (TR_SALE.cs:9525-11891 {{private void CommPassTotal()}}) into
`web/scripts/desktop-oracle/sales-line/Oracle.cs`, where `MSG_TOT_FILL` and `BILL_TOTAL` are no-op stand-ins
(header comment, lines 16-24 of that file). Family 2 fills them in. Every line range below was opened in this
session; quotes are copied from the decompiled source.

Two forms carry the tax arithmetic:

- **TR_SALE** (retail Sales, 21586 lines): one bill-level tax percent, tax computed on the bill, CGST/SGST/IGST
  split only at save. Dispatch: MDI_FORM.cs:7922 {{if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)}}
  chooses TR_SALE_HM, else MDI_FORM.cs:7933 {{TR_SALE tR_SALE = new TR_SALE();}}.
- **TR_SL_EBILL** (E Invoice / E CrntNote, 9954 lines): per-line tax code and per-line IGST/CGST/SGST with
  half-tax rounding. Dispatch: MDI_FORM.cs:7942-7946 {{case "E Invoice":}} → `TR_SL_EBILL`.

TR_SALE itself contains **no HSN lookup and no per-line tax amount**: the only GST split is the header split at
save (section 7). HSN appears only in TR_SL_EBILL's e-invoice JSON payload (section 13).

## Methods

### 1. TR_SALE.MSG_TOT_FILL — TR_SALE.cs:9078-9126 {{private void MSG_TOT_FILL()}}

Sums every sale-grid row into the totals grid `MSG_TOT` row 0. Guarded by `UpDown`
(TR_SALE.cs:9082 {{if (!UpDown)}}). Clears all total cells, writes the label
(TR_SALE.cs:9092 {{mSG_TOT[0, 6] = "Total :";}}), then loops rows 1..MSG.Rows-1. **Each accumulation is wrapped
in `Strings.Format` at the column's display precision, so the running total is re-rounded half-up after every
row** — not one final rounding. Tax-relevant columns: 23 ITM_AMT, 27 LBR_AMT, 28 GHT_AMT, 29 OTH_AMT, 35 TOT_AMT,
37 NET_AMT, all `"0.00"`; e.g. column 37:
TR_SALE.cs:9111 {{Conversion.Val(mSG_TOT[0, 37]) + Conversion.Val(MSG[DC_Main.M, 37]))), "0.00");}}.
Pieces (col 11) use `"0"` (TR_SALE.cs:9097 {{Conversion.Val(MSG[DC_Main.M, 11]))), "0");}}), weights use
`"0.000"` (TR_SALE.cs:9098 {{Conversion.Val(MSG[DC_Main.M, 10]))), "0.000");}}).
Ends with the value-change detector
TR_SALE.cs:9123 {{NewValTot = Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 43]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG_TOT[0, 27]);}}.
Called from CommPassTotal (TR_SALE.cs:10339 {{MSG_TOT_FILL();}}), CLEAR_DATA (TR_SALE.cs:14160 {{MSG_TOT_FILL();}}),
BtnSave_Click (TR_SALE.cs:15089 {{MSG_TOT_FILL();}}), DISPLAY_DATA (TR_SALE.cs:14659 {{MSG_TOT_FILL();}}) and
NetAmtChange (TR_SALE.cs:18512 {{MSG_TOT_FILL();}}).

### 2. TR_SALE.BILL_TOTAL — TR_SALE.cs:19189-19448 {{private void BILL_TOTAL()}}

The bill-level tax and round-off engine. In order:

1. **Net** (row 0): `Math.Round` of the summed line NET_AMT at `MsTotAmtRof`, then Format `"0.00"`:
   TR_SALE.cs:19192 {{mSG2_TOTAL[0, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 37]), DC_Main.MsTotAmtRof), "0.00");}}.
2. **Discount amount** (row 1): computed on the **labour total** MSG_TOT[0,27], Format only (half-up, no Math.Round):
   TR_SALE.cs:19195 {{mSG2_TOTAL[1, 3] = Strings.Format((object)(Conversion.Val(MSG_TOT[0, 27]) * Conversion.Val(mSG2_TOTAL[1, 2]) / 100.0), "0.00");}}.
3. **Tax** (row 2), only when net+disc or the rate changed
   (TR_SALE.cs:19197 {{Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[1, 3]) != OldNetAmt}}):
   TR_SALE.cs:19202 {{Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");}}.
   So tax = (rounded net − discount) × rate / 100, `Math.Round` at `MsTaxRof` (half-to-even on the double), then
   Format `"0.00"` (half-up again). `OldNetAmt` is set to net+disc (TR_SALE.cs:19199 {{OldNetAmt = Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[1, 3]);}})
   and `OldTcsPrc` to the sentinel 111 (TR_SALE.cs:19201 {{OldTcsPrc = 111.0;}}).
4. **TCS** (row 3): auto only in Add mode, party ≠ cash `00045`, registration ≠ `VS315NBBU`, and
   `AcTcsAmt + net + tax − disc > 5000000`
   (TR_SALE.cs:19206 {{AcTcsAmt + (Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3])) - Conversion.Val(mSG2_TOTAL[1, 3]) > 5000000.0}}).
   Looks up TAX_MAST code `'20'` only when `FormBookType = "T"`
   (TR_SALE.cs:19212 {{AND TAX_CODE = '20'";}}), reads its TAX_PRC through `Fnv`
   (TR_SALE.cs:19221 {{double num = DC_Main.Fnv(ref Value);}}), prorates the threshold excess
   (TR_SALE.cs:19229 {{double num3 = 5000000.0 - AcTcsAmt;}}) and rounds whole rupees:
   TR_SALE.cs:19234 {{Math.Round(num4 * Conversion.Val(mSG2_TOTAL[3, 2]) / 100.0, 0), "0.00");}}.
   Manual TCS percent changes take the else branch
   TR_SALE.cs:19254 {{(Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[3, 2]) / 100.0, 0), "0.00");}}.
5. **TDS vs Rof** (row 4): when `MsSlTdsTax = "Y"`
   (TR_SALE.cs:19261 {{if (Operators.CompareString(DC_Main.MsSlTdsTax, "Y", false) == 0)}}) row 4 is TDS =
   TR_SALE.cs:19265 {{Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[4, 2]) / 100.0, 0), "0.00");}}.
   Otherwise row 4 is the **operator-typed "Rof Amt"** (label TR_SALE.cs:18081 {{mSG2_TOTAL[4, 0] = "Rof Amt : ";}});
   BILL_TOTAL never computes it.
6. **Bill total** (row 5): TDS mode subtracts TDS:
   TR_SALE.cs:19274 {{Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]) - Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]), DC_Main.MsTotAmtRof), "0.00");}}.
   Registration `HM407NEKU` rounds at 1 digit
   (TR_SALE.cs:19278 {{- Conversion.Val(mSG2_TOTAL[1, 3]), 1), "0.00");}}). Default **adds** the typed Rof row:
   TR_SALE.cs:19282 {{Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]) + Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]), DC_Main.MsTotAmtRof), "0.00");}}.
   The round-off is therefore the `Math.Round` at `MsTotAmtRof` plus whatever the operator typed in row 4.
7. Points block (rows 14/15, Enterprise only, `MsSoftType = "E"` and `PointMemb` non-empty):
   TR_SALE.cs:19284-19313 {{if (((Operators.CompareString(EntryMode, "A", false) == 0) & (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && Operators.CompareString(PointMemb, "", false) != 0)}} — reads POINT_MAST/POINT_DATA; out of Lite scope.
8. Advances: row 8 col 3 = sum of MSG_ORD col 2
   (TR_SALE.cs:19321 {{Conversion.Val(mSG2_TOTAL[8, 3]) + Conversion.Val(MSG_ORD[DC_Main.M, 2])}}), row 8 col 1 =
   sum of MSG_CRNT col 2 (TR_SALE.cs:19329 {{Conversion.Val(mSG2_TOTAL[8, 1]) + Conversion.Val(MSG_CRNT[DC_Main.M, 2])}}).
9. Old gold/silver (rows 9/10) only when `MCo_BookType = "M"`, split by MSG_OLD col 14 = `"G"`
   (TR_SALE.cs:19343 {{if (Operators.CompareString(MSG_OLD[DC_Main.M, 14], "G", false) == 0)}}), summing cols 6 and 13.
10. Cash party `00045` special case computes Cash Paid (row 13) with `MsAllRofRemove` choosing 2 vs 0 digits
    (TR_SALE.cs:19364 {{if (Operators.CompareString(DC_Main.MsAllRofRemove, "Y", false) == 0)}},
    TR_SALE.cs:19370 {{Math.Round(Conversion.Val(mSG2_TOTAL[9, 3]) + Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[5, 3]), 0), "0.00");}}).
11. **Outstanding** (row 15): total minus every tender, e.g.
    TR_SALE.cs:19390 {{mSG2_TOTAL[15, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[12, 1])}} (Format `"0.00"`, no Math.Round).
12. Customer balance: `CustClAmt = CustOpAmt − Os`
    (TR_SALE.cs:19417 {{CustClAmt = CustOpAmt - Conversion.Val(mSG2_TOTAL[15, 3]);}}) and the label
    TR_SALE.cs:19434 {{LClAmt.Text = Strings.Format((object)CustClAmt, "0.00") + " : Cr Amt";}}.

### 3. DC_Main.Fnv — DC_Main.cs:2088-2103 {{public static double Fnv(ref object Value)}}

`public static double Fnv(ref object Value)`: DBNull → 0
(DC_Main.cs:2090 {{if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(Value)))}}), null → 0, empty string → 0,
else DC_Main.cs:2102 {{return Conversion.Val(Value.ToString());}}. The `ref` never changes the value; callers
write the same object back. Tax call sites: default tax rate
(TR_SALE.cs:14179 {{double num = DC_Main.Fnv(ref Value);}}), reopen KASAR_AMT/BILL_OS/OLD_GL
(TR_SALE.cs:14296 {{double num = DC_Main.Fnv(ref Value);}}), TCS rate lookup
(TR_SALE.cs:19221 {{double num = DC_Main.Fnv(ref Value);}}). Family 1 already copied Fnv verbatim.

### 4. Tax-inclusive back-calculation (inside CommPassTotal, already copied by family 1)

`digits`/`digits2` start at 0 (TR_SALE.cs:10343 {{digits = 0;}}) and become 2 only for registration `DM035NPDM`
or `MsAllRofRemove = "Y"` (TR_SALE.cs:10351 {{(Operators.CompareString(DC_Main.SSRegSrNo, "DM035NPDM", false) == 0) | (Operators.CompareString(DC_Main.MsAllRofRemove, "Y", false) == 0)}},
TR_SALE.cs:10358 {{digits = 2;}}). When the line tax percent (col 36) is non-zero, line NET_AMT (col 37) is
back-calculated from the tax-inclusive TOT_AMT (col 35):
TR_SALE.cs:11264 {{val[val.Row, 37] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 35]) / (Conversion.Val(val[val.Row, 36]) + 100.0) * 100.0, digits), "0.00");}}
and again after a tax-percent edit (TR_SALE.cs:11614 {{Math.Round(Conversion.Val(val[val.Row, 35]) / (Conversion.Val(val[val.Row, 36]) + 100.0) * 100.0, digits), "0.00");}}).
With zero tax, col 37 = col 35 (TR_SALE.cs:11570 {{val[val.Row, 37] = Strings.Format((object)Conversion.Val(val[val.Row, 35]), "0.00");}}).
The operator edits col 36 through TEXT_ENTRY (TR_SALE.cs:11588 {{val[val.Row, 36] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");}}).
CommPassTotal ends by calling BILL_TOTAL (TR_SALE.cs:11871 {{BILL_TOTAL();}}).

### 5. Tax entry on the totals grid — TR_SALE.cs:18128-18253 {{private void MSG2_TOTAL_EnterCell(object sender, EventArgs e)}} and 18522-19187

`MSG2_TOTAL_EnterCell` (18128-18212) makes rows 0/5/15 read-only
(TR_SALE.cs:18195 {{if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 5) | (mSG2_TOTAL.Row == 15))}}).
`MSG2_TOTAL_LeaveCell` (18214-18253) commits the editor with Format `"0.00"` and calls BILL_TOTAL
(TR_SALE.cs:18244 {{mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY_2.Text), "0.00");}}).
`TEXT_ENTRY_2_KeyDown` (18522-19187) resolves the tax name on row 2 against TAX_MAST `SR_NO = 0`
(TR_SALE.cs:18664 {{AND SR_NO = 0 AND TAX_NAME = '" + TEXT_ENTRY_2.Text + "'}}); on no match it opens MS_HELP
with all rates (TR_SALE.cs:18668 {{AND A.SR_NO = 0 ORDER BY A.TAX_CODE}}), and an empty pick means
TR_SALE.cs:18687 {{TEXT_ENTRY_2.Text = "TAX FREE";}} with rate `"0.00"` and code `"00"`
(TR_SALE.cs:18690 {{mSG2_TOTAL[mSG2_TOTAL.Row, 4] = "00";}}). A matched name stores
TR_SALE.cs:18700 {{mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"])), "0.00");}}.
Row 3 (TCS) lists only codes `('20','00')` (TR_SALE.cs:18732 {{AND TAX_CODE IN ('20','00') AND A.SR_NO = 0 ORDER BY A.TAX_CODE}});
row 4 (TDS) only `('25','00')` (TR_SALE.cs:18798 {{AND TAX_CODE IN ('25','00') AND A.SR_NO = 0 ORDER BY A.TAX_CODE}}).
Row labels: TR_SALE.cs:18073 {{mSG2_TOTAL[2, 0] = "Tax Amt : ";}}.

### 6. Defaults and reopen — CLEAR_DATA 13993-14224, DISPLAY_DATA 14226-14855

CLEAR_DATA resets `OldTaxPrc` (TR_SALE.cs:14129 {{OldTaxPrc = 0.0;}}), defaults the party to cash and
TR_SALE.cs:14143 {{AcGstType = "L";}}. When the book is a transaction book or estimate-tax is on
(TR_SALE.cs:14168 {{(Operators.CompareString(FormBookType, "T", false) == 0) | (Operators.CompareString(DC_Main.MsTaxWithEstmate, "Y", false) == 0)}})
it loads the company default tax code (TR_SALE.cs:14170 {{AND TAX_CODE = '" + DC_Main.MsTaxCode + "'"}})
and writes the rate via Fnv (TR_SALE.cs:14181 {{mSG2_TOTAL[2, 2] = Strings.Format((object)num, "0.00");}}).
DISPLAY_DATA restores on reopen: TR_SALE.cs:14248 {{AcGstType = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_GST_TYPE"], (object)""));}},
TR_SALE.cs:14254 {{MSG2_TOTAL[2, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"]), "0.00");}},
TR_SALE.cs:14256 {{MSG2_TOTAL[2, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_AMT"]), "0.00");}},
and in non-TDS mode TR_SALE.cs:14275 {{MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ROF_AMT"]), "0.00");}}.

### 7. Save-time split and apportionment — BtnSave_Click (TR_SALE.cs:14885-16298 {{private void BtnSave_Click(object sender, EventArgs e)}})

SL_DATA header: TR_SALE.cs:15205 {{dataRow3["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);}},
TR_SALE.cs:15225 {{dataRow3["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);}};
ROF_AMT is 0 in TDS mode (TR_SALE.cs:15211 {{dataRow3["ROF_AMT"] = 0;}}) else the typed row 4
(TR_SALE.cs:15218 {{dataRow3["ROF_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);}}).
**The CGST/SGST/IGST split** (TR_SALE.cs:15276-15297 {{dataRow3["AC_GST_TYPE"] = AcGstType;}}): store
TR_SALE.cs:15276 {{dataRow3["AC_GST_TYPE"] = AcGstType;}}; when tax ≠ 0 and
TR_SALE.cs:15279 {{if (Operators.CompareString(AcGstType, "I", false) == 0)}} →
TR_SALE.cs:15281 {{dataRow3["IGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]);}} with SGST/CGST 0; otherwise
TR_SALE.cs:15288 {{dataRow3["SGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;}} and
TR_SALE.cs:15289 {{dataRow3["CGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;}} — **two equal unrounded
halves** (₹1.01 → 0.505 + 0.505). Zero tax → all three 0 (TR_SALE.cs:15294-15296 {{dataRow3["IGST_TAX"] = 0;}}).
SL_DETL keeps only the percent and net: TR_SALE.cs:15437 {{dataRow4["TAX_PRC"] = Conversion.Val(mSG[DC_Main.i, 36]);}},
TR_SALE.cs:15438 {{dataRow4["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 37]);}}. TR_SALE never writes
ITM_IGST_AMT/ITM_CGST_AMT/ITM_SGST_AMT (no occurrence in the file).
**After commit**, IT_TAX_AMT is apportioned from the header, per detail row:
TR_SALE.cs:16153-16157 {{Operators.DivideObject(Operators.MultiplyObject(dataTable7.Rows[num21]["NET_AMT"], DC_Main.Rshlp.Rows[0]["TAX_AMT"]), DC_Main.Rshlp.Rows[0]["NET_AMT"])}}
inside `Math.Round(..., 2)` then Format `"0.000"`
(TR_SALE.cs:16157 {{}, (string[])null, (Type[])null, (bool[])null)), "0.000"));}}), written by
TR_SALE.cs:16158 {{UPDATE SL_DETL SET IT_TAX_AMT = }}. Rows with zero NET_AMT are skipped
(TR_SALE.cs:16151 {{if (Operators.ConditionalCompareObjectNotEqual(dataTable7.Rows[num21]["NET_AMT"], (object)0, false))}});
if header tax or net is 0, all IT_TAX_AMT are zeroed (TR_SALE.cs:16164 {{UPDATE SL_DETL SET IT_TAX_AMT = 0}}).
IT_DISC_AMT is apportioned the same way (TR_SALE.cs:16182-16187 {{Operators.DivideObject(Operators.MultiplyObject(dataTable7.Rows[num21]["NET_AMT"], DC_Main.Rshlp.Rows[0]["DISC_AMT"]), DC_Main.Rshlp.Rows[0]["NET_AMT"])}}).
Note the apportionment does not force the rows to sum to the header.

### 8. Party GST type and TCS history — tAcCode_KeyDown (TR_SALE.cs:17340-17847 {{private void tAcCode_KeyDown(object sender, KeyEventArgs e)}})

`AcGstType` comes from AC_MAST.AC_GST_TYPE
(TR_SALE.cs:17775 {{AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));}}).
`AcTcsAmt` is the party's year-to-date TCS-base debit sum:
TR_SALE.cs:17787 {{SELECT AC_CODE,SUM(DR_AMT)As TcsDr FROM AC_DATA}}, stored
TR_SALE.cs:17791 {{AcTcsAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TcsDr"]), "0.00"));}}.

### 9. TR_SL_EBILL.CommPassTotal — TR_SL_EBILL.cs:4714-5842 {{private void CommPassTotal()}} (per-line tax, half-tax rounding)

Column constants: cTaxableAmt=22, cTaxPrc=25, cIgstAmt=26, cCgstAmt=27, cSgstAmt=28, cNetAmt=29
(TR_SL_EBILL.cs:386-400 {{private const int cTaxableAmt = 22;}}). Taxable amount (col 22) is
labour+other+item (TR_SL_EBILL.cs:5769 {{val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 13])), "0.00");}}),
or MRP when set (TR_SL_EBILL.cs:5780 {{val[val.Row, 22] = Strings.Format((object)Conversion.Val(val[val.Row, 19]), "0.00");}}),
or item+other when gross is 0 (TR_SL_EBILL.cs:5795 {{val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 18])), "0.00");}}),
or the typed value (TR_SL_EBILL.cs:5672 {{val[val.Row, 22] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");}}).
Tax runs only when taxable ≠ 0 and rate ≠ 0
(TR_SL_EBILL.cs:5814 {{if ((Conversion.Val(val[val.Row, 22]) != 0.0) & (Conversion.Val(val[val.Row, 25]) != 0.0))}}).
Interstate (`tAcType.Text = "I"`, TR_SL_EBILL.cs:5110 {{if (Operators.CompareString(tAcType.Text, "I", false) == 0)}}):
TR_SL_EBILL.cs:5102 {{val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 22]) * Conversion.Val(val[val.Row, 25]) / 100.0, DC_Main.MsTaxRof), "0.00");}}.
Local: **each half is rounded separately at MsTaxRof** —
TR_SL_EBILL.cs:5407 {{val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 22]) * (Conversion.Val(val[val.Row, 25]) / 2.0) / 100.0, DC_Main.MsTaxRof), "0.00");}} (CGST)
and TR_SL_EBILL.cs:5403 {{val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 22]) * (Conversion.Val(val[val.Row, 25]) / 2.0) / 100.0, DC_Main.MsTaxRof), "0.00");}} (SGST).
Line grand total (col 29) rounds half-to-even to whole rupees:
TR_SL_EBILL.cs:5431 {{val[val.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 26]) + Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 28]), 0), "0.00");}}.
Ends with BILL_TOTAL (TR_SL_EBILL.cs:5823 {{BILL_TOTAL();}}). The catch clause has the same ILSpy exception-filter
shape family 1 rewrote (TR_SL_EBILL.cs:5827 {{catch (object obj11) when (obj11 is Exception && num3 != 0 && num == 0)}}).
The line tax code is looked up by TAX_CODE, not HSN
(TR_SL_EBILL.cs:6412 {{Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '" + TEXT_ENTRY.Text + "'}}),
rate stored at TR_SL_EBILL.cs:6439 {{mSG[mSG.Row, 25] = Strings.Format(RuntimeHelpers.GetObjectValue(dataView[0]["TAX_PRC"]), "0.00");}}.
`tAcType` defaults `"L"` (TR_SL_EBILL.cs:6895 {{tAcType.Text = "L";}}) and is read from AC_MAST
(TR_SL_EBILL.cs:8408 {{tAcType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));}}).

### 10. TR_SL_EBILL totals — MSG_TOT_FILL 4341-4396, BILL_TOTAL 9062-9177

MSG_TOT_FILL sums cols 22/26/27/28/29 with per-row Format `"0.00"`
(TR_SL_EBILL.cs:4376 {{Conversion.Val(mSG_TOT[0, 26]) + Conversion.Val(MSG[DC_Main.M, 26]))), "0.00");}}).
BILL_TOTAL copies the sums to rows 0-3
(TR_SL_EBILL.cs:9066 {{mSG2_TOTAL[1, 3] = Strings.Format((object)Conversion.Val(MSG_TOT[0, 26]), "0.00");}};
labels TR_SL_EBILL.cs:8620-8622 {{mSG2_TOTAL[1, 0] = "Igst Amt : ";}}), adds TCS (same 5,000,000 rule,
TR_SL_EBILL.cs:9076-9127 {{AcTcsAmt + (Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[1, 3])) - Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[3, 3]) > 5000000.0}}),
total = line-net sum + TCS (TR_SL_EBILL.cs:9128 {{mSG2_TOTAL[6, 3] = Strings.Format((object)(Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(mSG2_TOTAL[4, 3])), "0.00");}}),
and here **Rof (row 5) is derived**, the residual of total minus net/TCS/taxes:
TR_SL_EBILL.cs:9129 {{mSG2_TOTAL[5, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[6, 3]) - (Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[4, 3])}}.
TDS rounds whole rupees on the taxable sum (TR_SL_EBILL.cs:9133 {{Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) * Conversion.Val(mSG2_TOTAL[7, 2]) / 100.0, 0), "0.00");}}).
Save writes the three heads separately:
TR_SL_EBILL.cs:7532 {{dataRow2["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]) + Conversion.Val(MSG2_TOTAL[2, 3]) + Conversion.Val(MSG2_TOTAL[3, 3]);}},
TR_SL_EBILL.cs:7534 {{dataRow2["CGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]);}},
TR_SL_EBILL.cs:7539 {{dataRow2["ROF_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);}},
and per line TR_SL_EBILL.cs:7679 {{dataRow3["ITM_IGST_AMT"] = Conversion.Val(mSG[DC_Main.i, 26]);}} (27/28 at 7680-7681).

### 11. Settings load — MS_OPNCOMP.cs, UT_SETTING.cs, UT_SETTING_MAIN.cs

From CO_SET (MS_OPNCOMP.cs:657 {{SELECT * From CO_SET WHERE CO_CODE = '}}):
`MsTaxRof = (int)Math.Round(Fnv(TAX_ROF))` (MS_OPNCOMP.cs:668-671 {{DC_Main.MsTaxRof = (int)Math.Round(a);}}),
clamped: >5 → 2 (MS_OPNCOMP.cs:741-743 {{DC_Main.MsTaxRof = 2;}}). **A blank TAX_ROF therefore gives 0 digits**
(Fnv → 0; the field initialiser is DC_Main.cs:303 {{public static int MsTaxRof = 0;}}).
`MsTaxCode` (MS_OPNCOMP.cs:704 {{DC_Main.MsTaxCode = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));}}),
`MsAllRofRemove` (MS_OPNCOMP.cs:717 {{["ALL_ROF_REMOVE"]}}), blank → "N" (MS_OPNCOMP.cs:929-931 {{DC_Main.MsAllRofRemove = "N";}}).
From CO_SET_NEW (MS_OPNCOMP.cs:948 {{SELECT * From CO_SET_NEW WHERE CO_CODE = '}}):
`MsSlTdsTax` ← SL_TDS_TAX (MS_OPNCOMP.cs:971 {{["SL_TDS_TAX"]}}),
`MsTotAmtRof` ← TOT_AMT_ROF (MS_OPNCOMP.cs:991 {{DC_Main.MsTotAmtRof = Conversions.ToInteger(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TOT_AMT_ROF"], (object)""));}}),
≥4 → 0 (MS_OPNCOMP.cs:1180-1182 {{DC_Main.MsTotAmtRof = 0;}}),
`MsTaxWithEstmate` ← ESTMATE_TAX, blank → "N" (MS_OPNCOMP.cs:992 {{["ESTMATE_TAX"]}}, 1184-1186).
`ALL_ROF_REMOVE = "Y"` forces item-rate/labour/total/tax all to 2
(MS_OPNCOMP.cs:1297-1303 {{DC_Main.MsTotAmtRof = 2;}}).
Settings screens: UT_SETTING.cs:4933-4935 {{UPDATE CO_SET SET TAX_ROF = }} /
{{DC_Main.MsTaxRof = checked((int)Math.Round(Conversion.Val(cboTaxRof.Text)));}} with message
UT_SETTING.cs:4936 {{Gst Tax Roundof Set....}};
UT_SETTING_MAIN.cs:9197-9199 {{UPDATE CO_SET_NEW SET TOT_AMT_ROF = '}} /
{{DC_Main.MsTotAmtRof = Conversions.ToInteger(Strings.Mid(cboBilTotRof.Text, 1, 1));}} — the same click also writes
ITM_RATE_ROF (UT_SETTING_MAIN.cs:9201 {{UPDATE CO_SET SET ITM_RATE_ROF = '}}); the ALL_ROF_REMOVE toggle forces the
same 2s and exits (UT_SETTING_MAIN.cs:8824-8831 {{DC_Main.MsTaxRof = 2;}}).

### 12. Ledger tax split — Ac_Tax.Sales_GST (Ac_Tax.cs:77-105 {{public static void Sales_GST(string MsBook, string MsVchNo)}})

After save, TAX_DATA rows are built from SL_DATA by TAX_MAST component: SGST half when local
(Ac_Tax.cs:92 {{A.TAX_AMT/2}}; condition Ac_Tax.cs:92 {{C.SR_NO = 1 AND D.AC_GST_TYPE <> 'I'}}), CGST half
(Ac_Tax.cs:94 {{C.SR_NO = 2 AND D.AC_GST_TYPE <> 'I'}}), IGST full
(Ac_Tax.cs:96 {{C.SR_NO = 3 AND D.AC_GST_TYPE = 'I'}}). The split here is `TAX_AMT/2` in SQL, again unrounded.

### 13. HSN — only in the e-invoice payload (TR_SL_EBILL)

No HSN→rate table exists in these forms; the rate always comes from TAX_MAST. HSN is carried per item for the
e-invoice JSON: service HSNs flip `isServc`
(TR_SL_EBILL.cs:9432-9434 {{isServc = "Y";}}; the list is 9997/9972/9968/998892/997212 on line 9432),
TR_SL_EBILL.cs:9442 {{HsnCd = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["HSN_CODE"])),}},
and the rate sent is the saved SL_DETL.TAX_PRC
(TR_SL_EBILL.cs:9451 {{GstRt = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["TAX_PRC"])),}}).
Blank HSNs are backfilled by item type: gold/silver → 7113, HM → 9997
(TR_SL_EBILL.cs:9813 {{UPDATE ITEM_MAST SET HSN_CODE = '7113'}}).

### 14. Out of Lite scope: NetAmtChange (TR_SALE.cs:18282-18520 {{private void NetAmtChange()}})

F1 on the discount cell redistributes a typed net change across lines; only Advanced/Enterprise
(TR_SALE.cs:18287 {{(Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}}),
else the message TR_SALE.cs:18517 {{This Function Not Working in Your Software Virson Please Upgrad Advance or Enterprise Then Try}}.
Its tax step re-derives line nets whole-rupee:
TR_SALE.cs:18430 {{Math.Round(Conversion.Val(mSG2[DC_Main.X, 35]) / (Conversion.Val(MSG2_TOTAL[2, 2]) + 100.0) * 100.0, 0), "0.00");}}.

## Inputs

Every value a vector must supply (grid cells are strings; `Val` reads them):

| Input | Read at |
|---|---|
| MSG rows, cols 10-14,17,20,23,27,28,29,30,35,37,38,40,42,43,45,48,50,51,53 (summed) | TR_SALE.cs:9097-9119 {{Conversion.Val(MSG[DC_Main.M, 37]))), "0.00");}} |
| MSG_TOT[0,37] (bill net base), MSG_TOT[0,27] (discount base = labour total) | TR_SALE.cs:19192 {{Conversion.Val(MSG_TOT[0, 37]), DC_Main.MsTotAmtRof}} / 19195 {{Conversion.Val(MSG_TOT[0, 27]) * Conversion.Val(mSG2_TOTAL[1, 2])}} |
| MSG2_TOTAL[1,2] disc %, [2,2] tax %, [3,2] TCS %, [4,2] TDS %, [4,3] typed Rof | TR_SALE.cs:19197 {{Conversion.Val(mSG2_TOTAL[2, 2]) != OldTaxPrc}} |
| MSG2_TOTAL rows 6-15 tenders (chq, card, adv, old gold/silver, scheme, cash/UPI, cash paid, kasar, point val) | TR_SALE.cs:19390 {{Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[12, 1])}} |
| MSG_ORD col 2 / MSG_CRNT col 2 / MSG_OLD cols 6,13,14 | TR_SALE.cs:19321 {{Conversion.Val(MSG_ORD[DC_Main.M, 2])}} |
| Settings: MsTotAmtRof, MsTaxRof, MsSlTdsTax, MsAllRofRemove, MsSoftType, MCo_BookType, SSRegSrNo, MsPointCode | TR_SALE.cs:19202 {{DC_Main.MsTaxRof}} / 19261 {{DC_Main.MsSlTdsTax}} / 19333 {{if (Operators.CompareString(DC_Main.MCo_BookType, "M", false) == 0)}} |
| Form state: EntryMode, FormBookType, tAcCode, OldNetAmt, OldTaxPrc, OldTcsPrc, AcTcsAmt, CustOpAmt, PointMemb, UpDown | TR_SALE.cs:19204 {{(Operators.CompareString(EntryMode, "A", false) == 0) & (Operators.CompareString(tAcCode.Text, "00045", false) != 0)}} |
| TAX_MAST row for code '20' (TCS auto) | TR_SALE.cs:19212 {{AND TAX_CODE = '20'";}} |
| AcGstType ("L"/"I") | TR_SALE.cs:15279 {{if (Operators.CompareString(AcGstType, "I", false) == 0)}} |
| TR_SL_EBILL: cols 13,17,18,19,22,25 and tAcType; MsTaxRof | TR_SL_EBILL.cs:5814 {{(Conversion.Val(val[val.Row, 22]) != 0.0) & (Conversion.Val(val[val.Row, 25]) != 0.0)}} |
| Apportionment: SL_DATA.NET_AMT/TAX_AMT/DISC_AMT + SL_DETL.NET_AMT per row | TR_SALE.cs:16155 {{Operators.MultiplyObject(dataTable7.Rows[num21]["NET_AMT"], DC_Main.Rshlp.Rows[0]["TAX_AMT"])}} |
| Fnv: any object (DBNull, null, "", numeric text) | DC_Main.cs:2098 {{if (Operators.CompareString(Value.ToString(), "", false) == 0)}} |

## Outputs

| Output | Written at |
|---|---|
| MSG_TOT row 0 column sums (per-row re-rounded) | TR_SALE.cs:9111 {{Conversion.Val(MSG[DC_Main.M, 37]))), "0.00");}} |
| MSG2_TOTAL[0,3] net, [1,3] disc, [2,3] tax, [3,3] TCS, [4,3] TDS, [5,3] bill total | TR_SALE.cs:19282 {{Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]) + Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]), DC_Main.MsTotAmtRof), "0.00");}} |
| MSG2_TOTAL[13,3] cash paid, [15,3] OS, CustClAmt / LClAmt text | TR_SALE.cs:19434 {{LClAmt.Text = Strings.Format((object)CustClAmt, "0.00") + " : Cr Amt";}} |
| SL_DATA: TAX_CODE/TAX_PRC/TAX_AMT, TCS_*, TDS_*/ROF_AMT, TOT_AMT, AC_GST_TYPE, IGST_TAX/CGST_TAX/SGST_TAX | TR_SALE.cs:15288 {{dataRow3["SGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;}} |
| SL_DETL: TAX_PRC, NET_AMT per row; IT_TAX_AMT/IT_DISC_AMT after commit | TR_SALE.cs:16158 {{UPDATE SL_DETL SET IT_TAX_AMT = }} |
| TR_SL_EBILL line cols 26/27/28/29; SL_DATA three heads; SL_DETL ITM_IGST/CGST/SGST_AMT | TR_SL_EBILL.cs:7679 {{dataRow3["ITM_IGST_AMT"] = Conversion.Val(mSG[DC_Main.i, 26]);}} |
| TAX_DATA ledger rows (SR_NO 1/2/3) | Ac_Tax.cs:92 {{C.SR_NO = 1 AND D.AC_GST_TYPE <> 'I'}} |

## Stand-ins

Family 1's pattern (sales-line Oracle.cs, header and classes at its lines 43-135) extends directly:

- `AxMSFlexGrid` dictionary grid: reuse for MSG, MSG_TOT, MSG2_TOTAL, MSG_ORD, MSG_CRNT, MSG_OLD. Add `Clear()`,
  `Rows`, `Cols`, `FixedCols`, `RowSel`/`ColSel`, `CellWidth` no-ops where MSG2_CLEAR/EnterCell touch them; the
  arithmetic methods only need the indexer, `Rows` and `Row`.
- Text boxes: TEXT_ENTRY_2, tAcCode, tPointCode, nPointVal, nPointSlVal, nPointBal, nPointBillVal, nBillPoint,
  nTotPoint, nBillProfit, LClAmt, LOpAmt — plain `{ Text }` stand-ins; record LClAmt text as an output.
- `DC_Main` statics: MsTotAmtRof, MsTaxRof, MsSlTdsTax, MsAllRofRemove, MsSoftType, MCo_BookType, MCo_code,
  SSRegSrNo, MsPointCode, MsBillProfit, MCo_UserType, plus the loop counters M, i, X the methods use
  (TR_SALE.cs:9086 {{DC_Main.M = 1;}}).
- Form fields: UpDown, EntryMode, FormBookType, PointMemb, OldNetAmt, OldTaxPrc, OldTcsPrc, AcTcsAmt, CustOpAmt,
  CustClAmt, NewValTot, AcGstType, RowChang, chkPointMemb (false).
- Database lookups → supplied DataTables: TAX_MAST (code '20' for TCS; the default MsTaxCode row), POINT_MAST /
  POINT_DATA (only reached when MsSoftType="E" and PointMemb≠""; vectors keep PointMemb="" so an empty table
  suffices), AC_DATA aggregate (supply AcTcsAmt directly as a number). `OpenRecordSetDc` returns the supplied table.
- `Interaction.MsgBox` recorder, `Color`/`Control` no-ops for the LClAmt colouring
  (TR_SALE.cs:19435 {{((Control)LClAmt).ForeColor = Color.Blue;}}).
- Real .NET keeps `Math.Round`, `Strings.Format`, `Conversion.Val`, `Information.IsDBNull` — that is the point of
  the oracle; do not stand them in.
- Cannot be faked meaningfully: nothing blocking. The Enterprise points branch and the MS_HELP dialog are UI; skip
  via settings (PointMemb="", and drive tax rates by writing MSG2_TOTAL cells directly instead of the KeyDown help
  flow). The save-time split and apportionment are blocks inside BtnSave_Click, not standalone methods: copy the
  cited line ranges into named helpers with the range in a comment, as family 1 did for Fnv.

## Web counterparts

- `web/packages/core/src/calc.ts:243` `gstSplit` — equal unrounded halves local, full IGST inter; matches the
  TR_SALE header split (its comment cites the same desktop lines).
- `web/packages/core/src/calc.ts:281` `billTotals` — net→disc→tax→split→round-off→total; derives roundOff as
  total−preRound (desktop TR_SALE instead takes a typed Rof row and rounds the total).
- `web/packages/core/src/money.ts:30` `round` (half-up, for Strings.Format sites), `:38` `roundHalfEven`,
  `:74` `dotNetRoundDouble` (scaled-double half-even, no tolerance — the Math.Round semantics).
- `web/packages/core/src/roundingPolicy.ts:112` `resolveRoundingPolicy` — TAX_ROF≤5, TOT_AMT_ROF≤3,
  ALL_ROF_REMOVE forces 2; blank flags keep 2dp (desktop blank gives 0, see Gaps below).
- `web/packages/core/src/roundingPolicy.ts:64` `roundNearest` — half-even only when the flag was configured,
  with an EPSILON tolerance (differs from raw .NET InternalRound on near-midpoint doubles).
- `web/packages/core/src/roundingPolicy.ts:177` `saleLineDecimals` — the 0/2 digits rule of CommPassTotal.
- `web/packages/core/src/eBillCalc.ts:129` `calculateEBillLine` — per-line GST at `:212-220` via `mathRound2`
  (`:127`, roundHalfEven then half-up to 2dp), line net at `:224`; `:268` `calculateEBillTotals` sums the heads.
- `web/packages/core/src/vbVal.ts:8` `vbVal` — the Conversion.Val reader Fnv delegates to.
- `web/packages/core/src/saleAmount.ts` — family 1 line amounts; no tax logic.
- `web/apps/api/src/modules/sales/sales.ts:868` calls `billTotals`; `:1160-1172` computes per-line tax as
  net×rate/100 and rounds the halves for ITM_CGST_AMT/ITM_SGST_AMT (documented deviation: desktop TR_SALE leaves
  those 0 and apportions IT_TAX_AMT from the header, TR_SALE.cs:16155 {{Operators.MultiplyObject(dataTable7.Rows[num21]["NET_AMT"], DC_Main.Rshlp.Rows[0]["TAX_AMT"])}}).
- `web/apps/api/src/modules/ops/seedCompany.ts:112-120` seeds tax codes 00/10/11/12/13/14/20 = 0/3/5/12/18/28/0.1%
  and writes no rounding flags (so web defaults apply).

## Vector plan

Generate with a Node script as family 1 did (gen-vectors.mjs pattern: id, cells, settings, checks). Groups:

1. **Fnv**: DBNull, null, "", "0", "12.5 KG", "1 000", "1,000", "-3.7", "1.5e2", "ABC". Expected 0/0/0/0/12.5/1000/1/-3.7/150/0.
2. **Bill tax, every seed rate** (0, 3, 5, 12, 18, 28) × local/interstate, on nets 0, 100, 100.50, 12345.67,
   99999.99: checks [0,3], [2,3], split halves, [5,3]. Odd-paise tax (e.g. net 33.50 × 3% = 1.005) proves the
   equal-unrounded-halves rule (0.5025 + 0.5025, not 0.51/0.50).
3. **Half-tax midpoints**: taxable × rate/100 landing on exact .5 at MsTaxRof 0 (10.5→10, 11.5→12, −10.5→−10),
   and third-decimal 5s at MsTaxRof 2 (3.015, 2.675, 0.315 from 11.25×2.8/100) to expose double-scale vs exact
   decimal rounding; repeat with MsTaxRof 1, 3, 4, 5 to prove the Format-"0.00" second rounding.
4. **MsTotAmtRof 0/1/2/3** on net 100.45/100.5/100.55 with tax and typed Rof row 4 (±0.50, ±0.005); include
   ALL_ROF_REMOVE=Y (forces 2) and the HM407NEKU 1-digit branch as a settings-only variant.
5. **Zero and empty**: no rows; rows with all-zero cells; tax rate 0 with non-zero net (col 37 = col 35 path);
   discount 0 vs discount on labour total only (prove the MSG_TOT[0,27] base).
6. **Negative nets** (return-style lines in the grid): −100.50 × 3%, tax guard sign behaviour, OS row sign.
7. **TCS threshold**: AcTcsAmt 0 / 4,999,999 / 5,000,000 with net+tax−disc just below/at/above 5,000,000;
   FormBookType "T" vs "E"; code '20' present/absent; manual TCS % change (OldTcsPrc sentinel 111).
8. **TDS on/off**: MsSlTdsTax=Y subtracts row 4 and zeroes ROF_AMT; =N adds typed row 4.
9. **Multi-row accumulation**: rows whose col-37 sum has third-decimal residue (0.004+0.004+0.004) to prove
   per-row Format re-rounding in MSG_TOT_FILL; 2-3 rows for the apportionment vectors.
10. **IT_TAX_AMT apportionment**: header tax 32.61 over nets 1087/1 (drift case), equal nets, zero-net row
    skipped, header tax 0 → all zero; compare Format(Round(x,2),"0.000") output text.
11. **TR_SL_EBILL per line**: taxable 100.50 × 3% local (each half 1.5075 → Math.Round at MsTaxRof 0/2), MRP
    override (col 19), gross-zero path, inter vs local, line net .5 whole-rupee cases; bill residual Rof row 5.
12. **Tax-inclusive back-calc** (family 1 overlap, cheap to re-check): TOT_AMT 103 with rate 3 → net 100 at
    digits 0; 100.005-style residues at digits 2.

## Open questions

1. Should the oracle copy the whole TR_SL_EBILL.CommPassTotal (4714-5842, ~1130 lines, same catch-filter rewrite
   as family 1) or only the tax blocks (5672-5842 plus 5100-5118, 5401-5436)? Whole-method copying is family 1's
   proven pattern but doubles the file; the tax blocks alone need the taxable-amount branches to be meaningful.
2. Blank-flag defaults: desktop MsTaxRof/MsTotAmtRof become 0 when CO_SET.TAX_ROF / CO_SET_NEW.TOT_AMT_ROF are
   blank (MS_OPNCOMP.cs:668-671 {{DC_Main.MsTaxRof = (int)Math.Round(a);}}, 991), while
   `resolveRoundingPolicy` keeps 2dp half-up for blanks (roundingPolicy.ts:95-96, deliberate per its comment).
   The web seed writes no flags. Is the 2dp default an accepted decision, or a gap the vectors should flag?
3. `roundNearest`'s EPSILON tolerance (roundingPolicy.ts:72) vs .NET InternalRound's none: which tax sites need
   `dotNetRoundDouble` instead? The vectors in group 3 will measure it; the fix belongs to a later packet.
4. TR_SALE's typed "Rof Amt" row vs the web's derived roundOff (calc.ts:298): is the web's auto round-off a
   decided deviation for Lite, and does any Lite menu expose the desktop's typed row? Not answered by the source.
5. The per-line ITM_CGST/SGST/IGST columns the web fills (sales.ts:1160-1172) are left 0 by desktop TR_SALE;
   the sales.ts comment records a measurement on the real database. Confirm the supervisor accepts that
   deviation before family 2 vectors assert equality on those columns.
6. TAX_MAST component rows (SR_NO 1/2/3) drive Ac_Tax.Sales_GST, but TR_SALE's own split ignores them and uses
   AC_GST_TYPE only. A party with AC_GST_TYPE blank (not "L"/"I") takes the local branch
   (TR_SALE.cs:15279 {{if (Operators.CompareString(AcGstType, "I", false) == 0)}} is false) — worth one vector,
   but whether blank occurs in practice is a data question (aggregate query only, not run here).