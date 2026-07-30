# TR_MEMB_ADJ — Member Scheme Adjust / Maturity (stub)

```
Form: TR_MEMB_ADJ ("Member Scheme Adjust")  ·  Module: 10_Membership  ·  Type: transaction (posting)
Desktop source: unified/src/csharp/DataCareNext/TR_MEMB_ADJ.cs (124 KB) → AD_ADJ
Web target: apps/api/src/modules/membership/scheme.ts → schemeMaturity / deleteSchemeMaturity · routes/txn.ts (/scheme/maturity)
Book/Voucher: 076 / MBADJ / "MEMB ADJUST"   ·   Status: 📋 SPEC · 🟩 BUILT
```

> Variant of [`TR_MEMB_ENT`](TR_MEMB_ENT.md). This is the **maturity / redemption** end of a saving
> scheme: the member's accrued balance is paid back (± bonus / penalty) and the scheme liability is
> cleared. It is the **mirror image** of an installment — the ledger reverses direction.

## What it does (delta vs TR_MEMB_ENT)

A matured (or surrendered) member is paid out. Net **payout = `MEMB_AMT` (matured principal) +
`MEMB_BONUS` − `MEMB_LESS`** (`bonus`/`less` default 0 for a plain cash redeem).
`// web: scheme.ts → schemeMaturity` `// src: TR_MEMB_ADJ.cs#L2429 (MAX(VCH_NO) FROM AD_ADJ)`

| Aspect | Installment (`TR_MEMB_ENT`) | **Adjust/Maturity (`TR_MEMB_ADJ`)** |
|---|---|---|
| Detail table | `AD_DATA` (`ENT_TYPE` E/O) | **`AD_ADJ`** (`SIGN='-'`, `MEMB_BONUS`, `MEMB_LESS`, `ADJ_AMT`=payout) |
| Outstanding | `AD_OS` `OS_TYPE='A'` `SIGN='+'` (accrue) | `AD_OS` `OS_TYPE='D'` `SIGN='-'` (redeem) |
| Ledger | Dr cash/bank · Cr `SCHM_AC` | **Dr `SCHM_AC` · Cr cash/bank** (pay member out) |
| Book | 074 MBENT / 075 MBOP | **076 MBADJ "MEMB ADJUST"** |

## Posting shape

```
Dr  AD_MAST.SCHM_AC      payout     ← clear the liability the shop owed the member
Cr  CASH/BANK            payout     ← money paid out
```
Balanced on the **net payout**; `AD_ADJ` carries `MEMB_AMT`/`MEMB_BONUS`/`MEMB_LESS`/`ADJ_AMT`,
`AC_CODE`/`AC_NAME` (settlement account), `VCH_DESC`, `SIGN='-'`. `AD_ADJ` can also settle against an
open sale bill (`SBILL_NO`/`SBILL_AMT` columns) — "adjust scheme balance against a purchase" mode.
`// data: AD_ADJ (MEMB_BONUS, MEMB_LESS, ADJ_AMT, SBILL_NO, SIGN)`

## Tables

**Writes:** `AD_ADJ` (adjustment detail), `AD_OS` (`OS_TYPE='D'`, `SIGN='-'`), `AC_DATA` (balanced).
**Reverses:** `AD_ADJ, AD_OS, AC_DATA` + `DELETE_DATA`. `// web: scheme.ts → deleteSchemeMaturity`
Refs: [AD_ADJ](../../02_Data_Model/tables/AD_ADJ.md) · [AD_OS](../../02_Data_Model/tables/AD_OS.md) ·
[AC_DATA](../../02_Data_Model/tables/AC_DATA.md).

## API

```ts
// POST /scheme/maturity   (right: create) → 201 { vchNo, payout }
interface SchemeMaturityBody {
  schmCode; membCode; amount; bonus?; less?;       // payout = amount + bonus − less
  mode?; bankAc?; acName?; vchDesc?; chqNo?; vchDate?;
}
// DELETE /scheme/maturity/:vchNo   (right: delete) → { reversed:true }
```

## Parity / DoD
- `AD_ADJ` row matches desktop (`MEMB_AMT`/`MEMB_BONUS`/`MEMB_LESS`/`ADJ_AMT`/`SIGN='-'`); `AD_OS`
  decremented (`OS_TYPE='D'`); `AC_DATA` Dr `SCHM_AC` / Cr cash, ΣCR=ΣDR; member balance returns to 0
  on full maturity. Delete reverses + writes `DELETE_DATA`. Trial balance nets to zero.

## Open questions
- `AD_ADJ.ENTRY_TYPE` is `'A'` on the real 076 rows (web sets it) — confirm the bill-settlement
  (`SBILL_*`) mode's exact account flow against the desktop before building "scheme-balance against a
  purchase" redemption. Bonus/less account resolution (income/expense ledgers) needs the golden-master pass.
