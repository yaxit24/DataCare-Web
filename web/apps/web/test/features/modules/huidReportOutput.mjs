import assert from 'node:assert/strict';
import { readFile } from 'node:fs/promises';
import { inflateRawSync } from 'node:zlib';
import { USERS } from '../fixtures/catalogue.mjs';
import { cleanHuid, seedHuid } from './huidSeed.mjs';
/**
 * Feature: Report → HuId Report (RP_HUID.cs, /reports/huid), part B, first slice: T04, T05, T11 and T12.
 * Still to write from the frozen list: T15 history.group-renamed-live-master, T16 output (ten ids), T17 keyboard (nine ids).
 * Expected values are the desktop rules applied to huidSeed.mjs, never read back from the app. Selectors follow the
 * WP-18 page contract (buttons by name, labelled inputs, role=grid with data-col cells, role=alert).
 */
const ROUTE = '/reports/huid';
const EXPORT = /\/api\/reports\/huid\/export\.(pdf|csv|xlsx)/;
const ROW = '[role="grid"] [role="row"]:not([data-testid="huid-totals"]):has([data-col="tagNo"])';
const WINDOW = { from: '05/04/2026', to: '30/06/2026' };
const tag = (n) => `TG-${String(n).padStart(3, '0')}`;
/** Gold tags in the window 05/04/2026 to 30/06/2026 (cases.md T02 seed): tag numbers 1 to 6, 10, 12, 13 and 15. */
const GOLD_WINDOW = [1, 2, 3, 4, 5, 6, 10, 12, 13, 15].map(tag);
const NO_PRINT = 'You Have No Print Rights.....';
const GRANTED = [USERS.admin.user, USERS.clerk.user, USERS.printViewer.user];
/** tagNo is the fourth visible In and Stock column (RP_HUID.cs:1761 SELECT order; CoCode is hidden). */
const TAG_AT = 3;
const DELETE_RIGHTS = `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "LC_CODE"='01' AND "SUB_MENU"='HuId Report' AND "USER_NAME" = ANY($2::text[])`;
const GRANT_RIGHTS = `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT") VALUES ($1,'01','01',$2,'Reports','HuId Report','Y','N','N',$3)`;

const as = (user) => ({
  user,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, source, fn) => ({
  id,
  group,
  kind: 'read-only',
  source,
  applicable: true,
  requiredEvidence: ['browser', 'expected'],
  run: (ctx) => withCase(ctx, () => fn(ctx)),
});
const button = (page, name) => page.getByRole('button', { name, exact: true });
const field = (page, name) => page.getByLabel(name, { exact: true });
const focused = (page, name) => field(page, name).evaluate((el) => el === document.activeElement);
const settle = (ms = 750) => new Promise((resolve) => setTimeout(resolve, ms));
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);
/** The HuId rights rows are the only rows this file writes beyond the seed (the catalogue never writes them). */
const cleanRights = (ctx) => exec(ctx, DELETE_RIGHTS, GRANTED);
/** A USER_SET row for the HuId form (menu Reports): view on, print as given. Route rights read this row (authorization.ts). */
const grant = (ctx, user, print) => exec(ctx, GRANT_RIGHTS, user, print);

async function withCase(ctx, fn) {
  await cleanRights(ctx);
  await seedHuid(ctx);
  try {
    return await fn();
  } finally {
    await cleanHuid(ctx);
    await cleanRights(ctx);
  }
}

async function open(page) {
  await page.goto(ROUTE);
  await button(page, 'Stock Tag').waitFor();
}
async function setWindow(page) {
  await field(page, 'From').fill(WINDOW.from);
  await field(page, 'To').fill(WINDOW.to);
}
/** Clicks a view and waits for its API response, so the case reads the result and not the page before it. */
async function runView(page, name) {
  const isReport = (r) =>
    new URL(r.url()).pathname.startsWith('/api/reports/huid') && r.request().method() === 'GET';
  const [res] = await Promise.all([page.waitForResponse(isReport), button(page, name).click()]);
  assert.equal(res.status(), 200, `${name}: report request status`);
}
const readTags = (page) =>
  page
    .locator(ROW)
    .evaluateAll((rows) =>
      rows.map((r) => r.querySelector('[data-col="tagNo"]').textContent.trim()),
    );
/** Polls the grid until it shows the exact tag list, in order, then asserts it. */
async function expectTags(page, want) {
  for (let i = 0; i < 50 && JSON.stringify(await readTags(page)) !== JSON.stringify(want); i += 1)
    await settle(300);
  assert.deepEqual(await readTags(page), want);
}
const noMessage = async (page) =>
  assert.equal(await page.locator('[role="alert"]').count(), 0, 'no message is shown');
const noHelp = async (page) => {
  await settle();
  assert.equal(await page.getByRole('dialog').count(), 0, 'no help list opens');
};
/** A tag must be absent from In, Out and Stock. The grid is awaited first, so an empty stale grid cannot pass. */
async function absentFromViews(page, tagNo) {
  for (const view of ['In Tag', 'Out Tag', 'Stock Tag']) {
    await runView(page, view);
    await page.locator(ROW).first().waitFor();
    const tags = await readTags(page);
    assert.ok(tags.length > 0, `${view} is populated`);
    assert.equal(tags.includes(tagNo), false, `${view}: ${tagNo} must not appear`);
  }
}

/** The Excel file is the download; the CSV of the same query is fetched from its URL (the page has no CSV button). */
async function downloadOf(page, name) {
  const [file] = await Promise.all([page.waitForEvent('download'), button(page, name).click()]);
  return file;
}
const bytesOf = async (download) => readFile(await download.path());
const csvUrl = (url) => url.replace(/\/export\.\w+/, '/export.csv');
const fetchText = (page, url) =>
  page.evaluate(async (u) => {
    const res = await fetch(u, { credentials: 'include' });
    return { status: res.status, body: await res.text() };
  }, url);
const csvTags = (text) =>
  text
    .split(/\r?\n/)
    .map((line) => line.split(',')[TAG_AT]?.replace(/^"|"$/g, '') ?? '')
    .filter((t) => /^TG-/.test(t))
    .sort();

/** Zip entries of an .xlsx, read through the central directory (no xlsx library in the harness). */
function zipEntries(buf) {
  let end = buf.length - 22;
  while (end >= 0 && buf.readUInt32LE(end) !== 0x06054b50) end -= 1;
  let p = buf.readUInt32LE(end + 16);
  const out = {};
  for (let i = 0; i < buf.readUInt16LE(end + 10); i += 1) {
    const nameLen = buf.readUInt16LE(p + 28);
    const at = buf.readUInt32LE(p + 42);
    const start = at + 30 + buf.readUInt16LE(at + 26) + buf.readUInt16LE(at + 28);
    const data = buf.subarray(start, start + buf.readUInt32LE(p + 20));
    const body = buf.readUInt16LE(p + 10) === 8 ? inflateRawSync(data) : data;
    out[buf.toString('utf8', p + 46, p + 46 + nameLen)] = body.toString('utf8');
    p += 46 + nameLen + buf.readUInt16LE(p + 30) + buf.readUInt16LE(p + 32);
  }
  return out;
}
/** Tags held in the workbook: cell and shared-string XML split into text, then matched. */
const xlsxTags = (buf) => {
  const text = Object.values(zipEntries(buf))
    .join('\n')
    .replace(/<[^>]+>/g, '\n');
  return [...new Set(text.match(/TG-[A-Z0-9]+/g) ?? [])].sort();
};
const sheetXml = (buf) =>
  Object.entries(zipEntries(buf))
    .filter(([name]) => name.startsWith('xl/worksheets/'))
    .sort()
    .map(([, xml]) => xml)
    .join('');

/** Lookup, drill-down, scope and rights, and concurrency cases. */
export const outputCases = [
  // T04 Lookup
  C(
    'huid-report.lookup.tag-no-found-focus-stays',
    'T04',
    'RP_HUID.cs:2229 {{if ((int)e.KeyCode != 13)}}',
    async (ctx) => {
      const { page } = await ctx.session();
      await open(page);
      await field(page, 'Tag No').click();
      await page.keyboard.type('TG-005');
      await page.keyboard.press('Enter');
      await noHelp(page);
      assert.equal(await focused(page, 'Tag No'), true, 'focus stays in Tag No');
      return {
        observation: 'TG-005 found: no help list, focus stays',
        expected: { focus: 'Tag No' },
      };
    },
  ),
  C(
    'huid-report.lookup.tag-no-missing-opens-help',
    'T04',
    'RP_HUID.cs:2235 {{if (DC_Main.Rshlp.Rows.Count == 0)}}',
    async (ctx) => {
      const { page } = await ctx.session();
      await open(page);
      await field(page, 'Tag No').click();
      await page.keyboard.type('TG-999');
      await page.keyboard.press('Enter');
      await page.getByRole('dialog').waitFor();
      await noMessage(page);
      await page.getByRole('dialog').getByText('TG-001', { exact: true }).click();
      await page.getByRole('dialog').waitFor({ state: 'hidden' });
      assert.equal(await field(page, 'Tag No').inputValue(), 'TG-001');
      return {
        observation: 'TG-999 opens the tag help; TG-001 fills Tag No',
        expected: { tagNo: 'TG-001' },
      };
    },
  ),
  C(
    'huid-report.lookup.account-found-selects-text',
    'T04',
    'RP_HUID.cs:2729 {{((TextBoxBase)tAcCode).SelectAll();}}',
    async (ctx) => {
      const { page } = await ctx.session();
      await open(page);
      await field(page, 'Ac Code').click();
      await page.keyboard.type('V1');
      await page.keyboard.press('Enter');
      await noHelp(page);
      const selected = await field(page, 'Ac Code').evaluate(
        (el) => el.value === 'V1' && el.selectionStart === 0 && el.selectionEnd === el.value.length,
      );
      assert.equal(selected, true, 'the AcCode text is selected');
      return {
        observation: 'V1 found: no help list, text selected',
        expected: { acCode: 'V1', selected: true },
      };
    },
  ),
  C(
    'huid-report.lookup.account-missing-opens-help',
    'T04',
    'RP_HUID.cs:2722 {{tAcCode.Text = DC_Main.ColValue[1];}}',
    async (ctx) => {
      const { page } = await ctx.session();
      await open(page);
      await field(page, 'Ac Code').click();
      await page.keyboard.type('X999');
      await page.keyboard.press('Enter');
      await page.getByRole('dialog').waitFor();
      await noMessage(page);
      await page.getByRole('dialog').getByText('V2', { exact: true }).click();
      await page.getByRole('dialog').waitFor({ state: 'hidden' });
      assert.equal(await field(page, 'Ac Code').inputValue(), 'V2');
      assert.equal(await focused(page, 'Ac Code'), true, 'AcCode is refocused');
      return {
        observation: 'X999 opens the account help; V2 fills and focuses AcCode',
        expected: { acCode: 'V2' },
      };
    },
  ),
  C(
    'huid-report.lookup.account-filter-in-view',
    'T04',
    "RP_HUID.cs:1788 {{AND C.AC_CODE =  '}}",
    async (ctx) => {
      const { page } = await ctx.session();
      await open(page);
      await setWindow(page);
      await field(page, 'Ac Code').fill('V1');
      await runView(page, 'In Tag');
      await expectTags(page, [tag(1)]);
      return {
        observation: 'Ac Code V1 in the In view lists TG-001 only',
        expected: { tags: ['TG-001'] },
      };
    },
  ),

  // T05 Children: blocked for this package (supervisor decision); no assertions.
  {
    ...C(
      'huid-report.drill.double-click-opens-source-voucher',
      'T05',
      'RP_HUID.cs:2272 {{DC_Main.CurBookVch = ((ColumnView)GridView1).GetFocusedRowCellValue("VchNo")}}',
      async () => {
        throw new Error('blocked: not run');
      },
    ),
    blocked:
      'Blocked for this package (supervisor decision, 16 November 2026): the target voucher screens were not traced in the study (open question 4) and no drill-down handler is built.',
  },

  // T11 Scope and rights
  C(
    'huid-report.scope.other-company-never-appears',
    'T11',
    'RP_HUID.cs:1761 {{SELECT C.CO_CODE As CoCode,C.VCH_TYPE As VchTyp}}',
    async (ctx) => {
      const { page } = await ctx.session();
      await open(page);
      await setWindow(page);
      await absentFromViews(page, 'TG-S1');
      await runView(page, 'In Tag');
      const file = await downloadOf(page, 'Excel');
      const { status, body } = await fetchText(page, csvUrl(file.url()));
      assert.equal(status, 200, 'CSV status');
      assert.equal(csvTags(body).includes('TG-S1'), false, 'the CSV has no TG-S1');
      return {
        observation: 'TG-S1 (company 02) absent from In, Out, Stock and the CSV',
        expected: { absent: 'TG-S1' },
      };
    },
  ),
  C(
    'huid-report.scope.other-location-never-appears',
    'T11',
    "RP_HUID.cs:1761 {{AND C.LC_CODE = '}}",
    async (ctx) => {
      const { page } = await ctx.session();
      await open(page);
      await setWindow(page);
      await absentFromViews(page, 'TG-S2');
      return {
        observation: 'TG-S2 (location 02) absent from In, Out and Stock',
        expected: { absent: 'TG-S2' },
      };
    },
  ),
  C(
    'huid-report.scope.prior-year-tag-never-appears',
    'T11',
    "RP_HUID.cs:1838 {{AND A.CO_YEAR = '}}",
    async (ctx) => {
      const { page } = await ctx.session();
      await open(page);
      await setWindow(page);
      await absentFromViews(page, 'TG-009');
      return {
        observation: 'TG-009 (2025-2026) absent from In, Out and Stock',
        expected: { absent: 'TG-009' },
      };
    },
  ),
  C(
    'huid-report.rights.print-refused-without-print-right',
    'T11',
    'RP_HUID.cs:2189 {{private void BtnPrint_Click(object sender, EventArgs e)}}',
    async (ctx) => {
      await grant(ctx, USERS.printViewer.user, 'N');
      const { page } = await ctx.session(as(USERS.printViewer.user));
      await open(page);
      await setWindow(page);
      await runView(page, 'In Tag');
      const refused = async (name) => {
        const [res] = await Promise.all([
          page.waitForResponse((r) => EXPORT.test(r.url())),
          button(page, name).click(),
        ]);
        assert.equal(res.status(), 403, `${name} is refused`);
        assert.deepEqual(JSON.parse(await res.text()), { error: 'forbidden', action: 'print' });
        return res;
      };
      const pdf = await refused('Print');
      await refused('Excel');
      // The CSV of the same query is refused too (no CSV button in the page contract).
      const csv = await fetchText(page, csvUrl(pdf.url()));
      assert.equal(csv.status, 403, 'CSV is refused');
      assert.deepEqual(JSON.parse(csv.body), { error: 'forbidden', action: 'print' });
      return {
        observation: 'PDF, Excel and CSV refused with 403 forbidden/print',
        expected: { status: 403 },
      };
    },
  ),
  C(
    'huid-report.rights.print-refusal-text',
    'T11',
    'RP_HUID.cs:1361 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}',
    async (ctx) => {
      await grant(ctx, USERS.printViewer.user, 'N');
      const { page } = await ctx.session(as(USERS.printViewer.user));
      await open(page);
      await setWindow(page);
      await runView(page, 'In Tag');
      await expectTags(page, GOLD_WINDOW);
      await Promise.all([
        page.waitForResponse((r) => EXPORT.test(r.url())),
        button(page, 'Excel').click(),
      ]);
      const alert = page.getByRole('alert').filter({ hasText: NO_PRINT });
      await alert.first().waitFor();
      assert.equal((await alert.first().innerText()).trim(), NO_PRINT);
      await expectTags(page, GOLD_WINDOW);
      return {
        observation: 'Excel without the print right shows the desktop text; grid unchanged',
        expected: { rows: 10 },
      };
    },
  ),

  // T12 Concurrency
  C(
    'huid-report.concurrency.two-users-export-independent',
    'T12',
    'RP_HUID.cs:2168 {{DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE}}',
    async (ctx) => {
      await grant(ctx, USERS.clerk.user, 'Y');
      const a = await ctx.session(as(USERS.admin.user));
      const b = await ctx.session(as(USERS.clerk.user));
      for (const { page } of [a, b]) {
        await open(page);
        await setWindow(page);
        await runView(page, 'In Tag');
        await expectTags(page, GOLD_WINDOW);
      }
      const [fileA, fileB] = await Promise.all([
        downloadOf(a.page, 'Excel'),
        downloadOf(b.page, 'Excel'),
      ]);
      const [bytesA, bytesB] = [await bytesOf(fileA), await bytesOf(fileB)];
      assert.deepEqual(
        xlsxTags(bytesA),
        [...GOLD_WINDOW].sort(),
        'user one file holds the 10 rows',
      );
      assert.deepEqual(
        xlsxTags(bytesB),
        [...GOLD_WINDOW].sort(),
        'user two file holds the 10 rows',
      );
      assert.equal(sheetXml(bytesA), sheetXml(bytesB), 'both sheets are identical');
      return {
        observation: 'both exports hold the same 10 rows and sheet data',
        expected: { rows: 10 },
      };
    },
  ),
];
