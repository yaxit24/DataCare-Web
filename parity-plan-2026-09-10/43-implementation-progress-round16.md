# Implementation progress — Round 16, Sale Return numeric update endpoint + UI Save (X13 steps 8-9)

This document records the Round 16 slice honestly. It is a progress record, not a sealed
checkpoint. [Checkpoint 41](41-implementation-checkpoint-round14.json) remains the latest
sealed record at SHA256 `643bf89ad0ac50729c7feff06c28dfa6bf8cca7d6318e498397cd5c57bf9ebea`;
it is not rewritten here. [Document 42](42-implementation-progress-round15.md) and its Round
15 evidence remain unchanged. No new checkpoint is sealed by this document.

## Scope of this slice

FEAT-003 executes steps 8 and 9 of the "Complete next Return write sequence" in document 42,
building directly on the FEAT-002 numeric-write coordinator
(`apps/api/src/modules/sales/saleReturnNumericUpdate.ts`, committed at `27eb61d`). It does NOT
re-implement the coordinator, and it does NOT widen the supported profile: this remains the
finite c27 writer for the ordinary saved single-primary N/P/I/SR1 zero-tax "Other 0->1"
profile only. It does not close card X13.

## What was implemented

### Step 8 — strict Update endpoint

- `apps/api/src/routes/txn.ts`: new guarded route
  `PUT /sales-returns/:vchNo/incoming-numeric`. It invokes the FEAT-002 coordinator
  `updateSaleReturnNumeric` (NOT the generic `editSaleReturn`, NOT the metadata-only
  `updateSavedSaleReturnMetadata`). RBAC is enforced via the existing `guard(req, reply,
  'update')` (the project's `routeAuthorized`/`authorizeForm` mechanism; there is no
  `assertRight` symbol in this codebase). The body is validated strictly with the
  `SavedSaleReturnError(status, code, message)` pattern: only `version` and `otherAmount` are
  accepted, any unsupported field is rejected. The authenticated operator identity is taken
  from the session (`sess(req).sub`) and never trusted from the body; the whole-second audit
  time is derived server-side. On success the coordinator's fresh `documentVersion` is
  returned so the caller can adopt it. Serialization/stale/alias/cross-year/phantom conditions
  map to 4xx (409/404/422) through `SavedSaleReturnError`, already handled by the route `run()`
  translator.
- `apps/api/src/modules/rbac/routePolicy.ts`: registered the new route under the
  `Sales/Sales Return` form with `update` action and business scope.

### Step 8 — real UI Save flow

- `apps/web/lib/salesReturnForm.ts`: `savedReturnPath` gained a `numeric` action that targets
  `/sales-returns/:vchNo/incoming-numeric` with the same explicit business scope, never the
  generic metadata/create surfaces.
- `apps/web/components/SaleReturnSavedPanel.tsx`: a new "Numeric update (contained profile)"
  Save action on the saved Sale Return screen. It follows the existing draft/conflict-state
  ownership model (`SavedReturnRequestGuard`, `savedReturnSaveFailure`): it sends only the
  observed version and the single c27 Other value, maps a 409 to the retained-changes conflict
  banner, and on success adopts the fresh saved version by reloading the document. The numeric
  draft is kept separate from the metadata draft.
- `apps/web/lib/nav.ts`: **unchanged**. The Sales Return menu was already `ready:true` (from
  the create + saved-metadata surfaces). Per plan card X01 a contained numeric profile does not
  justify promoting a menu to verified, and the honest partial/contained label is retained. No
  nav entry was flipped by this slice.

### Step 8 — coverage

- `apps/web/test/route-coverage.mjs`: added a DB-independent, source-side registered-endpoint
  assertion that the numeric surface is wired end to end (web lib emits the path, the saved
  panel calls it, the API registers it through `updateSaleReturnNumeric`, and it does NOT fall
  through to the generic `editSaleReturn`). Also added a shaped stub for the numeric PUT so the
  saved-return page render stays deterministic.
- `apps/web/test/salesReturnForm.test.ts`: extended the request-shape unit test to assert the
  numeric path resolves to `/sales-returns/00001/incoming-numeric` with the exact scope.
- `apps/api/test/routePolicy.test.ts`: route universe count updated 556 -> 557 and the new PUT
  bound to `Sales/Sales Return` / `update`.

### Step 8 — live smoke test

- `apps/api/integration/sale-return-update.live.mjs`: new live end-to-end following the
  `sales.live.mjs` pattern. It seeds a J01-shaped source sale + saved Return in the dedicated
  non-default `e2e` tenant (as HANDOFF.md documents, so demo data and login stay untouched),
  performs the numeric Return update through the coordinator, and asserts the nine changed rows,
  the whole-unit 111 header, that the AC_DATA and ROJ_MEL_DATA trial balances stay tied, that a
  same-value event is a no-op, and that a stale version maps to a 409.

### Step 9 — report reconciliation

- `apps/api/test/saleReturnNumericUpdate.db.test.ts`: added a `report reconciliation (step 9)`
  block. After the Other 0->1 write it asserts, against the committed rows:
  - `salesReturnRegister` (reads `SL_DETL_RTN` NET_AMT/TOT_AMT) moves 110 -> 111;
  - `trialBalance` (AC_DATA) stays tied (Dr total === Cr total) and the customer credit / sale
    debit each become 111;
  - `accountBalances` and `accountLedger` reflect the -111 customer movement;
  - `outstandingReport` reflects the 111 customer credit.

  Reports reconciled (authored-for-CI): sales-return register, trial balance, account balances,
  account ledger, outstanding.

  OPEN items (honest residual, not claimed closed): the tax/GST reports (GSTR-1/3B/HSN) for
  this profile are zero-tax, so there is no non-trivial tax movement to reconcile in this slice;
  stock valuation and the bill-wise outstanding (`BILL_OS_DATA`) report were not reconciled here
  because this profile creates no received-side `BILL_OS_DATA` row and the stock quantity/fine
  are unchanged by an Other-amount edit (only OTH_AMT/NET_AMT move). These are recorded as open
  reconciliation items to be closed when the corresponding write families (tender/tax,
  received-side outstanding, quantity edits) are implemented.

## Verification — ACTUAL results

DB-independent gate, all GREEN in-sandbox:

- `prisma generate`: OK (Prisma v6.19.3).
- `pnpm typecheck`: 10 successful / 10 total.
- `pnpm build`: 7 successful / 7 total.
- `pnpm lint`: clean (`lint-workspace.mjs` -> 920 source files, 0 policy violations; `eslint .`
  exit 0; `turbo run typecheck` 10/10).
- `pnpm --filter @datacare/core test`: 26 files / 1614 tests passed (unchanged from FEAT-002;
  none regressed).
- `pnpm typecheck:tests`: OK (apps/api `tsconfig.test.json` compiles the extended DB test).
- API pure subset (`ALLOW_SKIP_DB_TESTS=1 ... npx vitest run`): 125 files / 1901 tests passed |
  147 files / 1271 skipped, 0 failures. `routePolicy.test.ts` passes with the updated 557 route
  count.
- `node --check apps/api/integration/sale-return-update.live.mjs`: OK (valid Node ESM).
- `node --check apps/web/test/route-coverage.mjs`: OK.
- `apps/web/test/salesReturnForm.test.ts` via Vitest: 31 tests passed.

## Deferred to CI (NOT executed in-sandbox)

This sandbox has NO working PostgreSQL (podman/crun cannot run postgres:16-alpine; the host
port is unreachable), so the following are authored for CI and verified here only by
compilation / syntax:

- `apps/api/test/saleReturnNumericUpdate.db.test.ts` including the new report-reconciliation
  block (gated on `RUN_DB_INTEGRITY_TESTS=1`).
- `apps/api/integration/sale-return-update.live.mjs` (needs the postgres service + built
  `dist/`).
- The web route/browser suites (`pnpm test:routes`, browser smoke, sales-return journey tests).

These run for real in GitHub Actions CI (`.github/workflows/ci.yml` provides postgres:16-alpine
with `RUN_DB_INTEGRITY_TESTS=1`).

## Round 16 revision — semantic-review findings addressed (NEEDS_CHANGES)

The 2026-09-29 semantic review (`2026-09-29-082715-review.md`, verdict NEEDS_CHANGES) raised
five issues on the X13 numeric write slice. This revision addresses each; the DB-independent
gate stays green and the pure guard's frozen contract is untouched.

### Issue 1 (BLOCKING) — LedrCash cash obligation was unreachable in the ready path — FIXED

Confirmed root cause: the coordinator passed the configured non-zero `CASH_LIMIT` into the
pure guard (`buildGuardInput -> cashLimit: q(config.cashLimit)`), but the pure guard's frozen
profile check refuses ANY non-zero cash limit with `unsupported-cash-limit` BEFORE the
coordinator's `cashLimit > 0` `observeLedrCash` block could run. The two were mutually
exclusive, so `observeLedrCash` (and the `00045` special case) were dead code and the
plan-mandated all-year LedrCash obligation was never observed.

Fix (review option **a** — preferred, keeps the pure guard's frozen contract intact):
`buildGuardInput` now always presents a **zero** cash limit to the pure guard
(`cashLimit: q('0')`), which is exactly what the guard's frozen "ordinary" profile requires,
so all `saleReturnSaveGuards.test.ts` frozen fixtures stay green. The REAL configured
`CASH_LIMIT` (read from `CO_SET` into `config.cashLimit`) is now enforced by the coordinator's
OWN LedrCash ceiling check, which runs AFTER the guard is `ready`. That check
(`if (cashLimit > 0) { observeLedrCash(...); ... }`) is therefore genuinely reachable and
owns the cash decision. The dead `accountCode !== '00045'` sub-condition was removed from the
coordinator block and documented: the pure guard already rejects the `00045` account
(`special-account`), so a `status:'ready'` document never carries it and the coordinator needs
no `00045` branch. `observeLedrCash` implements the binding round-14 aggregate unchanged
(all-year positive customer cash CR sum minus current-book positive cash CR sum, each with its
own positive-only HAVING).

### Issue 2 — the cash-limit DB test proved the wrong gate — FIXED

The over-limit DB case previously passed via the guard's zero-limit refusal, not via the
LedrCash aggregate it seeded. `apps/api/test/saleReturnNumericUpdate.db.test.ts` now:

- restructures the over-limit case to seed a positive configured limit (50) and a non-trivial
  prior-cash aggregate spread across two books/years (40 + 30 = 70 > 50) so the **aggregate**,
  not a single row, decides; it asserts the refusal carries the LedrCash ceiling message
  (`'The observed all-year cash credit exceeds the configured cash limit.'`), proving
  `observeLedrCash` ran (a guard-stage refusal would carry a different code). If the
  `observeLedrCash` block were reverted, this write would commit and the assertion would fail.
- adds a guard-clean ACCEPT case: positive configured limit (50) with observed all-year cash
  under it (30), which is admitted and stays trial-balance-tied — proving the LedrCash
  observation is genuinely on the accepted path and does not spuriously refuse.

### Issue 3 — edition supplied as 'L' not 'E' — CONFIRMED SAFE, documented

The coordinator supplies `edition: q('L')` to the pure guard because the guard treats `'E'`
as `edition-audit-required`. This is a guard-ENVELOPE value only; it is never persisted. The
coordinator writes NO `edition`/`USER_DATA` column (verified: the only persisted columns are
the c27 line/header patches and the financial-effect patches; the actor identity is used only
to verify ownership, not stamped as an edition marker). No downstream reader depends on a
true edition-E marker on the persisted rows, because none is written and none is read for this
profile. The "edition-E audit inputs" therefore honestly reduce to verifying the authenticated
actor owns the saved document — retained as an explicit web audit adaptation, not desktop
`USER_DATA` parity. This remains an open parity item, disclosed, not a defect.

### Issue 4 — endpoint vs coordinator validation drift — documented as safe

The endpoint (`txn.ts PUT /sales-returns/:vchNo/incoming-numeric`) performs only a
superset-safe shape gate (both body fields present as strings; unknown keys rejected). The
authoritative hex/length/charset BOUNDS live once in the coordinator's `validateRequest`,
which denies fail-closed with the same `SavedSaleReturnError` pattern. Because the endpoint's
checks are a strict subset of the coordinator's, they cannot drift into ACCEPTING anything the
coordinator would reject (at worst an error message differs). A clarifying comment was added
at the endpoint stating the coordinator is the single authoritative validator, so the split is
safe and intentional rather than accidental. Centralizing further was judged unnecessary given
the fail-closed coordinator.

### Issue 5 — authored-for-CI proof — confirmed wired

`.github/workflows/ci.yml` (job `quality`) runs `pnpm test` (= `turbo run test`, which runs
the `@datacare/api` Vitest suite) with `RUN_DB_INTEGRITY_TESTS: '1'` and
`RUN_DB_SECURITY_TESTS: '1'` against the `postgres:16-alpine` service on port 55433. The new
`apps/api/test/saleReturnNumericUpdate.db.test.ts` is a standard `*.db.test.ts` picked up by
that Vitest run and gated on `RUN_DB_INTEGRITY_TESTS==='1'`, so it executes for real in CI
(including the restructured LedrCash cases and the report-reconciliation block). The live
`apps/api/integration/sale-return-update.live.mjs` follows the existing `*.live.mjs` convention;
like every other `*.live.mjs` in the repo it is a standalone smoke script and is NOT invoked by
the CI workflow (only verified here by `node --check`). This is stated plainly rather than
claimed as executed. No in-sandbox DB execution is claimed.

## Qualifications retained — X13 is NOT closed

DB-backed, live and browser proof for this slice is authored-for-CI and was not executed in
this sandbox. This remains a finite c27 writer for the ordinary saved single-primary N/P/I/SR1
zero-tax Other 0->1 profile only. It does not implement outgoing/exchange legs, tags, children,
multirow, received-side transitions, BAR-header disappearance at Other -11, non-zero
tender/tax, closing/known-mode, or edition-E desktop USER_DATA parity (only the explicit web
audit adaptation). A finite c27 writer plus its endpoint/UI does not close card X13 or certify
the whole product.
