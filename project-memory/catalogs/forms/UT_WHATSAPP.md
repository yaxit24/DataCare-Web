# UT_WHATSAPP

- **Module:** utility
- **Source:** `src/csharp/DataCareNext/UT_WHATSAPP.cs`
- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._

## Tables written on save
- **INSERT:** LEDR_AC_DATA, MSG_MAST, POINT_MAST
- **UPDATE:** CO_SET_NEW, POINT_MAST

## Tables deleted / reversed
- **DELETE:** LEDR_AC_DATA, MSG_MAST, POINT_MAST

## Tables read
- AC_MAST, MSG_MAST, AD_MEMB, ADD_MAST, AD_DATA, LEDR_AC_DATA, POINT_MAST, USER_SET, LOGIN_MAST, CO_SET_NEW, AD_MAST, AC_DATA, RATE_MAST

## Save / operation sequence (ordered; consecutive dups collapsed)
- L5355: DELETE MSG_MAST
- L5358: INSERT MSG_MAST
- L5408: DELETE MSG_MAST
- L6359: DELETE LEDR_AC_DATA
- L6382: INSERT LEDR_AC_DATA
- L6673: UPDATE CO_SET_NEW
- L6745: UPDATE POINT_MAST
- L6749: INSERT POINT_MAST
- L6765: DELETE POINT_MAST

## Validation guards (heuristic, user-facing messages)
- Internet Connection Failed
- Message sent successfully!
- Failed to send message:
- WhatsApp not ready. Current state:
- File does not exists
