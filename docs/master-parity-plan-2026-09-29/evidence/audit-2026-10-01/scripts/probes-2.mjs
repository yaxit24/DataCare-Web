import { createRequire } from 'node:module';
import { writeFileSync } from 'node:fs';
const require = createRequire('<repo>/web/apps/web/package.json');
const { chromium } = require('playwright');
const WEB = 'http://127.0.0.1:4101';
const browser = await chromium.launch();
const page = await (await browser.newContext()).newPage();
let ctxHeaders = null;
page.on('request', (q) => { const h = q.headers(); if (h['x-session-context-id']) ctxHeaders = { 'x-session-context-id': h['x-session-context-id'], 'x-session-context-epoch': h['x-session-context-epoch'] }; });
await page.goto(`${WEB}/login`);
await page.getByLabel('User', { exact: true }).fill('admin');
await page.getByLabel('Password', { exact: true }).fill(process.env.DEMO_PASSWORD);
await page.getByRole('button', { name: 'Sign In', exact: true }).click();
await page.getByRole('button', { name: 'Open', exact: true }).click();
await page.waitForURL('**/dashboard');
await page.waitForLoadState('networkidle').catch(() => {});
const api = async (method, path, data) => {
  const r = await page.request.fetch(`${WEB}/api${path}`, { method, data, headers: ctxHeaders ?? {} });
  let body = ''; try { body = (await r.text()).replace(/\s+/g, ' ').slice(0, 200); } catch {}
  return `${r.status()} ${body}`;
};
const line = { itCode: 'GOLD', pcs: 1, grossWt: 1, netWt: 1, touch: 91.6, rate: 6000, labourRate: 0 };
const base = { coBook: 'SL', acCode: 'CUST01', taxRatePct: 3, vchDate: '2026-10-01' };
const out = {
  saleLineNull: await api('POST', '/sales', { ...base, lines: [null] }),
  saleRateText: await api('POST', '/sales', { ...base, lines: [{ ...line, rate: 'abc' }] }),
  saleNetText: await api('POST', '/sales', { ...base, lines: [{ ...line, netWt: 'ten' }] }),
  saleDiscountText: await api('POST', '/sales', { ...base, discountAmount: 'x', lines: [line] }),
  salesReturnIncomplete: await api('POST', '/sales-returns', { coBook: 'SRT', acCode: 'CUST01', taxRatePct: 3, lines: [{ itCode: 'GOLD' }] }),
  purchaseIntoJournalBook: await api('POST', '/purchases', { coBook: 'JV', acCode: 'CUST01', taxRatePct: 3, lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 1, netWt: 1, touch: 99.5, rate: 6000 }] }),
  receiptIntoSalesBook: await api('POST', '/receipts', { coBook: 'SL', partyAc: 'CUST01', amount: 1, mode: 'cash' }),
};
const rc = { coBook: 'RCT', partyAc: 'CUST01', amount: 111, mode: 'cash' };
out.duplicateReceipt = [await api('POST', '/receipts', rc), await api('POST', '/receipts', rc)];
out.deleteSaleNoVersion = await api('DELETE', '/sales/00001?coBook=SL&coYear=2026-2027&lcCode=01');
writeFileSync('<audit-workdir>/probes2.json', JSON.stringify(out, null, 1));
console.log(JSON.stringify(out, null, 1));
await browser.close();
