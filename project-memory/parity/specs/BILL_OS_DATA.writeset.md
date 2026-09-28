# Desktop write set — BILL_OS_DATA (bill outstanding)

Source: `unified/src/csharp/DataCareNext/TR_SALE.cs:15742`–`15780`, row variable `dataRow9`, verified against its own `SELECT * FROM BILL_OS_DATA`.

- Assigned columns: **35** (35 exist in the desktop production schema)
- Already persisted by the web: **15**
- **MISSING: 20**
- Desktop production table: present, 40 columns
- Web Prisma model: present

Implement each MISSING column from its cited expression. `MSG2_TOTAL[r,c]` = settlement grid,
`MSG_TOT[0,c]` = totals grid, `mSG4[i,c]` = item grid, `tXxx.Text` = header field.
Do not invent a value: if an expression cannot be resolved, record it in the form contract.

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_CODE` | 15753 | `tAcCode.Text` | web |
| `BILL_AMT` | 15758 | `Conversion.Val(MSG2_TOTAL[5, 3])` | web |
| `BILL_DBCD` | 15772 | `DC_Main.MCo_Book` | **MISSING** |
| `BILL_GOLD` | 15762 | `0` | **MISSING** |
| `BILL_HD_VCH_NO` | 15774 | `tHdVchNo.Text` | **MISSING** |
| `BILL_LC` | 15770 | `DC_Main.MLc_code` | **MISSING** |
| `BILL_NO` | 15773 | `tVchNo.Text` | **MISSING** |
| `BILL_SILVER` | 15766 | `0` | **MISSING** |
| `BILL_SRNO` | 15775 | `1` | **MISSING** |
| `BILL_YRCD` | 15771 | `DC_Main.MCo_year` | **MISSING** |
| `BOOK_NAME` | 15757 | `FormMainBook` | web |
| `CO_BOOK` | 15748 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 15745 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 15747 | `DC_Main.MCo_year` | web |
| `DATA_TRFR` | 15778 | `"N"` | **MISSING** |
| `DATA_TYPE` | 15779 | `"A"` | **MISSING** |
| `ENTRY_TYPE` | 15756 | `"O"` | web |
| `HD_VCH_NO` | 15752 | `tHdVchNo.Text` | **MISSING** |
| `INOUT_TYPE` | 15755 | `FormBookInOut` | web |
| `KASAR_AMT` | 15761 | `Conversion.Val(MSG2_TOTAL[14, 3])` | web |
| `KASAR_GOLD` | 15765 | `0` | **MISSING** |
| `KASAR_SILVER` | 15769 | `0` | **MISSING** |
| `LC_CODE` | 15746 | `DC_Main.MLc_code` | web |
| `MAIN_USER` | 15777 | `MainUser` | **MISSING** |
| `OLD_ADJ_AMT` | 15759 | `0` | **MISSING** |
| `OLD_ADJ_GOLD` | 15763 | `0` | **MISSING** |
| `OLD_ADJ_SILVER` | 15767 | `0` | **MISSING** |
| `REC_AMT` | 15760 | `Conversion.Val(MSG2_TOTAL[5, 3]) - (Conversion.Val(MSG2_TOTAL[15, 3]) + Conversion.Val(MSG2_TOTAL[14, 3])` | web |
| `REC_GOLD` | 15764 | `0` | **MISSING** |
| `REC_SILVER` | 15768 | `0` | **MISSING** |
| `SR_NO` | 15750 | `1` | web |
| `VCH_DATE` | 15751 | `mVchDate.Text` | web |
| `VCH_NO` | 15749 | `tVchNo.Text` | web |
| `VCH_TIME` | 15776 | `mVchDate.Text + " " + mTime.Text` | **MISSING** |
| `VCH_TYPE` | 15754 | `FormBookSname` | web |
