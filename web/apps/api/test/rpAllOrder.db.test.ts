import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-14 Order Report (RP_ALL) through the real Fastify routes under forced RLS.
 *
 * The web route and adapter do not exist yet, so the route tests are red with 404.
 * The database assertions still seed the frozen WP-14 fixture and prove:
 *   - the pending set is derived from the seeded rows (order-report.formula.pending-set);
 *   - running the report changes zero rows (order-report.lifecycle.writes-nothing);
 *   - cross-scope sentinels never leak (order-report.scope.sentinels).
 */

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'rpall-order-db';
const OTHER_TENANT = 'rpall-order-other';
const PASSWORD = 'RpAll-Order!2026';
const SECRET = 'rpall-order-test-signing-secret-over-thirty-two-characters';
const YEAR = '2025-2026';
const FROM = '2026-01-01';
const TO = '2026-01-31';

interface Line {
  sr: number;
  itCode: string;
  designNo: string;
  tagNo: string;
  pcs: number;
  nwt: number;
  designIsu: string;
}
interface Order {
  co?: string;
  lc?: string;
  year?: string;
  book: string;
  vch: string;
  date: string;
  acCode: string;
  acName: string;
  totAmt: number;
  advAmt: number;
  cashAmt: number;
  lines: Line[];
}
interface Adjustment {
  co?: string;
  lc?: string;
  year?: string;
  book: string;
  vch: string;
  sr: number;
  date: string;
  sign: string;
  amt: number;
  ordLc: string;
  ordYrcd: string;
  ordDbcd: string;
  ordNo: string;
  ordAcCode: string;
}
interface Bill {
  co?: string;
  lc?: string;
  year?: string;
  book: string;
  vch: string;
  date: string;
  acCode: string;
  acName: string;
  totAmt: number;
  advAmt: number;
}

const ORDER_O1: Order = {
  book: 'B1',
  vch: 'O1',
  date: '2026-01-05',
  acCode: 'P1',
  acName: 'ALPHA JEWELS',
  totAmt: 20000,
  advAmt: 5000,
  cashAmt: 5000,
  lines: [
    { sr: 1, itCode: 'I1', designNo: 'D1', tagNo: 'T1', pcs: 1, nwt: 10.5, designIsu: 'N' },
    { sr: 2, itCode: 'I2', designNo: 'D2', tagNo: 'T2', pcs: 2, nwt: 5.25, designIsu: 'N' },
  ],
};
const ORDER_O2: Order = {
  book: 'B2',
  vch: 'O2',
  date: '2026-01-10',
  acCode: 'P2',
  acName: 'BETA TRADERS',
  totAmt: 9000,
  advAmt: 0,
  cashAmt: 0,
  lines: [{ sr: 1, itCode: 'I1', designNo: 'D1', tagNo: 'T3', pcs: 3, nwt: 7.125, designIsu: 'N' }],
};
const ORDER_O3: Order = {
  book: 'B1',
  vch: 'O3',
  date: '2026-01-15',
  acCode: 'P1',
  acName: 'ALPHA JEWELS',
  totAmt: 9000,
  advAmt: 3000,
  cashAmt: 0,
  lines: [{ sr: 1, itCode: 'I2', designNo: 'D3', tagNo: 'T4', pcs: 1, nwt: 4.0, designIsu: 'N' }],
};
const ORDER_O4: Order = {
  book: 'B1',
  vch: 'O4',
  date: '2026-01-12',
  acCode: '',
  acName: 'WALK IN CUSTOMER',
  totAmt: 0,
  advAmt: 0,
  cashAmt: 0,
  lines: [{ sr: 1, itCode: 'I1', designNo: 'D4', tagNo: 'T5', pcs: 1, nwt: 2.0, designIsu: 'N' }],
};
const ORDER_O5: Order = {
  year: YEAR,
  book: 'B1',
  vch: 'O5',
  date: '2025-12-20',
  acCode: 'P1',
  acName: 'ALPHA JEWELS',
  totAmt: 0,
  advAmt: 0,
  cashAmt: 0,
  lines: [{ sr: 1, itCode: 'I1', designNo: 'D5', tagNo: 'T6', pcs: 2, nwt: 6.0, designIsu: 'N' }],
};
const ORDER_O6: Order = {
  lc: '00',
  book: 'B1',
  vch: 'O6',
  date: '2026-01-08',
  acCode: 'P1',
  acName: 'ALPHA JEWELS',
  totAmt: 0,
  advAmt: 0,
  cashAmt: 0,
  lines: [{ sr: 1, itCode: 'I1', designNo: 'D6', tagNo: 'T7', pcs: 1, nwt: 1.0, designIsu: 'N' }],
};
const ORDER_O7: Order = {
  co: 'C2',
  book: 'B1',
  vch: 'O1',
  date: '2026-01-05',
  acCode: 'P1',
  acName: 'ALPHA JEWELS',
  totAmt: 0,
  advAmt: 0,
  cashAmt: 0,
  lines: [{ sr: 1, itCode: 'I1', designNo: 'D7', tagNo: 'T8', pcs: 1, nwt: 1.0, designIsu: 'N' }],
};
const ORDER_O8: Order = {
  book: 'B1',
  vch: 'O8',
  date: '2026-01-20',
  acCode: 'P2',
  acName: 'BETA TRADERS',
  totAmt: 0,
  advAmt: 0,
  cashAmt: 0,
  lines: [{ sr: 1, itCode: 'I2', designNo: 'D8', tagNo: 'T9', pcs: 1, nwt: 3.0, designIsu: 'Y' }],
};
const ORDERS: Order[] = [
  ORDER_O1,
  ORDER_O2,
  ORDER_O3,
  ORDER_O4,
  ORDER_O5,
  ORDER_O6,
  ORDER_O7,
  ORDER_O8,
];

// An SL_ORD_ADJ row's own keys are the voucher that wrote it: the order for its `+` advance row, the sale
// bill for a `-` adjustment; ORD_* always point at the order (Ac_Tax.cs:71-73, cases.md "Test data").
const adj = (
  own: [book: string, vch: string, sr: number],
  date: string,
  sign: string,
  amt: number,
  order: Order,
  extra: Partial<Adjustment> = {},
): Adjustment => ({
  book: own[0],
  vch: own[1],
  sr: own[2],
  date,
  sign,
  amt,
  ordLc: order.lc ?? '01',
  ordYrcd: order.year ?? YEAR,
  ordDbcd: order.book,
  ordNo: order.vch,
  ordAcCode: order.acCode,
  ...extra,
});
const ADJUSTMENTS: Adjustment[] = [
  adj(['B1', 'O1', 1], '2026-01-05', '+', 5000, ORDER_O1),
  adj(['SB', 'S1', 1], '2026-01-18', '-', 1500, ORDER_O1),
  adj(['SB', 'S1', 2], '2026-01-18', '-', 500, ORDER_O1),
  adj(['B1', 'O3', 1], '2026-01-15', '+', 3000, ORDER_O3),
  adj(['SB', 'S2', 1], '2026-01-22', '-', 1500, ORDER_O3),
  adj(['SB', 'S2', 2], '2026-01-22', '-', 1500, ORDER_O3),
  adj(['B1', 'O5', 1], '2025-12-20', '+', 1000, ORDER_O5),
  adj(['SB', 'S0', 1], '2025-12-20', '-', 1000, ORDER_O5),
];

const BILLS: Bill[] = [
  {
    book: 'SB',
    vch: 'S1',
    date: '2026-01-18',
    acCode: 'P1',
    acName: 'ALPHA JEWELS',
    totAmt: 12000,
    advAmt: 2000,
  },
  {
    book: 'SB',
    vch: 'S2',
    date: '2026-01-22',
    acCode: 'P1',
    acName: 'ALPHA JEWELS',
    totAmt: 9000,
    advAmt: 3000,
  },
  // A bill with no adjustment row: BillWiseOrderAdjust's SL_DATA → SL_ORD_ADJ link is an Equal join.
  {
    book: 'SB',
    vch: 'S3',
    date: '2026-01-25',
    acCode: 'P2',
    acName: 'BETA TRADERS',
    totAmt: 5000,
    advAmt: 0,
  },
];

(enabled ? describe : describe.skip)(
  'RP_ALL Order Report over HTTP under forced RLS (WP-14)',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    const cookies: Record<string, string> = {};
    const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
    const query = (sql: string, ...params: unknown[]) => owner.$queryRawUnsafe(sql, ...params);
    const wipe = async (tenant: string) => {
      const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
        `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
      );
      for (const row of rows)
        await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenant);
    };

    const insertOrder = async (tenant: string, o: Order) => {
      const co = o.co ?? '01';
      const lc = o.lc ?? '01';
      const year = o.year ?? YEAR;
      await exec(
        `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME",
         "TOT_AMT","ADV_AMT","CASH_AMT","CARD_AMT","CHQ_AMT","OLD_GL_AMT","OLD_SL_AMT")
         VALUES($1,$2,$3,$4,$5,$6,$7::date,$8,$9,$10,$11,$12,0,0,0,0)`,
        tenant,
        co,
        lc,
        year,
        o.book,
        o.vch,
        o.date,
        o.acCode,
        o.acName,
        o.totAmt,
        o.advAmt,
        o.cashAmt,
      );
      for (const l of o.lines) {
        await exec(
          `INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
           "IT_CODE","DESIGN_NO","TAG_NO","ITM_PCS","ITM_NWT","DESIGN_ISU")
           VALUES($1,$2,$3,$4,$5,$6,$7,$8::date,$9,$10,$11,$12,$13,$14)`,
          tenant,
          co,
          lc,
          year,
          o.book,
          o.vch,
          l.sr,
          o.date,
          l.itCode,
          l.designNo,
          l.tagNo,
          l.pcs,
          l.nwt,
          l.designIsu,
        );
      }
    };

    const insertAdjustment = async (tenant: string, a: Adjustment) => {
      const co = a.co ?? '01';
      const lc = a.lc ?? '01';
      const year = a.year ?? YEAR;
      await exec(
        `INSERT INTO "SL_ORD_ADJ"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "ORD_SIGN","ORD_AMT","ORD_LC","ORD_YRCD","ORD_DBCD","ORD_NO","ORD_AC_CODE")
         VALUES($1,$2,$3,$4,$5,$6,$7,$8::date,$9,$10,$11,$12,$13,$14,$15)`,
        tenant,
        co,
        lc,
        year,
        a.book,
        a.vch,
        a.sr,
        a.date,
        a.sign,
        a.amt,
        a.ordLc,
        a.ordYrcd,
        a.ordDbcd,
        a.ordNo,
        a.ordAcCode,
      );
    };

    const insertBill = async (tenant: string, b: Bill) => {
      const co = b.co ?? '01';
      const lc = b.lc ?? '01';
      const year = b.year ?? YEAR;
      await exec(
        `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME","TOT_AMT","ADV_AMT")
         VALUES($1,$2,$3,$4,$5,$6,$7::date,$8,$9,$10,$11)`,
        tenant,
        co,
        lc,
        year,
        b.book,
        b.vch,
        b.date,
        b.acCode,
        b.acName,
        b.totAmt,
        b.advAmt,
      );
    };

    const login = async (name: string, lcCode = '01') => {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': TENANT },
        payload: { coCode: '01', lcCode, coYear: YEAR, loginName: name, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const values = response.headers['set-cookie'];
      return (Array.isArray(values) ? values : [values ?? ''])
        .map((value) => value.split(';', 1)[0])
        .join('; ');
    };

    const get = (user: string, url: string) =>
      app.inject({
        method: 'GET',
        url,
        headers: { cookie: cookies[user]!, 'x-tenant-id': TENANT },
      });

    const report = async (mode: string, query = '', user = 'admin01') => {
      const response = await get(
        user,
        `/reports/order-report?fromDate=${FROM}&toDate=${TO}&mode=${mode}${query ? `&${query}` : ''}`,
      );
      expect(response.statusCode, response.body).toBe(200);
      return response.json();
    };

    const snapshot = async () => {
      const counts = {
        slOrdData: Number(
          (
            (await query(
              `SELECT count(*)::int n FROM "SL_ORD_DATA" WHERE tenant_id=$1`,
              TENANT,
            )) as any[]
          )[0].n,
        ),
        slOrdDetl: Number(
          (
            (await query(
              `SELECT count(*)::int n FROM "SL_ORD_DETL" WHERE tenant_id=$1`,
              TENANT,
            )) as any[]
          )[0].n,
        ),
        slOrdAdj: Number(
          (
            (await query(
              `SELECT count(*)::int n FROM "SL_ORD_ADJ" WHERE tenant_id=$1`,
              TENANT,
            )) as any[]
          )[0].n,
        ),
        slData: Number(
          (
            (await query(
              `SELECT count(*)::int n FROM "SL_DATA" WHERE tenant_id=$1`,
              TENANT,
            )) as any[]
          )[0].n,
        ),
      };
      const flags: Array<{ vch: string; sr: number; designIsu: string }> = (await query(
        `SELECT "VCH_NO" vch, "SR_NO" sr, "DESIGN_ISU" "designIsu" FROM "SL_ORD_DETL" WHERE tenant_id=$1 ORDER BY "VCH_NO", "SR_NO"`,
        TENANT,
      )) as any[];
      return { counts, flags };
    };

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe(TENANT);
      await wipe(OTHER_TENANT);
      await seedCompany(runtime, TENANT, '01', { coName: 'Order Report Jewellers', lcCode: '01' });
      await seedCompany(runtime, OTHER_TENANT, '01', { coName: 'Other Tenant', lcCode: '01' });

      // Override the fiscal year so 2026-01 dates fall inside the current year.
      await exec(`DELETE FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`, TENANT);
      await exec(
        `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,'01',$2,'2025-04-01','2026-03-31')`,
        TENANT,
        YEAR,
      );
      await exec(
        `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME","AC_CODE") VALUES($1,'01','00','Head Office','BRANCH')`,
        TENANT,
      );

      for (const tenant of [TENANT, OTHER_TENANT]) {
        await exec(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL","DATA_TYPE")
           VALUES($1,'01','01','B1','Order Book 1','OB1','SALES ORDER','O','Y','SL_ORD_DATA','SL_ORD_DETL','A'),
                  ($1,'01','01','B2','Order Book 2','OB2','SALES ORDER','O','Y','SL_ORD_DATA','SL_ORD_DETL','B'),
                  ($1,'01','01','SB','Sales Bill','SB','SALES','O','Y','SL_DATA','SL_DETL','L')`,
          tenant,
        );
        await exec(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL","DATA_TYPE")
           VALUES($1,'01','00','B1','Order Book 1','OB1','SALES ORDER','O','Y','SL_ORD_DATA','SL_ORD_DETL','A')`,
          tenant,
        );
        await exec(
          `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_CITY","AC_AREA") VALUES
           ($1,'01','01','P1','ALPHA JEWELS','SURAT','ADAJAN'),
           ($1,'01','01','P2','BETA TRADERS','BARODA','ALKAPURI')`,
          tenant,
        );
        await exec(
          `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE") VALUES
           ($1,'01','I1','Gold Ring','G','P1','G1'),
           ($1,'01','I2','Gold Chain','G','P1','G1')`,
          tenant,
        );
      }

      for (const o of ORDERS) await insertOrder(TENANT, o);
      for (const a of ADJUSTMENTS) await insertAdjustment(TENANT, a);
      for (const b of BILLS) await insertBill(TENANT, b);

      // Sentinel: same order in another tenant.
      await insertOrder(OTHER_TENANT, {
        ...ORDER_O1,
        co: '01',
        lc: '01',
        year: YEAR,
        book: 'B1',
        vch: 'ZO1',
      });

      // Users.
      for (const [name, lcCode, view, print, subMenu] of [
        ['admin01', '01', 'Y', 'Y', 'Order Report'],
        ['admin00', '00', 'Y', 'Y', 'Order Report'],
        ['order-viewer', '01', 'Y', 'N', 'Order Report'],
        ['sales-only', '01', 'Y', 'N', 'Sales Order'],
      ] as const) {
        await exec(
          `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
           VALUES($1,'01',$2,$3,'USER','N','N',$4,'N')`,
          TENANT,
          name,
          await hashPassword(PASSWORD),
          print,
        );
        await exec(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
           VALUES($1,'01',$2,$3,'Report',$4,$5,'N','N',$6)`,
          TENANT,
          lcCode,
          name,
          subMenu,
          view,
          print,
        );
      }

      // An administrator with no USER_SET row: admins bypass form rights as on every other screen.
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES($1,'01','boss',$2,'ADMIN','Y','Y','Y','N')`,
        TENANT,
        await hashPassword(PASSWORD),
      );

      app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
      cookies['admin01'] = await login('admin01');
      cookies['admin00'] = await login('admin00', '00');
      cookies['order-viewer'] = await login('order-viewer');
      cookies['sales-only'] = await login('sales-only');
      cookies['boss'] = await login('boss');
    });

    afterAll(async () => {
      if (app) await app.close();
      if (owner) {
        await wipe(TENANT);
        await wipe(OTHER_TENANT);
        await owner.$disconnect();
      }
      if (runtime) await runtime.$disconnect();
    });

    const inRange = (o: Order) => o.date >= FROM && o.date <= TO;
    const visible = ORDERS.filter(
      (o) => (o.co ?? '01') === '01' && (o.lc ?? '01') === '01' && inRange(o),
    );
    const dmy = (iso: string) => iso.split('-').reverse().join('/');
    const sumOf = (xs: number[], dp: number) => Number(xs.reduce((a, b) => a + b, 0).toFixed(dp));
    const adjOf = (o: Order, sign: string) =>
      ADJUSTMENTS.filter((a) => a.ordNo === o.vch && a.ordDbcd === o.book && a.sign === sign);
    const amt = (xs: Adjustment[]) => xs.reduce((s, a) => s + a.amt, 0);

    it('order-report.output.report: header and line rows of every order in range, totals from the seeded lines', async () => {
      const r = await report('report');
      const headers = r.rows.filter((x: any) => x.level === 'voucher');
      expect(headers.map((x: any) => x.cells.vchNo).sort()).toEqual(
        visible.map((o) => o.vch).sort(),
      );
      const lines = visible.flatMap((o) => o.lines);
      expect(r.rows.filter((x: any) => x.level === 'line')).toHaveLength(lines.length);
      expect(r.totals.pcs).toBe(
        sumOf(
          lines.map((l) => l.pcs),
          0,
        ),
      );
      expect(r.totals.nwt).toBe(
        sumOf(
          lines.map((l) => l.nwt),
          3,
        ),
      );
      const o1 = headers.find((x: any) => x.cells.vchNo === 'O1');
      expect(o1.cells).toMatchObject({
        acName: ORDER_O1.acName,
        advAmt: ORDER_O1.advAmt,
        vchDate: ORDER_O1.date,
      });
      const ring = r.rows.find((x: any) => x.level === 'line' && x.cells.designNo === 'D1');
      expect(ring.cells.itName).toBe('Gold Ring');
    });

    it('order-report.output.adjust: per-order advance, adjustment and pending through SL_ORD_ADJ.ORD_* (OrdAdvAdj)', async () => {
      const r = await report('adjust');
      for (const o of [ORDER_O1, ORDER_O3]) {
        const g = r.groups.find((x: any) => x.key === `01${YEAR}${o.book}${o.vch}`);
        expect(g, o.vch).toBeTruthy();
        expect(g.label).toBe(`${o.vch} ${dmy(o.date)} ${o.acName}`);
        const plus = amt(adjOf(o, '+'));
        const minus = amt(adjOf(o, '-'));
        expect(g.totals).toEqual({ plusAmt: plus, minusAmt: minus, balAmt: plus - minus });
      }
      const all = visible.flatMap((o) =>
        ADJUSTMENTS.filter((a) => a.ordNo === o.vch && a.ordDbcd === o.book),
      );
      const plus = amt(all.filter((a) => a.sign === '+'));
      const minus = amt(all.filter((a) => a.sign === '-'));
      expect(r.totals).toEqual({ plusAmt: plus, minusAmt: minus, balAmt: plus - minus });
      expect(r.rows).toHaveLength(0);
    });

    it('order-report.output.with-bill: bills reached through the adjustment row, @PandingTot per order (OrdAdjBillWise)', async () => {
      const r = await report('with-bill');
      for (const o of [ORDER_O1, ORDER_O3]) {
        const g = r.groups.find((x: any) => x.depth === 1 && x.key === o.vch);
        const minus = amt(adjOf(o, '-'));
        expect(g.totals).toEqual({ advAmt: o.advAmt, adjAmt: minus, pendingAmt: o.advAmt - minus });
      }
      const o1 = r.rows
        .filter((x: any) => x.voucherKey === `01|${YEAR}|B1|O1`)
        .map((x: any) => x.cells);
      expect(o1).toEqual([
        {
          adjBook: 'B1',
          adjVchNo: 'O1',
          adjVchDate: '2026-01-05',
          billParty: null,
          billTotAmt: 0,
          adjAmt: 0,
        },
        {
          adjBook: 'SB',
          adjVchNo: 'S1',
          adjVchDate: '2026-01-18',
          billParty: 'ALPHA JEWELS',
          billTotAmt: 12000,
          adjAmt: 1500,
        },
        {
          adjBook: 'SB',
          adjVchNo: 'S1',
          adjVchDate: '2026-01-18',
          billParty: 'ALPHA JEWELS',
          billTotAmt: 12000,
          adjAmt: 500,
        },
      ]);
      // City/Area read the BILL party's AC_MAST in this template: only rows with a bill of a SURAT party remain.
      const surat = await report('with-bill', 'city=SURAT');
      expect(surat.rows.map((x: any) => `${x.cells.adjVchNo}:${x.cells.adjAmt}`)).toEqual([
        'S1:1500',
        'S1:500',
        'S2:1500',
        'S2:1500',
      ]);
    });

    it('order-report.output.bill-wise: bills with adjustments only, raw ORD_AMT, all selectors applied (BillWiseOrderAdjust)', async () => {
      const r = await report('bill-wise');
      const shape = r.rows.map((x: any) =>
        x.level === 'voucher'
          ? `${x.cells.vchNo}:${x.cells.billTotAmt}:${x.cells.billAdvAmt}`
          : `  ${x.cells.ordNo}:${x.cells.ordAmt}:${x.cells.orderPartyName}`,
      );
      const expected: string[] = [];
      for (const b of BILLS.filter((b) => b.date >= FROM && b.date <= TO)) {
        const rows = ADJUSTMENTS.filter((a) => a.book === b.book && a.vch === b.vch);
        if (!rows.length) continue;
        expected.push(`${b.vch}:${b.totAmt}:${b.advAmt}`);
        for (const a of rows) expected.push(`  ${a.ordNo}:${a.amt}:ALPHA JEWELS`);
      }
      expect(shape).toEqual(expected);
      expect(shape.join()).not.toContain('S3');
      expect(r.grandTotal).toBe(false);
      expect((await report('bill-wise', 'city=BARODA')).rows).toHaveLength(0);
      expect((await report('bill-wise', 'acCode=P2')).rows).toHaveLength(0);
      expect((await report('bill-wise', 'coBook=SB&custName=ALPHA%20JEWELS')).rows).toHaveLength(
        shape.length,
      );
    });

    it('order-report.formula.pending-set: Making Panding lists every DESIGN_ISU = N line in range (RP_ALL.cs:10940)', async () => {
      // The fully-adjusted DESIGN_ISU write runs only for registration HM310NEPK (RP_ALL.cs:10925); every other
      // installation prints the stored flag, so the fully adjusted O3 still lists and the stock-less O8 does not.
      const r = await report('pending');
      const expected = visible
        .flatMap((o) => o.lines.filter((l) => l.designIsu === 'N').map((l) => ({ o, l })))
        .sort(
          (a, b) =>
            `${a.o.book}${a.o.vch}`.localeCompare(`${b.o.book}${b.o.vch}`) || a.l.sr - b.l.sr,
        );
      const lines = r.rows.filter((x: any) => x.level === 'line');
      expect(lines.map((x: any) => x.cells.design)).toEqual(
        expected.map((x) => x.l.designNo || x.l.tagNo),
      );
      expect(r.totals.pcs).toBe(
        sumOf(
          expected.map((x) => x.l.pcs),
          0,
        ),
      );
      expect(r.totals.nwt).toBe(
        sumOf(
          expected.map((x) => x.l.nwt),
          3,
        ),
      );
      expect(lines.map((x: any) => x.cells.design)).not.toContain('D8');

      const summ = await report('summary');
      const yes = await report('summary', 'onlySummary=yes');
      expect(summ.rows).toHaveLength(expected.length);
      expect(yes.rows).toHaveLength(0);
      expect(yes.groups.map((g: any) => [g.key, g.totals])).toEqual(
        summ.groups.map((g: any) => [g.key, g.totals]),
      );
      expect(summ.groups.find((g: any) => g.key === 'T1D1').totals).toEqual({ pcs: 1, nwt: 10.5 });
    });

    it('order-report.lifecycle.writes-nothing: running all seven modes writes zero rows (D2)', async () => {
      const before = await snapshot();
      for (const mode of [
        'report',
        'advance',
        'adjust',
        'with-bill',
        'pending',
        'summary',
        'bill-wise',
      ]) {
        const r = await get(
          'admin01',
          `/reports/order-report?fromDate=${FROM}&toDate=${TO}&mode=${mode}`,
        );
        expect(r.statusCode, `${mode}: ${r.body}`).toBe(200);
      }
      const after = await snapshot();
      expect(after.counts).toEqual(before.counts);
      expect(after.flags).toEqual(before.flags);
    });

    it('order-report.scope.sentinels: another location, company or tenant never appears; a 00 user may list all', async () => {
      for (const mode of [
        'report',
        'advance',
        'adjust',
        'with-bill',
        'pending',
        'summary',
        'bill-wise',
      ]) {
        const r = await get(
          'admin01',
          `/reports/order-report?fromDate=${FROM}&toDate=${TO}&mode=${mode}`,
        );
        expect(r.statusCode).toBe(200);
        expect(r.body).not.toContain('"O6"');
        expect(r.body).not.toContain('D7'); // O7: company C2, same book/number as O1
        expect(r.body).not.toContain('ZO1');
      }
      const all = await get(
        'admin00',
        `/reports/order-report?fromDate=${FROM}&toDate=${TO}&mode=report&lcCode=`,
      );
      expect(all.statusCode, all.body).toBe(200);
      expect(all.json().rows.map((x: any) => x.cells.vchNo)).toContain('O6');
      const own = await get(
        'admin00',
        `/reports/order-report?fromDate=${FROM}&toDate=${TO}&mode=report`,
      );
      expect(
        own
          .json()
          .rows.filter((x: any) => x.level === 'voucher')
          .map((x: any) => x.cells.vchNo),
      ).toEqual(['O6']);
    });

    it('order-report.report-location: a 00 session picks a branch; invalid and locked sessions are refused', async () => {
      const at = (q: string, user = 'admin00') =>
        get(user, `/reports/order-report?fromDate=${FROM}&toDate=${TO}&mode=report&${q}`);
      const vouchers = (r: any) =>
        r
          .json()
          .rows.filter((x: any) => x.level === 'voucher')
          .map((x: any) => x.cells.vchNo);
      // RP_ALL.cs:6660-6671, 8383: the head office box names a branch; only that location's orders list.
      const one = await at('reportLcCode=01');
      expect(one.statusCode, one.body).toBe(200);
      expect(vouchers(one)).toContain('O1');
      expect(vouchers(one)).not.toContain('O6');
      const head = await at('reportLcCode=00');
      expect(head.statusCode, head.body).toBe(200);
      expect(vouchers(head)).toEqual(['O6']);
      const all = await at('reportLcCode=');
      expect(all.statusCode, all.body).toBe(200);
      expect(vouchers(all)).toEqual(expect.arrayContaining(['O1', 'O6']));
      const csv = await get(
        'admin00',
        `/reports/order-report/export.csv?fromDate=${FROM}&toDate=${TO}&mode=report&reportLcCode=00`,
      );
      expect(csv.statusCode, csv.body).toBe(200);
      expect(csv.body).toContain('O6');
      expect(csv.body).not.toContain('O1,');
      // RP_ALL.cs:7691: a location outside the company's LOCT_MAST is refused.
      const bad = await at('reportLcCode=99');
      expect(bad.statusCode).toBe(400);
      expect(bad.json().error).toBe('invalid-location');
      // A session that is not head office cannot send one (RP_ALL.cs:6664).
      const locked = await at('reportLcCode=00', 'admin01');
      expect(locked.statusCode).toBe(400);
      expect(locked.json().error).toBe('location-locked');
    });

    it('order-report.rights.caption-and-print: rights key on the Order Report caption (D6, D7)', async () => {
      const url = `/reports/order-report?fromDate=${FROM}&toDate=${TO}`;
      expect((await get('sales-only', url)).statusCode).toBe(403);
      expect((await get('order-viewer', url)).statusCode).toBe(200);
      expect(
        (await get('order-viewer', url.replace('order-report?', 'order-report/export.csv?')))
          .statusCode,
      ).toBe(403);
      const csv = await get('admin01', url.replace('order-report?', 'order-report/export.csv?'));
      expect(csv.statusCode).toBe(200);
      expect(csv.headers['content-type']).toContain('text/csv');
      expect(csv.body).toContain('Total :');
      const xlsx = await get('admin01', url.replace('order-report?', 'order-report/export.xlsx?'));
      expect(xlsx.statusCode).toBe(200);
      // An administrator needs no USER_SET row, as on every other form (authorization.ts admin bypass).
      expect((await get('boss', url)).statusCode).toBe(200);
      expect(
        (await get('boss', url.replace('order-report?', 'order-report/export.csv?'))).statusCode,
      ).toBe(200);
    });
  },
);
