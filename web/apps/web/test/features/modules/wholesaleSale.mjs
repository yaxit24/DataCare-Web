import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, ITEMS, PARTIES, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Transaction → Wh Sales (desktop TR_WH_SALE on a WH SALES book, web /txn/wholesale-sale).
 *
 * Desktop authority for the expected values:
 * - MDI_FORM.cs:8040-8051 opens TR_WH_SALE after CurBookHelp('WH SALES'); a web-provisioned company has book WHS
 *   (BOOK_SNAME 'WSALE', BOOK_TBL_NAME 'RATE_CUT_DATA') with the twelve BOOK_DETL slots of the real book 034.
 * - Save (TR_WH_SALE.cs:12779-12896) refuses, in this order: a defaulter party that leaves a sale outstanding, a
 *   missing mandatory employee, a new voucher in a company of type B, a cheque or card amount without its bank
 *   account, a date outside the year, a date on or before the lock date, an edit without the edit right, a blank
 *   party, and a grid row with weight or value but no item code — each with the desktop's own text.
 * - Wh_Sales_Ledr (Ac_Ledr.cs:613-778) posts the voucher's legs; the figures below are evaluated by hand.
 * - Delete (TR_WH_SALE.cs:13553-13592) checks the lock date and the delete right, asks "Are You Sure To Delete This
 *   Voucher now?", writes DELETE_DATA and gives every tag back to stock.
 *
 * Each case seeds its own live tag (BAR_DETL + MAIN_STOCK '+', as a tag opening would) so cases never share a tag.
 */
const BOOK = 'WHS';
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `wholesale-sale.${id}`,
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

const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const OPEN_DAY = `${startYear}-04-05`;
const DAY = `${startYear}-07-15`;

async function open(ctx, credentials) {
  const session = await ctx.session(credentials);
  const { page } = session;
  await page.goto('/txn/wholesale-sale');
  await page.getByRole('heading', { name: 'Wholesale Sale', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && (await book.inputValue()) !== BOOK; i++) await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), BOOK, 'the provisioned WH SALES book is selected');
  return { page, book, session };
}

let seq = 0;
/**
 * A live gold tag of the fixture item, as a tag opening leaves it: BAR_DETL plus a '+' MAIN_STOCK row. Gross equals
 * net (no stone), so the stored fine is round(net × touch / 100, 3). `lbrRate` gives the tag a net-wise labour rate.
 */
async function seedTag(ctx, { net = 10, touch = 91.6, lbrRate = 0 } = {}) {
  seq += 1;
  const tag = `WSE${String(seq).padStart(5, '0')}`;
  const srno = 900200000000 + seq;
  const fine = Math.round(net * touch * 10) / 1000;
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","VCH_DATE",
       "BOOK_NAME","INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE",
       "TBL_CODE","IT_TYPE","EMP_ISU","LBR_TYPE","LBR_RATE")
     VALUES ($1::text,'01','01',$2::text,'TOP','09201',$3::float8,$3::float8,$4::date,'TAG OPENING','I',$5::text,
             $6::numeric,$7::text,1,$8::float8,$8::float8,$9::float8,$10::float8,'001','G','N',$11::text,$12::float8)`,
    ctx.tenantId,
    YEAR,
    seq,
    OPEN_DAY,
    tag,
    srno,
    ITEMS.gold.code,
    net,
    touch,
    fine,
    lbrRate ? 'N' : '',
    lbrRate,
  );
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE",
       "IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
     VALUES ($1::text,'01','01',$2::text,'TOP','09201',$3::float8,1,$4::date,$5::text,$6::text,$7::numeric,'P','+',1,1,
             $8::float8,$8::float8)`,
    ctx.tenantId,
    YEAR,
    seq,
    OPEN_DAY,
    ITEMS.gold.code,
    tag,
    srno,
    net,
  );
  return { tag, srno, net, fine };
}

/** Type into a picker, wait for the code in its list, and take it with Enter (the desktop's F1 help). */
async function pick(page, label, code) {
  const input = page.getByLabel(label, { exact: true });
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await input.press('Enter');
}
async function value(page, label, expected) {
  const input = page.getByLabel(label, { exact: true });
  for (let i = 0; i < 50 && (await input.inputValue()) !== expected; i++)
    await page.waitForTimeout(100);
  assert.equal(await input.inputValue(), expected, label);
}
async function text(page, testId, expected) {
  const node = page.getByTestId(testId);
  const matches = (actual) =>
    expected instanceof RegExp ? expected.test(actual) : actual.trim() === expected;
  for (let i = 0; i < 50 && !matches((await node.textContent()) ?? ''); i++)
    await page.waitForTimeout(100);
  const actual = (await node.textContent()) ?? '';
  assert(matches(actual), `${testId}: expected ${expected}, got ${JSON.stringify(actual)}`);
}
/** Press the screen's Save / Update and return the POST or PUT it sends. */
async function save(page) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        /\/api\/wholesale-sales(\/|$)/.test(new URL(r.url()).pathname) &&
        ['POST', 'PUT'].includes(r.request().method()),
    ),
    page.locator('button[data-save-mnemonic]').click(),
  ]);
  return response;
}
const voucherOf = async (response) => String((await response.json()).vchNo).padStart(5, '0');
const alertText = async (page) => {
  const alert = page.getByRole('alert');
  if (!(await alert.count())) return '';
  return (
    (await alert
      .first()
      .textContent()
      .catch(() => '')) ?? ''
  );
};

/**
 * Enter a one-tag sale through the screen: date, party, the tag on issue line 1, the fine cut at `rate` into money,
 * and the Received column's cash and kasar. Returns the save response; `before` runs after the form is filled.
 */
async function sell(
  page,
  {
    tag,
    cutFine,
    rate = 6500,
    cash,
    kasar,
    cheque,
    card,
    receiveGross,
    party = PARTIES.local.code,
    date = DAY,
    before,
  },
) {
  await page.getByLabel('Date', { exact: true }).fill(date);
  await pick(page, 'Party', party);
  if (tag) await pick(page, 'TagNo Issue line 1', tag);
  // A receive row with weight but no item code (TR_WH_SALE.cs:12890: "Please Select Item Code In Row N").
  if (receiveGross != null)
    await page.getByLabel('GrWt Receive line 1', { exact: true }).fill(String(receiveGross));
  if (cutFine != null) {
    await page.getByLabel('1gm Rate', { exact: true }).fill(String(rate));
    await page.getByLabel('Ac Fine Cr', { exact: true }).fill(String(cutFine));
  }
  if (cash != null) await page.getByLabel('Received Cash Amt', { exact: true }).fill(String(cash));
  if (cheque != null)
    await page.getByLabel('Received Cheque Amt', { exact: true }).fill(String(cheque));
  if (card != null) await page.getByLabel('Received Card Amt', { exact: true }).fill(String(card));
  if (kasar != null)
    await page.getByLabel('Received Kasar Amt', { exact: true }).fill(String(kasar));
  if (before) await before();
  return save(page);
}

const header = async (ctx, vchNo) =>
  (
    await ctx.rows(
      `SELECT "VCH_NO",left("VCH_DATE"::text,10) AS day,"AC_CODE","AC_NAME","FINE_RATE"::float8 AS rate,
              "CR_FINE"::float8 AS cr_fine,"DR_AMT"::float8 AS dr_amt,"SL_FINE"::float8 AS sl_fine,
              "TOT_FINE_DR"::float8 AS tot_dr,"TOT_FINE_CR"::float8 AS tot_cr,"SL_LBR_AMT"::float8 AS lbr,
              "SL_NET_AMT"::float8 AS net,"SL_CASH_AMT"::float8 AS cash,"SL_KASAR_AMT"::float8 AS kasar,
              "SL_BILL_OS"::float8 AS os,"MAIN_USER"
         FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
      vchNo,
    )
  )[0];
/** Wh_Sales_Ledr legs as [leg, account, Dr, Cr, sign, fine, rate]. */
const legs = async (ctx, vchNo) =>
  (
    await ctx.rows(
      `SELECT right("LEDR_KEY",2) AS leg,"AC_CODE" AS ac,"DR_AMT"::float8 AS dr,"CR_AMT"::float8 AS cr,
              coalesce("SIGN",'') AS sign,coalesce("FINE_WT",0)::float8 AS fine,coalesce("FINE_RATE",0)::float8 AS rate
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
      vchNo,
    )
  ).map(({ leg, ac, dr, cr, sign, fine, rate }) => [leg, ac, dr, cr, sign, fine, rate]);
const stockRows = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "SR_NO"::int AS sr,"TAG_NO" AS tag,"IT_CODE" AS it,"ITM_SIGN" AS sign,coalesce("ITM_FINE",0)::float8 AS fine
       FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO","TAG_NO"`,
    vchNo,
  );
/** A tag is in stock while its signed MAIN_STOCK balance is positive (the desktop's HAVING SUM(...) > 0). */
const tagBalance = async (ctx, tag) =>
  Number(
    (
      await ctx.rows(
        `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int AS n
           FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO"=$2`,
        tag,
      )
    )[0].n,
  );
const counts = async (ctx) =>
  (
    await ctx.rows(
      `SELECT (SELECT count(*) FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int AS vch,
              (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int AS legs,
              (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int AS stock`,
    )
  )[0];
const partyBalance = async (ctx, ac) =>
  (
    await ctx.rows(
      `SELECT (coalesce(sum("DR_AMT"),0) - coalesce(sum("CR_AMT"),0))::float8 AS bal
         FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
      ac,
    )
  )[0].bal;

/** New, then the voucher number with Enter (tVchNo_KeyDown → DISPLAY_DATA, TR_WH_SALE.cs:14414-14416). */
async function load(page, vchNo) {
  await page.getByRole('button', { name: 'New', exact: true }).click();
  const box = page.getByLabel('Voucher No', { exact: true });
  await box.fill(String(Number(vchNo)));
  await box.press('Enter');
  await text(page, 'wholesale-sale-status', `Loaded voucher ${vchNo}`);
}
/**
 * Press Delete on the loaded voucher and answer the question. The harness accepts every dialog, so its handler is
 * replaced by one that records the question and answers it; the accept-all handler is put back afterwards.
 */
async function deleteLoaded(page, accept = true) {
  let question = '';
  page.removeAllListeners('dialog');
  page.on('dialog', (dialog) => {
    question = dialog.message();
    void (accept ? dialog.accept() : dialog.dismiss());
  });
  const restore = () => {
    page.removeAllListeners('dialog');
    page.on('dialog', (dialog) => void dialog.accept());
  };
  const button = page.getByRole('button', { name: 'Delete', exact: true });
  try {
    if (!accept) {
      await button.click();
      await page.waitForTimeout(500);
      return { question, response: null };
    }
    const [response] = await Promise.all([
      page.waitForResponse(
        (r) =>
          /\/api\/wholesale-sales\//.test(new URL(r.url()).pathname) &&
          r.request().method() === 'DELETE',
      ),
      button.click(),
    ]);
    return { question, response };
  } finally {
    restore();
  }
}
/** Every row of the voucher's write set without row_id, so an unchanged save can be compared column by column. */
async function writeSet(ctx, vchNo) {
  const out = {};
  for (const table of [
    'RATE_CUT_DATA',
    'RATE_CUT_ISU',
    'RATE_CUT_REC',
    'MAIN_STOCK',
    'AC_DATA',
    'ROJ_MEL_DATA',
  ])
    out[table] = (
      await ctx.rows(
        `SELECT (to_jsonb(t) - 'row_id')::text AS r FROM "${table}" t
          WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY 1`,
        vchNo,
      )
    ).map((row) => row.r);
  return out;
}
const DELETE_QUESTION = 'Are You Sure To Delete This Voucher now?';

const MSG = {
  defaulter:
    'You Cant Save Entry Because This Party Is in Defaulter List...Please Change It First In AcMast...',
  employee: 'Please Select Employee Code and Try......',
  companyB: 'You Cant Save This Voucher Becouse This Company Type is B......',
  chequeBank: 'Please Select Bank Account And Try Because Chq Rec Amt <> 0......',
  cardBank: 'Please Select Card Bank Account And Try Because Card Amt <> 0......',
  year: 'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...',
  itemCode: (row) => `Please Select Item Code In Row ${row} and Try......`,
};
const lockMessage = (dmy) =>
  `You Cant Save and Delete This Voucher Becouse Lock Date is = ${dmy} ....`;
const escape = (s) => s.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');

/**
 * A save the desktop refuses: `setup` sets the flag, the voucher is entered through the screen, the save must answer
 * 400 with exactly `message` shown to the operator, nothing may be written and the tag must stay in stock; `restore`
 * always runs.
 */
async function refused(ctx, { setup, message, options = {} }) {
  const t = await seedTag(ctx);
  const before = await counts(ctx);
  const undo = setup ? await setup() : undefined;
  try {
    const { page } = await open(ctx);
    const response = await sell(page, { tag: t.tag, cutFine: t.fine, cash: 59540, ...options });
    const body = await response.text();
    assert.equal(response.status(), 400, body);
    assert.match(body, new RegExp(escape(message)), 'the API answers with the desktop text');
    for (let i = 0; i < 50 && !(await alertText(page)).includes(message); i++)
      await page.waitForTimeout(100);
    const shown = await alertText(page);
    assert(
      shown.includes(message),
      `the screen shows the desktop text, got ${JSON.stringify(shown)}`,
    );
    assert.deepEqual(await counts(ctx), before, 'nothing written');
    assert.equal(await tagBalance(ctx, t.tag), 1, 'the tag stays in stock');
    return {
      observation: `400 "${message}"; nothing written`,
      expected: { status: 400, message, written: 0 },
      database: { before },
    };
  } finally {
    if (undo) await undo();
  }
}

/**
 * Set one company or party flag for a case. Returns the undo, which puts back the exact earlier value (NULL
 * included), so later cases and modules in the same company see the provisioned setting, not a guessed one. The
 * table, column and row filter are this module's constants; the values travel as parameters.
 */
async function setFlag(ctx, { table, column, where, keys = [] }, value) {
  const read = async () =>
    (
      await ctx.owner.$queryRawUnsafe(
        `SELECT DISTINCT "${column}" AS v FROM "${table}" WHERE tenant_id=$1 AND ${where}`,
        ctx.tenantId,
        ...keys,
      )
    ).map((row) => row.v ?? null);
  const values = await read();
  assert.equal(
    values.length,
    1,
    `${table}.${column} must have one value on the matched rows to restore it`,
  );
  const [earlier] = values;
  const update = `UPDATE "${table}" SET "${column}"=$${keys.length + 2} WHERE tenant_id=$1 AND ${where}`;
  await ctx.owner.$executeRawUnsafe(update, ctx.tenantId, ...keys, value);
  return async () => {
    await ctx.owner.$executeRawUnsafe(update, ctx.tenantId, ...keys, earlier);
    assert.deepEqual(await read(), [earlier], `${table}.${column} is back to its earlier value`);
  };
}
const companyFlag = (column) => ({ table: 'CO_SET', column, where: `"CO_CODE"='01'` });
const defaulterFlag = () => ({
  table: 'AC_MAST',
  column: 'DEFAULTER_AC',
  where: `"AC_CODE"=$2`,
  keys: [PARTIES.local.code],
});

export const wholesaleSale = {
  feature: 'wholesale-sale',
  title: 'Transaction → Wh Sales (TR_WH_SALE)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/components/WholesaleVoucherForm.tsx',
    'web/apps/web/lib/wholesaleVoucher.ts',
    'web/apps/api/src/modules/sales/rateCut.ts',
    'web/apps/web/test/features/modules/wholesaleSale.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    companySettings:
      'catalogue defaults; refusal cases set and restore their own CO_SET / CO_MAST flag',
  },
  cases: [
    C(
      'entry.book-family',
      'T01',
      'read-only',
      "MDI_FORM.cs:8040-8051: Wh Sales opens TR_WH_SALE on CurBookHelp('WH SALES'); only the WH SALES book is offered",
      async (ctx) => {
        const { page, book } = await open(ctx);
        const offered = (await book.locator('option').allTextContents()).filter((t) =>
          t.includes('—'),
        );
        assert.deepEqual(offered, ['WHS — Wholesale Sale']);
        await page.getByRole('button', { name: 'Save', exact: true }).waitFor();
        assert.equal(
          await page.getByRole('button', { name: 'Save', exact: true }).isDisabled(),
          true,
          'Save waits for a party and a line',
        );
        await ctx.shot(page, 'opened');
        return {
          observation: `book list ${JSON.stringify(offered)}; Save disabled on a blank voucher`,
          expected: { offered: ['WHS — Wholesale Sale'], saveDisabled: true },
        };
      },
    ),
    C(
      'create.tag-sale',
      'T07',
      'mutation',
      'A tag sold to the party: it leaves stock, its 9.160 fine is cut at 6500 into Math.Round(59540), 50000 cash and 40 kasar are received and 9500 stays outstanding; Wh_Sales_Ledr legs 01/02, 23, 43/44, 47/48 (Ac_Ledr.cs:613-778)',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const balance0 = await partyBalance(ctx, PARTIES.local.code);
        const response = await sell(page, {
          tag: t.tag,
          cutFine: t.fine,
          cash: 50000,
          kasar: 40,
          before: async () => {
            await value(page, 'Fine Issue line 1', '9.160');
            await text(page, 'wholesale-sale-derived-settleDrAmt', '= 59540.00 (derived)');
            await text(page, 'wholesale-sale-received-net', '59540.00');
            await text(page, 'wholesale-sale-received-os', '9500.00');
            await text(page, 'wholesale-sale-tot-fine-dr', '9.160');
            await text(page, 'wholesale-sale-tot-fine-cr', '9.160');
            await text(page, 'wholesale-sale-os-fine', '0.000');
          },
        });
        assert.equal(response.status(), 201, await response.text());
        const vchNo = await voucherOf(response);
        await text(page, 'wholesale-sale-status', `Saved voucher ${vchNo}`);
        await ctx.shot(page, 'saved');
        const head = await header(ctx, vchNo);
        assert.deepEqual(head, {
          VCH_NO: vchNo,
          day: DAY,
          AC_CODE: PARTIES.local.code,
          AC_NAME: PARTIES.local.name,
          rate: 6500,
          cr_fine: 9.16,
          dr_amt: 59540,
          sl_fine: 9.16,
          tot_dr: 9.16,
          tot_cr: 9.16,
          lbr: 0,
          net: 59540,
          cash: 50000,
          kasar: 40,
          os: 9500,
          MAIN_USER: USERS.admin.user,
        });
        const ledger = await legs(ctx, vchNo);
        assert.deepEqual(ledger, [
          ['01', PARTIES.local.code, 59540, 0, '+', 9.16, 6500],
          ['02', 'SALES', 0, 59540, '', 0, 6500],
          ['23', PARTIES.local.code, 0, 0, '-', 9.16, 0],
          ['43', PARTIES.local.code, 0, 50000, '', 0, 0],
          ['44', 'CASH', 50000, 0, '', 0, 0],
          ['47', PARTIES.local.code, 0, 40, '', 0, 0],
          ['48', 'KASAR', 40, 0, '', 0, 0],
        ]);
        assert.deepEqual(await stockRows(ctx, vchNo), [
          { sr: 1, tag: t.tag, it: ITEMS.gold.code, sign: '-', fine: 9.16 },
        ]);
        assert.equal(await tagBalance(ctx, t.tag), 0, 'the sold tag is out of stock');
        const moved =
          Math.round(((await partyBalance(ctx, PARTIES.local.code)) - balance0) * 100) / 100;
        assert.equal(moved, 9500, 'the party owes the outstanding');
        return {
          observation: `voucher ${vchNo}: DR_AMT 59540 for 9.160 fine at 6500, Os 9500, ${ledger.length} legs`,
          expected: { drAmt: 59540, os: 9500, legs: 7 },
          database: { head, ledger },
          downstream: { tagBalance: 0, partyMoved: moved },
        };
      },
    ),
    C(
      'formula.bankers-rounding-and-labour',
      'T03',
      'mutation',
      "BILL_TOTAL: Ac Amt Dr = Math.Round(0.125 × 6500) = 812, .NET banker's rounding (812.5 → 812); a net-wise tag labour of 237.50/g on 10 g is Math.Round(2375) on legs 15/16; Received Net 3187, Os fine 9.035",
      async (ctx) => {
        const t = await seedTag(ctx, { lbrRate: 237.5 });
        const { page } = await open(ctx);
        const response = await sell(page, {
          tag: t.tag,
          cutFine: 0.125,
          cash: 3187,
          before: async () => {
            await value(page, 'LbrAmt Issue line 1', '2375.00');
            await text(page, 'wholesale-sale-derived-settleDrAmt', '= 812.00 (derived)');
            await text(page, 'wholesale-sale-received-net', '3187.00');
            await text(page, 'wholesale-sale-received-os', '0.00');
            await text(page, 'wholesale-sale-os-fine', '9.035');
          },
        });
        assert.equal(response.status(), 201, await response.text());
        const vchNo = await voucherOf(response);
        const head = await header(ctx, vchNo);
        assert.equal(head.dr_amt, 812, 'banker’s rounding of 812.5');
        assert.equal(head.lbr, 2375);
        assert.equal(head.net, 3187);
        assert.equal(head.os, 0);
        const ledger = await legs(ctx, vchNo);
        assert.deepEqual(ledger, [
          ['01', PARTIES.local.code, 812, 0, '+', 0.125, 6500],
          ['02', 'SALES', 0, 812, '', 0, 6500],
          ['15', PARTIES.local.code, 2375, 0, '', 0, 0],
          ['16', 'LBRINC', 0, 2375, '', 0, 0],
          ['23', PARTIES.local.code, 0, 0, '-', 9.16, 0],
          ['43', PARTIES.local.code, 0, 3187, '', 0, 0],
          ['44', 'CASH', 3187, 0, '', 0, 0],
        ]);
        return {
          observation: `voucher ${vchNo}: 0.125 × 6500 posted ${head.dr_amt}; labour ${head.lbr}; net ${head.net}`,
          expected: { drAmt: 812, labour: 2375, net: 3187 },
          database: { head, ledger },
          downstream: { legs: ledger.length },
        };
      },
    ),
    C(
      'lookup.sold-tag-not-offered',
      'T04',
      'mutation',
      'The F1 tag help offers only tags that can still be issued (signed MAIN_STOCK balance > 0): after one of two tags is sold, their common prefix lists only the other',
      async (ctx) => {
        const a = await seedTag(ctx);
        const b = await seedTag(ctx);
        const { page } = await open(ctx);
        const response = await sell(page, { tag: a.tag, cutFine: a.fine, cash: 59540 });
        assert.equal(response.status(), 201, await response.text());
        await page.getByRole('button', { name: 'New', exact: true }).click();
        const input = page.getByLabel('TagNo Issue line 1', { exact: true });
        const prefix = a.tag.slice(0, -1);
        await input.fill(prefix);
        const list = input.locator('xpath=..');
        await list.getByText(b.tag, { exact: true }).first().waitFor();
        const soldShown = await list.getByText(a.tag, { exact: true }).count();
        await input.press('Escape');
        assert.equal(soldShown, 0, `${a.tag} was sold and must not be offered`);
        return {
          observation: `prefix ${prefix}: ${b.tag} offered, sold ${a.tag} not offered`,
          expected: { offered: b.tag, notOffered: a.tag },
          database: { soldBalance: await tagBalance(ctx, a.tag) },
          downstream: { availableBalance: await tagBalance(ctx, b.tag) },
        };
      },
    ),
    C(
      'children.two-tags-and-received-metal',
      'T05',
      'mutation',
      'Two issued tags (9.160 + 4.580) and 5.000 fine gold received on one voucher: issued fine on leg 23 (13.740), received on leg 29 (5.000), the 8.740 balance cut at 6500 into 56810; MAIN_STOCK takes both tags out on SR_NO 1 and the gold in on SR_NO 2',
      async (ctx) => {
        const a = await seedTag(ctx);
        const b = await seedTag(ctx, { net: 5 });
        const { page } = await open(ctx);
        await page.getByLabel('Date', { exact: true }).fill(DAY);
        await pick(page, 'Party', PARTIES.local.code);
        await pick(page, 'TagNo Issue line 1', a.tag);
        await pick(page, 'TagNo Issue line 2', b.tag);
        await pick(page, 'ItCode Receive line 1', ITEMS.gold.code);
        await page.getByLabel('GrWt Receive line 1', { exact: true }).fill('5');
        await page.getByLabel('Touch Receive line 1', { exact: true }).fill('100');
        await value(page, 'Fine Receive line 1', '5.000');
        await page.getByLabel('1gm Rate', { exact: true }).fill('6500');
        await page.getByLabel('Ac Fine Cr', { exact: true }).fill('8.74');
        await page.getByLabel('Received Cash Amt', { exact: true }).fill('56810');
        await text(page, 'wholesale-sale-tot-fine-dr', '13.740');
        await text(page, 'wholesale-sale-tot-fine-cr', '13.740');
        await text(page, 'wholesale-sale-received-os', '0.00');
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = await voucherOf(response);
        const stock = await stockRows(ctx, vchNo);
        assert.deepEqual(stock, [
          { sr: 1, tag: a.tag, it: ITEMS.gold.code, sign: '-', fine: 9.16 },
          { sr: 1, tag: b.tag, it: ITEMS.gold.code, sign: '-', fine: 4.58 },
          { sr: 2, tag: 'N', it: ITEMS.gold.code, sign: '+', fine: 5 },
        ]);
        const ledger = await legs(ctx, vchNo);
        assert.deepEqual(ledger, [
          ['01', PARTIES.local.code, 56810, 0, '+', 8.74, 6500],
          ['02', 'SALES', 0, 56810, '', 0, 6500],
          ['23', PARTIES.local.code, 0, 0, '-', 13.74, 0],
          ['29', PARTIES.local.code, 0, 0, '+', 5, 0],
          ['43', PARTIES.local.code, 0, 56810, '', 0, 0],
          ['44', 'CASH', 56810, 0, '', 0, 0],
        ]);
        const received = await ctx.rows(
          `SELECT "IT_CODE" AS it,coalesce("ITM_FINE",0)::float8 AS fine FROM "RATE_CUT_REC"
            WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
          vchNo,
        );
        assert.deepEqual(received, [{ it: ITEMS.gold.code, fine: 5 }]);
        return {
          observation: `voucher ${vchNo}: 2 tags out, 5.000 in, 8.740 cut into 56810`,
          expected: { issuedFine: 13.74, receivedFine: 5, cut: 56810 },
          database: { stock, received },
          downstream: { ledger },
        };
      },
    ),
    C(
      'field.header-text',
      'T02',
      'mutation',
      'TR_WH_SALE.cs:12960-13000 stores the header boxes on RATE_CUT_DATA: Bill No, Vch Desc, City and a typed Mobile reach the row and come back on reopen',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const response = await sell(page, {
          tag: t.tag,
          cutFine: t.fine,
          cash: 59540,
          before: async () => {
            await page.getByLabel('Bill No', { exact: true }).fill('WB-77');
            await page.getByLabel('Vch Desc', { exact: true }).fill('E2E WHOLESALE');
            await page.getByLabel('City', { exact: true }).fill('SURAT');
            await page.getByLabel('Mobile', { exact: true }).fill('9824000001');
          },
        });
        assert.equal(response.status(), 201, await response.text());
        const vchNo = await voucherOf(response);
        const [row] = await ctx.rows(
          `SELECT "BILL_NO","VCH_DESC","CITY","MOBILE" FROM "RATE_CUT_DATA"
            WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert.deepEqual(row, {
          BILL_NO: 'WB-77',
          VCH_DESC: 'E2E WHOLESALE',
          CITY: 'SURAT',
          MOBILE: '9824000001',
        });
        await load(page, vchNo);
        await value(page, 'Bill No', 'WB-77');
        await value(page, 'Vch Desc', 'E2E WHOLESALE');
        await value(page, 'City', 'SURAT');
        await value(page, 'Mobile', '9824000001');
        return {
          observation: `voucher ${vchNo}: header boxes stored and reopened`,
          expected: row,
          database: { row },
          downstream: { reopened: true },
        };
      },
    ),
    C(
      'reopen.unchanged-save',
      'T08',
      'mutation',
      'A reopened voucher saved unchanged rebuilds the same write set: header, issue rows, stock, legs and day book, with its number, clock and creating user (TR_WH_SALE.cs:12196, :12325)',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const created = await sell(page, { tag: t.tag, cutFine: t.fine, cash: 50000, kasar: 40 });
        assert.equal(created.status(), 201, await created.text());
        const vchNo = await voucherOf(created);
        const before = await writeSet(ctx, vchNo);
        await load(page, vchNo);
        await value(page, 'TagNo Issue line 1', t.tag);
        await text(page, 'wholesale-sale-received-os', '9500.00');
        const response = await save(page);
        assert.equal(response.status(), 200, await response.text());
        await text(page, 'wholesale-sale-status', `Updated voucher ${vchNo}`);
        const after = await writeSet(ctx, vchNo);
        for (const table of Object.keys(before))
          assert.deepEqual(after[table], before[table], `${table} changed on an unchanged save`);
        return {
          observation: `voucher ${vchNo}: unchanged save kept ${Object.values(before).flat().length} rows`,
          expected: 'no row changes',
          database: {
            tables: Object.fromEntries(Object.entries(before).map(([k, v]) => [k, v.length])),
          },
          downstream: { tagBalance: await tagBalance(ctx, t.tag) },
        };
      },
    ),
    C(
      'edit.drop-a-tag',
      'T09',
      'mutation',
      'An edit that removes a tag gives it back to stock and keeps the other out; the voucher keeps its number and creating user, and leg 23 and SL_FINE carry only the remaining fine (TR_WH_SALE.cs:12756-13411)',
      async (ctx) => {
        const a = await seedTag(ctx);
        const b = await seedTag(ctx, { net: 5 });
        const { page } = await open(ctx);
        const created = await sell(page, {
          tag: a.tag,
          cutFine: 13.74,
          cash: 89310,
          before: () => pick(page, 'TagNo Issue line 2', b.tag),
        });
        assert.equal(created.status(), 201, await created.text());
        const vchNo = await voucherOf(created);
        assert.equal(await tagBalance(ctx, b.tag), 0);
        await load(page, vchNo);
        await page.getByRole('button', { name: 'Remove Issue line 2', exact: true }).click();
        await text(page, 'wholesale-sale-tot-fine-dr', '9.160');
        const response = await save(page);
        assert.equal(response.status(), 200, await response.text());
        assert.equal(await tagBalance(ctx, b.tag), 1, 'the dropped tag is back in stock');
        assert.equal(await tagBalance(ctx, a.tag), 0, 'the kept tag stays sold');
        const head = await header(ctx, vchNo);
        assert.equal(head.sl_fine, 9.16);
        assert.equal(head.tot_dr, 9.16);
        assert.equal(head.dr_amt, 89310, 'the stored Ac Amt Dr is kept, not re-derived');
        assert.equal(head.MAIN_USER, USERS.admin.user);
        const issued = (await legs(ctx, vchNo)).filter(([leg]) => leg === '23');
        assert.deepEqual(issued, [['23', PARTIES.local.code, 0, 0, '-', 9.16, 0]]);
        assert.deepEqual(await stockRows(ctx, vchNo), [
          { sr: 1, tag: a.tag, it: ITEMS.gold.code, sign: '-', fine: 9.16 },
        ]);
        return {
          observation: `voucher ${vchNo}: ${b.tag} back in stock, ${a.tag} still sold, SL_FINE 9.160`,
          expected: { dropped: 1, kept: 0, slFine: 9.16 },
          database: { head },
          downstream: { issued },
        };
      },
    ),
    C(
      'delete.audit-and-tags-back',
      'T10',
      'mutation',
      'BtnDelete_Click (TR_WH_SALE.cs:13553-13592) asks "Are You Sure To Delete This Voucher now?"; No keeps the voucher, Yes writes DELETE_DATA with the signed-in user, removes the write set and gives the tag back',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const created = await sell(page, { tag: t.tag, cutFine: t.fine, cash: 59540 });
        assert.equal(created.status(), 201, await created.text());
        const vchNo = await voucherOf(created);
        await load(page, vchNo);
        const declined = await deleteLoaded(page, false);
        assert.equal((await header(ctx, vchNo))?.VCH_NO, vchNo, 'No keeps the voucher');
        const { question, response } = await deleteLoaded(page, true);
        assert.equal(response.status(), 200, await response.text());
        const remaining = await writeSet(ctx, vchNo);
        for (const [table, rows] of Object.entries(remaining))
          assert.deepEqual(rows, [], `${table} rows remain after delete`);
        const audit = await ctx.rows(
          `SELECT "VCH_NO","DELETE_USER" FROM "DELETE_DATA"
            WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert(audit.length > 0, 'DELETE_DATA has the deleted voucher');
        assert(audit.every((row) => row.DELETE_USER === USERS.admin.user));
        assert.equal(await tagBalance(ctx, t.tag), 1, 'the tag is back in stock');
        assert.equal(declined.question, DELETE_QUESTION, 'the delete question is the desktop text');
        assert.equal(question, DELETE_QUESTION);
        return {
          observation: `voucher ${vchNo} deleted after "${question}"; ${audit.length} audit row(s)`,
          expected: { question: DELETE_QUESTION, auditUser: USERS.admin.user, tagBalance: 1 },
          database: { audit },
          downstream: { tagBalance: 1 },
        };
      },
    ),
    C(
      'concurrency.double-delete',
      'T12',
      'mutation',
      'Two operators open the same voucher and both delete it: the first succeeds, the second is refused, and the tag is given back once',
      async (ctx) => {
        const t = await seedTag(ctx);
        const first = await open(ctx);
        const created = await sell(first.page, { tag: t.tag, cutFine: t.fine, cash: 59540 });
        assert.equal(created.status(), 201, await created.text());
        const vchNo = await voucherOf(created);
        const second = await open(ctx);
        await load(first.page, vchNo);
        await load(second.page, vchNo);
        const one = await deleteLoaded(first.page, true);
        assert.equal(one.response.status(), 200, await one.response.text());
        const two = await deleteLoaded(second.page, true);
        assert.notEqual(two.response.status(), 200, 'the second delete must be refused');
        assert.equal(await tagBalance(ctx, t.tag), 1, 'the tag is given back once');
        return {
          observation: `first delete ${one.response.status()}, second ${two.response.status()}; tag balance 1`,
          expected: 'second refused; tag back once',
          database: { second: two.response.status() },
          downstream: { tagBalance: 1 },
        };
      },
    ),
    C(
      'retry.double-click',
      'T13',
      'mutation',
      'A double-click on Save creates one voucher and reserves the tag once',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const before = await counts(ctx);
        await page.getByLabel('Date', { exact: true }).fill(DAY);
        await pick(page, 'Party', PARTIES.local.code);
        await pick(page, 'TagNo Issue line 1', t.tag);
        await page.getByLabel('1gm Rate', { exact: true }).fill('6500');
        await page.getByLabel('Ac Fine Cr', { exact: true }).fill(String(t.fine));
        await page.getByLabel('Received Cash Amt', { exact: true }).fill('59540');
        await page.locator('button[data-save-mnemonic]').dblclick();
        await text(page, 'wholesale-sale-status', /^Saved voucher \d{5}$/);
        await page.waitForTimeout(1500);
        const after = await counts(ctx);
        assert.equal(after.vch - before.vch, 1, 'one voucher');
        assert.equal(await tagBalance(ctx, t.tag), 0);
        return {
          observation: `${after.vch - before.vch} voucher created by a double-click`,
          expected: 1,
          database: { before, after },
          downstream: { tagBalance: 0 },
        };
      },
    ),
    C(
      'refusal.defaulter-with-outstanding',
      'T06',
      'refusal',
      'TR_WH_SALE.cs:12784-12789: a party flagged AC_MAST.DEFAULTER_AC = Y cannot be left owing (Received Os > 0): "You Cant Save Entry Because This Party Is in Defaulter List..."',
      (ctx) =>
        refused(ctx, {
          setup: () => setFlag(ctx, defaulterFlag(), 'Y'),
          message: MSG.defaulter,
          options: { cash: 50000 },
        }),
    ),
    C(
      'refusal.defaulter-paid-in-full-saves',
      'T06',
      'mutation',
      'Control for the defaulter rule: the desktop refuses only an outstanding (MSG2_TOTAL[7,4] + nDiffFine > 0), so a defaulter who pays in full saves',
      async (ctx) => {
        const t = await seedTag(ctx);
        const undo = await setFlag(ctx, defaulterFlag(), 'Y');
        try {
          const { page } = await open(ctx);
          const response = await sell(page, { tag: t.tag, cutFine: t.fine, cash: 59540 });
          assert.equal(response.status(), 201, await response.text());
          const vchNo = await voucherOf(response);
          assert.equal((await header(ctx, vchNo)).os, 0);
          return {
            observation: `defaulter paid in full: voucher ${vchNo} saved`,
            expected: { status: 201, os: 0 },
            database: { vchNo },
            downstream: { tagBalance: await tagBalance(ctx, t.tag) },
          };
        } finally {
          await undo();
        }
      },
    ),
    C(
      'refusal.employee-mandatory',
      'T06',
      'refusal',
      'TR_WH_SALE.cs:12790-12795: with CO_SET.EMP_CODE_MANDATORY = Y a voucher without an employee is refused with "Please Select Employee Code and Try......"',
      (ctx) =>
        refused(ctx, {
          setup: () => setFlag(ctx, companyFlag('EMP_CODE_MANDATORY'), 'Y'),
          message: MSG.employee,
        }),
    ),
    C(
      'refusal.company-type-b',
      'T06',
      'refusal',
      'TR_WH_SALE.cs:12814-12819: a new voucher in a company whose CO_TYPE is B is refused with "You Cant Save This Voucher Becouse This Company Type is B......"',
      (ctx) =>
        refused(ctx, {
          setup: () =>
            setFlag(ctx, { table: 'CO_MAST', column: 'CO_TYPE', where: `"CO_CODE"='01'` }, 'B'),
          message: MSG.companyB,
        }),
    ),
    C(
      'refusal.cheque-without-bank',
      'T06',
      'refusal',
      'TR_WH_SALE.cs:12820-12825: a cheque amount with no bank account is refused ("Please Select Bank Account And Try Because Chq Rec Amt <> 0......"); the web must not post it to the cash account',
      (ctx) => refused(ctx, { message: MSG.chequeBank, options: { cash: 29540, cheque: 30000 } }),
    ),
    C(
      'refusal.card-without-bank',
      'T06',
      'refusal',
      'TR_WH_SALE.cs:12826-12831: a card amount with no card bank account is refused ("Please Select Card Bank Account And Try Because Card Amt <> 0......")',
      (ctx) => refused(ctx, { message: MSG.cardBank, options: { cash: 29540, card: 30000 } }),
    ),
    C(
      'refusal.date-outside-year',
      'T06',
      'refusal',
      'TR_WH_SALE.cs:12833-12838: a date before the year opens is refused with "You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date..."',
      (ctx) => refused(ctx, { message: MSG.year, options: { date: `${startYear}-03-31` } }),
    ),
    C(
      'refusal.item-code-missing',
      'T06',
      'refusal',
      'TR_WH_SALE.cs:12886-12896: a grid row with weight but no item code is refused with "Please Select Item Code In Row 1 and Try......" (the web saved it with IT_CODE NULL)',
      (ctx) => refused(ctx, { message: MSG.itemCode(1), options: { receiveGross: 5 } }),
    ),
    C(
      'config.lock-date',
      'T15',
      'refusal',
      'TR_WH_SALE.cs:12839-12844: after CO_SET.LOCK_DATE moves past the voucher date a save is refused with "You Cant Save and Delete This Voucher Becouse Lock Date is = dd/MM/yyyy ...."',
      (ctx) => {
        const lock = `${startYear}-07-20`;
        return refused(ctx, {
          setup: () => setFlag(ctx, companyFlag('LOCK_DATE'), lock),
          message: lockMessage(`20/07/${startYear}`),
        });
      },
    ),
    C(
      'rights.clerk-no-wh-sales',
      'T11',
      'refusal',
      'USER_SET grants the clerk Sales Invoice only, so "Wh Sales" is refused ("You Have No Rights....."): neither the screen nor a direct POST /wholesale-sales writes anything',
      async (ctx) => {
        const t = await seedTag(ctx);
        const before = await counts(ctx);
        const clerk = await ctx.session(as(USERS.clerk.user));
        await clerk.page.goto('/txn/wholesale-sale');
        await clerk.page.waitForTimeout(1500);
        const direct = await clerk.page.evaluate(
          async ({ tag, party, day }) => {
            const r = await fetch('/api/wholesale-sales', {
              method: 'POST',
              headers: { 'content-type': 'application/json' },
              body: JSON.stringify({
                coBook: 'WHS',
                acCode: party,
                vchDate: day,
                lines: [{ tagNo: tag }],
                fineRate: 6500,
                settleCrFine: 9.16,
              }),
            });
            return r.status;
          },
          { tag: t.tag, party: PARTIES.local.code, day: DAY },
        );
        assert.equal(direct, 403, 'the server refuses the clerk');
        assert.deepEqual(await counts(ctx), before);
        assert.equal(await tagBalance(ctx, t.tag), 1, 'the tag stays in stock');
        return {
          observation: `clerk POST /wholesale-sales answered ${direct}; nothing written`,
          expected: { status: 403, written: 0 },
          database: { before },
        };
      },
    ),
    C(
      'rollback.fault-on-issue-row',
      'T14',
      'mutation',
      'TR_WH_SALE saves inside one transaction (WhTran, :12920-13510): a fault on the issue-row insert rolls back the header, stock, legs and the hidden number, and the tag stays in stock',
      async (ctx) => {
        const t = await seedTag(ctx);
        const before = await counts(ctx);
        const hidden0 = await ctx.rows(
          `SELECT count(*)::int AS n FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
        );
        await ctx.owner.$executeRawUnsafe(
          `CREATE OR REPLACE FUNCTION e2e_ws_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
           BEGIN
             IF NEW."TAG_NO" = '${t.tag}' THEN RAISE EXCEPTION 'e2e fault on the issue row'; END IF;
             RETURN NEW;
           END $f$`,
        );
        await ctx.owner.$executeRawUnsafe(
          `CREATE TRIGGER e2e_ws_fault BEFORE INSERT ON "RATE_CUT_ISU" FOR EACH ROW EXECUTE FUNCTION e2e_ws_fault()`,
        );
        try {
          const { page } = await open(ctx);
          const response = await sell(page, { tag: t.tag, cutFine: t.fine, cash: 59540 });
          assert.notEqual(response.status(), 201, 'the faulted save must fail');
          assert.deepEqual(await counts(ctx), before, 'nothing of the voucher remains');
          assert.equal(await tagBalance(ctx, t.tag), 1, 'the tag stays in stock');
          const hidden1 = await ctx.rows(
            `SELECT count(*)::int AS n FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
          );
          assert.deepEqual(hidden1, hidden0, 'no hidden number is taken');
          return {
            observation: `faulted save answered ${response.status()}; counts and tag stock unchanged`,
            expected: 'complete rollback',
            database: { before, hidden: hidden1 },
            downstream: { tagBalance: 1 },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `DROP TRIGGER IF EXISTS e2e_ws_fault ON "RATE_CUT_ISU"`,
          );
          await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_ws_fault()`);
        }
      },
    ),
    C(
      'output.print-bill',
      'T16',
      'output',
      'BtnPrint_Click (TR_WH_SALE.cs:13654-13800) checks the print right and prints the WH SALES bill (WhSalesBill): a saved voucher must offer Print, and the bill shows the party, the tag and the net amount',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const response = await sell(page, { tag: t.tag, cutFine: t.fine, cash: 59540 });
        assert.equal(response.status(), 201, await response.text());
        const print = page.getByRole('button', { name: 'Print', exact: true });
        assert.equal(await print.count(), 1, 'a saved Wh Sales voucher offers Print');
        const [doc] = await Promise.all([page.waitForEvent('popup'), print.click()]);
        // openDocument opens a blank window, checks the session, then navigates it to the bill.
        await doc.waitForURL(/\/api\/wholesale-sales\/\d+\/print/);
        await doc.waitForLoadState();
        const body = (await doc.textContent('body')) ?? '';
        for (const expected of [PARTIES.local.name, t.tag, '59,540.00'])
          assert(body.includes(expected), `the bill shows ${expected}`);
        return {
          observation: 'the bill shows the party, the tag and the net amount',
          expected: { shows: [PARTIES.local.name, t.tag, '59,540.00'] },
          output: Buffer.from(body),
        };
      },
    ),
    C(
      'keyboard.alt-s-saves',
      'T17',
      'mutation',
      'The &Save mnemonic: Alt+S from a box of the tender band saves the voucher, as the desktop button does',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        await page.getByLabel('Date', { exact: true }).fill(DAY);
        await pick(page, 'Party', PARTIES.local.code);
        await pick(page, 'TagNo Issue line 1', t.tag);
        await page.getByLabel('1gm Rate', { exact: true }).fill('6500');
        await page.getByLabel('Ac Fine Cr', { exact: true }).fill(String(t.fine));
        const cash = page.getByLabel('Received Cash Amt', { exact: true });
        await cash.fill('59540');
        await cash.focus();
        const [response] = await Promise.all([
          page.waitForResponse(
            (r) =>
              new URL(r.url()).pathname === '/api/wholesale-sales' &&
              r.request().method() === 'POST',
          ),
          page.keyboard.press('Alt+s'),
        ]);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = await voucherOf(response);
        assert.equal((await header(ctx, vchNo))?.cash, 59540);
        return {
          observation: `Alt+S saved voucher ${vchNo}`,
          expected: { status: 201 },
          database: { vchNo },
          downstream: { tagBalance: await tagBalance(ctx, t.tag) },
        };
      },
    ),
    C(
      'journey.outstanding-then-cash-received',
      'T18',
      'mutation',
      'A Wh Sales voucher left 9500 outstanding is cleared by a Cash Received of 9500 from the same party: the party owes 9500 after the sale and nothing more after the receipt',
      async (ctx) => {
        // Its own party: the earlier cases received cash from the local customer, and TR_CASH's cash-received
        // limit (CO_SET.CASH_LIMIT) would rightly refuse a further receipt from it.
        const PARTY = PARTIES.interState.code;
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const balance0 = await partyBalance(ctx, PARTY);
        const sale = await sell(page, {
          tag: t.tag,
          cutFine: t.fine,
          cash: 50000,
          kasar: 40,
          party: PARTY,
        });
        assert.equal(sale.status(), 201, await sale.text());
        const delta = async () =>
          Math.round(((await partyBalance(ctx, PARTY)) - balance0) * 100) / 100;
        assert.equal(await delta(), 9500, 'the party owes the Wh Sales outstanding');
        await page.goto('/txn/receipt');
        await page.getByLabel('Party account', { exact: true }).waitFor();
        const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
        for (let i = 0; i < 50 && !(await book.inputValue()); i++) await page.waitForTimeout(100);
        const party = page.getByLabel('Party account', { exact: true });
        await party.fill(PARTY);
        await party.locator('xpath=..').getByText(PARTY, { exact: true }).first().waitFor();
        await party.press('Enter');
        await page.getByLabel('Amount', { exact: true }).fill('9500');
        const [receipt] = await Promise.all([
          page.waitForResponse(
            (r) => new URL(r.url()).pathname === '/api/receipts' && r.request().method() === 'POST',
          ),
          page.getByRole('button', { name: 'Save Receipt', exact: true }).click(),
        ]);
        assert.equal(receipt.status(), 201, await receipt.text());
        assert.equal(await delta(), 0, 'the receipt clears the outstanding');
        return {
          observation: 'sale left 9500 owing; Cash Received 9500 cleared it',
          expected: { afterSale: 9500, afterReceipt: 0 },
          database: { sale: await voucherOf(sale) },
          downstream: { partyMoved: 0 },
        };
      },
    ),
  ],
};
