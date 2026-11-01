import { PrismaClient, withTenant } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { deleteTax } from '../src/modules/masters/taxMaster.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { resolveTaxPolicyTx } from '../src/modules/shared/taxPolicy.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N213 / G226: the Tax master (desktop MS_TAX, opened by MDI_FORM.cs:7670-7679) through the real Fastify routes on a
 * forced-RLS database. Expected values come from the desktop source:
 *
 * - The list is TAX_MAST's header rows (SR_NO = 0) of the company ordered by TAX_CODE (CLEAR_DATA, MS_TAX.cs:1608).
 * - BtnSave_Click (:1824-1933) needs the edit right only for an opened code, refuses a blank code ("Enter Tax Code.")
 *   and name ("Enter Tax Name."), deletes the code's rows and writes the header (SR_NO 0, TAX_GROUP 'N', Val of Tax %
 *   and Add Tax %, the account) and one row per grid row with a non-zero Tax % (:1886): SR_NO = the grid row (:1889),
 *   the row's type, name, account and Val(Tax %), and the header's Add Tax %. MAIN_USER is not written.
 * - Leaving the code refuses a code another tax has (:1720-1740); leaving the name, a name another code has
 *   (:1761-1781). Typed text is upper-cased and the apostrophe dropped (:1689-1702).
 * - BtnDelete_Click (:1935-1956) refuses a blank code and deletes every row of the code. BtnPrint_Click needs the print
 *   right. The header account help lists group 12 and 00013 by name (:2039); a component's, every account (:1252).
 * - The sale and purchase tax postings read the code's header and its SR_NO 1/2/3 components (taxPolicy, Ac_Tax).
 * Web rules on purpose (gap G226): one transaction, version tokens, unknown accounts refused, generic writes refused.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'tax-master-db';
const otherTenant = 'tax-master-db-other';
const PASSWORD = 'Tax-Master-Routes!2026';
const SECRET = 'tax-master-routes-test-signing-secret-over-thirty';
const ADMIN = 'txadmin';
const CLERK = 'txclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
/** The desktop's tax ledger accounts (group 12) and TDS (00013), as the desktop template holds them. */
const ACCOUNTS = [
  ['00085', 'GST TAX', '12'],
  ['00086', 'CGST TAX', '12'],
  ['00087', 'IGST TAX', '12'],
  ['00013', 'TDS A/C', '18'],
  ['00099', 'GST SUSPENSE', '30'],
] as const;
/** The rights SUB_MENU the clerk's row names (the web form's own name until the caption alias 'Tax' lands, N212). */
const RIGHTS_SUB_MENU = 'Taxes';

type Cookie = string;
type TaxRow = {
  code: string;
  sr: number;
  grp: string;
  name: string;
  pct: number;
  add: number;
  ac: string;
  main: string | null;
};

(enabled ? describe : describe.skip)('N213 Tax master is the desktop MS_TAX through HTTP', () => {
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
  const taxRows = (code: string) =>
    query<TaxRow[]>(
      `SELECT "TAX_CODE" code,coalesce("SR_NO",0)::float sr,"TAX_GROUP" grp,"TAX_NAME" name,
              "TAX_PRC"::float pct,coalesce("ADD_TAX_PRC",0)::float "add",coalesce("TAX_AC",'') ac,"MAIN_USER" main
         FROM "TAX_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "TAX_CODE"=$2 ORDER BY coalesce("SR_NO",0),row_id`,
      tenantId,
      code,
    );
  const allRows = () =>
    query<Array<{ code: string; sr: number; rid: string }>>(
      `SELECT "TAX_CODE" code,coalesce("SR_NO",0)::float sr,row_id::text rid FROM "TAX_MAST"
        WHERE tenant_id=$1 ORDER BY "TAX_CODE",coalesce("SR_NO",0),row_id`,
      tenantId,
    );
  const VERSION = /^[0-9a-f]{64}$/;
  const versionOf = async (code: string): Promise<string> => {
    const response = await request(adminCookie, 'GET', `/masters/tax-master/${code}`);
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
  const gst = (code: string, name: string, pct: string, components: unknown[], extra = {}) => ({
    code,
    name,
    pct,
    addPct: '',
    account: '00085',
    components,
    ...extra,
  });

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
    // Another tenant's code 15 must never be listed or replaced.
    await exec(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC","TAX_GROUP") VALUES ($1,'01','15',0,'OTHER TENANT',9,'N')`,
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

  it('lists the header rows of the company by code, with the rights', async () => {
    const response = await request(adminCookie, 'GET', '/masters/tax-master');
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json()).toEqual({
      rows: [
        { code: '00', name: 'TAX FREE' },
        { code: '10', name: 'GST 3%' },
        { code: '11', name: 'GST 5%' },
        { code: '12', name: 'GST 12%' },
        { code: '13', name: 'GST 18%' },
        { code: '14', name: 'GST 28%' },
        { code: '20', name: 'TCS 0.1%' },
      ],
      rights: { canUpdate: true, canDelete: true, canPrint: true },
    });
  });

  it('saves a new code as its header and the non-zero grid rows, upper-cased, with Val of the boxes', async () => {
    const response = await request(
      adminCookie,
      'POST',
      '/masters/tax-master',
      gst('15', "gst 1.5% o'nly", ' 1.5', [
        { taxType: 'sgst', name: 'sgst 0.75%', account: '00085', pct: '0.75' },
        { taxType: 'cgst', name: 'cgst 0.75%', account: '00086', pct: '0.750' },
        { taxType: 'igst', name: 'igst 1.5%', account: '00087', pct: '1.5 %' },
        { taxType: '', name: '', account: '', pct: '' },
      ]),
    );
    expect(response.statusCode, response.body).toBe(201);
    expect(response.json()).toEqual({ code: '15', components: 3 });
    expect(await taxRows('15')).toEqual([
      {
        code: '15',
        sr: 0,
        grp: 'N',
        name: 'GST 1.5% ONLY',
        pct: 1.5,
        add: 0,
        ac: '00085',
        main: null,
      },
      {
        code: '15',
        sr: 1,
        grp: 'SGST',
        name: 'SGST 0.75%',
        pct: 0.75,
        add: 0,
        ac: '00085',
        main: null,
      },
      {
        code: '15',
        sr: 2,
        grp: 'CGST',
        name: 'CGST 0.75%',
        pct: 0.75,
        add: 0,
        ac: '00086',
        main: null,
      },
      {
        code: '15',
        sr: 3,
        grp: 'IGST',
        name: 'IGST 1.5%',
        pct: 1.5,
        add: 0,
        ac: '00087',
        main: null,
      },
    ]);
    // The sale and purchase postings resolve the new code: header pinned at SR_NO 0, components 1/2/3.
    const policy = await withTenant(runtime, tenantId, (tx: any) =>
      resolveTaxPolicyTx(tx, { tenantId, coCode: '01', lcCode: '01', coYear: YEAR } as any, {
        acCode: 'WALKIN',
        taxPct: 1.5,
        taxCode: '15',
      }),
    );
    expect(policy.taxCode).toBe('15');
    expect(policy.taxAc).toBe('00085');
    expect([...policy.components.entries()]).toEqual([
      [1, { group: 'SGST', ac: '00085', pct: 0.75 }],
      [2, { group: 'CGST', ac: '00086', pct: 0.75 }],
      [3, { group: 'IGST', ac: '00087', pct: 1.5 }],
    ]);
  });

  it('skips a grid row at zero but keeps the next rows at their grid row, and writes the Add Tax % on each', async () => {
    const response = await request(
      adminCookie,
      'POST',
      '/masters/tax-master',
      gst(
        '16',
        'CESS 2%',
        '2',
        [
          { taxType: 'SGST', name: 'SGST 1%', account: '00085', pct: '1' },
          { taxType: 'CGST', name: 'CGST 0', account: '00086', pct: '0' },
          { taxType: 'IGST', name: 'IGST 2%', account: '00087', pct: '2' },
        ],
        { addPct: '0.25' },
      ),
    );
    expect(response.statusCode, response.body).toBe(201);
    expect((await taxRows('16')).map((r) => [r.sr, r.grp, r.pct, r.add])).toEqual([
      [0, 'N', 2, 0.25],
      [1, 'SGST', 1, 0.25],
      [3, 'IGST', 2, 0.25],
    ]);
  });

  it('refuses what MS_TAX refuses, with its texts, and writes nothing', async () => {
    const before = await allRows();
    const refusals: Array<[Record<string, unknown>, string]> = [
      [{ code: '', name: 'X' }, 'Enter Tax Code.'],
      [{ code: '17', name: '  ' }, 'Enter Tax Name.'],
      [
        { code: '15', name: 'NEW NAME' },
        "This Tax Code already Exist in  'GST 1.5% ONLY'  Tax Name...Please Change Tax Code...",
      ],
      [
        { code: '17', name: 'gst 3%' },
        "This Tax Name already Exist in  '10'  Tax Code...Please Change Tax Name...",
      ],
      [
        { code: '17', name: 'NEW', account: 'ZZZZ' },
        'account ZZZZ of the tax is not in the account master',
      ],
      [
        { code: '17', name: 'NEW', components: [{ taxType: 'SGST', account: 'NOPE', pct: '1' }] },
        'account NOPE of row 1 is not in the account master',
      ],
      [{ code: '171', name: 'NEW' }, 'tax code must be 1 or 2 characters'],
      [{ code: '17', name: 'N'.repeat(41) }, 'tax name must be at most 40 characters'],
      [
        { code: '17', name: 'NEW', components: [{ taxType: 'SGSTXX', pct: '1' }] },
        'tax type of row 1 must be at most 5 characters',
      ],
    ];
    for (const [payload, message] of refusals) {
      const response = await request(adminCookie, 'POST', '/masters/tax-master', payload);
      expect(response.statusCode, `${JSON.stringify(payload)} ${response.body}`).toBe(400);
      expect(response.json().message).toBe(message);
    }
    expect(await allRows()).toEqual(before);
  });

  it('reads one code with its account name and components, and answers 404 for an unknown code', async () => {
    let response = await request(adminCookie, 'GET', '/masters/tax-master/16');
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json()).toEqual({
      code: '16',
      name: 'CESS 2%',
      pct: 2,
      addPct: 0.25,
      account: '00085',
      accountName: 'GST TAX',
      components: [
        { srNo: 1, taxType: 'SGST', name: 'SGST 1%', account: '00085', pct: 1 },
        { srNo: 3, taxType: 'IGST', name: 'IGST 2%', account: '00087', pct: 2 },
      ],
      version: expect.stringMatching(VERSION),
    });
    response = await request(adminCookie, 'GET', '/masters/tax-master/99');
    expect(response.statusCode).toBe(404);
  });

  it('replaces an opened code, and refuses a stale, replayed or missing version and a code deleted meanwhile', async () => {
    const opened = await versionOf('15');
    const edit = {
      name: 'GST 1.5% ONLY',
      pct: '1.5',
      addPct: '',
      account: '00085',
      components: [
        { taxType: 'SGST', name: 'SGST 0.75%', account: '00085', pct: '0.75' },
        { taxType: 'CGST', name: 'CGST 0.75%', account: '00086', pct: '0.75' },
        { taxType: 'IGST', name: 'IGST 1.5%', account: '00099', pct: '1.5' },
      ],
    };
    let response = await request(adminCookie, 'PUT', '/masters/tax-master/15', {
      ...edit,
      expectedVersion: opened,
    });
    expect(response.statusCode, response.body).toBe(200);
    expect((await taxRows('15')).map((r) => [r.sr, r.ac])).toEqual([
      [0, '00085'],
      [1, '00085'],
      [2, '00086'],
      [3, '00099'],
    ]);
    const saved = await allRows();
    response = await request(adminCookie, 'PUT', '/masters/tax-master/15', {
      ...edit,
      expectedVersion: opened,
    });
    expect(response.statusCode, response.body).toBe(409);
    expect(response.json().error).toBe('tax-version-conflict');
    response = await request(
      adminCookie,
      'DELETE',
      `/masters/tax-master/15?expectedVersion=${opened}`,
    );
    expect(response.statusCode).toBe(409);
    response = await request(adminCookie, 'PUT', '/masters/tax-master/15', edit);
    expect(response.statusCode).toBe(400);
    expect(await allRows()).toEqual(saved);
    // An opened code that another operator deleted is not brought back by its save.
    const sixteen = await versionOf('16');
    response = await request(
      adminCookie,
      'DELETE',
      `/masters/tax-master/16?expectedVersion=${sixteen}`,
    );
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json()).toEqual({ code: '16', deleted: 3 });
    response = await request(adminCookie, 'PUT', '/masters/tax-master/16', {
      name: 'CESS 2%',
      expectedVersion: sixteen,
    });
    expect(response.statusCode).toBe(409);
    expect(await taxRows('16')).toEqual([]);
  });

  it("follows the clerk's view-only rights row: list and add, but no edit, delete or print", async () => {
    let response = await request(clerkCookie, 'GET', '/masters/tax-master');
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json().rights).toEqual({ canUpdate: false, canDelete: false, canPrint: false });
    response = await request(clerkCookie, 'POST', '/masters/tax-master', {
      code: '17',
      name: 'CLERK TAX',
      pct: '1',
    });
    expect(response.statusCode, response.body).toBe(201);
    response = await request(clerkCookie, 'PUT', '/masters/tax-master/17', {
      name: 'CLERK EDIT',
      expectedVersion: await versionOf('17'),
    });
    expect(response.statusCode).toBe(403);
    response = await request(clerkCookie, 'DELETE', '/masters/tax-master/17');
    expect(response.statusCode).toBe(403);
    response = await request(clerkCookie, 'GET', '/masters/tax-master/print');
    expect(response.statusCode).toBe(403);
    expect((await taxRows('17')).map((r) => r.name)).toEqual(['CLERK TAX']);
  });

  it('lists the header help of group 12 and 00013 by name, the component help of every account', async () => {
    let response = await request(adminCookie, 'GET', '/masters/tax-master/accounts?kind=header&q=');
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json().map((r: { code: string }) => r.code)).toEqual([
      '00086',
      '00085',
      '00087',
      '00013',
    ]);
    response = await request(
      adminCookie,
      'GET',
      '/masters/tax-master/accounts?kind=header&q=00099',
    );
    expect(response.json()).toEqual([{ code: '00099', name: 'GST SUSPENSE', group: '30' }]);
    response = await request(
      adminCookie,
      'GET',
      '/masters/tax-master/accounts?kind=component&q=GST',
    );
    expect(response.json().map((r: { code: string }) => r.code)).toEqual(
      expect.arrayContaining(['00085', '00086', '00087', '00099', 'GST', 'GSTINPUT']),
    );
  });

  it('prints every row of the company by code and SR_NO', async () => {
    const response = await request(adminCookie, 'GET', '/masters/tax-master/print');
    expect(response.statusCode, response.body).toBe(200);
    const rows = response.json().rows as Array<{ code: string; srNo: number }>;
    expect(rows.filter((r) => r.code === '15').map((r) => r.srNo)).toEqual([0, 1, 2, 3]);
    expect(rows.map((r) => r.code)).toEqual([...rows.map((r) => r.code)].sort());
  });

  it('deletes a code with every row, refuses a blank code, and leaves another tenant alone', async () => {
    await expect(deleteTax(runtime, { tenantId, coCode: '01' }, ' ')).rejects.toThrow(
      'Please Select Tax Code For Delete.',
    );
    const response = await request(adminCookie, 'DELETE', '/masters/tax-master/17');
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json()).toEqual({ code: '17', deleted: 1 });
    expect(await taxRows('17')).toEqual([]);
    const other = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "TAX_MAST" WHERE tenant_id=$1 AND "TAX_CODE"='15'`,
      otherTenant,
    );
    expect(other[0]?.n).toBe(1);
  });

  it('refuses the generic master writes, which would copy the header into every component row', async () => {
    const before = await allRows();
    for (const [method, url, payload] of [
      ['POST', '/masters/taxes', { TAX_CODE: '18', TAX_NAME: 'GENERIC' }],
      ['PUT', '/masters/taxes', { TAX_CODE: '13', TAX_NAME: 'GENERIC', TAX_PRC: 20 }],
      ['DELETE', '/masters/taxes', { TAX_CODE: '13' }],
    ] as const) {
      const response = await request(adminCookie, method, url, payload);
      expect(response.statusCode, `${method} ${response.body}`).toBe(400);
      expect(response.json().message).toContain('Tax codes are saved by the Tax master');
    }
    expect(await allRows()).toEqual(before);
    const list = await request(adminCookie, 'GET', '/masters/taxes');
    expect(list.statusCode).toBe(200);
  });
});
