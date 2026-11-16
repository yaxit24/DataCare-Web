import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { COMPANY_CLONE_TABLES } from '../src/modules/masters/companyClone.js';
import { createYear } from '../src/modules/masters/year.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { resolveBookAccountTx, resolveBookPolicyTx } from '../src/modules/shared/bookPolicy.js';
import { resolveTaxPolicyTx } from '../src/modules/shared/taxPolicy.js';
import { withTxBudget } from '../src/modules/shared/txBudget.js';
import { tenantTables } from './support/tenantSnapshot.js';

/**
 * Year Create safety net (WP-22, risk tier A). These tests pin what the CURRENT first-year copy gives a new
 * company so the narrower copy of packet WP-22.impl-copy cannot break selling, buying or receipts, and pin
 * the all-or-nothing behaviour of a failed create. They assert nothing about WHICH rows the new copy keeps.
 *
 * Every read goes through the owner client with an explicit tenant_id (the runtime role sees nothing outside
 * a tenant context); the writers and resolvers run through the runtime client under forced row-level security.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'year-pin-a';
const OTHER = 'year-pin-b';
const TEMPLATE = '01';
const NEW_CO = '04';
const LC = '01';
const YEAR1 = '2026-2027';
const YEAR2 = '2027-2028';
const CLONED = [...new Set(COMPANY_CLONE_TABLES.map((t) => t.table))];
const VOUCHER_TABLES = ['AC_DATA', 'OP_DATA', 'ITM_OPBL'];
const TRIGGER_FN = 'year_pin_fail_tax';

databaseDescribe('Year Create pins: first-year footprint, posting resolvers, rollback', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const t of await tenantTables(owner)) {
      for (const tenant of [TENANT, OTHER]) {
        await owner.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenant);
      }
    }
  };

  const count = async (tenant: string, table: string, co: string): Promise<number> => {
    const r: any[] = await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      tenant,
      co,
    );
    return Number(r[0]?.n ?? 0);
  };

  const counts = async (tenant: string, co: string): Promise<Record<string, number>> => {
    const out: Record<string, number> = {};
    for (const table of [...CLONED, 'YEAR_MAST', ...VOUCHER_TABLES, 'BAL_GR']) {
      out[table] = await count(tenant, table, co);
    }
    return out;
  };

  const dropTrigger = async (): Promise<void> => {
    await owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS year_pin_fail_tax ON "TAX_MAST"`);
    await owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS ${TRIGGER_FN}()`);
  };

  const scopeOf = (co: string, coYear: string, coBook = 'SL') =>
    ({ tenantId: TENANT, coCode: co, lcCode: LC, coBook, coYear }) as any;

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) throw new Error('MIGRATE_DATABASE_URL and DATABASE_URL required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  afterAll(async () => {
    await dropTrigger();
    await cleanup();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  beforeEach(async () => {
    await dropTrigger();
    await cleanup();
    await seedCompany(runtime, TENANT, TEMPLATE, { coName: 'Year Pin Template', lcCode: LC });
  });

  it('first year: one YEAR_MAST row with the saved columns, copied masters, no vouchers or openings', async () => {
    await createYear(
      runtime,
      { tenantId: TENANT, coCode: NEW_CO },
      { coYear: YEAR1, yearMonth: '04', mainUser: 'op1' },
    );
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT "CO_YEAR",left("OP_DATE"::text,10) op,left("CL_DATE"::text,10) cl,"OLD_METHOD","YEAR_MONTH","MAIN_USER"
         FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      NEW_CO,
    );
    // MS_YEAR.cs:1196 {{dataRow["CL_DATE"] = mClDate.Text;}}
    // MS_YEAR.cs:1198 {{dataRow["YEAR_MONTH"] = tMonth.Text;}}
    // MS_YEAR.cs:1199 {{dataRow["MAIN_USER"] = DC_Main.MCo_User;}}
    expect(rows).toHaveLength(1);
    expect(rows[0]).toMatchObject({
      CO_YEAR: YEAR1,
      op: '2026-04-01',
      cl: '2027-03-31',
      OLD_METHOD: 'Y',
      YEAR_MONTH: '04',
      MAIN_USER: 'op1',
    });
    // The first year of a new company copies masters from the template.
    for (const table of ['AC_GROUP', 'AC_MAST', 'BOOK_DATA', 'BOOK_DETL', 'LOCT_MAST', 'TAX_MAST']) {
      expect(await count(TENANT, table, NEW_CO), `${table} rows for ${NEW_CO}`).toBeGreaterThan(0);
    }
    // MS_YEAR.cs:1357 {{if (Operators.CompareString(DC_Main.NewCompCode, "", false) != 0)}}
    for (const table of VOUCHER_TABLES) {
      expect(await count(TENANT, table, NEW_CO), `${table} rows for ${NEW_CO}`).toBe(0);
    }
  });

  it('a further year writes one YEAR_MAST row and changes no other table', async () => {
    await createYear(runtime, { tenantId: TENANT, coCode: NEW_CO }, { coYear: YEAR1 });
    const before = await counts(TENANT, NEW_CO);
    await createYear(runtime, { tenantId: TENANT, coCode: NEW_CO }, { coYear: YEAR2 });
    const after = await counts(TENANT, NEW_CO);
    expect(after.YEAR_MAST).toBe(before.YEAR_MAST! + 1);
    // MS_YEAR.cs:1357 {{if (Operators.CompareString(DC_Main.NewCompCode, "", false) != 0)}}
    expect({ ...after, YEAR_MAST: 0 }).toEqual({ ...before, YEAR_MAST: 0 });
  });

  it('the new company resolves the same posting books, accounts and tax rate as the template', async () => {
    await createYear(runtime, { tenantId: TENANT, coCode: NEW_CO }, { coYear: YEAR1 });
    const locs: any[] = await owner.$queryRawUnsafe(
      `SELECT "LC_CODE" FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "LC_CODE"`,
      TENANT,
      NEW_CO,
    );
    const tmplLocs: any[] = await owner.$queryRawUnsafe(
      `SELECT "LC_CODE" FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "LC_CODE"`,
      TENANT,
      TEMPLATE,
    );
    expect(locs.map((r) => r.LC_CODE)).toEqual(tmplLocs.map((r) => r.LC_CODE));
    expect(locs.map((r) => r.LC_CODE)).toContain(LC);

    const resolve = (co: string, coYear: string) =>
      withTxBudget(runtime as any, TENANT, 'read', async (tx: any) => {
        const scope = scopeOf(co, coYear);
        const policy = await resolveBookPolicyTx(tx, scope, 'SALES');
        const accounts: string[] = [];
        for (const sr of [1, 2, 3]) accounts.push(await resolveBookAccountTx(tx, scope, policy, sr));
        const tax = await resolveTaxPolicyTx(tx, scope, { acCode: 'CASH', taxPct: 3 });
        return { coBook: policy.coBook, accounts, taxGroup: tax.taxGroup, taxPct: tax.taxPct };
      });
    const tmplYear: any[] = await owner.$queryRawUnsafe(
      `SELECT "CO_YEAR" FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "CO_YEAR" LIMIT 1`,
      TENANT,
      TEMPLATE,
    );
    const expected = await resolve(TEMPLATE, String(tmplYear[0]?.CO_YEAR));
    const actual = await resolve(NEW_CO, YEAR1);
    expect(actual.accounts, 'SAL book slots 1, 2, 3 (control, cash, round-off) of the new company').toEqual(
      expected.accounts,
    );
    expect(actual, 'sale book policy and 3% GST resolution of the new company').toEqual(expected);
  });

  it('every book account and every book of the new company is backed by a real row', async () => {
    await createYear(runtime, { tenantId: TENANT, coCode: NEW_CO }, { coYear: YEAR1 });
    const orphans: any[] = await owner.$queryRawUnsafe(
      `SELECT DISTINCT d."CO_BOOK", d."AC_CODE" FROM "BOOK_DETL" d
        WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND coalesce(d."AC_CODE",'')<>''
          AND NOT EXISTS (SELECT 1 FROM "AC_MAST" a
                           WHERE a.tenant_id=d.tenant_id AND a."CO_CODE"=d."CO_CODE" AND a."AC_CODE"=d."AC_CODE")`,
      TENANT,
      NEW_CO,
    );
    expect(orphans, 'BOOK_DETL account codes missing from AC_MAST of the new company').toEqual([]);
    const bare: any[] = await owner.$queryRawUnsafe(
      `SELECT b."CO_BOOK" FROM "BOOK_DATA" b
        WHERE b.tenant_id=$1 AND b."CO_CODE"=$2
          AND NOT EXISTS (SELECT 1 FROM "BOOK_DETL" d
                           WHERE d.tenant_id=b.tenant_id AND d."CO_CODE"=b."CO_CODE" AND d."CO_BOOK"=b."CO_BOOK")`,
      TENANT,
      NEW_CO,
    );
    expect(bare, 'BOOK_DATA books of the new company with no BOOK_DETL row').toEqual([]);
  });

  it('a failed copy leaves no year row and no cloned row, and the template is unchanged', async () => {
    const templateBefore = await counts(TENANT, TEMPLATE);
    await owner.$executeRawUnsafe(
      `CREATE FUNCTION ${TRIGGER_FN}() RETURNS trigger LANGUAGE plpgsql AS $$
       BEGIN
         IF NEW."CO_CODE" = '04' THEN RAISE EXCEPTION 'year pin: TAX_MAST insert refused'; END IF;
         RETURN NEW;
       END $$`,
    );
    try {
      await owner.$executeRawUnsafe(
        `CREATE TRIGGER year_pin_fail_tax BEFORE INSERT ON "TAX_MAST"
           FOR EACH ROW EXECUTE FUNCTION ${TRIGGER_FN}()`,
      );
      await expect(
        createYear(runtime, { tenantId: TENANT, coCode: NEW_CO }, { coYear: YEAR1 }),
      ).rejects.toThrow();
    } finally {
      await dropTrigger();
    }
    expect(await count(TENANT, 'YEAR_MAST', NEW_CO), 'YEAR_MAST rows for 04').toBe(0);
    for (const table of CLONED) {
      expect(await count(TENANT, table, NEW_CO), `${table} rows for ${NEW_CO}`).toBe(0);
    }
    expect(await counts(TENANT, TEMPLATE)).toEqual(templateBefore);
  });

  it('another tenant is untouched by the copy and none of its rows appear under the new company', async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_GROUP"(tenant_id,"CO_CODE","AC_GR") VALUES ($1,$2,'ZZB')`,
      OTHER,
      TEMPLATE,
    );
    const otherBefore = await counts(OTHER, TEMPLATE);
    await createYear(runtime, { tenantId: TENANT, coCode: NEW_CO }, { coYear: YEAR1 });
    expect(await counts(OTHER, TEMPLATE)).toEqual(otherBefore);
    expect(await counts(OTHER, NEW_CO)).toEqual(await counts(OTHER, '99'));
    const leaked: any[] = await owner.$queryRawUnsafe(
      `SELECT 1 FROM "AC_GROUP" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_GR"='ZZB'`,
      TENANT,
      NEW_CO,
    );
    expect(leaked, 'tenant B group row copied under tenant A company 04').toEqual([]);
  });
});
