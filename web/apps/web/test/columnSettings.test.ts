import { describe, expect, it } from 'vitest';
import {
  appendColumnSettingsPage,
  columnSettingKey,
  columnSettingPatch,
  columnSettingProblem,
  columnSettingsExport,
  columnSettingsQuery,
  parseColumnSettingsCsv,
  readColumnSettings,
  type ColumnSetting,
} from '../lib/columnSettings';
const row: ColumnSetting = {
  row_id: '117',
  CO_CODE: '01',
  BOOK_NAME: 'SALES RETURNE',
  COL_NAME: 'Fine',
  COL_NEW_NAME: null,
  YES_NO: 'N',
  COL_RPT: null,
  _columnVersion: 'a'.repeat(64),
  _columnIdentityCount: 1,
  _columnCollectionVersion: 'b'.repeat(64),
  _columnTotal: 1,
};
const meta = {
  table: 'COL_MAST',
  keyColumns: ['CO_CODE', 'BOOK_NAME', 'COL_NAME'],
  capabilities: { canCreate: true, canUpdate: true, canDelete: false },
};
describe('column settings client observation and identity', () => {
  it('accepts exact saved NULLs and creates a minimal patch bound to original family/name/version', () => {
    expect(readColumnSettings(meta, [row], '01').rows[0]).toEqual(row);
    expect(
      columnSettingPatch(row, { COL_NEW_NAME: '', COL_RPT: '', YES_NO: 'Y' }, ['YES_NO']),
    ).toEqual({
      CO_CODE: '01',
      BOOK_NAME: 'SALES RETURNE',
      COL_NAME: 'Fine',
      version: row._columnVersion,
      YES_NO: 'Y',
    });
    expect(row.COL_NEW_NAME).toBeNull();
    expect(
      columnSettingPatch(row, { COL_NEW_NAME: '', COL_RPT: '', YES_NO: 'N' }, ['COL_NEW_NAME']),
    ).toHaveProperty('COL_NEW_NAME', '');
  });
  it('preserves case/spacing in original keys rather than using changed captions', () => {
    expect(
      columnSettingKey({
        ...row,
        BOOK_NAME: 'A B',
        COL_NAME: 'Receive Item',
        COL_NEW_NAME: 'New caption',
      }),
    ).toEqual({ CO_CODE: '01', BOOK_NAME: 'A B', COL_NAME: 'Receive Item' });
  });
  it.each([
    { ...row, CO_CODE: '99' },
    { ...row, _columnVersion: '' },
    { ...row, row_id: 1 },
    { ...row, _columnIdentityCount: 0 },
    { ...row, COL_NAME: {} },
    { ...row, _columnCollectionVersion: '' },
    { ...row, _columnTotal: 0 },
  ])('rejects malformed observation %# before enabling actions', (bad) => {
    expect(() => readColumnSettings(meta, [bad], '01')).toThrow();
  });
  it('rejects old two-part metadata, absent capabilities and repeated physical row observations', () => {
    expect(() =>
      readColumnSettings({ ...meta, keyColumns: ['CO_CODE', 'COL_NAME'] }, [row], '01'),
    ).toThrow();
    expect(() => readColumnSettings({ ...meta, capabilities: {} }, [row], '01')).toThrow();
    expect(() => readColumnSettings(meta, [row, row], '01')).toThrow();
  });
  it.each([
    { ...row, BOOK_NAME: null },
    { ...row, COL_NAME: ' ' },
    { ...row, _columnIdentityCount: 2 },
    { ...row, BOOK_NAME: ' A' },
    { ...row, COL_NAME: 'Fine\n' },
  ])('keeps imported invalid/ambiguous identities readable but prevents mutation %#', (bad) => {
    expect(readColumnSettings(meta, [bad], '01').rows).toHaveLength(1);
    expect(columnSettingProblem(bad)).toBeTruthy();
    expect(() => columnSettingKey(bad)).toThrow();
  });
  it('keeps full scope explicit and excludes internal observations from CSV exports', () => {
    expect(
      new URLSearchParams(
        columnSettingsQuery({ coCode: '01', lcCode: '02', coYear: '2024-2025' }),
      ).get('coYear'),
    ).toBe('2024-2025');
    expect(Object.keys(columnSettingsExport([row])[0]!)).toEqual([
      'CO_CODE',
      'BOOK_NAME',
      'COL_NAME',
      'COL_NEW_NAME',
      'COL_RPT',
      'YES_NO',
    ]);
  });
  it('parses quoted multiline captions exactly and ignores only recognized old export metadata', () => {
    expect(
      parseColumnSettingsCsv(
        'row_id,CO_CODE,BOOK_NAME,COL_NAME,COL_NEW_NAME,YES_NO\r\n117,01,SALES RETURNE,Fine,"A, B\n""caption""",N\r\n',
      ),
    ).toEqual([
      {
        CO_CODE: '01',
        BOOK_NAME: 'SALES RETURNE',
        COL_NAME: 'Fine',
        COL_NEW_NAME: 'A, B\n"caption"',
        YES_NO: 'N',
      },
    ]);
  });
  it.each([
    'COL_NAME\nFine',
    'BOOK_NAME,COL_NAME,COL_NAME\nA,B,C',
    'BOOK_NAME,COL_NAME\n"A,B',
    'BOOK_NAME,COL_NAME\n"A"x,B',
    'BOOK_NAME,COL_NAME,STYLE_CODE\nA,B,C',
    'BOOK_NAME,COL_NAME\nA,B,C',
  ])('rejects CSV input that could change or lose identity %#', (csv) => {
    expect(() => parseColumnSettingsCsv(csv)).toThrow();
  });
});

describe('column settings pages', () => {
  const page = (ids: number[], token = 'b'.repeat(64), total = 5) =>
    readColumnSettings(
      meta,
      ids.map((id) => ({
        ...row,
        row_id: String(id),
        COL_NAME: `Column ${id}`,
        _columnTotal: total,
        _columnCollectionVersion: token,
      })),
      '01',
    );
  it('loads all rows across several bounded pages without duplication or dropping final rows', () => {
    const first = page([1, 2]);
    const all = appendColumnSettingsPage(appendColumnSettingsPage(first, page([3, 4])), page([5]));
    expect(all.rows.map((row) => row.row_id)).toEqual(['1', '2', '3', '4', '5']);
    expect(first.rows.map((row) => row.row_id)).toEqual(['1', '2']);
    expect(all.total).toBe(5);
  });
  it('refuses pages after collection edits, filter changes, overlapping rows or unexpected exhaustion', () => {
    const first = page([1, 2]);
    for (const next of [
      page([3], 'c'.repeat(64)),
      page([3], 'b'.repeat(64), 6),
      page([2, 3]),
      readColumnSettings(meta, [], '01'),
    ]) {
      expect(() => appendColumnSettingsPage(first, next)).toThrow(/Reload/);
      expect(first.rows).toHaveLength(2);
    }
  });
  it('rejects internally mixed collection observations', () => {
    expect(() =>
      readColumnSettings(meta, [...page([1]).rows, ...page([2], 'c'.repeat(64)).rows], '01'),
    ).toThrow();
  });
});

it('accepts a UTF-8 BOM before quoted CSV headers without changing data', () => {
  expect(
    parseColumnSettingsCsv('\uFEFF"CO_CODE","BOOK_NAME","COL_NAME"\r\n"01","SALES RETURNE","Fine"'),
  ).toEqual([{ CO_CODE: '01', BOOK_NAME: 'SALES RETURNE', COL_NAME: 'Fine' }]);
});
