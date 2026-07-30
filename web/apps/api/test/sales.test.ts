import { describe, it, expect } from 'vitest';
import {
  buildSaleFineLedger,
  buildSaleLedger,
  buildIncomeLegs,
  computeLine,
} from '../src/modules/sales/sales.js';
import { ledgerBalance } from '../src/modules/posting/posting.js';

const key = { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024', CO_BOOK: 'SAL', VCH_NO: '1' };

describe('sales builders', () => {
  it('computeLine = metal + labour + other', () => {
    const c = computeLine({
      itCode: 'I1',
      metalAmount: 1000,
      labourType: 'fixed',
      labourFixed: 200,
      otherAmount: 50,
    });
    expect(c.metal).toBe(1000);
    expect(c.labour).toBe(200);
    expect(c.net).toBe(1250);
  });
  it.each([
    ['F', 900],
    ['G', 1300],
    ['N', 1100],
    ['P', 1100],
  ] as const)('computeLine applies SL_AMT_TYPE=%s to metal amount', (type, expected) => {
    const c = computeLine(
      { itCode: 'I1', grossWt: 12, netWt: 10, ghtWt: 1, fineWt: 9, rate: 100 },
      undefined,
      type,
    );
    expect(c.metal).toBe(expected);
  });
  it('buildSaleLedger balances (no round-off)', () => {
    const lines = buildSaleLedger({
      key,
      acCode: 'CUST',
      salesAc: 'SALES',
      taxAc: 'GST',
      roundAc: 'ROF',
      totals: { total: 1180, taxable: 1000, tax: 180, roundOff: 0 },
    });
    const b = ledgerBalance(lines);
    expect(b.balanced).toBe(true);
    expect(b.dr).toBe(1180);
    expect(lines.length).toBe(3); // no round-off line
  });
  it('buildSaleLedger balances (with round-off)', () => {
    const lines = buildSaleLedger({
      key,
      acCode: 'CUST',
      salesAc: 'SALES',
      taxAc: 'GST',
      roundAc: 'ROF',
      totals: { total: 1181, taxable: 1000, tax: 180.4, roundOff: 0.6 },
    });
    expect(ledgerBalance(lines).balanced).toBe(true);
    expect(lines.length).toBe(4);
  });
  it('posts desktop gross party plus paired tender rows with actual contra accounts', () => {
    const lines = buildSaleLedger({
      key,
      acCode: 'CUST',
      salesAc: 'SALES',
      taxAc: 'GST',
      roundAc: 'ROF',
      controlAc: 'CTRL',
      totals: { total: 1180, taxable: 1000, tax: 180, roundOff: 0 },
      payments: { cashAc: 'CASH', cashAmt: 200 },
    });
    expect(ledgerBalance(lines).balanced).toBe(true);
    expect(lines).toEqual(
      expect.arrayContaining([
        expect.objectContaining({ AC_CODE: 'CUST', LD_CODE: 'CTRL', DR_AMT: 1180 }),
        expect.objectContaining({ AC_CODE: 'CUST', LD_CODE: 'CASH', CR_AMT: 200 }),
        expect.objectContaining({ AC_CODE: 'CASH', LD_CODE: 'CUST', DR_AMT: 200 }),
      ]),
    );
  });
  it('suppresses normal money legs and posts desktop leg 38 for an unfixed sale', () => {
    expect(
      buildSaleLedger({
        key,
        acCode: 'CUST',
        salesAc: 'SALES',
        taxAc: 'GST',
        roundAc: 'ROF',
        rateUnfix: true,
        totals: { total: 0, taxable: 0, tax: 0, roundOff: 0 },
      }),
    ).toEqual([]);
    expect(
      buildSaleFineLedger({
        key,
        acCode: 'CUST',
        rateUnfix: true,
        lines: [{ metal: 'G', saleAc: 'GOLD_SALE', fine: 10.1234 }],
      }),
    ).toEqual([
      expect.objectContaining({
        AC_CODE: 'CUST',
        LD_CODE: 'GOLD_SALE',
        IT_TYPE: 'G',
        SIGN: '-',
        FINE_WT: 10.123,
        DR_AMT: 0,
        CR_AMT: 0,
      }),
    ]);
  });
});

describe('per-group income allocation (GROUP_MAST.SALE_AC)', () => {
  const sum = (legs: { amount: number }[]) =>
    Math.round(legs.reduce((s, l) => s + l.amount, 0) * 100) / 100;
  it('single account → one leg = taxable', () => {
    const legs = buildIncomeLegs(
      [
        { net: 1000, ac: 'SALES' },
        { net: 500, ac: 'SALES' },
      ],
      1500,
      1500,
    );
    expect(legs).toEqual([{ ac: 'SALES', amount: 1500 }]);
  });
  it('multi-group splits proportional, Σ == taxable exactly', () => {
    const legs = buildIncomeLegs(
      [
        { net: 1000, ac: 'GOLD_SALE' },
        { net: 500, ac: 'SILVER_SALE' },
      ],
      1500,
      1500,
    );
    expect(legs.length).toBe(2);
    expect(sum(legs)).toBe(1500);
  });
  it('discounted taxable still sums exactly (rounding remainder absorbed)', () => {
    // net 1500, discount 100 ⇒ taxable 1400 split across 3 odd groups
    const legs = buildIncomeLegs(
      [
        { net: 333.33, ac: 'A' },
        { net: 333.33, ac: 'B' },
        { net: 833.34, ac: 'C' },
      ],
      1400,
      1500,
    );
    expect(sum(legs)).toBe(1400);
    expect(legs.length).toBe(3);
  });
});
