# TR_CASH

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_CASH.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** AC_DATA, APR_IDTL, CASH_DATA, REMARK_DATA, ROJ_MEL_DATA, TEMP_BOOK_DATA

## Tables read
- CASH_DATA, TEMP_BOOK_DATA, AC_MAST, AC_DATA, EMP_MAST, ROJ_MEL_DATA, USER_SET, BOOK_DETL, APR_IDTL, REMARK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2988: DELETE CASH_DATA
- L2989: DELETE APR_IDTL
- L2992: DELETE TEMP_BOOK_DATA
- L3071: DELETE AC_DATA
- L3081: DELETE ROJ_MEL_DATA
- L3217: INSERT DELETE_DATA
- L3219: DELETE REMARK_DATA
- L3220: DELETE TEMP_BOOK_DATA
- L3221: DELETE AC_DATA
- L3222: DELETE ROJ_MEL_DATA
- L3223: DELETE CASH_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
