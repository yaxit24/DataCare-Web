import { describe, it, expect } from 'vitest';
import {
  accruedInterest,
  monthlyInterest,
  monthlyTermInterest,
  monthsBetween,
  termInterestBetween,
  buildDhrnIssueLedger,
  buildDhrnReceiptLedger,
} from '../src/modules/dhrn/dhrn.js';
import { ledgerBalance } from '../src/modules/posting/posting.js';

const key = { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024', CO_BOOK: 'DIS', VCH_NO: '1' };

describe('dhrn interest + ledgers', () => {
  it('accrued interest = principal × rate% × days/yearDays (RP_DHRN_OS parity)', () => {
    expect(accruedInterest(10000, 12, 90, 360)).toBe(300); // quarter-year at 12% = 300
    expect(accruedInterest(10000, 12, 360, 360)).toBe(1200);
    expect(monthlyInterest(10000, 12, 360)).toBe(100); // 30-day month
  });
  it('issue ledger balances (Dr loan / Cr cash)', () => {
    const lines = buildDhrnIssueLedger(key, 'DHRN', 'CASH', 10000);
    const b = ledgerBalance(lines);
    expect(b.balanced).toBe(true);
    expect(b.dr).toBe(10000);
  });
  it('receipt ledger balances (Dr cash = Cr principal + Cr interest)', () => {
    const lines = buildDhrnReceiptLedger(key, 'DHRN', 'CASH', 'INTINC', 4000, 300);
    const b = ledgerBalance(lines);
    expect(b.balanced).toBe(true);
    expect(b.dr).toBe(4300);
    expect(lines.length).toBe(3);
  });
  it('receipt with zero interest omits the interest line', () => {
    const lines = buildDhrnReceiptLedger(key, 'DHRN', 'CASH', 'INTINC', 6000, 0);
    expect(lines.length).toBe(2);
    expect(ledgerBalance(lines).balanced).toBe(true);
  });
});

describe('dhrn whole-month bucketing (pledge term interest)', () => {
  it('rounds any partial month UP, 1-month minimum', () => {
    expect(monthsBetween('2024-01-15', '2024-01-15')).toBe(1); // same day → min 1
    expect(monthsBetween('2024-01-15', '2024-02-14')).toBe(1); // <1 month
    expect(monthsBetween('2024-01-15', '2024-02-16')).toBe(2); // part of 2nd month → 2
    expect(monthsBetween('2024-01-15', '2024-04-15')).toBe(3); // exact 3 months
  });
  it('termInterestBetween = monthlyTermInterest over bucketed months', () => {
    // 2% monthly on 10000 over 15-Jan→16-Mar (2 part-months → 3) = 10000×2%×3 = 600
    expect(termInterestBetween(10000, 2, '2024-01-15', '2024-03-16')).toBe(
      monthlyTermInterest(10000, 2, 3),
    );
    expect(termInterestBetween(10000, 2, '2024-01-15', '2024-03-16')).toBe(600);
  });
});
