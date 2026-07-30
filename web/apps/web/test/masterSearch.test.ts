import { describe, expect, it } from 'vitest';
import { filterMasterRows, rowMatchesSearch } from '../lib/masterSearch';

/**
 * Desktop master-list search semantics.
 *
 * `MS_BOOKLIST.cs` (`tSearchText_TextChanged`) compares each grid cell with
 * `cell.Value.ToString().ToLower().StartsWith(tSearchText.Text.ToLower())`, so matching is a
 * case-insensitive PREFIX over any visible column. Substring matching would land the operator on a
 * different record, so the distinction is pinned rather than assumed.
 */
describe('master list search', () => {
  const rows = [
    { AC_CODE: 'CASH', AC_NAME: 'Cash on Hand', AC_GR: 'CA' },
    { AC_CODE: 'BANK', AC_NAME: 'Bank Current', AC_GR: 'BA' },
    { AC_CODE: 'CAPITAL', AC_NAME: 'Capital Account', AC_GR: 'CP' },
    { AC_CODE: 'GSTIN', AC_NAME: null, AC_GR: 'DU' },
  ];

  it('matches a prefix in the first column', () => {
    expect(filterMasterRows(rows, 'CA').map((r) => r.AC_CODE)).toEqual(['CASH', 'CAPITAL']);
  });

  it('matches a prefix in any column, not only the first', () => {
    // 'Bank Current' is matched via AC_NAME even though AC_CODE does not start with 'ban'.
    expect(filterMasterRows(rows, 'bank c').map((r) => r.AC_CODE)).toEqual(['BANK']);
  });

  it('is case-insensitive', () => {
    expect(filterMasterRows(rows, 'cash').map((r) => r.AC_CODE)).toEqual(['CASH']);
    expect(filterMasterRows(rows, 'CASH').map((r) => r.AC_CODE)).toEqual(['CASH']);
  });

  it('does NOT match a substring', () => {
    // Desktop uses StartsWith. 'ash' appears inside CASH but must not match.
    expect(filterMasterRows(rows, 'ash')).toEqual([]);
    // 'urrent' is inside 'Bank Current' but is not a prefix of any cell.
    expect(filterMasterRows(rows, 'urrent')).toEqual([]);
  });

  it('returns every row for an empty or whitespace query', () => {
    expect(filterMasterRows(rows, '')).toHaveLength(rows.length);
    expect(filterMasterRows(rows, '   ')).toHaveLength(rows.length);
  });

  it('tolerates null cells', () => {
    expect(() => filterMasterRows(rows, 'g')).not.toThrow();
    expect(filterMasterRows(rows, 'gst').map((r) => r.AC_CODE)).toEqual(['GSTIN']);
  });

  it('can be limited to specific columns', () => {
    // Restricting to AC_CODE means the AC_NAME prefix no longer matches.
    expect(rowMatchesSearch(rows[1], 'bank c', ['AC_CODE'])).toBe(false);
    expect(rowMatchesSearch(rows[1], 'ban', ['AC_CODE'])).toBe(true);
  });
});
