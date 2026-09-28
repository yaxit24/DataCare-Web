import { describe, expect, it } from 'vitest';
import {
  createDesignCalculationState as state,
  applyDesignCalculationEvent as apply,
  replayDesignCalculationEvents as replay,
  designCalculationTotals,
  type DesignCalculationEvent,
  type DesignCalculationPolicy,
  type DesignCalculationState,
} from '../src/designCalc.js';

const policy: DesignCalculationPolicy = {
  defaultLabourType: 'G',
  automaticCost: false,
  tagCostVisible: true,
};
const parent = (field: string, value: string | number | null): DesignCalculationEvent => ({
  kind: 'parent',
  field,
  value,
});
const component = (
  field: string,
  value: string | number | null,
  isrNo = 7,
): DesignCalculationEvent => ({ kind: 'component', isrNo, field, value });
const child = (result: DesignCalculationState) => {
  const value = result.components[0]?.values;
  if (!value) throw new Error('Missing test component');
  return value;
};

describe('Design Book source-defined ordered calculation vectors', () => {
  it('hydrates exact null, zero, blank and higher-precision snapshots without applying formulas', () => {
    const original = { grossWt: '12.123456', otherWt: null, rate: '', amount: 0, tagCost: 713.47 };
    const loaded = state(original, [{ isrNo: 7, values: { pcsWt: '0.251', labourAmount: null } }]);
    expect(loaded.values).toEqual(original);
    expect(child(loaded)).toEqual({ pcsWt: '0.251', labourAmount: null });
    expect(replay(loaded, [], policy)).toBe(loaded);
  });
  it('uses new parent pcs 1 and configured labour type without changing saved blank labour type', () => {
    expect(state({}, [], { ...policy, defaultLabourType: 'P' }, false).values).toEqual({
      pcs: 1,
      labourType: 'P',
    });
    expect(state({ pcs: null, labourType: '' }, [], policy, true).values).toEqual({
      pcs: null,
      labourType: '',
    });
  });
  it('formats a piece leave but does not recalculate amount until a numeric trigger', () => {
    let result = state({
      pcs: 3,
      grossWt: 10,
      netWt: 10,
      fineWt: 10,
      rate: 3.5,
      rateType: 'P',
      amount: 10,
    });
    result = apply(result, parent('pcs', 4.5), policy);
    expect(result.values).toMatchObject({ pcs: 5, amount: 10 });
    result = apply(result, { kind: 'refreshParent' }, policy);
    expect(result.values.amount).toBe(18);
  });
  it('preserves the fine-before-new-ghat source ordering and only updates on later qualifying triggers', () => {
    let result = state({ grossWt: 10, netWt: 10, touch: 50, fineWt: 5, ghatPct: 10, ghatWt: 1 });
    result = apply(result, parent('grossWt', 20), policy);
    expect(result.values).toMatchObject({ netWt: 20, fineWt: 10.5, ghatWt: 2 });
    result = apply(result, parent('amount', 0), policy);
    expect(result.values.fineWt).toBe(10.5);
    result = apply(result, parent('touch', 51), policy);
    expect(result.values.fineWt).toBe(11.22);
  });
  it.each([
    ['P', 10],
    ['1', 4],
    ['K', 0],
    ['G', 35],
    ['N', 35],
    ['', 35],
  ])('parent rate basis %s has .NET whole-amount midpoint rounding', (basis, expected) => {
    const result = apply(
      state({ pcs: 3, grossWt: 10, netWt: 10, fineWt: 10, rateType: basis }),
      parent('rate', 3.5),
      policy,
    );
    expect(result.values.amount).toBe(expected);
  });
  it('leaves manual amount when rate or fine is zero, including piece basis with zero fine', () => {
    expect(apply(state({ amount: 91, fineWt: 10 }), parent('rate', 0), policy).values.amount).toBe(
      91,
    );
    expect(
      apply(state({ amount: 91, pcs: 8, rateType: 'P' }), parent('rate', 10), policy).values.amount,
    ).toBe(91);
  });
  it.each([
    ['P', 10],
    ['N', 32],
    ['K', 0],
    ['G', 35],
    ['', 35],
  ])('parent labour basis %s preserves source gross/net-ghat/pieces bases', (basis, expected) => {
    const result = apply(
      state({
        pcs: 3,
        grossWt: 10,
        netWt: 8,
        otherWt: 2,
        ghatWt: 1,
        labourType: basis,
        labourPct: 80,
      }),
      parent('labourRate', 3.5),
      policy,
    );
    expect(result.values.labourAmount).toBe(expected);
    expect(result.values.labourPct).toBe(80);
  });
  it('does not consume labour percentage or manufacture NET_AMT; rate zero preserves manual labour', () => {
    const result = apply(
      state({ labourAmount: 43, labourRate: 0, amount: 50, netAmount: 991 }),
      parent('labourPct', 20),
      policy,
    );
    expect(result.values).toMatchObject({ labourAmount: 43, netAmount: 991 });
  });
  it('requires configured automatic cost and rounds that cost to one decimal', () => {
    const initial = state({ tagCost: 19, purchaseCost: 29, otherAmount: 0 });
    expect(apply(initial, parent('amount', 20.25), policy).values).toMatchObject({
      tagCost: 19,
      purchaseCost: 29,
    });
    expect(
      apply(initial, parent('amount', 20.25), { ...policy, automaticCost: true }).values,
    ).toMatchObject({ tagCost: 20.3, purchaseCost: 20.3 });
  });
  it('MRP depends on margin changing, and preserves a manual MRP when only base cost changes', () => {
    let result = apply(state({ tagCost: 210, mrp: 900 }), parent('marginPct', 5), policy);
    expect(result.values.mrp).toBe(220);
    result = apply(result, parent('tagCost', 400), policy);
    expect(result.values.mrp).toBe(220);
    result = apply(result, parent('mrp', 701.25), policy);
    expect(result.values.mrp).toBe(701.25);
  });
  it('uses transient purchase cost only when TagCost is hidden and its normal branch did not consume the margin change', () => {
    const initial = state({ tagCost: 0, purchaseCost: 100, mrp: 900 });
    expect(apply(initial, parent('marginPct', 5), policy).values.mrp).toBe(900);
    expect(
      apply(initial, parent('marginPct', 5), { ...policy, tagCostVisible: false }).values.mrp,
    ).toBe(105);
  });
  it('applies karigar percentage itself, conversion multiplication and component-only parent aggregates', () => {
    let result = state({ grossWt: 10, fineWt: 99, rate: 123 }, [
      {
        isrNo: 7,
        values: {
          pcs: 4,
          pcsWt: 2,
          karigarLessPct: 10,
          conversionPct: 0.2,
          rate: 50,
          labourRate: 2,
        },
      },
    ]);
    result = apply(result, component('pcs', 4), policy);
    expect(child(result)).toMatchObject({
      karigarWt: 8,
      grossWt: 0.8,
      conversionWt: 0.16,
      karigarConversionWt: 1.6,
      amount: 40,
      labourAmount: 8,
      netAmount: 48,
    });
    expect(result.values).toMatchObject({
      otherWt: 0.16,
      netWt: 9.84,
      otherAmount: 48,
      fineWt: 99,
    });
    expect(result.values.amount).toBeUndefined();
  });
  it.each([
    ['P', 0.5, 3.5],
    ['P', 0.51, 1.53],
    ['P', -0.5, -3.5],
    ['P', -0.51, -1.53],
    ['G', 0.51, 3.57],
    ['1', 0.51, 3.57],
    ['K', 0.51, 3.57],
    ['', 0.51, 3.57],
  ])('IL verified component %s rate %s produces %s', (basis, rate, expected) => {
    const result = apply(
      state({}, [{ isrNo: 7, values: { pcs: 3, grossWt: 7, rateType: basis } }]),
      component('rate', rate),
      policy,
    );
    expect(child(result).amount).toBe(expected);
  });
  it('blank basis with zero customer weight uses pieces, and amount uses two-place half-up', () => {
    expect(
      child(apply(state({}, [{ isrNo: 7, values: { pcs: 3 } }]), component('rate', 1.25), policy))
        .amount,
    ).toBe(3.75);
    expect(
      child(
        apply(
          state({}, [{ isrNo: 7, values: { grossWt: 0.125 } }]),
          component('rate', 1.16),
          policy,
        ),
      ).amount,
    ).toBe(0.15);
  });
  it('uses old customer/karigar snapshots for zero-only backfill', () => {
    let result = state({}, [{ isrNo: 7, values: { grossWt: 0, karigarWt: 0 } }]);
    result = apply(result, component('karigarWt', 8), policy);
    expect(child(result)).toMatchObject({ grossWt: 8, karigarWt: 8 });
    result = apply(result, component('karigarWt', 10), policy);
    expect(child(result)).toMatchObject({ grossWt: 8, karigarWt: 10 });
    expect(
      child(
        apply(
          state({}, [{ isrNo: 7, values: { grossWt: 0, karigarWt: 0 } }]),
          component('grossWt', 3),
          policy,
        ),
      ).karigarWt,
    ).toBe(3);
  });
  it('retains manual amount/labour/net and parent amounts when zero guards fail, while conversion clears', () => {
    const result = apply(
      state({ otherWt: 4, netWt: 6, otherAmount: 55 }, [
        { isrNo: 7, values: { amount: 10, labourAmount: -10, netAmount: 0, conversionWt: 9 } },
      ]),
      component('rate', 0),
      policy,
    );
    expect(child(result)).toMatchObject({
      amount: 10,
      labourAmount: -10,
      netAmount: 0,
      conversionWt: 0,
    });
    expect(result.values).toMatchObject({ otherWt: 4, netWt: 6, otherAmount: 55 });
  });
  it('other weight leave recalculates first component before parent; removing last child retains nonzero guarded totals', () => {
    let result = state({ grossWt: 10 }, [
      { isrNo: 7, values: { grossWt: 2, conversionPct: 0.5, netAmount: 11 } },
    ]);
    result = apply(result, parent('otherWt', 9), policy);
    expect(result.values).toMatchObject({ otherWt: 1, netWt: 9, fineWt: 9, otherAmount: 11 });
    result = apply(result, { kind: 'removeComponent', isrNo: 7 }, policy);
    expect(result.components).toEqual([]);
    expect(result.values).toMatchObject({ otherWt: 1, otherAmount: 11 });
  });
  it('item defaults apply rates and basis only to new books and preserve manual nonzero cells', () => {
    const event: DesignCalculationEvent = {
      kind: 'item',
      isrNo: 7,
      itCode: 'STONE',
      defaults: { itType: 'D', conversionPct: 0.2, rateType: 'P', rate: 75 },
    };
    const initial = state({}, [{ isrNo: 7, values: {} }]);
    expect(child(apply(initial, event, policy))).toEqual({
      itCode: 'STONE',
      itType: 'D',
      conversionPct: 0.2,
    });
    expect(child(apply(initial, event, { ...policy, newBook: true }))).toMatchObject({
      rate: 75,
      rateType: 'P',
      conversionPct: 0.2,
    });
    const manual = state({}, [
      { isrNo: 7, values: { rate: 99, rateType: 'G', conversionPct: 0.8 } },
    ]);
    expect(child(apply(manual, event, { ...policy, newBook: true }))).toMatchObject({
      rate: 99,
      rateType: 'G',
      conversionPct: 0.8,
    });
    expect(
      child(
        apply(
          initial,
          { ...event, defaults: { ...event.defaults!, rateType: 'F' } },
          { ...policy, newBook: true },
        ),
      ),
    ).toMatchObject({ netAmount: 75 });
  });
  it('sums per formatted addition and keeps the desktop 3dp MRP total', () => {
    expect(
      designCalculationTotals([
        { pcs: 0.5, grossWt: 0.0005, amount: 0.005, mrp: 1.125 },
        { pcs: 0.5, grossWt: 0.0005, amount: 0.005, mrp: 2.125 },
      ]),
    ).toMatchObject({ pcs: 2, grossWt: 0.002, amount: 0.02, mrp: 3.25 });
  });
  it('rejects invalid events, unknown serials and duplicate add identities without changing its input', () => {
    const initial = state({ grossWt: 5 }, [{ isrNo: 7, values: {} }]);
    expect(() => apply(initial, component('rate', 'oops'), policy)).toThrow('finite');
    expect(() => apply(initial, parent('unknown', 1), policy)).toThrow('Unsupported');
    expect(() => apply(initial, component('rate', 3, 99), policy)).toThrow('not found');
    expect(() => apply(initial, { kind: 'addComponent', isrNo: 7 }, policy)).toThrow('Duplicate');
    expect(initial.values).toEqual({ grossWt: 5 });
  });
});
