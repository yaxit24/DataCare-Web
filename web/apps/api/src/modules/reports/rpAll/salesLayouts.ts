import { round } from '@datacare/core';
import type { RpAllFilters } from './filters.js';
import type { RpAllColumn, RpAllLayout, RpAllRecord } from './types.js';

/**
 * The Sales branch of RP_ALL: the buttons of PanelSale (RP_ALL.cs:4364-4378, shown when the menu caption
 * is "Sales Report", :6676-6698) whose output is a report over the sales tables, each with the template
 * the desktop opens and the filters its click handler appends. Every layout below is read from the
 * extracted template (extraction_output/rpt_xml/<Template>.xml): groups, sort, band captions, the bound
 * fields per band and the totals. docs/parity/rpall-sales-inventory.md is the cited inventory.
 *
 * Pure data and pure functions only; the SQL lives in salesQuery.ts.
 */

export type SalesMode = 'report' | 'register' | 'item' | 'group' | 'employee' | 'with-order';
export const SALES_MODES: readonly SalesMode[] = [
  'report',
  'register',
  'item',
  'group',
  'employee',
  'with-order',
];

/** Filter keys of the shared selector panel (filters.ts). */
export type SalesFilterKey = keyof Omit<RpAllFilters, 'fromDate' | 'toDate'>;

/** Shape of the read the adapter performs for a variant. */
export interface SalesQueryShape {
  /** 'header' reads SL_DATA (+ lines); 'detail' reads SL_DETL alone (Sale With Order). */
  from: 'header' | 'detail';
  lines: 'SL_DETL' | 'SL_DETL_RTN' | null;
  subs: 'SL_IDTL' | 'BAR_IDTL' | null;
  /** Amount predicate of the base formula: NET_AMT <> 0, RTN_NET_AMT <> 0, or none. */
  guard: 'NET_AMT' | 'RTN_NET_AMT' | null;
}

export interface SalesVariant {
  layout: RpAllLayout;
  query: SalesQueryShape;
  /** Formula fields computed from the record (Crystal @formulas), pure. */
  derive?: (record: RpAllRecord) => Record<string, number | string | null>;
  /** Source lines of the click handler and template, for the inventory and the PR. */
  cite: string;
}

export interface SalesModeSpec {
  mode: SalesMode;
  /** Button caption, verbatim (ampersand access keys removed). */
  caption: string;
  /** Filters the click handler appends to the record-selection formula. */
  filters: readonly SalesFilterKey[];
  /**
   * Filters the handler appends on a table the template does not contain (AC_MAST is not in SalesItem,
   * SalesRtnItem or SalesGroupWise). Crystal cannot resolve such a field, so the desktop cannot produce
   * that report; the web refuses the combination instead of guessing a result.
   */
  templateLacks: readonly SalesFilterKey[];
  /** Yes/No prompt that switches to the return variant ("Sales Return (Creditnote) Report"). */
  returnPrompt: boolean;
  /** Yes/No prompt "Only Item Sales With Order" (Sale With Order only, RP_ALL.cs:11749). */
  orderPrompt: boolean;
  sale: SalesVariant;
  ret?: SalesVariant;
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

const VOUCHER_KEY = ['lcCode', 'coBook', 'vchNo'] as const;

/** @ItemType of SalesItem / SalesGroupWise: G → GOLD, S → SILVER, anything else OTHER. */
const ITEM_TYPE_LABELS = { G: 'GOLD', S: 'SILVER' } as const;

// ---- Sales Report (BtnSlRpt, RP_ALL.cs:7572-7678) → SaleReport / SaleRtnReport ----------------------------

const saleReportLayout = (ret: boolean): RpAllLayout => ({
  template: ret ? 'SaleRtnReport' : 'SaleReport',
  titlePrefix: ret ? 'Sales Return Report' : 'Sales Report',
  groups: [{ key: 'coBook', labelKeys: ['coBook', 'bookName'], subtotal: 'none' }],
  sort: [{ key: 'vchGroup' }, { key: 'srNo' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'], sub: ['subSrNo'] },
  rowLevels: ['voucher', 'line', 'sub'],
  columns: [
    derived('vchDate', 'Date', 'date', 'voucher'),
    derived('vchNo', 'Vch No', 'text', 'voucher'),
    derived('acName', 'Party', 'text', 'voucher'),
    col('itmAmt', 'Net Amt', 'money', 'voucher', { total: true }),
    col('discAmt', 'Disc', 'money', 'voucher', { total: !ret }),
    col('taxAmt', 'Tax', 'money', 'voucher', { total: true }),
    col('vchAmt', 'Bill Tot', 'money', 'voucher', { total: true }),
    ...(ret ? [] : [col('rofAmt', 'Rof Amt', 'money', 'voucher')]),
    col('tagNo', 'Tag No', 'text', 'line'),
    col('itName', 'Item Code & Name', 'text', 'line'),
    col('pcs', 'Pcs', 'pcs', 'line', { total: true }),
    col('gwt', 'GrossWt', 'weight', 'line', { total: true }),
    col('nwt', 'Net Wt', 'weight', 'line', { total: true }),
    col('rate', 'Rate', 'rate', 'line'),
    col('lbrRate', 'L.Rate', 'rate', 'line'),
    col('lbrAmt', 'LbrAmt', 'money', 'line', { total: true }),
    col('lineNetAmt', 'Net Amt', 'money', 'line'),
    derived('subItName', 'Item Code & Name', 'text', 'sub'),
    derived('subPcs', 'Pcs', 'pcs', 'sub'),
    derived('subGwt', 'GrossWt', 'weight', 'sub'),
    derived('subRate', 'Rate', 'rate', 'sub'),
    derived('subNetAmt', 'Net Amt', 'money', 'sub'),
  ],
  grandTotal: true,
  // SaleReport Section6 / SaleRtnReport Section6: EnableSuppress "{SL_DETL.OTH_AMT} = 0".
  suppress: { sub: (r) => n(r, 'othAmt') === 0 },
});

// ---- Sales Reg (BtnSalesReg, RP_ALL.cs:7722-7824) → SalesSumm / SalesRtnSumm -------------------------------

const salesSummLayout: RpAllLayout = {
  template: 'SalesSumm',
  titlePrefix: 'Sales Register Report',
  groups: [
    {
      key: 'vchDate',
      labelKeys: ['vchDate'],
      subtotal: 'footer',
      subtotalCaption: 'DATE TOTAL :',
    },
  ],
  sort: [{ key: 'vchNo' }, { key: 'srNo' }, { key: 'coBook' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'] },
  rowLevels: ['voucher', 'line'],
  columns: [
    col('vchNo', 'BIL_NO', 'text', 'voucher'),
    col('vchDate', 'BIL_DATE', 'date', 'voucher'),
    col('partyName', 'AC NAME', 'text', 'voucher'),
    col('city', 'City', 'text', 'voucher'),
    col('mobile', 'Mobile', 'text', 'voucher'),
    col('panNo', 'Pan No', 'text', 'voucher'),
    col('gstNo', 'GST No', 'text', 'voucher'),
    col('netAmt', 'Net AMT', 'money', 'voucher', { total: true }),
    col('cgstTax', 'CGST', 'money', 'voucher', { total: true }),
    col('sgstTax', 'SGST', 'money', 'voucher', { total: true }),
    col('totAmt', 'TOT_AMT', 'money', 'voucher', { total: true }),
    col('cashAmt', 'CASH', 'money', 'voucher', { total: true }),
    col('chqAmt', 'Bank', 'money', 'voucher', { total: true }),
    col('advAmt', 'Les:Adv', 'money', 'voucher', { total: true }),
    col('oldGlAmt', 'Old Gold', 'money', 'voucher', { total: true }),
    col('oldSlAmt', 'Old Sl', 'money', 'voucher', { total: true }),
    col('kasarAmt', 'Kasar', 'money', 'voucher', { total: true }),
    col('billOs', 'Os Amt', 'money', 'voucher', { total: true }),
    col('itName', 'Product Name', 'text', 'line'),
    col('nwt', 'Net Wt', 'weight', 'line', { total: true }),
  ],
  grandTotal: true,
  grandTotalCaption: 'GRAND TOTAL :',
};

const salesRtnSummLayout: RpAllLayout = {
  template: 'SalesRtnSumm',
  titlePrefix: 'Sales Return Register Report',
  groups: [
    {
      key: 'vchDate',
      labelKeys: ['vchDate'],
      subtotal: 'footer',
      subtotalCaption: 'DATE TOTAL :',
    },
  ],
  sort: [{ key: 'coBook' }],
  keys: { voucher: VOUCHER_KEY },
  rowLevels: ['voucher'],
  columns: [
    col('coBook', 'BK', 'text', 'voucher'),
    col('vchNo', 'BIL_NO', 'text', 'voucher'),
    col('vchDate', 'BIL_DATE', 'date', 'voucher'),
    col('partyName', 'AC NAME', 'text', 'voucher'),
    col('rtnTotAmt', 'TOT_AMT', 'money', 'voucher', { total: true }),
    col('rtnCashAmt', 'CASH', 'money', 'voucher', { total: true }),
    col('rtnCardAmt', 'CARD', 'money', 'voucher', { total: true }),
    col('rtnChqAmt', 'Bank', 'money', 'voucher', { total: true }),
    col('rtnKasarAmt', 'Kasar', 'money', 'voucher', { total: true }),
    col('rtnBillOs', 'Os Amt', 'money', 'voucher', { total: true }),
  ],
  grandTotal: true,
  grandTotalCaption: 'GRAND TOTAL :',
};

// ---- Item Wise (BtnSalesItem, RP_ALL.cs:7826-7940) → SalesItem / SalesRtnItem; Group Sales → SalesGroupWise --

const itemColumns: RpAllColumn[] = [
  col('vchDate', 'Bill Date', 'date', 'line'),
  col('vchNo', 'Vch No', 'text', 'line'),
  col('billNo', 'Bill No', 'text', 'line'),
  col('acName', 'Party Name', 'text', 'line'),
  col('nwt', 'Net Weight', 'weight', 'line', { total: true }),
  col('rate', 'Rate', 'rate', 'line'),
  col('itmAmtLine', 'Item Amt', 'money', 'line', { total: true }),
  col('lbrAmt', 'Labour', 'money', 'line', { total: true }),
  col('othAmt', 'Other', 'money', 'line', { total: true }),
  col('lineNetAmt', 'Net Amt', 'money', 'line', { total: true }),
  col('mrp', 'MRP', 'money', 'line', { total: true }),
  col('itmTotAmt', 'Total Amt', 'money', 'line', { total: true }),
];

const itemLayout = (
  template: string,
  titlePrefix: string,
  second: 'prCode' | 'grCode',
  rows: boolean,
): RpAllLayout => ({
  template,
  titlePrefix,
  groups: [
    {
      key: 'itType',
      labelKeys: ['itType'],
      subtotal: 'header',
      labelMap: ITEM_TYPE_LABELS,
      labelDefault: 'OTHER',
    },
    {
      key: second,
      labelKeys: [second === 'prCode' ? 'prName' : 'grName'],
      subtotal: 'header',
    },
  ],
  sort: [{ key: 'vchDate' }, { key: 'acCode' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'] },
  // SalesGroupWise suppresses its detail band (Section8), so it prints only the group bands.
  rowLevels: rows ? ['line'] : [],
  columns: itemColumns,
  grandTotal: true,
  grandTotalCaption: 'Total:',
});

// ---- Employ Sales (btnEmpRpt, RP_ALL.cs:9135-9206) → EmpSaleReport -----------------------------------------

const empLayout: RpAllLayout = {
  template: 'EmpSaleReport',
  titlePrefix: 'Salesman Wise Report',
  groups: [
    {
      key: 'empCode',
      labelKeys: ['empCode', 'empName'],
      subtotal: 'footer',
      subtotalCaption: 'Total :',
    },
  ],
  // Groups 2-4 of the template (VCH_DATE, @VchGroup, @SrNo) print no subtotal, so they are sort keys here.
  sort: [{ key: 'vchDate' }, { key: 'vchGroup' }, { key: 'srNo' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'], sub: ['subSrNo'] },
  rowLevels: ['voucher', 'sub'],
  columns: [
    col('bookSName', 'Book', 'text', 'voucher'),
    col('vchDate', 'Vch Date', 'date', 'voucher'),
    col('vchNo', 'Vch No', 'text', 'voucher'),
    col('acName', 'Name', 'text', 'voucher'),
    col('totAmt', 'Bill Amount', 'money', 'voucher', { total: true }),
    col('kasarAmt', 'Kasar Amt', 'money', 'voucher', { total: true }),
    col('vchAmt', 'Net Amount', 'money', 'voucher', { total: true }),
    derived('subPcs', 'Pcs', 'pcs', 'sub'),
    derived('subGwt', 'Gross Wt', 'weight', 'sub'),
    derived('subRate', 'Rate', 'rate', 'sub'),
    derived('subNetAmt', 'Net Amt', 'money', 'sub'),
  ],
  // The report footer (Section10) is suppressed: only the per-employee "Total :" band prints.
  grandTotal: false,
  // Section6: EnableSuppress "{SL_DETL.IT_CODE} = ''".
  suppress: { sub: (r) => (r.itCode ?? '') === '' },
};

// ---- Sale With Order (btnSlWithOrder, RP_ALL.cs:11735-11816) → SalesWithOrder -----------------------------

const withOrderLayout: RpAllLayout = {
  template: 'SalesWithOrder',
  titlePrefix: 'Sales With Order Report',
  // The VCH_DATE group header and footer are suppressed (Section4, Section10): a sort key only.
  groups: [],
  sort: [{ key: 'vchDate' }, { key: 'itCode' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'] },
  rowLevels: ['line'],
  columns: [
    col('vchType', 'VchType', 'text', 'line'),
    col('vchDate', 'Date', 'date', 'line'),
    col('vchNo', 'VchNo', 'text', 'line'),
    col('partyName', 'Party Name', 'text', 'line'),
    col('ordNo', 'Ord No', 'text', 'line'),
    col('ordYrcd', 'Ord Year', 'text', 'line'),
    col('ordDbcd', 'Book', 'text', 'line'),
    col('tagNo', 'Tag No', 'text', 'line'),
    col('itName', 'Item Name', 'text', 'line'),
    col('pcs', 'Pcs', 'pcs', 'line', { total: true }),
    col('gwt', 'Gross Wt', 'weight', 'line', { total: true }),
    col('nwt', 'Net Wt', 'weight', 'line', { total: true }),
    col('lineNetAmt', 'Net amt', 'money', 'line', { total: true }),
  ],
  grandTotal: true,
  grandTotalCaption: 'GRAND TOTAL :',
};

const vchGroup = (r: RpAllRecord) => `${r.coBook ?? ''}${r.vchNo ?? ''}`;

export const SALES_SPECS: Readonly<Record<SalesMode, SalesModeSpec>> = {
  report: {
    mode: 'report',
    caption: 'Sales Report',
    filters: [
      'lcCode',
      'coBook',
      'acCode',
      'city',
      'area',
      'state',
      'empCode',
      'books',
      'itemType',
    ],
    templateLacks: [],
    returnPrompt: true,
    orderPrompt: false,
    sale: {
      layout: saleReportLayout(false),
      query: { from: 'header', lines: 'SL_DETL', subs: 'SL_IDTL', guard: 'NET_AMT' },
      // @ItmAmt = NET_AMT, @DiscAmt = DISC_AMT, @TaxAmt = TAX_AMT, @VchAmt = TOT_AMT, @VchGroup = CO_BOOK+VCH_NO.
      derive: (r) => ({
        vchGroup: vchGroup(r),
        itmAmt: n(r, 'netAmt'),
        vchAmt: n(r, 'totAmt'),
      }),
      cite: 'RP_ALL.cs:7584,7603-7610,7618-7665; SaleReport.xml',
    },
    ret: {
      layout: saleReportLayout(true),
      query: { from: 'header', lines: 'SL_DETL_RTN', subs: 'BAR_IDTL', guard: 'RTN_NET_AMT' },
      // SaleRtnReport: @ItmAmt = RTN_NET_AMT, @DiscAmt = 0, @TaxAmt = TAX_AMT, @VchAmt = RTN_TOT_AMT.
      derive: (r) => ({
        vchGroup: vchGroup(r),
        itmAmt: n(r, 'rtnNetAmt'),
        discAmt: 0,
        vchAmt: n(r, 'rtnTotAmt'),
      }),
      cite: 'RP_ALL.cs:7584-7597,7620-7665; SaleRtnReport.xml',
    },
  },
  register: {
    mode: 'register',
    caption: 'Sales Reg',
    filters: ['lcCode', 'coBook', 'acCode', 'city', 'area', 'state', 'empCode', 'books'],
    templateLacks: [],
    returnPrompt: true,
    orderPrompt: false,
    sale: {
      layout: salesSummLayout,
      query: { from: 'header', lines: 'SL_DETL', subs: null, guard: 'NET_AMT' },
      cite: 'RP_ALL.cs:7734,7753-7760,7768-7809; SalesSumm.xml',
    },
    ret: {
      layout: salesRtnSummLayout,
      query: { from: 'header', lines: null, subs: null, guard: 'RTN_NET_AMT' },
      cite: 'RP_ALL.cs:7734-7747,7771-7809; SalesRtnSumm.xml',
    },
  },
  item: {
    mode: 'item',
    caption: 'Item Wise',
    filters: [
      'lcCode',
      'coBook',
      'acCode',
      'prCode',
      'city',
      'area',
      'state',
      'itemType',
      'grCode',
      'empCode',
      'books',
    ],
    templateLacks: ['city', 'area', 'state'],
    returnPrompt: true,
    orderPrompt: false,
    sale: {
      layout: itemLayout('SalesItem', 'Item Wise Sales Report', 'prCode', true),
      query: { from: 'header', lines: 'SL_DETL', subs: null, guard: 'NET_AMT' },
      // @ItmTotAmt = SL_DETL.TOT_AMT.
      derive: (r) => ({ itmTotAmt: n(r, 'lineTotAmt') }),
      cite: 'RP_ALL.cs:7838,7857-7864,7872-7925; SalesItem.xml',
    },
    ret: {
      layout: itemLayout('SalesRtnItem', 'Item Wise Sales Return Report', 'prCode', true),
      query: { from: 'header', lines: 'SL_DETL_RTN', subs: null, guard: 'RTN_NET_AMT' },
      // SalesRtnItem: @ItmTotAmt = SL_DETL_RTN.NET_AMT.
      derive: (r) => ({ itmTotAmt: n(r, 'lineNetAmt') }),
      cite: 'RP_ALL.cs:7838-7851,7875-7925; SalesRtnItem.xml',
    },
  },
  group: {
    mode: 'group',
    caption: 'Group Sales',
    filters: [
      'lcCode',
      'coBook',
      'acCode',
      'prCode',
      'city',
      'area',
      'state',
      'itemType',
      'grCode',
      'empCode',
      'books',
    ],
    templateLacks: ['city', 'area', 'state'],
    returnPrompt: false,
    orderPrompt: false,
    sale: {
      layout: itemLayout('SalesGroupWise', 'Item Group Sales Report', 'grCode', false),
      query: { from: 'header', lines: 'SL_DETL', subs: null, guard: 'NET_AMT' },
      // @ItmTotAmt = SL_DETL.NET_AMT + SL_DETL.IT_TAX_AMT - SL_DETL.IT_DISC_AMT.
      derive: (r) => ({
        itmTotAmt: round(n(r, 'lineNetAmt') + n(r, 'itTaxAmt') - n(r, 'itDiscAmt'), 6),
      }),
      cite: 'RP_ALL.cs:11928-12018; SalesGroupWise.xml',
    },
  },
  employee: {
    mode: 'employee',
    caption: 'Employ Sales',
    filters: ['lcCode', 'coBook', 'acCode', 'city', 'area', 'state', 'empCode', 'books'],
    templateLacks: [],
    returnPrompt: false,
    orderPrompt: false,
    sale: {
      layout: empLayout,
      // No amount guard: the formula is company, year and dates only (RP_ALL.cs:9146).
      query: { from: 'header', lines: 'SL_DETL', subs: 'SL_IDTL', guard: null },
      // @VchAmt = TOT_AMT - KASAR_AMT; @VchGroup = CO_BOOK + VCH_NO.
      derive: (r) => ({
        vchGroup: vchGroup(r),
        vchAmt: round(n(r, 'totAmt') - n(r, 'kasarAmt'), 6),
      }),
      cite: 'RP_ALL.cs:9135-9206; EmpSaleReport.xml',
    },
  },
  'with-order': {
    mode: 'with-order',
    caption: 'Sale With Order',
    filters: [
      'lcCode',
      'coBook',
      'acCode',
      'city',
      'area',
      'itemType',
      'prCode',
      'grCode',
      'books',
    ],
    templateLacks: [],
    returnPrompt: false,
    orderPrompt: true,
    sale: {
      layout: withOrderLayout,
      query: { from: 'detail', lines: 'SL_DETL', subs: null, guard: null },
      cite: 'RP_ALL.cs:11735-11816; SalesWithOrder.xml',
    },
  },
};

/** The Sales Report buttons this phase does not serve yet, with the reason (inventory §5). */
export const SALES_NOT_YET: Readonly<Record<string, string>> = {
  'Sales Bill': 'prints the PRINT_MAST-selected bill template per voucher (RP_ALL.cs:9005-9133)',
  'Cash/Bank Bill': 'CASH_DATA receipts by book (RP_ALL.cs:9797-9895)',
  'Wh Sales': 'RATE_CUT_ISU / RATE_CUT_REC staging (RP_ALL.cs:8913-9003)',
  'Wh Summ': 'RATE_CUT_DATA bill print or RATE_CUT staging summary (RP_ALL.cs:10996-11202)',
  'Emp  WhSales': 'RATE_CUT_ISU staging by employee (RP_ALL.cs:11265-11353)',
  'Counter Sales': 'MAIN_STOCK TR_TYPE S by counter (RP_ALL.cs:11658-11733)',
  'Labour Work': 'LBR_ISU_DETL / LBR_REC_DETL staging (RP_ALL.cs:12020-12110)',
};
