import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import {
  calculateEBillTotals,
  calculateEBillLine,
  eBillLabourRateDigits,
  eBillLineIsSaved,
  eBillTaxDigits,
  eInvoiceTcs,
  type EBillPolicy,
  type EInvoiceTcsInput,
} from '../src/eBillCalc.js';

type Vector = {
  id: string;
  input: Record<string, unknown>;
  policy?: Partial<EBillPolicy>;
  expect: Record<string, number>;
};
const fixture = JSON.parse(
  readFileSync(new URL('./fixtures/eBillCalc.vectors.json', import.meta.url), 'utf8'),
) as {
  basePolicy: EBillPolicy;
  lines: Vector[];
  bills: {
    id: string;
    lineIds: string[];
    tender: Record<string, number>;
    expect: Record<string, number>;
  }[];
  tcs: { id: string; input: EInvoiceTcsInput; expect: Record<string, unknown> }[];
};
const lineOf = (vector: Vector) =>
  calculateEBillLine(vector.input, { ...fixture.basePolicy, ...vector.policy });

describe('E-bill line arithmetic (TR_SL_EBILL CommPassTotal)', () => {
  for (const vector of fixture.lines) {
    it(vector.id, () => {
      const result = lineOf(vector) as unknown as Record<string, number>;
      for (const [key, value] of Object.entries(vector.expect)) {
        expect({ key, value: result[key] }).toEqual({ key, value });
      }
    });
  }

  it('rounds the whole-rupee line net half-to-even, not half-up', () => {
    // 64117.5 → 64118 (even) and 64116.5 → 64116 (even); half-up would give 64117.
    const policy = fixture.basePolicy;
    const line = calculateEBillLine({ pcs: 1, mrp: 64116.5, taxPercent: 0 }, policy);
    expect(line.netAmount).toBe(64116);
  });

  it('leaves labour out of the taxable amount when there is no gross weight', () => {
    const line = calculateEBillLine(
      { pcs: 2, rate: 10, rateType: 'P', labourType: 'P', labourRate: 5 },
      fixture.basePolicy,
    );
    expect(line.labourAmount).toBe(10);
    expect(line.taxableAmount).toBe(20);
  });

  it('respects LBR_WITH_GHT=N for net-wise labour', () => {
    const input = { grossWt: 10, ghatPercent: 10, labourType: 'N', labourRate: 100 };
    const withGhat = calculateEBillLine(input, fixture.basePolicy);
    const withoutGhat = calculateEBillLine(input, {
      ...fixture.basePolicy,
      labourIncludesGhat: false,
    });
    expect(withGhat.labourAmount).toBe(1100);
    expect(withoutGhat.labourAmount).toBe(1000);
  });

  it('applies the desktop save predicate', () => {
    const empty = calculateEBillLine({}, fixture.basePolicy);
    expect(eBillLineIsSaved('', empty)).toBe(false);
    expect(eBillLineIsSaved('GOLD', empty)).toBe(false);
    const mrpOnly = calculateEBillLine({ mrp: 5 }, fixture.basePolicy);
    expect(eBillLineIsSaved('GOLD', mrpOnly)).toBe(true);
    const otherOnly = calculateEBillLine({ otherAmount: 5 }, fixture.basePolicy);
    expect(eBillLineIsSaved('', otherOnly)).toBe(true);
  });

  it('refuses non-finite input rather than computing NaN', () => {
    expect(() => calculateEBillLine({ rate: Number.NaN }, fixture.basePolicy)).toThrow();
  });
});

describe('E-bill totals (TR_SL_EBILL BILL_TOTAL)', () => {
  for (const bill of fixture.bills) {
    it(bill.id, () => {
      const lines = bill.lineIds.map((id) => lineOf(fixture.lines.find((l) => l.id === id)!));
      const result = calculateEBillTotals(lines, bill.tender) as unknown as Record<string, number>;
      for (const [key, value] of Object.entries(bill.expect)) {
        expect({ key, value: result[key] }).toEqual({ key, value });
      }
    });
  }

  it('reports no outstanding when the bill has no taxable amount', () => {
    expect(calculateEBillTotals([], { cash: 10 }).outstanding).toBe(0);
  });
});

describe('E-bill company rounding settings (MS_OPNCOMP)', () => {
  it('maps TAX_ROF like MsTaxRof', () => {
    expect(eBillTaxDigits(null)).toBe(0);
    expect(eBillTaxDigits('2')).toBe(2);
    expect(eBillTaxDigits('9')).toBe(2);
    expect(() => eBillTaxDigits('x')).toThrow();
  });
  it('maps LBR_ROF like MsLbrRof', () => {
    expect(eBillLabourRateDigits('')).toBe(0);
    expect(eBillLabourRateDigits(2)).toBe(2);
    expect(eBillLabourRateDigits(4)).toBe(0);
  });
});

describe('E INVOICE TCS (TR_SL_EBILL BILL_TOTAL 9074-9127)', () => {
  for (const vector of fixture.tcs) {
    it(vector.id, () => {
      expect(eInvoiceTcs(vector.input)).toEqual(vector.expect);
    });
  }
  it('fails closed when the threshold is crossed without a TAX_MAST code 20', () => {
    expect(() => eInvoiceTcs({ ...fixture.tcs[0]!.input, thresholdPercent: null })).toThrow(
      'TAX_MAST code 20',
    );
  });
});
