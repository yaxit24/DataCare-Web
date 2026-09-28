# Desktop write set — SL_PR_DETL (old-gold purchase detail)

Source: `unified/src/csharp/DataCareNext/TR_SALE.cs:15630`–`15673`, row variable `dataRow7`, verified against its own `SELECT * FROM SL_PR_DETL`.

- Assigned columns: **35** (34 exist in the desktop production schema)
- Already persisted by the web: **25**
- **MISSING: 9**
- Desktop production table: present, 42 columns
- Web Prisma model: present

Implement each MISSING column from its cited expression. `MSG2_TOTAL[r,c]` = settlement grid,
`MSG_TOT[0,c]` = totals grid, `mSG4[i,c]` = item grid, `tXxx.Text` = header field.
Do not invent a value: if an expression cannot be resolved, record it in the form contract.

| Column | Line | Desktop value expression | Status |
|---|---:|---|---|
| `AC_CODE` | 15645 | `tAcCode.Text` | web |
| `BOOK_NAME` | 15649 | `FormMainBook` | web |
| `CON_PRC` | 15660 | `Conversion.Val(mSG_OLD[DC_Main.i, 9])` | **MISSING** |
| `CON_WT` | 15661 | `Conversion.Val(mSG_OLD[DC_Main.i, 10])` | **MISSING** |
| `CO_BOOK` | 15641 | `DC_Main.MCo_Book` | web |
| `CO_CODE` | 15638 | `DC_Main.MCo_code` | web |
| `CO_YEAR` | 15640 | `DC_Main.MCo_year` | web |
| `ENTRY_TYPE` | 15648 | `"A"` | web |
| `HD_VCH_NO` | 15644 | `tHdVchNo.Text` | web |
| `HM_ID2_WT` | 15669 | `0` | **MISSING** |
| `HM_ID3_WT` | 15670 | `0` | **MISSING** |
| `HM_ID4_WT` | 15671 | `0` | **MISSING** |
| `HM_ID_WT` | 15668 | `0` | **MISSING** |
| `INOUT_TYPE` | 15647 | `FormBookInOut` | web |
| `ITM_FINE` | 15659 | `Conversion.Val(mSG_OLD[DC_Main.i, 8])` | web |
| `ITM_GWT` | 15655 | `Conversion.Val(mSG_OLD[DC_Main.i, 4])` | web |
| `ITM_NWT` | 15657 | `Conversion.Val(mSG_OLD[DC_Main.i, 6])` | web |
| `ITM_OTH` | 15672 | `0` | **MISSING** |
| `ITM_OTH_WT` | 15656 | `Conversion.Val(mSG_OLD[DC_Main.i, 5])` | **MISSING** |
| `ITM_PCS` | 15654 | `Conversion.Val(mSG_OLD[DC_Main.i, 3])` | web |
| `ITM_RATE` | 15662 | `Conversion.Val(mSG_OLD[DC_Main.i, 11])` | web |
| `ITM_RATE_TYPE` | 15663 | `mSG_OLD[DC_Main.i, 12]` | **MISSING** |
| `ITM_TOUCH` | 15658 | `Conversion.Val(mSG_OLD[DC_Main.i, 7])` | web |
| `IT_CODE` | 15651 | `mSG_OLD[DC_Main.i, 1]` | web |
| `IT_DESC` | 15653 | `mSG_OLD[DC_Main.i, 2]` | web |
| `IT_TYPE` | 15652 | `mSG_OLD[DC_Main.i, 14]` | web |
| `LC_CODE` | 15639 | `DC_Main.MLc_code` | web |
| `MAIN_USER` | 15667 | `MainUser` | web |
| `NET_AMT` | 15664 | `Conversion.Val(mSG_OLD[DC_Main.i, 13])` | web |
| `PR_COST` | 15665 | `Conversion.Val(mSG_OLD[DC_Main.i, 17])` | not-in-desktop-schema |
| `SR_NO` | 15650 | `Conversion.Val(mSG_OLD[DC_Main.i, 0])` | web |
| `VCH_DATE` | 15643 | `mVchDate.Text` | web |
| `VCH_NO` | 15642 | `tVchNo.Text` | web |
| `VCH_TIME` | 15666 | `mVchDate.Text + " " + mTime.Text` | web |
| `VCH_TYPE` | 15646 | `FormBookSname` | web |
