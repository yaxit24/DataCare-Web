import { Decimal } from 'decimal.js';
import { round, roundHalfEven } from './money.js';

export interface OrderLabourPolicy {
  includesGhat: boolean;
  rateDecimals: number;
}

export type OrderLabourAction = 'rate' | 'percentage' | 'amount';

export interface OrderLabourEdit {
  action: OrderLabourAction;
  value: number;
  basis: Pick<OrderLabourState, 'labourType' | 'pcs' | 'grossWt' | 'netWt' | 'ghatWt' | 'itemRate'>;
}

export interface OrderLabourState {
  labourType: string;
  pcs: number;
  grossWt: number;
  netWt: number;
  ghatWt: number;
  itemRate: number;
  labourPct: number;
  labourRate: number;
  labourAmount: number;
}

function base(state: OrderLabourState, policy: OrderLabourPolicy): Decimal {
  switch (state.labourType) {
    case 'P':
      return new Decimal(state.pcs);
    case 'G':
      // Order gross labour does not include ghat (TR_SALE_ORD:6870).
      return new Decimal(state.grossWt);
    case 'K':
      // The kilogram branch includes ghat even with LBR_WITH_GHT=N (:6866).
      return new Decimal(state.netWt).plus(state.ghatWt);
    default:
      return new Decimal(state.netWt).plus(policy.includesGhat ? state.ghatWt : 0);
  }
}

/** TR_SALE_ORD:6835–6874: labour amount has hardcoded whole-rupee half-even rounding. */
export function orderLabourAmount(state: OrderLabourState, policy: OrderLabourPolicy): number {
  const value = base(state, policy).times(state.labourRate);
  return roundHalfEven(state.labourType === 'K' ? value.div(1000) : value, 0);
}

function rateCell(value: Decimal, policy: OrderLabourPolicy): number {
  if (!Number.isInteger(policy.rateDecimals) || policy.rateDecimals < 0 || policy.rateDecimals > 3)
    throw new Error('Order labour rate precision must be between 0 and 3');
  // The desktop formats the Math.Round result into a two-decimal editable cell.
  return round(roundHalfEven(value, policy.rateDecimals), 2);
}

/**
 * One committed order-grid labour edit (TR_SALE_ORD:6743–6874).
 * The previous rate/amount are the desktop's cached columns84/85. An unchanged cell does not
 * recalculate imported/manual values. Type, pieces and weight changes alone do not reset cache84.
 * Callers supply a prior server snapshot or their previous committed editor state, never a flag
 * which asks the server to trust a client-supplied prior amount.
 */
export function orderLabourTransition(
  previous: OrderLabourState,
  next: OrderLabourState,
  policy: OrderLabourPolicy,
  action: OrderLabourAction,
): OrderLabourState {
  const out = { ...next };
  if (action === 'amount') {
    if (next.labourAmount === previous.labourAmount) return out;
    if (next.labourAmount !== 0 && next.labourRate !== 0) {
      const divisor = base(next, policy);
      if (divisor.isZero()) throw new Error('Cannot derive order labour rate from a zero basis');
      let value = new Decimal(next.labourAmount).div(divisor);
      // Literal source :6784 and :6955. This is deliberately NOT the algebraic inverse of the
      // K rate-to-amount branch. Independent executable desktop confirmation remains required.
      if (next.labourType === 'K') value = value.div(1000);
      out.labourRate = rateCell(value, policy);
    }
    return out;
  }
  if (action === 'percentage') {
    if (next.labourPct === previous.labourPct || next.itemRate === 0) return out;
    out.labourRate = rateCell(new Decimal(next.itemRate).times(next.labourPct).div(100), policy);
  }
  if (out.labourRate !== previous.labourRate) out.labourAmount = orderLabourAmount(out, policy);
  return out;
}

/** Replay committed edits from the server-owned prior rate/amount, not a client baseline. */
export function orderLabourReplay(
  previous: OrderLabourState,
  edits: readonly OrderLabourEdit[],
  policy: OrderLabourPolicy,
): OrderLabourState {
  if (!Array.isArray(edits) || edits.length > 256)
    throw new Error('Order labour edits must contain at most 256 committed cells');
  let current = previous;
  for (const edit of edits) {
    if (
      !edit ||
      !['rate', 'percentage', 'amount'].includes(edit.action) ||
      !Number.isFinite(edit.value) ||
      !edit.basis ||
      typeof edit.basis.labourType !== 'string' ||
      edit.basis.labourType.length > 1 ||
      !['pcs', 'grossWt', 'netWt', 'ghatWt', 'itemRate'].every((key) =>
        Number.isFinite((edit.basis as any)[key]),
      )
    )
      throw new Error('Invalid committed order labour edit');
    const action = edit.action as OrderLabourAction;
    const field = { rate: 'labourRate', percentage: 'labourPct', amount: 'labourAmount' }[action];
    const next = {
      ...current,
      labourType: edit.basis.labourType,
      pcs: edit.basis.pcs,
      grossWt: edit.basis.grossWt,
      netWt: edit.basis.netWt,
      ghatWt: edit.basis.ghatWt,
      itemRate: edit.basis.itemRate,
      [field]: round(edit.value, 2),
    };
    current = orderLabourTransition(current, next, policy, edit.action);
  }
  return current;
}
