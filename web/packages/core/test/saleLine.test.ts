import { describe, expect, it } from 'vitest';
import {
  applySaleGridEdit,
  computeSaleLine,
  formatCell2,
  type SaleLineCells,
  type SaleLineSettings,
} from '../src/saleLine.js';

/**
 * The shared Sale line (TR_SALE.cs CommPassTotal). Every review vector of PR #241 (two Codex rounds, 8 cases) is
 * here with the desktop's value worked out in IEEE double and .NET Math.Round.
 */
const settings: SaleLineSettings = {
  labourRateDecimals: 2,
  allRoundingRemoved: false,
  labourWithGhat: true,
};
const cells = (over: Partial<SaleLineCells>): SaleLineCells => ({
  pcs: 0,
  grossWt: 0,
  netWt: 0,
  ghtWt: 0,
  fineWt: 0,
  rateWith: 'N',
  itemRate: 0,
  labourMode: 'none',
  labourBasis: 'N',
  labourPct: 0,
  otherAmount: 0,
  ...over,
});

describe('review vectors (PR #241)', () => {
  it('R1-1: a typed labour rate after Lbr% stands: rate 100, Lbr% 10, net 10, N, Making 50 -> 500', () => {
    let row = { rate: '100', lbrPct: '', making: '', lbrPctApplied: '', grossWt: '10', pcs: '' };
    row = applySaleGridEdit(row, 'lbrPct', '10', 2);
    expect(row.making).toBe('10.00');
    row = applySaleGridEdit(row, 'making', '50', 2);
    const r = computeSaleLine(
      cells({ netWt: 10, itemRate: 100, labourMode: 'percentage', labourPct: 10, labourRate: 50 }),
      settings,
    );
    expect(row.making).toBe('50');
    expect([r.labourRate, r.labourAmount]).toEqual([50, 500]);
  });
  it('R1-2: 11.25 x 2.8 % = 0.31499999999999995 -> 0.31, 1000 g -> 310', () => {
    const r = computeSaleLine(
      cells({ netWt: 1000, itemRate: 11.25, labourMode: 'percentage', labourPct: 2.8 }),
      settings,
    );
    expect([r.labourRate, r.labourAmount]).toEqual([0.31, 310]);
  });
  it('R1-3: a typed ITM_AMT 1000.55 is kept (TR_SALE.cs:9478, :9495)', () => {
    const r = computeSaleLine(cells({ netWt: 10, itemRate: 100, itemAmount: 1000.55 }), settings);
    expect([r.itemAmount, r.netAmount]).toEqual([1000.55, 1000.55]);
  });
  it('R2-1: reopen keeps an overridden rate: P basis, 2 pcs, rate 100, Lbr% 10, typed 50 -> 100', () => {
    // Reopen restores LBR_RATE 50 and column 83 = LBR_PRC (:21091-21096); an unchanged save keeps 100.
    const reopened = {
      rate: '100',
      lbrPct: '10',
      making: '50',
      lbrPctApplied: '10',
      pcs: '2',
      grossWt: '',
    };
    const saved = applySaleGridEdit(reopened, 'rate', '100', 2);
    expect(saved.making).toBe('50');
    const r = computeSaleLine(
      cells({
        pcs: 2,
        itemRate: 100,
        labourMode: 'percentage',
        labourBasis: 'P',
        labourPct: 10,
        labourRate: 50,
      }),
      settings,
    );
    expect(r.labourAmount).toBe(100);
  });
  it('R2-2: Lbr% entered before the item rate waits for it: net 10, Making 50, Lbr% 10, rate 100 -> 100', () => {
    let row = { rate: '', lbrPct: '', making: '50', lbrPctApplied: '', grossWt: '10', pcs: '' };
    row = applySaleGridEdit(row, 'lbrPct', '10', 2);
    expect(row.making).toBe('50');
    row = applySaleGridEdit(row, 'rate', '100', 2);
    expect(row.making).toBe('10.00');
    const r = computeSaleLine(
      cells({
        netWt: 10,
        itemRate: 100,
        labourMode: 'percentage',
        labourPct: 10,
        labourRate: Number(row.making),
      }),
      settings,
    );
    expect(r.labourAmount).toBe(100);
  });
  it('R2-3: a typed Making/g 0.315 is the "0.00" cell 0.32 (TR_SALE.cs:9479-9496): 1000 g -> 320', () => {
    expect(formatCell2(0.315)).toBe(0.32);
    const r = computeSaleLine(
      cells({
        netWt: 1000,
        itemRate: 11.25,
        labourMode: 'percentage',
        labourPct: 2.8,
        labourRate: 0.315,
      }),
      settings,
    );
    expect([r.labourRate, r.labourAmount]).toEqual([0.32, 320]);
  });
  it('R2-4: the amount stage rounds the double: ALL_ROF_REMOVE, 0.29 g x 7.50 = 2.1749999999999998 -> 2.17', () => {
    expect(0.29 * 7.5).toBe(2.1749999999999998);
    const r = computeSaleLine(
      cells({ netWt: 0.29, itemRate: 75, labourMode: 'percentage', labourPct: 10 }),
      { ...settings, allRoundingRemoved: true },
    );
    expect([r.labourRate, r.labourAmount]).toEqual([7.5, 2.17]);
  });
  it('R2-5: a typed amount 1000.555 is the "0.00" cell 1000.56', () => {
    const r = computeSaleLine(cells({ netWt: 10, itemRate: 100, itemAmount: 1000.555 }), settings);
    expect(r.itemAmount).toBe(1000.56);
  });
});

describe('desktop event order (applySaleGridEdit)', () => {
  it('a changed item rate resets column 83 and drops a typed amount (TR_SALE.cs:10822-10830)', () => {
    const row = {
      rate: '100',
      lbrPct: '10',
      making: '50',
      lbrPctApplied: '10',
      metalAmount: '999',
      grossWt: '10',
      pcs: '',
    };
    const next = applySaleGridEdit(row, 'rate', '200', 2);
    expect([next.making, next.metalAmount]).toEqual(['20.00', '']);
  });
  it('Lbr% cleared clears the rate (TR_SALE.cs:11033-11048)', () => {
    const row = {
      rate: '100',
      lbrPct: '10',
      making: '10.00',
      lbrPctApplied: '10',
      grossWt: '1',
      pcs: '',
    };
    expect(applySaleGridEdit(row, 'lbrPct', '', 2).making).toBe('');
  });
});
