import { describe, expect, it } from 'vitest';
import { RepairWorkflowValidationError } from '../src/modules/repair/repairWorkflowCommon.js';
import {
  KARIGAR_REPAIR_ISSUE_STAGE,
  KARIGAR_REPAIR_RECEIPT,
  karigarReceiptLabourOtherLegs,
} from '../src/modules/repair/repairKarigarReceipt.js';
import { repairBillTotals, repairLineTotals } from '../src/modules/repair/repairReceipt.js';

describe('karigar repair receipt stage identity', () => {
  it('uses the exact desktop MAIN_BOOK names for its own stage and its source stage', () => {
    expect(KARIGAR_REPAIR_RECEIPT).toBe('KRREP RECEIPT');
    expect(KARIGAR_REPAIR_ISSUE_STAGE).toBe('KRREP ISSUE');
  });
});

describe('karigar repair receipt calculations', () => {
  it('prices the item leg on fine weight derived from add weight, touch, and wastage', () => {
    expect(
      repairLineTotals(
        {
          itCode: 'GOLD',
          pcs: 1,
          grossWt: 10,
          otherWt: 1,
          addWt: 10,
          touch: 90,
          wastagePct: 2,
          rate: 100,
          rateType: '1',
          labourType: 'N',
          labourRate: 10,
          otherAmount: 5,
        },
        KARIGAR_REPAIR_RECEIPT,
      ),
    ).toEqual({
      netWt: 9,
      fineWt: 9.2,
      lessFine: 0,
      itemAmount: 92,
      labourAmount: 90,
      otherAmount: 5,
      netAmount: 187,
    });
  });

  it('applies labour discount, configured tax rounding, and tender outstanding including kasar', () => {
    expect(
      repairBillTotals([{ netAmount: 187, labourAmount: 90 }], {
        discountPct: 10,
        taxPct: 3,
        taxDigits: 0,
        chequeAmount: 50,
        cashAmount: 20,
        kasarAmount: 3,
      }),
    ).toEqual({
      netAmount: 187,
      discountAmount: 9,
      taxAmount: 5,
      totalAmount: 183,
      outstandingAmount: 110,
    });
  });
});

describe('karigar repair receipt labour/other ledger balancing', () => {
  it('nets the labour discount into the configured row-3 debit so double entry balances', () => {
    const result = karigarReceiptLabourOtherLegs({
      totalAmount: 183,
      itemDebitTotal: 92,
      taxAmount: 5,
      rawLabourOther: [95],
    });
    expect(result).toEqual({ legs: [86], target: 86, adjustment: -9 });
    expect(result.legs.reduce((sum, value) => sum + value, 0) + 92 + 5).toBe(183);
  });

  it('distributes the adjusted debit across detail rows and absorbs the remainder deterministically', () => {
    const result = karigarReceiptLabourOtherLegs({
      totalAmount: 100,
      itemDebitTotal: 0,
      taxAmount: 0,
      rawLabourOther: [33.33, 66.67],
    });
    expect(result.target).toBe(100);
    expect(result.legs).toHaveLength(2);
    expect(result.legs.reduce((sum, value) => sum + value, 0)).toBe(100);
    expect(result.legs.every((value) => value >= 0)).toBe(true);
  });

  it('carries an implicit whole-total rounding delta that has no desktop round-off ledger leg', () => {
    // Detail net 100.40 + 49.40 rounds to a whole header net of 150, so the ledger must absorb the
    // 0.20 delta; desktop leaves REP_DATA.ROF_AMT blank and posts no round-off account.
    const totals = repairBillTotals(
      [
        { netAmount: 100.4, labourAmount: 50 },
        { netAmount: 49.4, labourAmount: 20 },
      ],
      { taxPct: 0, taxDigits: 2 },
    );
    expect(totals).toMatchObject({ netAmount: 150, totalAmount: 150, taxAmount: 0 });
    const { legs, adjustment } = karigarReceiptLabourOtherLegs({
      totalAmount: totals.totalAmount,
      itemDebitTotal: 79.8,
      taxAmount: totals.taxAmount,
      rawLabourOther: [50, 20],
    });
    expect(adjustment).toBe(0.2);
    expect(Math.round((legs[0]! + legs[1]! + 79.8) * 100) / 100).toBe(150);
  });

  it('emits no labour legs when the adjusted debit is exactly zero', () => {
    expect(
      karigarReceiptLabourOtherLegs({
        totalAmount: 92,
        itemDebitTotal: 92,
        taxAmount: 0,
        rawLabourOther: [0],
      }),
    ).toEqual({ legs: [0], target: 0, adjustment: 0 });
  });

  it('places a positive adjusted debit on the first row when no raw labour exists', () => {
    expect(
      karigarReceiptLabourOtherLegs({
        totalAmount: 105,
        itemDebitTotal: 100,
        taxAmount: 0,
        rawLabourOther: [0, 0],
      }).legs,
    ).toEqual([5, 0]);
  });

  it('fails closed instead of inventing an account when item and tax exceed the voucher total', () => {
    expect(() =>
      karigarReceiptLabourOtherLegs({
        totalAmount: 100,
        itemDebitTotal: 120,
        taxAmount: 5,
        rawLabourOther: [0],
      }),
    ).toThrow(RepairWorkflowValidationError);
  });

  it('rejects negative raw labour input and a debit with no detail row', () => {
    expect(() =>
      karigarReceiptLabourOtherLegs({
        totalAmount: 10,
        itemDebitTotal: 0,
        taxAmount: 0,
        rawLabourOther: [-1],
      }),
    ).toThrow(RepairWorkflowValidationError);
    expect(() =>
      karigarReceiptLabourOtherLegs({
        totalAmount: 10,
        itemDebitTotal: 0,
        taxAmount: 0,
        rawLabourOther: [],
      }),
    ).toThrow(RepairWorkflowValidationError);
  });
});
