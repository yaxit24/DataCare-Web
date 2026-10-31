import assert from 'node:assert/strict';
import { createHash, randomBytes } from 'node:crypto';
import { spawn, spawnSync } from 'node:child_process';
import { createRequire } from 'node:module';
import { mkdirSync, readFileSync, writeFileSync } from 'node:fs';
import { dirname, relative, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { chromium } from 'playwright';
import { assertPortsFree, realStackTarget } from '../real-stack-target.mjs';

/**
 * Feature E2E harness (docs/handbook/web/testing.md §4a).
 *
 * One process boots the real stack once — disposable PostgreSQL from scripts/parity-test-env.mjs, the real
 * Fastify app in-process as the non-owner `app_user` under forced RLS, and the production Next build — and then
 * runs every case of every selected feature module through Chromium. No request is intercepted or mocked; the
 * harness counts route registrations and fails the run if any appear.
 *
 * A case is one row of a module's frozen matrix (.kiro/skills/datacare-feature-browser-validation evidence
 * contract). Each case gets a fresh browser context (its own session cookie), its own screenshots, a log of the
 * API requests the page made, and the console/page errors. The case function returns evidence objects (the
 * independently computed expectation, the database observation, the downstream observation, any output bytes),
 * which the harness writes and hashes. A thrown assertion is a failed case; the run continues to the next case.
 */

const here = dirname(fileURLToPath(import.meta.url));
export const webRoot = resolve(here, '../../../..');
const repoRoot = resolve(webRoot, '..');
const apiRequire = createRequire(new URL('../../../api/package.json', import.meta.url));
const { PrismaClient } = apiRequire('@datacare/db');

export const TENANT = 'feature-e2e';
export const SECOND_TENANT = 'feature-e2e-sentinel';

const sha256 = (data) => createHash('sha256').update(data).digest('hex');
const wait = (ms) => new Promise((done) => setTimeout(done, ms));

/** SHA-256 of the exact source bytes a run depends on, so a run record names the inputs it tested. */
function inputsHash(files) {
  const hash = createHash('sha256');
  for (const file of files.sort()) {
    hash.update(file);
    hash.update(readFileSync(resolve(repoRoot, file)));
  }
  return hash.digest('hex');
}

function gitHead() {
  const out = spawnSync('git', ['rev-parse', 'HEAD'], { cwd: repoRoot, encoding: 'utf8' });
  const sha = out.stdout.trim().toLowerCase();
  assert.match(sha, /^[0-9a-f]{40}$/, 'feature E2E needs a git checkout to name its candidate');
  return sha;
}

function dirtyPatchHash() {
  const out = spawnSync('git', ['diff', 'HEAD'], { cwd: repoRoot, encoding: 'utf8' });
  return out.stdout ? sha256(out.stdout) : null;
}

/** Start the stack. Returns the handles every module and case uses. */
export async function startStack({ artifacts }) {
  mkdirSync(artifacts, { recursive: true });
  const target = realStackTarget(webRoot);
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
  });
  const runtime = new PrismaClient();
  const role = await runtime.$queryRawUnsafe(
    `SELECT rolsuper,rolbypassrls FROM pg_roles WHERE rolname=current_user`,
  );
  assert.deepEqual(role, [{ rolsuper: false, rolbypassrls: false }], 'runtime must be app_user');

  const { buildApp } = await import('../../../api/dist/app.js');
  const { hashPassword } = await import('../../../api/dist/modules/auth/password.js');
  const { seedCompany } = await import('../../../api/dist/modules/ops/seedCompany.js');

  const app = await buildApp({
    prisma: runtime,
    secret: randomBytes(32).toString('hex'),
    secureCookies: false,
    defaultTenantId: TENANT,
    allowTenantHeader: false,
  });
  await assertPortsFree(target);
  await app.listen({ port: target.apiPort, host: '127.0.0.1' });

  let serverLog = '';
  const server = spawn(
    'pnpm',
    [
      '--filter',
      '@datacare/web',
      'exec',
      'next',
      'start',
      '-p',
      String(target.webPort),
      '-H',
      '127.0.0.1',
    ],
    {
      cwd: webRoot,
      env: { ...process.env, API_ORIGIN: target.apiOrigin },
      detached: true,
      stdio: ['ignore', 'pipe', 'pipe'],
    },
  );
  server.stdout.on('data', (chunk) => (serverLog += chunk));
  server.stderr.on('data', (chunk) => (serverLog += chunk));
  let ready = false;
  for (let attempt = 0; attempt < 120 && !ready; attempt++) {
    if (server.exitCode != null) throw new Error(`Next exited: ${serverLog}`);
    try {
      ready = (await fetch(`${target.webOrigin}/login`)).ok;
    } catch {
      /* not listening yet */
    }
    if (!ready) await wait(250);
  }
  assert(ready, 'Next startup timed out');

  const browser = await chromium.launch({ headless: true });
  return {
    target,
    owner,
    runtime,
    app,
    server,
    browser,
    artifacts,
    hashPassword,
    seedCompany,
    candidate: gitHead(),
    dirtyPatch: dirtyPatchHash(),
  };
}

export async function stopStack(stack) {
  await stack?.browser?.close().catch(() => {});
  if (stack?.server?.pid) {
    try {
      process.kill(-stack.server.pid, 'SIGTERM');
    } catch {
      /* already gone */
    }
  }
  await stack?.app?.close().catch(() => {});
  await stack?.runtime?.$disconnect().catch(() => {});
  await stack?.owner?.$disconnect().catch(() => {});
}

/** Delete every tenant-scoped row of the given tenants (fixture reset between modules). */
export async function wipeTenants(owner, tenants) {
  const tables = await owner.$queryRawUnsafe(
    `SELECT DISTINCT table_name FROM information_schema.columns
      WHERE table_schema='public' AND column_name='tenant_id'`,
  );
  for (const { table_name } of tables)
    await owner.$executeRawUnsafe(
      `DELETE FROM "${table_name}" WHERE tenant_id = ANY($1::text[])`,
      tenants,
    );
}

/**
 * Saved authenticated browser state, one per login slot.
 *
 * `/auth/login` is limited to 10 per minute (app.ts:500), which is a security control and stays on. A case
 * therefore does not log in on its own: the first case that needs a slot performs one real login through the
 * login and Open Company screens, and every later context for that slot starts from the cookies it produced.
 * A slot is `user` or `user#n`; two slots for the same user are two independent server sessions, which the
 * two-operator (T12) cases need.
 */
const savedLogins = new Map();
/**
 * Refresh tokens rotate and are single-use: replaying one revokes the session (session.ts 'refresh-reused').
 * A saved state is therefore only reused while its access cookie (15 min, app.ts:115) is comfortably valid, so
 * no case ever needs to refresh. After 10 minutes the slot logs in again — a handful of logins per run, well
 * under the 10/minute limit.
 */
const SAVED_LOGIN_MAX_AGE_MS = 10 * 60 * 1000;

async function savedLogin(stack, { user, password, slot }) {
  const key = slot ?? user;
  const saved = savedLogins.get(key);
  if (saved && Date.now() - saved.at < SAVED_LOGIN_MAX_AGE_MS) return saved.state;
  const context = await stack.browser.newContext({ baseURL: stack.target.webOrigin });
  const page = await context.newPage();
  const requests = [];
  page.on('response', (response) => {
    const url = new URL(response.url());
    if (url.pathname.startsWith('/api/'))
      requests.push({
        method: response.request().method(),
        path: url.pathname,
        status: response.status(),
      });
  });
  try {
    await page.goto('/login');
    await page.getByLabel('User', { exact: true }).fill(user);
    await page.getByLabel('Password', { exact: true }).fill(password);
    await page.getByRole('button', { name: 'Sign In', exact: true }).click();
    await page
      .getByRole('heading', { name: 'Open Company', exact: true })
      .waitFor({ timeout: 20_000 });
    await page.getByRole('button', { name: 'Open', exact: true }).click();
    await page.waitForURL('**/dashboard', { timeout: 20_000 });
  } catch (error) {
    const message = await page
      .locator('[role=alert], .msg.err')
      .allInnerTexts()
      .catch(() => []);
    await context.close();
    throw new Error(
      `login as ${user} stalled: ${String(error?.message ?? error).split('\n')[0]}; ` +
        `api ${JSON.stringify(requests.slice(-8))}; screen ${JSON.stringify(message)}`,
    );
  }
  const state = await context.storageState();
  await context.close();
  savedLogins.set(key, { state, at: Date.now() });
  return state;
}

/** Forget saved logins, e.g. after the fixture data (and its users) were reseeded. */
export function resetSavedLogins() {
  savedLogins.clear();
}

/**
 * A long-lived authenticated context for one crawler worker. Each worker uses its own login slot, so its refresh
 * token is never shared with another context (refresh tokens are single-use).
 */
export async function authenticatedContext(stack, credentials) {
  const storageState = await savedLogin(stack, credentials);
  return stack.browser.newContext({
    baseURL: stack.target.webOrigin,
    viewport: { width: 1600, height: 1000 },
    storageState,
    acceptDownloads: true,
  });
}

/**
 * A new, isolated browser context for one case, authenticated as `user` (see savedLogin). Every request the
 * page makes to /api is recorded; console errors and page errors are collected.
 */
export async function openSession(stack, credentials) {
  const storageState = await savedLogin(stack, credentials);
  const context = await stack.browser.newContext({
    baseURL: stack.target.webOrigin,
    viewport: { width: 1600, height: 1000 },
    storageState,
  });
  let interceptions = 0;
  for (const holder of [context]) {
    for (const method of ['route', 'routeFromHAR']) {
      const original = holder[method]?.bind(holder);
      if (!original) continue;
      holder[method] = async (...args) => {
        interceptions += 1;
        return original(...args);
      };
    }
  }
  const page = await context.newPage();
  const requests = [];
  const consoleErrors = [];
  page.on('response', (response) => {
    const url = new URL(response.url());
    if (!url.pathname.startsWith('/api/')) return;
    requests.push({
      method: response.request().method(),
      path: url.pathname,
      query: url.search,
      status: response.status(),
    });
  });
  page.on('console', (message) => {
    if (message.type() !== 'error') return;
    const text = message.text();
    // Chrome logs every non-2xx fetch as "Failed to load resource". A refusal case expects a 4xx, and the
    // response itself is recorded in `requests`; only script errors and 5xx answers count as page errors.
    if (/^Failed to load resource: the server responded with a status of 4\d\d/.test(text)) return;
    consoleErrors.push(text);
  });
  page.on('pageerror', (error) => consoleErrors.push(`pageerror: ${error.message}`));
  page.on('dialog', (dialog) => void dialog.accept());

  // The saved session must still be authenticated: the dashboard renders, not the login screen.
  await page.goto('/dashboard');
  if (new URL(page.url()).pathname.startsWith('/login'))
    throw new Error(`saved session for ${credentials.user} is no longer authenticated`);
  return {
    context,
    page,
    requests,
    consoleErrors,
    interceptions: () => interceptions,
    close: () => context.close(),
  };
}

/** Run every case of a module; never stop on a failed case. */
export async function runModule(stack, module, { onlyCases } = {}) {
  const moduleDir = resolve(stack.artifacts, module.feature);
  mkdirSync(moduleDir, { recursive: true });
  const matrix = {
    feature: module.feature,
    candidate: stack.candidate,
    inputsHash: inputsHash(module.inputs),
    fixtureHash: sha256(JSON.stringify(module.fixtureManifest)),
    settingsHash: sha256(JSON.stringify(module.settingsManifest)),
    cases: module.cases.map(
      ({ id, group, source, applicable, reason, kind, requiredEvidence }) => ({
        id,
        group,
        source,
        applicable,
        ...(reason ? { reason } : {}),
        kind,
        requiredEvidence,
      }),
    ),
  };
  const matrixBytes = `${JSON.stringify(matrix, null, 2)}\n`;
  writeFileSync(resolve(moduleDir, 'matrix.json'), matrixBytes);

  const startedAt = new Date().toISOString();
  const results = [];
  let interceptions = 0;
  for (const testCase of module.cases) {
    if (!testCase.applicable) {
      results.push({ id: testCase.id, status: 'not-applicable', observation: testCase.reason });
      continue;
    }
    if (onlyCases && !onlyCases.has(testCase.id)) {
      results.push({
        id: testCase.id,
        status: 'untested',
        observation: 'not selected in this run (FEATURE_E2E_CASES filter)',
        desktopStatus: 'not-run',
      });
      continue;
    }
    if (testCase.blocked) {
      results.push({
        id: testCase.id,
        status: 'blocked',
        observation: testCase.blocked,
        desktopStatus: 'not-run',
      });
      continue;
    }
    const caseDir = resolve(moduleDir, testCase.id);
    mkdirSync(caseDir, { recursive: true });
    const sessions = [];
    const shots = [];
    const ctx = {
      stack,
      owner: stack.owner,
      tenantId: TENANT,
      module,
      /** Log in a new independent session (own browser context and cookie). */
      session: async (credentials = module.defaultUser) => {
        const s = await openSession(stack, credentials);
        sessions.push(s);
        return s;
      },
      /** Full-page screenshot into this case's evidence directory. */
      shot: async (page, name) => {
        const path = resolve(caseDir, `${String(shots.length + 1).padStart(2, '0')}-${name}.png`);
        await page.screenshot({ path, fullPage: true });
        shots.push(relative(caseDir, path));
      },
      rows: (sql, ...params) => stack.owner.$queryRawUnsafe(sql, TENANT, ...params),
    };
    const begun = Date.now();
    let outcome;
    try {
      const evidence = await testCase.run(ctx);
      assert(evidence && typeof evidence === 'object', `${testCase.id}: case must return evidence`);
      assert(evidence.observation, `${testCase.id}: case must report its observation`);
      for (const s of sessions)
        assert.deepEqual(s.consoleErrors, [], `${testCase.id}: browser console errors`);
      outcome = { status: 'passed', ...evidence };
    } catch (error) {
      const page = sessions.at(-1)?.page;
      if (page) await ctx.shot(page, 'failure').catch(() => {});
      // A failed case must still prove itself (evidence contract): the independent expectation, and what the
      // database and downstream state actually are after the failed attempt.
      const observed = testCase.observe
        ? await testCase.observe(ctx).catch((e) => ({ observeError: String(e?.message ?? e) }))
        : {};
      outcome = {
        status: 'failed',
        observation: `FAILED: ${String(error?.message ?? error).slice(0, 2000)}`,
        expected: testCase.expected ?? { note: 'see the case source and assertions' },
        database: observed,
        downstream: observed,
        output:
          testCase.kind === 'output' ? Buffer.from(String(error?.message ?? error)) : undefined,
      };
    }
    for (const s of sessions) {
      interceptions += s.interceptions();
      await s.close().catch(() => {});
    }
    const browserArtifact = {
      screenshots: shots,
      requests: sessions.map((s) => s.requests),
      consoleErrors: sessions.map((s) => s.consoleErrors),
      durationMs: Date.now() - begun,
    };
    const evidenceFiles = {};
    const write = (kind, value) => {
      if (value === undefined) return;
      const bytes = Buffer.isBuffer(value)
        ? value
        : Buffer.from(`${JSON.stringify(value, null, 2)}\n`);
      const name = Buffer.isBuffer(value) ? `${kind}.bin` : `${kind}.json`;
      writeFileSync(resolve(caseDir, name), bytes);
      evidenceFiles[kind] = {
        path: relative(moduleDir, resolve(caseDir, name)),
        sha256: sha256(bytes),
      };
    };
    write('browser', browserArtifact);
    write('expected', outcome.expected ?? testCase.expected);
    write('database', outcome.database);
    write('downstream', outcome.downstream);
    write('output', outcome.output);
    results.push({
      id: testCase.id,
      status: outcome.status,
      observation: outcome.observation,
      driver: 'browser',
      desktopStatus: 'not-run',
      evidence: evidenceFiles,
    });
    console.log(`  ${outcome.status === 'passed' ? 'PASS' : 'FAIL'} ${testCase.id}`);
    if (outcome.status !== 'passed') console.log(`       ${outcome.observation.split('\n')[0]}`);
  }
  const run = {
    feature: module.feature,
    candidate: matrix.candidate,
    inputsHash: matrix.inputsHash,
    fixtureHash: matrix.fixtureHash,
    settingsHash: matrix.settingsHash,
    matrixSha256: sha256(matrixBytes),
    dirtyPatchSha256: stack.dirtyPatch,
    startedAt,
    finishedAt: new Date().toISOString(),
    businessResponseMocks: 0,
    requestInterceptions: interceptions,
    cases: results,
  };
  writeFileSync(resolve(moduleDir, 'run.json'), `${JSON.stringify(run, null, 2)}\n`);
  assert.equal(interceptions, 0, `${module.feature}: request interception is not allowed`);
  return { matrix, run, moduleDir };
}

/** The contract's own validator, so the suite cannot drift from it. */
export function validateBundle(moduleDir) {
  const out = spawnSync(
    'python3',
    [
      resolve(
        repoRoot,
        '.kiro/skills/datacare-feature-browser-validation/scripts/validate_evidence.py',
      ),
      resolve(moduleDir, 'matrix.json'),
      resolve(moduleDir, 'run.json'),
      '--evidence-root',
      moduleDir,
    ],
    { encoding: 'utf8' },
  );
  let summary;
  try {
    summary = JSON.parse(out.stdout);
  } catch {
    throw new Error(`validator output unreadable: ${out.stdout}${out.stderr}`);
  }
  return { exitCode: out.status, summary };
}

/**
 * Compare a module's failures with the checked-in known-defect baseline.
 *
 * The baseline only shrinks: a new failure fails CI, and so does a baseline entry whose case now passes (it has
 * to be removed in the same change that fixed it). A blocked case must say why in the matrix, and stays in the
 * denominator of every reported percentage.
 */
export function compareBaseline(feature, run, baseline) {
  const known = new Map((baseline[feature] ?? []).map((entry) => [entry.case, entry]));
  const failed = run.cases.filter((c) => c.status === 'failed').map((c) => c.id);
  const newFailures = failed.filter((id) => !known.has(id));
  const fixed = [...known.keys()].filter(
    (id) => run.cases.find((c) => c.id === id)?.status === 'passed',
  );
  const missing = [...known.keys()].filter((id) => !run.cases.some((c) => c.id === id));
  return { failed, newFailures, fixed, missing };
}
