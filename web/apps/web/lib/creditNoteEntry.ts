import {
  calculateECreditNoteBill,
  calculateECreditNoteLine,
  eCreditNoteLineIsSaved,
  type ECreditNoteBillResult,
  type ECreditNoteLineResult,
  type ECreditNotePolicy,
} from '@datacare/core';

/** E CRNT entry form state and the exact request the API writer accepts (card X15). */
export type CreditNoteLineDraft = {
  oldSrNo?: number;
  itemCode: string;
  itemName: string;
  designNo: string;
  size: string;
  remark: string;
  hmId: string;
  pcs: number;
  bagWt: number;
  grossWt: number;
  lessWt: number;
  ghatPercent: number;
  touch: number;
  westPercent: number;
  rate: number;
  rateType: string;
  labourType: string;
  labourRate: number;
  labourPercent: number;
  otherAmount: number;
  mrp: number;
  taxCode: string;
};

export type CreditNoteDraft = {
  vchDate: string;
  partyCode: string;
  partyName: string;
  partyGstType: string;
  billNo: string;
  ledgerCode: string;
  employeeCode: string;
  description: string;
  cashAmount: number;
  chequeAmount: number;
  chequeAccount: string;
  chequeNo: string;
  cardAmount: number;
  cardAccount: string;
  cardCommission: number;
  kasarAmount: number;
  lines: CreditNoteLineDraft[];
};

export type CreditNoteEntryConfig = {
  book: {
    coBook: string;
    name: string;
    shortName: string;
    slots: { srNo: number; accountCode: string }[];
  };
  policy: Omit<ECreditNotePolicy, 'interState'>;
  defaultLabourType: string;
  defaultTaxCode: string;
  employeeMandatory: boolean;
  cashLimit: number;
  taxCodes: { code: string; name: string; percent: number }[];
};

export type CreditNoteEntryView = {
  voucherNo: string;
  hiddenVoucherNo: string;
  vchDate: string;
  partyCode: string;
  partyName: string;
  gstType: string;
  billNo: string;
  ledgerCode: string;
  employeeCode: string;
  description: string;
  cashAmount: number;
  chequeAmount: number;
  chequeAccount: string;
  chequeNo: string;
  cardAmount: number;
  cardAccount: string;
  cardCommission: number;
  kasarAmount: number;
  irnLocked: boolean;
  componentCount: number;
  revision: string;
  lines: (Omit<CreditNoteLineDraft, 'itemName'> & {
    itemName?: string;
    srNo: number;
    tagNo: string;
  })[];
};

export const RATE_TYPES = [
  ['G', 'Per gram'],
  ['1', 'Per 10 g'],
  ['K', 'Per kg'],
  ['P', 'Per piece'],
] as const;
export const LABOUR_TYPES = [
  ['G', 'Gross wt'],
  ['N', 'Net wt'],
  ['K', 'Per kg'],
  ['P', 'Per piece'],
] as const;

/** TR_SL_EBILL CommPassAdd (4400-4418): a new row starts with 1 piece, the company labour basis and GST 10. */
export function blankCreditNoteLine(
  config?: Pick<CreditNoteEntryConfig, 'defaultLabourType' | 'defaultTaxCode'>,
): CreditNoteLineDraft {
  return {
    itemCode: '',
    itemName: '',
    designNo: '',
    size: '',
    remark: '',
    hmId: '',
    pcs: 1,
    bagWt: 0,
    grossWt: 0,
    lessWt: 0,
    ghatPercent: 0,
    touch: 0,
    westPercent: 0,
    rate: 0,
    rateType: 'G',
    labourType: config?.defaultLabourType || 'G',
    labourRate: 0,
    labourPercent: 0,
    otherAmount: 0,
    mrp: 0,
    taxCode: config?.defaultTaxCode ?? '10',
  };
}

export function blankCreditNoteDraft(
  today: string,
  config?: CreditNoteEntryConfig,
): CreditNoteDraft {
  return {
    vchDate: today,
    partyCode: '',
    partyName: '',
    partyGstType: '',
    billNo: '',
    ledgerCode: '',
    employeeCode: '',
    description: '',
    cashAmount: 0,
    chequeAmount: 0,
    chequeAccount: '',
    chequeNo: '',
    cardAmount: 0,
    cardAccount: '',
    cardCommission: 0,
    kasarAmount: 0,
    lines: [blankCreditNoteLine(config)],
  };
}

export function draftFromEntry(view: CreditNoteEntryView): CreditNoteDraft {
  return {
    vchDate: view.vchDate,
    partyCode: view.partyCode,
    partyName: view.partyName,
    partyGstType: view.gstType,
    billNo: view.billNo,
    ledgerCode: view.ledgerCode,
    employeeCode: view.employeeCode,
    description: view.description,
    cashAmount: view.cashAmount,
    chequeAmount: view.chequeAmount,
    chequeAccount: view.chequeAccount,
    chequeNo: view.chequeNo,
    cardAmount: view.cardAmount,
    cardAccount: view.cardAccount,
    cardCommission: view.cardCommission,
    kasarAmount: view.kasarAmount,
    lines: view.lines.map(({ srNo: _srNo, tagNo: _tagNo, ...line }) => ({
      ...line,
      itemName: line.itemName ?? '',
    })),
  };
}

/** Live preview with the same core arithmetic the server uses; the server result is authoritative. */
export function previewCreditNote(
  draft: CreditNoteDraft,
  config: CreditNoteEntryConfig | null,
): { lines: (ECreditNoteLineResult & { saved: boolean })[]; bill: ECreditNoteBillResult } {
  const policy: ECreditNotePolicy = {
    amountDigits: config?.policy.amountDigits ?? 0,
    taxDigits: config?.policy.taxDigits ?? 0,
    labourRateDigits: config?.policy.labourRateDigits ?? 0,
    labourIncludesGhat: config?.policy.labourIncludesGhat ?? true,
    interState: draft.partyGstType.trim().toUpperCase() === 'I',
  };
  const percentOf = (code: string) =>
    config?.taxCodes.find((t) => t.code === code.trim())?.percent ?? 0;
  const lines = draft.lines.map((line) => {
    const calc = calculateECreditNoteLine(
      { ...line, taxPercent: line.taxCode.trim() ? percentOf(line.taxCode) : 0 },
      policy,
    );
    return { ...calc, saved: eCreditNoteLineIsSaved(line.itemCode, calc) };
  });
  const bill = calculateECreditNoteBill(
    lines.filter((l) => l.saved),
    {
      cash: draft.cashAmount,
      cheque: draft.chequeAmount,
      card: draft.cardAmount,
      kasar: draft.kasarAmount,
    },
  );
  return { lines, bill };
}

export function creditNoteRequest(
  draft: CreditNoteDraft,
  coBook: string,
  expectedRevision?: string,
) {
  return {
    coBook,
    vchDate: draft.vchDate,
    partyCode: draft.partyCode.trim(),
    billNo: draft.billNo.trim(),
    ledgerCode: draft.ledgerCode.trim(),
    employeeCode: draft.employeeCode.trim(),
    description: draft.description,
    cashAmount: draft.cashAmount,
    chequeAmount: draft.chequeAmount,
    chequeAccount: draft.chequeAccount.trim(),
    chequeNo: draft.chequeNo.trim(),
    cardAmount: draft.cardAmount,
    cardAccount: draft.cardAccount.trim(),
    cardCommission: draft.cardCommission,
    kasarAmount: draft.kasarAmount,
    ...(expectedRevision ? { expectedRevision } : {}),
    lines: draft.lines.map(({ itemName: _itemName, ...line }) => ({
      ...line,
      itemCode: line.itemCode.trim(),
    })),
  };
}
