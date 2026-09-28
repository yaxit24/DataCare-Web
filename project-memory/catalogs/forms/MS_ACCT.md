# MS_ACCT

- **Module:** master
- **Source:** `src/csharp/DataCareNext/MS_ACCT.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** AC_MAST
- **UPDATE:** AC_MAST

## Tables deleted / reversed
- **DELETE:** AC_DATA, AC_MAST, AC_MAST_SRNO, OP_DATA

## Tables read
- AC_MAST, AC_MAST_SRNO, AC_GROUP, OP_DATA, AC_DATA, STATE_MAST, CO_MAST, ADD_MAST, AD_MEMB, USER_SET

## Save / operation sequence (ordered; consecutive dups collapsed)
- L7760: DELETE AC_MAST
- L7864: DELETE OP_DATA
- L7888: DELETE AC_DATA
- L7914: DELETE AC_MAST_SRNO
- L8006: DELETE AC_MAST
- L8008: DELETE OP_DATA
- L8009: DELETE AC_DATA
- L8943: INSERT AC_MAST
- L9009: UPDATE AC_MAST

## Validation guards (heuristic, user-facing messages)
- (none detected)
