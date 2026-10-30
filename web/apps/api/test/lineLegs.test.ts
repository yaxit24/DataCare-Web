/**
 * G169: revenue legs of a sale whose lines credit more than one income account.
 *
 * Expected values are derived by hand from the desktop rule, never from the web's output:
 *   - `Ac_Ledr.cs:90` (Sales_Ledr, line path): one revenue row per SL_DETL line, `D.SALE_AC`, `A.NET_AMT`,
 *     keyed `VCH_NO + STR(A.SR_NO) + <code>`; `STR()` right-aligns the number in 10 characters.
 *   - the measured single-account form (book 027 voucher 00001): one 23-character `…03` revenue leg.
 * The amounts below are the feature suite's lines A and B: gold 10 g × 6,123.45 + making 237.50/g × 10 g
 * = 63,609.50 on SALES; silver 50 g × 85.50 = 4,275.00 on SLVSALE; 3% GST on 67,884.50 = 2,036.535 → 2,036.54.
 */
import { describe, expect, it } from 'vitest';
import { ledgerBalance } from '../src/modules/posting/posting.js';
import { buildSaleLedger } from '../src/modules/sales/sales.js';
import { buildPurchaseLedger } from '../src/modules/purchase/purchase.js';
import { buildLineLegs, lineLegKey, sqlStr } from '../src/modules/posting/lineLegs.js';

const GOLD = { net: 63609.5, ac: 'SALES' };
const SILVER = { net: 4275, ac: 'SLVSALE' };
const sum = (legs: Array<{ amount: number }>) =>
  legs.reduce((total, leg) => Math.round((total + leg.amount) * 100) / 100, 0);

describe('buildLineLegs on sale lines (G169)', () => {
  it('one account: one leg for the whole taxable amount, no line number (measured 23-char form)', () => {
    expect(buildLineLegs([GOLD, { net: 4275, ac: 'SALES' }], 67884.5, 67884.5)).toEqual([
      { ac: 'SALES', amount: 67884.5 },
    ]);
  });

  it('two accounts, no discount: one leg per line, each its own line net (A.NET_AMT)', () => {
    expect(buildLineLegs([GOLD, SILVER], 67884.5, 67884.5)).toEqual([
      { ac: 'SALES', amount: 63609.5, srNo: 1 },
      { ac: 'SLVSALE', amount: 4275, srNo: 2 },
    ]);
  });

  it('per LINE, not per account: two gold lines and one silver line give three legs', () => {
    const legs = buildLineLegs(
      [
        { net: 1000, ac: 'SALES' },
        { net: 2000, ac: 'SALES' },
        { net: 500, ac: 'SLVSALE' },
      ],
      3500,
      3500,
    );
    expect(legs).toEqual([
      { ac: 'SALES', amount: 1000, srNo: 1 },
      { ac: 'SALES', amount: 2000, srNo: 2 },
      { ac: 'SLVSALE', amount: 500, srNo: 3 },
    ]);
  });

  it('a bill discount is shared in proportion to line net and the legs sum to taxable exactly', () => {
    // Discount 884.50 → taxable 67,000.00.
    // Gold: 67,000 × 63,609.50 / 67,884.50 = 62,780.7010… → 62,780.70; silver takes the rest, 4,219.30
    // (independently 67,000 × 4,275 / 67,884.50 = 4,219.2990… → 4,219.30, so the remainder costs nothing here).
    const legs = buildLineLegs([GOLD, SILVER], 67000, 67884.5);
    expect(legs).toEqual([
      { ac: 'SALES', amount: 62780.7, srNo: 1 },
      { ac: 'SLVSALE', amount: 4219.3, srNo: 2 },
    ]);
    expect(sum(legs)).toBe(67000);
  });

  it('the rounding remainder lands on the last line with a non-zero net, never on a zero line', () => {
    // Three equal lines sharing 100.00: 33.33 + 33.33 + 33.34, and a trailing zero line stays 0.
    const legs = buildLineLegs(
      [
        { net: 10, ac: 'A' },
        { net: 10, ac: 'B' },
        { net: 10, ac: 'A' },
        { net: 0, ac: 'B' },
      ],
      100,
      30,
    );
    expect(legs.map((leg) => leg.amount)).toEqual([33.33, 33.33, 33.34, 0]);
    expect(legs.map((leg) => leg.srNo)).toEqual([1, 2, 3, 4]);
    expect(sum(legs)).toBe(100);
  });

  it('no lines: no legs (the ledger falls back to its own single-account default)', () => {
    expect(buildLineLegs([], 0, 0)).toEqual([]);
  });
});

describe('lineLegKey (G169, G176)', () => {
  it('a single-account leg keeps the measured leg type', () => {
    expect(lineLegKey({}, 3)).toEqual({ legType: 3 });
  });
  it('a per-line leg carries STR(SR_NO) right-aligned in 10, then the 2-digit code', () => {
    expect(sqlStr(2)).toBe('         2');
    expect(lineLegKey({ srNo: 2 }, 3)).toEqual({ legKeySuffix: '         203' });
    expect(lineLegKey({ srNo: 12 }, 3)).toEqual({ legKeySuffix: '        1203' });
  });
});

describe('buildSaleLedger with a two-account bill (G169)', () => {
  const key = {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2026-2027',
    CO_BOOK: 'SL',
    VCH_NO: '00001',
  };
  const legs = buildLineLegs([GOLD, SILVER], 67884.5, 67884.5);
  const ledger = buildSaleLedger({
    key,
    acCode: 'CUST',
    salesAc: 'SALES',
    taxAc: 'GST',
    roundAc: 'ROUNDOFF',
    totals: { total: 69921.04, taxable: 67884.5, tax: 2036.54, roundOff: 0 },
    incomeLegs: legs,
  });

  it('balances: Dr party 69,921.04 = Cr 63,609.50 + 4,275.00 + 2,036.54', () => {
    const balance = ledgerBalance(ledger);
    expect(balance.balanced).toBe(true);
    expect(balance.dr).toBe(69921.04);
  });

  it('keys each revenue leg by its line and leaves party and tax on their measured codes', () => {
    const shape = ledger.map((line) => ({
      ac: line.AC_CODE,
      cr: line.CR_AMT,
      dr: line.DR_AMT,
      legType: line.legType,
      legKeySuffix: line.legKeySuffix,
    }));
    expect(shape).toEqual([
      { ac: 'CUST', cr: 0, dr: 69921.04, legType: 1, legKeySuffix: undefined },
      { ac: 'SALES', cr: 63609.5, dr: 0, legType: undefined, legKeySuffix: '         103' },
      { ac: 'SLVSALE', cr: 4275, dr: 0, legType: undefined, legKeySuffix: '         203' },
      { ac: 'GST', cr: 2036.54, dr: 0, legType: 4, legKeySuffix: undefined },
    ]);
  });

  it('gives every revenue leg its own key (the pre-G169 code gave both legType 3 and collided)', () => {
    const tails = ledger.filter((line) => line.AC_CODE !== 'CUST' && line.AC_CODE !== 'GST');
    expect(tails.map((line) => line.legKeySuffix)).toEqual(['         103', '         203']);
    expect(tails.every((line) => line.legType === undefined)).toBe(true);
  });
});

/**
 * G176: the purchase mirror, with the feature suite's purchase lines (purchaseInvoice.mjs):
 *   gold   net 20 g, touch 91.6 → fine 18.320 × 6,050 = 110,836.00 + making 150/g × 20 = 3,000.00 → 113,836.00 (PURCHASE)
 *   silver net 100 g, touch 92.5 → fine 92.500 × 80 = 7,400.00 (SLVPURC)
 *   taxable 121,236.00; GST 3% = 3,637.08; total 124,873.08. Purchase codes: party 01, purchase 03, tax 06.
 */
describe('buildPurchaseLedger with a two-group bill (G176)', () => {
  const key = {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2026-2027',
    CO_BOOK: 'PR',
    VCH_NO: '00001',
  };
  const totals = { total: 124873.08, taxable: 121236, tax: 3637.08, roundOff: 0 };
  const shape = (ledger: ReturnType<typeof buildPurchaseLedger>) =>
    ledger.map((line) => [line.AC_CODE, line.DR_AMT, line.CR_AMT, line.legType, line.legKeySuffix]);

  it('posts one expense leg per line, keyed STR(SR_NO)+03, and balances', () => {
    const legs = buildLineLegs(
      [
        { net: 113836, ac: 'PURCHASE' },
        { net: 7400, ac: 'SLVPURC' },
      ],
      121236,
      121236,
    );
    const ledger = buildPurchaseLedger({
      key,
      acCode: 'SUPL',
      purchaseAc: 'PURCHASE',
      taxAc: 'GSTINPUT',
      roundAc: 'ROUNDOFF',
      totals,
      expenseLegs: legs,
    });
    expect(shape(ledger)).toEqual([
      ['SUPL', 0, 124873.08, 1, undefined],
      ['PURCHASE', 113836, 0, undefined, '         103'],
      ['SLVPURC', 7400, 0, undefined, '         203'],
      ['GSTINPUT', 3637.08, 0, 6, undefined],
    ]);
    expect(ledgerBalance(ledger).balanced).toBe(true);
  });

  it('PURC_WITH_LBR = N: the labour leg to slot 4 no longer shares the purchase code with the item leg', () => {
    // Gold primary = 113,836 − 3,000 labour = 110,836; one item account, so its leg keeps the measured code 03.
    const legs = buildLineLegs([{ net: 110836, ac: 'PURCHASE' }], 110836, 110836);
    const ledger = buildPurchaseLedger({
      key,
      acCode: 'SUPL',
      purchaseAc: 'PURCHASE',
      taxAc: 'GSTINPUT',
      roundAc: 'ROUNDOFF',
      totals: { total: 117251.08, taxable: 113836, tax: 3415.08, roundOff: 0 },
      expenseLegs: legs,
      labourLeg: { ac: 'LBREXP', amount: 3000 },
    });
    expect(shape(ledger)).toEqual([
      ['SUPL', 0, 117251.08, 1, undefined],
      ['PURCHASE', 110836, 0, 3, undefined],
      ['LBREXP', 3000, 0, undefined, undefined],
      ['GSTINPUT', 3415.08, 0, 6, undefined],
    ]);
    expect(ledgerBalance(ledger).balanced).toBe(true);
  });
});
