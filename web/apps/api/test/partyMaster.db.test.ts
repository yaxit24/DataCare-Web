import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N223 / G236: the Party master (desktop MS_ACCT, opened by MDI_FORM.cs:7600-7609) through the real Fastify routes on a
 * forced-RLS database. Expected values come from the desktop source:
 *
 * - The list at a location other than 00 is the company's codes below 100 and the location's codes from 200
 *   (MS_ACCT_Load :5944-5958); the next code is the location's second character and five digits, 00201 first
 *   (CLEAR_DATA :6290-6315, AC_LC_CODE_LEN blank is 1).
 * - BtnSave_Click (:7650-7962) upper-cases every box but the email (:6606-6619, :5050), writes AC_TYPE's first letter,
 *   AC_GST_TYPE I or L, Val() of the number boxes, Y/N flags, a date box that is not a date as NULL, MAIN_USER,
 *   DATA_TRFR 'N' and VISIT_TRAN 'AC'; a new entry's opening goes to OP_DATA (book 000, voucher 00000, DATA_TRFR 'Y')
 *   with the AcOp_Ledr legs, and AC_MAST_SRNO gets the code's row. Its refusals use the desktop's texts.
 * - BtnDelete_Click (:7963-8025) refuses a code used outside the opening voucher and a software default account, and
 *   deletes AC_MAST_SRNO, AC_MAST and the year's book-000 OP_DATA and AC_DATA rows.
 * - The Enter checks (mobile :6893, mobile 2 :6930, short name :7230, GST number :6978) and the helps.
 * Web rules on purpose (gap G236): one transaction, versions, read-only opening on an opened party.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'party-master-db';
const otherTenant = 'party-master-db-other';
const PASSWORD = 'Party-Master-Routes!2026';
const SECRET = 'party-master-routes-test-signing-secret-over-thirty';
const ADMIN = 'pmadmin';
const CLERK = 'pmclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;

type Cookie = string;

(enabled ? describe : describe.skip)(
  'N223 Party master is the desktop MS_ACCT through HTTP',
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
    const partyRow = async (code: string) =>
      query<any[]>(
        `SELECT "LC_CODE" lc,"AC_CODE" code,"AC_NAME" name,"AC_GR" grp,"AC_MAIN_GR" main_gr,"AC_TYPE" typ,"AC_MOBILE" mobile,
              "AC_PHONE" phone,"AC_PERSON" person,"AC_SHORT" short,"AC_ADD1" a1,"AC_CITY" city,"AC_PIN" pin,"AC_AREA" area,
              "AC_GSTNO" gst,"AC_GST_TYPE" gst_type,"AC_PANNO" pan,"LCS_NO" lcs,"AC_STATE" state,"AC_DISTRICT" district,
              "MAIN_AC_CODE" main_ac,"AC_REF_CODE" ref,"AC_REF_NAME" ref_name,"AC_MOBILE2" mobile2,"AC_ADHAR_NO" aadhaar,
              "PASSPORT_NO" passport,"AC_COUNTRY" country,"BANK_NAME" bank,"BANK_RTGS_NO" rtgs,"AC_EMAIL" email,
              "AC_KHATA_NO" khata,"AC_CR_DAYS" cr_days,"DPC_PRC"::text dpc,"AC_INT_PRC"::text int_prc,
              "AMT_LIMIT"::text amt_limit,"DEFAULTER_AC" defaulter,"WITH_TDS_TAX" tds,"AC_WITH_MEMB_COM" memb,
              "AC_SHARE_HOLDER_COM" share,"BR_DATE" br,"AN_DATE" an,to_char("L_BR_DATE",'YYYY-MM-DD') lbr,
              "LAST_VISIT" visit,"LAST_DATE" ldr,"MAIN_USER" main,"DATA_TRFR" trfr,"VISIT_TRAN" visit_tran
         FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"=$2 ORDER BY row_id`,
        tenantId,
        code,
      );
    const count = async (table: string, code: string) =>
      (
        await query<Array<{ n: number }>>(
          `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
          tenantId,
          code,
        )
      )[0]!.n;
    const snapshot = () =>
      query<unknown[]>(
        `SELECT (SELECT jsonb_agg(to_jsonb(a) - 'row_id' ORDER BY a."AC_CODE") FROM "AC_MAST" a WHERE tenant_id=$1) m,
              (SELECT jsonb_agg(to_jsonb(s) - 'row_id' ORDER BY s."AC_CODE") FROM "AC_MAST_SRNO" s WHERE tenant_id=$1) s,
              (SELECT count(*) FROM "OP_DATA" WHERE tenant_id=$1) o, (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1) d`,
        tenantId,
      );
    const VERSION = /^[0-9a-f]{64}$/;
    const versionOf = async (code: string): Promise<string> => {
      const response = await request(adminCookie, 'GET', `/masters/party-master/${code}`);
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
      group: '10',
      acType: 'B',
      mobile: '9876543210',
      phone: '0261-2345678',
      person: 'suresh',
      short: 'rsh',
      address1: '12 ring road',
      city: 'surat',
      pin: '395002',
      area: 'adajan',
      gstNo: '27abcde1234f1z5',
      gstType: 'I',
      panNo: 'abcde1234f',
      lcsNo: 'lcs-77',
      state: 'maharashtra',
      district: 'surat',
      mainAcCode: '',
      refCode: '',
      refName: '',
      mobile2: '9123456780',
      aadhaar: '123412341234',
      passport: 'p1234567',
      country: 'india',
      bankName: 'state bank',
      rtgs: 'sbin0001234',
      email: 'Ramesh@Example.com',
      khata: 'k-12',
      crDays: '30',
      dpcPrc: '1.5',
      intPrc: '2.25',
      amtLimit: '',
      withTds: true,
      member: true,
      shareHolder: false,
      defaulter: false,
      birthDate: '15/08/1990',
      anniversary: '31/02/2020',
      lBirthDate: '01/01/1960',
      lastVisit: '02/11/2026',
      ledgerDate: '  /  /    ',
      ...extra,
    });

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      await exec(
        `UPDATE "CO_MAST" SET "CO_STATE"='GUJARAT',"CO_STATE_CODE"='24' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        tenantId,
      );
      await exec(
        `INSERT INTO "AC_GROUP"(tenant_id,"CO_CODE","AC_GR","AC_GR_NAME","AC_SUB_GR","AC_MAIN_GR") VALUES
         ($1,'01','10','SUNDRY DEBTORS','CURRENT ASSETS','A'),($1,'01','11','SUNDRY CREDITORS','CURRENT LIAB','L')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "STATE_MAST"(tenant_id,"STATE_CODE","STATE_NAME") VALUES ($1,'24','GUJARAT'),($1,'27','MAHARASHTRA')`,
        tenantId,
      );
      // A company-wide default account at location 00, a location code below 200 (hidden), another location's party,
      // an address to copy and a party of another tenant.
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_MOBILE","AC_SHORT") VALUES
         ($1,'01','00','05','CASH IN HAND','10','',''),
         ($1,'01','01','150','HIDDEN LOCATION CODE','10','',''),
         ($1,'01','02','200201','OTHER LOCATION PARTY','10','9000000002','OLP')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "ADD_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_ADD1","AC_CITY","AC_MOBILE","BR_DATE") VALUES
         ($1,'01','01','010001','ADDRESS BOOK NAME','5 STATION ROAD','VAPI','9111111111','10/10/1985')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,'01','01','100201','OTHER TENANT')`,
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
       VALUES ($1,'01','01',$2,'Master','Party','Y','N','N','N')`,
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

    it('lists the company codes below 100 and the location codes from 200, with the next code and rights', async () => {
      const response = await request(adminCookie, 'GET', '/masters/party-master');
      expect(response.statusCode, response.body).toBe(200);
      const body = response.json();
      const codes: string[] = body.rows.map((r: { code: string }) => r.code);
      expect(codes).toContain('05');
      expect(codes).not.toContain('150');
      expect(codes).not.toContain('200201');
      // The seeded accounts have codes that are not numbers; they stay in their location's list.
      expect(codes).toContain('CASH');
      expect(body.nextCode).toBe('100201');
      expect(body.allBranch).toBe(false);
      expect(body.coState).toBe('GUJARAT');
      expect(body.rights).toEqual({ canUpdate: true, canDelete: true, canPrint: true });
      expect(body.combos.states).toEqual(expect.arrayContaining(['GUJARAT', 'MAHARASHTRA']));
    });

    it('saves a new party with every box as the desktop writes it, its opening and its serial row', async () => {
      const response = await request(adminCookie, 'POST', '/masters/party-master', {
        code: '100201',
        ...full(),
        opening: {
          amount: '1500.5',
          sign: 'D',
          gold: '2.5',
          goldSign: 'C',
          silver: '',
          silverSign: 'C',
        },
      });
      expect(response.statusCode, response.body).toBe(201);
      expect(response.json()).toEqual({ code: '100201', name: 'RAMESH SHAH', opening: true });
      expect(await partyRow('100201')).toEqual([
        {
          lc: '01',
          code: '100201',
          name: 'RAMESH SHAH',
          grp: '10',
          main_gr: 'A',
          typ: 'B',
          mobile: '9876543210',
          phone: '0261-2345678',
          person: 'SURESH',
          short: 'RSH',
          a1: '12 RING ROAD',
          city: 'SURAT',
          pin: '395002',
          area: 'ADAJAN',
          gst: '27ABCDE1234F1Z5',
          gst_type: 'I',
          pan: 'ABCDE1234F',
          lcs: 'LCS-77',
          state: 'MAHARASHTRA',
          district: 'SURAT',
          main_ac: '',
          ref: '',
          ref_name: '',
          mobile2: '9123456780',
          aadhaar: '123412341234',
          passport: 'P1234567',
          country: 'INDIA',
          bank: 'STATE BANK',
          rtgs: 'SBIN0001234',
          email: 'ramesh@example.com',
          khata: 'K-12',
          cr_days: 30,
          dpc: '1.5',
          int_prc: '2.25',
          amt_limit: '0.00',
          defaulter: 'N',
          tds: 'Y',
          memb: 'Y',
          share: 'N',
          br: '15/08/1990',
          an: null,
          lbr: '1960-01-01',
          visit: '02/11/2026',
          ldr: null,
          main: ADMIN,
          trfr: 'N',
          visit_tran: 'AC',
        },
      ]);
      const [op] = await query<any[]>(
        `SELECT "CO_YEAR" y,"CO_BOOK" b,"VCH_NO" v,"OP_AMT"::text amt,"OP_SIGN" s,"FINE_BAL"::text g,"FINE_SIGN" gs,
              "SL_FINE_BAL"::text sl,"DATA_TYPE" t,"DATA_TRFR" trfr,"MAIN_USER" u
         FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"='100201'`,
        tenantId,
      );
      expect(op).toMatchObject({
        y: YEAR,
        b: '000',
        v: '00000',
        s: 'D',
        gs: 'C',
        t: 'A',
        trfr: 'Y',
        u: ADMIN,
      });
      expect(Number(op.amt)).toBe(1500.5);
      expect(Number(op.g)).toBe(2.5);
      expect(Number(op.sl)).toBe(0);
      const legs = await query<Array<{ key: string; dr: string | null }>>(
        `SELECT right("LEDR_KEY",2) key,"DR_AMT"::text dr FROM "AC_DATA"
        WHERE tenant_id=$1 AND "AC_CODE"='100201' AND "CO_BOOK"='000' ORDER BY "LEDR_KEY"`,
        tenantId,
      );
      expect(legs.map((l) => l.key)).toEqual(['02', '03']);
      expect(Number(legs[0]!.dr)).toBe(1500.5);
      expect(
        await query(
          `SELECT "LC_CODE" lc,"AC_NAME" name,"AC_GR" grp,"MAIN_USER" u FROM "AC_MAST_SRNO" WHERE tenant_id=$1 AND "AC_CODE"='100201'`,
          tenantId,
        ),
      ).toEqual([{ lc: '01', name: 'RAMESH SHAH', grp: '10', u: ADMIN }]);
      const list = (await request(adminCookie, 'GET', '/masters/party-master')).json();
      expect(list.nextCode).toBe('100202');
      expect(list.rows).toContainEqual({
        code: '100201',
        name: 'RAMESH SHAH',
        mobile: '9876543210',
        lc: '01',
      });
      expect(list.combos.cities).toContain('SURAT');
    });

    it('reads one party with its group name and read-only opening, and answers another location', async () => {
      let response = await request(adminCookie, 'GET', '/masters/party-master/100201');
      expect(response.statusCode, response.body).toBe(200);
      const party = response.json();
      expect(party).toMatchObject({
        code: '100201',
        groupName: 'SUNDRY DEBTORS',
        opening: {
          amount: '1500.50',
          sign: 'D',
          gold: '2.500',
          goldSign: 'C',
          silver: '0.000',
          silverSign: 'C',
          exists: true,
        },
        version: expect.stringMatching(VERSION),
      });
      expect(party.values).toMatchObject({
        name: 'RAMESH SHAH',
        acType: 'B',
        gstType: 'I',
        email: 'ramesh@example.com',
        crDays: '30',
        dpcPrc: '1.50',
        intPrc: '2.25',
        amtLimit: '0.00',
        goldLimit: '0.000',
        withTds: true,
        member: true,
        shareHolder: false,
        birthDate: '15/08/1990',
        anniversary: '',
        lBirthDate: '01/01/1960',
        lastVisit: '02/11/2026',
        mainUser: ADMIN,
      });
      response = await request(adminCookie, 'GET', '/masters/party-master/200201');
      expect(response.json()).toEqual({ branch: '02' });
      response = await request(adminCookie, 'GET', '/masters/party-master/999999');
      expect(response.statusCode).toBe(404);
    });

    it('refuses what MS_ACCT refuses with its texts, and writes nothing', async () => {
      const before = await snapshot();
      const cases: Array<[Record<string, unknown>, string]> = [
        [{ code: '100202', ...full({ name: ' ' }) }, 'Enter Party Name and Account group Detail'],
        [
          { code: '100202', ...full({ name: 'new', group: '' }) },
          'Enter Party Name and Account group Detail',
        ],
        [{ code: '', ...full({ name: 'new' }) }, 'Enter Party Name and Account group Detail'],
        [
          { code: '100202', ...full({ name: 'ramesh shah' }) },
          "This Ac Name already Exist in  '100201'  Ac Code... Please Change Account Name...",
        ],
        [
          { code: '100202', ...full({ name: 'new', pin: '123456789' }) },
          'AC_PIN must be at most 8 characters',
        ],
        [
          { code: '10020', ...full({ name: 'new' }) },
          " You Can't Change Software Default Account....",
        ],
        [
          { code: '10020', unlocked: true, ...full({ name: 'new' }) },
          ' You Change Software Default Account With Main Location....',
        ],
        [
          { code: '100202', ...full({ name: 'new' }), opening: { amount: '123456789' } },
          'opening amount must be at most 8 characters',
        ],
      ];
      for (const [payload, message] of cases) {
        const response = await request(adminCookie, 'POST', '/masters/party-master', payload);
        expect(response.statusCode, JSON.stringify(payload)).toBe(400);
        expect(response.json().message, JSON.stringify(payload)).toBe(message);
      }
      // With BRANCH_ALL_AC_SHOW the mobile is required (:7671-7676).
      await exec(
        `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","BRANCH_ALL_AC_SHOW") VALUES ($1,'01','Y')`,
        tenantId,
      );
      try {
        const response = await request(adminCookie, 'POST', '/masters/party-master', {
          code: '100202',
          ...full({ name: 'new', mobile: '' }),
        });
        expect(response.statusCode).toBe(400);
        expect(response.json().message).toBe(
          'Please Insert Mobile No Because This Ac With Multi Branch Acconut so Mobile No Is Mandatory....',
        );
        // The company-wide list then shows the other location's party, ordered by location.
        const list = (await request(adminCookie, 'GET', '/masters/party-master')).json();
        expect(list.allBranch).toBe(true);
        expect(list.rows.map((r: { code: string }) => r.code)).toContain('200201');
        expect(list.rows[0].lc).toBe('00');
      } finally {
        await exec(`DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1`, tenantId);
      }
      expect(await snapshot()).toEqual(before);
    });

    it('a new entry whose code exists takes the next code, without an opening when none is typed', async () => {
      const response = await request(adminCookie, 'POST', '/masters/party-master', {
        code: '100201',
        ...full({ name: 'second party', mobile: '9000000003', short: '' }),
      });
      expect(response.statusCode, response.body).toBe(201);
      expect(response.json()).toEqual({ code: '100202', name: 'SECOND PARTY', opening: false });
      expect((await partyRow('100201'))[0]).toMatchObject({ name: 'RAMESH SHAH' });
      expect(await count('OP_DATA', '100202')).toBe(0);
      expect(await count('AC_MAST_SRNO', '100202')).toBe(1);
    });

    it('an edit keeps the stored MAIN_USER, ignores an opening and needs the current version', async () => {
      await exec(
        `UPDATE "AC_MAST" SET "MAIN_USER"='DESKUSER' WHERE tenant_id=$1 AND "AC_CODE"='100202'`,
        tenantId,
      );
      const opened = await versionOf('100202');
      let response = await request(adminCookie, 'PUT', '/masters/party-master/100202', {
        ...full({ name: 'second party', city: 'navsari', mobile: '9000000003', short: '' }),
        opening: { amount: '999', sign: 'C' },
        expectedVersion: opened,
      });
      expect(response.statusCode, response.body).toBe(200);
      expect((await partyRow('100202'))[0]).toMatchObject({ city: 'NAVSARI', main: 'DESKUSER' });
      expect(await count('OP_DATA', '100202')).toBe(0);
      response = await request(adminCookie, 'PUT', '/masters/party-master/100202', {
        ...full({ name: 'second party', city: 'vapi' }),
        expectedVersion: opened,
      });
      expect(response.statusCode).toBe(409);
      expect(response.json().error).toBe('party-version-conflict');
      response = await request(adminCookie, 'PUT', '/masters/party-master/100202', full());
      expect(response.statusCode).toBe(400);
      expect((await partyRow('100202'))[0]).toMatchObject({ city: 'NAVSARI' });
    });

    it('answers the Enter checks, the GST state, the account lookup and the helps', async () => {
      const taken = async (kind: string, value: string, code = '') =>
        (
          await request(
            adminCookie,
            'GET',
            `/masters/party-master/taken/${kind}?value=${encodeURIComponent(value)}&code=${code}`,
          )
        ).json().taken;
      expect(await taken('mobile', '9876543210')).toEqual({
        message: 'This Mobile No = RAMESH SHAH  With this Account .....',
        clear: false,
      });
      expect(await taken('mobile', '9876543210', '100201')).toBeNull();
      // Another location's mobile is free without BRANCH_ALL_AC_SHOW.
      expect(await taken('mobile', '9000000002')).toBeNull();
      expect(await taken('mobile2', '9123456780', '100202')).toEqual({
        message: 'This Short Name = RAMESH SHAH  With this Account .....',
        clear: false,
      });
      expect(await taken('short', 'olp')).toEqual({
        message: 'This Short Name = OTHER LOCATION PARTY  With this Account .....',
        clear: false,
      });
      expect(await taken('short', 'zzz')).toBeNull();
      let response = await request(
        adminCookie,
        'GET',
        '/masters/party-master/gst-state?gst=24AAAAA0000A1Z5',
      );
      expect(response.json()).toEqual({ state: 'GUJARAT', gstType: 'L' });
      response = await request(
        adminCookie,
        'GET',
        '/masters/party-master/gst-state?gst=27AAAAA0000A1Z5',
      );
      expect(response.json()).toEqual({ state: 'MAHARASHTRA', gstType: 'I' });
      response = await request(adminCookie, 'GET', '/masters/party-master/gst-state?gst=');
      expect(response.json()).toEqual({ state: 'GUJARAT', gstType: null });
      response = await request(adminCookie, 'GET', '/masters/party-master/account?code=200201');
      expect(response.json()).toEqual({
        account: { code: '200201', name: 'OTHER LOCATION PARTY' },
      });
      response = await request(adminCookie, 'GET', '/masters/party-master/help/groups');
      expect(response.json().rows).toEqual([
        { code: '10', name: 'SUNDRY DEBTORS', subGroup: 'CURRENT ASSETS', mainGroup: 'A' },
        { code: '11', name: 'SUNDRY CREDITORS', subGroup: 'CURRENT LIAB', mainGroup: 'L' },
      ]);
      response = await request(adminCookie, 'GET', '/masters/party-master/help/names');
      const names = response.json().rows.map((r: { name: string }) => r.name);
      expect(names).toContain('RAMESH SHAH');
      expect(names).not.toContain('OTHER LOCATION PARTY');
      response = await request(adminCookie, 'GET', '/masters/party-master/help/f1');
      expect(response.json().rows[0]).toHaveProperty('short');
      response = await request(adminCookie, 'GET', '/masters/party-master/help/account');
      expect(response.json().rows.map((r: { code: string }) => r.code)).toEqual(
        expect.arrayContaining(['100201', '100202', '150', '200201']),
      );
      response = await request(
        adminCookie,
        'GET',
        '/masters/party-master/copy/address?code=010001',
      );
      expect(response.json().values).toMatchObject({
        name: 'ADDRESS BOOK NAME',
        address1: '5 STATION ROAD',
        city: 'VAPI',
        mobile: '9111111111',
        birthDate: '10/10/1985',
      });
      response = await request(clerkCookie, 'GET', '/masters/party-master/help/short');
      expect(response.statusCode).toBe(403);
    });

    it("follows the clerk's view-only rights row: list and add, but no edit, delete or print", async () => {
      let response = await request(clerkCookie, 'GET', '/masters/party-master');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json().rights).toEqual({
        canUpdate: false,
        canDelete: false,
        canPrint: false,
      });
      response = await request(clerkCookie, 'POST', '/masters/party-master', {
        code: '100203',
        ...full({ name: 'clerk party', mobile: '', short: '' }),
      });
      expect(response.statusCode, response.body).toBe(201);
      response = await request(clerkCookie, 'PUT', '/masters/party-master/100203', {
        ...full({ name: 'clerk edit' }),
        expectedVersion: await versionOf('100203'),
      });
      expect(response.statusCode).toBe(403);
      response = await request(clerkCookie, 'DELETE', '/masters/party-master/100203');
      expect(response.statusCode).toBe(403);
      response = await request(clerkCookie, 'GET', '/masters/party-master/print');
      expect(response.statusCode).toBe(403);
      expect((await partyRow('100203')).map((r) => [r.name, r.main])).toEqual([
        ['CLERK PARTY', CLERK],
      ]);
    });

    it('keeps, shows and deletes the photo', async () => {
      const jpeg = `data:image/jpeg;base64,${Buffer.from([0xff, 0xd8, 0xff, 0xe0, 1, 2, 3, 0xff, 0xd9]).toString('base64')}`;
      let response = await request(adminCookie, 'POST', '/masters/party-master/100201/photo', {
        dataUrl: jpeg,
      });
      expect(response.statusCode, response.body).toBe(200);
      response = await request(adminCookie, 'GET', '/masters/party-master/100201/photo');
      expect(response.json()).toEqual({ dataUrl: jpeg });
      response = await request(adminCookie, 'POST', '/masters/party-master/100201/photo', {
        dataUrl: 'data:text/plain;base64,aGVsbG8=',
      });
      expect(response.statusCode).toBe(400);
      response = await request(adminCookie, 'POST', '/masters/party-master/100201/photo/delete');
      expect(response.json()).toEqual({ deleted: 1 });
      response = await request(adminCookie, 'GET', '/masters/party-master/100201/photo');
      expect(response.json()).toEqual({ dataUrl: null });
    });

    it('deletes a party with its opening and serial rows; refuses one in use, a default account and a blank code', async () => {
      await exec(
        `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","DR_AMT")
       VALUES ($1,'01','01',$2,'011','00007','100202',100)`,
        tenantId,
        YEAR,
      );
      let response = await request(adminCookie, 'DELETE', '/masters/party-master/100202');
      expect(response.statusCode).toBe(400);
      expect(response.json().message).toBe(
        "You Can't Delete Record This Party Code Use in Transection....",
      );
      response = await request(adminCookie, 'DELETE', '/masters/party-master/%20');
      expect(response.json().message).toBe('Please Select AcCode For Delete.');
      response = await request(adminCookie, 'DELETE', '/masters/party-master/SALES');
      expect(response.statusCode).toBe(400);
      expect(response.json().message).toBe(" You Can't Delete Software Default Account....");
      expect(await count('AC_MAST', 'SALES')).toBe(1);
      response = await request(
        adminCookie,
        'DELETE',
        `/masters/party-master/100201?expectedVersion=${await versionOf('100201')}`,
      );
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({ code: '100201', deleted: 1 });
      for (const table of ['AC_MAST', 'AC_MAST_SRNO', 'OP_DATA', 'AC_DATA'])
        expect(await count(table, '100201'), table).toBe(0);
      expect(await count('AC_MAST', '200201')).toBe(1);
      const other = await query<Array<{ n: number }>>(
        `SELECT count(*)::int n FROM "AC_MAST" WHERE tenant_id=$1`,
        otherTenant,
      );
      expect(other[0]!.n).toBe(1);
      response = await request(adminCookie, 'GET', '/masters/party-master/print');
      const printed = response.json().rows.map((r: { code: string }) => r.code);
      expect(printed).toContain('100202');
      expect(printed).not.toContain('100201');
    });
  },
);
