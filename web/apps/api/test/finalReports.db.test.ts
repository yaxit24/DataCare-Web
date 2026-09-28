import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { finalReports, profitAndLoss } from '../src/modules/reports/reports.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'final-reports';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe() {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as { table_name: string }[];
  for (const r of rows) await owner.$executeRawUnsafe(`DELETE FROM "${r.table_name}" WHERE tenant_id=$1`, TENANT);
}

async function seed() {
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","TAX_ROF","ITM_RATE_ROF","ALL_ROF_REMOVE")
     VALUES ($1,$2,'N',2,2,2,'N')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF","PR_RATE_ROF") VALUES ($1,$2,0,2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  for (const [code, name, main, group] of [
    ['00004', 'Sales', '3', '25'],
    ['00008', 'Purchase', '4', '30'],
    ['00001', 'Cash', '1', '05'],
  ]) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_MAIN_GR","AC_GR","AC_GST_TYPE")
       VALUES ($1,$2,$3,$4,$5,$6,$7,'L')`,
      TENANT,
      CO,
      LC,
      code,
      name,
      main,
      group,
    );
  }
  const legs = [
    ['00004', 0, 1000],
    ['00008', 300, 0],
    ['00001', 700, 0],
    ['00001', 0, 700],
  ];
  let i = 0;
  for (const [ac, dr, cr] of legs) {
    i += 1;
    await exec(
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_TYPE","VCH_DATE","LEDR_KEY","BOOK_NAME","AC_CODE","DR_AMT","CR_AMT","IT_TYPE","SIGN","FINE_WT","DATA_TYPE")
       VALUES ($1,$2,$3,$4,'026','00001','GST','2024-04-10',$5,'SALES',$6,$7,$8,'A','',0,'A')`,
      TENANT,
      CO,
      LC,
      YEAR,
      `${CO}${LC}${YEAR}02600001${String(i).padStart(2, '0')}`,
      ac,
      dr,
      cr,
    );
  }
}

describe.runIf(RUN)('RP_BALANCE final reports', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('uses AC_MAIN_GR >= 3 for Profit and Loss and returns the launcher rows', async () => {
    const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR };
    const pnl = await profitAndLoss(runtime, scope);
    expect(pnl.rows.map((r) => [r.acCode, r.class, r.income, r.expense])).toEqual([
      ['00004', 'income', 1000, 0],
      ['00008', 'expense', 0, 300],
    ]);
    expect(pnl.totals).toMatchObject({ income: 1000, expense: 300, netProfit: 700 });

    const final = await finalReports(runtime, scope, { closingDate: '2024-04-10' });
    expect(final.rows.map((r) => r.statement)).toEqual(['Trial Balance', 'Profit and Loss', 'Balance Sheet']);
    expect(final.totals?.netProfit).toBe(700);
    expect(final.detail.profitAndLoss).toMatchObject({ totals: { netProfit: 700 } });
  });
});
