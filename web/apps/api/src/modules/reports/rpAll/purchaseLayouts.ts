import { round } from '@datacare/core';
import type { RpAllFilters } from './filters.js';
import type { RpAllColumn, RpAllLayout, RpAllRecord } from './types.js';

/**
 * The Purchase branch of RP_ALL: the seven buttons of PanelPurc (RP_ALL.cs:6704-6707 shows the panel when the
 * menu caption is "Purchase Rpt"), each with the Crystal template it opens and the predicates its click handler
 * appends. Every layout is read from the extracted template (extraction_output/rpt_xml/<Template>.xml): groups,
 * sort, band captions, bound fields per band and totals. Pure data and functions; the SQL is in purchaseQuery.ts.
 *
 *   Purc Report   btnPurcRpt      RP_ALL.cs:7946-8015   PurcReport
 *   Purc Reg      btnPurcReg      RP_ALL.cs:8017-8086   PurcSumm
 *   Item Wise     btnPurcItem     RP_ALL.cs:8088-8187   PurcItem
 *   Purchase Bill btnPurcBill     RP_ALL.cs:9615-9683   PurcBillA4Gst
 *   Party Purc    btnAcPurc       RP_ALL.cs:11204-11274 AcPurcRpt
 *   Group Purc    btnGroupPurc    RP_ALL.cs:12112-12213 PurcGroupWise
 *   Party Summ    btnParyPurcSumm RP_ALL.cs:12536-12606 AcPurcSummRpt
 */

export type PurchaseMode =
  'report' | 'register' | 'item' | 'bill' | 'party' | 'group' | 'party-summary';
export const PURCHASE_MODES: readonly PurchaseMode[] = [
  'report',
  'register',
  'item',
  'bill',
  'party',
  'group',
  'party-summary',
];

/** The captions the seven buttons carry, verbatim (access-key ampersands removed). */
export const PURCHASE_CAPTIONS: Readonly<Record<PurchaseMode, string>> = {
  report: 'Purc Report',
  register: 'Purc Reg',
  item: 'Item Wise',
  bill: 'Purchase Bill',
  party: 'Party Purc',
  group: 'Group Purc',
  'party-summary': 'Party Summ',
};

export type PurchaseFilterKey = keyof Omit<RpAllFilters, 'fromDate' | 'toDate'>;

/** What the adapter reads for a mode. */
export interface PurchaseQueryShape {
  lines: boolean;
  subs: boolean;
  /** PR_DATA.NET_AMT <> 0, the Group Purc predicate (RP_ALL.cs:12125). */
  guardNetAmt: boolean;
}

export interface PurchaseModeSpec {
  mode: PurchaseMode;
  caption: string;
  /** Filters the click handler appends to the record-selection formula. */
  filters: readonly PurchaseFilterKey[];
  /** Filters the handler appends on a table the template does not contain (PurcGroupWise has no AC_MAST). */
  templateLacks: readonly PurchaseFilterKey[];
  layout: RpAllLayout;
  query: PurchaseQueryShape;
  /** Formula fields computed from one record (Crystal @formulas). */
  derive?: (record: RpAllRecord) => Record<string, number | string | null>;
  /** Fields computed from the whole record set (Crystal group sums printed on a band of another level). */
  prepare?: (records: readonly RpAllRecord[]) => RpAllRecord[];
  cite: string;
}

const n = (record: RpAllRecord, key: string): number => {
  const v = record[key];
  return typeof v === 'number' ? v : v === null || v === undefined || v === '' ? 0 : Number(v);
};
const t = (record: RpAllRecord, key: string): string => String(record[key] ?? '');

const col = (
  key: string,
  caption: string,
  kind: RpAllColumn['kind'],
  level: RpAllColumn['level'],
  extra: Partial<RpAllColumn> = {},
): RpAllColumn => ({ key, caption, kind, level, captionSource: 'template', ...extra });
const field = (
  key: string,
  caption: string,
  kind: RpAllColumn['kind'],
  level: RpAllColumn['level'],
  extra: Partial<RpAllColumn> = {},
): RpAllColumn => col(key, caption, kind, level, { captionSource: 'field', ...extra });

const VOUCHER_KEY = ['lcCode', 'coBook', 'vchNo'] as const;
const vchGroup = (r: RpAllRecord) => `${t(r, 'coBook')}${t(r, 'vchNo')}`;

// ---- Purc Report → PurcReport (a clone of SaleReport over PR_DATA / PR_DETL / PR_IDTL) ----------------------

const reportLayout: RpAllLayout = {
  template: 'PurcReport',
  titlePrefix: 'Purchase Report',
  groups: [{ key: 'coBook', labelKeys: ['coBook', 'bookName'], subtotal: 'none' }],
  sort: [{ key: 'vchGroup' }, { key: 'srNo' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'], sub: ['subSrNo'] },
  rowLevels: ['voucher', 'line', 'sub'],
  columns: [
    field('vchDate', 'Date', 'date', 'voucher'),
    field('vchNo', 'Vch No', 'text', 'voucher'),
    field('acName', 'Party', 'text', 'voucher'),
    col('itmAmt', 'Net Amt', 'money', 'voucher', { total: true }),
    col('discAmt', 'Disc', 'money', 'voucher', { total: true }),
    col('taxAmt', 'Tax', 'money', 'voucher', { total: true }),
    col('vchAmt', 'Bill Tot', 'money', 'voucher', { total: true }),
    col('rofAmt', 'Rof Amt', 'money', 'voucher'),
    col('tagNo', 'Tag No', 'text', 'line'),
    col('itName', 'Item Code & Name', 'text', 'line'),
    col('pcs', 'Pcs', 'pcs', 'line', { total: true }),
    col('gwt', 'GrossWt', 'weight', 'line', { total: true }),
    col('nwt', 'Net Wt', 'weight', 'line', { total: true }),
    col('rate', 'Rate', 'rate', 'line'),
    col('lbrRate', 'L.Rate', 'rate', 'line'),
    col('lbrAmt', 'LbrAmt', 'money', 'line', { total: true }),
    col('lineNetAmt', 'Net Amt', 'money', 'line'),
    field('subItName', 'Item Code & Name', 'text', 'sub'),
    field('subPcs', 'Pcs', 'pcs', 'sub'),
    field('subGwt', 'GrossWt', 'weight', 'sub'),
    field('subRate', 'Rate', 'rate', 'sub'),
    field('subNetAmt', 'Net Amt', 'money', 'sub'),
  ],
  grandTotal: true,
};

// ---- Purc Reg → PurcSumm ------------------------------------------------------------------------------------

const registerLayout: RpAllLayout = {
  template: 'PurcSumm',
  titlePrefix: 'Purchase Register',
  groups: [
    { key: 'vchDate', labelKeys: ['vchDate'], subtotal: 'footer', subtotalCaption: 'DATE TOTAL :' },
  ],
  sort: [{ key: 'coBook' }],
  keys: { voucher: VOUCHER_KEY },
  rowLevels: ['voucher'],
  columns: [
    col('coBook', 'BOOK', 'text', 'voucher'),
    col('vchNo', 'BIL_NO', 'text', 'voucher'),
    col('vchDate', 'BIL_DATE', 'date', 'voucher'),
    col('partyName', 'AC NAME', 'text', 'voucher'),
    col('totAmt', 'TOT_AMT', 'money', 'voucher', { total: true }),
    col('cashAmt', 'CASH', 'money', 'voucher', { total: true }),
    col('cardAmt', 'CARD', 'money', 'voucher', { total: true }),
    col('creditAmt', 'CREDIT', 'money', 'voucher', { total: true }),
    col('kasarAmt', 'Kasar', 'money', 'voucher', { total: true }),
  ],
  grandTotal: true,
  grandTotalCaption: 'GRAND TOTAL :',
};

// ---- Item Wise → PurcItem -----------------------------------------------------------------------------------

const itemLayout: RpAllLayout = {
  template: 'PurcItem',
  titlePrefix: 'Item Wise Purchase Register',
  groups: [
    // Section6 prints the book name; its footer (Section10) is the "Total :" band with the per-book sums.
    {
      key: 'coBook',
      labelKeys: ['bookName'],
      subtotal: 'footer',
      subtotalCaption: 'Total :',
    },
    // Section7 prints the item code and name; Section9, its footer, is suppressed.
    { key: 'itCode', labelKeys: ['itCode', 'itName'], subtotal: 'none' },
    // Section3 is GroupName(VCH_DATE, "Daily"); its footer prints no sums.
    { key: 'vchDate', labelKeys: ['vchDate'], subtotal: 'none' },
  ],
  sort: [{ key: 'srNo' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'] },
  rowLevels: ['line'],
  columns: [
    col('vchNo', 'Vch No', 'text', 'line'),
    col('vchDate', 'Date', 'date', 'line'),
    col('partyName', 'Party_Name', 'text', 'line'),
    col('pcs', 'Pcs', 'pcs', 'line', { total: true }),
    col('nwt', 'Net Wt', 'weight', 'line', { total: true }),
    col('touch', 'Touch', 'rate', 'line'),
    col('westPrc', 'Wt%', 'rate', 'line'),
    col('fine', 'FineWt', 'weight', 'line', { total: true }),
    col('rate', 'Rate', 'rate', 'line'),
    col('itmAmtLine', 'ItmAmt', 'money', 'line', { total: true }),
    col('lineNetAmt', 'BillAmt', 'money', 'line', { total: true }),
  ],
  grandTotal: true,
  grandTotalCaption: 'Total :',
};

// ---- Purchase Bill → PurcBillA4Gst --------------------------------------------------------------------------

const billLayout: RpAllLayout = {
  template: 'PurcBillA4Gst',
  titlePrefix: 'Purchase Bill',
  // The template groups on @VchGroup and SR_NO and prints no group sums; one voucher is one bill page.
  groups: [],
  sort: [{ key: 'coBook' }, { key: 'vchNo' }, { key: 'srNo' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'] },
  rowLevels: ['voucher', 'line'],
  voucherRowAfter: true,
  columns: [
    col('vchDate', 'Invoice Date', 'date', 'voucher', { slot: 'SNo / Invoice Date' }),
    col('refNo', 'Invoice No', 'text', 'voucher', { slot: 'Description / Invoice No' }),
    col('acName', 'Name', 'text', 'voucher', { slot: 'Code / Name' }),
    col('netAmt', 'Net Amount', 'money', 'voucher', { total: true, slot: 'Amount' }),
    col('discAmt', 'Discount Amt', 'money', 'voucher', { total: true, slot: 'Discount Amt' }),
    col('igstTax', 'IGST', 'money', 'voucher', { total: true, slot: 'IGST' }),
    col('cgstTax', 'CGST', 'money', 'voucher', { total: true, slot: 'CGST' }),
    col('sgstTax', 'SGST', 'money', 'voucher', { total: true, slot: 'SGST' }),
    col('totAmt', 'Total Amount', 'money', 'voucher', { total: true, slot: 'Total Amount' }),
    col('cashAmt', 'Cash Amount', 'money', 'voucher', { total: true, slot: 'Cash Amount' }),
    col('cardAmt', 'Card Amount', 'money', 'voucher', { total: true, slot: 'Card Amount' }),
    col('chqAmt', 'Chq Amount', 'money', 'voucher', { total: true, slot: 'Chq Amount' }),
    col('kasarAmt', 'Kasar Amount', 'money', 'voucher', { total: true, slot: 'Kasar Amount' }),
    col('billOs', 'Bill Outstanding', 'money', 'voucher', {
      total: true,
      slot: 'Bill Outstanding',
    }),
    col('srNo', 'SNo', 'pcs', 'line', { slot: 'SNo / Invoice Date' }),
    col('itName', 'Description', 'text', 'line', { slot: 'Description / Invoice No' }),
    col('hsn', 'HSN', 'text', 'line', { slot: 'Code / Name' }),
    col('pcs', 'Pcs', 'pcs', 'line', { total: true }),
    col('gwt', 'Gr Wt.', 'weight', 'line', { total: true }),
    col('nwt', 'Net Wt', 'weight', 'line', { total: true }),
    col('rate', 'Rate', 'rate', 'line'),
    col('itmAmtLine', 'Amount', 'money', 'line', { total: true, slot: 'Amount' }),
    col('otherChg', 'Other Charg', 'money', 'line', { total: true }),
    col('lineNetAmt', 'Taxable Value', 'money', 'line', { total: true }),
  ],
  grandTotal: false,
};

// ---- Party Purc → AcPurcRpt, Party Summ → AcPurcSummRpt -----------------------------------------------------

/** The signed twins AcPurcSummRpt totals a party with: BOOK_DATA.BOOK_INOUT I → +, O → - (else 0). */
const SIGNED: Readonly<Record<string, string>> = {
  pcs: 'pcsS',
  gwt: 'gwtS',
  nwt: 'nwtS',
  fine: 'fineS',
  lbrOth: 'lbrOthS',
  lineNetAmt: 'netAmtS',
};

const inOutName = (inout: string) =>
  inout === 'I' ? 'Purchase / Recept' : inout === 'O' ? 'Purchase Return / Issue' : '';

const partyColumns = (): RpAllColumn[] => [
  col('vchNo', 'Vch No', 'text', 'voucher', { slot: 'Vch No / Item Code' }),
  col('vchDate', 'Date', 'date', 'voucher', { slot: 'Date / Item Name' }),
  // Section7 prints BOOK_NAME under Party_Name; the web adds the party's live master name beside it, because the
  // party band that carries it in the template is a separate line.
  field('bookParty', 'Party_Name', 'text', 'voucher', { slot: 'Party_Name' }),
  col('vPcs', 'Pcs', 'pcs', 'voucher', { slot: 'Pcs' }),
  col('vGwt', 'Gr Wt', 'weight', 'voucher', { slot: 'Gr Wt' }),
  col('vNwt', 'Net Wt', 'weight', 'voucher', { slot: 'Net Wt' }),
  col('vFine', 'Fine', 'weight', 'voucher', { slot: 'Fine' }),
  col('vLbrOth', 'Lbr / Oth', 'money', 'voucher', { slot: 'Lbr / Oth' }),
  col('totAmt', 'BillAmt', 'money', 'voucher', { slot: 'BillAmt' }),
  col('itCode', 'Item Code', 'text', 'line', { slot: 'Vch No / Item Code' }),
  col('itName', 'Item Name', 'text', 'line', { slot: 'Date / Item Name' }),
  col('pcs', 'Pcs', 'pcs', 'line', { total: true, slot: 'Pcs' }),
  col('gwt', 'Gr Wt', 'weight', 'line', { total: true, slot: 'Gr Wt' }),
  col('nwt', 'Net Wt', 'weight', 'line', { total: true, slot: 'Net Wt' }),
  col('touch', 'Touch', 'rate', 'line'),
  col('westPrc', 'West%', 'rate', 'line'),
  col('fine', 'Fine', 'weight', 'line', { total: true, slot: 'Fine' }),
  col('rate', 'Rate', 'rate', 'line'),
  col('lbrOth', 'Lbr / Oth', 'money', 'line', { total: true, slot: 'Lbr / Oth' }),
  col('lineNetAmt', 'BillAmt', 'money', 'line', { total: true, slot: 'BillAmt' }),
];

const partyLayout = (template: string, voucherAfter: boolean): RpAllLayout => ({
  template,
  titlePrefix: 'Party Purchase Report',
  groups: [
    // Party Total (Section10) sums the signed fields; the party header (Section6) is AC_MAST.AC_NAME.
    {
      key: 'acCode',
      labelKeys: ['partyName'],
      subtotal: 'footer',
      subtotalCaption: 'Party Total :',
      totalKeys: SIGNED,
    },
    // Section12 "Total :" sums the raw fields by @InOutType; Section5 prints @InOutName.
    {
      key: 'inOut',
      labelKeys: [],
      subtotal: 'footer',
      subtotalCaption: 'Total :',
      labelMap: { I: 'Purchase / Recept', O: 'Purchase Return / Issue' },
      labelDefault: '',
    },
  ],
  sort: [{ key: 'vchGroup' }, { key: 'srNo' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'] },
  rowLevels: ['voucher', 'line'],
  voucherRowAfter: voucherAfter,
  columns: partyColumns(),
  grandTotal: true,
  grandTotalCaption: 'Total :',
  grandTotalKeys: SIGNED,
});

/** Sum of the lines of each voucher, printed on the voucher band (Sum(...,{@Group}) of Section7/Section9). */
function withVoucherSums(records: readonly RpAllRecord[]): RpAllRecord[] {
  const sums = new Map<string, Record<string, number>>();
  const seen = new Set<string>();
  for (const r of records) {
    const v = VOUCHER_KEY.map((k) => t(r, k)).join('|');
    const line = `${v}|${t(r, 'srNo')}`;
    if (seen.has(line)) continue;
    seen.add(line);
    const s = sums.get(v) ?? { vPcs: 0, vGwt: 0, vNwt: 0, vFine: 0, vLbrOth: 0 };
    s.vPcs = round(s.vPcs! + n(r, 'pcs'), 6);
    s.vGwt = round(s.vGwt! + n(r, 'gwt'), 6);
    s.vNwt = round(s.vNwt! + n(r, 'nwt'), 6);
    s.vFine = round(s.vFine! + n(r, 'fine'), 6);
    s.vLbrOth = round(s.vLbrOth! + n(r, 'lbrAmt') + n(r, 'othAmt'), 6);
    sums.set(v, s);
  }
  return records.map((r) => ({ ...r, ...sums.get(VOUCHER_KEY.map((k) => t(r, k)).join('|')) }));
}

const partyDerive = (r: RpAllRecord): Record<string, number | string | null> => {
  const inout = t(r, 'bookInout');
  const sign = inout === 'I' ? 1 : inout === 'O' ? -1 : 0;
  const lbrOth = round(n(r, 'lbrAmt') + n(r, 'othAmt'), 6);
  return {
    vchGroup: `${t(r, 'coYear')}${vchGroup(r)}`,
    inOut: inout,
    inOutName: inOutName(inout),
    lbrOth,
    bookParty: `${t(r, 'bookName')} ${t(r, 'partyName')}`.trim(),
    pcsS: sign * n(r, 'pcs'),
    gwtS: sign * n(r, 'gwt'),
    nwtS: sign * n(r, 'nwt'),
    fineS: sign * n(r, 'fine'),
    lbrOthS: sign * lbrOth,
    netAmtS: sign * n(r, 'lineNetAmt'),
  };
};

// ---- Group Purc → PurcGroupWise -----------------------------------------------------------------------------

const groupLayout: RpAllLayout = {
  template: 'PurcGroupWise',
  titlePrefix: 'Item Group Purchase Report',
  groups: [
    {
      key: 'itType',
      labelKeys: ['itType'],
      subtotal: 'header',
      labelMap: { G: 'GOLD', S: 'SILVER' },
      labelDefault: 'OTHER',
    },
    { key: 'grCode', labelKeys: ['grName'], subtotal: 'header' },
  ],
  sort: [{ key: 'vchDate' }, { key: 'acCode' }],
  keys: { voucher: VOUCHER_KEY, line: ['srNo'] },
  // PurcGroupWise suppresses its Detail band (Section8, EnableSuppress=True), so it prints only the item-type and
  // group header sums and the grand total, as SalesGroupWise does in the Sales branch. The line columns below
  // name what those sums add up.
  rowLevels: [],
  columns: [
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
  ],
  grandTotal: true,
  grandTotalCaption: 'Total:',
};

const ALL_BUT_STATE: readonly PurchaseFilterKey[] = ['lcCode', 'coBook', 'acCode', 'city', 'area'];

export const PURCHASE_SPECS: Readonly<Record<PurchaseMode, PurchaseModeSpec>> = {
  report: {
    mode: 'report',
    caption: PURCHASE_CAPTIONS.report,
    filters: ALL_BUT_STATE,
    templateLacks: [],
    layout: reportLayout,
    query: { lines: true, subs: true, guardNetAmt: false },
    // PurcReport: @ItmAmt = NET_AMT, @VchAmt = TOT_AMT, @VchGroup = CO_BOOK + VCH_NO.
    derive: (r) => ({ vchGroup: vchGroup(r), itmAmt: n(r, 'netAmt'), vchAmt: n(r, 'totAmt') }),
    cite: 'RP_ALL.cs:7946-8015; PurcReport.xml',
  },
  register: {
    mode: 'register',
    caption: PURCHASE_CAPTIONS.register,
    filters: ALL_BUT_STATE,
    templateLacks: [],
    layout: registerLayout,
    query: { lines: false, subs: false, guardNetAmt: false },
    // PurcSumm: @Crd_amt = TOT_AMT - CASH_AMT.
    derive: (r) => ({ creditAmt: round(n(r, 'totAmt') - n(r, 'cashAmt'), 6) }),
    cite: 'RP_ALL.cs:8017-8086; PurcSumm.xml',
  },
  item: {
    mode: 'item',
    caption: PURCHASE_CAPTIONS.item,
    filters: [...ALL_BUT_STATE, 'prCode', 'itemType', 'grCode'],
    templateLacks: [],
    layout: itemLayout,
    query: { lines: true, subs: false, guardNetAmt: false },
    cite: 'RP_ALL.cs:8088-8187; PurcItem.xml',
  },
  bill: {
    mode: 'bill',
    caption: PURCHASE_CAPTIONS.bill,
    filters: ALL_BUT_STATE,
    templateLacks: [],
    layout: billLayout,
    query: { lines: true, subs: false, guardNetAmt: false },
    // PurcBillA4Gst: @RefNo = BOOK_SR_NAME-VCH_NO [/ Ref No : BILL_NO]; @OtherCharg = LBR_AMT + OTH_AMT.
    derive: (r) => ({
      refNo: `${t(r, 'bookSrName')}-${t(r, 'vchNo')}${t(r, 'billNo') ? ` / Ref No : ${t(r, 'billNo')}` : ''}`,
      otherChg: round(n(r, 'lbrAmt') + n(r, 'othAmt'), 6),
    }),
    cite: 'RP_ALL.cs:9615-9683; PurcBillA4Gst.xml',
  },
  party: {
    mode: 'party',
    caption: PURCHASE_CAPTIONS.party,
    filters: ALL_BUT_STATE,
    templateLacks: [],
    layout: partyLayout('AcPurcRpt', true),
    query: { lines: true, subs: false, guardNetAmt: false },
    derive: partyDerive,
    prepare: withVoucherSums,
    cite: 'RP_ALL.cs:11204-11274; AcPurcRpt.xml',
  },
  group: {
    mode: 'group',
    caption: PURCHASE_CAPTIONS.group,
    filters: [...ALL_BUT_STATE, 'prCode', 'itemType', 'grCode'],
    templateLacks: ['city', 'area'],
    layout: groupLayout,
    query: { lines: true, subs: false, guardNetAmt: true },
    // @ItmTotAmt = PR_DETL.NET_AMT + PR_DETL.IT_TAX_AMT; the web PR_DETL has no IT_TAX_AMT column, so it adds 0.
    derive: (r) => ({ itmTotAmt: n(r, 'lineNetAmt') }),
    cite: 'RP_ALL.cs:12112-12213; PurcGroupWise.xml',
  },
  'party-summary': {
    mode: 'party-summary',
    caption: PURCHASE_CAPTIONS['party-summary'],
    filters: ALL_BUT_STATE,
    templateLacks: [],
    layout: partyLayout('AcPurcSummRpt', false),
    query: { lines: true, subs: false, guardNetAmt: false },
    derive: partyDerive,
    prepare: withVoucherSums,
    cite: 'RP_ALL.cs:12536-12606; AcPurcSummRpt.xml',
  },
};
