# TR_MFG_WITH_LOT — Lot merge / untagged-lot consumption (variant stub)

```
Form: TR_MFG_WITH_LOT  ·  Module: 5_Manufacturing  ·  Type: transaction (metal-flow; lot)
Desktop: unified/src/csharp/DataCareNext/TR_MFG_WITH_LOT.cs (#L5946-L6337) + Ac_Stock.Itm_Mfg_Lot
Web target: apps/api/src/modules/manufacturing/mfg.ts (lot variant) — phase E
Status: ⬛ UNBUILT (lot variant; schema gap) · Parity: 06_Parity/manufacturing.md
```

Base engine in [`TR_MFG_ISU_REC.md`](TR_MFG_ISU_REC.md). Active when `DC_Main.MsMfgWithLot='Y'`.

## Purpose
A **lot-merge** UI (`MSG_ADJ` grid + "Lot Merge" checkbox) that re-keys several working lots onto one,
and consumes **untagged stock lots** (`MAIN_STOCK` rows with `ITM_LOT<>'' AND TAG_NO='N'`) into the
process.

## Deltas vs TR_MFG_ISU_REC
- **`ITM_LOT`** (a consumed stock lot, distinct from the working `LOT_NO`) resolved from
  `MAIN_STOCK ... WHERE ITM_LOT<>'' AND TAG_NO='N'`.
- **`LOT_DETL`** written via `Ac_Stock.Itm_Mfg_Lot` — the 29-col lot ledger
  (`...,IT_PCS,IT_GWT,IT_NWT,IT_SIGN,...,ITM_LOT,...`). _(src: `Ac_Stock.cs#L624-L644` `INSERT INTO LOT_DETL`.)_
- Full engine writes `MFG_DATA/DETL/IDTL/MFG_ISU_REC/MAIN_STOCK + LOT_DETL` (`TR_MFG_WITH_LOT.cs#L5946-L6337`).

## Footprint
`MFG_DATA`/`MFG_DETL`/`MFG_IDTL` → `MFG_ISU_REC` → `MAIN_STOCK` + `LOT_DETL`; `MENU_DATA`/
`TAG_PRINT_DATA`/`DELETE_DATA` per MODULE_MAP.

## Build note / risks
**Blocked on schema:** `MFG_ISU_REC` lacks `ITM_LOT, LAST_IR_TYPE, REC_YRCD/DBCD/NO/SRNO, CON_PRC`
(spec-mfg §5). Add via migration behind the `MsMfgWithLot` flag before building. `grep ITM_LOT` over
`apps/api/src` → only `mfg.ts` passing `lotNo` (no lot-merge). Defer until phase E.
