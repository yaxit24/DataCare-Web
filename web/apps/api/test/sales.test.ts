import { describe, it, expect } from 'vitest';
import {
  buildSaleFineLedger,
  buildSaleLedger,
  buildIncomeLegs,
  computeLine,
} from '../src/modules/sales/sales.js';
import { ledgerBalance } from '../src/modules/posting/posting.js';
import { resolveRoundingPolicy } from '@datacare/core';

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
  // P prices pieces (TR_SALE.cs:10909-10916), not net + ghat; the fixture carries 3 pieces so it can.
  it.each([
    ['F', 900],
    ['G', 1300],
    ['N', 1100],
    ['P', 300],
  ] as const)('computeLine applies SL_AMT_TYPE=%s to metal amount', (type, expected) => {
    const c = computeLine(
      { itCode: 'I1', pcs: 3, grossWt: 12, netWt: 10, ghtWt: 1, fineWt: 9, rate: 100 },
      undefined,
      type,
    );
    expect(c.metal).toBe(expected);
  });
  // Review of PR #241. A typed ITM_AMT is formatted "0.00" (TR_SALE.cs:9478, :9495); only an amount computed from the
  // rate is rounded to the line precision (:10905-10932).
  it('keeps an explicit item amount at 2 dp under a whole-rupee line precision', () => {
    const policy = resolveRoundingPolicy({ ALL_ROF_REMOVE: 'N', TOT_AMT_ROF: '2' });
    const c = computeLine({ itCode: 'I1', pcs: 1, metalAmount: 1000.55 }, policy, 'N');
    expect(c.metal).toBe(1000.55);
    expect(c.net).toBe(1000.55);
  });
  // TR_SALE.cs:10999: LBR_RATE is re-derived only when LBR_PRC changed; a stored or edited rate stands.
  it('a percentage line with a labour rate uses that rate; without one it derives it', () => {
    const policy = resolveRoundingPolicy({ LBR_ROF: '2' });
    const line = {
      itCode: 'I1',
      netWt: 10,
      rate: 100,
      labourType: 'percentage' as const,
      labourPct: 10,
    };
    const typed = computeLine({ ...line, labourRate: 50 }, policy, 'N', false, { basis: 'N' });
    expect([typed.labour, typed.labourRate]).toEqual([500, 50]);
    const derived = computeLine(line, policy, 'N', false, { basis: 'N' });
    expect([derived.labour, derived.labourRate]).toEqual([100, 10]);
  });
  // Final review of PR #241: the Sale derives ghat weight from Ghat % as its grid does (TR_SALE.cs:10581).
  it('a Sale line with Ghat % only derives the ghat weight: gross 10, 2 %, rate 6000, making 500', () => {
    const policy = resolveRoundingPolicy({});
    const c = computeLine(
      {
        itCode: 'I1',
        pcs: 1,
        grossWt: 10,
        netWt: 10,
        touch: 91.6,
        ghtPct: 2,
        rate: 6000,
        labourType: 'per_gram',
        labourRate: 500,
      },
      policy,
      'N',
      true,
      { rule: 'sale' },
    );
    expect([c.metal, c.labour]).toEqual([61200, 5100]);
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
  it('refuses a round-off leg past the rounding bound: line legs that do not add up to the bill', () => {
    const build = (lineAmount: number) =>
      buildSaleLedger({
        key,
        acCode: 'CUST',
        salesAc: 'SALES',
        taxAc: 'GST',
        roundAc: 'ROF',
        totals: { total: 1180, taxable: 1000, tax: 180, roundOff: 0, net: 1000 },
        incomeLegs: [{ ac: 'SALES', amount: lineAmount, srNo: 1 }],
        maxRoundOffResidue: 2.01,
      });
    // Paise of rounding is carried by the round-off leg...
    expect(ledgerBalance(build(999.6)).balanced).toBe(true);
    // ...a line total 100 short of the bill is refused rather than hidden in the round-off leg.
    expect(() => build(900)).toThrow(/does not agree with the bill total/);
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
      payments: { cash: { ac: 'CASH', amount: 200 } },
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
