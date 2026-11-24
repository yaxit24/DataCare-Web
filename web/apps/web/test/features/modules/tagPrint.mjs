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
 * Web rules that differ on purpose (gap G237): the label sheet is the web's HTML sheet, one layout per Crystal label file
 * (N249/G261); a blank Gr Code or Pr Code goes on or loads the stock; Delete does nothing (the desktop's BtnDelete_Click
 * is empty).
 *
 * N249 / G261 (orchestration/work/WP-34/cases.md): the PRINT_MAST label-file choice (cboPrintfile :4936-4954, :5200-5209,
 * Set :5636-5655) and the SubTagPrint sub-report (BarPrint10.xml:72, :100-101; QrPrint10.xml:119; GhatTagPrnt.xml:102;
 * BarPrint13.xml:10). The browser cases are the `tag-print.*` ids of cases.md at layer browser. Its unit and database
 * layer ids are vitest cases (apps/api/test/tagLabelText.test.ts, tagPrintFiles.db.test.ts, tagPrintScreen.db.test.ts):
 * calc.*, required.set-empty-or-unknown, set.default-switches-only-one-file, create.print-does-not-write-master,
 * edit.set-leaves-staging, rights.cross-tenant-file, concurrency.two-sets-one-default, rollback.set-second-statement-fails.
 * Deliberate difference: KR_NAME is VARCHAR(5) (a karigar code), so the fixture karigar is `KARI1`, not cases.md's `KARI-1`.
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
    `DELETE FROM "BAR_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"='TOP' AND "VCH_NO"='88001'`,
  );
  await exec(
    ctx,
    `DELETE FROM "PRINT_MAST" WHERE tenant_id=$1 AND "PRINT_TYPE"='QR' AND "PRINT_FILE" LIKE 'QrPrint10%'`,
  );
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
       "TBL_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_MRP","LBR_PRC","STK_DATE","VCH_TIME","HM_ID","KR_NAME")
     VALUES ($1,'01','01',$2,$3,$4,$5,$6,$7,$5,$8,$9,1,$10,$11,91.6,$12,8,$13,now(),'','KARI1')`,
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
  const [shop] = await ctx.rows(
    `SELECT "CO_NAME" n FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' LIMIT 1`,
  );
  await exec(
    ctx,
    `UPDATE "CO_MAST" SET "CO_NAME"='E2E SHOP' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
  );
  try {
    return await run();
  } finally {
    await cleanCase(ctx);
    await exec(
      ctx,
      `UPDATE "CO_MAST" SET "CO_NAME"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      shop?.n ?? null,
    );
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

// ---- N249 / G261 helpers: the PRINT_MAST label files and the SubTagPrint sub-report ----
const LABEL_FILES = ['QrPrint10', 'BarPrint10', 'BarPrint13', 'GhatTagPrnt'];
const fourFiles = (def = 'BarPrint10') => LABEL_FILES.map((f) => ['TAG', f, f === def ? 'Y' : 'N']);
async function putFiles(ctx, rows) {
  await exec(ctx, `DELETE FROM "PRINT_MAST" WHERE tenant_id=$1 AND "PRINT_TYPE"='TAG'`);
  await exec(
    ctx,
    `DELETE FROM "PRINT_MAST" WHERE tenant_id=$1 AND "PRINT_TYPE"='QR' AND "PRINT_FILE" LIKE 'QrPrint10%'`,
  );
  for (const [type, file, flag] of rows)
    await exec(
      ctx,
      `INSERT INTO "PRINT_MAST"(tenant_id,"CO_CODE","PRINT_TYPE","PRINT_FILE","PRINT_SET_A") VALUES ($1,'01',$2,$3,$4)`,
      type,
      file,
      flag,
    );
}
const marks = async (ctx) =>
  (
    await ctx.rows(
      `SELECT "PRINT_TYPE" t,"PRINT_FILE" f,"PRINT_SET_A" a FROM "PRINT_MAST" WHERE tenant_id=$1 AND ("PRINT_TYPE"='TAG' OR "PRINT_FILE" LIKE 'QrPrint10%')`,
    )
  )
    .map((r) => `${r.t}/${r.f}/${r.a}`)
    .sort();
const options = (page) => label(page, 'Print file Name').locator('option').allInnerTexts();
/** The sub-report rows of voucher 88001: GLD1 / IT_AMT 1234.50 / IT_NET_AMT 1000.40 on TP0001 and GLD2 / 99.40 / 55.60 on TP0002 (IT_NET_AMT differs so QrPrint10 (net) and the other files (IT_AMT) are told apart). */
async function seedIdtl(ctx) {
  const year = await ctx.year();
  for (const [srno, tagNo, code, amt, net] of [
    [1, 'TP0001', 'GLD1', 1234.5, 1000.4],
    [2, 'TP0002', 'GLD2', 99.4, 55.6],
  ])
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","TAG_NO","VCH_SRNO","IT_CODE","IT_AMT","IT_NET_AMT")
       VALUES ($1,'01','01',$2,'TOP','88001',$3,$4,$3,$5,$6,$7)`,
      ctx.tenantId,
      year,
      srno,
      tagNo,
      code,
      amt,
      net,
    );
}
/** QR_CODE_GEN = Y for the run, then the company's previous CO_SET_NEW state back. */
async function withQr(ctx, run) {
  const [before] = await ctx.rows(
    `SELECT count(*)::int n, max("QR_CODE_GEN") v FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
  );
  if (before.n)
    await exec(
      ctx,
      `UPDATE "CO_SET_NEW" SET "QR_CODE_GEN"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
    );
  else
    await exec(
      ctx,
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","QR_CODE_GEN") VALUES ($1,'01','Y')`,
    );
  try {
    return await run();
  } finally {
    if (before.n)
      await exec(
        ctx,
        `UPDATE "CO_SET_NEW" SET "QR_CODE_GEN"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        before.v,
      );
    else await exec(ctx, `DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"='01'`);
  }
}
const TWO_TAGS = [
  { tagNo: 'TP0001', vchSrno: 1 },
  { tagNo: 'TP0002', vchSrno: 2 },
];
/** Print through the API as the screen does (file in the body), then fetch that file's sheet. */
async function sheetFor(page, file, extra = {}) {
  const printed = await page.request.post(`/api${API}/print`, {
    data: { bookCode: BOOK, file, tags: TWO_TAGS, ...extra },
  });
  assert.equal(printed.status(), 200, await printed.text());
  const response = await page.request.get(`/api${API}/labels?file=${encodeURIComponent(file)}`);
  assert.equal(response.status(), 200);
  return response.text();
}
const labelParts = (html) => html.split(/<div class="lbl[ "]/).slice(1);
const labelFor = (parts, tagNo) =>
  parts.find((p) => p.includes(`>*${tagNo}*<`) || p.includes(`>${tagNo}<`)) ?? '';
const subLines = (part) => part.match(/[A-Z0-9]+ \/ \d+/g) ?? [];
const sheetResult = (observation, expected, html, extra = {}) => ({
  observation,
  expected,
  output: Buffer.from(html),
  ...extra,
});
const blockedCase = (name, group, reason) => ({
  ...C(name, group, 'read-only', `cases.md tag-print.${name}`, async () => ({})),
  blocked: reason,
});

export const tagPrint = {
  feature: 'tag-print',
  title: 'Other → Tag Print (UT_TAG_PRINT)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/tag-print/page.tsx',
    'web/apps/web/lib/screenEscape.ts',
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
          assert.deepEqual(options, ['', ...FILES].sort());
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
      "The label file reads TAG_PRINT_DATA (:5200-5215); the web's sheet shows one label per staged row, the Lable Skip blanks first (Math.Round banker's: 2.5 skips 2), each with its tag, item, design, weights, touch, MRP and a scannable barcode. The weight and labour lines are the label files' formulas (QrPrint10, BarPrint10, BarPrint13, GhatTagPrnt): 'G.' + totext(ITM_GWT,3), 'N.' + totext(ITM_NWT,3) and MRP: / LP: / LF: totext(x,'0'), worked by hand for the fixture (gross 10.5, net 10, MRP 55000): G.10.500, N.10.000, MRP: 55000",
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
          // The three labels each carry the desktop's text for gross 10.5, net 10 and MRP 55000.
          const count = (s) => html.split(s).length - 1;
          assert.equal(count('G.10.500'), 3, 'gross: G. and three decimals');
          assert.equal(count('N.10.000'), 3, 'net: N. and three decimals');
          assert.equal(count('MRP: 55000'), 3, "labour line: MRP: totext(55000,'0')");
          assert.ok(!html.includes('55,000') && !html.includes('₹'), 'no web-only wording');
          return {
            observation: `${html.length} bytes, two blanks then three labels`,
            expected: 'blanks, labels, barcodes',
            output: Buffer.from(html),
          };
        }),
    ),
    C(
      'output.label-labour-lines',
      'T16',
      'output',
      "The Labour formula of the label files (QrPrint10, BarPrint10, BarPrint13, GhatTagPrnt): MRP: totext(ITM_MRP,'0') when MRP <> 0, else LP: totext(LBR_RATE,'0') when the rate <> 0, else LF: totext(LBR_AMT,'0') when the amount <> 0, else no line. Staged from BAR_DETL through Print (:5200-5215). Worked by hand: tag 1 MRP 0, rate 600 -> LP: 600; tag 2 MRP 0, rate 0, amount 90 -> LF: 90; tag 3 all zero -> no labour line",
      async (ctx) =>
        withCase(ctx, async () => {
          const set = (tagNo, rate, amt) =>
            exec(
              ctx,
              `UPDATE "BAR_DETL" SET "ITM_MRP"=0,"LBR_RATE"=$2,"LBR_AMT"=$3 WHERE tenant_id=$1 AND "TAG_NO"=$4`,
              rate,
              amt,
              tagNo,
            );
          await set('TP0001', 600, 0);
          await set('TP0002', 0, 90);
          await set('TP0003', 0, 0);
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          assert.equal((await printNow(page)).status(), 200);
          const html = await labelsHtml(page);
          const blocks = html.split(/<div class="lbl[ "]/).slice(1);
          assert.equal(blocks.length, 3, 'one label per staged row');
          const of = (tagNo) => blocks.find((b) => b.includes(`>*${tagNo}*<`)) ?? '';
          const [one, two, three] = [of('TP0001'), of('TP0002'), of('TP0003')];
          assert.ok(one.includes('LP: 600'), 'tag 1: LP:');
          assert.ok(!one.includes('MRP') && !one.includes('LF:'), 'tag 1 has only the LP line');
          assert.ok(two.includes('LF: 90'), 'tag 2: LF:');
          assert.ok(!two.includes('MRP') && !two.includes('LP:'), 'tag 2 has only the LF line');
          assert.ok(
            !three.includes('MRP') && !three.includes('LP:') && !three.includes('LF:'),
            'tag 3: no labour line',
          );
          for (const b of [one, two, three]) {
            assert.ok(b.includes('G.10.500') && b.includes('N.10.000'), 'weights on every label');
          }
          return {
            observation: 'LP: 600, LF: 90 and no labour line on the three labels',
            expected: { one: 'LP: 600', two: 'LF: 90', three: '' },
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
          // The print window can open late on a slow runner and take the keyboard from this page; bring the page back
          // and press Esc again rather than counting on the first key reaching it.
          for (let attempt = 0; attempt < 3; attempt++) {
            await page.bringToFront();
            await page.evaluate(() => window.focus());
            await page.keyboard.press('Escape');
            const left = await page
              .waitForURL((url) => url.pathname === '/dashboard', { timeout: 8000 })
              .then(() => true)
              .catch(() => false);
            if (left) break;
          }
          assert.equal(new URL(page.url()).pathname, '/dashboard', 'Esc closes Tag Print');
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
      'keyboard.esc-with-focus-on-the-page',
      'T17',
      'read-only',
      'The form sets KeyPreview (:1805) and subscribes its own KeyDown (:1154), so Esc reaches TR_TAG_CAN_KeyDown (:5101-5105) wherever the focus is. OldValTot and NewValTot are only ever assigned 0.0 (:5035-5036), so they are equal and the form closes (:5107-5109). A browser has a state the desktop form never has: focus on no control, after a click on the page background or when the focused Print button is disabled while a print runs. Esc must close Tag Print there too',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          // Focus on no control at all: what a click on the page background leaves, and what a disabled focused button leaves.
          await page.getByRole('heading', { name: 'Tag Print', exact: true }).click();
          const focusOnBody = await page.evaluate(() => document.activeElement === document.body);
          assert.equal(focusOnBody, true, 'the click left the focus on the page body');
          assert.equal(new URL(page.url()).pathname, '/txn/tag-print');
          // The boundary: a key aimed at a header control (the MDI parent, not this form) is not the form's, as before.
          await page.getByLabel('Company', { exact: true }).focus();
          await assert.rejects(
            Promise.all([
              page.waitForURL((url) => url.pathname === '/dashboard', { timeout: 1500 }),
              page.keyboard.press('Escape'),
            ]),
            /Timeout/,
            'Esc on the header Company box must leave Tag Print open',
          );
          assert.equal(new URL(page.url()).pathname, '/txn/tag-print');
          await page.getByRole('heading', { name: 'Tag Print', exact: true }).click();
          assert.equal(await page.evaluate(() => document.activeElement === document.body), true);
          await Promise.all([
            page.waitForURL((url) => url.pathname === '/dashboard', { timeout: 10_000 }),
            page.keyboard.press('Escape'),
          ]);
          return {
            observation: 'Esc with the focus on the page body closed Tag Print',
            expected: { focusOnBody: true, leftTo: '/dashboard' },
            downstream: { leftTo: new URL(page.url()).pathname },
          };
        }),
    ),
    C(
      'journey.hm-id-reaches-the-label',
      'T18',
      'mutation',
      'An HM id keyed in Hm Id Update is written to BAR_DETL (:5087) and copied to TAG_PRINT_DATA by the print that follows (:5161), so the next plain print of that voucher carries it too; none of the four label files places HM_ID, so the label prints no HUID line (cases.md OQ1)',
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
          // N249: none of the four label files places the hallmark id, so the label no longer shows it.
          assert.ok(
            !html.includes('HUID') && !html.includes('HJOURNEY'),
            'no HUID line on the label',
          );
          return {
            observation:
              "HJOURNEY saved and staged by the save's print; the label files place no HM id, so no sheet shows it",
            expected: { hm: 'HJOURNEY', label: 'no HUID line' },
            database: { staged: await staged(ctx) },
            downstream: { label: 'no HUID line' },
          };
        }),
    ),
    // ---- N249 / G261: the PRINT_MAST label-file choice and the SubTagPrint sub-report (cases.md) ----
    C(
      'entry.combo-leading-empty',
      'T01',
      'read-only',
      'UT_TAG_PRINT.cs:4936 cboPrintfile.Items.Add(""), :4954 cboPrintfile.Text = text: the list is the empty item then the files, the marked file selected',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, [
            ['TAG', 'BarPrint10', 'N'],
            ['TAG', 'BarPrint13', 'Y'],
          ]);
          const { page } = await ctx.session();
          await openScreen(page);
          assert.deepEqual(await options(page), ['', 'BarPrint10', 'BarPrint13']);
          assert.equal(await label(page, 'Print file Name').inputValue(), 'BarPrint13');
          return {
            observation: 'options "", BarPrint10, BarPrint13; BarPrint13 selected',
            expected: { options: ['', 'BarPrint10', 'BarPrint13'], selected: 'BarPrint13' },
          };
        }),
    ),
    C(
      'entry.no-files-only-empty',
      'T01',
      'read-only',
      'UT_TAG_PRINT.cs:4952 with no PRINT_MAST row the combo holds only the empty item, :4954 its text stays empty',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, []);
          const { page } = await ctx.session();
          await openScreen(page);
          assert.deepEqual(await options(page), ['']);
          assert.equal(await label(page, 'Print file Name').inputValue(), '');
          return {
            observation: 'only the empty item, empty selection',
            expected: { options: [''] },
          };
        }),
    ),
    C(
      'set.no-default-marked',
      'T01',
      'read-only',
      'UT_TAG_PRINT.cs:4942 only a row marked PRINT_SET_A Y assigns the text, :4954 so with files but none marked the combo stays empty (the web used to pick the first file)',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(
            ctx,
            ['BarPrint10', 'BarPrint13', 'GhatTagPrnt'].map((f) => ['TAG', f, 'N']),
          );
          const { page } = await ctx.session();
          await openScreen(page);
          assert.equal(await label(page, 'Print file Name').inputValue(), '');
          assert.deepEqual(await options(page), ['', 'BarPrint10', 'BarPrint13', 'GhatTagPrnt']);
          return { observation: 'selected value is empty', expected: { selected: '' } };
        }),
    ),
    C(
      'entry.two-marked-last-wins',
      'T01',
      'read-only',
      'UT_TAG_PRINT.cs:4942-4954 the Load loop has no break: with two files marked Y the last in PRINT_FILE order is selected',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, [
            ['TAG', 'BarPrint10', 'Y'],
            ['TAG', 'BarPrint13', 'Y'],
            ['TAG', 'GhatTagPrnt', 'N'],
          ]);
          const { page } = await ctx.session();
          await openScreen(page);
          assert.equal(await label(page, 'Print file Name').inputValue(), 'BarPrint13');
          return { observation: 'BarPrint13 selected', expected: { selected: 'BarPrint13' } };
        }),
    ),
    C(
      'entry.tag-vs-qr-type',
      'T01',
      'read-only',
      'UT_TAG_PRINT.cs:4926 PRINT_TYPE = QR (with QR generation on) versus :4930 PRINT_TYPE = TAG, each with its own marked default',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, [
            ['TAG', 'BarPrint10', 'N'],
            ['TAG', 'QrPrint10', 'Y'],
            ['QR', 'QrPrint10', 'N'],
            ['QR', 'QrPrint10-ALT', 'Y'],
          ]);
          const { page } = await ctx.session();
          await openScreen(page);
          assert.deepEqual(await options(page), ['', 'BarPrint10', 'QrPrint10']);
          assert.equal(await label(page, 'Print file Name').inputValue(), 'QrPrint10');
          return withQr(ctx, async () => {
            await openScreen(page);
            assert.deepEqual(await options(page), ['', 'QrPrint10', 'QrPrint10-ALT']);
            assert.equal(await label(page, 'Print file Name').inputValue(), 'QrPrint10-ALT');
            return {
              observation: 'TAG files with QR off, QR files with QR on',
              expected: { off: 'QrPrint10', on: 'QrPrint10-ALT' },
            };
          });
        }),
    ),
    C(
      'field.file-reaches-print',
      'T02',
      'output',
      "UT_TAG_PRINT.cs:5200 string text = cboPrintfile.Text and :5209 Cr.ReportFileName: the combo text selects the template, so the print request carries the chosen file and the sheet is that file's layout",
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles('BarPrint10'));
          await seedIdtl(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          await label(page, 'Print file Name').selectOption('BarPrint13');
          const response = await printNow(page);
          assert.equal(response.status(), 200, await response.text());
          assert.equal(response.request().postDataJSON().file, 'BarPrint13');
          const html = await (await page.request.get(`/api${API}/labels?file=BarPrint13`)).text();
          assert.ok(html.includes('L.0.500') && html.includes('*TP0001*'));
          assert.ok(!html.includes('GLD1 / 1235'), 'BarPrint13 has no sub-report');
          return sheetResult(
            'the print request carried BarPrint13 and the sheet is its layout',
            { file: 'BarPrint13' },
            html,
          );
        }),
    ),
    C(
      'field.set-persists-default',
      'T02',
      'mutation',
      'BtnTagSet_Click :5641 clears PRINT_SET_A, :5643 marks the chosen file, :5653 says "Tag Print Report Default Set"; the reopened combo shows it',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, [
            ['TAG', 'BarPrint10', 'Y'],
            ['TAG', 'BarPrint13', 'N'],
          ]);
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Print file Name').selectOption('BarPrint13');
          const [set] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'POST', `${API}/default-file`)),
            button(page, 'Set').click(),
          ]);
          assert.equal(set.status(), 200);
          await message(page, 'Tag Print Report Default Set');
          assert.deepEqual(await marks(ctx), ['TAG/BarPrint10/N', 'TAG/BarPrint13/Y']);
          await openScreen(page);
          assert.equal(await label(page, 'Print file Name').inputValue(), 'BarPrint13');
          return {
            observation: 'BarPrint13 is Y, BarPrint10 N, message shown, default kept on reopen',
            expected: { default: 'BarPrint13', message: 'Tag Print Report Default Set' },
            database: { marks: await marks(ctx) },
            downstream: { reopened: 'BarPrint13' },
          };
        }),
    ),
    C(
      'field.qr-set-separate',
      'T02',
      'mutation',
      'BtnTagSet_Click :5639-5650 the QR branch updates PRINT_TYPE QR rows, the TAG branch the TAG rows, each separately',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, [
            ['TAG', 'BarPrint10', 'Y'],
            ['QR', 'QrPrint10', 'Y'],
            ['QR', 'QrPrint10-ALT', 'N'],
          ]);
          return withQr(ctx, async () => {
            const { page } = await ctx.session();
            await openScreen(page);
            await label(page, 'Print file Name').selectOption('QrPrint10-ALT');
            await Promise.all([
              page.waitForResponse((r) => isApi(r, 'POST', `${API}/default-file`)),
              button(page, 'Set').click(),
            ]);
            await message(page, 'Tag Print Report Default Set');
            assert.deepEqual(await marks(ctx), [
              'QR/QrPrint10-ALT/Y',
              'QR/QrPrint10/N',
              'TAG/BarPrint10/Y',
            ]);
            return {
              observation: 'only the QR rows changed; the TAG default is still BarPrint10',
              expected: { qr: 'QrPrint10-ALT', tag: 'BarPrint10' },
              database: { marks: await marks(ctx) },
              downstream: { tagDefault: 'BarPrint10' },
            };
          });
        }),
    ),
    C(
      'lookup.files-scoped-ordered',
      'T04',
      'read-only',
      "UT_TAG_PRINT.cs:4930 PRINT_TYPE = TAG ORDER BY PRINT_FILE: the combo lists the company's TAG files in file order after the empty item; QR rows are left out",
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, [
            ['TAG', 'QrPrint10', 'N'],
            ['TAG', 'GhatTagPrnt', 'N'],
            ['TAG', 'BarPrint13', 'N'],
            ['TAG', 'BarPrint10', 'Y'],
            ['QR', 'QrPrint10-QR', 'N'],
          ]);
          const { page } = await ctx.session();
          await openScreen(page);
          assert.deepEqual(await options(page), [
            '',
            'BarPrint10',
            'BarPrint13',
            'GhatTagPrnt',
            'QrPrint10',
          ]);
          return { observation: 'sorted TAG files, no QR row', expected: 'BarPrint10..QrPrint10' };
        }),
    ),
    C(
      'lookup.loaded-once',
      'T04',
      'read-only',
      'UT_TAG_PRINT.cs:4930 the combo is filled once in Load: a file added while the screen is open appears after a reload only',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, [['TAG', 'BarPrint10', 'Y']]);
          const { page } = await ctx.session();
          await openScreen(page);
          await exec(
            ctx,
            `INSERT INTO "PRINT_MAST"(tenant_id,"CO_CODE","PRINT_TYPE","PRINT_FILE","PRINT_SET_A") VALUES ($1,'01','TAG','GhatTagPrnt','N')`,
          );
          assert.deepEqual(await options(page), ['', 'BarPrint10']);
          await openScreen(page);
          assert.deepEqual(await options(page), ['', 'BarPrint10', 'GhatTagPrnt']);
          return { observation: 'added after reload only', expected: 'no live refresh' };
        }),
    ),
    C(
      'children.subtagprint-rows-per-parent',
      'T05',
      'output',
      'BarPrint10.xml:100-101 links the sub-report by TAG_NO and VCH_SRNO, QrPrint10.xml:119 by the voucher row incl. SR_NO: no child line moves to the other tag',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles());
          await seedIdtl(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          const bar = labelParts(await sheetFor(page, 'BarPrint10'));
          assert.deepEqual(subLines(labelFor(bar, 'TP0001')), ['GLD1 / 1235']);
          assert.deepEqual(subLines(labelFor(bar, 'TP0002')), ['GLD2 / 99']);
          const html = await sheetFor(page, 'QrPrint10');
          const qr = labelParts(html);
          assert.deepEqual(subLines(qr[0]), ['GLD1 / 1000']);
          assert.deepEqual(subLines(qr[1]), ['GLD2 / 56']);
          return sheetResult(
            'each tag shows only its own line',
            { TP0001: 'GLD1 / 1235', TP0002: 'GLD2 / 99', QR: 'GLD1 / 1000, GLD2 / 56' },
            html,
          );
        }),
    ),
    C(
      'children.barprint13-no-subreport',
      'T05',
      'output',
      'BarPrint13.xml:10 <SubReports />: BarPrint13 declares no sub-report, so no BAR_IDTL line prints',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles());
          await seedIdtl(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          const html = await sheetFor(page, 'BarPrint13');
          assert.ok(!/GLD\d/.test(html) && !html.includes(' / '));
          return sheetResult('no sub-report line', 'none', html);
        }),
    ),
    blockedCase(
      'print.empty-file',
      'T06',
      "what message should the web show when Print file Name is empty? The desktop passes the empty name to Crystal (UT_TAG_PRINT.cs:5209) and fails with Crystal's own error; no desktop text exists (study Gap 8). Until the owner fixes the text the web prints an empty choice in the BarPrint10 layout. Unblocks when the owner fixes the text.",
    ),
    C(
      'required.unknown-file',
      'T06',
      'refusal',
      'UT_TAG_PRINT.cs:5209 the desktop hands any name to Crystal; the web refuses a name PRINT_MAST lacks (400 "Unknown print file: X") and stages nothing',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, [['TAG', 'BarPrint10', 'Y']]);
          const { page } = await ctx.session();
          await openScreen(page);
          await sheetFor(page, 'BarPrint10');
          await putFiles(ctx, []);
          const before = await staged(ctx);
          const response = await page.request.post(`/api${API}/print`, {
            data: { bookCode: BOOK, file: 'BarPrint10', tags: TWO_TAGS },
          });
          assert.equal(response.status(), 400);
          assert.ok((await response.text()).includes('Unknown print file: BarPrint10'));
          assert.deepEqual(await staged(ctx), before);
          return {
            observation: '400 Unknown print file: BarPrint10; the staging is untouched',
            expected: '400',
            database: { staged: before.length },
          };
        }),
    ),
    C(
      'reopen.default-preserved',
      'T08',
      'read-only',
      'Load :4954 reads the default, Set :5643 writes it: the reopened combo shows the set file and PRINT_MAST has one Y',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles('BarPrint10'));
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Print file Name').selectOption('BarPrint13');
          await Promise.all([
            page.waitForResponse((r) => isApi(r, 'POST', `${API}/default-file`)),
            button(page, 'Set').click(),
          ]);
          await openScreen(page);
          assert.equal(await label(page, 'Print file Name').inputValue(), 'BarPrint13');
          assert.equal((await marks(ctx)).filter((m) => m.endsWith('/Y')).length, 1);
          return { observation: 'BarPrint13, one Y row', expected: { default: 'BarPrint13' } };
        }),
    ),
    C(
      'set.default-message-text',
      'T09',
      'read-only',
      'BtnTagSet_Click :5653 MsgBox "Tag Print Report Default Set": no file name, no period',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, [
            ['TAG', 'BarPrint10', 'Y'],
            ['TAG', 'BarPrint13', 'N'],
          ]);
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Print file Name').selectOption('BarPrint13');
          await button(page, 'Set').click();
          await message(page, 'Tag Print Report Default Set');
          return { observation: 'the desktop text', expected: 'Tag Print Report Default Set' };
        }),
    ),
    C(
      'edit.switch-default-and-reprint',
      'T09',
      'output',
      "The template is the combo text at print time (:5200): printing the same voucher after Set shows the new file's layout and leaves BAR_DETL alone",
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles('BarPrint10'));
          await seedIdtl(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          const barBefore = await ctx.rows(
            `SELECT count(*)::int n, sum("ITM_GWT")::float g FROM "BAR_DETL" WHERE tenant_id=$1 AND "VCH_NO"='88001'`,
          );
          const first = await sheetFor(page, 'BarPrint10');
          assert.ok(first.includes('GLD1 / 1235') && !first.includes('L.0.500'));
          await label(page, 'Print file Name').selectOption('BarPrint13');
          await Promise.all([
            page.waitForResponse((r) => isApi(r, 'POST', `${API}/default-file`)),
            button(page, 'Set').click(),
          ]);
          const second = await sheetFor(page, 'BarPrint13');
          assert.ok(second.includes('L.0.500') && !second.includes('GLD1'));
          assert.deepEqual(
            await ctx.rows(
              `SELECT count(*)::int n, sum("ITM_GWT")::float g FROM "BAR_DETL" WHERE tenant_id=$1 AND "VCH_NO"='88001'`,
            ),
            barBefore,
          );
          return sheetResult(
            'BarPrint10 then BarPrint13 layouts; BAR_DETL unchanged',
            'two layouts',
            second,
          );
        }),
    ),
    C(
      'cancel.print-dialog',
      'T10',
      'output',
      'BtnPrint_Click :5143 clears and :5151 copies before the dialog; :5192 Cancel only returns: the staging and the sheet are still there',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles());
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          assert.equal((await printNow(page)).status(), 200);
          const rows = await staged(ctx);
          assert.equal(rows.length, 3);
          const html = await (await page.request.get(`/api${API}/labels?file=BarPrint10`)).text();
          assert.equal(labelParts(html).length, 3);
          return sheetResult('three rows staged and shown after the sheet was closed', 3, html);
        }),
    ),
    C(
      'rights.set-needs-update',
      'T11',
      'refusal',
      'BtnTagSet_Click :5636 has no right test on the desktop; the web keeps the update right because Set changes a company-wide default (architect decision, owner may override)',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, [
            ['TAG', 'BarPrint10', 'Y'],
            ['TAG', 'BarPrint13', 'N'],
          ]);
          await exec(
            ctx,
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES ($1,'01','01',$2,'Other','Tag Print','Y','N','N','N')`,
            USERS.clerk.user,
          );
          try {
            const { page } = await ctx.session(as(USERS.clerk.user));
            await openScreen(page);
            await label(page, 'Print file Name').selectOption('BarPrint13');
            await button(page, 'Set').click();
            await message(page, 'You Have No Rights.....');
            const direct = await page.request.post(`/api${API}/default-file`, {
              data: { file: 'BarPrint13' },
            });
            assert.equal(direct.status(), 403);
            assert.deepEqual(await marks(ctx), ['TAG/BarPrint10/Y', 'TAG/BarPrint13/N']);
            return {
              observation: 'refused on screen and 403 direct; PRINT_MAST unchanged',
              expected: '403',
              database: { marks: await marks(ctx) },
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
      'retry.replayed-print-with-file',
      'T13',
      'mutation',
      "BtnPrint_Click :5143 clears before it copies, so a replayed print with the same file stages the same rows and the sheet keeps the file's layout",
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles('BarPrint13'));
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          await label(page, 'Print file Name').selectOption('BarPrint13');
          const first = await printNow(page);
          assert.equal(first.status(), 200);
          const rows = await staged(ctx);
          const replay = await page.request.fetch(first.request());
          assert.equal(replay.status(), 200);
          assert.deepEqual(await staged(ctx), rows);
          const html = await (await page.request.get(`/api${API}/labels?file=BarPrint13`)).text();
          assert.ok(html.includes('L.0.500'));
          return {
            observation: 'same rows, BarPrint13 layout',
            expected: 'idempotent',
            database: { staged: rows.length },
            downstream: { layout: 'BarPrint13' },
          };
        }),
    ),
    C(
      'config.file-is-print-time-snapshot',
      'T15',
      'output',
      'The template is the combo text at print (:5200), not a column of TAG_PRINT_DATA: a later Set does not change a sheet requested for the earlier file; a new print after the Set shows the new file',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles('BarPrint10'));
          await seedIdtl(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          await sheetFor(page, 'BarPrint10');
          await page.request.post(`/api${API}/default-file`, { data: { file: 'BarPrint13' } });
          const again = await (await page.request.get(`/api${API}/labels?file=BarPrint10`)).text();
          assert.ok(again.includes('GLD1 / 1235') && !again.includes('L.0.500'));
          const next = await sheetFor(page, 'BarPrint13');
          assert.ok(next.includes('L.0.500'));
          return sheetResult('BarPrint10 kept; a new print is BarPrint13', 'snapshot', again);
        }),
    ),
    C(
      'config.qr-mode-files',
      'T15',
      'read-only',
      'UT_TAG_PRINT.cs:4924-4926 with QR generation on the combo lists the QR files and the QR default; no TAG row changes',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, [
            ['TAG', 'BarPrint10', 'Y'],
            ['QR', 'QrPrint10', 'N'],
            ['QR', 'QrPrint10-ALT', 'Y'],
          ]);
          const before = await marks(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          assert.deepEqual(await options(page), ['', 'BarPrint10']);
          return withQr(ctx, async () => {
            await openScreen(page);
            assert.deepEqual(await options(page), ['', 'QrPrint10', 'QrPrint10-ALT']);
            assert.equal(await label(page, 'Print file Name').inputValue(), 'QrPrint10-ALT');
            assert.deepEqual(await marks(ctx), before);
            return { observation: 'QR files with QR on; PRINT_MAST unchanged', expected: before };
          });
        }),
    ),
    C(
      'output.file-choice-per-template',
      'T16',
      'output',
      'Cr.ReportFileName :5209 = the combo text: each of the four files prints its own layout (BarPrint13.xml:10, :217; QrPrint10.xml:386; BarPrint10.xml:72)',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles('BarPrint10'));
          await seedIdtl(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          const htmls = {};
          for (const file of LABEL_FILES) htmls[file] = await sheetFor(page, file);
          const q = labelFor(labelParts(htmls.QrPrint10), 'TP0001');
          assert.ok(
            q.includes('data-qr="TP0001"') && !q.includes('*TP0001*') && q.includes('GLD1 / 1000'),
          );
          const b10 = labelFor(labelParts(htmls.BarPrint10), 'TP0001');
          assert.ok(
            b10.includes('*TP0001*') && b10.includes('GLD1 / 1235') && !b10.includes('L.0.500'),
          );
          const b13 = labelFor(labelParts(htmls.BarPrint13), 'TP0001');
          assert.ok(b13.includes('*TP0001*') && b13.includes('L.0.500') && !b13.includes('GLD1'));
          const g = labelFor(labelParts(htmls.GhatTagPrnt), 'TP0001');
          assert.ok(g.includes('*TP0001*') && g.includes('GLD1 / 1235') && g.includes('GLD2 / 99'));
          return sheetResult(
            'four different layouts',
            LABEL_FILES,
            Object.values(htmls).join('\n'),
          );
        }),
    ),
    C(
      'output.layout-per-file',
      'T16',
      'output',
      'The four files place different fields: QrPrint10 a QR picture and no barcode text, BarPrint13 the L. line and no sub-report, BarPrint10 and GhatTagPrnt the sub-report and *tag*; all place G., N., MRP, karigar, shop, group, item and tag',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles('BarPrint10'));
          await seedIdtl(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          const htmls = {};
          for (const file of LABEL_FILES) {
            htmls[file] = await sheetFor(page, file);
            const one = labelFor(labelParts(htmls[file]), 'TP0001');
            for (const t of [
              'G.10.500',
              'N.10.000',
              'MRP: 55000',
              'KARI1',
              'E2E SHOP',
              '>E1<',
              'TPG1',
              'TP0001',
            ])
              assert.ok(one.includes(t), `${file} ${t}`);
          }
          assert.equal(new Set(Object.values(htmls)).size, 4, 'four different sheets');
          return sheetResult(
            'common fields on all four, file fields differ',
            'differ',
            Object.values(htmls).join('\n'),
          );
        }),
    ),
    C(
      'output.subtagprint-lines',
      'T16',
      'output',
      'BarPrint10.xml:72 {BAR_IDTL.IT_CODE} & " / " & totext(IT_AMT,0) per row in BarPrint10 and GhatTagPrnt, QrPrint10.xml:72 totext(IT_NET_AMT,0); BarPrint13.xml:10 has none',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles());
          await seedIdtl(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          for (const file of ['BarPrint10', 'QrPrint10', 'GhatTagPrnt']) {
            const html = await sheetFor(page, file);
            const [l1, l2] = file === 'QrPrint10' ? ['1000', '56'] : ['1235', '99'];
            assert.ok(html.includes(`GLD1 / ${l1}`) && html.includes(`GLD2 / ${l2}`), file);
          }
          const none = await sheetFor(page, 'BarPrint13');
          assert.ok(!/GLD\d/.test(none));
          return sheetResult(
            'GLD1 / 1235 and GLD2 / 99 (IT_AMT) on BarPrint10 and GhatTagPrnt, GLD1 / 1000 and GLD2 / 56 (IT_NET_AMT) on QrPrint10, none on BarPrint13',
            'lines',
            none,
          );
        }),
    ),
    C(
      'output.subtagprint-link-per-file',
      'T16',
      'output',
      'The link differs per file: BarPrint10.xml:100-101 TAG_NO + VCH_SRNO, QrPrint10.xml:119 voucher row incl. SR_NO, GhatTagPrnt.xml:102 VCH_NO only (the whole voucher on every label), BarPrint13 none',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles());
          await seedIdtl(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          const bar = labelParts(await sheetFor(page, 'BarPrint10'));
          assert.deepEqual(subLines(labelFor(bar, 'TP0001')), ['GLD1 / 1235']);
          assert.deepEqual(subLines(labelFor(bar, 'TP0002')), ['GLD2 / 99']);
          const qr = labelParts(await sheetFor(page, 'QrPrint10'));
          assert.deepEqual(subLines(qr[0]), ['GLD1 / 1000']);
          const html = await sheetFor(page, 'GhatTagPrnt');
          for (const part of labelParts(html))
            assert.deepEqual(subLines(part), ['GLD1 / 1235', 'GLD2 / 99']);
          const none = labelParts(await sheetFor(page, 'BarPrint13'));
          for (const part of none) assert.deepEqual(subLines(part), []);
          return sheetResult('tag link, row link, voucher link, none', 'per file', html);
        }),
    ),
    C(
      'output.lable-skip-no-subreport-lines',
      'T16',
      'output',
      "The Lable Skip blanks are staged with VCH_NO 00000 (:5151), which GhatTagPrnt.xml:102 matches to no BAR_IDTL row: blanks print no line, the real labels all of the voucher's",
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles());
          await seedIdtl(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          const html = await sheetFor(page, 'GhatTagPrnt', {
            labelSkip: 2,
            tags: [...TWO_TAGS, { tagNo: 'TP0003', vchSrno: 3 }],
          });
          const parts = labelParts(html);
          assert.equal(parts.length, 5);
          for (const blank of parts.slice(0, 2))
            assert.ok(blank.includes('blank') && !blank.includes('GLD'));
          for (const real of parts.slice(2))
            assert.deepEqual(subLines(real), ['GLD1 / 1235', 'GLD2 / 99']);
          return sheetResult(
            'two blanks without lines, three labels with both',
            'blanks empty',
            html,
          );
        }),
    ),
    C(
      'output.huid-line-removed',
      'T16',
      'output',
      "None of the four label files places an HM id (BarPrint13.xml:205-225 and the placed-field lists), so the web's HUID: line is dropped (architect decision, owner may override)",
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles());
          await exec(
            ctx,
            `UPDATE "BAR_DETL" SET "HM_ID"='HJOURNEY' WHERE tenant_id=$1 AND "TAG_NO"='TP0001'`,
          );
          const { page } = await ctx.session();
          await openScreen(page);
          let last = '';
          for (const file of ['BarPrint10', 'GhatTagPrnt']) {
            last = await sheetFor(page, file);
            assert.ok(!last.includes('HUID') && !last.includes('HJOURNEY'), file);
          }
          return sheetResult('no HUID text on any sheet', 'none', last);
        }),
    ),
    C(
      'output.qr-picture',
      'T16',
      'output',
      'QrPrint10.xml:386 prints IMAGE_DATA.TAG_IMAGE built from the tag (:5181); the web generates the picture into the sheet from the tag number and writes no IMAGE_DATA; the blanks carry none',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, [['QR', 'QrPrint10', 'Y']]);
          return withQr(ctx, async () => {
            const { page } = await ctx.session();
            await openScreen(page);
            const html = await sheetFor(page, 'QrPrint10', {
              labelSkip: 2,
              tags: [...TWO_TAGS, { tagNo: 'TP0003', vchSrno: 3 }],
            });
            const parts = labelParts(html);
            assert.equal(parts.length, 5);
            for (const blank of parts.slice(0, 2)) assert.ok(!blank.includes('data-qr'));
            ['TP0001', 'TP0002', 'TP0003'].forEach((t, i) => {
              assert.ok(
                parts[i + 2].includes(`data-qr="${t}"`) && parts[i + 2].includes('<svg'),
                t,
              );
              assert.equal((parts[i + 2].match(/data-qr=/g) ?? []).length, 1);
            });
            const [images] = await ctx.rows(
              `SELECT count(*)::int n FROM "IMAGE_DATA" WHERE tenant_id=$1`,
            );
            assert.equal(images.n, 0);
            return sheetResult(
              'three QR pictures keyed by tag, no IMAGE_DATA row',
              'one QR per real label',
              html,
              { database: { imageData: images.n } },
            );
          });
        }),
    ),
    C(
      'output.master-fields',
      'T16',
      'output',
      'BarPrint13.xml:205 {TAG_PRINT_DATA.KR_NAME} and the placed CO_MAST.CO_NAME, ITEM_MAST.GR_CODE, IT_CODE, TAG_NO: every sheet shows karigar, shop, purity group, item and tag',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles());
          const { page } = await ctx.session();
          await openScreen(page);
          let last = '';
          for (const file of LABEL_FILES) {
            last = await sheetFor(page, file);
            const one = labelFor(labelParts(last), 'TP0001');
            for (const t of ['KARI1', 'E2E SHOP', '>E1<', 'TPG1', 'TP0001'])
              assert.ok(one.includes(t), `${file} ${t}`);
          }
          return sheetResult('karigar, shop and group on every file', 'present', last);
        }),
    ),
    C(
      'output.less-weight-line',
      'T16',
      'output',
      "BarPrint13.xml:217 'L.'+totext(ITM_GWT-ITM_NWT,3): gross 10.500 less net 10.000 is L.0.500 on BarPrint13 only",
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles());
          const { page } = await ctx.session();
          await openScreen(page);
          const b13 = await sheetFor(page, 'BarPrint13');
          const b10 = await sheetFor(page, 'BarPrint10');
          assert.ok(b13.includes('L.0.500'));
          assert.ok(!b10.includes('L.0.500'));
          return sheetResult('L.0.500 on BarPrint13 only', 'L.0.500', b13);
        }),
    ),
    C(
      'output.barcode-text',
      'T16',
      'output',
      "BarPrint13.xml:225 '*' + TAG_NO + '*' on BarPrint10, BarPrint13 and GhatTagPrnt; QrPrint10.xml:386 prints the QR picture instead",
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles());
          const { page } = await ctx.session();
          await openScreen(page);
          let last = '';
          for (const file of ['BarPrint10', 'BarPrint13', 'GhatTagPrnt']) {
            last = await sheetFor(page, file);
            assert.ok(last.includes('*TP0001*') && last.includes('<svg'), file);
          }
          const qr = await sheetFor(page, 'QrPrint10');
          assert.ok(!qr.includes('*TP0001*') && qr.includes('data-qr="TP0001"'));
          return sheetResult('*TP0001* on three files, a QR on QrPrint10', 'barcode text', last);
        }),
    ),
    C(
      'keyboard.combo-set',
      'T17',
      'mutation',
      'The combo has no key handler of its own (:4936): standard select keys change it, Tab lands on Set, Enter activates it (:1650 caption Set)',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles('BarPrint10'));
          const { page } = await ctx.session();
          await openScreen(page);
          const box = label(page, 'Print file Name');
          await box.focus();
          await page.keyboard.press('End');
          assert.equal(await box.inputValue(), 'QrPrint10');
          await box.selectOption('BarPrint13');
          await page.keyboard.press('Tab');
          assert.equal(
            await page.evaluate(() => document.activeElement?.textContent?.trim()),
            'Set',
          );
          const [set] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'POST', `${API}/default-file`)),
            page.keyboard.press('Enter'),
          ]);
          assert.equal(set.status(), 200);
          assert.ok((await marks(ctx)).includes('TAG/BarPrint13/Y'));
          return {
            observation: 'End/select, Tab to Set, Enter set BarPrint13',
            expected: 'BarPrint13 Y',
            database: { marks: await marks(ctx) },
            downstream: { set: 'BarPrint13' },
          };
        }),
    ),
    C(
      'keyboard.alt-p',
      'T17',
      'mutation',
      '&Print (:1422): Alt+P activates Print and the print runs',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles());
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          const [response] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'POST', `${API}/print`)),
            page
              .context()
              .waitForEvent('page', { timeout: 8000 })
              .then((p) => p.close())
              .catch(() => {}),
            page.keyboard.press('Alt+p'),
          ]);
          assert.equal(response.status(), 200);
          assert.equal((await staged(ctx)).length, 3);
          return {
            observation: 'Alt+P printed three labels',
            expected: 'print runs',
            database: { staged: 3 },
            downstream: { print: 200 },
          };
        }),
    ),
    C(
      'journey.chosen-file-to-label',
      'T18',
      'mutation',
      'combo -> print request -> staged rows -> chosen template -> sheet (:5200, :5209): BarPrint13 then, after Set, GhatTagPrnt',
      async (ctx) =>
        withCase(ctx, async () => {
          await putFiles(ctx, fourFiles('BarPrint10'));
          await seedIdtl(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          await loadVoucher(page);
          await label(page, 'Print file Name').selectOption('BarPrint13');
          assert.equal((await printNow(page)).status(), 200);
          const first = await (await page.request.get(`/api${API}/labels?file=BarPrint13`)).text();
          assert.ok(first.includes('L.0.500') && !first.includes('GLD1'));
          await label(page, 'Print file Name').selectOption('GhatTagPrnt');
          await Promise.all([
            page.waitForResponse((r) => isApi(r, 'POST', `${API}/default-file`)),
            button(page, 'Set').click(),
          ]);
          await openScreen(page);
          assert.equal(await label(page, 'Print file Name').inputValue(), 'GhatTagPrnt');
          await loadVoucher(page);
          assert.equal((await printNow(page)).status(), 200);
          const second = await (
            await page.request.get(`/api${API}/labels?file=GhatTagPrnt`)
          ).text();
          assert.ok(
            second.includes('GLD1 / 1235') &&
              second.includes('GLD2 / 99') &&
              second.includes('*TP0001*'),
          );
          assert.deepEqual(await marks(ctx), [
            'TAG/BarPrint10/N',
            'TAG/BarPrint13/N',
            'TAG/GhatTagPrnt/Y',
            'TAG/QrPrint10/N',
          ]);
          return {
            observation: 'BarPrint13 sheet, then the GhatTagPrnt sheet after Set',
            expected: 'two layouts',
            database: { marks: await marks(ctx) },
            downstream: { first: 'BarPrint13', second: 'GhatTagPrnt' },
          };
        }),
    ),
  ],
};
