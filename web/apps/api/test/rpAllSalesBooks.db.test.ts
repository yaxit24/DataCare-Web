import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * The Sales Report "Select Book" panel's book list (GET /reports/sales-report/books) through the real
 * Fastify route under forced RLS. NEEDS A STACK RUN: the parity wrapper sets RUN_DB_INTEGRITY_TESTS.
 *
 * Desktop authority — RP_ALL.cs:6699 calls BookMast() for the "Sales Report" caption, whose one record set
 * is RP_ALL.cs:11421 {{SELECT A.CO_BOOK,A.BOOK_NAME FROM BOOK_DATA AS A WHERE A.CO_CODE = 'MCo_code' AND
 * A.LC_CODE = 'MLc_code' ORDER BY A.CO_BOOK}}: EVERY book of the session company+location, no row cap, one
 * grid row per open row. The generic /lookup/books (masters/lookup.ts) is capped at 50 and filters only
 * CO_CODE, so it both truncates a 51-book location and lists other locations' books; this endpoint is the
 * panel's own list and must do neither.
 */

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'rpall-books-db';
const OTHER_TENANT = 'rpall-books-other';
const PASSWORD = 'RpAll-Books!2026';
const SECRET = 'rpall-books-test-signing-secret-over-thirty-two-characters';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;

/** One more book than the generic lookup's hard cap (masters/lookup.ts Math.min(limit, 50)). */
const OWN_BOOKS = Array.from({ length: 51 }, (_, i) => `B${String(i + 1).padStart(2, '0')}`);
const OTHER_LOCATION_BOOK = 'Z02';
const OTHER_TENANT_BOOK = 'OT1';

interface BookRow {
  code: string;
  name: string;
}

(enabled ? describe : describe.skip)('Sales Report Select Book list (RP_ALL BookMast)', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async (tenant: string) => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenant);
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    for (const tenant of [TENANT, OTHER_TENANT]) {
      await wipe(tenant);
      await seedCompany(runtime, tenant, '01', { coName: 'RP_ALL Books Jewellers', lcCode: '01' });
      // The company seed carries its own books; the panel's list is asserted exactly, so the fixture
      // below is the tenant's whole BOOK_DATA.
      await exec(`DELETE FROM "BOOK_DATA" WHERE tenant_id=$1`, tenant);
    }
    // The session location's books: 51 of them (the 51st is what a 50-row cap would cut off), a duplicate
    // row of B01 with a later name (the grid still shows one B01), and none from anywhere else.
    for (const code of OWN_BOOKS)
      await exec(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","CUR_USE")
         VALUES($1,'01','01',$2,$3,'SALES','Y')`,
        TENANT,
        code,
        `${code} NAME`,
      );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","CUR_USE")
       VALUES($1,'01','01','B01','B01 NAME DUP','SALES','Y')`,
      TENANT,
    );
    // RP_ALL.cs:11421 filters A.LC_CODE = MLc_code: location 02's own book and its twin of B51 stay out.
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","CUR_USE")
       VALUES($1,'01','02',$2,'OTHER LOCATION BOOK','SALES','Y'),($1,'01','02','B51','B51 OTHER LOCATION','SALES','Y')`,
      TENANT,
      OTHER_LOCATION_BOOK,
    );
    // A sentinel in another tenant with the location-01 shape: forced RLS plus the bound tenant keep it out.
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","CUR_USE")
       VALUES($1,'01','01',$2,'OTHER TENANT BOOK','SALES','Y')`,
      OTHER_TENANT,
      OTHER_TENANT_BOOK,
    );
    for (const [name, view, print] of [
      ['viewer', 'Y', 'N'],
      ['blocked', 'N', 'N'],
    ] as const) {
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES($1,'01',$2,$3,'USER','N','N',$4,'N')`,
        TENANT,
        name,
        await hashPassword(PASSWORD),
        print,
      );
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Report','Sales Report',$3,'N','N',$4)`,
        TENANT,
        name,
        view,
        print,
      );
    }
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const name of ['viewer', 'blocked']) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': TENANT },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: name, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const values = response.headers['set-cookie'];
      cookies[name] = (Array.isArray(values) ? values : [values ?? ''])
        .map((value) => value.split(';', 1)[0])
        .join('; ');
    }
  });

  afterAll(async () => {
    if (app) await app.close();
    if (owner) {
      await wipe(TENANT);
      await wipe(OTHER_TENANT);
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('books.location-scoped-uncapped: all 51 books of the session location, ordered, distinct codes', async () => {
    const response = await app.inject({
      method: 'GET',
      url: '/reports/sales-report/books',
      headers: { cookie: cookies.viewer! },
    });
    expect(response.statusCode, response.body).toBe(200);
    const books = response.json() as BookRow[];
    // RP_ALL.cs:11421 lists the whole location with no cap: the 51st book proves the old 50-row cap is gone.
    expect(books).toHaveLength(OWN_BOOKS.length);
    expect(books.map((b) => b.code)).toEqual(OWN_BOOKS);
    // ORDER BY A.CO_BOOK, and DISTINCT ON keeps one row per code even when BOOK_DATA holds a second B01 row.
    const b01 = books.find((b) => b.code === 'B01')!;
    expect(b01).toBeDefined();
    expect(b01.name).toBe('B01 NAME');
    expect(books.filter((b) => b.code === 'B01')).toHaveLength(1);
  });

  it('books.other-location-and-tenant-excluded: the panel lists only the session company+location', async () => {
    const response = await app.inject({
      method: 'GET',
      url: '/reports/sales-report/books',
      headers: { cookie: cookies.viewer! },
    });
    expect(response.statusCode, response.body).toBe(200);
    const codes = (response.json() as BookRow[]).map((b) => b.code);
    // RP_ALL.cs:11421 filters A.LC_CODE = MLc_code, unlike the generic lookup, which filters only CO_CODE.
    expect(codes).not.toContain(OTHER_LOCATION_BOOK);
    // B51 exists in both locations; the location-02 twin must not add a second row or replace the name.
    expect(codes.filter((c) => c === 'B51')).toHaveLength(1);
    expect((response.json() as BookRow[]).find((b) => b.code === 'B51')!.name).toBe('B51 NAME');
    // Forced RLS plus the bound tenant: another tenant's location-01 book never appears.
    expect(codes).not.toContain(OTHER_TENANT_BOOK);
  });

  it('books.view-right-gate: no Sales Report view right refuses the list', async () => {
    const response = await app.inject({
      method: 'GET',
      url: '/reports/sales-report/books',
      headers: { cookie: cookies.blocked! },
    });
    expect(response.statusCode).toBe(403);
  });
});
