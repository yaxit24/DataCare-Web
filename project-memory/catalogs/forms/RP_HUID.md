# RP_HUID

- **Module:** report
- **Source:** `src/csharp/DataCareNext/RP_HUID.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** TAG_STOCK_PRINT
- **UPDATE:** BAR_DETL

## Tables deleted / reversed
- **DELETE:** TAG_STOCK_PRINT

## Tables read
- BAR_DETL, AC_MAST, TAG_STOCK_PRINT, USER_SET, PRODUCT_MAST, GROUP_MAST, BOOK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L1754: UPDATE BAR_DETL
- L2140: DELETE TAG_STOCK_PRINT
- L2179: INSERT TAG_STOCK_PRINT

## Validation guards (heuristic, user-facing messages)
- (none detected)
