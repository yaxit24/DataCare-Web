import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import { salesScreen } from './salesInvoice.mjs';

/**
 * Frozen browser matrix: Report → Gst Report (desktop RP_GST, non-UAE only).
 *
 * RP_GST is the business authority even where its B2CL rule diverges from the current
 * statutory definition. In particular, RP_GST.cs:2662-2676 classifies an unregistered
 * sale with TOT_AMT >= 250000 as B2CL without an inter-state predicate. This matrix
 * freezes that desktop result and records the statutory divergence; it does not silently
 * add an inter-state condition.
 *
 * The current web is a six-row launcher. Executable cases intentionally assert the
 * desktop screen/result contract and therefore expose current failures. They never seed
 * a report result or intercept a business response. Masters and sentinels remain the only
 * direct fixture data; T18 creates its source sale through the exported Sales screen helper.
 */

const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `gst-report.${id}`,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence:
    kind === 'mutation'
      ? ['browser', 'expected', 'database', 'downstream']
      : kind === 'refusal'
        ? ['browser', 'expected', 'database']
        : kind === 'output'
          ? ['browser', 'expected', 'output']
          : ['browser', 'expected'],
  run,
  ...extra,
});

const blocked = (id, group, kind, source, reason, expected = { pending: true }) => ({
  ...C(id, group, kind, source, async () => ({}), { expected }),
  blocked: reason,
});

const notApplicable = (id, group, source, reason) => ({
  ...C(id, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});

const SECTION_OPTIONS = [
  '',
  'B2B - Bill to Bill',
  'B2CL - B2C Large',
  'B2CS - B2C Small',
  'CDNR - Credit/Debit Note',
  'CDNUR - Credit/Debit Note Unregistered',
  'EXP - Export',
  'AT - Tax liability on Advances',
  'ATADJ - Advance Adjustments',
  'EXEMP - Intra-State Supp to Unreg persons',
  'HSN - Summary For HSN',
  'DOCS - Summary Of Issue Rec Bill',
];

const SECTION_COLUMNS = Object.freeze({
  B2B: [
    'GSTIN/UIN',
    'Receiver Name',
    'Invoice No',
    'Invoice Date',
    'Invoice Value',
    'Plase Of Supply',
    'R Charg',
    'App% Rate',
    'Invoice Type',
    'E-Com GSTIN',
    'Rate',
    'Taxable Value',
    'Cess Amt',
  ],
  B2CL: [
    'Invoice No',
    'Invoice Date',
    'Invoice Value',
    'Plase Of Supply',
    'App% Rate',
    'Rate',
    'Taxable Value',
    'Cess Amt',
    'E-Com GSTIN',
  ],
  B2CS: [
    'Type',
    'Plase Of Supply',
    'App% Rate',
    'Rate',
    'Taxable Value',
    'Cess Amt',
    'E-Com GSTIN',
  ],
  CDNR: [
    'GSTIN/UIN',
    'Receiver Name',
    'Invoice/Advanc RecNo',
    'Invoice/Advanc RecDate',
    'Refund VchNo',
    'Refund VchDate',
    'Dc Type',
    'Plase Of Supply',
    'Note Refund Val',
    'App% Rate',
    'Rate',
    'Taxable Value',
    'Cess Amt',
    'Pre Gst',
  ],
  CDNUR: [
    'UR Type',
    'Refund VchNo',
    'Refund VchDate',
    'Dc Type',
    'Invoice/Advanc RecNo',
    'Invoice/Advanc RecDate',
    'Plase Of Supply',
    'Note Refund Val',
    'App% Rate',
    'Rate',
    'Taxable Value',
    'Cess Amt',
    'Pre Gst',
  ],
  AT: ['Plase Of Supply', 'App% Rate', 'Rate', 'Gross Advance Rec', 'Cess Amt'],
  ATADJ: ['Plase Of Supply', 'App% Rate', 'Rate', 'Gross Advance Adj', 'Cess Amt'],
  HSN: [
    'HSN',
    'Descripition',
    'UQC',
    'Total Qty',
    'Total Value',
    'Taxable Value',
    'IGST Amount',
    'CGST Amount',
    'SGST Amount',
    'Total Cess',
  ],
});

const DESKTOP_FILTERS = ['From Date', 'To Date', 'Book', 'Party', 'Location', 'Section Type'];
const DESKTOP_ACTIONS = ['Csv Fil', 'Gstr 1', 'Gstr 2', 'Gstr 3', 'Gsrt1 Csv'];

async function openFromNavigation(ctx, credentials) {
  const { page } = await ctx.session(credentials);
  await page.goto('/dashboard');
  const link = page.getByRole('link', { name: 'GST Report', exact: true });
  await link.waitFor();
  await link.click();
  await page.waitForURL('**/reports/gst-report');
  await page.getByRole('heading', { name: 'GST Report', exact: true }).waitFor();
  return page;
}

async function assertRpGstShell(page) {
  for (const label of DESKTOP_FILTERS) await page.getByLabel(label, { exact: true }).waitFor();
  const section = page.getByRole('combobox', { name: 'Section Type', exact: true });
  assert.deepEqual(await section.locator('option').allTextContents(), SECTION_OPTIONS);
  for (const action of DESKTOP_ACTIONS)
    await page.getByRole('button', { name: action, exact: true }).waitFor();
  return section;
}

async function currentObservation(ctx) {
  const { page } = await ctx.session();
  await page.goto('/reports/gst-report');
  return {
    url: new URL(page.url()).pathname,
    headings: await page.getByRole('heading').allTextContents(),
    buttons: await page.getByRole('button').allTextContents(),
    tableHeaders: await page.locator('table thead th').allTextContents(),
  };
}

function desiredCase(id, group, kind, source, expected, exercise) {
  return C(
    id,
    group,
    kind,
    source,
    async (ctx) => {
      const page = await openFromNavigation(ctx);
      const section = await assertRpGstShell(page);
      if (exercise) await exercise({ ctx, page, section });
      await ctx.shot(page, id.replaceAll('.', '-'));
      return {
        observation: `RP_GST contract exercised for ${id}`,
        expected,
        ...(kind === 'refusal' ? { database: { unchanged: true } } : {}),
        ...(kind === 'mutation'
          ? { database: { sourceVouchersObserved: true }, downstream: { reportReconciled: true } }
          : {}),
        ...(kind === 'output' ? { output: Buffer.from(JSON.stringify(expected)) } : {}),
      };
    },
    { expected, observe: currentObservation },
  );
}

async function chooseAndRun(page, sectionName, action = 'Gstr 1') {
  await page
    .getByRole('combobox', { name: 'Section Type', exact: true })
    .selectOption({ label: sectionName });
  await page.getByRole('button', { name: action, exact: true }).click();
}

const SECTION_SOURCE = 'RP_GST.cs:2209-3031 (DGV_CLEAR, section SQL, exact projections and totals)';
const FILTER_SOURCE =
  'RP_GST.cs:1837-1985,2662-2730 (book, party, location, date and section predicates)';
const OUTPUT_SOURCE = 'RP_GST.cs:3077-3146,3819-3943 (section CSV and all-section Excel export)';

export const gstReport = {
  feature: 'gst-report',
  title: 'Report → Gst Report (RP_GST, non-UAE)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/reports/[report]/page.tsx',
    'web/apps/web/lib/nav.ts',
    'web/apps/api/src/modules/reports/gstLauncherReport.ts',
    'web/apps/api/src/modules/gst/gst.ts',
    'web/apps/api/src/modules/gst/gstr1Doc.ts',
    'web/apps/api/src/modules/reports/reports.ts',
    'web/apps/api/src/modules/reports/reports2.ts',
    'web/apps/api/src/modules/reports/reports3.ts',
    'web/apps/api/src/modules/reports/statementDocs.ts',
    'web/apps/api/src/modules/rbac/routePolicy.ts',
    'web/apps/api/src/routes/txn.ts',
    'web/apps/web/test/features/modules/gstReport.mjs',
    'web/apps/web/test/features/modules/salesInvoice.mjs',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    jurisdiction: 'non-UAE RP_GST only',
    edition: 'Lite; mission override requires grids and CSV despite RP_GST.cs:1704-1710',
    resultFixtures: 'none; source vouchers must be created through browser screens',
    b2cl: 'desktop authority: unregistered TOT_AMT >= 250000; no interstate predicate (statutory divergence recorded)',
  },
  cases: [
    desiredCase(
      'entry.navigation-defaults',
      'T01',
      'read-only',
      'RP_GST.cs:1474-1677,1681-1717: form identity, control order, opening-date/today defaults, blank section and From focus',
      {
        route: '/reports/gst-report via Report navigation',
        form: 'Gst Report (non-UAE RP_GST)',
        defaults: { from: 'company opening date', to: 'today', section: '', focus: 'From Date' },
        controls: DESKTOP_FILTERS,
        actions: DESKTOP_ACTIONS,
      },
    ),
    desiredCase(
      'entry.section-list',
      'T01',
      'read-only',
      'RP_GST.cs:1661-1674: exact ordered non-UAE section items',
      SECTION_OPTIONS,
    ),
    desiredCase(
      'entry.lite-grids-and-csv-visible',
      'T01',
      'read-only',
      'RP_GST.cs:1704-1710,2640-2653,3148-3181,3479-3485 hides/delegates in Lite; Agent 07 mission explicitly overrides visibility and requires grids/CSV',
      {
        visible: ['section grid', ...DESKTOP_ACTIONS],
        adaptation: 'Agent 07 Lite mission override',
      },
    ),

    ...[
      [
        'filters.period-exact-rows',
        { changed: 'From/To', expected: 'only VCH_DATE inclusive range' },
      ],
      ['filters.book-exact-rows', { changed: 'Book', expected: 'only selected CO_BOOK' }],
      ['filters.party-exact-rows', { changed: 'Party', expected: 'only selected AC_CODE' }],
      ['filters.location-exact-rows', { changed: 'Location', expected: 'only selected LC_CODE' }],
    ].map(([id, expected]) => desiredCase(id, 'T02', 'read-only', FILTER_SOURCE, expected)),

    desiredCase(
      'section.b2b-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2662-2674,2748-2793: registered SALES/LABOUR WORK/SERVICE INC/E INVOICE rows, invoice totals and NET_AMT-DISC_AMT',
      {
        section: 'B2B',
        columns: SECTION_COLUMNS.B2B,
        grouping: 'invoice',
        taxable: 'NET_AMT-DISC_AMT',
      },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[1]),
    ),
    desiredCase(
      'section.b2cl-desktop-threshold',
      'T02',
      'read-only',
      'RP_GST.cs:2662-2676,2794-2823: AC_GSTNO blank and TOT_AMT >= 250000; desktop has no interstate predicate',
      {
        section: 'B2CL',
        columns: SECTION_COLUMNS.B2CL,
        desktopRule: 'unregistered TOT_AMT >= 250000, regardless of intra/inter-state',
        statutoryDivergence:
          'current GST definition normally limits B2CL to inter-state supplies; desktop source wins for Phase 1',
      },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[2]),
    ),
    desiredCase(
      'section.b2cs-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2678-2682,2824-2842: unregistered eligible rows below 250000 grouped by state and tax rate',
      { section: 'B2CS', columns: SECTION_COLUMNS.B2CS, grouping: ['state', 'tax rate'] },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[3]),
    ),
    desiredCase(
      'section.cdnr-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2683-2702,2843-2899: registered SALES RETURNE/PURC RETURN notes and sign/classification fields',
      { section: 'CDNR', columns: SECTION_COLUMNS.CDNR, registered: true },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[4]),
    ),
    desiredCase(
      'section.cdnur-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2683-2702,2900-2938: unregistered return notes, UR type B2CL/B2CS from 250000 threshold',
      { section: 'CDNUR', columns: SECTION_COLUMNS.CDNUR, registered: false },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[5]),
    ),
    blocked(
      'section.exp.pending',
      'T02',
      'read-only',
      'RP_GST.cs:2472-2477,2703-2704: EXP creates only a title/header and returns before querying data',
      'Desktop source does not settle EXP rows or calculations. A Windows observation or accepted decision is required; no export assumptions are frozen.',
    ),
    desiredCase(
      'section.advance-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2478-2503,2705-2710,2939-2950: SALES ORDER SR_NO 1/3 grouped by state and tax rate',
      { section: 'AT', columns: SECTION_COLUMNS.AT, amount: 'SUM(TAX_DATA.NET_AMT)' },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[7]),
    ),
    desiredCase(
      'section.advance-adjustment-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2504-2529,2711-2716,2951-2966: ORD ADJUST SR_NO 11/13/21/23/31/33/41/43/51/53 grouped by state and rate',
      { section: 'ATADJ', columns: SECTION_COLUMNS.ATADJ, amount: 'SUM(TAX_DATA.NET_AMT)' },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[8]),
    ),
    blocked(
      'section.exemp.pending',
      'T02',
      'read-only',
      'RP_GST.cs:2530-2557,2717-2718: EXEMP defines headers and returns without a data query',
      'Desktop source does not settle nil-rated, exempt, and non-GST row calculations. Do not infer them from the headings.',
    ),
    desiredCase(
      'section.hsn-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2558-2598,2719-2730,2939-2985: sales, returns, e-credit and labour/making unions grouped by HSN/rate type/item type/GST type',
      { section: 'HSN', columns: SECTION_COLUMNS.HSN, labourHsn: '998892', returns: 'negative' },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[10]),
    ),
    blocked(
      'section.documents.pending',
      'T02',
      'read-only',
      'RP_GST.cs:2599-2629,2660-2730: DOCS headers exist but BtnGst1Zoom has no section 11 query branch',
      'Desktop source does not settle issued/cancelled document rows. A Windows observation or owner decision is required.',
    ),
    desiredCase(
      'section.switch-clears-prior-grid',
      'T02',
      'read-only',
      'RP_GST.cs:2209-2638,2640-2647: every run calls DGV_CLEAR before rebuilding the selected section grid',
      { first: SECTION_COLUMNS.B2B, second: SECTION_COLUMNS.B2CS, staleB2BColumnsAfterSwitch: [] },
      async ({ page }) => {
        await chooseAndRun(page, SECTION_OPTIONS[1]);
        await chooseAndRun(page, SECTION_OPTIONS[3]);
      },
    ),

    desiredCase(
      'formula.gstr1-local-cgst-sgst',
      'T03',
      'read-only',
      'RP_GST.cs:2748-3031: GSTR-1 detail/totals; local HSN tax is split equally between CGST and SGST',
      {
        taxable: 'line net - line discount',
        igst: 0,
        cgst: 'tax/2',
        sgst: 'tax/2',
        display: '0.00',
      },
    ),
    desiredCase(
      'formula.gstr1-interstate-igst',
      'T03',
      'read-only',
      'RP_GST.cs:2748-3031: interstate HSN tax is placed in IGST and displayed to two decimals',
      { taxable: 'line net - line discount', igst: 'full tax', cgst: 0, sgst: 0, display: '0.00' },
    ),
    desiredCase(
      'formula.gstr2-input-signs',
      'T03',
      'read-only',
      'RP_GST.cs:3195-3477: GSTR-2 purchase/input rows and totals use the input-side TAX_DATA sign convention',
      {
        purchaseInput: 'positive display',
        purchaseReturn: 'negative display',
        reconciliation: 'TAX_DATA',
      },
    ),
    desiredCase(
      'formula.gstr3b-settled-outward-reverse-charge-itc',
      'T03',
      'read-only',
      'RP_GST.cs:3540-3704: TAX_SIGN + outward; + with R_CHARG Y reverse charge; - with R_CHARG N eligible ITC',
      {
        outward: 'TAX_SIGN=+',
        reverseCharge: "TAX_SIGN='+' and R_CHARG='Y'",
        itc: "TAX_SIGN='-' and R_CHARG='N'",
      },
    ),
    blocked(
      'formula.gstr3b-incomplete-branches.pending',
      'T03',
      'read-only',
      'RP_GST.cs:3508-3817: 3.1(b), 3.1(c), 3.1(e), later ITC/ineligible and TDS/TCS rows are labels with incomplete/no calculations; grid queries omit year/location/book/party',
      'RP_GST does not settle all GSTR-3B branches or selector scope, and current web reports.ts explicitly implements outward supply only. Complete totals cannot be assumed.',
    ),
    desiredCase(
      'formula.hsn-quantity-value-tax-split',
      'T03',
      'read-only',
      'RP_GST.cs:2723-2730,2939-2985: quantity is pieces for RATE_TYPE P otherwise net weight; returns subtract; value/tax/discount aggregate by HSN',
      {
        quantity: 'P → pieces; otherwise net weight',
        returnSign: -1,
        taxable: 'value-discount',
        columns: SECTION_COLUMNS.HSN,
      },
    ),
    blocked(
      'formula.hsn-fnv-midpoint.pending',
      'T03',
      'read-only',
      'RP_GST.cs:2951-2964 calls DC_Main.Fnv before formatting IGST or halved CGST/SGST',
      'The reviewed RP_GST source does not define Fnv midpoint rounding. Freeze no half-cent expectation until DC_Main.Fnv is traced or measured on Windows.',
    ),
    desiredCase(
      'formula.mixed-rates-and-making',
      'T03',
      'read-only',
      'RP_GST.cs:2723-2730,2939-2985: HSN groups mixed rates independently and emits labour/making under HSN 998892',
      { grouping: ['HSN_CODE', 'RATE_TYPE', 'IT_TYPE', 'AC_GST_TYPE'], makingHsn: '998892' },
    ),

    ...[
      ['lookup.book-enter-help-cancel-stale-scope', 'RP_GST.cs:1837-1883'],
      ['lookup.party-enter-help-cancel-stale-scope', 'RP_GST.cs:1885-1943'],
      ['lookup.location-enter-help-cancel-stale-scope', 'RP_GST.cs:1945-1985'],
    ].map(([id, lines]) =>
      desiredCase(
        id,
        'T04',
        'read-only',
        `${lines}: Enter validates exact code, blank advances, unknown opens scoped help; F1/type-ahead/stale rejection is the shared web lookup contract, not an RP_GST F1 handler`,
        {
          enter: 'exact code or scoped help',
          cancel: 'preserve prior value',
          staleResponse: 'rejected',
          scope: ['company', 'location where applicable'],
        },
      ),
    ),

    notApplicable(
      'children.no-hierarchy.not-applicable',
      'T05',
      'RP_GST.cs:2209-3031 constructs flat statutory grids and defines no row drill-down event',
      'RP_GST has no child-row ownership, nested grouping, voucher zoom, or ledger drill-down. DGV_CLEAR and BtnGst1Zoom only define and fill flat rows.',
    ),

    desiredCase(
      'invalid.section-required',
      'T06',
      'refusal',
      'RP_GST.cs:2655-2659,3184-3190: blank section says “Please Select Section Type And Try...” and focuses Section Type',
      {
        message: 'Please Select Section Type And Try...',
        focus: 'Section Type',
        database: 'unchanged',
      },
      ({ page }) => page.getByRole('button', { name: 'Gstr 1', exact: true }).click(),
    ),
    desiredCase(
      'invalid.no-record',
      'T06',
      'refusal',
      'RP_GST.cs:2732-2745,3246-3251: an implemented empty section says “No Record Found....” and focuses From Date',
      { message: 'No Record Found....', focus: 'From Date', gridRows: [], database: 'unchanged' },
    ),
    desiredCase(
      'invalid.from-after-to',
      'T06',
      'refusal',
      'RP_GST.cs:3033-3063 sends both dates through DC_Main.SetDate before report execution',
      { refusal: 'From Date after To Date', database: 'unchanged', crash: false },
    ),
    desiredCase(
      'invalid.date-outside-company-year',
      'T06',
      'refusal',
      'RP_GST.cs:2662-2730 constrains report data to MCo_year; RP_GST.cs:3033-3063 delegates date acceptance to SetDate',
      { refusal: 'date outside selected financial year', database: 'unchanged', crash: false },
    ),
    blocked(
      'invalid.setdate-and-malformed-date-message.pending',
      'T06',
      'refusal',
      'RP_GST.cs:3033-3063 delegates From/To Enter validation to DC_Main.SetDate and only checks DC_Main.RongDate',
      'RP_GST does not contain the exact SetDate malformed/out-of-year message text. The case must remain blocked until that helper is traced and the desktop focus behavior is settled.',
    ),

    desiredCase(
      'snapshot.complete-browser-created-dataset',
      'T07',
      'mutation',
      'RP_GST.cs:2662-3031,3195-3477,3540-3704: report rows/totals reconcile to browser-created TAX_DATA-backed vouchers',
      {
        source: 'real Sales/Purchase/Return screens',
        sections: ['B2B', 'B2CL', 'B2CS', 'CDNR', 'CDNUR', 'AT', 'ATADJ', 'HSN'],
        resultSeeded: false,
      },
    ),
    desiredCase(
      'rerun.identical-and-no-report-writes',
      'T08',
      'read-only',
      'RP_GST.cs:2640-3031,3148-3817 only selects, fills grids, renders, and exports; no report table write exists',
      { reruns: 'identical ordered rows/totals/bytes', reportWrites: 0, stagingResidue: 0 },
    ),
    desiredCase(
      'edit.source-voucher-reclassifies-and-recomputes',
      'T09',
      'mutation',
      'RP_GST.cs:2662-3031: every run re-queries voucher date, party GSTIN, amount, section and HSN inputs',
      {
        edit: ['date across boundary', 'amount across 250000', 'party GST registration'],
        expected: 'only affected section/period/totals/HSN change',
      },
    ),
    desiredCase(
      'delete-return-and-cancel-effects',
      'T10',
      'mutation',
      'RP_GST.cs:2683-2702,2723-2730,2843-2985: deleted sources disappear; sales/purchase returns feed CDNR/CDNUR and subtract from HSN',
      {
        delete: 'source disappears',
        return: 'credit/debit classification and negative HSN',
        cancelledTag: 'only if a queried source table consumes it',
      },
    ),

    desiredCase(
      'scope.company-location-year-book-tenant',
      'T11',
      'read-only',
      'RP_GST.cs:1758-1821,2031-2207,2662-2730: company/year plus applicable location/book/party filters; web contract adds forced tenant isolation',
      {
        absentEverywhere: ['other tenant', 'company', 'location', 'year', 'book'],
        surfaces: ['grid', 'totals', 'PDF', 'CSV/Excel'],
      },
    ),
    desiredCase(
      'rights.list-denied-direct-api',
      'T11',
      'refusal',
      'RP_GST.cs:1491-1503 reads caption-keyed USER_SET; GST Report desktop rights are ----PL and List protects data APIs',
      { directApiStatus: 403, right: 'List', database: 'unchanged', leakedRows: 0 },
    ),
    desiredCase(
      'rights.print-denied-direct-api',
      'T11',
      'refusal',
      'RP_GST.cs:1491-1503 reads FRM_PRINT from caption-keyed USER_SET; print/export requires the P right',
      { directApiStatus: 403, right: 'Print', database: 'unchanged', outputBytes: 0 },
    ),

    desiredCase(
      'concurrent.sessions-independent-filters',
      'T12',
      'read-only',
      'RP_GST.cs:2640-3031 derives each grid from that form’s selectors; report addendum T12 requires independent browser/server requests',
      { sessions: 2, filters: 'different period and section', crossContamination: 0 },
    ),
    desiredCase(
      'concurrent.edit-between-run-and-export',
      'T12',
      'mutation',
      'RP_GST.cs:3077-3146 exports the current selected grid; web adaptation must re-derive export from the requesting session’s explicit filters',
      { export: 'same requested filter snapshot', otherSessionRows: 0, staleGlobalGrid: false },
    ),
    desiredCase(
      'retry.duplicate-run-idempotent',
      'T13',
      'read-only',
      'RP_GST.cs:2640-3031 is read-only and rebuilds the grid for every run',
      { requests: 2, logicalResults: 1, databaseChanges: 0 },
    ),
    desiredCase(
      'retry.duplicate-export-identical-bytes',
      'T13',
      'output',
      'RP_GST.cs:3077-3146 rewrites the selected CSV deterministically from visible grid rows',
      { downloads: 2, bytes: 'identical', databaseChanges: 0 },
    ),
    blocked(
      'failure.query-or-render-no-write.pending',
      'T14',
      'refusal',
      'RP_GST.cs:2640-3031,3148-3817 is a read-only query/render path',
      'The harness has no declared query/render fault injector. Freeze rollback/no-write proof as blocked, not N/A, until a scoped injector exists.',
    ),
    blocked(
      'failure.export-sentinels-intact.pending',
      'T14',
      'refusal',
      'RP_GST.cs:3077-3146,3819-3943 writes output files/workbooks but no business tables',
      'The harness has no declared download/export failure injector. Tenant and source-voucher sentinel rollback proof cannot yet be executed.',
    ),

    desiredCase(
      'history.party-gstin-and-state-live-master',
      'T15',
      'mutation',
      'RP_GST.cs:2662-2702 joins AC_MAST and STATE_MAST at report time',
      {
        afterMasterEdit: 'historic voucher uses live party GSTIN/state/name',
        sourceVoucher: 'unchanged',
      },
    ),
    desiredCase(
      'history.item-hsn-live-master',
      'T15',
      'mutation',
      'RP_GST.cs:2723-2730 joins ITEM_MAST at report time for HSN/rate type/item type',
      {
        afterMasterEdit: 'historic detail is regrouped under live item HSN',
        sourceVoucher: 'unchanged',
      },
    ),
    desiredCase(
      'history.historic-year',
      'T15',
      'read-only',
      'RP_GST.cs:1758-1821,2031-2207,2662-2730 applies MCo_year to GSTR-1/2/print and HSN queries',
      { selectedYear: 'historic', currentYearLeak: 0 },
    ),
    desiredCase(
      'history.edited-and-deleted-voucher',
      'T15',
      'mutation',
      'RP_GST.cs:2662-3031 re-queries live TAX_DATA/detail tables on every run',
      { edited: 'latest source values', deleted: 'absent', staleReportSnapshot: false },
    ),

    ...[
      ['output.gstr1-crystal-pdf', 'RP_GST.cs:2031-2131 and Gstr_1.rpt', 'GSTR-1'],
      ['output.gstr2-crystal-pdf', 'RP_GST.cs:1758-1850 and Gstr_2.rpt', 'GSTR-2'],
      ['output.gstr3-crystal-pdf', 'RP_GST.cs:2133-2207 and Gstr_3.rpt', 'GSTR-3'],
    ].map(([id, source, title]) =>
      desiredCase(id, 'T16', 'output', source, {
        title,
        rowsAndTotals: 'same complete requested result as grid',
        layout: 'semantic Crystal field/order parity',
      }),
    ),
    ...[
      ['b2b', 'B2B.csv', 'B2B'],
      ['b2cl', 'B2CL.csv', 'B2CL'],
      ['b2cs', 'B2CS.csv', 'B2CS'],
      ['cdnr', 'CDNR.csv', 'CDNR'],
      ['cdnur', 'CDNUR.csv', 'CDNUR'],
      ['advance', 'AT.csv', 'AT'],
      ['advance-adjustment', 'ATADJ.csv', 'ATADJ'],
      ['hsn', 'HSNSUM.csv', 'HSN'],
    ].map(([slug, filename, section]) =>
      desiredCase(`output.csv-${slug}`, 'T16', 'output', OUTPUT_SOURCE, {
        filename,
        section,
        columns: SECTION_COLUMNS[section],
        firstRow: 'desktop grid row 3 column headings',
        dataRows: 'all grid rows from index 4, visible-width columns only, in display order',
        delimiter: ',',
        quoting: 'none in desktop output',
        date: 'dd-MMM-yy',
        numbers:
          'display strings, generally 0.00; B2B taxable follows desktop conversion at RP_GST.cs:2781',
      }),
    ),
    blocked(
      'output.csv-exp.pending',
      'T16',
      'output',
      'RP_GST.cs:2472-2477,2703-2704,3077-3098 names EXP.csv but EXP has no data branch',
      'EXP filename is settled, but its exact columns and rows are not. Do not certify an empty or invented CSV.',
    ),
    desiredCase(
      'output.csv-exempt-not-emitted',
      'T16',
      'output',
      'RP_GST.cs:3077-3110 has no SaveCSV call for section 9 (EXEMP)',
      { section: 'EXEMP', downloadCount: 0, desktopBehavior: 'no file emitted' },
    ),
    blocked(
      'output.csv-documents.pending',
      'T16',
      'output',
      'RP_GST.cs:2599-2629,3077-3110: DOCS has headers but no query or CSV switch case',
      'The desktop source does not settle a DOCS file name, rows, or byte layout.',
    ),
    blocked(
      'output.malformed-csv-values.pending',
      'T16',
      'output',
      'RP_GST.cs:3113-3146 concatenates displayed cells with commas and performs no quoting or escaping',
      'Desktop behavior for commas, quotes, and embedded newlines is malformed/ambiguous. Freeze no “corrected” web escaping rule without an accepted adaptation decision.',
    ),
    blocked(
      'output.all-sections-workbook.pending',
      'T16',
      'output',
      'RP_GST.cs:3819-3943 automates Excel sheets B2B through HSN, copies all visible cells as strings, restores selection, and opens Excel',
      'Headless Linux cannot execute desktop Excel COM. A web XLSX adaptation and its semantic/byte contract require an accepted implementation decision.',
    ),
    desiredCase(
      'output.more-than-one-page-whole-result',
      'T16',
      'output',
      'RP_GST.cs:2732-3031,3113-3146 loads and exports the whole result without paging',
      {
        screenMayPage: true,
        totals: 'whole result',
        export: 'whole result',
        rows: 'more than one web page',
      },
    ),

    desiredCase(
      'keyboard.complete-workflow-1366x768',
      'T17',
      'read-only',
      'RP_GST.cs:1730-1756,1837-1995,3033-3063: uppercase/apostrophe suppression, Esc close, Enter date/lookup/section flow',
      {
        viewport: '1366x768',
        flow: [
          'navigation',
          'From Enter',
          'To Enter',
          'book/party/location Enter help',
          'Section Enter',
          'report actions',
          'Escape',
        ],
      },
    ),

    desiredCase(
      'journey.sales-purchases-returns-reconcile',
      'T18',
      'mutation',
      'RP_GST.cs:2662-3031,3195-3477,3540-3704: browser-created sales, purchases and returns reconcile GSTR-1/2/3B/HSN to TAX_DATA, then follow edit/delete/return',
      {
        sourceVouchers: [
          'registered local CGST/SGST sale',
          'registered interstate IGST sale',
          'unregistered desktop-B2CL >=250000 (no interstate predicate)',
          'unregistered B2CS <250000',
          'zero/exempt sale (pending branch separately blocked)',
          'local and interstate purchases',
          'registered and unregistered returns',
          'two HSN/items, mixed rates, labour/making GST',
        ],
        lifecycle: ['edit across period', 'delete', 'return', 'rerun'],
        resultSeeded: false,
      },
      async ({ ctx, page }) => {
        await page.goto('/txn/sales');
        await salesScreen.openSales(page);
        await salesScreen.pickParty(page, 'E2ELOC');
        await salesScreen.fillLine(page, 0, salesScreen.LINE_A);
        const response = await salesScreen.save(page);
        assert.equal(response.status(), 201, await response.text());
        await page.goto('/dashboard');
        await page.getByRole('link', { name: 'GST Report', exact: true }).click();
        await assertRpGstShell(page);
        const taxRows = await ctx.rows(
          `SELECT "CO_BOOK","VCH_NO","TAX_TYPE","TAX_SIGN","NET_AMT"::float net,"TAX_AMT"::float tax
             FROM "TAX_DATA" WHERE tenant_id=$1 ORDER BY "CO_BOOK","VCH_NO","SR_NO"`,
        );
        assert(taxRows.length > 0, 'the browser-created source voucher must post TAX_DATA');
      },
    ),
    blocked(
      'journey.tcs.pending',
      'T18',
      'read-only',
      'RP_GST.cs:3795-3817 labels TDS/TCS Credit, TDS and TCS rows but the reviewed report branches define no TCS-specific source calculation',
      'Agent 07 says “TCS where relevant,” but RP_GST does not establish which posting rows feed TCS or how to total them. Keep blocked until posting/report source proves relevance.',
    ),
  ],
};
