import { describe, expect, it } from 'vitest';
import {
  purchaseAmountBasis,
  purchaseItemAmount,
  purchaseLabourAmount,
  purchaseLineAmounts,
  resolveRoundingPolicy,
} from '../src/index.js';

const primary = {
  pieces: 1,
  grossWt: 10,
  netWt: 10,
  ghatWt: 0,
  fineWt: 9.16,
  rate: 6123.45,
  labourType: 'per_gram' as const,
  labourRate: 237.5,
};

const policy = resolveRoundingPolicy({
  PR_RATE_ROF: '2',
  LBR_ROF: '2',
  TAX_ROF: '2',
  TOT_AMT_ROF: '0',
});

describe('TR_PURC ordinary Purchase amount stages (G198/N188)', () => {
  it('pins the desktop-derived fine-basis vector', () => {
    expect(purchaseLineAmounts(primary, 'F', policy)).toEqual({
      item: 56091,
      labour: 2375,
      net: 58466,
    });
  });

  it('rounds exact item and labour midpoints to the even whole rupee', () => {
    expect(purchaseItemAmount({ quantity: 1, rateDivisor: 1 }, 2.5)).toBe(2);
    expect(purchaseItemAmount({ quantity: 1, rateDivisor: 1 }, 3.5)).toBe(4);
    expect(purchaseItemAmount({ quantity: 1, rateDivisor: 1 }, 1.499)).toBe(1);
    expect(purchaseLabourAmount('fixed', { labourFixed: 2374.5 }, 0)).toBe(2374);
    expect(purchaseLabourAmount('fixed', { labourFixed: 2375.5 }, 0)).toBe(2376);
  });

  it.each([
    ['P', { quantity: 3, rateDivisor: 1 }, 300],
    ['1', { quantity: 9, rateDivisor: 10 }, 90],
    ['K', { quantity: 9, rateDivisor: 1000 }, 1],
    ['G', { quantity: 9, rateDivisor: 1 }, 900],
    ['', { quantity: 9, rateDivisor: 1 }, 900],
  ] as const)('models RATE_TYPE %s explicitly', (rateType, expectedBasis, expectedAmount) => {
    const basis = purchaseAmountBasis(
      { pieces: 3, grossWt: 12, netWt: 10, ghatWt: 1, fineWt: 9, rateType },
      'F',
    );
    expect(basis).toEqual(expectedBasis);
    expect(purchaseItemAmount(basis, 100)).toBe(expectedAmount);
  });

  it.each([
    ['F', 9],
    ['G', 12],
    ['N', 11],
    ['P', 9],
    ['', 9],
  ] as const)('honours PR_AMT_TYPE=%s', (amountType, quantity) => {
    expect(
      purchaseAmountBasis({ pieces: 3, grossWt: 12, netWt: 10, ghatWt: 1, fineWt: 9 }, amountType),
    ).toEqual({ quantity, rateDivisor: 1 });
  });

  it('lets URD_RATE_TYPE=N override the company weight basis', () => {
    expect(
      purchaseAmountBasis(
        {
          grossWt: 12,
          netWt: 10,
          ghatWt: 1,
          fineWt: 9,
          rateType: 'K',
          urdRateType: 'N',
        },
        'G',
      ),
    ).toEqual({ quantity: 11, rateDivisor: 1000 });
  });

  it('rounds all derived web labour modes to whole rupees', () => {
    expect(purchaseLabourAmount('per_gram', { netWt: 10, labourRate: 237.55 }, 0)).toBe(2376);
    expect(purchaseLabourAmount('per_piece', { pieces: 3, labourRate: 10.5 }, 0)).toBe(32);
    expect(purchaseLabourAmount('percentage', { labourPct: 2.5 }, 1010)).toBe(25);
    expect(purchaseLabourAmount('fixed', { labourFixed: 20.5 }, 0)).toBe(20);
  });

  it('preserves a fractional other charge in the two-decimal detail net', () => {
    expect(purchaseLineAmounts({ ...primary, otherAmount: 0.4 }, 'F', policy)).toEqual({
      item: 56091,
      labour: 2375,
      net: 58466.4,
    });
  });

  it('does not alter explicit operator-supplied item or labour amounts', () => {
    expect(
      purchaseLineAmounts({ ...primary, itemAmount: 56090.8, labourAmount: 2375.25 }, 'F', policy),
    ).toEqual({ item: 56090.8, labour: 2375.25, net: 58466.05 });
  });
});
