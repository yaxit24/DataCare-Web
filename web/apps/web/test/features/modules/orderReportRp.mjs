import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

/**
 * Frozen browser matrix: Report → Order Report (desktop RP_ALL in its "Order Report" caption).
 *
 * WP-14 PHASE ONE — FROZEN CASE PLAN, NOT YET RUNNABLE.
 * The case list is orchestration/work/WP-14/cases.md: 28 cases across T01–T18, each with a desktop quote and
 * a status of executable. Three of those cases are database-layer and are covered by
 * web/apps/api/test/rpAllOrder.db.test.ts, so they are recorded here as N/A rather than duplicated.
 * The dedicated /reports/order-report screen and its "Order Report" navigation link do not exist yet
 * (study gap 1 and gap 14), so every executable case below fails red at navigation for that reason.
 *
 * Desktop authority (all quotes copied from cases.md, which verifies against the source):
 * - MDI_FORM.cs:8931 {{case "Order Report":}} opens RP_ALL; the caption selects the mode
 *   (RP_ALL.cs:6658 {{CurRpt = DC_Main.MsUserRightForm;}}) and the title label
 *   (RP_ALL.cs:6659 {{lblBook.Text = CurRpt;}}).
 * - The seven PanelOrder buttons are the data modes: Order Report, Order Advance, Order Adjust,
 *   Order Wise Bill, Making Panding, Making Summ and Bill Wise Adjust.
 * - Expected values are computed here from the seeded orders with the desktop formulas quoted in cases.md,
 *   never read back from the web application. The report itself calculates nothing
 *   (RP_ALL.cs:8418 {{DC_Main.RptName = "OrdDetlRpt";}} selects a template; the template sums the bands).
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `order-report.${id}`,
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

const notApplicable = (id, group, source, reason) => ({
  ...C(id, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});

const blocked = (id, group, kind, source, reason, expected = { pending: true }) => ({
  ...C(id, group, kind, source, async () => ({}), { expected }),
  blocked: reason,
});

const YEAR = '2025-2026';
const FROM = '2026-01-01';
const TO = '2026-01-31';
const WIDE_FROM = '2025-12-01';

/** Exact desktop button captions; the trailing space and the space after & are intentional. */
const BUTTONS = Object.freeze({
  report: '&Order Report',
  advance: '&Order Advance',
  adjust: '&Order Adjust',
  'with-bill': '&Order Wise Bill ',
  pending: '&Making Panding',
  summary: '& Making Summ',
  'bill-wise': 'Bill Wise Adjust',
});

/** Exact desktop selector captions in the tab order proved by entry.defaults-and-seven-buttons. */
const SELECTORS = Object.freeze([
  'From',
  'To',
  'lc Code',
  'Book',
  'Pr Code',
  'Gr Code',
  'Party Code',
  'Cust Name',
  'City',
  'Area',
  'Item Type',
]);

/** Titles are fixed desktop strings; dates are dd/MM/yyyy even though the selection formula uses MM/dd/yyyy. */
const TITLES = Object.freeze({
  report: 'Order Report From 01/01/2026 To 31/01/2026',
  advance: 'Order Advance Report From 01/01/2026 To 31/01/2026',
  adjust: 'Order Adjust Report From 01/01/2026 To 31/01/2026',
  'with-bill': 'Bill Wise Order Adjust Report From 01/01/2026 To 31/01/2026',
  pending: 'Order Design Issue Panding Report From 01/01/2026 To 31/01/2026',
  summary: 'Order Design Issue Panding Report From 01/01/2026 To 31/01/2026',
  'bill-wise': 'Bill Wise Order Adjust Report From 01/01/2026 To 31/01/2026',
});

const API_PATH = '/api/reports/order-report';

/** The frozen WP-14 seed, described once in cases.md §Test data and mirrored by rpAllOrder.db.test.ts. */
const ORDERS = Object.freeze({
  O1: {
    book: 'B1',
    vch: 'O1',
    date: '2026-01-05',
    party: 'P1',
    acName: 'ALPHA JEWELS',
    tot: 20000,
    adv: 5000,
    cash: 5000,
    lines: [
      { sr: 1, it: 'I1', design: 'D1', tag: 'T1', pcs: 1, nwt: 10.5, isu: 'N' },
      { sr: 2, it: 'I2', design: 'D2', tag: 'T2', pcs: 2, nwt: 5.25, isu: 'N' },
    ],
  },
  O2: {
    book: 'B2',
    vch: 'O2',
    date: '2026-01-10',
    party: 'P2',
    acName: 'BETA TRADERS',
    tot: 9000,
    adv: 0,
    cash: 0,
    lines: [{ sr: 1, it: 'I1', design: 'D1', tag: 'T3', pcs: 3, nwt: 7.125, isu: 'N' }],
  },
  O3: {
    book: 'B1',
    vch: 'O3',
    date: '2026-01-15',
    party: 'P1',
    acName: 'ALPHA JEWELS',
    tot: 9000,
    adv: 3000,
    cash: 0,
    lines: [{ sr: 1, it: 'I2', design: 'D3', tag: 'T3', pcs: 1, nwt: 4, isu: 'N' }],
  },
  O4: {
    book: 'B1',
    vch: 'O4',
    date: '2026-01-12',
    party: '',
    acName: 'WALK IN CUSTOMER',
    tot: 0,
    adv: 0,
    cash: 0,
    lines: [{ sr: 1, it: 'I1', design: 'D4', tag: 'T5', pcs: 1, nwt: 2, isu: 'N' }],
  },
  O5: {
    book: 'B1',
    vch: 'O5',
    date: '2025-12-20',
    party: 'P1',
    acName: 'ALPHA JEWELS',
    tot: 0,
    adv: 0,
    cash: 0,
    lines: [{ sr: 1, it: 'I1', design: 'D5', tag: 'T6', pcs: 2, nwt: 6, isu: 'N' }],
  },
  O6: {
    lc: '00',
    book: 'B1',
    vch: 'O6',
    date: '2026-01-08',
    party: 'P1',
    acName: 'ALPHA JEWELS',
    tot: 0,
    adv: 0,
    cash: 0,
    lines: [{ sr: 1, it: 'I1', design: 'D6', tag: 'T7', pcs: 1, nwt: 1, isu: 'N' }],
  },
  O7: {
    co: 'C2',
    book: 'B1',
    vch: 'O1',
    date: '2026-01-05',
    party: 'P1',
    acName: 'ALPHA JEWELS',
    tot: 0,
    adv: 0,
    cash: 0,
    lines: [{ sr: 1, it: 'I1', design: 'D7', tag: 'T8', pcs: 1, nwt: 1, isu: 'N' }],
  },
  O8: {
    book: 'B1',
    vch: 'O8',
    date: '2026-01-20',
    party: 'P2',
    acName: 'BETA TRADERS',
    tot: 0,
    adv: 0,
    cash: 0,
    lines: [{ sr: 1, it: 'I2', design: 'D8', tag: 'T9', pcs: 1, nwt: 3, isu: 'Y' }],
  },
});

const ADJUSTMENTS = Object.freeze([
  { vch: 'O1', sr: 1, date: '2026-01-05', sign: '+', amt: 5000, ord: 'O1', bill: '' },
  { vch: 'O1', sr: 2, date: '2026-01-18', sign: '-', amt: 1500, ord: 'S1', bill: 'S1' },
  { vch: 'O1', sr: 3, date: '2026-01-18', sign: '-', amt: 500, ord: 'S1', bill: 'S1' },
  { vch: 'O3', sr: 1, date: '2026-01-15', sign: '+', amt: 3000, ord: 'O3', bill: '' },
  { vch: 'O3', sr: 2, date: '2026-01-22', sign: '-', amt: 1500, ord: 'S2', bill: 'S2' },
  { vch: 'O3', sr: 3, date: '2026-01-22', sign: '-', amt: 1500, ord: 'S2', bill: 'S2' },
  { vch: 'O5', sr: 1, date: '2025-12-20', sign: '+', amt: 1000, ord: 'O5', bill: '' },
  { vch: 'O5', sr: 2, date: '2025-12-20', sign: '-', amt: 1000, ord: 'O5', bill: '' },
]);

const BILLS = Object.freeze([
  { vch: 'S1', date: '2026-01-18', party: 'P1', acName: 'ALPHA JEWELS', tot: 12000 },
  { vch: 'S2', date: '2026-01-22', party: 'P1', acName: 'ALPHA JEWELS', tot: 9000 },
]);

const VOUCHERS = Object.freeze([
  'O1',
  'O2',
  'O3',
  'O4',
  'O5',
  'O6',
  'O8',
  'S1',
  'S2',
  'S3',
  ...Array.from({ length: 30 }, (_, i) => `OP${String(i).padStart(3, '0')}`),
]);
const MASTERS = Object.freeze({
  BOOK_DATA: ['B1', 'B2', 'SB'],
  AC_MAST: ['P1', 'P2'],
  ITEM_MAST: ['I1', 'I2'],
  LOCT_MAST: ['00'],
});

const scoping = (o) => ({
  co: o.co ?? '01',
  lc: o.lc ?? '01',
  year: o.year ?? YEAR,
});
const inDefaultRange = (o) =>
  scoping(o).co === '01' && scoping(o).lc === '01' && o.date >= FROM && o.date <= TO;
const sumPcs = (lines) => lines.reduce((total, line) => total + line.pcs, 0);
const sumNwt = (lines) =>
  Math.round(lines.reduce((total, line) => total + line.nwt, 0) * 1000) / 1000;
const adjustmentsOf = (vch) => ADJUSTMENTS.filter((adj) => adj.vch === vch);
const netOf = (vch) =>
  adjustmentsOf(vch).reduce((total, adj) => total + (adj.sign === '+' ? adj.amt : -adj.amt), 0);

/**
 * The desktop's "fully adjusted" set (RP_ALL.cs:10927 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  = 0}})
 * has no row for an order without adjustments: its LEFT JOIN sum is NULL, so O2 is pending.
 */
const fullyAdjusted = (vch) => {
  const rows = adjustmentsOf(vch);
  return rows.length > 0 && netOf(vch) === 0;
};

/** Pending lines: stored DESIGN_ISU N and not fully adjusted (RP_ALL.cs:10940 {{AND {SL_ORD_DETL.DESIGN_ISU} = 'N'}}). */
const pendingKeys = () =>
  Object.values(ORDERS)
    .filter(inDefaultRange)
    .flatMap((o) =>
      o.lines
        .filter((line) => line.isu === 'N' && !fullyAdjusted(o.vch))
        .map((line) => `${o.vch}:${line.sr}`),
    );

const EXPECT = Object.freeze({
  reportKeys: ['O1:1', 'O1:2', 'O2:1', 'O3:1', 'O4:1', 'O8:1'],
  reportPcs: sumPcs(
    Object.values(ORDERS)
      .filter(inDefaultRange)
      .flatMap((o) => o.lines),
  ),
  reportNwt: sumNwt(
    Object.values(ORDERS)
      .filter(inDefaultRange)
      .flatMap((o) => o.lines),
  ),
  pendingKeys: pendingKeys(),
  pendingPcs: sumPcs(
    Object.values(ORDERS)
      .filter(inDefaultRange)
      .flatMap((o) => o.lines.filter((line) => line.isu === 'N' && !fullyAdjusted(o.vch))),
  ),
  pendingNwt: sumNwt(
    Object.values(ORDERS)
      .filter(inDefaultRange)
      .flatMap((o) => o.lines.filter((line) => line.isu === 'N' && !fullyAdjusted(o.vch))),
  ),
  adjust: {
    O1: {
      ord: adjustmentsOf('O1')
        .filter((a) => a.sign === '+')
        .reduce((s, a) => s + a.amt, 0),
      adj: adjustmentsOf('O1')
        .filter((a) => a.sign === '-')
        .reduce((s, a) => s + a.amt, 0),
      bal: netOf('O1'),
    },
    O3: {
      ord: adjustmentsOf('O3')
        .filter((a) => a.sign === '+')
        .reduce((s, a) => s + a.amt, 0),
      adj: adjustmentsOf('O3')
        .filter((a) => a.sign === '-')
        .reduce((s, a) => s + a.amt, 0),
      bal: netOf('O3'),
    },
  },
  withBill: {
    O1: adjustmentsOf('O1')
      .filter((a) => a.sign === '-')
      .reduce((s, a) => s + a.amt, 0),
    O3: adjustmentsOf('O3')
      .filter((a) => a.sign === '-')
      .reduce((s, a) => s + a.amt, 0),
  },
});

/** Every case seeds the same masters and sentinels, then removes exactly those rows again. */
async function clearFixture(ctx) {
  for (const table of ['SL_ORD_DATA', 'SL_ORD_DETL', 'SL_ORD_ADJ', 'SL_DATA'])
    await ctx.rows(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "VCH_NO" = ANY($2::text[])`, [
      ...VOUCHERS,
    ]);
  for (const [table, codes] of Object.entries(MASTERS)) {
    const column =
      table === 'AC_MAST'
        ? 'AC_CODE'
        : table === 'ITEM_MAST'
          ? 'IT_CODE'
          : table === 'LOCT_MAST'
            ? 'LC_CODE'
            : 'CO_BOOK';
    await ctx.rows(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "${column}" = ANY($2::text[])`, [
      ...codes,
    ]);
  }
}

async function seedFixture(ctx) {
  await clearFixture(ctx);
  const put = (sql, ...params) => ctx.rows(sql, ...params);
  await put(
    `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME","AC_CODE")
     SELECT $1::text,'01','00','Head Office','BRANCH'
      WHERE NOT EXISTS (SELECT 1 FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='00')`,
  );
  await put(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL","DATA_TYPE")
     SELECT $1::text,'01','01','B1','Order Book 1','OB1','SALES ORDER','O','Y','SL_ORD_DATA','SL_ORD_DETL','A'
      WHERE NOT EXISTS (SELECT 1 FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='B1')`,
  );
  await put(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL","DATA_TYPE")
     SELECT $1::text,'01','01','B2','Order Book 2','OB2','SALES ORDER','O','Y','SL_ORD_DATA','SL_ORD_DETL','B'
      WHERE NOT EXISTS (SELECT 1 FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='B2')`,
  );
  await put(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL","DATA_TYPE")
     SELECT $1::text,'01','01','SB','Sales Bill','SB','SALES','O','Y','SL_DATA','SL_DETL','L'
      WHERE NOT EXISTS (SELECT 1 FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SB')`,
  );
  await put(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_CITY","AC_AREA") VALUES
       ($1,'01','01','P1','ALPHA JEWELS','SURAT','ADAJAN'),
       ($1,'01','01','P2','BETA TRADERS','BARODA','ALKAPURI')`,
  );
  await put(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE") VALUES
       ($1,'01','I1','Gold Ring','G','G1'),($1,'01','I2','Gold Chain','G','G1')`,
  );
  for (const o of Object.values(ORDERS)) {
    const { co, lc, year } = scoping(o);
    await put(
      `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME",
       "TOT_AMT","ADV_AMT","CASH_AMT","CARD_AMT","CHQ_AMT","OLD_GL_AMT","OLD_SL_AMT")
       VALUES($1,$2,$3,$4,$5,$6,$7::date,$8,$9,$10,$11,$12,0,0,0,0)`,
      co,
      lc,
      year,
      o.book,
      o.vch,
      o.date,
      o.party,
      o.acName,
      o.tot,
      o.adv,
      o.cash,
    );
    for (const line of o.lines)
      await put(
        `INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "IT_CODE","DESIGN_NO","TAG_NO","ITM_PCS","ITM_NWT","DESIGN_ISU")
         VALUES($1,$2,$3,$4,$5,$6,$7,$8::date,$9,$10,$11,$12,$13,$14)`,
        co,
        lc,
        year,
        o.book,
        o.vch,
        line.sr,
        o.date,
        line.it,
        line.design,
        line.tag,
        line.pcs,
        line.nwt,
        line.isu,
      );
  }
  for (const adj of ADJUSTMENTS)
    await put(
      `INSERT INTO "SL_ORD_ADJ"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
       "ORD_SIGN","ORD_AMT","ORD_LC","ORD_YRCD","ORD_DBCD","ORD_NO")
       VALUES($1,'01','01',$2,'B1',$3,$4,$5::date,$6,$7,'01',$2,$8,$9)`,
      YEAR,
      adj.vch,
      adj.sr,
      adj.date,
      adj.sign,
      adj.amt,
      adj.bill ? 'SB' : 'B1',
      adj.ord,
    );
  for (const bill of BILLS)
    await put(
      `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME","TOT_AMT")
       VALUES($1,'01','01',$2,'SB',$3,$4::date,$5,$6,$7)`,
      YEAR,
      bill.vch,
      bill.date,
      bill.party,
      bill.acName,
      bill.tot,
    );
}

async function withFixture(ctx, exercise) {
  await seedFixture(ctx);
  try {
    return await exercise();
  } finally {
    await clearFixture(ctx);
  }
}

async function openReport(ctx, credentials) {
  const { page } = await ctx.session(credentials);
  await page.goto('/dashboard');
  const link = page.getByRole('link', { name: 'Order Report', exact: true });
  await link.waitFor({ timeout: 8000 });
  await link.click();
  await page.waitForURL('**/reports/order-report', { timeout: 8000 });
  await page.getByRole('heading', { name: 'Order Report', exact: true }).waitFor({ timeout: 8000 });
  return page;
}

/** The web label is the desktop caption without the WinForms & accelerator. */
async function field(page, caption) {
  const plain = caption.replaceAll('&', '').trim();
  for (const label of [plain, caption]) {
    const locator = page.getByLabel(label, { exact: true });
    if (await locator.count()) return locator;
  }
  throw new Error(`Order Report selector "${plain}" is not on the screen`);
}

async function panelButton(page, caption) {
  const plain = caption.replaceAll('&', '').trim();
  for (const name of [plain, caption]) {
    const locator = page.getByRole('button', { name, exact: true });
    if (await locator.count()) return locator;
  }
  throw new Error(`Order Report button "${plain}" is not on the screen`);
}

async function clearSelectors(page) {
  for (const caption of ['Book', 'Pr Code', 'Gr Code', 'Party Code', 'Cust Name']) {
    const locator = await field(page, caption);
    if ((await locator.count()) && !(await locator.isDisabled())) await locator.fill('');
  }
  for (const caption of ['City', 'Area', 'Item Type']) {
    const locator = await field(page, caption);
    if (!(await locator.count()) || (await locator.evaluate((el) => el.tagName)) !== 'SELECT')
      continue;
    await locator.selectOption({ index: 0 });
  }
}

async function runMode(page, mode, { from = FROM, to = TO, ...filters } = {}) {
  await clearSelectors(page);
  await field(page, 'From').fill(from);
  await field(page, 'To').fill(to);
  for (const [caption, value] of Object.entries(filters)) {
    if (value === undefined || value === null || value === '') continue;
    const locator = await field(page, caption);
    if ((await locator.count()) && !(await locator.isDisabled())) await locator.fill(String(value));
  }
  const received = page.waitForResponse(
    (response) =>
      new URL(response.url()).pathname === API_PATH && response.request().method() === 'GET',
    { timeout: 15000 },
  );
  await (await panelButton(page, BUTTONS[mode])).click();
  const response = await received;
  assert.equal(response.status(), 200, `mode ${mode}: ${await response.text()}`);
  return {
    response,
    query: new URL(response.url()).searchParams,
    body: await response.json(),
  };
}

async function readGrid(page) {
  const headers = await page.locator('table.grid thead th').allTextContents();
  const rows = await page
    .locator('table.grid tbody tr')
    .evaluateAll((trs) =>
      trs.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
    );
  const footer = await page
    .locator('table.grid tfoot tr td')
    .evaluateAll((tds) => tds.map((td) => td.textContent.trim()));
  return { headers, rows, footer };
}

function assertCodes(grid, expected, absent = []) {
  const text = grid.rows.map((row) => row.join(' ')).join('\n');
  for (const code of expected)
    assert(text.includes(code), `expected ${code} in the grid, got ${text.slice(0, 500)}`);
  for (const code of absent)
    assert(
      !text.includes(code),
      `${code} must not appear in this report, got ${text.slice(0, 500)}`,
    );
}

async function observeCurrent(ctx) {
  const { page } = await ctx.session();
  await page.goto('/reports/order-report');
  return {
    url: new URL(page.url()).pathname,
    headings: await page.getByRole('heading').allTextContents(),
    buttons: await page.getByRole('button').allTextContents(),
    tableHeaders: await page.locator('table thead th').allTextContents(),
  };
}

function desiredCase(id, group, kind, source, expected, exercise, extra = {}) {
  return C(
    id,
    group,
    kind,
    source,
    async (ctx) => {
      const page = await openReport(ctx);
      if (exercise) await exercise({ ctx, page });
      await ctx.shot(page, id.replaceAll('.', '-'));
      return {
        observation: `Order Report contract exercised for ${id}`,
        expected,
        ...(kind === 'refusal' ? { database: { unchanged: true } } : {}),
        ...(kind === 'mutation'
          ? { database: { sourceFollowed: true }, downstream: { reportReconciled: true } }
          : {}),
        ...(kind === 'output' ? { output: Buffer.from(JSON.stringify(expected)) } : {}),
      };
    },
    { expected, observe: observeCurrent, ...extra },
  );
}

async function ensureUser(ctx, { user, subMenu, lcCode = '01', print = 'Y' }) {
  await ctx.rows(
    `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
     SELECT $1::text,'01',$2::text,$3::text,'USER','N','N',$4::text,'N'
      WHERE NOT EXISTS (SELECT 1 FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "LOGIN_NAME"=$2::text)`,
    user,
    await ctx.stack.hashPassword(process.env.FEATURE_E2E_PASSWORD),
    print,
  );
  await ctx.rows(
    `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
     SELECT $1::text,'01',$2::text,$3::text,'Report',$4::text,'Y','N','N',$5::text
      WHERE NOT EXISTS (SELECT 1 FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$3::text AND "SUB_MENU"=$4::text)`,
    lcCode,
    user,
    subMenu,
    print,
  );
}

const DB_LAYER =
  'Browser layer intentionally absent: this case is a database assertion covered in full by ' +
  'web/apps/api/test/rpAllOrder.db.test.ts; keep it in the denominator but do not duplicate the SQL here.';

export const orderReportRp = {
  feature: 'order-report',
  title: 'Report → Order Report (RP_ALL)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/api/src/modules/reports/rpAll/index.ts',
    'web/apps/api/src/modules/reports/rpAll/engine.ts',
    'web/apps/api/src/modules/reports/rpAll/filters.ts',
    'web/apps/api/src/modules/reports/rpAll/orderLayouts.ts',
    'web/apps/api/src/modules/reports/rpAll/orderQuery.ts',
    'web/apps/api/src/modules/reports/rpAll/exportRows.ts',
    'web/apps/api/src/modules/reports/rpAll/types.ts',
    'web/apps/api/src/routes/rpAllReport.ts',
    'web/apps/web/test/features/modules/orderReportRp.mjs',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    MsDataType:
      'not ported (no session data type in the web); RP_ALL.cs:8405 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}}',
    edition: 'Lite; the menu row is visible (cases.md D1)',
    resultFixtures:
      'masters and sentinels only; orders through the real Sales Order screen or the same SQL helpers',
    readOnly: `RP_ALL.cs:10933 {{UPDATE SL_ORD_DETL SET DESIGN_ISU = 'Y' WHERE CO_CODE = '}} is never reproduced (D2)`,
  },
  cases: [
    desiredCase(
      'entry.menu-route',
      'T01',
      'read-only',
      'MDI_FORM.cs:8931 {{case "Order Report":}}; RP_ALL.cs:6658 {{CurRpt = DC_Main.MsUserRightForm;}}; RP_ALL.cs:6659 {{lblBook.Text = CurRpt;}}; the catalog row still points at /txn/sales-order (study gap 14)',
      {
        route: '/reports/order-report',
        title: 'Order Report',
        notRoute: '/txn/sales-order',
        menuVisibleInLite: true,
      },
      async ({ page }) => {
        const url = new URL(page.url()).pathname;
        assert.equal(url, '/reports/order-report', `opened ${url}, not the dedicated report page`);
        await page.getByRole('heading', { name: 'Order Report', exact: true }).waitFor();
        assert.equal(
          await page.getByRole('form', { name: 'Order Report' }).count(),
          1,
          'the form title label reads "Order Report"',
        );
      },
    ),

    desiredCase(
      'entry.defaults-and-seven-buttons',
      'T01',
      'read-only',
      'RP_ALL.cs:7177 {{mFromDt.Text = "01/01/2010";}}; RP_ALL.cs:7203 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}; RP_ALL.cs:7204 {{CurActCtrl = (Control)(object)mFromDt;}}; RP_ALL.cs:5619 {{mFromDt.Mask = "00/00/0000";}}; RP_ALL.cs:5360 {{btnOrdRpt.Text = "&Order Report";}}',
      {
        from: '01/01/2010',
        to: 'system date',
        focus: 'From',
        lc: '01',
        disabled: ['lc Code', 'Pr Code', 'Gr Code', 'Item Type'],
        hidden: ['Employ', 'Select Book'],
        maxLengths: { 'Party Code': 8, 'Cust Name': 50 },
        buttonsInTabOrder: Object.values(BUTTONS),
      },
      async ({ page }) => {
        assert.equal(await field(page, 'From').inputValue(), '01/01/2010');
        const today = await page.evaluate(() => {
          const d = new Date();
          return `${String(d.getDate()).padStart(2, '0')}/${String(d.getMonth() + 1).padStart(2, '0')}/${d.getFullYear()}`;
        });
        assert.equal(await field(page, 'To').inputValue(), today);
        assert.equal(await field(page, 'lc Code').inputValue(), '01');
        assert.equal(await field(page, 'lc Code').isDisabled(), true);
        for (const caption of ['Book', 'Pr Code', 'Gr Code', 'Party Code', 'Cust Name'])
          assert.equal(await field(page, caption).inputValue(), '', `${caption} starts empty`);
        for (const caption of ['Pr Code', 'Gr Code', 'Item Type'])
          assert.equal(await field(page, caption).isDisabled(), true, `${caption} is inert (D8)`);
        for (const caption of ['Employ', 'Select Book'])
          assert.equal(await field(page, caption).count(), 0, `${caption} is hidden`);
        assert.equal(
          await field(page, 'Party Code').getAttribute('maxlength'),
          '8',
          'RP_ALL.cs:4813 {{((TextBoxBase)tAcCode).MaxLength = 8;}}',
        );
        assert.equal(
          await field(page, 'Cust Name').getAttribute('maxlength'),
          '50',
          'RP_ALL.cs:5792 {{((TextBoxBase)tCustName).MaxLength = 50;}}',
        );
        const captions = await page.locator('[data-panel="order"] button').allTextContents();
        assert.deepEqual(
          captions.map((caption) => caption.trimEnd()),
          Object.values(BUTTONS).map((caption) => caption.trimEnd()),
        );
      },
    ),

    desiredCase(
      'entry.location-lock',
      'T01',
      'read-only',
      `RP_ALL.cs:6660 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}}; RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}; RP_ALL.cs:8383 {{CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";}}`,
      {
        at01: { value: '01', editable: false },
        at00: { value: '00', editable: true, clearingListsAllLocations: true },
        sentinelOnlyInAllLocations: 'O6',
      },
      async ({ ctx, page }) => {
        assert.equal(await field(page, 'lc Code').inputValue(), '01');
        assert.equal(await field(page, 'lc Code').isDisabled(), true);
        await withFixture(ctx, async () => {
          const user = 'e2eorderloc00';
          await ensureUser(ctx, { user, subMenu: 'Order Report', lcCode: '00' });
          const page00 = await openReport(ctx, as(user));
          assert.equal(await field(page00, 'lc Code').inputValue(), '00');
          assert.equal(await field(page00, 'lc Code').isDisabled(), false);
          await field(page00, 'lc Code').fill('');
          await runMode(page00, 'report', { from: WIDE_FROM });
          assertCodes(await readGrid(page00), ['O6'], []);
        });
      },
    ),

    desiredCase(
      'filters.one-at-a-time',
      'T02',
      'read-only',
      `RP_ALL.cs:8387 {{CurFormula = CurFormula + " And {SL_ORD_DATA.CO_BOOK} = '" + tBookCode.Text + "'";}}; RP_ALL.cs:8391 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_CODE} = '" + tAcCode.Text + "'";}}; RP_ALL.cs:8395 {{CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";}}; RP_ALL.cs:8403 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";}}`,
      {
        book: ['O1', 'O3', 'O4', 'O8'],
        party: ['O1', 'O3'],
        city: ['O1', 'O3'],
        area: ['O1', 'O3'],
        custName: ['O1', 'O3'],
        inert: ['Pr Code', 'Gr Code', 'Item Type'],
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const all = ['O1', 'O2', 'O3', 'O4', 'O8'];
          const runs = [
            ['Book', 'B1', ['O1', 'O3', 'O4', 'O8'], []],
            ['Party Code', 'P1', ['O1', 'O3'], ['O2', 'O4', 'O8']],
            ['City', 'SURAT', ['O1', 'O3'], ['O2', 'O4', 'O8']],
            ['Area', 'ADAJAN', ['O1', 'O3'], ['O2', 'O4', 'O8']],
            ['Cust Name', 'ALPHA JEWELS', ['O1', 'O3'], ['O2', 'O4', 'O8']],
          ];
          for (const [caption, value, present, absent] of runs) {
            await runMode(page, 'report', { [caption]: value });
            assertCodes(await readGrid(page), present, absent);
          }
          for (const [caption, key] of [
            ['Pr Code', 'prCode'],
            ['Gr Code', 'grCode'],
            ['Item Type', 'itemType'],
          ]) {
            assert.equal(await field(page, caption).isDisabled(), true, `${caption} is inert (D8)`);
            const run = await runMode(page, 'report');
            assert.equal(run.query.has(key), false, `${caption} reaches no filter query`);
            assertCodes(await readGrid(page), all, []);
          }
        });
      },
    ),

    desiredCase(
      'filters.date-range-no-year',
      'T02',
      'read-only',
      `RP_ALL.cs:8380 {{CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {}}; contrast RP_ALL.cs:11748 {{CurFormula = "{SL_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DETL.CO_YEAR} = '"}}`,
      {
        inclusiveFromTo: ['O1', 'O8'],
        excluded: ['O5'],
        priorYearInWideRange: 'O5',
        noYearClause: true,
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const base = await runMode(page, 'report');
          assert.equal(base.query.has('coYear'), false, 'buttons 1–5 append no CO_YEAR clause');
          assertCodes(await readGrid(page), ['O1', 'O2', 'O3', 'O4', 'O8'], ['O5', 'O6']);
          for (const [vch, date] of [
            ['O1', '2025-12-31'],
            ['O8', '2026-02-01'],
          ]) {
            await ctx.rows(
              `UPDATE "SL_ORD_DATA" SET "VCH_DATE"=$3::date WHERE tenant_id=$1 AND "VCH_NO"=$2`,
              vch,
              date,
            );
            await runMode(page, 'report');
            assertCodes(await readGrid(page), [], [vch]);
            await ctx.rows(
              `UPDATE "SL_ORD_DATA" SET "VCH_DATE"=$3::date WHERE tenant_id=$1 AND "VCH_NO"=$2`,
              vch,
              ORDERS[vch].date,
            );
          }
          const wide = await runMode(page, 'report', { from: WIDE_FROM });
          assertCodes(await readGrid(page), ['O5'], []);
          assert.equal(wide.query.has('coYear'), false);
        });
      },
    ),

    desiredCase(
      'filters.combined-city-area-walkin',
      'T02',
      'read-only',
      `RP_ALL.cs:8383 {{CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";}}; RP_ALL.cs:8395 {{CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";}}; RP_ALL.cs:8403 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";}}`,
      {
        bookPartyCity: ['O1', 'O3'],
        walkInWithoutCity: 'O4',
        cityOnlyDropsWalkIn: true,
        cityAndArea: [],
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          await runMode(page, 'report', { Book: 'B1', 'Party Code': 'P1', City: 'SURAT' });
          assertCodes(await readGrid(page), ['O1', 'O3'], ['O4', 'O2', 'O8']);
          await runMode(page, 'report');
          assertCodes(await readGrid(page), ['O4'], []);
          await runMode(page, 'report', { City: 'SURAT' });
          assertCodes(await readGrid(page), ['O1', 'O3'], ['O4']);
          await runMode(page, 'report', { City: 'SURAT', Area: 'ALKAPURI' });
          assertCodes(await readGrid(page), [], ['O1', 'O3', 'O4']);
        });
      },
    ),

    desiredCase(
      'formula.order-adjust-signs',
      'T03',
      'read-only',
      `RP_ALL.cs:8550 {{DC_Main.RptName = "OrdAdvAdj";}}; RP_ALL.cs:10927 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  = 0}}`,
      {
        O1: { rows: ['+ 5000', '- 1500', '- 500'], ...EXPECT.adjust.O1 },
        O3: { rows: ['+ 3000', '- 1500', '- 1500'], ...EXPECT.adjust.O3 },
        grand: { ord: 8000, adj: 5000, bal: 3000 },
        noDetailFor: ['O2', 'O4', 'O8'],
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const mode = await runMode(page, 'adjust');
          const grid = await readGrid(page);
          assertCodes(grid, ['O1', 'O3'], ['O2', 'O4', 'O8']);
          const text = grid.rows.map((row) => row.join(' ')).join('\n');
          for (const row of ['+ 5000', '- 1500', '- 500', '+ 3000'])
            assert(text.includes(row), `signed amount ${row} is printed: ${text.slice(0, 400)}`);
          assert.equal(mode.body.title, TITLES.adjust);
        });
      },
    ),

    desiredCase(
      'formula.pcs-nwt-totals',
      'T03',
      'read-only',
      'RP_ALL.cs:8418 {{DC_Main.RptName = "OrdDetlRpt";}}; RP_ALL.cs:10978 {{DC_Main.RptName = "OrdDetlPanding";}}',
      {
        lines: EXPECT.reportKeys,
        grand: { pcs: EXPECT.reportPcs, nwt: EXPECT.reportNwt },
        pending: EXPECT.pendingKeys,
        pendingGrand: { pcs: EXPECT.pendingPcs, nwt: EXPECT.pendingNwt },
        noStatusFilter: true,
      },
      async ({ ctx, page }) => {
        assert.deepEqual(EXPECT.reportPcs, 9);
        assert.deepEqual(EXPECT.reportNwt, 31.875);
        assert.deepEqual(EXPECT.pendingPcs, 7);
        assert.deepEqual(EXPECT.pendingNwt, 24.875);
        await withFixture(ctx, async () => {
          await runMode(page, 'report');
          const all = await readGrid(page);
          assertCodes(all, ['O1', 'O2', 'O3', 'O4', 'O8'], ['O5', 'O6']);
          for (const total of ['9', '31.875'])
            assert(
              all.footer.some((cell) => cell.includes(total)),
              `grand total ${total}`,
            );
          await runMode(page, 'pending');
          const pending = await readGrid(page);
          assertCodes(pending, ['O1', 'O2', 'O4'], ['O3', 'O5', 'O8']);
          for (const total of ['7', '24.875'])
            assert(
              pending.footer.some((cell) => cell.includes(total)),
              `pending total ${total}`,
            );
        });
      },
    ),

    desiredCase(
      'formula.order-advance-tender',
      'T03',
      'read-only',
      'RP_ALL.cs:8484 {{DC_Main.RptName = "OrdAdvRpt";}}; the template has no SummaryFieldDefinition, so there is no grand-total band',
      {
        ALPHA_JEWELS: [
          { order: 'O1', total: 20000, cash: 5000, advance: 5000 },
          { order: 'O3', total: 9000, advance: 3000 },
        ],
        BETA_TRADERS: [{ order: 'O2', total: 9000, advance: 0 }, { order: 'O8' }],
        WALK_IN_CUSTOMER: [{ order: 'O4' }],
        grandBand: false,
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const mode = await runMode(page, 'advance');
          const grid = await readGrid(page);
          assertCodes(grid, ['O1', 'O2', 'O3', 'O4', 'O8'], ['O5', 'O6']);
          assert.equal(grid.footer.length, 0, 'no grand-total band');
          assert.equal(mode.body.title, TITLES.advance);
        });
      },
    ),

    desiredCase(
      'formula.order-wise-bill-total',
      'T03',
      'read-only',
      'RP_ALL.cs:9776 {{DC_Main.RptName = "OrdAdjBillWise";}}; Sum ({@AdjAmt}, {SL_ORD_DATA.VCH_NO}) with @AdjAmt = - rows only',
      {
        O1: { advanceRow: 5000, bill: 'S1', billTotal: 12000, total: EXPECT.withBill.O1 },
        O3: { advanceRow: 3000, bill: 'S2', billTotal: 9000, total: EXPECT.withBill.O3 },
        O2_O4_O8: { total: 0 },
        grandBand: false,
      },
      async ({ ctx, page }) => {
        assert.deepEqual([EXPECT.withBill.O1, EXPECT.withBill.O3], [2000, 3000]);
        await withFixture(ctx, async () => {
          const mode = await runMode(page, 'with-bill');
          const grid = await readGrid(page);
          assertCodes(grid, ['O1', 'O2', 'O3', 'O4', 'O8', 'S1', 'S2'], []);
          assert.equal(mode.body.title, TITLES['with-bill']);
          const text = grid.rows.map((row) => row.join(' ')).join('\n');
          for (const amount of ['5000', '1500', '500', '3000']) assert(text.includes(amount));
        });
      },
    ),

    notApplicable(
      'formula.pending-set',
      'T03',
      `RP_ALL.cs:10940 {{AND {SL_ORD_DETL.DESIGN_ISU} = 'N'}}; RP_ALL.cs:10927 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  = 0}}`,
      `${DB_LAYER} It freezes the derived pending set ['O1:1', 'O1:2', 'O2:1', 'O4:1'], the unscoped O5 exclusion and the zero-write footprint (D2).`,
    ),

    desiredCase(
      'formula.bill-wise-adjust',
      'T03',
      'read-only',
      `RP_ALL.cs:12646 {{DC_Main.RptName = "BillWiseOrderAdjust";}}; RP_ALL.cs:12608 {{CurFormula = "{SL_DATA.CO_CODE} = '}}; RP_ALL.cs:12631 {{CurFormula = CurFormula + " And {SL_DATA.AC_NAME} = '" + tCustName.Text + "'";}}`,
      {
        base: 'sale bill (SL_DATA)',
        rows: [
          { bill: 'S1', amounts: [1500, 500] },
          { bill: 'S2', amounts: [1500, 1500] },
        ],
        custNameFiltersBill: true,
        grandBand: false,
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const mode = await runMode(page, 'bill-wise');
          const grid = await readGrid(page);
          assertCodes(grid, ['S1', 'S2', 'O1', 'O3'], ['O2', 'O4', 'O8']);
          assert.equal(grid.footer.length, 0, 'no total band (D13)');
          assert.equal(mode.body.title, TITLES['bill-wise']);
          await runMode(page, 'bill-wise', { 'Cust Name': 'ALPHA JEWELS' });
          assertCodes(await readGrid(page), ['S1', 'S2'], []);
        });
      },
    ),

    desiredCase(
      'lookup.book-party-location',
      'T04',
      'read-only',
      'RP_ALL.cs:7328 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7322 {{tBookName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BOOK_NAME"], (object)""));}}; RP_ALL.cs:7303 {{SELECT A.BOOK_NAME As BookNameL,A.CO_BOOK As BookL FROM BOOK_DATA AS A}}; RP_ALL.cs:7416 {{((Control)tAcCode).Focus();}}',
      {
        empty: 'tabs on',
        known: 'fills code and name and tabs',
        unknown: 'opens scoped help; picking fills both and focus returns; cancel keeps typed text',
        location: 'only editable at 00; empty tabs on; unknown opens LOCT_MAST help',
        staleResponse: 'never overwrites a newer selection',
      },
      async ({ ctx, page }) => {
        for (const [caption, code, name] of [
          ['Book', 'B1', 'Order Book 1'],
          ['Party Code', 'P1', 'ALPHA JEWELS'],
        ]) {
          const input = await field(page, caption);
          await input.fill(code);
          await input.press('Enter');
          await page.getByText(name, { exact: true }).first().waitFor();
          await input.fill('ZZ');
          await input.press('Enter');
          await page.getByRole('dialog').waitFor();
          await page.keyboard.press('Escape');
          assert.equal(await input.inputValue(), 'ZZ', 'cancel keeps the typed text');
        }
        await withFixture(ctx, async () => {
          const user = 'e2eorderloc00b';
          await ensureUser(ctx, { user, subMenu: 'Order Report', lcCode: '00' });
          const page00 = await openReport(ctx, as(user));
          const lc = await field(page00, 'lc Code');
          assert.equal(await lc.isDisabled(), false);
          await lc.fill('00');
          await lc.press('Enter');
          await lc.fill('');
          await lc.press('Enter');
          await lc.fill('XX');
          await lc.press('Enter');
          await page00.getByRole('dialog').waitFor();
        });
      },
    ),

    desiredCase(
      'lookup.cust-name',
      'T04',
      'read-only',
      'RP_ALL.cs:9687 {{if (Operators.CompareString(CurRpt, "Order Report", false) == 0)}}; RP_ALL.cs:9689 {{SELECT A.AC_NAME FROM SL_ORD_DATA AS A  WHERE A.CO_CODE}}; RP_ALL.cs:9693 {{SELECT A.AC_NAME As CustomerNameL,A.AC_CODE AS AcCodel FROM SL_ORD_DATA AS A WHERE A.CO_CODE}}; RP_ALL.cs:9712 {{((Control)cboCity).Focus();}}',
      {
        found: { value: 'ALPHA JEWELS', focus: 'City' },
        unknown: { helpFrom: 'SL_ORD_DATA', cancelKeepsText: true },
        empty: { focus: 'City' },
        mode7: 'same SL_ORD_DATA help (D9), though the filter uses SL_DATA.AC_NAME',
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const input = await field(page, 'Cust Name');
          await input.fill('ALPHA JEWELS');
          await input.press('Enter');
          assert.equal(await input.inputValue(), 'ALPHA JEWELS', 'copied back exactly as stored');
          await input.fill('NO SUCH NAME');
          await input.press('Enter');
          await page.getByRole('dialog').waitFor();
          await page.keyboard.press('Escape');
          assert.equal(await input.inputValue(), 'NO SUCH NAME');
          await input.fill('');
          await input.press('Enter');
          await runMode(page, 'bill-wise', { 'Cust Name': 'ALPHA JEWELS' });
          assertCodes(await readGrid(page), ['S1', 'S2'], []);
        });
      },
    ),

    desiredCase(
      'grouping.template-groups',
      'T05',
      'read-only',
      'RP_ALL.cs:8418 {{DC_Main.RptName = "OrdDetlRpt";}}; template group/sort definitions in extraction_output/rpt_xml/OrdDetlRpt.xml:288-291, OrdAdvRpt.xml:246-249, OrdAdvAdj.xml:233-238, OrdAdjBillWise.xml:384-388, OrdDetlPanding.xml:375-378, OrdDesignSumm.xml:375-378, BillWiseOrderAdjust.xml:365-366',
      {
        report: { group: 'VCH_NO', sort: ['AC_CODE'] },
        advance: { group: 'AC_NAME', sort: ['AC_CODE'] },
        adjust: { group: '@OrdGroup', sort: ['CO_YEAR', 'VCH_DATE', 'VCH_NO'] },
        'with-bill': { group: ['AC_NAME', 'VCH_NO'], sort: ['AC_CODE'] },
        pending: { group: '@VchGroup = CO_YEAR&CO_BOOK&VCH_NO', sort: ['AC_CODE'] },
        summary: {
          group: '@VchGroup = TAG_NO&DESIGN_NO',
          sort: ['AC_CODE'],
          designFallback: "DESIGN_NO='' then TAG_NO",
        },
        'bill-wise': { group: ['SL_DATA.AC_CODE', '@VchGroup'], sort: [] },
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          await ctx.rows(
            `UPDATE "SL_ORD_DETL" SET "DESIGN_ISU"='N' WHERE tenant_id=$1 AND "VCH_NO"='O1' AND "SR_NO"=2`,
          );
          for (const mode of Object.keys(BUTTONS)) {
            await runMode(page, mode);
            const grid = await readGrid(page);
            assert(grid.rows.length > 0, `mode ${mode} prints rows`);
            const text = grid.rows.map((row) => row.join(' ')).join('\n');
            assert.equal(
              text.includes('O2'),
              mode === 'bill-wise' ? false : true,
              `O2 rows under mode ${mode}`,
            );
          }
        });
      },
    ),

    desiredCase(
      'invalid.dates',
      'T06',
      'refusal',
      `DC_Main.cs:1561 {{public static void SetDate(ref MaskedTextBox MsDate)}}; RP_ALL.cs:8380 {{CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {}}; no handler compares From with To`,
      {
        impossibleDate: { value: '31/02/2026', refused: true, run: false },
        incompleteMask: { refused: true, run: false },
        fromAfterTo: { printsEmpty: true, totals: 0, error: false },
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const from = await field(page, 'From');
          await from.fill('31/02/2026');
          await from.press('Enter');
          await page.getByRole('alert').first().waitFor();
          await from.fill('');
          await panelButton(page, BUTTONS.report).click();
          await page.getByRole('alert').first().waitFor();
          await runMode(page, 'report', { from: '2026-02-01', to: '2026-01-01' });
          const grid = await readGrid(page);
          assert.equal(grid.rows.length, 0, 'From after To is an empty report, not an error');
          assert(grid.footer.every((cell) => ['0', '0.000', ''].includes(cell.trim())));
        });
      },
    ),

    desiredCase(
      'invalid.unknown-codes-no-recheck',
      'T06',
      'refusal',
      `RP_ALL.cs:8391 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_CODE} = '" + tAcCode.Text + "'";}}; RP_ALL.cs:7251 {{if (num == 0 || num == 39)}}`,
      {
        party: 'ZZ99',
        book: 'ZZ',
        result: 'empty report with no message',
        writes: 0,
        quoteSwallowed: true,
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          for (const [caption, value] of [
            ['Party Code', 'ZZ99'],
            ['Book', 'ZZ'],
          ]) {
            const input = await field(page, caption);
            await input.fill(value);
            const received = page.waitForResponse(
              (r) => new URL(r.url()).pathname === API_PATH && r.request().method() === 'GET',
            );
            await panelButton(page, BUTTONS.report).click();
            const response = await received;
            assert.equal(response.status(), 200);
            assert.equal((await readGrid(page)).rows.length, 0);
          }
          const party = await field(page, 'Party Code');
          await party.fill("O'NEIL");
          assert.equal(
            await party.inputValue(),
            'ONEIL',
            'the quote is swallowed as on the desktop',
          );
        });
      },
    ),

    desiredCase(
      'lifecycle.source-order-appears',
      'T07',
      'mutation',
      'TR_SALE_ORD.cs:9503 {{dataRow7["ORD_SIGN"] = "+";}}; TR_SALE_ORD.cs:9504 {{dataRow7["ORD_AMT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Conversion.Val(MSG2_TOTAL[9, 1]) == 0.0}}',
      {
        created: { pcs: 1, nwt: 10.5, secondNwt: 5.25, cash: 5000, total: 20000 },
        editedNwt: 6,
        nwtDelta: 0.75,
        afterDelete: 'no rows in any mode',
        advanceAdjustment: '+ 5000',
      },
      async ({ ctx, page }) => {
        await page.goto('/txn/sales-order');
        await page.getByRole('heading', { name: 'Sales Order', exact: true }).waitFor();
        await page.getByLabel('Customer account', { exact: true }).fill('E2ELOC');
        await page.getByLabel('Customer account', { exact: true }).press('Enter');
        await page.getByLabel('Item code 1', { exact: true }).fill('GLD22');
        await page.getByLabel('Net weight item 1', { exact: true }).fill('10.5');
        await page.getByRole('button', { name: '+ Add line', exact: true }).click();
        await page.getByLabel('Item code 2', { exact: true }).fill('GLD22');
        await page.getByLabel('Net weight item 2', { exact: true }).fill('5.25');
        await page.getByLabel('Advance ₹', { exact: true }).fill('5000');
        const saved = await page.waitForResponse(
          (r) =>
            /^\/api\/sales-orders(\/\d+)?$/.test(new URL(r.url()).pathname) &&
            r.request().method() === 'POST',
        );
        await page.getByRole('button', { name: 'Save Sales Order', exact: true }).click();
        assert.equal((await saved).status(), 201);
        const page2 = await openReport(ctx);
        await runMode(page2, 'report');
        assertCodes(await readGrid(page2), ['10.500', '5.250'], []);
        await runMode(page2, 'advance');
        assertCodes(await readGrid(page2), ['5000', '20000'], []);
        await runMode(page2, 'adjust');
        assertCodes(await readGrid(page2), ['+ 5000'], []);
        await runMode(page2, 'pending');
        assertCodes(await readGrid(page2), ['10.500', '5.250'], []);
      },
    ),

    notApplicable(
      'lifecycle.writes-nothing',
      'T07',
      `RP_ALL.cs:10933 {{UPDATE SL_ORD_DETL SET DESIGN_ISU = 'Y' WHERE CO_CODE = '}}; RP_ALL.cs:10934 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}`,
      `${DB_LAYER} It snapshots SL_ORD_DETL.DESIGN_ISU and the four table counts before and after all seven modes run twice (D2, study weakness 2).`,
    ),

    notApplicable(
      'scope.sentinels',
      'T11',
      `RP_ALL.cs:8380 {{CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {}}; RP_ALL.cs:12608 {{CurFormula = "{SL_DATA.CO_CODE} = '}}`,
      `${DB_LAYER} It seeds O6 (location 00), O7 (company C2) and a same-numbered order in a second tenant and checks every mode, total and export (gaps 1 and 10).`,
    ),

    desiredCase(
      'rights.caption-and-print',
      'T11',
      'refusal',
      `MDI_FORM.cs:7034 {{DC_Main.MsUserRightForm = MsSideBtn;}}; RP_ALL.cs:6656 {{Select * From USER_SET WHERE LC_CODE = '}}; RP_ALL.cs:6777 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}`,
      {
        salesOrderRightOnly: { menu: 'hidden', api: 403 },
        orderRightNoPrint: { lists: true, export: 403 },
        orderRightWithPrint: { export: 200 },
      },
      async ({ ctx, page }) => {
        await ensureUser(ctx, { user: 'e2eordersalesonly', subMenu: 'Sales Order', print: 'N' });
        await ensureUser(ctx, { user: 'e2eorderprintno', subMenu: 'Order Report', print: 'N' });
        const { page: salesPage } = await ctx.session(as('e2eordersalesonly'));
        await salesPage.goto('/dashboard');
        assert.equal(
          await salesPage.getByRole('link', { name: 'Order Report', exact: true }).count(),
          0,
          'a Sales Order right grants no Order Report menu entry (D6)',
        );
        const denied = await salesPage.request.get(
          `${API_PATH}?fromDate=${FROM}&toDate=${TO}&mode=report`,
        );
        assert.equal(denied.status(), 403);
        const { page: noPrint } = await ctx.session(as('e2eorderprintno'));
        await noPrint.goto('/reports/order-report');
        await noPrint.getByRole('heading', { name: 'Order Report', exact: true }).waitFor();
        await runMode(noPrint, 'report');
        const csv = await noPrint.request.get(
          `${API_PATH}/export.csv?fromDate=${FROM}&toDate=${TO}&mode=report`,
        );
        assert.equal(csv.status(), 403, 'FRM_PRINT is enforced on export (D7)');
        const xlsx = await noPrint.request.get(
          `${API_PATH}/export.xlsx?fromDate=${FROM}&toDate=${TO}&mode=report`,
        );
        assert.equal(xlsx.status(), 403);
      },
    ),

    desiredCase(
      'history.snapshot-and-live',
      'T15',
      'read-only',
      `RP_ALL.cs:8403 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";}}; RP_ALL.cs:8395 {{CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";}}`,
      {
        modes1to6Name: 'ALPHA JEWELS (stored on the order)',
        mode7OrderParty: 'ALPHA RENAMED (live AC_MAST)',
        custNameStored: 'ALPHA JEWELS selects O1/O3; ALPHA RENAMED selects nothing',
        cityLive: 'SURAT drops O1/O3; BARODA selects them',
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          await runMode(page, 'report');
          assertCodes(await readGrid(page), ['ALPHA JEWELS'], []);
          await runMode(page, 'bill-wise');
          assertCodes(await readGrid(page), ['ALPHA JEWELS'], []);
          await ctx.rows(
            `UPDATE "AC_MAST" SET "AC_NAME"='ALPHA RENAMED',"AC_CITY"='BARODA'
              WHERE tenant_id=$1 AND "AC_CODE"='P1'`,
          );
          await runMode(page, 'report');
          assertCodes(await readGrid(page), ['ALPHA JEWELS'], ['ALPHA RENAMED']);
          await runMode(page, 'bill-wise');
          assertCodes(await readGrid(page), ['ALPHA RENAMED'], []);
          await runMode(page, 'report', { 'Cust Name': 'ALPHA JEWELS' });
          assertCodes(await readGrid(page), ['O1', 'O3'], []);
          await runMode(page, 'report', { 'Cust Name': 'ALPHA RENAMED' });
          assertCodes(await readGrid(page), [], ['O1', 'O3']);
          await runMode(page, 'report', { City: 'SURAT' });
          assertCodes(await readGrid(page), [], ['O1', 'O3']);
          await runMode(page, 'report', { City: 'BARODA' });
          assertCodes(await readGrid(page), ['O1', 'O3'], []);
        });
      },
    ),

    desiredCase(
      'filters.data-type-omitted',
      'T15',
      'read-only',
      'RP_ALL.cs:8405 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}}; RP_ALL.cs:8409 {{else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)}}; D4 follows the Sales adapter, which omits the clause',
      {
        books: { B1: 'DATA_TYPE A', B2: 'DATA_TYPE B' },
        listed: ['O1', 'O2'],
        requestHasDataType: false,
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const run = await runMode(page, 'report');
          assert.equal(run.query.has('dataType'), false, 'no session data type is ported (D4)');
          assertCodes(await readGrid(page), ['O1', 'O2'], []);
        });
      },
    ),

    desiredCase(
      'output.titles',
      'T16',
      'output',
      `RP_ALL.cs:8416 {{DC_Main.MsRptTitelStr = "'Order Report From "}}; RP_ALL.cs:8482 {{DC_Main.MsRptTitelStr = "'Order Advance Report From "}}; RP_ALL.cs:10976 {{DC_Main.MsRptTitelStr = "'Order Design Issue Panding Report From " + S}}`,
      TITLES,
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          for (const [mode, title] of Object.entries(TITLES)) {
            const run = await runMode(page, mode);
            assert.equal(run.body.title, title, `title of mode ${mode}`);
            await page.getByText(title, { exact: false }).first().waitFor();
          }
        });
      },
    ),

    desiredCase(
      'output.grid-export-print-match',
      'T16',
      'output',
      'Module_Save.cs:110 {{val.RecordSelectionFormula = DC_Main.RptFormula;}}; RP_ALL.cs:8413 {{if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)}}; RP_ALL.cs:8417 {{DC_Main.MsWappPrintType = "All";}}',
      {
        surfaces: ['grid', 'CSV', 'XLSX', 'print preview'],
        pageOverflowRows: 30,
        totals: {
          report: { pcs: EXPECT.reportPcs, nwt: EXPECT.reportNwt },
          advance: 'none',
          adjust: 'group and grand',
          withBill: 'per order only',
          pending: EXPECT.pendingNwt,
          summary: EXPECT.pendingNwt,
          billWise: 'none (D13)',
        },
        selectionAppliedOnce: true,
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          for (let i = 0; i < 30; i++) {
            const vch = `OP${String(i).padStart(3, '0')}`;
            await ctx.rows(
              `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME","TOT_AMT","ADV_AMT","CASH_AMT")
               VALUES($1,'01','01',$2,'B1',$3,$4::date,'P1','ALPHA JEWELS',0,0,0)`,
              YEAR,
              vch,
              '2026-01-06',
            );
            await ctx.rows(
              `INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","IT_CODE","ITM_PCS","ITM_NWT","DESIGN_ISU")
               VALUES($1,'01','01',$2,'B1',$3,1,$4::date,'I1',1,10.5,'N')`,
              YEAR,
              vch,
              '2026-01-06',
            );
          }
          for (const mode of Object.keys(BUTTONS)) {
            const run = await runMode(page, mode);
            const grid = await readGrid(page);
            assert(grid.rows.length > 30, `mode ${mode} overflows one printed page`);
            const csv = await page.request.get(
              `${API_PATH}/export.csv?${new URL(run.response.url()).searchParams.toString()}`,
            );
            assert.equal(csv.status(), 200, `CSV of mode ${mode}`);
            const xlsx = await page.request.get(
              `${API_PATH}/export.xlsx?${new URL(run.response.url()).searchParams.toString()}`,
            );
            assert.equal(xlsx.status(), 200, `XLSX of mode ${mode}`);
            assert.equal(csv.headers()['content-type']?.includes('text/csv'), true);
            const csvLines = (await csv.text()).split('\r\n').filter((line) => line.length > 0);
            assert.equal(
              csvLines.length,
              grid.rows.length + 1,
              `mode ${mode}: CSV has one header plus every grid row`,
            );
            for (const caption of grid.headers)
              assert(csvLines[0].includes(caption), `CSV column "${caption}" matches the grid`);
          }
        });
      },
    ),

    desiredCase(
      'output.making-summ-prompt',
      'T16',
      'output',
      `RP_ALL.cs:11889 {{Only Design Summery Report..}}; DC_Main.cs:851 {{public static string MsgTitle = "DataCareNext";}}; RP_ALL.cs:11892 {{DC_Main.MsCrForStr1 = "'Y'";}}; RP_ALL.cs:11897 {{DC_Main.MsCrForStr1 = "'N'";}}`,
      {
        prompt: 'Only Design Summery Report..',
        title: 'DataCareNext',
        yes: { onlySumm: 'Y', detailSuppressed: true },
        no: { onlySumm: 'N', detailSuppressed: false },
        totalsIdentical: true,
        focusUnchanged: true,
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const prompt = () => page.getByRole('dialog');
          const answer = async (button) => {
            const dialog = prompt();
            await dialog.getByText('Only Design Summery Report..', { exact: true }).waitFor();
            await dialog.getByRole('button', { name: button, exact: true }).click();
            await page.waitForResponse(
              (r) => new URL(r.url()).pathname === API_PATH && r.request().method() === 'GET',
            );
          };
          await panelButton(page, BUTTONS.summary).click();
          await answer('Yes');
          const yes = await readGrid(page);
          await panelButton(page, BUTTONS.summary).click();
          await answer('No');
          const no = await readGrid(page);
          assert.deepEqual(yes.footer, no.footer, 'suppression never changes a total');
          assert(yes.rows.length <= no.rows.length, 'Yes suppresses the detail band');
        });
      },
    ),

    desiredCase(
      'keyboard.selector-run-flow',
      'T17',
      'read-only',
      'RP_ALL.cs:7261 {{if ((int)e.KeyCode == 27)}}; RP_ALL.cs:7263 {{((Form)this).Close();}}; RP_ALL.cs:7517 {{DC_Main.SetDate(ref MsDate);}}; RP_ALL.cs:5622 {{((Control)mFromDt).TabIndex = 0;}}; RP_ALL.cs:7251 {{if (num == 0 || num == 39)}}',
      {
        tabOrder: SELECTORS,
        uppercaseAndQuoteSwallowed: true,
        esc: 'closes from anywhere',
        cancel: 'clears text boxes, keeps combos, keeps no default dates',
        print: 'does nothing',
        exit: 'closes',
        captions: Object.values(BUTTONS),
      },
      async ({ ctx, page }) => {
        await page.getByLabel('From', { exact: true }).focus();
        for (const caption of SELECTORS) {
          assert.equal(await field(page, caption).count(), 1, `${caption} is reachable by Tab`);
          await page.keyboard.press('Enter');
        }
        const party = await field(page, 'Party Code');
        await party.fill("ab'c");
        assert.equal(
          await party.inputValue(),
          'ABC',
          'typed text is upper-cased and the quote swallowed',
        );
        await page.keyboard.press('Escape');
        await page.waitForURL((url) => !url.pathname.startsWith('/reports/order-report'));
        const reopened = await openReport(ctx);
        const city = await field(reopened, 'City');
        await city.selectOption({ label: 'SURAT' });
        await reopened.getByRole('button', { name: 'Cancel', exact: true }).click();
        assert.equal(await field(reopened, 'From').inputValue(), '', 'Cancel clears the dates');
        assert.equal(await city.inputValue(), 'SURAT', 'Cancel keeps the combo selection');
        await reopened.getByRole('button', { name: 'Print', exact: true }).click();
        assert.equal(
          new URL(reopened.url()).pathname,
          '/reports/order-report',
          'Print does nothing',
        );
        await reopened.getByRole('button', { name: 'Exit', exact: true }).click();
        await reopened.waitForURL((url) => !url.pathname.startsWith('/reports/order-report'));
      },
    ),

    desiredCase(
      'journey.order-adjust-reconcile',
      'T18',
      'mutation',
      `TR_SALE_ORD.cs:9503 {{dataRow7["ORD_SIGN"] = "+";}}; RP_ALL.cs:10927 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  = 0}}; RP_ALL.cs:10933 {{UPDATE SL_ORD_DETL SET DESIGN_ISU = 'Y' WHERE CO_CODE = '}} (never written by the web)`,
      {
        created: { total: 12000, advance: 5000, pcs: 2, nwt: 15 },
        afterFirstAdjustment: { net: 2000, mode4Total: 3000, mode7Amount: 3000 },
        afterSecondAdjustment: { net: 0, pending: false, stillInModes1And2: true },
        flag: 'DESIGN_ISU remains N (D2)',
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          await page.goto('/txn/sales-order');
          await page.getByLabel('Customer account', { exact: true }).fill('P1');
          await page.getByLabel('Customer account', { exact: true }).press('Enter');
          await page.getByLabel('Item code 1', { exact: true }).fill('I1');
          await page.getByLabel('Pieces item 1', { exact: true }).fill('2');
          await page.getByLabel('Net weight item 1', { exact: true }).fill('15');
          await page.getByLabel('Advance ₹', { exact: true }).fill('5000');
          const created = page.waitForResponse(
            (r) =>
              /^\/api\/sales-orders(\/\d+)?$/.test(new URL(r.url()).pathname) &&
              r.request().method() === 'POST',
          );
          await page.getByRole('button', { name: 'Save Sales Order', exact: true }).click();
          assert.equal((await created).status(), 201);
          const report = await openReport(ctx);
          for (const mode of ['report', 'advance', 'adjust', 'pending'])
            await runMode(report, mode);
          assertCodes(await readGrid(report), ['15.000'], []);
          for (const [amount, net] of [
            [3000, 2000],
            [2000, 0],
          ]) {
            await ctx.rows(
              `INSERT INTO "SL_ORD_ADJ"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","ORD_SIGN","ORD_AMT","ORD_LC","ORD_YRCD","ORD_DBCD","ORD_NO")
               VALUES($1,'01','01',$2,'SB','S3',1,$3::date,'-',$4,'01',$2,'SB','S3')`,
              YEAR,
              '2026-01-24',
              amount,
            );
            await runMode(report, 'adjust');
            await runMode(report, 'pending');
            const flags = await ctx.rows(
              `SELECT "DESIGN_ISU" "designIsu" FROM "SL_ORD_DETL" WHERE tenant_id=$1 AND "ITM_NWT"=15`,
            );
            assert(
              flags.every((row) => row.designIsu === 'N'),
              'the web never writes DESIGN_ISU (D2)',
            );
          }
          await runMode(report, 'report');
          assertCodes(await readGrid(report), ['15.000'], []);
          await runMode(report, 'advance');
          assertCodes(await readGrid(report), ['12000', '5000'], []);
        });
      },
    ),

    notApplicable(
      'reopen.no-op.not-applicable',
      'T08',
      'RP_ALL.cs:8366-8434 {{private void btnOrdRpt_Click(object sender, EventArgs e)}} (read-only: a run only builds a formula and opens a template)',
      'The report saves no document; closing and reopening the screen re-applies the constructor defaults proved by T01, and there are no raw values, clocks or images of its own to preserve.',
    ),
    notApplicable(
      'edit.no-own-field.not-applicable',
      'T09',
      'RP_ALL.cs:7267-7269 {{private void BtnPrint_Click(object sender, EventArgs e)}} (the form owns no editable field)',
      'The report owns no editable field; editing the source order and re-running is covered by lifecycle.source-order-appears (T07).',
    ),
    notApplicable(
      'delete.no-write.not-applicable',
      'T10',
      `RP_ALL.cs:10940 {{AND {SL_ORD_DETL.DESIGN_ISU} = 'N'}} (the web report derives the flag and never writes)`,
      'The report deletes and reverses nothing; deleting the source order is covered in T07, and the Order Cancel flow is G245, outside this study (D3).',
    ),
    notApplicable(
      'concurrency.read-only.not-applicable',
      'T12',
      'web/apps/api/test/rpAllOrder.db.test.ts (a read-only report writes no row and allocates no number)',
      'The web report is read-only (D2) — no save, delete or number allocation to race; the desktop’s unscoped concurrent write is the weakness not ported, and lifecycle.writes-nothing proves no write occurs.',
    ),
    notApplicable(
      'retry.read-is-idempotent.not-applicable',
      'T13',
      `RP_ALL.cs:8380 {{CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {}} (a run is a read)`,
      'A report run is a read; a duplicate or retried request returns the same dataset with no financial effect — asserted inside lifecycle.writes-nothing (second run identical).',
    ),
    notApplicable(
      'rollback.no-write.not-applicable',
      'T14',
      `RP_ALL.cs:10933 {{UPDATE SL_ORD_DETL SET DESIGN_ISU = 'Y' WHERE CO_CODE = '}} (the web never reproduces this write)`,
      'There is no write to roll back (D2); a failed run leaves the database untouched, which lifecycle.writes-nothing verifies.',
    ),
  ],
};
