# WP-14 browser red report — Order Report (`orderReportRp.mjs`)

The module `web/apps/web/test/features/modules/orderReportRp.mjs` freezes all 28 case ids of
`orchestration/work/WP-14/cases.md` (25 browser-layer, 3 database-layer) and adds six group N/A cases so that
every T01–T18 group is dispositioned. It is red on purpose: the dedicated `/reports/order-report` screen and its
"Order Report" navigation link do not exist yet (study gaps 1 and 14). No case is marked `blocked` because
cases.md records every case as `executable` and explicitly says the missing screen is the red state the list
drives, not a blocker.

## How to run

From `web/`, build once with the API port the harness will use, then run only this module:

```bash
cd web
API_ORIGIN=http://127.0.0.1:4410 pnpm build
node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs \
  # with FEATURE_E2E_MODULES=order-report
```

Concretely:

```bash
cd web
FEATURE_E2E_MODULES=order-report \
  PARITY_TEST_PORT=55439 PARITY_API_PORT=4410 PARITY_WEB_PORT=4411 \
  node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs
```

Add `FEATURE_E2E_CASES=order-report.<group>.<name>,...` to select cases. The run is expected to exit 1 with
`FEATURE_E2E_FAILED` and a `NEW failure` line for every applicable case until the screen exists; do not add
these ids to `baseline.json` to make it green. Evidence goes to `web/test-results/feature-e2e/order-report/`.

The two static gates from the work packet both pass (output quoted in the worker report):

```bash
node --check apps/web/test/features/modules/orderReportRp.mjs &&
  pnpm exec eslint apps/web/test/features/modules/orderReportRp.mjs apps/web/test/features/run-features.mjs &&
  pnpm exec prettier --check apps/web/test/features/modules/orderReportRp.mjs
node -e "import('./apps/web/test/features/modules/orderReportRp.mjs').then(m=>{const mod=Object.values(m).find(v=>v&&v.feature);const g=new Set(mod.cases.map(c=>c.group));const miss=[...Array(18)].map((_,i)=>'T'+String(i+1).padStart(2,'0')).filter(t=>!g.has(t));if(miss.length){console.error('missing groups',miss);process.exit(1)}console.log(mod.cases.length,'cases')})"
```

## Executable browser cases (red today)

Every row below fails today at `openReport()` on `getByRole('link', { name: 'Order Report', exact: true })`:
the Reports navigation has no "Order Report" link (gap 14), so the run never reaches the screen. That is the
correct red reason. When the page exists, each case asserts the desktop-derived expectation listed here,
computed from the seeded rows rather than read back from the app.

| Case id | Group / kind | Desktop-derived expectation |
|---|---|---|
| `order-report.entry.menu-route` | T01 read-only | Dedicated `/reports/order-report`, heading and form title "Order Report", not `/txn/sales-order`; menu visible in Lite. |
| `order-report.entry.defaults-and-seven-buttons` | T01 read-only | From `01/01/2010`, To system date, focus From, lc `01` disabled, inert Pr/Gr/Item Type disabled, Employ/Select Book hidden, max lengths 8/50, seven buttons with verbatim captions including the trailing space in `&Order Wise Bill ` and the space in `& Making Summ`. |
| `order-report.entry.location-lock` | T01 read-only | lc locked at `01`; at `00` editable, clearable, and the location sentinel O6 appears only in the all-locations run. |
| `order-report.filters.one-at-a-time` | T02 read-only | Book B1 → O1/O3/O4/O8; Party, City, Area and Cust Name → O1/O3; Pr Code, Gr Code and Item Type are disabled and reach no request filter (D8). |
| `order-report.filters.date-range-no-year` | T02 read-only | Inclusive `VCH_DATE` range; a date one day before/after is excluded; from `01/12/2025` the 2025 order O5 is listed and no `coYear` filter is sent. |
| `order-report.filters.combined-city-area-walkin` | T02 read-only | Filters combine AND; walk-in O4 prints without a city filter, drops out with City SURAT, and City SURAT + Area ALKAPURI is empty. |
| `order-report.formula.order-adjust-signs` | T03 read-only | O1 `+5000/-1500/-500`, O3 `+3000/-1500/-1500`; groups O1 5000/2000/3000 and O3 3000/3000/0; grand 8000/5000/3000. |
| `order-report.formula.pcs-nwt-totals` | T03 read-only | Mode 1 grand pcs 9, nwt 31.875; mode 5 pending lines O1:1, O1:2, O2:1, O4:1, pcs 7, nwt 24.875; no status filter. |
| `order-report.formula.order-advance-tender` | T03 read-only | One header row per order grouped by stored customer name, tender values from `SL_ORD_DATA`, no grand-total band. |
| `order-report.formula.order-wise-bill-total` | T03 read-only | O1 `+5000` with empty bill plus two `-` rows against S1 (12000), O3 `+3000` plus two `-` rows against S2 (9000); per-order totals 2000/3000/0, no grand band. |
| `order-report.formula.bill-wise-adjust` | T03 read-only | Base is `SL_DATA`: S1 and S2 with raw `-` amounts; Cust Name filters the bill's stored name; no total band (D13). |
| `order-report.lookup.book-party-location` | T04 read-only | Empty exits with Tab, known fills name and tabs, unknown opens scoped help, picking fills both and returns focus, cancel keeps typed text, stale help cannot overwrite; location help only at `00`. |
| `order-report.lookup.cust-name` | T04 read-only | Found name copied back exactly, focus to City; unknown opens the distinct `SL_ORD_DATA` name help (D9 in mode 7 too); cancel keeps text; empty goes to City. |
| `order-report.grouping.template-groups` | T05 read-only | Per-mode group/sort keys from the seven XML templates; O1's two lines print in group order even when inserted in reverse; mode 6 groups by tag+design, mode 7 by bill keys. |
| `order-report.invalid.dates` | T06 refusal | `31/02/2026` and an incomplete mask are refused with no run; From after To prints an empty report with zero totals and no error. |
| `order-report.invalid.unknown-codes-no-recheck` | T06 refusal | Unknown party/book typed without Enter goes straight into the filter and prints an empty report, writes nothing, and a typed `'` is swallowed. |
| `order-report.lifecycle.source-order-appears` | T07 mutation | An order created through the Sales Order screen appears in modes 1/2, its cash advance writes a `+` adjustment visible in mode 3 and renders it pending in mode 5; editing net weight changes the grand total; deleting removes all rows. |
| `order-report.rights.caption-and-print` | T11 refusal | A Sales Order right only hides the menu and gets 403 from the API; the Order Report caption right is required; `FRM_PRINT = 'N'` still lists but refuses CSV/XLSX (D6, D7). |
| `order-report.history.snapshot-and-live` | T15 read-only | Modes 1–6 keep the stored `ALPHA JEWELS`, mode 7 shows the live `ALPHA RENAMED` order party; Cust Name matches stored, City matches live master. |
| `order-report.filters.data-type-omitted` | T15 read-only | B1 (DATA_TYPE A) and B2 (DATA_TYPE B) both list; no data-type parameter is sent (D4). |
| `order-report.output.titles` | T16 output | Seven fixed titles with `dd/MM/yyyy`, including both "Bill Wise Order Adjust Report" and the two "Order Design Issue Panding Report" modes. |
| `order-report.output.grid-export-print-match` | T16 output | 30 extra orders overflow one page; grid, CSV, XLSX and print show the same rows/columns/totals; mode 2 and 7 have no grand band. |
| `order-report.output.making-summ-prompt` | T16 output | Yes/No prompt text "Only Design Summery Report..", title "DataCareNext"; Yes suppresses detail, No prints it, totals identical. |
| `order-report.keyboard.selector-run-flow` | T17 read-only | Enter walks From→To→lc→Book→Pr→Gr→Party→Cust Name→City→Area→Item Type; uppercase and quote swallowing; Esc exits; Cancel clears text but keeps combos; Print no-op; Exit closes; captions carry `&` marks verbatim. |
| `order-report.journey.order-adjust-reconcile` | T18 mutation | Create J1, reconcile modes 1/2/3/5; add `-3000` then `-2000`, reconcile 3/4/5/7 then 1/2/5/6; at net zero modes 5/6 drop it but 1/2 still list it; `DESIGN_ISU` stays `N`. |

## Cases with no browser layer (N/A, with reasons)

These keep their exact cases.md id in the matrix so the denominator is unchanged, but `applicable: false`
and a source-backed reason; the harness records them as `not-applicable`.

| Case id | Group | Reason |
|---|---|---|
| `order-report.formula.pending-set` | T03 | Database assertion fully covered by `web/apps/api/test/rpAllOrder.db.test.ts`: derived pending set `['O1:1','O1:2','O2:1','O4:1']`, unscoped O5 exclusion, `DESIGN_ISU` unchanged (D2). |
| `order-report.lifecycle.writes-nothing` | T07 | Database assertion in `web/apps/api/test/rpAllOrder.db.test.ts`: row counts and every `DESIGN_ISU` byte-identical after running all seven modes twice. |
| `order-report.scope.sentinels` | T11 | Database assertion in `web/apps/api/test/rpAllOrder.db.test.ts`: O6 (location 00), O7 (company C2) and a same-numbered second-tenant order never appear and the cross-scope API call is refused. |
| `order-report.reopen.no-op.not-applicable` | T08 | The report saves no document; closing and reopening re-applies constructor defaults (T01); it has no raw values, clocks or images of its own. |
| `order-report.edit.no-own-field.not-applicable` | T09 | The report owns no editable field; editing the source order and re-running is in T07. |
| `order-report.delete.no-write.not-applicable` | T10 | The report deletes and reverses nothing; source-order deletion is in T07 and Order Cancel is G245 (D3). |
| `order-report.concurrency.read-only.not-applicable` | T12 | The web report is read-only (D2): no save, delete or number allocation to race; zero writes are proved in T07. |
| `order-report.retry.read-is-idempotent.not-applicable` | T13 | A run is a read; a retried request returns the same dataset with no financial effect, asserted by the second-run comparison in T07. |
| `order-report.rollback.no-write.not-applicable` | T14 | There is no write to roll back (D2); a failed run leaves the database untouched, verified by T07. |

## Executed red evidence (this session)

A scoped harness run built the production web app with `API_ORIGIN=http://127.0.0.1:4410` and ran two cases on
the isolated database. Both failed for the right reason — the missing navigation link — before reaching any
selector or data assertion:

```
=== order-report: Report → Order Report (RP_ALL) (34 cases) ===
  FAIL order-report.entry.menu-route
       FAILED: locator.waitFor: Timeout 8000ms exceeded.
  FAIL order-report.entry.defaults-and-seven-buttons
       FAILED: locator.waitFor: Timeout 8000ms exceeded.
  -> applicable 25, passed 0, failed 2, blocked 0, untested 23; browser pass 0%
FEATURE_E2E_FAILED:
- order-report: NEW failure order-report.entry.menu-route
- order-report: NEW failure order-report.entry.defaults-and-seven-buttons
```

Read back from `web/test-results/feature-e2e/order-report/run.json`:

```
waiting for getByRole('link', { name: 'Order Report', exact: true }) to be visible
```

The other 23 applicable cases were not executed in this scoped run (`FEATURE_E2E_CASES` filter) and remain
untested; they are expected to fail at the same navigation step until the screen is built. The citation checker
reports `90 citations: 90 verified by quote, 0 range only, 0 wrong` for the module.

## Found but out of scope

- `orchestration/work/WP-14/cases.md:145` says the Book `B1` filter returns O1, O3 and O4, but its own Test data
  (line ~606) seeds O8 in book B1 on 20/01/2026 and `formula.pcs-nwt-totals` includes O8. The module computes
  the expectation from the desktop predicate and includes O8; the supervisor should reconcile the case-list
  text. No case was weakened or deleted.
- The API routes and `order` adapter already exist (`web/apps/api/src/routes/rpAllReport.ts:138-190`), so the
  red state is only the browser page and navigation link; no API work was done here.
