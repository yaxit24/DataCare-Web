import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import {
  calculateECreditNoteBill,
  calculateECreditNoteLine,
  eCreditNoteLabourRateDigits,
  eCreditNoteLineIsSaved,
  eCreditNoteTaxDigits,
  type ECreditNotePolicy,
} from '../src/eCreditNoteCalc.js';

type Vector = {
  id: string;
  input: Record<string, unknown>;
  policy?: Partial<ECreditNotePolicy>;
  expect: Record<string, number>;
};
const fixture = JSON.parse(
  readFileSync(new URL('./fixtures/eCreditNoteCalc.vectors.json', import.meta.url), 'utf8'),
) as {
  basePolicy: ECreditNotePolicy;
  lines: Vector[];
  bills: {
    id: string;
    lineIds: string[];
    tender: Record<string, number>;
    expect: Record<string, number>;
  }[];
};
const lineOf = (vector: Vector) =>
  calculateECreditNoteLine(vector.input, { ...fixture.basePolicy, ...vector.policy });

describe('E CRNT line arithmetic (TR_SL_EBILL CommPassTotal)', () => {
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
    const line = calculateECreditNoteLine({ pcs: 1, mrp: 64116.5, taxPercent: 0 }, policy);
    expect(line.netAmount).toBe(64116);
  });

  it('leaves labour out of the taxable amount when there is no gross weight', () => {
    const line = calculateECreditNoteLine(
      { pcs: 2, rate: 10, rateType: 'P', labourType: 'P', labourRate: 5 },
      fixture.basePolicy,
    );
    expect(line.labourAmount).toBe(10);
    expect(line.taxableAmount).toBe(20);
  });

  it('respects LBR_WITH_GHT=N for net-wise labour', () => {
    const input = { grossWt: 10, ghatPercent: 10, labourType: 'N', labourRate: 100 };
    const withGhat = calculateECreditNoteLine(input, fixture.basePolicy);
    const withoutGhat = calculateECreditNoteLine(input, {
      ...fixture.basePolicy,
      labourIncludesGhat: false,
    });
    expect(withGhat.labourAmount).toBe(1100);
    expect(withoutGhat.labourAmount).toBe(1000);
  });

  it('applies the desktop save predicate', () => {
    const empty = calculateECreditNoteLine({}, fixture.basePolicy);
    expect(eCreditNoteLineIsSaved('', empty)).toBe(false);
    expect(eCreditNoteLineIsSaved('GOLD', empty)).toBe(false);
    const mrpOnly = calculateECreditNoteLine({ mrp: 5 }, fixture.basePolicy);
    expect(eCreditNoteLineIsSaved('GOLD', mrpOnly)).toBe(true);
    const otherOnly = calculateECreditNoteLine({ otherAmount: 5 }, fixture.basePolicy);
    expect(eCreditNoteLineIsSaved('', otherOnly)).toBe(true);
  });

  it('refuses non-finite input rather than computing NaN', () => {
    expect(() => calculateECreditNoteLine({ rate: Number.NaN }, fixture.basePolicy)).toThrow();
  });
});

describe('E CRNT bill totals (TR_SL_EBILL BILL_TOTAL)', () => {
  for (const bill of fixture.bills) {
    it(bill.id, () => {
      const lines = bill.lineIds.map((id) => lineOf(fixture.lines.find((l) => l.id === id)!));
      const result = calculateECreditNoteBill(lines, bill.tender) as unknown as Record<
        string,
        number
      >;
      for (const [key, value] of Object.entries(bill.expect)) {
        expect({ key, value: result[key] }).toEqual({ key, value });
      }
    });
  }

  it('reports no outstanding when the bill has no taxable amount', () => {
    expect(calculateECreditNoteBill([], { cash: 10 }).outstanding).toBe(0);
  });
});

describe('E CRNT company rounding settings (MS_OPNCOMP)', () => {
  it('maps TAX_ROF like MsTaxRof', () => {
    expect(eCreditNoteTaxDigits(null)).toBe(0);
    expect(eCreditNoteTaxDigits('2')).toBe(2);
    expect(eCreditNoteTaxDigits('9')).toBe(2);
    expect(() => eCreditNoteTaxDigits('x')).toThrow();
  });
  it('maps LBR_ROF like MsLbrRof', () => {
    expect(eCreditNoteLabourRateDigits('')).toBe(0);
    expect(eCreditNoteLabourRateDigits(2)).toBe(2);
    expect(eCreditNoteLabourRateDigits(4)).toBe(0);
  });
});
