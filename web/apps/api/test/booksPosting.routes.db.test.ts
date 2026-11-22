import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N240 / G252, T18 and the provisioning half of WP-21: a book created on the Books screen (MS_BOOK) is the book the
 * vouchers post through. Each journey creates a book with marker accounts in its slots through
 * POST /masters/books-master, posts a voucher on it through the voucher's own route, and reads AC_DATA: the legs must
 * land on the configured accounts and never on the provisioned defaults. The slot roles are the web posting readers'
 * (sales.ts / purchase.ts slot 1 control, 2 cash, 3 round-off and kasar; finance.ts slot 1 settlement, 2 kasar), which
 * cases.md records as the assumption to confirm against the desktop baseline.
 *
 * Provisioning (gaps 7 to 11): web-provisioned books carry the desktop template slots where the MS_UPDATE.cs templates
 * add them (OTH INC/OTH EXP 2 and 3, TAG SPLIT 1 to 9 with the gold/silver sale and purchase roles, PURCHASE and TAG
 * PURCHASE 5, LABOUR WORK 8 to 11), Data Type 'A' (MS_BOOK.cs:2630, :2667) and the account's name in AC_NAME.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'books-posting-db';
const PASSWORD = 'Books-Posting-Routes!2026';
const SECRET = 'books-posting-routes-test-signing-secret-over-thirty';
const ADMIN = 'bkpost';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const API = '/masters/books-master';
const M = ['90001', '90002', '90003', '90004', '90005'] as const;
/** The accounts web provisioning puts in the slots; a journey's legs must never land on them. */
const PROVISIONED = ['CASH', 'BANK', 'ROUNDOFF', 'KASAR', 'SALES', 'PURCHASE', 'LBREXP', 'ORDADV'];

interface Leg {
  ac: string;
  ld: string;
  dr: number;
  cr: number;
}

(enabled ? describe : describe.skip)(
  'N240 books created on the Books screen post their vouchers',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    let cookie = '';
    const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
    const query = <T>(sql: string, ...params: unknown[]) =>
      owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
    const send = (method: 'GET' | 'POST' | 'PUT' | 'DELETE', url: string, payload?: unknown) =>
      app.inject({
        method,
        url,
        headers: { cookie },
        ...(payload === undefined ? {} : { payload: payload as any }),
      });
    const wipe = async () => {
      const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
        `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
      );
      for (const row of rows)
        await owner.$executeRawUnsafe(
          `DELETE FROM "${row.table_name}" WHERE tenant_id=$1`,
          tenantId,
        );
    };
    const legs = (book: string, vchNo?: string) =>
      query<Leg[]>(
        `SELECT "AC_CODE" ac,coalesce("LD_CODE",'') ld,coalesce("DR_AMT",0)::float8 dr,coalesce("CR_AMT",0)::float8 cr
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND ($3::text IS NULL OR "VCH_NO"=$3)
        ORDER BY "VCH_NO","LEDR_KEY",row_id`,
        tenantId,
        book,
        vchNo ?? null,
      );
    const balanced = (rows: Leg[]) => {
      const dr = rows.reduce((sum, row) => sum + row.dr, 0);
      const cr = rows.reduce((sum, row) => sum + row.cr, 0);
      expect(Math.round(dr * 100)).toBe(Math.round(cr * 100));
    };
    const noProvisioned = (rows: Leg[]) =>
      expect(
        rows.filter(
          (row) => PROVISIONED.includes(row.ac) && row.ac !== 'SALES' && row.ac !== 'PURCHASE',
        ),
      ).toEqual([]);
    const createBook = async (
      code: string,
      family: string,
      inout: 'I' | 'O',
      slots: Array<[number, string]>,
    ) => {
      const response = await send('POST', API, {
        code,
        name: `Journey ${code}`,
        short: code,
        curUse: 'Y',
        family,
        itemType: 'A',
        inout,
        bookType: 'F',
        slots: slots.map(([srNo, acCode]) => ({ srNo, acCode })),
      });
      expect(response.statusCode, response.body).toBe(201);
    };
    const created = (response: { statusCode: number; body: string; json: () => any }) => {
      expect(response.statusCode, response.body).toBe(201);
      return String(response.json().vchNo).padStart(5, '0');
    };
    const goldLine = {
      itCode: 'GOLD',
      pcs: 1,
      grossWt: 10,
      netWt: 10,
      touch: 100,
      metalAmount: 1000,
    };
    const sale = (coBook: string, extra: Record<string, unknown> = {}) =>
      send('POST', '/sales', {
        coBook,
        acCode: 'CUSL',
        vchDate: DAY,
        taxRatePct: 0,
        interState: false,
        lines: [goldLine],
        cashAmt: 995,
        kasarAmount: 5,
        ...extra,
      });

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      await exec(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
       VALUES ($1,'01','01','GOLD JEWELLERY','SALES','PURCHASE')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,'01','GOLD','GOLD ORNAMENT','G','01')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR")
       VALUES ($1,'01','01','CUSL','Local Customer','L','10'),($1,'01','01','SUPL','Local Supplier','L','40'),
              ($1,'01','01','PTY','Receipt Party','L','10'),
              ($1,'01','01','90001','MARKER ONE',NULL,'01'),($1,'01','01','90002','MARKER TWO',NULL,'01'),
              ($1,'01','01','90003','MARKER THREE',NULL,'31'),($1,'01','01','90004','MARKER FOUR',NULL,'02'),
              ($1,'01','01','90005','MARKER FIVE',NULL,'02')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'ADMIN','Y','Y','Y','N')`,
        tenantId,
        ADMIN,
        await hashPassword(PASSWORD),
      );
      app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
      const login = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: ADMIN, password: PASSWORD },
      });
      expect(login.statusCode, login.body).toBe(200);
      const value = login.headers['set-cookie'];
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

    it('provisioning gives the template slots the web seed missed (gaps 7, 8, 9, 11)', async () => {
      const slots = await query<Array<{ book: string; sr: number; ac: string }>>(
        `SELECT "CO_BOOK" book,"SR_NO"::int sr,"AC_CODE" ac FROM "BOOK_DETL"
        WHERE tenant_id=$1 AND "CO_BOOK" IN ('OIN','OEX','TSP','PR','TPR','LBR') ORDER BY 1,2`,
        tenantId,
      );
      const of = (book: string) =>
        slots.filter((row) => row.book === book).map((row) => [row.sr, row.ac]);
      // OTH INC / OTH EXP: cash 2 and kasar 3 (MS_UPDATE.cs:22860-22892); slot 1 is the provisioned account.
      expect(of('OIN')).toEqual([
        [1, 'INTINC'],
        [2, 'CASH'],
        [3, 'KASAR'],
      ]);
      expect(of('OEX')).toEqual([
        [1, 'OTHCHRG'],
        [2, 'CASH'],
        [3, 'KASAR'],
      ]);
      // TAG SPLIT 1 to 9 (MS_UPDATE.cs:32078-32110): 6 gold sale, 7 gold purchase, 8 silver sale, 9 silver purchase.
      expect(of('TSP')).toEqual([
        [1, 'CASH'],
        [2, 'KASAR'],
        [3, 'KASAR'],
        [4, 'LBRINC'],
        [5, 'LBREXP'],
        [6, 'SALES'],
        [7, 'PURCHASE'],
        [8, 'SLVSALE'],
        [9, 'SLVPURC'],
      ]);
      // PURCHASE / TAG PURCHASE 5 discount (MS_UPDATE.cs:25022, :30221).
      for (const book of ['PR', 'TPR'])
        expect(of(book)).toEqual([
          [1, 'PURCHASE'],
          [2, 'CASH'],
          [3, 'ROUNDOFF'],
          [4, 'LBREXP'],
          [5, 'DISCOUNT'],
        ]);
      // LABOUR WORK 8 to 11 (MS_UPDATE.cs:23749-23761).
      expect(of('LBR')).toEqual([
        [1, 'LBRINC'],
        [6, 'LBRINC'],
        [8, 'SLVSALE'],
        [9, 'SLVPURC'],
        [10, 'OG'],
        [11, 'OS'],
      ]);
      // Data Type A and the account's name (gap 11).
      const wrong = await query<unknown[]>(
        `SELECT d."CO_BOOK",d."SR_NO",d."DATA_TYPE",d."AC_NAME",a."AC_NAME" master FROM "BOOK_DETL" d
         LEFT JOIN "AC_MAST" a ON a.tenant_id=d.tenant_id AND a."CO_CODE"=d."CO_CODE" AND a."AC_CODE"=d."AC_CODE"
        WHERE d.tenant_id=$1 AND (d."DATA_TYPE" IS DISTINCT FROM 'A' OR d."AC_NAME" IS DISTINCT FROM a."AC_NAME")`,
        tenantId,
      );
      expect(wrong).toEqual([]);
      const headers = await query<Array<{ n: number }>>(
        `SELECT count(*)::int n FROM "BOOK_DATA" WHERE tenant_id=$1 AND "DATA_TYPE" IS DISTINCT FROM 'A'`,
        tenantId,
      );
      expect(headers).toEqual([{ n: 0 }]);
    });

    it('T08 provisioned books reopen and save unchanged with the same slots', async () => {
      for (const code of ['SL', 'PR', 'SRT', 'RCT', 'PAY', 'SOR', 'CON', 'JV']) {
        const before = await query<unknown[]>(
          `SELECT "SR_NO","AC_CODE","AC_NAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE" FROM "BOOK_DETL"
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY "SR_NO"`,
          tenantId,
          code,
        );
        const opened = await send('GET', `${API}/${code}`);
        expect(opened.statusCode, opened.body).toBe(200);
        const book = opened.json();
        const saved = await send('PUT', `${API}/${code}`, {
          ...book,
          slots: book.slots.map((slot: any) => ({ srNo: slot.srNo, acCode: slot.acCode })),
          expectedVersion: book.version,
        });
        expect(saved.statusCode, `${code}: ${saved.body}`).toBe(200);
        const after = await query<unknown[]>(
          `SELECT "SR_NO","AC_CODE","AC_NAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE" FROM "BOOK_DETL"
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY "SR_NO"`,
          tenantId,
          code,
        );
        expect(after, code).toEqual(before);
      }
    });

    it('T18 a sale posts through the slots of a SALES book made on the screen, and a slot change moves only later sales', async () => {
      await createBook('JS1', 'SALES', 'O', [
        [1, M[0]],
        [2, M[1]],
        [3, M[2]],
        [4, M[3]],
      ]);
      const first = created(await sale('JS1'));
      const one = await legs('JS1', first);
      balanced(one);
      noProvisioned(one);
      // Slot 1 is the bill's control account, slot 2 takes the cash, slot 3 the kasar.
      expect(one.find((leg) => leg.ac === 'CUSL' && leg.dr === 1000)?.ld).toBe(M[0]);
      expect(one.filter((leg) => leg.ac === M[1]).map((leg) => leg.dr)).toEqual([995]);
      expect(one.filter((leg) => leg.ac === M[2]).map((leg) => leg.dr)).toEqual([5]);

      const opened = (await send('GET', `${API}/JS1`)).json();
      const moved = await send('PUT', `${API}/JS1`, {
        ...opened,
        slots: opened.slots.map((slot: any) => ({
          srNo: slot.srNo,
          acCode: slot.srNo === 2 ? M[4] : slot.acCode,
        })),
        expectedVersion: opened.version,
      });
      expect(moved.statusCode, moved.body).toBe(200);
      const second = created(await sale('JS1'));
      expect(
        (await legs('JS1', second)).filter((leg) => leg.ac === M[4]).map((leg) => leg.dr),
      ).toEqual([995]);
      // The first sale keeps its posted legs.
      expect(await legs('JS1', first)).toEqual(one);
    });

    it('T18 a purchase posts through the slots of a PURCHASE book made on the screen', async () => {
      await createBook('JP1', 'PURCHASE', 'I', [
        [1, M[0]],
        [2, M[1]],
        [3, M[2]],
        [4, M[3]],
        [5, 'DISCOUNT'],
      ]);
      const vch = created(
        await send('POST', '/purchases', {
          coBook: 'JP1',
          vchDate: DAY,
          acCode: 'SUPL',
          taxRatePct: 0,
          interState: false,
          lines: [goldLine],
          cashAmt: 995,
          kasar: 5,
        }),
      );
      const rows = await legs('JP1', vch);
      balanced(rows);
      noProvisioned(rows);
      expect(rows.find((leg) => leg.ac === 'SUPL' && leg.cr === 1000)?.ld).toBe(M[0]);
      expect(rows.filter((leg) => leg.ac === M[1]).map((leg) => leg.cr)).toEqual([995]);
      expect(rows.some((leg) => leg.ac === M[2])).toBe(true);
    });

    it('T18 cash and bank receipts and payments post through CASH REC / BANK PAY books made on the screen', async () => {
      await createBook('JC1', 'CASH REC', 'I', [
        [1, M[0]],
        [2, M[1]],
      ]);
      created(
        await send('POST', '/receipts', {
          coBook: 'JC1',
          partyAc: 'PTY',
          amount: 5000,
          kasar: 50,
          mode: 'cash',
        }),
      );
      expect((await legs('JC1')).map(({ ac, dr, cr }) => ({ ac, dr, cr }))).toEqual([
        { ac: 'PTY', dr: 0, cr: 5000 },
        { ac: M[0], dr: 5000, cr: 0 },
        { ac: 'PTY', dr: 0, cr: 50 },
        { ac: M[1], dr: 50, cr: 0 },
      ]);
      await createBook('JC2', 'BANK PAY', 'O', [
        [1, M[3]],
        [2, M[2]],
      ]);
      created(
        await send('POST', '/payments', {
          coBook: 'JC2',
          partyAc: 'PTY',
          amount: 700,
          mode: 'bank',
        }),
      );
      const paid = await legs('JC2');
      balanced(paid);
      noProvisioned(paid);
      expect(paid.filter((leg) => leg.ac === M[3]).map((leg) => leg.cr)).toEqual([700]);
    });

    it('T18 a contra posts in a CONTRA book made on the screen and never on the provisioned slot accounts', async () => {
      await createBook('JK1', 'CONTRA', 'I', [
        [1, M[0]],
        [2, M[1]],
      ]);
      created(
        await send('POST', '/contra', {
          coBook: 'JK1',
          vchDate: DAY,
          lines: [
            { crdr: 'DR', acCode: M[3], amount: 2000 },
            { crdr: 'CR', acCode: M[4], amount: 2000 },
          ],
        }),
      );
      const rows = await legs('JK1');
      balanced(rows);
      noProvisioned(rows);
      expect(rows.map(({ ac, dr, cr }) => ({ ac, dr, cr }))).toEqual(
        expect.arrayContaining([
          { ac: M[3], dr: 2000, cr: 0 },
          { ac: M[4], dr: 0, cr: 2000 },
        ]),
      );
    });

    it('T18 a blank slot is saved on the screen and refused by the voucher that needs it', async () => {
      await createBook('JB1', 'SALES', 'O', [
        [1, M[0]],
        [2, ''],
        [3, M[2]],
      ]);
      const before = await query<Array<{ n: number }>>(
        `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1`,
        tenantId,
      );
      const refused = await sale('JB1');
      expect(refused.statusCode, refused.body).toBe(400);
      expect(
        await query<Array<{ n: number }>>(
          `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1`,
          tenantId,
        ),
      ).toEqual(before);
    });

    it('T18 a book with vouchers keeps its family and cannot be deleted until its vouchers are gone', async () => {
      const opened = (await send('GET', `${API}/JS1`)).json();
      expect(opened.hasVouchers).toBe(true);
      const refused = await send('PUT', `${API}/JS1`, {
        ...opened,
        family: 'PURCHASE',
        slots: opened.slots.map((slot: any) => ({ srNo: slot.srNo, acCode: slot.acCode })),
        expectedVersion: opened.version,
      });
      expect(refused.statusCode, refused.body).toBe(400);
      expect(refused.json().message).toBe(
        'This book already has vouchers, so its Transaction Name cannot be changed.',
      );
      const blocked = await send('DELETE', `${API}/JS1`);
      expect(blocked.statusCode, blocked.body).toBe(400);
      expect(blocked.json().message).toBe(
        'You Cant Delete Record This Book Code Use in Account Transection....',
      );
      const vouchers = await query<Array<{ vch: string }>>(
        `SELECT DISTINCT "VCH_NO" vch FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='JS1' ORDER BY 1`,
        tenantId,
      );
      for (const { vch } of vouchers) {
        const read = await send('GET', `/sales/${vch}?coBook=JS1`);
        expect(read.statusCode, read.body).toBe(200);
        const removed = await send(
          'DELETE',
          `/sales/${vch}?coBook=JS1&expectedVersion=${read.json().version}`,
        );
        expect(removed.statusCode, removed.body).toBe(200);
      }
      const deleted = await send('DELETE', `${API}/JS1`);
      expect(deleted.statusCode, deleted.body).toBe(200);
      expect(
        await query<unknown[]>(
          `SELECT 1 FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='JS1'`,
          tenantId,
        ),
      ).toEqual([]);
    });
  },
);
