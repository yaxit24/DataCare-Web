import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { Decimal } from 'decimal.js';
import { describe, expect, it } from 'vitest';
import {
  projectSavedSaleReturnIncoming,
  projectSaleReturnIncomingEditorText,
  SALE_RETURN_INCOMING_MONEY_PREVIEW_COLUMNS,
  type SavedSaleReturnIncomingProjectionInput,
} from '../src/saleReturnIncomingProjection.js';
import {
  createSaleReturnIncomingState,
  saleReturnIncomingCells,
  type SaleReturnIncomingRaw,
  type SaleReturnIncomingState,
} from '../src/saleReturnIncoming.js';

const bytes = readFileSync(
  new URL('./fixtures/saleReturnIncoming.projection.json', import.meta.url),
);
const fixture = JSON.parse(bytes.toString()) as {
  input: SavedSaleReturnIncomingProjectionInput;
  expectedCells: Record<number, string>;
  expectedCaches: Record<number, string>;
};
const input = (
  raw: Record<string, string | null> = {},
  itemMasters: readonly SaleReturnIncomingRaw[] = fixture.input.itemMasters,
): SavedSaleReturnIncomingProjectionInput => ({
  ...fixture.input,
  raw: { ...fixture.input.raw, ...raw },
  itemMasters,
});
function ready(value = input()): SaleReturnIncomingState {
  const result = projectSavedSaleReturnIncoming(value);
  expect(result.status, JSON.stringify(result)).toBe('ready');
  if (result.status !== 'ready') throw new Error('Expected a supported projection');
  return result.state;
}
function unsupported(
  value: SavedSaleReturnIncomingProjectionInput,
  code: string,
  fieldId?: string,
) {
  const before = structuredClone(value);
  const result = projectSavedSaleReturnIncoming(value);
  expect(result.status).toBe('unsupported');
  if (result.status !== 'unsupported') throw new Error('Expected a contained projection');
  expect(result.diagnostics).toEqual(
    expect.arrayContaining([expect.objectContaining({ code, ...(fieldId ? { fieldId } : {}) })]),
  );
  expect(result).not.toHaveProperty('state');
  expect(value).toEqual(before);
  expect(Object.isFrozen(result.diagnostics)).toBe(true);
}

describe('saved primary incoming source projection', () => {
  it('pins a portable source-authored expectation for every loaded cell and only eight caches', () => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      '0f29c29e9ccfc8cd4663c36b0ed9b2def4123fab7a3556239ad507aba6477b78',
    );
    const state = ready();
    expect(saleReturnIncomingCells(state)).toEqual(fixture.expectedCells);
    expect(state.caches).toEqual(fixture.expectedCaches);
    expect(Object.keys(state.caches)).toHaveLength(8);
    expect(state.journal).toEqual([]);
  });
  it('preserves raw values and inconsistent manual totals without calculating on hydration', () => {
    const original = input();
    const before = structuredClone(original);
    const state = ready(original);
    expect(original).toEqual(before);
    expect(state.raw).toEqual(original.raw);
    expect(state.raw).not.toBe(original.raw);
    expect(state.raw.VCH_TIME).toBe('2024-02-29 12:13:14.123456');
    expect(state.raw.UNRELATED_DECIMAL).toBe('9999999999999999.99');
    expect(state.raw.RAW_NULL).toBeNull();
    expect(state.raw.RAW_BLANK).toBe('');
    expect(state.visible[36]).toBe('900.13');
    expect(state.visible[38]).toBe('800.01');
    for (const value of [state, state.raw, state.visible, state.caches, state.journal])
      expect(Object.isFrozen(value)).toBe(true);
  });
  it('keeps persisted identity separate from visual ordinal and rounded hidden identity cells', () => {
    const state = ready();
    expect(state.rowIdentity).toBe('saved-return-exact-row17');
    expect(state.raw.SR_NO).toBe('17');
    expect(state.visible[0]).toBe('2');
    expect(state.raw.OLD_SRNO).toBe('31.5');
    expect(state.visible[51]).toBe('32');
    expect(state.raw.TAG_SRNO).toBe('78.5');
    expect(state.visible[56]).toBe('79');
    expect(state.visible[40]).toBe('7000000.125');
    expect(state.visible[41]).toBe('');
    expect(state.visible[42]).toBe('');
    expect(state.visible[57]).toBe('E');
  });
  it('retains fractional piece ToString text and formats touch/west/tax before seeding caches', () => {
    const state = ready();
    expect(state.visible[9]).toBe('1.250');
    expect(state.raw.ITM_TOUCH).toBe('75.555');
    expect(state.visible[16]).toBe('75.56');
    expect(state.caches[47]).toBe('75.56');
    expect(state.raw.ITM_WEST_PRC).toBe('0.0049');
    expect(state.caches[48]).toBe('0.00');
    expect(state.raw.TAX_PRC).toBe('2.6750');
    expect(state.caches[67]).toBe('2.68');
  });
  it.each([null, ''])(
    'applies description and tag-labour display fallbacks without rewriting raw %j',
    (blank) => {
      const state = ready(input({ ITM_REMARK: blank, TAG_LBR_CODE: blank }));
      expect(state.visible[3]).toBe('Original ring name');
      expect(state.visible[29]).toBe('L001');
      expect(state.raw.ITM_REMARK).toBe(blank);
      expect(state.raw.TAG_LBR_CODE).toBe(blank);
    },
  );
  it('does not trim away nonempty description or tag-labour text when applying fallbacks', () => {
    const state = ready(input({ ITM_REMARK: ' ', TAG_LBR_CODE: ' ' }));
    expect(state.visible[3]).toBe(' ');
    expect(state.visible[29]).toBe(' ');
  });
  it('keeps huge exact values under unrelated global Decimal precision and leaves that configuration alone', () => {
    const previous = Decimal.precision;
    Decimal.set({ precision: 7 });
    try {
      const state = ready(
        input({ ITM_RATE: '9999999999999999.99', LBR_RATE: '1234567890123456.78' }),
      );
      expect(state.visible[19]).toBe('9999999999999999.99');
      expect(state.caches[49]).toBe('9999999999999999.99');
      expect(state.visible[23]).toBe('1234567890123456.78');
      expect(Decimal.precision).toBe(7);
    } finally {
      Decimal.set({ precision: previous });
    }
  });
  it.each([
    ['1.005', '1.01'],
    ['-1.005', '-1.01'],
    ['0.0049', '0.00'],
    ['0.005', '0.01'],
  ])(
    'documents the mathematical display profile for %s without claiming binary acceptance',
    (raw, expected) => {
      expect(ready(input({ ITM_RATE: raw })).visible[19]).toBe(expected);
    },
  );
});

describe('projection containment preserves the whole saved read', () => {
  it.each([
    ['ITM_PCS', 9],
    ['ITM_GWT', 10],
    ['ITM_FINE', 18],
    ['ITM_RATE', 19],
    ['LBR_AMT', 24],
    ['DISC_PRC', 25],
    ['TAG_MRP', 35],
    ['OLD_SRNO', 51],
    ['TAG_SRNO', 56],
    ['HM_ID2_WT', 63],
  ] as const)('contains unproved numeric NULL in %s', (field, column) => {
    unsupported(
      input({ [field]: null }),
      'unsupported-numeric-null',
      'x13.primary-incoming.c' + String(column).padStart(2, '0'),
    );
  });
  it('distinguishes a missing source column from a raw NULL and never returns partial state', () => {
    const value = input();
    const { ITM_RATE: omitted, ...raw } = value.raw;
    expect(omitted).toBe('123.45');
    unsupported({ ...value, raw }, 'missing-saved-column', 'x13.primary-incoming.c19');
  });
  it.each(['', ' ', 'NaN', 'Infinity', '1e2', '0x10', '12abc', '1,25', ' 1.25 '])(
    'contains malformed saved decimal %j',
    (value) => {
      unsupported(input({ ITM_RATE: value }), 'invalid-saved-decimal', 'x13.primary-incoming.c19');
    },
  );
  it.each([
    '1000000000000000000000000000000000000',
    '0.0000000000000000001',
    '1234567890123456789.123456789012345678',
  ])('contains out-of-profile exact decimal %s', (value) => {
    unsupported(
      input({ ITM_RATE: value }),
      'unsupported-saved-precision',
      'x13.primary-incoming.c19',
    );
  });
  it('requires exact company/item identity and rejects duplicate physical masters even when identical', () => {
    unsupported(input({}, []), 'missing-item-master');
    unsupported(
      input({}, [{ ...fixture.input.itemMasters[0]!, CO_CODE: '02' }]),
      'missing-item-master',
    );
    unsupported(
      input({}, [{ ...fixture.input.itemMasters[0]!, IT_CODE: 'OTHER' }]),
      'missing-item-master',
    );
    unsupported(
      input({}, [...fixture.input.itemMasters, ...fixture.input.itemMasters]),
      'ambiguous-item-master',
    );
  });
  it.each(['RATE_TYPE', 'IT_TYPE'] as const)(
    'does not choose a current master %s over an incompatible saved value',
    (field) => {
      unsupported(
        input({}, [{ ...fixture.input.itemMasters[0]!, [field]: 'P' }]),
        'unresolved-item-type-binding',
      );
      unsupported(input({ [field]: null }), 'unresolved-item-type-binding');
      unsupported(
        input({}, [{ ...fixture.input.itemMasters[0]!, [field]: null }]),
        'unresolved-item-type-binding',
      );
    },
  );
  it('can ignore unrelated exact identities but not replace the matching saved master', () => {
    const state = ready(
      input({}, [
        { CO_CODE: '02', IT_CODE: 'I001', IT_NAME: 'Other', RATE_TYPE: 'P', IT_TYPE: 'S' },
        ...fixture.input.itemMasters,
      ]),
    );
    expect(state.visible[3]).toBe('Original ring name');
  });
  it.each<SaleReturnIncomingRaw>([
    { IT_CODE: 'i001' },
    { IT_CODE: 'I001 ' },
    { IT_CODE: ' I001' },
    { CO_CODE: '01 ' },
  ])('does not let an exact master conceal a discovered case/trim alias %j', (alias) => {
    unsupported(
      input({}, [...fixture.input.itemMasters, { ...fixture.input.itemMasters[0]!, ...alias }]),
      'ambiguous-item-master',
      'x13.primary-incoming.c01',
    );
  });
  it.each([
    null,
    {},
    { ...fixture.input, ordinal: 0 },
    { ...fixture.input, ordinal: 1.5 },
    { ...fixture.input, rowIdentity: '' },
    { ...fixture.input, raw: { ITM_RATE: 10 } },
    { ...fixture.input, itemMasters: [null] },
  ])('rejects malformed trusted-boundary input %# recoverably', (value) => {
    const result = projectSavedSaleReturnIncoming(value as SavedSaleReturnIncomingProjectionInput);
    expect(result.status).toBe('unsupported');
    if (result.status === 'unsupported')
      expect(result.diagnostics[0]?.code).toBe('invalid-projection-input');
  });
});

describe('source EnterCell editor presentation', () => {
  it('exposes exactly twelve two-decimal editors without mutating visible cells, caches or journal', () => {
    const loaded = ready();
    const state = createSaleReturnIncomingState({
      rowIdentity: loaded.rowIdentity,
      raw: loaded.raw,
      cells: { ...saleReturnIncomingCells(loaded), 21: '20.125', 24: '' },
      cacheMode: 'provided',
    });
    const before = structuredClone(state);
    const result = projectSaleReturnIncomingEditorText(state);
    expect(result.status).toBe('ready');
    if (result.status !== 'ready') throw new Error('Expected editors');
    expect(Object.keys(result.editorTextByField)).toEqual(
      SALE_RETURN_INCOMING_MONEY_PREVIEW_COLUMNS.map((column) => 'x13.primary-incoming.c' + column),
    );
    expect(result.editorTextByField['x13.primary-incoming.c21']).toBe('20.13');
    expect(result.editorTextByField['x13.primary-incoming.c24']).toBe('0.00');
    expect(state.visible[21]).toBe('20.125');
    expect(state.caches[66]).toBe('2.35');
    expect(state.visible[24]).toBe('');
    expect(state).toEqual(before);
    expect(Object.isFrozen(result.editorTextByField)).toBe(true);
  });
  it('preserves huge editor text instead of silently enforcing a typing limit during display', () => {
    const state = ready(input({ ITM_RATE: '9999999999999999.99' }));
    const result = projectSaleReturnIncomingEditorText(state);
    expect(result.status === 'ready' && result.editorTextByField['x13.primary-incoming.c19']).toBe(
      '9999999999999999.99',
    );
  });
  it('contains malformed editor cells without producing a partial editor map', () => {
    const state = ready();
    const result = projectSaleReturnIncomingEditorText({
      ...state,
      visible: { ...state.visible, 19: 'Infinity' },
    });
    expect(result.status).toBe('unsupported');
    expect(result).not.toHaveProperty('editorTextByField');
    expect(state.visible[19]).toBe('123.45');
  });
});
