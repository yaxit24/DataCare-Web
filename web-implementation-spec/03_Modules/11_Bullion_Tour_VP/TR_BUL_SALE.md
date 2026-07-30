# TR_BUL_SALE — Bullion Sales (stub)

```
Form: TR_BUL_SALE ("Bullion Sales")  ·  Module: 11_Bullion_Tour_VP  ·  Type: transaction (posting)
Desktop source: unified/src/csharp/DataCareNext/TR_BUL_SALE.cs (422 KB) → BUL_DATA (drawdown) + AC_DATA + TAX_DATA
Web target: NEW apps/api/src/modules/bullion/bullionSale.ts (proposed) — extends bullion.ts
Book: BULLION   ·   Status: 📋 SPEC · ⬛ UNBUILT (only the booking side exists)
Evidence: form catalog project-memory/catalogs/forms/TR_BUL_SALE.md
```

> Sibling of [`TR_BUL_BOOKING`](TR_BUL_BOOKING.md). The booking reserves fine metal; **this form sells
> against it**, drawing the reserved quantity down and pricing it (rate + premium + GST).

## What it does
Picks one or more open `BUL_DATA` bookings, where the **balance to sell** = `ITM_GWT − ADJ_WT` (and
`ITM_NWT − ADJ_WT`), prices each at `ITM_RATE` + `PRM_AMT` premium, `AMT_TYPE` cash/bank, and posts a
sale: it **increments `BUL_DATA.ADJ_WT`** (drawdown), writes a balanced `AC_DATA` (Dr customer/cash ·
Cr bullion-sales + GST) and `TAX_DATA`, plus `MAIN_STOCK`/`RATE_CUT_*` where applicable.
`// src: TR_BUL_SALE.cs#L3204 (lblBook "Bullion Sales"); #L4581-L4588 (ITM_GWT−ADJ_WT, ITM_RATE, PRM_AMT, AMT_TYPE); #L8816/#L9101/#L9202 (UPDATE BUL_DATA)`

## Tables
**Writes/updates:** `BUL_DATA` (ADJ_WT drawdown), `AC_DATA` (balanced), `TAX_DATA`, `RATE_CUT_*`,
`ROJ_MEL_DATA`. **Reverses:** `AC_DATA, TAX_DATA, ROJ_MEL_DATA, MAIN_STOCK, RATE_CUT_DATA/ISU/REC,
SL_IDTL` + restore `BUL_DATA.ADJ_WT` + `DELETE_DATA`. `// src: TR_BUL_SALE.cs#L9200-L9215`
Refs: [BUL_DATA](../../02_Data_Model/tables/BUL_DATA.md) · [AC_DATA](../../02_Data_Model/tables/AC_DATA.md) ·
[RATE_CUT_DATA](../../02_Data_Model/tables/RATE_CUT_DATA.md).

## Posting shape
```
Dr  customer / cash        net (fine×rate + premium + GST)
Cr  bullion-sales          metal value
Cr  output GST             CGST+SGST | IGST
```
Money 2 dp, fine 3 dp, HALF-UP; GST split keeps the penny.

## API (proposed)
```ts
// POST /bullion/sale  (create) → 201 { vchNo, totals }
//   { partyAc, draws:[{ bookingKey, srNo, fine }], rate?, premium?, taxPct?, interState?, amtType? }
// DELETE /bullion/sale/:vchNo (delete) → { reversed:true }
```

## Parity / DoD
- `BUL_DATA.ADJ_WT` increases by exactly the sold fine; cannot exceed `ITM_GWT − ADJ_WT`.
- `AC_DATA` balances (Dr party / Cr bullion-sales + GST); `TAX_DATA` matches CGST+SGST/IGST shape.
- Delete restores `ADJ_WT` and reverses ledger/tax/stock; `DELETE_DATA` written; trial balance nets to zero.
- Crystal parity: `BullBookBill.rpt`, `BulCustBooking.rpt`, `BulCustAdjust.rpt`.

## Open questions
- **Not built.** Extends `bullion.ts`; needs the drawdown + sale ledger + GST.
- Confirm whether premium (`PRM_AMT`) is taxed and which ledger receives it; confirm the exact
  `RATE_CUT_*` rows a bullion sale writes (the catalog shows them but not the column flow). Golden-master pass.
