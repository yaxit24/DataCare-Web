import { huidResidualCases } from './huidReportResiduals.mjs';
import { USERS } from '../fixtures/catalogue.mjs';
import { huidUser } from './huidSeed.mjs';
import { filterCases } from './huidReportFilters.mjs';
import { outputCases } from './huidReportOutput.mjs';
import { huidJourneyCases } from './huidReportJourney.mjs';

/**
 * Feature: Report → HuId Report (RP_HUID.cs, web /reports/huid). This module combines the case arrays of
 * huidReportFilters.mjs (T01, T02, T03, T06, T04, T05, T11, T12) and huidReportOutput.mjs (T15, T16, T17) with
 * the T18 journey and the blocked and not-applicable entries recorded from orchestration/work/WP-18/cases.md.
 *
 * Every `### huid-report.` heading of cases.md appears once in `cases`. The T18 journey (stages 1 to 4) and the
 * voucher zoom (T05) are in huidReportJourney.mjs: they build their tags through the real screens. The entries below
 * are the cases recorded as not applicable, each with the Status text of cases.md as its reason.
 */

const as = huidUser;

const SOURCE = 'orchestration/work/WP-18/cases.md';

/** One entry per blocked or N/A case id of cases.md, reason copied from its Status line. */
const notRun = (id, group, reason) => ({
  id,
  group,
  kind: 'read-only',
  source: SOURCE,
  applicable: !reason.startsWith('N/A:') && !reason.startsWith('db layer:'),
  ...(reason.startsWith('blocked:') ? { blocked: reason } : {}),
  requiredEvidence: ['browser', 'expected'],
  reason,
});

const blockedCases = [
  notRun(
    'huid-report.entry.default-item-type-silver-when-not-gold',
    'T01',
    'blocked: the source of `DC_Main.MsMetalType` (the company setting that holds the metal type) is not traced in the study. It unblocks when the settings catalogue entry for the metal type is read.',
  ),
  notRun(
    'huid-report.total.weights-rounding-to-precision',
    'T03',
    "blocked: the stored precision of the weight columns is not known (study Open question 9). The web rounds each weight to `PRECISION.weight` (`web/apps/api/src/modules/reports/huid.ts:82`, `:177`). It unblocks when the weight column's scale is read from the schema, and the owner accepts the result.",
  ),
  notRun(
    'huid-report.drill.target-form-per-main-book',
    'T05',
    'blocked: the target forms of these branches were not traced (study Open question 4). The branch list was read but not each target. It unblocks when the target forms for the three branches are read.',
  ),
  notRun(
    'huid-report.drill.disabled-when-stock-merge-y',
    'T05',
    'blocked: the meaning of `CO_STK_MERGE` is not known (study Open question 3, `MS_OPNCOMP.cs:706 {{DC_Main.MsCoStockMerge = }}`). It unblocks when the owner states what the flag means and the settings catalogue has an entry for it.',
  ),
  notRun(
    'huid-report.invalid.blank-or-bad-date',
    'T06',
    'blocked: `DC_Main.SetDate` was not read (study Open question 6), so the desktop message and behaviour are unknown. It unblocks when `DC_Main.SetDate` is read in the desktop source.',
  ),
  notRun(
    'huid-report.rights.list-right',
    'T11',
    'blocked: study Open question 8. It unblocks when the owner decides whether List is checked.',
  ),
  notRun(
    'huid-report.config.stock-merge-y-company-scope',
    'T15',
    'blocked: `CO_STK_MERGE` has no entry in the settings catalogue (study Open question 3, `MS_OPNCOMP.cs:706 {{Rows[0][\"CO_STK_MERGE\"]}}`). It unblocks when the owner states the meaning of the flag.',
  ),
  notRun(
    'huid-report.config.data-type-filter',
    'T15',
    'blocked: what the codes A, B and C mean is not known (study Open question 3). It unblocks when the owner states what each data-type code is for.',
  ),
  notRun(
    'huid-report.output.headers-desktop-aliases',
    'T16',
    'blocked: the owner must choose the header text (study Open question 10; a desktop screenshot or the video knowledge base would settle it, neither was read here).',
  ),
  notRun(
    'huid-report.output.print-formula-totals',
    'T16',
    'db layer: the formula bodies are now read (TagHuIdRpt.xml: @TagQty = ITM_PCS, @TagGwt = ITM_GWT, @TagNwt = ITM_NWT; groups PR_CODE > GR_CODE, records by TAG_NO; sums per group, product and report). The printed sections and sums are built by printResultOf (web/apps/api/src/routes/huidReport.ts) and checked in web/apps/api/test/inventoryReportResiduals.test.ts; the browser harness cannot read text out of the rendered PDF, and Print through the screen is covered by huid-report.rights.print-refused-without-print-right and the PDF export cases.',
  ),
  notRun(
    'huid-report.labels.title-desktop-text',
    'T16',
    'blocked: the owner chooses the title (study Gap 28, Open question 11: the run-time caption comes from `DC_Main.MsUserRightForm`, whose setter was not found).',
  ),
  notRun(
    'huid-report.labels.hallmark-options',
    'T16',
    'blocked: the owner must confirm the wording (study Gap 27). The web wording is intended, per the study.',
  ),
  notRun(
    'huid-report.keys.tab-order-ties-blocked',
    'T17',
    'blocked: the tie order is not in the source (study Open question 12). It unblocks when the owner accepts a tie-break rule, or a desktop run records the order.',
  ),
  notRun(
    'huid-report.lifecycle.create-not-applicable',
    'T07',
    'N/A: a report writes no voucher, so there is nothing to create (addendum: "a report writes nothing").',
  ),
  notRun(
    'huid-report.lifecycle.reopen-not-applicable',
    'T08',
    'N/A: the report has no document to reopen; its only state is the screen filters, which the Cancel case covers.',
  ),
  notRun('huid-report.lifecycle.edit-not-applicable', 'T09', 'N/A: the report edits nothing.'),
  notRun(
    'huid-report.lifecycle.delete-cancel-not-applicable',
    'T10',
    'N/A: there is no voucher to delete, cancel or reverse.',
  ),
  notRun(
    'huid-report.retry.not-applicable',
    'T13',
    'N/A: the report is read-only. A duplicate request returns the same rows and writes nothing, so there is no financial effect to protect.',
  ),
  notRun(
    'huid-report.output.stkdate-column-hidden-for-named-registrations',
    'T16',
    'N/A: customer-specific behaviour; the study says do not port it.',
  ),
  // T14 is covered at the database layer (WP-18 design §5): the report is read-only, so the browser adds
  // nothing to the two write-set checks over the real route.
  notRun(
    'huid-report.write.view-leaves-bar-detl-unchanged',
    'T14',
    'db layer: covered by web/apps/api/test/huidReport.db.test.ts (WP-18 design §5); the browser module changes no data.',
  ),
  notRun(
    'huid-report.write.print-leaves-no-staging-rows',
    'T14',
    'db layer: covered by web/apps/api/test/huidReport.db.test.ts (WP-18 design §5); the browser module changes no data.',
  ),
];

export const huidReport = {
  feature: 'huid-report',
  title: 'Report → HuId Report (RP_HUID)',
  route: '/reports/huid',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/test/features/modules/huidReport.mjs',
    'web/apps/web/test/features/modules/huidReportFilters.mjs',
    'web/apps/web/test/features/modules/huidReportOutput.mjs',
    'web/apps/web/test/features/modules/huidReportJourney.mjs',
    'web/apps/web/test/features/modules/huidReportResiduals.mjs',
    'web/apps/web/test/features/modules/huidSeed.mjs',
  ],
  fixtureManifest: { base: 'huidSeed.mjs seedHuid per case; cleanHuid after each case' },
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    ...filterCases,
    ...outputCases,
    ...huidJourneyCases,
    ...huidResidualCases,
    ...blockedCases.filter(
      (c) => ![...huidResidualCases, ...huidJourneyCases].some((r) => r.id === c.id),
    ),
  ],
};
