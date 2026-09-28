# Desktop write set — UPI_DATA (UPI tender)

Source: `unified/src/csharp/DataCareNext/TR_SALE.cs:15849`–`15870`, row variable `dataRow12`, verified against its own `SELECT * FROM UPI_DATA`.

- Assigned columns: **14** (14 exist in the desktop production schema)
- Already persisted by the web: **14**
- **MISSING: 0**
- Desktop production table: present, 18 columns
- Web Prisma model: present

Implement each MISSING column from its cited expression. `MSG2_TOTAL[r,c]` = settlement grid,
`MSG_TOT[0,c]` = totals grid, `mSG4[i,c]` = item grid, `tXxx.Text` = header field.
Do not invent a value: if an expression cannot be resolved, record it in the form contract.

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_CODE` | 15862 | `tAcCode.Text` | web |
| `CO_BOOK` | 15859 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 15856 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 15858 | `DC_Main.MCo_year` | web |
| `LC_CODE` | 15857 | `DC_Main.MLc_code` | web |
| `SR_NO` | 15861 | `DC_Main.i` | web |
| `UPI_AC_CODE` | 15865 | `MSG_UPI[DC_Main.i, 1]` | web |
| `UPI_AC_NAME` | 15866 | `MSG_UPI[DC_Main.i, 2]` | web |
| `UPI_AMT` | 15869 | `Conversion.Val(MSG_UPI[DC_Main.i, 5])` | web |
| `UPI_ID` | 15868 | `MSG_UPI[DC_Main.i, 4]` | web |
| `UPI_TYPE` | 15867 | `MSG_UPI[DC_Main.i, 3]` | web |
| `VCH_DATE` | 15863 | `mVchDate.Text` | web |
| `VCH_NO` | 15860 | `tVchNo.Text` | web |
| `VCH_TIME` | 15864 | `mVchDate.Text + " " + mTime.Text` | web |
