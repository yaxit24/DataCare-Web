/**
 * CLR_DATE is set only on the books the desktop actually sets it on.
 *
 * FOUND BY THE 66-VOUCHER COMPARISON
 * ==================================
 * `enrichLedgerLine` stamped `CLR_DATE` from the row date on every ledger leg of every family. Measured over
 * all 5150 real AC_DATA rows in Live24 the desktop populates it on exactly 345, and the partition is clean:
 *
 *     BANK PAY   130 of 130   (100%)
 *     BANK REC    98 of  98   (100%)
 *     OPSTK      117 of 117   (100%)
 *     20 other families              0     (PURCHASE 0/143, SALES 0/1020, CASH PAY 0/360, CONTRA 0/74, …)
 *
 * 130 + 98 + 117 = 345 exactly, so nothing else contributes a row. Stamping it everywhere disagreed with the
 * desktop on 4805 of 5150 ledger rows (93%) and was the largest single source of real value mismatches in the
 * 66-voucher diff — 119 occurrences of `AC_DATA.CLR_DATE`.
 *
 * A clearance date belongs to a bank instrument. These tests pin the rule to the measurement so the
 * convenience of "just use the row date" cannot quietly come back.
 */
import { describe, expect, it } from 'vitest';
import { enrichLedgerLine } from '../src/modules/posting/posting.js';

const DATE = new Date('2024-04-10T00:00:00.000Z');

/** Minimal ledger line; only the fields enrichLedgerLine reads for this rule matter. */
const line = () => ({
  CO_CODE: '01',
  LC_CODE: '00',
  CO_YEAR: '2024-2025',
  CO_BOOK: '035',
  VCH_NO: '00001',
  AC_CODE: '000903',
  DR_AMT: 0,
  CR_AMT: 6780,
  VCH_DATE: DATE,
});

const clrDateFor = (bookName: string) =>
  (enrichLedgerLine(line() as never, 1, '', false, bookName, DATE) as Record<string, unknown>)
    .CLR_DATE;

describe('CLR_DATE follows the desktop book partition', () => {
  it.each(['BANK PAY', 'BANK REC', 'OPSTK'])('%s carries a clearance date', (book) => {
    expect(clrDateFor(book)).toEqual(DATE);
  });

  it.each([
    'PURCHASE',
    'SALES',
    'CASH PAY',
    'CASH REC',
    'CONTRA',
    'RATE CUT',
    'WH SALES',
    'MEMB ENTRY',
    'MEMB ADJUST',
    'FINE JV',
    'KARIGAR RECEIPT',
    'KARIGAR ISSUE',
    'LABOUR WORK',
    'SALES ORDER',
    'ORDER CANCEL',
    'SALES RETURNE',
    'OTH INC',
    'OTH EXP',
    'BILL REC',
  ])('%s leaves CLR_DATE null', (book) => {
    expect(clrDateFor(book)).toBeNull();
  });

  it('leaves CLR_DATE null when the book is unknown, rather than guessing', () => {
    expect(clrDateFor('')).toBeNull();
    expect(
      (enrichLedgerLine(line() as never, 1, '', false, undefined, DATE) as Record<string, unknown>)
        .CLR_DATE,
    ).toBeNull();
  });

  it('matches the book name case-insensitively and ignores surrounding space', () => {
    expect(clrDateFor('bank pay')).toEqual(DATE);
    expect(clrDateFor('  BANK REC  ')).toEqual(DATE);
  });

  it('still prefers a clearance date the caller supplied, on any book', () => {
    const supplied = new Date('2024-05-01T00:00:00.000Z');
    const enriched = enrichLedgerLine(
      { ...line(), CLR_DATE: supplied } as never,
      1,
      '',
      false,
      'PURCHASE',
      DATE,
    ) as Record<string, unknown>;
    expect(enriched.CLR_DATE).toEqual(supplied);
  });

  it('does not disturb ENTRY_TIME, which the desktop sets on every family', () => {
    for (const book of ['PURCHASE', 'BANK PAY', 'SALES']) {
      const enriched = enrichLedgerLine(line() as never, 1, '', false, book, DATE) as Record<
        string,
        unknown
      >;
      expect(enriched.ENTRY_TIME, `${book} must still carry ENTRY_TIME`).toEqual(DATE);
    }
  });
});
