# Ac_Ledr

- **Module:** other
- **Source:** `src/csharp/DataCareNext/Ac_Ledr.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** AC_DATA
- **UPDATE:** PR_DATA, PR_DETL, SL_DATA

## Tables deleted / reversed
- **DELETE:** —

## Tables read
- RATE_CUT_DATA, LBR_DATA, SL_DATA, DHRN_REC_DATA, PR_DATA, MFG_DATA, KR_DATA, DHRN_ISU_DATA, CUT_DATA, CASH_DATA, FAN_DATA, PAY_DATA, REP_DATA, LDR_ADJ_DATA, CARD_DATA, SL_ORD_DATA, OP_DATA, VP_ADJ_DATA, CONTRA_DATA, SL_ORD_ADJ, AD_ADJ, EMP_DATA, DG_GOLD_DATA, COMM_DATA, PR_DETL, REP_DETL

## Save / operation sequence (ordered; consecutive dups collapsed)
- L13: INSERT AC_DATA
- L63: UPDATE SL_DATA
- L64: INSERT AC_DATA
- L176: UPDATE SL_DATA
- L177: INSERT AC_DATA
- L275: UPDATE PR_DATA
- L276: INSERT AC_DATA
- L376: UPDATE PR_DATA
- L377: INSERT AC_DATA
- L483: UPDATE PR_DATA
- L484: UPDATE PR_DETL
- L485: INSERT AC_DATA
- L1323: UPDATE SL_DATA
- L1324: INSERT AC_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
