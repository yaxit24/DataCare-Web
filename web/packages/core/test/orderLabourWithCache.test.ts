import { describe, expect, it } from 'vitest';
import { orderLabourWithCache, type OrderLabourCache } from '../src/orderLabourWithCache.js';
import type { OrderLabourState } from '../src/orderLabour.js';

const policy = { includesGhat: false, rateDecimals: 2 };
const initial: OrderLabourState = {
  labourType: 'N',
  pcs: 2,
  grossWt: 6,
  netWt: 4,
  ghatWt: 1,
  itemRate: 1000,
  labourPct: 0,
  labourRate: 10,
  labourAmount: 40,
};
const initialCache: OrderLabourCache = { labourPct: 0, labourRate: 10, labourAmount: 40 };
describe('Sales order labour comparison caches after F1', () => {
  it('a copied visible rate remains separate until an actual trigger compares pre-F1 cache84', () => {
    const selected = { ...initial, labourRate: 12.5 };
    expect(selected.labourAmount).toBe(40);
    const next = orderLabourWithCache(selected, initialCache, policy);
    expect(next.state.labourAmount).toBe(50);
    expect(next.cache).toEqual({ ...initialCache, labourRate: 12.5 });
    expect(initialCache.labourRate).toBe(10);
    // Re-entering/leaving the same selected rate still compares to10, not tovisible12.5.
    expect(selected.labourRate).toBe(12.5);
  });
  it('applies copied visible percentage at a later trigger and leaves amount cache until its actual comparison', () => {
    const next = orderLabourWithCache({ ...initial, labourPct: 5 }, initialCache, policy);
    expect(next.state).toMatchObject({ labourPct: 5, labourRate: 50, labourAmount: 200 });
    expect(next.cache).toEqual({ labourPct: 5, labourRate: 50, labourAmount: 40 });
    const repeated = orderLabourWithCache(next.state, next.cache, policy);
    expect(repeated.state).toEqual(next.state);
    expect(repeated.cache).toEqual({ ...next.cache, labourAmount: 200 });
  });
  it('runs amount before percentage before rate when more than one visible cell differs', () => {
    const next = orderLabourWithCache(
      { ...initial, labourAmount: 60, labourPct: 2 },
      initialCache,
      policy,
    );
    expect(next.state).toMatchObject({ labourRate: 20, labourAmount: 80 });
    expect(next.cache).toEqual({ labourRate: 20, labourPct: 2, labourAmount: 60 });
  });
  it('a changed amount back-solves rate without immediately rerounding the manual amount', () => {
    const next = orderLabourWithCache({ ...initial, labourAmount: 41.25 }, initialCache, policy);
    expect(next.state).toMatchObject({ labourRate: 10.31, labourAmount: 41.25 });
    expect(next.cache).toEqual({ labourRate: 10.31, labourAmount: 41.25, labourPct: 0 });
  });
  it('zero percentage with nonzero item rate clears rate/amount; zero item rate does not advance percentage cache', () => {
    const cache = { ...initialCache, labourPct: 5 };
    expect(orderLabourWithCache(initial, cache, policy).state).toMatchObject({
      labourRate: 0,
      labourAmount: 0,
    });
    expect(orderLabourWithCache({ ...initial, itemRate: 0 }, cache, policy).cache.labourPct).toBe(
      5,
    );
  });
  it('an unchanged cache retains manual amounts even if weights changed', () => {
    const next = orderLabourWithCache(
      { ...initial, netWt: 9, labourAmount: 41.25 },
      { ...initialCache, labourAmount: 41.25 },
      policy,
    );
    expect(next.state.labourAmount).toBe(41.25);
  });
  it.each([
    ['P', 2, 25],
    ['G', 6, 75],
    ['N', 4, 50],
    ['K', 5, 0],
  ])('uses source %s rate basis and whole-rupee half-even amount', (labourType, _basis, amount) => {
    expect(
      orderLabourWithCache({ ...initial, labourType, labourRate: 12.5 }, initialCache, policy).state
        .labourAmount,
    ).toBe(amount);
  });
  it('retains the literal asymmetric kilogram amount-to-rate branch and rejects zero divisors', () => {
    const next = orderLabourWithCache(
      { ...initial, labourType: 'K', labourAmount: 1000 },
      initialCache,
      policy,
    );
    expect(next.state.labourRate).toBe(0.2);
    expect(next.state.labourAmount).toBe(1000);
    expect(() =>
      orderLabourWithCache({ ...initial, netWt: 0, labourAmount: 55 }, initialCache, policy),
    ).toThrow('zero basis');
  });
});
