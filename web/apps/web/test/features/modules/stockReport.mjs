import { USERS } from '../fixtures/catalogue.mjs';
import * as data from './stockReportData.mjs';
import { dataCases } from './stockReportCases.mjs';
import { moreCases } from './stockReportMoreCases.mjs';
import { notRunCases } from './stockReportNotRun.mjs';

/**
 * Feature: Report -> Stock Report (desktop RP_STOCK, web /reports/stock-report).
 *
 * RP_STOCK is a READ-ONLY report (MDI_FORM.cs:8881-8890). Every figure is the sum of signed MAIN_STOCK movements
 * (RP_STOCK.cs:4284: Opening = VCH_DATE < FROM, Closing = every signed movement to TO), so the cases read the
 * movements the real screens write. stockReportData.mjs saves the movement table of
 * orchestration/work/WP-16/cases.md section 1 through the real Item Opening, Tag Opening, Purchase, Sales, Sales
 * Return, Purchase Return, Stock Adjust, Tag Cancel and Approval Issue screens, in a location of its own so the
 * worked totals hold exactly; the counter transfer (Tag Transfer is not a Lite menu) is the one fixture insert.
 * The API layer (every dimension, filter, drill-down, rights, tenant and year scope) is proven by
 * apps/api/test/stockReport.db.test.ts, which computes its figures from the same rows.
 *
 * The data set is built by the first case that needs it and removed after the last case that runs.
 */

const cases = [...dataCases, ...moreCases];
// Every case signs in at the stock-report location, which must exist before the first sign-in.
for (const c of cases) {
  const body = c.run;
  c.run = async (ctx) => {
    await data.ensureProvisioned(ctx);
    return body(ctx);
  };
}

// The location, its vouchers and masters are removed after the last case that runs (all of them, or the
// FEATURE_E2E_CASES subset), and the tenant is proven to be back to the row counts it had.
const selected = process.env.FEATURE_E2E_CASES
  ? new Set(process.env.FEATURE_E2E_CASES.split(',').map((id) => id.trim()))
  : null;
const last = cases.filter((c) => !c.blocked && (!selected || selected.has(c.id))).at(-1);
if (last) {
  const body = last.run;
  last.run = async (ctx) => {
    try {
      return await body(ctx);
    } finally {
      const { leaked } = await data.teardown(ctx);
      if (leaked?.length)
        throw new Error(`the stock-report data set left rows behind: ${leaked.join('; ')}`);
    }
  };
}

export const stockReport = {
  feature: 'stock-report',
  title: 'Reports -> Stock Report (RP_STOCK)',
  defaultUser: data.at(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/reports/stock-report/page.tsx',
    'web/apps/web/app/(app)/reports/stock-report/useStockReport.ts',
    'web/apps/web/app/(app)/reports/stock-report/StockGrids.tsx',
    'web/apps/web/app/(app)/reports/stock-report/types.ts',
    'web/apps/api/src/modules/reports/stockReport/index.ts',
    'web/apps/api/src/modules/reports/stockReport/parse.ts',
    'web/apps/api/src/modules/reports/stockReport/sql.ts',
    'web/apps/api/src/routes/stockReport.ts',
    'web/apps/web/test/features/modules/stockReport.mjs',
    'web/apps/web/test/features/modules/stockReportData.mjs',
    'web/apps/web/test/features/modules/stockReportScreen.mjs',
    'web/apps/web/test/features/modules/stockReportCases.mjs',
    'web/apps/web/test/features/modules/stockReportMoreCases.mjs',
    'web/apps/web/test/features/modules/stockReportFlows.mjs',
    'web/apps/web/test/features/modules/stockReportEntryCases.mjs',
    'web/apps/web/test/features/modules/stockReportZoomCases.mjs',
    'web/apps/web/app/(app)/reports/stock-report/ItemPicker.tsx',
    'web/apps/web/app/(app)/reports/stock-report/CodeBox.tsx',
    'web/apps/web/test/features/modules/stockReportNotRun.mjs',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
  ],
  fixtureManifest: {
    base: `seedCompany provisions location ${data.LC}; masters (items ZRNG, ZCHN, ZBWL, groups, products, counters, parties) by insert; vouchers M1..M19 through the real screens, counter transfer by insert`,
  },
  settingsManifest: {
    companySettings:
      'catalogue defaults (STK_RPT_TYPE blank = net); no setting is changed unless a case says so',
  },
  cases: [...cases, ...notRunCases(cases.map((c) => c.id))],
};
