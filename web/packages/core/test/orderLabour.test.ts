import { describe, expect, it } from 'vitest';
import {
  orderLabourAmount,
  orderLabourTransition,
  orderLabourReplay,
  type OrderLabourState,
} from '../src/orderLabour.js';

const policy = { includesGhat: true, rateDecimals: 2 };
const state = (patch: Partial<OrderLabourState> = {}): OrderLabourState => ({
  labourType: 'N',
  pcs: 3,
  grossWt: 12,
  netWt: 10,
  ghatWt: 2,
  itemRate: 7012.5,
  labourPct: 0,
  labourRate: 10.25,
  labourAmount: 77.37,
  ...patch,
});

describe('order-specific labour source branches', () => {
  it.each([
    ['P', true, 31],
    ['G', true, 123],
    ['G', false, 123],
    ['N', true, 123],
    ['N', false, 102],
    ['', true, 123],
    ['W', false, 102],
    ['K', true, 123],
    ['K', false, 123],
  ])('basis %s, ghat %s gives literal %s', (labourType, includesGhat, expected) => {
    expect(
      orderLabourAmount(state({ labourType, labourRate: labourType === 'K' ? 10250 : 10.25 }), {
        ...policy,
        includesGhat,
      }),
    ).toBe(expected);
  });
  it.each([
    [10.5, 10],
    [11.5, 12],
    [-10.5, -10],
    [-11.5, -12],
  ])('rounds midpoint %s to whole-rupee half-even %s', (labourRate, amount) => {
    expect(orderLabourAmount(state({ labourType: 'P', pcs: 1, labourRate }), policy)).toBe(amount);
  });
  it('percentage derives a rate, including explicit zero, then the chosen basis amount', () => {
    const previous = state();
    const next = orderLabourTransition(previous, state({ labourPct: 1 }), policy, 'percentage');
    expect(next.labourRate).toBe(70.12);
    expect(next.labourAmount).toBe(841);
    expect(
      orderLabourTransition(next, { ...next, labourPct: 0 }, policy, 'percentage'),
    ).toMatchObject({ labourRate: 0, labourAmount: 0 });
  });
  it('does not reprice a manual amount when percentage derives the unchanged cached rate', () => {
    expect(
      orderLabourTransition(
        state({ labourRate: 70.12 }),
        state({ labourRate: 70.12, labourPct: 1 }),
        policy,
        'percentage',
      ).labourAmount,
    ).toBe(77.37);
  });
  it('manual amount updates the inverse rate and preserves the entered paise', () => {
    expect(
      orderLabourTransition(state(), state({ labourAmount: 150.75 }), policy, 'amount'),
    ).toMatchObject({ labourAmount: 150.75, labourRate: 12.56 });
    expect(
      orderLabourTransition(state(), state({ labourAmount: 0 }), policy, 'amount'),
    ).toMatchObject({ labourAmount: 0, labourRate: 10.25 });
  });
  it('retains the unusual literal K inverse instead of inventing an inverse formula', () => {
    expect(
      orderLabourTransition(
        state({ labourType: 'K' }),
        state({ labourType: 'K', labourAmount: 120 }),
        policy,
        'amount',
      ),
    ).toMatchObject({ labourAmount: 120, labourRate: 0.01 });
  });
  it('keeps manual rate zero and refuses a nonzero-rate inverse with a zero basis', () => {
    expect(
      orderLabourTransition(
        state({ labourRate: 0 }),
        state({ labourRate: 0, labourAmount: 150.75 }),
        policy,
        'amount',
      ).labourRate,
    ).toBe(0);
    expect(() =>
      orderLabourTransition(
        state(),
        state({ netWt: 0, ghatWt: 0, labourAmount: 1 }),
        policy,
        'amount',
      ),
    ).toThrow('zero basis');
  });
  it('preserves manual values for unchanged rate, including when only the basis changes', () => {
    const previous = state();
    expect(orderLabourTransition(previous, previous, policy, 'rate')).toEqual(previous);
    expect(
      orderLabourTransition(previous, state({ labourType: 'P', pcs: 100 }), policy, 'rate')
        .labourAmount,
    ).toBe(77.37);
  });
  it('applies configured rate precision before the two-decimal cell format', () => {
    expect(
      orderLabourTransition(
        state(),
        state({ labourPct: 1 }),
        { ...policy, rateDecimals: 0 },
        'percentage',
      ).labourRate,
    ).toBe(70);
    expect(
      orderLabourTransition(
        state(),
        state({ itemRate: 1234.5, labourPct: 1 }),
        { ...policy, rateDecimals: 3 },
        'percentage',
      ).labourRate,
    ).toBe(12.35);
  });
});

describe('ordered labour edit replay', () => {
  const basis = { labourType: 'N', pcs: 2, grossWt: 3.5, netWt: 3.123, ghatWt: 0, itemRate: 7000 };
  it('uses the basis at rate entry even if ghat changes later', () => {
    const replayed = orderLabourReplay(
      state({ labourRate: 0, labourAmount: 0, labourPct: 0 }),
      [{ action: 'rate', value: 37.321, basis }],
      policy,
    );
    expect(replayed).toMatchObject({ labourRate: 37.32, labourAmount: 117 });
    expect(orderLabourAmount({ ...replayed, ghatWt: 0.103 }, policy)).toBe(120);
  });
  it('recalculates rate changed away and back, while an unchanged save needs no events', () => {
    const previous = state({ labourType: 'P', pcs: 3, labourRate: 10.25, labourAmount: 77.37 });
    const snapshot = { ...basis, labourType: 'P', pcs: 3 };
    const replayed = orderLabourReplay(
      previous,
      [
        { action: 'rate', value: 20, basis: snapshot },
        { action: 'rate', value: 10.25, basis: snapshot },
      ],
      policy,
    );
    expect(replayed.labourAmount).toBe(31);
    expect(orderLabourReplay(previous, [], policy)).toEqual(previous);
  });
  it('rejects malformed committed cells and unbounded event lists', () => {
    expect(() =>
      orderLabourReplay(state(), [{ action: 'rate', value: Infinity, basis }], policy),
    ).toThrow('Invalid committed');
    expect(() =>
      orderLabourReplay(state(), Array(257).fill({ action: 'rate', value: 1, basis }), policy),
    ).toThrow('at most 256');
  });
});
