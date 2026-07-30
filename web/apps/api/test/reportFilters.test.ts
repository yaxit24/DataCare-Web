import { describe, expect, it } from 'vitest';
import {
  filterWhere,
  readFilters,
  REPORT_FILTER_KEYS,
  supportedFilters,
  unsupportedFilters,
  type FilterBinding,
  type ReportFilters,
} from '../src/modules/reports/reportFilters.js';

/**
 * The shared `RP_ALL` filter matrix.
 *
 * The properties pinned here are the ones that would silently produce wrong reports if got wrong: which
 * column each control drives (two of them are misleadingly named), and the refusal of a dimension the
 * report cannot honour.
 */
describe('report filter matrix', () => {
  const full: FilterBinding = {
    data: 'd',
    party: 'p',
    item: 'i',
    custNameAlias: 'o',
  };

  it('covers all eleven desktop panel dimensions', () => {
    // Extracted from RP_ALL.cs: tBookCode, tAcCode, tLcCode, cboCity, cboArea, tItCode, cboItemTyp,
    // tGrCode, cboState, cboEmploy, tCustName.
    expect(REPORT_FILTER_KEYS).toHaveLength(11);
  });

  it('binds tItCode to PR_CODE, not IT_CODE', () => {
    // The control is called tItCode but drives the PRODUCT code. Binding it to IT_CODE would filter the
    // wrong column on 30 reports.
    const params: unknown[] = [];
    const sql = filterWhere({ prCode: 'P7' }, full, params);
    expect(sql).toContain('i."PR_CODE"=$1');
    expect(sql).not.toContain('IT_CODE');
    expect(params).toEqual(['P7']);
  });

  it('binds grCode to the item group by default and to AC_ANGDIYA where the report says so', () => {
    // One control, two dimensions. The rate-cut family binds it to the data table's AC_ANGDIYA column.
    const a: unknown[] = [];
    expect(filterWhere({ grCode: 'GO' }, full, a)).toContain('i."GR_CODE"=$1');

    const b: unknown[] = [];
    const rateCut: FilterBinding = { data: 'd', grCodeDataColumn: 'AC_ANGDIYA' };
    const sql = filterWhere({ grCode: 'ANG1' }, rateCut, b);
    expect(sql).toContain('d."AC_ANGDIYA"=$1');
    expect(sql).not.toContain('GR_CODE');
  });

  it('uses MEMB_CODE for the party filter on the scheme tables', () => {
    const params: unknown[] = [];
    const scheme: FilterBinding = { data: 'ad', partyCodeColumn: 'MEMB_CODE', member: 'm' };
    const sql = filterWhere({ acCode: 'M001', area: 'North' }, scheme, params);
    expect(sql).toContain('ad."MEMB_CODE"=$1');
    // Schemes filter geography on AD_MEMB rather than AC_MAST.
    expect(sql).toContain('m."AC_AREA"=$2');
  });

  it('treats a blank filter as "all", exactly as the desktop guard does', () => {
    const params: unknown[] = [];
    // Blank, whitespace and undefined must all be skipped, not matched as empty string.
    const sql = filterWhere({ acCode: '', city: '   ', grCode: undefined }, full, params);
    expect(sql).toBe('');
    expect(params).toEqual([]);
  });

  it('truncates item type to one character', () => {
    // IT_TYPE stores Strings.Mid(cboItemTyp.Text, 1, 1) — the first character of the label.
    const params: unknown[] = [];
    filterWhere({ itType: 'Silver' }, full, params);
    expect(params).toEqual(['S']);
  });

  it('numbers parameters from the caller array so it can follow other predicates', () => {
    // Builders assemble their own positional parameters; the matrix must continue the sequence, not restart.
    const params: unknown[] = ['01', '2425'];
    const sql = filterWhere({ acCode: 'CASH', bookCode: 'SL' }, full, params);
    expect(sql).toContain('d."AC_CODE"=$3');
    expect(sql).toContain('d."CO_BOOK"=$4');
    expect(params).toEqual(['01', '2425', 'CASH', 'SL']);
  });

  it('refuses a dimension the report cannot honour rather than dropping it', () => {
    // A report with no ITEM_MAST join cannot filter by group. Silently ignoring would show the operator a
    // wider result set as if it were filtered — the worst outcome.
    const noItem: FilterBinding = { data: 'd' };
    expect(unsupportedFilters({ grCode: 'GO', prCode: 'P1' }, noItem)).toEqual([
      'grCode',
      'prCode',
    ]);
    // And a supported one is not reported.
    expect(unsupportedFilters({ acCode: 'CASH' }, noItem)).toEqual([]);
    // A blank value for an unsupported dimension is not an error: nothing was asked for.
    expect(unsupportedFilters({ grCode: '' }, noItem)).toEqual([]);
  });

  it('reports state as unsupported when only AD_MEMB is bound', () => {
    // AD_MEMB carries AC_AREA and AC_CITY but the desktop never filters scheme reports by state.
    const scheme: FilterBinding = { data: 'ad', member: 'm' };
    expect(unsupportedFilters({ area: 'N', city: 'C' }, scheme)).toEqual([]);
    expect(unsupportedFilters({ state: 'GJ' }, scheme)).toEqual(['state']);
  });

  it('lists supported dimensions per binding', () => {
    expect(supportedFilters(full).sort()).toEqual([...REPORT_FILTER_KEYS].sort());
    expect(supportedFilters({ data: 'd' }).sort()).toEqual(
      ['acCode', 'bookCode', 'empCode', 'lcCode'].sort(),
    );
    expect(supportedFilters({})).toEqual([]);
  });

  it('reads and bounds filters from a query string', () => {
    const f: ReportFilters = readFilters({
      acCode: '  CASH  ',
      itType: 'Silver',
      grCode: '',
      custName: 'x'.repeat(200),
    });
    expect(f.acCode, 'trimmed').toBe('CASH');
    expect(f.itType, 'single character').toBe('S');
    expect(f.grCode, 'blank becomes absent').toBeUndefined();
    expect(f.custName?.length, 'bounded').toBe(60);
  });
});
