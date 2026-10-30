/**
 * Zero-mock browser check of the Standard edition gate (N171, D31).
 *
 *   node scripts/parity-test-env.mjs -- node apps/web/test/edition.real-stack.mjs
 *
 * Real Chromium -> production Next -> in-process Fastify (app_user under forced RLS) -> disposable PostgreSQL.
 * The company comes from the real seedCompany provisioning; the operator signs in through the login and Open Company
 * screens. Phase 1 runs the API as the Standard edition: the navigation lists only Standard menus, a Pro screen
 * opened by URL is refused, and its API answers 403 edition-unavailable. Phase 2 restarts the API with Beta on (same
 * signing secret, so the session survives): the Pro screen appears in the Beta group, opens with a Beta notice, and
 * its API passes the gate. Desktop authority: MDI_FORM.cs:11249-11322 loads MENU_DATA by edition.
 */
import assert from 'node:assert/strict';
import { createRequire } from 'node:module';
import { randomBytes } from 'node:crypto';
import { spawn } from 'node:child_process';
import { mkdirSync, writeFileSync } from 'node:fs';
import { resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { realStackTarget } from './real-stack-target.mjs';

const root = resolve(dirname(fileURLToPath(import.meta.url)), '../../..');
assert(process.env.MIGRATE_DATABASE_URL, 'Run through scripts/parity-test-env.mjs');
const target = realStackTarget(root);
const { apiOrigin, webOrigin } = target;
const artifacts = resolve(root, 'test-results/edition-real-stack');
mkdirSync(artifacts, { recursive: true });
const apiRequire = createRequire(resolve(root, 'apps/api/package.json'));
const webRequire = createRequire(resolve(root, 'apps/web/package.json'));
const { PrismaClient } = apiRequire('@datacare/db');
const { chromium } = webRequire('playwright');
const { buildApp } = await import(resolve(root, 'apps/api/dist/app.js'));
const { hashPassword } = await import(resolve(root, 'apps/api/dist/modules/auth/password.js'));
const { seedCompany } = await import(resolve(root, 'apps/api/dist/modules/ops/seedCompany.js'));

const TENANT = 'browser-edition-gate';
const LOGIN = 'edition';
const password = `Edition-${randomBytes(12).toString('hex')}!`;
const secret = randomBytes(32).toString('hex');
const owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
const runtime = new PrismaClient();
const checks = {};
let app;
let server;
let browser;
let serverLog = '';

async function wipe() {
  const rows = await owner.$queryRawUnsafe(
    `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
  );
  for (const row of rows)
    await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, TENANT);
}

async function startApi(edition) {
  if (app) await app.close();
  app = await buildApp({
    prisma: runtime,
    secret,
    secureCookies: false,
    defaultTenantId: TENANT,
    allowTenantHeader: false,
    edition,
  });
  await app.listen({ host: '127.0.0.1', port: target.apiPort });
}

const navHrefs = (page) =>
  page.locator('nav a').evaluateAll((links) => links.map((a) => a.getAttribute('href')));
const apiStatus = (page, method, url) =>
  page.evaluate(
    async ([m, u]) => {
      const r = await fetch(`/api${u}`, {
        method: m,
        credentials: 'include',
        headers: { 'content-type': 'application/json' },
        body: m === 'GET' ? undefined : '{}',
      });
      return { status: r.status, body: await r.text() };
    },
    [method, url],
  );

const result = { status: 'running', startedAt: new Date().toISOString(), checks };
try {
  await wipe();
  await seedCompany(runtime, TENANT, '01', { coName: 'Edition Gate Jeweller', lcCode: '01' });
  await owner.$executeRawUnsafe(
    `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
     VALUES($1,'01',$2,$3,'ADMIN','Y','Y','Y','N')`,
    TENANT,
    LOGIN,
    await hashPassword(password),
  );

  // Phase 1: Standard.
  await startApi({ code: 'S', beta: false });
  server = spawn(
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
      cwd: root,
      env: { ...process.env, API_ORIGIN: apiOrigin },
      detached: true,
      stdio: ['ignore', 'pipe', 'pipe'],
    },
  );
  server.stdout.on('data', (chunk) => (serverLog += chunk));
  server.stderr.on('data', (chunk) => (serverLog += chunk));
  let ready = false;
  for (let attempt = 0; attempt < 80 && !ready; attempt++) {
    try {
      ready = (await fetch(`${webOrigin}/login`)).ok;
    } catch {
      /* starting */
    }
    if (!ready) await new Promise((r) => setTimeout(r, 250));
  }
  assert(ready, 'production Next did not start');

  browser = await chromium.launch();
  const context = await browser.newContext({ baseURL: webOrigin });
  const page = await context.newPage();
  await page.goto('/login');
  await page.getByRole('textbox', { name: 'Company Code' }).fill('01');
  await page.getByRole('textbox', { name: 'User' }).fill(LOGIN);
  await page.getByRole('textbox', { name: 'Password' }).fill(password);
  await page.getByRole('button', { name: 'Sign In' }).click();
  await page.getByRole('button', { name: 'Open', exact: true }).click();
  await page.getByRole('heading', { name: /^Dashboard FY/ }).waitFor();

  assert.equal((await page.getByTestId('edition').textContent())?.trim(), 'Standard');
  const standardNav = await navHrefs(page);
  for (const href of [
    '/txn/sales',
    '/txn/purchase',
    '/txn/receipt',
    '/reports/rojmel',
    '/admin/users',
  ])
    assert(standardNav.includes(href), `Standard navigation lists ${href}`);
  for (const href of [
    '/txn/dhrn-issue',
    '/txn/scheme',
    '/txn/tag-split',
    '/txn/stock-in',
    '/masters/locations',
  ])
    assert(!standardNav.includes(href), `Standard navigation hides ${href}`);
  assert.equal(await page.getByTestId('beta-menus').count(), 0, 'no Beta group in Standard');
  checks.standardNavigation = { links: standardNav.length };

  await page.goto('/txn/dhrn-issue');
  await page.getByTestId('edition-unavailable').waitFor();
  assert.match(
    (await page.getByTestId('edition-unavailable').textContent()) ?? '',
    /not part of the Standard edition/,
  );
  assert.equal(await page.getByRole('heading', { name: 'Pledge Loan — Issue' }).count(), 0);
  const refused = await apiStatus(page, 'POST', '/dhrn/issue');
  assert.equal(refused.status, 403);
  assert.deepEqual(JSON.parse(refused.body), {
    error: 'edition-unavailable',
    form: 'Loans (Dhrn)/Pledge Issue',
    edition: 'S',
  });
  assert.equal((await apiStatus(page, 'GET', '/masters/items')).status, 200);
  const catalog = JSON.parse((await apiStatus(page, 'GET', '/admin/form-catalog')).body);
  assert(
    !catalog.some((form) => form.mainMenu === 'Loans (Dhrn)'),
    'rights catalog lists no Dhiran form',
  );
  checks.standardRefusal = { page: 'guarded', api: refused.status, rightsForms: catalog.length };

  // Phase 2: Beta on, same secret, so the browser session carries over.
  await startApi({ code: 'S', beta: true });
  await page.goto('/dashboard');
  await page.getByRole('heading', { name: /^Dashboard FY/ }).waitFor();
  assert.equal((await page.getByTestId('edition').textContent())?.trim(), 'Standard + Beta');
  const beta = page.getByTestId('beta-menus');
  await beta.getByRole('link', { name: /Pledge Issue/ }).click();
  await page.getByRole('heading', { name: 'Pledge Loan — Issue' }).waitFor();
  await page.getByTestId('edition-beta').waitFor();
  const passed = await apiStatus(page, 'GET', '/dhrn/issue/1');
  assert.notEqual(passed.status, 403, `Beta lets the API pass the gate: ${passed.body}`);
  checks.beta = { pledgeIssueRenders: true, api: passed.status };

  await page.screenshot({ path: resolve(artifacts, 'beta.png'), fullPage: true });
  result.status = 'passed';
  console.log('EDITION_REAL_STACK_PASSED', JSON.stringify(checks));
} catch (error) {
  result.status = 'failed';
  result.error = String(error?.stack ?? error);
  console.error('EDITION_REAL_STACK_FAILED', error);
  if (serverLog) writeFileSync(resolve(artifacts, 'next.log'), serverLog);
  process.exitCode = 1;
} finally {
  result.finishedAt = new Date().toISOString();
  writeFileSync(resolve(artifacts, 'result.json'), `${JSON.stringify(result, null, 2)}\n`);
  if (browser) await browser.close().catch(() => {});
  if (server?.pid) {
    try {
      process.kill(-server.pid, 'SIGTERM');
    } catch {
      /* already gone */
    }
  }
  if (app) await app.close().catch(() => {});
  await wipe().catch(() => {});
  await owner.$disconnect();
  await runtime.$disconnect();
}
