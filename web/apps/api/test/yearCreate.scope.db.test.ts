import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { COMPANY_CLONE_TABLES } from '../src/modules/masters/companyClone.js';
import { createYear, YearValidationError } from '../src/modules/masters/year.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import { tenantTables } from './support/tenantSnapshot.js';

/**
 * Year Create (WP-22): who may create a year, for which company, and what happens when the same create is
 * repeated, runs at the same time as another, or fails in the year row. The cases are in
 * orchestration/work/WP-22/cases.md (year-create.field.*, validate.*, rights.*, scope.*, retry.*, rollback.*,
 * concurrency.*). Expected values come from the desktop rules cited above each assertion, never from the
 * application's own output.
 *
 * Setup: company 01 is the template (seedCompany plus three AC_GROUP rows). Companies 02 and 04 get only a
 * CO_MAST and a LOCT_MAST row, so that a session can log in with no year yet. Logins are made once in beforeAll
 * (the login route is rate limited). Rows written by the creates are wiped before each test; the login-scope
 * rows (CO_MAST, LOCT_MAST, LOGIN_MAST, USER_SET) are kept.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT_A = 'year-scope-a';
const TENANT_B = 'year-scope-b';
const PASSWORD = 'Year-Scope-Test!2026';
const SECRET = 'year-scope-test-signing-secret-over-thirty-two';
const ADMIN = 'ysadmin';
const CLERK = 'ysnorights';
const LC = '01';
const TEMPLATE = '01';
const NEW_CO = '04';
const OTHER_CO = '02';
const RACE_COS = ['31', '32', '33', '34', '35'];
const WIPED_CO_CODES = [NEW_CO, OTHER_CO, ...RACE_COS];
/** Every table the first-year copy writes, plus YEAR_MAST. LOCT_MAST is copied too but kept as login scope. */
const CLONED = [...new Set(COMPANY_CLONE_TABLES.map((t) => t.table))];
const WIPED = [...new Set([...CLONED, 'YEAR_MAST'])].filter((t) => t !== 'LOCT_MAST');
const TRIGGER_FN = 'year_scope_fail_year';

(enabled ? describe : describe.skip)('Year Create scope, rights, retry, rollback and concurrency', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let runtimeB: PrismaClient;
  let app: FastifyInstance;
  let adminA: string;
  let clerkA: string;
  let adminB: string;
  let templateGroups = 0;

  const count = async (tenant: string, table: string, co: string): Promise<number> => {
    const rows = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      tenant,
      co,
    )) as Array<{ n: number }>;
    return Number(rows[0]?.n ?? 0);
  };
  const cloneCounts = async (tenant: string, co: string): Promise<Record<string, number>> => {
    const out: Record<string, number> = {};
    for (const table of CLONED) out[table] = await count(tenant, table, co);
    return out;
  };
  const yearRows = (tenant: string, co: string) =>
    owner.$queryRawUnsafe(
      `SELECT "CO_YEAR", "CL_DATE"::date::text AS "CL_DATE" FROM "YEAR_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "CO_YEAR"`,
      tenant,
      co,
    ) as Promise<Array<{ CO_YEAR: string | null; CL_DATE: string | null }>>;
  const seedYear = (tenant: string, co: string, coYear: string) =>
    owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE","YEAR_MONTH","OLD_METHOD","MAIN_USER")
       VALUES ($1,$2,$3,'2026-04-01','2027-03-31','04','Y','seed')`,
      tenant,
      co,
      coYear,
    );
  const wipeTenant = async (tenant: string): Promise<void> => {
    for (const table of await tenantTables(owner))
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenant);
  };
  const wipeCreatedRows = async (): Promise<void> => {
    for (const tenant of [TENANT_A, TENANT_B])
      for (const co of WIPED_CO_CODES)
        for (const table of WIPED)
          await owner.$executeRawUnsafe(
            `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
            tenant,
            co,
          );
  };
  const dropTrigger = async (): Promise<void> => {
    await owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS ${TRIGGER_FN} ON "YEAR_MAST"`);
    await owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS ${TRIGGER_FN}()`);
  };
  const openCompany = async (tenant: string, co: string, name: string): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES ($1,$2,$3,$4)`,
      tenant,
      co,
      name,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,$2,$3,'SCOPE LOCATION')`,
      tenant,
      co,
      LC,
    );
  };
  const addLogin = async (
    tenant: string,
    co: string,
    user: string,
    category: 'ADMIN' | 'USER',
    passwordHash: string,
  ): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,$2,$3,$4,$5,'Y','Y','Y','N')`,
      tenant,
      co,
      user,
      passwordHash,
      category,
    );
  };
  // Login without coYear: the company has no year yet, and the create is what opens it.
  const login = async (tenant: string, co: string, user: string): Promise<string> => {
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenant },
      payload: { coCode: co, lcCode: LC, loginName: user, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const setCookie = response.headers['set-cookie'];
    return (Array.isArray(setCookie) ? setCookie : [setCookie ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  };
  const createYearRoute = (cookie: string, payload: Record<string, unknown>) =>
    app.inject({ method: 'POST', url: '/years', headers: { cookie }, payload: payload as never });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    runtimeB = new PrismaClient();
    for (const tenant of [TENANT_A, TENANT_B]) await wipeTenant(tenant);
    await seedCompany(runtime, TENANT_A, TEMPLATE, { coName: 'YEAR SCOPE TEMPLATE', lcCode: LC });
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_GROUP"(tenant_id,"CO_CODE","AC_GR","AC_GR_NAME")
       VALUES ($1,'01','01','SCOPE GROUP 1'),($1,'01','02','SCOPE GROUP 2'),($1,'01','03','SCOPE GROUP 3')`,
      TENANT_A,
    );
    templateGroups = await count(TENANT_A, 'AC_GROUP', TEMPLATE);
    expect(templateGroups).toBeGreaterThan(0);
    await openCompany(TENANT_A, NEW_CO, 'SCOPE COMPANY A');
    await openCompany(TENANT_A, OTHER_CO, 'SCOPE OTHER A');
    await openCompany(TENANT_B, NEW_CO, 'SCOPE COMPANY B');
    const passwordHash = await hashPassword(PASSWORD);
    await addLogin(TENANT_A, NEW_CO, ADMIN, 'ADMIN', passwordHash);
    await addLogin(TENANT_A, NEW_CO, CLERK, 'USER', passwordHash);
    await addLogin(TENANT_B, NEW_CO, ADMIN, 'ADMIN', passwordHash);
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    adminA = await login(TENANT_A, NEW_CO, ADMIN);
    clerkA = await login(TENANT_A, NEW_CO, CLERK);
    adminB = await login(TENANT_B, NEW_CO, ADMIN);
  });

  beforeEach(async () => {
    await dropTrigger();
    await wipeCreatedRows();
  });

  afterAll(async () => {
    await dropTrigger();
    if (app) await app.close();
    if (owner) {
      for (const tenant of [TENANT_A, TENANT_B]) await wipeTenant(tenant);
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
    if (runtimeB) await runtimeB.$disconnect();
  });

  it('year-create.field.year-code-route: the typed year code is stored as CO_YEAR of the new company', async () => {
    // MS_YEAR.cs:1193 {{dataRow["CO_YEAR"] = tYearCode.Text;}}
    const response = await createYearRoute(adminA, {
      coYear: '2026-2027',
      opDate: '2026-04-01',
      clDate: '2027-03-31',
      yearMonth: '04',
    });
    expect(response.statusCode, response.body).toBe(201);
    const rows = await yearRows(TENANT_A, NEW_CO);
    expect(rows.map((row) => row.CO_YEAR)).toEqual(['2026-2027']);
  });

  it('year-create.field.closing-date-route: the closing date of the first year is 31 March of the second year', async () => {
    // MS_YEAR.cs:1196 {{dataRow["CL_DATE"] = mClDate.Text;}}
    const response = await createYearRoute(adminA, {
      coYear: '2026-2027',
      opDate: '2026-04-01',
      clDate: '2027-03-31',
      yearMonth: '04',
    });
    expect(response.statusCode, response.body).toBe(201);
    const rows = await yearRows(TENANT_A, NEW_CO);
    expect(rows).toEqual([{ CO_YEAR: '2026-2027', CL_DATE: '2027-03-31' }]);
  });

  it('year-create.validate.year-code-blank-refused: a blank year code is refused and writes no year row and no copied row', async () => {
    // The desktop has no code check in its save handler (MS_YEAR.cs:1140 {{private void BtnSave_Click(object sender, EventArgs e)}}).
    // The refusal is the web's own: web/apps/api/src/modules/masters/year.ts:76 {{if (!coYear) throw new YearValidationError('coYear is required');}}
    const response = await createYearRoute(adminA, { coYear: '', yearMonth: '04' });
    expect(response.statusCode, response.body).toBe(400);
    expect(response.json()).toMatchObject({
      error: 'YearValidationError',
      message: 'coYear is required',
    });
    expect(await count(TENANT_A, 'YEAR_MAST', NEW_CO)).toBe(0);
    expect(await count(TENANT_A, 'AC_GROUP', NEW_CO)).toBe(0);
  });

  it('year-create.rights.create-without-right-refused: a user without the Year Create right gets 403 and writes no row', async () => {
    // The route is registered under the form 'Masters/Year Create' (web/apps/api/src/modules/rbac/routePolicy.ts:918 {{route('Masters/Year Create', ['GET /years', 'POST /years', 'POST /years/carry-forward']);}}).
    // The route guard answers 403 with the action (web/apps/api/src/routes/txn.ts:6357 {{if (!guard(req, reply, 'create')) return;}}).
    // Desktop: its only rights test on this save is the edit guard, not create (MS_YEAR.cs:1147 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}}).
    const response = await createYearRoute(clerkA, { coYear: '2026-2027', yearMonth: '04' });
    expect(response.statusCode, response.body).toBe(403);
    expect(response.json()).toMatchObject({ error: 'forbidden', action: 'create' });
    expect(await count(TENANT_A, 'YEAR_MAST', NEW_CO)).toBe(0);
    expect(await count(TENANT_A, 'AC_GROUP', NEW_CO)).toBe(0);
  });

  it('year-create.scope.other-company-same-year-code: the same year code in another company is neither refused nor changed', async () => {
    // The desktop existence probe has no company condition (MS_YEAR.cs:1164 {{SELECT * FROM YEAR_MAST WHERE  CO_YEAR}}).
    // That weakness is not ported: the web checks the session company only (year.ts:86 {{if (ex[0]?.n > 0) throw new YearValidationError(`year ${coYear} already exists`);}}).
    await seedYear(TENANT_A, OTHER_CO, '2026-2027');
    const otherBefore = await yearRows(TENANT_A, OTHER_CO);
    expect(otherBefore).toHaveLength(1);
    const response = await createYearRoute(adminA, { coYear: '2026-2027', yearMonth: '04' });
    expect(response.statusCode, response.body).toBe(201);
    expect((await yearRows(TENANT_A, NEW_CO)).map((row) => row.CO_YEAR)).toEqual(['2026-2027']);
    expect(await yearRows(TENANT_A, OTHER_CO)).toEqual(otherBefore);
  });

  it('year-create.scope.other-tenant-no-leak: another tenant lists none of this tenant’s years and its own create stays in its rows', async () => {
    // The list and the create use the request's scope (web/apps/api/src/routes/txn.ts:6352 {{app.get('/years', auth, async (req) => {}}).
    const created = await createYearRoute(adminA, { coYear: '2026-2027', yearMonth: '04' });
    expect(created.statusCode, created.body).toBe(201);
    const listed = await app.inject({
      method: 'GET',
      url: '/years',
      headers: { cookie: adminB },
    });
    expect(listed.statusCode, listed.body).toBe(200);
    expect(listed.json()).toEqual([]);
    const other = await createYearRoute(adminB, { coYear: '2027-2028', yearMonth: '04' });
    expect(other.statusCode, other.body).toBe(201);
    expect((await yearRows(TENANT_A, NEW_CO)).map((row) => row.CO_YEAR)).toEqual(['2026-2027']);
    expect((await yearRows(TENANT_B, NEW_CO)).map((row) => row.CO_YEAR)).toEqual(['2027-2028']);
  });

  it('year-create.scope.body-company-ignored: a CO_CODE in the body is ignored and the year goes to the session company', async () => {
    // The row’s company is the session company (MS_YEAR.cs:1186 {{dataRow["CO_CODE"] = DC_Main.MCo_code;}}).
    await seedYear(TENANT_A, OTHER_CO, '2025-2026');
    const otherBefore = await yearRows(TENANT_A, OTHER_CO);
    const response = await createYearRoute(adminA, {
      CO_CODE: OTHER_CO,
      coYear: '2026-2027',
      yearMonth: '04',
    });
    expect(response.statusCode, response.body).toBe(201);
    expect(await yearRows(TENANT_A, OTHER_CO)).toEqual(otherBefore);
    expect((await yearRows(TENANT_A, NEW_CO)).map((row) => row.CO_YEAR)).toEqual(['2026-2027']);
  });

  it('year-create.retry.same-request-after-commit: repeating a committed create is refused and copies nothing a second time', async () => {
    // The desktop overwrites and purges on a repeated save (MS_YEAR.cs:1386 {{DC_Main.DataConYear();}}); that is not ported.
    const payload = { coYear: '2026-2027', yearMonth: '04' };
    const first = await createYearRoute(adminA, payload);
    expect(first.statusCode, first.body).toBe(201);
    const second = await createYearRoute(adminA, payload);
    expect(second.statusCode, second.body).toBe(400);
    expect(second.json()).toMatchObject({
      error: 'YearValidationError',
      message: 'year 2026-2027 already exists',
    });
    expect(await yearRows(TENANT_A, NEW_CO)).toHaveLength(1);
    expect(await count(TENANT_A, 'AC_GROUP', NEW_CO)).toBe(templateGroups);
  });

  it('year-create.rollback.year-row-failure-no-copy: a refused YEAR_MAST insert leaves no year row and no cloned row', async () => {
    // The copy runs only after the year row is written (web/apps/api/src/modules/masters/year.ts:106 {{if (firstYear && scope.coCode !== CLONE_TEMPLATE_CO_CODE)}}).
    const before = await cloneCounts(TENANT_A, NEW_CO);
    await owner.$executeRawUnsafe(
      `CREATE FUNCTION ${TRIGGER_FN}() RETURNS trigger LANGUAGE plpgsql AS $$
       BEGIN
         RAISE EXCEPTION 'year scope: YEAR_MAST insert refused';
       END $$`,
    );
    try {
      await owner.$executeRawUnsafe(
        `CREATE TRIGGER ${TRIGGER_FN} BEFORE INSERT ON "YEAR_MAST"
           FOR EACH ROW WHEN (NEW.tenant_id = '${TENANT_A}' AND NEW."CO_CODE" = '${NEW_CO}')
           EXECUTE FUNCTION ${TRIGGER_FN}()`,
      );
      const response = await createYearRoute(adminA, { coYear: '2026-2027', yearMonth: '04' });
      expect(response.statusCode).toBeGreaterThanOrEqual(400);
      expect(response.statusCode).not.toBe(201);
    } finally {
      await dropTrigger();
    }
    expect(await count(TENANT_A, 'YEAR_MAST', NEW_CO)).toBe(0);
    expect(await cloneCounts(TENANT_A, NEW_CO)).toEqual(before);
  });

  it('year-create.concurrency.same-year-two-requests: two creates of one year at the same moment write one year and one copy', async () => {
    // The duplicate check is a read before the insert (year.ts:86 {{if (ex[0]?.n > 0) throw new YearValidationError(`year ${coYear} already exists`);}}),
    // and YEAR_MAST has no unique key on company and year, so two sessions can both pass it (the expected result is one success and one refusal).
    // Each pair uses a new company and a new year code, so a lucky ordering in one pair cannot pass the whole test.
    for (const [index, co] of RACE_COS.entries()) {
      const coYear = `${2026 + index}-${2027 + index}`;
      const scope = { tenantId: TENANT_A, coCode: co };
      const results = await Promise.allSettled([
        createYear(runtime, scope, { coYear, yearMonth: '04' }),
        createYear(runtimeB, scope, { coYear, yearMonth: '04' }),
      ]);
      const fulfilled = results.filter((result) => result.status === 'fulfilled');
      const rejected = results.filter(
        (result): result is PromiseRejectedResult => result.status === 'rejected',
      );
      expect(fulfilled, `pair ${index}: successes`).toHaveLength(1);
      expect(rejected, `pair ${index}: refusals`).toHaveLength(1);
      const reason = rejected[0]?.reason;
      expect(reason, `pair ${index}: refusal type`).toBeInstanceOf(YearValidationError);
      expect((reason as Error).message, `pair ${index}: refusal text`).toMatch(/already exists/);
      expect(await yearRows(TENANT_A, co), `pair ${index}: YEAR_MAST rows`).toHaveLength(1);
      expect(await count(TENANT_A, 'AC_GROUP', co), `pair ${index}: copied AC_GROUP rows`).toBe(
        templateGroups,
      );
    }
  });
});
