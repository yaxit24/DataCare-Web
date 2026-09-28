import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { Decimal } from 'decimal.js';
import { describe, expect, it } from 'vitest';
import {
  SALE_RETURN_BILL_PROJECTION_VERSION,
  projectSavedSaleReturnBill,
  type SavedSaleReturnBillProjectionInput,
  type SaleReturnBillProjectionResult,
} from '../src/saleReturnBillProjection.js';

const fixtureBytes = readFileSync(
  new URL('./fixtures/sale-return-bill-projection.v1.json', import.meta.url),
);
const fixture = JSON.parse(fixtureBytes.toString()) as {
  input: SavedSaleReturnBillProjectionInput;
  expectedState: Extract<SaleReturnBillProjectionResult, { status: 'ready' }>['state'];
};
const directColumns = [
  'NET_AMT',
  'TOT_AMT',
  'CHQ_AMT',
  'CARD_AMT',
  'CASH_AMT',
  'RTN_NET_AMT',
  'TAX_PRC',
  'TAX_AMT',
  'RTN_TOT_AMT',
  'RTN_CHQ_AMT',
  'RTN_CARD_AMT',
  'RTN_CASH_AMT',
] as const;
const fnvColumns = ['KASAR_AMT', 'BILL_OS', 'RTN_KASAR_AMT', 'RTN_BILL_OS'] as const;
const textColumns = ['TAX_CODE', 'BANK_AC', 'CHQ_NO', 'CARD_AC'] as const;
function input(raw: Record<string, string | null> = {}): SavedSaleReturnBillProjectionInput {
  return { raw: { ...fixture.input.raw, ...raw }, labels: { ...fixture.input.labels } };
}
function ready(value: SavedSaleReturnBillProjectionInput = input()) {
  const result = projectSavedSaleReturnBill(value);
  expect(result.status).toBe('ready');
  if (result.status !== 'ready') throw new Error(JSON.stringify(result.diagnostics));
  return result;
}
function refused(value: SavedSaleReturnBillProjectionInput) {
  const result = projectSavedSaleReturnBill(value);
  expect(result.status).toBe('unsupported');
  if (result.status !== 'unsupported') throw new Error('Unexpected admitted projection');
  return result;
}

describe('saved Sale Return bill projection source contract', () => {
  it('pins the literal expected complete matrix authored before implementation', () => {
    expect(createHash('sha256').update(fixtureBytes).digest('hex')).toBe(
      '3a13171acfc68e79a8b2f12e1b3169d97c85c23851bda7fed81bce49707eea8c',
    );
    expect(SALE_RETURN_BILL_PROJECTION_VERSION).toBe('sale-return-bill-projection-v1');
    expect(ready().state).toEqual(fixture.expectedState);
  });

  it('retains unreconciled manual tax and both saved tender sides without callbacks', () => {
    const result = ready(
      input({
        NET_AMT: '40.6',
        RTN_NET_AMT: '200.6',
        TAX_PRC: '10.000',
        TAX_AMT: '7',
        RTN_TOT_AMT: '999',
        RTN_CASH_AMT: '400',
        TOT_AMT: '81',
        CASH_AMT: '55',
      }),
    );
    expect(result.state).toMatchObject({
      outgoingRounded: '40.60',
      incomingRounded: '200.60',
      oldNetAmt: '200.6',
      oldTaxPrc: '10',
    });
    expect(result.state.matrix[1]).toEqual(['Net Amt : ', '', '', '', '', '']);
    expect(result.state.matrix[2]?.slice(2, 5)).toEqual(['10.00', '7.00', '']);
    expect(result.state.matrix[3]?.slice(3, 5)).toEqual(['999.00', '81.00']);
    expect(result.state.matrix[6]?.slice(3, 5)).toEqual(['400.00', '55.00']);
    expect(result.raw.TAX_AMT).toBe('7');
  });

  it('keeps leading-zero identifiers, raw Float text, microseconds, NULL and blank intact', () => {
    const original = input();
    const before = structuredClone(original);
    const result = ready(original);
    expect(result.raw).toEqual(before.raw);
    expect(result.raw).not.toBe(original.raw);
    expect(result.state.matrix[2]?.[5]).toBe('0010');
    expect(result.state.matrix[4]?.[2]).toBe('000123');
    expect(result.state.matrix[4]?.[5]).toBe('0007');
    expect(result.state.matrix[5]?.[5]).toBe('0008');
    expect(result.raw.VCH_TIME).toBe('2024-07-02 12:34:56.123456');
    expect(result.raw.FLOAT_OBSERVATION).toBe('0.30000000000000004');
    expect(result.raw.UNUSED_HIDDEN).toBeNull();
    expect(result.raw.ORIGINAL_DESCRIPTION).toBe('');
    expect(original).toEqual(before);
  });

  it('detaches and freezes every returned mutable layer while leaving the caller mutable', () => {
    const original = input();
    const result = ready(original);
    expect(Object.isFrozen(original)).toBe(false);
    for (const value of [
      result,
      result.raw,
      result.state,
      result.state.matrix,
      result.state.closing,
      ...result.state.matrix,
    ])
      expect(Object.isFrozen(value)).toBe(true);
    (original.raw as Record<string, string | null>).RTN_NET_AMT = '1';
    (original.labels as { taxName: string }).taxName = 'changed';
    expect(result.raw.RTN_NET_AMT).toBe('200.605');
    expect(result.state.matrix[2]?.[1]).toBe('Saved tax label');
    expect(() => {
      (result.state.matrix[2] as string[])[1] = 'mutated';
    }).toThrow(TypeError);
  });

  it('accepts frozen inputs and creates no opening, closing or prior color from unrelated raw values', () => {
    const original = input({ CUST_OPEN: '999', CUST_CLOSE: '-7', LAST_COLOR: 'red' });
    Object.freeze(original.raw);
    Object.freeze(original.labels);
    Object.freeze(original);
    const result = ready(original);
    expect(result.state.closing).toEqual({
      status: 'unavailable',
      amount: null,
      label: null,
      color: 'unknown',
      reason: 'Customer balance requires a resolved ledger mode.',
    });
    expect(result.raw.CUST_OPEN).toBe('999');
    expect(result.raw.CUST_CLOSE).toBe('-7');
  });

  it('maps nullable text and unavailable labels to blank display without rewriting raw', () => {
    const original = input({ TAX_CODE: null, BANK_AC: null, CHQ_NO: null, CARD_AC: null });
    const result = ready({
      ...original,
      labels: { taxName: null, bankAccountName: null, cardAccountName: null },
    });
    expect(result.state.matrix[2]?.[1]).toBe('');
    expect(result.state.matrix[2]?.[5]).toBe('');
    expect(result.state.matrix[4]?.[1]).toBe('');
    expect(result.state.matrix[4]?.[2]).toBe('');
    expect(result.state.matrix[4]?.[5]).toBe('');
    expect(result.state.matrix[5]?.[1]).toBe('');
    expect(result.state.matrix[5]?.[5]).toBe('');
    for (const key of textColumns) expect(result.raw[key]).toBeNull();
  });

  it.each(fnvColumns)('applies explicit Fnv NULL and ASCII-blank behavior only to %s', (key) => {
    const position: Record<(typeof fnvColumns)[number], readonly [number, number]> = {
      KASAR_AMT: [7, 4],
      BILL_OS: [8, 4],
      RTN_KASAR_AMT: [7, 3],
      RTN_BILL_OS: [8, 3],
    };
    for (const value of [null, '', '   '] as const) {
      const result = ready(input({ [key]: value }));
      const [row, column] = position[key];
      expect(result.state.matrix[row]?.[column]).toBe('0.00');
      expect(result.raw[key]).toBe(value);
    }
  });

  it.each(directColumns)('contains unresolved direct-Val NULL for %s', (key) => {
    const original = input({ [key]: null });
    const before = structuredClone(original);
    const result = refused(original);
    expect(result.diagnostics).toEqual([
      expect.objectContaining({ code: 'unsupported-numeric-null', sourceField: key }),
    ]);
    expect(original).toEqual(before);
    expect(Object.isFrozen(result)).toBe(true);
    expect(Object.isFrozen(result.diagnostics)).toBe(true);
    expect(Object.isFrozen(result.diagnostics[0])).toBe(true);
  });

  it.each([...directColumns, ...fnvColumns, ...textColumns])(
    'requires an own %s observation instead of a missing default',
    (key) => {
      const original = input();
      const raw = { ...original.raw };
      delete raw[key];
      Object.setPrototypeOf(raw, { [key]: fixture.input.raw[key] });
      const result = refused({ ...original, raw });
      expect(result.diagnostics).toEqual([
        expect.objectContaining({ code: 'missing-saved-column', sourceField: key }),
      ]);
    },
  );
});

describe('saved header exact-decimal containment', () => {
  it.each([
    '',
    ' ',
    '1e2',
    '1E-2',
    '12kg',
    '1,234.50',
    '0x10',
    '&H10',
    'NaN',
    'Infinity',
    '1 2',
    '12\n',
    '12\r',
    '12\u2028',
    '\t12',
    '\u00a012',
    '１２',
    '12\u0000',
    '+',
    '.',
    '0'.repeat(129),
  ])('rejects unsupported direct numeric text %j without conversion or trimming loss', (value) => {
    const result = refused(input({ RTN_NET_AMT: value }));
    expect(result.diagnostics).toEqual([
      expect.objectContaining({ code: 'invalid-saved-decimal', sourceField: 'RTN_NET_AMT' }),
    ]);
  });

  it.each(['\n', '\r', '\u2028', '\u00a0', '\t'])(
    'does not grant Fnv whitespace permission to %j',
    (value) => {
      const result = refused(input({ BILL_OS: value }));
      expect(result.diagnostics).toEqual([
        expect.objectContaining({ code: 'invalid-saved-decimal', sourceField: 'BILL_OS' }),
      ]);
    },
  );

  it.each([
    '0.0000000000000000001',
    '123456789012345678901234567890123456.1',
    '1000000000000000000000000000000000000',
    '-1000000000000000000000000000000000000',
  ])('rejects a parsed value outside the explicit precision/range profile: %s', (value) => {
    const result = refused(input({ TAX_AMT: value }));
    expect(result.diagnostics).toEqual([
      expect.objectContaining({ code: 'unsupported-saved-precision', sourceField: 'TAX_AMT' }),
    ]);
  });

  it('accepts boundary precision, ASCII spaces/signs, and source-format mathematical ties', () => {
    const result = ready(
      input({
        NET_AMT: '999999999999999999999999999999999999',
        RTN_NET_AMT: ' +0010.125 ',
        TAX_PRC: ' -.005 ',
        TAX_AMT: '.000000000000000001',
        TOT_AMT: '001.',
        BILL_OS: ' -1.225 ',
      }),
    );
    expect(result.state.outgoingRounded).toBe('999999999999999999999999999999999999.00');
    expect(result.state.incomingRounded).toBe('10.13');
    expect(result.state.oldNetAmt).toBe('10.13');
    expect(result.state.oldTaxPrc).toBe('-0.01');
    expect(result.state.matrix[2]?.[2]).toBe('-0.01');
    expect(result.state.matrix[2]?.[3]).toBe('0.00');
    expect(result.state.matrix[3]?.[4]).toBe('1.00');
    expect(result.state.matrix[8]?.[4]).toBe('-1.23');
  });

  it('retains exact large cents and historical Float text under ambient Decimal precision7', () => {
    const previousPrecision = Decimal.precision;
    try {
      Decimal.set({ precision: 7 });
      const original = input({
        RTN_NET_AMT: '99999999999999999999999999.015',
        TAX_PRC: '0.30000000000000004',
      });
      const result = ready(original);
      expect(result.state.incomingRounded).toBe('99999999999999999999999999.02');
      expect(result.state.oldNetAmt).toBe('99999999999999999999999999.02');
      expect(result.state.matrix[2]?.[2]).toBe('0.30');
      expect(result.state.oldTaxPrc).toBe('0.3');
      expect(result.raw).toEqual(original.raw);
      expect(Decimal.precision).toBe(7);
    } finally {
      Decimal.set({ precision: previousPrecision });
    }
  });

  it('preserves signed formatted zero but seeds canonical numeric caches', () => {
    const result = ready(input({ RTN_NET_AMT: '-0.004', TAX_PRC: '-0.004' }));
    expect(result.state.incomingRounded).toBe('-0.00');
    expect(result.state.matrix[2]?.[2]).toBe('-0.00');
    expect(result.state.oldNetAmt).toBe('0');
    expect(result.state.oldTaxPrc).toBe('0');
    expect(result.raw.RTN_NET_AMT).toBe('-0.004');
  });

  it('reports independent field problems together without a partial bill state', () => {
    const original = input({ NET_AMT: null, TAX_PRC: '1e2', RTN_BILL_OS: '\n' });
    const result = refused(original);
    expect(
      result.diagnostics.map((diagnostic) => [diagnostic.sourceField, diagnostic.code]),
    ).toEqual([
      ['NET_AMT', 'unsupported-numeric-null'],
      ['TAX_PRC', 'invalid-saved-decimal'],
      ['RTN_BILL_OS', 'invalid-saved-decimal'],
    ]);
    expect(Object.hasOwn(result, 'state')).toBe(false);
  });

  it.each([
    null,
    [],
    { raw: null, labels: fixture.input.labels },
    { raw: { ...fixture.input.raw, UNEXPECTED_NUMBER: 1 }, labels: fixture.input.labels },
    { raw: fixture.input.raw, labels: null },
    { raw: fixture.input.raw, labels: { taxName: null, bankAccountName: null } },
    {
      raw: fixture.input.raw,
      labels: { taxName: 1, bankAccountName: null, cardAccountName: null },
    },
    { raw: fixture.input.raw, labels: Object.create(fixture.input.labels) },
  ])('returns a recoverable diagnostic for malformed trusted input %#', (value) => {
    const result = refused(value as SavedSaleReturnBillProjectionInput);
    expect(result.diagnostics).toEqual([
      expect.objectContaining({ code: 'invalid-projection-input' }),
    ]);
  });
});
