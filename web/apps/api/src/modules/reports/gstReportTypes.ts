export type GstView = 'gstr1' | 'gstr2' | 'gstr3b';
export type GstSection =
  'B2B' | 'B2CL' | 'B2CS' | 'CDNR' | 'CDNUR' | 'EXP' | 'AT' | 'ATADJ' | 'EXEMP' | 'HSN' | 'DOCS';
/** RP_GST sections whose zoom builds the caption grid and returns before any query (EXP, EXEMP) or has no query (DOCS). */
export type HeaderOnlyGstSection = 'EXP' | 'EXEMP' | 'DOCS';

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
    /** RP_GST grid row 1 group captions, by column key, where the desktop sets them. */
    groupCaptions?: Readonly<Record<string, string>>;
    /** True when the desktop shows only the caption grid: no query, no rows and no "No Record Found...." message. */
    headerOnly?: boolean;
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

/** A desktop aggregate over no rows is NULL and `Strings.Format(NULL & "", "0.00")` prints a blank cell. */
export interface RawGstr3bAggregate extends RawGstr3bAmounts {
  rowCount: string;
}

export interface RawGstr3bStateRow {
  stateCode: string;
  stateName: string;
  taxable: string;
  igst: string;
}

export interface RawGstr3bResult {
  outward: RawGstr3bAggregate;
  reverseCharge: RawGstr3bAggregate;
  otherItc: RawGstr3bAggregate;
  /** 3.2(1): inter-state supplies to unregistered persons, one row per place of supply. */
  unregisteredInterState: RawGstr3bStateRow[];
}

export class GstReportRequestError extends Error {
  constructor(
    readonly code:
      | 'invalid-query'
      | 'invalid-view'
      | 'missing-section'
      | 'invalid-section'
      | 'section-not-supported'
      | 'csv-not-emitted'
      | 'csv-not-settled'
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
