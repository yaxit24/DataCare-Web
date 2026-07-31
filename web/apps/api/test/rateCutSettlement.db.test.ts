import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { postRateCut } from '../src/modules/sales/rateCut.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * Rate-cut settlement and rate basis.
 *
 * Two things are pinned here:
 *
 * 1. `RATE_CUT_DATA.RATE_PAR` must mirror the company's configured metal-rate basis. It was hardcoded to
 *    `'G'`, which silently mislabels every voucher at a shop quoting rates per 10 grams or per kilogram —
 *    and the desktop reads that column back when reopening a voucher (`TR_WH_SALE.cs:12215`), so a wrong
 *    value is not merely cosmetic. The desktop sets it from `MsRatePar` for a new voucher
 *    (`TR_WH_SALE.cs:12086-12099`) and writes it at `:12974`.
 *
 * 2. The money/metal settlement is derived and persisted, so a party balance can be closed in rupees and
 *    fine metal together (`TR_TOUR_SALE.cs:12999-13130`).
 */
d('rate-cut settlement persistence', () => {
  const prisma = new PrismaClient();
  // tenant_id is varchar(24), so DB tests use short kebab tenants.
  const tenantId = 'ratecut-set-db';
  const CO = '01';
  const LC = '01';
  const YEAR = '2024-2025';
  const scope = { tenantId, coCode: CO, lcCode: LC, coYear: YEAR, coBook: 'RCT' } as any;

  const TABLES = [
    'RATE_CUT_DATA',
    'RATE_CUT_ISU',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'CO_SET',
    'SRNO_MAST',
    'BOOK_DATA',
    'BOOK_DETL',
  ];

  const clean = () =>
    withTenant(prisma, tenantId, async (tx: any) => {
      for (const t of TABLES) {
        await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenantId);
      }
    });

  /** CO_SET must hold exactly one row: resolveSettingsBehaviorTx fails closed otherwise. */
  const setBasis = async (basis: string) =>
    withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(`DELETE FROM "CO_SET" WHERE tenant_id=$1`, tenantId);
      await tx.$executeRawUnsafe(
        `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","RATE_PAR") VALUES ($1,$2,$3)`,
        tenantId,
        CO,
        basis,
      );
    });

  const line = {
    itCode: 'GOLD',
    pcs: 1,
    grossWt: 10,
    othWt: 0,
    ghtPct: 0,
    touch: 100,
    rate: 7000,
  } as any;

  beforeEach(async () => {
    await clean();
    await withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_SRNO","TAG_SRNO") VALUES ($1,$2,$3,'0','0')`,
        tenantId,
        CO,
        LC,
      );
    });
  });
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
  });

  const header = () =>
    withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "RATE_PAR","FINE_RATE","DR_AMT","CR_AMT","CONV_RATE","CONV_PRC"
           FROM "RATE_CUT_DATA" WHERE tenant_id=$1 ORDER BY row_id DESC LIMIT 1`,
        tenantId,
      ),
    );

  it.each([['G'], ['T'], ['K']])(
    'writes RATE_PAR = %s from the company setting, not a constant',
    async (basis) => {
      await setBasis(basis);
      await postRateCut(prisma, { scope, acCode: 'CASH', lines: [line] });
      const h: any[] = await header();
      expect(h[0].RATE_PAR).toBe(basis);
    },
  );

  it('derives and persists the settlement money leg from a metal leg', async () => {
    await setBasis('T'); // per 10 grams
    await postRateCut(prisma, {
      scope,
      acCode: 'CASH',
      lines: [line],
      // Operator supplies the rate and the metal side; the money side must be derived.
      convRate: 7000,
      settleCrFine: 100,
    });
    const h: any[] = await header();
    // fineRate = convRate = 7000; drAmt = round(100 x (7000/10), 0) = 70,000.
    expect(Number(h[0].DR_AMT)).toBe(70000);
    expect(Number(h[0].CR_AMT)).toBe(0);
    expect(String(h[0].CONV_RATE)).toBe('7000');
  });

  it('honours the per-kilogram basis in the derived amount', async () => {
    await setBasis('K');
    await postRateCut(prisma, {
      scope,
      acCode: 'CASH',
      lines: [line],
      convRate: 700000,
      settleCrFine: 100,
    });
    const h: any[] = await header();
    // drAmt = round(100 x (700000/1000), 0) = 70,000 — the same money from a per-kg quote.
    expect(Number(h[0].DR_AMT)).toBe(70000);
  });

  it('leaves the settlement at zero when no conversion is supplied', async () => {
    await setBasis('G');
    await postRateCut(prisma, { scope, acCode: 'CASH', lines: [line] });
    const h: any[] = await header();
    // An ordinary rate-cut voucher must be unchanged by the new feature.
    expect(Number(h[0].DR_AMT)).toBe(0);
    expect(Number(h[0].CR_AMT)).toBe(0);
    expect(h[0].CONV_RATE).toBeNull();
  });

  it('never overwrites an operator-supplied money leg', async () => {
    await setBasis('T');
    await postRateCut(prisma, {
      scope,
      acCode: 'CASH',
      lines: [line],
      convRate: 7000,
      settleCrFine: 100,
      settleDrAmt: 12345, // typed by the operator
    });
    const h: any[] = await header();
    expect(Number(h[0].DR_AMT)).toBe(12345);
  });
});
