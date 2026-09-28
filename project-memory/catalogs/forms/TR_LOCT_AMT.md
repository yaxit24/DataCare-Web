# TR_LOCT_AMT

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_LOCT_AMT.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** AC_DATA, LOCT_AMT, REMARK_DATA, ROJ_MEL_DATA, TEMP_BOOK_DATA

## Tables read
- LOCT_AMT, LOCT_MAST, TEMP_BOOK_DATA, AC_MAST, EMP_MAST, AC_DATA, ROJ_MEL_DATA, USER_SET, REMARK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L3137: DELETE LOCT_AMT
- L3140: DELETE TEMP_BOOK_DATA
- L3206: DELETE LOCT_AMT
- L3319: DELETE AC_DATA
- L3322: DELETE ROJ_MEL_DATA
- L3471: INSERT DELETE_DATA
- L3473: DELETE REMARK_DATA
- L3476: DELETE TEMP_BOOK_DATA
- L3477: DELETE AC_DATA
- L3478: DELETE ROJ_MEL_DATA
- L3479: DELETE LOCT_AMT
- L3484: DELETE TEMP_BOOK_DATA
- L3485: DELETE AC_DATA
- L3486: DELETE ROJ_MEL_DATA
- L3487: DELETE LOCT_AMT

## Validation guards (heuristic, user-facing messages)
- (none detected)
