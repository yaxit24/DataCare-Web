# MS_DESIGN_BOOK

- **Module:** master
- **Source:** `src/csharp/DataCareNext/MS_DESIGN_BOOK.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** DESIGN_DETL
- **UPDATE:** —

## Tables deleted / reversed
- **DELETE:** DESIGN_DETL, DESIGN_IDTL, TAG_IMAGE_DATA

## Tables read
- DESIGN_DETL, DESIGN_IDTL, TAG_IMAGE_DATA, AC_MAST, ITEM_MAST, DM_MAST, GROUP_MAST, MODEL_MAST, EMP_MAST, PRODUCT_MAST, USER_SET, MAIN_STOCK

## Save / operation sequence (ordered; consecutive dups collapsed)
- L4652: DELETE DESIGN_DETL
- L4725: DELETE DESIGN_IDTL
- L4795: DELETE DESIGN_DETL
- L4796: DELETE DESIGN_IDTL
- L5354: DELETE TAG_IMAGE_DATA
- L5790: INSERT DESIGN_DETL

## Validation guards (heuristic, user-facing messages)
- (none detected)
