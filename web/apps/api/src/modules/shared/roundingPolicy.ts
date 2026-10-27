import {
  resolveRoundingPolicy as resolveRoundingPolicyCore,
  RoundingPolicyValidationError,
  type RoundingFlagValues,
  type RoundingPolicy,
  type StandardRoundingDecimals,
  type TaxRoundingDecimals,
} from '@datacare/core';

export {
  RoundingPolicyValidationError,
  type RoundingFlagValues,
  type RoundingPolicy,
  type StandardRoundingDecimals,
  type TaxRoundingDecimals,
};

/**
 * Resolve the company rounding policy. The rule itself lives in `@datacare/core` so the web previews a
 * document's totals with the identical arithmetic the server posts (G102/G84). This server wrapper adds the
 * PARITY_STRICT gate.
 *
 * PARITY_STRICT turns an ABSENT setting from a silent default into a failure. An absent setting is
 * indistinguishable from a product defect in a comparison: the replay harness seeded CO_SET but not
 * CO_SET_NEW, so TOT_AMT_ROF was missing and the rule kept its documented 2dp default; the web produced
 * 1515.21 against the desktop's 1515.00, which was written up as a MISSING whole-rupee rounding mode — across
 * two commits — before the cause was found. Off by default (production wants a sane default when a customer
 * has not set a flag); on under PARITY_STRICT=1, where nothing may be assumed.
 */
export function resolveRoundingPolicy(flags: RoundingFlagValues = {}): RoundingPolicy {
  const policy = resolveRoundingPolicyCore(flags);
  if (process.env.PARITY_STRICT === '1') {
    const unset = (
      [
        ['TAX_ROF', policy.configured.tax],
        ['LBR_ROF', policy.configured.labour],
        ['ITM_RATE_ROF', policy.configured.itemRate],
        ['TOT_AMT_ROF', policy.configured.billTotal],
        ['PR_RATE_ROF', policy.configured.purchaseRate],
      ] as const
    )
      .filter(([, configured]) => !configured)
      .map(([name]) => name);
    if (unset.length) {
      throw new RoundingPolicyValidationError(
        `PARITY_STRICT: ${unset.length} rounding setting(s) are not configured and would silently take a ` +
          `default, which is indistinguishable from a defect in a comparison: ${unset.join(', ')}`,
      );
    }
  }
  return policy;
}
