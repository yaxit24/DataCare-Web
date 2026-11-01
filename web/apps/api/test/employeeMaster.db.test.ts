import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { deleteEmployee } from '../src/modules/masters/employeeMaster.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N211 / G224: the Employee master (desktop MS_EMP, opened by MDI_FORM.cs:7660-7669) through the real Fastify routes
 * on a forced-RLS database. Expected values come from the desktop source:
 *
 * - The list is EMP_MAST of the company ORDER BY EMP_NAME (MS_EMP.cs:1144), and ORDER BY EMP_CODE after a delete
 *   (:1579). The next code is '001' for a company without employees, else the highest code + 1 as "000" (:1260-1268).
 *   The user list is a blank entry and LOGIN_MAST's login names of company '01' (AddCboItem :1152-1177).
 * - BtnSave_Click (:1462-1550) needs the edit right only for an opened employee, refuses a blank code and name with
 *   "Enter Employee Detail", and replaces the row: code, name, account, Val(amount), Val(day hours), the user or 'ABC'
 *   when blank, and MainUser: the operator for a new entry (CLEAR_DATA :1253), the creator for an opened one (:1293).
 * - Leaving the code refuses a code another employee has (:1350-1370); leaving the name, a name another code has
 *   (:1391-1411). Typed text is upper-cased and the apostrophe dropped (:1319-1332).
 * - BtnDelete_Click (:1552-1584) needs the delete right, refuses a blank code and the default employee '001'.
 * - BtnPrint_Click (:1585-1599) needs the print right. The account help lists groups 09, 10 and 45 without 00020,
 *   ordered by group and name, and an exactly typed code of any group is taken (:1631-1680).
 * Web rule on purpose (gap G224): an opened employee carries its version (N51 tokens); a stale one is refused with 409.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'employee-master-db';
const otherTenant = 'employee-master-db-other';
const PASSWORD = 'Employee-Master!2026';
const SECRET = 'employee-master-routes-test-signing-secret-thirty-two';
const ADMIN = 'emadmin';
const CLERK = 'emclerk';
const NOBODY = 'emnone';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const ACCOUNTS = [
  ['50001', 'STAFF SALARY', '45'],
  ['50002', 'STAFF ADVANCE', '10'],
  ['50003', 'COUNTER CASH', '09'],
  ['00020', 'STAFF EXCLUDED', '10'],
  ['50004', 'STAFF DEBTOR', '01'],
] as const;

type Cookie = string;
type EmpRow = {
  co: string;
  code: string;
  name: string;
  ac: string;
  amt: number;
  hours: number;
  user: string;
  main: string;
  type: string | null;
  tds: number;
  pf: number;
};

(enabled ? describe : describe.skip)(
  'N211 Employee master is the desktop MS_EMP through HTTP',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    let adminCookie: Cookie;
    let clerkCookie: Cookie;
    let nobodyCookie: Cookie;

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
    const employees = () =>
      query<EmpRow[]>(
        `SELECT "CO_CODE" co,"EMP_CODE" code,"EMP_NAME" name,coalesce("EMP_AC",'') ac,"EMP_AMT"::float amt,
              "DAY_HOURS"::float hours,"USER_NAME" "user",coalesce("MAIN_USER",'') main,"EMP_TYPE" "type",
              "TDS_PRC"::float tds,"PF_PRC"::float pf
         FROM "EMP_MAST" WHERE tenant_id=$1 ORDER BY "EMP_CODE","row_id"`,
        tenantId,
      );
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
    const VERSION = /^[0-9a-f]{64}$/;
    const versionOf = async (code: string, cookie = adminCookie): Promise<string> => {
      const response = await request(cookie, 'GET', `/masters/employee-master/${code}`);
      expect(response.statusCode, response.body).toBe(200);
      return response.json().version;
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
      // Another tenant's employee of the same company code must never be listed, numbered or replaced.
      await exec(
        `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME","USER_NAME") VALUES ($1,'01','009','OTHER TENANT','ABC')`,
        otherTenant,
      );
      const passwordHash = await hashPassword(PASSWORD);
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01',$2,$5,'ADMIN','Y','Y','Y','N'),($1,'01',$3,$5,'USER','Y','N','N','N'),
              ($1,'01',$4,$5,'USER','Y','Y','Y','N'),($1,'02','otherco',$5,'USER','Y','Y','Y','N')`,
        tenantId,
        ADMIN,
        CLERK,
        NOBODY,
        passwordHash,
      );
      // The clerk's desktop rights row: SUB_MENU is the menu button's caption 'Employee' (MDI_FORM.cs:7660), view only.
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES ($1,'01','01',$2,'Master','Employee','Y','N','N','N')`,
        tenantId,
        CLERK,
      );
      app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
      adminCookie = await login(ADMIN);
      clerkCookie = await login(CLERK);
      nobodyCookie = await login(NOBODY);
    });

    afterAll(async () => {
      if (app) await app.close();
      if (owner) await wipe();
      if (runtime) await runtime.$disconnect();
      if (owner) await owner.$disconnect();
    });

    it("opens a company without employees with code '001', the company-01 login names and the admin's rights", async () => {
      const response = await request(adminCookie, 'GET', '/masters/employee-master');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({
        rows: [],
        nextCode: '001',
        users: ['', ADMIN, CLERK, NOBODY],
        rights: { canUpdate: true, canDelete: true, canPrint: true },
      });
    });

    it("saves a new employee upper-cased, with Val of the boxes, 'ABC' for a blank user and the operator as creator", async () => {
      const response = await request(adminCookie, 'POST', '/masters/employee-master', {
        code: '001',
        name: "ramesh pa'tel",
        account: '50001',
        amount: '12500.555',
        dayHours: ' 8.5 hrs',
        user: '',
      });
      expect(response.statusCode, response.body).toBe(201);
      expect(response.json()).toEqual({ code: '001' });
      expect(await employees()).toEqual([
        {
          co: '01',
          code: '001',
          name: 'RAMESH PATEL',
          ac: '50001',
          amt: 12500.555,
          hours: 8.5,
          user: 'ABC',
          main: ADMIN,
          type: null,
          tds: 0,
          pf: 0,
        },
      ]);
    });

    it('numbers the next employee from the highest code and lists by name, or by code', async () => {
      let response = await request(adminCookie, 'GET', '/masters/employee-master');
      expect(response.json()).toMatchObject({ nextCode: '002' });
      for (const [code, name, account, user] of [
        ['002', 'ANIL SHAH', '50002', CLERK],
        ['003', 'BHAVIN', '', ''],
      ]) {
        response = await request(adminCookie, 'POST', '/masters/employee-master', {
          code,
          name,
          account,
          amount: '',
          dayHours: '',
          user,
        });
        expect(response.statusCode, response.body).toBe(201);
      }
      response = await request(adminCookie, 'GET', '/masters/employee-master');
      expect(response.json()).toMatchObject({
        nextCode: '004',
        rows: [
          { code: '002', name: 'ANIL SHAH' },
          { code: '003', name: 'BHAVIN' },
          { code: '001', name: 'RAMESH PATEL' },
        ],
      });
      response = await request(adminCookie, 'GET', '/masters/employee-master?order=code');
      expect(response.json().rows.map((row: { code: string }) => row.code)).toEqual([
        '001',
        '002',
        '003',
      ]);
      expect((await employees()).find((row) => row.code === '002')).toMatchObject({
        user: CLERK,
        ac: '50002',
        amt: 0,
        hours: 0,
      });
    });

    it('refuses what MS_EMP refuses, with its texts, and writes nothing', async () => {
      const before = await employees();
      const refusals: Array<[Record<string, unknown>, string]> = [
        [
          { code: '002', name: 'NEW GUY' },
          "This Employee Code already Exist in  'ANIL SHAH'  Employee Name...Please Change Employee Code...",
        ],
        [
          { code: '004', name: 'anil shah' },
          "This Employee Name already Exist in  '002'  Employee Code...Please Change Employee Name...",
        ],
        [{ code: '', name: '' }, 'Enter Employee Detail'],
        [{ code: '004', name: '  ' }, 'Please Insert Employee Name ...'],
        [
          { code: '004', name: 'NEW GUY', account: '99999' },
          'account 99999 is not in the account master',
        ],
        [{ code: '004', name: 'NEW GUY', user: 'otherco' }, 'user otherco is not in the user list'],
        [{ code: '0004', name: 'NEW GUY' }, 'employee code must be 1 to 3 characters'],
        [{ code: '004', name: 'N'.repeat(41) }, 'employee name must be at most 40 characters'],
      ];
      for (const [payload, message] of refusals) {
        const response = await request(adminCookie, 'POST', '/masters/employee-master', payload);
        expect(response.statusCode, `${JSON.stringify(payload)} ${response.body}`).toBe(400);
        expect(response.json().message).toBe(message);
      }
      expect(await employees()).toEqual(before);
    });

    it('reads one employee with its account name, and answers 404 for an unknown code', async () => {
      let response = await request(adminCookie, 'GET', '/masters/employee-master/002');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({
        code: '002',
        name: 'ANIL SHAH',
        user: CLERK,
        account: '50002',
        accountName: 'STAFF ADVANCE',
        amount: 0,
        dayHours: 0,
        mainUser: ADMIN,
        version: expect.stringMatching(VERSION),
      });
      response = await request(adminCookie, 'GET', '/masters/employee-master/999');
      expect(response.statusCode).toBe(404);
      expect(response.json()).toMatchObject({ error: 'employee-not-found' });
    });

    it('updates an opened employee in place, keeping its creator, type, TDS and PF', async () => {
      await exec(
        `UPDATE "EMP_MAST" SET "MAIN_USER"='origuser',"EMP_TYPE"='S',"TDS_PRC"=1.5,"PF_PRC"=12
        WHERE tenant_id=$1 AND "EMP_CODE"='002'`,
        tenantId,
      );
      const response = await request(adminCookie, 'PUT', '/masters/employee-master/002', {
        name: 'anil m shah',
        account: '50003',
        amount: '15000',
        dayHours: '9',
        user: '',
        expectedVersion: await versionOf('002'),
      });
      expect(response.statusCode, response.body).toBe(200);
      const rows = (await employees()).filter((row) => row.code === '002');
      expect(rows).toEqual([
        {
          co: '01',
          code: '002',
          name: 'ANIL M SHAH',
          ac: '50003',
          amt: 15000,
          hours: 9,
          user: 'ABC',
          main: 'origuser',
          type: 'S',
          tds: 1.5,
          pf: 12,
        },
      ]);
    });

    it('replaces an employee saved again as a new entry under its own code and name, as the operator', async () => {
      await exec(
        `UPDATE "EMP_MAST" SET "MAIN_USER"='origuser' WHERE tenant_id=$1 AND "EMP_CODE"='003'`,
        tenantId,
      );
      const response = await request(adminCookie, 'POST', '/masters/employee-master', {
        code: '003',
        name: 'BHAVIN',
        amount: '100',
        dayHours: '',
        user: NOBODY,
      });
      expect(response.statusCode, response.body).toBe(201);
      expect((await employees()).filter((row) => row.code === '003')).toEqual([
        expect.objectContaining({ name: 'BHAVIN', amt: 100, user: NOBODY, main: ADMIN }),
      ]);
    });

    it("follows the clerk's desktop 'Employee' rights row: view and add, but no edit, delete or print", async () => {
      let response = await request(clerkCookie, 'GET', '/masters/employee-master');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json().rights).toEqual({
        canUpdate: false,
        canDelete: false,
        canPrint: false,
      });
      response = await request(clerkCookie, 'POST', '/masters/employee-master', {
        code: '004',
        name: 'CLERK MADE',
        amount: '1',
        dayHours: '1',
        user: '',
      });
      expect(response.statusCode, response.body).toBe(201);
      expect((await employees()).find((row) => row.code === '004')).toMatchObject({ main: CLERK });
      response = await request(clerkCookie, 'PUT', '/masters/employee-master/004', {
        name: 'CLERK EDIT',
        expectedVersion: await versionOf('004', clerkCookie),
      });
      expect(response.statusCode).toBe(403);
      response = await request(clerkCookie, 'DELETE', '/masters/employee-master/004');
      expect(response.statusCode).toBe(403);
      response = await request(clerkCookie, 'GET', '/masters/employee-master/print');
      expect(response.statusCode).toBe(403);
      expect((await employees()).find((row) => row.code === '004')).toMatchObject({
        name: 'CLERK MADE',
      });
      // A user without an Employee rights row cannot open the screen.
      response = await request(nobodyCookie, 'GET', '/masters/employee-master');
      expect(response.statusCode).toBe(403);
    });

    it('refuses an edit or delete of an employee changed meanwhile, a replayed edit and an edit without a version', async () => {
      const opened = await versionOf('003');
      const second = await versionOf('003');
      expect(second).toBe(opened);
      let response = await request(adminCookie, 'PUT', '/masters/employee-master/003', {
        name: 'BHAVIN K',
        amount: '100',
        user: NOBODY,
        expectedVersion: opened,
      });
      expect(response.statusCode, response.body).toBe(200);
      const saved = await employees();
      // The other operator's save, and the same request sent again, carry a spent version.
      for (const payload of [
        { name: 'BHAVIN X', expectedVersion: second },
        { name: 'BHAVIN K', amount: '100', user: NOBODY, expectedVersion: opened },
      ]) {
        response = await request(adminCookie, 'PUT', '/masters/employee-master/003', payload);
        expect(response.statusCode, response.body).toBe(409);
        expect(response.json()).toEqual({
          error: 'employee-version-conflict',
          message:
            'This employee was changed by someone else after you opened it. Open it again before saving or deleting.',
        });
      }
      response = await request(
        adminCookie,
        'DELETE',
        `/masters/employee-master/003?expectedVersion=${second}`,
      );
      expect(response.statusCode, response.body).toBe(409);
      response = await request(adminCookie, 'PUT', '/masters/employee-master/003', {
        name: 'NO VERSION',
      });
      expect(response.statusCode, response.body).toBe(400);
      expect(await employees()).toEqual(saved);
      expect(saved.find((row) => row.code === '003')).toMatchObject({ name: 'BHAVIN K', amt: 100 });
    });

    it('refuses to save an opened employee that another operator deleted, instead of bringing it back', async () => {
      const created = await request(adminCookie, 'POST', '/masters/employee-master', {
        code: '005',
        name: 'TEMP WORKER',
      });
      expect(created.statusCode, created.body).toBe(201);
      const opened = await versionOf('005');
      let response = await request(
        adminCookie,
        'DELETE',
        `/masters/employee-master/005?expectedVersion=${opened}`,
      );
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({ code: '005', deleted: 1 });
      response = await request(adminCookie, 'PUT', '/masters/employee-master/005', {
        name: 'TEMP WORKER',
        expectedVersion: opened,
      });
      expect(response.statusCode, response.body).toBe(409);
      expect((await employees()).some((row) => row.code === '005')).toBe(false);
    });

    it('lists the account help of groups 09, 10 and 45 without 00020, and takes a typed code of any group', async () => {
      let response = await request(adminCookie, 'GET', '/masters/employee-master/accounts?q=STAFF');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual([
        { code: '50002', name: 'STAFF ADVANCE', group: '10' },
        { code: '50001', name: 'STAFF SALARY', group: '45' },
      ]);
      response = await request(adminCookie, 'GET', '/masters/employee-master/accounts?q=');
      expect(response.json().map((row: { code: string }) => row.code)).toEqual([
        '50003',
        '50002',
        'WALKIN',
        '50001',
      ]);
      response = await request(adminCookie, 'GET', '/masters/employee-master/accounts?q=50004');
      expect(response.json()[0]).toEqual({ code: '50004', name: 'STAFF DEBTOR', group: '01' });
    });

    it('prints the company employees in code order', async () => {
      const response = await request(adminCookie, 'GET', '/masters/employee-master/print');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json().rows).toEqual([
        {
          code: '001',
          name: 'RAMESH PATEL',
          user: 'ABC',
          account: '50001',
          amount: 12500.555,
          dayHours: 8.5,
        },
        {
          code: '002',
          name: 'ANIL M SHAH',
          user: 'ABC',
          account: '50003',
          amount: 15000,
          dayHours: 9,
        },
        { code: '003', name: 'BHAVIN K', user: NOBODY, account: '', amount: 100, dayHours: 0 },
        { code: '004', name: 'CLERK MADE', user: 'ABC', account: '', amount: 1, dayHours: 1 },
      ]);
    });

    it("refuses to delete the default employee '001' or a blank code, deletes another and lists by code", async () => {
      let response = await request(adminCookie, 'DELETE', '/masters/employee-master/001');
      expect(response.statusCode, response.body).toBe(400);
      expect(response.json().message).toBe(
        'You Cant Delete Record, This Empoyee Is Default Empoyee....',
      );
      await expect(deleteEmployee(runtime, { tenantId, coCode: '01' }, '  ')).rejects.toThrow(
        'Please Select Employee For Delete.',
      );
      response = await request(adminCookie, 'DELETE', '/masters/employee-master/004');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({ code: '004', deleted: 1 });
      response = await request(adminCookie, 'GET', '/masters/employee-master?order=code');
      expect(response.json()).toMatchObject({
        nextCode: '004',
        rows: [
          { code: '001', name: 'RAMESH PATEL' },
          { code: '002', name: 'ANIL M SHAH' },
          { code: '003', name: 'BHAVIN K' },
        ],
      });
      const other = await query<Array<{ n: number }>>(
        `SELECT count(*)::int n FROM "EMP_MAST" WHERE tenant_id=$1 AND "EMP_CODE"='009'`,
        otherTenant,
      );
      expect(other[0]?.n).toBe(1);
    });
  },
);
