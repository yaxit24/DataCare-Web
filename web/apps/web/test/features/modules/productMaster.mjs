import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import { SECOND_TENANT } from '../harness.mjs';

/**
 * Feature: Master → Product (desktop MS_PRODUCT with CurMast 'Product', web /masters/products).
 *
 * Desktop rules used for the expected values (MS_PRODUCT.cs unless noted):
 * - The menu button 'Product' opens MS_PRODUCT after setting MsUserRightForm to the caption (MDI_FORM.cs:7111,
 *   :7620-7628); Load shows the caption as the title and hides the scheme boxes. The list is every PRODUCT_MAST row of the
 *   company ordered by PR_CODE (:2142); a new entry has blank boxes, SEARCH RECORD and the cursor in the code (:2217-2264).
 * - Save (:2570-2665): an opened product needs the edit right ("You Have No Rights....."); "Enter Product Code.",
 *   "Enter Product Name.", "Please Insert Product Code 2 Digit..."; then the code's row is replaced by CO_CODE, PR_CODE,
 *   PR_NAME, MAIN_USER = the signed-in user (:2230) and DATA_TRFR 'N'; "Data Are Saved." and a new entry.
 * - Leaving the code refuses a code another product has (:2395-2432); leaving the name, a name another code has
 *   (:2467-2504); Enter on a blank name says "Please Insert Product Name ..." (:2434-2465); typed keys are upper-cased and
 *   the apostrophe refused (:2361-2377).
 * - Keys: Enter on the code moves on and F1 goes to the search box (:2379-2393); Enter on the name goes to Save (the next
 *   tab stop); Up and Down from any box go to the list and Esc leaves (MS_PRODUCT_KeyDown :2529-2560); in the list Enter
 *   and a double click open a product with the cursor in the name, F1 goes to the search box, Backspace shortens it.
 * - Delete (:2706-2804): "Please Select Product For Delete.", then "Are You Sure To Delete This Record now?", then "You
 *   Cant Delete Record This Product Use in Itme Master...." or "You Cant Delete Record, This Product Is Default
 *   Product...." (DM, EM, FN, HM, OG, OR, OS, OT, RD, SN), else "Delete Success.". Print does nothing (:1914-1917).
 * - The Item master's product help lists PRODUCT_MAST (`lookup.ts`, entity products).
 * Web rules that differ on purpose (gap G228): one transaction; version tokens; a name over 40 refused.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `product-master.${id}`,
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

const API = '/masters/product-master';
const SAVED = 'Data Are Saved.';
const CONFLICT =
  'This product was changed by someone else after you opened it. Open it again before saving or deleting.';
const QUESTION = 'Are You Sure To Delete This Record now?';
/** Codes the cases create; OG stands in for the desktop template's default products. */
const CASE_CODES = ['PA', 'PB', 'PC', 'OG'];
const CASE_ITEMS = ['PRI01'];

const path = (r) => new URL(r.url()).pathname;
const isApi = (r, method, p) => r.request().method() === method && path(r) === `/api${p}`;
const label = (page, text) => page.getByLabel(text, { exact: true });
const button = (page, name) => page.getByRole('button', { name, exact: true });
const focusedId = (page) =>
  page.evaluate(
    () =>
      document.activeElement?.id ||
      document.activeElement?.getAttribute('aria-label') ||
      document.activeElement?.dataset?.code ||
      document.activeElement?.textContent?.trim() ||
      '',
  );
const message = (page, text) => page.getByText(text, { exact: true }).waitFor();
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);

const productRows = (ctx, code) =>
  ctx.rows(
    `SELECT "PR_CODE" code,"PR_NAME" name,"MAIN_USER" main,"DATA_TRFR" trfr,row_id::text rid
       FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "PR_CODE"=$2 ORDER BY row_id`,
    code,
  );
const allProducts = (ctx) =>
  ctx.rows(
    `SELECT to_jsonb(p) AS r FROM "PRODUCT_MAST" p WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "PR_CODE",row_id`,
  );
/** The list MS_PRODUCT_Load reads: every product of the company by code (:2142); other modules may add products. */
const dbList = async (ctx) =>
  (
    await ctx.rows(
      `SELECT "PR_CODE" code,"PR_NAME" name FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "PR_CODE",row_id`,
    )
  ).map((r) => [String(r.code ?? '').trim(), String(r.name ?? '').trim()]);
async function cleanCase(ctx) {
  await exec(
    ctx,
    `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE" = ANY($2::text[])`,
    CASE_ITEMS,
  );
  await exec(
    ctx,
    `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "PR_CODE" = ANY($2::text[])`,
    CASE_CODES,
  );
}
async function seedProduct(ctx, code, name, main = 'DESKUSER') {
  await exec(
    ctx,
    `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME","MAIN_USER","DATA_TRFR") VALUES ($1,'01',$2,$3,$4,'N')`,
    code,
    name,
    main,
  );
}
async function withCase(ctx, run) {
  await cleanCase(ctx);
  try {
    return await run();
  } finally {
    await cleanCase(ctx);
  }
}

async function openScreen(page) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', API)),
    page.goto('/masters/products'),
  ]);
  await page.getByRole('heading', { name: 'Product', exact: true }).waitFor();
  if (response.status() === 200)
    await page.waitForFunction(() => document.activeElement?.id === 'product-code');
  return response;
}
const listed = (page) =>
  page
    .getByTestId('product-list')
    .locator('tr')
    .evaluateAll((rows) =>
      rows.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
    );
async function openProduct(page, code, how = 'enter') {
  const row = page.getByTestId('product-list').locator(`tr[data-code="${code}"]`);
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `${API}/${code}`)),
    how === 'enter' ? row.press('Enter') : row.dblclick(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.waitForFunction((c) => {
    const box = document.querySelector('#product-code');
    return box?.value === c && box.readOnly && document.activeElement?.id === 'product-name';
  }, code);
  return response.json();
}
async function fill(page, values) {
  if (values.code !== undefined) await label(page, 'Code').fill(values.code);
  if (values.name !== undefined) await label(page, 'Name').fill(values.name);
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
      document.activeElement?.id === 'product-code' &&
      !document.querySelector('#product-code')?.readOnly &&
      document.querySelector('#product-code')?.value === '',
  );
}
/** Cancel: CLEAR_DATA reads the list again and puts the cursor in an empty code box. */
async function cancel(page) {
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', API)),
    button(page, 'Cancel').click(),
  ]);
  await page.waitForFunction(
    () =>
      document.activeElement?.id === 'product-code' &&
      document.querySelector('#product-code')?.value === '',
  );
}
/** Replace the harness's accept-all dialog handler with one that answers and records the questions. */
function answerQuestions(page, answer = true) {
  const questions = [];
  page.removeAllListeners('dialog');
  page.on('dialog', (dialog) => {
    questions.push(dialog.message());
    void (answer ? dialog.accept() : dialog.dismiss());
  });
  return questions;
}

export const productMaster = {
  feature: 'product-master',
  title: 'Master → Product (MS_PRODUCT)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/masters/products/page.tsx',
    'web/apps/api/src/modules/masters/productMaster.ts',
    'web/apps/api/src/routes/productMaster.ts',
    'web/apps/web/test/features/modules/productMaster.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'MDI_FORM.cs:7111 and :7620-7628 open MS_PRODUCT with the caption as title; CLEAR_DATA (:2217-2264) blank boxes, SEARCH RECORD, cursor in the code, code MaxLength 2; the list by code (:2142); the form spec layout and tab order with the scheme boxes hidden',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedProduct(ctx, 'PB', 'E2E BANGLE');
          await seedProduct(ctx, 'PA', 'E2E ANKLET');
          const { page } = await ctx.session();
          await openScreen(page);
          assert.equal(await label(page, 'Code').inputValue(), '');
          assert.equal(await label(page, 'Name').inputValue(), '');
          assert.equal(await label(page, 'Code').getAttribute('maxlength'), '2');
          assert.equal(await label(page, 'Name').getAttribute('maxlength'), '40');
          assert.equal(await label(page, 'Search record').inputValue(), 'SEARCH RECORD');
          const list = await listed(page);
          assert.deepEqual(list, await dbList(ctx));
          assert.deepEqual(
            list.filter(([c]) => ['PA', 'PB'].includes(c)),
            [
              ['PA', 'E2E ANKLET'],
              ['PB', 'E2E BANGLE'],
            ],
          );
          const order = await page.evaluate(() =>
            [...document.querySelectorAll('main input,main button,[data-testid="product-list"] tr')]
              .filter((el) => !el.closest('nav'))
              .map(
                (el) =>
                  el.id ||
                  el.getAttribute('aria-label') ||
                  (el.tagName === 'TR' ? 'list' : el.textContent.trim()),
              ),
          );
          assert.deepEqual(order, [
            'product-code',
            'product-name',
            'Save',
            'Print',
            'Cancel',
            'Delete',
            'Exit',
            'Search record',
            ...list.map(() => 'list'),
          ]);
          const drawn = [];
          for (const name of ['Save', 'Print', 'Cancel', 'Delete', 'Exit'])
            drawn.push([name, (await button(page, name).boundingBox()).x]);
          assert.deepEqual(
            drawn.sort((a, b) => a[1] - b[1]).map(([n]) => n),
            ['Print', 'Save', 'Cancel', 'Delete', 'Exit'],
          );
          const listBox = await page.getByTestId('product-list').boundingBox();
          const codeBox = await label(page, 'Code').boundingBox();
          assert.ok(listBox.x < codeBox.x, 'the list is drawn left of the boxes');
          return {
            observation: `title Product, blank entry, cursor in the code, ${list.length} products by code, tab order ${order.join(' > ')}`,
            expected: { list, maxLength: { code: 2, name: 40 } },
          };
        }),
    ),
    C(
      'field.every-field',
      'T02',
      'mutation',
      'BtnSave_Click (:2655-2657) writes CO_CODE, PR_CODE, PR_NAME, MAIN_USER and DATA_TRFR N; DISPLAY_DATA (:2266-2340) shows the code and name again',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await fill(page, { code: 'pa', name: 'e2e anklet' });
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          const rows = await productRows(ctx, 'PA');
          assert.deepEqual(
            rows.map(({ rid, ...r }) => r),
            [{ code: 'PA', name: 'E2E ANKLET', main: USERS.admin.user, trfr: 'N' }],
          );
          await openProduct(page, 'PA');
          const shown = {
            code: await label(page, 'Code').inputValue(),
            name: await label(page, 'Name').inputValue(),
          };
          assert.deepEqual(shown, { code: 'PA', name: 'E2E ANKLET' });
          return {
            observation: 'the product stored upper-cased with the user and N, and shown again',
            expected: { code: 'PA', name: 'E2E ANKLET' },
            database: { rows },
            downstream: { shown },
          };
        }),
    ),
    C(
      'field.typing-rules',
      'T03',
      'mutation',
      'UT_TASTING_KeyPress (:2361-2377) upper-cases every key and refuses the apostrophe; the code box holds 2 characters (CLEAR_DATA :2249-2252) and Save refuses one (:2650-2653)',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Code').focus();
          await page.keyboard.type('pbx');
          assert.equal(await label(page, 'Code').inputValue(), 'PB', 'two characters, upper-cased');
          await label(page, 'Name').focus();
          await page.keyboard.type("e2e o'bangle");
          assert.equal(await label(page, 'Name').inputValue(), 'E2E OBANGLE');
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          const rows = await productRows(ctx, 'PB');
          assert.deepEqual(
            rows.map((r) => r.name),
            ['E2E OBANGLE'],
          );
          return {
            observation: 'typed pbx became PB, the apostrophe was refused',
            expected: { code: 'PB', name: 'E2E OBANGLE' },
            database: { rows },
            downstream: { list: await listed(page) },
          };
        }),
    ),
    C(
      'lookup.search-list',
      'T04',
      'read-only',
      'Text1_Click drops SEARCH RECORD and Text1_TextChanged keeps the names starting with the text (PR_NAME LIKE, :2506-2527); F1 from the code goes to the search box (:2379-2393); Backspace in the list shortens the search (DGV_KeyDown :2806-2942)',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedProduct(ctx, 'PA', 'E2E ANKLET');
          await seedProduct(ctx, 'PB', 'E2E BANGLE');
          await seedProduct(ctx, 'PC', 'E2E BRACELET');
          const { page } = await ctx.session();
          await openScreen(page);
          await page.keyboard.press('F1');
          assert.equal(await focusedId(page), 'Search record');
          assert.equal(await label(page, 'Search record').inputValue(), '');
          await page.keyboard.type('e2e b');
          const filtered = await listed(page);
          assert.deepEqual(
            filtered.map((r) => r[0]),
            ['PB', 'PC'],
          );
          await page.getByTestId('product-list').locator('tr[data-code="PB"]').focus();
          await page.keyboard.press('Backspace');
          await page.keyboard.press('Backspace');
          await page.waitForFunction(
            () => document.querySelector('[aria-label="Search record"]')?.value === 'E2E',
          );
          const widened = await listed(page);
          assert.deepEqual(
            widened.filter((r) => r[0].startsWith('P')).map((r) => r[0]),
            ['PA', 'PB', 'PC'],
          );
          return {
            observation: `"E2E B" listed ${filtered.map((r) => r[0]).join(',')}; Backspace twice listed ${widened.length}`,
            expected: { filtered: ['PB', 'PC'] },
          };
        }),
    ),
    notApplicable(
      'children',
      'T05',
      'MS_PRODUCT_Load with CurMast Product (:1918-2150) shows only the code and the name; the scheme boxes stay hidden',
      'MS_PRODUCT with CurMast Product has no child grid or detail rows: the screen is a code and a name',
    ),
    C(
      'required.refusals',
      'T06',
      'refusal',
      'Save (:2583-2653): "Enter Product Code.", "Enter Product Name.", "Please Insert Product Code 2 Digit..."; Enter on a blank name (:2434-2465); leaving the code or the name taken by another product (:2395-2504); nothing written',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedProduct(ctx, 'PB', 'E2E BANGLE');
          const before = await allProducts(ctx);
          const { page, requests } = await ctx.session();
          await openScreen(page);
          await button(page, 'Save').click();
          await message(page, 'Enter Product Code.');
          await fill(page, { code: 'PA' });
          await button(page, 'Save').click();
          await message(page, 'Enter Product Name.');
          await label(page, 'Name').focus();
          await page.keyboard.press('Enter');
          await message(page, 'Please Insert Product Name ...');
          assert.equal(await focusedId(page), 'product-name');
          await fill(page, { code: 'P', name: 'E2E PENDANT' });
          await button(page, 'Save').click();
          await message(page, 'Please Insert Product Code 2 Digit...');
          await cancel(page);
          await fill(page, { code: 'PB' });
          await label(page, 'Name').focus();
          await message(
            page,
            "This Product Code already Exist in  'E2E BANGLE'  Product Name...Please Change Pr Code...",
          );
          await page.waitForFunction(() => document.activeElement?.id === 'product-code');
          await fill(page, { code: 'PA', name: 'e2e bangle' });
          await button(page, 'Save').focus();
          await message(
            page,
            "This Product Name already Exist in  'PB'  Product Code...Please Change Pr Name...",
          );
          assert.equal(requests.filter((r) => ['POST', 'PUT'].includes(r.method)).length, 0);
          const after = await allProducts(ctx);
          assert.deepEqual(after, before);
          return {
            observation: 'every refusal shown with the desktop text; no save was sent',
            expected: 'no PRODUCT_MAST row changed',
            database: { before: before.length, after: after.length },
          };
        }),
    ),
    C(
      'create.footprint',
      'T07',
      'mutation',
      'A new product writes one PRODUCT_MAST row (:2655-2657) and no other table changes',
      async (ctx) =>
        withCase(ctx, async () => {
          const counts = async () =>
            (
              await ctx.rows(
                `SELECT (SELECT count(*)::int FROM "PRODUCT_MAST" WHERE tenant_id=$1) p,
                        (SELECT count(*)::int FROM "ITEM_MAST" WHERE tenant_id=$1) i,
                        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1) d,
                        (SELECT count(*)::int FROM "GROUP_MAST" WHERE tenant_id=$1) g`,
              )
            )[0];
          const before = await counts();
          const { page } = await ctx.session();
          await openScreen(page);
          await fill(page, { code: 'PA', name: 'E2E ANKLET' });
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          const after = await counts();
          assert.deepEqual(after, { ...before, p: before.p + 1 });
          return {
            observation: `PRODUCT_MAST ${before.p} → ${after.p}; nothing else changed`,
            expected: 'one row',
            database: { before, after },
            downstream: { list: await listed(page) },
          };
        }),
    ),
    C(
      'reopen.unchanged-save',
      'T08',
      'mutation',
      'DISPLAY_DATA then Save with nothing changed replaces the row with the same code and name; MAIN_USER becomes the signed-in user, as no product read sets MainUser back (:2230, :2657)',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedProduct(ctx, 'PA', 'E2E ANKLET', 'DESKUSER');
          const [before] = await productRows(ctx, 'PA');
          const { page } = await ctx.session();
          await openScreen(page);
          await openProduct(page, 'PA');
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const rows = await productRows(ctx, 'PA');
          assert.equal(rows.length, 1);
          assert.deepEqual(
            { code: rows[0].code, name: rows[0].name, main: rows[0].main, trfr: rows[0].trfr },
            { code: 'PA', name: 'E2E ANKLET', main: USERS.admin.user, trfr: 'N' },
          );
          return {
            observation: `the row was replaced (${before.rid} → ${rows[0].rid}) with the same name, MAIN_USER ${rows[0].main}`,
            expected: { main: USERS.admin.user },
            database: { before, after: rows },
            downstream: { status: response.status() },
          };
        }),
    ),
    C(
      'edit.name',
      'T09',
      'mutation',
      "An opened product's name is changed and saved (:2655-2657); the items naming the product keep it (ITEM_MAST.PR_CODE is not touched)",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedProduct(ctx, 'PA', 'E2E ANKLET');
          await exec(
            ctx,
            `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE") VALUES ($1,'01','PRI01','E2E PRODUCT ITEM','PA')`,
          );
          const { page } = await ctx.session();
          await openScreen(page);
          await openProduct(page, 'PA', 'dblclick');
          await fill(page, { name: 'E2E ANKLET 22K' });
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const rows = await productRows(ctx, 'PA');
          const items = await ctx.rows(
            `SELECT "IT_CODE" code,"PR_CODE" pr FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"='PRI01'`,
          );
          assert.deepEqual(
            rows.map((r) => r.name),
            ['E2E ANKLET 22K'],
          );
          assert.deepEqual(items, [{ code: 'PRI01', pr: 'PA' }]);
          const list = await listed(page);
          assert.ok(list.some(([c, n]) => c === 'PA' && n === 'E2E ANKLET 22K'));
          return {
            observation: 'renamed PA; its item still names PA',
            expected: { name: 'E2E ANKLET 22K' },
            database: { rows, items },
            downstream: { list },
          };
        }),
    ),
    C(
      'delete.lifecycle',
      'T10',
      'mutation',
      'BtnDelete_Click (:2706-2804): a blank code is refused without the question; otherwise the question comes first and then an item-used or default product is refused; an unused product is deleted with "Delete Success."; No keeps it',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedProduct(ctx, 'PA', 'E2E ANKLET');
          await seedProduct(ctx, 'PB', 'E2E BANGLE');
          await seedProduct(ctx, 'OG', 'OLD GOLD');
          await exec(
            ctx,
            `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE") VALUES ($1,'01','PRI01','E2E PRODUCT ITEM','PB')`,
          );
          const { page } = await ctx.session();
          let questions = answerQuestions(page);
          await openScreen(page);
          await button(page, 'Delete').click();
          await message(page, 'Please Select Product For Delete.');
          assert.deepEqual(questions, []);
          await openProduct(page, 'PB');
          await button(page, 'Delete').click();
          await message(page, 'You Cant Delete Record This Product Use in Itme Master....');
          await cancel(page);
          await openProduct(page, 'OG');
          await button(page, 'Delete').click();
          await message(page, 'You Cant Delete Record, This Product Is Default Product....');
          assert.deepEqual(
            questions,
            [QUESTION, QUESTION],
            'the question comes before both refusals',
          );
          await cancel(page);
          questions = answerQuestions(page, false);
          await openProduct(page, 'PA');
          await button(page, 'Delete').click();
          await page.waitForTimeout(300);
          assert.equal((await productRows(ctx, 'PA')).length, 1, 'No keeps the product');
          questions = answerQuestions(page, true);
          const [removed] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'DELETE', `${API}/PA`)),
            button(page, 'Delete').click(),
          ]);
          assert.equal(removed.status(), 200, await removed.text());
          await message(page, 'Delete Success.');
          await page.waitForFunction(
            () => !document.querySelector('[data-testid="product-list"] tr[data-code="PA"]'),
          );
          const rows = {
            PA: await productRows(ctx, 'PA'),
            PB: await productRows(ctx, 'PB'),
            OG: await productRows(ctx, 'OG'),
          };
          assert.deepEqual(rows.PA, []);
          assert.equal(rows.PB.length + rows.OG.length, 2);
          return {
            observation:
              'blank refused without asking; PB and OG refused after the question; No kept PA; Yes deleted it',
            expected: 'the desktop order and texts',
            database: { rows },
            downstream: { list: await listed(page) },
          };
        }),
    ),
    C(
      'rights.view-only',
      'T11',
      'refusal',
      'MS_PRODUCT_Load reads FRM_EDIT/FRM_DELETE of the user\'s rights row (:1918-1935): Save of an opened product and Delete answer "You Have No Rights....." (:2583-2587, :2723-2727); a new product needs only the view right',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedProduct(ctx, 'PA', 'E2E ANKLET');
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "PR_CODE"='PA'`,
            SECOND_TENANT,
          );
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES ($1,'01','PA','SENTINEL')`,
            SECOND_TENANT,
          );
          await exec(
            ctx,
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES ($1,'01','01',$2,'Master','Product','Y','N','N','N')`,
            USERS.clerk.user,
          );
          try {
            const { page, requests } = await ctx.session(as(USERS.clerk.user));
            await openScreen(page);
            const opened = await openProduct(page, 'PA');
            await fill(page, { name: 'E2E CHANGED' });
            await button(page, 'Save').click();
            await message(page, 'You Have No Rights.....');
            await cancel(page);
            await openProduct(page, 'PA');
            await button(page, 'Delete').click();
            await message(page, 'You Have No Rights.....');
            assert.equal(requests.filter((r) => ['PUT', 'DELETE'].includes(r.method)).length, 0);
            const direct = [
              (
                await page.request.put(`/api${API}/PA`, {
                  data: { name: 'X', expectedVersion: opened.version },
                })
              ).status(),
              (
                await page.request.delete(`/api${API}/PA?expectedVersion=${opened.version}`)
              ).status(),
            ];
            assert.deepEqual(direct, [403, 403]);
            await cancel(page);
            await fill(page, { code: 'PC', name: 'E2E CLERK PRODUCT' });
            const created = await save(page);
            assert.equal(created.status(), 201, await created.text());
            await saved(page);
            const rows = { PA: await productRows(ctx, 'PA'), PC: await productRows(ctx, 'PC') };
            assert.equal(rows.PA[0].name, 'E2E ANKLET');
            assert.deepEqual(
              rows.PC.map((r) => [r.name, r.main]),
              [['E2E CLERK PRODUCT', USERS.clerk.user]],
            );
            const sentinel = await ctx.owner.$queryRawUnsafe(
              `SELECT "PR_NAME" name FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "PR_CODE"='PA'`,
              SECOND_TENANT,
            );
            assert.deepEqual(sentinel, [{ name: 'SENTINEL' }]);
            const printer = await ctx.session(as(USERS.printViewer.user));
            const refused = await openScreen(printer.page);
            assert.equal(refused.status(), 403);
            await message(printer.page, 'You Have No Rights.....');
            return {
              observation: `clerk refused on screen; direct ${direct.join('/')}; clerk created PC; e2eprint refused ${refused.status()}`,
              expected:
                'the desktop texts, 403s, a new product allowed, the sentinel tenant untouched',
              database: { rows, sentinel },
            };
          } finally {
            await exec(
              ctx,
              `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Product'`,
              USERS.clerk.user,
            );
            await ctx.owner.$executeRawUnsafe(
              `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "PR_CODE"='PA'`,
              SECOND_TENANT,
            );
          }
        }),
    ),
    C(
      'concurrency.two-operators',
      'T12',
      'mutation',
      'Two operators open one product: the first save wins and the second is refused with 409 (version token, G228) where the desktop lets the later save win; two new entries with one code: the second is refused with the code text under the company lock',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedProduct(ctx, 'PA', 'E2E ANKLET');
          const a = (await ctx.session()).page;
          const b = (await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#2`))).page;
          await openScreen(a);
          await openScreen(b);
          await openProduct(a, 'PA');
          await openProduct(b, 'PA');
          await fill(a, { name: 'E2E ANKLET A' });
          const first = await save(a);
          assert.equal(first.status(), 200, await first.text());
          await saved(a);
          await fill(b, { name: 'E2E ANKLET B' });
          const second = await save(b);
          assert.equal(second.status(), 409);
          await message(b, CONFLICT);
          await cancel(b);
          await fill(a, { code: 'PC', name: 'E2E NEW A' });
          await fill(b, { code: 'PC', name: 'E2E NEW B' });
          assert.equal((await save(a)).status(), 201);
          await saved(a);
          const late = await save(b);
          assert.equal(late.status(), 400);
          await message(
            b,
            "This Product Code already Exist in  'E2E NEW A'  Product Name...Please Change Pr Code...",
          );
          const rows = { PA: await productRows(ctx, 'PA'), PC: await productRows(ctx, 'PC') };
          assert.deepEqual(
            rows.PA.map((r) => r.name),
            ['E2E ANKLET A'],
          );
          assert.deepEqual(
            rows.PC.map((r) => r.name),
            ['E2E NEW A'],
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
      "A replayed edit carries a spent version and is refused (409); a replayed new product has the same code and name, so it replaces the same row (BtnSave_Click's DELETE + INSERT) and no second row appears",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedProduct(ctx, 'PA', 'E2E ANKLET');
          const { page } = await ctx.session();
          await openScreen(page);
          await openProduct(page, 'PA');
          await fill(page, { name: 'E2E ANKLET RETRY' });
          const first = await save(page);
          assert.equal(first.status(), 200, await first.text());
          await saved(page);
          const replayEdit = (await page.request.fetch(first.request())).status();
          assert.equal(replayEdit, 409);
          await fill(page, { code: 'PC', name: 'E2E RETRY PRODUCT' });
          const created = await save(page);
          assert.equal(created.status(), 201, await created.text());
          await saved(page);
          const replayCreate = (await page.request.fetch(created.request())).status();
          assert.equal(replayCreate, 201);
          const rows = { PA: await productRows(ctx, 'PA'), PC: await productRows(ctx, 'PC') };
          assert.equal(rows.PA[0].name, 'E2E ANKLET RETRY');
          assert.equal(rows.PC.length, 1, 'one row after the replay');
          return {
            observation: `replayed edit ${replayEdit}; replayed create ${replayCreate}; PC has ${rows.PC.length} row`,
            expected: 'the edit replay refused, one row for PC',
            database: { rows },
            downstream: { replayEdit, replayCreate },
          };
        }),
    ),
    C(
      'rollback.insert-fault',
      'T14',
      'mutation',
      "BtnSave_Click deletes the code's row before it inserts the new one (:2655-2657); a fault on the insert must roll the delete back, leaving the row as it was (the desktop would leave the product deleted)",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedProduct(ctx, 'PA', 'E2E ANKLET');
          const before = await allProducts(ctx);
          await ctx.owner.$executeRawUnsafe(
            `CREATE OR REPLACE FUNCTION e2e_product_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
             BEGIN
               IF NEW."PR_NAME" = 'E2E FAULT' THEN RAISE EXCEPTION 'e2e fault after the delete'; END IF;
               RETURN NEW;
             END $f$`,
          );
          await ctx.owner.$executeRawUnsafe(
            `CREATE TRIGGER e2e_product_fault BEFORE INSERT ON "PRODUCT_MAST" FOR EACH ROW EXECUTE FUNCTION e2e_product_fault()`,
          );
          try {
            const { page } = await ctx.session();
            await openScreen(page);
            await openProduct(page, 'PA');
            await fill(page, { name: 'E2E FAULT' });
            const failed = await save(page);
            assert.equal(failed.status(), 400, await failed.text());
            const after = await allProducts(ctx);
            assert.deepEqual(after, before, 'the delete was rolled back with the failed insert');
            return {
              observation: `the save answered ${failed.status()}; every PRODUCT_MAST row is as before`,
              expected: 'no row lost',
              database: { before, after },
              downstream: { status: failed.status() },
            };
          } finally {
            await ctx.owner.$executeRawUnsafe(
              `DROP TRIGGER IF EXISTS e2e_product_fault ON "PRODUCT_MAST"`,
            );
            await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_product_fault()`);
          }
        }),
    ),
    C(
      'history.company-wide',
      'T15',
      'mutation',
      'PRODUCT_MAST has no year: MS_PRODUCT reads and writes by CO_CODE and PR_CODE (:2142, :2655), so a product saved in this year is the product of the historic year too',
      async (ctx) =>
        withCase(ctx, async () => {
          // Its own login: opening another year moves the server session, which the other cases' saved login shares.
          const { page } = await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#history`));
          await openScreen(page);
          await fill(page, { code: 'PA', name: 'E2E YEAR PRODUCT' });
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          await page.goto('/select');
          await page.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
          await page.getByRole('combobox', { name: 'FINANCIAL YEAR' }).selectOption('2024-2025');
          await button(page, 'Open').click();
          await page.waitForURL('**/dashboard');
          const me = await (await page.request.get('/api/me')).json();
          assert.equal(me.coYear, '2024-2025');
          await openScreen(page);
          const list = await listed(page);
          assert.ok(list.some(([c, n]) => c === 'PA' && n === 'E2E YEAR PRODUCT'));
          return {
            observation: `the historic year lists PA among ${list.length} products`,
            expected: 'the same products in every year',
            database: { rows: await productRows(ctx, 'PA') },
            downstream: { historicYearList: list },
          };
        }),
    ),
    C(
      'output.print-does-nothing',
      'T16',
      'output',
      'BtnPrint_Click is empty in MS_PRODUCT (:1914-1917): Print sends nothing and shows nothing',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedProduct(ctx, 'PA', 'E2E ANKLET');
          const { page, requests } = await ctx.session();
          await openScreen(page);
          await openProduct(page, 'PA');
          const sent = requests.length;
          await button(page, 'Print').click();
          await page.waitForTimeout(400);
          const after = requests.slice(sent).map((r) => `${r.method} ${r.path}`);
          assert.deepEqual(after, []);
          assert.equal(await page.locator('section[aria-label]').count(), 0);
          assert.equal(await label(page, 'Code').inputValue(), 'PA', 'the entry is left as it was');
          return {
            observation: 'Print sent no request and opened nothing',
            expected: 'nothing',
            output: { requests: after },
          };
        }),
    ),
    C(
      'keyboard.desktop-keys',
      'T17',
      'mutation',
      'UT_TASTING_KeyPress (:2361-2377), tPrCode_KeyDown (:2379-2393), tPrName_KeyDown (:2434-2465), MS_PRODUCT_KeyDown Up/Down to the list and Esc (:2529-2560), DGV_KeyDown (:2806-2942) and the &Save mnemonic',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedProduct(ctx, 'PA', 'E2E ANKLET');
          const { page } = await ctx.session();
          await openScreen(page);
          await page.keyboard.press('Enter');
          assert.equal(await focusedId(page), 'product-code', 'Enter on a blank code stays');
          await page.keyboard.type('pb');
          await page.keyboard.press('Enter');
          assert.equal(await focusedId(page), 'product-name');
          await page.keyboard.press('Enter');
          await message(page, 'Please Insert Product Name ...');
          await page.keyboard.type('e2e bangle');
          await page.keyboard.press('Enter');
          assert.equal(await focusedId(page), 'Save');
          const created = await save(page, () => page.keyboard.press('Enter'));
          assert.equal(created.status(), 201, await created.text());
          await saved(page);
          // Down from the code box goes to the list; Down again moves a row; Enter opens it with the cursor in the name.
          const codes = (await listed(page)).map(([c]) => c);
          await page.keyboard.press('ArrowDown');
          assert.equal(await focusedId(page), codes[0], 'the first row of the list');
          for (let i = 0; i < codes.indexOf('PB'); i++) await page.keyboard.press('ArrowDown');
          assert.equal(await focusedId(page), 'PB');
          const [opened] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/PB`)),
            page.keyboard.press('Enter'),
          ]);
          assert.equal(opened.status(), 200);
          await page.waitForFunction(() => document.activeElement?.id === 'product-name');
          await page.keyboard.type(' 22K');
          const altSaved = await save(page, () => page.keyboard.press('Alt+s'));
          assert.equal(altSaved.status(), 200, await altSaved.text());
          await saved(page);
          await page.keyboard.press('Escape');
          await page.waitForURL((url) => !url.pathname.startsWith('/masters/products'));
          const rows = await productRows(ctx, 'PB');
          assert.deepEqual(
            rows.map((r) => [r.name, r.main]),
            [['E2E BANGLE 22K', USERS.admin.user]],
          );
          return {
            observation: `keyed in PB with Enter, opened it from the list with the arrows, saved with Alt+S; Esc left for ${new URL(page.url()).pathname}`,
            expected: 'every desktop key as listed in the source',
            database: { rows },
            downstream: { leftTo: new URL(page.url()).pathname },
          };
        }),
    ),
    C(
      'journey.product-in-the-item-master',
      'T18',
      'mutation',
      "A product saved here is offered by the Item master's product help (lookup.ts entity products); once an item names it, Delete refuses it after the question (:2775-2781); with the item gone, Delete removes it",
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          let questions = answerQuestions(page);
          await openScreen(page);
          await fill(page, { code: 'PC', name: 'E2E JOURNEY PRODUCT' });
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          const help = await (await page.request.get('/api/lookup/products?q=PC&limit=20')).json();
          assert.ok(
            help.some((r) => r.code === 'PC' && r.name === 'E2E JOURNEY PRODUCT'),
            JSON.stringify(help),
          );
          await exec(
            ctx,
            `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE") VALUES ($1,'01','PRI01','E2E PRODUCT ITEM','PC')`,
          );
          await openProduct(page, 'PC');
          await button(page, 'Delete').click();
          await message(page, 'You Cant Delete Record This Product Use in Itme Master....');
          await exec(ctx, `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"='PRI01'`);
          await cancel(page);
          await openProduct(page, 'PC');
          const [removed] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'DELETE', `${API}/PC`)),
            button(page, 'Delete').click(),
          ]);
          assert.equal(removed.status(), 200, await removed.text());
          await message(page, 'Delete Success.');
          assert.deepEqual(questions, [QUESTION, QUESTION]);
          const after = await (await page.request.get('/api/lookup/products?q=PC&limit=20')).json();
          assert.ok(!after.some((r) => r.code === 'PC'));
          return {
            observation:
              'the item help offered PC; an item naming it blocked the delete; without it the delete went through',
            expected: 'the product reaches the Item master and the item guard',
            database: { rows: await productRows(ctx, 'PC') },
            downstream: { help, after },
          };
        }),
    ),
  ],
};
