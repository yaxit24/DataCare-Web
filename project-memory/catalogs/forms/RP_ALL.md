# RP_ALL

- **Module:** report
- **Source:** `src/csharp/DataCareNext/RP_ALL.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** RATE_CUT_ISU_REC
- **UPDATE:** SL_ORD_DETL

## Tables deleted / reversed
- **DELETE:** RATE_CUT_ISU_REC

## Tables read
- AC_MAST, RATE_CUT_ISU_REC, PRINT_MAST, SL_ORD_DATA, BOOK_DATA, RATE_CUT_ISU, AD_MEMB, AD_MAST, PRODUCT_MAST, LOCT_MAST, RATE_CUT_REC, GROUP_MAST, USER_SET, EMP_MAST, SL_DETL, SL_DETL_RTN, LBR_ISU_DETL, LBR_REC_DETL

## Save / operation sequence (ordered; consecutive dups collapsed)
- L8924: DELETE RATE_CUT_ISU_REC
- L8925: INSERT RATE_CUT_ISU_REC
- L9055: DELETE RATE_CUT_ISU_REC
- L9056: INSERT RATE_CUT_ISU_REC
- L10933: UPDATE SL_ORD_DETL
- L11000: DELETE RATE_CUT_ISU_REC
- L11001: INSERT RATE_CUT_ISU_REC
- L11276: DELETE RATE_CUT_ISU_REC
- L11277: INSERT RATE_CUT_ISU_REC
- L11843: UPDATE SL_ORD_DETL
- L12031: DELETE RATE_CUT_ISU_REC
- L12032: INSERT RATE_CUT_ISU_REC

## Validation guards (heuristic, user-facing messages)
- (none detected)
