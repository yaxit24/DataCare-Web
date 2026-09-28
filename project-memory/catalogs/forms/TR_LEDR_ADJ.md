# TR_LEDR_ADJ

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_LEDR_ADJ.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** —
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** AC_DATA, LDR_ADJ_DATA, REMARK_DATA, ROJ_MEL_DATA, TEMP_BOOK_DATA

## Tables read
- LDR_ADJ_DATA, TEMP_BOOK_DATA, AC_MAST, EMP_MAST, AC_DATA, ROJ_MEL_DATA, USER_SET, REMARK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2932: DELETE LDR_ADJ_DATA
- L2935: DELETE TEMP_BOOK_DATA
- L3003: DELETE AC_DATA
- L3006: DELETE ROJ_MEL_DATA
- L3153: DELETE REMARK_DATA
- L3154: DELETE TEMP_BOOK_DATA
- L3155: DELETE AC_DATA
- L3156: DELETE ROJ_MEL_DATA
- L3157: DELETE LDR_ADJ_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
