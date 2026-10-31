import { describe, expect, it } from 'vitest';
import {
  ITEM_OPENING_TYPES,
  isItemOpeningType,
  itemOpeningRow,
  itemOpeningRowSaved,
  itemOpeningTotals,
} from '../src/itemOpening.js';

/** Expected values are worked by hand from TR_ITM_OPBL.cs CommPassTotal (:942-993), not from the code under test. */
describe('itemOpeningRow (TR_ITM_OPBL CommPassTotal)', () => {
  it('lists the seven desktop metal types in the combo order', () => {
    expect(ITEM_OPENING_TYPES.map((type) => `${type.code}:${type.name}`)).toEqual([
      'G:Gold',
      'S:Silver',
      'D:Diamond',
      'R:Real Stone',
      'E:Emitation',
      'O:Other',
      'P:Platinum',
    ]);
    expect(isItemOpeningType('G')).toBe(true);
    expect(isItemOpeningType('X')).toBe(false);
    expect(isItemOpeningType('')).toBe(false);
  });

  it('takes the gross weight for a blank net weight and works fine with touch and wastage', () => {
    // net = 10.5 (from gross); fine = 10.5 × (91.6 + 2) / 100 = 9.828; amount = 9.828 × 6000 = 58,968.
    const row = itemOpeningRow({ grossWt: 10.5, touch: 91.6, westPct: 2, rate: 6000 });
    expect(row).toMatchObject({ netWt: 10.5, fineWt: 9.828, amount: 58968, netAmt: 58968 });
  });

  it('uses the net weight as the fine when touch is blank, and keeps a typed amount when there is no rate', () => {
    const row = itemOpeningRow({ grossWt: 12, netWt: 11.25, amount: 750.5 });
    expect(row).toMatchObject({ netWt: 11.25, fineWt: 11.25, amount: 750.5, netAmt: 750.5 });
  });

  it('prices a piece-rated item without fine by pieces × rate', () => {
    // A piece item with no weight: fine = net = 0, so amount = 3 × 250 = 750.
    const row = itemOpeningRow({ rateType: 'P', pcs: 3, rate: 250 });
    expect(row).toMatchObject({ fineWt: 0, amount: 750, netAmt: 750 });
    // A gram-rated item with no fine keeps the amount as typed.
    expect(itemOpeningRow({ rateType: 'G', pcs: 3, rate: 250, amount: 99 }).amount).toBe(99);
  });

  it('works labour by its type and rounds it half to even to whole rupees', () => {
    const base = { pcs: 2, grossWt: 10.5, netWt: 10, othAmt: 100 };
    // P: 2 × 125.25 = 250.5 → 250 (half to even); N: 10 × 12.5 = 125; K: 10 × 2.5 / 1000 = 0.025 → 0;
    // G: 10.5 × 13 = 136.5 → 136; any other letter works on net: 10 × 12.5 = 125.
    expect(itemOpeningRow({ ...base, lbrType: 'P', lbrRate: 125.25 }).lbrAmt).toBe(250);
    expect(itemOpeningRow({ ...base, lbrType: 'N', lbrRate: 12.5 }).lbrAmt).toBe(125);
    expect(itemOpeningRow({ ...base, lbrType: 'K', lbrRate: 2.5 }).lbrAmt).toBe(0);
    expect(itemOpeningRow({ ...base, lbrType: 'G', lbrRate: 13 }).lbrAmt).toBe(136);
    expect(itemOpeningRow({ ...base, lbrType: 'X', lbrRate: 12.5 }).lbrAmt).toBe(125);
    // Net amount = item amount (fine 10 × no rate = 0) + labour 136 + other 100.
    expect(itemOpeningRow({ ...base, lbrType: 'g', lbrRate: 13 }).netAmt).toBe(236);
    // With no labour rate the typed labour amount stays.
    expect(itemOpeningRow({ ...base, lbrAmt: 40 }).lbrAmt).toBe(40);
  });

  it('holds each cell in the grid format: whole pieces, three-place weights, two-place amounts', () => {
    const row = itemOpeningRow({ pcs: '2.4', grossWt: '1.23456', touch: '91.666', rate: '10.005' });
    expect(row).toMatchObject({ pcs: 2, grossWt: 1.235, netWt: 1.235, touch: 91.67, rate: 10.01 });
    // fine = 1.235 × 91.67 / 100 = 1.13212… → 1.132; amount = 1.132 × 10.01 = 11.33132 → 11.33.
    expect(row).toMatchObject({ fineWt: 1.132, amount: 11.33 });
  });

  it('saves a row only when gross weight plus pieces is not zero', () => {
    expect(itemOpeningRowSaved(itemOpeningRow({}))).toBe(false);
    expect(itemOpeningRowSaved(itemOpeningRow({ pcs: 1 }))).toBe(true);
    expect(itemOpeningRowSaved(itemOpeningRow({ grossWt: 0.001 }))).toBe(true);
    // Only the rate and amount typed: the desktop drops the row.
    expect(itemOpeningRowSaved(itemOpeningRow({ rate: 100, amount: 500 }))).toBe(false);
  });

  it('totals pieces, weights, fine, item amount and net amount', () => {
    const totals = itemOpeningTotals([
      itemOpeningRow({ pcs: 1, grossWt: 10.5, touch: 91.6, rate: 6000 }),
      itemOpeningRow({ pcs: 2, grossWt: 5.25, netWt: 5, touch: 75 }),
    ]);
    // Row 1: fine 9.618, amount 57,708; row 2: fine 3.75, no rate.
    expect(totals).toEqual({
      pcs: 3,
      grossWt: 15.75,
      netWt: 15.5,
      fineWt: 13.368,
      amount: 57708,
      netAmt: 57708,
    });
  });
});
