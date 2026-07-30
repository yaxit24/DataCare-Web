import { describe, it, expect } from 'vitest';
import {
  formatVoucherNo,
  NumberingConfigurationError,
  scopeKey,
} from '../src/modules/vouchers/numbering.js';

describe('scopeKey', () => {
  it('is deterministic and distinguishes book/year', () => {
    const base = { tenantId: 't', coCode: '01', lcCode: '01' };
    expect(scopeKey({ ...base, coYear: '2024', coBook: 'SAL' })).toBe('t|01|01|2024|SAL');
    expect(scopeKey({ ...base, coYear: '2024', coBook: 'SAL' })).toBe(
      scopeKey({ ...base, coYear: '2024', coBook: 'SAL' }),
    );
    expect(scopeKey({ ...base, coBook: 'SAL' })).not.toBe(scopeKey({ ...base, coBook: 'PUR' }));
  });
});

describe('formatVoucherNo', () => {
  it('matches the desktop 00000 format', () => {
    expect(formatVoucherNo(1)).toBe('00001');
    expect(formatVoucherNo('52')).toBe('00052');
    expect(formatVoucherNo(99999)).toBe('99999');
  });

  it('rejects non-numeric, zero, and exhausted values', () => {
    for (const value of ['A1', 0, 100000]) {
      expect(() => formatVoucherNo(value)).toThrow(NumberingConfigurationError);
    }
  });
});
