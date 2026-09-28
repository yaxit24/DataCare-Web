# RP_BAL_ZOOM

- **Module:** report
- **Source:** `src/csharp/DataCareNext/RP_BAL_ZOOM.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** LEDR_AC_DATA, REPORT_DATA
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** AC_DATA, LEDR_AC_DATA, REPORT_DATA

## Tables read
- AC_DATA, AC_GROUP, LEDR_AC_DATA, MAIN_STOCK, AC_MAST, RATE_MAST, REPORT_DATA, BOOK_DATA, LOCT_MAST, USER_SET

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2179: DELETE AC_DATA
- L4691: DELETE REPORT_DATA
- L4693: INSERT REPORT_DATA
- L4732: DELETE LEDR_AC_DATA
- L4739: INSERT LEDR_AC_DATA
- L4939: DELETE AC_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
