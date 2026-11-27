import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { saveCompanyIdentity } from '../src/modules/masters/companyIdentity.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * Company reset on a company made through Company Master (companyIdentity → companyClone desktopDefaults), whose books
 * and location name the desktop's numeric default accounts cloned from 01 (companyClone.ts defaultFilters: AC_MAST
 * numeric codes below 101, BOOK_DATA/BOOK_DETL/LOCT_MAST at location 00).
 *
 * Desktop: the reset keeps accounts with a numeric code up to 99 (Module_Schm.cs:90). The web keeps those plus every
 * account a kept book or location names (companyReset.ts accountKept), so after the reset every kept book
 * still posts to an account that exists: a sale and a purchase are saved through the real routes and every ledger
 * leg names an existing account.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'company-reset-clone';
const PASSWORD = 'Company-Reset-Clone!2026';
const SECRET = 'company-reset-clone-test-signing-secret-over-thirty';
const ADMIN = 'rcadmin';
const CO = '05';
const NAME = 'CLONED TARGET';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
/** Web book accounts of SL/PR renamed to desktop numeric codes; PURCHASE becomes 00100, kept only as a reference. */
const NUMERIC: Record<string, string> = {
  SALES: '00075',
  PURCHASE: '00100',
  CASH: '00021',
  ROUNDOFF: '00060',
  KASAR: '00061',
  BANK: '00022',
  DISCOUNT: '00062',
  GST: '00063',
  GSTINPUT: '00064',
};

(enabled ? describe : describe.skip)('Company reset of a Company Master (cloned) company', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const query = <T>(sql: string, ...params: unknown[]) =>
    owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
  const send = (method: 'GET' | 'POST', url: string, payload?: unknown) =>
    app.inject({
      method,
      url,
      headers: { cookie },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT c.table_name FROM information_schema.columns c
         JOIN information_schema.tables t USING (table_schema,table_name)
        WHERE c.table_schema='public' AND t.table_type='BASE TABLE' AND c.column_name='tenant_id'`,
    );
    await owner.$transaction(async (tx: any) => {
      await tx.$executeRawUnsafe(`SET LOCAL "app.allow_repair_purge" = 'on'`);
      for (const row of rows)
        await tx.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
    });
  };
  /** Account codes named by the kept books and locations that have no AC_MAST row. */
  const danglingReferences = () =>
    query<{ ref: string }[]>(
      `SELECT DISTINCT ref FROM (
         SELECT "AC_CODE" ref FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2
         UNION SELECT "AC_CODE" FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
         ) r
        WHERE ref IS NOT NULL AND ref<>'' AND NOT EXISTS (
          SELECT 1 FROM "AC_MAST" a WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."AC_CODE"=r.ref)
        ORDER BY ref`,
      tenantId,
      CO,
    );

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    // Make 01 look like a desktop company: location 00, and SL/PR books at 00 posting to numeric accounts.
    await exec(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME","AC_CODE") VALUES ($1,'01','00','MAIN','00100')`,
      tenantId,
    );
    for (const [web, code] of Object.entries(NUMERIC))
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_GST_TYPE")
         SELECT tenant_id,'01','00',$2,"AC_NAME","AC_GR","AC_GST_TYPE" FROM "AC_MAST"
          WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"=$3 LIMIT 1`,
        tenantId,
        code,
        web,
      );
    const cols = async (table: string) =>
      (
        await query<{ c: string }[]>(
          `SELECT column_name c FROM information_schema.columns WHERE table_schema='public' AND table_name=$1
             AND column_name NOT IN ('row_id','tenant_id','LC_CODE','AC_CODE','AC_NAME')`,
          table,
        )
      ).map((row) => `"${row.c}"`);
    const bookCols = (await cols('BOOK_DATA')).join(',');
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"LC_CODE",${bookCols})
       SELECT tenant_id,'00',${bookCols} FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_BOOK" IN ('SL','PR')`,
      tenantId,
    );
    const detlCols = (await cols('BOOK_DETL')).join(',');
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"LC_CODE","AC_CODE","AC_NAME",${detlCols})
       SELECT tenant_id,'00',coalesce(($2::jsonb)->>"AC_CODE","AC_CODE"),"AC_NAME",${detlCols}
         FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_BOOK" IN ('SL','PR')`,
      tenantId,
      JSON.stringify(NUMERIC),
    );
    // Company Master: a new company with the desktop default masters of 01 (MS_COMPANY / MS_YEAR clone).
    await saveCompanyIdentity(
      runtime,
      tenantId,
      ADMIN,
      { CO_CODE: CO, CO_NAME: NAME, firstYear: { coYear: YEAR } },
      false,
    );
    // The user's own data in 05: a party above 99, an item and a group posting to the numeric accounts.
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_GST_TYPE")
       VALUES ($1,$2,'00','00500','OLD PARTY','20','L')`,
      tenantId,
      CO,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,$2,$3,$4,'ADMIN','Y','Y','Y','N')`,
      tenantId,
      CO,
      ADMIN,
      await hashPassword(PASSWORD),
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const login = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: CO, lcCode: '00', coYear: YEAR, loginName: ADMIN, password: PASSWORD },
    });
    expect(login.statusCode, login.body).toBe(200);
    const value = login.headers['set-cookie'];
    cookie = (Array.isArray(value) ? value : [value ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  }, 120_000);
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('keeps every account a kept book or location names, and a sale and a purchase still post', async () => {
    const books = await query<{ ac: string }[]>(
      `SELECT DISTINCT "AC_CODE" ac FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
      tenantId,
      CO,
    );
    expect(books.map((row) => row.ac)).toContain('00100');
    const preview = await send('GET', `/companies/${CO}/reset/preview`);
    expect(preview.statusCode, preview.body).toBe(200);
    const reset = await send('POST', `/companies/${CO}/reset`, {
      coCode: CO,
      coName: NAME,
      password: PASSWORD,
      reason: 'Clone path reset with synthetic data',
      fingerprint: preview.json().fingerprint,
    });
    expect(reset.statusCode, reset.body).toBe(200);
    expect(reset.json()).toMatchObject({ ownCompany: true });
    expect(await danglingReferences()).toEqual([]);
    const accounts = await query<{ ac: string }[]>(
      `SELECT "AC_CODE" ac FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE" ~ '^[0-9]+$' ORDER BY 1`,
      tenantId,
      CO,
    );
    // 00100 stays only because the books and the location name it; the user's 00500 is gone.
    expect(accounts.map((row) => row.ac)).toContain('00100');
    expect(accounts.map((row) => row.ac)).not.toContain('00500');
    expect((await send('GET', '/me')).statusCode).toBe(200);

    // The user sets up a party, a supplier and an item again, then sells and buys.
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR")
       VALUES ($1,$2,'00','CUSL','Local Customer','L','20'),($1,$2,'00','SUPL','Local Supplier','L','05')`,
      tenantId,
      CO,
    );
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
       VALUES ($1,$2,'01','GOLD JEWELLERY','00075','00100')`,
      tenantId,
      CO,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'GOLD','GOLD ORNAMENT','G','01')`,
      tenantId,
      CO,
    );
    const line = { itCode: 'GOLD', pcs: 1, grossWt: 10, netWt: 10, touch: 100, metalAmount: 1000 };
    const sale = await send('POST', '/sales', {
      coBook: 'SL',
      acCode: 'CUSL',
      vchDate: DAY,
      taxRatePct: 0,
      interState: false,
      lines: [line],
      cashAmt: 995,
      kasarAmount: 5,
    });
    expect(sale.statusCode, sale.body).toBe(201);
    const purchase = await send('POST', '/purchases', {
      coBook: 'PR',
      vchDate: DAY,
      acCode: 'SUPL',
      taxRatePct: 0,
      interState: false,
      lines: [line],
      cashAmt: 995,
      kasar: 5,
    });
    expect(purchase.statusCode, purchase.body).toBe(201);
    const legs = await query<{ book: string; ac: string; known: boolean }[]>(
      `SELECT d."CO_BOOK" book, d."AC_CODE" ac,
              EXISTS (SELECT 1 FROM "AC_MAST" a WHERE a.tenant_id=d.tenant_id AND a."CO_CODE"=d."CO_CODE"
                         AND a."AC_CODE"=d."AC_CODE") known
         FROM "AC_DATA" d WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 ORDER BY 1,2`,
      tenantId,
      CO,
    );
    expect(legs.map((leg) => leg.book)).toEqual(expect.arrayContaining(['SL', 'PR']));
    expect(legs.filter((leg) => !leg.known)).toEqual([]);
    expect(legs.map((leg) => leg.ac)).toEqual(expect.arrayContaining(['00075', '00100', '00021']));
  });
});
