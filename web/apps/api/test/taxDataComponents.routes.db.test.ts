import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * G90: every voucher family writes its main TAX_DATA rows from the tax code's COMPONENT rows.
 *
 * Desktop authority, the non-UAE branch of each family in `unified/src/csharp/DataCareNext/Ac_Tax.cs`:
 * sales `Sales_GST` :92-96, purchase `Purc_GST` :122-126, sales return `Sales_Rtn_GST` :191-195, purchase
 * return `Purc_Rtn_GST` :242-246. Each joins `TAX_MAST AS C` on the voucher's TAX_CODE and writes
 *
 *   AC_GST_TYPE <> 'I':  SR_NO 1 from C.SR_NO = 1 and SR_NO 2 from C.SR_NO = 2, TAX_AMT = A.TAX_AMT/2 each
 *   AC_GST_TYPE  = 'I':  SR_NO 3 from C.SR_NO = 3, TAX_AMT = A.TAX_AMT
 *
 * with TAX_TYPE = C.TAX_GROUP and TAX_PRC = C.TAX_PRC; TRAN_TYPE/TAX_SIGN are 'S'/'+' (sale), 'P'/'-'
 * (purchase), 'S'/'-' (sales return) and 'P'/'+' (purchase return). A provisioned company's code 10 is 3%
 * with components SGST 1.5, CGST 1.5 and IGST 3 (seedCompany, G82), so the expected rows below follow from
 * the source and the header's TAX_AMT alone.
 *
 * Before G90 the purchase, purchase-return and sales-return writers stored the PARENT's group ('N') on every
 * row, the half rate computed locally, and SR_NO 1 for an inter-state voucher.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'g90-tax-components';
const PASSWORD = 'G90-Tax-Components!2026';
const SECRET = 'g90-tax-components-route-signing-secret-32-chars';
const LOGIN = 'taxclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

interface TaxRow {
  sr: number;
  tran: string;
  code: string;
  type: string;
  prc: number;
  net: number;
  amt: number;
  sign: string;
  ac: string;
}

(enabled ? describe : describe.skip)('G90 TAX_DATA rows come from the tax code components', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const query = <T>(sql: string, ...params: unknown[]) =>
    owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const send = (method: 'GET' | 'POST' | 'PUT' | 'DELETE', url: string, payload?: unknown) =>
    app.inject({
      method,
      url,
      headers: { cookie },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });
  const taxRows = (book: string, vchNo: string) =>
    query<TaxRow[]>(
      `SELECT "SR_NO"::int sr, "TRAN_TYPE" tran, "TAX_CODE" code, "TAX_TYPE" type,
              "TAX_PRC"::float8 prc, "NET_AMT"::float8 net, "TAX_AMT"::float8 amt, "TAX_SIGN" sign,
              "AC_CODE" ac
         FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "SR_NO"`,
      tenantId,
      book,
      vchNo,
    );
  const header = (table: 'PR_DATA' | 'SL_DATA', book: string, vchNo: string) =>
    query<Array<{ tax: number; cgst: number; sgst: number; igst: number }>>(
      `SELECT "TAX_AMT"::float8 tax, coalesce("CGST_TAX",0)::float8 cgst,
              coalesce("SGST_TAX",0)::float8 sgst, coalesce("IGST_TAX",0)::float8 igst
         FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      tenantId,
      book,
      vchNo,
    ).then((rows) => rows[0]);
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
       VALUES ($1,'01','01','CUSL','Local Customer','L','30'),
              ($1,'01','01','CUSI','Inter-state Customer','I','30'),
              ($1,'01','01','SUPL','Local Supplier','L','40'),
              ($1,'01','01','SUPI','Inter-state Supplier','I','40')`,
      tenantId,
    );
    // A legacy single-row master: one row at SR_NO 1 carrying the whole rate, no parent, no components.
    await exec(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC")
       VALUES ($1,'01','L7',1,'GST','Legacy GST 7%',7)`,
      tenantId,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    for (const subMenu of ['Sales Invoice', 'Sales Return', 'Purchase Invoice', 'Purchase Return'])
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Transaction',$3,'Y','Y','Y','Y')`,
        tenantId,
        LOGIN,
        subMenu,
      );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const login = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: LOGIN, password: PASSWORD },
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

  it('purchase (Purc_GST): SGST and CGST rows intra-state, an IGST row at SR_NO 3 inter-state', async () => {
    const local = created(
      await send('POST', '/purchases', {
        coBook: 'PR',
        vchDate: DAY,
        acCode: 'SUPL',
        taxRatePct: 3,
        interState: false,
        lines: [goldLine],
      }),
    );
    // 1000 at 3%: TAX_AMT 30, so A.TAX_AMT/2 = 15 on each half.
    expect(await header('PR_DATA', 'PR', local)).toMatchObject({ tax: 30, cgst: 15, sgst: 15 });
    const base = { tran: 'P', code: '10', net: 1000, sign: '-', ac: 'SUPL' };
    expect(await taxRows('PR', local)).toEqual([
      { ...base, sr: 1, type: 'SGST', prc: 1.5, amt: 15 },
      { ...base, sr: 2, type: 'CGST', prc: 1.5, amt: 15 },
    ]);

    const inter = created(
      await send('POST', '/purchases', {
        coBook: 'PR',
        vchDate: DAY,
        acCode: 'SUPI',
        taxRatePct: 3,
        interState: true,
        lines: [goldLine],
      }),
    );
    expect(await header('PR_DATA', 'PR', inter)).toMatchObject({ tax: 30, igst: 30 });
    expect(await taxRows('PR', inter)).toEqual([
      { ...base, ac: 'SUPI', sr: 3, type: 'IGST', prc: 3, amt: 30 },
    ]);

    // Edit and delete keep and then remove exactly those rows.
    const localVersion = (await send('GET', `/purchases/${local}?coBook=PR`)).json().version;
    const edited = await send('PUT', `/purchases/${local}`, {
      expectedVersion: localVersion,
      coBook: 'PR',
      vchDate: DAY,
      acCode: 'SUPL',
      taxRatePct: 3,
      interState: false,
      lines: [goldLine],
    });
    expect(edited.statusCode, edited.body).toBe(200);
    expect((await taxRows('PR', local)).map((row) => [row.sr, row.type, row.prc])).toEqual([
      [1, 'SGST', 1.5],
      [2, 'CGST', 1.5],
    ]);
    const interVersion = (await send('GET', `/purchases/${inter}?coBook=PR`)).json().version;
    const removed = await send(
      'DELETE',
      `/purchases/${inter}?coBook=PR&expectedVersion=${interVersion}`,
    );
    expect(removed.statusCode, removed.body).toBe(200);
    expect(await taxRows('PR', inter)).toEqual([]);
  });

  it('purchase return (Purc_Rtn_GST): component rows with TRAN_TYPE P and TAX_SIGN +', async () => {
    const local = created(
      await send('POST', '/purchase-returns', {
        coBook: 'PRT',
        vchDate: DAY,
        acCode: 'SUPL',
        taxRatePct: 3,
        interState: false,
        lines: [goldLine],
      }),
    );
    expect(await header('PR_DATA', 'PRT', local)).toMatchObject({ tax: 30 });
    const base = { tran: 'P', code: '10', net: 1000, sign: '+', ac: 'SUPL' };
    expect(await taxRows('PRT', local)).toEqual([
      { ...base, sr: 1, type: 'SGST', prc: 1.5, amt: 15 },
      { ...base, sr: 2, type: 'CGST', prc: 1.5, amt: 15 },
    ]);

    const inter = created(
      await send('POST', '/purchase-returns', {
        coBook: 'PRT',
        vchDate: DAY,
        acCode: 'SUPI',
        taxRatePct: 3,
        interState: true,
        lines: [goldLine],
      }),
    );
    expect(await taxRows('PRT', inter)).toEqual([
      { ...base, ac: 'SUPI', sr: 3, type: 'IGST', prc: 3, amt: 30 },
    ]);
  });

  it('sales return (Sales_Rtn_GST): component rows with TRAN_TYPE S and TAX_SIGN -', async () => {
    const local = created(
      await send('POST', '/sales-returns', {
        coBook: 'SRT',
        vchDate: DAY,
        acCode: 'CUSL',
        taxRatePct: 3,
        interState: false,
        lines: [goldLine],
      }),
    );
    expect(await header('SL_DATA', 'SRT', local)).toMatchObject({ tax: 30 });
    const base = { tran: 'S', code: '10', net: 1000, sign: '-', ac: 'CUSL' };
    expect(await taxRows('SRT', local)).toEqual([
      { ...base, sr: 1, type: 'SGST', prc: 1.5, amt: 15 },
      { ...base, sr: 2, type: 'CGST', prc: 1.5, amt: 15 },
    ]);

    const inter = created(
      await send('POST', '/sales-returns', {
        coBook: 'SRT',
        vchDate: DAY,
        acCode: 'CUSI',
        taxRatePct: 3,
        interState: true,
        lines: [goldLine],
      }),
    );
    expect(await taxRows('SRT', inter)).toEqual([
      { ...base, ac: 'CUSI', sr: 3, type: 'IGST', prc: 3, amt: 30 },
    ]);
  });

  it('sale (Sales_GST): the same component rows, through the shared builder', async () => {
    const saleLine = { itCode: 'GOLD', pcs: 1, grossWt: 10, netWt: 10, touch: 100, rate: 100 };
    const local = created(
      await send('POST', '/sales', {
        coBook: 'SL',
        vchDate: DAY,
        acCode: 'CUSL',
        taxRatePct: 3,
        interState: false,
        lines: [saleLine],
      }),
    );
    // 10 g at 100/g on net: 1000 taxable, 30 tax.
    const base = { tran: 'S', code: '10', net: 1000, sign: '+', ac: 'CUSL' };
    expect(await taxRows('SL', local)).toEqual([
      { ...base, sr: 1, type: 'SGST', prc: 1.5, amt: 15 },
      { ...base, sr: 2, type: 'CGST', prc: 1.5, amt: 15 },
    ]);
    const inter = created(
      await send('POST', '/sales', {
        coBook: 'SL',
        vchDate: DAY,
        acCode: 'CUSI',
        taxRatePct: 3,
        interState: true,
        lines: [saleLine],
      }),
    );
    expect(await taxRows('SL', inter)).toEqual([
      { ...base, ac: 'CUSI', sr: 3, type: 'IGST', prc: 3, amt: 30 },
    ]);
  });

  it('a legacy master without component rows keeps its own group and splits the rate', async () => {
    // The desktop join finds no C.SR_NO = 2 (or 3) row here and would write fewer rows; the web keeps the
    // tax in the registers under the master's own group, as before G90.
    const legacy = created(
      await send('POST', '/purchases', {
        coBook: 'PR',
        vchDate: DAY,
        acCode: 'SUPL',
        taxRatePct: 7,
        interState: false,
        lines: [goldLine],
      }),
    );
    const base = { tran: 'P', code: 'L7', net: 1000, sign: '-', ac: 'SUPL' };
    expect(await taxRows('PR', legacy)).toEqual([
      { ...base, sr: 1, type: 'GST', prc: 3.5, amt: 35 },
      { ...base, sr: 2, type: 'GST', prc: 3.5, amt: 35 },
    ]);
  });
});
