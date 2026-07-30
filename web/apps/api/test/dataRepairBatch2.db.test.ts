import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  confirmationFor,
  getRepair,
  listRepairs,
  previewRepair,
} from '../src/modules/utilities/dataRepair.js';
import '../src/modules/utilities/dataRepairOps.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * The three repairs added after the first six: fine backfill, opening-serial renumbering and cancelled-tag
 * duplicate removal.
 *
 * Each is checked for the property that matters most in a data-repair tool: it changes exactly the rows the
 * preview promised, leaves healthy rows untouched, and a second run is a no-op.
 */
d('data repair operations (batch 2)', () => {
  const prisma = new PrismaClient();
  const tenantId = 'repair-batch2-db';
  const CO = '01';
  const LC = '01';
  const YR = '2425';
  const scope = { tenantId, coCode: CO, lcCode: LC, coYear: YR };
  const OPERATOR = 'repair-tester';

  const TABLES = [
    'BAR_DETL',
    'BAR_IDTL',
    'BAR_CAN_DETL',
    'SL_DETL_RTN',
    'BOOK_DATA',
    'BOOK_DETL',
    'CASH_DATA',
    'BANK_RECONCILE',
    'AC_DATA',
    'AC_MAST',
    'MAIN_STOCK',
    'SL_DETL',
    'RATE_CUT_ISU',
    'LBR_ISU_DETL',
  ];

  const clean = () =>
    withTenant(prisma, tenantId, async (tx: any) => {
      for (const t of TABLES) {
        await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenantId);
      }
      // The run ledger is append-only; purging needs the explicit opt-in the trigger requires.
      await tx.$executeRawUnsafe(`SET LOCAL app.allow_repair_purge = 'on'`);
      await tx.$executeRawUnsafe(`DELETE FROM "data_repair_run" WHERE tenant_id=$1`, tenantId);
    });

  const run = <T>(fn: (tx: any) => Promise<T>): Promise<T> => withTenant(prisma, tenantId, fn);

  beforeEach(clean);
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
  });

  /** Insert a tag row. TAG_NO is varchar(15), so keys stay short. */
  const bar = (
    tag: string,
    srno: number,
    extra: Record<string, number | string> = {},
  ): Promise<unknown> =>
    run((tx) => {
      const cols = ['tenant_id', 'CO_CODE', 'LC_CODE', 'CO_YEAR', 'TAG_NO', 'VCH_SRNO'];
      const vals: unknown[] = [tenantId, CO, LC, YR, tag, srno];
      for (const [k, v] of Object.entries(extra)) {
        const at = cols.indexOf(k);
        if (at >= 0) {
          vals[at] = v; // override rather than duplicate the column
          continue;
        }
        cols.push(k);
        vals.push(v);
      }
      const ph = vals.map((_, i) => `$${i + 1}`).join(',');
      return tx.$executeRawUnsafe(
        `INSERT INTO "BAR_DETL"(${cols.map((c) => (c === 'tenant_id' ? c : `"${c}"`)).join(',')}) VALUES (${ph})`,
        ...vals,
      );
    });

  // -------------------------------------------------------------------------------------------------
  describe('stock-fine-refresh', () => {
    it('fills a missing fine weight and leaves a healthy row alone', async () => {
      // 10.000 x (91.600 + 1.5000) / 100 = 9.310
      await bar('FINE1', 1, { ITM_NWT: 10, ITM_TOUCH: 91.6, ITM_WEST_PRC: 1.5, ITM_FINE: 0 });
      // Already correct — must not be selected.
      await bar('FINE2', 1, { ITM_NWT: 10, ITM_TOUCH: 91.6, ITM_WEST_PRC: 1.5, ITM_FINE: 9.31 });
      // No touch or wastage — outside the candidate set even though fine is 0.
      await bar('FINE3', 1, { ITM_NWT: 10, ITM_TOUCH: 0, ITM_WEST_PRC: 0, ITM_FINE: 0 });

      const p = await previewRepair(prisma, 'stock-fine-refresh', scope, OPERATOR);
      const bd = p.diffs.find((x) => x.table === 'BAR_DETL');
      expect(bd?.update, 'only the one broken row is a candidate').toBe(1);

      await run((tx) => getRepair('stock-fine-refresh')!.apply(tx, scope));
      const rows: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "TAG_NO", "ITM_FINE"::float f FROM "BAR_DETL" WHERE tenant_id=$1 ORDER BY "TAG_NO"`,
          tenantId,
        ),
      );
      expect(rows.map((r) => [r.TAG_NO, r.f])).toEqual([
        ['FINE1', 9.31],
        ['FINE2', 9.31],
        ['FINE3', 0], // untouched: no touch/wastage means no basis
      ]);

      // A second run must find nothing.
      const again = await previewRepair(prisma, 'stock-fine-refresh', scope, OPERATOR);
      expect(again.diffs).toEqual([]);
    });

    it('refreshes a sales-return line from the tag even when the return already has a fine', async () => {
      // This is the desktop oddity: the SL_DETL_RTN update sits outside the `if`, matching on tag and serial
      // ALONE with no condition on the return's own fine weight.
      await bar('RTN1', 1, { ITM_NWT: 10, ITM_TOUCH: 90, ITM_WEST_PRC: 0, ITM_FINE: 0 });
      await run((tx) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "SL_DETL_RTN"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","TAG_NO","VCH_SRNO","ITM_FINE")
           VALUES ($1,$2,$3,$4,'201','00001',1,'RTN1',1,5.5)`,
          tenantId,
          CO,
          LC,
          YR,
        ),
      );
      const p = await previewRepair(prisma, 'stock-fine-refresh', scope, OPERATOR);
      expect(p.diffs.find((x) => x.table === 'SL_DETL_RTN')?.update).toBe(1);

      await run((tx) => getRepair('stock-fine-refresh')!.apply(tx, scope));
      const r: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "ITM_FINE"::float f FROM "SL_DETL_RTN" WHERE tenant_id=$1`,
          tenantId,
        ),
      );
      // Overwritten from the tag's recomputation (10 x 90 / 100 = 9.000), not left at 5.5.
      expect(r[0].f).toBeCloseTo(9, 3);
    });
  });

  // -------------------------------------------------------------------------------------------------
  describe('bar-idtl-serial', () => {
    it('renumbers each opening voucher 1..n and realigns BAR_IDTL', async () => {
      // Voucher 00001 has a gap (serials 1,5,9); voucher 00002 starts at 3.
      await bar('T1', 1, { CO_BOOK: '000', VCH_NO: '00001', SR_NO: 1 });
      await bar('T2', 2, { CO_BOOK: '000', VCH_NO: '00001', SR_NO: 5 });
      await bar('T3', 3, { CO_BOOK: '000', VCH_NO: '00001', SR_NO: 9 });
      await bar('T4', 4, { CO_BOOK: '000', VCH_NO: '00002', SR_NO: 3 });
      // A non-opening row must be untouched: the desktop filters CO_BOOK = '000'.
      await bar('T9', 9, { CO_BOOK: '218', VCH_NO: '00001', SR_NO: 77 });
      for (const [tag, srno] of [
        ['T1', 1],
        ['T2', 2],
        ['T3', 3],
      ] as const) {
        await run((tx) =>
          tx.$executeRawUnsafe(
            `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","TAG_NO","VCH_SRNO","SR_NO")
             VALUES ($1,$2,$3,$4,$5,$6,99)`,
            tenantId,
            CO,
            LC,
            YR,
            tag,
            srno,
          ),
        );
      }

      const p = await previewRepair(prisma, 'bar-idtl-serial', scope, OPERATOR);
      // All four opening rows change: T2/T3/T4 need a new SR_NO, and T1 needs its null OLD_SRNO set.
      expect(p.diffs.find((x) => x.table === 'BAR_DETL')?.update).toBe(4);
      expect(p.diffs.find((x) => x.table === 'BAR_IDTL')?.update).toBe(3);

      await run((tx) => getRepair('bar-idtl-serial')!.apply(tx, scope));
      const rows: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "TAG_NO", "SR_NO"::int s, "OLD_SRNO"::int o, "CO_BOOK" b
             FROM "BAR_DETL" WHERE tenant_id=$1 ORDER BY "TAG_NO"`,
          tenantId,
        ),
      );
      // T1's SR_NO was already 1, but OLD_SRNO was null and the desktop writes BOTH for every row, so it
      // is still repaired. A diff on SR_NO alone would have left OLD_SRNO stale.
      expect(rows.map((r) => [r.TAG_NO, r.s, r.o])).toEqual([
        ['T1', 1, 1],
        ['T2', 2, 2],
        ['T3', 3, 3],
        ['T4', 1, 1], // its own voucher restarts at 1
        ['T9', 77, null], // non-opening row untouched, OLD_SRNO never set
      ]);
      const idtl: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "TAG_NO", "SR_NO"::int s FROM "BAR_IDTL" WHERE tenant_id=$1 ORDER BY "TAG_NO"`,
          tenantId,
        ),
      );
      expect(idtl.map((r) => [r.TAG_NO, r.s])).toEqual([
        ['T1', 1],
        ['T2', 2],
        ['T3', 3],
      ]);

      const again = await previewRepair(prisma, 'bar-idtl-serial', scope, OPERATOR);
      expect(again.diffs).toEqual([]);
    });
  });

  // -------------------------------------------------------------------------------------------------
  describe('duplicate-cancelled-tag', () => {
    it('deletes only the duplicate rows matching the cancelled weight', async () => {
      // DUP1 is duplicated at gross weight 5.000 and cancelled at 5.000 -> both rows go.
      await bar('DUP1', 1, { ITM_GWT: 5 });
      await bar('DUP1', 1, { ITM_GWT: 5 });
      // DUP2 is duplicated at TWO weights but only 7.000 was cancelled -> 8.000 must survive.
      await bar('DUP2', 1, { ITM_GWT: 7 });
      await bar('DUP2', 1, { ITM_GWT: 8 });
      // DUP3 is duplicated with NO cancellation row -> untouched, the desktop requires a cancel row.
      await bar('DUP3', 1, { ITM_GWT: 9 });
      await bar('DUP3', 1, { ITM_GWT: 9 });
      // NOTDUP appears once, so it is not a duplicate group even though it has a cancellation.
      await bar('NOTDUP', 1, { ITM_GWT: 4 });

      for (const [tag, gwt] of [
        ['DUP1', 5],
        ['DUP2', 7],
        ['NOTDUP', 4],
      ] as const) {
        await run((tx) =>
          tx.$executeRawUnsafe(
            `INSERT INTO "BAR_CAN_DETL"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","ITM_GWT")
             VALUES ($1,$2,$3,$4,1,$5)`,
            tenantId,
            CO,
            LC,
            tag,
            gwt,
          ),
        );
      }

      const p = await previewRepair(prisma, 'duplicate-cancelled-tag', scope, OPERATOR);
      // DUP1 x2 rows at weight 5, DUP2 x1 row at weight 7 = 3 tag rows.
      expect(p.diffs.find((x) => x.table === 'BAR_DETL')?.delete).toBe(3);
      expect(p.diffs.find((x) => x.table === 'BAR_CAN_DETL')?.delete).toBe(2);

      await run((tx) => getRepair('duplicate-cancelled-tag')!.apply(tx, scope));
      const rows: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "TAG_NO", "ITM_GWT"::float g FROM "BAR_DETL" WHERE tenant_id=$1
            ORDER BY "TAG_NO", "ITM_GWT"`,
          tenantId,
        ),
      );
      expect(rows.map((r) => [r.TAG_NO, r.g])).toEqual([
        ['DUP2', 8], // the weight that was never cancelled survives
        ['DUP3', 9], // no cancellation row, so untouched
        ['DUP3', 9],
        ['NOTDUP', 4], // not a duplicate group
      ]);
      const can: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "TAG_NO" FROM "BAR_CAN_DETL" WHERE tenant_id=$1 ORDER BY "TAG_NO"`,
          tenantId,
        ),
      );
      expect(can.map((r) => r.TAG_NO)).toEqual(['NOTDUP']);
    });

    it('is scoped by company and location only, without the year', async () => {
      // The desktop query for this repair has no CO_YEAR predicate, unlike its neighbours. A row in a
      // different year must still be a candidate.
      await bar('YR1', 1, { ITM_GWT: 5, CO_YEAR: '2324' });
      await bar('YR1', 1, { ITM_GWT: 5, CO_YEAR: '2324' });
      await run((tx) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "BAR_CAN_DETL"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","ITM_GWT")
           VALUES ($1,$2,$3,'YR1',1,5)`,
          tenantId,
          CO,
          LC,
        ),
      );
      // Scope carries the CURRENT year, yet the prior-year rows must still be found.
      const p = await previewRepair(prisma, 'duplicate-cancelled-tag', scope, OPERATOR);
      expect(p.diffs.find((x) => x.table === 'BAR_DETL')?.delete).toBe(2);
    });
  });

  // -------------------------------------------------------------------------------------------------
  it('demands a typed confirmation for every operation that deletes rows', async () => {
    // A repair that removes data must never be one click away. This is asserted over the WHOLE registry
    // rather than the new operations only, so a future op cannot be added as low risk while deleting rows.
    const deleting = listRepairs().filter((op) =>
      /delete|remove|purge|convert/i.test(`${op.id} ${op.title} ${op.description}`),
    );
    expect(
      deleting.length,
      'the registry must contain destructive operations to check',
    ).toBeGreaterThan(0);
    for (const op of deleting) {
      expect(op.risk, `${op.id} deletes rows so it must be high risk`).toBe('high');
      expect(
        confirmationFor(op as never, scope),
        `${op.id} must require a typed confirmation`,
      ).toBe(`${op.id} ${CO}`);
    }
  });

  // -------------------------------------------------------------------------------------------------
  describe('ledger-normalise', () => {
    it('normalises book flags, defaults the cash clearing date and rebuilds reconciliation', async () => {
      await run(async (tx: any) => {
        // Books with a blank/NULL data type; one already set must be left alone.
        await tx.$executeRawUnsafe(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","DATA_TYPE")
           VALUES ($1,$2,$3,'901','Blank',''),($1,$2,$3,'902','Null',NULL),($1,$2,$3,'903','Set','X')`,
          tenantId,
          CO,
          LC,
        );
        // Cash rows: one uncleared, one already cleared to a DIFFERENT date which must not move.
        await tx.$executeRawUnsafe(
          `INSERT INTO "CASH_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
               "VCH_DATE","CLR_DATE")
           VALUES ($1,$2,$3,$4,'CSH','00001',1,'2024-06-10'::date,NULL),
                  ($1,$2,$3,$4,'CSH','00002',1,'2024-06-11'::date,'2024-07-01'::date)`,
          tenantId,
          CO,
          LC,
          YR,
        );
        // A bank account (group 02) and a non-bank one; only the bank ledger row is indexed.
        await tx.$executeRawUnsafe(
          `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","AC_CODE","AC_NAME","AC_GR")
           VALUES ($1,$2,'BANK1','Bank','02'),($1,$2,'SALES','Sales','40')`,
          tenantId,
          CO,
        );
        for (const [ac, key] of [
          ['BANK1', 'K1'],
          ['SALES', 'K2'],
        ] as const) {
          await tx.$executeRawUnsafe(
            `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
                 "VCH_DATE","AC_CODE","LEDR_KEY","CLR_DATE","DR_AMT","CR_AMT")
             VALUES ($1,$2,$3,$4,'CSH','00001','2024-06-10'::date,$5,$6,'2024-06-10'::date,100,0)`,
            tenantId,
            CO,
            LC,
            YR,
            ac,
            key,
          );
        }
        // A stale reconciliation row that the rebuild must remove.
        await tx.$executeRawUnsafe(
          `INSERT INTO "BANK_RECONCILE"(tenant_id,"CO_CODE","LC_CODE","LEDR_KEY","CLR_DATE")
           VALUES ($1,$2,$3,'STALE','2020-01-01'::date)`,
          tenantId,
          CO,
          LC,
        );
      });

      const p = await previewRepair(prisma, 'ledger-normalise', scope, OPERATOR);
      expect(p.diffs.find((x) => x.table === 'BOOK_DATA')?.update).toBe(2);
      expect(p.diffs.find((x) => x.table === 'CASH_DATA')?.update).toBe(1);
      expect(p.diffs.find((x) => x.table === 'BANK_RECONCILE' && x.delete)?.delete).toBe(1);
      expect(p.diffs.find((x) => x.table === 'BANK_RECONCILE' && x.insert)?.insert).toBe(1);

      await run((tx) => getRepair('ledger-normalise')!.apply(tx, scope));

      const books: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "CO_BOOK", "DATA_TYPE" FROM "BOOK_DATA" WHERE tenant_id=$1 ORDER BY "CO_BOOK"`,
          tenantId,
        ),
      );
      expect(books.map((b) => [b.CO_BOOK, b.DATA_TYPE])).toEqual([
        ['901', 'A'],
        ['902', 'A'],
        ['903', 'X'], // already set, untouched
      ]);

      const cash: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "VCH_NO", to_char("CLR_DATE",'YYYY-MM-DD') d FROM "CASH_DATA"
            WHERE tenant_id=$1 ORDER BY "VCH_NO"`,
          tenantId,
        ),
      );
      expect(cash.map((c) => [c.VCH_NO, c.d])).toEqual([
        ['00001', '2024-06-10'], // defaulted to its voucher date
        ['00002', '2024-07-01'], // already cleared, not moved
      ]);

      const rec: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "LEDR_KEY" FROM "BANK_RECONCILE" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
          tenantId,
        ),
      );
      // Only the bank-group ledger row is indexed, and the stale row is gone.
      expect(rec.map((r) => r.LEDR_KEY)).toEqual(['K1']);

      // Idempotent: a second preview finds only the reconciliation replacement, and re-running is stable.
      await run((tx) => getRepair('ledger-normalise')!.apply(tx, scope));
      const rec2: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "LEDR_KEY" FROM "BANK_RECONCILE" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
          tenantId,
        ),
      );
      expect(
        rec2.map((r) => r.LEDR_KEY),
        'rebuild must not duplicate',
      ).toEqual(['K1']);
    });

    it('scopes the reconciliation delete, unlike the desktop', async () => {
      // The desktop's DELETE FROM BANK_RECONCILE has NO scope and would wipe every company's rows. On a
      // shared server that is cross-company data loss, so the web scopes it.
      await run((tx: any) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "BANK_RECONCILE"(tenant_id,"CO_CODE","LC_CODE","LEDR_KEY","CLR_DATE")
           VALUES ($1,'99','01','OTHERCO','2020-01-01'::date)`,
          tenantId,
        ),
      );
      await run((tx) => getRepair('ledger-normalise')!.apply(tx, scope));
      const other: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "LEDR_KEY" FROM "BANK_RECONCILE" WHERE tenant_id=$1 AND "CO_CODE"='99'`,
          tenantId,
        ),
      );
      expect(
        other.map((r) => r.LEDR_KEY),
        "another company's rows must survive",
      ).toEqual(['OTHERCO']);
    });
  });

  // -------------------------------------------------------------------------------------------------
  describe('tag-serial-backfill', () => {
    /** Insert a MAIN_STOCK row. */
    const stock = (
      tag: string,
      srno: number,
      sign: string,
      gwt: number,
      book: string,
    ): Promise<unknown> =>
      run((tx: any) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
               "VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE","ITM_GWT","ITM_NWT","ITM_PCS","ITM_SIGN","BOOK_NAME")
           VALUES ($1,$2,$3,$4,'301','00001',1,'2024-06-10'::date,$5,$6,'GOLD',$7,$7,1,$8,$9)`,
          tenantId,
          CO,
          LC,
          YR,
          tag,
          srno,
          gwt,
          sign,
          book,
        ),
      );

    it('restores the serial from the tag ledger by tag AND gross weight', async () => {
      // The tag ledger holds the true instance number.
      await bar('SER1', 7, { ITM_GWT: 5 });
      // A sold stock row that lost it (VCH_SRNO = 0).
      await stock('SER1', 0, '-', 5, 'SALE');
      // An INWARD row with a lost serial must NOT be touched: the candidate set is ITM_SIGN = '-'.
      await stock('SER1', 0, '+', 5, 'TAG OPBL');
      // A tag reused at a DIFFERENT weight keeps its own serial rather than borrowing this one.
      await bar('SER2', 9, { ITM_GWT: 8 });
      await stock('SER2', 0, '-', 8, 'SALE');

      const p = await previewRepair(prisma, 'tag-serial-backfill', scope, OPERATOR);
      expect(p.diffs.find((x) => x.table === 'MAIN_STOCK')?.update).toBe(2);

      await run((tx) => getRepair('tag-serial-backfill')!.apply(tx, scope));
      const rows: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "TAG_NO", "ITM_SIGN", "VCH_SRNO"::int s FROM "MAIN_STOCK"
            WHERE tenant_id=$1 ORDER BY "TAG_NO", "ITM_SIGN"`,
          tenantId,
        ),
      );
      expect(rows.map((r) => [r.TAG_NO, r.ITM_SIGN, r.s])).toEqual([
        ['SER1', '+', 0], // inward, untouched
        ['SER1', '-', 7],
        ['SER2', '-', 9],
      ]);

      const again = await previewRepair(prisma, 'tag-serial-backfill', scope, OPERATOR);
      expect(again.diffs, 'a second run must be a no-op').toEqual([]);
    });

    it('propagates the serial to the sale, cancel, rate-cut and labour rows', async () => {
      await bar('PROP', 4, { ITM_GWT: 6 });
      await stock('PROP', 0, '-', 6, 'SALE');
      // One row in each of the four sibling tables, matched on tag + gross weight + book name.
      for (const t of ['SL_DETL', 'BAR_CAN_DETL', 'RATE_CUT_ISU', 'LBR_ISU_DETL'] as const) {
        await run((tx: any) =>
          tx.$executeRawUnsafe(
            `INSERT INTO "${t}"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
                 "TAG_NO","VCH_SRNO","ITM_GWT","BOOK_NAME")
             VALUES ($1,$2,$3,$4,'301','00001',1,'PROP',0,6,'SALE')`,
            tenantId,
            CO,
            LC,
            YR,
          ),
        );
      }
      await run((tx) => getRepair('tag-serial-backfill')!.apply(tx, scope));
      for (const t of ['SL_DETL', 'BAR_CAN_DETL', 'RATE_CUT_ISU', 'LBR_ISU_DETL'] as const) {
        const r: any[] = await run((tx) =>
          tx.$queryRawUnsafe(
            `SELECT "VCH_SRNO"::int s FROM "${t}" WHERE tenant_id=$1 AND "TAG_NO"='PROP'`,
            tenantId,
          ),
        );
        expect(r[0]?.s, `${t} must receive the restored serial`).toBe(4);
      }
    });

    it('falls back to a tag-only match that repairs ONLY the stock row', async () => {
      // The ledger weight (5) differs from the stock weight (99), so the exact match misses and the desktop's
      // fallback applies: MAIN_STOCK is repaired, the sibling tables deliberately are NOT.
      await bar('FB1', 3, { ITM_GWT: 5 });
      await stock('FB1', 0, '-', 99, 'SALE');
      await run((tx: any) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "SL_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
               "TAG_NO","VCH_SRNO","ITM_GWT","BOOK_NAME")
           VALUES ($1,$2,$3,$4,'301','00001',1,'FB1',0,99,'SALE')`,
          tenantId,
          CO,
          LC,
          YR,
        ),
      );
      await run((tx) => getRepair('tag-serial-backfill')!.apply(tx, scope));
      const st: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "VCH_SRNO"::int s FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO"='FB1'`,
          tenantId,
        ),
      );
      expect(st[0]?.s, 'stock row repaired by the tag-only fallback').toBe(3);
      const sl: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "VCH_SRNO"::int s FROM "SL_DETL" WHERE tenant_id=$1 AND "TAG_NO"='FB1'`,
          tenantId,
        ),
      );
      expect(sl[0]?.s, 'the fallback must NOT touch the sale row').toBe(0);
    });

    it('deletes only TAG CANCEL rows when the backfill collides', async () => {
      await bar('DUPC', 2, { ITM_GWT: 5 });
      // Two stock rows will end up sharing (tag, serial 2): one is a cancellation, one a real sale.
      await stock('DUPC', 0, '-', 5, 'SALE');
      await stock('DUPC', 2, '-', 5, 'TAG CANCEL');
      await run((tx: any) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "BAR_CAN_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","TAG_NO","VCH_SRNO",
               "ITM_GWT","BOOK_NAME")
           VALUES ($1,$2,$3,$4,'DUPC',2,5,'TAG CANCEL')`,
          tenantId,
          CO,
          LC,
          YR,
        ),
      );
      await run((tx) => getRepair('tag-serial-backfill')!.apply(tx, scope));
      const rows: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT "BOOK_NAME" FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO"='DUPC'
            ORDER BY "BOOK_NAME"`,
          tenantId,
        ),
      );
      // The cancellation row is removed; the real sale survives.
      expect(rows.map((r) => r.BOOK_NAME)).toEqual(['SALE']);
      const can: any[] = await run((tx) =>
        tx.$queryRawUnsafe(
          `SELECT count(*)::int n FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "TAG_NO"='DUPC'`,
          tenantId,
        ),
      );
      expect(can[0].n).toBe(0);
    });
  });
});
