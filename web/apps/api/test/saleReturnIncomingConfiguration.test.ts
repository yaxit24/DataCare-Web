import { describe, expect, it } from 'vitest';
import {
  resolveSaleReturnIncomingConfiguration,
  SALE_RETURN_INCOMING_COLUMN_CATALOG,
  type SaleReturnIncomingConfigurationObservations,
  type SaleReturnIncomingConfigurationRow,
} from '../src/modules/sales/saleReturnIncomingConfiguration.js';

const scope = {
  tenantId: 'return-config-pure-r8',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  coBook: 'R81',
};
const row = (
  raw: Record<string, string | null>,
  physicalId = '1',
): SaleReturnIncomingConfigurationRow => ({
  raw: { CO_CODE: '01', ...raw },
  revision: '10',
  locator: `(0,${physicalId})`,
  physicalId,
});
const base = (): SaleReturnIncomingConfigurationObservations => ({
  settings: [
    row({ SL_AMT_TYPE: 'F', LBR_ROF: '2', LBR_RATE_GEN: 'N', ALL_ROF_REMOVE: 'N', LBR_TYPE: 'G' }),
  ],
  newSettings: [row({ LBR_WITH_GHT: 'Y' })],
  columns: [],
  books: [
    row({
      LC_CODE: '01',
      CO_BOOK: 'R81',
      MAIN_BOOK: 'SALES RETURNE',
      BOOK_INOUT: 'I',
      BOOK_TBL_NAME: 'SL_DATA',
      CUR_USE: 'Y',
    }),
  ],
  years: [row({ CO_YEAR: '2024-2025' })],
});

describe('incoming Return server configuration catalog and strict observation boundary', () => {
  it('keeps 71 original positions and independently named hidden identities without permitting ordinary cache commits', () => {
    const dto = resolveSaleReturnIncomingConfiguration(scope, base());
    expect(dto.columns).toHaveLength(71);
    expect(new Set(dto.columns.map((column) => column.id)).size).toBe(71);
    expect(dto.columns[0]).toMatchObject({
      id: 'x13.primary-incoming.c00',
      label: 'Sr',
      nominalWidth: 325,
    });
    expect(dto.columns[1]).toMatchObject({
      sourceName: 'RecCode',
      nominalWidth: 300,
      commitKind: 'admission',
    });
    expect(dto.columns[18]).toMatchObject({
      sourceName: 'Fine',
      nominalWidth: 1000,
      storageField: 'ITM_FINE',
      commitKind: 'decimal3',
    });
    expect(dto.columns[29]).toMatchObject({ sourceName: 'TgLCode', storageField: 'TAG_LBR_CODE' });
    for (const index of [41, 42, 45, 46, 47, 48, 49, 53, 55, 57, 58, 66, 67])
      expect(dto.columns[index]).toMatchObject({
        sourceName: null,
        storageField: null,
        widthState: 'zero',
        nominalWidth: 0,
        commitKind: 'none',
      });
    expect(dto.columns[51]).toMatchObject({ storageField: 'OLD_SRNO', commitKind: 'none' });
    expect(dto.columns[56]).toMatchObject({ storageField: 'TAG_SRNO', commitKind: 'none' });
    expect(dto.columns[69]).toMatchObject({ storageField: 'DESIGN_IMG_ID', commitKind: 'none' });
    expect(dto.capabilities).toEqual({ canCalculate: true, canSaveNumeric: false });
  });

  it('does not mutate source observations or its shared frozen catalog', () => {
    const observations = base();
    observations.columns = [
      row({
        BOOK_NAME: 'SALES RETURNE',
        COL_NAME: 'Fine',
        COL_NEW_NAME: '',
        YES_NO: 'N',
        COL_RPT: 'Y',
      }),
    ];
    const original = structuredClone(observations);
    const dto = resolveSaleReturnIncomingConfiguration(scope, observations);
    dto.columns[18]!.label = 'Local response edit';
    expect(observations).toEqual(original);
    expect(SALE_RETURN_INCOMING_COLUMN_CATALOG[18]!.label).toBe('Fine');
    expect(Object.isFrozen(SALE_RETURN_INCOMING_COLUMN_CATALOG[18])).toBe(true);
    expect(resolveSaleReturnIncomingConfiguration(scope, observations).columns[18]!.label).toBe('');
  });

  it('keeps diagnostic alias normalization separate from configured book validation', () => {
    const observations = base();
    observations.books[0]!.raw.MAIN_BOOK = 'SALES  RETURNE';
    expect(() => resolveSaleReturnIncomingConfiguration(scope, observations)).toThrow(
      /must belong/,
    );
    observations.books[0]!.raw.MAIN_BOOK = ' sales returne ';
    expect(
      resolveSaleReturnIncomingConfiguration(scope, observations).capabilities.canCalculate,
    ).toBe(true);
    observations.books[0]!.raw.CUR_USE = 'n';
    expect(() => resolveSaleReturnIncomingConfiguration(scope, observations)).toThrow(/inactive/);
  });

  it('does not present a conditional Style caption as effective before the edition is resolved', () => {
    const observations = base();
    observations.columns = [
      row({ BOOK_NAME: 'SALES RETURNE', COL_NAME: 'Style', COL_NEW_NAME: 'Model', YES_NO: 'Y' }),
    ];
    const unresolved = resolveSaleReturnIncomingConfiguration(scope, observations);
    expect(unresolved.columns[6]).toMatchObject({
      configured: true,
      sourceName: 'Style',
      originalLabel: null,
      label: null,
      widthState: 'unresolved',
    });
    expect(unresolved.capabilities.canCalculate).toBe(true);
    observations.edition = { state: 'resolved', value: 'A', version: 'test-authoritative-edition' };
    expect(resolveSaleReturnIncomingConfiguration(scope, observations).columns[6]).toMatchObject({
      label: 'Model',
      originalLabel: 'Style',
      widthState: 'nonzero',
    });
  });

  it.each([
    { tenantId: '' },
    { coCode: ' 1' },
    { lcCode: 1 },
    { coYear: ['2024-2025'] },
    { coBook: 'R811' },
    { coBook: 'R\n1' },
    { policy: {} },
    { width: 0 },
    { cells: { 18: '1' } },
    { cached: { 45: '0' } },
  ])('refuses malformed or client-enriched scope %j before resolving', (patch) => {
    expect(() =>
      resolveSaleReturnIncomingConfiguration({ ...scope, ...patch } as typeof scope, base()),
    ).toThrowError(/explicit text|complete selected/);
  });

  it.each([
    ['0', 'N', 0],
    ['1', 'N', 1],
    ['2', 'N', 2],
    ['3', 'N', 3],
    ['4', 'N', 0],
    ['2147483647', 'N', 0],
    ['-2147483648', 'Y', 2],
    ['0', 'Y', 2],
    ['4', 'Y', 2],
  ] as const)(
    'applies source integral rounding precedence %s/%s → %s',
    (precision, all, expected) => {
      const observations = base();
      Object.assign(observations.settings[0]!.raw, { LBR_ROF: precision, ALL_ROF_REMOVE: all });
      expect(
        resolveSaleReturnIncomingConfiguration(scope, observations).policy?.labourRoundingDecimals,
      ).toBe(expected);
    },
  );

  it.each([
    '2147483648',
    '-2147483649',
    '1.5',
    'NaN',
    'Infinity',
    '-Infinity',
    '',
    null,
    ' 2',
    '+2',
    '2x',
  ])('contains unsupported Int32 conversion %s even with the final Y override', (precision) => {
    const observations = base();
    Object.assign(observations.settings[0]!.raw, { LBR_ROF: precision, ALL_ROF_REMOVE: 'Y' });
    const dto = resolveSaleReturnIncomingConfiguration(scope, observations);
    expect(dto.policy).toBeNull();
    expect(dto.rawSettings['CO_SET.LBR_ROF']).toBe(precision);
    expect(dto.diagnostics).toContainEqual(
      expect.objectContaining({ code: 'unsupported-labour-rounding', blocking: true }),
    );
  });

  it('requires unique CO_SET_NEW even in a pure historical duplicate observation', () => {
    const observations = base();
    observations.newSettings.push(row({ LBR_WITH_GHT: 'Y' }, '2'));
    expect(resolveSaleReturnIncomingConfiguration(scope, observations)).toMatchObject({
      policy: null,
      capabilities: { canCalculate: false },
    });
  });

  it('versions physical source changes even when raw or effective policy is unchanged', () => {
    const observations = base();
    const initial = resolveSaleReturnIncomingConfiguration(scope, observations);
    observations.settings[0]!.revision = '11';
    const updated = resolveSaleReturnIncomingConfiguration(scope, observations);
    expect(updated.policy).toEqual(initial.policy);
    expect(updated.version).not.toBe(initial.version);
    observations.settings[0]!.physicalId = '9';
    expect(resolveSaleReturnIncomingConfiguration(scope, observations).version).not.toBe(
      updated.version,
    );
    expect(Object.keys(initial.rawSettings).sort()).toEqual([
      'CO_SET.ALL_ROF_REMOVE',
      'CO_SET.LBR_RATE_GEN',
      'CO_SET.LBR_ROF',
      'CO_SET.LBR_TYPE',
      'CO_SET.SL_AMT_TYPE',
      'CO_SET_NEW.LBR_WITH_GHT',
    ]);
  });

  it('orders independent physical observations for deterministic tokens without selecting an arbitrary duplicate', () => {
    const observations = base();
    observations.columns = [
      row(
        { BOOK_NAME: 'SALES RETURNE', COL_NAME: 'Fine', COL_NEW_NAME: 'Metal fine', YES_NO: 'Y' },
        '3',
      ),
      row(
        { BOOK_NAME: 'SALES RETURNE', COL_NAME: 'Fine', COL_NEW_NAME: 'Metal fine', YES_NO: 'Y' },
        '9',
      ),
    ];
    const first = resolveSaleReturnIncomingConfiguration(scope, observations);
    observations.columns.reverse();
    expect(resolveSaleReturnIncomingConfiguration(scope, observations)).toEqual(first);
    expect(first.policy).toBeNull();
  });
});
