# Ac_Stock

- **Module:** other
- **Source:** `src/csharp/DataCareNext/Ac_Stock.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DM_DATA, DM_KR_DATA, LOT_DETL, MAIN_STOCK, TAG_SUM_DATA
- **UPDATE:** BAR_DETL, INOUT_DETL, MAIN_STOCK

## Tables deleted / reversed
- **DELETE:** TAG_SUM_DATA

## Tables read
- BAR_DETL, SL_DETL, APR_DETL, SL_PR_DETL, RATE_CUT_ISU, BAR_CAN_DETL, LBR_ISU_DETL, DHRN_REC_DATA, MFG_DETL, ITM_OPBL, PR_DETL, RATE_CUT_REC, KR_DETL, LBR_REC_DETL, ITM_LOT_DETL, DHRN_ISU_DATA, INOUT_DETL, FAN_DETL, SL_ORD_DETL, SL_DETL_RTN, MLT_DETL, MFG_IDTL, CUT_STK_DETL, TAG_SUM_DATA, MAIN_STOCK

## Save / operation sequence (ordered; consecutive dups collapsed)
- L15: INSERT MAIN_STOCK
- L373: UPDATE INOUT_DETL
- L374: UPDATE BAR_DETL
- L375: INSERT MAIN_STOCK
- L624: INSERT LOT_DETL
- L654: INSERT MAIN_STOCK
- L682: DELETE TAG_SUM_DATA
- L683: UPDATE MAIN_STOCK
- L705: INSERT TAG_SUM_DATA
- L736: INSERT DM_DATA
- L756: INSERT DM_KR_DATA
- L762: INSERT MAIN_STOCK
- L776: INSERT DM_DATA
- L794: INSERT DM_KR_DATA
- L800: INSERT DM_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
