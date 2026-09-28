# Desktop write set — SL_DATA (header)

Source: `unified/src/csharp/DataCareNext/TR_SALE.cs:15188`–`15358`, row variable `dataRow3`, verified against its own `SELECT * FROM SL_DATA`.

- Assigned columns: **94** (87 exist in the desktop production schema)
- Already persisted by the web: **41**
- **MISSING: 46**
- Desktop production table: present, 98 columns
- Web Prisma model: present

Implement each MISSING column from its cited expression. `MSG2_TOTAL[r,c]` = settlement grid,
`MSG_TOT[0,c]` = totals grid, `mSG4[i,c]` = item grid, `tXxx.Text` = header field.
Do not invent a value: if an expression cannot be resolved, record it in the form contract.

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_CODE` | 15194 | `tAcCode.Text` | web |
| `AC_GST_TYPE` | 15276 | `AcGstType` | web |
| `AC_MEMB_COM_PRC` | 15265 | `0` | not-in-desktop-schema |
| `AC_MEMB_COM_VAL` | 15266 | `Conversion.Val(MSG_TOT[0, 40])` | not-in-desktop-schema |
| `AC_NAME` | 15199 | `tAcName.Text` | web |
| `ADD1` | 15271 | `tAdd1.Text` | **MISSING** |
| `ADD2` | 15272 | `tAdd2.Text` | **MISSING** |
| `ADD3` | 15273 | `tAdd3.Text` | **MISSING** |
| `ADV_AMT` | 15229 | `Conversion.Val(MSG2_TOTAL[8, 3])` | **MISSING** |
| `BANK_AC` | 15260 | `MSG2_TOTAL[6, 4]` | **MISSING** |
| `BANK_NAME` | 15268 | `tBankName.Text` | **MISSING** |
| `BILL_NO` | 15196 | `tBillNo.Text` | web |
| `BILL_OS` | 15256 | `Conversion.Val(MSG2_TOTAL[15, 3])` | web |
| `CARD_AC` | 15259 | `MSG2_TOTAL[7, 4]` | **MISSING** |
| `CARD_ADJ` | 15269 | `CardCommAdj` | **MISSING** |
| `CARD_AMT` | 15227 | `Conversion.Val(MSG2_TOTAL[7, 3])` | web |
| `CARD_COM_AMT` | 15228 | `Conversion.Val(MSG2_TOTAL[7, 2])` | **MISSING** |
| `CASH_AMT` | 15236 | `Conversion.Val(MSG2_TOTAL[12, 3])` | web |
| `CASH_PAID` | 15254 | `Conversion.Val(MSG2_TOTAL[13, 3])` | **MISSING** |
| `CGST_TAX` | 15283 | `0` | web |
| `CHQ_AMT` | 15226 | `Conversion.Val(MSG2_TOTAL[6, 3])` | web |
| `CHQ_NO` | 15261 | `MSG2_TOTAL[6, 2]` | **MISSING** |
| `CITY` | 15274 | `tCity.Text` | **MISSING** |
| `CO_BOOK` | 15192 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 15189 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 15191 | `DC_Main.MCo_year` | web |
| `CRNT_ADJ_AMT` | 15230 | `Conversion.Val(MSG2_TOTAL[8, 1])` | **MISSING** |
| `CR_DAYS` | 15270 | `Conversion.Val(nCrDays.Text)` | web |
| `DATA_TRFR` | 15332 | `"N"` | **MISSING** |
| `DISC_AMT` | 15202 | `Conversion.Val(MSG2_TOTAL[1, 3])` | web |
| `DISC_PRC` | 15201 | `Conversion.Val(MSG2_TOTAL[1, 2])` | **MISSING** |
| `EMP_CODE` | 15314 | `tEmpCode.Text` | web |
| `FX_CODE` | 15356 | `""` | **MISSING** |
| `FX_RATE` | 15355 | `0` | **MISSING** |
| `HD_VCH_NO` | 15197 | `tHdVchNo.Text` | web |
| `HM_AMT` | 15298 | `0` | web |
| `HM_TAX_AMT` | 15301 | `0` | web |
| `HM_TAX_CODE` | 15299 | `""` | **MISSING** |
| `HM_TAX_PRC` | 15300 | `0` | **MISSING** |
| `IGST_TAX` | 15281 | `Conversion.Val(MSG2_TOTAL[2, 3])` | web |
| `ISU_DBCD` | 15313 | `tIsuDbCd.Text` | web |
| `ISU_LC_CODE` | 15311 | `DC_Main.MLc_code` | web |
| `ISU_NO` | 15310 | `tIsuNo.Text` | web |
| `ISU_YRCD` | 15312 | `tIsuYrCd.Text` | web |
| `KASAR_AMT` | 15255 | `Conversion.Val(MSG2_TOTAL[14, 3])` | web |
| `LBR_AMT` | 15223 | `Conversion.Val(MSG_TOT[0, 27])` | **MISSING** |
| `LC_CODE` | 15190 | `DC_Main.MLc_code` | web |
| `MAIN_USER` | 15341 | `MainUser` | web |
| `MEMB_COM_AC_CODE` | 15264 | `tAcMembCode.Text` | not-in-desktop-schema |
| `MOBILE` | 15275 | `tMobile.Text` | **MISSING** |
| `MOB_ENTRY_SAVE` | 15344 | `"Y"` | **MISSING** |
| `MTL_RATE` | 15357 | `0` | **MISSING** |
| `NET_AMT` | 15200 | `Conversion.Val(MSG2_TOTAL[0, 3])` | web |
| `OLD_GL` | 15257 | `Conversion.Val(MSG2_TOTAL[9, 2])` | **MISSING** |
| `OLD_GL_AMT` | 15231 | `Conversion.Val(MSG2_TOTAL[9, 3])` | web |
| `OLD_SL` | 15258 | `Conversion.Val(MSG2_TOTAL[10, 2])` | **MISSING** |
| `OLD_SL_AMT` | 15232 | `Conversion.Val(MSG2_TOTAL[10, 3])` | **MISSING** |
| `ORNA_ISU` | 15320 | `"N"` | **MISSING** |
| `OTH_AMT` | 15224 | `Conversion.Val(MSG_TOT[0, 29])` | **MISSING** |
| `OZ_CONV` | 15354 | `0` | **MISSING** |
| `OZ_RATE` | 15353 | `0` | **MISSING** |
| `POINT_VAL` | 15263 | `Conversion.Val(MSG2_TOTAL[15, 2])` | **MISSING** |
| `RATE_UNFIX` | 15347 | `"Y"` | web |
| `RE_TRFR` | 15335 | `"Y"` | not-in-desktop-schema |
| `ROF_AMT` | 15211 | `0` | web |
| `RTN_BILL_OS` | 15307 | `0` | **MISSING** |
| `RTN_CARD_AMT` | 15304 | `0` | **MISSING** |
| `RTN_CASH_AMT` | 15305 | `0` | **MISSING** |
| `RTN_CHQ_AMT` | 15303 | `0` | **MISSING** |
| `RTN_KASAR_AMT` | 15306 | `0` | **MISSING** |
| `RTN_MEMB_COM_PRC` | 15308 | `0` | not-in-desktop-schema |
| `RTN_MEMB_COM_VAL` | 15309 | `0` | not-in-desktop-schema |
| `RTN_TOT_AMT` | 15302 | `0` | **MISSING** |
| `SCHM_AC` | 15262 | `MSG2_TOTAL[11, 4]` | **MISSING** |
| `SCHM_AMT` | 15233 | `Conversion.Val(MSG2_TOTAL[11, 3])` | **MISSING** |
| `SGST_TAX` | 15282 | `0` | web |
| `TAX_AMT` | 15205 | `Conversion.Val(MSG2_TOTAL[2, 3])` | web |
| `TAX_CODE` | 15203 | `MSG2_TOTAL[2, 4]` | web |
| `TAX_PRC` | 15204 | `Conversion.Val(MSG2_TOTAL[2, 2])` | web |
| `TCS_AMT` | 15208 | `Conversion.Val(MSG2_TOTAL[3, 3])` | web |
| `TCS_CODE` | 15206 | `MSG2_TOTAL[3, 4]` | **MISSING** |
| `TCS_PRC` | 15207 | `Conversion.Val(MSG2_TOTAL[3, 2])` | web |
| `TDS_AMT` | 15214 | `Conversion.Val(MSG2_TOTAL[4, 3])` | **MISSING** |
| `TDS_CODE` | 15212 | `MSG2_TOTAL[4, 4]` | **MISSING** |
| `TDS_PRC` | 15213 | `Conversion.Val(MSG2_TOTAL[4, 2])` | **MISSING** |
| `TOT_AMT` | 15225 | `Conversion.Val(MSG2_TOTAL[5, 3])` | web |
| `UPI_AMT` | 15253 | `Conversion.Val(MSG2_TOTAL[12, 1])` | web |
| `USER_DELETE` | 15343 | `"N"` | **MISSING** |
| `USER_UPDATE` | 15342 | `"N"` | **MISSING** |
| `VCH_DATE` | 15195 | `mVchDate.Text` | web |
| `VCH_DESC` | 15315 | `tVchDesc.Text` | **MISSING** |
| `VCH_NO` | 15193 | `tVchNo.Text` | web |
| `VCH_TIME` | 15331 | `mVchDate.Text + " " + mTime.Text` | web |
| `WHOUT_COMM_BILL` | 15267 | `RuntimeHelpers.GetObjectValue(Interaction.IIf(chkWhoutcommBill.Checked, (object)"Y", (object)"N"))` | not-in-desktop-schema |
