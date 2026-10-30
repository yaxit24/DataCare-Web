import { describe, expect, it } from 'vitest';
import { exactCodeRow, isCurrentAnswer, lookupEnterAction } from '../lib/lookupEnter';

/** G185: Enter in a lookup never picks from a list fetched for different text (TR_PURC.cs:14619-14628). */
describe('lookupEnterAction', () => {
  it('picks the highlighted row only when the open list belongs to the typed text', () => {
    expect(lookupEnterAction({ open: true, rowCount: 3, rowsFor: 'SUPL', value: 'SUPL' })).toBe(
      'pick-highlighted',
    );
  });
  it('the 30 October case: list still shows the rows for "" (BANK first) when SUPL + Enter arrive', () => {
    expect(lookupEnterAction({ open: true, rowCount: 20, rowsFor: '', value: 'SUPL' })).toBe(
      'resolve-typed',
    );
  });
  it('a list for a shorter prefix is stale too (SUP shown, SUPL typed)', () => {
    expect(lookupEnterAction({ open: true, rowCount: 2, rowsFor: 'SUP', value: 'SUPL' })).toBe(
      'resolve-typed',
    );
  });
  it('a closed list or one that has not arrived resolves the typed code', () => {
    expect(lookupEnterAction({ open: false, rowCount: 0, rowsFor: null, value: 'CUST01' })).toBe(
      'resolve-typed',
    );
    expect(lookupEnterAction({ open: true, rowCount: 0, rowsFor: 'CUST01', value: 'CUST01' })).toBe(
      'resolve-typed',
    );
  });
  it('nothing typed and no list: Enter is left to the form', () => {
    expect(lookupEnterAction({ open: false, rowCount: 0, rowsFor: null, value: '  ' })).toBe(
      'none',
    );
  });
});

describe('exactCodeRow', () => {
  const rows = [{ code: 'SUPPLIER2' }, { code: 'SUPL' }, { code: 'BANK' }];
  it('finds the exact code, ignoring case and spaces, not a prefix match', () => {
    expect(exactCodeRow(rows, ' supl ')).toEqual({ code: 'SUPL' });
    expect(exactCodeRow(rows, 'SUP')).toBeUndefined();
    expect(exactCodeRow(rows, '')).toBeUndefined();
  });
});

describe('isCurrentAnswer', () => {
  it('drops an answer for older text', () => {
    expect(isCurrentAnswer('SUP', 'SUPL')).toBe(false);
    expect(isCurrentAnswer('SUPL', 'SUPL')).toBe(true);
  });
});
