# RP_ROJMEL

- **Module:** report
- **Source:** `src/csharp/DataCareNext/RP_ROJMEL.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** LEDR_AC_DATA, ROJMEL_BAL, TAG_STOCK_PRINT
- **UPDATE:** GROUP_MAST

## Tables deleted / reversed
- **DELETE:** LEDR_AC_DATA, ROJMEL_BAL, TAG_STOCK_PRINT

## Tables read
- AC_DATA, MAIN_STOCK, ROJ_MEL_DATA, AC_MAST, ROJMEL_BAL, RATE_CUT_DATA, SL_DATA, LEDR_AC_DATA, BOOK_DATA, UPI_DATA, KR_DATA, REP_DATA, USER_SET, LOCT_MAST, SL_ORD_DATA, CASH_DATA, CARD_DATA, PR_DATA, GROUP_MAST, TAG_STOCK_PRINT

## Save / operation sequence (ordered; consecutive dups collapsed)
- L3047: DELETE LEDR_AC_DATA
- L3055: INSERT LEDR_AC_DATA
- L3325: UPDATE GROUP_MAST
- L4927: DELETE TAG_STOCK_PRINT
- L4952: INSERT TAG_STOCK_PRINT
- L5840: DELETE ROJMEL_BAL
- L5842: INSERT ROJMEL_BAL

## Validation guards (heuristic, user-facing messages)
- (none detected)
