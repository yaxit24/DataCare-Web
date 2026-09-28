# Desktop write set — PR_DETL

Source: `TR_PURC.cs:13077`–`13193` (`dataRow3`). The form writes `PR_*` or `KR_*` depending on
the book: `MAIN_BOOK = 'KARIGAR RECEIPT'` or `'OLD ITEM SALES'` selects `KR_DATA/KR_DETL/KR_IDTL`
(TR_PURC.cs:11830-11845), otherwise `PR_DATA/PR_DETL/PR_IDTL` (11861-11864).

- Assigned: **85** (81 in the desktop schema) | already persisted **40** | **MISSING 41**

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_CODE` | 13092 | `tAcCode.Text` | web |
| `BAG_TOT` | 13109 | `Conversion.Val(mSG_PR[DC_Main.i, 10])` | not-in-desktop-schema |
| `BAG_WT` | 13107 | `Conversion.Val(mSG_PR[DC_Main.i, 8])` | **MISSING** |
| `BOOK_NAME` | 13096 | `FormMainBook` | web |
| `COMM_AMT` | 13141 | `Conversion.Val(mSG_PR[DC_Main.i, 42])` | **MISSING** |
| `COMM_PRC` | 13140 | `Conversion.Val(mSG_PR[DC_Main.i, 41])` | **MISSING** |
| `CONV_PRC` | 13132 | `Conversion.Val(mSG_PR[DC_Main.i, 28])` | **MISSING** |
| `CONV_RATE` | 13131 | `Conversion.Val(mSG_PR[DC_Main.i, 27])` | **MISSING** |
| `CO_BOOK` | 13088 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 13085 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 13087 | `DC_Main.MCo_year` | web |
| `DESIGN_NO` | 13103 | `mSG_PR[DC_Main.i, 4]` | **MISSING** |
| `ENTRY_TYPE` | 13095 | `"P"` | web |
| `FINE_CUT_FINE` | 13192 | `Conversion.Val(mSG_PR[DC_Main.i, 63])` | **MISSING** |
| `FINE_CUT_GWT` | 13190 | `Conversion.Val(mSG_PR[DC_Main.i, 61])` | **MISSING** |
| `FINE_CUT_NWT` | 13191 | `Conversion.Val(mSG_PR[DC_Main.i, 62])` | **MISSING** |
| `FINE_CUT_PCS` | 13189 | `Conversion.Val(mSG_PR[DC_Main.i, 60])` | **MISSING** |
| `HD_VCH_NO` | 13091 | `tHdVchNo.Text` | web |
| `INOUT_TYPE` | 13094 | `FormBookInOut` | web |
| `ITM_AMT` | 13138 | `Conversion.Val(mSG_PR[DC_Main.i, 31])` | web |
| `ITM_FINE` | 13122 | `Conversion.Val(mSG_PR[DC_Main.i, 24])` | web |
| `ITM_GHT_PRC` | 13117 | `Conversion.Val(mSG_PR[DC_Main.i, 19])` | **MISSING** |
| `ITM_GHT_WT` | 13118 | `Conversion.Val(mSG_PR[DC_Main.i, 20])` | web |
| `ITM_GWT` | 13110 | `Conversion.Val(mSG_PR[DC_Main.i, 12])` | web |
| `ITM_LESS_TCH` | 13121 | `Conversion.Val(mSG_PR[DC_Main.i, 23])` | **MISSING** |
| `ITM_LOSS_WT` | 13112 | `Conversion.Val(mSG_PR[DC_Main.i, 14])` | **MISSING** |
| `ITM_LOT` | 13105 | `mSG_PR[DC_Main.i, 6]` | **MISSING** |
| `ITM_MRP` | 13139 | `Conversion.Val(mSG_PR[DC_Main.i, 39])` | **MISSING** |
| `ITM_NWT` | 13116 | `Conversion.Val(mSG_PR[DC_Main.i, 18])` | web |
| `ITM_OTH_FINE` | 13130 | `Conversion.Val(mSG_PR[DC_Main.i, 38])` | web |
| `ITM_OTH_RATE` | 13129 | `Conversion.Val(mSG_PR[DC_Main.i, 37])` | **MISSING** |
| `ITM_OTH_WT` | 13111 | `Conversion.Val(mSG_PR[DC_Main.i, 13])` | **MISSING** |
| `ITM_PCS` | 13108 | `Conversion.Val(mSG_PR[DC_Main.i, 9])` | web |
| `ITM_RATE` | 13136 | `Conversion.Val(mSG_PR[DC_Main.i, 29])` | web |
| `ITM_SIZE` | 13106 | `""` | **MISSING** |
| `ITM_TOUCH` | 13119 | `Conversion.Val(mSG_PR[DC_Main.i, 21])` | web |
| `ITM_WEST_PRC` | 13120 | `Conversion.Val(mSG_PR[DC_Main.i, 22])` | web |
| `IT_CODE` | 13099 | `mSG_PR[DC_Main.i, 1]` | web |
| `IT_DESC` | 13100 | `mSG_PR[DC_Main.i, 2]` | **MISSING** |
| `IT_TYPE` | 13146 | `mSG_PR[DC_Main.i, 45]` | web |
| `KR_NAME` | 13186 | `""` | **MISSING** |
| `KUNDAN_FINE` | 13115 | `Conversion.Val(mSG_PR[DC_Main.i, 17])` | not-in-desktop-schema |
| `KUNDAN_TOUCH` | 13114 | `Conversion.Val(mSG_PR[DC_Main.i, 16])` | not-in-desktop-schema |
| `KUNDAN_WT` | 13113 | `Conversion.Val(mSG_PR[DC_Main.i, 15])` | not-in-desktop-schema |
| `LBR_AMT` | 13127 | `Conversion.Val(mSG_PR[DC_Main.i, 35])` | web |
| `LBR_PRC` | 13124 | `Conversion.Val(mSG_PR[DC_Main.i, 32])` | web |
| `LBR_RATE` | 13126 | `Conversion.Val(mSG_PR[DC_Main.i, 34])` | web |
| `LBR_TYPE` | 13125 | `mSG_PR[DC_Main.i, 33]` | web |
| `LC_CODE` | 13086 | `DC_Main.MLc_code` | web |
| `LOT_NO` | 13104 | `mSG_PR[DC_Main.i, 5]` | **MISSING** |
| `MAIN_USER` | 13173 | `MainUser` | web |
| `MCX_RATE` | 13133 | `0` | **MISSING** |
| `NET_AMT` | 13144 | `Conversion.Val(mSG_PR[DC_Main.i, 44])` | web |
| `OLD_SRNO` | 13098 | `Conversion.Val(mSG_PR[DC_Main.i, 57])` | web |
| `OTH_AMT` | 13128 | `Conversion.Val(mSG_PR[DC_Main.i, 36])` | web |
| `PRM_AMT` | 13134 | `0` | **MISSING** |
| `PRM_DISC` | 13135 | `0` | **MISSING** |
| `PR_CODE` | 13147 | `mSG_PR[DC_Main.i, 64]` | **MISSING** |
| `RATE_TYPE` | 13145 | `mSG_PR[DC_Main.i, 46]` | web |
| `SILVER_FINE` | 13123 | `Conversion.Val(mSG_PR[DC_Main.i, 26])` | web |
| `SL_BILL_DBCD` | 13172 | `tSlBill_DbCd.Text` | **MISSING** |
| `SL_BILL_LC` | 13170 | `DC_Main.MLc_code` | **MISSING** |
| `SL_BILL_NO` | 13169 | `tSlBill.Text` | **MISSING** |
| `SL_BILL_YRCD` | 13171 | `DC_Main.MCo_year` | **MISSING** |
| `SR_NO` | 13097 | `Conversion.Val(mSG_PR[DC_Main.i, 0])` | web |
| `TAG_COST` | 13184 | `0` | **MISSING** |
| `TAG_FINE` | 13179 | `0` | **MISSING** |
| `TAG_LBR_AMT` | 13182 | `0` | **MISSING** |
| `TAG_LBR_PRC` | 13180 | `0` | **MISSING** |
| `TAG_LBR_RATE` | 13181 | `0` | **MISSING** |
| `TAG_MRP` | 13185 | `0` | **MISSING** |
| `TAG_NO` | 13101 | `"N"` | web |
| `TAG_OTH_AMT` | 13183 | `0` | **MISSING** |
| `TAG_TOUCH` | 13177 | `0` | **MISSING** |
| `TAG_WEST_PRC` | 13178 | `0` | **MISSING** |
| `TAX_PRC` | 13143 | `Conversion.Val(mSG_PR[DC_Main.i, 43])` | web |
| `TBL_CODE` | 13102 | `mSG_PR[DC_Main.i, 3]` | **MISSING** |
| `TOT_AMT` | 13142 | `Conversion.Val(mSG_PR[DC_Main.i, 40])` | web |
| `URD_RATE_TYPE` | 13137 | `mSG_PR[DC_Main.i, 30]` | **MISSING** |
| `VCH_DATE` | 13090 | `mVchDate.Text` | web |
| `VCH_NO` | 13089 | `tVchNo.Text` | web |
| `VCH_SRNO` | 13188 | `0` | web |
| `VCH_TIME` | 13148 | `mVchDate.Text + " " + mTime.Text` | web |
| `VCH_TYPE` | 13093 | `FormBookSname` | web |
| `WITH_STOCK` | 13151 | `mSG_PR[DC_Main.i, 7]` | **MISSING** |
