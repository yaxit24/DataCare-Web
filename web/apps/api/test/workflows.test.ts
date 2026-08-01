import { describe, it, expect } from 'vitest';
import { billTotals, gstSplit, metalAmount, labourCharge, lineNet } from '@datacare/core';
import { buildSaleLedger } from '../src/modules/sales/sales.js';
import { buildReturnLedger } from '../src/modules/sales/salesReturn.js';
import { buildPurchaseLedger } from '../src/modules/purchase/purchase.js';
import { buildPurchaseReturnLedger } from '../src/modules/purchase/purchaseReturn.js';
import { assertBalanced } from '../src/modules/posting/posting.js';
import {
  accruedInterest,
  monthlyTermInterest,
  monthlyInterest,
  dhrnInterest,
} from '../src/modules/dhrn/dhrn.js';
import {
  fineWeight,
  fineWithWastage,
  karigarBalance,
  INOUT_ISSUE,
  INOUT_RECEIPT,
} from '../src/modules/manufacturing/karigar.js';

const KEY = { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024', CO_BOOK: 'SAL', VCH_NO: '1' };
const drcr = (lines: any[]) => ({
  dr: lines.reduce((s, l) => s + (Number(l.DR_AMT) || 0), 0),
  cr: lines.reduce((s, l) => s + (Number(l.CR_AMT) || 0), 0),
});

describe('calc engine — edge cases', () => {
  it('zero net → zero everything', () => {
    const t = billTotals({ lineNetTotal: 0, taxRatePct: 3, interState: false });
    expect(t.total).toBe(0);
    expect(t.tax).toBe(0);
    expect(t.taxable).toBe(0);
  });
  it('discount equal to net → taxable 0, tax 0', () => {
    const t = billTotals({
      lineNetTotal: 50000,
      discountAmount: 50000,
      taxRatePct: 3,
      interState: false,
    });
    expect(t.taxable).toBe(0);
    expect(t.tax).toBe(0);
    expect(t.total).toBe(0);
  });
  it('intra-state splits CGST=SGST=tax/2, IGST=0', () => {
    const t = billTotals({ lineNetTotal: 100000, taxRatePct: 3, interState: false });
    expect(t.tax).toBe(3000);
    expect(t.cgst).toBe(1500);
    expect(t.sgst).toBe(1500);
    expect(t.igst).toBe(0);
  });
  it('inter-state puts all tax in IGST', () => {
    const t = billTotals({ lineNetTotal: 100000, taxRatePct: 3, interState: true });
    expect(t.igst).toBe(3000);
    expect(t.cgst).toBe(0);
    expect(t.sgst).toBe(0);
  });
  it('round-off ties total = taxable + tax + roundOff', () => {
    const t = billTotals({ lineNetTotal: 72857, taxRatePct: 3, interState: false }); // desktop vch1
    expect(Math.round((t.taxable + t.tax + t.roundOff) * 100) / 100).toBe(t.total);
    expect(t.total).toBe(75043); // matches desktop stored TOT_AMT
  });
  it('splits an odd-paise tax into two EQUAL unrounded halves, as TR_SALE.cs does', () => {
    // Desktop: ["SGST_TAX"] = Val(MSG2_TOTAL[2,3]) / 2.0 and ["CGST_TAX"] = the same expression.
    // Both columns are `double precision` with no scale, so nothing rounds the halves and neither head
    // absorbs a remainder. GST returns report CGST and SGST separately, so an unequal split would show.
    const s = gstSplit(756.45, false);
    expect(s.cgst).toBe(378.225);
    expect(s.sgst).toBe(378.225);
    expect(s.cgst).toBe(s.sgst);
    expect(s.cgst + s.sgst).toBeCloseTo(756.45, 10);
    expect(s.igst).toBe(0);
  });

  it('puts the whole tax on IGST inter-state and leaves both intra heads at zero', () => {
    const s = gstSplit(756.45, true);
    expect(s).toEqual({ cgst: 0, sgst: 0, igst: 756.45 });
  });
  it('metalAmount = fine × rate; labour types', () => {
    expect(metalAmount(100, 7000)).toBe(700000);
    expect(labourCharge('fixed', { fixed: 2000 })).toBe(2000);
    expect(labourCharge('per_gram', { netWt: 10, rate: 300 })).toBe(3000);
    expect(labourCharge('percentage', { metalAmount: 50000, pct: 8 })).toBe(4000);
    expect(lineNet({ metal: 50000, labour: 2000, other: 500 })).toBe(52500);
  });
});

describe('double-entry workflow — sale, purchase, and reversals', () => {
  const totals = billTotals({ lineNetTotal: 72857, taxRatePct: 3, interState: false });
  it('sale ledger is balanced', () => {
    const l = buildSaleLedger({
      key: KEY,
      acCode: 'CUST',
      salesAc: 'SALES',
      taxAc: 'GST',
      roundAc: 'ROF',
      totals,
    });
    const { dr, cr } = drcr(l);
    expect(dr).toBeCloseTo(cr, 2);
  });
  it('sale + sales-return net to ZERO per account (full reversal)', () => {
    const sale = buildSaleLedger({
      key: KEY,
      acCode: 'CUST',
      salesAc: 'SALES',
      taxAc: 'GST',
      roundAc: 'ROF',
      totals,
    });
    const ret = buildReturnLedger({
      key: KEY,
      acCode: 'CUST',
      salesAc: 'SALES',
      taxAc: 'GST',
      roundAc: 'ROF',
      totals,
    });
    const net: Record<string, number> = {};
    for (const l of [...sale, ...ret])
      net[String(l.AC_CODE)] =
        (net[String(l.AC_CODE)] || 0) + (Number(l.DR_AMT) || 0) - (Number(l.CR_AMT) || 0);
    for (const ac of Object.keys(net)) expect(Math.abs(net[ac]!)).toBeLessThan(0.005);
  });
  it('purchase ledger balanced + purchase-return is its mirror', () => {
    const pur = buildPurchaseLedger({
      key: KEY,
      acCode: 'SUPP',
      purchaseAc: 'PURCH',
      taxAc: 'GSTIN',
      roundAc: 'ROF',
      totals,
    });
    const pret = buildPurchaseReturnLedger({
      key: KEY,
      acCode: 'SUPP',
      purchaseAc: 'PURCH',
      taxAc: 'GSTIN',
      roundAc: 'ROF',
      totals,
    });
    expect(() => assertBalanced(pur)).not.toThrow();
    const net: Record<string, number> = {};
    for (const l of [...pur, ...pret])
      net[String(l.AC_CODE)] =
        (net[String(l.AC_CODE)] || 0) + (Number(l.DR_AMT) || 0) - (Number(l.CR_AMT) || 0);
    for (const ac of Object.keys(net)) expect(Math.abs(net[ac]!)).toBeLessThan(0.005);
  });
  it('assertBalanced throws on an unbalanced ledger', () => {
    expect(() =>
      assertBalanced([{ ...KEY, AC_CODE: 'X', DR_AMT: 100, CR_AMT: 0, SIGN: 'D' } as any]),
    ).toThrow();
  });
});

describe('dhrn interest — modes + lifecycle parity', () => {
  it('monthly-term interest = principal × rate% × months (desktop DHRN_INT_TYPE=M)', () => {
    expect(monthlyTermInterest(50000, 2, 3)).toBe(3000); // 50000 × 2% × 3
  });
  it('day-count interest = principal × rate% × days/yearDays', () => {
    expect(accruedInterest(50000, 12, 30, 360)).toBe(500); // 50000 ×12%×30/360
  });
  it('dispatcher honours type', () => {
    expect(dhrnInterest({ type: 'M', principal: 50000, ratePct: 2, months: 3 })).toBe(3000);
    expect(
      dhrnInterest({ type: 'D', principal: 50000, ratePct: 12, days: 30, yearDays: 360 }),
    ).toBe(500);
  });
  it('monthlyInterest = 30-day slice', () => {
    expect(monthlyInterest(50000, 12, 360)).toBe(500);
  });
});

describe('karigar metal-flow — fine, wastage, balance', () => {
  it('fine = nwt × touch / 100', () => {
    expect(fineWeight(100, 91.6)).toBe(91.6);
  });
  it('receipt folds wastage: nwt × (touch + west)/100', () => {
    expect(fineWithWastage(100, 91.6, 2)).toBe(93.6);
  });
  it('balance = issued − received; INOUT constants I/O', () => {
    expect(karigarBalance(91.6, 0)).toBe(91.6);
    expect(karigarBalance(91.6, 93.6)).toBeCloseTo(-2, 3);
    expect(INOUT_ISSUE).toBe('O');
    expect(INOUT_RECEIPT).toBe('I');
  });
});
