import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Other → Tag Print (desktop UT_TAG_PRINT, web /txn/tag-print).
 *
 * Desktop rules used for the expected values (UT_TAG_PRINT.cs unless noted):
 * - The menu button 'Tag Print' opens UT_TAG_PRINT directly (MDI_FORM.cs:8596-8605). Load (:4735-5013) lists the label files
 *   of PRINT_MAST (TAG type) with the one marked PRINT_SET_A 'Y' selected and the item type Gold, or Silver when
 *   CO_MAST.METAL_TYPE is S; CLEAR_DATA (:5014-5043) leaves the boxes and the grid blank.
 * - A voucher fills the grid with its tags by SR_NO, every row Y (tVchNo_KeyDown :5284-5403); the stock fills it with the
 *   in-stock tags by item and tag, filtered by Gr Code, Pr Code and Item Type (MSG_VCH_FILL :5575-5635); a tag typed in
 *   the TagNo column is looked up in the stock, "Duplicate Tag No" when it is already in the grid (:3508, :4102-4420);
 *   Ctrl+D removes a row after "This Row Record will Removed permantley ?" (:3532-3561).
 * - Print (BtnPrint_Click :5122-5226): "You Have No Print Rights.....", Hm Id Update first ("Please First Update Hmid Data
 *   and Then print"), TAG_PRINT_DATA cleared, Lable Skip blank rows (SR_NO 1..n, VCH_NO 00000, IT_CODE '00', Math.Round
 *   of Val), then the BAR_DETL row of every Y row copied. Save (:5073-5096) writes the HM ids, weights, Lbr%, Mrp and LRate
 *   back to BAR_DETL (only with Hm Id Update). Set (:5636-5655) makes the chosen file the default.
 * Web rules that differ on purpose (gap G237): the label sheet is the web's (the Crystal files are not in the repository);
 * a blank Gr Code or Pr Code goes on or loads the stock; Delete does nothing (the desktop's BtnDelete_Click is empty).
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `tag-print.${id}`,
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
const notApplicable = (name, group, source, reason) => ({
  ...C(`${name}.not-applicable`, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});

const API = '/stock/tag-print-screen';
const VCH = '88001';
const BOOK = 'TOP';
/** The cases' tags TP0001-TP0009; the stock lists are compared on these only. */
const TAGS = ['TP0001', 'TP0002', 'TP0003', 'TP0004', 'TP0005'];
const FILES = ['E2E TAG BIG', 'E2E TAG SMALL'];

const path = (r) => new URL(r.url()).pathname;
const isApi = (r, method, p) => r.request().method() === method && path(r) === `/api${p}`;
const label = (page, text) => page.getByLabel(text, { exact: true });
const button = (page, name) => page.getByRole('button', { name, exact: true });
const message = (page, text) => page.getByText(text, { exact: true }).waitFor();
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);
const waitFocus = (page, want) =>
  page.waitForFunction(
    (w) => (document.activeElement?.getAttribute('aria-label') || document.activeElement?.id) === w,
    want,
  );

async function cleanCase(ctx) {
  for (const table of ['TAG_PRINT_DATA'])
    await exec(ctx, `DELETE FROM "${table}" WHERE tenant_id=$1`);
  await exec(
    ctx,
    `DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO" = ANY($2::text[])`,
    TAGS,
  );
  await exec(ctx, `DELETE FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO" = ANY($2::text[])`, TAGS);
  await exec(ctx, `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE" IN ('TPG1','TPS1')`);
  await exec(ctx, `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "PR_CODE"='TP'`);
  await exec(ctx, `DELETE FROM "PRINT_MAST" WHERE tenant_id=$1 AND "PRINT_TYPE"='TAG'`);
  await exec(ctx, `UPDATE "CO_MAST" SET "METAL_TYPE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`);
}
async function tag(ctx, tagNo, srno, over = {}, stock = true) {
  const row = {
    book: BOOK,
    vch: VCH,
    it: 'TPG1',
    design: `DSG-${tagNo}`,
    counter: 'T1',
    gwt: 10.5,
    nwt: 10,
    mrp: 55000,
    stk: '2026-04-02',
    year: null,
    ...over,
  };
  const year = row.year ?? (await ctx.year());
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","TAG_NO","VCH_SRNO","DESIGN_NO",
       "TBL_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_MRP","LBR_PRC","STK_DATE","VCH_TIME","HM_ID")
     VALUES ($1,'01','01',$2,$3,$4,$5,$6,$7,$5,$8,$9,1,$10,$11,91.6,$12,8,$13,now(),'')`,
    ctx.tenantId,
    year,
    row.book,
    row.vch,
    srno,
    row.it,
    tagNo,
    row.design,
    row.counter,
    row.gwt,
    row.nwt,
    row.mrp,
    row.stk,
  );
  if (stock)
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN","ITM_GWT","ITM_NWT")
       VALUES ($1,'01','01',$2,$3,$4,$5,$6,$7,'+',$8,$9)`,
      ctx.tenantId,
      year,
      row.book,
      row.vch,
      row.it,
      tagNo,
      srno,
      row.gwt,
      row.nwt,
    );
}
async function withCase(ctx, run, seed = true) {
  ctx.year ??= async () =>
    (
      await ctx.rows(
        `SELECT "CO_YEAR" y FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "CO_YEAR" DESC LIMIT 1`,
      )
    )[0].y;
  await cleanCase(ctx);
  await exec(
    ctx,
    `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES ($1,'01','TP','E2E TAGP')`,
  );
  await exec(
    ctx,
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","PR_CODE") VALUES
       ($1,'01','TPG1','E2E TAG GOLD RING','G','E1','TP'),($1,'01','TPS1','E2E TAG SILVER RING','S','E2','TP')`,
  );
  await exec(
    ctx,
    `INSERT INTO "PRINT_MAST"(tenant_id,"CO_CODE","PRINT_TYPE","PRINT_FILE","PRINT_SET_A") VALUES ($1,'01','TAG',$2,'N'),($1,'01','TAG',$3,'Y')`,
    FILES[1],
    FILES[0],
  );
  if (seed) {
    await tag(ctx, 'TP0001', 1);
    await tag(ctx, 'TP0002', 2, { design: 'DSG-NEWER' });
    await tag(ctx, 'TP0003', 3, { it: 'TPS1', counter: 'T2' });
  }
  try {
    return await run();
  } finally {
    await cleanCase(ctx);
  }
}

async function openScreen(page) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', API)),
    page.goto('/txn/tag-print'),
  ]);
  await page.getByRole('heading', { name: 'Tag Print', exact: true }).waitFor();
  await page.waitForFunction(
    () => document.querySelector('[aria-label="Print file Name"]')?.options?.length >= 0,
  );
  await waitFocus(page, 'Book');
  return response;
}
const gridTags = (page) =>
  page
    .getByTestId('tag-print-grid')
    .locator('tbody tr')
    .evaluateAll((rows) => rows.map((tr) => tr.dataset.tag).filter(Boolean));
const gridRows = (page) =>
  page
    .getByTestId('tag-print-grid')
    .locator('tbody tr')
    .evaluateAll((rows) =>
      rows
        .filter((tr) => tr.dataset.tag)
        .map((tr) =>
          [...tr.querySelectorAll('td')].map((td) => {
            const box = td.querySelector('input');
            return box ? box.value : td.textContent.trim();
          }),
        ),
    );
async function loadVoucher(page, vch = VCH) {
  await label(page, 'Book').fill(BOOK);
  await label(page, 'Book').press('Enter');
  await waitFocus(page, 'Vch No');
  await label(page, 'Vch No').fill(vch);
  const [response] = await Promise.all([
    page.waitForResponse((r) => path(r) === `/api${API}/voucher`),
    label(page, 'Vch No').press('Enter'),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.waitForFunction(
    () =>
      document.querySelectorAll(
        '[data-testid="tag-print-grid"] tbody tr[data-tag]:not([data-tag=""])',
      ).length > 0,
  );
  return response.json();
}
const staged = (ctx) =>
  ctx.rows(
    `SELECT "SR_NO","IT_CODE","TAG_NO","VCH_NO","CO_BOOK","VCH_SRNO","HM_ID","DESIGN_NO","ITM_MRP"::float mrp FROM "TAG_PRINT_DATA" WHERE tenant_id=$1 ORDER BY row_id`,
  );
async function labelsHtml(page) {
  const response = await page.request.get(`/api${API}/labels`);
  assert.equal(response.status(), 200);
  return response.text();
}
async function printNow(page) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'POST', `${API}/print`)),
    page
      .context()
      .waitForEvent('page', { timeout: 8000 })
      .then((p) => p.close())
      .catch(() => {}),
    button(page, 'Print').click(),
  ]);
  return response;
}

export const tagPrint = {
  feature: 'tag-print',
  title: 'Other → Tag Print (UT_TAG_PRINT)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/tag-print/page.tsx',
    'web/apps/api/src/modules/stock/tagPrintScreen.ts',
    'web/apps/api/src/routes/tagPrintScreen.ts',
    'web/apps/web/test/features/modules/tagPrint.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    companySettings: 'catalogue defaults; T01 sets CO_MAST.METAL_TYPE to S and restores it',
  },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      "MDI_FORM.cs:8596-8605 opens UT_TAG_PRINT; Load (:4735-5013): the TAG label files with the PRINT_SET_A 'Y' one selected, the item type Gold (Silver for METAL_TYPE S); CLEAR_DATA a blank grid; the boxes in the form spec's order; Print, Save, Cancel, Delete and Exit",
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          assert.equal(await label(page, 'Print file Name').inputValue(), FILES[0]);
          const options = await label(page, 'Print file Name').locator('option').allInnerTexts();
          assert.deepEqual(options, [...FILES].sort());
          assert.equal(await label(page, 'Item Type').inputValue(), 'Gold');
          assert.deepEqual(await label(page, 'Item Type').locator('option').allInnerTexts(), [
            'Gold',
            'Silver',
            'Diamond',
            'Real Stone',
            'Emitation',
            'Other',
            'Platinum',
          ]);
          assert.deepEqual(await gridTags(page), []);
          const headers = (
            await page.getByTestId('tag-print-grid').locator('th').allInnerTexts()
          ).map((t) => t.trim());
          assert.deepEqual(headers.slice(0, 9), [
            'Sr',
            'Y/N',
            'TagNo',
            'ItCode',
            'Counter',
            'Design',
            'Size',
            'Pcs',
            'GrWt',
          ]);
          assert.ok(
            headers.includes('NetWt') && headers.includes('Mrp') && headers.includes('KrCode'),
          );
          assert.ok(!headers.includes('HmId'), 'HM columns only with Hm Id Update');
          const primaries = (await page.locator('main button.primary').allInnerTexts()).map((t) =>
            t.trim(),
          );
          assert.deepEqual(primaries, ['Save']);
          for (const name of ['Print', 'Save', 'Cancel', 'Delete', 'Exit', 'Set'])
            assert.ok(await button(page, name).isVisible(), name);
          await exec(
            ctx,
            `UPDATE "CO_MAST" SET "METAL_TYPE"='S' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          );
          await openScreen(page);
          assert.equal(await label(page, 'Item Type').inputValue(), 'Silver');
          return {
            observation: `files ${options.join('/')}, default ${FILES[0]}, item type Gold then Silver`,
            expected: { files: options, itemType: 'Gold' },
          };
        }),
    ),
    C(
      'field.every-field',
      'T02',
      'mutation',
      'BtnPrint_Click (:5131-5175) copies the BAR_DETL row of every Y row into TAG_PRINT_DATA, every column; MSG_VCH_FILL and tVchNo_KeyDown show them in the grid formatted 0.000 / 0.00',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          const rows = await gridRows(page);
          assert.equal(rows.length, 3);
          assert.deepEqual(rows[0].slice(0, 9), [
            '1',
            'Y',
            'TP0001',
            'TPG1',
            'T1',
            'DSG-TP0001',
            '',
            '1',
            '10.500',
          ]);
          const response = await printNow(page);
          assert.equal(response.status(), 200, await response.text());
          const copied = await ctx.rows(
            `SELECT t."TAG_NO",t."IT_CODE",t."DESIGN_NO",t."TBL_CODE",t."ITM_PCS",t."ITM_GWT"::float g,t."ITM_NWT"::float n,t."ITM_TOUCH"::float tc,
                    t."ITM_MRP"::float mrp,t."LBR_PRC"::float l,t."STK_DATE",t."VCH_NO",t."CO_BOOK",t."VCH_SRNO",
                    (to_jsonb(t) - 'row_id' - 'tenant_id') = (to_jsonb(b) - 'row_id' - 'tenant_id' - 'MAIN_USER' - 'ADD_USER' - 'DATA_TRFR'
                       - 'HD_VCH_NO' - 'OLD_VCH_NO' - 'NEW_VCH_NO' - 'DATA_TYPE' - 'APP_TRFR') same
               FROM "TAG_PRINT_DATA" t JOIN "BAR_DETL" b ON b.tenant_id=t.tenant_id AND b."TAG_NO"=t."TAG_NO" AND b."VCH_SRNO"=t."VCH_SRNO"
              WHERE t.tenant_id=$1 ORDER BY t.row_id`,
          );
          assert.deepEqual(
            copied.map((r) => r.TAG_NO),
            ['TP0001', 'TP0002', 'TP0003'],
          );
          assert.deepEqual(
            [
              copied[1].IT_CODE,
              copied[1].DESIGN_NO,
              copied[1].TBL_CODE,
              copied[1].g,
              copied[1].n,
              copied[1].tc,
              copied[1].mrp,
              copied[1].l,
              copied[1].VCH_NO,
              copied[1].CO_BOOK,
            ],
            ['TPG1', 'DSG-NEWER', 'T1', 10.5, 10, 91.6, 55000, 8, VCH, BOOK],
          );
          return {
            observation: 'the three tags copied with every BAR_DETL column',
            expected: { tags: ['TP0001', 'TP0002', 'TP0003'] },
            database: { copied },
            downstream: { grid: rows },
          };
        }),
    ),
    C(
      'field.typing-and-formats',
      'T03',
      'mutation',
      'A tag typed lower case is looked up upper case (the form upper-cases every key); the grid shows weights as 0.000 and money as 0.00 (:5610-5623); an HM id typed in the Hm Id Update grid is upper-cased and saved with its weight (:5087)',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Vch No').focus();
          await page.keyboard.press('Enter');
          await waitFocus(page, 'TagNo row 1');
          await page.keyboard.type('tp0002');
          assert.equal(await label(page, 'TagNo row 1').inputValue(), 'TP0002');
          await Promise.all([
            page.waitForResponse((r) => path(r) === `/api${API}/tag`),
            page.keyboard.press('Enter'),
          ]);
          await page.waitForFunction(() => document.querySelector('[aria-label="Print row 1"]'));
          const [row] = await gridRows(page);
          assert.deepEqual(
            [row[2], row[8], row[9], row[18]],
            ['TP0002', '10.500', '10.000', '55000.00'],
          );
          await label(page, 'Hm Id Update').check();
          await label(page, 'TagNo row 1').fill('tp0002');
          await Promise.all([
            page.waitForResponse((r) => path(r) === `/api${API}/tag`),
            label(page, 'TagNo row 1').press('Enter'),
          ]);
          await label(page, 'HmId row 1').fill('ab12cd');
          await label(page, 'HmWt row 1').fill('0.55');
          assert.equal(await label(page, 'HmId row 1').inputValue(), 'AB12CD');
          const [saved] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'POST', `${API}/hm-update`)),
            page
              .context()
              .waitForEvent('page', { timeout: 8000 })
              .then((p) => p.close())
              .catch(() => {}),
            button(page, 'Save').click(),
          ]);
          assert.equal(saved.status(), 200, await saved.text());
          const [stored] = await ctx.rows(
            `SELECT "HM_ID","HM_ID_WT"::float w FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO"='TP0002'`,
          );
          assert.deepEqual(stored, { HM_ID: 'AB12CD', w: 0.55 });
          return {
            observation: 'tp0002 found as TP0002; the HM id AB12CD with 0.55 saved',
            expected: { hm: 'AB12CD' },
            database: { stored },
            downstream: { grid: row },
          };
        }),
    ),
    C(
      'lookup.helps',
      'T04',
      'read-only',
      "F1 on Vch No lists the book's vouchers (:5318-5326); an unknown Gr Code or Pr Code opens its help (:5499-5574) whose pick fills the code and name; the MS_HELP search box filters the first column; Book's help lists the books with tags (:5439-5482); an unknown tag opens the tag help (:4132)",
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Book').fill(BOOK);
          await label(page, 'Book').press('Enter');
          await waitFocus(page, 'Vch No');
          await page.keyboard.press('F1');
          const help = page.getByTestId('tag-print-help');
          await help.waitFor();
          const vouchers = await help
            .locator('tr')
            .evaluateAll((rows) => rows.map((tr) => tr.dataset.code));
          assert.ok(vouchers.includes(VCH), vouchers.join());
          await page.keyboard.press('Escape');
          await label(page, 'Gr Code').fill('zz');
          await label(page, 'Gr Code').press('Enter');
          await help.waitFor();
          await waitFocus(page, 'Help search');
          await page.keyboard.type('E2E GOLD');
          await page.waitForFunction(
            () => document.querySelectorAll('[data-testid="tag-print-help"] tr').length === 1,
          );
          await page.keyboard.press('Enter');
          await waitFocus(page, 'Pr Code');
          assert.equal(await label(page, 'Gr Code').inputValue(), 'E1');
          assert.equal(await label(page, 'Gr Name').inputValue(), 'E2E GOLD');
          await label(page, 'Pr Code').fill('zz');
          await label(page, 'Pr Code').press('Enter');
          await help.waitFor();
          await waitFocus(page, 'Help search');
          await page.keyboard.type('E2E TAGP');
          await page.keyboard.press('Enter');
          assert.equal(await label(page, 'Pr Code').inputValue(), 'TP');
          assert.equal(await label(page, 'Pr Name').inputValue(), 'E2E TAGP');
          await label(page, 'Vch No').focus();
          await page.keyboard.press('Enter');
          await waitFocus(page, 'TagNo row 1');
          await page.keyboard.type('NOSUCH');
          await page.keyboard.press('Enter');
          await help.waitFor();
          const tags = await help
            .locator('tr')
            .evaluateAll((rows) => rows.map((tr) => tr.dataset.code));
          for (const t of ['TP0001', 'TP0002', 'TP0003']) assert.ok(tags.includes(t), t);
          return {
            observation: `vouchers ${vouchers.length}, group E1 and product TP picked, tag help ${tags.length}`,
            expected: { vouchers: [VCH] },
          };
        }),
    ),
    C(
      'children.grid-rows',
      'T05',
      'mutation',
      'A voucher fills the grid with its tags by SR_NO; the stock fills it with the in-stock tags by item and tag, by Gr Code, Pr Code and Item Type; N leaves a row out of the print; Ctrl+D removes a row after the question; the Item Name line shows the current row',
      async (ctx) =>
        withCase(ctx, async () => {
          await tag(ctx, 'TP0004', 4, { vch: '88002', stk: '2999-01-01' });
          await tag(ctx, 'TP0005', 5, { vch: '88002' }, false);
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          assert.deepEqual(await gridTags(page), ['TP0001', 'TP0002', 'TP0003']);
          assert.equal(await page.getByTestId('tag-print-item').innerText(), 'E2E TAG GOLD RING');
          await openScreen(page);
          await label(page, 'Pr Code').fill('TP');
          await label(page, 'Item Type').selectOption('Silver');
          await Promise.all([
            page.waitForResponse((r) => path(r) === `/api${API}/stock`),
            label(page, 'Pr Code').press('Enter'),
          ]);
          await page.waitForFunction(() => document.querySelector('[aria-label="Print row 1"]'));
          assert.deepEqual(
            (await gridTags(page)).filter((t) => t.startsWith('TP')),
            ['TP0003'],
          );
          await label(page, 'Item Type').selectOption('Gold');
          await Promise.all([
            page.waitForResponse((r) => path(r) === `/api${API}/stock`),
            label(page, 'Pr Code').press('Enter'),
          ]);
          await page.waitForFunction(() => document.querySelector('[aria-label="Print row 2"]'));
          assert.deepEqual(
            (await gridTags(page)).filter((t) => t.startsWith('TP')),
            ['TP0001', 'TP0002'],
          );
          // N on the first row leaves it out.
          await label(page, 'Print row 1').focus();
          await page.keyboard.press('n');
          assert.equal(await label(page, 'Print row 1').innerText(), 'N');
          page.removeAllListeners('dialog');
          const asked = [];
          page.on('dialog', (d) => {
            asked.push(d.message());
            void d.accept();
          });
          await label(page, 'Print row 2').focus();
          await page.keyboard.press('Control+d');
          await page.waitForFunction(
            () =>
              document.querySelectorAll(
                '[data-testid="tag-print-grid"] tbody tr[data-tag]:not([data-tag=""])',
              ).length === 1,
          );
          assert.deepEqual(asked, ['This Row Record will Removed permantley ?']);
          // The one row left is N: there is nothing to print.
          await button(page, 'Print').click();
          await message(page, 'Please select the tags to print (Y) and try.');
          assert.deepEqual((await staged(ctx)).map((r) => r.TAG_NO).filter(Boolean), []);
          return {
            observation: 'voucher and stock fills, N and Ctrl+D leave only the rows to print',
            expected: { silver: ['TP0003'], gold: ['TP0001', 'TP0002'] },
            database: { staged: await staged(ctx) },
            downstream: { asked },
          };
        }),
    ),
    C(
      'required.refusals',
      'T06',
      'refusal',
      'Print with nothing marked Y; a tag typed twice says "Duplicate Tag No" (:3508); Hm Id Update ticked and Print before Save says "Please First Update Hmid Data and Then print" (:5130); Lable Skip is at most 500; nothing is staged',
      async (ctx) =>
        withCase(ctx, async () => {
          const before = await staged(ctx);
          const { page, requests } = await ctx.session();
          await openScreen(page);
          await button(page, 'Print').click();
          await message(page, 'Please select the tags to print (Y) and try.');
          await loadVoucher(page);
          await label(page, 'TagNo row 4').fill('tp0001');
          await label(page, 'TagNo row 4').press('Enter');
          await message(page, 'Duplicate Tag No');
          await label(page, 'Hm Id Update').check();
          await label(page, 'TagNo row 1').fill('tp0001');
          await Promise.all([
            page.waitForResponse((r) => path(r) === `/api${API}/tag`),
            label(page, 'TagNo row 1').press('Enter'),
          ]);
          await button(page, 'Print').click();
          await message(page, 'Please First Update Hmid Data and Then print');
          await label(page, 'Hm Id Update').uncheck();
          await loadVoucher(page);
          await label(page, 'Lable Skip').fill('501');
          const refused = await printNow(page);
          assert.equal(refused.status(), 400);
          assert.deepEqual(await staged(ctx), before);
          assert.equal(
            requests.filter((r) => ['POST', 'PUT', 'DELETE'].includes(r.method) && r.status === 200)
              .length,
            0,
          );
          return {
            observation: 'every refusal shown with the desktop text; nothing staged',
            expected: 'TAG_PRINT_DATA unchanged',
            database: { before },
          };
        }),
    ),
    C(
      'create.footprint',
      'T07',
      'mutation',
      'Print writes TAG_PRINT_DATA only: no BAR_DETL, MAIN_STOCK, ledger or number-series row changes (BtnPrint_Click :5122-5226)',
      async (ctx) =>
        withCase(ctx, async () => {
          const counts = async () =>
            (
              await ctx.rows(
                `SELECT (SELECT count(*)::int FROM "BAR_DETL" WHERE tenant_id=$1) b,(SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1) s,
                        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1) a,(SELECT count(*)::int FROM "BAR_DATA" WHERE tenant_id=$1) d,
                        (SELECT md5(string_agg(to_jsonb(x)::text, '|' ORDER BY x.row_id)) FROM "BAR_DETL" x WHERE x.tenant_id=$1) h`,
              )
            )[0];
          const before = await counts();
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          await label(page, 'Lable Skip').fill('1');
          assert.equal((await printNow(page)).status(), 200);
          assert.deepEqual(await counts(), before);
          const rows = await staged(ctx);
          assert.deepEqual(
            rows.map((r) => r.TAG_NO),
            ['', 'TP0001', 'TP0002', 'TP0003'],
          );
          return {
            observation:
              'one blank row and three tags staged; BAR_DETL (hash), MAIN_STOCK, AC_DATA and BAR_DATA unchanged',
            expected: 'TAG_PRINT_DATA only',
            database: { before, rows },
            downstream: { staged: rows.length },
          };
        }),
    ),
    C(
      'reprint.replaces-staging',
      'T08',
      'mutation',
      'Print clears TAG_PRINT_DATA first (:5131), so printing the same voucher twice leaves one copy of each label, and a second print of fewer tags leaves only those',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          assert.equal((await printNow(page)).status(), 200);
          assert.equal((await printNow(page)).status(), 200);
          assert.deepEqual(
            (await staged(ctx)).map((r) => r.TAG_NO),
            ['TP0001', 'TP0002', 'TP0003'],
          );
          await label(page, 'Print row 1').focus();
          await page.keyboard.press('n');
          await label(page, 'Print row 3').focus();
          await page.keyboard.press('n');
          assert.equal((await printNow(page)).status(), 200);
          const rows = await staged(ctx);
          assert.deepEqual(
            rows.map((r) => r.TAG_NO),
            ['TP0002'],
          );
          return {
            observation: 'two identical prints left three rows; N on two rows left one',
            expected: { tags: ['TP0002'] },
            database: { rows },
            downstream: { again: true },
          };
        }),
    ),
    C(
      'hm.update-boxes',
      'T09',
      'mutation',
      'Hm Id Update (:5656-5666) shows the four HM ids and weights, LRate, Mrp and Lbr%; Save (:5073-5096) writes HM_ID..HM_ID4 with their weights, LBR_PRC, ITM_MRP and LBR_RATE to BAR_DETL for rows with an HM id or a Lbr% / Mrp, then prints',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Hm Id Update').check();
          const headers = (
            await page.getByTestId('tag-print-grid').locator('th').allInnerTexts()
          ).map((t) => t.trim());
          assert.deepEqual(headers.slice(9, 17), [
            'HmId',
            'HmWt',
            'HmId2',
            'HmWt2',
            'HmId3',
            'HmWt3',
            'HmId4',
            'HmWt4',
          ]);
          assert.ok(['LRate', 'Mrp', 'KrCode', 'Lbr%'].every((h) => headers.includes(h)));
          await label(page, 'Book').fill(BOOK);
          await label(page, 'Book').press('Enter');
          await label(page, 'Vch No').fill(VCH);
          await Promise.all([
            page.waitForResponse((r) => path(r) === `/api${API}/voucher`),
            label(page, 'Vch No').press('Enter'),
          ]);
          await page.waitForFunction(() => document.querySelector('[aria-label="HmId row 1"]'));
          await label(page, 'HmId row 1').fill('hu0001');
          await label(page, 'HmWt row 1').fill('0.5');
          await label(page, 'HmId2 row 1').fill('hu0002');
          await label(page, 'LRate row 1').fill('120');
          await label(page, 'Mrp row 1').fill('56000');
          await label(page, 'Lbr% row 1').fill('9');
          // Row 2: no HM id and a zero Lbr% and Mrp: not written.
          await label(page, 'Mrp row 2').fill('0');
          await label(page, 'Lbr% row 2').fill('0');
          const [saved] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'POST', `${API}/hm-update`)),
            page
              .context()
              .waitForEvent('page', { timeout: 8000 })
              .then((p) => p.close())
              .catch(() => {}),
            button(page, 'Save').click(),
          ]);
          assert.equal(saved.status(), 200, await saved.text());
          assert.deepEqual(
            (await saved.json()).updated,
            2,
            'row 2 has a Mrp from BAR_DETL, so it qualifies only with one',
          );
          const rows = await ctx.rows(
            `SELECT "TAG_NO","HM_ID","HM_ID_WT"::float w,"HM_ID2","LBR_PRC"::float lbr,"ITM_MRP"::float mrp,"LBR_RATE"::float rate
               FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO" = ANY($2::text[]) ORDER BY "TAG_NO"`,
            TAGS,
          );
          assert.deepEqual(rows[0], {
            TAG_NO: 'TP0001',
            HM_ID: 'HU0001',
            w: 0.5,
            HM_ID2: 'HU0002',
            lbr: 9,
            mrp: 56000,
            rate: 120,
          });
          const staging = await staged(ctx);
          assert.deepEqual(
            staging.map((r) => r.TAG_NO),
            ['TP0001', 'TP0002', 'TP0003'],
          );
          assert.equal(staging[0].HM_ID, 'HU0001', 'the print follows the save');
          return {
            observation:
              'HU0001 / HU0002, LRate 120, Mrp 56000 and Lbr% 9 saved; the print staged the new HM id',
            expected: { hm: 'HU0001' },
            database: { rows, staging },
            downstream: { printed: staging.length },
          };
        }),
    ),
    notApplicable(
      'delete',
      'T10',
      'BtnDelete_Click (UT_TAG_PRINT.cs:5097-5100) is empty: the screen has no delete',
      'Tag Print deletes nothing; the Delete button of the form does nothing on the desktop as well',
    ),
    C(
      'rights.print-and-edit',
      'T11',
      'refusal',
      'BtnPrint_Click: "You Have No Print Rights....." without the print right (:5124-5128); Hm Id Update and Set need the edit right here (the desktop checks none); reading the stock needs the view right only',
      async (ctx) =>
        withCase(ctx, async () => {
          await exec(
            ctx,
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES ($1,'01','01',$2,'Other','Tag Print','Y','N','N','N')`,
            USERS.clerk.user,
          );
          try {
            const { page, requests } = await ctx.session(as(USERS.clerk.user));
            await openScreen(page);
            await loadVoucher(page);
            await button(page, 'Print').click();
            await message(page, 'You Have No Print Rights.....');
            await button(page, 'Set').click();
            await message(page, 'You Have No Rights.....');
            await label(page, 'Hm Id Update').check();
            await button(page, 'Save').click();
            await message(page, 'You Have No Rights.....');
            assert.equal(requests.filter((r) => r.method === 'POST').length, 0);
            const direct = [
              (
                await page.request.post(`/api${API}/print`, {
                  data: { bookCode: BOOK, tags: [{ tagNo: 'TP0001', vchSrno: 1 }] },
                })
              ).status(),
              (await page.request.get(`/api${API}/labels`)).status(),
              (await page.request.post(`/api${API}/hm-update`, { data: { rows: [] } })).status(),
              (
                await page.request.post(`/api${API}/default-file`, { data: { file: FILES[1] } })
              ).status(),
            ];
            assert.deepEqual(direct, [403, 403, 403, 403]);
            assert.deepEqual(await staged(ctx), []);
            return {
              observation: `refused on screen; direct ${direct.join('/')}`,
              expected: 'the desktop texts and 403s',
              database: { staged: 0 },
            };
          } finally {
            await exec(
              ctx,
              `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Tag Print'`,
              USERS.clerk.user,
            );
          }
        }),
    ),
    C(
      'concurrency.last-print-wins',
      'T12',
      'mutation',
      "TAG_PRINT_DATA is one table per company that BtnPrint_Click clears (:5131): when two operators print, the later print is what the label file reads (the desktop is single-operator here); the earlier operator's sheet request then shows the later labels",
      async (ctx) =>
        withCase(ctx, async () => {
          const a = (await ctx.session()).page;
          const b = (await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#2`))).page;
          await openScreen(a);
          await openScreen(b);
          await loadVoucher(a);
          await loadVoucher(b);
          await label(b, 'Print row 1').focus();
          await b.keyboard.press('n');
          await label(b, 'Print row 2').focus();
          await b.keyboard.press('n');
          assert.equal((await printNow(a)).status(), 200);
          assert.equal((await printNow(b)).status(), 200);
          const rows = await staged(ctx);
          assert.deepEqual(
            rows.map((r) => r.TAG_NO),
            ['TP0003'],
          );
          const html = await labelsHtml(a);
          assert.ok(html.includes('TP0003') && !html.includes('TP0001'));
          return {
            observation: "the second print replaced the first operator's labels",
            expected: { tags: ['TP0003'] },
            database: { rows },
            downstream: { sheetOfFirstOperator: 'TP0003' },
          };
        }),
    ),
    C(
      'retry.replayed-print',
      'T13',
      'mutation',
      'A replayed print request clears and rewrites the same rows (no doubled labels); a replayed Set is the same default',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          const first = await printNow(page);
          assert.equal(first.status(), 200);
          const replay = await page.request.fetch(first.request());
          assert.equal(replay.status(), 200);
          assert.deepEqual(
            (await staged(ctx)).map((r) => r.TAG_NO),
            ['TP0001', 'TP0002', 'TP0003'],
          );
          const [set] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'POST', `${API}/default-file`)),
            (async () => {
              await label(page, 'Print file Name').selectOption(FILES[1]);
              await button(page, 'Set').click();
            })(),
          ]);
          assert.equal(set.status(), 200);
          assert.equal((await page.request.fetch(set.request())).status(), 200);
          const marked = await ctx.rows(
            `SELECT "PRINT_FILE" f FROM "PRINT_MAST" WHERE tenant_id=$1 AND "PRINT_TYPE"='TAG' AND "PRINT_SET_A"='Y'`,
          );
          assert.deepEqual(marked, [{ f: FILES[1] }]);
          return {
            observation: 'replayed print and Set changed nothing more',
            expected: 'one set of labels, one default file',
            database: { marked },
            downstream: { replayed: true },
          };
        }),
    ),
    C(
      'rollback.stage-fault',
      'T14',
      'mutation',
      'BtnPrint_Click clears TAG_PRINT_DATA before it copies (:5131); a fault on a copied row must roll the clear back (the desktop would leave a half-filled table)',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          assert.equal((await printNow(page)).status(), 200);
          const before = await staged(ctx);
          await ctx.owner.$executeRawUnsafe(
            `CREATE OR REPLACE FUNCTION e2e_tagprint_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
             BEGIN IF NEW."TAG_NO" = 'TP0003' THEN RAISE EXCEPTION 'e2e fault on the third label'; END IF; RETURN NEW; END $f$`,
          );
          await ctx.owner.$executeRawUnsafe(
            `CREATE TRIGGER e2e_tagprint_fault BEFORE INSERT ON "TAG_PRINT_DATA" FOR EACH ROW EXECUTE FUNCTION e2e_tagprint_fault()`,
          );
          try {
            await label(page, 'Lable Skip').fill('2');
            const failed = await printNow(page);
            assert.ok(failed.status() >= 400, await failed.text());
            assert.deepEqual(await staged(ctx), before);
            return {
              observation: `the print answered ${failed.status()}; the earlier labels are all still there`,
              expected: 'TAG_PRINT_DATA as before',
              database: { before },
              downstream: { status: failed.status() },
            };
          } finally {
            await ctx.owner.$executeRawUnsafe(
              `DROP TRIGGER IF EXISTS e2e_tagprint_fault ON "TAG_PRINT_DATA"`,
            );
            await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_tagprint_fault()`);
          }
        }),
    ),
    C(
      'history.stock-spans-years',
      'T15',
      'read-only',
      'The stock fill reads MAIN_STOCK by company and location, not by year (MSG_VCH_FILL filters A.CO_YEAR but the web keeps the tag balance over every year): a tag opened in the previous year is listed',
      async (ctx) =>
        withCase(ctx, async () => {
          await tag(ctx, 'TP0004', 4, { year: '2024-2025', vch: '88003' });
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Pr Code').fill('TP');
          await Promise.all([
            page.waitForResponse((r) => path(r) === `/api${API}/stock`),
            label(page, 'Pr Code').press('Enter'),
          ]);
          await page.waitForFunction(() => document.querySelector('[aria-label="Print row 1"]'));
          const tags = (await gridTags(page)).filter((t) => t.startsWith('TP'));
          assert.ok(tags.includes('TP0004'), tags.join());
          assert.ok(tags.includes('TP0001'));
          return {
            observation: `the stock lists ${tags.join(', ')}`,
            expected: "last year's tag included",
          };
        }),
    ),
    C(
      'output.label-sheet',
      'T16',
      'output',
      "The label file reads TAG_PRINT_DATA (:5200-5215); the web's sheet shows one label per staged row, the Lable Skip blanks first (Math.Round banker's: 2.5 skips 2), each with its tag, item, design, weights, touch, MRP and a scannable barcode",
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          await label(page, 'Lable Skip').fill('2.5');
          assert.equal((await printNow(page)).status(), 200);
          const html = await labelsHtml(page);
          assert.equal((html.match(/class="lbl blank"/g) ?? []).length, 2);
          for (const t of ['TP0001', 'TP0002', 'TP0003']) assert.ok(html.includes(t), t);
          assert.ok(html.indexOf('lbl blank') < html.indexOf('TP0001'), 'blanks first');
          assert.ok(html.includes('<svg'), 'a barcode');
          assert.ok(html.includes('55,000'), 'the MRP');
          return {
            observation: `${html.length} bytes, two blanks then three labels`,
            expected: 'blanks, labels, barcodes',
            output: Buffer.from(html),
          };
        }),
    ),
    C(
      'keyboard.desktop-keys',
      'T17',
      'mutation',
      'Enter in Book and Vch No (:5439-5482, :5284-5403) lands on the grid, Y/N and Space on a row, the arrows between rows, Ctrl+D (:3532), Alt+S (the &Save mnemonic, outside Hm Id Update it says so, :5073-5077), Alt+P and Esc',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          // Esc closes the form with router.back(): arrive from another screen so there is an entry to go back to
          // (a goto to the URL the page is already on replaces the entry, and then back stays on Tag Print).
          await page.goto('/utilities');
          await page.waitForLoadState();
          await openScreen(page);
          await label(page, 'Book').fill(BOOK);
          await page.keyboard.press('Enter');
          await waitFocus(page, 'Vch No');
          await page.keyboard.type(VCH);
          await Promise.all([
            page.waitForResponse((r) => path(r) === `/api${API}/voucher`),
            page.keyboard.press('Enter'),
          ]);
          await waitFocus(page, 'Print row 1');
          await page.keyboard.press('n');
          assert.equal(await label(page, 'Print row 1').innerText(), 'N');
          await page.keyboard.press('Space');
          assert.equal(await label(page, 'Print row 1').innerText(), 'Y');
          await page.keyboard.press('ArrowDown');
          await waitFocus(page, 'Print row 2');
          await page.keyboard.press('n');
          await page.keyboard.press('ArrowUp');
          await waitFocus(page, 'Print row 1');
          await page.keyboard.press('Alt+s');
          await message(page, 'Save writes the Hm Id data only; tick Hm Id Update to change it.');
          await button(page, 'Print').focus();
          await Promise.all([
            page.waitForResponse((r) => isApi(r, 'POST', `${API}/print`)),
            page
              .context()
              .waitForEvent('page', { timeout: 8000 })
              .then((p) => p.close())
              .catch(() => {}),
            page.keyboard.press('Enter'),
          ]);
          assert.deepEqual(
            (await staged(ctx)).map((r) => r.TAG_NO),
            ['TP0001', 'TP0003'],
          );
          await Promise.all([
            page.waitForURL((url) => url.pathname === '/dashboard'),
            page.keyboard.press('Escape'),
          ]);
          return {
            observation:
              'Enter through Book and Vch No, Y/N, Space, the arrows, Alt+S, Print with Enter and Esc',
            expected: 'the desktop keys',
            database: { staged: await staged(ctx) },
            downstream: { leftTo: new URL(page.url()).pathname },
          };
        }),
    ),
    C(
      'journey.hm-id-reaches-the-label',
      'T18',
      'mutation',
      'An HM id keyed in Hm Id Update is written to BAR_DETL (:5087) and copied to TAG_PRINT_DATA by the print that follows (:5161), so the next plain print of that voucher carries it too',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Hm Id Update').check();
          await label(page, 'Book').fill(BOOK);
          await label(page, 'Book').press('Enter');
          await label(page, 'Vch No').fill(VCH);
          await Promise.all([
            page.waitForResponse((r) => path(r) === `/api${API}/voucher`),
            label(page, 'Vch No').press('Enter'),
          ]);
          await page.waitForFunction(() => document.querySelector('[aria-label="HmId row 1"]'));
          await label(page, 'HmId row 1').fill('hjourney');
          await Promise.all([
            page.waitForResponse((r) => isApi(r, 'POST', `${API}/print`)),
            page
              .context()
              .waitForEvent('page', { timeout: 8000 })
              .then((p) => p.close())
              .catch(() => {}),
            button(page, 'Save').click(),
          ]);
          assert.equal((await staged(ctx))[0].HM_ID, 'HJOURNEY');
          await page.goto('/txn/tag-print');
          await waitFocus(page, 'Book');
          await loadVoucher(page);
          assert.equal((await gridRows(page))[0][0], '1');
          assert.equal((await printNow(page)).status(), 200);
          const html = await labelsHtml(page);
          assert.ok(html.includes('HJOURNEY'), 'the label shows the HM id');
          return {
            observation:
              "HJOURNEY saved, staged by the save's print and on the next plain print's label",
            expected: { hm: 'HJOURNEY' },
            database: { staged: await staged(ctx) },
            downstream: { label: 'HJOURNEY' },
          };
        }),
    ),
  ],
};
