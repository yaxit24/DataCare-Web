# Desktop write set — SL_ORD_DETL

Source: `TR_SALE_ORD.cs:9182`–`9309` (`dataRow3`), verified against its own `SELECT ... FROM SL_ORD_DETL`.

- Assigned **72** (72 in the desktop schema) | persisted **32** | **MISSING 40**

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_CODE` | 9199 | `tAcCode.Text` | web |
| `BAG_WT` | 9220 | `Conversion.Val(mSG[DC_Main.i, 7])` | **MISSING** |
| `BOOK_NAME` | 9203 | `FormMainBook` | web |
| `CO_BOOK` | 9195 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 9192 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 9194 | `DC_Main.MCo_year` | web |
| `DESIGN_IMG_ID` | 9297 | `mSG[DC_Main.i, 71]` | **MISSING** |
| `DESIGN_ISU` | 9263 | `mSG[DC_Main.i, 66]` | web |
| `DESIGN_NO` | 9217 | `mSG[DC_Main.i, 4]` | web |
| `EMP_CODE` | 9296 | `tEmpCode.Text` | **MISSING** |
| `ENTRY_TYPE` | 9202 | `"O"` | web |
| `HD_VCH_NO` | 9198 | `tHdVchNo.Text` | web |
| `HM_ID` | 9298 | `mSG[DC_Main.i, 72]` | **MISSING** |
| `HM_ID2` | 9299 | `mSG[DC_Main.i, 73]` | **MISSING** |
| `HM_ID2_WT` | 9303 | `Conversion.Val(mSG[DC_Main.i, 77])` | **MISSING** |
| `HM_ID3` | 9300 | `mSG[DC_Main.i, 74]` | **MISSING** |
| `HM_ID3_WT` | 9304 | `Conversion.Val(mSG[DC_Main.i, 78])` | **MISSING** |
| `HM_ID4` | 9301 | `mSG[DC_Main.i, 75]` | **MISSING** |
| `HM_ID4_WT` | 9305 | `Conversion.Val(mSG[DC_Main.i, 79])` | **MISSING** |
| `HM_ID_WT` | 9302 | `Conversion.Val(mSG[DC_Main.i, 76])` | **MISSING** |
| `INOUT_TYPE` | 9201 | `FormBookInOut` | web |
| `ITM_AMT` | 9248 | `Conversion.Val(mSG[DC_Main.i, 19])` | web |
| `ITM_COLOR` | 9218 | `mSG[DC_Main.i, 5]` | **MISSING** |
| `ITM_FINE` | 9229 | `Conversion.Val(mSG[DC_Main.i, 16])` | web |
| `ITM_GHT_PRC` | 9225 | `Conversion.Val(mSG[DC_Main.i, 12])` | **MISSING** |
| `ITM_GHT_WT` | 9226 | `Conversion.Val(mSG[DC_Main.i, 13])` | **MISSING** |
| `ITM_GWT` | 9222 | `Conversion.Val(mSG[DC_Main.i, 9])` | web |
| `ITM_MRP` | 9249 | `Conversion.Val(mSG[DC_Main.i, 25])` | **MISSING** |
| `ITM_NWT` | 9224 | `Conversion.Val(mSG[DC_Main.i, 11])` | web |
| `ITM_OTH_WT` | 9223 | `Conversion.Val(mSG[DC_Main.i, 10])` | **MISSING** |
| `ITM_PCS` | 9221 | `Conversion.Val(mSG[DC_Main.i, 8])` | web |
| `ITM_RATE` | 9247 | `Conversion.Val(mSG[DC_Main.i, 18])` | web |
| `ITM_REMARK` | 9207 | `mSG[DC_Main.i, 65]` | web |
| `ITM_SIZE` | 9219 | `mSG[DC_Main.i, 6]` | **MISSING** |
| `ITM_TOUCH` | 9227 | `Conversion.Val(mSG[DC_Main.i, 14])` | web |
| `ITM_WEST_PRC` | 9228 | `Conversion.Val(mSG[DC_Main.i, 15])` | **MISSING** |
| `IT_CODE` | 9206 | `mSG[DC_Main.i, 2]` | web |
| `IT_TYPE` | 9260 | `mSG[DC_Main.i, 49]` | **MISSING** |
| `KR_FINE` | 9257 | `Conversion.Val(mSG[DC_Main.i, 37])` | **MISSING** |
| `KR_NAME` | 9258 | `mSG[DC_Main.i, 30]` | **MISSING** |
| `KR_NET_WT` | 9254 | `Conversion.Val(mSG[DC_Main.i, 32])` | **MISSING** |
| `KR_TOUCH` | 9255 | `Conversion.Val(mSG[DC_Main.i, 35])` | **MISSING** |
| `KR_WEST_PRC` | 9256 | `Conversion.Val(mSG[DC_Main.i, 36])` | **MISSING** |
| `LBR_AMT` | 9233 | `Conversion.Val(mSG[DC_Main.i, 23])` | web |
| `LBR_PRC` | 9230 | `Conversion.Val(mSG[DC_Main.i, 20])` | **MISSING** |
| `LBR_RATE` | 9232 | `Conversion.Val(mSG[DC_Main.i, 22])` | **MISSING** |
| `LBR_TYPE` | 9231 | `mSG[DC_Main.i, 21]` | **MISSING** |
| `LC_CODE` | 9193 | `DC_Main.MLc_code` | web |
| `MAIN_USER` | 9307 | `MainUser` | web |
| `NET_AMT` | 9253 | `Conversion.Val(mSG[DC_Main.i, 29])` | web |
| `OLD_SRNO` | 9205 | `Conversion.Val(mSG[DC_Main.i, 47])` | **MISSING** |
| `OLD_TBL_CODE` | 9266 | `mSG[DC_Main.i, 69]` | **MISSING** |
| `ORD_DEL_DATE` | 9290 | `mSG[DC_Main.i, 26]` | **MISSING** |
| `ORD_REC_AMT` | 9306 | `0` | **MISSING** |
| `OTH_AMT` | 9234 | `Conversion.Val(mSG[DC_Main.i, 24])` | **MISSING** |
| `PR_CODE` | 9261 | `mSG[DC_Main.i, 51]` | **MISSING** |
| `RATE_FIX` | 9237 | `mSG[DC_Main.i, 17]` | **MISSING** |
| `RATE_TYPE` | 9259 | `mSG[DC_Main.i, 48]` | **MISSING** |
| `SR_NO` | 9204 | `Conversion.Val(mSG[DC_Main.i, 0])` | web |
| `TAG_COST` | 9250 | `Conversion.Val(mSG[DC_Main.i, 43])` | **MISSING** |
| `TAG_GEN` | 9264 | `mSG[DC_Main.i, 67]` | web |
| `TAG_NO` | 9210 | `"N"` | **MISSING** |
| `TAG_SALE` | 9265 | `mSG[DC_Main.i, 68]` | web |
| `TAG_STK_LESS` | 9267 | `mSG[DC_Main.i, 70]` | **MISSING** |
| `TAX_PRC` | 9252 | `Conversion.Val(mSG[DC_Main.i, 28])` | web |
| `TBL_CODE` | 9216 | `mSG[DC_Main.i, 3]` | **MISSING** |
| `TOT_AMT` | 9251 | `Conversion.Val(mSG[DC_Main.i, 27])` | web |
| `VCH_DATE` | 9197 | `mVchDate.Text` | web |
| `VCH_NO` | 9196 | `tVchNo.Text` | web |
| `VCH_SRNO` | 9262 | `Conversion.Val(mSG[DC_Main.i, 42])` | **MISSING** |
| `VCH_TIME` | 9308 | `mVchDate.Text + " " + mTime.Text` | web |
| `VCH_TYPE` | 9200 | `FormBookSname` | web |
