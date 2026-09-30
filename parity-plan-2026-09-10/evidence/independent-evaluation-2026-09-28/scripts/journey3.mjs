// Purchase via UI, then Sales edit (Update Invoice), Print, Delete via UI, with DB verification.
import { createRequire } from 'node:module';
import { writeFileSync, mkdirSync } from 'node:fs';
const reqWeb = createRequire('/projects/sandbox/DataCare-Web/web/apps/web/package.json');
const reqApi = createRequire('/projects/sandbox/DataCare-Web/web/apps/api/package.json');
const { chromium } = reqWeb('playwright');
const { PrismaClient } = reqApi('@prisma/client');
const WEB = 'http://127.0.0.1:4411', OUT = '/projects/sandbox/work/e2e/journey3';
mkdirSync(OUT, { recursive: true });
const T = process.env.E2E_TENANT;
const db = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
const q = (s, ...a) => db.$queryRawUnsafe(s, ...a);
const ser = (x) => JSON.parse(JSON.stringify(x, (k, v) => (typeof v === 'bigint' ? Number(v) : v?.constructor?.name === 'Decimal' ? Number(v) : v)));
const log = (n, d) => console.log(`\n### ${n}\n${JSON.stringify(d, null, 1).slice(0, 3000)}`);
const browser = await chromium.launch();
const page = await (await browser.newContext({ viewport: { width: 1440, height: 1000 } })).newPage();
const api = [];
page.on('response', async (r) => { if (!r.url().includes('/api/') || r.request().method() === 'GET') return; let b = ''; try { b = (await r.text()).slice(0, 500); } catch {} api.push({ m: r.request().method(), u: r.url().replace(WEB, ''), s: r.status(), req: (r.request().postData() || '').slice(0, 900), b }); });
page.on('dialog', (d) => d.accept());
const last = (f) => [...api].reverse().find((a) => a.u.includes(f));
const settle = () => page.waitForLoadState('networkidle', { timeout: 10000 }).catch(() => {});
const L = (t) => page.locator(`xpath=(//label[normalize-space()="${t}"]/following::*[self::input or self::select])[1]`);
const cell = (r, c) => page.locator(`[data-grid-row="${r}"][data-grid-column="${c}"] input`).first();
const counts = async (book, vch) => {
  const o = {};
  for (const t of ['SL_DATA', 'SL_DETL', 'AC_DATA', 'ROJ_MEL_DATA', 'MAIN_STOCK', 'TAX_DATA', 'BILL_OS_DATA', 'PR_DATA', 'PR_DETL', 'LOT_DETL'])
    o[t] = Number((await q(`SELECT count(*) n FROM "${t}" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`, T, book, vch).catch(() => [{ n: -1 }]))[0].n);
  o.DELETE_DATA = Number((await q(`SELECT count(*) n FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2`, T, book))[0].n);
  return o;
};
await page.goto(`${WEB}/login`);
await page.getByLabel('Company Code', { exact: true }).fill('01');
await page.getByLabel('User', { exact: true }).fill('admin');
await page.getByLabel('Password', { exact: true }).fill(process.env.DEMO_PASSWORD);
await page.getByRole('button', { name: 'Sign In', exact: true }).click();
await page.getByRole('button', { name: 'Open', exact: true }).click();
await page.waitForURL('**/dashboard');

// ---- Purchase through the UI
try {
  await page.goto(`${WEB}/txn/purchase`); await settle();
  await page.getByLabel('Configured book').selectOption({ label: 'PR — Purchase' });
  await page.getByPlaceholder('search accounts… (F1)').first().fill('CUST01'); await page.keyboard.press('Escape');
  const row = page.locator('table').filter({ hasText: 'Making/g' }).locator('tbody tr').first();
  const inputs = row.locator('input');
  log('purchase-row-inputs', { n: await inputs.count() });
  const vals = ['GOLD', '', '1', '5', '5', '99.5', '5900', '0'];
  for (let i = 0; i < vals.length; i++) if (vals[i]) { await inputs.nth(i).fill(vals[i]); await page.keyboard.press('Tab').catch(() => {}); }
  await page.keyboard.press('Escape');
  await page.getByRole('button', { name: 'Save Purchase' }).click(); await settle(); await page.waitForTimeout(1200);
  await page.screenshot({ path: `${OUT}/purchase.png`, fullPage: true });
  const p = last('/purchases');
  let v = null; try { v = String(JSON.parse(p.b).vchNo).padStart(5, '0'); } catch {}
  log('purchase-save', { post: p, writeSet: v ? await counts('PR', v) : null,
    ledger: v ? ser(await q(`SELECT "AC_CODE","DR_AMT","CR_AMT","FINE_WT","SIGN","LEDR_KEY" FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='PR' AND "VCH_NO"=$2`, T, v)) : null,
    stock: v ? ser(await q(`SELECT "IT_CODE","ITM_SIGN","ITM_GWT","ITM_NWT","ITM_FINE","TAG_NO" FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='PR' AND "VCH_NO"=$2`, T, v)) : null });
} catch (e) { log('purchase-error', { e: e.message, last: api.slice(-2) }); await page.screenshot({ path: `${OUT}/purchase-err.png`, fullPage: true }); }

// ---- Sales: new voucher, then Update, Print, Delete through the UI
await page.goto(`${WEB}/txn/sales`); await settle();
await page.getByLabel('Configured book').selectOption({ label: 'SL — Sales' });
await page.getByPlaceholder('search accounts… (F1)').first().fill('CUST01'); await page.keyboard.press('Escape');
await cell(0, 0).fill('GOLD'); await page.keyboard.press('Escape');
for (const [c, v] of [[2, '1'], [3, '8'], [4, '8'], [5, '91.6'], [6, '6000'], [7, '400']]) await cell(0, c).fill(v);
await page.getByRole('button', { name: 'Save Invoice' }).click(); await settle(); await page.waitForTimeout(1000);
const created = last('/sales');
const vch = String(JSON.parse(created.b).vchNo);
const V = vch.padStart(5, '0');
log('sale-created', { s: created.s, b: created.b, counts: await counts('SL', V) });
const before = ser(await q(`SELECT "AC_CODE","DR_AMT","CR_AMT" FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2 ORDER BY 1`, T, V));

await page.goto(`${WEB}/txn/sales`); await settle();
await page.getByLabel('Configured book').selectOption({ label: 'SL — Sales' });
await page.getByLabel('Voucher No', { exact: true }).fill(vch);
await page.getByRole('button', { name: 'Load', exact: true }).click(); await settle(); await page.waitForTimeout(800);
await cell(0, 3).fill('9'); await cell(0, 4).fill('9');
await page.getByRole('button', { name: 'Update Invoice' }).click(); await settle(); await page.waitForTimeout(1200);
const upd = last(`/sales/${vch}`);
log('sale-update', { s: upd?.s, m: upd?.m, b: upd?.b, counts: await counts('SL', V), before,
  after: ser(await q(`SELECT "AC_CODE","DR_AMT","CR_AMT" FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2 ORDER BY 1`, T, V)),
  detl: ser(await q(`SELECT "ITM_GWT","ITM_NWT","ITM_FINE","ITM_AMT","LBR_AMT","NET_AMT" FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2`, T, V)),
  userUpdate: ser(await q(`SELECT "USER_UPDATE","UPDATE_USER" FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2`, T, V).catch((e) => e.message)) });

// Print
const [popup] = await Promise.all([page.waitForEvent('popup', { timeout: 8000 }).catch(() => null), page.getByRole('button', { name: 'Print', exact: true }).click().catch(() => null)]);
if (popup) { await popup.waitForLoadState().catch(() => {}); await popup.screenshot({ path: `${OUT}/sale-print.png`, fullPage: true }).catch(() => {}); log('sale-print', { url: popup.url().replace(WEB, ''), text: (await popup.locator('body').innerText().catch(() => '')).replace(/\s+/g, ' ').slice(0, 700) }); }
else log('sale-print', { popup: false, lastApi: api.slice(-1) });

// Delete
await page.getByRole('button', { name: 'Delete', exact: true }).click().catch((e) => log('delete-click', { e: e.message }));
await settle(); await page.waitForTimeout(1200);
const del = last(`/sales/${vch}`);
log('sale-delete', { s: del?.s, m: del?.m, b: del?.b, counts: await counts('SL', V),
  deleteData: ser(await q(`SELECT * FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' ORDER BY row_id DESC LIMIT 2`, T).catch((e) => e.message)) });
await page.screenshot({ path: `${OUT}/sale-after-delete.png`, fullPage: true });
writeFileSync(`${OUT}/api.json`, JSON.stringify(api, null, 1));
await browser.close(); await db.$disconnect();
