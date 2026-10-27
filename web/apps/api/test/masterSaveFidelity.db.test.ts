import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import {
  createMaster,
  updateMaster,
  AC_MAST_CONFIG,
  ITEM_MAST_CONFIG,
} from '../src/modules/masters/master.service.js';
import { GROUP_MAST_CONFIG } from '../src/modules/masters/configs.js';
import { createYear, listYears, YearValidationError } from '../src/modules/masters/year.js';
import { assertFiscalDateTx } from '../src/modules/vouchers/lifecycle.js';
import { withTxBudget } from '../src/modules/shared/txBudget.js';

/**
 * Found by operating the screens on a fresh company (E2E 2026-10-26):
 *  - a master saved with any numeric/date box left blank failed with `invalid input syntax for type double
 *    precision: ""` — the desktop stores Conversion.Val (0) / DBNull (MS_GROUP.cs:1873-1883, MS_ACCT.cs:7810-7851);
 *  - masters were saved without MAIN_USER (MS_GROUP.cs:1882, MS_ACCT.cs:7826);
 *  - Year Create stored no closing date, so a web-created year could not post a voucher
 *    (MS_YEAR.cs:1035-1040 fills 01/04 – 31/03).
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'master-save-fidelity';
const CO = '07';
const scope = { tenantId: TENANT, coCode: CO, lcCode: '01' };
const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });

const TABLES = ['GROUP_MAST', 'AC_MAST', 'ITEM_MAST', 'YEAR_MAST', 'CO_SET', 'CO_SET_NEW'];
async function clean(): Promise<void> {
  for (const table of TABLES)
    await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
}
const one = async (sql: string, ...params: unknown[]): Promise<Record<string, unknown>> => {
  const rows = (await owner.$queryRawUnsafe(sql, TENANT, ...params)) as Record<string, unknown>[];
  expect(rows).toHaveLength(1);
  return rows[0]!;
};

databaseDescribe('master and year save fidelity (desktop blank/stamp/date rules)', () => {
  beforeEach(clean);
  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('stores blank numeric boxes as 0 and stamps the creator on an item group', async () => {
    await createMaster(
      runtime,
      scope,
      GROUP_MAST_CONFIG,
      {
        CO_CODE: 'XX', // ignored: the server binds the session company
        GR_CODE: 'G22',
        GR_NAME: 'GOLD ORNAMENTS 22K',
        GR_TYPE: 'G',
        GR_TOUCH: '100',
        GR_PURC_TOUCH: '',
        MELTING_PRC: '',
        WEST_PRC: ' ',
        SALE_AC: 'SALES',
        PURC_AC: 'PURCHASE',
        HSN_CODE: '',
        TAX_PRC: '',
        RATE_DISPLAY: '',
        MAIN_USER: 'forged',
      },
      { user: 'cashier1' },
    );
    const row = await one(
      `SELECT "CO_CODE","GR_TOUCH","GR_PURC_TOUCH","MELTING_PRC","WEST_PRC","TAX_PRC","HSN_CODE","MAIN_USER"
         FROM "GROUP_MAST" WHERE tenant_id=$1`,
    );
    expect({
      ...row,
      GR_TOUCH: Number(row.GR_TOUCH),
      GR_PURC_TOUCH: Number(row.GR_PURC_TOUCH),
      MELTING_PRC: Number(row.MELTING_PRC),
      WEST_PRC: Number(row.WEST_PRC),
      TAX_PRC: Number(row.TAX_PRC),
    }).toEqual({
      CO_CODE: CO,
      GR_TOUCH: 100,
      GR_PURC_TOUCH: 0,
      MELTING_PRC: 0,
      WEST_PRC: 0,
      TAX_PRC: 0,
      HSN_CODE: '',
      MAIN_USER: 'cashier1',
    });
    // The values are real numbers, not NULLs that happen to coerce to 0.
    expect(row.GR_PURC_TOUCH).not.toBeNull();
    expect(row.TAX_PRC).not.toBeNull();
  });

  it('stores a blank date mask as NULL on an account and keeps the creator on edit', async () => {
    // A provisioned company always has its CO_SET row; the account writer reads AC_LC_CODE_LEN from it.
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE") VALUES ($1,$2)`,
      TENANT,
      CO,
    );
    // L_BR_DATE is the date-typed column in the migrated AC_MAST (BR_DATE/AN_DATE are varchar).
    await createMaster(
      runtime,
      scope,
      AC_MAST_CONFIG,
      {
        AC_CODE: 'SUP01',
        AC_NAME: 'MAHALAXMI BULLION SUPPLIERS',
        AC_GR: 'SC',
        AC_CR_DAYS: '',
        DPC_PRC: '',
        L_BR_DATE: '',
        AC_GST_TYPE: 'I',
      },
      { user: 'admin' },
    );
    const created = await one(
      `SELECT "LC_CODE","AC_CR_DAYS","DPC_PRC","L_BR_DATE","MAIN_USER"
         FROM "AC_MAST" WHERE tenant_id=$1`,
    );
    expect(created).toMatchObject({ LC_CODE: '01', L_BR_DATE: null, MAIN_USER: 'admin' });
    expect(Number(created.AC_CR_DAYS)).toBe(0);
    expect(Number(created.DPC_PRC)).toBe(0);

    await updateMaster(runtime, scope, AC_MAST_CONFIG, {
      AC_CODE: 'SUP01',
      AC_NAME: 'MAHALAXMI BULLION',
      AC_CR_DAYS: '30',
      L_BR_DATE: '1980-05-01',
      DPC_PRC: '',
      MAIN_USER: 'someone-else',
    });
    const edited = await one(
      `SELECT "AC_NAME","AC_CR_DAYS","DPC_PRC","L_BR_DATE"::text AS "L_BR_DATE","MAIN_USER"
         FROM "AC_MAST" WHERE tenant_id=$1`,
    );
    expect(edited).toMatchObject({
      AC_NAME: 'MAHALAXMI BULLION',
      L_BR_DATE: '1980-05-01',
      MAIN_USER: 'admin',
    });
    expect(Number(edited.AC_CR_DAYS)).toBe(30);
    expect(Number(edited.DPC_PRC)).toBe(0);
  });

  it('still rejects a malformed number instead of storing 0', async () => {
    await expect(
      createMaster(runtime, scope, ITEM_MAST_CONFIG, {
        IT_CODE: 'CHN22',
        IT_NAME: 'GOLD CHAIN 22K',
        IT_TOUCH: 'ninety',
      }),
    ).rejects.toThrow(/double precision|numeric/);
    const rows = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "ITEM_MAST" WHERE tenant_id=$1`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(rows[0]!.n).toBe(0);
  });

  it('creates a year with the desktop opening/closing dates and it accepts vouchers', async () => {
    await expect(
      createYear(runtime, scope, { coYear: '2027-2028', yearMonth: '4', mainUser: 'admin' }),
    ).resolves.toEqual({ coYear: '2027-2028', opDate: '2027-04-01', clDate: '2028-03-31' });
    const row = await one(
      `SELECT "OP_DATE","CL_DATE"::date::text AS "CL_DATE","YEAR_MONTH","OLD_METHOD","MAIN_USER"
         FROM "YEAR_MAST" WHERE tenant_id=$1`,
    );
    expect(row).toEqual({
      OP_DATE: '2027-04-01',
      CL_DATE: '2028-03-31',
      YEAR_MONTH: '04',
      OLD_METHOD: 'Y',
      MAIN_USER: 'admin',
    });
    await expect(listYears(runtime, scope)).resolves.toEqual([
      { coYear: '2027-2028', opDate: '2027-04-01', clDate: '2028-03-31', yearMonth: '04' },
    ]);
    const voucherScope = { ...scope, coYear: '2027-2028', coBook: '000' } as any;
    await withTxBudget(runtime, TENANT, 'read', async (tx: any) => {
      await expect(assertFiscalDateTx(tx, voucherScope, '2028-03-31')).resolves.toBeUndefined();
      await expect(assertFiscalDateTx(tx, voucherScope, '2028-04-01')).rejects.toThrow(
        /outside fiscal year 2027-04-01 to 2028-03-31/,
      );
    });
  });

  it('opens the next year of the template company without cloning it into itself', async () => {
    // Found in the browser: Year Create in company 01 failed with "company clone source and target must
    // differ", because every year creation cloned masters from company 01.
    const template = { ...scope, coCode: '01' };
    await owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       VALUES ($1,'01','2026-2027','2026-04-01','2027-03-31')`,
      TENANT,
    );
    await expect(createYear(runtime, template, { coYear: '2027-2028' })).resolves.toMatchObject({
      coYear: '2027-2028',
      clDate: '2028-03-31',
    });
    await expect(createYear(runtime, template, { coYear: '2028-2029' })).resolves.toMatchObject({
      opDate: '2028-04-01',
    });
  });

  it('refuses a year it could not post against, writing nothing', async () => {
    await expect(createYear(runtime, scope, { coYear: '2027' })).rejects.toBeInstanceOf(
      YearValidationError,
    );
    await expect(createYear(runtime, scope, { coYear: '2027-2029' })).rejects.toThrow(
      /consecutive years/,
    );
    await createYear(runtime, scope, { coYear: '2027-2028' });
    await expect(createYear(runtime, scope, { coYear: '2027-2028' })).rejects.toThrow(
      /already exists/,
    );
    const rows = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "YEAR_MAST" WHERE tenant_id=$1`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(rows[0]!.n).toBe(1);
  });
});
