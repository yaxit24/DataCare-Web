import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { KEPT_TABLES } from '../src/modules/masters/companyReset.js';
import {
  companyWriteLockKey,
  runWithCompanyWriteScope,
} from '../src/modules/shared/companyWriteScope.js';
import { CompanyBusyError, withTxBudget } from '../src/modules/shared/txBudget.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * Company → Company, Ctrl+R "Reset Compnay" through the real routes on a forced-RLS database.
 *
 * Desktop: MS_COMPANY.cs:6477-6480 shows the box, :6116/:6162 store CO_MAST.RTGS_TYPE='Y', and at the next login
 * Module_Schm.cs:60-230 (via MS_OPNCOMP.cs:1513,2010-2013) and MS_LOGIN.cs:581-593 delete the company's vouchers,
 * masters, keeping the default rows (Module_Schm.cs:83-222). The web (owner decision 2026-11-28) clears the company at
 * once in one transaction, keeps identity, settings, books, users, locations and one year, puts seedCompany's
 * default masters back, and archives every deleted row in company_reset_archive (companyReset.ts).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'company-reset-db';
const otherTenant = 'company-reset-db-other';
const PASSWORD = 'Company-Reset-Routes!2026';
const SECRET = 'company-reset-routes-test-signing-secret-over-thirty';
const ADMIN = 'rsadmin';
const CLERK = 'rsclerk';
const REASON = 'Synthetic test company no longer needed';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;

type Cookie = string;

(enabled ? describe : describe.skip)('Company reset (MS_COMPANY Ctrl+R) through HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let adminCookie: Cookie;
  let clerkCookie: Cookie;
  /** Company-scoped tables that took a synthetic sentinel row for every seeded company. */
  let seeded: string[] = [];
  let seeded03: string[] = [];

  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const query = <T>(sql: string, ...params: unknown[]) =>
    owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
  const request = (cookie: Cookie, method: string, url: string, payload?: unknown) =>
    app.inject({
      method: method as never,
      url,
      headers: { cookie },
      ...(payload === undefined ? {} : { payload: payload as never }),
    });
  const companyTables = async () =>
    (
      await query<{ table_name: string }[]>(
        `SELECT c.table_name FROM information_schema.columns c
           JOIN information_schema.tables t USING (table_schema,table_name)
          WHERE c.table_schema='public' AND t.table_type='BASE TABLE' AND c.column_name IN ('tenant_id','CO_CODE')
          GROUP BY c.table_name HAVING count(*)=2 ORDER BY c.table_name`,
      )
    ).map((row) => row.table_name);
  /** Row count of every company-scoped table for one tenant and company. */
  const census = async (tenant: string, coCode: string) => {
    const out: Record<string, number> = {};
    for (const table of await companyTables()) {
      const [{ n }] = await query<[{ n: number }]>(
        `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"::text=$2`,
        tenant,
        coCode,
      );
      if (n) out[table] = n;
    }
    return out;
  };
  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await query(
      `SELECT DISTINCT c.table_name FROM information_schema.columns c
         JOIN information_schema.tables t USING (table_schema,table_name)
        WHERE c.table_schema='public' AND t.table_type='BASE TABLE' AND c.column_name='tenant_id'`,
    );
    await owner.$transaction(async (tx: any) => {
      await tx.$executeRawUnsafe(`SET LOCAL "app.allow_repair_purge" = 'on'`);
      for (const { table_name } of tables)
        await tx.$executeRawUnsafe(
          `DELETE FROM "${table_name}" WHERE tenant_id IN ($1,$2)`,
          tenantId,
          otherTenant,
        );
    });
  };
  /** One synthetic row per company-scoped table, filling only NOT NULL columns that have no default. */
  const seedEveryTable = async (tenant: string, coCode: string, tables: string[]) => {
    const ok: string[] = [];
    for (const table of tables) {
      const columns = await query<{ column_name: string; data_type: string; len: number | null }[]>(
        `SELECT column_name, data_type, character_maximum_length len FROM information_schema.columns
          WHERE table_schema='public' AND table_name=$1 AND is_nullable='NO' AND column_default IS NULL
            AND is_generated='NEVER' AND identity_generation IS NULL AND column_name NOT IN ('tenant_id','CO_CODE')`,
        table,
      );
      const value = (type: string) =>
        /char|text/.test(type)
          ? `'9'`
          : /int|numeric|double|real/.test(type)
            ? '9'
            : /timestamp|date/.test(type)
              ? 'now()'
              : type === 'boolean'
                ? 'false'
                : /json/.test(type)
                  ? `'{}'`
                  : type === 'uuid'
                    ? 'gen_random_uuid()'
                    : 'NULL';
      const names = ['tenant_id', 'CO_CODE', ...columns.map((c) => c.column_name)];
      const values = ['$1', '$2', ...columns.map((c) => value(c.data_type))];
      try {
        await exec(
          `INSERT INTO "${table}"(${names.map((n) => `"${n}"`).join(',')}) VALUES (${values.join(',')})`,
          tenant,
          coCode,
        );
        ok.push(table);
      } catch {
        // A table whose constraints a generic row cannot meet is covered by seedCompany's rows or not at all.
      }
    }
    return ok;
  };
  const login = async (user: string): Promise<Cookie> => {
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: user, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const setCookie = response.headers['set-cookie'];
    return (Array.isArray(setCookie) ? setCookie : [setCookie ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  };
  /** The fingerprint of a fresh preview, as the screen sends it. */
  const fingerprintOf = async (code: string, cookie = adminCookie) =>
    (await request(cookie, 'GET', `/companies/${code}/reset/preview`)).json().fingerprint as string;
  const reset = async (
    body: Record<string, unknown>,
    cookie = adminCookie,
    code = '02',
    name = 'RESET TARGET',
  ) =>
    request(cookie, 'POST', `/companies/${code}/reset`, {
      coCode: code,
      coName: name,
      password: PASSWORD,
      reason: REASON,
      fingerprint: 'fingerprint' in body ? body.fingerprint : await fingerprintOf(code),
      ...body,
    });
  /**
   * A reset keeps the accounts the desktop keeps (numeric code up to 99, Module_Schm.cs:90) and those a kept book,
   * location or CO_SET names, with their groups; the seed then adds the defaults that are missing. Stated here
   * independently of companyReset.ts.
   */
  const expectedRest = async (tenant: string, coCode: string, fresh: Record<string, string[]>) => {
    const refs = `SELECT "AC_CODE" FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE" IS NOT NULL
      UNION SELECT "AC_CODE" FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE" IS NOT NULL`;
    const keptAccounts = `SELECT * FROM "AC_MAST" a WHERE tenant_id=$1 AND "CO_CODE"=$2
      AND (("AC_CODE" ~ '^[0-9]+$' AND "AC_CODE"::numeric <= 99) OR "AC_CODE" IN (${refs}))`;
    const accounts = (
      await query<{ r: string }[]>(
        `SELECT (to_jsonb(a) - 'row_id')::text r FROM (${keptAccounts}) a`,
        tenant,
        coCode,
      )
    ).map((row) => row.r);
    const groups = (
      await query<{ r: string }[]>(
        `SELECT (to_jsonb(g) - 'row_id')::text r FROM "AC_GROUP" g WHERE tenant_id=$1 AND "CO_CODE"=$2
          AND "AC_GR" IN (SELECT "AC_GR" FROM (${keptAccounts}) k WHERE "AC_GR" IS NOT NULL)`,
        tenant,
        coCode,
      )
    ).map((row) => row.r);
    const merge = (kept: string[], defaults: string[] = [], key: string) => {
      const keys = new Set(kept.map((row) => JSON.parse(row)[key]));
      return [...kept, ...defaults.filter((row) => !keys.has(JSON.parse(row)[key]))].sort();
    };
    const out = { ...fresh };
    out.AC_MAST = merge(accounts, fresh.AC_MAST, 'AC_CODE');
    out.AC_GROUP = merge(groups, fresh.AC_GROUP, 'AC_GR');
    // Employee 001 (Module_Schm.cs:136) and every employee a kept book names stay too.
    const employees = (
      await query<{ r: string }[]>(
        `SELECT (to_jsonb(e) - 'row_id')::text r FROM "EMP_MAST" e WHERE tenant_id=$1 AND "CO_CODE"=$2
          AND ("EMP_CODE"='001' OR "EMP_CODE" IN (SELECT "USER_EMP_CODE" FROM "BOOK_DATA"
                 WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "USER_EMP_CODE" IS NOT NULL))`,
        tenant,
        coCode,
      )
    ).map((row) => row.r);
    out.EMP_MAST = merge(employees, fresh.EMP_MAST, 'EMP_CODE');
    for (const key of Object.keys(out)) if (!out[key]!.length) delete out[key];
    return { rest: out, keptRows: accounts.length + groups.length + employees.length };
  };
  const runs = () =>
    query<any[]>(
      `SELECT row_id::text id,co_code,co_year,state,operator,reason,applied_counts,reauthenticated_at
         FROM "data_repair_run" WHERE tenant_id=$1 AND operation_id='company-reset' ORDER BY row_id`,
      tenantId,
    );
  /**
   * Content of every company-scoped table for one company, without the surrogate row ids, sorted, so a fresh seed
   * and a reset-then-reseeded company compare equal.
   */
  const content = async (tenant: string, coCode: string, only?: (table: string) => boolean) => {
    const out: Record<string, string[]> = {};
    for (const table of await companyTables()) {
      if (only && !only(table)) continue;
      const rows = await query<{ r: string }[]>(
        `SELECT (to_jsonb(t) - 'row_id')::text r FROM "${table}" t WHERE tenant_id=$1 AND "CO_CODE"::text=$2`,
        tenant,
        coCode,
      );
      if (rows.length) out[table] = rows.map((row) => row.r).sort();
    }
    return out;
  };
  const resettable = (table: string) => !KEPT_TABLES.has(table) && table !== 'YEAR_MAST';
  let fresh02: Record<string, string[]> = {};
  let fresh01: Record<string, string[]> = {};

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await seedCompany(runtime, tenantId, '02', { coName: 'RESET TARGET' });
    await seedCompany(runtime, tenantId, '03', { coName: 'KEEP SENTINEL' });
    await seedCompany(runtime, otherTenant, '02', { coName: 'RESET TARGET' });
    // What a freshly provisioned company holds outside the kept tables: the default masters.
    fresh02 = await content(tenantId, '02', resettable);
    fresh01 = await content(tenantId, '01', resettable);
    const tables = (await companyTables()).filter((table) => table !== 'CO_MAST');
    seeded = await seedEveryTable(tenantId, '02', tables);
    seeded03 = await seedEveryTable(tenantId, '03', seeded);
    await seedEveryTable(otherTenant, '02', seeded);
    await seedEveryTable(tenantId, '01', ['AC_DATA', 'SL_DATA', 'MAIN_STOCK', 'ITEM_MAST']);
    // A default master edited by the user goes back to its default; a kept row edited stays edited.
    await exec(
      `UPDATE "AC_GROUP" SET "AC_GR_NAME"='RENAMED BY USER' WHERE tenant_id=$1 AND "CO_CODE"='02' AND "AC_GR"='00'`,
      tenantId,
    );
    // A kept book names its user's employee: that employee stays.
    await exec(
      `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME") VALUES ($1,'02','E77','BOOK USER')`,
      tenantId,
    );
    await exec(
      `UPDATE "BOOK_DATA" SET "USER_EMP_CODE"='E77' WHERE tenant_id=$1 AND "CO_CODE"='02' AND "CO_BOOK"='SL'`,
      tenantId,
    );
    await exec(
      `UPDATE "CO_MAST" SET "CO_ADD1"='KEPT ROAD' WHERE tenant_id=$1 AND "CO_CODE"='02'`,
      tenantId,
    );
    const passwordHash = await hashPassword(PASSWORD);
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01',$2,$4,'ADMIN','Y','Y','Y','N'),($1,'01',$3,$4,'USER','Y','Y','Y','N'),
              ($1,'02','rsother',$4,'USER','Y','Y','Y','N')`,
      tenantId,
      ADMIN,
      CLERK,
      passwordHash,
    );
    await exec(
      `INSERT INTO "auth_session"(tenant_id,session_id,login_name,login_co_code,co_code,lc_code,refresh_jti_hash,expires_at)
       VALUES ($1,'rs-session-02','rsother','02','02','01',repeat('a',64),now()+interval '1 day'),
              ($1,'rs-session-03','rsother','03','03','01',repeat('b',64),now()+interval '1 day'),
              ($1,'rs-session-01','rsclerk','01','01','01',repeat('d',64),now()+interval '1 day'),
              ($2,'rs-session-x2','rsother','02','02','01',repeat('c',64),now()+interval '1 day')`,
      tenantId,
      otherTenant,
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    adminCookie = await login(ADMIN);
    clerkCookie = await login(CLERK);
  }, 120_000);

  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('seeds a sentinel row in nearly every company-scoped table', async () => {
    expect(seeded.length).toBeGreaterThan(100);
    expect(seeded03.length).toBeGreaterThan(100);
  });

  it('previews what is kept (identity, settings, books, users, locations, one year) and what is deleted', async () => {
    const all = await census(tenantId, '02');
    const response = await request(adminCookie, 'GET', '/companies/02/reset/preview');
    expect(response.statusCode, response.body).toBe(200);
    const preview = response.json();
    expect(preview).toMatchObject({
      coCode: '02',
      coName: 'RESET TARGET',
      keptYear: YEAR,
      reasonMinLength: 12,
    });
    const kept = Object.fromEntries(preview.kept.map((t: any) => [t.table, t.rows]));
    const deleted = Object.fromEntries(preview.deleted.map((t: any) => [t.table, t.rows]));
    expect(kept.YEAR_MAST).toBe(1);
    expect(deleted.YEAR_MAST).toBe(all.YEAR_MAST! - 1);
    for (const table of ['CO_MAST', 'CO_SET', 'BOOK_DATA', 'BOOK_DETL', 'LOGIN_MAST', 'LOCT_MAST'])
      expect(kept[table], table).toBe(all[table]);
    for (const [table, rows] of Object.entries(all))
      expect((kept[table] ?? 0) + (deleted[table] ?? 0), table).toBe(rows);
    expect(preview.kinds.years).toBe(all.YEAR_MAST! - 1);
    expect(preview.kinds.vouchers).toBeGreaterThan(0);
    expect(preview.kinds.masters).toBeGreaterThan(0);
    expect(preview.deletedTotal + preview.keptTotal).toBe(
      Object.values(all).reduce((a, b) => a + b, 0),
    );
    expect((await request(adminCookie, 'GET', '/companies/99/reset/preview')).statusCode).toBe(404);
  });

  it('refuses a non-admin, wrong code or name, wrong password and a short reason', async () => {
    const before = await census(tenantId, '02');
    expect((await request(clerkCookie, 'GET', '/companies/02/reset/preview')).statusCode).toBe(403);
    expect((await reset({ fingerprint: '0'.repeat(64) }, clerkCookie)).statusCode).toBe(403);
    const refusal = async (body: Record<string, unknown>, status: number, code: string) => {
      const response = await reset(body);
      expect(response.statusCode, response.body).toBe(status);
      expect(response.json().code).toBe(code);
    };
    await refusal({ coCode: '03' }, 400, 'confirmation-mismatch');
    await refusal({ coName: 'reset target' }, 400, 'confirmation-mismatch');
    await refusal({ coName: 'RESET TARGET ' }, 400, 'confirmation-mismatch');
    await refusal({ password: 'wrong-password-1!' }, 403, 'reauthentication-failed');
    await refusal({ reason: 'too short' }, 400, 'reason-required');
    // The data moved after the preview the admin confirmed.
    const confirmed = await fingerprintOf('02');
    await exec(
      `UPDATE "AC_DATA" SET "CR_AMT"=coalesce("CR_AMT",0)+1 WHERE tenant_id=$1 AND "CO_CODE"='02'`,
      tenantId,
    );
    await refusal({ fingerprint: confirmed }, 409, 'stale-preview');
    await exec(
      `UPDATE "AC_DATA" SET "CR_AMT"="CR_AMT"-1 WHERE tenant_id=$1 AND "CO_CODE"='02'`,
      tenantId,
    );
    expect(await census(tenantId, '02')).toEqual(before);
    expect(await runs()).toEqual([]);
  });

  it('fingerprints binary content, including same-length changes, without changing row counts', async () => {
    await exec(
      `INSERT INTO "IMAGE_DATA"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","TAG_IMAGE")
       VALUES ($1,'02','01','RESET-HASH',decode('00ff','hex'))`,
      tenantId,
    );
    try {
      const fingerprint = await fingerprintOf('02');
      await exec(
        `UPDATE "IMAGE_DATA" SET "TAG_IMAGE"=decode('01ff','hex')
         WHERE tenant_id=$1 AND "CO_CODE"='02' AND "TAG_NO"='RESET-HASH'`,
        tenantId,
      );
      expect(await fingerprintOf('02')).not.toBe(fingerprint);
      const response = await reset({ fingerprint });
      expect(response.statusCode, response.body).toBe(409);
      expect(response.json().code).toBe('stale-preview');
      await exec(
        `UPDATE "IMAGE_DATA" SET "TAG_IMAGE"=decode('00ff','hex')
         WHERE tenant_id=$1 AND "CO_CODE"='02' AND "TAG_NO"='RESET-HASH'`,
        tenantId,
      );
      expect(await fingerprintOf('02')).toBe(fingerprint);
    } finally {
      await exec(
        `DELETE FROM "IMAGE_DATA" WHERE tenant_id=$1 AND "CO_CODE"='02' AND "TAG_NO"='RESET-HASH'`,
        tenantId,
      );
    }
  });

  it('holds off only the reset company: its writes are refused, other companies and tenants write on', async () => {
    // Hold company 02's write key exclusively, as a running reset of 02 does.
    let release!: () => void;
    const held = new Promise<void>((resolve) => (release = resolve));
    let locked!: () => void;
    const isLocked = new Promise<void>((resolve) => (locked = resolve));
    const holder = owner.$transaction(
      async (tx: any) => {
        await tx.$executeRawUnsafe(
          'SELECT pg_advisory_xact_lock(hashtextextended($1, 0))',
          companyWriteLockKey(tenantId, '02'),
        );
        locked();
        await held;
      },
      { timeout: 60_000 },
    );
    await isLocked;
    try {
      const write = (tenant: string, coCode: string) =>
        runWithCompanyWriteScope({ tenantId: tenant, coCode }, () =>
          withTxBudget(runtime, tenant, 'voucher', (tx: any) =>
            tx.$executeRawUnsafe(
              `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","VCH_NO") VALUES ($1,$2,'LOCKT')`,
              tenant,
              coCode,
            ),
          ),
        );
      const started = Date.now();
      await expect(write(tenantId, '02')).rejects.toBeInstanceOf(CompanyBusyError);
      await expect(write(tenantId, '03')).resolves.toBe(1);
      await expect(write(otherTenant, '02')).resolves.toBe(1);
      expect(Date.now() - started).toBeLessThan(2_000);
      // Reads are never held off.
      await expect(
        runWithCompanyWriteScope({ tenantId, coCode: '02' }, () =>
          withTxBudget(runtime, tenantId, 'read', (tx: any) => tx.$queryRawUnsafe(`SELECT 1 n`)),
        ),
      ).resolves.toEqual([{ n: 1 }]);
      // Through HTTP: the admin works in 01, so a held 02 does not stop an edit of 01, and a held 01 refuses it
      // with a retryable 503.
      const body = (row: Record<string, unknown>) => {
        const { version, ...fields } = row;
        return Object.fromEntries([
          ...Object.entries(fields).filter(([, value]) => value !== null),
          ['expectedVersion', version],
        ]);
      };
      const current = (await request(adminCookie, 'GET', '/company-identity/01')).json();
      const ok = await request(adminCookie, 'PUT', '/company-identity', body(current));
      expect(ok.statusCode, ok.body).toBe(200);
      const again = (await request(adminCookie, 'GET', '/company-identity/01')).json();
      let release01!: () => void;
      const held01 = new Promise<void>((resolve) => (release01 = resolve));
      let locked01!: () => void;
      const isLocked01 = new Promise<void>((resolve) => (locked01 = resolve));
      const holder01 = owner.$transaction(
        async (tx: any) => {
          await tx.$executeRawUnsafe(
            'SELECT pg_advisory_xact_lock(hashtextextended($1, 0))',
            companyWriteLockKey(tenantId, '01'),
          );
          locked01();
          await held01;
        },
        { timeout: 60_000 },
      );
      await isLocked01;
      const busy = await request(adminCookie, 'PUT', '/company-identity', body(again));
      release01();
      await holder01;
      expect(busy.statusCode, busy.body).toBe(503);
      expect(busy.json()).toMatchObject({ error: 'company-busy', retryable: true });
    } finally {
      release();
      await holder;
      await exec(
        `DELETE FROM "AC_DATA" WHERE tenant_id IN ($1,$2) AND "VCH_NO"='LOCKT'`,
        tenantId,
        otherTenant,
      );
    }
  });

  it('resets 02 while another company has a write transaction open', async () => {
    // An open write of company 03 to a table the reset clears (the old table lock would have waited for it).
    let release!: () => void;
    const held = new Promise<void>((resolve) => (release = resolve));
    let written!: () => void;
    const isWritten = new Promise<void>((resolve) => (written = resolve));
    const writer = owner.$transaction(
      async (tx: any) => {
        await tx.$executeRawUnsafe(
          `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","VCH_NO") VALUES ($1,'03','LOCKT')`,
          tenantId,
        );
        written();
        await held;
        throw new Error('rolled back on purpose');
      },
      { timeout: 60_000 },
    );
    await isWritten;
    try {
      const fingerprint = await fingerprintOf('02');
      // Only checks that the reset is not blocked: the stale fingerprint answer comes at once, after the locks.
      const started = Date.now();
      const response = await reset({ fingerprint: '0'.repeat(64) });
      expect(response.statusCode, response.body).toBe(409);
      expect(response.json().code).toBe('stale-preview');
      expect(Date.now() - started).toBeLessThan(5_000);
      expect(fingerprint).toMatch(/^[0-9a-f]{64}$/);
    } finally {
      release();
      await writer.catch(() => undefined);
    }
  });

  it('keeps the preview valid across a login', async () => {
    const fingerprint = await fingerprintOf('02');
    await exec(
      `UPDATE "LOGIN_MAST" SET "FAILED_LOGIN_COUNT"=coalesce("FAILED_LOGIN_COUNT",0)+1 WHERE tenant_id=$1 AND "CO_CODE"='02'`,
      tenantId,
    );
    expect(await fingerprintOf('02')).toBe(fingerprint);
    await exec(
      `UPDATE "LOGIN_MAST" SET "FAILED_LOGIN_COUNT"=0 WHERE tenant_id=$1 AND "CO_CODE"='02'`,
      tenantId,
    );
  });

  it('refuses a second reset while one holds the company lock', async () => {
    const before = await census(tenantId, '02');
    let release!: () => void;
    const held = new Promise<void>((resolve) => (release = resolve));
    let locked!: () => void;
    const isLocked = new Promise<void>((resolve) => (locked = resolve));
    const holder = owner.$transaction(
      async (tx: any) => {
        await tx.$executeRawUnsafe(
          'SELECT pg_advisory_xact_lock(hashtext($1))',
          `company-reset:${tenantId}:02`,
        );
        locked();
        await held;
      },
      { timeout: 60_000 },
    );
    await isLocked;
    const response = await reset({});
    release();
    await holder;
    expect(response.statusCode, response.body).toBe(409);
    expect(response.json().code).toBe('reset-in-progress');
    expect(await census(tenantId, '02')).toEqual(before);
  });

  it('clears 02 to a fresh company, keeps what is kept, archives exactly the deleted rows, and audits', async () => {
    const keptBefore = await content(tenantId, '02', (table) => KEPT_TABLES.has(table));
    const yearsBefore = await query<{ r: string }[]>(
      `SELECT to_jsonb(t)::text r FROM "YEAR_MAST" t WHERE tenant_id=$1 AND "CO_CODE"='02' AND "CO_YEAR"=$2`,
      tenantId,
      YEAR,
    );
    const deletedRows = await query<{ t: string; r: any }[]>(
      `SELECT 'AC_DATA' t, to_jsonb(a) r FROM "AC_DATA" a WHERE tenant_id=$1 AND "CO_CODE"='02'`,
      tenantId,
    );
    const preview = (await request(adminCookie, 'GET', '/companies/02/reset/preview')).json();
    const expected = await expectedRest(tenantId, '02', fresh02);
    const before03 = await content(tenantId, '03');
    const beforeOther = await content(otherTenant, '02');
    const [first, second] = await Promise.all([reset({}), reset({})]);
    const statuses = [first.statusCode, second.statusCode].sort();
    // One reset runs; the concurrent one is refused: the lock is held, or the data moved since its preview.
    expect(statuses, first.body + second.body).toEqual([200, 409]);
    const refused = (first.statusCode === 409 ? first : second).json();
    expect(['reset-in-progress', 'stale-preview']).toContain(refused.code);
    const ok = (first.statusCode === 200 ? first : second).json();
    expect(ok).toMatchObject({
      coCode: '02',
      coName: 'RESET TARGET',
      revokedSessions: 1,
      ownCompany: false,
      keptYear: YEAR,
      archived: preview.deletedTotal,
    });
    expect(ok.deleted).toEqual(preview.deleted);
    expect(
      await query<{ n: number }[]>(
        `SELECT count(*)::int n FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"='02' AND "EMP_CODE"='E77'`,
        tenantId,
      ),
    ).toEqual([{ n: 1 }]);
    // Kept exactly, including the edited identity.
    expect(await content(tenantId, '02', (table) => KEPT_TABLES.has(table))).toEqual(keptBefore);
    expect(
      await query<{ r: string }[]>(
        `SELECT to_jsonb(t)::text r FROM "YEAR_MAST" t WHERE tenant_id=$1 AND "CO_CODE"='02'`,
        tenantId,
      ),
    ).toEqual(yearsBefore);
    // Everything else equals a freshly provisioned company plus the kept accounts and their groups.
    expect(await content(tenantId, '02', resettable)).toEqual(expected.rest);
    expect(ok.restoredDefaults).toBe(
      Object.values(expected.rest).reduce((a, b) => a + b.length, 0) - expected.keptRows,
    );
    // Other company and other tenant untouched.
    expect(await content(tenantId, '03')).toEqual(before03);
    expect(await content(otherTenant, '02')).toEqual(beforeOther);
    // Sessions: only the other session on 02 ends; the caller's stays.
    expect((await request(adminCookie, 'GET', '/me')).statusCode).toBe(200);
    const sessions = await query<any[]>(
      `SELECT tenant_id,session_id,revoke_reason FROM auth_session WHERE session_id LIKE 'rs-session-%' ORDER BY tenant_id,session_id`,
    );
    expect(sessions).toEqual([
      { tenant_id: tenantId, session_id: 'rs-session-01', revoke_reason: null },
      { tenant_id: tenantId, session_id: 'rs-session-02', revoke_reason: 'company-reset' },
      { tenant_id: tenantId, session_id: 'rs-session-03', revoke_reason: null },
      { tenant_id: otherTenant, session_id: 'rs-session-x2', revoke_reason: null },
    ]);
    // Audit row and archive.
    const [run, ...more] = await runs();
    expect(more).toEqual([]);
    expect(run).toMatchObject({
      id: ok.runId,
      co_code: '02',
      co_year: YEAR,
      state: 'applied',
      operator: ADMIN,
      reason: REASON,
    });
    expect(run.reauthenticated_at).not.toBeNull();
    const archiveCounts = await query<{ table_name: string; n: number }[]>(
      `SELECT table_name, count(*)::int n FROM company_reset_archive
        WHERE tenant_id=$1 AND run_id=$2::bigint AND co_code='02' GROUP BY table_name ORDER BY table_name`,
      tenantId,
      ok.runId,
    );
    const archived = Object.fromEntries(archiveCounts.map((row) => [row.table_name, row.n]));
    expect(archived).toEqual(
      Object.fromEntries(preview.deleted.map((t: any) => [t.table, t.rows])),
    );
    expect(Object.fromEntries(run.applied_counts.map((d: any) => [d.table, d.delete]))).toEqual(
      archived,
    );
    const archivedAcData = await query<{ r: any }[]>(
      `SELECT row_data r FROM company_reset_archive WHERE tenant_id=$1 AND run_id=$2::bigint AND table_name='AC_DATA'`,
      tenantId,
      ok.runId,
    );
    expect(archivedAcData.map((row) => row.r)).toEqual(deletedRows.map((row) => row.r));
    // Support's recovery (desktop-adaptations.md "Recovering archived rows"): the AC_DATA rows come back as they were.
    const columns = (
      await query<{ c: string }[]>(
        `SELECT column_name c FROM information_schema.columns
          WHERE table_schema='public' AND table_name='AC_DATA' AND column_name<>'row_id' ORDER BY ordinal_position`,
      )
    ).map((row) => `"${row.c}"`);
    await exec(
      `INSERT INTO "AC_DATA" (${columns.join(',')})
       SELECT ${columns.map((c) => `r.${c}`).join(',')}
         FROM company_reset_archive x, jsonb_populate_record(NULL::"AC_DATA", x.row_data) r
        WHERE x.tenant_id=$1 AND x.run_id=$2::bigint AND x.table_name='AC_DATA'`,
      tenantId,
      ok.runId,
    );
    const recovered = await query<{ r: string }[]>(
      `SELECT (to_jsonb(a) - 'row_id')::text r FROM "AC_DATA" a WHERE tenant_id=$1 AND "CO_CODE"='02' ORDER BY 1`,
      tenantId,
    );
    const canonical = (value: Record<string, unknown>) =>
      JSON.stringify(
        Object.fromEntries(Object.entries(value).sort(([a], [b]) => a.localeCompare(b))),
      );
    expect(recovered.map((row) => canonical(JSON.parse(row.r))).sort()).toEqual(
      deletedRows
        .map((row) => {
          const { row_id: _id, ...rest } = row.r;
          return canonical(rest);
        })
        .sort(),
    );
    // The archive survives and is protected.
    await expect(
      exec(`UPDATE company_reset_archive SET table_name='X' WHERE tenant_id=$1`, tenantId),
    ).rejects.toThrow(/immutable/);
    await expect(
      exec(`DELETE FROM company_reset_archive WHERE tenant_id=$1`, tenantId),
    ).rejects.toThrow(/immutable/);
    await expect(
      exec(
        `UPDATE "data_repair_run" SET reason='x' WHERE tenant_id=$1 AND operation_id='company-reset'`,
        tenantId,
      ),
    ).rejects.toThrow(/immutable/);
    // The runtime role sees only its own tenant's archive.
    const foreign = await runtime.$transaction(async (tx: any) => {
      await tx.$executeRawUnsafe(`SELECT set_config('app.tenant_id',$1,true)`, otherTenant);
      return tx.$queryRawUnsafe(`SELECT count(*)::int n FROM company_reset_archive`);
    });
    expect(foreign).toEqual([{ n: 0 }]);
  });

  it('resets 01, the company the caller works in, and keeps the caller signed in', async () => {
    const expected = await expectedRest(tenantId, '01', fresh01);
    const response = await reset({}, adminCookie, '01', 'Company 01');
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json()).toMatchObject({ coCode: '01', ownCompany: true });
    expect(await content(tenantId, '01', resettable)).toEqual(expected.rest);
    const logins = await query<{ n: number }[]>(
      `SELECT count(*)::int n FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    expect(logins).toEqual([{ n: 2 }]);
    expect((await request(adminCookie, 'GET', '/me')).statusCode).toBe(200);
    expect((await request(adminCookie, 'GET', '/companies/01/reset/preview')).json()).toMatchObject(
      {
        keptYear: YEAR,
      },
    );
    const [{ reason }] = await query<[{ reason: string }]>(
      `SELECT revoke_reason reason FROM auth_session WHERE tenant_id=$1 AND session_id='rs-session-01'`,
      tenantId,
    );
    expect(reason).toBe('company-reset');
  });

  it('archives 50,000 voucher rows and 20 MB of images within the heavy budget', async () => {
    await exec(
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","CR_AMT")
       SELECT $1,'03','01',$2,'SL',lpad(g::text,5,'0'),'CASH',g FROM generate_series(1,50000) g`,
      tenantId,
      YEAR,
    );
    // 100 tag images of 200 KB each.
    await exec(
      `INSERT INTO "IMAGE_DATA"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","TAG_IMAGE")
       SELECT $1,'03','01','T'||g, decode(repeat(md5(g::text),12800),'hex') FROM generate_series(1,100) g`,
      tenantId,
    );
    const started = Date.now();
    const response = await reset({}, adminCookie, '03', 'KEEP SENTINEL');
    const ms = Date.now() - started;
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json().archived).toBeGreaterThan(50_100);
    // The image bytes come back through jsonb_populate_record, as support's recovery reads them.
    const [{ bytes }] = await query<[{ bytes: number }]>(
      `SELECT sum(length(r."TAG_IMAGE"))::int bytes
         FROM company_reset_archive x, jsonb_populate_record(NULL::"IMAGE_DATA", x.row_data) r
        WHERE x.tenant_id=$1 AND x.table_name='IMAGE_DATA' AND x.co_code='03'`,
      tenantId,
    );
    expect(bytes).toBeGreaterThanOrEqual(100 * 204_800);
    console.info(
      `company reset of ${response.json().archived} rows (20 MB of images) took ${ms} ms`,
    );
    expect(ms).toBeLessThan(30_000);
  }, 120_000);
});
