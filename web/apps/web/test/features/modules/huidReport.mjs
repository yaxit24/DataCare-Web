import { USERS } from '../fixtures/catalogue.mjs';
import { filterCases } from './huidReportFilters.mjs';
import { outputCases } from './huidReportOutput.mjs';

/**
 * Feature: Report → HuId Report (RP_HUID.cs, web /reports/huid). This module combines the case arrays of
 * huidReportFilters.mjs (T01, T02, T03, T06, T04, T05, T11, T12) and huidReportOutput.mjs (T15, T16, T17) with
 * the T18 journey and the blocked and not-applicable entries recorded from orchestration/work/WP-18/cases.md.
 *
 * Every `### huid-report.` heading of cases.md appears once in `cases`. Blocked entries carry the Status text of
 * the case as their reason. Journey stages 1 to 3 are executable in the case list; they are recorded here as
 * `blocked` because the web screens cannot yet carry out their steps (see the MISSING notes below), so they are
 * not run and no shared setup is created.
 */

const as = (user) => ({
  user,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

const SOURCE = 'orchestration/work/WP-18/cases.md';

/** T18 journey stage that cannot run through the web screens today. Each stage depends on the same missing step. */
const JOURNEY_MISSING_HUID =
  'blocked: MISSING: the Purchase screen has no HUID (hallmark slot) input on its item lines. The line columns in ' +
  'web/apps/web/test/features/modules/purchaseInvoice.mjs:136-138 are item, tag, pcs, gross, net, touch, rate and making only. ' +
  'JT-3 (hallmarked purchase with HUID HUJ003) cannot be created through the screen the journey names.';
const JOURNEY_MISSING_SALE_TAG =
  'blocked: MISSING: the Sales screen sells by item and has no tag selection and no HUID entry (web/apps/web/app/(app)/txn/sales/page.tsx:77 ' +
  'says the operator cannot enter HUID). The sale of JT-1 as a specific tag (stage 2) therefore cannot be made through the screen, ' +
  'and the Sales Return of that tag (stage 3) depends on it.';

const journeyBlocked = (id, reason) => ({
  id,
  group: 'T18',
  kind: 'read-only',
  source: `${SOURCE} (T18 journey)`,
  applicable: true,
  requiredEvidence: ['browser', 'expected'],
  blocked: reason,
});

const journeyCases = [
  journeyBlocked(
    'huid-report.journey.stage-1-tags-and-purchase-in-view',
    `${JOURNEY_MISSING_HUID} Tag Opening (JT-1, JT-2, JT-4) is driveable through tagOpening.mjs. The hallmark slot of JT-3 is the blocker.`,
  ),
  journeyBlocked('huid-report.journey.stage-2-sale-out-and-stock', JOURNEY_MISSING_SALE_TAG),
  journeyBlocked(
    'huid-report.journey.stage-3-return-views-agree',
    `${JOURNEY_MISSING_SALE_TAG} The return of a tag through the Sales Return screen (salesReturn.mjs fillLine column 2 is the tag) is driveable only once stage 2 has a sale.`,
  ),
];

/** One entry per blocked or N/A case id of cases.md, reason copied from its Status line. */
const notRun = (id, group, reason) => ({
  id,
  group,
  kind: 'read-only',
  source: SOURCE,
  applicable: false,
  requiredEvidence: ['browser', 'expected'],
  reason,
});

const blockedCases = [
  notRun('huid-report.entry.default-item-type-silver-when-not-gold', 'T01', "blocked: the source of `DC_Main.MsMetalType` (the company setting that holds the metal type) is not traced in the study. It unblocks when the settings catalogue entry for the metal type is read."),
  notRun('huid-report.hallmark.whitespace-only-first-slot', 'T02', "blocked: the desktop runs on SQL Server (`unified/src/csharp/DataCareNext/DC_Main.cs:37 {{public static SqlConnection Mc = new SqlConnection();}}`). In SQL Server, `'   ' = ''` is true, so `RP_HUID.cs:1768 {{DC_Main.RsQry += \"AND C.HM_ID = '' \";}}` would put TG-004 under \"Without\". The study's Gap 11 says the desktop counts it as present; that is not verified and may be wrong. The supervisor's rule and the desktop engine disagree. Unblocks when the owner confirms the rule (and, if needed, a SQL Server check of `'   ' = ''` on the desktop schema). The web currently treats TG-004 as absent (`web/apps/api/src/modules/reports/huid.ts:129-132`)."),
  notRun('huid-report.total.weights-rounding-to-precision', 'T03', 'blocked: the stored precision of the weight columns is not known (study Open question 9). The web rounds each weight to `PRECISION.weight` (`web/apps/api/src/modules/reports/huid.ts:82`, `:177`). It unblocks when the weight column\'s scale is read from the schema, and the owner accepts the result.'),
  notRun('huid-report.drill.target-form-per-main-book', 'T05', 'blocked: the target forms of these branches were not traced (study Open question 4). The branch list was read but not each target. It unblocks when the target forms for the three branches are read.'),
  notRun('huid-report.drill.disabled-when-stock-merge-y', 'T05', 'blocked: the meaning of `CO_STK_MERGE` is not known (study Open question 3, `MS_OPNCOMP.cs:706 {{DC_Main.MsCoStockMerge = }}`). It unblocks when the owner states what the flag means and the settings catalogue has an entry for it.'),
  notRun('huid-report.invalid.blank-or-bad-date', 'T06', 'blocked: `DC_Main.SetDate` was not read (study Open question 6), so the desktop message and behaviour are unknown. It unblocks when `DC_Main.SetDate` is read in the desktop source.'),
  notRun('huid-report.rights.list-right', 'T11', 'blocked: study Open question 8. It unblocks when the owner decides whether List is checked.'),
  notRun('huid-report.config.stock-merge-y-company-scope', 'T15', 'blocked: `CO_STK_MERGE` has no entry in the settings catalogue (study Open question 3, `MS_OPNCOMP.cs:706 {{Rows[0][\"CO_STK_MERGE\"]}}`). It unblocks when the owner states the meaning of the flag.'),
  notRun('huid-report.config.data-type-filter', 'T15', 'blocked: what the codes A, B and C mean is not known (study Open question 3). It unblocks when the owner states what each data-type code is for.'),
  notRun('huid-report.output.headers-desktop-aliases', 'T16', 'blocked: the owner must choose the header text (study Open question 10; a desktop screenshot or the video knowledge base would settle it, neither was read here).'),
  notRun('huid-report.output.print-formula-totals', 'T16', 'blocked: the Crystal formula bodies `@TagQty`, `@TagGwt`, `@TagNwt`, `@TagPcs`, `@NewBal`, `@VchSrno` were not extracted (study Open question 5, marked MISSING). It unblocks when the formula bodies are extracted from `extraction_output/rpt_xml/TagHuIdRpt.xml`.'),
  notRun('huid-report.labels.title-desktop-text', 'T16', 'blocked: the owner chooses the title (study Gap 28, Open question 11: the run-time caption comes from `DC_Main.MsUserRightForm`, whose setter was not found).'),
  notRun('huid-report.labels.hallmark-options', 'T16', 'blocked: the owner must confirm the wording (study Gap 27). The web wording is intended, per the study.'),
  notRun('huid-report.keys.tab-order-ties-blocked', 'T17', 'blocked: the tie order is not in the source (study Open question 12). It unblocks when the owner accepts a tie-break rule, or a desktop run records the order.'),
  notRun('huid-report.journey.stage-4-cancel-views-agree', 'T18', 'blocked: the MAIN_STOCK and BAR_DETL rows that Tag Cancel writes are not in this study. The Stock result for JT-2 depends on them. It unblocks when the Tag Cancel desktop form is read and its rows traced (the form is outside this menu).'),
  notRun('huid-report.lifecycle.create-not-applicable', 'T07', 'N/A: a report writes no voucher, so there is nothing to create (addendum: "a report writes nothing").'),
  notRun('huid-report.lifecycle.reopen-not-applicable', 'T08', 'N/A: the report has no document to reopen; its only state is the screen filters, which the Cancel case covers.'),
  notRun('huid-report.lifecycle.edit-not-applicable', 'T09', 'N/A: the report edits nothing.'),
  notRun('huid-report.lifecycle.delete-cancel-not-applicable', 'T10', 'N/A: there is no voucher to delete, cancel or reverse.'),
  notRun('huid-report.retry.not-applicable', 'T13', 'N/A: the report is read-only. A duplicate request returns the same rows and writes nothing, so there is no financial effect to protect.'),
  notRun('huid-report.output.stkdate-column-hidden-for-named-registrations', 'T16', 'N/A: customer-specific behaviour; the study says do not port it.'),
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
    'web/apps/web/test/features/modules/huidSeed.mjs',
  ],
  fixtureManifest: { base: 'huidSeed.mjs seedHuid per case; cleanHuid after each case' },
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [...filterCases, ...outputCases, ...journeyCases, ...blockedCases],
};
