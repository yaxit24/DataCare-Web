# TR_MEMB_ENT

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_MEMB_ENT.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA, TEMP_AD_DATA, USER_DATA
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** AC_DATA, AD_DATA, AD_OS, REMARK_DATA, ROJ_MEL_DATA, TEMP_AD_DATA, TEMP_BOOK_DATA, UPI_DATA

## Tables read
- AD_DATA, AC_MAST, UPI_DATA, AD_OS, AD_MEMB, TEMP_BOOK_DATA, AD_MAST, EMP_MAST, RATE_MAST, AC_DATA, ROJ_MEL_DATA, TEMP_AD_DATA, USER_SET, REMARK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L4528: DELETE AD_DATA
- L4533: DELETE TEMP_BOOK_DATA
- L4615: DELETE UPI_DATA
- L4649: DELETE AD_OS
- L4658: DELETE AC_DATA
- L4664: DELETE ROJ_MEL_DATA
- L4683: INSERT USER_DATA
- L4800: INSERT DELETE_DATA
- L4802: DELETE REMARK_DATA
- L4803: DELETE UPI_DATA
- L4804: DELETE TEMP_BOOK_DATA
- L4805: DELETE AC_DATA
- L4806: DELETE ROJ_MEL_DATA
- L4807: DELETE AD_OS
- L4808: DELETE AD_DATA
- L5381: DELETE TEMP_AD_DATA
- L5388: INSERT TEMP_AD_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
