import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * G92: the labour invoice and fine sale/purchase write TAX_DATA from their tax codes' component rows.
 *
 * Desktop authority, `unified/src/csharp/DataCareNext/Ac_Tax.cs`:
 *  - `LbrWork_GST` :164-174 joins TAX_MAST on LBR_DATA.TAX_CODE (metal: SR_NO 1/2 from C.SR_NO 1/2, or 3 for an
 *    inter-state party; NET_AMT = SL_NET_AMT, TAX_AMT/2 each or the whole, TOT_AMT = SL_NET_AMT + TAX_AMT) and on
 *    LBR_TAX_CODE (labour: SR_NO 10/20, or 30; NET_AMT = DR_LBR, DISC_AMT = LBR_DISC_AMT,
 *    TOT_AMT = DR_LBR + LBR_TAX_AMT - LBR_DISC_AMT), TRAN_TYPE 'S', TAX_SIGN '+'.
 *  - `Fine_Cut_GST` :289-293 joins on CUT_DATA.TAX_CODE: SR_NO 1/2 (3), NET_AMT, TAX_AMT/2 each or the whole,
 *    DISC_AMT 0, TOT_AMT; TRAN_TYPE 'P' and TAX_SIGN '-' for FINE PURC, 'S' and '+' for FINE SALE.
 * TAX_TYPE = C.TAX_GROUP, TAX_PRC = C.TAX_PRC; geography is the party's AC_GST_TYPE. A provisioned company's code
 * 10 is 3% and 11 is 5%, each with SGST, CGST and IGST components (seedCompany).
 *
 * Before G92 both writers wrote literal CGST at SR_NO 1 and SGST at 2, IGST at SR_NO 1, the labour part at 5/6,
 * no tax code, and took inter-state from the screen.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'g92-labour-fine-tax';
const PASSWORD = 'G92-Labour-Fine!2026';
const SECRET = 'g92-labour-fine-route-signing-secret-32-chars';
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
  disc: number;
  tot: number;
  sign: string;
}

(enabled ? describe : describe.skip)('G92 labour and fine tax rows come from the tax codes', () => {
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
  const post = (url: string, payload: unknown) =>
    app.inject({ method: 'POST', url, headers: { cookie }, payload: payload as any });
  const taxRows = (book: string, vchNo: string) =>
    query<TaxRow[]>(
      `SELECT "SR_NO"::int sr, "TRAN_TYPE" tran, "TAX_CODE" code, "TAX_TYPE" type,
              "TAX_PRC"::float8 prc, "NET_AMT"::float8 net, "TAX_AMT"::float8 amt,
              coalesce("DISC_AMT",0)::float8 disc, "TOT_AMT"::float8 tot, "TAX_SIGN" sign
         FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "SR_NO"`,
      tenantId,
      book,
      vchNo,
    );
  const created = (response: { statusCode: number; body: string; json: () => any }) => {
    expect(response.statusCode, response.body).toBe(201);
    return String(response.json().vchNo).padStart(5, '0');
  };
  const labour = (acCode: string, interState: boolean) =>
    post('/labour-invoice', {
      coBook: 'LBR',
      vchDate: DAY,
      acCode,
      interState,
      metalTaxPct: 3,
      labourTaxPct: 5,
      lines: [{ itCode: 'GOLD', pcs: 1, netWt: 5, metalAmount: 1000, labourAmount: 200 }],
    });
  const fine = (side: 'SALE' | 'PURC', partyAc: string, interState: boolean, lines: unknown[]) =>
    post('/fine-sale', { side, partyAc, taxPct: 3, interState, vchDate: DAY, lines });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,'01','01','LBR','Labour','LBRI','LABOUR WORK','O','Y','LBR_DATA'),
              ($1,'01','01','FSL','Fine Sale','FNSL','FINE SALE','O','Y','CUT_DATA'),
              ($1,'01','01','FPR','Fine Purchase','FNPR','FINE PURC','I','Y','CUT_DATA')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,'01','01','CUSL','Local Party','L'),
              ($1,'01','01','CUSI','Inter-state Party','I'),
              ($1,'01','01','LABOUR','Labour Income','L')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE") VALUES ($1,'01','GOLD','Gold','G')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    for (const subMenu of ['Labour Sale', 'Fine Settlement'])
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

  it('labour invoice (LbrWork_GST): metal at SR_NO 1/2 or 3, labour at 10/20 or 30, with both codes stored', async () => {
    const local = created(await labour('CUSL', false));
    // Metal 1000 at 3%: 30 tax, 15 + 15. Labour 200 at 5%: 10 tax, 5 + 5.
    const metal = { tran: 'S', code: '10', net: 1000, disc: 0, tot: 1030, sign: '+' };
    const work = { tran: 'S', code: '11', net: 200, disc: 0, tot: 210, sign: '+' };
    expect(await taxRows('LBR', local)).toEqual([
      { ...metal, sr: 1, type: 'SGST', prc: 1.5, amt: 15 },
      { ...metal, sr: 2, type: 'CGST', prc: 1.5, amt: 15 },
      { ...work, sr: 10, type: 'SGST', prc: 2.5, amt: 5 },
      { ...work, sr: 20, type: 'CGST', prc: 2.5, amt: 5 },
    ]);
    const [codes] = await query<Array<{ metal: string; labour: string }>>(
      `SELECT "TAX_CODE" metal, "LBR_TAX_CODE" labour FROM "LBR_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='LBR' AND "VCH_NO"=$2`,
      tenantId,
      local,
    );
    expect(codes).toEqual({ metal: '10', labour: '11' });

    const inter = created(await labour('CUSI', true));
    expect(await taxRows('LBR', inter)).toEqual([
      { ...metal, sr: 3, type: 'IGST', prc: 3, amt: 30 },
      { ...work, sr: 30, type: 'IGST', prc: 5, amt: 10 },
    ]);
  });

  it("refuses a labour invoice whose inter-state flag contradicts the party's GST type", async () => {
    const refused = await labour('CUSI', false);
    expect(refused.statusCode, refused.body).toBe(400);
    expect(refused.json().message).toMatch(/interState does not match/);
  });

  it('fine sale and purchase (Fine_Cut_GST): SR_NO 1/2 or 3 with equal unrounded halves and the code stored', async () => {
    // 10 g fine at 7000: 70000, 3% tax 2100, halves 1050.
    const sale = created(await fine('SALE', 'CUSL', false, [{ fineWt: 10, fineRate: 7000 }]));
    const sold = { tran: 'S', code: '10', net: 70000, disc: 0, tot: 72100, sign: '+' };
    expect(await taxRows('FSL', sale)).toEqual([
      { ...sold, sr: 1, type: 'SGST', prc: 1.5, amt: 1050 },
      { ...sold, sr: 2, type: 'CGST', prc: 1.5, amt: 1050 },
    ]);
    const [cut] = await query<Array<{ code: string }>>(
      `SELECT "TAX_CODE" code FROM "CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='FSL' AND "VCH_NO"=$2`,
      tenantId,
      sale,
    );
    expect(cut?.code).toBe('10');

    // Odd paise: 1 g at 33.67 is 33.67 and 3% is 1.01, so A.TAX_AMT/2 is 0.505 on each row, not 0.51 + 0.50.
    const odd = created(await fine('PURC', 'CUSL', false, [{ fineWt: 1, fineRate: 33.67 }]));
    const bought = { tran: 'P', code: '10', net: 33.67, disc: 0, tot: 34.68, sign: '-' };
    expect(await taxRows('FPR', odd)).toEqual([
      { ...bought, sr: 1, type: 'SGST', prc: 1.5, amt: 0.505 },
      { ...bought, sr: 2, type: 'CGST', prc: 1.5, amt: 0.505 },
    ]);

    const inter = created(await fine('SALE', 'CUSI', true, [{ fineWt: 10, fineRate: 7000 }]));
    expect(await taxRows('FSL', inter)).toEqual([
      { ...sold, sr: 3, type: 'IGST', prc: 3, amt: 2100 },
    ]);
    const refused = await fine('SALE', 'CUSI', false, [{ fineWt: 10, fineRate: 7000 }]);
    expect(refused.statusCode, refused.body).toBe(400);
  });
});
