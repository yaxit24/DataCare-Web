// Full-surface crawl of the CURRENT commit's real stack (API :4100 + Next :4101 + isolated Postgres).
// Nothing is mocked. Logs in through the UI, opens the company, visits every route and records:
// HTTP status, page errors, console errors, failed API calls (with bodies), error boundaries,
// containment/unavailable notices and the action buttons offered to the operator.
import { createRequire } from 'node:module';
import { readFileSync, writeFileSync } from 'node:fs';

const require = createRequire('<repo>/web/apps/web/package.json');
const { chromium } = require('playwright');
const WEB = 'http://127.0.0.1:4101';
const OUT = '<audit-workdir>';
const { targets } = JSON.parse(readFileSync(`${OUT}/routes.json`, 'utf8'));

const browser = await chromium.launch();
const ctx = await browser.newContext({ viewport: { width: 1440, height: 900 } });
const page = await ctx.newPage();
let current = null;
page.on('pageerror', (e) => current?.pageErrors.push(String(e.message).slice(0, 240)));
page.on('console', (m) => { if (m.type() === 'error') current?.consoleErrors.push(m.text().slice(0, 240)); });
page.on('response', async (r) => {
  const u = r.url();
  if (!u.includes('/api/') || !current) return;
  const rec = { url: u.replace(WEB, '').slice(0, 160), method: r.request().method(), status: r.status() };
  current.api.push(rec);
  if (r.status() >= 400) { try { rec.body = (await r.text()).replace(/\s+/g, ' ').slice(0, 220); } catch {} }
});

await page.goto(`${WEB}/login`);
await page.getByLabel('User', { exact: true }).fill('admin');
await page.getByLabel('Password', { exact: true }).fill(process.env.DEMO_PASSWORD);
await page.getByRole('button', { name: 'Sign In', exact: true }).click();
await page.getByRole('button', { name: 'Open', exact: true }).click();
await page.waitForURL('**/dashboard', { timeout: 20000 });

const results = [];
for (const href of targets) {
  current = { href, pageErrors: [], consoleErrors: [], api: [] };
  const t0 = Date.now();
  let status = null;
  try {
    const resp = await page.goto(`${WEB}${href}`, { waitUntil: 'domcontentloaded', timeout: 30000 });
    status = resp?.status() ?? null;
    await page.waitForLoadState('networkidle', { timeout: 12000 }).catch(() => {});
  } catch (e) { current.navError = String(e.message).slice(0, 160); }
  const probe = await page.evaluate(() => {
    const main = document.querySelector('main') || document.body;
    const txt = main.innerText || '';
    const btns = [...main.querySelectorAll('button')].map((b) => b.textContent.trim()).filter((t) => t && !/^(F\d+|Ctrl\+)/.test(t));
    return {
      url: location.pathname,
      title: (main.querySelector('h1,h2')?.textContent ?? '').trim().slice(0, 90),
      inputs: main.querySelectorAll('input:not([type=hidden]),select,textarea').length,
      tables: main.querySelectorAll('table').length,
      errorBoundary: /Application error|Something went wrong|Unhandled Runtime Error|This page could not be found/i.test(document.body.innerText),
      contained: /contained|PARITY_CONTAINMENT|temporarily disabled|not yet available|not available here|safety containment/i.test(txt),
      containedText: (txt.match(/[^\n]*(contained|not available here|not yet available|temporarily disabled)[^\n]*/i) || [''])[0].slice(0, 200),
      actions: [...new Set(btns.filter((t) => /save|update|delete|print|post|submit|create|add|apply|generate|export|cancel|restore|load|run|show|set|import/i.test(t)))].slice(0, 14),
    };
  }).catch((e) => ({ evalError: String(e.message).slice(0, 160) }));
  const failed = current.api.filter((a) => a.status >= 400);
  const benign = failed.filter((a) => /\/reports\/[^/?]+\/filters/.test(a.url) && a.status === 404);
  const real = failed.filter((a) => !benign.includes(a));
  results.push({ ...current, api: undefined, apiCalls: current.api.length, status, ms: Date.now() - t0, ...probe, failedApi: real, benignFilters404: benign.length });
  process.stdout.write(real.length || current.pageErrors.length || probe.errorBoundary || probe.url === '/login' ? 'X' : probe.contained ? 'c' : '.');
}
console.log();
writeFileSync(`${OUT}/crawl.json`, JSON.stringify(results, null, 1));
const bad = results.filter((r) => r.failedApi.length || r.pageErrors.length || r.errorBoundary || r.navError || (r.status && r.status >= 400) || r.url === '/login');
console.log(`CRAWL visited=${results.length} clean=${results.length - bad.length} withProblems=${bad.length} containedNotices=${results.filter((r) => r.contained).length}`);
await browser.close();
