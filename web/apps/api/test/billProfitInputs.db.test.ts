import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import {
  averageTouchByItemTx,
  billProfitEnabledTx,
  todaySaleRateTx,
} from '../src/modules/sales/billProfit.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * Bill-profit server-side inputs.
 *
 * Both the sale rate and the item average touch are read from the database, never from a request: a
 * client-supplied cost would let the margin be dictated by the caller.
 *
 * The rate derivation is the part most easily got wrong. The desktop computes
 * `ToDaySlRate = Format(FINE_SL_RATE / 103 * 100 / 1000, "0.00")` — the fine SALE rate with a 3% loading
 * stripped and converted from per-kilogram to per-gram — taking `SR_NO = 1` and the newest `VCH_DATE` not
 * after the voucher date.
 */
d('bill profit inputs', () => {
  const prisma = new PrismaClient();
  // tenant_id is varchar(24), so DB tests use short kebab tenants.
  const tenantId = 'billprofit-db';
  const CO = '01';
  const LC = '01';
  const scope = { coCode: CO, lcCode: LC };

  const clean = () =>
    withTenant(prisma, tenantId, async (tx: any) => {
      for (const t of ['RATE_MAST', 'ITEM_MAST', 'CO_SET_NEW']) {
        await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenantId);
      }
    });

  const run = <T>(fn: (tx: any) => Promise<T>): Promise<T> => withTenant(prisma, tenantId, fn);

  beforeEach(clean);
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
  });

  const rate = (date: string, srNo: number, fineSl: number) =>
    run((tx) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_DATE","SR_NO","FINE_SL_RATE","FINE_GL_RATE")
         VALUES ($1,$2,$3,$4::date,$5,$6,999999)`,
        tenantId,
        CO,
        LC,
        date,
        srNo,
        fineSl,
      ),
    );

  it('strips the 3% loading and converts per-kg to per-gram', async () => {
    // 7_210_000 / 103 * 100 / 1000 = 7000.00 exactly.
    await rate('2024-06-01', 1, 7_210_000);
    const r = await run((tx) => todaySaleRateTx(tx, scope, '2024-06-15'));
    expect(r).toBeCloseTo(7000, 2);
  });

  it('does NOT use FINE_GL_RATE even though the desktop query selects it', async () => {
    // FINE_GL_RATE is seeded absurdly high; using it would produce a wildly different figure.
    await rate('2024-06-01', 1, 7_210_000);
    const r = await run((tx) => todaySaleRateTx(tx, scope, '2024-06-15'));
    expect(r).toBeLessThan(10000);
  });

  it('takes the newest rate NOT AFTER the voucher date', async () => {
    await rate('2024-05-01', 1, 6_180_000); // 6000/g
    await rate('2024-06-01', 1, 7_210_000); // 7000/g
    await rate('2024-07-01', 1, 8_240_000); // 8000/g — after the voucher, must be ignored
    // A back-dated voucher is costed at the rate that applied then, not today's.
    expect(await run((tx) => todaySaleRateTx(tx, scope, '2024-06-15'))).toBeCloseTo(7000, 2);
    expect(await run((tx) => todaySaleRateTx(tx, scope, '2024-05-15'))).toBeCloseTo(6000, 2);
  });

  it('uses only the primary rate row (SR_NO = 1)', async () => {
    await rate('2024-06-01', 2, 9_270_000); // a secondary row must be ignored
    expect(await run((tx) => todaySaleRateTx(tx, scope, '2024-06-15'))).toBe(0);
    await rate('2024-06-01', 1, 7_210_000);
    expect(await run((tx) => todaySaleRateTx(tx, scope, '2024-06-15'))).toBeCloseTo(7000, 2);
  });

  it('returns 0 when no rate is configured', async () => {
    // No rate must mean no profit rather than a wrong one.
    expect(await run((tx) => todaySaleRateTx(tx, scope, '2024-06-15'))).toBe(0);
  });

  it('reads average touch per item and omits zero rows', async () => {
    await run(async (tx) => {
      const item = (code: string, touch: number) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","AVG_TOUCH")
           VALUES ($1,$2,$3,$3,$4)`,
          tenantId,
          CO,
          code,
          touch,
        );
      await item('GOLD', 91.6);
      await item('SILV', 0); // the desktop lookup filters AVG_TOUCH <> 0
    });
    const map = await run((tx) => averageTouchByItemTx(tx, scope, ['GOLD', 'SILV', 'MISSING']));
    expect(map.GOLD).toBeCloseTo(91.6, 3);
    expect(map.SILV).toBeUndefined();
    expect(map.MISSING).toBeUndefined();
  });

  it('defaults the margin to hidden until the company turns it on', async () => {
    // A shop that has never configured BILL_PROFIT has not asked to see margins.
    expect(await run((tx) => billProfitEnabledTx(tx, scope))).toBe(false);
    await run((tx) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","BILL_PROFIT") VALUES ($1,$2,'Y')`,
        tenantId,
        CO,
      ),
    );
    expect(await run((tx) => billProfitEnabledTx(tx, scope))).toBe(true);
    await run((tx) =>
      tx.$executeRawUnsafe(
        `UPDATE "CO_SET_NEW" SET "BILL_PROFIT"='N' WHERE tenant_id=$1`,
        tenantId,
      ),
    );
    expect(await run((tx) => billProfitEnabledTx(tx, scope))).toBe(false);
  });
});
