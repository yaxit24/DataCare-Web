import { describe, expect, it } from 'vitest';
import { saleReturnIncomingReplayInput } from '../src/modules/sales/saleReturnIncomingReplay.js';

const valid = () => ({
  replayVersion: 'a'.repeat(64),
  rowIdentity: 'b'.repeat(64),
  events: [] as unknown[],
});
describe('saved incoming replay strict transport profile', () => {
  it('detaches an empty request and retains ordered repeated original editor text', () => {
    const input = valid();
    input.events = [
      { fieldId: 'x13.primary-incoming.c24', editorText: ' 30.00 ' },
      { fieldId: 'x13.primary-incoming.c24', editorText: ' 30.00 ' },
    ];
    const parsed = saleReturnIncomingReplayInput(input);
    expect(parsed).toEqual(input);
    expect(parsed.events).not.toBe(input.events);
    expect(saleReturnIncomingReplayInput(valid()).events).toEqual([]);
  });
  it.each([
    null,
    [],
    1,
    'request',
    {},
    { ...valid(), cells: {} },
    { ...valid(), context: {} },
    { ...valid(), policy: {} },
    { ...valid(), source: {} },
  ])('rejects malformed/extra request %j', (input) => {
    expect(() => saleReturnIncomingReplayInput(input)).toThrowError(
      /must be an object|must contain only/,
    );
  });
  it.each(['A'.repeat(64), 'a'.repeat(63), '', 0, null])(
    'rejects noncanonical token %j',
    (token) => {
      expect(() =>
        saleReturnIncomingReplayInput({ ...valid(), replayVersion: token }),
      ).toThrowError(/hexadecimal/);
      expect(() => saleReturnIncomingReplayInput({ ...valid(), rowIdentity: token })).toThrowError(
        /hexadecimal/,
      );
    },
  );
  it.each([
    null,
    {},
    0,
    Array.from({ length: 101 }, () => ({ fieldId: 'x13.primary-incoming.c19', editorText: '1' })),
  ])('bounds journal %j', (events) => {
    expect(() => saleReturnIncomingReplayInput({ ...valid(), events })).toThrowError(
      /ordered array/,
    );
  });
  it.each([
    null,
    [],
    {},
    { fieldId: 19, editorText: '1' },
    { fieldId: 'Rate', editorText: '1' },
    { fieldId: 'x13.primary-incoming.c71', editorText: '1' },
    { fieldId: 'x13.primary-incoming.c19', editorText: 1 },
    { fieldId: 'x13.primary-incoming.c19', editorText: '12345678901' },
    { fieldId: 'x13.primary-incoming.c19', editorText: '1\n' },
    { fieldId: 'x13.primary-incoming.c19', editorText: '1', committedColumnWidth: 1 },
  ])('rejects malformed/forged event %j', (event) => {
    expect(() => saleReturnIncomingReplayInput({ ...valid(), events: [event] })).toThrow();
  });
  it('keeps a known unsupported field for a precise semantic422 instead of coercing it to a supported numeric field', () => {
    expect(
      saleReturnIncomingReplayInput({
        ...valid(),
        events: [{ fieldId: 'x13.primary-incoming.c01', editorText: 'GOLD' }],
      }).events[0]?.fieldId,
    ).toBe('x13.primary-incoming.c01');
  });
  it('accepts the exact resource boundary without truncating editor text', () => {
    const event = { fieldId: 'x13.primary-incoming.c19', editorText: '1234567.89' };
    expect(
      saleReturnIncomingReplayInput({
        ...valid(),
        events: Array.from({ length: 100 }, () => event),
      }).events,
    ).toHaveLength(100);
  });
});
