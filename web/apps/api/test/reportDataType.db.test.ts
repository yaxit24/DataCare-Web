import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { trialBalance } from '../src/modules/accounting/accounting.js';
import {
  billOutstanding,
  dayBook,
  outstandingReport,
  profitAndLoss,
  salesRegister,
  balanceSheet,
} from '../src/modules/reports/reports.js';
import { cashBook } from '../src/modules/reports/reports2.js';
import { rojmel } from '../src/modules/reports/rojmelReport.js';
import { trialBalanceFull } from '../src/modules/reports/reports8.js';
import { gstr1 } from '../src/modules/gst/gst.js';
import { bookDataTypeSql, dataTypeSql } from '../src/modules/reports/reportDataType.js';

/**
 * PR #292 review round 3, finding 4: reports read only the session data type's rows (desktop MsDataType filters,
 * Ac_Final.cs:151-182, RP_ROJMEL.cs:3048, RP_CASH_BANK.cs:2123, RP_OS.cs:3810/5533, RP_ALL.cs:7653, RP_TAX.cs:1941).
 * 'C' reads everything; a blank or NULL DATA_TYPE is read as 'A'.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'report-data-type';
const CO = '01';
const LC = '01';
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
  for (const r of rows)
    await owner.$executeRawUnsafe(`DELETE FROM "${r.table_name}" WHERE tenant_id=$1`, TENANT);
}

// Book 'SLA' is a type-A sales book, 'SLB' a type-B one. One voucher per type, plus a legacy NULL and a blank row.
const VOUCHERS: Array<{ book: string; vch: string; type: string | null; amount: number }> = [
  { book: 'SLA', vch: '00001', type: 'A', amount: 100 },
  { book: 'SLB', vch: '00002', type: 'B', amount: 20 },
  { book: 'SLA', vch: '00003', type: null, amount: 3 },
  { book: 'SLA', vch: '00004', type: '', amount: 4000 },
];

async function seed() {
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  for (const [code, name, main] of [
    ['00004', 'Sales', '3'],
    ['00001', 'Cash', '1'],
  ])
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_MAIN_GR","AC_GR")
       VALUES ($1,$2,$3,$4,$5,$6,'05')`,
      TENANT,
      CO,
      LC,
      code,
      name,
      main,
    );
  for (const [book, type] of [
    ['SLA', 'A'],
    ['SLB', 'B'],
  ])
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","DATA_TYPE")
       VALUES ($1,$2,$3,$4,$6,'SALES',$5)`,
      TENANT,
      CO,
      LC,
      book,
      type,
      `Sales ${book}`,
    );
  let key = 0;
  for (const v of VOUCHERS) {
    for (const [ac, dr, cr] of [
      ['00001', v.amount, 0],
      ['00004', 0, v.amount],
    ] as const) {
      key += 1;
      const ledrKey = `${CO}${LC}${YEAR}${v.book}${v.vch}${String(key).padStart(2, '0')}`;
      await exec(
        `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_TYPE","VCH_DATE","LEDR_KEY","BOOK_NAME","AC_CODE","DR_AMT","CR_AMT","IT_TYPE","SIGN","FINE_WT","DATA_TYPE")
         VALUES ($1,$2,$3,$4,$5,$6,'SL','2024-04-10',$7,'SALES',$8,$9,$10,'A','',0,$11)`,
        TENANT,
        CO,
        LC,
        YEAR,
        v.book,
        v.vch,
        ledrKey,
        ac,
        dr,
        cr,
        v.type,
      );
      await exec(
        `INSERT INTO "ROJ_MEL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_TYPE","VCH_DATE","LEDR_KEY","AC_CODE","DR_AMT","CR_AMT","IT_TYPE","DATA_TYPE")
         VALUES ($1,$2,$3,$4,$5,$6,'SL','2024-04-10',$7,$8,$9,$10,'A',$11)`,
        TENANT,
        CO,
        LC,
        YEAR,
        v.book,
        v.vch,
        ledrKey,
        ac,
        dr,
        cr,
        v.type,
      );
    }
    await exec(
      `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","NET_AMT","TOT_AMT")
       VALUES ($1,$2,$3,$4,$5,$6,'2024-04-10','00001',$7,$7)`,
      TENANT,
      CO,
      LC,
      YEAR,
      v.book,
      v.vch,
      v.amount,
    );
    // BILL_OS_DATA always carries the literal 'A' (posting/dataType.ts); its book decides the type.
    await exec(
      `INSERT INTO "BILL_OS_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","INOUT_TYPE","BILL_AMT","REC_AMT","DATA_TYPE")
       VALUES ($1,$2,$3,$4,$5,$6,1,'2024-04-10','00001','O',$7,0,'A')`,
      TENANT,
      CO,
      LC,
      YEAR,
      v.book,
      v.vch,
      v.amount,
    );
  }
}

const scope = (dataType?: string) => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  dataType,
});
// A sees A + NULL + blank; B sees B; C (and no type) sees all.
const EXPECTED: Record<string, number> = { A: 4103, B: 20, C: 4123 };

describe('report data type SQL', () => {
  it('filters only for A and B, inlining a whitelisted literal', () => {
    expect(dataTypeSql('C')).toBe('');
    expect(dataTypeSql(undefined)).toBe('');
    expect(dataTypeSql("A' OR 1=1 --")).toBe('');
    expect(dataTypeSql('B', 'd."DATA_TYPE"')).toBe(
      ` AND coalesce(nullif(btrim(d."DATA_TYPE"),''),'A')='B'`,
    );
    expect(bookDataTypeSql('C', 'x')).toBe('');
    expect(bookDataTypeSql('A', 'x')).toContain(`'A')='A'`);
  });
});

describe.runIf(RUN)('reports filter by the session data type', () => {
  beforeAll(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it.each(['A', 'B', 'C'])('trial balance for %s (Ac_Final.cs:151-182)', async (type) => {
    const tb = await trialBalance(runtime, scope(type));
    expect(tb.grandDr).toBe(EXPECTED[type]);
    expect(tb.grandCr).toBe(EXPECTED[type]);
    expect(tb.balanced).toBe(true);
    const full = await trialBalanceFull(runtime, scope(type));
    const dr = full.rows.reduce((t, r) => t + Number(r.dr ?? 0), 0);
    expect(dr).toBe(EXPECTED[type]);
  });

  it('a session without a type (All) reads every row', async () => {
    expect((await trialBalance(runtime, scope())).grandDr).toBe(EXPECTED.C);
  });

  it.each(['A', 'B', 'C'])('day book for %s (RP_ROJMEL.cs:3048)', async (type) => {
    const book = await dayBook(runtime, scope(type));
    expect(book.totals.dr).toBe(EXPECTED[type]);
    expect(new Set(book.rows.map((r) => r.vchNo))).toEqual(
      new Set(
        VOUCHERS.filter((v) =>
          type === 'C' ? true : (v.type || 'A') === type,
        ).map((v) => v.vch),
      ),
    );
    const roj = await rojmel(runtime, scope(type));
    expect(roj.totals.dr).toBe(EXPECTED[type]);
  });

  it.each(['A', 'B', 'C'])(
    'P&L, outstanding and cash book for %s (Ac_Final.cs, RP_OS.cs:3810, RP_CASH_BANK.cs:2123)',
    async (type) => {
      const pnl = await profitAndLoss(runtime, scope(type));
      expect(pnl.totals?.income).toBe(EXPECTED[type]);
      const os = await outstandingReport(runtime, scope(type));
      expect(os.totals?.receivable).toBe(EXPECTED[type]);
      const cash = await cashBook(runtime, scope(type));
      expect(cash.totals?.dr).toBe(EXPECTED[type]);
      const bs = await balanceSheet(runtime, scope(type), { closingDate: '2024-04-10' });
      expect(bs.ledgerDr).toBe(EXPECTED[type]);
    },
  );

  it.each(['A', 'B', 'C'])(
    'book-typed reports for %s: sales register, GSTR-1, bill outstanding (RP_ALL.cs:7653, RP_TAX.cs:1941, RP_OS.cs:5533)',
    async (type) => {
      const reg = await salesRegister(runtime, scope(type));
      expect(reg.totals.totAmt).toBe(EXPECTED[type]);
      const g = await gstr1(runtime, scope(type));
      const taxable =
        g.b2b.reduce((t, r) => t + r.taxable, 0) +
        g.b2cl.reduce((t, r) => t + r.taxable, 0) +
        g.b2cs.reduce((t, r) => t + r.taxable, 0);
      expect(taxable).toBe(EXPECTED[type]);
      const bills = await billOutstanding(runtime, scope(type));
      expect(bills.totals?.billed).toBe(EXPECTED[type]);
    },
  );
});
