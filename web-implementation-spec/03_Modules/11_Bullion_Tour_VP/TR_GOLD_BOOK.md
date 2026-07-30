# TR_GOLD_BOOK — Gold Booking (customer gold accumulation) (stub) ⚠️ semantics derived

```
Form: TR_GOLD_BOOK ("Gold Booking")  ·  Module: 11_Bullion_Tour_VP  ·  Type: transaction (posting)
Desktop source: unified/src/csharp/DataCareNext/TR_GOLD_BOOK.cs (118 KB) → DG_GOLD_DATA
Web target: NEW (not built)   ·   Status: 📋 SPEC · ⬛ UNBUILT
Evidence: form catalog project-memory/catalogs/forms/TR_GOLD_BOOK.md
```

> ⚠️ **UNCERTAIN — derived from the schema + decompiled source; confirm before building. Do NOT
> invent the exact accounting.** Caption `lblBook.Text = "Gold Booking"` / `this.Text = "Gold Booking"`.
> `// src: TR_GOLD_BOOK.cs#L1111, L1424`

## Likely behaviour (to confirm)
A **customer gold-accumulation / gold-savings booking**: a customer pays money that is converted to a
**fine-gram balance** at the day's rate and accumulated against their account (the desktop tracks a
per-account gold opening balance `MsAcGoldOpBal`). `ITM_SIGN '+'` accrues gold; `'-'` redeems/delivers
it. Each row in `DG_GOLD_DATA` carries the customer (`AC_CODE`/`AC_NAME`/`AC_MOBILE`), the rate
(`ITM_RATE`), amount (`ITM_AMT`), **fine grams** (`ITM_FINE`), the control ledger (`LDR_AC`), and GST
(`TAX_CODE`/`TAX_PRC`/`TAX_AMT`). `// src: TR_GOLD_BOOK.cs#L2007 (MsAcGoldOpBal); data: DG_GOLD_DATA`

This differs from a **member saving scheme** (`AD_*`, Module 10): gold-booking is an **ad-hoc
per-account gold balance** (grams), not a fixed monthly-installment scheme.

## Tables (footprint, from catalog)
**Writes:** `DG_GOLD_DATA` (+ `AC_DATA` + `ROJ_MEL_DATA`). **Reverses:** `DG_GOLD_DATA, AC_DATA,
ROJ_MEL_DATA, REMARK_DATA, TEMP_BOOK_DATA` + `DELETE_DATA`. `// src: TR_GOLD_BOOK.cs#L2758-L2764`
Refs: [DG_GOLD_DATA](../../02_Data_Model/tables/DG_GOLD_DATA.md) · [AC_DATA](../../02_Data_Model/tables/AC_DATA.md).

## Likely posting (to confirm)
```
Dr  cash/bank           ITM_AMT (+ tax)        ← money paid in
Cr  gold-booking liab.  ITM_AMT                ← obligation to deliver ITM_FINE grams later
[ track ITM_FINE (+) against the customer's gold balance ]
```

## Parity / DoD (once confirmed)
`DG_GOLD_DATA` row matches desktop (`ITM_RATE`/`ITM_AMT`/`ITM_FINE`/`ITM_SIGN`/`LDR_AC`/tax); balanced
`AC_DATA`; per-account gold (fine) balance correct after accrue/redeem; delete reverses + `DELETE_DATA`.
Crystal `MembGoldRpt.rpt`.

## Open questions (must resolve before build)
- Confirm this is **customer gold accumulation** (vs a vendor/own gold book) and the exact liability/
  control ledger (`LDR_AC`) flow, GST treatment, and how `ITM_SIGN '+'/'-'` maps to accrue vs deliver.
- Confirm how delivery/redemption converts the accumulated fine balance into a sale or stock-out.
- Requires a Docker golden-master pass on `TR_GOLD_BOOK.cs` + `DG_GOLD_DATA` real rows.
