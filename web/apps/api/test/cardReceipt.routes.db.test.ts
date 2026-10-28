import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N123 / G132: the Card Receipt (CARD ADJUST, desktop TR_CARD_REC) full lifecycle through the API.
 *
 * A customer card settlement posts the exact 8-leg ledger (Ac_Ledr.cs:1790-1804):
 *   01 Cr party R; 02 Dr party C; 03 Cr slot1 C; 04 Dr bank R; 05 Cr bank B; 06 Dr slot1 B;
 *   07 Dr party H; 08 Cr slot2 H — where R = CARD_AMT + card commission, B = bank commission,
 *   H = cash paid. The commission account is BOOK_DETL slot 1 and the cash account slot 2 of the
 *   provisioned CRD (CARD ADJUST) book. The ledger is balanced and CARD_DATA + ROJ_MEL_DATA are written.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'n123-card-receipt';
const PASSWORD = 'N123-Card-Rec!2026';
const SECRET = 'n123-card-receipt-route-signing-secret-32-chars';
const LOGIN = 'cardclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

interface Leg {
  ac: string;
  ld: string;
  dr: number;
  cr: number;
  party: string;
  suffix: string;
}

(enabled ? describe : describe.skip)('N123 card receipt (CARD ADJUST) lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
  const exec = (sql: string, ...p: unknown[]) => owner.$executeRawUnsafe(sql, ...p);
  const query = <T>(sql: string, ...p: unknown[]) => owner.$queryRawUnsafe(sql, ...p) as Promise<T>;
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const req = (method: string, url: string, payload?: unknown) =>
    app.inject({ method: method as any, url, headers: { cookie }, payload: payload as any });
  const legs = (vchNo: string) =>
    query<Leg[]>(
      `SELECT "AC_CODE" ac, "LD_CODE" ld, "DR_AMT"::float8 dr, "CR_AMT"::float8 cr,
              coalesce("PARTY_AC_CODE",'') party, right("LEDR_KEY",2) suffix
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='CRD' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
      tenantId,
      vchNo,
    );

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    // card bank (acquiring) account + a customer party
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,'01','01','CARDBANK','CARD CLEARING BANK','L'),
              ($1,'01','01','CUST1','Card Customer','L')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES($1,'01','01',$2,'Transaction','Card / UPI Receipt','Y','Y','Y','Y')`,
      tenantId,
      LOGIN,
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

  it('posts the 8-leg CARD ADJUST ledger, writes CARD_DATA + ROJ_MEL_DATA, then reopens/edits/deletes', async () => {
    // CARD_AMT 10000, card comm 2% => C = 200 (whole-unit), R = 10200. Bank comm 1% of R = 102, B = 102, N = 10098.
    const post = await req('POST', '/card-receipts?coBook=CRD', {
      partyAc: 'CUST1',
      partyName: 'Card Customer',
      bankAc: 'CARDBANK',
      bankName: 'CARD CLEARING BANK',
      cardAmt: 10000,
      cardComPrc: 2,
      bankComPrc: 1,
      vchDate: DAY,
      desc: 'Card settlement',
    });
    expect(post.statusCode, post.body).toBe(201);
    const vch = String(post.json().vchNo).padStart(5, '0');
    expect(post.json().totals).toMatchObject({ cardRec: 10200, bankCom: 102, bankNet: 10098 });

    const rows = await legs(vch);
    // 6 legs (no cash paid): 01,02,03,04,05,06.
    expect(rows.map((r) => r.suffix)).toEqual(['01', '02', '03', '04', '05', '06']);
    const by = Object.fromEntries(rows.map((r) => [r.suffix, r]));
    expect(by['01']).toMatchObject({
      ac: 'CUST1',
      ld: 'CARDBANK',
      dr: 0,
      cr: 10200,
      party: 'CUST1',
    });
    expect(by['02']).toMatchObject({ ac: 'CUST1', ld: 'CARDCOMM', dr: 200, cr: 0, party: 'CUST1' });
    expect(by['03']).toMatchObject({ ac: 'CARDCOMM', ld: 'CUST1', dr: 0, cr: 200, party: '' });
    expect(by['04']).toMatchObject({ ac: 'CARDBANK', ld: 'CUST1', dr: 10200, cr: 0, party: '' });
    expect(by['05']).toMatchObject({ ac: 'CARDBANK', ld: 'CUST1', dr: 0, cr: 102, party: 'CUST1' });
    expect(by['06']).toMatchObject({ ac: 'CARDCOMM', ld: 'CARDBANK', dr: 102, cr: 0, party: '' });
    // balanced
    const totDr = rows.reduce((s, r) => s + r.dr, 0);
    const totCr = rows.reduce((s, r) => s + r.cr, 0);
    expect(totDr).toBeCloseTo(totCr, 2);
    expect(totDr).toBeCloseTo(10502, 2);

    // CARD_DATA header
    const [hdr] = await query<Array<Record<string, unknown>>>(
      `SELECT "CARD_AMT"::float8 a,"CARD_COM_AMT"::float8 c,"CARD_REC_AMT"::float8 r,"BANK_COM_AMT"::float8 b,"BANK_NET_AMT"::float8 n,"BANK_ACCD" bank
         FROM "CARD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='CRD' AND "VCH_NO"=$2`,
      tenantId,
      vch,
    );
    expect(hdr).toMatchObject({ a: 10000, c: 200, r: 10200, b: 102, n: 10098, bank: 'CARDBANK' });

    // ROJ_MEL_DATA: 3 rows (card, cardcom, bank net) — no bankcom row when... actually B!=0 so 4 rows here.
    const rojCountRows = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='CRD' AND "VCH_NO"=$2`,
      tenantId,
      vch,
    );
    expect(rojCountRows[0]?.n).toBe(4);

    // reopen
    const got = await req('GET', `/card-receipts/${vch}?coBook=CRD`);
    expect(got.statusCode, got.body).toBe(200);
    expect(got.json()).toMatchObject({
      partyAc: 'CUST1',
      bankAc: 'CARDBANK',
      cardAmt: 10000,
      cardComAmt: 200,
      cardRecAmt: 10200,
      bankComAmt: 102,
      bankNetAmt: 10098,
      desc: 'Card settlement',
    });

    // edit: raise card amount to 20000 (comm 2% => 400, R = 20400, bank 1% => 204, N = 20196)
    const put = await req('PUT', `/card-receipts/${vch}?coBook=CRD`, {
      partyAc: 'CUST1',
      partyName: 'Card Customer',
      bankAc: 'CARDBANK',
      bankName: 'CARD CLEARING BANK',
      cardAmt: 20000,
      cardComPrc: 2,
      bankComPrc: 1,
      vchDate: DAY,
      desc: 'Card settlement revised',
    });
    expect(put.statusCode, put.body).toBe(200);
    const after = await req('GET', `/card-receipts/${vch}?coBook=CRD`);
    expect(after.json()).toMatchObject({
      cardAmt: 20000,
      cardComAmt: 400,
      cardRecAmt: 20400,
      bankNetAmt: 20196,
      desc: 'Card settlement revised',
    });
    // edit replaced the write set — still a single CARD_DATA row and a balanced ledger
    const rows2 = await legs(vch);
    const d2 = rows2.reduce((s, r) => s + r.dr, 0);
    const c2 = rows2.reduce((s, r) => s + r.cr, 0);
    expect(d2).toBeCloseTo(c2, 2);

    // delete: reverses the write set and logs a DELETE_DATA row with VCH_VAL_CR = CARD_AMT
    const del = await req('DELETE', `/card-receipts/${vch}?coBook=CRD`, {});
    expect(del.statusCode, del.body).toBe(200);
    const leftRows = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "CARD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='CRD' AND "VCH_NO"=$2`,
      tenantId,
      vch,
    );
    expect(leftRows[0]?.n).toBe(0);
    const acLeftRows = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='CRD' AND "VCH_NO"=$2`,
      tenantId,
      vch,
    );
    expect(acLeftRows[0]?.n).toBe(0);
    const [audit] = await query<Array<{ cr: number }>>(
      `SELECT "VCH_VAL_CR"::float8 cr FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='CRD' AND "VCH_NO"=$2`,
      tenantId,
      vch,
    );
    expect(audit?.cr).toBe(20000);
  });

  it('includes the slot-2 cash legs (07/08) when CASH_PAID is non-zero', async () => {
    const post = await req('POST', '/card-receipts?coBook=CRD', {
      partyAc: 'CUST1',
      bankAc: 'CARDBANK',
      cardAmt: 5000,
      cashPaid: 1000,
      vchDate: DAY,
    });
    expect(post.statusCode, post.body).toBe(201);
    const vch = String(post.json().vchNo).padStart(5, '0');
    const rows = await legs(vch);
    // no commission => 01,04 (card) + 07,08 (cash)
    expect(rows.map((r) => r.suffix)).toEqual(['01', '04', '07', '08']);
    const by = Object.fromEntries(rows.map((r) => [r.suffix, r]));
    expect(by['07']).toMatchObject({ ac: 'CUST1', ld: 'CASH', dr: 1000, cr: 0 });
    expect(by['08']).toMatchObject({ ac: 'CASH', ld: 'CUST1', dr: 0, cr: 1000 });
    const d = rows.reduce((s, r) => s + r.dr, 0);
    const c = rows.reduce((s, r) => s + r.cr, 0);
    expect(d).toBeCloseTo(c, 2);
  });
});
