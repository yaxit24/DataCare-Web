# Desktop write set — BAR_IDTL

Source: `unified/src/csharp/DataCareNext/TR_TAG_OPBL.cs` — lines 9398-9462 (`dataRow4`), lines 11191-11285 (`dataRow5`); each row variable verified against its own `SELECT ... FROM BAR_IDTL`.

- Assigned columns: **49** (48 in the desktop production schema)
- Already persisted: **40** | **MISSING: 8**

`mSG[i,c]` = tag grid, `tXxx.Text` = header field. Implement each MISSING column from its
cited expression; never invent a value.

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `BOOK_NAME` | 9416 | `FormMainBook` | web |
| `CO_BOOK` | 9410 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 9407 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 9409 | `DC_Main.MCo_year` | web |
| `DM_CODE` | 9429 | `mSG_IDTL[i, 3]` | web |
| `DM_COLOR` | 9431 | `mSG_IDTL[i, 5]` | web |
| `DM_NAME` | 9430 | `mSG_IDTL[i, 4]` | web |
| `DM_ORIGIN` | 9433 | `mSG_IDTL[i, 7]` | web |
| `DM_REMARK` | 9434 | `mSG_IDTL[i, 8]` | web |
| `DM_SFNO` | 9435 | `mSG_IDTL[i, 9]` | web |
| `DM_SIZE` | 9432 | `mSG_IDTL[i, 6]` | web |
| `ENTRY_TYPE` | 9415 | `"O"` | web |
| `INOUT_TYPE` | 9414 | `FormBookInOut` | web |
| `ISR_NO` | 9427 | `Conversion.Val(mSG_IDTL[i, 0])` | web |
| `IT_AMT` | 9447 | `Conversion.Val(mSG_IDTL[i, 23])` | web |
| `IT_CODE` | 9428 | `mSG_IDTL[i, 1]` | web |
| `IT_CON_PRC` | 9444 | `Conversion.Val(mSG_IDTL[i, 20])` | web |
| `IT_CON_WT` | 9459 | `Conversion.Val(mSG_IDTL[i, 35])` | web |
| `IT_DISC_AMT` | 9449 | `Conversion.Val(mSG_IDTL[i, 25])` | **MISSING** |
| `IT_DISC_PRC` | 9448 | `Conversion.Val(mSG_IDTL[i, 24])` | **MISSING** |
| `IT_GWT` | 9438 | `Conversion.Val(mSG_IDTL[i, 19])` | web |
| `IT_LBR_AMT` | 9457 | `Conversion.Val(mSG_IDTL[i, 33])` | web |
| `IT_LBR_RATE` | 9456 | `Conversion.Val(mSG_IDTL[i, 32])` | web |
| `IT_NET_AMT` | 9458 | `Conversion.Val(mSG_IDTL[i, 34])` | web |
| `IT_PCS` | 9436 | `Conversion.Val(mSG_IDTL[i, 12])` | web |
| `IT_PCS_WT` | 9437 | `Conversion.Val(mSG_IDTL[i, 13])` | web |
| `IT_RATE` | 9446 | `Conversion.Val(mSG_IDTL[i, 22])` | web |
| `IT_RATE_TYPE` | 9445 | `mSG_IDTL[i, 21]` | web |
| `IT_TYPE` | 9460 | `mSG_IDTL[i, 37]` | web |
| `KR_ACT_PRC` | 9440 | `Conversion.Val(mSG_IDTL[i, 15])` | **MISSING** |
| `KR_ACT_WT` | 9439 | `Conversion.Val(mSG_IDTL[i, 14])` | **MISSING** |
| `KR_AMT` | 9453 | `Conversion.Val(mSG_IDTL[i, 29])` | web |
| `KR_CON_PRC` | 9450 | `Conversion.Val(mSG_IDTL[i, 26])` | **MISSING** |
| `KR_CON_WT` | 11281 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][36]))` | web |
| `KR_LBR_AMT` | 9455 | `Conversion.Val(mSG_IDTL[i, 31])` | **MISSING** |
| `KR_LBR_RATE` | 9454 | `Conversion.Val(mSG_IDTL[i, 30])` | **MISSING** |
| `KR_LESS_PRC` | 9442 | `Conversion.Val(mSG_IDTL[i, 17])` | web |
| `KR_LESS_WT` | 9443 | `Conversion.Val(mSG_IDTL[i, 18])` | not-in-desktop-schema |
| `KR_RATE` | 9452 | `Conversion.Val(mSG_IDTL[i, 28])` | web |
| `KR_RATE_TYPE` | 9451 | `mSG_IDTL[i, 27]` | **MISSING** |
| `KR_WT` | 9441 | `Conversion.Val(mSG_IDTL[i, 16])` | web |
| `LC_CODE` | 9408 | `DC_Main.MLc_code` | web |
| `MAIN_USER` | 9461 | `MainUser` | web |
| `SR_NO` | 9417 | `L` | web |
| `TAG_NO` | 9418 | `MSG[L, 5]` | web |
| `VCH_DATE` | 9412 | `mVchDate.Text` | web |
| `VCH_NO` | 9411 | `tVchNo.Text` | web |
| `VCH_SRNO` | 9421 | `Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + Strings.Mid(mVchDate.Text, 10` | web |
| `VCH_TYPE` | 9413 | `FormBookSname` | web |
