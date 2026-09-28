# TR_OTH_PURC

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_OTH_PURC.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** AC_DATA, PAY_DATA, PAY_DETL, REMARK_DATA, ROJ_MEL_DATA, TAX_DATA, TEMP_BOOK_DATA

## Tables read
- AC_MAST, PAY_DATA, PAY_DETL, TAX_MAST, TEMP_BOOK_DATA, EMP_MAST, AC_DATA, ROJ_MEL_DATA, TAX_DATA, USER_SET, REMARK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L3699: DELETE PAY_DATA
- L3700: DELETE PAY_DETL
- L3703: DELETE TEMP_BOOK_DATA
- L3766: DELETE PAY_DETL
- L3815: DELETE AC_DATA
- L3818: DELETE ROJ_MEL_DATA
- L3821: DELETE TAX_DATA
- L3904: INSERT DELETE_DATA
- L3906: DELETE REMARK_DATA
- L3907: DELETE TEMP_BOOK_DATA
- L3908: DELETE AC_DATA
- L3909: DELETE ROJ_MEL_DATA
- L3910: DELETE TAX_DATA
- L3911: DELETE PAY_DATA
- L3912: DELETE PAY_DETL

## Validation guards (heuristic, user-facing messages)
- (none detected)
