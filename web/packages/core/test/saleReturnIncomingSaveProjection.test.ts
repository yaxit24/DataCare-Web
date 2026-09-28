import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { Decimal } from 'decimal.js';
import { describe, expect, it } from 'vitest';
import {
  projectSaleReturnIncomingSave,
  SALE_RETURN_INCOMING_SAVE_VERSION,
  SALE_RETURN_INCOMING_SAVE_PROFILE,
  type SaleReturnIncomingSaveInput,
  type SaleReturnIncomingSaveCode,
} from '../src/saleReturnIncomingSaveProjection.js';

const bytes = readFileSync(
  new URL('./fixtures/saleReturnIncomingSave.independent.json', import.meta.url),
);
interface Literal {
  id: string;
  note: string;
  input: SaleReturnIncomingSaveInput;
  expected: {
    status: 'ready' | 'unsupported';
    sourceFieldValues: Record<string, string>;
    candidatePatch: Record<string, string> | null;
    diagnosticCode: SaleReturnIncomingSaveCode | null;
    raw: Record<string, string | null>;
    canCommit: false;
  };
}
const fixture = JSON.parse(bytes.toString()) as { cases: Literal[] };
const sample = (): Record<string, any> => structuredClone(fixture.cases[0]!.input);
function frozen(value: unknown): void {
  if (value && typeof value === 'object') {
    expect(Object.isFrozen(value)).toBe(true);
    Object.values(value).forEach(frozen);
  }
}
function refused(input: unknown, code: SaleReturnIncomingSaveCode) {
  const result = projectSaleReturnIncomingSave(input);
  expect(result.status).toBe('unsupported');
  expect(result.candidatePatch).toBeNull();
  expect(result.canCommit).toBe(false);
  expect(result.diagnostics.some((d) => d.code === code)).toBe(true);
  frozen(result);
  return result;
}

describe('incoming save map independent full-field fixtures', () => {
  it('pins26 preimplementation literals and the unchanged versioned inspection-only surface', () => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      'b6aae6e4add413b768f306703d16072999ac00a48ba779515b83346de4aeed50',
    );
    expect(fixture.cases).toHaveLength(26);
    expect(SALE_RETURN_INCOMING_SAVE_VERSION).toBe('primary-incoming-save-map-v1');
    expect(SALE_RETURN_INCOMING_SAVE_PROFILE).toBe(
      'saved-one-primary-untagged-c27-map-decimal-pg-v1',
    );
  });
  for (const literal of fixture.cases)
    it(`${literal.id}: ${literal.note}`, () => {
      const input = structuredClone(literal.input),
        before = structuredClone(input);
      const result = projectSaleReturnIncomingSave(input);
      expect(result.status).toBe(literal.expected.status);
      expect(result.sourceFieldValues).toStrictEqual(literal.expected.sourceFieldValues);
      expect(result.candidatePatch).toStrictEqual(literal.expected.candidatePatch);
      expect(result.raw).toStrictEqual(literal.expected.raw);
      expect(result.raw).not.toBe(input.raw);
      expect(result.canCommit).toBe(false);
      if (literal.expected.diagnosticCode)
        expect(result.diagnostics.some((d) => d.code === literal.expected.diagnosticCode)).toBe(
          true,
        );
      else expect(result.diagnostics).toStrictEqual([]);
      expect(input).toStrictEqual(before);
      expect(Object.isFrozen(input)).toBe(false);
      expect(Object.isFrozen(input.raw)).toBe(false);
      frozen(result);
    });
});

describe('mapping ownership and preserved observations', () => {
  it('separates source reserialization from unowned NULL/text and source scale', () => {
    const result = projectSaleReturnIncomingSave(sample());
    expect(result.differences).toContainEqual({
      field: 'ITM_REMARK',
      rawValue: null,
      sourceValue: 'Current master name',
      disposition: 'unowned-text-preserved',
    });
    expect(result.differences).toContainEqual({
      field: 'TAG_LBR_CODE',
      rawValue: '',
      sourceValue: 'AA',
      disposition: 'unowned-text-preserved',
    });
    expect(result.differences).toContainEqual({
      field: 'ITM_PCS',
      rawValue: '1.000',
      sourceValue: '1',
      disposition: 'numeric-text-preserved',
    });
    expect(result.raw?.FUTURE_EXTENSION).toBe('raw\ntext\u2603');
    expect(result.raw?.VCH_TIME).toBe('2024-07-09T23:59:59.999999');
    for (const field of ['VCH_TIME', 'MAIN_USER', 'EMP_CODE', 'CO_CODE', 'ENTRY_TYPE'])
      expect(Object.hasOwn(result.sourceFieldValues!, field)).toBe(false);
    expect(result.requirements).toContain(
      'complete-bar-stock-ledger-rojmel-tax-outstanding-remark-effect-ownership',
    );
  });
  it('reports source blank defaults without granting repair or session mode', () => {
    const x = sample();
    x.visible['2'] = '';
    x.visible['70'] = '';
    const result = projectSaleReturnIncomingSave(x);
    expect(result.branches).toStrictEqual({
      sourceWouldInclude: true,
      sourceOrdinal: '1',
      instanceAllocationRequired: false,
      blankTagDefault: true,
      blankDataTypeDefault: true,
    });
    expect(result.candidatePatch).toStrictEqual({});
    expect(result.raw?.TAG_NO).toBe('N');
    expect(result.canCommit).toBe(false);
  });
  it('retains the complete original raw on a later unowned-value refusal; publishes no earlier owned patch', () => {
    const x = sample();
    x.visible['27'] = '1';
    x.visible['35'] = '4';
    const result = refused(x, 'unowned-numeric-change');
    expect(result.raw).toStrictEqual(x.raw);
    expect(
      result.differences.some(
        (d) => d.field === 'OTH_AMT' && d.disposition === 'candidate-numeric-change',
      ),
    ).toBe(true);
    expect(result.sourceFieldValues?.TAG_MRP).toBe('4');
  });
  it('does not infer a no-op from a same-valued editor or map an event journal', () => {
    const x = sample();
    x.events = [{ fieldId: 'x13.primary-incoming.c27', editorText: '0' }];
    const result = refused(x, 'invalid-input');
    expect(result.raw).toStrictEqual(x.raw);
    expect(result.requirements).toContain(
      'trusted-c27-only-replay-and-complete-poststate-admission',
    );
  });
  it('does not serialize the unused source columns as new storage fields', () => {
    const x = sample();
    x.visible['41'] = 'unused cost';
    x.visible['42'] = 'unused fine';
    x.visible['53'] = 'unused code';
    x.visible['55'] = 'unused tag type';
    x.visible['57'] = 'unused';
    const result = projectSaleReturnIncomingSave(x);
    expect(result.status).toBe('ready');
    expect(result.sourceFieldValues).toStrictEqual(fixture.cases[0]!.expected.sourceFieldValues);
    expect(Object.keys(result.sourceFieldValues!)).toHaveLength(58);
  });
  it('uses private precision for exact cancellation even if shared Decimal settings change', () => {
    const previous = Decimal.precision;
    try {
      Decimal.set({ precision: 5 });
      const x = sample();
      x.visible['12'] = '999999999999999999999999999999999999';
      x.visible['38'] = '-999999999999999999999999999999999998';
      const result = refused(x, 'unsupported-credit-row');
      expect(result.branches.sourceWouldInclude).toBe(true);
      expect(Decimal.precision).toBe(5);
    } finally {
      Decimal.set({ precision: previous });
    }
  });
  it('retains a large unchanged Float-backed instance without a Number coercion/new assignment', () => {
    const x = sample();
    x.raw.VCH_SRNO = '9007199254740993';
    x.visible['40'] = '9007199254740993';
    const result = projectSaleReturnIncomingSave(x);
    expect(result.status).toBe('ready');
    expect(result.raw?.VCH_SRNO).toBe('9007199254740993');
    expect(result.sourceFieldValues?.VCH_SRNO).toBe('9007199254740993');
    expect(result.candidatePatch).toStrictEqual({});
  });
});

describe('bounded malformed input refuses without evaluating accessors or altering raw', () => {
  for (const value of [
    '12\n',
    '12\r',
    '12\t',
    '12\u2028',
    '\u00a012',
    '1e3',
    '12x',
    'NaN',
    'Infinity',
    '0x12',
  ])
    it(`rejects unsupported decimal ${JSON.stringify(value)}`, () => {
      const x = sample();
      x.visible['27'] = value;
      const result = refused(x, 'invalid-decimal');
      expect(result.raw).toStrictEqual(x.raw);
      expect(result.sourceFieldValues).toBeNull();
    });
  for (const value of ['1' + '0'.repeat(36), '0.0000000000000000001'])
    it(`rejects mathematical precision ${value}`, () => {
      const x = sample();
      x.visible['27'] = value;
      refused(x, 'unsupported-precision');
    });
  for (const [name, edit] of [
    [
      'missing visible key',
      (x: any) => {
        delete x.visible['69'];
      },
    ],
    [
      'extra cache key',
      (x: any) => {
        x.visible['45'] = '10';
      },
    ],
    [
      'NULL visible numeric',
      (x: any) => {
        x.visible['27'] = null;
      },
    ],
    [
      'numeric visible value',
      (x: any) => {
        x.visible['27'] = 1;
      },
    ],
    [
      'noncanonical visible key',
      (x: any) => {
        x.visible['027'] = '1';
        delete x.visible['27'];
      },
    ],
  ] as const)
    it(name, () => {
      const x = sample();
      edit(x);
      refused(x, 'invalid-visible');
    });
  it('retains missing raw fields as missing, not invented NULL', () => {
    const x = sample();
    delete x.raw.HM_ID3;
    const result = refused(x, 'missing-raw-field');
    expect(Object.hasOwn(result.raw!, 'HM_ID3')).toBe(false);
  });
  for (const location of ['envelope', 'visible', 'raw'] as const)
    it(`does not invoke ${location} getters`, () => {
      const x = sample();
      let reads = 0;
      const target = location === 'envelope' ? x : x[location];
      Object.defineProperty(
        target,
        location === 'envelope' ? 'visible' : location === 'raw' ? 'ITM_PCS' : '27',
        {
          enumerable: true,
          get: () => {
            reads++;
            throw new Error('must not run');
          },
        },
      );
      const result = refused(
        x,
        location === 'envelope'
          ? 'invalid-input'
          : location === 'raw'
            ? 'invalid-raw'
            : 'invalid-visible',
      );
      expect(reads).toBe(0);
      expect(result.raw === null).toBe(location === 'raw');
    });
  for (const kind of ['symbol', 'nonenumerable', 'prototype', 'cycle', 'array'] as const)
    it(`refuses ${kind} raw envelope`, () => {
      const x = sample();
      if (kind === 'symbol') x.raw[Symbol('x')] = 'value';
      if (kind === 'nonenumerable') Object.defineProperty(x.raw, 'hidden', { value: 'x' });
      if (kind === 'prototype') Object.setPrototypeOf(x.raw, { inherited: 'x' });
      if (kind === 'cycle') x.raw.loop = x.raw;
      if (kind === 'array') x.raw = [];
      const result = refused(x, 'invalid-raw');
      expect(result.raw).toBeNull();
    });
  it('accepts safe null-prototype records and preserves an own __proto__ string', () => {
    const x = sample();
    x.raw = Object.assign(Object.create(null), x.raw);
    Object.defineProperty(x.raw, '__proto__', {
      enumerable: true,
      value: 'retained literal',
    });
    x.visible = Object.assign(Object.create(null), x.visible);
    const result = projectSaleReturnIncomingSave(x);
    expect(result.status).toBe('ready');
    expect(Object.hasOwn(result.raw!, '__proto__')).toBe(true);
    expect(result.raw!['__proto__']).toBe('retained literal');
    expect(Object.getPrototypeOf(result.raw)).toBe(Object.prototype);
  });
  it('refuses oversized raw without manufacturing an empty saved row', () => {
    const x = sample();
    x.raw.FUTURE_EXTENSION = 'x'.repeat(65537);
    expect(refused(x, 'invalid-raw').raw).toBeNull();
  });
  it('does not retain caller references after success', () => {
    const x = sample(),
      result = projectSaleReturnIncomingSave(x);
    x.raw.ITM_REMARK = 'later';
    x.visible['3'] = 'later';
    expect(result.raw?.ITM_REMARK).toBeNull();
    expect(result.sourceFieldValues?.ITM_REMARK).toBe('Current master name');
    frozen(result);
  });
});
