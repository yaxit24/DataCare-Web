# RP_DHRN_LOAN

- **Module:** report
- **Source:** `src/csharp/DataCareNext/RP_DHRN_LOAN.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DHRN_DATA
- **UPDATE:** DHRN_ISU_DATA

## Tables deleted / reversed
- **DELETE:** DHRN_DATA

## Tables read
- AC_MAST, DHRN_DATA, DHRN_ISU_DATA, LOCT_MAST, USER_SET, DHRN_REC_DATA, DHRN_ISU_DETL

## Save / operation sequence (ordered; consecutive dups collapsed)
- L2389: DELETE DHRN_DATA
- L2906: INSERT DHRN_DATA
- L3075: UPDATE DHRN_ISU_DATA

## Validation guards (heuristic, user-facing messages)
- Only Panding Packet Display = Yes Only Isu Packet = No Or All Packet = Cancel
