# Coding Conventions

Conventions every module must follow so the codebase stays consistent and **parity-safe**. These
are derived from the existing `web/` implementation and ADR-0001 (precision policy).

## 1. Preserve desktop names

- **Table and column names are kept verbatim** from the desktop schema (`AC_DATA`, `SL_DETL`,
  `ITM_FINE`, `CR_AMT`, …), quoted in SQL because they are upper-case/legacy:
  `'"' + ident + '"'`. This keeps the parity diff against the golden master 1:1 and lets the ETL
  copy data without renaming.
- Module/service/function names are idiomatic TS (`createSale`, `postVoucherTx`, `billTotals`).
- Voucher *types* and *book* codes are kept as the desktop uses them (e.g. `BOOK_NAME='SALES'`).

## 2. Money & weight = exact decimals, never float

```ts
// packages/core/src/money.ts
export const PRECISION = { amount: 2, weight: 3, fine: 3 } as const;
export function round(value, dp) {
  return new Decimal(value).toDecimalPlaces(dp, Decimal.ROUND_HALF_UP).toNumber();
}
```

- Use **`decimal.js`** for all metal/money math. DB columns are `NUMERIC` (Prisma `Decimal`), not float.
- **Rounding is HALF-UP** to: amounts **2 dp**, weights **3 dp**, fine **3 dp**.
- Bill **total** rounds to the nearest whole unit (`ROUND_HALF_UP`, 0 dp); the difference is `roundOff`.
- **GST split keeps the penny:** `SGST = tax − CGST` so `CGST + SGST === tax` exactly (desktop parity), see `gstSplit`.
- Never introduce a different rounding mode/precision without an ADR — it breaks parity.

## 3. The voucher key & ledger line identity

- Voucher key object passed to reverse/delete: `{ CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, ... }`.
- `AC_DATA` lines are enriched on post (desktop parity), do not hand-set these unless overriding:
  - `LEDR_KEY` = `CO_CODE+LC_CODE+CO_YEAR+CO_BOOK+pad(VCH_NO,6)+pad(srno,2)` (unique line key)
  - `IT_TYPE` = `'A'` for money legs (`G`/`S` for gold/silver metal legs, set by caller)
  - `DATA_TYPE` = `'A'` (desktop stamps this on 100% of data rows; `postVoucherTx` auto-stamps tables that have the column)
  - `LD_CODE` = line ordinal; `BOOK_NAME` = the voucher book.

## 4. Transactions & posting

- All multi-table writes go through `withTenant`/`atomic`; never write across tables outside a tx.
- Post via `postVoucherTx(tx, tenantId, { ledger, writes, bookName })`; it asserts ΣCR=ΣDR and the period lock.
- Delete via `reverseVoucherTx(tx, tenantId, { tables, key, deleteLog })`.
- Edit = `reverseVoucherTx` then `postVoucherTx` in the **same** transaction.

## 5. Error model → HTTP mapping

Domain errors are thrown by services and mapped to HTTP by the route adapter:

| Domain error | HTTP | Body |
|---|---|---|
| `ValidationError` (missing required) | 400 | `{ error:'missing-required', missing:[...] }` |
| `*ValidationError` (e.g. `PeriodLockValidationError`) | 400 | `{ error, detail }` |
| `DuplicateKeyError` | 409 | `{ error:'duplicate-key' }` |
| `ReferencedError` (delete blocked by FK) | 409 | `{ error:'referenced', ref }` |
| `ForbiddenError` (RBAC) | 403 | `{ error:'forbidden', action }` |
| `UnbalancedError` (ΣCR≠ΣDR) | 500/400 | internal invariant — should never reach a user |
| `DataError` (bad value/DB constraint) | 400 | `{ error:'invalid-data', detail }` |

Convention: a service throws a typed error; **routes never embed business logic** — they map errors
and call `assertRight`. Any error class whose name ends in `ValidationError` is auto-mapped to 400.

## 6. RBAC

- Three rights mirror the desktop: `USER_UPDATE` (create/update), `USER_DELETE`, `USER_PRINT`.
- Guard every mutation with `assertRight(session.rights, 'create'|'delete'|'print')`.
- Filter nav with `filterNav` so users don't see menus/forms they can't access (Req 6.7).

## 7. Tests & parity (Definition of Done per module)

- **Tier-1**: pure unit tests for calc/posting (golden vectors). 
- **Tier-2/3**: live integration tests (`apps/api/integration/*.live.mjs`) against real Postgres.
- **Tier-4**: golden-master parity vs SQL Server backup via `packages/parity` + `xdb_diff.mjs`.
- A module is **done** only when its parity criteria in `06_Parity/<module>.md` pass and the trial
  balance still nets to zero.

## 8. File/route placement

- Pure calc → `packages/core`. Shared tx primitives → `modules/posting`, `modules/vouchers`.
- Module logic → `apps/api/src/modules/<module>/*.ts`. REST → `apps/api/src/routes/txn.ts`.
- Frontend screen → `apps/web/app/(app)/…`; nav entry in `apps/web/lib/nav.ts` (`ready:true` when built).
- Generic master → add a config to `modules/masters/configs.ts` + a nav entry (no new screen needed).
