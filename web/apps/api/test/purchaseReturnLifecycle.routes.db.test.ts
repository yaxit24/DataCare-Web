import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/** N34/G04 lifecycle over HTTP with a desktop-shaped non-mnemonic return book. */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'prt-lifecycle-route';
const PASSWORD = 'Purchase-Return-Route!2026';
const SECRET = 'purchase-return-route-signing-secret-over-thirty-two-chars';
const LOGIN = 'returnclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

(enabled ? describe : describe.skip)('configured Purchase Return HTTP lifecycle', () => {
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
  const request = (method: 'GET' | 'POST' | 'DELETE', url: string, payload?: unknown) =>
    app.inject({
      method,
      url,
      headers: { cookie },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR")
       VALUES ($1,'01','01','SUPP01','Return Supplier','L','40')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC")
       VALUES ($1,'01','G01','Gold','PURCHASE')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","OTH_DETL_POSTING")
       VALUES ($1,'01','GOLD','Gold Ornament','G','G01','Y')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,'01','01','348','Purchase Return 348','P348','PURC RETURN','O','Y','PR_DATA')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,'01','01','348',1,'PURCHASE','PURC RETURN','O'),
              ($1,'01','01','348',2,'CASH','PURC RETURN','O'),
              ($1,'01','01','348',3,'ROUNDOFF','PURC RETURN','O')`,
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
       VALUES($1,'01','01',$2,'Purchase','Purchase Return','Y','Y','Y','Y')`,
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

  it('creates, reopens, prints and fully deletes book 348 without a PRT fallback', async () => {
    const saved = await request('POST', '/purchase-returns', {
      coBook: '348',
      vchDate: DAY,
      acCode: 'SUPP01',
      acName: 'Return Supplier',
      taxRatePct: 0,
      interState: false,
      lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 5, netWt: 5, touch: 90, metalAmount: 450 }],
    });
    expect(saved.statusCode, saved.body).toBe(201);
    const vchNo = String(saved.json().vchNo).padStart(5, '0');
    const q = `coBook=348&coYear=${YEAR}&lcCode=01`;

    const read = await request('GET', `/purchase-returns/${vchNo}?${q}`);
    expect(read.statusCode, read.body).toBe(200);
    expect(read.json()).toMatchObject({
      acCode: 'SUPP01',
      mainUser: LOGIN,
      lines: [{ itCode: 'GOLD', netWt: 5 }],
    });
    const printed = await request('GET', `/purchase-returns/${vchNo}/print?${q}&format=html`);
    expect(printed.statusCode, printed.body).toBe(200);
    expect(printed.headers['content-type']).toMatch(/text\/html/);
    expect(printed.body).toMatch(/Purchase Return/);

    const [before] = await query<Array<{ hd: string; temp: number; rojmel: number }>>(
      `SELECT p."HD_VCH_NO" hd,
              (SELECT count(*)::int FROM "TEMP_BOOK_DATA" t WHERE t.tenant_id=p.tenant_id
                AND t."CO_CODE"=p."CO_CODE" AND t."LC_CODE"=p."LC_CODE" AND t."CO_BOOK"=p."CO_BOOK"
                AND t."VCH_NO"=p."HD_VCH_NO") temp,
              (SELECT count(*)::int FROM "ROJ_MEL_DATA" r WHERE r.tenant_id=p.tenant_id
                AND r."CO_CODE"=p."CO_CODE" AND r."LC_CODE"=p."LC_CODE" AND r."CO_YEAR"=p."CO_YEAR"
                AND r."CO_BOOK"=p."CO_BOOK" AND r."VCH_NO"=p."VCH_NO") rojmel
         FROM "PR_DATA" p WHERE p.tenant_id=$1 AND p."CO_BOOK"='348' AND p."VCH_NO"=$2`,
      tenantId,
      vchNo,
    );
    expect(before?.temp).toBe(1);
    expect(before?.rojmel).toBeGreaterThan(0);
    const dmRows = await query<Array<Record<string, unknown>>>(
      `SELECT "MAIN_SRNO"::int,"SR_NO"::int,"ISR_NO"::int,"ENTRY_TYPE","BOOK_NAME","AC_CODE",
              "IT_CODE","DM_CODE","DM_PCS"::float8,"DM_WT"::float8,"DM_SIGN","DM_RATE"::float8,
              "DM_AMT"::float8,"TAG_NO","VCH_SRNO"::int,"MAIN_IT_CODE","INOUT_TYPE","TBL_CODE"
         FROM "DM_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='348' AND "VCH_NO"=$2`,
      tenantId,
      vchNo,
    );
    expect(dmRows).toEqual([
      {
        MAIN_SRNO: 1,
        SR_NO: 1,
        ISR_NO: 1,
        ENTRY_TYPE: 'L',
        BOOK_NAME: 'P348',
        AC_CODE: 'SUPP01',
        IT_CODE: 'GOLD',
        DM_CODE: 'GOLD',
        DM_PCS: 1,
        DM_WT: 5,
        DM_SIGN: '-',
        DM_RATE: 0,
        DM_AMT: 450,
        TAG_NO: 'N',
        VCH_SRNO: 0,
        MAIN_IT_CODE: 'GOLD',
        INOUT_TYPE: 'O',
        TBL_CODE: null,
      },
    ]);

    const removed = await request('DELETE', `/purchase-returns/${vchNo}?${q}`);
    expect(removed.statusCode, removed.body).toBe(200);
    const [after] = await query<
      Array<{ pr: number; dm: number; rojmel: number; temp: number; audit: number }>
    >(
      `SELECT
         (SELECT count(*)::int FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='348') pr,
         (SELECT count(*)::int FROM "DM_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='348') dm,
         (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='348') rojmel,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='348' AND "VCH_NO"=$2) temp,
         (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='348'
            AND "VCH_TYPE"='P348' AND "DELETE_USER"=$3) audit`,
      tenantId,
      before?.hd,
      LOGIN,
    );
    expect(after).toEqual({ pr: 0, dm: 0, rojmel: 0, temp: 0, audit: 1 });
  });
});
