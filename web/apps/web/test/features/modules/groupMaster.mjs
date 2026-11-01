import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, PARTIES, USERS } from '../fixtures/catalogue.mjs';
import { SECOND_TENANT } from '../harness.mjs';

/**
 * Feature: Master → Group (desktop MS_GROUP, web /masters/groups).
 *
 * Desktop rules used for the expected values (MS_GROUP.cs unless noted):
 * - The menu button 'Group' opens MS_GROUP directly (MDI_FORM.cs:7630-7636). The list is every GROUP_MAST row of the
 *   company ordered by GR_CODE (CLEAR_DATA :1732); a new entry has blank boxes, Item Type Gold, SEARCH RECORD and the
 *   cursor in the code. The Item Type combo is Gold, Silver, Diamond, Real Stone, Emitation, Other, Platinum (:1642-1648).
 * - Save (:1825-1919): an opened group needs the edit right ("You Have No Rights....."); a blank sales or purchase
 *   account says "Please Select Sales and Purchase Account And Try" and a blank code or name "Enter Group Detail"; the
 *   row gets Val of each number box, GR_TYPE = the first letter of the item type, RATE_DISPLAY Y/N and MAIN_USER (the
 *   user for a new group, the stored one for an opened group, :1725/:1802); every item of the group takes the trade
 *   type, item type and HSN code (:1887); then "Data Are Saved." and a new entry.
 * - Leaving the code refuses a code another group has (:2006-2026); leaving the name, a name another code has
 *   (:2028-2048); Enter on a blank name says "Please Insert Group Name ..." (:2091-2108); typed keys are upper-cased and
 *   the apostrophe refused (:1975-1988).
 * - Keys: Enter on the touches, melting and wastage shows Val as 0.00 (:2151-2193); Enter on the trade type takes a
 *   BAL_GR code, else opens its help (:2271-2304); Enter on Sales Ac takes a group-25 code, else opens the help of group
 *   25 without 00099 (:2195-2231); Purchase Ac the same over group 30 (:2233-2269); Enter on Rate Tax % goes to Save
 *   (:2328-2336, tab index 12); Esc leaves (:2073-2081); in the list Enter and a double click open a group with the
 *   cursor in the name and F1 goes to the search box (:2110-2139).
 * - Delete (:1921-1954): "Please Select Group For Delete.", "You Cant Delete Record This Group Code Use in Item
 *   Master...." before the question, "Are You Sure To Delete This Group now?", "Delete Success.".
 * - A sale credits each line to its item group's SALE_AC (`sales.ts`, G169) and the invoice prints the item's HSN code.
 * Web rules that differ on purpose (gap G227): the row is updated in place in one transaction with the item update (the
 * desktop's delete and blank insert wipes GR_RATE and the day-close fields); version tokens; unknown accounts and a
 * trade type over 2 characters refused; Print lists the groups on screen.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `group-master.${id}`,
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

const API = '/masters/group-master';
const SAVED = 'Data Are Saved.';
const CONFLICT =
  'This group was changed by someone else after you opened it. Open it again before saving or deleting.';
/** The catalogue's groups (F02), as the list shows them. */
const CATALOGUE = [
  ['E1', 'E2E GOLD'],
  ['E2', 'E2E SILVER'],
];
/** Sales accounts (group 25), purchase accounts (group 30) and a sundry debtor, as the desktop chart holds them. */
const ACCOUNTS = [
  ['GMSAL', 'GM SALES GOLD A/C', '25'],
  ['GMSAS', 'GM SALES SILVER A/C', '25'],
  ['00099', 'GM SALES SUSPENSE', '25'],
  ['GMPUR', 'GM PURCHASE GOLD A/C', '30'],
  ['GMPUS', 'GM PURCHASE SILVER A/C', '30'],
];
const TRADES = [
  ['GO', 'GM GOLD ORNAMENT'],
  ['SL', 'GM SILVER ORNAMENT'],
];
/** Codes the cases create; the catalogue's E1 and E2 are never changed. */
const CASE_CODES = ['GM1', 'GM2', 'GM3', 'GMT'];
const CASE_ITEMS = ['GMI01', 'GMI02', 'GMI03'];
const TYPES = ['Gold', 'Silver', 'Diamond', 'Real Stone', 'Emitation', 'Other', 'Platinum'];

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

const groupRow = async (ctx, code) =>
  (
    await ctx.rows(
      `SELECT "GR_CODE" code,"GR_NAME" name,"GR_TYPE" type,"TRAD_TYPE" trade,"GR_TOUCH" touch,"GR_PURC_TOUCH" purc,
              "MELTING_PRC" melting,"WEST_PRC" west,"TAX_PRC"::float tax,"SALE_AC" sale,"PURC_AC" purcac,
              "HSN_CODE" hsn,"RATE_DISPLAY" display,"MAIN_USER" main,"GR_RATE"::float rate,"AVG_TOUCH" avg,
              row_id::text rid
         FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "GR_CODE"=$2 ORDER BY row_id`,
      code,
    )
  ).map(({ rid, ...row }) => ({ ...row, rid }));
const allGroups = (ctx) =>
  ctx.rows(
    `SELECT to_jsonb(g) AS r FROM "GROUP_MAST" g WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "GR_CODE",row_id`,
  );
/** CLEAR_DATA's list: every GROUP_MAST row of the company by code (:1732); other modules add groups in a full run. */
const dbList = async (ctx) =>
  (
    await ctx.rows(
      `SELECT "GR_CODE" code,"GR_NAME" name FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "GR_CODE",row_id`,
    )
  ).map((r) => [String(r.code ?? '').trim(), String(r.name ?? '').trim()]);
const includes = (list, row) => list.some(([c, n]) => c === row[0] && n === row[1]);
const itemRows = (ctx) =>
  ctx.rows(
    `SELECT "IT_CODE" code,"GR_CODE" grp,"IT_TYPE" type,"TRAD_TYPE" trade,"HSN_CODE" hsn FROM "ITEM_MAST"
      WHERE tenant_id=$1 AND ("IT_CODE" = ANY($2::text[]) OR "IT_CODE" IN ('GLD22','SLV92')) ORDER BY "IT_CODE"`,
    CASE_ITEMS,
  );

async function cleanCase(ctx) {
  await exec(
    ctx,
    `DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "IT_CODE" = ANY($2::text[])`,
    CASE_ITEMS,
  );
  await exec(
    ctx,
    `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE" = ANY($2::text[])`,
    CASE_ITEMS,
  );
  await exec(
    ctx,
    `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE" = ANY($2::text[])`,
    CASE_CODES,
  );
}
/** Insert a group as the desktop writes it, for a case that opens an existing group. */
async function seedGroup(ctx, code, name, extra = {}) {
  await exec(
    ctx,
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE","TRAD_TYPE","GR_TOUCH","GR_PURC_TOUCH",
                              "MELTING_PRC","WEST_PRC","TAX_PRC","SALE_AC","PURC_AC","HSN_CODE","RATE_DISPLAY","MAIN_USER","GR_RATE","AVG_TOUCH")
     VALUES ($1,'01',$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,$13,$14,$15,$16,$17)`,
    code,
    name,
    extra.type ?? 'G',
    extra.trade ?? 'GO',
    extra.touch ?? 91.6,
    extra.purc ?? 92,
    extra.melting ?? 0,
    extra.west ?? 1.5,
    extra.tax ?? 3,
    extra.sale ?? 'GMSAL',
    extra.purcac ?? 'GMPUR',
    extra.hsn ?? '7113',
    extra.display ?? 'N',
    extra.main ?? 'DESKUSER',
    extra.rate ?? null,
    extra.avg ?? null,
  );
}
async function seedItem(ctx, code, group, extra = {}) {
  await exec(
    ctx,
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","TRAD_TYPE","HSN_CODE")
     VALUES ($1,'01',$2,$3,$4,$5,$6,$7)`,
    code,
    extra.name ?? `GM ITEM ${code}`,
    extra.type ?? 'G',
    group,
    extra.trade ?? 'GO',
    extra.hsn ?? '7113',
  );
}
async function withMasters(ctx, run) {
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
  await exec(ctx, `DELETE FROM "BAL_GR" WHERE tenant_id=$1 AND "TRAD_NAME" LIKE 'GM %'`);
  for (const [code, name] of TRADES)
    await exec(
      ctx,
      `INSERT INTO "BAL_GR"(tenant_id,"CO_CODE","TRAD_TYPE","TRAD_NAME") VALUES ($1,'01',$2,$3)`,
      code,
      name,
    );
  await cleanCase(ctx);
  try {
    return await run();
  } finally {
    await cleanCase(ctx);
    await exec(ctx, `DELETE FROM "BAL_GR" WHERE tenant_id=$1 AND "TRAD_NAME" LIKE 'GM %'`);
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
    page.goto('/masters/groups'),
  ]);
  await page.getByRole('heading', { name: 'Item Group Master', exact: true }).waitFor();
  if (response.status() === 200)
    await page.waitForFunction(() => document.activeElement?.id === 'group-code');
  return response;
}
const listed = (page) =>
  page
    .getByTestId('group-list')
    .locator('tr')
    .evaluateAll((rows) =>
      rows.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
    );
async function openGroup(page, code, how = 'enter') {
  const row = page.getByTestId('group-list').locator(`tr[data-code="${code}"]`);
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `${API}/${code}`)),
    how === 'enter' ? row.press('Enter') : row.dblclick(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.waitForFunction((c) => {
    const box = document.querySelector('#group-code');
    return box?.value === c && box.readOnly && document.activeElement?.id === 'group-name';
  }, code);
  return response.json();
}
const shownFields = async (page) => ({
  code: await label(page, 'Gr Code').inputValue(),
  name: await label(page, 'Gr Name').inputValue(),
  type: await label(page, 'Item Type').inputValue(),
  trade: await label(page, 'Trade Type').inputValue(),
  touch: await label(page, 'Gr Rate Touch').inputValue(),
  purc: await label(page, 'Purc Touch').inputValue(),
  melting: await label(page, 'Melting %').inputValue(),
  west: await label(page, 'West %').inputValue(),
  sale: await label(page, 'Sales Ac').inputValue(),
  saleName: await label(page, 'Sales Account Name').inputValue(),
  purcac: await label(page, 'Purchase Ac').inputValue(),
  purcName: await label(page, 'Purchase Account Name').inputValue(),
  hsn: await label(page, 'Hsn Code').inputValue(),
  tax: await label(page, 'Rate Tax %').inputValue(),
  display: await label(page, 'Rate Display In Main Screen').isChecked(),
  codeReadOnly: await label(page, 'Gr Code').evaluate((el) => el.readOnly),
});
/** Fill the boxes without keys. */
async function fillFields(page, values) {
  const boxes = {
    code: 'Gr Code',
    name: 'Gr Name',
    trade: 'Trade Type',
    touch: 'Gr Rate Touch',
    purc: 'Purc Touch',
    melting: 'Melting %',
    west: 'West %',
    sale: 'Sales Ac',
    purcac: 'Purchase Ac',
    hsn: 'Hsn Code',
    tax: 'Rate Tax %',
  };
  for (const [key, value] of Object.entries(values)) {
    if (key === 'type') await label(page, 'Item Type').selectOption(value);
    else if (key === 'display') await label(page, 'Rate Display In Main Screen').setChecked(value);
    else await label(page, boxes[key]).fill(value);
  }
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
/** Cancel: CLEAR_DATA reads the list again and puts the cursor in an empty code box. */
async function cancel(page) {
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', API)),
    button(page, 'Cancel').click(),
  ]);
  await page.waitForFunction(
    () =>
      document.activeElement?.id === 'group-code' &&
      document.querySelector('#group-code')?.value === '',
  );
}
/** A saved entry: "Data Are Saved." and a new entry with the cursor in the code (CLEAR_DATA). */
async function saved(page) {
  await message(page, SAVED);
  await page.waitForFunction(
    () =>
      document.activeElement?.id === 'group-code' &&
      !document.querySelector('#group-code')?.readOnly &&
      document.querySelector('#group-code')?.value === '',
  );
}
const GOLD = {
  code: 'GM1',
  name: 'GM GOLD ORNAMENT',
  type: 'G',
  trade: 'GO',
  touch: '91.6',
  purc: '92',
  melting: '0.5',
  west: '1.5',
  sale: 'GMSAL',
  purcac: 'GMPUR',
  hsn: '7113',
  tax: '3',
};

export const groupMaster = {
  feature: 'group-master',
  title: 'Master → Group (MS_GROUP)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/masters/groups/page.tsx',
    'web/apps/api/src/modules/masters/groupMaster.ts',
    'web/apps/api/src/routes/groupMaster.ts',
    'web/apps/web/test/features/modules/groupMaster.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'MDI_FORM.cs:7630-7636 opens MS_GROUP; CLEAR_DATA (:1713-1736) blank boxes, Item Type Gold, SEARCH RECORD, cursor in the code; the list is every group by code (:1732); the combo (:1642-1648); the form spec layout, MaxLength and tab order',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const first = await shownFields(page);
          assert.deepEqual(first, {
            code: '',
            name: '',
            type: 'G',
            trade: '',
            touch: '',
            purc: '',
            melting: '',
            west: '',
            sale: '',
            saleName: '',
            purcac: '',
            purcName: '',
            hsn: '',
            tax: '',
            display: false,
            codeReadOnly: false,
          });
          const types = await label(page, 'Item Type').locator('option').allInnerTexts();
          assert.deepEqual(types, TYPES);
          const lengths = {};
          for (const box of ['Gr Code', 'Gr Name', 'Gr Rate Touch', 'Hsn Code', 'Rate Tax %'])
            lengths[box] = await label(page, box).getAttribute('maxlength');
          assert.deepEqual(lengths, {
            'Gr Code': '3',
            'Gr Name': '40',
            'Gr Rate Touch': '5',
            'Hsn Code': '10',
            'Rate Tax %': '5',
          });
          assert.equal(await label(page, 'Search record').inputValue(), 'SEARCH RECORD');
          const list = await listed(page);
          assert.deepEqual(list, await dbList(ctx));
          for (const row of CATALOGUE) assert.ok(includes(list, row), `${row} listed`);
          const order = await page.evaluate(() =>
            [
              ...document.querySelectorAll(
                'main input:not([tabindex="-1"]),main select,main button,[data-testid="group-list"] tr',
              ),
            ]
              .filter((el) => !el.closest('nav'))
              .map(
                (el) =>
                  el.id ||
                  el.getAttribute('aria-label') ||
                  (el.tagName === 'TR'
                    ? 'list'
                    : el.type === 'checkbox'
                      ? 'rate-display'
                      : el.textContent.trim()),
              ),
          );
          const expectedOrder = [
            'group-code',
            'group-name',
            'group-type',
            'Trade Type',
            'group-rateTouch',
            'group-purcTouch',
            'group-melting',
            'group-west',
            'Sales Ac',
            'Purchase Ac',
            'group-hsn',
            'group-tax',
            'Save',
            'Print',
            'Cancel',
            'Delete',
            'Exit',
            'Search record',
            ...list.map(() => 'list'),
            'rate-display',
          ];
          assert.deepEqual(order.slice(0, expectedOrder.length), expectedOrder);
          const drawn = [];
          for (const name of ['Save', 'Print', 'Cancel', 'Delete', 'Exit'])
            drawn.push([name, (await button(page, name).boundingBox()).x]);
          assert.deepEqual(
            drawn.sort((a, b) => a[1] - b[1]).map(([n]) => n),
            ['Print', 'Save', 'Cancel', 'Delete', 'Exit'],
          );
          const listBox = await page.getByTestId('group-list').boundingBox();
          const codeBox = await label(page, 'Gr Code').boundingBox();
          const tradeBox = await label(page, 'Trade Type').boundingBox();
          const typeBox = await label(page, 'Item Type').boundingBox();
          assert.ok(listBox.x < codeBox.x, 'the list is drawn left of the boxes');
          assert.ok(
            Math.abs(tradeBox.y - typeBox.y) < 8 && tradeBox.x > typeBox.x,
            'the trade type sits right of the item type',
          );
          return {
            observation: `blank entry with Gold, cursor in the code, ${list.length} groups by code, tab order ${order.slice(0, 13).join(' > ')}`,
            expected: { list: CATALOGUE, types: TYPES, lengths },
          };
        }),
    ),
    C(
      'field.every-field',
      'T02',
      'mutation',
      'BtnSave_Click (:1862-1885) stores GR_CODE, GR_NAME, TRAD_TYPE, GR_TYPE, GR_TOUCH, GR_PURC_TOUCH, MELTING_PRC, WEST_PRC, TAX_PRC, SALE_AC, PURC_AC, HSN_CODE, RATE_DISPLAY and MAIN_USER; DISPLAY_DATA (:1738-1808) shows them again with the account names',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await fillFields(page, { ...GOLD, type: 'P', display: true });
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          const [row] = await groupRow(ctx, 'GM1');
          const { rid, ...stored } = row;
          assert.deepEqual(stored, {
            code: 'GM1',
            name: 'GM GOLD ORNAMENT',
            type: 'P',
            trade: 'GO',
            touch: 91.6,
            purc: 92,
            melting: 0.5,
            west: 1.5,
            tax: 3,
            sale: 'GMSAL',
            purcac: 'GMPUR',
            hsn: '7113',
            display: 'Y',
            main: USERS.admin.user,
            rate: null,
            avg: null,
          });
          await openGroup(page, 'GM1');
          const shown = await shownFields(page);
          assert.deepEqual(shown, {
            code: 'GM1',
            name: 'GM GOLD ORNAMENT',
            type: 'P',
            trade: 'GO',
            touch: '91.60',
            purc: '92.00',
            melting: '0.50',
            west: '1.50',
            sale: 'GMSAL',
            saleName: 'GM SALES GOLD A/C',
            purcac: 'GMPUR',
            purcName: 'GM PURCHASE GOLD A/C',
            hsn: '7113',
            tax: '3.00',
            display: true,
            codeReadOnly: true,
          });
          return {
            observation: 'every box stored and shown again, Platinum as P, the box ticked as Y',
            expected: { stored, shown },
            database: { row },
            downstream: { reopened: shown },
          };
        }),
    ),
    C(
      'formula.val-and-format',
      'T03',
      'mutation',
      'Conversion.Val of each number box on save (:1869-1873): leading digits, a blank or text box is 0; Enter on the touches, melting and wastage shows Strings.Format(Val, "0.00") (:2151-2193); Enter on Rate Tax % does not format (:2328-2336); MS_GROUP_KeyPress upper-cases and drops the apostrophe (:1975-1988)',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await fillFields(page, {
            ...GOLD,
            name: "gm o'ld gold",
            trade: 'go',
            touch: '91.6x',
            purc: '',
            melting: 'abc',
            west: '1.255',
            tax: '3%',
          });
          assert.equal(await label(page, 'Gr Name').inputValue(), 'GM OLD GOLD');
          await label(page, 'Gr Rate Touch').press('Enter');
          assert.equal(await label(page, 'Gr Rate Touch').inputValue(), '91.60');
          await label(page, 'Purc Touch').press('Enter');
          assert.equal(await label(page, 'Purc Touch').inputValue(), '0.00');
          await label(page, 'Melting %').press('Enter');
          assert.equal(await label(page, 'Melting %').inputValue(), '0.00');
          await label(page, 'West %').press('Enter');
          // Strings.Format(1.255, "0.00"): the stored double 1.255 rounds half away from zero.
          assert.equal(await label(page, 'West %').inputValue(), '1.26');
          await label(page, 'Rate Tax %').press('Enter');
          assert.equal(await label(page, 'Rate Tax %').inputValue(), '3%');
          await label(page, 'West %').fill('1.255');
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          const [row] = await groupRow(ctx, 'GM1');
          assert.deepEqual(
            {
              name: row.name,
              trade: row.trade,
              touch: row.touch,
              purc: row.purc,
              melting: row.melting,
              west: row.west,
              tax: row.tax,
            },
            {
              name: 'GM OLD GOLD',
              trade: 'GO',
              touch: 91.6,
              purc: 0,
              melting: 0,
              west: 1.255,
              tax: 3,
            },
          );
          return {
            observation: `Val stored ${row.touch}/${row.purc}/${row.melting}/${row.west}/${row.tax}`,
            expected: 'Val of each box; 0.00 shown on Enter; the tax box unformatted',
            database: { row },
            downstream: { shownWest: '1.26' },
          };
        }),
    ),
    C(
      'lookup.helps',
      'T04',
      'read-only',
      'tSalesAc_KeyDown (:2195-2231): a group-25 code is taken, else the help of group 25 by name without 00099 opens; tPurcAc_KeyDown (:2233-2269) over group 30; tGTradTyp_KeyDown (:2271-2304) over BAL_GR by name; a row chosen over a typed exact code stands (LookupPicker)',
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const sale = label(page, 'Sales Ac');
          await sale.focus();
          await sale.fill('GM');
          const saleHelp = sale.locator('xpath=..');
          await saleHelp.getByText('GMSAS', { exact: true }).waitFor();
          const saleCodes = (await saleHelp.locator('b').allInnerTexts()).map((t) => t.trim());
          assert.deepEqual(saleCodes, ['GMSAL', 'GMSAS'], 'group 25 by name, without 00099');
          // A purchase account typed in Sales Ac is not taken: the help for the text opens instead.
          await sale.fill('GMPUR');
          await sale.press('Enter');
          await page.waitForTimeout(500);
          assert.equal(await focusedId(page), 'Sales Ac');
          assert.equal(await label(page, 'Sales Account Name').inputValue(), '');
          // 00099 is not listed but is taken when typed (:2204).
          await sale.fill('00099');
          await sale.press('Enter');
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Purchase Ac',
          );
          assert.equal(await label(page, 'Sales Account Name').inputValue(), 'GM SALES SUSPENSE');
          const purc = label(page, 'Purchase Ac');
          await purc.fill('GM');
          const purcHelp = purc.locator('xpath=..');
          await purcHelp.getByText('GMPUS', { exact: true }).waitFor();
          const purcCodes = (await purcHelp.locator('b').allInnerTexts()).map((t) => t.trim());
          assert.deepEqual(purcCodes, ['GMPUR', 'GMPUS']);
          await purc.press('ArrowDown');
          await purc.press('Enter');
          await page.waitForFunction(() => document.activeElement?.id === 'group-hsn');
          assert.equal(await purc.inputValue(), 'GMPUS');
          assert.equal(
            await label(page, 'Purchase Account Name').inputValue(),
            'GM PURCHASE SILVER A/C',
          );
          const trade = label(page, 'Trade Type');
          await trade.fill('GM');
          const tradeHelp = trade.locator('xpath=..');
          await tradeHelp.getByText('SL', { exact: true }).waitFor();
          const tradeCodes = (await tradeHelp.locator('b').allInnerTexts()).map((t) => t.trim());
          assert.deepEqual(tradeCodes, ['GO', 'SL'], 'BAL_GR by name');
          await trade.press('ArrowDown');
          await trade.press('Enter');
          await page.waitForFunction(() => document.activeElement?.id === 'group-rateTouch');
          assert.equal(await trade.inputValue(), 'SL');
          return {
            observation: `sales help ${saleCodes.join(',')}; purchase help ${purcCodes.join(',')}; trade help ${tradeCodes.join(',')}; 00099 taken typed; GMPUR refused in Sales Ac`,
            expected: { saleCodes: ['GMSAL', 'GMSAS'], purcCodes: ['GMPUR', 'GMPUS'] },
          };
        }),
    ),
    C(
      'children.items-take-the-group',
      'T05',
      'mutation',
      "BtnSave_Click's UPDATE ITEM_MAST SET TRAD_TYPE, IT_TYPE = the item type's letter, HSN_CODE WHERE GR_CODE (:1887): every item of the group and no other",
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedGroup(ctx, 'GM1', 'GM GOLD ORNAMENT');
          await seedItem(ctx, 'GMI01', 'GM1');
          await seedItem(ctx, 'GMI02', 'GM1', { trade: '', hsn: '' });
          await seedGroup(ctx, 'GM2', 'GM SILVER ORNAMENT', { type: 'S', trade: 'SL' });
          await seedItem(ctx, 'GMI03', 'GM2', { type: 'S', trade: 'SL', hsn: '7114' });
          const before = await itemRows(ctx);
          const { page } = await ctx.session();
          await openScreen(page);
          await openGroup(page, 'GM1');
          await fillFields(page, { type: 'D', trade: 'SL', hsn: '7102' });
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          assert.deepEqual(await response.json(), { code: 'GM1', items: 2 });
          await saved(page);
          const after = await itemRows(ctx);
          const untouched = (rows) => rows.filter((r) => !['GMI01', 'GMI02'].includes(r.code));
          assert.deepEqual(untouched(after), untouched(before));
          assert.deepEqual(
            after.filter((r) => r.grp === 'GM1'),
            [
              { code: 'GMI01', grp: 'GM1', type: 'D', trade: 'SL', hsn: '7102' },
              { code: 'GMI02', grp: 'GM1', type: 'D', trade: 'SL', hsn: '7102' },
            ],
          );
          return {
            observation:
              'both items of GM1 took D / SL / 7102; GM2 and the catalogue items kept theirs',
            expected: 'the item update of the group only',
            database: { before, after },
            downstream: { items: 2 },
          };
        }),
    ),
    C(
      'required.refusals',
      'T06',
      'refusal',
      'Save (:1849-1861) refuses a blank sales or purchase account first, then a blank code or name; Enter on a blank name (:2091-2108); leaving the code or the name taken by another group (:2006-2048); the web refuses an unknown account and a trade type over 2 (G227); nothing is written',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedGroup(ctx, 'GM2', 'GM SILVER ORNAMENT', { type: 'S' });
          const before = await allGroups(ctx);
          const { page, requests } = await ctx.session();
          await openScreen(page);
          await button(page, 'Save').click();
          await message(page, 'Please Select Sales and Purchase Account And Try');
          assert.equal(await focusedId(page), 'Sales Ac');
          await fillFields(page, { sale: 'GMSAL', purcac: 'GMPUR' });
          await button(page, 'Save').click();
          await message(page, 'Enter Group Detail');
          await label(page, 'Gr Name').focus();
          await page.keyboard.press('Enter');
          await message(page, 'Please Insert Group Name ...');
          assert.equal(await focusedId(page), 'group-name');
          await label(page, 'Gr Code').fill('GM2');
          await label(page, 'Gr Name').focus();
          await message(
            page,
            "This Group Code already Exist in  'GM SILVER ORNAMENT'  Group Name... Please Change Group Code...",
          );
          await page.waitForFunction(() => document.activeElement?.id === 'group-code');
          await label(page, 'Gr Code').fill('GM1');
          await label(page, 'Gr Name').fill('gm silver ornament');
          await label(page, 'Hsn Code').focus();
          await message(
            page,
            "This Group Name already Exist in  'GM2'  Group Code... Please Change Group Name...",
          );
          assert.equal(requests.filter((r) => ['POST', 'PUT'].includes(r.method)).length, 0);
          await label(page, 'Gr Name').fill('GM NEW GROUP');
          await fillFields(page, { sale: 'NOSUCH' });
          let response = await save(page);
          assert.equal(response.status(), 400);
          await message(page, 'sales account NOSUCH is not in the account master');
          await fillFields(page, { sale: 'GMSAL', trade: 'GOLD' });
          response = await save(page);
          assert.equal(response.status(), 400);
          await message(
            page,
            'trade type must be at most 2 characters (the items of the group keep it in ITEM_MAST.TRAD_TYPE)',
          );
          const after = await allGroups(ctx);
          assert.deepEqual(after, before);
          return {
            observation:
              'every refusal shown with the desktop text, in the desktop order; nothing written',
            expected: 'no GROUP_MAST row changed',
            database: { before: before.length, after: after.length },
          };
        }),
    ),
    C(
      'create.footprint',
      'T07',
      'mutation',
      'A new group writes one GROUP_MAST row (:1866-1885) and updates only its own items (none yet); no other table changes',
      async (ctx) =>
        withMasters(ctx, async () => {
          const counts = async () =>
            (
              await ctx.rows(
                `SELECT (SELECT count(*)::int FROM "GROUP_MAST" WHERE tenant_id=$1) g,
                        (SELECT count(*)::int FROM "ITEM_MAST" WHERE tenant_id=$1) i,
                        (SELECT count(*)::int FROM "AC_MAST" WHERE tenant_id=$1) a,
                        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1) d,
                        (SELECT md5(string_agg(to_jsonb(t)::text,'' ORDER BY "IT_CODE")) FROM "ITEM_MAST" t WHERE tenant_id=$1) ih`,
              )
            )[0];
          const before = await counts();
          const { page } = await ctx.session();
          await openScreen(page);
          await fillFields(page, GOLD);
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          const after = await counts();
          assert.deepEqual(after, { ...before, g: before.g + 1 });
          const list = await listed(page);
          assert.deepEqual(list, await dbList(ctx));
          assert.ok(includes(list, ['GM1', 'GM GOLD ORNAMENT']));
          return {
            observation: `GROUP_MAST ${before.g} → ${after.g}; items, accounts and postings unchanged`,
            expected: 'one row',
            database: { before, after },
            downstream: { list },
          };
        }),
    ),
    C(
      'reopen.unchanged-save',
      'T08',
      'mutation',
      'DISPLAY_DATA then Save with nothing changed writes the same values back (:1862-1885); the web keeps the row, its GR_RATE and the day-close fields (G227) and MAIN_USER stays the stored user (:1802)',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedGroup(ctx, 'GM1', 'GM GOLD ORNAMENT', { rate: 7250, avg: 90.5, display: 'Y' });
          const [before] = await groupRow(ctx, 'GM1');
          const { page } = await ctx.session();
          await openScreen(page);
          await openGroup(page, 'GM1');
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const [after] = await groupRow(ctx, 'GM1');
          assert.deepEqual(after, before);
          return {
            observation: `row ${after.rid} unchanged, GR_RATE ${after.rate}, MAIN_USER ${after.main}`,
            expected: 'the same row and values',
            database: { before, after },
            downstream: { status: response.status() },
          };
        }),
    ),
    C(
      'edit.keeps-the-day-rate',
      'T09',
      'mutation',
      "An edit of the name and touches keeps GR_RATE (the Daily Rate screen's, dailyRate.ts) and the average fields; the desktop's delete and blank insert (:1862-1886) would write NULL into them (G227); MAIN_USER stays the stored user",
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedGroup(ctx, 'GM1', 'GM GOLD ORNAMENT', { rate: 7250, avg: 90.5 });
          const { page } = await ctx.session();
          await openScreen(page);
          await openGroup(page, 'GM1');
          await fillFields(page, { name: 'GM GOLD 22K', touch: '91.75', purcac: 'GMPUS' });
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const [row] = await groupRow(ctx, 'GM1');
          assert.deepEqual(
            [row.name, row.touch, row.purcac, row.rate, row.avg, row.main],
            ['GM GOLD 22K', 91.75, 'GMPUS', 7250, 90.5, 'DESKUSER'],
          );
          const list = await listed(page);
          assert.ok(list.some(([c, n]) => c === 'GM1' && n === 'GM GOLD 22K'));
          return {
            observation: `edited GM1; GR_RATE ${row.rate} and AVG_TOUCH ${row.avg} kept`,
            expected: { rate: 7250, avg: 90.5, main: 'DESKUSER' },
            database: { row },
            downstream: { list },
          };
        }),
    ),
    C(
      'delete.lifecycle',
      'T10',
      'mutation',
      'BtnDelete_Click (:1921-1954): "Please Select Group For Delete."; a group an item uses is refused before the question; "Are You Sure To Delete This Group now?" then the row deleted and "Delete Success."; the list read again',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedGroup(ctx, 'GM1', 'GM GOLD ORNAMENT');
          await seedGroup(ctx, 'GM2', 'GM SILVER ORNAMENT', { type: 'S' });
          await seedItem(ctx, 'GMI03', 'GM2', { type: 'S' });
          const { page } = await ctx.session();
          // The harness accepts every dialog; this case counts the questions and records their text.
          let asked = 0;
          const questions = [];
          page.removeAllListeners('dialog');
          page.on('dialog', (dialog) => {
            asked++;
            questions.push(dialog.message());
            void dialog.accept();
          });
          await openScreen(page);
          await button(page, 'Delete').click();
          await message(page, 'Please Select Group For Delete.');
          await openGroup(page, 'GM2');
          await button(page, 'Delete').click();
          await message(page, 'You Cant Delete Record This Group Code Use in Item Master....');
          assert.equal(asked, 0, 'refused before the question');
          // A typed code another group has is refused on leave, and the desktop's cancelled Validating suppresses the
          // Delete click (:2006-2026); the name box refuses that group's name the same way, so only an opened group
          // reaches the item check.
          await cancel(page);
          await label(page, 'Gr Code').fill('GM2');
          await button(page, 'Delete').click();
          await message(
            page,
            "This Group Code already Exist in  'GM SILVER ORNAMENT'  Group Name... Please Change Group Code...",
          );
          assert.equal(asked, 0);
          await cancel(page);
          await openGroup(page, 'GM1');
          const [removed] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'DELETE', `${API}/GM1`)),
            button(page, 'Delete').click(),
          ]);
          assert.equal(removed.status(), 200, await removed.text());
          await message(page, 'Delete Success.');
          assert.deepEqual(questions, ['Are You Sure To Delete This Group now?']);
          await page.waitForFunction(
            () => !document.querySelector('[data-testid="group-list"] tr[data-code="GM1"]'),
          );
          const rows = { GM1: await groupRow(ctx, 'GM1'), GM2: await groupRow(ctx, 'GM2') };
          assert.deepEqual(rows.GM1, []);
          assert.equal(rows.GM2.length, 1);
          const list = await listed(page);
          assert.deepEqual(list, await dbList(ctx));
          assert.ok(
            includes(list, ['GM2', 'GM SILVER ORNAMENT']) && !list.some(([c]) => c === 'GM1'),
          );
          return {
            observation:
              'blank and used refused without the question; GM1 deleted after one question',
            expected: 'the desktop texts and order',
            database: { rows },
            downstream: { list },
          };
        }),
    ),
    C(
      'rights.view-only',
      'T11',
      'refusal',
      'MS_GROUP_Load reads FRM_EDIT/FRM_DELETE/FRM_PRINT of the user\'s rights row (:1487-1495): Save of an opened group, Delete and Print answer "You Have No Rights....." / "You Have No Print Rights....." (:1813-1817, :1844-1848, :1929-1933); a new group needs only the view right',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedGroup(ctx, 'GM1', 'GM GOLD ORNAMENT');
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE"='GM1'`,
            SECOND_TENANT,
          );
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC") VALUES ($1,'01','GM1','SENTINEL','X','Y')`,
            SECOND_TENANT,
          );
          await exec(
            ctx,
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES ($1,'01','01',$2,'Master','Group','Y','N','N','N')`,
            USERS.clerk.user,
          );
          try {
            const { page, requests } = await ctx.session(as(USERS.clerk.user));
            await openScreen(page);
            const opened = await openGroup(page, 'GM1');
            await label(page, 'Gr Name').fill('GM CHANGED');
            await button(page, 'Save').click();
            await message(page, 'You Have No Rights.....');
            await button(page, 'Delete').click();
            await message(page, 'You Have No Rights.....');
            await button(page, 'Print').click();
            await message(page, 'You Have No Print Rights.....');
            assert.equal(requests.filter((r) => ['PUT', 'DELETE'].includes(r.method)).length, 0);
            const direct = [
              (
                await page.request.put(`/api${API}/GM1`, {
                  data: {
                    ...GOLD,
                    name: 'X',
                    saleAc: 'GMSAL',
                    purcAc: 'GMPUR',
                    expectedVersion: opened.version,
                  },
                })
              ).status(),
              (
                await page.request.delete(`/api${API}/GM1?expectedVersion=${opened.version}`)
              ).status(),
              (await page.request.get(`/api${API}/print`)).status(),
            ];
            assert.deepEqual(direct, [403, 403, 403]);
            await cancel(page);
            await fillFields(page, { ...GOLD, code: 'GM3', name: 'GM CLERK GROUP' });
            const created = await save(page);
            assert.equal(created.status(), 201, await created.text());
            await saved(page);
            const rows = { GM1: await groupRow(ctx, 'GM1'), GM3: await groupRow(ctx, 'GM3') };
            assert.equal(rows.GM1[0].name, 'GM GOLD ORNAMENT');
            assert.deepEqual(
              rows.GM3.map((r) => [r.name, r.main]),
              [['GM CLERK GROUP', USERS.clerk.user]],
            );
            const sentinel = await ctx.owner.$queryRawUnsafe(
              `SELECT "GR_NAME" name FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE"='GM1'`,
              SECOND_TENANT,
            );
            assert.deepEqual(sentinel, [{ name: 'SENTINEL' }]);
            const printer = await ctx.session(as(USERS.printViewer.user));
            const refused = await openScreen(printer.page);
            assert.equal(refused.status(), 403);
            await message(printer.page, 'You Have No Rights.....');
            return {
              observation: `clerk refused on screen; direct ${direct.join('/')}; clerk created GM3; e2eprint refused ${refused.status()}`,
              expected:
                'the desktop texts, 403s, a new group allowed, the sentinel tenant untouched',
              database: { rows, sentinel },
            };
          } finally {
            await exec(
              ctx,
              `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Group'`,
              USERS.clerk.user,
            );
            await ctx.owner.$executeRawUnsafe(
              `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE"='GM1'`,
              SECOND_TENANT,
            );
          }
        }),
    ),
    C(
      'concurrency.two-operators',
      'T12',
      'mutation',
      'Two operators open one group: the first save wins and the second is refused with 409 (version token, G227) where the desktop lets the later save win; two new entries with one code: the second is refused with the code text under the company lock',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedGroup(ctx, 'GM1', 'GM GOLD ORNAMENT');
          const a = (await ctx.session()).page;
          const b = (await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#2`))).page;
          await openScreen(a);
          await openScreen(b);
          await openGroup(a, 'GM1');
          await openGroup(b, 'GM1');
          await label(a, 'Gr Name').fill('GM GOLD A');
          const first = await save(a);
          assert.equal(first.status(), 200, await first.text());
          await saved(a);
          await label(b, 'Gr Rate Touch').fill('75');
          const second = await save(b);
          assert.equal(second.status(), 409);
          await message(b, CONFLICT);
          let [row] = await groupRow(ctx, 'GM1');
          assert.deepEqual([row.name, row.touch], ['GM GOLD A', 91.6]);
          await cancel(b);
          await fillFields(a, { ...GOLD, code: 'GM3', name: 'GM NEW A' });
          await b.waitForFunction(() => document.querySelector('#group-code')?.value === '');
          await fillFields(b, { ...GOLD, code: 'GM3', name: 'GM NEW B' });
          assert.equal((await save(a)).status(), 201);
          await saved(a);
          const late = await save(b);
          assert.equal(late.status(), 400);
          await message(
            b,
            "This Group Code already Exist in  'GM NEW A'  Group Name... Please Change Group Code...",
          );
          const rows = await groupRow(ctx, 'GM3');
          assert.deepEqual(
            rows.map((r) => r.name),
            ['GM NEW A'],
          );
          [row] = await groupRow(ctx, 'GM1');
          return {
            observation: `edit race ${first.status()} then ${second.status()}; new-code race 201 then ${late.status()}`,
            expected: 'one result per race and a defined refusal',
            database: { GM1: row, GM3: rows },
            downstream: { second: second.status(), late: late.status() },
          };
        }),
    ),
    C(
      'retry.replayed-save',
      'T13',
      'mutation',
      "A replayed edit carries a spent version and is refused (409); a replayed new group has the same code and name, so it rewrites the same row (BtnSave_Click's code check passes on the same name) and no second row appears",
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedGroup(ctx, 'GM1', 'GM GOLD ORNAMENT');
          const { page } = await ctx.session();
          await openScreen(page);
          await openGroup(page, 'GM1');
          await label(page, 'West %').fill('2.25');
          const first = await save(page);
          assert.equal(first.status(), 200, await first.text());
          await saved(page);
          const replayEdit = (await page.request.fetch(first.request())).status();
          assert.equal(replayEdit, 409);
          await fillFields(page, { ...GOLD, code: 'GM3', name: 'GM RETRY GROUP' });
          const created = await save(page);
          assert.equal(created.status(), 201, await created.text());
          await saved(page);
          const replayCreate = (await page.request.fetch(created.request())).status();
          assert.equal(replayCreate, 201);
          const rows = { GM1: await groupRow(ctx, 'GM1'), GM3: await groupRow(ctx, 'GM3') };
          assert.equal(rows.GM1[0].west, 2.25);
          assert.equal(rows.GM3.length, 1, 'one row after the replay');
          return {
            observation: `replayed edit ${replayEdit}; replayed create ${replayCreate}; GM3 has ${rows.GM3.length} row`,
            expected: 'the edit replay refused, one row for GM3',
            database: { rows },
            downstream: { replayEdit, replayCreate },
          };
        }),
    ),
    C(
      'rollback.item-update-fault',
      'T14',
      'mutation',
      'BtnSave_Click writes the group (:1862-1886) and then updates its items (:1887) without a transaction; a fault on the item update must leave the group as it was (the desktop would keep the new group row and say "Error Found")',
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedGroup(ctx, 'GM1', 'GM GOLD ORNAMENT', { rate: 7250 });
          await seedItem(ctx, 'GMI01', 'GM1');
          const before = { groups: await allGroups(ctx), items: await itemRows(ctx) };
          await ctx.owner.$executeRawUnsafe(
            `CREATE OR REPLACE FUNCTION e2e_group_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
             BEGIN
               IF NEW."HSN_CODE" = 'E2EFAULT' THEN RAISE EXCEPTION 'e2e fault after the group write'; END IF;
               RETURN NEW;
             END $f$`,
          );
          await ctx.owner.$executeRawUnsafe(
            `CREATE TRIGGER e2e_group_fault BEFORE UPDATE ON "ITEM_MAST" FOR EACH ROW EXECUTE FUNCTION e2e_group_fault()`,
          );
          try {
            const { page } = await ctx.session();
            await openScreen(page);
            await openGroup(page, 'GM1');
            await fillFields(page, { name: 'GM FAULT NAME', hsn: 'E2EFAULT' });
            const failed = await save(page);
            assert.equal(failed.status(), 400, await failed.text());
            const after = { groups: await allGroups(ctx), items: await itemRows(ctx) };
            assert.deepEqual(after, before, 'the group write was rolled back with the item update');
            return {
              observation: `the save answered ${failed.status()}; the group and its item are as before`,
              expected: 'no change',
              database: { before, after },
              downstream: { status: failed.status() },
            };
          } finally {
            await ctx.owner.$executeRawUnsafe(
              `DROP TRIGGER IF EXISTS e2e_group_fault ON "ITEM_MAST"`,
            );
            await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_group_fault()`);
          }
        }),
    ),
    C(
      'history.company-wide',
      'T15',
      'mutation',
      'GROUP_MAST has no year: MS_GROUP reads and writes by CO_CODE and GR_CODE (:1732, :1862), so a group saved in this year is the group of the historic year too; an account renamed after the save is shown under its new name (:1781-1791)',
      async (ctx) =>
        withMasters(ctx, async () => {
          // Its own login: opening another year moves the server session, which the other cases' saved login shares.
          const { page } = await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#group-history`));
          await openScreen(page);
          await fillFields(page, GOLD);
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          await exec(
            ctx,
            `UPDATE "AC_MAST" SET "AC_NAME"='GM SALES RENAMED' WHERE tenant_id=$1 AND "AC_CODE"='GMSAL'`,
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
          assert.deepEqual(list, await dbList(ctx));
          assert.ok(includes(list, ['GM1', 'GM GOLD ORNAMENT']));
          await openGroup(page, 'GM1');
          const shown = await shownFields(page);
          assert.equal(shown.saleName, 'GM SALES RENAMED');
          return {
            observation: `the historic year lists ${list.length} groups with GM1; the account shows as "${shown.saleName}"`,
            expected: 'the same groups in every year; the account read by code',
            database: { rows: await groupRow(ctx, 'GM1') },
            downstream: { historicYearList: list, shown },
          };
        }),
    ),
    C(
      'output.print',
      'T16',
      'output',
      "BtnPrint_Click (:1810-1823) prints the company's groups (GroupMast, {GROUP_MAST.CO_CODE}); the report layout is not in the repository, so the web lists every group's boxes on screen by code (G227)",
      async (ctx) =>
        withMasters(ctx, async () => {
          await seedGroup(ctx, 'GM1', 'GM GOLD ORNAMENT', { type: 'R', trade: 'GO', hsn: '7113' });
          const { page } = await ctx.session();
          await openScreen(page);
          const [response] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/print`)),
            button(page, 'Print').click(),
          ]);
          assert.equal(response.status(), 200);
          const sheet = page.getByTestId('group-print');
          await sheet.waitFor();
          const headers = (await sheet.locator('thead th').allInnerTexts()).map((t) => t.trim());
          const body = await sheet
            .locator('tbody tr')
            .evaluateAll((rows) =>
              rows.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
            );
          assert.deepEqual(headers, [
            'Code',
            'Name',
            'Type',
            'Trade',
            'Rate Touch',
            'Purc Touch',
            'Melting %',
            'West %',
            'Sales Ac',
            'Purchase Ac',
            'Hsn Code',
            'Tax %',
          ]);
          assert.deepEqual(
            body.map((r) => r[0]),
            (await dbList(ctx)).map(([c]) => c),
            'every group of the company by code',
          );
          assert.deepEqual(
            body.find((r) => r[0] === 'GM1'),
            [
              'GM1',
              'GM GOLD ORNAMENT',
              'Real Stone',
              'GO',
              '91.60',
              '92.00',
              '0.00',
              '1.50',
              'GMSAL',
              'GMPUR',
              '7113',
              '3.00',
            ],
          );
          return {
            observation: `printed ${body.length} groups by code`,
            expected: { headers, gm1: body.find((r) => r[0] === 'GM1') },
            output: { headers, rows: body },
          };
        }),
    ),
    C(
      'keyboard.desktop-keys',
      'T17',
      'mutation',
      "MS_GROUP_KeyPress (:1975-1988), the boxes' Enter keys (:1990-2004, :2091-2108, :2141-2336), the list keys (:2110-2139), MS_GROUP_KeyDown Esc (:2073-2081) and the &Save mnemonic",
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const step = async (text, expectFocus) => {
            if (text) await page.keyboard.type(text);
            await page.keyboard.press('Enter');
            await page.waitForFunction(
              (want) =>
                (document.activeElement?.id ||
                  document.activeElement?.getAttribute('aria-label') ||
                  document.activeElement?.textContent?.trim()) === want,
              expectFocus,
            );
          };
          await step('gm1', 'group-name');
          await step("gm si'lver", 'group-type');
          assert.equal(await label(page, 'Gr Name').inputValue(), 'GM SILVER');
          // The combo's own keys are the browser's; the value is chosen and Enter moves on (cboItemTyp_KeyDown).
          await label(page, 'Item Type').selectOption('S');
          await step('', 'Trade Type');
          await step('sl', 'group-rateTouch');
          await step('70', 'group-purcTouch');
          await step('72.5', 'group-melting');
          await step('', 'group-west');
          await step('1.5', 'Sales Ac');
          assert.deepEqual(
            [
              await label(page, 'Gr Rate Touch').inputValue(),
              await label(page, 'Purc Touch').inputValue(),
              await label(page, 'Melting %').inputValue(),
              await label(page, 'West %').inputValue(),
            ],
            ['70.00', '72.50', '0.00', '1.50'],
          );
          await page.keyboard.type('silver');
          await page.waitForResponse(
            (r) => path(r) === `/api${API}/accounts` && /q=silver/i.test(r.url()),
          );
          await page.keyboard.press('Enter');
          await label(page, 'Sales Ac')
            .locator('xpath=..')
            .getByText('GMSAS', { exact: true })
            .waitFor();
          await step('', 'Purchase Ac');
          assert.equal(await label(page, 'Sales Ac').inputValue(), 'GMSAS');
          await page.keyboard.type('GMPUS');
          await page.waitForResponse(
            (r) => path(r) === `/api${API}/accounts` && r.url().includes('q=GMPUS'),
          );
          await step('', 'group-hsn');
          await step('7114', 'group-tax');
          await step('3', 'Save');
          assert.equal(await label(page, 'Rate Tax %').inputValue(), '3');
          const created = await save(page, () => page.keyboard.press('Enter'));
          assert.equal(created.status(), 201, await created.text());
          await saved(page);
          // F1 from the code box goes to the search box; typing filters by name; Backspace in the list shortens it.
          await page.keyboard.press('F1');
          assert.equal(await focusedId(page), 'Search record');
          await page.keyboard.type('gm');
          assert.deepEqual(await listed(page), [['GM1', 'GM SILVER']]);
          await page.getByTestId('group-list').locator('tr[data-code="GM1"]').focus();
          await page.keyboard.press('Backspace');
          await page.waitForFunction(
            () => document.querySelector('[aria-label="Search record"]')?.value === 'G',
          );
          const [opened] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/GM1`)),
            page.getByTestId('group-list').locator('tr[data-code="GM1"]').press('Enter'),
          ]);
          assert.equal(opened.status(), 200);
          await page.waitForFunction(() => document.activeElement?.id === 'group-name');
          await label(page, 'Hsn Code').fill('711419');
          const altSaved = await save(page, () => page.keyboard.press('Alt+s'));
          assert.equal(altSaved.status(), 200, await altSaved.text());
          await saved(page);
          await label(page, 'Gr Name').focus();
          await page.keyboard.press('Escape');
          await page.waitForURL((url) => !url.pathname.startsWith('/masters/groups'));
          const [row] = await groupRow(ctx, 'GM1');
          const { rid, ...stored } = row;
          assert.deepEqual(stored, {
            code: 'GM1',
            name: 'GM SILVER',
            type: 'S',
            trade: 'SL',
            touch: 70,
            purc: 72.5,
            melting: 0,
            west: 1.5,
            tax: 3,
            sale: 'GMSAS',
            purcac: 'GMPUS',
            hsn: '711419',
            display: 'N',
            main: USERS.admin.user,
            rate: null,
            avg: null,
          });
          return {
            observation: `the group was keyed in with Enter through every box, saved with Enter, reopened from the list and saved with Alt+S; Esc left for ${new URL(page.url()).pathname}`,
            expected: 'every desktop key as listed in the source',
            database: { row },
            downstream: { leftTo: new URL(page.url()).pathname },
          };
        }),
    ),
    C(
      'journey.group-on-a-sale',
      'T18',
      'mutation',
      "A sale of an item of the new group credits the line to the group's SALE_AC (sales.ts, G169) and its invoice prints the HSN code the group's save gave the item (:1887; invoice.ts reads ITEM_MAST.HSN_CODE); deleting the sale, the item and the group leaves no row behind",
      async (ctx) =>
        withMasters(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await fillFields(page, { ...GOLD, code: 'GMT', name: 'GM JOURNEY GOLD', hsn: '7113' });
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          await seedItem(ctx, 'GMI01', 'GMT', { type: 'X', trade: '', hsn: '0000' });
          await exec(
            ctx,
            `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","IT_CODE","ITM_SIGN","ITM_GWT","ITM_NWT","TAG_NO")
             VALUES ($1,'01','01','2024-2025','OPN','00001','2024-04-01','GMI01','+',100,100,'N')`,
          );
          // The group's save sets the item's type, trade type and HSN code (:1887).
          await openGroup(page, 'GMT');
          await fillFields(page, { hsn: '711319' });
          const edited = await save(page);
          assert.equal(edited.status(), 200, await edited.text());
          assert.deepEqual(await edited.json(), { code: 'GMT', items: 1 });
          await saved(page);
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
          await line(0).fill('GMI01');
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
            // 10 g × 6,123.45 + 10 g × 237.50 making = 63,609.50 credited to the group's sales account.
            const legs = await ctx.rows(
              `SELECT "AC_CODE" ac,"CR_AMT"::float cr FROM "AC_DATA"
                WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2 AND "AC_CODE"='GMSAL'`,
              vchNo,
            );
            assert.deepEqual(legs, [{ ac: 'GMSAL', cr: 63609.5 }]);
            const me = await (await page.request.get('/api/me')).json();
            const invoice = await page.request.get(
              `/api/sales/invoice?coBook=SL&coYear=${encodeURIComponent(me.coYear)}&vchNo=${vchNo}&format=html&copy=O`,
            );
            assert.equal(invoice.status(), 200);
            const html = await invoice.text();
            assert.ok(html.includes('711319'), 'the invoice prints the HSN code from the group');
            assert.ok(!html.includes('>0000<'), 'not the HSN the item had before');
            return {
              observation: `sale ${vchNo} credited 63609.50 to GMSAL; the invoice prints HSN 711319`,
              expected: { leg: 63609.5, hsn: '711319' },
              database: { legs, item: await itemRows(ctx) },
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
