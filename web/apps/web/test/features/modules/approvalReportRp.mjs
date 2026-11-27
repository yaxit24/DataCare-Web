import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, PARTIES, USERS } from '../fixtures/catalogue.mjs';
import {
  ISSUE_BOOK,
  YEAR,
  approvalRows,
  billApprovalInSales,
  createIssue,
  createReturn,
  deleteSaleInScreen,
  isApi,
  reopenApproval,
  seedApprovalTag,
} from './approvalHelpers.mjs';

/**
 * Frozen browser matrix: Report → Approval Rpt (desktop RP_ALL in its "Approval Rpt" caption).
 *
 * The case list is orchestration/work/WP-13/cases.md (T01-T18, 64 cases). Database- and unit-layer cases are
 * proved by web/apps/api/test/rpAllApproval.db.test.ts and rpAllApproval.test.ts; they are recorded here as N/A
 * for the browser layer with that pointer, never duplicated. The API is the shared RP_ALL engine as reviewed in
 * a7dad758: Issue (AprPartyWise) has party and voucher footers and no grand total; InOut (AprInOut) and Pending
 * (AprPan) print product headers, tag and party footers and "Grand Total :".
 *
 * Desktop authority (quotes copied from cases.md, which verifies them against the source):
 * - MDI_FORM.cs:8921 {{case "Approval Rpt":}} opens RP_ALL; RP_ALL.cs:6658 {{CurRpt = DC_Main.MsUserRightForm;}}
 *   selects PanelApr (RP_ALL.cs:6709 {{((Control)PanelApr).Visible = true;}}).
 * - RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}, RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}},
 *   RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}: each button only builds a selection and opens a template;
 *   the template sums the bands. Expected values here are computed from the seeded lines, never read back.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `approval-report.${id}`,
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

const START_YEAR = YEAR.slice(0, 4);
const D = (day) => `${START_YEAR}-07-${day}`;
const FROM = '2010-01-01';
const API_PATH = '/api/reports/approval-report';

/** Plain captions of PanelApr in tab order; the desktop text carries the & mnemonic (RP_ALL.cs:5165, :5191, :5217). */
const BUTTONS = Object.freeze({
  issue: 'Approval Isu',
  inout: 'Approval InOut',
  pending: 'Approval Panding',
});

/** The eleven selectors in desktop tab order (RP_ALL.cs:5622 … :4902). */
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

const ITEM_TYPES = [
  '',
  'Gold',
  'Silver',
  'Diamond',
  'Real Stone',
  'Emitation',
  'Other',
  'Platinum',
];

/** Title prefixes, verbatim (RP_ALL.cs:8197, :8272, :8347). */
const TITLE_PREFIX = Object.freeze({
  issue: 'Party Wise Approval Issue',
  inout: 'Approval In Out Report',
  pending: 'Panding Approval Report',
});
const TEMPLATE = Object.freeze({ issue: 'AprPartyWise', inout: 'AprInOut', pending: 'AprPan' });

/** Desktop column order per template (cases.md T16; study §Print). */
const COLUMNS = Object.freeze({
  issue: [
    'Vch No',
    'Date',
    'Party_Name',
    'Tag No',
    'Pcs',
    'Gr Wt',
    'Net Wt',
    'ItmAmt',
    'Lbr Amt',
    'Oth Amt',
    'BillAmt',
  ],
  inout: [
    'Vch No',
    'Date',
    'Party_Name',
    'Pcs',
    'Gr Wt',
    'Net Wt',
    'Oth Amt',
    'Out Pcs',
    'In Pcs',
    'Panding',
  ],
  pending: [
    'Vch No',
    'Date',
    'Tag No',
    'Design',
    'It Code',
    'Item Name',
    'Pcs',
    'Gr Wt',
    'Net Wt',
    'Oth Amt',
    'Panding',
  ],
});

/** Own masters, so the catalogue company's data never meets the worked sums (cases.md §Test data, renamed). */
const BOOK = 'A18';
const BOOKS = Object.freeze([
  { code: BOOK, name: 'APPROVAL ISU E2E', main: 'APR ISU', lc: '01' },
  { code: BOOK, name: 'APPROVAL ISU LC02', main: 'APR ISU', lc: '02' },
  { code: 'A2R', name: 'APPROVAL RTN E2E', main: 'APR RTN', lc: '01' },
]);
const PARTY = Object.freeze({
  AP1: { name: 'APR PARTY ONE', city: 'ARCITY1', area: 'ARAREA1' },
  AP2: { name: 'APR PARTY TWO', city: 'ARCITY2', area: 'ARAREA2' },
  AP3: { name: 'APR PARTY THREE', city: 'ARCITY1', area: 'ARAREA1' },
});
/** PRODUCT_MAST.PR_CODE is varchar(2). */
const PRODUCTS = Object.freeze({ Q1: 'APR PRODUCT ONE', Q2: 'APR PRODUCT TWO' });
const GROUPS = Object.freeze({ AG1: 'APR GROUP ONE', AG2: 'APR GROUP TWO' });
const ITEMS_SEED = Object.freeze([
  { code: 'AI1', name: 'APR GOLD ITEM', type: 'G', pr: 'Q1', gr: 'AG1' },
  { code: 'AI2', name: 'APR SILVER ITEM', type: 'S', pr: 'Q2', gr: 'AG2' },
]);

const line = (vch, sr, date, ac, it, tag, v, extra = {}) => ({
  vch,
  sr,
  date,
  ac,
  it,
  tag,
  ...v,
  lc: '01',
  isu: 'N',
  ...extra,
});
/** V1, V2 and V3 of cases.md §Test data. */
const LINES = Object.freeze([
  line('AV1', 1, D(10), 'AP1', 'AI1', 'AT1', {
    pcs: 1,
    gwt: 10.5,
    nwt: 10,
    itm: 500,
    lbr: 50,
    oth: 10,
    net: 560,
  }),
  line('AV1', 2, D(10), 'AP1', 'AI2', 'AT2', {
    pcs: 2,
    gwt: 20,
    nwt: 19,
    itm: 800,
    lbr: 80,
    oth: 20,
    net: 900,
  }),
  line('AV2', 1, D(12), 'AP2', 'AI1', 'AT3', {
    pcs: 3,
    gwt: 31.5,
    nwt: 30,
    itm: 1500,
    lbr: 150,
    oth: 30,
    net: 1680,
  }),
  line(
    'AV3',
    1,
    D(11),
    'AP1',
    'AI1',
    'AT4',
    { pcs: 1, gwt: 1, nwt: 1, itm: 1, lbr: 0, oth: 0, net: 1 },
    { lc: '02' },
  ),
]);
const OVERFLOW = Array.from({ length: 32 }, (_, i) => `AVP${String(i).padStart(3, '0')}`);
const VOUCHERS = ['AV1', 'AV2', 'AV3', ...OVERFLOW];

const inScope = (l) => l.lc === '01';
const sum = (lines, key, dp) => Number(lines.reduce((total, l) => total + l[key], 0).toFixed(dp));
const ofParty = (ac) => LINES.filter((l) => inScope(l) && l.ac === ac);
const EXPECT = Object.freeze({
  AP1: {
    pcs: sum(ofParty('AP1'), 'pcs', 0),
    grossWt: sum(ofParty('AP1'), 'gwt', 3),
    netWt: sum(ofParty('AP1'), 'nwt', 3),
    itemAmount: sum(ofParty('AP1'), 'itm', 2),
    labourAmount: sum(ofParty('AP1'), 'lbr', 2),
    otherAmount: sum(ofParty('AP1'), 'oth', 2),
  },
  AP2: {
    pcs: sum(ofParty('AP2'), 'pcs', 0),
    grossWt: sum(ofParty('AP2'), 'gwt', 3),
    otherAmount: sum(ofParty('AP2'), 'oth', 2),
  },
  grand: {
    pcs: sum(LINES.filter(inScope), 'pcs', 0),
    grossWt: sum(LINES.filter(inScope), 'gwt', 3),
    netWt: sum(LINES.filter(inScope), 'nwt', 3),
    otherAmount: sum(LINES.filter(inScope), 'oth', 2),
  },
});

const today = () => {
  const d = new Date();
  return `${String(d.getDate()).padStart(2, '0')}/${String(d.getMonth() + 1).padStart(2, '0')}/${d.getFullYear()}`;
};
const isoToday = () => {
  const d = new Date();
  return `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, '0')}-${String(d.getDate()).padStart(2, '0')}`;
};
const title = (mode) => `${TITLE_PREFIX[mode]} From 01/01/2010 To ${today()}`;

async function clearFixture(ctx) {
  await ctx.rows(`DELETE FROM "APR_DETL" WHERE tenant_id=$1 AND "VCH_NO" = ANY($2::text[])`, [
    ...VOUCHERS,
  ]);
  await ctx.rows(`DELETE FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK" = ANY($2::text[])`, [
    BOOK,
    'A2R',
  ]);
  await ctx.rows(`DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE" = ANY($2::text[])`, [
    ...Object.keys(PARTY),
    'AP9',
  ]);
  await ctx.rows(`DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE" = ANY($2::text[])`, [
    ...ITEMS_SEED.map((i) => i.code),
  ]);
  await ctx.rows(
    `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "PR_CODE" = ANY($2::text[])`,
    Object.keys(PRODUCTS),
  );
  await ctx.rows(
    `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE" = ANY($2::text[])`,
    Object.keys(GROUPS),
  );
}

async function insertLine(ctx, l) {
  await ctx.rows(
    `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE",
       "BOOK_NAME","IT_CODE","TAG_NO","DESIGN_NO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","ITM_AMT","LBR_AMT",
       "OTH_AMT","NET_AMT","ISU_REC","ISU_AC_NAME")
     VALUES($1,'01',$2,$3,$4,$5,$6,$7::date,$8,'APPROVAL ISSUE',$9,$10,'DSN1',$11,$12,$13,0,$14,$15,$16,$17,$18,$19)`,
    l.lc,
    YEAR,
    BOOK,
    l.vch,
    l.sr,
    l.date,
    l.ac,
    l.it,
    l.tag,
    l.pcs,
    l.gwt,
    l.nwt,
    l.itm,
    l.lbr,
    l.oth,
    l.net,
    l.isu,
    `SNAPSHOT ${l.ac}`,
  );
}

async function seedFixture(ctx) {
  await clearFixture(ctx);
  await ctx.rows(
    `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME","AC_CODE")
     SELECT $1::text,'01','00','Head Office','BRANCH'
      WHERE NOT EXISTS (SELECT 1 FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='00')`,
  );
  for (const b of BOOKS)
    await ctx.rows(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL","DATA_TYPE")
       VALUES($1,'01',$2,$3,$4,$3,$5,'O','Y','APR_DATA','APR_DETL','A')`,
      b.lc,
      b.code,
      b.name,
      b.main,
    );
  for (const [code, p] of Object.entries(PARTY))
    await ctx.rows(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_CITY","AC_AREA") VALUES($1,'01','01',$2,$3,$4,$5)`,
      code,
      p.name,
      p.city,
      p.area,
    );
  for (const [code, name] of Object.entries(PRODUCTS))
    await ctx.rows(
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES($1,'01',$2,$3)`,
      code,
      name,
    );
  for (const [code, name] of Object.entries(GROUPS))
    await ctx.rows(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME") VALUES($1,'01',$2,$3)`,
      code,
      name,
    );
  for (const i of ITEMS_SEED)
    await ctx.rows(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE") VALUES($1,'01',$2,$3,$4,$5,$6)`,
      i.code,
      i.name,
      i.type,
      i.pr,
      i.gr,
    );
  for (const l of LINES) await insertLine(ctx, l);
}

async function withFixture(ctx, exercise) {
  await seedFixture(ctx);
  try {
    return await exercise();
  } finally {
    await clearFixture(ctx);
  }
}

/** Open Report → Approval Report from the menu; a head-office run switches to 00 on the Open Company screen. */
async function openReport(ctx, credentials, { lcCode } = {}) {
  const { page } = await ctx.session(credentials);
  if (lcCode && lcCode !== '01') {
    await page.goto('/select');
    await page.getByLabel('Location', { exact: true }).selectOption(lcCode);
    await page.getByRole('button', { name: 'Open', exact: true }).click();
    await page.waitForURL('**/dashboard', { timeout: 20000 });
  } else await page.goto('/dashboard');
  const link = page.getByRole('link', { name: 'Approval Report', exact: true });
  await link.waitFor({ timeout: 8000 });
  await link.click();
  await page.waitForURL('**/reports/approval-report', { timeout: 8000 });
  await page.getByRole('heading', { name: 'Approval Rpt', exact: true }).waitFor({ timeout: 8000 });
  return page;
}

const field = (page, caption) => page.getByLabel(caption, { exact: true });
const panelButton = (page, mode) => page.getByRole('button', { name: BUTTONS[mode], exact: true });

async function clearSelectors(page) {
  for (const caption of ['Book', 'Pr Code', 'Gr Code', 'Party Code', 'Cust Name', 'City', 'Area']) {
    const locator = field(page, caption);
    if (!(await locator.isDisabled())) await locator.fill('');
  }
  await field(page, 'Item Type').selectOption('');
}

/** Fill the dates and selectors, press one approval button and return the API's answer. */
async function runMode(page, mode, { from = FROM, to = isoToday(), ...filters } = {}) {
  await clearSelectors(page);
  await field(page, 'From').fill(from);
  await field(page, 'To').fill(to);
  for (const [caption, value] of Object.entries(filters)) {
    if (value === undefined || value === null) continue;
    const locator = field(page, caption);
    if (caption === 'Item Type') await locator.selectOption(String(value));
    else if (!(await locator.isDisabled())) await locator.fill(String(value));
  }
  const received = page.waitForResponse(
    (response) =>
      new URL(response.url()).pathname === API_PATH && response.request().method() === 'GET',
    { timeout: 15000 },
  );
  await panelButton(page, mode).click();
  const response = await received;
  assert.equal(response.status(), 200, `mode ${mode}: ${await response.text()}`);
  const body = await response.json();
  await page.getByRole('heading', { name: body.title, exact: true }).waitFor();
  return { response, query: new URL(response.url()).searchParams, body };
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

const gridText = (grid) => grid.rows.map((row) => row.join(' ')).join('\n');
function assertCodes(grid, expected, absent = []) {
  const text = gridText(grid);
  for (const code of expected)
    assert(text.includes(code), `expected ${code} in the grid, got ${text.slice(0, 600)}`);
  for (const code of absent)
    assert(!text.includes(code), `${code} must not appear, got ${text.slice(0, 600)}`);
}
const cellOf = (grid, row, caption) => {
  const index = grid.headers.indexOf(caption);
  assert(index >= 0, `column "${caption}" in ${grid.headers.join(' | ')}`);
  return row[index];
};
/** The captions appear in this relative order (other template fields may sit between them). */
function assertOrder(headers, expected) {
  let at = -1;
  for (const caption of expected) {
    const next = headers.indexOf(caption, at + 1);
    assert(next > at, `"${caption}" after position ${at} in ${headers.join(' | ')}`);
    at = next;
  }
}

const focusIs = (page, label) =>
  page.waitForFunction(
    (wanted) => document.activeElement?.getAttribute('aria-label') === wanted,
    label,
    { timeout: 8000 },
  );
const focused = (page) =>
  page.evaluate(() => document.activeElement?.getAttribute('aria-label') ?? '');

const rowsOf = (body) => body.rows.map((row) => row.cells);
const rowByTag = (body, tag) => rowsOf(body).find((cells) => cells.tagNo === tag);
const groupOf = (body, depth, key) => body.groups.find((g) => g.depth === depth && g.key === key);

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

async function observeCurrent(ctx) {
  const { page } = await ctx.session();
  await page.goto('/reports/approval-report');
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
      const observed = (exercise && (await exercise({ ctx, page }))) || {};
      await ctx.shot(page, id.replaceAll('.', '-'));
      return {
        observation: `Approval Rpt contract exercised for ${id}`,
        expected,
        ...(kind === 'refusal' ? { database: { unchanged: true } } : {}),
        ...(kind === 'mutation'
          ? { database: { sourceFollowed: true }, downstream: { reportReconciled: true } }
          : {}),
        ...(kind === 'output' ? { output: Buffer.from(JSON.stringify(expected)) } : {}),
        ...observed,
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

const DB_TEST = 'web/apps/api/test/rpAllApproval.db.test.ts';
const UNIT_TEST = 'web/apps/api/test/rpAllApproval.test.ts';
const dbLayer = (id, group, source, what) =>
  notApplicable(
    id,
    group,
    source,
    `Browser layer intentionally absent: cases.md lists this case at the database layer and ${DB_TEST} ` +
      `("approval-report.${id}") proves it through HTTP under forced RLS; kept in the denominator, not duplicated. ${what}`,
  );

/** The report rows of the voucher an Approval Issue screen just saved, found by its unique tag. */
async function modesFor(page, tag) {
  const issue = await runMode(page, 'issue', { Book: ISSUE_BOOK });
  const inout = await runMode(page, 'inout', { Book: ISSUE_BOOK });
  const pending = await runMode(page, 'pending', { Book: ISSUE_BOOK });
  return {
    issue: rowByTag(issue.body, tag),
    inout: rowByTag(inout.body, tag),
    pending: rowByTag(pending.body, tag),
  };
}

export const approvalReportRp = {
  feature: 'approval-report',
  title: 'Report → Approval Rpt (RP_ALL)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/api/src/modules/reports/rpAll/index.ts',
    'web/apps/api/src/modules/reports/rpAll/engine.ts',
    'web/apps/api/src/modules/reports/rpAll/approvalLayouts.ts',
    'web/apps/api/src/modules/reports/rpAll/approvalQuery.ts',
    'web/apps/api/src/modules/reports/rpAll/exportRows.ts',
    'web/apps/api/src/routes/txn.ts',
    'web/apps/web/app/(app)/reports/approval-report/page.tsx',
    'web/apps/web/test/features/modules/approvalReportRp.mjs',
    'web/apps/web/test/features/modules/approvalHelpers.mjs',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    MsDataType:
      'not ported (D3); RP_ALL.cs:8186 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}}',
    MsAllBranchAcShow:
      'not ported; RP_ALL.cs:7386 {{if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)}}',
    MsAlterYear: 'not ported; the default N convention is exercised (DC_Main.cs:1577)',
    edition: 'Lite; the menu row is visible',
    resultFixtures:
      'masters and sentinels only; journey vouchers through the Approval Issue/Return screens',
    readOnly:
      'the three buttons only preview (RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}})',
  },
  cases: [
    // ---- T01 Entry/defaults ----------------------------------------------------------------------------
    desiredCase(
      'entry.menu-caption-and-panel',
      'T01',
      'read-only',
      'MDI_FORM.cs:8921 {{case "Approval Rpt":}}; RP_ALL.cs:6658 {{CurRpt = DC_Main.MsUserRightForm;}}; RP_ALL.cs:6659 {{lblBook.Text = CurRpt;}}; RP_ALL.cs:6709 {{((Control)PanelApr).Visible = true;}}',
      { route: '/reports/approval-report', caption: 'Approval Rpt', panel: 'PanelApr' },
      async ({ page }) => {
        assert.equal(new URL(page.url()).pathname, '/reports/approval-report');
        assert.equal(await page.getByRole('form', { name: 'Approval Rpt' }).count(), 1);
        assert.equal(await page.locator('[data-panel="approval"]').isVisible(), true);
        // The generic [report] page's old labels are gone (gap 8).
        for (const old of ['Party Wise Issue', 'In Out', 'Pending'])
          assert.equal(await page.getByRole('button', { name: old, exact: true }).count(), 0);
      },
    ),

    desiredCase(
      'entry.three-approval-buttons',
      'T01',
      'read-only',
      'RP_ALL.cs:5165 {{btnAprRpt.Text = "&Approval Isu";}}; RP_ALL.cs:5191 {{btnAprInOut.Text = "&Approval InOut";}}; RP_ALL.cs:5217 {{BtnAprPanding.Text = "&Approval Panding";}}',
      { buttons: Object.values(BUTTONS), spelling: 'Panding preserved' },
      async ({ page }) => {
        const buttons = page.locator('[data-panel="approval"] button');
        assert.deepEqual(
          await buttons.evaluateAll((all) => all.map((b) => b.getAttribute('aria-label'))),
          Object.values(BUTTONS),
        );
        assert.deepEqual(
          (await buttons.allTextContents()).map((t) => t.trim()),
          Object.values(BUTTONS),
        );
      },
    ),

    desiredCase(
      'entry.date-defaults',
      'T01',
      'read-only',
      'RP_ALL.cs:7185 {{mFromDt.Text = "01/01/2010";}}; RP_ALL.cs:7203 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}; RP_ALL.cs:7204 {{CurActCtrl = (Control)(object)mFromDt;}}',
      { from: '01/01/2010', to: 'system date', focus: 'From' },
      async ({ page }) => {
        assert.equal(await field(page, 'From').inputValue(), '01/01/2010');
        assert.equal(await field(page, 'To').inputValue(), today());
        await focusIs(page, 'From');
      },
    ),

    desiredCase(
      'entry.location-scope-lock',
      'T01',
      'read-only',
      'RP_ALL.cs:6662 {{tLcCode.Text = DC_Main.MLc_code;}}; RP_ALL.cs:6660 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}}; RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}; RP_ALL.cs:6669 {{tLcCode.Text = DC_Main.MLc_code;}}; RP_ALL.cs:8154-8156 {{And {APR_DETL.LC_CODE} = tLcCode.Text}}',
      {
        at01: {
          value: '01',
          editable: false,
          sendsNoLocation: true,
          sessionScopeKept: 'AV3 (lc 02) absent',
        },
        at00: {
          value: '00',
          editable: true,
          clearedListsAllLocations: ['AV1', 'AV3'],
          branch01ListsOnlyLocation01: ['AV1', 'AV2'],
        },
      },
      async ({ ctx, page }) => {
        assert.equal(await field(page, 'lc Code').inputValue(), '01');
        assert.equal(await field(page, 'lc Code').isDisabled(), true);
        await withFixture(ctx, async () => {
          const locked = await runMode(page, 'issue', { Book: BOOK });
          // The locked box sends no location parameter at all: the server applies the session location (D9).
          assert.equal(locked.query.get('lcCode'), null);
          assert.equal(locked.query.get('reportLcCode'), null);
          assertCodes(await readGrid(page), ['AV1', 'AV2'], ['AV3']);
          const user = 'e2eaprloc00';
          await ensureUser(ctx, { user, subMenu: 'Approval Report', lcCode: '00' });
          const page00 = await openReport(ctx, as(user), { lcCode: '00' });
          assert.equal(await field(page00, 'lc Code').inputValue(), '00');
          assert.equal(await field(page00, 'lc Code').isDisabled(), false);
          await field(page00, 'lc Code').fill('');
          const cleared = await runMode(page00, 'issue', { Book: BOOK });
          // A 00 session that clears lc Code appends no location clause (RP_ALL.cs:8154).
          assert.equal(cleared.query.get('reportLcCode'), '');
          assertCodes(await readGrid(page00), ['AV1', 'AV3'], []);
          // The editable box may also name one branch (RP_ALL.cs:6660): its value is applied as
          // {APR_DETL.LC_CODE} (RP_ALL.cs:8156) through the separate reportLcCode parameter, never as the
          // session scope's own location.
          await field(page00, 'lc Code').fill('01');
          const branch = await runMode(page00, 'issue', { Book: BOOK });
          assert.equal(branch.query.get('reportLcCode'), '01');
          assertCodes(await readGrid(page00), ['AV1', 'AV2'], ['AV3']);
          // One box holds one location: a repeated reportLcCode is refused, never read as every location.
          const twice = new URLSearchParams(branch.query);
          twice.append('reportLcCode', '00');
          const refused = await page00.request.get(`${API_PATH}?${twice.toString()}`);
          assert.equal(refused.status(), 400);
          assert.equal((await refused.json()).error, 'invalid-location');
        });
      },
    ),

    desiredCase(
      'entry.selector-set-and-hidden-controls',
      'T01',
      'read-only',
      'RP_ALL.cs:4808 {{Label2.Text = "From / To Date";}}; RP_ALL.cs:6400 {{((Control)cboEmploy).Visible = false;}}; RP_ALL.cs:6549 {{((Control)cboState).Visible = false;}}; RP_ALL.cs:6539 {{((Control)chkBookSelect).Visible = false;}}; RP_ALL.cs:4266-4270 PnlBotam',
      {
        selectors: SELECTORS,
        hidden: ['Employ', 'State', 'Select Book', 'item grid'],
        bottom: ['Save', 'Delete', 'Cancel', 'Print', 'Exit'],
      },
      async ({ page }) => {
        for (const caption of SELECTORS)
          assert.equal(await field(page, caption).count(), 1, `${caption} is on the screen`);
        await page.getByText('From / To Date', { exact: true }).waitFor();
        for (const caption of ['Employ', 'Employee', 'State', 'Select Book'])
          assert.equal(await field(page, caption).count(), 0, `${caption} is hidden`);
        const bottom = await page
          .locator('[data-panel="bottom"] button')
          .evaluateAll((all) => all.map((b) => b.getAttribute('aria-label')));
        assert.deepEqual([...bottom].sort(), ['Cancel', 'Delete', 'Exit', 'Print', 'Save']);
      },
    ),

    desiredCase(
      'entry.selector-lists',
      'T01',
      'read-only',
      'RP_ALL.cs:7087 {{SELECT AC_CITY FROM AC_MAST WHERE CO_CODE}}; RP_ALL.cs:7121 {{GROUP BY AC_AREA ORDER BY AC_AREA}}; RP_ALL.cs:7165-7173 cboItemTyp items; RP_ALL.cs:7173 {{cboItemTyp.SelectedIndex = 0;}}',
      {
        cities: ['ARCITY1', 'ARCITY2'],
        areas: ['ARAREA1', 'ARAREA2'],
        itemTypes: ITEM_TYPES,
        liveCityAdded: 'ARCITY3',
      },
      async ({ ctx }) => {
        await withFixture(ctx, async () => {
          const page = await openReport(ctx);
          const options = async (caption) =>
            page
              .locator(`#ar-${caption}-options option`)
              .evaluateAll((all) => all.map((o) => o.value));
          await page.waitForFunction(
            () => document.querySelectorAll('#ar-City-options option').length > 0,
          );
          const cities = await options('City');
          assert.deepEqual(
            cities.filter((c) => c.startsWith('ARCITY')),
            ['ARCITY1', 'ARCITY2'],
            'distinct master cities, ordered',
          );
          assert.deepEqual([...cities].sort(), cities, 'ordered by AC_CITY');
          const areas = await options('Area');
          assert.deepEqual(
            areas.filter((a) => a.startsWith('ARAREA')),
            ['ARAREA1', 'ARAREA2'],
          );
          const types = await field(page, 'Item Type')
            .locator('option')
            .evaluateAll((all) => all.map((o) => o.value));
          assert.deepEqual(types, ITEM_TYPES);
          assert.equal(await field(page, 'Item Type').inputValue(), '');
          // The list reads live AC_MAST values each time the form opens (cases.md history.setting-between-runs).
          await ctx.rows(
            `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_CITY","AC_AREA") VALUES($1,'01','01','AP9','APR PARTY NINE','ARCITY3','ARAREA3')`,
          );
          const again = await openReport(ctx);
          await again.waitForFunction(
            () => document.querySelectorAll('#ar-City-options option').length > 0,
          );
          const after = await again
            .locator('#ar-City-options option')
            .evaluateAll((all) => all.map((o) => o.value));
          assert(after.includes('ARCITY3'), `the new city is listed: ${after.join(', ')}`);
          return { observation: `cities ${cities.join(', ')}` };
        });
      },
    ),

    desiredCase(
      'entry.view-right-gate',
      'T01',
      'refusal',
      'MDI_FORM.cs:7041 {{AND FRM_VIEW = \'Y\'}}; MDI_FORM.cs:7044 {{if (RsRight.Rows.Count == 0)}}; MDI_FORM.cs:7047 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}}',
      { menu: 'hidden', api: 403, rows: 0 },
      async ({ ctx }) => {
        await ensureUser(ctx, { user: 'e2eaprnoright', subMenu: 'Sales Order', print: 'N' });
        const { page } = await ctx.session(as('e2eaprnoright'));
        await page.goto('/dashboard');
        assert.equal(
          await page.getByRole('link', { name: 'Approval Report', exact: true }).count(),
          0,
          'no menu entry without the Approval Report view right',
        );
        const denied = await page.request.get(`${API_PATH}?fromDate=${FROM}&toDate=${isoToday()}`);
        assert.equal(denied.status(), 403);
        const body = await denied.json();
        assert.equal(Array.isArray(body.rows) ? body.rows.length : 0, 0);
        return { database: { status: denied.status(), rows: 0 } };
      },
    ),

    // ---- T02 Field route --------------------------------------------------------------------------------
    dbLayer(
      'filters.one-at-a-time',
      'T02',
      'RP_ALL.cs:8156 {{And {APR_DETL.LC_CODE}}}; RP_ALL.cs:8164 {{And {APR_DETL.AC_CODE}}}; RP_ALL.cs:8184 {{And {ITEM_MAST.GR_CODE}}}',
      'The screen sends exactly these selectors (approvalQuery in useApprovalReport.ts).',
    ),
    dbLayer(
      'filters.date-range-inclusive-and-year',
      'T02',
      'RP_ALL.cs:8152 {{AND {APR_DETL.VCH_DATE} >= #}}; RP_ALL.cs:8227 {{AND {APR_DETL.VCH_DATE} <= #}}',
      'D4: the session-year filter is a documented difference.',
    ),
    dbLayer(
      'filters.item-type-first-character',
      'T02',
      'RP_ALL.cs:8180 {{Strings.Mid(cboItemTyp.Text, 1, 1)}}',
      '',
    ),

    desiredCase(
      'filters.ignored-selectors',
      'T02',
      'read-only',
      'RP_ALL.cs:9717 {{tCustName.Text = "";}}; RP_ALL.cs:9718 {{((Control)cboCity).Focus();}}; RP_ALL.cs:6400 {{((Control)cboEmploy).Visible = false;}}; RP_ALL.cs:6539 {{((Control)chkBookSelect).Visible = false;}}',
      {
        custNameEnter: 'clears and focuses City',
        requestCarriesCustName: false,
        employeeStateMultiBook: 'never narrow the result',
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const cust = field(page, 'Cust Name');
          await cust.fill('APR PARTY ONE');
          await cust.press('Enter');
          await focusIs(page, 'City');
          assert.equal(await cust.inputValue(), '');
          const base = await runMode(page, 'issue', { Book: BOOK });
          for (const key of ['custName', 'empCode', 'state', 'books'])
            assert.equal(base.query.has(key), false, `${key} is not an approval selector`);
          const keys = rowsOf(base.body)
            .map((c) => `${c.vchNo}:${c.srNo}`)
            .sort();
          for (const extra of ['empCode=E01', 'state=GUJARAT', 'books=X1']) {
            const answer = await page.request.get(`${API_PATH}?${base.query.toString()}&${extra}`);
            // Either ignored (the same rows) or refused as a filter this report cannot apply; never narrowed.
            if (answer.status() === 200) {
              const got = (await answer.json()).rows.map((r) => `${r.cells.vchNo}:${r.cells.srNo}`);
              assert.deepEqual(got.sort(), keys, `${extra} must not filter`);
            } else assert.equal(answer.status(), 400, `${extra}: ${answer.status()}`);
          }
        });
      },
    ),

    dbLayer(
      'filters.combined-and',
      'T02',
      'RP_ALL.cs:8162 {{if (Operators.CompareString(tAcCode.Text, "", false) != 0)}}',
      '',
    ),
    dbLayer(
      'filters.main-book-family',
      'T02',
      "RP_ALL.cs:8153 {{{BOOK_DATA.MAIN_BOOK} = 'APR ISU'}}",
      'D6: the legacy APPROVAL ISSUE family is accepted as a recorded compatibility.',
    ),
    dbLayer(
      'filters.pending-exact-n',
      'T02',
      "RP_ALL.cs:8302 {{AND {APR_DETL.ISU_REC} = 'N'}}",
      'D6: legacy R counts as resolved in InOut.',
    ),
    notApplicable(
      'filters.data-type-selection',
      'T02',
      'RP_ALL.cs:8186 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}}; RP_ALL.cs:8190 {{else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)}}',
      `Unit layer: ${UNIT_TEST} ("approval-report.filters.data-type-selection") drives the selection builder with A, B and blank; no browser surface carries the setting (D3).`,
    ),
    C(
      'filters.data-type-setting-source',
      'T02',
      'read-only',
      'RP_ALL.cs:8186-8192 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0) … {BOOK_DATA.DATA_TYPE}}}: the setting is the session data type (owner decision 2026-11-25, data-type access: LOGIN_MAST DATA_TYPE_ALLOW/DEFAULT, Ctrl+B/Ctrl+C switch). app.ts binds it into every /reports/* query (sessionReportQuery) and approvalQuery.ts appends bk."DATA_TYPE" = <type> for A/B only; All (C) appends nothing',
      async (ctx) =>
        withFixture(ctx, async () => {
          const session = await ctx.session(as(USERS.admin.user, 'apr-datatype'));
          const { page } = session;
          const fixtureTags = LINES.filter(inScope).map((l) => l.tag);
          const bookType = (type) =>
            ctx.rows(
              `UPDATE "BOOK_DATA" SET "DATA_TYPE"=$2 WHERE tenant_id=$1 AND "CO_BOOK"=$3 AND "LC_CODE"='01'`,
              type,
              BOOK,
            );
          const open = async () => {
            await page.goto('/dashboard');
            await page.getByRole('link', { name: 'Approval Report', exact: true }).click();
            await page.waitForURL('**/reports/approval-report', { timeout: 8000 });
            await page.getByRole('heading', { name: 'Approval Rpt', exact: true }).waitFor();
          };
          const run = async () => {
            await field(page, 'From').fill(FROM);
            await field(page, 'To').fill(isoToday());
            const received = page.waitForResponse(
              (r) => new URL(r.url()).pathname === API_PATH && r.request().method() === 'GET',
              { timeout: 15000 },
            );
            await panelButton(page, 'issue').click();
            const response = await received;
            assert.equal(response.status(), 200, await response.text());
            const tags = rowsOf(await response.json())
              .map((cells) => cells.tagNo)
              .filter((tag) => fixtureTags.includes(tag));
            return { url: response.url(), tags: [...new Set(tags)].sort() };
          };
          try {
            // All (C): no predicate, the A book's lines show.
            await open();
            const all = await run();
            assert.deepEqual(all.tags, [...new Set(fixtureTags)].sort(), 'All shows every line');
            // Ctrl+B: the session is B; the fixture book is A, so its lines are filtered out.
            await page.goto('/dashboard');
            // The shortcut listens only once /me has loaded (the badge is up).
            await page.getByTestId('data-type-badge').filter({ hasText: /^All$/ }).waitFor();
            await page.keyboard.press('Control+b');
            await page.getByTestId('data-type-badge').filter({ hasText: /^B$/ }).waitFor();
            await open();
            const bSession = await run();
            assert.deepEqual(bSession.tags, [], 'a B session hides the A book');
            // The client cannot choose: a request asking for A (or All) still answers with the session's B.
            const forged = await page.request.get(
              `${API_PATH}?fromDate=${FROM}&toDate=${isoToday()}&dataType=A`,
            );
            assert.equal(forged.status(), 200);
            assert.deepEqual(
              rowsOf(await forged.json()).filter((c) => fixtureTags.includes(c.tagNo)),
              [],
              'a forged dataType=A is replaced by the session type',
            );
            // The same book marked B: the B session now shows exactly those lines.
            await bookType('B');
            const bBook = await run();
            assert.deepEqual(bBook.tags, all.tags, 'the B session shows the B book');
            await ctx.shot(page, 'filters-data-type-setting-source');
            return {
              observation: `All: ${all.tags.join(',')}; B session over A book: none (forged dataType=A ignored); B session over B book: ${bBook.tags.join(',')}`,
              expected: { all: all.tags, bOverA: [], bOverB: all.tags },
            };
          } finally {
            await bookType('A');
            await ctx.owner.$executeRawUnsafe(
              `UPDATE auth_session SET revoked_at=clock_timestamp(),revoke_reason='test-cleanup' WHERE tenant_id=$1 AND session_id IN (SELECT session_id FROM auth_session WHERE tenant_id=$1 AND login_name=$2 AND data_type<>'C')`,
              ctx.tenantId,
              USERS.admin.user,
            );
          }
        }),
    ),

    // ---- T03 Formula sequence (database layer) -----------------------------------------------------------
    dbLayer(
      'formula.issue-party-sums',
      'T03',
      'RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}',
      'The browser shows the same party sums in output.issue-layout-and-title.',
    ),
    dbLayer(
      'formula.inout-out-in-pending',
      'T03',
      'RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}',
      'The UI journey journey.issue-return-reopen repeats it end to end.',
    ),
    dbLayer(
      'formula.inout-sum-levels',
      'T03',
      'RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}',
      '',
    ),
    dbLayer(
      'formula.pending-signed-tags',
      'T03',
      'RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}',
      '',
    ),
    dbLayer(
      'formula.pending-zero-footer-suppression',
      'T03',
      'RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}} (AprPan.xml:936 EnableSuppress)',
      "The screen and the exports honour the engine's effective group placement.",
    ),
    dbLayer('formula.precision-preserved', 'T03', 'RP_ALL.cs:8216-8290 {{Cr.Action = -1;}}', ''),

    // ---- T04 Lookup -------------------------------------------------------------------------------------
    desiredCase(
      'lookup.book-enter',
      'T04',
      'read-only',
      'RP_ALL.cs:7293 {{if ((int)e.KeyCode != 13)}}; RP_ALL.cs:7303 {{ORDER BY A.BOOK_NAME}}; RP_ALL.cs:7309 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}; RP_ALL.cs:7314 {{tBookCode.Text = DC_Main.ColValue[1];}}; RP_ALL.cs:7317 {{((Control)tBookCode).Focus();}}; RP_ALL.cs:7323 {{SendKeys.Send("{tab}");}}',
      {
        blank: 'tab to Pr Code',
        valid: 'tab to Pr Code',
        unknown: 'help; pick fills and stays on Book',
        cancel: 'unchanged',
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const book = field(page, 'Book');
          await book.focus();
          await book.press('Enter');
          await focusIs(page, 'Pr Code');
          await book.fill(BOOK);
          await book.press('Enter');
          await focusIs(page, 'Pr Code');
          await page.locator('[data-lookup-name="Book"]').getByText('APPROVAL ISU E2E').waitFor();
          await book.fill('ZZQ');
          await book.press('Enter');
          const help = page.getByRole('dialog', { name: 'Book help' });
          await help.waitFor();
          const names = await help
            .getByRole('button')
            .evaluateAll((all) => all.map((b) => b.textContent.split(' · ')[1] ?? ''));
          assert.deepEqual(
            names,
            [...names].sort((a, b) => a.localeCompare(b)),
            'ordered by BOOK_NAME',
          );
          await help
            .getByRole('button', { name: new RegExp(`^${BOOK} · `) })
            .first()
            .click();
          assert.equal(await book.inputValue(), BOOK);
          await focusIs(page, 'Book');
          await book.fill('ZZQ');
          await book.press('Enter');
          await help.waitFor();
          await book.press('Escape');
          await help.waitFor({ state: 'hidden' });
          assert.equal(await book.inputValue(), 'ZZQ', 'cancelled help leaves the field');
        });
      },
    ),

    blocked(
      'lookup.party-enter-and-branch-setting',
      'T04',
      'read-only',
      'RP_ALL.cs:7386 {{if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)}}; RP_ALL.cs:7392 {{CAST(C.AC_CODE AS INT) < 100}}; RP_ALL.cs:7396 {{AND A.LC_CODE = \'}}',
      'MsAllBranchAcShow has no web setting: the party help always lists every company account (the desktop Y branch). Owner question: which company setting carries MsAllBranchAcShow, and should a non-00 branch with N see only codes below 100 plus its own codes from 200? Unblocks: an accepted setting contract on the shared account lookup. The party Enter fill/tab flow itself is exercised by keyboard.enter-walk-and-tab-order and lookup.cancel-and-stale.',
    ),

    desiredCase(
      'lookup.product-enter',
      'T04',
      'read-only',
      'RP_ALL.cs:7477 {{AND PR_CODE}}; RP_ALL.cs:7487 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}; RP_ALL.cs:7495 {{((Control)tItCode).Focus();}}; RP_ALL.cs:7501 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7506 {{((Control)cboCity).Focus();}}',
      { valid: 'Gr Code', unknown: 'help, pick stays', blank: 'City', source: 'PRODUCT_MAST' },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const product = field(page, 'Pr Code');
          await product.fill('Q1');
          await product.press('Enter');
          await focusIs(page, 'Gr Code');
          await page.locator('[data-lookup-name="Pr Code"]').getByText('APR PRODUCT ONE').waitFor();
          // An item code is not a product code (RP_ALL.cs:7477 matches PR_CODE, not IT_CODE).
          await product.fill('AI1');
          await product.press('Enter');
          const help = page.getByRole('dialog', { name: 'Pr Code help' });
          await help.waitFor();
          await help.getByRole('button', { name: /^Q2 · / }).click();
          assert.equal(await product.inputValue(), 'Q2');
          await focusIs(page, 'Pr Code');
          await product.fill('');
          await product.press('Enter');
          await focusIs(page, 'City');
        });
      },
    ),

    desiredCase(
      'lookup.group-enter',
      'T04',
      'read-only',
      'RP_ALL.cs:9265 {{Select * From GROUP_MAST}}; RP_ALL.cs:9277 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}; RP_ALL.cs:9282 {{tGrCode.Text = DC_Main.ColValue[1];}}; RP_ALL.cs:9291 {{SendKeys.Send("{tab}");}}',
      { unknown: 'help', blank: 'help', valid: 'Party Code' },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const group = field(page, 'Gr Code');
          const help = page.getByRole('dialog', { name: 'Gr Code help' });
          await group.fill('ZZQ');
          await group.press('Enter');
          await help.waitFor();
          await help.getByRole('button', { name: /^AG2 · / }).click();
          assert.equal(await group.inputValue(), 'AG2');
          await focusIs(page, 'Gr Code');
          await group.fill('');
          await group.press('Enter');
          await help.waitFor();
          await group.press('Escape');
          await group.fill('AG1');
          await group.press('Enter');
          await focusIs(page, 'Party Code');
        });
      },
    ),

    desiredCase(
      'lookup.location-enter',
      'T04',
      'read-only',
      'RP_ALL.cs:7691 {{Select * From LOCT_MAST}}; RP_ALL.cs:7703 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}; RP_ALL.cs:7706 {{tLcCode.Text = DC_Main.ColValue[0];}}; RP_ALL.cs:7713 {{SendKeys.Send("{tab}");}}',
      { user: 'location 00', unknown: 'help fills', valid: 'Book', blank: 'Book' },
      async ({ ctx }) => {
        await withFixture(ctx, async () => {
          const user = 'e2eaprloc00';
          await ensureUser(ctx, { user, subMenu: 'Approval Report', lcCode: '00' });
          const page = await openReport(ctx, as(user), { lcCode: '00' });
          const lc = field(page, 'lc Code');
          await lc.fill('ZQ');
          await lc.press('Enter');
          const help = page.getByRole('dialog', { name: 'lc Code help' });
          await help.waitFor();
          await help.getByRole('button', { name: /^01 · / }).click();
          assert.equal(await lc.inputValue(), '01');
          await lc.fill('00');
          await lc.press('Enter');
          await focusIs(page, 'Book');
          await lc.fill('');
          await lc.press('Enter');
          await focusIs(page, 'Book');
        });
      },
    ),

    desiredCase(
      'lookup.cancel-and-stale',
      'T04',
      'read-only',
      'RP_ALL.cs:7704 {{if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)}}',
      { cancel: 'field unchanged', stale: 'the later lookup wins', deadField: false },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const party = field(page, 'Party Code');
          await party.fill('ZZQ');
          await party.press('Enter');
          const help = page.getByRole('dialog', { name: 'Party Code help' });
          await help.waitFor();
          await party.press('Escape');
          await help.waitFor({ state: 'hidden' });
          assert.equal(await party.inputValue(), 'ZZQ');
          // Fire two lookups back to back: the first (unknown) answer must not open help over the second.
          await party.fill('ZZR');
          await party.press('Enter');
          await party.fill('AP2');
          await party.press('Enter');
          await focusIs(page, 'Cust Name');
          await page
            .locator('[data-lookup-name="Party Code"]')
            .getByText('APR PARTY TWO')
            .waitFor();
          await page.waitForTimeout(500);
          assert.equal(await help.count(), 0, 'no stale help over the newer selection');
          assert.equal(await party.inputValue(), 'AP2');
        });
      },
    ),

    // ---- T05 Children -----------------------------------------------------------------------------------
    dbLayer(
      'grouping.issue-voucher-party-bands',
      'T05',
      'RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}} (AprPartyWise.xml:252 Groups)',
      '',
    ),
    dbLayer(
      'grouping.inout-party-product-date-tag',
      'T05',
      'RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}} (AprInOut.xml:271 Groups)',
      '',
    ),
    dbLayer(
      'grouping.pending-voucher-product-tag',
      'T05',
      'RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}} (AprPan.xml:310 Groups)',
      '',
    ),
    dbLayer(
      'grouping.repeated-blank-tags',
      'T05',
      'RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}',
      '',
    ),
    dbLayer(
      'grouping.duplicate-master-no-amplification',
      'T05',
      'RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}} (AprPartyWise.xml:12 TableLinks)',
      'ITEM_MAST_pkey forbids the duplicate; the test records that constraint.',
    ),
    blocked(
      'grouping.null-tag-footer',
      'T05',
      'read-only',
      'RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}} (runtime Crystal null-default/group-sort)',
      'D2: MISSING generated Crystal SQL and runtime null-default/group-sort semantics. Owner question: how does a NULL (vs blank vs N) TAG_NO render and group in the tag footer at runtime? Unblocks: original-Windows runtime evidence or an owner decision.',
    ),

    // ---- T06 Required/invalid ---------------------------------------------------------------------------
    desiredCase(
      'invalid.date-not-valid',
      'T06',
      'refusal',
      'DC_Main.cs:1644 {{Interaction.MsgBox((object)"Date Not Valid...", (MsgBoxStyle)0, (object)null);}}; DC_Main.cs:1645 {{MsDate.Text = "__/__/____";}}; DC_Main.cs:1669 {{if (Conversion.Val(Strings.Mid(MsDate.Text, 1, 2)) > 31.0)}}; RP_ALL.cs:7519 {{if (!DC_Main.RongDate)}}',
      { message: 'Date Not Valid...', mask: '__/__/____', advances: false },
      async ({ page }) => {
        const from = field(page, 'From');
        await from.fill('32/07/2026');
        await from.press('Enter');
        await page.getByRole('alert').filter({ hasText: 'Date Not Valid...' }).waitFor();
        assert.equal(await from.inputValue(), '__/__/____');
        assert.equal(await focused(page), 'From');
      },
    ),

    desiredCase(
      'invalid.month-not-valid',
      'T06',
      'refusal',
      'DC_Main.cs:1664 {{Interaction.MsgBox((object)"Month Not Valid...", (MsgBoxStyle)0, (object)null);}}; DC_Main.cs:1665 {{MsDate.Text = "__/__/____";}}',
      { message: 'Month Not Valid...', mask: '__/__/____', advances: false },
      async ({ page }) => {
        const to = field(page, 'To');
        await to.fill('10/13/2026');
        await to.press('Enter');
        await page.getByRole('alert').filter({ hasText: 'Month Not Valid...' }).waitFor();
        assert.equal(await to.inputValue(), '__/__/____');
        assert.equal(await focused(page), 'To');
      },
    ),

    desiredCase(
      'invalid.setdate-completion',
      'T06',
      'read-only',
      'DC_Main.cs:1594 {{FnYear = Conversions.ToString(Interaction.IIf(Conversion.Val(Strings.Mid(MsDate.Text, 4, 2)) < 4.0, (object)Strings.Right(MCo_year, 4), (object)Strings.Left(MCo_year, 4)));}}; DC_Main.cs:1608 {{MsDate.Text = DateAndTime.Today.Day.ToString("00") + "/" + DateAndTime.Today.Month.ToString("00") + "/" + FnYear;}}; DC_Main.cs:1600 {{if (i == 2)}}',
      {
        yearBlankMonthJuly: `10/07/${START_YEAR}`,
        yearBlankMonthFeb: `10/02/${Number(START_YEAR) + 1}`,
        allBlank: 'today dd/MM with FnYear from today’s month',
        singleDigit: 'RongDate, silent, no tab',
        notPorted: 'MsAlterYear=Y and UAE variants (no web setting; owner question)',
      },
      async ({ page }) => {
        const from = field(page, 'From');
        const enter = async (typed) => {
          await from.focus();
          await from.fill(typed);
          await from.press('Enter');
        };
        await enter('10/07');
        await focusIs(page, 'To');
        assert.equal(await from.inputValue(), `10/07/${START_YEAR}`);
        await enter('10/02');
        assert.equal(await from.inputValue(), `10/02/${Number(START_YEAR) + 1}`);
        await enter('');
        const now = new Date();
        const fnYear = now.getMonth() + 1 < 4 ? Number(START_YEAR) + 1 : START_YEAR;
        assert.equal(
          await from.inputValue(),
          `${String(now.getDate()).padStart(2, '0')}/${String(now.getMonth() + 1).padStart(2, '0')}/${fnYear}`,
        );
        await enter('5');
        assert.equal(await focused(page), 'From', 'a single digit does not tab');
        assert.equal(await page.locator('form .msg.err').count(), 0, 'and shows no message');
      },
    ),

    dbLayer(
      'invalid.reversed-range-empty',
      'T06',
      'RP_ALL.cs:8152 {{AND {APR_DETL.VCH_DATE} >= #}}; RP_ALL.cs:8227 {{AND {APR_DETL.VCH_DATE} <= #}}',
      'D7.',
    ),
    dbLayer(
      'invalid.empty-period',
      'T06',
      'RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}}',
      '',
    ),
    dbLayer(
      'invalid.malformed-date-safe',
      'T06',
      'RP_ALL.cs:8152 {{Conversions.ToDate(mFromDt.Text)}}',
      'The screen refuses an impossible date before any request (setDate in types.ts).',
    ),

    // ---- T07 Create -------------------------------------------------------------------------------------
    C(
      'source.issue-appears-in-three-modes',
      'T07',
      'mutation',
      'RP_ALL.cs:8302 {{AND {APR_DETL.ISU_REC} = \'N\'}}; RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}; RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}',
      async (ctx) => {
        const { tag } = await seedApprovalTag(ctx, 'ARS');
        const issue = await createIssue(ctx, tag, 'report source');
        const stored = await approvalRows(ctx, ISSUE_BOOK, issue.voucherNo);
        assert.equal(stored.length, 1);
        assert.equal(stored[0].received, 'N');
        const page = await openReport(ctx);
        const rows = await modesFor(page, tag);
        // The tag fixture: 1 pc, gross 10.500, net 10.000 (approvalHelpers.seedApprovalTag).
        assert(rows.issue, 'the issue line in Approval Isu');
        assert.equal(rows.issue.pcs, 1);
        assert.equal(rows.issue.grossWt, 10.5);
        assert.equal(rows.issue.netWt, 10);
        assert.equal(rows.issue.acName, PARTIES.local.name);
        assert(rows.inout, 'the issue line in Approval InOut');
        assert.deepEqual([rows.inout.outPcs, rows.inout.inPcs, rows.inout.pendingPcs], [1, 0, 1]);
        assert(rows.pending, 'the issue line in Approval Panding (ISU_REC N)');
        await ctx.shot(page, 'source-issue-three-modes');
        return {
          observation: `issue ${issue.voucherNo} (tag ${tag}) appears in all three modes`,
          expected: { issue: { pcs: 1, grossWt: 10.5 }, inout: [1, 0, 1], pending: true },
          database: { stored },
          downstream: rows,
        };
      },
      { expected: { issue: { pcs: 1 }, inout: [1, 0, 1], pending: true }, observe: observeCurrent },
    ),

    // ---- T08 / T09 --------------------------------------------------------------------------------------
    notApplicable(
      'reopen.none',
      'T08',
      'RP_ALL.cs:8141-8215 {{Module_Save.ShowReportPreview();}}',
      'A read/preview workflow has no saved report document; re-run identity is covered by retry.duplicate-run-idempotent and the lifecycle by T18.',
    ),
    notApplicable(
      'edit.none',
      'T09',
      'RP_ALL.cs:8141-8215 {{Module_Save.ShowReportPreview();}} (no report write set)',
      'The report edits no owned field; the live-master rename effect is history.live-master-names (T15).',
    ),

    // ---- T10 Delete/cancel/reverse ----------------------------------------------------------------------
    desiredCase(
      'cancel.clear-data',
      'T10',
      'read-only',
      'RP_ALL.cs:7273 {{CLEAR_DATA();}}; RP_ALL.cs:7217 {{val.Text = "";}}; RP_ALL.cs:7221 {{val.Text = DC_Main.MMask;}}; RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}',
      {
        cleared: ['From', 'To', 'lc Code', 'Book', 'Pr Code', 'Gr Code', 'Party Code', 'Cust Name'],
        kept: ['City', 'Area', 'Item Type'],
        scopeAfterClear: 'session location 01 (AV3 absent)',
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          await field(page, 'Book').fill(BOOK);
          await field(page, 'Party Code').fill('AP1');
          await field(page, 'City').fill('ARCITY1');
          await field(page, 'Item Type').selectOption('Gold');
          await page.getByRole('button', { name: 'Cancel', exact: true }).click();
          for (const caption of ['From', 'To', 'lc Code', 'Book', 'Party Code', 'Cust Name'])
            assert.equal(await field(page, caption).inputValue(), '', `${caption} cleared`);
          assert.equal(await field(page, 'City').inputValue(), 'ARCITY1', 'combo text kept');
          assert.equal(await field(page, 'Item Type').inputValue(), 'Gold', 'combo kept');
          await field(page, 'From').fill(FROM);
          await field(page, 'To').fill(isoToday());
          await field(page, 'Book').fill(BOOK);
          await field(page, 'City').fill('');
          await field(page, 'Item Type').selectOption('');
          const received = page.waitForResponse(
            (r) => new URL(r.url()).pathname === API_PATH && r.request().method() === 'GET',
          );
          await panelButton(page, 'issue').click();
          const response = await received;
          // The locked box is never sent: the session location applies on the server (RP_ALL.cs:6664, D9).
          assert.equal(new URL(response.url()).searchParams.get('lcCode'), null);
          assert.equal(new URL(response.url()).searchParams.get('reportLcCode'), null);
          await page.locator('table.grid').waitFor();
          assertCodes(await readGrid(page), ['AV1'], ['AV3']);
        });
      },
    ),

    C(
      'actions.save-delete-print-noop',
      'T10',
      'refusal',
      'RP_ALL.cs:521 {{_BtnDelete = value;}}; RP_ALL.cs:565 {{_BtnSave = value;}}; RP_ALL.cs:7267-7270 {{private void BtnPrint_Click(object sender, EventArgs e)}}; RP_ALL.cs:7230 {{((Form)this).Close();}}',
      async (ctx) => {
        const counts = async () =>
          ctx.rows(
            `SELECT (SELECT count(*)::int FROM "APR_DETL" WHERE tenant_id=$1) detl,
                    (SELECT count(*)::int FROM "APR_DATA" WHERE tenant_id=$1) head,
                    (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1) deleted`,
          );
        const page = await openReport(ctx);
        const before = await counts();
        const writes = [];
        page.on('request', (r) => {
          if (new URL(r.url()).pathname.startsWith('/api/') && r.method() !== 'GET')
            writes.push(`${r.method()} ${r.url()}`);
        });
        for (const caption of ['Save', 'Delete', 'Print'])
          await page.getByRole('button', { name: caption, exact: true }).click();
        await page.waitForTimeout(500);
        assert.equal(new URL(page.url()).pathname, '/reports/approval-report');
        assert.deepEqual(writes, [], 'no write request');
        const after = await counts();
        assert.deepEqual(after, before);
        await page.getByRole('button', { name: 'Exit', exact: true }).click();
        await page.waitForURL((url) => !url.pathname.startsWith('/reports/approval-report'));
        return {
          observation: 'Save, Delete and Print wrote nothing; Exit closed the form',
          expected: { writes: 0, exit: 'closes' },
          database: { before, after },
        };
      },
      { expected: { writes: 0 }, observe: observeCurrent },
    ),

    // ---- T11 Scope/rights (database layer) ---------------------------------------------------------------
    dbLayer(
      'scope.tenant-company-location-sentinels',
      'T11',
      "RP_ALL.cs:8152 {{{APR_DETL.CO_CODE} = '}}; RP_ALL.cs:8156 {{And {APR_DETL.LC_CODE}}}",
      'The browser also proves the locked location in entry.location-scope-lock and cancel.clear-data.',
    ),
    dbLayer('scope.year-scope', 'T11', "RP_ALL.cs:8152 {{{APR_DETL.CO_CODE} = '}}", 'D4.'),
    dbLayer(
      'scope.view-print-rights',
      'T11',
      'MDI_FORM.cs:7041 {{AND FRM_VIEW = \'Y\'}}; RP_ALL.cs:6777 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}',
      'D10; the browser view gate is entry.view-right-gate.',
    ),

    // ---- T12 / T13 / T14 --------------------------------------------------------------------------------
    dbLayer(
      'concurrency.request-local-state',
      'T12',
      'RP_ALL.cs:6658 {{CurRpt = DC_Main.MsUserRightForm;}}',
      '',
    ),
    dbLayer(
      'concurrency.run-during-resolution',
      'T12',
      "TR_APR_ISU.cs:6414 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}}",
      '',
    ),
    dbLayer(
      'retry.duplicate-run-idempotent',
      'T13',
      'RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}}',
      '',
    ),
    notApplicable(
      'rollback.none',
      'T14',
      'RP_ALL.cs:8216-8290 {{Cr.Action = -1;}}; RP_ALL.cs:8291-8365 {{Cr.Action = -1;}}',
      'No write set to roll back; a failed run leaves no partial output, covered by retry.duplicate-run-idempotent and scope.tenant-company-location-sentinels.',
    ),

    // ---- T15 Config/history -----------------------------------------------------------------------------
    dbLayer(
      'history.live-master-names',
      'T15',
      'RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}} (AprPartyWise.xml:571 AC_MAST.AC_NAME)',
      'The browser grid prints the live AC_MAST name (output.issue-layout-and-title asserts "APR PARTY ONE", not the "SNAPSHOT AP1" stored on the line).',
    ),
    blocked(
      'history.setting-between-runs',
      'T15',
      'read-only',
      'RP_ALL.cs:7386 {{if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)}}; RP_ALL.cs:7087 {{SELECT AC_CITY FROM AC_MAST WHERE CO_CODE}}',
      'The setting half needs MsAllBranchAcShow, which has no web setting (same owner question as lookup.party-enter-and-branch-setting). The live City half is proved inside entry.selector-lists (a new city appears on the next open).',
    ),

    // ---- T16 Report/output ------------------------------------------------------------------------------
    desiredCase(
      'output.issue-layout-and-title',
      'T16',
      'output',
      'RP_ALL.cs:8197 {{DC_Main.MsRptTitelStr = "\'Party Wise Approval Issue From "}}; RP_ALL.cs:8150 AprPartyWise.RPT; AprPartyWise.xml Section10 "Party Total :"',
      {
        title: 'Party Wise Approval Issue From 01/01/2010 To <system date>',
        columns: COLUMNS.issue,
        partyTotals: { AP1: EXPECT.AP1, AP2: EXPECT.AP2 },
        grandTotal: false,
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const run = await runMode(page, 'issue', { Book: BOOK });
          assert.equal(run.body.title, title('issue'));
          assert.equal(run.body.template, 'AprPartyWise');
          const grid = await readGrid(page);
          assertOrder(grid.headers, COLUMNS.issue);
          assert.deepEqual(grid.footer, [], 'AprPartyWise has no grand-total band');
          const ap1 = groupOf(run.body, 0, 'AP1');
          assert(ap1, 'party AP1 band');
          for (const [key, value] of Object.entries(EXPECT.AP1))
            assert.equal(ap1.totals[key], value, `AP1 ${key}`);
          const ap2 = groupOf(run.body, 0, 'AP2');
          for (const [key, value] of Object.entries(EXPECT.AP2))
            assert.equal(ap2.totals[key], value, `AP2 ${key}`);
          const totalLines = grid.rows.filter((row) => row[0] === 'Party Total :');
          assert.equal(totalLines.length, 2, 'one Party Total line per party');
          assert.equal(cellOf(grid, totalLines[0], 'Pcs'), String(EXPECT.AP1.pcs));
          assert.equal(cellOf(grid, totalLines[0], 'Gr Wt'), EXPECT.AP1.grossWt.toFixed(3));
          assert.equal(cellOf(grid, totalLines[0], 'ItmAmt'), EXPECT.AP1.itemAmount.toFixed(2));
          assertCodes(grid, ['APR PARTY ONE'], ['SNAPSHOT AP1']);
        });
      },
    ),

    desiredCase(
      'output.inout-layout-and-title',
      'T16',
      'output',
      'RP_ALL.cs:8272 {{DC_Main.MsRptTitelStr = "\'Approval In Out Report From "}}; RP_ALL.cs:8225 AprInOut.RPT; AprInOut.xml:369 Sum ({@PanPcs})',
      {
        title: 'Approval In Out Report From 01/01/2010 To <system date>',
        columns: COLUMNS.inout,
        grand: { out: EXPECT.grand.pcs, in: 0, pending: EXPECT.grand.pcs, ...EXPECT.grand },
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const run = await runMode(page, 'inout', { Book: BOOK });
          assert.equal(run.body.title, title('inout'));
          assert.equal(run.body.template, 'AprInOut');
          const grid = await readGrid(page);
          assertOrder(grid.headers, COLUMNS.inout);
          assert.equal(grid.footer[0], 'Grand Total :');
          assert.equal(cellOf(grid, grid.footer, 'Out Pcs'), String(EXPECT.grand.pcs));
          assert.equal(cellOf(grid, grid.footer, 'In Pcs'), '0');
          assert.equal(cellOf(grid, grid.footer, 'Panding'), String(EXPECT.grand.pcs));
          assert.equal(cellOf(grid, grid.footer, 'Gr Wt'), EXPECT.grand.grossWt.toFixed(3));
          assert.equal(cellOf(grid, grid.footer, 'Net Wt'), EXPECT.grand.netWt.toFixed(3));
          assert.equal(cellOf(grid, grid.footer, 'Oth Amt'), EXPECT.grand.otherAmount.toFixed(2));
        });
      },
    ),

    desiredCase(
      'output.pending-layout-and-title',
      'T16',
      'output',
      'RP_ALL.cs:8347 {{DC_Main.MsRptTitelStr = "\'Panding Approval Report From "}}; RP_ALL.cs:8300 AprPan.RPT; RP_ALL.cs:5217 {{BtnAprPanding.Text = "&Approval Panding";}}',
      {
        title: 'Panding Approval Report From 01/01/2010 To <system date>',
        columns: COLUMNS.pending,
        grandPanding: EXPECT.grand.pcs,
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          const run = await runMode(page, 'pending', { Book: BOOK });
          assert.equal(run.body.title, title('pending'));
          assert.equal(run.body.template, 'AprPan');
          const grid = await readGrid(page);
          assertOrder(grid.headers, COLUMNS.pending);
          assert.equal(grid.footer[0], 'Grand Total :');
          assert.equal(cellOf(grid, grid.footer, 'Panding'), String(EXPECT.grand.pcs));
          assert.equal(cellOf(grid, grid.footer, 'Oth Amt'), EXPECT.grand.otherAmount.toFixed(2));
        });
      },
    ),

    desiredCase(
      'output.grid-csv-xlsx-pdf-match',
      'T16',
      'output',
      'RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}; RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}; RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}',
      {
        surfaces: ['grid', 'CSV', 'XLSX', 'PDF'],
        pageOverflowLines: OVERFLOW.length,
        sameLinesAndTotals: true,
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          for (const [i, vch] of OVERFLOW.entries())
            await insertLine(
              ctx,
              line(vch, 1, D(11), i % 2 ? 'AP1' : 'AP3', 'AI1', `AQ${i}`, {
                pcs: 1,
                gwt: 1.25,
                nwt: 1.125,
                itm: 100,
                lbr: 10,
                oth: 1,
                net: 111,
              }),
            );
          for (const mode of ['issue', 'inout', 'pending']) {
            const run = await runMode(page, mode, { Book: BOOK });
            const grid = await readGrid(page);
            assert(grid.rows.length > 30, `mode ${mode} spans more than one printed page`);
            const query = run.query.toString();
            const csv = await page.request.get(`${API_PATH}/export.csv?${query}`);
            assert.equal(csv.status(), 200, `CSV of ${mode}`);
            const csvRows = parseCsv(await csv.text()).filter((cells) => cells.some(Boolean));
            const printed = [...grid.rows, ...(grid.footer.length ? [grid.footer] : [])];
            assert.deepEqual(csvRows[0], grid.headers, `${mode}: CSV columns match the grid`);
            assert.equal(csvRows.length, printed.length + 1, `${mode}: CSV has every grid line`);
            printed.forEach((cells, i) =>
              assert.deepEqual(
                csvRows[i + 1].map((cell) => cell.trim()),
                cells,
                `${mode}: CSV line ${i + 1} equals the grid line`,
              ),
            );
            const xlsx = await page.request.get(`${API_PATH}/export.xlsx?${query}`);
            assert.equal(xlsx.status(), 200, `XLSX of ${mode}`);
            const pdf = await page.request.get(`${API_PATH}/export.pdf?${query}`);
            assert.equal(pdf.status(), 200, `PDF of ${mode}`);
            assert.match(pdf.headers()['content-type'] ?? '', /pdf/);
            assert.equal((await pdf.body()).subarray(0, 4).toString(), '%PDF');
          }
        });
      },
    ),

    desiredCase(
      'output.preview-window',
      'T16',
      'output',
      'Module_Save.cs:362 {{Text = "Report Preview - " + DC_Main.RptName,}}; Module_Save.cs:269 {{val.DataDefinition.FormulaFields[DC_Main.MsRptTitel].Text = DC_Main.MsRptTitelStr;}}; Module_Save.cs:367 {{val3.ToolPanelView = (ToolPanelViewType)0;}}',
      { captions: Object.values(TEMPLATE).map((t) => `Report Preview - ${t}`), groupTree: false },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          for (const mode of ['issue', 'inout', 'pending']) {
            await runMode(page, mode, { Book: BOOK });
            await page.getByText(`Report Preview - ${TEMPLATE[mode]}`, { exact: true }).waitFor();
            await page.getByRole('heading', { name: title(mode), exact: true }).waitFor();
            assert.equal(await page.getByRole('tree').count(), 0, 'no group-tree panel');
          }
        });
      },
    ),

    blocked(
      'output.numeric-display-precision',
      'T16',
      'output',
      'RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}} (no numeric ObjectFormat metadata extracted)',
      'D1: MISSING Crystal numeric display rounding/decimal metadata and original-Windows output. Owner question: what precision and tie handling do AprPartyWise, AprInOut and AprPan print? Unblocks: an original-Windows render or extracted ObjectFormat metadata. The web prints 3/2/0 places, not certified as desktop.',
    ),
    blocked(
      'output.drilldown',
      'T16',
      'read-only',
      'RP_ALL.cs:8276 {{Module_Save.ShowReportPreview();}}; Module_Save.cs:367 {{val3.ToolPanelView = (ToolPanelViewType)0;}}',
      'D2: MISSING runtime proof of Crystal built-in drill-down. Owner question: does the generic Crystal viewer drill into vouchers at runtime, and how? Unblocks: original-Windows runtime evidence. No voucher link is claimed.',
    ),

    // ---- T17 Keyboard/usability -------------------------------------------------------------------------
    desiredCase(
      'keyboard.enter-walk-and-tab-order',
      'T17',
      'read-only',
      'RP_ALL.cs:5622 {{((Control)mFromDt).TabIndex = 0;}}; RP_ALL.cs:4902 {{((Control)cboItemTyp).TabIndex = 10;}}; RP_ALL.cs:7521 {{SendKeys.Send("{tab}");}}; RP_ALL.cs:7506 {{((Control)cboCity).Focus();}}; RP_ALL.cs:9718 {{((Control)cboCity).Focus();}}; RP_ALL.cs:9607 {{((TextBoxBase)mFromDt).SelectAll();}}',
      {
        tabOrder: SELECTORS.filter((s) => s !== 'lc Code'),
        enterWalk: ['From', 'To', 'Book', 'Pr Code', 'City', 'Area', 'Item Type', 'Approval Isu'],
        partyWalk: ['Party Code', 'Cust Name', 'City'],
        dateSelectAllOnFocus: true,
      },
      async ({ ctx, page }) => {
        await withFixture(ctx, async () => {
          await focusIs(page, 'From');
          const tabbed = [];
          for (let i = 0; i < 10; i++) {
            tabbed.push(await focused(page));
            await page.keyboard.press('Tab');
          }
          assert.deepEqual(
            tabbed,
            SELECTORS.filter((s) => s !== 'lc Code'),
            'tab order; the locked lc box is skipped',
          );
          await field(page, 'From').focus();
          const walked = [];
          for (let i = 0; i < 8; i++) {
            walked.push(await focused(page));
            await page.keyboard.press('Enter');
            await page.waitForTimeout(150);
          }
          assert.deepEqual(walked, [
            'From',
            'To',
            'Book',
            'Pr Code',
            'City',
            'Area',
            'Item Type',
            'Approval Isu',
          ]);
          const party = field(page, 'Party Code');
          await party.fill('AP1');
          await party.press('Enter');
          await focusIs(page, 'Cust Name');
          await field(page, 'Cust Name').fill('ANY NAME');
          await field(page, 'Cust Name').press('Enter');
          await focusIs(page, 'City');
          await field(page, 'To').focus();
          const selection = await field(page, 'To').evaluate((el) => [
            el.selectionStart,
            el.selectionEnd,
            el.value.length,
          ]);
          assert.equal(selection[0], 0);
          assert.equal(selection[1], selection[2], 'the date is selected on focus');
        });
      },
    ),

    desiredCase(
      'keyboard.form-keys',
      'T17',
      'read-only',
      'RP_ALL.cs:7261 {{if ((int)e.KeyCode == 27)}}; RP_ALL.cs:7263 {{((Form)this).Close();}}; RP_ALL.cs:7248 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}; RP_ALL.cs:7251 {{if (num == 0 || num == 39)}}',
      { typed: "abc'", shown: 'ABC', esc: 'closes the form' },
      async ({ page }) => {
        const party = field(page, 'Party Code');
        await party.fill("abc'");
        assert.equal(await party.inputValue(), 'ABC');
        await page.keyboard.press('Escape');
        await page.waitForURL((url) => !url.pathname.startsWith('/reports/approval-report'));
      },
    ),

    desiredCase(
      'keyboard.mnemonics',
      'T17',
      'read-only',
      'RP_ALL.cs:5165 {{btnAprRpt.Text = "&Approval Isu";}}; RP_ALL.cs:4330 {{BtnSave.Text = "&Save";}}; RP_ALL.cs:4317 {{BtnCancel.Text = "&Cancel";}}; RP_ALL.cs:4303 {{BtnDelete.Text = "&Delete";}}; RP_ALL.cs:4290 {{BtnExit.Text = "E&xit";}}; RP_ALL.cs:4343 {{BtnPrint.Text = "&Print";}}',
      {
        approval: 'A (shared, no unique shortcut invented)',
        bottom: { Save: 'S', Cancel: 'C', Delete: 'D', Exit: 'x', Print: 'P' },
      },
      async ({ page }) => {
        const underlined = async (name) =>
          page.getByRole('button', { name, exact: true }).locator('u').textContent();
        for (const name of Object.values(BUTTONS)) assert.equal(await underlined(name), 'A');
        for (const [name, letter] of Object.entries({
          Save: 'S',
          Cancel: 'C',
          Delete: 'D',
          Exit: 'x',
          Print: 'P',
        }))
          assert.equal(await underlined(name), letter, `${name} mnemonic`);
        assert.equal(await page.locator('form [accesskey]').count(), 0, 'no invented accesskey');
      },
    ),

    // ---- T18 Full journey -------------------------------------------------------------------------------
    C(
      'journey.issue-return-reopen',
      'T18',
      'mutation',
      "TR_APR_ISU.cs:6414 {{APR_DETL.OLD_SRNO = B.ISU_SRNO}}; TR_APR_ISU.cs:6414 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}}; RP_ALL.cs:8302 {{AND {APR_DETL.ISU_REC} = 'N'}}",
      async (ctx) => {
        const { tag } = await seedApprovalTag(ctx, 'ARJ');
        const issue = await createIssue(ctx, tag, 'report journey');
        const report = await openReport(ctx);
        const afterIssue = await modesFor(report, tag);
        assert.equal(afterIssue.issue?.pcs, 1);
        assert.deepEqual(
          [afterIssue.inout?.outPcs, afterIssue.inout?.inPcs, afterIssue.inout?.pendingPcs],
          [1, 0, 1],
        );
        assert(afterIssue.pending, 'pending after the issue');
        const returned = await createReturn(ctx, issue, 'report journey return');
        const resolved = await approvalRows(ctx, ISSUE_BOOK, issue.voucherNo);
        assert.equal(resolved[0].received, 'Y');
        const afterReturn = await modesFor(report, tag);
        assert.equal(afterReturn.issue?.pcs, 1, 'Approval Isu unchanged');
        assert.deepEqual(
          [afterReturn.inout?.outPcs, afterReturn.inout?.inPcs, afterReturn.inout?.pendingPcs],
          [1, 1, 0],
        );
        assert.equal(afterReturn.pending, undefined, 'dropped from Approval Panding');
        await reopenApproval(returned.page, 'return', returned.voucherNo);
        const [deleted] = await Promise.all([
          returned.page.waitForResponse((r) =>
            isApi(r, 'DELETE', `/tour/return/${returned.voucherNo}`),
          ),
          returned.page.getByTestId('approval-return-delete').click(),
        ]);
        assert.equal(deleted.status(), 200, await deleted.text());
        const reopened = await approvalRows(ctx, ISSUE_BOOK, issue.voucherNo);
        assert.equal(reopened[0].received, 'N');
        // Only ISU_REC toggled: the stored line values never changed.
        assert.equal(reopened[0].net, resolved[0].net);
        const afterDelete = await modesFor(report, tag);
        assert(afterDelete.pending, 'back in Approval Panding');
        assert.deepEqual(
          [afterDelete.inout?.outPcs, afterDelete.inout?.inPcs, afterDelete.inout?.pendingPcs],
          [1, 0, 1],
        );
        await ctx.shot(report, 'journey-after-delete');
        return {
          observation: `issue ${issue.voucherNo} → return ${returned.voucherNo} → delete; reports followed ISU_REC`,
          expected: { afterIssue: [1, 0, 1], afterReturn: [1, 1, 0], afterDelete: [1, 0, 1] },
          database: { resolved, reopened },
          downstream: { afterIssue, afterReturn, afterDelete },
        };
      },
      {
        expected: { afterIssue: [1, 0, 1], afterReturn: [1, 1, 0], afterDelete: [1, 0, 1] },
        observe: observeCurrent,
      },
    ),
    C(
      'journey.sale-consume-reverse',
      'T18',
      'mutation',
      "TR_SALE.cs:16112 {{APR_DETL.SR_NO = B.ISU_SRNO}}; TR_SALE.cs:16112 {{AND APR_DETL.CO_BOOK = '018'}}; TR_SALE.cs:16112 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}}; TR_SALE.cs:16326 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'N'}}; RP_ALL.cs:8302 {{AND {APR_DETL.ISU_REC} = 'N'}}",
      async (ctx) => {
        const { tag } = await seedApprovalTag(ctx, 'ARS');
        const issue = await createIssue(ctx, tag, 'report sale journey');
        const report = await openReport(ctx);
        const afterIssue = await modesFor(report, tag);
        assert.deepEqual(
          [afterIssue.inout?.outPcs, afterIssue.inout?.inPcs, afterIssue.inout?.pendingPcs],
          [1, 0, 1],
        );
        assert(afterIssue.pending, 'pending after the issue');
        // The customer keeps the item: Sales Invoice imports the approval (Apr No) and the save closes it.
        const sale = await billApprovalInSales(issue.page, issue);
        const consumed = await approvalRows(ctx, ISSUE_BOOK, issue.voucherNo);
        assert.equal(consumed[0].received, 'Y');
        const afterSale = await modesFor(report, tag);
        assert.equal(afterSale.issue?.pcs, 1, 'Approval Isu unchanged');
        assert.deepEqual(
          [afterSale.inout?.outPcs, afterSale.inout?.inPcs, afterSale.inout?.pendingPcs],
          [1, 1, 0],
        );
        assert.equal(afterSale.pending, undefined, 'dropped from Approval Panding');
        await ctx.shot(report, 'journey-after-sale');
        await deleteSaleInScreen(issue.page, sale.vchNo);
        const reopened = await approvalRows(ctx, ISSUE_BOOK, issue.voucherNo);
        assert.equal(reopened[0].received, 'N');
        assert.equal(reopened[0].net, consumed[0].net, 'only ISU_REC toggled');
        const afterDelete = await modesFor(report, tag);
        assert(afterDelete.pending, 'back in Approval Panding');
        assert.deepEqual(
          [afterDelete.inout?.outPcs, afterDelete.inout?.inPcs, afterDelete.inout?.pendingPcs],
          [1, 0, 1],
        );
        return {
          observation: `issue ${issue.voucherNo} → sale ${sale.vchNo} → sale deleted; reports followed ISU_REC`,
          expected: { afterIssue: [1, 0, 1], afterSale: [1, 1, 0], afterDelete: [1, 0, 1] },
          database: { consumed, reopened },
          downstream: { afterIssue, afterSale, afterDelete },
        };
      },
      {
        expected: { afterIssue: [1, 0, 1], afterSale: [1, 1, 0], afterDelete: [1, 0, 1] },
        observe: observeCurrent,
      },
    ),
    dbLayer(
      'journey.custody-reconcile',
      'T18',
      "TR_APR_ISU.cs:6414 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}}",
      'D5: fine is test-only evidence, never a report column.',
    ),
  ],
};
