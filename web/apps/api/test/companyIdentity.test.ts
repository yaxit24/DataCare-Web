import { describe, expect, it } from 'vitest';
import { normalizeCompanyIdentity } from '../src/modules/masters/companyIdentity.js';
// MS_COMPANY.cs:6042-6065,6074-6108
describe('Company desktop identity validation', () => {
  it('requires identity', () => {
    expect(() => normalizeCompanyIdentity({ CO_CODE: '01' })).toThrow('Enter Company Detail');
  });
  it('preserves all supplied identity fields and desktop casing', () => {
    const row = normalizeCompanyIdentity({
      CO_CODE: '01',
      CO_NAME: 'test',
      CO_ADD1: 'road',
      CO_STATE: 'A'.repeat(30),
      CO_TYPE: 'a',
      REP_ADD_TYPE: 'B',
    });
    expect(row.CO_NAME).toBe('TEST');
    expect(row.CO_ADD1).toBe('ROAD');
    expect(row.CO_TYPE).toBe('A');
    expect(row.CO_STATE).toBe('A'.repeat(25));
    expect(row.REP_ADD_TYPE).toBe('B');
  });
  it('rejects overlong identity without silent loss', () => {
    expect(() => normalizeCompanyIdentity({ CO_CODE: '01', CO_NAME: 'A'.repeat(51) })).toThrow();
  });
});
