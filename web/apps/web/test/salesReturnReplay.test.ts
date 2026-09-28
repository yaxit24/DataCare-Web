import { describe, expect, it } from 'vitest';
import { ApiError } from '../lib/api';
import { readSavedIncomingReturn, type SavedIncomingReturn } from '../lib/salesReturnForm';
import {
  readReturnReplayResult,
  readReturnReplayState,
  ReturnReplayGuard,
  returnReplayBaseline,
  returnReplayFailure,
  returnReplayFieldId,
  returnReplayFields,
  returnReplayPath,
  returnReplayRequest,
  type ReturnReplayResult,
  type ReturnReplayState,
} from '../lib/salesReturnReplay';

const token = (letter: string) => letter.repeat(64);
const cacheColumns = [45, 46, 47, 48, 49, 58, 66, 67];
function fixture() {
  const scope = { coCode: '01', lcCode: '02', coYear: '2024', coBook: 'R91' };
  const rawScope = {
    CO_CODE: '01',
    LC_CODE: '02',
    CO_YEAR: '2024',
    CO_BOOK: 'R91',
    VCH_NO: '00001',
  };
  const identity = {
    srNo: '17',
    oldSrNo: '31',
    vchSrno: '117',
    tagSrNo: '0',
    itCode: 'GOLD',
    tagNo: 'N',
  };
  const raw = {
    ...rawScope,
    SR_NO: '17',
    OLD_SRNO: '31',
    VCH_SRNO: '117',
    TAG_SRNO: '0',
    IT_CODE: 'GOLD',
    TAG_NO: 'N',
    ITM_REMARK: null,
    HM_ID: '',
    ITM_AMT: '9999999999999999.99',
    ITM_GWT: '1.234',
    LBR_PRC: '9.876',
    NET_AMT: '7.000',
  };
  const yes = () => ({ allowed: true, reason: null });
  const document: SavedIncomingReturn = {
    scope,
    voucherNo: '00001',
    version: token('a'),
    canUpdate: false,
    capabilities: { canUpdate: true, reason: null },
    header: {
      raw: { ...rawScope, EMP_CODE: '' },
      display: { employeeName: null, employeeNameReason: null },
      capabilities: { employeeCode: yes() },
    },
    lines: [
      {
        identity,
        raw,
        display: { itemName: 'Gold', itemNameReason: null, description: 'Gold' },
        capabilities: { huid: yes(), description: yes() },
      },
    ],
    related: {
      outgoingLines: [],
      outgoingComponents: [],
      tagHeaders: [],
      tagParents: [],
      tagComponents: [],
    },
    provenance: {
      incomingLineCount: 1,
      outgoingLineCount: 0,
      outgoingComponentCount: 0,
      tagHeaderCount: 0,
      tagParentCount: 0,
      tagComponentCount: 0,
    },
  };
  const visible = Object.fromEntries(
    Array.from({ length: 71 }, (_, column) => column)
      .filter((column) => !cacheColumns.includes(column))
      .map((column) => [column, '0.00']),
  );
  visible['21'] = '9.876';
  visible['20'] = '9999999999999999.99';
  const state: ReturnReplayState = {
    contractVersion: 'x13-saved-incoming-replay-v1',
    profile: 'saved-primary-incoming-money-preview-v1',
    scope,
    voucherNo: '00001',
    replayVersion: token('b'),
    documentVersion: document.version,
    configurationVersion: token('c'),
    configuration: {
      scope,
      version: token('c'),
      columns: Array.from({ length: 71 }, (_, column) => ({
        id: returnReplayFieldId(column),
        sourceColumn: column,
        label: `Configured ${column}`,
        originalLabel: `Original ${column}`,
        widthState: 'nonzero' as const,
      })),
      capabilities: { canCalculate: true, canSaveNumeric: false },
      diagnostics: [],
    },
    rows: [
      {
        identity,
        rowIdentity: token('d'),
        raw,
        visible,
        caches: Object.fromEntries(cacheColumns.map((column) => [column, '0.00'])),
        editorTextByField: Object.fromEntries(
          returnReplayFields.map((column) => [
            returnReplayFieldId(column),
            column === 21 ? '9.88' : '0.00',
          ]),
        ),
        fieldCapabilities: returnReplayFields.map((column) => ({
          fieldId: returnReplayFieldId(column),
          ...yes(),
          maxLength: 10,
          editorDecimals: 2,
        })),
        diagnostics: [],
      },
    ],
    capabilities: { canPreview: true, canSaveNumeric: false },
  };
  return { document, state, row: state.rows[0]! };
}
function response(
  state: ReturnReplayState,
  events = [{ fieldId: returnReplayFieldId(19), editorText: '2.00' }],
): ReturnReplayResult {
  const row = state.rows[0]!;
  return {
    contractVersion: state.contractVersion,
    scope: state.scope,
    voucherNo: state.voucherNo,
    replayVersion: state.replayVersion,
    documentVersion: state.documentVersion,
    configurationVersion: state.configurationVersion,
    rowIdentity: row.rowIdentity,
    baseline: structuredClone(returnReplayBaseline(row)!),
    preview: structuredClone(returnReplayBaseline(row)!),
    events: events.map((event) => ({ ...event, status: 'applied' })),
    aggregateRequired: true,
    capabilities: { canSaveNumeric: false },
  };
}

describe('trusted saved Return replay observations', () => {
  it('preserves raw precision, NULL, independent source editor text and read-only metadata permission', () => {
    const { document, state } = fixture();
    const before = structuredClone({ document, state });
    expect(readReturnReplayState(state, document)).toBe(state);
    expect(state.rows[0]!.visible!['21']).toBe('9.876');
    expect(state.rows[0]!.editorTextByField![returnReplayFieldId(21)]).toBe('9.88');
    expect(state.rows[0]!.raw.ITM_AMT).toBe('9999999999999999.99');
    expect(state.rows[0]!.raw.ITM_REMARK).toBeNull();
    expect(document.canUpdate).toBe(false);
    expect({ document, state }).toEqual(before);
  });

  it.each(['coCode', 'lcCode', 'coYear', 'coBook'] as const)(
    'rejects mismatched full scope %s',
    (key) => {
      const { document, state } = fixture();
      state.scope = { ...state.scope, [key]: 'OTHER' };
      expect(() => readReturnReplayState(state, document)).toThrow('does not match');
    },
  );

  it.each(['replayVersion', 'documentVersion', 'configurationVersion'] as const)(
    'rejects malformed %s',
    (key) => {
      const { document, state } = fixture();
      state[key] = 'not-a-token';
      expect(() => readReturnReplayState(state, document)).toThrow();
    },
  );

  it('requires matching embedded configuration and source catalog, refusing caption-as-ID or duplicate columns', () => {
    const { document, state } = fixture();
    state.configuration.version = token('e');
    expect(() => readReturnReplayState(state, document)).toThrow();
    state.configuration.version = state.configurationVersion;
    state.configuration.columns[19]!.id = 'Configured 19';
    expect(() => readReturnReplayState(state, document)).toThrow();
    state.configuration.columns[19] = state.configuration.columns[20]!;
    expect(() => readReturnReplayState(state, document)).toThrow();
  });

  it('requires complete saved row/raw identity and refuses row omission or raw normalization', () => {
    const { document, state } = fixture();
    state.rows[0] = structuredClone(state.rows[0]!);
    state.rows[0]!.identity.oldSrNo = '17';
    expect(() => readReturnReplayState(state, document)).toThrow();
    state.rows[0]!.identity.oldSrNo = '31';
    state.rows[0]!.raw.ITM_REMARK = '';
    expect(() => readReturnReplayState(state, document)).toThrow();
    state.rows = [];
    expect(() => readReturnReplayState(state, document)).toThrow();
  });

  it('retains unsupported rows only with null snapshots and false field capabilities', () => {
    const { document, state, row } = fixture();
    row.visible = row.caches = row.editorTextByField = null;
    row.fieldCapabilities.forEach((cap) => {
      cap.allowed = false;
      cap.reason = 'Unsupported saved numeric NULL.';
    });
    row.diagnostics.push({
      code: 'unsupported-numeric-null',
      message: 'Saved numeric NULL requires desktop proof.',
    });
    expect(readReturnReplayState(state, document)).toBe(state);
    expect(returnReplayBaseline(row)).toBeNull();
    row.fieldCapabilities[0]!.allowed = true;
    expect(() => readReturnReplayState(state, document)).toThrow();
  });

  it('accepts a matched empty saved header with no incoming preview capability, without treating omitted rows as empty', () => {
    const { document, state } = fixture();
    document.lines = [];
    document.provenance.incomingLineCount = 0;
    state.rows = [];
    state.capabilities.canPreview = false;
    expect(readSavedIncomingReturn(document, document.scope, document.voucherNo)).toBe(document);
    expect(readReturnReplayState(state, document)).toBe(state);
    state.capabilities.canPreview = true;
    expect(() => readReturnReplayState(state, document)).toThrow();
    document.provenance.incomingLineCount = 1;
    expect(() => readSavedIncomingReturn(document, document.scope, document.voucherNo)).toThrow();
  });

  it('retains valid projected values for a profile-denied row while refusing every field commit', () => {
    const { document, state, row } = fixture();
    state.capabilities.canPreview = false;
    row.fieldCapabilities.forEach((cap) => {
      cap.allowed = false;
      cap.reason = 'Tagged rows remain read-only.';
    });
    row.diagnostics.push({ code: 'unsupported-profile', message: 'Tagged rows remain read-only.' });
    expect(readReturnReplayState(state, document)).toBe(state);
    expect(returnReplayBaseline(row)?.visible['20']).toBe('9999999999999999.99');
    expect(() =>
      returnReplayRequest(state, row, [], { fieldId: returnReplayFieldId(19), editorText: '10' }),
    ).toThrow();
  });

  it('refuses hidden allowed fields and writable numeric capability, even with valid tokens', () => {
    const { document, state } = fixture();
    state.configuration.columns[19]!.widthState = 'zero';
    expect(() => readReturnReplayState(state, document)).toThrow();
    state.rows[0]!.fieldCapabilities[0]!.allowed = false;
    expect(readReturnReplayState(state, document)).toBe(state);
    expect(() =>
      readReturnReplayState(
        { ...state, capabilities: { canPreview: true, canSaveNumeric: true } },
        document,
      ),
    ).toThrow();
  });

  it('requires complete string-valued numeric source maps with exactly eight separate caches', () => {
    const { document, state, row } = fixture();
    row.caches!['41'] = '0.00';
    expect(() => readReturnReplayState(state, document)).toThrow();
    delete row.caches!['41'];
    delete row.visible!['41'];
    expect(() => readReturnReplayState(state, document)).toThrow();
  });

  it('uses exact five-digit saved identity and explicit scope in both routes', () => {
    const { document } = fixture();
    expect(returnReplayPath(document)).toBe(
      '/sales-returns/00001/incoming-replay-state?coCode=01&lcCode=02&coYear=2024&coBook=R91',
    );
    expect(returnReplayPath(document, 'preview')).toContain('/00001/incoming-replay?');
    expect(() => returnReplayPath({ ...document, voucherNo: '1' })).toThrow('five-digit');
  });
});

describe('explicit ordered completed-cell requests and recovery', () => {
  it('appends repeated same-value commits without rounding, deduplication, mutation or authority echoes', () => {
    const { state, row } = fixture();
    const event = { fieldId: returnReplayFieldId(36), editorText: '1.2345' };
    const prior = [event, { fieldId: returnReplayFieldId(19), editorText: '0.00' }];
    const before = structuredClone({ state, prior });
    expect(returnReplayRequest(state, row, prior, event)).toEqual({
      replayVersion: state.replayVersion,
      rowIdentity: row.rowIdentity,
      events: [event, prior[1], event],
    });
    expect({ state, prior }).toEqual(before);
  });

  it.each(['1,25', '1e3', '1x', 'NaN', '12345678901', '\t1', '1\n'])(
    'keeps invalid editor text %j without converting it or changing accepted journal',
    (text) => {
      const { state, row } = fixture();
      const before = structuredClone(state);
      expect(() =>
        returnReplayRequest(state, row, [], { fieldId: returnReplayFieldId(24), editorText: text }),
      ).toThrow('plain decimal');
      expect(state).toEqual(before);
    },
  );

  it.each(['', '  ', ' 1.25 '])(
    'preserves explicit blank-as-zero or whitespace input %j as an original completed event',
    (editorText) => {
      const { state, row } = fixture();
      const before = structuredClone(state);
      const event = { fieldId: returnReplayFieldId(24), editorText };
      expect(returnReplayRequest(state, row, [], event).events).toEqual([event]);
      expect(state).toEqual(before);
    },
  );

  it('refuses nonallowlisted actions, denied fields, wrong row objects and more than100 events', () => {
    const { state, row } = fixture();
    const event = { fieldId: returnReplayFieldId(19), editorText: '0.00' };
    expect(() =>
      returnReplayRequest(state, row, [], { ...event, fieldId: returnReplayFieldId(10) }),
    ).toThrow();
    expect(() => returnReplayRequest(state, structuredClone(row), [], event)).toThrow();
    expect(() =>
      returnReplayRequest(
        state,
        row,
        Array.from({ length: 100 }, () => event),
        event,
      ),
    ).toThrow('100');
    row.fieldCapabilities[0]!.allowed = false;
    expect(() => returnReplayRequest(state, row, [], event)).toThrow();
  });

  it('preserves oversized loaded editor text, refuses its unchanged commit and permits deliberate short replacement', () => {
    const { document, state, row } = fixture();
    const fieldId = returnReplayFieldId(20);
    row.editorTextByField![fieldId] = '9999999999999999.99';
    const before = structuredClone(state);
    expect(readReturnReplayState(state, document)).toBe(state);
    expect(() =>
      returnReplayRequest(state, row, [], {
        fieldId,
        editorText: row.editorTextByField![fieldId]!,
      }),
    ).toThrow('10 characters');
    expect(returnReplayRequest(state, row, [], { fieldId, editorText: '1200.00' }).events).toEqual([
      { fieldId, editorText: '1200.00' },
    ]);
    expect(state).toEqual(before);
  });

  it('accepts only results for the original baseline, exact event order and same composite observation', () => {
    const { state, row } = fixture();
    const request = returnReplayRequest(state, row, [], {
      fieldId: returnReplayFieldId(19),
      editorText: '2.00',
    });
    const result = response(state);
    result.preview.visible['19'] = '2.00';
    expect(readReturnReplayResult(result, state, row, request)).toBe(result);
    result.baseline.visible['19'] = '2.00';
    expect(() => readReturnReplayResult(result, state, row, request)).toThrow();
    result.baseline.visible['19'] = '0.00';
    result.events[0]!.editorText = '2';
    expect(() => readReturnReplayResult(result, state, row, request)).toThrow();
    result.events[0]!.editorText = '2.00';
    result.rowIdentity = token('e');
    expect(() => readReturnReplayResult(result, state, row, request)).toThrow();
  });

  it('keeps server422 recoverable while stale, missing, access, network and malformed responses require reload', () => {
    expect(
      returnReplayFailure(new ApiError('failed', 422, { message: 'Zero denominator.' })),
    ).toEqual({ needsReload: false, conflict: false, message: 'Zero denominator.' });
    for (const status of [401, 403, 404, 409, 500, 502, 503])
      expect(returnReplayFailure(new ApiError('failed', status, {})).needsReload).toBe(true);
    expect(returnReplayFailure(new ApiError('failed', 409, {})).conflict).toBe(true);
    expect(returnReplayFailure(new Error('Connection lost')).needsReload).toBe(true);
    expect(returnReplayFailure(new ApiError('failed', 400, {}), true).needsReload).toBe(true);
  });

  it('invalidates delayed successes/errors/finally through A→B→A and document/close/new request generations', () => {
    const { document } = fixture();
    const guard = new ReturnReplayGuard();
    guard.observe(document);
    const first = guard.begin();
    guard.observe({ ...document, scope: { ...document.scope, coBook: 'R92' } });
    guard.observe(document);
    expect(guard.current(first)).toBe(false);
    const second = guard.begin();
    const newer = guard.begin();
    expect(guard.current(second)).toBe(false);
    expect(guard.current(newer)).toBe(true);
    guard.invalidate();
    expect(guard.current(newer)).toBe(false);
    const loadedAgain = guard.begin();
    guard.observe({ ...document, version: token('e') });
    expect(guard.current(loadedAgain)).toBe(false);
  });
});
