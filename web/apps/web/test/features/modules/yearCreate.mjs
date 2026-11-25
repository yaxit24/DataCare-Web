import assert from 'node:assert/strict';
import { TENANT } from '../harness.mjs';
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
const blocked = (id, group, kind, source, reason) => ({
  ...base(`${id}.blocked`, group, kind, source, async () => ({})),
  blocked: reason,
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
    blocked(
      'rollback',
      'T14',
      'refusal',
      'MS_YEAR.cs:1357 first-year provisioning runs after the YEAR_MAST insert',
      'Blocked: failing after each table family needs server fault injection that the browser feature harness does not provide; the transactional write is covered by the DB tests.',
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
    blocked(
      'keyboard',
      'T17',
      'read-only',
      'MS_YEAR.cs:1035-1228',
      'Blocked: no recorded desktop keyboard order or throughput target exists for MS_YEAR to compare the web against.',
    ),
    blocked(
      'full-journey',
      'T18',
      'mutation',
      'MS_YEAR.cs:1357 first-year provisioning copies masters; desktop-runtime comparison is required for desktop-match credit',
      'Blocked: first-year provisioning needs a company with no years and its own session, and no original Windows runtime comparison has been executed; DB tests cover the copy.',
    ),
  ],
};
