# TR_FN_INOUT — Franchise In / Out (stub) ⚠️ web naming divergence

```
Form: TR_FN_INOUT ("Franchise In Out")  ·  Module: 11_Bullion_Tour_VP  ·  Type: transaction (posting)
Desktop source: unified/src/csharp/DataCareNext/TR_FN_INOUT.cs (364 KB) → FAN_DATA / FAN_DETL / FAN_IDTL (+ tax)
Web target: ⚠️ apps/api/src/modules/inout/fineInout.ts MISLABELS this as "fine in/out" — see divergence below
Book: FRANCHISE IN OUT   ·   Status: 📋 SPEC · ⬛ UNBUILT (as franchise; a different INOUT_* form is partial)
Evidence: form catalog project-memory/catalogs/forms/TR_FN_INOUT.md
```

> **`FN` = Franchise, not Fine.** Caption `lblBook.Text = "Franchise In Out"`; it reads `FAN_AC_MAST`
> (franchise master, keyed by `FAN_CO_CODE`) and `CO_MAST`. This form moves **tagged stock between the
> main company and a franchisee, with billing** (it writes `AC_DATA` **and** `TAX_DATA`).
> `// src: TR_FN_INOUT.cs#L2091 (lblBook "Franchise In Out"); #L5748 (FAN_AC_MAST.FAN_CO_CODE)`

## ⚠️ Divergence to reconcile (build blocker)
The web file `apps/api/src/modules/inout/fineInout.ts` is **named/commented "Fine In/Out
(TR_FN_INOUT — pure fine-metal in/out)"** but actually writes the **`INOUT_*`** tables (the
[`TR_INOUT`](TR_INOUT.md) "Branch Inout" family) with **no money/tax**. The real desktop `TR_FN_INOUT`
is a **franchise** transfer on **`FAN_*`** tables **with** `AC_DATA`+`TAX_DATA`. So:
- The web "fineInout" maps to **`TR_INOUT`** (branch transfer), *not* `TR_FN_INOUT`.
- A true `TR_FN_INOUT` web build must use `FAN_DATA`/`FAN_DETL`/`FAN_IDTL` + `FAN_AC_MAST` + post money + GST.

Document/rename accordingly before building; do not assume the web `fineInout.ts` covers franchise.

## What it does
Transfer tagged stock to/from a franchise (`FAN_AC_MAST.FAN_CO_CODE`), billing the franchisee: writes
`FAN_DATA` (header) / `FAN_DETL` (lines) / `FAN_IDTL` (tag sub-detail) + `BAR_DETL`/`BAR_IDTL` (barcode/
tag detail) + `MAIN_STOCK` movement + **balanced `AC_DATA`** + **`TAX_DATA`** (GST on the transfer).

## Tables (footprint, from catalog)
**Reverses:** `FAN_DATA, FAN_DETL, FAN_IDTL, BAR_DETL, BAR_IDTL, MAIN_STOCK, AC_DATA, TAX_DATA,
ROJ_MEL_DATA, TEMP_BOOK_DATA` + `DELETE_DATA`. `// src: TR_FN_INOUT.cs#L7033-L7049`
Refs: [FAN_DATA](../../02_Data_Model/tables/FAN_DATA.md) · [FAN_DETL](../../02_Data_Model/tables/FAN_DETL.md) ·
[AC_DATA](../../02_Data_Model/tables/AC_DATA.md).

## Parity / DoD (once built)
`FAN_*` rows + `MAIN_STOCK` movement + balanced `AC_DATA` + `TAX_DATA` match desktop; the franchisee's
ledger reflects the transfer value; delete reverses + `DELETE_DATA`; trial balance nets to zero.

## Open questions (must resolve before build)
- Reconcile the web `fineInout.ts` naming (it is branch/`INOUT_*`, not franchise/`FAN_*`).
- Confirm the franchise billing legs (Dr franchisee / Cr stock-transfer + GST) and the `FAN_AC_MAST`
  party resolution; confirm whether transfers are at cost or with margin/GST.
- Requires a Docker golden-master pass on `TR_FN_INOUT.cs` + `FAN_*` real rows.
