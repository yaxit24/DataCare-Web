# Desktop write set — SL_ORD_IDTL

Source: `TR_SALE_ORD.cs:9374`–`9415` (`dataRow5`), verified against its own `SELECT ... FROM SL_ORD_IDTL`.

- Assigned **34** (34 in the desktop schema) | persisted **20** | **MISSING 14**

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_CODE` | 9388 | `tAcCode.Text` | web |
| `BOOK_NAME` | 9392 | `FormMainBook` | web |
| `CO_BOOK` | 9384 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 9381 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 9383 | `DC_Main.MCo_year` | web |
| `DM_CODE` | 9398 | `RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][3])` | **MISSING** |
| `DM_NAME` | 9399 | `RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4])` | **MISSING** |
| `DM_SFNO` | 9401 | `RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6])` | **MISSING** |
| `DM_SIZE` | 9400 | `RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][5])` | **MISSING** |
| `ENTRY_TYPE` | 9391 | `"O"` | web |
| `HD_VCH_NO` | 9386 | `tHdVchNo.Text` | web |
| `INOUT_TYPE` | 9390 | `FormBookInOut` | web |
| `ISR_NO` | 9396 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0]))` | web |
| `IT_AMT` | 9408 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]))` | web |
| `IT_CODE` | 9397 | `RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1])` | web |
| `IT_CON_PRC` | 9405 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9]))` | **MISSING** |
| `IT_CON_WT` | 9412 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]))` | **MISSING** |
| `IT_GWT` | 9403 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8]))` | web |
| `IT_LBR_AMT` | 9410 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]))` | **MISSING** |
| `IT_LBR_RATE` | 9409 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]))` | **MISSING** |
| `IT_NET_AMT` | 9411 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]))` | web |
| `IT_PCS` | 9402 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7]))` | web |
| `IT_RATE` | 9407 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11]))` | **MISSING** |
| `IT_RATE_TYPE` | 9406 | `RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10])` | **MISSING** |
| `IT_TYPE` | 9413 | `RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19])` | **MISSING** |
| `KR_WT` | 9404 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]))` | **MISSING** |
| `LC_CODE` | 9382 | `DC_Main.MLc_code` | web |
| `MAIN_USER` | 9414 | `MainUser` | web |
| `SR_NO` | 9393 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]))` | web |
| `TAG_NO` | 9394 | `MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]))), 1]` | **MISSING** |
| `VCH_DATE` | 9387 | `mVchDate.Text` | web |
| `VCH_NO` | 9385 | `tVchNo.Text` | web |
| `VCH_SRNO` | 9395 | `Conversion.Val(MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]))` | **MISSING** |
| `VCH_TYPE` | 9389 | `FormBookSname` | web |
