import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Report → Sales Report (desktop RP_ALL in its "Sales Report" caption).
 *
 * WP-11 PHASE ONE — FROZEN CASE PLAN, NOT YET RUNNABLE.
 * Phase one delivered the shared RP_ALL engine, the Sales adapter and its API (GET /reports/sales-report and
 * the CSV/XLSX exports), proven by unit and DB tests. The dedicated screen (web/apps/web/app/(app)/reports/
 * sales-report/) is phase two, and phase one ran no local stack (the 8 GB machine already carried two). So every
 * case below is frozen with its desktop-derived expectation and BLOCKED with that reason; each stays in the
 * denominator until phase two builds the screen and runs it. docs/parity/rpall-sales-inventory.md §8 is the plan.
 *
 * Desktop authority:
 * - MDI_FORM.cs:8901-8910 opens RP_ALL for the "Sales Report" caption; RP_ALL.cs:6676-6698 shows PanelSale,
 *   the Employ box, the Select Book box and, for UAE or two registrations only, Item Bill / B2B Bill.
 * - The thirteen Lite buttons (RP_ALL.cs:4364-4378) and their templates: Sales Report → SaleReport /
 *   SaleRtnReport (:7572-7678), Sales Reg → SalesSumm / SalesRtnSumm (:7722-7824), Item Wise → SalesItem /
 *   SalesRtnItem (:7826-7940), Sales Bill (:9005-9133), Employ Sales → EmpSaleReport (:9135-9206), Cash/Bank
 *   Bill (:9797-9895), Wh Sales (:8913-9003), Wh Summ (:10996-11202), Emp WhSales (:11265-11353), Counter
 *   Sales (:11658-11733), Sale With Order → SalesWithOrder (:11735-11816), Group Sales → SalesGroupWise
 *   (:11928-12018), Labour Work → LbrWorkRpt (:12020-12110).
 * - Expected totals are added up from the vouchers each case creates through the Sales Invoice and Sales Return
 *   screens, with the template formula (SaleReport.xml Section10, SalesSumm.xml Section7/8, ...), never read
 *   back from the web.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, expected, extra = {}) => ({
  id: `sales-report.${id}`,
  group,
  kind,
  source,
  expected,
  applicable: true,
  requiredEvidence: kind === 'output' ? ['browser', 'expected', 'output'] : ['browser', 'expected'],
  run: async () => ({}),
  blocked:
    'WP-11 phase two: the dedicated /reports/sales-report screen is not built yet and phase one ran no ' +
    'local stack; the API and engine are covered by rpAllSales.db.test.ts and the rpAll unit tests',
  ...extra,
});

const writesNothing = (group) => ({
  id: `sales-report.${group.toLowerCase()}.not-applicable`,
  group,
  kind: 'read-only',
  source: 'docs/agent-prompts/lite/00b-REPORT-ADDENDUM.md (report version of the voucher matrix)',
  applicable: false,
  reason:
    'RP_ALL Sales Report writes nothing (every button only builds a selection formula and opens a template, ' +
    'RP_ALL.cs:7572-7678); the addendum turns the voucher groups into filters, totals, drill-down and output, ' +
    'covered by the T02, T03, T05 and T16 cases',
  requiredEvidence: ['browser', 'expected'],
  run: async () => ({}),
});

export const salesReport = {
  feature: 'sales-report',
  title: 'Reports → Sales Report (RP_ALL)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/api/src/modules/reports/rpAll/engine.ts',
    'web/apps/api/src/modules/reports/rpAll/filters.ts',
    'web/apps/api/src/modules/reports/rpAll/salesLayouts.ts',
    'web/apps/api/src/modules/reports/rpAll/salesQuery.ts',
    'web/apps/api/src/modules/reports/rpAll/index.ts',
    'web/apps/api/src/routes/rpAllReport.ts',
    'web/apps/web/test/features/modules/salesReport.mjs',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    MsDataType: 'not ported (no session data type in the web); see inventory §6',
    masters:
      'cases set distinct AC_CITY/AC_AREA, product and group codes; vouchers via real screens',
  },
  cases: [
    C(
      'entry.defaults-and-thirteen-buttons',
      'T01',
      'read-only',
      'MDI_FORM.cs:8901-8910; RP_ALL.cs:6676-6698, 7195-7198 (From = system date), 4364-4378',
      'Reports nav opens the dedicated screen; From and To default to today; lc Code shows the session location and is locked unless it is 00; Employ and Select Book are visible, State is not (Lite); the thirteen Lite buttons in desktop order; refused by the API for a user without the Sales Report right',
    ),
    C(
      'filters.one-at-a-time',
      'T02',
      'read-only',
      'RP_ALL.cs:7620-7665, 7771-7809, 7875-7925, 9147-9185, 11947-11997, 11753-11795',
      'Each selector alone (location, book, Select Book, party, city, area, employee, product, group, item type) yields exactly the voucher ids its button formula selects; a selector the button does not use is listed as ignored',
    ),
    C(
      'filters.combined-and-year-boundary',
      'T02',
      'read-only',
      'RP_ALL.cs:7618 (VCH_DATE >= From and <= To, inclusive)',
      'Combinations narrow as an AND; a voucher on From and on To is included, the day before and after are not; two sale books split exactly',
    ),
    C(
      'formula.register-report-totals',
      'T03',
      'read-only',
      'SaleReport.xml Section10 running totals; SalesSumm.xml Section7/8 (DATE TOTAL, GRAND TOTAL)',
      'Net Amt, Disc, Tax, Bill Tot, Pcs, Gross/Net Wt, LbrAmt and every register column equal the sums of the created vouchers, each bill counted once even with two lines (inventory §6 deliberate difference)',
    ),
    C(
      'formula.item-group-employee-order',
      'T03',
      'read-only',
      'SalesItem.xml, SalesGroupWise.xml (@ItmTotAmt = NET_AMT + IT_TAX_AMT - IT_DISC_AMT), EmpSaleReport.xml (@VchAmt = TOT_AMT - KASAR_AMT), SalesWithOrder.xml',
      'Item-type and product/group header subtotals, the employee "Total :" band and the order-line grand total equal hand sums of the created lines',
    ),
    C(
      'lookup.party-book-product-group',
      'T04',
      'read-only',
      'RP_ALL.cs:7288-7331 (book help), 7336-7430 (party help), 7431-7509 (product help), 9208-9295 (group help)',
      'Enter on an unknown code opens the help, picking fills code and name, Esc cancels, a stale lookup response never overwrites a newer one',
    ),
    C(
      'grouping.templates-and-zoom',
      'T05',
      'read-only',
      'SaleReport.xml groups CO_BOOK/@VchGroup/@SrNo; SalesSumm VCH_DATE; SalesItem IT_TYPE/PR_CODE; EmpSaleReport EMP_CODE',
      'Group bands and nesting match each template; a voucher row zooms to the voucher screen and back',
    ),
    C(
      'invalid.dates-and-empty',
      'T06',
      'refusal',
      'RP_ALL.cs:7510-7541 (SetDate/RongDate); no From/To comparison in any handler',
      'An impossible date is refused before the run; From after To prints an empty report with zero totals and no crash; an empty period prints an empty report',
      { requiredEvidence: ['browser', 'expected', 'database'] },
    ),
    C(
      'source.create-edit-delete-return',
      'T07',
      'read-only',
      'TR_SALE_RTN.cs:12623 (NET_AMT = sale part), 12707 (RTN_NET_AMT = return part)',
      'A sale created on the Sales Invoice screen appears; editing it re-totals; deleting it removes it; a Sales Return appears only under the return prompt (blocked on G243 until the web return writes RTN_NET_AMT)',
    ),
    ...['T08', 'T09', 'T10'].map(writesNothing),
    C(
      'scope.tenant-company-location-year-book-rights',
      'T11',
      'refusal',
      'RP_ALL.cs:7618 (CO_CODE, CO_YEAR), 6660-6671 (location lock); 00b addendum T11',
      'Sentinel vouchers in another tenant, company, location, year and book never appear in the grid, totals or exports; no List right → 403 from the API; no Print right → export refused',
      { requiredEvidence: ['browser', 'expected', 'database'] },
    ),
    ...['T12', 'T13', 'T14'].map(writesNothing),
    C(
      'history.live-master-and-snapshot',
      'T15',
      'read-only',
      'SaleReport prints SL_DATA.AC_NAME (snapshot); SalesSumm prints AC_MAST.AC_NAME (live)',
      'After renaming the party, Sales Report keeps the bill-time name and Sales Reg shows the new one; an older year is never mixed in',
    ),
    C(
      'output.grid-pdf-xlsx-csv-match',
      'T16',
      'output',
      'SaleReport.xml, SalesSumm.xml, SalesItem.xml, SalesGroupWise.xml, EmpSaleReport.xml, SalesWithOrder.xml',
      'Grid, CSV, Excel and print show the same rows and totals in desktop column order and captions over more rows than one page; SalesRtnA4Print is missing from the repository (blocked with that reason)',
    ),
    C(
      'keyboard.selector-run-flow',
      'T17',
      'read-only',
      'RP_ALL.cs:7257-7265 (Esc closes), 7510-7568 (Enter walks the selectors), tab order :4778-6549',
      'The whole run is done with the keyboard: Enter walks From → To → lc → Book → Pr → Gr → Party → City → Area → Item Type, Alt-key buttons run, Esc closes',
    ),
    C(
      'journey.create-edit-delete-return-reconcile',
      'T18',
      'read-only',
      '00b-REPORT-ADDENDUM.md T18; 01-sales-report.md case emphasis',
      'Two item groups on one bill, local and inter-state GST, old-gold exchange, hallmark, order advance, then a Sales Return, all through their screens; the report reconciles to the hand totals and to the ledger, then follows an edit, a delete and the return',
    ),
  ],
};
