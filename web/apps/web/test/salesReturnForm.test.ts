import { describe, expect, it } from 'vitest';
import { ApiError } from '../lib/api';
import {
  readSavedIncomingReturn,
  readSavedReturnRecent,
  savedReturnDraft,
  savedReturnHasChanges,
  savedReturnLineKey,
  savedReturnMetadataPatch,
  savedReturnPath,
  savedReturnRecentPath,
  savedReturnSaveFailure,
  savedReturnScopeKey,
  SavedReturnRequestGuard,
  type SavedIncomingReturn,
  type SavedReturnScope,
} from '../lib/salesReturnForm';

const scope: SavedReturnScope = { coCode: '01', lcCode: '02', coYear: '2024-2025', coBook: 'R61' };
const allow = () => ({ allowed: true, reason: null });
const rawKey = () => ({
  CO_CODE: '01',
  LC_CODE: '02',
  CO_YEAR: '2024-2025',
  CO_BOOK: 'R61',
  VCH_NO: '00001',
});
function fixture(): SavedIncomingReturn {
  return {
    scope: { ...scope },
    voucherNo: '00001',
    version: 'a'.repeat(64),
    canUpdate: true,
    capabilities: { canUpdate: true, reason: null },
    header: {
      raw: {
        ...rawKey(),
        EMP_CODE: null,
        VCH_TIME: '2024-07-10T09:17:18.123456',
        ISU_NO: '00002',
        ISU_YRCD: '2023-2024',
        ISU_DBCD: 'S41',
        ISU_LC_CODE: '02',
        NET_AMT: '0.00',
        RTN_NET_AMT: '9999999999999999.99',
        BILL_NO: '',
      },
      display: { employeeName: null, employeeNameReason: null },
      capabilities: { employeeCode: allow() },
    },
    lines: [
      {
        identity: {
          srNo: '17',
          oldSrNo: '31',
          vchSrno: '117.25',
          tagSrNo: null,
          itCode: 'GOLD',
          tagNo: 'N',
        },
        raw: {
          ...rawKey(),
          SR_NO: '17',
          OLD_SRNO: '31',
          VCH_SRNO: '117.25',
          TAG_SRNO: null,
          IT_CODE: 'GOLD',
          TAG_NO: 'N',
          HM_ID: 'OLD17',
          ITM_REMARK: null,
          HM_ID2: 'H2',
          HM_ID3: '',
          HM_ID4: null,
          HM_ID_WT: '0.000',
          HM_ID2_WT: '1.234',
          HM_ID3_WT: null,
          HM_ID4_WT: '9.876',
          ITM_NWT: '0.000',
          NET_AMT: '9999999999999999.99',
          ITM_FINE: '7.777',
          LBR_PRC: '9.8765',
          DESIGN_IMG_ID: null,
          DATA_TYPE: 'X',
          EMP_CODE: null,
          VCH_TIME: '2024-07-10T09:17:18.123456',
        },
        display: { itemName: 'Gold item', itemNameReason: null, description: 'Gold item' },
        capabilities: { huid: allow(), description: allow() },
      },
      {
        identity: {
          srNo: '42',
          oldSrNo: '58',
          vchSrno: '242',
          tagSrNo: '9',
          itCode: 'STONE',
          tagNo: '',
        },
        raw: {
          ...rawKey(),
          SR_NO: '42',
          OLD_SRNO: '58',
          VCH_SRNO: '242',
          TAG_SRNO: '9',
          IT_CODE: 'STONE',
          TAG_NO: '',
          HM_ID: null,
          ITM_REMARK: '  Hand set  ',
          ITM_NWT: null,
          NET_AMT: '0.00',
          DESIGN_IMG_ID: 'N',
        },
        display: { itemName: 'Stone item', itemNameReason: null, description: '  Hand set  ' },
        capabilities: { huid: allow(), description: allow() },
      },
    ],
    related: {
      outgoingLines: [],
      outgoingComponents: [],
      tagHeaders: [],
      tagParents: [],
      tagComponents: [
        { ...rawKey(), SR_NO: '17', ISR_NO: '3', IT_RATE: '9999999999999999.99', IT_GWT: null },
      ],
    },
    provenance: {
      incomingLineCount: 2,
      outgoingLineCount: 0,
      outgoingComponentCount: 0,
      tagHeaderCount: 0,
      tagParentCount: 0,
      tagComponentCount: 1,
    },
  };
}

describe('saved incoming Return observations and metadata', () => {
  it('preserves exact raw NULL, scale, large decimals, timestamps, identities and distinct children', () => {
    const raw = fixture();
    const before = structuredClone(raw);
    const document = readSavedIncomingReturn(raw, scope, '1');
    expect(document).toBe(raw);
    const draft = savedReturnDraft(document);
    expect(draft.lines[savedReturnLineKey(document.lines[0]!.identity)]).toEqual({
      huid: 'OLD17',
      description: 'Gold item',
    });
    expect(savedReturnHasChanges(document, draft)).toBe(false);
    expect(savedReturnMetadataPatch(document, draft)).toBeNull();
    expect(raw).toEqual(before);
    expect(document.related.tagComponents[0]?.IT_RATE).toBe('9999999999999999.99');
  });

  it('uses exact protected saved identity and only one HUID patch, preserving NULL description fallback', () => {
    const document = fixture();
    const draft = savedReturnDraft(document);
    draft.lines[savedReturnLineKey(document.lines[0]!.identity)]!.huid = 'NEW17';
    expect(savedReturnMetadataPatch(document, draft)).toEqual({
      version: 'a'.repeat(64),
      lines: [
        {
          identity: {
            srNo: '17',
            oldSrNo: '31',
            vchSrno: '117.25',
            tagSrNo: null,
            itCode: 'GOLD',
            tagNo: 'N',
          },
          changes: { huid: 'NEW17' },
        },
      ],
    });
    expect(document.lines[0]?.raw.ITM_REMARK).toBeNull();
    expect(document.lines[1]?.raw.ITM_REMARK).toBe('  Hand set  ');
  });

  it('retains missing and ambiguous master diagnostics without repairing raw values or changing patch authority', () => {
    const raw = fixture();
    raw.header.raw.EMP_CODE = 'E99';
    raw.header.display.employeeNameReason = 'The saved employee is not in this company.';
    raw.header.capabilities.employeeCode = { allowed: false, reason: 'Companion is unsupported.' };
    raw.lines[0]!.display = {
      itemName: null,
      itemNameReason: 'More than one item matches the saved item code.',
      description: '',
    };
    raw.lines[1]!.display.itemName = null;
    raw.lines[1]!.display.itemNameReason = 'The saved item is not in this company.';
    const before = structuredClone(raw);
    const document = readSavedIncomingReturn(raw, scope, '1');
    const draft = savedReturnDraft(document);
    expect(savedReturnMetadataPatch(document, draft)).toBeNull();
    expect(draft.employeeCode).toBe('E99');
    expect(draft.lines[savedReturnLineKey(document.lines[1]!.identity)]!.description).toBe(
      '  Hand set  ',
    );
    draft.lines[savedReturnLineKey(document.lines[0]!.identity)]!.huid = 'NEW17';
    expect(savedReturnMetadataPatch(document, draft)).toEqual({
      version: document.version,
      lines: [{ identity: document.lines[0]!.identity, changes: { huid: 'NEW17' } }],
    });
    expect(document).toEqual(before);
    draft.employeeCode = 'E01';
    expect(() => savedReturnMetadataPatch(document, draft)).toThrow('Companion is unsupported');
  });

  it.each(['missing-item', 'invalid-item', 'missing-employee', 'invalid-employee'] as const)(
    'rejects a %s diagnostic instead of accepting an incomplete saved observation',
    (kind) => {
      const raw = fixture();
      const display: Record<string, unknown> = kind.endsWith('item')
        ? raw.lines[0]!.display
        : raw.header.display;
      const field = kind.endsWith('item') ? 'itemNameReason' : 'employeeNameReason';
      if (kind.startsWith('missing')) delete display[field];
      else display[field] = 17;
      expect(() => readSavedIncomingReturn(raw, scope, '1')).toThrow('incomplete');
    },
  );

  it('sends explicit empty descriptions, preserves spaces, and removes reverted fallback edits', () => {
    const document = fixture();
    const draft = savedReturnDraft(document);
    const first = savedReturnLineKey(document.lines[0]!.identity);
    const second = savedReturnLineKey(document.lines[1]!.identity);
    draft.lines[first]!.description = '';
    draft.lines[second]!.description = ' New description ';
    expect(savedReturnMetadataPatch(document, draft)?.lines?.map((line) => line.changes)).toEqual([
      { description: '' },
      { description: ' New description ' },
    ]);
    draft.lines[first]!.description = 'Gold item';
    draft.lines[second]!.description = '  Hand set  ';
    expect(savedReturnMetadataPatch(document, draft)).toBeNull();
    expect(document.lines[0]?.raw.ITM_REMARK).toBeNull();
  });

  it('sends header employee once without per-line stamping or scope in the body', () => {
    const document = fixture();
    const draft = savedReturnDraft(document);
    draft.employeeCode = 'E02';
    expect(savedReturnMetadataPatch(document, draft)).toEqual({
      version: document.version,
      header: { employeeCode: 'E02' },
    });
    const path = new URL(
      savedReturnPath(document.scope, document.voucherNo, 'metadata'),
      'http://localhost',
    );
    expect(path.pathname).toBe('/sales-returns/00001/incoming-metadata');
    expect(Object.fromEntries(path.searchParams)).toEqual(scope);
    expect(new URL(savedReturnRecentPath(scope), 'http://localhost').pathname).toBe(
      '/sales-returns/incoming-recent',
    );
  });

  it.each(['rights', 'domain', 'field', 'employee'] as const)(
    'rejects %s-denied edits without mutating the raw snapshot',
    (kind) => {
      const document = fixture();
      const draft = savedReturnDraft(document);
      draft.lines[savedReturnLineKey(document.lines[0]!.identity)]!.huid = 'NEW';
      if (kind === 'rights') document.canUpdate = false;
      if (kind === 'domain') document.capabilities = { canUpdate: false, reason: 'Locked return' };
      if (kind === 'field')
        document.lines[0]!.capabilities.huid = {
          allowed: false,
          reason: 'Tagged return is read-only',
        };
      if (kind === 'employee') {
        draft.employeeCode = 'E02';
        document.header.capabilities.employeeCode = {
          allowed: false,
          reason: 'Companion employee effect is unsupported',
        };
      }
      const before = structuredClone(document);
      expect(() => savedReturnMetadataPatch(document, draft)).toThrow();
      expect(document).toEqual(before);
    },
  );

  it('rejects a missing or injected row key and preserves invalid over-width draft for correction', () => {
    const document = fixture();
    const draft = savedReturnDraft(document);
    const key = savedReturnLineKey(document.lines[0]!.identity);
    draft.lines[key]!.huid = 'X'.repeat(11);
    expect(() => savedReturnMetadataPatch(document, draft)).toThrow('at most 10');
    expect(draft.lines[key]!.huid).toBe('X'.repeat(11));
    draft.lines[key]!.huid = 'X'.repeat(10);
    expect(savedReturnMetadataPatch(document, draft)?.lines?.[0]?.changes.huid).toBe(
      'X'.repeat(10),
    );
    draft.lines.foreign = { huid: 'FORGED', description: '' };
    expect(() => savedReturnMetadataPatch(document, draft)).toThrow('identity changed');
    delete draft.lines.foreign;
    delete draft.lines[key];
    expect(() => savedReturnMetadataPatch(document, draft)).toThrow('identity changed');
  });

  it.each([
    'scope',
    'header-key',
    'empty-header',
    'empty-lines',
    'line-key',
    'null-identity',
    'lossy-number',
    'lossy-child',
    'missing-capability',
    'duplicate-row',
  ] as const)('rejects a %s observation before it enables editing', (kind) => {
    const malformed: any = fixture();
    if (kind === 'scope') malformed.scope.coBook = 'R62';
    if (kind === 'header-key') malformed.header.raw.CO_YEAR = '2023-2024';
    if (kind === 'empty-header') malformed.header.raw = {};
    if (kind === 'empty-lines') malformed.lines = [];
    if (kind === 'line-key') malformed.lines[0].raw.SR_NO = '1';
    if (kind === 'null-identity') malformed.lines[0].raw.TAG_SRNO = '0';
    if (kind === 'lossy-number') malformed.lines[0].raw.NET_AMT = 10000000000000000;
    if (kind === 'lossy-child') malformed.related.tagComponents[0].IT_RATE = 10;
    if (kind === 'missing-capability') delete malformed.lines[0].capabilities.huid;
    if (kind === 'duplicate-row') malformed.lines.push(structuredClone(malformed.lines[0]));
    expect(() => readSavedIncomingReturn(malformed, scope, '1')).toThrow();
  });

  it('keeps recent list amounts exact and rejects malformed scope/voucher before building a request', () => {
    const recent = {
      rows: [
        {
          voucherNo: '00001',
          raw: fixture().header.raw,
          display: { customer: 'Customer', date: '2024-07-10', billNo: '' },
        },
      ],
    };
    expect(readSavedReturnRecent(recent).rows[0]?.raw.RTN_NET_AMT).toBe('9999999999999999.99');
    expect(() => savedReturnPath({ ...scope, coBook: '' }, '1')).toThrow('configured return book');
    expect(() => savedReturnPath(scope, '1.2')).toThrow('voucher number');
    expect(() => savedReturnPath(scope, '123456789')).toThrow('voucher number');
    expect(savedReturnScopeKey(scope)).not.toBe(savedReturnScopeKey({ ...scope, coBook: 'R62' }));
  });
});

describe('saved Return request ownership', () => {
  it('rejects first-A responses after A to B to A even when the scope string is equal again', () => {
    const guard = new SavedReturnRequestGuard();
    guard.observe('A');
    const firstA = guard.begin('document');
    guard.observe('B');
    const b = guard.begin('document');
    guard.observe('A');
    const finalA = guard.begin('document');
    expect(guard.current(firstA)).toBe(false);
    expect(guard.current(b)).toBe(false);
    expect(guard.current(finalA)).toBe(true);
  });

  it('separates list/document requests, supersedes older loads, and invalidates cancelled save/readback ownership', () => {
    const guard = new SavedReturnRequestGuard();
    guard.observe('A');
    const list = guard.begin('browse');
    const first = guard.begin('document');
    const second = guard.begin('document');
    expect(guard.current(list)).toBe(true);
    expect(guard.current(first)).toBe(false);
    expect(guard.current(second)).toBe(true);
    guard.invalidate();
    expect(guard.current(list)).toBe(false);
    expect(guard.current(second)).toBe(false);
    expect(guard.current(guard.begin('document'))).toBe(true);
  });
});

describe('saved Return failed save disposition', () => {
  it.each([500, 502, 503])(
    'requires explicit Reload after uncertain HTTP %s without an automatic retry',
    (status) => {
      const result = savedReturnSaveFailure(
        new ApiError('gateway', status, { message: 'Gateway failure' }),
        { dispatched: true, committed: false },
      );
      expect(result).toEqual({
        needsReload: true,
        conflict: false,
        message: 'The save result could not be confirmed. Reload before retrying. Gateway failure',
      });
    },
  );
  it('keeps invalid local draft correctable and marks conflict, network and committed malformed response separately', () => {
    expect(
      savedReturnSaveFailure(new Error('HUID too long'), { dispatched: false, committed: false }),
    ).toEqual({ needsReload: false, conflict: false, message: 'HUID too long' });
    expect(
      savedReturnSaveFailure(new ApiError('version-conflict', 409, { message: 'Reload return' }), {
        dispatched: true,
        committed: false,
      }),
    ).toEqual({ needsReload: true, conflict: true, message: 'Reload return' });
    expect(
      savedReturnSaveFailure(new TypeError('Network failure'), {
        dispatched: true,
        committed: false,
      }).needsReload,
    ).toBe(true);
    expect(
      savedReturnSaveFailure(new Error('Invalid observation'), {
        dispatched: true,
        committed: true,
      }).message,
    ).toContain('Metadata saved');
  });
});
