import { describe, it, expect } from 'vitest';
import {
  buildTransferLedger,
  assertCashLimit,
  assertCashReceiptCeiling,
  settlementAc,
  FinanceValidationError,
} from '../src/modules/finance/finance.js';
import { ledgerBalance } from '../src/modules/posting/posting.js';

const key = { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024', CO_BOOK: 'RCT', VCH_NO: '1' };

describe('finance builders', () => {
  it('transfer ledger balances (Dr = Cr)', () => {
    const lines = buildTransferLedger(key, 'RCT', 'CASH', 'CUST', 5000);
    const b = ledgerBalance(lines);
    expect(b.balanced).toBe(true);
    expect(b.dr).toBe(5000);
    expect(lines[0].AC_CODE).toBe('CASH'); // debit cash
    expect(lines[1].AC_CODE).toBe('CUST'); // credit party
  });
  it('settlementAc routes cash→CASH, others→bank/clearing', () => {
    expect(settlementAc('cash')).toBe('CASH');
    expect(settlementAc('card')).toBe('BANK');
    expect(settlementAc('upi', 'HDFC')).toBe('HDFC');
  });
  it('cash over limit without PAN is rejected; with PAN or non-cash is allowed', () => {
    expect(() => assertCashLimit('cash', 250000, undefined, 200000)).toThrow(
      FinanceValidationError,
    );
    expect(() => assertCashLimit('cash', 250000, 'ABCDE1234F', 200000)).not.toThrow();
    expect(() => assertCashLimit('cash', 100000, undefined, 200000)).not.toThrow();
    expect(() => assertCashLimit('cheque', 250000, undefined, 200000)).not.toThrow();
  });
  it('cash-receipt ceiling blocks with NO PAN escape, incl. cumulative party cash (R7 / TR_CASH)', () => {
    expect(() => assertCashReceiptCeiling(250000, 0, 200000)).toThrow(FinanceValidationError); // single over limit
    expect(() => assertCashReceiptCeiling(150000, 100000, 200000)).toThrow(FinanceValidationError); // cumulative 250k over
    expect(() => assertCashReceiptCeiling(100000, 0, 200000)).not.toThrow(); // under limit
    expect(() => assertCashReceiptCeiling(200000, 0, 200000)).not.toThrow(); // exactly at limit is allowed
  });
});
