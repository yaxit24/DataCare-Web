# TR_OTH_COMM — Other Commission (stub)

```
Form: TR_OTH_COMM ("Other Commission")  ·  Module: 11_Bullion_Tour_VP  ·  Type: transaction (posting)
Desktop source: unified/src/csharp/DataCareNext/TR_OTH_COMM.cs (181 KB) → AC_DATA (commission ledger)
Web target: NEW (not built; closest pattern: finance journal/ledgerAdjust)
Book: OTHER COMMISSION   ·   Status: 📋 SPEC · ⬛ UNBUILT
```

> Records **commission income/expense** outside the normal sale flow — e.g. brokerage/commission paid
> to an agent or earned on a referred deal. Caption `lblBook.Text = "Other Commission"`.
> `// src: TR_OTH_COMM.cs#L1709`

## What it does
A balanced commission voucher: it books the commission **amount** between a party/agent account and a
commission income or expense ledger, optionally with the cash/bank settlement leg. Pure money posting
(no stock). Likely also a day-book (`ROJ_MEL_DATA`) row.

## Posting shape (to confirm)
```
Commission PAID:     Dr commission-expense / Cr agent (or cash/bank)
Commission RECEIVED: Dr party (or cash/bank) / Cr commission-income
```

## Tables
**Writes:** `AC_DATA` (balanced) (+ likely `ROJ_MEL_DATA`, `REMARK_DATA`). **Reverses:** `AC_DATA`
(+ day-book/remark) + `DELETE_DATA`. Ref: [AC_DATA](../../02_Data_Model/tables/AC_DATA.md).

## API (proposed)
```ts
// POST /commission  (create) → 201 { vchNo }   { partyAc, commissionAc, amount, direction:'paid'|'received', mode?, vchDate? }
```
Reuse the finance posting pattern (`finance.ts`/`journal.ts` → `buildTransferLedger` + `postVoucherTx`).

## Parity / DoD
Balanced `AC_DATA` (ΣCR=ΣDR) matching desktop accounts/amounts; delete reverses + `DELETE_DATA`;
trial balance nets to zero. Crystal `OthCommVch.rpt`.

## Open questions
- **Not built.** Confirm the exact commission ledgers used (income vs expense), whether GST/TDS applies
  to the commission, and the settlement modes. Golden-master pass on `TR_OTH_COMM.cs`.
