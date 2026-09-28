import { describe, expect, it } from 'vitest';
import {
  resolveSaleReturnBillTaxPolicy,
  SALE_RETURN_BILL_TAX_POLICY_PROFILE,
  SALE_RETURN_BILL_TAX_POLICY_VERSION,
  type SaleReturnBillTaxPolicyCode,
  type SaleReturnBillTaxPolicyRaw,
} from '../src/saleReturnBillTaxPolicy.js';

const raw = (tax: string | null, flag: string | null): SaleReturnBillTaxPolicyRaw => ({
  'CO_SET.TAX_ROF': tax,
  'CO_SET.ALL_ROF_REMOVE': flag,
});
const ready = (tax: string | null, flag: string | null) => {
  const input = raw(tax, flag);
  const result = resolveSaleReturnBillTaxPolicy(input);
  expect(result.status, JSON.stringify(result)).toBe('ready');
  if (result.status !== 'ready') throw new Error('Expected source-supported tax precision');
  expect(result.raw).toEqual(input);
  expect(result.raw).not.toBe(input);
  expect(result.version).toBe(SALE_RETURN_BILL_TAX_POLICY_VERSION);
  expect(result.policy.version).toBe(SALE_RETURN_BILL_TAX_POLICY_VERSION);
  expect(result.profile).toBe(SALE_RETURN_BILL_TAX_POLICY_PROFILE);
  expect(result.diagnostics).toEqual([]);
  return result;
};
const unsupported = (input: unknown, code: SaleReturnBillTaxPolicyCode) => {
  const result = resolveSaleReturnBillTaxPolicy(input);
  expect(result.status, JSON.stringify(result)).toBe('unsupported');
  if (result.status !== 'unsupported') throw new Error('Expected contained tax policy');
  expect(result.policy).toBeNull();
  expect(result.diagnostics).toHaveLength(1);
  expect(result.diagnostics[0]?.code).toBe(code);
  expect(Object.isFrozen(result)).toBe(true);
  expect(Object.isFrozen(result.diagnostics)).toBe(true);
  expect(Object.isFrozen(result.diagnostics[0])).toBe(true);
  expect(Object.isFrozen(result.provenance)).toBe(true);
  return result;
};

describe('source company-open Sales Return bill tax precision', () => {
  // Hand-derived from MS_OPNCOMP:668–671 Int32; :741 >5->2; :1297 Y->2.
  // Values are literal independent expectations, never calculated by the resolver.
  it.each([
    ['0', 'N', 0],
    ['1', 'N', 1],
    ['2', 'N', 2],
    ['3', 'N', 3],
    ['4', 'N', 4],
    ['5', 'N', 5],
    ['6', 'N', 2],
    ['2147483647', 'N', 2],
    ['0', 'Y', 2],
    ['1', 'Y', 2],
    ['2', 'Y', 2],
    ['5', 'Y', 2],
    ['6', 'Y', 2],
    ['2147483647', 'Y', 2],
    ['-1', 'Y', 2],
    ['-2147483648', 'Y', 2],
    [null, 'N', 0],
    [null, 'Y', 2],
    ['4', '', 4],
    ['6', '', 2],
    [null, '', 0],
  ] as const)('resolves tax %s and flag %s to %s decimals', (tax, flag, expected) => {
    expect(ready(tax, flag).policy.taxRoundingDecimals).toBe(expected);
  });

  it('keeps SQL NULL, canonical zero and the source blank flag distinct in raw/provenance', () => {
    const fromNull = ready(null, 'N');
    const fromZero = ready('0', 'N');
    const fromBlankFlag = ready('0', '');
    expect(fromNull.raw['CO_SET.TAX_ROF']).toBeNull();
    expect(fromZero.raw['CO_SET.TAX_ROF']).toBe('0');
    expect(fromNull.policy).toEqual(fromZero.policy);
    expect(fromNull.provenance[0]).toEqual({
      stage: 'int32-conversion',
      inputKind: 'sql-null-via-fnv',
      value: '0',
    });
    expect(fromZero.provenance[0]).toEqual({
      stage: 'int32-conversion',
      inputKind: 'canonical-sql-int32-text',
      value: '0',
    });
    expect(fromBlankFlag.raw['CO_SET.ALL_ROF_REMOVE']).toBe('');
    expect(fromBlankFlag.provenance[2]).toEqual({
      stage: 'all-rounding-flag',
      inputKind: 'blank-default',
      value: 'N',
    });
    expect(fromNull.provenance[2]).toEqual({
      stage: 'all-rounding-flag',
      inputKind: 'canonical-flag',
      value: 'N',
    });
  });

  it('retains the preceding greater-than-five fallback even when final Y produces the same value', () => {
    expect(ready('2147483647', 'Y').provenance).toEqual([
      {
        stage: 'int32-conversion',
        inputKind: 'canonical-sql-int32-text',
        value: '2147483647',
      },
      {
        stage: 'greater-than-five-fallback',
        applied: true,
        before: '2147483647',
        after: '2',
      },
      { stage: 'all-rounding-flag', inputKind: 'canonical-flag', value: 'Y' },
      { stage: 'all-rounding-override', applied: true, before: '2', after: '2' },
    ]);
  });

  it('does not clamp a valid negative before the later configured override', () => {
    const result = ready('-2147483648', 'Y');
    expect(result.provenance[1]).toEqual({
      stage: 'greater-than-five-fallback',
      applied: false,
      before: '-2147483648',
      after: '-2147483648',
    });
    expect(result.provenance[3]).toEqual({
      stage: 'all-rounding-override',
      applied: true,
      before: '-2147483648',
      after: '2',
    });
  });

  it.each([
    ['-1', 'N'],
    ['-2147483648', 'N'],
    ['-5', ''],
  ])('contains unresolved negative %s after the valid %s flag path', (tax, flag) => {
    const input = raw(tax!, flag!);
    const result = unsupported(input, 'negative-tax-precision');
    expect(result.raw).toEqual(input);
    expect(result.diagnostics[0]?.key).toBe('CO_SET.TAX_ROF');
    expect(result.provenance).toHaveLength(4);
    expect(result.provenance[3]).toEqual({
      stage: 'all-rounding-override',
      applied: false,
      before: tax,
      after: tax,
    });
  });

  it.each([
    ['2147483648', 'N'],
    ['2147483648', 'Y'],
    ['-2147483649', 'N'],
    ['-2147483649', 'Y'],
    ['9007199254740991', 'Y'],
    ['9007199254740992', 'Y'],
    ['9999999999999999999999999999999999999999', 'Y'],
  ])('refuses Int32 overflow %s before either fallback or flag %s', (tax, flag) => {
    const result = unsupported(raw(tax!, flag!), 'tax-precision-int32-overflow');
    expect(result.provenance).toEqual([]);
    expect(result.raw?.['CO_SET.TAX_ROF']).toBe(tax);
  });

  it.each([
    '',
    ' ',
    '+0',
    '+1',
    '-0',
    '00',
    '01',
    '-01',
    '1.0',
    '2.5',
    '-1.5',
    '1e0',
    '1E0',
    '0x2',
    '&H2',
    '2tax',
    ' 2',
    '2 ',
    '2\n',
    '\t2',
    'NaN',
    'Infinity',
    '-Infinity',
    '２',
  ])('contains tax text %j under the SQL storage profile, even with final Y', (tax) => {
    const result = unsupported(raw(tax, 'Y'), 'unsupported-tax-precision-text');
    expect(result.raw).toEqual(raw(tax, 'Y'));
    expect(result.provenance).toEqual([]);
  });

  it.each([null, 'y', 'n', ' Y', 'Y ', 'N ', 'YES', '0', '\n'])(
    'does not invent the unsupported flag %j as N or Y',
    (flag) => {
      const result = unsupported(raw('6', flag), 'unsupported-all-rounding-flag');
      expect(result.raw).toEqual(raw('6', flag));
      expect(result.diagnostics[0]?.key).toBe('CO_SET.ALL_ROF_REMOVE');
      expect(result.provenance).toHaveLength(2);
      expect(result.provenance[1]).toEqual({
        stage: 'greater-than-five-fallback',
        applied: true,
        before: '6',
        after: '2',
      });
    },
  );

  it.each([
    undefined,
    null,
    false,
    2,
    '2',
    [],
    {},
    { 'CO_SET.TAX_ROF': '2' },
    { 'CO_SET.ALL_ROF_REMOVE': 'N' },
    { ...raw('2', 'N'), unknown: 'ignored?' },
    { 'CO_SET.TAX_ROF': '2', 'CO_SET_NEW.ALL_ROF_REMOVE': 'Y' },
    { 'co_set.tax_rof': '2', 'CO_SET.ALL_ROF_REMOVE': 'Y' },
    { CO_SET: { TAX_ROF: '2', ALL_ROF_REMOVE: 'N' } },
    { ...raw('2', 'N'), 'CO_SET.TAX_ROF': 2 },
    { ...raw('2', 'N'), 'CO_SET.TAX_ROF': undefined },
    { ...raw('2', 'N'), 'CO_SET.ALL_ROF_REMOVE': true },
    new Map(Object.entries(raw('2', 'N'))),
  ])('contains incomplete, foreign or non-text raw shape %#', (input) => {
    const result = unsupported(input, 'invalid-tax-policy-input');
    expect(result.raw).toBeNull();
    expect(result.provenance).toEqual([]);
  });

  it('does not accept an inherited setting, unknown symbol or nonenumerable property', () => {
    const inherited = Object.assign(Object.create({ 'CO_SET.TAX_ROF': '2' }), {
      'CO_SET.ALL_ROF_REMOVE': 'Y',
    });
    const withSymbol = { ...raw('2', 'N'), [Symbol('unobserved')]: 'x' };
    const nonenumerable = Object.defineProperty(
      { 'CO_SET.TAX_ROF': '2' },
      'CO_SET.ALL_ROF_REMOVE',
      {
        value: 'Y',
      },
    );
    for (const input of [inherited, withSymbol, nonenumerable])
      expect(unsupported(input, 'invalid-tax-policy-input').raw).toBeNull();
  });

  it('contains an accessor without invoking it as though it were a raw SQL value', () => {
    let calls = 0;
    const input = Object.defineProperty({ 'CO_SET.ALL_ROF_REMOVE': 'N' }, 'CO_SET.TAX_ROF', {
      enumerable: true,
      get() {
        calls += 1;
        return '2';
      },
    });
    expect(unsupported(input, 'invalid-tax-policy-input').raw).toBeNull();
    expect(calls).toBe(0);
  });

  it('accepts a complete null-prototype SQL text record', () => {
    const input: unknown = Object.assign(Object.create(null), raw('5', 'N'));
    const result = resolveSaleReturnBillTaxPolicy(input);
    expect(result.status).toBe('ready');
    expect(result.policy?.taxRoundingDecimals).toBe(5);
    expect(result.raw).toEqual(raw('5', 'N'));
  });

  it('deeply freezes detached success state while leaving caller values mutable and unchanged', () => {
    const input = { ...raw(null, '') };
    const before = structuredClone(input);
    const result = resolveSaleReturnBillTaxPolicy(input);
    expect(result.status).toBe('ready');
    expect(input).toEqual(before);
    expect(Object.isFrozen(input)).toBe(false);
    for (const value of [result, result.raw, result.policy, result.diagnostics, result.provenance])
      expect(Object.isFrozen(value)).toBe(true);
    for (const step of result.provenance) expect(Object.isFrozen(step)).toBe(true);
    input['CO_SET.TAX_ROF'] = '5';
    input['CO_SET.ALL_ROF_REMOVE'] = 'Y';
    expect(result.raw).toEqual(before);
    expect(result.policy?.taxRoundingDecimals).toBe(0);
  });

  it('freezes failure raw and provenance without changing its unaccepted nullable flag', () => {
    const input = Object.freeze(raw('2147483647', null));
    const result = unsupported(input, 'unsupported-all-rounding-flag');
    expect(result.raw).toEqual(input);
    expect(result.raw).not.toBe(input);
    expect(Object.isFrozen(result.raw)).toBe(true);
    for (const step of result.provenance) expect(Object.isFrozen(step)).toBe(true);
    expect(input['CO_SET.ALL_ROF_REMOVE']).toBeNull();
  });
});
