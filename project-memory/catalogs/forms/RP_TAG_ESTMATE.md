# RP_TAG_ESTMATE

- **Module:** report
- **Source:** `src/csharp/DataCareNext/RP_TAG_ESTMATE.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** TAG_STOCK_PRINT
- **UPDATE:** TAG_IMAGE_DATA

## Tables deleted / reversed
- **DELETE:** TAG_IMAGE_DATA, TAG_STOCK_PRINT

## Tables read
- TAG_IMAGE_DATA, TAG_STOCK_PRINT, MAIN_STOCK, BAR_DETL, PRODUCT_MAST, GROUP_MAST, BAR_IDTL, USER_SET, BOOK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L4545: DELETE TAG_STOCK_PRINT
- L4584: INSERT TAG_STOCK_PRINT
- L4847: DELETE TAG_IMAGE_DATA
- L5472: UPDATE TAG_IMAGE_DATA
- L5689: DELETE TAG_IMAGE_DATA
- L6246: UPDATE TAG_IMAGE_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
