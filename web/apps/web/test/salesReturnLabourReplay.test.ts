import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import { ApiError } from '../lib/api';
import type { SavedIncomingReturn } from '../lib/salesReturnForm';
import { createPageContextGuard, type BrowserSessionContext } from '../lib/pageContext';
import {
  returnReplayFields,
  returnReplayFieldId,
  type ReturnReplayState,
} from '../lib/salesReturnReplay';
import {
  SavedReturnPreviewOwnership,
  type ReturnBillPhase,
  type ReturnBillReplayState,
} from '../lib/salesReturnBillReplay';
import {
  readReturnLabourReplayState,
  returnLabourReplayContract,
  returnLabourReplayProfile,
  returnLabourSemanticVersions,
  returnLabourFields,
  returnLabourInitialPrefix,
  returnLabourObserveRequest,
  returnLabourAppendRequest,
  readReturnLabourObservation,
  readReturnLabourReplayResult,
  requireReturnLabourPage,
  returnLabourReplayPath,
  validateReturnLabourRecovery,
  returnLabourFailure,
  ReturnLabourReplayLease,
  type ReturnLabourReplayState,
  type ReturnLabourObserveInput,
  type ReturnLabourAppendInput,
  type ReturnLabourPrefix,
  type ReturnLabourEvent,
} from '../lib/salesReturnLabourReplay';
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
const goldenBytes = readFileSync(
  new URL('./fixtures/saleReturnLabourReplay.independent.json', import.meta.url),
);
const golden = JSON.parse(goldenBytes.toString());
const context: BrowserSessionContext & { coYear: string } = {
  sessionId: 'aaaaaaaa-aaaa-4aaa-8aaa-aaaaaaaaaaaa',
  contextEpoch: '7',
  coCode: '01',
  lcCode: '02',
  coYear: '2024',
};
function labourFixture() {
  const { document, state: billReplay } = fixture();
  document.header.raw = { ...document.header.raw, ...golden.header };
  billReplay.savedHeader = structuredClone(document.header.raw);
  Object.assign(billReplay.rowReplay.rows[0]!, structuredClone(golden.expected.initial));
  billReplay.phases = structuredClone({
    loaded: golden.expected.loaded,
    opened: golden.expected.opened,
  });
  const state: ReturnLabourReplayState = {
    contractVersion: returnLabourReplayContract,
    profile: returnLabourReplayProfile,
    context: { ...context },
    scope: { ...document.scope },
    voucherNo: document.voucherNo,
    baseVersion: token('f'),
    documentVersion: document.version,
    configurationVersion: billReplay.configurationVersion,
    billReplay,
    semanticVersions: { ...returnLabourSemanticVersions },
    rows: [
      {
        rowIdentity: token('d'),
        initialPrefixVersion: token('1'),
        labourFields: returnLabourFields.map((fieldId) => ({
          fieldId,
          allowed: true,
          reason: null,
          maxLength: 2,
          commit: 'resolved-enter',
        })),
      },
    ],
    capabilities: {
      canPreview: true,
      canPreviewClosing: false,
      canSaveNumeric: false,
      canApplySource: false,
    },
  };
  const parsed = readReturnLabourReplayState(state, document, context);
  return {
    document,
    state: parsed,
    rawState: state,
    prefix: returnLabourInitialPrefix(parsed, token('d'))!,
  };
}
function baseIdentity(s: ReturnLabourReplayState) {
  const {
    contractVersion,
    profile,
    context,
    scope,
    voucherNo,
    baseVersion,
    documentVersion,
    configurationVersion,
  } = s;
  return {
    contractVersion,
    profile,
    context,
    scope,
    voucherNo,
    baseVersion,
    documentVersion,
    configurationVersion,
  };
}
function observation(s: ReturnLabourReplayState, r: ReturnLabourObserveInput) {
  return {
    ...baseIdentity(s),
    rowIdentity: r.rowIdentity,
    prefixVersion: r.prefixVersion,
    fieldId: r.fieldId,
    editorText: r.editorText,
    observationVersion: token('2'),
    selection: { CO_CODE: s.scope.coCode, LBR_CODE: r.editorText, LBR_CATG: '01', LBR_VAL: '2' },
  };
}
function result(s: ReturnLabourReplayState, r: ReturnLabourAppendInput, name = 'bb') {
  const literal = golden.expected.prefixes[name];
  return {
    ...baseIdentity(s),
    rowIdentity: r.rowIdentity,
    prefix: {
      prefixVersion: token(String(r.events.length + 3)),
      events: [...r.events, r.event],
      preview: structuredClone(literal.preview),
      phase: structuredClone(literal.phase),
    },
    acceptedEvent: { event: r.event, status: 'applied' },
    effects: { aggregateApplied: true, billApplied: true, taxRecalculated: true },
    capabilities: { canPreviewClosing: false, canSaveNumeric: false, canApplySource: false },
  };
}
const labour = (text = 'BB'): ReturnLabourEvent => ({
  kind: 'labourEnter',
  fieldId: returnLabourFields[0],
  editorText: text,
  observationVersion: token('2'),
});
const money = (text = '1'): ReturnLabourEvent => ({
  kind: 'moneyLeave',
  fieldId: returnReplayFieldId(27),
  editorText: text,
});
function mutate(value: unknown, change: (v: any) => void) {
  const copy = structuredClone(value);
  change(copy);
  return copy;
}

describe('separate labour preview protocol, without client arithmetic', () => {
  it('pins the complete source-independent API states and earlier lifecycle choices', () => {
    expect(createHash('sha256').update(goldenBytes).digest('hex')).toBe(
      '8c2e2ba9a985a1e57e353bcbf742e8b350fac47cd34e6cf96f7cb283adbeb78b',
    );
    const bytes = readFileSync(
      new URL('./fixtures/returnLabourUiTransitions.independent.json', import.meta.url),
    );
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      'e11b9b1c9597bb72fa3c3a74e3ee1e541355f2b5defdf6b1644a2fe8d9d553d5',
    );
    expect(JSON.parse(bytes.toString()).cases).toHaveLength(26);
  });
  it('retains exact source loaded/opened matrices, NULLs and distinct manual tax without calculating', () => {
    const { state, rawState, prefix } = labourFixture();
    expect(state).toEqual(rawState);
    expect(state).not.toBe(rawState);
    expect(prefix.preview).toEqual(golden.expected.initial);
    expect(prefix.phase).toEqual(golden.expected.opened);
    expect(state.billReplay.phases.loaded).toEqual(golden.expected.loaded);
    expect(state.billReplay.savedHeader.KASAR_AMT).toBeNull();
    expect(state.billReplay.phases.loaded!.bill.matrix[2]![3]).toBe('7.00');
  });
  it.each([
    'session',
    'epoch',
    'scope',
    'document',
    'configuration',
    'semantic',
    'authority',
    'width',
    'row',
    'extra',
  ])('contains mismatched GET %s', (kind) => {
    const { rawState, document } = labourFixture();
    const changes: Record<string, (v: any) => void> = {
      session: (v) => (v.context.sessionId = 'bbbbbbbb-bbbb-4bbb-8bbb-bbbbbbbbbbbb'),
      epoch: (v) => (v.context.contextEpoch = '8'),
      scope: (v) => (v.scope.coBook = 'BAD'),
      document: (v) => (v.documentVersion = token('8')),
      configuration: (v) => (v.configurationVersion = token('8')),
      semantic: (v) => (v.semanticVersions.labourCopy = 'future'),
      authority: (v) => (v.capabilities.canSaveNumeric = true),
      width: (v) => (v.billReplay.rowReplay.configuration.columns[13].widthState = 'zero'),
      row: (v) => (v.rows[0].rowIdentity = token('8')),
      extra: (v) => (v.hiddenAuthority = true),
    };
    expect(() =>
      readReturnLabourReplayState(mutate(rawState, changes[kind]!), document, context),
    ).toThrow();
  });
  it.each(['getter', 'symbol', 'sparse', 'array-property', 'cycle', 'undefined'])(
    'rejects non-JSON %s before reading embedded fields',
    (kind) => {
      const { rawState, document } = labourFixture();
      const v: any = structuredClone(rawState);
      let invoked = 0;
      if (kind === 'getter')
        Object.defineProperty(v, 'billReplay', {
          enumerable: true,
          get() {
            invoked++;
            throw new Error('invoked');
          },
        });
      if (kind === 'symbol') v[Symbol('hidden')] = 1;
      if (kind === 'sparse') delete v.rows[0];
      if (kind === 'array-property') v.rows.extra = 1;
      if (kind === 'cycle') v.loop = v;
      if (kind === 'undefined') v.extra = undefined;
      expect(() => readReturnLabourReplayState(v, document, context)).toThrow();
      expect(invoked).toBe(0);
    },
  );
  it('requires a ready matching descriptor and complete year, without adopting a response', () => {
    const { document } = labourFixture(),
      page = createPageContextGuard();
    expect(() => requireReturnLabourPage(page.read(), document)).toThrow();
    page.observe(context);
    expect(requireReturnLabourPage(page.read(), document)).toEqual(context);
    page.pauseForSelection();
    expect(() => requireReturnLabourPage(page.read(), document)).toThrow('company change');
  });
  it('uses only the three new full-scope paths and exact saved voucher', () => {
    const { document } = labourFixture();
    expect(returnLabourReplayPath(document)).toContain(
      '/incoming-labour-replay-state?coCode=01&lcCode=02&coYear=2024&coBook=R91',
    );
    expect(returnLabourReplayPath(document, 'observe')).toContain('/incoming-labour-observation?');
    expect(returnLabourReplayPath(document, 'append')).toContain('/incoming-labour-replay?');
    expect(() => returnLabourReplayPath({ ...document, voucherNo: '00000' })).toThrow();
  });
  it.each(['', ' BB', 'BB ', 'AAA', 'B\n', 'B\u2028'])(
    'refuses unsupported exact code %j while retaining input',
    (text) => {
      const { state, prefix } = labourFixture();
      const before = structuredClone(prefix);
      expect(() =>
        returnLabourObserveRequest(state, token('d'), prefix, returnLabourFields[0], text),
      ).toThrow();
      expect(prefix).toEqual(before);
    },
  );
  it('lookup returns only an observation, retaining every accepted row, cache, phase and journal', () => {
    const { state, prefix } = labourFixture(),
      before = structuredClone(prefix);
    const request = returnLabourObserveRequest(
      state,
      token('d'),
      prefix,
      returnLabourFields[0],
      'BB',
    );
    const checked = readReturnLabourObservation(observation(state, request), state, request);
    expect(checked.selection).toEqual({
      CO_CODE: '01',
      LBR_CODE: 'BB',
      LBR_CATG: '01',
      LBR_VAL: '2',
    });
    expect(checked).not.toHaveProperty('prefix');
    expect(prefix).toEqual(before);
  });
  it.each(['prefix', 'code', 'field', 'row', 'company', 'base', 'extra-prefix'])(
    'rejects lookup %s mismatch without candidate acceptance',
    (kind) => {
      const { state, prefix } = labourFixture(),
        request = returnLabourObserveRequest(
          state,
          token('d'),
          prefix,
          returnLabourFields[0],
          'BB',
        );
      const changes: Record<string, (v: any) => void> = {
        prefix: (v) => (v.prefixVersion = token('9')),
        code: (v) => (v.editorText = 'AA'),
        field: (v) => (v.fieldId = returnLabourFields[1]),
        row: (v) => (v.rowIdentity = token('9')),
        company: (v) => (v.selection.CO_CODE = '02'),
        base: (v) => (v.baseVersion = token('9')),
        'extra-prefix': (v) => (v.prefix = { events: [] }),
      };
      expect(() =>
        readReturnLabourObservation(
          mutate(observation(state, request), changes[kind]!),
          state,
          request,
        ),
      ).toThrow();
    },
  );
  it('accepts the independent BB→AA full history including manual-tax change, without recalculation', () => {
    const { state, prefix } = labourFixture();
    const firstRequest = returnLabourAppendRequest(state, token('d'), prefix, labour());
    const first = readReturnLabourReplayResult(result(state, firstRequest), state, firstRequest);
    expect(first.prefix.preview).toEqual(golden.expected.prefixes.bb.preview);
    expect(first.prefix.phase).toEqual(golden.expected.prefixes.bb.phase);
    const secondRequest = returnLabourAppendRequest(state, token('d'), first.prefix, labour('AA'));
    const second = readReturnLabourReplayResult(
      result(state, secondRequest, 'bb-aa'),
      state,
      secondRequest,
    );
    expect(second.prefix.events).toEqual([labour(), labour('AA')]);
    expect(second.prefix.phase).toEqual(golden.expected.prefixes['bb-aa'].phase);
  });
  it('interleaved money and repeated/blank input remains an ordered complete journal', () => {
    const { state, prefix } = labourFixture();
    let accepted = prefix;
    for (const e of [labour(), money(''), money(''), labour('AA')]) {
      const r = returnLabourAppendRequest(state, token('d'), accepted, e);
      const next = result(state, r, 'bb-other-aa');
      accepted = readReturnLabourReplayResult(next, state, r).prefix;
    }
    expect(accepted.events).toEqual([labour(), money(''), money(''), labour('AA')]);
  });
  it.each([
    'drop-history',
    'duplicate',
    'wrong-event',
    'mutate-history',
    'partial-visible',
    'missing-cache',
    'partial-total',
    'known-closing',
    'save',
    'effect',
    'unknown-field',
  ])('refuses append %s with the accepted prefix unchanged', (kind) => {
    const { state, prefix } = labourFixture();
    const r = returnLabourAppendRequest(state, token('d'), prefix, labour());
    const good = readReturnLabourReplayResult(result(state, r), state, r).prefix;
    const next = returnLabourAppendRequest(state, token('d'), good, labour('AA')),
      before = structuredClone(good);
    const changes: Record<string, (v: any) => void> = {
      'drop-history': (v) => v.prefix.events.shift(),
      duplicate: (v) => v.prefix.events.push(next.event),
      'wrong-event': (v) => (v.acceptedEvent.event = labour('BB')),
      'mutate-history': (v) => (v.prefix.events[0].editorText = 'ZZ'),
      'partial-visible': (v) => delete v.prefix.preview.visible['13'],
      'missing-cache': (v) => delete v.prefix.preview.caches['67'],
      'partial-total': (v) => delete v.prefix.phase.incomingTotals['42'],
      'known-closing': (v) =>
        (v.prefix.phase.bill.closing = {
          status: 'ready',
          amount: '0',
          label: 'Dr',
          color: 'x',
          reason: '',
        }),
      save: (v) => (v.capabilities.canSaveNumeric = true),
      effect: (v) => (v.effects.billApplied = false),
      'unknown-field': (v) => (v.policy = {}),
    };
    expect(() =>
      readReturnLabourReplayResult(
        mutate(result(state, next, 'bb-aa'), changes[kind]!),
        state,
        next,
      ),
    ).toThrow();
    expect(good).toEqual(before);
  });
  it('100 accepted events forbid further observation/append and overlong money never truncates', () => {
    const { state, prefix } = labourFixture();
    const full = { ...prefix, events: Array.from({ length: 100 }, () => money()) };
    expect(() =>
      returnLabourObserveRequest(state, token('d'), full, returnLabourFields[0], 'BB'),
    ).toThrow();
    expect(() => returnLabourAppendRequest(state, token('d'), full, money())).toThrow();
    for (const text of ['12345678901', '1\u2028', 'NaN'])
      expect(() => returnLabourAppendRequest(state, token('d'), prefix, money(text))).toThrow();
  });
  it('exact422 recovery confirms the prior prefix only; shortened/changed recovery is refused', () => {
    const { state, prefix } = labourFixture(),
      r = returnLabourAppendRequest(state, token('d'), prefix, labour());
    const before = structuredClone(prefix),
      details = {
        eventIndex: 0,
        event: r.event,
        diagnostics: [{ code: 'refused', message: 'Refused' }],
        recovery: structuredClone(prefix),
      };
    expect(() =>
      validateReturnLabourRecovery(new ApiError('Refused', 422, { details }), r, prefix),
    ).not.toThrow();
    details.recovery.preview.visible['13'] = 'BB';
    expect(() =>
      validateReturnLabourRecovery(new ApiError('Refused', 422, { details }), r, prefix),
    ).toThrow();
    expect(prefix).toEqual(before);
  });
  it('network loss supports explicit identical request retry; stale and omitted-output recovery freeze', () => {
    const { state, prefix } = labourFixture();
    const first = returnLabourAppendRequest(state, token('d'), prefix, labour());
    expect(returnLabourFailure(new TypeError('Failed to fetch')).needsReload).toBe(false);
    expect(returnLabourAppendRequest(state, token('d'), prefix, labour())).toEqual(first);
    expect(returnLabourFailure(new ApiError('stale', 409, {})).needsReload).toBe(true);
    expect(
      returnLabourFailure(new ApiError('output', 422, { error: 'unsupported-output' })).needsReload,
    ).toBe(true);
  });
  it('empty saved headers remain inspectable with no initial prefix or preview authority', () => {
    const { rawState, document } = labourFixture();
    document.lines = [];
    document.provenance.incomingLineCount = 0;
    rawState.rows = [];
    rawState.billReplay.rowReplay.rows = [];
    rawState.billReplay.rowReplay.capabilities.canPreview = false;
    rawState.billReplay.capabilities.canPreviewBill = false;
    rawState.capabilities.canPreview = false;
    const parsed = readReturnLabourReplayState(rawState, document, context);
    expect(parsed.rows).toEqual([]);
    expect(returnLabourInitialPrefix(parsed, token('d'))).toBeNull();
  });
});

describe('labour lifecycle and synchronous three-owner admission', () => {
  it.each([
    'close',
    'draft',
    'field',
    'scope',
    'epoch',
    'selection-pause',
    'unmount',
    'strict-mode',
  ])('late response after %s cannot publish a candidate/prefix', async (cause) => {
    const lease = new ReturnLabourReplayLease();
    lease.observe('document-A');
    const ticket = lease.begin();
    let resolve!: (v: string) => void;
    const pending = new Promise<string>((r) => {
      resolve = r;
    });
    let visible = 'accepted prefix',
      candidate: string | null = null;
    const work = pending.then((v) => {
      if (lease.current(ticket)) {
        candidate = v;
        visible = 'changed';
      }
    });
    if (cause === 'scope' || cause === 'epoch') lease.observe(cause);
    else lease.invalidate();
    resolve('BB');
    await work;
    expect(visible).toBe('accepted prefix');
    expect(candidate).toBeNull();
  });
  it('BB→AA draft replacement may issue a new lookup while the old actual read is pending', async () => {
    const lease = new ReturnLabourReplayLease();
    lease.observe('A');
    let oldResolve!: (v: string) => void, newResolve!: (v: string) => void;
    let candidate = '';
    const old = lease.begin(),
      oldWork = new Promise<string>((r) => (oldResolve = r)).then((v) => {
        if (lease.current(old)) candidate = v;
      });
    lease.invalidate();
    const next = lease.begin(),
      newWork = new Promise<string>((r) => (newResolve = r)).then((v) => {
        if (lease.current(next)) candidate = v;
      });
    newResolve('AA');
    await newWork;
    oldResolve('BB');
    await oldWork;
    expect(candidate).toBe('AA');
  });
  it('same-document close/reopen fences the original generation rather than matching only identity', () => {
    const l = new ReturnLabourReplayLease();
    l.observe('A');
    const first = l.begin();
    l.invalidate();
    l.observe('B');
    l.observe('A');
    const second = l.begin();
    expect(l.current(first)).toBe(false);
    expect(l.current(second)).toBe(true);
  });
  it.each(['row', 'bill', 'labour'] as const)(
    '%s wins synchronously and excludes both other owners',
    (first) => {
      const owner = new SavedReturnPreviewOwnership(),
        scope = { context: 1, generation: 2 };
      owner.observe(scope);
      expect(owner.change(scope, first, true)).toBe(true);
      for (const next of ['row', 'bill', 'labour'] as const)
        if (next !== first) expect(owner.change(scope, next, true)).toBe(false);
      expect(owner.active(scope)).toBe(first);
      owner.observe({ context: 1, generation: 3 });
      expect(owner.change(scope, first, false)).toBe(false);
    },
  );
  it('the mounted source uses explicit ownership, guarded awaits, editable pending drafts and no Tab/blur commit', () => {
    const source = readFileSync(
      new URL('../components/SaleReturnLabourReplayPanel.tsx', import.meta.url),
      'utf8',
    );
    expect(source).toMatch(/onActivityChange\(true\)\s*!==\s*true/);
    expect(source).toContain('assertPageContextTicket');
    expect(source).toContain('disabled={!editorEligible}');
    expect(source).not.toContain('onBlur=');
    expect(source).not.toContain("event.key === 'Tab'");
    expect(source).not.toContain('pinPageContext');
    expect(source).not.toContain('reduceSaleReturn');
    expect(source).toContain('sale-return-labour-replay-value-${c}-preview');
  });
});
