import { describe, expect, it } from 'vitest';
import {
  blankEBillDraft,
  blankEBillLine,
  eBillRequest,
  draftFromEntry,
  previewEBill,
  type EBillEntryConfig,
} from '../lib/eBillEntry';

const config: EBillEntryConfig = {
  book: { coBook: '146', name: 'E Credit Note', shortName: 'ECRNT', slots: [] },
  policy: { amountDigits: 0, taxDigits: 2, labourRateDigits: 0, labourIncludesGhat: true },
  defaultLabourType: 'N',
  defaultTaxCode: '10',
  employeeMandatory: false,
  cashLimit: 0,
  taxCodes: [{ code: '10', name: 'GST 3%', percent: 3 }],
};

describe('TR_SL_EBILL entry form', () => {
  it('starts a line like TR_SL_EBILL CommPassAdd: one piece, company labour basis, GST 10', () => {
    expect(blankEBillLine(config)).toMatchObject({ pcs: 1, labourType: 'N', taxCode: '10' });
  });

  it('previews the same totals the server posts (core vector B01)', () => {
    const draft = {
      ...blankEBillDraft('2024-06-10', config),
      partyCode: 'CUST01',
      cashAmount: 10000,
      lines: [
        {
          ...blankEBillLine(config),
          itemCode: 'GOLD',
          grossWt: 10,
          lessWt: 0.5,
          rate: 6000,
          rateType: 'G',
          labourType: 'G',
          labourRate: 500,
          otherAmount: 250,
        },
        {
          ...blankEBillLine(config),
          itemCode: 'CHAIN',
          pcs: 3,
          rate: 1234.5,
          rateType: 'P',
          labourType: 'P',
          labourRate: 100,
        },
        blankEBillLine(config),
      ],
    };
    const preview = previewEBill(draft, config);
    expect(preview.lines.map((l) => l.saved)).toEqual([true, true, false]);
    expect(preview.bill).toMatchObject({
      netAmount: 65954,
      taxAmount: 1978.62,
      totalAmount: 67933,
      roundOff: 0.38,
      outstanding: 57933,
    });
    const inter = previewEBill({ ...draft, partyGstType: 'I' }, config);
    expect(inter.bill.igst).toBe(1978.62);
    expect(inter.bill.cgst).toBe(0);
  });

  it('sends the writer contract and keeps the revision for a stale-edit check', () => {
    const draft = { ...blankEBillDraft('2024-06-10', config), partyCode: ' CUST01 ' };
    draft.lines[0] = { ...draft.lines[0]!, itemCode: ' GOLD ', itemName: 'Gold Ring', oldSrNo: 4 };
    const body = eBillRequest(draft, '146', 'E CRNT', 'rev-1');
    expect(body).toMatchObject({ coBook: '146', partyCode: 'CUST01', expectedRevision: 'rev-1' });
    expect(body.lines[0]).toMatchObject({ itemCode: 'GOLD', oldSrNo: 4 });
    expect(body.lines[0]).not.toHaveProperty('itemName');
    expect(eBillRequest(draft, '146', 'E CRNT')).not.toHaveProperty('expectedRevision');
    expect(body).not.toHaveProperty('tdsCode');
  });

  it('hydrates a saved credit note without inventing values', () => {
    const draft = draftFromEntry({
      voucherNo: '00001',
      hiddenVoucherNo: '00001',
      vchDate: '2024-06-10',
      partyCode: 'CUST01',
      partyName: 'Credit Customer',
      gstType: 'L',
      billNo: 'REF-9',
      ledgerCode: '',
      employeeCode: 'E01',
      description: '',
      cashAmount: 5,
      chequeAmount: 0,
      chequeAccount: '',
      chequeNo: '',
      cardAmount: 0,
      cardAccount: '',
      cardCommission: 0,
      kasarAmount: 0,
      irnLocked: false,
      componentCount: 0,
      revision: 'r',
      lines: [{ ...blankEBillLine(config), srNo: 1, tagNo: '', oldSrNo: 7, itemCode: 'GOLD' }],
    });
    expect(draft).toMatchObject({ partyGstType: 'L', cashAmount: 5, billNo: 'REF-9' });
    expect(draft.lines[0]).toMatchObject({ oldSrNo: 7, itemCode: 'GOLD', itemName: '' });
    expect(draft.lines[0]).not.toHaveProperty('srNo');
  });
});

describe('E INVOICE entry preview', () => {
  const invoiceConfig: EBillEntryConfig = {
    ...config,
    family: 'E INVOICE',
    tcsCodes: [
      { code: '00', name: 'None', percent: 0 },
      { code: '20', name: 'TCS', percent: 0.1 },
    ],
    tdsCodes: [{ code: '25', name: 'TDS', percent: 1 }],
    tcsThresholdPercent: 0.1,
  };
  const draft = {
    ...blankEBillDraft('2024-06-10', invoiceConfig),
    partyCode: 'CUST01',
    lines: [{ ...blankEBillLine(invoiceConfig), itemCode: 'GOLD', mrp: 50000 }],
  };

  it('applies the new-voucher TCS threshold with the party debits (vector EI-2)', () => {
    const preview = previewEBill(draft, invoiceConfig, {
      family: 'E INVOICE',
      creating: true,
      priorDebits: 4990000,
    });
    expect(preview.bill).toMatchObject({ tcsAmount: 42, totalAmount: 51542, roundOff: 0 });
    const saved = previewEBill(draft, invoiceConfig, {
      family: 'E INVOICE',
      creating: false,
      priorDebits: 4990000,
    });
    expect(saved.bill.tcsAmount).toBe(0); // a saved voucher needs its stored code (20) to recompute
    const savedWithCode = previewEBill({ ...draft, tcsCode: '20' }, invoiceConfig, {
      family: 'E INVOICE',
      creating: false,
    });
    expect(savedWithCode.bill).toMatchObject({ tcsAmount: 52, totalAmount: 51552 });
  });

  it('computes TDS on the taxable amount and sends TCS/TDS only for an e-invoice', () => {
    const preview = previewEBill({ ...draft, tdsCode: '25' }, invoiceConfig, {
      family: 'E INVOICE',
      creating: true,
    });
    expect(preview.bill).toMatchObject({ tdsAmount: 500, outstanding: 51000 });
    const body = eBillRequest({ ...draft, tdsCode: '25', tcsCode: '00' }, 'EIN', 'E INVOICE');
    expect(body).toMatchObject({ tdsCode: '25', tcsCode: '00', tcsAmount: 0 });
  });
});
