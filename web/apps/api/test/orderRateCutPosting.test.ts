import { describe, expect, it } from 'vitest';
import { assertVoucherBalanced, UnbalancedError } from '../src/modules/posting/posting.js';
import {
  orderTenderOf,
  TOUR_CASH_BELOW_ZERO,
  tourCashColumn,
} from '../src/modules/sales/salesOrderTender.js';
import {
  isOrderRateCutLedgerRow,
  orderRateCutAmount,
  orderRateCutLedger,
  withOrderRateCutRojmel,
} from '../src/modules/sales/salesOrderRateCutPosting.js';

/** Ac_Ledr.cs:53 and Ac_Rojmel.cs:23: the order rate-cut rows, and the one leg the balance check leaves out. */
const key = { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024-2025', CO_BOOK: '320', VCH_NO: '00007' };
const header = {
  ...key,
  VCH_DATE: new Date('2024-07-10T00:00:00Z'),
  VCH_TIME: new Date('2024-07-10T11:22:33Z'),
  AC_CODE: 'PARTY',
  AC_NAME: 'Customer',
  VCH_DESC: 'Note',
  HD_VCH_NO: '00003',
  MAIN_USER: 'clerk',
  ADV_AMT: 0,
  CASH_AMT: 1000,
  CARD_AMT: 300,
  CHQ_AMT: 500,
  OLD_GL_AMT: 2000.5,
  OLD_SL_AMT: 40,
  SCHM_AMT: 20,
  UPI_AMT: 999, // not part of the rate-cut amount
  RCUT_RATE: 6000,
  RCUT_FINE: 0.6431,
};
// Order Booking, the desktop's own Sales Order book, is BOOK_INOUT 'I' (MS_UPDATE.cs:31987).
const book = { mainBook: 'SALES ORDER', vchType: 'ORDBK', inoutType: 'I', dataType: 'A' };

describe('order rate-cut posting', () => {
  it('builds ledger key 11 with every desktop column (Ac_Ledr.cs:53)', () => {
    expect(orderRateCutAmount(header)).toBe(3860.5);
    const [leg, ...rest] = orderRateCutLedger(key, header, book);
    expect(rest).toEqual([]);
    expect(leg).toMatchObject({
      ...key,
      legType: 11,
      VCH_TYPE: 'ORDBK',
      VCH_DATE: header.VCH_DATE,
      BOOK_NAME: 'SALES ORDER',
      BILL_NO: '',
      BILL_DATE: null,
      CHQ_NO: '',
      AC_CODE: 'PARTY',
      LD_CODE: '00008',
      CR_AMT: 0,
      DR_AMT: 3860.5,
      IT_TYPE: 'G',
      SIGN: '+',
      FINE_WT: 0.643,
      IT_DESC: '',
      ENTRY_TIME: header.VCH_TIME,
      HD_VCH_NO: '00003',
      CLR_DATE: null,
      DATA_TYPE: 'A',
      DATA_TRFR: 'N',
      MAIN_USER: 'clerk',
      FINE_RATE: 0,
      PARTY_AC_CODE: 'PARTY',
      LDR_NAME: '',
    });
  });

  it('writes no key 11 for an O book or a zero RCUT_FINE', () => {
    expect(orderRateCutLedger(key, header, { ...book, inoutType: 'O' })).toEqual([]);
    expect(orderRateCutLedger(key, { ...header, RCUT_FINE: 0 }, book)).toEqual([]);
  });

  it('the balance check leaves out only the marked key-11 leg', () => {
    const leg = orderRateCutLedger(key, header, book);
    const pair = [
      { AC_CODE: 'PARTY', CR_AMT: 1000, DR_AMT: 0 },
      { AC_CODE: 'CASH', CR_AMT: 0, DR_AMT: 1000 },
    ];
    expect(() => assertVoucherBalanced([...pair, ...leg])).not.toThrow();
    // The same debit without the marker is an ordinary unbalanced voucher.
    const { desktopOneSidedOrderRateCut: _marker, ...unmarked } = leg[0]!;
    void _marker;
    expect(() => assertVoucherBalanced([...pair, unmarked])).toThrow(UnbalancedError);
    // A marked leg of any other shape is refused, never exempted.
    for (const change of [
      { legType: 12 },
      { LD_CODE: '00001' },
      { CR_AMT: 5 },
      { BOOK_NAME: 'SALES' },
    ])
      expect(() => assertVoucherBalanced([...pair, { ...leg[0]!, ...change }])).toThrow(
        /order rate-cut leg/,
      );
    // The exemption does not hide an unbalanced tender pair.
    expect(() => assertVoucherBalanced([pair[0]!, ...leg])).toThrow(UnbalancedError);
  });

  it('recognises the saved key-11 row only against 00008', () => {
    expect(
      isOrderRateCutLedgerRow({ LEDR_KEY: '01012024-202532000007' + '11', LD_CODE: '00008' }),
    ).toBe(true);
    expect(
      isOrderRateCutLedgerRow({ LEDR_KEY: '01012024-202532000007' + '11', LD_CODE: 'CASH' }),
    ).toBe(false);
    expect(
      isOrderRateCutLedgerRow({ LEDR_KEY: '01012024-202532000007' + '02', LD_CODE: '00008' }),
    ).toBe(false);
  });

  it('day book: drops type 01 when ADV_AMT is 0 and adds type 07 (Ac_Rojmel.cs:11, :23)', () => {
    const context = {
      scope: { coCode: '01', lcCode: '01', coYear: '2024-2025' },
      key,
      coBook: '320',
      vchNo: '00007',
    };
    const head = '01012024-202532000007';
    const rows = [
      { LEDR_KEY: `${head}01`, CR_AMT: 3860.5 },
      { LEDR_KEY: `${head}02`, DR_AMT: 500 },
    ];
    const out = withOrderRateCutRojmel(rows, context, header, book);
    expect(out.map((row) => row.LEDR_KEY)).toEqual([`${head}02`, `${head}07`]);
    expect(out[1]).toEqual({
      ...key,
      LEDR_KEY: `${head}07`,
      VCH_DATE: header.VCH_DATE,
      VCH_TYPE: 'ORDBK',
      BOOK_NAME: 'SALES ORDER',
      AC_CODE: 'PARTY',
      LD_CODE: '00008',
      CR_AMT: 0,
      DR_AMT: 3860.5,
      AC_NAME: 'Customer',
      IT_TYPE: 'G',
      SIGN: '+',
      ITM_PCS: 0,
      ITM_GWT: 0.643,
      ITM_NWT: 0.643,
      ITM_TOUCH: 0,
      ITM_WEST: 0,
      ITM_FINE: 0.643,
      ITM_RATE: 6000,
      ITM_AMT: 0,
      LBR_RATE: 0,
      LBR_AMT: 0,
      OTH_AMT: 0,
      NET_AMT: 0,
      IT_DESC: 'Note',
      IT_CODE: '',
      MEMB_CODE: '',
      SCHM_CODE: '',
      REF_NO: '',
      DATA_TYPE: 'A',
    });
    // Without a rate cut ADV_AMT holds the advance: type 01 stays and no type 07 is added.
    expect(
      withOrderRateCutRojmel(rows, context, { ...header, ADV_AMT: 3860.5, RCUT_FINE: 0 }, book),
    ).toEqual(rows);
  });
});

describe('Tour Order CASH_AMT (TR_TOUR_ORD.cs:7309, :9375)', () => {
  const tender = (cash: number) => orderTenderOf({ advanceAmount: cash }, false);
  it('a new order saves its advance as cash; an unchanged edit leaves the saved CASH_AMT', () => {
    expect(tourCashColumn(tender(1000), undefined, undefined)).toEqual({ CASH_AMT: 1000 });
    expect(tourCashColumn(tender(1500), { CASH_AMT: 1000, CHQ_AMT: 500 }, 1500)).toEqual({});
  });
  it('a changed advance moves only the cash tender, never below zero', () => {
    expect(tourCashColumn(tender(1700), { CASH_AMT: 1000, CHQ_AMT: 500 }, 1500)).toEqual({
      CASH_AMT: 1200,
    });
    expect(() => tourCashColumn(tender(400), { CASH_AMT: 0, CHQ_AMT: 500 }, 500)).toThrow(
      TOUR_CASH_BELOW_ZERO,
    );
  });
});
