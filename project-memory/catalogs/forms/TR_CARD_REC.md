# TR_CARD_REC

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_CARD_REC.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** AC_DATA, CARD_DATA, DHRN_DATA, DHRN_REC_DETL, MAIN_STOCK, REMARK_DATA, ROJ_MEL_DATA, TEMP_BOOK_DATA

## Tables read
- CARD_DATA, AC_MAST, TEMP_BOOK_DATA, EMP_MAST, DHRN_REC_DETL, AC_DATA, ROJ_MEL_DATA, USER_SET, REMARK_DATA, DHRN_DATA, MAIN_STOCK

## Save / operation sequence (ordered; consecutive dups collapsed)
- L3271: DELETE CARD_DATA
- L3272: DELETE DHRN_REC_DETL
- L3275: DELETE TEMP_BOOK_DATA
- L3334: DELETE AC_DATA
- L3337: DELETE ROJ_MEL_DATA
- L3398: INSERT DELETE_DATA
- L3400: DELETE REMARK_DATA
- L3401: DELETE TEMP_BOOK_DATA
- L3402: DELETE DHRN_DATA
- L3403: DELETE AC_DATA
- L3404: DELETE ROJ_MEL_DATA
- L3405: DELETE MAIN_STOCK
- L3406: DELETE CARD_DATA
- L3407: DELETE DHRN_REC_DETL

## Validation guards (heuristic, user-facing messages)
- (none detected)
