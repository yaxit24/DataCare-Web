import { describe, it, expect } from 'vitest';
import {
  MEMB_ENTRY,
  MEMB_OPENING,
  MEMB_ADJUST,
  SchemeError,
} from '../src/modules/membership/scheme.js';
import { buildTransferLedger } from '../src/modules/finance/finance.js';
import { ledgerBalance } from '../src/modules/posting/posting.js';

// Desktop parity facts (verified against live BOOK_DATA + 2622 real AC_DATA legs):
//   074 "Member Monthly Entry"  → VCH_TYPE MBENT, BOOK_NAME 'MEMB ENTRY'  (the monthly installment)
//   076 "Member Advance Adjust" → VCH_TYPE MBADJ, BOOK_NAME 'MEMB ADJUST' (maturity/redemption → AD_ADJ)
const key = { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024-2025', CO_BOOK: '074', VCH_NO: '1' };

describe('scheme book identity (desktop parity)', () => {
  it('monthly installment = book 074 / MBENT / MEMB ENTRY (not the old 075/SCH/SCHEME)', () => {
    expect(MEMB_ENTRY).toEqual({ book: '074', vchType: 'MBENT', bookName: 'MEMB ENTRY' });
  });
  it('maturity/redemption = book 076 / MBADJ / MEMB ADJUST', () => {
    expect(MEMB_ADJUST).toEqual({ book: '076', vchType: 'MBADJ', bookName: 'MEMB ADJUST' });
  });
  it('opening entry = book 075 / MBOP / MEMB OPENING', () => {
    expect(MEMB_OPENING).toEqual({ book: '075', vchType: 'MBOP', bookName: 'MEMB OPENING' });
  });
  it('SchemeError maps to HTTP 400 (name ends in ValidationError)', () => {
    expect(new SchemeError('x').name).toMatch(/ValidationError$/);
  });
});

describe('scheme ledger direction', () => {
  it('installment is a receipt: Dr cash / Cr scheme-liability, balanced', () => {
    const lines = buildTransferLedger(key, MEMB_ENTRY.vchType, 'CASH', '000858', 2000);
    const b = ledgerBalance(lines);
    expect(b.balanced).toBe(true);
    expect(b.dr).toBe(2000);
    expect(lines[0].AC_CODE).toBe('CASH'); // Dr cash (money in)
    expect(lines[0].DR_AMT).toBe(2000);
    expect(lines[1].AC_CODE).toBe('000858'); // Cr member/scheme liability
    expect(lines[1].CR_AMT).toBe(2000);
    expect(lines[0].VCH_TYPE).toBe('MBENT');
  });

  it('opening entry posts like an installment: Dr cash / Cr scheme-liability, balanced (MBOP)', () => {
    const lines = buildTransferLedger(key, MEMB_OPENING.vchType, 'CASH', '000858', 5000);
    const b = ledgerBalance(lines);
    expect(b.balanced).toBe(true);
    expect(b.dr).toBe(5000);
    expect(lines[0].AC_CODE).toBe('CASH');
    expect(lines[1].AC_CODE).toBe('000858');
    expect(lines[0].VCH_TYPE).toBe('MBOP');
  });

  it('maturity is the mirror image: Dr scheme-liability / Cr cash, balanced', () => {
    const lines = buildTransferLedger(key, MEMB_ADJUST.vchType, '000858', 'CASH', 2000);
    const b = ledgerBalance(lines);
    expect(b.balanced).toBe(true);
    expect(lines[0].AC_CODE).toBe('000858'); // Dr member/scheme liability (clear it)
    expect(lines[0].DR_AMT).toBe(2000);
    expect(lines[1].AC_CODE).toBe('CASH'); // Cr cash (pay member out)
    expect(lines[1].CR_AMT).toBe(2000);
    expect(lines[0].VCH_TYPE).toBe('MBADJ');
  });

  it('net maturity payout = amount + bonus − less (balanced on the net figure)', () => {
    // mirrors schemeMaturity(): 2000 principal + 150 bonus − 50 less = 2100
    const payout = Math.round((2000 + 150 - 50 + Number.EPSILON) * 100) / 100;
    const lines = buildTransferLedger(key, MEMB_ADJUST.vchType, '000858', 'CASH', payout);
    expect(ledgerBalance(lines).dr).toBe(2100);
  });
});
