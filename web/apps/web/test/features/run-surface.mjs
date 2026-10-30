import { randomBytes } from 'node:crypto';
import { mkdirSync } from 'node:fs';
import { resolve } from 'node:path';
import {
  SECOND_TENANT,
  TENANT,
  resetSavedLogins,
  startStack,
  stopStack,
  webRoot,
  wipeTenants,
} from './harness.mjs';
import { seedCatalogue } from './fixtures/catalogue.mjs';
import { runSurface } from './surface/runner.mjs';

/**
 * UI surface crawl (docs/handbook/web/testing.md §4b).
 *
 *   node scripts/parity-test-env.mjs -- node apps/web/test/features/run-surface.mjs
 *
 * Env:
 *   SURFACE_SWEEP=1      also press every button on every page (slow; the committed map comes from this mode)
 *   SURFACE_ROUTES=a,b   only these routes
 *   SURFACE_WORKERS=n    parallel browser contexts (default 4)
 *   SURFACE_WRITE_DOC=1  rewrite docs/handbook/web/ui-surface-map.md from this run
 */
const sweep = process.env.SURFACE_SWEEP === '1';
const workers = Math.max(1, Number(process.env.SURFACE_WORKERS || 4));
const only = process.env.SURFACE_ROUTES
  ? new Set(process.env.SURFACE_ROUTES.split(',').map((s) => s.trim()))
  : null;
const out = resolve(webRoot, 'test-results/ui-surface');
mkdirSync(out, { recursive: true });

const password = `Srf-${randomBytes(12).toString('hex')}!`;
process.env.FEATURE_E2E_PASSWORD = password;

let stack;
let exitCode = 0;
try {
  stack = await startStack({ artifacts: out });
  await wipeTenants(stack.owner, [TENANT, SECOND_TENANT]);
  await seedCatalogue(stack, { password });
  resetSavedLogins();
  const { result } = await runSurface(stack, {
    out,
    sweep,
    workers,
    only,
    writeDoc: process.env.SURFACE_WRITE_DOC === '1',
  });
  if (result.problems.length) {
    console.error(`SURFACE_FAILED:\n- ${result.problems.join('\n- ')}`);
    exitCode = 1;
  } else console.log('SURFACE_PASSED');
} finally {
  if (stack) await wipeTenants(stack.owner, [TENANT, SECOND_TENANT]).catch(() => {});
  await stopStack(stack);
}
process.exit(exitCode);
