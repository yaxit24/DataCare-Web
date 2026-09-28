# MS_ITEM

- **Module:** master
- **Source:** `src/csharp/DataCareNext/MS_ITEM.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** GROUP_MAST, PRODUCT_MAST
- **UPDATE:** BAR_DETL

## Tables deleted / reversed
- **DELETE:** ITEM_MAST

## Tables read
- ITEM_MAST, PRODUCT_MAST, GROUP_MAST, MAIN_STOCK, USER_SET, BAR_DETL

## Save / operation sequence (ordered; consecutive dups collapsed)
- L3226: DELETE ITEM_MAST
- L3889: INSERT PRODUCT_MAST
- L3900: INSERT GROUP_MAST
- L3980: UPDATE BAR_DETL

## Validation guards (heuristic, user-facing messages)
- (none detected)
