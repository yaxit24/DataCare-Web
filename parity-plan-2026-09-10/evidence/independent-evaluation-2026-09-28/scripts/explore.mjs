// Dump form labels, selects and grid column headers for key transaction pages (real stack).
import { createRequire } from 'node:module';
import { writeFileSync } from 'node:fs';
const require = createRequire('/projects/sandbox/DataCare-Web/web/apps/web/package.json');
const { chromium } = require('playwright');
const WEB = 'http://127.0.0.1:4411';
const browser = await chromium.launch();
const page = await (await browser.newContext({ viewport: { width: 1440, height: 900 } })).newPage();
await page.goto(`${WEB}/login`);
await page.getByLabel('Company Code', { exact: true }).fill('01');
await page.getByLabel('User', { exact: true }).fill('admin');
await page.getByLabel('Password', { exact: true }).fill(process.env.DEMO_PASSWORD);
await page.getByRole('button', { name: 'Sign In', exact: true }).click();
await page.getByRole('button', { name: 'Open', exact: true }).click();
await page.waitForURL('**/dashboard');
const out = {};
for (const href of (process.env.PAGES || '/txn/sales,/txn/receipt,/txn/purchase,/txn/payment,/masters/accounts,/reports/account-ledger,/reports/rojmel,/reports/trial-balance,/txn/daily-rate').split(',')) {
  await page.goto(`${WEB}${href}`);
  await page.waitForLoadState('networkidle').catch(() => {});
  out[href] = await page.evaluate(() => {
    const lab = (el) => el.getAttribute('aria-label') || el.closest('label')?.textContent?.trim() || el.previousElementSibling?.textContent?.trim() || el.name || el.placeholder || '';
    return {
      fields: [...document.querySelectorAll('input:not([type=hidden]),select,textarea')].filter((e) => !e.closest('[data-grid-row]')).map((e) => ({ tag: e.tagName, label: lab(e).slice(0, 40), type: e.type, value: e.value?.slice(0, 30), options: e.tagName === 'SELECT' ? [...e.options].map((o) => o.value + '=' + o.text).slice(0, 8) : undefined })),
      grids: [...document.querySelectorAll('table')].map((t) => ({ testid: t.getAttribute('data-testid') || t.closest('[data-testid]')?.getAttribute('data-testid'), headers: [...t.querySelectorAll('thead th')].map((h) => h.textContent.trim()), gridCells: t.querySelectorAll('[data-grid-row="0"]').length })),
      buttons: [...document.querySelectorAll('button')].map((b) => b.textContent.trim()).filter(Boolean).slice(0, 60),
    };
  });
}
writeFileSync('/projects/sandbox/work/e2e/explore.json', JSON.stringify(out, null, 1));
await browser.close();
