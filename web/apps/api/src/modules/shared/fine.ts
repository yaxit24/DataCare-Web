import { DEFAULT_FINE_WORKFLOW, fineFor } from './finePolicy.js';

export { round3 } from './finePolicy.js';

/**
 * Backward-compatible default jewellery fine-weight helper. Named workflow call sites should use
 * fineFor(); this remains the historical (NetWt + GhtWt) × (Touch + West%) / 100 policy.
 */
export function fineWt(netWt?: number, ghtWt?: number, touch?: number, westPct?: number): number {
  return fineFor(DEFAULT_FINE_WORKFLOW, { netWt, ghtWt, touch, westPct });
}
