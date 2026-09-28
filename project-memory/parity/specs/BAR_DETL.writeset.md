# Desktop write set — BAR_DETL

Source: `unified/src/csharp/DataCareNext/TR_TAG_OPBL.cs` — lines 9294-9384 (`dataRow3`), lines 10925-11126 (`dataRow3`); each row variable verified against its own `SELECT ... FROM BAR_DETL`.

- Assigned columns: **102** (102 in the desktop production schema)
- Already persisted: **59** | **MISSING: 43**

`mSG[i,c]` = tag grid, `tXxx.Text` = header field. Implement each MISSING column from its
cited expression; never invent a value.

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `APR_ISU` | 9367 | `"N"` | web |
| `BAG_WT` | 9319 | `Conversion.Val(mSG[L, 12])` | web |
| `BOOK_NAME` | 9309 | `FormMainBook` | web |
| `CO_BOOK` | 9301 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 9298 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 9300 | `DC_Main.MCo_year` | web |
| `DATA_TRFR` | 9374 | `"N"` | web |
| `DATA_TYPE` | 9375 | `mSG[L, 89]` | web |
| `DESIGN_IMG_ID` | 11112 | `mSG[DC_Main.i, 101]` | **MISSING** |
| `DESIGN_NO` | 9315 | `mSG[L, 7]` | web |
| `EMP_ISU` | 11111 | `mSG[DC_Main.i, 100]` | **MISSING** |
| `ENTRY_TYPE` | 9308 | `"O"` | web |
| `HD_VCH_NO` | 9303 | `tHdVchNo.Text` | web |
| `HM_ID` | 9318 | `mSG[L, 11]` | web |
| `HM_ID2` | 9376 | `mSG[L, 82]` | **MISSING** |
| `HM_ID2_WT` | 9380 | `Conversion.Val(mSG[L, 86])` | **MISSING** |
| `HM_ID3` | 9377 | `mSG[L, 83]` | **MISSING** |
| `HM_ID3_WT` | 9381 | `Conversion.Val(mSG[L, 87])` | **MISSING** |
| `HM_ID4` | 9378 | `mSG[L, 84]` | **MISSING** |
| `HM_ID4_WT` | 9382 | `Conversion.Val(mSG[L, 88])` | **MISSING** |
| `HM_ID_WT` | 9379 | `Conversion.Val(mSG[L, 85])` | **MISSING** |
| `INOUT_TYPE` | 9307 | `FormBookInOut` | web |
| `ITM_AMT` | 9346 | `Conversion.Val(mSG[L, 44])` | web |
| `ITM_COLOR` | 10967 | `mSG[DC_Main.i, 9]` | **MISSING** |
| `ITM_FINE` | 9335 | `Conversion.Val(mSG[L, 29])` | web |
| `ITM_GHT_PRC` | 9331 | `Conversion.Val(mSG[L, 25])` | web |
| `ITM_GHT_WT` | 9332 | `Conversion.Val(mSG[L, 26])` | web |
| `ITM_GWT` | 9321 | `Conversion.Val(mSG[L, 14])` | web |
| `ITM_MARGIN` | 9348 | `Conversion.Val(mSG[L, 49])` | **MISSING** |
| `ITM_MRP` | 9349 | `Conversion.Val(mSG[L, 50])` | web |
| `ITM_NWT` | 9323 | `Conversion.Val(mSG[L, 16])` | web |
| `ITM_OTH_WT` | 9322 | `Conversion.Val(mSG[L, 15])` | web |
| `ITM_PCS` | 9320 | `Conversion.Val(mSG[L, 13])` | web |
| `ITM_RATE` | 9345 | `Conversion.Val(mSG[L, 43])` | web |
| `ITM_REMARK` | 9350 | `mSG[L, 52]` | web |
| `ITM_SIZE` | 9316 | `mSG[L, 10]` | web |
| `ITM_STYLE` | 9317 | `mSG[L, 8]` | **MISSING** |
| `ITM_TOUCH` | 9333 | `Conversion.Val(mSG[L, 27])` | web |
| `ITM_WEST_PRC` | 9334 | `Conversion.Val(mSG[L, 28])` | web |
| `IT_CODE` | 9312 | `mSG[L, 3]` | web |
| `IT_TYPE` | 9354 | `mSG[L, 64]` | web |
| `JDT_GHT_WT` | 11105 | `Conversion.Val(mSG[DC_Main.i, 55])` | **MISSING** |
| `JDT_JDT_WT` | 11104 | `Conversion.Val(mSG[DC_Main.i, 54])` | **MISSING** |
| `JDT_KUN_NET` | 11108 | `Conversion.Val(mSG[DC_Main.i, 58])` | **MISSING** |
| `JDT_KUN_TOUCH` | 11107 | `Conversion.Val(mSG[DC_Main.i, 57])` | **MISSING** |
| `JDT_KUN_WT` | 11106 | `Conversion.Val(mSG[DC_Main.i, 56])` | **MISSING** |
| `JDT_WAX_WT` | 11109 | `Conversion.Val(mSG[DC_Main.i, 59])` | **MISSING** |
| `KR_COST` | 9344 | `Conversion.Val(mSG[L, 45])` | **MISSING** |
| `KR_FINE` | 9330 | `Conversion.Val(mSG[L, 23])` | web |
| `KR_GHT_PRC` | 9326 | `Conversion.Val(mSG[L, 19])` | web |
| `KR_GHT_WT` | 9327 | `Conversion.Val(mSG[L, 20])` | web |
| `KR_GWT_TOUCH` | 11042 | `Conversion.Val(mSG[DC_Main.i, 42])` | **MISSING** |
| `KR_LBR_AMT` | 9342 | `Conversion.Val(mSG[L, 36])` | **MISSING** |
| `KR_LBR_RATE` | 9341 | `Conversion.Val(mSG[L, 35])` | **MISSING** |
| `KR_NAME` | 9351 | `mSG[L, 53]` | **MISSING** |
| `KR_NET_WT` | 9325 | `Conversion.Val(mSG[L, 18])` | web |
| `KR_OTH_AMT` | 9343 | `Conversion.Val(mSG[L, 37])` | **MISSING** |
| `KR_OTH_FINE` | 11040 | `Conversion.Val(mSG[DC_Main.i, 40])` | **MISSING** |
| `KR_OTH_RATE` | 11039 | `Conversion.Val(mSG[DC_Main.i, 39])` | **MISSING** |
| `KR_OTH_WT` | 9324 | `Conversion.Val(mSG[L, 17])` | web |
| `KR_TOT_FINE` | 11041 | `Conversion.Val(mSG[DC_Main.i, 41])` | **MISSING** |
| `KR_TOUCH` | 9328 | `Conversion.Val(mSG[L, 21])` | web |
| `KR_WAX_WT` | 11110 | `Conversion.Val(mSG[DC_Main.i, 60])` | **MISSING** |
| `KR_WEST_PRC` | 9329 | `Conversion.Val(mSG[L, 22])` | web |
| `LBR_AMT` | 9339 | `Conversion.Val(mSG[L, 33])` | web |
| `LBR_CODE` | 11028 | `mSG[DC_Main.i, 24]` | **MISSING** |
| `LBR_PRC` | 9336 | `Conversion.Val(mSG[L, 30])` | web |
| `LBR_RATE` | 9338 | `Conversion.Val(mSG[L, 32])` | web |
| `LBR_TYPE` | 9337 | `mSG[L, 31]` | web |
| `LC_CODE` | 9299 | `DC_Main.MLc_code` | web |
| `LOT_NO` | 10952 | `tLotNo.Text` | web |
| `MAIN_MARGIN_PRC` | 11060 | `Conversion.Val(mSG[DC_Main.i, 47])` | **MISSING** |
| `MAIN_MRP` | 11061 | `Conversion.Val(mSG[DC_Main.i, 48])` | **MISSING** |
| `MAIN_USER` | 9383 | `MainUser` | web |
| `MFG_DBCD` | 11124 | `mSG[DC_Main.i, 104]` | **MISSING** |
| `MFG_NO` | 11116 | `mSG[DC_Main.i, 2]` | **MISSING** |
| `MFG_SRNO` | 11125 | `Conversion.Val(mSG[DC_Main.i, 106])` | **MISSING** |
| `MFG_YRCD` | 11123 | `mSG[DC_Main.i, 103]` | **MISSING** |
| `OLD_SRNO` | 9311 | `Conversion.Val(mSG[L, 62])` | web |
| `ORD_AC` | 11101 | `mSG[DC_Main.i, 94]` | **MISSING** |
| `ORD_DBCD` | 11100 | `mSG[DC_Main.i, 92]` | **MISSING** |
| `ORD_LC_CODE` | 11102 | `mSG[DC_Main.i, 95]` | **MISSING** |
| `ORD_NO` | 11097 | `mSG[DC_Main.i, 4]` | **MISSING** |
| `ORD_SRNO` | 11098 | `Conversion.Val(mSG[DC_Main.i, 90])` | **MISSING** |
| `ORD_YRCD` | 11099 | `mSG[DC_Main.i, 91]` | **MISSING** |
| `OTH_AMT` | 9340 | `Conversion.Val(mSG[L, 34])` | web |
| `PR_CODE` | 9356 | `mSG[L, 66]` | web |
| `RATE_TYPE` | 9353 | `mSG[L, 63]` | web |
| `SF_NO` | 11103 | `mSG[DC_Main.i, 97]` | **MISSING** |
| `SL_TYPE` | 11038 | `mSG[DC_Main.i, 38]` | **MISSING** |
| `SR_NO` | 9310 | `Conversion.Val(mSG[L, 0])` | web |
| `STK_DATE` | 9305 | `mVchDate.Text` | web |
| `TAG_COST` | 9347 | `Conversion.Val(mSG[L, 46])` | web |
| `TAG_NO` | 9313 | `mSG[L, 5]` | web |
| `TAG_SRNO` | 9352 | `Conversion.Val(mSG[L, 61])` | web |
| `TAG_TYPE` | 9355 | `mSG[L, 65]` | web |
| `TBL_CODE` | 9314 | `mSG[L, 6]` | web |
| `VCH_DATE` | 9304 | `mVchDate.Text` | web |
| `VCH_NO` | 9302 | `tVchNo.Text` | web |
| `VCH_SRNO` | 9359 | `DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tVchNo.Text + Conversions.ToS` | web |
| `VCH_TIME` | 9373 | `mVchDate.Text + " " + mTime.Text` | web |
| `VCH_TYPE` | 9306 | `FormBookSname` | web |
