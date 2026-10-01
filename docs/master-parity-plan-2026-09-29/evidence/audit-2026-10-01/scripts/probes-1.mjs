// Real-stack probes on the audit stack (API :4100, Next :4101). Private headless browser; nothing mocked.
import { createRequire } from 'node:module';
import { writeFileSync } from 'node:fs';
const require = createRequire('<repo>/web/apps/web/package.json');
const { chromium } = require('playwright');
const WEB = 'http://127.0.0.1:4101';
const OUT = '<audit-workdir>';
const R = {};
const browser = await chromium.launch();
const page = await (await browser.newContext()).newPage();
let ctxHeaders = null;
page.on('request', (q) => {
  const h = q.headers();
  if (h['x-session-context-id'] && h['x-session-context-epoch']) ctxHeaders = { 'x-session-context-id': h['x-session-context-id'], 'x-session-context-epoch': h['x-session-context-epoch'] };
});
const reportJson = {};
page.on('response', async (r) => {
  const m = r.url().match(/\/api\/reports\/([a-z0-9-]+)(\?|$)/);
  if (m && r.request().method() === 'GET' && !r.url().includes('/filters')) {
    try { reportJson[m[1]] = { status: r.status(), body: await r.json() }; } catch { reportJson[m[1]] = { status: r.status(), body: null }; }
  }
});
await page.goto(`${WEB}/login`);
await page.getByLabel('User', { exact: true }).fill('admin');
await page.getByLabel('Password', { exact: true }).fill(process.env.DEMO_PASSWORD);
await page.getByRole('button', { name: 'Sign In', exact: true }).click();
await page.getByRole('button', { name: 'Open', exact: true }).click();
await page.waitForURL('**/dashboard');
await page.waitForLoadState('networkidle').catch(() => {});

// (a) report pages as an operator opens them
const reports = ['trial-balance', 'account-ledger', 'rojmel', 'sales-register', 'purchase-register', 'gstr1', 'gstr3b', 'gstr2', 'balance-sheet', 'profit-loss', 'outstanding', 'bill-outstanding', 'cash-book', 'item-stock-ledger', 'tag-stock', 'stock-valuation', 'hsn-summary', 'daily-sales', 'huid', 'bill-profit', 'item-weight-levels', 'size-movement', 'physical-stock-verify'];
R.reports = {};
for (const slug of reports) {
  await page.goto(`${WEB}/reports/${slug}`, { waitUntil: 'domcontentloaded' });
  await page.waitForLoadState('networkidle', { timeout: 12000 }).catch(() => {});
  const shown = await page.evaluate(() => {
    const main = document.querySelector('main');
    const rows = [...main.querySelectorAll('table tbody tr')].map((tr) => tr.innerText.replace(/\s+/g, ' ').trim()).filter(Boolean);
    return { rows: rows.length, sample: rows.slice(0, 6), text: main.innerText.replace(/\s+/g, ' ').slice(0, 260) };
  });
  const api = reportJson[slug] || Object.entries(reportJson).find(([k]) => k.startsWith(slug.split('-')[0]))?.[1];
  R.reports[slug] = { apiStatus: api?.status ?? null, screenRows: shown.rows, sample: shown.sample, text: shown.rows ? undefined : shown.text };
}

const api = async (method, path, data) => {
  const r = await page.request.fetch(`${WEB}/api${path}`, { method, data, headers: ctxHeaders ?? {} });
  let body = ''; try { body = (await r.text()).replace(/\s+/g, ' ').slice(0, 260); } catch {}
  return { status: r.status(), body };
};
R.ctxHeadersCaptured = !!ctxHeaders;

// (b) contained operations
R.containment = {
  tagWeightDiff: await api('POST', '/stock/tag-weight-diff', { tagNo: 'X', coBook: 'TWD' }),
  logicalRestore: await api('POST', '/backup/restore', {}),
};

// (c) malformed input: 400 vs 500
const goodLine = { itCode: 'GOLD', pcs: 1, grossWt: 1, netWt: 1, touch: 91.6, rate: 6000 };
R.validation = {
  saleLineNull: await api('POST', '/sales', { coBook: 'SL', acCode: 'CUST01', lines: [null] }),
  saleRateText: await api('POST', '/sales', { coBook: 'SL', acCode: 'CUST01', lines: [{ ...goodLine, rate: 'abc' }] }),
  saleDiscountText: await api('POST', '/sales', { coBook: 'SL', acCode: 'CUST01', discountAmount: 'x', lines: [goodLine] }),
  estimateBadOther: await api('POST', '/estimate', { lines: [{ ...goodLine, otherAmount: 'zz' }] }),
  salesReturnIncomplete: await api('POST', '/sales-returns', { coBook: 'SRT', acCode: 'CUST01', lines: [{ itCode: 'GOLD' }] }),
  purchaseWrongBookFamily: await api('POST', '/purchases', { coBook: 'JV', acCode: 'CUST01', lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 1, netWt: 1, touch: 99.5, rate: 6000 }] }),
  receiptIntoSalesBook: await api('POST', '/receipts', { coBook: 'SL', acCode: 'CUST01', amount: 1, mode: 'cash' }),
};

// (d) duplicate submission of an identical receipt (no idempotency key)
const rc = { coBook: 'RCT', acCode: 'CUST01', amount: 111, mode: 'cash' };
R.duplicateReceipt = [await api('POST', '/receipts', rc), await api('POST', '/receipts', rc)];

// (e) delete the sale through the UI and let the DB check verify reversal
await page.goto(`${WEB}/txn/sales`, { waitUntil: 'domcontentloaded' });
await page.waitForLoadState('networkidle').catch(() => {});
page.on('dialog', (d) => d.accept());
const recent = page.getByRole('button', { name: /Recent vouchers/ });
if (await recent.count()) await recent.first().click();
await page.waitForTimeout(800);
const rowBtn = page.locator('main').getByText('00001', { exact: false }).first();
if (await rowBtn.count()) await rowBtn.click().catch(() => {});
await page.waitForTimeout(1500);
const loaded = await page.locator('main').innerText();
R.deleteFlow = { loadedVoucher: /Loaded #00001/.test(loaded) || /00001/.test(loaded) };
const del = page.getByRole('button', { name: 'Delete', exact: true });
if (await del.count()) {
  const resp = page.waitForResponse((r) => r.request().method() === 'DELETE' && r.url().includes('/api/sales'), { timeout: 10000 }).catch(() => null);
  await del.first().click();
  const d = await resp;
  R.deleteFlow.deleteStatus = d ? d.status() : 'no DELETE request seen';
} else R.deleteFlow.deleteStatus = 'no Delete button';

writeFileSync(`${OUT}/probes.json`, JSON.stringify(R, null, 1));
console.log(JSON.stringify({ reports: Object.fromEntries(Object.entries(R.reports).map(([k, v]) => [k, `${v.apiStatus}/${v.screenRows}`])), containment: R.containment, validation: Object.fromEntries(Object.entries(R.validation).map(([k, v]) => [k, `${v.status} ${v.body.slice(0, 110)}`])), duplicateReceipt: R.duplicateReceipt.map((x) => `${x.status} ${x.body.slice(0, 80)}`), deleteFlow: R.deleteFlow }, null, 1));
await browser.close();
