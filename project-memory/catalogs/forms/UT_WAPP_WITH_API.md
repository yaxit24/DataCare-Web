# UT_WAPP_WITH_API

- **Module:** utility
- **Source:** `src/csharp/DataCareNext/UT_WAPP_WITH_API.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** LEDR_AC_DATA, POINT_MAST
- **UPDATE:** POINT_MAST

## Tables deleted / reversed
- **DELETE:** LEDR_AC_DATA, MSG_MAST, POINT_MAST

## Tables read
- AC_MAST, AD_MEMB, ADD_MAST, MSG_MAST, AD_DATA, LEDR_AC_DATA, POINT_MAST, USER_SET, LOGIN_MAST, AD_MAST, AC_DATA, RATE_MAST

## Save / operation sequence (ordered; consecutive dups collapsed)
- L4244: DELETE MSG_MAST
- L5099: DELETE LEDR_AC_DATA
- L5122: INSERT LEDR_AC_DATA
- L5394: UPDATE POINT_MAST
- L5398: INSERT POINT_MAST
- L5414: DELETE POINT_MAST

## Validation guards (heuristic, user-facing messages)
- All variables fill First...
- DB Save Error :
- API Error :
- Media upload failed.
- Media Uploaded Successfully.\r\nMedia ID:
- Upload Error:
