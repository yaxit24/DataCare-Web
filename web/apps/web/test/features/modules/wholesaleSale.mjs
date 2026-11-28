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
const QUOTE_BOOK = 'WHQ';
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
async function seedTag(ctx, { net = 10, touch = 91.6, lbrRate = 0, stones = [] } = {}) {
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
  // The tag's stones (BAR_IDTL): [dm code, pcs, weight, rate, amount]; a stone with nothing in it is not copied.
  for (const [i, [dm, pcs, wt, rate, amt]] of stones.entries())
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","TAG_NO","VCH_SRNO",
         "IT_CODE","IT_TYPE","DM_CODE","DM_NAME","DM_COLOR","DM_SIZE","DM_ORIGIN","IT_PCS","IT_GWT","IT_RATE_TYPE","IT_RATE",
         "IT_AMT","IT_LBR_RATE","IT_LBR_AMT","IT_NET_AMT","KR_WT")
       VALUES ($1::text,'01','01',$2::text,'TOP','09201',$3::float8,$4::float8,$5::text,$6::float8,$7::text,'G',$8::text,
               $9::text,'WHITE','1.5','NATURAL',$10::numeric,$11::numeric,'C',$12::numeric,$13::numeric,0,0,$13::numeric,
               $11::numeric)`,
      ctx.tenantId,
      YEAR,
      seq,
      i + 1,
      tag,
      srno,
      ITEMS.gold.code,
      dm,
      `${dm} STONE`,
      pcs,
      wt,
      rate,
      amt,
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
    'SL_IDTL',
    'DM_DATA',
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

/**
 * WP-30 helpers: the item-detail panel and the Ksr Fine boxes. Row A is 2 pcs x 1.5 = 3.000 g at 101 with Con% 0.1,
 * Disc% 5 and labour 237.5 a piece: ItAmt 303, Disc round(15.15) = 15, Lbr 475, Net 763 (CommPassTotal_Idtl,
 * TR_WH_SALE.cs:7750-7971). Row B is 2.000 g with Con% 0.1 and a typed net amount 500. The line (5.000 g) takes
 * OthWt 0.3 + 0.2 = 0.5, NetWt 4.5 and OthAmt 763 + 500 = 1263.
 */
const ROW_A = {
  pcs: '2',
  pcsWt: '1.5',
  conPct: '0.1',
  krConPct: '0.05',
  rate: '101',
  discPct: '5',
  lbrRate: '237.5',
};
const ROW_B = { pcs: '2', grossWt: '2', conPct: '0.1', netAmt: '500' };
const DETAIL_LABELS = {
  pcs: 'Pcs',
  pcsWt: 'PcsWt',
  krWt: 'KrWt',
  krLessPrc: 'KrLs%',
  grossWt: 'Weight',
  conPct: 'Con%',
  rateType: 'P/W',
  rate: 'Rate',
  discPct: 'Disc%',
  lbrRate: 'LbrRate',
  krConPct: 'KrCon%',
  netAmt: 'NetAmt',
};
async function openDetail(page, line = 1) {
  const panel = page.getByRole('region', { name: `Item detail Issue line ${line}` });
  if (!(await panel.count()))
    await page.getByRole('button', { name: `Item detail Issue line ${line}`, exact: true }).click();
  await panel.waitFor();
  return panel;
}
/**
 * Enter in a detail row's NetAmt commits it and the app moves the caret to the next row's ItCode on the next
 * animation frame (TR_WH_SALE.cs:7522; WholesaleDetailPanel schedules the move after React commits). Wait for
 * that move before typing further: Playwright's fill types into the focused element between two protocol
 * steps, so a keystroke issued while the frame callback is still pending can land in the cell the callback
 * is about to focus. A CI run stored row 2 with IT_CODE '2' and IT_PCS 0 because the Pcs '2' was sent to the
 * ItCode the caret was moving to.
 */
const detailCaretMoved = (page, row) =>
  page.waitForFunction(
    (n) =>
      document.activeElement instanceof HTMLInputElement &&
      document.activeElement.getAttribute('aria-label') === `ItCode detail ${n}`,
    row,
  );
/** Type detail rows into the panel of an issue line; Enter in NetAmt commits a row and starts the next. */
async function typeDetails(page, rows, line = 1) {
  await openDetail(page, line);
  for (const [i, row] of rows.entries()) {
    if (row.itCode) await pick(page, `ItCode detail ${i + 1}`, row.itCode);
    for (const [field, label] of Object.entries(DETAIL_LABELS))
      if (row[field] != null)
        await page.getByLabel(`${label} detail ${i + 1}`, { exact: true }).fill(row[field]);
    await page.getByLabel(`NetAmt detail ${i + 1}`, { exact: true }).press('Enter');
    await detailCaretMoved(page, i + 2);
  }
}
/** A loose issue line (no tag) and its rows, then the Received cash; returns the save response. */
async function looseSale(
  page,
  { rows = [ROW_A, ROW_B], cash = 1263, ksrDr, ksrCr, party = PARTIES.local.code } = {},
) {
  await page.getByLabel('Date', { exact: true }).fill(DAY);
  await pick(page, 'Party', party);
  await pick(page, 'ItCode Issue line 1', ITEMS.gold.code);
  await page.getByLabel('Pcs Issue line 1', { exact: true }).fill('2');
  await page.getByLabel('GrWt Issue line 1', { exact: true }).fill('5');
  await page.getByLabel('Touch Issue line 1', { exact: true }).fill('91.6');
  await typeDetails(
    page,
    rows.map((r, i) => (i === 0 ? { itCode: ITEMS.gold.code, ...r } : r)),
  );
  await page.keyboard.press('Escape');
  if (ksrDr != null) await typeKasar(page, 'Ksr Fine Dr', ksrDr);
  if (ksrCr != null) await typeKasar(page, 'Ksr Fine Cr', ksrCr);
  await page.getByLabel('Received Cash Amt', { exact: true }).fill(String(cash));
  return save(page);
}
async function typeKasar(page, label, typed) {
  const box = page.getByLabel(label, { exact: true });
  await box.fill(typed);
  await box.press('Enter');
}
const slidtl = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "SR_NO"::int AS sr,"ISR_NO"::int AS isr,"ENTRY_TYPE" AS et,"TAG_NO" AS tag,"IT_CODE" AS it,"IT_PCS"::float8 AS pcs,
            "IT_PCS_WT"::float8 AS pcswt,"IT_GWT"::float8 AS gwt,"KR_WT"::float8 AS krwt,"IT_CON_PRC"::float8 AS con,
            "IT_CON_WT"::float8 AS conwt,"IT_RATE"::float8 AS rate,"IT_AMT"::float8 AS amt,"IT_DISC_PRC"::float8 AS disc,
            "IT_DISC_AMT"::float8 AS discamt,"IT_LBR_RATE"::float8 AS lr,"IT_LBR_AMT"::float8 AS la,
            "IT_NET_AMT"::float8 AS net,"KR_CON_PRC"::float8 AS krcon,"KR_CON_WT"::float8 AS krconwt
       FROM "SL_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO","ISR_NO"`,
    vchNo,
  );
const rojmelRows = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "LEDR_KEY" AS key,"AC_NAME" AS name,"AC_CODE" AS ac,"LD_CODE" AS ld,"SIGN" AS sign,"ITM_FINE"::float8 AS fine,
            "DR_AMT"::float8 AS dr,"CR_AMT"::float8 AS cr
       FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
    vchNo,
  );
/** The downstream proof of a voucher: its ledger legs, day book rows and stock rows as they stand now. */
const downstreamOf = async (ctx, vchNo) =>
  (
    await ctx.rows(
      `SELECT (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2)::int AS legs,
              (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2)::int AS rojmel,
              (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2)::int AS stock`,
      vchNo,
    )
  )[0];
const LOOSE_ROWS = [
  {
    sr: 1,
    isr: 1,
    et: 'W',
    tag: 'N',
    it: ITEMS.gold.code,
    pcs: 2,
    pcswt: 1.5,
    gwt: 3,
    krwt: 3,
    con: 0.1,
    conwt: 0.3,
    rate: 101,
    amt: 303,
    disc: 5,
    discamt: 15,
    lr: 237.5,
    la: 475,
    net: 763,
    krcon: 0.05,
    krconwt: 0,
  },
  {
    sr: 1,
    isr: 2,
    et: 'W',
    tag: 'N',
    it: '',
    pcs: 2,
    pcswt: 0,
    gwt: 2,
    krwt: 2,
    con: 0.1,
    conwt: 0.2,
    rate: 0,
    amt: 0,
    disc: 0,
    discamt: 0,
    lr: 0,
    la: 0,
    net: 500,
    krcon: 0,
    krconwt: 0,
  },
];

/** A view/edit user has no delete or print grant; exercise the actual editor and direct requests. */
async function restrictedDetails(ctx, checkPrint) {
  const { page: admin } = await open(ctx);
  const created = await looseSale(admin);
  assert.equal(created.status(), 201, await created.text());
  const no = await voucherOf(created);
  const before = await slidtl(ctx, no);
  const downstream = await downstreamOf(ctx, no);
  const { page } = await open(ctx, as(USERS.printViewer.user));
  await page.getByLabel('Voucher No', { exact: true }).fill(no);
  await page.getByRole('button', { name: 'Load', exact: true }).click();
  await page.getByRole('button', { name: 'Update', exact: true }).waitFor();
  await openDetail(page);
  await value(page, 'Pcs detail 1', '2');
  await page.getByLabel('Pcs detail 1', { exact: true }).press('Control+d');
  await page.getByRole('alert').filter({ hasText: 'You Have No Rights.....' }).waitFor();
  await value(page, 'Pcs detail 1', '2');
  await value(page, 'Pcs detail 2', '2');
  const payload = created.request().postDataJSON();
  const me = await (await page.request.get('/api/me')).json();
  const headers = {
    'x-session-context-id': me.context.sessionId,
    'x-session-context-epoch': String(me.context.contextEpoch),
  };
  const current = await page.request.get(`/api/wholesale-sales/${no}?coBook=${BOOK}`, { headers });
  assert.equal(current.status(), 200, await current.text());
  const version = (await current.json()).version;
  const removed = {
    ...payload,
    expectedVersion: version,
    lines: payload.lines.map((line, i) => (i ? line : { ...line, details: [] })),
  };
  const denied = await page.request.put(`/api/wholesale-sales/${no}`, { data: removed, headers });
  assert([400, 403].includes(denied.status()), await denied.text());
  assert.match(await denied.text(), /You Have No Rights/);
  // TR_WH_SALE.cs:10224: a whole issue line is refused too, not only its detail rows.
  const lineDropped = await page.request.put(`/api/wholesale-sales/${no}`, {
    // settleDrAmt keeps the body past the "at least one line or a settlement" check.
    data: { ...payload, expectedVersion: version, lines: [], settleDrAmt: 1 },
    headers,
  });
  assert([400, 403].includes(lineDropped.status()), await lineDropped.text());
  assert.match(await lineDropped.text(), /You Have No Rights/);
  if (checkPrint) {
    await page.getByRole('button', { name: 'Print', exact: true }).click();
    await page.getByRole('alert').filter({ hasText: 'You Have No Print Rights.....' }).waitFor();
    const print = await page.request.get(
      `/api/wholesale-sales/${no}/print?coBook=${BOOK}&format=html`,
      { headers },
    );
    assert.equal(print.status(), 403, await print.text());
  }
  assert.deepEqual(await slidtl(ctx, no), before);
  assert.deepEqual(await downstreamOf(ctx, no), downstream);
  return {
    observation:
      'Detail delete refused without removing rows' +
      (checkPrint ? '; print refused by UI and API' : ''),
    expected: 'desktop refusal text and unchanged voucher',
    database: { before, downstream },
  };
}

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
        // Wh_Sale_Stk copies the line's stored ITM_LOT, NOT NULL DEFAULT '' (Ac_Stock.cs:153).
        const lots = await ctx.rows(
          `SELECT "ITM_LOT" lot FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert.deepEqual(lots, [{ lot: '' }]);
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
        // @RptTitle is the book's name; the lines sit under "Issue Item"; the band has the report's four columns.
        const [{ name: bookName }] = await ctx.rows(
          `SELECT "BOOK_NAME" AS name FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
        );
        const shows = [
          PARTIES.local.name,
          t.tag,
          '59,540.00',
          'Issue Item',
          'Purchase Fine',
          'Sales Fine',
          'Purchase Amt',
          'Sales Amt',
          'Kasar Fine',
          'ESTIMATE',
        ];
        for (const expected of shows) assert(body.includes(expected), `the bill shows ${expected}`);
        assert.equal(await doc.title(), bookName, 'the bill is titled with the book name');
        return {
          observation: `the bill, titled ${bookName}, shows the party, the tag, the net amount and the four-column band`,
          expected: { title: bookName, shows },
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
      'create.tag-stones',
      'T05',
      'mutation',
      "A tag's stones travel with the sale: save copies its BAR_IDTL rows to SL_IDTL (ENTRY_TYPE W, ISR_NO 1.. per line, an empty stone skipped) and, for an item with OTH_DETL_POSTING, projects them into DM_DATA (TR_WH_SALE.cs:10113-10148, :13162-13250; Ac_Stock.cs:857-861); an unchanged save rewrites them and Delete removes them",
      async (ctx) => {
        const undo = await setFlag(
          ctx,
          {
            table: 'ITEM_MAST',
            column: 'OTH_DETL_POSTING',
            where: `"CO_CODE"='01' AND "IT_CODE"=$2`,
            keys: [ITEMS.gold.code],
          },
          'Y',
        );
        try {
          const t = await seedTag(ctx, {
            stones: [
              ['DIA01', 3, 0.3, 20000, 6000],
              ['ZER00', 0, 0, 0, 0],
              ['CZ02', 5, 0.5, 100, 500],
            ],
          });
          const { page } = await open(ctx);
          const created = await sell(page, { tag: t.tag, cutFine: t.fine, cash: 50000, kasar: 40 });
          assert.equal(created.status(), 201, await created.text());
          const vchNo = await voucherOf(created);
          const stoneRows = (table, columns) =>
            ctx.rows(
              `SELECT ${columns} FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "ISR_NO"`,
              vchNo,
            );
          const idtl = await stoneRows(
            'SL_IDTL',
            `"SR_NO"::int AS sr,"ISR_NO"::int AS isr,"ENTRY_TYPE" AS et,"TAG_NO" AS tag,"DM_CODE" AS dm,"IT_PCS"::float8 AS pcs,"IT_GWT"::float8 AS wt,"IT_AMT"::float8 AS amt`,
          );
          assert.deepEqual(idtl, [
            { sr: 1, isr: 1, et: 'W', tag: t.tag, dm: 'DIA01', pcs: 3, wt: 0.3, amt: 6000 },
            { sr: 1, isr: 2, et: 'W', tag: t.tag, dm: 'CZ02', pcs: 5, wt: 0.5, amt: 500 },
          ]);
          const projected = await stoneRows(
            'DM_DATA',
            `"ISR_NO"::int AS isr,"ENTRY_TYPE" AS et,"DM_CODE" AS dm,"DM_PCS"::float8 AS pcs,"DM_WT"::float8 AS wt,"DM_SIGN" AS sign,"MAIN_IT_CODE" AS main,"TAG_NO" AS tag`,
          );
          assert.deepEqual(projected, [
            {
              isr: 1,
              et: 'S',
              dm: 'DIA01',
              pcs: 3,
              wt: 0.3,
              sign: '-',
              main: ITEMS.gold.code,
              tag: t.tag,
            },
            {
              isr: 2,
              et: 'S',
              dm: 'CZ02',
              pcs: 5,
              wt: 0.5,
              sign: '-',
              main: ITEMS.gold.code,
              tag: t.tag,
            },
          ]);
          const before = await writeSet(ctx, vchNo);
          await load(page, vchNo);
          const updated = await save(page);
          assert.equal(updated.status(), 200, await updated.text());
          assert.deepEqual(
            await writeSet(ctx, vchNo),
            before,
            'an unchanged save keeps the stone rows',
          );
          const { response } = await deleteLoaded(page);
          assert.equal(response.status(), 200, await response.text());
          const remaining = await writeSet(ctx, vchNo);
          assert.deepEqual([remaining.SL_IDTL, remaining.DM_DATA], [[], []], 'Delete removes them');
          return {
            observation: `voucher ${vchNo}: 2 SL_IDTL and 2 DM_DATA stone rows, kept on an unchanged save, gone after Delete`,
            expected: { idtl, projected },
            database: { idtl, projected },
            downstream: { afterDelete: [0, 0], tagBalance: await tagBalance(ctx, t.tag) },
          };
        } finally {
          await undo();
        }
      },
    ),
    C(
      'keyboard.voucher-number-keys',
      'T17',
      'read-only',
      'The voucher number box: F1 lists the book, Up steps to the next saved voucher, Down to the previous one, Enter opens the typed number (tVchNo_KeyDown, TR_WH_SALE.cs:14393-14418)',
      async (ctx) => {
        const first = await (async () => {
          const t = await seedTag(ctx);
          const { page } = await open(ctx);
          const response = await sell(page, { tag: t.tag, cutFine: t.fine });
          assert.equal(response.status(), 201, await response.text());
          return voucherOf(response);
        })();
        const t2 = await seedTag(ctx);
        const { page } = await open(ctx);
        const response = await sell(page, { tag: t2.tag, cutFine: t2.fine });
        assert.equal(response.status(), 201, await response.text());
        const second = await voucherOf(response);
        await page.getByRole('button', { name: 'New', exact: true }).click();
        const box = page.getByLabel('Voucher No', { exact: true });
        const note = page.getByTestId('voucher-number-note');
        const seen = [];
        const expectLoaded = async (vchNo, step) => {
          await text(page, 'wholesale-sale-status', `Loaded voucher ${vchNo}`);
          seen.push(`${step}: #${vchNo}`);
        };
        await box.focus();
        await page.keyboard.press('ArrowDown');
        await expectLoaded(second, 'Down');
        await page.keyboard.press('ArrowDown');
        await expectLoaded(first, 'Down');
        assert.equal(
          await box.evaluate((el) => el === document.activeElement),
          true,
          'Up/Down keep the focus in the box',
        );
        await page.keyboard.press('ArrowUp');
        await expectLoaded(second, 'Up');
        await page.keyboard.press('ArrowUp');
        for (let i = 0; i < 50 && (await box.inputValue()) !== ''; i++)
          await page.waitForTimeout(100);
        assert.equal(await box.inputValue(), '', 'a blank new voucher');
        seen.push('Up: new voucher');
        await page.keyboard.press('ArrowUp');
        await note.filter({ hasText: 'Last Record...' }).waitFor();
        seen.push('Up: Last Record...');
        await box.fill(first);
        await page.keyboard.press('Enter');
        await expectLoaded(first, 'Enter');
        await page.waitForFunction(() => document.activeElement?.getAttribute('type') === 'date');
        seen.push('Enter: focus on the date');
        await box.focus();
        await page.keyboard.press('F1');
        await page.waitForFunction(() => document.activeElement?.hasAttribute('data-voucher-load'));
        await page.keyboard.press('ArrowDown');
        await page.keyboard.press('Enter');
        await expectLoaded(first, 'F1 list');
        return {
          observation: seen.join('; '),
          expected: [
            `Down: #${second}`,
            `Down: #${first}`,
            `Up: #${second}`,
            'Up: new voucher',
            'Up: Last Record...',
            `Enter: #${first}`,
            'Enter: focus on the date',
            `F1 list: #${first}`,
          ].join('; '),
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
    // ---- WP-30: item-detail rows, fine kasar and the Rojmel -----------------------------------------------------
    C(
      'entry.detail-grid-defaults',
      'T01',
      'read-only',
      'MSG_IDTL is hidden until an issue line asks for it and carries the desktop captions (TR_WH_SALE.cs:4899-4903, :7115-7286); a tagged line has none',
      async (ctx) => {
        const { page } = await open(ctx);
        const button = page.getByRole('button', { name: 'Item detail Issue line 1', exact: true });
        assert.equal(await button.count(), 1, 'a loose issue line offers its item-detail rows');
        assert.equal(
          await page.getByRole('region', { name: 'Item detail Issue line 1' }).count(),
          0,
          'hidden at first',
        );
        const panel = await openDetail(page);
        const captions = await panel.getByRole('columnheader').allTextContents();
        for (const caption of [
          'ItCode',
          'DmCode',
          'Pcs',
          'PcsWt',
          'Weight',
          'Con%',
          'Rate',
          'Disc%',
          'LbrRate',
          'KrCon%',
          'NetAmt',
        ])
          assert(captions.includes(caption), `caption ${caption}`);
        await page.keyboard.press('Escape');
        return {
          observation: `captions ${captions.join(',')}`,
          expected: { hidden: true, captions: 11 },
        };
      },
    ),
    C(
      'entry.fine-box-defaults',
      'T01',
      'read-only',
      'Ksr Fine Dr and Ksr Fine Cr follow Ac Fine Dr in tab order and are always editable (TR_WH_SALE.cs:5256-5271, :5359, :5369)',
      async (ctx) => {
        const { page } = await open(ctx);
        const order = await page.evaluate(() =>
          [...document.querySelectorAll('input')].map(
            (i) => i.labels?.[0]?.textContent ?? i.getAttribute('aria-label') ?? '',
          ),
        );
        const at = (label) => order.indexOf(label);
        assert(
          at('Ac Fine Dr') >= 0 &&
            at('Ksr Fine Dr') === at('Ac Fine Dr') + 1 &&
            at('Ksr Fine Cr') === at('Ksr Fine Dr') + 1,
          `order ${order.join('|')}`,
        );
        for (const label of ['Ksr Fine Dr', 'Ksr Fine Cr']) {
          const box = page.getByLabel(label, { exact: true });
          assert(await box.isEditable(), `${label} editable`);
          assert.equal(await box.inputValue(), '', `${label} starts blank`);
        }
        return {
          observation: 'Ksr Fine Dr, Ksr Fine Cr after Ac Fine Dr, editable',
          expected: { order: true },
        };
      },
    ),
    C(
      'field.ksr-fine-dr-cr',
      'T02',
      'mutation',
      'Enter formats a kasar to three decimals (TR_WH_SALE.cs:16035); Save posts ksrFineDr/ksrFineCr and stores KSR_FINE_DR/CR (:12980-12981); the reopen shows them again (:12230)',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const created = await sell(page, {
          tag: t.tag,
          cutFine: t.fine,
          cash: 59540,
          before: async () => {
            await typeKasar(page, 'Ksr Fine Dr', '0.5');
            await typeKasar(page, 'Ksr Fine Cr', '0.25');
            await value(page, 'Ksr Fine Dr', '0.500');
            await value(page, 'Ksr Fine Cr', '0.250');
          },
        });
        assert.equal(created.status(), 201, await created.text());
        const posted = created.request().postDataJSON();
        assert.deepEqual([posted.ksrFineDr, posted.ksrFineCr], [0.5, 0.25]);
        const vchNo = await voucherOf(created);
        const [stored] = await ctx.rows(
          `SELECT "KSR_FINE_DR"::float8 AS dr,"KSR_FINE_CR"::float8 AS cr FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert.deepEqual(stored, { dr: 0.5, cr: 0.25 });
        await load(page, vchNo);
        await value(page, 'Ksr Fine Dr', '0.500');
        await value(page, 'Ksr Fine Cr', '0.250');
        return {
          observation: 'posted 0.5/0.25, stored, shown 0.500/0.250 on reopen',
          expected: stored,
          database: { vchNo },
          downstream: { reopened: true },
        };
      },
    ),
    C(
      'field.detail-row-fields',
      'T02',
      'mutation',
      'Every typed detail column reaches the request and SL_IDTL (TR_WH_SALE.cs:13190-13245)',
      async (ctx) => {
        const { page } = await open(ctx);
        const created = await looseSale(page);
        assert.equal(created.status(), 201, await created.text());
        const sent = created.request().postDataJSON().lines[0].details[0];
        assert.deepEqual(
          [
            sent.pcs,
            sent.pcsWt,
            sent.conPct,
            sent.krConPct,
            sent.rateType,
            sent.rate,
            sent.discPct,
            sent.lbrRate,
          ],
          [2, 1.5, 0.1, 0.05, '', 101, 5, 237.5],
        );
        const vchNo = await voucherOf(created);
        const [first] = await slidtl(ctx, vchNo);
        assert.deepEqual(
          [first.pcs, first.pcswt, first.con, first.krcon, first.rate, first.disc, first.lr],
          [2, 1.5, 0.1, 0.05, 101, 5, 237.5],
        );
        return {
          observation: 'row A typed values in the request and the stored row',
          expected: first,
          database: { vchNo },
          downstream: await downstreamOf(ctx, vchNo),
        };
      },
    ),
    C(
      'formula.ksr-fine-totals',
      'T03',
      'mutation',
      'Tot Fine Dr and Cr include the kasar: 9.160 + 0.500, 9.160 + 0.250, Os Fine 0.250; SL_FINE stays (TR_WH_SALE.cs:15633-15635)',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const created = await sell(page, {
          tag: t.tag,
          cutFine: t.fine,
          cash: 59540,
          before: async () => {
            await text(page, 'wholesale-sale-tot-fine-dr', '9.160');
            await typeKasar(page, 'Ksr Fine Dr', '0.500');
            await typeKasar(page, 'Ksr Fine Cr', '0.250');
            await text(page, 'wholesale-sale-tot-fine-dr', '9.660');
            await text(page, 'wholesale-sale-tot-fine-cr', '9.410');
            await text(page, 'wholesale-sale-os-fine', '0.250');
          },
        });
        assert.equal(created.status(), 201, await created.text());
        const h = await header(ctx, await voucherOf(created));
        assert.deepEqual([h.tot_dr, h.tot_cr, h.sl_fine], [9.66, 9.41, 9.16]);
        return {
          observation: 'totals 9.660 / 9.410 / 0.250 on screen and in the header',
          expected: { totDr: 9.66, totCr: 9.41, slFine: 9.16 },
          database: { header: h },
          downstream: await downstreamOf(ctx, await voucherOf(created)),
        };
      },
    ),
    C(
      'formula.detail-rollup-to-line',
      'T03',
      'mutation',
      'The detail rows roll into the issue line: OthWt 0.500, NetWt 4.500, OthAmt 1263.00 (TR_WH_SALE.cs:7821-7880)',
      async (ctx) => {
        const { page } = await open(ctx);
        const created = await looseSale(page);
        assert.equal(created.status(), 201, await created.text());
        const vchNo = await voucherOf(created);
        const [line] = await ctx.rows(
          `SELECT "ITM_OTH_WT"::float8 AS oth,"ITM_NWT"::float8 AS nwt,"OTH_AMT"::float8 AS amt FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert.deepEqual(line, { oth: 0.5, nwt: 4.5, amt: 1263 });
        await load(page, vchNo);
        await value(page, 'OthWt Issue line 1', '0.5');
        await value(page, 'NetWt Issue line 1', '4.5');
        return {
          observation: 'line OthWt 0.5, NetWt 4.5, OthAmt 1263 stored and shown',
          expected: line,
          database: { vchNo },
          downstream: await downstreamOf(ctx, vchNo),
        };
      },
    ),
    C(
      'create.loose-item-detail-rows',
      'T05',
      'mutation',
      'Loose rows land in SL_IDTL keyed by the line, ISR_NO restarting at 1, ENTRY_TYPE W; an empty row is skipped (TR_WH_SALE.cs:13162-13250)',
      async (ctx) => {
        const { page } = await open(ctx);
        const created = await looseSale(page, { rows: [ROW_A, ROW_B, {}] });
        assert.equal(created.status(), 201, await created.text());
        const vchNo = await voucherOf(created);
        assert.deepEqual(await slidtl(ctx, vchNo), LOOSE_ROWS);
        return {
          observation: 'two rows written, the empty third skipped',
          expected: LOOSE_ROWS,
          database: { vchNo },
          downstream: await downstreamOf(ctx, vchNo),
        };
      },
    ),
    C(
      'create.loose-detail-write-set',
      'T07',
      'mutation',
      'The write set of a loose-row voucher with kasar: SL_IDTL, ledger legs 27/28/33/34, day book 07/08 and the line roll-up, all from one save',
      async (ctx) => {
        const { page } = await open(ctx);
        const created = await looseSale(page, { ksrDr: '0.5', ksrCr: '0.25' });
        assert.equal(created.status(), 201, await created.text());
        const vchNo = await voucherOf(created);
        const set = await writeSet(ctx, vchNo);
        assert.equal(set.SL_IDTL.length, 2);
        const legCodes = (await legs(ctx, vchNo)).map((l) => l[0]);
        for (const code of ['27', '28', '33', '34']) assert(legCodes.includes(code), `leg ${code}`);
        const keys = (await rojmelRows(ctx, vchNo)).map((r) => r.key.slice(-2));
        assert(keys.includes('07') && keys.includes('08'));
        assert.deepEqual(
          (await slidtl(ctx, vchNo)).map((r) => r.krconwt),
          [0, 0],
          'KR_CON_WT is never written (decision 2)',
        );
        return {
          observation: `legs ${legCodes.join(',')}; rojmel ${keys.join(',')}`,
          expected: { sl_idtl: 2 },
          database: { vchNo },
          downstream: { legCodes, rojmelTypes: keys },
        };
      },
    ),
    C(
      'refusal.detail-row-no-item-code',
      'T06',
      'mutation',
      'A detail row with no item code saves with IT_CODE empty: the only item-code refusal is for the issue grid (TR_WH_SALE.cs:12894-12895)',
      async (ctx) => {
        const { page } = await open(ctx);
        // itCode '' overrides the gold code looseSale gives its first row, so the row really has no item code.
        const created = await looseSale(page, {
          rows: [{ itCode: '', pcs: '1', grossWt: '1' }],
          cash: 0,
        });
        assert.equal(created.status(), 201, await created.text());
        const vchNo = await voucherOf(created);
        const [row] = await slidtl(ctx, vchNo);
        assert.equal(row.it, '');
        return {
          observation: 'saved with IT_CODE empty',
          expected: { it: '' },
          database: { row },
          downstream: await downstreamOf(ctx, vchNo),
        };
      },
    ),
    C(
      'refusal.kasar-any-number',
      'T06',
      'refusal',
      'The kasar boxes take any number and format it "0.000" (TR_WH_SALE.cs:16035): -1 is -1.000, 12.3456 is 12.346, text is 0.000; the hosted service refuses a negative kasar on save',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const box = page.getByLabel('Ksr Fine Dr', { exact: true });
        for (const [typed, shown] of [
          ['-1', '-1.000'],
          ['12.3456', '12.346'],
          ['abc', '0.000'],
        ]) {
          await typeKasar(page, 'Ksr Fine Dr', typed);
          await value(page, 'Ksr Fine Dr', shown);
        }
        await typeKasar(page, 'Ksr Fine Dr', '-1');
        const before = await counts(ctx);
        const response = await sell(page, { tag: t.tag, cutFine: t.fine, cash: 59540 });
        assert.equal(response.status(), 400, await response.text());
        assert.deepEqual(await counts(ctx), before, 'nothing written');
        assert.equal(await box.inputValue(), '-1.000');
        return {
          observation:
            'formatted as the desktop does; the save of -1.000 is refused, nothing written',
          expected: { status: 400 },
          database: { before },
        };
      },
    ),
    C(
      'keyboard.ksr-fine-enter-tab',
      'T17',
      'read-only',
      'Enter in a kasar box formats it, recomputes the bill and moves to the next control (TR_WH_SALE.cs:16035-16047)',
      async (ctx) => {
        const { page } = await open(ctx);
        const dr = page.getByLabel('Ksr Fine Dr', { exact: true });
        await dr.fill('0.5');
        await dr.press('Enter');
        await value(page, 'Ksr Fine Dr', '0.500');
        await text(page, 'wholesale-sale-tot-fine-dr', '0.500');
        const focused = await page.evaluate(
          () =>
            document.activeElement?.labels?.[0]?.textContent ??
            document.activeElement?.getAttribute('aria-label') ??
            '',
        );
        assert.equal(focused, 'Ksr Fine Cr');
        return {
          observation: 'formatted, totals recomputed, focus on Ksr Fine Cr',
          expected: { focus: 'Ksr Fine Cr' },
        };
      },
    ),
    C(
      'keyboard.detail-grid-enter-esc-ctrl-d',
      'T17',
      'read-only',
      'Enter walks the detail cells and sets Weight from Pcs x PcsWt (:7503); Enter in the last NetAmt adds a row (:7522); Ctrl+D asks the desktop question (:7331); Esc returns to the issue line (:13625)',
      async (ctx) => {
        const { page } = await open(ctx);
        await pick(page, 'ItCode Issue line 1', ITEMS.gold.code);
        await openDetail(page);
        await page.getByLabel('Pcs detail 1', { exact: true }).fill('2');
        const pcsWt = page.getByLabel('PcsWt detail 1', { exact: true });
        await pcsWt.fill('1.5');
        await pcsWt.press('Enter');
        await value(page, 'Weight detail 1', '3.000');
        await page.getByLabel('NetAmt detail 1', { exact: true }).press('Enter');
        await detailCaretMoved(page, 2);
        await page.getByLabel('Pcs detail 2', { exact: true }).waitFor();
        let question = '';
        page.removeAllListeners('dialog');
        page.on('dialog', (dialog) => {
          question = dialog.message();
          void dialog.accept();
        });
        await page.getByLabel('Pcs detail 2', { exact: true }).press('Control+d');
        for (let i = 0; i < 20 && !question; i++) await page.waitForTimeout(100);
        page.removeAllListeners('dialog');
        page.on('dialog', (dialog) => void dialog.accept());
        assert.equal(question, 'This Row Record will Removed permantley ?');
        await page.getByLabel('Pcs detail 1', { exact: true }).press('Escape');
        assert.equal(
          await page.getByRole('region', { name: 'Item detail Issue line 1' }).count(),
          0,
          'Esc closes the panel',
        );
        return {
          observation: 'Weight 3.000 on Enter, row added, Ctrl+D question, Esc closes',
          expected: { question },
        };
      },
    ),
    C(
      'reopen.loose-detail-rows-return',
      'T08',
      'mutation',
      'GET returns the detail rows and the kasar (TR_WH_SALE.cs:12588-12630, :12230); an unchanged save leaves every stored column of every table identical',
      async (ctx) => {
        const { page } = await open(ctx);
        const created = await looseSale(page, { ksrDr: '0.5', ksrCr: '0.25' });
        assert.equal(created.status(), 201, await created.text());
        const vchNo = await voucherOf(created);
        const before = await writeSet(ctx, vchNo);
        await load(page, vchNo);
        await value(page, 'Ksr Fine Dr', '0.500');
        await value(page, 'Ksr Fine Cr', '0.250');
        await openDetail(page);
        await value(page, 'Pcs detail 1', '2');
        await value(page, 'NetAmt detail 2', '500');
        const updated = await save(page);
        assert.equal(updated.status(), 200, await updated.text());
        assert.deepEqual(
          await writeSet(ctx, vchNo),
          before,
          'an unchanged save keeps every column',
        );
        return {
          observation: 'rows, kasar and version came back; the unchanged save was identical',
          expected: { identical: true },
          database: { vchNo },
          downstream: await downstreamOf(ctx, vchNo),
        };
      },
    ),
    C(
      'edit.loose-detail-row-change',
      'T09',
      'mutation',
      'Edit rewrites the rows from the screen: row B at Pcs 3 priced 101 x 2.000 g = 202.00 and row A deleted (TR_WH_SALE.cs:12937)',
      async (ctx) => {
        const { page } = await open(ctx);
        const created = await looseSale(page);
        const vchNo = await voucherOf(created);
        await load(page, vchNo);
        await openDetail(page);
        let accepted = false;
        page.removeAllListeners('dialog');
        page.on('dialog', (dialog) => {
          accepted = true;
          void dialog.accept();
        });
        await page.getByLabel('Pcs detail 1', { exact: true }).press('Control+d');
        for (let i = 0; i < 20 && !accepted; i++) await page.waitForTimeout(100);
        page.removeAllListeners('dialog');
        page.on('dialog', (dialog) => void dialog.accept());
        await page.getByLabel('Pcs detail 1', { exact: true }).fill('3');
        await page.getByLabel('Rate detail 1', { exact: true }).fill('101');
        await page.getByLabel('NetAmt detail 1', { exact: true }).fill('0');
        await page.getByLabel('NetAmt detail 1', { exact: true }).press('Enter');
        await detailCaretMoved(page, 2);
        await page.getByLabel('Received Cash Amt', { exact: true }).fill('202');
        const updated = await save(page);
        assert.equal(updated.status(), 200, await updated.text());
        const rows = await slidtl(ctx, vchNo);
        assert.equal(rows.length, 1);
        assert.deepEqual([rows[0].isr, rows[0].pcs, rows[0].amt, rows[0].net], [1, 3, 202, 202]);
        return {
          observation: 'one row, Pcs 3, ItAmt 202.00',
          expected: { isr: 1, pcs: 3, amt: 202 },
          database: { vchNo, rows },
          downstream: await downstreamOf(ctx, vchNo),
        };
      },
    ),
    C(
      'delete.removes-detail-rows',
      'T10',
      'mutation',
      "Delete removes this voucher's SL_IDTL rows and no other voucher's (TR_WH_SALE.cs:13567, :12937)",
      async (ctx) => {
        const { page } = await open(ctx);
        const sentinel = await looseSale(page);
        const keep = await voucherOf(sentinel);
        await page.getByRole('button', { name: 'New', exact: true }).click();
        const created = await looseSale(page);
        const vchNo = await voucherOf(created);
        await load(page, vchNo);
        const declined = await deleteLoaded(page, false);
        assert.equal(declined.question, DELETE_QUESTION);
        assert.equal((await slidtl(ctx, vchNo)).length, 2, 'No leaves the rows');
        const done = await deleteLoaded(page, true);
        assert.equal(done.response.status(), 200, await done.response.text());
        assert.equal((await slidtl(ctx, vchNo)).length, 0);
        assert.equal((await slidtl(ctx, keep)).length, 2, 'the other voucher keeps its rows');
        return {
          observation: 'rows removed with the voucher; sentinel untouched',
          expected: { removed: 2, kept: 2 },
          database: { vchNo, keep },
          downstream: {
            deleted: await downstreamOf(ctx, vchNo),
            kept: await downstreamOf(ctx, keep),
          },
        };
      },
    ),
    C(
      'concurrency.detail-row-race',
      'T12',
      'mutation',
      "Two sessions edit the same voucher: the first save wins, the second answers 409 voucher-version-conflict and the rows are exactly the winner's",
      async (ctx) => {
        const first = await open(ctx);
        const created = await looseSale(first.page);
        const vchNo = await voucherOf(created);
        const second = await open(ctx);
        await load(first.page, vchNo);
        await load(second.page, vchNo);
        await openDetail(second.page);
        await second.page.getByLabel('Pcs detail 2', { exact: true }).fill('3');
        await openDetail(first.page);
        await first.page.getByLabel('Pcs detail 1', { exact: true }).fill('4');
        await first.page.getByLabel('NetAmt detail 1', { exact: true }).press('Enter');
        const won = await save(first.page);
        assert.equal(won.status(), 200, await won.text());
        const lost = await save(second.page);
        assert.equal(lost.status(), 409, await lost.text());
        assert.equal((await lost.json()).error, 'voucher-version-conflict');
        const rows = await slidtl(ctx, vchNo);
        assert.deepEqual(
          rows.map((r) => r.pcs),
          [4, 2],
          "exactly the winner's rows",
        );
        return {
          observation: 'first save 200, second 409',
          expected: { winner: [4, 2] },
          database: { rows },
          downstream: await downstreamOf(ctx, vchNo),
        };
      },
    ),
    C(
      'concurrency.stale-delete-refused',
      'T12',
      'refusal',
      'N51 (D17): a delete sends the version its load returned; after another session changed the voucher the delete answers 409 voucher-version-conflict, the screen shows the conflict message and every row of the write set is exactly as the other session left it',
      async (ctx) => {
        const first = await open(ctx);
        const created = await looseSale(first.page);
        const vchNo = await voucherOf(created);
        const second = await open(ctx);
        await load(first.page, vchNo);
        await load(second.page, vchNo);
        await openDetail(second.page);
        await second.page.getByLabel('Pcs detail 2', { exact: true }).fill('3');
        await second.page.getByLabel('NetAmt detail 2', { exact: true }).press('Enter');
        const changed = await save(second.page);
        assert.equal(changed.status(), 200, await changed.text());
        const before = await writeSet(ctx, vchNo);
        const { response } = await deleteLoaded(first.page, true);
        assert.equal(response.status(), 409, await response.text());
        assert.equal((await response.json()).error, 'voucher-version-conflict');
        const shown = await alertText(first.page);
        assert.match(shown, /changed by someone else after you opened it/);
        assert.deepEqual(await writeSet(ctx, vchNo), before, 'the stale delete removed nothing');
        const audit = await ctx.rows(
          `SELECT 1 FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert.equal(audit.length, 0, 'no DELETE_DATA row for the refused delete');
        return {
          observation: `stale delete 409; screen says "${shown.trim()}"`,
          expected: { status: 409, rowsUnchanged: true, audit: 0 },
          database: { vchNo, slidtl: (await slidtl(ctx, vchNo)).length },
        };
      },
    ),
    C(
      'rollback.fault-on-slidtl-row',
      'T14',
      'mutation',
      'A fault on the second SL_IDTL insert rolls the whole voucher back: header, lines, ledger, day book and stock',
      async (ctx) => {
        await ctx.owner.$executeRawUnsafe(
          `CREATE OR REPLACE FUNCTION e2e_ws_idtl_fault() RETURNS trigger AS $$ BEGIN IF NEW."ISR_NO" = 2 AND NEW.tenant_id = '${ctx.tenantId}' THEN RAISE EXCEPTION 'e2e fault'; END IF; RETURN NEW; END $$ LANGUAGE plpgsql`,
        );
        await ctx.owner.$executeRawUnsafe(
          `CREATE TRIGGER e2e_ws_idtl_fault BEFORE INSERT ON "SL_IDTL" FOR EACH ROW EXECUTE FUNCTION e2e_ws_idtl_fault()`,
        );
        try {
          const before = await counts(ctx);
          const { page } = await open(ctx);
          const response = await looseSale(page, { ksrDr: '0.5' });
          assert(response.status() >= 400, 'the save fails');
          assert.deepEqual(await counts(ctx), before, 'nothing written');
          return {
            observation: `status ${response.status()}; counts unchanged`,
            expected: { rolledBack: true },
            database: { before },
            downstream: { after: await counts(ctx) },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `DROP TRIGGER IF EXISTS e2e_ws_idtl_fault ON "SL_IDTL"`,
          );
          await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_ws_idtl_fault()`);
        }
      },
    ),
    C(
      'ledger.ksr-fine-legs',
      'T18',
      'mutation',
      'Fine kasar posts four metal-only legs: 27 party + and 28 slot-12 - for the Cr kasar, 33 party - and 34 slot-12 + for the Dr kasar (Ac_Ledr.cs:685-705); the voucher stays balanced; an unchanged save keeps them',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const created = await sell(page, {
          tag: t.tag,
          cutFine: t.fine,
          cash: 59540,
          before: async () => {
            await typeKasar(page, 'Ksr Fine Dr', '0.5');
            await typeKasar(page, 'Ksr Fine Cr', '0.25');
          },
        });
        assert.equal(created.status(), 201, await created.text());
        const vchNo = await voucherOf(created);
        const all = await legs(ctx, vchNo);
        const pick4 = (code) => all.find((l) => l[0] === code);
        assert.deepEqual(pick4('27').slice(2, 6), [0, 0, '+', 0.25]);
        assert.deepEqual(pick4('28').slice(2, 6), [0, 0, '-', 0.25]);
        assert.deepEqual(pick4('33').slice(2, 6), [0, 0, '-', 0.5]);
        assert.deepEqual(pick4('34').slice(2, 6), [0, 0, '+', 0.5]);
        assert.equal(pick4('27')[1], PARTIES.local.code);
        assert.equal(pick4('33')[1], PARTIES.local.code);
        const sums = all.reduce((a, l) => [a[0] + l[2], a[1] + l[3]], [0, 0]);
        assert.equal(Math.round(sums[0] * 100), Math.round(sums[1] * 100), 'Dr = Cr');
        const before = await writeSet(ctx, vchNo);
        await load(page, vchNo);
        const updated = await save(page);
        assert.equal(updated.status(), 200, await updated.text());
        assert.deepEqual(await writeSet(ctx, vchNo), before);
        return {
          observation: 'legs 27/28/33/34 as the source, balanced, stable on resave',
          expected: { legs: ['27', '28', '33', '34'] },
          database: { vchNo, legs: all },
          downstream: { drCr: sums },
        };
      },
    ),
    C(
      'rojmel.ksr-fine-rows',
      'T18',
      'mutation',
      'Day book rows 07 (Dr kasar, sign -) and 08 (Cr kasar, sign +) named KSR - party, fine in ITM_FINE, money 0 (Ac_Rojmel.cs:235-237); both go when the kasar is 0',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const created = await sell(page, {
          tag: t.tag,
          cutFine: t.fine,
          cash: 59540,
          before: async () => {
            await typeKasar(page, 'Ksr Fine Dr', '0.5');
            await typeKasar(page, 'Ksr Fine Cr', '0.25');
          },
        });
        const vchNo = await voucherOf(created);
        const rows = await rojmelRows(ctx, vchNo);
        const r07 = rows.find((r) => r.key.endsWith('07'));
        const r08 = rows.find((r) => r.key.endsWith('08'));
        assert.deepEqual(
          [r07.name, r07.sign, r07.fine, r07.dr, r07.cr],
          [`KSR - ${PARTIES.local.name}`, '-', 0.5, 0, 0],
        );
        assert.deepEqual(
          [r08.name, r08.sign, r08.fine, r08.dr, r08.cr],
          [`KSR - ${PARTIES.local.name}`, '+', 0.25, 0, 0],
        );
        await load(page, vchNo);
        await typeKasar(page, 'Ksr Fine Dr', '0');
        await typeKasar(page, 'Ksr Fine Cr', '0');
        const updated = await save(page);
        assert.equal(updated.status(), 200, await updated.text());
        assert(
          !(await rojmelRows(ctx, vchNo)).some((r) => /0[78]$/.test(r.key)),
          'both rows gone with the kasar',
        );
        return {
          observation: 'rows 07/08 written, then removed at 0',
          expected: { r07: 0.5, r08: 0.25 },
          database: { vchNo, rows },
          downstream: await downstreamOf(ctx, vchNo),
        };
      },
    ),
    C(
      'rojmel.lined-voucher-rows-05-06-14-27',
      'T18',
      'mutation',
      'A fine-only issue line writes day book row 05 keyed with its line number; labour writes 27 (Ac_Rojmel.cs:231, :249, :275)',
      async (ctx) => {
        const { page } = await open(ctx);
        await page.getByLabel('Date', { exact: true }).fill(DAY);
        await pick(page, 'Party', PARTIES.local.code);
        await pick(page, 'ItCode Issue line 1', ITEMS.gold.code);
        await page.getByLabel('Pcs Issue line 1', { exact: true }).fill('1');
        await page.getByLabel('GrWt Issue line 1', { exact: true }).fill('10');
        await page.getByLabel('Touch Issue line 1', { exact: true }).fill('91.6');
        await page.getByLabel('LbrRate Issue line 1', { exact: true }).fill('10');
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = await voucherOf(response);
        const rows = await rojmelRows(ctx, vchNo);
        const r05 = rows.find((r) => /05 +1$/.test(r.key));
        assert(r05, 'row 05 keyed with the line number');
        assert.deepEqual([r05.sign, r05.name, r05.fine], ['-', PARTIES.local.name, 9.16]);
        const [h] = await ctx.rows(
          `SELECT "SL_LBR_AMT"::float8 AS lbr,"SL_OTH_AMT"::float8 AS oth FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        const r27 = rows.find((r) => r.key.endsWith('27'));
        assert.equal(r27.cr, h.lbr + h.oth);
        assert.equal(r27.name, `LBR - ${PARTIES.local.name}`);
        return {
          observation: 'rows 05 (line 1) and 27 as the source',
          expected: { r05: 9.16, r27: h.lbr + h.oth },
          database: { vchNo, rows },
          downstream: await downstreamOf(ctx, vchNo),
        };
      },
    ),
    C(
      'rojmel.key-and-name-shape',
      'T18',
      'mutation',
      'Keys and names follow Wh_Sales_Rojmel: BOOK_SNAME - AC_NAME on the header rows, KSR/LBR prefixes, the master name on line rows, the line number in 05/06 (Ac_Rojmel.cs:221-310)',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const created = await sell(page, { tag: t.tag, cutFine: t.fine, cash: 59540 });
        const vchNo = await voucherOf(created);
        const rows = await rojmelRows(ctx, vchNo);
        const [{ sname }] = await ctx.rows(
          `SELECT "BOOK_SNAME" AS sname FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
        );
        for (const row of rows) {
          const type = row.key.slice(21, 23);
          if (['03', '04'].includes(type))
            assert.equal(row.name, `${sname} - ${PARTIES.local.name}`, `type ${type} name`);
          if (type === '05') assert.match(row.key, /05 +\d+$/, 'line number in the key');
        }
        return {
          observation: `${rows.length} rows checked`,
          expected: { names: true },
          database: { vchNo, rows },
          downstream: await downstreamOf(ctx, vchNo),
        };
      },
    ),
    C(
      'output.print-detail-under-line',
      'T16',
      'output',
      "The bill prints a line's detail rows right under it, in ISR_NO order, with name, pieces, weight, rate and net amount (WhSalesBill area 5)",
      async (ctx) => {
        const { page } = await open(ctx);
        const created = await looseSale(page);
        assert.equal(created.status(), 201, await created.text());
        const [doc] = await Promise.all([
          page.waitForEvent('popup'),
          page.getByRole('button', { name: 'Print', exact: true }).click(),
        ]);
        await doc.waitForURL(/\/api\/wholesale-sales\/\d+\/print/);
        await doc.waitForLoadState();
        const body = ((await doc.textContent('body')) ?? '').replace(/\s+/g, ' ');
        for (const expected of ['Rate 101.00', '763.00', 'Rate 0.00', '500.00'])
          assert(body.includes(expected), `the bill shows ${expected}`);
        assert(body.indexOf('763.00') < body.indexOf('500.00'), 'ISR_NO order');
        return {
          observation: 'rows 763.00 then 500.00 under the line',
          expected: { order: true },
          output: Buffer.from(body),
        };
      },
    ),
    C(
      'output.print-kasar-fine-row',
      'T16',
      'output',
      'The band prints the stored kasar: Kasar Fine 0.250 / 0.500 (WhSalesBill @RecFine, @IsuFine from KSR_FINE_*)',
      async (ctx) => {
        const t = await seedTag(ctx);
        const { page } = await open(ctx);
        const created = await sell(page, {
          tag: t.tag,
          cutFine: t.fine,
          cash: 59540,
          before: async () => {
            await typeKasar(page, 'Ksr Fine Dr', '0.5');
            await typeKasar(page, 'Ksr Fine Cr', '0.25');
          },
        });
        assert.equal(created.status(), 201, await created.text());
        const [doc] = await Promise.all([
          page.waitForEvent('popup'),
          page.getByRole('button', { name: 'Print', exact: true }).click(),
        ]);
        await doc.waitForURL(/\/api\/wholesale-sales\/\d+\/print/);
        await doc.waitForLoadState();
        const body = ((await doc.textContent('body')) ?? '').replace(/\s+/g, ' ');
        assert(/Kasar Fine\s*0\.250\s*0\.500/.test(body), 'Kasar Fine 0.250 0.500');
        return {
          observation: 'Kasar Fine row prints 0.250 / 0.500',
          expected: { cr: 0.25, dr: 0.5 },
          output: Buffer.from(body),
        };
      },
    ),
    C(
      'rojmel.missing-types-and-silver',
      'T18',
      'mutation',
      'Ac_Rojmel.cs:243,245,251,259-261: silver header and line rows use slot 8 and silver keys.',
      async (ctx) => {
        const { page } = await open(ctx);
        await page.getByLabel('Date', { exact: true }).fill(DAY);
        await pick(page, 'Party', PARTIES.local.code);
        await page.getByLabel('Item Type', { exact: true }).selectOption('S');
        await pick(page, 'ItCode Issue line 1', ITEMS.silver.code);
        await page.getByLabel('Pcs Issue line 1', { exact: true }).fill('1');
        await page.getByLabel('GrWt Issue line 1', { exact: true }).fill('10');
        await page.getByLabel('Touch Issue line 1', { exact: true }).fill('92.5');
        await page.getByLabel('1gm Rate', { exact: true }).fill('100');
        await page.getByLabel('Ac Fine Cr', { exact: true }).fill('9.25');
        await typeKasar(page, 'Ksr Fine Dr', '0.5');
        await typeKasar(page, 'Ksr Fine Cr', '0.25');
        const first = await save(page);
        assert.equal(first.status(), 201, await first.text());
        const no = await voucherOf(first);
        const rows = await rojmelRows(ctx, no);
        const types = rows.map((r) =>
          r.key.slice(-2).trim() === '1' ? r.key.slice(-12, -10) : r.key.slice(-2),
        );
        assert.deepEqual(types.sort(), ['11', '12', '15', '19', '20']);
        const slots = await ctx.rows(
          `SELECT "SR_NO"::int AS sr,"AC_CODE" AS ac FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_BOOK"='WHS'`,
        );
        const slot8 = slots.find((r) => r.sr === 8).ac;
        const sale = rows.find((r) => r.key.endsWith('12'));
        assert.equal(sale.ac, slot8);
        assert.equal(sale.cr, 925);
        assert.equal(sale.name, '');
        const line = rows.find((r) => r.key.endsWith('15         1'));
        assert.equal(line.ld, slot8);
        assert.equal(line.fine, 9.25);
        assert.equal(line.sign, '-');
        return {
          observation: 'Silver rows 11/12/15/19/20 persisted',
          expected: { types, amount: 925, fine: 9.25 },
          database: { rows },
          downstream: await downstreamOf(ctx, no),
        };
      },
    ),
    C(
      'refusal.detail-row-delete-right',
      'T06',
      'refusal',
      'TR_WH_SALE.cs:7326-7331: no delete right in edit mode leaves the detail row intact.',
      async (ctx) => restrictedDetails(ctx, false),
    ),
    C(
      'rights.detail-delete-and-print',
      'T11',
      'refusal',
      'TR_WH_SALE.cs:7326,13658: delete and print are independently refused by the UI and server.',
      async (ctx) => restrictedDetails(ctx, true),
    ),
    C(
      'rights.quotation-print-needs-frm-print',
      'T11',
      'refusal',
      'MDI_FORM.cs:8149-8156 opens TR_WH_SALE as Wh Quotation; TR_WH_SALE.cs:13658-13660 answers "You Have No Print Rights....." without that caption\'s FRM_PRINT.',
      async (ctx) => {
        const openQuotation = async (credentials) => {
          const { page } = await ctx.session(credentials);
          await page.goto('/txn/wholesale-quotation');
          await page.getByRole('heading', { name: 'Wholesale Quotation', exact: true }).waitFor();
          const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
          for (let i = 0; i < 50 && (await book.inputValue()) !== QUOTE_BOOK; i++)
            await page.waitForTimeout(100);
          assert.equal(await book.inputValue(), QUOTE_BOOK, 'the provisioned WH QUOT book');
          return page;
        };
        const admin = await openQuotation();
        await admin.getByLabel('Date', { exact: true }).fill(DAY);
        await pick(admin, 'Party', PARTIES.local.code);
        await pick(admin, 'ItCode Issue line 1', ITEMS.gold.code);
        await admin.getByLabel('Pcs Issue line 1', { exact: true }).fill('1');
        await admin.getByLabel('GrWt Issue line 1', { exact: true }).fill('5');
        await admin.getByLabel('Touch Issue line 1', { exact: true }).fill('91.6');
        const [created] = await Promise.all([
          admin.waitForResponse(
            (r) =>
              new URL(r.url()).pathname === '/api/wholesale-quotations' &&
              r.request().method() === 'POST',
          ),
          admin.locator('button[data-save-mnemonic]').click(),
        ]);
        assert.equal(created.status(), 201, await created.text());
        const no = await voucherOf(created);
        const quotation = async () =>
          ctx.rows(
            `SELECT "VCH_NO","AC_CODE","SL_NET_AMT"::float8 AS net FROM "RATE_CUT_DATA"
              WHERE tenant_id=$1 AND "CO_BOOK"='${QUOTE_BOOK}' AND "VCH_NO"=$2`,
            no,
          );
        const before = await quotation();
        assert.equal(before.length, 1, 'the quotation is stored');

        const viewer = await openQuotation(as(USERS.printViewer.user));
        let popups = 0;
        viewer.context().on('page', () => popups++);
        const box = viewer.getByLabel('Voucher No', { exact: true });
        await box.fill(String(Number(no)));
        await box.press('Enter');
        await text(viewer, 'wholesale-quotation-status', `Loaded voucher ${no}`);
        await viewer.getByRole('button', { name: 'Print', exact: true }).click();
        await viewer
          .getByRole('alert')
          .filter({ hasText: 'You Have No Print Rights.....' })
          .waitFor();
        assert.equal(popups, 0, 'no document window opens');
        const url = `/api/wholesale-quotations/${no}/print?coBook=${QUOTE_BOOK}&format=html`;
        const status = (await viewer.request.get(url)).status();
        assert.equal(status, 403, url);
        const after = await quotation();
        assert.deepEqual(after, before);
        return {
          observation: `print-less user saw the message; ${url} answered ${status}`,
          expected: 'message, no window, 403 from the quotation print route; quotation unchanged',
          database: { before, after },
        };
      },
    ),
    C(
      'retry.detail-row-double-post',
      'T13',
      'mutation',
      'One command key creates one voucher including its detail rows; a changed payload is refused.',
      async (ctx) => {
        const { page } = await open(ctx);
        const first = await looseSale(page);
        assert.equal(first.status(), 201, await first.text());
        assert.match(first.request().headers()['idempotency-key'] ?? '', /^[0-9a-f-]{36}$/);
        const no = await voucherOf(first);
        const before = await counts(ctx);
        const details = await slidtl(ctx, no);
        const downstream = await downstreamOf(ctx, no);
        const replay = await page.request.fetch(first.request());
        assert.equal(replay.status(), 201, await replay.text());
        assert.equal(replay.headers()['idempotency-replayed'], 'true');
        assert.deepEqual(await replay.json(), await first.json());
        const changed = await page.request.fetch(first.request(), {
          data: { ...first.request().postDataJSON(), vchDesc: 'different retry body' },
        });
        assert.equal(changed.status(), 409, await changed.text());
        assert.deepEqual(await counts(ctx), before);
        assert.deepEqual(await slidtl(ctx, no), details);
        assert.deepEqual(await downstreamOf(ctx, no), downstream);
        return {
          observation: 'Identical replay returned first voucher; changed body refused with 409',
          expected: { replay: 201, changed: 409, details: 2 },
          database: { before, details },
          downstream,
        };
      },
    ),
  ],
};
