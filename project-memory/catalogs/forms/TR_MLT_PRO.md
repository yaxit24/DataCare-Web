# TR_MLT_PRO

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_MLT_PRO.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** SL_DATA

## Tables deleted / reversed
- **DELETE:** MAIN_STOCK, MFG_DETL, MFG_ISU_REC, MLT_DATA, MLT_DETL, REMARK_DATA, TEMP_BOOK_DATA

## Tables read
- MLT_DATA, ITEM_MAST, MLT_DETL, TEMP_BOOK_DATA, AC_MAST, EMP_MAST, MFG_DETL, MFG_ISU_REC, MAIN_STOCK, USER_SET, REMARK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L4149: DELETE MLT_DATA
- L4150: DELETE MLT_DETL
- L4153: DELETE TEMP_BOOK_DATA
- L4319: DELETE MFG_DETL
- L4424: DELETE MAIN_STOCK
- L4427: DELETE MFG_ISU_REC
- L4511: INSERT DELETE_DATA
- L4513: DELETE REMARK_DATA
- L4514: DELETE TEMP_BOOK_DATA
- L4515: DELETE MAIN_STOCK
- L4516: DELETE MFG_ISU_REC
- L4517: DELETE MFG_DETL
- L4518: DELETE MLT_DATA
- L4519: DELETE MLT_DETL
- L4928: UPDATE SL_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
