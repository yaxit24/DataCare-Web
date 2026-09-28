# Desktop write set — SL_ORD_DATA

Source: `TR_SALE_ORD.cs:9107`–`9175` (`dataRow2`), verified against its own `SELECT ... FROM SL_ORD_DATA`.

- Assigned **51** (50 in the desktop schema) | persisted **25** | **MISSING 25**

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_CODE` | 9113 | `tAcCode.Text` | web |
| `AC_NAME` | 9118 | `tAcName.Text` | web |
| `ADD1` | 9157 | `tAdd1.Text` | **MISSING** |
| `ADD2` | 9158 | `tAdd2.Text` | **MISSING** |
| `ADD3` | 9159 | `tAdd3.Text` | **MISSING** |
| `ADJ_GOLD` | 9146 | `AdjGold` | **MISSING** |
| `ADJ_SILVER` | 9147 | `AdjSilver` | **MISSING** |
| `ADV_AMT` | 9127 | `0` | web |
| `BANK_AC` | 9149 | `MSG2_TOTAL[4, 4]` | **MISSING** |
| `BANK_NAME` | 9151 | `tBankName.Text` | **MISSING** |
| `BILL_NO` | 9115 | `tBillNo.Text` | web |
| `CARD_AC` | 9148 | `MSG2_TOTAL[5, 4]` | **MISSING** |
| `CARD_ADJ` | 9154 | `CardCommAdj` | **MISSING** |
| `CARD_AMT` | 9139 | `Conversion.Val(MSG2_TOTAL[5, 3])` | web |
| `CASH_AMT` | 9138 | `Conversion.Val(MSG2_TOTAL[3, 3])` | web |
| `CHQ_AMT` | 9140 | `Conversion.Val(MSG2_TOTAL[4, 3])` | web |
| `CHQ_NO` | 9150 | `MSG2_TOTAL[4, 2]` | **MISSING** |
| `CITY` | 9160 | `tCity.Text` | **MISSING** |
| `CO_BOOK` | 9111 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 9108 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 9110 | `DC_Main.MCo_year` | web |
| `DATA_TRFR` | 9163 | `"N"` | web |
| `DEL_DATE` | 9152 | `RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mDelDate.Text), (object)DB` | **MISSING** |
| `EMP_CODE` | 9155 | `tEmpCode.Text` | web |
| `FUN_DATE` | 9153 | `RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mFunDate.Text), (object)DB` | **MISSING** |
| `HD_VCH_NO` | 9116 | `tHdVchNo.Text` | web |
| `LC_CODE` | 9109 | `DC_Main.MLc_code` | web |
| `MAIN_USER` | 9172 | `MainUser` | web |
| `MOBILE` | 9161 | `tMobile.Text` | **MISSING** |
| `NET_AMT` | 9119 | `Conversion.Val(MSG2_TOTAL[0, 3])` | web |
| `OLD_GL` | 9143 | `Conversion.Val(MSG2_TOTAL[6, 2]) + Conversion.Val(MSG2_TOTAL[9, 2])` | **MISSING** |
| `OLD_GL_AMT` | 9136 | `Conversion.Val(MSG2_TOTAL[6, 3])` | **MISSING** |
| `OLD_SL` | 9144 | `Conversion.Val(MSG2_TOTAL[7, 2])` | **MISSING** |
| `OLD_SL_AMT` | 9137 | `Conversion.Val(MSG2_TOTAL[7, 3])` | **MISSING** |
| `ORD_ADJ_AMT` | 9145 | `RecAdjAmt` | **MISSING** |
| `RCUT_AMT` | 9126 | `Conversion.Val(MSG2_TOTAL[9, 3])` | **MISSING** |
| `RCUT_FINE` | 9135 | `Conversion.Val(MSG2_TOTAL[9, 2])` | **MISSING** |
| `RCUT_RATE` | 9134 | `Conversion.Val(MSG2_TOTAL[9, 1])` | **MISSING** |
| `RE_TRFR` | 9166 | `"Y"` | not-in-desktop-schema |
| `SCHM_AMT` | 9142 | `Conversion.Val(MSG2_TOTAL[8, 3])` | **MISSING** |
| `TAX_AMT` | 9122 | `Conversion.Val(MSG2_TOTAL[1, 3])` | web |
| `TAX_CODE` | 9120 | `MSG2_TOTAL[1, 4]` | **MISSING** |
| `TAX_PRC` | 9121 | `Conversion.Val(MSG2_TOTAL[1, 2])` | web |
| `TOT_AMT` | 9123 | `Conversion.Val(MSG2_TOTAL[2, 3])` | web |
| `UPI_AMT` | 9141 | `Conversion.Val(MSG2_TOTAL[3, 1])` | **MISSING** |
| `USER_DELETE` | 9174 | `"N"` | web |
| `USER_UPDATE` | 9173 | `"N"` | web |
| `VCH_DATE` | 9114 | `mVchDate.Text` | web |
| `VCH_DESC` | 9156 | `tVchDesc.Text` | web |
| `VCH_NO` | 9112 | `tVchNo.Text` | web |
| `VCH_TIME` | 9162 | `mVchDate.Text + " " + mTime.Text` | web |
