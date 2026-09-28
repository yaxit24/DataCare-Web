import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import {
  SESSION_LEDGER_CONTEXT_VERSION,
  MAX_CONTEXT_EPOCH,
  parseContextEpoch,
  nextContextEpoch,
  parseContextSelectionId,
  parseUnknownSessionLedgerContext,
} from '../src/modules/auth/sessionContextValue.js';

type Operation = 'epoch' | 'successor' | 'ledgerContext' | 'selectionId';
interface Decision {
  id: string;
  operation: Operation;
  reason: string;
  input: unknown;
  expected: { accepted: boolean; value?: unknown };
}
const bytes = readFileSync(
  new URL('./fixtures/sessionContextValue.independent.json', import.meta.url),
);
const fixture = JSON.parse(bytes.toString()) as { cases: Decision[] };
const parsers = {
  epoch: parseContextEpoch,
  successor: nextContextEpoch,
  ledgerContext: parseUnknownSessionLedgerContext,
  selectionId: parseContextSelectionId,
};
const invalidCodes = {
  epoch: 'invalid-context-epoch',
  successor: 'invalid-context-epoch',
  ledgerContext: 'invalid-ledger-context',
  selectionId: 'invalid-context-selection-id',
} as const;
function unknownContext() {
  return {
    version: 'server-session-ledger-context-v1',
    status: 'unknown',
    mode: null,
    reason: 'vendor-authority-unresolved',
  };
}
function expectInvalidLedger(input: unknown) {
  const result = parseUnknownSessionLedgerContext(input);
  expect(result).toStrictEqual({ status: 'invalid', code: 'invalid-ledger-context' });
  expect(Object.isFrozen(result)).toBe(true);
}

describe('session context values: independently frozen transport decisions', () => {
  it('pins the original63 literal cases and explicit protocol constants', () => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      '6596159e7e7b1fe1ce2fdf40370b6d2533837b13e834f65dbc38f37f0c654910',
    );
    expect(fixture.cases).toHaveLength(63);
    expect(fixture.cases.filter((row) => row.operation === 'epoch')).toHaveLength(23);
    expect(fixture.cases.filter((row) => row.operation === 'successor')).toHaveLength(5);
    expect(fixture.cases.filter((row) => row.operation === 'ledgerContext')).toHaveLength(18);
    expect(fixture.cases.filter((row) => row.operation === 'selectionId')).toHaveLength(17);
    expect(SESSION_LEDGER_CONTEXT_VERSION).toBe('server-session-ledger-context-v1');
    expect(MAX_CONTEXT_EPOCH).toBe('9223372036854775807');
  });

  it.each(fixture.cases)('$id: $reason', ({ operation, input: literal, expected }) => {
    const input = structuredClone(literal);
    const before = structuredClone(input);
    const result = parsers[operation](input);
    expect(Object.isFrozen(result)).toBe(true);
    expect(input).toStrictEqual(before);
    if (input !== null && typeof input === 'object') expect(Object.isFrozen(input)).toBe(false);
    if (expected.accepted) {
      expect(result.status).toBe('ready');
      if (result.status !== 'ready') throw new Error('A frozen accepted vector was refused.');
      expect(result.value).toStrictEqual(expected.value);
      if (operation === 'ledgerContext') {
        expect(Object.isFrozen(result.value)).toBe(true);
        expect(result.value).not.toBe(input);
      }
    } else {
      const code = operation === 'successor' && input === '9223372036854775807'
        ? 'context-epoch-exhausted'
        : invalidCodes[operation];
      expect(result).toStrictEqual({ status: 'invalid', code });
    }
  });
});

describe('unknown ledger envelope and non-JSON containment', () => {
  it.each(['version', 'status', 'mode', 'reason'] as const)(
    'refuses an own %s getter without evaluating it',
    (field) => {
      const input = unknownContext();
      let calls = 0;
      Object.defineProperty(input, field, {
        enumerable: true,
        configurable: true,
        get() {
          calls += 1;
          throw new Error('Input getter must not execute.');
        },
      });
      expectInvalidLedger(input);
      expect(calls).toBe(0);
      expect(Object.isFrozen(input)).toBe(false);
    },
  );

  it('refuses a nonenumerable required key rather than silently serializing another shape', () => {
    const input = unknownContext();
    Object.defineProperty(input, 'mode', { value: null, enumerable: false });
    expectInvalidLedger(input);
  });

  it.each(['symbol', 'nonenumerable'] as const)('refuses an extra %s own key', (kind) => {
    const input = unknownContext();
    Object.defineProperty(input, kind === 'symbol' ? Symbol('extra') : 'extra', {
      value: 'untrusted',
      enumerable: kind === 'symbol',
    });
    expectInvalidLedger(input);
  });

  it('refuses a custom prototype with inherited protocol fields', () => {
    const inherited = Object.create(unknownContext()) as Record<string, unknown>;
    inherited.reason = 'scope-incomplete';
    expectInvalidLedger(inherited);
    expect(Object.hasOwn(inherited, 'mode')).toBe(false);
  });

  it('refuses a cyclic field value without recursive coercion or a thrown error', () => {
    const input: Record<string, unknown> = unknownContext();
    input.reason = input;
    expectInvalidLedger(input);
    expect(input.reason).toBe(input);
    expect(Object.isFrozen(input)).toBe(false);
  });

  it.each(['getPrototypeOf', 'ownKeys'] as const)(
    'contains a throwing %s reflection trap as an invalid envelope',
    (trap) => {
      let calls = 0;
      const fail = () => {
        calls += 1;
        throw new Error('Uninspectable input');
      };
      const input = new Proxy(unknownContext(), trap === 'getPrototypeOf'
        ? { getPrototypeOf: fail }
        : { ownKeys: fail });
      expectInvalidLedger(input);
      expect(calls).toBe(1);
    },
  );

  it('contains a revoked proxy without granting an observation', () => {
    const { proxy, revoke } = Proxy.revocable(unknownContext(), {});
    revoke();
    expectInvalidLedger(proxy);
  });

  it.each(['epoch', 'successor', 'ledgerContext', 'selectionId'] as const)(
    'refuses undefined %s instead of creating a default',
    (operation) => {
      expect(parsers[operation](undefined)).toStrictEqual({
        status: 'invalid',
        code: invalidCodes[operation],
      });
    },
  );

  it('does not coerce object values into epoch, selection ID or a ledger reason', () => {
    let calls = 0;
    const value = {
      [Symbol.toPrimitive]() {
        calls += 1;
        throw new Error('No coercion');
      },
    };
    expect(parseContextEpoch(value)).toStrictEqual({ status: 'invalid', code: 'invalid-context-epoch' });
    expect(nextContextEpoch(value)).toStrictEqual({ status: 'invalid', code: 'invalid-context-epoch' });
    expect(parseContextSelectionId(value)).toStrictEqual({
      status: 'invalid', code: 'invalid-context-selection-id',
    });
    expectInvalidLedger({ ...unknownContext(), reason: value });
    expect(calls).toBe(0);
  });

  it('detaches and freezes accepted ledger values while leaving caller data mutable', () => {
    const input = unknownContext();
    const before = structuredClone(input);
    const result = parseUnknownSessionLedgerContext(input);
    expect(result.status).toBe('ready');
    if (result.status !== 'ready') throw new Error('Expected the declared unknown context.');
    expect(result.value).toStrictEqual(before);
    expect(result.value).not.toBe(input);
    expect(Object.isFrozen(input)).toBe(false);
    expect(Object.isFrozen(result)).toBe(true);
    expect(Object.isFrozen(result.value)).toBe(true);
    input.status = 'resolved';
    input.reason = 'caller-mutated';
    expect(result.value).toStrictEqual(before);
  });

  it('accepts an already frozen caller without reusing its container', () => {
    const input = Object.freeze(unknownContext());
    const result = parseUnknownSessionLedgerContext(input);
    expect(result.status).toBe('ready');
    if (result.status !== 'ready') throw new Error('Expected the declared unknown context.');
    expect(result.value).toStrictEqual(input);
    expect(result.value).not.toBe(input);
  });

  it('accepts an exact null-prototype plain data envelope and returns ordinary detached data', () => {
    const input = Object.assign(Object.create(null), unknownContext()) as Record<string, unknown>;
    const result = parseUnknownSessionLedgerContext(input);
    expect(result.status).toBe('ready');
    if (result.status !== 'ready') throw new Error('Expected the declared unknown context.');
    expect(result.value).toStrictEqual(unknownContext());
    expect(result.value).not.toBe(input);
    expect(Object.getPrototypeOf(result.value)).toBe(Object.prototype);
    expect(Object.isFrozen(result.value)).toBe(true);
    expect(Object.isFrozen(input)).toBe(false);
  });
});
