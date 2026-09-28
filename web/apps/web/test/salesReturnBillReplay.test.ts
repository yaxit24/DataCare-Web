import { describe, expect, it } from 'vitest';
import { ApiError } from '../lib/api';
import type { SavedIncomingReturn } from '../lib/salesReturnForm';
import {
  ReturnReplayGuard,
  returnReplayBaseline,
  returnReplayFailure,
  returnReplayFieldId,
  returnReplayFields,
  type ReturnReplayRequest,
  type ReturnReplayState,
} from '../lib/salesReturnReplay';
import {
  readReturnBillReplayState,
  readReturnBillReplayResult,
  returnBillReplayPath,
  returnBillReplayRequest,
  SavedReturnPreviewOwnership,
  type ReturnBillPhase,
  type ReturnBillReplayState,
  type ReturnBillReplayResult,
} from '../lib/salesReturnBillReplay';

const token = (letter: string) => letter.repeat(64);
const cacheColumns = [45, 46, 47, 48, 49, 58, 66, 67];
function rowFixture() {
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

function fixture() {
  const { document, state: original } = rowFixture();
  document.header.raw = {
    ...document.header.raw,
    RTN_NET_AMT: '9999999999999999.99',
    NET_AMT: '0.00',
    TAX_AMT: null,
    RTN_TOT_AMT: '',
    TOT_AMT: '0',
    RTN_BILL_OS: '10.000',
    BILL_OS: '0.000',
  };
  const rowReplay = structuredClone(original);
  const loaded: ReturnBillPhase = {
    incomingTotals: Object.fromEntries(Array.from({ length: 71 }, (_, c) => [String(c), ''])),
    bill: {
      matrix: [
        ['', '', '', 'Payment    ', 'Received    ', ''],
        ['Net Amt : ', '', '', '', '', ''],
        ['Sale Tax : ', '', '10.00', '7.00', '', 'T1'],
        ['Total Amt : ', '', '', '117.00', '0.00', ''],
        ['Cheque Amt : ', 'Bank', '000031', '0.00', '0.00', 'B1'],
        ['Card Amt : ', '', '', '0.00', '0.00', 'C1'],
        ['Cash Amt : ', '', '', '0.00', '0.00', ''],
        ['Kasar Amt : ', '', '', '0.00', '0.00', ''],
        ['Out Standing : ', '', '', '117.00', '0.00', ''],
      ],
      oldNetAmt: '110',
      oldTaxPrc: '10',
      incomingRounded: '110.00',
      outgoingRounded: '0.00',
      closing: {
        status: 'unavailable',
        amount: null,
        label: null,
        color: 'unknown',
        reason: 'Customer balance requires a resolved ledger mode.',
      },
    },
  };
  const opened = structuredClone(loaded);
  opened.incomingTotals['38'] = '110.00';
  const matrix = opened.bill.matrix.map((row) => [...row]);
  matrix[1]![3] = '110.00';
  matrix[1]![4] = '0.00';
  opened.bill = { ...opened.bill, matrix };
  const state: ReturnBillReplayState = {
    contractVersion: 'x13-saved-incoming-bill-replay-v1',
    profile: 'saved-primary-incoming-bill-preview-v1',
    scope: structuredClone(document.scope),
    voucherNo: document.voucherNo,
    replayVersion: token('e'),
    documentVersion: document.version,
    configurationVersion: rowReplay.configurationVersion,
    rowReplay,
    savedHeader: structuredClone(document.header.raw),
    headerProjectionVersion: 'sale-return-bill-projection-v1',
    taxPolicy: {
      version: 'sale-return-company-open-tax-policy-v1',
      profile: 'sql-int32-text-and-null-v1',
      status: 'ready',
      raw: { 'CO_SET.TAX_ROF': '2', 'CO_SET.ALL_ROF_REMOVE': 'N' },
      provenance: [
        { stage: 'int32-conversion', inputKind: 'canonical-sql-int32-text', value: '2' },
        { stage: 'greater-than-five-fallback', applied: false, before: '2', after: '2' },
        { stage: 'all-rounding-flag', inputKind: 'canonical-flag', value: 'N' },
        { stage: 'all-rounding-override', applied: false, before: '2', after: '2' },
      ],
      policy: { version: 'sale-return-company-open-tax-policy-v1', taxRoundingDecimals: 2 },
      diagnostics: [],
    },
    phases: { loaded, opened },
    diagnostics: [],
    capabilities: { canPreviewBill: true, canPreviewClosing: false, canSaveNumeric: false },
  };
  return { document, state, row: rowReplay.rows[0]! };
}
function response(
  state: ReturnBillReplayState,
  request: ReturnReplayRequest,
): ReturnBillReplayResult {
  const row = state.rowReplay.rows[0]!;
  return {
    contractVersion: state.contractVersion,
    scope: structuredClone(state.scope),
    voucherNo: state.voucherNo,
    replayVersion: state.replayVersion,
    documentVersion: state.documentVersion,
    configurationVersion: state.configurationVersion,
    rowIdentity: row.rowIdentity,
    baseline: structuredClone(returnReplayBaseline(row)!),
    preview: structuredClone(returnReplayBaseline(row)!),
    phases: {
      loaded: structuredClone(state.phases.loaded!),
      opened: structuredClone(state.phases.opened!),
      preview: structuredClone(state.phases.opened!),
    },
    events: request.events.map((event) => ({ ...event, status: 'applied' })),
    capabilities: { canPreviewClosing: false, canSaveNumeric: false },
  };
}
const event = (editorText = '1.00', column = 27) => ({
  fieldId: returnReplayFieldId(column),
  editorText,
});

// These fixtures test the wire boundary, not independent arithmetic acceptance.
describe('totals and bill trusted observation', () => {
  it('preserves exact saved NULL/blank/large strings, loaded blank net cells and distinct opening values', () => {
    const { document, state } = fixture();
    const before = structuredClone({ document, state });
    expect(readReturnBillReplayState(state, document)).toBe(state);
    expect(state.savedHeader.RTN_NET_AMT).toBe('9999999999999999.99');
    expect(state.savedHeader.TAX_AMT).toBeNull();
    expect(state.savedHeader.RTN_TOT_AMT).toBe('');
    expect(state.phases.loaded!.bill.matrix[1]!.slice(3, 5)).toEqual(['', '']);
    expect(state.phases.opened!.bill.matrix[1]!.slice(3, 5)).toEqual(['110.00', '0.00']);
    expect(state.phases.loaded!.bill.matrix[0]![3]).toBe('Payment    ');
    expect({ document, state }).toEqual(before);
  });
  it.each(['coCode', 'lcCode', 'coYear', 'coBook'] as const)(
    'rejects different outer %s even when embedded identity matches',
    (key) => {
      const { state, document } = fixture();
      state.scope[key] = 'OTHER';
      expect(() => readReturnBillReplayState(state, document)).toThrow('does not match');
    },
  );
  it.each([
    'voucherNo',
    'documentVersion',
    'configurationVersion',
    'replayVersion',
    'headerProjectionVersion',
    'profile',
    'contractVersion',
  ])('rejects malformed or stale %s', (key) => {
    const { state, document } = fixture();
    expect(() => readReturnBillReplayState({ ...state, [key]: 'wrong' }, document)).toThrow();
  });
  it('rejects mismatched embedded document/config/master observation and saved-header normalization', () => {
    const { state, document } = fixture();
    state.rowReplay.documentVersion = token('f');
    expect(() => readReturnBillReplayState(state, document)).toThrow();
    state.rowReplay.documentVersion = document.version;
    state.savedHeader.TAX_AMT = '';
    expect(() => readReturnBillReplayState(state, document)).toThrow();
  });
  it.each(['loaded', 'opened'] as const)(
    'requires all 71 total cells in %s, including untouched columns',
    (phase) => {
      const { state, document } = fixture();
      delete state.phases[phase]!.incomingTotals['70'];
      expect(() => readReturnBillReplayState(state, document)).toThrow();
    },
  );
  it.each([
    (phase: ReturnBillPhase) => {
      (phase.bill.matrix as string[][]).pop();
    },
    (phase: ReturnBillPhase) => {
      (phase.bill.matrix as string[][])[4]!.pop();
    },
    (phase: ReturnBillPhase) => {
      (phase.bill.matrix as unknown[][])[4]![3] = 0;
    },
    (phase: ReturnBillPhase) => {
      delete (phase.bill as unknown as Record<string, unknown>).oldTaxPrc;
    },
    (phase: ReturnBillPhase) => {
      phase.incomingTotals['71'] = '';
    },
    (phase: ReturnBillPhase) => {
      (phase.bill as unknown as Record<string, unknown>).oldNetAmt = 110;
    },
  ])('rejects partial or numerically coerced phase %s', (mutate) => {
    const { state, document } = fixture();
    mutate(state.phases.loaded!);
    expect(() => readReturnBillReplayState(state, document)).toThrow();
  });
  it('keeps unsupported phases null and never grants v2 from the embedded v1 capability', () => {
    const { state, document, row } = fixture();
    state.capabilities.canPreviewBill = false;
    state.phases.opened = null;
    expect(state.rowReplay.capabilities.canPreview).toBe(true);
    expect(readReturnBillReplayState(state, document)).toBe(state);
    expect(() => returnBillReplayRequest(state, row, [], event())).toThrow('cannot preview');
    state.phases.loaded = null;
    expect(readReturnBillReplayState(state, document)).toBe(state);
    state.capabilities.canPreviewBill = true;
    expect(() => readReturnBillReplayState(state, document)).toThrow();
  });
  it('requires a loaded phase before an opening phase even when read-only', () => {
    const { state, document } = fixture();
    state.capabilities.canPreviewBill = false;
    state.phases.loaded = null;
    expect(() => readReturnBillReplayState(state, document)).toThrow();
  });
  it('accepts a complete matched empty document only without preview capability', () => {
    const { state, document } = fixture();
    document.lines = [];
    document.provenance.incomingLineCount = 0;
    state.rowReplay.rows = [];
    state.rowReplay.capabilities.canPreview = false;
    state.capabilities.canPreviewBill = false;
    state.phases = { loaded: state.phases.loaded, opened: null };
    expect(readReturnBillReplayState(state, document)).toBe(state);
  });
  it.each([
    { status: 'resolved', amount: '0.00', label: '0.00 Dr', color: 'Red' },
    { status: 'unavailable', amount: '0', label: null, color: 'unknown', reason: 'Not ready' },
    { status: 'unavailable', amount: null, label: null, color: 'unknown', reason: ' ' },
  ])('rejects invented closing balance %s', (closing) => {
    const { state, document } = fixture();
    const changed = structuredClone(state) as unknown as {
      phases: { loaded: { bill: { closing: unknown } } };
    };
    changed.phases.loaded.bill.closing = closing;
    expect(() => readReturnBillReplayState(changed, document)).toThrow();
  });
  it.each(['canSaveNumeric', 'canPreviewClosing'] as const)(
    'rejects unexpected %s authority',
    (key) => {
      const { state, document } = fixture();
      expect(() =>
        readReturnBillReplayState(
          { ...state, capabilities: { ...state.capabilities, [key]: true } },
          document,
        ),
      ).toThrow();
    },
  );
  it('keeps unsupported tax diagnostics and blocks opening preview without inventing tax precision', () => {
    const { state, document } = fixture();
    state.taxPolicy = {
      version: 'sale-return-company-open-tax-policy-v1',
      profile: 'sql-int32-text-and-null-v1',
      status: 'unsupported',
      raw: null,
      provenance: [],
      policy: null,
      diagnostics: [{ code: 'invalid-tax-policy-input', message: 'Tax settings are ambiguous.' }],
    };
    state.capabilities.canPreviewBill = false;
    state.phases.opened = null;
    expect(readReturnBillReplayState(state, document)).toBe(state);
    state.capabilities.canPreviewBill = true;
    expect(() => readReturnBillReplayState(state, document)).toThrow();
  });
  it.each([
    { policy: { version: 'sale-return-company-open-tax-policy-v1', taxRoundingDecimals: '2' } },
    { policy: { version: 'sale-return-company-open-tax-policy-v1', taxRoundingDecimals: 6 } },
    { raw: { TAX_ROF: '2', ALL_ROF_REMOVE: 'N' } },
    { provenance: [] },
    { diagnostics: [{ code: 'bad', message: 'not ready' }] },
  ])('rejects partial/malformed ready tax policy %s', (changes) => {
    const { state, document } = fixture();
    expect(() =>
      readReturnBillReplayState(
        { ...state, taxPolicy: { ...state.taxPolicy, ...changes } },
        document,
      ),
    ).toThrow();
  });
  it('sends explicit complete scope through distinct v2 paths and refuses normalized voucher keys', () => {
    const { document } = fixture();
    const path = returnBillReplayPath(document);
    expect(path).toContain('/sales-returns/00001/incoming-bill-replay-state?');
    const query = new URL(path, 'http://local.invalid').searchParams;
    expect(Object.fromEntries(query)).toEqual(document.scope);
    expect(returnBillReplayPath(document, 'preview')).toContain('/incoming-bill-replay?');
    for (const voucherNo of ['1', '00000', '00001\n'])
      expect(() => returnBillReplayPath({ ...document, voucherNo })).toThrow();
  });
});

describe('explicit whole-journal bill preview requests and results', () => {
  it('uses the outer token, retains repeated, blank and spaced events, and never sends policy/phase/cache fields', () => {
    const { state, row } = fixture();
    const before = structuredClone(state);
    const accepted = [event('1'), event('1'), event(''), event(' 0 ')];
    const request = returnBillReplayRequest(state, row, accepted, event('0'));
    expect(request).toEqual({
      replayVersion: token('e'),
      rowIdentity: token('d'),
      events: [...accepted, event('0')],
    });
    expect(request.replayVersion).not.toBe(state.rowReplay.replayVersion);
    expect(accepted).toHaveLength(4);
    expect(state).toEqual(before);
    const result = response(state, request);
    result.events[2]!.status = 'skipped';
    expect(readReturnBillReplayResult(result, state, row, request)).toBe(result);
  });
  it.each(['\n', '1\t', '\u00a0', '1\u2000', '1\u2028', '1,2', '1e2', '12345678901'])(
    'retains and rejects invalid transport text %j',
    (editorText) => {
      const { state, row } = fixture();
      const draft = event(editorText);
      expect(() => returnBillReplayRequest(state, row, [], draft)).toThrow();
      expect(draft.editorText).toBe(editorText);
    },
  );
  it('preserves an oversized saved editor until deliberate shorter replacement; focus cannot create a journal', () => {
    const { state, row } = fixture();
    row.editorTextByField![returnReplayFieldId(20)] = '9999999999999999.99';
    const history: ReturnReplayRequest['events'] = [];
    expect(history).toEqual([]);
    expect(() =>
      returnBillReplayRequest(
        state,
        row,
        history,
        event(row.editorTextByField![returnReplayFieldId(20)]!, 20),
      ),
    ).toThrow();
    expect(row.editorTextByField![returnReplayFieldId(20)]).toBe('9999999999999999.99');
    expect(returnBillReplayRequest(state, row, history, event('1200', 20)).events).toEqual([
      event('1200', 20),
    ]);
  });
  it('rejects a detached row, denied field, malformed accepted event and journal over 100', () => {
    const { state, row } = fixture();
    expect(() => returnBillReplayRequest(state, structuredClone(row), [], event())).toThrow();
    expect(() => returnBillReplayRequest(state, row, [], event('1', 10))).toThrow();
    expect(() => returnBillReplayRequest(state, row, [event('1e2')], event())).toThrow();
    expect(() =>
      returnBillReplayRequest(
        state,
        row,
        Array.from({ length: 100 }, () => event()),
        event(),
      ),
    ).toThrow('100');
    expect(
      returnBillReplayRequest(
        state,
        row,
        Array.from({ length: 99 }, () => event()),
        event(),
      ).events,
    ).toHaveLength(100);
  });
  it.each(['rowIdentity', 'replayVersion', 'documentVersion', 'configurationVersion'] as const)(
    'rejects result mismatch %s',
    (key) => {
      const { state, row } = fixture();
      const request = returnBillReplayRequest(state, row, [], event());
      expect(() =>
        readReturnBillReplayResult(
          { ...response(state, request), [key]: token('f') },
          state,
          row,
          request,
        ),
      ).toThrow();
    },
  );
  it.each(['loaded', 'opened'] as const)(
    'rejects a changed previously observed %s phase',
    (phase) => {
      const { state, row } = fixture();
      const request = returnBillReplayRequest(state, row, [], event());
      const result = response(state, request);
      result.phases[phase].incomingTotals['70'] = '1';
      expect(() => readReturnBillReplayResult(result, state, row, request)).toThrow();
    },
  );
  it('rejects incomplete preview, altered baseline, reordered events and normalized text', () => {
    const { state, row } = fixture();
    const request = returnBillReplayRequest(state, row, [event(' 1 ')], event('2'));
    let result = response(state, request);
    delete result.preview.caches['58'];
    expect(() => readReturnBillReplayResult(result, state, row, request)).toThrow();
    result = response(state, request);
    result.baseline.visible['20'] = '0';
    expect(() => readReturnBillReplayResult(result, state, row, request)).toThrow();
    result = response(state, request);
    result.events.reverse();
    expect(() => readReturnBillReplayResult(result, state, row, request)).toThrow();
    result = response(state, request);
    result.events[0]!.editorText = '1';
    expect(() => readReturnBillReplayResult(result, state, row, request)).toThrow();
  });
  it('blocks embedded-token requests from being paired with v2 results', () => {
    const { state, row } = fixture();
    const request = returnBillReplayRequest(state, row, [], event());
    const result = response(state, request);
    request.replayVersion = state.rowReplay.replayVersion;
    expect(() => readReturnBillReplayResult(result, state, row, request)).toThrow();
  });
});

describe('exclusive preview lifecycle', () => {
  it('returns rejected activation when current metadata/operation eligibility changes before the next disabled render', () => {
    const owner = new SavedReturnPreviewOwnership();
    const current = { context: 1, generation: 7 };
    owner.observe(current);
    expect(owner.change(current, 'bill', true, false)).toBe(false);
    expect(owner.active(current)).toBeNull();
    expect(owner.change(current, 'row', true, false)).toBe(false);
    expect(owner.active(current)).toBeNull();
    expect(owner.change(current, 'bill', true, true)).toBe(true);
    // Closing remains possible even if metadata/operation eligibility changed meanwhile.
    expect(owner.change(current, 'bill', false, false)).toBe(true);
    expect(owner.active(current)).toBeNull();
  });

  it('prevents same-render second ownership and stale row close from unlocking active bill metadata', () => {
    const owner = new SavedReturnPreviewOwnership();
    const context = { context: 1, generation: 2 };
    owner.observe(context);
    expect(owner.change(context, 'row', true)).toBe(true);
    expect(owner.change(context, 'bill', true)).toBe(false);
    expect(owner.active(context)).toBe('row');
    expect(owner.change(context, 'row', false)).toBe(true);
    expect(owner.change(context, 'bill', true)).toBe(true);
    expect(owner.change(context, 'row', false)).toBe(false);
    expect(owner.active(context)).toBe('bill');
  });
  it('invalidates A→B→A generations and identical-version authoritative rehydration without stale reacquisition', () => {
    const owner = new SavedReturnPreviewOwnership();
    const a = { context: 1, generation: 1 },
      b = { context: 2, generation: 2 },
      newA = { context: 3, generation: 3 };
    owner.observe(a);
    owner.change(a, 'bill', true);
    owner.observe(b);
    owner.observe(newA);
    expect(owner.change(a, 'bill', true)).toBe(false);
    expect(owner.active(newA)).toBeNull();
    owner.change(newA, 'row', true);
    const hydrated = { ...newA, generation: 4 };
    owner.observe(hydrated);
    expect(owner.active(hydrated)).toBeNull();
    expect(owner.change(newA, 'row', false)).toBe(false);
    owner.clear();
    expect(owner.change(hydrated, 'bill', true)).toBe(false);
  });
  it('rejects delayed state/result/error/focus after close, newer request, scope return or unmount', () => {
    const { document } = fixture();
    const guard = new ReturnReplayGuard();
    guard.observe(document);
    const first = guard.begin();
    guard.invalidate();
    const closeFocus = guard.begin();
    const reopened = guard.begin();
    expect(guard.current(first)).toBe(false);
    expect(guard.current(closeFocus)).toBe(false);
    expect(guard.current(reopened)).toBe(true);
    guard.observe({ ...document, scope: { ...document.scope, coBook: 'R92' } });
    guard.observe(document);
    expect(guard.current(reopened)).toBe(false);
    const pending = guard.begin();
    guard.invalidate();
    expect(guard.current(pending)).toBe(false);
  });
  it.each([401, 403, 404, 409, 500, 502, 503])(
    'requires deliberate reload after uncertain/stale %s while preserving the draft',
    (status) => {
      const draft = event(' 1 ');
      const accepted = [event('0')];
      const failure = returnReplayFailure(
        new ApiError('failed', status, { message: 'Reload first' }),
      );
      expect(failure.needsReload).toBe(true);
      expect(failure.conflict).toBe(status === 409);
      expect(draft).toEqual(event(' 1 '));
      expect(accepted).toEqual([event('0')]);
    },
  );
  it('keeps recoverable 422 entered draft and accepted prefix without promoting recovery partials to success', () => {
    const failure = returnReplayFailure(
      new ApiError('unsupported', 422, {
        message: 'Unsupported calculation',
        details: { preview: { bogus: true } },
      }),
    );
    expect(failure.needsReload).toBe(false);
    expect(failure.message).toBe('Unsupported calculation');
    expect(returnReplayFailure(new Error('network lost')).needsReload).toBe(true);
    expect(returnReplayFailure(new Error('malformed response'), true).needsReload).toBe(true);
  });
});
