import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N240 / G252: Company → Books is the desktop MS_BOOK screen (MDI_FORM.cs:7443-7448) through the real Fastify routes
 * on a forced-RLS database. Expected values come from the desktop source and the frozen case list
 * (orchestration/work/WP-21/cases.md):
 *
 * - BtnSave_Click (MS_BOOK.cs:2579-2685) refuses the reserved codes 218/888/999 ("This Is a Reserve Code You Cant Use
 *   It..."), then a blank short name ("Please Insert Book Short Name"), then a blank code or name ("Error Found : Please
 *   Enter Book Detail First..."); it writes BOOK_DATA from the boxes (the combos store their first letter, :2621-2625;
 *   a blank Data Type is 'A', :2630) and one BOOK_DETL row per grid row with the header columns repeated (:2653-2673).
 * - The family grid is the BOOK_IDTL template of the family (MS_BOOK.cs:2936), here the MS_UPDATE.cs template inserts
 *   (supervisor decision D1); the first template row's direction sets Inword/Outword (:2942-2948).
 * - Leaving the code refuses a code another book has; leaving the name, a name another code has (:2778, :2800).
 * - BtnDelete_Click (:2687-2726) refuses a blank code, a book AC_DATA uses (company + book, every location) and a book
 *   MAIN_STOCK uses at the location, then deletes the header and the slots.
 * Web rules on purpose: header and slots are written in one transaction; version tokens; a slot account must be in the
 * company's account master (blank allowed, D5); the direction and invoice type of a saved book cannot be changed (the
 * Ctrl+O override is not ported, D6); a book with vouchers keeps its family (D4).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'books-master-db';
const otherTenant = 'books-master-db-other';
const PASSWORD = 'Books-Master-Routes!2026';
const SECRET = 'books-master-routes-test-signing-secret-over-thirty';
const ADMIN = 'bkadmin';
const CLERK = 'bkclerk';
const BARRED = 'bkbarred';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
/** The rights SUB_MENU of the desktop menu caption 'Books' (formCatalog alias of 'Masters/Books / Series'). */
const RIGHTS_SUB_MENU = 'Books';
const API = '/masters/books-master';

/** The accounts of the desktop template codes and the marker accounts (cases.md, Test data). */
const ACCOUNTS: Array<[string, string, string]> = [
  ['00001', 'CASH ON HAND', '01'],
  ['00002', 'BANK OF TEST', '02'],
  ['00003', 'SALES GOLD A/C', '25'],
  ['00004', 'SALES SILVER A/C', '25'],
  ['00005', 'SALES OLD GOLD A/C', '25'],
  ['00006', 'SALES OLD SILVER A/C', '25'],
  ['00008', 'PURCHASE A/C', '30'],
  ['00009', 'PURCHASE SILVER A/C', '30'],
  ['00020', 'ORDER ADVANCE', '04'],
  ['00041', 'LABOUR INCOM. A/C', '23'],
  ['00042', 'KASAR AVAK A/C', '31'],
  ['00044', 'COMMISION INCOM A/C', '23'],
  ['00056', 'LABOUR EXP A/C', '22'],
  ['00057', 'KASAR JAVK A/C', '31'],
  ['00061', 'INTEREST INCOME A/C', '23'],
  ['00076', 'DISCOUNT A/C', '22'],
  ['00077', 'OTHER CHARGES A/C', '23'],
  ['00098', 'FINE KASAR', '31'],
  ['00099', 'SALES A/C', '25'],
  ['90001', 'MARKER ONE', '01'],
  ['90002', 'MARKER TWO', '01'],
  ['PTY01', 'TEST PARTY', '10'],
];

/**
 * The family-to-slot table of cases.md (MS_UPDATE.cs template inserts, cited there line by line):
 * family → direction of the first row and the slots as "SR_NO account description".
 */
const TEMPLATES: Record<string, { inout: 'I' | 'O'; slots: Array<[number, string, string]> }> = {
  'ITEM SALES': {
    inout: 'O',
    slots: [
      [1, '00003', 'SALES GOLD A/C'],
      [2, '00001', 'CASH ON HAND'],
      [3, '00041', 'LABOUR INCOM. A/C'],
      [4, '00057', 'KASAR JAVK A/C'],
      [5, '00076', 'DISCOUNT A/C'],
      [6, '00020', 'ORDER ADVANCE'],
    ],
  },
  'ITEM PURC': {
    inout: 'O',
    slots: [
      [1, '00008', 'PURCHASE A/C'],
      [2, '00001', 'CASH ON HAND'],
      [3, '00056', 'LABOUR EXP A/C'],
      [4, '00042', 'KASAR AVAK A/C'],
      [5, '00076', 'DISCOUNT A/C'],
    ],
  },
  'E INVOICE': {
    inout: 'O',
    slots: [
      [1, '00003', 'SALES GOLD A/C'],
      [2, '00001', 'CASH ON HAND'],
      [3, '00057', 'KASAR JAVK A/C'],
      [4, '00020', 'ORDER ADVANCE'],
      [5, '00076', 'DISCOUNT A/C'],
      [6, '00041', 'LABOUR INCOM. A/C'],
    ],
  },
  'CON PUR': {
    inout: 'I',
    slots: [
      [1, '00008', 'PURCHASE GOLD A/C'],
      [2, '00001', 'CASH ON HAND'],
      [3, '00042', 'KASAR AVAK A/C.'],
      [4, '00056', 'LABOUR EXP A/C'],
    ],
  },
  'OTH EXP': {
    inout: 'O',
    slots: [
      [1, '00008', 'PURCHASE A/C'],
      [2, '00001', 'CASH ON HAND'],
      [3, '00042', 'KASAR AVAK A/C'],
    ],
  },
  'OTH INC': {
    inout: 'I',
    slots: [
      [1, '00099', 'SALES A/C'],
      [2, '00001', 'CASH ON HAND'],
      [3, '00057', 'KASAR JAVK A/C'],
    ],
  },
  'LABOUR WORK': {
    inout: 'I',
    slots: [
      [8, '00004', 'SALES SILVER A/C'],
      [9, '00009', 'PURCHASE SILVER A/C'],
      [10, '00005', 'SALES OLD GOLD A/C'],
      [11, '00006', 'SALES OLD SILVER A/C'],
    ],
  },
  PURCHASE: { inout: 'I', slots: [[5, '00076', 'DISCOUNT A/C']] },
  'E CRNT': {
    inout: 'I',
    slots: [
      [1, '00003', 'SALES GOLD A/C'],
      [2, '00001', 'CASH ON HAND'],
      [3, '00042', 'KASAR AVAK A/C'],
      [4, '00076', 'DISCOUNT A/C'],
    ],
  },
  'OTH COMM': {
    inout: 'O',
    slots: [
      [1, '00001', 'CASH ON HAND'],
      [2, '00044', 'COMMISION INCOM A/C'],
      [3, '00057', 'KASAR JAVK A/C'],
    ],
  },
  'WH RTN': {
    inout: 'I',
    slots: [
      [1, '00003', 'SALES GOLD A/C'],
      [2, '00004', 'SALES SILVER A/C'],
      [3, '00001', 'CASH ON HAND'],
      [4, '00041', 'LABOUR INCOM. A/C'],
      [5, '00042', 'KASAR AVAK A/C'],
      [6, '00077', 'OTHER CHARGES A/C'],
      [7, '00098', 'FINE KASAR'],
    ],
  },
  'LD ADJUST': {
    inout: 'I',
    slots: [
      [1, '00042', 'KASAR AVAK A/C.'],
      [2, '00057', 'KASAR JAVK A/C'],
      [3, '00098', 'FINE KASAR'],
    ],
  },
  'FINE PURC': {
    inout: 'O',
    slots: [
      [1, '00001', 'CASH ON HAND'],
      [2, '00008', 'PURCHASE A/C'],
      [3, '00009', 'PURCHASE SILVER A/C'],
      [4, '00057', 'KASAR AVAK A/C'],
      [5, '00076', 'DISCOUNT A/C'],
      [6, '00056', 'LABOUR EXP A/C'],
    ],
  },
  'FINE SALE': {
    inout: 'O',
    slots: [
      [1, '00001', 'CASH ON HAND'],
      [2, '00003', 'SALES GOLD A/C'],
      [3, '00004', 'SALES SILVER A/C'],
      [4, '00057', 'KASAR JAVK A/C'],
      [5, '00076', 'DISCOUNT A/C'],
      [6, '00041', 'LABOUR INCOME A/C'],
    ],
  },
  'TAG PURCHASE': { inout: 'I', slots: [[5, '00076', 'DISCOUNT A/C']] },
  'AMT IN': { inout: 'I', slots: [[1, '00057', 'KASAR JAVK A/C']] },
  'AMT OUT': { inout: 'O', slots: [[1, '00042', 'KASAR AVAK A/C']] },
  'TOUR SALES': {
    inout: 'O',
    slots: [
      [1, '00003', 'SALES GOLD A/C'],
      [2, '00008', 'PURCHASE GOLD A/C'],
      [3, '00001', 'CASH ON HAND'],
      [4, '00057', 'KASAR JAVK A/C'],
      [5, '00042', 'KASAR AVAK A/C'],
      [6, '00041', 'LABOUR INCOME A/C'],
      [7, '00056', 'LABOUR EXP A/C'],
      [8, '00004', 'SALES SILVER A/C'],
      [9, '00009', 'PURCHASE SILVER A/C'],
      [10, '00061', 'INTEREST INCOME A/C'],
      [11, '00077', 'OTHER CHARGES A/C'],
      [12, '00098', 'FINE KASAR'],
    ],
  },
  'TOUR ORDER': { inout: 'I', slots: [[1, '00001', 'CASH ON HAND']] },
  'TAG SPLIT': {
    inout: 'O',
    slots: [
      [1, '00001', 'CASH ON HAND'],
      [2, '00057', 'KASAR JAVK A/C'],
      [3, '00042', 'KASAR AVAK A/C'],
      [4, '00041', 'LABOUR INCOME A/C'],
      [5, '00056', 'LABOUR EXP A/C'],
      [6, '00003', 'SALES GOLD A/C'],
      [7, '00008', 'PURCHASE GOLD A/C'],
      [8, '00004', 'SALES SILVER A/C'],
      [9, '00009', 'PURCHASE SILVER A/C'],
    ],
  },
};
const accountName = (code: string) => ACCOUNTS.find(([c]) => c === code)?.[1] ?? '';

type Cookie = string;
type Slot = { srNo: number | string; acCode: string };
interface DetlRow {
  lc: string;
  book: string;
  sr: number;
  name: string;
  sname: string;
  btype: string | null;
  itype: string | null;
  inout: string;
  ac: string;
  acname: string;
  main: string;
  reset: string | null;
  dtype: string;
}

(enabled ? describe : describe.skip)(
  'N240 Books is the desktop MS_BOOK screen through HTTP',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    let adminCookie: Cookie;
    let clerkCookie: Cookie;
    let barredCookie: Cookie;

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
    const admin = (method: string, url: string, payload?: unknown) =>
      request(adminCookie, method, url, payload);
    const header = (code: string, lc = '01') =>
      query<Array<Record<string, unknown>>>(
        `SELECT "LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","CUR_USE","MAIN_BOOK","ITM_TYPE","BOOK_INOUT","BOOK_TYPE",
              "BOOK_SR_NAME","USER_EMP_CODE","DATA_TYPE","RESET_BOOK","TRFR_BOOK","WITH_MOBILE_ENTRY","MAIN_USER",
              "BOOK_TBL_NAME","BOOK_TBL_DETL"
         FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"=$3 AND "CO_BOOK"=$2 ORDER BY row_id`,
        tenantId,
        code,
        lc,
      );
    const detail = (code: string, lc = '01') =>
      query<DetlRow[]>(
        `SELECT "LC_CODE" lc,"CO_BOOK" book,"SR_NO"::int sr,"BOOK_NAME" name,"BOOK_SNAME" sname,"BOOK_TYPE" btype,
              "ITM_TYPE" itype,"BOOK_INOUT" inout,coalesce("AC_CODE",'') ac,coalesce("AC_NAME",'') acname,
              "MAIN_BOOK" main,"RESET_BOOK" reset,"DATA_TYPE" dtype
         FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"=$3 AND "CO_BOOK"=$2
        ORDER BY "SR_NO",row_id`,
        tenantId,
        code,
        lc,
      );
    const slotsOf = async (code: string) =>
      (await detail(code)).map((row) => [row.sr, row.ac, row.acname] as const);
    /** Every BOOK_DATA/BOOK_DETL row of both tenants, for "nothing was written" checks. */
    const footprint = () =>
      query<unknown[]>(
        `SELECT 'D' t, to_jsonb(b) - 'row_id' r FROM "BOOK_DATA" b WHERE tenant_id IN ($1,$2)
       UNION ALL SELECT 'L', to_jsonb(d) - 'row_id' FROM "BOOK_DETL" d WHERE tenant_id IN ($1,$2)
       ORDER BY 1, 2`,
        tenantId,
        otherTenant,
      );
    const book = (extra: Record<string, unknown> = {}) => ({
      code: 'Z01',
      name: 'Zeta Sales',
      short: 'ZS',
      curUse: 'Y',
      family: 'SALES',
      itemType: 'G',
      inout: 'O',
      bookType: 'T',
      vchSeries: 'ZSR',
      resetBook: 'R1',
      trfrBook: 'T1',
      mobileEntry: 'Y',
      slots: [
        { srNo: 1, acCode: '00003' },
        { srNo: 2, acCode: '00001' },
      ] as Slot[],
      ...extra,
    });
    const templateSlots = (family: string): Slot[] =>
      TEMPLATES[family]!.slots.map(([srNo, acCode]) => ({ srNo, acCode }));
    const versionOf = async (code: string): Promise<string> => {
      const response = await admin('GET', `${API}/${code}`);
      expect(response.statusCode, response.body).toBe(200);
      return response.json().version;
    };
    const expectRefused = async (
      response: { statusCode: number; body: string; json: () => any },
      message: string,
    ) => {
      expect(response.statusCode, response.body).toBe(400);
      expect(response.json().message).toBe(message);
    };
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

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      for (const [code, name, group] of ACCOUNTS)
        await exec(
          `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01',$2,$3,$4)`,
          tenantId,
          code,
          name,
          group,
        );
      // Another tenant's book Z01 and account 77777 must never be listed, read or written.
      await exec(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK")
       VALUES ($1,'01','01','Z01','OTHER TENANT','OT','SALES')`,
        otherTenant,
      );
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','77777','FOREIGN','01')`,
        otherTenant,
      );
      const passwordHash = await hashPassword(PASSWORD);
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01',$2,$5,'ADMIN','Y','Y','Y','N'),($1,'01',$3,$5,'USER','Y','N','N','N'),
              ($1,'01',$4,$5,'USER','Y','Y','Y','N')`,
        tenantId,
        ADMIN,
        CLERK,
        BARRED,
        passwordHash,
      );
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES ($1,'01','01',$2,'Company',$4,'Y','N','N','N'),($1,'01','01',$3,'Company',$4,'N','N','N','N')`,
        tenantId,
        CLERK,
        BARRED,
        RIGHTS_SUB_MENU,
      );
      app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
      adminCookie = await login(ADMIN);
      clerkCookie = await login(CLERK);
      barredCookie = await login(BARRED);
    });

    afterAll(async () => {
      if (app) await app.close();
      if (owner) await wipe();
      if (runtime) await runtime.$disconnect();
      if (owner) await owner.$disconnect();
    });

    it('T01 lists the books of the location by code, the header families and the rights', async () => {
      const response = await admin('GET', API);
      expect(response.statusCode, response.body).toBe(200);
      const body = response.json();
      const codes = body.rows.map((row: { code: string }) => row.code);
      expect(codes).toEqual([...codes].sort());
      expect(body.rows.find((row: { code: string }) => row.code === 'SL')).toEqual({
        code: 'SL',
        name: 'Sales',
        trfr: '',
      });
      expect(codes).not.toContain('Z01');
      // MS_BOOK.cs:2119 GROUP BY MAIN_BOOK ORDER BY MAIN_BOOK, with the blank first entry left to the screen.
      const provisioned: Array<{ main: string }> = await query(
        `SELECT DISTINCT "MAIN_BOOK" main FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
        ORDER BY 1`,
        tenantId,
      );
      expect(body.families).toEqual(provisioned.map((row) => row.main));
      expect(body.rights).toEqual({ canUpdate: true, canDelete: true, canPrint: true });
    });

    it('T04 a family rebuilds the grid from its template, direction from the first row', async () => {
      for (const [family, template] of Object.entries(TEMPLATES)) {
        const response = await admin('GET', `${API}/template?family=${encodeURIComponent(family)}`);
        expect(response.statusCode, response.body).toBe(200);
        const body = response.json();
        expect(body.inout, family).toBe(template.inout);
        // The template's slots, with their accounts and descriptions. A slot number the template does not define (the
        // baseline rows the study records as MISSING, e.g. PURCHASE 1 to 4, LABOUR WORK 1 and 6) comes from the
        // location's provisioned book of the family, never from another family.
        const numbers = new Set(template.slots.map(([sr]) => sr));
        expect(
          body.slots
            .filter((slot: any) => numbers.has(slot.srNo))
            .map((slot: any) => [slot.srNo, slot.acCode, slot.desc, slot.acName]),
          family,
        ).toEqual(template.slots.map(([sr, code, desc]) => [sr, code, desc, accountName(code)]));
        const extra = body.slots.filter((slot: any) => !numbers.has(slot.srNo));
        const provisioned: Array<{ sr: number; ac: string }> = await query(
          `SELECT d."SR_NO"::int sr,d."AC_CODE" ac FROM "BOOK_DETL" d
          WHERE d.tenant_id=$1 AND d."CO_CODE"='01' AND d."LC_CODE"='01'
            AND d."CO_BOOK"=(SELECT min("CO_BOOK") FROM "BOOK_DATA" b WHERE b.tenant_id=$1 AND b."CO_CODE"='01'
                               AND b."LC_CODE"='01' AND b."MAIN_BOOK"=$2)
          ORDER BY 1`,
          tenantId,
          family,
        );
        expect(
          extra.map((slot: any) => [slot.srNo, slot.acCode]),
          family,
        ).toEqual(provisioned.filter((row) => !numbers.has(row.sr)).map((row) => [row.sr, row.ac]));
      }
    });

    it('T07 a book of each template family saves exactly its template slots (G7 to G10)', async () => {
      let n = 0;
      for (const [family, template] of Object.entries(TEMPLATES)) {
        const code = `F${String(++n).padStart(2, '0')}`;
        const response = await admin(
          'POST',
          API,
          book({
            code,
            name: `Family ${family}`,
            short: `F${n}`,
            family,
            inout: template.inout,
            slots: templateSlots(family),
          }),
        );
        expect(response.statusCode, `${family}: ${response.body}`).toBe(201);
        expect(await slotsOf(code), family).toEqual(
          template.slots.map(([sr, ac]) => [sr, ac, accountName(ac)]),
        );
        const [row] = await header(code);
        expect(row?.BOOK_INOUT, family).toBe(template.inout);
        expect(row?.MAIN_BOOK, family).toBe(family);
      }
    });

    it('T07 the ITEM SALES footprint: one header, six slots, the user, data type A, one commit', async () => {
      const before = await footprint();
      const response = await admin(
        'POST',
        API,
        book({
          code: 'Z12',
          name: 'Zeta Item Sales',
          short: 'ZIS',
          curUse: 'Y',
          family: 'ITEM SALES',
          itemType: 'A',
          inout: 'O',
          bookType: 'F',
          vchSeries: '',
          resetBook: '',
          trfrBook: '',
          mobileEntry: '',
          slots: templateSlots('ITEM SALES'),
        }),
      );
      expect(response.statusCode, response.body).toBe(201);
      expect(response.json()).toEqual({ code: 'Z12', slots: 6 });
      expect(await header('Z12')).toEqual([
        {
          LC_CODE: '01',
          CO_BOOK: 'Z12',
          BOOK_NAME: 'Zeta Item Sales',
          BOOK_SNAME: 'ZIS',
          CUR_USE: 'Y',
          MAIN_BOOK: 'ITEM SALES',
          ITM_TYPE: 'A',
          BOOK_INOUT: 'O',
          BOOK_TYPE: 'F',
          BOOK_SR_NAME: '',
          USER_EMP_CODE: '',
          DATA_TYPE: 'A',
          RESET_BOOK: '',
          TRFR_BOOK: '',
          WITH_MOBILE_ENTRY: '',
          MAIN_USER: ADMIN,
          BOOK_TBL_NAME: null,
          BOOK_TBL_DETL: null,
        },
      ]);
      expect(await detail('Z12')).toEqual(
        TEMPLATES['ITEM SALES']!.slots.map(([sr, ac]) => ({
          lc: '01',
          book: 'Z12',
          sr,
          name: 'Zeta Item Sales',
          sname: 'ZIS',
          btype: 'F',
          itype: 'A',
          inout: 'O',
          ac,
          acname: accountName(ac),
          main: 'ITEM SALES',
          reset: '',
          dtype: 'A',
        })),
      );
      const after = await footprint();
      expect(after.length - before.length).toBe(7);
    });

    it('data type: a B book stamps the header and every slot; other values are refused (MS_BOOK.cs:2628-2671)', async () => {
      const values = {
        name: 'Zeta B Sales',
        short: 'ZBS',
        curUse: 'Y',
        family: 'ITEM SALES',
        itemType: 'A',
        inout: 'O',
        bookType: 'F',
        vchSeries: '',
        resetBook: '',
        trfrBook: '',
        mobileEntry: '',
        slots: templateSlots('ITEM SALES'),
      };
      const refused = await admin('POST', API, book({ code: 'Z1B', ...values, dataType: 'C' }));
      expect(refused.statusCode, refused.body).toBe(400);
      const saved = await admin('POST', API, book({ code: 'Z1B', ...values, dataType: 'B' }));
      expect(saved.statusCode, saved.body).toBe(201);
      expect((await header('Z1B'))[0]!.DATA_TYPE).toBe('B');
      const slots = await detail('Z1B');
      expect(slots.length).toBe(6);
      expect(new Set(slots.map((row) => row.dtype))).toEqual(new Set(['B']));
    });

    it('T02 stores the first letter of each combo in both tables and keeps the name case', async () => {
      const response = await admin(
        'POST',
        API,
        book({
          code: 'z01',
          name: 'Zeta Sales',
          short: 'zs',
          curUse: 'No',
          itemType: 'Silver',
          inout: 'Outword',
          bookType: 'Mix',
          vchSeries: "z'sr",
          resetBook: 'r1',
          trfrBook: 't1',
          mobileEntry: 'y',
        }),
      );
      expect(response.statusCode, response.body).toBe(201);
      expect(await header('Z01')).toMatchObject([
        {
          CO_BOOK: 'Z01',
          BOOK_NAME: 'Zeta Sales',
          BOOK_SNAME: 'ZS',
          CUR_USE: 'N',
          MAIN_BOOK: 'SALES',
          ITM_TYPE: 'S',
          BOOK_INOUT: 'O',
          BOOK_TYPE: 'M',
          BOOK_SR_NAME: 'ZSR',
          RESET_BOOK: 'R1',
          TRFR_BOOK: 'T1',
          WITH_MOBILE_ENTRY: 'Y',
        },
      ]);
      expect(
        (await detail('Z01')).map((row) => [row.btype, row.itype, row.inout, row.reset]),
      ).toEqual([
        ['M', 'S', 'O', 'R1'],
        ['M', 'S', 'O', 'R1'],
      ]);
      // Reopen shows every value.
      const opened = await admin('GET', `${API}/Z01`);
      expect(opened.statusCode, opened.body).toBe(200);
      expect(opened.json()).toMatchObject({
        code: 'Z01',
        name: 'Zeta Sales',
        short: 'ZS',
        curUse: 'N',
        family: 'SALES',
        itemType: 'S',
        inout: 'O',
        bookType: 'M',
        vchSeries: 'ZSR',
        resetBook: 'R1',
        trfrBook: 'T1',
        mobileEntry: 'Y',
        hasVouchers: false,
      });
      expect(opened.json().version).toMatch(/^[0-9a-f]{64}$/);
    });

    it('T06 refuses the reserved codes, a blank short name, a blank code or name, in the desktop order', async () => {
      const before = await footprint();
      for (const code of ['218', '888', '999'])
        await expectRefused(
          await admin('POST', API, book({ code, name: `Reserved ${code}` })),
          'This Is a Reserve Code You Cant Use It...',
        );
      // The reserved code is checked before the short name (MS_BOOK.cs:2591, :2597).
      await expectRefused(
        await admin('POST', API, book({ code: '218', short: '' })),
        'This Is a Reserve Code You Cant Use It...',
      );
      await expectRefused(
        await admin('POST', API, book({ code: 'Z06', name: 'No Short', short: '' })),
        'Please Insert Book Short Name',
      );
      await expectRefused(
        await admin('POST', API, book({ code: '', name: 'Only Name', short: 'AB' })),
        'Error Found : Please Enter Book Detail First...',
      );
      await expectRefused(
        await admin('POST', API, book({ code: 'Z07', name: '', short: 'AB' })),
        'Error Found : Please Enter Book Detail First...',
      );
      expect(await footprint()).toEqual(before);
    });

    it('T06 the code holds at most 3 characters, upper-cased, never padded; the box limits hold', async () => {
      const before = await footprint();
      const long = await admin('POST', API, book({ code: 'ABCD', name: 'Too Long' }));
      expect(long.statusCode, long.body).toBe(400);
      for (const [field, value] of [
        ['name', 'N'.repeat(51)],
        ['short', 'S'.repeat(6)],
        ['vchSeries', 'V'.repeat(16)],
        ['resetBook', 'R'.repeat(6)],
        ['trfrBook', 'T'.repeat(6)],
        ['mobileEntry', 'YY'],
      ] as const) {
        const response = await admin(
          'POST',
          API,
          book({ code: 'Z40', name: 'Limits', [field]: value }),
        );
        expect(response.statusCode, `${field}: ${response.body}`).toBe(400);
      }
      for (const [field, value] of [
        ['curUse', 'Maybe'],
        ['itemType', 'Diamond'],
        ['inout', 'Sideways'],
        ['bookType', 'Other'],
      ] as const) {
        const response = await admin(
          'POST',
          API,
          book({ code: 'Z40', name: 'Combos', [field]: value }),
        );
        expect(response.statusCode, `${field}: ${response.body}`).toBe(400);
      }
      expect(await footprint()).toEqual(before);
      for (const [typed, stored] of [
        ['ab1', 'AB1'],
        ['Q', 'Q'],
      ] as const) {
        const response = await admin(
          'POST',
          API,
          book({ code: typed, name: `Code ${stored}`, short: stored }),
        );
        expect(response.statusCode, response.body).toBe(201);
        expect((await header(stored)).map((row) => row.CO_BOOK)).toEqual([stored]);
      }
    });

    it('T06 refuses a code another book has and a name another code has, with the desktop texts', async () => {
      const before = await footprint();
      await expectRefused(
        await admin('POST', API, book({ code: 'Z01', name: 'Other Name' })),
        "This Book Code already Exist in  'Zeta Sales'  Book Name... Please Change Book Code...",
      );
      await expectRefused(
        await admin('POST', API, book({ code: 'Z09', name: 'zeta sales' })),
        "This Book Name already Exist in  'Z01'  Book Code... Please Change Book Name...",
      );
      expect(await footprint()).toEqual(before);
    });

    it('T06 allows a blank slot account with data type A and refuses an account the company does not have', async () => {
      const slots = templateSlots('ITEM SALES').map((slot) =>
        slot.srNo === 3 || slot.srNo === 6 ? { ...slot, acCode: '' } : slot,
      );
      const saved = await admin(
        'POST',
        API,
        book({ code: 'Z10', name: 'Blank Slots', short: 'Z10', family: 'ITEM SALES', slots }),
      );
      expect(saved.statusCode, saved.body).toBe(201);
      const rows = await detail('Z10');
      expect(rows).toHaveLength(6);
      expect(
        rows.filter((row) => row.ac === '').map((row) => [row.sr, row.acname, row.dtype]),
      ).toEqual([
        [3, '', 'A'],
        [6, '', 'A'],
      ]);
      const before = await footprint();
      for (const acCode of ['99999', '77777']) {
        const refused = await admin(
          'POST',
          API,
          book({
            code: 'Z41',
            name: 'Unknown Account',
            slots: [{ srNo: 1, acCode }],
          }),
        );
        expect(refused.statusCode, refused.body).toBe(400);
        expect(refused.json().message).toContain(acCode);
      }
      // Two rows with one slot number would post through an ambiguous slot.
      const twice = await admin(
        'POST',
        API,
        book({
          code: 'Z41',
          name: 'Twice',
          slots: [
            { srNo: 1, acCode: '00001' },
            { srNo: '01', acCode: '00003' },
          ],
        }),
      );
      expect(twice.statusCode, twice.body).toBe(400);
      expect(await footprint()).toEqual(before);
    });

    it('T03 the Sr cell is stored as its number', async () => {
      const response = await admin(
        'POST',
        API,
        book({
          code: 'Z42',
          name: 'Sr Val',
          family: 'PURCHASE',
          inout: 'I',
          slots: [{ srNo: '03', acCode: '00001' }],
        }),
      );
      expect(response.statusCode, response.body).toBe(201);
      expect(await slotsOf('Z42')).toEqual([[3, '00001', 'CASH ON HAND']]);
    });

    it('T05/T08 reopen shows the template by slot identity with the saved accounts over it', async () => {
      await exec(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","DATA_TYPE","MAIN_USER")
       VALUES ($1,'01','01','Z43','Gappy','GP','ITEM SALES','O','Y','A','olduser')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","AC_CODE","AC_NAME","DATA_TYPE")
       VALUES ($1,'01','01','Z43',2,'Gappy','GP','ITEM SALES','O','00003','SALES GOLD A/C','A'),
              ($1,'01','01','Z43',5,'Gappy','GP','ITEM SALES','O','00004','SALES SILVER A/C','A')`,
        tenantId,
      );
      const opened = await admin('GET', `${API}/Z43`);
      expect(opened.statusCode, opened.body).toBe(200);
      expect(opened.json().slots.map((slot: any) => [slot.srNo, slot.acCode, slot.desc])).toEqual([
        [1, '00003', 'SALES GOLD A/C'],
        [2, '00003', 'CASH ON HAND'],
        [3, '00041', 'LABOUR INCOM. A/C'],
        [4, '00057', 'KASAR JAVK A/C'],
        [5, '00004', 'DISCOUNT A/C'],
        [6, '00020', 'ORDER ADVANCE'],
      ]);
      // The family grid of the book's own family keeps every saved account, the last one included (MS_BOOK.cs:2958
      // drops it); another family's grid is that family's template.
      const own = await admin('GET', `${API}/template?family=ITEM%20SALES&code=Z43`);
      expect(own.json().slots.map((slot: any) => slot.acCode)).toEqual([
        '00003',
        '00003',
        '00041',
        '00057',
        '00004',
        '00020',
      ]);
      const other = await admin('GET', `${API}/template?family=ITEM%20PURC&code=Z43`);
      expect(other.json().slots.map((slot: any) => slot.acCode)).toEqual(
        TEMPLATES['ITEM PURC']!.slots.map(([, ac]) => ac),
      );
      expect(opened.json().mainUser).toBe('olduser');
    });

    it('T08/T09 an unchanged save keeps every column and the stored user; an edit replaces the slots', async () => {
      await exec(
        `UPDATE "BOOK_DATA" SET "BOOK_TBL_NAME"='SL_DATA',"BOOK_TBL_DETL"='SL_DETL',"MAIN_USER"='olduser'
        WHERE tenant_id=$1 AND "CO_BOOK"='Z12'`,
        tenantId,
      );
      const beforeHeader = await header('Z12');
      const beforeDetail = await detail('Z12');
      const opened = (await admin('GET', `${API}/Z12`)).json();
      const unchanged = await admin('PUT', `${API}/Z12`, {
        ...opened,
        slots: opened.slots.map((slot: any) => ({ srNo: slot.srNo, acCode: slot.acCode })),
        expectedVersion: opened.version,
      });
      expect(unchanged.statusCode, unchanged.body).toBe(200);
      expect(await header('Z12')).toEqual(beforeHeader);
      expect(await detail('Z12')).toEqual(beforeDetail);

      // Stale version: refused before anything changes.
      const stale = await admin('PUT', `${API}/Z12`, {
        ...opened,
        slots: opened.slots.map((slot: any) => ({ srNo: slot.srNo, acCode: slot.acCode })),
        expectedVersion: opened.version,
      });
      expect(stale.statusCode, stale.body).toBe(409);

      const version = await versionOf('Z12');
      const edited = await admin('PUT', `${API}/Z12`, {
        ...opened,
        name: 'Zeta Item Sales 2',
        short: 'ZI2',
        curUse: 'N',
        itemType: 'G',
        slots: opened.slots.map((slot: any) => ({
          srNo: slot.srNo,
          acCode: slot.srNo === 2 ? '00002' : slot.acCode,
        })),
        expectedVersion: version,
      });
      expect(edited.statusCode, edited.body).toBe(200);
      expect(await header('Z12')).toMatchObject([
        {
          BOOK_NAME: 'Zeta Item Sales 2',
          BOOK_SNAME: 'ZI2',
          CUR_USE: 'N',
          ITM_TYPE: 'G',
          MAIN_USER: 'olduser',
          BOOK_TBL_NAME: 'SL_DATA',
          BOOK_TBL_DETL: 'SL_DETL',
        },
      ]);
      const rows = await detail('Z12');
      expect(rows.map((row) => [row.sr, row.ac, row.name, row.sname, row.itype])).toEqual(
        TEMPLATES['ITEM SALES']!.slots.map(([sr, ac]) => [
          sr,
          sr === 2 ? '00002' : ac,
          'Zeta Item Sales 2',
          'ZI2',
          'G',
        ]),
      );
    });

    it('T05 an edit of one book leaves another book of the family untouched', async () => {
      for (const [code, first] of [
        ['Z04', '00003'],
        ['Z05', '00004'],
      ] as const) {
        const response = await admin(
          'POST',
          API,
          book({
            code,
            name: `Iso ${code}`,
            short: code,
            family: 'ITEM SALES',
            slots: templateSlots('ITEM SALES').map((slot) =>
              slot.srNo === 1 ? { ...slot, acCode: first } : slot,
            ),
          }),
        );
        expect(response.statusCode, response.body).toBe(201);
      }
      const opened = (await admin('GET', `${API}/Z04`)).json();
      const edited = await admin('PUT', `${API}/Z04`, {
        ...opened,
        slots: opened.slots.map((slot: any) => ({
          srNo: slot.srNo,
          acCode: slot.srNo === 1 ? '00041' : slot.acCode,
        })),
        expectedVersion: opened.version,
      });
      expect(edited.statusCode, edited.body).toBe(200);
      expect((await slotsOf('Z04'))[0]).toEqual([1, '00041', 'LABOUR INCOM. A/C']);
      expect((await slotsOf('Z05'))[0]).toEqual([1, '00004', 'SALES SILVER A/C']);
      expect(await detail('Z04')).toHaveLength(6);
      expect(await detail('Z05')).toHaveLength(6);
    });

    it('T09 the direction and invoice type of a saved book cannot be changed', async () => {
      const opened = (await admin('GET', `${API}/Z05`)).json();
      const before = await footprint();
      for (const change of [{ inout: 'I' }, { bookType: 'M' }]) {
        const response = await admin('PUT', `${API}/Z05`, {
          ...opened,
          ...change,
          slots: opened.slots.map((slot: any) => ({ srNo: slot.srNo, acCode: slot.acCode })),
          expectedVersion: opened.version,
        });
        expect(response.statusCode, response.body).toBe(400);
      }
      expect(await footprint()).toEqual(before);
    });

    it('T09/T06 the family changes on a book without vouchers and is refused on a book with vouchers (D4)', async () => {
      const opened = (await admin('GET', `${API}/Z05`)).json();
      const changed = await admin('PUT', `${API}/Z05`, {
        ...opened,
        family: 'ITEM PURC',
        slots: templateSlots('ITEM PURC'),
        expectedVersion: opened.version,
      });
      expect(changed.statusCode, changed.body).toBe(200);
      expect((await slotsOf('Z05')).map(([sr, ac]) => [sr, ac])).toEqual(
        TEMPLATES['ITEM PURC']!.slots.map(([sr, ac]) => [sr, ac]),
      );
      expect((await header('Z05'))[0]).toMatchObject({ MAIN_BOOK: 'ITEM PURC', BOOK_INOUT: 'O' });
      expect(new Set((await detail('Z05')).map((row) => row.main))).toEqual(new Set(['ITEM PURC']));

      // A voucher of book Z04 at another location: AC_DATA is checked by company and book only.
      await exec(
        `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","DR_AMT","CR_AMT")
       VALUES ($1,'01','02',$2,'Z04','00001','00001',10,0)`,
        tenantId,
        YEAR,
      );
      const voucherBook = (await admin('GET', `${API}/Z04`)).json();
      expect(voucherBook.hasVouchers).toBe(true);
      const before = await footprint();
      await expectRefused(
        await admin('PUT', `${API}/Z04`, {
          ...voucherBook,
          family: 'ITEM PURC',
          slots: templateSlots('ITEM PURC'),
          expectedVersion: voucherBook.version,
        }),
        'This book already has vouchers, so its Transaction Name cannot be changed.',
      );
      expect(await footprint()).toEqual(before);
      // A slot change on the same book is still allowed: only the family is locked.
      const slotEdit = await admin('PUT', `${API}/Z04`, {
        ...voucherBook,
        slots: voucherBook.slots.map((slot: any) => ({
          srNo: slot.srNo,
          acCode: slot.srNo === 1 ? '00003' : slot.acCode,
        })),
        expectedVersion: voucherBook.version,
      });
      expect(slotEdit.statusCode, slotEdit.body).toBe(200);
    });

    it('T10 delete refuses a blank code and referenced books, then deletes header and slots together', async () => {
      await expectRefused(await admin('DELETE', `${API}/%20`), 'Please Select Product For Delete.');
      const before = await footprint();
      await expectRefused(
        await admin('DELETE', `${API}/Z04`),
        'You Cant Delete Record This Book Code Use in Account Transection....',
      );
      // A stock row at this location refuses; the same code at another location is not checked against it.
      await exec(
        `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO")
       VALUES ($1,'01','01',$2,'Z05','00001')`,
        tenantId,
        YEAR,
      );
      await expectRefused(
        await admin('DELETE', `${API}/Z05`),
        'You Cant Delete Record This Book Code Use in Stock Transection....',
      );
      expect(await footprint()).toEqual(before);

      const version = await versionOf('Z43');
      const stale = await admin('DELETE', `${API}/Z43?expectedVersion=${'0'.repeat(64)}`);
      expect(stale.statusCode, stale.body).toBe(409);
      const deleted = await admin('DELETE', `${API}/Z43?expectedVersion=${version}`);
      expect(deleted.statusCode, deleted.body).toBe(200);
      expect(deleted.json()).toEqual({ code: 'Z43', deleted: 1, slots: 2 });
      expect(await header('Z43')).toEqual([]);
      expect(await detail('Z43')).toEqual([]);
      const after = await footprint();
      expect(before.length - after.length).toBe(3);
    });

    it('T11 another location and another tenant are invisible and unchanged', async () => {
      await exec(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE")
       VALUES ($1,'01','02','Z26','Far Book','FB','SALES','O','Y')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","AC_CODE","AC_NAME","DATA_TYPE")
       VALUES ($1,'01','02','Z26',1,'Far Book','FB','SALES','O','00003','SALES GOLD A/C','A')`,
        tenantId,
      );
      const before = await footprint();
      const list = (await admin('GET', API)).json();
      expect(list.rows.map((row: { code: string }) => row.code)).not.toContain('Z26');
      expect((await admin('GET', `${API}/Z26`)).statusCode).toBe(404);
      const put = await admin('PUT', `${API}/Z26`, {
        ...book({ code: 'Z26', name: 'Far Book', short: 'FB' }),
        expectedVersion: 'f'.repeat(64),
      });
      expect(put.statusCode).toBe(404);
      const removed = await admin('DELETE', `${API}/Z26`);
      expect(removed.statusCode).toBe(404);
      // The other tenant's Z01 is not this tenant's Z01.
      expect((await admin('GET', `${API}/Z01`)).json().name).toBe('Zeta Sales');
      expect(await footprint()).toEqual(before);
    });

    it('T11 rights: no Books right is refused everything; edit, delete and print need their flags', async () => {
      expect((await request(barredCookie, 'GET', API)).statusCode).toBe(403);
      expect((await request(barredCookie, 'POST', API, book({ code: 'Z44' }))).statusCode).toBe(
        403,
      );
      const list = await request(clerkCookie, 'GET', API);
      expect(list.statusCode, list.body).toBe(200);
      expect(list.json().rights).toEqual({ canUpdate: false, canDelete: false, canPrint: false });
      // A new book needs no edit right (MS_BOOK.cs:2586 checks FRM_EDIT in mode E only).
      const added = await request(
        clerkCookie,
        'POST',
        API,
        book({ code: 'Z44', name: 'Clerk Book', short: 'CB' }),
      );
      expect(added.statusCode, added.body).toBe(201);
      const version = await versionOf('Z44');
      expect(
        (
          await request(clerkCookie, 'PUT', `${API}/Z44`, {
            ...book({ code: 'Z44', name: 'Clerk Edit', short: 'CB' }),
            expectedVersion: version,
          })
        ).statusCode,
      ).toBe(403);
      expect((await request(clerkCookie, 'DELETE', `${API}/Z44`)).statusCode).toBe(403);
      expect((await request(clerkCookie, 'GET', `${API}/print`)).statusCode).toBe(403);
      const print = await admin('GET', `${API}/print`);
      expect(print.statusCode, print.body).toBe(200);
      expect(print.json().rows[0]).toEqual({ code: 'AB1', name: 'Code AB1', trfr: 'T1' });
    });

    it('the generic master routes no longer write books', async () => {
      const before = await footprint();
      const post = await admin('POST', '/masters/books', {
        CO_BOOK: 'Z45',
        BOOK_NAME: 'Generic',
        BOOK_SNAME: 'GN',
      });
      expect(post.statusCode).toBeGreaterThanOrEqual(400);
      const remove = await admin('DELETE', '/masters/books?CO_BOOK=Z12');
      expect(remove.statusCode).toBeGreaterThanOrEqual(400);
      expect(await footprint()).toEqual(before);
    });

    it('T12/T13 one book per code under concurrent and repeated creates', async () => {
      const [a, b] = await Promise.all([
        admin('POST', API, book({ code: 'Z27', name: 'Race A', short: 'RA' })),
        admin('POST', API, book({ code: 'Z27', name: 'Race B', short: 'RB' })),
      ]);
      expect([a.statusCode, b.statusCode].sort()).toEqual([201, 400]);
      const loser = a.statusCode === 400 ? a : b;
      const winner = (await header('Z27'))[0]!.BOOK_NAME;
      expect(loser.json().message).toBe(
        `This Book Code already Exist in  '${winner}'  Book Name... Please Change Book Code...`,
      );
      expect(await detail('Z27')).toHaveLength(2);

      const [c, d] = await Promise.all([
        admin('POST', API, book({ code: 'Z28', name: 'Race Name', short: 'R8' })),
        admin('POST', API, book({ code: 'Z29', name: 'Race Name', short: 'R9' })),
      ]);
      expect([c.statusCode, d.statusCode].sort()).toEqual([201, 400]);
      const names: Array<{ n: number }> = await query(
        `SELECT count(*)::int n FROM "BOOK_DATA" WHERE tenant_id=$1 AND "BOOK_NAME"='Race Name'`,
        tenantId,
      );
      expect(names).toEqual([{ n: 1 }]);

      // The same create sent twice (double click, lost answer) leaves one header and one slot set.
      const payload = book({ code: 'Z30', name: 'Twice Sent', short: 'TS' });
      const first = await admin('POST', API, payload);
      expect(first.statusCode, first.body).toBe(201);
      const second = await admin('POST', API, payload);
      expect([201, 400]).toContain(second.statusCode);
      expect(await header('Z30')).toHaveLength(1);
      expect(await detail('Z30')).toHaveLength(2);
    });
  },
);
