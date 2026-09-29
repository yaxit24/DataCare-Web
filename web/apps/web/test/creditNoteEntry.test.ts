import { describe, expect, it } from 'vitest';
import {
  blankCreditNoteDraft,
  blankCreditNoteLine,
  creditNoteRequest,
  draftFromEntry,
  previewCreditNote,
  type CreditNoteEntryConfig,
} from '../lib/creditNoteEntry';

const config: CreditNoteEntryConfig = {
  book: { coBook: '146', name: 'E Credit Note', shortName: 'ECRNT', slots: [] },
  policy: { amountDigits: 0, taxDigits: 2, labourRateDigits: 0, labourIncludesGhat: true },
  defaultLabourType: 'N',
  defaultTaxCode: '10',
  employeeMandatory: false,
  cashLimit: 0,
  taxCodes: [{ code: '10', name: 'GST 3%', percent: 3 }],
};

describe('E CRNT entry form', () => {
  it('starts a line like TR_SL_EBILL CommPassAdd: one piece, company labour basis, GST 10', () => {
    expect(blankCreditNoteLine(config)).toMatchObject({ pcs: 1, labourType: 'N', taxCode: '10' });
  });

  it('previews the same totals the server posts (core vector B01)', () => {
    const draft = {
      ...blankCreditNoteDraft('2024-06-10', config),
      partyCode: 'CUST01',
      cashAmount: 10000,
      lines: [
        {
          ...blankCreditNoteLine(config),
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
          ...blankCreditNoteLine(config),
          itemCode: 'CHAIN',
          pcs: 3,
          rate: 1234.5,
          rateType: 'P',
          labourType: 'P',
          labourRate: 100,
        },
        blankCreditNoteLine(config),
      ],
    };
    const preview = previewCreditNote(draft, config);
    expect(preview.lines.map((l) => l.saved)).toEqual([true, true, false]);
    expect(preview.bill).toMatchObject({
      netAmount: 65954,
      taxAmount: 1978.62,
      totalAmount: 67933,
      roundOff: 0.38,
      outstanding: 57933,
    });
    const inter = previewCreditNote({ ...draft, partyGstType: 'I' }, config);
    expect(inter.bill.igst).toBe(1978.62);
    expect(inter.bill.cgst).toBe(0);
  });

  it('sends the writer contract and keeps the revision for a stale-edit check', () => {
    const draft = { ...blankCreditNoteDraft('2024-06-10', config), partyCode: ' CUST01 ' };
    draft.lines[0] = { ...draft.lines[0]!, itemCode: ' GOLD ', itemName: 'Gold Ring', oldSrNo: 4 };
    const body = creditNoteRequest(draft, '146', 'rev-1');
    expect(body).toMatchObject({ coBook: '146', partyCode: 'CUST01', expectedRevision: 'rev-1' });
    expect(body.lines[0]).toMatchObject({ itemCode: 'GOLD', oldSrNo: 4 });
    expect(body.lines[0]).not.toHaveProperty('itemName');
    expect(creditNoteRequest(draft, '146')).not.toHaveProperty('expectedRevision');
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
      lines: [{ ...blankCreditNoteLine(config), srNo: 1, tagNo: '', oldSrNo: 7, itemCode: 'GOLD' }],
    });
    expect(draft).toMatchObject({ partyGstType: 'L', cashAmount: 5, billNo: 'REF-9' });
    expect(draft.lines[0]).toMatchObject({ oldSrNo: 7, itemCode: 'GOLD', itemName: '' });
    expect(draft.lines[0]).not.toHaveProperty('srNo');
  });
});
