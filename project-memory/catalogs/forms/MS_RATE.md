# MS_RATE

- **Module:** master
- **Source:** `src/csharp/DataCareNext/MS_RATE.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** RATE_MAST
- **UPDATE:** GROUP_MAST

## Tables deleted / reversed
- **DELETE:** RATE_MAST

## Tables read
- RATE_MAST, GROUP_MAST, USER_SET, EMP_MAST, LOCT_MAST, BOOK_IDTL

## Save / operation sequence (ordered; consecutive dups collapsed)
- L1894: DELETE RATE_MAST
- L1932: UPDATE GROUP_MAST
- L1944: DELETE RATE_MAST
- L1945: INSERT RATE_MAST
- L2063: DELETE RATE_MAST
- L2086: INSERT RATE_MAST
- L2106: DELETE RATE_MAST

## Validation guards (heuristic, user-facing messages)
- (none detected)
