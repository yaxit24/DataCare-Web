# WP-11 verify — Sales Report screen, phase two (`salesReport.mjs`)

Run on 2026-11-23 19:32 IST in `~/dc-wt/orchwt/wp11-sales-report-screen` (branch
`agent/wp11-sales-report-screen`, candidate `8ba9d7c0`, `origin/main` at `fa460c55` merged). Fresh build first:

```bash
cd web
pnpm --filter @datacare/db db:generate && pnpm --filter "@datacare/api..." run build \
  && API_ORIGIN=http://127.0.0.1:4700 pnpm --filter "@datacare/web..." run build
PARITY_TEST_PORT=55700 PARITY_API_PORT=4700 PARITY_WEB_PORT=4701 FEATURE_E2E_MODULES=sales-report \
  node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs
```

Result line: `sales-report: Reports → Sales Report (RP_ALL) (20 cases) -> applicable 14, passed 11, failed 0,
blocked 3, untested 0; browser pass 78.57%` and `FEATURE_E2E_PASSED`. Evidence:
`web/test-results/feature-e2e/sales-report/run.json` (inputs hash `71b320b5…`), one folder per case with
screenshots and observations. Phase one (engine, Sales adapter, API, N234) is recorded in the backlog; this file
covers the dedicated screen on `/reports/sales-report`.

## Coverage

- Cases executed of applicable: **14 of 14** (3 of them end `blocked` after running their sale part).
- Cases passed of executed: **11 of 14**; 0 failed.
- Desktop-match coverage (formula families proven by the desktop oracle): **0** (no desktop run).

## Case table

| Case | Kind | Result |
|---|---|---|
| `sales-report.entry.defaults-and-thirteen-buttons` | T01 | pass |
| `sales-report.filters.one-at-a-time` | T02 | pass |
| `sales-report.filters.combined-and-year-boundary` | T02 | pass |
| `sales-report.formula.register-report-totals` | T03 | pass |
| `sales-report.formula.item-group-employee-order` | T03 | pass |
| `sales-report.lookup.party-book-product-group` | T04 | pass |
| `sales-report.grouping.templates-and-zoom` | T05 | pass |
| `sales-report.invalid.dates-and-empty` | T06 | pass |
| `sales-report.source.create-edit-delete-return` | T07 | blocked — sale create/edit/delete reconciled; the return variant waits on G246 (the web Sales Return writes `NET_AMT`, not `RTN_NET_AMT`) |
| `sales-report.scope.tenant-company-location-year-book-rights` | T11 | pass |
| `sales-report.history.live-master-and-snapshot` | T12 | pass |
| `sales-report.output.grid-pdf-xlsx-csv-match` | T13 | blocked — six sale templates checked over 55 vouchers (grid, CSV, XLSX, PDF); `SalesRtnA4Print` template is missing from the repository |
| `sales-report.keyboard.selector-run-flow` | T14 | pass |
| `sales-report.journey.create-edit-delete-return-reconcile` | T18 | blocked — same as T07 (G246) |
| T08, T09, T10, T12, T13, T14 group N/A cases | — | not applicable (read-only report) |

## Screen against the desktop

Not walked by hand in this session; the comparison rests on the module's assertions.
`entry.defaults-and-thirteen-buttons` checks the thirteen sales button captions, defaults and focus;
`keyboard.selector-run-flow` checks the Enter flow from selector to run. No difference was recorded.

## Console and network

No console errors in any case (`consoleErrors` empty in every `browser.json`); no failed request.

## Print

The six sale templates print through the PDF path and match the grid, CSV and XLSX over 55 vouchers. The return
bill (`SalesRtnA4Print`) cannot be checked: the template is not in the repository.

## Verdict

**ready for review** — no failing case. Three cases stay blocked for reasons outside this screen: G246 (T07,
T18) and the missing `SalesRtnA4Print` template (T13).
