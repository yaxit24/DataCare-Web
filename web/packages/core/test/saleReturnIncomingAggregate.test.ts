import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { Decimal } from 'decimal.js';
import { describe, expect, it } from 'vitest';
import {
  aggregateSaleReturnIncoming,
  calculateSaleReturnBill,
  createSaleReturnIncomingAggregateState,
  reduceSaleReturnIncomingAggregate,
  SALE_RETURN_INCOMING_AGGREGATE_COLUMNS,
  type SaleReturnBillContext,
  type SaleReturnBillState,
  type SaleReturnIncomingAggregateContext,
  type SaleReturnIncomingAggregateInput,
  type SaleReturnIncomingAggregateRow,
  type SaleReturnIncomingTotalsState,
} from '../src/saleReturnIncomingAggregate.js';
import type {
  SaleReturnIncomingEvent,
  SaleReturnIncomingPolicy,
} from '../src/saleReturnIncoming.js';

interface Fixtures {
  aggregateVectors: Array<{
    id: string;
    rows: SaleReturnIncomingAggregateRow[];
    previous: SaleReturnIncomingTotalsState;
    upDown: boolean;
    expected: { status: 'applied' | 'skipped'; state: SaleReturnIncomingTotalsState };
  }>;
  billVectors: Array<{
    id: string;
    previous: SaleReturnBillState;
    incomingTotal38: string;
    outgoingTotal24: string;
    context: SaleReturnBillContext;
    expected: { status: 'applied'; state: SaleReturnBillState; taxRecalculated: boolean };
  }>;
  compositeVectors: Array<{
    id: string;
    input: SaleReturnIncomingAggregateInput;
    rowPolicy: SaleReturnIncomingPolicy;
    context: SaleReturnIncomingAggregateContext;
    steps: Array<{
      event: SaleReturnIncomingEvent;
      expected: {
        visible: Readonly<Record<number, string>>;
        caches: Readonly<Record<number, string>>;
        totals: SaleReturnIncomingTotalsState;
        bill: SaleReturnBillState;
        rowCalculated: boolean;
        aggregateApplied: boolean;
        billApplied: boolean;
        taxRecalculated: boolean;
      };
    }>;
    finalOnlyIncorrectPaymentTotal: string;
  }>;
}
const bytes = readFileSync(
  new URL('./fixtures/sale-return-incoming-aggregate.v1.json', import.meta.url),
);
const fixtures = JSON.parse(bytes.toString('utf8')) as Fixtures;
const j1 = fixtures.compositeVectors[0]!;
const clone = <T>(value: T): T => structuredClone(value);
function freeze<T>(value: T): T {
  if (value && typeof value === 'object') {
    Object.values(value).forEach(freeze);
    Object.freeze(value);
  }
  return value;
}
function assertFrozen(value: unknown): void {
  if (value && typeof value === 'object') {
    expect(Object.isFrozen(value)).toBe(true);
    Object.values(value).forEach(assertFrozen);
  }
}
function ready(input: SaleReturnIncomingAggregateInput = clone(j1.input)) {
  const result = createSaleReturnIncomingAggregateState(input);
  expect(result.status).toBe('ready');
  if (result.status !== 'ready') throw new Error(JSON.stringify(result.diagnostic));
  return result.state;
}
function event(
  column = 27,
  text = '1',
  currentRow = 1,
): Extract<SaleReturnIncomingEvent, { kind: 'leaveCell' }> {
  return {
    kind: 'leaveCell',
    rowIdentity: 'j1-source-row',
    column,
    text,
    context: { currentRow, clearing: false, editorVisible: true, committedColumnWidth: 1000 },
  };
}
const setVisible = (row: SaleReturnIncomingAggregateRow, column: number, value: string) => ({
  ...row,
  state: { ...row.state, visible: { ...row.state.visible, [column]: value } },
});

describe('independent primary Return aggregate and bill fixtures', () => {
  it('pins the literal fixture authored before implementation inspection or execution', () => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      '97001a2719f491e50c3b1b9d31c96a822b243b9edd69bcd8b767b79e6b3231b5',
    );
    expect(SALE_RETURN_INCOMING_AGGREGATE_COLUMNS).toEqual([
      { column: 9, places: 0 },
      { column: 10, places: 3 },
      { column: 11, places: 3 },
      { column: 12, places: 3 },
      { column: 15, places: 3 },
      { column: 18, places: 3 },
      { column: 20, places: 2 },
      { column: 24, places: 2 },
      { column: 27, places: 2 },
      { column: 42, places: 3 },
      { column: 28, places: 2 },
      { column: 36, places: 2 },
      { column: 38, places: 2 },
      { column: 35, places: 2 },
    ]);
  });
  for (const v of fixtures.aggregateVectors) {
    it(`running fold: ${v.id}`, () => {
      const input = freeze(clone(v));
      const before = clone(input);
      const result = aggregateSaleReturnIncoming(input.rows, input.previous, input.upDown);
      expect(result.status).toBe(v.expected.status);
      expect(result.state).toEqual(v.expected.state);
      expect(input).toEqual(before);
      assertFrozen(result.state);
      if (result.status === 'skipped') expect(result.state).toBe(input.previous);
    });
  }
  for (const v of fixtures.billVectors) {
    it(`bill state: ${v.id}`, () => {
      const input = freeze(clone(v));
      const before = clone(input);
      const result = calculateSaleReturnBill(
        input.previous,
        input.incomingTotal38,
        input.outgoingTotal24,
        input.context,
      );
      expect(result).toEqual(v.expected);
      expect(input).toEqual(before);
      assertFrozen(result.state);
    });
  }
  it('retains exact low cents independently of ambient Decimal precision', () => {
    const before = Decimal.precision;
    try {
      Decimal.set({ precision: 7 });
      const v = fixtures.aggregateVectors.find((x) => x.id === 'large-exact-cents')!;
      expect(aggregateSaleReturnIncoming(v.rows, v.previous, false).state).toEqual(
        v.expected.state,
      );
    } finally {
      Decimal.set({ precision: before });
    }
  });
  it('retains the one-unit bill residual after subtracting a large tender at low ambient precision', () => {
    const ambientPrecision = Decimal.precision;
    const previous = clone(fixtures.billVectors[0]!.previous);
    (previous.matrix[6] as string[])[3] = '99999999999999999999999998.00';
    const input = freeze(previous);
    const before = clone(input);
    try {
      Decimal.set({ precision: 7 });
      const result = calculateSaleReturnBill(
        input,
        '99999999999999999999999999.01',
        '0',
        fixtures.billVectors[0]!.context,
      );
      expect(result.status).toBe('applied');
      if (result.status !== 'applied') throw new Error(JSON.stringify(result.diagnostic));
      expect(result.state.incomingRounded).toBe('99999999999999999999999999.00');
      expect(result.state.outgoingRounded).toBe('0.00');
      expect(result.state.oldNetAmt).toBe('99999999999999999999999999');
      expect(result.state.matrix[3]![3]).toBe('99999999999999999999999999.00');
      expect(result.state.matrix[8]![3]).toBe('1.00');
      expect(result.state.closing).toEqual({
        status: 'resolved',
        amount: '1',
        label: '1.00 : Cr Amt',
        color: 'blue',
      });
      expect(input).toEqual(before);
    } finally {
      Decimal.set({ precision: ambientPrecision });
    }
  });
});

describe('complete-state construction and event phase composition', () => {
  it('constructs a detached frozen observation without calculating or normalizing raw saved values', () => {
    const input = clone(j1.input);
    const before = clone(input);
    const state = ready(input);
    expect({
      raw: state.raw,
      rows: state.rows,
      totals: state.totals,
      bill: state.bill,
      outgoingTotal24: state.outgoingTotal24,
    }).toEqual(before);
    expect(state.journal).toEqual([]);
    expect(state.rows[0]!.state.journal).toEqual([]);
    assertFrozen(state);
    (input.raw as Record<string, string | null>).TAX_AMT = '999.00';
    (input.bill.matrix[2] as string[])[3] = '999.00';
    (input.rows[0]!.state.visible as Record<number, string>)[27] = '999.00';
    expect(state.raw).toEqual(before.raw);
    expect(state.bill).toEqual(before.bill);
    expect(state.rows).toEqual(before.rows);
  });
  it('J1 interleaves each genuine row event, aggregate and bill cache before the next event', () => {
    let state = ready();
    const original = state;
    for (const [index, step] of j1.steps.entries()) {
      const attempted = freeze(clone(step.event));
      const result = reduceSaleReturnIncomingAggregate(state, attempted, j1.rowPolicy, j1.context);
      expect(result.status).toBe('applied');
      if (result.status !== 'applied') throw new Error(JSON.stringify(result));
      expect(result.aggregateApplied).toBe(true);
      expect(result.billApplied).toBe(true);
      expect(result.state.rows[0]!.state.visible).toEqual(step.expected.visible);
      expect(result.state.rows[0]!.state.caches).toEqual(step.expected.caches);
      expect(result.state.totals).toEqual(step.expected.totals);
      expect(result.state.bill).toEqual(step.expected.bill);
      expect(result.state.raw).toEqual(original.raw);
      expect(result.state.journal).toHaveLength(index + 1);
      expect(result.state.rows[0]!.state.journal).toHaveLength(index + 1);
      expect(result.state.journal[index]).toEqual({
        event: step.event,
        rowPolicy: j1.rowPolicy,
        context: j1.context,
        rowCalculated: true,
        aggregateApplied: true,
        billApplied: true,
        taxRecalculated: true,
      });
      assertFrozen(result.state);
      state = result.state;
    }
    expect(state.rows[0]!.state.visible).toEqual(original.rows[0]!.state.visible);
    expect(state.bill.matrix[3]![3]).toBe('121.00');
    expect(original.bill.matrix[3]![3]).toBe(j1.finalOnlyIncorrectPaymentTotal);
    expect(original.journal).toEqual([]);
  });
  it('records a text-only event without aggregate, bill, or numeric cache changes', () => {
    const state = ready();
    const result = reduceSaleReturnIncomingAggregate(
      state,
      event(3, 'Retained draft description'),
      j1.rowPolicy,
      j1.context,
    );
    expect(result.status).toBe('applied');
    if (result.status !== 'applied') throw new Error(JSON.stringify(result));
    expect(result.aggregateApplied).toBe(false);
    expect(result.billApplied).toBe(false);
    expect(result.state.rows[0]!.state.visible[3]).toBe('Retained draft description');
    expect(result.state.rows[0]!.state.caches).toEqual(state.rows[0]!.state.caches);
    expect(result.state.totals).toEqual(state.totals);
    expect(result.state.bill).toEqual(state.bill);
    expect(result.state.journal[0]).toMatchObject({
      rowCalculated: false,
      aggregateApplied: false,
      billApplied: false,
      taxRecalculated: false,
    });
  });
  it('does not deduplicate a genuine same-value numeric leave event', () => {
    const state = ready();
    const result = reduceSaleReturnIncomingAggregate(
      state,
      event(27, '0.00'),
      j1.rowPolicy,
      j1.context,
    );
    expect(result.status).toBe('applied');
    if (result.status !== 'applied') throw new Error(JSON.stringify(result));
    expect(result.aggregateApplied).toBe(true);
    expect(result.billApplied).toBe(true);
    expect(result.state.rows[0]!.state.visible).toEqual(state.rows[0]!.state.visible);
    expect(result.state.bill.matrix[2]![3]).toBe('7.00');
    expect(result.state.journal).toHaveLength(1);
  });
  it('UpDown skips only the aggregate while a calculated row still bills the retained total', () => {
    const input = clone(j1.input);
    (input.totals.cells as Record<number, string>)[38] = '80.00';
    const state = ready(input);
    const result = reduceSaleReturnIncomingAggregate(state, event(), j1.rowPolicy, {
      ...j1.context,
      upDown: true,
    });
    expect(result.status).toBe('applied');
    if (result.status !== 'applied') throw new Error(JSON.stringify(result));
    expect(result.aggregateApplied).toBe(false);
    expect(result.billApplied).toBe(true);
    expect(result.state.rows[0]!.state.visible[38]).toBe('111.00');
    expect(result.state.totals).toBe(state.totals);
    expect(result.state.bill.incomingRounded).toBe('80.00');
    expect(result.state.bill.matrix[2]![3]).toBe('8.00');
    expect(result.state.bill.matrix[3]![3]).toBe('88.00');
  });
  for (const [name, attempted] of [
    ['row-zero', event(27, '1', 0)],
    [
      'clearing',
      {
        ...event(),
        context: {
          ...(event() as Extract<SaleReturnIncomingEvent, { kind: 'leaveCell' }>).context,
          clearing: true,
        },
      },
    ],
    [
      'hidden-editor',
      {
        ...event(),
        context: {
          ...(event() as Extract<SaleReturnIncomingEvent, { kind: 'leaveCell' }>).context,
          editorVisible: false,
        },
      },
    ],
    [
      'hidden-column',
      {
        ...event(),
        context: {
          ...(event() as Extract<SaleReturnIncomingEvent, { kind: 'leaveCell' }>).context,
          committedColumnWidth: 0,
        },
      },
    ],
  ] as const) {
    it(`preserves identical entire state/journals on source guard ${name}`, () => {
      const state = ready();
      const result = reduceSaleReturnIncomingAggregate(state, attempted, j1.rowPolicy, {
        ...j1.context,
        taxRoundingDecimals: -1,
      });
      expect(result.status).toBe('skipped');
      expect(result.state).toBe(state);
      expect(state.journal).toEqual([]);
    });
  }
  it('refuses active ordinal mismatch without journaling the attempt', () => {
    const state = ready();
    const attempted = event(27, '1', 2);
    const result = reduceSaleReturnIncomingAggregate(state, attempted, j1.rowPolicy, j1.context);
    expect(result.status).toBe('rejected');
    expect(result.state).toBe(state);
    if (result.status === 'rejected') expect(result.attemptedEvent).toEqual(attempted);
  });
  it('refuses a text-only c0 edit that would invalidate the saved ordinal invariant', () => {
    const state = ready();
    const result = reduceSaleReturnIncomingAggregate(
      state,
      event(0, '99'),
      j1.rowPolicy,
      j1.context,
    );
    expect(result.status).toBe('rejected');
    expect(result.state).toBe(state);
    if (result.status === 'rejected') expect(result.diagnostic.code).toBe('invalid-row-order');
    expect(state.rows[0]!.state.visible[0]).toBe('1');
    expect(state.rows[0]!.state.journal).toEqual([]);
  });
});

describe('recoverable profile and structural containment', () => {
  for (const bad of [
    'NaN',
    'Infinity',
    '1e3',
    '12tail',
    '\u00a012\u00a0',
    '12\n',
    '12\r',
    '12\u2028',
  ]) {
    it(`rejects a read numeric cell ${JSON.stringify(bad)} without changing totals`, () => {
      const v = fixtures.aggregateVectors[0]!;
      const previous = freeze(clone(v.previous));
      const result = aggregateSaleReturnIncoming(
        [setVisible(clone(v.rows[0]!), 20, bad)],
        previous,
        false,
      );
      expect(result.status).toBe('rejected');
      expect(result.state).toBe(previous);
      if (result.status === 'rejected') expect(result.diagnostic.code).toBe('invalid-decimal');
    });
  }
  it('accepts ASCII spaces while retaining raw text and exact formatted output', () => {
    const v = fixtures.aggregateVectors[0]!;
    const rows = [setVisible(clone(v.rows[0]!), 20, '  +1.20  ')];
    const result = aggregateSaleReturnIncoming(rows, v.previous, false);
    expect(result.status).toBe('applied');
    expect(result.state.cells[20]).toBe('1.20');
    expect(rows[0]!.state.visible[20]).toBe('  +1.20  ');
  });
  it('rejects a valid36-digit integer plus cents result that no later consumer can represent', () => {
    const v = fixtures.aggregateVectors[0]!;
    const rows = [
      setVisible(clone(v.rows[0]!), 20, '123456789012345678901234567890123456'),
      setVisible(clone(v.rows[1]!), 20, '0.01'),
    ];
    const previous = freeze(clone(v.previous));
    const result = aggregateSaleReturnIncoming(rows, previous, false);
    expect(result.status).toBe('rejected');
    expect(result.state).toBe(previous);
    if (result.status === 'rejected') expect(result.diagnostic.code).toBe('unsupported-precision');
  });
  it('rolls back the selected row and both journals when another row fails during the aggregate', () => {
    const input = clone(j1.input);
    const second = setVisible(
      {
        ordinal: 2,
        state: {
          ...clone(input.rows[0]!.state),
          rowIdentity: 'second-row',
          visible: { ...input.rows[0]!.state.visible, 0: '2' },
        },
      },
      38,
      'unread-invalid-net',
    );
    const state = ready({ ...input, rows: [...input.rows, second] });
    const result = reduceSaleReturnIncomingAggregate(state, event(), j1.rowPolicy, j1.context);
    expect(result.status).toBe('rejected');
    expect(result.state).toBe(state);
    if (result.status === 'rejected') expect(result.diagnostic.code).toBe('invalid-decimal');
    expect(state.rows[0]!.state.visible[27]).toBe('0.00');
    expect(state.rows.every((row) => row.state.journal.length === 0)).toBe(true);
    expect(state.journal).toEqual([]);
  });
  it('rolls back a successful row/aggregate when a later-used tender is invalid', () => {
    const input = clone(j1.input);
    (input.bill.matrix[6] as string[])[3] = 'invalid-cash';
    const state = ready(input);
    const attempted = event();
    const result = reduceSaleReturnIncomingAggregate(state, attempted, j1.rowPolicy, j1.context);
    expect(result.status).toBe('rejected');
    expect(result.state).toBe(state);
    if (result.status === 'rejected') {
      expect(result.diagnostic.code).toBe('invalid-decimal');
      expect(result.attemptedEvent).toEqual(attempted);
    }
    expect(state.journal).toEqual([]);
    expect(state.rows[0]!.state.journal).toEqual([]);
  });
  it('recovers from the row kernel zero denominator without partial composite state', () => {
    const state = ready();
    const attempted = event(37, '-100');
    const result = reduceSaleReturnIncomingAggregate(state, attempted, j1.rowPolicy, j1.context);
    expect(result.status).toBe('rejected');
    expect(result.state).toBe(state);
    if (result.status === 'rejected') {
      expect(result.diagnostic.code).toBe('row-calculation-rejected');
      expect(result.attemptedEvent).toEqual(attempted);
    }
  });
  for (const invalid of [-1, 6, 1.5, Number.NaN]) {
    it(`rejects unresolved/unsupported tax rounding ${String(invalid)}`, () => {
      const v = fixtures.billVectors[0]!;
      const previous = freeze(clone(v.previous));
      const result = calculateSaleReturnBill(previous, v.incomingTotal38, v.outgoingTotal24, {
        ...v.context,
        taxRoundingDecimals: invalid,
      });
      expect(result.status).toBe('rejected');
      expect(result.state).toBe(previous);
    });
  }
  for (const kind of [
    'missing-total-column',
    'sparse-matrix',
    'sparse-rows',
    'duplicate-identity',
    'wrong-ordinal',
    'wrong-visible-ordinal',
    'missing-read-column',
  ] as const) {
    it(`does not construct incomplete or inconsistent state: ${kind}`, () => {
      const input = clone(j1.input);
      if (kind === 'missing-total-column')
        delete (input.totals.cells as Record<number, string>)[70];
      if (kind === 'sparse-matrix') delete (input.bill.matrix[6] as string[])[3];
      if (kind === 'sparse-rows') (input.rows as SaleReturnIncomingAggregateRow[]).length = 2;
      if (kind === 'duplicate-identity')
        (input.rows as SaleReturnIncomingAggregateRow[]).push({
          ordinal: 2,
          state: {
            ...clone(input.rows[0]!.state),
            visible: { ...input.rows[0]!.state.visible, 0: '2' },
          },
        });
      if (kind === 'wrong-ordinal')
        (input.rows as SaleReturnIncomingAggregateRow[])[0] = { ...input.rows[0]!, ordinal: 2 };
      if (kind === 'wrong-visible-ordinal')
        (input.rows[0]!.state.visible as Record<number, string>)[0] = '17';
      if (kind === 'missing-read-column')
        delete (input.rows[0]!.state.visible as Record<number, string>)[42];
      expect(createSaleReturnIncomingAggregateState(input).status).toBe('unsupported');
    });
  }
});
