import { Decimal } from 'decimal.js';
import { round, roundHalfEven } from './money.js';

/** MS_DESIGN_BOOK:2540–2695, 3154–3710. These are ordered cell-leave operations,
 * not a formula that can be run indiscriminately on every loaded row. */
export type DesignCalculationValues = Record<string, string | number | null | undefined>;
export interface DesignCalculationPolicy {
  defaultLabourType: string;
  automaticCost: boolean;
  tagCostVisible: boolean;
  newBook?: boolean;
  columns?: { bookName: string; name: string; label: string; visible: boolean; repeat: boolean }[];
}
export interface DesignComponentDefaults {
  itType: string;
  conversionPct: string | number | null;
  rateType: string;
  rate: string | number | null;
}
export type DesignCalculationEvent =
  | { kind: 'parent'; field: string; value: string | number | null }
  | { kind: 'component'; isrNo: number; field: string; value: string | number | null }
  | { kind: 'addComponent'; isrNo: number }
  | { kind: 'removeComponent'; isrNo: number }
  | { kind: 'discardEmptyComponent'; isrNo: number }
  | { kind: 'item'; isrNo: number; itCode: string; defaults?: DesignComponentDefaults }
  | { kind: 'repeatParent'; values: DesignCalculationValues }
  | { kind: 'repeatComponent'; isrNo: number; fromIsrNo: number }
  | {
      kind: 'componentEnter';
      isrNo: number;
      field: 'pcsWt' | 'grossWt' | 'netAmount';
      value: string | number | null;
      defaults?: DesignComponentDefaults;
    }
  | { kind: 'refreshParent' };
interface ComponentState {
  isrNo: number;
  values: DesignCalculationValues;
  oldKarigarWt: number;
  oldGrossWt: number;
  repeatEligible?: boolean;
}
export interface DesignCalculationState {
  values: DesignCalculationValues;
  components: ComponentState[];
  old: { grossWt: number; netWt: number; touch: number; westPct: number; marginPct: number };
  repeatEligible?: boolean;
}

const parentRepeatNames: Record<string, string> = {
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
const componentRepeatNames: Record<string, string> = {
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
  karigarConversionWt: 'KrConWt',
  itType: 'ItType',
  oldKarigarWt: 'OldKrWt',
  oldGrossWt: 'OldGrWt',
};

/** CommPassAdd/CommPassAdd_Idtl look up COL_RPT by the renamed header, including hidden cells.
 * Copy values without rounding or running leave-cell calculations. Identities/images are excluded. */
export function designRepeatValues(
  values: DesignCalculationValues,
  policy: DesignCalculationPolicy,
  components = false,
): DesignCalculationValues {
  const book = components ? 'TAG_IDTL' : 'DESIGN DETL';
  const columns = (policy.columns ?? []).filter((column) => column.bookName === book);
  const result: DesignCalculationValues = {};
  for (const [key, name] of Object.entries(components ? componentRepeatNames : parentRepeatNames)) {
    const renamed = columns.find((column) => column.name === name)?.label ?? name;
    const matching = columns.filter((column) => column.label === renamed);
    if (
      matching.some((column) => column.repeat) &&
      (!renamed || new Set(matching.map((column) => column.repeat)).size > 1)
    )
      throw new Error('Ambiguous design repeat column labels require reconciliation.');
    if (matching[0]?.repeat && Object.hasOwn(values, key)) {
      if (
        Object.hasOwn(components ? componentDp : parentDp, key) ||
        key === 'oldKarigarWt' ||
        key === 'oldGrossWt'
      )
        n(values[key]);
      result[key] = values[key];
    }
  }
  return result;
}

const parentDp: Record<string, number> = {
  pcs: 0,
  grossWt: 3,
  otherWt: 3,
  netWt: 3,
  ghatPct: 2,
  ghatWt: 3,
  touch: 2,
  westPct: 2,
  fineWt: 3,
  labourPct: 2,
  labourRate: 2,
  labourAmount: 2,
  otherAmount: 2,
  rate: 2,
  amount: 2,
  tagCost: 2,
  purchaseCost: 2,
  marginPct: 2,
  mrp: 2,
};
const componentDp: Record<string, number> = {
  pcs: 0,
  pcsWt: 3,
  karigarWt: 3,
  karigarLessPct: 2,
  grossWt: 3,
  conversionPct: 3,
  rate: 2,
  amount: 2,
  labourRate: 2,
  labourAmount: 2,
  netAmount: 2,
  conversionWt: 3,
  karigarConversionWt: 3,
};
const parentText = new Set(['labourType', 'rateType', 'itType']);
const componentText = new Set(['rateType', 'itType']);
function n(value: unknown): number {
  if (value == null || value === '') return 0;
  if ((typeof value !== 'string' && typeof value !== 'number') || !Number.isFinite(Number(value)))
    throw new Error('Design calculation values must be finite numbers.');
  return Number(value);
}
const d = (value: unknown) => new Decimal(n(value));
const nz = (value: unknown) => n(value) !== 0;
function validSerial(value: number) {
  if (!Number.isSafeInteger(value) || value <= 0)
    throw new Error('Invalid design component serial.');
}

/** Hydration deliberately does not calculate, round or clear any persisted value. */
export function createDesignCalculationState(
  values: DesignCalculationValues = {},
  components: { isrNo: number; values: DesignCalculationValues }[] = [],
  policy: DesignCalculationPolicy = {
    defaultLabourType: 'G',
    automaticCost: false,
    tagCostVisible: true,
  },
  existing = true,
): DesignCalculationState {
  const parent: DesignCalculationValues = existing
    ? { ...values }
    : { pcs: 1, labourType: policy.defaultLabourType, ...values };
  const serials = new Set<number>();
  return {
    values: parent,
    repeatEligible: !existing,
    components: components.map((component) => {
      validSerial(component.isrNo);
      if (serials.has(component.isrNo)) throw new Error('Duplicate design component serial.');
      serials.add(component.isrNo);
      return {
        ...component,
        values: { ...component.values },
        oldKarigarWt: n(component.values.karigarWt),
        oldGrossWt: n(component.values.grossWt),
      };
    }),
    old: {
      grossWt: n(parent.grossWt),
      netWt: n(parent.netWt),
      touch: n(parent.touch),
      westPct: n(parent.westPct),
      marginPct: 0,
    },
  };
}

function aggregateChildren(state: DesignCalculationState) {
  const weight = state.components.reduce(
    (sum, child) => sum.plus(d(child.values.conversionWt)),
    new Decimal(0),
  );
  const amount = state.components.reduce(
    (sum, child) => sum.plus(d(child.values.netAmount)),
    new Decimal(0),
  );
  // Source nonzero guards intentionally retain a manual parent value when the total is zero.
  if (!weight.isZero()) {
    state.values.otherWt = round(weight, 3);
    state.values.netWt = round(d(state.values.grossWt).minus(weight), 3);
  }
  if (!amount.isZero()) state.values.otherAmount = round(amount, 2);
}

function calculateComponent(state: DesignCalculationState, child: ComponentState) {
  const v = child.values;
  if (nz(v.pcs) && nz(v.pcsWt)) v.karigarWt = round(d(v.pcs).times(d(v.pcsWt)), 3);
  if (nz(v.karigarLessPct)) {
    v.grossWt = round(d(v.karigarWt).times(d(v.karigarLessPct)).div(100), 3);
    child.oldGrossWt = n(v.grossWt);
  }
  if (n(v.karigarWt) !== child.oldKarigarWt && !nz(v.grossWt)) {
    child.oldKarigarWt = round(d(v.karigarWt), 3);
    v.grossWt = round(d(v.karigarWt), 3);
  }
  if (n(v.grossWt) !== child.oldGrossWt && !nz(v.karigarWt)) {
    child.oldGrossWt = round(d(v.grossWt), 3);
    v.karigarWt = round(d(v.grossWt), 3);
  }
  v.conversionWt =
    nz(v.grossWt) && nz(v.conversionPct) ? round(d(v.grossWt).times(d(v.conversionPct)), 3) : 0;
  v.karigarConversionWt =
    nz(v.karigarWt) && nz(v.conversionPct) ? round(d(v.karigarWt).times(d(v.conversionPct)), 3) : 0;
  if (!v.rateType) {
    if (!nz(v.grossWt) && nz(v.pcs) && nz(v.rate)) v.amount = round(d(v.rate).times(d(v.pcs)), 2);
    else if (nz(v.grossWt) && nz(v.rate)) v.amount = round(d(v.rate).times(d(v.grossWt)), 2);
  } else if (v.rateType === 'P' && roundHalfEven(d(v.rate), 0) !== 0) {
    // Actual IL: (-1 if basis P else 0) & checked((long)Math.Round(rate)).
    // A P rate of ±0.50 falls through to customer weight; ±0.51 uses pieces.
    v.amount = round(d(v.rate).times(d(v.pcs)), 2);
  } else if (nz(v.rate)) v.amount = round(d(v.rate).times(d(v.grossWt)), 2);
  if (nz(v.labourRate)) v.labourAmount = round(d(v.labourRate).times(d(v.pcs)), 2);
  const total = d(v.amount).plus(d(v.labourAmount));
  if (!total.isZero()) v.netAmount = round(total, 2);
  aggregateChildren(state);
}

function calculateParent(state: DesignCalculationState, policy: DesignCalculationPolicy) {
  const v = state.values;
  const fine = () =>
    round(
      d(v.netWt)
        .plus(d(v.ghatWt))
        .times(d(v.touch).plus(d(v.westPct)))
        .div(100),
      3,
    );
  const touchWest = () => d(v.touch).plus(d(v.westPct));
  if (n(v.grossWt) !== state.old.grossWt) {
    state.old.grossWt = round(d(v.grossWt), 3);
    v.netWt = round(d(v.grossWt).minus(d(v.otherWt)), 3);
  }
  if (nz(v.otherWt) && nz(v.grossWt)) v.netWt = round(d(v.grossWt).minus(d(v.otherWt)), 3);
  if (n(v.netWt) !== state.old.netWt) {
    state.old.netWt = round(d(v.netWt), 3);
    v.fineWt = !touchWest().isZero() && nz(v.netWt) ? fine() : round(d(v.netWt), 3);
  }
  // Preserve desktop ordering: a net change above uses the previous ghat weight.
  if (nz(v.ghatPct) && nz(v.netWt)) v.ghatWt = round(d(v.netWt).times(d(v.ghatPct)).div(100), 3);
  if (n(v.touch) !== state.old.touch) {
    state.old.touch = round(d(v.touch), 2);
    if (!touchWest().isZero() && nz(v.netWt)) v.fineWt = fine();
  }
  if (n(v.westPct) !== state.old.westPct) {
    state.old.westPct = round(d(v.westPct), 2);
    if (!touchWest().isZero() && nz(v.netWt)) v.fineWt = fine();
  }
  if (touchWest().isZero()) v.fineWt = round(d(v.netWt).plus(d(v.ghatWt)), 3);
  if (!nz(v.fineWt) && !touchWest().isZero()) v.fineWt = fine();
  if (nz(v.rate) && nz(v.fineWt)) {
    const basis = v.rateType === 'P' ? d(v.pcs) : d(v.fineWt);
    const divisor = v.rateType === '1' ? 10 : v.rateType === 'K' ? 1000 : 1;
    v.amount = roundHalfEven(basis.times(d(v.rate).div(divisor)), 0);
  }
  if (nz(v.labourRate)) {
    const basis =
      v.labourType === 'P'
        ? d(v.pcs)
        : v.labourType === 'N' || v.labourType === 'K'
          ? d(v.netWt).plus(d(v.ghatWt))
          : d(v.grossWt);
    v.labourAmount = roundHalfEven(
      basis.times(d(v.labourRate).div(v.labourType === 'K' ? 1000 : 1)),
      0,
    );
  }
  // LBR_PRC is an editable stored field but is not consumed by this desktop helper.
  if (policy.automaticCost) {
    v.tagCost = round(d(v.amount).plus(d(v.labourAmount)).plus(d(v.otherAmount)), 1);
    v.purchaseCost = v.tagCost;
  }
  if (nz(v.tagCost) && n(v.marginPct) !== state.old.marginPct) {
    state.old.marginPct = round(d(v.marginPct), 2);
    v.mrp = roundHalfEven(d(v.tagCost).times(d(v.marginPct).div(100).plus(1)), 0);
  }
  if (!policy.tagCostVisible && nz(v.purchaseCost) && n(v.marginPct) !== state.old.marginPct) {
    state.old.marginPct = round(d(v.marginPct), 2);
    v.mrp = roundHalfEven(d(v.purchaseCost).times(d(v.marginPct).div(100).plus(1)), 0);
  }
}

/** Returns a new state; reject unsupported events rather than silently ignoring a typo. */
export function applyDesignCalculationEvent(
  current: DesignCalculationState,
  event: DesignCalculationEvent,
  policy: DesignCalculationPolicy,
): DesignCalculationState {
  const state: DesignCalculationState = {
    values: { ...current.values },
    old: { ...current.old },
    repeatEligible: current.repeatEligible,
    components: current.components.map((child) => ({ ...child, values: { ...child.values } })),
  };
  if (event.kind === 'repeatParent') {
    if (!state.repeatEligible) throw new Error('Only a new design can receive repeat defaults.');
    const allowed = designRepeatValues(event.values, policy);
    for (const [key, value] of Object.entries(event.values)) {
      if (!Object.hasOwn(allowed, key) || (!Object.hasOwn(parentDp, key) && !parentText.has(key)))
        throw new Error(`Unsupported design repeat field: ${key}`);
      state.values[key] = value;
    }
    state.repeatEligible = false;
    return state;
  }
  if (event.kind === 'refreshParent') {
    aggregateChildren(state);
    calculateParent(state, policy);
    return state;
  }
  if (event.kind === 'parent') {
    const dp = parentDp[event.field];
    if (dp === undefined && !parentText.has(event.field))
      throw new Error(`Unsupported design calculation field: ${event.field}`);
    state.values[event.field] =
      dp === undefined ? String(event.value ?? '') : round(d(event.value), dp);
    if (event.field === 'otherWt' && state.components[0])
      calculateComponent(state, state.components[0]);
    if (dp !== undefined && event.field !== 'pcs') calculateParent(state, policy);
    return state;
  }
  if (!('isrNo' in event)) throw new Error('Invalid design calculation event.');
  validSerial(event.isrNo);
  if (event.kind === 'addComponent') {
    if (state.components.some((child) => child.isrNo === event.isrNo))
      throw new Error('Duplicate design component serial.');
    state.components.push({
      isrNo: event.isrNo,
      values: {},
      oldKarigarWt: 0,
      oldGrossWt: 0,
      repeatEligible: true,
    });
    return state;
  }
  const child = state.components.find((item) => item.isrNo === event.isrNo);
  if (!child) throw new Error('Design calculation component was not found.');
  if (event.kind === 'discardEmptyComponent') {
    if (
      !child.repeatEligible ||
      Object.values(child.values).some((value) => value != null && value !== '')
    )
      throw new Error('Only an untouched empty new component can be discarded.');
    state.components = state.components.filter((item) => item.isrNo !== event.isrNo);
  } else if (event.kind === 'repeatComponent') {
    validSerial(event.fromIsrNo);
    const index = state.components.indexOf(child);
    const source = state.components[index - 1];
    if (!child.repeatEligible || !source || source.isrNo !== event.fromIsrNo)
      throw new Error('Repeat defaults require the preceding component of this design.');
    const copied = designRepeatValues(
      { ...source.values, oldKarigarWt: source.oldKarigarWt, oldGrossWt: source.oldGrossWt },
      policy,
      true,
    );
    for (const [key, value] of Object.entries(copied)) {
      if (key === 'oldKarigarWt') child.oldKarigarWt = n(value);
      else if (key === 'oldGrossWt') child.oldGrossWt = n(value);
      else child.values[key] = value;
    }
    child.repeatEligible = false;
  } else if (event.kind === 'componentEnter') {
    if (!['pcsWt', 'grossWt', 'netAmount'].includes(event.field))
      throw new Error('Unsupported component Enter field.');
    // KeyDown runs before LeaveCell: the zero-weight condition sees the previously committed grid weight.
    if (event.field === 'grossWt' && !nz(child.values.pcs) && !nz(child.values.grossWt)) {
      if (!event.defaults) throw new Error('Design component defaults were not resolved.');
      if (!nz(child.values.netAmount)) child.values.netAmount = round(d(event.defaults.rate), 2);
      child.values.rate = '';
    }
    if (event.field === 'pcsWt' && nz(child.values.pcs) && nz(event.value))
      child.values.karigarWt = round(d(child.values.pcs).times(d(event.value)), 3);
    child.values[event.field] = round(d(event.value), componentDp[event.field]!);
    calculateComponent(state, child);
  } else if (event.kind === 'removeComponent') {
    state.components = state.components.filter((item) => item.isrNo !== event.isrNo);
    if (state.components[0]) calculateComponent(state, state.components[0]);
    else aggregateChildren(state);
  } else if (event.kind === 'item') {
    if (!event.defaults) throw new Error('Design component defaults were not resolved.');
    child.values.itCode = event.itCode;
    child.values.itType = event.defaults.itType;
    if (!nz(child.values.conversionPct))
      child.values.conversionPct = round(d(event.defaults.conversionPct), 3);
    if (policy.newBook) {
      if (event.defaults.rateType === 'F') {
        if (!nz(child.values.netAmount)) child.values.netAmount = round(d(event.defaults.rate), 2);
      } else if (!nz(child.values.rate)) child.values.rate = round(d(event.defaults.rate), 2);
    }
    if (
      policy.newBook &&
      event.defaults.rateType &&
      event.defaults.rateType !== 'F' &&
      !child.values.rateType
    )
      child.values.rateType = event.defaults.rateType;
  } else if (event.kind === 'component') {
    const dp = componentDp[event.field];
    if (dp === undefined && !componentText.has(event.field))
      throw new Error(`Unsupported component calculation field: ${event.field}`);
    child.values[event.field] =
      dp === undefined ? String(event.value ?? '') : round(d(event.value), dp);
    if (dp !== undefined) calculateComponent(state, child);
  } else throw new Error('Invalid design calculation event.');
  return state;
}

export function replayDesignCalculationEvents(
  state: DesignCalculationState,
  events: readonly DesignCalculationEvent[],
  policy: DesignCalculationPolicy,
): DesignCalculationState {
  if (!Array.isArray(events) || events.length > 10000)
    throw new Error('Invalid design calculation history.');
  return events.reduce(
    (result, event) => applyDesignCalculationEvent(result, event, policy),
    state,
  );
}

/** MSG_TOT_FILL formats each accumulated addition, including the desktop's 3dp MRP total. */
export function designCalculationTotals(
  rows: readonly DesignCalculationValues[],
): Record<string, number> {
  const dp: Record<string, number> = {
    pcs: 0,
    grossWt: 3,
    otherWt: 3,
    netWt: 3,
    ghatWt: 3,
    fineWt: 3,
    labourAmount: 2,
    otherAmount: 2,
    amount: 2,
    tagCost: 2,
    purchaseCost: 2,
    mrp: 3,
  };
  return Object.fromEntries(
    Object.entries(dp).map(([field, places]) => [
      field,
      rows.reduce((sum, row) => round(new Decimal(sum).plus(d(row[field])), places), 0),
    ]),
  );
}
