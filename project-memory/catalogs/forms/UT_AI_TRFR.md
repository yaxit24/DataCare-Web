# UT_AI_TRFR

- **Module:** utility
- **Source:** `src/csharp/DataCareNext/UT_AI_TRFR.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** BOOK_IDTL, TAG_DATA
- **UPDATE:** BAR_DETL, TAG_DATA

## Tables deleted / reversed
- **DELETE:** BOOK_IDTL, TAG_DATA, TAG_IMAGE_DATA

## Tables read
- TAG_IMAGE_DATA, TAG_DATA, BOOK_IDTL, GROUP_MAST, PRODUCT_MAST, USER_SET

## Save / operation sequence (ordered; consecutive dups collapsed)
- L149: DELETE TAG_IMAGE_DATA
- L2300: DELETE TAG_DATA
- L2320: INSERT TAG_DATA
- L2744: DELETE TAG_IMAGE_DATA
- L2761: UPDATE TAG_DATA
- L2786: UPDATE BAR_DETL
- L2833: DELETE BOOK_IDTL
- L2839: INSERT BOOK_IDTL

## Validation guards (heuristic, user-facing messages)
- Data loaded OK
- No rows found!
- Bulk Image Save Completed Successfully!
