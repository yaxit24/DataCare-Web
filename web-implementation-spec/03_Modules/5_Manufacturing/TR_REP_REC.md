# TR_REP_REC — Repairing / Job receipt (variant stub)

```
Form: TR_REP_REC  ·  Module: 5_Manufacturing  ·  Type: transaction (metal-flow + money + tax)
Desktop: unified/src/csharp/DataCareNext/TR_REP_REC.cs (#L4657-L4976)
Web target: apps/api/src/modules/manufacturing/ (no module yet)
Status: ⬛ UNBUILT (no web counterpart) · Parity: 06_Parity/manufacturing.md
```

A sibling job-work receipt that, unlike the bare process vouchers, **does post money and tax**. Distinct
from the karigar engine ([`TR_KR_ISU.md`](TR_KR_ISU.md)) — it has its own `REP_*` tables.

## Purpose
Receive a repairing / outside job-work job and bill it: record returned items, charge labour + GST,
post the customer/karigar ledger and the day-book.

## Footprint (desktop)
Writes **`REP_DATA`** (header) + **`REP_DETL`** (lines), and posts **`AC_DATA`** (ledger),
**`ROJ_MEL_DATA`** (day-book) and **`TAX_DATA`** (GST). _(src: `TR_REP_REC.cs#L4657-L4976`; MODULE_MAP
lists `TR_REP_REC` → `REP_DETL`, posting ✅.)_ Reverse = those tables + `DELETE_DATA`.

## Build note / risks
- **No web module exists** (`grep REP_ over apps/api/src` → 0; audit-C §G13). Greenfield.
- Because it posts money + GST, build it on the **posting** + **GST** engines (not the empty-ledger
  metal path): Dr customer / Cr labour-income + GST, mirroring a labour sale.
- Related reports: `ReparingRec.rpt`, `ReparingKrRec.rpt`, `ReparingCustIsu.rpt`.
- Confirm `REP_DATA`/`REP_DETL` column lists and the ledger leg set (`Ac_Ledr` rep path) in a
  golden-master pass before implementing.
