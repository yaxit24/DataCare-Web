# Desktop write set — SL_DETL (line detail)

Source: `unified/src/csharp/DataCareNext/TR_SALE.cs:15365`–`15489`, row variable `dataRow4`, verified against its own `SELECT * FROM SL_DETL`.

- Assigned columns: **86** (83 exist in the desktop production schema)
- Already persisted by the web: **49**
- **MISSING: 34**
- Desktop production table: present, 103 columns
- Web Prisma model: present

Implement each MISSING column from its cited expression. `MSG2_TOTAL[r,c]` = settlement grid,
`MSG_TOT[0,c]` = totals grid, `mSG4[i,c]` = item grid, `tXxx.Text` = header field.
Do not invent a value: if an expression cannot be resolved, record it in the form contract.

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_CODE` | 15380 | `tAcCode.Text` | web |
| `AC_MEMB_COM_PRC` | 15463 | `Conversion.Val(mSG[DC_Main.i, 39])` | not-in-desktop-schema |
| `AC_MEMB_COM_VAL` | 15464 | `Conversion.Val(mSG[DC_Main.i, 40])` | not-in-desktop-schema |
| `BAG_WT` | 15406 | `Conversion.Val(mSG[DC_Main.i, 10])` | **MISSING** |
| `BOOK_NAME` | 15384 | `FormMainBook` | web |
| `CO_BOOK` | 15376 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 15373 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 15375 | `DC_Main.MCo_year` | web |
| `DESIGN_IMG_ID` | 15470 | `mSG[DC_Main.i, 101]` | **MISSING** |
| `DESIGN_NO` | 15402 | `mSG[DC_Main.i, 6]` | web |
| `DISC_AMT` | 15429 | `Conversion.Val(mSG[DC_Main.i, 32])` | web |
| `DISC_PRC` | 15428 | `Conversion.Val(mSG[DC_Main.i, 31])` | **MISSING** |
| `EMP_CODE` | 15477 | `mSG[DC_Main.i, 34]` | **MISSING** |
| `ENTRY_TYPE` | 15383 | `"S"` | web |
| `FIX_WEST_PRC` | 15419 | `Conversion.Val(mSG[DC_Main.i, 16])` | not-in-desktop-schema |
| `GHT_AMT` | 15430 | `Conversion.Val(mSG[DC_Main.i, 28])` | **MISSING** |
| `HD_VCH_NO` | 15379 | `tHdVchNo.Text` | **MISSING** |
| `HM_AMT` | 15439 | `0` | **MISSING** |
| `HM_ID` | 15405 | `mSG[DC_Main.i, 9]` | web |
| `HM_ID2` | 15456 | `mSG[DC_Main.i, 86]` | **MISSING** |
| `HM_ID2_WT` | 15460 | `Conversion.Val(mSG[DC_Main.i, 90])` | **MISSING** |
| `HM_ID3` | 15457 | `mSG[DC_Main.i, 87]` | **MISSING** |
| `HM_ID3_WT` | 15461 | `Conversion.Val(mSG[DC_Main.i, 91])` | **MISSING** |
| `HM_ID4` | 15458 | `mSG[DC_Main.i, 88]` | **MISSING** |
| `HM_ID4_WT` | 15462 | `Conversion.Val(mSG[DC_Main.i, 92])` | **MISSING** |
| `HM_ID_WT` | 15459 | `Conversion.Val(mSG[DC_Main.i, 89])` | **MISSING** |
| `INOUT_TYPE` | 15382 | `FormBookInOut` | web |
| `ISU_DBCD` | 15454 | `mSG[DC_Main.i, 80]` | web |
| `ISU_LC_CODE` | 15452 | `DC_Main.MLc_code` | **MISSING** |
| `ISU_NO` | 15451 | `mSG[DC_Main.i, 78]` | web |
| `ISU_SRNO` | 15455 | `Conversion.Val(mSG[DC_Main.i, 81])` | web |
| `ISU_YRCD` | 15453 | `mSG[DC_Main.i, 79]` | web |
| `ITM_AMT` | 15434 | `Conversion.Val(mSG[DC_Main.i, 23])` | web |
| `ITM_FINE` | 15423 | `Conversion.Val(mSG[DC_Main.i, 20])` | web |
| `ITM_GHT_PRC` | 15418 | `Conversion.Val(mSG[DC_Main.i, 15])` | **MISSING** |
| `ITM_GHT_WT` | 15420 | `Conversion.Val(mSG[DC_Main.i, 17])` | web |
| `ITM_GWT` | 15408 | `Conversion.Val(mSG[DC_Main.i, 12])` | web |
| `ITM_LOT` | 15471 | `mSG[DC_Main.i, 2]` | **MISSING** |
| `ITM_MRP` | 15435 | `Conversion.Val(mSG[DC_Main.i, 30])` | web |
| `ITM_NWT` | 15411 | `Conversion.Val(mSG[DC_Main.i, 14])` | web |
| `ITM_OTH_WT` | 15410 | `Conversion.Val(mSG[DC_Main.i, 13])` | web |
| `ITM_PCS` | 15407 | `Conversion.Val(mSG[DC_Main.i, 11])` | web |
| `ITM_RATE` | 15433 | `Conversion.Val(mSG[DC_Main.i, 22])` | web |
| `ITM_REMARK` | 15449 | `mSG[DC_Main.i, 75]` | **MISSING** |
| `ITM_SIZE` | 15404 | `mSG[DC_Main.i, 8]` | web |
| `ITM_STYLE` | 15403 | `mSG[DC_Main.i, 7]` | **MISSING** |
| `ITM_TOUCH` | 15421 | `Conversion.Val(mSG[DC_Main.i, 18])` | web |
| `ITM_WEST_PRC` | 15422 | `Conversion.Val(mSG[DC_Main.i, 19])` | web |
| `IT_CODE` | 15387 | `mSG[DC_Main.i, 3]` | web |
| `IT_TYPE` | 15447 | `mSG[DC_Main.i, 59]` | web |
| `KR_FINE` | 15443 | `Conversion.Val(mSG[DC_Main.i, 48])` | **MISSING** |
| `KR_NAME` | 15445 | `mSG[DC_Main.i, 41]` | **MISSING** |
| `KR_NET_WT` | 15440 | `Conversion.Val(mSG[DC_Main.i, 43])` | **MISSING** |
| `KR_TOUCH` | 15441 | `Conversion.Val(mSG[DC_Main.i, 46])` | **MISSING** |
| `KR_WEST_PRC` | 15442 | `Conversion.Val(mSG[DC_Main.i, 47])` | **MISSING** |
| `LBR_AMT` | 15427 | `Conversion.Val(mSG[DC_Main.i, 27])` | web |
| `LBR_PRC` | 15424 | `Conversion.Val(mSG[DC_Main.i, 24])` | web |
| `LBR_RATE` | 15426 | `Conversion.Val(mSG[DC_Main.i, 26])` | web |
| `LBR_TYPE` | 15425 | `mSG[DC_Main.i, 25]` | web |
| `LC_CODE` | 15374 | `DC_Main.MLc_code` | web |
| `MAIN_USER` | 15488 | `MainUser` | **MISSING** |
| `NET_AMT` | 15438 | `Conversion.Val(mSG[DC_Main.i, 37])` | web |
| `OLD_SRNO` | 15386 | `Conversion.Val(mSG[DC_Main.i, 57])` | web |
| `ORD_DBCD` | 15467 | `mSG[DC_Main.i, 95]` | web |
| `ORD_LC_CODE` | 15465 | `DC_Main.MLc_code` | **MISSING** |
| `ORD_NO` | 15401 | `mSG[DC_Main.i, 5]` | web |
| `ORD_SRNO` | 15468 | `Conversion.Val(mSG[DC_Main.i, 96])` | web |
| `ORD_TAG_STK_ADD` | 15469 | `mSG[DC_Main.i, 100]` | **MISSING** |
| `ORD_YRCD` | 15466 | `mSG[DC_Main.i, 94]` | web |
| `OTH_AMT` | 15431 | `Conversion.Val(mSG[DC_Main.i, 29])` | web |
| `PR_CODE` | 15448 | `mSG[DC_Main.i, 61]` | **MISSING** |
| `RATE_TYPE` | 15446 | `mSG[DC_Main.i, 58]` | **MISSING** |
| `RATE_WITH` | 15432 | `mSG[DC_Main.i, 21]` | **MISSING** |
| `SR_NO` | 15385 | `Conversion.Val(mSG[DC_Main.i, 0])` | web |
| `TAG_COST` | 15444 | `Conversion.Val(mSG[DC_Main.i, 38])` | **MISSING** |
| `TAG_GWT` | 15409 | `Conversion.Val(mSG[DC_Main.i, 97])` | **MISSING** |
| `TAG_NO` | 15390 | `"N"` | web |
| `TAG_NWT` | 15412 | `Conversion.Val(mSG[DC_Main.i, 98])` | **MISSING** |
| `TAX_PRC` | 15437 | `Conversion.Val(mSG[DC_Main.i, 36])` | web |
| `TBL_CODE` | 15393 | `"001"` | web |
| `TOT_AMT` | 15436 | `Conversion.Val(mSG[DC_Main.i, 35])` | web |
| `VCH_DATE` | 15378 | `mVchDate.Text` | web |
| `VCH_NO` | 15377 | `tVchNo.Text` | web |
| `VCH_SRNO` | 15450 | `Conversion.Val(mSG[DC_Main.i, 52])` | web |
| `VCH_TIME` | 15472 | `mVchDate.Text + " " + mTime.Text` | **MISSING** |
| `VCH_TYPE` | 15381 | `FormBookSname` | web |
