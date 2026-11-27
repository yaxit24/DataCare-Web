/**
 * The sale and purchase day books against Ac_Rojmel.cs (Sales_Rojmel :41-106, Purc_Rojmel :115-177) and the
 * row codes the oracle replay measured on desktop data; every value below is synthetic. LEDR_KEY codes are the
 * DATA's numbering (rojmel.ts ROJMEL_ROW_TYPE, purchaseRojmel.ts PURCHASE_ROJMEL_TYPE), not the source's.
 */
import { describe, expect, it } from 'vitest';
import { buildSaleRojmel, type RojmelContext } from '../src/modules/shared/rojmel.js';
import {
  buildPurchaseRojmel,
  type PurchaseRojmelOptions,
} from '../src/modules/shared/purchaseRojmel.js';

const ctx: RojmelContext = {
  scope: { coCode: '01', lcCode: '00', coYear: '2024-2025' },
  key: { CO_CODE: '01', LC_CODE: '00', CO_YEAR: '2024-2025', CO_BOOK: '901', VCH_NO: '00007' },
  coBook: '901',
  vchNo: '00007',
  vchDate: '2024-04-01',
  vchType: 'SALE',
  bookName: 'SALES',
  partyCode: 'C00001',
  partyName: 'TEST CUSTOMER',
};
const type = (r: { LEDR_KEY: string }) => r.LEDR_KEY.slice(21, 23);
const saleLine = {
  lineNo: 1,
  revenueAc: '00004',
  amount: 10000,
  metal: 'G' as const,
  itemName: 'TEST ITEM',
  itemCode: 'TI',
};

describe('sale day book (Sales_Rojmel)', () => {
  it('names item/party rows, blanks tax, prefixes advance, contra slot 1 (a sale with tax and an order advance)', () => {
    const rows = buildSaleRojmel({ ...ctx, voucherDescription: '' }, [saleLine], {
      partyAccount: '00003',
      partyAmount: 10000,
      taxAc: '00085',
      taxAmount: 300,
      settlements: [{ kind: 'advance', account: '00020', amount: 2000 }],
    });
    expect(rows.map((r) => [type(r), r.AC_CODE, r.LD_CODE, r.AC_NAME])).toEqual([
      ['01', '00004', 'C00001', 'TEST CUSTOMER'],
      ['02', 'C00001', '00003', 'TEST CUSTOMER'], // :52 B.AC_CODE slot 1, not the item's 00004
      ['04', '00085', 'C00001', ''], // :56 tax row has no name
      ['14', '00020', 'C00001', 'OADJ - TEST CUSTOMER'], // :96
    ]);
  });

  it('writes a negative outstanding as the data type 03, credited absolutely (a sale with a negative outstanding)', () => {
    const [, party] = buildSaleRojmel(ctx, [saleLine], {
      partyAmount: -500,
      partyAccount: '00003',
    });
    expect(party).toMatchObject({ CR_AMT: 500, DR_AMT: 0, AC_CODE: 'C00001', LD_CODE: '00003' });
    expect(type(party!)).toBe('03');
    expect(party!.LEDR_KEY).toHaveLength(23);
  });

  it('gives every settlement its name, code and the header narration (:90-:106)', () => {
    const rows = buildSaleRojmel(
      { ...ctx, voucherDescription: 'TEST NARRATION', partyMasterName: 'MASTER NAME' },
      [saleLine],
      {
        partyAccount: '00003',
        partyAmount: 100,
        taxAc: '00085',
        taxAmount: 3,
        settlements: [
          { kind: 'cheque', account: 'B00001', amount: 1500 },
          { kind: 'card', account: 'CARDAC', amount: 500 },
          { kind: 'cardAdjusted', account: 'CARDAC', amount: 490 },
          { kind: 'upi', account: 'UPIAC', amount: 50, lineNo: 2 },
          { kind: 'discount', account: 'DISCAC', amount: 7 },
          { kind: 'kasar', account: '00057', amount: 28 },
          { kind: 'roundOff', account: 'ROUND', amount: -0.1 },
          {
            kind: 'oldMetal',
            account: '00011',
            amount: 1000,
            lineNo: 1,
            description: 'OLD SILVER',
          },
        ],
      },
    );
    expect(rows.slice(1).map((r) => [type(r), r.AC_CODE, r.LD_CODE, r.AC_NAME])).toEqual([
      ['02', 'C00001', '00003', 'TEST CUSTOMER'],
      ['04', '00085', 'C00001', ''],
      ['11', 'B00001', 'C00001', ''],
      ['12', 'CARDAC', 'C00001', ''],
      ['18', 'C00001', 'CARDAC', ''], // :104 names the party in AC_CODE, the card account as contra
      ['19', 'UPIAC', 'C00001', ''],
      ['15', 'DISCAC', 'C00001', 'DISC - TEST CUSTOMER'],
      ['13', '00057', 'C00001', 'KSR - TEST CUSTOMER'],
      ['22', 'C00001', 'ROUND', 'ROF - TEST CUSTOMER'],
      ['16', '00011', 'C00001', 'OLD PURC - MASTER NAME'], // :100 E.AC_NAME
    ]);
    expect(rows[6]!.LEDR_KEY).toBe('01002024-20259010000719         2');
    // Money rows carry VCH_DESC; the old-metal row its SL_PR_DETL.IT_DESC; the item row the item name.
    expect(rows.map((r) => r.IT_DESC)).toEqual([
      'TEST ITEM',
      ...Array(9).fill('TEST NARRATION'),
      'OLD SILVER',
    ]);
    expect(rows.every((r) => r.DR_AMT >= 0 || type(r) === '22')).toBe(true);
  });

  it('leaves the inward (sales return) tax row as it was', () => {
    const rows = buildSaleRojmel(
      ctx,
      [saleLine],
      { partyAmount: 0, taxAc: 'T', taxAmount: 3 },
      false,
    );
    expect(rows.find((r) => r.AC_CODE === 'T')?.AC_NAME).toBe('TEST CUSTOMER');
  });
});

const pctx: RojmelContext = {
  ...ctx,
  key: { ...ctx.key, CO_BOOK: '902', VCH_NO: '00003' },
  coBook: '902',
  vchNo: '00003',
  vchType: 'PURC',
  bookName: 'PURCHASE',
  partyCode: 'S00001',
  partyName: 'TEST SUPPLIER',
  partyMasterName: 'TEST SUPPLIER',
  voucherDescription: '',
};
const options: PurchaseRojmelOptions = {
  withLabour: true,
  partyAccount: '00008',
  kasarAccount: '00042',
  taxAccount: '00085',
  tcsAccount: '00081',
};
const pline = {
  lineNo: 1,
  revenueAc: '00008',
  amount: 120650,
  itemAmount: 120000,
  labourAmount: 600,
  otherAmount: 50,
  netAmount: 120650,
  rate: 6500,
  fine: 18.5,
  metal: 'G' as const,
  itemCode: 'TG',
  itemName: 'TEST GOLD ITEM',
};

describe('purchase day book (Purc_Rojmel)', () => {
  it('writes item, tax DR, TCS CR and cheque CR on the data codes (a purchase with tax, TCS and a cheque)', () => {
    const rows = buildPurchaseRojmel(
      pctx,
      [pline],
      { TAX_AMT: 3619.5, TCS_AMT: 124, CHQ_AMT: 124393.5, BANK_AC: 'B00002', BILL_OS: 0 },
      options,
    );
    expect(
      rows.map((r) => [r.LEDR_KEY, r.AC_CODE, r.LD_CODE, r.DR_AMT, r.CR_AMT, r.AC_NAME]),
    ).toEqual([
      ['01002024-20259020000301         1', '00008', 'S00001', 120650, 0, 'TEST SUPPLIER'], // :119
      ['01002024-20259020000303', '00085', 'S00001', 3619.5, 0, ''], // :136
      ['01002024-20259020000304', '00081', 'S00001', 0, 124, ''], // :138
      ['01002024-20259020000309', 'B00002', 'S00001', 0, 124393.5, ''], // :158
    ]);
    expect(rows[0]).toMatchObject({
      SIGN: '+',
      IT_TYPE: 'G',
      ITM_FINE: 0,
      ITM_AMT: 120000,
      LBR_AMT: 600,
    });
  });

  it('credits the outstanding party on slot 1 as type 08 and books unpriced metal as type 14 (an unpriced labour-only purchase)', () => {
    const rows = buildPurchaseRojmel(
      {
        ...pctx,
        partyCode: 'S00002',
        partyName: 'TEST SUPPLIER TWO',
        partyMasterName: 'TEST SUPPLIER TWO',
      },
      [
        {
          ...pline,
          rate: 0,
          itemAmount: 0,
          labourAmount: 400,
          otherAmount: 0,
          amount: 400,
          touch: 91.6,
          wastage: 2.5,
          fine: 4.9,
          otherFine: 0.1,
        },
      ],
      { BILL_OS: 400, SL_BILL_NO: null },
      options,
    );
    expect(rows.map((r) => [type(r), r.AC_CODE, r.LD_CODE, r.DR_AMT, r.CR_AMT, r.AC_NAME])).toEqual(
      [
        ['01', '00008', 'S00002', 400, 0, 'TEST SUPPLIER TWO'],
        ['08', 'S00002', '00008', 0, 400, 'TEST SUPPLIER TWO'], // :156
        ['14', 'S00002', '00008', 0, 0, 'TEST SUPPLIER TWO'], // :173 ITM_AMT = 0
      ],
    );
    expect(rows[2]).toMatchObject({
      ITM_FINE: 5,
      ITM_TOUCH: 91.6,
      ITM_WEST: 2.5,
      SIGN: '+',
      IT_CODE: 'TG',
    });
  });

  it('credits kasar on slot 3 named KSR (a purchase with kasar)', () => {
    const rows = buildPurchaseRojmel(
      { ...pctx, partyName: 'TEST SUPPLIER THREE' },
      [pline],
      { KASAR_AMT: 35, VCH_DESC: 'x' },
      options,
    );
    expect(rows.at(-1)).toMatchObject({
      AC_CODE: '00042',
      CR_AMT: 35,
      AC_NAME: 'KSR - TEST SUPPLIER THREE',
    });
    expect(type(rows.at(-1)!)).toBe('11');
  });

  it('suppresses a sale-linked party row and splits labour when PURC_WITH_LBR is off (:124/:126)', () => {
    const rows = buildPurchaseRojmel(
      pctx,
      [pline],
      { BILL_OS: 120, SL_BILL_NO: '00005', LBR_AMT: 600, OTH_AMT: 50 },
      { ...options, withLabour: false, labourAccount: '00006' },
    );
    expect(rows.map((r) => [type(r), r.AC_CODE, r.DR_AMT, r.AC_NAME])).toEqual([
      ['01', '00008', 120000, ''],
      ['02', '00006', 650, ''],
    ]);
  });

  it('writes discount and round-off on slot 5 with the desktop sides (:164/:166)', () => {
    const rows = buildPurchaseRojmel(
      pctx,
      [],
      { DISC_AMT: 5, ROF_AMT: 0.4 },
      { ...options, discountAccount: '00041' },
    );
    expect(rows.map((r) => [type(r), r.AC_CODE, r.LD_CODE, r.DR_AMT, r.CR_AMT, r.AC_NAME])).toEqual(
      [
        ['12', '00041', 'S00001', 0, 5, 'DISC - TEST SUPPLIER'],
        ['13', 'S00001', '00041', 0.4, 0, 'ROF - TEST SUPPLIER'],
      ],
    );
    const down = buildPurchaseRojmel(
      pctx,
      [],
      { ROF_AMT: -0.3 },
      { ...options, discountAccount: '00041' },
    );
    expect(down[0]).toMatchObject({ DR_AMT: 0, CR_AMT: 0.3 });
    // A book without slot 5 gets neither row, as `B.SR_NO = 5` drops them.
    expect(buildPurchaseRojmel(pctx, [], { DISC_AMT: 5, ROF_AMT: 0.4 }, options)).toEqual([]);
  });

  it('posts TDS, hallmark and hallmark tax (:140, :151, :153)', () => {
    const rows = buildPurchaseRojmel(
      pctx,
      [],
      { TDS_AMT: 10, HM_AMT: 45, HM_TAX_AMT: 8.1 },
      {
        ...options,
        tdsAccount: 'TDSAC',
        hallmarkTaxAccount: '00085',
        hallmarkTaxName: 'GST INPUT',
      },
    );
    expect(rows.map((r) => [type(r), r.AC_CODE, r.DR_AMT, r.AC_NAME])).toEqual([
      ['05', 'TDSAC', 10, ''],
      ['06', '00097', 45, ''],
      ['07', '00085', 8.1, 'GST INPUT'],
    ]);
  });

  it('selects metal rows on ITM_AMT and ITM_FINE, not on the rate, and adds the silver row (:173/:175)', () => {
    const priced = buildPurchaseRojmel(pctx, [{ ...pline, rate: 0 }], {}, options);
    expect(priced.map(type)).toEqual(['01']);
    const noFine = buildPurchaseRojmel(
      pctx,
      [{ ...pline, itemAmount: 0, labourAmount: 0, otherAmount: 0, fine: 0 }],
      {},
      options,
    );
    expect(noFine).toEqual([]);
    const silver = buildPurchaseRojmel(
      pctx,
      [{ ...pline, itemAmount: 0, rate: 99, silverFine: 2.5 }],
      {},
      options,
    );
    expect(silver.map(type)).toEqual(['01', '14', '15']);
    expect(silver[2]).toMatchObject({
      LD_CODE: '00009',
      IT_TYPE: 'S',
      ITM_GWT: 2.5,
      ITM_TOUCH: 100,
      ITM_FINE: 2.5,
    });
    // RATE_UNFIX = 'Y' outside the UAE writes no metal row.
    expect(
      buildPurchaseRojmel(pctx, [{ ...pline, itemAmount: 0 }], { RATE_UNFIX: 'Y' }, options).map(
        type,
      ),
    ).toEqual(['01']);
  });

  it('keeps a negative outstanding as a signed credit (:156 has no sign split)', () => {
    expect(buildPurchaseRojmel(pctx, [], { BILL_OS: -5 }, options)[0]).toMatchObject({
      CR_AMT: -5,
      DR_AMT: 0,
    });
  });

  it('UAE: B2B PURC splits other/labour and an unfixed bill books its metal (:130/:132/:170)', () => {
    const rows = buildPurchaseRojmel(
      pctx,
      [{ ...pline, fine: 10 }],
      { LBR_AMT: 600, OTH_AMT: 50, RATE_UNFIX: 'Y' },
      { ...options, uae: true, b2b: true, labourAccount: '00006' },
    );
    expect(rows.map((r) => [type(r), r.AC_CODE, r.DR_AMT])).toEqual([
      ['01', '00008', 120000],
      ['16', '00007', 50],
      ['17', '00006', 600],
      ['19', 'S00001', 0],
    ]);
    expect(new Set(rows.map((r) => r.LEDR_KEY)).size).toBe(rows.length);
  });
});
