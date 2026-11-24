import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

/**
 * Frozen browser matrix: Report → Order Report (desktop RP_ALL in its "Order Report" caption).
 *
 * The case list is orchestration/work/WP-14/cases.md (T01-T18); three cases are database-layer and are covered by
 * web/apps/api/test/rpAllOrder.db.test.ts, so they are recorded here as N/A rather than duplicated.
 * The module follows the API as reviewed in 69bd05e7: Order Report and Making Panding return voucher plus line
 * rows, Order Adjust returns group bands only (one null group for the orders without adjustments), Order Wise
 * Bill and Bill Wise Adjust carry the bill columns, and Making Panding/Summ list every stored DESIGN_ISU = N line
 * (the fully-adjusted write is HM310NEPK-only, RP_ALL.cs:10925, so D2 reads as the general behaviour).
 * The Sales Order screen writes the "+" SL_ORD_ADJ advance row (TR_SALE_ORD.cs:9503, web since #262): the
 * lifecycle and journey cases check it (expectAdvanceAdjustment) instead of seeding it.
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

/**
 * An SL_ORD_ADJ row's own keys (book, vch, sr) are the voucher that wrote it: the order for its `+` advance row,
 * the sale bill for a `-` adjustment; ORD_LC/ORD_YRCD/ORD_DBCD/ORD_NO always point at the order
 * (Ac_Tax.cs:71-73; the Crystal templates link ORD_NO/ORD_LC/ORD_YRCD/ORD_DBCD, extraction_output/rpt_xml/OrdAdvAdj.xml:13-31
 * and BillWiseOrderAdjust.xml). The first draft stored the bill rows the other way round.
 */
const adj = (book, vch, sr, date, sign, amt, ord) => ({ book, vch, sr, date, sign, amt, ord });
const ADJUSTMENTS = Object.freeze([
  adj('B1', 'O1', 1, '2026-01-05', '+', 5000, 'O1'),
  adj('SB', 'S1', 1, '2026-01-18', '-', 1500, 'O1'),
  adj('SB', 'S1', 2, '2026-01-18', '-', 500, 'O1'),
  adj('B1', 'O3', 1, '2026-01-15', '+', 3000, 'O3'),
  adj('SB', 'S2', 1, '2026-01-22', '-', 1500, 'O3'),
  adj('SB', 'S2', 2, '2026-01-22', '-', 1500, 'O3'),
  adj('B1', 'O5', 1, '2025-12-20', '+', 1000, 'O5'),
  adj('SB', 'S0', 1, '2025-12-20', '-', 1000, 'O5'),
]);

/** S3 has no adjustment row: BillWiseOrderAdjust links SL_DATA to SL_ORD_ADJ with an Equal join. */
const BILLS = Object.freeze([
  { vch: 'S1', date: '2026-01-18', party: 'P1', acName: 'ALPHA JEWELS', tot: 12000, adv: 2000 },
  { vch: 'S2', date: '2026-01-22', party: 'P1', acName: 'ALPHA JEWELS', tot: 9000, adv: 3000 },
  { vch: 'S3', date: '2026-01-25', party: 'P2', acName: 'BETA TRADERS', tot: 5000, adv: 0 },
]);

const VOUCHERS = Object.freeze([
  'O1',
  'O2',
  'O3',
  'O4',
  'O5',
  'O6',
  'O8',
  'S0',
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
const adjustmentsOf = (order) => ADJUSTMENTS.filter((a) => a.ord === order);
const netOf = (vch) =>
  adjustmentsOf(vch).reduce((total, adj) => total + (adj.sign === '+' ? adj.amt : -adj.amt), 0);

/**
 * Making Panding / Making Summ list every line whose stored DESIGN_ISU is 'N'. The desktop's fully-adjusted write
 * (RP_ALL.cs:10925, only for registration HM310NEPK) does not run on a general installation, so a fully adjusted
 * order such as O3 still lists (API review 69bd05e7, changing D2 to the general behaviour).
 */
const pendingKeys = () =>
  Object.values(ORDERS)
    .filter(inDefaultRange)
    .flatMap((o) =>
      o.lines.filter((line) => line.isu === 'N').map((line) => `${o.vch}:${line.sr}`),
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
      .flatMap((o) => o.lines.filter((line) => line.isu === 'N')),
  ),
  pendingNwt: sumNwt(
    Object.values(ORDERS)
      .filter(inDefaultRange)
      .flatMap((o) => o.lines.filter((line) => line.isu === 'N')),
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
       "ORD_SIGN","ORD_AMT","ORD_LC","ORD_YRCD","ORD_DBCD","ORD_NO","ORD_AC_CODE")
       VALUES($1,'01','01',$2,$3,$4,$5,$6::date,$7,$8,'01',$2,$9,$10,$11)`,
      YEAR,
      adj.book,
      adj.vch,
      adj.sr,
      adj.date,
      adj.sign,
      adj.amt,
      ORDERS[adj.ord].book,
      adj.ord,
      ORDERS[adj.ord].party,
    );
  for (const bill of BILLS)
    await put(
      `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME","TOT_AMT","ADV_AMT")
       VALUES($1,'01','01',$2,'SB',$3,$4::date,$5,$6,$7,$8)`,
      YEAR,
      bill.vch,
      bill.date,
      bill.party,
      bill.acName,
      bill.tot,
      bill.adv,
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

/**
 * Open Report → Order Report from the menu. A session always starts at the company's default location (01); the
 * head-office run (`lcCode: '00'`) then switches the location on the Open Company screen, as an operator does.
 */
async function openReport(ctx, credentials, { lcCode } = {}) {
  const { page } = await ctx.session(credentials);
  if (lcCode && lcCode !== '01') {
    await page.goto('/select');
    await page.getByLabel('Location', { exact: true }).selectOption(lcCode);
    await page.getByRole('button', { name: 'Open', exact: true }).click();
    await page.waitForURL('**/dashboard', { timeout: 20000 });
  } else await page.goto('/dashboard');
  const link = page.getByRole('link', { name: 'Order Report', exact: true });
  await link.waitFor({ timeout: 8000 });
  await link.click();
  await page.waitForURL('**/reports/order-report', { timeout: 8000 });
  await page.getByRole('heading', { name: 'Order Report', exact: true }).waitFor({ timeout: 8000 });
  return page;
}

/** The web label is the desktop caption without the WinForms & accelerator. */
function field(page, caption) {
  const plain = caption.replaceAll('&', '').trim();
  const byPlain = page.getByLabel(plain, { exact: true });
  return plain === caption ? byPlain : byPlain.or(page.getByLabel(caption, { exact: true }));
}

function panelButton(page, caption) {
  const plain = caption.replaceAll('&', '').trim();
  const byPlain = page.getByRole('button', { name: plain, exact: true });
  return plain === caption
    ? byPlain
    : byPlain.or(page.getByRole('button', { name: caption, exact: true }));
}

/**
 * Blank every live selector before a run. City and Area are editable combos on the desktop (RP_ALL.cs:7567
 * reads `cboCity.Text`; no DropDownStyle is set, so the WinForms default DropDown applies), so the web shows
 * an input with a list and the module types into it. Pr Code, Gr Code and Item Type are disabled (D8).
 */
async function clearSelectors(page) {
  for (const caption of ['Book', 'Pr Code', 'Gr Code', 'Party Code', 'Cust Name', 'City', 'Area']) {
    const locator = field(page, caption);
    if ((await locator.count()) && !(await locator.isDisabled())) await locator.fill('');
  }
}

/**
 * Fill the From/To boxes and the selectors, press one of the seven buttons and return the answer of the API.
 * Making Summ asks "Only Design Summery Report.." first (RP_ALL.cs:11889): `onlySummary` answers Yes, otherwise No.
 */
async function runMode(page, mode, { from = FROM, to = TO, onlySummary = false, ...filters } = {}) {
  await clearSelectors(page);
  await field(page, 'From').fill(from);
  await field(page, 'To').fill(to);
  for (const [caption, value] of Object.entries(filters)) {
    if (value === undefined || value === null || value === '') continue;
    const locator = field(page, caption);
    if ((await locator.count()) && !(await locator.isDisabled())) await locator.fill(String(value));
  }
  const received = page.waitForResponse(
    (response) =>
      new URL(response.url()).pathname === API_PATH && response.request().method() === 'GET',
    { timeout: 15000 },
  );
  await panelButton(page, BUTTONS[mode]).click();
  if (mode === 'summary')
    await page
      .getByRole('dialog', { name: 'DataCareNext' })
      .getByRole('button', { name: onlySummary ? 'Yes' : 'No', exact: true })
      .click();
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

/** Wait for the focus to land on the control with this accessible label (the lookups answer asynchronously). */
const focusIs = (page, label) =>
  page.waitForFunction(
    (wanted) => document.activeElement?.getAttribute('aria-label') === wanted,
    label,
    { timeout: 8000 },
  );

/** The printed lines whose band label starts with `label` (a group band, or a voucher row's first cell). */
const gridRow = (grid, label) => {
  const row = grid.rows.find((cells) => cells[0].startsWith(label));
  assert(row, `a printed line "${label}" in ${grid.rows.map((cells) => cells[0]).join(' | ')}`);
  return row;
};

/** The cell of a printed line under a column caption (the first match when a caption repeats). */
const cellOf = (grid, row, caption, { last = false } = {}) => {
  const index = last ? grid.headers.lastIndexOf(caption) : grid.headers.indexOf(caption);
  assert(index >= 0, `column "${caption}" in ${grid.headers.join(' | ')}`);
  return row[index];
};

/** RFC 4180 reader for the CSV export (quoted cells, doubled quotes). */
function parseCsv(text) {
  const rows = [];
  let row = [];
  let cell = '';
  let quoted = false;
  for (let i = 0; i < text.length; i++) {
    const ch = text[i];
    if (quoted) {
      if (ch === '"' && text[i + 1] === '"') {
        cell += '"';
        i++;
      } else if (ch === '"') quoted = false;
      else cell += ch;
    } else if (ch === '"') quoted = true;
    else if (ch === ',') {
      row.push(cell);
      cell = '';
    } else if (ch === '\n' || ch === '\r') {
      if (ch === '\r' && text[i + 1] === '\n') i++;
      row.push(cell);
      rows.push(row);
      row = [];
      cell = '';
    } else cell += ch;
  }
  if (cell !== '' || row.length) {
    row.push(cell);
    rows.push(row);
  }
  return rows;
}

const isoDay = (offsetDays = 0) => {
  const d = new Date(Date.now() + offsetDays * 86400000);
  return `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, '0')}-${String(d.getDate()).padStart(2, '0')}`;
};

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

/** The Sales Order screen (TR_SALE_ORD) as the source document of the lifecycle and journey cases. */
const SO_LINE = (pcs, net) => ({
  item: 'GLD22',
  pcs: String(pcs),
  gross: String(net),
  net: String(net),
  touch: '100',
  rate: '1500',
  labour: '40',
});
async function openSalesOrder(page) {
  await page.goto('/txn/sales-order');
  await page.getByRole('heading', { name: 'Sales Order', exact: true }).waitFor();
  await page.waitForFunction(() => {
    const input = document.querySelector('[aria-label="Labour rate item 1"]');
    return input && !input.matches(':disabled');
  });
}
async function fillSalesOrderLine(page, n, line) {
  const item = page.getByLabel(`Item code ${n}`, { exact: true });
  await item.fill(line.item);
  await item.press('Escape');
  for (const [label, key] of [
    ['Pieces', 'pcs'],
    ['Gross weight', 'gross'],
    ['Net weight', 'net'],
    ['Touch', 'touch'],
    ['Rate', 'rate'],
    ['Labour rate', 'labour'],
  ])
    await page.getByLabel(`${label} item ${n}`, { exact: true }).fill(line[key]);
  await page.getByLabel(`Labour rate item ${n}`, { exact: true }).press('Tab');
}
async function saveSalesOrder(page, label) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        /^\/api\/sales-orders(\/\d+)?$/.test(new URL(r.url()).pathname) &&
        ['POST', 'PUT'].includes(r.request().method()),
    ),
    page.getByRole('button', { name: label, exact: true }).click(),
  ]);
  return response;
}
/** Enter and save a Sales Order for party E2ELOC with a cash advance; returns the stored header. */
async function createSalesOrder(ctx, page, { lines, advance }) {
  await openSalesOrder(page);
  const customer = page.getByLabel('Customer account', { exact: true });
  await customer.fill('E2ELOC');
  await customer.locator('xpath=..').getByText('E2ELOC', { exact: true }).first().waitFor();
  await customer.press('Enter');
  for (const [i, line] of lines.entries()) {
    if (i) await page.getByRole('button', { name: '+ Add line', exact: true }).click();
    await fillSalesOrderLine(page, i + 1, line);
  }
  await page.getByLabel('Advance ₹', { exact: true }).fill(String(advance));
  const response = await saveSalesOrder(page, 'Save Sales Order');
  assert.equal(response.status(), 201, await response.text());
  const { vchNo } = await response.json();
  const [header] = await ctx.rows(
    `SELECT "CO_YEAR" "year","CO_BOOK" "book","VCH_NO" "vch","TOT_AMT"::float8 "tot","ADV_AMT"::float8 "adv","CASH_AMT"::float8 "cash"
       FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "VCH_NO" = ANY($2::text[])`,
    [String(vchNo), String(vchNo).padStart(5, '0')],
  );
  assert(header, `the saved order ${vchNo} is stored`);
  return header;
}

/**
 * TR_SALE_ORD.cs:9503 {{dataRow7["ORD_SIGN"] = "+";}} writes the advance as a "+" SL_ORD_ADJ row under the order's
 * own keys. The web Sales Order writes it too since #262 (SR_NO 1, ORD_SIGN '+', ORD_AMT the advance), and its edit
 * and delete replace or remove it with the rest of the write set; the '+' row alone never blocks an edit. The case
 * checks that the saved order carries that row, so the report is judged on what the Sales Order screen wrote.
 */
async function expectAdvanceAdjustment(ctx, header) {
  const rows = await ctx.rows(
    `SELECT "ORD_SIGN" AS sign, "ORD_AMT"::float8 AS amt FROM "SL_ORD_ADJ"
      WHERE tenant_id=$1 AND "CO_YEAR"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$4 AND "ORD_NO"=$4`,
    header.year,
    header.book,
    header.vch,
  );
  const plus = rows.filter((row) => row.sign === '+');
  assert.equal(
    plus.length,
    1,
    `one "+" SL_ORD_ADJ row for order ${header.vch}: ${JSON.stringify(rows)}`,
  );
  const order = await ctx.rows(
    `SELECT "ADV_AMT"::float8 AS adv FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_YEAR"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$4`,
    header.year,
    header.book,
    header.vch,
  );
  assert.equal(Number(plus[0].amt), Number(order[0].adv), 'the "+" row carries the order advance');
}

/** Everything one saved order writes (ORDER_WRITE_SET of salesOrder.mjs), for a case that fails midway. */
async function removeSalesOrder(ctx, vch) {
  for (const table of [
    'SL_ORD_ADJ',
    'SL_ORD_DETL',
    'SL_ORD_DATA',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'TEMP_BOOK_DATA',
  ])
    await ctx.rows(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"='SOR' AND "VCH_NO" = $2`,
      vch,
    );
}
/** Every mode over the whole life of the books, to include an order dated today. */
const WHOLE_LIFE = () => ({ from: '2010-01-01', to: isoDay(1) });

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
  // Rights are keyed by the session location; every session opens at the company default (01) and a head-office
  // user then switches to 00, so the user holds the row at both.
  for (const lc of new Set(['01', lcCode]))
    await ctx.rows(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       SELECT $1::text,'01',$2::text,$3::text,'Report',$4::text,'Y','N','N',$5::text
        WHERE NOT EXISTS (SELECT 1 FROM "USER_SET" WHERE tenant_id=$1 AND "LC_CODE"=$2::text AND "USER_NAME"=$3::text AND "SUB_MENU"=$4::text)`,
      lc,
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
          const page00 = await openReport(ctx, as(user), { lcCode: '00' });
          assert.equal(await field(page00, 'lc Code').inputValue(), '00');
          assert.equal(await field(page00, 'lc Code').isDisabled(), false);
          await field(page00, 'lc Code').fill('');
          await runMode(page00, 'report', { from: WIDE_FROM });
          assertCodes(await readGrid(page00), ['O6', 'O1'], ['O7']);
          // Typing the own location back lists only the head office's own order (RP_ALL.cs:8383).
          await runMode(page00, 'report', { from: WIDE_FROM, 'lc Code': '00' });
          assertCodes(await readGrid(page00), ['O6'], ['O1', 'O2', 'O3']);
          // A 00 session may name a branch: the box value travels as reportLcCode (not the session scope's
          // lcCode, which would be refused 409) and lists only that location (RP_ALL.cs:8383).
          const branch = await runMode(page00, 'report', { from: WIDE_FROM, 'lc Code': '01' });
          assert.equal(branch.query.get('reportLcCode'), '01');
          assert.equal(branch.query.get('lcCode'), null);
          await page00
            .locator('table.grid tbody')
            .getByText('O1', { exact: true })
            .first()
            .waitFor();
          assertCodes(await readGrid(page00), ['O1', 'O2'], ['O6']);
        });
      },
    ),

    desiredCase(
      'scope.session-location-excludes-other-location',
      'T01',
      'read-only',
      `RP_ALL.cs:6660 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}}; RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}; RP_ALL.cs:8383 {{CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";}}`,
      {
        session01Lists: ['O1', 'O2', 'O3', 'O4', 'O8'],
        otherLocationAbsent: 'O6 (location 00)',
        otherCompanyAbsent: 'O7 (company C2)',
        forgedLocationRefused: 'lcCode=00 from a session at 01 is refused, nothing listed',
        sharedCodePath: 'the shared RP_ALL scope still locks Order Report to the session location',
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          assert.equal(await field(page, 'lc Code').isDisabled(), true);
          const run = await runMode(page, 'report', { from: WIDE_FROM });
          assertCodes(await readGrid(page), ['O1', 'O2', 'O3', 'O4', 'O8'], ['O6', 'O7']);
          assert.equal(run.query.get('lcCode') ?? '01', '01', 'the locked box sends only 01');
          // The same session cannot widen the report to another location by sending a location itself.
          const forged = await page.evaluate(async (path) => {
            const forgedLocation = await fetch(
              `${path}?fromDate=2000-01-01&toDate=2099-12-31&lcCode=00`,
              {
                credentials: 'include',
              },
            );
            const none = await fetch(`${path}?fromDate=2000-01-01&toDate=2099-12-31`, {
              credentials: 'include',
            });
            return {
              status: forgedLocation.status,
              error: (await forgedLocation.json().catch(() => ({}))).error,
              noneStatus: none.status,
              noneText: await none.text(),
            };
          }, API_PATH);
          assert.ok(
            forged.status >= 400 && forged.status < 500,
            `forged lcCode refused: ${forged.status}`,
          );
          assert.equal(forged.noneStatus, 200);
          assert.ok(
            !forged.noneText.includes('"O6"'),
            'a request with no location is the session location only',
          );
          await ctx.shot(page, 'order-report-session-location');
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
        O1: EXPECT.adjust.O1,
        O3: EXPECT.adjust.O3,
        grand: { ord: 8000, adj: 5000, bal: 3000 },
        withoutAdjustments: ['O2', 'O4', 'O8'],
        detailBand: 'suppressed (OrdAdvAdj prints the per-order sums only)',
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const mode = await runMode(page, 'adjust');
          const grid = await readGrid(page);
          assert.equal(mode.body.title, TITLES.adjust);
          // OrdAdvAdj.xml:13-31 links SL_ORD_DATA to SL_ORD_ADJ with LeftOuter joins, so an order in range
          // without adjustments still reaches the report. The group is @OrdGroup = ORD_LC+ORD_YRCD+ORD_DBCD+ORD_NO
          // (OrdAdvAdj.xml:231,252): an order without adjustment rows has NULL ORD_* fields, so every such order
          // falls into ONE null group headed by the first of them in the record sort (CO_YEAR, VCH_DATE,
          // VCH_NO, OrdAdvAdj.xml:234-237), here O2. The detail band is suppressed; each band carries
          // Sum(@OrdAmt), Sum(@OrdAdjAmt), Sum(@BalAmt), @OrdAmt/@OrdAdjAmt chosen by ORD_SIGN.
          const money = (n) => n.toFixed(2);
          for (const [vch, date, name, expected] of [
            ['O1', '05/01/2026', 'ALPHA JEWELS', EXPECT.adjust.O1],
            ['O3', '15/01/2026', 'ALPHA JEWELS', EXPECT.adjust.O3],
            ['O2', '10/01/2026', 'BETA TRADERS', { ord: 0, adj: 0, bal: 0 }],
          ]) {
            const row = gridRow(grid, `${vch} ${date} ${name}`);
            assert.deepEqual(
              ['Order Adv', 'Order Adjust', 'Panding Amt'].map((caption) =>
                cellOf(grid, row, caption),
              ),
              [money(expected.ord), money(expected.adj), money(expected.bal)],
              `${vch} advance, adjustment and pending`,
            );
          }
          assert.equal(
            grid.rows.length,
            3,
            'O1, O3 and the one null group of the unadjusted orders',
          );
          assertCodes(grid, [], ['O4', 'O8']);
          assertCodes(grid, [], ['O5', 'O6']);
          assert.deepEqual(
            ['Order Adv', 'Order Adjust', 'Panding Amt'].map((caption) =>
              cellOf(grid, grid.footer, caption),
            ),
            ['8000.00', '5000.00', '3000.00'],
          );
          assert.equal(grid.footer[0], 'TOTAL :');
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
        pendingRule:
          'stored DESIGN_ISU = N only; the HM310NEPK-only write is not ported (API review 69bd05e7)',
        pendingGrand: { pcs: EXPECT.pendingPcs, nwt: EXPECT.pendingNwt },
        noStatusFilter: true,
      },
      async ({ ctx, page }) => {
        assert.deepEqual(EXPECT.reportPcs, 9);
        assert.deepEqual(EXPECT.reportNwt, 31.875);
        assert.deepEqual(EXPECT.pendingPcs, 8);
        assert.deepEqual(EXPECT.pendingNwt, 28.875);
        await withFixture(ctx, async () => {
          await runMode(page, 'report');
          const all = await readGrid(page);
          assertCodes(all, ['O1', 'O2', 'O3', 'O4', 'O8'], ['O5', 'O6']);
          assert.equal(all.footer[0], 'Total :');
          assert.equal(cellOf(all, all.footer, 'Pcs'), String(EXPECT.reportPcs));
          assert.equal(cellOf(all, all.footer, 'Net Wt'), EXPECT.reportNwt.toFixed(3));
          await runMode(page, 'pending');
          const pending = await readGrid(page);
          // Every line stored with DESIGN_ISU N lists, so the fully adjusted O3 stays; O8 is stored Y.
          assertCodes(pending, ['O1', 'O2', 'O3', 'O4'], ['O5', 'O8']);
          assert.equal(cellOf(pending, pending.footer, 'Pcs'), String(EXPECT.pendingPcs));
          assert.equal(cellOf(pending, pending.footer, 'Net Wt'), EXPECT.pendingNwt.toFixed(3));
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
      'RP_ALL.cs:9776 {{DC_Main.RptName = "OrdAdjBillWise";}}; extraction_output/rpt_xml/OrdAdjBillWise.xml:399-401 @AdjAmt = ORD_SIGN "-" rows only; @PandingTot = ADV_AMT - Sum(@AdjAmt, VCH_NO)',
      {
        O1: {
          advance: 5000,
          adjusted: 2000,
          pending: 3000,
          bills: [
            ['S1', 12000, 1500],
            ['S1', 12000, 500],
          ],
        },
        O3: {
          advance: 3000,
          adjusted: 3000,
          pending: 0,
          bills: [
            ['S2', 9000, 1500],
            ['S2', 9000, 1500],
          ],
        },
        withoutBills: ['O2', 'O4', 'O8'],
        grandBand: false,
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const mode = await runMode(page, 'with-bill');
          const grid = await readGrid(page);
          assert.equal(mode.body.title, TITLES['with-bill']);
          assert.equal(grid.footer.length, 0, 'OrdAdjBillWise has no report-footer sum (D13)');
          const money = (n) => n.toFixed(2);
          // Per-order band: ADV_AMT, Sum(@AdjAmt) over the "-" rows and @PandingTot.
          for (const [label, adv, adjusted] of [
            ['O1 05/01/2026', 5000, 2000],
            ['O3 15/01/2026', 3000, 3000],
            ['O2 10/01/2026', 0, 0],
            ['O4 12/01/2026', 0, 0],
            ['O8 20/01/2026', 0, 0],
          ]) {
            const row = gridRow(grid, label);
            assert.deepEqual(
              ['Total Adv.', 'Adjust Amt', 'Panding Amt'].map((caption) =>
                cellOf(grid, row, caption),
              ),
              [money(adv), money(adjusted), money(adv - adjusted)],
              `${label} advance, adjusted and pending`,
            );
          }
          // Detail band: the "+" advance row of the order itself (no bill) and one line per "-" adjustment
          // with the bill's own voucher, party and bill total.
          const detail = grid.rows.filter((cells) => cells[0] === 'line');
          const shape = detail.map((cells) =>
            ['Book', 'Vch No', 'Bill Party Name', 'Bill Amt', 'Adjust Amt'].map((caption) =>
              cellOf(grid, cells, caption),
            ),
          );
          for (const expected of [
            ['B1', 'O1', '', '0.00', '0.00'],
            ['SB', 'S1', 'ALPHA JEWELS', '12000.00', '1500.00'],
            ['SB', 'S1', 'ALPHA JEWELS', '12000.00', '500.00'],
            ['B1', 'O3', '', '0.00', '0.00'],
            ['SB', 'S2', 'ALPHA JEWELS', '9000.00', '1500.00'],
            ['SB', 'S2', 'ALPHA JEWELS', '9000.00', '1500.00'],
          ])
            assert(
              shape.some((cells) => cells.join('|') === expected.join('|')),
              `detail line ${expected.join('|')} in ${shape.map((cells) => cells.join('|')).join(' ; ')}`,
            );
          assertCodes(grid, [], ['O5', 'O6', 'S3']);
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
        billWithoutAdjustment: 'S3 does not list (Equal join)',
        custNameFiltersBill: true,
        grandBand: false,
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const mode = await runMode(page, 'bill-wise');
          const grid = await readGrid(page);
          assert.equal(grid.footer.length, 0, 'no total band (D13)');
          assert.equal(mode.body.title, TITLES['bill-wise']);
          // The bill is the base (Equal join to SL_ORD_ADJ, BillWiseOrderAdjust.xml): S3 has no adjustment row
          // and does not list; each bill prints its total and advance, then the raw ORD_AMT of every row.
          const bills = grid.rows.filter((cells) => cells[0] === 'voucher');
          assert.deepEqual(
            bills.map((cells) =>
              ['Vch No', 'Bill Amt'].map((caption) => cellOf(grid, cells, caption)).join(':'),
            ),
            ['S1:12000.00', 'S2:9000.00'],
          );
          const orders = grid.rows
            .filter((cells) => cells[0] === 'line')
            .map((cells) =>
              ['Order Book', 'Order No', 'Order Party', 'Adv Amt']
                .map((caption) => cellOf(grid, cells, caption, { last: true }))
                .join(':'),
            );
          assert.deepEqual(orders, [
            'B1:O1:ALPHA JEWELS:1500.00',
            'B1:O1:ALPHA JEWELS:500.00',
            'B1:O3:ALPHA JEWELS:1500.00',
            'B1:O3:ALPHA JEWELS:1500.00',
          ]);
          assertCodes(grid, [], ['S3', 'O2', 'O4', 'O8', 'S0', 'O5']);
          await runMode(page, 'bill-wise', { 'Cust Name': 'ALPHA JEWELS' });
          assertCodes(await readGrid(page), ['S1', 'S2'], ['S3']);
          await runMode(page, 'bill-wise', { 'Party Code': 'P2' });
          assertCodes(await readGrid(page), [], ['S1', 'S2', 'S3']);
          await runMode(page, 'bill-wise', { City: 'BARODA' });
          assertCodes(await readGrid(page), [], ['S1', 'S2']);
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
        await withFixture(ctx, async () => {
          for (const [caption, code, name, next] of [
            ['Book', 'B1', 'Order Book 1', 'Party Code'],
            ['Party Code', 'P1', 'ALPHA JEWELS', 'Cust Name'],
          ]) {
            const input = field(page, caption);
            await input.fill(code);
            await input.press('Enter');
            await page.getByText(name, { exact: true }).first().waitFor();
            await focusIs(page, next); // a known code fills its name and tabs on (RP_ALL.cs:7322-7328, :7421)
            await input.fill('ZZ');
            await input.press('Enter');
            await page.getByRole('dialog').waitFor();
            await page.keyboard.press('Escape');
            assert.equal(await input.inputValue(), 'ZZ', 'cancel keeps the typed text');
            assert.equal(await page.getByRole('dialog').count(), 0, 'the help closed');
          }
          const user = 'e2eorderloc00b';
          await ensureUser(ctx, { user, subMenu: 'Order Report', lcCode: '00' });
          const page00 = await openReport(ctx, as(user), { lcCode: '00' });
          const lc = field(page00, 'lc Code');
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
          const input = field(page, 'Cust Name');
          await input.fill('ALPHA JEWELS');
          await input.press('Enter');
          assert.equal(await input.inputValue(), 'ALPHA JEWELS', 'copied back exactly as stored');
          await focusIs(page, 'City'); // a found name moves to City (RP_ALL.cs:9712)
          await input.fill('NO SUCH NAME');
          await input.press('Enter');
          await page.getByRole('dialog').waitFor();
          await page.keyboard.press('Escape');
          assert.equal(await input.inputValue(), 'NO SUCH NAME');
          await input.press('Enter');
          await page
            .getByRole('dialog')
            .getByRole('button', { name: /BETA TRADERS/ })
            .click();
          assert.equal(await input.inputValue(), 'BETA TRADERS', 'picking writes the name');
          await focusIs(page, 'Cust Name'); // the focus returns after the help (RP_ALL.cs:9693)
          await input.fill('');
          await input.press('Enter');
          await focusIs(page, 'City'); // an empty name moves to City (RP_ALL.cs:9723)
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
            assert.equal(response.status(), 200, await response.text());
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
        created: { pcs: 3, nwt: 15.75, cash: 5000 },
        editedNwt: 6,
        nwtDelta: 0.75,
        afterDelete: 'no rows in any mode',
        advanceAdjustment: '+ 5000',
      },
      async ({ ctx, page }) => {
        const whole = WHOLE_LIFE();
        const report = await openReport(ctx);
        await runMode(report, 'report', whole);
        const before = await readGrid(report);
        const beforePcs = Number(cellOf(before, before.footer, 'Pcs'));
        const beforeNwt = Number(cellOf(before, before.footer, 'Net Wt'));
        let header;
        try {
          header = await createSalesOrder(ctx, page, {
            lines: [SO_LINE(1, 10.5), SO_LINE(2, 5.25)],
            advance: 5000,
          });
          assert.equal(header.adv, 5000, 'the advance is stored on the order');
          // Step 2: modes 1 and 2 follow the new order.
          await runMode(report, 'report', whole);
          const created = await readGrid(report);
          const voucher = created.rows.find(
            (cells) => cells[0] === 'voucher' && cellOf(created, cells, 'Ord No') === header.vch,
          );
          assert(voucher, `order ${header.vch} voucher row`);
          assert.equal(cellOf(created, voucher, 'Advance Amt'), '5000.00');
          assert.equal(cellOf(created, created.footer, 'Pcs'), String(beforePcs + 3));
          assert.equal(cellOf(created, created.footer, 'Net Wt'), (beforeNwt + 15.75).toFixed(3));
          assertCodes(created, ['10.500', '5.250'], []);
          await runMode(report, 'advance', whole);
          const advance = await readGrid(report);
          const advRow = advance.rows.find((cells) => cells.includes(header.vch));
          assert(advRow, `order ${header.vch} in the Order Advance report`);
          assert.equal(cellOf(advance, advRow, 'Total Adv.'), '5000.00');
          assert.equal(cellOf(advance, advRow, 'Order Amt'), header.tot.toFixed(2));
          await runMode(report, 'pending', whole);
          assertCodes(await readGrid(report), [header.vch, '10.500', '5.250'], []);
          // Step 3: edit line 2 to 6.000 on the Sales Order screen; mode 1 rises by 0.750.
          await openSalesOrder(page);
          await page.getByLabel('Order number', { exact: true }).fill(header.vch);
          await page.getByRole('button', { name: 'Load order', exact: true }).click();
          await page.getByText(`Editing order #${header.vch}`, { exact: true }).waitFor();
          await page.waitForFunction(() => {
            const input = document.querySelector('[aria-label="Net weight item 2"]');
            return input && !input.matches(':disabled');
          });
          await page.getByLabel('Net weight item 2', { exact: true }).fill('6');
          await page.getByLabel('Gross weight item 2', { exact: true }).fill('6');
          await page.getByLabel('Labour rate item 2', { exact: true }).press('Tab');
          const edited = await saveSalesOrder(page, 'Update Sales Order');
          assert.equal(edited.status(), 200, await edited.text());
          await runMode(report, 'report', whole);
          const after = await readGrid(report);
          assert.equal(cellOf(after, after.footer, 'Net Wt'), (beforeNwt + 16.5).toFixed(3));
          // The advance row the Sales Order wrote (see expectAdvanceAdjustment): Order Adjust shows the "+" 5000 and
          // the pending 5000.
          await expectAdvanceAdjustment(ctx, header);
          await runMode(report, 'adjust', whole);
          const adjusted = await readGrid(report);
          const band = adjusted.rows.find((cells) => cells[0].startsWith(header.vch));
          assert(band, `order ${header.vch} in the Order Adjust report`);
          assert.equal(cellOf(adjusted, band, 'Order Adv'), '5000.00');
          assert.equal(cellOf(adjusted, band, 'Panding Amt'), '5000.00');
          // Step 4: delete the order on its own screen; every mode drops it.
          await openSalesOrder(page);
          await page.getByLabel('Order number', { exact: true }).fill(header.vch);
          await page.getByRole('button', { name: 'Load order', exact: true }).click();
          await page.getByText(`Editing order #${header.vch}`, { exact: true }).waitFor();
          const [deleted] = await Promise.all([
            page.waitForResponse(
              (r) => r.request().method() === 'DELETE' && r.url().includes('/api/sales-orders/'),
            ),
            page.getByRole('button', { name: 'Delete order', exact: true }).click(),
          ]);
          assert(deleted.status() < 300, `delete answered ${deleted.status()}`);
          for (const mode of ['report', 'advance', 'adjust', 'with-bill', 'pending', 'summary']) {
            await runMode(report, mode, whole);
            assertCodes(await readGrid(report), [], [header.vch]);
          }
        } finally {
          // The screen's delete leaves the seeded advance row behind; remove whatever is left.
          if (header) await removeSalesOrder(ctx, header.vch);
        }
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
        await ensureUser(ctx, { user: 'e2eordsalesonly', subMenu: 'Sales Order', print: 'N' });
        await ensureUser(ctx, { user: 'e2eorderprintno', subMenu: 'Order Report', print: 'N' });
        const { page: salesPage } = await ctx.session(as('e2eordsalesonly'));
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
            // A sale bill (own keys SB/vch) that adjusts the order, so Order Wise Bill and Bill Wise Adjust overflow too.
            await ctx.rows(
              `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME","TOT_AMT","ADV_AMT")
               VALUES($1,'01','01',$2,'SB',$3,$4::date,'P1','ALPHA JEWELS',100,0)`,
              YEAR,
              vch,
              '2026-01-06',
            );
            await ctx.rows(
              `INSERT INTO "SL_ORD_ADJ"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","ORD_SIGN","ORD_AMT","ORD_LC","ORD_YRCD","ORD_DBCD","ORD_NO","ORD_AC_CODE")
               VALUES($1,'01','01',$2,'SB',$3,1,$4::date,'-',100,'01',$2,'B1',$3,'P1')`,
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
            // exportRows.ts prints the same lines as the grid body and then the grand total, which the
            // grid shows in its footer (OrdDetlRpt "Total :", OrdAdvAdj "TOTAL :").
            const csvRows = parseCsv(await csv.text()).filter((cells) => cells.some(Boolean));
            const printed = [...grid.rows, ...(grid.footer.length ? [grid.footer] : [])];
            assert.equal(
              csvRows.length,
              printed.length + 1,
              `mode ${mode}: CSV has one header plus every grid row and the total`,
            );
            assert.deepEqual(csvRows[0], grid.headers, `mode ${mode}: CSV columns match the grid`);
            printed.forEach((cells, i) =>
              assert.deepEqual(
                csvRows[i + 1].map((cell) => cell.trim()),
                cells,
                `mode ${mode}: CSV line ${i + 1} equals the grid line`,
              ),
            );
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
        // Enter walks the enabled selectors in tab order; disabled ones (lc Code at 01, Pr Code, Gr Code,
        // Item Type) are skipped, as the browser skips them (RP_ALL.cs:7506 jumps Pr Code to City).
        const walked = [];
        for (let step = 0; step < 8; step++) {
          walked.push(
            await page.evaluate(() => document.activeElement?.getAttribute('aria-label') ?? ''),
          );
          await page.keyboard.press('Enter');
        }
        assert.deepEqual(walked.slice(0, 7), [
          'From',
          'To',
          'Book',
          'Party Code',
          'Cust Name',
          'City',
          'Area',
        ]);
        for (const caption of SELECTORS)
          assert.equal(await field(page, caption).count(), 1, `${caption} is on the screen`);
        const party = field(page, 'Party Code');
        await party.fill("ab'c");
        assert.equal(
          await party.inputValue(),
          'ABC',
          'typed text is upper-cased and the quote swallowed',
        );
        await page.keyboard.press('Escape');
        await page.waitForURL((url) => !url.pathname.startsWith('/reports/order-report'));
        const reopened = await openReport(ctx);
        const city = field(reopened, 'City');
        // City is an editable combo (RP_ALL.cs:7567 reads cboCity.Text), typed in lower case here.
        await city.fill('surat');
        await reopened.getByRole('button', { name: 'Cancel', exact: true }).click();
        assert.equal(await field(reopened, 'From').inputValue(), '', 'Cancel clears the dates');
        assert.equal(
          await city.inputValue(),
          'SURAT',
          'upper-cased, and Cancel keeps the combo text',
        );
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
        created: { advance: 5000, pcs: 2, nwt: 15 },
        afterFirstAdjustment: { orderAdv: 5000, adjusted: 3000, pending: 2000, mode7Amount: 3000 },
        afterSecondAdjustment: { adjusted: 5000, pending: 0, stillInModes1And2: true },
        flag: 'DESIGN_ISU remains N (D2); Making Panding lists the line either way',
      },
      async ({ ctx, page }) => {
        const whole = WHOLE_LIFE();
        let header;
        try {
          header = await createSalesOrder(ctx, page, { lines: [SO_LINE(2, 15)], advance: 5000 });
          await expectAdvanceAdjustment(ctx, header);
          const report = await openReport(ctx);
          const money = (n) => n.toFixed(2);
          const adjustBand = async () => {
            await runMode(report, 'adjust', whole);
            const grid = await readGrid(report);
            const band = grid.rows.find((cells) => cells[0].startsWith(header.vch));
            assert(band, `order ${header.vch} in Order Adjust`);
            return ['Order Adv', 'Order Adjust', 'Panding Amt'].map((caption) =>
              cellOf(grid, band, caption),
            );
          };
          // Step 2: the order, its "+" advance row and its stored total.
          await runMode(report, 'report', whole);
          const first = await readGrid(report);
          assertCodes(first, [header.vch, '15.000'], []);
          await runMode(report, 'advance', whole);
          const advance = await readGrid(report);
          const advRow = advance.rows.find((cells) => cells.includes(header.vch));
          assert.equal(cellOf(advance, advRow, 'Total Adv.'), money(5000));
          assert.equal(cellOf(advance, advRow, 'Order Amt'), money(header.tot));
          assert.deepEqual(await adjustBand(), [money(5000), money(0), money(5000)]);
          await runMode(report, 'pending', whole);
          assertCodes(await readGrid(report), [header.vch], []);
          // Step 3 and 4: bill S9 (total 8000) adjusts the order; the bill's own keys are (SB, S9),
          // ORD_* point at the order (Ac_Tax.cs:71-73).
          await ctx.rows(
            `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME","TOT_AMT","ADV_AMT")
             SELECT $1,'01','01',$2,'SB','S9',$3::date,'E2ELOC','E2E LOCAL CUSTOMER',8000,5000`,
            header.year,
            isoDay(),
          );
          const adjustment = async (sr, amount) =>
            ctx.rows(
              `INSERT INTO "SL_ORD_ADJ"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","ORD_SIGN","ORD_AMT","ORD_LC","ORD_YRCD","ORD_DBCD","ORD_NO","ORD_AC_CODE")
               VALUES($1,'01','01',$2,'SB','S9',$3,$4::date,'-',$5,'01',$2,$6,$7,'E2ELOC')`,
              header.year,
              sr,
              isoDay(),
              amount,
              header.book,
              header.vch,
            );
          await adjustment(1, 3000);
          assert.deepEqual(await adjustBand(), [money(5000), money(3000), money(2000)]);
          await runMode(report, 'with-bill', whole);
          const withBill = await readGrid(report);
          const orderBand = gridRow(withBill, header.vch);
          assert.equal(cellOf(withBill, orderBand, 'Adjust Amt'), money(3000));
          assert.equal(cellOf(withBill, orderBand, 'Panding Amt'), money(2000));
          const billLine = withBill.rows.find(
            (cells) => cells[0] === 'line' && cellOf(withBill, cells, 'Vch No') === 'S9',
          );
          assert.equal(cellOf(withBill, billLine, 'Bill Amt'), money(8000));
          await runMode(report, 'pending', whole);
          assertCodes(await readGrid(report), [header.vch], []);
          await runMode(report, 'bill-wise', whole);
          const billWise = await readGrid(report);
          const billRow = billWise.rows.find((cells) => cellOf(billWise, cells, 'Vch No') === 'S9');
          assert.equal(cellOf(billWise, billRow, 'Bill Amt'), money(8000));
          const orderLine = billWise.rows.find(
            (cells) =>
              cells[0] === 'line' &&
              cellOf(billWise, cells, 'Order No', { last: true }) === header.vch,
          );
          assert.equal(cellOf(billWise, orderLine, 'Adv Amt', { last: true }), money(3000));
          // Step 4: the second adjustment nets the order to zero. The web never writes DESIGN_ISU, so the
          // line still lists in Making Panding, and modes 1 and 2 list it as always (D2, D3).
          await adjustment(2, 2000);
          assert.deepEqual(await adjustBand(), [money(5000), money(5000), money(0)]);
          for (const mode of ['report', 'advance', 'pending', 'summary']) {
            await runMode(report, mode, whole);
            assertCodes(await readGrid(report), [header.vch], []);
          }
          const flags = await ctx.rows(
            `SELECT "DESIGN_ISU" "designIsu" FROM "SL_ORD_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
            header.vch,
          );
          assert(
            flags.length > 0 && flags.every((row) => row.designIsu === 'N'),
            'D2: never written',
          );
        } finally {
          if (header) {
            await removeSalesOrder(ctx, header.vch);
            await ctx.rows(`DELETE FROM "SL_DATA" WHERE tenant_id=$1 AND "VCH_NO"='S9'`);
            await ctx.rows(`DELETE FROM "SL_ORD_ADJ" WHERE tenant_id=$1 AND "VCH_NO"='S9'`);
          }
        }
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
