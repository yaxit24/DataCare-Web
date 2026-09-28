# RP_LEDR

- **Module:** report
- **Source:** `src/csharp/DataCareNext/RP_LEDR.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** FINE_DATA, LEDR_AC_DATA
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** FINE_DATA, LEDR_AC_DATA

## Tables read
- AC_DATA, AC_MAST, MAIN_STOCK, OP_LDR, FINE_DATA, USER_SET, LEDR_AC_DATA, RATE_CUT_DATA, MFG_DETL, PR_DATA, KR_DATA, KR_DETL, PR_DETL, MFG_DATA, SL_DATA, REMARK_DATA, AC_GROUP, RATE_CUT_ISU, LBR_DATA, LOCT_MAST, BOOK_DATA, LDR_ADJ_DATA, CUT_STK_DETL

## Save / operation sequence (ordered; consecutive dups collapsed)
- L6128: DELETE LEDR_AC_DATA
- L6135: INSERT LEDR_AC_DATA
- L8255: DELETE FINE_DATA
- L8256: INSERT FINE_DATA
- L8441: DELETE FINE_DATA
- L8455: INSERT FINE_DATA
- L8664: DELETE FINE_DATA
- L8683: INSERT FINE_DATA
- L8899: DELETE FINE_DATA
- L8900: INSERT FINE_DATA
- L9150: DELETE FINE_DATA
- L9151: INSERT FINE_DATA
- L11669: DELETE LEDR_AC_DATA
- L11677: INSERT LEDR_AC_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
