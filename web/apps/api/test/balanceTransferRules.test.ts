/**
 * Balance TrFr pure rules (BtmSchm.cs), the unit layer of orchestration/work/WP-23/cases.md. Expected values are worked
 * by hand from the desktop formulas; the half-cases are below the 2- and 3-place database columns, so this layer
 * carries them alone.
 */
import { describe, expect, it } from 'vitest';
import {
  acOpeningHeads,
  dayBefore,
  itemOpeningFigures,
  nextYearOf,
} from '../src/modules/ops/balanceTransferRules.js';

const heads = (money: string, gold = '0', silver = '0') => acOpeningHeads({ money, gold, silver });
const item = (o: Partial<Parameters<typeof itemOpeningFigures>[0]>) =>
  itemOpeningFigures({
    itCode: 'I1',
    itType: 'G',
    pcs: '0',
    gross: '0',
    net: '0',
    amount: '0',
    touch: '0',
    ...o,
  });

describe('Ac Balance row rule (Rtl_AcOpbl, BtmSchm.cs:2786-2801)', () => {
  it('balance-transfer.ac.round.money-half-up-positive: 10.005 → 10.01 Cr; 4.015 → 4.02, where binary float gives 4.01', () => {
    expect(heads('10.005')).toMatchObject({ amount: 10.01, sign: 'C' });
    expect(heads('4.015')).toMatchObject({ amount: 4.02, sign: 'C' });
    // The web rounding this replaces (yearEnd.ts:47) on the same sum:
    expect(Math.round((4.015 + Number.EPSILON) * 100) / 100).toBe(4.01);
  });

  it('balance-transfer.ac.round.money-half-up-negative: −20.005 → 20.01 Dr (away from zero)', () => {
    expect(heads('-20.005')).toMatchObject({ amount: 20.01, sign: 'D' });
  });

  it('balance-transfer.ac.round.gold-three-decimals: gold 1.2345 → 1.235 Cr, silver −2.0005 → 2.001 Dr', () => {
    expect(heads('0', '1.2345', '-2.0005')).toEqual({
      amount: 0,
      sign: 'D',
      gold: 1.235,
      goldSign: 'C',
      silver: 2.001,
      silverSign: 'D',
    });
  });

  it('balance-transfer.ac.round.group-then-round: three 0.004 vouchers sum to 0.012 → 0.01, not 0.00', () => {
    // The grouped sum is rounded once (format(Sum(...),'0.00')); rounding each voucher first would give 0.00.
    expect(heads('0.012')).toMatchObject({ amount: 0.01, sign: 'C' });
    expect(heads('0.004')).toBeNull();
  });

  it('balance-transfer.ac.rule.zero-value-sign-d: a zero head is written D', () => {
    expect(heads('0.00', '8.250')).toEqual({
      amount: 0,
      sign: 'D',
      gold: 8.25,
      goldSign: 'C',
      silver: 0,
      silverSign: 'D',
    });
  });

  it('balance-transfer.ac.rule.skip-true-zero: 0.1 + 0.1 + 0.1 − 0.3 is exactly zero in decimals', () => {
    expect(0.1 + 0.1 + 0.1 - 0.3).not.toBe(0);
    expect(heads('0.00')).toBeNull();
    expect(heads('-0.00', '0.000', '-0.000')).toBeNull();
  });

  it('balance-transfer.ac.rule.skip-no-tolerance: 0.004 rounds to 0 and is skipped; 0.005 rounds to 0.01 and is carried', () => {
    expect(heads('0.004')).toBeNull();
    expect(heads('0.005')).toMatchObject({ amount: 0.01, sign: 'C' });
    expect(heads('0', '0.0004')).toBeNull();
  });

  it('balance-transfer.ac.rule.skip-diamond-only: a group with no money, gold or silver has no row', () => {
    expect(heads('0', '0', '0')).toBeNull();
  });

  it('balance-transfer.ac.rule.having-offset-money-vs-gold (blocked, Q2): the web carries both balances until the owner decides', () => {
    // The desktop HAVING (BtmSchm.cs:2786) drops 50.00 Cr + 50.000 gold Dr. Recorded so a change is deliberate.
    expect(heads('50.00', '-50.000')).toMatchObject({
      amount: 50,
      sign: 'C',
      gold: 50,
      goldSign: 'D',
    });
  });

  it('NULL and blank sums are 0 (DC_Main.Fnv)', () => {
    expect(acOpeningHeads({ money: null, gold: '', silver: undefined })).toBeNull();
  });
});

describe('Item Stock row rule (BtnItmStk, BtmSchm.cs:2945-2994)', () => {
  it('balance-transfer.item.rule.closing-worked and fine-from-touch: 6 pcs, 60.300 / 58.950, fine 53.998, amount 300.00', () => {
    expect(
      item({ pcs: '6', gross: '60.300', net: '58.950', amount: '300.00', touch: '91.600' }),
    ).toEqual({ pcs: 6, gross: 60.3, net: 58.95, touch: 91.6, fine: 53.998, amount: 300 });
  });

  it('balance-transfer.item.rule.fine-half-up: 12.345 × 50 / 100 = 6.1725 → 6.173; 0.001 × 50 / 100 → 0.001', () => {
    expect(item({ net: '12.345', touch: '50' })?.fine).toBe(6.173);
    expect(item({ net: '0.001', touch: '50.000' })?.fine).toBe(0.001);
  });

  it('fine is 0 when the touch or the net weight is 0 (:2950-2961)', () => {
    expect(item({ pcs: '15', gross: '150', net: '142.5', touch: '0' })?.fine).toBe(0);
    expect(item({ pcs: '2', gross: '1', net: '0', touch: '91.6' })?.fine).toBe(0);
  });

  it('balance-transfer.item.rule.skip-sold-out: nothing left, no row', () => {
    expect(item({ pcs: '0', gross: '0.000', net: '0.000' })).toBeNull();
  });

  it('balance-transfer.item.rule.skip-signed-sum-offset (blocked, Q3): the web keeps the position until the owner decides', () => {
    expect(item({ pcs: '5', gross: '-2.5', net: '-2.5' })).toMatchObject({
      pcs: 5,
      gross: -2.5,
      net: -2.5,
    });
  });

  it('pieces go in as Format "0" (half away from zero)', () => {
    expect(item({ pcs: '2.5', gross: '1' })?.pcs).toBe(3);
  });
});

describe('Transfer Year (BtmSchm.cs:2085-2105)', () => {
  const years = [
    { coYear: '2027-2028', opDate: '2027-04-01', clDate: '2028-03-31' },
    { coYear: '2025-2026', opDate: '2025-04-01', clDate: '2026-03-31' },
    { coYear: '2026-2027', opDate: '2026-04-01', clDate: '2027-03-31' },
  ];
  it('balance-transfer.entry.default-target-year: the first later year, not year + 1 guessed', () => {
    expect(nextYearOf(years, '2025-2026')?.coYear).toBe('2026-2027');
    expect(nextYearOf(years, '2026-2027')?.coYear).toBe('2027-2028');
  });
  it('balance-transfer.invalid.no-next-year-message: none after the last year', () => {
    expect(nextYearOf(years, '2027-2028')).toBeNull();
  });
  it('balance-transfer.tag.create.date-is-day-before-opening: OP_DATE − 1 day', () => {
    expect(dayBefore('2026-04-01')).toBe('2026-03-31');
    expect(dayBefore('2024-03-01')).toBe('2024-02-29');
  });
});
