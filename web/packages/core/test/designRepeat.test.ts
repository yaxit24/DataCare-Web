import { describe, expect, it } from 'vitest';
import {
  applyDesignCalculationEvent as apply,
  createDesignCalculationState as create,
  designRepeatValues,
  type DesignCalculationPolicy,
  type DesignCalculationState,
} from '../src/designCalc.js';
const config: DesignCalculationPolicy = {
  defaultLabourType: 'N',
  automaticCost: false,
  tagCostVisible: true,
  newBook: true,
  columns: [],
};
const column = (name: string, label = name, components = false, repeat = true, visible = true) => ({
  bookName: components ? 'TAG_IDTL' : 'DESIGN DETL',
  name,
  label,
  repeat,
  visible,
});
const child = (state: DesignCalculationState, serial: number) => {
  const found = state.components.find((entry) => entry.isrNo === serial);
  if (!found) throw new Error('Missing fixture component');
  return found;
};
describe('MS_DESIGN_BOOK repeat and keyboard source contract', () => {
  it('copies renamed and hidden repeat cells verbatim, including zero and blank, without rounding', () => {
    const policy = {
      ...config,
      columns: [
        column('GrWt', 'Customer gross'),
        column('TagCost', 'Internal cost', false, true, false),
        column('Touch', 'Purity', false, false),
      ],
    };
    expect(
      designRepeatValues({ grossWt: '1.23456', tagCost: '', touch: '91.123', pcs: 7 }, policy),
    ).toEqual({ grossWt: '1.23456', tagCost: '' });
    const result = apply(
      create({}, [], policy, false),
      { kind: 'repeatParent', values: { grossWt: '1.23456', tagCost: '' } },
      policy,
    );
    expect(result.values).toEqual({ pcs: 1, labourType: 'N', grossWt: '1.23456', tagCost: '' });
    expect(result.old.grossWt).toBe(0);
  });
  it('does not calculate a copied parent even when gross, net, fine and amounts intentionally differ', () => {
    const policy = {
      ...config,
      columns: ['GrWt', 'NetWt', 'Fine', 'ItRate', 'ItAmt', 'LbrAmt', 'Margin', 'Mrp'].map((name) =>
        column(name),
      ),
    };
    const copied = {
      grossWt: 10,
      netWt: 7,
      fineWt: 3.333,
      rate: 100,
      amount: 91.17,
      labourAmount: 12.25,
      marginPct: 5,
      mrp: 111.19,
    };
    const result = apply(
      create({}, [], policy, false),
      { kind: 'repeatParent', values: copied },
      policy,
    );
    expect(result.values).toMatchObject(copied);
    expect(result.values.otherWt).toBeUndefined();
  });
  it('matches COL_NEW_NAME after renaming and refuses conflicting alias flags', () => {
    const policy = {
      ...config,
      columns: [column('GrWt', 'Gross copy'), column('Other setting', 'Gross copy', false, false)],
    };
    expect(() => designRepeatValues({ grossWt: 10 }, policy)).toThrow('Ambiguous');
    expect(() =>
      designRepeatValues({ grossWt: 10 }, { ...config, columns: [column('GrWt', '')] }),
    ).toThrow('Ambiguous');
    // Source looks up the existing grid header even when no COL_NAME entry renames that header.
    expect(
      designRepeatValues(
        { grossWt: 10 },
        { ...config, columns: [column('Other setting', 'GrWt')] },
      ),
    ).toEqual({ grossWt: 10 });
  });
  it('excludes parent identities, image identity and unconfigured cells', () => {
    const policy = {
      ...config,
      columns: ['SR_NO', 'RowSrNo', 'Image', 'GrWt'].map((name) => column(name)),
    };
    expect(
      designRepeatValues(
        { srNo: 17, oldSrNo: 42, designImageId: 'old-photo', grossWt: 10 },
        policy,
      ),
    ).toEqual({ grossWt: 10 });
    for (const values of [{ srNo: 17 }, { rate: 500 }, { grossWt: 'invalid' }])
      expect(() =>
        apply(create({}, [], policy, false), { kind: 'repeatParent', values }, policy),
      ).toThrow();
  });
  it('refuses repeat defaults on persisted parents and a second initialization', () => {
    const policy = { ...config, columns: [column('GrWt')] };
    expect(() =>
      apply(create({ grossWt: 7 }), { kind: 'repeatParent', values: { grossWt: 10 } }, policy),
    ).toThrow('new design');
    const fresh = apply(
      create({}, [], policy, false),
      { kind: 'repeatParent', values: { grossWt: 10 } },
      policy,
    );
    expect(() => apply(fresh, { kind: 'repeatParent', values: { grossWt: 20 } }, policy)).toThrow(
      'new design',
    );
  });
  it('copies only the preceding component within its parent, preserving noncontiguous child identities', () => {
    const policy = {
      ...config,
      columns: ['ItCode', 'PcsWt', 'ItAmt', 'ConWt', 'OldKrWt'].map((name) =>
        column(name, name, true),
      ),
    };
    let state = create({ grossWt: 10, otherWt: 4, otherAmount: 91 }, [
      {
        isrNo: 7,
        values: {
          itCode: 'STONE',
          pcs: 4,
          pcsWt: '0.251',
          karigarWt: 2,
          amount: '17.29',
          conversionWt: '0.1234',
        },
      },
    ]);
    state = apply(state, { kind: 'addComponent', isrNo: 19 }, policy);
    const repeated = apply(state, { kind: 'repeatComponent', isrNo: 19, fromIsrNo: 7 }, policy);
    expect(child(repeated, 19).values).toEqual({
      itCode: 'STONE',
      pcsWt: '0.251',
      amount: '17.29',
      conversionWt: '0.1234',
    });
    expect(child(repeated, 19).oldKarigarWt).toBe(2);
    expect(repeated.values).toEqual(state.values);
    expect(child(repeated, 7)).toEqual(child(state, 7));
    expect(() =>
      apply(state, { kind: 'repeatComponent', isrNo: 19, fromIsrNo: 3 }, policy),
    ).toThrow('preceding');
    expect(() =>
      apply(repeated, { kind: 'repeatComponent', isrNo: 19, fromIsrNo: 7 }, policy),
    ).toThrow('preceding');
  });
  it('does not repeat children into a different parent or a persisted child', () => {
    const state = create({}, [
      { isrNo: 7, values: { amount: 20 } },
      { isrNo: 19, values: { amount: 30 } },
    ]);
    expect(() =>
      apply(state, { kind: 'repeatComponent', isrNo: 19, fromIsrNo: 7 }, config),
    ).toThrow('preceding');
    expect(() =>
      apply(create(), { kind: 'repeatComponent', isrNo: 19, fromIsrNo: 7 }, config),
    ).toThrow('not found');
  });
  it('Weight Enter tests the previously committed zero weight before applying the typed nonzero weight', () => {
    const state = create({}, [
      {
        isrNo: 7,
        values: {
          itCode: 'STONE',
          pcs: 0,
          grossWt: 0,
          rate: 5,
          amount: 0,
          labourAmount: 0,
          netAmount: 0,
        },
      },
    ]);
    const result = apply(
      state,
      {
        kind: 'componentEnter',
        isrNo: 7,
        field: 'grossWt',
        value: 2,
        defaults: { itType: 'S', conversionPct: 0, rateType: 'P', rate: 77.25 },
      },
      config,
    );
    expect(child(result, 7).values).toMatchObject({
      grossWt: 2,
      rate: '',
      amount: 0,
      netAmount: 77.25,
    });
  });
  it('Weight Enter preserves fixed net, but does not clear rate when prior pieces or weight are nonzero', () => {
    for (const values of [
      { pcs: 1, grossWt: 0 },
      { pcs: 0, grossWt: 1 },
    ]) {
      const state = create({}, [{ isrNo: 7, values: { ...values, rate: 5, netAmount: 91 } }]);
      expect(
        child(
          apply(state, { kind: 'componentEnter', isrNo: 7, field: 'grossWt', value: 2 }, config),
          7,
        ).values.rate,
      ).toBe(5);
    }
    const manual = create({}, [
      { isrNo: 7, values: { pcs: 0, grossWt: 0, rate: 5, netAmount: 91 } },
    ]);
    expect(
      child(
        apply(
          manual,
          {
            kind: 'componentEnter',
            isrNo: 7,
            field: 'grossWt',
            value: 0,
            defaults: { itType: 'S', conversionPct: 0, rateType: 'F', rate: 77 },
          },
          config,
        ),
        7,
      ).values.netAmount,
    ).toBe(91);
  });
  it('piece-weight Enter and net-amount Enter perform their source calculation without parent refresh', () => {
    let state = create({ grossWt: 10, fineWt: 8 }, [
      { isrNo: 7, values: { pcs: 4, grossWt: 0, rate: 5 } },
    ]);
    state = apply(
      state,
      { kind: 'componentEnter', isrNo: 7, field: 'pcsWt', value: 0.125 },
      config,
    );
    expect(child(state, 7).values).toMatchObject({
      karigarWt: 0.5,
      grossWt: 0.5,
      amount: 2.5,
      netAmount: 2.5,
    });
    state = apply(
      state,
      { kind: 'componentEnter', isrNo: 7, field: 'netAmount', value: 99 },
      config,
    );
    expect(child(state, 7).values.netAmount).toBe(2.5);
    expect(state.values.fineWt).toBe(8);
  });
  it('discards only untouched temporary empty child rows, without recalculating the retained parent', () => {
    let state = create({ grossWt: 10, otherAmount: 91 }, [
      { isrNo: 7, values: { itCode: 'STONE', amount: 20 } },
    ]);
    state = apply(state, { kind: 'addComponent', isrNo: 19 }, config);
    const discarded = apply(state, { kind: 'discardEmptyComponent', isrNo: 19 }, config);
    expect(discarded.values).toEqual(state.values);
    expect(discarded.components.map((entry) => entry.isrNo)).toEqual([7]);
    expect(() => apply(state, { kind: 'discardEmptyComponent', isrNo: 7 }, config)).toThrow(
      'untouched',
    );
  });
});
