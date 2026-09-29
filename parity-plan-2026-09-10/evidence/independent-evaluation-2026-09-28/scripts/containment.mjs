// Probe contained/disabled operations through the authenticated real API.
import { createRequire } from 'node:module';
const { chromium } = createRequire('/projects/sandbox/DataCare-Web/web/apps/web/package.json')('playwright');
const WEB = 'http://127.0.0.1:4411';
const b = await chromium.launch(); const page = await (await b.newContext()).newPage();
await page.goto(`${WEB}/login`);
await page.getByLabel('Company Code', { exact: true }).fill('01');
await page.getByLabel('User', { exact: true }).fill('admin');
await page.getByLabel('Password', { exact: true }).fill(process.env.DEMO_PASSWORD);
await page.getByRole('button', { name: 'Sign In', exact: true }).click();
await page.getByRole('button', { name: 'Open', exact: true }).click();
await page.waitForURL('**/dashboard');
const probes = [
  ['POST', '/stock/tag-split', { tagNo: 'X', coBook: 'TSP' }],
  ['POST', '/stock/tag-transfer', { tags: ['X'], coBook: 'TTR' }],
  ['POST', '/stock/tag-cancel', { tags: ['X'] }],
  ['POST', '/stock/tag-weight-diff', { tagNo: 'X' }],
  ['POST', '/sales-returns', { coBook: 'SRT', acCode: 'CUST01', lines: [{ itCode: 'GOLD', netWt: 1, rate: 6000 }] }],
  ['PUT', '/sales-returns/1', { coBook: 'SRT', acCode: 'CUST01', lines: [] }],
  ['GET', '/utilities/year-end/preview', null],
  ['POST', '/backup/restore', {}],
];
for (const [m, u, d] of probes) {
  const r = await page.request.fetch(`${WEB}/api${u}`, { method: m, data: d ?? undefined });
  console.log(m.padEnd(5), u.padEnd(28), r.status(), (await r.text()).replace(/\s+/g, ' ').slice(0, 260));
}
await b.close();
