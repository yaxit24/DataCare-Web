import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N225 / G237: Tag Print (desktop UT_TAG_PRINT, opened by MDI_FORM.cs:8596-8605) through the real Fastify routes on a
 * forced-RLS database. Expected values come from the desktop source:
 *
 * - Load (UT_TAG_PRINT.cs:4735-5013): the label files of PRINT_MAST of type TAG (QR with QR_CODE_GEN), the one marked
 *   PRINT_SET_A 'Y' selected; the item type is Gold unless CO_MAST.METAL_TYPE says Silver.
 * - A voucher fills the grid with its tags by SR_NO (tVchNo_KeyDown :5284-5403); the stock fills it with the in-stock tags
 *   by item and tag, filtered by product, group and item type (MSG_VCH_FILL :5575-5635); a tag typed in the TagNo column
 *   is found in the stock (:4102-4420).
 * - BtnPrint_Click (:5122-5226) needs the print right, clears TAG_PRINT_DATA, writes the label-skip rows (SR_NO 1..n,
 *   VCH_NO 00000, IT_CODE '00') and copies the BAR_DETL row of every Y row; BtnSave_Click (:5073-5096) writes the HM ids,
 *   Lbr% , Mrp and LRate back to BAR_DETL; BtnTagSet_Click (:5636-5655) marks the chosen label file PRINT_SET_A 'Y'.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'tag-print-db';
const otherTenant = 'tag-print-db-other';
const PASSWORD = 'Tag-Print-Routes!2026';
const SECRET = 'tag-print-routes-test-signing-secret-over-thirty';
const ADMIN = 'tpadmin';
const CLERK = 'tpclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const API = '/stock/tag-print-screen';

type Cookie = string;

(enabled ? describe : describe.skip)(
  'N225 Tag Print is the desktop UT_TAG_PRINT through HTTP',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    let adminCookie: Cookie;
    let clerkCookie: Cookie;

    const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
    const query = <T>(sql: string, ...params: unknown[]) =>
      owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
    const request = (cookie: Cookie, method: string, url: string, payload?: unknown) =>
      app.inject({
        method: method as never,
        url,
        headers: { cookie },
        ...(payload === undefined ? {} : { payload: payload as never }),
      });
    const wipe = async () => {
      const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
        `SELECT DISTINCT table_name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id'`,
      );
      for (const { table_name } of tables)
        await owner.$executeRawUnsafe(
          `DELETE FROM "${table_name}" WHERE tenant_id IN ($1,$2)`,
          tenantId,
          otherTenant,
        );
    };
    const login = async (user: string): Promise<Cookie> => {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: user, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const setCookie = response.headers['set-cookie'];
      return (Array.isArray(setCookie) ? setCookie : [setCookie ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    };
    /** A tag: its BAR_DETL row and the MAIN_STOCK '+' row of its voucher serial (Tag Opening's write). */
    const tag = async (
      t: string,
      srno: number,
      over: Record<string, string | number | null> = {},
      stock = true,
    ) => {
      const row: Record<string, string | number | null> = {
        CO_BOOK: 'TOP',
        VCH_NO: '00001',
        SR_NO: srno,
        IT_CODE: 'GR22',
        TAG_NO: t,
        VCH_SRNO: srno,
        DESIGN_NO: `D-${t}`,
        TBL_CODE: 'C1',
        ITM_PCS: 1,
        ITM_GWT: 10.5,
        ITM_NWT: 10,
        ITM_TOUCH: 91.6,
        ITM_MRP: 55000,
        LBR_PRC: 8,
        STK_DATE: '2026-04-02',
        ...over,
      };
      await exec(
        `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","TAG_NO","VCH_SRNO",
         "DESIGN_NO","TBL_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_MRP","LBR_PRC","STK_DATE","VCH_TIME")
       VALUES ($1,'01','01',$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,$13,$14,$15,$16,$17,now() - interval '1 minute' * $18::int)`,
        tenantId,
        YEAR,
        row.CO_BOOK,
        row.VCH_NO,
        row.SR_NO,
        row.IT_CODE,
        row.TAG_NO,
        row.VCH_SRNO,
        row.DESIGN_NO,
        row.TBL_CODE,
        row.ITM_PCS,
        row.ITM_GWT,
        row.ITM_NWT,
        row.ITM_TOUCH,
        row.ITM_MRP,
        row.LBR_PRC,
        row.STK_DATE,
        Number(row.SR_NO),
      );
      if (stock)
        await exec(
          `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN","ITM_GWT","ITM_NWT")
         VALUES ($1,'01','01',$2,$3,$4,$5,$6,$7,'+',$8,$9)`,
          tenantId,
          YEAR,
          row.CO_BOOK,
          row.VCH_NO,
          row.IT_CODE,
          row.TAG_NO,
          row.VCH_SRNO,
          row.ITM_GWT,
          row.ITM_NWT,
        );
    };
    const staged = () =>
      query<any[]>(
        `SELECT "SR_NO","IT_CODE","TAG_NO","VCH_NO","CO_BOOK","VCH_SRNO","ITM_MRP"::float mrp FROM "TAG_PRINT_DATA"
        WHERE tenant_id=$1 ORDER BY row_id`,
        tenantId,
      );

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      await exec(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE") VALUES
         ($1,'01','G22','GOLD 22K','G'),($1,'01','S92','SILVER 92','S')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES ($1,'01','RN','RING'),($1,'01','CH','CHAIN')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","PR_CODE") VALUES
         ($1,'01','GR22','GOLD RING 22K','G','G22','RN'),
         ($1,'01','GC22','GOLD CHAIN 22K','G','G22','CH'),
         ($1,'01','SR92','SILVER RING','S','S92','RN')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "PRINT_MAST"(tenant_id,"CO_CODE","PRINT_TYPE","PRINT_FILE","PRINT_SET_A") VALUES
         ($1,'01','TAG','TagSmall','N'),($1,'01','TAG','TagBig','Y'),($1,'01','QR','QrOnly','Y'),($1,'01','TAG','TagAlpha','N')`,
        tenantId,
      );
      await exec(
        `UPDATE "CO_MAST" SET "METAL_TYPE"='S' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        tenantId,
      );
      // Stock: two gold rings (one more recent), a gold chain, a silver ring, a sold ring and a future-dated chain.
      await tag('R001', 1);
      await tag('R002', 2, { DESIGN_NO: 'D-NEW' });
      await tag('C001', 3, { IT_CODE: 'GC22', TBL_CODE: 'C2' });
      await tag('S001', 4, { IT_CODE: 'SR92', ITM_TOUCH: 92.5 });
      await tag('X001', 5);
      await exec(
        `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN")
       VALUES ($1,'01','01',$2,'SL','00001','GR22','X001',5,'-')`,
        tenantId,
        YEAR,
      );
      await tag('F001', 6, { IT_CODE: 'GC22', STK_DATE: '2999-01-01' });
      await tag('N001', 7, {}, false);
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,'01','01','P1','TAG PARTY')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","TAG_NO","VCH_SRNO","AC_CODE","VCH_DATE")
       VALUES ($1,'01','02',$2,'TOP','00001',1,'GR22','OTHERLOC',1,'P1',now())`,
        tenantId,
        YEAR,
      );
      await exec(
        `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","TAG_NO","VCH_SRNO")
       VALUES ($1,'01','01',$2,'TOP','00001',1,'GR22','SENTINEL',1)`,
        otherTenant,
        YEAR,
      );
      const passwordHash = await hashPassword(PASSWORD);
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01',$2,$4,'ADMIN','Y','Y','Y','N'),($1,'01',$3,$4,'USER','Y','N','N','N')`,
        tenantId,
        ADMIN,
        CLERK,
        passwordHash,
      );
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES ($1,'01','01',$2,'Other','Tag Print','Y','N','N','N')`,
        tenantId,
        CLERK,
      );
      app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
      adminCookie = await login(ADMIN);
      clerkCookie = await login(CLERK);
    });

    afterAll(async () => {
      if (app) await app.close();
      if (owner) await wipe();
      if (runtime) await runtime.$disconnect();
      if (owner) await owner.$disconnect();
    });

    it('loads the label files, the default file, the item type and the rights', async () => {
      const response = await request(adminCookie, 'GET', API);
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toMatchObject({
        files: ['TagAlpha', 'TagBig', 'TagSmall'],
        defaultFile: 'TagBig',
        qr: false,
        itemType: 'Silver',
        itemTypes: ['Gold', 'Silver', 'Diamond', 'Real Stone', 'Emitation', 'Other', 'Platinum'],
        rights: { canUpdate: true, canDelete: true, canPrint: true },
      });
      await exec(
        `UPDATE "CO_MAST" SET "METAL_TYPE"='' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        tenantId,
      );
      expect((await request(adminCookie, 'GET', API)).json().itemType).toBe('Gold');
      await exec(
        `UPDATE "CO_MAST" SET "METAL_TYPE"='S' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        tenantId,
      );
    });

    it('lists the in-stock tags by item and tag, with filters, and leaves sold, future and other-location tags out', async () => {
      let response = await request(adminCookie, 'GET', `${API}/stock`);
      expect(response.statusCode, response.body).toBe(200);
      const rows = response.json().rows as Array<{ tagNo: string; itCode: string; itName: string }>;
      expect(rows.map((r) => r.tagNo)).toEqual(['C001', 'R001', 'R002', 'S001']);
      expect(rows[0]).toMatchObject({
        itName: 'GOLD CHAIN 22K',
        counter: 'C2',
        grossWt: '10.500',
        netWt: '10.000',
        touch: '91.60',
        mrp: '55000.00',
        lbrPrc: '8.00',
        vchSrno: 3,
      });
      response = await request(adminCookie, 'GET', `${API}/stock?itemType=Silver`);
      expect(response.json().rows.map((r: { tagNo: string }) => r.tagNo)).toEqual(['S001']);
      response = await request(adminCookie, 'GET', `${API}/stock?product=rn`);
      expect(response.json().rows.map((r: { tagNo: string }) => r.tagNo)).toEqual([
        'R001',
        'R002',
        'S001',
      ]);
      response = await request(adminCookie, 'GET', `${API}/stock?group=G22&product=RN`);
      expect(response.json().rows.map((r: { tagNo: string }) => r.tagNo)).toEqual(['R001', 'R002']);
      response = await request(adminCookie, 'GET', `${API}/stock?group=ZZZ`);
      expect(response.json().rows).toEqual([]);
    });

    it('finds a typed tag, lists the tag help and the group and product helps', async () => {
      let response = await request(adminCookie, 'GET', `${API}/tag?tagNo=r002`);
      expect(response.json().row).toMatchObject({ tagNo: 'R002', design: 'D-NEW', itCode: 'GR22' });
      for (const gone of ['X001', 'N001', 'OTHERLOC', 'NOPE']) {
        response = await request(adminCookie, 'GET', `${API}/tag?tagNo=${gone}`);
        expect(response.json().row, gone).toBeNull();
      }
      response = await request(adminCookie, 'GET', `${API}/tags`);
      expect(response.json().rows.map((r: { tagNo: string }) => r.tagNo)).toEqual([
        'C001',
        'F001',
        'R001',
        'R002',
        'S001',
      ]);
      response = await request(adminCookie, 'GET', `${API}/lookups/groups`);
      expect(response.json().rows.map((r: { code: string }) => r.code)).toEqual(['G22', 'S92']);
      response = await request(adminCookie, 'GET', `${API}/lookups/products`);
      expect(response.json().rows).toEqual([
        { name: 'CHAIN', code: 'CH' },
        { name: 'RING', code: 'RN' },
      ]);
      expect((await request(adminCookie, 'GET', `${API}/lookups/colours`)).statusCode).toBe(400);
    });

    it('reads a book, its vouchers and a voucher by SR_NO, and a Tag Cancel book through BAR_CAN_DETL', async () => {
      let response = await request(adminCookie, 'GET', `${API}/book?code=top`);
      expect(response.json().book).toMatchObject({ code: 'TOP', cancelFamily: false });
      response = await request(adminCookie, 'GET', `${API}/book?code=TGC`);
      expect(response.json().book).toMatchObject({ code: 'TGC', cancelFamily: true });
      expect((await request(adminCookie, 'GET', `${API}/book?code=NOPE`)).json().book).toBeNull();
      response = await request(adminCookie, 'GET', `${API}/books`);
      expect(response.json().rows.map((r: { code: string }) => r.code)).toEqual(['TOP']);
      response = await request(adminCookie, 'GET', `${API}/vouchers?bookCode=TOP`);
      expect(response.json().rows).toEqual([
        { vchNo: '00001', vchDate: expect.any(String), party: expect.any(String) },
      ]);
      response = await request(adminCookie, 'GET', `${API}/voucher?bookCode=TOP&vchNo=00001`);
      expect(response.json().rows.map((r: { tagNo: string }) => r.tagNo)).toEqual([
        'R001',
        'R002',
        'C001',
        'S001',
        'X001',
        'F001',
        'N001',
      ]);
      // A voucher of the Tag Cancel family reads BAR_CAN_DETL joined to BAR_DETL (:5309).
      await exec(
        `INSERT INTO "BAR_CAN_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","TAG_NO","VCH_SRNO")
       VALUES ($1,'01','01',$2,'TGC','00001',1,'GR22','R002',2)`,
        tenantId,
        YEAR,
      );
      response = await request(adminCookie, 'GET', `${API}/voucher?bookCode=TGC&vchNo=00001`);
      expect(response.json().rows).toHaveLength(1);
      expect(response.json().rows[0]).toMatchObject({ tagNo: 'R002', design: 'D-NEW' });
      response = await request(adminCookie, 'GET', `${API}/vouchers?bookCode=TGC`);
      expect(response.json().rows.map((r: { vchNo: string }) => r.vchNo)).toEqual(['00001']);
    });

    it('prints: needs the print right, clears the staging, writes the skip rows and copies each Y row', async () => {
      await exec(
        `INSERT INTO "TAG_PRINT_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE") VALUES ($1,'01','01',$2,'OLD','99999',1,'OLD')`,
        tenantId,
        YEAR,
      );
      let response = await request(clerkCookie, 'POST', `${API}/print`, {
        bookCode: 'TOP',
        labelSkip: 2,
        tags: [{ tagNo: 'R001', vchSrno: 1 }],
      });
      expect(response.statusCode).toBe(403);
      expect((await request(clerkCookie, 'GET', `${API}/labels`)).statusCode).toBe(403);
      expect((await staged()).map((r) => r.IT_CODE)).toEqual(['OLD']);
      response = await request(adminCookie, 'POST', `${API}/print`, {
        bookCode: 'top',
        labelSkip: '2.5',
        tags: [
          { tagNo: 'r002', vchSrno: 2 },
          { tagNo: 'C001', vchSrno: 3 },
        ],
      });
      expect(response.statusCode, response.body).toBe(200);
      // Math.Round(2.5) is 2 (banker's).
      expect(response.json()).toEqual({ skipped: 2, staged: 2 });
      expect(await staged()).toEqual([
        {
          SR_NO: 1,
          IT_CODE: '00',
          TAG_NO: '',
          VCH_NO: '00000',
          CO_BOOK: 'TOP',
          VCH_SRNO: 0,
          mrp: 0,
        },
        {
          SR_NO: 2,
          IT_CODE: '00',
          TAG_NO: '',
          VCH_NO: '00000',
          CO_BOOK: 'TOP',
          VCH_SRNO: 0,
          mrp: 0,
        },
        {
          SR_NO: 2,
          IT_CODE: 'GR22',
          TAG_NO: 'R002',
          VCH_NO: '00001',
          CO_BOOK: 'TOP',
          VCH_SRNO: 2,
          mrp: 55000,
        },
        {
          SR_NO: 3,
          IT_CODE: 'GC22',
          TAG_NO: 'C001',
          VCH_NO: '00001',
          CO_BOOK: 'TOP',
          VCH_SRNO: 3,
          mrp: 55000,
        },
      ]);
      response = await request(adminCookie, 'GET', `${API}/labels`);
      expect(response.statusCode).toBe(200);
      expect(response.headers['content-type']).toContain('text/html');
      expect((response.body.match(/class="lbl blank"/g) ?? []).length).toBe(2);
      expect(response.body).toContain('R002');
      expect(response.body).toContain('C001');
      expect(response.body).not.toContain('R001');
      // Nothing marked Y and no skip: refused, and the staging is left alone.
      response = await request(adminCookie, 'POST', `${API}/print`, { bookCode: 'TOP', tags: [] });
      expect(response.statusCode).toBe(400);
      expect((await staged()).length).toBe(4);
      response = await request(adminCookie, 'POST', `${API}/print`, {
        bookCode: 'TOP',
        labelSkip: 501,
        tags: [],
      });
      expect(response.statusCode).toBe(400);
    });

    it("the staging is the tenant's own: another tenant's tags are never copied or cleared", async () => {
      await request(adminCookie, 'POST', `${API}/print`, {
        bookCode: 'TOP',
        tags: [{ tagNo: 'SENTINEL', vchSrno: 1 }],
      });
      expect((await staged()).length).toBe(0);
      const other = await query<Array<{ n: number }>>(
        `SELECT count(*)::int n FROM "BAR_DETL" WHERE tenant_id=$1`,
        otherTenant,
      );
      expect(other[0]!.n).toBe(1);
    });

    it('Hm Id Update writes the HM ids, weights, Lbr%, Mrp and LRate of rows that qualify, behind the edit right', async () => {
      const before = await query<any[]>(
        `SELECT "TAG_NO","HM_ID","LBR_PRC"::float lbr,"ITM_MRP"::float mrp FROM "BAR_DETL" WHERE tenant_id=$1 ORDER BY row_id`,
        tenantId,
      );
      let response = await request(clerkCookie, 'POST', `${API}/hm-update`, { rows: [] });
      // The clerk's USER_SET row has FRM_EDIT N.
      expect(response.statusCode).toBe(403);
      response = await request(adminCookie, 'POST', `${API}/hm-update`, {
        rows: [
          {
            tagNo: 'R001',
            vchSrno: 1,
            hmIds: ['ab1234', '', '', ''],
            hmWts: ['0.5', '0', '0', '0'],
            lbrPrc: '9',
            mrp: '56000',
            lbrRate: '120',
          },
          // No HM id and Lbr% + Mrp are zero: not written (:5085).
          { tagNo: 'R002', vchSrno: 2, hmIds: ['', '', '', ''], lbrPrc: '0', mrp: '0' },
          // No HM id but a Mrp: written.
          {
            tagNo: 'C001',
            vchSrno: 3,
            hmIds: ['', '', '', ''],
            lbrPrc: '7',
            mrp: '61000',
            lbrRate: '0',
          },
          { tagNo: '', vchSrno: 0, hmIds: ['ZZ'], lbrPrc: '1', mrp: '1' },
        ],
      });
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({ updated: 2 });
      const after = await query<any[]>(
        `SELECT "TAG_NO","HM_ID","HM_ID_WT"::float w,"LBR_PRC"::float lbr,"ITM_MRP"::float mrp,"LBR_RATE"::float rate FROM "BAR_DETL"
        WHERE tenant_id=$1 AND "TAG_NO" IN ('R001','R002','C001') ORDER BY "TAG_NO"`,
        tenantId,
      );
      expect(after).toEqual([
        { TAG_NO: 'C001', HM_ID: '', w: 0, lbr: 7, mrp: 61000, rate: 0 },
        { TAG_NO: 'R001', HM_ID: 'AB1234', w: 0.5, lbr: 9, mrp: 56000, rate: 120 },
        { TAG_NO: 'R002', HM_ID: null, w: null, lbr: 8, mrp: 55000, rate: null },
      ]);
      expect(before.length).toBeGreaterThan(0);
      response = await request(adminCookie, 'POST', `${API}/hm-update`, {
        rows: [{ tagNo: 'R001', vchSrno: 1, hmIds: ['ELEVENCHARS'] }],
      });
      expect(response.statusCode).toBe(400);
    });

    it('Set marks the chosen file PRINT_SET_A Y and the others N, and refuses an unknown file', async () => {
      let response = await request(adminCookie, 'POST', `${API}/default-file`, {
        file: 'TagSmall',
      });
      expect(response.json()).toEqual({ defaultFile: 'TagSmall' });
      const rows = await query<any[]>(
        `SELECT "PRINT_TYPE","PRINT_FILE","PRINT_SET_A" FROM "PRINT_MAST" WHERE tenant_id=$1 ORDER BY "PRINT_TYPE","PRINT_FILE"`,
        tenantId,
      );
      expect(rows.map((r) => `${r.PRINT_TYPE}/${r.PRINT_FILE}/${r.PRINT_SET_A}`)).toEqual([
        'QR/QrOnly/Y',
        'TAG/TagAlpha/N',
        'TAG/TagBig/N',
        'TAG/TagSmall/Y',
      ]);
      expect((await request(adminCookie, 'GET', API)).json().defaultFile).toBe('TagSmall');
      response = await request(adminCookie, 'POST', `${API}/default-file`, { file: 'Nope' });
      expect(response.statusCode).toBe(400);
      response = await request(adminCookie, 'POST', `${API}/default-file`, { file: '' });
      expect(response.statusCode).toBe(400);
    });

    it("follows the clerk's rights row: reads yes, print no", async () => {
      const list = await request(clerkCookie, 'GET', API);
      expect(list.statusCode, list.body).toBe(200);
      expect(list.json().rights).toEqual({ canUpdate: false, canDelete: false, canPrint: false });
      expect((await request(clerkCookie, 'GET', `${API}/stock`)).statusCode).toBe(200);
      expect((await request(clerkCookie, 'GET', `${API}/labels`)).statusCode).toBe(403);
    });
  },
);
