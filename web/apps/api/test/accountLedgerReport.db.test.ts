import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * Account Ledger report (desktop RP_LEDR), over HTTP on the isolated database with forced RLS and a
 * non-administrator holding the report rights. Expected numbers are derived by hand from the desktop
 * arithmetic (RP_LEDR.cs), never from the web output:
 *   money = Σ(CR_AMT-DR_AMT); gold/silver = Σ signed FINE_WT (SIGN '+' adds); a negative net is a Dr
 *   column, a positive net a Cr column; the running balance is Σ(Cr)-Σ(Dr) with its side.
 *
 * Fixtures seed AC_DATA/AC_MAST/BOOK_DATA/REMARK_DATA directly (RP_LEDR is read-only; there is no web
 * writer that produces these rows for this screen), then every assertion is through the real route.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'ac-ledger-report-db';
const OTHER_TENANT = 'ac-ledger-report-other';
const PASSWORD = 'Account-Ledger-Report!2026';
const SECRET = 'account-ledger-report-test-signing-secret-over-32-chars';
const LOGIN = 'ledger-reader';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;

(enabled ? describe : describe.skip)('RP_LEDR account ledger report', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const get = (url: string) => app.inject({ method: 'GET', url, headers: { cookie } });
  const wipeTenant = async (tid: string) => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tid);
  };

  // AC_MAST header rows (distinct non-default codes so a literal fallback would be caught).
  const seedAccount = (tid: string, acCode: string, name: string, extra: Record<string, string> = {}) =>
    exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_CITY","AC_MOBILE","AC_REF_NAME","AC_AREA","AC_STATE","AC_KHATA_NO","AC_TYPE","AC_REF_CODE")
       VALUES($1,'01','01',$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12)`,
      tid,
      acCode,
      name,
      extra.gr ?? 'DEBTOR',
      extra.city ?? 'RAJKOT',
      extra.mobile ?? '9000000001',
      extra.refName ?? null,
      extra.area ?? 'WARD1',
      extra.state ?? 'GJ',
      extra.khata ?? '10',
      extra.type ?? 'C',
      extra.refCode ?? null,
    );

  let ledrSeq = 0;
  // One AC_DATA leg. LEDR_KEY is unique per tenant (schema), so every row carries its own key.
  const seedLeg = (
    tid: string,
    acCode: string,
    opts: {
      book?: string;
      bookName?: string;
      vchNo: string;
      date: string;
      entry?: string;
      cr?: number;
      dr?: number;
      itType?: 'G' | 'S';
      sign?: '+' | '-';
      fine?: number;
      ldCode?: string;
      ldrName?: string;
      dataType?: string;
    },
  ) => {
    ledrSeq += 1;
    return exec(
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_TYPE",
         "VCH_DATE","LEDR_KEY","BOOK_NAME","AC_CODE","LD_CODE","LDR_NAME","CR_AMT","DR_AMT","IT_TYPE","SIGN","FINE_WT","ENTRY_TIME","DATA_TYPE")
       VALUES($1,'01','01',$2,$3,$4,'SAL',$5::date,$6,$7,$8,$9,$10,$11,$12,$13,$14,$15,$16::timestamp,$17)`,
      tid,
      YEAR,
      opts.book ?? 'SL',
      opts.vchNo,
      opts.date,
      `${tid}-K${ledrSeq}`,
      opts.bookName ?? 'SALES',
      acCode,
      opts.ldCode ?? null,
      opts.ldrName ?? null,
      opts.cr ?? 0,
      opts.dr ?? 0,
      opts.itType ?? null,
      opts.sign ?? null,
      opts.fine ?? null,
      opts.entry ?? `${opts.date} 09:00:00`,
      opts.dataType ?? 'A',
    );
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipeTenant(tenantId);
    await wipeTenant(OTHER_TENANT);
    await seedCompany(runtime, tenantId, '01');

    // Scenario A account (summary split): ALPHA -> money -40, gold +1.75, silver -6.25.
    await seedAccount(tenantId, 'A100', 'ALPHA', { refName: 'REF ONE', khata: '11' });
    await seedLeg(tenantId, 'A100', { vchNo: '00001', date: '2024-04-01', cr: 100 });
    await seedLeg(tenantId, 'A100', { vchNo: '00002', date: '2024-04-02', dr: 140 });
    await seedLeg(tenantId, 'A100', { vchNo: '00003', date: '2024-04-03', itType: 'G', sign: '+', fine: 2.5 });
    await seedLeg(tenantId, 'A100', { vchNo: '00004', date: '2024-04-04', itType: 'G', sign: '-', fine: 0.75 });
    await seedLeg(tenantId, 'A100', { vchNo: '00005', date: '2024-04-05', itType: 'S', sign: '-', fine: 6.25 });

    // Scenario B: BETA nets to exactly zero (dropped unless withZero); GAMMA is master-only (never shows).
    await seedAccount(tenantId, 'A200', 'BETA');
    await seedLeg(tenantId, 'A200', { vchNo: '00010', date: '2024-04-01', cr: 50 });
    await seedLeg(tenantId, 'A200', { vchNo: '00011', date: '2024-04-02', dr: 50 });
    await seedAccount(tenantId, 'A300', 'GAMMA');

    // Scenario D voucher netting: DELTA voucher SL/00020 has two legs Dr 50 and Cr 10 -> net Dr 40.
    await seedAccount(tenantId, 'A400', 'DELTA');
    await seedLeg(tenantId, 'A400', {
      vchNo: '00020',
      date: '2024-04-10',
      entry: '2024-04-10 09:00:00',
      dr: 50,
      itType: 'G',
      sign: '-',
      fine: 0.5,
      ldCode: 'A100',
    });
    await seedLeg(tenantId, 'A400', {
      vchNo: '00020',
      date: '2024-04-10',
      entry: '2024-04-10 09:00:00',
      cr: 10,
      itType: 'G',
      sign: '+',
      fine: 0.1,
      ldCode: 'A100',
    });
    await exec(
      `INSERT INTO "REMARK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_REMARK")
       VALUES($1,'01','01',$2,'SL','00020',1,'first note'),($1,'01','01',$2,'SL','00020',2,'second note')`,
      tenantId,
      YEAR,
    );

    // Scenario F ageing: EPSILON as of 2024-06-30. Debits 200@age170(151+), 100@age100(120), 50@age20(30);
    // credit 220. Oldest-first -> 151+ 0, 120 80, 30 50.
    await seedAccount(tenantId, 'A500', 'EPSILON');
    await seedLeg(tenantId, 'A500', { vchNo: '00030', date: '2024-01-12', dr: 200 }); // age 170
    await seedLeg(tenantId, 'A500', { vchNo: '00031', date: '2024-03-22', dr: 100 }); // age 100
    await seedLeg(tenantId, 'A500', { vchNo: '00032', date: '2024-06-10', dr: 50 }); // age 20
    await seedLeg(tenantId, 'A500', { vchNo: '00033', date: '2024-06-01', cr: 220 });

    // A same-number sentinel in another tenant must never leak in.
    await seedCompany(runtime, OTHER_TENANT, '01');
    await seedAccount(OTHER_TENANT, 'A100', 'OTHER ALPHA');
    await seedLeg(OTHER_TENANT, 'A100', { vchNo: '00001', date: '2024-04-01', cr: 99999 });

    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','N','N','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES($1,'01','01',$2,'Report','Ledger Report','Y','N','N','Y')`,
      tenantId,
      LOGIN,
    );

    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: LOGIN, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const value = response.headers['set-cookie'];
    cookie = (Array.isArray(value) ? value : [value ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  });

  afterAll(async () => {
    if (app) await app.close();
    if (owner) {
      await wipeTenant(tenantId);
      await wipeTenant(OTHER_TENANT);
    }
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('summary splits signed money/gold/silver and drops zero rows (Scenario A + B)', async () => {
    const res = await get(`/reports/account-ledger?view=summary&coYear=${YEAR}`);
    expect(res.statusCode, res.body).toBe(200);
    const body = res.json();
    const alpha = body.rows.find((r: any) => r.acCode === 'A100');
    expect(alpha).toBeTruthy();
    expect(alpha.drAmt).toBe(40);
    expect(alpha.crAmt).toBe(0);
    expect(alpha.crGold).toBe(1.75);
    expect(alpha.drGold).toBe(0);
    expect(alpha.drSilver).toBe(6.25);
    expect(alpha.crSilver).toBe(0);
    // BETA (zero) and GAMMA (master-only) must not appear without withZero.
    expect(body.rows.some((r: any) => r.acCode === 'A200')).toBe(false);
    expect(body.rows.some((r: any) => r.acCode === 'A300')).toBe(false);
    // The other-tenant sentinel never leaks in.
    expect(body.rows.every((r: any) => r.crAmt !== 99999 && r.drAmt !== 99999)).toBe(true);
  });

  it('withZero keeps a transaction-backed zero account but never a master-only one', async () => {
    const res = await get(`/reports/account-ledger?view=summary&withZero=true&coYear=${YEAR}`);
    expect(res.statusCode, res.body).toBe(200);
    const rows = res.json().rows;
    expect(rows.some((r: any) => r.acCode === 'A200')).toBe(true);
    expect(rows.some((r: any) => r.acCode === 'A300')).toBe(false);
  });

  it('voucher-summary nets a voucher gross Dr/Cr and aggregates its remarks (Scenario D)', async () => {
    const res = await get(`/reports/account-ledger?view=voucher-summary&acCode=A400&coYear=${YEAR}`);
    expect(res.statusCode, res.body).toBe(200);
    const body = res.json();
    expect(body.account.acName).toBe('DELTA');
    const row = body.rows.find((r: any) => r.vchNo === '00020');
    expect(row).toBeTruthy();
    // Gross: Dr 50, Cr 10 (voucher summary keeps gross, RP_LEDR.cs:7716).
    expect(row.drAmt).toBe(50);
    expect(row.crAmt).toBe(10);
    expect(row.drGold).toBe(0.5);
    expect(row.crGold).toBe(0.1);
    // running money = 10 - 50 = -40 (signed); the side is Dr. The grid shows the absolute value.
    expect(row.balAmt).toBe(-40);
    expect(row.amtSide).toBe('Dr');
    expect(row.remark).toContain('first note');
    expect(row.remark).toContain('second note');
    // totals: net closing money = -40 (Dr), gold = +0.1-0.5 = -0.4 (Dr).
    expect(body.totals.amtSide).toBe('Dr');
    expect(body.totals.balAmt).toBe(40);
  });

  it('detail opening is the pre-period balance and the running balance accumulates', async () => {
    const res = await get(
      `/reports/account-ledger?view=detail&acCode=A100&fromDate=2024-04-03&toDate=2024-04-30&coYear=${YEAR}`,
    );
    expect(res.statusCode, res.body).toBe(200);
    const body = res.json();
    // Opening (before 2024-04-03): money 100-140 = -40; gold/silver 0.
    expect(body.opening.amount).toBe(-40);
    // Period rows are the three fine legs; closing money stays -40, gold +1.75, silver -6.25.
    expect(body.closing.amount).toBe(-40);
    expect(body.closing.goldFine).toBe(1.75);
    expect(body.closing.silverFine).toBe(-6.25);
  });

  it('ageing consumes the oldest debit first (Scenario F)', async () => {
    const res = await get(
      `/reports/account-ledger?view=ageing&toDate=2024-06-30&fineType=G&coYear=${YEAR}`,
    );
    expect(res.statusCode, res.body).toBe(200);
    const row = res.json().rows.find((r: any) => r.acCode === 'A500');
    expect(row).toBeTruthy();
    expect(row.amt151).toBe(0);
    expect(row.amt120).toBe(80);
    expect(row.amt30).toBe(50);
    expect(row.amt).toBe(130); // |220 - 350|
  });

  it('exports resolve the same dataset (CSV, XLSX, PDF) and need the print right', async () => {
    const csv = await get(`/reports/account-ledger/export.csv?view=summary&coYear=${YEAR}`);
    expect(csv.statusCode, csv.body).toBe(200);
    expect(csv.headers['content-type']).toContain('text/csv');
    expect(csv.body).toContain('ALPHA');
    const xlsx = await get(`/reports/account-ledger/export.xlsx?view=summary&coYear=${YEAR}`);
    expect(xlsx.statusCode, xlsx.body).toBe(200);
    expect(xlsx.headers['content-type']).toContain('spreadsheetml');
    const pdf = await get(`/reports/account-ledger/export.pdf?view=summary&coYear=${YEAR}`);
    expect(pdf.statusCode, pdf.body?.slice?.(0, 120)).toBe(200);
    expect(pdf.headers['content-type']).toContain('application/pdf');
  });

  it('the account-in-path alias still answers the detail view', async () => {
    const res = await get(`/reports/account-ledger/A100?fromDate=2024-04-03&coYear=${YEAR}`);
    expect(res.statusCode, res.body).toBe(200);
    expect(res.json().view).toBe('detail');
    expect(res.json().account.acName).toBe('ALPHA');
  });

  it('refuses an invalid request and a missing account', async () => {
    expect((await get(`/reports/account-ledger?view=nope&coYear=${YEAR}`)).statusCode).toBe(400);
    expect((await get(`/reports/account-ledger?view=detail&coYear=${YEAR}`)).statusCode).toBe(400);
    const missing = await get(`/reports/account-ledger?view=detail&acCode=ZZZZ&coYear=${YEAR}`);
    expect(missing.statusCode).toBe(404);
  });

  it('a user without the print right is refused the exports but keeps the screen', async () => {
    await exec(
      `UPDATE "LOGIN_MAST" SET "USER_PRINT"='N' WHERE tenant_id=$1 AND "LOGIN_NAME"=$2`,
      tenantId,
      LOGIN,
    );
    await exec(
      `UPDATE "USER_SET" SET "FRM_PRINT"='N' WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Ledger Report'`,
      tenantId,
      LOGIN,
    );
    // The screen still works with the view right.
    const screen = await get(`/reports/account-ledger?view=summary&coYear=${YEAR}`);
    expect(screen.statusCode, screen.body).toBe(200);
    const csv = await get(`/reports/account-ledger/export.csv?view=summary&coYear=${YEAR}`);
    expect(csv.statusCode).toBe(403);
    // restore
    await exec(
      `UPDATE "LOGIN_MAST" SET "USER_PRINT"='Y' WHERE tenant_id=$1 AND "LOGIN_NAME"=$2`,
      tenantId,
      LOGIN,
    );
    await exec(
      `UPDATE "USER_SET" SET "FRM_PRINT"='Y' WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Ledger Report'`,
      tenantId,
      LOGIN,
    );
  });

  it('the view right is required for the screen', async () => {
    await exec(
      `UPDATE "USER_SET" SET "FRM_VIEW"='N' WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Ledger Report'`,
      tenantId,
      LOGIN,
    );
    const refused = await get(`/reports/account-ledger?view=summary&coYear=${YEAR}`);
    expect(refused.statusCode).toBe(403);
    await exec(
      `UPDATE "USER_SET" SET "FRM_VIEW"='Y' WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Ledger Report'`,
      tenantId,
      LOGIN,
    );
  });
});
