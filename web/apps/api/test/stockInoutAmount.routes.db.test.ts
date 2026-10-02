import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * G87: a Stock In/Out line amount follows TR_INOUT `CommPassTotal` (unified/src/csharp/DataCareNext/TR_INOUT.cs:
 * 4085-4117). When ItRate and Fine are both non-zero the desktop overwrites ItAmt with Math.Round(…, 0), half to
 * even, by RATE_TYPE: 'P' pieces × rate, '1' fine × rate / 10, 'K' fine × rate / 1000, otherwise fine × rate.
 * Otherwise the entered amount stands. RATE_TYPE (grid column 50) is the tag's BAR_DETL.RATE_TYPE for a scanned
 * tag (:4558), the item's ITEM_MAST.RATE_TYPE for an item code (:4739) and the saved row's on reopen (:5532).
 *
 * Every expected amount below is computed from those rules, not read from the web. The screen sends deliberately
 * wrong amounts on rated lines to show the server values them itself.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'g87-stock-inout-amount';
const PASSWORD = 'G87-Stock-Inout!2026';
const SECRET = 'g87-stock-inout-route-signing-secret-32-chars';
const LOGIN = 'stockclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

type DetailRow = {
  sr: number;
  it: string;
  rt: string | null;
  rate: number;
  amt: number;
};

(enabled ? describe : describe.skip)('G87 Stock In/Out line amount by rate type', () => {
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
  const send = (method: 'GET' | 'POST' | 'PUT', url: string, payload?: unknown) =>
    app.inject({
      method,
      url,
      headers: { cookie },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });
  const details = (book: string, vchNo: string) =>
    query<DetailRow[]>(
      `SELECT "SR_NO"::int sr, "IT_CODE" it, "RATE_TYPE" rt, "ITM_RATE"::float8 rate,
              "ITM_AMT"::float8 amt
         FROM "INOUT_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "SR_NO"`,
      tenantId,
      book,
      vchNo,
    );
  const stockAmounts = (book: string, vchNo: string) =>
    query<Array<{ sr: number; amt: number }>>(
      `SELECT "VCH_SRNO"::int sr, "ITM_AMT"::float8 amt FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "VCH_SRNO", row_id`,
      tenantId,
      book,
      vchNo,
    );
  const created = (response: { statusCode: number; body: string; json: () => any }) => {
    expect(response.statusCode, response.body).toBe(201);
    return String(response.json().vchNo).padStart(5, '0');
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
                               "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
       VALUES ($1,'01','01','SOU','Stock Out','OUT','OUTWORD','O','Y','INOUT_DATA','INOUT_DETL'),
              ($1,'01','01','SIN','Stock In','SIN','INWORD','I','Y','INOUT_DATA','INOUT_DETL')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","RATE_TYPE")
       VALUES ($1,'01','GOLD','Gold by gram','G',NULL),
              ($1,'01','GLD10','Gold by 10 g','G','1'),
              ($1,'01','SILVK','Silver by kg','S','K'),
              ($1,'01','PCSIT','Priced by piece','G','P')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,'01','03','Workshop')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    for (const subMenu of ['Stock In', 'Stock Out'])
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

  it('values each line by its rate type, keeps an unrated amount, and survives reopen and an unchanged save', async () => {
    const lines = [
      // No type on the item: per gram. 9.16 × 7000 = 64120.
      { itCode: 'GOLD', pcs: 1, netWt: 10, fineWt: 9.16, rate: 7000, amount: 1 },
      // ITEM_MAST '1': per 10 g. 9.16 × 6500 = 59540.
      { itCode: 'GLD10', pcs: 1, netWt: 10, fineWt: 9.16, rate: 65000, amount: 1 },
      // ITEM_MAST 'K': per kg. 523.456 × 80 = 41876.48 → 41876.
      { itCode: 'SILVK', pcs: 1, netWt: 524, fineWt: 523.456, rate: 80000, amount: 1 },
      // ITEM_MAST 'P': per piece. 3 × 1500 = 4500.
      { itCode: 'PCSIT', pcs: 3, netWt: 0.5, fineWt: 0.5, rate: 1500, amount: 1 },
      // No rate: nothing is recomputed, the entered amount stands.
      { itCode: 'GOLD', pcs: 1, netWt: 2, fineWt: 1.8, rate: 0, amount: 123.45 },
      // An entered (or reopened) type wins over the item's: '1' on GOLD. 1 × 2.5 = 2.5 → 2 (half to even).
      { itCode: 'GOLD', pcs: 1, netWt: 1, fineWt: 1, rate: 25, rateType: '1', amount: 1 },
    ];
    const vchNo = created(
      await send('POST', '/stock/in', { coBook: 'SIN', vchDate: DAY, fromLcCode: '03', lines }),
    );
    const expected: DetailRow[] = [
      { sr: 1, it: 'GOLD', rt: null, rate: 7000, amt: 64120 },
      { sr: 2, it: 'GLD10', rt: '1', rate: 65000, amt: 59540 },
      { sr: 3, it: 'SILVK', rt: 'K', rate: 80000, amt: 41876 },
      { sr: 4, it: 'PCSIT', rt: 'P', rate: 1500, amt: 4500 },
      { sr: 5, it: 'GOLD', rt: null, rate: 0, amt: 123.45 },
      { sr: 6, it: 'GOLD', rt: '1', rate: 25, amt: 2 },
    ];
    expect(await details('SIN', vchNo)).toEqual(expected);
    const [header] = await query<Array<{ net: number }>>(
      `SELECT "TOT_NET_AMT"::float8 net FROM "INOUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SIN' AND "VCH_NO"=$2`,
      tenantId,
      vchNo,
    );
    expect(header?.net).toBe(170161.45);
    const stock = await stockAmounts('SIN', vchNo);
    expect(stock.map((row) => row.amt).sort((a, b) => a - b)).toEqual(
      expected.map((row) => row.amt).sort((a, b) => a - b),
    );

    // Reopen returns the stored type and amount; saving it unchanged changes nothing.
    const reopened = await send('GET', `/stock/in/${vchNo}?coBook=SIN&coYear=${YEAR}&lcCode=01`);
    expect(reopened.statusCode, reopened.body).toBe(200);
    const view = reopened.json();
    expect(view.lines.map((line: any) => [line.rateType, line.amount])).toEqual(
      expected.map((row) => [row.rt ?? '', row.amt]),
    );
    const resaved = await send('PUT', `/stock/in/${vchNo}`, {
      coBook: 'SIN',
      vchDate: view.vchDate,
      fromLcCode: view.fromLcCode,
      lines: view.lines,
    });
    expect(resaved.statusCode, resaved.body).toBe(200);
    expect(await details('SIN', vchNo)).toEqual(expected);
  });

  it("takes a scanned tag's rate type from the tag, not the item master", async () => {
    // A tag received as a per-piece item carries BAR_DETL.RATE_TYPE 'P'. 2 × 1000 = 2000.
    const tagIn = created(
      await send('POST', '/stock/in', {
        coBook: 'SIN',
        vchDate: DAY,
        fromLcCode: '03',
        lines: [
          {
            itCode: 'PCSIT',
            tagNo: 'G87-TAG',
            pcs: 2,
            grossWt: 0.3,
            netWt: 0.25,
            touch: 100,
            fineWt: 0.25,
            rate: 1000,
          },
        ],
      }),
    );
    expect((await details('SIN', tagIn)).map((row) => [row.rt, row.amt])).toEqual([['P', 2000]]);
    const [tag] = await query<Array<{ rt: string }>>(
      `SELECT "RATE_TYPE" rt FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO"='G87-TAG'`,
      tenantId,
    );
    expect(tag?.rt).toBe('P');

    // The item master no longer says 'P'; issuing the tag still values it per piece, as the desktop
    // copies column 50 from the scanned tag (TR_INOUT.cs:4558).
    await exec(
      `UPDATE "ITEM_MAST" SET "RATE_TYPE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"='PCSIT'`,
      tenantId,
    );
    const tagOut = created(
      await send('POST', '/stock/out', {
        coBook: 'SOU',
        vchDate: DAY,
        toLcCode: '03',
        lines: [{ itCode: 'PCSIT', tagNo: 'G87-TAG', fineWt: 0.25, rate: 1000 }],
      }),
    );
    expect(await details('SOU', tagOut)).toEqual([
      { sr: 1, it: 'PCSIT', rt: 'P', rate: 1000, amt: 2000 },
    ]);
  });
});
