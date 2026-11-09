import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-11 Sales Report (RP_ALL) through the real Fastify routes under forced RLS.
 *
 * NEEDS A STACK RUN: written without a local database (the WP-11 phase-one rule: no third stack on this
 * machine). CI runs it with RUN_DB_INTEGRITY_TESTS=1 on the isolated test database.
 *
 * Every expected number is added up here from the fixture vouchers with the template's formula
 * (SaleReport.xml / SalesSumm.xml / EmpSaleReport.xml), never read back from the API.
 */

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'rpall-sales-db';
const OTHER_TENANT = 'rpall-sales-other';
const PASSWORD = 'RpAll-Sales!2026';
const SECRET = 'rpall-sales-test-signing-secret-over-thirty-two-characters';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const OLD_YEAR = `${startYear - 1}-${startYear}`;
const FROM = `${startYear}-04-01`;
const TO = `${startYear}-04-30`;
const DAY1 = `${startYear}-04-05`;
const DAY2 = `${startYear}-04-06`;
const OUTSIDE = `${startYear}-05-02`;

interface Sub {
  isr: number;
  it: string;
  pcs: number;
  gwt: number;
  rate: number;
  net: number;
}
interface Line {
  sr: number;
  it: string;
  pcs: number;
  gwt: number;
  nwt: number;
  rate: number;
  lbrAmt: number;
  oth: number;
  itmAmt: number;
  tot: number;
  net: number;
  itTax: number;
  ordNo?: string;
  subs?: Sub[];
}
interface Voucher {
  co?: string;
  lc?: string;
  year?: string;
  book: string;
  vch: string;
  date: string;
  ac: string;
  emp: string;
  net: number;
  disc: number;
  tax: number;
  tot: number;
  cash: number;
  kasar: number;
  os: number;
  rtnNet?: number;
  rtnTot?: number;
  lines: Line[];
}

const L = (sr: number, over: Partial<Line> = {}): Line => ({
  sr,
  it: 'G22',
  pcs: 1,
  gwt: 10,
  nwt: 9.5,
  rate: 6000,
  lbrAmt: 4750,
  oth: 0,
  itmAmt: 57000,
  tot: 61750,
  net: 61750,
  itTax: 1852.5,
  ...over,
});

// In scope: company 01, location 01, the current year, April.
const V1: Voucher = {
  book: 'SL',
  vch: 'S0001',
  date: DAY1,
  ac: 'C1',
  emp: 'E01',
  net: 100000,
  disc: 500,
  tax: 3000,
  tot: 102500,
  cash: 50000,
  kasar: 0,
  os: 52500,
  lines: [
    L(1, {
      oth: 1500,
      net: 63250,
      tot: 63250,
      subs: [
        { isr: 1, it: 'ST1', pcs: 2, gwt: 0.2, rate: 500, net: 1000 },
        { isr: 2, it: 'ST1', pcs: 1, gwt: 0.1, rate: 500, net: 500 },
      ],
    }),
    L(2, {
      nwt: 4.25,
      gwt: 4.5,
      itmAmt: 30000,
      lbrAmt: 6750,
      net: 36750,
      tot: 36750,
      itTax: 1102.5,
      ordNo: 'O17',
    }),
  ],
};
const V2: Voucher = {
  book: 'SL',
  vch: 'S0002',
  date: DAY1,
  ac: 'C2',
  emp: 'E02',
  net: 8000,
  disc: 0,
  tax: 240,
  tot: 8240,
  cash: 8240,
  kasar: 0,
  os: 0,
  lines: [
    L(1, {
      it: 'S1',
      gwt: 100,
      nwt: 100,
      rate: 80,
      lbrAmt: 0,
      itmAmt: 8000,
      net: 8000,
      tot: 8000,
      itTax: 240,
    }),
  ],
};
const V3: Voucher = {
  book: 'SX',
  vch: 'X0001',
  date: DAY2,
  ac: 'C1',
  emp: 'E01',
  net: 20000,
  disc: 0,
  tax: 600,
  tot: 20600,
  cash: 600,
  kasar: 600,
  os: 19400,
  rtnNet: 1500,
  rtnTot: 1545,
  lines: [
    L(1, { nwt: 3.333, gwt: 3.5, itmAmt: 20000, lbrAmt: 0, net: 20000, tot: 20000, itTax: 600 }),
  ],
};
// In scope but NET_AMT = 0: left out by every NET_AMT <> 0 formula, kept by Employ Sales (no guard).
const V0: Voucher = {
  book: 'SL',
  vch: 'S0003',
  date: DAY2,
  ac: 'C2',
  emp: 'E02',
  net: 0,
  disc: 0,
  tax: 0,
  tot: 0,
  cash: 0,
  kasar: 0,
  os: 0,
  lines: [L(1, { nwt: 0, gwt: 0, pcs: 0, itmAmt: 0, lbrAmt: 0, net: 0, tot: 0, itTax: 0 })],
};
const IN_SCOPE = [V1, V2, V3];
// Sentinels: another company, location, year, date and tenant. None may ever appear.
const SENTINELS: Voucher[] = [
  { ...V2, co: '02', vch: 'Z-CO' },
  { ...V2, lc: '02', vch: 'Z-LC' },
  { ...V2, year: OLD_YEAR, vch: 'Z-YR' },
  { ...V2, date: OUTSIDE, vch: 'Z-DT' },
];
const OTHER_TENANT_VOUCHER: Voucher = { ...V2, vch: 'Z-TN' };

const round = (x: number, dp: number) => Number(x.toFixed(dp));
const sum = <T>(xs: T[], f: (x: T) => number, dp = 2) =>
  round(
    xs.reduce((s, x) => s + f(x), 0),
    dp,
  );
const lines = (vs: Voucher[]) => vs.flatMap((v) => v.lines);

(enabled ? describe : describe.skip)(
  'RP_ALL Sales Report over HTTP under forced RLS (WP-11)',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    const cookies: Record<string, string> = {};
    const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
    const wipe = async (tenant: string) => {
      const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
        `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
      );
      for (const row of rows)
        await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenant);
    };
    const login = async (name: string) => {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': TENANT },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: name, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const values = response.headers['set-cookie'];
      return (Array.isArray(values) ? values : [values ?? ''])
        .map((value) => value.split(';', 1)[0])
        .join('; ');
    };
    const get = (user: string, url: string) =>
      app.inject({ method: 'GET', url, headers: { cookie: cookies[user]! } });
    const report = async (query: string, user = 'printer') => {
      const response = await get(
        user,
        `/reports/sales-report?fromDate=${FROM}&toDate=${TO}&${query}`,
      );
      expect(response.statusCode, response.body).toBe(200);
      return response.json();
    };
    const vchNos = (body: any) =>
      [...new Set((body.rows as any[]).map((r) => String(r.voucherKey).split('|')[2]))].sort();

    const insertVoucher = async (tenant: string, v: Voucher) => {
      const key = [tenant, v.co ?? '01', v.lc ?? '01', v.year ?? YEAR, v.book, v.vch];
      await exec(
        `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","BILL_NO","AC_CODE","AC_NAME","EMP_CODE",
         "NET_AMT","DISC_AMT","TAX_AMT","ROF_AMT","TOT_AMT","CGST_TAX","SGST_TAX","CASH_AMT","CHQ_AMT","CARD_AMT","ADV_AMT","OLD_GL_AMT","OLD_SL_AMT",
         "KASAR_AMT","BILL_OS","RTN_NET_AMT","RTN_TOT_AMT")
       VALUES($1,$2,$3,$4,$5,$6,$7::date,$6,$8,$9,$10,$11,$12,$13,0,$14,$15,$15,$16,0,0,0,0,0,$17,$18,$19,$20)`,
        ...key,
        v.date,
        v.ac,
        `Party ${v.ac}`,
        v.emp,
        v.net,
        v.disc,
        v.tax,
        v.tot,
        v.tax / 2,
        v.cash,
        v.kasar,
        v.os,
        v.rtnNet ?? 0,
        v.rtnTot ?? 0,
      );
      for (const l of v.lines) {
        await exec(
          `INSERT INTO "SL_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TYPE","AC_CODE","IT_CODE","TAG_NO",
           "ITM_PCS","ITM_GWT","ITM_NWT","ITM_RATE","LBR_RATE","LBR_AMT","OTH_AMT","ITM_AMT","ITM_MRP","TOT_AMT","NET_AMT","IT_TAX_AMT","IT_DISC_AMT","ORD_NO")
         VALUES($1,$2,$3,$4,$5,$6,$7,$8::date,'S',$9,$10,$11,$12,$13,$14,$15,0,$16,$17,$18,0,$19,$20,$21,0,$22)`,
          ...key,
          l.sr,
          v.date,
          v.ac,
          l.it,
          `T${v.vch}${l.sr}`,
          l.pcs,
          l.gwt,
          l.nwt,
          l.rate,
          l.lbrAmt,
          l.oth,
          l.itmAmt,
          l.tot,
          l.net,
          l.itTax,
          l.ordNo ?? '',
        );
        for (const s of l.subs ?? []) {
          await exec(
            `INSERT INTO "SL_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","IT_CODE","IT_PCS","IT_GWT","IT_RATE","IT_NET_AMT")
           VALUES($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,$13)`,
            ...key,
            l.sr,
            s.isr,
            s.it,
            s.pcs,
            s.gwt,
            s.rate,
            s.net,
          );
        }
      }
    };

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe(TENANT);
      await wipe(OTHER_TENANT);
      await seedCompany(runtime, TENANT, '01', { coName: 'RP ALL Jewellers', lcCode: '01' });
      await seedCompany(runtime, OTHER_TENANT, '01', { coName: 'Other Tenant', lcCode: '01' });
      for (const tenant of [TENANT, OTHER_TENANT]) {
        await exec(
          `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_CITY","AC_AREA") VALUES
         ($1,'01','01','C1','Party C1','SURAT','ADAJAN'),($1,'01','01','C2','Party C2','MUMBAI','FORT')`,
          tenant,
        );
        await exec(
          `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE") VALUES
         ($1,'01','G22','Gold 22K','G','P1','GR1'),($1,'01','S1','Silver','S','P3','GR2'),($1,'01','ST1','Stone','O','P9','GR9')`,
          tenant,
        );
        await exec(
          `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES ($1,'01','P1','Rings'),($1,'01','P3','Payal')`,
          tenant,
        );
        await exec(
          `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME") VALUES ($1,'01','GR1','Gold Group'),($1,'01','GR2','Silver Group')`,
          tenant,
        );
        await exec(
          `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME") VALUES ($1,'01','E01','Ravi'),($1,'01','E02','Mina')`,
          tenant,
        );
        await exec(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","CUR_USE") VALUES
         ($1,'01','01','SL','Sales','SL','SALES','Y'),($1,'01','01','SX','Sales X','SX','SALES','Y')`,
          tenant,
        );
      }
      for (const v of [...IN_SCOPE, V0, ...SENTINELS]) await insertVoucher(TENANT, v);
      await insertVoucher(OTHER_TENANT, OTHER_TENANT_VOUCHER);

      for (const [name, view, print] of [
        ['viewer', 'Y', 'N'],
        ['printer', 'Y', 'Y'],
        ['blocked', 'N', 'N'],
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
         VALUES($1,'01','01',$2,'Report','Sales Report',$3,'N','N',$4)`,
          TENANT,
          name,
          view,
          print,
        );
      }
      app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
      cookies.viewer = await login('viewer');
      cookies.printer = await login('printer');
      cookies.blocked = await login('blocked');
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

    it('Sales Report: in-scope sales only, footer totals from the vouchers (SaleReport.xml Section10)', async () => {
      const body = await report('mode=report');
      expect(body.template).toBe('SaleReport');
      expect(vchNos(body)).toEqual(['S0001', 'S0002', 'X0001']);
      expect(body.voucherCount).toBe(3);
      expect(body.totals).toEqual({
        itmAmt: sum(IN_SCOPE, (v) => v.net),
        discAmt: sum(IN_SCOPE, (v) => v.disc),
        taxAmt: sum(IN_SCOPE, (v) => v.tax),
        vchAmt: sum(IN_SCOPE, (v) => v.tot),
        pcs: sum(lines(IN_SCOPE), (l) => l.pcs, 0),
        gwt: sum(lines(IN_SCOPE), (l) => l.gwt, 3),
        nwt: sum(lines(IN_SCOPE), (l) => l.nwt, 3),
        lbrAmt: sum(lines(IN_SCOPE), (l) => l.lbrAmt),
      });
      // Stone sub-lines print under the line with other amount (Section6).
      expect(body.rows.filter((r: any) => r.level === 'sub')).toHaveLength(2);
    });

    it('Sales Reg: a two-line bill is counted once in DATE TOTAL and GRAND TOTAL', async () => {
      const body = await report('mode=register');
      const day1 = body.groups.find((g: any) => g.key === DAY1);
      expect(day1.totals.netAmt).toBe(sum([V1, V2], (v) => v.net));
      expect(day1.totals.nwt).toBe(sum(lines([V1, V2]), (l) => l.nwt, 3));
      expect(body.totals.totAmt).toBe(sum(IN_SCOPE, (v) => v.tot));
      expect(body.totals.kasarAmt).toBe(sum(IN_SCOPE, (v) => v.kasar));
      expect(body.totals.billOs).toBe(sum(IN_SCOPE, (v) => v.os));
    });

    it('each selector narrows the row set exactly as the button formula does', async () => {
      expect(vchNos(await report('mode=report&acCode=C1'))).toEqual(['S0001', 'X0001']);
      expect(vchNos(await report('mode=report&city=MUMBAI'))).toEqual(['S0002']);
      expect(vchNos(await report('mode=report&area=ADAJAN'))).toEqual(['S0001', 'X0001']);
      expect(vchNos(await report('mode=report&coBook=SX'))).toEqual(['X0001']);
      expect(vchNos(await report('mode=report&books=SL'))).toEqual(['S0001', 'S0002']);
      expect(vchNos(await report('mode=report&empCode=E02'))).toEqual(['S0002']);
      expect(vchNos(await report('mode=report&itemType=Silver'))).toEqual(['S0002']);
      // Sales Reg's formula has no item type (RP_ALL.cs:7771-7809): ignored, reported, all three bills.
      const reg = await report('mode=register&itemType=Silver');
      expect(vchNos(reg)).toEqual(['S0001', 'S0002', 'X0001']);
      expect(reg.ignoredFilters).toEqual(['itemType']);
      // Item Wise applies product and group.
      const item = await report('mode=item&prCode=P3');
      expect(item.rows).toHaveLength(1);
      expect(item.totals.nwt).toBe(100);
    });

    it('the return prompt reads RTN_NET_AMT <> 0 (SaleRtnReport)', async () => {
      const body = await report('mode=report&returns=yes');
      expect(body.template).toBe('SaleRtnReport');
      expect(vchNos(body)).toEqual(['X0001']);
      expect(body.totals.itmAmt).toBe(1500);
      expect(body.totals.vchAmt).toBe(1545);
      const reg = await report('mode=register&returns=yes');
      expect(reg.template).toBe('SalesRtnSumm');
      expect(reg.totals.rtnTotAmt).toBe(1545);
    });

    it('Employ Sales has no amount guard; Sale With Order filters ORD_NO on the prompt', async () => {
      const emp = await report('mode=employee');
      expect(vchNos(emp)).toEqual(['S0001', 'S0002', 'S0003', 'X0001']);
      const e01 = emp.groups.find((g: any) => g.key === 'E01');
      expect(e01.totals.vchAmt).toBe(sum([V1, V3], (v) => v.tot - v.kasar));
      const order = await report('mode=with-order&orderOnly=yes');
      expect(order.rows).toHaveLength(1);
      expect(order.totals.lineNetAmt).toBe(36750);
    });

    it('never shows another company, location, year, date or tenant', async () => {
      for (const mode of ['report', 'register', 'item', 'group', 'employee', 'with-order']) {
        const body = await report(`mode=${mode}`);
        const text = JSON.stringify(body);
        for (const vch of ['Z-CO', 'Z-LC', 'Z-YR', 'Z-DT', 'Z-TN'])
          expect(text, `${mode} ${vch}`).not.toContain(vch);
      }
    });

    it('refuses a user without the Sales Report right, and exports only with Print', async () => {
      expect(
        (await get('blocked', `/reports/sales-report?fromDate=${FROM}&toDate=${TO}`)).statusCode,
      ).toBe(403);
      expect(
        (
          await get(
            'viewer',
            `/reports/sales-report/export.csv?fromDate=${FROM}&toDate=${TO}&mode=register`,
          )
        ).statusCode,
      ).toBe(403);
      const csv = await get(
        'printer',
        `/reports/sales-report/export.csv?fromDate=${FROM}&toDate=${TO}&mode=register`,
      );
      expect(csv.statusCode, csv.body).toBe(200);
      const last = csv.body.trim().split('\r\n').pop()!.split(',');
      expect(last[0]).toBe('GRAND TOTAL :');
      expect(last).toContain(sum(IN_SCOPE, (v) => v.net).toFixed(2));
      const xlsx = await get(
        'printer',
        `/reports/sales-report/export.xlsx?fromDate=${FROM}&toDate=${TO}&mode=item`,
      );
      expect(xlsx.statusCode).toBe(200);
    });

    it('validates input like the desktop: bad date 400, reversed range empty, locked location 400', async () => {
      const bad = await get('printer', `/reports/sales-report?fromDate=2026-13-01&toDate=${TO}`);
      expect(bad.statusCode).toBe(400);
      expect(bad.json().error).toBe('invalid-date');
      const reversedResponse = await get(
        'printer',
        `/reports/sales-report?fromDate=${TO}&toDate=${FROM}`,
      );
      expect(reversedResponse.statusCode, reversedResponse.body).toBe(200);
      const reversed = reversedResponse.json();
      expect(reversed.rows).toEqual([]);
      expect(reversed.totals.vchAmt).toBe(0);
      const locked = await get(
        'printer',
        `/reports/sales-report?fromDate=${FROM}&toDate=${TO}&lcCode=02`,
      );
      expect(locked.statusCode).toBe(400);
      const lacks = await get(
        'printer',
        `/reports/sales-report?fromDate=${FROM}&toDate=${TO}&mode=item&city=SURAT`,
      );
      expect(lacks.statusCode).toBe(400);
      expect(lacks.json().error).toBe('filter-not-in-template');
    });
  },
);
