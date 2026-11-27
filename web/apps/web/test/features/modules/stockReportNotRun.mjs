/**
 * Stock Report cases this module does not execute: the database-layer cases (proven by
 * apps/api/test/stockReport.db.test.ts), the N/A cases, and the ones still blocked with their reason.
 * Every id of orchestration/work/WP-16/cases.md appears once across stockReport.mjs and this table; a case that
 * has a browser implementation is dropped from here by id.
 */
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `stock-report.${id}`,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence: ['browser', 'expected'],
  run,
  ...extra,
});

const REST = [
  [
    'entry.tag-stock-stays-separate',
    'T01',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'entry.default-gross-from-setting',
    'T01',
    'blocked',
    'the gross-from-setting default needs the STK_RPT_TYPE company setting changed through the settings screen',
  ],
  [
    'entry.item-type-default-silver',
    'T01',
    'blocked',
    'the web has no company metal-type setting (MsMetalType); the default is Gold',
  ],
  [
    'entry.future-dated-warning',
    'T01',
    'blocked',
    'the future-dated-voucher warning on open is not built in this PR',
  ],
  ['entry.f3-shortcut', 'T01', 'blocked', 'the F3 shortcut is not built in this PR'],
  [
    'entry.menu-needs-view-right',
    'T01',
    'blocked',
    'the menu-level View refusal for this caption is not exercised in the browser in this PR (the API returns 403, stockReport.db.test.ts)',
  ],
  [
    'filter.date-range',
    'T02',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'filter.from-after-to',
    'T02',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'filter.item-type',
    'T02',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'filter.account',
    'T02',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'filter.tag-number',
    'T02',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'filter.item-code',
    'T02',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'filter.product-group',
    'T02',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'filter.design',
    'T02',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'filter.safe',
    'T02',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'filter.counter',
    'T02',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'filter.lc-default-and-isolation',
    'T02',
    'db',
    'a foreign location is refused (409/400) and the location sentinel never reaches a figure',
  ],
  [
    'filter.sql-metacharacters',
    'T02',
    'db',
    'tag, account and design filters carrying SQL text return an empty result and leave the tables intact',
  ],
  [
    'formula.closing-identity-per-row',
    'T03',
    'db',
    'Closing = Opening + every movement on every row and the total in all eight dimensions, and equals an independent signed sum',
  ],
  [
    'formula.dimension-product',
    'T03',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'formula.dimension-safe',
    'T03',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'formula.dimension-design',
    'T03',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'formula.dimension-size',
    'T03',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'formula.dimension-counter',
    'T03',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'formula.counter-blank-is-001',
    'T03',
    'db',
    'blank counters are reported under 001 and the rows stay blank after every run',
  ],
  [
    'formula.dimension-trading',
    'T03',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'formula.dimension-item-lot',
    'T03',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'formula.rows-split-by-metal',
    'T03',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'formula.hidden-items-excluded',
    'T03',
    'db',
    'a STK_DISPLAY = N item leaves every column and the total; NULL stays shown',
  ],
  ['formula.data-type-filter', 'T03', 'db', 'data type A excludes a B row, C includes it'],
  ['formula.year-scope', 'T03', 'db', 'a previous-year movement never reaches Opening or Closing'],
  ['formula.onhandnet-differs', 'T03', 'na'],
  [
    'lookup.code-help-on-enter',
    'T04',
    'blocked',
    'the code boxes are plain text boxes in this PR; the Enter-opens-help lookup is not built',
  ],
  [
    'lookup.stale-and-cancel',
    'T04',
    'blocked',
    'the code boxes are plain text boxes in this PR; the Enter-opens-help lookup is not built',
  ],
  ['lookup.lc-code', 'T04', 'na'],
  [
    'drill.purchase',
    'T05',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'drill.inward-and-outward',
    'T05',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'drill.closing-signed-total',
    'T05',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'drill.tag-filter-fine',
    'T05',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'drill.non-drill-columns',
    'T05',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'drill.same-filters-as-summary',
    'T05',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'drill.excel-uses-visible-grid',
    'T05',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'zoom.lite-voucher-targets',
    'T05',
    'blocked',
    'no web voucher screen opens a voucher by its key (no deep link), so the voucher zoom is not built in this PR',
  ],
  ['zoom.non-lite-books', 'T05', 'na'],
  [
    'zoom.item-opening-refused',
    'T05',
    'blocked',
    'no web voucher screen opens a voucher by its key (no deep link), so the voucher zoom is not built in this PR',
  ],
  [
    'zoom.needs-target-read-right',
    'T05',
    'blocked',
    'no web voucher screen opens a voucher by its key (no deep link), so the voucher zoom is not built in this PR',
  ],
  ['zoom.not-from-merged-or-other-lc', 'T05', 'na'],
  [
    'invalid.print-right-no-rights-row',
    'T06',
    'db',
    'a user with no rights row for Stock Report is refused (403) on the screen and the exports',
  ],
  [
    'invalid.item-picker-nothing-ticked',
    'T06',
    'blocked',
    'the InOut item-ledger picker and print are not built in this PR',
  ],
  [
    'invalid.bad-date-text',
    'T06',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'create.item-opening',
    'T07',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'create.tag-opening',
    'T07',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'create.purchase',
    'T07',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'create.sale',
    'T07',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'create.sales-return',
    'T07',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'create.purchase-return',
    'T07',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'create.stock-adjust',
    'T07',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'create.tag-cancel',
    'T07',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'create.approval-issue',
    'T07',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'create.counter-transfer-fixture',
    'T07',
    'db',
    'the two T rows are seeded and the hidden transfer columns and the Counter dimension equal the oracle',
  ],
  [
    'reopen.runs-write-nothing',
    'T08',
    'db',
    'row counts and blank counters are identical before and after every dimension, drill-down and export, for two tenants',
  ],
  [
    'reopen.same-result-twice',
    'T08',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'edit.purchase-quantity',
    'T09',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'edit.voucher-date-moves-column',
    'T09',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'delete.sale-restores-stock',
    'T10',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'delete.tag-cancel-and-approval-return',
    'T10',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'scope.second-tenant-sentinel',
    'T11',
    'db',
    "a second tenant's 1000 pcs never appears in any figure",
  ],
  [
    'scope.company-merge-isolation',
    'T11',
    'db',
    'CO_STK_MERGE = Y adds the second company inside the tenant only',
  ],
  [
    'scope.list-right',
    'T11',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'concurrency.two-users-print',
    'T12',
    'db',
    'two simultaneous exports each carry their own window and totals',
  ],
  ['concurrency.save-during-run', 'T12', 'na'],
  ['retry.duplicate-request', 'T13', 'na'],
  ['rollback.none', 'T14', 'na'],
  [
    'config.gross-setting-changes-default-only',
    'T15',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'config.master-edit-after-voucher',
    'T15',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'config.cancelled-tag-and-previous-year',
    'T15',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  ['config.emp-isu-adjustment', 'T15', 'na'],
  [
    'output.group-print',
    'T16',
    'blocked',
    'the Crystal templates are not rendered; Print uses the browser print of the grid',
  ],
  [
    'output.titles-by-dimension',
    'T16',
    'blocked',
    'the Crystal templates are not rendered; Print uses the browser print of the grid',
  ],
  [
    'output.safe-summary-question',
    'T16',
    'blocked',
    'the Crystal templates (GroupStkRpt, SafeStkRpt, SafeStkSumm) are not rendered; Print uses the browser print of the grid',
  ],
  [
    'output.print-uses-screen-filters',
    'T16',
    'blocked',
    'the Crystal templates are not rendered; Print uses the browser print of the grid',
  ],
  [
    'output.excel-export',
    'T16',
    'blocked',
    'the Excel file is covered at the API layer by the export test; the browser download was not opened in this run',
  ],
  [
    'output.large-result-totals',
    'T16',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'output.item-ledger-print',
    'T16',
    'blocked',
    'the InOut item-ledger picker and print are not built in this PR',
  ],
  ['output.print-title-with-lc', 'T16', 'na'],
  ['output.opening-print-layout', 'T16', 'na'],
  ['keyboard.arrows-and-escape', 'T17', 'blocked', 'not run in this PR'],
  ['keyboard.full-run-without-mouse', 'T17', 'blocked', 'not run in this PR'],
  ['keyboard.alt-accelerators', 'T17', 'blocked', 'not run in this PR'],
  [
    'journey.build-and-reconcile',
    'T18',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'journey.non-tag-movements-are-reported',
    'T18',
    'db',
    'closing 138.000 from loose plus tag movements, 15.000 tag-only',
  ],
  [
    'journey.approval-round-trip',
    'T18',
    'blocked',
    'the case needs vouchers created through the real Sales, Purchase, Tag or Approval screens, or a screen flow this PR did not drive; the figures it checks are proven at the API layer by stockReport.db.test.ts; stays in the denominator',
  ],
  [
    'settings.co-year-and-data-type-from-session',
    'T15',
    'db',
    'the session year decides the rows; data type A, B and C',
  ],
];

/** cases.md statuses that are already N/A or blocked carry their reason there; this repeats the short form. */
const NA_REASON = {
  'formula.onhandnet-differs':
    'the shared onHandNet() defect is reported separately; the report never calls it',
  'zoom.non-lite-books': 'the target menus are outside Lite (decision 5)',
  'concurrency.save-during-run':
    'a read-only report has no race outcome beyond one consistent snapshot',
  'retry.duplicate-request': 'reads are idempotent and the web writes nothing',
  'rollback.none': 'the report has no write set',
  'output.opening-print-layout': 'layout fidelity is listed under "Not covered"',
  'lookup.lc-code':
    'Lite has no LC box: RP_STOCK.cs:3693 shows it only when `DC_Main.MsLcBoxShow` is true, and MS_OPNCOMP.cs:1415-1428 sets that only when `MsSoftType` is "E" (Enterprise) and the company has more than one LOCT_MAST row. The Location menu is edition E in docs/handbook/menu-editions.json, so a Lite company has the one location 00; there is no LC code to look up.',
  'zoom.not-from-merged-or-other-lc':
    'Lite has no LC box: RP_STOCK.cs:3693 shows it only when `DC_Main.MsLcBoxShow` is true, and MS_OPNCOMP.cs:1415-1428 sets that only when `MsSoftType` is "E" (Enterprise) and the company has more than one LOCT_MAST row. The Location menu is edition E in docs/handbook/menu-editions.json, so a Lite company has the one location 00; the other-LC half cannot arise. The merged-company half is covered by the zoom answer returning nothing while CO_STK_MERGE is Y (stockReport.db.test.ts).',
  'output.print-title-with-lc':
    'Lite has no LC box: RP_STOCK.cs:3693 shows it only when `DC_Main.MsLcBoxShow` is true, and MS_OPNCOMP.cs:1415-1428 sets that only when `MsSoftType` is "E" (Enterprise) and the company has more than one LOCT_MAST row. The Location menu is edition E in docs/handbook/menu-editions.json, so a Lite company has the one location 00; no print title carries an LC code.',
  'config.emp-isu-adjustment':
    'the only form that writes `EMP ISU` rows is the Stock Isu menu (`MDI_FORM.cs:9299 {{DC_Main.CurBookHelp("EMP ISU");}}`), which is edition E (Enterprise) in docs/handbook/menu-editions.json (Karigar/Stock Isu), not Lite, so no Lite company holds the rows the adjustment (`RP_STOCK.cs:4907-4994`) reads; the web report does not carry that adjustment.',
};
/** Blocked in the frozen case list itself (orchestration/work/WP-16/cases.md), with the reason written there. */
const FROZEN_BLOCKED = {
  'output.titles-by-dimension':
    'the case prints the Safe dimension through the Crystal template `SafeStkRpt`, which is MISSING from `extraction_output/rpt_xml/`, so its title and layout cannot be read. The web prints the grid as a PDF (the other dimensions share the desktop title strings, asserted by `stock-report.output.group-print`).',
  'output.safe-summary-question':
    'the question chooses between the Crystal templates `SafeStkRpt` (missing from `extraction_output/rpt_xml/`) and `SafeStkSumm`; the web prints one table for both, so the answer has no web effect to assert.',
  'keyboard.alt-accelerators':
    'the desktop gives two buttons the same Alt letter (&I Item and InOut, &C Counter and Cancel, &S Safe and Size: RP_STOCK.cs:1977, 1991, 2438, 2490, 2516, 2706). Which one an Alt press reaches is WinForms mnemonic cycling (focus-order dependent), which RP_STOCK.cs does not state. Question for the owner: copy the WinForms cycle (the next matching button after the focused control), or give each duplicated letter to one button?',
};
const generate = (implemented) =>
  REST.filter(([id]) => !implemented.has(`stock-report.${id}`)).map(
    ([id, group, status, reason]) => {
      const base = C(id, group, 'read-only', 'orchestration/work/WP-16/cases.md', async () => ({}));
      if (status === 'na')
        return {
          ...base,
          applicable: false,
          reason: NA_REASON[id] ?? 'see orchestration/work/WP-16/cases.md',
        };
      if (status === 'db')
        return {
          ...base,
          applicable: false,
          reason: `proven at the API layer by apps/api/test/stockReport.db.test.ts: ${reason}`,
        };
      return {
        ...base,
        blocked: FROZEN_BLOCKED[id] ? `WP-16 cases.md: ${FROZEN_BLOCKED[id]}` : `WP-16: ${reason}`,
      };
    },
  );

/** The not-run entries for every case id the module has no browser implementation for. */
export const notRunCases = (implementedIds) => generate(new Set(implementedIds));
