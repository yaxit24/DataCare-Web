// Business journeys through the REAL UI (real API + Postgres), with database write-set verification.
// Daily rate -> Sales invoice -> reload -> Cash receipt -> Purchase -> Ledger / Rojmel / Trial balance / Stock reports.
import { createRequire } from 'node:module';
import { writeFileSync, mkdirSync } from 'node:fs';
const reqWeb = createRequire('/projects/sandbox/DataCare-Web/web/apps/web/package.json');
const reqApi = createRequire('/projects/sandbox/DataCare-Web/web/apps/api/package.json');
const { chromium } = reqWeb('playwright');
const { PrismaClient } = reqApi('@prisma/client');
const WEB = 'http://127.0.0.1:4411';
const OUT = '/projects/sandbox/work/e2e/journey';
mkdirSync(OUT, { recursive: true });
const T = process.env.E2E_TENANT || 'e2e';
const db = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
const q = (sql, ...a) => db.$queryRawUnsafe(sql, ...a);
const ser = (x) => JSON.parse(JSON.stringify(x, (k, v) => (typeof v === 'bigint' ? Number(v) : v?.constructor?.name === 'Decimal' ? Number(v) : v)));
const R = { steps: [] };
const step = (name, data) => { R.steps.push({ name, ...data }); console.log(`\n### ${name}\n${JSON.stringify(data, null, 1).slice(0, 2500)}`); };

const browser = await chromium.launch();
const page = await (await browser.newContext({ viewport: { width: 1440, height: 1000 } })).newPage();
const apiLog = [];
page.on('response', async (r) => {
  if (!r.url().includes('/api/') || r.request().method() === 'GET') return;
  let body = ''; try { body = (await r.text()).slice(0, 600); } catch {}
  apiLog.push({ method: r.request().method(), url: r.url().replace(WEB, ''), status: r.status(), req: (r.request().postData() || '').slice(0, 1500), body });
});
const pageErrors = []; page.on('pageerror', (e) => pageErrors.push(e.message));
const lastPost = (frag) => [...apiLog].reverse().find((a) => a.url.includes(frag));
const shot = (n) => page.screenshot({ path: `${OUT}/${n}.png`, fullPage: true }).catch(() => {});
const cell = (row, col) => page.locator(`[data-grid-row="${row}"][data-grid-column="${col}"] input`).first();
const L = (t) => page.locator(`xpath=(//label[normalize-space()="${t}"]/following::*[self::input or self::select or self::textarea])[1]`);
const settle = () => page.waitForLoadState('networkidle', { timeout: 10000 }).catch(() => {});

// ---- login
await page.goto(`${WEB}/login`);
await page.getByLabel('Company Code', { exact: true }).fill('01');
await page.getByLabel('User', { exact: true }).fill('admin');
await page.getByLabel('Password', { exact: true }).fill(process.env.DEMO_PASSWORD);
await page.getByRole('button', { name: 'Sign In', exact: true }).click();
await page.getByRole('button', { name: 'Open', exact: true }).click();
await page.waitForURL('**/dashboard');
const coYear = await page.getByLabel('Financial year').inputValue();
step('login', { coYear });

// ---- 1. Daily rate
try {
  await page.goto(`${WEB}/txn/daily-rate`); await settle();
  await L('Gold /10g (fine)').fill('60000');
  await L('Silver /kg (fine)').fill('70000');
  await page.getByRole('button', { name: 'Set Daily Rate' }).click(); await settle(); await page.waitForTimeout(800);
  await shot('01-daily-rate');
  step('daily-rate', { api: lastPost('rate'), db: ser(await q(`SELECT * FROM "RATE_MAST" WHERE tenant_id=$1 LIMIT 3`, T).catch((e) => e.message)) });
} catch (e) { step('daily-rate', { error: e.message }); }

// ---- 2. Sales invoice
let saleVch = null;
try {
  await page.goto(`${WEB}/txn/sales`); await settle();
  const books = await page.getByLabel('Configured book').locator('option').allTextContents();
  const saleBook = books.find((b) => /sal/i.test(b) && !/return|order|quot/i.test(b));
  step('sales-books-offered', { books, chosen: saleBook });
  if (saleBook) await page.getByLabel('Configured book').selectOption({ label: saleBook });
  await page.getByPlaceholder('search accounts… (F1)').first().fill('CUST01');
  await page.keyboard.press('Escape');
  await cell(0, 0).fill('GOLD'); await page.keyboard.press('Escape');
  await cell(0, 2).fill('1');
  await cell(0, 3).fill('10');
  await cell(0, 4).fill('10');
  await cell(0, 5).fill('91.6');
  await cell(0, 6).fill('6000');
  await cell(0, 7).fill('500');
  await page.waitForTimeout(500);
  const rowText = await page.locator('[data-grid-row="0"]').allInnerTexts();
  const lineVals = [];
  for (let c = 0; c < 17; c++) lineVals.push(await cell(0, c).inputValue().catch(() => null));
  await L('Cash ₹').fill('20000');
  await shot('02-sales-before-save');
  await page.getByRole('button', { name: 'Save Invoice' }).click(); await settle(); await page.waitForTimeout(1200);
  await shot('02-sales-after-save');
  const post = lastPost('/sales');
  step('sales-save', { lineVals, post, uiMessage: (await page.locator('body').innerText()).match(/(saved|error|invalid|required|failed)[^\n]{0,160}/gi)?.slice(0, 6) });
  try { saleVch = JSON.parse(post?.body || '{}').vchNo ?? null; } catch {}
} catch (e) { step('sales-save', { error: e.message, api: apiLog.slice(-3) }); await shot('02-sales-error'); }

const writeSet = async (book, vch) => {
  const tables = ['SL_DATA', 'SL_DETL', 'AC_DATA', 'ROJ_MEL_DATA', 'MAIN_STOCK', 'TAX_DATA', 'BILL_OS_DATA', 'UPI_DATA', 'PR_DATA', 'PR_DETL', 'CASH_DATA'];
  const o = {};
  for (const t of tables) {
    const rows = await q(`SELECT * FROM "${t}" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND ltrim("VCH_NO"::text,'0')=ltrim($3::text,'0')`, T, book, String(vch)).catch(() => []);
    if (rows.length) o[t] = ser(rows).map((r) => Object.fromEntries(Object.entries(r).filter(([k, v]) => v !== null && v !== '' && v !== 0 && !['tenant_id', 'row_id'].includes(k))));
  }
  return o;
};
if (saleVch) {
  const hdr = ser(await q(`SELECT "CO_BOOK","VCH_NO" FROM "SL_DATA" WHERE tenant_id=$1 ORDER BY row_id DESC LIMIT 1`, T))[0];
  const ws = await writeSet(hdr.CO_BOOK, hdr.VCH_NO);
  const ac = ws.AC_DATA || [];
  const dr = ac.reduce((s, r) => s + (r.DR_AMT || 0), 0), cr = ac.reduce((s, r) => s + (r.CR_AMT || 0), 0);
  step('sales-db-write-set', { book: hdr.CO_BOOK, vch: hdr.VCH_NO, tables: Object.fromEntries(Object.entries(ws).map(([k, v]) => [k, v.length])), ledgerDr: dr, ledgerCr: cr, ws });
  // Independent recomputation using the desktop formulas (TR_SALE CommPassTotal/BILL_TOTAL):
  // fine = net*touch/100 ; metal = net*rate (rate per gram) ; labour = net*making ; GST 3% on (metal+labour)
  const metal = 10 * 6000, labour = 10 * 500, taxable = metal + labour, gst = Math.round(taxable * 0.03 * 100) / 100;
  step('sales-expected-desktop-formula', { fine: 9.16, metal, labour, taxable, gst, total: taxable + gst, outstandingAfterCash: taxable + gst - 20000 });
  // Reload the saved voucher through the UI
  try {
    await page.goto(`${WEB}/txn/sales`); await settle();
    await page.getByLabel('Configured book').selectOption({ label: 'SL — Sales' });
    await page.getByLabel('Voucher No', { exact: true }).fill(String(saleVch));
    await page.getByRole('button', { name: 'Load', exact: true }).click(); await settle(); await page.waitForTimeout(800);
    const loadResp = apiLog.length; const reVals = []; for (let c = 0; c < 17; c++) reVals.push(await cell(0, c).inputValue().catch(() => null));
    await shot('03-sales-reloaded');
    step('sales-reload', { reVals, buttons: (await page.locator('button').allTextContents()).filter((b) => /delete|update|print|cancel/i.test(b)) });
  } catch (e) { step('sales-reload', { error: e.message }); }
}

// ---- 3. Cash receipt
try {
  await page.goto(`${WEB}/txn/receipt`); await settle();
  await page.getByPlaceholder('search accounts… (F1)').first().fill('CUST01'); await page.keyboard.press('Escape');
  await L('Amount').fill('5000');
  await page.getByRole('button', { name: 'Save Receipt' }).click(); await settle(); await page.waitForTimeout(1000);
  await shot('04-receipt');
  const post = lastPost('/receipts');
    step('receipt', { post });
} catch (e) { step('receipt', { error: e.message }); await shot('04-receipt-error'); }

// ---- 3b. Cash payment through the UI
try {
  await page.goto(`${WEB}/txn/payment`); await settle();
  await page.getByPlaceholder('search accounts… (F1)').first().fill('CUST01'); await page.keyboard.press('Escape');
  await L('Amount').fill('1000');
  await page.getByRole('button', { name: 'Save Payment' }).click(); await settle(); await page.waitForTimeout(1000);
  await shot('04b-payment');
  step('payment-ui', { post: lastPost('/payments') });
} catch (e) { step('payment-ui', { error: e.message }); }
// ---- 3c. Control: the same receipt with the configured book supplied explicitly (same session cookie)
{
  const r = await page.request.post(`${WEB}/api/receipts?coBook=RCT`, { data: { partyAc: 'CUST01', amount: 5000, mode: 'cash', coBook: 'RCT' } });
  step('receipt-api-with-book', { status: r.status(), body: (await r.text()).slice(0, 400) });
}
// ---- 4. Purchase
try {
  await page.goto(`${WEB}/txn/purchase`); await settle();
  const books = await page.getByLabel('Configured book').locator('option').allTextContents();
  const pb = books.find((b) => /^PR\b|purchase/i.test(b) && !/return|quot/i.test(b));
  if (pb) await page.getByLabel('Configured book').selectOption({ label: pb });
  await page.getByPlaceholder('search accounts… (F1)').first().fill('CUST01'); await page.keyboard.press('Escape');
  if (!(await cell(0, 0).count())) await page.getByRole('button', { name: '+ Add line' }).first().click();
  await cell(0, 0).fill('GOLD'); await page.keyboard.press('Escape');
  await cell(0, 2).fill('1'); await cell(0, 3).fill('5'); await cell(0, 4).fill('5'); await cell(0, 5).fill('99.5'); await cell(0, 6).fill('5900');
  await page.waitForTimeout(400);
  await page.getByRole('button', { name: 'Save Purchase' }).click(); await settle(); await page.waitForTimeout(1200);
  await shot('05-purchase');
  const post = lastPost('/purchases');
  const hdr = ser(await q(`SELECT "CO_BOOK","VCH_NO" FROM "PR_DATA" WHERE tenant_id=$1 ORDER BY row_id DESC LIMIT 1`, T))[0];
  step('purchase', { book: pb, post, ws: hdr ? Object.fromEntries(Object.entries(await writeSet(hdr.CO_BOOK, hdr.VCH_NO)).map(([k, v]) => [k, v.length])) : null });
} catch (e) { step('purchase', { error: e.message }); await shot('05-purchase-error'); }

// ---- 5. Reports through the UI, compared with direct SQL over the same ledger
const runReport = async (slug, fill) => {
  await page.goto(`${WEB}/reports/${slug}`); await settle();
  if (fill) await fill().catch((e) => console.log('fill failed', e.message.slice(0,120)));
  await page.getByRole('button', { name: 'Run', exact: true }).click().catch(() => {});
  await settle(); await page.waitForTimeout(800);
  await shot(`06-report-${slug}`);
  const rows = await page.locator('table tbody tr').allInnerTexts().catch(() => []);
  return { rows: rows.length, sample: rows.slice(0, 12).map((r) => r.replace(/\s+/g, ' ').slice(0, 200)), failed: apiLog.filter((a) => a.status >= 400).slice(-2) };
};
step('report-account-ledger', await runReport('account-ledger', async () => L('Account Code').fill('CUST01')));
step('db-ledger-CUST01', { rows: ser(await q(`SELECT "CO_BOOK","VCH_NO","VCH_DATE","DR_AMT","CR_AMT" FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE"='CUST01' ORDER BY row_id`, T)) });
step('report-rojmel', await runReport('rojmel'));
step('report-trial-balance', await runReport('trial-balance'));
step('db-trial-balance', { rows: ser(await q(`SELECT "AC_CODE", sum(coalesce("DR_AMT",0)) dr, sum(coalesce("CR_AMT",0)) cr FROM "AC_DATA" WHERE tenant_id=$1 GROUP BY 1 ORDER BY 1`, T)) });
step('report-tag-stock', await runReport('tag-stock'));
step('report-stock-valuation', await runReport('stock-valuation'));
step('report-sales-register', await runReport('sales-register'));
step('report-gstr3b', await runReport('gstr3b'));

R.pageErrors = pageErrors; R.api = apiLog;
writeFileSync(`${OUT}/journey.json`, JSON.stringify(R, null, 1));
await browser.close(); await db.$disconnect();
