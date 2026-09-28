# Ac_Tax

- **Module:** other
- **Source:** `src/csharp/DataCareNext/Ac_Tax.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** AD_OS, DHRN_DATA, MFG_ISU_REC, REMARK_DATA, SL_ORD_ADJ, TAX_DATA
- **UPDATE:** BAR_DATA

## Tables deleted / reversed
- **DELETE:** REMARK_DATA

## Tables read
- DHRN_REC_DATA, AD_ADJ, AD_DATA, DHRN_ISU_DATA, SL_ORD_DATA, REMARK_DATA, BOOK_DATA

## Save / operation sequence (ordered; consecutive dups collapsed)
- L13: INSERT AD_OS
- L35: INSERT DHRN_DATA
- L71: INSERT SL_ORD_ADJ
- L81: INSERT TAX_DATA
- L333: INSERT MFG_ISU_REC
- L671: INSERT REMARK_DATA
- L690: UPDATE BAR_DATA
- L694: DELETE REMARK_DATA
- L743: INSERT REMARK_DATA

## Validation guards (heuristic, user-facing messages)
- (none detected)
