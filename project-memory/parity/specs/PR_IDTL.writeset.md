# Desktop write set — PR_IDTL

Source: `TR_PURC.cs:13203`–`13244` (`dataRow4`). The form writes `PR_*` or `KR_*` depending on
the book: `MAIN_BOOK = 'KARIGAR RECEIPT'` or `'OLD ITEM SALES'` selects `KR_DATA/KR_DETL/KR_IDTL`
(TR_PURC.cs:11830-11845), otherwise `PR_DATA/PR_DETL/PR_IDTL` (11861-11864).

- Assigned: **33** (33 in the desktop schema) | already persisted **0** | **MISSING 33**

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_CODE` | 13221 | `tAcCode.Text` | **MISSING** |
| `BOOK_NAME` | 13220 | `FormMainBook` | **MISSING** |
| `CO_BOOK` | 13214 | `DC_Main.MCo_Book` | **MISSING** |
| `CO_CODE` | 13211 | `DC_Main.MCo_code` | **MISSING** |
| `CO_YEAR` | 13213 | `DC_Main.MCo_year` | **MISSING** |
| `DM_CODE` | 13225 | `RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][3])` | **MISSING** |
| `DM_COLOR` | 13227 | `RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][5])` | **MISSING** |
| `DM_NAME` | 13226 | `RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][4])` | **MISSING** |
| `DM_ORIGIN` | 13229 | `RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][7])` | **MISSING** |
| `DM_REMARK` | 13230 | `RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][8])` | **MISSING** |
| `DM_SFNO` | 13231 | `RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][9])` | **MISSING** |
| `DM_SIZE` | 13228 | `RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][6])` | **MISSING** |
| `ENTRY_TYPE` | 13219 | `"P"` | **MISSING** |
| `INOUT_TYPE` | 13218 | `FormBookInOut` | **MISSING** |
| `ISR_NO` | 13223 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0]))` | **MISSING** |
| `IT_AMT` | 13237 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][18]))` | **MISSING** |
| `IT_CODE` | 13224 | `RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][1])` | **MISSING** |
| `IT_CON_PRC` | 13234 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][15]))` | **MISSING** |
| `IT_CON_WT` | 13241 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][22]))` | **MISSING** |
| `IT_GWT` | 13233 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][14]))` | **MISSING** |
| `IT_LBR_AMT` | 13239 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][20]))` | **MISSING** |
| `IT_LBR_RATE` | 13238 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][19]))` | **MISSING** |
| `IT_NET_AMT` | 13240 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][21]))` | **MISSING** |
| `IT_PCS` | 13232 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][12]))` | **MISSING** |
| `IT_RATE` | 13236 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][17]))` | **MISSING** |
| `IT_RATE_TYPE` | 13235 | `RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][16])` | **MISSING** |
| `IT_TYPE` | 13242 | `RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][23])` | **MISSING** |
| `LC_CODE` | 13212 | `DC_Main.MLc_code` | **MISSING** |
| `MAIN_USER` | 13243 | `MainUser` | **MISSING** |
| `SR_NO` | 13222 | `Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][24]))` | **MISSING** |
| `VCH_DATE` | 13216 | `mVchDate.Text` | **MISSING** |
| `VCH_NO` | 13215 | `tVchNo.Text` | **MISSING** |
| `VCH_TYPE` | 13217 | `FormBookSname` | **MISSING** |
