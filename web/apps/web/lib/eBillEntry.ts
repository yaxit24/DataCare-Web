import {
  calculateEBillLine,
  calculateEBillTotals,
  eBillLineIsSaved,
  eInvoiceTcs,
  type EBillLineResult,
  type EBillPolicy,
  type EBillTotals,
} from '@datacare/core';

/**
 * TR_SL_EBILL entry form state (card X15) for both modes: E CRNT credit notes and E INVOICE
 * e-invoices, and the exact request the API writer accepts.
 */
export type EBillFamily = 'E CRNT' | 'E INVOICE';

export type EBillLineDraft = {
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

export type EBillDraft = {
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
  /** E INVOICE only. '' none. */
  tdsCode: string;
  /** E INVOICE only. '' automatic 50 lakh rule, '00' none, otherwise a picked code. */
  tcsCode: string;
  /** E INVOICE only: typed amount for a picked code below the threshold. */
  tcsAmount: number;
  lines: EBillLineDraft[];
};

type TaxHead = { code: string; name: string; percent: number };
export type EBillEntryConfig = {
  family?: EBillFamily;
  book: {
    coBook: string;
    name: string;
    shortName: string;
    slots: { srNo: number; accountCode: string }[];
  };
  policy: Omit<EBillPolicy, 'interState'>;
  defaultLabourType: string;
  defaultTaxCode: string;
  employeeMandatory: boolean;
  cashLimit: number;
  taxCodes: TaxHead[];
  tcsCodes?: TaxHead[];
  tdsCodes?: TaxHead[];
  tcsThresholdPercent?: number | null;
};

export type EBillEntryView = {
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
  tcsCode?: string;
  tcsAmount?: number;
  tdsCode?: string;
  irnLocked: boolean;
  componentCount: number;
  revision: string;
  registration?: { irn: string; ackNo: string; ackDate: string } | null;
  lines: (Omit<EBillLineDraft, 'itemName'> & { itemName?: string; srNo: number; tagNo: string })[];
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
export function blankEBillLine(
  config?: Pick<EBillEntryConfig, 'defaultLabourType' | 'defaultTaxCode'>,
): EBillLineDraft {
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

export function blankEBillDraft(today: string, config?: EBillEntryConfig): EBillDraft {
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
    tdsCode: '',
    tcsCode: '',
    tcsAmount: 0,
    lines: [blankEBillLine(config)],
  };
}

export function draftFromEntry(view: EBillEntryView): EBillDraft {
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
    tdsCode: view.tdsCode ?? '',
    tcsCode: view.tcsCode ?? '',
    tcsAmount: view.tcsAmount ?? 0,
    lines: view.lines.map(({ srNo: _srNo, tagNo: _tagNo, ...line }) => ({
      ...line,
      itemName: line.itemName ?? '',
    })),
  };
}

/**
 * Live preview with the same core arithmetic the server uses; the server result is authoritative.
 * `priorDebits` is the party's AcTcsAmt (GET /e-invoices/tcs-basis) and only matters for a new
 * E INVOICE; `creating` selects the new-voucher threshold rule or the saved-voucher full base.
 */
export function previewEBill(
  draft: EBillDraft,
  config: EBillEntryConfig | null,
  options: { family?: EBillFamily; creating?: boolean; priorDebits?: number } = {},
): { lines: (EBillLineResult & { saved: boolean })[]; bill: EBillTotals } {
  const family = options.family ?? config?.family ?? 'E CRNT';
  const policy: EBillPolicy = {
    amountDigits: config?.policy.amountDigits ?? 0,
    taxDigits: config?.policy.taxDigits ?? 0,
    labourRateDigits: config?.policy.labourRateDigits ?? 0,
    labourIncludesGhat: config?.policy.labourIncludesGhat ?? true,
    interState: draft.partyGstType.trim().toUpperCase() === 'I',
  };
  const percentOf = (list: TaxHead[] | undefined, code: string) =>
    list?.find((t) => t.code === code.trim())?.percent ?? 0;
  const lines = draft.lines.map((line) => {
    const calc = calculateEBillLine(
      {
        ...line,
        taxPercent: line.taxCode.trim() ? percentOf(config?.taxCodes, line.taxCode) : 0,
      },
      policy,
    );
    return { ...calc, saved: eBillLineIsSaved(line.itemCode, calc) };
  });
  const saved = lines.filter((l) => l.saved);
  const tender = {
    cash: draft.cashAmount,
    cheque: draft.chequeAmount,
    card: draft.cardAmount,
    kasar: draft.kasarAmount,
  };
  if (family !== 'E INVOICE') return { lines, bill: calculateEBillTotals(saved, tender) };
  const gross = calculateEBillTotals(saved, tender);
  let tcsAmount = 0;
  try {
    tcsAmount = eInvoiceTcs({
      creating: options.creating ?? true,
      netAmount: gross.netAmount,
      igst: gross.igst,
      cgst: gross.cgst,
      sgst: gross.sgst,
      priorDebits: options.priorDebits ?? 0,
      requestedCode: draft.tcsCode,
      requestedPercent: percentOf(config?.tcsCodes, draft.tcsCode),
      thresholdPercent: config?.tcsThresholdPercent ?? null,
      typedAmount: draft.tcsAmount,
    }).amount;
  } catch {
    tcsAmount = 0; // the server reports the missing TAX_MAST code 20 on save
  }
  return {
    lines,
    bill: calculateEBillTotals(saved, {
      ...tender,
      tcsAmount,
      tdsPercent: draft.tdsCode.trim() ? percentOf(config?.tdsCodes, draft.tdsCode) : 0,
    }),
  };
}

export function eBillRequest(
  draft: EBillDraft,
  coBook: string,
  family: EBillFamily,
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
    ...(family === 'E INVOICE'
      ? { tdsCode: draft.tdsCode.trim(), tcsCode: draft.tcsCode.trim(), tcsAmount: draft.tcsAmount }
      : {}),
    ...(expectedRevision ? { expectedRevision } : {}),
    lines: draft.lines.map(({ itemName: _itemName, ...line }) => ({
      ...line,
      itemCode: line.itemCode.trim(),
    })),
  };
}
