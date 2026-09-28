# TR_AC_OPBL

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_AC_OPBL.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** CONTRA_DATA, DELETE_DATA, OP_DATA, USER_DATA
- **UPDATE:** CONTRA_DATA

## Tables deleted / reversed
- **DELETE:** AC_DATA, OP_DATA

## Tables read
- OP_DATA, AC_DATA, AC_MAST, CONTRA_DATA, USER_SET, LOCT_MAST, BAL_GR

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2694: DELETE OP_DATA
- L2774: DELETE AC_DATA
- L2822: INSERT USER_DATA
- L2872: INSERT DELETE_DATA
- L2876: DELETE OP_DATA
- L2878: DELETE AC_DATA
- L3342: UPDATE CONTRA_DATA
- L3344: DELETE AC_DATA
- L3349: INSERT CONTRA_DATA
- L3353: DELETE AC_DATA
- L3393: DELETE OP_DATA
- L3403: INSERT OP_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
