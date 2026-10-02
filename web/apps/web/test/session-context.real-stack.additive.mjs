import assert from 'node:assert/strict';
import { createRequire } from 'node:module';
import { randomBytes } from 'node:crypto';
import { spawn } from 'node:child_process';
import { mkdirSync, writeFileSync } from 'node:fs';
import { resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { realStackTarget } from './real-stack-target.mjs';
import {
  sessionContextFixture,
  sessionContextRequiredChecks,
  seedSessionContext,
  cleanupSessionContext,
  exerciseSessionContext,
} from './session-context.journey.mjs';
import {
  exerciseSessionContextLifecycle,
  sessionContextLifecycleRequiredChecks,
} from './session-context-lifecycle.journey.mjs';

// OPTIONAL separate runner. It never imports or modifies the sixteen-journey parity harness.
// Execute only under scripts/parity-test-env.mjs with the scheduled disposable DB lease.
const root = resolve(
  process.env.SESSION_CONTEXT_WEB_ROOT ||
    resolve(dirname(fileURLToPath(import.meta.url)), '../../..'),
);
const apiRequire = createRequire(resolve(root, 'apps/api/package.json'));
const webRequire = createRequire(resolve(root, 'apps/web/package.json'));
const { PrismaClient } = apiRequire('@prisma/client');
const { chromium } = webRequire('playwright');
assert.equal(
  process.env.RUN_DB_INTEGRITY_TESTS,
  '1',
  'Use the parity environment wrapper and acquire the serial browser/DB lease',
);
// Database, ports and build origin (N49 step 4): see real-stack-target.mjs.
const target = realStackTarget(root);
const { apiOrigin, webOrigin } = target;
const artifacts = resolve(
  process.env.SESSION_CONTEXT_ARTIFACT_DIR ||
    resolve(root, 'test-results/session-context-real-stack-lifecycle'),
);
mkdirSync(artifacts, { recursive: true });
const { buildApp } = await import(resolve(root, 'apps/api/dist/app.js'));
const { hashPassword } = await import(resolve(root, 'apps/api/dist/modules/auth/password.js'));
const owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
const runtime = new PrismaClient();
const password = `Context-${randomBytes(18).toString('hex')}!`;
const tenantId = sessionContextFixture.tenantId;
const sql = (query, ...parameters) => owner.$executeRawUnsafe(query, tenantId, ...parameters);
let app, server, browser, page;
let serverLog = '';
const result = {
  status: 'running',
  startedAt: new Date().toISOString(),
  requiredChecks: [...sessionContextRequiredChecks, ...sessionContextLifecycleRequiredChecks],
  provenance:
    'Real Chromium -> production Next -> Fastify -> PostgreSQL app_user/RLS; explicitly injected upstream response transport faults',
  releaseSha: process.env.RELEASE_SHA || null,
  database: target.databaseLabel,
};
try {
  await seedSessionContext(sql, { passwordHash: await hashPassword(password) });
  app = await buildApp({
    prisma: runtime,
    secret: randomBytes(32).toString('hex'),
    secureCookies: false,
    defaultTenantId: tenantId,
    allowTenantHeader: false,
  });
  await app.listen({ host: '127.0.0.1', port: target.apiPort });
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
  server.stdout.on('data', (chunk) => {
    serverLog += chunk;
  });
  server.stderr.on('data', (chunk) => {
    serverLog += chunk;
  });
  let ready = false;
  for (let attempt = 0; attempt < 80; attempt++) {
    if (server.exitCode !== null)
      throw new Error('The production Next server exited before readiness');
    try {
      if ((await fetch(`${webOrigin}/login`)).ok) {
        ready = true;
        break;
      }
    } catch {
      /* startup only */
    }
    await new Promise((done) => setTimeout(done, 250));
  }
  assert(ready, 'Production Next readiness timed out');
  browser = await chromium.launch({ headless: true });
  const context = await browser.newContext({
    baseURL: webOrigin,
    viewport: { width: 1600, height: 1000 },
  });
  page = await context.newPage();
  page.setDefaultTimeout(20_000);
  let registrations = 0;
  const instrument = (target) => {
    for (const name of ['route', 'routeFromHAR']) {
      const original = target[name].bind(target);
      target[name] = async (...args) => {
        registrations++;
        return original(...args);
      };
    }
  };
  instrument(context);
  context.on('page', instrument);
  instrument(page);
  const checkpoint = (target, name) =>
    target.screenshot({ path: resolve(artifacts, `${name}.png`), fullPage: true });
  result.sessionContext = await exerciseSessionContext(page, {
    owner,
    password,
    tenantId,
    checkpoint,
    onProgress: (progress) => {
      result.sessionContext = progress;
    },
  });
  result.sessionContextLifecycle = await exerciseSessionContextLifecycle(page, {
    owner,
    tenantId,
    checkpoint,
    onProgress: (progress) => {
      result.sessionContextLifecycle = progress;
    },
  });
  assert.equal(
    registrations,
    5,
    'Only the original three plus additive two declared transport registrations are allowed',
  );
  assert.equal(
    result.sessionContext.transportFaultInjections.length +
      result.sessionContextLifecycle.transportFaultInjections.length,
    registrations,
  );
  result.actualInterceptionRegistrations = registrations;
  result.status = 'passed';
  process.stdout.write(
    'SESSION_CONTEXT_REAL_STACK_PASSED: 14 checks (original12 + additive2), real responses with 5 declared transport injections; no synthetic business response\n',
  );
} catch (error) {
  result.status = 'failed';
  if (result.sessionContext)
    result.sessionContext.status = result.sessionContext.status === 'passed' ? 'passed' : 'failed';
  if (result.sessionContextLifecycle) result.sessionContextLifecycle.status = 'failed';
  result.error = error instanceof Error ? error.message : String(error);
  process.exitCode = 1;
  await page
    ?.screenshot({ path: resolve(artifacts, 'failure.png'), fullPage: true })
    .catch(() => {});
  process.stderr.write(`SESSION_CONTEXT_REAL_STACK_FAILED: ${result.error}\n`);
} finally {
  result.finishedAt = new Date().toISOString();
  writeFileSync(resolve(artifacts, 'result.json'), `${JSON.stringify(result, null, 2)}\n`);
  // Server output is internal local diagnostic data; no browser cookies/tokens or passwords are recorded.
  writeFileSync(resolve(artifacts, 'next-server.log'), serverLog);
  await browser?.close();
  if (server?.pid) {
    try {
      process.kill(-server.pid, 'SIGTERM');
    } catch {
      /* already exited */
    }
  }
  await app?.close();
  await cleanupSessionContext(sql);
  await runtime.$disconnect();
  await owner.$disconnect();
}
