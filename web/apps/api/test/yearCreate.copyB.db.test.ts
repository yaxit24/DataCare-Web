import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import {
  cloneCompany,
  cloneCompanyTx,
  type CloneCompanyOptions,
} from '../src/modules/masters/companyClone.js';
import { createYear } from '../src/modules/masters/year.js';
import { withTxBudget } from '../src/modules/shared/txBudget.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import { diffTenant, snapshotTenant, tenantTables } from './support/tenantSnapshot.js';

/**
 * Year Create, group B of the first-year copy (WP-22 packet t-copy-b). Eight tables are copied whole: AC_GROUP,
 * BAL_GR, CO_SET, CO_SET_NEW, COL_MAST, CONV_MAST, PRINT_MAST, TAX_MAST. Four have a row selection and a narrower
 * column list: EMP_MAST, GROUP_MAST, ITEM_MAST, PRODUCT_MAST. The expected values come from the desktop rule
 * (design section 2), not from what the web prints today. The whole-table tests pass today and must keep passing;
 * the selection and column tests fail until WP-22.impl-copy is built.
 */
// `selection` is not in CloneCompanyOptions until WP-22.impl-copy runs; the cast becomes unnecessary then.
const baseline = { selection: 'baseline' } as unknown as CloneCompanyOptions;

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'year-copyb-a';
const OTHER = 'year-copyb-b';
const TEMPLATE = '01';
const NEW_CO = '04';
const YEAR1 = '2026-2027';

/** Whole-table row counts of company 01 after the first-year copy (cases.md "Test data"). */
const WHOLE_COUNTS: ReadonlyArray<readonly [string, number]> = [
  ['AC_GROUP', 3],
  ['BAL_GR', 2],
  ['CO_SET', 1],
  ['CO_SET_NEW', 1],
  ['COL_MAST', 2],
  ['CONV_MAST', 2],
  ['PRINT_MAST', 2],
  ['TAX_MAST', 2],
];

const EMP_KEYS = [
  'EMP_CODE',
  'EMP_NAME',
  'USER_NAME',
  'EMP_TYPE',
  'EMP_AC',
  'EMP_AMT',
  'MAIN_USER',
  'TDS_PRC',
  'TDS_AMT',
  'PF_PRC',
  'PF_AMT',
  'DAY_HOURS',
];

databaseDescribe('Year Create copy B: whole tables, row and column selections', () => {
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

  const count = async (tenant: string, table: string, co = NEW_CO): Promise<number> => {
    const r = await rows(
      tenant,
      `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      co,
    );
    return Number(r[0]?.n ?? 0);
  };

  /** Sorted values of one column for the company's rows of one table. */
  const codes = async (table: string, col: string, co = NEW_CO): Promise<string[]> =>
    (
      await rows(
        TENANT,
        `SELECT "${col}" c FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
        co,
      )
    ).map((r) => r.c);

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

  /** Template company 01 for group B (cases.md "Test data"). Dropped columns are filled so a copy defect shows. */
  const seedTemplate = async (tenant: string): Promise<void> => {
    await many(tenant, 'AC_GROUP', ['AC_GR', 'AC_GR_NAME'], [
      ['G1', 'Group 1'],
      ['G2', 'Group 2'],
      ['G3', 'Group 3'],
    ]);
    await many(tenant, 'BAL_GR', ['TRAD_TYPE', 'TRAD_NAME'], [
      ['G', 'Gold'],
      ['S', 'Silver'],
    ]);
    await many(tenant, 'CO_SET', ['TAG_RPT'], [['Y']]);
    await many(tenant, 'CO_SET_NEW', ['COUNTER_STK'], [['Y']]);
    await many(tenant, 'COL_MAST', ['BOOK_NAME', 'COL_NAME'], [
      ['SAL', 'C1'],
      ['PUR', 'C2'],
    ]);
    await many(tenant, 'CONV_MAST', ['CON_CODE', 'CON_NAME'], [
      ['01', 'Conv 1'],
      ['02', 'Conv 2'],
    ]);
    await many(tenant, 'PRINT_MAST', ['PRINT_TYPE', 'PRINT_FILE'], [
      ['A', 'file-a'],
      ['B', 'file-b'],
    ]);
    await many(tenant, 'TAX_MAST', ['TAX_CODE', 'SR_NO', 'TAX_NAME'], [
      ['01', 1, 'Tax 1'],
      ['02', 2, 'Tax 2'],
    ]);
    await many(tenant, 'EMP_MAST', EMP_KEYS, [
      ['001', 'Emp One', 'u1', 'S', 'AC1', 10, 'm1', 1.5, 100, 12, 200, 8],
      ['002', 'Emp Two', 'u2', 'S', 'AC2', 20, 'm2', 2.5, 150, 10, 180, 9],
    ]);
    await many(tenant, 'GROUP_MAST', ['GR_CODE', 'GR_NAME', 'GR_TYPE', 'SALE_AC', 'PURC_AC', 'RATE_DISPLAY', 'DATA_TRFR'], [
      ['DM', 'Diamond', 'D', 'SA1', 'PA1', 'Y', 'Y'],
      ['ZZ', 'Zeta', 'Z', 'SA2', 'PA2', 'Y', 'Y'],
    ]);
    await many(tenant, 'ITEM_MAST', ['IT_CODE', 'IT_NAME', 'GR_CODE'], [
      ['DM', 'Diamond item', 'DM'],
      ['AB', 'Abc item', 'AB'],
    ]);
    await many(tenant, 'PRODUCT_MAST', ['PR_CODE', 'PR_NAME'], [
      ['DM', 'Diamond product'],
      ['AB', 'Abc product'],
    ]);
  };

  const cloneBaseline = (co = NEW_CO) =>
    withTxBudget(runtime as any, TENANT, 'heavy', (tx: any) =>
      cloneCompanyTx(tx, TENANT, co, baseline),
    );

  beforeAll(async () => {
    assertIsolatedTestDatabase('year create copy B');
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
    await seedTemplate(TENANT);
  });

  // ---- Whole-table copies (pass today; must keep passing) ----

  it('year-create.copy.ac-group-rows: all 3 AC_GROUP rows of company 01 are copied', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1558 {{FROM AC_GROUP WHERE CO_CODE = '01'}}
    expect(await count(TENANT, 'AC_GROUP')).toBe(3);
  });

  it('year-create.copy.bal-gr-rows: all 2 BAL_GR rows of company 01 are copied', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1562 {{FROM BAL_GR WHERE CO_CODE = '01'}}
    expect(await count(TENANT, 'BAL_GR')).toBe(2);
  });

  it('year-create.copy.co-set-rows: the 1 CO_SET row of company 01 is copied', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1568 {{FROM CO_SET WHERE CO_CODE = '01'}}
    expect(await count(TENANT, 'CO_SET')).toBe(1);
  });

  it('year-create.copy.co-set-new-rows: the 1 CO_SET_NEW row of company 01 is copied', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1570 {{FROM CO_SET_NEW WHERE CO_CODE = '01'}}
    expect(await count(TENANT, 'CO_SET_NEW')).toBe(1);
  });

  it('year-create.copy.col-mast-rows: all 2 COL_MAST rows of company 01 are copied', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1572 {{FROM COL_MAST WHERE CO_CODE = '01'}}
    expect(await count(TENANT, 'COL_MAST')).toBe(2);
  });

  it('year-create.copy.conv-mast-rows: all 2 CONV_MAST rows of company 01 are copied', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1574 {{FROM CONV_MAST WHERE CO_CODE = '01'}}
    expect(await count(TENANT, 'CONV_MAST')).toBe(2);
  });

  it('year-create.copy.print-mast-rows: all 2 PRINT_MAST rows of company 01 are copied', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1586 {{FROM PRINT_MAST WHERE CO_CODE = '01'}}
    expect(await count(TENANT, 'PRINT_MAST')).toBe(2);
  });

  it('year-create.copy.tax-mast-rows: all 2 TAX_MAST rows of company 01 are copied', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1592 {{FROM TAX_MAST WHERE CO_CODE = '01'}}
    expect(await count(TENANT, 'TAX_MAST')).toBe(2);
  });

  // ---- Row selections and column lists (fail until WP-22.impl-copy) ----

  it('year-create.copy.emp-mast-rows: only EMP_CODE 001 is copied, 002 is not', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1576 {{FROM EMP_MAST WHERE CO_CODE = '01' AND EMP_CODE = '001'}}
    expect(await codes('EMP_MAST', 'EMP_CODE')).toEqual(['001']);
  });

  it('year-create.copy.emp-mast-columns: TDS, PF and day-hours columns are NULL, the kept columns equal the template', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1576 {{INSERT INTO EMP_MAST (CO_CODE,EMP_CODE,EMP_NAME,USER_NAME,EMP_TYPE,EMP_AC,EMP_AMT,MAIN_USER)}}
    const [r] = await rows(
      TENANT,
      `SELECT * FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3`,
      NEW_CO,
      '001',
    );
    for (const c of ['TDS_PRC', 'TDS_AMT', 'PF_PRC', 'PF_AMT', 'DAY_HOURS'])
      expect(r?.[c] ?? null, `EMP_MAST.${c}`).toBeNull();
    expect(r?.EMP_NAME).toBe('Emp One');
    expect(r?.USER_NAME).toBe('u1');
    expect(r?.EMP_TYPE).toBe('S');
    expect(r?.EMP_AC).toBe('AC1');
    expect(Number(r?.EMP_AMT)).toBe(10);
  });

  it('year-create.copy.group-mast-rows: only GR_CODE DM is copied, ZZ is not', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1578 {{IN ('916','DM','EM','FGL','FSL','GO','OG','ORD','OS','OT','SL','SN')}}
    expect(await codes('GROUP_MAST', 'GR_CODE')).toEqual(['DM']);
  });

  it('year-create.copy.group-mast-columns: RATE_DISPLAY and DATA_TRFR are NULL, the kept columns equal the template', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1578 {{DAY_CL_PCS,DAY_CL_WT)}}
    const [r] = await rows(
      TENANT,
      `SELECT * FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=$3`,
      NEW_CO,
      'DM',
    );
    expect(r?.RATE_DISPLAY ?? null).toBeNull();
    expect(r?.DATA_TRFR ?? null).toBeNull();
    expect(r?.GR_NAME).toBe('Diamond');
    expect(r?.GR_TYPE).toBe('D');
    expect(r?.SALE_AC).toBe('SA1');
  });

  it('year-create.copy.item-mast-rows: only IT_CODE DM is copied, AB is not', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1580 {{IN ('999','DM','EM','FSL','HM','OG','ORG','ORS','OS','OT','RD','SN')}}
    expect(await codes('ITEM_MAST', 'IT_CODE')).toEqual(['DM']);
  });

  it('year-create.copy.product-mast-rows: only PR_CODE DM is copied, AB is not', async () => {
    await cloneBaseline();
    // MS_YEAR.cs:1588 {{IN ('DM','EM','FN','HM','OD','OG','OR','OS','OT','RD','SN')}}
    expect(await codes('PRODUCT_MAST', 'PR_CODE')).toEqual(['DM']);
  });

  // ---- Isolation and default behaviour ----

  it('year-create.copy.other-tenant: a second tenant company 01 with the same codes is neither read nor changed', async () => {
    await seedTemplate(OTHER);
    await owner.$executeRawUnsafe(
      `UPDATE "GROUP_MAST" SET "GR_NAME"='Other Diamond' WHERE tenant_id=$1`,
      OTHER,
    );
    const before = await snapshotTenant(owner, OTHER);
    // The first-year path (createYear) runs for tenant A only.
    await createYear(runtime, { tenantId: TENANT, coCode: NEW_CO }, { coYear: YEAR1 });
    expect(diffTenant(before, await snapshotTenant(owner, OTHER))).toEqual({ added: {}, removed: {} });
    for (const [table, n] of WHOLE_COUNTS) expect(await count(TENANT, table), table).toBe(n);
    // MS_YEAR.cs:1578 {{FROM GROUP_MAST WHERE CO_CODE = '01'}}
    expect(
      await rows(
        TENANT,
        `SELECT "GR_NAME" FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"='DM'`,
        NEW_CO,
      ),
    ).toEqual([{ GR_NAME: 'Diamond' }]);
    expect(await count(OTHER, 'GROUP_MAST', NEW_CO)).toBe(0);
  });

  it('year-create.copy.default-selection: cloneCompany without a selection still copies both EMP_MAST rows', async () => {
    // Web default kept for other callers. It is not a desktop rule, so there is no desktop citation.
    await cloneCompany(runtime, TENANT, '05');
    expect(await codes('EMP_MAST', 'EMP_CODE', '05')).toEqual(['001', '002']);
  });
});
