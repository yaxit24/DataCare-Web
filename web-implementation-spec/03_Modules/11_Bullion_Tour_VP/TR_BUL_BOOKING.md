# TR_BUL_BOOKING — Bullion Booking (stub)

```
Form: TR_BUL_BOOKING ("Bullion Booking")  ·  Module: 11_Bullion_Tour_VP  ·  Type: transaction (posting)
Desktop source: unified/src/csharp/DataCareNext/TR_BUL_BOOKING.cs (138 KB) → BUL_DATA
Web target: apps/api/src/modules/bullion/bullion.ts → bullionBooking / deleteBullionBooking · routes/txn.ts (/bullion/booking)
Book: BUL / BULLION   ·   Status: 📋 SPEC · 🟩 BUILT
```

## Purpose
A party **books a bulk quantity of fine metal at a locked rate** for later delivery/settlement. The
header lands in `BUL_DATA` (`ITM_GWT`/`ITM_NWT` = fine booked, `ITM_RATE`, `ITM_AMT = fine × rate`,
`PRM_AMT` premium, `ADJ_WT = 0` until drawn down) and a **balanced** double-entry posts to `AC_DATA`.
A later **`TR_BUL_SALE`** draws the booking down via `ADJ_WT`. `// src: TR_BUL_BOOKING.cs#L1261 (lblBook "Bullion Booking")`

## Posting shape (web — `buildBookingLedger`)
```
Dr  party (AC_CODE)        amount        ← party owes the booked value
Cr  bullion-payable        amount        ← our obligation to deliver metal
[ if advance > 0 ]
Dr  cash (CASH)            advance        ← advance received now
Cr  party                  advance        ← reduces party receivable
```
`assertBalanced` guarantees ΣDR=ΣCR. `// web: bullion.ts → buildBookingLedger`

## Tables
**Writes:** `BUL_DATA` (header) + `AC_DATA` (balanced). **Reverses:** `BUL_DATA, AC_DATA` + `DELETE_DATA`.
Ref: [BUL_DATA](../../02_Data_Model/tables/BUL_DATA.md) · [AC_DATA](../../02_Data_Model/tables/AC_DATA.md).

## API
```ts
// POST /bullion/booking  (create) → 201 { vchNo, amount }   { partyAc, fineWt, rate, advanceAmt?, vchDate? }
// DELETE /bullion/:vchNo (delete) → { reversed:true }
```

## Parity / DoD
`BUL_DATA` header matches desktop (`ITM_GWT`/`ITM_NWT`=fine, `ITM_RATE`, `ITM_AMT`, `IT_TYPE` G/S,
`AMT_TYPE`, `ADJ_WT=0`); ledger Dr party / Cr `BULLION` (+advance) balances; delete reverses + logs.

## Open questions
- Web defaults the payable to `'BULLION'` and cash to `'CASH'`; confirm the real ledger codes from
  `BOOK_DETL`. `PRM_AMT` (premium), `RATE_TYPE`, and per-10g/per-kg rate conversions are accepted but
  the desktop's exact premium/tax treatment on a booking needs a golden-master pass.
- Verify `BUL_DATA.INOUT_TYPE`/`ENTRY_TYPE` flags ('I'/'S' in the web) against real rows.
