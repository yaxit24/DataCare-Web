# TR_VP_ADJ

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_VP_ADJ.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** RATE_CUT_DATA

## Tables deleted / reversed
- **DELETE:** AC_DATA, ROJ_MEL_DATA, TEMP_BOOK_DATA, VP_ADJ_DATA

## Tables read
- VP_ADJ_DATA, TEMP_BOOK_DATA, AC_MAST, RATE_CUT_DATA, EMP_MAST, AC_DATA, ROJ_MEL_DATA, USER_SET, BOOK_DETL

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2631: UPDATE RATE_CUT_DATA
- L2634: DELETE VP_ADJ_DATA
- L2639: DELETE TEMP_BOOK_DATA
- L2705: UPDATE RATE_CUT_DATA
- L2707: DELETE AC_DATA
- L2710: DELETE ROJ_MEL_DATA
- L2758: INSERT DELETE_DATA
- L2760: UPDATE RATE_CUT_DATA
- L2770: DELETE AC_DATA
- L2776: DELETE TEMP_BOOK_DATA
- L2777: DELETE AC_DATA
- L2778: DELETE ROJ_MEL_DATA
- L2779: DELETE VP_ADJ_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
