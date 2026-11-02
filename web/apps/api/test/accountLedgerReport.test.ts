import { describe, it, expect } from 'vitest';
import {
  sideOf,
  splitSigned,
  summaryIsZero,
  runningBalances,
  ageDebitsFifo,
  parseAccountLedgerQuery,
  AccountLedgerValidationError,
} from '../src/modules/reports/accountLedgerReport.js';

/**
 * Pure-helper vectors for the desktop RP_LEDR Ledger Report. Every expected value is derived by hand from
 * the desktop arithmetic (RP_LEDR.cs), never from the web's own output:
 *   - signed money = Σ(CR_AMT - DR_AMT); gold/silver = Σ signed FINE_WT (SIGN '+' adds) (:6408/6417/6426)
 *   - a negative net shows as an absolute Dr, a positive net as an absolute Cr
 *   - running balance = Σ(Cr) - Σ(Dr) with side Cr(>0)/Dr(<0)/blank(0) (:6989-7160)
 *   - debit ageing consumes the oldest debit first with the account's total credit (:9877-10282)
 */
describe('account ledger — Cr/Dr side and sign split (RP_LEDR.cs:6408/6417/6426)', () => {
  it('sideOf is Cr when positive, Dr when negative, blank at zero', () => {
    expect(sideOf(1)).toBe('Cr');
    expect(sideOf(-1)).toBe('Dr');
    expect(sideOf(0)).toBe('');
  });

  it('splitSigned sends a negative net to Dr (abs) and a positive net to Cr (abs)', () => {
    expect(splitSigned(-40, 2)).toEqual({ dr: 40, cr: 0 });
    expect(splitSigned(1.75, 3)).toEqual({ dr: 0, cr: 1.75 });
    expect(splitSigned(-6.25, 3)).toEqual({ dr: 6.25, cr: 0 });
    expect(splitSigned(0, 2)).toEqual({ dr: 0, cr: 0 });
  });

  // Scenario A: CR_AMT 100 then DR_AMT 140 -> money -40 -> Dr 40. Gold +2.5 then -0.75 -> +1.75 -> Cr.
  // Silver -6.25 -> Dr 6.25.
  it('Scenario A: account summary splits signed money/gold/silver into Dr/Cr', () => {
    const money = 100 - 140;
    const gold = 2.5 - 0.75;
    const silver = -6.25;
    expect(splitSigned(money, 2)).toEqual({ dr: 40, cr: 0 });
    expect(splitSigned(gold, 3)).toEqual({ dr: 0, cr: 1.75 });
    expect(splitSigned(silver, 3)).toEqual({ dr: 6.25, cr: 0 });
  });
});

describe('account ledger — zero-balance inclusion (RP_LEDR.cs:6421)', () => {
  it('Scenario B: an account whose six components are all zero is a "zero" row', () => {
    expect(summaryIsZero(0, 0, 0)).toBe(true);
    // a residual in any component keeps the row
    expect(summaryIsZero(0.01, 0, 0)).toBe(false);
    expect(summaryIsZero(0, 0.001, 0)).toBe(false);
    expect(summaryIsZero(0, 0, -0.004)).toBe(false);
  });
});

describe('account ledger — detail running balances (RP_LEDR.cs:6989-7160)', () => {
  // Scenario C: opening Cr 100 / Gold Cr 2.000 / Silver Dr 5.000.
  // G1 nets to Dr 40 / Gold Dr 0.400; G2 is Cr 10 / Gold Cr 0.200.
  it('Scenario C: cumulative Σ(Cr)-Σ(Dr) with correct sides', () => {
    const opening = { amount: 100, goldFine: 2.0, silverFine: -5.0 };
    const rows = [
      { crAmt: 0, drAmt: 40, crGold: 0, drGold: 0.4, crSilver: 0, drSilver: 0 },
      { crAmt: 10, drAmt: 0, crGold: 0.2, drGold: 0, crSilver: 0, drSilver: 0 },
    ];
    const out = runningBalances(opening, rows);
    expect(out[0]!.balAmt).toBe(60);
    expect(out[0]!.amtSide).toBe('Cr');
    expect(out[0]!.balGold).toBe(1.6);
    expect(out[0]!.goldSide).toBe('Cr');
    expect(out[0]!.balSilver).toBe(-5);
    expect(out[0]!.silverSide).toBe('Dr');
    expect(out[1]!.balAmt).toBe(70);
    expect(out[1]!.balGold).toBe(1.8);
    expect(out[1]!.balSilver).toBe(-5);
  });

  it('opening-only ledger (no rows) leaves the opening balance as the closing', () => {
    const out = runningBalances({ amount: 100, goldFine: 0, silverFine: 0 }, []);
    expect(out).toEqual([]);
  });
});

describe('account ledger — debit ageing FIFO (RP_LEDR.cs:9877-10282)', () => {
  // Scenario F: debits 200 (age 170 -> 151+), 100 (age 100 -> 120 bucket), 50 (age 20 -> 30 bucket);
  // total credit 220. Oldest first: 200 consumes all of the 151+ debit and leaves 20 credit; that 20
  // reduces the 120-bucket debit from 100 to 80; the 30-bucket debit 50 stays.
  it('Scenario F: oldest debit is consumed first', () => {
    const buckets = { 151: 200, 150: 0, 120: 100, 90: 0, 60: 0, 45: 0, 30: 50, 15: 0 };
    const out = ageDebitsFifo(buckets, 220, 2);
    expect(out[151]).toBe(0);
    expect(out[120]).toBe(80);
    expect(out[30]).toBe(50);
    expect(out[90]).toBe(0);
  });

  it('credit larger than every debit clears all buckets', () => {
    const buckets = { 151: 10, 150: 0, 120: 20, 90: 0, 60: 0, 45: 0, 30: 5, 15: 0 };
    const out = ageDebitsFifo(buckets, 1000, 2);
    for (const b of [151, 120, 30]) expect(out[b]).toBe(0);
  });

  it('no credit leaves every bucket intact', () => {
    const buckets = { 151: 10, 150: 0, 120: 20, 90: 0, 60: 0, 45: 0, 30: 5, 15: 0 };
    const out = ageDebitsFifo(buckets, 0, 2);
    expect(out[151]).toBe(10);
    expect(out[120]).toBe(20);
    expect(out[30]).toBe(5);
  });
});

describe('account ledger — query parsing (fail closed)', () => {
  it('defaults to the summary view', () => {
    expect(parseAccountLedgerQuery({}).view).toBe('summary');
  });

  it('detail and voucher-summary require an account', () => {
    expect(() => parseAccountLedgerQuery({ view: 'detail' })).toThrow(AccountLedgerValidationError);
    expect(() => parseAccountLedgerQuery({ view: 'voucher-summary' })).toThrow(
      AccountLedgerValidationError,
    );
    expect(parseAccountLedgerQuery({ view: 'detail', acCode: 'A100' }).acCode).toBe('A100');
  });

  it('rejects an unknown view, a bad date, an inverted range, and a bad dataType/fineType', () => {
    expect(() => parseAccountLedgerQuery({ view: 'nope' })).toThrow(AccountLedgerValidationError);
    expect(() => parseAccountLedgerQuery({ fromDate: '2024-13-01' })).toThrow(
      AccountLedgerValidationError,
    );
    expect(() => parseAccountLedgerQuery({ fromDate: '2024-05-01', toDate: '2024-04-01' })).toThrow(
      AccountLedgerValidationError,
    );
    expect(() => parseAccountLedgerQuery({ dataType: 'Z' })).toThrow(AccountLedgerValidationError);
    expect(() => parseAccountLedgerQuery({ view: 'ageing', fineType: 'X' })).toThrow(
      AccountLedgerValidationError,
    );
  });

  it('ageing defaults the fine type to gold; detail leaves it unset', () => {
    expect(parseAccountLedgerQuery({ view: 'ageing', toDate: '2024-06-30' }).fineType).toBe('G');
    expect(parseAccountLedgerQuery({ view: 'summary' }).fineType).toBeUndefined();
  });

  it('accepts boolean-ish flags and uppercases dataType/fineType', () => {
    const q = parseAccountLedgerQuery({
      view: 'summary',
      withZero: 'true',
      openingOnly: '1',
      dataType: 'a',
    });
    expect(q.withZero).toBe(true);
    expect(q.openingOnly).toBe(true);
    expect(q.dataType).toBe('A');
  });
});
