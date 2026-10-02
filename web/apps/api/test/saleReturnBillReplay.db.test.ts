import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { PrismaClient } from '@datacare/db';
import * as core from '@datacare/core';
import { afterAll, afterEach, beforeAll, beforeEach, describe, expect, it, vi } from 'vitest';
import {
  getSaleReturnBillReplayState,
  previewSaleReturnBillReplay,
  type SaleReturnBillReplayState,
} from '../src/modules/sales/saleReturnBillReplay.js';
import { getSaleReturnIncomingReplayState } from '../src/modules/sales/saleReturnIncomingReplay.js';
import {
  assertBillTestDatabase,
  assertClosingUnavailable,
  assertMatrixCells,
  billEvent,
  billInsert,
  billJournal,
  billKey,
  billSelected,
  billVoucher,
  cleanBillFixture,
  independent,
  seedBillFixture,
  snapshotBillFixture,
} from './fixtures/saleReturnBillReplay.fixture.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('trusted saved incoming bill phases in PostgreSQL', () => {
  const tenantId = 'r11-bill-service';
  const otherTenant = 'r11-bill-service-other';
  const tenants = [tenantId, otherTenant];
  const scope = { tenantId, ...billSelected };
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const sql = (query: string, ...args: unknown[]) => owner.$executeRawUnsafe(query, ...args);
  const insert = (table: string, values: Record<string, unknown>) =>
    billInsert(owner, table, values);
  const snapshot = () => snapshotBillFixture(owner, tenants);
  const get = (overrides = {}) =>
    getSaleReturnBillReplayState(runtime, { ...scope, ...overrides }, billVoucher);
  const post = (
    state: SaleReturnBillReplayState,
    events: Array<{ fieldId: string; editorText: string }> = [],
    row = 0,
  ) => previewSaleReturnBillReplay(runtime, scope, billVoucher, billJournal(state, events, row));

  beforeAll(() => {
    assertBillTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
  });
  beforeEach(async () => {
    await cleanBillFixture(owner, tenants);
    await seedBillFixture(owner, tenants);
  });
  afterEach(() => vi.restoreAllMocks());
  afterAll(async () => {
    if (owner) {
      await cleanBillFixture(owner, tenants);
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('pins source-authored numerical expectations independently of the new service', () => {
    const bytes = readFileSync(
      new URL('./fixtures/saleReturnBillReplay.independent.json', import.meta.url),
    );
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      '1d0cecba70ed751c64a14b506f18468a49778987dda285b0a0abbb37b7b48410',
    );
  });
  it('distinguishes raw saved, loaded and opened values without changing v1 or any business rows', async () => {
    const before = await snapshot();
    const v1 = await getSaleReturnIncomingReplayState(runtime, scope, billVoucher);
    const state = await get();
    expect(state.rowReplay).toEqual(v1);
    expect(state.replayVersion).toMatch(/^[a-f0-9]{64}$/);
    expect(state.replayVersion).not.toBe(v1.replayVersion);
    expect(state.savedHeader).toMatchObject({
      VCH_DESC: null,
      BILL_NO: '',
      DISC_AMT: '9999999999999999.99',
      RTN_NET_AMT: '160',
      RTN_TOT_AMT: '166.75',
      KASAR_AMT: null,
      BILL_OS: null,
      RTN_KASAR_AMT: null,
      RTN_BILL_OS: null,
    });
    expect(state.savedHeader.VCH_TIME).toContain('12:34:56.123456');
    expect(state.rowReplay.rows.map((row) => [row.identity.srNo, row.identity.oldSrNo])).toEqual([
      ['17', '31'],
      ['42', '58'],
    ]);
    expect(state.rowReplay.rows[0]!.raw.ITM_REMARK).toBeNull();
    expect(state.rowReplay.rows[1]!.raw.ITM_REMARK).toBe('');
    expect(state.capabilities).toEqual({
      canPreviewBill: true,
      canPreviewClosing: false,
      canSaveNumeric: false,
    });
    expect(state.phases.loaded).not.toBeNull();
    expect(state.phases.opened).not.toBeNull();
    assertMatrixCells(state.phases.loaded!, independent.expected.loaded.matrixCells);
    expect(Object.keys(state.phases.loaded!.incomingTotals)).toHaveLength(71);
    expect(Object.values(state.phases.loaded!.incomingTotals).every((value) => value === '')).toBe(
      true,
    );
    assertMatrixCells(state.phases.opened!, independent.expected.opened.matrixCells);
    expect(state.phases.opened!.incomingTotals).toMatchObject(independent.expected.opened.totals);
    expect(state.phases.opened!.incomingTotals['26']).toBe('');
    expect(state.phases.opened!.incomingTotals['37']).toBe('');
    expect(state.phases.opened!.bill.oldNetAmt).toBe('160');
    expect(state.phases.opened!.bill.oldTaxPrc).toBe('10');
    for (const phase of [state.phases.loaded!, state.phases.opened!])
      assertClosingUnavailable(phase);
    expect(JSON.stringify(state)).not.toContain(tenantId);
    expect(await snapshot()).toEqual(before);
  });
  it.each(independent.expected.prefixes)(
    'interleaves every genuine event in the source prefix $events',
    async (expected) => {
      const state = await get();
      const before = await snapshot();
      const result = await post(state, expected.events);
      expect(result.events).toEqual(
        expected.events.map((event) => ({ ...event, status: 'applied' })),
      );
      expect(result.baseline.visible).toEqual(state.rowReplay.rows[0]!.visible);
      expect(result.preview.visible).toMatchObject(expected.selectedRow);
      expect(result.preview.caches).toEqual({
        '45': '10.000',
        '46': '10.000',
        '47': '100.00',
        '48': '0.00',
        '49': '10.00',
        '58': '1.00',
        '66': '10.00',
        '67': '0.00',
      });
      expect(result.phases.preview.incomingTotals).toMatchObject(expected.totals);
      assertMatrixCells(result.phases.preview, expected.matrixCells);
      expect(result.phases.preview.bill.oldNetAmt).toBe(expected.oldNetAmt);
      expect(result.phases.preview.bill.oldTaxPrc).toBe(expected.oldTaxPrc);
      expect(result.phases.loaded).toEqual(state.phases.loaded);
      expect(result.phases.opened).toEqual(state.phases.opened);
      assertClosingUnavailable(result.phases.preview);
      expect(result.capabilities).toEqual({ canPreviewClosing: false, canSaveNumeric: false });
      expect(await getSaleReturnIncomingReplayState(runtime, scope, billVoucher)).toEqual(
        state.rowReplay,
      );
      expect(await snapshot()).toEqual(before);
    },
  );
  it('empty and repeated journals preserve source event history without claiming a save', async () => {
    const state = await get();
    const before = await snapshot();
    const empty = await post(state);
    expect(empty.preview).toEqual(empty.baseline);
    expect(empty.phases.preview).toEqual(state.phases.opened);
    expect(empty.events).toEqual([]);
    const repeated = await post(state, [billEvent(27, '1'), billEvent(27, '1')]);
    expect(repeated.events).toEqual([
      { ...billEvent(27, '1'), status: 'applied' },
      { ...billEvent(27, '1'), status: 'applied' },
    ]);
    expect(repeated.phases.preview.bill.matrix[2]![3]).toBe('16.10');
    expect(repeated.phases.preview.bill.matrix[3]![3]).toBe('177.00');
    expect(await snapshot()).toEqual(before);
  });
  it('can replay the second stored row while aggregating the untouched first row', async () => {
    const state = await get();
    const before = await snapshot();
    const result = await post(state, [billEvent(27, '5')], 1);
    expect(result.rowIdentity).toBe(state.rowReplay.rows[1]!.rowIdentity);
    expect(result.baseline.visible['0']).toBe('2');
    expect(result.preview.visible['38']).toBe('55.00');
    expect(result.phases.preview.incomingTotals['38']).toBe('165.00');
    expect(result.phases.preview.bill.matrix[2]![3]).toBe('16.50');
    expect(result.phases.preview.bill.matrix[3]![3]).toBe('182.00'); // Math.Round(181.5,0), ties-even.
    expect(await snapshot()).toEqual(before);
  });
  it('recalculates the saved-open tax cache after whole rounding without recalculating incoming rows', async () => {
    await sql(
      'UPDATE "SL_DATA" SET "RTN_NET_AMT"=200.60 WHERE tenant_id=$1 AND "CO_BOOK"=$2',
      tenantId,
      'R11',
    );
    await sql(
      'UPDATE "SL_DETL_RTN" SET "NET_AMT"=150.60,"TOT_AMT"=150.60 WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "SR_NO"=17',
      tenantId,
      'R11',
    );
    const before = await snapshot();
    const state = await get();
    expect(state.savedHeader.RTN_NET_AMT).toBe('200.6');
    expect(state.rowReplay.rows[0]!.visible?.['38']).toBe('150.60');
    expect(state.phases.loaded!.bill.oldNetAmt).toBe('200.6');
    expect(state.phases.opened!.bill.incomingRounded).toBe('201.00');
    expect(state.phases.opened!.bill.matrix[2]![3]).toBe('20.10');
    expect(state.phases.opened!.bill.matrix[3]![3]).toBe('221.00');
    expect(await snapshot()).toEqual(before);
  });
  it.each([
    ['N', '1.00'],
    ['Y', '1.41'],
  ] as const)('uses trusted TAX_ROF0 / ALL_ROF_REMOVE%s for the tax step', async (flag, tax) => {
    await sql(
      'UPDATE "CO_SET" SET "TAX_ROF"=0,"ALL_ROF_REMOVE"=$2 WHERE tenant_id=$1',
      tenantId,
      flag,
    );
    await sql(
      'UPDATE "SL_DATA" SET "RTN_NET_AMT"=0,"TAX_PRC"=1.4,"TAX_AMT"=7 WHERE tenant_id=$1 AND "CO_BOOK"=$2',
      tenantId,
      'R11',
    );
    await sql(
      'UPDATE "SL_DETL_RTN" SET "NET_AMT"=CASE WHEN "SR_NO"=17 THEN 51 ELSE 50 END WHERE tenant_id=$1 AND "CO_BOOK"=$2',
      tenantId,
      'R11',
    );
    const before = await snapshot();
    const state = await get();
    expect(state.taxPolicy.status).toBe('ready');
    expect(state.phases.opened!.bill.matrix[2]![3]).toBe(tax);
    expect(state.phases.opened!.bill.matrix[3]![3]).toBe('102.00');
    expect(await snapshot()).toEqual(before);
  });
  it('reads SQL NULL tax precision through Fnv and preserves the exact qualified owner', async () => {
    await sql('UPDATE "CO_SET" SET "TAX_ROF"=NULL WHERE tenant_id=$1', tenantId);
    const before = await snapshot();
    const state = await get();
    expect(state.taxPolicy).toMatchObject({
      status: 'ready',
      raw: { 'CO_SET.TAX_ROF': null, 'CO_SET.ALL_ROF_REMOVE': 'N' },
      policy: { taxRoundingDecimals: 0 },
    });
    expect(state.taxPolicy.raw).not.toHaveProperty('CO_SET_NEW.ALL_ROF_REMOVE');
    const result = await post(state, [billEvent(27, '1')]);
    expect(result.phases.preview.bill.matrix[2]![3]).toBe('16.00');
    expect(await snapshot()).toEqual(before);
  });
  it.each(['TAX_AMT', 'RTN_TOT_AMT'] as const)(
    'contains direct-Val NULL %s while raw saved values remain inspectable',
    async (field) => {
      await sql(
        `UPDATE "SL_DATA" SET "${field}"=NULL WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
        tenantId,
        'R11',
      );
      const before = await snapshot();
      const state = await get();
      expect(state.savedHeader[field]).toBeNull();
      expect(state.capabilities.canPreviewBill).toBe(false);
      expect(state.diagnostics.length).toBeGreaterThan(0);
      await expect(post(state, [billEvent(27, '1')])).rejects.toMatchObject({ statusCode: 422 });
      expect(await snapshot()).toEqual(before);
    },
  );
  it.each([
    'null-unselected',
    'tagged-unselected',
    'empty',
    'outgoing',
    'negative-tax',
    'duplicate-settings',
  ] as const)('contains %s instead of silently dropping unsupported input', async (kind) => {
    if (kind === 'null-unselected')
      await sql(
        'UPDATE "SL_DETL_RTN" SET "ITM_RATE"=NULL WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "SR_NO"=42',
        tenantId,
        'R11',
      );
    if (kind === 'tagged-unselected')
      await sql(
        'UPDATE "SL_DETL_RTN" SET "TAG_NO"=\'TAG42\' WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "SR_NO"=42',
        tenantId,
        'R11',
      );
    if (kind === 'empty')
      await sql('DELETE FROM "SL_DETL_RTN" WHERE tenant_id=$1 AND "CO_BOOK"=$2', tenantId, 'R11');
    if (kind === 'outgoing')
      await insert('SL_DETL', { ...billKey(tenantId), SR_NO: 9, OLD_SRNO: 19, IT_CODE: 'GOLD' });
    if (kind === 'negative-tax')
      await sql('UPDATE "CO_SET" SET "TAX_ROF"=-1 WHERE tenant_id=$1', tenantId);
    if (kind === 'duplicate-settings')
      await insert('CO_SET', { tenant_id: tenantId, CO_CODE: '01', TAX_ROF: 2 });
    const before = await snapshot();
    const state = await get();
    expect(state.capabilities.canPreviewBill).toBe(false);
    expect(state.phases.opened).toBeNull();
    expect(state.diagnostics.length).toBeGreaterThan(0);
    expect(state.rowReplay.rows).toHaveLength(kind === 'empty' ? 0 : 2);
    if (kind !== 'empty')
      await expect(post(state, [billEvent(27, '1')])).rejects.toMatchObject({ statusCode: 422 });
    expect(await snapshot()).toEqual(before);
  });
  it('retains exact scoped current display labels without replacing saved percentages or customer data', async () => {
    const state = await get();
    const loaded = state.phases.loaded!.bill.matrix;
    expect(loaded[2]![1]).toBe('Current tax label');
    expect(loaded[4]![1]).toBe('Current bank label');
    expect(loaded[5]![1]).toBe('Current card label');
    expect(loaded[2]![2]).toBe('10.00');
    expect(state.savedHeader.AC_NAME).toBe('Saved bill customer');
    expect(loaded[0]![3]).toBe('Payment    ');
    expect(loaded[0]![4]).toBe('Received    ');
    expect(JSON.stringify(state)).not.toContain('Foreign');
  });
  it.each(['missing-tax', 'duplicate-bank', 'duplicate-tax', 'bank-alias'] as const)(
    'represents %s as an unavailable label without inventing rates',
    async (kind) => {
      if (kind === 'missing-tax') await sql('DELETE FROM "TAX_MAST" WHERE tenant_id=$1', tenantId);
      if (kind === 'duplicate-bank')
        await insert('AC_MAST', {
          tenant_id: tenantId,
          CO_CODE: '01',
          AC_CODE: 'BANK',
          AC_NAME: 'Ambiguous bank',
        });
      if (kind === 'duplicate-tax')
        await insert('TAX_MAST', {
          tenant_id: tenantId,
          CO_CODE: '01',
          TAX_CODE: '10',
          SR_NO: 0,
          TAX_NAME: 'Ambiguous tax',
          TAX_PRC: '1',
        });
      if (kind === 'bank-alias')
        await insert('AC_MAST', {
          tenant_id: tenantId,
          CO_CODE: '01',
          AC_CODE: 'bank',
          AC_NAME: 'Noncanonical bank alias',
        });
      const before = await snapshot();
      const state = await get();
      expect(state.capabilities.canPreviewBill).toBe(true);
      expect(
        state.phases.loaded!.bill.matrix[
          kind.endsWith('bank') || kind === 'bank-alias' ? 4 : 2
        ]![1],
      ).toBe('');
      expect(state.diagnostics.length).toBeGreaterThan(0);
      expect(state.phases.opened!.bill.matrix[2]![3]).toBe('7.00');
      expect(await snapshot()).toEqual(before);
    },
  );
  it.each([
    'header',
    'tax-setting',
    'same-value-tax-setting',
    'unselected-master',
    'tax-name',
    'bank-name',
  ] as const)('invalidates %s physically before any projection or replay', async (kind) => {
    const state = await get();
    if (kind === 'header')
      await sql(
        'UPDATE "SL_DATA" SET "VCH_DESC"=\'changed\' WHERE tenant_id=$1 AND "CO_BOOK"=$2',
        tenantId,
        'R11',
      );
    if (kind === 'tax-setting')
      await sql('UPDATE "CO_SET" SET "TAX_ROF"=0 WHERE tenant_id=$1', tenantId);
    if (kind === 'same-value-tax-setting')
      await sql('UPDATE "CO_SET" SET "TAX_ROF"="TAX_ROF" WHERE tenant_id=$1', tenantId);
    if (kind === 'unselected-master')
      await sql(
        'UPDATE "ITEM_MAST" SET "IT_NAME"=\'Changed silver\' WHERE tenant_id=$1 AND "IT_CODE"=\'SILVR\'',
        tenantId,
      );
    if (kind === 'tax-name')
      await sql('UPDATE "TAX_MAST" SET "TAX_NAME"=\'Changed tax\' WHERE tenant_id=$1', tenantId);
    if (kind === 'bank-name')
      await sql(
        'UPDATE "AC_MAST" SET "AC_NAME"=\'Changed bank\' WHERE tenant_id=$1 AND "AC_CODE"=\'BANK\'',
        tenantId,
      );
    const before = await snapshot();
    const projection = vi.spyOn(core, 'projectSavedSaleReturnIncoming');
    const headerProjection = vi.spyOn(core, 'projectSavedSaleReturnBill');
    const reducer = vi.spyOn(core, 'reduceSaleReturnIncoming');
    await expect(post(state, [billEvent(27, '1')])).rejects.toMatchObject({
      statusCode: 409,
      code: 'version-conflict',
    });
    expect(projection).not.toHaveBeenCalled();
    expect(headerProjection).not.toHaveBeenCalled();
    expect(reducer).not.toHaveBeenCalled();
    expect(await snapshot()).toEqual(before);
    expect((await get()).replayVersion).not.toBe(state.replayVersion);
  });
  it('preserves a complete first prefix when the following calculator event is refused', async () => {
    const state = await get();
    const before = await snapshot();
    let caught: unknown;
    try {
      await post(state, [billEvent(27, '1'), billEvent(19, 'NaN')]);
    } catch (error) {
      caught = error;
    }
    expect(caught).toMatchObject({
      statusCode: 422,
      code: 'calculation-rejected',
      details: { eventIndex: 1, fieldId: billEvent(19, '').fieldId, editorText: 'NaN' },
    });
    const recovery = (
      caught as {
        details: {
          preview: { visible: Record<string, string> };
          phases: { preview: NonNullable<SaleReturnBillReplayState['phases']['opened']> };
        };
      }
    ).details;
    expect(recovery.preview.visible).toMatchObject({
      '27': '1.00',
      '36': '111.00',
      '38': '111.00',
    });
    assertMatrixCells(recovery.phases.preview, independent.expected.prefixes[0]!.matrixCells);
    expect(await snapshot()).toEqual(before);
  });
  it('rolls back the row and aggregate journals when a later bill-tax result exceeds the admitted range', async () => {
    // Independent reviewer-derived boundary: first labour-percent event produces
    // about1e32 metal; the second produces about1.1e33 net. The99999% saved tax
    // then exceeds the bill1e36 bound, after row and incoming-fold calculations.
    await sql('UPDATE "CO_SET" SET "SL_AMT_TYPE"=\'F\' WHERE tenant_id=$1', tenantId);
    await sql(
      'UPDATE "SL_DATA" SET "TAX_PRC"=99999 WHERE tenant_id=$1 AND "CO_BOOK"=\'R11\'',
      tenantId,
    );
    await sql(
      `UPDATE "SL_DETL_RTN" SET "ITM_GWT"=10000000000,"ITM_NWT"=10000000000,
        "ITM_TOUCH"=1000000000,"ITM_RATE"=1000000000000000,
        "LBR_PRC"=0,"LBR_RATE"=0,"LBR_AMT"=0,"LBR_TYPE"='N'
       WHERE tenant_id=$1 AND "CO_BOOK"='R11' AND "SR_NO"=17`,
      tenantId,
    );
    const before = await snapshot();
    const dto = await get();
    expect(dto.capabilities.canPreviewBill).toBe(true);
    const first = billEvent(21, '0');
    const second = billEvent(21, '9999999999');
    const validPrefix = await post(dto, [first]);
    let caught: unknown;
    try {
      await post(dto, [first, second]);
    } catch (error) {
      caught = error;
    }
    expect(caught).toMatchObject({
      statusCode: 422,
      code: 'calculation-rejected',
      details: {
        eventIndex: 1,
        ...second,
        baseline: validPrefix.baseline,
        preview: validPrefix.preview,
        phases: validPrefix.phases,
        diagnostics: [
          expect.objectContaining({ code: 'unsupported-precision', stage: 'bill matrix r2' }),
        ],
      },
    });
    expect(await snapshot()).toEqual(before);
  });
  it('keeps closing unavailable despite a posting-book type and an unrelated earlier customer ledger balance', async () => {
    const initial = await get();
    await insert('AC_DATA', {
      ...billKey(tenantId, 'R12'),
      LEDR_KEY: 'r11-unresolved-mode',
      AC_CODE: 'CUST',
      ENTRY_TIME: '2024-07-10T11:00:00',
      DATA_TYPE: 'B',
      CR_AMT: '999',
      DR_AMT: '0',
    });
    const before = await snapshot();
    const state = await get();
    expect(state.replayVersion).toBe(initial.replayVersion); // No cross-book ledger authority is claimed.
    assertClosingUnavailable(state.phases.opened!);
    const result = await post(state, [billEvent(27, '1')]);
    assertClosingUnavailable(result.phases.preview);
    expect(result.phases.preview.bill.matrix[8]![3]).toBe('177.00');
    expect(await snapshot()).toEqual(before);
  });
  it('keeps duplicate voucher numbers isolated by configured book and tenant', async () => {
    const main = await get();
    const otherBook = await get({ coBook: 'R12' });
    const foreign = await get({ tenantId: otherTenant });
    expect(otherBook.savedHeader.AC_NAME).toBe('Other book saved customer');
    expect(foreign.savedHeader.AC_NAME).toBe('Foreign saved customer');
    expect(main.replayVersion).not.toBe(otherBook.replayVersion);
    expect(main.replayVersion).not.toBe(foreign.replayVersion);
    const before = await snapshot();
    await expect(
      previewSaleReturnBillReplay(
        runtime,
        { ...scope, coBook: 'R12' },
        billVoucher,
        billJournal(main),
      ),
    ).rejects.toMatchObject({ statusCode: 409 });
    await expect(getSaleReturnBillReplayState(runtime, scope, '00099')).rejects.toMatchObject({
      statusCode: 404,
    });
    expect(await snapshot()).toEqual(before);
  });
  it('observes header, row settings and display masters within one real RepeatableRead snapshot', async () => {
    const before = await get();
    let changed = false;
    let transactions = 0;
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
                        await owner.$transaction(async (other) => {
                          await other.$executeRawUnsafe(
                            'UPDATE "CO_SET" SET "TAX_ROF"=0 WHERE tenant_id=$1',
                            tenantId,
                          );
                          await other.$executeRawUnsafe(
                            'UPDATE "TAX_MAST" SET "TAX_NAME"=\'Concurrent label\' WHERE tenant_id=$1',
                            tenantId,
                          );
                          await other.$executeRawUnsafe(
                            'UPDATE "SL_DATA" SET "TAX_AMT"=9 WHERE tenant_id=$1 AND "CO_BOOK"=$2',
                            tenantId,
                            'R11',
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
    const result = await getSaleReturnBillReplayState(wrapped, scope, billVoucher);
    expect(changed).toBe(true);
    expect(transactions).toBe(1);
    expect(result).toEqual(before);
    expect((await get()).replayVersion).not.toBe(before.replayVersion);
  });
});
