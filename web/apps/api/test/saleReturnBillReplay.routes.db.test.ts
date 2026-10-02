import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import type {
  SaleReturnBillReplayResult,
  SaleReturnBillReplayState,
} from '../src/modules/sales/saleReturnBillReplay.js';
import {
  assertBillTestDatabase,
  assertClosingUnavailable,
  assertMatrixCells,
  billEvent,
  billInsert,
  billJournal,
  billSelected,
  billVoucher,
  cleanBillFixture,
  independent,
  seedBillFixture,
  snapshotBillFixture,
} from './fixtures/saleReturnBillReplay.fixture.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('authenticated read-only saved incoming bill replay', () => {
  const tenantId = 'r11-bill-http';
  const otherTenant = 'r11-bill-http-other';
  const tenants = [tenantId, otherTenant];
  type Role = 'view' | 'unrelated' | 'other';
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Partial<Record<Role, string>> = {};
  const sql = (query: string, ...args: unknown[]) => owner.$executeRawUnsafe(query, ...args);
  const insert = (table: string, values: Record<string, unknown>) =>
    billInsert(owner, table, values);
  const snapshot = () => snapshotBillFixture(owner, tenants);
  const endpoint = (
    action = 'incoming-bill-replay-state',
    voucher = billVoucher,
    scope: Record<string, string> = billSelected,
  ) => `/sales-returns/${voucher}/${action}?${new URLSearchParams(scope)}`;
  const call = (
    method: 'GET' | 'POST',
    url: string,
    role: Role | 'anonymous' = 'view',
    payload?: unknown,
  ) =>
    app.inject({
      method,
      url,
      headers: role === 'anonymous' ? {} : { cookie: cookies[role] ?? '' },
      ...(payload === undefined ? {} : { payload: payload as object }),
    });
  const state = async (role: Role = 'view', scope: Record<string, string> = billSelected) => {
    const response = await call(
      'GET',
      endpoint('incoming-bill-replay-state', billVoucher, scope),
      role,
    );
    expect(response.statusCode, response.body).toBe(200);
    expect(response.headers['cache-control']).toBe('no-store');
    return response.json<SaleReturnBillReplayState>();
  };
  const preview = (
    payload: unknown,
    role: Role = 'view',
    scope: Record<string, string> = billSelected,
  ) => call('POST', endpoint('incoming-bill-replay', billVoucher, scope), role, payload);

  beforeAll(async () => {
    assertBillTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await cleanBillFixture(owner, tenants, true);
    const password = 'Source-Bill-Replay!2026';
    const hash = await hashPassword(password);
    for (const tenant of tenants) {
      await insert('CO_MAST', {
        tenant_id: tenant,
        CO_CODE: '01',
        LC_CODE: '01',
        CO_NAME: 'Bill fixture',
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
        CO_YEAR: billSelected.coYear,
        OP_DATE: '2024-04-01',
        CL_DATE: '2025-03-31',
      });
      for (const [user, form] of [
        ['view', 'Sales Return'],
        ['unrelated', 'Sales'],
      ] as const) {
        await insert('LOGIN_MAST', {
          tenant_id: tenant,
          CO_CODE: '01',
          LOGIN_NAME: user,
          LOGIN_PWD: hash,
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
          USER_NAME: user,
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
      secret: 'bill-preview-isolated-route-session-secret-over32',
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
          coYear: billSelected.coYear,
          loginName: role === 'other' ? 'view' : role,
          password,
        },
      });
      expect(response.statusCode, response.body).toBe(200);
      const values = response.headers['set-cookie'];
      cookies[role] = (Array.isArray(values) ? values : [values ?? ''])
        .map((cookie) => cookie.split(';', 1)[0])
        .join('; ');
    }
  });
  beforeEach(async () => {
    await cleanBillFixture(owner, tenants);
    await seedBillFixture(owner, tenants);
    await sql(
      'UPDATE "USER_SET" SET "FRM_VIEW"=\'Y\' WHERE tenant_id=$1 AND "USER_NAME"=\'view\'',
      tenantId,
    );
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await cleanBillFixture(owner, tenants, true);
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('allows fresh own View without Edit to inspect and interleave a real bill journal', async () => {
    const before = await snapshot();
    const dto = await state();
    expect(dto.scope).toEqual(billSelected);
    expect(dto.capabilities).toEqual({
      canPreviewBill: true,
      canPreviewClosing: false,
      canSaveNumeric: false,
    });
    expect(dto.savedHeader.AC_NAME).toBe('Saved bill customer');
    expect(dto.savedHeader.VCH_TIME).toContain('12:34:56.123456');
    assertMatrixCells(dto.phases.loaded!, independent.expected.loaded.matrixCells);
    assertMatrixCells(dto.phases.opened!, independent.expected.opened.matrixCells);
    const expected = independent.expected.prefixes[1]!;
    const response = await preview(billJournal(dto, expected.events));
    expect(response.statusCode, response.body).toBe(200);
    expect(response.headers['cache-control']).toBe('no-store');
    const result = response.json<SaleReturnBillReplayResult>();
    expect(result.events).toEqual(
      expected.events.map((event) => ({ ...event, status: 'applied' })),
    );
    expect(result.preview.visible).toMatchObject(expected.selectedRow);
    assertMatrixCells(result.phases.preview, expected.matrixCells);
    expect(result.phases.preview.incomingTotals).toMatchObject(expected.totals);
    assertClosingUnavailable(result.phases.preview);
    expect(result.capabilities.canSaveNumeric).toBe(false);
    expect(await snapshot()).toEqual(before);
  });
  it('preserves all twelve owned field capabilities and original same-value event text', async () => {
    const dto = await state();
    const row = dto.rowReplay.rows[0]!;
    const fields = [19, 20, 21, 23, 24, 25, 26, 27, 28, 36, 37, 38];
    expect(
      row.fieldCapabilities.filter((field) => field.allowed).map((field) => field.fieldId),
    ).toEqual(fields.map((column) => billEvent(column, '').fieldId));
    const before = await snapshot();
    for (const column of fields) {
      const fieldId = billEvent(column, '').fieldId;
      const event = { fieldId, editorText: row.editorTextByField![fieldId]! };
      const response = await preview(billJournal(dto, [event]));
      expect(response.statusCode, `${fieldId}: ${response.body}`).toBe(200);
      expect(response.json<SaleReturnBillReplayResult>().events).toEqual([
        { ...event, status: 'applied' },
      ]);
    }
    expect(await snapshot()).toEqual(before);
  });
  it('uses the outer bill token, never a v1 row token or another stored identity', async () => {
    const dto = await state();
    const another = await state('view', { ...billSelected, coBook: 'R12' });
    const before = await snapshot();
    for (const payload of [
      { ...billJournal(dto), replayVersion: dto.rowReplay.replayVersion },
      { ...billJournal(dto), rowIdentity: another.rowReplay.rows[0]!.rowIdentity },
    ]) {
      const response = await preview(payload);
      expect(response.statusCode, response.body).toBe(409);
    }
    expect(await snapshot()).toEqual(before);
  });
  it('rejects anonymous/unrelated/revoked rights despite a previously obtained token', async () => {
    const dto = await state();
    const before = await snapshot();
    expect((await call('GET', endpoint(), 'anonymous')).statusCode).toBe(401);
    expect((await call('GET', endpoint(), 'unrelated')).statusCode).toBe(403);
    expect((await preview(billJournal(dto), 'unrelated')).statusCode).toBe(403);
    await sql(
      'UPDATE "USER_SET" SET "FRM_VIEW"=\'N\' WHERE tenant_id=$1 AND "USER_NAME"=\'view\'',
      tenantId,
    );
    expect((await call('GET', endpoint())).statusCode).toBe(403);
    expect((await preview(billJournal(dto))).statusCode).toBe(403);
    expect(await snapshot()).toEqual(before);
  });
  it('requires exact explicit scope, rejects aliases/arrays, and isolates another tenant', async () => {
    const dto = await state();
    const before = await snapshot();
    for (const [key, value] of [
      ['coCode', '02'],
      ['lcCode', '02'],
      ['coYear', '2023-2024'],
    ] as const) {
      const response = await call(
        'GET',
        endpoint('incoming-bill-replay-state', billVoucher, { ...billSelected, [key]: value }),
      );
      expect(response.statusCode, response.body).toBe(409);
      expect(response.json<{ error: string }>().error).toBe('scope-mismatch');
    }
    for (const key of ['coCode', 'lcCode', 'coYear', 'coBook']) {
      const scope: Record<string, string> = { ...billSelected };
      delete scope[key];
      const response = await call(
        'GET',
        endpoint('incoming-bill-replay-state', billVoucher, scope),
      );
      expect(response.statusCode, response.body).toBe(400);
    }
    for (const suffix of ['&book=R11', '&coBook=R12', '&DATA_TYPE=C', '&taxRoundingDecimals=0']) {
      const response = await call('GET', endpoint() + suffix);
      expect(response.statusCode, response.body).toBe(400);
    }
    const foreign = await state('other');
    expect(foreign.savedHeader.AC_NAME).toBe('Foreign saved customer');
    expect(JSON.stringify(foreign)).not.toContain('Saved bill customer');
    expect((await preview(billJournal(dto), 'other')).statusCode).toBe(409);
    expect(await snapshot()).toEqual(before);
  });
  it('contains client policy, phase, hidden/source-copy and context authority fields', async () => {
    const dto = await state();
    const before = await snapshot();
    const authorities: Record<string, unknown> = {
      policy: { taxRoundingDecimals: 0 },
      taxPolicy: { raw: { 'CO_SET_NEW.ALL_ROF_REMOVE': 'Y' } },
      phase: 'opened',
      phases: dto.phases,
      openingBalance: { status: 'resolved', amount: '0' },
      DATA_TYPE: 'C',
      source: { coYear: '2023-2024', coBook: 'S01', vchNo: '00001' },
      rows: dto.rowReplay.rows,
    };
    for (const [key, value] of Object.entries(authorities)) {
      const response = await preview({ ...billJournal(dto), [key]: value });
      expect(response.statusCode, `${key}: ${response.body}`).toBe(400);
    }
    const hidden = await preview(billJournal(dto, [billEvent(42, '1')]));
    expect(hidden.statusCode, hidden.body).toBe(422);
    const unknown = await preview(
      billJournal(dto, [{ fieldId: 'x13.primary-incoming.c99', editorText: '1' }]),
    );
    expect(unknown.statusCode, unknown.body).toBe(400);
    const nonAsciiField = await preview(
      billJournal(dto, [{ fieldId: 'x13.primary-incoming.c27\u2028', editorText: '1' }]),
    );
    expect(nonAsciiField.statusCode, nonAsciiField.body).toBe(400);
    const context = await preview({
      ...billJournal(dto),
      events: [{ ...billEvent(27, '1'), context: { editorVisible: true } }],
    });
    expect(context.statusCode, context.body).toBe(400);
    const long = await preview(billJournal(dto, [billEvent(19, '12345678901')]));
    expect(long.statusCode, long.body).toBe(400);
    for (const text of ['\u2028', '\u00a0', '12\u2028']) {
      const nonAscii = await preview(billJournal(dto, [billEvent(27, text)]));
      expect(nonAscii.statusCode, JSON.stringify({ text, body: nonAscii.body })).toBe(400);
    }
    expect(await snapshot()).toEqual(before);
  });
  it('stales physical tax/name edits, then exposes authoritative reloaded labels and raw policy', async () => {
    const dto = await state();
    await sql('UPDATE "CO_SET" SET "TAX_ROF"="TAX_ROF" WHERE tenant_id=$1', tenantId);
    await sql(
      'UPDATE "AC_MAST" SET "AC_NAME"=\'Renamed current bank\' WHERE tenant_id=$1 AND "AC_CODE"=\'BANK\'',
      tenantId,
    );
    const before = await snapshot();
    const refused = await preview(billJournal(dto, [billEvent(27, '1')]));
    expect(refused.statusCode, refused.body).toBe(409);
    expect(refused.json<{ error: string }>().error).toBe('version-conflict');
    const reloaded = await state();
    expect(reloaded.replayVersion).not.toBe(dto.replayVersion);
    expect(reloaded.phases.loaded!.bill.matrix[4]![1]).toBe('Renamed current bank');
    expect(reloaded.taxPolicy.raw).toEqual({ 'CO_SET.TAX_ROF': '2', 'CO_SET.ALL_ROF_REMOVE': 'N' });
    expect((await preview(billJournal(reloaded, [billEvent(27, '1')]))).statusCode).toBe(200);
    expect(await snapshot()).toEqual(before);
  });
  it('returns recoverable complete prefix state after a failed second event with no writes', async () => {
    const dto = await state();
    const before = await snapshot();
    const response = await preview(billJournal(dto, [billEvent(27, '1'), billEvent(19, 'NaN')]));
    expect(response.statusCode, response.body).toBe(422);
    const error = response.json<{
      error: string;
      details: {
        eventIndex: number;
        editorText: string;
        preview: SaleReturnBillReplayResult['preview'];
        phases: SaleReturnBillReplayResult['phases'];
      };
    }>();
    expect(error.error).toBe('calculation-rejected');
    expect(error.details.eventIndex).toBe(1);
    expect(error.details.editorText).toBe('NaN');
    expect(error.details.preview.visible).toMatchObject({ '27': '1.00', '38': '111.00' });
    assertMatrixCells(error.details.phases.preview, independent.expected.prefixes[0]!.matrixCells);
    expect(await snapshot()).toEqual(before);
  });
  it('retains read-only empty and tagged saved documents without allowing partial aggregate replay', async () => {
    await sql('DELETE FROM "SL_DETL_RTN" WHERE tenant_id=$1 AND "CO_BOOK"=$2', tenantId, 'R11');
    await sql(
      'UPDATE "SL_DETL_RTN" SET "TAG_NO"=\'HIST17\' WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "SR_NO"=17',
      tenantId,
      'R12',
    );
    const before = await snapshot();
    const empty = await state();
    expect(empty.rowReplay.rows).toEqual([]);
    expect(empty.capabilities.canPreviewBill).toBe(false);
    expect(empty.savedHeader.AC_NAME).toBe('Saved bill customer');
    const fake = await preview({
      replayVersion: empty.replayVersion,
      rowIdentity: 'a'.repeat(64),
      events: [],
    });
    expect(fake.statusCode, fake.body).toBe(409);
    const taggedScope = { ...billSelected, coBook: 'R12' };
    const tagged = await state('view', taggedScope);
    expect(tagged.rowReplay.rows).toHaveLength(2);
    expect(tagged.capabilities.canPreviewBill).toBe(false);
    const blocked = await preview(billJournal(tagged, [billEvent(27, '1')]), 'view', taggedScope);
    expect(blocked.statusCode, blocked.body).toBe(422);
    expect(await snapshot()).toEqual(before);
  });
  it('validates configured books and exact saved voucher keys without falling back to other documents', async () => {
    const before = await snapshot();
    const missing = await call('GET', endpoint('incoming-bill-replay-state', '00099'));
    expect(missing.statusCode, missing.body).toBe(404);
    for (const key of ['17', '00000', '000017', 'ABC17']) {
      const invalid = await call('GET', endpoint('incoming-bill-replay-state', key));
      expect(invalid.statusCode, invalid.body).toBe(400);
    }
    const missingBook = await call(
      'GET',
      endpoint('incoming-bill-replay-state', billVoucher, { ...billSelected, coBook: 'R00' }),
    );
    expect(missingBook.statusCode, missingBook.body).toBe(409);
    await sql(
      'UPDATE "BOOK_DATA" SET "MAIN_BOOK"=\'SALES\' WHERE tenant_id=$1 AND "CO_BOOK"=$2',
      tenantId,
      'R12',
    );
    const updated = await snapshot();
    const wrongFamily = await call(
      'GET',
      endpoint('incoming-bill-replay-state', billVoucher, { ...billSelected, coBook: 'R12' }),
    );
    expect(wrongFamily.statusCode, wrongFamily.body).toBe(422);
    expect(await snapshot()).toEqual(updated);
    expect(updated).not.toEqual(before); // Only the intentional owner fixture change occurred.
  });
});
