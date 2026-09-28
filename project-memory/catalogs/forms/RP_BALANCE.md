# RP_BALANCE

- **Module:** report
- **Source:** `src/csharp/DataCareNext/RP_BALANCE.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** AC_DATA
- **UPDATE:** BAL_GR

## Tables deleted / reversed
- **DELETE:** AC_DATA, LEDR_AC_DATA

## Tables read
- AC_DATA, RATE_MAST, LOCT_MAST, USER_SET, LEDR_AC_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2161: DELETE AC_DATA
- L2574: INSERT AC_DATA
- L2602: UPDATE BAL_GR
- L2653: DELETE AC_DATA
- L2655: DELETE LEDR_AC_DATA
- L2656: UPDATE BAL_GR

## Validation guards (heuristic, user-facing messages)
- (none detected)
