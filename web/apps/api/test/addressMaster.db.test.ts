import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { maskedDate } from '../src/modules/masters/addressMaster.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N217 / G230: the Address master (desktop MS_ADD_MAST, opened by MDI_FORM.cs:7610-7619) through the real Fastify
 * routes on a forced-RLS database. Expected values come from the desktop source:
 *
 * - The list is the location's ADD_MAST rows ordered by AC_CODE (MS_ADD_MAST_Load, MS_ADD_MAST.cs:3119-3396); typing a
 *   name lists up to 99 of the company's addresses whose name starts with it (tAcName_KeyUp :4171-4294).
 * - BtnSave_Click (:4411-4515) refuses a blank code or name ("Please Select Customer name and try...."), replaces the
 *   code's row of the location with every box upper-cased (:3604-3617), a date box that is not a date as NULL, MAIN_USER
 *   (the user for a new address, the stored one for an opened address) and DATA_TRFR 'N'. Leaving the name refuses a
 *   name another code has (:4389-4409). Enter on the mobile of a new entry refuses a mobile the company has (:3867-3887).
 * - BtnDelete_Click (:4517-4544) refuses a blank code and deletes the address with its book-000 OP_DATA and AC_DATA rows
 *   of the year. The combos list the company's distinct values and the states with STATE_MAST's (:3939-4046).
 * Web rules on purpose (gap G230): the next code is the location prefix and four digits; one transaction; versions.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'address-master-db';
const otherTenant = 'address-master-db-other';
const PASSWORD = 'Address-Master-Routes!2026';
const SECRET = 'address-master-routes-test-signing-secret-over-thirty';
const ADMIN = 'adadmin';
const CLERK = 'adclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const RIGHTS_SUB_MENU = 'Address';

type Cookie = string;

(enabled ? describe : describe.skip)(
  'N217 Address master is the desktop MS_ADD_MAST through HTTP',
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
    const addressRow = async (code: string) =>
      (
        await query<any[]>(
          `SELECT "LC_CODE" lc,"AC_CODE" code,"AC_NAME" name,"AC_GR" grp,"AC_PERSON" person,"AC_ADD1" a1,"AC_ADD2" a2,"AC_ADD3" a3,
                "AC_CITY" city,"AC_PIN" pin,"AC_AREA" area,"AC_COUNTRY" country,"AC_STATE" state,"AC_DISTRICT" district,
                "AC_PHONE" phone,"AC_PHONE2" phone2,"AC_MOBILE" mobile,"AC_MOBILE2" mobile2,"AC_EMAIL" email,
                "BR_DATE" br,"AN_DATE" an,to_char("L_BR_DATE",'YYYY-MM-DD') lbr,"MAIN_USER" main,"DATA_TRFR" trfr
           FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"=$2 ORDER BY row_id`,
          tenantId,
          code,
        )
      ).map((r) => r);
    const allAddresses = () =>
      query<unknown[]>(
        `SELECT to_jsonb(a) AS r FROM "ADD_MAST" a WHERE tenant_id=$1 ORDER BY "AC_CODE",row_id`,
        tenantId,
      );
    const VERSION = /^[0-9a-f]{64}$/;
    const versionOf = async (code: string): Promise<string> => {
      const response = await request(adminCookie, 'GET', `/masters/address-master/${code}`);
      expect(response.statusCode, response.body).toBe(200);
      return response.json().version;
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
    const full = (extra: Record<string, unknown> = {}) => ({
      name: "r'amesh shah",
      group: 'customer',
      mobile: '9876543210',
      phone: '0261-2345678',
      person: 'suresh',
      address1: '12 ring road',
      address2: 'near market',
      address3: 'block b',
      city: 'surat',
      pin: '395002',
      area: 'adajan',
      country: 'india',
      state: 'gujarat',
      district: 'surat',
      email: 'ramesh@example.com',
      mobile2: '9123456780',
      phone2: '0261-1111111',
      birthDate: '15/08/1990',
      anniversary: '31/02/2020',
      lBirthDate: '01/01/1960',
      ...extra,
    });

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      await exec(`DELETE FROM "ADD_MAST" WHERE tenant_id=$1`, tenantId);
      await exec(
        `INSERT INTO "ADD_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_MOBILE","AC_STATE","MAIN_USER") VALUES
       ($1,'01','02','020001','OTHER LOCATION','9000000002','MAHARASHTRA','DESKUSER')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "ADD_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,'01','01','010001','OTHER TENANT')`,
        otherTenant,
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
       VALUES ($1,'01','01',$2,'Master',$3,'Y','N','N','N')`,
        tenantId,
        CLERK,
        RIGHTS_SUB_MENU,
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

    it('reads a masked date box as the desktop IsDate does', () => {
      expect(maskedDate('15/08/1990')).toEqual({ text: '15/08/1990', iso: '1990-08-15' });
      expect(maskedDate('1/2/2020')).toEqual({ text: '01/02/2020', iso: '2020-02-01' });
      expect(maskedDate('31/02/2020')).toBeNull();
      expect(maskedDate('  /  /    ')).toBeNull();
      expect(maskedDate('')).toBeNull();
    });

    it("lists the location's addresses with the rights, the combos and the next code", async () => {
      const response = await request(adminCookie, 'GET', '/masters/address-master');
      expect(response.statusCode, response.body).toBe(200);
      const body = response.json();
      expect(body.rows).toEqual([]);
      expect(body.nextCode).toBe('010001');
      expect(body.rights).toEqual({ canUpdate: true, canDelete: true, canPrint: true });
      expect(body.combos.states).toContain('MAHARASHTRA');
    });

    it('saves a new address with every box upper-cased, the dates as the desktop writes them, and the user', async () => {
      const response = await request(adminCookie, 'POST', '/masters/address-master', {
        code: '010001',
        ...full(),
      });
      expect(response.statusCode, response.body).toBe(201);
      expect(await addressRow('010001')).toEqual([
        {
          lc: '01',
          code: '010001',
          name: 'RAMESH SHAH',
          grp: 'CUSTOMER',
          person: 'SURESH',
          a1: '12 RING ROAD',
          a2: 'NEAR MARKET',
          a3: 'BLOCK B',
          city: 'SURAT',
          pin: '395002',
          area: 'ADAJAN',
          country: 'INDIA',
          state: 'GUJARAT',
          district: 'SURAT',
          phone: '0261-2345678',
          phone2: '0261-1111111',
          mobile: '9876543210',
          mobile2: '9123456780',
          email: 'RAMESH@EXAMPLE.COM',
          br: '15/08/1990',
          an: null,
          lbr: '1960-01-01',
          main: ADMIN,
          trfr: 'N',
        },
      ]);
      const list = await request(adminCookie, 'GET', '/masters/address-master');
      expect(list.json().rows).toEqual([
        {
          code: '010001',
          name: 'RAMESH SHAH',
          group: 'CUSTOMER',
          address: '12 RING ROAD',
          phone: '0261-2345678',
          mobile: '9876543210',
        },
      ]);
      expect(list.json().nextCode).toBe('010002');
      expect(list.json().combos.cities).toContain('SURAT');
    });

    it('reads one address with its boxes, lists name matches company-wide and checks a mobile', async () => {
      let response = await request(adminCookie, 'GET', '/masters/address-master/010001');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toMatchObject({
        code: '010001',
        name: 'RAMESH SHAH',
        city: 'SURAT',
        birthDate: '15/08/1990',
        anniversary: '',
        lBirthDate: '01/01/1960',
        version: expect.stringMatching(VERSION),
      });
      response = await request(adminCookie, 'GET', '/masters/address-master/names?q=o');
      expect(response.json()).toEqual([{ code: '020001', name: 'OTHER LOCATION' }]);
      response = await request(adminCookie, 'GET', '/masters/address-master/mobile?no=9000000002');
      expect(response.json()).toEqual({ taken: { name: 'OTHER LOCATION' } });
      response = await request(adminCookie, 'GET', '/masters/address-master/mobile?no=9999999999');
      expect(response.json()).toEqual({ taken: null });
    });

    it('refuses what MS_ADD_MAST refuses with its texts, and writes nothing', async () => {
      const before = await allAddresses();
      const cases: Array<[Record<string, unknown>, string]> = [
        [{ code: '', ...full() }, 'Please Select Customer name and try....'],
        [{ code: '010002', ...full({ name: ' ' }) }, 'Please Select Customer name and try....'],
        [
          { code: '010002', ...full({ name: 'ramesh shah' }) },
          "This Ac Name already Exist in  '010001'  Ac Code... Please Change Account Name...",
        ],
        [
          { code: '010002', ...full({ name: 'NEW', pin: '123456789' }) },
          'AC_PIN must be at most 8 characters',
        ],
      ];
      for (const [payload, message] of cases) {
        const response = await request(adminCookie, 'POST', '/masters/address-master', payload);
        expect(response.statusCode, JSON.stringify(payload)).toBe(400);
        expect(response.json().message, JSON.stringify(payload)).toBe(message);
      }
      expect(await allAddresses()).toEqual(before);
    });

    it('an edit keeps the stored MAIN_USER and needs the current version', async () => {
      await exec(
        `UPDATE "ADD_MAST" SET "MAIN_USER"='DESKUSER' WHERE tenant_id=$1 AND "AC_CODE"='010001'`,
        tenantId,
      );
      const opened = await versionOf('010001');
      let response = await request(adminCookie, 'PUT', '/masters/address-master/010001', {
        ...full({ city: 'navsari' }),
        expectedVersion: opened,
      });
      expect(response.statusCode, response.body).toBe(200);
      expect((await addressRow('010001'))[0]).toMatchObject({ city: 'NAVSARI', main: 'DESKUSER' });
      response = await request(adminCookie, 'PUT', '/masters/address-master/010001', {
        ...full({ city: 'vapi' }),
        expectedVersion: opened,
      });
      expect(response.statusCode).toBe(409);
      expect(response.json().error).toBe('address-version-conflict');
      response = await request(adminCookie, 'PUT', '/masters/address-master/010001', full());
      expect(response.statusCode).toBe(400);
      expect((await addressRow('010001'))[0]).toMatchObject({ city: 'NAVSARI' });
    });

    it("follows the clerk's view-only rights row: list and add, but no edit, delete or print", async () => {
      let response = await request(clerkCookie, 'GET', '/masters/address-master');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json().rights).toEqual({
        canUpdate: false,
        canDelete: false,
        canPrint: false,
      });
      response = await request(clerkCookie, 'POST', '/masters/address-master', {
        code: '010002',
        ...full({ name: 'clerk address', mobile: '' }),
      });
      expect(response.statusCode, response.body).toBe(201);
      response = await request(clerkCookie, 'PUT', '/masters/address-master/010002', {
        ...full({ name: 'clerk edit' }),
        expectedVersion: await versionOf('010002'),
      });
      expect(response.statusCode).toBe(403);
      response = await request(clerkCookie, 'DELETE', '/masters/address-master/010002');
      expect(response.statusCode).toBe(403);
      response = await request(clerkCookie, 'GET', '/masters/address-master/print');
      expect(response.statusCode).toBe(403);
      expect((await addressRow('010002')).map((r) => [r.name, r.main])).toEqual([
        ['CLERK ADDRESS', CLERK],
      ]);
    });

    it('deletes an address with its opening rows of the year, refuses a blank code, and leaves others alone', async () => {
      await exec(
        `INSERT INTO "OP_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","OP_AMT","OP_SIGN")
       VALUES ($1,'01','01',$2,'000','00001','010002',500,'D')`,
        tenantId,
        YEAR,
      );
      let response = await request(adminCookie, 'DELETE', '/masters/address-master/%20');
      expect(response.statusCode).toBe(400);
      expect(response.json().message).toBe('Please Select AcCode For Delete.');
      response = await request(
        adminCookie,
        'DELETE',
        `/masters/address-master/010002?expectedVersion=${await versionOf('010002')}`,
      );
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({ code: '010002', deleted: 1 });
      expect(await addressRow('010002')).toEqual([]);
      const opening = await query<Array<{ n: number }>>(
        `SELECT count(*)::int n FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"='010002'`,
        tenantId,
      );
      expect(opening[0]!.n).toBe(0);
      expect(await addressRow('020001')).toHaveLength(1);
      const other = await query<Array<{ n: number }>>(
        `SELECT count(*)::int n FROM "ADD_MAST" WHERE tenant_id=$1`,
        otherTenant,
      );
      expect(other[0]!.n).toBe(1);
      response = await request(adminCookie, 'GET', '/masters/address-master/print');
      expect(response.json().rows.map((r: { code: string }) => r.code)).toEqual(['010001']);
    });
  },
);
