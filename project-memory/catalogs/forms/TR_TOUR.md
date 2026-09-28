# TR_TOUR

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_TOUR.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** APR_DETL, BAR_DETL

## Tables deleted / reversed
- **DELETE:** APR_DATA, APR_DETL, APR_IDTL, MAIN_STOCK, TEMP_BOOK_DATA

## Tables read
- APR_DETL, APR_DATA, TEMP_BOOK_DATA, ITEM_MAST, MAIN_STOCK, APR_IDTL, EMP_MAST, TAG_IMAGE_DATA, DM_MAST, BAR_IDTL, TABLE_MAST, BAR_DETL, USER_SET, RATE_CUT_ISU

## Save / operation sequence (ordered; consecutive dups collapsed)
- L5089: DELETE APR_DATA
- L5090: DELETE APR_DETL
- L5091: DELETE APR_IDTL
- L5094: DELETE TEMP_BOOK_DATA
- L5283: DELETE MAIN_STOCK
- L5287: UPDATE APR_DETL
- L5291: UPDATE BAR_DETL
- L5293: DELETE MAIN_STOCK
- L5299: UPDATE BAR_DETL
- L5301: DELETE MAIN_STOCK
- L5386: INSERT DELETE_DATA
- L5390: UPDATE APR_DETL
- L5394: UPDATE BAR_DETL
- L5402: DELETE TEMP_BOOK_DATA
- L5403: DELETE MAIN_STOCK
- L5404: DELETE APR_DATA
- L5405: DELETE APR_DETL
- L5406: DELETE APR_IDTL

## Validation guards (heuristic, user-facing messages)
- (none detected)
