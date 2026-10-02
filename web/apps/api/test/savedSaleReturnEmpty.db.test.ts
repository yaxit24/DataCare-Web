import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import {
  getSavedSaleReturnIncoming,
  updateSavedSaleReturnMetadata,
} from '../src/modules/sales/savedSaleReturn.js';
import {
  getSaleReturnIncomingReplayState,
  previewSaleReturnIncomingReplay,
} from '../src/modules/sales/saleReturnIncomingReplay.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('empty saved Return header inspection preserves metadata and replay refusal', () => {
  const tenantId = 'r9-empty-return';
  const otherTenant = 'r9-empty-other';
  const selected = { coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R93' };
  const scope = { tenantId, ...selected };
  const doc = {
    tenant_id: tenantId,
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2024-2025',
    CO_BOOK: 'R93',
    VCH_NO: '00004',
  };
  const businessTables = [
    'SL_DATA',
    'SL_DETL_RTN',
    'SL_DETL',
    'SL_IDTL',
    'BAR_DATA',
    'BAR_DETL',
    'BAR_IDTL',
    'MAIN_STOCK',
    'AC_DATA',
    'TAX_DATA',
    'BILL_OS_DATA',
    'ROJ_MEL_DATA',
    'DM_DATA',
    'REMARK_DATA',
    'TEMP_BOOK_DATA',
    'SRNO_MAST',
    'TAG_SET',
    'CO_SET',
    'CO_SET_NEW',
    'COL_MAST',
    'BOOK_DATA',
    'YEAR_MAST',
    'ITEM_MAST',
    'EMP_MAST',
  ];
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const sql = (query: string, ...values: unknown[]) => owner.$executeRawUnsafe(query, ...values);
  const insert = async (table: string, values: Record<string, unknown>) => {
    const columns = Object.keys(values)
      .map((key) => `"${key}"`)
      .join(',');
    await sql(
      `INSERT INTO "${table}" (${columns}) SELECT ${columns} FROM jsonb_populate_record(NULL::"${table}",$1::jsonb)`,
      JSON.stringify(values),
    );
  };
  const cleanup = async (all = false) => {
    for (const table of all
      ? [
          'audit_log',
          'auth_session',
          ...businessTables,
          'USER_SET',
          'LOGIN_MAST',
          'LOCT_MAST',
          'CO_MAST',
        ]
      : businessTables)
      await sql(`DELETE FROM "${table}" WHERE tenant_id IN($1,$2)`, tenantId, otherTenant);
  };
  const snapshot = async () => {
    const result: Record<string, unknown> = {};
    for (const table of businessTables)
      result[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text raw,t.xmin::text revision,t.ctid::text locator FROM "${table}" t WHERE tenant_id IN($1,$2) ORDER BY to_jsonb(t)::text`,
        tenantId,
        otherTenant,
      );
    return result;
  };
  const url = (action: string, book = 'R93', voucher = '00004') =>
    `/sales-returns/${voucher}/${action}?${new URLSearchParams({ ...selected, coBook: book })}`;
  const request = (
    method: 'GET' | 'PUT' | 'POST',
    action: string,
    payload?: unknown,
    role = 'edit',
  ) =>
    app.inject({
      method,
      url: url(action),
      headers: { cookie: cookies[role]! },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });
  const saved = () => getSavedSaleReturnIncoming(runtime, scope, '00004');
  const replay = () => getSaleReturnIncomingReplayState(runtime, scope, '00004');
  const guessed = (version: string) => ({
    replayVersion: version,
    rowIdentity: 'a'.repeat(64),
    events: [],
  });
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await cleanup(true);
    const password = 'Empty-Return-Read!2026';
    const hashed = await hashPassword(password);
    await insert('CO_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      CO_NAME: 'Empty Return fixture',
      LC_CODE: '01',
    });
    await insert('LOCT_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      LC_CODE: '01',
      LC_NAME: 'Main',
    });
    await insert('YEAR_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      CO_YEAR: selected.coYear,
      OP_DATE: '2024-04-01',
      CL_DATE: '2025-03-31',
    });
    for (const role of ['edit', 'view']) {
      await insert('LOGIN_MAST', {
        tenant_id: tenantId,
        CO_CODE: '01',
        LOGIN_NAME: role,
        LOGIN_PWD: hashed,
        LOGIN_CATG: 'USER',
        USER_UPDATE: role === 'edit' ? 'Y' : 'N',
        USER_DELETE: 'N',
        USER_PRINT: 'N',
        PASSWORD_RESET_REQUIRED: 'N',
      });
      await insert('USER_SET', {
        tenant_id: tenantId,
        CO_CODE: '01',
        LC_CODE: '01',
        USER_NAME: role,
        MAIN_MENU: 'Sales',
        SUB_MENU: 'Sales Return',
        FRM_VIEW: 'Y',
        FRM_EDIT: role === 'edit' ? 'Y' : 'N',
        FRM_DELETE: 'N',
        FRM_PRINT: 'N',
      });
    }
    app = await buildApp({
      prisma: runtime,
      secret: 'empty-return-test-secret-at-least-thirty-two-characters',
      secureCookies: false,
    });
    for (const role of ['edit', 'view']) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: selected.coYear, loginName: role, password },
      });
      expect(response.statusCode, response.body).toBe(200);
      const setCookie = response.headers['set-cookie'];
      cookies[role] = (Array.isArray(setCookie) ? setCookie : [setCookie ?? ''])
        .map((value) => value.split(';', 1)[0])
        .join('; ');
    }
  });
  beforeEach(async () => {
    await cleanup();
    for (const tenant of [tenantId, otherTenant]) {
      await insert('CO_SET', {
        tenant_id: tenant,
        CO_CODE: '01',
        LOCK_DATE: null,
        EMP_CODE_MANDATORY: 'N',
        SL_AMT_TYPE: 'N',
        LBR_ROF: 2,
        LBR_RATE_GEN: 'N',
        ALL_ROF_REMOVE: 'N',
        LBR_TYPE: 'N',
      });
      await insert('CO_SET_NEW', { tenant_id: tenant, CO_CODE: '01', LBR_WITH_GHT: 'N' });
      await insert('YEAR_MAST', {
        tenant_id: tenant,
        CO_CODE: '01',
        CO_YEAR: selected.coYear,
        OP_DATE: '2024-04-01',
        CL_DATE: '2025-03-31',
      });
      await insert('ITEM_MAST', {
        tenant_id: tenant,
        CO_CODE: '01',
        IT_CODE: 'GOLD',
        IT_NAME: 'Saved gold',
        IT_TYPE: 'G',
        RATE_TYPE: 'N',
      });
      await insert('EMP_MAST', {
        tenant_id: tenant,
        CO_CODE: '01',
        EMP_CODE: 'E01',
        EMP_NAME: 'Eligible employee',
      });
      for (const book of ['R93', 'R94']) {
        await insert('BOOK_DATA', {
          tenant_id: tenant,
          CO_CODE: '01',
          LC_CODE: '01',
          CO_BOOK: book,
          MAIN_BOOK: 'SALES RETURNE',
          BOOK_NAME: 'Configured Return',
          BOOK_INOUT: 'I',
          BOOK_TBL_NAME: 'SL_DATA',
          CUR_USE: 'Y',
        });
        await insert('SL_DATA', {
          ...doc,
          tenant_id: tenant,
          CO_BOOK: book,
          VCH_DATE: '2024-07-10',
          VCH_TIME: '2024-07-10T12:34:56.123456',
          USER_UPDATE: 'Y',
          EMP_CODE: '',
          VCH_DESC: null,
          NET_AMT: '9999999999999999.99',
        });
        if (book === 'R94')
          await insert('SL_DETL_RTN', {
            ...doc,
            tenant_id: tenant,
            CO_BOOK: book,
            SR_NO: 17,
            OLD_SRNO: 31,
            ENTRY_TYPE: 'P',
            INOUT_TYPE: 'I',
            IT_CODE: 'GOLD',
            TAG_NO: 'N',
            APR_ISU: 'N',
            EMP_ISU: 'N',
            HM_ID: 'UNCHANGED',
          });
      }
    }
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) {
      await cleanup(true);
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('reads an exact empty header with no domain edit authority and unchanged nonempty sibling version', async () => {
    const before = await snapshot();
    const sibling = await getSavedSaleReturnIncoming(runtime, { ...scope, coBook: 'R94' }, '00004');
    const value = await saved();
    expect(value.lines).toEqual([]);
    expect(value.header.raw).toMatchObject({
      EMP_CODE: '',
      VCH_DESC: null,
      NET_AMT: '9999999999999999.99',
    });
    expect(value.header.raw.VCH_TIME).toContain('12:34:56.123456');
    expect(value.capabilities).toEqual({
      canUpdate: false,
      reason: 'The saved voucher has no incoming Return rows.',
    });
    expect(value.header.capabilities.employeeCode).toEqual({
      allowed: false,
      reason: 'The saved voucher has no incoming Return rows.',
    });
    expect(value.provenance.incomingLineCount).toBe(0);
    expect(
      (await getSavedSaleReturnIncoming(runtime, { ...scope, coBook: 'R94' }, '00004')).version,
    ).toBe(sibling.version);
    expect(await snapshot()).toEqual(before);
  });
  it('retains locked metadata refusal for a fresh valid employee patch and refuses a fabricated replay row', async () => {
    const current = await saved();
    const state = await replay();
    const before = await snapshot();
    expect(state.rows).toEqual([]);
    expect(state.capabilities).toEqual({ canPreview: false, canSaveNumeric: false });
    expect(state.documentVersion).toBe(current.version);
    expect(state.configurationVersion).toBe(state.configuration.version);
    await expect(
      updateSavedSaleReturnMetadata(runtime, scope, '00004', {
        version: current.version,
        header: { employeeCode: 'E01' },
      }),
    ).rejects.toMatchObject({
      statusCode: 422,
      code: 'unsupported-state',
      message: 'The saved voucher has no incoming Return rows.',
    });
    await expect(
      previewSaleReturnIncomingReplay(runtime, scope, '00004', guessed(state.replayVersion)),
    ).rejects.toMatchObject({ statusCode: 409, code: 'identity-conflict' });
    expect(await snapshot()).toEqual(before);
  });
  it('serves both actual authenticated GETs with empty rows, no-store and no numeric or metadata domain authority', async () => {
    const before = await snapshot();
    for (const role of ['edit', 'view']) {
      const response = await request('GET', 'incoming', undefined, role);
      expect(response.statusCode, response.body).toBe(200);
      expect(response.headers['cache-control']).toBe('no-store');
      expect(response.json()).toMatchObject({
        lines: [],
        capabilities: { canUpdate: false },
        header: { capabilities: { employeeCode: { allowed: false } } },
      });
      const state = await request('GET', 'incoming-replay-state', undefined, role);
      expect(state.statusCode, state.body).toBe(200);
      expect(state.headers['cache-control']).toBe('no-store');
      expect(state.json()).toMatchObject({
        rows: [],
        documentVersion: response.json().version,
        capabilities: { canPreview: false, canSaveNumeric: false },
      });
    }
    expect(await snapshot()).toEqual(before);
  });
  it('refuses actual employee PUT with fresh version despite Edit rights and rejects empty replay POST without writes', async () => {
    const current = await request('GET', 'incoming');
    const state = await request('GET', 'incoming-replay-state');
    const before = await snapshot();
    expect(current.statusCode, current.body).toBe(200);
    expect(current.json().canUpdate).toBe(true); // Owning permission does not override domain eligibility.
    const update = await request('PUT', 'incoming-metadata', {
      version: current.json().version,
      header: { employeeCode: 'E01' },
    });
    expect(update.statusCode, update.body).toBe(422);
    expect(update.json()).toMatchObject({
      error: 'unsupported-state',
      message: 'The saved voucher has no incoming Return rows.',
    });
    const preview = await request('POST', 'incoming-replay', guessed(state.json().replayVersion));
    expect(preview.statusCode, preview.body).toBe(409);
    expect(preview.json().error).toBe('identity-conflict');
    expect(await snapshot()).toEqual(before);
  });
  it('keeps existing related records visible without inventing an incoming row and still refuses metadata mutation', async () => {
    await insert('SL_IDTL', {
      ...doc,
      SR_NO: 31,
      ISR_NO: 9,
      IT_CODE: 'STONE',
      IT_PCS: '2',
      IT_GWT: '0.123',
    });
    const before = await snapshot();
    const current = await saved();
    expect(current.lines).toEqual([]);
    expect(current.related.outgoingComponents).toHaveLength(1);
    expect(current.related.outgoingComponents[0]).toMatchObject({
      SR_NO: '31',
      ISR_NO: '9',
      IT_CODE: 'STONE',
      IT_GWT: '0.123',
    });
    expect((await replay()).capabilities.canPreview).toBe(false);
    await expect(
      updateSavedSaleReturnMetadata(runtime, scope, '00004', {
        version: current.version,
        header: { employeeCode: 'E01' },
      }),
    ).rejects.toMatchObject({ statusCode: 422 });
    expect(await snapshot()).toEqual(before);
  });
  it('invalidates the empty observation after real incoming admission and retains missing-header404', async () => {
    const state = await replay();
    await insert('SL_DETL_RTN', {
      ...doc,
      SR_NO: 17,
      OLD_SRNO: 31,
      ENTRY_TYPE: 'P',
      INOUT_TYPE: 'I',
      IT_CODE: 'GOLD',
      TAG_NO: 'N',
    });
    const before = await snapshot();
    await expect(
      previewSaleReturnIncomingReplay(runtime, scope, '00004', guessed(state.replayVersion)),
    ).rejects.toMatchObject({ statusCode: 409, code: 'version-conflict' });
    expect((await saved()).lines).toHaveLength(1);
    await expect(getSavedSaleReturnIncoming(runtime, scope, '99999')).rejects.toMatchObject({
      statusCode: 404,
      code: 'not-found',
    });
    await expect(getSaleReturnIncomingReplayState(runtime, scope, '99999')).rejects.toMatchObject({
      statusCode: 404,
      code: 'not-found',
    });
    expect(await snapshot()).toEqual(before);
  });
});
