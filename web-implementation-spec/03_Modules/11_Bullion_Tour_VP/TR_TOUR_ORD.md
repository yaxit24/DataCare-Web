# TR_TOUR_ORD — Tour Order / Sales Order on tour (stub)

```
Form: TR_TOUR_ORD ("Sales Order")  ·  Module: 11_Bullion_Tour_VP  ·  Type: transaction (posting)
Desktop source: unified/src/csharp/DataCareNext/TR_TOUR_ORD.cs (383 KB) → SL_ORD_* (order) + advance
Web target: NEW (extends sales/salesOrder.ts with the tour/salesman dimension)
Book: SALES ORDER (tour)   ·   Status: 📋 SPEC · ⬛ UNBUILT
```

> The **order** counterpart of the tour workflow: while on tour a salesman **books an order** (a
> customer commits to buy, often with an advance) rather than selling on the spot. Mirrors the
> retail `TR_SALE_ORD` but carries the salesman/`EMP_CODE` dimension. The order is later fulfilled by
> a sale (`TR_TOUR_SALE` / `TR_SALE`) and the advance adjusted. `// src: TR_TOUR_ORD.cs#L2529 (lblBook "Sales Order")`

## What it does
Records an order header + lines (design/item, expected weight, rate) and an **advance** received, with
no stock-out yet (goods not delivered). Posts the advance to `AC_DATA` (Dr cash/bank · Cr customer
advance) and stores the order in the `SL_ORD_*` tables; later adjusted on the fulfilling bill.

## Tables (footprint)
Order header/detail (`SL_ORD_DETL` and order tables) + `AC_DATA` (advance) + `ROJ_MEL_DATA`. Updated by
the fulfilling sale (`SL_ORD_ADJ`/`AD_ADJ`). Refs: [AC_DATA](../../02_Data_Model/tables/AC_DATA.md).

## API (proposed)
```ts
// POST /tour/order  (create) → 201 { vchNo }   { empCode, acCode, lines[], advanceAmount?, taxRatePct?, interState? }
```
Reuse `sales/salesOrder.ts → createSalesOrder` + the `EMP_CODE` field + tour book.

## Parity / DoD
Order rows + advance ledger match desktop; advance adjusts cleanly on fulfilment (no double count);
delete reverses order + advance + `DELETE_DATA`.

## Open questions
- **Not built.** Confirm the exact order table set (`SL_ORD_DETL` vs a tour-specific `TOUR_ORD_*`),
  the advance account, and whether tour orders share `salesOrder.ts` or need their own service.
  Crystal `TourOrdVch.rpt`/`OrdAdvRpt.rpt`. Golden-master pass.
