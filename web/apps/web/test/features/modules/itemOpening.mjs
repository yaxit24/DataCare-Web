import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, ITEMS, PARTIES, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Master → Item Opening (desktop TR_ITM_OPBL, web /txn/item-opening).
 *
 * Desktop rules used for the expected values (TR_ITM_OPBL.cs unless noted):
 * - The menu opens the form directly, with no book help (MDI_FORM.cs:7690-7699). Enter on the metal type lists every
 *   item of the type, ordered IT_TYPE, GR_CODE, IT_NAME, and starts on row 1, Rtype (:1269-1370, :1672-1684).
 * - A row works out when a number cell is left (MSG_LeaveCell :887-925, CommPassTotal :942-993): a blank net weight takes
 *   the gross; fine = net × (touch + wastage) / 100 when touch is set, else the net weight; item amount = fine × rate when
 *   both are set (pieces × rate for a piece-rated item without fine), otherwise as typed; labour by its type when a
 *   labour rate is set (G = gross × rate), rounded with .NET Math.Round, half to even; net amount = item amount + labour
 *   + other amount. Cells are held as "0", "0.000" or "0.00".
 * - Save keeps the rows whose gross weight plus pieces is not zero, in book '000' with the type letter as voucher
 *   number and SR_NO = the grid row (:1414-1441), and writes Ac_Stock.Itm_Opbl_Stk stock rows (Ac_Stock.cs:11-21): a
 *   purchase-in (P, '+') dated the day before the year opens, VCH_TYPE 'ITOBL', BOOK_NAME 'ITM OPBL', AC_CODE '00000',
 *   TAG_NO 'N', with the karigar columns copied. Then "Data Are Saved." and an empty screen (CLEAR_DATA :1247-1268).
 * - Delete asks "Are You Sure To Delete All Item Opening From This Record now?" and answers "Delete Success."
 *   (:1492-1517). With no metal type: "Please Select Metaltype...." (:1407) and "Please Select Item For Delete."
 *   (:1505). Without the rights: "You Have No Rights....." and "You Have No Print Rights....." (:1371-1405).
 * - Keys (:1538-1684): Enter moves one cell right; Enter on NetAmt goes to the next row's Pcs, or on the last row adds
 *   a row and goes to its ItCode; Enter on an empty ItCode goes to Save; text is upper-cased; Esc leaves an unchanged
 *   screen and otherwise goes to Save.
 * Web rules that differ on purpose (gap G222): the grid reads only this year's book '000' rows, a save or delete
 * carries the version read with the grid (N51), and an item code that is not of the type is refused.
 */
const GOLD = ITEMS.gold.code;
const SILVER = ITEMS.silver.code;
const ADDED_ITEM = { code: 'E2EGC', name: 'A GOLD CHAIN' };
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `item-opening.${id}`,
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
const pending = (name, group, reason) => ({
  ...C(`${name}.pending`, group, 'read-only', `Playbook ${group}`, async () => ({})),
  blocked: reason,
});

const HEADERS = [
  'Sr.',
  'ItCode',
  'Item Name',
  'Rtype',
  'Pcs',
  'GrWt',
  'NetWt',
  'Touch',
  'West%',
  'Fine',
  'Rate',
  'ItmAmt',
  'LType',
  'LRate',
  'LbrAmt',
  'OthAmt',
  'NetAmt',
];
const NAMES = { G: 'Gold', S: 'Silver', P: 'Platinum' };
const isApi = (r, method, prefix) =>
  r.request().method() === method && new URL(r.url()).pathname.startsWith(`/api${prefix}`);
const cell = (page, header, row) => page.getByLabel(`${header} row ${row}`, { exact: true });
const button = (page, name) => page.getByRole('button', { name, exact: true });
const focused = (locator) => locator.evaluate((element) => element === document.activeElement);

async function openScreen(page) {
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', '/stock/item-opening/rights')),
    page.goto('/txn/item-opening'),
  ]);
  await page.getByRole('heading', { name: 'Item Opening', exact: true }).waitFor();
}
/** Choose the metal type and press Enter on it (cboItemTyp_KeyDown). */
async function loadType(page, code) {
  const type = page.getByLabel('Item Type', { exact: true });
  await type.selectOption(code);
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `/stock/item-opening/type/${code}`)),
    type.press('Enter'),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.getByTestId('item-opening-loaded').filter({ hasText: NAMES[code] }).waitFor();
  return response.json();
}
/** Type a value and press Enter, which leaves the cell (MSG_LeaveCell) and moves one cell right. */
async function enterCell(page, header, row, value) {
  const input = cell(page, header, row);
  await input.fill(value);
  await input.press('Enter');
}
async function enterRow(page, row, values) {
  for (const [header, value] of Object.entries(values)) await enterCell(page, header, row, value);
}
async function save(page, trigger = () => button(page, 'Save').click(), type = 'G') {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'PUT', `/stock/item-opening/type/${type}`)),
    trigger(),
  ]);
  return response;
}
async function saveType(page, type, values) {
  await openScreen(page);
  await loadType(page, type);
  await enterRow(page, 1, values);
  const response = await save(page, undefined, type);
  assert.equal(response.status(), 200, await response.text());
  await page.getByText('Data Are Saved.', { exact: true }).waitFor();
  return response;
}
/** Delete a type's opening through the screen; harmless when the type has none. */
async function removeOpening(page, type) {
  await openScreen(page);
  await loadType(page, type);
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'DELETE', `/stock/item-opening/type/${type}`)),
    button(page, 'Delete').click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.getByText('Delete Success.', { exact: true }).waitFor();
}
async function rowValues(page, row) {
  const out = {};
  for (const header of HEADERS.slice(1)) out[header] = await cell(page, header, row).inputValue();
  return out;
}
const sessionYear = async (page) => (await (await page.request.get('/api/me')).json()).coYear;
/** The day before the year opens (MOp_dt.AddDays(-1)), from YEAR_MAST. */
async function stockDateOf(ctx, coYear) {
  const [year] = await ctx.rows(
    `SELECT "OP_DATE"::date::text op FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "CO_YEAR"=$2`,
    coYear,
  );
  const day = new Date(`${year.op}T00:00:00Z`);
  day.setUTCDate(day.getUTCDate() - 1);
  return day.toISOString().slice(0, 10);
}
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);

const opbl = (ctx, type) =>
  ctx.rows(
    `SELECT "CO_YEAR" yr, "CO_BOOK" book, "VCH_NO" vch, "SR_NO"::int sr, "IT_CODE" it, "ITM_PCS"::float pcs,
            "ITM_GWT"::float gwt, "ITM_NWT"::float nwt, "ITM_TOUCH"::float touch, "ITM_WEST_PRC"::float west,
            "ITM_FINE"::float fine, "ITM_RATE"::float rate, "ITM_AMT"::float amt, coalesce("LBR_TYPE",'') lt,
            "LBR_RATE"::float lr, "LBR_AMT"::float la, "OTH_AMT"::float oa, "NET_AMT"::float na,
            "MAIN_USER" mu, "DATA_TYPE" dt, "DATA_TRFR" trfr
       FROM "ITM_OPBL" WHERE tenant_id=$1 AND "CO_BOOK"='000' AND "VCH_NO"=$2 ORDER BY "CO_YEAR", "SR_NO"`,
    type,
  );
const stock = (ctx, type) =>
  ctx.rows(
    `SELECT "CO_YEAR" yr, "SR_NO"::int sr, "ISR_NO"::int isr, "VCH_DATE"::date::text dt, "STK_DATE" sd,
            "VCH_TYPE" vt, "BOOK_NAME" bn, "AC_CODE" ac, "IT_CODE" it, "TAG_NO" tag, "TR_TYPE" tr, "ITM_SIGN" sg,
            "ITM_QTY"::float qty, "ITM_PCS"::float pcs, "ITM_GWT"::float gwt, "ITM_NWT"::float nwt,
            "ITM_TOUCH"::float touch, "ITM_FINE"::float fine, "ITM_AMT"::float amt, "LBR_AMT"::float la,
            "OTH_AMT"::float oa, "NET_AMT"::float na, "KR_NWT"::float krn, "KR_FINE"::float krf,
            "KR_COST"::float krc
       FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='000' AND "VCH_NO"=$2 AND "VCH_TYPE"='ITOBL'
      ORDER BY "CO_YEAR", "SR_NO"`,
    type,
  );
const count = async (ctx, table, where) =>
  (await ctx.rows(`SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND ${where}`))[0].n;

/** The Item Stock Ledger row of an item (MAIN_STOCK by item: in/out fine and pieces). */
async function ledgerRow(page, item) {
  await page.goto('/reports/item-stock-ledger');
  await page.getByRole('heading', { name: 'Item Stock Ledger' }).waitFor();
  const table = page.locator('table.grid').first();
  await table.waitFor();
  const headers = (await table.locator('thead th').allInnerTexts()).map((t) => t.trim());
  const row = table.locator('tbody tr').filter({
    has: page
      .locator('td')
      .first()
      .filter({ hasText: new RegExp(`^${item}$`) }),
  });
  if ((await row.count()) === 0) return { inFine: 0, outFine: 0, netFine: 0, inPcs: 0, moves: 0 };
  const cells = (await row.first().locator('td').allInnerTexts()).map((t) => t.trim());
  const pick = (name) => Number(cells[headers.indexOf(name)] || 0);
  return {
    inFine: pick('inFine'),
    outFine: pick('outFine'),
    netFine: pick('netFine'),
    inPcs: pick('inPcs'),
    moves: pick('moves'),
  };
}
const r3 = (n) => Math.round(n * 1000) / 1000;

export const itemOpening = {
  feature: 'item-opening',
  title: 'Master → Item Opening (TR_ITM_OPBL)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/item-opening/page.tsx',
    'web/apps/api/src/modules/stock/itemOpening.ts',
    'web/apps/api/src/routes/itemOpening.ts',
    'web/packages/core/src/itemOpening.ts',
    'web/apps/web/test/features/modules/itemOpening.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.type-grid',
      'T01',
      'read-only',
      "MDI_FORM.cs:7690-7699 opens TR_ITM_OPBL with no book; MSG_CLEAR (:694-783) columns; DISPLAY_DATA lists the type's items; the cursor starts on row 1, Rtype (:1672-1684)",
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        const type = page.getByLabel('Item Type', { exact: true });
        assert.equal(await type.inputValue(), '', 'the metal type starts blank (CLEAR_DATA)');
        assert.equal(await focused(type), true, 'the cursor starts on the metal type');
        const options = await type.locator('option').allInnerTexts();
        assert.deepEqual(
          options.map((o) => o.trim()),
          ['', 'Gold', 'Silver', 'Diamond', 'Real Stone', 'Emitation', 'Other', 'Platinum'],
        );
        const headers = (await page.locator('thead th').allInnerTexts()).map((t) => t.trim());
        assert.deepEqual(headers, HEADERS);
        assert.equal(await page.getByRole('combobox', { name: 'Configured book' }).count(), 0);
        await loadType(page, 'G');
        assert.equal(await cell(page, 'ItCode', 1).inputValue(), GOLD);
        assert.equal(await cell(page, 'Item Name', 1).inputValue(), ITEMS.gold.name);
        assert.equal(await cell(page, 'GrWt', 1).inputValue(), '', 'no opening yet: blank cells');
        assert.equal(await focused(cell(page, 'Rtype', 1)), true, 'row 1, Rtype has the cursor');
        await loadType(page, 'S');
        assert.equal(await cell(page, 'ItCode', 1).inputValue(), SILVER);
        assert.equal(await cell(page, 'ItCode', 2).count(), 0, 'one silver item');
        return {
          observation: `blank type focused; ${options.length} type choices; ${headers.length} columns; Gold lists ${GOLD}, Silver lists ${SILVER}`,
          expected: { headers: HEADERS, gold: GOLD, silver: SILVER, focus: 'Rtype row 1' },
        };
      },
    ),
    C(
      'field.every-cell',
      'T02',
      'mutation',
      'BtnSave_Click (:1424-1441) stores every grid column; DISPLAY_DATA (:1290-1331) shows them again',
      async (ctx) => {
        const { page } = await ctx.session();
        // Hand calculation: fine = 10.25 × (91.6 + 2.5) / 100 = 9.64525 → 9.645; amount = 9.645 × 6123.45 =
        // 59,060.67525 → 59,060.68; labour G = 10.5 × 13 = 136.5 → 136 (half to even); net = 59,060.68 + 136 + 237.5.
        const typed = {
          Pcs: '2',
          GrWt: '10.5',
          NetWt: '10.25',
          Touch: '91.6',
          'West%': '2.5',
          Rate: '6123.45',
          LType: 'g',
          LRate: '13',
          OthAmt: '237.5',
        };
        try {
          await saveType(page, 'G', typed);
          const [row] = await opbl(ctx, 'G');
          assert.deepEqual(
            {
              sr: row.sr,
              it: row.it,
              pcs: row.pcs,
              gwt: row.gwt,
              nwt: row.nwt,
              touch: row.touch,
              west: row.west,
              fine: row.fine,
              rate: row.rate,
              amt: row.amt,
              lt: row.lt,
              lr: row.lr,
              la: row.la,
              oa: row.oa,
              na: row.na,
            },
            {
              sr: 1,
              it: GOLD,
              pcs: 2,
              gwt: 10.5,
              nwt: 10.25,
              touch: 91.6,
              west: 2.5,
              fine: 9.645,
              rate: 6123.45,
              amt: 59060.68,
              lt: 'G',
              lr: 13,
              la: 136,
              oa: 237.5,
              na: 59434.18,
            },
          );
          const [posted] = await stock(ctx, 'G');
          assert.deepEqual(
            [
              posted.pcs,
              posted.gwt,
              posted.nwt,
              posted.fine,
              posted.amt,
              posted.la,
              posted.oa,
              posted.na,
            ],
            [2, 10.5, 10.25, 9.645, 59060.68, 136, 237.5, 59434.18],
          );
          await openScreen(page);
          await loadType(page, 'G');
          const shown = await rowValues(page, 1);
          assert.deepEqual(shown, {
            ItCode: GOLD,
            'Item Name': ITEMS.gold.name,
            Rtype: '',
            Pcs: '2',
            GrWt: '10.500',
            NetWt: '10.250',
            Touch: '91.60',
            'West%': '2.50',
            Fine: '9.645',
            Rate: '6123.45',
            ItmAmt: '59060.68',
            LType: 'G',
            LRate: '13.00',
            LbrAmt: '136.00',
            OthAmt: '237.50',
            NetAmt: '59434.18',
          });
          return {
            observation: `stored ${JSON.stringify(row)}; reopened ${JSON.stringify(shown)}`,
            expected:
              'fine 9.645, amount 59060.68, labour 136, net 59434.18; every typed cell stored and shown',
            database: { opening: row, stock: posted },
            downstream: { reopened: shown },
          };
        } finally {
          await removeOpening(page, 'G');
        }
      },
    ),
    C(
      'formula.sequence',
      'T03',
      'mutation',
      'CommPassTotal (:942-993) after each cell, in the order typed; Fine is always worked out, a typed item amount stays when there is no rate',
      async (ctx) => {
        const { page } = await ctx.session();
        const steps = [];
        const snap = async (label) => {
          const v = await rowValues(page, 1);
          steps.push({ label, fine: v.Fine, amount: v.ItmAmt, labour: v.LbrAmt, net: v.NetAmt });
          return v;
        };
        try {
          await openScreen(page);
          await loadType(page, 'G');
          await enterCell(page, 'GrWt', 1, '10.5');
          let v = await snap('gross 10.5');
          // A blank net takes the gross; no touch, so fine = net.
          assert.deepEqual([v.NetWt, v.Fine, v.NetAmt], ['10.500', '10.500', '0.00']);
          await enterCell(page, 'Touch', 1, '91.6');
          v = await snap('touch 91.6');
          assert.equal(v.Fine, '9.618'); // 10.5 × 91.6 / 100
          await enterCell(page, 'West%', 1, '2');
          v = await snap('wastage 2');
          assert.equal(v.Fine, '9.828'); // 10.5 × 93.6 / 100
          await enterCell(page, 'Rate', 1, '6000');
          v = await snap('rate 6000');
          assert.equal(v.ItmAmt, '58968.00'); // 9.828 × 6000
          await enterCell(page, 'LType', 1, 'G');
          await enterCell(page, 'LRate', 1, '13');
          v = await snap('labour G 13');
          assert.deepEqual([v.LbrAmt, v.NetAmt], ['136.00', '59104.00']); // 136.5 → 136
          await enterCell(page, 'OthAmt', 1, '100');
          v = await snap('other 100');
          assert.equal(v.NetAmt, '59204.00');
          await enterCell(page, 'Fine', 1, '5');
          v = await snap('fine typed 5');
          assert.equal(v.Fine, '9.828', 'a typed fine is worked out again');
          await enterCell(page, 'Rate', 1, '0');
          v = await snap('rate cleared');
          assert.equal(v.ItmAmt, '58968.00', 'no rate: the amount is not worked out');
          await enterCell(page, 'ItmAmt', 1, '500');
          v = await snap('amount typed 500');
          assert.deepEqual([v.ItmAmt, v.NetAmt], ['500.00', '736.00']);
          const totals = (
            await page.getByTestId('item-opening-totals').locator('td').allInnerTexts()
          ).map((t) => t.trim());
          assert.deepEqual(
            [totals[2], totals[4], totals[5], totals[6], totals[9], totals[11], totals[16]],
            ['Total :', '0', '10.500', '10.500', '9.828', '500.00', '736.00'],
          );
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          const [row] = await opbl(ctx, 'G');
          assert.deepEqual(
            [row.fine, row.rate, row.amt, row.la, row.oa, row.na],
            [9.828, 0, 500, 136, 100, 736],
          );
          return {
            observation: `steps ${JSON.stringify(steps)}; stored ${JSON.stringify(row)}`,
            expected:
              'fine 10.5 → 9.618 → 9.828; amount 58968; labour 136; net 59204; typed fine reworked; typed amount 500 kept',
            database: { opening: row },
            downstream: { totals },
          };
        } finally {
          await removeOpening(page, 'G');
        }
      },
    ),
    C(
      'lookup.change-type',
      'T04',
      'read-only',
      'DISPLAY_DATA (:1269-1286) reloads the grid for the type chosen; unsaved cells of the previous type are dropped',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        await loadType(page, 'G');
        await enterCell(page, 'GrWt', 1, '7');
        await loadType(page, 'S');
        assert.equal(await cell(page, 'ItCode', 1).inputValue(), SILVER);
        assert.equal(await cell(page, 'GrWt', 1).inputValue(), '');
        await loadType(page, 'P');
        // No platinum item: one empty row.
        assert.equal(await cell(page, 'ItCode', 1).inputValue(), '');
        assert.equal(await cell(page, 'ItCode', 2).count(), 0);
        const written = await count(ctx, 'ITM_OPBL', `"CO_BOOK"='000'`);
        assert.equal(written, 0, 'choosing a type writes nothing');
        return {
          observation: `gold typed then silver listed ${SILVER} with blank cells; platinum one empty row; ${written} rows written`,
          expected: { silver: SILVER, platinum: 'one empty row', written: 0 },
        };
      },
    ),
    C(
      'children.two-types-row-gaps',
      'T05',
      'mutation',
      'DISPLAY_DATA order IT_TYPE, GR_CODE, IT_NAME (:1273); BtnSave keeps SR_NO = grid row (:1424) and replaces only the type saved (:1414)',
      async (ctx) => {
        const { page } = await ctx.session();
        // A second gold item in the same group; its name sorts first, so the fixture's item moves to row 2.
        await exec(
          ctx,
          `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE") VALUES ($1,'01',$2,$3,'G','E1')`,
          ADDED_ITEM.code,
          ADDED_ITEM.name,
        );
        try {
          await openScreen(page);
          await loadType(page, 'G');
          assert.deepEqual(
            [
              await cell(page, 'ItCode', 1).inputValue(),
              await cell(page, 'ItCode', 2).inputValue(),
            ],
            [ADDED_ITEM.code, GOLD],
          );
          await enterCell(page, 'GrWt', 2, '5');
          const gold = await save(page);
          assert.equal(gold.status(), 200, await gold.text());
          await saveType(page, 'S', { GrWt: '100' });
          const g = await opbl(ctx, 'G');
          const s = await opbl(ctx, 'S');
          assert.deepEqual(
            g.map((r) => [r.sr, r.it, r.gwt]),
            [[2, GOLD, 5]],
          );
          assert.deepEqual(
            s.map((r) => [r.sr, r.it, r.gwt]),
            [[1, SILVER, 100]],
          );
          const posted = [...(await stock(ctx, 'G')), ...(await stock(ctx, 'S'))];
          assert.deepEqual(
            posted.map((r) => [r.sr, r.it, r.gwt]),
            [
              [2, GOLD, 5],
              [1, SILVER, 100],
            ],
          );
          return {
            observation: `gold rows ${JSON.stringify(g.map((r) => [r.sr, r.it]))}; silver rows ${JSON.stringify(s.map((r) => [r.sr, r.it]))}`,
            expected:
              'gold SR_NO 2 (row 1 left blank), silver SR_NO 1, each type in its own voucher',
            database: { gold: g, silver: s, stock: posted },
            downstream: { stockRows: posted.length },
          };
        } finally {
          await removeOpening(page, 'G');
          await removeOpening(page, 'S');
          await exec(
            ctx,
            `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"=$2`,
            ADDED_ITEM.code,
          );
        }
      },
    ),
    C(
      'refusal.type-and-item',
      'T06',
      'refusal',
      'BtnSave_Click :1407 "Please Select Metaltype...."; BtnDelete_Click :1505 "Please Select Item For Delete."; the web refuses an item of another metal type (gap G222)',
      async (ctx) => {
        const { page, requests } = await ctx.session();
        await openScreen(page);
        await button(page, 'Save').click();
        await page.getByText('Please Select Metaltype....', { exact: true }).waitFor();
        await button(page, 'Delete').click();
        await page.getByText('Please Select Item For Delete.', { exact: true }).waitFor();
        assert.equal(
          requests.filter((r) => ['PUT', 'DELETE'].includes(r.method)).length,
          0,
          'no request leaves the screen',
        );
        await loadType(page, 'G');
        await enterCell(page, 'GrWt', 1, '2');
        // Enter on the last row's NetAmt adds a row; a silver item typed there is not a gold item.
        const netAmt = cell(page, 'NetAmt', 1);
        await netAmt.focus();
        await netAmt.press('Enter');
        await cell(page, 'ItCode', 2).fill(SILVER);
        await enterCell(page, 'GrWt', 2, '3');
        const response = await save(page);
        assert.equal(response.status(), 400);
        await page
          .getByText(`item ${SILVER} is not a G item in this company`, { exact: true })
          .waitFor();
        const written = await opbl(ctx, 'G');
        assert.equal(written.length, 0, 'nothing is written');
        return {
          observation: `blank type refused for save and delete; ${SILVER} in the gold grid answered ${response.status()}`,
          expected: 'the desktop texts; a 400 for the wrong metal type; no rows',
          database: { opening: written },
        };
      },
    ),
    C(
      'create.footprint',
      'T07',
      'mutation',
      'BtnSave_Click (:1414-1449) and Ac_Stock.Itm_Opbl_Stk (Ac_Stock.cs:11-21): one opening row, one ITOBL stock row dated the day before the year, no other-detail row (OTH_DETL_POSTING not Y), no voucher header, no ledger; then CLEAR_DATA',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await saveType(page, 'G', { Pcs: '1', GrWt: '10.5', Touch: '91.6' });
          // CLEAR_DATA: blank type, one empty row, the cursor on the type.
          const type = page.getByLabel('Item Type', { exact: true });
          assert.equal(await type.inputValue(), '');
          assert.equal(await cell(page, 'ItCode', 1).inputValue(), '');
          assert.equal(await focused(type), true);
          const coYear = await sessionYear(page);
          const stockDate = await stockDateOf(ctx, coYear);
          const rows = await opbl(ctx, 'G');
          assert.equal(rows.length, 1);
          const [row] = rows;
          assert.deepEqual(
            [
              row.yr,
              row.book,
              row.vch,
              row.sr,
              row.it,
              row.pcs,
              row.gwt,
              row.nwt,
              row.touch,
              row.fine,
              row.na,
            ],
            [coYear, '000', 'G', 1, GOLD, 1, 10.5, 10.5, 91.6, 9.618, 0],
          );
          assert.deepEqual([row.dt, row.trfr], ['A', 'Y']);
          assert.equal(String(row.mu).toLowerCase(), USERS.admin.user.toLowerCase());
          const posted = await stock(ctx, 'G');
          assert.deepEqual(posted, [
            {
              yr: coYear,
              sr: 1,
              isr: 1,
              dt: stockDate,
              sd: stockDate,
              vt: 'ITOBL',
              bn: 'ITM OPBL',
              ac: '00000',
              it: GOLD,
              tag: 'N',
              tr: 'P',
              sg: '+',
              qty: 1,
              pcs: 1,
              gwt: 10.5,
              nwt: 10.5,
              touch: 91.6,
              fine: 9.618,
              amt: 0,
              la: 0,
              oa: 0,
              na: 0,
              krn: 10.5,
              krf: 9.618,
              krc: 0,
            },
          ]);
          const others = {
            dmData: await count(ctx, 'DM_DATA', `"CO_BOOK"='000'`),
            barData: await count(ctx, 'BAR_DATA', `"CO_BOOK"='000'`),
            acData: await count(ctx, 'AC_DATA', `"CO_BOOK"='000'`),
          };
          assert.deepEqual(others, { dmData: 0, barData: 0, acData: 0 });
          return {
            observation: `opening ${JSON.stringify(row)}; stock ${JSON.stringify(posted[0])}; ${JSON.stringify(others)}`,
            expected: `one row in book 000 / G / SR 1; one P + ITOBL row dated ${stockDate}; nothing else`,
            database: { opening: rows, stock: posted, others },
            downstream: { stockDate },
          };
        } finally {
          await removeOpening(page, 'G');
        }
      },
    ),
    C(
      'reopen.unchanged-imported',
      'T08',
      'mutation',
      'DISPLAY_DATA shows the stored cells (:1290-1331) and BtnSave stores the cells as they are (:1424-1440): an imported row whose fine is not the formula keeps it',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        const coYear = await sessionYear(page);
        // An opening as the desktop or a migration leaves it: touch 0 but a fine below the net weight.
        await exec(
          ctx,
          `INSERT INTO "ITM_OPBL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","ITM_PCS",
             "ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","ITM_RATE","ITM_AMT","LBR_TYPE","LBR_RATE","LBR_AMT",
             "OTH_AMT","NET_AMT","MAIN_USER","DATA_TYPE","DATA_TRFR")
           VALUES ($1,'01','01',$2,'000','G',1,$3,3,12,11.5,0,0,10.75,0,0,'',0,0,0,0,'IMPORT','A','Y')`,
          coYear,
          GOLD,
        );
        try {
          await loadType(page, 'G');
          const shown = await rowValues(page, 1);
          assert.deepEqual(
            [shown.Pcs, shown.GrWt, shown.NetWt, shown.Touch, shown.Fine],
            ['3', '12.000', '11.500', '', '10.750'],
          );
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          const [row] = await opbl(ctx, 'G');
          assert.deepEqual(
            [row.pcs, row.gwt, row.nwt, row.touch, row.fine],
            [3, 12, 11.5, 0, 10.75],
          );
          const [posted] = await stock(ctx, 'G');
          assert.deepEqual(
            [posted.gwt, posted.nwt, posted.fine, posted.krf],
            [12, 11.5, 10.75, 10.75],
          );
          return {
            observation: `shown ${JSON.stringify(shown)}; stored ${JSON.stringify(row)}`,
            expected: 'fine 10.750 shown and kept (the formula would give 11.5)',
            database: { opening: row, stock: posted },
            downstream: { reopened: shown },
          };
        } finally {
          await removeOpening(page, 'G');
        }
      },
    ),
    C(
      'edit.gross-only',
      'T09',
      'mutation',
      'CommPassTotal: a typed net weight stays, so a new gross changes only the gross, the G labour (gross × rate) and the net amount; the other type is untouched',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          // fine = 10 × 91.6 / 100 = 9.16; labour = 10.5 × 13 = 136.5 → 136.
          await saveType(page, 'G', {
            Pcs: '1',
            GrWt: '10.5',
            NetWt: '10',
            Touch: '91.6',
            LType: 'G',
            LRate: '13',
          });
          await saveType(page, 'S', { GrWt: '100' });
          const silverBefore = await opbl(ctx, 'S');
          await openScreen(page);
          await loadType(page, 'G');
          await enterCell(page, 'GrWt', 1, '11');
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          const [row] = await opbl(ctx, 'G');
          // labour = 11 × 13 = 143; net amount 143.
          assert.deepEqual([row.gwt, row.nwt, row.fine, row.la, row.na], [11, 10, 9.16, 143, 143]);
          const [posted] = await stock(ctx, 'G');
          assert.deepEqual([posted.gwt, posted.la, posted.krc], [11, 143, 143]);
          const silverAfter = await opbl(ctx, 'S');
          assert.deepEqual(silverAfter, silverBefore, 'the silver opening is untouched');
          return {
            observation: `gold ${JSON.stringify(row)}; silver unchanged ${JSON.stringify(silverAfter)}`,
            expected: 'gross 11, net 10, fine 9.16, labour 143, net amount 143',
            database: { gold: row, stock: posted, silver: silverAfter },
            downstream: { silverUnchanged: true },
          };
        } finally {
          await removeOpening(page, 'G');
          await removeOpening(page, 'S');
        }
      },
    ),
    C(
      'delete.type',
      'T10',
      'mutation',
      'BtnDelete_Click (:1492-1517): the confirm text, then the type\'s stock, other-detail and opening rows go, "Delete Success." and CLEAR_DATA; other types and other stock stay',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await saveType(page, 'G', { GrWt: '10.5' });
          await saveType(page, 'S', { GrWt: '100' });
          const otherStock = await count(ctx, 'MAIN_STOCK', `"VCH_TYPE" IS DISTINCT FROM 'ITOBL'`);
          await openScreen(page);
          await loadType(page, 'G');
          let asked = '';
          page.once('dialog', (dialog) => {
            asked = dialog.message();
          });
          const [response] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'DELETE', '/stock/item-opening/type/G')),
            button(page, 'Delete').click(),
          ]);
          assert.equal(response.status(), 200, await response.text());
          await page.getByText('Delete Success.', { exact: true }).waitFor();
          assert.equal(asked, 'Are You Sure To Delete All Item Opening From This Record now?');
          assert.equal(await page.getByLabel('Item Type', { exact: true }).inputValue(), '');
          const gold = { opening: await opbl(ctx, 'G'), stock: await stock(ctx, 'G') };
          const silver = { opening: await opbl(ctx, 'S'), stock: await stock(ctx, 'S') };
          assert.deepEqual([gold.opening.length, gold.stock.length], [0, 0]);
          assert.deepEqual([silver.opening.length, silver.stock.length], [1, 1]);
          assert.equal(
            await count(ctx, 'MAIN_STOCK', `"VCH_TYPE" IS DISTINCT FROM 'ITOBL'`),
            otherStock,
          );
          return {
            observation: `asked "${asked}"; gold rows ${gold.opening.length}/${gold.stock.length}; silver ${silver.opening.length}/${silver.stock.length}`,
            expected: 'the desktop question; gold gone; silver and the other stock rows kept',
            database: { gold, silver },
            downstream: { otherStock },
          };
        } finally {
          await removeOpening(page, 'S');
        }
      },
    ),
    C(
      'rights.view-only',
      'T11',
      'refusal',
      'TR_ITM_OPBL_Load reads FRM_EDIT/FRM_DELETE/FRM_PRINT (:1061-1063); Save, Delete and Print answer "You Have No Rights....." / "You Have No Print Rights....." (:1371-1405, :1494); the server refuses the same save',
      async (ctx) => {
        await exec(
          ctx,
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
           VALUES ($1,'01','01',$2,'Master','Item Opening','Y','N','N','N')`,
          USERS.clerk.user,
        );
        try {
          const { page, requests } = await ctx.session(as(USERS.clerk.user));
          await openScreen(page);
          const grid = await loadType(page, 'G');
          await enterCell(page, 'GrWt', 1, '5');
          await button(page, 'Save').click();
          await page.getByText('You Have No Rights.....', { exact: true }).waitFor();
          await button(page, 'Delete').click();
          await page.getByText('You Have No Rights.....', { exact: true }).waitFor();
          await button(page, 'Print').click();
          await page.getByText('You Have No Print Rights.....', { exact: true }).waitFor();
          assert.equal(requests.filter((r) => ['PUT', 'DELETE'].includes(r.method)).length, 0);
          // The same save sent straight to the server.
          const direct = await page.request.put('/api/stock/item-opening/type/G', {
            data: { expectedVersion: grid.version, rows: [{ itCode: GOLD, grossWt: 5 }] },
          });
          assert.equal(direct.status(), 403);
          const written = await opbl(ctx, 'G');
          assert.equal(written.length, 0);
          return {
            observation: `clerk refused on screen for save, delete and print; direct PUT answered ${direct.status()}`,
            expected: 'the desktop texts and a 403; no rows',
            database: { opening: written },
          };
        } finally {
          await exec(
            ctx,
            `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Item Opening'`,
            USERS.clerk.user,
          );
        }
      },
    ),
    C(
      'concurrency.two-operators',
      'T12',
      'mutation',
      'N51 version token: two operators read the gold grid; the first save wins and the second is refused instead of silently replacing it (the desktop lets the later save win)',
      async (ctx) => {
        const a = (await ctx.session()).page;
        const b = (await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#2`))).page;
        try {
          await openScreen(a);
          await openScreen(b);
          await loadType(a, 'G');
          await loadType(b, 'G');
          await enterCell(a, 'GrWt', 1, '5');
          const first = await save(a);
          assert.equal(first.status(), 200, await first.text());
          await enterCell(b, 'GrWt', 1, '7');
          const second = await save(b);
          assert.equal(second.status(), 409);
          await b
            .getByText(
              'This voucher was changed by someone else after you opened it. Reload it before saving or deleting.',
              { exact: true },
            )
            .waitFor();
          const rows = await opbl(ctx, 'G');
          assert.deepEqual(
            rows.map((r) => r.gwt),
            [5],
          );
          await loadType(b, 'G');
          assert.equal(await cell(b, 'GrWt', 1).inputValue(), '5.000');
          return {
            observation: `first save 200, second 409; stored gross ${rows.map((r) => r.gwt)}; the second operator now reads 5.000`,
            expected: 'one result (5) and a defined conflict',
            database: { opening: rows },
            downstream: { secondStatus: second.status() },
          };
        } finally {
          await removeOpening(a, 'G');
        }
      },
    ),
    C(
      'retry.replayed-save',
      'T13',
      'mutation',
      "A save replaces the type's rows; the same request sent again carries a spent version and is refused, so a lost acknowledgement cannot double the opening",
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await openScreen(page);
          await loadType(page, 'G');
          await enterCell(page, 'GrWt', 1, '10.5');
          const first = await save(page);
          assert.equal(first.status(), 200, await first.text());
          const replay = (await page.request.fetch(first.request())).status();
          assert.equal(replay, 409);
          const rows = await opbl(ctx, 'G');
          const posted = await stock(ctx, 'G');
          assert.deepEqual([rows.length, posted.length], [1, 1]);
          return {
            observation: `replay answered ${replay}; ${rows.length} opening row, ${posted.length} stock row`,
            expected: 'one row each',
            database: { opening: rows, stock: posted },
            downstream: { replay },
          };
        } finally {
          await removeOpening(page, 'G');
        }
      },
    ),
    pending('rollback', 'T14', 'No fault injector in the harness yet (G173 / N166).'),
    C(
      'history.other-year',
      'T15',
      'mutation',
      "The web reads and replaces only this year's book 000 rows (gap G222); the desktop reload (:1286) has no year filter and would show another year's opening",
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        const coYear = await sessionYear(page);
        const [other] = await ctx.rows(
          `SELECT "CO_YEAR" yr FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "CO_YEAR"<>$2 ORDER BY 1 LIMIT 1`,
          coYear,
        );
        assert.ok(other, 'the catalogue has a second year');
        await exec(
          ctx,
          `INSERT INTO "ITM_OPBL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","ITM_PCS",
             "ITM_GWT","ITM_NWT","ITM_FINE","MAIN_USER","DATA_TYPE","DATA_TRFR")
           VALUES ($1,'01','01',$2,'000','G',1,$3,0,3,3,3,'IMPORT','A','Y')`,
          other.yr,
          GOLD,
        );
        try {
          await loadType(page, 'G');
          assert.equal(
            await cell(page, 'GrWt', 1).inputValue(),
            '',
            "another year's opening is not shown",
          );
          await enterCell(page, 'GrWt', 1, '4');
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          const rows = await opbl(ctx, 'G');
          assert.deepEqual(
            rows.map((r) => [r.yr, r.gwt]).sort(),
            [
              [coYear, 4],
              [other.yr, 3],
            ].sort(),
          );
          return {
            observation: `rows by year ${JSON.stringify(rows.map((r) => [r.yr, r.gwt]))}`,
            expected: `${other.yr} keeps 3; ${coYear} has 4`,
            database: { opening: rows },
            downstream: { years: [coYear, other.yr] },
          };
        } finally {
          await removeOpening(page, 'G');
          await exec(
            ctx,
            `DELETE FROM "ITM_OPBL" WHERE tenant_id=$1 AND "CO_YEAR"=$2 AND "CO_BOOK"='000' AND "VCH_NO"='G'`,
            other.yr,
          );
        }
      },
    ),
    C(
      'output.item-stock-ledger',
      'T16',
      'output',
      'An opening is purchase-in stock (Itm_Opbl_Stk, P / +): the Item Stock Ledger shows it as an IN movement of the item until it is deleted',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await ledgerRow(page, GOLD);
        try {
          await saveType(page, 'G', { Pcs: '1', GrWt: '10.5', Touch: '91.6' });
          const after = await ledgerRow(page, GOLD);
          const change = {
            inFine: r3(after.inFine - before.inFine),
            inPcs: r3(after.inPcs - before.inPcs),
            moves: after.moves - before.moves,
          };
          assert.deepEqual(change, { inFine: 9.618, inPcs: 1, moves: 1 });
          const text = JSON.stringify({ before, after, change });
          return {
            observation: `ledger change ${JSON.stringify(change)}`,
            expected: '+9.618 fine in, +1 piece in, one more movement',
            output: Buffer.from(text),
          };
        } finally {
          await removeOpening(page, 'G');
        }
      },
    ),
    C(
      'keyboard.desktop-keys',
      'T17',
      'mutation',
      'TEXT_ENTRY_KeyDown (:1583-1670), TR_ITM_OPBL_KeyPress (:1538-1551), TR_ITM_OPBL_KeyDown (:1553-1574) and the &Save mnemonic',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await openScreen(page);
          const type = page.getByLabel('Item Type', { exact: true });
          await type.selectOption('G');
          await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', '/stock/item-opening/type/G')),
            page.keyboard.press('Enter'),
          ]);
          await page.getByTestId('item-opening-loaded').waitFor();
          assert.equal(await focused(cell(page, 'Rtype', 1)), true);
          await page.keyboard.press('Enter');
          assert.equal(await focused(cell(page, 'Pcs', 1)), true, 'Enter moves one cell right');
          await page.keyboard.type('1');
          await page.keyboard.press('Enter');
          await page.keyboard.type('10.5');
          await page.keyboard.press('Enter');
          assert.equal(await focused(cell(page, 'NetWt', 1)), true);
          assert.equal(await cell(page, 'NetWt', 1).inputValue(), '10.500');
          await page.keyboard.press('ArrowLeft');
          assert.equal(await focused(cell(page, 'GrWt', 1)), true, 'the arrows move one cell');
          await cell(page, 'LType', 1).focus();
          await page.keyboard.type("g'");
          assert.equal(await cell(page, 'LType', 1).inputValue(), 'G', 'upper case, no apostrophe');
          await cell(page, 'NetAmt', 1).focus();
          await page.keyboard.press('Enter');
          assert.equal(await focused(cell(page, 'ItCode', 2)), true, 'the last NetAmt adds a row');
          await page.keyboard.press('Enter');
          assert.equal(await focused(button(page, 'Save')), true, 'an empty ItCode goes to Save');
          await cell(page, 'Pcs', 1).focus();
          await page.keyboard.press('Escape');
          assert.equal(
            await focused(button(page, 'Save')),
            true,
            'Esc after a change goes to Save',
          );
          const response = await save(page, () => page.keyboard.press('Alt+s'));
          assert.equal(response.status(), 200, await response.text());
          await page.getByText('Data Are Saved.', { exact: true }).waitFor();
          const [row] = await opbl(ctx, 'G');
          assert.deepEqual([row.pcs, row.gwt, row.lt], [1, 10.5, 'G']);
          // An unchanged screen: Esc leaves it.
          await loadType(page, 'G');
          await cell(page, 'Pcs', 1).focus();
          await page.keyboard.press('Escape');
          await page.waitForURL((url) => !url.pathname.startsWith('/txn/item-opening'));
          return {
            observation: `keys as the desktop; Alt+S saved ${JSON.stringify(row)}; Esc left the unchanged screen`,
            expected: 'Enter, arrows, NetAmt append, empty ItCode to Save, Esc rules, Alt+S',
            database: { opening: row },
            downstream: { left: page.url() },
          };
        } finally {
          await removeOpening(page, 'G');
        }
      },
    ),
    C(
      'journey.open-then-sell',
      'T18',
      'mutation',
      'Opening stock (P +) is sold through Sales Invoice (stock -): the item stock moves in and out; deleting the sale and the opening restores it',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await ledgerRow(page, GOLD);
        let saleNo = '';
        try {
          await saveType(page, 'G', { Pcs: '1', GrWt: '10.5', Touch: '91.6' });
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
          const saleCell = (column) =>
            page.locator(`[data-grid-row="0"][data-grid-column="${column}"] input`).first();
          await saleCell(0).fill(GOLD);
          await saleCell(0).press('Escape');
          // A loose sale of 10 g net at touch 91.6: fine 9.16.
          for (const [column, value] of [
            [2, '1'],
            [3, '10.25'],
            [4, '10'],
            [5, '91.6'],
            [6, '6123.45'],
          ])
            await saleCell(column).fill(value);
          const [sale] = await Promise.all([
            page.waitForResponse(
              (r) => r.request().method() === 'POST' && new URL(r.url()).pathname === '/api/sales',
            ),
            button(page, 'Save Invoice').click(),
          ]);
          assert.equal(sale.status(), 201, await sale.text());
          saleNo = String((await sale.json()).vchNo).padStart(5, '0');
          const during = await ledgerRow(page, GOLD);
          const change = {
            inFine: r3(during.inFine - before.inFine),
            outFine: r3(during.outFine - before.outFine),
            netFine: r3(during.netFine - before.netFine),
          };
          // In 9.618 (the opening), out 9.16 (the sale): net +0.458.
          assert.deepEqual(change, { inFine: 9.618, outFine: 9.16, netFine: 0.458 });
          return {
            observation: `after opening and sale ${saleNo}: ${JSON.stringify(change)}`,
            expected: 'in 9.618, out 9.16, net 0.458',
            database: { sale: saleNo, opening: await opbl(ctx, 'G') },
            downstream: { ledger: change },
          };
        } finally {
          if (saleNo) {
            await page.goto('/txn/sales');
            await page.getByRole('heading', { name: 'Sales Invoice', exact: true }).waitFor();
            await page.getByLabel('Voucher No', { exact: true }).fill(saleNo);
            await button(page, 'Load').click();
            await page
              .getByTestId('sales-loaded')
              .filter({ hasText: `Loaded #${saleNo}` })
              .waitFor();
            const [deleted] = await Promise.all([
              page.waitForResponse(
                (r) => r.request().method() === 'DELETE' && /\/api\/sales\//.test(r.url()),
              ),
              button(page, 'Delete').click(),
            ]);
            assert.equal(deleted.status(), 200, await deleted.text());
          }
          await removeOpening(page, 'G');
          const after = await ledgerRow(page, GOLD);
          assert.equal(
            r3(after.netFine - before.netFine),
            0,
            'the item stock is back where it was',
          );
        }
      },
    ),
  ],
};
