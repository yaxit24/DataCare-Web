---
name: datacare-write-set-test
description: Write a complete write-set database test for a DataCare voucher writer (create, reopen, unchanged save, edit, delete, scope sentinel, broken variant) on the isolated PostgreSQL with forced RLS. Use whenever a writer, posting rule, route or migration changes.
---

# Write-set database test

Writer or route under test: `$ARGUMENTS`.

The method is in `docs/handbook/web/testing.md` §3. A complete existing example is
`web/apps/api/test/purchaseReturnLifecycle.routes.db.test.ts`.

## 1. File and guards

- Name: `web/apps/api/test/<family><Aspect>.routes.db.test.ts` (HTTP) or `<family><Aspect>.db.test.ts` (service).
- Gate on `process.env.RUN_DB_INTEGRITY_TESTS === '1'` like the other database tests; the global setup
  (`web/apps/api/test/globalSetup.ts`) turns it on whenever a database is reachable.
- In `beforeAll`, call `assertIsolatedTestDatabase()` from `web/apps/api/test/support/isolatedDatabase.ts`, which
  refuses anything but the isolated database from `web/scripts/parity-test-env.mjs` (never compare the port literally;
  `web/apps/api/test/isolatedDatabase.test.ts` fails on that).
- Use a tenant ID unique to this file; wipe its rows in `beforeAll` and `afterAll` through the owner client.
- Fixture credentials are test-only constants generated for the file; never reuse a real or tracked credential.

## 2. Fixture

1. `seedCompany(runtime, tenantId, '01')` from `web/apps/api/src/modules/ops/seedCompany.ts`.
2. Insert only the master rows the scenario needs through the owner client, with bind parameters and the test's
   tenant ID. Use non-default codes (for example account codes that are not `00001`) so literal fallbacks are caught.
3. Configure the book exactly as the desktop does (3-digit code, `MAIN_BOOK`, `BOOK_DETL` slots).
4. Build the app with `buildApp`, log in through `POST /auth/login` and select the context through
   `POST /context/select`, then drive the voucher **only through its routes** with `app.inject()`.

## 3. Expected values

- Derive them independently: from the desktop source (cite `file:line` in a comment) or a captured desktop row stored
  as `web/apps/api/test/fixtures/<name>.independent.json`. Never paste the web's own output as the expectation.
- Cover every table in the form's `tablesWrittenCatalog`
  (`docs/master-parity-plan-2026-09-29/desktop-form-reference.json`).

## 4. Cases (each an `it`)

| Case | Assert |
|---|---|
| Create | Every row of the write set field by field: header, details, sub-details, `AC_DATA` legs (use `ledgerLegs`), `ROJ_MEL_DATA`, `MAIN_STOCK`, `TAX_DATA`, `BILL_OS_DATA`, `TEMP_BOOK_DATA`, audit; `AC_DATA` balances |
| Reopen | GET returns every saved field, including blanks and NULLs |
| Unchanged save | PUT with the reopened body changes no row (`snapshotTenant` before and after, `diffTenant` empty) |
| Edit | Only the edited field and its derived rows change |
| Delete | Full reversal of every effect plus one `DELETE_DATA` row |
| Scope sentinel | A voucher with the same visible number in another company, location, year and tenant is untouched |
| Refusals | Invalid body → 400 with field paths; stale version → 409; missing book slot → error, never a fallback account |
| Concurrency (when relevant) | Two edits with the same version: one wins, one gets 409 |

Helpers: `footprintOf`, `ledgerLegs`, `voucherTables` in `web/apps/api/test/support/footprint.ts`; `snapshotTenant`,
`diffTenant`, `countsOf` in `web/apps/api/test/support/tenantSnapshot.ts`.

## 5. Prove the test can fail

Temporarily break the writer (drop one ledger leg or flip one sign), run the test, confirm it fails with a clear
message, and revert. Mention this in the pull request.

## 6. Run

```bash
cd web
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test -- <test-file-name>
pnpm typecheck:tests
```
