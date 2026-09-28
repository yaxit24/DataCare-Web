# RP_USER

- **Module:** report
- **Source:** `src/csharp/DataCareNext/RP_USER.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** REPORT_DATA, TAG_STOCK_PRINT
- **UPDATE:** USER_DATA

## Tables deleted / reversed
- **DELETE:** REPORT_DATA, TAG_STOCK_PRINT, USER_DATA

## Tables read
- AC_MAST, BOOK_DATA, MAIN_STOCK, TAG_STOCK_PRINT, AC_DATA, REPORT_DATA, SL_DATA, AD_DATA, UPI_DATA, CASH_DATA, USER_SET, LOGIN_MAST, USER_DATA, ITEM_MAST

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2128: DELETE TAG_STOCK_PRINT
- L2131: INSERT TAG_STOCK_PRINT
- L2560: UPDATE USER_DATA
- L2784: DELETE USER_DATA
- L3532: DELETE REPORT_DATA
- L3534: INSERT REPORT_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
