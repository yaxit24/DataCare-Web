import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, PARTIES, USERS } from '../fixtures/catalogue.mjs';
import { escLeavesWithNoFocus, SECOND_TENANT } from '../harness.mjs';

/**
 * Feature: Master → Item (desktop MS_ITEM, web /masters/items).
 *
 * Desktop rules used for the expected values (MS_ITEM.cs unless noted):
 * - The menu button 'Item' opens MS_ITEM directly (MDI_FORM.cs:7650-7659). The list is every ITEM_MAST row of the
 *   company by name, shown as Code / Name / Safe (:2548-2843); a new entry has blank boxes, Safe MAIN, Gram Wise, Yes,
 *   Weight and the cursor in the product (CLEAR_DATA :2845-2877).
 * - The product and group come from their helps (:3081-3116, :3397-3450): a group fills the item type, tag type and trade
 *   type and, on a new entry, the item code (product + group) and name (product name + " " + group code); an existing
 *   item code asks "This Item already Exist in '<name>' Item Name...You Want to Creat New Item..." (:3452-3495).
 * - Save (:3165-3300): an opened item needs the edit right; "Product Code Is Null Please Create Item Again..", then the
 *   group and the item code texts; Val of the number boxes; the first letter of Rate Per, Stk Display and Oth Dtl Rate
 *   Type; MAIN_USER (the user for a new item, the stored one for an opened item); "Data Are Saved.".
 * - Leaving the item code refuses a code another item has under another name; leaving the name, a name another code has
 *   (:3497-3629). Enter on the number boxes shows Val as 0.00 (bag weight 0.0000) and on Bag Weight goes to Save.
 * - Delete (:3302-3355): stock rows ("You Can't Delete Record This Item Use in Transaction...."), a default code ("You
 *   Cant Delete Record This Item Code Is Default Code....") and a blank code are refused before "Are You Sure To Delete
 *   This Record now?". Print checks the print right and does nothing else (:3697-3705).
 * - The Tag Value Update panel (PnlBotam double click, :3922-4015) sets zero labour %, karigar touch and wastage on the
 *   item's tags at the location and recomputes KR_FINE = KR_NET_WT × (KR_TOUCH + KR_WEST_PRC) / 100 for the year.
 * - A sale of the item credits the line to its group's SALE_AC (sales.ts, G169) and the invoice prints the item's HSN.
 * Web rules that differ on purpose (gap G231): the row is updated in place (MIN_STK and the averages kept); unknown product
 * or group and a blank name refused; an opened item's code is read-only; version tokens; the tag update needs the edit
 * right.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `item-master.${id}`,
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

const API = '/masters/item-master';
const SAVED = 'Data Are Saved.';
const CONFLICT =
  'This item was changed by someone else after you opened it. Open it again before saving or deleting.';
const QUESTION = 'Are You Sure To Delete This Record now?';
/** Products and a group the cases use; the catalogue's group E1 (SALES / PURCHASE) is used as it is. */
const PRODUCTS = [
  ['IM', 'E2E IM RING'],
  ['IN', 'E2E IN CHAIN'],
];
const GROUP = ['IMG', 'E2E IM GOLD', 'G', 'GO'];
const CASE_ITEMS = ['IMIMG', 'ININ1', 'IMIM2', 'INIMG', 'OG', 'IMX'];

const path = (r) => new URL(r.url()).pathname;
const isApi = (r, method, p) => r.request().method() === method && path(r) === `/api${p}`;
const label = (page, text) => page.getByLabel(text, { exact: true });
const button = (page, name) => page.getByRole('button', { name, exact: true });
const focusedId = (page) =>
  page.evaluate(
    () =>
      document.activeElement?.getAttribute('aria-label') ||
      document.activeElement?.id ||
      document.activeElement?.dataset?.code ||
      document.activeElement?.textContent?.trim() ||
      '',
  );
const message = (page, text) => page.getByText(text, { exact: true }).waitFor();
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);

const itemRow = async (ctx, code) =>
  (
    await ctx.rows(
      `SELECT "PR_CODE" pr,"GR_CODE" gr,"IT_CODE" code,"IT_NAME" name,"IT_TYPE" type,"TAG_TYPE" tag,"TRAD_TYPE" trade,
              "SAFE_NAME" safe,"HSN_CODE" hsn,"UNIT_NAME" unit,"RATE_TYPE" rate,"STK_DISPLAY" stk,"IT_LBR_RATE"::float lbrrate,
              "LBR_PRC"::float lbr,"IT_GHT_PRC"::float ght,"CON_PRC"::float con,"DISC_PRC"::float disc,"ITEM_RATE"::float itemrate,
              "OTH_RATE"::float oth,"OTH_RATE_TYPE" othtype,"IT_BAG_WT"::float bag,"MAIN_USER" main,"MIN_STK" minstk,
              "AVG_TOUCH"::float avg
         FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"=$2`,
      code,
    )
  )[0];
const allItems = (ctx) =>
  ctx.rows(
    `SELECT to_jsonb(i) AS r FROM "ITEM_MAST" i WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "IT_CODE"`,
  );
/** The list MS_ITEM_Load reads: every item of the company by name (:2548-2784); other modules add items in a full run. */
const dbList = async (ctx) =>
  (
    await ctx.rows(
      `SELECT "IT_CODE" code,"IT_NAME" name,"SAFE_NAME" safe FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "IT_NAME","IT_CODE"`,
    )
  ).map((r) => [r.code ?? '', r.name ?? '', r.safe ?? ''].map((v) => String(v).trim()));

async function cleanCase(ctx) {
  for (const table of ['MAIN_STOCK', 'BAR_DETL', 'ITEM_MAST'])
    await exec(
      ctx,
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "IT_CODE" = ANY($2::text[])`,
      CASE_ITEMS,
    );
}
async function seedItem(ctx, code, name, extra = {}) {
  await exec(
    ctx,
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE","GR_CODE","IT_TYPE","TAG_TYPE","TRAD_TYPE","SAFE_NAME",
                             "HSN_CODE","UNIT_NAME","RATE_TYPE","STK_DISPLAY","LBR_PRC","OTH_RATE_TYPE","MAIN_USER","MIN_STK","AVG_TOUCH")
     VALUES ($1,'01',$2,$3,$4,$5,'G','G','GO',$6,$7,'GM','G','Y',$8,'W',$9,$10,$11)`,
    code,
    name,
    extra.pr ?? 'IM',
    extra.gr ?? 'IMG',
    extra.safe ?? 'MAIN',
    extra.hsn ?? '7113',
    extra.lbr ?? 0,
    extra.main ?? 'DESKUSER',
    extra.minstk ?? null,
    extra.avg ?? null,
  );
}
async function withMasters(ctx, run) {
  await exec(
    ctx,
    `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "PR_CODE" = ANY($2::text[])`,
    PRODUCTS.map(([code]) => code),
  );
  for (const [code, name] of PRODUCTS)
    await exec(
      ctx,
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME","DATA_TRFR") VALUES ($1,'01',$2,$3,'N')`,
      code,
      name,
    );
  await exec(ctx, `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE"=$2`, GROUP[0]);
  await exec(
    ctx,
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE","TRAD_TYPE","SALE_AC","PURC_AC","HSN_CODE")
     VALUES ($1,'01',$2,$3,$4,$5,'SALES','PURCHASE','7113')`,
    ...GROUP,
  );
  await cleanCase(ctx);
  try {
    return await run();
  } finally {
    await cleanCase(ctx);
    await exec(ctx, `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE"=$2`, GROUP[0]);
    await exec(
      ctx,
      `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "PR_CODE" = ANY($2::text[])`,
      PRODUCTS.map(([code]) => code),
    );
  }
}

async function openScreen(page) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', API)),
    page.goto('/masters/items'),
  ]);
  await page.getByRole('heading', { name: 'Item Master', exact: true }).waitFor();
  if (response.status() === 200)
    await page.waitForFunction(
      () => document.activeElement?.getAttribute('aria-label') === 'Pr Code',
    );
  return response;
}
const listed = (page) =>
  page
    .getByTestId('item-list')
    .locator('tr')
    .evaluateAll((rows) =>
      rows.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
    );
async function openItem(page, code, how = 'dblclick') {
  const row = page.getByTestId('item-list').locator(`tr[data-code="${code}"]`);
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `${API}/${code}`)),
    how === 'enter' ? row.press('Enter') : row.dblclick(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.waitForFunction((c) => {
    const box = document.querySelector('#item-code');
    return box?.value === c && box.readOnly && document.activeElement?.id === 'item-name';
  }, code);
  return response.json();
}
/** Choose a product and a group through their boxes as an operator does: type the code, Enter. */
async function choose(page, productCode, groupCode) {
  const product = label(page, 'Pr Code');
  await product.fill(productCode);
  await product.press('Enter');
  await page.waitForFunction(
    () => document.activeElement?.getAttribute('aria-label') === 'Gr Code',
  );
  const group = label(page, 'Gr Code');
  await group.fill(groupCode);
  await group.press('Enter');
}
const BOXES = {
  code: 'Item Code',
  tagType: 'Tag Type',
  name: 'Item Name',
  safe: 'Safe Name',
  hsn: 'Hsn Code',
  unit: 'Unit Name',
  lbrRate: 'Labour Rate',
  lbrPrc: 'Labour %',
  ghtPrc: 'Ght %',
  conPrc: 'Conversion %',
  discPrc: 'Discount %',
  itemRate: 'Item Rate',
  othRate: 'Oth itm Rate',
  bagWt: 'Bag Weight',
  itType: 'Item Type',
  tradeType: 'Trade Type',
};
async function fill(page, values) {
  for (const [key, value] of Object.entries(values)) {
    if (key === 'rateType') await label(page, 'Rate Per').selectOption(value);
    else if (key === 'othRateType') await page.locator('#item-othRateType').selectOption(value);
    else if (key === 'stockDisplay') await label(page, 'Stk Display').selectOption(value);
    else await label(page, BOXES[key]).fill(value);
  }
}
async function save(page, trigger = () => button(page, 'Save').click()) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        ['POST', 'PUT'].includes(r.request().method()) &&
        path(r).startsWith(`/api${API}`) &&
        !path(r).endsWith('/tag-values'),
    ),
    trigger(),
  ]);
  return response;
}
async function saved(page) {
  await message(page, SAVED);
  await page.waitForFunction(
    () =>
      document.activeElement?.getAttribute('aria-label') === 'Pr Code' &&
      document.querySelector('#item-code')?.value === '',
  );
}
async function cancel(page) {
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', API)),
    button(page, 'Cancel').click(),
  ]);
  await page.waitForFunction(
    () =>
      document.activeElement?.getAttribute('aria-label') === 'Pr Code' &&
      document.querySelector('#item-code')?.value === '',
  );
}
/** Replace the harness's accept-all dialog handler: answer each question (a function gets its index) and record it. */
function answerQuestions(page, answer = true) {
  const questions = [];
  page.removeAllListeners('dialog');
  page.on('dialog', (dialog) => {
    questions.push(dialog.message());
    const yes = typeof answer === 'function' ? answer(questions.length - 1) : answer;
    void (yes ? dialog.accept() : dialog.dismiss());
  });
  return questions;
}
const FULL = {
  safe: 'e2e vault',
  hsn: '711319',
  unit: 'gm',
  rateType: '1',
  lbrRate: '350',
  lbrPrc: '12.5',
  ghtPrc: '0.75',
  conPrc: '1.2',
  discPrc: '2',
  itemRate: '6123.45',
  othRate: '150x',
  othRateType: 'P',
  bagWt: '0.0125',
  stockDisplay: 'N',
};

export const itemMaster = {
  feature: 'item-master',
  title: 'Master → Item (MS_ITEM)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/masters/items/page.tsx',
    'web/apps/web/lib/screenEscape.ts',
    'web/apps/api/src/modules/masters/itemMaster.ts',
    'web/apps/api/src/routes/itemMaster.ts',
    'web/apps/web/test/features/modules/itemMaster.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'MDI_FORM.cs:7650-7659 opens MS_ITEM; CLEAR_DATA (:2845-2877) blank boxes, Safe MAIN, Gram Wise, Yes, Weight, cursor in the product; the list by name with Code / Name / Safe (:2795-2843); the form spec layout and tab order',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const shown = {
            product: await label(page, 'Pr Code').inputValue(),
            code: await label(page, 'Item Code').inputValue(),
            safe: await label(page, 'Safe Name').inputValue(),
            rate: await label(page, 'Rate Per').inputValue(),
            stk: await label(page, 'Stk Display').inputValue(),
            oth: await page.locator('#item-othRateType').inputValue(),
          };
          assert.deepEqual(shown, {
            product: '',
            code: '',
            safe: 'MAIN',
            rate: 'G',
            stk: 'Y',
            oth: 'W',
          });
          const rates = await label(page, 'Rate Per').locator('option').allInnerTexts();
          assert.deepEqual(rates, ['Gram Wise', '10Gm Wise', 'Kg Wise', 'Pcs Wise']);
          const headers = (
            await page
              .getByTestId('item-list')
              .locator('xpath=..')
              .locator('thead th')
              .allInnerTexts()
          ).map((t) => t.trim());
          assert.deepEqual(headers, ['Code', 'Name', 'Safe']);
          const list = await listed(page);
          assert.deepEqual(list, await dbList(ctx));
          const order = await page.evaluate(() =>
            [...document.querySelectorAll('main input,main select,main button')]
              .filter((el) => !el.closest('nav') && el.tabIndex >= 0)
              .map((el) => el.getAttribute('aria-label') || el.id || el.textContent.trim()),
          );
          assert.deepEqual(order.slice(0, 18), [
            'Pr Code',
            'Gr Code',
            'item-code',
            'Tag Type',
            'item-name',
            'item-safe',
            'item-hsn',
            'item-unit',
            'item-rateType',
            'Labour Rate',
            'Labour %',
            'Ght %',
            'Conversion %',
            'Discount %',
            'Item Rate',
            'Oth itm Rate',
            'item-othRateType',
            'Bag Weight',
          ]);
          const listBox = await page.getByTestId('item-list').boundingBox();
          const codeBox = await label(page, 'Item Code').boundingBox();
          assert.ok(listBox.x < codeBox.x, 'the list is drawn left of the boxes');
          return {
            observation: `blank entry with MAIN / Gram Wise / Yes / Weight, ${list.length} items by name`,
            expected: { shown, rates, headers },
          };
        }),
    ),
    C(
      'field.every-field',
      'T02',
      'mutation',
      'BtnSave_Click (:3225-3263) writes every box; DISPLAY_DATA (:2879-3045) shows them again, numbers as 0.00 and the bag weight as 0.0000',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await choose(page, 'im', 'img');
          await page.waitForFunction(() => document.querySelector('#item-code')?.value === 'IMIMG');
          await fill(page, FULL);
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          const row = await itemRow(ctx, 'IMIMG');
          assert.deepEqual(row, {
            pr: 'IM',
            gr: 'IMG',
            code: 'IMIMG',
            name: 'E2E IM RING IMG',
            type: 'G',
            tag: 'G',
            trade: 'GO',
            safe: 'E2E VAULT',
            hsn: '711319',
            unit: 'GM',
            rate: '1',
            stk: 'N',
            lbrrate: 350,
            lbr: 12.5,
            ght: 0.75,
            con: 1.2,
            disc: 2,
            itemrate: 6123.45,
            oth: 150,
            othtype: 'P',
            bag: 0.013,
            main: USERS.admin.user,
            minstk: null,
            avg: null,
          });
          await openItem(page, 'IMIMG');
          const reopened = {
            product: await label(page, 'Pr Code').inputValue(),
            productName: await label(page, 'Product Name').inputValue(),
            groupName: await label(page, 'Group Name').inputValue(),
            lbrPrc: await label(page, 'Labour %').inputValue(),
            bag: await label(page, 'Bag Weight').inputValue(),
            oth: await page.locator('#item-othRateType').inputValue(),
          };
          assert.deepEqual(reopened, {
            product: 'IM',
            productName: 'E2E IM RING',
            groupName: 'E2E IM GOLD',
            lbrPrc: '12.50',
            bag: '0.0130',
            oth: 'P',
          });
          return {
            observation:
              'every box stored and shown again; the bag weight kept at the column scale (0.013)',
            expected: row,
            database: { row },
            downstream: { reopened },
          };
        }),
    ),
    C(
      'formula.val-and-format',
      'T03',
      'mutation',
      'Conversion.Val of each number box (:3245-3251); Enter shows Strings.Format(Val, "0.00"), the bag weight "0.0000" (:3559-3754); MS_ITEM_KeyPress upper-cases and drops the apostrophe (:3066-3079)',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await choose(page, 'IM', 'IMG');
          await page.waitForFunction(() => document.querySelector('#item-code')?.value === 'IMIMG');
          await label(page, 'Item Name').fill('');
          await label(page, 'Item Name').focus();
          await page.keyboard.type("e2e o'val ring");
          assert.equal(await label(page, 'Item Name').inputValue(), 'E2E OVAL RING');
          const shownAfterEnter = {};
          for (const [key, typedValue] of [
            // Six characters, the box's MaxLength (resx nLbrRate); a longer value is cut by the box itself.
            ['lbrRate', '35.556'],
            ['lbrPrc', 'abc'],
            ['ghtPrc', ''],
            ['bagWt', '1.23456'],
          ]) {
            await label(page, BOXES[key]).fill(typedValue);
            await label(page, BOXES[key]).press('Enter');
            shownAfterEnter[key] = await label(page, BOXES[key]).inputValue();
          }
          assert.deepEqual(shownAfterEnter, {
            lbrRate: '35.56',
            lbrPrc: '0.00',
            ghtPrc: '0.00',
            bagWt: '1.2346',
          });
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          const row = await itemRow(ctx, 'IMIMG');
          assert.deepEqual(
            [row.name, row.lbrrate, row.lbr, row.ght, row.bag],
            ['E2E OVAL RING', 35.56, 0, 0, 1.235],
          );
          return {
            observation: `Enter showed ${JSON.stringify(shownAfterEnter)}; stored ${row.lbrrate}/${row.lbr}/${row.ght}/${row.bag}`,
            expected: shownAfterEnter,
            database: { row },
            downstream: { name: row.name },
          };
        }),
    ),
    C(
      'lookup.helps-and-question',
      'T04',
      'read-only',
      'tPrCode_KeyDown (:3081-3116) lists the products by name; tGrCode_KeyDown (:3397-3450) the groups with their type and trade type and fills the item code and name; tGrCode_Validating (:3452-3495) asks when that item exists: Yes clears the code and name, No clears the group',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedItem(ctx, 'INIMG', 'E2E EXISTING CHAIN', { pr: 'IN' });
          const { page } = await ctx.session();
          // The first question is answered No, the second Yes.
          const questions = answerQuestions(page, (index) => index === 1);
          await openScreen(page);
          const product = label(page, 'Pr Code');
          // Typed in lower case: the box shows E2E IN while the search went out for e2e in; the help must be the
          // answer for that text (IN alone), not the list fetched on focus (every product).
          await product.focus();
          await page.keyboard.type('e2e in');
          await page.waitForFunction(() => {
            const box = document.querySelector('[aria-label="Pr Code"]')?.parentElement;
            const codes = [...(box?.querySelectorAll('b') ?? [])].map((b) => b.textContent.trim());
            return codes.includes('IN') && !codes.includes('IM');
          });
          const productHelp = (await product.locator('xpath=..').locator('b').allInnerTexts()).map(
            (t) => t.trim(),
          );
          await product.press('Enter');
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Gr Code',
          );
          assert.equal(await product.inputValue(), 'IN');
          const group = label(page, 'Gr Code');
          // First answer No: the group, code and name are cleared and the cursor goes back to the group.
          await group.fill('IMG');
          await group.press('Enter');
          await page.waitForFunction(
            () =>
              document.activeElement?.getAttribute('aria-label') === 'Gr Code' &&
              document.querySelector('[aria-label="Gr Code"]')?.value === '',
          );
          assert.equal(await label(page, 'Item Code').inputValue(), '');
          // Then Yes: the group stays, the code and name are cleared for a new code.
          await group.fill('IMG');
          await group.press('Enter');
          await page.waitForFunction(() => document.activeElement?.id === 'item-code');
          const after = {
            group: await group.inputValue(),
            groupName: await label(page, 'Group Name').inputValue(),
            type: await label(page, 'Item Type').inputValue(),
            tag: await label(page, 'Tag Type').inputValue(),
            trade: await label(page, 'Trade Type').inputValue(),
            code: await label(page, 'Item Code').inputValue(),
            name: await label(page, 'Item Name').inputValue(),
          };
          assert.deepEqual(after, {
            group: 'IMG',
            groupName: 'E2E IM GOLD',
            type: 'G',
            tag: 'G',
            trade: 'GO',
            code: '',
            name: '',
          });
          const expectedQuestion =
            "This Item already Exist in  'E2E EXISTING CHAIN' Item Name...You Want to Creat New Item...";
          assert.deepEqual(questions, [expectedQuestion, expectedQuestion]);
          return {
            observation: `product help ${productHelp.join(',')}; No then Yes on the question; after Yes ${JSON.stringify(after)}`,
            expected: { after, questions },
          };
        }),
    ),
    C(
      'children.tag-value-update',
      'T05',
      'mutation',
      "btnTagValUpdate_Click (:3969-4015): after its question, the item's tags at the location take each non-zero box where their value is zero (the wastage only with a karigar touch), and KR_FINE = KR_NET_WT × (KR_TOUCH + KR_WEST_PRC) / 100 is recomputed for the year; other locations and items are untouched",
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedItem(ctx, 'IMIMG', 'E2E TAG RING');
          await seedItem(ctx, 'IMX', 'E2E OTHER RING');
          const { page } = await ctx.session();
          const year = (await (await page.request.get('/api/me')).json()).coYear;
          const tag = (no, item, lc, values) =>
            exec(
              ctx,
              `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","TAG_NO","IT_CODE","VCH_SRNO","LBR_PRC","KR_TOUCH","KR_WEST_PRC","KR_NET_WT","KR_FINE")
               VALUES ($1,'01',$2,$3,$4,$5,1,$6,$7,0,$8,0)`,
              lc,
              year,
              no,
              item,
              ...values,
            );
          await tag('E2EIM1', 'IMIMG', '01', [0, 0, 10]);
          await tag('E2EIM2', 'IMIMG', '01', [8, 91.6, 5]);
          await tag('E2EIM3', 'IMIMG', '02', [0, 0, 10]);
          await tag('E2EIM4', 'IMX', '01', [0, 0, 10]);
          const questions = answerQuestions(page, true);
          await openScreen(page);
          await openItem(page, 'IMIMG');
          await page.getByTestId('item-button-bar').dblclick({ position: { x: 4, y: 4 } });
          await page.waitForFunction(() => document.activeElement?.id === 'item-tag-lbrPrc');
          await page.keyboard.type('12');
          await page.keyboard.press('Enter');
          await page.keyboard.type('92');
          await page.keyboard.press('Enter');
          await page.keyboard.type('1.5');
          await page.keyboard.press('Enter');
          assert.equal(await focusedId(page), 'Tag Value Update');
          const [response] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'POST', `${API}/IMIMG/tag-values`)),
            page.keyboard.press('Enter'),
          ]);
          assert.equal(response.status(), 200, await response.text());
          await message(page, 'Item Tag Value Is Update.....');
          assert.deepEqual(questions, ['Are You Sure To Update This Item Tag With New Value... ?']);
          const tags = await ctx.rows(
            `SELECT "TAG_NO" t,"LBR_PRC"::float l,"KR_TOUCH"::float k,"KR_WEST_PRC"::float w,"KR_FINE"::float f
               FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO" LIKE 'E2EIM%' ORDER BY "TAG_NO"`,
          );
          await exec(ctx, `DELETE FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO" LIKE 'E2EIM%'`);
          assert.deepEqual(tags, [
            { t: 'E2EIM1', l: 12, k: 92, w: 1.5, f: 9.35 },
            { t: 'E2EIM2', l: 8, k: 91.6, w: 1.5, f: 4.655 },
            { t: 'E2EIM3', l: 0, k: 0, w: 0, f: 0 },
            { t: 'E2EIM4', l: 0, k: 0, w: 0, f: 0 },
          ]);
          return {
            observation: `${JSON.stringify(await response.json())}; tags ${tags.map((t) => `${t.t}:${t.f}`).join(' ')}`,
            expected: 'the zero values set at the location, the fine recomputed',
            database: { tags },
            downstream: { answer: await response.json() },
          };
        }),
    ),
    C(
      'required.refusals',
      'T06',
      'refusal',
      'Save (:3184-3224) refuses a blank product, group and item code with their texts in that order; leaving the code taken by another item and the name taken by another code (:3497-3629); the web refuses a blank name with the desktop\'s "Please Insert Item Name" (G231); nothing written',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedItem(ctx, 'IMIMG', 'E2E TAKEN RING');
          const before = await allItems(ctx);
          const { page, requests } = await ctx.session();
          await openScreen(page);
          await button(page, 'Save').click();
          await message(page, 'Product Code Is Null Please Create Item Again..');
          const product = label(page, 'Pr Code');
          await product.fill('IN');
          await product.press('Enter');
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Gr Code',
          );
          await button(page, 'Save').click();
          await message(page, 'Group Code Is Null Please Create Item Again..');
          await label(page, 'Gr Code').fill('IMG');
          await label(page, 'Gr Code').press('Enter');
          await page.waitForFunction(() => document.querySelector('#item-code')?.value === 'INIMG');
          await label(page, 'Item Code').fill('');
          await button(page, 'Save').click();
          await message(page, 'Item Code Is Null Please Create Item Again..');
          assert.equal(
            await focusedId(page),
            'Gr Code',
            'BtnSave_Click puts the cursor in the group (:3223)',
          );
          await label(page, 'Item Code').fill('IMIMG');
          await label(page, 'Item Name').focus();
          await message(
            page,
            "This Item Code already Exist in  'E2E TAKEN RING'  Item Name...Please Change It Code...",
          );
          await page.waitForFunction(() => document.activeElement?.id === 'item-code');
          await label(page, 'Item Code').fill('INIMG');
          await label(page, 'Item Name').fill('e2e taken ring');
          await label(page, 'Safe Name').focus();
          await message(
            page,
            "This Item Code already Exist in  'IMIMG'  Item Name...Please Change It Name...",
          );
          await label(page, 'Item Name').fill('');
          await button(page, 'Save').click();
          await message(page, 'Please Insert Item Name');
          assert.equal(requests.filter((r) => ['POST', 'PUT'].includes(r.method)).length, 0);
          assert.deepEqual(await allItems(ctx), before);
          return {
            observation:
              'every refusal shown with the desktop text, in the desktop order; nothing sent',
            expected: 'no ITEM_MAST row changed',
            database: { rows: before.length },
          };
        }),
    ),
    C(
      'create.footprint',
      'T07',
      'mutation',
      'A new item writes one ITEM_MAST row (:3225-3263) and no other table changes',
      async (ctx) =>
        withMasters(ctx, async () => {
          const counts = async () =>
            (
              await ctx.rows(
                `SELECT (SELECT count(*)::int FROM "ITEM_MAST" WHERE tenant_id=$1) i,
                        (SELECT count(*)::int FROM "PRODUCT_MAST" WHERE tenant_id=$1) p,
                        (SELECT count(*)::int FROM "GROUP_MAST" WHERE tenant_id=$1) g,
                        (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1) s,
                        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1) d`,
              )
            )[0];
          const before = await counts();
          const { page } = await ctx.session();
          await openScreen(page);
          await choose(page, 'IM', 'IMG');
          await page.waitForFunction(() => document.querySelector('#item-code')?.value === 'IMIMG');
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          const after = await counts();
          assert.deepEqual(after, { ...before, i: before.i + 1 });
          const list = await listed(page);
          assert.deepEqual(list, await dbList(ctx));
          return {
            observation: `ITEM_MAST ${before.i} → ${after.i}; nothing else changed`,
            expected: 'one row',
            database: { before, after },
            downstream: { listed: list.some(([c]) => c === 'IMIMG') },
          };
        }),
    ),
    C(
      'reopen.unchanged-save',
      'T08',
      'mutation',
      'DISPLAY_DATA then Save with nothing changed writes the same values; the web keeps MIN_STK and the averages (G231) and MAIN_USER stays the stored user (:2990)',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedItem(ctx, 'IMIMG', 'E2E REOPEN RING', { minstk: 5, avg: 91.6, lbr: 9 });
          const before = await allItems(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          await openItem(page, 'IMIMG');
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const after = await allItems(ctx);
          const row = await itemRow(ctx, 'IMIMG');
          assert.deepEqual([row.minstk, row.avg, row.main, row.lbr], [5, 91.6, 'DESKUSER', 9]);
          return {
            observation: `MIN_STK ${row.minstk}, AVG_TOUCH ${row.avg}, MAIN_USER ${row.main} after an unchanged save`,
            expected: { minstk: 5, avg: 91.6, main: 'DESKUSER' },
            database: { before: before.length, after: after.length, row },
            downstream: { status: response.status() },
          };
        }),
    ),
    C(
      'edit.boxes',
      'T09',
      'mutation',
      "An opened item saves its changed boxes in place; the product, group and code stay read-only (the desktop's tPrCode is read-only once opened, :3043)",
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedItem(ctx, 'IMIMG', 'E2E EDIT RING', { minstk: 5 });
          const { page } = await ctx.session();
          await openScreen(page);
          await openItem(page, 'IMIMG', 'enter');
          const readOnly = await page.evaluate(() => [
            document.querySelector('[aria-label="Pr Code"]')?.readOnly,
            document.querySelector('[aria-label="Gr Code"]')?.readOnly,
            document.querySelector('#item-code')?.readOnly,
          ]);
          assert.deepEqual(readOnly, [true, true, true]);
          await fill(page, { name: 'E2E EDIT RING 22K', lbrPrc: '14', unit: 'PCS', rateType: 'P' });
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const row = await itemRow(ctx, 'IMIMG');
          assert.deepEqual(
            [row.name, row.lbr, row.unit, row.rate, row.minstk, row.main],
            ['E2E EDIT RING 22K', 14, 'PCS', 'P', 5, 'DESKUSER'],
          );
          const list = await listed(page);
          assert.ok(list.some(([c, n]) => c === 'IMIMG' && n === 'E2E EDIT RING 22K'));
          return {
            observation: 'renamed, labour 14, unit PCS, Pcs Wise; MIN_STK and MAIN_USER kept',
            expected: { name: 'E2E EDIT RING 22K' },
            database: { row },
            downstream: { list: list.length },
          };
        }),
    ),
    C(
      'delete.lifecycle',
      'T10',
      'mutation',
      'BtnDelete_Click (:3302-3355): stock rows and a default code are refused before the question, a blank code says "Please Select Item For Delete."; No keeps the item; Yes deletes it with "Delete Success."',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedItem(ctx, 'IMIMG', 'E2E STOCK RING');
          await seedItem(ctx, 'OG', 'E2E OLD GOLD');
          await seedItem(ctx, 'ININ1', 'E2E FREE CHAIN', { pr: 'IN' });
          await exec(
            ctx,
            `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","IT_CODE","ITM_SIGN","ITM_GWT","ITM_NWT","TAG_NO")
             VALUES ($1,'01','01','2024-2025','OPN','00001','2024-04-01','IMIMG','+',5,5,'N')`,
          );
          const { page } = await ctx.session();
          let questions = answerQuestions(page, false);
          await openScreen(page);
          await button(page, 'Delete').click();
          await message(page, 'Please Select Item For Delete.');
          await openItem(page, 'IMIMG');
          await button(page, 'Delete').click();
          await message(page, "You Can't Delete Record This Item Use in Transaction....");
          await cancel(page);
          await openItem(page, 'OG');
          await button(page, 'Delete').click();
          await message(page, 'You Cant Delete Record This Item Code Is Default Code....');
          assert.deepEqual(questions, [], 'refused before the question');
          await cancel(page);
          await openItem(page, 'ININ1');
          await button(page, 'Delete').click();
          await page.waitForTimeout(300);
          assert.deepEqual(questions, [QUESTION]);
          assert.ok(await itemRow(ctx, 'ININ1'), 'No keeps it');
          questions = answerQuestions(page, true);
          const [removed] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'DELETE', `${API}/ININ1`)),
            button(page, 'Delete').click(),
          ]);
          assert.equal(removed.status(), 200, await removed.text());
          await message(page, 'Delete Success.');
          await page.waitForFunction(
            () => !document.querySelector('[data-testid="item-list"] tr[data-code="ININ1"]'),
          );
          assert.equal(await itemRow(ctx, 'ININ1'), undefined);
          assert.ok(await itemRow(ctx, 'IMIMG'));
          assert.ok(await itemRow(ctx, 'OG'));
          return {
            observation:
              'blank, stock and default refused without the question; No kept ININ1; Yes deleted it',
            expected: 'the desktop order and texts',
            database: { deleted: 'ININ1' },
            downstream: { list: (await listed(page)).length },
          };
        }),
    ),
    C(
      'rights.view-only',
      'T11',
      'refusal',
      'MS_ITEM_Load reads FRM_EDIT/FRM_DELETE/FRM_PRINT of the user\'s rights row (:2548-2560): Save of an opened item and Delete answer "You Have No Rights.....", Print "You Have No Print Rights....." (:3184-3190, :3311-3315, :3697-3705); a new item needs only the view right; the tag update needs the edit right on the web (G231)',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedItem(ctx, 'IMIMG', 'E2E RIGHTS RING');
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"='IMIMG'`,
            SECOND_TENANT,
          );
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME") VALUES ($1,'01','IMIMG','SENTINEL')`,
            SECOND_TENANT,
          );
          await exec(
            ctx,
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES ($1,'01','01',$2,'Master','Item','Y','N','N','N')`,
            USERS.clerk.user,
          );
          try {
            const { page, requests } = await ctx.session(as(USERS.clerk.user));
            answerQuestions(page, true);
            await openScreen(page);
            const opened = await openItem(page, 'IMIMG');
            await fill(page, { lbrPrc: '20' });
            await button(page, 'Save').click();
            await message(page, 'You Have No Rights.....');
            await button(page, 'Delete').click();
            await message(page, 'You Have No Rights.....');
            await button(page, 'Print').click();
            await message(page, 'You Have No Print Rights.....');
            assert.equal(requests.filter((r) => ['PUT', 'DELETE'].includes(r.method)).length, 0);
            const direct = [
              (
                await page.request.put(`/api${API}/IMIMG`, {
                  data: {
                    productCode: 'IM',
                    groupCode: 'IMG',
                    name: 'X',
                    expectedVersion: opened.version,
                  },
                })
              ).status(),
              (
                await page.request.delete(`/api${API}/IMIMG?expectedVersion=${opened.version}`)
              ).status(),
              (
                await page.request.post(`/api${API}/IMIMG/tag-values`, { data: { lbrPrc: '5' } })
              ).status(),
            ];
            assert.deepEqual(direct, [403, 403, 403]);
            await cancel(page);
            await choose(page, 'IN', 'IMG');
            await page.waitForFunction(
              () => document.querySelector('#item-code')?.value === 'INIMG',
            );
            const created = await save(page);
            assert.equal(created.status(), 201, await created.text());
            await saved(page);
            const rows = { IMIMG: await itemRow(ctx, 'IMIMG'), INIMG: await itemRow(ctx, 'INIMG') };
            assert.equal(rows.IMIMG.lbr, 0);
            assert.equal(rows.INIMG.main, USERS.clerk.user);
            const sentinel = await ctx.owner.$queryRawUnsafe(
              `SELECT "IT_NAME" name FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"='IMIMG'`,
              SECOND_TENANT,
            );
            assert.deepEqual(sentinel, [{ name: 'SENTINEL' }]);
            const printer = await ctx.session(as(USERS.printViewer.user));
            const refused = await openScreen(printer.page);
            assert.equal(refused.status(), 403);
            await message(printer.page, 'You Have No Rights.....');
            return {
              observation: `clerk refused on screen; direct ${direct.join('/')}; clerk created INIMG; e2eprint refused ${refused.status()}`,
              expected:
                'the desktop texts, 403s, a new item allowed, the sentinel tenant untouched',
              database: { rows, sentinel },
            };
          } finally {
            await exec(
              ctx,
              `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Item'`,
              USERS.clerk.user,
            );
            await ctx.owner.$executeRawUnsafe(
              `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"='IMIMG'`,
              SECOND_TENANT,
            );
          }
        }),
    ),
    C(
      'concurrency.two-operators',
      'T12',
      'mutation',
      'Two operators open one item: the first save wins and the second is refused with 409 (version token, G231) where the desktop lets the later save win; two new entries with one code: the second is refused with the code text under the company lock',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedItem(ctx, 'IMIMG', 'E2E RACE RING');
          const a = (await ctx.session()).page;
          const b = (await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#2`))).page;
          await openScreen(a);
          await openScreen(b);
          await openItem(a, 'IMIMG');
          await openItem(b, 'IMIMG');
          await fill(a, { lbrPrc: '11' });
          const first = await save(a);
          assert.equal(first.status(), 200, await first.text());
          await saved(a);
          await fill(b, { lbrPrc: '12' });
          const second = await save(b);
          assert.equal(second.status(), 409);
          await message(b, CONFLICT);
          assert.equal((await itemRow(ctx, 'IMIMG')).lbr, 11);
          await cancel(b);
          await choose(a, 'IN', 'IMG');
          await a.waitForFunction(() => document.querySelector('#item-code')?.value === 'INIMG');
          await choose(b, 'IN', 'IMG');
          await b.waitForFunction(() => document.querySelector('#item-code')?.value === 'INIMG');
          await fill(b, { name: 'E2E OTHER NAME' });
          assert.equal((await save(a)).status(), 201);
          await saved(a);
          const late = await save(b);
          assert.equal(late.status(), 400);
          await message(
            b,
            "This Item Code already Exist in  'E2E IN CHAIN IMG'  Item Name...Please Change It Code...",
          );
          const row = await itemRow(ctx, 'INIMG');
          assert.equal(row.name, 'E2E IN CHAIN IMG');
          return {
            observation: `edit race ${first.status()} then ${second.status()}; new-code race 201 then ${late.status()}`,
            expected: 'one result per race and a defined refusal',
            database: { row },
            downstream: { second: second.status(), late: late.status() },
          };
        }),
    ),
    C(
      'retry.replayed-save',
      'T13',
      'mutation',
      'A replayed edit carries a spent version and is refused (409); a replayed new item has the same code and name, so it rewrites the same row and no second row appears',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedItem(ctx, 'IMIMG', 'E2E RETRY RING');
          const { page } = await ctx.session();
          await openScreen(page);
          await openItem(page, 'IMIMG');
          await fill(page, { discPrc: '3' });
          const first = await save(page);
          assert.equal(first.status(), 200);
          await saved(page);
          const replayEdit = (await page.request.fetch(first.request())).status();
          assert.equal(replayEdit, 409);
          await choose(page, 'IN', 'IMG');
          await page.waitForFunction(() => document.querySelector('#item-code')?.value === 'INIMG');
          const created = await save(page);
          assert.equal(created.status(), 201);
          await saved(page);
          const replayCreate = (await page.request.fetch(created.request())).status();
          assert.equal(replayCreate, 201);
          const count = await ctx.rows(
            `SELECT count(*)::int n FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"='INIMG'`,
          );
          assert.equal(count[0].n, 1);
          return {
            observation: `replayed edit ${replayEdit}; replayed create ${replayCreate}; one INIMG row`,
            expected: 'the edit replay refused, one row',
            database: { count: count[0].n, disc: (await itemRow(ctx, 'IMIMG')).disc },
            downstream: { replayEdit, replayCreate },
          };
        }),
    ),
    C(
      'rollback.update-fault',
      'T14',
      'mutation',
      'BtnSave_Click deletes the row before it inserts the new one (:3225-3263); a fault in the write must leave the item as it was (the desktop would leave the item deleted)',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedItem(ctx, 'IMIMG', 'E2E FAULT RING', { minstk: 5 });
          const before = await allItems(ctx);
          await ctx.owner.$executeRawUnsafe(
            `CREATE OR REPLACE FUNCTION e2e_item_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
             BEGIN
               IF NEW."HSN_CODE" = 'E2EFAULT' THEN RAISE EXCEPTION 'e2e fault in the item write'; END IF;
               RETURN NEW;
             END $f$`,
          );
          await ctx.owner.$executeRawUnsafe(
            `CREATE TRIGGER e2e_item_fault BEFORE INSERT OR UPDATE ON "ITEM_MAST" FOR EACH ROW EXECUTE FUNCTION e2e_item_fault()`,
          );
          try {
            const { page } = await ctx.session();
            await openScreen(page);
            await openItem(page, 'IMIMG');
            await fill(page, { name: 'E2E FAULT CHANGED', hsn: 'e2efault' });
            const failed = await save(page);
            assert.equal(failed.status(), 400, await failed.text());
            assert.deepEqual(await allItems(ctx), before);
            return {
              observation: `the save answered ${failed.status()}; every ITEM_MAST row is as before`,
              expected: 'no change',
              database: { rows: before.length },
              downstream: { status: failed.status() },
            };
          } finally {
            await ctx.owner.$executeRawUnsafe(
              `DROP TRIGGER IF EXISTS e2e_item_fault ON "ITEM_MAST"`,
            );
            await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_item_fault()`);
          }
        }),
    ),
    C(
      'history.company-wide',
      'T15',
      'mutation',
      'ITEM_MAST has no year: MS_ITEM reads and writes by CO_CODE and IT_CODE (:2548-2784, :3225), so an item saved in this year is listed in the historic year too',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session(
            as(USERS.admin.user, `${USERS.admin.user}#item-history`),
          );
          await openScreen(page);
          await choose(page, 'IM', 'IMG');
          await page.waitForFunction(() => document.querySelector('#item-code')?.value === 'IMIMG');
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          await page.goto('/select');
          await page.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
          await page.getByRole('combobox', { name: 'FINANCIAL YEAR' }).selectOption('2024-2025');
          await button(page, 'Open').click();
          await page.waitForURL('**/dashboard');
          await openScreen(page);
          const list = await listed(page);
          assert.ok(list.some(([c]) => c === 'IMIMG'));
          return {
            observation: `the historic year lists IMIMG among ${list.length} items`,
            expected: 'the same items in every year',
            database: { row: await itemRow(ctx, 'IMIMG') },
            downstream: { listed: true },
          };
        }),
    ),
    C(
      'output.print-right-only',
      'T16',
      'output',
      'The Print button runs BtnPrint_Click_1 (:3697-3705, wired at :990): it checks the print right and prints nothing; the ItemMast report call in BtnPrint_Click (:3357-3364) is not wired to the button',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedItem(ctx, 'IMIMG', 'E2E PRINT RING');
          const { page, requests } = await ctx.session();
          await openScreen(page);
          await openItem(page, 'IMIMG');
          // The product help's search on focus is debounced (LookupPicker, 180 ms) and may still go out after the item opened.
          await page.waitForTimeout(400);
          const sent = requests.length;
          await button(page, 'Print').click();
          await page.waitForTimeout(400);
          const after = requests.slice(sent).map((r) => `${r.method} ${r.path}`);
          assert.deepEqual(after, []);
          assert.equal(await page.locator('.msg').count(), 0);
          assert.equal(await label(page, 'Item Code').inputValue(), 'IMIMG');
          return {
            observation: 'Print with the right sent nothing and showed nothing',
            expected: 'nothing',
            output: { requests: after },
          };
        }),
    ),
    C(
      'keyboard.desktop-keys',
      'T17',
      'mutation',
      "MS_ITEM_KeyPress (:3066-3079), the boxes' Enter keys (:3081-3116, :3397-3450, :3519-3754), the list keys (:3366-3395), Esc (:3141-3155) and the &Save mnemonic",
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const step = async (text, expectFocus) => {
            if (text) await page.keyboard.type(text);
            await page.keyboard.press('Enter');
            await page.waitForFunction(
              (want) =>
                (document.activeElement?.getAttribute('aria-label') ||
                  document.activeElement?.id ||
                  document.activeElement?.textContent?.trim()) === want,
              expectFocus,
            );
          };
          await step('im', 'Gr Code');
          await step('img', 'item-code');
          assert.equal(await label(page, 'Item Code').inputValue(), 'IMIMG');
          await step('', 'Tag Type');
          await step('', 'item-name');
          await step('', 'item-safe');
          await step('', 'item-hsn');
          await step('7113', 'item-unit');
          await step('gm', 'item-rateType');
          await step('', 'Labour Rate');
          await step('350', 'Labour %');
          await step('12.5', 'Ght %');
          await step('', 'Conversion %');
          await step('', 'Discount %');
          await step('', 'Item Rate');
          await step('6123.45', 'Oth itm Rate');
          await step('', 'item-othRateType');
          await step('', 'Bag Weight');
          await step('0.5', 'Save');
          assert.equal(await label(page, 'Bag Weight').inputValue(), '0.5000');
          const created = await save(page, () => page.keyboard.press('Enter'));
          assert.equal(created.status(), 201, await created.text());
          await saved(page);
          await page.getByTestId('item-list').locator('tr[data-code="IMIMG"]').focus();
          await page.keyboard.press('F1');
          assert.equal(await focusedId(page), 'Search record');
          await page.keyboard.type('e2e im');
          const filtered = await listed(page);
          assert.ok(
            filtered.length >= 1 &&
              filtered.every(([c, n]) => n.startsWith('E2E IM') || c.startsWith('E2E IM')),
          );
          await page.getByTestId('item-list').locator('tr[data-code="IMIMG"]').focus();
          const [opened] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/IMIMG`)),
            page.keyboard.press('Enter'),
          ]);
          assert.equal(opened.status(), 200);
          await page.waitForFunction(() => document.activeElement?.id === 'item-name');
          await label(page, 'Discount %').fill('1');
          const altSaved = await save(page, () => page.keyboard.press('Alt+s'));
          assert.equal(altSaved.status(), 200, await altSaved.text());
          await saved(page);
          await page.keyboard.press('Escape');
          await page.waitForURL((url) => !url.pathname.startsWith('/masters/items'));
          const row = await itemRow(ctx, 'IMIMG');
          assert.deepEqual(
            [row.name, row.hsn, row.unit, row.lbrrate, row.lbr, row.itemrate, row.bag, row.disc],
            ['E2E IM RING IMG', '7113', 'GM', 350, 12.5, 6123.45, 0.5, 1],
          );
          return {
            observation:
              'keyed in with Enter through every box, saved with Enter, reopened from the list with Enter and saved with Alt+S; Esc left',
            expected: 'every desktop key as listed in the source',
            database: { row },
            downstream: { leftTo: new URL(page.url()).pathname },
          };
        }),
    ),
    C(
      'keyboard.esc-with-focus-on-the-page',
      'T17',
      'read-only',
      "MS_ITEM sets KeyPreview (:2538) and subscribes MS_ITEM_KeyDown (:1838), so the form sees Esc wherever the focus is; Esc closes the form (:3147-3149). A browser has a state the desktop form never has: focus on no control, after a click on the page background. Esc must close Item Master there too, and a key aimed at the header Company box stays the header's (GB-02, the G239 pattern)",
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        const left = await escLeavesWithNoFocus(page, {
          heading: 'Item Master',
          path: '/masters/items',
        });
        return {
          observation: `Esc with the focus on the page body left Item Master for ${left.leftTo}`,
          expected: { focusOnBody: true, leaves: '/masters/items' },
          downstream: left,
        };
      },
    ),
    C(
      'journey.item-on-a-sale',
      'T18',
      'mutation',
      "An item saved here is sold on the Sales Invoice: the line is credited to its group's SALE_AC (sales.ts, G169) and the invoice prints the item's HSN code (invoice.ts reads ITEM_MAST.HSN_CODE first); the sale is then deleted",
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await choose(page, 'IM', 'IMG');
          await page.waitForFunction(() => document.querySelector('#item-code')?.value === 'IMIMG');
          await fill(page, { hsn: '711311' });
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          await exec(
            ctx,
            `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","IT_CODE","ITM_SIGN","ITM_GWT","ITM_NWT","TAG_NO")
             VALUES ($1,'01','01','2024-2025','OPN','00001','2024-04-01','IMIMG','+',100,100,'N')`,
          );
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
          const line = (column) =>
            page.locator(`[data-grid-row="0"][data-grid-column="${column}"] input`).first();
          await line(0).fill('IMIMG');
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
            // 10 g × 6,123.45 + 10 g × 237.50 = 63,609.50 credited to group IMG's sales account (SALES).
            const lines = await ctx.rows(
              `SELECT "IT_CODE" it FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2`,
              vchNo,
            );
            assert.deepEqual(lines, [{ it: 'IMIMG' }]);
            const legs = await ctx.rows(
              `SELECT "AC_CODE" ac,"CR_AMT"::float cr FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2 AND "AC_CODE"='SALES'`,
              vchNo,
            );
            assert.deepEqual(legs, [{ ac: 'SALES', cr: 63609.5 }]);
            const me = await (await page.request.get('/api/me')).json();
            const invoice = await page.request.get(
              `/api/sales/invoice?coBook=SL&coYear=${encodeURIComponent(me.coYear)}&vchNo=${vchNo}&format=html&copy=O`,
            );
            assert.equal(invoice.status(), 200);
            assert.ok(
              (await invoice.text()).includes('711311'),
              "the invoice prints the item's HSN code",
            );
            return {
              observation: `sale ${vchNo} of IMIMG credited 63609.50 to SALES; the invoice prints HSN 711311`,
              expected: { leg: 63609.5, hsn: '711311' },
              database: { lines, legs },
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
