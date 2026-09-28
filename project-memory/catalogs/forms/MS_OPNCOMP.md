# MS_OPNCOMP

- **Module:** master
- **Source:** `src/csharp/DataCareNext/MS_OPNCOMP.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** AC_MAST_SRNO
- **UPDATE:** BOOK_IDTL, CO_SET, MENU_DATA

## Tables deleted / reversed
- **DELETE:** AC_MAST_SRNO

## Tables read
- LOCT_MAST, CO_MAST, YEAR_MAST, AC_MAST_SRNO, AC_MAST, RATE_MAST, HDD_MAST, CO_SET, CO_SET_NEW, POINT_MAST, AC_GROUP, EMP_MAST, TAG_IMAGE_DATA, SL_IDTL, BOOK_IDTL

## Save / operation sequence (ordered; consecutive dups collapsed)
- L1411: INSERT AC_MAST_SRNO
- L1505: UPDATE CO_SET
- L2242: DELETE AC_MAST_SRNO
- L4351: UPDATE BOOK_IDTL
- L5067: UPDATE MENU_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
