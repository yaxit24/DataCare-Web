# WP-14 verify — Order Report (`orderReportRp.mjs`)

Run on 2026-11-23 20:07 IST in `~/dc-wt/orchwt/wp14-order-report` (branch `agent/wp14-order-report`, candidate
`f286750a` plus the module change below, after merging `origin/main` at `bb633980`, which includes #262). Fresh
build first:

```bash
cd web
pnpm --filter @datacare/db db:generate && pnpm --filter "@datacare/api..." run build \
  && API_ORIGIN=http://127.0.0.1:4700 pnpm --filter "@datacare/web..." run build
PARITY_TEST_PORT=55700 PARITY_API_PORT=4700 PARITY_WEB_PORT=4701 FEATURE_E2E_MODULES=order-report \
  node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs
```

Result line: `order-report: Report → Order Report (RP_ALL) (34 cases) -> applicable 25, passed 25, failed 0,
blocked 0, untested 0; browser pass 100%` and `FEATURE_E2E_PASSED`. Evidence:
`web/test-results/feature-e2e/order-report/run.json` (inputs hash `c64ce34e…`, no business-response mocks, no
request interceptions), one folder per case with screenshots and `browser.json`/`database.json`/`expected.json`.

History: the first run at 19:30 (before #262, candidate `13a50549`) also passed 25 of 25. After merging #262 the
lifecycle and journey cases failed with `duplicate key value violates unique constraint "SL_ORD_ADJ_pkey"`: they
seeded the `+` advance row that the web Sales Order now writes itself. The module now checks that row
(`expectAdvanceAdjustment`: one `+` row whose `ORD_AMT` is the order's `ADV_AMT`) instead of seeding it, and no
longer deletes it before the order delete. No expected report value changed.

## Coverage

- Cases executed of applicable: **25 of 25**.
- Cases passed of executed: **25 of 25**.
- Desktop-match coverage (formula families proven by the desktop oracle): **0** (no desktop run).

The 34 module cases are the 28 case ids of `cases.md` plus six group N/A cases. Three case ids are proven at the
database layer by `web/apps/api/test/rpAllOrder.db.test.ts`, not in the browser: `formula.pending-set`,
`lifecycle.writes-nothing`, `scope.sentinels`.

## Case table

| Case | Kind | Result |
|---|---|---|
| `order-report.entry.menu-route` | T01 | pass |
| `order-report.entry.defaults-and-seven-buttons` | T01 | pass |
| `order-report.entry.location-lock` | T01 | pass |
| `order-report.filters.one-at-a-time` | T02 | pass |
| `order-report.filters.date-range-no-year` | T02 | pass |
| `order-report.filters.combined-city-area-walkin` | T02 | pass |
| `order-report.filters.data-type-omitted` | T02 | pass |
| `order-report.formula.order-adjust-signs` | T03 | pass |
| `order-report.formula.pcs-nwt-totals` | T03 | pass |
| `order-report.formula.order-advance-tender` | T03 | pass |
| `order-report.formula.order-wise-bill-total` | T03 | pass |
| `order-report.formula.bill-wise-adjust` | T03 | pass |
| `order-report.formula.pending-set` | T03 | not run here (DB layer, `rpAllOrder.db.test.ts`) |
| `order-report.lookup.book-party-location` | T04 | pass |
| `order-report.lookup.cust-name` | T04 | pass |
| `order-report.grouping.template-groups` | T05 | pass |
| `order-report.invalid.dates` | T06 | pass |
| `order-report.invalid.unknown-codes-no-recheck` | T06 | pass |
| `order-report.lifecycle.source-order-appears` | T07 | pass |
| `order-report.lifecycle.writes-nothing` | T07 | not run here (DB layer) |
| `order-report.scope.sentinels` | T11 | not run here (DB layer) |
| `order-report.rights.caption-and-print` | T11 | pass |
| `order-report.history.snapshot-and-live` | T12 | pass |
| `order-report.output.titles` | T13 | pass |
| `order-report.output.grid-export-print-match` | T13 | pass |
| `order-report.output.making-summ-prompt` | T13 | pass |
| `order-report.keyboard.selector-run-flow` | T14 | pass |
| `order-report.journey.order-adjust-reconcile` | T16 | pass |
| reopen / edit / delete / concurrency / retry / rollback | T08–T10, T15, T17, T18 | not applicable (read-only report, D2) |

## Screen against the desktop

Not walked by hand in this session; the comparison rests on the module's assertions. `entry.defaults-and-seven-buttons`
checks the seven verbatim captions (including `&Order Wise Bill ` and `& Making Summ`), From `01/01/2010`, To
the system date, the locked location, disabled Pr Code / Gr Code / Item Type and hidden Employ / Select Book
(study Screen; decisions D8, D11). `keyboard.selector-run-flow` checks the Enter flow of the study's Keyboard
section. No difference from the study was recorded.

## Console and network

The 25 executed cases logged no console errors (`consoleErrors` empty in every `browser.json`) and no failed
request.

## Print

There is no PDF in the Crystal template layouts. `output.grid-export-print-match` compares the CSV with the grid
line by line and checks the XLSX/Print buttons behind the Print right (D7); `output.titles` checks the fixed
template titles (`Order Report From …`, `Order Design Issue Panding Report From …` and the rest).

## Known gaps this run does not close

- Closed during this run: the web Sales Order now writes the `+` `SL_ORD_ADJ` advance row (#262, WP-03, merged);
  the lifecycle and journey cases prove the report reads the row the screen wrote.
- Making Panding / Making Summ print the stored `DESIGN_ISU = 'N'` lines, the general desktop behaviour: the
  desktop's fully-adjusted `DESIGN_ISU` write runs only for registration `HM310NEPK` (`RP_ALL.cs:10925`). This
  replaces decision D2's derived set and is an owner question.

## Verdict

**ready for review** — no failing case. Desktop match is 0 %; the three DB-layer cases run in CI with the API
tests.
