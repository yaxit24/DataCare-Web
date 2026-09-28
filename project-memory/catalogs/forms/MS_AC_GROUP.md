# MS_AC_GROUP

- **Module:** master
- **Source:** `src/csharp/DataCareNext/MS_AC_GROUP.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** AC_GROUP, BOOK_IDTL
- **UPDATE:** BOOK_IDTL

## Tables deleted / reversed
- **DELETE:** AC_GROUP

## Tables read
- AC_GROUP, BOOK_IDTL, USER_SET, AC_MAST

## Save / operation sequence (ordered; consecutive dups collapsed)
- L1809: DELETE AC_GROUP
- L1813: INSERT AC_GROUP
- L1896: DELETE AC_GROUP
- L2002: INSERT BOOK_IDTL
- L2008: UPDATE BOOK_IDTL

## Validation guards (heuristic, user-facing messages)
- (none detected)
