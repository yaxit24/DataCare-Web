import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import {
  entryCheckDetailReport,
  entryCheckReport,
  markEntryChecked,
} from '../src/modules/reports/userAuditReports.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'entry-check-report';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe(): Promise<void> {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as Array<{ table_name: string }>;
  for (const table of tables) {
    await owner.$executeRawUnsafe(`DELETE FROM "${table.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

const databaseDescribe = RUN ? describe : describe.skip;

databaseDescribe('RP_USER Entry Check parity', () => {
  beforeEach(async () => {
    await wipe();
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","DATA_TYPE")
       VALUES ($1,$2,$3,'SAL','Sales Book','SALES','S'),($1,$2,$3,'PUR','Purchase Book','PURCHASE','S')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_AREA","AC_CITY","AC_STATE")
       VALUES ($1,$2,$3,'C001','Alpha Buyer','Ring Road','Surat','24'),
              ($1,$2,$3,'C002','Beta Buyer','Kalawad','Rajkot','24')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "USER_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","VCH_DATE","EDIT_DATE","ENTRY_TIME","USER_NAME","NEW_USER","COL_TYPE","OLD_VAL","NEW_VAL","ENTRY_CHECK")
       VALUES ($1,$2,$3,$4,'SAL','00001','C001','2024-06-09','2024-06-10','2024-06-10 10:00:00','CLERK','OWNER','NET_AMT','100','120','N'),
              ($1,$2,$3,$4,'SAL','00001','C001','2024-06-09','2024-06-10','2024-06-10 10:05:00','CLERK','OWNER','TAX_AMT','3','4','N'),
              ($1,$2,$3,$4,'PUR','00002','C002','2024-06-11','2024-06-11','2024-06-11 11:00:00','OTHER','OWNER','TOT_AMT','200','210','Y')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
  });

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('lists only pending grouped vouchers by default and honours desktop filters', async () => {
    const report = await entryCheckReport(
      runtime,
      {
        tenantId: TENANT,
        coCode: CO,
        lcCode: LC,
        coYear: YEAR,
        fromDate: '2024-06-01',
        toDate: '2024-06-30',
        filters: { bookCode: 'SAL', acCode: 'C001', city: 'Surat' },
      },
      { userName: 'CLERK' },
    );

    expect(report.rows).toHaveLength(1);
    expect(report.rows[0]).toMatchObject({
      coBook: 'SAL',
      bookName: 'Sales Book',
      mainBook: 'SALES',
      acName: 'Alpha Buyer',
      vchNo: '00001',
      editDate: '2024-06-10',
      userName: 'CLERK',
      editUser: 'OWNER',
      entryCheck: 'N',
    });
  });

  it('returns the desktop double-click field-change detail rows', async () => {
    const detail = await entryCheckDetailReport(
      runtime,
      {
        tenantId: TENANT,
        coCode: CO,
        lcCode: LC,
        coYear: YEAR,
        fromDate: '2024-06-01',
        toDate: '2024-06-30',
      },
      { coBook: 'SAL', vchNo: '00001' },
    );

    expect(detail.rows.map((r) => r.field)).toEqual(['TAX_AMT', 'NET_AMT']);
    expect(detail.rows[0]).toMatchObject({
      oldValue: '3',
      newValue: '4',
      entryTime: '2024-06-10 10:05:00',
    });
  });

  it('marks matching voucher/date/book rows checked like BtnSave', async () => {
    const before = await entryCheckReport(runtime, {
      tenantId: TENANT,
      coCode: CO,
      lcCode: LC,
      coYear: YEAR,
      fromDate: '2024-06-01',
      toDate: '2024-06-30',
    });
    expect(before.rows.map((r) => r.vchNo)).toEqual(['00001']);

    const result = await markEntryChecked(
      runtime,
      {
        tenantId: TENANT,
        coCode: CO,
        lcCode: LC,
        coYear: YEAR,
      },
      [{ coBook: 'SAL', vchNo: '00001', editDate: '2024-06-10' }],
    );

    expect(result.updated).toBe(2);
    const after = await entryCheckReport(runtime, {
      tenantId: TENANT,
      coCode: CO,
      lcCode: LC,
      coYear: YEAR,
      fromDate: '2024-06-01',
      toDate: '2024-06-30',
    });
    expect(after.rows).toEqual([]);

    const all = await entryCheckReport(
      runtime,
      {
        tenantId: TENANT,
        coCode: CO,
        lcCode: LC,
        coYear: YEAR,
        fromDate: '2024-06-01',
        toDate: '2024-06-30',
      },
      { pendingOnly: false },
    );
    expect(all.rows.map((r) => [r.vchNo, r.entryCheck])).toEqual([
      ['00001', 'Y'],
      ['00002', 'Y'],
    ]);
  });
});
