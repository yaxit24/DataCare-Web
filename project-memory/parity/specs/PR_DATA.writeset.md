# Desktop write set — PR_DATA

Source: `TR_PURC.cs:12960`–`13069` (`dataRow2`). The form writes `PR_*` or `KR_*` depending on
the book: `MAIN_BOOK = 'KARIGAR RECEIPT'` or `'OLD ITEM SALES'` selects `KR_DATA/KR_DETL/KR_IDTL`
(TR_PURC.cs:11830-11845), otherwise `PR_DATA/PR_DETL/PR_IDTL` (11861-11864).

- Assigned: **64** (63 in the desktop schema) | already persisted **42** | **MISSING 21**

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_CODE` | 12966 | `tAcCode.Text` | web |
| `AC_GST_TYPE` | 13022 | `AcGstType` | web |
| `AC_NAME` | 12971 | `tAcName.Text` | web |
| `ADD1` | 13017 | `tAdd1.Text` | **MISSING** |
| `ADD2` | 13018 | `tAdd2.Text` | **MISSING** |
| `ADD3` | 13019 | `tAdd3.Text` | **MISSING** |
| `BANK_AC` | 13014 | `MSG2_TOTAL[6, 4]` | web |
| `BANK_NAME` | 13016 | `tBankName.Text` | **MISSING** |
| `BILL_NO` | 12968 | `tBillNo.Text` | web |
| `BILL_OS` | 13012 | `Conversion.Val(MSG2_TOTAL[10, 3])` | web |
| `CARD_AC` | 13013 | `MSG2_TOTAL[7, 4]` | **MISSING** |
| `CARD_AMT` | 13009 | `Conversion.Val(MSG2_TOTAL[7, 3])` | web |
| `CASH_AMT` | 13010 | `Conversion.Val(MSG2_TOTAL[8, 3])` | web |
| `CGST_TAX` | 13029 | `0` | web |
| `CHQ_AMT` | 13008 | `Conversion.Val(MSG2_TOTAL[6, 3])` | web |
| `CHQ_NO` | 13015 | `MSG2_TOTAL[6, 2]` | **MISSING** |
| `CITY` | 13020 | `tCity.Text` | **MISSING** |
| `CO_BOOK` | 12964 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 12961 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 12963 | `DC_Main.MCo_year` | web |
| `CR_DAYS` | 13046 | `Conversion.Val(nCrDays.Text)` | **MISSING** |
| `DATA_TRFR` | 13057 | `"N"` | web |
| `DISC_AMT` | 12983 | `Conversion.Val(MSG2_TOTAL[1, 3])` | web |
| `DISC_PRC` | 12982 | `Conversion.Val(MSG2_TOTAL[1, 2])` | **MISSING** |
| `EMP_CODE` | 13044 | `tEmpCode.Text` | web |
| `FX_CODE` | 13055 | `""` | **MISSING** |
| `FX_RATE` | 13054 | `0` | **MISSING** |
| `HD_VCH_NO` | 12969 | `tHdVchNo.Text` | web |
| `IGST_TAX` | 13027 | `Conversion.Val(MSG2_TOTAL[2, 3])` | web |
| `IT_TYPE` | 12972 | `Strings.Mid(cboItemTyp.Text, 1, 1)` | web |
| `KASAR_AMT` | 13011 | `Conversion.Val(MSG2_TOTAL[9, 3])` | web |
| `LBR_AMT` | 13006 | `Conversion.Val(MSG_PR_TOT[0, 35])` | web |
| `LC_CODE` | 12962 | `DC_Main.MLc_code` | web |
| `MAIN_USER` | 13066 | `MainUser` | web |
| `MOBILE` | 13021 | `tMobile.Text` | **MISSING** |
| `MTL_RATE` | 13056 | `0` | **MISSING** |
| `NET_AMT` | 12981 | `Conversion.Val(MSG2_TOTAL[0, 3])` | web |
| `OTH_AMT` | 13007 | `Conversion.Val(MSG_PR_TOT[0, 36]) - PrOthAmtLess` | web |
| `OZ_CONV` | 13053 | `0` | **MISSING** |
| `OZ_RATE` | 13052 | `0` | **MISSING** |
| `PARTY_FINE` | 12975 | `Conversion.Val(nPartyFine.Text)` | web |
| `RE_TRFR` | 13060 | `"Y"` | not-in-desktop-schema |
| `ROF_AMT` | 12992 | `0` | web |
| `SGST_TAX` | 13028 | `0` | web |
| `SL_BILL_DBCD` | 13050 | `tSlBill_DbCd.Text` | web |
| `SL_BILL_LC` | 13048 | `DC_Main.MLc_code` | web |
| `SL_BILL_NO` | 13047 | `tSlBill.Text` | web |
| `SL_BILL_YRCD` | 13049 | `DC_Main.MCo_year` | web |
| `TAX_AMT` | 12986 | `Conversion.Val(MSG2_TOTAL[2, 3])` | web |
| `TAX_CODE` | 12984 | `MSG2_TOTAL[2, 4]` | web |
| `TAX_PRC` | 12985 | `Conversion.Val(MSG2_TOTAL[2, 2])` | web |
| `TCS_AMT` | 12989 | `Conversion.Val(MSG2_TOTAL[3, 3])` | **MISSING** |
| `TCS_CODE` | 12987 | `MSG2_TOTAL[3, 4]` | **MISSING** |
| `TCS_PRC` | 12988 | `Conversion.Val(MSG2_TOTAL[3, 2])` | **MISSING** |
| `TDS_AMT` | 12995 | `Conversion.Val(MSG2_TOTAL[4, 3])` | **MISSING** |
| `TDS_CODE` | 12993 | `MSG2_TOTAL[4, 4]` | **MISSING** |
| `TDS_PRC` | 12994 | `Conversion.Val(MSG2_TOTAL[4, 2])` | **MISSING** |
| `TOT_AMT` | 12996 | `Conversion.Val(MSG2_TOTAL[5, 3]) + Conversion.Val(MSG2_TOTAL[4, 3])` | web |
| `USER_DELETE` | 13068 | `"N"` | web |
| `USER_UPDATE` | 13067 | `"N"` | web |
| `VCH_DATE` | 12967 | `mVchDate.Text` | web |
| `VCH_DESC` | 13045 | `tVchDesc.Text` | web |
| `VCH_NO` | 12965 | `tVchNo.Text` | web |
| `VCH_TIME` | 13051 | `mVchDate.Text + " " + mTime.Text` | web |
