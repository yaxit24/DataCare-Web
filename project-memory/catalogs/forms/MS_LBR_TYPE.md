# MS_LBR_TYPE

- **Module:** master
- **Source:** `src/csharp/DataCareNext/MS_LBR_TYPE.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** —
- **UPDATE:** BAR_DETL

## Tables deleted / reversed
- **DELETE:** LBR_MAST

## Tables read
- LBR_MAST, PRODUCT_MAST, GROUP_MAST, USER_SET, BAR_DETL

## Save / operation sequence (ordered; consecutive dups collapsed)
- L1312: DELETE LBR_MAST
- L1349: UPDATE BAR_DETL
- L1430: DELETE LBR_MAST

## Validation guards (heuristic, user-facing messages)
- (none detected)
