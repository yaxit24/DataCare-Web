import { PrismaClient } from '@datacare/db';
import { beforeAll, afterAll, describe, it, expect } from 'vitest';
import type { FastifyInstance, LightMyRequestResponse } from 'fastify';
import { buildApp } from '../src/app.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import { withTxBudget } from '../src/modules/shared/txBudget.js';
import { postingDataTypeTx } from '../src/modules/posting/dataType.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenant = 'data-type-access-test';
const password = 'Data-Type-Test!2026';
const cookie = (r: LightMyRequestResponse) =>
  r.cookies.map((c) => `${c.name}=${c.value}`).join('; ');
run('owner data-type decision: PostgreSQL and HTTP authority', () => {
  let owner: PrismaClient, runtime: PrismaClient, app: FastifyInstance;
  const clear = async () => {
    const tables = await owner.$queryRawUnsafe<Array<{ table_name: string }>>(
      `SELECT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const { table_name } of tables) {
      if (!/^[A-Za-z_][A-Za-z0-9_]*$/.test(table_name)) throw new Error('unexpected-table');
      await owner.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, tenant);
    }
  };
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await clear();
    await seedCompany(runtime, tenant, '01');
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG") VALUES ($1,'01','TYPEADMIN',$2,'ADMIN')`,
      tenant,
      await hashPassword(password),
    );
    app = await buildApp({
      prisma: runtime,
      secret: 'data-type-test-signing-secret-at-least-32-characters',
      secureCookies: false,
    });
  });
  afterAll(async () => {
    await app?.close();
    if (owner) {
      await clear();
      await owner.$disconnect();
    }
    await runtime?.$disconnect();
  });
  const login = () =>
    app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenant },
      payload: { coCode: '01', lcCode: '01', loginName: 'TYPEADMIN', password },
    });
  it('defaults existing/new logins to ABC/C; switches, audits, rotates refresh and denies disallowed types', async () => {
    const defaults = await owner.$queryRawUnsafe<Array<{ allow: string; default: string }>>(
      `SELECT "DATA_TYPE_ALLOW" AS allow,"DATA_TYPE_DEFAULT" AS default FROM "LOGIN_MAST" WHERE tenant_id=$1`,
      tenant,
    );
    expect(defaults).toEqual([{ allow: 'ABC', default: 'C' }]);
    const signed = await login();
    expect(signed.statusCode, signed.body).toBe(200);
    expect(signed.json()).toMatchObject({ dataType: 'C', allowedDataTypes: ['A', 'B', 'C'] });
    const changed = await app.inject({
      method: 'POST',
      url: '/auth/data-type',
      headers: { cookie: cookie(signed) },
      payload: { type: 'B' },
    });
    expect(changed.statusCode, changed.body).toBe(200);
    expect(changed.json().dataType).toBe('B');
    expect(BigInt(changed.json().contextEpoch)).toBe(
      BigInt(signed.json().context.contextEpoch) + 1n,
    );
    const refreshed = await app.inject({
      method: 'POST',
      url: '/auth/refresh',
      headers: { cookie: cookie(signed) },
    });
    expect(refreshed.statusCode, refreshed.body).toBe(200);
    const me = await app.inject({
      method: 'GET',
      url: '/me',
      headers: { cookie: cookie(refreshed) },
    });
    expect(me.json().dataType).toBe('B');
    const audit = await owner.$queryRawUnsafe<Array<{ path: string }>>(
      `SELECT path FROM audit_log WHERE tenant_id=$1 AND action='DATA_TYPE'`,
      tenant,
    );
    expect(audit).toEqual([{ path: '/auth/data-type/B' }]);
    await owner.$executeRawUnsafe(
      `UPDATE "LOGIN_MAST" SET "DATA_TYPE_ALLOW"='AB',"DATA_TYPE_DEFAULT"='A' WHERE tenant_id=$1`,
      tenant,
    );
    const denied = await app.inject({
      method: 'POST',
      url: '/auth/data-type',
      headers: { cookie: cookie(refreshed) },
      payload: { type: 'C' },
    });
    expect(denied.statusCode).toBe(403);
    expect(denied.json().message ?? denied.json().error).toBe('data-type-not-allowed');
  });
  it('server flag off forces All and refuses switching, even with an A-only user', async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO tenant_feature(tenant_id,feature,enabled) VALUES ($1,'dataTypes',false)`,
      tenant,
    );
    const signed = await login();
    expect(signed.json().dataType).toBe('C');
    const me = await app.inject({ method: 'GET', url: '/me', headers: { cookie: cookie(signed) } });
    expect(me.json()).toMatchObject({ dataType: 'C', features: { dataTypes: false } });
    const denied = await app.inject({
      method: 'POST',
      url: '/auth/data-type',
      headers: { cookie: cookie(signed) },
      payload: { type: 'A' },
    });
    expect(denied.statusCode).toBe(404);
    await owner.$executeRawUnsafe(`DELETE FROM tenant_feature WHERE tenant_id=$1`, tenant);
  });
  it('resolves every persisted B book slot and keeps the literal A quirk', async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","DATA_TYPE") VALUES ($1,'01','01','Z99',1,'B'),($1,'01','01','Z99',2,'B')`,
      tenant,
    );
    await withTxBudget(runtime, tenant, 'read', async (tx) => {
      const row = { CO_CODE: '01', LC_CODE: '01', CO_BOOK: 'Z99' };
      expect(await postingDataTypeTx(tx, tenant, 'AC_DATA', row)).toBe('B');
      expect(await postingDataTypeTx(tx, tenant, 'MAIN_STOCK', row)).toBe('B');
      expect(await postingDataTypeTx(tx, tenant, 'BILL_OS_DATA', row)).toBe('A');
    });
  });
  it('book pickers filter by the session type (DC_Main.cs:1491-1502) and User Create stores the access', async () => {
    await owner.$executeRawUnsafe(`DELETE FROM "BOOK_DATA" WHERE tenant_id=$1`, tenant);
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","CUR_USE","DATA_TYPE")
       VALUES ($1,'01','01','PA1','Pick A','PA','SALES','Y','A'),($1,'01','01','PB1','Pick B','PB','SALES','Y','B'),($1,'01','01','PN1','Pick Null','PN','SALES','Y',NULL)`,
      tenant,
    );
    await owner.$executeRawUnsafe(
      `UPDATE "LOGIN_MAST" SET "DATA_TYPE_ALLOW"='ABC',"DATA_TYPE_DEFAULT"='C' WHERE tenant_id=$1 AND "LOGIN_NAME"='TYPEADMIN'`,
      tenant,
    );
    const signed = await login();
    expect(signed.statusCode, signed.body).toBe(200);
    const codes = async (c: string) =>
      (await app.inject({ method: 'GET', url: '/context/books', headers: { cookie: c } }))
        .json()
        .map((b: { CO_BOOK: string }) => b.CO_BOOK);
    expect(await codes(cookie(signed))).toEqual(['PA1', 'PB1', 'PN1']); // All
    const toB = await app.inject({
      method: 'POST',
      url: '/auth/data-type',
      headers: { cookie: cookie(signed) },
      payload: { type: 'B' },
    });
    expect(toB.statusCode, toB.body).toBe(200);
    expect(await codes(cookie(toB))).toEqual(['PB1']);
    const toA = await app.inject({
      method: 'POST',
      url: '/auth/data-type',
      headers: { cookie: cookie(toB) },
      payload: { type: 'A' },
    });
    expect(toA.statusCode, toA.body).toBe(200);
    expect(await codes(cookie(toA))).toEqual(['PA1', 'PN1']); // a NULL data type reads as A
    // The server also refuses a request that names a book of the other type (A session -> B book), and allows All.
    const ask = (c: string, book: string) =>
      app.inject({
        method: 'GET',
        url: `/reports/stock-report?dimension=item&coBook=${book}`,
        headers: { cookie: c },
      });
    const mismatch = await ask(cookie(toA), 'PB1');
    expect(mismatch.statusCode).toBe(403);
    expect(mismatch.json().error).toBe('book-data-type-mismatch');
    expect((await ask(cookie(toA), 'PA1')).statusCode).not.toBe(403);
    expect((await ask(cookie(toA), 'PN1')).statusCode).not.toBe(403);
    const toC = await app.inject({
      method: 'POST',
      url: '/auth/data-type',
      headers: { cookie: cookie(toA) },
      payload: { type: 'C' },
    });
    expect((await ask(cookie(toC), 'PB1')).json().error).not.toBe('book-data-type-mismatch');
    const backA = await app.inject({
      method: 'POST',
      url: '/auth/data-type',
      headers: { cookie: cookie(toC) },
      payload: { type: 'A' },
    });
    expect(backA.statusCode, backA.body).toBe(200);
    const bad = await app.inject({
      method: 'POST',
      url: '/admin/users',
      headers: { cookie: cookie(backA) },
      payload: {
        loginName: 'TYPEBONLY',
        password: 'Strong-Pass-2026!x',
        confirmPassword: 'Strong-Pass-2026!x',
        userType: 'User',
        allowedDataTypes: 'B',
        defaultDataType: 'A',
      },
    });
    expect(bad.statusCode, bad.body).toBe(400);
    const made = await app.inject({
      method: 'POST',
      url: '/admin/users',
      headers: { cookie: cookie(backA) },
      payload: {
        loginName: 'TYPEBONLY',
        password: 'Strong-Pass-2026!x',
        confirmPassword: 'Strong-Pass-2026!x',
        userType: 'User',
        allowedDataTypes: 'B',
        defaultDataType: 'B',
      },
    });
    expect(made.statusCode, made.body).toBe(201);
    const row = await owner.$queryRawUnsafe<Array<{ a: string; d: string }>>(
      `SELECT "DATA_TYPE_ALLOW" a,"DATA_TYPE_DEFAULT" d FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "LOGIN_NAME"='TYPEBONLY'`,
      tenant,
    );
    expect(row).toEqual([{ a: 'B', d: 'B' }]);
    const user = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenant },
      payload: {
        coCode: '01',
        lcCode: '01',
        loginName: 'TYPEBONLY',
        password: 'Strong-Pass-2026!x',
      },
    });
    expect(user.json()).toMatchObject({ dataType: 'B', allowedDataTypes: ['B'] });
    const denied = await app.inject({
      method: 'POST',
      url: '/auth/data-type',
      headers: { cookie: cookie(user) },
      payload: { type: 'C' },
    });
    expect(denied.statusCode).toBe(403);
  });
});
