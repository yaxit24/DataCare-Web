import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { closingStockValuation } from '../src/modules/reports/closingStock.js';
import { balanceSheet } from '../src/modules/reports/reports.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * Closing-stock valuation parity — desktop `Ac_Final.Trading_Stock` (`Ac_Final.cs:18-138`).
 *
 * The central assertion is that closing stock is computed from INVENTORY, not derived as the figure that
 * makes the sheet balance. The fixture is built so the two answers cannot coincide: the ledger is
 * deliberately lopsided, so a `ΣCr − ΣDr` balancing figure produces a different number from the real
 * inventory valuation. A regression to the balancing figure therefore fails on an exact value.
 */
d('closing stock valuation (Ac_Final parity)', () => {
  const prisma = new PrismaClient();
  // tenant_id is varchar(24) on all tables, so DB tests use short kebab tenants.
  const tenantId = 'closing-stock-db';
  const CO = '01';
  const LC = '01';
  const YEAR = '2024-2025';
  const CLOSING = '2025-03-31';

  const scope = { tenantId, coCode: CO, coYear: YEAR };

  const clean = () =>
    withTenant(prisma, tenantId, async (tx: any) => {
      for (const t of ['AC_DATA', 'MAIN_STOCK', 'ITEM_MAST', 'BAL_GR', 'CO_SET_NEW']) {
        await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenantId);
      }
    });

  /** Seed: gold trading group with 10.000 fine, plus a non-metal group valued from BAL_GR averages. */
  const seed = async (balanceSheetType: string) =>
    withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","PROFIT_RPT_TYPE") VALUES ($1,$2,$3)`,
        tenantId,
        CO,
        balanceSheetType,
      );
      // BAL_GR stores AVG_* as VARCHAR — deliberately written as text to prove the Val-style cast works.
      await tx.$executeRawUnsafe(
        `INSERT INTO "BAL_GR"(tenant_id,"CO_CODE","TRAD_TYPE","TRAD_NAME","IT_TYPE","AVG_FINE","AVG_AMT",
           "AVG_RATE","AVG_NWT","TOT_PCS","PCS_RATE","CLG_AC","CLOSING_AC")
         VALUES ($1,$2,'GO','Gold Stock','G','10.000','500','0','0',0,0,'CLGGOLD','CLOSEGOLD')`,
        tenantId,
        CO,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "BAL_GR"(tenant_id,"CO_CODE","TRAD_TYPE","TRAD_NAME","IT_TYPE","AVG_FINE","AVG_AMT",
           "AVG_RATE","AVG_NWT","TOT_PCS","PCS_RATE","CLG_AC","CLOSING_AC")
         VALUES ($1,$2,'IM','Imitation','O','0','0','100','9',2,50,'CLGIMIT','CLOSEIMIT')`,
        tenantId,
        CO,
      );
      for (const [itCode, trad] of [
        ['GOLD', 'GO'],
        ['IMIT', 'IM'],
      ]) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","TRAD_TYPE")
           VALUES ($1,$2,$3,$3,$4)`,
          tenantId,
          CO,
          itCode,
          trad,
        );
      }
      // Inventory movement: +12.000 in, -3.000 out => net 9.000 net weight for the gold item.
      // ITM_MRP = 0 so it lands in ClNwt (Ac_Final.cs:40 counts ITM_NWT only when ITM_MRP = 0).
      const mv = async (sign: string, nwt: number, pcs: number, date: string) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","IT_CODE","ITM_SIGN",
             "ITM_NWT","ITM_PCS","ITM_MRP","VCH_DATE")
           VALUES ($1,$2,$3,$4,'GOLD',$5,$6,$7,0,$8::date)`,
          tenantId,
          CO,
          LC,
          YEAR,
          sign,
          nwt,
          pcs,
          date,
        );
      await mv('+', 12.0, 3, '2024-06-01');
      await mv('-', 3.0, 1, '2024-09-01');
      // Beyond the closing date: must be EXCLUDED by VCH_DATE <= FinalClDt.
      await mv('+', 99.0, 9, '2025-08-01');
      // Lopsided ledger so a balancing figure cannot equal the inventory valuation.
      await tx.$executeRawUnsafe(
        `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","AC_CODE","DR_AMT","CR_AMT")
         VALUES ($1,$2,$3,$4,'SL','CASH',1000,0)`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","AC_CODE","DR_AMT","CR_AMT")
         VALUES ($1,$2,$3,$4,'SL','CAPITAL',0,4000)`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
    });

  beforeAll(clean);
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
  });

  it("values metal from BAL_GR fine at rate/10 plus AVG_AMT in 'F' mode", async () => {
    await clean();
    await seed('F');
    const r = await closingStockValuation(prisma, scope, {
      closingDate: CLOSING,
      goldRate: 70000,
      silverRate: 0,
    });
    expect(r.mode).toBe('computed');
    expect(r.balanceSheetType).toBe('F');
    expect(r.metalValued).toBe(true);
    const gold = r.rows.find((x) => x.code === 'GO');
    // 10.000 fine x (70000/10) + 500 AVG_AMT = 70,500 exactly.
    expect(gold?.basis).toBe('fine');
    expect(gold?.value).toBe(70500);
    // Non-metal always valued from BAL_GR averages: 9 x 100 + 2 x 50 = 1,000.
    const imit = r.rows.find((x) => x.code === 'IM');
    expect(imit?.basis).toBe('amount');
    expect(imit?.value).toBe(1000);
    expect(r.total).toBe(71500);
  });

  it('applies the ledger-fine adjustment only to the GO group', async () => {
    await clean();
    await seed('F');
    // Positive ledger fine is SUBTRACTED (Ac_Final.cs:54): (10.000 - 2.000) x 7000 + 500 = 56,500.
    const r = await closingStockValuation(prisma, scope, {
      closingDate: CLOSING,
      goldRate: 70000,
      ledgerFineGold: 2,
    });
    expect(r.rows.find((x) => x.code === 'GO')?.value).toBe(56500);
    // Negative ledger fine is ADDED by magnitude: (10.000 + 2.000) x 7000 + 500 = 84,500.
    const r2 = await closingStockValuation(prisma, scope, {
      closingDate: CLOSING,
      goldRate: 70000,
      ledgerFineGold: -2,
    });
    expect(r2.rows.find((x) => x.code === 'GO')?.value).toBe(84500);
  });

  it("does NOT value metal outside 'F' mode", async () => {
    await clean();
    await seed('A'); // Amount Wise
    const r = await closingStockValuation(prisma, scope, {
      closingDate: CLOSING,
      goldRate: 70000,
    });
    expect(r.metalValued).toBe(false);
    expect(r.rows.some((x) => x.code === 'GO')).toBe(false);
    // The non-metal pass still runs (Ac_Final.cs:102 is outside the 'F' branch).
    expect(r.total).toBe(1000);
  });

  it('skips the computed pass when operator values exist in book 888', async () => {
    await clean();
    await seed('F');
    await withTenant(prisma, tenantId, (tx: any) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","AC_CODE","DR_AMT","CR_AMT")
         VALUES ($1,$2,$3,$4,'888','CLGGOLD',12345,0)`,
        tenantId,
        CO,
        LC,
        YEAR,
      ),
    );
    const r = await closingStockValuation(prisma, scope, {
      closingDate: CLOSING,
      goldRate: 70000,
    });
    expect(r.mode).toBe('managed');
    expect(r.total).toBe(12345);
    expect(r.rows).toEqual([]);
  });

  it('returns a balanced double-entry pair per group without writing it', async () => {
    await clean();
    await seed('F');
    const before: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(`SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1`, tenantId),
    );
    const r = await closingStockValuation(prisma, scope, {
      closingDate: CLOSING,
      goldRate: 70000,
    });
    const dr = r.legs.reduce((a, l) => a + l.drAmt, 0);
    const cr = r.legs.reduce((a, l) => a + l.crAmt, 0);
    expect(dr).toBe(cr); // the pair balances by construction (Ac_Final.cs:88,90)
    expect(dr).toBe(r.total);
    expect(r.legs.map((l) => l.acCode)).toContain('CLGGOLD');
    expect(r.legs.map((l) => l.acCode)).toContain('CLOSEGOLD');
    // Read-only: rendering must not post to the ledger.
    const after: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(`SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1`, tenantId),
    );
    expect(Number(after[0].n)).toBe(Number(before[0].n));
  });

  it('exposes a REAL difference instead of a balancing figure', async () => {
    await clean();
    await seed('F');
    const bs: any = await balanceSheet(prisma, scope, {
      closingDate: CLOSING,
      goldRate: 70000,
    });
    expect(bs.ledgerDr).toBe(1000);
    expect(bs.ledgerCr).toBe(4000);
    // Inventory valuation is 71,500 and owes nothing to the ledger imbalance.
    expect(bs.closingStock).toBe(71500);
    // The old implementation would have produced closingStock = cr - dr = 3000. Pin that it does not.
    expect(bs.closingStock).not.toBe(3000);
    expect(bs.totalAssets).toBe(72500); // 1000 + 71500
    expect(bs.totalLiabilities).toBe(4000);
    // The difference is real and visible: 72,500 - 4,000 = 68,500.
    expect(bs.difference).toBe(68500);
    expect(bs.balanced).toBe(false);
  });
});
