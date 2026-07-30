import { describe, it, expect } from 'vitest';
import { buildReturnLedger } from '../src/modules/sales/salesReturn.js';
import { assertBalanced } from '../src/modules/posting/posting.js';

describe('sales return ledger', () => {
  const key = { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024', CO_BOOK: 'SRT', VCH_NO: '1' };
  const totals = { total: 25750, taxable: 25000, tax: 750, roundOff: 0 };

  it('is balanced and is the reverse of a sale', () => {
    const lines = buildReturnLedger({
      key,
      acCode: 'CUST1',
      salesAc: 'SALES',
      taxAc: 'GST',
      roundAc: 'ROUNDOFF',
      totals,
    });
    expect(() => assertBalanced(lines)).not.toThrow();
    const by = (ac: string) => lines.find((l) => l.AC_CODE === ac);
    expect(by('SALES')?.DR_AMT).toBe(25000); // sale credited income → return debits it
    expect(by('GST')?.DR_AMT).toBe(750); // sale credited GST output → return debits it
    expect(by('CUST1')?.CR_AMT).toBe(25750); // sale debited customer → return credits it
    const dr = lines.reduce((s, l) => s + (Number(l.DR_AMT) || 0), 0);
    const cr = lines.reduce((s, l) => s + (Number(l.CR_AMT) || 0), 0);
    expect(dr).toBeCloseTo(cr, 2);
  });

  it('omits zero tax/round lines', () => {
    const lines = buildReturnLedger({
      key,
      acCode: 'CUST1',
      salesAc: 'SALES',
      taxAc: 'GST',
      roundAc: 'ROUNDOFF',
      totals: { total: 1000, taxable: 1000, tax: 0, roundOff: 0 },
    });
    expect(lines.find((l) => l.AC_CODE === 'GST')).toBeUndefined();
    expect(lines.length).toBe(2);
  });
});
