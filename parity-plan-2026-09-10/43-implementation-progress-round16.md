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

## Qualifications retained — X13 is NOT closed

DB-backed, live and browser proof for this slice is authored-for-CI and was not executed in
this sandbox. This remains a finite c27 writer for the ordinary saved single-primary N/P/I/SR1
zero-tax Other 0->1 profile only. It does not implement outgoing/exchange legs, tags, children,
multirow, received-side transitions, BAR-header disappearance at Other -11, non-zero
tender/tax, closing/known-mode, or edition-E desktop USER_DATA parity (only the explicit web
audit adaptation). A finite c27 writer plus its endpoint/UI does not close card X13 or certify
the whole product.
