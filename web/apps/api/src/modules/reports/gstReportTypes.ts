export type GstView = 'gstr1' | 'gstr2' | 'gstr3b';
export type GstSection = 'B2B' | 'B2CL' | 'B2CS' | 'CDNR' | 'CDNUR' | 'AT' | 'ATADJ' | 'HSN';
export type BlockedGstSection = 'EXP' | 'EXEMP' | 'DOCS' | 'TCS';

export interface GstReportScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
}

export interface GstReportInput extends GstReportScope {
  view: GstView;
  section?: GstSection;
  fromDate: string;
  toDate: string;
  bookCode?: string;
  partyCode?: string;
}

export interface GstColumn {
  key: string;
  header: string;
}

export type GstDisplayRow = Record<string, string>;

export interface GstReportResult {
  view: GstView;
  section: GstSection | null;
  title: string;
  fileName: string;
  columns: readonly GstColumn[];
  rows: GstDisplayRow[];
  totals: GstDisplayRow;
  metadata: {
    companyName?: string;
    fromDate?: string;
    toDate?: string;
    source: 'RP_GST';
    blockedSections?: readonly string[];
    blockedRows?: readonly string[];
    limitations?: readonly string[];
  };
}

export interface RawTaxReportRow {
  coBook: string;
  bookName: string;
  bookPrefix: string;
  acCode: string;
  acName: string;
  gstin: string;
  stateCode: string;
  stateName: string;
  voucherNo: string;
  voucherDate: string;
  invoiceValue: string;
  reverseCharge: string;
  taxRate: string;
  taxCode?: string;
  netAmount: string;
  discountAmount: string;
  billBookPrefix: string;
  billNo: string;
  billDate: string;
  srNo?: string;
}

export interface RawHsnReportRow {
  hsn: string;
  rateType: string;
  itemType: string;
  gstType: string;
  quantity: string;
  itemAmount: string;
  itemTax: string;
  itemDiscount: string;
}

export interface RawGstr3bAmounts {
  taxable: string;
  igst: string;
  cgst: string;
  sgst: string;
}

export interface RawGstr3bResult {
  outward: RawGstr3bAmounts;
  reverseCharge: RawGstr3bAmounts;
  otherItc: RawGstr3bAmounts;
}

export class GstReportRequestError extends Error {
  constructor(
    readonly code:
      | 'invalid-query'
      | 'invalid-view'
      | 'missing-section'
      | 'invalid-section'
      | 'section-not-supported'
      | 'invalid-date'
      | 'invalid-date-range'
      | 'date-outside-year'
      | 'scope-incomplete',
    readonly statusCode: 400 | 422,
    readonly details: Record<string, unknown> = {},
  ) {
    super(code);
    this.name = 'GstReportRequestError';
  }
}
