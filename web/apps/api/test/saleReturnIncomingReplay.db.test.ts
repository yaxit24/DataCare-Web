import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it, vi } from 'vitest';
import * as core from '@datacare/core';
import {
  getSaleReturnIncomingReplayState,
  previewSaleReturnIncomingReplay,
  type SaleReturnIncomingReplayState,
} from '../src/modules/sales/saleReturnIncomingReplay.js';
import { getSavedSaleReturnIncoming } from '../src/modules/sales/savedSaleReturn.js';
import independent from './fixtures/saleReturnIncomingReplay.independent.json';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('saved incoming Return trusted replay in a real read-only observation', () => {
  const tenantId = 'return-replay-r9';
  const otherTenant = 'return-replay-other-r9';
  const scope = { tenantId, coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R91' };
  const document = {
    tenant_id: tenantId,
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2024-2025',
    CO_BOOK: 'R91',
    VCH_NO: '00017',
  };
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
  const numeric = [
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
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const sql = (query: string, ...args: unknown[]) => owner.$executeRawUnsafe(query, ...args);
  const insert = async (table: string, values: Record<string, unknown>) => {
    const columns = Object.keys(values)
      .map((k) => `"${k}"`)
      .join(',');
    await sql(
      `INSERT INTO "${table}" (${columns}) SELECT ${columns} FROM jsonb_populate_record(NULL::"${table}",$1::jsonb)`,
      JSON.stringify(values),
    );
  };
  const cleanup = async () => {
    for (const table of tables)
      await sql(`DELETE FROM "${table}" WHERE tenant_id IN($1,$2)`, tenantId, otherTenant);
  };
  const snapshot = async () => {
    const result: Record<string, unknown> = {};
    for (const table of tables)
      result[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text raw,t.xmin::text revision,t.ctid::text locator FROM "${table}" t WHERE tenant_id IN($1,$2) ORDER BY to_jsonb(t)::text`,
        tenantId,
        otherTenant,
      );
    return result;
  };
  const line = (extra: Record<string, unknown> = {}) => ({
    ...document,
    ...Object.fromEntries(numeric.map((key) => [key, '0'])),
    SR_NO: '17',
    OLD_SRNO: '31',
    VCH_SRNO: '500001',
    TAG_SRNO: '123',
    VCH_DATE: '2024-07-10',
    VCH_TIME: '2024-07-10T12:34:56.123456',
    ENTRY_TYPE: 'P',
    INOUT_TYPE: 'I',
    IT_CODE: 'GOLD',
    TAG_NO: 'N',
    ITM_PCS: '1.250',
    ITM_GWT: '10',
    ITM_NWT: '10',
    ITM_FINE: '10',
    ITM_RATE: '100',
    ITM_AMT: '1000',
    TOT_AMT: '777',
    NET_AMT: '888',
    ITM_REMARK: null,
    ITM_SIZE: '',
    HM_ID: 'OLD HUID',
    LBR_CODE: 'L001',
    TAG_LBR_CODE: '',
    LBR_TYPE: 'N',
    RATE_TYPE: 'N',
    IT_TYPE: 'G',
    APR_ISU: 'N',
    EMP_ISU: 'N',
    ...extra,
  });
  const get = (override = {}) =>
    getSaleReturnIncomingReplayState(runtime, { ...scope, ...override }, '00017');
  const post = (
    dto: SaleReturnIncomingReplayState,
    events: Array<{ fieldId: string; editorText: string }>,
    row = 0,
  ) =>
    previewSaleReturnIncomingReplay(runtime, scope, '00017', {
      replayVersion: dto.replayVersion,
      rowIdentity: dto.rows[row]!.rowIdentity,
      events,
    });
  const event = (column: number, editorText: string) => ({
    fieldId: `x13.primary-incoming.c${String(column).padStart(2, '0')}`,
    editorText,
  });
  beforeAll(() => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
  });
  beforeEach(async () => {
    await cleanup();
    for (const tenant of [tenantId, otherTenant]) {
      await insert('CO_SET', { tenant_id: tenant, ...independent.serverSettings.CO_SET });
      await insert('CO_SET_NEW', { tenant_id: tenant, ...independent.serverSettings.CO_SET_NEW });
      await insert('YEAR_MAST', { tenant_id: tenant, ...independent.serverSettings.YEAR_MAST });
      await insert('ITEM_MAST', {
        tenant_id: tenant,
        CO_CODE: '01',
        IT_CODE: 'GOLD',
        IT_NAME: 'Scoped gold',
        RATE_TYPE: 'N',
        IT_TYPE: 'G',
      });
      for (const book of ['R91', 'R92']) {
        await insert('BOOK_DATA', {
          tenant_id: tenant,
          ...independent.serverSettings.BOOK_DATA,
          CO_BOOK: book,
        });
        await insert('SL_DATA', {
          ...document,
          tenant_id: tenant,
          CO_BOOK: book,
          VCH_DATE: '2024-07-10',
          VCH_TIME: '2024-07-10T12:34:56.123456',
          USER_UPDATE: 'Y',
          EMP_CODE: '',
          NET_AMT: '9999999999999999.99',
          VCH_DESC: null,
        });
        await insert('SL_DETL_RTN', line({ tenant_id: tenant, CO_BOOK: book }));
      }
    }
    await insert(
      'SL_DETL_RTN',
      line({
        SR_NO: '42',
        OLD_SRNO: '58',
        VCH_SRNO: '500042',
        TAG_SRNO: '142',
        ITM_REMARK: '',
        HM_ID: 'SECOND H1',
      }),
    );
  });
  afterAll(async () => {
    if (owner) {
      await cleanup();
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('hydrates exact raw identities, rawNULL/blank/decimals/microseconds, eight caches and an empty journal without recalculation or business writes', async () => {
    const before = await snapshot();
    const saved = await getSavedSaleReturnIncoming(runtime, scope, '00017');
    const dto = await get();
    expect(dto.documentVersion).toBe(saved.version);
    expect(dto.configurationVersion).toBe(dto.configuration.version);
    expect(JSON.stringify(dto)).not.toContain(tenantId);
    expect(
      dto.rows.map((row) => [row.identity.srNo, row.identity.oldSrNo, row.visible?.['0']]),
    ).toEqual([
      ['17', '31', '1'],
      ['42', '58', '2'],
    ]);
    expect(dto.rows[0]!.raw.ITM_REMARK).toBeNull();
    expect(dto.rows[1]!.raw.ITM_REMARK).toBe('');
    expect(dto.rows[0]!.raw.VCH_TIME).toContain('12:34:56.123456');
    expect(dto.rows[0]!.visible).toMatchObject({
      '9': '1.250',
      '29': 'L001',
      '36': '777.00',
      '38': '888.00',
      '41': '',
      '42': '',
    });
    expect(Object.keys(dto.rows[0]!.caches!)).toEqual([
      '45',
      '46',
      '47',
      '48',
      '49',
      '58',
      '66',
      '67',
    ]);
    const result = await post(dto, []);
    expect(result.preview).toEqual(result.baseline);
    expect(result.events).toEqual([]);
    expect(result.aggregateRequired).toBe(false);
    expect(result.capabilities.canSaveNumeric).toBe(false);
    expect(await snapshot()).toEqual(before);
  });
  it.each([19, 20, 21, 23, 24, 25, 26, 27, 28, 36, 37, 38])(
    'admits only a trusted configured LeaveCell for column%s without persisting it',
    async (column) => {
      const dto = await get();
      const before = await snapshot();
      const result = await post(dto, [event(column, column === 37 ? '2' : '5')]);
      expect(result.events).toEqual([
        { ...event(column, column === 37 ? '2' : '5'), status: 'applied' },
      ]);
      expect(result.aggregateRequired).toBe(true);
      expect(await snapshot()).toEqual(before);
    },
  );
  for (const vector of independent.vectors)
    it(`replays independent source prefixes: ${vector.id}`, async () => {
      await sql('DELETE FROM "SL_DETL_RTN" WHERE tenant_id=$1 AND "CO_BOOK"=$2', tenantId, 'R91');
      const raw: Record<string, unknown> = { ...vector.baseline.raw };
      for (const key of ['RAW_NULL', 'RAW_BLANK', 'UNRELATED_DECIMAL']) delete raw[key];
      await insert('SL_DETL_RTN', { ...raw, ...document, ENTRY_TYPE: 'P', INOUT_TYPE: 'I' });
      await insert('ITEM_MAST', { tenant_id: tenantId, ...vector.baseline.itemMasters[0]! });
      const dto = await get();
      expect(dto.configuration.policy).toEqual(independent.policy);
      expect(dto.rows[0]!.visible).toEqual({ ...vector.baseline.visible, '9': '1.000' });
      expect(dto.rows[0]!.caches).toEqual(vector.baseline.caches);
      const before = await snapshot();
      for (let count = 1; count <= vector.steps.length; count++) {
        const steps = vector.steps.slice(0, count);
        const result = await post(
          dto,
          steps.map((step) => step.event),
        );
        expect(result.preview.visible).toEqual({ ...steps.at(-1)!.expected.visible, '9': '1.000' });
        expect(result.preview.caches).toEqual(steps.at(-1)!.expected.caches);
        expect(result.events).toEqual(steps.map(({ event }) => ({ ...event, status: 'applied' })));
        expect(result.aggregateRequired).toBe(steps.at(-1)!.expected.aggregateRequired);
        expect(result.capabilities.canSaveNumeric).toBe(false);
        const editorAssertions = (
          steps.at(-1)!.expected as { editorTextByFieldAssertions?: Record<string, string> }
        ).editorTextByFieldAssertions;
        if (editorAssertions)
          expect(result.preview.editorTextByField).toMatchObject(editorAssertions);
        expect(result.preview.editorTextByField['x13.primary-incoming.c21']).toMatch(
          /^\d+\.\d{2}$/,
        );
      }
      expect(await snapshot()).toEqual(before);
    });
  it('returns the last-valid transient prefix on a calculator failure and preserves all business tables', async () => {
    const dto = await get();
    const before = await snapshot();
    await expect(post(dto, [event(27, '5'), event(37, '-100')])).rejects.toMatchObject({
      statusCode: 422,
      code: 'calculation-refused',
      details: {
        eventIndex: 1,
        editorText: '-100',
        preview: { visible: { '27': '5.00', '36': '1005.00' } },
        diagnostics: [{ code: 'zero-denominator' }],
      },
    });
    expect(await snapshot()).toEqual(before);
  });
  it('contains hidden, known unsupported and malformed events without widening the twelve-field profile', async () => {
    await insert('COL_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      BOOK_NAME: 'SALES RETURNE',
      COL_NAME: 'OthAmt',
      COL_NEW_NAME: 'Renamed other',
      YES_NO: 'N',
    });
    const dto = await get();
    const before = await snapshot();
    await expect(post(dto, [event(27, '2')])).rejects.toMatchObject({
      statusCode: 422,
      code: 'unsupported-field',
    });
    for (const col of [1, 9, 13, 22, 29, 31, 41, 45, 69])
      await expect(post(dto, [event(col, '1')])).rejects.toMatchObject({
        statusCode: 422,
        code: 'unsupported-field',
      });
    for (const value of ['NaN', '0x10', '1e2', '1,25', '12tail'])
      await expect(post(dto, [event(19, value)])).rejects.toMatchObject({
        statusCode: 422,
        code: 'calculation-refused',
      });
    expect(await snapshot()).toEqual(before);
  });
  it('retains an overlong saved editor verbatim, refuses echoing it, and permits explicit shorter correction', async () => {
    await sql(
      'UPDATE "SL_DETL_RTN" SET "ITM_RATE"=9999999999999999.99 WHERE tenant_id=$1 AND "CO_BOOK"=$2',
      tenantId,
      'R91',
    );
    const dto = await get();
    const before = await snapshot();
    expect(dto.rows[0]!.editorTextByField?.['x13.primary-incoming.c19']).toBe(
      '9999999999999999.99',
    );
    expect(dto.rows[0]!.fieldCapabilities.find((f) => f.fieldId.endsWith('c19'))?.allowed).toBe(
      true,
    );
    await expect(post(dto, [event(19, '9999999999999999.99')])).rejects.toMatchObject({
      statusCode: 400,
    });
    expect((await post(dto, [event(19, '100')])).preview.visible['19']).toBe('100.00');
    expect(await snapshot()).toEqual(before);
  });
  it.each([
    { TAG_NO: 'TAG-17' },
    { TAG_NO: null },
    { ENTRY_TYPE: 'R' },
    { INOUT_TYPE: 'O' },
    { APR_ISU: 'Y' },
    { EMP_ISU: 'Y' },
  ])('keeps unsupported historical profile readable but refuses preview %j', async (patch) => {
    await sql(
      'UPDATE "SL_DETL_RTN" SET ' +
        Object.keys(patch)
          .map((key, i) => `"${key}"=$${i + 2}`)
          .join(',') +
        ' WHERE tenant_id=$1 AND "CO_BOOK"=\'R91\' AND "SR_NO"=17',
      tenantId,
      ...Object.values(patch),
    );
    const dto = await get();
    const before = await snapshot();
    expect(dto.rows).toHaveLength(2);
    expect(dto.rows[0]!.raw).toMatchObject(patch);
    await expect(post(dto, [])).rejects.toMatchObject({
      statusCode: 422,
      code: 'unsupported-state',
    });
    expect(await snapshot()).toEqual(before);
  });
  it.each(['SL_DETL', 'SL_IDTL', 'BAR_DETL', 'BAR_IDTL', 'DM_DATA'])(
    'does not admit %s companion state or touch it',
    async (table) => {
      await insert(table, {
        ...document,
        SR_NO: 31,
        ...(['SL_IDTL', 'BAR_IDTL'].includes(table) ? { ISR_NO: 9 } : {}),
        ...(table === 'DM_DATA' ? { MAIN_SRNO: 17, ISR_NO: 9 } : {}),
      });
      const dto = await get();
      const before = await snapshot();
      expect(dto.capabilities.canPreview).toBe(false);
      await expect(post(dto, [])).rejects.toMatchObject({ statusCode: 422 });
      expect(await snapshot()).toEqual(before);
    },
  );
  it('returns NULL numeric projection diagnostics and contains period/document restrictions', async () => {
    await sql(
      'UPDATE "SL_DETL_RTN" SET "ITM_FINE"=NULL WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "SR_NO"=17',
      tenantId,
      'R91',
    );
    let dto = await get();
    expect(dto.rows[0]).toMatchObject({ visible: null, caches: null, editorTextByField: null });
    expect(dto.rows[0]!.diagnostics).toContainEqual(
      expect.objectContaining({
        code: 'unsupported-numeric-null',
        fieldId: 'x13.primary-incoming.c18',
      }),
    );
    await sql(
      'UPDATE "SL_DATA" SET "USER_UPDATE"=\'N\' WHERE tenant_id=$1 AND "CO_BOOK"=$2',
      tenantId,
      'R91',
    );
    dto = await get();
    expect(dto.capabilities.canPreview).toBe(false);
    await sql(
      'UPDATE "SL_DATA" SET "USER_UPDATE"=\'Y\',"VCH_DATE"=NULL WHERE tenant_id=$1 AND "CO_BOOK"=$2',
      tenantId,
      'R91',
    );
    expect((await get()).capabilities.canPreview).toBe(false);
  });
  it('separates complete book/tenant identities, exact five-digit keys and missing vouchers', async () => {
    const dto = await get();
    const otherBook = await get({ coBook: 'R92' });
    const other = await get({ tenantId: otherTenant });
    expect(new Set([dto.replayVersion, otherBook.replayVersion, other.replayVersion]).size).toBe(3);
    await expect(post({ ...dto, rows: otherBook.rows }, [])).rejects.toMatchObject({
      statusCode: 409,
      code: 'identity-conflict',
    });
    for (const no of ['17', '000017', '100000', '00000', '1e1', '17a'])
      await expect(getSaleReturnIncomingReplayState(runtime, scope, no)).rejects.toMatchObject({
        statusCode: 400,
      });
    await expect(getSaleReturnIncomingReplayState(runtime, scope, '99999')).rejects.toMatchObject({
      statusCode: 404,
    });
  });
  it('uses SQL numeric order with the same JSONB serial representation for scientific-range saved rows', async () => {
    await sql(
      'UPDATE "SL_DETL_RTN" SET "SR_NO"=1e-6 WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "SR_NO"=42',
      tenantId,
      'R91',
    );
    const expected: Array<{ srNo: string; directText: string }> = await owner.$queryRawUnsafe(
      'SELECT to_jsonb(t)->>\'SR_NO\' AS "srNo", "SR_NO"::text AS "directText" FROM "SL_DETL_RTN" t WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY "SR_NO"',
      tenantId,
      'R91',
    );
    expect(expected[0]!.directText).not.toBe(expected[0]!.srNo);
    expect(expected[1]!.srNo).toBe('17');
    const dto = await get();
    expect(dto.rows.map((r) => r.identity.srNo)).toEqual(expected.map((r) => r.srNo));
    expect(dto.rows.map((r) => r.visible?.['0'])).toEqual(['1', '2']);
    const reducer = vi.spyOn(core, 'reduceSaleReturnIncoming'); // Observe the real reducer call; no replacement implementation.
    try {
      expect((await post(dto, [event(27, '1')], 1)).rowIdentity).toBe(dto.rows[1]!.rowIdentity);
      expect(reducer.mock.calls[0]?.[1]).toMatchObject({ context: { currentRow: 2 } });
    } finally {
      reducer.mockRestore();
    }
  });
  it.each(['gold', 'GOLD '])(
    'contains discovered item alias %s and observes its physical identity',
    async (itCode) => {
      const before = await get();
      await insert('ITEM_MAST', {
        tenant_id: tenantId,
        CO_CODE: '01',
        IT_CODE: itCode,
        IT_NAME: 'Alias',
        RATE_TYPE: 'N',
        IT_TYPE: 'G',
      });
      const dto = await get();
      expect(dto.replayVersion).not.toBe(before.replayVersion);
      expect(dto.rows[0]!.diagnostics).toContainEqual(
        expect.objectContaining({ code: 'ambiguous-item-master' }),
      );
      await expect(post(before, [event(27, '1')])).rejects.toMatchObject({ statusCode: 409 });
    },
  );
  it('contains a normalized company alias but ignores genuinely different company masters', async () => {
    for (const table of [
      'CO_SET',
      'CO_SET_NEW',
      'YEAR_MAST',
      'BOOK_DATA',
      'SL_DATA',
      'SL_DETL_RTN',
      'ITEM_MAST',
    ])
      await sql(`UPDATE "${table}" SET "CO_CODE"='a1' WHERE tenant_id=$1`, tenantId);
    const current = { ...scope, coCode: 'a1' };
    const before = await getSaleReturnIncomingReplayState(runtime, current, '00017');
    await insert('ITEM_MAST', {
      tenant_id: tenantId,
      CO_CODE: '02',
      IT_CODE: 'GOLD',
      IT_NAME: 'Foreign',
      RATE_TYPE: 'N',
      IT_TYPE: 'G',
    });
    expect((await getSaleReturnIncomingReplayState(runtime, current, '00017')).replayVersion).toBe(
      before.replayVersion,
    );
    await insert('ITEM_MAST', {
      tenant_id: tenantId,
      CO_CODE: 'A1',
      IT_CODE: 'GOLD',
      IT_NAME: 'Alias',
      RATE_TYPE: 'N',
      IT_TYPE: 'G',
    });
    expect(
      (await getSaleReturnIncomingReplayState(runtime, current, '00017')).rows[0]!.diagnostics,
    ).toContainEqual(expect.objectContaining({ code: 'ambiguous-item-master' }));
  });
  it.each([
    [
      'header',
      'UPDATE "SL_DATA" SET "VCH_TIME"=\'2024-07-10 12:34:56.123457\' WHERE tenant_id=$1 AND "CO_BOOK"=\'R91\'',
    ],
    [
      'sibling',
      'UPDATE "SL_DETL_RTN" SET "HM_ID"=\'Changed\' WHERE tenant_id=$1 AND "CO_BOOK"=\'R91\' AND "SR_NO"=42',
    ],
    ['setting', 'UPDATE "CO_SET" SET "LBR_ROF"=1 WHERE tenant_id=$1'],
    ['master same-value', 'UPDATE "ITEM_MAST" SET "IT_NAME"="IT_NAME" WHERE tenant_id=$1'],
  ])('invalidates the full observation after %s change', async (_, query) => {
    const dto = await get();
    await sql(query, tenantId);
    const before = await snapshot();
    await expect(post(dto, [event(27, '1')])).rejects.toMatchObject({
      statusCode: 409,
      code: 'version-conflict',
    });
    expect(await snapshot()).toEqual(before);
  });
  it('versions master inputs independently of the metadata/configuration tokens and detects extant-row ABA', async () => {
    const dto = await get();
    await sql('UPDATE "ITEM_MAST" SET "IT_NAME"=\'Changed\' WHERE tenant_id=$1', tenantId);
    await sql('UPDATE "ITEM_MAST" SET "IT_NAME"=\'Scoped gold\' WHERE tenant_id=$1', tenantId);
    const after = await get();
    expect(after.documentVersion).toBe(dto.documentVersion);
    expect(after.configurationVersion).toBe(dto.configurationVersion);
    expect(after.replayVersion).not.toBe(dto.replayVersion);
    await sql('DELETE FROM "ITEM_MAST" WHERE tenant_id=$1', tenantId);
    await insert('ITEM_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      IT_CODE: 'GOLD',
      IT_NAME: 'Scoped gold',
      RATE_TYPE: 'N',
      IT_TYPE: 'G',
    });
    expect((await get()).replayVersion).not.toBe(after.replayVersion);
  });
  it('observes an initially absent override recurrence without claiming a durable tombstone', async () => {
    const dto = await get();
    await insert('COL_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      BOOK_NAME: 'SALES RETURNE',
      COL_NAME: 'Fine',
      COL_NEW_NAME: 'Fine',
      YES_NO: 'N',
    });
    expect((await get()).replayVersion).not.toBe(dto.replayVersion);
    await sql('DELETE FROM "COL_MAST" WHERE tenant_id=$1', tenantId);
    expect((await get()).replayVersion).toBe(dto.replayVersion);
  });
  it('reads document/configuration/master inside one actual RepeatableRead snapshot despite an interleaved owner commit', async () => {
    const before = await get();
    let transactions = 0;
    let changed = false;
    const wrapped = {
      $transaction: (fn: (tx: unknown) => unknown, options: unknown) => {
        transactions++;
        expect(options).toMatchObject({ isolationLevel: 'RepeatableRead' });
        return runtime.$transaction(
          async (tx) =>
            fn(
              new Proxy(tx, {
                get(target, key) {
                  if (key === '$queryRawUnsafe')
                    return async (query: string, ...args: unknown[]) => {
                      const result = await target.$queryRawUnsafe(query, ...args);
                      if (!changed && query.includes('FROM "SL_DETL_RTN"')) {
                        changed = true;
                        await owner.$transaction(async (second) => {
                          await second.$executeRawUnsafe(
                            'UPDATE "SL_DATA" SET "VCH_DESC"=\'Concurrent\' WHERE tenant_id=$1',
                            tenantId,
                          );
                          await second.$executeRawUnsafe(
                            'UPDATE "CO_SET" SET "LBR_ROF"=1 WHERE tenant_id=$1',
                            tenantId,
                          );
                          await second.$executeRawUnsafe(
                            'UPDATE "ITEM_MAST" SET "IT_NAME"=\'Concurrent\' WHERE tenant_id=$1',
                            tenantId,
                          );
                        });
                      }
                      return result;
                    };
                  const value = Reflect.get(target, key);
                  return typeof value === 'function' ? value.bind(target) : value;
                },
              }),
            ),
          options as { isolationLevel: 'RepeatableRead' },
        );
      },
    };
    const observed = await getSaleReturnIncomingReplayState(wrapped, scope, '00017');
    expect(changed).toBe(true);
    expect(transactions).toBe(1);
    expect(observed).toEqual(before);
    expect((await get()).replayVersion).not.toBe(before.replayVersion);
  });
});
