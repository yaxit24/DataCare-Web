import { describe, expect, it } from 'vitest';
import { labourGstAllocation } from '../src/modules/sales/labourGstAllocation.js';

/** TR_SALE_LBR.cs:9748-9830: the per-line GST shares the Gst Report's HSN section sums (RP_GST.cs:2719). */
describe('labourGstAllocation (TR_SALE_LBR post-save LBR_ISU_DETL update)', () => {
  it('spreads the metal net and tax by NET_AMT and the labour net, tax and discount by LBR_AMT', () => {
    // Two lines: NET_AMT 600 + 400 = 1000 against a metal net of 900 (order gold reduced it); labour 300 + 100 = 400
    // against DR_LBR 400 with a labour discount of 40 and labour tax 18.
    const shares = labourGstAllocation(
      [
        { netAmount: 600, labourAmount: 300 },
        { netAmount: 400, labourAmount: 100 },
      ],
      { metalNet: 900, metalTax: 27, labourNet: 400, labourTax: 18, labourDiscount: 40 },
    );
    // IT_NET_AMT = 600 + 600/1000 * (900 - 1000) = 540; tax = Round(540 * 27 / 900, 2) = 16.2.
    expect(shares[0]).toEqual({
      IT_NET_AMT: 540,
      IT_TAX_AMT: 16.2,
      IT_DISC_AMT: 0,
      IT_LBR_AMT: 300,
      IT_LBR_TAX: 13.5,
      IT_LBR_DISC: 30,
    });
    expect(shares[1]).toEqual({
      IT_NET_AMT: 360,
      IT_TAX_AMT: 10.8,
      IT_DISC_AMT: 0,
      IT_LBR_AMT: 100,
      IT_LBR_TAX: 4.5,
      IT_LBR_DISC: 10,
    });
  });

  it('rounds each share with Math.Round midpoint-to-even', () => {
    // Two equal labour lines whose shares land exactly on a two-decimal midpoint.
    const shares = labourGstAllocation(
      [
        { netAmount: 0, labourAmount: 100 },
        { netAmount: 0, labourAmount: 100 },
      ],
      { metalNet: 0, metalTax: 0, labourNet: 200, labourTax: 0.25, labourDiscount: 0.05 },
    );
    // 100 * 0.25 / 200 = 0.125 -> 0.12 (even), 100 * 0.05 / 200 = 0.025 -> 0.02 (even).
    expect(shares.map((s) => [s.IT_LBR_TAX, s.IT_LBR_DISC])).toEqual([
      [0.12, 0.02],
      [0.12, 0.02],
    ]);
  });

  it('leaves the column defaults (0) when the voucher has no tax or a line has no amount', () => {
    const shares = labourGstAllocation(
      [
        { netAmount: 500, labourAmount: 0 },
        { netAmount: 0, labourAmount: 250 },
      ],
      { metalNet: 500, metalTax: 0, labourNet: 250, labourTax: 12.5, labourDiscount: 0 },
    );
    expect(shares[0]).toEqual({
      IT_NET_AMT: 0,
      IT_TAX_AMT: 0,
      IT_DISC_AMT: 0,
      IT_LBR_AMT: 0,
      IT_LBR_TAX: 0,
      IT_LBR_DISC: 0,
    });
    expect(shares[1]!.IT_LBR_AMT).toBe(250);
    expect(shares[1]!.IT_LBR_TAX).toBe(12.5);
  });
});
