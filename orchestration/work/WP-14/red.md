# WP-14 red test report

## Unit tests — `web/apps/api/test/rpAllOrder.test.ts`

Command run:

```bash
ALLOW_SKIP_DB_TESTS=1 pnpm --filter @datacare/api exec vitest run test/rpAllOrder.test.ts
```

Result: **19 passed, 0 failed**. These tests exercise the shared RP_ALL engine with the
Order Report record shapes and compute expected values from the desktop formulas. They are
green because the engine is already generic; they still pin the Order Report semantics.

Case ids covered:

- `order-report.formula.order-adjust-signs`
- `order-report.formula.pcs-nwt-totals`
- `order-report.formula.order-advance-tender`
- `order-report.formula.order-wise-bill-total`
- `order-report.formula.pending-set` (derived-set predicate, no database)
- `order-report.formula.bill-wise-adjust`
- `order-report.grouping.template-groups` (group/sort behavior)
- `order-report.output.titles`
- `order-report.filters.data-type-omitted` (shared selectors)
- `order-report.output.grid-export-print-match` (export from the same result)

## Database tests — `web/apps/api/test/rpAllOrder.db.test.ts`

Command run:

```bash
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run test/rpAllOrder.db.test.ts
```

Result: **3 passed, 2 failed**. The failures are the expected 404 because the Order Report
route and adapter do not exist yet.

### Passing

- `order-report.lifecycle.writes-nothing` — snapshot before/after running all seven modes is
  byte-identical; the report writes nothing.
- `order-report.scope.sentinels` — no sentinel voucher text (`O6`, `O7`, `ZO1`) leaks through
  the missing route.
- `order-report.rights.caption-and-print` — the missing route returns 404 for all users;
  rights checks cannot be exercised until the route exists.

### Failing

| Case id | Test | Failing lines | Reason |
|---|---|---|---|
| `order-report.formula.pending-set` | pending lines are derived from `DESIGN_ISU` and the fully-adjusted set (D2) | `rpAllOrder.db.test.ts:618` | `GET /reports/order-report` returns `404 {"error":"not-found"}`; the derived SQL assertion above it passes with the expected `O1:1, O1:2, O2:1, O4:1` keys. |
| `order-report.formula.pending-set` | widening the range still excludes `O5` because the fully-adjusted set is unscoped by date | `rpAllOrder.db.test.ts:626` | Same missing-route 404. |

## Browser cases

The browser cases in `cases.md` are not covered here because the dispatcher scope for this
packet is the two API test files (`web/apps/api/test/rpAllOrder*.ts`). No browser module was
created.

## Blocked cases

None.
