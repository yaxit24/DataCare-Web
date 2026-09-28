# UT_TAG_PRINT

- **Module:** utility
- **Source:** `src/csharp/DataCareNext/UT_TAG_PRINT.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** TAG_PRINT_DATA
- **UPDATE:** BAR_DETL, PRINT_MAST

## Tables deleted / reversed
- **DELETE:** TAG_PRINT_DATA

## Tables read
- BAR_DETL, ITEM_MAST, GROUP_MAST, BAR_IDTL, TABLE_MAST, PRINT_MAST, TAG_PRINT_DATA, BAR_CAN_DETL, BOOK_DATA, PRODUCT_MAST, MAIN_STOCK, USER_SET

## Save / operation sequence (ordered; consecutive dups collapsed)
- L5087: UPDATE BAR_DETL
- L5143: DELETE TAG_PRINT_DATA
- L5151: INSERT TAG_PRINT_DATA
- L5641: UPDATE PRINT_MAST

## Validation guards (heuristic, user-facing messages)
- (none detected)
