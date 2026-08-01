import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { postRateCut } from '../src/modules/sales/rateCut.js';
import { rojmel } from '../src/modules/reports/rojmelReport.js';
import { footprintOf, voucherTables } from './support/footprint.js';

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
      const h = (await header()) as any[];
      expect(h[0].RATE_PAR).toBe(basis);
    },
  );

  // ---------------------------------------------------------------------------------------------
  // The Rojmel (day book). Shapes taken from the real desktop rows of book 064, NOT from
  // Ac_Rojmel.cs - that file is a later version with the debit/credit assignment reversed on five of
  // the nine live types. This module books the SALE side, so it emits types 03 (fine) and 04 (amount).
  // ---------------------------------------------------------------------------------------------
  // Must read inside withTenant: outside a tenant context RLS returns zero rows SILENTLY, which reads
  // as "nothing was written" rather than as an error. This helper was wrong that way on first write and
  // reported 0 rows while the report - which uses withTenant internally - correctly saw fine of 10.
  const rojmelRows = async (): Promise<any[]> =>
    withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "LEDR_KEY","AC_CODE","LD_CODE","IT_TYPE","SIGN",
                "DR_AMT"::float dr,"CR_AMT"::float cr,"ITM_FINE"::float fine,"ITM_RATE"::float rate
           FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
        tenantId,
      ),
    ) as Promise<any[]>;

  it('writes exactly the declared set of tables, so a dropped write cannot pass unnoticed', async () => {
    // Asserted as an exact SET, not a subset. A `toContain` loop cannot see an unexpected EXTRA write,
    // and an extra write is how a duplicate ledger posting appears - a weakness found and fixed in the
    // sales-return test for exactly this reason.
    await setBasis('T');
    await postRateCut(prisma, {
      scope,
      acCode: 'CASH',
      lines: [line],
      convRate: 7000,
      settleCrFine: 100,
    });
    const tables = await voucherTables(prisma);
    expect(tables.length).toBeGreaterThan(30);
    // footprintOf reads directly and expects an owner client. This suite's client is RLS-bound, and the
    // helper's internal `.catch` turns a blocked read into a count of 0 - so calling it unscoped reports
    // an EMPTY footprint rather than an error. Hand it a tenant-scoped transaction instead.
    const touched = await withTenant(prisma, tenantId, (tx: any) =>
      footprintOf(tx, tables, tenantId, '00001'),
    );
    expect(touched).toEqual([
      'AC_DATA',
      'RATE_CUT_DATA',
      'RATE_CUT_ISU',
      // The day book. Added when the sale-side projection was implemented from the real book-064 rows.
      'ROJ_MEL_DATA',
    ]);
  });

  it('writes the sale-side Rojmel rows: type 03 fine and type 04 amount', async () => {
    await setBasis('T');
    await postRateCut(prisma, {
      scope,
      acCode: 'CASH',
      lines: [line],
      convRate: 7000,
      settleCrFine: 100,
    });
    const rows = await rojmelRows();
    expect(rows.length).toBeGreaterThan(0);
    const types = rows.map((r) => String(r.LEDR_KEY).slice(21, 23));
    expect(types).toContain('03'); // the fine row
    expect(types).toContain('04'); // the amount row
    // The purchase-side family cannot fire here: this module does not book a fine PURCHASE.
    for (const dead of ['01', '02', '13', '22', '26']) expect(types).not.toContain(dead);
    // All 66 real keys are 23 characters - no rate-cut type carries a line number.
    expect(rows.every((r) => String(r.LEDR_KEY).length === 23)).toBe(true);
  });

  it('the fine row carries metal and the amount row carries money, with the accounts flipped', async () => {
    await setBasis('T');
    await postRateCut(prisma, {
      scope,
      acCode: 'CASH',
      lines: [line],
      convRate: 7000,
      settleCrFine: 100,
    });
    const rows = await rojmelRows();
    const fine = rows.find((r) => String(r.LEDR_KEY).slice(21, 23) === '03')!;
    const amount = rows.find((r) => String(r.LEDR_KEY).slice(21, 23) === '04')!;

    // Real t03: ac=party ld=00003 G '+' fine 1.169 rate 6844.00
    expect(fine.IT_TYPE).toBe('G');
    expect(fine.SIGN).toBe('+'); // fine metal moves OUT on the sale side
    expect(Number(fine.fine)).toBeGreaterThan(0);
    expect(Number(fine.rate)).toBe(7000);
    expect(fine.AC_CODE).toBe('CASH'); // the PARTY is named on a fine row

    // Real t04: ac=00003 ld=party A - the account order is the REVERSE of the fine row, and getting
    // that backwards would misfile every amount row in the day book.
    expect(amount.IT_TYPE).toBe('A');
    expect(amount.LD_CODE).toBe('CASH'); // party moves to LD_CODE
    expect(amount.AC_CODE).not.toBe('CASH');
    expect(Number(amount.cr)).toBeGreaterThan(0); // type 04 is a CREDIT
    expect(Number(amount.dr)).toBe(0);
    expect(Number(amount.fine)).toBe(0); // money rows carry no metal
  });

  it('the fine reaches the report’s gold bucket — the first family to make it non-zero', async () => {
    await setBasis('T');
    await postRateCut(prisma, {
      scope,
      acCode: 'CASH',
      lines: [line],
      convRate: 7000,
      settleCrFine: 100,
    });
    const report = await rojmel(prisma, {
      tenantId,
      coCode: CO,
      lcCode: LC,
      coYear: YEAR,
    } as any);
    // RP_ROJMEL's gold/silver summaries filter ITM_FINE <> 0 split by SIGN. Until this family, every
    // implemented Rojmel writer left fine at 0, so those summaries could only ever report nothing.
    expect(report.totals.gold.inFine).toBeGreaterThan(0); // SIGN '+' is the inward bucket
    const fineRows = (await rojmelRows()).filter((r) => Number(r.fine) > 0 && r.SIGN === '+');
    expect(report.totals.gold.inFine).toBeCloseTo(
      fineRows.reduce((t, r) => t + Number(r.fine), 0),
      3,
    );
  });

  it('an edit replaces the Rojmel rows rather than colliding on LEDR_KEY', async () => {
    // ROJ_MEL_DATA's primary key is LEDR_KEY ALONE, so a rewrite that does not delete first fails with
    // 23505. This has bitten four times elsewhere in the project.
    await setBasis('T');
    await postRateCut(prisma, {
      scope,
      acCode: 'CASH',
      lines: [line],
      convRate: 7000,
      settleCrFine: 100,
    });
    const before = (await rojmelRows()).length;
    expect(before).toBeGreaterThan(0);
    await postRateCut(prisma, {
      scope,
      acCode: 'CASH',
      lines: [line],
      convRate: 7500,
      settleCrFine: 100,
    });
    // A second voucher, so the count grows by the same shape rather than erroring.
    const after = (await rojmelRows()).length;
    expect(after).toBe(before * 2);
  });

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
    const h = (await header()) as any[];
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
    const h = (await header()) as any[];
    // drAmt = round(100 x (700000/1000), 0) = 70,000 — the same money from a per-kg quote.
    expect(Number(h[0].DR_AMT)).toBe(70000);
  });

  it('leaves the settlement at zero when no conversion is supplied', async () => {
    await setBasis('G');
    await postRateCut(prisma, { scope, acCode: 'CASH', lines: [line] });
    const h = (await header()) as any[];
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
    const h = (await header()) as any[];
    expect(Number(h[0].DR_AMT)).toBe(12345);
  });
});
