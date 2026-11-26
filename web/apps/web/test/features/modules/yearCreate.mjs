import assert from 'node:assert/strict';
import { TENANT, switchCompany, purgeCompany, purgeYear } from '../harness.mjs';
import { changedTables, tenantFingerprint } from '../faults.mjs';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const base = (id, group, kind, source, run, extra = {}) => ({
  id: `year-create.${id}`,
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
const notApplicable = (id, group, source, reason) => ({
  ...base(`${id}.not-applicable`, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});
const yearRows = (ctx) =>
  ctx.rows(
    `SELECT "CO_YEAR","OP_DATE",to_char("CL_DATE",'YYYY-MM-DD') "CL_DATE","YEAR_MONTH","OLD_METHOD" FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "CO_YEAR"`,
  );
const dropYears = (ctx, years) =>
  ctx.owner.$executeRawUnsafe(
    `DELETE FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "CO_YEAR" = ANY($2::text[])`,
    TENANT,
    years,
  );
async function apiPost(page, data) {
  const me = await (await page.request.get('/api/me')).json();
  const response = await page.request.fetch('/api/years', {
    method: 'POST',
    headers: {
      'x-session-context-id': me.context.sessionId,
      'x-session-context-epoch': me.context.contextEpoch,
    },
    data,
  });
  return { status: response.status(), body: await response.json().catch(() => ({})) };
}

const BARE = { code: '03', name: 'E2E FIRST YEAR COMPANY' };
const FIRST_YEAR = '2030-2031';
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);

/** Rows per table of the company, for every table that has tenant_id and CO_CODE. */
async function companyCounts(ctx, coCode) {
  const tables = await ctx.owner.$queryRawUnsafe(
    `SELECT c.table_name FROM information_schema.columns c
      WHERE c.table_schema='public' AND c.column_name='CO_CODE'
        AND EXISTS (SELECT 1 FROM information_schema.columns t
                     WHERE t.table_schema='public' AND t.table_name=c.table_name AND t.column_name='tenant_id')
      GROUP BY c.table_name ORDER BY c.table_name`,
  );
  const out = {};
  for (const { table_name } of tables) {
    const [{ n }] = await ctx.rows(
      `SELECT count(*)::int n FROM "${table_name}" WHERE tenant_id=$1 AND "CO_CODE"='${coCode}'`,
    );
    out[table_name] = n;
  }
  return out;
}

/**
 * A company that has no year yet, and a session of its own on its Year Create screen. The desktop reaches it from
 * Company Master (NewCompCode, MS_COMPANY.cs:6196 → MS_YEAR.cs:1357); here the fixture makes a company with one year,
 * the operator's session switches to it through the header, and the year is removed, leaving what a brand-new company
 * is: a company, a location and no YEAR_MAST row.
 */
async function openBareCompany(ctx, slot) {
  await exec(
    ctx,
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE","CO_TYPE") VALUES ($1,$2,$3,'01','S')`,
    BARE.code,
    BARE.name,
  );
  await exec(
    ctx,
    `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,$2,'01','E2E FIRST YEAR MAIN')`,
    BARE.code,
  );
  await exec(
    ctx,
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,$2,'2025-2026','2025-04-01','2026-03-31'::timestamp)`,
    BARE.code,
  );
  const session = await ctx.session({
    user: USERS.admin.user,
    slot,
    get password() {
      return process.env.FEATURE_E2E_PASSWORD;
    },
  });
  await switchCompany(session.page, BARE.code);
  await exec(ctx, `DELETE FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`, BARE.code);
  await session.page.goto('/masters/year-create');
  await session.page.getByLabel('Year (CO_YEAR)', { exact: true }).waitFor();
  return session;
}
const dropBareCompany = (ctx) => purgeCompany(ctx.owner, ctx.tenantId, BARE.code);

async function submitYear(page, year) {
  await page.getByLabel('Year (CO_YEAR)', { exact: true }).fill(year);
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => new URL(r.url()).pathname === '/api/years' && r.request().method() === 'POST',
    ),
    page.getByRole('button', { name: 'Create Year', exact: true }).click(),
  ]);
  return response;
}

const firstYearCases = [
  base(
    'keyboard',
    'T17',
    'read-only',
    'MS_YEAR.cs:681-734 tab order Year Code 0, Start Month 1, Opening Date 2, Closing Date 3; :1079-1087 Enter on a non-blank year code moves on; :1096-1137 Enter on a date moves on; :951-957 Esc closes',
    async (ctx) => {
      const { page } = await ctx.session();
      await page.goto('/dashboard');
      await page.goto('/masters/year-create');
      const year = page.getByLabel('Year (CO_YEAR)', { exact: true });
      await year.waitFor();
      const active = () => page.evaluate(() => document.activeElement?.id ?? '');
      const idOf = (label) => page.getByLabel(label, { exact: true }).getAttribute('id');
      const ids = {
        year: await idOf('Year (CO_YEAR)'),
        month: await idOf('Start Month'),
        op: await idOf('Opening Date'),
        cl: await idOf('Closing Date'),
      };
      try {
        // A blank year code does not move on (:1083).
        await year.focus();
        await page.keyboard.press('Enter');
        assert.equal(await active(), ids.year);
        // Tab order of the fields (a date box has its own day, month and year stops, so Tab is checked up to it).
        await year.fill('2043-2044');
        const tabbed = [];
        for (let i = 0; i < 2; i += 1) {
          await page.keyboard.press('Tab');
          tabbed.push(await active());
        }
        assert.deepEqual(tabbed, [ids.month, ids.op]);
        // Enter walks the same way.
        await year.focus();
        const entered = [];
        for (let i = 0; i < 4; i += 1) {
          await page.keyboard.press('Enter');
          entered.push(await active());
        }
        assert.deepEqual(entered.slice(0, 3), [ids.month, ids.op, ids.cl]);
        assert.equal(
          await page.evaluate(() => document.activeElement?.textContent?.trim()),
          'Create Year',
        );
        // Enter on the button saves, as the desktop's Save does.
        const [saved] = await Promise.all([
          page.waitForResponse(
            (r) => new URL(r.url()).pathname === '/api/years' && r.request().method() === 'POST',
          ),
          page.keyboard.press('Enter'),
        ]);
        assert.equal(saved.status(), 201, await saved.text());
        await page
          .getByText('New Year are Created...Now ReOpen Sofware...', { exact: true })
          .waitFor();
        // Esc closes the form from a field.
        await year.focus();
        await Promise.all([
          page.waitForURL((url) => !url.pathname.startsWith('/masters/year-create'), {
            timeout: 10_000,
          }),
          page.keyboard.press('Escape'),
        ]);
        const database = (await yearRows(ctx)).filter((r) => r.CO_YEAR === '2043-2044');
        assert.equal(database.length, 1);
        return {
          observation:
            'blank year stays; Tab and Enter go year → month → opening → closing → Create Year; Enter saves; Esc leaves',
          expected: {
            order: ['Year', 'Start Month', 'Opening Date', 'Closing Date', 'Create Year'],
          },
        };
      } finally {
        await dropYears(ctx, ['2043-2044']);
      }
    },
  ),
  base(
    'rollback',
    'T14',
    'refusal',
    'MS_YEAR.cs:1357 first-year provisioning runs after the YEAR_MAST insert; the web writes both in one transaction (year.ts createYear)',
    async (ctx) => {
      try {
        const { page } = await openBareCompany(ctx, 'yc-rollback');
        // Learn the write set of a real first year: the tables that gain rows for the company.
        const empty = await companyCounts(ctx, BARE.code);
        const probe = await submitYear(page, FIRST_YEAR);
        assert.equal(probe.status(), 201, await probe.text());
        const full = await companyCounts(ctx, BARE.code);
        const written = Object.keys(full).filter((t) => full[t] > empty[t]);
        assert.ok(written.includes('YEAR_MAST'));
        const cloned = written.filter((t) => t !== 'YEAR_MAST');
        assert.ok(cloned.length >= 2, `the first year provisions masters (${cloned.join(', ')})`);
        // Undo the probe through the owner connection: the company is empty again (the company and its location
        // were not written by the year, so they stay).
        for (const table of written)
          await exec(ctx, `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='${BARE.code}'`);
        const attempts = [];
        for (const table of cloned) {
          await ctx.owner.$executeRawUnsafe(
            `CREATE OR REPLACE FUNCTION e2e_year_fault() RETURNS trigger LANGUAGE plpgsql SECURITY DEFINER AS $f$
             BEGIN
               IF NEW.tenant_id = '${ctx.tenantId}' AND NEW."CO_CODE" = '${BARE.code}' THEN
                 RAISE EXCEPTION 'e2e fault on ${table}';
               END IF;
               RETURN NEW;
             END $f$`,
          );
          await ctx.owner.$executeRawUnsafe(
            `CREATE TRIGGER e2e_year_fault BEFORE INSERT ON "${table}" FOR EACH ROW EXECUTE FUNCTION e2e_year_fault()`,
          );
          try {
            const before = await tenantFingerprint(ctx);
            const refused = await submitYear(page, FIRST_YEAR);
            assert.ok(refused.status() >= 400, `${table}: answered ${refused.status()}`);
            await page.locator('.msg[role="alert"]').first().waitFor();
            const after = await tenantFingerprint(ctx);
            assert.deepEqual(changedTables(before, after), [], `${table}: nothing is left behind`);
            assert.equal((await companyCounts(ctx, BARE.code)).YEAR_MAST, 0);
            attempts.push({ table, status: refused.status() });
          } finally {
            await ctx.owner.$executeRawUnsafe(
              `DROP TRIGGER IF EXISTS e2e_year_fault ON "${table}"`,
            );
            await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_year_fault()`);
          }
        }
        // The faults are gone: the same screen creates the year and provisions every table of the probe.
        const done = await submitYear(page, FIRST_YEAR);
        assert.equal(done.status(), 201, await done.text());
        const final = await companyCounts(ctx, BARE.code);
        assert.deepEqual(
          Object.keys(final).filter((t) => final[t] > empty[t]),
          written,
        );
        return {
          observation: `a fault on each of ${cloned.length} provisioned tables left the company exactly as before; the retry wrote the whole first year`,
          expected: { faulted: cloned, afterRetry: written },
          database: { attempts, final },
        };
      } finally {
        await dropBareCompany(ctx);
      }
    },
  ),
  base(
    'full-journey',
    'T18',
    'mutation',
    'MS_YEAR.cs:1357-1363 first-year provisioning copies the default masters when a new company gets its first year; MS_YEAR.cs:1394 refuses a repeat',
    async (ctx) => {
      try {
        const { page } = await openBareCompany(ctx, 'yc-journey');
        const before = await companyCounts(ctx, BARE.code);
        assert.equal(before.YEAR_MAST, 0);
        const created = await submitYear(page, FIRST_YEAR);
        assert.equal(created.status(), 201, await created.text());
        await page
          .getByText('New Year are Created...Now ReOpen Sofware...', { exact: true })
          .waitFor();
        const after = await companyCounts(ctx, BARE.code);
        const provisioned = Object.keys(after).filter((t) => after[t] > before[t]);
        assert.ok(provisioned.includes('YEAR_MAST') && provisioned.length >= 3, provisioned.join());
        // The same year again is refused and provisions nothing more.
        const repeat = await submitYear(page, FIRST_YEAR);
        assert.ok(repeat.status() >= 400 && repeat.status() < 500);
        await page
          .getByText('Year Is Already Exist...Now ReOpen Sofware...', { exact: true })
          .waitFor();
        assert.deepEqual(await companyCounts(ctx, BARE.code), after);
        // "Now ReOpen Software": the company opens on its new year through the Open Company screen.
        await page.goto('/select');
        await page.locator('#context-company').waitFor();
        await page.waitForFunction(
          () => document.querySelectorAll('#context-year option').length > 0,
        );
        await page.locator('#context-year').selectOption(FIRST_YEAR);
        await Promise.all([
          page.waitForURL('**/dashboard', { timeout: 20_000 }),
          page.getByRole('button', { name: 'Open', exact: true }).click(),
        ]);
        const me = await (await page.request.get('/api/me')).json();
        assert.deepEqual([me.coCode, me.coYear], [BARE.code, FIRST_YEAR]);
        const years = await (await page.request.get('/api/years')).json();
        assert.deepEqual(
          years.map((y) => [y.coYear, y.opDate, y.clDate]),
          [[FIRST_YEAR, '2030-04-01', '2031-03-31']],
        );
        return {
          observation: `the first year of company ${BARE.code} provisioned ${provisioned.join(', ')}; the repeat was refused; the company reopened on ${FIRST_YEAR}`,
          expected: { year: FIRST_YEAR, provisioned: 'masters copied once' },
          database: { before, after, provisioned },
          downstream: { session: [me.coCode, me.coYear], years },
        };
      } finally {
        await dropBareCompany(ctx);
      }
    },
  ),
];

export const yearCreate = {
  feature: 'year-create',
  title: 'Year Create (MS_YEAR)',
  defaultUser: {
    user: USERS.admin.user,
    get password() {
      return process.env.FEATURE_E2E_PASSWORD;
    },
  },
  inputs: [
    'web/apps/web/app/(app)/masters/year-create/page.tsx',
    'web/apps/api/src/modules/masters/year.ts',
    'web/apps/web/test/features/modules/yearCreate.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { year: 'Standard year; alternate branch covered by DB test' },
  cases: [
    {
      id: 'year-create.print-right-no-output',
      group: 'T16',
      kind: 'read-only',
      applicable: true,
      source: 'MS_YEAR.cs:961-968 checks print rights but produces no report',
      requiredEvidence: ['browser', 'expected', 'database'],
      async run(ctx) {
        const { page } = await ctx.session();
        await page.goto('/masters/year-create');
        const before = await ctx.rows(
          `SELECT to_jsonb(y) row FROM "YEAR_MAST" y WHERE tenant_id=$1 ORDER BY row_id`,
        );
        const response = page.waitForResponse(
          (r) => new URL(r.url()).pathname === '/api/years/print',
        );
        await page.getByRole('button', { name: 'Print', exact: true }).click();
        assert.equal((await response).status(), 200);
        const database = await ctx.rows(
          `SELECT to_jsonb(y) row FROM "YEAR_MAST" y WHERE tenant_id=$1 ORDER BY row_id`,
        );
        assert.deepEqual(database, before);
        return {
          observation: 'Print authorized without creating a report or changing year rows',
          expected: before,
          database,
        };
      },
    },
    {
      id: 'year-create.create-reopen-duplicate',
      group: 'T07',
      kind: 'mutation',
      applicable: true,
      source: 'MS_YEAR.cs:1035-1043,1153-1228,1394',
      requiredEvidence: ['browser', 'expected', 'database', 'downstream'],
      async run(ctx) {
        const { page } = await ctx.session();
        try {
          await page.goto('/masters/year-create');
          await page.getByLabel('Year (CO_YEAR)', { exact: true }).fill('2040-2041');
          await page.getByRole('button', { name: 'Create Year', exact: true }).click();
          await page
            .getByText('New Year are Created...Now ReOpen Sofware...', { exact: true })
            .waitFor();
          await page.reload();
          await page.getByRole('cell', { name: '2040-2041', exact: true }).waitFor();
          const database = await ctx.rows(
            `SELECT "CO_YEAR","OP_DATE",to_char("CL_DATE",'YYYY-MM-DD') "CL_DATE","YEAR_MONTH","OLD_METHOD" FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "CO_YEAR"='2040-2041'`,
          );
          assert.deepEqual(database, [
            {
              CO_YEAR: '2040-2041',
              OP_DATE: '2040-04-01',
              CL_DATE: '2041-03-31',
              YEAR_MONTH: '04',
              OLD_METHOD: 'Y',
            },
          ]);
          await page.getByLabel('Year (CO_YEAR)', { exact: true }).fill('2040-2041');
          await page.getByRole('button', { name: 'Create Year', exact: true }).click();
          await page
            .getByText('Year Is Already Exist...Now ReOpen Sofware...', { exact: true })
            .waitFor();
          assert.equal(await page.getByRole('button', { name: 'Delete', exact: true }).count(), 0);
          return {
            observation:
              'Created year persisted; duplicate refused; no destructive desktop user-delete action exposed',
            expected: database[0],
            database,
            downstream: { availableYear: '2040-2041' },
          };
        } finally {
          await dropYears(ctx, ['2040-2041']);
        }
      },
      observe: (ctx) =>
        ctx.rows(`SELECT "CO_YEAR" FROM "YEAR_MAST" WHERE tenant_id=$1 ORDER BY "CO_YEAR"`),
    },
    base(
      'entry.date-defaults',
      'T01',
      'read-only',
      'MS_YEAR.cs:1035-1043 fills 01/04/yyyy-31/03/yyyy+1 and start month 04',
      async (ctx) => {
        const { page } = await ctx.session();
        await page.goto('/masters/year-create');
        assert.equal(await page.getByLabel('Start Month', { exact: true }).inputValue(), '04');
        await page.getByLabel('Year (CO_YEAR)', { exact: true }).fill('2041-2042');
        await page.getByText('Opens 01/04/2041, closes 31/03/2042', { exact: true }).waitFor();
        return {
          observation: 'Start month defaults to 04 and 2041-2042 previews 01/04/2041 to 31/03/2042',
          expected: { month: '04', opens: '01/04/2041', closes: '31/03/2042' },
        };
      },
    ),
    base(
      'field.explicit-dates-route',
      'T02',
      'mutation',
      'MS_YEAR.cs:1196,1224 save the typed opening date, closing date and start month',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await page.goto('/masters/year-create');
          await page.getByLabel('Year (CO_YEAR)', { exact: true }).fill('2042-2043');
          await page.getByLabel('Start Month', { exact: true }).fill('05');
          await page.getByLabel('Opening Date', { exact: true }).fill('2042-05-01');
          await page.getByLabel('Closing Date', { exact: true }).fill('2043-05-15');
          await page.getByRole('button', { name: 'Create Year', exact: true }).click();
          await page
            .getByText('New Year are Created...Now ReOpen Sofware...', { exact: true })
            .waitFor();
          const database = (await yearRows(ctx)).filter((r) => r.CO_YEAR === '2042-2043');
          const expected = {
            CO_YEAR: '2042-2043',
            OP_DATE: '2042-05-01',
            CL_DATE: '2043-05-15',
            YEAR_MONTH: '05',
            OLD_METHOD: 'Y',
          };
          assert.deepEqual(database, [expected]);
          return {
            observation: 'Typed non-default dates and month reached YEAR_MAST unchanged',
            expected,
            database,
            downstream: { availableYear: '2042-2043' },
          };
        } finally {
          await dropYears(ctx, ['2042-2043']);
        }
      },
    ),
    notApplicable(
      'formula',
      'T03',
      'MS_YEAR.cs:1035-1043',
      'Year creation has no arithmetic or rounding; the only derivation is the date default covered by T01.',
    ),
    notApplicable(
      'lookup',
      'T04',
      'MS_YEAR.cs:1035-1228',
      'MS_YEAR has no lookup, search or selection control; every field is typed.',
    ),
    notApplicable(
      'children',
      'T05',
      'MS_YEAR.cs:1035-1228',
      'MS_YEAR has no child grid; first-year master copy is the provisioning write set (see T18).',
    ),
    base(
      'invalid.blank-and-overlong-code',
      'T06',
      'refusal',
      'MS_YEAR.cs:1153-1228 requires a year code; YEAR_MAST.CO_YEAR is nine characters',
      async (ctx) => {
        const { page } = await ctx.session();
        await page.goto('/masters/year-create');
        const before = await yearRows(ctx);
        assert.equal(
          await page.getByRole('button', { name: 'Create Year', exact: true }).isDisabled(),
          true,
        );
        const result = await apiPost(page, { coYear: '2050-20511' });
        assert.ok(result.status >= 400 && result.status < 500, JSON.stringify(result));
        const database = await yearRows(ctx);
        assert.deepEqual(database, before);
        return {
          observation:
            'Blank code leaves Create Year disabled; a ten character code is refused and no year row is written',
          expected: { blankDisabled: true, overlongStatus: result.status },
          database,
        };
      },
    ),
    notApplicable(
      'reopen-no-op',
      'T08',
      'MS_YEAR.cs:1035-1228',
      'MS_YEAR only inserts a year and exits; it has no reopen or unchanged-save mode. The created row surviving reload is asserted by T07.',
    ),
    notApplicable(
      'edit',
      'T09',
      'MS_YEAR.cs:1153-1228',
      'MS_YEAR has only the add path (EntryMode A); no edit of an existing year exists on the desktop.',
    ),
    notApplicable(
      'delete',
      'T10',
      'MS_YEAR.cs:1035-1228',
      'MS_YEAR exposes no delete, cancel or reverse action; T07 asserts the web exposes no Delete button.',
    ),
    base(
      'rights.restricted-clerk-denied',
      'T11',
      'refusal',
      'MDI_FORM.cs:7032-7049 requires FRM_VIEW on the Year Create menu; the web route policy enforces it on the server',
      async (ctx) => {
        const before = await yearRows(ctx);
        const { page } = await ctx.session(as(USERS.clerk.user, 'year-create-clerk'));
        const read = await page.request.get('/api/years');
        const write = await apiPost(page, { coYear: '2060-2061' });
        assert.equal(read.status(), 403, await read.text());
        assert.equal(write.status, 403, JSON.stringify(write));
        const database = await yearRows(ctx);
        assert.deepEqual(database, before);
        return {
          observation:
            'A clerk without Year Create rights was refused on read and create; no row written',
          expected: { read: 403, create: 403 },
          database,
        };
      },
    ),
    base(
      'concurrency.double-create',
      'T12',
      'mutation',
      'MS_YEAR.cs:1394 duplicate-year refusal; web serialises creation per company with an advisory lock',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await page.goto('/masters/year-create');
          const results = await Promise.all([
            apiPost(page, { coYear: '2043-2044' }),
            apiPost(page, { coYear: '2043-2044' }),
          ]);
          const statuses = results.map((r) => r.status).sort();
          assert.equal(statuses[0], 201, JSON.stringify(results));
          assert.ok(statuses[1] >= 400 && statuses[1] < 500, JSON.stringify(results));
          const refused = results.find((r) => r.status !== 201);
          assert.match(
            JSON.stringify(refused.body),
            /Year Is Already Exist\.\.\.Now ReOpen Sofware\.\.\./,
          );
          const database = (await yearRows(ctx)).filter((r) => r.CO_YEAR === '2043-2044');
          assert.equal(database.length, 1);
          return {
            observation:
              'Two simultaneous creates of one year produced one row and one duplicate refusal',
            expected: { created: 1, refused: 'Year Is Already Exist...Now ReOpen Sofware...' },
            database,
            downstream: { availableYear: '2043-2044' },
          };
        } finally {
          await dropYears(ctx, ['2043-2044']);
        }
      },
    ),
    base(
      'retry.repeat-create',
      'T13',
      'refusal',
      'MS_YEAR.cs:1394 refuses a repeated year with "Year Is Already Exist...Now ReOpen Sofware..."',
      async (ctx) => {
        const { page } = await ctx.session();
        try {
          await page.goto('/masters/year-create');
          const first = await apiPost(page, { coYear: '2045-2046' });
          assert.equal(first.status, 201, JSON.stringify(first));
          const repeat = await apiPost(page, { coYear: '2045-2046' });
          assert.ok(repeat.status >= 400 && repeat.status < 500, JSON.stringify(repeat));
          assert.match(JSON.stringify(repeat.body), /Year Is Already Exist/);
          const database = (await yearRows(ctx)).filter((r) => r.CO_YEAR === '2045-2046');
          assert.equal(database.length, 1);
          return {
            observation: 'A retried create after success was refused without a second row',
            expected: { rows: 1 },
            database,
          };
        } finally {
          await dropYears(ctx, ['2045-2046']);
        }
      },
    ),
    base(
      'config.alternate-year-code',
      'T15',
      'mutation',
      'MS_YEAR.cs:1153 alternate-year mode keys the year as first four characters plus the start month; the standard save writes OLD_METHOD Y (:1197)',
      async (ctx) => {
        const set = (value) =>
          ctx.owner.$executeRawUnsafe(
            `UPDATE "CO_MAST" SET "ALTER_YEAR"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
            TENANT,
            value,
          );
        const [{ v } = {}] = await ctx.rows(
          `SELECT "ALTER_YEAR" v FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        );
        const { page } = await ctx.session();
        try {
          await set('Y');
          await page.goto('/masters/year-create');
          await page.getByLabel('Year (CO_YEAR)', { exact: true }).fill('2044-2045');
          await page.getByRole('button', { name: 'Create Year', exact: true }).click();
          await page
            .getByText('New Year are Created...Now ReOpen Sofware...', { exact: true })
            .waitFor();
          const database = (await yearRows(ctx)).filter((r) => r.CO_YEAR === '204404');
          assert.deepEqual(database, [
            {
              CO_YEAR: '204404',
              OP_DATE: '2044-04-01',
              CL_DATE: '2045-03-31',
              YEAR_MONTH: '04',
              OLD_METHOD: 'N',
            },
          ]);
          return {
            observation:
              'With the company on alternate years the stored code is 204404 and OLD_METHOD is N',
            expected: database[0],
            database,
            downstream: { availableYear: '204404' },
          };
        } finally {
          await dropYears(ctx, ['204404', '2044-2045']);
          await set(v ?? null);
        }
      },
    ),
    ...firstYearCases,
  ],
};
