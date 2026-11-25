import assert from 'node:assert/strict';
import { withWriteFault } from '../faults.mjs';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Company → Open Company (desktop MS_OPNCOMP, web /select).
 *
 * The desktop opens a company, location and year for the signed-in user. The web stores that choice on the session
 * (`POST /context/select`, a serializable transaction). Several sessions opening at the same moment made one of
 * them lose with the raw code `context-transaction-conflict` (G172); the screen now retries it and otherwise explains.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `company-open.${id}`,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence:
    kind === 'mutation'
      ? ['browser', 'expected', 'database', 'downstream']
      : kind === 'refusal'
        ? ['browser', 'expected', 'database']
        : ['browser', 'expected'],
  run,
  ...extra,
});

async function openSelect(page) {
  await page.goto('/select');
  await page.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
  const open = page.getByRole('button', { name: 'Open', exact: true });
  for (let i = 0; i < 100 && !(await open.isEnabled()); i++) await page.waitForTimeout(100);
  assert.ok(await open.isEnabled(), 'Open is enabled once the choices load');
  return open;
}

/** Exercise the active fiscal/lock gate using the real Fine JV editor. */
async function checkVoucherDates(ctx, page, dates) {
  const outcomes = [];
  for (const [index, date] of dates.entries()) {
    await page.goto('/txn/fine-jv');
    await page.getByRole('heading', { name: 'Fine Jv Entry', exact: true }).waitFor();
    await page.getByLabel('Vch Date', { exact: true }).fill(date);
    for (const [row, code] of [
      [1, 'E2ELOC'],
      [2, 'E2EINT'],
    ]) {
      const input = page.getByLabel(`AcCode row ${row}`, { exact: true });
      await input.fill(code);
      await input.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
      await input.press('Enter');
      await page.getByLabel(`Fine row ${row}`, { exact: true }).fill('1');
    }
    const [response] = await Promise.all([
      page.waitForResponse(
        (r) => new URL(r.url()).pathname === '/api/fine-jv' && r.request().method() === 'POST',
      ),
      page.locator('button[data-save-mnemonic]').click(),
    ]);
    assert.equal(response.status(), index === 0 ? 201 : 400, await response.text());
    if (index !== 0) await page.locator('.msg[role="alert"]').waitFor();
    else await removePostedVoucher(ctx, page, await response.json());
    outcomes.push({ date, status: response.status() });
  }
  return outcomes;
}

/** The probe voucher is not part of this feature's evidence: remove it so later Fine JV cases see their own rows only. */
async function removePostedVoucher(ctx, page, { vchNo }) {
  const { coCode, lcCode, coYear } = await scope(page);
  const no = String(vchNo).padStart(5, '0');
  const where = `tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"='FJV'`;
  const args = [ctx.tenantId, coCode, lcCode, coYear];
  const [row] = await ctx.owner.$queryRawUnsafe(
    `SELECT "HD_VCH_NO" hidden FROM "CONTRA_DATA" WHERE ${where} AND "VCH_NO"=$5 LIMIT 1`,
    ...args,
    no,
  );
  for (const table of ['CONTRA_DATA', 'AC_DATA', 'ROJ_MEL_DATA', 'REMARK_DATA'])
    await ctx.owner.$executeRawUnsafe(
      `DELETE FROM "${table}" WHERE ${where} AND "VCH_NO"=$5`,
      ...args,
      no,
    );
  // TEMP_BOOK_DATA carries no year column.
  if (row?.hidden)
    await ctx.owner.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"='FJV' AND "VCH_NO"=$4`,
      ctx.tenantId,
      coCode,
      lcCode,
      row.hidden,
    );
}
const scope = async (page) => {
  const r = await page.request.get('/api/me');
  assert.equal(r.status(), 200);
  const me = await r.json();
  return { coCode: me.coCode, lcCode: me.lcCode, coYear: me.coYear };
};
/**
 * Opens the company and captures the answer inside a route handler: on success the page navigates to the dashboard
 * at once and a plain response listener loses the body.
 */
const openCompany = async (page) => {
  const selectUrl = (url) => new URL(url).pathname === '/api/context/select';
  let captured;
  const done = new Promise((resolve) => {
    captured = resolve;
  });
  const handler = async (route) => {
    if (route.request().method() !== 'POST') return route.fallback();
    const response = await route.fetch();
    const text = await response.text();
    await route.fulfill({ response, body: text });
    captured({
      status: () => response.status(),
      request: () => route.request(),
      text: async () => text,
      json: async () => JSON.parse(text),
    });
  };
  await page.route(selectUrl, handler);
  try {
    await page.getByRole('button', { name: 'Open', exact: true }).click();
    return await done;
  } finally {
    await page.unroute(selectUrl, handler);
  }
};
const lockSettings = async (ctx) =>
  (
    await ctx.rows(
      `SELECT "LAST_DAY_LOCK" flag, "LOCK_DATE"::date::text date FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
    )
  )[0];
const setLock = (ctx, flag, date) =>
  ctx.owner.$executeRawUnsafe(
    `UPDATE "CO_SET" SET "LAST_DAY_LOCK"=$2, "LOCK_DATE"=$3::date WHERE tenant_id=$1 AND "CO_CODE"='01'`,
    ctx.tenantId,
    flag,
    date,
  );
const yesterday = async (ctx) =>
  (await ctx.rows('SELECT (CURRENT_DATE - 1)::text AS day WHERE $1::text IS NOT NULL'))[0].day;
/** A second company with two locations and two years, removed afterwards (only the admin sees it). */
async function withSecondCompany(ctx, body) {
  const t = ctx.tenantId;
  const clean = async () => {
    for (const table of ['LOCT_MAST', 'YEAR_MAST', 'CO_MAST'])
      await ctx.owner.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='02'`,
        t,
      );
  };
  await clean();
  try {
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES ($1,'02','Second Company','01')`,
      t,
    );
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,'02','01','Second Main'),($1,'02','02','Second Branch')`,
      t,
    );
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR") VALUES ($1,'02','2024-2025'),($1,'02','2025-2026')`,
      t,
    );
    return await body();
  } finally {
    await clean();
  }
}
const NA = (name, group, reason) =>
  C(
    `${name}.not-applicable`,
    group,
    'read-only',
    'WP-35 cases.md T02–T18 disposition; MS_OPNCOMP.cs:598 selects context, not a voucher.',
    async () => ({}),
    { applicable: false, reason },
  );

export const companyOpen = {
  feature: 'company-open',
  title: 'Company → Open Company (MS_OPNCOMP, /select)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/test/features/faults.mjs',
    'web/apps/web/app/select/page.tsx',
    'web/apps/web/lib/contextSelection.ts',
    'web/apps/api/src/modules/auth/sessionContextSelection.ts',
    'web/apps/web/test/features/modules/companyOpen.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    companySettings: 'LAST_DAY_LOCK and LOCK_DATE temporarily changed and restored',
  },
  cases: [
    C(
      'entry.lists-choices',
      'T01',
      'read-only',
      'MS_OPNCOMP offers the companies, locations and years the user may open',
      async (ctx) => {
        const { page } = await ctx.session();
        await openSelect(page);
        const company = await page.getByRole('combobox', { name: 'COMPANY' }).inputValue();
        const years = await page
          .getByRole('combobox', { name: 'FINANCIAL YEAR' })
          .locator('option')
          .count();
        assert.equal(company, '01');
        assert.ok(years >= 1, 'at least one year');
        return {
          observation: `company ${company}, ${years} year(s) offered`,
          expected: { company: '01', years: '>= 1' },
        };
      },
    ),
    C(
      'concurrency.sessions-open-at-once',
      'T12',
      'read-only',
      'G172: four sessions of one user pressing Open at the same moment all open the company; none shows a raw code',
      async (ctx) => {
        const sessions = [];
        for (const slot of ['open-1', 'open-2', 'open-3', 'open-4'])
          sessions.push(await ctx.session(as(USERS.admin.user, `company-${slot}`)));
        const buttons = [];
        for (const { page } of sessions) buttons.push(await openSelect(page));
        await Promise.all(buttons.map((button) => button.click()));
        const outcomes = await Promise.all(
          sessions.map(async ({ page }) => {
            try {
              await page.waitForURL(/\/dashboard/, { timeout: 20_000 });
              return 'opened';
            } catch {
              return (await page.locator('body').innerText()).slice(0, 200);
            }
          }),
        );
        assert.deepEqual(
          outcomes,
          ['opened', 'opened', 'opened', 'opened'],
          JSON.stringify(outcomes),
        );
        return {
          observation: `outcomes ${outcomes.join(', ')}`,
          expected: 'all four sessions open the company',
        };
      },
    ),

    C(
      'branches.year-choice-carried',
      'T02',
      'read-only',
      'WP-35 cases.md; MS_OPNCOMP.cs:598 the chosen year selects its database.',
      async (ctx) => {
        const { page } = await ctx.session(as(USERS.admin.user, 'wp35-year'));
        await openSelect(page);
        await page.getByLabel('Financial Year', { exact: true }).selectOption('2024-2025');
        assert.equal((await openCompany(page)).status(), 200);
        await page.waitForURL(/\/dashboard/);
        const selected = await scope(page);
        assert.deepEqual(selected, { coCode: '01', lcCode: '01', coYear: '2024-2025' });
        await openSelect(page);
        assert.equal(
          await page.getByLabel('Financial Year', { exact: true }).inputValue(),
          '2024-2025',
        );
        const dates = await checkVoucherDates(ctx, page, ['2024-06-01', '2023-06-01']);
        return {
          observation: 'Chosen year survives reopen and controls voucher dates',
          expected: selected,
          database: selected,
          downstream: dates,
        };
      },
    ),
    NA(
      'calculations',
      'T03',
      'No visible calculations; month-wise provisioning is outside this Lite fixture.',
    ),
    C(
      'refusals.stale-choice-refused',
      'T04',
      'refusal',
      'WP-35 cases.md D6; MS_OPNCOMP.cs:536 unavailable years reopen help; web refuses stale choices.',
      async (ctx) => {
        const { page } = await ctx.session(as(USERS.admin.user, 'wp35-stale'));
        const before = await scope(page),
          results = [];
        for (const [label, value, code, message] of [
          ['Financial Year', '1999-2000', 'year-unavailable', 'Selected year is not available.'],
          ['Location', 'ZZ', 'location-unavailable', 'Selected location is not available.'],
        ]) {
          await openSelect(page);
          const select = page.getByLabel(label, { exact: true });
          await select.evaluate((el, v) => el.add(new Option(v, v)), value);
          await select.selectOption(value);
          const response = await openCompany(page);
          assert.equal(response.status(), 409);
          assert.equal((await response.json()).error, code);
          await page.getByText(message, { exact: true }).waitFor();
          assert.equal(new URL(page.url()).pathname, '/select');
          assert.deepEqual(await scope(page), before);
          results.push(code);
          // A refused request is deliberately pending: acknowledge current scope before another selection.
          await page.evaluate(() => sessionStorage.clear());
        }
        return {
          observation: results.join(', '),
          expected: '409 and unchanged scope',
          database: before,
        };
      },
    ),
    NA('lines', 'T05', 'No child rows.'),
    NA('settlement', 'T06', 'Choice validity is covered by T04; no numeric settlement.'),
    C(
      'reopen.year-newest-default',
      'T07',
      'read-only',
      'WP-35 cases.md; MS_OPNCOMP.cs:487 orders years descending.',
      async (ctx) => {
        const { page } = await ctx.session(as(USERS.admin.user, 'wp35-newest'));
        await openSelect(page);
        const field = page.getByLabel('Financial Year', { exact: true });
        const years = await field.locator('option').evaluateAll((xs) => xs.map((x) => x.value));
        assert.ok(years.includes('2024-2025') && years.length >= 2);
        assert.deepEqual(years, [...years].sort().reverse());
        assert.equal(await field.inputValue(), years[0]);
        return { observation: years.join(', '), expected: 'Newest first and selected' };
      },
    ),
    NA('unchanged-save', 'T08', 'No record save.'),
    NA('edit', 'T09', 'No stored record editor.'),
    NA('delete', 'T10', 'No delete action.'),
    C(
      'rights.location-scope',
      'T11',
      'read-only',
      'WP-35 cases.md; MS_OPNCOMP.cs:4401-4405 home location precedes user type.',
      async () => ({}),
      {
        blocked:
          'Requires second location, non-A user and home-location fixtures; catalogue has only one location.',
      },
    ),
    C(
      'retry.replayed-selection',
      'T13',
      'read-only',
      'WP-35 cases.md; MDI_FORM.cs:7562 opens the modal once; hosted selection replay is idempotent.',
      async (ctx) => {
        const { page } = await ctx.session(as(USERS.admin.user, 'wp35-replay'));
        const old = await lockSettings(ctx);
        try {
          await setLock(ctx, 'Y', null);
          await openSelect(page);
          const first = await openCompany(page);
          assert.equal(first.status(), 200);
          await page.waitForURL(/\/dashboard/);
          const before = await scope(page),
            lock = await lockSettings(ctx);
          // The recovery retry runs under a reloaded page: same stored body, the page's current session headers.
          const { context } = await (await page.request.get('/api/me')).json();
          const second = await page.request.post('/api/context/select', {
            data: first.request().postData(),
            headers: {
              'content-type': 'application/json',
              'x-session-context-id': context.sessionId,
              'x-session-context-epoch': String(context.contextEpoch),
            },
          });
          assert.equal(second.status(), 200, await second.text());
          assert.equal((await second.json()).replayed, true);
          assert.deepEqual(await lockSettings(ctx), lock);
          assert.deepEqual(await scope(page), before);
          await openSelect(page);
          assert.equal(
            await page.getByLabel('Financial Year', { exact: true }).inputValue(),
            before.coYear,
          );
          return {
            observation: 'Exact selection replayed once',
            expected: { replayed: true },
            database: { before, lock },
          };
        } finally {
          await setLock(ctx, old.flag, old.date);
        }
      },
    ),
    C(
      'rollback.fault',
      'T14',
      'refusal',
      'WP-35 cases.md; MS_OPNCOMP.cs:1505, :666 lock and context must commit together.',
      async (ctx) => {
        const session = await ctx.session(as(USERS.admin.user, 'wp35-open-fault'));
        const { page } = session;
        const old = await lockSettings(ctx);
        try {
          await setLock(ctx, 'Y', null);
          await openSelect(page);
          const before = await scope(page);
          await withWriteFault(ctx, 'auth_session', 'UPDATE', async () => {
            const response = await openCompany(page);
            assert.ok(response.status() >= 400);
            await page.locator('.msg.err').waitFor();
            // An injected database fault answers 500; the browser logs exactly that one failed load, which is expected.
            if (response.status() >= 500) {
              assert.deepEqual(session.consoleErrors, [
                'Failed to load resource: the server responded with a status of 500 (Internal Server Error)',
              ]);
              session.consoleErrors.length = 0;
            }
            assert.equal((await lockSettings(ctx)).date, null);
          });
          assert.deepEqual(await scope(page), before);
          // The refused selection stays saved in the tab; its retry replays the same operation.
          await page.goto('/select');
          await page.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
          const retry = page.getByRole('button', {
            name: 'Retry saved company change',
            exact: true,
          });
          for (let i = 0; i < 100 && !(await retry.isEnabled()); i++)
            await page.waitForTimeout(100);
          const [retried] = await Promise.all([
            page.waitForResponse(
              (r) =>
                new URL(r.url()).pathname === '/api/context/select' &&
                r.request().method() === 'POST',
            ),
            retry.click(),
          ]);
          assert.equal(retried.status(), 200);
          await page.waitForURL(/\/dashboard/);
          assert.equal((await lockSettings(ctx)).date, await yesterday(ctx));
          return {
            observation: 'Failed open preserves scope and lock; retry commits',
            expected: 'Atomic context selection',
            database: { before, lock: await lockSettings(ctx) },
          };
        } finally {
          await setLock(ctx, old.flag, old.date);
        }
      },
    ),
    C(
      'settings.last-day-lock',
      'T15',
      'mutation',
      'WP-35 cases.md D5; MS_OPNCOMP.cs:1503-1505 sets yesterday; web retains a later lock.',
      async (ctx) => {
        const { page } = await ctx.session(as(USERS.admin.user, 'wp35-lock'));
        const old = await lockSettings(ctx);
        try {
          await setLock(ctx, 'Y', null);
          await openSelect(page);
          const response = await openCompany(page);
          assert.equal(response.status(), 200);
          assert.equal(
            (await response.json()).lastDayLock?.applied,
            true,
            'Open must return lastDayLock.applied',
          );
          await page.waitForURL(/\/dashboard/);
          const lock = await lockSettings(ctx);
          assert.equal(lock.date, await yesterday(ctx));
          const [{ today }] = await ctx.rows(
            'SELECT CURRENT_DATE::text today WHERE $1::text IS NOT NULL',
          );
          const dates = await checkVoucherDates(ctx, page, [today, lock.date]);
          return {
            observation: 'Yesterday locked; today saves',
            expected: lock.date,
            database: lock,
            downstream: dates,
          };
        } finally {
          await setLock(ctx, old.flag, old.date);
        }
      },
    ),
    C(
      'settings.settings-in-force',
      'T15',
      'read-only',
      'WP-35 cases.md; MS_OPNCOMP.cs:668, :691 loads company-specific rounding.',
      async () => ({}),
      {
        blocked:
          'G174: requires a second company with different settings in the fixture catalogue.',
      },
    ),
    NA('output', 'T16', 'No print or export.'),
    C(
      'keyboard.tab-and-enter',
      'T17',
      'read-only',
      'WP-35 cases.md; MS_OPNCOMP.cs:493, :4396 company to location focus and Enter.',
      async (ctx) => {
        const session = await ctx.session(as(USERS.admin.user, 'wp35-keyboard'));
        const { page } = session;
        const focused = (label) =>
          page.getByLabel(label, { exact: true }).evaluate((el) => el === document.activeElement);
        // MS_OPNCOMP.cs:487-493, :509-520, :4391-4454: after a CHANGED company, Enter still walks Company -> Location
        // -> Year on that company's own choices and only Enter on the Year opens.
        await withSecondCompany(ctx, async () => {
          await openSelect(page);
          const opened = [];
          const selectUrl = (url) => new URL(url).pathname === '/api/context/select';
          const abortOpen = (route) => {
            if (route.request().method() !== 'POST') return route.fallback();
            opened.push(route.request().postDataJSON());
            return route.abort();
          };
          await page.route(selectUrl, abortOpen);
          const changed = page.getByLabel('Company', { exact: true });
          await changed.focus();
          await changed.selectOption('02');
          await changed.press('Enter');
          await page.waitForFunction(
            () => document.getElementById('context-location')?.options.length === 2,
          );
          assert.ok(await focused('Location'), 'Enter on a changed Company focuses Location');
          assert.deepEqual(opened, [], 'Enter on Company does not open');
          assert.deepEqual(
            await page
              .getByLabel('Financial Year', { exact: true })
              .locator('option')
              .evaluateAll((xs) => xs.map((x) => x.value)),
            ['2025-2026', '2024-2025'],
            "the target company's years, newest first",
          );
          await page.getByLabel('Location', { exact: true }).selectOption('02');
          await page.keyboard.press('Enter');
          assert.ok(await focused('Financial Year'), 'Enter on Location focuses Financial Year');
          assert.deepEqual(opened, [], 'Enter on Location does not open');
          await page.keyboard.press('Enter');
          for (let i = 0; i < 50 && !opened.length; i++) await page.waitForTimeout(100);
          assert.equal(opened.length, 1, 'Enter on Year opens');
          assert.deepEqual(
            { coCode: opened[0].coCode, lcCode: opened[0].lcCode, coYear: opened[0].coYear },
            { coCode: '02', lcCode: '02', coYear: '2025-2026' },
          );
          await page.unroute(selectUrl, abortOpen);
          // The deliberately aborted open is logged by the browser once; it is not a defect.
          session.consoleErrors.length = 0;
          await page.evaluate(() => sessionStorage.clear());
        });
        await openSelect(page);
        const company = page.getByLabel('Company', { exact: true });
        await company.focus();
        await company.press('ArrowDown');
        // MS_OPNCOMP.cs:493 / :4454: Enter on Company focuses Location, Enter on Location focuses Year.
        await company.press('Enter');
        assert.ok(await focused('Location'), 'Enter on Company focuses Location');
        await page.keyboard.press('Enter');
        assert.ok(await focused('Financial Year'), 'Enter on Location focuses Financial Year');
        await page.keyboard.press('Tab');
        assert.ok(
          await page
            .getByRole('button', { name: 'Open', exact: true })
            .evaluate((el) => el === document.activeElement),
          'Tab reaches Open',
        );
        await page.keyboard.press('Enter');
        await page.waitForURL(/\/dashboard/);
        return {
          observation: 'Enter walks Company → Location → Year; Tab reaches Open; Enter opens',
          expected: 'Keyboard selection',
        };
      },
    ),
    C(
      'journey.open-then-dashboard',
      'T18',
      'read-only',
      'WP-35 cases.md; MDI_FORM.cs:7562 company modal precedes dashboard.',
      async (ctx) => {
        const { page } = await ctx.session(as(USERS.admin.user, 'wp35-journey'));
        await openSelect(page);
        const year = await page.getByLabel('Financial Year', { exact: true }).inputValue();
        assert.equal((await openCompany(page)).status(), 200);
        await page.waitForURL(/\/dashboard/);
        await page.locator('h1').waitFor();
        assert.deepEqual(await scope(page), { coCode: '01', lcCode: '01', coYear: year });
        await page.getByRole('button', { name: /sign out|log out|logout/i }).click();
        await page.waitForURL(/\/login/);
        await page.getByLabel('Company Code', { exact: true }).fill('01');
        await page.getByLabel('User', { exact: true }).fill(USERS.admin.user);
        await page.getByLabel('Password', { exact: true }).fill(process.env.FEATURE_E2E_PASSWORD);
        await page.getByRole('button', { name: /sign in/i }).click();
        await page.waitForURL(/\/select|\/dashboard/);
        assert.equal((await scope(page)).coCode, '01');
        return {
          observation: 'Open → dashboard → sign out → sign in preserves company',
          expected: { coCode: '01', lcCode: '01', coYear: year },
        };
      },
    ),
  ],
};
