# MS_BOOK

- **Module:** master
- **Source:** `src/csharp/DataCareNext/MS_BOOK.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** —
- **UPDATE:** BOOK_DATA, BOOK_DETL

## Tables deleted / reversed
- **DELETE:** BOOK_DATA, BOOK_DETL

## Tables read
- BOOK_DATA, BOOK_DETL, EMP_MAST, AC_MAST, BOOK_IDTL, USER_SET, AC_DATA, MAIN_STOCK

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2608: DELETE BOOK_DATA
- L2610: DELETE BOOK_DETL
- L2721: DELETE BOOK_DATA
- L2722: DELETE BOOK_DETL
- L3078: UPDATE BOOK_DATA
- L3079: UPDATE BOOK_DETL

## Validation guards (heuristic, user-facing messages)
- (none detected)
