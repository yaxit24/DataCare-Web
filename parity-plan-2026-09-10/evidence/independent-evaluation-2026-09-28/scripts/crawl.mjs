// Full-surface headless crawl of the real stack (real API + Postgres, nothing mocked).
// Logs in through the UI, opens a company, then visits every nav href + every page route and records
// per-page: HTTP status, runtime/page errors, failed API calls, error-boundary text, interactive surface.
import { createRequire } from 'node:module';
import { mkdirSync, writeFileSync, readFileSync } from 'node:fs';
const require = createRequire('/projects/sandbox/DataCare-Web/web/apps/web/package.json');
const { chromium } = require('playwright');

const WEB = 'http://127.0.0.1:4411';
const OUT = '/projects/sandbox/work/e2e';
mkdirSync(`${OUT}/shots`, { recursive: true });
const nav = JSON.parse(readFileSync('/projects/sandbox/work/nav-hrefs.json', 'utf8'));
const pages = JSON.parse(readFileSync('/projects/sandbox/work/page-routes.json', 'utf8'));
const targets = [...new Set([...nav, ...pages])].filter((h) => !h.includes('['));

const browser = await chromium.launch();
const ctx = await browser.newContext({ viewport: { width: 1440, height: 900 } });
const page = await ctx.newPage();
let current = null;
const bucket = () => current;
page.on('pageerror', (e) => bucket()?.pageErrors.push(String(e.message).slice(0, 300)));
page.on('console', (m) => { if (m.type() === 'error') bucket()?.consoleErrors.push(m.text().slice(0, 300)); });
page.on('response', async (r) => {
  const u = r.url();
  if (!u.includes('/api/') || !bucket()) return;
  const rec = { url: u.replace(WEB, ''), method: r.request().method(), status: r.status() };
  bucket().api.push(rec);
  if (r.status() >= 400) { try { rec.body = (await r.text()).slice(0, 240); } catch {} }
});

// ---- login + open company through the real UI
await page.goto(`${WEB}/login`);
await page.getByLabel('Company Code', { exact: true }).fill('01');
await page.getByLabel('User', { exact: true }).fill('admin');
await page.getByLabel('Password', { exact: true }).fill(process.env.DEMO_PASSWORD);
await page.getByRole('button', { name: 'Sign In', exact: true }).click();
await page.getByRole('heading', { name: 'Open Company', exact: true }).waitFor({ timeout: 20000 });
await page.screenshot({ path: `${OUT}/shots/_select.png` });
await page.getByRole('button', { name: 'Open', exact: true }).click();
await page.waitForURL('**/dashboard', { timeout: 20000 });
await page.waitForLoadState('networkidle').catch(() => {});
await page.screenshot({ path: `${OUT}/shots/_dashboard.png`, fullPage: true });

const results = [];
for (const href of targets) {
  current = { href, pageErrors: [], consoleErrors: [], api: [] };
  const t0 = Date.now();
  let status = null;
  try {
    const resp = await page.goto(`${WEB}${href}`, { waitUntil: 'domcontentloaded', timeout: 30000 });
    status = resp?.status() ?? null;
    await page.waitForLoadState('networkidle', { timeout: 12000 }).catch(() => {});
  } catch (e) {
    current.navError = String(e.message).slice(0, 200);
  }
  const probe = await page.evaluate(() => {
    const txt = document.body?.innerText ?? '';
    const q = (s) => document.querySelectorAll(s).length;
    return {
      title: (document.querySelector('h1,h2')?.textContent ?? '').trim().slice(0, 80),
      url: location.pathname,
      inputs: q('input:not([type=hidden]),select,textarea'),
      buttons: q('button'),
      tables: q('table'),
      gridRows: q('table tbody tr'),
      errorBoundary: /Application error|Something went wrong|Unhandled Runtime Error|This page could not be found|404/i.test(txt),
      contained: /contained|disabled by|not yet available|Coming soon|parity safety/i.test(txt),
      comingSoon: /coming soon|placeholder|not implemented/i.test(txt),
      textLen: txt.length,
      snippet: txt.replace(/\s+/g, ' ').slice(0, 220),
    };
  }).catch((e) => ({ evalError: String(e.message) }));
  const safe = href.replace(/[^a-z0-9]+/gi, '_');
  await page.screenshot({ path: `${OUT}/shots/${safe}.png` }).catch(() => {});
  const failed = current.api.filter((a) => a.status >= 400);
  results.push({ ...current, status, ms: Date.now() - t0, ...probe, apiCalls: current.api.length, failedApi: failed, api: undefined });
  process.stdout.write(`${failed.length || current.pageErrors.length || probe.errorBoundary ? 'X' : '.'}`);
}
console.log();
writeFileSync(`${OUT}/crawl.json`, JSON.stringify(results, null, 2));
const bad = results.filter((r) => r.failedApi.length || r.pageErrors.length || r.errorBoundary || r.navError || (r.status && r.status >= 400) || r.url === '/login');
console.log(`CRAWL visited=${results.length} clean=${results.length - bad.length} withProblems=${bad.length}`);
await browser.close();
