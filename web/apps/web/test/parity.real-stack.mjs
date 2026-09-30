import assert from 'node:assert/strict';
import { createRequire } from 'node:module';
import { randomBytes } from 'node:crypto';
import { spawn } from 'node:child_process';
import { mkdirSync, readFileSync, writeFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { chromium } from 'playwright';
import {
  aggregateRealStackEvidence,
  summarizeJourneyEvidence,
} from './parity-real-stack-evidence.mjs';
import { exerciseTourOrder } from './tour-order.journey.mjs';
import { exerciseCreditNote } from './credit-note.journey.mjs';
import {
  cleanupCreditNoteEntry,
  creditNoteEntryFixtureTables,
  exerciseCreditNoteEntry,
  seedCreditNoteEntry,
} from './credit-note-entry.journey.mjs';
import {
  cleanupEInvoiceEntry,
  eInvoiceEntryFixtureTables,
  exerciseEInvoiceEntry,
  seedEInvoiceEntry,
} from './e-invoice-entry.journey.mjs';
import {
  cashReceiptPaymentFixtureTables,
  cleanupCashReceiptPayment,
  exerciseCashReceiptPayment,
  seedCashReceiptPayment,
} from './cash-receipt-payment.journey.mjs';
import {
  cleanupWholesaleRateCut,
  exerciseWholesaleRateCut,
  seedWholesaleRateCut,
  wholesaleRateCutFixtureTables,
} from './wholesale-rate-cut.journey.mjs';
import {
  cleanupSaleAmountBasis,
  exerciseSaleAmountBasis,
  saleAmountBasisFixtureTables,
  seedSaleAmountBasis,
} from './sale-amount-basis.journey.mjs';
import { exerciseDesignCalculation } from './design-calculation.journey.mjs';
import {
  seedDesignRepeat,
  cleanupDesignRepeat,
  exerciseDesignRepeat,
} from './design-repeat.journey.mjs';
import { seedOrderImageJourney, exerciseOrderImages } from './order-image.journey.mjs';
import { seedMfgLot, mfgLotFixtureTables, exerciseMfgLot } from './mfg-lot.journey.mjs';
import { exerciseImageConflict } from './image-conflict.journey.mjs';
import { seedSalesOrder, exerciseSalesOrder } from './sales-order.journey.mjs';
import { seedSalesOrderDesign, exerciseSalesOrderDesign } from './sales-design.journey.mjs';
import {
  seedGenericImageConflict,
  cleanupGenericImageConflict,
  exerciseGenericImageConflict,
} from './generic-image-conflict.journey.mjs';
import {
  repairImageFixtureTables,
  seedRepairImageConflict,
  cleanupRepairImageConflict,
  exerciseRepairImageConflict,
} from './repair-image-conflict.journey.mjs';
import {
  salesReturnSavedFixtureTables,
  seedSalesReturnSaved,
  cleanupSalesReturnSaved,
  snapshotSalesReturnSaved,
  exerciseSalesReturnSaved,
} from './sales-return-saved.journey.mjs';
import {
  seedColumnSettings,
  cleanupColumnSettings,
  exerciseColumnSettings,
} from './column-settings.journey.mjs';
import {
  seedSalesReturnReplay,
  cleanupSalesReturnReplay,
  snapshotSalesReturnReplay,
  salesReturnReplayFixtureTables,
  exerciseSalesReturnReplay,
} from './sales-return-replay.journey.mjs';

import {
  seedSalesReturnBillReplay,
  cleanupSalesReturnBillReplay,
  snapshotSalesReturnBillReplay,
  salesReturnBillReplayFixtureTables,
  exerciseSalesReturnBillReplay,
} from './sales-return-bill-replay.journey.mjs';

import {
  seedSalesReturnLabourReplay,
  cleanupSalesReturnLabourReplay,
  salesReturnLabourReplayFixtureTables,
  exerciseSalesReturnLabourReplay,
} from './sales-return-labour-replay.journey.mjs';

// Real Next production build -> real Fastify -> migrated PostgreSQL with app_user and forced RLS.
// Run through scripts/parity-test-env.mjs. This harness refuses the running application's database.
const root = resolve(dirname(fileURLToPath(import.meta.url)), '../../..');
const apiRequire = createRequire(new URL('../../api/package.json', import.meta.url));
const { PrismaClient } = apiRequire('@prisma/client');
const { buildApp } = await import('../../api/dist/app.js');
const { hashPassword } = await import('../../api/dist/modules/auth/password.js');
const tenantId = 'browser-parity';
const apiOrigin = 'http://127.0.0.1:4410';
const webOrigin = 'http://127.0.0.1:4411';
const artifacts = resolve(
  process.env.PARITY_ARTIFACT_DIR || resolve(root, 'test-results/parity-real-stack'),
);
mkdirSync(artifacts, { recursive: true });
for (const name of ['DATABASE_URL', 'MIGRATE_DATABASE_URL']) {
  const url = new URL(process.env[name] || 'invalid:');
  assert.equal(url.hostname, '127.0.0.1', `${name} must use the disposable local DB`);
  assert.equal(url.port, '55433', `${name} must use the disposable test port`);
  assert.equal(url.pathname, '/datacare');
}
assert.equal(new URL(process.env.DATABASE_URL).username, 'app_user');
const manifest = JSON.parse(
  readFileSync(resolve(root, 'apps/web/.next/routes-manifest.json'), 'utf8'),
);
assert(
  JSON.stringify(manifest.rewrites).includes(`${apiOrigin}/:path*`),
  'Build with API_ORIGIN=http://127.0.0.1:4410 pnpm build before running the real-stack journey',
);
const owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
const runtime = new PrismaClient();
const password = `Test-${randomBytes(18).toString('hex')}!`;
const tables = [
  ...salesReturnLabourReplayFixtureTables,
  ...salesReturnBillReplayFixtureTables,
  ...salesReturnReplayFixtureTables,
  ...salesReturnSavedFixtureTables,
  ...repairImageFixtureTables,
  ...mfgLotFixtureTables,
  ...creditNoteEntryFixtureTables,
  ...eInvoiceEntryFixtureTables,
  ...cashReceiptPaymentFixtureTables,
  ...saleAmountBasisFixtureTables,
  ...wholesaleRateCutFixtureTables,
  'COL_MAST',
  'CO_SET_NEW',
  'TAG_IMAGE_DATA',
  'audit_log',
  'auth_session',
  'ENTITY_IMAGE',
  'ENTITY_IMAGE_REVISION',
  'DESIGN_IDTL',
  'DESIGN_DETL',
  'DELETE_DATA',
  'ROJ_MEL_DATA',
  'AC_DATA',
  'SL_ORD_IDTL',
  'SL_ORD_DETL',
  'SL_ORD_DATA',
  'SL_IDTL',
  'SL_DETL',
  'SL_DATA',
  'E_DATA',
  'TEMP_BOOK_DATA',
  'BOOK_DATA',
  'ITEM_MAST',
  'PRODUCT_MAST',
  'AC_MAST',
  'CO_SET',
  'USER_SET',
  'LOGIN_MAST',
  'YEAR_MAST',
  'LOCT_MAST',
  'CO_MAST',
];
const cleanup = async () => {
  for (const table of tables)
    await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
};
const sql = (query, ...params) => owner.$executeRawUnsafe(query, tenantId, ...params);
// Delay a real saved read without replacing HTTP. Only the isolated serial browser runner owns this DB slot.
async function holdSavedReads(table) {
  assert(['REP_DATA', 'SL_DATA'].includes(table));
  let release;
  let ready;
  let fail;
  const released = new Promise((resolve) => {
    release = resolve;
  });
  const acquired = new Promise((resolve, reject) => {
    ready = resolve;
    fail = reject;
  });
  const transaction = owner.$transaction(
    async (tx) => {
      await tx.$executeRawUnsafe(`LOCK TABLE "${table}" IN ACCESS EXCLUSIVE MODE`);
      ready();
      await released;
    },
    { timeout: 30_000 },
  );
  void transaction.catch(fail);
  await acquired;
  return async () => {
    release();
    await transaction;
  };
}
const holdRepairReads = () => holdSavedReads('REP_DATA');
const holdSalesReturnReads = () => holdSavedReads('SL_DATA');
async function seed() {
  await cleanup();
  await sql(
    `INSERT INTO "CO_MAST" (tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES ($1,'01','Parity browser fixture','01')`,
  );
  await sql(
    `INSERT INTO "LOCT_MAST" (tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,'01','01','Main')`,
  );
  await sql(
    `INSERT INTO "YEAR_MAST" (tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,'01','2024-2025','2024-04-01','2025-03-31')`,
  );
  await sql(`INSERT INTO "CO_SET" (tenant_id,"CO_CODE") VALUES ($1,'01')`);
  await sql(`INSERT INTO "BOOK_DATA" (tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
    VALUES ($1,'01','01','Z09','Tour Order','TUROD','TOUR ORDER','I','Y','SL_ORD_DATA','SL_ORD_DETL')`);
  await sql(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
    VALUES($1,'01','01','146','E Credit Note','ECRNT','E CRNT','I','Y','SL_DATA','SL_DETL'),
          ($1,'01','01','147','E Credit Note 2','ECRNT','E CRNT','I','Y','SL_DATA','SL_DETL')`);
  await sql(`INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_NAME","NET_AMT","TOT_AMT","IRN_NO")
    VALUES($1,'01','01','2024-2025','146','00001','2024-07-01','Imported credit-note customer',0,0,repeat('a',64)),
          ($1,'01','01','2024-2025','147','00001','2024-07-01','Second credit-note book',0,0,NULL)`);
  await sql(`INSERT INTO "SL_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","IT_CODE")
    VALUES($1,'01','01','2024-2025','146','00001',17,42,'GOLD')`);
  await sql(`INSERT INTO "SL_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","IT_CODE","DM_NAME","IT_GWT")
    VALUES($1,'01','01','2024-2025','146','00001',42,3,'STONE','Ruby',0),
          ($1,'01','01','2024-2025','146','00001',42,9,'STONE','Diamond',0.123)`);
  await sql(`INSERT INTO "AC_MAST" (tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
    VALUES ($1,'01','01','TOURAC','Real browser tour customer'),($1,'01','01','CASH','Cash Account')`);
  await sql(`INSERT INTO "ITEM_MAST" (tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
    VALUES ($1,'01','GOLD','Gold Ring','G','G01'),($1,'01','STONE','Diamond component','D','D01')`);
  await sql(`INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","CON_PRC","OTH_RATE_TYPE","OTH_RATE")
    VALUES($1,'01','CALCS','Calculation stone','S',0.2,'P',50)`);
  await sql(
    `INSERT INTO "PRODUCT_MAST" (tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES ($1,'01','01','Gold jewellery')`,
  );
  await sql(
    `INSERT INTO "LOGIN_MAST" (tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
    VALUES ($1,'01','browser',$2,'ADMIN','Y','Y','Y','N')`,
    await hashPassword(password),
  );
}
const wait = (ms) => new Promise((resolve) => setTimeout(resolve, ms));
let app, server, browser;
let serverLog = '';
const result = {
  startedAt: new Date().toISOString(),
  releaseSha: process.env.RELEASE_SHA?.trim().toLowerCase() || null,
  database: 'disposable localhost:55433 / app_user',
  imageObservations: [],
  cameraDevice: 'Chromium synthetic video; no physical camera acceptance',
  status: 'running',
};
async function expectValue(locator, value) {
  for (let attempt = 0; attempt < 50; attempt++) {
    if ((await locator.inputValue()) === value) return;
    await wait(100);
  }
  assert.equal(await locator.inputValue(), value);
}
const checkpoint = async (name, page) =>
  page.screenshot({ path: resolve(artifacts, `${name}.png`), fullPage: true });
async function exerciseDesignBook(page) {
  const save = async (method) => {
    const [response] = await Promise.all([
      page.waitForResponse(
        (response) =>
          new URL(response.url()).pathname === '/api/masters/design-book' &&
          response.request().method() === method,
      ),
      page.getByRole('button', { name: 'Save Design Book', exact: true }).click(),
    ]);
    assert.equal(response.status(), 200, await response.text());
    await page
      .getByRole('status')
      .filter({ hasText: 'Saved and reopened 1 designs with their components.' })
      .waitFor();
  };
  await page.goto('/masters/design-book');
  await page.getByRole('heading', { name: 'Design Book', exact: true }).waitFor();
  await page.getByLabel('Book Name', { exact: true }).fill('BROWSER');
  await page.getByPlaceholder('search products… (F1)', { exact: true }).fill('01');
  await page.getByRole('button', { name: 'Load', exact: true }).click();
  await page.getByRole('status').filter({ hasText: 'This book is empty' }).waitFor();
  for (const [label, value] of Object.entries({
    'Design No': 'D-001',
    Style: 'FILIGREE',
    'Page No': '001A',
    Gross: '5.25',
    Net: '5',
    Touch: '91.6',
    'Net Amount': '35250',
  })) {
    await page.getByLabel(`${label} design 1`, { exact: true }).fill(value);
  }
  for (const [index, weight] of [
    [1, '0.125'],
    [2, '0.375'],
  ]) {
    await page.getByRole('button', { name: '+ Add Component', exact: true }).click();
    await page.getByLabel(`Item component ${index}`, { exact: true }).fill('STONE');
    await page.getByLabel(`Customer Weight component ${index}`, { exact: true }).fill(weight);
    await page
      .getByLabel(`Karigar Weight component ${index}`, { exact: true })
      .fill(index === 1 ? '0.12' : '0.35');
    await page
      .getByLabel(`Net Amount component ${index}`, { exact: true })
      .fill(index === 1 ? '500' : '1500');
  }
  await save('POST');
  const endpoint = '/api/masters/design-book?bookName=BROWSER&prCode=01';
  const first = await (await page.request.get(endpoint)).json();
  assert.equal(first[0].components.length, 2);
  assert.equal(first[0].ITM_STYLE, 'FILIGREE');
  assert.equal(String(first[0].PAGE_NO), '001A');
  await page.reload();
  await page.getByLabel('Book Name', { exact: true }).fill('BROWSER');
  await page.getByPlaceholder('search products… (F1)', { exact: true }).fill('01');
  await page.getByRole('button', { name: 'Load', exact: true }).click();
  await page.getByRole('status').filter({ hasText: 'Loaded 1 designs.' }).waitFor();
  await expectValue(page.getByLabel('Style design 1', { exact: true }), 'FILIGREE');
  await expectValue(page.getByLabel('Customer Weight component 2', { exact: true }), '0.375');
  await save('PUT');
  const unchanged = await (await page.request.get(endpoint)).json();
  for (const column of ['SR_NO', 'OLD_SRNO', 'PAGE_NO', 'ITM_STYLE', 'DESIGN_IMG_ID'])
    assert.deepEqual(unchanged[0][column], first[0][column]);
  const businessChildren = (rows) => rows.map(({ row_id, MAIN_USER, DATA_TRFR, ...row }) => row);
  assert.deepEqual(
    businessChildren(unchanged[0].components),
    businessChildren(first[0].components),
  );
  // A real PNG passes through Next and the form-specific authorized image endpoint into PostgreSQL.
  const png = Buffer.from(
    'iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP4/x8AAwAB/2+Bq7YAAAAASUVORK5CYII=',
    'base64',
  );
  const chooserReady = page.waitForEvent('filechooser');
  await page.getByTestId('entity-image-select').click();
  await (await chooserReady).setFiles({ name: 'design.png', mimeType: 'image/png', buffer: png });
  await page.getByTestId('entity-image-zoom').waitFor();
  const imageResponse = await page.request.get(
    `/api/masters/design-book/image?entityKey=${encodeURIComponent(first[0].DESIGN_IMG_ID)}`,
  );
  assert.equal(imageResponse.status(), 200);
  assert.deepEqual(await imageResponse.body(), png);
  await checkpoint('design-book-components', page);
  await page.getByLabel('Karigar Weight component 2', { exact: true }).fill('0.36');
  await save('PUT');
  const edited = await (await page.request.get(endpoint)).json();
  assert.equal(Number(edited[0].components[1].KR_WT), 0.36);
  // A second session writes through the real API; the old browser version must be refused.
  const concurrent = await page.request.put('/api/masters/design-book', {
    data: {
      bookName: 'BROWSER',
      prCode: '01',
      expectedVersion: edited[0].bookVersion,
      lines: [{ srNo: 1, designNo: 'D-001', style: 'OTHER SESSION' }],
    },
  });
  assert.equal(concurrent.status(), 200, await concurrent.text());
  await page.getByLabel('Style design 1', { exact: true }).fill('LOCAL UNSAVED');
  const [conflict] = await Promise.all([
    page.waitForResponse(
      (response) =>
        response.request().method() === 'PUT' &&
        new URL(response.url()).pathname === '/api/masters/design-book',
    ),
    page.getByRole('button', { name: 'Save Design Book', exact: true }).click(),
  ]);
  assert.equal(conflict.status(), 409);
  await expectValue(page.getByLabel('Style design 1', { exact: true }), 'LOCAL UNSAVED');
  await page.getByRole('button', { name: 'Load', exact: true }).click();
  await expectValue(page.getByLabel('Style design 1', { exact: true }), 'OTHER SESSION');
  await page.getByTestId('entity-image-delete').click();
  await page.getByTestId('entity-image-empty').waitFor();
  await page.getByRole('button', { name: 'Delete Book', exact: true }).click();
  await page.getByRole('button', { name: 'Confirm Delete Book', exact: true }).click();
  await page
    .getByRole('status')
    .filter({ hasText: 'Deleted the selected book and its components.' })
    .waitFor();
  assert.deepEqual(await (await page.request.get(endpoint)).json(), []);
  return {
    checks: [
      'browser create/reload',
      'two components',
      'style and text page number',
      'unchanged edit',
      'saved image upload/read/delete',
      'changed component',
      'stale edit409 retains form',
      'browser deletion',
    ],
  };
}
try {
  const role = await runtime.$queryRawUnsafe(
    `SELECT rolsuper,rolbypassrls FROM pg_roles WHERE rolname=current_user`,
  );
  assert.deepEqual(role, [{ rolsuper: false, rolbypassrls: false }]);
  await seed();
  app = await buildApp({
    prisma: runtime,
    secret: randomBytes(32).toString('hex'),
    secureCookies: false,
    defaultTenantId: tenantId,
    allowTenantHeader: false,
  });
  await app.listen({ port: 4410, host: '127.0.0.1' });
  server = spawn(
    'pnpm',
    ['--filter', '@datacare/web', 'exec', 'next', 'start', '-p', '4411', '-H', '127.0.0.1'],
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
  for (let attempt = 0; attempt < 60; attempt++) {
    if (server.exitCode != null) throw new Error(`Next exited: ${serverLog}`);
    try {
      if ((await fetch(`${webOrigin}/login`)).ok) {
        ready = true;
        break;
      }
    } catch {}
    await wait(250);
  }
  assert(ready, 'Next startup timed out');
  // Chromium-generated video verifies the media pipeline without using the operator's physical camera.
  browser = await chromium.launch({
    headless: true,
    args: ['--use-fake-device-for-media-stream', '--use-fake-ui-for-media-stream'],
  });
  const context = await browser.newContext({
    baseURL: webOrigin,
    viewport: { width: 1600, height: 1000 },
  });
  let runnerInterceptionRegistrations = 0;
  const observeRouteRegistrations = (target) => {
    for (const method of ['route', 'routeFromHAR']) {
      const original = target[method]?.bind(target);
      if (!original) continue;
      target[method] = async (...args) => {
        runnerInterceptionRegistrations += 1;
        return original(...args);
      };
    }
  };
  observeRouteRegistrations(context);
  await context.grantPermissions(['camera'], { origin: webOrigin });
  const page = await context.newPage();
  observeRouteRegistrations(page);
  page.on('response', async (response) => {
    const url = new URL(response.url());
    if (!url.pathname.endsWith('/image/state')) return;
    try {
      const value = await response.json();
      result.imageObservations.push({
        path: url.pathname,
        query: url.search,
        status: response.status(),
        ...value,
        image: value.image
          ? {
              ...value.image,
              data: value.image.data ? `${value.image.data.length} base64 characters` : undefined,
            }
          : undefined,
      });
    } catch {
      /* A failed request is recorded by the journey's response assertion. */
    }
  });
  const errors = [];
  page.on('pageerror', (error) => errors.push(error.message));
  await page.goto('/login');
  await page.getByLabel('User', { exact: true }).fill('browser');
  await page.getByLabel('Password', { exact: true }).fill(password);
  await page.getByRole('button', { name: 'Sign In', exact: true }).click();
  await page.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
  await page.getByRole('button', { name: 'Open', exact: true }).click();
  await page.waitForURL('**/dashboard');
  result.designBook = await exerciseDesignBook(page);
  result.designCalculations = await exerciseDesignCalculation(page, { checkpoint });
  await seedDesignRepeat(sql);
  try {
    result.designRepeat = await exerciseDesignRepeat(page, { checkpoint });
  } finally {
    await cleanupDesignRepeat(sql);
  }
  await seedGenericImageConflict(sql);
  try {
    result.genericImageConflict = await exerciseGenericImageConflict(page, { checkpoint });
  } finally {
    await cleanupGenericImageConflict(sql);
  }
  await seedRepairImageConflict(sql);
  try {
    result.repairImageConflict = await exerciseRepairImageConflict(page, {
      checkpoint,
      holdRepairReads,
    });
  } finally {
    await cleanupRepairImageConflict(sql);
  }
  await seedSalesReturnSaved(sql);
  try {
    result.salesReturnSaved = await exerciseSalesReturnSaved(page, {
      checkpoint,
      snapshot: () => snapshotSalesReturnSaved(owner, tenantId),
      holdSalesReturnReads,
    });
  } finally {
    await cleanupSalesReturnSaved(sql);
  }
  result.tourOrder = await exerciseTourOrder(page, { checkpoint, owner, tenantId });
  result.creditNote = await exerciseCreditNote(page, { checkpoint });
  await seedCreditNoteEntry(sql);
  try {
    result.creditNoteEntry = await exerciseCreditNoteEntry(page, { checkpoint, owner, tenantId });
  } finally {
    await cleanupCreditNoteEntry(sql);
  }
  await seedEInvoiceEntry(sql);
  try {
    result.eInvoiceEntry = await exerciseEInvoiceEntry(page, { checkpoint, owner, tenantId });
  } finally {
    await cleanupEInvoiceEntry(sql);
  }
  await seedCashReceiptPayment(sql);
  try {
    result.cashReceiptPayment = await exerciseCashReceiptPayment(page, {
      checkpoint,
      owner,
      tenantId,
    });
  } finally {
    await cleanupCashReceiptPayment(sql);
  }
  await seedSaleAmountBasis(sql);
  try {
    result.saleAmountBasis = await exerciseSaleAmountBasis(page, { checkpoint, owner, tenantId });
  } finally {
    await cleanupSaleAmountBasis(sql);
  }
  await seedWholesaleRateCut(sql);
  try {
    result.wholesaleRateCut = await exerciseWholesaleRateCut(page, { checkpoint, owner, tenantId });
  } finally {
    await cleanupWholesaleRateCut(sql);
  }
  await seedSalesOrder(sql);
  await seedSalesOrderDesign(sql);
  result.salesOrderDesign = await exerciseSalesOrderDesign(page, { checkpoint, coBook: 'S41' });
  result.salesOrder = await exerciseSalesOrder(page, { checkpoint });
  await seedOrderImageJourney(sql);
  result.orderImages = await exerciseOrderImages(page, { checkpoint });
  result.imageConflict = await exerciseImageConflict(page, { checkpoint });
  await seedMfgLot(owner, tenantId);
  result.mfgLot = await exerciseMfgLot(page, { checkpoint });
  await seedColumnSettings(sql);
  try {
    result.columnSettings = await exerciseColumnSettings(page, { checkpoint, password, tenantId });
  } finally {
    await cleanupColumnSettings(sql);
  }
  await seedSalesReturnReplay(sql);
  try {
    result.salesReturnReplay = await exerciseSalesReturnReplay(page, {
      checkpoint,
      snapshot: () => snapshotSalesReturnReplay(owner, tenantId),
      holdSalesReturnReads,
      password,
      tenantId,
    });
  } finally {
    await cleanupSalesReturnReplay(sql);
  }
  await seedSalesReturnBillReplay(sql);
  try {
    result.salesReturnBillReplay = await exerciseSalesReturnBillReplay(page, {
      checkpoint,
      snapshot: () => snapshotSalesReturnBillReplay(owner, tenantId),
      touchTaxSetting: () =>
        sql('UPDATE "CO_SET" SET "TAX_ROF"="TAX_ROF" WHERE tenant_id=$1 AND "CO_CODE"=\'01\''),
      holdSalesReturnReads,
      password,
      tenantId,
    });
  } finally {
    await cleanupSalesReturnBillReplay(sql);
  }
  await seedSalesReturnLabourReplay(sql);
  try {
    result.salesReturnLabourReplay = await exerciseSalesReturnLabourReplay(page, {
      checkpoint,
      owner,
      tenantId,
      password,
      sql,
    });
  } finally {
    await cleanupSalesReturnLabourReplay(sql);
  }
  assert.deepEqual(errors, [], 'browser runtime errors');
  const journeySummaries = [];
  result.journeys = [
    ['cash-receipt-payment', result.cashReceiptPayment],
    ['column-settings', result.columnSettings],
    ['credit-note', result.creditNote],
    ['credit-note-entry', result.creditNoteEntry],
    ['e-invoice-entry', result.eInvoiceEntry],
    ['design-book', result.designBook],
    ['design-calculations', result.designCalculations],
    ['design-repeat', result.designRepeat],
    ['generic-image-conflict', result.genericImageConflict],
    ['image-conflict', result.imageConflict],
    ['manufacturing-lot', result.mfgLot],
    ['order-images', result.orderImages],
    ['repair-image-conflict', result.repairImageConflict],
    ['sale-amount-basis', result.saleAmountBasis],
    ['sales-order', result.salesOrder],
    ['sales-order-design', result.salesOrderDesign],
    ['sales-return-bill-replay', result.salesReturnBillReplay],
    ['sales-return-labour-replay', result.salesReturnLabourReplay],
    ['sales-return-replay', result.salesReturnReplay],
    ['sales-return-saved', result.salesReturnSaved],
    ['tour-order', result.tourOrder],
    ['wholesale-rate-cut', result.wholesaleRateCut],
  ].map(([journeyId, detail]) => {
    const summary = summarizeJourneyEvidence(journeyId, detail);
    journeySummaries.push(summary);
    return summary.journey;
  });
  const provenance = aggregateRealStackEvidence(journeySummaries, runnerInterceptionRegistrations);
  result.mockedRequests = provenance.mockedRequests;
  result.mockedResponses = provenance.mockedResponses;
  result.interceptionIndicators = provenance.interceptionIndicators;
  assert.deepEqual(provenance.problems, [], 'real browser journey provenance');
  assert.deepEqual(
    result.journeys.filter(({ status }) => status !== 'passed'),
    [],
    'real browser journey status',
  );
  result.status = 'passed';
  console.log(
    'PARITY_REAL_STACK_PASSED: real login, Design Book calculation/repeat, Sales design selection and lifecycle, Tour Order lifecycle, credit-note browse, E CRNT create/print/edit/reopen/delete and E INVOICE create/IRN/cancel/reopen/delete, cash receipt/payment/contra with configured books, sale amount basis, wholesale sale tag/stock/ledger lifecycle and header-only rate cut, saved order and generic/repair images with conflicts, saved incoming Return metadata, Setting lot sources, family-qualified column settings, saved incoming Return calculation, bill and resolved labour preview; zero mocked requests',
  );
} catch (error) {
  result.status = 'failed';
  result.error = error.message;
  result.failedFixtureImages = await owner.$queryRawUnsafe(
    `SELECT "ENTITY_TYPE","ENTITY_KEY","INSTANCE","IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE",octet_length("IMAGE_BYTES") AS "storedSize",encode("IMAGE_BYTES",'base64') AS "fixtureBytes" FROM "ENTITY_IMAGE" WHERE tenant_id=$1`,
    tenantId,
  );
  const page = browser?.contexts()[0]?.pages()[0];
  if (page) await checkpoint('failure', page).catch(() => {});
  throw error;
} finally {
  result.finishedAt = new Date().toISOString();
  writeFileSync(resolve(artifacts, 'result.json'), `${JSON.stringify(result, null, 2)}\n`);
  await browser?.close();
  if (server?.pid) {
    try {
      process.kill(-server.pid, 'SIGTERM');
    } catch {}
  }
  await app?.close();
  await cleanup();
  await runtime.$disconnect();
  await owner.$disconnect();
}
