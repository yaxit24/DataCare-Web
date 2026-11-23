import { randomUUID } from 'node:crypto';
import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { voucherVersionTx, writeSetStateTx } from '../src/modules/vouchers/version.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import { diffTenant, snapshotTenant } from './support/tenantSnapshot.js';

// WP-35 D-35-2 / cases.md D2; D17 is a hosted concurrency contract, not a desktop rule.
// Database counterpart of fine-jv.concurrency.stale-second-save (the frozen case is Layer: browser).
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'fine-jv-version-db';
const otherTenant = 'fine-jv-version-other-db';
const PASSWORD = 'Fine-JV-Version-Test!2026';
const SECRET = 'fine-jv-version-test-signing-secret-over-thirty-two';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const BOOK = 'FJV';
const FROM = 'FJVFROM';
const TO = 'FJVTO';
// The writer's WRITE_TABLES; refusal snapshots additionally cover remarks, identity and audit.
const WRITE_TABLES = ['CONTRA_DATA', 'AC_DATA', 'ROJ_MEL_DATA'] as const;
const WATCH_TABLES = [...WRITE_TABLES, 'REMARK_DATA', 'TEMP_BOOK_DATA', 'APR_IDTL', 'DELETE_DATA'];
const scope = { coCode: '01', lcCode: '01', coYear: YEAR };
const key = (voucherNo: string, tenant = tenantId) => ({
  tenantId: tenant,
  ...scope,
  coBook: BOOK,
  voucherNo,
});
const body = (fine = 12.345) => ({
  coBook: BOOK,
  lcCode: '01',
  coYear: YEAR,
  vchDate: DAY,
  metal: 'G',
  lines: [
    { crdr: 'DR', acCode: FROM, fine, itDesc: 'Version debit' },
    { crdr: 'CR', acCode: TO, fine, itDesc: 'Version credit' },
  ],
});
const url = (no: string) => `/fine-jv/${no}?coBook=${BOOK}`;

(enabled ? describe : describe.skip)('WP-35 Fine JV D17 version contract', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let first: string;
  let second: string;
  let outsider: string;
  const call = (
    cookie: string,
    method: 'POST' | 'GET' | 'PUT' | 'DELETE',
    path: string,
    payload?: unknown,
  ) =>
    app.inject({
      method,
      url: path,
      headers: { cookie },
      ...(payload === undefined ? {} : { payload: payload as never }),
    });
  const wipe = async () => {
    const tables = await owner.$queryRawUnsafe<Array<{ table_name: string }>>(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const { table_name } of tables)
      for (const tenant of [tenantId, otherTenant])
        await owner.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, tenant);
  };
  const cookies = (value: string | string[] | undefined) =>
    (Array.isArray(value) ? value : [value ?? '']).map((part) => part.split(';', 1)[0]).join('; ');
  const login = async (tenant: string, loginName: string) => {
    const signed = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenant },
      payload: { ...scope, loginName, password: PASSWORD },
    });
    expect(signed.statusCode, signed.body).toBe(200);
    const context = signed.json().context;
    const selected = await app.inject({
      method: 'POST',
      url: '/context/select',
      headers: {
        cookie: cookies(signed.headers['set-cookie']),
        'x-session-context-id': context.sessionId,
        'x-session-context-epoch': context.contextEpoch,
      },
      payload: { ...scope, expectedContextEpoch: context.contextEpoch, selectionId: randomUUID() },
    });
    expect(selected.statusCode, selected.body).toBe(200);
    return cookies(selected.headers['set-cookie'] ?? signed.headers['set-cookie']);
  };
  const create = async (cookie = first) => {
    const response = await call(cookie, 'POST', `/fine-jv?coBook=${BOOK}`, body());
    expect(response.statusCode, response.body).toBe(201);
    return String(response.json().vchNo).padStart(5, '0');
  };
  const read = async (no: string, cookie = first) => {
    const response = await call(cookie, 'GET', url(no));
    expect(response.statusCode, response.body).toBe(200);
    return response.json();
  };
  const snapshot = (tenant = tenantId) => snapshotTenant(owner, tenant, WATCH_TABLES);
  const assertFine = async (no: string, fine: number) => {
    const rows = await owner.$queryRawUnsafe<Array<{ ac: string; dr: number; cr: number }>>(
      `SELECT "AC_CODE" ac,"DR_FINE"::float dr,"CR_FINE"::float cr FROM "CONTRA_DATA"
       WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "AC_CODE"`,
      tenantId,
      scope.coCode,
      scope.lcCode,
      YEAR,
      BOOK,
      no,
    );
    // TR_CONTRA.cs:2787 {{dataRow2["CR_FINE"] = Conversion.Val(mSG[DC_Main.i, 5]);}}
    // TR_CONTRA.cs:2846 {{dataRow2["DR_FINE"] = Conversion.Val(mSG[DC_Main.i, 5]);}}
    expect(rows).toEqual([
      { ac: FROM, dr: fine, cr: 0 },
      { ac: TO, dr: 0, cr: fine },
    ]);
  };
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    const hash = await hashPassword(PASSWORD);
    for (const tenant of [tenantId, otherTenant]) {
      await seedCompany(runtime, tenant, '01');
      await owner.$executeRawUnsafe(
        `UPDATE "BOOK_DATA" SET "DATA_TYPE"='A',"BOOK_NAME"='Fine JV' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_BOOK"=$2`,
        tenant,
        BOOK,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01',$2,'Version From','10'),($1,'01','01',$3,'Version To','10')`,
        tenant,
        FROM,
        TO,
      );
      for (const user of ['fjvfirst', 'fjvsecond'])
        await owner.$executeRawUnsafe(
          `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED") VALUES ($1,'01',$2,$3,'ADMIN','Y','Y','Y','N')`,
          tenant,
          user,
          hash,
        );
    }
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    first = await login(tenantId, 'fjvfirst');
    second = await login(tenantId, 'fjvsecond');
    outsider = await login(otherTenant, 'fjvfirst');
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('fine-jv.version.get: GET returns the canonical 64-lowercase-hex write-set token', async () => {
    const no = await create();
    const before = await snapshot();
    const opened = await read(no);
    expect(opened.version).toMatch(/^[0-9a-f]{64}$/);
    expect(opened.version).toBe(await voucherVersionTx(owner, WRITE_TABLES, key(no)));
    expect((await read(no)).version).toBe(opened.version);
    expect(diffTenant(before, await snapshot())).toEqual({ added: {}, removed: {} });
  });

  for (const method of ['PUT', 'DELETE'] as const) {
    for (const [label, token] of [
      ['missing', undefined],
      ['empty', ''],
      ['short', 'abc'],
      ['uppercase', 'A'.repeat(64)],
      ['non-hex', 'g'.repeat(64)],
      ['too-long', 'a'.repeat(65)],
    ] as const) {
      it(`fine-jv.version.${method.toLowerCase()}.${label}: refuses invalid token with 400 and no writes`, async () => {
        const no = await create();
        const before = await snapshot();
        const response =
          method === 'PUT'
            ? await call(first, method, url(no), {
                ...body(11),
                ...(token === undefined ? {} : { expectedVersion: token }),
              })
            : await call(
                first,
                method,
                url(no) +
                  (token === undefined ? '' : `&expectedVersion=${encodeURIComponent(token)}`),
              );
        expect.soft(response.statusCode, response.body).toBe(400);
        expect(diffTenant(before, await snapshot())).toEqual({ added: {}, removed: {} });
      });
    }
    it(`fine-jv.version.${method.toLowerCase()}.stale: well-formed wrong token is 409 and writes nothing`, async () => {
      const no = await create();
      const before = await snapshot();
      const token = '0'.repeat(64);
      expect(await voucherVersionTx(owner, WRITE_TABLES, key(no))).not.toBe(token);
      const response =
        method === 'PUT'
          ? await call(first, method, url(no), { ...body(10), expectedVersion: token })
          : await call(first, method, `${url(no)}&expectedVersion=${token}`);
      expect.soft(response.statusCode, response.body).toBe(409);
      expect.soft(response.json().error).toBe('voucher-version-conflict');
      expect(diffTenant(before, await snapshot())).toEqual({ added: {}, removed: {} });
    });
  }

  it('fine-jv.version.current-save: current version saves and next GET changes version', async () => {
    const no = await create();
    const opened = await read(no);
    expect(opened.version).toMatch(/^[0-9a-f]{64}$/);
    const response = await call(first, 'PUT', url(no), {
      ...body(11),
      expectedVersion: opened.version,
    });
    expect(response.statusCode, response.body).toBe(200);
    await assertFine(no, 11);
    const updated = await read(no);
    expect(updated.version).toMatch(/^[0-9a-f]{64}$/);
    expect(updated.version).not.toBe(opened.version);
    expect(updated.version).toBe(await voucherVersionTx(owner, WRITE_TABLES, key(no)));
  });

  it('fine-jv.concurrency.stale-second-save: two clients load; first save survives stale second PUT', async () => {
    const no = await create();
    const a = await read(no, first);
    const b = await read(no, second);
    expect(a.version).toMatch(/^[0-9a-f]{64}$/);
    expect(b.version).toBe(a.version);
    const saved = await call(first, 'PUT', url(no), { ...body(11), expectedVersion: a.version });
    expect(saved.statusCode, saved.body).toBe(200);
    await assertFine(no, 11);
    const before = await snapshot();
    const stored = await read(no);
    const refused = await call(second, 'PUT', url(no), { ...body(10), expectedVersion: b.version });
    expect.soft(refused.statusCode, refused.body).toBe(409);
    expect.soft(refused.json().error).toBe('voucher-version-conflict');
    expect(diffTenant(before, await snapshot())).toEqual({ added: {}, removed: {} });
    expect(await read(no, second)).toEqual(stored);
    await assertFine(no, 11);
  });

  it('fine-jv.version.stale-delete-after-save: old token refuses deletion; current token removes write set', async () => {
    const no = await create();
    const opened = await read(no);
    expect(opened.version).toMatch(/^[0-9a-f]{64}$/);
    const saved = await call(first, 'PUT', url(no), {
      ...body(11),
      expectedVersion: opened.version,
    });
    expect(saved.statusCode, saved.body).toBe(200);
    const before = await snapshot();
    const refused = await call(second, 'DELETE', `${url(no)}&expectedVersion=${opened.version}`);
    expect.soft(refused.statusCode, refused.body).toBe(409);
    expect.soft(refused.json().error).toBe('voucher-version-conflict');
    expect(diffTenant(before, await snapshot())).toEqual({ added: {}, removed: {} });
    const current = await read(no);
    expect(current.version).not.toBe(opened.version);
    const deleted = await call(first, 'DELETE', `${url(no)}&expectedVersion=${current.version}`);
    expect(deleted.statusCode, deleted.body).toBe(200);
    expect(await writeSetStateTx(owner, WRITE_TABLES, key(no))).toEqual({
      CONTRA_DATA: [],
      AC_DATA: [],
      ROJ_MEL_DATA: [],
    });
    expect((await call(first, 'GET', url(no))).statusCode).toBe(404);
  });

  it('fine-jv.version.tenant-scope: another tenant cannot see or mutate the voucher', async () => {
    const no = await create();
    const before = await snapshot();
    const otherBefore = await snapshot(otherTenant);
    const token = await voucherVersionTx(owner, WRITE_TABLES, key(no));
    expect((await call(outsider, 'GET', url(no))).statusCode).toBe(404);
    const edited = await call(outsider, 'PUT', url(no), { ...body(10), expectedVersion: token });
    expect.soft(edited.statusCode, edited.body).toBe(404);
    const deleted = await call(outsider, 'DELETE', `${url(no)}&expectedVersion=${token}`);
    expect.soft(deleted.statusCode, deleted.body).toBe(404);
    expect(diffTenant(before, await snapshot())).toEqual({ added: {}, removed: {} });
    expect(diffTenant(otherBefore, await snapshot(otherTenant))).toEqual({
      added: {},
      removed: {},
    });
  });
});
