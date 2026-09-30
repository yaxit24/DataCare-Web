import { describe, expect, it } from 'vitest';
import {
  wholesaleBand,
  wholesaleGridTotals,
  wholesaleIssueLine,
  wholesaleReceiveLine,
  type WholesaleLineSettings,
} from '../src/wholesaleLine.js';

/**
 * TR_WH_SALE grid arithmetic. Expected values are the desktop expressions evaluated by hand (double arithmetic,
 * `Strings.Format` half-up, `Math.Round` half-to-even), cited per case — never taken from the implementation.
 */
const desktop: WholesaleLineSettings = { labourIncludesGhat: true, companyLabourType: 'G' };

describe('issued-line fine (TR_WH_SALE.cs:9436-9660)', () => {
  it('reproduces the tag fines of Next23 034/4 and 034/6', () => {
    // (12.300 + 0) × (92 + 5) / 100 = 11.931; 13.000 → 12.610; at wastage 4: 11.520 and 13.440.
    const at = (netWt: number, westPct: number) =>
      wholesaleIssueLine({ netWt, touch: 92, westPct }, desktop).fine;
    expect([at(12.3, 5), at(13, 5), at(12, 4), at(14, 4)]).toEqual([11.931, 12.61, 11.52, 13.44]);
  });

  it('takes less weight off and adds hallmark fine (cols 24 and 25)', () => {
    // gross 12 − other 2 = net 10; ghat 10% = 1.000; (10 + 1) × (90 + 1) / 100 − 0.125 + 0.75 = 10.635.
    const line = wholesaleIssueLine(
      {
        grossWt: 12,
        othWt: 2,
        ghtPct: 10,
        touch: 90,
        westPct: 1,
        lessWt: 0.125,
        hallmarkFine: 0.75,
      },
      desktop,
    );
    expect(line).toMatchObject({ netWt: 10, ghtWt: 1, fine: 10.635 });
  });

  it('with no purity the fine is the weight itself: net + ghat − less + hallmark (:9500)', () => {
    expect(wholesaleIssueLine({ netWt: 24 }, desktop).fine).toBe(24);
    expect(wholesaleIssueLine({ netWt: 5, lessWt: 0.2, hallmarkFine: 0.1 }, desktop).fine).toBe(
      4.9,
    );
  });

  it('keeps a weightless line at fine 0 unless a hallmark fine is entered', () => {
    expect(wholesaleIssueLine({ netWt: 0, touch: 92 }, desktop).fine).toBe(0);
    expect(wholesaleIssueLine({ netWt: 0, touch: 92, hallmarkFine: 0.25 }, desktop).fine).toBe(
      0.25,
    );
  });

  it('keeps a tag’s stored fine, until a hallmark fine forces the formula (:10697, :9540)', () => {
    expect(wholesaleIssueLine({ netWt: 10, touch: 92, fine: 9.123 }, desktop).fine).toBe(9.123);
    expect(
      wholesaleIssueLine({ netWt: 10, touch: 92, fine: 9.123, hallmarkFine: 0.5 }, desktop).fine,
    ).toBe(9.7);
  });
});

describe('issued-line rate, amounts and other fine', () => {
  it('a conversion decides the rate: Math.Round(ConRate / Con% × 100, 2) (:9591)', () => {
    // 7001 / 90.25 × 100 = 7757.3407… → 7757.34
    expect(wholesaleIssueLine({ convRate: 7001, convPct: 90.25, rate: 7000 }, desktop).rate).toBe(
      7757.34,
    );
    expect(wholesaleIssueLine({ convRate: 7100, rate: 7000 }, desktop).rate).toBe(7100);
    expect(wholesaleIssueLine({ rate: 7000 }, desktop).rate).toBe(7000);
  });

  it('prices by rate type, in the desktop operand order (:9690-9716)', () => {
    // '1': 10.635 × (7757.34 / 10) = 8249.93… → 8250
    const perTen = wholesaleIssueLine(
      {
        grossWt: 12,
        othWt: 2,
        ghtPct: 10,
        touch: 90,
        westPct: 1,
        lessWt: 0.125,
        hallmarkFine: 0.75,
        convRate: 7001,
        convPct: 90.25,
        rateType: '1',
      },
      desktop,
    );
    expect(perTen.itemAmount).toBe(8250);
    expect(wholesaleIssueLine({ netWt: 2.5, touch: 82, rate: 7300 }, desktop).itemAmount).toBe(
      14965,
    );
    expect(wholesaleIssueLine({ netWt: 1, rate: 7300000, rateType: 'K' }, desktop).itemAmount).toBe(
      7300,
    );
    expect(wholesaleIssueLine({ pcs: 3, rate: 50, rateType: 'P' }, desktop).itemAmount).toBe(150);
  });

  it('rounds money half-to-even, as Math.Round does', () => {
    // 2 pcs × 1.25 = 2.5 → 2; 0.5 g × 5 = 2.5 → 2; 3 × 2.5 = 7.5 → 8.
    expect(wholesaleIssueLine({ pcs: 2, rate: 1.25, rateType: 'P' }, desktop).itemAmount).toBe(2);
    expect(wholesaleIssueLine({ netWt: 0.5, rate: 5 }, desktop).itemAmount).toBe(2);
    expect(wholesaleIssueLine({ pcs: 3, rate: 2.5, rateType: 'P' }, desktop).itemAmount).toBe(8);
  });

  it('computes labour from its rate and basis (:9760-9800)', () => {
    const base = { pcs: 2, grossWt: 12, othWt: 2, ghtPct: 10, lbrRate: 37 };
    // P: 2 × 37 = 74; gross: 12 × 37 = 444; N with ghat: 11 × 37 = 407; N without: 10 × 37 = 370.
    expect(wholesaleIssueLine({ ...base, lbrType: 'P' }, desktop).labourAmount).toBe(74);
    expect(wholesaleIssueLine({ ...base, lbrType: 'G' }, desktop).labourAmount).toBe(444);
    expect(wholesaleIssueLine({ ...base, lbrType: '' }, desktop).labourAmount).toBe(444);
    expect(wholesaleIssueLine({ ...base, lbrType: 'N' }, desktop).labourAmount).toBe(407);
    expect(
      wholesaleIssueLine({ ...base, lbrType: 'N' }, { ...desktop, labourIncludesGhat: false })
        .labourAmount,
    ).toBe(370);
    // K: company LBR_TYPE G → 12 × (37000 / 1000) = 444; otherwise 11 × 37 = 407.
    expect(
      wholesaleIssueLine({ ...base, lbrType: 'K', lbrRate: 37000 }, desktop).labourAmount,
    ).toBe(444);
    expect(
      wholesaleIssueLine(
        { ...base, lbrType: 'K', lbrRate: 37000 },
        { ...desktop, companyLabourType: 'N' },
      ).labourAmount,
    ).toBe(407);
  });

  it('keeps a typed labour amount when there is no labour rate', () => {
    expect(wholesaleIssueLine({ netWt: 5, lbrType: 'N', lbrAmt: 250 }, desktop).labourAmount).toBe(
      250,
    );
  });

  it('turns other charges quoted per metal unit into fine (col 39) and keeps MRP out of the net', () => {
    // '1': 22 × 10 / 11 = 20.000; per gram 25 / 9 = 2.778 (Math.Round(…, 3)).
    const quoted = wholesaleIssueLine(
      { netWt: 1, othAmt: 22, otherRate: 11, rateType: '1' },
      desktop,
    );
    expect(quoted).toMatchObject({ otherFine: 20, otherAmountInFine: 22 });
    expect(wholesaleIssueLine({ netWt: 1, othAmt: 25, otherRate: 9 }, desktop).otherFine).toBe(
      2.778,
    );
    // Col 41 = labour + other + item amount; MRP does not override it on a gold/silver voucher (:9834).
    const net = wholesaleIssueLine(
      { netWt: 1, touch: 100, rate: 100, othAmt: 50, lbrAmt: 25 },
      desktop,
    );
    expect(net).toMatchObject({ itemAmount: 100, netAmount: 175, totalAmount: 0 });
  });
});

describe('received line (TR_WH_SALE.cs:6857-7040)', () => {
  it('takes less touch off the purity and backs tax out of the net', () => {
    // net 4, ghat 20% = 0.8; 4.8 × (80 + 2 − 0.25) / 100 = 3.924.
    const line = wholesaleReceiveLine(
      {
        pcs: 2,
        grossWt: 5,
        othWt: 1,
        ghtPct: 20,
        touch: 80,
        westPct: 2,
        lessTouch: 0.25,
        convRate: 6001,
        convPct: 80.75,
        lbrType: 'G',
        lbrRate: 12,
        othAmt: 25,
        otherRate: 9,
        taxPct: 5,
      },
      desktop,
    );
    // rate 6001 / 80.75 × 100 = 7431.58; 3.924 × 7431.58 = 29161.52 → 29162; labour 5 × 12 = 60;
    // total 60 + 25 + 29162 = 29247; net Math.Round(29247 / 105 × 100) = 27854; other fine 25 / 9 = 2.778.
    expect(line).toMatchObject({
      netWt: 4,
      ghtWt: 0.8,
      fine: 3.924,
      rate: 7431.58,
      itemAmount: 29162,
      labourAmount: 60,
      totalAmount: 29247,
      netAmount: 27854,
      otherFine: 2.778,
    });
  });

  it('with no purity the fine is net + ghat; a weightless line with purity has none', () => {
    expect(wholesaleReceiveLine({ netWt: 24 }, desktop).fine).toBe(24);
    expect(wholesaleReceiveLine({ netWt: 20, touch: 100 }, desktop).fine).toBe(20);
    expect(wholesaleReceiveLine({ netWt: 0, touch: 91 }, desktop).fine).toBe(0);
  });

  it('takes the ghat as a typed weight: the receive grid has no ghat % (col 11, :6875)', () => {
    // (4 + 0.8) × (80 + 2 − 0.25) / 100 = 3.924 — the same fine as ghat 20 % of net 4, typed as 0.800 g.
    const typed = wholesaleReceiveLine(
      { netWt: 4, ghtWt: 0.8, touch: 80, westPct: 2, lessTouch: 0.25 },
      desktop,
    );
    expect(typed).toMatchObject({ ghtWt: 0.8, fine: 3.924 });
    // A weight given beside a percent wins: a reopened line carries only ITM_GHT_WT.
    expect(
      wholesaleIssueLine({ netWt: 10, ghtPct: 5, ghtWt: 1, touch: 100 }, desktop),
    ).toMatchObject({ ghtWt: 1, fine: 11 });
  });
});

describe('settlement band (MSG2_TOTAL, BILL_TOTAL :15633-15667)', () => {
  const none = { fine: 0, netAmount: 0 };

  it('V2 034/5: 0.541 cut at 6500 is Received net 3517, owed by the party', () => {
    const band = wholesaleBand({
      settlement: { drAmt: 3517, crFine: 0.541 },
      issued: none,
      received: { fine: 24, netAmount: 0 },
    });
    // Net [1,4] = Math.Round(3517 + 0) = 3517; Os = 3517; Tot fine Cr = 24 + 0.541; Os fine = 0 − 24.541;
    // Payment Os 0 < Received Os 3517, so the label reads "3517.00 Rec".
    expect(band).toEqual({
      receivedNet: 3517,
      receivedOs: 3517,
      paymentNet: 0,
      paymentOs: 0,
      totFineDr: 0,
      totFineCr: 24.541,
      osFine: -24.541,
      diffAmount: 3517,
      diffSide: 'Rec',
    });
  });

  it('Live24 064/00004: Payment net 14965 less cash 15800 and kasar 15 leaves Os −850', () => {
    const band = wholesaleBand({
      settlement: { crAmt: 14965 },
      issued: none,
      received: none,
      paymentTender: { cash: 15800, kasar: 15 },
    });
    // [7,3] = 14965 − 15800 − 0 − 0 − 15 = −850 (the stored PR_BILL_OS); −850 < 0, so "850.00 Rec".
    expect(band).toMatchObject({
      paymentNet: 14965,
      paymentOs: -850,
      diffAmount: 850,
      diffSide: 'Rec',
    });
  });

  it('rounds the net half-to-even (Math.Round) and keeps paise in the tender (Format "0.00")', () => {
    const at = (netAmount: number, cash = 0) =>
      wholesaleBand({
        settlement: {},
        issued: { fine: 0, netAmount },
        received: none,
        receivedTender: { cash },
      });
    expect([at(1000.5).receivedNet, at(1001.5).receivedNet]).toEqual([1000, 1002]);
    expect(at(1000, 100.5).receivedOs).toBe(899.5);
    // Equal outstandings: the label is blank.
    expect(at(0)).toMatchObject({ diffAmount: 0, diffSide: '' });
  });

  it('pays the party when the Payment outstanding is the larger', () => {
    const band = wholesaleBand({
      settlement: { crAmt: 5000, drFine: 0.8 },
      issued: { fine: 1.2, netAmount: 1200 },
      received: none,
      receivedTender: { cash: 200 },
    });
    // Received Os 1200 − 200 = 1000; Payment Os 5000; 5000 > 1000 → "4000.00 Pay"; Tot fine Dr 1.2 + 0.8.
    expect(band).toMatchObject({
      receivedOs: 1000,
      paymentOs: 5000,
      diffAmount: 4000,
      diffSide: 'Pay',
      totFineDr: 2,
      osFine: 2,
    });
  });
});

describe('grid totals (MSG_TOT_FILL / MSG_PR_TOT_FILL)', () => {
  it('counts only unpriced lines in the fine balance, plus every other fine (:8344-8346)', () => {
    const priced = wholesaleIssueLine({ netWt: 2.5, touch: 82, rate: 7300 }, desktop); // 2.050 at 14965
    const loose = wholesaleIssueLine({ netWt: 12.3, touch: 92, westPct: 5 }, desktop); // 11.931, unpriced
    const quoted = wholesaleIssueLine(
      { netWt: 1, touch: 100, othAmt: 22, otherRate: 11, rateType: '1' },
      desktop,
    ); // 1.000 fine + 20.000 other fine, 22 of other charges converted
    const totals = wholesaleGridTotals([priced, loose, quoted]);
    expect(totals).toEqual({
      fine: 32.931, // 11.931 + 1.000 + 20.000 — the priced 2.050 is sold for money instead
      handledFine: 14.981, // 2.050 + 11.931 + 1.000: the metal that leaves stock
      itemAmount: 14965,
      labourAmount: 0,
      otherAmount: 0, // 22 − 22 converted
      netAmount: 14965, // 14965 + 0 + 22 − 22
    });
  });
});
