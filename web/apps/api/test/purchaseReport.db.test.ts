import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { FakePdfRenderer } from '../src/modules/reports/render.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-12 Purchase Rpt (RP_ALL) through the real Fastify routes under forced RLS.
 *
 * Every expected number is added up here from the fixture vouchers with the template's formula
 * (PurcReport.xml, PurcSumm.xml, PurcItem.xml, AcPurcSummRpt.xml, PurcGroupWise.xml), never read back from the API.
 */

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'rpall-purchase-db';
const OTHER_TENANT = 'rpall-purchase-other';
const PASSWORD = 'RpAll-Purchase!2026';
const SECRET = 'rpall-purchase-test-signing-secret-over-thirty-two-characters';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const OLD_YEAR = `${startYear - 1}-${startYear}`;
const FROM = `${startYear}-04-01`;
const TO = `${startYear}-04-30`;
const DAY1 = `${startYear}-04-05`;
const DAY2 = `${startYear}-04-06`;
const OUTSIDE = `${startYear}-05-02`;

interface Line {
  sr: number;
  it: string;
  pcs: number;
  gwt: number;
  nwt: number;
  fine: number;
  rate: number;
  amt: number;
  lbr: number;
  net: number;
}
interface Voucher {
  co?: string;
  lc?: string;
  year?: string;
  book: string;
  vch: string;
  date: string;
  ac: string;
  net: number;
  tax: number;
  tot: number;
  cash: number;
  lines: Line[];
}

// In scope: company 01, location 01, the current year, April. 3% GST on the net amount.
const V1: Voucher = {
  book: 'PUR',
  vch: '00001',
  date: DAY1,
  ac: 'C1',
  net: 113836,
  tax: 3415.08,
  tot: 117251.08,
  cash: 1000,
  lines: [
    {
      sr: 1,
      it: 'G22',
      pcs: 1,
      gwt: 20,
      nwt: 20,
      fine: 18.32,
      rate: 6050,
      amt: 110836,
      lbr: 3000,
      net: 113836,
    },
  ],
};
const V2: Voucher = {
  book: 'PUR',
  vch: '00002',
  date: DAY1,
  ac: 'C2',
  net: 7400,
  tax: 222,
  tot: 7622,
  cash: 0,
  lines: [
    {
      sr: 1,
      it: 'S1',
      pcs: 1,
      gwt: 100,
      nwt: 100,
      fine: 92.5,
      rate: 74,
      amt: 7400,
      lbr: 0,
      net: 7400,
    },
  ],
};
// A purchase return, in the outbound book.
const V3: Voucher = {
  book: 'PRT',
  vch: '00001',
  date: DAY2,
  ac: 'C1',
  net: 5000,
  tax: 150,
  tot: 5150,
  cash: 0,
  lines: [
    {
      sr: 1,
      it: 'G22',
      pcs: 1,
      gwt: 10,
      nwt: 10,
      fine: 9.16,
      rate: 500,
      amt: 5000,
      lbr: 0,
      net: 5000,
    },
  ],
};
const IN_SCOPE = [V1, V2, V3];
// A zero-amount purchase: left out by Group Purc (NET_AMT <> 0), kept by every other button.
const V0: Voucher = {
  book: 'PUR',
  vch: '00003',
  date: DAY2,
  ac: 'C2',
  net: 0,
  tax: 0,
  tot: 0,
  cash: 0,
  lines: [{ sr: 1, it: 'S1', pcs: 0, gwt: 0, nwt: 0, fine: 0, rate: 0, amt: 0, lbr: 0, net: 0 }],
};
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
  'RP_ALL Purchase Rpt over HTTP under forced RLS (WP-12)',
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
        `/reports/purchase-report?fromDate=${FROM}&toDate=${TO}&${query}`,
      );
      expect(response.statusCode, response.body).toBe(200);
      return response.json();
    };
    /** The distinct voucher numbers a result prints, from its voucher and line rows. */
    const vouchersOf = (body: any) =>
      [
        ...new Set(
          (body.table.lines as any[])
            .filter((l) => ['voucher', 'line'].includes(l._kind) && l.vchNo !== undefined)
            .map((l) => `${l.vchNo}`),
        ),
      ].sort();

    const insertVoucher = async (tenant: string, v: Voucher) => {
      const key = [tenant, v.co ?? '01', v.lc ?? '01', v.year ?? YEAR, v.book, v.vch];
      await exec(
        `INSERT INTO "PR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","BILL_NO","AC_CODE","AC_NAME",
         "NET_AMT","DISC_AMT","TAX_AMT","ROF_AMT","TOT_AMT","CGST_TAX","SGST_TAX","IGST_TAX","CASH_AMT","CARD_AMT","CHQ_AMT","KASAR_AMT","BILL_OS")
       VALUES($1,$2,$3,$4,$5,$6,$7::date,'',$8,$9,$10,0,$11,0,$12,$13,$13,0,$14,0,0,0,0)`,
        ...key,
        v.date,
        v.ac,
        `Party ${v.ac}`,
        v.net,
        v.tax,
        v.tot,
        v.tax / 2,
        v.cash,
      );
      for (const l of v.lines) {
        await exec(
          `INSERT INTO "PR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","IT_CODE","TAG_NO",
           "ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","ITM_RATE","LBR_AMT","OTH_AMT","ITM_AMT","TOT_AMT","NET_AMT")
         VALUES($1,$2,$3,$4,$5,$6,$7,$8::date,$9,$10,'',$11,$12,$13,0,0,$14,$15,$16,0,$17,$18,$18)`,
          ...key,
          l.sr,
          v.date,
          v.ac,
          l.it,
          l.pcs,
          l.gwt,
          l.nwt,
          l.fine,
          l.rate,
          l.lbr,
          l.amt,
          l.net,
        );
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
         ($1,'01','G22','Gold 22K','G','P1','GR1'),($1,'01','S1','Silver','S','P3','GR2')`,
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
        // The provisioned company already carries a PURCHASE book: replace it with the two this test reads.
        await exec(
          `DELETE FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK" IN ('PUR','PRT')`,
          tenant,
        );
        await exec(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","BOOK_SR_NAME","MAIN_BOOK","BOOK_INOUT","CUR_USE") VALUES
         ($1,'01','01','PUR','Purchase','PU','PU','PURCHASE','I','Y'),($1,'01','01','PRT','Purchase Return','PR','PR','PURC RETURN','O','Y')`,
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
         VALUES($1,'01','01',$2,'Report','Purchase Rpt',$3,'N','N',$4)`,
          TENANT,
          name,
          view,
          print,
        );
      }
      app = await buildApp({
        prisma: runtime,
        secret: SECRET,
        secureCookies: false,
        pdfRenderer: new FakePdfRenderer(),
      });
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

    it('Purc Report: in-scope purchases only, footer totals from the vouchers (PurcReport.xml Section10)', async () => {
      const body = await report('mode=report');
      expect(body.template).toBe('PurcReport');
      expect(vouchersOf(body)).toEqual(['00001', '00002', '00003']);
      expect(body.voucherCount).toBe(4); // PURCHASE 1, 2, 3 and PRT 1
      expect(body.totals).toMatchObject({
        itmAmt: sum(IN_SCOPE, (v) => v.net),
        taxAmt: sum(IN_SCOPE, (v) => v.tax),
        vchAmt: sum(IN_SCOPE, (v) => v.tot),
        pcs: sum(lines(IN_SCOPE), (l) => l.pcs, 0),
        gwt: sum(lines(IN_SCOPE), (l) => l.gwt, 3),
        nwt: sum(lines(IN_SCOPE), (l) => l.nwt, 3),
        lbrAmt: sum(lines(IN_SCOPE), (l) => l.lbr),
      });
    });

    it('Purc Reg: a day total and the grand total from TOT_AMT, CASH_AMT and the credit TOT_AMT - CASH_AMT', async () => {
      const body = await report('mode=register');
      expect(body.template).toBe('PurcSumm');
      const day1 = body.table.lines.find((l: any) => l._band === 'DATE TOTAL :');
      expect(Number(day1.totAmt)).toBe(sum([V1, V2], (v) => v.tot));
      expect(Number(day1.cashAmt)).toBe(sum([V1, V2], (v) => v.cash));
      expect(Number(day1.creditAmt)).toBe(sum([V1, V2], (v) => v.tot - v.cash));
      expect(body.totals.totAmt).toBe(sum(IN_SCOPE, (v) => v.tot));
      expect(body.selection).toEqual({
        voucherCount: 4,
        netAmt: sum(IN_SCOPE, (v) => v.net),
        taxAmt: sum(IN_SCOPE, (v) => v.tax),
        totAmt: sum(IN_SCOPE, (v) => v.tot),
        fine: null,
        nwt: null,
      });
    });

    it('each selector narrows the row set exactly as the button formula does', async () => {
      expect(vouchersOf(await report('mode=register&acCode=C1'))).toEqual(['00001']);
      expect(vouchersOf(await report('mode=register&city=MUMBAI'))).toEqual(['00002', '00003']);
      expect(vouchersOf(await report('mode=register&area=ADAJAN'))).toEqual(['00001']);
      expect(vouchersOf(await report('mode=register&coBook=PRT'))).toEqual(['00001']);
      // Purc Reg's formula has no item type (RP_ALL.cs:8028-8068): ignored, reported, nothing narrowed.
      const reg = await report('mode=register&itemType=Silver');
      expect(reg.voucherCount).toBe(4);
      expect(reg.ignoredFilters).toEqual(['itemType']);
      // Item Wise applies product, group and item type.
      const item = await report('mode=item&prCode=P3');
      expect(item.totals.nwt).toBe(100);
      expect(item.totals.fine).toBe(92.5);
      const type = await report('mode=item&itemType=S');
      expect(type.totals.nwt).toBe(100);
      expect(item.selection.voucherCount).toBe(2); // 00002 and the empty-weight 00003
    });

    it('Group Purc leaves out NET_AMT = 0 and sums the lines under GOLD and SILVER', async () => {
      const body = await report('mode=group');
      expect(body.template).toBe('PurcGroupWise');
      expect(vouchersOf(body)).toEqual(['00001', '00002']);
      expect(body.totals.lineNetAmt).toBe(sum(lines(IN_SCOPE), (l) => l.net));
      const gold = body.table.lines.find((l: any) => l._band === 'GOLD');
      expect(Number(gold.nwt)).toBe(30); // V1 20 g + the return's 10 g, as the template sums raw lines
    });

    it('Party Summ signs the party total by BOOK_INOUT: the purchase return subtracts', async () => {
      const body = await report('mode=party-summary');
      expect(body.template).toBe('AcPurcSummRpt');
      const parties = body.table.lines.filter((l: any) => l._band === 'Party Total :');
      // C1: V1 +20 g, V3 -10 g; C2: V2 +100 g and the zero voucher.
      expect(Number(parties[0].nwt)).toBe(10);
      expect(Number(parties[0].fine)).toBe(round(18.32 - 9.16, 3));
      expect(Number(parties[0].lineNetAmt)).toBe(113836 - 5000);
      expect(Number(parties[1].nwt)).toBe(100);
      expect(body.totals.nwt).toBe(110);
    });

    it('Purchase Bill prints each voucher with its tax split and totals', async () => {
      const body = await report('mode=bill&coBook=PUR&acCode=C1');
      const footer = body.table.lines.find((l: any) => l._kind === 'voucher');
      expect(footer).toMatchObject({ refNo: 'PU-00001', netAmt: '113836.00', totAmt: '117251.08' });
      expect(Number(footer.cgstTax) + Number(footer.sgstTax)).toBe(V1.tax);
    });

    it('never shows another company, location, year, date or tenant', async () => {
      for (const mode of [
        'report',
        'register',
        'item',
        'bill',
        'party',
        'group',
        'party-summary',
      ]) {
        const body = await report(`mode=${mode}`);
        const text = JSON.stringify(body);
        for (const vch of ['Z-CO', 'Z-LC', 'Z-YR', 'Z-DT', 'Z-TN'])
          expect(text, `${mode} ${vch}`).not.toContain(vch);
      }
    });

    it('lists the City and Area values of the company only', async () => {
      const response = await get('printer', '/reports/purchase-report/options');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({ cities: ['MUMBAI', 'SURAT'], areas: ['ADAJAN', 'FORT'] });
    });

    it('refuses a user without the Purchase Rpt right, and exports only with Print', async () => {
      expect(
        (await get('blocked', `/reports/purchase-report?fromDate=${FROM}&toDate=${TO}`)).statusCode,
      ).toBe(403);
      expect((await get('blocked', '/reports/purchase-report/options')).statusCode).toBe(403);
      const q = `fromDate=${FROM}&toDate=${TO}&mode=register`;
      for (const ext of ['csv', 'xlsx', 'pdf'])
        expect(
          (await get('viewer', `/reports/purchase-report/export.${ext}?${q}`)).statusCode,
        ).toBe(403);
      expect((await get('viewer', `/reports/purchase-report?${q}`)).statusCode).toBe(200);
      const csv = await get('printer', `/reports/purchase-report/export.csv?${q}`);
      expect(csv.statusCode, csv.body).toBe(200);
      const rows = csv.body.trim().split('\r\n');
      expect(rows.at(-2)!.split(',')[0]).toBe('GRAND TOTAL :');
      expect(rows.at(-1)).toContain('Voucher totals: Vouchers 4');
      expect(csv.body).toContain(sum(IN_SCOPE, (v) => v.tot).toFixed(2));
      expect((await get('printer', `/reports/purchase-report/export.xlsx?${q}`)).statusCode).toBe(
        200,
      );
      const pdf = await get('printer', `/reports/purchase-report/export.pdf?${q}`);
      expect(pdf.statusCode, pdf.body).toBe(200);
      expect(pdf.headers['content-type']).toBe('application/pdf');
    });

    it('validates input like the desktop: bad date 400, reversed range empty, locked location 409', async () => {
      const bad = await get('printer', `/reports/purchase-report?fromDate=2026-13-01&toDate=${TO}`);
      expect(bad.statusCode).toBe(400);
      expect(bad.json().error).toBe('invalid-date');
      const reversed = await get(
        'printer',
        `/reports/purchase-report?fromDate=${TO}&toDate=${FROM}&mode=register`,
      );
      expect(reversed.statusCode, reversed.body).toBe(200);
      expect(reversed.json().selection.voucherCount).toBe(0);
      const locked = await get(
        'printer',
        `/reports/purchase-report?fromDate=${FROM}&toDate=${TO}&lcCode=02`,
      );
      expect(locked.statusCode).toBe(409);
      const lacks = await get(
        'printer',
        `/reports/purchase-report?fromDate=${FROM}&toDate=${TO}&mode=group&city=SURAT`,
      );
      expect(lacks.statusCode).toBe(400);
      expect(lacks.json().error).toBe('filter-not-in-template');
      const mode = await get('printer', `/reports/purchase-report?mode=nope`);
      expect(mode.statusCode).toBe(400);
      expect(mode.json().error).toBe('invalid-mode');
    });

    it('the date defaults to today when the query carries none', async () => {
      const response = await get('viewer', '/reports/purchase-report?mode=register');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json().filters.fromDate).toBe(response.json().filters.toDate);
    });
  },
);
