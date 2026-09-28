# MS_AUTO_ITEM

- **Module:** master
- **Source:** `src/csharp/DataCareNext/MS_AUTO_ITEM.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** —
- **UPDATE:** BAR_DETL, BAR_IDTL, CO_SET_NEW, ITEM_MAST

## Tables deleted / reversed
- **DELETE:** TOUCH_MAST

## Tables read
- MAIN_STOCK, BAR_DETL, ITEM_MAST, TOUCH_MAST, GROUP_MAST, PRODUCT_MAST, AC_MAST, CO_SET_NEW, USER_SET, BAR_IDTL

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2687: UPDATE ITEM_MAST
- L2699: UPDATE CO_SET_NEW
- L2725: UPDATE BAR_DETL
- L2748: UPDATE BAR_IDTL
- L2754: UPDATE BAR_DETL
- L2835: UPDATE ITEM_MAST
- L2842: DELETE TOUCH_MAST

## Validation guards (heuristic, user-facing messages)
- (none detected)
