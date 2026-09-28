# UT_SMS

- **Module:** utility
- **Source:** `src/csharp/DataCareNext/UT_SMS.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** LEDR_AC_DATA, MSG_MAST
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** LEDR_AC_DATA, MSG_MAST

## Tables read
- AC_MAST, MSG_MAST, ADD_MAST, AD_MEMB, LEDR_AC_DATA, USER_SET, LOGIN_MAST, AD_MAST, AC_DATA, RATE_MAST

## Save / operation sequence (ordered; consecutive dups collapsed)
- L3693: DELETE MSG_MAST
- L3696: INSERT MSG_MAST
- L3746: DELETE MSG_MAST
- L4169: DELETE LEDR_AC_DATA
- L4196: INSERT LEDR_AC_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
