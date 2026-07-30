# TR_MFG_GHAT_REC — Ghat (casting-gate) Receive (variant stub)

```
Form: TR_MFG_GHAT_REC  ·  Module: 5_Manufacturing  ·  Type: transaction (metal-flow)
Desktop: unified/src/csharp/DataCareNext/TR_MFG_GHAT_REC.cs + Ac_Tax.Ghat_Rec_Mfg
Web target: apps/api/src/modules/manufacturing/mfg.ts (receiveMfg, stage = MFG GHAT REC)
Status: ⬛ UNBUILT (variant of TR_MFG_ISU_REC) · Parity: 06_Parity/manufacturing.md
```

Full engine, fields, save/delete sequence, API and validation are documented in
[`TR_MFG_ISU_REC.md`](TR_MFG_ISU_REC.md) — this stub records **only the Ghat-receive deltas**.

## Purpose
The receive step right after casting: the cast tree comes back, metal is reclaimed from the
casting-gate/sprue (`ghat`), and filings (`chol`) / polishing dust (`ghis`) are returned. Book
`MFG GHAT REC` (`CO_BOOK 304`-era; `IR_TYPE='G'`, `LAST='G'`, `NEXT='R'`). _(src: `Mfg_Module.cs` MFG_MAST seed.)_

## Deltas vs TR_MFG_ISU_REC
- **Multi-row `MFG_ISU_REC` projection (3 rows / detail line, by `ISR_NO`):**
  1. `ISR_NO=1`, `ITM_SIGN='+'`, `IR_TYPE=ENTRY_TYPE`, `IR_WT=ITM_NWT`, **fills**
     `RTN_CHOL`, `RTN_GHIS`, `ITM_GHAT = ITM_GHT_WT + DM_GHT`, `RTN_MTRL = MTRL_WT`; `IR_*` back-pointer
     = `REP_YRCD/REP_DBCD/REP_NO/REP_SRNO/REP_AC_CODE` (the prior-process line).
  2. `ISR_NO=2`, `ITM_SIGN='-'`, gold (`C.IT_TYPE='G'`), `SR_NO>100`.
  3. `ISR_NO=3`, `ITM_SIGN='-'`, non-gold/diamond (`C.IT_TYPE<>'G'`), carries `DM_PCS/DM_WT`.
  _(src: `Ac_Tax.cs#L362` `Ghat_Rec_Mfg`; the `VS205NSBU` registration branch emits the 3-row split,
  the default branch emits the single `+` row.)_
- **`ITM_GHAT` includes `DM_GHT`** here (diamond ghat), unlike Filing/PrePolish which use plain `ITM_GHT_WT`.
- Reconciliation uses the standard `RecWt = IR_WT + RTN_CHOL + RTN_GHIS + ITM_GHAT + ITM_LOSS`
  (`TR_MFG_ISU_REC.cs#L5372`).

## Footprint
Writes `MFG_DATA`/`MFG_DETL`/`MFG_IDTL` → `MFG_ISU_REC` (multi-row). `MAIN_STOCK` only if its
`MFG_MAST` row sets a STK flag (Ghat Rec does **not** — `STK_REC='N'`). Also `APR_DETL`/`DELETE_DATA`
per MODULE_MAP. Reverse = same tables + `DELETE_DATA`.

## Build note / risks
The current web `receiveMfg` emits **one** `MFG_ISU_REC` row per line — it must be extended to the
**3-row** Ghat shape (and the Setting 2/3-row shape) before lot-fine balances reconcile (see
`TR_MFG_ISU_REC.md §11`). Map: `receiveMfg(scope, 'MFG GHAT REC', { lines:[{...,rtnChol,rtnGhis,ghtWt,
itmGhat,dmPcs,dmWt, repYrcd,...}] })`.
