import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, PARTIES, USERS, sentinelSnapshot } from '../fixtures/catalogue.mjs';

/**
 * Feature: ExtraTran → Fine Jv Entry (desktop TR_CONTRA in FINE JV mode, web /txn/fine-jv).
 *
 * Desktop authority used for the independently computed expectations:
 * - MDI_FORM.cs:8360-8365 opens TR_CONTRA only after CurBookHelp('FINE JV').
 * - TR_CONTRA.cs:1426-1446 — the grid columns Sr, Cr/Dr, AcCode, Ac Name, It Desc, CrFine, DrFine; :1530-1545 row 1
 *   is DR and a new row takes the other side; :2329-2343 Item Type (Gold/Silver); 0.000 fine (:1509-1512).
 * - TR_CONTRA.cs:2760-2847 — row i is written first (LDR_TYPE 0, own side and description, LD_CODE row 1) and row 1 is
 *   mirrored against it (LDR_TYPE 1, the opposite fine, row 1's description).
 * - Ac_Ledr.cs:846-848 keys CR_FINE legs STR(SR_NO)+'03' (+) and DR_FINE legs STR(SR_NO)+'04' (-); STR() is 10 wide,
 *   so a key is 33 characters. Ac_Rojmel.cs:342-344 projects the same rows.
 * - Ac_Tax.cs:686-694 (Vch_Remark mode 3, TR_CONTRA.cs:2890) rebuilds REMARK_DATA from rows with a description.
 * - TR_CONTRA.cs:2680-2697 refuses a date outside the current year and unequal Cr/Dr totals with its own messages.
 * - TR_CONTRA.cs:2961-2968 audits every source row, then removes remarks, identity, ledger, day book and source rows.
 * - TR_CONTRA.cs:3000-3004 needs UserPrint; :3021/:3061-3069 print FineJvBill.RPT.
 */
const BOOK = 'FJV';
const BOOK_NAME = 'Fine JV';
const FROM = PARTIES.local;
const TO = PARTIES.interState;
const THIRD = PARTIES.bank;
const STR = (n) => String(n).padStart(10, ' ');
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const OUT_OF_YEAR = `${startYear - 1}-12-31`;
const pad2 = (n) => String(n).padStart(2, '0');
const todayLocal = () => `${now.getFullYear()}-${pad2(now.getMonth() + 1)}-${pad2(now.getDate())}`;
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `fine-jv.${id}`,
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
const blocked = (name, group, reason) => ({
  ...C(`${name}.pending`, group, 'read-only', `Playbook ${group}`, async () => ({})),
  blocked: reason,
});
const notApplicable = (name, group, source, reason) => ({
  ...C(`${name}.not-applicable`, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});
const isApi = (response, method, path) =>
  response.request().method() === method && new URL(response.url()).pathname === `/api${path}`;
const label = (page, text) => page.getByLabel(text, { exact: true });

async function openFineJv(page) {
  await page.goto('/txn/fine-jv');
  await page.getByRole('heading', { name: 'Fine Jv Entry', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let attempt = 0; attempt < 50 && (await book.isDisabled()); attempt++)
    await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), BOOK, 'provisioned Fine JV book auto-selected');
  return book;
}

async function pickAccount(page, row, code) {
  const input = label(page, `AcCode row ${row}`);
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await input.press('Enter');
}

/** Fill the TR_CONTRA grid; `code: null` types nothing, `typed` types a code without picking it. */
async function fillGrid(page, rows, { metal } = {}) {
  for (let i = 2; i < rows.length; i++)
    await page.getByRole('button', { name: '+ Add line', exact: true }).click();
  for (const [index, row] of rows.entries()) {
    const n = index + 1;
    await label(page, `Cr/Dr row ${n}`).selectOption(row.crdr);
    if (row.typed) await label(page, `AcCode row ${n}`).fill(row.typed);
    else if (row.code) await pickAccount(page, n, row.code);
    if (row.desc !== undefined) await label(page, `It Desc row ${n}`).fill(row.desc);
    await label(page, `Fine row ${n}`).fill(String(row.fine));
  }
  if (metal) await label(page, 'Item Type').selectOption(metal);
}

const twoRows = ({ from = FROM.code, to = TO.code, fine = '12.3456', fromDesc, toDesc } = {}) => [
  { crdr: 'DR', code: from, fine, desc: fromDesc },
  { crdr: 'CR', code: to, fine, desc: toDesc },
];

async function save(page, expectedMethod = 'POST') {
  const [response] = await Promise.all([
    page.waitForResponse((response) => {
      const pathname = new URL(response.url()).pathname;
      return (
        response.request().method() === expectedMethod &&
        (expectedMethod === 'POST'
          ? pathname === '/api/fine-jv'
          : /^\/api\/fine-jv\/\d+$/.test(pathname))
      );
    }),
    page.locator('button[data-save-mnemonic]').click(),
  ]);
  return response;
}

async function create(page, rows = twoRows(), options = {}) {
  await openFineJv(page);
  await fillGrid(page, rows, options);
  const response = await save(page);
  assert.equal(response.status(), 201, await response.text());
  const { vchNo } = await response.json();
  const formatted = String(vchNo).padStart(5, '0');
  await page.getByText(`Posted — Fine JV #${vchNo}`, { exact: true }).waitFor();
  return formatted;
}

async function load(page, vchNo) {
  await page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
  const row = page.locator('table.grid tr', { hasText: vchNo }).last();
  await row.getByRole('button', { name: 'Load', exact: true }).click();
  await page.getByRole('button', { name: `Update #${vchNo}`, exact: true }).waitFor();
}

async function gridValues(page) {
  const count = await page.locator('select[aria-label^="Cr/Dr row "]').count();
  const rows = [];
  for (let n = 1; n <= count; n++)
    rows.push({
      crdr: await label(page, `Cr/Dr row ${n}`).inputValue(),
      code: await label(page, `AcCode row ${n}`).inputValue(),
      desc: await label(page, `It Desc row ${n}`).inputValue(),
      fine: await label(page, `Fine row ${n}`).inputValue(),
    });
  return rows;
}

const sourceRows = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"AC_CODE" ac,coalesce("AC_NAME",'') name,"LD_CODE" ld,"CRDR_TYPE" crdr,"LDR_TYPE" ldr,
            coalesce("CR_FINE",0)::float crfine,coalesce("DR_FINE",0)::float drfine,"IT_TYPE" metal,
            coalesce("IT_DESC",'') "desc","VCH_TYPE" vtype,coalesce("INOUT_TYPE",'') inout,
            coalesce("ENTRY_TYPE",'') entry,coalesce("BOOK_NAME",'') book,coalesce("HD_VCH_NO",'') hidden,
            coalesce("MAIN_USER",'') mainuser
       FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    vchNo,
  );
const ledgerRows = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "LEDR_KEY" key,length("LEDR_KEY")::int len,right("LEDR_KEY",2) leg,"AC_CODE" ac,"LD_CODE" ld,
            "SIGN" sign,"IT_TYPE" metal,coalesce("FINE_WT",0)::float fine,coalesce("DR_AMT",0)::float dr,
            coalesce("CR_AMT",0)::float cr,coalesce("BOOK_NAME",'') book,coalesce("HD_VCH_NO",'') hidden,
            coalesce("MAIN_USER",'') mainuser
       FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
    vchNo,
  );
const rojmelRows = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "AC_CODE" ac,"LD_CODE" ld,"SIGN" sign,"IT_TYPE" metal,
            coalesce("ITM_FINE",0)::float fine,coalesce("DR_AMT",0)::float dr,coalesce("CR_AMT",0)::float cr,
            coalesce("ITM_GWT",0)::float gross
       FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
    vchNo,
  );
const remarkRows = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"AC_CODE" ac,coalesce("AC_NAME",'') name,coalesce("MAIN_BOOK",'') main,
            coalesce("VCH_REMARK",'') remark
       FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    vchNo,
  );
const deleteRows = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"AC_CODE" ac,"DELETE_USER" deleteuser,"MAIN_USER" mainuser,
            coalesce("VCH_FINE_CR",0)::float crfine,coalesce("VCH_FINE_DR",0)::float drfine
       FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    vchNo,
  );
const countRows = (ctx) =>
  ctx
    .rows(
      `SELECT
       (SELECT count(*)::int FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}') source,
       (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}') ledger,
       (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}') rojmel,
       (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}') remarks`,
    )
    .then(([row]) => row);

const accountName = (code) =>
  Object.values(PARTIES).find((party) => party.code === code)?.name ?? code;

function expectedSource({ from, to, fine, metal, mainuser, fromDesc = '', toDesc = '' }) {
  const base = { metal, vtype: 'FJV', inout: 'I', entry: 'J', book: 'FINE JV', mainuser };
  return [
    {
      sr: 1,
      ac: to,
      name: accountName(to),
      ld: from,
      crdr: 'CR',
      ldr: '0',
      crfine: fine,
      drfine: 0,
      desc: toDesc,
      ...base,
    },
    {
      sr: 2,
      ac: from,
      name: accountName(from),
      ld: to,
      crdr: 'DR',
      ldr: '1',
      crfine: 0,
      drfine: fine,
      desc: fromDesc,
      ...base,
    },
  ];
}
function expectedProjection({ from, to, fine, metal }) {
  return [
    { ac: to, ld: from, sign: '+', metal, fine, dr: 0, cr: 0 },
    { ac: from, ld: to, sign: '-', metal, fine, dr: 0, cr: 0 },
  ];
}

const plainLedger = (rows) =>
  rows.map(
    ({
      key: _key,
      len: _len,
      leg: _leg,
      book: _book,
      hidden: _hidden,
      mainuser: _mainuser,
      ...row
    }) => row,
  );

function assertLedgerIdentity(rows, vchNo) {
  assert.deepEqual(
    rows.map((row) => [row.len, row.book, row.hidden, row.mainuser]),
    rows.map(() => [33, 'FINE JV', vchNo, USERS.admin.user]),
  );
  rows.forEach((row) =>
    assert(
      String(row.key).endsWith(
        `${vchNo}${STR(rows.indexOf(row) + 1)}${row.sign === '+' ? '03' : '04'}`,
      ),
      `ledger key ${JSON.stringify(row.key)} is VCH_NO + STR(SR_NO) + leg`,
    ),
  );
}

/** Same-origin API calls from the signed-in browser page (session cookie and headers included). */
const browserFetch = (page, method, url) =>
  page.evaluate(
    async ({ method: m, url: u }) => {
      const response = await fetch(u, { method: m, credentials: 'include' });
      return { status: response.status, body: await response.text() };
    },
    { method, url },
  );

export const fineJv = {
  feature: 'fine-jv',
  title: 'ExtraTran → Fine Jv Entry (TR_CONTRA, FINE JV)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/fine-jv/page.tsx',
    'web/apps/api/src/modules/finance/fineJv.ts',
    'web/apps/api/src/modules/finance/contraVoucher.ts',
    'web/apps/api/src/modules/finance/journal.ts',
    'web/apps/api/src/routes/fineJv.ts',
    'web/apps/api/src/routes/txn.ts',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
    'web/apps/web/test/features/modules/fineJv.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.fine-jv-book-and-defaults',
      'T01',
      'read-only',
      "MDI_FORM.cs:8360-8365 opens CurBookHelp('FINE JV'); TR_CONTRA.cs:1530-1545 starts row 1 DR and row 2 CR; :2329-2343 shows Item Type Gold; the date is today.",
      async (ctx) => {
        const { page } = await ctx.session();
        const book = await openFineJv(page);
        const optionValues = await book
          .locator('option')
          .evaluateAll((options) => options.map((option) => option.getAttribute('value')));
        assert.deepEqual(optionValues, ['', BOOK], 'only the FINE JV book is offered');
        assert.equal(await label(page, 'Item Type').inputValue(), 'G');
        assert.equal(await label(page, 'Vch Date').inputValue(), todayLocal());
        const sides = (await gridValues(page)).map((row) => row.crdr);
        assert.deepEqual(sides, ['DR', 'CR']);
        assert.ok(await page.locator('button[data-save-mnemonic]').isDisabled());
        await ctx.shot(page, 'entry');
        return {
          observation: `book options ${optionValues.join('/')}, Gold, rows ${sides.join('/')}, Save disabled`,
          expected: `only ${BOOK}, Gold, today's date, rows DR/CR, disabled Save`,
        };
      },
    ),
    C(
      'book.family-isolated',
      'T02',
      'read-only',
      "MDI_FORM.cs:8361 calls CurBookHelp('FINE JV'), so a journal, sales or other CONTRA_DATA book cannot be selected by this menu.",
      async (ctx) => {
        const { page } = await ctx.session();
        const book = await openFineJv(page);
        const values = await book
          .locator('option')
          .evaluateAll((options) =>
            options.map((option) => option.getAttribute('value')).filter(Boolean),
          );
        assert.deepEqual(values, [BOOK]);
        return { observation: `visible books ${values.join(', ')}`, expected: BOOK };
      },
    ),
    C(
      'formula.three-decimal-fine',
      'T03',
      'mutation',
      'TR_CONTRA.cs:1509-1512 and :1689-1692 format FINE JV fine fields as 0.000; 12.3456 therefore persists as 12.346.',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await create(page, twoRows({ fine: '12.3456' }));
        const rows = await sourceRows(ctx, vchNo);
        assert.deepEqual(
          rows.map((row) => [row.crfine, row.drfine]),
          [
            [12.346, 0],
            [0, 12.346],
          ],
        );
        return {
          observation: `voucher ${vchNo}: ${JSON.stringify(rows.map((row) => [row.crfine, row.drfine]))}`,
          expected: '12.346 credit and 12.346 debit',
          database: { rows },
          downstream: { fineTransferred: 12.346 },
        };
      },
    ),
    C(
      'refusal.unequal-totals-no-write',
      'T04',
      'refusal',
      'TR_CONTRA.cs:2692-2697: "You Cant Save This Voucher Becouse Cr Value and Dr Value is not same...." and nothing is saved.',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await countRows(ctx);
        await openFineJv(page);
        await fillGrid(page, [
          { crdr: 'DR', code: FROM.code, fine: '5' },
          { crdr: 'CR', code: TO.code, fine: '4' },
        ]);
        assert.equal(await page.getByLabel('CrFine total').textContent(), '4.000');
        assert.equal(await page.getByLabel('DrFine total').textContent(), '5.000');
        const response = await save(page);
        assert.equal(response.status(), 400, await response.text());
        const message = 'You Cant Save This Voucher Becouse Cr Value and Dr Value is not same....';
        await page.getByRole('alert').filter({ hasText: message }).waitFor();
        const after = await countRows(ctx);
        assert.deepEqual(after, before);
        return {
          observation: 'unequal 5.000 / 4.000 refused with the desktop message; no rows written',
          expected: 'desktop message and no business write',
          database: { before, after },
        };
      },
    ),
    C(
      'refusal.unknown-account-no-write',
      'T04',
      'refusal',
      'TR_CONTRA account help resolves AC_MAST; a typed code with no account may not create a paired ledger row.',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await countRows(ctx);
        await openFineJv(page);
        await fillGrid(page, [
          { crdr: 'DR', typed: 'NOFROM', fine: '4.5' },
          { crdr: 'CR', code: TO.code, fine: '4.5' },
        ]);
        const response = await save(page);
        assert.equal(response.status(), 400, await response.text());
        const after = await countRows(ctx);
        assert.deepEqual(after, before);
        return {
          observation: 'an unknown row-1 account is refused by the real route; nothing was written',
          expected: '400 and no business write',
          database: { before, after },
        };
      },
    ),
    C(
      'refusal.date-outside-year-no-write',
      'T04',
      'refusal',
      'TR_CONTRA.cs:2680-2685: "You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date..."',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await countRows(ctx);
        await openFineJv(page);
        await fillGrid(page, twoRows({ fine: '1.5' }));
        await label(page, 'Vch Date').fill(OUT_OF_YEAR);
        const response = await save(page);
        assert.equal(response.status(), 400, await response.text());
        const message =
          'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...';
        await page.getByRole('alert').filter({ hasText: message }).waitFor();
        const after = await countRows(ctx);
        assert.deepEqual(after, before);
        return {
          observation: `${OUT_OF_YEAR} refused with the desktop message; nothing written`,
          expected: 'desktop message and no business write',
          database: { before, after },
        };
      },
    ),
    C(
      'create.desktop-write-set',
      'T05',
      'mutation',
      'TR_CONTRA.cs:2760-2847, Ac_Ledr.cs:846-848, Ac_Rojmel.cs:342-344 and Ac_Tax.cs:686-694: the CR_FINE/+ receiver and DR_FINE/- giver, 33-character keys and one remark per described row.',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await create(
          page,
          twoRows({ fine: '7.125', fromDesc: 'gold given', toDesc: 'gold received' }),
          { metal: 'G' },
        );
        const source = await sourceRows(ctx, vchNo);
        const ledger = await ledgerRows(ctx, vchNo);
        const rojmel = await rojmelRows(ctx, vchNo);
        const remarks = await remarkRows(ctx, vchNo);
        const expected = expectedSource({
          from: FROM.code,
          to: TO.code,
          fine: 7.125,
          metal: 'G',
          mainuser: USERS.admin.user,
          fromDesc: 'gold given',
          toDesc: 'gold received',
        });
        assert.deepEqual(
          source.map(({ hidden: _hidden, ...row }) => row),
          expected,
          JSON.stringify(source),
        );
        assert(
          source.every((row) => row.hidden === vchNo),
          'source rows carry the hidden number',
        );
        const projection = expectedProjection({
          from: FROM.code,
          to: TO.code,
          fine: 7.125,
          metal: 'G',
        });
        assert.deepEqual(plainLedger(ledger), projection);
        assertLedgerIdentity(ledger, vchNo);
        assert.deepEqual(
          rojmel,
          projection.map((row) => ({ ...row, gross: 0 })),
        );
        assert.deepEqual(remarks, [
          { sr: 1, ac: TO.code, name: TO.name, main: 'FINE JV', remark: 'gold received' },
          { sr: 2, ac: FROM.code, name: FROM.name, main: 'FINE JV', remark: 'gold given' },
        ]);
        await ctx.shot(page, 'posted');
        return {
          observation: `voucher ${vchNo}: two CONTRA_DATA rows, two 33-character legs, two day-book rows, two remarks`,
          expected: { source: expected, projection },
          database: { source, ledger, rojmel, remarks },
          downstream: { ledger, rojmel, remarks },
        };
      },
    ),
    C(
      'create.multi-account-grid',
      'T05',
      'mutation',
      'TR_CONTRA.cs:2760-2847 pairs row 1 with each later row: three grid rows write four CONTRA_DATA rows and four legs; :2467-2565 reopens three rows.',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await create(page, [
          { crdr: 'DR', code: FROM.code, fine: '5', desc: 'pooled' },
          { crdr: 'CR', code: TO.code, fine: '3', desc: 'first share' },
          { crdr: 'CR', code: THIRD.code, fine: '2' },
        ]);
        const source = await sourceRows(ctx, vchNo);
        assert.deepEqual(
          source.map((row) => [row.sr, row.ac, row.ld, row.crdr, row.ldr, row.crfine, row.drfine]),
          [
            [1, TO.code, FROM.code, 'CR', '0', 3, 0],
            [2, FROM.code, TO.code, 'DR', '1', 0, 3],
            [3, THIRD.code, FROM.code, 'CR', '0', 2, 0],
            [4, FROM.code, THIRD.code, 'DR', '1', 0, 2],
          ],
        );
        const ledger = await ledgerRows(ctx, vchNo);
        assert.deepEqual(
          ledger.map((row) => [row.ac, row.sign, row.fine]),
          [
            [TO.code, '+', 3],
            [FROM.code, '-', 3],
            [THIRD.code, '+', 2],
            [FROM.code, '-', 2],
          ],
        );
        assertLedgerIdentity(ledger, vchNo);
        const remarks = await remarkRows(ctx, vchNo);
        assert.deepEqual(
          remarks.map((row) => [row.sr, row.remark]),
          [
            [1, 'first share'],
            [2, 'pooled'],
            [4, 'pooled'],
          ],
        );
        await load(page, vchNo);
        const grid = await gridValues(page);
        assert.deepEqual(grid, [
          { crdr: 'DR', code: FROM.code, desc: 'pooled', fine: '5.000' },
          { crdr: 'CR', code: TO.code, desc: 'first share', fine: '3.000' },
          { crdr: 'CR', code: THIRD.code, desc: '', fine: '2.000' },
        ]);
        await ctx.shot(page, 'multi-account');
        return {
          observation: `voucher ${vchNo}: 4 source rows, 4 legs, 3 remarks; reopened as 3 grid rows`,
          expected: 'row 1 paired with rows 2 and 3, reopened unchanged',
          database: { source, ledger, remarks },
          downstream: { grid },
        };
      },
    ),
    notApplicable(
      'settlement',
      'T06',
      'TR_CONTRA FINE JV branch writes CR_FINE/DR_FINE and zeros money (TR_CONTRA.cs:2784-2790, :2836-2850).',
      'Fine JV has no cash, bank, cheque, card, UPI or bill-allocation branch.',
    ),
    C(
      'reopen.lossless',
      'T07',
      'mutation',
      'TR_CONTRA.cs:2430-2565 reloads Item Type and the LDR_TYPE 1 and 0 rows, with names, descriptions and 0.000 fines.',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await create(
          page,
          twoRows({ fine: '6.875', fromDesc: 'silver out', toDesc: 'silver in' }),
          { metal: 'S' },
        );
        await load(page, vchNo);
        const grid = await gridValues(page);
        assert.deepEqual(grid, [
          { crdr: 'DR', code: FROM.code, desc: 'silver out', fine: '6.875' },
          { crdr: 'CR', code: TO.code, desc: 'silver in', fine: '6.875' },
        ]);
        assert.equal(await label(page, 'Item Type').inputValue(), 'S');
        const entryGrid = page.locator('form table.grid');
        await entryGrid.getByRole('cell', { name: FROM.name, exact: true }).waitFor();
        await entryGrid.getByRole('cell', { name: TO.name, exact: true }).waitFor();
        return {
          observation: `reopened ${vchNo}: ${JSON.stringify(grid)}, Silver`,
          expected: 'every grid field round-trips',
          database: { source: await sourceRows(ctx, vchNo) },
          downstream: { loaded: vchNo },
        };
      },
    ),
    C(
      'edit.unchanged-write-set',
      'T08',
      'mutation',
      'TR_CONTRA.cs:2739-2890 replaces the same voucher write set without generating a delete audit on an unchanged Save.',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await create(page, twoRows({ fine: '8.25', toDesc: 'kept' }));
        await load(page, vchNo);
        const snapshot = async () => ({
          source: await sourceRows(ctx, vchNo),
          ledger: await ledgerRows(ctx, vchNo),
          rojmel: await rojmelRows(ctx, vchNo),
          remarks: await remarkRows(ctx, vchNo),
          audits: await deleteRows(ctx, vchNo),
        });
        const before = await snapshot();
        const response = await save(page, 'PUT');
        assert.equal(response.status(), 200, await response.text());
        const after = await snapshot();
        assert.deepEqual(after, before);
        return {
          observation: `unchanged update ${vchNo} retained its complete business footprint`,
          expected: 'no source, ledger, Rojmel, remark or audit change',
          database: { before, after },
          downstream: { unchanged: true },
        };
      },
    ),
    C(
      'edit.reprice-metal',
      'T09',
      'mutation',
      'TR_CONTRA.cs:2739-2890 removes and rebuilds the rows, ledger, day book and remarks on edit; the same CR_FINE/DR_FINE polarity applies to silver.',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await create(page, twoRows({ fine: '3.25', toDesc: 'old note' }));
        await load(page, vchNo);
        await pickAccount(page, 1, THIRD.code);
        await pickAccount(page, 2, FROM.code);
        await label(page, 'It Desc row 2').fill('new note');
        await label(page, 'Item Type').selectOption('S');
        await label(page, 'Fine row 1').fill('4.3214');
        await label(page, 'Fine row 2').fill('4.3214');
        const response = await save(page, 'PUT');
        assert.equal(response.status(), 200, await response.text());
        const source = await sourceRows(ctx, vchNo);
        const ledger = await ledgerRows(ctx, vchNo);
        const rojmel = await rojmelRows(ctx, vchNo);
        const remarks = await remarkRows(ctx, vchNo);
        const expected = expectedSource({
          from: THIRD.code,
          to: FROM.code,
          fine: 4.321,
          metal: 'S',
          mainuser: USERS.admin.user,
          toDesc: 'new note',
        });
        assert.deepEqual(
          source.map(({ hidden: _hidden, ...row }) => row),
          expected,
        );
        assert(
          source.every((row) => row.hidden === vchNo),
          'edited rows keep the hidden number',
        );
        const projection = expectedProjection({
          from: THIRD.code,
          to: FROM.code,
          fine: 4.321,
          metal: 'S',
        });
        assert.deepEqual(plainLedger(ledger), projection);
        assertLedgerIdentity(ledger, vchNo);
        assert.deepEqual(
          rojmel,
          projection.map((row) => ({ ...row, gross: 0 })),
        );
        assert.deepEqual(remarks, [
          { sr: 1, ac: FROM.code, name: FROM.name, main: 'FINE JV', remark: 'new note' },
        ]);
        return {
          observation: `edited ${vchNo} to 4.321 silver ${THIRD.code} -> ${FROM.code}; remark rebuilt`,
          expected: { source: expected, remarks: ['new note'] },
          database: { source, ledger, rojmel, remarks },
          downstream: { ledger, rojmel, remarks },
        };
      },
    ),
    C(
      'delete.audit-and-reversal',
      'T10',
      'mutation',
      'TR_CONTRA.cs:2961-2968 audits every source row with DELETE_USER, then removes the remarks, temporary identity, ledger, day book and source rows.',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await create(page, twoRows({ fine: '5.5', toDesc: 'to be deleted' }));
        assert.equal((await remarkRows(ctx, vchNo)).length, 1);
        await page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
        const row = page.locator('table.grid tr', { hasText: vchNo }).last();
        await Promise.all([
          page.waitForResponse((response) => isApi(response, 'DELETE', `/fine-jv/${vchNo}`)),
          row.getByRole('button', { name: 'Delete', exact: true }).click(),
        ]);
        const audits = await deleteRows(ctx, vchNo);
        assert.deepEqual(audits, [
          {
            sr: 1,
            ac: TO.code,
            deleteuser: USERS.admin.user,
            mainuser: USERS.admin.user,
            crfine: 5.5,
            drfine: 0,
          },
          {
            sr: 2,
            ac: FROM.code,
            deleteuser: USERS.admin.user,
            mainuser: USERS.admin.user,
            crfine: 0,
            drfine: 5.5,
          },
        ]);
        assert.deepEqual(await sourceRows(ctx, vchNo), []);
        assert.deepEqual(await ledgerRows(ctx, vchNo), []);
        assert.deepEqual(await rojmelRows(ctx, vchNo), []);
        assert.deepEqual(await remarkRows(ctx, vchNo), []);
        return {
          observation: `deleted ${vchNo}; two desktop-style audit rows retained, remark removed`,
          expected: 'two DELETE_DATA rows with the signed-in delete user and no active effects',
          database: { audits, source: [], ledger: [], rojmel: [], remarks: [] },
          downstream: { reversed: true },
        };
      },
    ),
    C(
      'scope.sentinel-tenant',
      'T11',
      'mutation',
      'Every Fine JV query carries the authenticated tenant and company/location/year/book scope; the feature sentinel has the same visible number in another tenant.',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await sentinelSnapshot(ctx.owner);
        const vchNo = await create(page, twoRows({ fine: '2.25' }));
        const after = await sentinelSnapshot(ctx.owner);
        assert.deepEqual(after, before);
        return {
          observation: `Fine JV ${vchNo} left the cross-tenant sentinel unchanged`,
          expected: 'cross-scope sentinel byte-for-byte unchanged',
          database: { before, after },
          downstream: { isolated: true },
        };
      },
    ),
    C(
      'rights.print-denied',
      'T11',
      'refusal',
      'TR_CONTRA.cs:3000-3004: a user without UserPrint may view the form but FineJvBill printing is refused.',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await create(page, twoRows({ fine: '2.75' }));
        const before = await sourceRows(ctx, vchNo);
        const viewer = await ctx.session(as(USERS.printViewer.user));
        await openFineJv(viewer.page);
        await viewer.page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
        const row = viewer.page.locator('table.grid tr', { hasText: vchNo }).last();
        const [printed] = await Promise.all([
          viewer.page.waitForEvent('popup'),
          row.getByRole('link', { name: 'Print', exact: true }).click(),
        ]);
        await printed.waitForURL(new RegExp(`coBook=${BOOK}`));
        await printed.waitForLoadState();
        const text = (await printed.locator('body').textContent()) ?? '';
        await printed.close();
        assert.match(text, /forbidden/i);
        assert.match(text, /print/i);
        const after = await sourceRows(ctx, vchNo);
        assert.deepEqual(after, before);
        return {
          observation: `view-allowed user was refused FineJvBill for ${vchNo} without changing it`,
          expected: 'print permission is required; source remains unchanged',
          database: { before, after },
        };
      },
    ),
    C(
      'rights.journal-routes-refuse-fine-jv-book',
      'T11',
      'refusal',
      'MDI_FORM.cs:8360-8365: only the Fine Jv Entry menu opens a FINE JV book, so the Journal routes sharing CONTRA_DATA refuse it.',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await create(page, twoRows({ fine: '1.75' }));
        const before = { source: await sourceRows(ctx, vchNo), counts: await countRows(ctx) };
        const answers = [];
        for (const [method, url] of [
          ['GET', `/api/journal/${vchNo}?coBook=${BOOK}`],
          ['DELETE', `/api/journal/${vchNo}?coBook=${BOOK}`],
          ['GET', `/api/journal/${vchNo}/print?coBook=${BOOK}&format=html`],
        ]) {
          const answer = await browserFetch(page, method, url);
          assert.equal(answer.status, 400, `${method} ${url} => ${answer.body}`);
          assert.match(answer.body, /MAIN_BOOK='JOURNAL'/);
          answers.push([method, url, answer.status]);
        }
        const after = { source: await sourceRows(ctx, vchNo), counts: await countRows(ctx) };
        assert.deepEqual(after, before);
        return {
          observation: `Journal read, delete and print refused the FINE JV voucher ${vchNo}: ${JSON.stringify(answers)}`,
          expected: "400 MAIN_BOOK='JOURNAL' and no change to the Fine JV voucher",
          database: { before, after },
        };
      },
    ),
    blocked(
      'concurrency',
      'T12',
      'Fine JV has no persisted version token or conditional update/delete yet, so two browser sessions cannot be asserted to reject a stale change.',
    ),
    blocked(
      'retry',
      'T13',
      'Fine JV POST has no idempotency-key contract yet, so a lost acknowledgement/double-submit case remains blocked rather than assumed safe.',
    ),
    blocked(
      'rollback',
      'T14',
      'The feature harness has no declared Fine JV mid-write transport or database fault injector (G173 / N166).',
    ),
    blocked(
      'settings-and-lock',
      'T15',
      'Employee-code mandatory, company type B and the lock date are covered through HTTP in fineJv.routes.db.test.ts and financeLifecycle.db.test.ts; the feature catalogue does not change company settings, so no browser settings matrix is frozen yet.',
    ),
    C(
      'print.fine-jv-bill',
      'T16',
      'output',
      "TR_CONTRA.cs:3021, :3061-3069 select FineJvBill.RPT: title 'Gold '/'Silver ' & BOOK_NAME, Party Name / Cr Fine / Dr Fine rows with their It Desc line, and the 'For : ' / 'Party signature.' / 'signature.' footer.",
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await create(page, twoRows({ fine: '7.125', toDesc: 'bill line note' }), {
          metal: 'G',
        });
        await page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
        const row = page.locator('table.grid tr', { hasText: vchNo }).last();
        const [printed] = await Promise.all([
          page.waitForEvent('popup'),
          row.getByRole('link', { name: 'Print', exact: true }).click(),
        ]);
        await printed.waitForURL(new RegExp(`coBook=${BOOK}`));
        await printed.waitForLoadState();
        const html = await printed.content();
        await ctx.shot(printed, 'fine-jv-bill');
        await printed.close();
        for (const text of [
          `Gold ${BOOK_NAME}`,
          'Party Name',
          'Cr Fine',
          'Dr Fine',
          '7.125',
          'bill line note',
          FROM.name,
          TO.name,
          'For : ',
          'Party signature.',
          '>signature.<',
        ])
          assert(html.includes(text), `FineJvBill shows ${text}`);
        for (const absent of ['Total', 'Authorised Signatory', 'Bank Details'])
          assert(!html.includes(absent), `FineJvBill has no ${absent}`);
        return {
          observation: `Fine JV ${vchNo} printed as Gold ${BOOK_NAME} with its description and signatures`,
          expected:
            'the FineJvBill title, columns, It Desc line and footer, with no total or bank block',
          output: Buffer.from(html),
        };
      },
    ),
    C(
      'keyboard.alt-s-saves',
      'T17',
      'mutation',
      'TR_CONTRA Save is the desktop &Save mnemonic; N163 marks Fine JV Save with data-save-mnemonic.',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await countRows(ctx);
        await openFineJv(page);
        await fillGrid(page, twoRows({ fine: '9.75' }));
        const [response] = await Promise.all([
          page.waitForResponse((response) => isApi(response, 'POST', '/fine-jv')),
          page.keyboard.press('Alt+s'),
        ]);
        assert.equal(response.status(), 201, await response.text());
        const after = await countRows(ctx);
        assert.equal(after.source - before.source, 2);
        return {
          observation: 'Alt+S posted the two Fine JV source rows',
          expected: 'desktop Save mnemonic creates one paired transfer',
          database: { before, after },
          downstream: { createdRows: 2 },
        };
      },
    ),
    C(
      'keyboard.voucher-number-enter-opens',
      'T17',
      'read-only',
      'TR_CONTRA tVchNo_KeyDown (N172): Enter in Vch No opens the typed voucher, as on Contra Entry.',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await create(page, twoRows({ fine: '1.125' }));
        await openFineJv(page);
        const box = label(page, 'Vch No');
        await box.fill(vchNo);
        await box.press('Enter');
        await page.getByRole('button', { name: `Update #${vchNo}`, exact: true }).waitFor();
        const grid = await gridValues(page);
        assert.deepEqual(
          grid.map((row) => row.fine),
          ['1.125', '1.125'],
        );
        return {
          observation: `Enter on ${vchNo} opened it with ${JSON.stringify(grid)}`,
          expected: 'the typed voucher opens for update',
        };
      },
    ),
    blocked(
      'downstream-report',
      'T18',
      'The Rojmel projection is asserted in T05/T09, but the L6 Rojmel/ledger report filter-and-total browser cases have not been frozen for Fine JV yet.',
    ),
  ],
};
