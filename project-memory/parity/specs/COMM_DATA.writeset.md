# Desktop write set — COMM_DATA (commission)

Source: `unified/src/csharp/DataCareNext/TR_SALE.cs:15948`–`16003`, row variable `dataRow14`, verified against its own `SELECT * FROM COMM_DATA`.

- Assigned columns: **31** (31 exist in the desktop production schema)
- Already persisted by the web: **0**
- **MISSING: 31**
- Desktop production table: **ABSENT from realdb catalog**
- Web Prisma model: present

Implement each MISSING column from its cited expression. `MSG2_TOTAL[r,c]` = settlement grid,
`MSG_TOT[0,c]` = totals grid, `mSG4[i,c]` = item grid, `tXxx.Text` = header field.
Do not invent a value: if an expression cannot be resolved, record it in the form contract.

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_AREA` | 16000 | `value3` | **MISSING** |
| `AC_CITY` | 15999 | `value2` | **MISSING** |
| `AC_CODE` | 15974 | `tAcCode.Text` | **MISSING** |
| `BOOK_NAME` | 15973 | `FormMainBook` | **MISSING** |
| `COM_AMT` | 15995 | `0` | **MISSING** |
| `COM_FINE` | 15992 | `Strings.Format((object)(Conversion.Val(mSG3[DC_Main.i, 40]) / (double)num17), "0.000")` | **MISSING** |
| `COM_GHT` | 15989 | `Conversion.Val(mSG3[DC_Main.i, 17])` | **MISSING** |
| `COM_PRC` | 15991 | `Conversion.Val(mSG3[DC_Main.i, 39])` | **MISSING** |
| `COM_TYPE` | 15983 | `""` | **MISSING** |
| `COM_WT` | 15988 | `Conversion.Val(mSG3[DC_Main.i, 14])` | **MISSING** |
| `CO_BOOK` | 15967 | `DC_Main.MCo_Book` | **MISSING** |
| `CO_CODE` | 15964 | `DC_Main.MCo_code` | **MISSING** |
| `CO_YEAR` | 15966 | `DC_Main.MCo_year` | **MISSING** |
| `DATA_TYPE` | 15997 | `"A"` | **MISSING** |
| `EMP_CODE` | 15998 | `tEmpCode.Text` | **MISSING** |
| `INOUT_TYPE` | 15972 | `FormBookInOut` | **MISSING** |
| `ISR_NO` | 15985 | `DC_Main.M` | **MISSING** |
| `ITM_TOUCH` | 15990 | `Conversion.Val(mSG3[DC_Main.i, 106])` | **MISSING** |
| `ITM_TYPE` | 15996 | `mSG3[DC_Main.i, 59]` | **MISSING** |
| `IT_CODE` | 15986 | `mSG3[DC_Main.i, 3]` | **MISSING** |
| `LBR_AMT` | 15993 | `Conversion.Val(mSG3[DC_Main.i, 27])` | **MISSING** |
| `LC_CODE` | 15965 | `DC_Main.MLc_code` | **MISSING** |
| `MAIN_USER` | 16002 | `MainUser` | **MISSING** |
| `MEMB_AC_CODE` | 15977 | `tAcMembCode.Text` | **MISSING** |
| `NET_AMT` | 15994 | `Conversion.Val(mSG3[DC_Main.i, 37])` | **MISSING** |
| `SR_NO` | 15984 | `Conversion.Val(mSG3[DC_Main.i, 0])` | **MISSING** |
| `TOT_NET_WT` | 15987 | `Conversion.Val(mSG3[DC_Main.i, 14]) + Conversion.Val(mSG3[DC_Main.i, 17])` | **MISSING** |
| `VCH_DATE` | 15969 | `mVchDate.Text` | **MISSING** |
| `VCH_NO` | 15968 | `tVchNo.Text` | **MISSING** |
| `VCH_TIME` | 15970 | `mVchDate.Text + " " + mTime.Text` | **MISSING** |
| `VCH_TYPE` | 15971 | `FormBookSname` | **MISSING** |
