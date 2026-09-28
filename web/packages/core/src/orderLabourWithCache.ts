import { round } from './money.js';
import {
  orderLabourAmount,
  orderLabourTransition,
  type OrderLabourPolicy,
  type OrderLabourState,
} from './orderLabour.js';

/** TR_SALE_ORD hidden cells 84/85/86. F1 changes visible cells without changing these. */
export type OrderLabourCache = Pick<OrderLabourState, 'labourRate' | 'labourAmount' | 'labourPct'>;

/** Execute the amount→percentage→rate comparison block TR_SALE_ORD:6732–6874
 * on an ACTUAL grid calculation trigger. Do not call when selecting/clearing a design.
 * These are the block's cache writes, not a synthetic cache=visible snapshot. In particular,
 * the rate branch changes amount23 but leaves cache85 until a subsequent amount comparison.
 * Later total/MRP/tax branches (6893 onward) are outside this bounded helper. */
export function orderLabourWithCache(
  visible: OrderLabourState,
  previousCache: OrderLabourCache,
  policy: OrderLabourPolicy,
): { state: OrderLabourState; cache: OrderLabourCache } {
  for (const [key, value] of [...Object.entries(visible), ...Object.entries(previousCache)])
    if (key !== 'labourType' && !Number.isFinite(value))
      throw new Error('Order labour values and cached cells must be finite.');
  let state = { ...visible };
  const cache = { ...previousCache };
  if (state.labourAmount !== cache.labourAmount) {
    const previousAmount = cache.labourAmount;
    cache.labourAmount = round(state.labourAmount, 2);
    const derivesRate = state.labourAmount !== 0 && state.labourRate !== 0;
    state = orderLabourTransition(
      { ...state, labourAmount: previousAmount },
      state,
      policy,
      'amount',
    );
    if (derivesRate) cache.labourRate = round(state.labourRate, 2);
  }
  if (state.labourPct !== cache.labourPct && state.itemRate !== 0) {
    const previousPct = cache.labourPct;
    cache.labourPct = round(state.labourPct, 2);
    const derived = orderLabourTransition(
      { ...state, labourPct: previousPct },
      state,
      policy,
      'percentage',
    );
    // The percentage block writes only22. The following rate block decides whether23 changes.
    state.labourRate = derived.labourRate;
  }
  if (state.labourRate !== cache.labourRate) {
    cache.labourRate = round(state.labourRate, 2);
    state.labourAmount = orderLabourAmount(state, policy);
  }
  return { state, cache };
}
