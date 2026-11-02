import { describe, expect, it } from 'vitest';
import {
  OLD_METAL_RATE_TYPE,
  deriveOldMetalRow,
  oldMetalAdvance,
  oldMetalHeader,
  orderOldMetalLedger,
  orderOldMetalOf,
  orderOldMetalRojmel,
  type OrderOldMetalRow,
} from '../src/modules/sales/salesOrderOldMetal.js';

/**
 * G206 old metal on the Sales Order: TR_SALE_ORD CommPassTotal_Old (:4427-4500), BILL_TOTAL (:11345-11368), SL_PR_DETL
 * (:9421-9475) and Order_Ledr legs 07-10 (Ac_Ledr.cs:42-50).
 */
const typed = (row: Partial<Parameters<typeof deriveOldMetalRow>[0]> = {}) => ({
  grossWt: 0,
  otherWt: 0,
  touch: 0,
  fine: 0,
  rateType: 'F',
  rate: 0,
  netAmt: 0,
  ...row,
});
const saved = (row: Partial<OrderOldMetalRow>): OrderOldMetalRow => ({
  srNo: 1,
  itCode: 'GL',
  itName: 'Gold',
  itType: 'G',
  purchaseAc: 'PURCHASE',
  pcs: 1,
  grossWt: 10.5,
  otherWt: 0.5,
  netWt: 10,
  touch: 91.6,
  fine: 9.16,
  rateType: 'F',
  rate: 218,
  netAmt: 2000,
  ...row,
});

describe('deriveOldMetalRow (CommPassTotal_Old)', () => {
  it('net weight is gross minus other weight and fine is net x touch / 100 to three decimals', () => {
    expect(deriveOldMetalRow(typed({ grossWt: 10.5, otherWt: 0.5, touch: 91.6 }))).toMatchObject({
      netWt: 10,
      fine: 9.16,
    });
    // 3.333 x 91.6 / 100 = 3.0530... and the half-up third decimal is kept
    expect(deriveOldMetalRow(typed({ grossWt: 3.333, touch: 91.6 })).fine).toBe(3.053);
  });
  it('with no touch the fine is the typed fine, or the net weight when none was typed', () => {
    expect(deriveOldMetalRow(typed({ grossWt: 20 })).fine).toBe(20);
    expect(deriveOldMetalRow(typed({ grossWt: 20, fine: 18.5 })).fine).toBe(18.5);
  });
  it('a typed amount gives the rate on the rate type basis, whole rupees half to even', () => {
    expect(
      deriveOldMetalRow(typed({ grossWt: 10.5, otherWt: 0.5, touch: 91.6, netAmt: 2000 })),
    ).toMatchObject({ rate: 218, netAmt: 2000 });
    expect(
      deriveOldMetalRow(typed({ grossWt: 50, touch: 80, rateType: 'N', netAmt: 3000 })),
    ).toMatchObject({ rate: 60, netAmt: 3000 });
    // 2500 / 10 = 250 and 125 / 10 = 12.5 rounds to 12 (Math.Round half to even)
    expect(deriveOldMetalRow(typed({ grossWt: 10, touch: 100, netAmt: 125 })).rate).toBe(12);
  });
  it('a typed rate with no amount gives the amount; a rate that already makes the amount is kept', () => {
    expect(deriveOldMetalRow(typed({ grossWt: 5, touch: 100, rate: 400 }))).toMatchObject({
      rate: 400,
      netAmt: 2000,
    });
    expect(
      deriveOldMetalRow(typed({ grossWt: 3, touch: 100, rate: 6123.45, netAmt: 18370 })),
    ).toMatchObject({ rate: 6123.45, netAmt: 18370 });
  });
  it('refuses a rate type other than N or F with the desktop text', () => {
    expect(() => deriveOldMetalRow(typed({ grossWt: 1, rateType: 'X' }))).toThrow(
      OLD_METAL_RATE_TYPE,
    );
    expect(OLD_METAL_RATE_TYPE).toBe('Please Slelect Rate type = N - Net Wise Or F - Fine Wise');
  });
});

describe('orderOldMetalOf and the totals', () => {
  const rows = orderOldMetalOf([
    { itCode: 'GL', pcs: 1, grossWt: 10.5, otherWt: 0.5, touch: 91.6, rateType: 'F', netAmt: 2000 },
    { itCode: '', grossWt: 5 },
    { itCode: 'SV', pcs: 2, grossWt: 20, touch: 100 },
    { itCode: 'SV' },
  ]);
  it('keeps rows with an item code and a net weight or amount, numbered by their grid row', () => {
    expect(rows.map((r) => [r.srNo, r.itCode, r.netWt, r.fine, r.netAmt])).toEqual([
      [1, 'GL', 10, 9.16, 2000],
      [3, 'SV', 20, 20, 0],
    ]);
  });
  it('sums gold by item type G and everything else as silver; the advance takes the amounts only', () => {
    const typedRows = [
      saved({}),
      saved({ srNo: 2, itCode: 'SV', itType: 'S', fine: 40, netAmt: 3000 }),
      saved({ srNo: 3, itCode: 'PL', itType: 'P', fine: 1.5, netAmt: 0 }),
    ];
    expect(oldMetalHeader(typedRows)).toEqual({
      OLD_GL_AMT: 2000,
      OLD_SL_AMT: 3000,
      OLD_GL: 9.16,
      OLD_SL: 41.5,
    });
    expect(oldMetalAdvance(typedRows)).toBe(5000);
  });
  it('refuses a negative weight and more than 50 rows', () => {
    expect(() => orderOldMetalOf([{ itCode: 'GL', grossWt: -1 }])).toThrow(
      /GrWt on old metal line 1/,
    );
    expect(() => orderOldMetalOf(Array.from({ length: 51 }, () => ({})))).toThrow(/at most 50/);
  });
});

describe('Order_Ledr legs 07-10', () => {
  const key = {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2024-2025',
    CO_BOOK: 'S91',
    VCH_NO: '00001',
  };
  const valued = saved({});
  const unvalued = saved({
    srNo: 2,
    itCode: 'SV',
    itType: 'S',
    purchaseAc: 'SLVPURC',
    fine: 20,
    netAmt: 0,
    rate: 0,
  });
  it('posts nothing for a book whose BOOK_INOUT is not I (Ac_Ledr.cs:42-50 joins BOOK_INOUT = I)', () => {
    expect(orderOldMetalLedger(key, 'SORD', 'PARTY', [valued, unvalued], 'O')).toEqual([]);
  });
  it('posts 07/08 for a valued row and 09/10 for fine with no amount, keyed STR(SR_NO) + leg', () => {
    const legs = orderOldMetalLedger(key, 'SORD', 'PARTY', [valued, unvalued], 'I');
    expect(
      legs.map((l) => [
        l.legKeySuffix,
        l.AC_CODE,
        l.LD_CODE,
        l.DR_AMT,
        l.CR_AMT,
        l.SIGN,
        l.FINE_WT,
      ]),
    ).toEqual([
      ['         107', 'PARTY', 'PURCHASE', 0, 2000, '', 0],
      ['         108', 'PURCHASE', 'PARTY', 2000, 0, '', 0],
      ['         209', 'PARTY', 'SLVPURC', 0, 0, '+', 20],
      ['         210', 'SLVPURC', 'PARTY', 0, 0, '-', 20],
    ]);
    expect(legs.map((l) => (l.legKeySuffix as string).length)).toEqual([12, 12, 12, 12]);
    expect(legs.every((l) => l.BILL_NO === '')).toBe(true);
    expect(legs.map((l) => l.PARTY_AC_CODE)).toEqual(['PARTY', '', 'PARTY', '']);
  });
});

describe('Order_Rojmel input', () => {
  it('routes a valued row to type 04 and fine with no amount to type 06', () => {
    expect(
      orderOldMetalRojmel([
        saved({}),
        saved({ srNo: 2, itCode: 'SV', itType: 'S', netAmt: 0, fine: 20 }),
      ]),
    ).toMatchObject([
      {
        lineNo: 1,
        netAmount: 2000,
        metal: 'G',
        fine: 9.16,
        purchaseAc: 'PURCHASE',
        itemCode: 'GL',
      },
      { lineNo: 2, netAmount: 0, metal: 'S', fine: 20 },
    ]);
  });
});
