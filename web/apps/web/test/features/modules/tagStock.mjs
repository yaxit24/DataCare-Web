import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import { reopenApproval } from './approvalHelpers.mjs';
import {
  cancelTag,
  deleteCancel,
  deleteOpening,
  deleteReturn,
  deleteSale,
  issueApproval,
  openTags,
  returnTag,
  sellTag,
  today,
} from './inventoryFlows.mjs';

/**
 * Feature: Report → Tag Stock (desktop RP_TAG, MDI_FORM.cs:8891-8900; web /reports/tag-stock). WP-15.
 *
 * The expected values come from the desktop rule applied to the rows each case seeds, never from the report:
 * - A tag instance is in stock when sum(+id for '+', -id for '-') over its movements of the year dated up to To is
 *   positive (RP_TAG.cs:4187 HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0); Stock ignores From.
 * - In = BAR_DETL creation rows dated From..To (:4009); Out = the minus movements dated From..To (:4070); Mrp = Stock with
 *   ITM_MRP <> 0 (:4152); Apr = APR ISU rows with ISU_REC 'N' joined to BAR_DETL (:4227); All = the signed movement
 *   history (:4278), the date range ignored when a TagNo is typed (:4286).
 * - The footer sums Qty, Pcs, Grwt, NetWt, LbrAmt, OthAmt, PrCost and Mrp of the rows shown (:4916-4976) and follows the
 *   Search box; weights show with three decimals, amounts with none (:4942, :5257).
 * - Keys: Escape closes (:3865), Down/Up on a selector focuses the grid (:3871), Enter in a date runs the date mask
 *   ("Date Not Valid...", "Month Not Valid...", DC_Main.cs:1664-1672); each mode button runs its own query.
 *
 * The cases seed their tags as rows (BAR_DETL + MAIN_STOCK + APR_DETL, as a tag opening, sale, cancel, return and
 * approval issue would write them) and isolate them from every other module's tags with the Search box (TagNo
 * contains the case prefix). Journeys below operate the real voucher screens.
 */
const TENANT = 'feature-e2e';
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `tag-stock.${id}`,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence:
    kind === 'mutation'
      ? ['browser', 'expected', 'database', 'downstream']
      : kind === 'output'
        ? ['browser', 'expected', 'output']
        : kind === 'refusal'
          ? ['browser', 'expected', 'database']
          : ['browser', 'expected'],
  run,
  ...extra,
});
const notApplicable = (name, group, source, reason) => ({
  ...C(`${name}.not-applicable`, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});

const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const iso = (m, d) => `${startYear}-${String(m).padStart(2, '0')}-${String(d).padStart(2, '0')}`;
const ui = (isoDate) => isoDate.split('-').reverse().join('/');
const RUN = Date.now().toString(36).slice(-4).toUpperCase();
let caseNo = 0;
let idSeq = 0;
let mastersReady = false;

/** Seed B of orchestration/work/WP-15/cases.md: id = VCH_SRNO; pcs / gross / net / MRP / cost / labour / other. */
const TAGS = [
  ['1', 'TS1', 1, 5, 4.8, 30000, 25000, 500, 100, '7', 'C1', iso(4, 5)],
  ['2', 'TS1', 2, 3, 2.9, 20000, 16000, 300, 50, '8', 'C1', iso(4, 10)],
  ['3', 'TS1', 1, 4, 3.8, 25000, 20000, 400, 80, '7', 'C1', iso(4, 5)],
  ['4', 'TS1', 1, 1, 0.95, 8000, 6000, 100, 10, '7', 'C1', iso(4, 5)],
  ['5', 'TS1', 1, 2, 1.9, 12000, 9000, 200, 20, '7', 'C1', iso(4, 5)],
  ['6', 'TS1', 1, 6, 5.8, 40000, 33000, 600, 120, '7', 'C1', iso(4, 5)],
  ['7', 'TS2', 1, 10, 10, 0, 4000, 100, 0, '18', 'C2', iso(4, 5)],
].map(([n, it, pcs, gwt, nwt, mrp, cost, lbr, oth, size, ctr, stk]) => ({
  n,
  it,
  pcs,
  gwt,
  nwt,
  mrp,
  cost,
  lbr,
  oth,
  size,
  ctr,
  stk,
}));
/** [tag number, sign, date, voucher type, voucher no] after each tag's opening. */
const MOVES = [
  ['3', '-', iso(4, 20), 'SL', '0001'],
  ['5', '-', iso(4, 20), 'SL', '0002'],
  ['4', '-', iso(4, 25), 'TC', '0001'],
  ['5', '+', iso(5, 10), 'SR', '0001'],
  ['6', '-', iso(5, 15), 'AI', '0001'],
];

async function ensureMasters(ctx) {
  if (mastersReady) return;
  const x = (sql, ...p) => ctx.owner.$executeRawUnsafe(sql, TENANT, ...p);
  for (const [code, name, type, pr, gr] of [
    ['TS1', 'TS Ring', 'G', 'T1', 'T1'],
    ['TS2', 'TS Chain', 'S', 'T2', 'T2'],
  ]) {
    await x(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE")
       VALUES ($1,'01',$2,$3,$4,$5,$6) ON CONFLICT DO NOTHING`,
      code,
      name,
      type,
      pr,
      gr,
    );
    await x(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE","TRAD_TYPE","SALE_AC","PURC_AC","HSN_CODE")
       SELECT $1::text,'01',$2::text,$3::text,$4::text,'GO','SALES','PURCHASE','7113' WHERE NOT EXISTS
         (SELECT 1 FROM "GROUP_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "GR_CODE"=$2::text)`,
      gr,
      `TS Group ${gr}`,
      type,
    );
    await x(
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME")
       SELECT $1::text,'01',$2::text,$3::text WHERE NOT EXISTS
         (SELECT 1 FROM "PRODUCT_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "PR_CODE"=$2::text)`,
      pr,
      code === 'TS1' ? 'TS Rings' : 'TS Chains',
    );
  }
  mastersReady = true;
}

/** Seeds the seven tags of Seed B under a fresh prefix and returns { prefix, tags, moves } with the real tag numbers. */
async function seedB(ctx, { only } = {}) {
  await ensureMasters(ctx);
  caseNo += 1;
  const prefix = `T${RUN}${caseNo}`;
  const tags = TAGS.filter((t) => !only || only.includes(t.n)).map((t) => {
    idSeq += 1;
    return { ...t, tag: `${prefix}A${t.n}`, id: 920000000000 + caseNo * 1000 + idSeq };
  });
  const byN = Object.fromEntries(tags.map((t) => [t.n, t]));
  const movements = [
    ...tags.map((t) => ({
      t,
      sign: '+',
      date: t.stk,
      type: 'TO',
      book: 'TOP',
      vchNo: `0${t.n}000`,
    })),
    ...MOVES.filter(([n]) => byN[n]).map(([n, sign, date, type, vchNo]) => ({
      t: byN[n],
      sign,
      date,
      type,
      book: type,
      vchNo,
    })),
  ];
  for (const t of tags) {
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","STK_DATE","VCH_TYPE",
         "BOOK_NAME","IT_CODE","TAG_NO","DESIGN_NO","TBL_CODE","ITM_SIZE","ITM_PCS","ITM_GWT","ITM_NWT","LBR_AMT","OTH_AMT",
         "KR_COST","ITM_MRP","VCH_SRNO","EMP_ISU")
       VALUES ($1::text,'01','01',$2::text,'TOP','0000',$3::date,$4::text,'TO','TAG OPENING',$5::text,$6::text,$7::text,$8::text,
         $9::text,$10::numeric,$11::numeric,$12::numeric,$13::numeric,$14::numeric,$15::float8,$16::numeric,$17::float8,'N')`,
      TENANT,
      YEAR,
      t.stk,
      t.stk,
      t.it,
      t.tag,
      `D${t.n}`,
      t.ctr,
      t.size,
      t.pcs,
      t.gwt,
      t.nwt,
      t.lbr,
      t.oth,
      t.cost,
      t.mrp,
      t.id,
    );
  }
  for (const m of movements) {
    const t = m.t;
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","STK_DATE","VCH_TYPE",
         "BOOK_NAME","IT_CODE","TAG_NO","TBL_CODE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","LBR_AMT","OTH_AMT","ITM_MRP",
         "DESIGN_NO","ITM_SIZE","VCH_SRNO")
       VALUES ($1::text,'01','01',$2::text,$3::text,$4::text,$5::date,$6::text,$7::text,$8::text,$9::text,$10::text,$11::text,
         $12::text,$13::numeric,$14::numeric,$15::numeric,$16::numeric,$17::numeric,$18::numeric,$19::text,$20::text,$21::float8)`,
      TENANT,
      YEAR,
      m.book,
      m.vchNo,
      m.date,
      t.stk,
      m.type,
      m.type === 'AI' ? 'APR ISU' : m.book,
      t.it,
      t.tag,
      t.ctr,
      m.sign,
      t.pcs,
      t.gwt,
      t.nwt,
      t.lbr,
      t.oth,
      t.mrp,
      `D${t.n}`,
      t.size,
      t.id,
    );
  }
  const six = byN['6'];
  if (six)
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TYPE","BOOK_NAME",
         "AC_CODE","IT_CODE","TAG_NO","VCH_SRNO","ISU_REC","ITM_PCS","ITM_GWT","ITM_NWT","ITM_MRP")
       VALUES ($1::text,'01','01',$2::text,'AI','0001',$3::date,'AI','APR ISU','E2ELOC',$4::text,$5::text,$6::float8,'N',9,9.999,9.5,0)`,
      TENANT,
      YEAR,
      iso(5, 15),
      six.it,
      six.tag,
      six.id,
    );
  return { prefix, tags, byN, movements };
}

// ───────────── the desktop rule applied to the seeded movements (the oracle) ─────────────
const inStock = (seed, asOf) =>
  seed.tags.filter(
    (t) =>
      seed.movements
        .filter((m) => m.t === t && m.date <= asOf)
        .reduce((a, m) => a + (m.sign === '+' ? t.id : -t.id), 0) > 0,
  );
const sumOf = (rows, key) => rows.reduce((a, r) => a + r[key], 0);
const close = (a, b, msg) => assert.ok(Math.abs(a - b) < 1e-6, `${msg}: ${a} vs ${b}`);
const totalsOf = (rows) => ({
  qty: rows.length,
  pcs: sumOf(rows, 'pcs'),
  grossWt: sumOf(rows, 'gwt'),
  netWt: sumOf(rows, 'nwt'),
  mrp: sumOf(rows, 'mrp'),
  prCost: sumOf(rows, 'cost'),
  lbrAmt: sumOf(rows, 'lbr'),
  othAmt: sumOf(rows, 'oth'),
});

// ───────────── the screen ─────────────
const num = (text) => Number(String(text).replaceAll(',', '') || 0);
/**
 * The harness accepts every dialog. The desktop asks "Report With Other Detail Item Name..." on every Apr run
 * (RP_TAG.cs:4221), and "Yes" adds columns, so the screen's cases answer No unless a case asks for the columns.
 */
function answerDialogs(page, { otherItems = false } = {}) {
  page.removeAllListeners('dialog');
  const seen = [];
  page.on('dialog', async (dialog) => {
    seen.push(dialog.message());
    if (/^Report With Other Detail Item Name/.test(dialog.message()) && !otherItems)
      await dialog.dismiss();
    else await dialog.accept();
  });
  return seen;
}
async function openScreen(page, options) {
  const seen = answerDialogs(page, options);
  await page.goto('/reports/tag-stock');
  await page.getByRole('heading', { name: 'Tag Stock', exact: true }).waitFor();
  return seen;
}
const setDates = async (page, from, to) => {
  await page.getByLabel('From', { exact: true }).fill(ui(from));
  await page.getByLabel('To', { exact: true }).fill(ui(to));
};
async function runMode(page, label, tab) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => {
      const url = new URL(r.url());
      return (
        url.pathname === '/api/reports/tag-stock' && (!tab || url.searchParams.get('tab') === tab)
      );
    }),
    page.getByRole('button', { name: label, exact: true }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.getByTestId('tag-stock-grid').waitFor();
  return response;
}
const filterRows = async (page, text) => {
  await page.getByLabel('Search', { exact: true }).fill(text);
};
/** The visible grid as { heads, rows: [{header: text}] } and the footer as { colKey: number }. */
async function readGrid(page) {
  return page.getByTestId('tag-stock-grid').evaluate((grid) => {
    const heads = [...grid.querySelectorAll('thead th')].map((h) => h.textContent.trim());
    const rows = [...grid.querySelectorAll('tbody tr')]
      .map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim()))
      .filter((cells) => cells.length === heads.length && cells.some(Boolean))
      .map((cells) => Object.fromEntries(heads.map((h, i) => [h, cells[i]])));
    const footer = Object.fromEntries(
      [...grid.querySelectorAll('[data-testid="tag-stock-footer"] td[data-col]')].map((td) => [
        td.getAttribute('data-col'),
        td.textContent.trim(),
      ]),
    );
    return { heads, rows, footer };
  });
}
const FOOT = {
  qty: 'qty',
  pcs: 'pcs',
  grossWt: 'grossWt',
  netWt: 'netWt',
  mrp: 'mrp',
  prCost: 'prCost',
  lbrAmt: 'lbrAmt',
  othAmt: 'othAmt',
};
function assertFooter(footer, rows) {
  const want = totalsOf(rows);
  for (const k of Object.keys(FOOT)) close(num(footer[k]), want[k], `footer ${k}`);
}
const tagsOf = (grid) => grid.rows.map((r) => r.TagNo);
const tagsFrom = (report) => report.rows.map((r) => r.tagNo);

// ───────────── the lifecycle journey: vouchers made through the screens ─────────────
const tagStockRead = async (page, query) => {
  const q = new URLSearchParams({ view: 'tag', ...query });
  const response = await page.request.get(`/api/reports/tag-stock?${q.toString()}`);
  assert.equal(response.status(), 200, await response.text());
  return response.json();
};
const inStockNow = async (page, tags) => {
  const found = [];
  for (const tag of tags) {
    const report = await tagStockRead(page, {
      tab: 'stock',
      tagNo: tag,
      fromDate: `${startYear}-04-01`,
      toDate: today().iso,
    });
    if (report.rows.length) found.push(tag);
  }
  return found;
};
const movementsOf = (ctx, tags) =>
  ctx.rows(
    `SELECT "TAG_NO" tag,"VCH_TYPE" vt,"BOOK_NAME" bn,"ITM_SIGN" sg,"VCH_NO" vch FROM "MAIN_STOCK"
      WHERE tenant_id=$1 AND "TAG_NO"=ANY($2::text[]) ORDER BY "TAG_NO",row_id`,
    tags,
  );
const newLife = () => ({ tags: [], steps: [], vouchers: { sales: [] } });
/**
 * Five tags opened through Tag Opening: tag 1 stays, tags 2 and 3 are sold (Sales Invoice), tag 4 is cancelled (Tag
 * Cancel), tag 3 comes back (Sales Return) and tag 5 goes out on approval (Approval Issue). The Stock of the five after
 * each step is recorded as indexes into the tag list.
 */
async function lifecycle(ctx, page, life) {
  const steps = life.steps;
  const record = async (name, tags) => {
    const live = await inStockNow(page, tags);
    steps.push({ name, inStock: live.map((t) => tags.indexOf(t)).sort() });
  };
  const opened = await openTags(
    page,
    Array.from({ length: 5 }, () => ({ gross: '10.5', net: '10', touch: '91.6' })),
  );
  const tags = opened.tagNos;
  life.tags = tags;
  life.vouchers.opening = opened.vchNo;
  await record('opened', tags);
  life.vouchers.sales.push(await sellTag(page, tags[1]));
  life.vouchers.sales.push(await sellTag(page, tags[2]));
  await record('sold', tags);
  life.vouchers.cancel = await cancelTag(page, tags[3]);
  await record('cancelled', tags);
  life.vouchers.returned = await returnTag(page, life.vouchers.sales[1]);
  await record('returned', tags);
  const issue = await issueApproval(ctx, tags[4], { page });
  life.vouchers.issue = issue.voucherNo;
  await record('approval issued', tags);
  return life;
}
/**
 * The journey cases leave nothing behind: the vouchers are deleted through their screens, last first (an approval
 * issue through its own Delete), and the rows of the tags are swept for what a failed run left.
 */
async function purge(ctx, life, page) {
  const tags = life.tags;
  const attempt = async (work) => {
    try {
      await work();
    } catch {
      // already deleted by the case, or never created
    }
  };
  if (page) {
    const { vouchers } = life;
    if (vouchers.issue)
      await attempt(async () => {
        await reopenApproval(page, 'issue', vouchers.issue);
        await Promise.all([
          page.waitForResponse((r) => r.request().method() === 'DELETE'),
          page.getByTestId('approval-issue-delete').click(),
        ]);
      });
    if (vouchers.returned) await attempt(() => deleteReturn(page, vouchers.returned));
    if (vouchers.cancel) await attempt(() => deleteCancel(page, vouchers.cancel));
    for (const no of vouchers.sales ?? []) await attempt(() => deleteSale(page, no));
    if (vouchers.opening) await attempt(() => deleteOpening(page, vouchers.opening));
  }
  for (const table of ['APR_DETL', 'MAIN_STOCK', 'BAR_IDTL', 'BAR_DETL'])
    await ctx.owner.$executeRawUnsafe(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "TAG_NO"=ANY($2::text[])`,
      TENANT,
      tags,
    );
}

const tagStockCases = [
  C(
    'entry.opens-empty',
    'T01',
    'read-only',
    'RP_TAG.cs:3714 the form opens without running a query; the Report menu constructs RP_TAG (MDI_FORM.cs:8893).',
    async (ctx) => {
      const { page } = await ctx.session();
      const reportCalls = [];
      page.on('request', (r) => {
        if (new URL(r.url()).pathname === '/api/reports/tag-stock') reportCalls.push(r.url());
      });
      await openScreen(page);
      await page.waitForTimeout(500);
      assert.equal(reportCalls.length, 0, 'no report query on open');
      assert.equal(
        await page.getByTestId('tag-stock-grid').count(),
        0,
        'no grid before a mode button',
      );
      return {
        observation: 'screen opened, no report request',
        expected: 'no query and no grid until a mode button',
      };
    },
  ),
  C(
    'entry.defaults-and-captions',
    'T01',
    'read-only',
    'RP_TAG.cs:3711-3714 From and To = the system date, focus in From; :3642 RptType Tag Wise; :3627 It Type list; button captions Stock Tag, In Tag, Out Tag, Mrp Tag, Apr Pending, All Tag.',
    async (ctx) => {
      const { page } = await ctx.session();
      await openScreen(page);
      const today = ui(
        `${now.getFullYear()}-${String(now.getMonth() + 1).padStart(2, '0')}-${String(now.getDate()).padStart(2, '0')}`,
      );
      assert.equal(await page.getByLabel('From', { exact: true }).inputValue(), today);
      assert.equal(await page.getByLabel('To', { exact: true }).inputValue(), today);
      assert.equal(await page.evaluate(() => document.activeElement?.id), 'ts-from');
      assert.equal(await page.getByLabel('RptType', { exact: true }).inputValue(), 'tag');
      const types = await page
        .getByLabel('It Type', { exact: true })
        .locator('option')
        .allTextContents();
      assert.deepEqual(types, [
        '',
        'Gold',
        'Silver',
        'Diamond',
        'Real Stone',
        'Emitation',
        'Other',
        'Platinum',
      ]);
      for (const name of [
        'Stock Tag',
        'In Tag',
        'Out Tag',
        'Mrp Tag',
        'Apr Pending',
        'All Tag',
        'Excel',
        'Cancel',
        'Exit',
      ])
        await page.getByRole('button', { name, exact: true }).waitFor();
      return {
        observation: 'defaults and captions as the desktop form',
        expected: 'From = To = today; Tag Wise; six mode buttons',
      };
    },
  ),
  C(
    'entry.summ-relabel',
    'T01',
    'read-only',
    'RP_TAG.cs:9744 BtnAll.Text = "Product Stk" when RptType is Tag Summ.',
    async (ctx) => {
      const { page } = await ctx.session();
      await openScreen(page);
      await page.getByLabel('RptType', { exact: true }).selectOption('summ');
      await page.getByRole('button', { name: 'Product Stk', exact: true }).waitFor();
      assert.equal(await page.getByRole('button', { name: 'All Tag', exact: true }).count(), 0);
      return {
        observation: 'sixth button reads Product Stk',
        expected: 'Product Stk replaces All Tag',
      };
    },
  ),
  C(
    'entry.no-photo-no-diagnostics',
    'T01',
    'read-only',
    'RP_TAG.cs:3484 PicImage.Visible = false for Tag Stock; the F1 TagNo repair writer and pnlDiff are not ported (decision 4).',
    async (ctx) => {
      const { page } = await ctx.session();
      const seed = await seedB(ctx);
      const images = [];
      page.on(
        'request',
        (r) => /\/entity-image|\/images?\//.test(new URL(r.url()).pathname) && images.push(r.url()),
      );
      await openScreen(page);
      await setDates(page, iso(4, 1), iso(5, 31));
      await runMode(page, 'Stock Tag', 'stock');
      await page.getByTestId('tag-stock-grid').locator('tbody tr').first().click();
      assert.equal(await page.getByTestId('tag-stock-image').count(), 0, 'no photograph panel');
      await page.getByLabel('TagNo', { exact: true }).press('F1');
      assert.equal(await page.getByText('Re Adjust This Tag...').count(), 0);
      assert.deepEqual(images, []);
      return {
        observation: `no photograph or repair for ${seed.prefix}`,
        expected: 'no image request, no diagnostics',
      };
    },
  ),
  C(
    'stock.signed-movement-states',
    'T03',
    'read-only',
    "RP_TAG.cs:4187 HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0; :4124 A.VCH_DATE <= To; From ignored.",
    async (ctx) => {
      const { page } = await ctx.session();
      const seed = await seedB(ctx);
      await openScreen(page);
      await filterRows(page, seed.prefix);
      const seen = {};
      for (const asOf of [iso(4, 19), iso(4, 30), iso(5, 14), iso(5, 31)]) {
        await setDates(page, iso(1, 1), asOf);
        await runMode(page, 'Stock Tag', 'stock');
        const grid = await readGrid(page);
        const want = inStock(seed, asOf);
        assert.deepEqual(tagsOf(grid).sort(), want.map((t) => t.tag).sort(), `Stock as of ${asOf}`);
        assertFooter(grid.footer, want);
        seen[asOf] = want.map((t) => t.n);
      }
      // As of 31/05 the cancelled (4), sold (3) and approval-pending (6) tags are out; the returned sale (5) is back.
      assert.deepEqual(seen[iso(5, 31)], ['1', '2', '5', '7']);
      assert.deepEqual(seen[iso(4, 30)], ['1', '2', '6', '7']);
      return {
        observation: JSON.stringify(seen),
        expected: 'signed sums per as-of date',
        output: seen,
      };
    },
  ),
  C(
    'stock.footer-and-formats',
    'T03',
    'read-only',
    'RP_TAG.cs:4916-4976 footer Summary.Add of Qty, Pcs, Grwt, NetWt, LbrAmt, OthAmt, PrCost, Mrp; :4942 Grwt {0:n3}; :5257 LbrAmt {0:n0}.',
    async (ctx) => {
      const { page } = await ctx.session();
      const seed = await seedB(ctx);
      await openScreen(page);
      await setDates(page, iso(4, 1), iso(5, 31));
      await filterRows(page, seed.prefix);
      await runMode(page, 'Stock Tag', 'stock');
      const grid = await readGrid(page);
      const want = inStock(seed, iso(5, 31));
      assert.deepEqual(
        want.map((t) => t.n),
        ['1', '2', '5', '7'],
      );
      assertFooter(grid.footer, want);
      assert.equal(grid.footer.grossWt, '20.000');
      const a1 = grid.rows.find((r) => r.TagNo === seed.byN['1'].tag);
      assert.equal(a1.Grwt, '5.000');
      assert.equal(a1.LbrAmt, '500');
      const today = new Date(now.getFullYear(), now.getMonth(), now.getDate());
      const stk = new Date(`${seed.byN['1'].stk}T00:00:00`);
      assert.equal(
        Number(a1.Day),
        Math.round((today - stk) / 86400000),
        'Day = system date - stock date',
      );
      assert.deepEqual(grid.heads.slice(0, 8), [
        'LcCode',
        'VchTyp',
        'VchNo',
        'VchDate',
        'Day',
        'TagNo',
        'ItCode',
        'Counter',
      ]);
      return {
        observation: JSON.stringify(grid.footer),
        expected: 'footer = hand sums of the four stock tags',
        output: grid.footer,
      };
    },
  ),
  C(
    'modes.in-out-mrp-apr-all',
    'T03',
    'read-only',
    'RP_TAG.cs:4009 In = BAR_DETL rows From..To; :4070 Out = minus movements; :4152 Mrp <> 0; :4227 Apr = APR ISU, ISU_REC N, BAR_DETL amounts; :4278 All = signed history.',
    async (ctx) => {
      const { page } = await ctx.session();
      const seed = await seedB(ctx);
      await openScreen(page);
      await filterRows(page, seed.prefix);
      // In: the six tags created 05/04..07/04 (A002 was created on 10/04).
      await setDates(page, iso(4, 1), iso(4, 7));
      await runMode(page, 'In Tag', 'in');
      let grid = await readGrid(page);
      const inRows = seed.tags.filter((t) => t.stk >= iso(4, 1) && t.stk <= iso(4, 7));
      assert.deepEqual(tagsOf(grid).sort(), inRows.map((t) => t.tag).sort());
      assertFooter(grid.footer, inRows);
      // Out: the four minus movements 01/04..31/05, each with the movement's own figures.
      await setDates(page, iso(4, 1), iso(5, 31));
      await runMode(page, 'Out Tag', 'out');
      grid = await readGrid(page);
      const outs = seed.movements.filter((m) => m.sign === '-');
      assert.deepEqual(tagsOf(grid).sort(), outs.map((m) => m.t.tag).sort());
      assertFooter(
        grid.footer,
        outs.map((m) => m.t),
      );
      const order = grid.rows.map((r) => `${r.VchTyp}|${r.VchNo}`);
      assert.deepEqual(order, [...order].sort(), 'Out is ordered by VchTyp then VchNo');
      // Mrp: stock tags with an MRP (A007's MRP is 0).
      await runMode(page, 'Mrp Tag', 'mrp');
      grid = await readGrid(page);
      const mrpRows = inStock(seed, iso(5, 31)).filter((t) => t.mrp !== 0);
      assert.deepEqual(tagsOf(grid).sort(), mrpRows.map((t) => t.tag).sort());
      assertFooter(grid.footer, mrpRows);
      // Apr: the pending approval of A006 with the BAR_DETL figures (6.000 gross, 40000 MRP), not APR_DETL's.
      await runMode(page, 'Apr Pending', 'apr');
      grid = await readGrid(page);
      assert.deepEqual(tagsOf(grid), [seed.byN['6'].tag]);
      assert.equal(grid.rows[0].Grwt, '6.000');
      assert.equal(grid.rows[0].Mrp, '40,000');
      // All: 12 movements, one row per movement, with the sign.
      await runMode(page, 'All Tag', 'all');
      grid = await readGrid(page);
      assert.equal(grid.rows.length, seed.movements.length);
      assert.deepEqual(
        grid.rows.filter((r) => r.TagNo === seed.byN['5'].tag).map((r) => r.Sign),
        ['+', '-', '+'],
      );
      assert.equal(num(grid.footer.qty), seed.movements.length);
      return {
        observation: 'six modes match the desktop selections',
        expected: 'In 6, Out 4, Mrp 3, Apr 1, All 12',
      };
    },
  ),
  C(
    'filters.search-narrows-footer',
    'T02',
    'read-only',
    'RP_TAG.cs:3819 the Search box filters the bound grid by TagNo (Like); the footer sums the rows shown.',
    async (ctx) => {
      const { page } = await ctx.session();
      const seed = await seedB(ctx);
      await openScreen(page);
      await setDates(page, iso(4, 1), iso(5, 31));
      await runMode(page, 'Stock Tag', 'stock');
      await filterRows(page, seed.byN['2'].tag);
      const grid = await readGrid(page);
      assert.deepEqual(tagsOf(grid), [seed.byN['2'].tag]);
      assertFooter(grid.footer, [seed.byN['2']]);
      await filterRows(page, `${seed.prefix}ZZ`);
      const none = await readGrid(page);
      assert.equal(none.rows.length, 0);
      assert.equal(num(none.footer.qty), 0);
      return {
        observation: 'search narrows rows and footer',
        expected: 'A002 only, then zero rows and zero footer',
      };
    },
  ),
  C(
    'filters.item-product-type-size-tagno',
    'T02',
    'read-only',
    'RP_TAG.cs:4132-4156 the Size, Item, Product, Group, It Type and TagNo filters add exact predicates.',
    async (ctx) => {
      const { page } = await ctx.session();
      const seed = await seedB(ctx);
      await openScreen(page);
      await setDates(page, iso(4, 1), iso(5, 31));
      await filterRows(page, seed.prefix);
      const run = async () => {
        await runMode(page, 'Stock Tag', 'stock');
        return (await readGrid(page)).rows.map((r) => r.TagNo).sort();
      };
      await page.getByLabel('It Type', { exact: true }).selectOption('S');
      assert.deepEqual(await run(), [seed.byN['7'].tag]);
      await page.getByLabel('It Type', { exact: true }).selectOption('G');
      assert.deepEqual(
        await run(),
        [seed.byN['1'].tag, seed.byN['2'].tag, seed.byN['5'].tag].sort(),
      );
      await page.getByLabel('It Type', { exact: true }).selectOption('');
      await page.getByLabel('TagNo', { exact: true }).fill(seed.byN['2'].tag);
      assert.deepEqual(await run(), [seed.byN['2'].tag]);
      return {
        observation: 'It Type and TagNo select exact rows',
        expected: 'Silver: A007; Gold: A001, A002, A005; TagNo: A002',
      };
    },
  ),
  C(
    'invalid.date-mask',
    'T06',
    'read-only',
    'DC_Main.cs:1664 "Month Not Valid..."; :1672 "Date Not Valid..."; the text is reset and focus stays in the box; no query runs.',
    async (ctx) => {
      const { page } = await ctx.session();
      await openScreen(page);
      const calls = [];
      page.on(
        'request',
        (r) => new URL(r.url()).pathname === '/api/reports/tag-stock' && calls.push(r.url()),
      );
      const from = page.getByLabel('From', { exact: true });
      await from.fill('32/05/2026');
      await from.press('Enter');
      await page.getByRole('alert').filter({ hasText: 'Date Not Valid...' }).waitFor();
      assert.equal(await page.evaluate(() => document.activeElement?.id), 'ts-from');
      const to = page.getByLabel('To', { exact: true });
      await to.fill('15/13/2026');
      await to.press('Enter');
      await page.getByRole('alert').filter({ hasText: 'Month Not Valid...' }).waitFor();
      await from.fill('30/02/2026');
      await from.press('Enter');
      await page.getByRole('alert').filter({ hasText: 'Date Not Valid...' }).waitFor();
      assert.deepEqual(calls, []);
      return {
        observation: 'three bad dates refused with the desktop texts',
        expected: 'Date Not Valid..., Month Not Valid..., no query',
      };
    },
  ),
  C(
    'invalid.empty-result',
    'T06',
    'read-only',
    'RP_TAG.cs:4777 an empty bound set shows an empty grid with no message box.',
    async (ctx) => {
      const { page } = await ctx.session();
      const dialogs = await openScreen(page);
      await page.getByLabel('TagNo', { exact: true }).fill(`NOSUCH${RUN}`);
      await runMode(page, 'Stock Tag', 'stock');
      const grid = await readGrid(page);
      assert.equal(grid.rows.length, 0);
      assert.equal(num(grid.footer.qty), 0);
      assert.deepEqual(dialogs, []);
      return {
        observation: 'empty grid, zero footer, no popup',
        expected: 'empty result without a message',
      };
    },
  ),
  C(
    'keyboard.escape-arrows-enter-alt-cancel',
    'T17',
    'read-only',
    'RP_TAG.cs:3865-3871 Escape closes the form, Down/Up focus the grid; DC_Main date Enter moves on; &In Tag, &Out Tag, &Mrp Tag, &Excel, &Cancel, E&xit mnemonics (:2504-2644).',
    async (ctx) => {
      const { page } = await ctx.session();
      const seed = await seedB(ctx);
      await openScreen(page);
      await setDates(page, iso(4, 1), iso(5, 31));
      await filterRows(page, seed.prefix);
      // Enter in From -> To -> Search.
      await page.getByLabel('From', { exact: true }).press('Enter');
      assert.equal(
        await page.evaluate(() => document.activeElement?.id),
        'ts-to',
        'Enter in From focuses To',
      );
      await page.getByLabel('To', { exact: true }).press('Enter');
      assert.equal(
        await page.evaluate(() => document.activeElement?.id),
        'ts-search',
        'Enter in To focuses Search',
      );
      // Alt+I runs In Tag, Alt+O Out Tag, Alt+M Mrp Tag.
      for (const [key, tab] of [
        ['i', 'in'],
        ['o', 'out'],
        ['m', 'mrp'],
      ]) {
        const [response] = await Promise.all([
          page.waitForResponse(
            (r) =>
              new URL(r.url()).pathname === '/api/reports/tag-stock' &&
              new URL(r.url()).searchParams.get('tab') === tab,
          ),
          page.keyboard.press(`Alt+${key}`),
        ]);
        assert.equal(response.status(), 200, `Alt+${key} ${tab}`);
      }
      // Down from a selector box focuses the grid.
      await page.getByLabel('TagNo', { exact: true }).focus();
      await page.keyboard.press('ArrowDown');
      assert.equal(
        await page.getByTestId('tag-stock-grid').evaluate((el) => el === document.activeElement),
        true,
      );
      // Cancel clears the grid and the selectors and focuses From (Alt+C).
      await page.getByLabel('TagNo', { exact: true }).fill('X1');
      await page.keyboard.press('Alt+c');
      await page.waitForFunction(() => !document.querySelector('[data-testid="tag-stock-grid"]'));
      assert.equal(
        await page.getByLabel('TagNo', { exact: true }).inputValue(),
        '',
        'Cancel clears TagNo',
      );
      assert.equal(
        await page.evaluate(() => document.activeElement?.id),
        'ts-from',
        'Cancel focuses From',
      );
      // Escape leaves the screen.
      await page.goto('/');
      await page.goto('/reports/tag-stock');
      await page.getByRole('heading', { name: 'Tag Stock', exact: true }).waitFor();
      await page.keyboard.press('Escape');
      await page.waitForURL((u) => !u.pathname.endsWith('/reports/tag-stock'));
      return {
        observation: 'Enter flow, Alt mnemonics, arrows, Cancel and Escape',
        expected: 'desktop key handling',
      };
    },
  ),
  C(
    'lookup.stale-response',
    'T04',
    'read-only',
    'A report answered after a newer request was sent is dropped: the grid shows the last button pressed.',
    async (ctx) => {
      const { page } = await ctx.session();
      const seed = await seedB(ctx);
      await openScreen(page);
      await setDates(page, iso(4, 1), iso(5, 31));
      await filterRows(page, seed.prefix);
      await page.route(/\/api\/reports\/tag-stock\?.*tab=stock/, async (route) => {
        await new Promise((resolve) => setTimeout(resolve, 2500));
        await route.continue();
      });
      await page.getByRole('button', { name: 'Stock Tag', exact: true }).click();
      await runMode(page, 'Out Tag', 'out');
      await page.waitForTimeout(3000);
      const grid = await readGrid(page);
      const outs = seed.movements.filter((m) => m.sign === '-');
      assert.deepEqual(tagsOf(grid).sort(), outs.map((m) => m.t.tag).sort());
      await page.unroute(/\/api\/reports\/tag-stock\?.*tab=stock/);
      return {
        observation: 'Out grid kept after the slow Stock answer',
        expected: 'the stale Stock response is discarded',
      };
    },
  ),
  C(
    'summ.item-and-product',
    'T03',
    'read-only',
    'RP_TAG.cs:7866 GROUP BY item ordered by name; :8322-8326 Product Stk grouped and ordered by product name.',
    async (ctx) => {
      const { page } = await ctx.session();
      // The summary has no Search box over its groups: drop the other cases' tags so the item totals are this case's.
      for (const table of ['APR_DETL', 'MAIN_STOCK', 'BAR_DETL'])
        await ctx.owner.$executeRawUnsafe(
          `DELETE FROM "${table}" WHERE tenant_id=$1 AND "TAG_NO" LIKE $2`,
          TENANT,
          `T${RUN}%`,
        );
      const seed = await seedB(ctx);
      await openScreen(page);
      await setDates(page, iso(4, 1), iso(5, 31));
      await page.getByLabel('RptType', { exact: true }).selectOption('summ');
      await runMode(page, 'Stock Tag', 'stock');
      let grid = await readGrid(page);
      const stock = inStock(seed, iso(5, 31));
      const ring = grid.rows.find((r) => r.Item === 'TS Ring');
      const chain = grid.rows.find((r) => r.Item === 'TS Chain');
      const gold = stock.filter((t) => t.it === 'TS1');
      assert.equal(num(ring.Qty), gold.length);
      assert.equal(num(ring.Pcs), sumOf(gold, 'pcs'));
      close(num(ring.Grwt), sumOf(gold, 'gwt'), 'ring gross');
      assert.equal(num(chain.Qty), 1);
      await page.getByRole('button', { name: 'Product Stk', exact: true }).click();
      await page.waitForResponse((r) => new URL(r.url()).searchParams.get('view') === 'product');
      await page.getByRole('cell', { name: 'TS Rings', exact: true }).waitFor();
      grid = await readGrid(page);
      const names = grid.rows.map((r) => r.Product);
      assert.ok(names.indexOf('TS Chains') < names.indexOf('TS Rings'), 'ordered by product name');
      return {
        observation: 'summaries grouped by item and product',
        expected: 'ring 3 tags, chain 1',
      };
    },
  ),
  C(
    'output.csv-equals-grid',
    'T16',
    'output',
    'RP_TAG.cs:3263 Excel exports the grid; the web CSV has the grid columns, every row and a TOTAL row equal to the footer.',
    async (ctx) => {
      const { page } = await ctx.session();
      const seed = await seedB(ctx);
      await openScreen(page);
      await setDates(page, iso(4, 1), iso(5, 31));
      await filterRows(page, seed.prefix);
      const response = await runMode(page, 'Stock Tag', 'stock');
      const grid = await readGrid(page);
      const url = new URL(response.url());
      url.searchParams.set('search', seed.prefix);
      const csv = await page.request.get(`/api/reports/tag-stock.csv${url.search}`);
      assert.equal(csv.status(), 200, await csv.text());
      const lines = (await csv.text()).split('\n');
      assert.deepEqual(lines[0].split(','), grid.heads);
      assert.equal(lines.length, 1 + grid.rows.length + 1);
      const total = lines.at(-1).split(',');
      assert.equal(total[0], 'TOTAL');
      const head = lines[0].split(',');
      const want = totalsOf(inStock(seed, iso(5, 31)));
      assert.equal(Number(total[head.indexOf('Qty')]), want.qty);
      assert.equal(Number(total[head.indexOf('Mrp')]), want.mrp);
      return {
        observation: lines.slice(0, 2).join(' / '),
        expected: 'CSV = grid columns, rows and footer',
        output: Buffer.from(lines.join('\n')),
      };
    },
  ),
  C(
    'drill.voucher-zoom',
    'T05',
    'read-only',
    'RP_TAG.cs:8917-9140 DGV_DoubleClick: a double click opens the voucher of the row in its own screen on the row VchNo (Tag Opening, Sale, Sale Return, Tag Cancel, Approval Issue); nothing opens in Tag Summ or for another location (:8920); a target without the View right answers "You Have No Rights..." (:8943), also when the rights row is missing (WP-15 decision 4)',
    async (ctx) => {
      const { page } = await ctx.session();
      const life = newLife();
      const rights = [];
      const arrive = async (target, pattern) => {
        try {
          await target.waitForURL(pattern, { timeout: 15000 });
        } catch {
          throw new Error(`expected ${pattern}, the page is ${target.url()}`);
        }
      };
      try {
        await lifecycle(ctx, page, life);
        const { tags, vouchers } = life;
        const range = [`${startYear}-04-01`, today().iso];
        const run = async (target, tab, tag) => {
          await openScreen(target);
          await setDates(target, ...range);
          await target.getByLabel('TagNo', { exact: true }).fill(tag);
          await runMode(
            target,
            tab === 'stock' ? 'Stock Tag' : tab === 'out' ? 'Out Tag' : 'All Tag',
            tab,
          );
          return readGrid(target);
        };
        const zoomed = async (target, tab, tag, rowText) => {
          const grid = await run(target, tab, tag);
          const row = target
            .getByTestId('tag-stock-grid')
            .locator('tbody tr')
            .filter({ hasText: rowText });
          const index = grid.rows.findIndex((r) => rowText.test(Object.values(r).join(' ')));
          assert.ok(index >= 0, `${tag}: no ${tab} row ${rowText}`);
          await row.first().dblclick();
          return grid.rows[index];
        };
        const same = (shown, wanted) => assert.equal(Number(shown), Number(wanted));
        // Tag Opening: the Stock row of tag 1 is its opening voucher.
        let row = await zoomed(page, 'stock', tags[0], /./);
        await arrive(page, /\/txn\/tag-opening/);
        await page.getByTestId('tag-opening-loaded').waitFor();
        same(await page.getByLabel('Voucher No', { exact: true }).inputValue(), row.VchNo);
        same(vouchers.opening, row.VchNo);
        // Sale: the Out row of tag 2.
        row = await zoomed(page, 'out', tags[1], /./);
        await arrive(page, /\/txn\/sales/);
        await page
          .getByTestId('sales-loaded')
          .filter({ hasText: `Loaded #${row.VchNo}` })
          .waitFor();
        same(vouchers.sales[0], row.VchNo);
        // Sale Return: the last "+" row of the returned tag 3 in All (the first "+" is its opening).
        const all = await run(page, 'all', tags[2]);
        const returned = all.rows.filter((r) => r.Sign === '+').at(-1);
        await page
          .getByTestId('tag-stock-grid')
          .locator('tbody tr')
          .filter({ hasText: /\+/ })
          .last()
          .dblclick();
        await arrive(page, /\/txn\/sale-return/);
        await page
          .getByText(`Editing return #${Number(returned.VchNo)}`, { exact: false })
          .waitFor();
        same(vouchers.returned, returned.VchNo);
        // Tag Cancel: the Out row of tag 4.
        row = await zoomed(page, 'out', tags[3], /./);
        await arrive(page, /\/txn\/tag-cancel/);
        await page
          .getByTestId('tag-cancel-status')
          .filter({ hasText: `Loaded voucher ${row.VchNo}` })
          .waitFor();
        same(vouchers.cancel, row.VchNo);
        // Approval Issue: the Out row of tag 5.
        row = await zoomed(page, 'out', tags[4], /./);
        await arrive(page, /\/txn\/tour/);
        await page.getByText(`Loaded voucher ${row.VchNo}`, { exact: true }).waitFor();
        same(vouchers.issue, row.VchNo);
        rights.push('five screens opened on the row voucher number');

        // No Tag Summ zoom, and none for another location.
        await openScreen(page);
        await setDates(page, ...range);
        await page.getByLabel('RptType', { exact: true }).selectOption('summ');
        await runMode(page, 'Stock Tag', 'stock');
        await page.getByTestId('tag-stock-grid').locator('tbody tr').first().dblclick();
        await page.waitForTimeout(800);
        assert.match(new URL(page.url()).pathname, /\/reports\/tag-stock/);
        await page.getByLabel('RptType', { exact: true }).selectOption('tag');
        await page.getByLabel('TagNo', { exact: true }).fill(tags[0]);
        await runMode(page, 'Stock Tag', 'stock');
        // The Location box now names another location than the session's (RP_TAG.cs:8920 tLcCode.Text != MLc_code).
        await page.locator('#ts-location').fill('L2');
        await page.getByTestId('tag-stock-grid').locator('tbody tr').first().dblclick();
        await page.waitForTimeout(800);
        assert.match(new URL(page.url()).pathname, /\/reports\/tag-stock/);
        rights.push('Tag Summ and a second location open nothing');

        // Rights: the clerk may run Tag Stock; the Sale menu is denied (explicit N), then Tag Cancel has no row.
        const sub = async (menu, view) =>
          ctx.owner.$executeRawUnsafe(
            `UPDATE "USER_SET" SET "FRM_VIEW"=$3 WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"=$4`,
            TENANT,
            USERS.clerk.user,
            view,
            menu,
          );
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
           VALUES ($1,'01','01',$2,'Inventory','Tag Stock','Y','N','N','N')`,
          TENANT,
          USERS.clerk.user,
        );
        try {
          const clerk = (await ctx.session(as(USERS.clerk.user))).page;
          await sub('Sales Invoice', 'N');
          await run(clerk, 'out', tags[1]);
          await clerk.getByTestId('tag-stock-grid').locator('tbody tr').first().dblclick();
          await clerk
            .locator('.msg[role="alert"]')
            .filter({ hasText: 'You Have No Rights...' })
            .waitFor();
          assert.match(new URL(clerk.url()).pathname, /\/reports\/tag-stock/);
          await run(clerk, 'out', tags[3]);
          await clerk.getByTestId('tag-stock-grid').locator('tbody tr').first().dblclick();
          await clerk
            .locator('.msg[role="alert"]')
            .filter({ hasText: 'You Have No Rights...' })
            .waitFor();
          assert.match(new URL(clerk.url()).pathname, /\/reports\/tag-stock/);
          const zoom = await clerk.request.get(
            `/api/reports/tag-stock/zoom?bookCode=TGC&vchNo=${vouchers.cancel}`,
          );
          assert.equal(zoom.status(), 403);
          rights.push('explicit N and a missing rights row both refused');
        } finally {
          await sub('Sales Invoice', 'Y');
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Tag Stock'`,
            TENANT,
            USERS.clerk.user,
          );
        }
        return {
          observation: rights.join('; '),
          expected: 'the voucher screens open on the row voucher; the refusals open nothing',
        };
      } finally {
        await purge(ctx, life, page);
      }
    },
  ),
  C(
    'drill.approval-other-items',
    'T05',
    'read-only',
    'RP_TAG.cs:4221 "Report With Other Detail Item Name..." then ItemSub_Detl (:3890, :3892): Apr rows also carry It1..It5 with pieces and weight from BAR_IDTL (ISR_NO 1 to 5, summed per tag), HM_ID, HM_ID2..4 and GR_CODE; the footer sums the pieces and weights',
    async (ctx) => {
      const { page } = await ctx.session();
      const seed = await seedB(ctx, { only: ['6'] });
      const six = seed.byN['6'];
      await ctx.owner.$executeRawUnsafe(
        `UPDATE "BAR_DETL" SET "HM_ID"='HU6A',"HM_ID2"='HU6B' WHERE tenant_id=$1 AND "TAG_NO"=$2`,
        TENANT,
        six.tag,
      );
      for (const [isr, item, pcs, gwt] of [
        [1, 'ST1', 2, 0.5],
        [2, 'ST2', 1, 0.25],
      ])
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","TAG_NO","VCH_SRNO","IT_CODE","IT_PCS","IT_GWT")
           VALUES ($1,'01','01',$2,'TOP','0000',$3,$3,$4,$5,$6,$7,$8)`,
          TENANT,
          YEAR,
          isr,
          six.tag,
          six.id,
          item,
          pcs,
          gwt,
        );
      const dialogs = await openScreen(page, { otherItems: true });
      await setDates(page, iso(4, 1), iso(5, 31));
      await filterRows(page, seed.prefix);
      await runMode(page, 'Apr Pending', 'apr');
      await page.waitForFunction(() =>
        [...document.querySelectorAll('[data-testid="tag-stock-grid"] thead th')].some(
          (th) => th.textContent.trim() === 'It1',
        ),
      );
      const grid = await readGrid(page);
      assert.deepEqual(dialogs, ['Report With Other Detail Item Name...']);
      assert.deepEqual(tagsOf(grid), [six.tag]);
      const row = grid.rows[0];
      assert.deepEqual(
        ['It1', 'It1P', 'It1Wt', 'It2', 'It2P', 'It2Wt', 'It3', 'It3P', 'It3Wt'].map((h) => row[h]),
        ['ST1', '2', '0.500', 'ST2', '1', '0.250', '', '', ''],
      );
      assert.deepEqual(
        ['It4', 'It5', 'HM_ID', 'HM_ID2', 'HM_ID3', 'GR_CODE'].map((h) => row[h]),
        ['', '', 'HU6A', 'HU6B', '', 'T1'],
      );
      assert.equal(num(grid.footer.it1P), 2);
      close(num(grid.footer.it2Wt), 0.25, 'footer It2Wt');
      // Answering No keeps the plain Apr columns.
      const plain = await ctx.session();
      const noDialogs = await openScreen(plain.page);
      await filterRows(plain.page, seed.prefix);
      await runMode(plain.page, 'Apr Pending', 'apr');
      const without = await readGrid(plain.page);
      assert.deepEqual(noDialogs, ['Report With Other Detail Item Name...']);
      assert.ok(!without.heads.includes('It1'));
      return {
        observation: `Apr row ${six.tag}: ${['It1', 'It1P', 'It1Wt', 'It2', 'It2P', 'It2Wt'].map((h) => `${h}=${row[h]}`).join(' ')}`,
        expected: 'It1 ST1 2 0.500, It2 ST2 1 0.250, It3 to It5 blank; No keeps the plain columns',
      };
    },
  ),
  C(
    'output.print-window',
    'T16',
    'output',
    'RP_TAG.cs:8578-8754 BtnPrint_Click and :8755-8897 BtnSumm_Click: the print window is titled "Tag Wise Stock As on Date " + From + " To " + To (:8696, :8626-8635, branch prefix with the location), lists the grid columns and the footer totals; Summ asks "Product Wise Group Report" and prints TagStkSummRpt (Yes) or TagStkItemSumRpt (No)',
    async (ctx) => {
      const { page } = await ctx.session();
      const seed = await seedB(ctx);
      await openScreen(page);
      await setDates(page, iso(4, 1), iso(5, 31));
      await filterRows(page, seed.prefix);
      await runMode(page, 'Stock Tag', 'stock');
      const grid = await readGrid(page);
      const read = async (popup) => {
        await popup.waitForURL(/\/api\/reports\/tag-stock\/print/);
        await popup.getByTestId('print-title').waitFor();
        return popup.evaluate(() => ({
          template: document.body.dataset.template,
          title: document.querySelector('[data-testid="print-title"]').textContent,
          heads: [...document.querySelectorAll('thead th')].map((th) => th.textContent.trim()),
          rows: [...document.querySelectorAll('tbody tr')].map((tr) =>
            [...tr.querySelectorAll('td')].map((td) => td.textContent.trim()),
          ),
          footer: Object.fromEntries(
            [...document.querySelectorAll('[data-testid="print-footer"] td[data-col]')].map(
              (td) => [td.dataset.col, td.textContent.trim()],
            ),
          ),
        }));
      };
      const [popup] = await Promise.all([
        page.waitForEvent('popup'),
        page.getByRole('button', { name: 'Print', exact: true }).click(),
      ]);
      const printed = await read(popup);
      assert.equal(
        printed.title,
        `Branch - 01 Tag Wise Stock As on Date ${ui(iso(4, 1))} To ${ui(iso(5, 31))}`,
      );
      assert.equal(printed.template, 'TagStkRpt');
      assert.deepEqual(printed.heads, grid.heads);
      assert.equal(printed.rows.length, grid.rows.length);
      assert.deepEqual(
        printed.rows.map((r) => r[printed.heads.indexOf('TagNo')]).sort(),
        tagsOf(grid).sort(),
      );
      for (const key of Object.keys(FOOT))
        close(num(printed.footer[key]), num(grid.footer[key]), key);
      assertFooter(printed.footer, inStock(seed, iso(5, 31)));
      await popup.close();
      // Summ: the confirm answers pick the template.
      const answers = [];
      page.removeAllListeners('dialog');
      page.on('dialog', async (dialog) => {
        answers.push(dialog.message());
        await dialog.accept();
      });
      const [yes] = await Promise.all([
        page.waitForEvent('popup'),
        page.getByRole('button', { name: 'Summ', exact: true }).click(),
      ]);
      const product = await read(yes);
      assert.equal(product.template, 'TagStkSummRpt');
      assert.match(product.title, /^Branch - 01 Tag Wise Stock Summary As on Date /);
      assert.equal(product.heads[0], 'Product');
      await yes.close();
      page.removeAllListeners('dialog');
      page.on('dialog', async (dialog) => {
        answers.push(dialog.message());
        await dialog.dismiss();
      });
      const [no] = await Promise.all([
        page.waitForEvent('popup'),
        page.getByRole('button', { name: 'Summ', exact: true }).click(),
      ]);
      const item = await read(no);
      assert.equal(item.template, 'TagStkItemSumRpt');
      assert.equal(item.heads[0], 'Item');
      assert.deepEqual(answers, ['Product Wise Group Report', 'Product Wise Group Report']);
      await no.close();
      return {
        observation: `${printed.title} | ${printed.heads.length} columns, ${printed.rows.length} rows | Summ ${product.template} / ${item.template}`,
        expected: 'the desktop titles, the grid columns and the footer totals',
        output: Buffer.from(
          [printed.title, printed.heads.join(','), ...printed.rows.map((r) => r.join(','))].join(
            '\n',
          ),
        ),
      };
    },
  ),
  C(
    'rights.print-user',
    'T11',
    'refusal',
    'RP_TAG.cs:3257-3260 Excel (BtnSave_Click) answers "You Have No Print Rights....." without FRM_PRINT; Print and Summ are guarded the same way here; the List right still runs the report',
    async (ctx) => {
      await ctx.owner.$executeRawUnsafe(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES ($1,'01','01',$2,'Inventory','Tag Stock','Y','N','N','N')`,
        TENANT,
        USERS.clerk.user,
      );
      try {
        const seed = await seedB(ctx, { only: ['1', '2'] });
        const { page } = await ctx.session(as(USERS.clerk.user));
        await openScreen(page);
        await setDates(page, iso(4, 1), iso(5, 31));
        await filterRows(page, seed.prefix);
        const response = await runMode(page, 'Stock Tag', 'stock');
        const grid = await readGrid(page);
        assert.equal(grid.rows.length, 2, 'the List right runs the report');
        const popups = [];
        page.on('popup', (popup) => popups.push(popup));
        const refused = [];
        for (const name of ['Excel', 'CSV', 'Print', 'Summ']) {
          await page.getByRole('button', { name, exact: true }).click();
          await page
            .locator('.msg[role="alert"]')
            .filter({ hasText: 'You Have No Print Rights.....' })
            .waitFor();
          refused.push(name);
          await page.getByLabel('Search', { exact: true }).fill(seed.prefix);
        }
        assert.equal(popups.length, 0, 'no window or file opened');
        const url = new URL(response.url());
        for (const path of ['tag-stock.csv', 'tag-stock.xlsx', 'tag-stock/print']) {
          const direct = await page.request.get(`/api/reports/${path}${url.search}`);
          assert.equal(direct.status(), 403, path);
        }
        return {
          observation: `buttons ${refused.join(', ')} refused with the desktop text; the three routes answered 403`,
          expected: 'You Have No Print Rights..... and no document',
          database: {
            rights: await ctx.rows(
              `SELECT "FRM_VIEW" v,"FRM_PRINT" p FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Tag Stock'`,
              USERS.clerk.user,
            ),
          },
        };
      } finally {
        await ctx.owner.$executeRawUnsafe(
          `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Tag Stock'`,
          TENANT,
          USERS.clerk.user,
        );
      }
    },
  ),
  C(
    'concurrent.read-during-write',
    'T12',
    'read-only',
    'One report read is one snapshot: while a sale of a tag commits, each Stock answer is either the state before (the tag listed, Qty n) or after (the tag gone, Qty n-1), never a mix; the totals always equal their rows',
    async (ctx) => {
      const { page } = await ctx.session();
      const seed = await seedB(ctx, { only: ['1', '2', '7'] });
      const url = `/api/reports/tag-stock?tab=stock&view=tag&fromDate=${iso(4, 1)}&toDate=${iso(5, 31)}&search=${seed.prefix}`;
      const read = async () => {
        const response = await page.request.get(url);
        assert.equal(response.status(), 200);
        return response.json();
      };
      const log = [];
      const sold = [];
      for (const t of seed.tags) {
        const before = tagsFrom(await read());
        assert.ok(before.includes(t.tag));
        const [, ...answers] = await Promise.all([
          ctx.owner.$executeRawUnsafe(
            `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","STK_DATE","VCH_TYPE",
               "BOOK_NAME","IT_CODE","TAG_NO","TBL_CODE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","VCH_SRNO")
             VALUES ($1::text,'01','01',$2::text,'SL',$3::text,$4::date,$5::text,'SL','SL',$6::text,$7::text,$8::text,'-',$9::numeric,$10::numeric,$11::numeric,$12::float8)`,
            TENANT,
            YEAR,
            `9${t.n}00`,
            iso(5, 20),
            t.stk,
            t.it,
            t.tag,
            t.ctr,
            t.pcs,
            t.gwt,
            t.nwt,
            t.id,
          ),
          ...Array.from({ length: 6 }, () => read()),
        ]);
        sold.push(t.tag);
        for (const answer of answers) {
          const tags = tagsFrom(answer);
          const isBefore = tags.includes(t.tag);
          const expected = before.filter((x) => isBefore || x !== t.tag);
          assert.deepEqual(tags, expected, `${t.tag}: before or after, never a mix`);
          assert.equal(answer.totals.qty, answer.rows.length);
          close(
            answer.totals.grossWt,
            answer.rows.reduce((a, r) => a + r.grossWt, 0),
            'totals follow the rows',
          );
          log.push(isBefore ? 'before' : 'after');
        }
        assert.ok(!tagsFrom(await read()).includes(t.tag), 'after the commit the tag is gone');
      }
      assert.deepEqual(tagsFrom(await read()), []);
      return {
        observation: `${log.length} reads while ${sold.length} sales committed: ${log.filter((x) => x === 'before').length} before, ${log.filter((x) => x === 'after').length} after, none mixed`,
        expected: 'each answer is a whole before or after state',
      };
    },
  ),
  C(
    'history.item-master-rename',
    'T15',
    'mutation',
    'RP_TAG.cs:7866 and :4009 join ITEM_MAST on every run: renaming an item through Master -> Items shows the new name in the summary and the Stock grid follows the master',
    async (ctx) => {
      const { page } = await ctx.session();
      const seed = await seedB(ctx, { only: ['1', '2'] });
      const summary = async () => {
        await openScreen(page);
        await setDates(page, iso(4, 1), iso(5, 31));
        await page.getByLabel('RptType', { exact: true }).selectOption('summ');
        await runMode(page, 'Stock Tag', 'stock');
        return (await readGrid(page)).rows.map((r) => r.Item);
      };
      assert.ok((await summary()).includes('TS Ring'));
      try {
        await page.goto('/masters/items');
        await page.getByRole('heading', { name: 'Item Master', exact: true }).waitFor();
        const row = page.getByTestId('item-list').locator('tr[data-code="TS1"]');
        await row.dblclick();
        await page.waitForFunction(
          () =>
            document.querySelector('#item-code')?.value === 'TS1' &&
            document.activeElement?.id === 'item-name',
        );
        await page.getByLabel('Item Name', { exact: true }).fill('TS Band');
        const [saved] = await Promise.all([
          page.waitForResponse(
            (r) =>
              ['POST', 'PUT'].includes(r.request().method()) &&
              new URL(r.url()).pathname.startsWith('/api/masters/item-master'),
          ),
          page.getByRole('button', { name: 'Save', exact: true }).click(),
        ]);
        assert.equal(saved.status(), 200, await saved.text());
        await page.getByText('Data Are Saved.', { exact: true }).waitFor();
        const names = await summary();
        // The Item Master upper-cases the name it saves (desktop MS_ITEM).
        assert.ok(names.includes('TS BAND') && !names.includes('TS Ring'), names.join());
        await page.getByLabel('RptType', { exact: true }).selectOption('tag');
        await filterRows(page, seed.prefix);
        await runMode(page, 'Stock Tag', 'stock');
        const grid = await readGrid(page);
        assert.ok(grid.rows.length >= 2);
        return {
          observation: `summary groups: ${names.join(', ')}`,
          expected: 'the live master name: TS BAND replaces TS Ring',
          downstream: { summaryGroups: names, stockRows: grid.rows.length },
          database: {
            item: await ctx.rows(
              `SELECT "IT_NAME" n FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"='TS1'`,
            ),
          },
        };
      } finally {
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "ITEM_MAST" SET "IT_NAME"='TS Ring' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"='TS1'`,
          TENANT,
        );
      }
    },
  ),
  C(
    'history.older-year-carry',
    'T15',
    'read-only',
    'BtmSchm.cs:2362-2470 (Balance TrFr, Tag Stock): a tag still in stock at the end of the closed year is copied into the new year, so the new year lists it; one sold last year is not carried. The web reads the earlier year instead of copying',
    async (ctx) => {
      await ensureMasters(ctx);
      const previous = `${startYear - 1}-${startYear}`;
      const tag = `T${RUN}OY`;
      const seedOld = async (suffix, sold) => {
        const t = `${tag}${suffix}`;
        const id = 930000000000 + Math.floor(Math.random() * 1e6);
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","STK_DATE","VCH_TYPE","BOOK_NAME",
             "IT_CODE","TAG_NO","DESIGN_NO","TBL_CODE","ITM_SIZE","ITM_PCS","ITM_GWT","ITM_NWT","VCH_SRNO","EMP_ISU")
           VALUES ($1::text,'01','01',$2::text,'TOP','0000',$3::date,$4::text,'TO','TAG OPENING','TS1',$5::text,'DO','C1','7',1,2,1.9,$6::float8,'N')`,
          TENANT,
          previous,
          `${startYear - 1}-06-05`,
          `${startYear - 1}-06-05`,
          t,
          id,
        );
        for (const [sign, date, type, book, no] of [
          ['+', `${startYear - 1}-06-05`, 'TO', 'TOP', '0000'],
          ...(sold ? [['-', `${startYear - 1}-12-20`, 'SL', 'SL', '0008']] : []),
        ])
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","STK_DATE","VCH_TYPE","BOOK_NAME",
               "IT_CODE","TAG_NO","TBL_CODE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","VCH_SRNO")
             VALUES ($1::text,'01','01',$2::text,$3::text,$4::text,$5::date,$6::text,$7::text,$3::text,'TS1',$8::text,'C1',$9::text,1,2,1.9,$10::float8)`,
            TENANT,
            previous,
            book,
            no,
            date,
            `${startYear - 1}-06-05`,
            type,
            t,
            sign,
            id,
          );
        return t;
      };
      const kept = await seedOld('K', false);
      const gone = await seedOld('S', true);
      const { page } = await ctx.session();
      await openScreen(page);
      await setDates(page, iso(4, 1), iso(5, 31));
      await filterRows(page, tag);
      await runMode(page, 'Stock Tag', 'stock');
      const stock = await readGrid(page);
      assert.deepEqual(
        tagsOf(stock),
        [kept],
        'carried into this year; the one sold last year is not',
      );
      assert.equal(stock.rows[0].Qty, '1');
      // The carried row opens nothing: the desktop's copy sits in book 000, which BOOK_DATA does not hold
      // (BtmSchm.cs:2378, RP_TAG.cs:8924); the web row is last year's voucher, whose number must not open this year.
      const zoomCalls = [];
      const onRequest = (request) => {
        if (request.url().includes('/reports/tag-stock/zoom')) zoomCalls.push(request.url());
      };
      page.on('request', onRequest);
      await page.getByTestId('tag-stock-grid').locator('tbody tr').first().dblclick();
      await page.waitForTimeout(800);
      page.off('request', onRequest);
      assert.match(new URL(page.url()).pathname, /\/reports\/tag-stock/);
      assert.deepEqual(zoomCalls, [], 'no zoom is asked for a carried row');
      // The movements of the year stay the year's own: In and All of this year do not list it.
      await runMode(page, 'In Tag', 'in');
      assert.deepEqual(tagsOf(await readGrid(page)), []);
      await runMode(page, 'All Tag', 'all');
      assert.deepEqual(tagsOf(await readGrid(page)), []);
      for (const table of ['MAIN_STOCK', 'BAR_DETL'])
        await ctx.owner.$executeRawUnsafe(
          `DELETE FROM "${table}" WHERE tenant_id=$1 AND "TAG_NO" = ANY($2::text[])`,
          TENANT,
          [kept, gone],
        );
      return {
        observation: `${previous} tags: ${kept} (in stock) listed, ${gone} (sold) not`,
        expected: 'the carried tag is in this year Stock',
      };
    },
  ),
  C(
    'journey.lifecycle-through-screens',
    'T18',
    'mutation',
    'WP-15 tag-stock.journey.lifecycle-reconcile: the tags are made by Tag Opening and moved by a Sale, a Tag Cancel, a Sale Return and an Approval Issue through their screens; Stock after each step is the signed sum of the tag movements (RP_TAG.cs:4187), and In, Out and All follow',
    async (ctx) => {
      const { page } = await ctx.session();
      const life = newLife();
      try {
        await lifecycle(ctx, page, life);
        const { tags, steps } = life;
        assert.deepEqual(
          steps.map((x) => x.inStock),
          [
            [0, 1, 2, 3, 4], // five tags opened
            [0, 3, 4], // tags 1 and 2 sold
            [0, 4], // tag 3 cancelled
            [0, 2, 4], // tag 2 returned
            [0, 2], // tag 4 issued on approval
          ],
        );
        const range = { from: `${startYear}-04-01`, to: today().iso };
        const read = async (tab, tag) =>
          (await tagStockRead(page, { tab, tagNo: tag, fromDate: range.from, toDate: range.to }))
            .rows;
        const inRows = (await Promise.all(tags.map((t) => read('in', t)))).flat();
        const outRows = (await Promise.all(tags.map((t) => read('out', t)))).flat();
        const allRows = await read('all', tags[2]);
        assert.deepEqual(
          inRows.map((r) => r.tagNo).sort(),
          [...tags].sort(),
          'In: one creation row per tag',
        );
        assert.deepEqual(
          outRows.map((r) => r.tagNo).sort(),
          [tags[1], tags[2], tags[3], tags[4]].sort(),
          'Out: sale, sale, cancel, approval issue',
        );
        assert.deepEqual(
          allRows.map((r) => r.sign),
          ['+', '-', '+'],
          'All of the returned tag: open, sold, returned',
        );
        // The screen shows the same final state.
        await openScreen(page);
        await setDates(page, range.from, range.to);
        await filterRows(page, tags[0].slice(0, -2));
        await runMode(page, 'Stock Tag', 'stock');
        const grid = await readGrid(page);
        const shown = tagsOf(grid)
          .filter((t) => tags.includes(t))
          .sort();
        assert.deepEqual(shown, [tags[0], tags[2]].sort());
        return {
          observation: steps
            .map((x) => `${x.name}: ${x.inStock.map((i) => tags[i]).join(' ')}`)
            .join(' | '),
          expected: 'Stock after each voucher follows the signed sum of the tag movements',
          database: { movements: await movementsOf(ctx, tags) },
          downstream: {
            in: inRows.length,
            out: outRows.length,
            all: allRows.length,
            screen: shown,
          },
        };
      } finally {
        await purge(ctx, life, page);
      }
    },
  ),
  C(
    'reverse.delete-source-vouchers',
    'T10',
    'mutation',
    'WP-15 tag-stock.reverse.*: deleting the Tag Cancel, the Sale and the Sale Return through their screens removes their stock movement, so the tag is back (cancel, sale) or gone again (return) in Stock',
    async (ctx) => {
      const { page } = await ctx.session();
      const life = newLife();
      try {
        await lifecycle(ctx, page, life);
        const { tags, vouchers } = life;
        const now = async () => (await inStockNow(page, tags)).sort();
        assert.deepEqual(await now(), [tags[0], tags[2]].sort());
        await deleteCancel(page, vouchers.cancel);
        assert.deepEqual(
          await now(),
          [tags[0], tags[2], tags[3]].sort(),
          'tag 4 back after the Tag Cancel delete',
        );
        await deleteReturn(page, vouchers.returned);
        assert.deepEqual(
          await now(),
          [tags[0], tags[3]].sort(),
          'tag 3 leaves again with the Sale Return delete',
        );
        await deleteSale(page, vouchers.sales[0]);
        assert.deepEqual(
          await now(),
          [tags[0], tags[1], tags[3]].sort(),
          'tag 2 back after its Sale delete',
        );
        const all = (
          await tagStockRead(page, {
            tab: 'all',
            tagNo: tags[2],
            fromDate: `${startYear}-04-01`,
            toDate: today().iso,
          })
        ).rows.map((r) => r.sign);
        assert.deepEqual(
          all,
          ['+', '-'],
          'All of the returned tag shows the opening and the sale again',
        );
        return {
          observation: 'cancel, sale return and sale deleted one by one; Stock followed each',
          expected: 'the movement of each deleted voucher is gone',
          database: { movements: await movementsOf(ctx, tags) },
          downstream: { final: await now() },
        };
      } finally {
        await purge(ctx, life, page);
      }
    },
  ),
  notApplicable(
    'create',
    'T07',
    'WP-15 cases tag-stock.na.create',
    'Read-only report: it writes nothing; the desktop print staging (TAG_STOCK_PRINT, TAG_SUM_DATA) is a Crystal feed the web does not port.',
  ),
  notApplicable(
    'reopen',
    'T08',
    'WP-15 cases tag-stock.na.reopen',
    'Read-only report: nothing is saved, so there is no reopen or unchanged save; reopening the screen re-runs on demand.',
  ),
  notApplicable(
    'edit',
    'T09',
    'WP-15 cases tag-stock.na.edit',
    'Read-only grid (RP_TAG.cs:2475 Editable = false); the effect of editing a source voucher is a T18 journey.',
  ),
  notApplicable(
    'retry',
    'T13',
    'WP-15 cases tag-stock.na.retry',
    'Read-only report: the endpoints are idempotent GETs; repeating a request changes no data.',
  ),
  notApplicable(
    'rollback',
    'T14',
    'WP-15 cases tag-stock.na.rollback',
    'Read-only report: there is no write to roll back.',
  ),
  C(
    'scope.leaves-no-rows-for-other-modules',
    'T11',
    'read-only',
    'Fixture hygiene: the seeded gold and silver items and tags would otherwise show up in Item Opening and other screens that list by item type.',
    async (ctx) => {
      for (const table of ['APR_DETL', 'MAIN_STOCK', 'BAR_IDTL', 'BAR_DETL'])
        await ctx.owner.$executeRawUnsafe(
          `DELETE FROM "${table}" WHERE tenant_id=$1 AND "TAG_NO" LIKE $2`,
          TENANT,
          `T${RUN}%`,
        );
      await ctx.owner.$executeRawUnsafe(
        `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE" IN ('TS1','TS2')`,
        TENANT,
      );
      await ctx.owner.$executeRawUnsafe(
        `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "PR_CODE" IN ('T1','T2')`,
        TENANT,
      );
      await ctx.owner.$executeRawUnsafe(
        `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "GR_CODE" IN ('T1','T2')`,
        TENANT,
      );
      mastersReady = false;
      return {
        observation: 'tag-stock fixtures removed',
        expected: 'no rows left for other modules',
      };
    },
  ),
];

export const tagStock = {
  feature: 'tag-stock',
  title: 'Report → Tag Stock (RP_TAG)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/reports/tag-stock/page.tsx',
    'web/apps/web/app/(app)/reports/tag-stock/TagStockGrid.tsx',
    'web/apps/web/app/(app)/reports/tag-stock/useTagStock.ts',
    'web/apps/web/app/(app)/reports/tag-stock/dateText.ts',
    'web/apps/api/src/modules/reports/tagStock.ts',
    'web/apps/api/src/modules/reports/tagStockColumns.ts',
    'web/apps/api/src/routes/tagStock.ts',
    'web/apps/web/test/features/modules/tagStock.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    companySettings: 'catalogue defaults; cases seed their own tags under a unique prefix',
  },
  cases: tagStockCases,
};
