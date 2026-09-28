import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import {
  createSaleReturnIncomingState,
  reduceSaleReturnIncoming,
  saleReturnIncomingCells,
  type SaleReturnIncomingCells,
  type SaleReturnIncomingEvent,
  type SaleReturnIncomingPolicy,
  type SaleReturnIncomingState,
} from '../src/saleReturnIncoming.js';
import { decimalCellText, roundHalfEvenDecimal } from '../src/money.js';

// Byte-identical copies of the independently frozen round7 artifacts. Local
// fixtures keep these core tests runnable without the extracted desktop folder.
const sourceBytes = readFileSync(
  new URL('./fixtures/saleReturnIncoming.independent.json', import.meta.url),
);
const widthBytes = readFileSync(
  new URL('./fixtures/saleReturnIncoming.widths.json', import.meta.url),
);
interface Vector {
  id: string;
  initialCells: Record<number, string>;
  settings?: Partial<SourceSettings>;
  columnWidths?: Record<number, number>;
  event: { kind: string; column?: number; text?: string; activeColumn?: number };
  expectedCells: Record<number, string>;
  subsequentEvents?: Array<{ event: Vector['event']; expectedCells: Record<number, string> }>;
}
interface SourceSettings {
  MsSlAmtType: string;
  MsLbrRof: number;
  MsLbrWithGht: string;
  MsLbrGen: string;
}
const independent = JSON.parse(sourceBytes.toString()) as {
  baseCells: Record<number, string>;
  baseSettings: SourceSettings;
  vectors: Vector[];
};
const widthVectors = JSON.parse(widthBytes.toString()) as {
  baseSettingsOverrides: Partial<SourceSettings>;
  baseColumnWidths: Record<number, number>;
  vectors: Vector[];
};
const identity = JSON.stringify([
  'TENANT',
  'COMP',
  'LC01',
  '2024',
  'R71',
  '00001',
  '17',
  '500001.125',
]);
const raw = {
  SR_NO: '17',
  OLD_SRNO: '31',
  VCH_SRNO: '500001.125',
  VCH_TIME: '2024-02-29T12:13:14.123456',
  ITM_AMT: '9999999999999999.99',
  HM_ID2: null,
  ITM_REMARK: '',
  ISU_YEAR: '2023',
  ISU_BOOK: 'SAL',
  ISU_VCH_NO: '00042',
};
const policy: SaleReturnIncomingPolicy = {
  saleAmountType: 'N',
  labourRoundingDecimals: 2,
  labourIncludesGhat: true,
  generateLabourRate: false,
  fineColumnWidth: null,
};
function state(cells: SaleReturnIncomingCells = {}, cacheMode: 'saved' | 'provided' = 'provided') {
  return createSaleReturnIncomingState({
    rowIdentity: identity,
    raw,
    cells: { ...independent.baseCells, ...cells },
    cacheMode,
  });
}
function leave(
  column: number,
  text: string,
): Extract<SaleReturnIncomingEvent, { kind: 'leaveCell' }> {
  return {
    kind: 'leaveCell',
    rowIdentity: identity,
    column,
    text,
    context: { currentRow: 1, clearing: false, editorVisible: true, committedColumnWidth: 1000 },
  };
}
function apply(
  current: SaleReturnIncomingState,
  event: SaleReturnIncomingEvent,
  settings = policy,
) {
  const result = reduceSaleReturnIncoming(current, event, settings);
  expect(result.status, result.status === 'rejected' ? JSON.stringify(result.diagnostic) : '').toBe(
    'applied',
  );
  return result.state;
}
function vectorEvent(
  event: Vector['event'],
  widths?: Record<number, number>,
): SaleReturnIncomingEvent {
  if (event.kind === 'sourceSelectionAfterCopy')
    return {
      kind: 'calculateAfterCopy',
      rowIdentity: identity,
      activeColumn: event.activeColumn!,
      editorText: event.text!,
      cause: 'sourceSelection',
    };
  const result = leave(event.column!, event.text!);
  if (widths) result.context.committedColumnWidth = widths[event.column!] ?? 1000;
  return result;
}
function vectorPolicy(
  settings: Partial<SourceSettings> = {},
  widths?: Record<number, number>,
): SaleReturnIncomingPolicy {
  const p = { ...independent.baseSettings, ...settings };
  return {
    saleAmountType: p.MsSlAmtType,
    labourRoundingDecimals: p.MsLbrRof,
    labourIncludesGhat: p.MsLbrWithGht !== 'N',
    generateLabourRate: p.MsLbrGen === 'Y',
    fineColumnWidth: widths?.[18] ?? null,
  };
}

describe('immutable independent source expectations (not executable desktop acceptance)', () => {
  it('pins the independently created arithmetic and IL width artifacts without rewriting them', () => {
    expect(createHash('sha256').update(sourceBytes).digest('hex')).toBe(
      'ad1184e6bb7f7256e42e85b5469ea3152404fba25566465389bc6a7ba4367527',
    );
    expect(createHash('sha256').update(widthBytes).digest('hex')).toBe(
      '3c0bef2a5aa86fca83d8c0e98b56e36c553595f2b941a06642409ce7e631d309',
    );
    expect(independent.vectors).toHaveLength(35);
    expect(widthVectors.vectors).toHaveLength(8);
  });
  for (const vector of independent.vectors) {
    it(vector.id, () => {
      const before = state(
        vector.initialCells,
        vector.event.kind === 'savedHydration' ? 'saved' : 'provided',
      );
      const snapshot = JSON.stringify(before);
      const p = vectorPolicy(vector.settings);
      let after =
        vector.event.kind === 'savedHydration'
          ? before
          : apply(before, vectorEvent(vector.event), p);
      expect(saleReturnIncomingCells(after)).toMatchObject(vector.expectedCells);
      expect(JSON.stringify(before)).toBe(snapshot);
      expect(after.raw).toEqual(raw);
      for (const step of vector.subsequentEvents ?? []) {
        after = apply(after, vectorEvent(step.event), p);
        expect(saleReturnIncomingCells(after)).toMatchObject(step.expectedCells);
      }
    });
  }
  for (const vector of widthVectors.vectors) {
    it(vector.id, () => {
      const widths = { ...widthVectors.baseColumnWidths, ...vector.columnWidths };
      const before = state(vector.initialCells);
      const result = reduceSaleReturnIncoming(
        before,
        vectorEvent(vector.event, widths),
        vectorPolicy({ ...widthVectors.baseSettingsOverrides, ...vector.settings }, widths),
      );
      expect(result.status).toBe(widths[vector.event.column!] === 0 ? 'skipped' : 'applied');
      expect(saleReturnIncomingCells(result.state)).toMatchObject(vector.expectedCells);
      if (result.status === 'skipped') expect(result.state).toBe(before);
    });
  }
});

describe('Return-specific state, source cache order and recoverable boundaries', () => {
  it('keeps the raw snapshot, visible strings, eight caches and journal physically separate and frozen', () => {
    const input = { ...raw };
    const cells = { ...independent.baseCells, 20: '9999999999999999.99', 49: '9.9900' };
    const before = createSaleReturnIncomingState({
      rowIdentity: identity,
      raw: input,
      cells,
      cacheMode: 'provided',
    });
    input.ITM_AMT = '0';
    cells[20] = '0';
    expect(before.raw.ITM_AMT).toBe('9999999999999999.99');
    expect(before.visible[20]).toBe('9999999999999999.99');
    expect(before.visible[49]).toBeUndefined();
    expect(before.caches[49]).toBe('9.9900');
    expect(Object.isFrozen(before.raw)).toBe(true);
    expect(Object.isFrozen(before.visible)).toBe(true);
    expect(Object.isFrozen(before.caches)).toBe(true);
    const event = leave(3, '  exact text  ');
    const next = apply(before, event);
    event.text = 'mutated';
    event.context.editorVisible = false;
    expect(next.raw).toBe(before.raw);
    expect(next.visible[3]).toBe('  exact text  ');
    expect(next.journal[0]?.event).toMatchObject({
      text: '  exact text  ',
      context: { editorVisible: true },
    });
    expect(next.journal[0]?.calculated).toBe(false);
    expect(before.journal).toHaveLength(0);
  });
  it('hydrates malformed/large raw and visible saved values without parsing or repricing them', () => {
    const before = state(
      { 19: '9999999999999999.99', 20: '17.1700', 24: '', 42: 'unknown-slot' },
      'saved',
    );
    expect(before.caches[49]).toBe('9999999999999999.99');
    expect(before.visible[20]).toBe('17.1700');
    expect(before.visible[24]).toBe('');
    expect(before.visible[42]).toBe('unknown-slot');
    expect(before.journal).toEqual([]);
    expect(before.raw.VCH_TIME).toBe('2024-02-29T12:13:14.123456');
  });
  it('calculates large supported decimals without a Number cents roundtrip', () => {
    const next = apply(
      state({ 10: '1.000', 12: '1.000', 45: '1.000', 46: '1.000', 9: '1', 44: 'P' }),
      leave(19, '9999999999999999.99'),
    );
    expect(saleReturnIncomingCells(next)).toMatchObject({
      19: '9999999999999999.99',
      20: '10000000000000000.00',
      36: '10000000000000000.00',
    });
    expect(decimalCellText('9999999999999999.995', 2)).toBe('10000000000000000.00');
    expect(roundHalfEvenDecimal('9999999999999998.5', 0).toFixed()).toBe('9999999999999998');
    expect(decimalCellText('-1.005', 2)).toBe('-1.01');
  });
  it('clearing a changed labour rate clears labour amount while clearing item rate retains metal', () => {
    const next = apply(
      state({ 23: '10.00', 58: '10.00', 24: '100.00', 20: '77.37' }),
      leave(23, '0'),
    );
    expect(saleReturnIncomingCells(next)).toMatchObject({
      23: '0.00',
      58: '0.00',
      24: '0.00',
      20: '77.37',
      36: '77.37',
    });
  });
  it('preserves the source basis-plus-pieces cancellation guard', () => {
    const next = apply(state({ 9: '-10', 20: '77.37' }), leave(19, '100'));
    expect(saleReturnIncomingCells(next)).toMatchObject({ 19: '100.00', 20: '77.37', 36: '77.37' });
  });
  it('uses gross for the K tax inverse, independently of its generation/manual net-plus-ghat inverses', () => {
    const next = apply(
      state({
        10: '20.000',
        45: '20.000',
        12: '10.000',
        46: '10.000',
        22: 'K',
        23: '100.00',
        58: '100.00',
        24: '100.00',
      }),
      leave(37, '25'),
    );
    expect(saleReturnIncomingCells(next)).toMatchObject({
      36: '100.00',
      38: '80.00',
      24: '80.00',
      23: '4000.00',
      58: '4000.00',
    });
  });
  it('uses original manual editor precision instead of the rounded committed cell', () => {
    const next = apply(
      state({
        19: '10.00',
        49: '10.00',
        20: '100.00',
        23: '2.00',
        58: '2.00',
        24: '20.00',
        27: '10.00',
      }),
      leave(36, '130.004'),
    );
    expect(saleReturnIncomingCells(next)).toMatchObject({
      24: '20.00',
      23: '2.00',
      58: '2',
      36: '130.00',
      38: '130.00',
    });
  });
  it('does not blank a signed-zero residual at the strict source less-than-zero comparison', () => {
    const before = state({
      19: '10.00',
      49: '10.00',
      20: '100.00',
      23: '1.00',
      58: '1.00',
      24: '0.00',
    });
    const next = apply(before, leave(36, '99.999'));
    // Selected mathematical cell-format policy gives -0.00. The desktop's
    // exact formatted zero sign remains unmeasured, but Val(-0) < 0 is false.
    expect(saleReturnIncomingCells(next)).toMatchObject({
      24: '-0.00',
      23: '1.00',
      58: '1.00',
      36: '100.00',
      38: '100.00',
    });
    expect(next.raw).toBe(before.raw);
  });
  it('updates manual-total visible percentage even when editor equals computed total, retaining percentage cache', () => {
    const next = apply(
      state({
        19: '10.00',
        49: '10.00',
        20: '100.00',
        21: '10.00',
        66: '10.00',
        23: '2.00',
        58: '2.00',
        24: '20.00',
        27: '10.00',
      }),
      leave(36, '130'),
    );
    expect(saleReturnIncomingCells(next)).toMatchObject({
      21: '20.000',
      66: '10.00',
      24: '20.00',
      23: '2.00',
      36: '130.00',
    });
  });
  it.each([
    ['clear', { clearing: true }],
    ['header', { currentRow: 0 }],
    ['hidden editor', { editorVisible: false }],
    ['hidden column', { committedColumnWidth: 0 }],
  ])(
    'skips the %s leave guard without committing text or appending a journal',
    (_label, context) => {
      const before = state();
      const event = leave(19, 'bad');
      Object.assign(event.context, context);
      const result = reduceSaleReturnIncoming(before, event, { ...policy, saleAmountType: 'F' });
      expect(result).toMatchObject({ status: 'skipped', aggregateRequired: false });
      expect(result.state).toBe(before);
    },
  );
  it.each(['NaN', 'Infinity', '1e3', '1,234.00', '12x', '0x10', '1.2.3'])(
    'contains malformed decimal %s without partial mutation',
    (text) => {
      const before = state();
      const result = reduceSaleReturnIncoming(before, leave(19, text), policy);
      expect(result).toMatchObject({
        status: 'rejected',
        diagnostic: { code: 'invalid-decimal', recoverable: true },
      });
      expect(result.state).toBe(before);
      if (result.status === 'rejected') expect(result.attemptedEvent).toMatchObject({ text });
      expect(apply(result.state, leave(19, '10')).visible[20]).toBe('100.00');
    },
  );
  it.each([
    [{ 9: '0', 22: 'P', 24: '10.00' }, { generateLabourRate: true }, 27, '0'],
    [
      { 12: '1.000', 46: '1.000', 15: '-1.000', 24: '10.00' },
      { generateLabourRate: true },
      27,
      '0',
    ],
    [{ 24: '100.00' }, {}, 37, '-100'],
    [{ 28: '100.00' }, {}, 37, '-100'],
    [{ 9: '0', 22: 'P', 23: '1.00', 58: '1.00' }, {}, 36, '10'],
    [{ 12: '1.000', 46: '1.000', 15: '-1.000', 24: '100.00' }, {}, 37, '25'],
  ] as Array<[Record<number, string>, Partial<SaleReturnIncomingPolicy>, number, string]>)(
    'rejects an unguarded source zero denominator atomically (%j)',
    (cells, p, column, text) => {
      const before = state(cells);
      const json = JSON.stringify(before);
      const result = reduceSaleReturnIncoming(before, leave(column, text), { ...policy, ...p });
      expect(result).toMatchObject({
        status: 'rejected',
        diagnostic: { code: 'zero-denominator', recoverable: true },
      });
      expect(result.state).toBe(before);
      expect(JSON.stringify(before)).toBe(json);
    },
  );
  it('rejects unknown F width and missing event width without guessing a fine basis', () => {
    const before = state();
    expect(
      reduceSaleReturnIncoming(before, leave(19, '100'), { ...policy, saleAmountType: 'F' }),
    ).toMatchObject({ status: 'rejected', diagnostic: { code: 'missing-column-width' } });
    const event = leave(19, '100');
    event.context.committedColumnWidth = null;
    expect(reduceSaleReturnIncoming(before, event, policy)).toMatchObject({
      status: 'rejected',
      diagnostic: { code: 'missing-column-width' },
    });
  });
  it('rejects row identity mismatch, item admission, unsupported settings and precision explicitly', () => {
    const before = state();
    const event = leave(19, '100');
    event.rowIdentity = 'other';
    expect(reduceSaleReturnIncoming(before, event, policy)).toMatchObject({
      status: 'rejected',
      diagnostic: { code: 'row-identity-conflict' },
    });
    expect(reduceSaleReturnIncoming(before, leave(1, 'GOLD'), policy)).toMatchObject({
      status: 'rejected',
      diagnostic: { code: 'unsupported-item-admission' },
    });
    expect(
      reduceSaleReturnIncoming(before, leave(19, '1'), { ...policy, labourRoundingDecimals: -1 }),
    ).toMatchObject({ status: 'rejected', diagnostic: { code: 'invalid-policy' } });
    expect(
      reduceSaleReturnIncoming(
        before,
        leave(19, '999999999999999999999999999999999999999'),
        policy,
      ),
    ).toMatchObject({ status: 'rejected', diagnostic: { code: 'unsupported-precision' } });
  });
});
