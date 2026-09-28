# TR_ITM_LOT

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_ITM_LOT.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** TAG_PRINT_DATA
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** BAR_DATA, ITM_LOT_DETL, MAIN_STOCK, REMARK_DATA, TAG_PRINT_DATA, TEMP_BOOK_DATA

## Tables read
- BAR_DATA, TEMP_BOOK_DATA, ITM_LOT_DETL, AC_MAST, ITEM_MAST, EMP_MAST, MAIN_STOCK, TAG_IMAGE_DATA, TAG_PRINT_DATA, USER_SET, REMARK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L3757: DELETE BAR_DATA
- L3758: DELETE ITM_LOT_DETL
- L3761: DELETE TEMP_BOOK_DATA
- L3891: DELETE MAIN_STOCK
- L3926: DELETE REMARK_DATA
- L3927: DELETE TEMP_BOOK_DATA
- L3928: DELETE BAR_DATA
- L3929: DELETE ITM_LOT_DETL
- L4328: DELETE TAG_PRINT_DATA
- L4335: INSERT TAG_PRINT_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
