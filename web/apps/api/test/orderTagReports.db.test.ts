import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { orderLotZoom, tagEstimate } from '../src/modules/reports/orderTagReports.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * `RP_TAG_ESTMATE` and `RP_ORDER`.
 *
 * Both were entirely absent, which is why `Ctrl+F12` and `Ctrl+F2` were left unmapped. The properties pinned
 * here are the ones that distinguish these reports from a naive listing: the In/Out source switch, the
 * cross-table column sourcing, and the two-sided lot union.
 */
d('order and tag-estimate reports', () => {
  const prisma = new PrismaClient();
  const tenantId = 'order-tag-rpt';
  const CO = '01';
  const LC = '01';
  const YR = '2425';
  const scope = { tenantId, coCode: CO, lcCode: LC, coYear: YR };

  const TABLES = ['BAR_DETL', 'MAIN_STOCK', 'ITEM_MAST', 'LOT_DETL', 'BOOK_DATA'];

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

  // -------------------------------------------------------------------------------------------------
  describe('tagEstimate (RP_TAG_ESTMATE)', () => {
    const seed = async () => {
      await run(async (tx: any) => {
        await tx.$executeRawUnsafe(
          `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE","GR_CODE","IT_TYPE")
           VALUES ($1,$2,'RING','Ring','P1','GO','S'),
                  ($1,$2,'CHAIN','Chain','P2','SL','B')`,
          tenantId,
          CO,
        );
        // Two tag rows, different items, so the ITEM_MAST filters can be told apart.
        for (const [tag, it, dt, nwt] of [
          ['TAGA', 'RING', '2024-06-10', 10],
          ['TAGB', 'CHAIN', '2024-06-20', 20],
        ] as const) {
          await tx.$executeRawUnsafe(
            `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
                 "VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE","ITM_NWT","ITM_GWT","ITM_PCS","LBR_AMT",
                 "DESIGN_NO","ITM_SIZE","KR_NAME")
             VALUES ($1,$2,$3,$4,'218','00001',1,$5::date,$6,1,$7,$8,$8,1,100,'D-1','M','KRG1')`,
            tenantId,
            CO,
            LC,
            YR,
            dt,
            tag,
            it,
            nwt,
          );
        }
        // A tag with a BLANK tag number must be excluded by the desktop's `A.TAG_NO <> ''`.
        await tx.$executeRawUnsafe(
          `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
               "VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE","ITM_NWT")
           VALUES ($1,$2,$3,$4,'218','00002',1,'2024-06-15'::date,'',2,'RING',99)`,
          tenantId,
          CO,
          LC,
          YR,
        );
      });
    };

    it('lists tag rows and excludes a blank tag number', async () => {
      await seed();
      const r = await tagEstimate(prisma, scope);
      expect(r.rows.map((x) => x.tagNo)).toEqual(['TAGA', 'TAGB']);
      expect(r.totals?.nwt).toBeCloseTo(30, 3);
      // The 99g blank-tag row must not reach the total.
      expect(r.totals?.nwt).not.toBeCloseTo(129, 3);
    });

    it('filters by product, group and item type from ITEM_MAST', async () => {
      await seed();
      expect((await tagEstimate(prisma, scope, { prCode: 'P1' })).rows.map((x) => x.tagNo)).toEqual(
        ['TAGA'],
      );
      expect((await tagEstimate(prisma, scope, { grCode: 'SL' })).rows.map((x) => x.tagNo)).toEqual(
        ['TAGB'],
      );
      // IT_TYPE holds only the FIRST character of the desktop's chosen label.
      expect((await tagEstimate(prisma, scope, { itType: 'S' })).rows.map((x) => x.tagNo)).toEqual([
        'TAGA',
      ]);
      expect(
        (await tagEstimate(prisma, scope, { tagNo: 'TAGB' })).rows.map((x) => x.tagNo),
      ).toEqual(['TAGB']);
    });

    it('honours the voucher-date window on both boundaries', async () => {
      await seed();
      const within = await tagEstimate(
        prisma,
        { ...scope, fromDate: '2024-06-10', toDate: '2024-06-20' },
        {},
      );
      expect(
        within.rows.map((x) => x.tagNo),
        'both boundary dates are inclusive',
      ).toEqual(['TAGA', 'TAGB']);
      const narrow = await tagEstimate(
        prisma,
        { ...scope, fromDate: '2024-06-11', toDate: '2024-06-20' },
        {},
      );
      expect(narrow.rows.map((x) => x.tagNo)).toEqual(['TAGB']);
    });

    it('Out reads stock weights but design, size and karigar from the tag ledger', async () => {
      await seed();
      // MAIN_STOCK does not carry DESIGN_NO / ITM_SIZE / KR_NAME, so the desktop takes them from the joined
      // BAR_DETL while the weights come from stock. Different weight proves the sourcing.
      await run((tx: any) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
               "VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE","ITM_NWT","ITM_GWT","ITM_PCS","ITM_SIGN")
           VALUES ($1,$2,$3,$4,'301','00007',1,'2024-06-25'::date,'TAGA',1,'RING',7.5,7.5,1,'-')`,
          tenantId,
          CO,
          LC,
          YR,
        ),
      );
      const r = await tagEstimate(prisma, scope, { direction: 'Out' });
      expect(r.rows).toHaveLength(1);
      const row = r.rows[0]!;
      expect(row.nwt, 'weight comes from MAIN_STOCK').toBeCloseTo(7.5, 3);
      expect(row.design, 'design comes from the joined BAR_DETL').toBe('D-1');
      expect(row.size).toBe('M');
      // KR_NAME is varchar(5) — it stores a karigar CODE, not a name, despite what it is called.
      expect(row.krName).toBe('KRG1');
      expect(row.vchNo, 'voucher identity is the stock row').toBe('00007');
    });
  });

  // -------------------------------------------------------------------------------------------------
  describe('orderLotZoom (RP_ORDER)', () => {
    const seedLot = async () => {
      await run(async (tx: any) => {
        await tx.$executeRawUnsafe(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK")
           VALUES ($1,$2,$3,'401','Lot Issue','LI','MFG'),
                  ($1,$2,$3,'402','Lot Receive','LR','MFG')`,
          tenantId,
          CO,
          LC,
        );
        // '+' leg: metal issued against the lot.
        await tx.$executeRawUnsafe(
          `INSERT INTO "LOT_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
               "VCH_DATE","LOT_NO","IT_CODE","IT_PCS","IT_GWT","IT_NWT","IT_SIGN","EMP_CODE")
           VALUES ($1,$2,$3,$4,'401','00001',1,'2024-06-01'::date,'LOT9','GOLD',0,100,100,'+','E1')`,
          tenantId,
          CO,
          LC,
          YR,
        );
        // '-' leg: tags returned. Item code is TAG_IT_CODE, which differs from IT_CODE on purpose.
        await tx.$executeRawUnsafe(
          `INSERT INTO "LOT_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
               "VCH_DATE","LOT_NO","IT_CODE","TAG_IT_CODE","TAG_NO","IT_PCS","IT_GWT","IT_NWT","IT_SIGN","EMP_CODE")
           VALUES ($1,$2,$3,$4,'402','00002',2,'2024-06-05'::date,'LOT9','GOLD','RING','T77',3,92,92,'-','E1')`,
          tenantId,
          CO,
          LC,
          YR,
        );
        // A different lot must not appear.
        await tx.$executeRawUnsafe(
          `INSERT INTO "LOT_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
               "VCH_DATE","LOT_NO","IT_CODE","IT_PCS","IT_GWT","IT_NWT","IT_SIGN")
           VALUES ($1,$2,$3,$4,'401','00003',1,'2024-06-02'::date,'LOTX','GOLD',0,50,50,'+')`,
          tenantId,
          CO,
          LC,
          YR,
        );
      });
    };

    it('unions the issue and return legs into opposing column pairs', async () => {
      await seedLot();
      const r = await orderLotZoom(prisma, scope, 'LOT9');
      expect(r.rows).toHaveLength(2);
      const [issue, ret] = r.rows as any[];
      // The '+' leg fills the issue columns and zeroes the tag columns.
      expect([issue.nwt, issue.tagNwt]).toEqual([100, 0]);
      expect(issue.itCode).toBe('GOLD');
      expect(issue.bookShort).toBe('LI');
      // The '-' leg is the reverse, and its item code is TAG_IT_CODE.
      expect([ret.nwt, ret.tagNwt]).toEqual([0, 92]);
      expect(ret.itCode, 'the return leg reports TAG_IT_CODE, not IT_CODE').toBe('RING');
      expect(ret.tagNo).toBe('T77');
      // The lot balance is what the drill-down exists to answer.
      expect(r.totals?.balanceNwt).toBeCloseTo(8, 3);
    });

    it('is a drill-down: a blank lot returns nothing rather than every lot', async () => {
      await seedLot();
      expect((await orderLotZoom(prisma, scope, '')).rows).toEqual([]);
      expect((await orderLotZoom(prisma, scope, '   ')).rows).toEqual([]);
      // And a named lot never leaks another lot's rows.
      const r = await orderLotZoom(prisma, scope, 'LOT9');
      expect(r.rows.every((x: any) => x.lotNo === 'LOT9')).toBe(true);
    });

    it('orders by voucher date then line serial', async () => {
      await seedLot();
      const r = await orderLotZoom(prisma, scope, 'LOT9');
      const dates = r.rows.map((x: any) => String(x.vchDate).slice(0, 10));
      expect([...dates]).toEqual([...dates].sort());
    });
  });
});
