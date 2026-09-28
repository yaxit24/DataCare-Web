# TR_BUL_BOOKING

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_BUL_BOOKING.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** AC_DATA, BUL_DATA, REMARK_DATA, ROJ_MEL_DATA, TEMP_BOOK_DATA

## Tables read
- BUL_DATA, AC_MAST, TEMP_BOOK_DATA, ITEM_MAST, EMP_MAST, LOCT_MAST, USER_SET, REMARK_DATA, AC_DATA, ROJ_MEL_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2421: DELETE BUL_DATA
- L3069: DELETE TEMP_BOOK_DATA
- L3149: DELETE BUL_DATA
- L3257: INSERT DELETE_DATA
- L3259: DELETE REMARK_DATA
- L3260: DELETE TEMP_BOOK_DATA
- L3261: DELETE AC_DATA
- L3262: DELETE ROJ_MEL_DATA
- L3265: DELETE BUL_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
