import assert from 'node:assert/strict';
import { existsSync, mkdtempSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { spawn } from 'node:child_process';
import { chromium } from 'playwright';

const port = Number(process.env.BROWSER_TEST_PORT || 4111);
const origin = `http://127.0.0.1:${port}`;
const root = new URL('../../..', import.meta.url).pathname;

if (!existsSync(new URL('../.next/BUILD_ID', import.meta.url))) {
  throw new Error('browser smoke requires a production build; run pnpm build first');
}

const server = spawn(
  'pnpm',
  ['--filter', '@datacare/web', 'exec', 'next', 'start', '-p', String(port)],
  {
    cwd: root,
    env: { ...process.env, API_ORIGIN: 'http://127.0.0.1:49999' },
    detached: process.platform !== 'win32',
    stdio: ['ignore', 'pipe', 'pipe'],
  },
);
let serverLog = '';
server.stdout.on('data', (chunk) => (serverLog += chunk));
server.stderr.on('data', (chunk) => (serverLog += chunk));

const stopServer = () => {
  if (server.killed) return;
  try {
    if (process.platform === 'win32') server.kill('SIGTERM');
    else process.kill(-server.pid, 'SIGTERM');
  } catch {
    server.kill('SIGTERM');
  }
};

/**
 * Wait for a control to hold an expected value.
 *
 * `BookSelect` fills itself from `/context/books` after mount, so reading `inputValue()` immediately after
 * the heading appears is a race: the heading renders before the fetch resolves. This produced an
 * intermittent `actual: '' expected: 'TOP'`. Polling asserts the same thing without depending on timing.
 */
async function expectValue(locator, expected, what) {
  for (let i = 0; i < 60; i += 1) {
    if ((await locator.inputValue()) === expected) return;
    await new Promise((r) => setTimeout(r, 100));
  }
  assert.equal(await locator.inputValue(), expected, `${what} must become "${expected}"`);
}

/**
 * A book <select> fills its <option> list only after /context/books resolves. Reading the count the
 * instant the element attaches races that fetch and flakes as `1 !== 2` on slower CI runners. Poll
 * until the expected number of options is present, then assert, so a genuine wrong count still fails.
 */
async function expectOptionCount(locator, expected, what) {
  for (let i = 0; i < 60; i += 1) {
    if ((await locator.locator('option').count()) === expected) return;
    await new Promise((r) => setTimeout(r, 100));
  }
  assert.equal(
    await locator.locator('option').count(),
    expected,
    `${what} must have ${expected} options`,
  );
}

async function waitForServer() {
  for (let attempt = 0; attempt < 60; attempt += 1) {
    if (server.exitCode != null) throw new Error(`Next server exited early:\n${serverLog}`);
    try {
      const response = await fetch(`${origin}/login`);
      if (response.ok) return;
    } catch {
      // Server is still starting.
    }
    await new Promise((resolve) => setTimeout(resolve, 250));
  }
  throw new Error(`Next server did not become ready:\n${serverLog}`);
}

const json = (route, status, body) =>
  route.fulfill({
    status,
    contentType: 'application/json',
    body: JSON.stringify(body),
  });

let browser;
let page;
const pageErrors = [];
const consoleErrors = [];
const requestFailures = [];
let repairImageStored = null;
let repairImageRevision = 0;
const repairImageVersion = () => repairImageRevision.toString(16).padStart(64, '0');
let repairImageRequestBody = null;
let repairReceiptRequestBody = null;
let repairReceiptStored = null;
let repairReceiptReads = 0;
let physicalStockRequestBody = null;
let meltingRequestBody = null;
let salesEditPath = null;
let salesEditBody = null;
let salesDeletePath = null;
// Mock-only protocol compatibility. Business scope/fixtures below remain the same;
// this descriptor is not a real authenticated session or database observation.
let smokeContext = {
  sessionId: '11111111-1111-4111-8111-111111111111',
  contextEpoch: '1',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
};
const smokeLedgerContext = {
  version: 'server-session-ledger-context-v1',
  status: 'unknown',
  mode: null,
  reason: 'vendor-authority-unresolved',
};
const authJson = (route, status, body) =>
  route.fulfill({
    status,
    contentType: 'application/json',
    headers: { 'cache-control': 'no-store' },
    body: JSON.stringify(body),
  });
try {
  await waitForServer();
  browser = await chromium.launch({ headless: true });
  const context = await browser.newContext({ viewport: { width: 1440, height: 900 } });
  page = await context.newPage();
  // Focus is committed after React commits a grid row change; poll rather than asserting on the
  // same tick. The application deliberately retries focus across a few frames.
  const expectFocused = async (locator, label) => {
    for (let attempt = 0; attempt < 100; attempt += 1) {
      if (await locator.evaluate((element) => element === document.activeElement)) return;
      await page.waitForTimeout(50);
    }
    assert.fail(`expected ${label ?? 'element'} to hold focus`);
  };
  page.on('pageerror', (error) => pageErrors.push(error.message));
  page.on('console', (message) => {
    if (message.type() === 'error') consoleErrors.push(message.text());
  });
  page.on('requestfailed', (request) => {
    requestFailures.push({ url: request.url(), error: request.failure()?.errorText });
  });

  await page.route('**/api/**', async (route) => {
    const request = route.request();
    const path = new URL(request.url()).pathname.replace(/^\/api/, '');
    if (path === '/auth/login') {
      const input = request.postDataJSON();
      return input.password === 'correct-password'
        ? authJson(route, 200, {
            user: 'BROWSER',
            rights: { view: true, edit: true, delete: true, print: true },
            forcedReset: false,
            scope: { coCode: '01', lcCode: '01', coYear: '2024-2025' },
            context: smokeContext,
            ledgerContext: smokeLedgerContext,
          })
        : authJson(route, 401, { error: 'invalid-credentials' });
    }
    // The state route distinguishes an empty photo from a failed read and carries the CAS token.
    // This remains mock-only UI compatibility coverage; the real-stack journey proves database CAS.
    if (path === '/stock/tag-image/state' || path === '/masters/design-book/image/state')
      return json(route, 200, {
        version: '0'.repeat(64),
        canUpdate: true,
        canDelete: false,
        image: { state: 'absent' },
      });
    if (path === '/stock/tag-image') return json(route, 404, { error: 'tag-image-not-found' });
    if (path === '/stock/tag-image/list') return json(route, 200, { images: [] });
    if (path === '/auth/logout') return json(route, 200, { ok: true });
    if (path === '/auth/refresh')
      return authJson(route, 200, {
        refreshed: true,
        context: smokeContext,
        ledgerContext: smokeLedgerContext,
      });
    if (path === '/context/select') {
      const input = request.postDataJSON();
      // The existing smoke has one deliberate same-scope Open. Require the real
      // request shape, then model only that successful transition; no retry/CAS credit.
      assert.deepEqual(Object.keys(input).sort(), [
        'coCode',
        'coYear',
        'expectedContextEpoch',
        'lcCode',
        'selectionId',
      ]);
      assert.deepEqual(
        { coCode: input.coCode, lcCode: input.lcCode, coYear: input.coYear },
        { coCode: '01', lcCode: '01', coYear: '2024-2025' },
      );
      assert.equal(input.expectedContextEpoch, smokeContext.contextEpoch);
      assert.match(
        input.selectionId,
        /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/,
      );
      const headers = request.headers();
      assert.equal(headers['x-session-context-id'], smokeContext.sessionId);
      assert.equal(headers['x-session-context-epoch'], smokeContext.contextEpoch);
      smokeContext = {
        ...smokeContext,
        contextEpoch: (BigInt(smokeContext.contextEpoch) + 1n).toString(),
      };
      return authJson(route, 200, {
        coCode: '01',
        lcCode: '01',
        coYear: '2024-2025',
        scoped: true,
        replayed: false,
        context: smokeContext,
        ledgerContext: smokeLedgerContext,
      });
    }
    if (path === '/me')
      return authJson(route, 200, {
        user: 'BROWSER',
        context: smokeContext,
        ledgerContext: smokeLedgerContext,
        coCode: '01',
        lcCode: '01',
        coYear: '2024-2025',
        passwordResetRequired: false,
        rights: { view: true, edit: true, delete: true, print: true },
        allowedForms: null,
      });
    if (path === '/context/companies')
      return json(route, 200, [{ CO_CODE: '01', CO_NAME: 'Browser Test Company' }]);
    if (path === '/context/locations')
      return json(route, 200, [{ LC_CODE: '01', LC_NAME: 'Main' }]);
    if (path === '/context/years') return json(route, 200, [{ year: '2024-2025' }]);
    // GET /settings returns an object. An array from the generic list fallback has a callable
    // `.values` property; the settings hook would receive Array.prototype.values as React state.
    if (path === '/settings') return json(route, 200, { values: {} });
    if (path === '/context/books')
      return json(route, 200, [
        {
          CO_BOOK: 'SAL',
          BOOK_NAME: 'Sales',
          BOOK_SNAME: 'SALE',
          MAIN_BOOK: 'SALES',
        },
        {
          CO_BOOK: 'TOP',
          BOOK_NAME: 'Tag Opening',
          BOOK_SNAME: 'TGOP',
          MAIN_BOOK: 'TAG-OPENING',
        },
        {
          CO_BOOK: 'IOP',
          BOOK_NAME: 'Item Opening',
          BOOK_SNAME: 'IOPN',
          MAIN_BOOK: 'ITEM-OPENING',
        },
        {
          CO_BOOK: 'ILT',
          BOOK_NAME: 'Item Lot',
          BOOK_SNAME: 'ILOT',
          MAIN_BOOK: 'ITEM-LOT',
        },
        {
          CO_BOOK: 'PHS',
          BOOK_NAME: 'Physical Stock',
          BOOK_SNAME: 'PHYS',
          MAIN_BOOK: 'PHY STOCK',
        },
        {
          CO_BOOK: 'MLP',
          BOOK_NAME: 'Melting Process',
          BOOK_SNAME: 'MLT',
          MAIN_BOOK: 'MLT PRO',
        },
        {
          CO_BOOK: 'RCR',
          BOOK_NAME: 'Repair Received',
          BOOK_SNAME: 'RPR',
          MAIN_BOOK: 'CUSTREP RECEIPT',
        },
        {
          CO_BOOK: 'RKI',
          BOOK_NAME: 'Repair Karigar Issue',
          BOOK_SNAME: 'RKI',
          MAIN_BOOK: 'KRREP ISSUE',
        },
        {
          CO_BOOK: 'RKR',
          BOOK_NAME: 'Repair Karigar Receipt',
          BOOK_SNAME: 'RKR',
          MAIN_BOOK: 'KRREP RECEIPT',
        },
        {
          CO_BOOK: 'RCI',
          BOOK_NAME: 'Repair Customer Issue',
          BOOK_SNAME: 'RCI',
          MAIN_BOOK: 'CUSTREP ISSUE',
        },
      ]);
    if (path === '/rate')
      return json(route, 200, { fineGold: 7500, fineSilver: 95, date: '2024-04-10' });
    if (path.startsWith('/party/'))
      return json(route, 200, {
        acCode: 'WALKIN',
        name: 'Walk-in Customer',
        amount: 0,
        sign: 'Dr',
        gold: 0,
        silver: 0,
      });
    if (path.startsWith('/lookup/items'))
      return json(route, 200, [{ code: 'GOLD', name: 'Gold Ornament' }]);
    if (path.startsWith('/lookup/accounts'))
      return json(route, 200, [
        { code: 'CUST', name: 'Repair Customer' },
        { code: 'KAR', name: 'Repair Karigar' },
      ]);
    if (path.startsWith('/sales/') && request.method() === 'GET') {
      return json(route, 200, {
        voucherNo: '00001',
        vchDate: '2024-04-10',
        billNo: '00001',
        acCode: 'WALKIN',
        acName: 'Walk-in Customer',
        taxRatePct: 3,
        discountAmount: 0,
        interState: false,
        mainUser: 'BROWSER',
        hiddenVoucherNo: '00001',
        lines: [
          {
            itCode: 'GOLD',
            tagNo: 'TAG001',
            vchSrno: 1,
            pcs: 1,
            grossWt: 10,
            netWt: 10,
            touch: 100,
            rate: 100,
            metalAmount: 1000,
          },
        ],
        oldGold: [],
      });
    }
    if (path.startsWith('/sales/') && request.method() === 'PUT') {
      salesEditPath = path;
      salesEditBody = request.postDataJSON();
      return json(route, 200, {
        vchNo: 1,
        totals: {
          net: 1000,
          discount: 0,
          taxable: 1000,
          tax: 30,
          cgst: 15,
          sgst: 15,
          igst: 0,
          roundOff: 0,
          total: 1030,
        },
      });
    }
    if (path.startsWith('/sales/') && request.method() === 'DELETE') {
      salesDeletePath = path;
      return json(route, 200, { reversed: true });
    }
    if (path === '/sales' && request.method() === 'POST')
      return json(route, 200, {
        vchNo: 1,
        totals: {
          net: 0,
          discount: 0,
          taxable: 0,
          tax: 0,
          cgst: 0,
          sgst: 0,
          igst: 0,
          roundOff: 0,
          total: 0,
        },
      });
    if (path === '/stock/physical-list')
      return json(route, 200, [
        {
          tagNo: 'TAG001',
          vchSrno: 11,
          itCode: 'GOLD',
          itemName: 'Gold Ornament',
          designNo: 'D1',
          itmSize: 'M',
          tblCode: '001',
          pieces: 1,
          grossWt: 10,
          otherWt: 1,
          netWt: 9,
          touch: 90,
          labourAmount: 50,
          otherAmount: 10,
          mrp: 1500,
          karigarName: 'K1',
        },
      ]);
    if (path === '/stock/physical-stock' && request.method() === 'POST') {
      physicalStockRequestBody = request.postDataJSON();
      return json(route, 201, {
        voucherNo: '00001',
        hiddenVoucherNo: '00001',
        created: true,
        lines: physicalStockRequestBody.lines.length,
      });
    }
    if (path === '/melting' && request.method() === 'POST') {
      meltingRequestBody = request.postDataJSON();
      return json(route, 201, {
        voucherNo: '00001',
        hiddenVoucherNo: '00001',
        created: true,
        outLines: meltingRequestBody.outLines.length,
        resultLines: meltingRequestBody.resultLines.length,
        stockRows: 6,
      });
    }
    if (path === '/stock/physical-reconcile' && request.method() === 'POST')
      return json(route, 200, {
        bookCount: 2,
        countedCount: 1,
        matchedCount: 1,
        missingCount: 1,
        extraCount: 0,
        matched: ['TAG001|11'],
        missing: ['TAG002|12'],
        extra: [],
        detail: [
          {
            tagNo: 'TAG001',
            vchSrno: 11,
            status: 'matched',
            bookWt: 9,
            countedWt: null,
            diffWt: 0,
          },
          {
            tagNo: 'TAG002',
            vchSrno: 12,
            status: 'missing',
            bookWt: 8,
            countedWt: null,
            diffWt: -8,
          },
        ],
      });
    if (path === '/repair-receipts' && request.method() === 'POST') {
      repairReceiptRequestBody = request.postDataJSON();
      const input = repairReceiptRequestBody;
      // This is the existing one-row smoke fixture, not an alternative receipt calculation engine.
      assert.equal(input.lines.length, 1);
      assert.equal(input.lines[0].itCode, 'GOLD');
      const totals = {
        netAmount: 95,
        discountAmount: 0,
        taxAmount: 0,
        totalAmount: 95,
        outstandingAmount: 80,
      };
      repairReceiptStored = {
        voucherNo: '00001',
        headerVoucherNo: '00001',
        vchDate: input.vchDate,
        billNo: input.billNo || '',
        acCode: input.acCode,
        acName: input.acName || 'Repair Customer',
        employeeCode: input.employeeCode || '',
        bankName: input.bankName || '',
        description: input.description || '',
        chequeAmount: input.chequeAmount || 0,
        chequeAccount: input.chequeAccount || '',
        chequeNo: input.chequeNo || '',
        cardAmount: input.cardAmount || 0,
        cardAccount: input.cardAccount || '',
        cashAmount: input.cashAmount || 0,
        totals,
        lines: input.lines.map((line) => ({
          ...line,
          srNo: 1,
          itemName: 'Gold Ornament',
          netWt: 9,
          labourAmount: 90,
          netAmount: 95,
        })),
      };
      return json(route, 201, {
        vchNo: 1,
        voucherNo: '00001',
        headerVoucherNo: '00001',
        created: true,
        totals,
      });
    }
    if (path === '/repair-receipts/00001' && request.method() === 'GET') {
      if (!repairReceiptStored) return json(route, 404, { error: 'repair-receipt-not-found' });
      const query = new URL(request.url()).searchParams;
      for (const field of ['coCode', 'lcCode', 'coYear', 'coBook'])
        assert.equal(
          query.get(field),
          repairReceiptRequestBody[field],
          `Saved Repair read keeps ${field}`,
        );
      repairReceiptReads += 1;
      return json(route, 200, repairReceiptStored);
    }
    if (path === '/repair-karigar-issues/open-lines')
      return json(route, 200, [
        {
          code: '2024-2025/RCR/00001/1',
          name: 'Repair Customer · Gold Ornament',
          coYear: '2024-2025',
          coBook: 'RCR',
          voucherNo: '00001',
          srNo: 1,
          headerVoucherNo: '00001',
          vchDate: '2024-04-10',
          customerCode: 'CUST',
          customerName: 'Repair Customer',
          itCode: 'GOLD',
          itemName: 'Gold Ornament',
          description: 'Resize ring',
          itmSize: '12',
          tagNo: '',
          pieces: 1,
          grossWt: 10,
          otherWt: 1,
          netWt: 9,
          touch: 91.6,
          wastagePct: 0,
          fineWt: 0,
        },
      ]);
    if (path === '/repair-karigar-issues' && request.method() === 'POST')
      return json(route, 201, {
        vchNo: 1,
        voucherNo: '00001',
        headerVoucherNo: '00001',
        created: true,
        totals: {
          netAmount: 0,
          discountAmount: 0,
          taxAmount: 0,
          totalAmount: 0,
          outstandingAmount: 0,
        },
      });
    if (path === '/repair-karigar-receipts/open-lines')
      return json(route, 200, [
        {
          code: '2024-2025/RKI/00001/1',
          name: 'Repair Customer · Gold Ornament',
          coYear: '2024-2025',
          coBook: 'RKI',
          voucherNo: '00001',
          srNo: 1,
          headerVoucherNo: '00001',
          vchDate: '2024-04-11',
          karigarCode: 'KAR',
          karigarName: 'Repair Karigar',
          customerCode: 'CUST',
          customerName: 'Repair Customer',
          customerRepairNo: '00001',
          itCode: 'GOLD',
          itemName: 'Gold Ornament',
          itType: 'G',
          rateType: 'G',
          description: 'Resize ring',
          itmSize: '12',
          tagNo: '',
          vchSrNo: 0,
          pieces: 1,
          grossWt: 10,
          otherWt: 1,
          netWt: 9,
          touch: 91.6,
          wastagePct: 0,
          fineWt: 0,
        },
      ]);
    if (path === '/repair-karigar-receipts' && request.method() === 'POST')
      return json(route, 201, {
        vchNo: 1,
        voucherNo: '00001',
        headerVoucherNo: '00001',
        created: true,
        totals: {
          netAmount: 995,
          discountAmount: 9,
          taxAmount: 29.58,
          totalAmount: 1016,
          outstandingAmount: 1001,
        },
      });
    if (path === '/repair-customer-issues/open-lines')
      return json(route, 200, [
        {
          code: '2024-2025/RCR/00001/1',
          name: 'Gold Ornament · via Repair Karigar',
          coYear: '2024-2025',
          coBook: 'RCR',
          voucherNo: '00001',
          srNo: 1,
          headerVoucherNo: '00001',
          vchDate: '2024-04-10',
          customerCode: 'CUST',
          customerName: 'Repair Customer',
          karigarReceiptNo: '00001',
          karigarReceiptSrNo: 1,
          karigarCode: 'KAR',
          karigarName: 'Repair Karigar',
          itCode: 'GOLD',
          itemName: 'Gold Ornament',
          itType: 'G',
          rateType: 'G',
          description: 'Resize ring',
          itmSize: '12',
          tagNo: '',
          vchSrNo: 0,
          pieces: 1,
          grossWt: 10,
          otherWt: 1,
          netWt: 9,
          touch: 90,
          wastagePct: 0,
          fineWt: 9,
          addWt: 10,
          lessWt: 0,
          lessTouch: 0,
          lessFine: 0,
          rate: 0,
          labourAmount: 90,
          otherAmount: 0,
        },
      ]);
    if (path === '/repair-customer-issues' && request.method() === 'POST')
      return json(route, 201, {
        vchNo: 1,
        voucherNo: '00001',
        headerVoucherNo: '00001',
        created: true,
        totals: {
          netAmount: 1090,
          discountAmount: 0,
          taxAmount: 32.7,
          totalAmount: 1123,
          outstandingAmount: 623,
        },
      });
    if (path === '/repair-images/line')
      return repairImageStored
        ? json(route, 200, repairImageStored)
        : json(route, 404, { error: 'repair-image-not-found' });
    if (path === '/repair-images/state')
      return json(route, 200, {
        version: repairImageVersion(),
        canUpdate: true,
        canDelete: repairImageStored !== null,
        image: repairImageStored ? { state: 'present', ...repairImageStored } : { state: 'absent' },
      });
    if (path === '/repair-images' && request.method() === 'POST') {
      const payload = JSON.parse(request.postData() || '{}');
      assert.equal(
        payload.version,
        repairImageVersion(),
        'Repair upload uses the loaded image token',
      );
      repairImageRequestBody = payload;
      repairImageStored = {
        imageNo: `${payload.coCode}${payload.lcCode}${(payload.imageYear || payload.coYear).slice(0, 4)}${payload.imageBook}${payload.vchNo}${payload.srNo}`,
        imageType: 'ReparingImage',
        mimeType: payload.mimeType,
        size: Buffer.from(payload.data, 'base64').length,
        entryTime: '2024-04-10T00:00:00.000Z',
        data: payload.data,
      };
      repairImageRevision += 1;
      return json(route, 200, { imageNo: repairImageStored.imageNo, replaced: false });
    }
    if (path === '/repair-images' && request.method() === 'DELETE') {
      assert.equal(
        request.postDataJSON().version,
        repairImageVersion(),
        'Repair deletion uses the loaded image token',
      );
      repairImageStored = null;
      repairImageRevision += 1;
      return json(route, 200, { deleted: true });
    }
    if (path.startsWith('/reports/sales-register'))
      return json(route, 200, { rows: [{ voucher: '00001' }], totals: { totAmt: 1234 } });
    if (path.startsWith('/reports/trial-balance'))
      return json(route, 200, { balanced: true, grandDr: 1234 });
    return json(route, 200, []);
  });

  await page.goto(`${origin}/login`, { waitUntil: 'domcontentloaded' });
  assert.equal(await page.locator('h1').textContent(), 'DataCareNext');
  const inputs = page.locator('input');
  assert.equal(await inputs.count(), 3);
  await expectFocused(inputs.nth(0), 'inputs.nth(0)');
  await page.keyboard.press('Tab');
  await expectFocused(inputs.nth(1), 'inputs.nth(1)');
  await page.keyboard.press('Tab');
  await expectFocused(inputs.nth(2), 'inputs.nth(2)');

  await inputs.nth(1).fill('BROWSER');
  await inputs.nth(2).fill('wrong-password');
  await page.getByRole('button', { name: 'Sign In' }).click();
  await page.getByText('Invalid company / user / password').waitFor();

  await inputs.nth(2).fill('correct-password');
  await page.getByRole('button', { name: 'Sign In' }).click();
  await page.waitForURL('**/select');
  await page.getByRole('heading', { name: 'Open Company' }).waitFor();
  // These selects populate from a fetch AFTER the heading renders, so an immediate inputValue() read is a
  // race. They use page.locator rather than getByLabel, which is why the earlier sweep of value assertions
  // missed them — the race was a class, and this is the rest of it.
  await expectValue(await Promise.resolve(page.locator('select').nth(0)), '01', 'scope select');
  await expectValue(await Promise.resolve(page.locator('select').nth(1)), '01', 'scope select');
  await expectValue(
    await Promise.resolve(page.locator('select').nth(2)),
    '2024-2025',
    'scope select',
  );

  await page.getByRole('button', { name: 'Open' }).click();
  await page.waitForURL('**/dashboard');
  await page.getByRole('heading', { name: /Dashboard/ }).waitFor();
  await page.getByText('Balanced', { exact: true }).waitFor();
  await expectValue(page.getByLabel('Company'), '01', 'company');
  await expectValue(page.getByLabel('Location'), '01', 'location');
  await expectValue(page.getByLabel('Financial year'), '2024-2025', 'financial year');
  assert.match(await page.locator('body').innerText(), /BROWSER/);

  await page.goto(`${origin}/txn/sales`, { waitUntil: 'domcontentloaded' });
  await page.getByRole('heading', { name: 'Sales Invoice' }).waitFor();
  await page.getByRole('button', { name: 'F2: Ledger report' }).waitFor();

  // Desktop MDI global accelerators remain active on voucher pages.
  // The hint row is server-rendered. The configured book arrives from an effect-driven request,
  // so wait for it as evidence that the form has hydrated before dispatching a global key.
  const readyForFormKeys = async () => {
    await page.getByRole('button', { name: 'F2: Ledger report' }).waitFor();
    await expectValue(page.getByLabel('Configured book'), 'SAL', 'hydrated sales book');
  };
  await readyForFormKeys();
  await page.keyboard.press('F4');
  await page.waitForURL('**/txn/sales-order');
  await page.goto(`${origin}/txn/sales`, { waitUntil: 'domcontentloaded' });
  await readyForFormKeys();
  await page.keyboard.press('F7');
  await page.waitForURL('**/txn/purchase');
  await page.goto(`${origin}/txn/sales`, { waitUntil: 'domcontentloaded' });
  await readyForFormKeys();
  await page.keyboard.press('F11');
  // F11 is the Rojmel. It used to land on /reports/day-book, which reads AC_DATA and shows money only -
  // not the same report as the desktop's, which carries metal weights beside the money.
  await page.waitForURL('**/reports/rojmel');
  await page.goto(`${origin}/txn/sales`, { waitUntil: 'domcontentloaded' });
  await page.getByRole('heading', { name: 'Sales Invoice' }).waitFor();
  await page.getByLabel('Configured book').selectOption('SAL');
  const gridInput = (row, column) =>
    page.locator(`[data-grid-row="${row}"][data-grid-column="${column}"] input`).first();
  // Grid focus is committed after React mounts the appended/removed row, so poll instead of
  // asserting on the same tick (the app deliberately retries focus across a few frames).
  const expectGridFocus = async (row, column) => {
    await page.waitForFunction(
      ([r, c]) => {
        const cell = document.querySelector(`[data-grid-row="${r}"][data-grid-column="${c}"]`);
        return !!cell && !!document.activeElement && cell.contains(document.activeElement);
      },
      [row, column],
    );
  };
  const item = gridInput(0, 0);
  const tag = gridInput(0, 1);

  await item.focus();
  await page.keyboard.press('F1');
  await page.getByText('Gold Ornament').waitFor();
  await page.keyboard.press('Escape');
  await page.getByText('Gold Ornament').waitFor({ state: 'hidden' });
  await expectFocused(item, 'item');

  await item.press('End');
  await item.press('ArrowRight');
  await expectFocused(tag, 'tag');
  await page.keyboard.press('Escape');

  const pieces = gridInput(0, 2);
  const gross = gridInput(0, 3);
  await pieces.focus();
  await page.keyboard.press('Enter');
  await expectFocused(gross, 'gross');

  const otherAmount = gridInput(0, 12);
  await otherAmount.focus();
  await page.keyboard.press('Enter');
  const secondRowItem = gridInput(1, 0);
  await secondRowItem.waitFor();
  await expectGridFocus(1, 0);
  await page.keyboard.press('ArrowUp');
  await expectGridFocus(0, 0);
  await page.keyboard.press('ArrowDown');
  await expectGridFocus(1, 0);

  page.once('dialog', (dialog) => dialog.accept());
  await page.keyboard.press('Control+d');
  await secondRowItem.waitFor({ state: 'detached' });
  assert.equal((await page.locator('[data-grid-row="0"]').count()) > 0, true);

  // Desktop parity: full grid mode promotes the per-row panel fields into real, keyboard-navigable
  // cells, so the operator types every field inline as they do on the desktop. Exactly one control
  // per field must exist in either mode.
  const compactColumns = await page
    .locator('[data-testid="sales-items-grid"] tr')
    .first()
    .locator('td')
    .count();
  const bagWtLabel = 'Bag Wt row 1';
  assert.equal(
    await page.getByLabel(bagWtLabel).count(),
    0,
    'bag wt must not be a cell in compact mode',
  );
  await page.getByTestId('sales-grid-mode').click();
  const fullColumns = await page
    .locator('[data-testid="sales-items-grid"] tr')
    .first()
    .locator('td')
    .count();
  assert.equal(
    fullColumns > compactColumns,
    true,
    `full grid must add columns (${compactColumns} -> ${fullColumns})`,
  );
  const bagWt = page.getByLabel(bagWtLabel);
  assert.equal(await bagWt.count(), 1, 'bag wt must have exactly one control in full mode');
  await bagWt.fill('1.25');
  await bagWt.press('ArrowUp');
  assert.equal(await bagWt.inputValue(), '1.25', 'value must survive keyboard navigation');
  await page.getByTestId('sales-grid-mode').click();
  assert.equal(
    await page.locator('[data-testid="sales-items-grid"] tr').first().locator('td').count(),
    compactColumns,
    'compact mode must restore the original column count',
  );

  // A pending append retry must not steal a deliberate move to another cell in the same grid.
  await page.evaluate(() => {
    const appendFrom = document.querySelector('[data-grid-row="0"][data-grid-column="12"] input');
    const deliberateTarget = document.querySelector(
      '[data-grid-row="0"][data-grid-column="2"] input',
    );
    appendFrom.focus();
    appendFrom.dispatchEvent(
      new KeyboardEvent('keydown', { key: 'Enter', bubbles: true, cancelable: true }),
    );
    deliberateTarget.focus();
  });
  const raceSecondRowItem = gridInput(1, 0);
  await raceSecondRowItem.waitFor();
  await page.evaluate(
    () => new Promise((resolve) => requestAnimationFrame(() => requestAnimationFrame(resolve))),
  );
  await expectFocused(pieces, 'pieces');
  await raceSecondRowItem.focus();
  page.once('dialog', (dialog) => dialog.accept());
  await page.keyboard.press('Control+d');
  await raceSecondRowItem.waitFor({ state: 'detached' });

  await pieces.focus();
  await page.keyboard.press('Escape');
  const cash = page.getByTestId('sales-cash');
  await expectFocused(cash, 'cash');
  await page.keyboard.press('Control+Enter');
  await page.getByText('Saved — Voucher #1').waitFor();

  // Desktop TR_SALE lifecycle: open the saved voucher by number, edit it in place, then delete it.
  await page.getByLabel('Voucher No').fill('00001');
  await page.getByRole('button', { name: 'Load', exact: true }).click();
  await page.getByTestId('sales-loaded').waitFor();
  assert.match(await page.getByTestId('sales-loaded').textContent(), /00001/);
  await page.getByRole('button', { name: 'Update Invoice' }).click();
  await page.waitForFunction(() => true);
  await page.getByText('Saved — Voucher #1').waitFor();
  assert.equal(salesEditPath, '/sales/00001');
  assert.equal(Array.isArray(salesEditBody?.lines), true);
  page.once('dialog', (dialog) => dialog.accept());
  await page.getByRole('button', { name: 'Delete', exact: true }).click();
  await page.getByTestId('sales-loaded').waitFor({ state: 'detached' });
  assert.equal(salesDeletePath, '/sales/00001');

  // New stock pages retain accessible control names and the shared desktop grid keys.
  await page.goto(`${origin}/txn/tag-opening`, { waitUntil: 'domcontentloaded' });
  await page.getByRole('heading', { name: /Tag Opening Balance/ }).waitFor();
  await expectValue(page.getByLabel('Configured book'), 'TOP', 'configured book');
  await page.getByLabel('Date').waitFor();
  for (const label of [
    'Tag no row 1',
    'Item code row 1',
    'Tag opening tblCode row 1',
    'Tag opening designNo row 1',
    'Tag opening itmSize row 1',
    'Tag opening pcs row 1',
    'Tag opening grossWt row 1',
    'Tag opening lessWt row 1',
    'Tag opening netWt row 1',
    'Tag opening touch row 1',
    'Tag opening lbrPct row 1',
    'Tag opening lbrRate row 1',
    'Tag opening othAmt row 1',
    'Tag opening mrp row 1',
    'Remove tag row 1',
  ])
    await page.getByLabel(label).waitFor();
  await page.getByLabel('Tag opening pcs row 1').focus();
  await page.keyboard.press('Enter');
  assert.equal(
    await page
      .getByLabel('Tag opening grossWt row 1')
      .evaluate((element) => element === document.activeElement),
    true,
  );
  await page.getByLabel('Tag opening mrp row 1').press('Enter');
  await page.getByLabel('Tag no row 2').waitFor();
  page.once('dialog', (dialog) => dialog.accept());
  await page.keyboard.press('Control+d');
  await page.getByLabel('Tag no row 2').waitFor({ state: 'detached' });
  await page.getByLabel('Tag opening pcs row 1').focus();
  await page.keyboard.press('Escape');
  assert.equal(
    await page
      .getByRole('button', { name: 'Load Opening Stock' })
      .evaluate((element) => element === document.activeElement),
    true,
  );

  await page.goto(`${origin}/txn/item-opening`, { waitUntil: 'domcontentloaded' });
  await page.getByRole('heading', { name: /Item Opening Balance/ }).waitFor();
  await expectValue(page.getByLabel('Configured book'), 'IOP', 'configured book');
  await page.getByLabel('Date').waitFor();
  for (const label of [
    'Item code row 1',
    'Item opening pcs row 1',
    'Item opening grossWt row 1',
    'Item opening netWt row 1',
    'Item opening touch row 1',
    'Item opening rate row 1',
    'Remove item row 1',
  ])
    await page.getByLabel(label).waitFor();
  await page.getByLabel('Item opening pcs row 1').press('Enter');
  assert.equal(
    await page
      .getByLabel('Item opening grossWt row 1')
      .evaluate((element) => element === document.activeElement),
    true,
  );
  await page.getByLabel('Item opening rate row 1').press('Enter');
  await page.getByLabel('Item code row 2').waitFor();
  page.once('dialog', (dialog) => dialog.accept());
  await page.keyboard.press('Control+d');
  await page.getByLabel('Item code row 2').waitFor({ state: 'detached' });
  await page.getByLabel('Item opening pcs row 1').focus();
  await page.keyboard.press('Escape');
  assert.equal(
    await page
      .getByRole('button', { name: 'Post Opening' })
      .evaluate((element) => element === document.activeElement),
    true,
  );

  await page.goto(`${origin}/txn/item-lot`, { waitUntil: 'domcontentloaded' });
  await page.getByRole('heading', { name: /Item Lot Intake/ }).waitFor();
  await expectValue(page.getByLabel('Configured book'), 'ILT', 'configured book');
  await page.getByLabel('Date').waitFor();
  await page.getByLabel('Account').waitFor();
  for (const label of [
    'Item code row 1',
    'Item lot lotNo row 1',
    'Item lot designNo row 1',
    'Item lot itmSize row 1',
    'Item lot pcs row 1',
    'Item lot grossWt row 1',
    'Item lot netWt row 1',
    'Item lot touch row 1',
    'Item lot westPct row 1',
    'Item lot rate row 1',
    'Item lot making row 1',
    'Remove lot row 1',
  ])
    await page.getByLabel(label).waitFor();
  await page.getByLabel('Item lot pcs row 1').press('Enter');
  assert.equal(
    await page
      .getByLabel('Item lot grossWt row 1')
      .evaluate((element) => element === document.activeElement),
    true,
  );
  await page.getByLabel('Item lot making row 1').press('Enter');
  await page.getByLabel('Item code row 2').waitFor();
  page.once('dialog', (dialog) => dialog.accept());
  await page.keyboard.press('Control+d');
  await page.getByLabel('Item code row 2').waitFor({ state: 'detached' });
  await page.getByLabel('Item lot pcs row 1').focus();
  await page.keyboard.press('Escape');
  assert.equal(
    await page
      .getByRole('button', { name: 'Post Lot Intake' })
      .evaluate((element) => element === document.activeElement),
    true,
  );

  await page.goto(`${origin}/txn/repair-receipt`, { waitUntil: 'domcontentloaded' });
  await page.getByRole('heading', { name: 'Repairing Received — Customer Receipt' }).waitFor();
  const repairBook = page.getByLabel('Configured book');
  await repairBook.waitFor();
  await expectOptionCount(repairBook, 2, 'customer-receipt configured book');
  await expectValue(repairBook, 'RCR', 'configured book');

  const repairParty = page.getByTestId('repair-party').locator('input');
  await repairParty.focus();
  await page.keyboard.press('F1');
  await page.getByTestId('repair-party').getByText('Repair Customer').waitFor();
  await page.keyboard.press('Enter');
  assert.equal(await repairParty.inputValue(), 'CUST');

  const repairGridInput = (row, column) =>
    page.locator(`[data-grid-row="${row}"][data-grid-column="${column}"] input`).first();
  const repairItem = repairGridInput(0, 0);
  await repairItem.focus();
  await page.keyboard.press('F1');
  await page.getByText('Gold Ornament').waitFor();
  await page.keyboard.press('Enter');
  await repairGridInput(0, 2).fill('Resize ring');
  await repairGridInput(0, 4).fill('10');
  await repairGridInput(0, 5).fill('1');
  await repairGridInput(0, 8).fill('10');
  const repairOther = repairGridInput(0, 9);
  await repairOther.fill('5');
  assert.equal((await page.getByTestId('repair-net-0').textContent()).trim(), '9.000');
  assert.match((await page.getByTestId('repair-estimate').textContent()).trim(), /95/);

  await repairOther.press('Enter');
  const secondRepairItem = repairGridInput(1, 0);
  await secondRepairItem.waitFor();
  await expectFocused(secondRepairItem, 'secondRepairItem');
  page.once('dialog', (dialog) => dialog.accept());
  await page.keyboard.press('Control+d');
  await secondRepairItem.waitFor({ state: 'detached' });

  const repairGross = repairGridInput(0, 4);
  // Let the Ctrl+D post-render focus restoration settle before testing Escape traversal.
  await page.evaluate(
    () => new Promise((resolve) => requestAnimationFrame(() => requestAnimationFrame(resolve))),
  );
  await repairGross.focus();
  await expectFocused(repairGross, 'repairGross');
  await page.keyboard.press('Escape');
  const repairCheque = page.getByTestId('repair-cheque');
  await repairCheque.waitFor();
  await page.waitForFunction(
    () => document.activeElement?.getAttribute('data-testid') === 'repair-cheque',
  );
  const repairCash = page.getByTestId('repair-cash');
  await repairCash.fill('15');
  await repairCash.press('Control+Enter');
  await page.getByTestId('repair-saved').waitFor();
  assert.match(await page.getByTestId('repair-saved').textContent(), /00001/);

  // Repair-line image attachment: empty before upload and previewed after save.
  await page.getByTestId('repair-image-empty').waitFor();
  assert.equal(
    repairReceiptReads,
    1,
    'Images activate only after the authoritative saved receipt read',
  );
  assert.equal(repairReceiptStored.lines[0].srNo, 1);
  assert.equal(await repairGridInput(0, 0).inputValue(), repairReceiptRequestBody.lines[0].itCode);

  // Device parity: the camera control must be present and must report an honest status. Headless
  // Chromium has no granted camera. Check its reported state and hidden preview without fake capture.
  await page.getByTestId('repair-image-camera-status').waitFor();
  const cameraStatus = (await page.getByTestId('repair-image-camera-status').textContent()) ?? '';
  assert.equal(
    /idle|unsupported|denied|error/.test(cameraStatus),
    true,
    `camera must report an honest status without hardware, got "${cameraStatus}"`,
  );
  assert.equal(/live/.test(cameraStatus), false, 'camera must never report live without a stream');
  assert.equal(await page.getByTestId('repair-image-camera-start').isVisible(), true);
  if (/unsupported/.test(cameraStatus))
    assert.equal(await page.getByTestId('repair-image-camera-start').isDisabled(), true);
  // The preview element exists but stays hidden until a stream is actually granted.
  assert.equal(await page.getByTestId('repair-image-camera-preview').isVisible(), false);
  await page.locator('#repair-image-file').setInputFiles({
    name: 'repair.png',
    mimeType: 'image/png',
    buffer: Buffer.from(
      'iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP4/x8AAwAB/2+Bq7YAAAAASUVORK5CYII=',
      'base64',
    ),
  });
  await page.getByTestId('repair-image-preview').waitFor();
  assert.equal(repairImageRequestBody.coBook, 'RCR');
  assert.equal(repairImageRequestBody.imageBook, 'RCR');
  assert.equal(repairImageRequestBody.srNo, 1);

  await page.goto(`${origin}/txn/repair-karigar-issue`, { waitUntil: 'domcontentloaded' });
  await page.getByRole('heading', { name: 'Repairing Issued — Karigar Issue' }).waitFor();
  const issueBook = page.getByLabel('Configured book');
  await issueBook.waitFor();
  await expectOptionCount(issueBook, 2, 'repair karigar issue configured book');
  await expectValue(issueBook, 'RKI', 'configured book');

  const issueParty = page.getByTestId('repair-issue-party').locator('input');
  await issueParty.focus();
  await page.keyboard.press('F1');
  await page.getByTestId('repair-issue-party').getByText('Repair Karigar').waitFor();
  await page.keyboard.press('ArrowDown');
  await page.keyboard.press('Enter');
  assert.equal(await issueParty.inputValue(), 'KAR');

  const issueGridInput = (row, column) =>
    page.locator(`[data-grid-row="${row}"][data-grid-column="${column}"] input`).first();
  const issueSource = issueGridInput(0, 0);
  await issueSource.focus();
  await page.keyboard.press('F1');
  await page.getByText('Repair Customer · Gold Ornament').waitFor();
  await page.keyboard.press('Enter');
  assert.equal(await issueSource.inputValue(), '2024-2025/RCR/00001/1');
  assert.equal((await page.getByTestId('repair-issue-net-0').textContent()).trim(), '9.000');
  // The R1 image follows its source customer repair row into KRREP ISSUE.
  await page.getByTestId('repair-issue-image-preview').waitFor();
  page.once('dialog', (dialog) => dialog.accept());
  await page.getByRole('button', { name: 'Delete image' }).click();
  await page.getByTestId('repair-issue-image-empty').waitFor();

  await issueSource.focus();
  await page.getByText('Repair Customer · Gold Ornament').waitFor();
  await page.keyboard.press('Escape');
  await page.getByText('Repair Customer · Gold Ornament').waitFor({ state: 'hidden' });
  await page.keyboard.press('Enter');
  const secondIssueSource = issueGridInput(1, 0);
  await secondIssueSource.waitFor();
  await expectFocused(secondIssueSource, 'secondIssueSource');
  await page.keyboard.press('ArrowUp');
  await expectFocused(issueSource, 'issueSource');
  await page.keyboard.press('ArrowDown');
  await expectFocused(secondIssueSource, 'secondIssueSource');
  page.once('dialog', (dialog) => dialog.accept());
  await page.keyboard.press('Control+d');
  await secondIssueSource.waitFor({ state: 'detached' });

  await issueSource.focus();
  await page.getByText('Repair Customer · Gold Ornament').waitFor();
  await page.keyboard.press('Escape');
  await page.getByText('Repair Customer · Gold Ornament').waitFor({ state: 'hidden' });
  await page.keyboard.press('Escape');
  const issueCheque = page.getByTestId('repair-issue-cheque');
  await expectFocused(issueCheque, 'issueCheque');
  const issueCash = page.getByTestId('repair-issue-cash');
  await issueCash.fill('15');
  assert.match((await page.getByTestId('repair-issue-paid').textContent()).trim(), /15/);
  await issueCash.press('Control+Enter');
  await page.getByTestId('repair-issue-saved').waitFor();
  assert.match(await page.getByTestId('repair-issue-saved').textContent(), /00001/);

  await page.goto(`${origin}/txn/repair-karigar-receipt`, { waitUntil: 'domcontentloaded' });
  await page.getByRole('heading', { name: 'Repairing Received — Karigar Receipt' }).waitFor();
  const krRecBook = page.getByLabel('Configured book');
  await krRecBook.waitFor();
  await expectOptionCount(krRecBook, 2, 'repair karigar receipt configured book');
  await expectValue(krRecBook, 'RKR', 'configured book');

  const krRecParty = page.getByTestId('repair-krrec-party').locator('input');
  await krRecParty.focus();
  await page.keyboard.press('F1');
  await page.getByTestId('repair-krrec-party').getByText('Repair Karigar').waitFor();
  await page.keyboard.press('ArrowDown');
  await page.keyboard.press('Enter');
  assert.equal(await krRecParty.inputValue(), 'KAR');

  const krRecInput = (row, column) =>
    page.locator(`[data-grid-row="${row}"][data-grid-column="${column}"] input`).first();
  const krRecSource = krRecInput(0, 0);
  await krRecSource.focus();
  await page.keyboard.press('F1');
  await page.getByText('Repair Customer · Gold Ornament').waitFor();
  await page.keyboard.press('Enter');
  assert.equal(await krRecSource.inputValue(), '2024-2025/RKI/00001/1');

  await krRecInput(0, 1).fill('10');
  await krRecInput(0, 2).fill('90');
  await krRecInput(0, 3).fill('100');
  await krRecInput(0, 4).fill('N');
  await krRecInput(0, 5).fill('10');
  const krRecOther = krRecInput(0, 6);
  await krRecOther.fill('5');
  assert.equal((await page.getByTestId('repair-krrec-fine-0').textContent()).trim(), '9.000');
  assert.equal((await page.getByTestId('repair-krrec-net-0').textContent()).trim(), '995.00');
  assert.equal((await page.getByTestId('repair-krrec-detail-net').textContent()).trim(), '995.00');

  await krRecOther.press('Enter');
  const secondKrRecSource = krRecInput(1, 0);
  await secondKrRecSource.waitFor();
  await expectFocused(secondKrRecSource, 'secondKrRecSource');
  await page.keyboard.press('ArrowUp');
  await expectFocused(krRecSource, 'krRecSource');
  await page.keyboard.press('ArrowDown');
  await expectFocused(secondKrRecSource, 'secondKrRecSource');
  page.once('dialog', (dialog) => dialog.accept());
  await page.keyboard.press('Control+d');
  await secondKrRecSource.waitFor({ state: 'detached' });

  await krRecInput(0, 1).focus();
  await page.keyboard.press('Escape');
  const krRecCheque = page.getByTestId('repair-krrec-cheque');
  await krRecCheque.waitFor();
  await page.waitForFunction(
    () => document.activeElement?.getAttribute('data-testid') === 'repair-krrec-cheque',
  );
  await page.getByTestId('repair-krrec-discount').fill('10');
  const krRecCash = page.getByTestId('repair-krrec-cash');
  await krRecCash.fill('15');
  assert.match((await page.getByTestId('repair-krrec-paid').textContent()).trim(), /15/);
  await krRecCash.press('Control+Enter');
  await page.getByTestId('repair-krrec-saved').waitFor();
  const krRecSaved = await page.getByTestId('repair-krrec-saved').textContent();
  assert.match(krRecSaved, /00001/);
  assert.match(krRecSaved, /1,016/);

  await page.goto(`${origin}/txn/repair-customer-issue`, { waitUntil: 'domcontentloaded' });
  await page.getByRole('heading', { name: 'Repairing Delivered — Customer Issue' }).waitFor();
  const custIsuBook = page.getByLabel('Configured book');
  await custIsuBook.waitFor();
  await expectOptionCount(custIsuBook, 2, 'repair customer issue configured book');
  await expectValue(custIsuBook, 'RCI', 'configured book');

  const custIsuParty = page.getByTestId('repair-custisu-party').locator('input');
  await custIsuParty.focus();
  await page.keyboard.press('F1');
  await page.getByTestId('repair-custisu-party').getByText('Repair Customer').waitFor();
  await page.keyboard.press('Enter');
  assert.equal(await custIsuParty.inputValue(), 'CUST');

  const custIsuInput = (row, column) =>
    page.locator(`[data-grid-row="${row}"][data-grid-column="${column}"] input`).first();
  const custIsuSource = custIsuInput(0, 0);
  await custIsuSource.focus();
  await page.keyboard.press('F1');
  await page.getByText('Gold Ornament · via Repair Karigar').waitFor();
  await page.keyboard.press('Enter');
  assert.equal(await custIsuSource.inputValue(), '2024-2025/RCR/00001/1');
  // Add weight, labour amount and karigar linkage arrive from the karigar receipt.
  assert.equal(await custIsuInput(0, 1).inputValue(), '10');
  assert.equal((await page.getByTestId('repair-custisu-fine-0').textContent()).trim(), '9.000');
  assert.equal((await page.getByTestId('repair-custisu-net-0').textContent()).trim(), '90.00');

  await custIsuInput(0, 3).fill('100');
  assert.equal((await page.getByTestId('repair-custisu-net-0').textContent()).trim(), '1090.00');
  assert.equal(
    (await page.getByTestId('repair-custisu-detail-net').textContent()).trim(),
    '1090.00',
  );

  const custIsuOther = custIsuInput(0, 5);
  await custIsuOther.focus();
  await page.keyboard.press('Enter');
  const secondCustIsuSource = custIsuInput(1, 0);
  await secondCustIsuSource.waitFor();
  await expectFocused(secondCustIsuSource, 'secondCustIsuSource');
  page.once('dialog', (dialog) => dialog.accept());
  await page.keyboard.press('Control+d');
  await secondCustIsuSource.waitFor({ state: 'detached' });

  await custIsuInput(0, 1).focus();
  await page.keyboard.press('Escape');
  const custIsuCheque = page.getByTestId('repair-custisu-cheque');
  await expectFocused(custIsuCheque, 'custIsuCheque');
  const custIsuCash = page.getByTestId('repair-custisu-cash');
  await custIsuCash.fill('500');
  assert.match((await page.getByTestId('repair-custisu-received').textContent()).trim(), /500/);
  await custIsuCash.press('Control+Enter');
  await page.getByTestId('repair-custisu-saved').waitFor();
  const custIsuSaved = await page.getByTestId('repair-custisu-saved').textContent();
  assert.match(custIsuSaved, /00001/);
  assert.match(custIsuSaved, /1,123/);

  // Desktop MLT PRO uses separate material-out and melting-result grids.
  await page.goto(`${origin}/txn/melting`, { waitUntil: 'domcontentloaded' });
  await page.getByRole('heading', { name: 'Melting Process — MLT PRO' }).waitFor();
  const meltingBook = page.getByLabel('Configured book');
  await meltingBook.waitFor();
  await expectValue(meltingBook, 'MLP', 'configured book');
  await page.getByLabel('Lot no.').fill('LOT001');
  await page.getByLabel('Party account').fill('PARTY');
  await page.getByLabel('Material itCode 1').fill('SCRAP');
  await page.getByLabel('Material grossWt 1').fill('100');
  await page.getByLabel('Material touch 1').fill('80');
  assert.equal((await page.getByTestId('melting-out-net-0').textContent()).trim(), '100.000');
  assert.equal((await page.getByTestId('melting-out-fine-0').textContent()).trim(), '80.000');
  await page.getByLabel('Result itCode 1').fill('MELT');
  await page.getByLabel('Result grossWt 1').fill('100');
  await page.getByLabel('Result touch 1').fill('80');
  await page.getByLabel('Result conversion percent 1').fill('90');
  await page.getByLabel('Result conversion item 1').fill('FINE');
  await page.getByLabel('Result return weight 1').fill('10');
  await page.getByLabel('Result return item 1').fill('RTN');
  assert.equal((await page.getByTestId('melting-result-melt-0').textContent()).trim(), '200.000');
  assert.equal((await page.getByTestId('melting-result-loss-0').textContent()).trim(), '0.000');
  await page.getByRole('button', { name: 'Save', exact: true }).click();
  await page.getByTestId('melting-saved').waitFor();
  assert.equal(meltingRequestBody.coBook, 'MLP');
  assert.equal(meltingRequestBody.outLines[0].itCode, 'SCRAP');
  assert.equal(meltingRequestBody.resultLines[0].returnItCode, 'RTN');

  // Persist a desktop-style physical-count voucher without posting a stock movement.
  await page.goto(`${origin}/txn/physical-stock`, { waitUntil: 'domcontentloaded' });
  await page.getByRole('heading', { name: 'Physical Stock' }).waitFor();
  const physicalBook = page.getByLabel('Configured book');
  await physicalBook.waitFor();
  await expectValue(physicalBook, 'PHS', 'configured book');
  await page.getByRole('button', { name: 'Load in-stock' }).click();
  await page.getByText('Gold Ornament').waitFor();
  const physicalScan = page.getByTestId('physical-stock-scan');
  await physicalScan.fill('TAG001');
  await physicalScan.press('Enter');
  assert.equal(await page.getByLabel('Count tag TAG001').isChecked(), true);
  await page.getByRole('button', { name: 'Save', exact: true }).click();
  await page.getByTestId('physical-stock-saved').waitFor();
  assert.equal(physicalStockRequestBody.coBook, 'PHS');
  assert.deepEqual(physicalStockRequestBody.lines, [{ tagNo: 'TAG001', vchSrno: 11 }]);
  await page.getByRole('button', { name: 'Variance report' }).click();
  await page.getByText('TAG002').waitFor();
  assert.match(await page.getByText('Saved physical count').textContent(), /00001/);

  // Device parity: the scale control must appear and must NOT claim a connection when no hardware and no
  // WebSerial are present. Headless Chromium has no navigator.serial, so this asserts the honest path.
  await page.goto(`${origin}/txn/tag-opening`, { waitUntil: 'domcontentloaded' });
  await page.getByTestId('scale-status').waitFor();
  const scaleStatus = (await page.getByTestId('scale-status').textContent()) ?? '';
  assert.equal(
    /disabled|unsupported|idle/.test(scaleStatus),
    true,
    `scale must report an honest status without hardware, got "${scaleStatus}"`,
  );
  assert.equal(
    /reading/.test(scaleStatus),
    false,
    'scale must never report reading without a granted port',
  );
  // ---- Tag image panel (desktop BtnImgS / BtnImgC / BtnImgD) ----
  // 24 desktop forms carry these buttons and the web had none outside repair. The panel follows the focused
  // grid row, exactly as the desktop's image buttons act on the current row.
  await page.goto(`${origin}/txn/tag-opening`, { waitUntil: 'domcontentloaded' });
  await page.waitForTimeout(300);
  assert.equal(
    await page.getByTestId('tag-opening-image').count(),
    1,
    'tag-opening must expose the tag image panel',
  );
  await page.getByLabel('Tag no row 1').fill('SMOKETAG');
  await page.waitForTimeout(400);
  assert.match(
    (await page.getByTestId('tag-opening-image-tag').innerText()).trim(),
    /SMOKETAG/,
    'the image panel must follow the focused tag row',
  );
  // Delete must be inert while no image exists, and the camera must report an honest status.
  assert.equal(
    await page.getByTestId('tag-opening-image-delete').isDisabled(),
    true,
    'delete must be disabled when the tag has no image',
  );
  const tagCameraStatus = (
    await page.getByTestId('tag-opening-image-camera-status').innerText()
  ).trim();
  assert.equal(
    /live/.test(tagCameraStatus),
    false,
    `tag image camera must never claim to be live without a granted device, got "${tagCameraStatus}"`,
  );

  // ---- Desktop MDI accelerators are GLOBAL, not per-page ----
  // The desktop binds these in MDI_FORM.cs (the shell), so they work from anywhere. The web previously
  // mounted them on 13 transaction pages only, and discarded every Ctrl press outright, so all eight
  // desktop chords did nothing. Both facts are asserted here.
  const ctrlChord = async (key, expectedPath) => {
    await page.goto(`${origin}/dashboard`, { waitUntil: 'domcontentloaded' });
    await page.getByRole('button', { name: 'Logout' }).waitFor();
    await page.keyboard.down('Control');
    await page.keyboard.press(key);
    await page.keyboard.up('Control');
    // Route rendering may outlast a fixed delay on a loaded workstation. Wait
    // for this single key press to reach its exact destination; never re-press it.
    await page.waitForURL((url) => url.pathname === expectedPath, { timeout: 10000 });
    assert.equal(
      new URL(page.url()).pathname,
      expectedPath,
      `Ctrl+${key} must open ${expectedPath}`,
    );
  };
  await ctrlChord('F1', '/txn/daily-rate'); // F1CtrlDailyRate -> MS_RATE
  await ctrlChord('F5', '/txn/bill-to-bill'); // ShoCtrlF5BillRec -> TR_BILL_TO
  await ctrlChord('F6', '/txn/rate-cut'); // ShoCtrlF6RateCut -> TR_WH_SALE on a RATE CUT book
  await ctrlChord('F11', '/reports/cash-book'); // F11CtrlCashBank -> RP_CASH_BANK
  // These two were unmapped until their report families existed (MDI_FORM.cs:7147, :8994).
  await ctrlChord('F2', '/reports/order-lot-zoom'); // F2CtrlOrderZoom -> RP_ORDER
  await ctrlChord('F12', '/reports/tag-estimate'); // ShoCtrlF12TagEstmate -> RP_TAG_ESTMATE

  // A plain F-key must work away from the transaction pages too.
  await page.goto(`${origin}/masters/accounts`, { waitUntil: 'domcontentloaded' });
  await page.getByRole('button', { name: 'Logout' }).waitFor();
  await page.keyboard.press('F5');
  await page.waitForURL((url) => url.pathname === '/txn/sales', { timeout: 10000 });
  assert.equal(
    new URL(page.url()).pathname,
    '/txn/sales',
    'plain F5 must work from a master page, not only from transaction pages',
  );

  await page.getByRole('button', { name: 'Logout' }).click();
  await page.waitForURL('**/login');
  assert.deepEqual(pageErrors, []);
  console.log(
    'Browser smoke passed: auth, scope, global F-key navigation, desktop Ctrl chords, tag images, sales lifecycle, tag/item-opening/item-lot accessible keyboard grids, all four repair workflow stages, repair images, MLT PRO, physical stock, dashboard, logout',
  );
} catch (error) {
  // Preserve the actual browser state before teardown so a missing control or key-navigation
  // failure can be distinguished from a hydration error without weakening its assertion.
  const directory = mkdtempSync(join(tmpdir(), 'datacare-browser-smoke-failure-'));
  const diagnostics = {
    error: String(error?.stack ?? error),
    url: page?.url(),
    pageErrors,
    consoleErrors,
    requestFailures,
    serverLog,
  };
  if (page && !page.isClosed()) {
    const results = await Promise.allSettled([
      page.screenshot({ path: join(directory, 'page.png'), fullPage: true, timeout: 5000 }),
      page.content().then((html) => writeFileSync(join(directory, 'page.html'), html)),
    ]);
    diagnostics.captureErrors = results
      .filter((result) => result.status === 'rejected')
      .map((result) => String(result.reason));
  }
  writeFileSync(join(directory, 'diagnostics.json'), JSON.stringify(diagnostics, null, 2));
  console.error(`Browser smoke failure diagnostics: ${directory}`);
  throw error;
} finally {
  if (browser) await browser.close();
  stopServer();
}
