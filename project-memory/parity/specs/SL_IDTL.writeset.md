# Desktop write set — SL_IDTL (sub-detail stones/diamonds)

Source: `unified/src/csharp/DataCareNext/TR_SALE.cs:15549`–`15620`, row variable `dataRow6`, verified against its own `SELECT * FROM SL_IDTL`.

- Assigned columns: **37** (37 exist in the desktop production schema)
- Already persisted by the web: **37**
- **MISSING: 0**
- Desktop production table: present, 52 columns
- Web Prisma model: present

Implement each MISSING column from its cited expression. `MSG2_TOTAL[r,c]` = settlement grid,
`MSG_TOT[0,c]` = totals grid, `mSG4[i,c]` = item grid, `tXxx.Text` = header field.
Do not invent a value: if an expression cannot be resolved, record it in the form contract.

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_CODE` | 15589 | `tAcCode.Text` | web |
| `BOOK_NAME` | 15593 | `FormMainBook` | web |
| `CO_BOOK` | 15585 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 15582 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 15584 | `DC_Main.MCo_year` | web |
| `DM_CODE` | 15599 | `Operators.ConcatenateObject(DtIdtl.Rows[i][3], (object)"")` | web |
| `DM_COLOR` | 15601 | `Operators.ConcatenateObject(DtIdtl.Rows[i][5], (object)"")` | web |
| `DM_NAME` | 15600 | `Operators.ConcatenateObject(DtIdtl.Rows[i][4], (object)"")` | web |
| `DM_ORIGIN` | 15603 | `Operators.ConcatenateObject(DtIdtl.Rows[i][7], (object)"")` | web |
| `DM_REMARK` | 15604 | `Operators.ConcatenateObject(DtIdtl.Rows[i][8], (object)"")` | web |
| `DM_SFNO` | 15605 | `Operators.ConcatenateObject(DtIdtl.Rows[i][9], (object)"")` | web |
| `DM_SIZE` | 15602 | `Operators.ConcatenateObject(DtIdtl.Rows[i][6], (object)"")` | web |
| `ENTRY_TYPE` | 15592 | `"S"` | web |
| `HD_VCH_NO` | 15587 | `tHdVchNo.Text` | web |
| `INOUT_TYPE` | 15591 | `FormBookInOut` | web |
| `ISR_NO` | 15597 | `num8` | web |
| `IT_AMT` | 15612 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]))` | web |
| `IT_CODE` | 15598 | `RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1])` | web |
| `IT_CON_PRC` | 15609 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]))` | web |
| `IT_CON_WT` | 15616 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]))` | web |
| `IT_GWT` | 15607 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11]))` | web |
| `IT_LBR_AMT` | 15614 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]))` | web |
| `IT_LBR_RATE` | 15613 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]))` | web |
| `IT_NET_AMT` | 15615 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18]))` | web |
| `IT_PCS` | 15606 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10]))` | web |
| `IT_RATE` | 15611 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]))` | web |
| `IT_RATE_TYPE` | 15610 | `RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13])` | web |
| `IT_TYPE` | 15617 | `RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22])` | web |
| `KR_WT` | 15608 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]))` | web |
| `LC_CODE` | 15583 | `DC_Main.MLc_code` | web |
| `MAIN_USER` | 15618 | `MainUser` | web |
| `SR_NO` | 15594 | `Conversion.Val(MSG[num7, 57])` | web |
| `TAG_NO` | 15595 | `MSG[num7, 1]` | web |
| `VCH_DATE` | 15588 | `mVchDate.Text` | web |
| `VCH_NO` | 15586 | `tVchNo.Text` | web |
| `VCH_SRNO` | 15596 | `Conversion.Val(MSG[num7, 52])` | web |
| `VCH_TYPE` | 15590 | `FormBookSname` | web |
