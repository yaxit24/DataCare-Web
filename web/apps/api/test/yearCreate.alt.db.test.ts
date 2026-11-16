import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { createYear, listYears } from '../src/modules/masters/year.js';
import { assertFiscalDateTx } from '../src/modules/vouchers/lifecycle.js';
import { withTxBudget } from '../src/modules/shared/txBudget.js';

/**
 * Alternate-year company (CO_MAST.ALTER_YEAR = 'Y', company 03) and a standard company (02, ALTER_YEAR 'N').
 * Expected values are the desktop rule in MS_YEAR.cs, never read back from the application.
 * Runs only when RUN_DB_INTEGRITY_TESTS=1, like masterSaveFidelity.db.test.ts.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'year-create-alt';
const ALT = '03';
const STD = '02';
const scope = { tenantId: TENANT, coCode: ALT, lcCode: '01' };
const stdScope = { tenantId: TENANT, coCode: STD, lcCode: '01' };
const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });

const TABLES = ['GROUP_MAST', 'AC_MAST', 'ITEM_MAST', 'YEAR_MAST', 'CO_SET', 'CO_SET_NEW', 'CO_MAST'];
async function clean(): Promise<void> {
  for (const table of TABLES)
    await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
}
async function seedCompanies(): Promise<void> {
  await owner.$executeRawUnsafe(
    `INSERT INTO "CO_MAST" ("tenant_id","CO_CODE","CO_NAME","LC_CODE","ALTER_YEAR")
     VALUES ($1,'03','ALTERNATE YEAR COMPANY','01','Y'),($1,'02','STANDARD YEAR COMPANY','01','N')`,
    TENANT,
  );
}
/** Rows of YEAR_MAST for one company; the tenant is bound as $1, the company as $2. */
const yearRows = (coCode: string) =>
  owner.$queryRawUnsafe(
    `SELECT "CO_YEAR","OP_DATE",("CL_DATE")::date::text AS "CL_DATE","OLD_METHOD","YEAR_MONTH","MAIN_USER"
       FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "CO_YEAR"`,
    TENANT,
    coCode,
  ) as Promise<Record<string, unknown>[]>;

databaseDescribe('alternate-year company (desktop MS_YEAR alternate rule)', () => {
  beforeEach(async () => {
    await clean();
    await seedCompanies();
  });
  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('year-create.alt.create-footprint-apr-dec: 2026-2027 in month 11 stores key 202611 and the desktop footprint', async () => {
    // MS_YEAR.cs:1189 {{dataRow["CO_YEAR"] = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;}}
    // MS_YEAR.cs:1196 {{dataRow["CL_DATE"] = mClDate.Text;}}
    // MS_YEAR.cs:1197 {{dataRow["OLD_METHOD"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(}}
    // MS_YEAR.cs:1198 {{dataRow["YEAR_MONTH"] = tMonth.Text;}}
    // MS_YEAR.cs:1199 {{dataRow["MAIN_USER"] = DC_Main.MCo_User;}}
    const created = await createYear(runtime, scope, {
      coYear: '2026-2027',
      yearMonth: '11',
      opDate: '2026-11-01',
      mainUser: 'op1',
    });
    expect(created).toMatchObject({
      coYear: '2026-2027',
      coYearKey: '202611',
      opDate: '2026-11-01',
      clDate: '2027-11-01',
    });
    expect(await yearRows(ALT)).toEqual([
      {
        CO_YEAR: '202611',
        OP_DATE: '2026-11-01',
        CL_DATE: '2027-11-01',
        OLD_METHOD: 'N',
        YEAR_MONTH: '11',
        MAIN_USER: 'op1',
      },
    ]);
  });

  it('year-create.alt.create-footprint-jan-mar: 2026-2027 opened in February 2027 stores key 202602 and closes 2028-02-01', async () => {
    // MS_YEAR.cs:1022 {{mOpDate.Text = "01/" + tMonth.Text + "/" + Strings.Mid(tYearCode.Text, 6, 4);}}
    // MS_YEAR.cs:1023 {{Strings.Format((object)(Conversions.ToDouble(Strings.Mid(tYearCode.Text, 6, 4)) + 1.0), "00")}}
    // MS_YEAR.cs:1189 {{dataRow["CO_YEAR"] = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;}}
    const created = await createYear(runtime, scope, {
      coYear: '2026-2027',
      yearMonth: '02',
      opDate: '2027-02-01',
    });
    expect(created).toMatchObject({
      coYearKey: '202602',
      opDate: '2027-02-01',
      clDate: '2028-02-01',
    });
    expect(await yearRows(ALT)).toEqual([
      {
        CO_YEAR: '202602',
        OP_DATE: '2027-02-01',
        CL_DATE: '2028-02-01',
        OLD_METHOD: 'N',
        YEAR_MONTH: '02',
        MAIN_USER: null,
      },
    ]);
  });

  it('year-create.alt.second-year-same-month: 2027-2028 in month 11 stores key 202711 and leaves the first row unchanged', async () => {
    // MS_YEAR.cs:1189 {{dataRow["CO_YEAR"] = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;}}
    await createYear(runtime, scope, { coYear: '2026-2027', yearMonth: '11', opDate: '2026-11-01' });
    const second = await createYear(runtime, scope, {
      coYear: '2027-2028',
      yearMonth: '11',
      opDate: '2027-11-01',
    });
    expect(second).toMatchObject({ coYearKey: '202711', opDate: '2027-11-01', clDate: '2028-11-01' });
    expect(await yearRows(ALT)).toEqual([
      {
        CO_YEAR: '202611',
        OP_DATE: '2026-11-01',
        CL_DATE: '2027-11-01',
        OLD_METHOD: 'N',
        YEAR_MONTH: '11',
        MAIN_USER: null,
      },
      {
        CO_YEAR: '202711',
        OP_DATE: '2027-11-01',
        CL_DATE: '2028-11-01',
        OLD_METHOD: 'N',
        YEAR_MONTH: '11',
        MAIN_USER: null,
      },
    ]);
  });

  it('year-create.alt.duplicate-key-refused: the same alternate year twice is refused and one row remains', async () => {
    // MS_YEAR.cs:1189 {{dataRow["CO_YEAR"] = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;}}
    await createYear(runtime, scope, { coYear: '2026-2027', yearMonth: '11', opDate: '2026-11-01' });
    expect((await yearRows(ALT))[0]?.CO_YEAR).toBe('202611');
    await expect(
      createYear(runtime, scope, { coYear: '2026-2027', yearMonth: '11', opDate: '2026-11-01' }),
    ).rejects.toThrow(/already exists/);
    expect(await yearRows(ALT)).toHaveLength(1);
  });

  it('year-create.alt.flag-read-on-server: a body alterYear or oldMethod on a standard company is ignored', async () => {
    // MS_YEAR.cs:1010 {{if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)}}
    // MS_YEAR.cs:1193 {{dataRow["CO_YEAR"] = tYearCode.Text;}}
    // MS_YEAR.cs:1197 {{dataRow["OLD_METHOD"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(}}
    const body = { coYear: '2026-2027', alterYear: 'Y', oldMethod: 'N' };
    const created = await createYear(runtime, stdScope, body);
    expect(created.coYear).toBe('2026-2027');
    expect(await yearRows(STD)).toEqual([
      {
        CO_YEAR: '2026-2027',
        OP_DATE: '2026-04-01',
        CL_DATE: '2027-03-31',
        OLD_METHOD: 'Y',
        YEAR_MONTH: '04',
        MAIN_USER: null,
      },
    ]);
  });

  it('year-create.alt.date-check-and-listing: vouchers are checked against the stored alternate year and listYears returns its key', async () => {
    // MS_YEAR.cs:1196 {{dataRow["CL_DATE"] = mClDate.Text;}}
    await createYear(runtime, scope, { coYear: '2026-2027', yearMonth: '11', opDate: '2026-11-01' });
    const voucherScope = { ...scope, coYear: '202611', coBook: '000' } as any;
    await withTxBudget(runtime, TENANT, 'read', async (tx: any) => {
      await expect(assertFiscalDateTx(tx, voucherScope, '2027-10-31')).resolves.toBeUndefined();
      // The closing date 2027-11-01 is the last accepted day; 2027-11-02 is outside (inclusive closing, as in the
      // standard year). See the handoff note in .orch/report.md about the boundary day.
      await expect(assertFiscalDateTx(tx, voucherScope, '2027-11-02')).rejects.toThrow(
        /outside fiscal year 2026-11-01 to 2027-11-01/,
      );
    });
    await expect(listYears(runtime, scope)).resolves.toEqual([
      { coYear: '202611', opDate: '2026-11-01', clDate: '2027-11-01', yearMonth: '11' },
    ]);
  });
});
