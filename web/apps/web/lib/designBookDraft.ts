import {
  createDesignCalculationState,
  applyDesignCalculationEvent,
  designRepeatValues,
  type DesignCalculationEvent,
  type DesignCalculationPolicy,
  type DesignCalculationState,
  type DesignCalculationValues,
  type DesignComponentDefaults,
} from '@datacare/core';

/** Full parent/component DTO mapping. Keep a saved column snapshot so NULL, zero, blank text,
 * dates and child identities survive an unchanged browser edit without reinterpretation. */
export interface DesignColumn {
  key: string;
  column: string;
  label: string;
  numeric?: boolean;
  identity?: boolean;
}
export const DESIGN_COLUMNS: DesignColumn[] = [
  { key: 'srNo', column: 'SR_NO', label: 'Sr', numeric: true, identity: true },
  { key: 'oldSrNo', column: 'OLD_SRNO', label: 'Original Sr', numeric: true, identity: true },
  { key: 'pageNo', column: 'PAGE_NO', label: 'Page No' },
  { key: 'designNo', column: 'DESIGN_NO', label: 'Design No' },
  { key: 'style', column: 'ITM_STYLE', label: 'Style' },
  { key: 'grCode', column: 'GR_CODE', label: 'Group' },
  { key: 'itmSize', column: 'ITM_SIZE', label: 'Size' },
  { key: 'dieNo', column: 'DIE_NO', label: 'Die No' },
  { key: 'pcs', column: 'ITM_PCS', label: 'Pcs', numeric: true },
  { key: 'grossWt', column: 'ITM_GWT', label: 'Gross', numeric: true },
  { key: 'otherWt', column: 'ITM_OTH_WT', label: 'Other Wt', numeric: true },
  { key: 'netWt', column: 'ITM_NWT', label: 'Net', numeric: true },
  { key: 'touch', column: 'ITM_TOUCH', label: 'Touch', numeric: true },
  { key: 'westPct', column: 'ITM_WEST_PRC', label: 'West %', numeric: true },
  { key: 'fineWt', column: 'ITM_FINE', label: 'Fine', numeric: true },
  { key: 'ghatPct', column: 'GHT_PRC', label: 'Ghat %', numeric: true },
  { key: 'ghatWt', column: 'ITM_GHT', label: 'Ghat Wt', numeric: true },
  { key: 'rate', column: 'ITM_RATE', label: 'Rate', numeric: true },
  { key: 'amount', column: 'ITM_AMT', label: 'Amount', numeric: true },
  { key: 'labourType', column: 'LBR_TYPE', label: 'Labour Type' },
  { key: 'labourPct', column: 'LBR_PRC', label: 'Labour %', numeric: true },
  { key: 'labourRate', column: 'LBR_RATE', label: 'Labour Rate', numeric: true },
  { key: 'labourAmount', column: 'LBR_AMT', label: 'Labour Amount', numeric: true },
  { key: 'otherAmount', column: 'OTH_AMT', label: 'Other Amount', numeric: true },
  { key: 'tagCost', column: 'TAG_COST', label: 'Tag Cost', numeric: true },
  { key: 'mrp', column: 'ITM_MRP', label: 'MRP', numeric: true },
  { key: 'netAmount', column: 'NET_AMT', label: 'Net Amount', numeric: true },
  { key: 'rateType', column: 'RATE_TYPE', label: 'Rate Type' },
  { key: 'itType', column: 'IT_TYPE', label: 'Item Type' },
  { key: 'karigarName', column: 'KR_NAME', label: 'Karigar' },
];
export const COMPONENT_COLUMNS: DesignColumn[] = [
  { key: 'isrNo', column: 'ISR_NO', label: 'Sr', numeric: true, identity: true },
  { key: 'itCode', column: 'IT_CODE', label: 'Item' },
  { key: 'itType', column: 'IT_TYPE', label: 'Item Type' },
  { key: 'pcs', column: 'IT_PCS', label: 'Pcs', numeric: true },
  { key: 'pcsWt', column: 'IT_PCS_WT', label: 'Piece Weight', numeric: true },
  { key: 'karigarWt', column: 'KR_WT', label: 'Karigar Weight', numeric: true },
  { key: 'karigarLessPct', column: 'KR_LESS_PRC', label: 'Karigar Less %', numeric: true },
  { key: 'grossWt', column: 'IT_GWT', label: 'Customer Weight', numeric: true },
  { key: 'conversionPct', column: 'IT_CON_PRC', label: 'Conversion', numeric: true },
  { key: 'conversionWt', column: 'IT_CON_WT', label: 'Converted Weight', numeric: true },
  { key: 'rateType', column: 'IT_RATE_TYPE', label: 'Rate Basis' },
  { key: 'rate', column: 'IT_RATE', label: 'Rate', numeric: true },
  { key: 'amount', column: 'IT_AMT', label: 'Item Amount', numeric: true },
  { key: 'labourRate', column: 'IT_LBR_RATE', label: 'Labour Rate', numeric: true },
  { key: 'labourAmount', column: 'IT_LBR_AMT', label: 'Labour Amount', numeric: true },
  { key: 'netAmount', column: 'IT_NET_AMT', label: 'Net Amount', numeric: true },
];
export type SavedRow = Record<string, unknown>;
export interface ComponentDraft {
  values: Record<string, string>;
  saved?: SavedRow;
}
export interface DesignDraft extends ComponentDraft {
  components: ComponentDraft[];
  nextComponentSerial: number;
  calculation?: {
    state: DesignCalculationState;
    events: DesignCalculationEvent[];
    policy: DesignCalculationPolicy;
    version: string;
  };
}
export interface DesignCalculationConfig extends DesignCalculationPolicy {
  version: string;
  columns: { bookName: string; name: string; label: string; visible: boolean; repeat: boolean }[];
}
export const DESIGN_TRANSIENT_COLUMNS: DesignColumn[] = [
  { key: 'purchaseCost', column: '', label: 'Purchase Cost', numeric: true },
  { key: 'marginPct', column: '', label: 'Margin %', numeric: true },
];
const parentCalculationFields = new Set([
  'pcs',
  'grossWt',
  'otherWt',
  'netWt',
  'ghatPct',
  'ghatWt',
  'touch',
  'westPct',
  'fineWt',
  'labourPct',
  'labourType',
  'labourRate',
  'labourAmount',
  'otherAmount',
  'rate',
  'rateType',
  'amount',
  'tagCost',
  'mrp',
  'itType',
  'purchaseCost',
  'marginPct',
]);
const parentDesktopNames: Record<string, string> = {
  pageNo: 'Page No',
  designNo: 'Design',
  style: 'Style',
  grCode: 'GrCode',
  itmSize: 'Size',
  dieNo: 'DieNo',
  pcs: 'Pcs',
  grossWt: 'GrWt',
  otherWt: 'LsWt',
  netWt: 'NetWt',
  ghatPct: 'Ght%',
  ghatWt: 'GhtWt',
  touch: 'Touch',
  westPct: 'West%',
  fineWt: 'Fine',
  labourPct: 'Lbr%',
  labourType: 'LType',
  labourRate: 'LbrRate',
  labourAmount: 'LbrAmt',
  otherAmount: 'OthAmt',
  rate: 'ItRate',
  amount: 'ItAmt',
  tagCost: 'TagCost',
  purchaseCost: 'PrCost',
  marginPct: 'Margin',
  mrp: 'Mrp',
  karigarName: 'KrCod',
};
const componentDesktopNames: Record<string, string> = {
  itCode: 'ItCode',
  pcs: 'Pcs',
  pcsWt: 'PcsWt',
  karigarWt: 'KrWt',
  karigarLessPct: 'KrLs%',
  grossWt: 'Weight',
  conversionPct: 'Con%',
  rateType: 'P/W',
  rate: 'Rate',
  amount: 'ItAmt',
  labourRate: 'LbrRate',
  labourAmount: 'LbrAmt',
  netAmount: 'NetAmt',
  conversionWt: 'ConWt',
  itType: 'ItType',
};
/** Configuration changes visibility/labels only; every saved column remains in the DTO. */
export function configuredDesignColumns(
  config: DesignCalculationConfig | null,
  components = false,
): DesignColumn[] {
  const columns = components ? COMPONENT_COLUMNS : [...DESIGN_COLUMNS, ...DESIGN_TRANSIENT_COLUMNS];
  const names = components ? componentDesktopNames : parentDesktopNames;
  const bookName = components ? 'TAG_IDTL' : 'DESIGN DETL';
  return columns.flatMap((column) => {
    const setting = config?.columns.find(
      (entry) => entry.bookName === bookName && entry.name === names[column.key],
    );
    if (!column.identity && setting && !setting.visible) return [];
    return [{ ...column, label: setting?.label || column.label }];
  });
}
const str = (value: unknown) => String(value ?? '');
const valuesFrom = (row: SavedRow, columns: DesignColumn[]) =>
  Object.fromEntries(columns.map(({ key, column }) => [key, str(row[column])]));
export function blankComponent(serial: number): ComponentDraft {
  return { values: { ...valuesFrom({}, COMPONENT_COLUMNS), isrNo: String(serial) } };
}
export function blankDesign(serial: number): DesignDraft {
  return {
    values: { ...valuesFrom({}, DESIGN_COLUMNS), srNo: String(serial), oldSrNo: String(serial) },
    components: [],
    nextComponentSerial: 1,
  };
}
export function designFromDb(row: SavedRow): DesignDraft {
  const children = Array.isArray(row.components) ? (row.components as SavedRow[]) : [];
  return {
    values: valuesFrom(row, DESIGN_COLUMNS),
    saved: row,
    components: children.map((child) => ({
      values: valuesFrom(child, COMPONENT_COLUMNS),
      saved: child,
    })),
    nextComponentSerial: Math.max(0, ...children.map((child) => Number(child.ISR_NO))) + 1,
  };
}
function payload(row: ComponentDraft, columns: DesignColumn[]): Record<string, unknown> {
  return Object.fromEntries(
    columns.map(({ key, column, numeric, label }) => {
      const value = row.values[key] ?? '';
      if (row.saved && Object.hasOwn(row.saved, column) && str(row.saved[column]) === value)
        return [key, row.saved[column]];
      if (!numeric) return [key, value.trim()];
      if (value.trim() === '') return [key, row.saved ? null : undefined];
      const result = Number(value);
      if (!Number.isFinite(result)) throw new Error(`${label} must be a finite number.`);
      return [key, result];
    }),
  );
}
export function designToPayload(row: DesignDraft): Record<string, unknown> {
  if (!row.values.designNo.trim()) throw new Error('Every design line needs a design number.');
  for (const child of row.components) {
    if (!child.values.itCode.trim())
      throw new Error(`Every component of ${row.values.designNo} needs an item.`);
  }
  return {
    ...payload(row, DESIGN_COLUMNS),
    // The date is per parent, even though the original screen has one optional date for new entries.
    ...(row.saved ? { vchDate: row.saved.VCH_DATE, designImageId: row.saved.DESIGN_IMG_ID } : {}),
    components: row.components.map((child) => payload(child, COMPONENT_COLUMNS)),
    ...(row.calculation?.events.length
      ? {
          calculationVersion: row.calculation.version,
          calculationEvents: row.calculation.events.map((event) =>
            event.kind === 'item'
              ? { kind: event.kind, isrNo: event.isrNo, itCode: event.itCode }
              : event.kind === 'componentEnter'
                ? { kind: event.kind, isrNo: event.isrNo, field: event.field, value: event.value }
                : event,
          ),
        }
      : {}),
  };
}

/** Attach the engine without modifying saved cells. New parent defaults come from CO_SET. */
export function initializeDesignCalculations(
  row: DesignDraft,
  config: DesignCalculationConfig,
  newBook: boolean,
): DesignDraft {
  const values: Record<string, string> = { ...row.values, purchaseCost: '', marginPct: '' };
  if (!row.saved) {
    values.pcs = values.pcs || '1';
    values.labourType = values.labourType || config.defaultLabourType;
  }
  const parent = Object.fromEntries(
    Object.entries(payload({ ...row, values }, DESIGN_COLUMNS)).filter(([key]) =>
      parentCalculationFields.has(key),
    ),
  ) as DesignCalculationValues;
  const state = createDesignCalculationState(
    parent,
    row.components.map((child) => ({
      isrNo: Number(child.values.isrNo),
      values: payload(child, COMPONENT_COLUMNS) as DesignCalculationValues,
    })),
    config,
    Boolean(row.saved),
  );
  return {
    ...row,
    values,
    calculation: { state, events: [], policy: { ...config, newBook }, version: config.version },
  };
}
function applyDraftEvent(row: DesignDraft, event: DesignCalculationEvent): DesignDraft {
  if (!row.calculation) return row;
  const state = applyDesignCalculationEvent(row.calculation.state, event, row.calculation.policy);
  const values = { ...row.values };
  for (const [key, value] of Object.entries(state.values)) values[key] = str(value);
  return {
    ...row,
    values,
    components: row.components.map((child) => {
      const result = state.components.find((item) => item.isrNo === Number(child.values.isrNo));
      return result
        ? {
            ...child,
            values: {
              ...child.values,
              ...Object.fromEntries(
                Object.entries(result.values).map(([key, value]) => [key, str(value)]),
              ),
            },
          }
        : child;
    }),
    calculation: { ...row.calculation, state, events: [...row.calculation.events, event] },
  };
}
export function commitDesignField(
  row: DesignDraft,
  field: string,
  value: string,
  isrNo?: number,
): DesignDraft {
  if (
    !row.calculation ||
    (isrNo === undefined && !parentCalculationFields.has(field)) ||
    field === 'isrNo' ||
    field === 'itCode'
  )
    return row;
  const previous =
    isrNo === undefined
      ? row.calculation.state.values[field]
      : row.calculation.state.components.find((child) => child.isrNo === isrNo)?.values[field];
  if (str(previous) === value) return row;
  try {
    return applyDraftEvent(
      row,
      isrNo === undefined
        ? { kind: 'parent', field, value }
        : { kind: 'component', isrNo, field, value },
    );
  } catch (error) {
    const columns =
      isrNo === undefined ? [...DESIGN_COLUMNS, ...DESIGN_TRANSIENT_COLUMNS] : COMPONENT_COLUMNS;
    const label = columns.find((column) => column.key === field)?.label ?? field;
    throw new Error(
      `${isrNo === undefined ? 'Design' : `Component ${isrNo}`} ${label}: ${error instanceof Error ? error.message : 'Invalid value'}`,
    );
  }
}
export function addDesignComponent(row: DesignDraft): DesignDraft {
  row = commitPendingDesignFields(row);
  const serial = row.nextComponentSerial;
  const next = {
    ...row,
    nextComponentSerial: serial + 1,
    components: [...row.components, blankComponent(serial)],
  };
  const added = applyDraftEvent(next, { kind: 'addComponent', isrNo: serial });
  const previous = row.components.at(-1);
  const previousState = row.calculation?.state.components.find(
    (child) => child.isrNo === Number(previous?.values.isrNo),
  );
  if (
    !previous ||
    !row.calculation ||
    !Object.keys(
      designRepeatValues(
        {
          ...previous.values,
          ...previousState?.values,
          oldKarigarWt: previousState?.oldKarigarWt,
          oldGrossWt: previousState?.oldGrossWt,
        },
        row.calculation.policy,
        true,
      ),
    ).length
  )
    return added;
  return applyDraftEvent(added, {
    kind: 'repeatComponent',
    isrNo: serial,
    fromIsrNo: Number(previous.values.isrNo),
  });
}

/** The previous row is a copy source, not a new parent/child identity or a leave-cell trigger. */
export function newDesignWithRepeat(
  serial: number,
  previous: DesignDraft | undefined,
  config: DesignCalculationConfig,
  newBook: boolean,
): DesignDraft {
  const fresh = initializeDesignCalculations(blankDesign(serial), config, newBook);
  if (!previous) return fresh;
  const copied = designRepeatValues(previous.values, config);
  const next = {
    ...fresh,
    values: {
      ...fresh.values,
      ...Object.fromEntries(Object.entries(copied).map(([key, value]) => [key, str(value)])),
    },
  };
  const calculated = Object.fromEntries(
    Object.entries(copied).filter(([key]) => parentCalculationFields.has(key)),
  );
  return Object.keys(calculated).length
    ? applyDraftEvent(next, { kind: 'repeatParent', values: calculated })
    : next;
}

/** Explicit Enter executes the desktop KeyDown/LeaveCell path even when a numeric cell is unchanged. */
export function enterDesignField(
  row: DesignDraft,
  field: string,
  value: string,
  isrNo?: number,
  defaults?: DesignComponentDefaults,
): DesignDraft {
  if (!row.calculation) throw new Error('Load design calculation settings before editing.');
  if (
    isrNo === undefined &&
    field === 'grossWt' &&
    Number(value) === 0 &&
    row.values.rateType !== 'P'
  )
    throw new Error('Enter a nonzero gross weight before opening components, or use rate basis P.');
  if (isrNo !== undefined && ['pcsWt', 'grossWt', 'netAmount'].includes(field))
    return applyDraftEvent(row, {
      kind: 'componentEnter',
      isrNo,
      field: field as 'pcsWt' | 'grossWt' | 'netAmount',
      value,
      defaults,
    });
  if (isrNo === undefined && parentCalculationFields.has(field))
    return applyDraftEvent(row, { kind: 'parent', field, value });
  if (isrNo !== undefined && field !== 'itCode' && field !== 'isrNo')
    return applyDraftEvent(row, { kind: 'component', isrNo, field, value });
  return row;
}
export function removeDesignComponent(row: DesignDraft, index: number): DesignDraft {
  const child = row.components[index];
  if (!child) return row;
  return applyDraftEvent(
    { ...row, components: row.components.filter((_, position) => position !== index) },
    { kind: 'removeComponent', isrNo: Number(child.values.isrNo) },
  );
}
export function discardEmptyDesignComponent(row: DesignDraft, isrNo: number): DesignDraft {
  const child = row.components.find((entry) => Number(entry.values.isrNo) === isrNo);
  if (
    !child ||
    child.saved ||
    Object.entries(child.values).some(([key, value]) => key !== 'isrNo' && value !== '')
  )
    return row;
  return applyDraftEvent(
    { ...row, components: row.components.filter((entry) => entry !== child) },
    { kind: 'discardEmptyComponent', isrNo },
  );
}
export function selectDesignComponentItem(
  row: DesignDraft,
  isrNo: number,
  itCode: string,
  defaults: DesignComponentDefaults,
  force = false,
): DesignDraft {
  if (
    !force &&
    row.calculation?.state.components.find((child) => child.isrNo === isrNo)?.values.itCode ===
      itCode
  )
    return row;
  return applyDraftEvent(row, { kind: 'item', isrNo, itCode, defaults });
}
export function refreshDesignParent(row: DesignDraft): DesignDraft {
  return applyDraftEvent(row, { kind: 'refreshParent' });
}

/** Flush any changed cell when save is activated directly while the editor has focus. */
export function commitPendingDesignFields(row: DesignDraft): DesignDraft {
  let next = row;
  for (const column of [...DESIGN_COLUMNS, ...DESIGN_TRANSIENT_COLUMNS])
    next = commitDesignField(next, column.key, next.values[column.key] ?? '');
  for (const child of next.components) {
    for (const column of COMPONENT_COLUMNS) {
      const current = next.components.find((item) => item.values.isrNo === child.values.isrNo)!;
      next = commitDesignField(
        next,
        column.key,
        current.values[column.key] ?? '',
        Number(child.values.isrNo),
      );
    }
  }
  return next;
}
