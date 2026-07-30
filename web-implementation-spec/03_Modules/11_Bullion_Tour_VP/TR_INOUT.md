# TR_INOUT — Branch In / Out (inter-location stock transfer) (stub)

```
Form: TR_INOUT ("Branch Inout")  ·  Module: 11_Bullion_Tour_VP  ·  Type: transaction (stock + posting)
Desktop source: unified/src/csharp/DataCareNext/TR_INOUT.cs (402 KB) → INOUT_DATA / INOUT_DETL / INOUT_IDTL
Web target: apps/api/src/modules/inout/fineInout.ts (PARTIAL — pure-metal movement, no money) · routes/txn.ts (/inout/fine)
Book: BRANCH INOUT   ·   Status: 📋 SPEC · 🟦 PARTIAL
Evidence: form catalog project-memory/catalogs/forms/TR_INOUT.md
```

> Moves stock **between the firm's own branches/locations** (`INOUT_DATA.TO_LC_CODE`). The header is
> location-keyed (its PK has **no `SR_NO`** — header-only), with per-line `INOUT_DETL` and tag
> sub-detail `INOUT_IDTL`, plus `MAIN_STOCK` movements (out at source, in at destination). The web
> `fineInout.ts` implements the **pure-metal** flavour of this (no money ledger).
> `// src: TR_INOUT.cs#L1889 (lblBook "Branch Inout"); data: INOUT_DATA.TO_LC_CODE`

## What the web does today (`fineInout.ts`)
```ts
// direction IN ⇒ TR_TYPE 'I' / ITM_SIGN '+' / VCH_TYPE 'FNIN' ; OUT ⇒ 'O' / '-' / 'FNOUT' ; BOOK_NAME 'FINE INOUT'
writes:[ {table:'INOUT_DATA',rows:[header /* TOT_GWT/TOT_NWT/TOT_FINE */]},
         {table:'INOUT_DETL',rows:detl}, {table:'MAIN_STOCK',rows:mainStock} ]   // ledger empty (no money)
fine = fineWt ?? netWt × touch / 100   // 3 dp
```
`// web: inout/fineInout.ts → fineInout / deleteFineInout`

## Tables
**Writes:** `INOUT_DATA`, `INOUT_DETL`, `MAIN_STOCK` (web). Desktop also writes/reverses `INOUT_IDTL,
BAR_DETL, BAR_IDTL, ITM_LOT_DETL, AC_DATA, ROJ_MEL_DATA, DM_DATA, TAG_IMAGE_DATA` + `DELETE_DATA`.
`// src: TR_INOUT.cs#L10874-L10891`
Refs: [INOUT_DATA](../../02_Data_Model/tables/INOUT_DATA.md) · [INOUT_DETL](../../02_Data_Model/tables/INOUT_DETL.md) ·
[AC_DATA](../../02_Data_Model/tables/AC_DATA.md).

## API
```ts
// POST /inout/fine  (create) → 201 { vchNo, fine }   { direction:'IN'|'OUT', partyAc?, lines:[{itCode,pcs?,grossWt?,netWt?,touch?,fineWt?}] }
// DELETE /inout/fine/:vchNo (delete) → { reversed:true }
```

## Parity / DoD
`INOUT_DATA`+`INOUT_DETL` + `MAIN_STOCK` movements match desktop; the destination location's on-hand
increases and the source's decreases by the same weight/fine; delete reverses + `DELETE_DATA`.

## Open questions
- The web models a **pure-metal** movement (no money). Desktop `TR_INOUT` also writes `AC_DATA`/
  `INOUT_IDTL`/tag detail/`ITM_LOT_DETL` for **tagged, valued** branch transfers — add for full parity.
- Confirm the **destination** in-movement is written (web writes one signed `MAIN_STOCK` per line for
  the source; a true branch transfer needs both source-out and dest-in, keyed by `TO_LC_CODE`).
- Distinguish clearly from [`TR_FN_INOUT`](TR_FN_INOUT.md) (franchise, `FAN_*`, billed). Golden-master pass.
