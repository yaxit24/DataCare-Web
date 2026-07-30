import { describe, expect, it } from 'vitest';
import {
  CUSTOMER_REPAIR_RECEIPT,
  RepairValidationError,
  repairBillTotals,
  repairLineTotals,
} from '../src/modules/repair/repairReceipt.js';

describe('customer repair receipt calculations', () => {
  it('derives net, fine, less-fine, item, labour, and net amount from desktop columns', () => {
    expect(
      repairLineTotals(
        {
          itCode: 'GOLD',
          pcs: 2,
          grossWt: 10,
          otherWt: 1,
          addWt: 10,
          lessWt: 2,
          lessTouch: 50,
          touch: 90,
          wastagePct: 2,
          rate: 100,
          rateType: '1',
          labourType: 'N',
          labourRate: 10,
          otherAmount: 5,
        },
        'KRREP RECEIPT',
      ),
    ).toEqual({
      netWt: 9,
      fineWt: 9.2,
      lessFine: 1,
      itemAmount: 92,
      labourAmount: 110,
      otherAmount: 5,
      netAmount: 207,
    });
  });

  it('uses add weight for CUSTREP ISSUE rates and fine weight for other stages', () => {
    const line = {
      itCode: 'GOLD',
      addWt: 10,
      touch: 90,
      rate: 100,
      rateType: '1',
    };
    expect(repairLineTotals(line, 'CUSTREP ISSUE').itemAmount).toBe(100);
    expect(repairLineTotals(line, 'KRREP RECEIPT').itemAmount).toBe(90);
  });

  it('supports the four source labour bases', () => {
    const base = { itCode: 'GOLD', pcs: 2, grossWt: 10, otherWt: 1, lessWt: 1, labourRate: 100 };
    expect(repairLineTotals({ ...base, labourType: 'P' }).labourAmount).toBe(200);
    expect(repairLineTotals({ ...base, labourType: 'N' }).labourAmount).toBe(1000);
    expect(repairLineTotals({ ...base, labourType: 'K' }).labourAmount).toBe(1);
    expect(repairLineTotals({ ...base, labourType: 'G' }).labourAmount).toBe(1000);
  });

  it('applies labour discount, configured tax rounding, whole total, and tender outstanding', () => {
    expect(
      repairBillTotals(
        [
          { netAmount: 100.4, labourAmount: 50 },
          { netAmount: 49.4, labourAmount: 20 },
        ],
        {
          discountPct: 10,
          taxPct: 3,
          taxDigits: 2,
          chequeAmount: 40,
          cardAmount: 10,
          cashAmount: 50,
        },
      ),
    ).toEqual({
      netAmount: 150,
      discountAmount: 7,
      taxAmount: 4.29,
      totalAmount: 147,
      outstandingAmount: 47,
    });
  });

  it('clears bill outstanding when detail net is zero even if an advance tender is entered', () => {
    expect(
      repairBillTotals([], {
        chequeAmount: 40,
        cardAmount: 10,
        cashAmount: 50,
      }),
    ).toEqual({
      netAmount: 0,
      discountAmount: 0,
      taxAmount: 0,
      totalAmount: 0,
      outstandingAmount: 0,
    });
  });

  it('uses midpoint-to-even whole rounding and rejects invalid monetary input', () => {
    expect(repairBillTotals([{ netAmount: 100.5, labourAmount: 0 }]).netAmount).toBe(100);
    expect(() =>
      repairLineTotals({ itCode: 'GOLD', grossWt: -1 }, CUSTOMER_REPAIR_RECEIPT),
    ).toThrow(RepairValidationError);
  });
});
