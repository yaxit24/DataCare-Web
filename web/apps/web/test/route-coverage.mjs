#!/usr/bin/env node
/**
 * Route reachability — every page in the app is loaded once and must render without erroring.
 *
 * WHY THIS EXISTS ALONGSIDE THE SMOKE
 * ===================================
 * `browser.smoke.mjs` is a DEPTH test: it drives a handful of screens through real interactions and asserts
 * specific behaviour. Valuable, and it covers 39 routes. The application has **101**, so 62 pages were never
 * loaded by any test at all — a page that throws on render would ship, and the first person to find it would be
 * a jeweller at a counter.
 *
 * This is the BREADTH half: no interactions, no assertions about content, just "does every page render". Cheap to
 * run, cheap to keep true, and it fails on the whole class the smoke cannot see.
 *
 * WHAT THIS CATCHES
 * =================
 *   * a server-render failure — a bad server component, an import cycle, a missing export
 *   * an HTTP 5xx for the document
 *   * a navigation that never completes
 *
 * WHAT IT DOES **NOT** CATCH, AND WHY — MEASURED, NOT ASSUMED
 * =========================================================
 * A CLIENT-side render failure is invisible here. Injecting `throw new Error(...)` into a client page component
 * was tried: the page still returned HTTP 200, emitted no `pageerror`, and rendered the application's own
 * fallback — the text "Cannot reach server." — because this harness runs WITHOUT an API by design (`API_ORIGIN`
 * points at a dead port, the smoke's convention). That is exactly what a healthy page shows when the API is
 * absent, so the two states are indistinguishable and no assertion here can separate them.
 *
 * Claiming otherwise would make this a gate that cannot fail. Closing that gap needs the API and a database
 * running, so that "Cannot reach server." stops being the normal state — recorded as the next step rather than
 * papered over.
 *
 * A redirect to login or company selection is NOT a failure: most pages legitimately require a session and a
 * chosen company.
 *
 * The route list is DERIVED from the filesystem, so a new page is covered the moment it is added rather than when
 * someone remembers to list it.
 *
 * USAGE
 *   pnpm --filter @datacare/web build      # a production build is required, as for the smoke
 *   node apps/web/test/route-coverage.mjs
 */

import { existsSync, readdirSync, statSync } from 'node:fs';
import { spawn } from 'node:child_process';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { chromium } from 'playwright';

const HERE = dirname(fileURLToPath(import.meta.url));
const WEB_APP = resolve(HERE, '..');
const REPO_WEB = resolve(WEB_APP, '../..');
const port = Number(process.env.ROUTE_TEST_PORT || 4112);
const origin = `http://127.0.0.1:${port}`;

if (!existsSync(join(WEB_APP, '.next', 'BUILD_ID'))) {
  console.error(
    'ROUTE_COVERAGE_SKIP requires a production build; run pnpm --filter @datacare/web build',
  );
  process.exit(1);
}

/** Placeholder values for dynamic segments, so a parameterised route is still exercised. */
const SEGMENT_SAMPLES = { name: 'party', report: 'tag-stock' };

function collectRoutes(dir, urlParts = []) {
  const out = [];
  for (const entry of readdirSync(dir)) {
    const full = join(dir, entry);
    if (statSync(full).isDirectory()) {
      // (group) directories are organisational and contribute nothing to the URL.
      const isGroup = entry.startsWith('(') && entry.endsWith(')');
      const dynamic = entry.match(/^\[(?:\.\.\.)?([^\]]+)\]$/);
      if (dynamic) {
        const sample = SEGMENT_SAMPLES[dynamic[1]];
        if (!sample) {
          out.push({
            route: null,
            skipped: `/${[...urlParts, entry].join('/')}`,
            reason: `no sample for [${dynamic[1]}]`,
          });
          continue;
        }
        out.push(...collectRoutes(full, [...urlParts, sample]));
      } else {
        out.push(...collectRoutes(full, isGroup ? urlParts : [...urlParts, entry]));
      }
    } else if (entry === 'page.tsx' || entry === 'page.jsx') {
      out.push({ route: `/${urlParts.join('/')}` || '/' });
    }
  }
  return out;
}

const collected = collectRoutes(join(WEB_APP, 'app'));
const routes = [...new Set(collected.filter((r) => r.route).map((r) => r.route))].sort();
const unsampled = collected.filter((r) => !r.route);

/**
 * Registered-endpoint assertion for the strict Sale Return numeric-update surface (card X13,
 * steps 8-9). This breadth harness discovers PAGE routes from the filesystem, so a new API
 * endpoint reached only by a PUT-on-interaction is not otherwise observed here. Assert, source
 * side and DB-independently, that the endpoint is wired end to end: the web lib emits the
 * numeric path, the saved Return panel calls it, and the API registers the route through the
 * dedicated coordinator (never the generic editSaleReturn or the metadata-only path).
 */
const NUMERIC_UPDATE_ENDPOINT = 'incoming-numeric';
{
  const { readFileSync } = await import('node:fs');
  const lib = readFileSync(join(WEB_APP, 'lib', 'salesReturnForm.ts'), 'utf8');
  const panel = readFileSync(join(WEB_APP, 'components', 'SaleReturnSavedPanel.tsx'), 'utf8');
  const api = readFileSync(resolve(REPO_WEB, 'apps', 'api', 'src', 'routes', 'txn.ts'), 'utf8');
  const problems = [];
  if (!lib.includes(`numeric: '${NUMERIC_UPDATE_ENDPOINT}'`))
    problems.push('lib/salesReturnForm.ts does not emit the numeric endpoint path');
  if (!panel.includes("'numeric'") || !panel.includes('saveNumeric'))
    problems.push('SaleReturnSavedPanel.tsx does not call the numeric endpoint');
  if (!api.includes(`/sales-returns/:vchNo/${NUMERIC_UPDATE_ENDPOINT}`))
    problems.push('apps/api/src/routes/txn.ts does not register the numeric endpoint');
  if (!api.includes('updateSaleReturnNumeric'))
    problems.push('apps/api/src/routes/txn.ts does not route through updateSaleReturnNumeric');
  // Inspect the registered handler itself (from its app.put(...) to the next route registration),
  // not a fixed character window: the shared import list legitimately names both functions.
  const handlerStart = api.indexOf(`app.put('/sales-returns/:vchNo/${NUMERIC_UPDATE_ENDPOINT}'`);
  const handlerEnd = handlerStart < 0 ? -1 : api.indexOf('\n  app.', handlerStart + 1);
  const handler =
    handlerStart < 0 ? '' : api.slice(handlerStart, handlerEnd < 0 ? undefined : handlerEnd);
  if (!handler.includes('updateSaleReturnNumeric('))
    problems.push('the numeric endpoint handler does not call updateSaleReturnNumeric');
  if (/\beditSaleReturn\(|\bupdateSavedSaleReturnMetadata\(/.test(handler))
    problems.push('numeric endpoint must not fall through to the generic editSaleReturn');
  if (problems.length) {
    console.error('ROUTE_COVERAGE_FAILED numeric-update endpoint is not wired:');
    for (const p of problems) console.error(`  ${p}`);
    process.exit(1);
  }
  console.log(
    `numeric-update endpoint wired: web lib + saved panel + API route all reference /sales-returns/:vchNo/${NUMERIC_UPDATE_ENDPOINT}`,
  );
}

console.log(
  `routes discovered: ${routes.length}${unsampled.length ? ` (+${unsampled.length} unsampled)` : ''}`,
);

const server = spawn(
  'pnpm',
  ['--filter', '@datacare/web', 'exec', 'next', 'start', '-p', String(port)],
  {
    cwd: REPO_WEB,
    // No API, on purpose: this checks that pages RENDER, and the smoke uses the same convention.
    env: { ...process.env, API_ORIGIN: 'http://127.0.0.1:49999' },
    detached: process.platform !== 'win32',
    stdio: ['ignore', 'pipe', 'pipe'],
  },
);
const stopServer = () => {
  try {
    if (process.platform === 'win32') server.kill();
    else process.kill(-server.pid, 'SIGKILL');
  } catch {
    /* already gone */
  }
};
process.on('exit', stopServer);

async function waitForServer() {
  for (let i = 0; i < 90; i += 1) {
    try {
      const res = await fetch(`${origin}/login`, { redirect: 'manual' });
      if (res.status > 0) return;
    } catch {
      /* not up yet */
    }
    await new Promise((r) => setTimeout(r, 500));
  }
  throw new Error(`the web server did not start on ${origin}`);
}

const failures = [];
const deferred = [];
const ok = [];

/**
 * Stub the API in the browser, exactly as `browser.smoke.mjs` does.
 *
 * The first version of this harness ran with no API at all, and that made it unable to fail: every page rendered
 * the application's "Cannot reach server." fallback, which is indistinguishable from a page that threw. Stubbing
 * gives each page a SESSION and a chosen company, so pages render real content and a render failure looks
 * different from a healthy page.
 *
 * Stubs rather than a live API on purpose: this check asks whether screens render, and a stub is deterministic,
 * needs no database, and cannot fail for reasons unrelated to the page. Asserting against persisted rows is a
 * different job — the end-to-end workflow tests — and needs the real API.
 */
const ME = {
  user: 'ROUTE-COVERAGE',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  passwordResetRequired: false,
  rights: { view: true, edit: true, delete: true, print: true },
  allowedForms: null,
};

/**
 * Routes whose failure is THIS HARNESS'S fault, not the page's.
 *
 * The blanket fallback below answers every unknown endpoint with `[]`. These pages fetch endpoints that
 * really return an OBJECT and then read a field of it, so `[]` makes that field `undefined` and the page throws:
 *
 *   /settings                 reads `.some`            on the /settings payload
 *   /reports/tag-stock        reads `.count`           on the report payload
 *   /txn/reminders            reads `.overdueParties`  on the /reminders payload
 *   /utilities/data-repair    reads `.map`             on the operations payload
 *   /utilities/data-export    reads `.totals`          on the preview payload
 *   /utilities/estimate-reset reads `.totals`          on the preview payload
 *   /utilities/e-invoice      Object.keys(...)         on the gsp-config payload
 *
 * Blaming the pages would be wrong — the contract was broken by the stub, not by them. Hiding them would be worse.
 * They are excluded from the verdict and listed on every run, so the fix is obvious: give each endpoint a correctly
 * shaped stub, then delete its entry here. Each removal is a real increase in coverage.
 */
const NEEDS_SHAPED_STUB = new Map([]);

async function installApiStubs(page) {
  await page.route('**/api/**', async (route) => {
    const path = new URL(route.request().url()).pathname.replace(/^\/api/, '');
    const json = (status, body) =>
      route.fulfill({ status, contentType: 'application/json', body: JSON.stringify(body) });
    if (path === '/me') return json(200, ME);
    if (path === '/auth/login' || path === '/auth/logout' || path === '/context/select')
      return json(200, { ok: true });
    if (path === '/context/companies')
      return json(200, [{ CO_CODE: '01', CO_NAME: 'Route Coverage Co' }]);
    if (path === '/context/locations') return json(200, [{ LC_CODE: '01', LC_NAME: 'Main' }]);
    if (path === '/context/years') return json(200, [{ CO_YEAR: '2024-2025' }]);
    if (path === '/context/books') return json(200, []);
    /**
     * Endpoints whose real payload is an OBJECT, shaped from the page's own declared type.
     *
     * Each of these pages reads a field of the response, so the blanket `[]` below made that field `undefined` and
     * the page threw — routes failing for the harness's reasons rather than their own. The shapes are taken
     * from the types the pages declare, not guessed:
     *
     *   /settings                        `{ fields: Field[]; values: Record<string, unknown> }`
     *   /reports/tag-stock               `{ totals: { count, pcs, netWt, fine, mrp } }`
     *   /reminders                       `{ receivables, ordersDue, summary: { overdueParties, ... } }`
     *   /utilities/data-repair/runs      `{ runs: RunRow[] }`
     *   /utilities/data-repair/operations`{ operations: Operation[] }`
     *   /utilities/data-export/preview   `{ tables: TablePreview[]; totals: Totals }`
     *   /utilities/estimate-reset/preview`{ diffs: Diff[]; totals: Totals }`
     *   /einvoice/gsp-config             an object the page passes to Object.keys
     */
    if (path === '/settings') return json(200, { fields: [], values: {} });
    if (path.startsWith('/reports/tag-stock'))
      return json(200, { rows: [], totals: { count: 0, pcs: 0, netWt: 0, fine: 0, mrp: 0 } });
    if (path === '/reminders')
      return json(200, {
        receivables: [],
        ordersDue: [],
        summary: { overdueParties: 0, totalOutstanding: 0, ordersDue: 0, ordersOverdue: 0 },
      });
    if (path === '/utilities/data-repair/runs') return json(200, { runs: [] });
    if (path === '/utilities/data-repair/operations') return json(200, { operations: [] });
    if (path === '/utilities/data-export/preview')
      return json(200, {
        kind: 'data-export-preview',
        generatedAt: '2024-06-10T00:00:00.000Z',
        scope: { tenantId: 'route-coverage', coCode: '01', lcCode: '01', coYear: '2024-2025' },
        tables: [],
        totals: { tables: 0, rows: 0, pendingRows: 0, flaggedTables: 0 },
      });
    if (path === '/utilities/estimate-reset/preview')
      return json(200, {
        kind: 'estimate-reset-preview',
        generatedAt: '2024-06-10T00:00:00.000Z',
        asOfDate: '2024-06-10',
        scope: { tenantId: 'route-coverage', coCode: '01', lcCode: '01', coYear: '2024-2025' },
        companyType: 'R',
        desktopSource: [],
        diffs: [],
        samples: [],
        totals: { insert: 0, update: 0, delete: 0, selectedVouchers: 0, stockAdjustmentDetails: 0 },
        requiresConfirmation: 'RESET',
        postApplyMessage: 'No eligible reset rows were found.',
        registrationSpecificBranches: [],
      });
    if (path === '/einvoice/gsp-config') return json(200, { vars: {} });
    // The strict Sale Return numeric-update endpoint (card X13 steps 8-9). It is a PUT invoked
    // only on operator interaction, so page render never calls it; a shaped stub keeps the saved
    // Return screen render deterministic if a future default fetch reaches it, and documents that
    // the numeric surface routes through /sales-returns/:vchNo/incoming-numeric (NOT the generic
    // metadata/create paths). See NUMERIC_UPDATE_ENDPOINT below for the registered-path assertion.
    if (/^\/sales-returns\/[^/]+\/incoming-numeric$/.test(path))
      return json(200, {
        version: 'sale-return-numeric-update-coordinator-v1',
        profile: 'saved-one-pi-n-sr1-c27-t-zero-tax-ordinary-other-v1',
        committed: true,
        voucherNo: '00001',
        documentVersion: 'a'.repeat(64),
        changes: [],
        noOp: true,
        canUpdate: true,
      });
    if (path === '/integrations/status') return json(200, {});
    // A 404 for one missing image is meaningful to the page; the blanket [] below would look like data.
    if (path === '/stock/tag-image') return json(404, { error: 'tag-image-not-found' });
    // Everything else: an empty but VALID payload. A page that cannot cope with "no data yet" breaks on a
    // freshly provisioned company, which is worth catching.
    return json(200, []);
  });
}

await waitForServer();
const browser = await chromium.launch();
try {
  const page = await browser.newPage();
  await installApiStubs(page);
  for (const route of routes) {
    const problems = [];
    const onError = (e) => problems.push(`pageerror: ${e.message}`);
    const onReject = (e) => problems.push(`unhandled rejection: ${e}`);
    page.on('pageerror', onError);
    page.on('crash', onReject);
    let status = 0;
    try {
      const res = await page.goto(`${origin}${route}`, {
        waitUntil: 'domcontentloaded',
        timeout: 20_000,
      });
      status = res?.status() ?? 0;
      if (status >= 500) problems.push(`HTTP ${status}`);
      // Next.js renders its error overlay/boundary into the document; either is a render failure.
      const overlay = await page
        .locator('nextjs-portal, [data-nextjs-dialog], #__next_error__')
        .count();
      if (overlay > 0) problems.push('Next.js error overlay rendered');
      /**
       * The application's own failure surfaces. With the API stubbed none of these may appear, so their presence
       * is a render failure — precisely the signal the no-API version of this harness could not see.
       *
       * "Something went wrong" is the text of `app/error.tsx` and `app/global-error.tsx`, this app's React error
       * boundaries. Detecting only the generic Next.js strings missed it: a client component throwing during
       * render produced HTTP 200, no `pageerror`, and that boundary, so the mutation probe passed.
       */
      /**
       * Wait for hydration before judging the body.
       *
       * `domcontentloaded` fires on the SERVER-rendered HTML, which is healthy even when the client component
       * throws — the error boundary only replaces it once React hydrates. Reading the body at that moment made the
       * mutation probe pass: the check was looking at the page before the failure existed.
       */
      await page.waitForTimeout(600);
      const body =
        (await page
          .locator('body')
          .innerText()
          .catch(() => '')) ?? '';
      for (const marker of [
        'Something went wrong',
        'Cannot reach server',
        'Application error',
        'client-side exception',
      ]) {
        if (body.includes(marker)) problems.push(`rendered failure text: "${marker}"`);
      }
    } catch (e) {
      problems.push(`navigation failed: ${e.message}`);
    }
    page.off('pageerror', onError);
    page.off('crash', onReject);
    if (problems.length) {
      if (NEEDS_SHAPED_STUB.has(route)) deferred.push({ route, problems });
      else failures.push({ route, status, problems });
    } else ok.push(route);
  }
} finally {
  await browser.close();
  stopServer();
}

console.log(`rendered without error: ${ok.length} / ${routes.length}`);
for (const d of deferred) {
  console.log(`  NEEDS SHAPED STUB ${d.route} — ${NEEDS_SHAPED_STUB.get(d.route)}`);
}
for (const u of unsampled) console.log(`  UNSAMPLED ${u.skipped} — ${u.reason}`);
if (failures.length) {
  console.error(`\nROUTE_COVERAGE_FAILED ${failures.length} route(s) did not render:`);
  for (const f of failures) {
    console.error(`  ${f.route} (HTTP ${f.status})`);
    for (const p of f.problems) console.error(`      ${p}`);
  }
  process.exit(1);
}
console.log(
  `\nROUTE_COVERAGE_OK ${ok.length} route(s) rendered; ${deferred.length} deferred pending a shaped stub`,
);
console.log(
  '  Covers server render, CLIENT render (after hydration), HTTP status and navigation, with the API stubbed\n' +
    '  so a session exists and the error boundary is meaningful. It does NOT assert content or persistence.',
);
