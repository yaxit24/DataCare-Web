# Desktop write set — SL_ORD_ADJ

Source: `TR_SALE_ORD.cs:9480`–`9516` (`dataRow7`), verified against its own `SELECT ... FROM SL_ORD_ADJ`.

- Assigned **33** (33 in the desktop schema) | persisted **25** | **MISSING 8**

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_CODE` | 9491 | `tAcCode.Text` | web |
| `AC_NAME` | 9492 | `tAcName.Text` | web |
| `BOOK_NAME` | 9496 | `FormMainBook` | web |
| `CO_BOOK` | 9486 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 9483 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 9485 | `DC_Main.MCo_year` | web |
| `DATA_TRFR` | 9512 | `"N"` | **MISSING** |
| `EMP_CODE` | 9513 | `tEmpCode.Text` | **MISSING** |
| `ENTRY_TYPE` | 9495 | `"O"` | web |
| `HD_VCH_NO` | 9490 | `tHdVchNo.Text` | web |
| `INOUT_TYPE` | 9494 | `FormBookInOut` | web |
| `IT_DESC` | 9514 | `tVchDesc.Text` | web |
| `KASAR_AMT` | 9507 | `0` | web |
| `LC_CODE` | 9484 | `DC_Main.MLc_code` | web |
| `MAIN_USER` | 9515 | `MainUser` | web |
| `ORD_AC_CODE` | 9502 | `tAcCode.Text` | web |
| `ORD_AMT` | 9504 | `RuntimeHelpers.GetObjectValue(Interaction.IIf(Conversion.Val(MSG2_TOTAL[9, 1]) == 0.0, (object)Conve` | web |
| `ORD_BAL_AMT` | 9508 | `0` | web |
| `ORD_DBCD` | 9501 | `DC_Main.MCo_Book` | **MISSING** |
| `ORD_GOLD` | 9509 | `OrdGold + Conversion.Val(MSG2_TOTAL[9, 2])` | **MISSING** |
| `ORD_HD_VCH_NO` | 9497 | `tHdVchNo.Text` | **MISSING** |
| `ORD_LC` | 9499 | `DC_Main.MLc_code` | **MISSING** |
| `ORD_NO` | 9498 | `tVchNo.Text` | web |
| `ORD_SIGN` | 9503 | `"+"` | web |
| `ORD_SILVER` | 9510 | `OrdSilver` | **MISSING** |
| `ORD_YRCD` | 9500 | `DC_Main.MCo_year` | **MISSING** |
| `PAID_AC` | 9505 | `""` | web |
| `PAID_AMT` | 9506 | `0` | web |
| `SR_NO` | 9488 | `1` | web |
| `VCH_DATE` | 9489 | `mVchDate.Text` | web |
| `VCH_NO` | 9487 | `tVchNo.Text` | web |
| `VCH_TIME` | 9511 | `mVchDate.Text + " " + mTime.Text` | web |
| `VCH_TYPE` | 9493 | `FormBookSname` | web |
