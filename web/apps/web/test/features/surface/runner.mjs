import { mkdirSync, writeFileSync } from 'node:fs';
import { resolve } from 'node:path';
import { authenticatedContext } from '../harness.mjs';
import { USERS } from '../fixtures/catalogue.mjs';
import { DESTRUCTIVE, crawlRoute, instrument, menuRoutes, unlinkedPages } from './crawl.mjs';
import { buildMap, gate } from './map.mjs';

// Pages whose buttons change company-wide state (years, users, books, renumbering): crawled last, one at a time.
const LAST =
  /^\/(utilities|admin|backup|settings|company)\b|^\/masters\/(years|year-create|companies|books)$|^\/password-change$/;

/**
 * Crawl every route on an already running, already seeded stack. `label` names the run ('empty' company or
 * 'with-data' after the feature suites), `out` is its results directory.
 */
export async function runSurface(
  stack,
  { out, sweep, workers = 4, only, writeDoc, label = 'empty' },
) {
  mkdirSync(out, { recursive: true });
  const credentials = (slot) => ({
    user: USERS.admin.user,
    slot,
    password: process.env.FEATURE_E2E_PASSWORD,
  });
  const menu = menuRoutes();
  const routes = [...menu, ...unlinkedPages(menu)].filter((r) => !only || only.has(r.route));
  const ordinary = routes.filter((r) => !LAST.test(r.route));
  const last = routes.filter((r) => LAST.test(r.route));
  console.log(
    `surface (${label}): ${routes.length} routes (${ordinary.length} parallel on ${workers} workers, ${last.length} last); sweep=${sweep}`,
  );

  // One login per slot, sequentially: concurrent Open Company for one user conflicts (G172).
  for (const slot of [
    ...Array.from({ length: workers }, (_, i) => `crawler-${i + 1}`),
    'crawler-last',
    'crawler-destructive',
  ])
    await (await authenticatedContext(stack, credentials(slot))).close();

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
  const lanes = Array.from({ length: workers }, () => []);
  ordinary.forEach((entry, i) => lanes[i % workers].push(entry));
  await Promise.all(lanes.map((lane, i) => runQueue(lane, `crawler-${i + 1}`, 'safe')));
  await runQueue(last, 'crawler-last', 'safe');
  const destructivePages = routes.filter((entry) =>
    records.some(
      (r) => r.route === entry.route && r.structure?.buttons?.some((b) => DESTRUCTIVE.test(b.name)),
    ),
  );
  await runQueue(destructivePages, 'crawler-destructive', 'destructive');

  const meta = {
    label,
    candidate: stack.candidate,
    dirtyPatch: stack.dirtyPatch,
    sweep,
    workers,
    routes: routes.length,
    durationSeconds: Math.round((Date.now() - started) / 1000),
    finishedAt: new Date().toISOString(),
  };
  writeFileSync(resolve(out, 'records.json'), `${JSON.stringify({ meta, records }, null, 2)}\n`);
  const map = buildMap({ meta, records, out, writeDoc });
  const result = gate(map, { sweep });
  writeFileSync(resolve(out, 'gate.json'), `${JSON.stringify(result, null, 2)}\n`);
  console.log(
    `surface (${label}): verdicts ${JSON.stringify(map.summary.verdicts)}, findings ${JSON.stringify(map.summary.findingsBySeverity)}`,
  );
  return { map, result };
}
