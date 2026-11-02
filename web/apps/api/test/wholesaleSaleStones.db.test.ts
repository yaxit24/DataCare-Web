import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * TR_WH_SALE copies the stones of an issued tag onto the voucher: SL_IDTL rows (TR_WH_SALE.cs:12588-12632 reads the
 * tag's BAR_IDTL into the item-detail grid at :10113-10148; the save writes them at :13162-13250 with ENTRY_TYPE 'W',
 * SR_NO the line's serial, ISR_NO 1.. per line), then Dm_Wh_Tour_Sale_Detl (Ac_Stock.cs:857-861; called at
 * TR_WH_SALE.cs:13358) projects them into DM_DATA for an item with OTH_DETL_POSTING = 'Y' on a WH SALES or TOUR SALES
 * book. A row with no pieces, weight, less weight and net amount is not saved (:13190-13194).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'wh-stones-db';
const PASSWORD = 'Wholesale-Stones!2026';
const SECRET = 'wholesale-stones-test-signing-secret-over-thirty-two-chars';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

(enabled ? describe : describe.skip)(
  'Wh Sales copies the issued tag stones (SL_IDTL, DM_DATA)',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    let cookie = '';
    let seq = 0;
    const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
    const rows = (sql: string, ...params: unknown[]) =>
      owner.$queryRawUnsafe<any[]>(sql, tenantId, ...params);
    const wipe = async () => {
      const found: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
        `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
      );
      for (const row of found)
        await owner.$executeRawUnsafe(
          `DELETE FROM "${row.table_name}" WHERE tenant_id=$1`,
          tenantId,
        );
    };
    /** A live gold tag of item `itCode` with two stones (one of them empty, which the desktop does not save). */
    const seedTag = async (itCode: string) => {
      seq += 1;
      const tag = `STN${String(seq).padStart(5, '0')}`;
      const vchSrno = 100312000200 + seq;
      await exec(
        `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","BOOK_NAME",
         "INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE","TBL_CODE","EMP_ISU")
       VALUES ($1,'01','01',$2,'PR','0010${seq}',1,$3::date,'PURCHASE','I',$4,$5,$6,1,10,9.5,91.6,8.702,'001','N')`,
        tenantId,
        YEAR,
        DAY,
        tag,
        vchSrno,
        itCode,
      );
      await exec(
        `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE",
         "IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,'01','01',$2,'PR','0010${seq}',2,1,$3::date,$4,$5,$6,'P','+',1,1,10,9.5)`,
        tenantId,
        YEAR,
        DAY,
        itCode,
        tag,
        vchSrno,
      );
      const stone = (isr: number, dm: string, pcs: number, wt: number, rate: number, amt: number) =>
        exec(
          `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","TAG_NO","VCH_SRNO",
           "IT_CODE","IT_TYPE","DM_CODE","DM_NAME","DM_COLOR","DM_SIZE","DM_ORIGIN","DM_REMARK","DM_SFNO","IT_PCS","IT_GWT",
           "IT_RATE_TYPE","IT_RATE","IT_AMT","IT_LBR_RATE","IT_LBR_AMT","IT_NET_AMT","KR_WT")
         VALUES ($1,'01','01',$2,'PR','0010${seq}',1,$3,$4,$5,$6,'G',$7,$8,'WHITE','1.5','NATURAL','R1','S1',$9,$10,'C',$11,$12,0,0,$12,$10)`,
          tenantId,
          YEAR,
          isr,
          tag,
          vchSrno,
          itCode,
          dm,
          `${dm} STONE`,
          pcs,
          wt,
          rate,
          amt,
        );
      await stone(1, 'DIA01', 3, 0.3, 20000, 6000);
      await stone(2, 'ZER00', 0, 0, 0, 0);
      await stone(3, 'CZ02', 5, 0.5, 100, 500);
      return { tag, vchSrno };
    };
    const sell = (tag: string, coBook = 'WHS', extra: Record<string, unknown> = {}) => ({
      coBook,
      vchDate: DAY,
      acCode: 'WHCUST',
      itType: 'G',
      lines: [{ tagNo: tag }],
      fineRate: 6500,
      settleCrFine: 8.702,
      pay: { cash: 56563 },
      ...extra,
    });
    const inject = (method: 'POST' | 'PUT' | 'DELETE', url: string, payload?: unknown) =>
      app.inject({ method, url, headers: { cookie }, payload: payload as any });
    const idtl = (vchNo: string) =>
      rows(
        `SELECT "SR_NO"::int sr,"ISR_NO"::int isr,"ENTRY_TYPE" et,"TAG_NO" tag,"VCH_SRNO"::float8 srno,"IT_CODE" it,
              "DM_CODE" dm,"DM_NAME" dmn,"DM_COLOR" col,"DM_SIZE" size,"DM_ORIGIN" ori,"DM_REMARK" rem,"DM_SFNO" sf,
              "IT_PCS"::float8 pcs,"IT_GWT"::float8 gwt,"IT_RATE_TYPE" rt,"IT_RATE"::float8 rate,"IT_AMT"::float8 amt,
              "IT_NET_AMT"::float8 net,"VCH_TYPE" vt,"INOUT_TYPE" io,"BOOK_NAME" bn,"AC_CODE" ac
         FROM "SL_IDTL" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO","ISR_NO"`,
        vchNo,
      );
    const dm = (vchNo: string) =>
      rows(
        `SELECT "MAIN_SRNO"::int ms,"SR_NO"::int sr,"ISR_NO"::int isr,"ENTRY_TYPE" et,"BOOK_NAME" bn,"IT_CODE" it,
              "MAIN_IT_CODE" mit,"DM_CODE" dm,"DM_PCS"::float8 pcs,"DM_WT"::float8 wt,"DM_SIGN" sign,"DM_RATE"::float8 rate,
              "DM_AMT"::float8 amt,"TAG_NO" tag,"VCH_SRNO"::float8 srno,"INOUT_TYPE" io,"TBL_CODE" tbl
         FROM "DM_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO","ISR_NO"`,
        vchNo,
      );

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','WHCUST','Wholesale Customer','10')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE","OTH_DETL_POSTING")
       VALUES ($1,'01','DST','STUDDED RING','G','LR','G','Y'),($1,'01','PLN','PLAIN RING','G','LR','G','N')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01','wholesaler',$2,'ADMIN','Y','Y','Y','N')`,
        tenantId,
        await hashPassword(PASSWORD),
      );
      app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: {
          coCode: '01',
          lcCode: '01',
          coYear: YEAR,
          loginName: 'wholesaler',
          password: PASSWORD,
        },
      });
      expect(response.statusCode, response.body).toBe(200);
      const value = response.headers['set-cookie'];
      cookie = (Array.isArray(value) ? value : [value ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    });
    afterAll(async () => {
      if (app) await app.close();
      if (owner) await wipe();
      if (runtime) await runtime.$disconnect();
      if (owner) await owner.$disconnect();
    });

    it('writes the tag stones to SL_IDTL and, for an OTH_DETL_POSTING item, to DM_DATA; the empty stone is skipped', async () => {
      const t = await seedTag('DST');
      const created = await inject('POST', '/wholesale-sales', sell(t.tag));
      expect(created.statusCode, created.body).toBe(201);
      const vchNo = String(created.json().vchNo).padStart(5, '0');
      const written = await idtl(vchNo);
      expect(written).toEqual([
        expect.objectContaining({
          sr: 1,
          isr: 1,
          et: 'W',
          tag: t.tag,
          srno: t.vchSrno,
          it: 'DST',
          dm: 'DIA01',
          dmn: 'DIA01 STONE',
          col: 'WHITE',
          size: '1.5',
          ori: 'NATURAL',
          rem: 'R1',
          sf: 'S1',
          pcs: 3,
          gwt: 0.3,
          rt: 'C',
          rate: 20000,
          amt: 6000,
          net: 6000,
          ac: 'WHCUST',
        }),
        expect.objectContaining({ sr: 1, isr: 2, dm: 'CZ02', pcs: 5, gwt: 0.5, amt: 500 }),
      ]);
      expect(await dm(vchNo)).toEqual([
        expect.objectContaining({
          ms: 1,
          sr: 1,
          isr: 1,
          et: 'S',
          it: 'DST',
          mit: 'DST',
          dm: 'DIA01',
          pcs: 3,
          wt: 0.3,
          sign: '-',
          rate: 20000,
          amt: 6000,
          tag: t.tag,
          srno: t.vchSrno,
          io: 'S',
          tbl: '001',
        }),
        expect.objectContaining({ sr: 1, isr: 2, dm: 'CZ02', pcs: 5, wt: 0.5, sign: '-' }),
      ]);
    });

    it('an item without OTH_DETL_POSTING keeps the SL_IDTL rows and writes no DM_DATA', async () => {
      const t = await seedTag('PLN');
      const created = await inject('POST', '/wholesale-sales', sell(t.tag));
      expect(created.statusCode, created.body).toBe(201);
      const vchNo = String(created.json().vchNo).padStart(5, '0');
      expect((await idtl(vchNo)).map((r) => r.dm)).toEqual(['DIA01', 'CZ02']);
      expect(await dm(vchNo)).toEqual([]);
    });

    it('an edit rewrites the same rows once and a delete removes them', async () => {
      const t = await seedTag('DST');
      const created = await inject('POST', '/wholesale-sales', sell(t.tag));
      expect(created.statusCode, created.body).toBe(201);
      const vchNo = String(created.json().vchNo).padStart(5, '0');
      const before = [await idtl(vchNo), await dm(vchNo)];
      const edited = await inject(
        'PUT',
        `/wholesale-sales/${vchNo}`,
        sell(t.tag, 'WHS', { vchDesc: 'edited' }),
      );
      expect(edited.statusCode, edited.body).toBe(200);
      expect([await idtl(vchNo), await dm(vchNo)]).toEqual(before);
      const deleted = await inject('DELETE', `/wholesale-sales/${vchNo}`, { book: 'WHS' });
      expect(deleted.statusCode, deleted.body).toBe(200);
      expect(await idtl(vchNo)).toEqual([]);
      expect(await dm(vchNo)).toEqual([]);
    });
  },
);
