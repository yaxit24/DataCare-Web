# TR_ITM_OPBL

- **Module:** transaction
- **Source:** `src/csharp/DataCareNext/TR_ITM_OPBL.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** —
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** DM_DATA, ITM_OPBL, MAIN_STOCK

## Tables read
- ITM_OPBL, MAIN_STOCK, DM_DATA, USER_SET, ITEM_MAST

## Save / operation sequence (ordered; consecutive dups collapsed)
- L1414: DELETE ITM_OPBL
- L1453: DELETE MAIN_STOCK
- L1456: DELETE DM_DATA
- L1509: DELETE MAIN_STOCK
- L1511: DELETE DM_DATA
- L1513: DELETE ITM_OPBL

## Validation guards (heuristic, user-facing messages)
- (none detected)
