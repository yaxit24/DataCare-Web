import { describe, expect, it } from 'vitest';
import {
  companySaleAmountType,
  effectiveSaleRateWith,
  saleAmountBasis,
  saleItemAmount,
  saleRateWithCode,
} from '../src/index.js';

/**
 * Vectors D6-1..D6-8 from
 * parity-plan-2026-09-10/evidence/implementation-2026-09-29-eval-defects/contract.md.
 *
 * Every expected figure is a literal, worked by hand from TR_SALE.cs CommPassTotal (10716-10936).
 * None is computed by the function under test. Fine values are worked by hand as well:
 *   fine = round3((net + ghat) x (touch + wastage) / 100)
 *   10 x 0.916 = 9.160, and 10.5 x 0.916 = 9.618.
 */
const amount = (
  line: Parameters<typeof saleAmountBasis>[0],
  lineRateWith: string,
  company: string,
  rate: number,
  rateType?: string,
) =>
  saleItemAmount(
    saleAmountBasis(line, effectiveSaleRateWith(lineRateWith, company), rateType),
    rate,
  );

describe('company SL_AMT_TYPE and the line RtWith', () => {
  it('blank company type is N, as MS_OPNCOMP.cs:881-884 sets it', () => {
    expect(companySaleAmountType('')).toBe('N');
    expect(companySaleAmountType(null)).toBe('N');
    expect(companySaleAmountType('  ')).toBe('N');
    expect(companySaleAmountType('g')).toBe('G');
  });

  it('a new line copies the company type; its own value wins once set (TR_SALE.cs:9161)', () => {
    expect(effectiveSaleRateWith('', '')).toBe('N');
    expect(effectiveSaleRateWith(undefined, 'F')).toBe('F');
    expect(effectiveSaleRateWith('G', 'N')).toBe('G');
    expect(effectiveSaleRateWith(' p ', 'N')).toBe('P');
  });

  it('keeps only the first character, because the desktop cell is one character wide', () => {
    expect(saleRateWithCode('Fine')).toBe('F');
    expect(saleRateWithCode('net')).toBe('N');
  });
});

describe('TR_SALE item amount (CommPassTotal)', () => {
  it('D6-1: blank company prices net, not fine (60,000, previously 54,960 on the web)', () => {
    const line = { pcs: 1, grossWt: 10, netWt: 10, ghtWt: 0, fineWt: 9.16 };
    expect(amount(line, '', '', 6000)).toBe(60000);
  });

  it.each([
    ['', 10000],
    ['F', 9160],
    ['G', 12000],
    ['N', 10000],
    ['P', 1000],
  ])('D6-2: company %s prices the line at %d', (company, expected) => {
    const line = { pcs: 1, grossWt: 12, netWt: 10, ghtWt: 0, fineWt: 9.16 };
    expect(amount(line, '', company, 1000)).toBe(expected);
  });

  it.each([
    ['F', 9160],
    ['G', 12000],
    ['P', 2000],
  ])('D6-3: a line RtWith of %s overrides company N', (lineRateWith, expected) => {
    const line = { pcs: 2, grossWt: 12, netWt: 10, ghtWt: 0, fineWt: 9.16 };
    expect(amount(line, lineRateWith, 'N', 1000)).toBe(expected);
  });

  it.each([
    ['N', 10500],
    ['F', 9618],
    ['G', 12500],
  ])('D6-4: ghat joins the net and gross bases but not the fine one (%s)', (company, expected) => {
    const line = { pcs: 1, grossWt: 12, netWt: 10, ghtWt: 0.5, fineWt: 9.618 };
    expect(amount(line, '', company, 1000)).toBe(expected);
  });

  it('D6-5: RATE_TYPE K is a rate per kilogram', () => {
    const line = { pcs: 1, grossWt: 250, netWt: 250, ghtWt: 0, fineWt: 0 };
    expect(amount(line, '', 'N', 70000, 'K')).toBe(17500);
  });

  it('D6-6: RATE_TYPE 1 is a rate per 10 g', () => {
    const line = { pcs: 1, grossWt: 10, netWt: 10, ghtWt: 0, fineWt: 9.16 };
    expect(amount(line, '', 'N', 60000, '1')).toBe(60000);
  });

  it('D6-7: RATE_TYPE 1 adds ghat even to the fine quantity (desktop quirk kept)', () => {
    const line = { pcs: 1, grossWt: 10.5, netWt: 10, ghtWt: 0.5, fineWt: 9.618 };
    // (9.618 + 0.5) x 60000 / 10 = 10.118 x 6000
    expect(amount(line, 'F', 'N', 60000, '1')).toBe(60708);
  });

  it('D6-8: RATE_TYPE P prices pieces whatever the RtWith', () => {
    const line = { pcs: 3, grossWt: 10, netWt: 10, ghtWt: 0, fineWt: 9.16 };
    expect(amount(line, 'F', 'N', 500, 'P')).toBe(1500);
    expect(amount(line, 'G', 'N', 500, 'P')).toBe(1500);
  });

  it('a zero fine (touch + wastage = 0) falls back to net + ghat, as column 20 does', () => {
    const line = { pcs: 1, grossWt: 5, netWt: 4, ghtWt: 0.25, fineWt: 0 };
    expect(amount(line, 'F', 'N', 1000)).toBe(4250);
  });

  it('a G item rate type is the default gram branch', () => {
    const line = { pcs: 1, grossWt: 12, netWt: 10, ghtWt: 0, fineWt: 9.16 };
    expect(amount(line, '', 'N', 1000, 'G')).toBe(10000);
  });

  it('can fail: each basis gives a different amount for the same line', () => {
    const line = { pcs: 2, grossWt: 12, netWt: 10, ghtWt: 0.5, fineWt: 9.618 };
    const results = ['F', 'G', 'N', 'P'].map((code) => amount(line, code, 'N', 1000));
    expect(new Set(results).size).toBe(4);
  });
});
