import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { deleteRateCut, getRateCut, postRateCut } from '../src/modules/sales/rateCut.js';
import { lookup } from '../src/modules/masters/lookup.js';
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
    'RATE_CUT_REC',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'CO_SET',
    'SRNO_MAST',
    'BOOK_DATA',
    'BOOK_DETL',
    'BUL_DATA',
    // The booking draw-down test deletes a voucher, which writes a DELETE_DATA audit row. Without
    // cleaning it the footprint assertion in this same file sees an extra table and fails.
    'DELETE_DATA',
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
      /**
       * BOOK_DETL supplies the book's contra accounts. Rate-cut posting now FAILS CLOSED when a slot is
       * missing: it previously fell back to invented codes such as 'SALEGOLD' that exist in no chart of
       * accounts, so every ledger row carried a contra pointing nowhere. SR positions are the desktop's,
       * measured on real books 034/064 — SR1 sale gold, SR2 purchase gold, SR3 cash, SR4 kasar,
       * SR6 labour income, SR7 labour expense (purchase labour, legs 19/20), SR11 other.
       */
      await tx.$executeRawUnsafe(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE")
           VALUES ($1,$2,$3,'RCT',1,'SALEGOLD'),($1,$2,$3,'RCT',2,'PURCGOLD'),
                  ($1,$2,$3,'RCT',3,'CASH'),
                  ($1,$2,$3,'RCT',4,'KASAR'),($1,$2,$3,'RCT',6,'LABOUR'),
                  ($1,$2,$3,'RCT',7,'LBREXP'),($1,$2,$3,'RCT',11,'OTHER')`,
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
        `SELECT "RATE_PAR","FINE_RATE","DR_AMT","CR_AMT","CONV_RATE","CONV_PRC",
                "SL_FINE","PR_FINE","SL_ITM_AMT","PR_ITM_AMT","SL_NET_AMT","PR_NET_AMT",
                "PR_CHQ_AMT","PR_KASAR_AMT","PR_BILL_OS"
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

  it('posts a received-only rate cut with PR header totals, ledger, Rojmel and readback', async () => {
    await setBasis('G');
    const created = await postRateCut(prisma, {
      scope,
      acCode: 'CASH',
      lines: [],
      receivedLines: [
        {
          itCode: 'RCV',
          itemName: 'Received Metal',
          pcs: 1,
          grossWt: 4,
          netWt: 4,
          touch: 91,
          rate: 7100,
        },
      ],
      receivedPay: {
        chq: 1000,
        kasar: 5,
        billOs: 24839,
        bankAc: 'BANK',
      },
    } as any);

    // The voucher handles 3.640 g of fine…
    expect(created.fine).toBeCloseTo(3.64, 3);
    expect(created.netAmt).toBe(25844);

    const h = (await header()) as any[];
    expect(Number(h[0].SL_FINE)).toBe(0);
    expect(Number(h[0].SL_ITM_AMT)).toBe(0);
    /**
     * …but the line is PRICED, so its metal is settled in rupees (legs 08/09) and does not also move the party's
     * fine balance: `TotCrFine += fine` only where the item amount is 0 (TR_WH_SALE.cs:7105-7107). This test
     * previously expected PR_FINE 3.640 and a separate metal leg, which was the web's own arithmetic.
     */
    expect(Number(h[0].PR_FINE)).toBe(0);
    expect(Number(h[0].PR_ITM_AMT)).toBe(25844);
    expect(Number(h[0].PR_NET_AMT)).toBe(25844);
    expect(Number(h[0].PR_CHQ_AMT)).toBe(1000);
    expect(Number(h[0].PR_KASAR_AMT)).toBe(5);
    // Derived, not typed: net 25844 − cheque 1000 − kasar 5 (the band's "Os Amt" row, TR_WH_SALE.cs:15641).
    expect(Number(h[0].PR_BILL_OS)).toBe(24839);

    const vchNo = String(created.vchNo).padStart(5, '0');
    const acRows = (await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "AC_CODE","LD_CODE","IT_TYPE","SIGN","FINE_WT"::float8 fine,
                "DR_AMT"::float8 dr,"CR_AMT"::float8 cr
           FROM "AC_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
        tenantId,
        vchNo,
      ),
    )) as Array<Record<string, unknown>>;
    // Wh_Sales_Ledr: 08 party Cr the purchase value (G '-' DR_FINE, here 0) / 09 slot 2 Dr; 37/38 the cheque
    // paid; 51/52 the purchase kasar. No metal-only leg 29, because PR_FINE is 0.
    expect(acRows).toEqual([
      { AC_CODE: 'CASH', LD_CODE: 'PURCGOLD', IT_TYPE: 'G', SIGN: '-', fine: 0, dr: 0, cr: 25844 },
      { AC_CODE: 'PURCGOLD', LD_CODE: 'CASH', IT_TYPE: 'A', SIGN: '', fine: 0, dr: 25844, cr: 0 },
      { AC_CODE: 'CASH', LD_CODE: 'BANK', IT_TYPE: 'A', SIGN: '', fine: 0, dr: 1000, cr: 0 },
      { AC_CODE: 'BANK', LD_CODE: 'CASH', IT_TYPE: 'A', SIGN: '', fine: 0, dr: 0, cr: 1000 },
      { AC_CODE: 'CASH', LD_CODE: 'KASAR', IT_TYPE: 'A', SIGN: '', fine: 0, dr: 5, cr: 0 },
      { AC_CODE: 'KASAR', LD_CODE: 'CASH', IT_TYPE: 'A', SIGN: '', fine: 0, dr: 0, cr: 5 },
    ]);

    const rows = await rojmelRows();
    const types = rows.map((r) => String(r.LEDR_KEY).slice(21, 23));
    expect(types).toEqual(expect.arrayContaining(['01', '02', '22', '26']));
    expect(types).not.toContain('03');
    expect(types).not.toContain('04');

    const reopened = (await getRateCut(prisma, scope, created.vchNo)) as any;
    expect(reopened.lines).toHaveLength(0);
    expect(reopened.receivedLines).toHaveLength(1);
    expect(reopened.receivedTotals).toMatchObject({
      fine: 0,
      itemAmount: 25844,
      netAmount: 25844,
    });
    expect(reopened.receivedLines[0].fine).toBeCloseTo(3.64, 3);
    expect(reopened.receivedPay).toMatchObject({
      chq: 1000,
      kasar: 5,
      billOs: 24839,
      bankAc: 'BANK',
    });
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
    /**
     * `0`, not NULL.
     *
     * This asserted NULL, which was the web's behaviour rather than the desktop's. `desktopColumnDefaults`
     * records `RATE_CUT_DATA.CONV_RATE` with a default of `0` — that spec is derived by counting NULLs per
     * column over every row of the real database, so a column only appears in it when the desktop NEVER stores
     * NULL there. All 15 captured `RATE_CUT_DATA` rows hold `0`.
     *
     * The old expectation passed only because an explicit `null` from the builder was allowed to override the
     * measured default. It no longer is.
     */
    expect(Number(h[0].CONV_RATE)).toBe(0);
  });

  it('keeps FINE_RATE the header rate only: a priced line without one leaves it 0 on the header and every leg', async () => {
    /**
     * `FINE_RATE` is `nFineRate`, typed or derived by BILL_TOTAL (TR_WH_SALE.cs:12975); the desktop never copies a
     * line's rate there. The web used the first line's rate as a fallback, which put 7000 on the header and on
     * legs 01/02 of a voucher whose header rate is blank.
     */
    await setBasis('G');
    const created = await postRateCut(prisma, { scope, acCode: 'CASH', lines: [line] });
    const h = (await header()) as any[];
    expect(Number(h[0].FINE_RATE)).toBe(0);
    const legs = (await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT right("LEDR_KEY",2) AS leg,"DR_AMT"::float8 dr,"CR_AMT"::float8 cr,"FINE_RATE"::float8 rate
           FROM "AC_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
        tenantId,
        String(created.vchNo).padStart(5, '0'),
      ),
    )) as Array<Record<string, unknown>>;
    // The priced line is sold for 10 × 7000 = 70000 on legs 01/02, at no header rate.
    expect(legs).toEqual([
      { leg: '01', dr: 70000, cr: 0, rate: 0 },
      { leg: '02', dr: 0, cr: 70000, rate: 0 },
    ]);
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
  /**
   * Bullion booking draw-down.
   *
   * A booking locks a metal rate for a quantity; availability is `ITM_GWT - ADJ_WT`, which is how the
   * desktop offers bookings for selection (`TR_BUL_SALE.cs:4508`, `:7410`). A rate cut against a
   * booking must consume it and a reversal must release it:
   *   save         `TR_BUL_SALE.cs:9101`  ADJ_WT += (ITM_GWT + ADJ_WT)
   *   edit/delete  `TR_BUL_SALE.cs:8816`, `:9202`  ADJ_WT -= same
   *
   * The web wrote the link columns on RATE_CUT_ISU but never touched BUL_DATA, so a booking stayed at
   * full availability after being cut and could be drawn down repeatedly at the locked rate. Both
   * directions are asserted because a save without its matching reversal leaves the booking consumed
   * forever, which is the mirror-image defect.
   */
  it('consumes booked bullion weight on save and releases it on delete', async () => {
    const bookingWt = 25;
    const cutWt = 10;
    // resolveSettingsBehaviorTx fails closed without exactly one CO_SET row.
    await setBasis('G');
    await withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "BUL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
                                "SR_NO","OLD_SRNO","AC_CODE","IT_CODE","ITM_GWT","ADJ_WT","INOUT_TYPE")
         VALUES ($1,$2,$3,$4,'BUL','00001',1,1,'CASH','GOLD',$5,0,'I')`,
        tenantId,
        CO,
        LC,
        YEAR,
        bookingWt,
      );
    });

    const adjWt = async (): Promise<number> => {
      const rows = (await withTenant(prisma, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "ADJ_WT"::float8 AS adj FROM "BUL_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00001'`,
          tenantId,
        ),
      )) as Array<{ adj: number }>;
      return rows[0]!.adj;
    };

    expect(await adjWt()).toBe(0);

    const created = await postRateCut(prisma, {
      scope,
      acCode: 'CASH',
      lines: [
        {
          ...line,
          grossWt: cutWt,
          // The link the desktop joins on: ISU_YRCD / ISU_DBCD / ISU_NO / ISU_SRNO against
          // BUL_DATA CO_YEAR / CO_BOOK / VCH_NO / OLD_SRNO.
          isuRef: { yrcd: YEAR, dbcd: 'BUL', no: '00001', srno: 1 },
        },
      ],
    } as any);

    // Booking consumed: availability falls from 25 to 15.
    expect(await adjWt()).toBeCloseTo(cutWt, 3);

    await deleteRateCut(prisma, { scope, vchNo: created.vchNo } as any);

    // Released in full — not left consumed, and not double-released.
    expect(await adjWt()).toBeCloseTo(0, 3);
  }, 30_000);

  it('rejects a linked rate cut whose bullion booking source is missing', async () => {
    await setBasis('G');

    await expect(
      postRateCut(prisma, {
        scope,
        acCode: 'CASH',
        lines: [
          {
            ...line,
            grossWt: 3,
            isuRef: { yrcd: YEAR, dbcd: 'BUL', no: '40404', srno: 1 },
          },
        ],
      } as any),
    ).rejects.toThrow(/references missing bullion booking/i);

    const rows = (await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT
           (SELECT count(*)::int FROM "RATE_CUT_DATA" WHERE tenant_id=$1) AS headers,
           (SELECT count(*)::int FROM "RATE_CUT_ISU" WHERE tenant_id=$1) AS issue_lines`,
        tenantId,
      ),
    )) as Array<{ headers: number; issue_lines: number }>;
    expect(rows[0]).toEqual({ headers: 0, issue_lines: 0 });
  });

  it('serializes concurrent booking draw-down and rejects the over-allocation', async () => {
    await setBasis('G');
    await withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "BUL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
                                "SR_NO","OLD_SRNO","AC_CODE","IT_CODE","ITM_GWT","ADJ_WT","INOUT_TYPE")
         VALUES ($1,$2,$3,$4,'BUL','00003',1,1,'CASH','GOLD',10,0,'I')`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
    });

    const attempt = () =>
      postRateCut(prisma, {
        scope,
        acCode: 'CASH',
        lines: [
          {
            ...line,
            grossWt: 8,
            isuRef: { yrcd: YEAR, dbcd: 'BUL', no: '00003', srno: 1 },
          },
        ],
      } as any);

    const results = await Promise.allSettled([attempt(), attempt()]);
    expect(results.filter((result) => result.status === 'fulfilled')).toHaveLength(1);
    const rejected = results.find((result) => result.status === 'rejected');
    expect(rejected?.status).toBe('rejected');
    expect(String((rejected as PromiseRejectedResult).reason?.message ?? '')).toMatch(
      /only 2\.000 weight available; requested 8\.000/i,
    );

    const rows = (await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT
           (SELECT "ADJ_WT"::float8 FROM "BUL_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00003') AS adj,
           (SELECT count(*)::int FROM "RATE_CUT_DATA" WHERE tenant_id=$1) AS headers,
           (SELECT count(*)::int FROM "RATE_CUT_ISU" WHERE tenant_id=$1) AS issue_lines`,
        tenantId,
      ),
    )) as Array<{ adj: number; headers: number; issue_lines: number }>;
    expect(rows[0]).toEqual({ adj: 8, headers: 1, issue_lines: 1 });
  }, 30_000);

  it('lists only scoped available bullion bookings with the rate-cut source key', async () => {
    await withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "BUL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
                                "SR_NO","OLD_SRNO","VCH_DATE","AC_CODE","IT_CODE","IT_TYPE",
                                "ITM_GWT","ADJ_WT","ITM_RATE","MCX_RATE","IT_DESC","INOUT_TYPE")
         VALUES ($1,$2,$3,$4,'BUL','00006',1,2,'2024-04-01','CASH','GOLD','G',10,4,7100,7200,'open booking','I'),
                ($1,$2,$3,$4,'BUL','00007',1,1,'2024-04-01','CASH','GOLD','G',10,10,7100,7200,'exhausted','I'),
                ($1,$2,'02',$4,'BUL','00008',1,1,'2024-04-01','CASH','GOLD','G',10,0,7100,7200,'wrong location','I'),
                ($1,$2,$3,'2025-2026','BUL','00009',1,1,'2025-04-01','CASH','GOLD','G',10,0,7100,7200,'wrong year','I'),
                ($1,$2,$3,$4,'BUL','00010',1,1,'2024-04-01','OTHER','GOLD','G',10,0,7100,7200,'wrong party','I'),
                ($1,$2,$3,$4,'BUL','00011',1,1,'2024-04-01','CASH','SILV','S',10,0,7100,7200,'wrong metal','I')`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
    });

    const rows = await lookup(prisma, tenantId, 'bullion-bookings', '00006', CO, 20, {
      lcCode: LC,
      coYear: YEAR,
      acCode: 'CASH',
      itType: 'G',
    });

    expect(rows).toHaveLength(1);
    expect(rows[0]).toMatchObject({
      code: `${YEAR}/BUL/00006/2`,
      CO_YEAR: YEAR,
      CO_BOOK: 'BUL',
      VCH_NO: '00006',
      SR_NO: 2,
      OLD_SRNO: 2,
      LC_CODE: LC,
      AC_CODE: 'CASH',
      IT_CODE: 'GOLD',
      IT_TYPE: 'G',
      ITM_GWT: 10,
      ADJ_WT: 4,
      AVAILABLE_WT: 6,
      ITM_RATE: 7100,
      MCX_RATE: 7200,
      issueYear: YEAR,
      issueBook: 'BUL',
      issueNo: '00006',
      issueSrno: 2,
      issueLcCode: LC,
      availableWt: 6,
    });
    expect(String(rows[0]!.name)).toContain('6.000g available');
  });

  it('reopens rich issue and receive line fields without dropping desktop grid columns', async () => {
    await setBasis('G');
    await withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "BUL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
                                "SR_NO","OLD_SRNO","AC_CODE","IT_CODE","ITM_GWT","ADJ_WT","INOUT_TYPE")
         VALUES ($1,$2,$3,$4,'BUL','00004',1,1,'CASH','GOLD',50,0,'I'),
                ($1,$2,$3,$4,'BUL','00005',1,1,'CASH','GOLD',50,0,'I')`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
    });

    const created = await postRateCut(prisma, {
      scope,
      acCode: 'CASH',
      convRate: 7100,
      convPct: 91.5,
      add1: 'Line 1',
      add2: 'Line 2',
      add3: 'Line 3',
      city: 'Surat',
      mobile: '9876543210',
      bankName: 'Operator Bank',
      lines: [
        {
          itCode: 'ISS',
          itemName: 'Issue Rich Metal',
          tagNo: 'TAG-I',
          designNo: 'DES-I',
          lotNo: 'LOT-I',
          itemLot: 'ITEM-LOT-I',
          pcs: 3,
          grossWt: 12,
          othWt: 2,
          ghtPct: 10,
          lessWt: 0.125,
          touch: 90,
          westPct: 1,
          lessTouch: 0.5,
          rate: 7000,
          rateType: '1',
          lbrType: 'N',
          lbrRate: 37,
          lbrAmt: 111,
          othAmt: 22,
          otherRate: 11,
          otherFine: 0.33,
          mrp: 0,
          taxPct: 3,
          tagCost: 1234,
          tagGrossWt: 12.34,
          tagNetWt: 10.34,
          convRate: 7001,
          convPct: 90.25,
          prCode: 'BK',
          adjustWt: 0.5,
          mcxRate: 7200,
          hallmarkFine: 0.75,
          silverFine: 0.2,
          issueLcCode: LC,
          isuRef: { yrcd: YEAR, dbcd: 'BUL', no: '00004', srno: 1 },
        },
      ],
      receivedLines: [
        {
          itCode: 'RCV',
          itemName: 'Receive Rich Metal',
          tagNo: 'TAG-R',
          designNo: 'DES-R',
          lotNo: 'LOT-R',
          itemLot: 'RCVLOT',
          pcs: 2,
          grossWt: 5,
          othWt: 1,
          ghtPct: 20,
          lessWt: 0.075,
          touch: 80,
          westPct: 2,
          lessTouch: 0.25,
          rate: 6000,
          lbrType: 'G',
          lbrRate: 12,
          lbrAmt: 50,
          othAmt: 25,
          otherRate: 9,
          otherFine: 0.11,
          mrp: 0,
          taxPct: 5,
          tagCost: 567,
          tagNetWt: 4.44,
          convRate: 6001,
          convPct: 80.75,
          prCode: 'FN',
          adjustWt: 0.25,
          mcxRate: 6100,
          silverFine: 0.1,
          issueLcCode: LC,
          isuRef: { yrcd: YEAR, dbcd: 'BUL', no: '00005', srno: 1 },
        },
      ],
      receivedPay: { cash: 100 },
    } as any);

    const reopened = (await getRateCut(prisma, scope, created.vchNo)) as any;
    expect(reopened.convRate).toBe(7100);
    expect(reopened.convPct).toBe(91.5);
    expect(reopened).toMatchObject({
      add1: 'Line 1',
      add2: 'Line 2',
      add3: 'Line 3',
      city: 'Surat',
      mobile: '9876543210',
      bankName: 'Operator Bank',
    });
    expect(reopened.lines).toHaveLength(1);
    expect(reopened.lines[0]).toMatchObject({
      itCode: 'ISS',
      itemName: 'Issue Rich Metal',
      tagNo: 'TAG-I',
      designNo: 'DES-I',
      lotNo: 'LOT-I',
      itemLot: 'ITEM-LOT-I',
      pcs: 3,
      grossWt: 12,
      othWt: 2,
      netWt: 10,
      ghtWt: 1,
      touch: 90,
      westPct: 1,
      lessTouch: 0.5,
      lessWt: 0.125,
      /**
       * TR_WH_SALE grid arithmetic (TR_WH_SALE.cs:9160-9860), evaluated by hand:
       * - the line conversion decides the rate: Math.Round(7001 / 90.25 × 100, 2) = 7757.34;
       * - per 10 g: Math.Round(10.635 × (7757.34 / 10)) = 8250;
       * - net-wise labour with ghat (LBR_WITH_GHT blank = Y): Math.Round((10 + 1) × 37) = 407;
       * - other charges quoted per 10 g become fine: 22 × 10 / 11 = 20.000;
       * - net = labour + other + item amount = 407 + 22 + 8250 = 8679, with no tax back-out on the issue grid.
       * The previous expectations (7007 / 111 / 6932) were the web's own arithmetic, not the desktop's.
       */
      rate: 7757.34,
      amount: 8250,
      lbrType: 'N',
      lbrRate: 37,
      lbrAmt: 407,
      othAmt: 22,
      otherRate: 11,
      otherFine: 20,
      // TR_WH_SALE never computes grid column 43 for a new line, so `TOT_AMT` saves 0 while `NET_AMT` carries the
      // value — Next25 034/1 holds TOT_AMT 0.00 beside NET_AMT 500.00 (contract C7).
      totalAmount: 0,
      taxPct: 3,
      netAmount: 8679,
      rateType: '1',
      convRate: 7001,
      convPct: 90.25,
      tagCost: 1234,
      tagGrossWt: 12.34,
      tagNetWt: 10.34,
      prCode: 'BK',
      adjustWt: 0.5,
      mcxRate: 7200,
      hallmarkFine: 0.75,
      silverFine: 0.2,
      issueLcCode: LC,
    });
    // (10 + 1) × (90 + 1) / 100 − less weight 0.125 + hallmark fine 0.75 (cols 24/25) = 10.635.
    expect(reopened.lines[0].fine).toBeCloseTo(10.635, 3);
    expect(reopened.lines[0].isuRef).toMatchObject({
      yrcd: YEAR,
      dbcd: 'BUL',
      no: '00004',
      srno: 1,
    });

    expect(reopened.receivedLines).toHaveLength(1);
    expect(reopened.receivedLines[0]).toMatchObject({
      itCode: 'RCV',
      itemName: 'Receive Rich Metal',
      tagNo: 'N',
      designNo: 'DES-R',
      lotNo: 'LOT-R',
      itemLot: 'RCVLOT',
      pcs: 2,
      grossWt: 5,
      othWt: 1,
      netWt: 4,
      ghtWt: 0.8,
      touch: 80,
      westPct: 2,
      lessTouch: 0.25,
      lessWt: 0.075,
      /**
       * Receive grid (CommPassTotal_Pr, TR_WH_SALE.cs:6857-7040): rate Math.Round(6001 / 80.75 × 100, 2) = 7431.58;
       * Math.Round(3.924 × 7431.58) = 29162; gross-wise labour 5 × 12 = 60; other fine 25 / 9 = 2.778;
       * total 60 + 25 + 29162 = 29247; with tax 5 %, net Math.Round(29247 / 105 × 100) = 27854.
       */
      rate: 7431.58,
      amount: 29162,
      lbrType: 'G',
      lbrRate: 12,
      lbrAmt: 60,
      othAmt: 25,
      otherRate: 9,
      otherFine: 2.778,
      totalAmount: 29247,
      taxPct: 5,
      netAmount: 27854,
      rateType: 'G',
      convRate: 6001,
      convPct: 80.75,
      tagCost: 567,
      tagNetWt: 4.44,
      prCode: 'FN',
      adjustWt: 0.25,
      mcxRate: 6100,
      silverFine: 0.1,
      issueLcCode: LC,
    });
    // (4 + 0.8) × (80 + 2 − less touch 0.25) / 100 = 3.924 (col 15).
    expect(reopened.receivedLines[0].fine).toBeCloseTo(3.924, 3);
    expect(reopened.receivedLines[0].isuRef).toMatchObject({
      yrcd: YEAR,
      dbcd: 'BUL',
      no: '00005',
      srno: 1,
    });
  });

  it('persists receive-side RATE_CUT_REC rows and applies their booking draw-down', async () => {
    await setBasis('G');
    await withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "BUL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
                                "SR_NO","OLD_SRNO","AC_CODE","IT_CODE","ITM_GWT","ADJ_WT","INOUT_TYPE")
         VALUES ($1,$2,$3,$4,'BUL','00002',1,1,'CASH','GOLD',25,0,'I')`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
    });

    const adjWt = async (): Promise<number> => {
      const rows = (await withTenant(prisma, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "ADJ_WT"::float8 AS adj FROM "BUL_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00002'`,
          tenantId,
        ),
      )) as Array<{ adj: number }>;
      return rows[0]!.adj;
    };

    const created = await postRateCut(prisma, {
      scope,
      acCode: 'CASH',
      lines: [line],
      receivedLines: [
        {
          itCode: 'RCV',
          itemName: 'Received Metal',
          pcs: 2,
          grossWt: 4,
          netWt: 4,
          touch: 91,
          rate: 7100,
          adjustWt: 1.5,
          mcxRate: 7200,
          silverFine: 0.25,
          issueLcCode: LC,
          isuRef: { yrcd: YEAR, dbcd: 'BUL', no: '00002', srno: 1 },
        },
      ],
    } as any);

    const rows = (await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "ENTRY_TYPE","IT_CODE","ITM_REMARK","ITM_FINE"::float8 fine,"ADJ_WT"::float8 adj,
                "MCX_RATE"::float8 mcx,"SILVER_FINE"::float8 silver,"ISU_NO","ISU_YRCD","ISU_DBCD",
                "ISU_SRNO"::float8 isu_srno
           FROM "RATE_CUT_REC" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
        tenantId,
        String(created.vchNo).padStart(5, '0'),
      ),
    )) as Array<Record<string, unknown>>;
    expect(rows).toHaveLength(1);
    expect(rows[0]).toMatchObject({
      ENTRY_TYPE: 'P',
      IT_CODE: 'RCV',
      ITM_REMARK: 'Received Metal',
      ISU_NO: '00002',
      ISU_YRCD: YEAR,
      ISU_DBCD: 'BUL',
    });
    expect(Number(rows[0]!.fine)).toBeCloseTo(3.64, 3);
    expect(Number(rows[0]!.adj)).toBeCloseTo(1.5, 3);
    expect(Number(rows[0]!.mcx)).toBeCloseTo(7200, 2);
    expect(Number(rows[0]!.silver)).toBeCloseTo(0.25, 3);
    expect(Number(rows[0]!.isu_srno)).toBe(1);

    // Desktop updates BUL_DATA with ITM_GWT + ADJ_WT for RATE_CUT_REC as well as RATE_CUT_ISU.
    expect(await adjWt()).toBeCloseTo(5.5, 3);

    const reopened = (await getRateCut(prisma, scope, created.vchNo)) as any;
    expect(reopened.receivedLines).toHaveLength(1);
    expect(reopened.receivedLines[0]).toMatchObject({
      itCode: 'RCV',
      itemName: 'Received Metal',
      grossWt: 4,
      netWt: 4,
      adjustWt: 1.5,
      issueLcCode: LC,
    });
    expect(reopened.receivedLines[0].isuRef).toMatchObject({
      yrcd: YEAR,
      dbcd: 'BUL',
      no: '00002',
      srno: 1,
    });

    await deleteRateCut(prisma, { scope, vchNo: created.vchNo } as any);
    expect(await adjWt()).toBeCloseTo(0, 3);
    const remaining = (await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT count(*)::int AS n FROM "RATE_CUT_REC" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
        tenantId,
        String(created.vchNo).padStart(5, '0'),
      ),
    )) as Array<{ n: number }>;
    expect(remaining[0]!.n).toBe(0);
  }, 30_000);
});
