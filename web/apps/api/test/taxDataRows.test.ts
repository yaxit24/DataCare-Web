import { describe, expect, it } from 'vitest';
import { gstTaxRows } from '../src/modules/shared/taxDataRows.js';

/**
 * G90: the main GST rows of TAX_DATA, from the tax code's component rows (Ac_Tax.cs: C.SR_NO = 1/2 for
 * AC_GST_TYPE <> 'I', C.SR_NO = 3 for 'I'; TAX_TYPE = C.TAX_GROUP, TAX_PRC = C.TAX_PRC).
 */
const provisioned = {
  taxGroup: 'N',
  components: new Map([
    [1, { group: 'SGST', ac: null, pct: 1.5 }],
    [2, { group: 'CGST', ac: null, pct: 1.5 }],
    [3, { group: 'IGST', ac: null, pct: 3 }],
  ]),
};
const base = { TRAN_TYPE: 'P', TAX_SIGN: '-', TAX_CODE: '10', NET_AMT: 1000 };

describe('gstTaxRows', () => {
  it('intra-state: SR_NO 1 and 2 from components 1 and 2, each carrying its own half', () => {
    expect(
      gstTaxRows(base, provisioned, {
        interState: false,
        ratePct: 3,
        igst: 0,
        sgst: 15.01,
        cgst: 15,
      }),
    ).toEqual([
      { ...base, SR_NO: 1, TAX_TYPE: 'SGST', TAX_PRC: 1.5, TAX_AMT: 15.01 },
      { ...base, SR_NO: 2, TAX_TYPE: 'CGST', TAX_PRC: 1.5, TAX_AMT: 15 },
    ]);
  });

  it('inter-state: one row at SR_NO 3 from component 3 with the full tax', () => {
    expect(
      gstTaxRows(base, provisioned, { interState: true, ratePct: 3, igst: 30, sgst: 0, cgst: 0 }),
    ).toEqual([{ ...base, SR_NO: 3, TAX_TYPE: 'IGST', TAX_PRC: 3, TAX_AMT: 30 }]);
  });

  it("TAX_PRC is the component's rate, not the voucher's", () => {
    const odd = {
      taxGroup: 'N',
      components: new Map([[3, { group: 'IGST', ac: null, pct: 2.95 }]]),
    };
    expect(
      gstTaxRows(base, odd, { interState: true, ratePct: 3, igst: 30, sgst: 0, cgst: 0 })[0]
        ?.TAX_PRC,
    ).toBe(2.95);
  });

  it('without components the master group stays and the rate splits half-up at 2 decimals', () => {
    const legacy = { taxGroup: 'GST', components: new Map() };
    expect(
      gstTaxRows(base, legacy, {
        interState: false,
        ratePct: 0.25,
        igst: 0,
        sgst: 1.25,
        cgst: 1.25,
      }),
    ).toEqual([
      { ...base, SR_NO: 1, TAX_TYPE: 'GST', TAX_PRC: 0.13, TAX_AMT: 1.25 },
      { ...base, SR_NO: 2, TAX_TYPE: 'GST', TAX_PRC: 0.13, TAX_AMT: 1.25 },
    ]);
    expect(
      gstTaxRows(base, legacy, { interState: true, ratePct: 7, igst: 70, sgst: 0, cgst: 0 }),
    ).toEqual([{ ...base, SR_NO: 3, TAX_TYPE: 'GST', TAX_PRC: 7, TAX_AMT: 70 }]);
  });

  it('numbers a second code (the labour part) at SR_NO 10/20/30 from the same components 1/2/3', () => {
    // LbrWork_GST :170-174: SR_NO 10 from C.SR_NO = 1, 20 from 2, 30 from 3.
    expect(
      gstTaxRows(
        base,
        provisioned,
        { interState: false, ratePct: 3, igst: 0, sgst: 5, cgst: 5 },
        [10, 20, 30],
      ),
    ).toEqual([
      { ...base, SR_NO: 10, TAX_TYPE: 'SGST', TAX_PRC: 1.5, TAX_AMT: 5 },
      { ...base, SR_NO: 20, TAX_TYPE: 'CGST', TAX_PRC: 1.5, TAX_AMT: 5 },
    ]);
    expect(
      gstTaxRows(
        base,
        provisioned,
        { interState: true, ratePct: 3, igst: 10, sgst: 0, cgst: 0 },
        [10, 20, 30],
      ),
    ).toEqual([{ ...base, SR_NO: 30, TAX_TYPE: 'IGST', TAX_PRC: 3, TAX_AMT: 10 }]);
  });

  it('a component with a blank group falls back to the master group, not an empty type', () => {
    const blank = {
      taxGroup: 'GST',
      components: new Map([
        [1, { group: '', ac: null, pct: 1.5 }],
        [2, { group: 'CGST', ac: null, pct: 1.5 }],
      ]),
    };
    expect(
      gstTaxRows(base, blank, { interState: false, ratePct: 3, igst: 0, sgst: 15, cgst: 15 }).map(
        (row) => row.TAX_TYPE,
      ),
    ).toEqual(['GST', 'CGST']);
  });
});
