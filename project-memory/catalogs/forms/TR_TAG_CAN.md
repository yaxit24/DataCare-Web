# TR_TAG_CAN

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_TAG_CAN.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** BAR_DETL, MAIN_STOCK

## Tables deleted / reversed
- **DELETE:** BAR_CAN_DATA, BAR_CAN_DETL, BAR_CAN_IDTL, DM_DATA, LOT_DETL, MAIN_STOCK, TEMP_BOOK_DATA

## Tables read
- BAR_CAN_DATA, MAIN_STOCK, ITEM_MAST, LOT_DETL, TEMP_BOOK_DATA, BAR_CAN_IDTL, BAR_CAN_DETL, EMP_MAST, TAG_IMAGE_DATA, BAR_DETL, TABLE_MAST, DM_DATA, AC_MAST, BAR_IDTL, USER_SET

## Save / operation sequence (ordered; consecutive dups collapsed)
- L5050: DELETE BAR_CAN_DATA
- L5051: DELETE BAR_CAN_DETL
- L5052: DELETE BAR_CAN_IDTL
- L5055: DELETE TEMP_BOOK_DATA
- L5258: DELETE DM_DATA
- L5262: UPDATE BAR_DETL
- L5264: UPDATE MAIN_STOCK
- L5269: DELETE MAIN_STOCK
- L5273: DELETE LOT_DETL
- L5348: INSERT DELETE_DATA
- L5350: DELETE TEMP_BOOK_DATA
- L5351: DELETE MAIN_STOCK
- L5352: DELETE DM_DATA
- L5354: DELETE LOT_DETL
- L5356: DELETE BAR_CAN_DATA
- L5357: DELETE BAR_CAN_DETL
- L5358: DELETE BAR_CAN_IDTL

## Validation guards (heuristic, user-facing messages)
- (none detected)
