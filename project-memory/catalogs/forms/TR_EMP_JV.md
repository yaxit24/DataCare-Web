# TR_EMP_JV

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_EMP_JV.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** —
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** AC_DATA, APR_IDTL, EMP_DATA, REMARK_DATA, ROJ_MEL_DATA, TEMP_BOOK_DATA

## Tables read
- EMP_DATA, AC_MAST, TEMP_BOOK_DATA, EMP_MAST, AC_DATA, ROJ_MEL_DATA, USER_SET, APR_IDTL, REMARK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2887: DELETE EMP_DATA
- L2888: DELETE APR_IDTL
- L2891: DELETE TEMP_BOOK_DATA
- L2955: DELETE AC_DATA
- L2958: DELETE ROJ_MEL_DATA
- L3032: DELETE REMARK_DATA
- L3033: DELETE TEMP_BOOK_DATA
- L3034: DELETE AC_DATA
- L3035: DELETE ROJ_MEL_DATA
- L3036: DELETE EMP_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
