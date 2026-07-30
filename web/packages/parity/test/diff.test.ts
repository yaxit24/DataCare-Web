import { describe, it, expect } from 'vitest';
import { diffRows, normalize, pkKey } from '../src/index.js';

const PK = ['CO_CODE', 'VCH_NO'];

describe('parity diffRows', () => {
  it('reports ok when rows match', () => {
    const a = [{ CO_CODE: '01', VCH_NO: '1', NET_AMT: 100.0 }];
    const b = [{ CO_CODE: '01', VCH_NO: '1', NET_AMT: 100.0 }];
    expect(diffRows(a, b, PK).ok).toBe(true);
  });

  it('treats FLOAT vs NUMERIC equal within precision', () => {
    const exp = [{ CO_CODE: '01', VCH_NO: '1', NET_AMT: 100.004 }]; // desktop float
    const act = [{ CO_CODE: '01', VCH_NO: '1', NET_AMT: '100.00' }]; // web numeric string
    const r = diffRows(exp, act, PK, { numericFields: { NET_AMT: 2 } });
    expect(r.ok).toBe(true);
  });

  it('flags value mismatch beyond precision', () => {
    const exp = [{ CO_CODE: '01', VCH_NO: '1', NET_AMT: 100.5 }];
    const act = [{ CO_CODE: '01', VCH_NO: '1', NET_AMT: 100.4 }];
    const r = diffRows(exp, act, PK, { numericFields: { NET_AMT: 2 } });
    expect(r.ok).toBe(false);
    expect(r.valueMismatches[0].field).toBe('NET_AMT');
  });

  it('detects missing and extra rows', () => {
    const exp = [
      { CO_CODE: '01', VCH_NO: '1' },
      { CO_CODE: '01', VCH_NO: '2' },
    ];
    const act = [
      { CO_CODE: '01', VCH_NO: '1' },
      { CO_CODE: '01', VCH_NO: '3' },
    ];
    const r = diffRows(exp, act, PK);
    expect(r.missing).toEqual(['01|2']);
    expect(r.extra).toEqual(['01|3']);
    expect(r.ok).toBe(false);
  });

  it('ignores configured fields (e.g. surrogate row_id)', () => {
    const exp = [{ CO_CODE: '01', VCH_NO: '1', row_id: 5 }];
    const act = [{ CO_CODE: '01', VCH_NO: '1', row_id: 99 }];
    expect(diffRows(exp, act, PK, { ignore: ['row_id'] }).ok).toBe(true);
  });

  it('normalize rounds numbers and formats dates', () => {
    expect(normalize('100.004', 2)).toBe(100);
    expect(normalize(2.346, 2)).toBe(2.35);
    expect(normalize(new Date('2024-04-01T10:00:00Z'))).toBe('2024-04-01');
    expect(pkKey({ CO_CODE: '01', VCH_NO: '7' }, PK)).toBe('01|7');
  });
});
