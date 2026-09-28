# Batch 1 transaction helper extraction — staged only

Status: proposed source and focused tests, not integrated or executed. Only files under `/tmp/datacare-session-context-next` were written. The formatter ran against the three staged TypeScript files; no TypeScript compiler, Vitest, database, browser, or workspace build ran for this staging task.

The patch is `batch1-extraction.patch`, with paths relative to the extracted repository root (`web/...`). The `baseline/` copies record the exact two source inputs. Check their hashes against the live repository before adopting the patch; do not overwrite intervening work.

## Changes

- `auth/businessScope.ts`: private company/location/year queries receive `Tx`; exported `resolveLoginScopeTx(tx, input)` and `resolveSelectedScopeTx(tx, input)` perform the same decisions. The original public wrappers and structural input/output types remain compatible, but each wrapper now calls `withTenant` once for its complete three-read operation.
- `rbac/authorization.ts`: exported `loadPrincipalTx(tx, input)` contains the existing query and projection; the original `loadPrincipal` wrapper delegates through one `withTenant` transaction. Form authorization and canonical form handling are unchanged.
- `sessionContext.extraction.test.ts`: 31 independent literal cases run through both direct-Tx and wrapper paths, nine transaction-boundary cases, and one frozen fixture hash/count assertion: **72 declared cases, none executed**.
- `fixtures/sessionContext.extraction.independent.json`: byte-identical copy of the independent reviewer's fixture, authored before they inspected this staged implementation. SHA256 `5fb741ce33c4615e1c1f905aef9dabf86ef97a58ca1514a56fe44bb46827c8d7`.

The Tx functions deliberately do not bind a tenant, open another transaction, choose isolation, authenticate a caller, or acquire row locks. Their caller must supply a tenant-bound transaction and trusted input. Existing public wrappers still use the default `withTenant` isolation/options. This prerequisite does not make login, session selection, refresh, last-day-lock, or an admitted business request atomic.

## Preserved decisions and evidence limits

The exact company membership/admin parameters, requested-location equality, company-default fallback when no location rows exist, requested/default year rules, optional no-year login versus required-year selection, query error propagation, and existing error types remain intact. Principal projection still returns the credential row's `CO_CODE` as `Principal.loginCoCode`; this is separate from the session's immutable login-company field. Existing role/rights/forced-reset flag parsing is unchanged, including its different whitespace/case behavior.

Static comparison found all eight business-scope and six authorization template literals byte-identical and in the same order. Other functions in these modules remain unchanged except formatting within the extracted regions. The scripted test queue returns already ordered database observations and checks exact SQL parameters and transaction traces. It does not prove PostgreSQL sorting, SQL permission predicates, RLS, isolation, locking, or rollback of physical writes.

After adoption, run the focused test with the normal isolated wrapper because API global setup probes the database even for unit files:

```sh
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run test/sessionContext.extraction.test.ts
```

Then use the API strict test compiler and existing authenticated scope/session/settings regressions, under the root's serialized verification lease. No passed result is asserted here. Any further session/epoch/migration work remains a separate batch.

`static-preservation-check.json` records source comparison; `staging-manifest.json` records final artifact hashes and review state. Independent review lives beside this directory under `../independent-review/` and must retain its unexecuted qualification.
