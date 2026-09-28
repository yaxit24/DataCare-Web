# TR_CONTRA

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_CONTRA.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** AC_DATA, APR_IDTL, CONTRA_DATA, REMARK_DATA, ROJ_MEL_DATA, TEMP_BOOK_DATA

## Tables read
- CONTRA_DATA, TEMP_BOOK_DATA, AC_MAST, EMP_MAST, AC_DATA, ROJ_MEL_DATA, USER_SET, REMARK_DATA, APR_IDTL

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2739: DELETE CONTRA_DATA
- L2742: DELETE TEMP_BOOK_DATA
- L2884: DELETE AC_DATA
- L2887: DELETE ROJ_MEL_DATA
- L2961: INSERT DELETE_DATA
- L2963: DELETE REMARK_DATA
- L2964: DELETE TEMP_BOOK_DATA
- L2965: DELETE AC_DATA
- L2966: DELETE ROJ_MEL_DATA
- L2967: DELETE CONTRA_DATA
- L2968: DELETE APR_IDTL

## Validation guards (heuristic, user-facing messages)
- (none detected)
