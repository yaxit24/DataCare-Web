import { describe, expect, it } from 'vitest';
import fixture from './fixtures/saleReturnHeaderFloat.independent.json' with { type: 'json' };
import { qualifySaleReturnHeaderFloat } from '../src/saleReturnHeaderFloat.js';

const input = (text = '111') => ({ RTN_NET_AMT: text, RTN_TOT_AMT: text, RTN_BILL_OS: text });

describe('exact mathematical Return header Float storage', () => {
  it.each(['111\u2028', '111\u2029', '111\u00a0'])(
    'refuses non-ASCII terminal whitespace %#',
    (text) => {
      expect(qualifySaleReturnHeaderFloat(input(text))).toMatchObject({
        status: 'unsupported',
        values: null,
        diagnostic: { code: 'invalid-decimal' },
      });
    },
  );
  for (const vector of fixture.cases)
    it(vector.id, () => {
      const original = input(vector.text);
      const result = qualifySaleReturnHeaderFloat(original);
      expect(result.canCommit).toBe(false);
      expect(result.raw).toEqual(original);
      expect(result.raw).not.toBe(original);
      if (vector.diagnosticCode === null) {
        expect(result.status).toBe('ready');
        if (result.status !== 'ready') throw Error('Expected ready');
        expect(result.values).toEqual(input(vector.expectedCanonical!));
      } else {
        expect(result.status).toBe('unsupported');
        if (result.status !== 'unsupported') throw Error('Expected unsupported');
        expect(result.values).toBeNull();
        expect(result.diagnostic).toEqual({
          code: vector.diagnosticCode,
          field: 'RTN_NET_AMT',
          recoverable: true,
        });
      }
      expect(original).toEqual(input(vector.text));
    });

  it.each(['RTN_NET_AMT', 'RTN_TOT_AMT', 'RTN_BILL_OS'] as const)(
    'refuses one inexact %s without a partial result',
    (field) => {
      const original = { ...input(), [field]: '0.1' };
      expect(qualifySaleReturnHeaderFloat(original)).toMatchObject({
        status: 'unsupported',
        values: null,
        raw: original,
        diagnostic: { code: 'inexact-binary64', field },
        canCommit: false,
      });
    },
  );

  it.each([
    null,
    [],
    '111',
    {},
    { ...input(), extra: true },
    { ...input(), RTN_NET_AMT: 111 },
    { ...input(), RTN_NET_AMT: null },
    new (class {
      RTN_NET_AMT = '111';
      RTN_TOT_AMT = '111';
      RTN_BILL_OS = '111';
    })(),
    { ...input(), [Symbol('extra')]: true },
  ])('refuses invalid own input %#', (value) => {
    expect(qualifySaleReturnHeaderFloat(value)).toMatchObject({
      status: 'unsupported',
      raw: null,
      values: null,
      canCommit: false,
      diagnostic: { code: 'invalid-envelope' },
    });
  });

  it('never evaluates accessors or nonenumerable field values', () => {
    let calls = 0;
    const accessor = {
      ...input(),
      get RTN_NET_AMT() {
        calls++;
        return '111';
      },
    };
    expect(qualifySaleReturnHeaderFloat(accessor).status).toBe('unsupported');
    expect(calls).toBe(0);
    const hidden = input();
    Object.defineProperty(hidden, 'RTN_TOT_AMT', { enumerable: false });
    expect(qualifySaleReturnHeaderFloat(hidden).status).toBe('unsupported');
  });

  it('accepts a null-prototype own map and detaches/freeze the whole success', () => {
    const original = Object.assign(Object.create(null), input());
    const result = qualifySaleReturnHeaderFloat(original);
    expect(result.status).toBe('ready');
    original.RTN_NET_AMT = '0.1';
    expect(result.raw).toEqual(input());
    expect(result.values).toEqual(input());
    expect(Object.isFrozen(result)).toBe(true);
    expect(Object.isFrozen(result.raw)).toBe(true);
    expect(Object.isFrozen(result.values)).toBe(true);
  });

  it('retains a detached immutable failed draft', () => {
    const original = input('0.1');
    const result = qualifySaleReturnHeaderFloat(original);
    original.RTN_NET_AMT = '111';
    expect(result.raw).toEqual(input('0.1'));
    expect(Object.isFrozen(result.raw)).toBe(true);
    expect(result.status).toBe('unsupported');
    if (result.status === 'unsupported') expect(Object.isFrozen(result.diagnostic)).toBe(true);
  });

  it('does not widen bounded input because many trailing zeros denote an exact value', () => {
    expect(qualifySaleReturnHeaderFloat(input(`1.${'0'.repeat(128)}`))).toMatchObject({
      status: 'unsupported',
      diagnostic: { code: 'invalid-decimal' },
    });
  });
});
