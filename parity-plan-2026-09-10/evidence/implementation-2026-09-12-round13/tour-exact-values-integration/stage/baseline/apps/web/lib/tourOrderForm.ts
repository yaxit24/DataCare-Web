import {
  fineFor,
  round,
  orderLabourAmount,
  orderLabourTransition,
  type OrderLabourAction,
  type OrderLabourPolicy,
  type OrderLabourState,
  type OrderLabourEdit,
} from '@datacare/core';
import {
  SUB_DETAIL_COLUMNS,
  type SubDetailRow,
  type SubDetailField,
} from '../components/SubDetailGrid';
import type { BusinessScope } from '../components/BusinessScope';

export interface Row {
  components: Array<SubDetailRow & { isrNo?: string }>;
  srNo?: string;
  consumed?: boolean;
  itCode: string;
  /** Saved imported tag identity; intentionally has no editable grid field. */
  tagNo: string;
  designNo: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
  labourAmount: string;
  labourAction: string;
  labourEdits: OrderLabourEdit[];
  itemAmount: string;
  lineNetAmount: string;
  lineTotalAmount: string;
  remark: string;
  // Desktop order-grid columns (TR_SALE_ORD mSG).
  tblCode: string;
  itmColor: string;
  itmSize: string;
  rateFix: string;
  labourType: string;
  karigarName: string;
  rateType: string;
  itType: string;
  prCode: string;
  oldTblCode: string;
  tagStockLess: string;
  designImageId: string;
  huid: string;
  hallmarkId2: string;
  hallmarkId3: string;
  hallmarkId4: string;
  orderDeliveryDate: string;
  bagWt: string;
  lessWt: string;
  ghtPct: string;
  ghtWt: string;
  westPct: string;
  labourPct: string;
  labourRate: string;
  otherAmount: string;
  mrp: string;
  karigarNetWt: string;
  karigarTouch: string;
  karigarWestPct: string;
  karigarFine: string;
  tagCost: string;
  vchSrno: string;
  oldSrNo: string;
  hallmarkIdWt: string;
  hallmarkId2Wt: string;
  hallmarkId3Wt: string;
  hallmarkId4Wt: string;
  dmCode: string;
  dmName: string;
  dmSize: string;
  dmSfNo: string;
  dmColor: string;
  dmOrigin: string;
  dmRemark: string;
  dmLeb: string;
  stonePcsWt: string;
  stoneConPct: string;
  stoneConWt: string;
  stoneRateType: string;
  stoneRate: string;
  stoneLabourRate: string;
  stoneLabourAmount: string;
  stoneKarigarWt: string;
  stoneKarigarLessPct: string;
  stoneKarigarConPct: string;
  stoneKarigarConWt: string;
  stoneKarigarRate: string;
  stoneKarigarAmount: string;
  stoneKarigarLabourRate: string;
  stoneKarigarLabourAmount: string;
  stoneKarigarNetAmount: string;
}
export const blank = (): Row => ({
  components: [{}],
  dmCode: '',
  dmName: '',
  dmSize: '',
  dmSfNo: '',
  dmColor: '',
  dmOrigin: '',
  dmRemark: '',
  dmLeb: '',
  stonePcsWt: '',
  stoneConPct: '',
  stoneConWt: '',
  stoneRateType: '',
  stoneRate: '',
  stoneLabourRate: '',
  stoneLabourAmount: '',
  stoneKarigarWt: '',
  stoneKarigarLessPct: '',
  stoneKarigarConPct: '',
  stoneKarigarConWt: '',
  stoneKarigarRate: '',
  stoneKarigarAmount: '',
  stoneKarigarLabourRate: '',
  stoneKarigarLabourAmount: '',
  stoneKarigarNetAmount: '',
  itCode: '',
  tagNo: '',
  designNo: '',
  pcs: '',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  making: '',
  labourAmount: '',
  labourAction: '',
  labourEdits: [],
  itemAmount: '',
  lineNetAmount: '',
  lineTotalAmount: '',
  remark: '',
  tblCode: '',
  itmColor: '',
  itmSize: '',
  rateFix: '',
  labourType: '',
  karigarName: '',
  rateType: '',
  itType: '',
  prCode: '',
  oldTblCode: '',
  tagStockLess: '',
  designImageId: '',
  huid: '',
  hallmarkId2: '',
  hallmarkId3: '',
  hallmarkId4: '',
  orderDeliveryDate: '',
  bagWt: '',
  lessWt: '',
  ghtPct: '',
  ghtWt: '',
  westPct: '',
  labourPct: '',
  labourRate: '',
  otherAmount: '',
  mrp: '',
  karigarNetWt: '',
  karigarTouch: '',
  karigarWestPct: '',
  karigarFine: '',
  tagCost: '',
  vchSrno: '',
  oldSrNo: '',
  hallmarkIdWt: '',
  hallmarkId2Wt: '',
  hallmarkId3Wt: '',
  hallmarkId4Wt: '',
});
export const extendedRowFields: Array<[keyof Row, string]> = [
  ['tblCode', 'Counter'],
  ['itmColor', 'Colour'],
  ['itmSize', 'Size'],
  ['rateFix', 'Rate Fix'],
  ['labourType', 'Labour Type'],
  ['karigarName', 'Karigar'],
  ['rateType', 'Rate Type'],
  ['itType', 'Item Type'],
  ['prCode', 'PR Code'],
  ['oldTblCode', 'Old Counter'],
  ['tagStockLess', 'Tag Stock Less'],
  ['designImageId', 'Design Image'],
  ['huid', 'HUID'],
  ['hallmarkId2', 'Hallmark 2'],
  ['hallmarkId3', 'Hallmark 3'],
  ['hallmarkId4', 'Hallmark 4'],
  ['orderDeliveryDate', 'Line Delivery Date'],
  ['bagWt', 'Bag Wt'],
  ['lessWt', 'Less Wt'],
  ['ghtPct', 'Ghat %'],
  ['ghtWt', 'Ghat Wt'],
  ['westPct', 'Wastage %'],
  ['labourPct', 'Labour %'],
  ['labourAmount', 'Labour amount'],
  ['otherAmount', 'Other Amt'],
  ['mrp', 'MRP'],
  ['karigarNetWt', 'Karigar Net Wt'],
  ['karigarTouch', 'Karigar Touch'],
  ['karigarWestPct', 'Karigar West %'],
  ['karigarFine', 'Karigar Fine'],
  ['tagCost', 'Tag Cost'],
  ['vchSrno', 'Vch SrNo'],
  ['oldSrNo', 'Old SrNo'],
  ['hallmarkIdWt', 'HM Wt'],
  ['hallmarkId2Wt', 'HM2 Wt'],
  ['hallmarkId3Wt', 'HM3 Wt'],
  ['hallmarkId4Wt', 'HM4 Wt'],
];
export const extendedHeaderFields: Array<[string, string]> = [
  ['billNo', 'Bill No'],
  ['vchTime', 'Order time'],
  ['vchDesc', 'Description'],
  ['taxCode', 'Tax Code'],
  ['bankAc', 'Bank A/c'],
  ['bankName', 'Bank Name'],
  ['chequeNo', 'Cheque No'],
  ['cardAc', 'Card A/c'],
  ['cardAdj', 'Card Adj'],
  ['cashAc', 'Cash A/c'],
  ['address1', 'Address 1'],
  ['address2', 'Address 2'],
  ['address3', 'Address 3'],
  ['city', 'City'],
  ['mobile', 'Mobile'],
  ['empCode', 'Employee'],
  ['deliveryDate', 'Delivery Date'],
  ['functionDate', 'Function Date'],
  ['upiAmount', 'UPI Amt'],
  ['oldGoldFine', 'Old Gold Fine'],
  ['oldGoldAmount', 'Old Gold Amt'],
  ['oldSilverFine', 'Old Silver Fine'],
  ['oldSilverAmount', 'Old Silver Amt'],
  ['schemeAmount', 'Scheme Amt'],
  ['rateCutRate', 'Rate-cut Rate'],
  ['rateCutFine', 'Rate-cut Fine'],
  ['rateCutAmount', 'Rate-cut Amt'],
  ['adjustGold', 'Adj Gold'],
  ['adjustSilver', 'Adj Silver'],
  ['orderAdjustAmount', 'Order Adj Amt'],
  ['netAmount', 'Net Amt (override)'],
];

const numericLineFields = new Set([
  'netWt',
  'touch',
  'netWt',
  'ghatWt',
  'rate',
  'pcs',
  'grossWt',
  'netWt',
  'touch',
  'rate',
  'making',
  'bagWt',
  'lessWt',
  'ghtPct',
  'ghtWt',
  'westPct',
  'labourPct',
  'labourRate',
  'labourAmount',
  'itemAmount',
  'lineNetAmount',
  'lineTotalAmount',
  'otherAmount',
  'mrp',
  'karigarNetWt',
  'karigarTouch',
  'karigarWestPct',
  'karigarFine',
  'tagCost',
  'vchSrno',
  'oldSrNo',
  'hallmarkIdWt',
  'hallmarkId2Wt',
  'hallmarkId3Wt',
  'hallmarkId4Wt',
  'stonePcsWt',
  'stoneConPct',
  'stoneConWt',
  'stoneRate',
  'stoneLabourRate',
  'stoneLabourAmount',
  'stoneKarigarWt',
  'stoneKarigarLessPct',
  'stoneKarigarConPct',
  'stoneKarigarConWt',
  'stoneKarigarRate',
  'stoneKarigarAmount',
  'stoneKarigarLabourRate',
  'stoneKarigarLabourAmount',
  'stoneKarigarNetAmount',
]);
const numericHeaderFields = new Set([
  'upiAmount',
  'oldGoldFine',
  'oldGoldAmount',
  'oldSilverFine',
  'oldSilverAmount',
  'schemeAmount',
  'rateCutRate',
  'rateCutFine',
  'rateCutAmount',
  'adjustGold',
  'adjustSilver',
  'orderAdjustAmount',
  'netAmount',
]);

export const blankOrderHeader = () => ({
  acCode: '',
  acName: '',
  taxRatePct: '3',
  advanceAmount: '',
  vchDate: new Date().toISOString().slice(0, 10),
});

function numberCell(value: unknown, label: string): number | undefined {
  if (value == null || String(value).trim() === '') return undefined;
  const result = Number(value);
  if (!Number.isFinite(result)) throw new Error(`${label} must be a valid number`);
  return result;
}

export function hydrateTourOrder(document: Record<string, any>) {
  const f = blankOrderHeader();
  for (const field of Object.keys(f) as Array<keyof typeof f>)
    f[field] = String(document[field] ?? '');
  const header: Record<string, string> = {};
  for (const [field] of extendedHeaderFields) header[field] = String(document[field] ?? '');
  const rows = (document.lines ?? []).map((line: Record<string, any>) => {
    const row = blank();
    for (const key of Object.keys(row) as Array<keyof Row>) {
      if (key !== 'components' && key !== 'consumed' && key !== 'labourEdits')
        (row as any)[key] = String(line[key] ?? '');
    }
    row.srNo = String(line.srNo ?? '');
    row.consumed = !!line.consumed;
    row.components = (line.components ?? []).map((child: Record<string, unknown>) =>
      Object.fromEntries(
        Object.entries(child)
          .filter(([key]) => key in SUB_DETAIL_COLUMNS || key === 'isrNo')
          .map(([key, value]) => [key, value == null ? '' : String(value)]),
      ),
    );
    return row;
  });
  return { f, header, rows: rows.length ? rows : [blank()] };
}

export function tourOrderPayload(
  f: ReturnType<typeof blankOrderHeader>,
  header: Record<string, string>,
  rows: Row[],
  expectedVersion?: string,
) {
  if (!f.acCode.trim()) throw new Error('Customer is required');
  const lines = rows
    .filter((row) => row.itCode.trim())
    .map((row, index) => {
      const line: Record<string, unknown> = {};
      for (const field of Object.keys(blank()) as Array<keyof Row>) {
        if (
          field === 'components' ||
          field === 'consumed' ||
          field === 'labourEdits' ||
          ['itemAmount', 'lineNetAmount', 'lineTotalAmount'].includes(field)
        )
          continue;
        const value = String(row[field] ?? '').trim();
        line[field] = numericLineFields.has(field)
          ? numberCell(value, `Item ${index + 1}: ${field}`)
          : value || undefined;
      }
      line.labourEdits = row.labourEdits;
      line.srNo = numberCell(row.srNo, 'Item row number');
      line.components = row.components
        .filter((child) => Object.values(child).some((value) => String(value ?? '').trim()))
        .map((child, childIndex) => {
          if (!child.itCode?.trim())
            throw new Error(`Item ${index + 1}, component ${childIndex + 1}: item is required`);
          const out: Record<string, unknown> = {
            isrNo: numberCell(child.isrNo, 'Component row number'),
          };
          for (const field of Object.keys(SUB_DETAIL_COLUMNS) as SubDetailField[]) {
            const value = String(child[field] ?? '').trim();
            out[field] = SUB_DETAIL_COLUMNS[field].numeric
              ? numberCell(value, `Component ${childIndex + 1}: ${field}`)
              : value || undefined;
          }
          return out;
        });
      return line;
    });
  if (!lines.length) throw new Error('Enter at least one item line');
  const result: Record<string, unknown> = {
    ...f,
    acCode: f.acCode.trim(),
    acName: f.acName.trim(),
    lines,
    expectedVersion,
    taxRatePct: numberCell(f.taxRatePct, 'Tax percentage') ?? 0,
    advanceAmount: numberCell(f.advanceAmount, 'Advance') ?? 0,
  };
  for (const [field, label] of extendedHeaderFields)
    result[field] = numericHeaderFields.has(field)
      ? numberCell(header[field], label)
      : header[field]?.trim() || undefined;
  return result;
}

export function tourOrderQuery(scope: BusinessScope, coBook: string): string {
  return new URLSearchParams({
    coCode: scope.coCode,
    lcCode: scope.lcCode,
    coYear: scope.coYear,
    coBook,
  }).toString();
}

/** Hydrated amounts are display snapshots, never a client instruction to trust prior values. */
export function setTourOrderCell(row: Row, field: keyof Row, value: string): Row {
  const out = { ...row, [field]: value };
  if (['netWt', 'ghtWt', 'touch', 'westPct', 'rate'].includes(field)) {
    out.itemAmount = '';
    out.lineNetAmount = '';
    out.lineTotalAmount = '';
  }
  if (field === 'otherAmount') {
    out.lineNetAmount = '';
    out.lineTotalAmount = '';
  }
  return out;
}

function labourState(row: Row): OrderLabourState {
  const n = (key: keyof Row) => numberCell(row[key], String(key)) ?? 0;
  return {
    labourType: row.labourType,
    pcs: n('pcs'),
    grossWt: n('grossWt'),
    netWt: n('netWt'),
    ghatWt: n('ghtWt'),
    itemRate: n('rate'),
    labourPct: n('labourPct'),
    labourRate: row.labourRate === '' ? n('making') : n('labourRate'),
    labourAmount: n('labourAmount'),
  };
}

export function commitTourOrderLabour(
  previous: Row,
  row: Row,
  field: keyof Row,
  policy: OrderLabourPolicy,
): Row {
  const actions: Partial<Record<keyof Row, OrderLabourAction>> = {
    labourRate: 'rate',
    labourPct: 'percentage',
    labourAmount: 'amount',
  };
  const action = actions[field];
  if (!action || Number(previous[field] || 0) === Number(row[field] || 0)) return row;
  // MSG_LeaveCell formats the committed rate/percentage/amount to two decimal places before
  // CommPassTotal. A transient blank is not calculated until the operator leaves the cell.
  const normalized = {
    ...row,
    [field]: String(round(numberCell(row[field], String(field)) ?? 0, 2)),
  };
  const result = orderLabourTransition(
    labourState(previous),
    labourState(normalized),
    policy,
    action,
  );
  const current = labourState(normalized);
  const edit: OrderLabourEdit = {
    action,
    value: Number(normalized[field]),
    basis: {
      labourType: current.labourType,
      pcs: current.pcs,
      grossWt: current.grossWt,
      netWt: current.netWt,
      ghatWt: current.ghatWt,
      itemRate: current.itemRate,
    },
  };
  return {
    ...normalized,
    labourAction: action,
    labourEdits: [...row.labourEdits, edit],
    labourRate: String(result.labourRate),
    labourPct: String(result.labourPct),
    labourAmount: String(result.labourAmount),
    lineNetAmount:
      result.labourAmount === Number(previous.labourAmount || 0) ? row.lineNetAmount : '',
    lineTotalAmount:
      result.labourAmount === Number(previous.labourAmount || 0) ? row.lineTotalAmount : '',
  };
}

export function tourOrderLineNet(row: Row, policy: OrderLabourPolicy): number {
  if (row.lineNetAmount !== '') return numberCell(row.lineNetAmount, 'Saved line amount') ?? 0;
  const state = labourState(row);
  const metal =
    row.itemAmount !== ''
      ? (numberCell(row.itemAmount, 'Saved metal amount') ?? 0)
      : round(
          fineFor('salesOrder', {
            netWt: state.netWt,
            ghtWt: state.ghatWt,
            touch: Number(row.touch || 0),
            westPct: Number(row.westPct || 0),
          }) * state.itemRate,
          2,
        );
  const labour = row.labourAmount !== '' ? state.labourAmount : orderLabourAmount(state, policy);
  return round(metal + labour + Number(row.otherAmount || 0), 2);
}
