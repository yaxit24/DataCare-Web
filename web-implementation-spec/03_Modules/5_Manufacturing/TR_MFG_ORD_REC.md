# TR_MFG_ORD_REC — Final Receive against an Order (variant stub)

```
Form: TR_MFG_ORD_REC  ·  Module: 5_Manufacturing  ·  Type: transaction (metal-flow; order-driven)
Desktop: unified/src/csharp/DataCareNext/TR_MFG_ORD_REC.cs + Ac_Stock.Mfg_Stk_Rec_With_Ord
Web target: apps/api/src/modules/manufacturing/mfg.ts (receiveMfg + assembly + order close) — phase E
Status: ⬛ UNBUILT (order variant of TR_MFG_ISU_REC) · Parity: 06_Parity/manufacturing.md
```

Base engine in [`TR_MFG_ISU_REC.md`](TR_MFG_ISU_REC.md). Pairs with
[`TR_MFG_ORD_ISU.md`](TR_MFG_ORD_ISU.md). Active when `MsMfgWithOrder='Y'`.

## Purpose
The **final receive** that closes an order's manufacturing: the assembled piece comes back, its
assembly breakdown is recorded, and the finished good is posted to sellable stock.

## Deltas vs TR_MFG_ISU_REC
- **`MFG_ASMBL_DETL`** (52 cols) written: assembly breakdown carrying `REC_YRCD/REC_DBCD/REC_NO/REC_SRNO`,
  `ORD_*`, `ITM_*`, `LBR_AMT/OTH_AMT/NET_AMT/LOT_NO`.
- **Finished goods to `MAIN_STOCK`** via `Ac_Stock.Mfg_Stk_Rec_With_Ord` — OUT from the in-process
  karigar (`SR_NO 98`), IN as finished (`SR_NO 99`), for the `MINO/STNG/POLISH ISU ↔ GHAT/MINO/STNG REC`
  pairings. _(src: `Ac_Stock.cs` `Mfg_Stk_Rec_With_Ord`; spec-mfg §4.)_
- `MFG_ISU_REC` projected as a **receive** (`ITM_SIGN='+'`, scrap cols filled).
- Order line state advanced/closed on the consumed `SL_ORD_DETL`.

## Footprint
`MFG_DATA`/`MFG_DETL`/`MFG_IDTL` + `MFG_ASMBL_DETL` → `MFG_ISU_REC` (receive) → `MAIN_STOCK`
(finished IN); `APR_DETL`/`MENU_DATA`/`TAG_PRINT_DATA`/`DELETE_DATA` per MODULE_MAP.

## Build note / risks
Needs `MFG_ASMBL_DETL` Prisma model + the order schema additions. The finished-stock SR_NO 98/99
convention must be reproduced so stock nets correctly. Confirm the exact stage pairings driving
`Mfg_Stk_Rec_With_Ord` in a golden-master pass.
