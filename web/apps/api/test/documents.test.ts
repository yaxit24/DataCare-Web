import { describe, it, expect } from 'vitest';
import { invoiceHtml, rupeesInWords } from '../src/modules/sales/invoice.js';
import { purchaseBillHtml } from '../src/modules/purchase/purchaseBill.js';
import { karigarIssueHtml } from '../src/modules/manufacturing/karigarVoucher.js';
import { customerRepairReceiptHtml } from '../src/modules/repair/repairReceiptDoc.js';
import { karigarRepairIssueHtml } from '../src/modules/repair/repairKarigarIssueDoc.js';
import { karigarRepairReceiptHtml } from '../src/modules/repair/repairKarigarReceiptDoc.js';
import { customerRepairIssueHtml } from '../src/modules/repair/repairCustomerIssueDoc.js';
import { financeVoucherHtml } from '../src/modules/finance/financeVoucher.js';
import { dhrnIssueHtml } from '../src/modules/dhrn/dhrnReceipt.js';
import { dhrnKhataHtml } from '../src/modules/dhrn/dhrnKhata.js';
import { schemePassbookHtml } from '../src/modules/scheme/passbook.js';
import { orderHtml } from '../src/modules/sales/orderDoc.js';
import { gstr1DocHtml } from '../src/modules/gst/gstr1Doc.js';
import {
  gstr2DocHtml,
  gstr3bDocHtml,
  trialBalanceDocHtml,
  balanceSheetDocHtml,
} from '../src/modules/reports/statementDocs.js';
import { groupForColumn } from '../src/modules/masters/master.service.js';

const CO = {
  CO_NAME: 'DHAKAN JEWELLERS',
  CO_GST_NO: '24ABCDE1234F1Z5',
  CO_STATE: 'Gujarat',
  BANK_NAME: 'HDFC',
  BANK_AC_NO: '123',
  BANK_RTGS_NO: 'HDFC01',
};

describe('faithful A4 documents', () => {
  it('sales GST invoice: intra-state shows CGST+SGST, HSN, grand total in words, no IGST', () => {
    const html = invoiceHtml(
      {
        BILL_NO: 'S1',
        VCH_NO: '42',
        CO_BOOK: 'SAL',
        VCH_DATE: '2026-07-02',
        AC_NAME: 'Buyer',
        NET_AMT: 100000,
        CGST_TAX: 1500,
        SGST_TAX: 1500,
        IGST_TAX: 0,
        ROF_AMT: 0,
        TOT_AMT: 103000,
      },
      [
        {
          IT_CODE: 'RING',
          ITM_PCS: 1,
          ITM_GWT: 10.5,
          ITM_NWT: 10,
          ITM_RATE: 6000,
          ITM_AMT: 60000,
          LBR_AMT: 40000,
          ITM_CGST_AMT: 1500,
          ITM_SGST_AMT: 1500,
          HSN_CODE: '7113',
        },
      ],
      {
        company: CO,
        party: { AC_NAME: 'Buyer', AC_GSTNO: '24XYZ', AC_STATE: 'Gujarat' },
        copy: 'ORIGINAL FOR RECIPIENT',
      },
    );
    expect(html).toContain('Tax Invoice');
    expect(html).toContain('24ABCDE1234F1Z5');
    expect(html).toContain('24XYZ');
    expect(html).toContain('7113');
    expect(html).toContain('1,03,000.00');
    expect(html).toContain('CGST');
    expect(html).not.toContain('>IGST<');
    expect(html).toContain('Amount in words');
  });

  it('sales invoice: inter-state shows IGST not CGST row; title override → credit note', () => {
    const inter = invoiceHtml(
      { VCH_NO: '1', CO_BOOK: 'SAL', NET_AMT: 100, IGST_TAX: 3, TOT_AMT: 103 },
      [{ IT_CODE: 'X', ITM_AMT: 100, ITM_IGST_AMT: 3, HSN_CODE: '7108' }],
      { company: CO },
    );
    expect(inter).toContain('>IGST<');
    expect(inter).not.toContain('>CGST<');
    const cn = invoiceHtml(
      { VCH_NO: '1', CO_BOOK: 'SRT', NET_AMT: 100, CGST_TAX: 1.5, SGST_TAX: 1.5, TOT_AMT: 103 },
      [{ IT_CODE: 'X', ITM_AMT: 100, HSN_CODE: '7113' }],
      { company: CO, title: 'Credit Note — Sales Return' },
    );
    expect(cn).toContain('Credit Note — Sales Return');
    expect(cn).not.toContain('Tax Invoice');
  });

  it('purchase bill: supplier + inter-state IGST', () => {
    const html = purchaseBillHtml(
      {
        BILL_NO: 'P1',
        VCH_NO: '7',
        CO_BOOK: 'PUR',
        AC_NAME: 'Vendor',
        ADD1: 'Zaveri Bazaar',
        CITY: 'Mumbai',
        NET_AMT: 200000,
        IGST_TAX: 6000,
        TOT_AMT: 206000,
        SL_BILL_NO: 'V-99',
      },
      [
        {
          IT_CODE: 'BAR',
          ITM_PCS: 2,
          ITM_GWT: 100,
          ITM_NWT: 100,
          ITM_AMT: 200000,
          ITM_IGST_AMT: 6000,
          HSN_CODE: '7108',
        },
      ],
      { company: CO, party: { AC_NAME: 'Vendor', AC_GSTNO: '27PQR', AC_STATE: 'Maharashtra' } },
    );
    expect(html).toContain('Purchase Bill');
    expect(html).toContain('Supplier');
    expect(html).toContain('27PQR');
    expect(html).toContain('2,06,000.00');
    expect(html).toContain('V-99');
  });

  it('karigar issue voucher: fine-weight metal document', () => {
    const html = karigarIssueHtml(
      { VCH_NO: '3', CO_BOOK: 'KIS', AC_NAME: 'Ramesh Smith', TOT_AMT: 0, LBR_AMT: 0 },
      [
        {
          IT_CODE: 'GOLD22',
          DESIGN_NO: 'D5',
          ITM_PCS: 5,
          ITM_GWT: 52,
          ITM_NWT: 50,
          ITM_TOUCH: 91.6,
          ITM_WEST_PRC: 2,
          ITM_FINE: 45.8,
        },
      ],
      { company: CO, party: { AC_NAME: 'Ramesh Smith' } },
    );
    expect(html).toContain('Karigar Issue Voucher');
    expect(html).toContain('Fine Wt');
    expect(html).toContain('45.800');
    expect(html).toContain('Total Fine Weight');
  });

  it('customer repair receipt binds REP_DATA/REP_DETL fields without unsafe markup', () => {
    const html = customerRepairReceiptHtml(
      {
        voucherNo: '00001',
        headerVoucherNo: '00001',
        vchDate: '2024-04-10',
        billNo: 'C-1',
        acCode: 'CUST',
        acName: 'Repair Customer',
        employeeCode: 'E01',
        bankName: '',
        description: '<script>bad()</script>',
        chequeAmount: 20,
        chequeAccount: 'BANK',
        chequeNo: 'CH1',
        cardAmount: 10,
        cardAccount: 'CARD',
        cashAmount: 15,
        totals: {
          netAmount: 95,
          discountAmount: 0,
          taxAmount: 0,
          totalAmount: 95,
          outstandingAmount: 50,
        },
        lines: [
          {
            srNo: 1,
            itCode: 'GOLD',
            itemName: 'Gold Ring',
            itmSize: '12',
            description: 'Resize',
            pcs: 1,
            grossWt: 10,
            otherWt: 1,
            netWt: 9,
            touch: 91.6,
            labourType: 'N',
            labourRate: 10,
            labourAmount: 90,
            otherAmount: 5,
            netAmount: 95,
            fineWt: 0,
            lessFine: 0,
            itemAmount: 0,
            itType: 'G',
            rateType: 'G',
          },
        ],
      },
      { company: CO },
    );
    expect(html).toContain('Repairing Received');
    expect(html).toContain('Gold Ring');
    expect(html).toContain('Outstanding');
    expect(html).toContain('50.00');
    expect(html).toContain('&lt;script&gt;bad()&lt;/script&gt;');
    expect(html).not.toContain('<script>bad()</script>');
  });

  it('karigar repair issue binds source customer rows and escapes unsafe narration', () => {
    const html = karigarRepairIssueHtml(
      {
        voucherNo: '00001',
        headerVoucherNo: '00001',
        vchDate: '2024-04-11',
        billNo: 'K-1',
        acCode: 'KAR',
        acName: 'Repair Karigar',
        employeeCode: 'E01',
        bankName: '',
        description: '<script>bad()</script>',
        chequeAmount: 20,
        chequeAccount: 'BANK',
        chequeNo: 'CH1',
        cardAmount: 10,
        cardAccount: 'CARD',
        cashAmount: 15,
        totals: {
          netAmount: 0,
          discountAmount: 0,
          taxAmount: 0,
          totalAmount: 0,
          outstandingAmount: 0,
        },
        lines: [
          {
            issueSrNo: 1,
            code: '2024-2025/RCR/00001/1',
            name: 'Repair Customer · Gold Ring',
            coYear: '2024-2025',
            coBook: 'RCR',
            voucherNo: '00001',
            srNo: 1,
            headerVoucherNo: '00001',
            vchDate: '2024-04-10',
            customerCode: 'CUST',
            customerName: 'Repair Customer',
            itCode: 'GOLD',
            itemName: 'Gold Ring',
            description: 'Resize',
            itmSize: '12',
            tagNo: '',
            pieces: 1,
            grossWt: 10,
            otherWt: 1,
            netWt: 9,
            touch: 91.6,
            wastagePct: 0,
            fineWt: 0,
          },
        ],
      },
      { company: CO },
    );
    expect(html).toContain('Repairing Issued — Karigar');
    expect(html).toContain('Repair Customer');
    expect(html).toContain('Gold Ring');
    expect(html).toContain('Advance Paid');
    expect(html).toContain('45.00');
    expect(html).toContain('&lt;script&gt;bad()&lt;/script&gt;');
    expect(html).not.toContain('<script>bad()</script>');
  });

  it('karigar repair receipt binds issue linkage, bill totals and escapes unsafe narration', () => {
    const html = karigarRepairReceiptHtml(
      {
        voucherNo: '00001',
        headerVoucherNo: '00001',
        vchDate: '2024-04-12',
        billNo: 'KR-1',
        acCode: 'KAR',
        acName: 'Repair Karigar',
        employeeCode: 'E01',
        bankName: '',
        description: '<script>bad()</script>',
        discountPct: 10,
        taxCode: '01',
        taxPct: 3,
        chequeAmount: 20,
        chequeAccount: 'BANK',
        chequeNo: 'CH1',
        cardAmount: 10,
        cardAccount: 'CARD',
        cashAmount: 15,
        kasarAmount: 1,
        totals: {
          netAmount: 187,
          discountAmount: 9,
          taxAmount: 5,
          totalAmount: 183,
          outstandingAmount: 137,
        },
        lines: [
          {
            receiptSrNo: 1,
            code: '2024-2025/RKI/00001/1',
            name: 'Repair Customer · Gold Ring',
            coYear: '2024-2025',
            coBook: 'RKI',
            voucherNo: '00001',
            srNo: 1,
            headerVoucherNo: '00001',
            vchDate: '2024-04-11',
            karigarCode: 'KAR',
            karigarName: 'Repair Karigar',
            customerCode: 'CUST',
            customerName: 'Repair Customer',
            customerRepairNo: '00001',
            itCode: 'GOLD',
            itemName: 'Gold Ring',
            itType: 'G',
            rateType: '1',
            description: 'Resize',
            itmSize: '12',
            tagNo: '',
            vchSrNo: 0,
            pieces: 1,
            grossWt: 10,
            otherWt: 1,
            netWt: 9,
            touch: 90,
            wastagePct: 2,
            fineWt: 9.2,
            addWt: 10,
            lessWt: 0,
            lessTouch: 0,
            lessFine: 0,
            rate: 100,
            itemAmount: 92,
            labourType: 'N',
            labourRate: 10,
            labourAmount: 90,
            otherAmount: 5,
            netAmount: 187,
          },
        ],
      },
      { company: CO },
    );
    expect(html).toContain('Repairing Received — Karigar');
    expect(html).toContain('Repair Customer');
    expect(html).toContain('Gold Ring');
    expect(html).toContain('Outstanding');
    expect(html).toContain('137.00');
    expect(html).toContain('Kasar');
    expect(html).toContain('&lt;script&gt;bad()&lt;/script&gt;');
    expect(html).not.toContain('<script>bad()</script>');
  });

  it('customer repair delivery binds both source links, bills the customer and escapes narration', () => {
    const html = customerRepairIssueHtml(
      {
        voucherNo: '00001',
        headerVoucherNo: '00001',
        vchDate: '2024-04-13',
        billNo: 'CI-1',
        acCode: 'CUST',
        acName: 'Repair Customer',
        employeeCode: 'E01',
        bankName: '',
        description: '<script>bad()</script>',
        discountPct: 0,
        taxCode: '03',
        taxPct: 3,
        chequeAmount: 0,
        chequeAccount: '',
        chequeNo: '',
        cardAmount: 0,
        cardAccount: '',
        cashAmount: 500,
        kasarAmount: 0,
        totals: {
          netAmount: 1000,
          discountAmount: 0,
          taxAmount: 30,
          totalAmount: 1030,
          outstandingAmount: 530,
        },
        lines: [
          {
            issueSrNo: 1,
            code: '2024-2025/RCR/00001/1',
            name: 'Gold Ring · via Repair Karigar',
            coYear: '2024-2025',
            coBook: 'RCR',
            voucherNo: '00001',
            srNo: 1,
            headerVoucherNo: '00001',
            vchDate: '2024-04-10',
            customerCode: 'CUST',
            customerName: 'Repair Customer',
            karigarReceiptNo: '00001',
            karigarReceiptSrNo: 1,
            karigarCode: 'KAR',
            karigarName: 'Repair Karigar',
            itCode: 'GOLD',
            itemName: 'Gold Ring',
            itType: 'G',
            rateType: 'G',
            description: 'Resize',
            itmSize: '12',
            tagNo: '',
            vchSrNo: 0,
            pieces: 1,
            grossWt: 10,
            otherWt: 1,
            netWt: 9,
            touch: 90,
            wastagePct: 0,
            fineWt: 9,
            addWt: 10,
            lessWt: 0,
            lessTouch: 0,
            lessFine: 0,
            rate: 100,
            labourAmount: 0,
            otherAmount: 0,
            labourType: '',
            labourRate: 0,
            itemAmount: 1000,
            netAmount: 1000,
          },
        ],
      },
      { company: CO },
    );
    expect(html).toContain('Repairing Delivered — Customer Issue');
    expect(html).toContain('Repair Karigar');
    expect(html).toContain('Gold Ring');
    expect(html).toContain('1,030.00');
    expect(html).toContain('530.00');
    expect(html).toContain('&lt;script&gt;bad()&lt;/script&gt;');
    expect(html).not.toContain('<script>bad()</script>');
  });

  it('receipt & payment vouchers', () => {
    const r = financeVoucherHtml(
      'receipt',
      {
        VCH_NO: '11',
        CO_BOOK: 'RCT',
        VCH_TYPE: 'CREC',
        AC_NAME: 'Ramesh',
        REC_AMT: 5000,
        KASAR_AMT: 50,
      },
      [{ AC_CODE: 'C1', IT_NAME: 'Ramesh', NET_AMT: 5000, IT_REMARK: 'bill S-42' }],
      { company: CO },
    );
    expect(r).toContain('Receipt Voucher');
    expect(r).toContain('Received with thanks from');
    expect(r).toContain('5,050.00');
    const pay = financeVoucherHtml(
      'payment',
      {
        VCH_NO: '8',
        CO_BOOK: 'PAY',
        VCH_TYPE: 'BPAY',
        AC_NAME: 'Vendor',
        NET_AMT: 20000,
        TOT_AMT: 20000,
        BANK_AC: 'HDFC',
        CHQ_NO: '556677',
      },
      [{ AC_CODE: 'V1', IT_NAME: 'Vendor', NET_AMT: 20000 }],
      { company: CO },
    );
    expect(pay).toContain('Payment Voucher');
    expect(pay).toContain('Cheque No: 556677');
    expect(pay).toContain('20,000.00');
  });

  it('dhrn pledge receipt + khata running ledger', () => {
    const rc = dhrnIssueHtml(
      {
        DHRN_BILL: 'DL-101',
        VCH_NO: '101',
        CO_BOOK: 'DIS',
        AC_NAME: 'Suresh',
        DHRN_AMT: 50000,
        INT_PRC: 24,
        INT_MONTH: 12,
        MONTH_INT_AMT: 1000,
        GOLD_AMT: 75000,
        PACKET_NO: 'PKT-9',
      },
      [
        {
          IT_NAME: 'Gold Chain',
          ITM_PCS: 1,
          ITM_GWT: 22.5,
          ITM_NWT: 22,
          ITM_FINE: 20.15,
          ITM_AMT: 50000,
        },
      ],
      { company: CO, party: { AC_NAME: 'Suresh' } },
    );
    expect(rc).toContain('Pledge Receipt');
    expect(rc).toContain('Pledged Collateral');
    expect(rc).toContain('50,000.00');
    expect(rc).toContain('24%');
    const kh = dhrnKhataHtml(
      [
        {
          VCH_DATE: '2026-01-01',
          VCH_TYPE: 'DISU',
          DHRN_AMT: 50000,
          INT_AMT: 0,
          DHRN_REC_AMT: 0,
          INT_REC_AMT: 0,
          ISU_NO: '1',
        },
        {
          VCH_DATE: '2026-02-01',
          VCH_TYPE: 'DINT',
          DHRN_AMT: 0,
          INT_AMT: 1000,
          DHRN_REC_AMT: 0,
          INT_REC_AMT: 0,
          ISU_NO: '1',
        },
        {
          VCH_DATE: '2026-03-01',
          VCH_TYPE: 'DREC',
          DHRN_AMT: 0,
          INT_AMT: 0,
          DHRN_REC_AMT: 20000,
          INT_REC_AMT: 1000,
          ISU_NO: '1',
        },
      ],
      { AC_CODE: 'B1', AC_NAME: 'Suresh' },
      { company: CO },
    );
    expect(kh).toContain('Dhrn Khata-Vahi');
    expect(kh).toContain('30,000.00');
  });

  it('scheme passbook running installments', () => {
    const html = schemePassbookHtml(
      { MEMB_CODE: 'M-7', SCHM_CODE: 'S1', MEMB_NAME: 'Meena Shah', MEMB_AMT: 2000 },
      {
        SCHM_CODE: 'S1',
        SCHM_NAME: 'Gold Saving 11+1',
        SCHM_AMT: 2000,
        SCHM_MONTH: 11,
        BONUS_PRC: 9,
      },
      [
        { VCH_DATE: '2026-01-05', MONTH_CODE: '1', MEMB_AMT: 2000 },
        { VCH_DATE: '2026-02-05', MONTH_CODE: '2', MEMB_AMT: 2000 },
        { VCH_DATE: '2026-03-05', MONTH_CODE: '3', MEMB_AMT: 2000 },
      ],
      { company: CO },
    );
    expect(html).toContain('Scheme Passbook');
    expect(html).toContain('3 / 11');
    expect(html).toContain('6,000.00');
    expect(html).toContain('Maturity Value');
  });

  it('sales order confirmation with advance + balance', () => {
    const html = orderHtml(
      {
        BILL_NO: 'O1',
        VCH_NO: '1',
        CO_BOOK: 'SOR',
        AC_NAME: 'Cust',
        DEL_DATE: '2026-08-01',
        NET_AMT: 50000,
        TAX_AMT: 1500,
        TOT_AMT: 51500,
        ADV_AMT: 10000,
      },
      [
        {
          IT_CODE: 'NECKLACE',
          ITM_PCS: 1,
          ITM_GWT: 30,
          ITM_NWT: 28,
          ITM_RATE: 6000,
          ITM_AMT: 50000,
          NET_AMT: 51500,
        },
      ],
      { company: CO, party: { AC_NAME: 'Cust' } },
    );
    expect(html).toContain('Sales Order Confirmation');
    expect(html).toContain('Balance Due on Delivery');
    expect(html).toContain('Advance Received');
  });

  it('GSTR-1 / GSTR-2 / GSTR-3B statutory documents', () => {
    const g1 = gstr1DocHtml(
      {
        b2b: [
          {
            gstin: '24AAA',
            vchNo: '1',
            ratePct: 3,
            taxable: 1000,
            cgst: 15,
            sgst: 15,
            igst: 0,
            invoiceValue: 1030,
          },
        ],
        b2cl: [],
        b2cs: [{ stateCode: '24', ratePct: 3, taxable: 500, cgst: 7.5, sgst: 7.5, igst: 0 }],
        hsn: [{ hsn: '7113', qty: 2, taxable: 1500, cgst: 22.5, sgst: 22.5, igst: 0 }],
      } as any,
      { company: CO, period: 'FY 2024' },
    );
    expect(g1).toContain('GSTR-1 — Outward Supplies');
    expect(g1).toContain('4. B2B');
    expect(g1).toContain('12. HSN');
    expect(g1).toContain('Total Tax Liability');
    const g2 = gstr2DocHtml(
      { taxable: 200000, cgst: 3000, sgst: 3000, igst: 0, tax: 6000 },
      { company: CO },
    );
    expect(g2).toContain('GSTR-2 — Inward Supplies');
    expect(g2).toContain('Eligible ITC');
    const g3 = gstr3bDocHtml(
      {
        outwardTaxable: 100000,
        outwardCGST: 1500,
        outwardSGST: 1500,
        outwardIGST: 0,
        outwardTax: 3000,
      },
      { company: CO },
    );
    expect(g3).toContain('GSTR-3B — Summary Return');
    expect(g3).toContain('Total Tax Payable');
  });

  it('trial balance (balanced) + balance sheet statements', () => {
    const tb = trialBalanceDocHtml(
      {
        rows: [
          { acCode: 'A', name: 'Cash', dr: 1000, cr: 0, balance: 1000 },
          { acCode: 'B', name: 'Capital', dr: 0, cr: 1000, balance: -1000 },
        ],
        totals: { accounts: 2, dr: 1000, cr: 1000 },
      },
      { company: CO },
    );
    expect(tb).toContain('Trial Balance');
    expect(tb).toContain('Debit');
    expect(tb).toContain('Credit');
    expect(tb).toContain('is balanced');
    const bs = balanceSheetDocHtml(
      {
        ledgerDr: 5000,
        ledgerCr: 5000,
        closingStockDerived: 0,
        totalAssets: 5000,
        totalLiabilities: 5000,
        balanced: true,
      },
      { company: CO },
    );
    expect(bs).toContain('Balance Sheet');
    expect(bs).toContain('Liabilities');
    expect(bs).toContain('Assets');
  });
});

describe('rupeesInWords', () => {
  it('formats lakhs', () => {
    expect(rupeesInWords(103045)).toContain('Lakh');
    expect(rupeesInWords(103045)).toContain('Rupees');
  });
  it('zero', () => {
    expect(rupeesInWords(0)).toBe('Zero Rupees');
  });
});

describe('groupForColumn (master field → tab)', () => {
  it('classifies known columns', () => {
    expect(groupForColumn('AC_GSTNO')).toBe('Tax & GST');
    expect(groupForColumn('AC_ADD1')).toBe('Address');
    expect(groupForColumn('CO_MOBILE')).toBe('Contact');
    expect(groupForColumn('BANK_NAME')).toBe('Bank');
    expect(groupForColumn('BIRTH_DATE')).toBe('Dates');
    expect(groupForColumn('AC_NAME')).toBe('General');
    expect(groupForColumn('CR_DAYS')).toBe('Balances & Terms');
  });
});
