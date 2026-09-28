import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import {
  createSaleReturnIncomingState,
  reduceSaleReturnIncoming,
  saleReturnIncomingCells,
} from '@datacare/core';
import {
  resolveSaleReturnIncomingConfiguration as resolve,
  SALE_RETURN_INCOMING_COLUMN_CATALOG as catalog,
  type SaleReturnIncomingConfigurationObservations as Observations,
  type SaleReturnIncomingConfigurationRow as Row,
} from '../src/modules/sales/saleReturnIncomingConfiguration.js';

const vectorBytes = readFileSync(
  new URL('./fixtures/saleReturnIncomingConfiguration.independent.json', import.meta.url),
);
const expected = JSON.parse(vectorBytes.toString()) as {
  baseSettings: Record<string, string | null>;
  baseNewSettings: Record<string, string | null>;
  cases: Array<{
    id: string;
    settings: Record<string, string | null>;
    newSettings: Record<string, string | null>;
    expected: Record<string, string | number | boolean | null>;
  }>;
};
// These are the unchanged portable core fixtures, independently authored before either implementation.
const coreBytes = readFileSync(
  new URL(
    '../../../packages/core/test/fixtures/saleReturnIncoming.independent.json',
    import.meta.url,
  ),
);
const widthBytes = readFileSync(
  new URL('../../../packages/core/test/fixtures/saleReturnIncoming.widths.json', import.meta.url),
);
const core = JSON.parse(coreBytes.toString()) as { baseCells: Record<number, string> };
const widths = JSON.parse(widthBytes.toString()) as {
  baseColumnWidths: Record<number, number>;
  vectors: Array<{
    id: string;
    initialCells: Record<number, string>;
    columnWidths: Record<number, number>;
    event: { column: number; text: string };
    expectedCells: Record<number, string>;
  }>;
};
const scope = {
  tenantId: 'config-review',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  coBook: 'R81',
};
function row(
  raw: Record<string, string | null>,
  physicalId = '1',
  revision = '11',
  locator = '(0,1)',
): Row {
  return { raw: { CO_CODE: '01', ...raw }, physicalId, revision, locator };
}
function observations(): Observations {
  return {
    settings: [row(expected.baseSettings)],
    newSettings: [row(expected.baseNewSettings)],
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
    years: [
      row({
        CO_YEAR: '2024-2025',
        OP_DATE: '2024-04-01T00:00:00.123456',
        CL_DATE: '2025-03-31T23:59:59.987654',
      }),
    ],
  };
}
let columnSequence = 1000;
function column(name: string | null, values: Record<string, string | null> = {}): Row {
  const physicalId = String(++columnSequence);
  return row(
    {
      BOOK_NAME: 'SALES RETURNE',
      COL_NAME: name,
      COL_NEW_NAME: name,
      YES_NO: 'Y',
      COL_RPT: 'N',
      ...values,
    },
    physicalId,
    '11',
    `(0,${physicalId})`,
  );
}
function resolvedColumn(result: ReturnType<typeof resolve>, index: number) {
  return result.columns.find((item) => item.sourceColumn === index)!;
}

describe('independent effective Return configuration review', () => {
  it('pins the independently authored expectations and frozen source/IL core fixtures', () => {
    expect(createHash('sha256').update(vectorBytes).digest('hex')).toBe(
      '2a75aa523224004fa7ac5e015e6c70a8260db9b18ec3c087c6fa65c5c3cc6e7f',
    );
    expect(createHash('sha256').update(coreBytes).digest('hex')).toBe(
      'ad1184e6bb7f7256e42e85b5469ea3152404fba25566465389bc6a7ba4367527',
    );
    expect(createHash('sha256').update(widthBytes).digest('hex')).toBe(
      '3c0bef2a5aa86fca83d8c0e98b56e36c553595f2b941a06642409ce7e631d309',
    );
    expect(expected.cases).toHaveLength(35);
    expect(widths.vectors).toHaveLength(8);
  });
  for (const vector of expected.cases)
    it(vector.id, () => {
      const obs = observations();
      Object.assign(obs.settings[0]!.raw, vector.settings);
      Object.assign(obs.newSettings[0]!.raw, vector.newSettings);
      const before = structuredClone(obs);
      const result = resolve(scope, obs);
      expect(obs).toEqual(before);
      for (const [key, value] of Object.entries(vector.settings))
        expect(result.rawSettings[`CO_SET.${key}`]).toBe(value);
      for (const [key, value] of Object.entries(vector.newSettings))
        expect(result.rawSettings[`CO_SET_NEW.${key}`]).toBe(value);
      expect(result.capabilities.canSaveNumeric).toBe(false);
      if (vector.expected.canCalculate === false) {
        expect(result.capabilities.canCalculate).toBe(false);
        expect(result.policy).toBeNull();
        expect(result.diagnostics.some((d) => d.blocking)).toBe(true);
      } else {
        expect(result.capabilities.canCalculate).toBe(true);
        for (const [key, value] of Object.entries(vector.expected)) {
          if (key === 'newRowLabourType') expect(result.newRowDefaults.labourType).toBe(value);
          else expect(result.policy).toHaveProperty(key, value);
        }
      }
    });

  it('publishes 71 stable source identities and immutable catalog definitions without numeric permission', () => {
    const result = resolve(scope, observations());
    expect(result.columns).toHaveLength(71);
    expect(new Set(result.columns.map((c) => c.id)).size).toBe(71);
    for (let index = 0; index < 71; index++) {
      expect(resolvedColumn(result, index).id).toBe(
        `x13.primary-incoming.c${String(index).padStart(2, '0')}`,
      );
      expect(Object.isFrozen(catalog[index])).toBe(true);
    }
    expect(Object.isFrozen(catalog)).toBe(true);
    expect(resolvedColumn(result, 41)).toMatchObject({
      sourceName: null,
      storageField: null,
      widthState: 'zero',
      commitKind: 'none',
    });
    expect(resolvedColumn(result, 42)).toMatchObject({
      sourceName: null,
      storageField: null,
      widthState: 'zero',
      commitKind: 'none',
    });
    expect(resolvedColumn(result, 45)).toMatchObject({
      sourceName: null,
      storageField: null,
      widthState: 'zero',
      commitKind: 'none',
    });
    expect(resolvedColumn(result, 40)).toMatchObject({
      storageField: 'VCH_SRNO',
      widthState: 'zero',
      commitKind: 'none',
    });
    expect(result.capabilities).toEqual({ canCalculate: true, canSaveNumeric: false });
  });
  it('keeps unrelated-family/company rows from acting as a runtime company00 fallback', () => {
    const obs = observations();
    const before = resolve(scope, obs);
    obs.columns = [
      column('Fine', { CO_CODE: '00', YES_NO: 'N' }),
      column('Fine', { CO_CODE: '02', YES_NO: 'N' }),
      column('Fine', { BOOK_NAME: 'SALES', YES_NO: 'N' }),
    ];
    const after = resolve(scope, obs);
    expect(after.version).toBe(before.version);
    expect(after.policy?.fineColumnWidth).toBe(1000);
    expect(resolvedColumn(after, 18)).toMatchObject({ configured: false, widthState: 'nonzero' });
  });
  it('matches original names once and never chains renamed captions into another source override', () => {
    const obs = observations();
    obs.columns = [
      column('Fine', { COL_NEW_NAME: 'Rate' }),
      column('Rate', { COL_NEW_NAME: 'Shared', YES_NO: 'N' }),
      column('Touch', { COL_NEW_NAME: 'Shared' }),
    ];
    const result = resolve(scope, obs);
    expect(resolvedColumn(result, 18)).toMatchObject({
      label: 'Rate',
      widthState: 'nonzero',
      storageField: 'ITM_FINE',
    });
    expect(resolvedColumn(result, 19)).toMatchObject({
      label: 'Shared',
      widthState: 'zero',
      storageField: 'ITM_RATE',
    });
    expect(resolvedColumn(result, 16)).toMatchObject({
      label: 'Shared',
      widthState: 'nonzero',
      storageField: 'ITM_TOUCH',
    });
    expect(result.capabilities.canCalculate).toBe(true);
    expect(
      result.diagnostics.filter((d) => d.code === 'duplicate-caption').every((d) => !d.blocking),
    ).toBe(true);
  });
  it('allows an exact empty caption without rewriting it to a fallback, separately from NULL', () => {
    const obs = observations();
    obs.columns = [column('Fine', { COL_NEW_NAME: '' })];
    const blank = resolve(scope, obs);
    expect(blank.capabilities.canCalculate).toBe(true);
    expect(resolvedColumn(blank, 18).label).toBe('');
    obs.columns[0]!.raw.COL_NEW_NAME = null;
    const missing = resolve(scope, obs);
    expect(missing.capabilities.canCalculate).toBe(false);
    expect(resolvedColumn(missing, 18).label).toBeNull();
    expect(missing.diagnostics).toEqual(
      expect.arrayContaining([
        expect.objectContaining({ code: 'null-column-label', blocking: true }),
      ]),
    );
  });
  it('retains Sr and RecCode final widths while only RecCode accepts a caption override', () => {
    const obs = observations();
    obs.columns = [
      column('Sr', { YES_NO: 'N', COL_NEW_NAME: 'Wrong serial' }),
      column('RecCode', { YES_NO: 'N', COL_NEW_NAME: 'Received code' }),
    ];
    const result = resolve(scope, obs);
    expect(resolvedColumn(result, 0)).toMatchObject({
      label: 'Sr',
      nominalWidth: 325,
      widthState: 'nonzero',
      configured: false,
    });
    expect(resolvedColumn(result, 1)).toMatchObject({
      label: 'Received code',
      nominalWidth: 300,
      widthState: 'nonzero',
      forcedVisible: true,
    });
    expect(result.capabilities.canCalculate).toBe(true);
  });
  it('retains forced RecCode positive width even when its family has a normalization ambiguity', () => {
    const obs = observations();
    obs.columns = [column('RecCode', { BOOK_NAME: 'sales returne', YES_NO: 'N' })];
    const result = resolve(scope, obs);
    expect(result.capabilities.canCalculate).toBe(false);
    expect(resolvedColumn(result, 1)).toMatchObject({
      nominalWidth: 300,
      widthState: 'nonzero',
      forcedVisible: true,
    });
  });
  it('does not re-resolve an ambiguous Fine alias as zero after applying an exact Fine/N row', () => {
    const obs = observations();
    obs.columns = [column('Fine', { YES_NO: 'N' }), column('fine', { YES_NO: 'Y' })];
    const result = resolve(scope, obs);
    expect(result.capabilities.canCalculate).toBe(false);
    expect(result.policy).toBeNull();
    expect(resolvedColumn(result, 18).widthState).toBe('unresolved');
  });
  it.each(['Y', '', 'N'])(
    'does not graft COL_RPT=%s onto calculation width or repeat policy',
    (flag) => {
      const obs = observations();
      obs.columns = [column('Fine', { YES_NO: 'N', COL_RPT: flag })];
      const result = resolve(scope, obs);
      expect(result.capabilities.canCalculate).toBe(true);
      expect(result.policy?.fineColumnWidth).toBe(0);
      expect(resolvedColumn(result, 18)).not.toHaveProperty('repeat');
    },
  );
  it('contains duplicate settings/column identities even when their effective values are identical', () => {
    for (const part of ['settings', 'newSettings', 'columns'] as const) {
      const obs = observations();
      if (part === 'columns') obs.columns = [column('Fine')];
      obs[part].push({ ...structuredClone(obs[part][0]!), physicalId: '2', locator: '(0,2)' });
      const result = resolve(scope, obs);
      expect(result.capabilities.canCalculate, part).toBe(false);
      expect(result.policy).toBeNull();
    }
  });
  it('contains missing settings rows without inventing web2dp or company00 defaults', () => {
    for (const part of ['settings', 'newSettings'] as const) {
      const obs = observations();
      obs[part] = [row({ ...obs[part][0]!.raw, CO_CODE: '00' })];
      const result = resolve(scope, obs);
      expect(result.capabilities.canCalculate, part).toBe(false);
      expect(result.policy).toBeNull();
    }
  });
  it('leaves unknown edition Style unresolved without blocking known Fine policy', () => {
    const obs = observations();
    obs.columns = [column('Style', { YES_NO: 'Y' })];
    const result = resolve(scope, obs);
    expect(resolvedColumn(result, 6).widthState).toBe('unresolved');
    expect(result.policy?.fineColumnWidth).toBe(1000);
    expect(result.capabilities.canCalculate).toBe(true);
  });
  it.each(['L', 'B', 'S', 'U', 'P'] as const)(
    'cannot reveal source-hidden Style in edition%s with a Y override',
    (value) => {
      const obs = observations();
      obs.edition = { state: 'resolved', value, version: 'edition1' };
      obs.columns = [column('Style', { YES_NO: 'Y' })];
      const result = resolve(scope, obs);
      expect(resolvedColumn(result, 6)).toMatchObject({
        widthState: 'zero',
        nominalWidth: 0,
        label: null,
      });
      expect(result.capabilities.canCalculate).toBe(true);
    },
  );
  it.each(['A', 'E'] as const)(
    'resolves Style only from server edition%s and allows N to hide it',
    (value) => {
      const obs = observations();
      obs.edition = { state: 'resolved', value, version: 'edition1' };
      const visible = resolve(scope, obs);
      expect(resolvedColumn(visible, 6)).toMatchObject({
        widthState: 'nonzero',
        nominalWidth: 1200,
        label: 'Style',
      });
      obs.columns = [column('Style', { YES_NO: 'N', COL_NEW_NAME: 'Model' })];
      expect(resolvedColumn(resolve(scope, obs), 6)).toMatchObject({
        widthState: 'zero',
        nominalWidth: 0,
        label: 'Model',
      });
    },
  );
  it('returns detached raw whitelist/captions without mutating observations or global definitions', () => {
    const obs = observations();
    obs.settings[0]!.raw.SMS_LINK = 'private-not-a-calculation-field';
    obs.columns = [column('Fine', { COL_NEW_NAME: 'Fine exact' })];
    const before = structuredClone(obs),
      result = resolve(scope, obs);
    expect(obs).toEqual(before);
    expect(Object.keys(result.rawSettings).sort()).toEqual(
      [
        'CO_SET.ALL_ROF_REMOVE',
        'CO_SET.LBR_RATE_GEN',
        'CO_SET.LBR_ROF',
        'CO_SET.LBR_TYPE',
        'CO_SET.SL_AMT_TYPE',
        'CO_SET_NEW.LBR_WITH_GHT',
      ].sort(),
    );
    expect(JSON.stringify(result)).not.toContain('private-not-a-calculation-field');
    result.rawSettings['CO_SET.LBR_ROF'] = '9';
    resolvedColumn(result, 18).label = 'changed response';
    expect(obs).toEqual(before);
    expect(catalog[18]?.label).toBe('Fine');
    expect(resolve(scope, obs).rawSettings['CO_SET.LBR_ROF']).toBe('0');
  });
  it('keeps full-scope tokens distinct while two configured Return books share company policy', () => {
    const obs = observations();
    obs.books.push(row({ ...obs.books[0]!.raw, CO_BOOK: 'R82' }, '2'));
    const a = resolve(scope, obs),
      b = resolve({ ...scope, coBook: 'R82' }, obs);
    expect(a.policy).toEqual(b.policy);
    expect(a.version).not.toBe(b.version);
    expect(resolve({ ...scope, tenantId: 'other-tenant' }, obs).version).not.toBe(a.version);
  });
  it('stably hashes order-independent observations while observing revision/locator and selected-year precision', () => {
    const obs = observations();
    obs.columns = [column('Fine'), column('Rate')];
    const a = resolve(scope, obs);
    obs.columns.reverse();
    const originalLocator = obs.columns[0]!.locator;
    expect(resolve(scope, obs).version).toBe(a.version);
    obs.columns[0]!.revision = '12';
    expect(resolve(scope, obs).version).not.toBe(a.version);
    obs.columns[0]!.revision = '13';
    expect(resolve(scope, obs).version).not.toBe(a.version);
    obs.columns[0]!.revision = '11';
    obs.columns[0]!.locator = '(2,4)';
    expect(resolve(scope, obs).version).not.toBe(a.version);
    obs.columns[0]!.locator = originalLocator;
    expect(resolve(scope, obs).version).toBe(a.version);
    obs.years[0]!.raw.CL_DATE = '2025-03-31T23:59:59.987655';
    expect(resolve(scope, obs).version).not.toBe(a.version);
  });
  it('documents absence-cycle limits: exact absent observations cannot record intervening insert/delete history', () => {
    const obs = observations(),
      original = resolve(scope, obs);
    obs.columns = [column('Fine', { YES_NO: 'N' })];
    expect(resolve(scope, obs).version).not.toBe(original.version);
    obs.columns = [];
    expect(resolve(scope, obs).version).toBe(original.version);
    // This equality is an explicit read-snapshot limitation, not universal ABA acceptance.
  });
  it('preserves the declared existing-book compatibility for blank table/direction without accepting contradictions', () => {
    const obs = observations();
    obs.books[0]!.raw.BOOK_TBL_NAME = '';
    obs.books[0]!.raw.BOOK_INOUT = '';
    expect(resolve(scope, obs).capabilities.canCalculate).toBe(true);
    obs.books[0]!.raw.BOOK_TBL_NAME = 'PR_DATA';
    expect(() => resolve(scope, obs)).toThrow();
  });

  for (const vector of widths.vectors)
    it('resolved configuration drives frozen core: ' + vector.id, () => {
      const obs = observations();
      obs.settings[0]!.raw.SL_AMT_TYPE = 'F';
      const zeroPredicate = { ...widths.baseColumnWidths, ...vector.columnWidths };
      obs.columns = Object.entries(zeroPredicate).map(([index, width]) =>
        column(catalog[Number(index)]!.sourceName!, { YES_NO: width === 0 ? 'N' : 'Y' }),
      );
      const configuration = resolve(scope, obs);
      expect(configuration.capabilities.canCalculate).toBe(true);
      if (!configuration.policy) throw new Error('Expected valid source configuration');
      const before = createSaleReturnIncomingState({
        rowIdentity: 'complete-saved-row17',
        raw: { SR_NO: '17', ITM_REMARK: null },
        cells: { ...core.baseCells, ...vector.initialCells },
        cacheMode: 'provided',
      });
      const col = resolvedColumn(configuration, vector.event.column);
      const result = reduceSaleReturnIncoming(
        before,
        {
          kind: 'leaveCell',
          rowIdentity: before.rowIdentity,
          column: col.sourceColumn,
          text: vector.event.text,
          context: {
            currentRow: 1,
            clearing: false,
            editorVisible: true,
            committedColumnWidth: col.nominalWidth,
          },
        },
        configuration.policy,
      );
      expect(result.status).toBe(col.widthState === 'zero' ? 'skipped' : 'applied');
      expect(saleReturnIncomingCells(result.state)).toMatchObject(vector.expectedCells);
      expect(configuration.widthMode).toBe('source-zero-predicate');
      expect(configuration.capabilities.canSaveNumeric).toBe(false);
    });
});
