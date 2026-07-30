import { describe, it, expect } from 'vitest';
import { buildPurchaseReturnLedger } from '../src/modules/purchase/purchaseReturn.js';
import { assertBalanced } from '../src/modules/posting/posting.js';

describe('purchase return ledger', () => {
  const key = { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024', CO_BOOK: 'PRT', VCH_NO: '1' };
  const totals = { total: 41200, taxable: 40000, tax: 1200, roundOff: 0 };

  it('is balanced and is the reverse of a purchase', () => {
    const lines = buildPurchaseReturnLedger({
      key,
      acCode: 'SUPP1',
      purchaseAc: 'PURCHASE',
      taxAc: 'GSTINPUT',
      roundAc: 'ROUNDOFF',
      totals,
    });
    expect(() => assertBalanced(lines)).not.toThrow();
    const by = (ac: string) => lines.find((l) => l.AC_CODE === ac);
    expect(by('SUPP1')?.DR_AMT).toBe(41200); // supplier debited (purchase credited it → return reverses)
    expect(by('PURCHASE')?.CR_AMT).toBe(40000); // purchase expense reversed
    expect(by('GSTINPUT')?.CR_AMT).toBe(1200); // input GST reversed
    const dr = lines.reduce((s, l) => s + (Number(l.DR_AMT) || 0), 0);
    const cr = lines.reduce((s, l) => s + (Number(l.CR_AMT) || 0), 0);
    expect(dr).toBeCloseTo(cr, 2);
  });
});
