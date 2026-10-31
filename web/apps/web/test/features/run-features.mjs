import assert from 'node:assert/strict';
import { randomBytes } from 'node:crypto';
import { readFileSync, writeFileSync } from 'node:fs';
import { resolve } from 'node:path';
import {
  SECOND_TENANT,
  TENANT,
  compareBaseline,
  resetSavedLogins,
  runModule,
  startStack,
  stopStack,
  validateBundle,
  webRoot,
  wipeTenants,
} from './harness.mjs';
import { seedCatalogue } from './fixtures/catalogue.mjs';
import { purchaseInvoice } from './modules/purchaseInvoice.mjs';
import { purchaseReturn } from './modules/purchaseReturn.mjs';
import { salesInvoice } from './modules/salesInvoice.mjs';
import { salesReturn } from './modules/salesReturn.mjs';
import { settingsEffects } from './modules/settingsEffects.mjs';
import { usersRights } from './modules/usersRights.mjs';
import { companyOpen } from './modules/companyOpen.mjs';
import { cashBank } from './modules/cashBank.mjs';
import { contraEntry } from './modules/contraEntry.mjs';
import { partyOpening } from './modules/partyOpening.mjs';
import { runSurface } from './surface/runner.mjs';

/**
 * Feature E2E runner (docs/handbook/web/testing.md §4a).
 *
 *   node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs
 *
 * Env:
 *   FEATURE_E2E_MODULES   comma list of module ids (default: all)
 *   FEATURE_E2E_CASES     comma list of case ids to run (others are recorded "untested")
 *   PARITY_API_PORT / PARITY_WEB_PORT / PARITY_TEST_PORT as for the other real-stack suites
 *
 * Gate: every applicable case must pass, except cases listed in baseline.json (known defects, each with a gap
 * id). A new failure fails the run; a baseline case that now passes also fails the run until it is removed.
 */
const MODULES = [
  salesInvoice,
  purchaseInvoice,
  settingsEffects,
  usersRights,
  salesReturn,
  companyOpen,
  purchaseReturn,
  cashBank,
  contraEntry,
  partyOpening,
];

const artifacts = resolve(webRoot, 'test-results/feature-e2e');
const baselinePath = resolve(webRoot, 'apps/web/test/features/baseline.json');
const baseline = JSON.parse(readFileSync(baselinePath, 'utf8'));
const selected = new Set(
  (process.env.FEATURE_E2E_MODULES ?? '')
    .split(',')
    .map((s) => s.trim())
    .filter(Boolean),
);
const onlyCases = process.env.FEATURE_E2E_CASES
  ? new Set(process.env.FEATURE_E2E_CASES.split(',').map((s) => s.trim()))
  : undefined;
const modules = MODULES.filter((m) => selected.size === 0 || selected.has(m.feature));
assert(modules.length, 'no feature module selected');

const password = `E2e-${randomBytes(12).toString('hex')}!`;
process.env.FEATURE_E2E_PASSWORD = password;

let stack;
// A rejection outside a case (for example a page event handler that throws) would end the process before the
// finally block below runs, leaving the Next server and the database container behind. Stop them first.
process.on('unhandledRejection', async (reason) => {
  console.error('\nunhandled rejection:', reason);
  await stopStack(stack).catch(() => {});
  process.exit(1);
});
const report = { startedAt: new Date().toISOString(), modules: [] };
let gateProblems = [];
try {
  stack = await startStack({ artifacts });
  // One company for the whole run: every module adds its vouchers to it, as a shop's day would, so later modules
  // and the closing surface crawl see real business data rather than an empty company.
  await wipeTenants(stack.owner, [TENANT, SECOND_TENANT]);
  await seedCatalogue(stack, { password });
  resetSavedLogins();
  for (const module of modules) {
    console.log(`\n=== ${module.feature}: ${module.title} (${module.cases.length} cases) ===`);
    const { run, moduleDir } = await runModule(stack, module, { onlyCases });
    const { summary } = validateBundle(moduleDir);
    const gate = compareBaseline(module.feature, run, baseline);
    report.modules.push({ feature: module.feature, summary, gate });
    console.log(
      `  -> applicable ${summary.applicableCases}, passed ${summary.counts?.passed}, failed ${summary.counts?.failed}, blocked ${summary.counts?.blocked}, untested ${summary.counts?.untested}; browser pass ${summary.browserBusinessPassPct}%`,
    );
    if (summary.errors?.length)
      gateProblems.push(...summary.errors.map((e) => `${module.feature}: bundle: ${e}`));
    gateProblems.push(...gate.newFailures.map((id) => `${module.feature}: NEW failure ${id}`));
    gateProblems.push(
      ...gate.fixed.map(
        (id) => `${module.feature}: ${id} now passes — remove it from baseline.json`,
      ),
    );
    gateProblems.push(
      ...gate.missing.map((id) => `${module.feature}: baseline names unknown case ${id}`),
    );
  }
  // FEATURE_E2E_THEN_SURFACE=1: crawl every page on the data the modules just created (report-only).
  if (process.env.FEATURE_E2E_THEN_SURFACE === '1') {
    const { map } = await runSurface(stack, {
      out: resolve(webRoot, 'test-results/ui-surface-with-data'),
      sweep: process.env.SURFACE_SWEEP === '1',
      workers: Math.max(1, Number(process.env.SURFACE_WORKERS || 4)),
      label: 'with-data',
    });
    report.surfaceWithData = map.summary;
  }
} finally {
  report.finishedAt = new Date().toISOString();
  report.problems = gateProblems;
  writeFileSync(resolve(artifacts, 'report.json'), `${JSON.stringify(report, null, 2)}\n`);
  if (stack) await wipeTenants(stack.owner, [TENANT, SECOND_TENANT]).catch(() => {});
  await stopStack(stack);
}
if (gateProblems.length) {
  console.error(`\nFEATURE_E2E_FAILED:\n- ${gateProblems.join('\n- ')}`);
  process.exit(1);
}
console.log('\nFEATURE_E2E_PASSED');
