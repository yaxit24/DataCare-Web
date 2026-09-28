# MS_MFG_MAST

- **Module:** master
- **Source:** `src/csharp/DataCareNext/MS_MFG_MAST.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** USER_SET
- **UPDATE:** BOOK_DATA, MENU_DATA, MFG_MAST, SL_ORD_DETL

## Tables deleted / reversed
- **DELETE:** MENU_DATA, MFG_DATA, MFG_DETL, MFG_IDTL, MFG_ISU_REC, MFG_MAST, TEMP_BOOK_DATA, USER_SET

## Tables read
- USER_SET, MFG_MAST, MFG_DATA, MENU_DATA, BOOK_DATA, LOCT_MAST, LOGIN_MAST, SL_ORD_DETL, TEMP_BOOK_DATA, MFG_ISU_REC, MFG_DETL, MFG_IDTL

## Save / operation sequence (ordered; consecutive dups collapsed)
- L1173: UPDATE BOOK_DATA
- L1174: DELETE MFG_MAST
- L1202: UPDATE MENU_DATA
- L1210: UPDATE BOOK_DATA
- L1214: UPDATE MENU_DATA
- L1218: UPDATE MFG_MAST
- L1224: UPDATE MENU_DATA
- L1650: DELETE MENU_DATA
- L1691: DELETE USER_SET
- L1733: INSERT USER_SET
- L1745: DELETE USER_SET
- L1753: INSERT USER_SET
- L1872: UPDATE SL_ORD_DETL
- L1874: DELETE TEMP_BOOK_DATA
- L1875: DELETE MFG_ISU_REC
- L1876: DELETE MFG_DATA
- L1877: DELETE MFG_DETL
- L1878: DELETE MFG_IDTL
- L1879: UPDATE MENU_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
