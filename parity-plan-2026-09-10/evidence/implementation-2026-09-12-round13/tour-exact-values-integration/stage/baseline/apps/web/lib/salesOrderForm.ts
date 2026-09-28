import {
  blank as blankTourRow,
  blankOrderHeader as blankTourHeader,
  extendedHeaderFields,
  extendedRowFields,
  hydrateTourOrder,
  tourOrderPayload,
  tourOrderQuery,
  type Row as OrderRow,
} from './tourOrderForm';
import { SUB_DETAIL_COLUMNS } from '../components/SubDetailGrid';
import {
  applySalesOrderDesignSelection,
  fineFor,
  round,
  orderLabourWithCache,
  type OrderLabourState,
  type OrderLabourCache,
  clearSalesOrderDesignSelection,
  type OrderLabourEdit,
  type OrderLabourPolicy,
  type SalesOrderDesignSourceRef,
  type SalesOrderDesignOption,
} from '@datacare/core';

export { extendedHeaderFields, extendedRowFields };
export const salesOrderQuery = tourOrderQuery;
export type SalesOrderJournalEvent =
  | { kind: 'field'; field: string; value: string | number }
  | { kind: 'labour'; edit: OrderLabourEdit }
  | { kind: 'design'; source: SalesOrderDesignSourceRef }
  | { kind: 'clearDesign' };
export type Row = OrderRow & {
  clientKey: string;
  orderEdits: SalesOrderJournalEvent[];
  dirtyFields: string[];
  componentDirty: Record<string, string[]>;
  labourCache: OrderLabourCache;
  calculationBasis: Pick<
    OrderRow,
    'netWt' | 'ghtWt' | 'touch' | 'westPct' | 'rate' | 'labourAmount' | 'otherAmount'
  >;
  draftFields: string[];
  calculationPending: boolean;
  fineWeight: string;
};
const numericJournalFields = new Set([
  'touch',
  'westPct',
  'labourPct',
  'labourRate',
  'labourAmount',
  'otherAmount',
  'pcs',
  'grossWt',
  'netWt',
  'ghtWt',
  'rate',
]);
const journalFields = new Set([
  'itCode',
  'designNo',
  'itmSize',
  'karigarName',
  'designImageId',
  'labourType',
  ...numericJournalFields,
]);
export const readonlyRowFields = new Set([
  'designImageId',
  'vchSrno',
  'oldSrNo',
  'oldTblCode',
  'tagStockLess',
]);
export const readonlyHeaderFields = new Set([
  'netAmount',
  'bankAc',
  'bankName',
  'chequeNo',
  'cardAc',
  'cardAdj',
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
]);
let nextClientKey = 0;
export const blank = (srNo?: number): Row => ({
  ...blankTourRow(),
  // TR_SALE_ORD:5558 uses N for a new row with no selected master image.
  designImageId: 'N',
  labourAmount: '0',
  itemAmount: '0',
  lineNetAmount: '0',
  lineTotalAmount: '0',
  fineWeight: '0',
  labourCache: { labourRate: 0, labourAmount: 0, labourPct: 0 },
  calculationBasis: {
    netWt: '',
    ghtWt: '',
    touch: '',
    westPct: '',
    rate: '',
    labourAmount: '0',
    otherAmount: '',
  },
  draftFields: [],
  calculationPending: false,
  srNo: srNo == null ? undefined : String(srNo),
  clientKey: `sales-row-${++nextClientKey}`,
  dirtyFields: [],
  componentDirty: {},
  orderEdits: [...journalFields].map((field) => ({
    kind: 'field',
    field,
    value: field === 'designImageId' ? 'N' : numericJournalFields.has(field) ? 0 : '',
  })),
});

const triggerFields = new Set([
  'pcs',
  'grossWt',
  'netWt',
  'ghtWt',
  'rate',
  'touch',
  'westPct',
  'otherAmount',
]);
function numeric(value: unknown, label: string): number {
  const number = value == null || value === '' ? 0 : Number(value);
  if (!Number.isFinite(number)) throw new Error(`${label} must be a valid number`);
  return number;
}
function labourState(row: Row): OrderLabourState {
  return {
    labourType: row.labourType,
    pcs: numeric(row.pcs, 'pcs'),
    grossWt: numeric(row.grossWt, 'grossWt'),
    netWt: numeric(row.netWt, 'netWt'),
    ghatWt: numeric(row.ghtWt, 'ghtWt'),
    itemRate: numeric(row.rate, 'rate'),
    labourPct: numeric(row.labourPct, 'labourPct'),
    labourRate: numeric(row.labourRate, 'labourRate'),
    labourAmount: numeric(row.labourAmount, 'labourAmount'),
  };
}
export function salesOrderLineNet(row: Row, _policy?: OrderLabourPolicy): number {
  return numeric(row.lineNetAmount, 'Saved line amount');
}
export function setSalesOrderCell(row: Row, field: keyof Row, value: string): Row {
  if (field === 'designNo' && value === '' && row.designNo !== '')
    return {
      ...clearSalesOrderDesignSelection(row),
      dirtyFields: [...new Set([...row.dirtyFields, 'designNo', 'designImageId'])],
      orderEdits: [...row.orderEdits, { kind: 'clearDesign' }],
    };
  const next = {
    ...row,
    [field]: value,
    dirtyFields: [...new Set([...row.dirtyFields, field])],
    draftFields: [...new Set([...row.draftFields, field])],
  };
  // Numeric inputs are drafts until the actual leave-cell calculation event.
  if (!journalFields.has(field) || numericJournalFields.has(field)) return next;
  const previous = row.orderEdits.at(-1);
  const edits =
    previous?.kind === 'field' && previous.field === field
      ? row.orderEdits.slice(0, -1)
      : row.orderEdits;
  return { ...next, orderEdits: [...edits, { kind: 'field', field, value }] };
}
export function selectSalesOrderDesign(
  row: Row,
  option: SalesOrderDesignOption,
  existing: boolean,
): Row {
  // F1 copies visible defaults but never parses unrelated drafts or changes cached totals84/85/86.
  return {
    ...applySalesOrderDesignSelection(row, option, { existing }),
    calculationPending: true,
    orderEdits: [...row.orderEdits, { kind: 'design', source: option.source }],
  };
}
export function commitSalesOrderLabour(
  previous: Row,
  row: Row,
  field: keyof Row,
  policy: OrderLabourPolicy,
): Row {
  const actions: Partial<Record<keyof Row, 'rate' | 'percentage' | 'amount'>> = {
    labourRate: 'rate',
    labourPct: 'percentage',
    labourAmount: 'amount',
  };
  const action = actions[field];
  if (!action && !triggerFields.has(field)) return row;
  if (!row.calculationPending && !row.draftFields.includes(field) && previous[field] === row[field])
    return row;
  const normalized = action
    ? { ...row, [field]: String(round(numeric(row[field], String(field)), 2)) }
    : row;
  const visible = labourState(normalized);
  const result = orderLabourWithCache(visible, row.labourCache, policy);
  // F1 leaves this basis unchanged too. Imported cached metal/net values survive
  // unrelated triggers, while a later copied Touch/West trigger correctly reprices.
  const sameMetal = (['netWt', 'ghtWt', 'touch', 'westPct', 'rate'] as const).every(
    (key) => numeric(normalized[key], key) === numeric(row.calculationBasis[key], key),
  );
  const fineWeight = sameMetal
    ? row.fineWeight
    : String(
        fineFor('salesOrder', {
          netWt: visible.netWt,
          ghtWt: visible.ghatWt,
          touch: numeric(row.touch, 'touch'),
          westPct: numeric(row.westPct, 'westPct'),
        }),
      );
  const metal = sameMetal
    ? row.itemAmount
    : String(round(numeric(fineWeight, 'Fine weight') * visible.itemRate, 2));
  const sameTotal =
    sameMetal &&
    result.state.labourAmount ===
      numeric(row.calculationBasis.labourAmount, 'Previous labour amount') &&
    numeric(row.otherAmount, 'otherAmount') ===
      numeric(row.calculationBasis.otherAmount, 'Previous other amount');
  const net = sameTotal
    ? row.lineNetAmount
    : String(
        round(
          numeric(metal, 'Metal amount') +
            result.state.labourAmount +
            numeric(row.otherAmount, 'otherAmount'),
          2,
        ),
      );
  const edit: OrderLabourEdit | undefined = action
    ? {
        action,
        value: numeric(normalized[field], String(field)),
        basis: {
          labourType: visible.labourType,
          pcs: visible.pcs,
          grossWt: visible.grossWt,
          netWt: visible.netWt,
          ghatWt: visible.ghatWt,
          itemRate: visible.itemRate,
        },
      }
    : undefined;
  return {
    ...normalized,
    labourRate: String(result.state.labourRate),
    labourPct: String(result.state.labourPct),
    labourAmount: String(result.state.labourAmount),
    labourCache: result.cache,
    fineWeight,
    itemAmount: metal,
    lineNetAmount: net,
    lineTotalAmount: sameTotal ? row.lineTotalAmount : '',
    calculationBasis: {
      netWt: row.netWt,
      ghtWt: row.ghtWt,
      touch: row.touch,
      westPct: row.westPct,
      rate: row.rate,
      labourAmount: String(result.state.labourAmount),
      otherAmount: row.otherAmount,
    },
    calculationPending: false,
    draftFields: row.draftFields.filter((key) => key !== field),
    labourEdits: edit ? [...row.labourEdits, edit] : row.labourEdits,
    orderEdits: [
      ...row.orderEdits,
      edit
        ? { kind: 'labour', edit }
        : { kind: 'field', field, value: numeric(row[field], String(field)) },
    ],
  };
}
/** The operator's calendar day, not yesterday's UTC date before 05:30 in India. */
export function localOrderDate(now = new Date()) {
  return `${now.getFullYear()}-${String(now.getMonth() + 1).padStart(2, '0')}-${String(now.getDate()).padStart(2, '0')}`;
}
export const blankOrderHeader = () => ({ ...blankTourHeader(), vchDate: localOrderDate() });

export function validateSalesOrderDate(value: string) {
  const match = /^(\d{4})-(\d{2})-(\d{2})$/.exec(value);
  if (!match) throw new Error('Enter a valid order date');
  const parsed = new Date(`${value}T00:00:00Z`);
  if (!Number.isFinite(parsed.getTime()) || parsed.toISOString().slice(0, 10) !== value)
    throw new Error('Enter a valid order date');
  return value;
}

export function hydrateSalesOrder(document: Record<string, any>) {
  const hydrated = hydrateTourOrder(document);
  const rows: Row[] = hydrated.rows.map((row: OrderRow): Row => ({
    ...row,
    clientKey: `sales-row-${++nextClientKey}`,
    dirtyFields: [],
    componentDirty: {},
    orderEdits: [],
    draftFields: [],
    calculationPending: false,
    calculationBasis: {
      netWt: row.netWt,
      ghtWt: row.ghtWt,
      touch: row.touch,
      westPct: row.westPct,
      rate: row.rate,
      labourAmount: row.labourAmount,
      otherAmount: row.otherAmount,
    },
    fineWeight: String(
      document.lines?.find((line: any) => String(line.srNo) === row.srNo)?.fineWeight ?? '',
    ),
    labourCache: {
      labourRate: numeric(row.labourRate, 'Saved labour rate'),
      labourAmount: numeric(row.labourAmount, 'Saved labour amount'),
      labourPct: numeric(row.labourPct, 'Saved labour percentage'),
    },
  }));
  return {
    ...hydrated,
    rows,
  };
}

const readonlyHeader = new Set([
  'voucherNo',
  'hiddenVoucherNo',
  'mainUser',
  'version',
  'labourIncludesGhat',
  'labourRateDecimals',
  'editBlockedReason',
  'coCode',
  'lcCode',
  'coYear',
  'coBook',
  'total',
  'lines',
]);
const readonlyLine = new Set([
  'consumed',
  'clientKey',
  'fineWeight',
  'itemAmount',
  'lineNetAmount',
  'lineTotalAmount',
  'components',
]);
/** Keep unchanged input-shaped values exactly as returned; never accept client ledger/raw-table state. */
export function salesOrderPayload(
  f: ReturnType<typeof blankOrderHeader>,
  header: Record<string, string>,
  rows: Row[],
  expectedVersion?: string,
  original?: Record<string, any>,
  dirtyFields: readonly string[] = [],
) {
  validateSalesOrderDate(f.vchDate);
  // A saved parent with a cleared item code is an invalid edit, not an implicit row deletion.
  for (const row of rows)
    if (
      !row.itCode.trim() &&
      row.srNo &&
      original?.lines?.some((line: any) => String(line.srNo) === row.srNo)
    )
      throw new Error('Restore the saved item code or remove its row explicitly');
  const calculated = tourOrderPayload(f, header, rows, expectedVersion);
  calculated.dirtyFields = [...dirtyFields];
  const keptRows = rows.filter((row) => row.itCode.trim());
  for (const [index, line] of (calculated.lines as Record<string, any>[]).entries()) {
    const row = keptRows[index]!;
    line.dirtyFields = row.dirtyFields;
    for (const child of line.components)
      child.dirtyFields = row.componentDirty[String(child.isrNo)] ?? [];
    if (row.orderEdits.length) {
      const textIntent = new Set<string>();
      for (const event of row.orderEdits) {
        if (event.kind === 'design')
          ['designNo', 'itmSize', 'karigarName', 'designImageId'].forEach((field) =>
            textIntent.add(field),
          );
        else if (event.kind === 'clearDesign')
          ['designNo', 'designImageId'].forEach((field) => textIntent.add(field));
        else if (
          event.kind === 'field' &&
          journalFields.has(event.field) &&
          !numericJournalFields.has(event.field)
        )
          textIntent.add(event.field);
      }
      // Empty source cells are actual selection results. Omission would let a writer
      // retain an old linked image or substitute new-row N instead of the selected blank.
      for (const field of textIntent) line[field] = String(row[field as keyof Row] ?? '');
      line.dirtyFields = [...new Set([...row.dirtyFields, ...textIntent])];
      line.orderEdits = row.orderEdits;
      delete line.labourEdits;
      delete line.labourAction;
    }
  }
  if (!original) return calculated;
  const result: Record<string, any> = Object.fromEntries(
    Object.entries(original).filter(([key]) => !readonlyHeader.has(key)),
  );
  Object.assign(result, calculated);
  for (const [key, current] of Object.entries({ ...f, ...header })) {
    if (
      !dirtyFields.includes(key) &&
      Object.hasOwn(original, key) &&
      current === String(original[key] ?? '')
    )
      result[key] = original[key];
  }
  const kept = rows.filter((row) => row.itCode.trim());
  result.lines = (calculated.lines as Record<string, any>[]).map((line, index) => {
    const row = kept[index]!;
    const prior = original.lines?.find((saved: any) => String(saved.srNo) === row.srNo);
    if (!prior) return line;
    const out: Record<string, any> = {
      ...Object.fromEntries(Object.entries(prior).filter(([key]) => !readonlyLine.has(key))),
      ...line,
    };
    for (const key of Object.keys(blankTourRow()))
      if (
        !readonlyLine.has(key) &&
        !['labourEdits', 'labourAction'].includes(key) &&
        Object.hasOwn(prior, key) &&
        !line.dirtyFields.includes(key) &&
        String((row as any)[key] ?? '') === String(prior[key] ?? '')
      )
        out[key] = prior[key];
    out.components = line.components.map((child: Record<string, any>) => {
      const priorChild = prior.components?.find(
        (saved: any) => String(saved.isrNo) === String(child.isrNo),
      );
      const draft = row.components.find((value) => String(value.isrNo) === String(child.isrNo));
      if (!priorChild || !draft) return child;
      const resultChild = { ...priorChild, ...child };
      for (const key of Object.keys(SUB_DETAIL_COLUMNS))
        if (
          Object.hasOwn(priorChild, key) &&
          !row.componentDirty[String(child.isrNo)]?.includes(key) &&
          String((draft as any)[key] ?? '') === String(priorChild[key] ?? '')
        )
          resultChild[key] = priorChild[key];
      return resultChild;
    });
    return out;
  });
  return result;
}
