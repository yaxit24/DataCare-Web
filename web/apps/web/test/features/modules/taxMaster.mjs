import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, ITEMS, PARTIES, USERS } from '../fixtures/catalogue.mjs';
import { SECOND_TENANT } from '../harness.mjs';

/**
 * Feature: Master → Tax (desktop MS_TAX, web /masters/taxes).
 *
 * Desktop rules used for the expected values (MS_TAX.cs unless noted):
 * - The menu button 'Tax' opens MS_TAX directly (MDI_FORM.cs:7670-7679). The list is TAX_MAST's header rows (SR_NO 0)
 *   ordered by TAX_CODE (CLEAR_DATA :1608); a new entry has blank boxes, one empty grid row, SEARCH RECORD and the cursor
 *   in the code (Tax Type).
 * - Save (:1824-1933): an opened code needs the edit right ("You Have No Rights....."); a blank code says "Enter Tax
 *   Code." and a blank name "Enter Tax Name."; the code's rows are replaced by the header (SR_NO 0, TAX_GROUP 'N', Val of
 *   Tax % and Add Tax %, the account) and one row per grid row with a non-zero Tax % (:1886), SR_NO = the grid row
 *   (:1889), with the header's Add Tax %; MAIN_USER is not written; then "Data Are Saved." and a new entry.
 * - Leaving the code refuses a code another tax has (:1720-1740); leaving the name, a name another code has
 *   (:1761-1781); Enter on a blank name says "Please Insert Tax Name ..." (:1742-1759); typed keys are upper-cased and
 *   the apostrophe refused (:1689-1702).
 * - Keys: Enter on Tax % and Add Tax % shows Val as 0.00 (:2004-2024); Enter on Ac Code takes a found code and goes to
 *   row 1 of the grid, else opens the help of group 12 and 00013 (:2026-2063); in the grid Enter moves right, a found Ac
 *   Code moves to Tax %, Enter on Tax % shows 0.000 and goes to the next row, on the last row adds one or with a blank
 *   Tax % goes to Save (:1200-1310); Esc leaves (:1806-1814); in the list Enter opens a code, F1 goes to the search box.
 * - Delete (:1935-1956): "Please Select Tax Code For Delete.", "Are You Sure To Delete This Record now?", every row of
 *   the code deleted, "Delete Success.".
 * - A sale posts its tax to the code's header account and reads the components by SR_NO (taxPolicy, Ac_Ledr).
 * Web rules that differ on purpose (gap G226): one transaction; an opened code's components shown at their SR_NO rows;
 * version tokens; unknown accounts refused; Print lists the codes on screen.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `tax-master.${id}`,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence:
    kind === 'mutation'
      ? ['browser', 'expected', 'database', 'downstream']
      : kind === 'refusal'
        ? ['browser', 'expected', 'database']
        : kind === 'output'
          ? ['browser', 'expected', 'output']
          : ['browser', 'expected'],
  run,
  ...extra,
});

const API = '/masters/tax-master';
const SAVED = 'Data Are Saved.';
const CONFLICT =
  'This tax code was changed by someone else after you opened it. Open it again before saving or deleting.';
/** The seeded codes of a provisioned company (seedCompany TAXES), as the list shows them. */
const SEEDED = [
  ['00', 'TAX FREE'],
  ['10', 'GST 3%'],
  ['11', 'GST 5%'],
  ['12', 'GST 12%'],
  ['13', 'GST 18%'],
  ['14', 'GST 28%'],
  ['20', 'TCS 0.1%'],
];
/** The desktop template's tax accounts (group 12) and TDS (00013); the case codes only ever use these. */
const ACCOUNTS = [
  ['TXGST', 'TX GST TAX', '12'],
  ['TXCGS', 'TX CGST TAX', '12'],
  ['TXIGS', 'TX IGST TAX', '12'],
  ['00013', 'TX TDS A/C', '18'],
  ['TXOTH', 'TX OTHER A/C', '22'],
];
/** Codes the cases create; none shares a seeded rate, so the sales of other modules keep resolving their codes. */
const CASE_CODES = ['15', '16', '17', '18', '19'];

const path = (r) => new URL(r.url()).pathname;
const isApi = (r, method, p) => r.request().method() === method && path(r) === `/api${p}`;
const label = (page, text) => page.getByLabel(text, { exact: true });
const button = (page, name) => page.getByRole('button', { name, exact: true });
const focusedId = (page) =>
  page.evaluate(
    () => document.activeElement?.id || document.activeElement?.getAttribute('aria-label') || '',
  );
const message = (page, text) => page.getByText(text, { exact: true }).waitFor();
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);
const cell = (page, header, row) => label(page, `${header} row ${row}`);

const taxRows = (ctx, code) =>
  ctx.rows(
    `SELECT coalesce("SR_NO",0)::float sr,"TAX_GROUP" grp,"TAX_NAME" name,"TAX_PRC"::float pct,
            coalesce("ADD_TAX_PRC",0)::float "add",coalesce("TAX_AC",'') ac,"MAIN_USER" main
       FROM "TAX_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "TAX_CODE"=$2 ORDER BY coalesce("SR_NO",0),row_id`,
    code,
  );
const allTaxes = (ctx) =>
  ctx.rows(
    `SELECT "TAX_CODE" code,coalesce("SR_NO",0)::float sr,row_id::text rid FROM "TAX_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "TAX_CODE",coalesce("SR_NO",0),row_id`,
  );

async function cleanCodes(ctx) {
  await exec(
    ctx,
    `DELETE FROM "TAX_MAST" WHERE tenant_id=$1 AND "TAX_CODE" = ANY($2::text[])`,
    CASE_CODES,
  );
}
/** Insert a code as the desktop writes it, for a case that opens an existing code. */
async function seedCode(ctx, code, name, pct, components = [], extra = {}) {
  await exec(
    ctx,
    `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","ADD_TAX_PRC","TAX_AC","MAIN_USER")
     VALUES ($1,'01',$2,0,'N',$3,$4,$5,$6,$7)`,
    code,
    name,
    pct,
    extra.add ?? 0,
    extra.ac ?? 'TXGST',
    extra.main ?? null,
  );
  for (const c of components)
    await exec(
      ctx,
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","ADD_TAX_PRC","TAX_AC","MAIN_USER")
       VALUES ($1,'01',$2,$3,$4,$5,$6,$7,$8,$9)`,
      code,
      c.sr,
      c.grp,
      c.name,
      c.pct,
      extra.add ?? 0,
      c.ac,
      extra.main ?? null,
    );
}
async function withAccounts(ctx, run) {
  const added = [];
  for (const [code, name, group] of ACCOUNTS) {
    const inserted = await exec(
      ctx,
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR")
       SELECT $1::text,'01','01',$2::text,$3::text,$4::text
        WHERE NOT EXISTS (SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "AC_CODE"=$2::text)`,
      code,
      name,
      group,
    );
    if (inserted) added.push(code);
  }
  await cleanCodes(ctx);
  try {
    return await run();
  } finally {
    await cleanCodes(ctx);
    await exec(
      ctx,
      `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE" = ANY($2::text[])`,
      added,
    );
  }
}

async function openScreen(page) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', API)),
    page.goto('/masters/taxes'),
  ]);
  await page.getByRole('heading', { name: 'Tax Master', exact: true }).waitFor();
  if (response.status() === 200)
    await page.waitForFunction(() => document.activeElement?.id === 'tax-code');
  return response;
}
const listed = (page) =>
  page
    .getByTestId('tax-list')
    .locator('tr')
    .evaluateAll((rows) =>
      rows.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
    );
async function openCode(page, code, how = 'enter') {
  const row = page.getByTestId('tax-list').locator(`tr[data-code="${code}"]`);
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `${API}/${code}`)),
    how === 'enter' ? row.press('Enter') : row.dblclick(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.waitForFunction(
    ([c, focus]) => {
      const box = document.querySelector('#tax-code');
      return box?.value === c && box.readOnly && document.activeElement?.id === focus;
    },
    [code, how === 'enter' ? 'tax-name' : 'tax-code'],
  );
  return response.json();
}
const header = async (page) => ({
  code: await label(page, 'Tax Type').inputValue(),
  name: await label(page, 'Tax Desc').inputValue(),
  pct: await label(page, 'Tax %').inputValue(),
  addPct: await label(page, 'Add Tax %').inputValue(),
  account: await label(page, 'Ac Code').inputValue(),
  accountName: await label(page, 'Account Name').inputValue(),
  codeReadOnly: await label(page, 'Tax Type').evaluate((el) => el.readOnly),
});
const grid = (page) =>
  page
    .getByTestId('tax-components')
    .locator('tr')
    .evaluateAll((rows) =>
      rows.map((tr) =>
        [...tr.querySelectorAll('td')].map((td) =>
          (td.querySelector('input')?.value ?? td.textContent).trim(),
        ),
      ),
    );
/** Fill a grid row by its cells (no keys), as typed text. */
async function fillComponent(page, row, values) {
  const map = { taxType: 'Tax Type', name: 'Tax Name', account: 'Ac Code', pct: 'Tax %' };
  for (const [key, value] of Object.entries(values)) await cell(page, map[key], row).fill(value);
}
async function save(page, trigger = () => button(page, 'Save').click()) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => ['POST', 'PUT'].includes(r.request().method()) && path(r).startsWith(`/api${API}`),
    ),
    trigger(),
  ]);
  return response;
}
/** A saved entry: "Data Are Saved." and a new entry with the cursor in the code (CLEAR_DATA). */
async function saved(page) {
  await message(page, SAVED);
  await page.waitForFunction(
    () =>
      document.activeElement?.id === 'tax-code' &&
      !document.querySelector('#tax-code')?.readOnly &&
      document.querySelector('#tax-code')?.value === '',
  );
}
/** Fill the header boxes without keys. */
async function fillHeader(page, values) {
  if (values.code !== undefined) await label(page, 'Tax Type').fill(values.code);
  if (values.name !== undefined) await label(page, 'Tax Desc').fill(values.name);
  if (values.pct !== undefined) await label(page, 'Tax %').fill(values.pct);
  if (values.addPct !== undefined) await label(page, 'Add Tax %').fill(values.addPct);
  if (values.account !== undefined) await label(page, 'Ac Code').fill(values.account);
}
const gstComponents = (half, full) => [
  { taxType: 'SGST', name: `SGST ${half}%`, account: 'TXGST', pct: half },
  { taxType: 'CGST', name: `CGST ${half}%`, account: 'TXCGS', pct: half },
  { taxType: 'IGST', name: `IGST ${full}%`, account: 'TXIGS', pct: full },
];
/** Type the components through the grid's cells, adding a row with Enter on the last Tax %. */
async function enterComponents(page, components) {
  for (const [i, c] of components.entries()) {
    const row = i + 1;
    await cell(page, 'Tax Type', row).waitFor();
    await fillComponent(page, row, c);
    if (i < components.length - 1) {
      await cell(page, 'Tax %', row).press('Enter');
      await cell(page, 'Tax Type', row + 1).waitFor();
    }
  }
}

export const taxMaster = {
  feature: 'tax-master',
  title: 'Master → Tax (MS_TAX)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/masters/taxes/page.tsx',
    'web/apps/api/src/modules/masters/taxMaster.ts',
    'web/apps/api/src/routes/taxMaster.ts',
    'web/apps/api/src/modules/masters/master.service.ts',
    'web/apps/web/test/features/modules/taxMaster.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'MDI_FORM.cs:7670-7679 opens MS_TAX; CLEAR_DATA (:1590-1614) blank boxes, one grid row, SEARCH RECORD, cursor in the code; the list is the header rows by code (:1608); MSG_CLEAR (:1094-1129) Sr / Tax Type / Tax Name / Ac Code / Tax %; the form spec layout and tab order',
      async (ctx) => {
        await cleanCodes(ctx);
        const { page } = await ctx.session();
        await openScreen(page);
        const first = await header(page);
        assert.deepEqual(first, {
          code: '',
          name: '',
          pct: '',
          addPct: '',
          account: '',
          accountName: '',
          codeReadOnly: false,
        });
        assert.equal(await label(page, 'Tax Type').getAttribute('maxlength'), '2');
        assert.equal(await label(page, 'Tax Desc').getAttribute('maxlength'), '40');
        assert.equal(await label(page, 'Search record').inputValue(), 'SEARCH RECORD');
        const list = await listed(page);
        assert.deepEqual(list, SEEDED);
        const gridHeaders = (
          await page
            .getByTestId('tax-components')
            .locator('xpath=..')
            .locator('thead th')
            .allInnerTexts()
        ).map((t) => t.trim());
        assert.deepEqual(gridHeaders, ['Sr', 'Tax Type', 'Tax Name', 'Ac Code', 'Tax %']);
        assert.deepEqual(await grid(page), [['1', '', '', '', '']]);
        const order = await page.evaluate(() =>
          [
            ...document.querySelectorAll(
              'input:not([tabindex="-1"]),button,[data-testid="tax-list"] tr',
            ),
          ].map(
            (el) =>
              el.id ||
              el.getAttribute('aria-label') ||
              (el.tagName === 'TR' ? 'list' : el.textContent.trim()),
          ),
        );
        const boxes = [
          'tax-code',
          'tax-name',
          'tax-pct',
          'tax-add-pct',
          'Ac Code',
          'Tax Type row 1',
        ];
        assert.deepEqual(
          order.filter((n) => boxes.includes(n)),
          boxes,
        );
        assert.ok(
          order.indexOf('Tax % row 1') < order.indexOf('Save') &&
            order.indexOf('Exit') < order.indexOf('Search record') &&
            order.indexOf('Search record') < order.indexOf('list'),
          `boxes, grid, buttons, search, list: ${order.join(' > ')}`,
        );
        const drawn = [];
        for (const name of ['Save', 'Print', 'Cancel', 'Delete', 'Exit'])
          drawn.push([name, (await button(page, name).boundingBox()).x]);
        assert.deepEqual(
          drawn.sort((a, b) => a[1] - b[1]).map(([n]) => n),
          ['Print', 'Save', 'Cancel', 'Delete', 'Exit'],
        );
        const listBox = await page.getByTestId('tax-list').boundingBox();
        const codeBox = await label(page, 'Tax Type').boundingBox();
        assert.ok(listBox.x < codeBox.x, 'the list is drawn left of the boxes');
        return {
          observation: `blank entry, cursor in the code, ${list.length} seeded codes by code, grid headers ${gridHeaders.join('/')}`,
          expected: {
            list: SEEDED,
            grid: [['1', '', '', '', '']],
            drawn: 'Print Save Cancel Delete Exit',
          },
        };
      },
    ),
    C(
      'field.every-field',
      'T02',
      'mutation',
      'BtnSave_Click (:1866-1906) stores the header (TAX_CODE, TAX_NAME, TAX_GROUP N, TAX_PRC, ADD_TAX_PRC, TAX_AC) and each grid row (SR_NO, TAX_GROUP, TAX_NAME, TAX_AC, TAX_PRC, the Add Tax %); DISPLAY_DATA (:1616-1668) shows them again',
      async (ctx) =>
        withAccounts(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await fillHeader(page, {
            code: '15',
            name: "gst 1.5% o'nly",
            pct: '1.5',
            addPct: '0.25',
            account: 'TXGST',
          });
          await label(page, 'Ac Code').press('Enter');
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Tax Type row 1',
          );
          assert.equal(await label(page, 'Account Name').inputValue(), 'TX GST TAX');
          await enterComponents(page, gstComponents('0.75', '1.5'));
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          const rows = await taxRows(ctx, '15');
          assert.deepEqual(rows, [
            {
              sr: 0,
              grp: 'N',
              name: 'GST 1.5% ONLY',
              pct: 1.5,
              add: 0.25,
              ac: 'TXGST',
              main: null,
            },
            {
              sr: 1,
              grp: 'SGST',
              name: 'SGST 0.75%',
              pct: 0.75,
              add: 0.25,
              ac: 'TXGST',
              main: null,
            },
            {
              sr: 2,
              grp: 'CGST',
              name: 'CGST 0.75%',
              pct: 0.75,
              add: 0.25,
              ac: 'TXCGS',
              main: null,
            },
            { sr: 3, grp: 'IGST', name: 'IGST 1.5%', pct: 1.5, add: 0.25, ac: 'TXIGS', main: null },
          ]);
          await openCode(page, '15');
          const shown = { header: await header(page), grid: await grid(page) };
          assert.deepEqual(shown, {
            header: {
              code: '15',
              name: 'GST 1.5% ONLY',
              pct: '1.50',
              addPct: '0.25',
              account: 'TXGST',
              accountName: 'TX GST TAX',
              codeReadOnly: true,
            },
            grid: [
              ['1', 'SGST', 'SGST 0.75%', 'TXGST', '0.750'],
              ['2', 'CGST', 'CGST 0.75%', 'TXCGS', '0.750'],
              ['3', 'IGST', 'IGST 1.5%', 'TXIGS', '1.500'],
              ['4', '', '', '', ''],
            ],
          });
          return {
            observation: `saved 15 with 3 components and reopened it: ${JSON.stringify(shown.header)}`,
            expected:
              'every typed value upper-cased, Val of the numbers, the header Add Tax % on every row',
            database: { rows },
            downstream: { reopened: shown },
          };
        }),
    ),
    C(
      'formula.val-format-and-sr-no',
      'T03',
      'mutation',
      'nTaxPrc_KeyDown / nAddTaxPrc_KeyDown: Format(Val, "0.00") on Enter (:2004-2024); MSG_LeaveCell / TEXT_ENTRY_KeyDown: Tax % as "0.000" (:1178-1198, :1281-1297); Save skips a 0% row but keeps SR_NO = the grid row (:1886-1889)',
      async (ctx) =>
        withAccounts(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const shown = {};
          for (const [box, value] of [
            ['Tax %', '2.345'],
            ['Tax %', ' 7 pc'],
            ['Tax %', 'ABC'],
            ['Add Tax %', '0.5'],
          ]) {
            await label(page, box).fill(value);
            await label(page, box).press('Enter');
            shown[`${box} ${value}`] = await label(page, box).inputValue();
          }
          assert.deepEqual(shown, {
            'Tax % 2.345': '2.35',
            'Tax %  7 pc': '7.00',
            'Tax % ABC': '0.00',
            'Add Tax % 0.5': '0.50',
          });
          await fillHeader(page, { code: '16', name: 'CESS 2%', pct: '2', account: 'TXGST' });
          await enterComponents(page, [
            { taxType: 'SGST', name: 'SGST 1%', account: 'TXGST', pct: '1' },
            { taxType: 'CGST', name: 'CGST NIL', account: 'TXCGS', pct: '0' },
            { taxType: 'IGST', name: 'IGST 2%', account: 'TXIGS', pct: '2' },
          ]);
          await cell(page, 'Tax %', 1).click();
          await cell(page, 'Tax %', 3).click();
          const formatted = [
            await cell(page, 'Tax %', 1).inputValue(),
            await cell(page, 'Tax %', 2).inputValue(),
          ];
          assert.deepEqual(formatted, ['1.000', '0.000']);
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          const rows = await taxRows(ctx, '16');
          assert.deepEqual(
            rows.map((r) => [r.sr, r.grp, r.pct, r.add]),
            [
              [0, 'N', 2, 0.5],
              [1, 'SGST', 1, 0.5],
              [3, 'IGST', 2, 0.5],
            ],
          );
          // The reopened grid keeps IGST at its SR_NO row (G226), so an unchanged save leaves it at 3.
          await openCode(page, '16');
          const reopened = await grid(page);
          assert.deepEqual(reopened, [
            ['1', 'SGST', 'SGST 1%', 'TXGST', '1.000'],
            ['2', '', '', '', ''],
            ['3', 'IGST', 'IGST 2%', 'TXIGS', '2.000'],
            ['4', '', '', '', ''],
          ]);
          const again = await save(page);
          assert.equal(again.status(), 200, await again.text());
          await saved(page);
          const after = (await taxRows(ctx, '16')).map((r) => r.sr);
          assert.deepEqual(after, [0, 1, 3]);
          return {
            observation: `Enter showed ${JSON.stringify(shown)}; stored SR_NO ${rows.map((r) => r.sr)}; after reopen and save ${after}`,
            expected: 'Val then 0.00/0.000; the 0% row skipped; IGST stays at SR_NO 3',
            database: { rows },
            downstream: { reopened, after },
          };
        }),
    ),
    C(
      'lookup.account-help',
      'T04',
      'read-only',
      "tTaxAcCode_KeyDown (:2026-2063): an AC_MAST code is taken whatever its group, else the help lists AC_GR = '12' OR AC_CODE = '00013' by AC_NAME (:2039); the grid's Ac Code help lists every account by name (:1252)",
      async (ctx) =>
        withAccounts(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const box = label(page, 'Ac Code');
          await box.fill('TX');
          await page.waitForResponse((r) => path(r) === `/api${API}/accounts`);
          const help = page.locator('[data-lookup-open="true"] b');
          await page.waitForFunction(
            () => document.querySelectorAll('[data-lookup-open="true"] b').length > 0,
          );
          const headerHelp = (await help.allInnerTexts()).map((t) => t.trim());
          assert.deepEqual(
            headerHelp,
            ['TXCGS', 'TXGST', 'TXIGS', '00013'],
            'group 12 and 00013 by name',
          );
          // Typing an existing code ('GST', the provisioned output account) and choosing another row keeps the choice.
          await box.fill('GST');
          await page.waitForResponse((r) => path(r) === `/api${API}/accounts`);
          await page.waitForFunction(
            () => document.querySelectorAll('[data-lookup-open="true"] b').length > 1,
          );
          const gstHelp = (await help.allInnerTexts()).map((t) => t.trim());
          assert.equal(gstHelp[0], 'GST', 'the exact code comes first');
          for (let i = 0; i < gstHelp.indexOf('TXGST'); i++) await box.press('ArrowDown');
          await box.press('Enter');
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Tax Type row 1',
          );
          await page.waitForTimeout(500);
          assert.deepEqual(
            [await box.inputValue(), await label(page, 'Account Name').inputValue()],
            ['TXGST', 'TX GST TAX'],
            'the chosen row stands over the typed exact code',
          );
          // A typed code of another group is taken.
          await box.fill('TXOTH');
          await page.waitForResponse((r) => path(r) === `/api${API}/accounts`);
          await box.press('Enter');
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Tax Type row 1',
          );
          assert.equal(await label(page, 'Account Name').inputValue(), 'TX OTHER A/C');
          // The grid's help lists every account, any group.
          const gridBox = cell(page, 'Ac Code', 1);
          await gridBox.fill('TXOT');
          await page.waitForResponse((r) => path(r) === `/api${API}/accounts`);
          await page.waitForFunction(
            () => document.querySelectorAll('[data-lookup-open="true"] b').length > 0,
          );
          const gridHelp = (await help.allInnerTexts()).map((t) => t.trim());
          assert.deepEqual(gridHelp, ['TXOTH']);
          await gridBox.press('Enter');
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Tax % row 1',
          );
          return {
            observation: `header help ${headerHelp.join(', ')}; typed TXOTH taken; grid help ${gridHelp.join(', ')}`,
            expected: { header: ['TXCGS', 'TXGST', 'TXIGS', '00013'], grid: ['TXOTH'] },
          };
        }),
    ),
    C(
      'children.components',
      'T05',
      'mutation',
      "The grid's rows are the code's components: Enter on the last Tax % adds a row (:1281-1290), a blank Tax % on the last row goes to Save; Save replaces every row of the code and a row cleared to 0 is dropped (:1864-1906)",
      async (ctx) =>
        withAccounts(ctx, async () => {
          await seedCode(ctx, '17', 'LEVY 4%', 4, [
            { sr: 1, grp: 'SGST', name: 'SGST 2%', pct: 2, ac: 'TXGST' },
            { sr: 2, grp: 'CGST', name: 'CGST 2%', pct: 2, ac: 'TXCGS' },
          ]);
          await seedCode(ctx, '18', 'OTHER LEVY 6%', 6, [
            { sr: 1, grp: 'IGST', name: 'IGST 6%', pct: 6, ac: 'TXIGS' },
          ]);
          const otherBefore = await taxRows(ctx, '18');
          const { page } = await ctx.session();
          await openScreen(page);
          await openCode(page, '17');
          // Add IGST in the empty third row, then clear CGST.
          await fillComponent(page, 3, {
            taxType: 'IGST',
            name: 'IGST 4%',
            account: 'TXIGS',
            pct: '4',
          });
          await cell(page, 'Tax %', 3).press('Enter');
          await cell(page, 'Tax Type', 4).waitFor();
          await cell(page, 'Tax %', 4).click();
          await cell(page, 'Tax %', 4).press('Enter');
          assert.equal(
            await page.evaluate(() => document.activeElement?.textContent?.trim()),
            'Save',
          );
          await cell(page, 'Tax %', 2).fill('0');
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const rows = await taxRows(ctx, '17');
          assert.deepEqual(
            rows.map((r) => [r.sr, r.grp, r.pct, r.ac]),
            [
              [0, 'N', 4, 'TXGST'],
              [1, 'SGST', 2, 'TXGST'],
              [3, 'IGST', 4, 'TXIGS'],
            ],
          );
          assert.deepEqual(await taxRows(ctx, '18'), otherBefore, 'another code keeps its rows');
          return {
            observation: `17 now SR_NO ${rows.map((r) => r.sr)}; 18 unchanged`,
            expected: 'IGST added at row 3, CGST dropped, other codes untouched',
            database: { rows },
            downstream: { other: otherBefore },
          };
        }),
    ),
    C(
      'required.refusals',
      'T06',
      'refusal',
      'BtnSave_Click (:1852-1862), tTaxName_KeyDown (:1751), tTaxCode_Validating (:1730), tTaxName_Validating (:1771); the web also refuses an unknown account and the lengths (G226)',
      async (ctx) =>
        withAccounts(ctx, async () => {
          const before = await allTaxes(ctx);
          const { page, requests } = await ctx.session();
          await openScreen(page);
          await button(page, 'Save').click();
          await message(page, 'Enter Tax Code.');
          await label(page, 'Tax Type').fill('15');
          await button(page, 'Save').click();
          await message(page, 'Enter Tax Name.');
          await label(page, 'Tax Desc').press('Enter');
          await message(page, 'Please Insert Tax Name ...');
          await page.waitForFunction(() => document.activeElement?.id === 'tax-name');
          // Leaving the code box with another tax's code is refused at once (Validating cancels, :1720-1740).
          await label(page, 'Tax Type').fill('10');
          await label(page, 'Tax Type').press('Tab');
          await message(
            page,
            "This Tax Code already Exist in  'GST 3%'  Tax Name...Please Change Tax Code...",
          );
          await page.waitForFunction(() => document.activeElement?.id === 'tax-code');
          await label(page, 'Tax Type').fill('15');
          await label(page, 'Tax Desc').fill("gst 5'%");
          await label(page, 'Tax Desc').press('Tab');
          await message(
            page,
            "This Tax Name already Exist in  '11'  Tax Code...Please Change Tax Name...",
          );
          await page.waitForFunction(() => document.activeElement?.id === 'tax-name');
          assert.equal(
            requests.filter((r) => ['POST', 'PUT'].includes(r.method)).length,
            0,
            'nothing was sent',
          );
          const direct = [];
          for (const [payload, text] of [
            [
              { code: '15', name: 'NEW', account: 'ZZZZ' },
              'account ZZZZ of the tax is not in the account master',
            ],
            [
              {
                code: '15',
                name: 'NEW',
                components: [{ taxType: 'SGST', account: 'NOPE', pct: '1' }],
              },
              'account NOPE of row 1 is not in the account master',
            ],
            [{ code: '151', name: 'NEW' }, 'tax code must be 1 or 2 characters'],
            [{ code: '15', name: 'N'.repeat(41) }, 'tax name must be at most 40 characters'],
          ]) {
            const response = await page.request.post(`/api${API}`, { data: payload });
            assert.equal(response.status(), 400, await response.text());
            assert.equal((await response.json()).message, text);
            direct.push(response.status());
          }
          const after = await allTaxes(ctx);
          assert.deepEqual(after, before);
          return {
            observation: `the screen refused with the desktop texts; direct posts answered ${direct.join(', ')}`,
            expected: 'desktop texts, the cursor kept, 400 for the web refusals, no row written',
            database: { before, after },
          };
        }),
    ),
    C(
      'create.footprint',
      'T07',
      'mutation',
      'BtnSave_Click: the header and component rows only (no MAIN_USER), "Data Are Saved." and a new entry with the list read again; a sale resolves the new code by its rate (taxPolicy)',
      async (ctx) =>
        withAccounts(ctx, async () => {
          const before = await allTaxes(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          await fillHeader(page, { code: '19', name: 'GST 0.5%', pct: '0.5', account: 'TXGST' });
          await enterComponents(page, gstComponents('0.25', '0.5'));
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          assert.deepEqual(await response.json(), { code: '19', components: 3 });
          await saved(page);
          const after = await allTaxes(ctx);
          assert.equal(after.length, before.length + 4, 'one header and three components added');
          assert.deepEqual(
            after.filter((r) => r.code !== '19'),
            before,
            'no other row changed',
          );
          const list = await listed(page);
          assert.deepEqual(list.at(-2), ['19', 'GST 0.5%'], 'the list is read again by code');
          const generic = await (await page.request.get('/api/masters/taxes?limit=500')).json();
          const genericRows = (generic.rows ?? generic).filter((r) => r.TAX_CODE === '19');
          assert.equal(genericRows.length, 4, 'the generic read lists the four rows');
          return {
            observation: `created 19 with 3 components; list ${JSON.stringify(list.at(-2))}`,
            expected: '4 new rows, nothing else changed',
            database: { rows: await taxRows(ctx, '19') },
            downstream: { list, genericRows: genericRows.length },
          };
        }),
    ),
    C(
      'reopen.unchanged-save',
      'T08',
      'mutation',
      "DISPLAY_DATA (:1616-1668) shows a code the desktop template wrote (MAIN_USER 'ABC'); an unchanged Save writes the same rows again without MAIN_USER, as BtnSave_Click does (:1866-1906)",
      async (ctx) =>
        withAccounts(ctx, async () => {
          await seedCode(
            ctx,
            '18',
            'TEMPLATE 8%',
            8,
            [
              { sr: 1, grp: 'SGST', name: 'SGST 4%', pct: 4, ac: 'TXGST' },
              { sr: 2, grp: 'CGST', name: 'CGST 4%', pct: 4, ac: 'TXCGS' },
              { sr: 3, grp: 'IGST', name: 'IGST 8%', pct: 8, ac: 'TXIGS' },
            ],
            { main: 'ABC', add: 1.25 },
          );
          const before = await taxRows(ctx, '18');
          const { page } = await ctx.session();
          await openScreen(page);
          await openCode(page, '18', 'dblclick');
          const shown = await header(page);
          assert.deepEqual(shown, {
            code: '18',
            name: 'TEMPLATE 8%',
            pct: '8.00',
            addPct: '1.25',
            account: 'TXGST',
            accountName: 'TX GST TAX',
            codeReadOnly: true,
          });
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const after = await taxRows(ctx, '18');
          assert.deepEqual(
            after,
            before.map((r) => ({ ...r, main: null })),
          );
          return {
            observation: `reopened 18 by double click (cursor in the code) and saved it unchanged`,
            expected: 'the same rows, MAIN_USER no longer written',
            database: { before, after },
            downstream: { shown },
          };
        }),
    ),
    C(
      'edit.one-component',
      'T09',
      'mutation',
      "An opened code (EntryMode E) is replaced under its code; changing one component's account changes only that row; other codes keep their rows",
      async (ctx) =>
        withAccounts(ctx, async () => {
          await seedCode(ctx, '17', 'LEVY 4%', 4, [
            { sr: 1, grp: 'SGST', name: 'SGST 2%', pct: 2, ac: 'TXGST' },
            { sr: 2, grp: 'CGST', name: 'CGST 2%', pct: 2, ac: 'TXCGS' },
          ]);
          const seeded = await allTaxes(ctx);
          const before = await taxRows(ctx, '17');
          const { page } = await ctx.session();
          await openScreen(page);
          await openCode(page, '17');
          const box = cell(page, 'Ac Code', 2);
          await box.fill('TXOTH');
          await page.waitForResponse((r) => path(r) === `/api${API}/accounts`);
          await box.press('Enter');
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Tax % row 2',
          );
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const after = await taxRows(ctx, '17');
          assert.deepEqual(
            after,
            before.map((r) => (r.sr === 2 ? { ...r, ac: 'TXOTH' } : r)),
          );
          const others = (await allTaxes(ctx)).filter((r) => r.code !== '17');
          assert.deepEqual(
            others,
            seeded.filter((r) => r.code !== '17'),
          );
          return {
            observation: 'CGST account TXCGS → TXOTH; nothing else changed',
            expected: 'one changed column',
            database: { before, after },
            downstream: { others: others.length },
          };
        }),
    ),
    C(
      'delete.lifecycle',
      'T10',
      'mutation',
      'BtnDelete_Click (:1935-1956): a blank code, the question, every row of the code deleted, "Delete Success." and a new entry with the list read again',
      async (ctx) =>
        withAccounts(ctx, async () => {
          await seedCode(ctx, '17', 'LEVY 4%', 4, [
            { sr: 1, grp: 'SGST', name: 'SGST 2%', pct: 2, ac: 'TXGST' },
            { sr: 2, grp: 'CGST', name: 'CGST 2%', pct: 2, ac: 'TXCGS' },
          ]);
          const { page } = await ctx.session();
          await openScreen(page);
          await button(page, 'Delete').click();
          await message(page, 'Please Select Tax Code For Delete.');
          await openCode(page, '17');
          page.removeAllListeners('dialog');
          let asked = '';
          page.once('dialog', (dialog) => {
            asked = dialog.message();
            void dialog.dismiss();
          });
          await button(page, 'Delete').click();
          await page.waitForTimeout(300);
          assert.equal(asked, 'Are You Sure To Delete This Record now?');
          assert.equal(
            (await taxRows(ctx, '17')).length,
            3,
            'a dismissed question deletes nothing',
          );
          page.on('dialog', (dialog) => void dialog.accept());
          const [gone] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'DELETE', `${API}/17`)),
            button(page, 'Delete').click(),
          ]);
          assert.equal(gone.status(), 200, await gone.text());
          assert.deepEqual(await gone.json(), { code: '17', deleted: 3 });
          await message(page, 'Delete Success.');
          await page.waitForFunction(() => document.querySelector('#tax-code')?.value === '');
          const rows = await taxRows(ctx, '17');
          assert.deepEqual(rows, []);
          assert.deepEqual(await listed(page), SEEDED);
          return {
            observation: `asked "${asked}"; 17 deleted with 3 rows; the list is back to the seeded codes`,
            expected: 'the desktop texts; no row of 17 left',
            database: { rows },
            downstream: { list: SEEDED },
          };
        }),
    ),
    C(
      'rights.view-only',
      'T11',
      'refusal',
      'MS_TAX_Load reads FRM_EDIT/FRM_DELETE/FRM_PRINT of the user\'s rights row (:1342-1350): Save of an opened code, Delete and Print answer "You Have No Rights....." / "You Have No Print Rights....."; a new code needs only the view right (:1845-1849)',
      async (ctx) =>
        withAccounts(ctx, async () => {
          await seedCode(ctx, '17', 'LEVY 4%', 4, [
            { sr: 1, grp: 'IGST', name: 'IGST 4%', pct: 4, ac: 'TXIGS' },
          ]);
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "TAX_MAST" WHERE tenant_id=$1 AND "TAX_CODE"='17'`,
            SECOND_TENANT,
          );
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC","TAX_GROUP") VALUES ($1,'01','17',0,'SENTINEL',9,'N')`,
            SECOND_TENANT,
          );
          await exec(
            ctx,
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES ($1,'01','01',$2,'Master','Taxes','Y','N','N','N')`,
            USERS.clerk.user,
          );
          try {
            const { page, requests } = await ctx.session(as(USERS.clerk.user));
            await openScreen(page);
            const opened = await openCode(page, '17');
            await label(page, 'Tax Desc').fill('LEVY CHANGED');
            await button(page, 'Save').click();
            await message(page, 'You Have No Rights.....');
            await button(page, 'Delete').click();
            await message(page, 'You Have No Rights.....');
            await button(page, 'Print').click();
            await message(page, 'You Have No Print Rights.....');
            assert.equal(requests.filter((r) => ['PUT', 'DELETE'].includes(r.method)).length, 0);
            const direct = [
              (
                await page.request.put(`/api${API}/17`, {
                  data: { name: 'X', expectedVersion: opened.version },
                })
              ).status(),
              (
                await page.request.delete(`/api${API}/17?expectedVersion=${opened.version}`)
              ).status(),
              (await page.request.get(`/api${API}/print`)).status(),
            ];
            assert.deepEqual(direct, [403, 403, 403]);
            // A new code needs only the view right.
            await button(page, 'Cancel').click();
            await page.waitForFunction(() => document.querySelector('#tax-code')?.value === '');
            await fillHeader(page, { code: '18', name: 'CLERK TAX', pct: '6.5' });
            const created = await save(page);
            assert.equal(created.status(), 201, await created.text());
            await saved(page);
            const rows = { 17: await taxRows(ctx, '17'), 18: await taxRows(ctx, '18') };
            assert.deepEqual(
              rows['17'].map((r) => r.name),
              ['LEVY 4%', 'IGST 4%'],
            );
            assert.deepEqual(
              rows['18'].map((r) => [r.sr, r.name, r.pct]),
              [[0, 'CLERK TAX', 6.5]],
            );
            const sentinel = await ctx.owner.$queryRawUnsafe(
              `SELECT "TAX_NAME" name FROM "TAX_MAST" WHERE tenant_id=$1 AND "TAX_CODE"='17'`,
              SECOND_TENANT,
            );
            assert.deepEqual(sentinel, [{ name: 'SENTINEL' }]);
            const printer = await ctx.session(as(USERS.printViewer.user));
            const refused = await openScreen(printer.page);
            assert.equal(refused.status(), 403);
            await message(printer.page, 'You Have No Rights.....');
            return {
              observation: `clerk refused on screen; direct ${direct.join('/')}; clerk created 18; e2eprint refused ${refused.status()}`,
              expected:
                'the desktop texts, 403s, a new code allowed, the sentinel tenant untouched',
              database: { rows, sentinel },
            };
          } finally {
            await exec(
              ctx,
              `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Taxes'`,
              USERS.clerk.user,
            );
            await ctx.owner.$executeRawUnsafe(
              `DELETE FROM "TAX_MAST" WHERE tenant_id=$1 AND "TAX_CODE"='17'`,
              SECOND_TENANT,
            );
          }
        }),
    ),
    C(
      'concurrency.two-operators',
      'T12',
      'mutation',
      'Two operators open one code: the first save wins and the second is refused with 409 (version token, G226) where the desktop lets the later save win; two new entries with the same code: the second is refused with the code text under the company lock',
      async (ctx) =>
        withAccounts(ctx, async () => {
          await seedCode(ctx, '17', 'LEVY 4%', 4, [
            { sr: 1, grp: 'IGST', name: 'IGST 4%', pct: 4, ac: 'TXIGS' },
          ]);
          const a = (await ctx.session()).page;
          const b = (await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#2`))).page;
          await openScreen(a);
          await openScreen(b);
          await openCode(a, '17');
          await openCode(b, '17');
          await label(a, 'Tax Desc').fill('LEVY A');
          const first = await save(a);
          assert.equal(first.status(), 200, await first.text());
          await saved(a);
          await label(b, 'Tax %').fill('9');
          const second = await save(b);
          assert.equal(second.status(), 409);
          await message(b, CONFLICT);
          let rows = await taxRows(ctx, '17');
          assert.deepEqual(
            rows.map((r) => [r.name, r.pct]),
            [
              ['LEVY A', 4],
              ['IGST 4%', 4],
            ],
          );
          await button(b, 'Cancel').click();
          await fillHeader(a, { code: '18', name: 'NEW A', pct: '6.5' });
          await b.waitForFunction(() => document.querySelector('#tax-code')?.value === '');
          await fillHeader(b, { code: '18', name: 'NEW B', pct: '7.5' });
          assert.equal((await save(a)).status(), 201);
          await saved(a);
          const late = await save(b);
          assert.equal(late.status(), 400);
          await message(
            b,
            "This Tax Code already Exist in  'NEW A'  Tax Name...Please Change Tax Code...",
          );
          rows = await taxRows(ctx, '18');
          assert.deepEqual(
            rows.map((r) => [r.name, r.pct]),
            [['NEW A', 6.5]],
          );
          return {
            observation: `edit race ${first.status()} then ${second.status()}; new-code race 201 then ${late.status()}`,
            expected: 'one result per race and a defined refusal',
            database: { rows },
            downstream: { second: second.status(), late: late.status() },
          };
        }),
    ),
    C(
      'retry.replayed-save',
      'T13',
      'mutation',
      "A replayed edit carries a spent version and is refused (409); a replayed new code has the same code and name, so it rewrites the same rows (BtnSave_Click's DELETE + INSERT) and no second header appears",
      async (ctx) =>
        withAccounts(ctx, async () => {
          await seedCode(ctx, '17', 'LEVY 4%', 4, [
            { sr: 1, grp: 'IGST', name: 'IGST 4%', pct: 4, ac: 'TXIGS' },
          ]);
          const { page } = await ctx.session();
          await openScreen(page);
          await openCode(page, '17');
          await label(page, 'Add Tax %').fill('0.5');
          const first = await save(page);
          assert.equal(first.status(), 200, await first.text());
          await saved(page);
          const replayEdit = (await page.request.fetch(first.request())).status();
          assert.equal(replayEdit, 409);
          await fillHeader(page, { code: '18', name: 'RETRY 6.5%', pct: '6.5' });
          const created = await save(page);
          assert.equal(created.status(), 201, await created.text());
          await saved(page);
          const replayCreate = (await page.request.fetch(created.request())).status();
          assert.equal(replayCreate, 201);
          const rows = { 17: await taxRows(ctx, '17'), 18: await taxRows(ctx, '18') };
          assert.deepEqual(
            rows['17'].map((r) => [r.sr, r.add]),
            [
              [0, 0.5],
              [1, 0.5],
            ],
          );
          assert.equal(rows['18'].length, 1, 'one header after the replay');
          return {
            observation: `replayed edit ${replayEdit}; replayed create ${replayCreate}; 18 has ${rows['18'].length} row`,
            expected: 'the edit replay refused, one header for 18',
            database: { rows },
            downstream: { replayEdit, replayCreate },
          };
        }),
    ),
    C(
      'rollback.insert-fault',
      'T14',
      'mutation',
      "BtnSave_Click deletes the code's rows before it inserts them (:1864-1906); a fault on a component insert must roll the delete back, leaving every row as it was (the desktop would leave the code deleted)",
      async (ctx) =>
        withAccounts(ctx, async () => {
          await seedCode(ctx, '17', 'LEVY 4%', 4, [
            { sr: 1, grp: 'SGST', name: 'SGST 2%', pct: 2, ac: 'TXGST' },
            { sr: 2, grp: 'CGST', name: 'CGST 2%', pct: 2, ac: 'TXCGS' },
          ]);
          const before = await allTaxes(ctx);
          await ctx.owner.$executeRawUnsafe(
            `CREATE OR REPLACE FUNCTION e2e_tax_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
             BEGIN
               IF NEW."TAX_NAME" = 'E2E FAULT' THEN RAISE EXCEPTION 'e2e fault after the delete'; END IF;
               RETURN NEW;
             END $f$`,
          );
          await ctx.owner.$executeRawUnsafe(
            `CREATE TRIGGER e2e_tax_fault BEFORE INSERT ON "TAX_MAST" FOR EACH ROW EXECUTE FUNCTION e2e_tax_fault()`,
          );
          try {
            const { page } = await ctx.session();
            await openScreen(page);
            await openCode(page, '17');
            await cell(page, 'Tax Name', 2).fill('E2E FAULT');
            const failed = await save(page);
            assert.equal(failed.status(), 400, await failed.text());
            const after = await allTaxes(ctx);
            assert.deepEqual(
              after,
              before,
              'the delete was rolled back with the failed insert, row ids included',
            );
            return {
              observation: `the save answered ${failed.status()}; every TAX_MAST row is as before`,
              expected: 'no row lost',
              database: { before, after },
              downstream: { status: failed.status() },
            };
          } finally {
            await ctx.owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS e2e_tax_fault ON "TAX_MAST"`);
            await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_tax_fault()`);
          }
        }),
    ),
    C(
      'history.company-wide',
      'T15',
      'mutation',
      'TAX_MAST has no year: MS_TAX reads and writes by CO_CODE and TAX_CODE (:1608, :1864), so a code saved in this year is the code of the historic year too; an account renamed after the save is shown under its new name',
      async (ctx) =>
        withAccounts(ctx, async () => {
          // Its own login: opening another year moves the server session, which the other cases' saved login shares.
          const { page } = await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#history`));
          await openScreen(page);
          await fillHeader(page, { code: '17', name: 'YEAR LEVY 4%', pct: '4', account: 'TXGST' });
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          await exec(
            ctx,
            `UPDATE "AC_MAST" SET "AC_NAME"='TX GST RENAMED' WHERE tenant_id=$1 AND "AC_CODE"='TXGST'`,
          );
          await page.goto('/select');
          await page.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
          await page.getByRole('combobox', { name: 'FINANCIAL YEAR' }).selectOption('2024-2025');
          await button(page, 'Open').click();
          await page.waitForURL('**/dashboard');
          const me = await (await page.request.get('/api/me')).json();
          assert.equal(me.coYear, '2024-2025');
          await openScreen(page);
          const list = await listed(page);
          assert.deepEqual(list, [...SEEDED.slice(0, 6), ['17', 'YEAR LEVY 4%'], SEEDED[6]]);
          await openCode(page, '17');
          const shown = await header(page);
          assert.equal(shown.accountName, 'TX GST RENAMED');
          return {
            observation: `the historic year lists ${list.length} codes with 17; the account shows as "${shown.accountName}"`,
            expected: 'the same codes in every year; the account read by code',
            database: { rows: await taxRows(ctx, '17') },
            downstream: { historicYearList: list, shown },
          };
        }),
    ),
    C(
      'output.print',
      'T16',
      'output',
      "BtnPrint_Click (:1958-1971) prints the company's TAX_MAST rows (TaxMast, {TAX_MAST.CO_CODE}); the report layout is not in the repository, so the web lists code, Sr, type, name, Tax %, Add Tax % and account on screen (G226)",
      async (ctx) =>
        withAccounts(ctx, async () => {
          await seedCode(ctx, '17', 'LEVY 4%', 4, [
            { sr: 1, grp: 'SGST', name: 'SGST 2%', pct: 2, ac: 'TXGST' },
            { sr: 2, grp: 'CGST', name: 'CGST 2%', pct: 2, ac: 'TXCGS' },
          ]);
          const { page } = await ctx.session();
          await openScreen(page);
          const [response] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/print`)),
            button(page, 'Print').click(),
          ]);
          assert.equal(response.status(), 200);
          const sheet = page.getByTestId('tax-print');
          await sheet.waitFor();
          const headers = (await sheet.locator('thead th').allInnerTexts()).map((t) => t.trim());
          const body = await sheet
            .locator('tbody tr')
            .evaluateAll((rows) =>
              rows.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
            );
          assert.deepEqual(headers, [
            'Code',
            'Sr',
            'Tax Type',
            'Tax Name',
            'Tax %',
            'Add Tax %',
            'Ac Code',
          ]);
          const seventeen = body.filter((r) => r[0] === '17');
          assert.deepEqual(seventeen, [
            ['17', '0', 'N', 'LEVY 4%', '4.00', '0.00', 'TXGST'],
            ['17', '1', 'SGST', 'SGST 2%', '2.000', '0.00', 'TXGST'],
            ['17', '2', 'CGST', 'CGST 2%', '2.000', '0.00', 'TXCGS'],
          ]);
          assert.deepEqual(
            body.map((r) => r[0]),
            [...body.map((r) => r[0])].sort(),
            'printed by code',
          );
          return {
            observation: `printed ${body.length} rows; code 17 has ${seventeen.length}`,
            expected: { headers, seventeen },
            output: { headers, rows: body },
          };
        }),
    ),
    C(
      'keyboard.desktop-keys',
      'T17',
      'mutation',
      "MS_TAX_KeyPress (:1689-1702), the boxes' Enter keys (:1704-1759, :2004-2063), TEXT_ENTRY_KeyDown (:1200-1310), the list keys (:1973-2002), MS_TAX_KeyDown Esc (:1806-1814) and the &Save mnemonic",
      async (ctx) =>
        withAccounts(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await page.keyboard.type('15');
          await page.keyboard.press('Enter');
          assert.equal(await focusedId(page), 'tax-name');
          await page.keyboard.type("gst 1.5% o'nly");
          assert.equal(await label(page, 'Tax Desc').inputValue(), 'GST 1.5% ONLY');
          await page.keyboard.press('Enter');
          assert.equal(await focusedId(page), 'tax-pct');
          await page.keyboard.type('1.5');
          await page.keyboard.press('Enter');
          assert.equal(await label(page, 'Tax %').inputValue(), '1.50');
          assert.equal(await focusedId(page), 'tax-add-pct');
          await page.keyboard.press('Enter');
          assert.equal(await label(page, 'Add Tax %').inputValue(), '0.00');
          assert.equal(await focusedId(page), 'Ac Code');
          await page.keyboard.type('TXGST');
          await page.waitForResponse((r) => path(r) === `/api${API}/accounts`);
          await page.keyboard.press('Enter');
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Tax Type row 1',
          );
          for (const [i, c] of gstComponents('0.75', '1.5').entries()) {
            const row = i + 1;
            await page.keyboard.type(c.taxType.toLowerCase());
            await page.keyboard.press('Enter');
            assert.equal(await focusedId(page), `Tax Name row ${row}`);
            await page.keyboard.type(c.name);
            await page.keyboard.press('Enter');
            assert.equal(await focusedId(page), `Ac Code row ${row}`);
            await page.keyboard.type(c.account);
            await page.waitForResponse((r) => path(r) === `/api${API}/accounts`);
            await page.keyboard.press('Enter');
            await page.waitForFunction(
              (label) => document.activeElement?.getAttribute('aria-label') === label,
              `Tax % row ${row}`,
            );
            await page.keyboard.type(c.pct);
            await page.keyboard.press('Enter');
            await page.waitForFunction(
              (label) => document.activeElement?.getAttribute('aria-label') === label,
              `Tax Type row ${row + 1}`,
            );
            assert.equal(await cell(page, 'Tax %', row).inputValue(), Number(c.pct).toFixed(3));
          }
          // The arrows move one cell; a blank Tax % on the last row goes to Save, and Enter there saves.
          await page.keyboard.press('ArrowUp');
          assert.equal(await focusedId(page), 'Tax Type row 3');
          await page.keyboard.press('ArrowDown');
          await page.keyboard.press('ArrowRight');
          await page.keyboard.press('ArrowRight');
          await page.keyboard.press('ArrowRight');
          assert.equal(await focusedId(page), 'Tax % row 4');
          await page.keyboard.press('Enter');
          assert.equal(
            await page.evaluate(() => document.activeElement?.textContent?.trim()),
            'Save',
          );
          const created = await save(page, () => page.keyboard.press('Enter'));
          assert.equal(created.status(), 201, await created.text());
          await saved(page);
          // F1 from the code box goes to the search box; typing filters by name; the list opens a code with Enter.
          await page.keyboard.press('F1');
          assert.equal(await focusedId(page), 'Search record');
          await page.keyboard.type('gst 1');
          assert.deepEqual(await listed(page), [
            ['12', 'GST 12%'],
            ['13', 'GST 18%'],
            ['15', 'GST 1.5% ONLY'],
          ]);
          await page.getByTestId('tax-list').locator('tr[data-code="15"]').focus();
          const [opened] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/15`)),
            page.keyboard.press('Enter'),
          ]);
          assert.equal(opened.status(), 200);
          await page.waitForFunction(() => document.activeElement?.id === 'tax-name');
          // Alt+S saves the opened code.
          await label(page, 'Add Tax %').fill('0.1');
          const altSaved = await save(page, () => page.keyboard.press('Alt+s'));
          assert.equal(altSaved.status(), 200, await altSaved.text());
          await saved(page);
          await label(page, 'Tax Desc').focus();
          await page.keyboard.press('Escape');
          await page.waitForURL((url) => !url.pathname.startsWith('/masters/taxes'));
          const rows = await taxRows(ctx, '15');
          assert.deepEqual(
            rows.map((r) => [r.sr, r.grp, r.name, r.ac, r.pct, r.add]),
            [
              [0, 'N', 'GST 1.5% ONLY', 'TXGST', 1.5, 0.1],
              [1, 'SGST', 'SGST 0.75%', 'TXGST', 0.75, 0.1],
              [2, 'CGST', 'CGST 0.75%', 'TXCGS', 0.75, 0.1],
              [3, 'IGST', 'IGST 1.5%', 'TXIGS', 1.5, 0.1],
            ],
          );
          return {
            observation: `the code and three components were keyed in, saved with Enter, reopened from the list and saved with Alt+S; Esc left for ${new URL(page.url()).pathname}`,
            expected: 'every desktop key as listed in the source',
            database: { rows },
            downstream: { leftTo: new URL(page.url()).pathname },
          };
        }),
    ),
    C(
      'journey.code-on-a-sale',
      'T18',
      'mutation',
      "A sale at the new code's rate resolves the code by its rate (taxPolicy, header SR_NO 0) and posts its tax to the header's account (Ac_Ledr Sales_Ledr, D.TAX_AC); deleting the sale and then the code leaves no row behind",
      async (ctx) =>
        withAccounts(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          // 2%: a rate no other code's header or component carries, so the sale resolves this code alone
          // (a rate shared with another code, such as 1.5% = code 10's SGST and CGST, is refused as ambiguous).
          await fillHeader(page, {
            code: '15',
            name: 'GST 2% JOURNEY',
            pct: '2',
            account: 'TXGST',
          });
          await enterComponents(page, gstComponents('1', '2'));
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          // Sales Invoice at 2%: one line of the catalogue's gold item for the local party.
          await page.goto('/txn/sales');
          await page.getByRole('heading', { name: 'Sales Invoice', exact: true }).waitFor();
          const party = page.getByPlaceholder('search accounts… (F1)').first();
          await party.fill(PARTIES.local.code);
          await party
            .locator('xpath=..')
            .getByText(PARTIES.local.code, { exact: true })
            .first()
            .waitFor();
          await party.press('Enter');
          const taxBox = page
            .locator('.field')
            .filter({ has: page.locator('label', { hasText: /^Tax %$/ }) })
            .locator('input')
            .first();
          await taxBox.fill('2');
          const line = (column) =>
            page.locator(`[data-grid-row="0"][data-grid-column="${column}"] input`).first();
          await line(0).fill(ITEMS.gold.code);
          await line(0).press('Escape');
          for (const [column, value] of [
            [2, '1'],
            [3, '10.25'],
            [4, '10'],
            [5, '91.6'],
            [6, '6123.45'],
            [7, '237.5'],
          ])
            await line(column).fill(value);
          const [sold] = await Promise.all([
            page.waitForResponse(
              (r) =>
                /\/api\/sales(\/|$)/.test(path(r)) &&
                ['POST', 'PUT'].includes(r.request().method()),
            ),
            page.getByRole('button', { name: 'Save Invoice', exact: true }).click(),
          ]);
          assert.equal(sold.status(), 201, await sold.text());
          const vchNo = String((await sold.json()).vchNo).padStart(5, '0');
          try {
            const [sale] = await ctx.rows(
              `SELECT "TAX_CODE" code,"TAX_PRC"::float pct,"TAX_AMT"::float tax,"SGST_TAX"::float sgst,"CGST_TAX"::float cgst
                 FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2`,
              vchNo,
            );
            // 63,609.50 × 2% = 1,272.19; SGST = CGST = 1,272.19 / 2 (TR_SALE.cs, no rounding).
            assert.deepEqual(sale, {
              code: '15',
              pct: 2,
              tax: 1272.19,
              sgst: 636.095,
              cgst: 636.095,
            });
            const legs = await ctx.rows(
              `SELECT "AC_CODE" ac,"CR_AMT"::float cr FROM "AC_DATA"
                WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2 AND "AC_CODE"='TXGST'`,
              vchNo,
            );
            assert.deepEqual(legs, [{ ac: 'TXGST', cr: 1272.19 }]);
            return {
              observation: `sale ${vchNo} at 2% resolved code 15 and posted 1272.19 Cr to TXGST`,
              expected: { tax: 1272.19, sgst: 636.095, legAccount: 'TXGST' },
              database: { sale, legs },
              downstream: { vchNo },
            };
          } finally {
            const read = await page.request.get(`/api/sales/${vchNo}?coBook=SL`);
            const version = (await read.json()).version;
            const removed = await page.request.delete(
              `/api/sales/${vchNo}?coBook=SL&expectedVersion=${encodeURIComponent(version)}`,
            );
            assert.equal(removed.status(), 200, await removed.text());
          }
        }),
    ),
  ],
};
