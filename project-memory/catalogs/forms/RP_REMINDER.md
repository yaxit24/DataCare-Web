# RP_REMINDER

- **Module:** report
- **Source:** `src/csharp/DataCareNext/RP_REMINDER.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** REPORT_DATA
- **UPDATE:** PR_DATA, RATE_CUT_DATA, SL_DATA, USER_REQUEST

## Tables deleted / reversed
- **DELETE:** REPORT_DATA

## Tables read
- DHRN_DATA, USER_REQUEST, REPORT_DATA, AD_MEMB, AD_DATA, AC_DATA, AC_MAST, ADD_MAST, USER_SET, REM_DATA, SL_ORD_DATA, BOOK_DATA, BILL_OS_DATA, RATE_CUT_DATA, AD_OS, WEB_DATA, PR_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2135: DELETE REPORT_DATA
- L2881: UPDATE SL_DATA
- L3050: UPDATE RATE_CUT_DATA
- L4094: DELETE REPORT_DATA
- L4096: INSERT REPORT_DATA
- L4498: UPDATE USER_REQUEST
- L4654: UPDATE PR_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
