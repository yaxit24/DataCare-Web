# UT_CUST_ENTRY

- **Module:** utility
- **Source:** `src/csharp/DataCareNext/UT_CUST_ENTRY.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** —
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** CUST_DATA, CUST_DETL

## Tables read
- CUST_DATA, CUST_DETL, EMP_MAST, AC_MAST, ADD_MAST, ITEM_MAST, MAIN_STOCK, BAR_DETL, USER_SET

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2068: DELETE CUST_DATA
- L2108: DELETE CUST_DETL
- L2496: DELETE CUST_DATA
- L2551: DELETE CUST_DETL
- L2605: DELETE CUST_DATA
- L2606: DELETE CUST_DETL

## Validation guards (heuristic, user-facing messages)
- (none detected)
