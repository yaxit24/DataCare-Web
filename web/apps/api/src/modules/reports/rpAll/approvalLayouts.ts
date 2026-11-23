import type { RpAllColumn, RpAllLayout, RpAllRecord } from './types.js';

/**
 * The Approval Rpt branch of RP_ALL: the three buttons of PanelApr (RP_ALL.cs:5132-5134), selected by the
 * "Approval Rpt" menu caption (RP_ALL.cs:6707-6711). Each button opens one Crystal template:
 *
 *   Approval Isu    → AprPartyWise  (RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}})
 *   Approval InOut  → AprInOut      (RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}})
 *   Approval Panding→ AprPan       (RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}})
 *
 * The groups, sorts, columns and totals below are read from extraction_output/rpt_xml/<Template>.xml; the
 * calculations live in those templates, not in the click handlers. Precision stays at the stored value —
 * there is no Round call in the three templates or handlers (study §Calculations). Pure data only; the
 * parameterised SQL lives in approvalQuery.ts.
 */

export type ApprovalMode = 'issue' | 'inout' | 'pending';
export const APPROVAL_MODES: readonly ApprovalMode[] = ['issue', 'inout', 'pending'];

/** Selector keys the approval click handlers append (RP_ALL.cs:8156-8192, 8231-8267, 8306-8342). */
export type ApprovalFilterKey =
  'lcCode' | 'coBook' | 'acCode' | 'prCode' | 'grCode' | 'city' | 'area' | 'itemType' | 'books';

export interface ApprovalModeSpec {
  mode: ApprovalMode;
  /** Button caption, verbatim with the ampersand removed (RP_ALL.cs:5165, 5191, 5217). */
  caption: string;
  /** Crystal template selected by the click handler. */
  template: string;
  /** RptTitel prefix, verbatim (RP_ALL.cs:8197, 8272, 8347). */
  titlePrefix: string;
  filters: readonly ApprovalFilterKey[];
  /** Pending selects exact N (RP_ALL.cs:8302); Issue and InOut append no ISU_REC predicate. */
  status: 'all' | 'N';
  layout: RpAllLayout;
  cite: string;
}

const col = (
  key: string,
  caption: string,
  kind: RpAllColumn['kind'],
  level: RpAllColumn['level'],
  extra: Partial<RpAllColumn> = {},
): RpAllColumn => ({ key, caption, kind, level, captionSource: 'template', ...extra });

const num = (record: RpAllRecord, key: string): number => {
  const v = record[key];
  return typeof v === 'number' ? v : v === null || v === undefined || v === '' ? 0 : Number(v);
};

const VOUCHER_KEY = ['coYear', 'coBook', 'vchNo'] as const;

// ---- Approval Isu → AprPartyWise -------------------------------------------------------------------------

/**
 * AprPartyWise groups AC_CODE → @Group (CO_YEAR+CO_BOOK+VCH_NO) then sorts SR_NO; voucher header and detail
 * rows, voucher footer then Party Total, and no grand-total field (AprPartyWise.xml:252, 256, 268). It sums
 * ITM_PCS, ITM_GWT, ITM_NWT, ITM_AMT, LBR_AMT and OTH_AMT at Group and AC_CODE; NET_AMT prints per detail
 * line only (AprPartyWise.xml:763) with no summary.
 */
const issueLayout: RpAllLayout = {
  template: 'AprPartyWise',
  titlePrefix: 'Party Wise Approval Issue',
  // Party footer Section10 prints "Party Total :" (Text20) and Sum (..., {APR_DETL.AC_CODE}); the voucher
  // footer Section9 prints Sum (..., {@Group}) with no caption; the voucher header Section7 prints
  // BOOK_DATA.BOOK_NAME, APR_DETL.VCH_NO and APR_DETL.VCH_DATE (AprPartyWise.xml Areas).
  groups: [
    {
      key: 'acCode',
      labelKeys: ['acCode', 'acName'],
      subtotal: 'footer',
      subtotalCaption: 'Party Total :',
    },
    { key: 'vchGroup', labelKeys: ['bookName', 'vchNo', 'vchDate'], subtotal: 'footer' },
  ],
  sort: [{ key: 'srNo' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'] },
  // One printed row per APR_DETL line; the voucher band carries the header values.
  rowLevels: ['line'],
  columns: [
    col('vchNo', 'Vch No', 'text', 'line'),
    col('vchDate', 'Date', 'date', 'line'),
    col('acName', 'Party_Name', 'text', 'line'),
    col('itemCode', 'It Code', 'text', 'line', { captionSource: 'field' }),
    col('itemName', 'Item Name', 'text', 'line', { captionSource: 'field' }),
    col('tagNo', 'Tag No', 'text', 'line'),
    // Sum ({APR_DETL.ITM_PCS}, {@Group}) and Sum ({APR_DETL.ITM_PCS}, {APR_DETL.AC_CODE}) both print.
    col('pcs', 'Pcs', 'pcs', 'line', { total: true }),
    col('grossWt', 'Gr Wt', 'weight', 'line', { total: true }),
    col('netWt', 'Net Wt', 'weight', 'line', { total: true }),
    col('itemAmount', 'ItmAmt', 'money', 'line', { total: true }),
    col('labourAmount', 'Lbr Amt', 'money', 'line', { total: true }),
    col('otherAmount', 'Oth Amt', 'money', 'line', { total: true }),
    col('netAmount', 'BillAmt', 'money', 'line'),
    col('acCode', 'Party Code', 'text', 'line'),
    col('bookName', 'Book', 'text', 'line'),
    col('srNo', 'Sr No', 'pcs', 'line'),
    col('status', 'Status', 'text', 'line'),
  ],
  // The report-footer band is empty (AprPartyWise has no grand-total field).
  grandTotal: false,
};

// ---- Approval InOut → AprInOut ---------------------------------------------------------------------------

/**
 * AprInOut groups AC_CODE → PR_CODE → VCH_DATE (OpDate) → TAG_NO and sorts VCH_DATE; product header sums,
 * tag and party footers, and a Grand Total (AprInOut.xml:271, 277, 342-369). TagPcs/TagGwt/TagNwt/TagOth
 * and OutPcs fire only on APR ISU; InPcs is ITM_PCS when ISU_REC='Y'; PanPcs = OutPcs − InPcs
 * (AprInOut.xml:293, 300, 304, 311-322). Legacy web 'R' also counts as resolved (D6).
 */
const inoutLayout: RpAllLayout = {
  template: 'AprInOut',
  titlePrefix: 'Approval In Out Report',
  groups: [
    {
      key: 'acCode',
      labelKeys: ['acCode', 'acName'],
      subtotal: 'footer',
      subtotalCaption: 'Party Total :',
    },
    { key: 'prCode', labelKeys: ['prCode', 'productName'], subtotal: 'header' },
    { key: 'vchDate', labelKeys: ['vchDate'], subtotal: 'none' },
    { key: 'tagNo', labelKeys: ['tagNo'], subtotal: 'footer' },
  ],
  sort: [{ key: 'vchDate' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'] },
  rowLevels: ['line'],
  columns: [
    col('vchNo', 'Vch No', 'text', 'line'),
    col('vchDate', 'Date', 'date', 'line'),
    col('acName', 'Party_Name', 'text', 'line'),
    // The tag footer Section9 prints ITEM_MAST.IT_NAME beside the voucher and tag (AprInOut.xml Areas).
    col('itemName', 'Item Name', 'text', 'line', { captionSource: 'field' }),
    col('pcs', 'Pcs', 'pcs', 'line', { total: true }),
    col('grossWt', 'Gr Wt', 'weight', 'line', { total: true }),
    col('netWt', 'Net Wt', 'weight', 'line', { total: true }),
    col('otherAmount', 'Oth Amt', 'money', 'line', { total: true }),
    col('outPcs', 'Out Pcs', 'pcs', 'line', { total: true }),
    col('inPcs', 'In Pcs', 'pcs', 'line', { total: true }),
    col('pendingPcs', 'Panding', 'pcs', 'line', { total: true }),
    col('acCode', 'Party Code', 'text', 'line'),
    col('prCode', 'Product', 'text', 'line'),
    col('productName', 'Product Name', 'text', 'line'),
    col('tagNo', 'Tag No', 'text', 'line'),
    col('srNo', 'Sr No', 'pcs', 'line'),
    col('status', 'Status', 'text', 'line'),
    col('bookName', 'Book', 'text', 'line'),
  ],
  grandTotal: true,
  // Text21 "Grand Total :" in the report footer.
  grandTotalCaption: 'Grand Total :',
};

// ---- Approval Panding → AprPan ---------------------------------------------------------------------------

/**
 * AprPan groups AC_CODE → VchGroup → PR_CODE → TAG_NO and sorts SR_NO; voucher header, product header sums,
 * tag and party footers, and a Grand Total (AprPan.xml:310, 316, 393-412). The selection forces APR ISU, so
 * the signed negative branch of TagPcs/TagGwt/TagNwt/TagOth cannot fire (RP_ALL.cs:8303). PanPcs is the raw
 * ITM_PCS (AprPan.xml:339). The tag footer is suppressed when Sum(PanPcs, Group)=0 (AprPan.xml:936) — that
 * hides the band only, never the two Z0 detail rows or the product/party/grand sums.
 */
const pendingLayout: RpAllLayout = {
  template: 'AprPan',
  titlePrefix: 'Panding Approval Report',
  groups: [
    {
      key: 'acCode',
      labelKeys: ['acCode', 'acName'],
      subtotal: 'footer',
      subtotalCaption: 'Party Total :',
    },
    // The voucher header Section15 prints APR_DETL.VCH_NO only; the group key stays @VchGroup.
    { key: 'vchGroup', labelKeys: ['vchNo'], subtotal: 'none' },
    { key: 'prCode', labelKeys: ['prCode', 'productName'], subtotal: 'header' },
    {
      key: 'tagNo',
      labelKeys: ['tagNo'],
      subtotal: 'footer',
      // AprPan.xml:936 {{EnableSuppress="Sum ({@PanPcs}, {@Group}) = 0"}}
      footerSuppressedWhen: (records) => records.every((r) => num(r, 'pendingPcs') === 0),
    },
  ],
  sort: [{ key: 'srNo' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'] },
  rowLevels: ['line'],
  columns: [
    col('vchNo', 'Vch No', 'text', 'line'),
    col('vchDate', 'Date', 'date', 'line'),
    col('tagNo', 'Tag No', 'text', 'line'),
    col('designNo', 'Design', 'text', 'line'),
    col('itemCode', 'It Code', 'text', 'line'),
    col('itemName', 'Item Name', 'text', 'line'),
    // Sum ({@TagPcs}, ...) prints at product, tag, party and report level (AprPan.xml:393-412).
    col('pcs', 'Pcs', 'pcs', 'line', { total: true }),
    col('grossWt', 'Gr Wt', 'weight', 'line', { total: true }),
    col('netWt', 'Net Wt', 'weight', 'line', { total: true }),
    col('otherAmount', 'Oth Amt', 'money', 'line', { total: true }),
    col('pendingPcs', 'Panding', 'pcs', 'line', { total: true }),
    col('acCode', 'Party Code', 'text', 'line'),
    col('acName', 'Party_Name', 'text', 'line'),
    col('prCode', 'Product', 'text', 'line'),
    col('srNo', 'Sr No', 'pcs', 'line'),
    col('status', 'Status', 'text', 'line'),
    col('bookName', 'Book', 'text', 'line'),
  ],
  grandTotal: true,
  // Text21 "Grand Total :" in the report footer.
  grandTotalCaption: 'Grand Total :',
};

export const APPROVAL_SPECS: Readonly<Record<ApprovalMode, ApprovalModeSpec>> = {
  issue: {
    mode: 'issue',
    caption: 'Approval Isu',
    template: 'AprPartyWise',
    titlePrefix: 'Party Wise Approval Issue',
    // RP_ALL.cs:8156-8184: location, book, party, product, city, area, item type, group.
    filters: ['lcCode', 'coBook', 'acCode', 'prCode', 'city', 'area', 'itemType', 'grCode'],
    status: 'all',
    layout: issueLayout,
    cite: 'RP_ALL.cs:8141-8215; AprPartyWise.xml',
  },
  inout: {
    mode: 'inout',
    caption: 'Approval InOut',
    template: 'AprInOut',
    titlePrefix: 'Approval In Out Report',
    filters: ['lcCode', 'coBook', 'acCode', 'prCode', 'city', 'area', 'itemType', 'grCode'],
    status: 'all',
    layout: inoutLayout,
    cite: 'RP_ALL.cs:8216-8290; AprInOut.xml',
  },
  pending: {
    mode: 'pending',
    caption: 'Approval Panding',
    template: 'AprPan',
    titlePrefix: 'Panding Approval Report',
    filters: ['lcCode', 'coBook', 'acCode', 'prCode', 'city', 'area', 'itemType', 'grCode'],
    status: 'N',
    layout: pendingLayout,
    cite: 'RP_ALL.cs:8291-8365; AprPan.xml',
  },
};

export function approvalMode(value: unknown): ApprovalMode {
  return value === 'inout' || value === 'pending' ? value : 'issue';
}

/** Book families the approval templates bind: desktop APR ISU, plus the provisioned legacy family (D6). */
export const APPROVAL_BOOK_FAMILIES = ['APR ISU', 'APPROVAL ISSUE'] as const;
/** InOut resolves a line on Y; the web Approval Return writer also closes it with legacy R (D6). */
export const APPROVAL_RESOLVED_STATUSES = ['Y', 'R'] as const;
