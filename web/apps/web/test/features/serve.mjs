/**
 * Interactive feature stack for checking screens by hand in a real browser (for example the local Chrome).
 *
 * It starts the same isolated stack as run-features.mjs, provisions the shared sample catalogue, optionally runs
 * feature modules first so the company holds real vouchers, then stays up until Ctrl+C (or SIGTERM), when it
 * wipes the test tenants and stops. Nothing here is part of the CI gate.
 *
 *   PARITY_TEST_PROJECT=datacare-serve PARITY_TEST_PORT=55471 PARITY_API_PORT=4420 PARITY_WEB_PORT=4421 \
 *   FEATURE_E2E_SERVE_PASSWORD='<choose one>' FEATURE_E2E_MODULES=sales-return \
 *   node scripts/parity-test-env.mjs -- node apps/web/test/features/serve.mjs
 *
 * Give it its own PARITY_TEST_PROJECT: parity-test-env names the database after the checkout by default, so any
 * other run from the same checkout that ends would tear this database down. The API port must be the one the web
 * was built against (API_ORIGIN). Without FEATURE_E2E_SERVE_PASSWORD a random password is printed. Without
 * FEATURE_E2E_MODULES no module runs.
 */
import { randomBytes } from 'node:crypto';
import { resolve } from 'node:path';
import {
  SECOND_TENANT,
  TENANT,
  runModule,
  startStack,
  stopStack,
  webRoot,
  wipeTenants,
} from './harness.mjs';
import { USERS, seedCatalogue } from './fixtures/catalogue.mjs';
import { purchaseInvoice } from './modules/purchaseInvoice.mjs';
import { purchaseReturn } from './modules/purchaseReturn.mjs';
import { salesInvoice } from './modules/salesInvoice.mjs';
import { salesReturn } from './modules/salesReturn.mjs';
import { settingsEffects } from './modules/settingsEffects.mjs';
import { usersRights } from './modules/usersRights.mjs';

const ALL = [
  salesInvoice,
  purchaseInvoice,
  settingsEffects,
  usersRights,
  salesReturn,
  purchaseReturn,
];
const wanted = new Set(
  (process.env.FEATURE_E2E_MODULES ?? '')
    .split(',')
    .map((name) => name.trim())
    .filter(Boolean),
);
const modules = ALL.filter((module) => wanted.has(module.feature));
const password =
  process.env.FEATURE_E2E_SERVE_PASSWORD || `E2e-${randomBytes(12).toString('hex')}!`;
process.env.FEATURE_E2E_PASSWORD = password;

const stack = await startStack({ artifacts: resolve(webRoot, 'test-results/feature-e2e-serve') });
let stopping = false;
const stop = async (code) => {
  if (stopping) return;
  stopping = true;
  await wipeTenants(stack.owner, [TENANT, SECOND_TENANT]).catch(() => {});
  await stopStack(stack);
  process.exit(code);
};
process.on('SIGINT', () => void stop(0));
process.on('SIGTERM', () => void stop(0));

try {
  await wipeTenants(stack.owner, [TENANT, SECOND_TENANT]);
  await seedCatalogue(stack, { password });
  for (const module of modules) {
    const { run } = await runModule(stack, module, {});
    const counts = run.cases.reduce(
      (acc, c) => ({ ...acc, [c.status]: (acc[c.status] ?? 0) + 1 }),
      {},
    );
    console.log(`data from ${module.feature}: ${JSON.stringify(counts)}`);
  }
} catch (error) {
  console.error(error);
  await stop(1);
}

console.log(
  [
    '',
    `FEATURE_E2E_SERVING ${stack.target.webOrigin}/login`,
    `  users: ${USERS.admin.user} (admin), ${USERS.clerk.user} (clerk); password: ${password}`,
    '  Ctrl+C wipes the test tenants and stops the stack.',
  ].join('\n'),
);
await new Promise(() => {});
