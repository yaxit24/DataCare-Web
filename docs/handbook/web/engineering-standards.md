# Engineering standards

Rules for every change to `web/`, for people and agents alike. They exist so that the web version keeps the
desktop's business results while the code stays easy to change. Where a rule is already enforced, the enforcing gate
is named; rules marked *N88* become CI ratchets with that slice.

## 1. Principles

1. **The desktop is the authority for business behaviour.** Before changing a calculation, posting, validation or
   print, read the desktop source for it (dispatch line, form, posting helpers) and cite it in the pull request.
   The web may differ only where a decision allows it (D20 layout, the weaknesses in the desktop handbook §8).
2. **Same results, safer mechanics.** Reproduce write sets, numbers and report data exactly; do not reproduce
   string-built SQL, plaintext passwords, global state, unscoped deletes or partial writes.
3. **The server owns business truth.** Company, location, year, book, accounts, numbering, rates and totals are
   decided on the server; the browser proposes, the server validates and computes.
4. **One atomic write set per voucher.** Header, details, sub-details, ledger, day book, stock, tax, outstanding and
   audit rows are written or reversed together.
5. **Evidence over claims.** Status lives in the backlog with evidence paths; a slice is never marked done without its
   tests.

## 2. TypeScript

- Strict mode with `noUncheckedIndexedAccess` (`web/tsconfig.base.json`); API and core test sources compile strictly
  too (`pnpm typecheck:tests`).
- No `any` at a module boundary; parse unknown input into a typed value at the edge. `@ts-ignore` is rejected by
  `web/scripts/lint-workspace.mjs`; use a typed boundary with a comment instead.
- Exact dependency versions in every `package.json` (enforced by `web/scripts/lint-workspace.mjs`); add a dependency
  only when the standard library or an existing package cannot do the job, and say why in the pull request.
- Formatting by Prettier (`web/.prettierrc.json`: 100 columns, single quotes, trailing commas); `pnpm format:check` in CI.
- React hooks rules are errors (`web/eslint.config.mjs`); list every dependency of `useCallback`, `useMemo` and
  `useEffect`.

## 3. API

- **Routes.** Every new route has a JSON Schema for params, query and body
  (D16: `additionalProperties: false`, no coercion, no defaults) and appears in the route policy
  (`web/apps/api/src/modules/rbac/routePolicy.ts`). The exact route-universe test
  (`web/apps/api/test/routePolicy.test.ts`) changes in the same pull request. Once N88 has created the first module
  route plugin, new routes go into their module's plugin rather than `web/apps/api/src/routes/txn.ts`; until then,
  add them next to their family in `txn.ts`, with schemas, so they move with that family (*N88*, D27).
- **Errors.** Use the typed taxonomy (*N88*): 400 `invalid-request` with field paths, 401, 403, 404, 409
  `voucher-version-conflict` or `idempotency-key-reused`, 422 business rule, 429, 502/503 provider, 500 opaque with a
  correlation ID. Never return SQL, stack traces, payloads or secrets.
- **Scope.** Never read company, location or year from the body or query; take them from the session
  (`web/apps/api/src/modules/auth/businessScope.ts`). Validate a requested book against active `BOOK_DATA`.
- **Edits and deletes** require the voucher's `version` (D17); **financial creates** require an `Idempotency-Key`
  (D18).
- **Transactions.** One transaction per command, opened with
  `withTxBudget(prisma, tenantId, 'read' | 'voucher' | 'heavy' | profile, fn)`
  (`web/apps/api/src/modules/shared/txBudget.ts`): the class sets the time limits and a transaction-local
  `statement_timeout`, a named profile adds an isolation level, and an expired budget is a retryable 503. A direct
  `withTenant` or `$transaction` call fails `web/apps/api/test/txBudgetCoverage.test.ts` unless it is listed there
  with its own longer limit (N53). No external call (provider, renderer) inside a business transaction — use the
  outbox (Phase 2) or call after commit and record the outcome.
- **Lists** return the full identity of each voucher (company, location, year, book, number) and are paginated.

## 4. Domain logic and calculations

- All money and weight arithmetic uses `@datacare/core` (decimal.js). Rounding happens at the stages the desktop
  rounds, with the desktop rule for that stage (`round` or `roundHalfEven` in `web/packages/core/src/money.ts`);
  never `Math.round`, `toFixed` or float arithmetic on business values. Kernel conformance is ratcheted (G22, N48).
- `web/packages/core` stays pure: no I/O, no clock, no database (*N88*).
- No literal account or book codes. Resolve accounts from `BOOK_DETL` slots and books from the session and
  `BOOK_DATA` through `web/apps/api/src/modules/shared/postingAccounts.ts` and
  `web/apps/api/src/modules/shared/bookPolicy.ts`; a missing slot is an error (N59).
- Numbers come from `web/apps/api/src/modules/vouchers/numbering.ts`; the lock date and fiscal year are checked inside
  the transaction (`web/apps/api/src/modules/vouchers/lifecycle.ts`).
- Desktop column defaults apply on create only; an imported or reopened NULL stays NULL.
- Every calculation change adds kernel vectors with expected values derived from the desktop source or a captured
  desktop row.

## 5. Database

- Forward migrations only, registered in `web/apps/api/src/modules/ops/migrationManifest.ts`; never edit an applied
  migration and never use `prisma db push`. After a migration: `rls.sql`, `setup_roles.sql`, `pnpm fresh:provision`.
- Every business table has `tenant_id` and is covered by forced RLS; the runtime role never bypasses RLS.
- Raw SQL binds every value; identifiers come from allow-lists through `web/apps/api/src/modules/security/sql.ts`.
  `$queryRawUnsafe` and `$executeRawUnsafe` appear only in its allow-listed helpers (*N88*).
- Keep desktop column names, types and widths so imports and the differential stay exact; new desktop-edition
  columns follow the desktop type (N84).
- Incompatible schema changes follow expand → backfill → switch → contract.

## 6. Frontend

- Pages get the business scope from `useBusinessScope()` and books from `BookSelect`; they never fetch `/me` or
  invent book codes (enforced by `web/scripts/lint-workspace.mjs`).
- Pages call the API only through `web/apps/web/lib/api.ts`.
- Voucher screens use the shared voucher editor once it exists (*N88*): hydrate **every** field the API returns, track
  changes, send the version and idempotency key, and reload after save. An unchanged save must not change any row.
- Calculated fields use `@datacare/core` functions, the same ones the server uses.
- Keyboard parity: Enter moves in desktop field order, F1 opens the lookup, the desktop F-keys work through
  `FormKeys`; every control is reachable by keyboard and has a label.
- Dates travel as `YYYY-MM-DD` and are shown as `dd/MM/yyyy`; amounts use `en-IN` grouping with 2 decimals; weights 3
  decimals unless company precision settings say otherwise (D19). UI text comes from the language catalogue once
  N76 lands.
- Grid columns follow `COL_MAST` captions and visibility (N77).
- New or moved pages at most 600 lines; split into components and hooks (*N88*).

## 7. Tests required for a change

| Change | Required |
|---|---|
| Calculation | Kernel vectors (independent expected values), including midpoints and zero, negative and blank inputs |
| Writer or posting | Complete write-set database test: create, reopen, unchanged save, edit, delete, a sentinel in another scope, and a broken variant that fails ([testing §3](testing.md#3-write-set-database-tests)) |
| Route | Schema tests (valid, invalid, extra fields), route policy, route-universe count |
| Screen | Zero-mock journey and the Chrome DevTools visual protocol record ([testing §4–5](testing.md#5-visual-and-interactive-verification-with-chrome-devtools-mcp)) |
| Report or print | Dataset test against independently derived rows; layout comparison for bound templates |
| Migration | `pnpm fresh:provision`, `pnpm schema:readiness`, `pnpm type:parity` |

Tests derive expected values independently and are hermetic (testing §8).

## 8. Security

- No real, tracked, production or customer credentials, and no customer data, in code, tests, fixtures, logs or
  documents; name environment variables by key only. Tests may use synthetic, test-only values generated for that
  test. `web/scripts/lint-workspace.mjs` scans application source for secret-shaped literals (it skips test and
  integration files) and `docs/tools/docs_check.py` scans the documentation hub.
- Desktop databases are queried with aggregate queries only.
- Rights are checked on the server for every route and action; the UI hiding a button is not a control.
- Outbound providers fail honestly: an unconfigured provider reports "not sent", never a simulated success (G33).
- PDFs are rendered only from server-built documents; the renderer gets no network access (G32).

## 9. Size and structure limits

| Item | Limit | Enforced |
|---|---|---|
| New or moved API route or module file | 800 lines | *N88* ratchet |
| New or moved page or component | 600 lines | *N88* ratchet |
| Existing files above the limit | May not grow | *N88* ratchet |
| Import boundaries | Core has no I/O; pages use `web/apps/web/lib/api.ts`; modules do not import another module's repository | *N88* lint |
| Kernel bypasses (local rounding helpers) | Ceiling may only fall | `web/scripts/check-kernel-conformance.mjs` (N48) |

## 10. Documentation and plan records

- Update `execution-backlog.json` (status, `statusAsOf`, evidence, note) and document 11 §2 in the same pull request
  as the code; new defects become gaps in document 12 (continuing at G84).
- Update the [menu catalog](../menu-catalog.md) row of every menu whose web state changed, then run
  `python3 docs/tools/docs_check.py --write`.
- Comments explain why, citing the desktop source line where the behaviour comes from.

## 11. Pull-request checklist

- [ ] Desktop authority cited (dispatch line, form source, posting helper) for every behaviour change.
- [ ] Tests from §7 added; all gates green locally: `pnpm lint`, `pnpm typecheck`, `pnpm typecheck:tests`, `pnpm test`,
      `pnpm build`, `pnpm format:check`, the isolated database suite, the zero-mock journey, `docs:refs`,
      `validate_plan.py`, `docs_check.py`.
- [ ] Visual protocol summary for each changed screen.
- [ ] No literal accounts or books, no unscoped writes, no raw-body casts, no secrets.
- [ ] Backlog, document 11 §2 and catalog rows updated.
- [ ] The description says what was verified and what was not.
- [ ] Branch is not `main`; specific files staged; hooks not skipped.
