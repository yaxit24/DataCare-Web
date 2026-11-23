import { describe, expect, it } from 'vitest';
import { balanceFormulas, chooseSaleTemplate } from '../src/modules/sales/salePrintChoice.js';
import {
  orderLockKeys,
  resolveSaleTenders,
  settleEditedHeader,
  stonesByLine,
} from '../src/modules/sales/saleResiduals.js';

/** WP-26 unit rules (cases.md ids in the test names); the database cases are in salesInvoiceResiduals.db.test.ts. */
const fail = (msg: string) => new Error(msg);

describe('Sales Invoice print choice (TR_SALE.cs:16482-16507, decision D6)', () => {
  it('sales-invoice.print.template-chosen-file: the chosen file names the template; unknown prints the default', () => {
    expect(chooseSaleTemplate({ coBook: 'SL', file: 'SalesBillA4' })).toMatchObject({
      file: 'SalesBillA4',
      template: 'tax-invoice',
      isDefault: false,
      passBalances: true,
    });
    expect(chooseSaleTemplate({ coBook: 'SL', file: 'SalesBillGst' }).file).toBe('SalesBillGst');
    expect(chooseSaleTemplate({ coBook: 'SL', file: 'NoSuchCrystal' })).toMatchObject({
      isDefault: true,
      title: 'Tax Invoice',
    });
  });

  it('sales-invoice.print.template-huid: HUID wins over the file and passes no balances (:16484, :16503)', () => {
    expect(chooseSaleTemplate({ huid: true, coBook: '099', file: 'SalesBillA4' })).toMatchObject({
      file: 'RtlHuidPrint',
      template: 'huid',
      passBalances: false,
    });
  });

  it('sales-invoice.print.template-quotation-book-099 and entry.quotation-book-099-offers-sales-quotation (:16489)', () => {
    expect(chooseSaleTemplate({ coBook: '099', file: 'SalesBillA4' })).toMatchObject({
      file: 'SalesQuotation',
      template: 'quotation',
      title: 'Quotation',
    });
  });

  it('print.opening-closing-parameters formula text is two decimals (:16505-16506)', () => {
    expect(balanceFormulas({ opAmt: -10000, clAmt: -75517.79 })).toEqual([
      'OpAmt = -10000.00',
      'ClAmt = -75517.79',
    ]);
  });
});

describe('tender rows (D1, D2, G8a)', () => {
  it('sales-invoice.tender.upi-total-is-sum-of-rows: rows with a blank account are ignored (TR_SALE.cs:6862)', () => {
    const out = resolveSaleTenders(
      {
        upiRows: [
          { acCode: 'U1', amount: 1000 },
          { acCode: 'U2', amount: 2500.5 },
          { acCode: '', amount: 99 },
        ],
      },
      fail,
    );
    expect([out.upiAmt, out.upiRows?.length]).toEqual([3500.5, 2]); // 1,000.00 + 2,500.50
  });

  it('refuses a second UPI figure, a duplicate order and a rate type other than N/F', () => {
    expect(() =>
      resolveSaleTenders({ upiRows: [{ acCode: 'U1', amount: 1000 }], upiAmt: 900 }, fail),
    ).toThrow(/upiAmount/);
    expect(() =>
      resolveSaleTenders(
        {
          orders: [
            { ordNo: '7', amount: 1 },
            { ordNo: '00007', amount: 2 },
          ],
        },
        fail,
      ),
    ).toThrow('Duplicate Order No');
    // A different book is a different order (:7324 compares book + number).
    expect(
      resolveSaleTenders(
        {
          orders: [
            { ordNo: '7', amount: 1 },
            { ordNo: '7', ordBook: 'SO2', amount: 2 },
          ],
        },
        fail,
      ).orders,
    ).toHaveLength(2);
    expect(() => resolveSaleTenders({ oldGold: [{ rateType: 'X' }] }, fail)).toThrow(
      'Please Slelect Rate type = N - Net Wise Or F - Fine Wise',
    );
  });

  it('a legacy orderRef becomes one order row', () => {
    expect(resolveSaleTenders({ orderRef: { ordNo: 5, adjustAmt: 100 } }, fail).orders).toEqual([
      { ordNo: 5, amount: 100, ordBook: undefined },
    ]);
  });
});

describe('lossless reopen (decision D8)', () => {
  it('an unchanged header takes every stored column back; a changed one marks RE_TRFR from DATA_TRFR', () => {
    const stored = {
      tenant_id: 't',
      row_id: 1n,
      VCH_TIME: 'x',
      NET_AMT: '100.00',
      DATA_TRFR: 'Y',
      IRN_NO: 'I1',
      ADD1: null,
    };
    const same: Record<string, unknown> = { NET_AMT: 100, DATA_TRFR: 'N', ADD1: '', IRN_NO: null };
    expect(settleEditedHeader(same, stored)).toBe('unchanged');
    expect([same.DATA_TRFR, same.IRN_NO, 'tenant_id' in same]).toEqual(['Y', 'I1', false]);
    const changed: Record<string, unknown> = { NET_AMT: 101, DATA_TRFR: 'N' };
    expect(settleEditedHeader(changed, stored)).toBe('changed');
    expect([changed.DATA_TRFR, changed.RE_TRFR]).toEqual(['N', 'Y']);
  });

  it('stone rows are kept per line; the web tag row is not', () => {
    const byLine = stonesByLine(
      [
        { SR_NO: 1, ISR_NO: 1, TAG_NO: 'T1', IT_CODE: 'GOLD', DM_CODE: '' },
        { SR_NO: 1, ISR_NO: 2, TAG_NO: 'T1', IT_CODE: 'STN', DM_CODE: 'DM1' },
      ],
      [{ srNo: 1, tagNo: 'T1', itCode: 'GOLD' }],
    );
    expect(byLine.get(1)?.map((s) => s.DM_CODE)).toEqual(['DM1']);
  });
});

describe('order lock order (review of #250)', () => {
  it('A,B and B,A give the same sorted, unique lock keys', () => {
    expect(orderLockKeys([{ ordNo: '2' }, { ordNo: '00001' }, { ordNo: 2 }])).toEqual([
      '00001',
      '00002',
    ]);
    expect(orderLockKeys([{ ordNo: '1' }, { ordNo: '2' }])).toEqual(
      orderLockKeys([{ ordNo: '2' }, { ordNo: '1' }]),
    );
  });
  it('refuses negative rows', () => {
    expect(() => resolveSaleTenders({ creditNotes: [{ crntNo: 'C', amount: -1 }] }, fail)).toThrow(
      /cannot be negative/,
    );
  });
});
