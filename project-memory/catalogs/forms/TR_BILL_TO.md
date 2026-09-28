# TR_BILL_TO

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_BILL_TO.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DELETE_DATA
- **UPDATE:** SL_DATA

## Tables deleted / reversed
- **DELETE:** AC_DATA, BILL_OS_DATA, CASH_DATA, MAIN_STOCK, REMARK_DATA, ROJ_MEL_DATA, SL_PR_DETL, TEMP_BOOK_DATA

## Tables read
- CASH_DATA, AC_MAST, TEMP_BOOK_DATA, BILL_OS_DATA, SL_PR_DETL, EMP_MAST, SL_DATA, RATE_MAST, ITEM_MAST, AC_DATA, ROJ_MEL_DATA, USER_SET, MAIN_STOCK, REMARK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L4745: DELETE CASH_DATA
- L4746: DELETE BILL_OS_DATA
- L4751: DELETE TEMP_BOOK_DATA
- L4861: DELETE SL_PR_DETL
- L4915: DELETE AC_DATA
- L4918: DELETE ROJ_MEL_DATA
- L4921: DELETE MAIN_STOCK
- L5027: INSERT DELETE_DATA
- L5029: DELETE REMARK_DATA
- L5030: DELETE TEMP_BOOK_DATA
- L5031: DELETE AC_DATA
- L5032: DELETE ROJ_MEL_DATA
- L5033: DELETE CASH_DATA
- L5034: DELETE BILL_OS_DATA
- L5035: DELETE SL_PR_DETL
- L5640: UPDATE SL_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
