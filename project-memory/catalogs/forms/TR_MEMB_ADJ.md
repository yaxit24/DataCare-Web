# TR_MEMB_ADJ

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_MEMB_ADJ.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** AD_MEMB

## Tables deleted / reversed
- **DELETE:** AC_DATA, AD_ADJ, AD_OS, REMARK_DATA, ROJ_MEL_DATA, TEMP_BOOK_DATA

## Tables read
- AD_ADJ, AD_OS, TEMP_BOOK_DATA, AC_MAST, EMP_MAST, AD_MAST, AC_DATA, ROJ_MEL_DATA, USER_SET, AD_MEMB, REMARK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2721: DELETE AD_ADJ
- L2726: DELETE TEMP_BOOK_DATA
- L2817: UPDATE AD_MEMB
- L2822: DELETE AD_OS
- L2824: DELETE AC_DATA
- L2827: DELETE ROJ_MEL_DATA
- L2887: INSERT DELETE_DATA
- L2889: DELETE REMARK_DATA
- L2890: DELETE TEMP_BOOK_DATA
- L2891: DELETE AC_DATA
- L2892: DELETE ROJ_MEL_DATA
- L2893: DELETE AD_OS
- L2894: DELETE AD_ADJ

## Validation guards (heuristic, user-facing messages)
- (none detected)
