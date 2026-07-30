import { describe, it, expect } from 'vitest';
import {
  fineWeight,
  fineWithWastage,
  karigarBalance,
  INOUT_ISSUE,
  INOUT_RECEIPT,
} from '../src/modules/manufacturing/karigar.js';

describe('karigar metal math', () => {
  it('INOUT_TYPE matches desktop alphabet (I/O)', () => {
    expect(INOUT_ISSUE).toBe('O');
    expect(INOUT_RECEIPT).toBe('I');
  });
  it('fine weight = nwt × touch / 100', () => {
    expect(fineWeight(100, 92)).toBe(92);
    expect(fineWeight(50, 91.6)).toBe(45.8);
  });
  it('fine with wastage = nwt × (touch + west)/100 (MS_UPDATE parity)', () => {
    expect(fineWithWastage(100, 90, 2)).toBe(92); // 2% wastage folded in
    expect(fineWithWastage(100, 90, 0)).toBe(90);
  });
  it('balance = issued − received (zero when wastage accounts for the gap)', () => {
    // issue 100g@92% = 92 fine; receive 100g@90% with 2% wastage = 92 fine -> balance 0
    expect(karigarBalance(fineWeight(100, 92), fineWithWastage(100, 90, 2))).toBe(0);
    // receive less -> karigar still owes
    expect(karigarBalance(92, 90)).toBe(2);
  });
});
