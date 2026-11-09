import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import { escLeavesWithNoFocus, SECOND_TENANT } from '../harness.mjs';

/**
 * Feature: Master → AutoItem (desktop MS_AUTO_ITEM with CurMast 'AutoItem', web /masters/auto-item).
 *
 * Desktop rules used for the expected values (MS_AUTO_ITEM.cs unless noted):
 * - The menu button 'AutoItem' opens MS_AUTO_ITEM with the caption as CurMast (MDI_FORM.cs:7640-7649); none of the
 *   Labour / Item Touch branches apply, so the form shows Group Code, name, type, trade type and HSN code over the
 *   Sr. / Pr Code / Pr Name / MinStk / Y/N grid (MSG_CLEAR :1640-1683) with the cursor in the group code.
 * - The group comes from its help by name (tGrCode_KeyDown :3432-3493); DISPLAY_DATA (:2614-2650) lists the products but
 *   HM, DM, OG, OS, SN, FN, RD, EM and OT by code, Y in red when the group has an item of the product, else N; the cursor
 *   goes to row 1's Y/N.
 * - Grid keys (:3040-3239): Enter on Y/N needs Y or N ("Please Enter Y or N and Try Again...") and goes to the next
 *   row's Y/N, adding a row on the last one with the cursor in its Pr Code; Enter on a blank Pr Code goes to Save; MinStk
 *   keeps Val as a whole number (MSG_LeaveCell :1880-1956); the arrows move; F1 copies the cell above; Esc goes to Save.
 * - Save (:2876-2923) makes PR_CODE + GR_CODE for each Y row the group lacks: IT_NAME = product name + " " + group code,
 *   IT_TYPE = TAG_TYPE = the type box, TRAD_TYPE, SAFE_NAME MAIN, HSN, UNIT_NAME GMS, RATE_TYPE G, MIN_STK, MAIN_USER
 *   (blank for a listed product, the user for an added row, CommPassAdd :1957-1976), STK_DISPLAY Y, DATA_TRFR N, flags N;
 *   existing items and N rows are untouched; "Data Are Saved."; the save needs the edit right once a group is shown.
 * - Print and Delete only check their rights in this mode (:2652-2659, :2927-2944).
 * Web rules that differ on purpose (gap G232): one transaction; a code another group's item has and an added unknown
 * product are refused; a typed group code fills the HSN code too.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `auto-item.${id}`,
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

const API = '/masters/auto-item';
const SAVED = 'Data Are Saved.';
const PRODUCTS = [
  ['A1', 'E2E AUTO RING'],
  ['A2', 'E2E AUTO CHAIN'],
  ['A3', 'E2E AUTO BANGLE'],
];
const GROUPS = [
  ['AIG', 'E2E AUTO GOLD', 'G', 'GO', '7113'],
  ['AIS', 'E2E AUTO SILVER', 'S', 'SL', '7114'],
];
const SKIPPED = ['HM', 'DM', 'OG', 'OS', 'SN', 'FN', 'RD', 'EM', 'OT'];

const path = (r) => new URL(r.url()).pathname;
const isApi = (r, method, p) => r.request().method() === method && path(r) === `/api${p}`;
const label = (page, text) => page.getByLabel(text, { exact: true });
const button = (page, name) => page.getByRole('button', { name, exact: true });
const focusedId = (page) =>
  page.evaluate(
    () =>
      document.activeElement?.getAttribute('aria-label') ||
      document.activeElement?.id ||
      document.activeElement?.textContent?.trim() ||
      '',
  );
const message = (page, text) => page.getByText(text, { exact: true }).waitFor();
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);
const cell = (page, header, row) => label(page, `${header} row ${row}`);

const madeItems = (ctx) =>
  ctx.rows(
    `SELECT "IT_CODE" code,"IT_NAME" name,"IT_TYPE" type,"TAG_TYPE" tag,"TRAD_TYPE" trade,"PR_CODE" pr,"GR_CODE" gr,
            "SAFE_NAME" safe,"HSN_CODE" hsn,"UNIT_NAME" unit,"RATE_TYPE" rate,"MIN_STK" minstk,"MAIN_USER" main,
            "STK_DISPLAY" stk,"DATA_TRFR" trfr,"TAG_IDTL_COL" tagcol,"OTH_DETL_POSTING" othpost,"OTH_ITM_WT_REMOVE" wtremove
       FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "GR_CODE" = ANY($2::text[]) ORDER BY "IT_CODE"`,
    GROUPS.map(([code]) => code),
  );
/** DISPLAY_DATA's list for a group: the company's products but the skipped ones, by code, Y for the group's own. */
const dbGrid = async (ctx, grCode) =>
  (
    await ctx.rows(
      `SELECT p."PR_CODE" pr,p."PR_NAME" name,
              EXISTS (SELECT 1 FROM "ITEM_MAST" i WHERE i.tenant_id=p.tenant_id AND i."CO_CODE"=p."CO_CODE"
                        AND i."GR_CODE"=$2 AND i."PR_CODE"=p."PR_CODE") made
         FROM "PRODUCT_MAST" p WHERE p.tenant_id=$1 AND p."CO_CODE"='01' AND NOT (coalesce(p."PR_CODE",'') = ANY($3::text[]))
        ORDER BY p."PR_CODE",p."PR_NAME",p.row_id`,
      grCode,
      SKIPPED,
    )
  ).map((r) => [String(r.pr ?? '').trim(), String(r.name ?? '').trim(), r.made ? 'Y' : 'N']);

async function cleanCase(ctx) {
  await exec(
    ctx,
    `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND ("GR_CODE" = ANY($2::text[]) OR "IT_CODE" = ANY($3::text[]))`,
    GROUPS.map(([code]) => code),
    ['A1A', 'A9AIG'],
  );
}
async function withMasters(ctx, run) {
  const productCodes = [...PRODUCTS.map(([code]) => code), 'A9', 'OG'];
  await exec(
    ctx,
    `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "PR_CODE" = ANY($2::text[])`,
    productCodes,
  );
  for (const [code, name] of [...PRODUCTS, ['OG', 'E2E AUTO OLD GOLD']])
    await exec(
      ctx,
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME","DATA_TRFR") VALUES ($1,'01',$2,$3,'N')`,
      code,
      name,
    );
  await exec(
    ctx,
    `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE" = ANY($2::text[])`,
    GROUPS.map(([c]) => c),
  );
  for (const [code, name, type, trade, hsn] of GROUPS)
    await exec(
      ctx,
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE","TRAD_TYPE","HSN_CODE","SALE_AC","PURC_AC")
       VALUES ($1,'01',$2,$3,$4,$5,$6,'SALES','PURCHASE')`,
      code,
      name,
      type,
      trade,
      hsn,
    );
  await cleanCase(ctx);
  try {
    return await run();
  } finally {
    await cleanCase(ctx);
    await exec(
      ctx,
      `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE" = ANY($2::text[])`,
      GROUPS.map(([c]) => c),
    );
    await exec(
      ctx,
      `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "PR_CODE" = ANY($2::text[])`,
      productCodes,
    );
  }
}

async function openScreen(page) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', API)),
    page.goto('/masters/auto-item'),
  ]);
  await page.getByRole('heading', { name: 'Auto Item', exact: true }).waitFor();
  if (response.status() === 200)
    await page.waitForFunction(
      () => document.activeElement?.getAttribute('aria-label') === 'Group Code',
    );
  return response;
}
/** Choose a group by typing its code and Enter (the help resolves the exact code); waits for the grid. */
async function chooseGroup(page, code) {
  const box = label(page, 'Group Code');
  await box.focus();
  await box.fill(code);
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => isApi(r, 'GET', API) && new URL(r.url()).searchParams.get('grCode') === code,
    ),
    box.press('Enter'),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.waitForFunction(
    () => document.activeElement?.getAttribute('aria-label') === 'Y/N row 1',
  );
}
const grid = (page) =>
  page
    .getByTestId('auto-item-grid')
    .locator('tr')
    .evaluateAll((rows) =>
      rows.map((tr) => [...tr.querySelectorAll('input')].map((input) => input.value.trim())),
    );
/** The grid row of a product code (1-based, as the cells' labels count). */
async function rowOf(page, prCode) {
  const rows = await grid(page);
  const index = rows.findIndex(([code]) => code === prCode);
  assert.ok(index >= 0, `${prCode} listed`);
  return index + 1;
}
async function save(page, trigger = () => button(page, 'Save').click()) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'POST', API)),
    trigger(),
  ]);
  return response;
}
async function saved(page) {
  await message(page, SAVED);
  await page.waitForFunction(
    () =>
      document.activeElement?.getAttribute('aria-label') === 'Group Code' &&
      document.querySelector('[aria-label="Group Code"]')?.value === '',
  );
}
/** Mark a product Y (or N) with its MinStk, as typed into the grid cells. */
async function mark(page, prCode, yn, minStk) {
  const row = await rowOf(page, prCode);
  if (minStk !== undefined) await cell(page, 'MinStk', row).fill(String(minStk));
  await cell(page, 'Y/N', row).fill(yn);
}

export const autoItem = {
  feature: 'auto-item',
  title: 'Master → AutoItem (MS_AUTO_ITEM)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/masters/auto-item/page.tsx',
    'web/apps/web/lib/screenEscape.ts',
    'web/apps/api/src/modules/masters/autoItem.ts',
    'web/apps/api/src/routes/autoItem.ts',
    'web/apps/web/test/features/modules/autoItem.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'MDI_FORM.cs:7640-7649 opens MS_AUTO_ITEM; CLEAR_DATA (:2241-2259) blank boxes and one empty grid row with the cursor in the group code; MSG_CLEAR (:1640-1683) Sr. / Pr Code / Pr Name / MinStk / Y/N; Save with no group writes nothing and says "Data Are Saved." (:2876-2923)',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const headers = (
            await page
              .getByTestId('auto-item-grid')
              .locator('xpath=..')
              .locator('thead th')
              .allInnerTexts()
          ).map((t) => t.trim());
          assert.deepEqual(headers, ['Sr.', 'Pr Code', 'Pr Name', 'MinStk', 'Y/N']);
          assert.deepEqual(await grid(page), [['', '', '', '']]);
          const boxes = {};
          for (const name of ['Group Code', 'Group Name', 'Group Type', 'Trade Type', 'Hsn Code'])
            boxes[name] = await label(page, name).inputValue();
          assert.deepEqual(Object.values(boxes), ['', '', '', '', '']);
          const drawn = [];
          for (const name of ['Save', 'Print', 'Cancel', 'Delete', 'Exit'])
            drawn.push([name, (await button(page, name).boundingBox()).x]);
          assert.deepEqual(
            drawn.sort((a, b) => a[1] - b[1]).map(([n]) => n),
            ['Print', 'Save', 'Cancel', 'Delete', 'Exit'],
          );
          // Save without a group: the save loop writes nothing and still answers "Data Are Saved." (:2876-2923).
          const posts = [];
          page.on('request', (r) => {
            if (r.method() === 'POST') posts.push(r.url());
          });
          await button(page, 'Save').click();
          await message(page, SAVED);
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Group Code',
          );
          assert.deepEqual(posts, []);
          return {
            observation: `headers ${headers.join('/')}, one empty row, cursor in the group; Save on it said "${SAVED}" and sent nothing`,
            expected: { headers },
          };
        }),
    ),
    C(
      'field.every-field',
      'T02',
      'mutation',
      'BtnSave_Click (:2876-2923) writes CO_CODE, IT_CODE (product + group), IT_NAME, IT_TYPE, TAG_TYPE, TRAD_TYPE, PR_CODE, GR_CODE, SAFE_NAME MAIN, HSN_CODE, UNIT_NAME GMS, RATE_TYPE G, MIN_STK, MAIN_USER, STK_DISPLAY Y, DATA_TRFR N and the flags N for each Y row',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await chooseGroup(page, 'AIG');
          await mark(page, 'A1', 'Y', 5);
          await mark(page, 'A2', 'N', 9);
          await mark(page, 'A3', 'Y', '');
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          assert.deepEqual(await response.json(), { created: ['A1AIG', 'A3AIG'], existing: [] });
          await saved(page);
          const base = {
            type: 'G',
            tag: 'G',
            trade: 'GO',
            gr: 'AIG',
            safe: 'MAIN',
            hsn: '7113',
            unit: 'GMS',
            rate: 'G',
            main: '',
            stk: 'Y',
            trfr: 'N',
            tagcol: 'N',
            othpost: 'N',
            wtremove: 'N',
          };
          const rows = await madeItems(ctx);
          assert.deepEqual(rows, [
            { ...base, code: 'A1AIG', name: 'E2E AUTO RING AIG', pr: 'A1', minstk: 5 },
            { ...base, code: 'A3AIG', name: 'E2E AUTO BANGLE AIG', pr: 'A3', minstk: 0 },
          ]);
          return {
            observation: 'A1 and A3 made as A1AIG and A3AIG with every desktop field; A2 (N) left',
            expected: rows,
            database: { rows },
            downstream: { created: ['A1AIG', 'A3AIG'] },
          };
        }),
    ),
    C(
      'formula.min-stock-and-letters',
      'T03',
      'mutation',
      'MSG_LeaveCell keeps Strings.Format(Val, "0") in MinStk (:1880-1956): 2.6x becomes 3 and a blank 0; MS_AUTO_ITEM_KeyPress upper-cases the Y/N cell (:2965-2978)',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await chooseGroup(page, 'AIG');
          const row = await rowOf(page, 'A1');
          await cell(page, 'MinStk', row).fill('2.6x');
          await cell(page, 'MinStk', row).press('Enter');
          assert.equal(await cell(page, 'MinStk', row).inputValue(), '3');
          assert.equal(await focusedId(page), `Y/N row ${row}`);
          await page.keyboard.type('y');
          assert.equal(await cell(page, 'Y/N', row).inputValue(), 'Y');
          assert.equal((await save(page)).status(), 200);
          await saved(page);
          const rows = await madeItems(ctx);
          assert.deepEqual(
            rows.map((r) => [r.code, r.minstk]),
            [['A1AIG', 3]],
          );
          return {
            observation: 'MinStk 2.6x showed 3 and was stored 3; y became Y',
            expected: { minstk: 3 },
            database: { rows },
            downstream: { shown: '3' },
          };
        }),
    ),
    C(
      'lookup.group-help-and-grid',
      'T04',
      'read-only',
      'tGrCode_KeyDown (:3432-3493): the group help by name fills the name, type, trade type and HSN code; DISPLAY_DATA (:2614-2650) lists the products but the default ones, Y in red for those the group already has',
      async (ctx) =>
        withMasters(ctx, async () => {
          await exec(
            ctx,
            `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE","GR_CODE") VALUES ($1,'01','A2AIS','E2E OLD CHAIN AIS','A2','AIS')`,
          );
          const { page } = await ctx.session();
          await openScreen(page);
          const box = label(page, 'Group Code');
          await box.focus();
          await page.keyboard.type('E2E AUTO S');
          await box.locator('xpath=..').getByText('AIS', { exact: true }).waitFor();
          const help = (await box.locator('xpath=..').locator('b').allInnerTexts()).map((t) =>
            t.trim(),
          );
          assert.ok(
            help.includes('AIS') && !help.includes('AIG'),
            `help for "E2E AUTO S": ${help}`,
          );
          const [response] = await Promise.all([
            page.waitForResponse(
              (r) => isApi(r, 'GET', API) && new URL(r.url()).searchParams.get('grCode') === 'AIS',
            ),
            box.press('Enter'),
          ]);
          assert.equal(response.status(), 200);
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Y/N row 1',
          );
          const boxes = {
            name: await label(page, 'Group Name').inputValue(),
            type: await label(page, 'Group Type').inputValue(),
            trade: await label(page, 'Trade Type').inputValue(),
            hsn: await label(page, 'Hsn Code').inputValue(),
          };
          assert.deepEqual(boxes, { name: 'E2E AUTO SILVER', type: 'S', trade: 'SL', hsn: '7114' });
          const shown = (await grid(page)).map(([code, name, , yn]) => [code, name, yn]);
          assert.deepEqual(shown, await dbGrid(ctx, 'AIS'));
          assert.ok(!shown.some(([code]) => SKIPPED.includes(code)), 'no default product listed');
          const red = await page
            .getByTestId('auto-item-grid')
            .locator('tr[data-made="true"]')
            .evaluateAll((rows) => rows.map((tr) => tr.querySelector('input').value));
          assert.deepEqual(red, ['A2']);
          return {
            observation: `help ${help.join(',')}; boxes ${JSON.stringify(boxes)}; red rows ${red.join(',')}`,
            expected: { boxes, red: ['A2'] },
          };
        }),
    ),
    C(
      'children.added-row',
      'T05',
      'mutation',
      'Enter on the last Y/N adds a row with the cursor in its Pr Code (TEXT_ENTRY_KeyDown :3157-3175, CommPassAdd :1957-1976); a product typed into it is made with MAIN_USER = the user, and Enter on a blank Pr Code goes to Save (:3147-3155)',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await chooseGroup(page, 'AIG');
          const rows = await grid(page);
          const last = rows.length;
          await cell(page, 'Y/N', last).fill('N');
          await cell(page, 'Y/N', last).press('Enter');
          await page.waitForFunction(
            (n) => document.activeElement?.getAttribute('aria-label') === `Pr Code row ${n}`,
            last + 1,
          );
          await page.keyboard.type('a1');
          await page.keyboard.press('Enter');
          await page.keyboard.type('e2e added ring');
          await page.keyboard.press('Enter');
          await page.keyboard.type('4');
          await page.keyboard.press('Enter');
          await page.keyboard.type('Y');
          await page.keyboard.press('Enter');
          await page.waitForFunction(
            (n) => document.activeElement?.getAttribute('aria-label') === `Pr Code row ${n}`,
            last + 2,
          );
          await page.keyboard.press('Enter');
          assert.equal(await focusedId(page), 'Save');
          const response = await save(page, () => page.keyboard.press('Enter'));
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const made = await madeItems(ctx);
          assert.deepEqual(
            made.map((r) => [r.code, r.name, r.minstk, r.main]),
            [['A1AIG', 'E2E ADDED RING AIG', 4, USERS.admin.user]],
          );
          return {
            observation: 'a row added at the bottom made A1AIG under the user',
            expected: { main: USERS.admin.user },
            database: { made },
            downstream: { rows: last + 2 },
          };
        }),
    ),
    C(
      'required.refusals',
      'T06',
      'refusal',
      'Enter on a Y/N that is neither Y nor N says "Please Enter Y or N and Try Again..." (:3176-3183); the web refuses an added product that is not in the product master and a code another group already has (G232); nothing written',
      async (ctx) =>
        withMasters(ctx, async () => {
          await exec(
            ctx,
            `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE","GR_CODE") VALUES ($1,'01','A1A','E2E OTHER GROUP ITEM','A1','AIS')`,
          );
          const before = await ctx.rows(
            `SELECT count(*)::int n FROM "ITEM_MAST" WHERE tenant_id=$1`,
          );
          const { page } = await ctx.session();
          await openScreen(page);
          await chooseGroup(page, 'AIG');
          await cell(page, 'Y/N', 1).fill('X');
          await cell(page, 'Y/N', 1).press('Enter');
          await message(page, 'Please Enter Y or N and Try Again...');
          assert.equal(await focusedId(page), 'Y/N row 1');
          await cell(page, 'Y/N', 1).fill('N');
          const rows = await grid(page);
          const last = rows.length;
          await cell(page, 'Y/N', last).fill('N');
          await cell(page, 'Y/N', last).press('Enter');
          await page.waitForFunction(
            (n) => document.activeElement?.getAttribute('aria-label') === `Pr Code row ${n}`,
            last + 1,
          );
          await page.keyboard.type('a9');
          await cell(page, 'Pr Name', last + 1).fill('E2E NO SUCH PRODUCT');
          await cell(page, 'Y/N', last + 1).fill('Y');
          let response = await save(page);
          assert.equal(response.status(), 400);
          await message(page, 'product A9 is not in the product master');
          // A one-character group: A1 + A = A1A, an item of group AIS.
          await exec(
            ctx,
            `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC") VALUES ($1,'01','A','E2E ONE','SALES','PURCHASE')`,
          );
          try {
            await openScreen(page);
            await chooseGroup(page, 'A');
            await mark(page, 'A1', 'Y');
            response = await save(page);
            assert.equal(response.status(), 400);
            await message(page, 'item A1A already exists in group AIS; it is not made again for A');
          } finally {
            await exec(ctx, `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE"='A'`);
          }
          const after = await ctx.rows(
            `SELECT count(*)::int n FROM "ITEM_MAST" WHERE tenant_id=$1`,
          );
          assert.deepEqual(after, before);
          return {
            observation:
              'the Y/N text, the unknown product and the taken code refused; nothing written',
            expected: 'no ITEM_MAST row added',
            database: { before: before[0].n, after: after[0].n },
          };
        }),
    ),
    C(
      'create.footprint',
      'T07',
      'mutation',
      'A save writes only the new ITEM_MAST rows (:2876-2923); no other table changes',
      async (ctx) =>
        withMasters(ctx, async () => {
          const counts = async () =>
            (
              await ctx.rows(
                `SELECT (SELECT count(*)::int FROM "ITEM_MAST" WHERE tenant_id=$1) i,(SELECT count(*)::int FROM "PRODUCT_MAST" WHERE tenant_id=$1) p,
                        (SELECT count(*)::int FROM "GROUP_MAST" WHERE tenant_id=$1) g,(SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1) s`,
              )
            )[0];
          const before = await counts();
          const { page } = await ctx.session();
          await openScreen(page);
          await chooseGroup(page, 'AIS');
          await mark(page, 'A2', 'Y', 1);
          assert.equal((await save(page)).status(), 200);
          await saved(page);
          const after = await counts();
          assert.deepEqual(after, { ...before, i: before.i + 1 });
          return {
            observation: `ITEM_MAST ${before.i} → ${after.i}`,
            expected: 'one row',
            database: { before, after },
            downstream: { code: 'A2AIS' },
          };
        }),
    ),
    C(
      'reopen.existing-shown',
      'T08',
      'mutation',
      'Choosing the group again shows the made products as Y in red (DISPLAY_DATA :2620-2630); saving them again makes nothing new (the dataView check :2889-2890)',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await chooseGroup(page, 'AIG');
          await mark(page, 'A1', 'Y', 2);
          assert.equal((await save(page)).status(), 200);
          await saved(page);
          await chooseGroup(page, 'AIG');
          const row = await rowOf(page, 'A1');
          assert.equal(await cell(page, 'Y/N', row).inputValue(), 'Y');
          assert.equal(
            await page.getByTestId('auto-item-grid').locator(`tr[data-made="true"]`).count(),
            1,
          );
          const response = await save(page);
          assert.deepEqual(await response.json(), { created: [], existing: ['A1AIG'] });
          await saved(page);
          const rows = await madeItems(ctx);
          assert.deepEqual(
            rows.map((r) => [r.code, r.minstk]),
            [['A1AIG', 2]],
          );
          return {
            observation: 'A1 shown Y in red; the second save made nothing',
            expected: { existing: ['A1AIG'] },
            database: { rows },
            downstream: { second: await response.json() },
          };
        }),
    ),
    C(
      'edit.n-keeps-existing',
      'T09',
      'mutation',
      'An existing item marked N is left as it is: BtnSave_Click only inserts (:2887-2915), it never updates or deletes',
      async (ctx) =>
        withMasters(ctx, async () => {
          await exec(
            ctx,
            `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE","GR_CODE","MIN_STK","MAIN_USER") VALUES ($1,'01','A2AIG','E2E KEPT CHAIN','A2','AIG',8,'DESKUSER')`,
          );
          const { page } = await ctx.session();
          await openScreen(page);
          await chooseGroup(page, 'AIG');
          await mark(page, 'A2', 'N', 1);
          await mark(page, 'A3', 'Y', 2);
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          assert.deepEqual(await response.json(), { created: ['A3AIG'], existing: [] });
          await saved(page);
          const rows = await madeItems(ctx);
          assert.deepEqual(
            rows.map((r) => [r.code, r.name, r.minstk, r.main]),
            [
              ['A2AIG', 'E2E KEPT CHAIN', 8, 'DESKUSER'],
              ['A3AIG', 'E2E AUTO BANGLE AIG', 2, ''],
            ],
          );
          return {
            observation:
              'A2AIG (marked N) kept with its name, MIN_STK 8 and user; A3AIG made beside it',
            expected: 'unchanged',
            database: { rows },
            downstream: { kept: true },
          };
        }),
    ),
    C(
      'delete.this-mode',
      'T10',
      'mutation',
      'BtnDelete_Click (:2927-2944) deletes only in the Labour mode; in the AutoItem mode it checks the delete right and does nothing',
      async (ctx) =>
        withMasters(ctx, async () => {
          await exec(
            ctx,
            `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE","GR_CODE") VALUES ($1,'01','A1AIG','E2E STAYS','A1','AIG')`,
          );
          const before = await madeItems(ctx);
          const { page, requests } = await ctx.session();
          await openScreen(page);
          await chooseGroup(page, 'AIG');
          const sent = requests.length;
          await button(page, 'Delete').click();
          await page.waitForTimeout(300);
          assert.deepEqual(
            requests.slice(sent).filter((r) => r.method !== 'GET'),
            [],
          );
          assert.equal(await page.locator('.msg').count(), 0);
          assert.deepEqual(await madeItems(ctx), before);
          return {
            observation: 'Delete sent nothing and changed nothing',
            expected: 'nothing',
            database: { rows: before },
            downstream: { requests: 0 },
          };
        }),
    ),
    C(
      'rights.view-only',
      'T11',
      'refusal',
      'MS_AUTO_ITEM_Load reads the user\'s rights row (:1978-1995): with a group shown Save needs FRM_EDIT ("You Have No Rights....."), Delete FRM_DELETE and Print FRM_PRINT ("You Have No Print Rights.....")',
      async (ctx) =>
        withMasters(ctx, async () => {
          await exec(
            ctx,
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES ($1,'01','01',$2,'Master','AutoItem','Y','N','N','N')`,
            USERS.clerk.user,
          );
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"='A1AIG'`,
            SECOND_TENANT,
          );
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME") VALUES ($1,'01','A1AIG','SENTINEL')`,
            SECOND_TENANT,
          );
          try {
            const { page, requests } = await ctx.session(as(USERS.clerk.user));
            await openScreen(page);
            await chooseGroup(page, 'AIG');
            await mark(page, 'A1', 'Y');
            await button(page, 'Save').click();
            await message(page, 'You Have No Rights.....');
            await button(page, 'Delete').click();
            await message(page, 'You Have No Rights.....');
            await button(page, 'Print').click();
            await message(page, 'You Have No Print Rights.....');
            assert.equal(requests.filter((r) => r.method === 'POST').length, 0);
            const direct = (
              await page.request.post(`/api${API}`, {
                data: { grCode: 'AIG', rows: [{ prCode: 'A1', prName: 'X', yn: 'Y' }] },
              })
            ).status();
            assert.equal(direct, 403);
            const rows = await madeItems(ctx);
            assert.deepEqual(rows, []);
            const sentinel = await ctx.owner.$queryRawUnsafe(
              `SELECT "IT_NAME" name FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"='A1AIG'`,
              SECOND_TENANT,
            );
            assert.deepEqual(sentinel, [{ name: 'SENTINEL' }]);
            return {
              observation: `clerk refused Save, Delete and Print; direct POST ${direct}`,
              expected: 'the desktop texts and 403, nothing written',
              database: { rows, sentinel },
            };
          } finally {
            await exec(
              ctx,
              `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='AutoItem'`,
              USERS.clerk.user,
            );
            await ctx.owner.$executeRawUnsafe(
              `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"='A1AIG'`,
              SECOND_TENANT,
            );
          }
        }),
    ),
    C(
      'concurrency.two-operators',
      'T12',
      'mutation',
      "Two operators make the same group's items: the first save makes them and the second finds them existing (one row each, under the item lock), where the desktop's two saves would insert the code twice",
      async (ctx) =>
        withMasters(ctx, async () => {
          const a = (await ctx.session()).page;
          const b = (await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#2`))).page;
          await openScreen(a);
          await openScreen(b);
          await chooseGroup(a, 'AIG');
          await chooseGroup(b, 'AIG');
          await mark(a, 'A1', 'Y');
          await mark(b, 'A1', 'Y');
          const [first, second] = await Promise.all([save(a), save(b)]);
          const answers = [await first.json(), await second.json()];
          assert.deepEqual(answers.map((x) => [x.created.length, x.existing.length]).sort(), [
            [0, 1],
            [1, 0],
          ]);
          const rows = await madeItems(ctx);
          assert.deepEqual(
            rows.map((r) => r.code),
            ['A1AIG'],
          );
          return {
            observation: `answers ${JSON.stringify(answers)}`,
            expected: 'one A1AIG',
            database: { rows },
            downstream: { answers },
          };
        }),
    ),
    C(
      'retry.replayed-save',
      'T13',
      'mutation',
      'A replayed save finds the items it made and makes nothing again',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await chooseGroup(page, 'AIS');
          await mark(page, 'A3', 'Y', 6);
          const first = await save(page);
          assert.equal(first.status(), 200);
          await saved(page);
          const replay = await page.request.fetch(first.request());
          assert.equal(replay.status(), 200);
          assert.deepEqual(await replay.json(), { created: [], existing: ['A3AIS'] });
          const rows = await madeItems(ctx);
          assert.deepEqual(
            rows.map((r) => [r.code, r.minstk]),
            [['A3AIS', 6]],
          );
          return {
            observation: 'the replay found A3AIS',
            expected: 'one row',
            database: { rows },
            downstream: { replay: await replay.json() },
          };
        }),
    ),
    C(
      'rollback.insert-fault',
      'T14',
      'mutation',
      'BtnSave_Click inserts one row at a time (:2915-2917), so a failure leaves the earlier rows made; on the web a fault on the second item rolls the first one back too',
      async (ctx) =>
        withMasters(ctx, async () => {
          await ctx.owner.$executeRawUnsafe(
            `CREATE OR REPLACE FUNCTION e2e_auto_item_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
             BEGIN
               IF NEW."IT_CODE" = 'A3AIG' THEN RAISE EXCEPTION 'e2e fault on the second item'; END IF;
               RETURN NEW;
             END $f$`,
          );
          await ctx.owner.$executeRawUnsafe(
            `CREATE TRIGGER e2e_auto_item_fault BEFORE INSERT ON "ITEM_MAST" FOR EACH ROW EXECUTE FUNCTION e2e_auto_item_fault()`,
          );
          try {
            const { page } = await ctx.session();
            await openScreen(page);
            await chooseGroup(page, 'AIG');
            await mark(page, 'A1', 'Y');
            await mark(page, 'A3', 'Y');
            const failed = await save(page);
            assert.equal(failed.status(), 400, await failed.text());
            const rows = await madeItems(ctx);
            assert.deepEqual(rows, [], 'A1AIG was rolled back with the failed A3AIG');
            return {
              observation: `the save answered ${failed.status()}; no item made`,
              expected: 'nothing',
              database: { rows },
              downstream: { status: failed.status() },
            };
          } finally {
            await ctx.owner.$executeRawUnsafe(
              `DROP TRIGGER IF EXISTS e2e_auto_item_fault ON "ITEM_MAST"`,
            );
            await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_auto_item_fault()`);
          }
        }),
    ),
    C(
      'history.company-wide',
      'T15',
      'mutation',
      'ITEM_MAST and PRODUCT_MAST have no year: the items made in this year show as Y in the historic year too (DISPLAY_DATA reads by CO_CODE)',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session(
            as(USERS.admin.user, `${USERS.admin.user}#auto-history`),
          );
          await openScreen(page);
          await chooseGroup(page, 'AIG');
          await mark(page, 'A2', 'Y');
          assert.equal((await save(page)).status(), 200);
          await saved(page);
          await page.goto('/select');
          await page.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
          await page.getByRole('combobox', { name: 'FINANCIAL YEAR' }).selectOption('2024-2025');
          await button(page, 'Open').click();
          await page.waitForURL('**/dashboard');
          await openScreen(page);
          await chooseGroup(page, 'AIG');
          const row = await rowOf(page, 'A2');
          assert.equal(await cell(page, 'Y/N', row).inputValue(), 'Y');
          return {
            observation: 'A2 is Y for AIG in 2024-2025',
            expected: 'the same items in every year',
            database: { rows: await madeItems(ctx) },
            downstream: { year: '2024-2025' },
          };
        }),
    ),
    C(
      'output.print-right-only',
      'T16',
      'output',
      'BtnPrint_Click (:2652-2659) checks the print right and prints nothing',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page, requests } = await ctx.session();
          await openScreen(page);
          await chooseGroup(page, 'AIG');
          await page.waitForTimeout(400);
          const sent = requests.length;
          await button(page, 'Print').click();
          await page.waitForTimeout(400);
          const after = requests.slice(sent).map((r) => `${r.method} ${r.path}`);
          assert.deepEqual(after, []);
          assert.equal(await page.locator('.msg').count(), 0);
          return {
            observation: 'Print sent nothing and showed nothing',
            expected: 'nothing',
            output: { requests: after },
          };
        }),
    ),
    C(
      'keyboard.desktop-keys',
      'T17',
      'mutation',
      'tGrCode_KeyDown (:3432-3493), TEXT_ENTRY_KeyDown (:3040-3239: Enter, the arrows, F1), MS_AUTO_ITEM_KeyDown Esc (:2980-3007) and the &Save mnemonic',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await page.keyboard.type('ais');
          const [response] = await Promise.all([
            page.waitForResponse(
              (r) => isApi(r, 'GET', API) && new URL(r.url()).searchParams.get('grCode') === 'AIS',
            ),
            page.keyboard.press('Enter'),
          ]);
          assert.equal(response.status(), 200);
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Y/N row 1',
          );
          const codes = (await grid(page)).map(([code]) => code);
          // Walk the Y/N column with Enter, marking A1 and A2 Y and the rest N.
          for (let i = 0; i < codes.length - 1; i++) {
            await page.keyboard.type(['A1', 'A2'].includes(codes[i]) ? 'y' : 'n');
            await page.keyboard.press('Enter');
            await page.waitForFunction(
              (n) => document.activeElement?.getAttribute('aria-label') === `Y/N row ${n}`,
              i + 2,
            );
          }
          await page.keyboard.type('n');
          // Left goes to MinStk of the last row, Up to the row above, F1 copies the cell above into it.
          await page.keyboard.press('ArrowLeft');
          assert.equal(await focusedId(page), `MinStk row ${codes.length}`);
          await page.keyboard.type('7');
          await page.keyboard.press('ArrowRight');
          await page.keyboard.press('Enter');
          await page.waitForFunction(
            (n) => document.activeElement?.getAttribute('aria-label') === `Pr Code row ${n}`,
            codes.length + 1,
          );
          await page.keyboard.press('Enter');
          assert.equal(await focusedId(page), 'Save');
          const a1 = codes.indexOf('A1') + 1;
          await cell(page, 'MinStk', a1).focus();
          await page.keyboard.type('4');
          await page.keyboard.press('ArrowDown');
          if (codes[a1] === 'A2') {
            await page.keyboard.press('F1');
            assert.equal(await cell(page, 'MinStk', a1 + 1).inputValue(), '4');
          }
          await page.keyboard.press('Escape');
          assert.equal(await focusedId(page), 'Save');
          const done = await save(page, () => page.keyboard.press('Alt+s'));
          assert.equal(done.status(), 200, await done.text());
          await saved(page);
          await page.keyboard.press('Escape');
          await page.waitForURL((url) => !url.pathname.startsWith('/masters/auto-item'));
          const rows = await madeItems(ctx);
          assert.deepEqual(
            rows.map((r) => r.code),
            ['A1AIS', 'A2AIS'],
          );
          assert.equal(rows[0].minstk, 4);
          return {
            observation: `walked ${codes.length} rows with Enter; Left/Right/Up/Down, F1 and Esc as the desktop; made ${rows.map((r) => r.code).join(',')}`,
            expected: 'every desktop key as listed in the source',
            database: { rows },
            downstream: { leftTo: new URL(page.url()).pathname },
          };
        }),
    ),
    C(
      'keyboard.esc-with-focus-on-the-page',
      'T17',
      'read-only',
      "MS_AUTO_ITEM sets KeyPreview (:1382) and subscribes MS_AUTO_ITEM_KeyDown (:902), so the form sees Esc wherever the focus is; with no grid cell editor (TEXT_ENTRY) visible, Esc closes the form (:2984-3005). A browser has a state the desktop form never has: focus on no control, after a click on the page background. Esc must close Auto Item there too, and a key aimed at the header Company box stays the header's (GB-02, the G239 pattern)",
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        const left = await escLeavesWithNoFocus(page, {
          heading: 'Auto Item',
          path: '/masters/auto-item',
        });
        return {
          observation: `Esc with the focus on the page body left Auto Item for ${left.leftTo}`,
          expected: { focusOnBody: true, leaves: '/masters/auto-item' },
          downstream: left,
        };
      },
    ),
    C(
      'journey.made-item-in-the-item-lookup',
      'T18',
      'mutation',
      'An item made here is an ordinary ITEM_MAST row: the items lookup the sale and purchase lines use offers it by code and name (lookup.ts entity items)',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await chooseGroup(page, 'AIG');
          await mark(page, 'A3', 'Y', 2);
          assert.equal((await save(page)).status(), 200);
          await saved(page);
          const lookup = await (
            await page.request.get('/api/lookup/items?q=A3AIG&limit=20')
          ).json();
          assert.ok(
            lookup.some((r) => r.code === 'A3AIG' && r.name === 'E2E AUTO BANGLE AIG'),
            JSON.stringify(lookup),
          );
          return {
            observation: 'the items lookup offers A3AIG E2E AUTO BANGLE AIG',
            expected: 'found',
            database: { rows: await madeItems(ctx) },
            downstream: { lookup },
          };
        }),
    ),
  ],
};
