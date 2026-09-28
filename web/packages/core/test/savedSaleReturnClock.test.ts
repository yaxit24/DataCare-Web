import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import {
  SAVED_SALE_RETURN_CLOCK_VERSION,
  SAVED_SALE_RETURN_CLOCK_PROFILE,
  projectSavedSaleReturnClock,
} from '../src/savedSaleReturnClock.js';

type Diagnostic = {
  code: string;
  sourceField?: 'VCH_DATE' | 'VCH_TIME';
};
type Vector = {
  id: string;
  reason: string;
  input: unknown;
  expected: {
    status: 'ready' | 'unsupported' | 'invalid-input';
    cutoffLocalSecond?: string | null;
    diagnostics?: Diagnostic[];
    diagnosticCode?: string;
    observation?: null;
  };
};
const bytes = readFileSync(new URL('./fixtures/saved-sale-return-clock.v1.json', import.meta.url));
const fixture = JSON.parse(bytes.toString()) as {
  expectedVersion: string;
  expectedProfile: string;
  cases: Vector[];
};

function validInput() {
  return {
    raw: {
      VCH_DATE: '2024-07-10',
      VCH_TIME: '2024-07-09T12:00:00.900000',
    },
    provenance: {
      documentIdentity: 'saved-return:tenant-test/01/01/2024/R13/00017',
      documentVersion: 'physical-observation-v1:revision-17',
    },
  };
}
function diagnosticKeys(values: readonly Diagnostic[]) {
  return values.map((value) => `${value.code}:${value.sourceField ?? ''}`).sort();
}
function expectDeepFrozen(value: unknown) {
  if (value === null || typeof value !== 'object') return;
  expect(Object.isFrozen(value)).toBe(true);
  for (const child of Object.values(value)) expectDeepFrozen(child);
}
function expectCallerNotFrozen(value: unknown) {
  if (value === null || typeof value !== 'object') return;
  expect(Object.isFrozen(value)).toBe(false);
  for (const descriptor of Object.values(Object.getOwnPropertyDescriptors(value))) {
    if ('value' in descriptor) expectCallerNotFrozen(descriptor.value);
  }
}
function expectInvalid(input: unknown) {
  const result = projectSavedSaleReturnClock(input);
  expect(result.status).toBe('invalid-input');
  expect(result.observation).toBeNull();
  expect(result.diagnostics.map((diagnostic) => diagnostic.code)).toContain('invalid-input');
  expectDeepFrozen(result);
}

describe('saved Return clock independent canonical JSONB profile', () => {
  it('pins the literal fixture before implementation and the explicit semantic version', () => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      'd360162bc731cb383e33146c29265586358413821fca0cf5d94c4bdf753cdd78',
    );
    expect(fixture.cases).toHaveLength(139);
    expect(fixture.cases.filter((value) => value.expected.status === 'ready')).toHaveLength(24);
    expect(fixture.cases.filter((value) => value.expected.status === 'unsupported')).toHaveLength(83);
    expect(fixture.cases.filter((value) => value.expected.status === 'invalid-input')).toHaveLength(32);
    expect(SAVED_SALE_RETURN_CLOCK_VERSION).toBe('saved-sale-return-clock-v1');
    expect(SAVED_SALE_RETURN_CLOCK_PROFILE).toBe('canonical-postgresql-jsonb-local-clock-v1');
  });

  it.each(fixture.cases)('$id: $reason', ({ input: originalInput, expected }) => {
    const input = structuredClone(originalInput);
    const before = structuredClone(input);
    const result = projectSavedSaleReturnClock(input);
    expect(result.version).toBe(fixture.expectedVersion);
    expect(result.profile).toBe(fixture.expectedProfile);
    expect(result.status).toBe(expected.status);
    expect(input).toStrictEqual(before);
    expectCallerNotFrozen(input);
    expectDeepFrozen(result);
    for (const diagnostic of result.diagnostics) {
      expect(typeof diagnostic.message).toBe('string');
      expect(diagnostic.message.trim().length).toBeGreaterThan(0);
    }
    if (expected.status === 'invalid-input') {
      expect(result.observation).toBeNull();
      expect(result.diagnostics.map((value) => value.code)).toContain(expected.diagnosticCode);
      return;
    }
    const typedInput = input as ReturnType<typeof validInput>;
    const observation = result.observation;
    expect(observation).not.toBeNull();
    if (observation === null) throw new Error('A valid envelope must retain its raw observation.');
    expect(observation.raw).toStrictEqual(typedInput.raw);
    expect(observation.provenance).toStrictEqual(typedInput.provenance);
    expect(observation.raw).not.toBe(typedInput.raw);
    expect(observation.provenance).not.toBe(typedInput.provenance);
    expect(observation.cutoffLocalSecond).toBe(expected.cutoffLocalSecond);
    expect(diagnosticKeys(result.diagnostics)).toEqual(diagnosticKeys(expected.diagnostics ?? []));
    for (const field of ['VCH_DATE', 'VCH_TIME'] as const) {
      expect(Object.hasOwn(observation.raw, field)).toBe(Object.hasOwn(typedInput.raw, field));
    }
  });

  it.each(['wrapper', 'raw', 'provenance'] as const)(
    'refuses a %s accessor without invoking it',
    (location) => {
      const input = validInput();
      let calls = 0;
      const target = location === 'wrapper' ? input : input[location];
      const key = location === 'wrapper' ? 'raw' : location === 'raw' ? 'VCH_DATE' : 'documentVersion';
      Object.defineProperty(target, key, {
        enumerable: true,
        configurable: true,
        get() {
          calls += 1;
          throw new Error('An input getter must never execute.');
        },
      });
      expectInvalid(input);
      expect(calls).toBe(0);
      expectCallerNotFrozen(input);
    },
  );

  it('refuses inherited saved date on a custom-prototype raw object', () => {
    const input = validInput();
    const raw = Object.create({ VCH_DATE: '2024-07-10' }) as Record<string, unknown>;
    raw.VCH_TIME = input.raw.VCH_TIME;
    expect(Object.hasOwn(raw, 'VCH_DATE')).toBe(false);
    expectInvalid({ ...input, raw });
    expect(Object.isFrozen(raw)).toBe(false);
  });

  it('refuses a cyclic malformed envelope without throwing', () => {
    const input = validInput() as ReturnType<typeof validInput> & { cycle?: unknown };
    input.cycle = input;
    expectInvalid(input);
    expect(Object.isFrozen(input)).toBe(false);
    expect(input.cycle).toBe(input);
  });

  it.each(['wrapper', 'raw', 'provenance'] as const)(
    'does not silently drop a %s symbol key',
    (location) => {
      const input = validInput();
      const target = location === 'wrapper' ? input : input[location];
      Object.defineProperty(target, Symbol('hidden-input'), { value: 'untrusted', enumerable: true });
      expectInvalid(input);
    },
  );

  it.each(['wrapper', 'raw', 'provenance'] as const)(
    'does not silently drop a %s nonenumerable extra own key',
    (location) => {
      const input = validInput();
      const target = location === 'wrapper' ? input : input[location];
      Object.defineProperty(target, 'hiddenInput', { value: 'untrusted', enumerable: false });
      expectInvalid(input);
    },
  );

  it.each([NaN, Infinity, -Infinity])('refuses nonfinite raw values (%s) without coercion', (value) => {
    const input = validInput();
    expectInvalid({ ...input, raw: { ...input.raw, VCH_TIME: value } });
  });

  it('keeps ready output detached while caller raw and provenance change', () => {
    const input = validInput();
    const result = projectSavedSaleReturnClock(input);
    expect(result.status).toBe('ready');
    const before = structuredClone(result);
    input.raw.VCH_DATE = '2025-01-01';
    input.raw.VCH_TIME = '2025-01-01T00:00:00';
    input.provenance.documentIdentity = 'different-document';
    input.provenance.documentVersion = 'different-version';
    expect(result).toStrictEqual(before);
    expect(result.observation?.cutoffLocalSecond).toBe('2024-07-10 12:00:00');
    expectDeepFrozen(result);
    expectCallerNotFrozen(input);
  });

  it('retains missing own keys in an unsupported detached observation after caller repair', () => {
    const input = {
      raw: { VCH_DATE: null } as { VCH_DATE: string | null; VCH_TIME?: string },
      provenance: validInput().provenance,
    };
    const result = projectSavedSaleReturnClock(input);
    expect(result.status).toBe('unsupported');
    const before = structuredClone(result);
    input.raw.VCH_DATE = '2024-07-10';
    input.raw.VCH_TIME = '2024-07-09T12:00:00.900000';
    input.provenance.documentVersion = 'repaired';
    expect(result).toStrictEqual(before);
    expect(result.observation?.raw.VCH_DATE).toBeNull();
    expect(Object.hasOwn(result.observation?.raw ?? {}, 'VCH_TIME')).toBe(false);
    expectDeepFrozen(result);
    expectCallerNotFrozen(input);
  });

  it('accepts a frozen caller without changing it and still returns detached containers', () => {
    const input = validInput();
    Object.freeze(input.raw);
    Object.freeze(input.provenance);
    Object.freeze(input);
    const before = structuredClone(input);
    const result = projectSavedSaleReturnClock(input);
    expect(result.status).toBe('ready');
    expect(input).toStrictEqual(before);
    expect(result.observation?.raw).not.toBe(input.raw);
    expect(result.observation?.provenance).not.toBe(input.provenance);
    expectDeepFrozen(result);
  });

  it('retains distinct opaque document versions without treating them as clock authority', () => {
    const first = validInput();
    const second = validInput();
    second.provenance.documentIdentity = 'second arbitrary document';
    second.provenance.documentVersion = 'second arbitrary version';
    const left = projectSavedSaleReturnClock(first);
    const right = projectSavedSaleReturnClock(second);
    expect(left.status).toBe('ready');
    expect(right.status).toBe('ready');
    expect(left.observation?.cutoffLocalSecond).toBe('2024-07-10 12:00:00');
    expect(right.observation?.cutoffLocalSecond).toBe('2024-07-10 12:00:00');
    expect(left.observation?.provenance).toStrictEqual(first.provenance);
    expect(right.observation?.provenance).toStrictEqual(second.provenance);
  });

  it('admits exactly256 printable provenance characters and interior spaces without trimming', () => {
    const input = validInput();
    input.provenance.documentIdentity = 'x'.repeat(256);
    input.provenance.documentVersion = 'v ' + 'y'.repeat(254);
    const result = projectSavedSaleReturnClock(input);
    expect(result.status).toBe('ready');
    expect(result.observation?.provenance).toStrictEqual(input.provenance);
  });
});
