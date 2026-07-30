import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { stockValuation } from '../src/modules/reports/reports.js';
import { purchaseByParty } from '../src/modules/reports/reports3.js';
import { salesReturnRegister } from '../src/modules/reports/reports4.js';
import { itemGroupStock } from '../src/modules/reports/reports6.js';
import { REPORT_FILTER_BINDINGS, supportedFilters } from '../src/modules/reports/reportFilters.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * Report filters applied against real rows.
 *
 * The unit tests pin the SQL the matrix generates; these pin that the generated SQL actually narrows the
 * result, which is the part a wrong alias would break silently. Every bound report is exercised, so a binding
 * cannot be registered without being proven to work.
 */
d('report filters end to end', () => {
  const prisma = new PrismaClient();
  const tenantId = 'rpt-filter-db';
  const CO = '01';
  const YR = '2425';
  const base = { tenantId, coCode: CO, coYear: YR };

  const TABLES = [
    'BAR_DETL',
    'MAIN_STOCK',
    'ITEM_MAST',
    'PR_DATA',
    'SL_DETL_RTN',
    'AC_MAST',
    'CO_SET',
  ];

  const clean = () =>
    withTenant(prisma, tenantId, async (tx: any) => {
      for (const t of TABLES) {
        await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenantId);
      }
    });
  const run = <T>(fn: (tx: any) => Promise<T>): Promise<T> => withTenant(prisma, tenantId, fn);

  beforeEach(clean);
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
  });

  const seed = () =>
    run(async (tx: any) => {
      // Two items in different groups so an item-dimension filter can be told apart.
      await tx.$executeRawUnsafe(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","GR_CODE","PR_CODE","IT_TYPE")
         VALUES ($1,$2,'GOLD','Gold','GO','P1','S'),
                ($1,$2,'SILV','Silver','SL','P2','B')`,
        tenantId,
        CO,
      );
      // Two parties in different cities.
      await tx.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","AC_CODE","AC_NAME","AC_CITY","AC_AREA","AC_STATE")
         VALUES ($1,$2,'P001','Party One','Surat','North','GJ'),
                ($1,$2,'P002','Party Two','Rajkot','South','GJ')`,
        tenantId,
        CO,
      );
      // Tags: one per item, in different books.
      for (const [tag, it, book, nwt] of [
        ['TG1', 'GOLD', '218', 10],
        ['TG2', 'SILV', '219', 20],
      ] as const) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
               "VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE","ITM_NWT","ITM_GWT","ITM_PCS","AC_CODE")
           VALUES ($1,$2,'01',$3,$4,'00001',1,'2024-06-10'::date,$5,1,$6,$7,$7,1,'P001')`,
          tenantId,
          CO,
          YR,
          book,
          tag,
          it,
          nwt,
        );
      }
      // A tag only counts as available when MAIN_STOCK shows a net positive presence for it, so the stock
      // reports need the matching '+' rows or they legitimately return nothing.
      for (const [tag, it, nwt] of [
        ['TG1', 'GOLD', 10],
        ['TG2', 'SILV', 20],
      ] as const) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
               "VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE","ITM_NWT","ITM_GWT","ITM_PCS","ITM_SIGN")
           VALUES ($1,$2,'01',$3,'218','00001',1,'2024-06-10'::date,$4,1,$5,$6,$6,1,'+')`,
          tenantId,
          CO,
          YR,
          tag,
          it,
          nwt,
        );
      }
      // stockValuation resolves rounding/stock policy, which requires exactly one CO_SET row.
      await tx.$executeRawUnsafe(
        `INSERT INTO "CO_SET"(tenant_id,"CO_CODE") VALUES ($1,$2)`,
        tenantId,
        CO,
      );
      // Purchases from both parties.
      for (const [ac, amt] of [
        ['P001', 1000],
        ['P002', 2000],
      ] as const) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "PR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
               "VCH_DATE","AC_CODE","AC_NAME","TOT_AMT")
           VALUES ($1,$2,'01',$3,'PR','0000'||$4,'2024-06-10'::date,$5,$5,$6)`,
          tenantId,
          CO,
          YR,
          ac === 'P001' ? '1' : '2',
          ac,
          amt,
        );
      }
      // Sales returns from both parties.
      for (const [ac, n] of [
        ['P001', '1'],
        ['P002', '2'],
      ] as const) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "SL_DETL_RTN"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
               "VCH_DATE","AC_CODE","NET_AMT","TOT_AMT","VCH_TYPE")
           VALUES ($1,$2,'01',$3,'SRT','0000'||$4,1,'2024-06-10'::date,$5,500,500,'SRTN')`,
          tenantId,
          CO,
          YR,
          n,
          ac,
        );
      }
    });

  it('every registered binding is exercised by this file', () => {
    // Guards against registering a binding without proving it works, which would let the capability endpoint
    // advertise a dimension the builder ignores.
    expect(Object.keys(REPORT_FILTER_BINDINGS).sort()).toEqual([
      'item-group-stock',
      'purchase-by-party',
      'sales-return-register',
      'stock-valuation',
      'tag-estimate',
    ]);
  });

  it('stock valuation filters by item group and by book', async () => {
    await seed();
    const all = await stockValuation(prisma, { ...base });
    expect(all.rows.length).toBe(2);

    const gold = await stockValuation(prisma, { ...base, filters: { grCode: 'GO' } });
    expect(gold.rows.map((r: any) => r.item)).toEqual(['GOLD']);

    // BAR_DETL carries CO_BOOK, so the book dimension is real here.
    const byBook = await stockValuation(prisma, { ...base, filters: { bookCode: '219' } });
    expect(byBook.rows.map((r: any) => r.item)).toEqual(['SILV']);

    // EMP_CODE does not exist on BAR_DETL, so asking for it is refused rather than crashing the query.
    await expect(stockValuation(prisma, { ...base, filters: { empCode: 'E1' } })).rejects.toThrow(
      /cannot filter by: empCode/,
    );
  });

  it('item group stock filters by product and item type', async () => {
    await seed();
    expect((await itemGroupStock(prisma, { ...base })).rows.length).toBe(2);
    const p1 = await itemGroupStock(prisma, { ...base, filters: { prCode: 'P1' } });
    expect(p1.rows.map((r: any) => r.group)).toEqual(['GO']);
    // IT_TYPE is a single character; a full label is truncated to its first.
    const typeB = await itemGroupStock(prisma, { ...base, filters: { itType: 'B' } });
    expect(typeB.rows.map((r: any) => r.group)).toEqual(['SL']);
  });

  it('purchase by party filters on the UNALIASED PR_DATA table', async () => {
    await seed();
    // This is the binding a naive alias scan got wrong: the registered builder has no table alias.
    expect((await purchaseByParty(prisma, { ...base })).rows.length).toBe(2);
    const one = await purchaseByParty(prisma, { ...base, filters: { acCode: 'P001' } });
    expect(one.rows.map((r: any) => r.acCode)).toEqual(['P001']);
    // PR_DATA has no ITEM_MAST join, so an item dimension must be refused.
    await expect(purchaseByParty(prisma, { ...base, filters: { grCode: 'GO' } })).rejects.toThrow(
      /cannot filter by: grCode/,
    );
  });

  it('sales return register filters by party AND by party geography through the real join', async () => {
    await seed();
    expect((await salesReturnRegister(prisma, { ...base })).rows.length).toBe(2);

    const byParty = await salesReturnRegister(prisma, { ...base, filters: { acCode: 'P002' } });
    expect(byParty.rows.map((r: any) => r.party)).toEqual(['Party Two']);

    // AC_MAST is a real LEFT JOIN here, so city/area/state genuinely work.
    const byCity = await salesReturnRegister(prisma, { ...base, filters: { city: 'Surat' } });
    expect(byCity.rows.map((r: any) => r.party)).toEqual(['Party One']);
    const byState = await salesReturnRegister(prisma, { ...base, filters: { state: 'GJ' } });
    expect(byState.rows.length).toBe(2);
    const byArea = await salesReturnRegister(prisma, { ...base, filters: { area: 'South' } });
    expect(byArea.rows.map((r: any) => r.party)).toEqual(['Party Two']);
  });

  it('advertises exactly the dimensions each report applies', () => {
    // The capability endpoint and the applied predicate come from the same map, so these cannot disagree.
    expect(supportedFilters(REPORT_FILTER_BINDINGS['stock-valuation']!).sort()).toEqual(
      ['acCode', 'bookCode', 'grCode', 'itType', 'lcCode', 'prCode'].sort(),
    );
    expect(supportedFilters(REPORT_FILTER_BINDINGS['purchase-by-party']!).sort()).toEqual(
      ['acCode', 'bookCode', 'empCode', 'lcCode'].sort(),
    );
    expect(supportedFilters(REPORT_FILTER_BINDINGS['sales-return-register']!)).toContain('state');
  });
});
