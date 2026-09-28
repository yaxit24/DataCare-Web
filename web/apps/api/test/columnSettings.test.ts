import { describe, expect, it } from 'vitest';
import {
  COLUMN_SETTING_KEYS,
  columnSettingInput,
  columnSettingListOptions,
} from '../src/modules/masters/columnSettings.js';
import { COL_MAST_CONFIG } from '../src/modules/masters/configs.js';
import { buildUpdate } from '../src/modules/masters/master.service.js';
const scope = { tenantId: 'columns-test', coCode: '01', lcCode: '02' };
const key = { CO_CODE: '01', BOOK_NAME: 'SALES RETURNE', COL_NAME: 'Fine' };
const version = 'a'.repeat(64);

describe('column setting identity and mutation envelope', () => {
  it('requires the desktop company/family/original-name key and never SETs family as a mutable value', () => {
    expect(COL_MAST_CONFIG.keyColumns).toEqual(COLUMN_SETTING_KEYS);
    expect(COL_MAST_CONFIG.requiredColumns).toEqual(COLUMN_SETTING_KEYS);
    const built = buildUpdate(COL_MAST_CONFIG, key, { ...key, COL_NEW_NAME: 'Pure metal' });
    expect(built.setCols).toEqual(['COL_NEW_NAME']);
    expect(built.sql).toContain('"BOOK_NAME"::text=$2::text');
    expect(built.params).toEqual(['01', 'SALES RETURNE', 'Fine', 'Pure metal']);
  });
  it('preserves exact names, partial NULL intent and immutable observation token', () => {
    expect(
      columnSettingInput(
        scope,
        { ...key, COL_NAME: 'Receive Item', COL_NEW_NAME: null, version },
        'update',
      ),
    ).toEqual({
      key: { ...key, COL_NAME: 'Receive Item' },
      changes: { COL_NEW_NAME: null },
      version,
    });
    expect(
      columnSettingInput(scope, { BOOK_NAME: 'A B', COL_NAME: 'B C', YES_NO: 'N' }, 'create'),
    ).toEqual({
      key: { CO_CODE: '01', BOOK_NAME: 'A B', COL_NAME: 'B C' },
      changes: { YES_NO: 'N' },
    });
  });
  it.each([
    null,
    [],
    'Fine',
    1,
    { COL_NAME: 'Fine' },
    { BOOK_NAME: ' ', COL_NAME: 'Fine' },
    { BOOK_NAME: ' A', COL_NAME: 'Fine' },
    { BOOK_NAME: 'A', COL_NAME: 'Fine ' },
    { BOOK_NAME: 'A', COL_NAME: 'Fine\n' },
    { BOOK_NAME: 'A', COL_NAME: null },
    { BOOK_NAME: {}, COL_NAME: 'Fine' },
    { ...key, CO_CODE: '99' },
    { ...key, row_id: '1' },
    { ...key, tenant_id: 'another' },
    { ...key, STYLE_CODE: 'fake' },
    { ...key, COL_NEW_NAME: {} },
    { ...key, COL_NEW_NAME: 'x'.repeat(256) },
  ])('rejects malformed or incomplete create payload %#', (payload) => {
    expect(() => columnSettingInput(scope, payload, 'create')).toThrow();
  });
  it.each([undefined, null, '', 'old', 'f'.repeat(63), 'Z'.repeat(64)])(
    'requires an actual observation on mutation %#',
    (token) => {
      expect(() =>
        columnSettingInput(scope, { ...key, COL_NEW_NAME: '', version: token }, 'update'),
      ).toThrow(/version/);
      expect(() => columnSettingInput(scope, { ...key, version: token }, 'delete')).toThrow(
        /version/,
      );
    },
  );
  it('does not allow delete payloads to smuggle mutable or surrogate fields', () => {
    expect(() =>
      columnSettingInput(scope, { ...key, version, COL_NEW_NAME: 'Other' }, 'delete'),
    ).toThrow(/unsupported/);
    expect(() => columnSettingInput(scope, { ...key, version }, 'update')).toThrow(/Supply/);
    expect(() => columnSettingInput(scope, { ...key, version }, 'create')).toThrow(/unsupported/);
  });
});

describe('column setting list options', () => {
  it('bounds pagination and preserves literal family/search strings', () => {
    expect(columnSettingListOptions()).toEqual({ offset: 0, limit: 100, family: '', search: '' });
    expect(
      columnSettingListOptions({
        offset: '50',
        limit: '50',
        family: 'SALES RETURNE',
        search: '50%_Gold',
      }),
    ).toEqual({ offset: 50, limit: 50, family: 'SALES RETURNE', search: '50%_Gold' });
  });
  it.each([
    { offset: -1 },
    { offset: '1.5' },
    { offset: 1000001 },
    { limit: 0 },
    { limit: 501 },
    { limit: 'no' },
    { family: [] },
    { search: {} },
    { search: 'a'.repeat(256) },
    { search: 'a\n' },
  ])('rejects malformed or unbounded list options %#', (input) => {
    expect(() => columnSettingListOptions(input)).toThrow();
  });
});
