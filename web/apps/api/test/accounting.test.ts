import { describe, it, expect } from 'vitest';
import {
  summarizeTrialBalance,
  applyRunningBalance,
} from '../src/modules/accounting/accounting.js';

describe('accounting read-model', () => {
  it('trial balance nets Dr=Cr and computes per-account balance', () => {
    const tb = summarizeTrialBalance([
      { AC_CODE: 'CUST', dr: 1030, cr: 0 },
      { AC_CODE: 'SALES', dr: 0, cr: 1000 },
      { AC_CODE: 'GST', dr: 0, cr: 30 },
    ]);
    expect(tb.grandDr).toBe(1030);
    expect(tb.grandCr).toBe(1030);
    expect(tb.balanced).toBe(true);
    expect(tb.accounts.find((a) => a.acCode === 'CUST')!.balance).toBe(1030);
  });
  it('detects an unbalanced set', () => {
    expect(summarizeTrialBalance([{ AC_CODE: 'X', dr: 100, cr: 0 }]).balanced).toBe(false);
  });
  it('running balance accumulates from opening', () => {
    const r = applyRunningBalance(500, [
      { VCH_NO: '1', VCH_TYPE: 'RCT', VCH_DATE: null, dr: 1000, cr: 0 },
      { VCH_NO: '2', VCH_TYPE: 'PAY', VCH_DATE: null, dr: 0, cr: 300 },
    ]);
    expect(r.opening).toBe(500);
    expect(r.rows[0]!.runningBalance).toBe(1500);
    expect(r.rows[1]!.runningBalance).toBe(1200);
    expect(r.closing).toBe(1200);
  });
});
