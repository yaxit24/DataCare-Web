export type MfgLotKind = 'issue' | 'receive';
export type MfgLotRow = Record<string, string | number | boolean | null>;
export type MfgLotDisplayLabels = {
  accounts: Record<string, string | null>;
  items: Record<string, string | null>;
};
export type MfgLotSettings = {
  book: MfgLotRow;
  stage: MfgLotRow | null;
  savedBrowse: boolean;
  sourceKind: 'stock-material' | 'setting-material-outstanding';
  sourceSelection: boolean;
  sourceUnavailableReason: string | null;
  sourceBooks: MfgLotRow[];
  writes: false;
  unavailableReason: string;
};
export type MfgLotDocument = {
  settings: MfgLotSettings;
  header: MfgLotRow;
  lines: MfgLotRow[];
  components: MfgLotRow[];
  movements: MfgLotRow[];
  stock: MfgLotRow[];
  version: string;
  displayLabels: MfgLotDisplayLabels;
};
export type MfgLotSourceView = {
  key: string;
  kind: string;
  identity: MfgLotRow;
  contributors: MfgLotRow[];
  materialLot: string | null;
  itemCode: string | null;
  receivedItemCode?: string | null;
  sourceDate: string | null;
  sourceYear?: string | null;
  sourceBook?: string | null;
  sourceVoucher?: string | null;
  sourceOldSrNo?: string | null;
  sourceAccount?: string | null;
  process?: string | null;
  remainingPieces: string | null;
  remainingWeight: string | null;
  remainingNetWeight: string | null;
  availabilityBasis: string;
  advisory: true;
};
export type MfgLotPage<T> = {
  rows: T[];
  offset: number;
  limit: number;
  hasMore: boolean;
  displayLabels: MfgLotDisplayLabels;
};
const accountFields = new Set([
  'AC_CODE',
  'KR_CODE',
  'KR_AC_CODE',
  'REP_AC_CODE',
  'ORD_AC_CODE',
  'IR_AC',
  'BANK_AC',
  'CARD_AC',
  'ITM_LOT_AC_CODE',
  'account',
  'karigar',
  'sourceAccount',
]);
const itemFields = new Set([
  'IT_CODE',
  'ISU_IT_CODE',
  'MTRL_IT_CODE',
  'CHOL_IT_CODE',
  'FTNG_IT_CODE',
  'itemCode',
  'receivedItemCode',
]);
export function mfgLotDisplayName(key: string, code: unknown, labels?: MfgLotDisplayLabels) {
  const names = accountFields.has(key)
    ? labels?.accounts
    : itemFields.has(key)
      ? labels?.items
      : undefined;
  return names?.[String(code ?? '').trim()] || null;
}
export const mfgLotValue = (value: unknown) =>
  value == null ? 'Not set' : value === '' ? 'Blank' : String(value);
export const mfgLotFamilies = { issue: 'MFG STNG ISU', receive: 'MFG STNG REC' } as const;
export function mfgLotComponents(document: MfgLotDocument, line: MfgLotRow) {
  // TR_MFG_WITH_LOT uses the persisted parent SR_NO. OLD_SRNO is the separate source link.
  return document.components.filter((child) => String(child.SR_NO) === String(line.SR_NO));
}
export const mfgLotLabels: Record<string, string> = {
  kind: 'Source kind',
  coCode: 'Company',
  lcCode: 'Branch',
  materialLot: 'Material lot',
  itemCode: 'Item code',
  sourceBranch: 'Source branch',
  sourceYear: 'Source year',
  sourceBook: 'Source book',
  sourceVoucher: 'Source voucher',
  sourceOldSrNo: 'Source original row',
  sourceAccount: 'Source account',
  receivedItemCode: 'Received item code',
  process: 'Process',
  account: 'Account',
  karigar: 'Karigar',
  stockRowId: 'Stock movement reference',

  VCH_NO: 'Voucher number',
  VCH_DATE: 'Voucher date',
  VCH_TIME: 'Voucher time',
  BILL_NO: 'Bill reference',
  BILL_DATE: 'Bill date',
  CO_CODE: 'Company',
  LC_CODE: 'Branch',
  CO_YEAR: 'Financial year',
  CO_BOOK: 'Book',
  AC_CODE: 'Account',
  KR_CODE: 'Karigar',
  BOOK_NAME: 'Saved book family',
  INOUT_TYPE: 'Movement direction',
  ENTRY_TYPE: 'Process',
  VCH_TYPE: 'Voucher type',
  VCH_DESC: 'Narration',
  SR_NO: 'Parent row',
  OLD_SRNO: 'Original / source row',
  ISR_NO: 'Component row',
  VCH_SRNO: 'Tag instance',
  IT_CODE: 'Item code',
  ISU_IT_CODE: 'Issued item code',
  TAG_NO: 'Tag / work lot',
  LOT_NO: 'Material lot',
  ITM_LOT: 'Component / stock material lot',
  ITM_LOT_AC_CODE: 'Material lot account',
  DESIGN_NO: 'Design',
  DESIGN_SRNO: 'Design row',
  DESIGN_IMG_ID: 'Design image reference',
  ITM_SIZE: 'Size',
  ITM_REMARK: 'Remark',
  ITM_PCS: 'Pieces',
  ITM_GWT: 'Gross weight',
  ITM_OTH_WT: 'Other weight',
  ITM_NWT: 'Net weight',
  ITM_TOUCH: 'Touch %',
  ITM_WEST_PRC: 'Wastage %',
  ITM_FINE: 'Fine weight',
  ITM_GHT_PRC: 'Ghat %',
  ITM_GHT_WT: 'Ghat weight',
  RTN_CHOL: 'Returned chol',
  RTN_GHIS: 'Returned ghis',
  MTRL_WT: 'Material weight',
  MTRL_IT_CODE: 'Material item',
  DM_PCS: 'Diamond pieces',
  DM_WT: 'Diamond weight',
  DM_SIZE: 'Stone size',
  DM_GHT: 'Diamond ghat',
  DM_GHT_TOUCH: 'Diamond ghat touch',
  TOT_GHT: 'Total ghat',
  LBR_TYPE: 'Labour basis',
  LBR_RATE: 'Labour rate',
  LBR_AMT: 'Labour amount',
  OTH_AMT: 'Other amount',
  ITM_RATE: 'Item rate',
  ITM_AMT: 'Item amount',
  NET_AMT: 'Net amount',
  TOT_AMT: 'Total amount',
  GR_WT: 'Gross weight',
  NET_WT: 'Net weight',
  FINE_WT: 'Fine weight',
  TAX_CODE: 'Tax code',
  TAX_PRC: 'Tax %',
  TAX_AMT: 'Tax amount',
  IGST_TAX: 'IGST',
  CGST_TAX: 'CGST',
  SGST_TAX: 'SGST',
  AC_GST_TYPE: 'GST type',
  ROF_AMT: 'Round off',
  CASH_AMT: 'Cash amount',
  CHQ_AMT: 'Cheque amount',
  CARD_AMT: 'Card amount',
  BANK_AC: 'Bank account',
  CARD_AC: 'Card account',
  CHQ_NO: 'Cheque number',
  KASAR_AMT: 'Kasar amount',
  BILL_OS: 'Outstanding amount',
  EMP_CODE: 'Employee',
  HD_VCH_NO: 'Internal voucher reference',
  MAIN_USER: 'Entered by',
  ADD_USER: 'Added by',
  USER_UPDATE: 'Update marker',
  USER_DELETE: 'Delete marker',
  DATA_TRFR: 'Transfer marker',
  REP_YRCD: 'Source year',
  REP_DBCD: 'Source book',
  REP_NO: 'Source voucher',
  REP_SRNO: 'Source original row',
  REP_AC_CODE: 'Source account',
  REP_ADJ: 'Source adjustment marker',
  ADJ_DATE: 'Adjustment date',
  ORD_NO: 'Order number',
  ORD_YRCD: 'Order year',
  ORD_DBCD: 'Order book',
  ORD_SRNO: 'Order row',
  ORD_AC_CODE: 'Order account',
  ORD_DESIGN: 'Order design',
  IT_PCS: 'Component pieces',
  IT_GWT: 'Component gross weight',
  IT_PCS_WT: 'Piece weight',
  IT_CON_PRC: 'Conversion factor',
  IT_CON_WT: 'Converted weight',
  IT_RATE_TYPE: 'Rate basis',
  IT_RATE: 'Component rate',
  IT_AMT: 'Component amount',
  IT_LBR_RATE: 'Component labour rate',
  IT_LBR_AMT: 'Component labour amount',
  IT_NET_AMT: 'Component net amount',
  RTN_PCS: 'Returned pieces',
  RTN_GWT: 'Returned weight',
  BROK_PCS: 'Broken pieces',
  BROK_WT: 'Broken weight',
  OLD_ITM_ISU: 'Previously issued marker',
  IR_LC: 'Source branch',
  IR_YRCD: 'Source year',
  IR_DBCD: 'Source book',
  IR_NO: 'Source voucher',
  IR_SRNO: 'Source original row',
  IR_AC: 'Source account',
  IR_TYPE: 'Process',
  IR_PCS: 'Movement pieces',
  IR_WT: 'Movement weight',
  ITM_SIGN: 'Movement sign',
  KR_AC_CODE: 'Karigar account',
  ITM_GHAT: 'Accounted ghat',
  ITM_LOSS: 'Accounted loss',
  STK_DATE: 'Stock date',
  ENTRY_TIME: 'Entry time',
  TR_TYPE: 'Stock direction',
  KR_NAME: 'Karigar name',
  KR_FINE: 'Karigar fine',
  KR_NWT: 'Karigar net weight',
};
export function mfgLotFields(row: MfgLotRow) {
  const preferred = Object.keys(mfgLotLabels).filter((key) => Object.hasOwn(row, key));
  const extra = Object.keys(row)
    .filter((key) => !Object.hasOwn(mfgLotLabels, key))
    .sort();
  return [...preferred, ...extra].map((key) => ({
    key,
    label: mfgLotLabels[key] ?? key,
    value: mfgLotValue(row[key]),
  }));
}
