# TR_OTH_COMM

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_OTH_COMM.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** AC_DATA, PAY_DATA, PAY_DETL, REMARK_DATA, ROJ_MEL_DATA, TAX_DATA, TEMP_BOOK_DATA

## Tables read
- PAY_DATA, AC_MAST, TAX_MAST, TEMP_BOOK_DATA, PAY_DETL, EMP_MAST, ITEM_MAST, AC_DATA, ROJ_MEL_DATA, TAX_DATA, USER_SET, REMARK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L3522: DELETE PAY_DATA
- L3523: DELETE PAY_DETL
- L3526: DELETE TEMP_BOOK_DATA
- L3588: DELETE PAY_DETL
- L3637: DELETE AC_DATA
- L3640: DELETE ROJ_MEL_DATA
- L3643: DELETE TAX_DATA
- L3726: INSERT DELETE_DATA
- L3728: DELETE REMARK_DATA
- L3729: DELETE TEMP_BOOK_DATA
- L3730: DELETE AC_DATA
- L3731: DELETE ROJ_MEL_DATA
- L3732: DELETE TAX_DATA
- L3733: DELETE PAY_DATA
- L3734: DELETE PAY_DETL

## Validation guards (heuristic, user-facing messages)
- (none detected)
