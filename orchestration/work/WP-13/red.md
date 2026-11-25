# WP-13 red report — Approval Rpt selection/database cases

Commands run from `web/` in this session (Docker was available; the parity wrapper started the isolated
database, applied migrations and tore it down afterwards):

- Unit: `node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run test/rpAllApproval.test.ts test/rpAllApproval.db.test.ts`
- Type check: `pnpm typecheck:tests` (passes; last lines quoted at the end).
- Final combined run: **2 files, 29 tests, 11 failed, 18 passed**. Every failure is on a desktop-derived
  expectation, not a seed/selector/type error. The 18 green tests are kept; their current web behaviour
  already matches the desktop case at this layer, as noted below.

## New tests and their result

### Failing on the behaviour (red)

| Case id | File:line of failing assertion | Failing line (verbatim from the run) |
|---|---|---|
| `approval-report.filters.data-type-selection` | `rpAllApproval.test.ts:68` | `AssertionError: setting A must append the BOOK_DATA.DATA_TYPE predicate: expected 'SELECT row_number() OVER (ORDER BY a.…' to match /DATA_TYPE"\s*=\s*\$\d+/` |
| `approval-report.filters.pending-exact-n` | `rpAllApproval.db.test.ts:481` | `AssertionError: expected [ { srNo: 1, …(26) }, …(1) ] to have a length of 1 but got 2` — the null `ISU_REC` line is coalesced to `N` (gap 3). |
| `approval-report.formula.inout-sum-levels` | `rpAllApproval.db.test.ts:572` | `AssertionError: expected false to be true` at `expect(Array.isArray(levels)).toBe(true)` — no product/tag/party group levels exist. |
| `approval-report.formula.pending-signed-tags` | `rpAllApproval.db.test.ts:595` | `AssertionError: expected undefined to be 6` at `expect(totals.pendingPcs).toBe(6)` — Pending has no sums. |
| `approval-report.formula.pending-zero-footer-suppression` | `rpAllApproval.db.test.ts:608` | `AssertionError: suppression hides the footer, not the records: expected undefined to be 6` — no grand total and no footer structure. |
| `approval-report.grouping.issue-voucher-party-bands` | `rpAllApproval.db.test.ts:653` | `AssertionError: expected undefined to deeply equal [ 'none', 'footer' ]` — no band nesting. |
| `approval-report.grouping.inout-party-product-date-tag` | `rpAllApproval.db.test.ts:663` | `AssertionError: expected undefined to deeply equal [ 'acCode', 'prCode', 'vchDate', …(1) ]`. |
| `approval-report.grouping.pending-voucher-product-tag` | `rpAllApproval.db.test.ts:673` | `AssertionError: expected undefined to deeply equal [ Array(4) ]` (expected `acCode, vchGroup, prCode, tagNo`). |
| `approval-report.grouping.repeated-blank-tags` | `rpAllApproval.db.test.ts:686` | `AssertionError: expected undefined to be 2` at `expect(tag?.rowCount).toBe(2)` — no tag group band. |
| `approval-report.invalid.reversed-range-empty` | `rpAllApproval.db.test.ts:716` | `AssertionError: {"error":"ReportValidationError","message":"fromDate must be before or equal to toDate"}: expected 400 to be 200` — the web throws where the desktop conjuncts an unsatisfiable range (D7). |
| `approval-report.history.live-master-names` | `rpAllApproval.db.test.ts:832` | `AssertionError: expected [ 'Snapshot P1', 'Snapshot P1', …(1) ] to include 'Renamed Party'` — snapshot names win over live masters (gap 7). |

### Green today, kept as regression contracts (checked, not weakened)

Each of these really drives the endpoint with the case's seed and asserts desktop-derived values; the
current web builder already produces them at the database layer. They remain in the file so the WP-13
implementation must not regress them.

- `approval-report.filters.one-at-a-time` — party/product/city/area/group/location predicates all narrow correctly.
- `approval-report.filters.date-range-inclusive-and-year` — inclusive endpoints and session-year scope hold.
- `approval-report.filters.item-type-first-character` — `R`/`G`/`E`/blank use the first character.
- `approval-report.filters.combined-and` — party AND product AND city conjunct.
- `approval-report.filters.main-book-family` — SALES/APR RTN excluded, legacy `APPROVAL ISSUE` accepted (D6).
- `approval-report.formula.issue-party-sums` — the flat Issue rows print the correct stored values; only the
  missing voucher/party subtotals make the grouping cases red.
- `approval-report.formula.inout-out-in-pending` — Out/In/Pending line status before and after resolution.
- `approval-report.formula.precision-preserved` — sums preserve the stored 3-place weights and 2-place amounts
  for the seed used; see the OTH_AMT note below.
- `approval-report.grouping.duplicate-master-no-amplification` — `ITEM_MAST_pkey` forbids the duplicate, and the
  count-once totals hold; see the schema note below.
- `approval-report.journey.custody-reconcile` — issued 6 = pending 2 + resolved 4 pieces and the gross/net sums
  and stored fine reconcile with the current writers; no fine column is invented.
- `approval-report.invalid.empty-period`, `approval-report.invalid.malformed-date-safe` — empty selection and safe
  400 for an impossible date.
- `approval-report.scope.tenant-company-location-sentinels`, `approval-report.scope.year-scope`,
  `approval-report.scope.view-print-rights` — RLS/company/year/location/rights guards hold.
- `approval-report.concurrency.request-local-state`, `approval-report.concurrency.run-during-resolution`,
  `approval-report.retry.duplicate-run-idempotent` — no cross-talk, no torn rows, no write set.

### Blocked cases (no test written)

- `approval-report.filters.data-type-setting-source` — blocked (D3). Exact question: which approved
  company/session setting supplies the A/B data-type input to the shared engine? Unblocks: owner accepts the
  setting-source contract; then bind it and run.
- `approval-report.grouping.null-tag-footer` — blocked (D2). Exact question: how does a NULL (vs blank vs `N`)
  `TAG_NO` render and group in the tag footer at runtime? Unblocks: original-Windows runtime evidence or an
  owner decision on null-tag grouping. The repeated blank/`N` case is covered by
  `approval-report.grouping.repeated-blank-tags`.
- `approval-report.output.numeric-display-precision` — blocked (D1). Exact question: what precision/tie handling
  do `AprPartyWise`, `AprInOut` and `AprPan` actually print? Unblocks: an original-Windows render or extracted
  numeric `ObjectFormat` metadata. Computation precision is covered by `formula.precision-preserved`.
- `approval-report.output.drilldown` — blocked (D2). Exact question: does the generic Crystal viewer drill into
  vouchers at runtime, and how? Unblocks: original-Windows runtime evidence.

## Seed notes

- `OTH_AMT` is `Decimal(18,2)`, so the case's `0.005` cannot be stored; the precision test uses `0.01` (the
  closest representable value), with zero values in the other amount columns, so the worked sums stay exact.
- `ITEM_MAST_pkey` (`tenant_id`, `CO_CODE`, `IT_CODE`) forbids the duplicate master the case asks for. The
  duplicate-amplification test asserts that constraint from `information_schema` and then checks count-once
  totals, as the case directs when the schema forbids the duplicate.
- Expected values are computed in the tests from the fixture lines and the desktop formulas; none is read back
  from the application. All 18 desktop quotes used in comments were checked against the cited source lines.

## Evidence (last lines of the commands)

```
$ pnpm typecheck:tests
> @datacare/core@0.0.0 typecheck:tests /.../web/packages/core
> tsc -p tsconfig.test.json
```

```
$ node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run test/rpAllApproval.test.ts test/rpAllApproval.db.test.ts
 Failed Tests  11 
 Test Files  2 failed (2)
      Tests  11 failed | 18 passed (29)
 Container datacare-parity-bc349e1a60fa-postgres-1 Stopped
 Container datacare-parity-bc349e1a60fa-postgres-1 Removed
 Volume datacare-parity-bc349e1a60fa_parity-test-data Removed
```
