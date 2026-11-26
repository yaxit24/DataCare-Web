import { describe, expect, it } from 'vitest';
import { diffBundles } from '../src/modules/parity/bundleDiff.js';
import type { ParityBundle } from '../src/modules/parity/bundle.js';
// The replay oracle is a JavaScript integration command by design; its pure part exports this test surface.
// @ts-expect-error no declaration file is needed for the CLI module
import * as lib from '../integration/replay/lib.mjs';

/**
 * Desktop replay oracle (integration/replay-desktop.mjs): request rebuild, replay order and normalisation, on SYNTHETIC
 * desktop rows only. Codes, names and amounts below are invented; no real database row is used.
 */

const voucher = (family: string, book: string, tables: Record<string, any[]>, extra = {}) => ({
  family,
  book,
  vchNo: '00007',
  mainBook: family,
  bookSname: '',
  tables,
  ...extra,
});

describe('replay oracle: request rebuild', () => {
  // TR_CONTRA.cs:2762-2866: grid rows 2..n are saved as an LDR_TYPE '0' record and an LDR_TYPE '1' mirror of row 1.
  const contraRows = [
    {
      SR_NO: 1,
      LDR_TYPE: '0',
      CRDR_TYPE: 'CR',
      AC_CODE: 'P2',
      AC_NAME: 'SYN TWO',
      CR_AMT: 300,
      VCH_DATE: '2024-05-02T00:00:00.000Z',
      IT_DESC: 'row two',
    },
    {
      SR_NO: 2,
      LDR_TYPE: '1',
      CRDR_TYPE: 'DR',
      AC_CODE: 'P1',
      AC_NAME: 'SYN ONE',
      DR_AMT: 300,
      VCH_DATE: '2024-05-02T00:00:00.000Z',
      IT_DESC: 'row one',
    },
    {
      SR_NO: 3,
      LDR_TYPE: '0',
      CRDR_TYPE: 'CR',
      AC_CODE: 'P3',
      AC_NAME: 'SYN THREE',
      CR_AMT: 200.5,
      VCH_DATE: '2024-05-02T00:00:00.000Z',
    },
    {
      SR_NO: 4,
      LDR_TYPE: '1',
      CRDR_TYPE: 'DR',
      AC_CODE: 'P1',
      AC_NAME: 'SYN ONE',
      DR_AMT: 200.5,
      VCH_DATE: '2024-05-02T00:00:00.000Z',
      IT_DESC: 'row one',
    },
  ];

  it('rebuilds the contra grid with the mirrored account as row 1 and its amount as the sum', () => {
    const r = lib.contraRequest(voucher('CONTRA', '017', { CONTRA_DATA: contraRows }));
    expect(r).toMatchObject({ method: 'POST', path: '/contra' });
    expect(r.body.vchDate).toBe('2024-05-02');
    expect(r.body.lines).toEqual([
      { crdr: 'DR', acCode: 'P1', acName: 'SYN ONE', itDesc: 'row one', amount: 500.5 },
      { crdr: 'CR', acCode: 'P2', acName: 'SYN TWO', itDesc: 'row two', amount: 300 },
      { crdr: 'CR', acCode: 'P3', acName: 'SYN THREE', amount: 200.5 },
    ]);
  });

  it('rebuilds a fine JV with fine weights, the metal and only the keys the route accepts', () => {
    const rows = contraRows.map((r) => ({
      ...r,
      IT_TYPE: 'S',
      DR_FINE: r.DR_AMT,
      CR_FINE: r.CR_AMT,
      DR_AMT: 0,
      CR_AMT: 0,
    }));
    const r = lib.fineJvRequest(voucher('FINE JV', '078', { CONTRA_DATA: rows }));
    expect(r.path).toBe('/fine-jv');
    expect(Object.keys(r.body).sort()).toEqual(['coBook', 'lines', 'metal', 'vchDate']);
    expect(r.body.metal).toBe('S');
    expect(r.body.lines[0]).toEqual({ crdr: 'DR', acCode: 'P1', itDesc: 'row one', fine: 500.5 });
    for (const line of r.body.lines)
      expect(Object.keys(line).every((k) => ['crdr', 'acCode', 'itDesc', 'fine'].includes(k))).toBe(
        true,
      );
  });

  it('posts a one-line cash receipt as the single form and a narrated or multi-line one as the grid', () => {
    const one = [
      {
        SR_NO: 1,
        AC_CODE: 'C1',
        AC_NAME: 'SYN CUST',
        REC_AMT: 1000,
        KASAR_AMT: 7,
        VCH_DATE: '2024-06-01T00:00:00.000Z',
      },
    ];
    const single = lib.cashRequest(
      voucher('CASH/BANK', '001', { CASH_DATA: one }, { mainBook: 'CASH REC' }),
    );
    expect(single).toMatchObject({ path: '/receipts' });
    expect(single.body).toEqual({
      coBook: '001',
      vchDate: '2024-06-01',
      partyAc: 'C1',
      partyName: 'SYN CUST',
      amount: 1000,
      mode: 'cash',
      kasar: 7,
    });
    // The settlement and kasar accounts are left to BOOK_DETL slots 1 and 2, as Ac_Ledr.cs:565-583 does.
    expect(single.body).not.toHaveProperty('bankAc');
    expect(single.body).not.toHaveProperty('kasarAc');

    const two = [
      {
        SR_NO: 2,
        AC_CODE: 'E2',
        REC_AMT: 50,
        IT_DESC: 'fuel',
        VCH_DATE: '2024-06-01T00:00:00.000Z',
        CHQ_NO: '123456',
      },
      { SR_NO: 1, AC_CODE: 'E1', REC_AMT: 70, VCH_DATE: '2024-06-01T00:00:00.000Z' },
      { SR_NO: 3, AC_CODE: '', REC_AMT: 0 },
    ];
    const multi = lib.cashRequest(
      voucher('CASH/BANK', '012', { CASH_DATA: two }, { mainBook: 'BANK PAY' }),
    );
    expect(multi.path).toBe('/payments/multi');
    expect(multi.body.mode).toBe('cheque');
    expect(multi.body.chqNo).toBe('123456');
    expect(multi.body.lines).toEqual([
      { partyAc: 'E1', amount: 70 },
      { partyAc: 'E2', amount: 50, itDesc: 'fuel' },
    ]);
    expect(() =>
      lib.cashRequest(voucher('CASH/BANK', '099', { CASH_DATA: one }, { mainBook: 'SALES' })),
    ).toThrow(lib.ReplayBuildError);
  });

  it('sends the grid cells the desktop stored: charges, a clearing date other than the voucher date, cheque print name and bank name', () => {
    const date = '2024-06-01T00:00:00.000Z';
    // A one-row bank payment with only the Chq Ac Name box filled stays the single form (the page's single mode).
    const printed = lib.cashRequest(
      voucher(
        'CASH/BANK',
        '012',
        {
          CASH_DATA: [
            {
              SR_NO: 1,
              AC_CODE: 'E1',
              REC_AMT: 100,
              VCH_DATE: date,
              CLR_DATE: date,
              CHQ_PRINT_NAME: 'PAYEE',
            },
          ],
        },
        { mainBook: 'BANK PAY' },
      ),
    );
    expect(printed.path).toBe('/payments');
    expect(printed.body).toMatchObject({ mode: 'bank', chqPrintName: 'PAYEE' });
    expect(printed.body).not.toHaveProperty('clrDate');

    // Bank charges or a different clearing date are Charges / Clearing Dt cells: the grid form (TR_CASH.cs:3022-3042).
    const charged = lib.cashRequest(
      voucher(
        'CASH/BANK',
        '012',
        {
          CASH_DATA: [
            {
              SR_NO: 1,
              AC_CODE: 'E1',
              REC_AMT: 100,
              BANK_CHARGES: 18,
              VCH_DATE: date,
              CLR_DATE: '2024-06-03T00:00:00.000Z',
              BANK_NAME: 'BANK X',
            },
          ],
        },
        { mainBook: 'BANK PAY' },
      ),
    );
    expect(charged.path).toBe('/payments/multi');
    expect(charged.body.lines).toEqual([
      { partyAc: 'E1', amount: 100, bankCharges: 18, clrDate: '2024-06-03', bankName: 'BANK X' },
    ]);
  });

  it('rebuilds a sale from operator inputs only and takes karigar figures from the tag', () => {
    const h = {
      CO_YEAR: '2024-2025',
      LC_CODE: '00',
      AC_CODE: 'C9',
      AC_NAME: 'SYN BUYER',
      VCH_DATE: '2024-07-03T00:00:00.000Z',
      TAX_CODE: '10',
      TAX_PRC: 3,
      AC_GST_TYPE: 'L',
      CASH_AMT: 500,
      KASAR_AMT: 0,
      NET_AMT: 99999,
      TOT_AMT: 99999,
      TAX_AMT: 1,
    };
    const lines = [
      {
        SR_NO: 1,
        IT_CODE: 'GLD',
        IT_TYPE: 'G',
        TAG_NO: 'TG1',
        VCH_SRNO: 1001,
        ITM_PCS: 1,
        ITM_GWT: 10,
        ITM_NWT: 9.5,
        ITM_GHT_WT: 0.25,
        ITM_RATE: 6000,
        LBR_TYPE: 'N',
        LBR_RATE: 500,
        LBR_AMT: 4750,
        ITM_AMT: 1,
        ITM_FINE: 1,
        KR_TOUCH: 1,
        KR_FINE: 1,
        NET_AMT: 1,
      },
      {
        SR_NO: 2,
        IT_CODE: 'SLV',
        IT_TYPE: 'S',
        TAG_NO: 'N',
        ITM_PCS: 1,
        ITM_GWT: 20,
        ITM_NWT: 20,
        ITM_RATE: 80,
        LBR_TYPE: 'N',
        LBR_RATE: 10,
        LBR_AMT: 999,
      },
      {
        SR_NO: 3,
        IT_CODE: 'MISC',
        IT_TYPE: 'O',
        TAG_NO: 'N',
        ITM_PCS: 1,
        LBR_TYPE: 'N',
        LBR_AMT: 120,
      },
    ];
    const tag = {
      ITM_GWT: 10,
      ITM_NWT: 9.5,
      KR_NET_WT: 9.5,
      KR_TOUCH: 92,
      KR_WEST_PRC: 4,
      KR_FINE: 9.12,
      KR_NAME: 'KR',
    };
    const r = lib.saleRequest(voucher('SALES', '029', { SL_DATA: [h], SL_DETL: lines }), {
      tag: (no: string, sr: number) => (no === 'TG1' && sr === 1001 ? tag : undefined),
    });
    expect(r).toMatchObject({ method: 'POST', path: '/sales' });
    expect(r.body).toMatchObject({
      coBook: '029',
      acCode: 'C9',
      vchDate: '2024-07-03',
      taxCode: '10',
      taxRatePct: 3,
      interState: false,
      cashAmt: 500,
    });
    // Desktop-derived figures are never sent.
    for (const k of ['netAmt', 'totAmt', 'taxAmt', 'NET_AMT']) expect(r.body).not.toHaveProperty(k);
    const [a, b, c] = r.body.lines;
    expect(a).toMatchObject({
      itCode: 'GLD',
      tagNo: 'TG1',
      vchSrno: 1001,
      netWt: 9.5,
      ghtWt: 0.25,
      rate: 6000,
      metal: 'G',
      labourType: 'per_gram',
      labourRate: 500,
    });
    expect(a).toMatchObject({ karigarTouch: 92, karigarFine: 9.12, karigarWestPct: 4 });
    for (const k of ['metalAmount', 'fineWt']) expect(a).not.toHaveProperty(k);
    // 20 g x 10 = 200, but 999 was stored: the operator typed the amount.
    expect(b).toMatchObject({ itCode: 'SLV', labourType: 'fixed', labourFixed: 999, metal: 'S' });
    expect(b).not.toHaveProperty('tagNo');
    expect(b).not.toHaveProperty('karigarTouch');
    expect(c).toMatchObject({ itCode: 'MISC', labourType: 'fixed', labourFixed: 120 });
    expect(c).not.toHaveProperty('metal');
  });

  it('tells a computed labour amount from a typed one, ghat included, and sends a typed Tax%', () => {
    const line = (o: Record<string, unknown>) => ({
      SR_NO: 1,
      IT_CODE: 'GLD',
      TAG_NO: 'N',
      ITM_PCS: 1,
      ITM_NWT: 10.65,
      ITM_RATE: 6000,
      LBR_TYPE: 'N',
      ...o,
    });
    const h = { AC_CODE: 'C9', VCH_DATE: '2024-07-03T00:00:00.000Z', TAX_PRC: 3 };
    const send = (o: Record<string, unknown>) =>
      lib.saleRequest(voucher('SALES', '029', { SL_DATA: [h], SL_DETL: [line(o)] })).body.lines[0];
    // (10.65 + 0.3) x 550 = 6022.5 rounds to the stored 6023: computed with ghat (TR_SALE.cs:11084-11127).
    expect(send({ ITM_GHT_WT: 0.3, LBR_RATE: 550, LBR_AMT: 6023 })).toMatchObject({
      labourType: 'per_gram',
      labourRate: 550,
    });
    // 107 x 6.79 = 726.53, which rounds to 727: the stored 726 was typed, so it goes as the amount with its rate.
    expect(send({ ITM_NWT: 107, LBR_RATE: 6.79, LBR_AMT: 726 })).toMatchObject({
      labourType: 'fixed',
      labourFixed: 726,
      labourRate: 6.79,
    });
    expect(send({ TAX_PRC: 3 })).toMatchObject({ taxPct: 3 });
    expect(send({ TAX_PRC: 0 })).not.toHaveProperty('taxPct');
  });

  it('rebuilds a purchase with its stone sub-grid and the sale link of a URD book', () => {
    const h = {
      AC_CODE: 'S1',
      VCH_DATE: '2024-04-11T00:00:00.000Z',
      SL_BILL_NO: '00003',
      SL_BILL_DBCD: '026',
      SL_BILL_LC: '00',
      SL_BILL_YRCD: '2024-2025',
      AC_GST_TYPE: 'L',
    };
    const l = [
      {
        SR_NO: 1,
        IT_CODE: 'OG',
        IT_TYPE: 'G',
        ITM_PCS: 1,
        ITM_GWT: 5,
        ITM_OTH_WT: 0.2,
        ITM_NWT: 4.8,
        ITM_TOUCH: 91.6,
        ITM_WEST_PRC: 0,
        ITM_RATE: 6100,
        LBR_TYPE: 'N',
        ITM_FINE: 4.397,
      },
    ];
    const s = [
      {
        SR_NO: 1,
        ISR_NO: 2,
        IT_CODE: 'DM',
        IT_PCS: 3,
        IT_GWT: 0.1,
        IT_RATE_TYPE: 'P',
        IT_RATE: 50,
        IT_AMT: 150,
      },
    ];
    const r = lib.purchaseRequest(
      voucher('PURCHASE', '043', { PR_DATA: [h], PR_DETL: l, PR_IDTL: s }, { bookSname: 'GLURD' }),
    );
    expect(r.path).toBe('/purchases');
    expect(r.body).toMatchObject({
      urd: true,
      saleBillNo: '00003',
      saleBillBook: '026',
      saleBillYear: '2024-2025',
    });
    expect(r.body.lines[0]).toMatchObject({
      itCode: 'OG',
      lessWt: 0.2,
      netWt: 4.8,
      touch: 91.6,
      rate: 6100,
    });
    expect(r.body.lines[0]).not.toHaveProperty('fineWt');
    expect(r.body.lines[0].stones).toEqual([
      { isrNo: 2, itCode: 'DM', pcs: 3, grossWt: 0.1, rateType: 'P', rate: 50, amount: 150 },
    ]);
  });

  it('rebuilds a sales order from its grid, tenders, old metal and components, typed labour only', () => {
    const h = {
      CO_YEAR: '2024-2025',
      AC_CODE: 'C9',
      AC_NAME: 'SYN CUST',
      VCH_DATE: '2024-05-03T00:00:00.000Z',
      BILL_NO: '',
      TAX_CODE: 'GS',
      TAX_PRC: 0,
      CASH_AMT: 5000,
      CHQ_AMT: 2000,
      BANK_AC: 'B1',
      CHQ_NO: '123',
      SCHM_AMT: 300,
      DEL_DATE: '2024-05-20T00:00:00.000Z',
      NET_AMT: 9999,
      ADV_AMT: 7300,
    };
    const lines = [
      {
        SR_NO: 2,
        OLD_SRNO: 2,
        IT_CODE: 'RNG',
        TAG_NO: 'N',
        ITM_PCS: 1,
        ITM_GWT: 10,
        ITM_NWT: 10,
        ITM_TOUCH: 91.6,
        ITM_RATE: 6000,
        LBR_TYPE: 'N',
        LBR_RATE: 400,
        LBR_AMT: 4000,
        RATE_FIX: 'Y',
        ORD_DEL_DATE: '2024-05-20T00:00:00.000Z',
        KR_NET_WT: 10,
        KR_FINE: 10,
        ITM_FINE: 9.16,
        ITM_AMT: 54960,
      },
      {
        SR_NO: 1,
        OLD_SRNO: 1,
        IT_CODE: 'CHN',
        ITM_PCS: 1,
        ITM_GWT: 5,
        ITM_NWT: 5,
        LBR_TYPE: 'N',
        LBR_RATE: 300,
        LBR_AMT: 1777,
        ORD_DEL_DATE: '2024-06-01T00:00:00.000Z',
      },
    ];
    const comps = [{ SR_NO: 2, ISR_NO: 1, IT_CODE: 'DM', IT_TYPE: 'D', IT_PCS: 2, IT_RATE: 50 }];
    const old = [
      {
        CO_BOOK: '020',
        SR_NO: 1,
        IT_CODE: 'OG',
        ITM_GWT: 3,
        ITM_OTH: 0.5,
        ITM_TOUCH: 80,
        ITM_FINE: 2,
        ITM_RATE_TYPE: 'F',
        ITM_RATE: 6000,
        NET_AMT: 12000,
      },
      { CO_BOOK: '026', SR_NO: 1, IT_CODE: 'XX' },
    ];
    const r = lib.salesOrderRequest(
      voucher('SALES ORDER', '020', {
        SL_ORD_DATA: [h],
        SL_ORD_DETL: lines,
        SL_ORD_IDTL: comps,
        SL_PR_DETL: old,
      }),
    );
    expect(r).toMatchObject({ method: 'POST', path: '/sales-orders' });
    expect(r.body).toMatchObject({
      coBook: '020',
      acCode: 'C9',
      vchDate: '2024-05-03',
      taxCode: 'GS',
      taxRatePct: 0,
      advanceAmount: 5000,
      chequeAmount: 2000,
      bankAc: 'B1',
      chequeNo: '123',
      schemeAmount: 300,
      deliveryDate: '2024-05-20',
    });
    // Computed or defaulted: the bill number (blank), the header totals and the advance are the web's to derive.
    for (const k of ['billNo', 'netAmount', 'cardAmount']) expect(r.body).not.toHaveProperty(k);
    expect(r.body.lines.map((l: any) => l.srNo)).toEqual([1, 2]);
    const [chain, ring] = r.body.lines;
    // 5 g x 300 = 1500, but 1777 was stored: a typed labour amount.
    expect(chain).toMatchObject({
      labourRate: 300,
      labourAmount: 1777,
      orderDeliveryDate: '2024-06-01',
    });
    expect(chain.components).toEqual([]);
    expect(ring).toMatchObject({
      labourRate: 400,
      rateFix: 'Y',
      karigarNetWt: 10,
      karigarFine: 10,
    });
    for (const k of ['labourAmount', 'orderDeliveryDate', 'tagNo', 'oldSrNo', 'fine', 'itemAmount'])
      expect(ring).not.toHaveProperty(k);
    expect(ring.components).toEqual([{ isrNo: 1, itCode: 'DM', itType: 'D', pcs: 2, rate: 50 }]);
    // Only the order book's own old metal row; fine follows the touch and the amount follows the rate.
    expect(r.body.oldMetalRows).toEqual([
      { itCode: 'OG', grossWt: 3, otherWt: 0.5, touch: 80, rateType: 'F', rate: 6000 },
    ]);
  });

  it('sends an old metal amount and fine only where the grid did not compute them', () => {
    expect(
      lib.orderOldMetal({
        IT_CODE: 'OS',
        ITM_GWT: 100,
        ITM_FINE: 70,
        ITM_RATE_TYPE: 'N',
        ITM_RATE: 70,
        NET_AMT: 7100,
      }),
    ).toEqual({ itCode: 'OS', grossWt: 100, fine: 70, rateType: 'N', rate: 70, netAmt: 7100 });
  });

  it('rebuilds a wholesale sale: issue and receive grids, settlement inputs, tenders, formula cells left out', () => {
    const h = {
      CO_YEAR: '2024-2025',
      AC_CODE: 'W1',
      VCH_DATE: '2025-03-12T00:00:00.000Z',
      IT_TYPE: 'G',
      CONV_PRC: 100,
      FINE_RATE: 8900,
      CR_FINE: 11.06,
      DR_AMT: 98434,
      KSR_FINE_CR: 0.004,
      SL_CASH_AMT: 95000,
      SL_KASAR_AMT: 34,
      PR_KASAR_AMT: 200,
      SL_NET_AMT: 98434,
      EMP_CODE: '001',
    };
    const isu = [
      {
        SR_NO: 2,
        IT_CODE: 'FG',
        ITM_REMARK: 'SYN ITEM',
        TAG_NO: 'N',
        ITM_GWT: 75.03,
        ITM_NWT: 75.043,
        TAG_GWT: 75.03,
        TAG_NWT: 75.043,
        ITM_FINE: 75.043,
        RATE_TYPE: 'G',
        LBR_TYPE: '',
        KR_NET_WT: 75.03,
        PR_CODE: 'FN',
      },
      {
        SR_NO: 1,
        IT_CODE: 'OG',
        ITM_GWT: 10,
        ITM_NWT: 10,
        TAG_GWT: 10,
        TAG_NWT: 10,
        ITM_TOUCH: 90,
        LBR_TYPE: 'N',
        LBR_AMT: 150,
      },
    ];
    const rec = [{ SR_NO: 1, IT_CODE: 'FG', ITM_GWT: 10, ITM_NWT: 10, TAG_NWT: 10, OTH_AMT: 1200 }];
    const r = lib.wholesaleSaleRequest(
      voucher('WH SALES', '034', { RATE_CUT_DATA: [h], RATE_CUT_ISU: isu, RATE_CUT_REC: rec }),
    );
    expect(r).toMatchObject({ method: 'POST', path: '/wholesale-sales' });
    expect(r.body).toMatchObject({
      coBook: '034',
      acCode: 'W1',
      itType: 'G',
      convPct: 100,
      fineRate: 8900,
      settleCrFine: 11.06,
      ksrFineCr: 0.004,
      empCode: '001',
      pay: { cash: 95000, kasar: 34 },
      receivedPay: { kasar: 200 },
    });
    // The money legs and totals follow from the fine and the rate.
    for (const k of ['settleDrAmt', 'settleCrAmt', 'billNo']) expect(r.body).not.toHaveProperty(k);
    const [og, fg] = r.body.lines;
    expect(og).toEqual({
      itCode: 'OG',
      grossWt: 10,
      touch: 90,
      lbrType: 'N',
      lbrAmt: 150,
    });
    // Net typed above gross is sent, the tag weights equal to the line's are not, a cleared labour type is kept.
    expect(fg).toMatchObject({ itCode: 'FG', itemName: 'SYN ITEM', netWt: 75.043, lbrType: '' });
    for (const k of ['tagNo', 'tagGrossWt', 'tagNetWt', 'fine', 'krNetWt'])
      expect(fg).not.toHaveProperty(k);
    expect(r.body.receivedLines).toEqual([
      { itCode: 'FG', grossWt: 10, othAmt: 1200, lbrType: '' },
    ]);
    expect(lib.REPLAYABLE.has('WH SALES') && lib.REPLAYABLE.has('SALES ORDER')).toBe(true);
    expect(lib.buildRequest({ ...voucher('WH SALES', '034', { RATE_CUT_DATA: [h] }) }).path).toBe(
      '/wholesale-sales',
    );
  });

  // TR_PURC.cs:7312 computes the Fine cell, :7138-7146 and :7225-7231 let the operator type over it, :13122 saves it.
  it('sends a purchase fine only when the stored cell is not the grid formula (the operator typed it)', () => {
    const base = { ITM_NWT: 2, ITM_TOUCH: 85, ITM_WEST_PRC: 0 };
    // 2 x 85 % = 1.700: computed, so not sent.
    expect(lib.typedFineOf({ ...base, ITM_FINE: 1.7 })).toEqual({});
    // A rounded-up fine was typed.
    expect(lib.typedFineOf({ ...base, ITM_FINE: 1.75 })).toEqual({ fineWt: 1.75 });
    // Wastage and ghat join the touch: (2 + 0.1) x (85 + 5) % = 1.890.
    expect(lib.typedFineOf({ ...base, ITM_GHT_WT: 0.1, ITM_WEST_PRC: 5, ITM_FINE: 1.89 })).toEqual(
      {},
    );
    // No touch or wastage: the cell is net + ghat (TR_PURC.cs:7358).
    expect(lib.typedFineOf({ ITM_NWT: 3, ITM_FINE: 3 })).toEqual({});
    expect(lib.typedFineOf({ ITM_NWT: 3, ITM_FINE: 2.9 })).toEqual({ fineWt: 2.9 });
  });

  it('maps books to families by MAIN_BOOK, with the blank-family URD book replayed as a purchase', () => {
    expect(lib.familyOf({ MAIN_BOOK: 'BANK PAY' })).toBe('CASH/BANK');
    expect(lib.familyOf({ MAIN_BOOK: '', BOOK_SNAME: 'GLURD' })).toBe('PURCHASE');
    expect(lib.familyOf({ MAIN_BOOK: 'MEMB ENTRY' })).toBeNull();
    const books = [
      { CO_BOOK: '001', MAIN_BOOK: 'CASH REC' },
      { CO_BOOK: '026', MAIN_BOOK: 'SALES' },
      { CO_BOOK: '074', MAIN_BOOK: 'MEMB ENTRY' },
    ];
    expect(lib.selectBooks(books, '').map((b: any) => b.CO_BOOK)).toEqual(['001', '026']);
    expect(lib.selectBooks(books, 'sales').map((b: any) => b.CO_BOOK)).toEqual(['026']);
    expect(lib.selectBooks(books, '001').map((b: any) => b.CO_BOOK)).toEqual(['001']);
  });
});

describe('replay oracle: order and numbering', () => {
  it('keeps each book in voucher-number order and merges books by date and entry time', () => {
    const v = (book: string, vchNo: string, vchDate: string, vchTime: string) => ({
      book,
      vchNo,
      vchDate,
      vchTime,
    });
    const order = lib.replayOrder([
      v('A', '00002', '2024-04-01', '2024-04-01T10:00:00Z'), // back-dated, entered after A/00001
      v('A', '00001', '2024-04-03', '2024-04-03T09:00:00Z'),
      v('B', '00001', '2024-04-02', '2024-04-02T09:00:00Z'),
      v('B', '00002', '2024-04-04', '2024-04-04T09:00:00Z'),
    ]);
    expect(order.map((x: any) => `${x.book}/${x.vchNo}`)).toEqual([
      'B/00001',
      'A/00001',
      'A/00002',
      'B/00002',
    ]);
  });

  it('places a throwaway voucher only across a gap, or when forced after a collision', () => {
    expect(lib.placeholderFor('00001', 0)).toBeNull();
    expect(lib.placeholderFor('00005', 4)).toBeNull();
    expect(lib.placeholderFor('00007', 4)).toBe('00006');
    expect(lib.placeholderFor('00005', 4, true)).toBe('00004');
  });
});

describe('replay oracle: normalisation and grouping', () => {
  const table = (columns: string[], rows: unknown[][]) => ({
    columns: columns.map((name) => ({
      name,
      type: /AMT/.test(name) ? 'float' : 'varchar',
      scale: null,
    })),
    rows,
  });

  it('drops only what cannot agree: history tables, web-only tables, clocks, operators and the hidden-number copy', () => {
    const c = {
      caseId: 'x',
      description: '',
      voucher: { book: '001', vchNo: '00001' },
      tables: {
        CASH_DATA: table(
          ['AC_CODE', 'REC_AMT', 'VCH_TIME', 'ADD_USER', 'CLR_DATE'],
          [['C1', 10, 't', 'u', '2024-01-01']],
        ),
        BILL_OS_DATA: table(['BILL_NO', 'BILL_HD_VCH_NO', 'BILL_AMT'], [['00001', '00009', 10]]),
        DELETE_DATA: table(['AC_CODE'], [['C1']]),
        voucher_version: table(['CO_BOOK'], [['001']]),
      },
    };
    const n = lib.normaliseCase(c, new Set(['CASH_DATA', 'BILL_OS_DATA', 'DELETE_DATA']));
    expect(Object.keys(n.tables).sort()).toEqual(['BILL_OS_DATA', 'CASH_DATA']);
    expect(n.tables.CASH_DATA.columns.map((x: any) => x.name)).toEqual([
      'AC_CODE',
      'REC_AMT',
      'CLR_DATE',
    ]);
    expect(n.tables.CASH_DATA.rows).toEqual([['C1', 10, '2024-01-01']]);
    expect(n.tables.BILL_OS_DATA.columns.map((x: any) => x.name)).toEqual(['BILL_NO', 'BILL_AMT']);
    // The input case is not modified.
    expect(c.tables.CASH_DATA.columns).toHaveLength(5);
  });

  it('drops print and scheme staging tables and compares a later-rewritten column at its save-time value', () => {
    const c = {
      caseId: 'y',
      description: '',
      voucher: { book: '020', vchNo: '00001' },
      tables: {
        SL_ORD_DETL: table(['IT_CODE', 'ORD_REC_AMT'], [['RNG', 5000]]),
        RATE_CUT_ISU_REC: table(['IT_CODE'], [['X']]),
        FINE_DATA: table(['AC_CODE'], [['C1']]),
      },
    };
    const known = new Set(['SL_ORD_DETL', 'RATE_CUT_ISU_REC', 'FINE_DATA']);
    const d = lib.normaliseCase(c, known, 'desktop');
    expect(Object.keys(d.tables)).toEqual(['SL_ORD_DETL']);
    expect(d.tables.SL_ORD_DETL.rows).toEqual([['RNG', 0]]);
    // The web side is compared as written.
    expect(lib.normaliseCase(c, known, 'web').tables.SL_ORD_DETL.rows).toEqual([['RNG', 5000]]);
  });

  it('marks a named column of a known build difference, and only that column', () => {
    const g = (family: string, table: string, column: string, kind = 'value') => ({
      family,
      table,
      column,
      kind,
    });
    expect(lib.buildDifferenceOf(g('SALES ORDER', 'SL_ORD_DETL', 'TAG_NO'))).toMatch(/:9208-9215/);
    expect(lib.buildDifferenceOf(g('SALES ORDER', 'SL_ORD_DETL', 'ITM_FINE'))).toBeUndefined();
    // The fine rounding is a build difference only within 0.005.
    expect(
      lib.buildDifferenceOf(g('WH SALES', 'RATE_CUT_ISU', 'ITM_FINE', 'value-within-tolerance')),
    ).toMatch(/0\.000/);
    expect(lib.buildDifferenceOf(g('WH SALES', 'RATE_CUT_ISU', 'ITM_FINE'))).toBeUndefined();
    expect(lib.buildDifferenceOf(g('WH SALES', 'RATE_CUT_ISU', 'ITM_AMT'))).toBeUndefined();
    // The scheme row 05 only: an unpaired row of any other key stays a defect.
    expect(
      lib.buildDifferenceOf(g('SALES ORDER', 'ROJ_MEL_DATA', '*', 'row-count (known rows)')),
    ).toMatch(/:19/);
    expect(
      lib.buildDifferenceOf(g('SALES ORDER', 'ROJ_MEL_DATA', '*', 'row-count')),
    ).toBeUndefined();
  });

  it('groups a scheme row 05 and a small fine rounding apart, and anything else as a defect', () => {
    const tbl = (table: string, extra: Record<string, unknown>) => ({
      table,
      presentOn: 'both',
      desktopRows: 1,
      webRows: 1,
      missingRows: [],
      extraRows: [],
      missingColumns: [],
      differences: [],
      ...extra,
    });
    const report = {
      cases: [
        {
          caseId: 'o1',
          tables: [
            tbl('ROJ_MEL_DATA', {
              webRows: 2,
              extraRows: ['LEDR_KEY=01002024-202502000001' + '05'],
            }),
          ],
        },
        {
          caseId: 'o2',
          tables: [
            tbl('ROJ_MEL_DATA', {
              desktopRows: 2,
              missingRows: ['LEDR_KEY=01002024-202502000002' + '01'],
            }),
          ],
        },
        {
          caseId: 'w1',
          tables: [
            tbl('RATE_CUT_ISU', {
              differences: [
                { column: 'ITM_FINE', rowKey: 'k', desktop: '54.480', web: '54.483' },
                { column: 'ITM_FINE', rowKey: 'k2', desktop: '54.480', web: '54.500' },
              ],
            }),
          ],
        },
      ],
    };
    const fam: Record<string, string> = { o1: 'SALES ORDER', o2: 'SALES ORDER', w1: 'WH SALES' };
    const groups = lib.groupDifferences(report, (id: string) => fam[id]);
    const by = (kind: string) => groups.find((x: any) => x.kind === kind);
    expect(by('row-count (known rows)').buildDifference).toMatch(/row 05/);
    expect(by('row-count').buildDifference).toBeUndefined();
    expect(by('value-within-tolerance').buildDifference).toMatch(/2 decimals/);
    expect(by('value').buildDifference).toBeUndefined();
  });

  it('pairs rows that share a declared key by content, whatever order each database returned them in', () => {
    const leg = (key: string, fine: number) => ['P1', 0, 0, key, fine];
    const ac = (rows: unknown[][]) =>
      table(['AC_CODE', 'DR_AMT', 'CR_AMT', 'LEDR_KEY', 'FINE_WT'], rows);
    const b = (side: 'desktop' | 'web', rows: unknown[][]): ParityBundle => ({
      kind: 'datacare.parity-bundle/1.0',
      side,
      capturedAt: '2026-01-01T00:00:00Z',
      source: { engine: side === 'desktop' ? 'sqlserver' : 'postgres', database: 'synthetic' },
      scope: { coCode: '01' },
      cases: [
        {
          caseId: 'WH SALES:034/00001',
          description: '',
          voucher: { book: '034', vchNo: '00001' },
          tables: { AC_DATA: ac(rows) },
        },
      ],
    });
    const d = diffBundles(
      b('desktop', [leg('k27', 0.004), leg('k29', 10)]),
      b('web', [leg('k29', 10), leg('k27', 0.004)]),
    );
    expect(d.cases[0]!.matched).toBe(true);
  });

  const bundle = (side: 'desktop' | 'web', rows: unknown[][]): ParityBundle => ({
    kind: 'datacare.parity-bundle/1.0',
    side,
    capturedAt: '2026-01-01T00:00:00Z',
    source: { engine: side === 'desktop' ? 'sqlserver' : 'postgres', database: 'synthetic' },
    scope: { coCode: '01' },
    cases: [
      {
        caseId: 'CONTRA:017/00001',
        description: '',
        voucher: { book: '017', vchNo: '00001' },
        tables: {
          CONTRA_DATA: table(['SR_NO', 'AC_CODE', 'AC_NAME', 'BOOK_NAME', 'DR_AMT'], rows),
        },
      },
    ],
  });

  it('pairs contra records by SR_NO, groups identical differences and masks personal values', () => {
    const d = diffBundles(
      bundle('desktop', [
        [1, 'P2', 'SYN PERSON', 'CONTRA', 0],
        [2, 'P1', 'SYN PERSON', 'CONTRA', 300],
      ]),
      bundle('web', [
        [1, 'P2', 'OTHER NAME', 'Contra Entry', 0],
        [2, 'P1', 'SYN PERSON', 'Contra Entry', 300],
      ]),
    );
    const t = d.cases[0]!.tables[0]!;
    expect(t.missingRows).toEqual([]);
    expect(t.differences.map((x) => x.column).sort()).toEqual([
      'AC_NAME',
      'BOOK_NAME',
      'BOOK_NAME',
    ]);
    const groups = lib.groupDifferences(d, () => 'CONTRA');
    const byColumn = Object.fromEntries(groups.map((g: any) => [g.column, g]));
    expect(byColumn.BOOK_NAME).toMatchObject({
      family: 'CONTRA',
      table: 'CONTRA_DATA',
      kind: 'value',
      cases: 1,
    });
    expect(byColumn.BOOK_NAME.examples[0]).toMatchObject({
      desktop: 'CONTRA',
      web: 'Contra Entry',
    });
    expect(byColumn.AC_NAME.examples[0]).toMatchObject({
      desktop: '<text 10ch>',
      web: '<text 10ch>',
    });
    const tally = lib.familyTallies(
      [
        { caseId: 'CONTRA:017/00001', family: 'CONTRA', status: 'REPLAYED' },
        {
          caseId: 'CONTRA:017/00002',
          family: 'CONTRA',
          status: 'REFUSED',
          reason: '400 book 017 voucher 00002 refused 12.5',
        },
      ],
      d,
    );
    expect(tally.CONTRA).toMatchObject({
      vouchers: 2,
      replayed: 1,
      differed: 1,
      matched: 0,
      couldNotReplay: 1,
    });
    expect(Object.keys(tally.CONTRA.reasons)).toEqual(['N book N voucher ##### refused N']);
  });
});

describe('known desktop build differences', () => {
  const head = '01002024-2025026' + '00001';
  const diff = (table: string, column: string, desktop: unknown, web: unknown) =>
    lib.buildDifferenceOf({ family: 'SALES', table, column, desktop, web });
  it('passes a renumbered key only when both builds name the same role on the same line', () => {
    expect(diff('AC_DATA', 'LEDR_KEY', `${head}19`, `${head}25`)).toMatch(/same role cash.party/);
    expect(diff('AC_DATA', 'LEDR_KEY', `${head}03`, `${head}08`)).toMatch(/item.book/);
    expect(diff('AC_DATA', 'LEDR_KEY', `${head}         102`, `${head}         107`)).toMatch(
      /item.line#1/,
    );
    // Colliding codes: data 09 is the bank pair, source 09 the tax leg; data 25 kasar, source 25 cash.
    expect(diff('AC_DATA', 'LEDR_KEY', `${head}09`, `${head}09`)).toBeUndefined();
    expect(diff('AC_DATA', 'LEDR_KEY', `${head}25`, `${head}25`)).toBeUndefined();
    // Same role, different line: a real difference.
    expect(
      diff('AC_DATA', 'LEDR_KEY', `${head}         102`, `${head}         207`),
    ).toBeUndefined();
    expect(diff('MAIN_STOCK', 'SR_NO', 1, 3)).toMatch(/Ac_Stock\.cs:114/);
    expect(diff('MAIN_STOCK', 'SR_NO', 1, 4)).toBeUndefined();
  });

  it('keeps unpaired ledger rows and amount differences as defects', () => {
    const report = {
      cases: [
        {
          caseId: 'SALES:026/00001',
          tables: [
            {
              table: 'AC_DATA',
              presentOn: 'both',
              desktopRows: 3,
              webRows: 4,
              missingRows: [],
              extraRows: ['x'],
              missingColumns: [],
              differences: [
                { column: 'LEDR_KEY', rowKey: 'k', desktop: `${head}04`, web: `${head}09` },
                { column: 'LEDR_KEY', rowKey: 'k2', desktop: `${head}09`, web: `${head}09` },
              ],
            },
          ],
        },
      ],
    };
    const groups = lib.groupDifferences(report as any, () => 'SALES');
    const kinds = groups.map((g: any) => [g.kind, g.cases, Boolean(g.buildDifference)]).sort();
    expect(kinds).toEqual([
      ['build-difference', 1, true],
      ['row-count', 1, false],
      ['value', 1, false],
    ]);
  });
});
