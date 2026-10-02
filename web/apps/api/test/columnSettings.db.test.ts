import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import {
  createColumnSetting,
  deleteColumnSetting,
  listColumnSettings,
  updateColumnSetting,
} from '../src/modules/masters/columnSettings.js';
import { getSaleReturnIncomingConfiguration } from '../src/modules/sales/saleReturnIncomingConfiguration.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
type Listed = {
  row_id: string;
  CO_CODE: string;
  BOOK_NAME: string | null;
  COL_NAME: string | null;
  COL_NEW_NAME: string | null;
  COL_RPT: string | null;
  YES_NO: string | null;
  _columnVersion: string;
  _columnCollectionVersion: string;
  _columnIdentityCount: number;
  _columnTotal: number;
};
type Role = 'writer' | 'view' | 'unrelated' | 'other';
run('column settings exact family lifecycle through PostgreSQL and authenticated HTTP', () => {
  const tenantId = 'column-settings-r8';
  const otherTenant = 'column-settings-other';
  const scope = { tenantId, coCode: '01', lcCode: '01' };
  const key = { CO_CODE: '01', BOOK_NAME: 'SALES RETURNE', COL_NAME: 'Fine' };
  const password = 'Column-Lifecycle!2026';
  const businessTables = [
    'COL_MAST',
    'CO_SET',
    'CO_SET_NEW',
    'BOOK_DATA',
    'YEAR_MAST',
    'SL_DATA',
    'SL_DETL_RTN',
    'MAIN_STOCK',
    'AC_DATA',
    'SRNO_MAST',
  ];
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Partial<Record<Role, string>> = {};
  const sql = (query: string, ...values: unknown[]) => owner.$executeRawUnsafe(query, ...values);
  const insert = async (table: string, values: Record<string, unknown>) => {
    const columns = Object.keys(values)
      .map((name) => `"${name}"`)
      .join(',');
    await sql(
      `INSERT INTO "${table}" (${columns}) SELECT ${columns} FROM jsonb_populate_record(NULL::"${table}",$1::jsonb)`,
      JSON.stringify(values),
    );
  };
  const column = (values: Record<string, unknown> = {}) =>
    insert('COL_MAST', {
      tenant_id: tenantId,
      ...key,
      COL_NEW_NAME: null,
      COL_RPT: '',
      YES_NO: 'Y',
      ...values,
    });
  const list = async (options: Parameters<typeof listColumnSettings>[2] = {}) =>
    (await listColumnSettings(runtime, scope, options)) as unknown as Listed[];
  const fine = async () => {
    const rows = await list({ family: key.BOOK_NAME });
    const row = rows.find((value) => value.COL_NAME === key.COL_NAME);
    if (!row) throw new Error('Expected scoped Fine fixture.');
    return row;
  };
  const path = (suffix = '', query: Record<string, unknown> = {}) =>
    `/masters/styles${suffix}?${new URLSearchParams(
      Object.entries({ coCode: '01', lcCode: '01', coYear: '2024-2025', ...query })
        .filter(([, value]) => value !== undefined)
        .map(([name, value]): [string, string] => [name, String(value)]),
    )}`;
  const request = (
    method: 'GET' | 'POST' | 'PUT' | 'DELETE',
    url: string,
    payload?: Record<string, unknown>,
    role: Role | 'anonymous' = 'writer',
  ) =>
    app.inject({
      method,
      url,
      ...(payload === undefined ? {} : { payload }),
      headers: role === 'anonymous' ? {} : { cookie: cookies[role] ?? '' },
    });
  const httpRows = async (query: Record<string, string> = {}, role: Role = 'writer') => {
    const response = await request('GET', path('', query), undefined, role);
    expect(response.statusCode, response.body).toBe(200);
    expect(response.headers['cache-control']).toBe('no-store');
    return response.json<Listed[]>();
  };
  const snapshot = async (excludeTarget = false) => {
    const result: Record<string, unknown> = {};
    for (const table of businessTables) {
      const rows = await owner.$queryRawUnsafe<
        Array<{ raw: string; revision: string; locator: string }>
      >(
        `SELECT to_jsonb(t)::text raw,t.xmin::text revision,t.ctid::text locator FROM "${table}" t WHERE tenant_id IN($1,$2) ORDER BY to_jsonb(t)::text`,
        tenantId,
        otherTenant,
      );
      result[table] =
        excludeTarget && table === 'COL_MAST'
          ? rows.filter((row) => {
              const raw = JSON.parse(row.raw) as Record<string, unknown>;
              return !(
                raw.tenant_id === tenantId &&
                raw.CO_CODE === key.CO_CODE &&
                raw.BOOK_NAME === key.BOOK_NAME &&
                raw.COL_NAME === key.COL_NAME
              );
            })
          : rows;
    }
    return result;
  };
  const clean = async () => {
    for (const table of [
      'audit_log',
      'auth_session',
      ...businessTables,
      'USER_SET',
      'LOGIN_MAST',
      'LOCT_MAST',
      'CO_MAST',
    ])
      await sql(`DELETE FROM "${table}" WHERE tenant_id IN($1,$2)`, tenantId, otherTenant);
  };
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await clean();
    const hashed = await hashPassword(password);
    for (const tenant of [tenantId, otherTenant]) {
      await insert('CO_MAST', {
        tenant_id: tenant,
        CO_CODE: '01',
        CO_NAME: 'Column settings test',
        LC_CODE: '01',
      });
      for (const lcCode of ['01', '02'])
        await insert('LOCT_MAST', {
          tenant_id: tenant,
          CO_CODE: '01',
          LC_CODE: lcCode,
          LC_NAME: 'Test branch',
        });
      await insert('YEAR_MAST', {
        tenant_id: tenant,
        CO_CODE: '01',
        CO_YEAR: '2024-2025',
        OP_DATE: '2024-04-01',
        CL_DATE: '2025-03-31',
      });
      await insert('BOOK_DATA', {
        tenant_id: tenant,
        CO_CODE: '01',
        LC_CODE: '01',
        CO_BOOK: 'R81',
        MAIN_BOOK: 'SALES RETURNE',
        BOOK_NAME: 'Configured Return',
        BOOK_INOUT: 'I',
        BOOK_TBL_NAME: 'SL_DATA',
        CUR_USE: 'Y',
      });
      await insert('CO_SET', {
        tenant_id: tenant,
        CO_CODE: '01',
        SL_AMT_TYPE: 'F',
        LBR_ROF: 2,
        LBR_RATE_GEN: 'N',
        ALL_ROF_REMOVE: 'N',
        LBR_TYPE: 'G',
      });
      await insert('CO_SET_NEW', { tenant_id: tenant, CO_CODE: '01', LBR_WITH_GHT: 'Y' });
      for (const role of ['writer', 'view', 'unrelated'] as const) {
        await insert('LOGIN_MAST', {
          tenant_id: tenant,
          CO_CODE: '01',
          LOGIN_NAME: role,
          LOGIN_PWD: hashed,
          LOGIN_CATG: 'USER',
          USER_UPDATE: role === 'writer' ? 'Y' : 'N',
          USER_DELETE: role === 'writer' ? 'Y' : 'N',
          USER_PRINT: 'N',
          PASSWORD_RESET_REQUIRED: 'N',
        });
        await insert('USER_SET', {
          tenant_id: tenant,
          CO_CODE: '01',
          LC_CODE: '01',
          USER_NAME: role,
          MAIN_MENU: 'Masters',
          SUB_MENU: role === 'unrelated' ? 'Design Book' : 'Styles / Columns',
          FRM_VIEW: 'Y',
          FRM_EDIT: role === 'writer' ? 'Y' : 'N',
          FRM_DELETE: role === 'writer' ? 'Y' : 'N',
          FRM_PRINT: 'N',
        });
      }
    }
    await insert('SL_DATA', {
      tenant_id: tenantId,
      CO_CODE: '01',
      LC_CODE: '01',
      CO_YEAR: '2024-2025',
      CO_BOOK: 'R81',
      VCH_NO: '00017',
      VCH_TIME: '2024-07-08T09:10:11.123456',
      AC_NAME: 'Untouched saved customer',
      NET_AMT: '9999999999999999.99',
    });
    await insert('SL_DETL_RTN', {
      tenant_id: tenantId,
      CO_CODE: '01',
      LC_CODE: '01',
      CO_YEAR: '2024-2025',
      CO_BOOK: 'R81',
      VCH_NO: '00017',
      SR_NO: 42,
      OLD_SRNO: 58,
      VCH_SRNO: 9017,
      IT_CODE: 'GOLD',
      ITM_FINE: null,
      ITM_REMARK: '',
    });
    app = await buildApp({
      prisma: runtime,
      secret: 'column-setting-http-test-secret-over-thirty-two-characters',
      secureCookies: false,
    });
    for (const role of ['writer', 'view', 'unrelated', 'other'] as const) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': role === 'other' ? otherTenant : tenantId },
        payload: {
          coCode: '01',
          lcCode: '01',
          coYear: '2024-2025',
          loginName: role === 'other' ? 'writer' : role,
          password,
        },
      });
      expect(response.statusCode, response.body).toBe(200);
      const raw = response.headers['set-cookie'];
      cookies[role] = (Array.isArray(raw) ? raw : [raw ?? ''])
        .map((value) => value.split(';', 1)[0])
        .join('; ');
    }
  });
  beforeEach(async () => {
    await sql('DELETE FROM "COL_MAST" WHERE tenant_id IN($1,$2)', tenantId, otherTenant);
    await column();
    await column({
      BOOK_NAME: 'SALES',
      COL_NEW_NAME: 'Other family sentinel',
      COL_RPT: 'Y',
      YES_NO: 'N',
    });
    await column({ CO_CODE: '02', COL_NEW_NAME: 'Other company sentinel' });
    await column({ tenant_id: otherTenant, COL_NEW_NAME: 'Other tenant sentinel' });
    await sql(
      "UPDATE \"USER_SET\" SET \"FRM_VIEW\"='Y',\"FRM_EDIT\"=CASE WHEN \"USER_NAME\"='writer' THEN 'Y' ELSE 'N' END,\"FRM_DELETE\"=CASE WHEN \"USER_NAME\"='writer' THEN 'Y' ELSE 'N' END WHERE tenant_id IN($1,$2)",
      tenantId,
      otherTenant,
    );
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await clean();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('lists complete exact family identity, NULL/blank values and physical versions without writes', async () => {
    const before = await snapshot();
    const rows = await list();
    expect(rows).toHaveLength(2);
    const target = rows.find((row) => row.BOOK_NAME === key.BOOK_NAME)!;
    expect(target).toMatchObject({
      ...key,
      COL_NEW_NAME: null,
      COL_RPT: '',
      YES_NO: 'Y',
      _columnIdentityCount: 1,
      _columnTotal: 2,
    });
    expect(target.row_id).toMatch(/^\d+$/);
    expect(target._columnVersion).toMatch(/^[a-f0-9]{64}$/);
    expect(target._columnCollectionVersion).toMatch(/^[a-f0-9]{64}$/);
    expect(target).not.toHaveProperty('_revision');
    expect(target).not.toHaveProperty('_physical');
    expect(await snapshot()).toEqual(before);
  });

  it('updates and deletes only the complete company/family/original-name key', async () => {
    const original = await fine();
    const collateral = await snapshot(true);
    await updateColumnSetting(runtime, scope, {
      ...key,
      version: original._columnVersion,
      COL_NEW_NAME: 'Return fine only',
    });
    const updated = await fine();
    expect(updated).toMatchObject({
      ...key,
      COL_NEW_NAME: 'Return fine only',
      COL_RPT: '',
      YES_NO: 'Y',
    });
    expect(updated._columnVersion).not.toBe(original._columnVersion);
    expect(await snapshot(true)).toEqual(collateral);
    await deleteColumnSetting(runtime, scope, { ...key, version: updated._columnVersion });
    expect((await list()).map((row) => row.BOOK_NAME)).toEqual(['SALES']);
    expect(await snapshot(true)).toEqual(collateral);
  });

  it('creates an independent family with the same original name and keeps omitted values NULL', async () => {
    await createColumnSetting(runtime, scope, {
      BOOK_NAME: 'NEW FAMILY',
      COL_NAME: 'Fine',
      COL_NEW_NAME: '',
    });
    const rows = await list({ family: 'NEW FAMILY' });
    expect(rows).toHaveLength(1);
    expect(rows[0]).toMatchObject({
      CO_CODE: '01',
      BOOK_NAME: 'NEW FAMILY',
      COL_NAME: 'Fine',
      COL_NEW_NAME: '',
      COL_RPT: null,
      YES_NO: null,
    });
    expect((await fine()).COL_NEW_NAME).toBeNull();
  });

  it('preserves untouched unusual imported flags and exact NULLs while permitting explicit empty/NULL edits', async () => {
    await sql(
      'UPDATE "COL_MAST" SET "COL_RPT"=\'imported-unusual\',"YES_NO"=NULL WHERE tenant_id=$1 AND "CO_CODE"=\'01\' AND "BOOK_NAME"=$2',
      tenantId,
      key.BOOK_NAME,
    );
    const original = await fine();
    await updateColumnSetting(runtime, scope, {
      ...key,
      version: original._columnVersion,
      COL_NEW_NAME: '',
    });
    const changed = await fine();
    expect(changed).toMatchObject({ COL_NEW_NAME: '', COL_RPT: 'imported-unusual', YES_NO: null });
    await updateColumnSetting(runtime, scope, {
      ...key,
      version: changed._columnVersion,
      COL_NEW_NAME: null,
      COL_RPT: 'imported-unusual',
    });
    expect(await fine()).toMatchObject({
      COL_NEW_NAME: null,
      COL_RPT: 'imported-unusual',
      YES_NO: null,
    });
    const before = await snapshot();
    await expect(
      updateColumnSetting(runtime, scope, {
        ...key,
        version: (await fine())._columnVersion,
        YES_NO: 'invalid',
      }),
    ).rejects.toMatchObject({ statusCode: 400 });
    expect(await snapshot()).toEqual(before);
  });

  it('contains duplicate physical rows before search filtering and refuses every mutation on that key', async () => {
    const initial = await fine();
    await column({ COL_NEW_NAME: 'Second imported row' });
    const filtered = await list({ family: key.BOOK_NAME, search: 'Second imported row' });
    expect(filtered).toHaveLength(1);
    expect(filtered[0]!._columnIdentityCount).toBe(2);
    const before = await snapshot();
    for (const mutation of [
      () => createColumnSetting(runtime, scope, key),
      () =>
        updateColumnSetting(runtime, scope, {
          ...key,
          version: initial._columnVersion,
          YES_NO: 'N',
        }),
      () => deleteColumnSetting(runtime, scope, { ...key, version: initial._columnVersion }),
    ])
      await expect(mutation()).rejects.toMatchObject({
        statusCode: 409,
        code: 'ambiguous-column-setting',
      });
    expect(await snapshot()).toEqual(before);
  });

  it('rejects stale update/delete after row A→B→A and after physical deletion/recreation', async () => {
    const initial = await fine();
    await sql(
      'UPDATE "COL_MAST" SET "COL_NEW_NAME"=\'B\' WHERE tenant_id=$1 AND "CO_CODE"=\'01\' AND "BOOK_NAME"=$2',
      tenantId,
      key.BOOK_NAME,
    );
    await sql(
      'UPDATE "COL_MAST" SET "COL_NEW_NAME"=NULL WHERE tenant_id=$1 AND "CO_CODE"=\'01\' AND "BOOK_NAME"=$2',
      tenantId,
      key.BOOK_NAME,
    );
    const restored = await fine();
    expect(restored.COL_NEW_NAME).toBe(initial.COL_NEW_NAME);
    expect(restored._columnVersion).not.toBe(initial._columnVersion);
    const before = await snapshot();
    await expect(
      updateColumnSetting(runtime, scope, { ...key, version: initial._columnVersion, YES_NO: 'N' }),
    ).rejects.toMatchObject({ statusCode: 409, code: 'column-setting-version-conflict' });
    await expect(
      deleteColumnSetting(runtime, scope, { ...key, version: initial._columnVersion }),
    ).rejects.toMatchObject({ statusCode: 409, code: 'column-setting-version-conflict' });
    expect(await snapshot()).toEqual(before);
    await deleteColumnSetting(runtime, scope, { ...key, version: restored._columnVersion });
    await createColumnSetting(runtime, scope, {
      ...key,
      COL_NEW_NAME: null,
      COL_RPT: '',
      YES_NO: 'Y',
    });
    expect((await fine()).row_id).not.toBe(initial.row_id);
    await expect(
      deleteColumnSetting(runtime, scope, { ...key, version: restored._columnVersion }),
    ).rejects.toMatchObject({ statusCode: 409 });
  });

  it('serializes actual concurrent same-key creates with one winner and no duplicated physical row', async () => {
    const source = { BOOK_NAME: 'RACE FAMILY', COL_NAME: 'Same original', COL_NEW_NAME: 'Winner' };
    const outcomes = await Promise.allSettled([
      createColumnSetting(runtime, scope, source),
      createColumnSetting(runtime, scope, source),
    ]);
    expect(outcomes.filter((outcome) => outcome.status === 'fulfilled')).toHaveLength(1);
    const rejected = outcomes.find((outcome) => outcome.status === 'rejected');
    expect(rejected?.status === 'rejected' ? rejected.reason : null).toMatchObject({
      statusCode: 409,
      code: 'duplicate-key',
    });
    expect(await list({ family: source.BOOK_NAME })).toHaveLength(1);
  });

  it('binds row versions to tenant and original family and never accepts a sibling version', async () => {
    const original = await fine();
    const sibling = (await list({ family: 'SALES' }))[0]!;
    await expect(
      updateColumnSetting(runtime, scope, { ...key, version: sibling._columnVersion, YES_NO: 'N' }),
    ).rejects.toMatchObject({ statusCode: 409 });
    await expect(
      updateColumnSetting(
        runtime,
        { ...scope, tenantId: otherTenant },
        { ...key, version: original._columnVersion, YES_NO: 'N' },
      ),
    ).rejects.toMatchObject({ statusCode: 409 });
    expect((await fine()).YES_NO).toBe('Y');
  });

  it('keeps an empty collection read-only and versions later insertion without claiming deleted history', async () => {
    expect(await list({ family: 'ABSENT FAMILY' })).toEqual([]);
    const before = (await fine())._columnCollectionVersion;
    await createColumnSetting(runtime, scope, {
      BOOK_NAME: 'ABSENT FAMILY',
      COL_NAME: 'Future row',
    });
    expect((await fine())._columnCollectionVersion).not.toBe(before);
  });

  it('paginates beyond100 rows deterministically and invalidates the collection when an off-page row changes', async () => {
    await sql(
      'INSERT INTO "COL_MAST"(tenant_id,"CO_CODE","BOOK_NAME","COL_NAME","COL_NEW_NAME","YES_NO","COL_RPT") SELECT $1,\'01\',\'BULK FAMILY\',\'Field\'||lpad(n::text,3,\'0\'),\'Caption\'||n::text,\'Y\',\'N\' FROM generate_series(1,125)n',
      tenantId,
    );
    const first = await list({ family: 'BULK FAMILY', offset: '0', limit: '100' });
    const next = await list({ family: 'BULK FAMILY', offset: '100', limit: '100' });
    expect(first).toHaveLength(100);
    expect(next).toHaveLength(25);
    expect(first[0]!.COL_NAME).toBe('Field001');
    expect(next[0]!.COL_NAME).toBe('Field101');
    expect(next[24]!.COL_NAME).toBe('Field125');
    expect(first[0]!._columnTotal).toBe(125);
    expect(first[0]!._columnCollectionVersion).toBe(next[0]!._columnCollectionVersion);
    expect(new Set([...first, ...next].map((row) => row.row_id)).size).toBe(125);
    const token = first[0]!._columnCollectionVersion;
    await updateColumnSetting(runtime, scope, {
      BOOK_NAME: 'BULK FAMILY',
      COL_NAME: 'Field125',
      version: next[24]!._columnVersion,
      COL_NEW_NAME: 'Changed off page',
    });
    const refreshed = await list({ family: 'BULK FAMILY', limit: 100 });
    expect(refreshed[0]!._columnVersion).toBe(first[0]!._columnVersion);
    expect(refreshed[0]!._columnCollectionVersion).not.toBe(token);
  });

  it('uses exact family filters and literal percent/underscore/backslash search characters', async () => {
    await column({ BOOK_NAME: 'LITERAL FAMILY', COL_NAME: 'Literal 50%_\\Gold', COL_NEW_NAME: '' });
    await column({ BOOK_NAME: 'LITERAL FAMILY', COL_NAME: 'Literal 50abGold', COL_NEW_NAME: '' });
    expect((await list({ family: 'SALES' })).every((row) => row.BOOK_NAME === 'SALES')).toBe(true);
    const found = await list({ family: 'LITERAL FAMILY', search: '%_\\' });
    expect(found).toHaveLength(1);
    expect(found[0]!.COL_NAME).toBe('Literal 50%_\\Gold');
  });

  it('keeps other company/tenant rows outside collection revisions', async () => {
    const initial = await fine();
    await sql(
      'UPDATE "COL_MAST" SET "COL_NEW_NAME"=\'Other only\' WHERE tenant_id=$1 OR "CO_CODE"=\'02\' AND tenant_id=$2',
      otherTenant,
      tenantId,
    );
    const unchanged = await fine();
    expect(unchanged._columnVersion).toBe(initial._columnVersion);
    expect(unchanged._columnCollectionVersion).toBe(initial._columnCollectionVersion);
  });

  it('delivers the updated Fine visibility to the source-derived configuration without changing saved returns', async () => {
    const target = { ...scope, coYear: '2024-2025', coBook: 'R81' };
    // Reconcile only the seeded NULL caption; the initial config correctly contains it.
    let current = await fine();
    await updateColumnSetting(runtime, scope, {
      ...key,
      version: current._columnVersion,
      COL_NEW_NAME: 'Return fine',
    });
    const baseline = await getSaleReturnIncomingConfiguration(runtime, target);
    const collateral = await snapshot(true);
    current = await fine();
    await updateColumnSetting(runtime, scope, {
      ...key,
      version: current._columnVersion,
      YES_NO: 'N',
    });
    const hidden = await getSaleReturnIncomingConfiguration(runtime, target);
    expect(baseline.policy?.fineColumnWidth).toBe(1000);
    expect(hidden.policy?.fineColumnWidth).toBe(0);
    expect(hidden.version).not.toBe(baseline.version);
    expect(hidden.capabilities.canSaveNumeric).toBe(false);
    expect(await snapshot(true)).toEqual(collateral);
  });

  it('publishes exact metadata and current form capabilities, including the existing View→create rule', async () => {
    const response = await request('GET', path('/meta'), undefined, 'view');
    expect(response.statusCode, response.body).toBe(200);
    expect(response.headers['cache-control']).toBe('no-store');
    expect(response.json()).toMatchObject({
      table: 'COL_MAST',
      keyColumns: ['CO_CODE', 'BOOK_NAME', 'COL_NAME'],
      requiredColumns: ['CO_CODE', 'BOOK_NAME', 'COL_NAME'],
      capabilities: { canCreate: true, canUpdate: false, canDelete: false },
    });
    expect((await request('GET', path('/meta'))).json().capabilities).toEqual({
      canCreate: true,
      canUpdate: true,
      canDelete: true,
    });
    const before = await snapshot();
    const original = await fine();
    for (const method of ['PUT', 'DELETE'] as const) {
      const body = {
        ...key,
        version: original._columnVersion,
        ...(method === 'PUT' ? { YES_NO: 'N' } : {}),
      };
      expect((await request(method, path(), body, 'view')).statusCode).toBe(403);
    }
    expect(await snapshot()).toEqual(before);
    expect(
      (
        await request(
          'POST',
          path(),
          { BOOK_NAME: 'VIEW CREATE', COL_NAME: 'Allowed source rule' },
          'view',
        )
      ).statusCode,
    ).toBe(201);
  });

  it('requires fresh owning-form rights, not another master right or a stale signed-in capability', async () => {
    expect((await request('GET', path(), undefined, 'anonymous')).statusCode).toBe(401);
    for (const suffix of ['', '/meta'])
      expect((await request('GET', path(suffix), undefined, 'unrelated')).statusCode).toBe(403);
    const original = await fine();
    await sql(
      'UPDATE "USER_SET" SET "FRM_EDIT"=\'N\',"FRM_DELETE"=\'N\' WHERE tenant_id=$1 AND "USER_NAME"=\'writer\'',
      tenantId,
    );
    expect((await request('GET', path('/meta'))).json().capabilities).toEqual({
      canCreate: true,
      canUpdate: false,
      canDelete: false,
    });
    expect(
      (await request('PUT', path(), { ...key, version: original._columnVersion, YES_NO: 'N' }))
        .statusCode,
    ).toBe(403);
    await sql(
      'UPDATE "USER_SET" SET "FRM_VIEW"=\'N\' WHERE tenant_id=$1 AND "USER_NAME"=\'writer\'',
      tenantId,
    );
    expect((await request('GET', path())).statusCode).toBe(403);
    expect(
      (await request('POST', path('/import'), { rows: [{ BOOK_NAME: 'DENIED', COL_NAME: 'Row' }] }))
        .statusCode,
    ).toBe(403);
  });

  it('runs authenticated create/read/update/delete without collateral same-name changes', async () => {
    const siblingBefore = (await httpRows({ family: 'SALES' }))[0]!;
    expect(
      (
        await request('POST', path(), {
          BOOK_NAME: 'HTTP FAMILY',
          COL_NAME: 'Fine',
          COL_NEW_NAME: 'HTTP original',
          COL_RPT: 'N',
          YES_NO: 'Y',
        })
      ).statusCode,
    ).toBe(201);
    const saved = (await httpRows({ family: 'HTTP FAMILY' }))[0]!;
    const changed = await request('PUT', path(), {
      BOOK_NAME: saved.BOOK_NAME,
      COL_NAME: saved.COL_NAME,
      version: saved._columnVersion,
      COL_NEW_NAME: '',
    });
    expect(changed.statusCode, changed.body).toBe(200);
    const updated = (await httpRows({ family: 'HTTP FAMILY' }))[0]!;
    expect(updated).toMatchObject({ COL_NEW_NAME: '', COL_RPT: 'N', YES_NO: 'Y' });
    expect(
      (
        await request('DELETE', path(), {
          BOOK_NAME: updated.BOOK_NAME,
          COL_NAME: updated.COL_NAME,
          version: updated._columnVersion,
        })
      ).statusCode,
    ).toBe(200);
    expect(await httpRows({ family: 'HTTP FAMILY' })).toEqual([]);
    const siblingAfter = (await httpRows({ family: 'SALES' }))[0]!;
    expect(siblingAfter._columnVersion).toBe(siblingBefore._columnVersion);
    expect(siblingAfter.COL_NEW_NAME).toBe(siblingBefore.COL_NEW_NAME);
  });

  it('rejects missing family/version, foreign scope and stale HTTP writes without any business changes', async () => {
    const original = await fine();
    const before = await snapshot();
    const bodies = [
      { COL_NAME: 'Fine', version: original._columnVersion, YES_NO: 'N' },
      { ...key, YES_NO: 'N' },
      { ...key, version: 'old', YES_NO: 'N' },
      { ...key, version: original._columnVersion, row_id: original.row_id, YES_NO: 'N' },
    ];
    for (const body of bodies) expect((await request('PUT', path(), body)).statusCode).toBe(400);
    expect((await request('DELETE', path(), key)).statusCode).toBe(400);
    expect((await request('POST', path(), { ...key, CO_CODE: '02' })).statusCode).toBe(409);
    for (const query of [{ coCode: '02' }, { lcCode: '02' }, { coYear: '2023-2024' }])
      expect((await request('GET', path('', query))).statusCode).toBe(409);
    expect(await snapshot()).toEqual(before);
    await updateColumnSetting(runtime, scope, {
      ...key,
      version: original._columnVersion,
      YES_NO: 'N',
    });
    const freshSnapshot = await snapshot();
    const conflict = await request('PUT', path(), {
      ...key,
      version: original._columnVersion,
      COL_NEW_NAME: 'Stale',
    });
    expect(conflict.statusCode, conflict.body).toBe(409);
    expect(conflict.json().error).toBe('column-setting-version-conflict');
    expect(await snapshot()).toEqual(freshSnapshot);
  });

  it('preserves exact tenant isolation in authenticated reads and versions', async () => {
    const own = (await httpRows({ family: key.BOOK_NAME }))[0]!;
    const other = (await httpRows({ family: key.BOOK_NAME }, 'other'))[0]!;
    expect(other.COL_NEW_NAME).toBe('Other tenant sentinel');
    expect(other._columnVersion).not.toBe(own._columnVersion);
    const conflict = await request(
      'DELETE',
      path(),
      { ...key, version: own._columnVersion },
      'other',
    );
    expect(conflict.statusCode).toBe(409);
    expect((await httpRows({ family: key.BOOK_NAME }, 'other'))[0]!.COL_NEW_NAME).toBe(
      'Other tenant sentinel',
    );
  });

  it('imports through the exact create path and reports per-row failures without overwriting duplicates', async () => {
    const before = await fine();
    const response = await request('POST', path('/import'), {
      rows: [
        { ...key, COL_NEW_NAME: 'Must not overwrite' },
        { BOOK_NAME: 'IMPORT A', COL_NAME: 'Fine', COL_NEW_NAME: 'A' },
        { COL_NAME: 'Missing family' },
        { BOOK_NAME: 'IMPORT B', COL_NAME: 'Fine', COL_NEW_NAME: null, YES_NO: null },
      ],
    });
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json()).toMatchObject({
      created: 2,
      failed: 2,
      errors: [{ row: 1 }, { row: 3 }],
    });
    expect((await fine())._columnVersion).toBe(before._columnVersion);
    expect((await httpRows({ family: 'IMPORT B' }))[0]).toMatchObject({
      COL_NEW_NAME: null,
      YES_NO: null,
      COL_RPT: null,
    });
    expect((await request('POST', path('/import'), { rows: {} })).statusCode).toBe(400);
  });

  it('shares the same absent-key lock between concurrent HTTP create and CSV import', async () => {
    const body = {
      BOOK_NAME: 'CROSS ADAPTER',
      COL_NAME: 'Concurrent',
      COL_NEW_NAME: 'One saved row',
    };
    const [created, imported] = await Promise.all([
      request('POST', path(), body),
      request('POST', path('/import'), { rows: [body] }),
    ]);
    expect([201, 409]).toContain(created.statusCode);
    expect(imported.statusCode, imported.body).toBe(200);
    expect(Number(created.statusCode === 201) + imported.json().created).toBe(1);
    expect(await httpRows({ family: 'CROSS ADAPTER' })).toHaveLength(1);
  });

  it('rejects malformed HTTP pagination/filter values while supporting bounded scalar page requests', async () => {
    for (const query of [
      { offset: '-1' },
      { offset: '1.5' },
      { limit: '0' },
      { limit: '501' },
      { offset: '1000001' },
      { search: 'x'.repeat(256) },
      { search: 'bad\nfilter' },
    ])
      expect((await request('GET', path('', query))).statusCode).toBe(400);
    expect((await request('GET', path() + '&limit=1&limit=2')).statusCode).toBe(400);
    expect((await request('GET', path() + '&family=SALES&family=SALES%20RETURNE')).statusCode).toBe(
      400,
    );
    const rows = await httpRows({ offset: '1', limit: '1' });
    expect(rows).toHaveLength(1);
    expect(rows[0]!._columnTotal).toBe(2);
  });
});
