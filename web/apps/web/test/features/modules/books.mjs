import assert from 'node:assert/strict';
import { readFile } from 'node:fs/promises';
import { FIXTURE_MANIFEST, ITEMS, PARTIES, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Company → Books (desktop MS_BOOK, web /masters/books). Case ids and expectations are the frozen case list
 * orchestration/work/WP-21/cases.md (T01 to T18); the database-layer cases of that list are proved by
 * web/apps/api/test/booksMaster.db.test.ts and booksPosting.routes.db.test.ts and are not repeated here.
 *
 * Desktop rules used (MS_BOOK.cs unless noted):
 * - MDI_FORM.cs:7443-7448 opens MS_BOOK directly, titled "Book Master" (:1423); CLEAR_DATA (:2434-2466) blanks the
 *   boxes, sets Yes / All / Inword / Free and a blank family (:2099-2112, :2450), empties the grid Sr / Account Desc /
 *   AcCode / AcName (:2154-2163) and puts the cursor in the code. The list is Code / Name / Trfr by code (:2418-2424,
 *   :2461). The Transaction Name combo is the location's distinct MAIN_BOOK, alphabetically, after a blank (:2119-2128).
 * - The family Enter builds the grid from BOOK_IDTL without SR_NO 0 and, for a new book, takes the direction of the
 *   first row (:2933-2948); the templates are the MS_UPDATE.cs inserts (decision D1, table in cases.md).
 * - Save (:2579-2685): edit right in edit mode, reserved 218/888/999, blank short name, blank code or name, then
 *   "Data Are Saved."; the code/name uniqueness texts (:2778, :2800); KeyPress upper-cases every box but Book Name
 *   and swallows the apostrophe (:2752-2763). Delete (:2687-2726): rights, blank code, AC_DATA by company and book,
 *   MAIN_STOCK by location, the question, "Delete Success.". Print (:2570-2577): only the rights text.
 * - Keys: F1 to the search box (:2992-2994), Esc closes (:2849-2851), Enter walks the boxes (:2917, :2970, :3037,
 *   :3058, :2978-2982) and the grid (:2280-2366); Alt mnemonics (:1623-1676). An opened book locks its code, mobile
 *   entry, direction and invoice type (:2526, :2564-2566).
 * Web rules on purpose (G252): Ctrl+O and the A/E reset are not ported (D6); a book with vouchers keeps its family
 * (D4, plain web text); blank slots allowed (D5); the CSV export behind the Print right is a web addition (D7).
 * The catalogue company is web-provisioned (CASH, SALES, ...), so each case seeds the desktop template accounts
 * (00001 ...) and the marker accounts M1 to M5 (90001 to 90005) it needs, and removes what it added.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `books.${id}`,
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
const blocked = (id, group, source, reason) => ({
  ...C(id, group, 'read-only', source, async () => ({})),
  blocked: reason,
});
const notApplicable = (id, group, source, reason) => ({
  ...C(id, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});

const API = '/masters/books-master';
const ROUTE = '/masters/books';
const SAVED = 'Data Are Saved.';
const NO_RIGHTS = 'You Have No Rights.....';
const NO_PRINT_RIGHTS = 'You Have No Print Rights.....';
const RESERVED = 'This Is a Reserve Code You Cant Use It...';
const SHORT_REQUIRED = 'Please Insert Book Short Name';
const DETAIL_REQUIRED = 'Error Found : Please Enter Book Detail First...';
const NAME_FIRST = 'Error Found : Please Enter Book Name First...';
const SELECT_FOR_DELETE = 'Please Select Product For Delete.';
const DELETE_CONFIRM = 'Are You Sure To Delete This Book now?';
const DELETED = 'Delete Success.';
const USED_IN_ACCOUNTS = 'You Cant Delete Record This Book Code Use in Account Transection....';
const USED_IN_STOCK = 'You Cant Delete Record This Book Code Use in Stock Transection....';
const FAMILY_LOCKED = 'This book already has vouchers, so its Transaction Name cannot be changed.';
const codeTaken = (name) =>
  `This Book Code already Exist in  '${name}'  Book Name... Please Change Book Code...`;
const nameTaken = (code) =>
  `This Book Name already Exist in  '${code}'  Book Code... Please Change Book Name...`;

/** The desktop template accounts (cases.md, Test data) and the marker accounts M1 to M5. */
const ACCOUNTS = [
  ['00001', 'CASH ON HAND', '01'],
  ['00002', 'BANK OF TEST', '02'],
  ['00003', 'SALES GOLD A/C', '25'],
  ['00004', 'SALES SILVER A/C', '25'],
  ['00008', 'PURCHASE A/C', '30'],
  ['00020', 'ORDER ADVANCE', '04'],
  ['00041', 'LABOUR INCOM. A/C', '23'],
  ['00042', 'KASAR AVAK A/C', '31'],
  ['00056', 'LABOUR EXP A/C', '22'],
  ['00057', 'KASAR JAVK A/C', '31'],
  ['00076', 'DISCOUNT A/C', '22'],
  ['90001', 'BK MARKER ONE', '01'],
  ['90002', 'BK MARKER TWO', '01'],
  ['90003', 'BK MARKER THREE', '31'],
  ['90004', 'BK MARKER FOUR', '02'],
  ['90005', 'BK MARKER FIVE', '02'],
];
const M = ['90001', '90002', '90003', '90004', '90005'];
/** MS_UPDATE.cs:7328-7348 and :7360-7376. */
const ITEM_SALES = ['00003', '00001', '00041', '00057', '00076', '00020'];
const ITEM_PURC = ['00008', '00001', '00056', '00042', '00076'];
/**
 * Header-only books whose families the location must already have for the combo to offer them (MS_BOOK.cs:2119), and
 * the codes the cases create. Every row of every table naming one of them is removed after each case.
 */
const HELPERS = [
  ['ZIS', 'BK ITEM SALES HELPER', 'ITEM SALES', 'O'],
  ['ZIP', 'BK ITEM PURC HELPER', 'ITEM PURC', 'O'],
  ['ZCR', 'BK CASH REC HELPER', 'CASH REC', 'I'],
  ['ZBP', 'BK BANK PAY HELPER', 'BANK PAY', 'O'],
];
const CODES = [
  ...HELPERS.map(([code]) => code),
  ...['Z01', 'Z02', 'Y01', 'Z03', 'Z04', 'Z06', 'Z07', 'Z08', 'Z09', 'Z10', 'Z11', 'Z12', 'Z13'],
  ...['Z21', 'Z22', 'Z23', 'Z31', 'Z32', 'Z33', 'Z34', 'Z44', 'ABC', 'AB1', 'Q'],
  ...['JS1', 'JP1', 'JC1', 'JC2', 'JK1', 'JB1'],
];
const PROVISIONED = ['CASH', 'BANK', 'ROUNDOFF', 'KASAR', 'ORDADV', 'LBREXP'];

const path = (r) => new URL(r.url()).pathname;
const isApi = (r, method, p) => r.request().method() === method && path(r) === `/api${p}`;
const label = (page, text) => page.getByLabel(text, { exact: true });
const button = (page, name) => page.getByRole('button', { name, exact: true });
const message = (page, text) => page.getByText(text, { exact: true }).waitFor();
const focused = (page) =>
  page.evaluate(
    () =>
      document.activeElement?.id ||
      document.activeElement?.getAttribute('aria-label') ||
      document.activeElement?.textContent?.trim() ||
      '',
  );
const waitFocus = (page, id) =>
  page.waitForFunction(
    (want) =>
      (document.activeElement?.id ||
        document.activeElement?.getAttribute('aria-label') ||
        document.activeElement?.textContent?.trim()) === want,
    id,
  );
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);
const today = () => new Date().toISOString().slice(0, 10);

const headerRows = (ctx, code, lc = '01') =>
  ctx.rows(
    `SELECT "CO_BOOK" code,"BOOK_NAME" name,"BOOK_SNAME" short,"CUR_USE" cur,"MAIN_BOOK" main,"ITM_TYPE" itype,
            "BOOK_INOUT" inout,"BOOK_TYPE" btype,"BOOK_SR_NAME" ser,"RESET_BOOK" reset,"TRFR_BOOK" trfr,
            "WITH_MOBILE_ENTRY" mobile,"DATA_TYPE" dtype
       FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"=$3 AND "CO_BOOK"=$2 ORDER BY row_id`,
    code,
    lc,
  );
const slotRows = (ctx, code) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,coalesce("AC_CODE",'') ac,coalesce("AC_NAME",'') acname,"DATA_TYPE" dtype,"MAIN_BOOK" main
       FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_BOOK"=$2
      ORDER BY "SR_NO",row_id`,
    code,
  );
const footprint = (ctx) =>
  ctx.rows(
    `SELECT 'D' t, to_jsonb(b) - 'row_id' r FROM "BOOK_DATA" b WHERE tenant_id=$1
     UNION ALL SELECT 'L', to_jsonb(d) - 'row_id' FROM "BOOK_DETL" d WHERE tenant_id=$1 ORDER BY 1, 2`,
  );
/** CLEAR_DATA's list: the location's books by code (:2461). */
const dbList = async (ctx) =>
  (
    await ctx.rows(
      `SELECT "CO_BOOK" code,"BOOK_NAME" name,"TRFR_BOOK" trfr FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' ORDER BY "CO_BOOK",row_id`,
    )
  ).map((r) => [r.code, r.name, r.trfr].map((v) => String(v ?? '').trim()));
const legsOf = (ctx, book, vchNo) =>
  ctx.rows(
    `SELECT "AC_CODE" ac,coalesce("LD_CODE",'') ld,coalesce("DR_AMT",0)::float8 dr,coalesce("CR_AMT",0)::float8 cr
       FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND ($3::text IS NULL OR "VCH_NO"=$3)
      ORDER BY "VCH_NO","LEDR_KEY",row_id`,
    book,
    vchNo ?? null,
  );

/** Every row of every tenant table that names one of the case book codes. */
async function sweep(ctx) {
  const tables = await ctx.owner.$queryRawUnsafe(
    `SELECT c.table_name t FROM information_schema.columns c
       JOIN information_schema.tables b ON b.table_schema=c.table_schema AND b.table_name=c.table_name
                                       AND b.table_type='BASE TABLE'
      WHERE c.table_schema='public' AND c.column_name='CO_BOOK'
        AND EXISTS (SELECT 1 FROM information_schema.columns x WHERE x.table_schema='public'
                      AND x.table_name=c.table_name AND x.column_name='tenant_id')`,
  );
  for (const { t } of tables)
    await exec(ctx, `DELETE FROM "${t}" WHERE tenant_id=$1 AND "CO_BOOK" = ANY($2::text[])`, CODES);
}
/** The accounts, the helper headers and a clean slate; everything added is removed afterwards. */
async function withBooks(ctx, run) {
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
  await sweep(ctx);
  for (const [code, name, family, inout] of HELPERS)
    await exec(
      ctx,
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","DATA_TYPE")
       VALUES ($1,'01','01',$2,$3,$2,$4,$5,'Y','A')`,
      code,
      name,
      family,
      inout,
    );
  // The CASH REC / BANK PAY families have no MS_UPDATE template; their grid is the helper book's two slots.
  for (const [code, family, inout] of [
    ['ZCR', 'CASH REC', 'I'],
    ['ZBP', 'BANK PAY', 'O'],
  ])
    await exec(
      ctx,
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","AC_CODE","AC_NAME","DATA_TYPE")
       VALUES ($1,'01','01',$2,1,$2,$2,$3,$4,'00001','CASH ON HAND','A'),($1,'01','01',$2,2,$2,$2,$3,$4,'00057','KASAR JAVK A/C','A')`,
      code,
      family,
      inout,
    );
  try {
    return await run();
  } finally {
    await sweep(ctx);
    await exec(
      ctx,
      `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "SUB_MENU"='Books' AND "USER_NAME" = ANY($2::text[])`,
      [USERS.clerk.user, USERS.printViewer.user],
    );
    await exec(
      ctx,
      `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE" = ANY($2::text[])`,
      added,
    );
  }
}
const grantBooks = (ctx, user, view, edit, del, print) =>
  exec(
    ctx,
    `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
     VALUES ($1,'01','01',$2,'Company','Books',$3,$4,$5,$6)`,
    user,
    view,
    edit,
    del,
    print,
  );

/** A book through the API the screen uses (for a case whose subject is not the create itself). */
async function apiBook(page, code, name, family, slots, extra = {}) {
  const response = await page.request.post(`/api${API}`, {
    data: {
      code,
      name,
      short: code,
      curUse: 'Y',
      family,
      itemType: 'A',
      inout: extra.inout ?? 'O',
      bookType: 'F',
      slots: slots.map(([srNo, acCode]) => ({ srNo, acCode })),
      ...extra,
    },
  });
  assert.equal(response.status(), 201, await response.text());
}
const SALE_SLOTS = [
  [1, 'SALES'],
  [2, 'CASH'],
  [3, 'ROUNDOFF'],
];

async function openScreen(page) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', API)),
    page.goto(ROUTE),
  ]);
  await page.getByRole('heading', { name: 'Book Master', exact: true }).waitFor();
  if (response.status() === 200) await waitFocus(page, 'book-code');
  return response;
}
const listed = (page) =>
  page
    .getByTestId('book-list')
    .locator('tr')
    .evaluateAll((rows) =>
      rows.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
    );
/** The grid as shown: Sr, Account Desc, AcCode, AcName per row. */
const gridShown = (page) =>
  page
    .getByTestId('book-slots')
    .locator('tr')
    .evaluateAll((rows) =>
      rows.map((tr) => [...tr.querySelectorAll('input')].map((input) => input.value)),
    );
async function openBook(page, code, how = 'enter') {
  const row = page.getByTestId('book-list').locator(`tr[data-code="${code}"]`);
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `${API}/${code}`)),
    how === 'enter' ? row.press('Enter') : row.dblclick(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.waitForFunction((c) => {
    const box = document.querySelector('#book-code');
    return box?.value === c && box.readOnly && document.activeElement?.id === 'book-name';
  }, code);
  return response.json();
}
/** Choose a family: the grid is rebuilt from GET template (cboTrnsNm_KeyDown :2922-2970). */
async function chooseFamily(page, family) {
  await Promise.all([
    page.waitForResponse((r) => path(r) === `/api${API}/template`),
    label(page, 'Transaction Name').selectOption(family),
  ]);
  await page.waitForTimeout(100);
}
async function fillHeader(page, values) {
  const boxes = {
    code: 'Book Code',
    name: 'Book Name',
    short: 'Book Short',
    resetBook: 'ReSet Book',
    vchSeries: 'Vch Serice',
    trfrBook: 'Trfr Book',
    mobileEntry: 'With Mobile Entry',
  };
  const combos = {
    curUse: 'Cur In Use',
    itemType: 'Item Type',
    inout: 'Tran In / Out',
    bookType: 'Invoice Type',
  };
  for (const [key, value] of Object.entries(values)) {
    if (key === 'family') await chooseFamily(page, value);
    else if (combos[key]) await label(page, combos[key]).selectOption(value);
    else await label(page, boxes[key]).fill(value);
  }
}
/** Type an account into a slot's AcCode and press Enter: the exact code is taken (MSG_KeyDown :2310-2337). */
async function setAccount(page, row, code) {
  const box = label(page, `AcCode row ${row}`);
  await box.fill(code);
  if (!code) return;
  await box.press('Enter');
  await page.waitForFunction(
    ([r, c]) =>
      document.querySelector(`[aria-label="AcCode row ${r}"]`)?.value === c &&
      document.querySelector(`[aria-label="AcName row ${r}"]`)?.value !== '',
    [row, code],
  );
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
/** A saved entry: "Data Are Saved." and a new entry with the cursor in an editable empty code (CLEAR_DATA). */
async function saved(page) {
  await message(page, SAVED);
  await page.waitForFunction(
    () =>
      document.activeElement?.id === 'book-code' &&
      !document.querySelector('#book-code')?.readOnly &&
      document.querySelector('#book-code')?.value === '',
  );
}
function answerQuestions(page, answer = true) {
  const questions = [];
  page.removeAllListeners('dialog');
  page.on('dialog', (dialog) => {
    questions.push(dialog.message());
    void (answer ? dialog.accept() : dialog.dismiss());
  });
  return questions;
}
/** Create a book on the screen with its grid's AcCode cells set (row number → account). */
async function createOnScreen(page, header, accounts = {}) {
  await openScreen(page);
  await fillHeader(page, header);
  for (const [row, code] of Object.entries(accounts)) await setAccount(page, Number(row), code);
  const response = await save(page);
  assert.equal(response.status(), 201, await response.text());
  await saved(page);
}
const saleBody = (coBook) => ({
  coBook,
  acCode: PARTIES.local.code,
  vchDate: today(),
  taxRatePct: 0,
  interState: false,
  lines: [
    { itCode: ITEMS.gold.code, pcs: 1, grossWt: 10, netWt: 10, touch: 100, metalAmount: 1000 },
  ],
  cashAmt: 995,
  kasarAmount: 5,
});
async function postSale(page, coBook) {
  const response = await page.request.post('/api/sales', { data: saleBody(coBook) });
  assert.equal(response.status(), 201, await response.text());
  return String((await response.json()).vchNo).padStart(5, '0');
}
const noProvisioned = (legs) =>
  assert.deepEqual(
    legs.filter((leg) => PROVISIONED.includes(leg.ac)),
    [],
    'no leg on the provisioned slot accounts',
  );
const balanced = (legs) =>
  assert.equal(
    Math.round(legs.reduce((s, l) => s + l.dr, 0) * 100),
    Math.round(legs.reduce((s, l) => s + l.cr, 0) * 100),
  );

export const books = {
  feature: 'books',
  title: 'Company → Books (MS_BOOK)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/masters/books/page.tsx',
    'web/apps/web/app/(app)/masters/books/bookScreen.ts',
    'web/apps/web/components/BookSlotGrid.tsx',
    'web/apps/web/components/LookupPicker.tsx',
    'web/apps/web/lib/screenEscape.ts',
    'web/apps/api/src/modules/masters/booksMaster.ts',
    'web/apps/api/src/modules/masters/bookTemplates.ts',
    'web/apps/api/src/routes/booksMaster.ts',
    'web/apps/api/src/modules/ops/seedCompany.ts',
    'web/apps/web/test/features/modules/books.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    // ---------------------------------------------------------------- T01 Entry/defaults
    C(
      'entry.menu-opens',
      'T01',
      'read-only',
      'MDI_FORM.cs:7443-7447 opens MS_BOOK directly; lblBook "Book Master" (MS_BOOK.cs:1423); focus on Book Code (:2465); /masters/books is the Books screen, not the generic master form (G1, G5)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          const [response] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', API)),
            page.evaluate(() => {
              const link = document.querySelector('a[href="/masters/books"]');
              if (!link) throw new Error('no navigation entry for /masters/books');
              link.click();
            }),
          ]);
          assert.equal(response.status(), 200);
          await page.getByRole('heading', { name: 'Book Master', exact: true }).waitFor();
          await waitFocus(page, 'book-code');
          assert.equal(await page.getByTestId('book-slots').count(), 1, 'the slot grid is shown');
          return {
            observation: 'navigation opened Book Master with the cursor in Book Code',
            expected: { heading: 'Book Master', focus: 'book-code' },
          };
        }),
    ),
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'CLEAR_DATA (:2443, :2449-2453): empty boxes, Cur In Use Yes (:2101), Item Type All (:2105), Inword (:2108), Free (:2112), blank family (:2450); grid header Sr / Account Desc / AcCode / AcName (:2154-2163) and no rows',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const shown = {};
          for (const [key, text] of [
            ['code', 'Book Code'],
            ['name', 'Book Name'],
            ['short', 'Book Short'],
            ['curUse', 'Cur In Use'],
            ['family', 'Transaction Name'],
            ['itemType', 'Item Type'],
            ['inout', 'Tran In / Out'],
            ['bookType', 'Invoice Type'],
            ['resetBook', 'ReSet Book'],
            ['vchSeries', 'Vch Serice'],
            ['trfrBook', 'Trfr Book'],
            ['mobileEntry', 'With Mobile Entry'],
          ])
            shown[key] = await label(page, text).inputValue();
          const expected = {
            code: '',
            name: '',
            short: '',
            curUse: 'Y',
            family: '',
            itemType: 'A',
            inout: 'I',
            bookType: 'F',
            resetBook: '',
            vchSeries: '',
            trfrBook: '',
            mobileEntry: '',
          };
          assert.deepEqual(shown, expected);
          const heads = await page
            .getByRole('table', { name: 'Book slots' })
            .locator('th')
            .allInnerTexts();
          assert.deepEqual(
            heads.map((h) => h.trim()),
            ['Sr', 'Account Desc', 'AcCode', 'AcName'],
          );
          assert.deepEqual(await gridShown(page), []);
          assert.equal(await label(page, 'Search record').inputValue(), 'SEARCH RECORD');
          return { observation: 'blank entry with Yes/All/Inword/Free, empty grid', expected };
        }),
    ),
    C(
      'entry.combo-options',
      'T01',
      'read-only',
      'MS_BOOK.cs:2099-2111: Cur In Use Yes/No, Item Type All/Gold/Silver, Inword/Outword, Free/Tax Invoice/Mix; a value outside the list is not accepted (G4, G12)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const options = {};
          for (const name of ['Cur In Use', 'Item Type', 'Tran In / Out', 'Invoice Type'])
            options[name] = (await label(page, name).locator('option').allInnerTexts()).map((t) =>
              t.trim(),
            );
          const expected = {
            'Cur In Use': ['Yes', 'No'],
            'Item Type': ['All', 'Gold', 'Silver'],
            'Tran In / Out': ['Inword', 'Outword'],
            'Invoice Type': ['Free', 'Tax Invoice', 'Mix'],
          };
          assert.deepEqual(options, expected);
          for (const name of Object.keys(expected))
            assert.equal(
              await label(page, name).evaluate((el) => el.tagName),
              'SELECT',
              `${name} takes no free text`,
            );
          const refused = await page.request.post(`/api${API}`, {
            data: {
              code: 'Z01',
              name: 'Combo',
              short: 'ZC',
              family: 'SALES',
              itemType: 'Diamond',
              slots: [],
            },
          });
          assert.equal(refused.status(), 400);
          return { observation: 'the four combos list the desktop entries only', expected };
        }),
    ),
    C(
      'entry.family-list-from-headers',
      'T01',
      'read-only',
      'MS_BOOK.cs:2119 GROUP BY MAIN_BOOK ORDER BY MAIN_BOOK, after the blank entry (:2123): only families the location has (G12)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const options = await label(page, 'Transaction Name')
            .locator('option')
            .evaluateAll((els) => els.map((o) => o.value));
          const families = (
            await ctx.rows(
              `SELECT DISTINCT "MAIN_BOOK" m FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
                 AND coalesce(btrim("MAIN_BOOK"),'')<>'' ORDER BY 1`,
            )
          ).map((r) => r.m);
          assert.deepEqual(options, ['', ...families]);
          assert.ok(
            !options.includes('TOUR SALES'),
            'a family no book of the location has is not offered',
          );
          return {
            observation: `${families.length} families after the blank entry`,
            expected: ['', ...families],
          };
        }),
    ),
    C(
      'entry.lite-hidden-controls',
      'T01',
      'read-only',
      'MS_BOOK.cs:1757, :1805 Data Type and Reset All hidden; :3064 the footer double-click reveals them only for A/E; :2113 employee only for E (D6)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await button(page, 'Save')
            .locator('..')
            .dblclick({ position: { x: 2, y: 2 } });
          const found = await page.evaluate(() =>
            [...document.querySelectorAll('main label, main button')]
              .map((el) => el.textContent.trim())
              .filter((t) => /Data Type|Reset All|Employee/i.test(t)),
          );
          assert.deepEqual(found, []);
          return { observation: 'no Data Type, Reset All or Employee control', expected: [] };
        }),
    ),
    C(
      'entry.list-columns',
      'T01',
      'read-only',
      'MS_BOOK.cs:1713 read-only, :2405 single select, :2418-2424 Code / Name / Trfr, rows by CO_BOOK (:2461)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const heads = await page
            .getByTestId('book-list')
            .locator('xpath=..')
            .locator('th')
            .allInnerTexts();
          assert.deepEqual(
            heads.map((h) => h.trim()),
            ['Code', 'Name', 'Trfr'],
          );
          const list = await listed(page);
          assert.deepEqual(list, await dbList(ctx));
          assert.equal(
            await page.getByTestId('book-list').locator('input').count(),
            0,
            'read-only',
          );
          return { observation: `${list.length} books by code`, expected: 'BOOK_DATA by CO_BOOK' };
        }),
    ),
    // ---------------------------------------------------------------- T02 Field route
    C(
      'field.header-route',
      'T02',
      'mutation',
      'BtnSave_Click :2619-2638 stores the boxes, the combos as first letters; the name keeps its case (:2752); reopen shows every value (DISPLAY_DATA :2468-2568)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await createOnScreen(page, {
            code: 'Z01',
            name: 'Zeta Sales',
            short: 'ZS',
            curUse: 'Y',
            family: 'SALES',
            itemType: 'G',
            bookType: 'T',
            vchSeries: 'ZSR',
            resetBook: 'R1',
            trfrBook: 'T1',
            mobileEntry: 'Y',
          });
          const rows = await headerRows(ctx, 'Z01');
          assert.deepEqual(rows, [
            {
              code: 'Z01',
              name: 'Zeta Sales',
              short: 'ZS',
              cur: 'Y',
              main: 'SALES',
              itype: 'G',
              inout: 'O',
              btype: 'T',
              ser: 'ZSR',
              reset: 'R1',
              trfr: 'T1',
              mobile: 'Y',
              dtype: 'A',
            },
          ]);
          await openBook(page, 'Z01');
          const shown = {
            name: await label(page, 'Book Name').inputValue(),
            itemType: await label(page, 'Item Type').inputValue(),
            bookType: await label(page, 'Invoice Type').inputValue(),
            vchSeries: await label(page, 'Vch Serice').inputValue(),
            mobileEntry: await label(page, 'With Mobile Entry').inputValue(),
          };
          assert.deepEqual(shown, {
            name: 'Zeta Sales',
            itemType: 'G',
            bookType: 'T',
            vchSeries: 'ZSR',
            mobileEntry: 'Y',
          });
          return {
            observation: 'Z01 stored and reopened with every value',
            expected: rows[0],
            database: { header: rows, slots: await slotRows(ctx, 'Z01') },
            downstream: { reopened: shown },
          };
        }),
    ),
    C(
      'field.slot-account-route',
      'T02',
      'mutation',
      'MS_BOOK.cs:2662-2663 stores the grid AcCode and AcName per slot; ITEM SALES slot 1 template 00003 (MS_UPDATE.cs:7328) changed to 00004 (G1, G11)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await createOnScreen(
            page,
            { code: 'Z03', name: 'Zeta Three', short: 'Z3', family: 'ITEM SALES' },
            { 1: '00004' },
          );
          const slots = await slotRows(ctx, 'Z03');
          assert.deepEqual(slots[0], {
            sr: 1,
            ac: '00004',
            acname: 'SALES SILVER A/C',
            dtype: 'A',
            main: 'ITEM SALES',
          });
          await openBook(page, 'Z03');
          const grid = await gridShown(page);
          assert.deepEqual(grid[0].slice(2), ['00004', 'SALES SILVER A/C']);
          return {
            observation: 'slot 1 stored and reopened as 00004 SALES SILVER A/C',
            expected: [1, '00004', 'SALES SILVER A/C'],
            database: { slots },
            downstream: { grid },
          };
        }),
    ),
    C(
      'field.slot-description-editable',
      'T02',
      'mutation',
      'TEXT_ENTRY is writable (:2216) with limits 2/50/8/50 (:2221-2233); the save writes SR_NO, AC_CODE, AC_NAME only (:2661-2663), so a reopen shows the template description (G1)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await fillHeader(page, {
            code: 'Z03',
            name: 'Zeta Three',
            short: 'Z3',
            family: 'ITEM SALES',
          });
          const lengths = {};
          for (const col of ['Sr', 'Account Desc', 'AcName'])
            lengths[col] = await label(page, `${col} row 2`).getAttribute('maxlength');
          assert.deepEqual(lengths, { Sr: '2', 'Account Desc': '50', AcName: '50' });
          await label(page, 'Account Desc row 2').fill('TILL CASH');
          await label(page, 'Account Desc row 2').press('Enter');
          assert.equal(await label(page, 'Account Desc row 2').inputValue(), 'TILL CASH');
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          await openBook(page, 'Z03');
          const row2 = (await gridShown(page))[1];
          assert.deepEqual(row2.slice(0, 3), ['2', 'CASH ON HAND', '00001']);
          return {
            observation: 'the edited description was not stored; reopen shows CASH ON HAND',
            expected: ['2', 'CASH ON HAND', '00001'],
            database: { slots: await slotRows(ctx, 'Z03') },
            downstream: { row2 },
          };
        }),
    ),
    // ---------------------------------------------------------------- T04 Lookup
    C(
      'lookup.slot-account-exact',
      'T04',
      'read-only',
      'MSG_KeyDown :2314 exact company AC_CODE; :2332-2333 fill code and name, no help',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await fillHeader(page, {
            code: 'Z03',
            name: 'Zeta Three',
            short: 'Z3',
            family: 'ITEM SALES',
          });
          await setAccount(page, 1, '00041');
          const row = (await gridShown(page))[0];
          assert.deepEqual(row.slice(2), ['00041', 'LABOUR INCOM. A/C']);
          assert.equal(await page.locator('[data-lookup-open="true"]').count(), 0, 'no help open');
          return { observation: '00041 resolved to LABOUR INCOM. A/C', expected: row.slice(2) };
        }),
    ),
    C(
      'lookup.slot-account-help',
      'T04',
      'read-only',
      'MSG_KeyDown :2318 an unknown code lists every company account (no class or location filter) ordered by AC_NAME; :2326 the help; :2337 no advance; :2332-2335 the pick fills code and name and refocuses the editor',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await fillHeader(page, {
            code: 'Z03',
            name: 'Zeta Three',
            short: 'Z3',
            family: 'ITEM SALES',
          });
          const box = label(page, 'AcCode row 1');
          await box.fill('99999');
          await box.press('Enter');
          await page.locator('[data-lookup-open="true"]').waitFor();
          assert.equal(await focused(page), 'AcCode row 1', 'the grid does not advance');
          const help = await page.locator('[data-lookup-open="true"] b').allInnerTexts();
          const names = await ctx.rows(
            `SELECT "AC_CODE" code FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "AC_NAME","AC_CODE"`,
          );
          assert.deepEqual(
            help,
            names.slice(0, help.length).map((r) => r.code),
            'the help lists the company accounts by name',
          );
          await box.fill('00057');
          await box.press('Enter');
          await page.waitForFunction(
            () => document.querySelector('[aria-label="AcName row 1"]')?.value === 'KASAR JAVK A/C',
          );
          return {
            observation: `help of ${help.length} accounts; 00057 taken`,
            expected: 'help by name',
          };
        }),
    ),
    C(
      'lookup.slot-account-any-class',
      'T04',
      'mutation',
      'MS_BOOK.cs:2318 no per-slot class restriction; :2662 stored as typed (D5, G1): a party account in the cash slot of a CASH REC book saves',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await createOnScreen(
            page,
            { code: 'Z34', name: 'Zeta Cash Rec', short: 'Z34', family: 'CASH REC' },
            { 1: PARTIES.local.code },
          );
          const slots = await slotRows(ctx, 'Z34');
          assert.equal(slots[0].ac, PARTIES.local.code);
          return {
            observation: `CASH REC slot 1 saved as party ${PARTIES.local.code}`,
            expected: PARTIES.local.code,
            database: { slots },
            downstream: { header: await headerRows(ctx, 'Z34') },
          };
        }),
    ),
    C(
      'lookup.book-search',
      'T04',
      'read-only',
      'Text1_TextChanged :2824 BOOK_NAME or CO_BOOK prefix; :2907 Backspace removes one character; F1 focuses Search; an apostrophe must not error (string-built filter not ported)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await apiBook(page, 'Z01', 'Zeta Sales', 'SALES', SALE_SLOTS);
          await apiBook(page, 'Z02', 'Zeta Two', 'SALES', SALE_SLOTS);
          await apiBook(page, 'Y01', 'Yankee', 'SALES', SALE_SLOTS);
          await openScreen(page);
          const codes = async () => (await listed(page)).map((r) => r[0]);
          const search = label(page, 'Search record');
          await search.fill('Zet');
          assert.deepEqual(await codes(), ['Z01', 'Z02']);
          await search.fill('Y0');
          assert.deepEqual(await codes(), ['Y01']);
          await search.fill('Zeta T');
          assert.deepEqual(await codes(), ['Z02']);
          await page.getByTestId('book-list').locator('tr').first().focus();
          await page.keyboard.press('Backspace');
          assert.equal(await search.inputValue(), 'ZETA ');
          assert.deepEqual(await codes(), ['Z01', 'Z02']);
          await page.getByTestId('book-list').locator('tr').first().press('F1');
          await waitFocus(page, 'Search record');
          await search.fill("Z'");
          const afterQuote = await codes();
          assert.ok(afterQuote.every((c) => c.startsWith('Z')) && afterQuote.includes('Z01'));
          return {
            observation: 'prefix search by name or code, Backspace and F1',
            expected: ['Z01', 'Z02'],
          };
        }),
    ),
    C(
      'lookup.dgv-reopen',
      'T04',
      'read-only',
      'DGV_KeyDown :2901-2903 Enter opens the selected book and focuses Book Name; double click the same (:3015); a late first answer must not overwrite the second book',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await apiBook(page, 'Z01', 'Zeta Sales', 'SALES', SALE_SLOTS);
          await apiBook(page, 'Z02', 'Zeta Two', 'SALES', [
            [1, 'SALES'],
            [2, '00002'],
          ]);
          await openScreen(page);
          await openBook(page, 'Z01', 'enter');
          await openBook(page, 'Z02', 'dblclick');
          await button(page, 'Cancel').click();
          await waitFocus(page, 'book-code');
          // The answer for Z01 arrives after the one for Z02: the screen keeps Z02.
          await page.route(`**/api${API}/Z01`, async (route) => {
            await new Promise((r) => setTimeout(r, 1500));
            await route.continue();
          });
          await page.getByTestId('book-list').locator('tr[data-code="Z01"]').press('Enter');
          await openBook(page, 'Z02', 'dblclick');
          await page.waitForTimeout(2000);
          assert.equal(await label(page, 'Book Code').inputValue(), 'Z02');
          const grid = await gridShown(page);
          assert.deepEqual(
            grid.filter((r) => ['1', '2'].includes(r[0])).map((r) => [r[0], r[2]]),
            [
              ['1', 'SALES'],
              ['2', '00002'],
            ],
            "the screen shows only the second book's slots",
          );
          await page.unroute(`**/api${API}/Z01`);
          return {
            observation: 'Enter and double click open; the late Z01 answer was dropped',
            expected: 'Z02',
          };
        }),
    ),
    C(
      'lookup.family-rebuilds-slots',
      'T04',
      'read-only',
      'cboTrnsNm_KeyDown :2933 MSG_CLEAR, :2936 template without SR_NO 0, :2942-2948 direction from the first row; MS_UPDATE.cs:7328-7348 ITEM SALES, :7360-7376 ITEM PURC (G1, G5)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await chooseFamily(page, 'ITEM SALES');
          const sales = await gridShown(page);
          assert.deepEqual(
            sales.map((r) => r[2]),
            ITEM_SALES,
          );
          assert.equal(await label(page, 'Tran In / Out').inputValue(), 'O');
          await chooseFamily(page, 'ITEM PURC');
          const purc = await gridShown(page);
          assert.deepEqual(
            purc.map((r) => [r[0], r[2]]),
            ITEM_PURC.map((ac, i) => [String(i + 1), ac]),
          );
          return {
            observation: 'six ITEM SALES rows, Outword; then exactly five ITEM PURC rows',
            expected: { sales: ITEM_SALES, purc: ITEM_PURC },
          };
        }),
    ),
    // ---------------------------------------------------------------- T05 Children
    C(
      'children.family-enter-last-slot',
      'T05',
      'read-only',
      'MS_BOOK.cs:2958 Rows.Count > i + 1 drops the last saved account on the family Enter (versus :2552); the web keeps it (slot identity)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await apiBook(
            page,
            'Z12',
            'Zeta Item Sales',
            'ITEM SALES',
            ITEM_SALES.map((ac, i) => [i + 1, i === 5 ? '00004' : ac]),
          );
          await openScreen(page);
          await openBook(page, 'Z12');
          await chooseFamily(page, 'ITEM PURC');
          await chooseFamily(page, 'ITEM SALES');
          const grid = await gridShown(page);
          assert.deepEqual(grid[5].slice(0, 3), ['6', 'ORDER ADVANCE', '00004']);
          return { observation: 'slot 6 still shows the saved 00004', expected: '00004' };
        }),
    ),
    blocked(
      'children.template-sr0-excluded',
      'T05',
      'MS_BOOK.cs:2936 AND SR_NO <> 0; :2650 the save loop starts at row 1',
      'blocked: whether the installed baseline has an SR_NO 0 template row is MISSING (study open question); unblocks when the baseline BOOK_IDTL is supplied.',
    ),
    // ---------------------------------------------------------------- T06 Required/invalid
    ...['218', '888', '999'].map((code) =>
      C(
        `invalid.reserved-code-${code}`,
        'T06',
        'refusal',
        'MS_BOOK.cs:2591 reserved 218/888/999; :2593 "This Is a Reserve Code You Cant Use It..."; :2594 focus Book Code (G3)',
        async (ctx) =>
          withBooks(ctx, async () => {
            const { page, requests } = await ctx.session();
            await openScreen(page);
            await fillHeader(page, {
              code,
              name: `Reserved ${code}`,
              short: 'RA',
              family: 'SALES',
            });
            await button(page, 'Save').click();
            await message(page, RESERVED);
            await waitFocus(page, 'book-code');
            assert.equal(requests.filter((r) => ['POST', 'PUT'].includes(r.method)).length, 0);
            const rows = await headerRows(ctx, code);
            assert.deepEqual(rows, []);
            return { observation: `${code} refused`, expected: RESERVED, database: { rows } };
          }),
      ),
    ),
    C(
      'invalid.reserved-code-api',
      'T06',
      'refusal',
      'MS_BOOK.cs:2593 the reserved-code text, enforced by the server too (G3)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const before = await footprint(ctx);
          const response = await page.request.post(`/api${API}`, {
            data: { code: '218', name: 'Reserved', short: 'RS', family: 'SALES', slots: [] },
          });
          assert.equal(response.status(), 400);
          assert.equal((await response.json()).message, RESERVED);
          assert.deepEqual(await footprint(ctx), before);
          return {
            observation: 'POST 218 refused',
            expected: RESERVED,
            database: { unchanged: true },
          };
        }),
    ),
    C(
      'invalid.blank-short',
      'T06',
      'refusal',
      'MS_BOOK.cs:2597-2600 "Please Insert Book Short Name", focus Book Short (G3)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await fillHeader(page, { code: 'Z06', name: 'No Short', family: 'SALES' });
          await button(page, 'Save').click();
          await message(page, SHORT_REQUIRED);
          await waitFocus(page, 'book-short');
          const rows = await headerRows(ctx, 'Z06');
          assert.deepEqual(rows, []);
          return {
            observation: 'blank short refused',
            expected: SHORT_REQUIRED,
            database: { rows },
          };
        }),
    ),
    C(
      'invalid.blank-code-or-name',
      'T06',
      'refusal',
      'MS_BOOK.cs:2603-2605 "Error Found : Please Enter Book Detail First..."; the check order edit right, reserved (:2591), short (:2597), code/name (:2603)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const before = await footprint(ctx);
          await fillHeader(page, { short: 'AB', name: 'Only Name' });
          await button(page, 'Save').click();
          await message(page, DETAIL_REQUIRED);
          await button(page, 'Cancel').click();
          await waitFocus(page, 'book-code');
          await fillHeader(page, { code: 'Z07', short: 'AB' });
          await button(page, 'Save').click();
          await message(page, DETAIL_REQUIRED);
          await button(page, 'Cancel').click();
          await waitFocus(page, 'book-code');
          await fillHeader(page, { code: '218', name: 'Order' });
          await button(page, 'Save').click();
          await message(page, RESERVED);
          assert.deepEqual(await footprint(ctx), before);
          return {
            observation: 'blank code, blank name refused; reserved first',
            expected: DETAIL_REQUIRED,
            database: { unchanged: true },
          };
        }),
    ),
    C(
      'invalid.name-enter-blank',
      'T06',
      'read-only',
      'tBkName_KeyDown :2875-2878 "Error Found : Please Enter Book Name First...", focus Book Name; Book Short shares the handler (:468)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Book Code').fill('Z08');
          await label(page, 'Book Code').press('Enter');
          await waitFocus(page, 'book-name');
          await label(page, 'Book Name').press('Enter');
          await message(page, NAME_FIRST);
          await waitFocus(page, 'book-name');
          await label(page, 'Book Short').focus();
          await label(page, 'Book Short').press('Enter');
          await waitFocus(page, 'book-name');
          return {
            observation: 'Enter on a blank name refused from Name and Short',
            expected: NAME_FIRST,
          };
        }),
    ),
    C(
      'invalid.duplicate-code',
      'T06',
      'refusal',
      "tBkCode_Validating :2778 the code text with the other book's name; :2780 the code selected; the same code and name is not a duplicate (G3)",
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await apiBook(page, 'Z01', 'Zeta Sales', 'SALES', SALE_SLOTS);
          await openScreen(page);
          const before = await footprint(ctx);
          await label(page, 'Book Code').fill('Z01');
          await label(page, 'Book Name').focus();
          await message(page, codeTaken('Zeta Sales'));
          await waitFocus(page, 'book-code');
          const response = await page.request.post(`/api${API}`, {
            data: { code: 'Z01', name: 'Other Name', short: 'ON', family: 'SALES', slots: [] },
          });
          assert.equal((await response.json()).message, codeTaken('Zeta Sales'));
          assert.deepEqual(await footprint(ctx), before);
          return {
            observation: 'duplicate code refused on leave and by the API',
            expected: codeTaken('Zeta Sales'),
            database: { unchanged: true },
          };
        }),
    ),
    C(
      'invalid.duplicate-name',
      'T06',
      'refusal',
      'tBkName_Validating :2800 the name text with the other code; :2802 the name selected (G3)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await apiBook(page, 'Z01', 'Zeta Sales', 'SALES', SALE_SLOTS);
          await openScreen(page);
          const before = await footprint(ctx);
          await label(page, 'Book Code').fill('Z09');
          await label(page, 'Book Name').fill('Zeta Sales');
          await label(page, 'Book Short').focus();
          await message(page, nameTaken('Z01'));
          await waitFocus(page, 'book-name');
          const response = await page.request.post(`/api${API}`, {
            data: { code: 'Z09', name: 'Zeta Sales', short: 'Z9', family: 'SALES', slots: [] },
          });
          assert.equal(response.status(), 400);
          assert.equal((await response.json()).message, nameTaken('Z01'));
          assert.deepEqual(await footprint(ctx), before);
          return {
            observation: 'duplicate name refused',
            expected: nameTaken('Z01'),
            database: { unchanged: true },
          };
        }),
    ),
    C(
      'invalid.code-max-3',
      'T06',
      'refusal',
      'MS_BOOK.cs:2459 MaxLength 3; no digits-only check (:2603); no padding (G4)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Book Code').pressSequentially('ABCD');
          assert.equal(await label(page, 'Book Code').inputValue(), 'ABC');
          const before = await footprint(ctx);
          const long = await page.request.post(`/api${API}`, {
            data: { code: 'ABCD', name: 'Too Long', short: 'TL', family: 'SALES', slots: [] },
          });
          assert.equal(long.status(), 400);
          assert.deepEqual(await footprint(ctx), before);
          await button(page, 'Cancel').click();
          await waitFocus(page, 'book-code');
          for (const code of ['AB1', 'Q'])
            await createOnScreen(page, {
              code,
              name: `Code ${code}`,
              short: code,
              family: 'SALES',
            });
          const rows = [...(await headerRows(ctx, 'AB1')), ...(await headerRows(ctx, 'Q'))];
          assert.deepEqual(
            rows.map((r) => r.code),
            ['AB1', 'Q'],
          );
          return {
            observation: 'ABCD held as ABC and refused by the API; AB1 and Q saved',
            expected: ['AB1', 'Q'],
            database: { rows },
          };
        }),
    ),
    C(
      'invalid.field-limits',
      'T06',
      'read-only',
      'MaxLength: Book Name 50 (:1435), Short 5 (:1526), Vch Serice 15 (:1511), ReSet 5 (:1745), Trfr 5 (:1770), Mobile Entry 1 (:1845); the API refuses longer values (G4)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const limits = {
            'Book Name': 50,
            'Book Short': 5,
            'Vch Serice': 15,
            'ReSet Book': 5,
            'Trfr Book': 5,
            'With Mobile Entry': 1,
          };
          const held = {};
          for (const [name, max] of Object.entries(limits)) {
            await label(page, name).pressSequentially('X'.repeat(max + 1));
            held[name] = (await label(page, name).inputValue()).length;
          }
          assert.deepEqual(held, limits);
          const refused = await page.request.post(`/api${API}`, {
            data: { code: 'Z40', name: 'N'.repeat(51), short: 'LM', family: 'SALES', slots: [] },
          });
          assert.equal(refused.status(), 400);
          return {
            observation: 'every box holds its limit; a 51-character name refused',
            expected: limits,
          };
        }),
    ),
    C(
      'invalid.keypress-filter',
      'T06',
      'read-only',
      'MS_BOOK_KeyPress :2758 upper-cases, :2761-2763 swallows the apostrophe; Book Name exempt (:2752) (G4)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Book Short').pressSequentially("ab'c");
          assert.equal(await label(page, 'Book Short').inputValue(), 'ABC');
          await label(page, 'Book Name').pressSequentially("ab'c");
          const name = await label(page, 'Book Name').inputValue();
          assert.ok(name.startsWith('ab') && name.endsWith('c'), `name keeps lower case: ${name}`);
          return {
            observation: `short ABC, name ${name}`,
            expected: { short: 'ABC', name: 'ab…c' },
          };
        }),
    ),
    C(
      'invalid.blank-slot-account-allowed',
      'T06',
      'mutation',
      'MS_BOOK.cs:2650 the save loop has no blank-account skip; :2667 Data Type A (D5); a voucher needing the slot refuses later',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await createOnScreen(
            page,
            { code: 'Z10', name: 'Blank Slots', short: 'Z10', family: 'ITEM SALES' },
            { 3: '', 6: '' },
          );
          const slots = await slotRows(ctx, 'Z10');
          assert.equal(slots.length, 6);
          assert.deepEqual(
            slots.filter((s) => !s.ac).map((s) => [s.sr, s.dtype]),
            [
              [3, 'A'],
              [6, 'A'],
            ],
          );
          return {
            observation: 'six slots, 3 and 6 blank with Data Type A',
            expected: [3, 6],
            database: { slots },
            downstream: { header: await headerRows(ctx, 'Z10') },
          };
        }),
    ),
    C(
      'invalid.family-change-with-vouchers',
      'T06',
      'refusal',
      'Decision D4: the web refuses a family change on a book with vouchers (no desktop guard; MS_BOOK.cs:2608 replaces the rows); without vouchers the change saves (G12)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await apiBook(page, 'Z11', 'Zeta Voucher', 'SALES', SALE_SLOTS);
          await apiBook(page, 'Z13', 'Zeta Free', 'SALES', SALE_SLOTS);
          // A voucher of Z11: an AC_DATA row (MS_BOOK.cs:2706 reads AC_DATA by company and book).
          await exec(
            ctx,
            `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","AC_CODE","DR_AMT","CR_AMT")
             VALUES ($1,'01','01','Z11','00001','CASH',10,0)`,
          );
          await openScreen(page);
          const before = await footprint(ctx);
          await openBook(page, 'Z11');
          await chooseFamily(page, 'PURCHASE');
          await button(page, 'Save').click();
          await message(page, FAMILY_LOCKED);
          assert.deepEqual(await footprint(ctx), before);
          await button(page, 'Cancel').click();
          await waitFocus(page, 'book-code');
          await openBook(page, 'Z13');
          await chooseFamily(page, 'PURCHASE');
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const z13 = await headerRows(ctx, 'Z13');
          assert.equal(z13[0].main, 'PURCHASE');
          return {
            observation: 'Z11 refused with the D4 text; Z13 changed',
            expected: FAMILY_LOCKED,
            database: { z13 },
          };
        }),
    ),
    C(
      'invalid.no-edit-right',
      'T06',
      'refusal',
      'MS_BOOK.cs:2586-2588 edit mode without FRM_EDIT: "You Have No Rights....."; a new book is not blocked by this check',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page: admin } = await ctx.session();
          await apiBook(admin, 'Z01', 'Zeta Sales', 'SALES', SALE_SLOTS);
          await grantBooks(ctx, USERS.clerk.user, 'Y', 'N', 'N', 'N');
          const { page, requests } = await ctx.session(as(USERS.clerk.user));
          await openScreen(page);
          const opened = await openBook(page, 'Z01');
          await label(page, 'Book Name').fill('Zeta Changed');
          await button(page, 'Save').click();
          await message(page, NO_RIGHTS);
          assert.equal(requests.filter((r) => r.method === 'PUT').length, 0);
          const direct = await page.request.put(`/api${API}/Z01`, {
            data: { ...opened, name: 'X', expectedVersion: opened.version },
          });
          assert.equal(direct.status(), 403);
          const rows = await headerRows(ctx, 'Z01');
          assert.equal(rows[0].name, 'Zeta Sales');
          return {
            observation: 'edit refused on screen and 403 by the API',
            expected: NO_RIGHTS,
            database: { rows },
          };
        }),
    ),
    // ---------------------------------------------------------------- T07 Create
    C(
      'create.new-code-enter',
      'T07',
      'read-only',
      'MS_BOOK.cs:3007 a new code sends Tab, no generator; :3002 an existing code is displayed first',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page, requests } = await ctx.session();
          await apiBook(page, 'Z01', 'Zeta Sales', 'SALES', SALE_SLOTS);
          await openScreen(page);
          await label(page, 'Book Code').fill('Z21');
          await label(page, 'Book Code').press('Enter');
          await waitFocus(page, 'book-name');
          assert.equal(await label(page, 'Book Code').inputValue(), 'Z21');
          assert.equal(await label(page, 'Book Name').inputValue(), '');
          assert.equal(requests.filter((r) => r.path.includes(`${API}/Z21`)).length, 0);
          await button(page, 'Cancel').click();
          await waitFocus(page, 'book-code');
          await label(page, 'Book Code').fill('Z01');
          await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/Z01`)),
            label(page, 'Book Code').press('Enter'),
          ]);
          await waitFocus(page, 'book-name');
          assert.equal(await label(page, 'Book Name').inputValue(), 'Zeta Sales');
          return {
            observation: 'new code moved on; existing code opened',
            expected: 'Tab / DISPLAY_DATA',
          };
        }),
    ),
    // ---------------------------------------------------------------- T08 Reopen
    C(
      'reopen.locks',
      'T08',
      'read-only',
      'MS_BOOK.cs:2526 mobile entry read-only, :2564-2565 direction and invoice type disabled, :2566 code read-only; family stays editable (G5)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await apiBook(page, 'Z01', 'Zeta Sales', 'SALES', SALE_SLOTS);
          await openScreen(page);
          await openBook(page, 'Z01');
          const state = {
            code: await label(page, 'Book Code').evaluate((el) => el.readOnly),
            mobile: await label(page, 'With Mobile Entry').evaluate((el) => el.readOnly),
            inout: await label(page, 'Tran In / Out').isDisabled(),
            bookType: await label(page, 'Invoice Type').isDisabled(),
            family: await label(page, 'Transaction Name').isDisabled(),
          };
          const expected = { code: true, mobile: true, inout: true, bookType: true, family: false };
          assert.deepEqual(state, expected);
          return { observation: 'the reopened book is locked as the desktop locks it', expected };
        }),
    ),
    C(
      'reopen.mode-after-save',
      'T08',
      'read-only',
      'MS_BOOK.cs:2563 EntryMode E on display; :2460 a fresh clear is add mode',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await createOnScreen(page, {
            code: 'Z33',
            name: 'Zeta Mode',
            short: 'Z33',
            family: 'SALES',
          });
          await label(page, 'Book Code').fill('Z33');
          await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/Z33`)),
            label(page, 'Book Code').press('Enter'),
          ]);
          await page.waitForFunction(() => document.querySelector('#book-code')?.readOnly === true);
          await button(page, 'Cancel').click();
          await page.waitForFunction(
            () =>
              document.querySelector('#book-code')?.readOnly === false &&
              document.querySelector('#book-code')?.value === '',
          );
          return {
            observation: 'Enter on the saved code opened it; Cancel returned to add mode',
            expected: 'E then A',
          };
        }),
    ),
    // ---------------------------------------------------------------- T09 Edit
    C(
      'edit.direction-locked',
      'T09',
      'refusal',
      'MS_BOOK.cs:2564 direction disabled; :2853-2857 Ctrl+O not ported (D6); the API refuses a direction or invoice-type change of a saved book (G5)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await apiBook(page, 'Z01', 'Zeta Sales', 'SALES', SALE_SLOTS);
          await openScreen(page);
          const opened = await openBook(page, 'Z01');
          await page.keyboard.press('Control+o');
          assert.equal(await label(page, 'Tran In / Out').isDisabled(), true);
          assert.equal(await label(page, 'Invoice Type').isDisabled(), true);
          const before = await headerRows(ctx, 'Z01');
          for (const change of [{ inout: 'I' }, { bookType: 'T' }]) {
            const response = await page.request.put(`/api${API}/Z01`, {
              data: {
                ...opened,
                ...change,
                slots: opened.slots.map((s) => ({ srNo: s.srNo, acCode: s.acCode })),
                expectedVersion: opened.version,
              },
            });
            assert.equal(response.status(), 400, await response.text());
          }
          assert.deepEqual(await headerRows(ctx, 'Z01'), before);
          return {
            observation: 'still disabled after Ctrl+O; the API refused both changes',
            expected: 'locked',
            database: { before },
          };
        }),
    ),
    C(
      'edit.edit-right-only-in-edit-mode',
      'T09',
      'mutation',
      'MS_BOOK.cs:2586 the edit right is checked in mode E only: a user without it saves a new book',
      async (ctx) =>
        withBooks(ctx, async () => {
          await grantBooks(ctx, USERS.clerk.user, 'Y', 'N', 'N', 'N');
          const { page } = await ctx.session(as(USERS.clerk.user));
          await createOnScreen(page, {
            code: 'Z44',
            name: 'Clerk Book',
            short: 'Z44',
            family: 'SALES',
          });
          const rows = await headerRows(ctx, 'Z44');
          assert.equal(rows.length, 1);
          return {
            observation: 'the clerk without edit right created Z44',
            expected: 1,
            database: { rows },
            downstream: { slots: await slotRows(ctx, 'Z44') },
          };
        }),
    ),
    // ---------------------------------------------------------------- T10 Delete/cancel
    C(
      'delete.unused',
      'T10',
      'mutation',
      'BtnDelete_Click :2719 the question; No leaves the data; Yes :2721-2722 deletes header and slots, :2723 "Delete Success.", :2724 clear (G2)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page, requests } = await ctx.session();
          await apiBook(
            page,
            'Z12',
            'Zeta Item Sales',
            'ITEM SALES',
            ITEM_SALES.map((ac, i) => [i + 1, ac]),
          );
          await openScreen(page);
          await openBook(page, 'Z12');
          const asked = answerQuestions(page, false);
          await button(page, 'Delete').click();
          await page.waitForTimeout(300);
          assert.deepEqual(asked, [DELETE_CONFIRM]);
          assert.equal(requests.filter((r) => r.method === 'DELETE').length, 0);
          assert.equal((await slotRows(ctx, 'Z12')).length, 6);
          const yes = answerQuestions(page, true);
          await button(page, 'Delete').click();
          await message(page, DELETED);
          assert.deepEqual(yes, [DELETE_CONFIRM]);
          const header = await headerRows(ctx, 'Z12');
          const slots = await slotRows(ctx, 'Z12');
          assert.deepEqual([header, slots], [[], []]);
          return {
            observation: 'No kept it; Yes deleted header and six slots',
            expected: DELETED,
            database: { header, slots },
            downstream: { list: await listed(page) },
          };
        }),
    ),
    C(
      'delete.refused-account-voucher',
      'T10',
      'refusal',
      'MS_BOOK.cs:2706 AC_DATA by company and book (every location); :2710 the account text (G2)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await apiBook(page, 'Z22', 'Zeta Receipts', 'SALES', SALE_SLOTS);
          // A voucher of Z22 posted at another location: still refused (no location in the desktop check).
          await exec(
            ctx,
            `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","AC_CODE","DR_AMT","CR_AMT")
             VALUES ($1,'01','02','Z22','00001','CASH',10,0)`,
          );
          await openScreen(page);
          const before = await footprint(ctx);
          await openBook(page, 'Z22');
          await button(page, 'Delete').click();
          await message(page, USED_IN_ACCOUNTS);
          assert.deepEqual(await footprint(ctx), before);
          return {
            observation: 'refused with the account text',
            expected: USED_IN_ACCOUNTS,
            database: { unchanged: true },
          };
        }),
    ),
    C(
      'delete.refused-stock-voucher',
      'T10',
      'refusal',
      'MS_BOOK.cs:2713 MAIN_STOCK by company, location and book; :2717 the stock text (G2)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await apiBook(page, 'Z23', 'Zeta Stock', 'SALES', SALE_SLOTS);
          await exec(
            ctx,
            `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO") VALUES ($1,'01','01','Z23','00001')`,
          );
          await openScreen(page);
          const before = await footprint(ctx);
          await openBook(page, 'Z23');
          await button(page, 'Delete').click();
          await message(page, USED_IN_STOCK);
          assert.deepEqual(await footprint(ctx), before);
          return {
            observation:
              'refused with the stock text (the other-location half is proved in booksMaster.db.test.ts)',
            expected: USED_IN_STOCK,
            database: { unchanged: true },
          };
        }),
    ),
    C(
      'delete.blank-code',
      'T10',
      'refusal',
      'MS_BOOK.cs:2703 "Please Select Product For Delete."',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page, requests } = await ctx.session();
          await openScreen(page);
          await button(page, 'Delete').click();
          await message(page, SELECT_FOR_DELETE);
          assert.equal(requests.filter((r) => r.method === 'DELETE').length, 0);
          return {
            observation: 'blank code refused',
            expected: SELECT_FOR_DELETE,
            database: { deleted: 0 },
          };
        }),
    ),
    C(
      'delete.no-right',
      'T10',
      'refusal',
      'MS_BOOK.cs:2696-2698 without FRM_DELETE "You Have No Rights....."; the API refuses the DELETE too',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page: admin } = await ctx.session();
          await apiBook(admin, 'Z22', 'Zeta Receipts', 'SALES', SALE_SLOTS);
          await grantBooks(ctx, USERS.clerk.user, 'Y', 'N', 'N', 'N');
          const { page, requests } = await ctx.session(as(USERS.clerk.user));
          await openScreen(page);
          await openBook(page, 'Z22');
          await button(page, 'Delete').click();
          await message(page, NO_RIGHTS);
          assert.equal(requests.filter((r) => r.method === 'DELETE').length, 0);
          assert.equal((await page.request.delete(`/api${API}/Z22`)).status(), 403);
          const rows = await headerRows(ctx, 'Z22');
          assert.equal(rows.length, 1);
          return {
            observation: 'delete refused on screen and by the API',
            expected: NO_RIGHTS,
            database: { rows },
          };
        }),
    ),
    blocked(
      'delete.atomic',
      'T10',
      'D3; MS_BOOK.cs:2721-2722 separate deletes not ported',
      'blocked: needs a fault-injection hook in the isolated test stack (another work package: the failure harness used by T14 in other modules); unblocks when the harness exposes a per-table failpoint.',
    ),
    C(
      'cancel.clears',
      'T10',
      'read-only',
      'BtnCancel_Click :2733 CLEAR_DATA without a write; Esc closes without a prompt (:2851); Exit closes (:2738)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page, requests } = await ctx.session();
          await apiBook(page, 'Z12', 'Zeta Item Sales', 'SALES', SALE_SLOTS);
          await openScreen(page);
          const before = await footprint(ctx);
          await openBook(page, 'Z12');
          await label(page, 'Book Name').fill('Edited');
          await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', API)),
            button(page, 'Cancel').click(),
          ]);
          await page.waitForFunction(
            () =>
              document.querySelector('#book-code')?.value === '' &&
              !document.querySelector('#book-code')?.readOnly,
          );
          assert.equal(
            requests.filter((r) => ['POST', 'PUT', 'DELETE'].includes(r.method)).length,
            0,
          );
          assert.deepEqual(await footprint(ctx), before);
          await Promise.all([
            page.waitForURL((url) => !url.pathname.startsWith(ROUTE), { timeout: 10_000 }),
            button(page, 'Exit').click(),
          ]);
          return {
            observation: 'Cancel cleared without a write; Exit left',
            expected: 'no change',
          };
        }),
    ),
    // ---------------------------------------------------------------- T11 Rights
    C(
      'rights.caption-books',
      'T11',
      'refusal',
      'MS_BOOK_Load :1930 USER_SET by the caption (formCatalog "Books"): no row refuses every route; a view row opens the screen',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session(as(USERS.printViewer.user));
          const refused = await openScreen(page);
          assert.equal(refused.status(), 403);
          await message(page, NO_RIGHTS);
          const direct = [
            (await page.request.get(`/api${API}`)).status(),
            (await page.request.post(`/api${API}`, { data: { code: 'Z44' } })).status(),
            (await page.request.put(`/api${API}/SL`, { data: {} })).status(),
            (await page.request.delete(`/api${API}/SL`)).status(),
          ];
          assert.deepEqual(direct, [403, 403, 403, 403]);
          await grantBooks(ctx, USERS.printViewer.user, 'Y', 'N', 'N', 'N');
          assert.equal((await page.request.get(`/api${API}`)).status(), 200);
          return {
            observation: `no Books row: ${direct.join('/')}; with the caption row 200`,
            expected: 403,
            database: { direct },
          };
        }),
    ),
    // ---------------------------------------------------------------- T13 Retry
    C(
      'retry.lost-ack',
      'T13',
      'mutation',
      'A save whose answer is lost: the book exists once and the next save is an edit of the same code (the code text :2778 fires only for a different name)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await fillHeader(page, {
            code: 'Z12',
            name: 'Zeta Lost',
            short: 'Z12',
            family: 'ITEM SALES',
          });
          await page.route(`**/api${API}`, async (route) => {
            if (route.request().method() !== 'POST') return route.continue();
            // The save reaches the server; its answer is lost on the way back.
            await route.fetch();
            await route.fulfill({
              status: 408,
              contentType: 'application/json',
              body: '{"error":"lost"}',
            });
          });
          await button(page, 'Save').click();
          await page.waitForTimeout(1000);
          await page.unroute(`**/api${API}`);
          await openScreen(page);
          const list = await listed(page);
          assert.equal(list.filter((r) => r[0] === 'Z12').length, 1);
          await label(page, 'Book Code').fill('Z12');
          await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/Z12`)),
            label(page, 'Book Code').press('Enter'),
          ]);
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const header = await headerRows(ctx, 'Z12');
          const slots = await slotRows(ctx, 'Z12');
          assert.equal(header.length, 1);
          assert.equal(slots.length, 6);
          return {
            observation: 'one book, six slots after the retry as an edit',
            expected: { header: 1, slots: 6 },
            database: { header, slots },
            downstream: { list },
          };
        }),
    ),
    // ---------------------------------------------------------------- T14/T15
    blocked(
      'rollback.detail-failure-keeps-old',
      'T14',
      'MS_BOOK.cs:2609, :2611, :2675 separate writes not ported',
      'blocked: needs a fault-injection point after the header write (see books.delete.atomic); unblocks with the shared failpoint harness.',
    ),
    C(
      'history.cur-use-no-hides-book',
      'T15',
      'mutation',
      'DC_Main.cs:1503 the voucher book help takes CUR_USE Y only; existing vouchers still open (G12)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await apiBook(page, 'Z31', 'Zeta In Use', 'SALES', SALE_SLOTS);
          const vch = await postSale(page, 'Z31');
          await openScreen(page);
          await openBook(page, 'Z31');
          await label(page, 'Cur In Use').selectOption('N');
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const books = JSON.stringify(await (await page.request.get('/api/context/books')).json());
          assert.ok(!books.includes('"Z31"'), 'Z31 is no longer offered');
          const read = await page.request.get(`/api/sales/${vch}?coBook=Z31`);
          assert.equal(read.status(), 200);
          return {
            observation: 'Z31 Cur In Use No: gone from the book help, its sale still opens',
            expected: 'CUR_USE N hides',
            database: { header: await headerRows(ctx, 'Z31') },
            downstream: { sale: vch },
          };
        }),
    ),
    notApplicable(
      'history.employee-book',
      'T15',
      'DC_Main.cs:1514 USER_EMP_CODE filter',
      'N/A: employee controls and employee matching exist for edition E only (MS_BOOK.cs:2113 {{if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}}).',
    ),
    blocked(
      'history.branch-clone',
      'T15',
      'MS_LOCT.cs:3609-3614 location add copies the books of location 00',
      'blocked: the Location Master add path in Lite is another work package (out of scope here) and its reachability in Lite is unverified; unblocks when a Location Master add is available in the test stack. If locations are not reachable in Lite, this case becomes N/A with the citation above.',
    ),
    // ---------------------------------------------------------------- T16 Output
    C(
      'output.print-no-right',
      'T16',
      'refusal',
      'BtnPrint_Click :2573-2575 "You Have No Print Rights....." (G13); the CSV export behind the same right',
      async (ctx) =>
        withBooks(ctx, async () => {
          await grantBooks(ctx, USERS.clerk.user, 'Y', 'Y', 'Y', 'N');
          const { page } = await ctx.session(as(USERS.clerk.user));
          await openScreen(page);
          await button(page, 'Print').click();
          await message(page, NO_PRINT_RIGHTS);
          await button(page, 'Export CSV').click();
          await message(page, NO_PRINT_RIGHTS);
          assert.equal((await page.request.get(`/api${API}/print`)).status(), 403);
          return {
            observation: 'Print and Export CSV refused',
            expected: NO_PRINT_RIGHTS,
            database: { written: 0 },
          };
        }),
    ),
    C(
      'output.print-with-right',
      'T16',
      'output',
      'BtnPrint_Click :2570-2577 with the right does nothing (no report); the CSV of Code / Name / Trfr is the web addition D7 (G13)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page, requests } = await ctx.session();
          await openScreen(page);
          const before = requests.length;
          await button(page, 'Print').click();
          await page.waitForTimeout(300);
          assert.equal(await page.locator('.msg').count(), 0, 'no message');
          assert.equal(requests.slice(before).length, 0, 'no request');
          const [download] = await Promise.all([
            page.waitForEvent('download'),
            button(page, 'Export CSV').click(),
          ]);
          const csv = await readFile(await download.path(), 'utf8');
          const lines = csv.split('\n');
          assert.equal(lines[0], 'Code,Name,Trfr');
          const rows = lines
            .slice(1)
            .map((line) =>
              line.split('","').map((v) => v.replace(/^"|"$/g, '').replace(/""/g, '"')),
            );
          assert.deepEqual(rows, await dbList(ctx));
          return {
            observation: `Print did nothing; the CSV listed ${rows.length} books`,
            expected: 'BOOK_DATA by code',
            output: { lines: lines.length },
          };
        }),
    ),
    C(
      'output.list-after-lifecycle',
      'T16',
      'mutation',
      'MS_BOOK.cs:2681-2683 the list is read again by code after save and delete',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await createOnScreen(page, {
            code: 'Z33',
            name: 'Zeta List',
            short: 'Z33',
            family: 'SALES',
          });
          assert.deepEqual(await listed(page), await dbList(ctx));
          await openBook(page, 'Z33');
          await label(page, 'Book Name').fill('Zeta List Two');
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const afterEdit = await listed(page);
          assert.ok(afterEdit.some((r) => r[0] === 'Z33' && r[1] === 'Zeta List Two'));
          assert.deepEqual(afterEdit, await dbList(ctx));
          await openBook(page, 'Z33');
          answerQuestions(page, true);
          await button(page, 'Delete').click();
          await message(page, DELETED);
          const afterDelete = await listed(page);
          assert.ok(!afterDelete.some((r) => r[0] === 'Z33'));
          assert.deepEqual(afterDelete, await dbList(ctx));
          return {
            observation: 'the list followed create, edit and delete',
            expected: 'BOOK_DATA by code',
            database: { afterDelete: afterDelete.length },
            downstream: { afterEdit: afterEdit.length },
          };
        }),
    ),
    // ---------------------------------------------------------------- T17 Keyboard
    C(
      'keys.form-flow',
      'T17',
      'mutation',
      'Enter walks the boxes (:2917), the family Enter rebuilds the grid (:2970), ReSet Book to Vch Serice (:3037), Vch Serice to grid row 1 column 1 (:2978-2982) (G5)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const step = async (key, value, next) => {
            if (value !== undefined) await page.keyboard.type(value);
            await page.keyboard.press(key);
            await waitFocus(page, next);
          };
          await step('Enter', 'Z32', 'book-name');
          await step('Enter', 'Zeta Keys', 'book-short');
          await step('Enter', 'ZK', 'book-curUse');
          await step('Enter', undefined, 'book-family');
          await chooseFamily(page, 'ITEM SALES');
          await label(page, 'Transaction Name').focus();
          await step('Enter', undefined, 'book-itemType');
          await step('Enter', undefined, 'book-inout');
          await step('Enter', undefined, 'book-bookType');
          await step('Enter', undefined, 'book-resetBook');
          await step('Enter', undefined, 'book-vchSeries');
          await step('Enter', undefined, 'Account Desc row 1');
          assert.equal(await label(page, 'Tran In / Out').inputValue(), 'O');
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          const slots = await slotRows(ctx, 'Z32');
          assert.deepEqual(
            slots.map((s) => s.ac),
            ITEM_SALES,
          );
          return {
            observation: 'keyboard walk to the grid; Z32 saved with the template',
            expected: ITEM_SALES,
            database: { slots },
            downstream: { header: await headerRows(ctx, 'Z32') },
          };
        }),
    ),
    C(
      'keys.grid-navigation',
      'T17',
      'read-only',
      "MSG_KeyDown :2283-2301 arrows stop at column 1, the last column, row 1 and the last row; :2348-2358 Enter on AcCode/AcName to the next row's AcCode, Save on the last row",
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await fillHeader(page, {
            code: 'Z32',
            name: 'Zeta Grid',
            short: 'ZG',
            family: 'ITEM SALES',
          });
          await label(page, 'Vch Serice').focus();
          await page.keyboard.press('Enter');
          await waitFocus(page, 'Account Desc row 1');
          await page.keyboard.press('ArrowLeft');
          await waitFocus(page, 'Account Desc row 1');
          await page.keyboard.press('ArrowUp');
          await waitFocus(page, 'Account Desc row 1');
          await page.keyboard.press('ArrowRight');
          await waitFocus(page, 'AcCode row 1');
          await page.keyboard.press('ArrowRight');
          await waitFocus(page, 'AcName row 1');
          await page.keyboard.press('ArrowRight');
          await waitFocus(page, 'AcName row 1');
          await page.keyboard.press('Enter');
          await waitFocus(page, 'AcCode row 2');
          await label(page, 'AcName row 6').focus();
          await page.keyboard.press('ArrowDown');
          await waitFocus(page, 'AcName row 6');
          await page.keyboard.press('Enter');
          await waitFocus(page, 'Save');
          return {
            observation: 'edges hold; Enter on AcName walks to the next AcCode and to Save',
            expected: 'MSG_KeyDown',
          };
        }),
    ),
    C(
      'keys.f1-esc-ctrl-o',
      'T17',
      'read-only',
      'F1 to Search (:2992-2994, :2895-2897); Esc closes without a prompt (:2849-2851); Ctrl+O not ported (D6)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await apiBook(page, 'Z01', 'Zeta Sales', 'SALES', SALE_SLOTS);
          await openScreen(page);
          await label(page, 'Book Code').press('F1');
          await waitFocus(page, 'Search record');
          await page.getByTestId('book-list').locator('tr').first().press('F1');
          await waitFocus(page, 'Search record');
          await openBook(page, 'Z01');
          await page.keyboard.press('Control+o');
          assert.equal(await label(page, 'Tran In / Out').isDisabled(), true);
          await label(page, 'Book Name').fill('Unsaved Edit');
          const asked = answerQuestions(page, true);
          await Promise.all([
            page.waitForURL((url) => !url.pathname.startsWith(ROUTE), { timeout: 10_000 }),
            label(page, 'Book Name').press('Escape'),
          ]);
          assert.deepEqual(asked, [], 'no prompt');
          assert.equal((await headerRows(ctx, 'Z01'))[0].name, 'Zeta Sales');
          return {
            observation: 'F1 to search, Ctrl+O inert, Esc left without a prompt',
            expected: 'desktop keys',
          };
        }),
    ),
    C(
      'keys.alt-mnemonics',
      'T17',
      'read-only',
      'Button captions &Save, &Print, &Cancel, &Delete, E&xit (:1623-1676)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await apiBook(page, 'Z01', 'Zeta Sales', 'SALES', SALE_SLOTS);
          await openScreen(page);
          await page.keyboard.press('Alt+s');
          await message(page, SHORT_REQUIRED);
          await page.keyboard.press('Alt+d');
          await message(page, SELECT_FOR_DELETE);
          await page.keyboard.press('Alt+p');
          await page.waitForTimeout(200);
          assert.equal(await page.locator('.msg').count(), 0, 'Print with the right shows nothing');
          await openBook(page, 'Z01');
          await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', API)),
            page.keyboard.press('Alt+c'),
          ]);
          await page.waitForFunction(() => document.querySelector('#book-code')?.value === '');
          await Promise.all([
            page.waitForURL((url) => !url.pathname.startsWith(ROUTE), { timeout: 10_000 }),
            page.keyboard.press('Alt+x'),
          ]);
          return { observation: 'Alt+S/D/P/C/X pressed their buttons', expected: 'mnemonics' };
        }),
    ),
    C(
      'keys.account-enter-unknown',
      'T17',
      'read-only',
      'MSG_KeyDown :2326 an unknown AcCode opens the help, :2337 the row does not advance; cancelling leaves the editor in the cell',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await fillHeader(page, {
            code: 'Z32',
            name: 'Zeta Unknown',
            short: 'ZU',
            family: 'ITEM SALES',
          });
          const box = label(page, 'AcCode row 2');
          await box.fill('99999');
          await box.press('Enter');
          await page.locator('[data-lookup-open="true"]').waitFor();
          await waitFocus(page, 'AcCode row 2');
          await box.press('Escape');
          await waitFocus(page, 'AcCode row 2');
          assert.equal(await box.inputValue(), '99999');
          return { observation: 'help opened, the cell kept the cursor', expected: 'no advance' };
        }),
    ),
    // ---------------------------------------------------------------- T18 Journeys
    C(
      'journey.sales-slots',
      'T18',
      'mutation',
      'A SALES book made on the screen with M1 to M4 in slots 1 to 4; the sale posts slot 1 as the bill control, slot 2 the cash, slot 3 the kasar (sales.ts readers, cases.md T18 preface); the book is offered to the Sales voucher',
      async (ctx) =>
        withBooks(ctx, () =>
          withMarkers(ctx, async () => {
            const { page } = await ctx.session();
            await createOnScreen(
              page,
              { code: 'JS1', name: 'Journey Sales', short: 'JS1', family: 'SALES' },
              { 1: M[0], 2: M[1], 3: M[2], 4: M[3] },
            );
            const help = JSON.stringify(
              await (await page.request.get('/api/context/books')).json(),
            );
            assert.ok(help.includes('"JS1"'), 'the Sales voucher offers JS1');
            // Posted through the Sales screen's own API (POST /api/sales), as the voucher form sends it.
            const vch = await postSale(page, 'JS1');
            const legs = await legsOf(ctx, 'JS1', vch);
            balanced(legs);
            noProvisioned(legs);
            assert.equal(legs.find((l) => l.ac === PARTIES.local.code && l.dr === 1000)?.ld, M[0]);
            assert.deepEqual(
              legs.filter((l) => l.ac === M[1]).map((l) => l.dr),
              [995],
            );
            assert.deepEqual(
              legs.filter((l) => l.ac === M[2]).map((l) => l.dr),
              [5],
            );
            return {
              observation: `sale ${vch} posted through the API the Sales screen uses: control ${M[0]}, cash ${M[1]}, kasar ${M[2]}`,
              expected: { control: M[0], cash: 995, kasar: 5 },
              database: { legs, slots: await slotRows(ctx, 'JS1') },
              downstream: { vch },
            };
          }),
        ),
    ),
    C(
      'journey.sales-edit-slot-then-repost',
      'T18',
      'mutation',
      'A slot change moves only later postings: voucher 1 keeps its legs, voucher 2 uses the new account (D1; MS_BOOK.cs:2662)',
      async (ctx) =>
        withBooks(ctx, () =>
          withMarkers(ctx, async () => {
            const { page } = await ctx.session();
            await apiBook(page, 'JS1', 'Journey Sales', 'SALES', [
              [1, M[0]],
              [2, M[1]],
              [3, M[2]],
              [4, M[3]],
            ]);
            const first = await postSale(page, 'JS1');
            const one = await legsOf(ctx, 'JS1', first);
            await openScreen(page);
            await openBook(page, 'JS1');
            await setAccount(page, 2, M[4]);
            const response = await save(page);
            assert.equal(response.status(), 200, await response.text());
            await saved(page);
            const second = await postSale(page, 'JS1');
            const two = await legsOf(ctx, 'JS1', second);
            assert.deepEqual(
              two.filter((l) => l.ac === M[4]).map((l) => l.dr),
              [995],
            );
            assert.deepEqual(await legsOf(ctx, 'JS1', first), one);
            return {
              observation: `sale ${first} kept ${M[1]}; sale ${second} posted cash to ${M[4]}`,
              expected: { first: M[1], second: M[4] },
              database: { one, two },
              downstream: { first, second },
            };
          }),
        ),
    ),
    C(
      'journey.purchase-slots',
      'T18',
      'mutation',
      'A PURCHASE book made on the screen with M1 to M4 and slot 5 the template DISCOUNT (MS_UPDATE.cs:25022); the purchase posts slot 1 control, 2 cash, 3 round-off/kasar (purchase.ts readers)',
      async (ctx) =>
        withBooks(ctx, () =>
          withMarkers(ctx, async () => {
            const { page } = await ctx.session();
            await createOnScreen(
              page,
              { code: 'JP1', name: 'Journey Purchase', short: 'JP1', family: 'PURCHASE' },
              { 1: M[0], 2: M[1], 3: M[2], 4: M[3] },
            );
            const slots = await slotRows(ctx, 'JP1');
            assert.ok(
              slots.some((s) => s.sr === 5),
              'slot 5 from the template',
            );
            const response = await page.request.post('/api/purchases', {
              data: { ...saleBody('JP1'), kasarAmount: undefined, kasar: 5 },
            });
            assert.equal(response.status(), 201, await response.text());
            const vch = String((await response.json()).vchNo).padStart(5, '0');
            const legs = await legsOf(ctx, 'JP1', vch);
            balanced(legs);
            noProvisioned(legs);
            assert.equal(legs.find((l) => l.ac === PARTIES.local.code && l.cr === 1000)?.ld, M[0]);
            assert.deepEqual(
              legs.filter((l) => l.ac === M[1]).map((l) => l.cr),
              [995],
            );
            return {
              observation: `purchase ${vch} posted through POST /api/purchases on JP1's slots`,
              expected: { control: M[0], cash: 995 },
              database: { legs, slots },
              downstream: { vch },
            };
          }),
        ),
    ),
    C(
      'journey.cashbank-slots',
      'T18',
      'mutation',
      'A CASH REC book made on the screen: receipt 5,000.00 with kasar 50.00 posts slot 1 Dr 5,000 and slot 2 Dr 50 (finance.ts readers; Ac_Ledr.cs:567-581); a BANK PAY book settles on its slot 1',
      async (ctx) =>
        withBooks(ctx, () =>
          withMarkers(ctx, async () => {
            const { page } = await ctx.session();
            await createOnScreen(
              page,
              {
                code: 'JC1',
                name: 'Journey Cash Rec',
                short: 'JC1',
                family: 'CASH REC',
                inout: 'I',
              },
              { 1: M[0], 2: M[1] },
            );
            const rec = await page.request.post('/api/receipts', {
              data: {
                coBook: 'JC1',
                partyAc: PARTIES.local.code,
                amount: 5000,
                kasar: 50,
                mode: 'cash',
              },
            });
            assert.equal(rec.status(), 201, await rec.text());
            const legs = (await legsOf(ctx, 'JC1')).map(({ ac, dr, cr }) => ({ ac, dr, cr }));
            assert.deepEqual(legs, [
              { ac: PARTIES.local.code, dr: 0, cr: 5000 },
              { ac: M[0], dr: 5000, cr: 0 },
              { ac: PARTIES.local.code, dr: 0, cr: 50 },
              { ac: M[1], dr: 50, cr: 0 },
            ]);
            await apiBook(page, 'JC2', 'Journey Bank Pay', 'BANK PAY', [
              [1, M[3]],
              [2, M[2]],
            ]);
            const pay = await page.request.post('/api/payments', {
              data: { coBook: 'JC2', partyAc: PARTIES.local.code, amount: 700, mode: 'bank' },
            });
            assert.equal(pay.status(), 201, await pay.text());
            const paid = await legsOf(ctx, 'JC2');
            balanced(paid);
            noProvisioned(paid);
            assert.deepEqual(
              paid.filter((l) => l.ac === M[3]).map((l) => l.cr),
              [700],
            );
            return {
              observation:
                "receipt and payment posted through POST /api/receipts and /api/payments on the books' slots",
              expected: { receipt: [M[0], M[1]], payment: M[3] },
              database: { legs, paid },
              downstream: { books: ['JC1', 'JC2'] },
            };
          }),
        ),
    ),
    C(
      'journey.contra-slots',
      'T18',
      'mutation',
      'A CONTRA book with M1/M2 slots: a contra of 2,000.00 posts the accounts the voucher names, never the provisioned CON slot accounts; debits equal credits',
      async (ctx) =>
        withBooks(ctx, () =>
          withMarkers(ctx, async () => {
            const { page } = await ctx.session();
            await createOnScreen(
              page,
              { code: 'JK1', name: 'Journey Contra', short: 'JK1', family: 'CONTRA' },
              { 1: M[0], 2: M[1] },
            );
            const response = await page.request.post('/api/contra', {
              data: {
                coBook: 'JK1',
                vchDate: today(),
                lines: [
                  { crdr: 'DR', acCode: M[3], amount: 2000 },
                  { crdr: 'CR', acCode: M[4], amount: 2000 },
                ],
              },
            });
            assert.equal(response.status(), 201, await response.text());
            const legs = await legsOf(ctx, 'JK1');
            balanced(legs);
            noProvisioned(legs);
            assert.ok(legs.some((l) => l.ac === M[3] && l.dr === 2000));
            assert.ok(legs.some((l) => l.ac === M[4] && l.cr === 2000));
            return {
              observation: 'contra posted through POST /api/contra in JK1',
              expected: { dr: M[3], cr: M[4] },
              database: { legs },
              downstream: { book: 'JK1' },
            };
          }),
        ),
    ),
    C(
      'journey.blank-slot-voucher-refused',
      'T18',
      'refusal',
      'D5: the screen saves a blank slot 2; the cash sale needing it is refused and writes nothing (bookPolicy.ts:124 fails closed)',
      async (ctx) =>
        withBooks(ctx, () =>
          withMarkers(ctx, async () => {
            const { page } = await ctx.session();
            await createOnScreen(
              page,
              { code: 'JB1', name: 'Journey Blank', short: 'JB1', family: 'SALES' },
              { 1: M[0], 2: '', 3: M[2] },
            );
            const before = await ctx.rows(
              `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1`,
            );
            const response = await page.request.post('/api/sales', { data: saleBody('JB1') });
            assert.equal(response.status(), 400, await response.text());
            const after = await ctx.rows(
              `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1`,
            );
            assert.deepEqual(after, before);
            return {
              observation: 'the sale was refused; nothing posted',
              expected: 400,
              database: { before, after },
            };
          }),
        ),
    ),
    C(
      'journey.family-change-refused-after-voucher',
      'T18',
      'refusal',
      'D4 after a posted sale: the family change is refused with the plain web text; slots and legs unchanged (MS_BOOK.cs:2933 would replace the slots)',
      async (ctx) =>
        withBooks(ctx, () =>
          withMarkers(ctx, async () => {
            const { page } = await ctx.session();
            await apiBook(page, 'JS1', 'Journey Sales', 'SALES', [
              [1, M[0]],
              [2, M[1]],
              [3, M[2]],
              [4, M[3]],
            ]);
            const vch = await postSale(page, 'JS1');
            const legs = await legsOf(ctx, 'JS1', vch);
            const before = await footprint(ctx);
            await openScreen(page);
            await openBook(page, 'JS1');
            await chooseFamily(page, 'PURCHASE');
            await button(page, 'Save').click();
            await message(page, FAMILY_LOCKED);
            assert.deepEqual(await footprint(ctx), before);
            assert.deepEqual(await legsOf(ctx, 'JS1', vch), legs);
            return {
              observation: 'refused with the D4 text',
              expected: FAMILY_LOCKED,
              database: { legs },
            };
          }),
        ),
    ),
    C(
      'journey.delete-after-voucher',
      'T18',
      'mutation',
      'MS_BOOK.cs:2710 refused while the sale exists; after the sale is deleted, :2723 "Delete Success." and no slot rows remain',
      async (ctx) =>
        withBooks(ctx, () =>
          withMarkers(ctx, async () => {
            const { page } = await ctx.session();
            await apiBook(page, 'JS1', 'Journey Sales', 'SALES', [
              [1, M[0]],
              [2, M[1]],
              [3, M[2]],
            ]);
            const vch = await postSale(page, 'JS1');
            await openScreen(page);
            await openBook(page, 'JS1');
            await button(page, 'Delete').click();
            await message(page, USED_IN_ACCOUNTS);
            const read = await page.request.get(`/api/sales/${vch}?coBook=JS1`);
            const version = (await read.json()).version;
            const removed = await page.request.delete(
              `/api/sales/${vch}?coBook=JS1&expectedVersion=${encodeURIComponent(version)}`,
            );
            assert.equal(removed.status(), 200, await removed.text());
            await openScreen(page);
            await openBook(page, 'JS1');
            answerQuestions(page, true);
            await button(page, 'Delete').click();
            await message(page, DELETED);
            const slots = await slotRows(ctx, 'JS1');
            assert.deepEqual(slots, []);
            return {
              observation: 'refused, then deleted after the sale was deleted',
              expected: DELETED,
              database: { slots },
              downstream: { vch },
            };
          }),
        ),
    ),
    C(
      'journey.regression-modules',
      'T18',
      'read-only',
      'The Books change adds or removes no slot of a provisioned book: each one reopens with exactly its BOOK_DETL accounts (the posting modules salesInvoice, purchaseInvoice, cashBank, contraEntry, salesOrder and tagCancel run as their own modules in the same suite)',
      async (ctx) =>
        withBooks(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          const checked = {};
          for (const code of ['SL', 'PR', 'RCT', 'PAY', 'CON', 'SOR']) {
            const stored = (await slotRows(ctx, code)).map((s) => [s.sr, s.ac]);
            const shown = (await (await page.request.get(`/api${API}/${code}`)).json()).slots
              .filter((s) => stored.some(([sr]) => sr === s.srNo))
              .map((s) => [s.srNo, s.acCode]);
            assert.deepEqual(shown, stored, code);
            checked[code] = stored.length;
          }
          return {
            observation: `provisioned books reopen with their slots: ${JSON.stringify(checked)}`,
            expected: 'unchanged slots',
          };
        }),
    ),
    blocked(
      'journey.tag-split-slots',
      'T18',
      'MS_UPDATE.cs:32098-32110 TAG SPLIT slots 6 to 9',
      'blocked: the desktop posting code that reads Tag Split slots 6 to 9 is not in the study; unblocks when the Tag Split study (another work package) states which leg uses which slot.',
    ),
  ],
};

/** The marker accounts are part of withBooks's ACCOUNTS; this keeps the journeys' intent explicit. */
async function withMarkers(ctx, run) {
  const missing = await ctx.rows(
    `SELECT unnest($2::text[]) code EXCEPT SELECT "AC_CODE" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
    M,
  );
  assert.deepEqual(missing, [], 'the marker accounts exist');
  return run();
}
