import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'r9-return-replay-http';
const otherTenant = 'r9-return-replay-other';
const selected = { coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R91' };
type Role = 'view' | 'unrelated' | 'other';
const tables = [
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
  'SRNO_MAST',
  'TAG_SET',
  'TEMP_BOOK_DATA',
  'CO_SET',
  'CO_SET_NEW',
  'COL_MAST',
  'BOOK_DATA',
  'YEAR_MAST',
  'ITEM_MAST',
];
const numericalFields = [
  'ITM_PCS',
  'ITM_GWT',
  'ITM_OTH_WT',
  'ITM_NWT',
  'ITM_GHT_PRC',
  'ITM_GHT_WT',
  'ITM_TOUCH',
  'ITM_WEST_PRC',
  'ITM_FINE',
  'ITM_RATE',
  'ITM_AMT',
  'LBR_PRC',
  'LBR_RATE',
  'LBR_AMT',
  'DISC_PRC',
  'DISC_AMT',
  'OTH_AMT',
  'ITM_MRP',
  'TAG_LBR_PRC',
  'TAG_LBR_RATE',
  'TAG_LBR_AMT',
  'TAG_OTH_AMT',
  'TAG_COST',
  'TAG_MRP',
  'TOT_AMT',
  'TAX_PRC',
  'NET_AMT',
  'HM_ID_WT',
  'HM_ID2_WT',
  'HM_ID3_WT',
  'HM_ID4_WT',
];

(enabled ? describe : describe.skip)('saved Incoming Return journal HTTP authority', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Partial<Record<Role, string>> = {};
  const sql = (text: string, ...values: unknown[]) => owner.$executeRawUnsafe(text, ...values);
  const insert = (table: string, values: Record<string, unknown>) => {
    const columns = Object.keys(values)
      .map((key) => `"${key}"`)
      .join(',');
    return sql(
      `INSERT INTO "${table}" (${columns}) SELECT ${columns} FROM jsonb_populate_record(NULL::"${table}",$1::jsonb)`,
      JSON.stringify(values),
    );
  };
  const url = (
    action = 'incoming-replay-state',
    voucher = '00001',
    scope: Record<string, string> = selected,
  ) => `/sales-returns/${voucher}/${action}?${new URLSearchParams(scope)}`;
  const call = (
    method: 'GET' | 'POST',
    endpoint: string,
    role: Role | 'anonymous' = 'view',
    payload?: unknown,
  ) =>
    app.inject({
      method,
      url: endpoint,
      headers: role === 'anonymous' ? {} : { cookie: cookies[role] ?? '' },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });
  const state = async (role: Role = 'view', scope: Record<string, string> = selected) => {
    const response = await call('GET', url('incoming-replay-state', '00001', scope), role);
    expect(response.statusCode, response.body).toBe(200);
    expect(response.headers['cache-control']).toBe('no-store');
    return response.json();
  };
  const journal = (dto: any, events: Array<{ fieldId: string; editorText: string }> = []) => ({
    replayVersion: dto.replayVersion,
    rowIdentity: dto.rows[0].rowIdentity,
    events,
  });
  const preview = (
    payload: unknown,
    role: Role = 'view',
    scope: Record<string, string> = selected,
  ) => call('POST', url('incoming-replay', '00001', scope), role, payload);
  async function snapshot() {
    const result: Record<string, unknown> = {};
    for (const table of tables)
      result[table] = await owner.$queryRawUnsafe(
        `SELECT (SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(t)) e) raw,
          t.xmin::text AS generation,t.ctid::text AS tuple
         FROM "${table}" t WHERE tenant_id IN ($1,$2) ORDER BY to_jsonb(t)::text`,
        tenantId,
        otherTenant,
      );
    return result;
  }
  async function clean(all = false) {
    for (const table of all
      ? ['audit_log', 'auth_session', ...tables, 'USER_SET', 'LOGIN_MAST', 'LOCT_MAST', 'CO_MAST']
      : tables)
      await sql(`DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`, tenantId, otherTenant);
  }
  beforeAll(async () => {
    for (const value of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!value || new URL(value).port !== '55433')
        throw new Error('Isolated parity database 55433 is required.');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await clean(true);
    const password = 'Return-Replay-Route!2026';
    const hashed = await hashPassword(password);
    for (const tenant of [tenantId, otherTenant]) {
      await insert('CO_MAST', {
        tenant_id: tenant,
        CO_CODE: '01',
        CO_NAME: 'Replay fixture',
        LC_CODE: '01',
      });
      await insert('LOCT_MAST', {
        tenant_id: tenant,
        CO_CODE: '01',
        LC_CODE: '01',
        LC_NAME: 'Main',
      });
      await insert('YEAR_MAST', {
        tenant_id: tenant,
        CO_CODE: '01',
        CO_YEAR: selected.coYear,
        OP_DATE: '2024-04-01',
        CL_DATE: '2025-03-31',
      });
      for (const [name, form] of [
        ['view', 'Sales Return'],
        ['unrelated', 'Sales'],
      ] as const) {
        await insert('LOGIN_MAST', {
          tenant_id: tenant,
          CO_CODE: '01',
          LOGIN_NAME: name,
          LOGIN_PWD: hashed,
          LOGIN_CATG: 'USER',
          USER_UPDATE: 'N',
          USER_DELETE: 'N',
          USER_PRINT: 'N',
          PASSWORD_RESET_REQUIRED: 'N',
        });
        await insert('USER_SET', {
          tenant_id: tenant,
          CO_CODE: '01',
          LC_CODE: '01',
          USER_NAME: name,
          MAIN_MENU: 'Sales',
          SUB_MENU: form,
          FRM_VIEW: 'Y',
          FRM_EDIT: 'N',
          FRM_DELETE: 'N',
          FRM_PRINT: 'N',
        });
      }
    }
    app = await buildApp({
      prisma: runtime,
      secret: 'return-replay-test-session-secret-over-thirty-two-characters',
      secureCookies: false,
    });
    for (const role of ['view', 'unrelated', 'other'] as const) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': role === 'other' ? otherTenant : tenantId },
        payload: {
          coCode: '01',
          lcCode: '01',
          coYear: selected.coYear,
          loginName: role === 'other' ? 'view' : role,
          password,
        },
      });
      expect(response.statusCode, response.body).toBe(200);
      const values = response.headers['set-cookie'];
      cookies[role] = (Array.isArray(values) ? values : [values ?? ''])
        .map((value) => value.split(';', 1)[0])
        .join('; ');
    }
  });
  beforeEach(async () => {
    await clean();
    await sql(
      `UPDATE "USER_SET" SET "FRM_VIEW"='Y' WHERE tenant_id=$1 AND "USER_NAME"='view'`,
      tenantId,
    );
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
        IT_NAME: 'Original master name',
        RATE_TYPE: 'N',
        IT_TYPE: 'G',
      });
      for (const coBook of ['R91', 'R92']) {
        await insert('BOOK_DATA', {
          tenant_id: tenant,
          CO_CODE: '01',
          LC_CODE: '01',
          CO_BOOK: coBook,
          MAIN_BOOK: 'SALES RETURNE',
          BOOK_NAME: 'Saved return',
          BOOK_SNAME: 'SRTN',
          BOOK_INOUT: 'I',
          CUR_USE: 'Y',
          BOOK_TBL_NAME: 'SL_DATA',
        });
        const key = {
          tenant_id: tenant,
          CO_CODE: '01',
          LC_CODE: '01',
          CO_YEAR: selected.coYear,
          CO_BOOK: coBook,
          VCH_NO: '00001',
        };
        await insert('SL_DATA', {
          ...key,
          VCH_DATE: '2024-07-10',
          VCH_TIME: '2024-07-10T12:34:56.123456',
          ENTRY_TIME: '2024-07-10',
          USER_UPDATE: 'Y',
          EMP_CODE: '',
          AC_CODE: 'PARTY',
          NET_AMT: '1000.00',
          TOT_AMT: '1000.00',
          RTN_NET_AMT: '1000.00',
          RTN_TOT_AMT: '1000.00',
        });
        await insert('SL_DETL_RTN', {
          ...Object.fromEntries(numericalFields.map((name) => [name, '0'])),
          ...key,
          SR_NO: 17,
          OLD_SRNO: 31,
          VCH_SRNO: 500001,
          TAG_SRNO: 123,
          VCH_DATE: '2024-07-10',
          VCH_TIME: '2024-07-10T12:34:56.123456',
          ENTRY_TYPE: 'P',
          INOUT_TYPE: 'I',
          IT_CODE: 'GOLD',
          TAG_NO: 'N',
          ITM_REMARK: '',
          RATE_TYPE: 'N',
          IT_TYPE: 'G',
          PR_CODE: '01',
          LBR_TYPE: 'N',
          LBR_CODE: '',
          TAG_LBR_CODE: '',
          APR_ISU: 'N',
          EMP_ISU: 'N',
          ITM_PCS: '1',
          ITM_GWT: '10',
          ITM_NWT: '10',
          ITM_TOUCH: '100',
          ITM_FINE: '10',
          ITM_RATE: '100',
          ITM_AMT: '1000',
          TOT_AMT: '1000',
          NET_AMT: '1000',
          HM_ID: null,
          ITM_STYLE: '',
          ITM_SIZE: '',
          TBL_CODE: '',
          DESIGN_NO: '',
          KR_NAME: '',
          TAG_TYPE: '',
          HM_ID2: '',
          HM_ID3: '',
          HM_ID4: '',
          DESIGN_IMG_ID: '',
          DATA_TYPE: '',
        });
      }
    }
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await clean(true);
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('allows owning View to load and simulate while preserving raw, caches and every business row', async () => {
    const before = await snapshot();
    const dto = await state();
    expect(dto.scope).toEqual(selected);
    expect(dto.capabilities).toMatchObject({ canPreview: true, canSaveNumeric: false });
    expect(dto.rows[0]).toMatchObject({
      identity: { srNo: '17', oldSrNo: '31' },
      raw: { HM_ID: null },
    });
    expect(dto.rows[0].visible['0']).toBe('1');
    expect(dto.rows[0].visible['3']).toBe('Original master name');
    expect(dto.rows[0].visible['10']).toBe('10.000');
    expect(dto.rows[0].caches['45']).toBe('10.000');
    expect(dto.replayVersion).toMatch(/^[a-f0-9]{64}$/);
    expect(dto.rows[0].rowIdentity).toMatch(/^[a-f0-9]{64}$/);
    expect(JSON.stringify(dto)).not.toContain(tenantId);
    const response = await preview(
      journal(dto, [{ fieldId: 'x13.primary-incoming.c27', editorText: '5' }]),
    );
    expect(response.statusCode, response.body).toBe(200);
    expect(response.headers['cache-control']).toBe('no-store');
    expect(response.json().capabilities.canSaveNumeric).toBe(false);
    expect(response.json().baseline.visible['27']).toBe('0.00');
    expect(response.json().preview.visible['27']).toBe('5.00');
    expect(response.json().preview.visible['36']).toBe('1005.00');
    expect(response.json().preview.visible['38']).toBe('1005.00');
    expect(await snapshot()).toEqual(before);
  });
  it('returns the unchanged loaded baseline for an empty journal and retains repeated committed events', async () => {
    const dto = await state();
    const before = await snapshot();
    const empty = await preview(journal(dto));
    expect(empty.statusCode, empty.body).toBe(200);
    expect(empty.json().preview).toEqual(empty.json().baseline);
    expect(empty.json().preview.visible).toEqual(dto.rows[0].visible);
    expect(empty.json().preview.caches).toEqual(dto.rows[0].caches);
    expect(empty.json().events).toEqual([]);
    expect(empty.json().aggregateRequired).toBe(false);
    const event = { fieldId: 'x13.primary-incoming.c27', editorText: '5' };
    const repeated = await preview(journal(dto, [event, event]));
    expect(repeated.statusCode, repeated.body).toBe(200);
    expect(repeated.json().events).toEqual([
      { ...event, status: 'applied' },
      { ...event, status: 'applied' },
    ]);
    expect(repeated.json().aggregateRequired).toBe(true);
    expect(repeated.json().preview.visible['38']).toBe('1005.00');
    expect(await snapshot()).toEqual(before);
  });
  it('returns a recoverable failed event and transient valid prefix without committing any business row', async () => {
    const dto = await state();
    const before = await snapshot();
    const response = await preview(
      journal(dto, [
        { fieldId: 'x13.primary-incoming.c27', editorText: '5' },
        { fieldId: 'x13.primary-incoming.c19', editorText: 'NaN' },
      ]),
    );
    expect(response.statusCode, response.body).toBe(422);
    expect(response.json()).toMatchObject({
      error: 'calculation-refused',
      details: {
        eventIndex: 1,
        fieldId: 'x13.primary-incoming.c19',
        editorText: 'NaN',
        baseline: { visible: { '27': '0.00' } },
        preview: { visible: { '27': '5.00', '38': '1005.00' } },
      },
    });
    expect(await snapshot()).toEqual(before);
  });
  it('classifies POST as nonpersisting View and checks current owning rights on every request', async () => {
    const dto = await state();
    for (const role of ['unrelated', 'anonymous'] as const) {
      expect((await call('GET', url(), role)).statusCode).toBe(role === 'anonymous' ? 401 : 403);
      expect((await call('POST', url('incoming-replay'), role, journal(dto))).statusCode).toBe(
        role === 'anonymous' ? 401 : 403,
      );
    }
    await sql(
      `UPDATE "USER_SET" SET "FRM_VIEW"='N' WHERE tenant_id=$1 AND "USER_NAME"='view'`,
      tenantId,
    );
    expect((await preview(journal(dto))).statusCode).toBe(403);
  });
  it('requires explicit scope and rejects query overrides or another active business scope', async () => {
    const dto = await state();
    const before = await snapshot();
    for (const key of Object.keys(selected)) {
      const partial: Record<string, string> = { ...selected };
      delete partial[key];
      expect((await call('GET', url('incoming-replay-state', '00001', partial))).statusCode).toBe(
        400,
      );
    }
    for (const addition of ['&policy=N', '&width=1000', '&tenantId=foreign', '&coBook=R92'])
      expect((await call('GET', url() + addition)).statusCode).toBe(400);
    for (const scope of [
      { ...selected, coCode: '02' },
      { ...selected, lcCode: '02' },
      { ...selected, coYear: '2023-2024' },
    ])
      expect((await preview(journal(dto), 'view', scope)).statusCode).toBe(409);
    expect(await snapshot()).toEqual(before);
  });
  it('refuses noncanonical voucher keys without silently selecting a different saved document', async () => {
    for (const voucher of ['1', '000001', '100000', 'abc', '00001%20'])
      expect((await call('GET', url('incoming-replay-state', voucher))).statusCode).toBe(400);
    expect((await call('GET', url('incoming-replay-state', '00009'))).statusCode).toBe(404);
  });
  it('rejects caller policy, raw cells, comparison caches, source actions and malformed journals', async () => {
    const dto = await state();
    const good = journal(dto);
    const before = await snapshot();
    const invalid: unknown[] = [
      { ...good, policy: {} },
      { ...good, cells: {} },
      { ...good, caches: {} },
      { ...good, sourceRef: {} },
      { ...good, replayVersion: 'old' },
      { ...good, rowIdentity: 17 },
      { ...good, events: {} },
      { ...good, events: [{ fieldId: 'x13.primary-incoming.c27', editorText: '1', width: 1 }] },
      { ...good, events: [{ fieldId: 'x13.primary-incoming.c27', editorText: 1 }] },
      { ...good, events: [{ fieldId: 'x13.primary-incoming.c27', editorText: '12345678901' }] },
      { ...good, events: [{ fieldId: 'unknown', editorText: '1' }] },
      {
        ...good,
        events: Array.from({ length: 101 }, () => ({
          fieldId: 'x13.primary-incoming.c27',
          editorText: '1',
        })),
      },
    ];
    for (const payload of invalid) {
      const response = await preview(payload);
      expect(response.statusCode, response.body).toBe(400);
    }
    expect(await snapshot()).toEqual(before);
  });
  it('does not admit source, hidden, labour-code or unimplemented commits through the preview route', async () => {
    const dto = await state();
    const before = await snapshot();
    for (const column of ['01', '10', '13', '29', '40', '45']) {
      const response = await preview(
        journal(dto, [{ fieldId: `x13.primary-incoming.c${column}`, editorText: '1' }]),
      );
      expect(response.statusCode, response.body).toBe(422);
    }
    expect(await snapshot()).toEqual(before);
  });
  it('binds versions to the selected book, tenant and exact server row identity', async () => {
    const dto = await state();
    const before = await snapshot();
    expect((await preview(journal(dto), 'view', { ...selected, coBook: 'R92' })).statusCode).toBe(
      409,
    );
    expect((await preview(journal(dto), 'other')).statusCode).toBe(409);
    expect((await preview({ ...journal(dto), rowIdentity: 'a'.repeat(64) })).statusCode).toBe(409);
    expect(await snapshot()).toEqual(before);
  });
  it('observes master changes omitted from the existing saved-metadata token', async () => {
    const dto = await state();
    await sql(
      `UPDATE "ITEM_MAST" SET "IT_NAME"='Changed master name' WHERE tenant_id=$1`,
      tenantId,
    );
    const before = await snapshot();
    const response = await preview(journal(dto));
    expect(response.statusCode, response.body).toBe(409);
    const fresh = await state();
    expect(fresh.documentVersion).toBe(dto.documentVersion);
    expect(fresh.configurationVersion).toBe(dto.configurationVersion);
    expect(fresh.replayVersion).not.toBe(dto.replayVersion);
    expect(fresh.rows[0].visible['3']).toBe('Changed master name');
    expect(await snapshot()).toEqual(before);
  });
  it('rejects stale configuration and then explicitly refuses its newly hidden field', async () => {
    const dto = await state();
    await insert('COL_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      BOOK_NAME: 'SALES RETURNE',
      COL_NAME: 'OthAmt',
      COL_NEW_NAME: 'Other charges',
      YES_NO: 'N',
      COL_RPT: 'N',
    });
    const before = await snapshot();
    const event = [{ fieldId: 'x13.primary-incoming.c27', editorText: '5' }];
    expect((await preview(journal(dto, event))).statusCode).toBe(409);
    const fresh = await state();
    expect((await preview(journal(fresh, event))).statusCode).toBe(422);
    expect(await snapshot()).toEqual(before);
  });
  it('contains unsupported imported numeric state while preserving the saved raw read', async () => {
    await sql(
      `UPDATE "SL_DETL_RTN" SET "ITM_RATE"=NULL WHERE tenant_id=$1 AND "CO_BOOK"='R91'`,
      tenantId,
    );
    const before = await snapshot();
    const dto = await state();
    expect(dto.rows[0].raw.ITM_RATE).toBeNull();
    expect(dto.rows[0].visible).toBeNull();
    expect(dto.capabilities).toMatchObject({ canPreview: false, canSaveNumeric: false });
    expect((await preview(journal(dto))).statusCode).toBe(422);
    expect(await snapshot()).toEqual(before);
  });
});
