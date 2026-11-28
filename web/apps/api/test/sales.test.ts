import { describe, it, expect } from 'vitest';
import {
  buildSaleFineLedger,
  buildSaleLedger,
  buildIncomeLegs,
  computeLine,
} from '../src/modules/sales/sales.js';
import { assertVoucherBalanced, ledgerBalance } from '../src/modules/posting/posting.js';
import {
  SALE_LEG,
  saleRoundingBound,
  saleRoundingResidue,
} from '../src/modules/sales/saleLedger.js';
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
  // Owner decision 1B (2026-11-27): the bill total's rounding is posted nowhere, as on the desktop (Ac_Ledr.cs:159
  // posts only a typed ROF_AMT); the line legs' rounding stays unposted too, and is bounded.
  it("leaves the line legs' rounding unposted, within the bound; a line short of the bill is refused", () => {
    const build = (lineAmount: number) =>
      buildSaleLedger({
        key,
        acCode: 'CUST',
        salesAc: 'SALES',
        taxAc: 'GST',
        roundAc: 'ROF',
        totals: { total: 1180, taxable: 1000, tax: 180, net: 1000 },
        incomeLegs: [{ ac: 'SALES', amount: lineAmount, srNo: 1 }],
      });
    const residue = (lineAmount: number) => ({
      amount: saleRoundingResidue(1180, [{ amount: lineAmount }, { amount: 180 }], 0),
      bound: saleRoundingBound(0, true),
    });
    expect(build(999.6).some((line) => line.legType === 99)).toBe(false);
    expect(residue(999.6).amount).toBe(0.4);
    expect(() => assertVoucherBalanced(build(999.6), residue(999.6))).not.toThrow();
    // A line total 100 short of the bill is far past what rounding can leave.
    expect(() => assertVoucherBalanced(build(900), residue(900))).toThrow(/rounding residue/);
  });
  it('posts no automatic round-off leg: the voucher is off by exactly the bill rounding', () => {
    const lines = buildSaleLedger({
      key,
      acCode: 'CUST',
      salesAc: 'SALES',
      taxAc: 'GST',
      roundAc: 'ROF',
      totals: { total: 1181, taxable: 1000, tax: 180.6 },
    });
    expect(lines.length).toBe(3);
    const b = ledgerBalance(lines);
    expect(Math.round((b.dr - b.cr) * 100) / 100).toBe(0.4);
    const residue = {
      amount: saleRoundingResidue(1181, [{ amount: 1000 }, { amount: 180.6 }], 0),
      bound: 0.5,
    };
    expect(() => assertVoucherBalanced(lines, residue)).not.toThrow();
    // Strict without the writer's residue, and a wrong residue is refused too.
    expect(() => assertVoucherBalanced(lines)).toThrow(/unbalanced/);
    expect(() => assertVoucherBalanced(lines, { amount: 0.3, bound: 0.5 })).toThrow(/unbalanced/);
  });
  it('accepts a half-paisa residue exactly (3-decimal tax under a 2-decimal bill total)', () => {
    // Net 97.09 + tax 2.915 (TAX_ROF 3) = 100.005, a 2-decimal bill of 100.00: the ledger is 0.005 short of the bill.
    const lines = buildSaleLedger({
      key,
      acCode: 'CUST',
      salesAc: 'SALES',
      taxAc: 'GST',
      roundAc: 'ROF',
      totals: { total: 100, taxable: 97.09, tax: 2.915 },
    });
    const amount = saleRoundingResidue(100, [{ amount: 97.09 }, { amount: 2.915 }], 0);
    expect(amount).toBe(-0.005);
    expect(() =>
      assertVoucherBalanced(lines, { amount, bound: saleRoundingBound(2, false) }),
    ).not.toThrow();
    // A paisa is not half a paisa: a wrong residue is still refused.
    expect(() => assertVoucherBalanced(lines, { amount: -0.004, bound: 0.005 })).toThrow(
      /unbalanced/,
    );
    expect(() => assertVoucherBalanced(lines, { amount: 0.005, bound: 0.005 })).toThrow(
      /unbalanced/,
    );
  });
  it('posts a typed round-off as desktop leg 35 on slot 5 (Ac_Ledr.cs:159)', () => {
    const build = (amount: number) =>
      buildSaleLedger({
        key,
        acCode: 'CUST',
        salesAc: 'SALES',
        taxAc: 'GST',
        roundAc: 'ROF',
        totals: { total: 1180, taxable: 1000, tax: 180.4 },
        roundOff: { ac: 'SLOT5', amount },
      });
    const negative = build(-0.4);
    expect(ledgerBalance(negative).balanced).toBe(true);
    expect(negative.find((line) => line.legType === SALE_LEG.roundOff)).toMatchObject({
      legType: 35,
      AC_CODE: 'SLOT5',
      LD_CODE: 'CUST',
      DR_AMT: 0.4,
      CR_AMT: 0,
      SIGN: 'D',
    });
    expect(build(0.6).find((line) => line.legType === 35)).toMatchObject({
      CR_AMT: 0.6,
      DR_AMT: 0,
      SIGN: 'C',
    });
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
