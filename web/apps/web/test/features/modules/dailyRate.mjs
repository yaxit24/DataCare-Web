import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Other → Daily Rate (desktop MS_RATE "Rate Master", web /txn/daily-rate).
 *
 * Desktop authority for the expected values (worked by hand, not read from the web):
 * - DISPLAY_DATA (MS_RATE.cs:1752-1832): the grid lists GROUP_MAST groups with GR_TOUCH <> 0 ORDER BY GR_TYPE, GR_NAME.
 * - nSilverRate_KeyDown (:2314-2368): Enter on the silver rate sets TaxRate = Round(Touch × Gold / 100) (silver: the
 *   1 kg rate / 10000), Rate10gm = Round(TaxRate / (Tax% + 100) × 100, 0) when the group has a Tax%, and
 *   PrRate = Round(PrTouch × rate / divisor); Round is .NET banker's rounding.
 * - BtnSave_Click (:1867-1947) writes one RATE_MAST row per group with a touch and a Rate10gm, SR_NO = grid row.
 * - BtnDelete_Click (:2095-2109) asks "Are You Sure To Delete This Day Rate?"; BtnPrint_Click prints RateRpt.
 *
 * The module adds three rate groups of its own (3-character GR_CODE) so the fixture groups, which have no touch and
 * so never appear on this screen, are left as they are.
 */
const GROUPS = [
  // code, name, type, touch, tax, purchase touch
  ['R18', 'Rate Gold 18K', 'G', 75, 0, 76],
  ['R22', 'Rate Gold 22K', 'G', 91.6, 3, 92],
  ['RSV', 'Rate Silver 925', 'S', 92.5, 3, 90],
];
/** Gold 72000 / Silver 85000 after Enter: [TaxRate, Rate10gm, PrRate] per group (see core dailyRate.test.ts). */
const ORIGINAL_RATE = { R18: 111, R22: 222, RSV: 333 };
const DERIVED = { R18: [54000, 54000, 54720], R22: [65952, 64031, 66240], RSV: [786, 763, 765] };
const as = (user, slot, location) => ({
  user,
  slot,
  location,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `daily-rate.${id}`,
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
const notApplicable = (name, group, source, reason) => ({
  ...C(`${name}.not-applicable`, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});
const label = (page, text) => page.getByLabel(text, { exact: true });
let day = 0;
/** A distinct day per case, inside the fixture's current year, so cases never share a saved day. */
function nextDay() {
  const now = new Date();
  const start = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
  day += 1;
  return `${start}-08-${String(day).padStart(2, '0')}`;
}

async function ensureGroups(ctx) {
  // seedCompany copies the installer groups (MS_YEAR.cs:1555-1592); five of them have a touch (916, FGL, GO, FSL, SL),
  // so the real grid lists them and Enter on the silver rate prices them too (the API suite proves that listing).
  // This module's matrices are written over its own three groups, so the installer groups' touch is cleared here;
  // nothing else in the shared database reads the installer groups' GR_TOUCH.
  await ctx.owner.$executeRawUnsafe(
    `UPDATE "GROUP_MAST" SET "GR_TOUCH"=0 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "GR_CODE" = ANY($2::text[])`,
    'feature-e2e',
    ['916', 'FGL', 'GO', 'FSL', 'SL'],
  );
  for (const [code, name, type, touch, tax, prTouch] of GROUPS)
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE","GR_TOUCH","TAX_PRC","GR_PURC_TOUCH","RATE_DISPLAY","GR_RATE")
       SELECT $1::text,'01',$2::text,$3::text,$4::text,$5::float8,$6::numeric,$7::float8,'Y',${ORIGINAL_RATE[code]}
        WHERE NOT EXISTS (SELECT 1 FROM "GROUP_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "GR_CODE"=$2::text)`,
      'feature-e2e',
      code,
      name,
      type,
      touch,
      tax,
      prTouch,
    );
}

/**
 * The screen has shown the day it read: the form is busy (rates and grid read-only) from the request until the
 * answer is on screen. The response alone is not enough, it reaches the test before the page has rendered it.
 */
const dayShown = (page) => page.locator('form[aria-busy="false"]').waitFor();

/** Type the day; the screen reads it only when it differs from the day it already shows. */
async function selectDay(page, date) {
  if ((await label(page, 'Vch Date').inputValue()) === date) return dayShown(page);
  await Promise.all([
    page.waitForResponse((r) => r.url().includes(`/api/daily-rate?date=${date}`)),
    label(page, 'Vch Date').fill(date),
  ]);
  await dayShown(page);
}

async function open(ctx, date, who) {
  await ensureWorld(ctx);
  const { page } = await ctx.session(who);
  await page.goto('/txn/daily-rate');
  await page.getByRole('heading', { name: 'Rate Master', exact: true }).waitFor();
  await label(page, 'Touch R22').waitFor();
  if (date) await selectDay(page, date);
  else await dayShown(page);
  return page;
}

async function priceDay(page) {
  await label(page, 'Gold Rate 10gm').fill('72000');
  await label(page, 'Silver Rate 1Kg').fill('85000');
  await label(page, 'Silver Rate 1Kg').press('Enter');
  await page.waitForFunction(() => {
    const el = document.querySelector('input[aria-label="TaxRate R22"]');
    return el && el.value === '65952';
  });
}

const gridOf = async (page) => {
  const out = {};
  for (const [code] of GROUPS)
    out[code] = [
      Number(await label(page, `TaxRate ${code}`).inputValue()),
      Number(await label(page, `Rate10gm ${code}`).inputValue()),
      Number(await label(page, `PrRate ${code}`).inputValue()),
    ];
  return out;
};

/**
 * Save. A saved day answers "Data Are Saved." and the screen runs CLEAR_DATA (MS_RATE.cs:2007-2016): the helper waits
 * for the grid to be cleared; `reopen` shows a day again. `reloadOf` is kept for the callers' readability only.
 */
async function save(page, _reloadOf) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => r.request().method() === 'POST' && new URL(r.url()).pathname === '/api/daily-rate',
    ),
    page.locator('button[data-save-mnemonic]').click(),
  ]);
  if (response.status() === 201)
    await page.waitForFunction(() => !document.querySelector('input[aria-label^="Rate10gm"]'));
  return response;
}

/** Show a day again after a save cleared the screen: the date is read when the cursor leaves it. */
async function reopen(page, date) {
  const input = label(page, 'Vch Date');
  if ((await input.inputValue()) !== date) return selectDay(page, date);
  await Promise.all([
    page.waitForResponse((r) => r.url().includes(`/api/daily-rate?date=${date}`)),
    input.focus().then(() => input.blur()),
  ]);
  await dayShown(page);
  await label(page, 'Touch R22').waitFor();
}

const savedRows = (ctx, date) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"GR_CODE" gr,"GR_TYPE" type,"GR_RATE"::float rate,"GR_TAX_RATE"::float taxrate,
            "GR_PR_RATE"::float prrate,"GR_TOUCH"::float touch,"GR_TAX_PRC"::float tax,"GR_PR_TOUCH"::float prtouch,
            "FINE_GL_RATE"::float gold,"FINE_SL_RATE"::float silver,coalesce("MAIN_USER",'') "user",
            "LC_CODE" lc,"GR_NAME" name
       FROM "RATE_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "VCH_DATE"=$2::date
         AND "GR_CODE" IN ('R18','R22','RSV') ORDER BY "SR_NO"`,
    date,
  );

// ---- WP-33 residuals: location sessions, the company copy entitlement, the main-window labels ------------------
const AT_00 = as(USERS.admin.user, `${USERS.admin.user}@00`, '00');
const AT_00B = as(USERS.admin.user, `${USERS.admin.user}@00#2`, '00');
const AT_01 = as(USERS.admin.user, `${USERS.admin.user}@01`, '01');
const AT_02 = as(USERS.admin.user, `${USERS.admin.user}@02`, '02');
const LOCATIONS = ['00', '01', '02'];

/** Groups, the locations 00 and 02 beside the fixture's 01, and the synthetic employee. */
async function ensureWorld(ctx) {
  await ensureGroups(ctx);
  for (const lc of ['00', '02'])
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME")
       SELECT 'feature-e2e','01',$1::text,$2::text
        WHERE NOT EXISTS (SELECT 1 FROM "LOCT_MAST" WHERE tenant_id='feature-e2e' AND "CO_CODE"='01' AND "LC_CODE"=$1::text)`,
      lc,
      `E2E LOCATION ${lc}`,
    );
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME")
     SELECT 'feature-e2e','01','E01','E2E RATE CLERK'
      WHERE NOT EXISTS (SELECT 1 FROM "EMP_MAST" WHERE tenant_id='feature-e2e' AND "CO_CODE"='01' AND "EMP_CODE"='E01')`,
  );
}

/** The operator-provisioned entitlement (A1); no API route writes it. */
const setEntitlement = (ctx, enabled) =>
  ctx.owner.$executeRawUnsafe(
    `INSERT INTO "daily_rate_copy_entitlement"(tenant_id,co_code,enabled) VALUES ('feature-e2e','01',$1)
     ON CONFLICT (tenant_id,co_code) DO UPDATE SET enabled=EXCLUDED.enabled`,
    enabled,
  );

/** A clean slate for the cases that read whole-tenant state: no rates, the original group rates, entitlement set. */
async function resetWorld(ctx, entitled) {
  await ensureWorld(ctx);
  await ctx.owner.$executeRawUnsafe(`DELETE FROM "RATE_MAST" WHERE tenant_id='feature-e2e'`);
  for (const [code, rate] of Object.entries(ORIGINAL_RATE))
    await ctx.owner.$executeRawUnsafe(
      `UPDATE "GROUP_MAST" SET "GR_RATE"=$2 WHERE tenant_id='feature-e2e' AND "CO_CODE"='01' AND "GR_CODE"=$1`,
      code,
      rate,
    );
  await setEntitlement(ctx, entitled);
}

const allRates = (ctx) =>
  ctx.rows(
    `SELECT "LC_CODE" lc,to_char("VCH_DATE",'YYYY-MM-DD') d,"SR_NO"::int sr,"GR_CODE" gr,"GR_RATE"::float rate,
            "GR_TAX_RATE"::float taxrate,"GR_PR_RATE"::float prrate,"FINE_GL_RATE"::float gold,
            "FINE_SL_RATE"::float silver,coalesce("EMP_CODE",'') emp,coalesce("MAIN_USER",'') usr,"CO_YEAR" yr
       FROM "RATE_MAST" WHERE tenant_id=$1 ORDER BY 1,2,3`,
  );
const rowsAt = async (ctx, lc, date) =>
  (await allRates(ctx)).filter((r) => r.lc === lc && r.d === date);
const groupRates = async (ctx) =>
  (
    await ctx.rows(
      `SELECT "GR_CODE" gr,"GR_RATE"::float rate FROM "GROUP_MAST"
        WHERE tenant_id=$1 AND "GR_CODE" IN ('R18','R22','RSV') ORDER BY 1`,
    )
  ).map((r) => [r.gr, r.rate]);
const rateOf = (rows) => rows.map((r) => r.rate);
const A_RATES = [54000, 64031, 763];
const B_RATES = [54750, 64920, 773];
const A_GROUPS = [
  ['R18', 54000],
  ['R22', 64031],
  ['RSV', 763],
];
const B_GROUPS = [
  ['R18', 54750],
  ['R22', 64920],
  ['RSV', 773],
];
const ORIGINAL_GROUPS = [
  ['R18', 111],
  ['R22', 222],
  ['RSV', 333],
];

async function priceAt(page, gold, silver, taxRateR22) {
  await label(page, 'Gold Rate 10gm').fill(String(gold));
  await label(page, 'Silver Rate 1Kg').fill(String(silver));
  await label(page, 'Silver Rate 1Kg').press('Enter');
  await page.waitForFunction((expected) => {
    const el = document.querySelector('input[aria-label="TaxRate R22"]');
    return el && el.value === expected;
  }, String(taxRateR22));
}
const priceB = (page) => priceAt(page, 73000, 86000, 66868);

/** The server's own view of the session scope: the case must not simulate 00 by editing a request. */
async function sessionLocation(page) {
  return page.evaluate(
    async () => (await (await fetch('/api/me', { credentials: 'include' })).json()).lcCode,
  );
}

const todayLocal = () => {
  const now = new Date();
  const pad = (v) => String(v).padStart(2, '0');
  return `${now.getFullYear()}-${pad(now.getMonth() + 1)}-${pad(now.getDate())}`;
};
const addDays = (iso, n) => {
  const d = new Date(`${iso}T00:00:00Z`);
  d.setUTCDate(d.getUTCDate() + n);
  return d.toISOString().slice(0, 10);
};
const fiscalYearOf = async (ctx) =>
  (
    await ctx.rows(
      `SELECT "CO_YEAR" y FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "CO_YEAR"<>'2024-2025' LIMIT 1`,
    )
  )[0].y;

/** The display fixture (cases.md Test data): groups Display 1..8 with no touch, so they never reach the Rate grid. */
async function seedDisplay(ctx, { count, lc = '01', date = todayLocal(), ahead = true }) {
  await ensureWorld(ctx);
  const year = await fiscalYearOf(ctx);
  const codes = ['DN0', ...Array.from({ length: 8 }, (_, i) => `D0${i + 1}`)];
  for (const [i, code] of codes.entries())
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE","GR_TOUCH","GR_RATE","RATE_DISPLAY")
       SELECT 'feature-e2e','01',$1::text,$2::text,'G',0,999,$3::text
        WHERE NOT EXISTS (SELECT 1 FROM "GROUP_MAST" WHERE tenant_id='feature-e2e' AND "CO_CODE"='01' AND "GR_CODE"=$1::text)`,
      code,
      i === 0 ? 'Hidden Row' : `Display ${i}`,
      i === 0 ? 'N' : 'Y',
    );
  const insert = (sr, code, rate, tax) =>
    ctx.owner.$executeRawUnsafe(
      `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","VCH_DATE","SR_NO","GR_CODE","GR_RATE","GR_TAX_RATE","FINE_GL_RATE","MAIN_USER")
       VALUES ('feature-e2e','01',$1,$2,$3::date,$4,$5,$6,$7,72000,'e2eseed')`,
      lc,
      year,
      date,
      sr,
      code,
      rate,
      tax,
    );
  if (ahead) await insert(0, 'DN0', 555, 955);
  for (let i = 1; i <= count; i += 1) await insert(i, `D0${i}`, 100 + i, 900 + i);
}

async function dashboardLabels(page) {
  await page.goto('/dashboard');
  await page.getByTestId('daily-rate-labels').waitFor();
  return page.locator('[data-rate-label]').evaluateAll((els) => els.map((e) => e.textContent));
}
const displayTexts = (n) =>
  Array.from({ length: n }, (_, i) => `Display ${i + 1}  -  ${101 + i}.00`);
const A_LABELS = [
  'Rate Gold 18K  -  54000.00',
  'Rate Gold 22K  -  64031.00',
  'Rate Silver 925  -  763.00',
];
const B_LABELS = [
  'Rate Gold 18K  -  54750.00',
  'Rate Gold 22K  -  64920.00',
  'Rate Silver 925  -  773.00',
];
const EMPTY_LABEL = ['ToDays Rate :'];

/** Save today's A from a location session, return the session page. */
async function saveDay(ctx, who, date, price = priceDay) {
  const page = await open(ctx, date, who);
  await price(page);
  const response = await save(page, date);
  assert.equal(response.status(), 201, await response.text());
  return page;
}

const POST_ERRORS = async (page, payload, raw) =>
  page.evaluate(
    async ({ body, rawText }) =>
      (
        await fetch('/api/daily-rate', {
          method: 'POST',
          credentials: 'include',
          headers: { 'content-type': 'application/json' },
          body: rawText ?? JSON.stringify(body),
        })
      ).status,
    { body: payload, rawText: raw },
  );
const gridRows = (grid) => [
  {
    grCode: 'R18',
    touch: 75,
    taxPct: 0,
    rate: grid.R18[1],
    taxRate: grid.R18[0],
    prRate: grid.R18[2],
  },
  {
    grCode: 'R22',
    touch: 91.6,
    taxPct: 3,
    rate: grid.R22[1],
    taxRate: grid.R22[0],
    prRate: grid.R22[2],
  },
  {
    grCode: 'RSV',
    touch: 92.5,
    taxPct: 3,
    rate: grid.RSV[1],
    taxRate: grid.RSV[0],
    prRate: grid.RSV[2],
  },
];

export const dailyRate = {
  feature: 'daily-rate',
  title: 'Other → Daily Rate (MS_RATE)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/daily-rate/page.tsx',
    'web/apps/api/src/modules/masters/dailyRate.ts',
    'web/apps/api/src/routes/dailyRate.ts',
    'web/packages/core/src/dailyRate.ts',
    'web/apps/web/components/DailyRateLabels.tsx',
    'web/apps/web/app/(app)/dashboard/page.tsx',
    'web/apps/web/test/features/modules/dailyRate.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    companySettings:
      'catalogue defaults; the module adds three rate groups R18, R22 and RSV, locations 00 and 02, employee E01 and the Daily Rate copy entitlement',
  },
  cases: [
    C(
      'entry.rate-master-grid',
      'T01',
      'read-only',
      'MS_RATE.cs:1752-1832: the grid lists the groups with a touch, GR_TYPE then GR_NAME; the date opens on today.',
      async (ctx) => {
        const page = await open(ctx);
        const codes = await page
          .locator('tbody tr td:nth-child(2)')
          .evaluateAll((cells) => cells.map((c) => c.textContent));
        const ours = codes.filter((c) => ['R18', 'R22', 'RSV'].includes(c));
        assert.deepEqual(ours, ['R18', 'R22', 'RSV']);
        assert.equal(await label(page, 'Touch R22').inputValue(), '91.6');
        await ctx.shot(page, 'entry');
        return { observation: `grid order ${ours.join(', ')}`, expected: 'R18, R22, RSV' };
      },
    ),
    notApplicable(
      'branches',
      'T02',
      'MS_RATE.cs:1705-1715 shows purchase and USD rates only for a UAE company.',
      'The fixture company is not UAE; the UAE recalculation is covered by packages/core/test/dailyRate.test.ts.',
    ),
    C(
      'formula.enter-on-silver-recomputes',
      'T03',
      'read-only',
      'MS_RATE.cs:2314-2368: Enter on Silver Rate 1Kg recomputes TaxRate, Rate10gm and PrRate with banker’s rounding.',
      async (ctx) => {
        const page = await open(ctx, nextDay());
        await priceDay(page);
        const grid = await gridOf(page);
        assert.deepEqual(grid, DERIVED);
        return { observation: JSON.stringify(grid), expected: DERIVED };
      },
    ),
    C(
      'refusal.negative-rate-no-write',
      'T06',
      'refusal',
      'MS_RATE grid cells take a rate; a negative rate is refused before anything is written.',
      async (ctx) => {
        const date = nextDay();
        const page = await open(ctx, date);
        await priceDay(page);
        await label(page, 'Rate10gm R18').fill('-5');
        const response = await save(page);
        assert.equal(response.status(), 400, await response.text());
        const rows = await savedRows(ctx, date);
        assert.deepEqual(rows, []);
        return {
          observation: 'negative rate refused',
          expected: '400, no rows',
          database: { rows },
        };
      },
    ),
    C(
      'create.desktop-rows',
      'T07',
      'mutation',
      'MS_RATE.cs:1890-1928: one row per priced group, SR_NO the grid row, the header rates, GR_TYPE and MainUser; no GR_NAME.',
      async (ctx) => {
        const date = nextDay();
        await setEntitlement(ctx, false);
        const page = await open(ctx, date, AT_00);
        await priceDay(page);
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        // MS_RATE.cs:2007 {{Interaction.MsgBox((object)"Data Are Saved.", ...}}: the desktop text, verbatim.
        const savedMsg = page.locator('.msg.ok');
        await savedMsg.waitFor();
        assert.equal((await savedMsg.innerText()).trim(), 'Data Are Saved.');
        const rows = await savedRows(ctx, date);
        assert.deepEqual(
          rows.map((r) => [
            r.gr,
            r.type,
            r.taxrate,
            r.rate,
            r.prrate,
            r.gold,
            r.silver,
            r.user,
            r.lc,
            r.name,
          ]),
          [
            ['R18', 'G', 54000, 54000, 54720, 72000, 85000, USERS.admin.user, '00', null],
            ['R22', 'G', 65952, 64031, 66240, 72000, 85000, USERS.admin.user, '00', null],
            ['RSV', 'S', 786, 763, 765, 72000, 85000, USERS.admin.user, '00', null],
          ],
        );
        assert(rows[0].sr < rows[1].sr && rows[1].sr < rows[2].sr, 'SR_NO follows the grid order');
        assert.deepEqual(await groupRates(ctx), [
          ['R18', 54000],
          ['R22', 64031],
          ['RSV', 763],
        ]);
        assert.equal((await allRates(ctx)).filter((r) => r.d === date && r.lc !== '00').length, 0);
        await ctx.shot(page, 'saved');
        return {
          observation: `${rows.length} rows saved for ${date} at location 00, group rates updated, no copy`,
          expected:
            'three priced rows in grid order at 00, groups [54000,64031,763], no destination row',
          database: { rows, groups: await groupRates(ctx) },
          downstream: { rows },
        };
      },
    ),
    C(
      'save.clears-the-form',
      'T07',
      'mutation',
      'MS_RATE.cs:2007-2016 and CLEAR_DATA (:1728-1749): after "Data Are Saved." every text box is blank, the grid is cleared, Vch Date is today and holds the cursor; MsDailyRateGen (company-opening wizard only, MS_OPNCOMP.cs:1377) would close the form instead.',
      async (ctx) => {
        const date = nextDay();
        const page = await open(ctx, date);
        await priceDay(page);
        await label(page, 'Employee').fill('E01');
        await label(page, 'Employee').blur();
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        assert.equal((await page.locator('.msg.ok').innerText()).trim(), 'Data Are Saved.');
        const after = {
          date: await label(page, 'Vch Date').inputValue(),
          gold: await label(page, 'Gold Rate 10gm').inputValue(),
          silver: await label(page, 'Silver Rate 1Kg').inputValue(),
          employee: await label(page, 'Employee').inputValue(),
          gridRows: await page.locator('input[aria-label^="Rate10gm"]').count(),
          focused: await page.evaluate(() => document.activeElement?.id),
          saveDisabled: await page.locator('button[data-save-mnemonic]').isDisabled(),
        };
        assert.deepEqual(after, {
          date: todayLocal(),
          gold: '',
          silver: '',
          employee: '',
          gridRows: 0,
          focused: 'daily-rate-date',
          saveDisabled: true,
        });
        const rows = await savedRows(ctx, date);
        assert.equal(rows.length, 3, 'the day is saved');
        // The day is read again only when the cursor leaves Vch Date (DISPLAY_DATA).
        await reopen(page, date);
        assert.equal(await label(page, 'Gold Rate 10gm').inputValue(), '72000.00');
        return {
          observation: JSON.stringify(after),
          expected: 'blank rates and employee, empty grid, date today with focus, Save disabled',
          database: { rows },
          downstream: { cleared: true },
        };
      },
    ),
    notApplicable(
      'settlement',
      'T06',
      'MS_RATE writes RATE_MAST only.',
      'A daily rate has no tender, ledger or stock effect.',
    ),
    C(
      'reopen.f1-list',
      'T04',
      'mutation',
      'MS_RATE.cs:2370-2396: F1 lists saved days (date, user, gold, silver); choosing one shows its grid.',
      async (ctx) => {
        const date = nextDay();
        let page = await open(ctx, date);
        await priceDay(page);
        assert.equal((await save(page)).status(), 201);
        page = await open(ctx);
        await page.getByRole('button', { name: 'F1', exact: true }).click();
        const shown = date.split('-').reverse().join('/');
        await page.getByRole('button', { name: `Open ${shown}`, exact: true }).click();
        await page.waitForFunction(() => {
          const el = document.querySelector('input[aria-label="Rate10gm R22"]');
          return el && el.value === '64031';
        });
        const grid = await gridOf(page);
        assert.deepEqual(grid, DERIVED);
        assert.equal(await label(page, 'Gold Rate 10gm').inputValue(), '72000.00');
        return {
          observation: `reopened ${date}: ${JSON.stringify(grid)}`,
          expected: DERIVED,
          database: { rows: await savedRows(ctx, date) },
          downstream: { reopened: date },
        };
      },
    ),
    C(
      'edit.unchanged-save',
      'T08',
      'mutation',
      'MS_RATE.cs:1888-1928 deletes and rewrites the day; an unchanged save leaves the same rows.',
      async (ctx) => {
        const date = nextDay();
        const page = await open(ctx, date);
        await priceDay(page);
        assert.equal((await save(page, date)).status(), 201);
        const before = await savedRows(ctx, date);
        await reopen(page, date);
        assert.equal((await save(page, date)).status(), 201);
        const after = await savedRows(ctx, date);
        assert.deepEqual(after, before);
        return {
          observation: `unchanged re-save of ${date} kept ${after.length} rows`,
          expected: 'identical rows',
          database: { before, after },
          downstream: { unchanged: true },
        };
      },
    ),
    C(
      'edit.unpriced-group-skipped',
      'T09',
      'mutation',
      'MS_RATE.cs:1888-1893: a re-save deletes the day and writes only rows with a Rate10gm.',
      async (ctx) => {
        const date = nextDay();
        const page = await open(ctx, date);
        await priceDay(page);
        assert.equal((await save(page, date)).status(), 201);
        await reopen(page, date);
        await label(page, 'Rate10gm R18').fill('');
        assert.equal((await save(page)).status(), 201);
        const rows = await savedRows(ctx, date);
        assert.deepEqual(
          rows.map((r) => r.gr),
          ['R22', 'RSV'],
        );
        return {
          observation: `after clearing R18: ${rows.map((r) => r.gr).join(', ')}`,
          expected: 'R22, RSV',
          database: { rows },
          downstream: { rows },
        };
      },
    ),
    C(
      'delete.day',
      'T10',
      'mutation',
      'MS_RATE.cs:2095-2109: "Are You Sure To Delete This Day Rate?" then the day is removed.',
      async (ctx) => {
        const date = nextDay();
        const page = await open(ctx, date);
        await priceDay(page);
        assert.equal((await save(page)).status(), 201);
        await reopen(page, date);
        await Promise.all([
          page.waitForResponse(
            (r) =>
              r.request().method() === 'DELETE' && new URL(r.url()).pathname === '/api/daily-rate',
          ),
          page.getByRole('button', { name: 'Delete', exact: true }).click(),
        ]);
        const rows = await savedRows(ctx, date);
        assert.deepEqual(rows, []);
        return {
          observation: `deleted ${date}`,
          expected: 'no rows',
          database: { rows },
          downstream: { deleted: true },
        };
      },
    ),
    C(
      'scope.no-rights-user',
      'T11',
      'refusal',
      "MS_RATE.cs:1867-1886, 2095, 1834: Rate Master saves, deletes and prints only with the user's rights; a user with no Daily Rate rights is refused all three",
      async (ctx) => {
        const date = nextDay();
        const admin = await open(ctx, date);
        await priceDay(admin);
        assert.equal((await save(admin)).status(), 201);
        const before = await savedRows(ctx, date);
        const clerk = await ctx.session(as(USERS.clerk.user));
        await clerk.page.goto('/txn/sales');
        const statuses = await clerk.page.evaluate(async (d) => {
          const call = async (method, url, body) =>
            (
              await fetch(url, {
                method,
                credentials: 'include',
                headers: body ? { 'content-type': 'application/json' } : {},
                body: body ? JSON.stringify(body) : undefined,
              })
            ).status;
          return {
            read: await call('GET', `/api/daily-rate?date=${d}`),
            print: await call('GET', `/api/daily-rate/print?date=${d}&format=html`),
            delete: await call('DELETE', `/api/daily-rate?date=${d}`),
            save: await call('POST', '/api/daily-rate', {
              date: d,
              goldRate: 1,
              silverRate: 1,
              rows: [],
            }),
          };
        }, date);
        for (const [what, status] of Object.entries(statuses))
          assert.ok(status === 403, `${what} refused for a user without the right: ${status}`);
        assert.deepEqual(await savedRows(ctx, date), before);
        return {
          observation: `read ${statuses.read}, print ${statuses.print}, delete ${statuses.delete}, save ${statuses.save}`,
          expected: '403 on all four, the day untouched',
          database: { rows: before },
        };
      },
    ),
    C(
      'concurrency.two-operators-same-day',
      'T12',
      'mutation',
      'MS_RATE.cs:1867-1947 deletes and rewrites the day with no version check, so two operators saving one day leave exactly one complete set of rows (the last writer wins), never a mixture or duplicates',
      async (ctx) => {
        const date = nextDay();
        const a = await open(ctx, date);
        const second = await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#2`));
        const b = second.page;
        await b.goto('/txn/daily-rate');
        await b.getByRole('heading', { name: 'Rate Master', exact: true }).waitFor();
        await label(b, 'Touch R22').waitFor();
        await selectDay(b, date);
        await priceDay(a);
        await label(b, 'Gold Rate 10gm').fill('73000');
        await label(b, 'Silver Rate 1Kg').fill('86000');
        await label(b, 'Silver Rate 1Kg').press('Enter');
        await b.waitForFunction(
          () => document.querySelector('input[aria-label="Rate10gm R22"]')?.value,
        );
        const [first, other] = await Promise.all([save(a), save(b)]);
        const statuses = [first.status(), other.status()];
        assert.ok(
          statuses.every((s) => s === 201 || s === 409),
          `statuses ${statuses}: ${(await first.text()).slice(0, 160)} | ${(await other.text()).slice(0, 160)}`,
        );
        assert.ok(statuses.includes(201));
        const rows = await savedRows(ctx, date);
        assert.deepEqual(
          rows.map((r) => r.gr),
          ['R18', 'R22', 'RSV'],
          'one complete set, no duplicates',
        );
        assert.equal(new Set(rows.map((r) => r.gold)).size, 1, "one writer's rates, not a mixture");
        assert.ok([72000, 73000].includes(rows[0].gold));
        return {
          observation: `statuses ${statuses.join(', ')}; the day holds the ${rows[0].gold} set`,
          expected: 'three rows from a single writer',
          database: { rows },
          downstream: { gold: rows[0].gold },
        };
      },
    ),
    C(
      'retry.replayed-save',
      'T13',
      'mutation',
      'A replayed save writes the same day again (delete and rewrite): still one set of rows with the same rates',
      async (ctx) => {
        const date = nextDay();
        const page = await open(ctx, date);
        await priceDay(page);
        const first = await save(page);
        assert.equal(first.status(), 201, await first.text());
        const before = await savedRows(ctx, date);
        const replay = await page.request.fetch(first.request());
        assert.equal(replay.status(), 201, await replay.text());
        const after = await savedRows(ctx, date);
        assert.deepEqual(after, before);
        return {
          observation: `the replay answered ${replay.status()}`,
          expected: 'identical rows, no duplicates',
          database: { rows: after },
          downstream: { rows: after.length },
        };
      },
    ),
    C(
      'rollback.rate-write-fault',
      'T14',
      'mutation',
      'A fault while rewriting a saved day rolls back the delete too: the day keeps its earlier rates',
      async (ctx) => {
        const date = nextDay();
        const page = await open(ctx, date);
        await priceDay(page);
        assert.equal((await save(page)).status(), 201);
        await reopen(page, date);
        const before = await savedRows(ctx, date);
        await ctx.owner.$executeRawUnsafe(
          `CREATE OR REPLACE FUNCTION e2e_rate_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
           BEGIN
             IF NEW."VCH_DATE" = '${date}'::date AND NEW."GR_CODE" = 'RSV' THEN RAISE EXCEPTION 'e2e rate fault'; END IF;
             RETURN NEW;
           END $f$`,
        );
        await ctx.owner.$executeRawUnsafe(
          `CREATE TRIGGER e2e_rate_fault BEFORE INSERT ON "RATE_MAST" FOR EACH ROW EXECUTE FUNCTION e2e_rate_fault()`,
        );
        try {
          await label(page, 'Gold Rate 10gm').fill('74000');
          await label(page, 'Silver Rate 1Kg').press('Enter');
          const response = await save(page);
          assert.ok(response.status() >= 400, `the save failed: ${response.status()}`);
          const after = await savedRows(ctx, date);
          assert.deepEqual(after, before);
          return {
            observation: `the save answered ${response.status()}; the day kept ${after[0]?.gold}`,
            expected: 'the earlier three rows',
            database: { rows: after },
            downstream: { rows: after.length },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS e2e_rate_fault ON "RATE_MAST"`);
          await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_rate_fault()`);
        }
      },
    ),
    C(
      'print.rate-report',
      'T16',
      'output',
      'MS_RATE.cs:1834-1866 and RateRpt.spec.json: Daily Rate Report dd/MM/yyyy with Group Name and Rate 10gm.',
      async (ctx) => {
        const date = nextDay();
        const page = await open(ctx, date);
        await priceDay(page);
        assert.equal((await save(page)).status(), 201);
        const response = await page.request.get(`/api/daily-rate/print?date=${date}&format=html`);
        const html = await response.text();
        assert.equal(response.status(), 200, html.slice(0, 200));
        const [y, m, d] = date.split('-');
        for (const text of [
          `Daily Rate Report ${d}/${m}/${y}`,
          'Group Name',
          'Rate 10gm',
          'Rate Gold 22K',
          '64,031.00',
          '763.00',
        ])
          assert(html.includes(text), `RateRpt shows ${text}`);
        return {
          observation: `RateRpt ${html.length} bytes`,
          expected: 'the report title, columns and rates',
          output: Buffer.from(html),
        };
      },
    ),
    C(
      'keyboard.alt-s-saves',
      'T17',
      'mutation',
      'MS_RATE &Save is the Alt+S mnemonic.',
      async (ctx) => {
        const date = nextDay();
        const page = await open(ctx, date);
        await priceDay(page);
        const [response] = await Promise.all([
          page.waitForResponse(
            (r) =>
              r.request().method() === 'POST' && new URL(r.url()).pathname === '/api/daily-rate',
          ),
          page.keyboard.press('Alt+s'),
        ]);
        assert.equal(response.status(), 201, await response.text());
        const rows = await savedRows(ctx, date);
        assert.equal(rows.length, 3);
        return {
          observation: 'Alt+S saved the day',
          expected: 'three rows',
          database: { rows },
          downstream: { rows: rows.length },
        };
      },
    ),
    C(
      'downstream.rate-lookup-own-location',
      'T18',
      'mutation',
      "TR_SALE.cs:12547 reads the day's RATE_MAST rows for the user's CO_CODE and LC_CODE: the rate lookup behind the sale forms and the ticker returns this location's saved rate, not a later one saved at another location",
      async (ctx) => {
        const date = nextDay();
        const page = await open(ctx, date);
        await priceDay(page);
        assert.equal((await save(page)).status(), 201);
        const later = new Date(`${date}T00:00:00Z`);
        later.setUTCDate(later.getUTCDate() + 1);
        const laterDay = later.toISOString().slice(0, 10);
        await ctx.owner.$executeRawUnsafe(
          `DO $d$ BEGIN
             CREATE TEMP TABLE e2e_rate_copy ON COMMIT DROP AS
               SELECT * FROM "RATE_MAST" WHERE tenant_id='feature-e2e' AND "CO_CODE"='01' AND "VCH_DATE"='${date}'::date AND "GR_CODE"='R22';
             UPDATE e2e_rate_copy SET "LC_CODE"='98', "VCH_DATE"='${laterDay}'::date, "GR_RATE"=11111;
             INSERT INTO "RATE_MAST" SELECT * FROM e2e_rate_copy;
           END $d$`,
        );
        try {
          const lookup = await (
            await page.request.get(`/api/rate?group=R22&date=${laterDay}`)
          ).json();
          assert.equal(
            lookup.rate,
            DERIVED.R22[1],
            `this location's rate, not 11111: ${JSON.stringify(lookup)}`,
          );
          assert.equal(lookup.date, date);
          return {
            observation: `the lookup for ${laterDay} returned ${lookup.rate} dated ${lookup.date}`,
            expected: `${DERIVED.R22[1]} from this location`,
            database: { other: 11111 },
            downstream: { lookup },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "RATE_MAST" WHERE tenant_id='feature-e2e' AND "CO_CODE"='01' AND "LC_CODE"='98'`,
          );
        }
      },
    ),
    // ---- WP-33 residuals ------------------------------------------------------------------------------------
    C(
      'entry.shortcut-rights',
      'T01',
      'refusal',
      'MDI_FORM.cs:12526-12528, :14395-14405: Ctrl+F1 opens Daily Rate; view rights refuse with desktop text.',
      async (ctx) => {
        await ensureWorld(ctx);
        const { page } = await ctx.session();
        await page.goto('/dashboard');
        await page.getByRole('main').waitFor();
        await page.keyboard.press('Control+F1');
        await page.waitForURL('**/txn/daily-rate');
        await dayShown(page);
        await label(page, 'Touch R22').waitFor();
        const before = await allRates(ctx);
        const clerk = await ctx.session(as(USERS.clerk.user));
        await clerk.page.goto('/txn/sales');
        await clerk.page.getByRole('main').waitFor();
        await clerk.page.keyboard.press('Control+F1');
        await clerk.page.waitForURL('**/txn/daily-rate');
        await clerk.page
          .getByRole('alert')
          .filter({ hasText: 'You Have No Rights.....' })
          .waitFor();
        assert.equal(await label(clerk.page, 'Touch R22').count(), 0);
        assert.deepEqual(await allRates(ctx), before);
        return {
          observation:
            'Ctrl+F1 opened the rate grid for admin and displayed the desktop refusal for clerk',
          expected: 'You Have No Rights.....',
          database: { unchanged: true },
        };
      },
    ),
    C(
      'field.net-rate-route',
      'T02',
      'mutation',
      'MS_RATE.cs:1920: GR_RATE is the displayed net Rate10gm, not TaxRate; MDI_FORM.cs:11429 shows GR_NAME, two spaces, hyphen, two spaces, GR_RATE.',
      async (ctx) => {
        await resetWorld(ctx, false);
        const date = todayLocal();
        const page = await open(ctx, date, AT_00);
        assert.equal(await sessionLocation(page), '00');
        await priceDay(page);
        await label(page, 'Rate10gm R22').fill('64032');
        await label(page, 'Employee').fill('E01');
        await label(page, 'Employee').blur();
        const response = await save(page, date);
        assert.equal(response.status(), 201, await response.text());
        const rows = await rowsAt(ctx, '00', date);
        const r22 = rows.find((r) => r.gr === 'R22');
        assert.deepEqual([r22.rate, r22.taxrate, r22.emp], [64032, 65952, 'E01']);
        assert.deepEqual(await groupRates(ctx), [
          ['R18', 54000],
          ['R22', 64032],
          ['RSV', 763],
        ]);
        const labels = await dashboardLabels(page);
        assert.equal(labels[1], 'Rate Gold 22K  -  64032.00');
        return {
          observation: `R22 stored ${r22.rate}, tax rate ${r22.taxrate}; label ${labels[1]}`,
          expected: 'GR_RATE 64032 (not recomputed), GR_TAX_RATE 65952, EMP_CODE E01',
          database: { rows, groups: await groupRates(ctx) },
          downstream: { labels },
        };
      },
    ),
    {
      ...C(
        'field.copy-optional-projection',
        'T02',
        'read-only',
        'MS_RATE.cs:1945: optional copy projection.',
        async () => ({}),
      ),
      applicable: false,
      reason:
        'DB-layer coverage: apps/api/test/dailyRate.copy.db.test.ts asserts all 26 projected columns including NULL versus zero. The UAE form is not reachable from this non-UAE browser fixture.',
    },
    C(
      'children.destination-ownership',
      'T05',
      'mutation',
      'MS_RATE.cs:1944-1946: each destination location is deleted for the day and refilled from 00; nothing is appended.',
      async (ctx) => {
        await resetWorld(ctx, true);
        const date = todayLocal();
        const year = await fiscalYearOf(ctx);
        const seed = (lc, d, sr, code, rate) =>
          ctx.owner.$executeRawUnsafe(
            `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","VCH_DATE","SR_NO","GR_CODE","GR_RATE","MAIN_USER")
             VALUES ('feature-e2e','01',$1,$2,$3::date,$4,$5,$6,'e2eseed')`,
            lc,
            year,
            d,
            sr,
            code,
            rate,
          );
        await seed('01', date, 1, 'R18', 1);
        await seed('02', date, 1, 'R22', 2);
        await seed('02', date, 2, 'RSV', 3);
        await seed('98', date, 1, 'R18', 98);
        await seed('01', addDays(date, -1), 1, 'R18', 7);
        const unrelatedBefore = (await allRates(ctx)).filter((r) => r.lc === '98' || r.d !== date);
        await saveDay(ctx, AT_00, date);
        const all = await allRates(ctx);
        for (const lc of LOCATIONS) {
          const rows = all.filter((r) => r.lc === lc && r.d === date);
          assert.deepEqual(
            rows.map((r) => [r.sr, r.gr, r.rate]),
            [
              [1, 'R18', 54000],
              [2, 'R22', 64031],
              [3, 'RSV', 763],
            ],
            `location ${lc}`,
          );
        }
        assert.deepEqual(
          all.filter((r) => r.lc === '98' || r.d !== date),
          unrelatedBefore,
        );
        return {
          observation:
            'three rows per location, old destination rows gone, unrelated day and location 98 unchanged',
          expected: 'replace, never append',
          database: { rows: all },
          downstream: { unrelated: unrelatedBefore.length },
        };
      },
    ),
    C(
      'refusal.zero-touch-or-rate',
      'T06',
      'mutation',
      'MS_RATE.cs:1900-1912: a row is stored only when Touch and Rate10gm are both non-zero; skipped groups keep their rate.',
      async (ctx) => {
        await resetWorld(ctx, false);
        const date = todayLocal();
        const page = await open(ctx, date, AT_00);
        await priceDay(page);
        await label(page, 'Touch R18').fill('0');
        await label(page, 'Rate10gm R22').fill('0');
        assert.equal((await save(page, date)).status(), 201);
        const rows = await rowsAt(ctx, '00', date);
        assert.deepEqual(
          rows.map((r) => [r.gr, r.rate]),
          [['RSV', 763]],
        );
        const groups = await groupRates(ctx);
        assert.deepEqual(groups, [
          ['R18', 111],
          ['R22', 222],
          ['RSV', 763],
        ]);
        return {
          observation: 'only RSV stored; R18 and R22 groups keep 111 and 222',
          expected: 'zero touch or rate stores nothing and zeroes nothing',
          database: { rows, groups },
          downstream: { groups },
        };
      },
    ),
    C(
      'refusal.invalid-payload',
      'T06',
      'refusal',
      'Hosted validation (A5): malformed rates, unknown groups and over-long employee codes are refused with no write.',
      async (ctx) => {
        await resetWorld(ctx, true);
        const date = todayLocal();
        const page = await open(ctx, date, AT_00);
        const before = { rates: await allRates(ctx), groups: await groupRates(ctx) };
        const rows = gridRows(DERIVED);
        const base = { date, goldRate: 72000, silverRate: 85000, rows };
        const attempts = {
          overflow: await POST_ERRORS(
            page,
            null,
            `{"date":"${date}","goldRate":1e999,"silverRate":1,"rows":[]}`,
          ),
          nan: await POST_ERRORS(page, { ...base, goldRate: 'abc' }),
          unknownGroup: await POST_ERRORS(page, { ...base, rows: [{ ...rows[0], grCode: 'ZZZ' }] }),
          longEmployee: await POST_ERRORS(page, { ...base, empCode: 'ABCD' }),
          negative: await POST_ERRORS(page, { ...base, rows: [{ ...rows[0], rate: -1 }] }),
        };
        for (const [what, status] of Object.entries(attempts)) assert.equal(status, 400, what);
        assert.deepEqual({ rates: await allRates(ctx), groups: await groupRates(ctx) }, before);
        return {
          observation: JSON.stringify(attempts),
          expected: '400 for each, nothing written',
          database: before,
        };
      },
    ),
    C(
      'copy.eligible-two-destinations',
      'T07',
      'mutation',
      'MS_RATE.cs:1937-1949: from location 00 the day is copied to every other location of the company.',
      async (ctx) => {
        await resetWorld(ctx, true);
        const date = todayLocal();
        const year = await fiscalYearOf(ctx);
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","VCH_DATE","SR_NO","GR_CODE","GR_RATE","MAIN_USER")
           VALUES ('feature-e2e','01','98',$1,$2::date,1,'R18',98,'sentinel')`,
          year,
          date,
        );
        const sentinels = (await allRates(ctx)).filter((r) => r.lc === '98');
        const page = await saveDay(ctx, AT_00, date);
        assert.equal(await sessionLocation(page), '00');
        const all = await allRates(ctx);
        const source = all.filter((r) => r.lc === '00');
        assert.equal(source.length, 3);
        for (const lc of ['01', '02'])
          assert.deepEqual(
            all.filter((r) => r.lc === lc).map(({ lc: _lc, ...rest }) => rest),
            source.map(({ lc: _lc, ...rest }) => rest),
            `location ${lc} equals the source`,
          );
        assert.equal(all.filter((r) => r.d === date && r.lc !== '98').length, 9);
        assert.deepEqual(
          all.filter((r) => r.lc === '98'),
          sentinels,
        );
        assert.deepEqual(await groupRates(ctx), A_GROUPS);
        return {
          observation: 'nine rows, three per location; location 98 untouched',
          expected: 'each destination equals the 00 day with its own LC_CODE',
          database: { rows: all, groups: await groupRates(ctx) },
          downstream: { copied: ['01', '02'] },
        };
      },
    ),
    C(
      'copy.disabled-at-zero',
      'T07',
      'mutation',
      'The company entitlement (hosted form of MS_RATE.cs:1937) is off: the 00 save changes the source and the groups only.',
      async (ctx) => {
        await resetWorld(ctx, false);
        const date = todayLocal();
        const year = await fiscalYearOf(ctx);
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","VCH_DATE","SR_NO","GR_CODE","GR_RATE","MAIN_USER")
           VALUES ('feature-e2e','01','01',$1,$2::date,1,'R18',1,'old'),('feature-e2e','01','02',$1,$2::date,1,'R22',2,'old')`,
          year,
          date,
        );
        const before = (await allRates(ctx)).filter((r) => r.lc !== '00');
        await saveDay(ctx, AT_00, date);
        const all = await allRates(ctx);
        assert.equal(all.filter((r) => r.lc === '00').length, 3);
        assert.deepEqual(
          all.filter((r) => r.lc !== '00'),
          before,
        );
        assert.deepEqual(await groupRates(ctx), A_GROUPS);
        return {
          observation: 'source and groups written; 01 and 02 keep their old rows',
          expected: 'no fan-out',
          database: { rows: all },
          downstream: { untouched: before.length },
        };
      },
    ),
    C(
      'copy.enabled-away-from-zero',
      'T07',
      'mutation',
      'MS_RATE.cs:1937: the copy needs location 00; the entitlement alone is not enough.',
      async (ctx) => {
        await resetWorld(ctx, true);
        const date = todayLocal();
        await saveDay(ctx, AT_01, date);
        const all = await allRates(ctx);
        assert.deepEqual(
          all.map((r) => r.lc),
          ['01', '01', '01'],
        );
        assert.deepEqual(await groupRates(ctx), ORIGINAL_GROUPS);
        return {
          observation: 'only location 01 has rows; groups unchanged',
          expected: 'no copy, no group update away from 00',
          database: { rows: all, groups: await groupRates(ctx) },
          downstream: { groups: await groupRates(ctx) },
        };
      },
    ),
    C(
      'reopen.imported-projection',
      'T08',
      'read-only',
      'MS_RATE.cs:1752-1832: reopening a saved day reads it and writes nothing.',
      async (ctx) => {
        await resetWorld(ctx, false);
        const date = todayLocal();
        const year = await fiscalYearOf(ctx);
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","VCH_DATE","SR_NO","GR_CODE","GR_TYPE","GR_TOUCH","GR_TAX_PRC",
             "GR_RATE","GR_TAX_RATE","GR_PR_TOUCH","GR_PR_RATE","FINE_GL_RATE","FINE_SL_RATE","FINE_GL_PR_RATE","FINE_SL_PR_RATE",
             "DOLLAR_GL_RATE","DOLLAR_SL_RATE","EMP_CODE","MAIN_USER","CASH_AMT","ADD_USER","ADD_DATE","AND_TRFR","OP_GL_RATE")
           VALUES ('feature-e2e','01','01',$1,$2::date,2,'R22','G',91.6,3,64031,65952,92,66240,72000,85000,71000,84000,2301.25,27.75,
             'E01','imported',NULL,NULL,NULL,'Y',123.45)`,
          year,
          date,
        );
        const dump = () =>
          ctx.rows(`SELECT * FROM "RATE_MAST" WHERE tenant_id=$1 ORDER BY "LC_CODE","SR_NO"`);
        const before = JSON.stringify(await dump());
        const page = await open(ctx, date, AT_01);
        await page.waitForFunction(
          () => document.querySelector('input[aria-label="Rate10gm R22"]')?.value === '64031',
        );
        assert.equal(await label(page, 'Gold Rate 10gm').inputValue(), '72000.00');
        assert.equal(JSON.stringify(await dump()), before);
        return {
          observation: 'gold 72000.00, R22 64031; the stored row is byte-identical after the read',
          expected: 'read-only',
        };
      },
    ),
    C(
      'edit.all-unpriced-clears-copies',
      'T09',
      'mutation',
      'MS_RATE.cs:1888-1893 and :1937-1949: a save with no priced group deletes the day, and the copy deletes the destinations.',
      async (ctx) => {
        await resetWorld(ctx, true);
        const date = todayLocal();
        const page = await saveDay(ctx, AT_00, date);
        await reopen(page, date);
        for (const code of ['R18', 'R22', 'RSV']) await label(page, `Rate10gm ${code}`).fill('0');
        assert.equal((await save(page, date)).status(), 201);
        const all = await allRates(ctx);
        assert.deepEqual(all, []);
        assert.deepEqual(await groupRates(ctx), A_GROUPS);
        return {
          observation: 'no rows at 00, 01 or 02; group rates stay at A',
          expected: 'zero rows everywhere, groups not reversed',
          database: { rows: all, groups: await groupRates(ctx) },
          downstream: { groups: await groupRates(ctx) },
        };
      },
    ),
    C(
      'cancel.no-reversal',
      'T10',
      'mutation',
      'MS_RATE Cancel only clears the form; nothing already saved is reversed.',
      async (ctx) => {
        await resetWorld(ctx, true);
        const date = todayLocal();
        const page = await saveDay(ctx, AT_00, date);
        const before = { rows: await allRates(ctx), groups: await groupRates(ctx) };
        await reopen(page, date);
        await priceB(page);
        await page.getByRole('button', { name: 'Cancel', exact: true }).click();
        assert.deepEqual({ rows: await allRates(ctx), groups: await groupRates(ctx) }, before);
        return {
          observation: 'unsaved B discarded; A rows at all three locations and group rates intact',
          expected: 'no reversal',
          database: before,
          downstream: { groups: before.groups },
        };
      },
    ),
    C(
      'scope.copy-entitlement-forgery',
      'T11',
      'refusal',
      'A1: the entitlement is server-managed; no request field can grant it or widen the scope.',
      async (ctx) => {
        await resetWorld(ctx, false);
        const date = todayLocal();
        const page = await open(ctx, date, AT_00);
        const before = { rates: await allRates(ctx), groups: await groupRates(ctx) };
        const rows = gridRows(DERIVED);
        const forged = {};
        for (const field of [
          'copyToLocations',
          'copyEnabled',
          'tenantId',
          'coCode',
          'lcCode',
          'eligible',
        ])
          forged[field] = await POST_ERRORS(page, {
            date,
            goldRate: 72000,
            silverRate: 85000,
            rows,
            [field]: field === 'lcCode' ? '01' : true,
          });
        for (const [field, status] of Object.entries(forged)) assert.equal(status, 400, field);
        const config = await page.evaluate(
          async () =>
            (
              await fetch('/api/daily-rate/copy-entitlement', {
                method: 'PUT',
                credentials: 'include',
                headers: { 'content-type': 'application/json' },
                body: '{"enabled":true}',
              })
            ).status,
        );
        assert.ok([403, 404].includes(config), `no route grants the entitlement: ${config}`);
        assert.deepEqual({ rates: await allRates(ctx), groups: await groupRates(ctx) }, before);
        const [entitlement] = await ctx.rows(
          `SELECT enabled FROM "daily_rate_copy_entitlement" WHERE tenant_id=$1`,
        );
        assert.equal(entitlement.enabled, false);
        return {
          observation: `forged fields ${JSON.stringify(forged)}; entitlement route ${config}`,
          expected: 'every forged request refused, entitlement still off, no write',
          database: before,
        };
      },
    ),
    C(
      'concurrency.copy-versus-local-save',
      'T12',
      'mutation',
      'A4 (hosted safety): a 00 copy and a local save of a destination run one after the other; the day is never half of each.',
      async (ctx) => {
        await resetWorld(ctx, true);
        const date = todayLocal();
        const a = await open(ctx, date, AT_00);
        const b = await open(ctx, date, AT_01);
        await priceDay(a);
        await priceB(b);
        const [first, second] = await Promise.all([save(a), save(b)]);
        const statuses = [first.status(), second.status()];
        assert.ok(
          statuses.every((v) => v === 201 || v === 409),
          `statuses ${statuses}`,
        );
        assert.equal(statuses[0], 201, 'the 00 save commits');
        const all = await allRates(ctx);
        for (const lc of ['00', '02'])
          assert.deepEqual(rateOf(all.filter((r) => r.lc === lc)), A_RATES, `location ${lc}`);
        const own = all.filter((r) => r.lc === '01');
        assert.ok(
          JSON.stringify(rateOf(own)) === JSON.stringify(A_RATES) ||
            JSON.stringify(rateOf(own)) === JSON.stringify(B_RATES),
          `01 holds one complete set: ${JSON.stringify(rateOf(own))}`,
        );
        assert.equal(new Set(own.map((r) => r.gold)).size, 1);
        assert.deepEqual(await groupRates(ctx), A_GROUPS);
        return {
          observation: `statuses ${statuses}; 01 holds ${own[0].gold}`,
          expected: '00 and 02 hold A; 01 holds all A or all B',
          database: { rows: all },
          downstream: { groups: await groupRates(ctx) },
        };
      },
    ),
    C(
      'rollback.last-destination-fault',
      'T14',
      'mutation',
      'A4: a fault while writing the last destination rolls the whole save back: no source, group or copy change survives.',
      async (ctx) => {
        await resetWorld(ctx, true);
        const date = todayLocal();
        const page = await saveDay(ctx, AT_00, date);
        const before = { rows: await allRates(ctx), groups: await groupRates(ctx) };
        await ctx.owner.$executeRawUnsafe(
          `CREATE OR REPLACE FUNCTION e2e_copy_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
           BEGIN IF NEW."LC_CODE" = '02' AND NEW."GR_CODE" = 'RSV' AND NEW."GR_RATE" = 773 THEN RAISE EXCEPTION 'e2e copy fault'; END IF; RETURN NEW; END $f$`,
        );
        await ctx.owner.$executeRawUnsafe(
          `CREATE TRIGGER e2e_copy_fault BEFORE INSERT ON "RATE_MAST" FOR EACH ROW EXECUTE FUNCTION e2e_copy_fault()`,
        );
        try {
          await reopen(page, date);
          await priceB(page);
          const response = await save(page);
          assert.ok(response.status() >= 400, `the save failed: ${response.status()}`);
          assert.deepEqual({ rows: await allRates(ctx), groups: await groupRates(ctx) }, before);
          return {
            observation: `the save answered ${response.status()}; every location and group kept A`,
            expected: 'the A snapshot',
            database: before,
            downstream: { groups: before.groups },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS e2e_copy_fault ON "RATE_MAST"`);
          await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_copy_fault()`);
        }
      },
    ),
    C(
      'settings.pending',
      'T15',
      'mutation',
      'MS_RATE.cs:1907-1933 and MS_RATE.cs:1950: a backdated save at 00 sets the group rates, but the main window shows only today.',
      async (ctx) => {
        await resetWorld(ctx, false);
        const today = todayLocal();
        const yesterday = addDays(today, -1);
        const a = await open(ctx, today, AT_00);
        assert.equal(await sessionLocation(a), '00');
        await priceDay(a);
        assert.equal((await save(a, today)).status(), 201);
        const b = await open(ctx, yesterday, AT_00);
        await priceB(b);
        assert.equal((await save(b, yesterday)).status(), 201);
        assert.deepEqual(await groupRates(ctx), B_GROUPS);
        assert.deepEqual(rateOf(await rowsAt(ctx, '00', today)), A_RATES);
        assert.deepEqual(rateOf(await rowsAt(ctx, '00', yesterday)), B_RATES);
        const labels = await dashboardLabels(b);
        assert.deepEqual(labels, A_LABELS);
        return {
          observation: 'groups [54750,64920,773]; today still A; labels show today only',
          expected: 'backdated save changes groups, not today labels',
          database: { rows: await allRates(ctx), groups: await groupRates(ctx) },
          downstream: { labels },
        };
      },
    ),
    C(
      'settings.changed-before-save',
      'T15',
      'mutation',
      'A5: the entitlement is read at save, so a change committed before the save governs that save; posted rates are never repriced.',
      async (ctx) => {
        await resetWorld(ctx, true);
        const date = todayLocal();
        const page = await open(ctx, date, AT_00);
        await priceDay(page);
        await setEntitlement(ctx, false);
        assert.equal((await save(page, date)).status(), 201);
        assert.deepEqual(
          (await allRates(ctx)).map((r) => r.lc),
          ['00', '00', '00'],
        );
        await setEntitlement(ctx, true);
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "GROUP_MAST" SET "GR_TOUCH"=90 WHERE tenant_id='feature-e2e' AND "GR_CODE"='R22'`,
        );
        try {
          await reopen(page, date);
          assert.equal((await save(page, date)).status(), 201);
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `UPDATE "GROUP_MAST" SET "GR_TOUCH"=91.6 WHERE tenant_id='feature-e2e' AND "GR_CODE"='R22'`,
          );
        }
        const all = await allRates(ctx);
        for (const lc of LOCATIONS)
          assert.deepEqual(rateOf(all.filter((r) => r.lc === lc)), A_RATES, lc);
        return {
          observation:
            'first save did not copy, the second (entitlement now on) copied to 01 and 02; R22 stayed 64031',
          expected: 'configuration read at save',
          database: { rows: all },
          downstream: { groups: await groupRates(ctx) },
        };
      },
    ),
    C(
      'copy.cross-year-collision',
      'T15',
      'mutation',
      'MS_RATE.cs:1944-1945: destination delete and source projection omit CO_YEAR; year is copied as data.',
      async (ctx) => {
        await resetWorld(ctx, true);
        const date = todayLocal();
        const year = await fiscalYearOf(ctx);
        const otherYear = year === '1900' ? '1901' : '1900';
        // The key excludes CO_YEAR: an old-year destination occupies the SAME key that the copy will insert.
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","VCH_DATE","SR_NO","GR_CODE","GR_RATE")
           VALUES ('feature-e2e','01','01',$1,$2::date,1,'R18',123)`,
          otherYear,
          date,
        );
        const before = await rowsAt(ctx, '01', date);
        assert.equal(before[0].yr, otherYear);
        const page = await open(ctx, date, AT_00);
        await priceDay(page);
        assert.equal((await save(page, date)).status(), 201);
        const all = await allRates(ctx);
        const source = all.filter((r) => r.lc === '00' && r.d === date);
        assert.equal(source.length, 3);
        for (const lc of ['01', '02']) {
          const destination = all.filter((r) => r.lc === lc && r.d === date);
          assert.deepEqual(
            destination,
            source.map((r) => ({ ...r, lc })),
          );
          assert.ok(destination.every((r) => r.yr === year));
        }
        await reopen(page, date);
        assert.equal(Number(await label(page, 'Rate10gm R18').inputValue()), 54000);
        return {
          observation: 'old-year destination was replaced at the colliding key',
          expected: 'all destinations equal source including CO_YEAR',
          database: { before, rows: all },
          downstream: { reopenedRate: 54000 },
        };
      },
    ),
    ...[
      ['0-eligible', 0],
      ['1-eligible', 1],
      ['7-eligible', 7],
      ['8-eligible', 8],
    ].map(([name, count]) =>
      C(
        `labels.${name}`,
        'T16',
        'output',
        'MDI_FORM.cs:11421-11500 and MS_RATE.cs:1950: today, own location, RATE_DISPLAY = Y, ORDER BY SR_NO, seven labels at most.',
        async (ctx) => {
          await resetWorld(ctx, false);
          await seedDisplay(ctx, { count });
          const { page } = await ctx.session(AT_01);
          const labels = await dashboardLabels(page);
          const expected = count === 0 ? EMPTY_LABEL : displayTexts(Math.min(count, 7));
          assert.deepEqual(labels, expected);
          await ctx.shot(page, 'labels');
          return {
            observation: JSON.stringify(labels),
            expected,
            output: Buffer.from(JSON.stringify(labels)),
          };
        },
      ),
    ),
    ...[
      [
        'foreign-location',
        async (ctx, today) => seedDisplay(ctx, { count: 3, lc: '02', date: today }),
      ],
      ['past-day', async (ctx, today) => seedDisplay(ctx, { count: 3, date: addDays(today, -1) })],
      ['future-day', async (ctx, today) => seedDisplay(ctx, { count: 3, date: addDays(today, 1) })],
      [
        'absent-own-day',
        async (ctx, today) => {
          await seedDisplay(ctx, { count: 3, date: addDays(today, -1) });
          await seedDisplay(ctx, { count: 3, lc: '02', date: today });
        },
      ],
    ].map(([name, seed]) =>
      C(
        `labels.no-fallback-${name}`,
        'T16',
        'output',
        'MDI_FORM.cs:11421-11424: with no row for today at this location the label reads ToDays Rate :, never another day or location.',
        async (ctx) => {
          await resetWorld(ctx, false);
          await seed(ctx, todayLocal());
          const before = await allRates(ctx);
          const { page } = await ctx.session(AT_01);
          const labels = await dashboardLabels(page);
          assert.deepEqual(labels, EMPTY_LABEL);
          assert.deepEqual(await allRates(ctx), before);
          return {
            observation: JSON.stringify(labels),
            expected: EMPTY_LABEL,
            output: Buffer.from(JSON.stringify(labels)),
          };
        },
      ),
    ),
    C(
      'labels.refresh-today',
      'T16',
      'output',
      'A3: the labels read the stored day again after a committed save, without waiting for any poll.',
      async (ctx) => {
        await resetWorld(ctx, false);
        const today = todayLocal();
        const page = await saveDay(ctx, AT_01, today);
        assert.deepEqual(await dashboardLabels(page), A_LABELS);
        await page.goto('/txn/daily-rate');
        await label(page, 'Touch R22').waitFor();
        await priceB(page);
        assert.equal((await save(page, today)).status(), 201);
        const labels = await dashboardLabels(page);
        assert.deepEqual(labels, B_LABELS);
        return {
          observation: JSON.stringify(labels),
          expected: B_LABELS,
          output: Buffer.from(JSON.stringify(labels)),
        };
      },
    ),
    C(
      'labels.refresh-historical',
      'T16',
      'output',
      'MS_RATE.cs:1950: the labels are today RATE_MAST rows, not a backdated day and not GROUP_MAST.GR_RATE.',
      async (ctx) => {
        await resetWorld(ctx, false);
        const today = todayLocal();
        const yesterday = addDays(today, -1);
        await saveDay(ctx, AT_00, today);
        const page = await open(ctx, yesterday, AT_00);
        await priceB(page);
        assert.equal((await save(page, yesterday)).status(), 201);
        const labels = await dashboardLabels(page);
        assert.deepEqual(labels, A_LABELS);
        assert.deepEqual(await groupRates(ctx), B_GROUPS);
        return {
          observation: JSON.stringify(labels),
          expected: A_LABELS,
          output: Buffer.from(JSON.stringify(labels)),
        };
      },
    ),
    C(
      'labels.shrink-clears-surplus',
      'T16',
      'output',
      'A3: each refresh replaces the whole label set; slots with no group are hidden, never left stale.',
      async (ctx) => {
        await resetWorld(ctx, false);
        const today = todayLocal();
        await seedDisplay(ctx, { count: 7 });
        const { page } = await ctx.session(AT_01);
        assert.deepEqual(await dashboardLabels(page), displayTexts(7));
        await ctx.owner.$executeRawUnsafe(
          `DELETE FROM "RATE_MAST" WHERE tenant_id='feature-e2e' AND "GR_CODE" NOT IN ('DN0','D01')`,
        );
        const one = await dashboardLabels(page);
        assert.deepEqual(one, displayTexts(1));
        await ctx.owner.$executeRawUnsafe(`DELETE FROM "RATE_MAST" WHERE tenant_id='feature-e2e'`);
        const none = await dashboardLabels(page);
        assert.deepEqual(none, EMPTY_LABEL);
        assert.equal(await page.locator('[data-rate-label]').count(), 1);
        void today;
        return {
          observation: `${JSON.stringify(one)} then ${JSON.stringify(none)}`,
          expected: 'one label, then the empty text',
          output: Buffer.from(JSON.stringify([one, none])),
        };
      },
    ),
    C(
      'keyboard.grid-and-escape',
      'T17',
      'read-only',
      'MS_RATE.cs:2149-2161, :2178-2259: Enter advances; Escape commits to Save then closes.',
      async (ctx) => {
        await resetWorld(ctx, false);
        const { page } = await ctx.session(AT_00);
        await page.goto('/dashboard');
        await page.getByRole('main').waitFor();
        await page.keyboard.press('Control+F1');
        await page.waitForURL('**/txn/daily-rate');
        await dayShown(page);
        const focused = async (name) =>
          assert.equal(
            await label(page, name).evaluate((el) => el === document.activeElement),
            true,
            name,
          );
        await label(page, 'Touch R18').fill('76');
        await page.keyboard.press('Enter');
        await focused('Tax% R18');
        await page.keyboard.press('Enter');
        await focused('Rate10gm R18');
        await label(page, 'Rate10gm R18').fill('12345');
        await page.keyboard.press('Enter');
        await focused('Rate10gm R22');
        await label(page, 'PrRate R22').focus();
        await page.keyboard.press('Enter');
        await focused('Rate10gm RSV');
        await page.keyboard.press('ArrowUp');
        await focused('Rate10gm R22');
        await page.keyboard.press('ArrowRight');
        await focused('TaxRate R22');
        await page.keyboard.press('Enter');
        await focused('PrTouch R22');
        await page.keyboard.press('Enter');
        await focused('PrRate R22');
        await label(page, 'Rate10gm RSV').focus();
        await page.keyboard.press('Enter');
        assert.equal(
          await page
            .getByRole('button', { name: 'Save', exact: true })
            .evaluate((el) => el === document.activeElement),
          true,
        );
        await label(page, 'Rate10gm R22').fill('45678');
        await page.keyboard.press('Escape');
        assert.equal(await label(page, 'Rate10gm R22').inputValue(), '45678');
        assert.equal(await label(page, 'Rate10gm R18').inputValue(), '12345');
        assert.equal(await label(page, 'Touch R18').inputValue(), '76');
        assert.equal(
          await page
            .getByRole('button', { name: 'Save', exact: true })
            .evaluate((el) => el === document.activeElement),
          true,
        );
        await page.keyboard.press('Escape');
        await page.waitForURL((url) => url.pathname === '/dashboard');
        return {
          observation:
            'Enter and arrows moved focus; Escape retained edits and focused Save; second Escape closed',
          expected: 'desktop grid navigation and commit then close',
        };
      },
    ),
    C(
      'downstream.copy-reopen-display',
      'T18',
      'mutation',
      'The residual chain: a 00 save reaches 01 and 02 as rows, as a printed day and as the main-window label.',
      async (ctx) => {
        await resetWorld(ctx, true);
        const today = todayLocal();
        const source = await saveDay(ctx, AT_00, today);
        const check = async (r22) => {
          for (const who of [AT_01, AT_02]) {
            const { page } = await ctx.session(who);
            await page.goto('/txn/daily-rate');
            await label(page, 'Touch R22').waitFor();
            await selectDay(page, today);
            await page.waitForFunction(
              (v) => document.querySelector('input[aria-label="Rate10gm R22"]')?.value === v,
              String(r22),
            );
            const html = await (
              await page.request.get(`/api/daily-rate/print?date=${today}&format=html`)
            ).text();
            assert(html.includes(`${r22.toLocaleString('en-IN')}.00`), `RateRpt shows ${r22}`);
            const labels = await dashboardLabels(page);
            assert.equal(labels[1], `Rate Gold 22K  -  ${r22}.00`);
          }
        };
        await check(64031);
        await source.goto('/txn/daily-rate');
        await label(source, 'Touch R22').waitFor();
        await selectDay(source, today);
        await source.waitForFunction(
          () => document.querySelector('input[aria-label="Rate10gm R22"]')?.value === '64031',
        );
        await label(source, 'Rate10gm R22').fill('64032');
        assert.equal((await save(source, today)).status(), 201);
        await check(64032);
        assert.deepEqual((await groupRates(ctx))[1], ['R22', 64032]);
        return {
          observation:
            '01 and 02 reopened, printed and displayed 64031, then 64032 after the 00 edit',
          expected: 'copy, reopen, report and label agree',
          database: { rows: await allRates(ctx), groups: await groupRates(ctx) },
          downstream: { r22: 64032 },
        };
      },
    ),
  ],
};
