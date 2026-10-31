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
const DERIVED = { R18: [54000, 54000, 54720], R22: [65952, 64031, 66240], RSV: [786, 763, 765] };
const as = (user, slot) => ({
  user,
  slot,
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
const blocked = (name, group, reason) => ({
  ...C(`${name}.pending`, group, 'read-only', `Playbook ${group}`, async () => ({})),
  blocked: reason,
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
  for (const [code, name, type, touch, tax, prTouch] of GROUPS)
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE","GR_TOUCH","TAX_PRC","GR_PURC_TOUCH")
       SELECT $1::text,'01',$2::text,$3::text,$4::text,$5::float8,$6::numeric,$7::float8
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

async function open(ctx, date) {
  await ensureGroups(ctx);
  const { page } = await ctx.session();
  await page.goto('/txn/daily-rate');
  await page.getByRole('heading', { name: 'Rate Master', exact: true }).waitFor();
  await label(page, 'Touch R22').waitFor();
  if (date)
    await Promise.all([
      page.waitForResponse((r) => r.url().includes(`/api/daily-rate?date=${date}`)),
      label(page, 'Vch Date').fill(date),
    ]);
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

/** Save; with `reloadOf` the helper also waits for the screen to reload that day after a successful save. */
async function save(page, reloadOf) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => r.request().method() === 'POST' && new URL(r.url()).pathname === '/api/daily-rate',
    ),
    ...(reloadOf
      ? [
          page.waitForResponse(
            (r) =>
              r.request().method() === 'GET' &&
              r.url().includes(`/api/daily-rate?date=${reloadOf}`),
          ),
        ]
      : []),
    page.locator('button[data-save-mnemonic]').click(),
  ]);
  return response;
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

export const dailyRate = {
  feature: 'daily-rate',
  title: 'Other → Daily Rate (MS_RATE)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/daily-rate/page.tsx',
    'web/apps/api/src/modules/masters/dailyRate.ts',
    'web/apps/api/src/routes/dailyRate.ts',
    'web/packages/core/src/dailyRate.ts',
    'web/apps/web/test/features/modules/dailyRate.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    companySettings: 'catalogue defaults; the module adds three rate groups R18, R22 and RSV',
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
      'T04',
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
      'T05',
      'mutation',
      'MS_RATE.cs:1890-1928: one row per priced group, SR_NO the grid row, the header rates, GR_TYPE and MainUser; no GR_NAME.',
      async (ctx) => {
        const date = nextDay();
        const page = await open(ctx, date);
        await priceDay(page);
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
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
            ['R18', 'G', 54000, 54000, 54720, 72000, 85000, USERS.admin.user, '01', null],
            ['R22', 'G', 65952, 64031, 66240, 72000, 85000, USERS.admin.user, '01', null],
            ['RSV', 'S', 786, 763, 765, 72000, 85000, USERS.admin.user, '01', null],
          ],
        );
        assert(rows[0].sr < rows[1].sr && rows[1].sr < rows[2].sr, 'SR_NO follows the grid order');
        await ctx.shot(page, 'saved');
        return {
          observation: `${rows.length} rows saved for ${date}`,
          expected: 'three priced rows in grid order',
          database: { rows },
          downstream: { rows },
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
      'T07',
      'mutation',
      'MS_RATE.cs:2370-2396: F1 lists saved days (date, user, gold, silver); choosing one shows its grid.',
      async (ctx) => {
        const date = nextDay();
        let page = await open(ctx, date);
        await priceDay(page);
        assert.equal((await save(page)).status(), 201);
        page = await open(ctx);
        await page.getByRole('button', { name: 'F1', exact: true }).click();
        await page.getByRole('button', { name: `Open ${date}`, exact: true }).click();
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
    blocked(
      'rights',
      'T11',
      'Edit, delete and print rights are covered through HTTP in dailyRate.routes.db.test.ts; the catalogue has no Daily Rate restricted user yet.',
    ),
    blocked('concurrency', 'T12', 'Daily Rate has no version token.'),
    blocked('retry', 'T13', 'Daily Rate POST has no idempotency key; a re-save replaces the day.'),
    blocked('rollback', 'T14', 'No fault injector in the harness yet (G173 / N166).'),
    blocked(
      'settings',
      'T15',
      'Location 00 also sets GROUP_MAST.GR_RATE; covered in the HTTP test.',
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
    blocked(
      'downstream-sale-rate',
      'T18',
      'The sale/purchase rate lookup (rate.ts) does not yet scope RATE_MAST by location as TR_SALE.cs:12547 does.',
    ),
  ],
};
