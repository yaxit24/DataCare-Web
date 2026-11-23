import type { RpAllFilters } from './filters.js';
import type { RpAllColumn, RpAllLayout, RpAllRecord } from './types.js';

/**
 * The Order branch of RP_ALL: the seven buttons of PanelOrder (RP_ALL.cs:5219-5225).
 * Each button opens a Crystal template; the layouts below are read from the extracted
 * template XMLs and the desktop click handlers (RP_ALL.cs:8366-12663). Pure data only.
 */

export type OrderMode =
  | 'report'
  | 'advance'
  | 'adjust'
  | 'with-bill'
  | 'pending'
  | 'summary'
  | 'bill-wise';

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
  /** Which base table drives the query. */
  base: 'SL_ORD_DATA' | 'SL_DATA';
  /** Whether the query reads order lines (SL_ORD_DETL). */
  lines: boolean;
  /** Whether the query reads adjustments (SL_ORD_ADJ). */
  adjustments: boolean;
  /** Whether the query needs the fully-adjusted exclusion (modes 5 and 6, D2). */
  fullyAdjustedExclusion: boolean;
}

export interface OrderVariant {
  layout: RpAllLayout;
  query: OrderQueryShape;
  derive?: (record: RpAllRecord) => Record<string, number | string | null>;
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
const derived = (
  key: string,
  caption: string,
  kind: RpAllColumn['kind'],
  level: RpAllColumn['level'],
) => col(key, caption, kind, level, { captionSource: 'field' });

const VOUCHER_KEY = ['coBook', 'vchNo'] as const;

// ---- Order Report (BtnOrdRpt, RP_ALL.cs:8366-8434) → OrdDetlRpt ----------------------------

const orderReportLayout: RpAllLayout = {
  template: 'OrdDetlRpt',
  titlePrefix: 'Order Report',
  // OrdDetlRpt.xml: group by SL_ORD_DATA.VCH_NO ascending.
  groups: [{ key: 'vchNo', labelKeys: ['vchNo'], subtotal: 'none' }],
  // OrdDetlRpt.xml: record sort AC_CODE ascending.
  sort: [{ key: 'acCode' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'] },
  rowLevels: ['line'],
  columns: [
    derived('vchNo', 'Ord No', 'text', 'voucher'),
    derived('vchDate', 'Ord Date', 'date', 'voucher'),
    derived('acName', 'Customer Name', 'text', 'voucher'),
    derived('advAmt', 'Advance Amt', 'money', 'voucher'),
    derived('delDate', 'Del.Date', 'date', 'voucher'),
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
};

// ---- Order Advance (BtnOrdAdvance, RP_ALL.cs:8435-8500) → OrdAdvRpt ------------------------

const orderAdvanceLayout: RpAllLayout = {
  template: 'OrdAdvRpt',
  titlePrefix: 'Order Advance Report',
  // OrdAdvRpt.xml: group by SL_ORD_DATA.AC_NAME ascending.
  groups: [{ key: 'acName', labelKeys: ['acName'], subtotal: 'none' }],
  sort: [{ key: 'acCode' }],
  keys: { voucher: VOUCHER_KEY },
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

const orderAdjustLayout: RpAllLayout = {
  template: 'OrdAdvAdj',
  titlePrefix: 'Order Adjust Report',
  // OrdAdvAdj.xml: group by @OrdGroup ascending.
  groups: [
    {
      key: 'ordGroup',
      labelKeys: ['vchNo'],
      subtotal: 'footer',
      subtotalCaption: 'TOTAL :',
    },
  ],
  sort: [{ key: 'coYear' }, { key: 'vchDate' }, { key: 'vchNo' }],
  keys: { voucher: VOUCHER_KEY, line: ['adjSr'] },
  rowLevels: ['line'],
  columns: [
    derived('vchNo', 'Order No', 'text', 'line'),
    derived('vchDate', 'Order Date', 'date', 'line'),
    derived('acName', 'Name', 'text', 'line'),
    col('ordSign', 'Sign', 'text', 'line'),
    col('ordAmt', 'Amount', 'money', 'line'),
    col('plusAmt', 'Order Adv', 'money', 'line', { total: true }),
    col('minusAmt', 'Order Adjust', 'money', 'line', { total: true }),
    col('balAmt', 'Panding Amt', 'money', 'line', { total: true }),
  ],
  grandTotal: true,
  grandTotalCaption: 'TOTAL :',
};

// ---- Order Wise Bill (BtnOrdWithBill, RP_ALL.cs:9727-9792) → OrdAdjBillWise ----------------

const orderWiseBillLayout: RpAllLayout = {
  template: 'OrdAdjBillWise',
  titlePrefix: 'Bill Wise Order Adjust Report',
  // OrdAdjBillWise.xml: groups by SL_ORD_DATA.AC_NAME then SL_ORD_DATA.VCH_NO.
  groups: [
    { key: 'acName', labelKeys: ['acName'], subtotal: 'none' },
    {
      key: 'vchNo',
      labelKeys: ['vchNo'],
      subtotal: 'footer',
      subtotalCaption: 'Total',
    },
  ],
  sort: [{ key: 'acCode' }],
  keys: { voucher: VOUCHER_KEY, line: ['adjSr'] },
  rowLevels: ['line'],
  columns: [
    derived('acName', 'Bill Party Name', 'text', 'line'),
    derived('vchNo', 'Ord.No.', 'text', 'line'),
    derived('vchDate', 'Ord.Date', 'date', 'line'),
    col('ordSign', 'Sign', 'text', 'line'),
    col('ordAmt', 'Total Adv.', 'money', 'line'),
    col('billNo', 'Bill No', 'text', 'line'),
    col('billTotAmt', 'Bill Amt', 'money', 'line'),
    col('adjAmt', 'Adjust Amt', 'money', 'line', { total: true }),
  ],
  // OrdAdjBillWise.xml has no grand total.
  grandTotal: false,
};

// ---- Making Panding (BtnOrdMakePan, RP_ALL.cs:10912-10995) → OrdDetlPanding ---------------

const orderPendingLayout: RpAllLayout = {
  template: 'OrdDetlPanding',
  titlePrefix: 'Order Design Issue Panding Report',
  // OrdDetlPanding.xml: group by @VchGroup = CO_YEAR&CO_BOOK&VCH_NO.
  groups: [
    {
      key: 'vchGroup',
      labelKeys: ['bookSName', 'vchDate', 'vchNo', 'acName'],
      subtotal: 'none',
    },
  ],
  sort: [{ key: 'acCode' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'] },
  rowLevels: ['line'],
  columns: [
    derived('bookSName', 'Book', 'text', 'voucher'),
    derived('vchDate', 'Ord Date', 'date', 'voucher'),
    derived('vchNo', 'Ord No', 'text', 'voucher'),
    derived('acName', 'Customer', 'text', 'voucher'),
    derived('oldGlAmt', 'Old Gold', 'money', 'voucher'),
    derived('advAmt', 'Advance', 'money', 'voucher'),
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

const orderSummaryLayout = (onlySummary: boolean): RpAllLayout => ({
  template: 'OrdDesignSumm',
  titlePrefix: 'Order Design Issue Panding Report',
  // OrdDesignSumm.xml: group by @VchGroup = TAG_NO&DESIGN_NO.
  groups: [
    {
      key: 'vchGroup',
      labelKeys: ['design'],
      subtotal: 'header',
    },
  ],
  sort: [{ key: 'acCode' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'] },
  rowLevels: ['line'],
  columns: [
    col('design', 'Design No', 'text', 'line'),
    col('itName', 'Item Name', 'text', 'line'),
    col('bookSName', 'Book', 'text', 'line'),
    col('vchNo', 'Ord No', 'text', 'line'),
    col('vchDate', 'Ord Date', 'date', 'line'),
    col('acName', 'Customer', 'text', 'line'),
    col('itmSize', 'Size', 'text', 'line'),
    col('pcs', 'Pcs', 'pcs', 'line', { total: true }),
    col('nwt', 'Net Wt', 'weight', 'line', { total: true }),
  ],
  grandTotal: true,
  grandTotalCaption: 'Total :',
  // OrdDesignSumm.xml Section5 EnableSuppress "{@OnlySumm} = \"Y\"".
  suppress: { line: () => onlySummary },
});

// ---- Bill Wise Adjust (btnbillwiseordadj, RP_ALL.cs:12597-12663) → BillWiseOrderAdjust ----

const billWiseAdjustLayout: RpAllLayout = {
  template: 'BillWiseOrderAdjust',
  titlePrefix: 'Bill Wise Order Adjust Report',
  // BillWiseOrderAdjust.xml: group by SL_DATA.AC_CODE then @VchGroup.
  groups: [
    { key: 'billAcCode', labelKeys: ['billAcName'], subtotal: 'none' },
    { key: 'billVchGroup', labelKeys: ['vchNo'], subtotal: 'none' },
  ],
  sort: [{ key: 'vchNo' }],
  keys: { voucher: ['coBook', 'vchNo'], line: ['adjSr'] },
  rowLevels: ['line'],
  columns: [
    derived('billAcName', 'Bill Party Name', 'text', 'line'),
    col('coBook', 'Book', 'text', 'line'),
    col('vchNo', 'Vch No', 'text', 'line'),
    col('vchDate', 'Date', 'date', 'line'),
    col('billTotAmt', 'Bill Amt', 'money', 'line'),
    col('ordYrcd', 'Order Year', 'text', 'line'),
    col('ordDbcd', 'Order Book', 'text', 'line'),
    col('ordNo', 'Order No', 'text', 'line'),
    col('orderAcName', 'Order Party', 'text', 'line'),
    col('adjAmt', 'Adv Amt', 'money', 'line'),
  ],
  // BillWiseOrderAdjust.xml has no summary fields (D13).
  grandTotal: false,
};

const designOf = (r: RpAllRecord): string =>
  (r.designNo === '' || r.designNo === null ? r.tagNo : r.designNo) as string;

export const ORDER_SPECS: Readonly<Record<OrderMode, OrderModeSpec>> = {
  report: {
    mode: 'report',
    caption: 'Order Report',
    filters: ['lcCode', 'coBook', 'acCode', 'city', 'area', 'custName'],
    variant: {
      layout: orderReportLayout,
      query: {
        base: 'SL_ORD_DATA',
        lines: true,
        adjustments: false,
        fullyAdjustedExclusion: false,
      },
      cite: 'RP_ALL.cs:8366-8434; OrdDetlRpt.xml',
    },
  },
  advance: {
    mode: 'advance',
    caption: 'Order Advance',
    filters: ['lcCode', 'coBook', 'acCode', 'city', 'area', 'custName'],
    variant: {
      layout: orderAdvanceLayout,
      query: {
        base: 'SL_ORD_DATA',
        lines: false,
        adjustments: false,
        fullyAdjustedExclusion: false,
      },
      cite: 'RP_ALL.cs:8435-8500; OrdAdvRpt.xml',
    },
  },
  adjust: {
    mode: 'adjust',
    caption: 'Order Adjust',
    filters: ['lcCode', 'coBook', 'acCode', 'city', 'area', 'custName'],
    variant: {
      layout: orderAdjustLayout,
      query: {
        base: 'SL_ORD_DATA',
        lines: false,
        adjustments: true,
        fullyAdjustedExclusion: false,
      },
      // OrdAdvAdj.xml formulas @OrdAmt, @OrdAdjAmt, @BalAmt.
      derive: (r) => {
        const amt = n(r, 'ordAmt');
        const isPlus = r.ordSign === '+';
        return {
          ordGroup: `${r.ordLc ?? ''}${r.ordYrcd ?? ''}${r.ordDbcd ?? ''}${r.ordNo ?? ''}`,
          plusAmt: isPlus ? amt : 0,
          minusAmt: isPlus ? 0 : amt,
          balAmt: isPlus ? amt : -amt,
        };
      },
      cite: 'RP_ALL.cs:8501-8566; OrdAdvAdj.xml',
    },
  },
  'with-bill': {
    mode: 'with-bill',
    caption: 'Order Wise Bill',
    filters: ['lcCode', 'coBook', 'acCode', 'city', 'area', 'custName'],
    variant: {
      layout: orderWiseBillLayout,
      query: {
        base: 'SL_ORD_DATA',
        lines: false,
        adjustments: true,
        fullyAdjustedExclusion: false,
      },
      // OrdAdjBillWise.xml formula @AdjAmt counts minus rows only.
      derive: (r) => ({
        adjAmt: r.ordSign === '-' ? n(r, 'ordAmt') : 0,
      }),
      cite: 'RP_ALL.cs:9727-9792; OrdAdjBillWise.xml',
    },
  },
  pending: {
    mode: 'pending',
    caption: 'Making Panding',
    filters: ['lcCode', 'coBook', 'acCode', 'city', 'area', 'custName'],
    variant: {
      layout: orderPendingLayout,
      query: {
        base: 'SL_ORD_DATA',
        lines: true,
        adjustments: false,
        fullyAdjustedExclusion: true,
      },
      // OrdDetlPanding.xml formula @Design = DESIGN_NO else TAG_NO.
      derive: (r) => ({
        design: designOf(r),
        vchGroup: `${r.coYear ?? ''}${r.coBook ?? ''}${r.vchNo ?? ''}`,
      }),
      cite: 'RP_ALL.cs:10912-10995; OrdDetlPanding.xml',
    },
  },
  summary: {
    mode: 'summary',
    caption: 'Making Summ',
    filters: ['lcCode', 'coBook', 'acCode', 'city', 'area', 'custName'],
    variant: {
      // Layout depends on the Yes/No prompt answer; resolved at request time.
      layout: orderSummaryLayout(false),
      query: {
        base: 'SL_ORD_DATA',
        lines: true,
        adjustments: false,
        fullyAdjustedExclusion: true,
      },
      derive: (r) => ({
        design: designOf(r),
        vchGroup: `${r.tagNo ?? ''}${r.designNo ?? ''}`,
      }),
      cite: 'RP_ALL.cs:11818-11923; OrdDesignSumm.xml',
    },
  },
  'bill-wise': {
    mode: 'bill-wise',
    caption: 'Bill Wise Adjust',
    filters: ['lcCode', 'custName'],
    variant: {
      layout: billWiseAdjustLayout,
      query: {
        base: 'SL_DATA',
        lines: false,
        adjustments: true,
        fullyAdjustedExclusion: false,
      },
      // BillWiseOrderAdjust.xml prints the raw adjustment amount (D13).
      derive: (r) => ({
        billVchGroup: `${r.coCode ?? ''}${r.lcCode ?? ''}${r.coYear ?? ''}${r.coBook ?? ''}${r.vchNo ?? ''}`,
        adjAmt: n(r, 'ordAmt'),
      }),
      cite: 'RP_ALL.cs:12597-12663; BillWiseOrderAdjust.xml',
    },
  },
};

export function orderSummaryVariant(onlySummary: boolean): OrderVariant {
  return { ...ORDER_SPECS.summary.variant, layout: orderSummaryLayout(onlySummary) };
}
