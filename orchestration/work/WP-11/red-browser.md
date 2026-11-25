# WP-11 browser tests — RED report (before the dedicated screen exists)

This file records the first run of the frozen Sales Report browser matrix against the current web build, in which the
dedicated `/reports/sales-report` screen has not been built yet. It is written by the tests worker so the supervisor
and the UI worker can see exactly which cases were made runnable and which variants remain blocked.

## Run command

From `web/`, after `API_ORIGIN=http://127.0.0.1:4410 pnpm --filter "@datacare/web..." run build` and an explicit
`pnpm --filter @datacare/types build && pnpm --filter @datacare/api build`:

```
FEATURE_E2E_MODULES=sales-report node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs
```

The run booted a disposable PostgreSQL (project `datacare-parity-365de35f20d2`, port 55433), the real Fastify API as
`app_user` under forced RLS, the production Next build and headless Chromium. Candidate commit `101fe4be`; the dirty
patch hash at run time was `7b20c796`. Evidence is retained under `web/test-results/feature-e2e/sales-report/`
(`matrix.json`, `run.json` and per-case screenshots and observations). The harness reported `bundleValid: true` and
`errors: []`; no request was intercepted or mocked.

## Result summary

20 cases are registered. 14 are applicable and all 14 fail (browser-pass 0%); 6 are not applicable (T08–T10 and
T12–T14). No applicable case passes, which is the expected RED state: the screen the cases target does not exist, so
every case stops at the first navigation assertion.

The single failing line for all 14 RED cases is `openReport()` in
`web/apps/web/test/features/modules/salesReport.mjs:89`:

```
assert.equal(await link.count(), 1, 'Reports navigation must expose Sales Report');
```

The running page's Reports navigation has no `Sales Report` link and the route `/reports/sales-report` returns no
dedicated screen, so this assertion fails before any case reaches its selector, total or output assertions. This is
the correct reason for RED: the API and engine are already green in `rpAllSales.db.test.ts`, and the missing piece is
the screen the UI worker will build.

## Cases (all 20, with their group and observed status)

| Case id | Group | Status | Observation |
|---|---|---|---|
| sales-report.entry.defaults-and-thirteen-buttons | T01 | failed | Reports navigation must expose Sales Report |
| sales-report.filters.one-at-a-time | T02 | failed | Reports navigation must expose Sales Report |
| sales-report.filters.combined-and-year-boundary | T02 | failed | Reports navigation must expose Sales Report |
| sales-report.formula.register-report-totals | T03 | failed | Reports navigation must expose Sales Report |
| sales-report.formula.item-group-employee-order | T03 | failed | Reports navigation must expose Sales Report |
| sales-report.lookup.party-book-product-group | T04 | failed | Reports navigation must expose Sales Report |
| sales-report.grouping.templates-and-zoom | T05 | failed | Reports navigation must expose Sales Report |
| sales-report.invalid.dates-and-empty | T06 | failed | Reports navigation must expose Sales Report |
| sales-report.source.create-edit-delete-return | T07 | failed | Reports navigation must expose Sales Report |
| sales-report.t08.not-applicable | T08 | not-applicable | A report writes nothing; mapped to T02/T03/T05/T16 |
| sales-report.t09.not-applicable | T09 | not-applicable | A report writes nothing; mapped to T02/T03/T05/T16 |
| sales-report.t10.not-applicable | T10 | not-applicable | A report writes nothing; mapped to T02/T03/T05/T16 |
| sales-report.scope.tenant-company-location-year-book-rights | T11 | failed | Reports navigation must expose Sales Report |
| sales-report.t12.not-applicable | T12 | not-applicable | A report writes nothing; mapped to T02/T03/T05/T16 |
| sales-report.t13.not-applicable | T13 | not-applicable | A report writes nothing; mapped to T02/T03/T05/T16 |
| sales-report.t14.not-applicable | T14 | not-applicable | A report writes nothing; mapped to T02/T03/T05/T16 |
| sales-report.history.live-master-and-snapshot | T15 | failed | Reports navigation must expose Sales Report |
| sales-report.output.grid-pdf-xlsx-csv-match | T16 | failed | Reports navigation must expose Sales Report |
| sales-report.keyboard.selector-run-flow | T17 | failed | Reports navigation must expose Sales Report |
| sales-report.journey.create-edit-delete-return-reconcile | T18 | failed | Reports navigation must expose Sales Report |

## Cases still blocked, with reasons

The "phase two" blocked reason has been removed from every case. Two desktop branches remain blocked inside the cases
that own them, for reasons outside this screen; both are preserved in the case source and will be reported as
`status: 'blocked'` by a run in which the screen exists and the earlier assertions pass.

- **Sales Return variant of T07 (`sales-report.source.create-edit-delete-return`) and T18
  (`sales-report.journey.create-edit-delete-return-reconcile`).** Reason: `G246` — the web Sales Return writer stores
  the return value in `NET_AMT`/`TOT_AMT` and leaves `RTN_NET_AMT` zero, so a web return lists as a sale under the
  desktop rule that selects returns on `RTN_NET_AMT <> 0` (`RP_ALL.cs:7597`). Inventory §6.9 records the defect; the
  lifecycle cases run the sale create/edit/delete part and then return the blocked status with this reason. The
  desktop split is `TR_SALE_RTN.cs:12623` and `TR_SALE_RTN.cs:12707`.
- **SalesRtnA4Print output in T16 (`sales-report.output.grid-pdf-xlsx-csv-match`).** Reason: `MISSING:
  SalesRtnA4Print template`; the return-bill print file is absent from `extraction_output/rpt_xml/` and the
  repository (inventory §5). The case checks the six implemented templates over 55 vouchers and then returns the
  blocked status with this reason for the missing print variant.

The six T08–T10 and T12–T14 entries stay not-applicable, unchanged, because the Sales Report writes nothing: each
button only builds a selection formula and opens a template (`RP_ALL.cs:7572-7678`), and the addendum maps those
groups to filters, totals, drill-down and output, covered by T02, T03, T05 and T16.

## What each new case proves once the screen exists

The ids and expectations are the 14 frozen cases of `docs/parity/rpall-sales-inventory.md` §8. Each case computes its
expected values from the vouchers it creates through the Sales Invoice API and screen, with the template formula, never
from the web. The thirteen Lite buttons are the desktop's (`RP_ALL.cs:4723 {{BtnSlRpt.Text = "&Sales Report";}}`,
`RP_ALL.cs:4749 {{BtnSalesReg.Text = "&Sales Reg";}}`, `RP_ALL.cs:4775 {{BtnSalesItem.Text = "&Item Wise";}}`). The two
Yes/No prompts are the desktop's (`RP_ALL.cs:7584 {{if ((int)Interaction.MsgBox((object)"Sales Return (Creditnote) Report", (MsgBoxStyle)260, (object)DC_Main.MsgTitle) == 6)}}`,
`RP_ALL.cs:11749 {{if ((int)Interaction.MsgBox((object)"Only Item Sales With Order", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)}}`).

## Not done or not verified

Nothing about desktop behaviour was executed in this run; the harness sets `desktopStatus: 'not-run'` for every case.
The report establishes only that the cases are runnable and RED before the screen exists. The UI worker's build must
turn the 14 failures green (except the two blocked variants above) before any acceptance claim.
