import { describe, it, expect } from 'vitest';
import { buildScopeWhere } from '../src/scope.js';

describe('buildScopeWhere', () => {
  it('always includes CO_CODE', () => {
    expect(buildScopeWhere({ coCode: '01' })).toEqual({ CO_CODE: '01' });
  });
  it('includes all composite keys when present', () => {
    expect(buildScopeWhere({ coCode: '01', lcCode: '02', coYear: '2024', coBook: 'SAL' })).toEqual({
      CO_CODE: '01',
      LC_CODE: '02',
      CO_YEAR: '2024',
      CO_BOOK: 'SAL',
    });
  });
  it('omits undefined optional keys', () => {
    const w = buildScopeWhere({ coCode: '01', coYear: '2024' });
    expect(w).toEqual({ CO_CODE: '01', CO_YEAR: '2024' });
    expect('LC_CODE' in w).toBe(false);
    expect('CO_BOOK' in w).toBe(false);
  });
});
