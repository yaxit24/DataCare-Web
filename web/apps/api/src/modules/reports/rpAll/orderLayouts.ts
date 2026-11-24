import type { RpAllFilters } from './filters.js';
import type { RpAllColumn, RpAllLayout, RpAllRecord } from './types.js';

/**
 * The Order branch of RP_ALL: the seven buttons of PanelOrder (RP_ALL.cs:5219-5225).
 * Each button opens a Crystal template; the layouts below are read from the extracted
 * template XMLs and the desktop click handlers (RP_ALL.cs:8366-12663). Pure data only.
 */

export type OrderMode =
  'report' | 'advance' | 'adjust' | 'with-bill' | 'pending' | 'summary' | 'bill-wise';

export const ORDER_MODES: readonly OrderMode[] = [
  'report',
  'advance',
  'adjust',
  'with-bill',
  'pending',
  'summary',
  'bill-wise',
];

/** Filter keys the Order branch handlers actually append to the record-selection formula. */
export type OrderFilterKey = keyof Omit<RpAllFilters, 'fromDate' | 'toDate'>;

export interface OrderQueryShape {
  /** Which template record set the query reproduces (see orderQuery.ts). */
  kind: 'header' | 'lines' | 'adjust' | 'withBill' | 'billWise';
  /** Making Panding / Making Summ: only lines with DESIGN_ISU = 'N' (RP_ALL.cs:10940). */
  designPending?: boolean;
}

export interface OrderVariant {
  layout: RpAllLayout;
  query: OrderQueryShape;
  derive?: (record: RpAllRecord) => Record<string, number | string | null>;
  /**
   * Group-header formulas that are not sums (OrdAdjBillWise @PandingTot = ADV_AMT - Sum(@AdjAmt, VCH_NO)),
   * computed from a band's count-once totals. Applied to every band that prints totals.
   */
  bandFormulas?: (totals: Readonly<Record<string, number>>) => Record<string, number>;
  cite: string;
}

export interface OrderModeSpec {
  mode: OrderMode;
  /** Button caption, verbatim (ampersand access keys removed). */
  caption: string;
  filters: readonly OrderFilterKey[];
  variant: OrderVariant;
}

const n = (record: RpAllRecord, key: string): number => {
  const v = record[key];
  return typeof v === 'number' ? v : v === null || v === undefined || v === '' ? 0 : Number(v);
};

const col = (
  key: string,
  caption: string,
  kind: RpAllColumn['kind'],
  level: RpAllColumn['level'],
  extra: Partial<RpAllColumn> = {},
): RpAllColumn => ({ key, caption, kind, level, captionSource: 'template', ...extra });
/** An order is keyed by location, year, book and number (a 00 user may list every location). */
const ORDER_KEY = ['lcCode', 'coYear', 'coBook', 'vchNo'] as const;
/** An SL_ORD_ADJ row is keyed by its own voucher (order or bill) and serial; SR_NO alone repeats. */
const ADJ_KEY = ['adjLc', 'adjYear', 'adjBook', 'adjVchNo', 'adjSr'] as const;

const txt = (r: RpAllRecord, key: string): string | null => {
  const v = r[key];
  return v === null || v === undefined ? null : String(v);
};
/** Crystal string `+`/`&` of fields: NULL when any part is NULL (no default-value conversion). */
const concat = (r: RpAllRecord, keys: readonly string[]): string | null => {
  const parts = keys.map((k) => txt(r, k));
  return parts.some((x) => x === null) ? null : parts.join('');
};

// ---- Order Report (BtnOrdRpt, RP_ALL.cs:8366-8434) → OrdDetlRpt ----------------------------
// Group header: VCH_NO, VCH_DATE, AC_NAME, ADV_AMT, DEL_DATE; detail: the line; report footer
// Sum(ITM_PCS), Sum(ITM_NWT) "Total :".

const orderReportLayout: RpAllLayout = {
  template: 'OrdDetlRpt',
  titlePrefix: 'Order Report',
  // OrdDetlRpt.xml: group by SL_ORD_DATA.VCH_NO ascending, record sort AC_CODE.
  groups: [{ key: 'vchNo', labelKeys: ['vchNo'], subtotal: 'none' }],
  sort: [{ key: 'acCode' }],
  keys: { voucher: ORDER_KEY, line: ['srNo'] },
  rowLevels: ['voucher', 'line'],
  columns: [
    col('vchNo', 'Ord No', 'text', 'voucher'),
    col('vchDate', 'Ord Date', 'date', 'voucher'),
    col('acName', 'Customer Name', 'text', 'voucher'),
    col('advAmt', 'Advance Amt', 'money', 'voucher'),
    col('delDate', 'Del.Date', 'date', 'voucher'),
    col('itCode', 'It.Code', 'text', 'line'),
    col('itName', 'Item Name', 'text', 'line'),
    col('designNo', 'Design No', 'text', 'line'),
    col('itmSize', 'Size', 'text', 'line'),
    col('pcs', 'Pcs', 'pcs', 'line', { total: true }),
    col('nwt', 'Net Wt', 'weight', 'line', { total: true }),
    col('itmRate', 'ItemRate', 'rate', 'line'),
    col('itmAmt', 'ItemAmt', 'money', 'line'),
    col('lbrRate', 'LbrRate', 'rate', 'line'),
    col('lbrAmt', 'Lbr Amt', 'money', 'line'),
    col('othAmt', 'Other Amt', 'money', 'line'),
    col('netAmt', 'Net Amt', 'money', 'line'),
    col('rateFix', 'Rt Booked', 'text', 'line'),
  ],
  grandTotal: true,
  grandTotalCaption: 'Total :',
};

// ---- Order Advance (BtnOrdAdvance, RP_ALL.cs:8435-8500) → OrdAdvRpt ------------------------

const orderAdvanceLayout: RpAllLayout = {
  template: 'OrdAdvRpt',
  titlePrefix: 'Order Advance Report',
  // OrdAdvRpt.xml: group by SL_ORD_DATA.AC_NAME ascending, record sort AC_CODE.
  groups: [{ key: 'acName', labelKeys: ['acName'], subtotal: 'none' }],
  sort: [{ key: 'acCode' }],
  keys: { voucher: ORDER_KEY },
  rowLevels: ['voucher'],
  columns: [
    col('vchNo', 'Ord.No.', 'text', 'voucher'),
    col('vchDate', 'Ord.Date', 'date', 'voucher'),
    col('totAmt', 'Order Amt', 'money', 'voucher'),
    col('cashAmt', 'Cash Amt', 'money', 'voucher'),
    col('cardAmt', 'Card Amt', 'money', 'voucher'),
    col('chqAmt', 'Chq Amt', 'money', 'voucher'),
    col('oldGlAmt', 'OldGold', 'money', 'voucher'),
    col('oldSlAmt', 'Old Silver', 'money', 'voucher'),
    col('advAmt', 'Total Adv.', 'money', 'voucher'),
  ],
  // OrdAdvRpt.xml has no summary fields.
  grandTotal: false,
};

// ---- Order Adjust (BtnOrdAdj, RP_ALL.cs:8501-8566) → OrdAdvAdj -----------------------------
// The detail band (one adjustment row) is suppressed; each order prints as its @OrdGroup header with
// VCH_NO, VCH_DATE, AC_NAME and Sum(@OrdAmt), Sum(@OrdAdjAmt), Sum(@BalAmt); the report footer prints
// "TOTAL :" with the three grand sums.

const orderAdjustLayout: RpAllLayout = {
  template: 'OrdAdvAdj',
  titlePrefix: 'Order Adjust Report',
  groups: [{ key: 'ordGroup', labelKeys: ['vchNo', 'vchDate', 'acName'], subtotal: 'header' }],
  sort: [{ key: 'coYear' }, { key: 'vchDate' }, { key: 'vchNo' }],
  keys: { voucher: ORDER_KEY, line: ADJ_KEY },
  rowLevels: [],
  columns: [
    col('vchNo', 'Order No', 'text', 'voucher'),
    col('vchDate', 'Order Date', 'date', 'voucher'),
    col('acName', 'Name', 'text', 'voucher'),
    col('plusAmt', 'Order Adv', 'money', 'line', { total: true }),
    col('minusAmt', 'Order Adjust', 'money', 'line', { total: true }),
    col('balAmt', 'Panding Amt', 'money', 'line', { total: true }),
  ],
  grandTotal: true,
  grandTotalCaption: 'TOTAL :',
};

// ---- Order Wise Bill (BtnOrdWithBill, RP_ALL.cs:9727-9792) → OrdAdjBillWise ----------------
// Group 1 header: SL_ORD_DATA.AC_NAME. Group 2 header (VCH_NO): VCH_NO, VCH_DATE, ADV_AMT,
// Sum(@AdjAmt, VCH_NO), @PandingTot. Detail: SL_ORD_ADJ.CO_BOOK, VCH_NO, VCH_DATE, @AcName, SL_DATA.TOT_AMT,
// @AdjAmt. No report-footer sums.

const orderWiseBillLayout: RpAllLayout = {
  template: 'OrdAdjBillWise',
  titlePrefix: 'Bill Wise Order Adjust Report',
  groups: [
    { key: 'acName', labelKeys: ['acName'], subtotal: 'none' },
    { key: 'vchNo', labelKeys: ['vchNo', 'vchDate'], subtotal: 'header' },
  ],
  sort: [{ key: 'acCode' }],
  keys: { voucher: ORDER_KEY, line: ADJ_KEY },
  rowLevels: ['line'],
  columns: [
    col('vchNo', 'Ord.No.', 'text', 'voucher'),
    col('vchDate', 'Ord.Date', 'date', 'voucher'),
    col('advAmt', 'Total Adv.', 'money', 'voucher', { total: true }),
    col('adjBook', 'Book', 'text', 'line', { captionSource: 'field' }),
    col('adjVchNo', 'Vch No', 'text', 'line', { captionSource: 'field' }),
    col('adjVchDate', 'Vch Date', 'date', 'line', { captionSource: 'field' }),
    col('billParty', 'Bill Party Name', 'text', 'line'),
    col('billTotAmt', 'Bill Amt', 'money', 'line', { captionSource: 'field' }),
    col('adjAmt', 'Adjust Amt', 'money', 'line', { total: true }),
    col('pendingAmt', 'Panding Amt', 'money', 'voucher', { total: true }),
  ],
  grandTotal: false,
};

// ---- Making Panding (BtnOrdMakePan, RP_ALL.cs:10912-10995) → OrdDetlPanding ---------------
// Group header (@VchGroup): BOOK_SNAME, VCH_DATE, VCH_NO, AC_NAME, OLD_GL, ADV_AMT; detail: the line;
// report footer "Total :" Sum(ITM_PCS), Sum(ITM_NWT).

const orderPendingLayout: RpAllLayout = {
  template: 'OrdDetlPanding',
  titlePrefix: 'Order Design Issue Panding Report',
  groups: [{ key: 'vchGroup', labelKeys: ['bookSName', 'vchNo'], subtotal: 'none' }],
  sort: [{ key: 'acCode' }],
  keys: { voucher: ORDER_KEY, line: ['srNo'] },
  rowLevels: ['voucher', 'line'],
  columns: [
    col('bookSName', 'Book', 'text', 'voucher', { captionSource: 'field' }),
    col('vchDate', 'Ord Date', 'date', 'voucher'),
    col('vchNo', 'Ord No', 'text', 'voucher'),
    col('acName', 'Customer', 'text', 'voucher', { captionSource: 'field' }),
    col('oldGl', 'Old Gold', 'weight', 'voucher', { captionSource: 'field' }),
    col('advAmt', 'Advance', 'money', 'voucher', { captionSource: 'field' }),
    col('itCode', 'It.Code', 'text', 'line'),
    col('itName', 'Item Name', 'text', 'line'),
    col('design', 'Design No', 'text', 'line'),
    col('itmSize', 'Size', 'text', 'line'),
    col('pcs', 'Pcs', 'pcs', 'line', { total: true }),
    col('nwt', 'Net Wt', 'weight', 'line', { total: true }),
  ],
  grandTotal: true,
  grandTotalCaption: 'Total :',
};

// ---- Making Summ (BtnDesignSumm, RP_ALL.cs:11818-11923) → OrdDesignSumm -------------------
// Group header (@VchGroup = TAG_NO&DESIGN_NO): the @VchGroup text and its Sum(ITM_PCS), Sum(ITM_NWT);
// detail suppressed when @OnlySumm = "Y"; report footer "Total :".

const orderSummaryLayout = (onlySummary: boolean): RpAllLayout => ({
  template: 'OrdDesignSumm',
  titlePrefix: 'Order Design Issue Panding Report',
  groups: [{ key: 'vchGroup', labelKeys: ['vchGroup'], subtotal: 'header' }],
  sort: [{ key: 'acCode' }],
  keys: { voucher: ORDER_KEY, line: ['srNo'] },
  rowLevels: ['line'],
  columns: [
    col('design', 'Design No', 'text', 'line'),
    col('itName', 'Item Name', 'text', 'line'),
    col('bookSName', 'Book', 'text', 'line'),
    col('vchNo', 'Ord No', 'text', 'line'),
    col('vchDate', 'Ord Date', 'date', 'line'),
    col('acName', 'Customer', 'text', 'line', { captionSource: 'field' }),
    col('itmSize', 'Size', 'text', 'line'),
    col('pcs', 'Pcs', 'pcs', 'line', { total: true }),
    col('nwt', 'Net Wt', 'weight', 'line', { total: true }),
  ],
  grandTotal: true,
  grandTotalCaption: 'Total :',
  // OrdDesignSumm.xml:685 Section5 EnableSuppress "{@OnlySumm} = \"Y\"".
  suppress: { line: () => onlySummary },
});

// ---- Bill Wise Adjust (btnbillwiseordadj, RP_ALL.cs:12597-12663) → BillWiseOrderAdjust ----
// Group 1 header: SL_DATA.AC_NAME (grouped on SL_DATA.AC_CODE). Group 2 (@VchGroup, the bill) header:
// BOOK_NAME, VCH_NO, VCH_DATE, TOT_AMT, ADV_AMT. Detail: ORD_YRCD, ORD_DBCD, ORD_NO, the order party's
// AC_MAST.AC_NAME (via ORD_AC_CODE), ORD_AMT. No summary fields (D13).

const billWiseAdjustLayout: RpAllLayout = {
  template: 'BillWiseOrderAdjust',
  titlePrefix: 'Bill Wise Order Adjust Report',
  groups: [{ key: 'billAcCode', labelKeys: ['billAcName'], subtotal: 'none' }],
  // The bill band is the voucher row, ordered by @VchGroup within the party.
  sort: [{ key: 'billVchGroup' }],
  keys: { voucher: ['coCode', 'lcCode', 'coYear', 'coBook', 'vchNo'], line: ['adjSr'] },
  rowLevels: ['voucher', 'line'],
  columns: [
    col('billAcName', 'Bill Party Name', 'text', 'voucher'),
    col('bookName', 'Book', 'text', 'voucher', { captionSource: 'field' }),
    col('vchNo', 'Vch No', 'text', 'voucher'),
    col('vchDate', 'Vch Date', 'date', 'voucher'),
    col('billTotAmt', 'Bill Amt', 'money', 'voucher'),
    col('billAdvAmt', 'Adv Amt', 'money', 'voucher'),
    col('ordYrcd', 'Order Year', 'text', 'line', { captionSource: 'field' }),
    col('ordDbcd', 'Order Book', 'text', 'line', { captionSource: 'field' }),
    col('ordNo', 'Order No', 'text', 'line', { captionSource: 'field' }),
    col('orderPartyName', 'Order Party', 'text', 'line', { captionSource: 'field' }),
    col('ordAmt', 'Adv Amt', 'money', 'line'),
  ],
  grandTotal: false,
};

/** @Design = if DESIGN_NO = "" then TAG_NO else DESIGN_NO (OrdDetlPanding.xml, OrdDesignSumm.xml). */
const designOf = (r: RpAllRecord): string | null =>
  r.designNo === '' ? txt(r, 'tagNo') : txt(r, 'designNo');

/** @AcName of OrdAdjBillWise / BillWiseOrderAdjust: fixed texts for the cancel and cash-payment books. */
const billPartyOf = (r: RpAllRecord): string | null => {
  if (r.adjBook === '081') return 'ORDER CANCEL';
  if (r.adjBook === '001') return 'CASH PAYMENT';
  if (r.adjBook === '088') return txt(r, 'adjAcName');
  return txt(r, 'billPartyName');
};

const ALL_FILTERS: readonly OrderFilterKey[] = [
  'lcCode',
  'coBook',
  'acCode',
  'city',
  'area',
  'custName',
];

export const ORDER_SPECS: Readonly<Record<OrderMode, OrderModeSpec>> = {
  report: {
    mode: 'report',
    caption: 'Order Report',
    filters: ALL_FILTERS,
    variant: {
      layout: orderReportLayout,
      query: { kind: 'lines' },
      // OrdDetlRpt.xml @RateFix = ''.
      derive: () => ({ rateFix: '' }),
      cite: 'RP_ALL.cs:8366-8434; OrdDetlRpt.xml',
    },
  },
  advance: {
    mode: 'advance',
    caption: 'Order Advance',
    filters: ALL_FILTERS,
    variant: {
      layout: orderAdvanceLayout,
      query: { kind: 'header' },
      cite: 'RP_ALL.cs:8435-8500; OrdAdvRpt.xml',
    },
  },
  adjust: {
    mode: 'adjust',
    caption: 'Order Adjust',
    filters: ALL_FILTERS,
    variant: {
      layout: orderAdjustLayout,
      query: { kind: 'adjust' },
      // OrdAdvAdj.xml: @OrdAmt = if ORD_SIGN = '+' then ORD_AMT; @OrdAdjAmt = if ORD_SIGN = '-' then ORD_AMT;
      // @BalAmt = @OrdAmt - @OrdAdjAmt; @OrdGroup = ORD_LC+ORD_YRCD+ORD_DBCD+ORD_NO.
      derive: (r) => {
        const amt = n(r, 'ordAmt');
        const plusAmt = r.ordSign === '+' ? amt : 0;
        const minusAmt = r.ordSign === '-' ? amt : 0;
        return {
          ordGroup: concat(r, ['ordLc', 'ordYrcd', 'ordDbcd', 'ordNo']),
          plusAmt,
          minusAmt,
          balAmt: plusAmt - minusAmt,
        };
      },
      cite: 'RP_ALL.cs:8501-8566; OrdAdvAdj.xml',
    },
  },
  'with-bill': {
    mode: 'with-bill',
    caption: 'Order Wise Bill',
    filters: ALL_FILTERS,
    variant: {
      layout: orderWiseBillLayout,
      query: { kind: 'withBill' },
      // OrdAdjBillWise.xml: @AdjAmt = if ORD_SIGN = '-' then ORD_AMT; @AcName as billPartyOf.
      derive: (r) => ({
        adjAmt: r.ordSign === '-' ? n(r, 'ordAmt') : 0,
        billParty: billPartyOf(r),
      }),
      // @PandingTot = ADV_AMT - Sum(@AdjAmt, SL_ORD_DATA.VCH_NO).
      bandFormulas: (t) => ({ pendingAmt: (t.advAmt ?? 0) - (t.adjAmt ?? 0) }),
      cite: 'RP_ALL.cs:9727-9792; OrdAdjBillWise.xml',
    },
  },
  pending: {
    mode: 'pending',
    caption: 'Making Panding',
    filters: ALL_FILTERS,
    variant: {
      layout: orderPendingLayout,
      query: { kind: 'lines', designPending: true },
      derive: (r) => ({
        design: designOf(r),
        vchGroup: concat(r, ['coYear', 'coBook', 'vchNo']),
      }),
      cite: 'RP_ALL.cs:10912-10995; OrdDetlPanding.xml',
    },
  },
  summary: {
    mode: 'summary',
    caption: 'Making Summ',
    filters: ALL_FILTERS,
    variant: {
      // Layout depends on the Yes/No prompt answer; resolved at request time.
      layout: orderSummaryLayout(false),
      query: { kind: 'lines', designPending: true },
      derive: (r) => ({
        design: designOf(r),
        vchGroup: concat(r, ['tagNo', 'designNo']),
      }),
      cite: 'RP_ALL.cs:11818-11923; OrdDesignSumm.xml',
    },
  },
  'bill-wise': {
    mode: 'bill-wise',
    caption: 'Bill Wise Adjust',
    // RP_ALL.cs:12609-12632 appends location, book, party code, city, area and name, all on SL_DATA
    // except city/area on the order party's AC_MAST.
    filters: ALL_FILTERS,
    variant: {
      layout: billWiseAdjustLayout,
      query: { kind: 'billWise' },
      derive: (r) => ({
        billVchGroup: concat(r, ['coCode', 'lcCode', 'coYear', 'coBook', 'vchNo']),
      }),
      cite: 'RP_ALL.cs:12597-12663; BillWiseOrderAdjust.xml',
    },
  },
};

export function orderSummaryVariant(onlySummary: boolean): OrderVariant {
  return { ...ORDER_SPECS.summary.variant, layout: orderSummaryLayout(onlySummary) };
}
