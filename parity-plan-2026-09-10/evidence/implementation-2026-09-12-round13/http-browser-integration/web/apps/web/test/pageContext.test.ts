import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { describe, expect, it, vi } from 'vitest';
import {
  createPageContextGuard,
  pageContextHeaders,
  parseBrowserSessionContext,
  type PageContextTicket,
} from '../lib/pageContext';
import independent from './fixtures/pageContext.independent.json';

const contexts: Record<string, unknown> = independent.contexts;
interface Transition {
  id: string;
  steps: string[];
  state: { status: string; revision: number; context: string | null; reason?: string };
  headers?: Record<string, unknown>;
  error?: string | null;
}
const transitions: Transition[] = independent.transitions;

describe('page context literal transition contract', () => {
  it.each(transitions)('$id', (fixture) => {
    const guard = createPageContextGuard();
    let ticket: PageContextTicket | undefined;
    let error: unknown;
    for (const step of fixture.steps) {
      try {
        if (step === 'capture') ticket = guard.capture();
        else if (step.startsWith('observe:'))
          guard.observe(contexts[step.slice(8)] ?? { invalid: true });
        else if (step === 'reset') guard.resetForNavigation();
        else {
          if (!ticket) throw new Error('Fixture needs a captured ticket');
          if (step === 'assert-ticket') guard.assertCurrent(ticket);
          else if (step === 'reject-ticket' || step === 'reject-old-ticket') guard.reject(ticket);
          else throw new Error(`Unknown fixture step ${step}`);
        }
      } catch (caught) {
        error = caught;
        break;
      }
    }
    expect(guard.read()).toMatchObject({
      ...fixture.state,
      context: fixture.state.context === null ? null : contexts[fixture.state.context],
    });
    if (fixture.error) expect(error).toMatchObject({ code: fixture.error, status: 409 });
    else expect(error).toBeUndefined();
    if (fixture.headers) {
      if (!ticket) throw new Error('Fixture needs headers ticket');
      expect(pageContextHeaders(ticket)).toStrictEqual(fixture.headers);
    }
  });

  it('pins the preimplementation transition and transport scenario input', () => {
    const bytes = readFileSync(new URL('./fixtures/pageContext.independent.json', import.meta.url));
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      'c4b96577f329ff64670b1b7124f0924dddf0c8c7c720bf62c8c31d4e5cec0515',
    );
    expect(transitions).toHaveLength(15);
    expect(independent.apiCases).toHaveLength(16);
  });
});

const A = independent.contexts.A;
describe('descriptor shape and exact immutable identity', () => {
  it.each([
    { name: 'ordinary', value: A },
    { name: 'maximumBIGINT', value: { ...A, contextEpoch: '9223372036854775807' } },
    { name: 'absentyear', value: { ...A, coYear: null } },
    { name: 'exactpaddedcode', value: { ...A, coCode: '1 ' } },
  ])('accepts $name without normalization', ({ value }) => {
    expect(parseBrowserSessionContext(value)).toStrictEqual(value);
    expect(Object.isFrozen(parseBrowserSessionContext(value))).toBe(true);
  });

  it.each([
    { name: 'numeric epoch', value: { ...A, contextEpoch: 7 } },
    { name: 'zero epoch', value: { ...A, contextEpoch: '0' } },
    { name: 'padded epoch', value: { ...A, contextEpoch: '07' } },
    { name: 'overflow epoch', value: { ...A, contextEpoch: '9223372036854775808' } },
    { name: 'epoch terminal newline', value: { ...A, contextEpoch: '7\n' } },
    { name: 'epoch terminal carriage return', value: { ...A, contextEpoch: '7\r' } },
    { name: 'UUID nonv4', value: { ...A, sessionId: '11111111-1111-1111-8111-111111111111' } },
    { name: 'missing year', value: { ...A, coYear: undefined } },
    { name: 'empty year', value: { ...A, coYear: '' } },
    { name: 'ten character year', value: { ...A, coYear: '2024-20255' } },
    { name: 'year terminal newline', value: { ...A, coYear: '2024\n' } },
    { name: 'unknown authority', value: { ...A, mode: 'A' } },
    { name: 'array', value: [A] },
    { name: 'null', value: null },
  ])('refuses $name', ({ value }) => expect(parseBrowserSessionContext(value)).toBeNull());

  it('rejects accessors/inherited/symbol fields without invoking the accessor', () => {
    const read = vi.fn(() => '7');
    const accessor = { ...A };
    Object.defineProperty(accessor, 'contextEpoch', { enumerable: true, get: read });
    expect(parseBrowserSessionContext(accessor)).toBeNull();
    expect(read).not.toHaveBeenCalled();
    expect(parseBrowserSessionContext(Object.create(A))).toBeNull();
    expect(parseBrowserSessionContext({ ...A, [Symbol('extra')]: 'unexpected' })).toBeNull();
  });

  it('detaches pinned data and freezes every exposed state, descriptor and ticket', () => {
    const guard = createPageContextGuard();
    const supplied = { ...A };
    guard.observe(supplied);
    supplied.coCode = '09';
    const state = guard.read();
    expect(state.context).toEqual(A);
    expect(Object.isFrozen(state)).toBe(true);
    expect(Object.isFrozen(state.context)).toBe(true);
    expect(Object.isFrozen(guard.capture())).toBe(true);
    expect(() => Object.assign(state.context!, { contextEpoch: '999' })).toThrow();
  });

  it('notifies subscribers only for transitions and supports explicit unsubscription', () => {
    const guard = createPageContextGuard();
    const changed = vi.fn();
    const unsubscribe = guard.subscribe(changed);
    guard.observe(A);
    guard.observe({ ...A });
    guard.observe(independent.contexts.B);
    expect(changed).toHaveBeenCalledTimes(2);
    expect(guard.read().observed).toEqual(independent.contexts.B);
    unsubscribe();
    guard.resetForNavigation();
    expect(changed).toHaveBeenCalledTimes(2);
  });
});
