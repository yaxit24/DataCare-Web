import { randomBytes } from 'node:crypto';
import { mkdirSync, writeFileSync } from 'node:fs';
import { resolve } from 'node:path';
import {
  SECOND_TENANT,
  TENANT,
  authenticatedContext,
  resetSavedLogins,
  startStack,
  stopStack,
  webRoot,
  wipeTenants,
} from './harness.mjs';
import { USERS, seedCatalogue } from './fixtures/catalogue.mjs';
import {
  DESTRUCTIVE,
  crawlRoute,
  instrument,
  menuRoutes,
  unlinkedPages,
} from './surface/crawl.mjs';
import { buildMap, gate } from './surface/map.mjs';

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

// Pages whose buttons change company-wide state (years, users, books, renumbering): crawled last, one at a time.
const LAST =
  /^\/(utilities|admin|backup|settings|company)\b|^\/masters\/(years|year-create|companies|books)$|^\/password-change$/;

const password = `Srf-${randomBytes(12).toString('hex')}!`;
process.env.FEATURE_E2E_PASSWORD = password;
const credentials = (slot) => ({ user: USERS.admin.user, slot, password });

let stack;
let exitCode = 0;
try {
  stack = await startStack({ artifacts: out });
  await wipeTenants(stack.owner, [TENANT, SECOND_TENANT]);
  await seedCatalogue(stack, { password });
  resetSavedLogins();

  const menu = menuRoutes();
  const routes = [...menu, ...unlinkedPages(menu)].filter((r) => !only || only.has(r.route));
  const ordinary = routes.filter((r) => !LAST.test(r.route));
  const last = routes.filter((r) => LAST.test(r.route));
  console.log(
    `surface: ${routes.length} routes (${ordinary.length} parallel on ${workers} workers, ${last.length} last); sweep=${sweep}`,
  );

  const records = [];
  const started = Date.now();
  const runQueue = async (queue, slot, phase) => {
    const context = await authenticatedContext(stack, credentials(slot));
    let page = await context.newPage();
    let recorder = instrument(page);
    for (const entry of queue) {
      if (page.isClosed()) {
        page = await context.newPage();
        recorder = instrument(page);
      }
      const record = await crawlRoute(page, recorder, entry, {
        phase,
        sweep: sweep || phase === 'destructive',
      });
      records.push(record);
      const bad = record.findings.filter((f) => f.severity !== 'low').length;
      console.log(
        `  [${slot}] ${phase} ${entry.route} — ${record.structure?.buttons?.length ?? 0} buttons, ${bad} finding(s)`,
      );
    }
    await context.close();
  };

  // Log every worker in one at a time first. Opening the company for the same user from several sessions at the
  // same instant answers 409 context-transaction-conflict for all but one (recorded as G172); the crawl is not
  // the place to race that, so each slot's saved login exists before the workers start.
  for (const slot of [
    ...Array.from({ length: workers }, (_, i) => `crawler-${i + 1}`),
    'crawler-last',
    'crawler-destructive',
  ])
    await (await authenticatedContext(stack, credentials(slot))).close();

  // Safe pass: everything except destructive buttons.
  const lanes = Array.from({ length: workers }, () => []);
  ordinary.forEach((entry, i) => lanes[i % workers].push(entry));
  await Promise.all(lanes.map((lane, i) => runQueue(lane, `crawler-${i + 1}`, 'safe')));
  await runQueue(last, 'crawler-last', 'safe');

  // Destructive pass: only pages that showed a destructive button, one at a time, after everything else.
  const destructivePages = routes.filter((entry) =>
    records.some(
      (r) => r.route === entry.route && r.structure?.buttons?.some((b) => DESTRUCTIVE.test(b.name)),
    ),
  );
  await runQueue(destructivePages, 'crawler-destructive', 'destructive');

  const meta = {
    candidate: stack.candidate,
    dirtyPatch: stack.dirtyPatch,
    sweep,
    workers,
    routes: routes.length,
    durationSeconds: Math.round((Date.now() - started) / 1000),
    finishedAt: new Date().toISOString(),
  };
  writeFileSync(resolve(out, 'records.json'), `${JSON.stringify({ meta, records }, null, 2)}\n`);
  const map = buildMap({ meta, records, out, writeDoc: process.env.SURFACE_WRITE_DOC === '1' });
  const result = gate(map, { sweep });
  writeFileSync(resolve(out, 'gate.json'), `${JSON.stringify(result, null, 2)}\n`);
  console.log(
    `\nsurface: ${map.summary.routes} routes, verdicts ${JSON.stringify(map.summary.verdicts)}`,
  );
  console.log(`findings: ${JSON.stringify(map.summary.findingsBySeverity)}`);
  if (result.problems.length) {
    console.error(`SURFACE_FAILED:\n- ${result.problems.join('\n- ')}`);
    exitCode = 1;
  } else console.log('SURFACE_PASSED');
} finally {
  if (stack) await wipeTenants(stack.owner, [TENANT, SECOND_TENANT]).catch(() => {});
  await stopStack(stack);
}
process.exit(exitCode);
