import assert from 'node:assert/strict';
import { createRequire } from 'node:module';
import { randomBytes } from 'node:crypto';
import { spawn } from 'node:child_process';
import { existsSync, mkdirSync, writeFileSync } from 'node:fs';
import { resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { realStackTarget } from './real-stack-target.mjs';
import { seedSessionContext } from './session-context.journey.mjs';
import { seedSalesReturnLabourReplay } from './sales-return-labour-replay.journey.mjs';
import {
  labourPreviewLifecycleFixture,
  labourPreviewLifecycleRequiredChecks,
  labourPreviewLifecycleTables,
  exerciseLabourPreviewLifecycle,
} from './labour-preview-lifecycle.journey.mjs';

// Separate optional runner; every case is mandatory when invoked. No shared16/17-runner edits.
const root = resolve(
  process.env.LABOUR_PREVIEW_WEB_ROOT ||
    resolve(dirname(fileURLToPath(import.meta.url)), '../../..'),
);
assert.equal(
  process.env.RUN_DB_INTEGRITY_TESTS,
  '1',
  'Use scripts/parity-test-env.mjs and the root-owned serial DB/browser lease',
);
// Database, ports and build origin (N49 step 4): see real-stack-target.mjs.
const target = realStackTarget(root);
const { apiOrigin, webOrigin } = target;
const artifacts = resolve(
  process.env.LABOUR_PREVIEW_ARTIFACT_DIR ||
    resolve(root, 'test-results/return-labour-preview-lifecycle'),
);
assert(
  !existsSync(resolve(artifacts, 'result.json')),
  'Use a new artifact directory; preserve previous executions',
);
mkdirSync(artifacts, { recursive: true });
const apiRequire = createRequire(resolve(root, 'apps/api/package.json'));
const webRequire = createRequire(resolve(root, 'apps/web/package.json'));
const { PrismaClient } = apiRequire('@prisma/client');
const { chromium } = webRequire('playwright');
const { buildApp } = await import(resolve(root, 'apps/api/dist/app.js'));
const { hashPassword } = await import(resolve(root, 'apps/api/dist/modules/auth/password.js'));
const owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
const runtime = new PrismaClient();
const password = `Labour-${randomBytes(18).toString('hex')}!`;
const tenantId = labourPreviewLifecycleFixture.tenantId;
assert.equal(tenantId, 'browser-labour-faults');
const sql = (statement, ...parameters) =>
  owner.$executeRawUnsafe(statement, tenantId, ...parameters);
const cleanup = async () => {
  for (const table of labourPreviewLifecycleTables)
    await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`);
};
let app, server, browser, page;
let serverLog = '';
const result = {
  status: 'running',
  startedAt: new Date().toISOString(),
  requiredChecks: labourPreviewLifecycleRequiredChecks,
  provenance: `Real Chromium -> production Next${target.webPort} -> Fastify${target.apiPort} -> disposable PostgreSQL${target.dbPort} app_user/RLS. Four explicit actual-response transport faults; no synthetic business response.`,
  fixtureSha256: '8c2e2ba9a985a1e57e353bcbf742e8b350fac47cd34e6cf96f7cb283adbeb78b',
  tenantId,
  releaseSha: process.env.RELEASE_SHA || null,
  cleanupErrors: [],
};
try {
  await cleanup();
  await seedSessionContext(sql, { passwordHash: await hashPassword(password) });
  // The baseline labour seed copies this credential to its View-only user. This real fixture
  // copy stays within the new tenant and uses the already generated password hash.
  assert.equal(
    await sql(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED") SELECT tenant_id,"CO_CODE",'browser',"LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED" FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "LOGIN_NAME"='context-browser' AND "CO_CODE" IN('01','02')`,
    ),
    2,
  );
  await seedSalesReturnLabourReplay(sql);
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
    if (server.exitCode !== null) throw new Error('Production Next exited before readiness');
    try {
      if ((await fetch(`${webOrigin}/login`)).ok) {
        ready = true;
        break;
      }
    } catch {
      /* startup only */
    }
    await new Promise((resolve) => setTimeout(resolve, 250));
  }
  assert(ready, 'Production Next readiness timed out');
  browser = await chromium.launch({ headless: true });
  const context = await browser.newContext({
    baseURL: webOrigin,
    viewport: { width: 1600, height: 1000 },
  });
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
  page = await context.newPage();
  page.setDefaultTimeout(20_000);
  const checkpoint = (target, name) =>
    target.screenshot({ path: resolve(artifacts, `${name}.png`), fullPage: true });
  result.labourPreviewLifecycle = await exerciseLabourPreviewLifecycle(page, {
    owner,
    tenantId,
    password,
    checkpoint,
    onProgress: (progress) => {
      result.labourPreviewLifecycle = progress;
    },
  });
  assert.equal(
    registrations,
    4,
    'Exactly four declared response transport registrations must execute',
  );
  assert.equal(result.labourPreviewLifecycle.transportFaultInjections.length, registrations);
  assert.deepEqual(result.labourPreviewLifecycle.checks, labourPreviewLifecycleRequiredChecks);
  assert.equal(result.labourPreviewLifecycle.syntheticBusinessResponses, 0);
  result.actualInterceptionRegistrations = registrations;
  result.status = 'passed';
} catch (error) {
  result.status = 'failed';
  result.error = error instanceof Error ? error.message : String(error);
  process.exitCode = 1;
  if (result.labourPreviewLifecycle) result.labourPreviewLifecycle.status = 'failed';
  await page
    ?.screenshot({ path: resolve(artifacts, 'failure.png'), fullPage: true })
    .catch(() => {});
} finally {
  // Drain real response handlers in the journey before closing its context and deleting fixtures.
  const safely = async (label, operation) => {
    try {
      await operation();
    } catch (error) {
      result.cleanupErrors.push(
        `${label}: ${error instanceof Error ? error.message : String(error)}`,
      );
    }
  };
  await safely('browser', async () => {
    await browser?.close();
  });
  await safely('next-server', async () => {
    if (!server?.pid || server.exitCode !== null) return;
    let timer;
    try {
      await new Promise((done, reject) => {
        server.once('exit', done);
        timer = setTimeout(() => reject(new Error('Next server did not exit after SIGTERM')), 5000);
        try {
          process.kill(-server.pid, 'SIGTERM');
        } catch (error) {
          if (error.code === 'ESRCH') done();
          else reject(error);
        }
      });
    } finally {
      clearTimeout(timer);
    }
  });
  await safely('api', async () => {
    await app?.close();
  });
  await safely('fixture-cleanup', cleanup);
  await safely('runtime-disconnect', () => runtime.$disconnect());
  await safely('owner-disconnect', () => owner.$disconnect());
  if (result.cleanupErrors.length) {
    result.status = 'failed';
    process.exitCode = 1;
  }
  result.finishedAt = new Date().toISOString();
  writeFileSync(resolve(artifacts, 'result.json'), `${JSON.stringify(result, null, 2)}\n`);
  writeFileSync(resolve(artifacts, 'next-server.log'), serverLog);
  process.stdout.write(
    `LABOUR_PREVIEW_LIFECYCLE_${result.status.toUpperCase()}: ${result.labourPreviewLifecycle?.checks?.length ?? 0}/5 checks; ${result.actualInterceptionRegistrations ?? result.labourPreviewLifecycle?.transportFaultInjections?.length ?? 0}/4 explicit actual-response faults; zero synthetic business responses\n`,
  );
  if (result.error) process.stderr.write(`${result.error}\n`);
}
