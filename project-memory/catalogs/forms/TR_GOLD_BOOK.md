# TR_GOLD_BOOK

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_GOLD_BOOK.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** AC_DATA, DG_GOLD_DATA, REMARK_DATA, ROJ_MEL_DATA, TEMP_BOOK_DATA

## Tables read
- DG_GOLD_DATA, AC_MAST, TEMP_BOOK_DATA, EMP_MAST, TAX_MAST, AC_DATA, ROJ_MEL_DATA, USER_SET, REMARK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2634: DELETE DG_GOLD_DATA
- L2639: DELETE TEMP_BOOK_DATA
- L2710: DELETE AC_DATA
- L2713: DELETE ROJ_MEL_DATA
- L2758: INSERT DELETE_DATA
- L2760: DELETE REMARK_DATA
- L2761: DELETE TEMP_BOOK_DATA
- L2762: DELETE AC_DATA
- L2763: DELETE ROJ_MEL_DATA
- L2764: DELETE DG_GOLD_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
