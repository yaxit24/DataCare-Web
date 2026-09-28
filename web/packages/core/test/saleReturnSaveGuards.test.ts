import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { Decimal } from 'decimal.js';
import { describe, expect, it } from 'vitest';
import { evaluateSavedSaleReturnSaveGuards } from '../src/saleReturnSaveGuards.js';

type Json = null | boolean | string | number | Json[] | { [key: string]: Json };
interface Case {
  id: string;
  description: string;
  input: Json;
  expected: Json;
}
interface Fixture {
  cases: Case[];
}
interface Amendment {
  originalFixtureSha256: string;
  replacements: { caseId: string; oldExpected: Json; newExpected: Json }[];
  additionalCases: Case[];
}
const originalBytes = readFileSync(
  new URL('./fixtures/saleReturnSaveGuards.independent.json', import.meta.url),
);
const amendmentBytes = readFileSync(
  new URL('./fixtures/saleReturnSaveGuards.fine-amendment.json', import.meta.url),
);
const fixture = JSON.parse(originalBytes.toString()) as Fixture;
const amendment = JSON.parse(amendmentBytes.toString()) as Amendment;
const clone = <T>(x: T): T => JSON.parse(JSON.stringify(x)) as T;
function changed(path: (string | number)[], value: Json): Json {
  const input = clone(fixture.cases[0]!.input);
  let current = input;
  for (const key of path.slice(0, -1)) current = (current as Record<string, Json>)[String(key)]!;
  (current as Record<string, Json>)[String(path[path.length - 1])] = value;
  return input;
}
function deeplyFrozen(x: unknown): boolean {
  return (
    !x || typeof x !== 'object' || (Object.isFrozen(x) && Object.values(x).every(deeplyFrozen))
  );
}
function verify(c: Case, expected: Json): void {
  const input = clone(c.input);
  const before = JSON.stringify(input);
  const result = evaluateSavedSaleReturnSaveGuards(input);
  expect(result).toStrictEqual(expected);
  expect(result.canCommit).toBe(false);
  expect(JSON.stringify(input)).toBe(before);
  expect(Object.isFrozen(input)).toBe(false);
  expect(deeplyFrozen(result)).toBe(true);
  expect(result.observation).not.toBe(input);
}

describe('source-derived immutable guard outcomes', () => {
  it('pins the original64 and sole explicit G41 amendment plus7 new cases', () => {
    expect(createHash('sha256').update(originalBytes).digest('hex')).toBe(
      '6af7121c2952c9be055f1e83671d0e1bd0139c80a1d81bc9482c1edb90fd8e78',
    );
    expect(createHash('sha256').update(amendmentBytes).digest('hex')).toBe(
      '87de6652da68f4400389e862edc590cfa4a919d882ddddd7b7ad51bed22790c5',
    );
    expect(amendment.originalFixtureSha256).toBe(
      createHash('sha256').update(originalBytes).digest('hex'),
    );
    expect(fixture.cases).toHaveLength(64);
    expect(amendment.additionalCases).toHaveLength(7);
    expect(amendment.replacements.map((r) => r.caseId)).toEqual(['G41']);
    expect(amendment.replacements[0]!.oldExpected).toEqual(
      fixture.cases.find((c) => c.id === 'G41')!.expected,
    );
  });
  it.each(fixture.cases)('$id $description', (c) => {
    const replacement = amendment.replacements.find((r) => r.caseId === c.id);
    verify(c, replacement?.newExpected ?? c.expected);
  });
  it.each(amendment.additionalCases)('$id full joint/predicate amendment', (c) =>
    verify(c, c.expected),
  );
});

describe('plain-decimal and calendar qualification', () => {
  it.each([
    '12\n',
    '12\r',
    '12\u2028',
    '\t0',
    '\u00a00',
    '0\u200b',
    '1e2',
    'Infinity',
    'NaN',
    '0suffix',
    '0x10',
    '+',
    '.',
    '1,000',
    '1 0',
  ])('refuses nonprofile cash text %j at the reached cash guard', (value) => {
    const result = evaluateSavedSaleReturnSaveGuards(
      changed(['observations', 'cashLimit', 'value'], value),
    );
    expect(result.status).toBe('unsupported');
    expect(result.diagnostic).toEqual({
      code: 'unsupported-decimal',
      guard: 'cash-limit',
    });
  });
  it.each([
    '0.0000000000000000001',
    '1000000000000000000000000000000000000',
    '999999999999999999999999999999999999.1',
  ])('contains values outside decimal profile %s', (value) => {
    expect(
      evaluateSavedSaleReturnSaveGuards(changed(['observations', 'cashLimit', 'value'], value))
        .diagnostic,
    ).toEqual({ code: 'unsupported-precision', guard: 'cash-limit' });
  });
  it.each([
    '0000-01-01',
    '2025-02-29',
    '2024-04-31',
    '2025-00-01',
    '2025-13-01',
    '2025-01-00',
    '2025-01-32',
    '2025-1-01',
    '2025-06-15\n',
    '2025-06-15T00:00:00',
    '15/06/2025',
    '',
    null,
  ])('refuses unqualified voucher date %j', (value) => {
    expect(
      evaluateSavedSaleReturnSaveGuards(
        changed(['observations', 'period', 'value', 'voucherDate'], value),
      ).diagnostic,
    ).toEqual({ code: 'unsupported-date', guard: 'year-range' });
  });
  it('preserves meaningful prior rejection before later bad numeric/date/fact', () => {
    const c = clone(fixture.cases.find((c) => c.id === 'G10')!.input);
    const result = evaluateSavedSaleReturnSaveGuards(c);
    expect(result.status).toBe('source-rejected');
    expect(result.checks.at(-1)?.guard).toBe('employee-required');
    expect(result.checks.some((r) => r.guard === 'defaulter')).toBe(false);
  });
  it('evaluates source bitwise cheque predicate operands without inventing NULL bank text', () => {
    expect(
      evaluateSavedSaleReturnSaveGuards(
        changed(['observations', 'bill', 'value', 'matrix', 4, 5], null),
      ).diagnostic,
    ).toEqual({ code: 'unsupported-text', guard: 'cheque-bank' });
  });
  it('keeps exact36-digit credit under hostile ambient Decimal precision', () => {
    const precision = Decimal.precision;
    try {
      Decimal.set({ precision: 7 });
      verify(
        fixture.cases.find((c) => c.id === 'G60')!,
        fixture.cases.find((c) => c.id === 'G60')!.expected,
      );
    } finally {
      Decimal.set({ precision });
    }
  });
  it('contains a comparison sum outside its declared precision instead of publishing a guess', () => {
    const c = clone(fixture.cases[0]!.input) as Record<string, Json>;
    const obs = c.observations as Record<string, Json>;
    const b = (obs.bill as Record<string, Json>).value as Record<string, Json>;
    b.nAcCrAmt = '999999999999999999999999999999999999';
    b.nAcDrAmt = '0.01';
    expect(evaluateSavedSaleReturnSaveGuards(c).diagnostic).toEqual({
      code: 'unsupported-precision',
      guard: 'amount-nonzero',
    });
  });
});

describe('strict detached envelope containment', () => {
  it.each([undefined, null, [], 1, true, 'flags', new Date(), new Map(), { provenance: {} }])(
    'rejects malformed envelope %#',
    (value) => {
      const result = evaluateSavedSaleReturnSaveGuards(value);
      expect(result.status).toBe('invalid-input');
      expect(result.observation).toBeNull();
      expect(result.canCommit).toBe(false);
    },
  );
  it('rejects unknown root data and supplied canCommit/auth flag without granting authority', () => {
    const input = clone(fixture.cases[0]!.input) as Record<string, Json>;
    input.canCommit = true;
    expect(evaluateSavedSaleReturnSaveGuards(input).status).toBe('invalid-input');
  });
  it('does not invoke getters in envelope or qualified values', () => {
    let calls = 0;
    const input = clone(fixture.cases[0]!.input) as Record<string, Json>;
    Object.defineProperty(input, 'provenance', {
      enumerable: true,
      get() {
        calls++;
        throw new Error('must not invoke');
      },
    });
    expect(evaluateSavedSaleReturnSaveGuards(input).status).toBe('invalid-input');
    expect(calls).toBe(0);
  });
  it('rejects hidden, symbol and inherited additions', () => {
    for (const kind of ['hidden', 'symbol', 'prototype']) {
      const input = clone(fixture.cases[0]!.input) as Record<string, Json>;
      if (kind === 'hidden')
        Object.defineProperty(input, 'hidden', {
          value: 'x',
          enumerable: false,
        });
      else if (kind === 'symbol')
        Object.defineProperty(input, Symbol('x'), {
          value: 'x',
          enumerable: true,
        });
      else Object.setPrototypeOf(input, { forged: true });
      expect(evaluateSavedSaleReturnSaveGuards(input).status).toBe('invalid-input');
    }
  });
  it('contains cyclic or revoked reflection inputs', () => {
    const input: Record<string, unknown> = {};
    input.self = input;
    expect(evaluateSavedSaleReturnSaveGuards(input).status).toBe('invalid-input');
    const p = Proxy.revocable({}, {});
    p.revoke();
    expect(evaluateSavedSaleReturnSaveGuards(p.proxy).status).toBe('invalid-input');
  });
  it('rejects sparse or extra-property arrays and row ordinal forgery', () => {
    const rows = [{ rowIdentity: 'row-1', ordinal: 1, itemCode: 'GOLD', counterCode: '01' }];
    Object.defineProperty(rows, 'surprise', { value: 'x', enumerable: true });
    expect(
      evaluateSavedSaleReturnSaveGuards(changed(['observations', 'incomingRows', 'value'], rows))
        .status,
    ).toBe('invalid-input');
    const sparse = new Array<Json>(1);
    expect(
      evaluateSavedSaleReturnSaveGuards(changed(['observations', 'incomingRows', 'value'], sparse))
        .status,
    ).toBe('invalid-input');
    expect(
      evaluateSavedSaleReturnSaveGuards(
        changed(['observations', 'incomingRows', 'value', 0, 'ordinal'], 2),
      ).status,
    ).toBe('invalid-input');
  });
  it('rejects coerced booleans/numerics and invalid provenance', () => {
    expect(
      evaluateSavedSaleReturnSaveGuards(changed(['observations', 'freshUpdate', 'value'], 'true'))
        .status,
    ).toBe('invalid-input');
    expect(
      evaluateSavedSaleReturnSaveGuards(changed(['observations', 'cashLimit', 'value'], 0)).status,
    ).toBe('invalid-input');
    expect(
      evaluateSavedSaleReturnSaveGuards(changed(['provenance', 'observationId'], ' epoch ')).status,
    ).toBe('invalid-input');
  });
  it('old result does not change when caller modifies a qualified observation', () => {
    const input = clone(fixture.cases[0]!.input) as Record<string, Json>;
    const result = evaluateSavedSaleReturnSaveGuards(input);
    const before = JSON.stringify(result);
    (input.provenance as Record<string, Json>).documentVersion = 'changed';
    expect(JSON.stringify(result)).toBe(before);
    expect(deeplyFrozen(result)).toBe(true);
  });
});
