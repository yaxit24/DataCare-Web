# RP_STOCK_FINE

- **Module:** report
- **Source:** `src/csharp/DataCareNext/RP_STOCK_FINE.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** —
- **UPDATE:** BAL_GR, GROUP_MAST, ITEM_MAST

## Tables deleted / reversed
- **DELETE:** —

## Tables read
- MAIN_STOCK, ITEM_MAST, USER_SET, PRODUCT_MAST, GROUP_MAST, BOOK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L3471: UPDATE ITEM_MAST
- L3472: UPDATE GROUP_MAST
- L3473: UPDATE BAL_GR
- L3494: UPDATE ITEM_MAST
- L3531: UPDATE GROUP_MAST
- L3567: UPDATE BAL_GR

## Validation guards (heuristic, user-facing messages)
- (none detected)
