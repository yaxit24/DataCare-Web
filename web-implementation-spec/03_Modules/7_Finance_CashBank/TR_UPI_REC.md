# TR_UPI_REC — UPI Receipt Capture (variant stub)

```
Form: TR_UPI_REC  ·  Module: 7_Finance_CashBank  ·  Type: transaction (capture register — NOT a posting voucher)
Desktop source: unified/src/csharp/DataCareNext/TR_UPI_REC.cs (1,688 lines)
Web target: apps/api/src/modules/finance/finance.ts (postReceipt mode='upi' — writes UPI_DATA) · apps/web/app/(app)/txn/receipts
Requirements: Req 17.4 (UPI/digital → bank/clearing)
Parity: 06_Parity/finance.md  ·  Status: 📋 SPEC · 🟦 PARTIAL
Evidence: form catalog project-memory/catalogs/forms/TR_UPI_REC.md ; table UPI_DATA.md (13 cols)
```

> **This is the odd one out — it does NOT post a ledger.** Unlike every other Finance form,
> `TR_UPI_REC` only **reads/writes `UPI_DATA`** (no `AC_DATA`, no `ROJ_MEL_DATA`). It is a
> **capture / reconciliation register** for UPI collections; the actual ledger effect is realized
> when those UPI entries are settled into a bank receipt elsewhere. `src:` form catalog
> `forms/TR_UPI_REC.md` ("Tables deleted/reversed: **UPI_DATA**"; "Tables read: UPI_DATA, AC_MAST,
> USER_SET"); `TR_UPI_REC.cs#L1314` (`DELETE FROM UPI_DATA …` — the only persistence).

## 1. Purpose & business context
Record UPI collections (VPA/handle, amount, party) as they arrive — a lightweight register so UPI
inflows can be reconciled against the bank statement and then swept into a `BANK REC`. Because it
posts no ledger, it is **not** in the trial balance until settled (Req 17.4 routing happens at sweep).

## 2. UI / UX specification
Grid of UPI lines: `AC_CODE` (payer, lookup→`AC_MAST`), `UPI_AC_CODE`/`UPI_AC_NAME` (the UPI/bank
clearing account), `UPI_AMT`, `VCH_DATE`/`VCH_TIME`. Rights-guarded save ("You Have No Rights….." on
no rights, `src: TR_UPI_REC.cs#L1310`). Modes: New/Edit/View/Delete. _(Confirm labels/F-keys.)_

## 3. Data model touched
- **Writes / deletes:** `UPI_DATA` **only** (13 cols — see [UPI_DATA.md](../../02_Data_Model/tables/UPI_DATA.md):
  `VCH_NO, SR_NO, VCH_DATE, VCH_TIME, AC_CODE, UPI_AC_CODE, UPI_AC_NAME, UPI_AMT, MAIN_USER`).
- **No** `AC_DATA`, `ROJ_MEL_DATA`, `DELETE_DATA`. `src:` catalog `forms/TR_UPI_REC.md`.

## 4. Business logic & calculations
N/A — no computation, no posting. Pure data capture (party + UPI account + amount). The web instead
treats UPI as a **tender mode** and **does** post a ledger:
```ts
// src: web/apps/api/src/modules/finance/finance.ts  postReceipt(mode='upi')
const recAc = settlementAc('upi', input.bankAc);          // → bank/clearing (Req 17.4)
buildTransferLedger(key, 'BREC', recAc, input.partyAc, input.amount);  // Dr bank · Cr party
// writes UPI_DATA{ SR_NO:1, AC_CODE:party, UPI_AC_CODE:recAc, UPI_AC_NAME:bankName, UPI_AMT:amount, UPI_ID }
```

## 5. Save sequence — desktop: delete-then-insert `UPI_DATA` only. Web: posts a bank receipt + writes `UPI_DATA` (see §11 divergence).
## 6. Delete / reverse — desktop: `DELETE FROM UPI_DATA` (no `DELETE_DATA`, no ledger to reverse).

## 7. API contract
`POST /txn/receipts` with `mode:'upi'`, `upiId?`, `bankName?`, `bankAc?` → `201 { vchNo }` (web).
(Desktop register has no posting endpoint equivalent — it would be a `/txn/upi-register` CRUD.)

## 8. Validation rules
Party (`AC_CODE`) + `UPI_AMT > 0`; rights to save. No cash-limit, period-lock, or balance invariant
(no ledger). `req: 17.4`.

## 9. Parity criteria
`UPI_DATA` rows match desktop (party, UPI account, amount, time). **Behavioural divergence to
resolve first:** desktop posts *nothing*; web posts a bank receipt — see §11.

## 10. Variants & edge cases
UPI as a tender line inside `TR_SALE`/`TR_SALE_ORD` (those write `UPI_DATA` too — see Sales `§3`);
bulk UPI import/reconciliation against bank statement.

## 11. Open questions / risks
- **Resolve the posting model.** Desktop `TR_UPI_REC` is a non-posting register; the web folds UPI
  into `postReceipt` (posts `Dr bank / Cr party`). Decide whether the web keeps a parallel
  non-posting register (parity) **and** a separate settlement step, or treats UPI purely as a tender
  mode. This changes whether UPI hits the trial balance at capture time.
- `UPI_DATA` has `UPI_ID`/`UPI_TYPE` written by the web but **not** in the recovered 13-col DDL —
  confirm these columns in the golden master.
