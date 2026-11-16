import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import {
  COMPANY_CLONE_TABLES,
  cloneCompanyTx,
  type CloneCompanyOptions,
} from '../src/modules/masters/companyClone.js';
import { createYear } from '../src/modules/masters/year.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { resolveBookAccountTx, resolveBookPolicyTx } from '../src/modules/shared/bookPolicy.js';
import { withTxBudget } from '../src/modules/shared/txBudget.js';
import { tenantTables } from './support/tenantSnapshot.js';

/**
 * Year Create, group A of the first-year copy (WP-22 packet t-copy-a): AC_MAST, BOOK_DATA, BOOK_DETL, LOCT_MAST,
 * TABLE_MAST and the two tables the desktop never copies (AC_MAST_SRNO, BANK_RECONCILE). The expected values come
 * from the desktop rule (design section 2), not from what the web prints today, so most of these fail until
 * WP-22.impl-copy is built. Template shapes: DESKTOP (numeric codes, location 00) and WEB-SEEDED (seedCompany).
 */
// `selection` is not in CloneCompanyOptions until WP-22.impl-copy runs; the cast becomes unnecessary then.
const baseline = { selection: 'baseline' } as unknown as CloneCompanyOptions;

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'year-copya-a';
const OTHER = 'year-copya-b';
const TEMPLATE = '01';
const NEW_CO = '04';
const YEAR1 = '2026-2027';
const CLONED = [...new Set(COMPANY_CLONE_TABLES.map((t) => t.table))];

describe('Year Create copy: table list', () => {
  it('year-create.copy.book-detl-listed-once: BOOK_DETL has exactly one clone entry', () => {
    // MS_YEAR.cs:1566 {{INSERT INTO BOOK_DETL(CO_CODE,LC_CODE,CO_BOOK,SR_NO,BOOK_NAME,BOOK_SNAME,BOOK_TYPE,ITM_TYPE,BOOK_INOUT,AC_CODE,AC_NAME,MAIN_BOOK,RESET_BOOK,DATA_TYPE)}}
    expect(COMPANY_CLONE_TABLES.filter((t) => t.table === 'BOOK_DETL')).toHaveLength(1);
  });
});

databaseDescribe('Year Create copy A: accounts, books, locations, tables', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const t of await tenantTables(owner)) {
      for (const tenant of [TENANT, OTHER]) {
        await owner.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenant);
      }
    }
  };

  const ins = async (
    tenant: string,
    table: string,
    row: Record<string, unknown>,
  ): Promise<void> => {
    const keys = Object.keys(row);
    await owner.$executeRawUnsafe(
      `INSERT INTO "${table}"(tenant_id,${keys.map((k) => `"${k}"`).join(',')})
       VALUES ($1,${keys.map((_, i) => `$${i + 2}`).join(',')})`,
      tenant,
      ...keys.map((k) => row[k]),
    );
  };

  const rows = async (tenant: string, sql: string, ...params: unknown[]): Promise<any[]> =>
    owner.$queryRawUnsafe(sql, tenant, ...params);

  const count = async (tenant: string, table: string, co: string): Promise<number> => {
    const r = await rows(
      tenant,
      `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      co,
    );
    return Number(r[0]?.n ?? 0);
  };

  /** Insert one row per tuple, naming the tuple's fields by `keys`; `common` columns apply to every row. */
  const many = async (
    tenant: string,
    table: string,
    keys: string[],
    tuples: unknown[][],
    common: Record<string, unknown> = {},
  ): Promise<void> => {
    for (const t of tuples)
      await ins(tenant, table, {
        CO_CODE: TEMPLATE,
        ...common,
        ...Object.fromEntries(keys.map((k, i) => [k, t[i]])),
      });
  };

  /** Desktop-shaped template company 01 (cases.md "Test data"): numeric codes, location 00. */
  // prettier-ignore
  const seedDesktop = async (tenant: string): Promise<void> => {
    const acRows = [['050', '00'], ['100', '00'], ['101', '00'], ['099', '01'], ['2001', '00']];
    await many(tenant, 'AC_MAST', ['AC_CODE', 'LC_CODE'], acRows, {
      AC_PERSON: 'Test Person', AC_ADD1: 'Test Street', AC_GSTNO: '27TESTG1234A1Z5', AC_PANNO: 'TESTP1234A',
      DATA_TRFR: 'Y', AC_SHORT: 'S', AC_MAIN_GR: 'MG', AC_GR: 'GR', AC_GST_TYPE: 'R',
    });
    await owner.$executeRawUnsafe(`UPDATE "AC_MAST" SET "AC_NAME"='Acct '||"AC_CODE" WHERE tenant_id=$1`, tenant);
    await many(tenant, 'AC_MAST_SRNO', ['LC_CODE', 'AC_CODE'], [['00', '050']]);
    await many(tenant, 'BANK_RECONCILE', ['LC_CODE', 'LEDR_KEY'], [['00', `${tenant}-k1`]]);
    const bd = { USER_EMP_CODE: '001', WITH_MOBILE_ENTRY: 'Y', MENU_NAME: 'Menu', BOOK_TBL_NAME: 'TBL', BOOK_TBL_DETL: 'TBLD' };
    await many(tenant, 'BOOK_DATA', ['LC_CODE', 'CO_BOOK', 'MAIN_BOOK', 'BOOK_INOUT'],
      [['00', 'SAL', 'SALES', 'O'], ['00', 'PUR', 'PURCHASE', 'I'], ['01', 'SAL', 'SALES', 'O']], { ...bd, BOOK_SNAME: 'B' });
    await many(tenant, 'BOOK_DETL', ['LC_CODE', 'CO_BOOK', 'SR_NO', 'AC_CODE', 'MAIN_BOOK', 'BOOK_INOUT'], [
      ['00', 'SAL', 1, '050', 'SALES', 'O'], ['00', 'SAL', 2, '100', 'SALES', 'O'],
      ['00', 'PUR', 1, '100', 'PURCHASE', 'I'], ['01', 'SAL', 1, '099', 'SALES', 'O'],
    ]);
    await many(tenant, 'LOCT_MAST', ['LC_CODE', 'LC_NAME'], [['00', 'Loc 00'], ['01', 'Loc 01']]);
    await many(tenant, 'TABLE_MAST', ['TABLE_CODE', 'TABLE_NAME'], [['001', 'T1'], ['002', 'T2']], { LC_CODE: '00' });
  };

  const create = (co = NEW_CO) =>
    createYear(runtime, { tenantId: TENANT, coCode: co }, { coYear: YEAR1 });
  const cloneBaseline = (co = NEW_CO) =>
    withTxBudget(runtime as any, TENANT, 'heavy', (tx: any) =>
      cloneCompanyTx(tx, TENANT, co, baseline),
    );

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) throw new Error('MIGRATE_DATABASE_URL and DATABASE_URL required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });
  afterAll(async () => {
    await cleanup();
    await owner.$disconnect();
    await runtime.$disconnect();
  });
  beforeEach(async () => {
    await cleanup();
    await seedDesktop(TENANT);
  });

  const codes = async (table: string, col: string, co = NEW_CO): Promise<string[]> =>
    (
      await rows(
        TENANT,
        `SELECT "${col}" c FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
        co,
      )
    ).map((r) => r.c);

  it('year-create.copy.ac-mast-rows: only 050 and 100 of location 00 are copied (createYear and clone)', async () => {
    await create();
    // MS_YEAR.cs:1560 {{AND CAST(AC_CODE AS INT) < 101}}
    const got = await rows(
      TENANT,
      `SELECT "AC_CODE","LC_CODE" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
      NEW_CO,
    );
    expect(got).toEqual([
      { AC_CODE: '050', LC_CODE: '00' },
      { AC_CODE: '100', LC_CODE: '00' },
    ]);
    await cloneBaseline('05');
    expect(await codes('AC_MAST', 'AC_CODE', '05')).toEqual(['050', '100']);
  });

  it('year-create.copy.ac-mast-rows: a mixed template (CASH, 050, 101) creates without a database error and keeps CASH and 050', async () => {
    await owner.$executeRawUnsafe(`DELETE FROM "AC_MAST" WHERE tenant_id=$1`, TENANT);
    for (const code of ['CASH', '050', '101'])
      await ins(TENANT, 'AC_MAST', {
        CO_CODE: TEMPLATE,
        LC_CODE: '00',
        AC_CODE: code,
        AC_NAME: `Acct ${code}`,
      });
    await owner.$executeRawUnsafe(
      `UPDATE "BOOK_DETL" SET "AC_CODE"='CASH' WHERE tenant_id=$1 AND "AC_CODE" IN ('100','099')`,
      TENANT,
    );
    // Rule N: a code that is not all digits is kept; the filter must test the pattern before the CAST.
    await expect(create()).resolves.toBeDefined();
    expect(await codes('AC_MAST', 'AC_CODE')).toEqual(['050', 'CASH']);
  });

  it('year-create.copy.ac-mast-rows: without a selection the clone still copies all 5 AC_MAST rows (old result)', async () => {
    await withTxBudget(runtime as any, TENANT, 'heavy', (tx: any) =>
      cloneCompanyTx(tx, TENANT, '05', { only: ['AC_MAST'] }),
    );
    expect(await codes('AC_MAST', 'AC_CODE', '05')).toEqual(['050', '099', '100', '101', '2001']);
  });

  it('year-create.copy.ac-mast-columns: personal, address, GST and PAN are empty and DATA_TRFR is N', async () => {
    await create();
    // MS_YEAR.cs:1560 {{INSERT INTO AC_MAST (CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_GST_TYPE,DATA_TRFR)}}
    const got = await rows(
      TENANT,
      `SELECT "AC_CODE","AC_NAME","AC_GST_TYPE","AC_PERSON","AC_ADD1","AC_GSTNO","AC_PANNO","DATA_TRFR"
         FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
      NEW_CO,
    );
    expect(got).toHaveLength(2);
    for (const r of got) {
      for (const c of ['AC_PERSON', 'AC_ADD1', 'AC_GSTNO', 'AC_PANNO'])
        expect(r[c] ?? '', `${c} of ${r.AC_CODE}`).toBe('');
      expect(r.DATA_TRFR).toBe('N');
      expect(r.AC_NAME).toBe(`Acct ${r.AC_CODE}`);
      expect(r.AC_GST_TYPE).toBe('R');
    }
  });

  it('year-create.copy.book-data-rows: only the two location 00 books are copied', async () => {
    await create();
    // MS_YEAR.cs:1564 {{FROM BOOK_DATA WHERE CO_CODE = '01' AND LC_CODE = '00'}}
    const got = await rows(
      TENANT,
      `SELECT "CO_BOOK","LC_CODE" FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
      NEW_CO,
    );
    expect(got).toEqual([
      { CO_BOOK: 'PUR', LC_CODE: '00' },
      { CO_BOOK: 'SAL', LC_CODE: '00' },
    ]);
    await cloneBaseline('05');
    expect(await count(TENANT, 'BOOK_DATA', '05')).toBe(2);
  });

  it('year-create.copy.book-data-columns: the five web-only columns are empty, the kept ones are copied', async () => {
    await create();
    // MS_YEAR.cs:1564 {{BOOK_VCH_TYPE,MAIN_USER,BOOK_SR_NAME,RESET_BOOK,DATA_TYPE,TRFR_BOOK,DATA_TRFR)}}
    const got = await rows(
      TENANT,
      `SELECT "MAIN_BOOK","BOOK_INOUT","BOOK_SNAME","USER_EMP_CODE","WITH_MOBILE_ENTRY","MENU_NAME","BOOK_TBL_NAME","BOOK_TBL_DETL"
         FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      NEW_CO,
    );
    expect(got.length).toBeGreaterThan(0);
    for (const r of got) {
      for (const c of [
        'USER_EMP_CODE',
        'WITH_MOBILE_ENTRY',
        'MENU_NAME',
        'BOOK_TBL_NAME',
        'BOOK_TBL_DETL',
      ])
        expect(r[c] ?? '', c).toBe('');
      expect(r.MAIN_BOOK && r.BOOK_INOUT && r.BOOK_SNAME).toBeTruthy();
    }
  });

  it('year-create.copy.book-detl-rows: 3 rows of location 00, none of location 01', async () => {
    await create();
    // MS_YEAR.cs:1566 {{FROM BOOK_DETL WHERE CO_CODE = '01' AND LC_CODE = '00'}}
    const got = await rows(
      TENANT,
      `SELECT DISTINCT "LC_CODE" FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      NEW_CO,
    );
    expect(got).toEqual([{ LC_CODE: '00' }]);
    expect(await count(TENANT, 'BOOK_DETL', NEW_CO)).toBe(3);
    await cloneBaseline('05');
    expect(await count(TENANT, 'BOOK_DETL', '05')).toBe(3);
  });

  it('year-create.copy.loct-mast-rows: only location 00 is copied', async () => {
    await create();
    // MS_YEAR.cs:1582 {{AND LC_CODE = '00'}}
    expect(await codes('LOCT_MAST', 'LC_CODE')).toEqual(['00']);
    await cloneBaseline('05');
    expect(await codes('LOCT_MAST', 'LC_CODE', '05')).toEqual(['00']);
  });

  it('year-create.copy.table-mast-rows: only TABLE_CODE 001 is copied', async () => {
    await create();
    // MS_YEAR.cs:1590 {{AND TABLE_CODE = '001'}}
    expect(await codes('TABLE_MAST', 'TABLE_CODE')).toEqual(['001']);
    await cloneBaseline('05');
    expect(await codes('TABLE_MAST', 'TABLE_CODE', '05')).toEqual(['001']);
  });

  it('year-create.copy.ac-mast-srno-not-copied: zero rows with the baseline, one with the default', async () => {
    // MS_YEAR.cs:1557 {{DC_Main.ExeQuteDc("DELETE FROM AC_GROUP WHERE CO_CODE}}
    await create();
    expect(await count(TENANT, 'AC_MAST_SRNO', NEW_CO)).toBe(0);
    await withTxBudget(runtime as any, TENANT, 'heavy', (tx: any) =>
      cloneCompanyTx(tx, TENANT, '05', { only: ['AC_MAST_SRNO'] }),
    );
    expect(await count(TENANT, 'AC_MAST_SRNO', '05')).toBe(1);
  });

  it('year-create.copy.bank-reconcile-not-copied: zero rows with the baseline', async () => {
    // MS_YEAR.cs:1412 {{DELETE FROM BANK_RECONCILE}}
    // The default copy is not asserted: LEDR_KEY is unique per tenant, so today's default copy of this table cannot insert.
    expect(await count(TENANT, 'BANK_RECONCILE', TEMPLATE)).toBe(1);
    await create();
    expect(await count(TENANT, 'BANK_RECONCILE', NEW_CO)).toBe(0);
  });

  it('year-create.copy.ac-mast-rows: after createYear every BOOK_DETL account exists and account 101 is absent (desktop shape)', async () => {
    await create();
    const orphans = await rows(
      TENANT,
      `SELECT d."AC_CODE" FROM "BOOK_DETL" d WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND coalesce(d."AC_CODE",'')<>''
          AND NOT EXISTS (SELECT 1 FROM "AC_MAST" a WHERE a.tenant_id=d.tenant_id AND a."CO_CODE"=d."CO_CODE" AND a."AC_CODE"=d."AC_CODE")`,
      NEW_CO,
    );
    expect(orphans).toEqual([]);
    expect(await codes('AC_MAST', 'AC_CODE')).not.toContain('101');
    const slots = await withTxBudget(runtime as any, TENANT, 'read', async (tx: any) => {
      const scope = {
        tenantId: TENANT,
        coCode: NEW_CO,
        lcCode: '00',
        coBook: 'SAL',
        coYear: YEAR1,
      } as any;
      const policy = { coBook: 'SAL', mainBook: 'SALES', inout: 'O' } as any;
      return [
        await resolveBookAccountTx(tx, scope, policy, 1),
        await resolveBookAccountTx(tx, scope, policy, 2),
      ];
    });
    expect(slots).toEqual(['050', '100']);
  });

  it('year-create.copy.book-data-rows: a web-seeded template still gives location 01, books and the same SAL slots 1-3', async () => {
    await cleanup();
    await seedCompany(runtime, TENANT, TEMPLATE, { coName: 'Copy A Template', lcCode: '01' });
    await create();
    expect(await codes('LOCT_MAST', 'LC_CODE')).toContain('01');
    expect(await count(TENANT, 'BOOK_DATA', NEW_CO)).toBeGreaterThan(0);
    const resolve = (co: string, coYear: string) =>
      withTxBudget(runtime as any, TENANT, 'read', async (tx: any) => {
        const scope = { tenantId: TENANT, coCode: co, lcCode: '01', coBook: 'SL', coYear } as any;
        const policy = await resolveBookPolicyTx(tx, scope, 'SALES');
        const out: string[] = [];
        for (const sr of [1, 2, 3]) out.push(await resolveBookAccountTx(tx, scope, policy, sr));
        return out;
      });
    const tmplYear = await rows(
      TENANT,
      `SELECT "CO_YEAR" FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
      TEMPLATE,
    );
    expect(await resolve(NEW_CO, YEAR1)).toEqual(
      await resolve(TEMPLATE, String(tmplYear[0]?.CO_YEAR)),
    );
  });

  it('year-create.copy.book-detl-rows: a BOOK_DETL pointing at a not-copied account (150) is refused and nothing is written', async () => {
    await ins(TENANT, 'BOOK_DETL', {
      CO_CODE: TEMPLATE,
      LC_CODE: '00',
      CO_BOOK: 'SAL',
      SR_NO: 3,
      AC_CODE: '150',
      MAIN_BOOK: 'SALES',
      BOOK_INOUT: 'O',
    });
    await expect(create()).rejects.toThrow();
    expect(await count(TENANT, 'YEAR_MAST', NEW_CO)).toBe(0);
    for (const table of CLONED)
      expect(await count(TENANT, table, NEW_CO), `${table} rows for ${NEW_CO}`).toBe(0);
  });

  it('year-create.copy.ac-mast-rows: another tenant company 01 with the same codes is never read or changed', async () => {
    await seedDesktop(OTHER);
    const snap = async () => ({
      ac: await rows(
        OTHER,
        `SELECT row_id::text r,"AC_CODE","DATA_TRFR","AC_PERSON" FROM "AC_MAST" WHERE tenant_id=$1 ORDER BY 1`,
      ),
      counts: await Promise.all(
        ['BOOK_DATA', 'BOOK_DETL', 'LOCT_MAST', 'TABLE_MAST'].map((t) => count(OTHER, t, TEMPLATE)),
      ),
      newCo: await Promise.all([...CLONED, 'YEAR_MAST'].map((t) => count(OTHER, t, NEW_CO))),
    });
    const before = await snap();
    await create();
    expect(await snap()).toEqual(before);
    expect(await count(TENANT, 'AC_MAST', NEW_CO)).toBe(2);
  });
});
