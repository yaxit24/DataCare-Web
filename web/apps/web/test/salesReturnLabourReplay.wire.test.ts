import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import type { BrowserSessionContext } from '../lib/pageContext';
import type { SavedIncomingReturn } from '../lib/salesReturnForm';
import {
  readReturnLabourReplayState,
  returnLabourAppendRequest,
  returnLabourInitialPrefix,
  returnLabourObserveRequest,
  returnLabourReplayPath,
} from '../lib/salesReturnLabourReplay';

const wireBytes = readFileSync(
  new URL('./fixtures/saleReturnLabourReplay.wire.json', import.meta.url),
);
function fixture() {
  return JSON.parse(wireBytes.toString('utf8')) as {
    saved: SavedIncomingReturn & { scope: { tenantId: string } };
    state: {
      context: BrowserSessionContext & { coYear: string };
      scope: Record<string, string>;
      [key: string]: unknown;
    };
  };
}

describe('real saved metadata and labour-state wire scope compatibility', () => {
  it('pins the unchanged synthetic real-browser response capture', () => {
    expect(createHash('sha256').update(wireBytes).digest('hex')).toBe(
      'db718afe6248e75a0dc81eb5dfbb872042fadeb50c95d21d9ed49d45038120cb',
    );
  });

  it('accepts the four-field response against saved metadata carrying tenantId without mutation', () => {
    const { saved, state } = fixture();
    const before = JSON.stringify({ saved, state });
    expect(saved.scope.tenantId).toBe('browser-parity');
    const parsed = readReturnLabourReplayState(state, saved, state.context);
    expect(parsed).toEqual(state);
    expect(Object.keys(parsed.scope).sort()).toEqual(['coBook', 'coCode', 'coYear', 'lcCode']);
    expect(parsed.capabilities.canPreview).toBe(true);
    expect(returnLabourInitialPrefix(parsed, parsed.rows[0]!.rowIdentity)).not.toBeNull();
    expect(JSON.stringify({ saved, state })).toBe(before);
  });

  it('retains compatibility with the already supported four-field saved scope', () => {
    const { saved, state } = fixture();
    const { tenantId: _tenantId, ...scope } = saved.scope;
    expect(readReturnLabourReplayState(state, { ...saved, scope }, state.context)).toEqual(state);
  });

  it('continues refusing an additional response scope field even when it equals saved tenantId', () => {
    const { saved, state } = fixture();
    state.scope.tenantId = saved.scope.tenantId;
    expect(() => readReturnLabourReplayState(state, saved, state.context)).toThrow();
  });

  it.each(['coCode', 'lcCode', 'coYear', 'coBook'] as const)(
    'continues binding the response to the exact saved %s',
    (field) => {
      const { saved, state } = fixture();
      state.scope[field] += '-different';
      expect(() => readReturnLabourReplayState(state, saved, state.context)).toThrow();
    },
  );

  it('continues refusing a missing owned response scope field', () => {
    const { saved, state } = fixture();
    delete state.scope.coBook;
    expect(() => readReturnLabourReplayState(state, saved, state.context)).toThrow();
  });

  it('keeps tenant authority out of all query paths and both generated request envelopes', () => {
    const { saved, state: rawState } = fixture();
    const state = readReturnLabourReplayState(rawState, saved, rawState.context);
    const rowIdentity = state.rows[0]!.rowIdentity;
    const prefix = returnLabourInitialPrefix(state, rowIdentity)!;
    for (const action of ['state', 'observe', 'append'] as const) {
      const query = new URL(returnLabourReplayPath(saved, action), 'http://example.invalid')
        .searchParams;
      expect([...query.keys()].sort()).toEqual(['coBook', 'coCode', 'coYear', 'lcCode']);
      expect(Object.fromEntries(query)).toEqual(state.scope);
      expect(query.has('tenantId')).toBe(false);
    }
    const observe = returnLabourObserveRequest(
      state,
      rowIdentity,
      prefix,
      'x13.primary-incoming.c13',
      'BB',
    );
    const append = returnLabourAppendRequest(state, rowIdentity, prefix, {
      kind: 'moneyLeave',
      fieldId: 'x13.primary-incoming.c27',
      editorText: '1',
    });
    expect(Object.keys(observe).sort()).toEqual([
      'baseVersion',
      'editorText',
      'events',
      'fieldId',
      'prefixVersion',
      'rowIdentity',
    ]);
    expect(Object.keys(append).sort()).toEqual([
      'baseVersion',
      'event',
      'events',
      'prefixVersion',
      'rowIdentity',
    ]);
    expect(JSON.stringify({ observe, append })).not.toContain(saved.scope.tenantId);
  });
});
