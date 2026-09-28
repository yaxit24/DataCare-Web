# RP_STOCK

- **Module:** report
- **Source:** `src/csharp/DataCareNext/RP_STOCK.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** REPORT_DATA
- **UPDATE:** ITEM_MAST, MAIN_STOCK

## Tables deleted / reversed
- **DELETE:** REPORT_DATA

## Tables read
- APR_DETL, ITEM_MAST, REPORT_DATA, AC_MAST, MAIN_STOCK, USER_SET, PRODUCT_MAST, GROUP_MAST, LOCT_MAST, TABLE_MAST, BOOK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L3651: UPDATE ITEM_MAST
- L3653: UPDATE MAIN_STOCK
- L4058: DELETE REPORT_DATA
- L4064: INSERT REPORT_DATA
- L6222: DELETE REPORT_DATA
- L6351: INSERT REPORT_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
