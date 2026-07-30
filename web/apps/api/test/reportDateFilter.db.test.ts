import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { dateWhere, type ReportScope } from '../src/modules/reports/reports.js';
import { monthlySales, outstandingReport, salesByParty } from '../src/modules/reports/reports.js';
import { salesReturnRegister } from '../src/modules/reports/reports4.js';
import { dailySalesSummary } from '../src/modules/reports/reports5.js';
import { contraRegister, purchaseReturnRegister } from '../src/modules/reports/reports6.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * Report date-range filtering.
 *
 * Only 3 of 48 report routes accepted a date range and the UI never sent one, so every other report
 * returned a whole financial year with no way to narrow it. The desktop filters most families by a from/to
 * voucher date, so this closes a real gap.
 *
 * The assertions check EXACT rows and totals for a seeded window rather than "fewer rows came back", because
 * an off-by-one on the boundary is the failure that matters — a report that silently drops the last day of a
 * month is worse than one with no filter at all.
 */
describe('dateWhere helper', () => {
  it('appends nothing when no window is supplied', () => {
    const params: unknown[] = ['01'];
    expect(dateWhere({ tenantId: 't', coCode: '01' }, 'x."VCH_DATE"', params)).toBe('');
    expect(params).toEqual(['01']);
  });

  it('uses the next free positional parameters', () => {
    // The caller has already pushed $1 and $2, so the date predicate must start at $3.
    const params: unknown[] = ['01', '2024-2025'];
    const sql = dateWhere(
      { tenantId: 't', coCode: '01', fromDate: '2024-06-01', toDate: '2024-06-30' },
      'r."VCH_DATE"',
      params,
    );
    expect(sql).toBe(' AND r."VCH_DATE" >= $3::date AND r."VCH_DATE" <= $4::date');
    expect(params).toEqual(['01', '2024-2025', '2024-06-01', '2024-06-30']);
  });

  it('supports an open-ended window', () => {
    const p1: unknown[] = ['01'];
    expect(dateWhere({ tenantId: 't', coCode: '01', fromDate: '2024-06-01' }, 'c', p1)).toBe(
      ' AND c >= $2::date',
    );
    const p2: unknown[] = ['01'];
    expect(dateWhere({ tenantId: 't', coCode: '01', toDate: '2024-06-30' }, 'c', p2)).toBe(
      ' AND c <= $2::date',
    );
  });
});

d('report date filtering', () => {
  const prisma = new PrismaClient();
  // tenant_id is varchar(24), so DB tests use short kebab tenants.
  const tenantId = 'rptdate-db';
  const CO = '01';
  const LC = '01';
  const YEAR = '2024-2025';
  const base: ReportScope = { tenantId, coCode: CO, lcCode: LC, coYear: YEAR };

  const TABLES = ['SL_DETL_RTN', 'PR_DATA', 'SL_DATA', 'BOOK_DATA', 'AC_DATA', 'AC_MAST'];

  const clean = () =>
    withTenant(prisma, tenantId, async (tx: any) => {
      for (const t of TABLES) {
        await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenantId);
      }
    });

  beforeAll(async () => {
    await clean();
    await withTenant(prisma, tenantId, async (tx: any) => {
      // Three sales returns: one before the window, one exactly ON each boundary, one after.
      const ret = (vch: string, date: string, net: number) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "SL_DETL_RTN"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
             "AC_CODE","VCH_DATE","NET_AMT","RTN_IT_TAX_AMT","TOT_AMT")
           VALUES ($1,$2,$3,$4,'SRT',$5,1,'CASH',$6::date,$7,0,$7)`,
          tenantId,
          CO,
          LC,
          YEAR,
          vch,
          date,
          net,
        );
      await ret('00001', '2024-05-31', 100); // before
      await ret('00002', '2024-06-01', 200); // ON the from boundary — must be INCLUDED
      await ret('00003', '2024-06-30', 400); // ON the to boundary — must be INCLUDED
      await ret('00004', '2024-07-01', 800); // after
    });
  });
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
  });

  it('returns the whole year when no window is given', async () => {
    const r: any = await salesReturnRegister(prisma, base);
    expect(r.rows.map((x: any) => x.voucher)).toEqual([
      'SRT/00001',
      'SRT/00002',
      'SRT/00003',
      'SRT/00004',
    ]);
    expect(r.totals.total).toBeCloseTo(1500, 2);
  });

  it('includes rows ON both boundaries and excludes the rest', async () => {
    const r: any = await salesReturnRegister(prisma, {
      ...base,
      fromDate: '2024-06-01',
      toDate: '2024-06-30',
    });
    // Inclusive on both ends: 200 + 400 = 600. An exclusive boundary would give 0.
    expect(r.rows.map((x: any) => x.voucher)).toEqual(['SRT/00002', 'SRT/00003']);
    expect(r.totals.count).toBe(2);
    expect(r.totals.total).toBeCloseTo(600, 2);
  });

  it('supports an open-ended window', async () => {
    const from: any = await salesReturnRegister(prisma, { ...base, fromDate: '2024-07-01' });
    expect(from.rows.map((x: any) => x.voucher)).toEqual(['SRT/00004']);
    const to: any = await salesReturnRegister(prisma, { ...base, toDate: '2024-05-31' });
    expect(to.rows.map((x: any) => x.voucher)).toEqual(['SRT/00001']);
  });

  it('returns an empty result for a window with no vouchers', async () => {
    const r: any = await salesReturnRegister(prisma, {
      ...base,
      fromDate: '2025-01-01',
      toDate: '2025-01-31',
    });
    expect(r.rows).toEqual([]);
    expect(r.totals.count).toBe(0);
    expect(r.totals.total).toBeCloseTo(0, 2);
  });

  it('applies the same window to the purchase-return and contra registers', async () => {
    await withTenant(prisma, tenantId, async (tx: any) => {
      // purchaseReturnRegister reads PR_DATA and requires a BOOK_DATA row whose BOOK_TBL_NAME is
      // 'PR_DATA' and whose BOOK_NAME matches %return%, so the fixture must satisfy that too.
      await tx.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_TBL_NAME")
         VALUES ($1,$2,$3,'PRT','Purchase Return','PR_DATA')`,
        tenantId,
        CO,
        LC,
      );
      // contraRegister has its own prerequisite: a BOOK_DATA row whose BOOK_NAME matches %contra%.
      await tx.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_TBL_NAME")
         VALUES ($1,$2,$3,'CON','Contra','AC_DATA')`,
        tenantId,
        CO,
        LC,
      );
      for (const [vch, date, net] of [
        ['00001', '2024-06-15', 50],
        ['00002', '2024-08-15', 70],
      ] as [string, string, number][]) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "PR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE",
             "VCH_DATE","NET_AMT","TAX_AMT","TOT_AMT")
           VALUES ($1,$2,$3,$4,'PRT',$5,'CASH',$6::date,$7,0,$7)`,
          tenantId,
          CO,
          LC,
          YEAR,
          vch,
          date,
          net,
        );
      }
      await tx.$executeRawUnsafe(
        `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE",
           "VCH_DATE","DR_AMT","CR_AMT") VALUES ($1,$2,$3,$4,'CON','00001','CASH','2024-06-10'::date,10,0)`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE",
           "VCH_DATE","DR_AMT","CR_AMT") VALUES ($1,$2,$3,$4,'CON','00002','CASH','2024-09-10'::date,20,0)`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
    });
    const window = { ...base, fromDate: '2024-06-01', toDate: '2024-06-30' };
    const pr: any = await purchaseReturnRegister(prisma, window);
    expect(pr.rows.length).toBe(1);
    const con: any = await contraRegister(prisma, window);
    expect(con.rows.length).toBe(1);
  });

  it('applies the window to the sales-analysis family', async () => {
    await withTenant(prisma, tenantId, async (tx: any) => {
      const sale = (vch: string, date: string, tot: number) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE",
             "AC_NAME","VCH_DATE","TOT_AMT","NET_AMT")
           VALUES ($1,$2,$3,$4,'SL',$5,'CASH','Cash',$6::date,$7,$7)`,
          tenantId,
          CO,
          LC,
          YEAR,
          vch,
          date,
          tot,
        );
      await sale('00001', '2024-05-31', 100); // before
      await sale('00002', '2024-06-01', 200); // on the from boundary
      await sale('00003', '2024-06-30', 400); // on the to boundary
      await sale('00004', '2024-07-01', 800); // after
    });
    const win = { ...base, fromDate: '2024-06-01', toDate: '2024-06-30' };

    // Party analysis: only the two in-window invoices are counted.
    const byParty: any = await salesByParty(prisma, win);
    expect(byParty.rows.length).toBe(1);
    expect(Number(byParty.rows[0].bills)).toBe(2);
    expect(Number(byParty.rows[0].total)).toBeCloseTo(600, 2);

    // Monthly grouping collapses to the single month inside the window.
    const monthly: any = await monthlySales(prisma, win);
    expect(monthly.rows.map((r: any) => r.month)).toEqual(['2024-06']);
    expect(Number(monthly.rows[0].invoices)).toBe(2);

    // Daily summary yields exactly the two dated days.
    const daily: any = await dailySalesSummary(prisma, win);
    expect(daily.rows.length).toBe(2);

    // Without the window all four are visible, proving the filter is what narrowed them.
    const all: any = await salesByParty(prisma, base);
    expect(Number(all.rows[0].bills)).toBe(4);
  });

  it('applies the window to the ledger-derived outstanding report', async () => {
    await withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR")
         VALUES ($1,$2,$3,'PARTYD','Party D','SD')`,
        tenantId,
        CO,
        LC,
      );
      const led = (date: string, dr: number) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE",
             "VCH_DATE","DR_AMT","CR_AMT") VALUES ($1,$2,$3,$4,'SL','09999','PARTYD',$5::date,$6,0)`,
          tenantId,
          CO,
          LC,
          YEAR,
          date,
          dr,
        );
      await led('2024-06-15', 1000); // inside
      await led('2024-09-15', 2500); // outside
    });
    const inside: any = await outstandingReport(prisma, {
      ...base,
      fromDate: '2024-06-01',
      toDate: '2024-06-30',
    });
    const row = inside.rows.find((r: any) => r.acCode === 'PARTYD');
    // Only the in-window debit contributes; the September one must not.
    expect(Number(row.balance)).toBeCloseTo(1000, 2);
  });
});
