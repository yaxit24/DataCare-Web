import { describe, expect, it } from 'vitest';
import {
  wholesaleSaleBillHtml,
  type WholesaleBillBand,
} from '../src/modules/sales/wholesaleSaleBill.js';

/**
 * WhSalesBill (TR_WH_SALE.cs:13654-13800, report-specs/WhSalesBill.spec.json): the title is the book's name
 * (`@RptTitle`), the lines print in an "Issue Item" and a "Received Item" group with the group's gross weight, and the
 * band has four columns (Purchase Fine, Sales Fine, Purchase Amt, Sales Amt) whose cells are the report's formulas.
 */
const band: WholesaleBillBand = {
  FINE_RATE: 6500,
  CR_FINE: 1,
  DR_FINE: 9.2,
  KSR_FINE_CR: 0.1,
  KSR_FINE_DR: 0.2,
  TOT_FINE_CR: 5,
  TOT_FINE_DR: 12,
  CR_AMT: 6500,
  DR_AMT: 59800,
  PR_LBR_AMT: 100,
  SL_LBR_AMT: 2375,
  PR_NET_AMT: 7000,
  SL_NET_AMT: 62175,
  PR_CASH_AMT: 500,
  SL_CASH_AMT: 50000,
  PR_CARD_AMT: 0,
  SL_CARD_AMT: 1000,
  PR_CHQ_AMT: 0,
  SL_CHQ_AMT: 2000,
  PR_KASAR_AMT: 0,
  SL_KASAR_AMT: 40,
  PR_BILL_OS: 500,
  SL_BILL_OS: 9135,
};
const voucher = {
  voucherNo: '00007',
  vchDate: '2026-07-15',
  billNo: 'B-17',
  acName: 'Wholesale Customer',
  vchDesc: 'First lot',
  lines: [
    { itemName: 'Gold Chain', tagNo: 'T1', pcs: 1, grossWt: 10, netWt: 10, fine: 9.16 },
    { itemName: 'Gold Ring', pcs: 2, grossWt: 5.5, netWt: 5, fine: 4.58 },
  ],
  receivedLines: [{ itemName: 'Old Gold', pcs: 1, grossWt: 3, netWt: 3, fine: 2.7 }],
};
const text = (html: string): string =>
  html
    .replace(/<style>[\s\S]*?<\/style>/g, '')
    .replace(/<[^>]+>/g, '|')
    .replace(/\s*\|[\s|]*/g, '|');

describe('WhSalesBill print', () => {
  const html = wholesaleSaleBillHtml(voucher, band, {
    party: { AC_NAME: 'Wholesale Customer', AC_MOBILE: '9876543210', AC_GSTNO: '24ABCDE1234F1Z5' },
    bookName: 'WH SALES',
    balances: {
      opening: { amount: 0, gold: 1.5, silver: 0 },
      closing: { amount: -250, gold: -2, silver: 0.25 },
    },
  });

  it('is titled with the book name and carries the report constants and the party block', () => {
    expect(html).toContain('<title>WH SALES</title>');
    expect(html).toContain('Ref No');
    expect(html).toContain('B-17');
    expect(html).toContain('ESTIMATE');
    expect(html).toContain('Mo : 9876543210');
    expect(html).toContain('Gst No : 24ABCDE1234F1Z5');
  });

  it('prints an Issue Item group and a Received Item group with a running serial and the gross weight of each', () => {
    const flat = text(html);
    expect(flat).toMatch(/Issue Item\|1\|Gold Chain/);
    expect(flat).toMatch(/\|2\|Gold Ring/);
    expect(flat).toMatch(/Received Item\|3\|Old Gold/);
    expect(flat).toContain('|15.500|'); // 10.000 + 5.500 issued
    expect(flat).toContain('|3.000|'); // received gross
  });

  it('prints the four-column band with the report formulas', () => {
    const flat = text(html);
    expect(flat).toContain('Purchase Fine|Sales Fine|Purchase Amt|Sales Amt');
    // @RecFine 5 - (0.1 + 1) = 3.9, @IsuFine 12 - (0.2 + 9.2) = 2.6, @PurcAmt 7000 - 6500, @SlAmt 62175 - 59800.
    expect(flat).toContain('Isu / Rec Fine :|3.900|2.600|500.00|2,375.00');
    expect(flat).toContain('Rate Cut Rate : 6,500.00|1.000|9.200|6,500.00|59,800.00');
    expect(flat).toContain('Kasar Fine|0.100|0.200');
    // @CrTot CR_AMT + PR_LBR_AMT, @DrTot DR_AMT + SL_LBR_AMT.
    expect(flat).toContain('Bill Total :|5.000|12.000|6,600.00|62,175.00');
    expect(flat).toContain('Cash Amount :|500.00|50,000.00');
    expect(flat).toContain('Card Amount :|0.00|1,000.00');
    expect(flat).toContain('Chq Amount :|0.00|2,000.00');
    expect(flat).toContain('Kasar Amount :|0.00|40.00');
    // @TotRecFine, @TotIsuFine = TOT_FINE_DR - TOT_FINE_CR.
    expect(flat).toContain('Bill Oustanding :|5.000|7.000|500.00|9,135.00');
  });

  it('labels gold and silver Cr when above zero and Dr otherwise, and money Dr for a debit balance', () => {
    const flat = text(html);
    expect(flat).toContain('Oppning Bal :|0.00|Dr');
    expect(flat).toContain('Closing Bal :|250.00|Cr'); // a credit balance (debit minus credit is -250)
    expect(flat).toContain('OppningGold :|1.500|Cr');
    expect(flat).toContain('Closing Gold :|2.000|Dr');
    expect(flat).toContain('Closing Silver :|0.250|Cr');
    expect(flat).toContain('Vch Desc : First lot');
  });
});
