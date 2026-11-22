import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

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
 * contains the case prefix). Journeys through the real voucher screens are listed as pending below.
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
    kind === 'output'
      ? ['browser', 'expected', 'output']
      : kind === 'refusal'
        ? ['browser', 'expected', 'database']
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
async function openScreen(page) {
  await page.goto('/reports/tag-stock');
  await page.getByRole('heading', { name: 'Tag Stock', exact: true }).waitFor();
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
      let dialogs = 0;
      page.on('dialog', async (d) => {
        dialogs += 1;
        await d.dismiss();
      });
      await openScreen(page);
      await page.getByLabel('TagNo', { exact: true }).fill(`NOSUCH${RUN}`);
      await runMode(page, 'Stock Tag', 'stock');
      const grid = await readGrid(page);
      assert.equal(grid.rows.length, 0);
      assert.equal(num(grid.footer.qty), 0);
      assert.equal(dialogs, 0);
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
      assert.equal(await page.evaluate(() => document.activeElement?.id), 'ts-to');
      await page.getByLabel('To', { exact: true }).press('Enter');
      assert.equal(await page.evaluate(() => document.activeElement?.id), 'ts-search');
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
        assert.equal(response.status(), 200);
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
      assert.equal(await page.getByLabel('TagNo', { exact: true }).inputValue(), '');
      assert.equal(await page.evaluate(() => document.activeElement?.id), 'ts-from');
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
  blocked(
    'drill.voucher-zoom',
    'T05',
    'Voucher double-click zoom (gap 10, cases drill.*) is not built: the voucher screens have no open-by-number entry from a report.',
  ),
  blocked(
    'drill.approval-other-items',
    'T05',
    'The Apr other-item columns (BAR_IDTL It1..It5, gap 13) are not built.',
  ),
  blocked(
    'output.print-window',
    'T16',
    'The Print window and Crystal templates TagStkRpt/TagStkSummRpt (gap 11) are not built; only CSV and Excel exports exist.',
  ),
  blocked(
    'rights.print-user',
    'T11',
    'A List-only browser user is not in the fixture catalogue; the Print right on CSV and Excel is covered at the API by tagStock.routes.db.test.ts.',
  ),
  blocked(
    'journey.lifecycle-through-screens',
    'T18',
    "Creating the Tag Opening, Sale, Tag Cancel, Sale Return and Approval Issue vouchers through their screens and running Stock after each step needs those modules' helpers; the stock rule is proven on seeded movements by stock.signed-movement-states and tagStock.db.test.ts.",
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
