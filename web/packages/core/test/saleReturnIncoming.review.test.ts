import { readFileSync } from 'node:fs';
import { createHash } from 'node:crypto';
import { Decimal } from 'decimal.js';
import { describe, expect, it } from 'vitest';
import {
  createSaleReturnIncomingState,
  reduceSaleReturnIncoming,
  saleReturnIncomingCells,
  type SaleReturnIncomingEvent,
  type SaleReturnIncomingPolicy,
  type SaleReturnIncomingResult,
  type SaleReturnIncomingState,
} from '../src/saleReturnIncoming.js';

// Independent source/IL vectors predate the reducer; never obtain expectations from it.
const originalBytes = readFileSync(
  new URL('./fixtures/saleReturnIncoming.independent.json', import.meta.url),
);
const widthBytes = readFileSync(
  new URL('./fixtures/saleReturnIncoming.widths.json', import.meta.url),
);
const original = JSON.parse(originalBytes.toString('utf8')) as {
  baseCells: Record<number, string>;
};
const widthCases = JSON.parse(widthBytes.toString('utf8')) as {
  baseColumnWidths: Record<number, number>;
  vectors: Array<{
    id: string;
    initialCells: Record<number, string>;
    columnWidths: Record<number, number>;
    event: { kind: 'leaveCell'; column: number; text: string };
    expectedCells: Record<number, string>;
  }>;
};
const rowIdentity = 'tenant|01|02|2024-2025|R61|00001|17|31|417|117';
const policy: SaleReturnIncomingPolicy = {
  saleAmountType: 'N',
  labourRoundingDecimals: 2,
  labourIncludesGhat: true,
  generateLabourRate: false,
  fineColumnWidth: 1000,
};
const raw = {
  CO_BOOK: 'R61',
  VCH_NO: '00001',
  SR_NO: '17',
  OLD_SRNO: '31',
  VCH_SRNO: '417',
  TAG_SRNO: '117',
  NET_AMT: '9999999999999999.99',
  ITM_GWT: '1234567890123.456',
  VCH_TIME: '2024-07-10T09:17:18.123456',
  ITM_REMARK: null,
  HM_ID2: '',
  HM_ID3: '  preserved  ',
  DESIGN_IMG_ID: null,
};

function state(cells: Record<number, string> = {}): SaleReturnIncomingState {
  return createSaleReturnIncomingState({
    rowIdentity,
    raw,
    cells: { ...original.baseCells, 41: 'UNKNOWN41', 42: 'UNKNOWN42', 59: 'HIDDEN', ...cells },
    cacheMode: 'provided',
  });
}
function leave(
  column: number,
  text: string,
): Extract<SaleReturnIncomingEvent, { kind: 'leaveCell' }> {
  return {
    kind: 'leaveCell',
    rowIdentity,
    column,
    text,
    context: { currentRow: 1, clearing: false, editorVisible: true, committedColumnWidth: 1000 },
  };
}
function applied(result: SaleReturnIncomingResult): SaleReturnIncomingState {
  expect(result.status).toBe('applied');
  if (result.status !== 'applied') throw new Error(JSON.stringify(result));
  return result.state;
}
function expectPreserved(before: SaleReturnIncomingState, after: SaleReturnIncomingState): void {
  expect(after.raw).toBe(before.raw);
  expect(after.raw).toEqual(raw);
  expect(after.rowIdentity).toBe(rowIdentity);
  expect(after.visible[41]).toBe(before.visible[41]);
  expect(after.visible[42]).toBe(before.visible[42]);
  expect(after.visible[59]).toBe(before.visible[59]);
}

describe('independent primary Return source and IL review', () => {
  it('uses byte-identical immutable pre-implementation source/IL expectations', () => {
    expect(createHash('sha256').update(originalBytes).digest('hex')).toBe(
      'ad1184e6bb7f7256e42e85b5469ea3152404fba25566465389bc6a7ba4367527',
    );
    expect(createHash('sha256').update(widthBytes).digest('hex')).toBe(
      '3c0bef2a5aa86fca83d8c0e98b56e36c553595f2b941a06642409ce7e631d309',
    );
  });
  it.each(widthCases.vectors)('$id', (vector) => {
    const before = state(vector.initialCells);
    const snapshot = structuredClone(before);
    const widths = { ...widthCases.baseColumnWidths, ...vector.columnWidths };
    const event = leave(vector.event.column, vector.event.text);
    event.context.committedColumnWidth = widths[vector.event.column] ?? 1000;
    const result = reduceSaleReturnIncoming(before, event, {
      ...policy,
      saleAmountType: 'F',
      fineColumnWidth: widths[18] ?? null,
    });
    const after =
      vector.id === 'hidden-active-column-skips-entire-leave'
        ? (expect(result.status).toBe('skipped'), result.state)
        : applied(result);
    for (const [column, expected] of Object.entries(vector.expectedCells)) {
      expect(saleReturnIncomingCells(after)[Number(column)], `${vector.id} cell${column}`).toBe(
        expected,
      );
    }
    expect(before).toEqual(snapshot);
    expectPreserved(before, after);
  });

  it('recomputes percentage on an equal manual total outside the residual mismatch guard (5111–5115)', () => {
    const before = state({
      19: '10.00',
      49: '10.00',
      21: '10.00',
      66: '10.00',
      23: '2.00',
      58: '2.00',
      24: '20.00',
      27: '10.00',
    });
    const after = applied(reduceSaleReturnIncoming(before, leave(36, '130'), policy));
    expect(saleReturnIncomingCells(after)).toMatchObject({
      20: '100.00',
      21: '20.000',
      66: '10.00',
      23: '2.00',
      58: '2.00',
      24: '20.00',
      36: '130.00',
      38: '130.00',
    });
    expectPreserved(before, after);
  });

  it('uses original manual-total text even when its formatted cell equals computed total (5077/5108)', () => {
    const before = state({
      19: '10.00',
      49: '10.00',
      23: '2.00',
      58: '2.00',
      24: '20.00',
      27: '10.00',
    });
    const event = leave(36, '130.004');
    const after = applied(reduceSaleReturnIncoming(before, event, policy));
    expect(saleReturnIncomingCells(after)).toMatchObject({
      24: '20.00',
      23: '2.00',
      58: '2',
      36: '130.00',
      38: '130.00',
    });
    expect(after.journal[0]?.event).toMatchObject({ column: 36, text: '130.004' });
    expect(event.text).toBe('130.004');
  });

  it('clearing a changed labour rate clears labour while zero item rate retains manual metal (4941/4969)', () => {
    const before = state({ 20: '77.37', 23: '2.00', 58: '2.00', 24: '20.00' });
    const after = applied(
      reduceSaleReturnIncoming(before, leave(23, ''), { ...policy, generateLabourRate: true }),
    );
    expect(saleReturnIncomingCells(after)).toMatchObject({
      19: '0.00',
      20: '77.37',
      23: '0.00',
      58: '0.00',
      24: '0.00',
      36: '77.37',
      38: '77.37',
      67: '0',
    });
  });

  it('preserves metal when nonzero basis and pieces cancel in the literal sum guard (4941)', () => {
    const before = state({ 12: '-2.000', 46: '-2.000', 18: '-2.000', 20: '77.37' });
    const after = applied(reduceSaleReturnIncoming(before, leave(19, '10'), policy));
    expect(saleReturnIncomingCells(after)).toMatchObject({
      9: '2',
      19: '10.00',
      49: '10.00',
      20: '77.37',
      36: '77.37',
      38: '77.37',
    });
  });

  it('K tax inversion uses gross rather than net or net+ghat (5142–5144)', () => {
    const before = state({
      10: '20.000',
      45: '20.000',
      20: '100.00',
      22: 'K',
      23: '2.00',
      58: '2.00',
      24: '50.00',
    });
    const after = applied(reduceSaleReturnIncoming(before, leave(37, '20'), policy));
    expect(saleReturnIncomingCells(after)).toMatchObject({
      12: '10.000',
      36: '150.00',
      38: '125.00',
      24: '25.00',
      23: '1250.00',
      58: '1250.00',
      67: '20.00',
    });
  });

  it('unknown labour type uses gross forward but no gross inverse in final tax (4992/5127–5150)', () => {
    const before = state({
      10: '20.000',
      45: '20.000',
      20: '100.00',
      22: 'X',
      23: '2.00',
      58: '2.00',
      24: '50.00',
    });
    const taxed = applied(reduceSaleReturnIncoming(before, leave(37, '20'), policy));
    expect(saleReturnIncomingCells(taxed)).toMatchObject({
      36: '150.00',
      38: '125.00',
      24: '25.00',
      23: '2.00',
      58: '2.00',
    });
    const forward = applied(reduceSaleReturnIncoming(before, leave(23, '3'), policy));
    expect(saleReturnIncomingCells(forward)).toMatchObject({ 24: '60.00', 23: '3.00', 58: '3.00' });
  });

  it('unknown labour generation and manual-total inversion use gross (5017/5105)', () => {
    const before = state({
      10: '20.000',
      45: '20.000',
      22: 'X',
      23: '2.00',
      58: '2.00',
      24: '20.00',
    });
    const generated = applied(
      reduceSaleReturnIncoming(before, leave(24, '50'), { ...policy, generateLabourRate: true }),
    );
    expect(saleReturnIncomingCells(generated)).toMatchObject({
      23: '2.50',
      58: '2.50',
      24: '50.00',
    });
    const total = applied(reduceSaleReturnIncoming(before, leave(36, '50'), policy));
    expect(saleReturnIncomingCells(total)).toMatchObject({
      23: '2.50',
      58: '2.5',
      24: '50.00',
      36: '50.00',
    });
  });

  it('uses distinct half-up cell formatting and configured half-even tag rounding', () => {
    const before = state({
      10: '1.000',
      45: '1.000',
      12: '1.000',
      46: '1.000',
      18: '1.000',
      22: 'G',
      31: '0.625',
    });
    const after = applied(reduceSaleReturnIncoming(before, leave(27, '-0.125'), policy));
    expect(saleReturnIncomingCells(after)).toMatchObject({
      27: '-0.13',
      31: '0.625',
      32: '0.62',
      36: '-0.13',
      38: '-0.13',
    });
  });

  it('keeps low integer digits in a product beyond default Decimal precision and does not mutate global configuration', () => {
    const before = state({
      10: '1234567890123.456',
      45: '1234567890123.456',
      12: '1234567890123.456',
      46: '1234567890123.456',
      18: '1234567890123.456',
    });
    const snapshot = structuredClone(before);
    const savedPrecision = Decimal.precision;
    const savedRounding = Decimal.rounding;
    try {
      Decimal.set({ precision: 7, rounding: Decimal.ROUND_DOWN });
      const after = applied(
        reduceSaleReturnIncoming(before, leave(19, '9876543210987.65'), policy),
      );
      // Exact independent arithmetic: product12193263113702166395214191.31840, then source E0/F2.
      expect(saleReturnIncomingCells(after)).toMatchObject({
        20: '12193263113702166395214191.00',
        36: '12193263113702166395214191.00',
        38: '12193263113702166395214191.00',
      });
      expect(Decimal.precision).toBe(7);
      expect(Decimal.rounding).toBe(Decimal.ROUND_DOWN);
      expectPreserved(before, after);
    } finally {
      Decimal.set({ precision: savedPrecision, rounding: savedRounding });
    }
    expect(before).toEqual(snapshot);
  });

  it('preserves exact imported monetary values on text commits and records immutable events without calculations', () => {
    const before = state({
      20: '9999999999999999.99',
      24: '0.000000000000000001',
      36: '9999999999999999.99',
      38: '9999999999999999.99',
    });
    const event = leave(8, '  HUID  ');
    const eventPolicy = { ...policy };
    const result = reduceSaleReturnIncoming(before, event, eventPolicy);
    const after = applied(result);
    expect(result.aggregateRequired).toBe(false);
    expect(saleReturnIncomingCells(after)).toMatchObject({
      8: '  HUID  ',
      20: '9999999999999999.99',
      24: '0.000000000000000001',
    });
    event.text = 'CHANGED';
    event.context.currentRow = 9;
    eventPolicy.saleAmountType = 'F';
    expect(after.journal[0]).toMatchObject({
      event: { text: '  HUID  ', context: { currentRow: 1 } },
      calculated: false,
      policy: { saleAmountType: 'N' },
    });
    expect(Object.isFrozen(after.journal)).toBe(true);
    expect(Object.isFrozen(after.journal[0]?.event)).toBe(true);
    expectPreserved(before, after);
  });

  it.each([
    'clearing',
    'header-row',
    'editor-hidden',
    'column-hidden',
    'unsupported-column',
  ] as const)('returns the identical full state and journal for %s', (kind) => {
    const before = applied(reduceSaleReturnIncoming(state(), leave(8, 'FIRST'), policy));
    const snapshot = structuredClone(before);
    const event = leave(kind === 'unsupported-column' ? 69 : 19, 'not a number');
    if (kind === 'clearing') event.context.clearing = true;
    if (kind === 'header-row') event.context.currentRow = 0;
    if (kind === 'editor-hidden') event.context.editorVisible = false;
    if (kind === 'column-hidden') event.context.committedColumnWidth = 0;
    const result = reduceSaleReturnIncoming(before, event, policy);
    expect(result.status).toBe('skipped');
    expect(result.state).toBe(before);
    expect(result.state.journal).toBe(before.journal);
    expect(result.aggregateRequired).toBe(false);
    expect(before).toEqual(snapshot);
  });

  it.each([
    'invalid-text',
    'input-range',
    'row-identity',
    'missing-width',
    'invalid-policy',
    'generation-denominator',
    'tax-denominator',
    'late-tax-denominator',
  ] as const)('rejects %s without partial cells, cache or journal changes', (kind) => {
    const cells: Record<number, string> =
      kind === 'generation-denominator'
        ? { 9: '0', 22: 'P', 23: '2.00', 58: '2.00', 24: '10.00' }
        : kind === 'late-tax-denominator'
          ? {
              12: '1.000',
              46: '1.000',
              15: '-1.000',
              20: '100.00',
              23: '2.00',
              58: '2.00',
              24: '50.00',
            }
          : {};
    const before = applied(reduceSaleReturnIncoming(state(cells), leave(8, 'FIRST'), policy));
    const snapshot = structuredClone(before);
    const event = leave(27, '0');
    const p = { ...policy };
    if (kind === 'invalid-text') event.text = '12abc';
    if (kind === 'input-range') event.text = '1' + '0'.repeat(36);
    if (kind === 'row-identity') event.rowIdentity = 'other-row';
    if (kind === 'missing-width') {
      p.saleAmountType = 'F';
      p.fineColumnWidth = null;
    }
    if (kind === 'invalid-policy') p.labourRoundingDecimals = -1;
    if (kind === 'generation-denominator') p.generateLabourRate = true;
    if (kind === 'tax-denominator') {
      event.column = 37;
      event.text = '-100';
    }
    if (kind === 'late-tax-denominator') {
      event.column = 37;
      event.text = '20';
    }
    const result = reduceSaleReturnIncoming(before, event, p);
    expect(result.status).toBe('rejected');
    if (result.status !== 'rejected') throw new Error(kind);
    expect(result.state).toBe(before);
    expect(result.state.journal).toBe(before.journal);
    expect(result.aggregateRequired).toBe(false);
    expect(result.attemptedEvent).toEqual(event);
    expect(result.diagnostic.recoverable).toBe(true);
    expect(before).toEqual(snapshot);
  });

  it('contains a malformed leave context as a recoverable invalid event instead of throwing', () => {
    const before = state();
    const snapshot = structuredClone(before);
    const event = { ...leave(19, '100'), context: null } as unknown as SaleReturnIncomingEvent;
    const result = reduceSaleReturnIncoming(before, event, policy);
    expect(result.status).toBe('rejected');
    if (result.status !== 'rejected') throw new Error('Expected invalid event');
    expect(result.diagnostic.code).toBe('invalid-event');
    expect(result.diagnostic.recoverable).toBe(true);
    expect(result.attemptedEvent).toEqual(event);
    expect(result.state).toBe(before);
    expect(before).toEqual(snapshot);
  });
});
