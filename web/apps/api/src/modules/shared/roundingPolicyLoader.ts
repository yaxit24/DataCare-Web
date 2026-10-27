import type { VoucherScope } from '../vouchers/numbering.js';
import {
  resolveRoundingPolicy,
  RoundingPolicyValidationError,
  type RoundingFlagValues,
  type RoundingPolicy,
} from './roundingPolicy.js';

interface RoundingSettingsRow {
  co_set_count: unknown;
  co_set_new_count: unknown;
  tax_rof: unknown;
  lbr_rof: unknown;
  itm_rate_rof: unknown;
  tot_amt_rof: unknown;
  pr_rate_rof: unknown;
  all_rof_remove: unknown;
}

/** Load the active company's policy once inside a voucher transaction. */
export async function resolveRoundingPolicyTx(
  tx: any,
  scope: VoucherScope,
): Promise<RoundingPolicy> {
  const rows: RoundingSettingsRow[] = await tx.$queryRawUnsafe(
    `SELECT
       (SELECT count(*)::int FROM "CO_SET"
         WHERE tenant_id=$1 AND "CO_CODE"=$2) AS co_set_count,
       (SELECT count(*)::int FROM "CO_SET_NEW"
         WHERE tenant_id=$1 AND "CO_CODE"=$2) AS co_set_new_count,
       (SELECT "TAX_ROF" FROM "CO_SET"
         WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id LIMIT 1) AS tax_rof,
       (SELECT "LBR_ROF" FROM "CO_SET"
         WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id LIMIT 1) AS lbr_rof,
       (SELECT "ITM_RATE_ROF" FROM "CO_SET"
         WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id LIMIT 1) AS itm_rate_rof,
       (SELECT "TOT_AMT_ROF" FROM "CO_SET_NEW"
         WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1) AS tot_amt_rof,
       (SELECT "PR_RATE_ROF" FROM "CO_SET_NEW"
         WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1) AS pr_rate_rof,
       (SELECT "ALL_ROF_REMOVE" FROM "CO_SET"
         WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id LIMIT 1) AS all_rof_remove`,
    scope.tenantId,
    scope.coCode,
  );
  if (rows.length !== 1) {
    throw new RoundingPolicyValidationError('rounding settings query returned an ambiguous result');
  }
  const row = rows[0] as RoundingSettingsRow;
  if (Number(row.co_set_count) > 1) {
    throw new RoundingPolicyValidationError(
      `company ${scope.coCode} has ambiguous CO_SET rounding settings`,
    );
  }
  if (Number(row.co_set_new_count) > 1) {
    throw new RoundingPolicyValidationError(
      `company ${scope.coCode} has ambiguous CO_SET_NEW rounding settings`,
    );
  }
  return resolveRoundingPolicy({
    TAX_ROF: row.tax_rof,
    LBR_ROF: row.lbr_rof,
    ITM_RATE_ROF: row.itm_rate_rof,
    TOT_AMT_ROF: row.tot_amt_rof,
    PR_RATE_ROF: row.pr_rate_rof,
    ALL_ROF_REMOVE: row.all_rof_remove,
  });
}

/**
 * The raw rounding flags, normalised to JSON-safe strings, so the web can rebuild the identical
 * `resolveRoundingPolicy` client-side and preview a document's totals exactly as the server posts them
 * (G102/G84). Returns `null` when the company has no (or an ambiguous) settings row — the web then keeps its
 * 2dp default, as the rule does for absent flags.
 */
export async function loadRoundingFlags(
  prisma: any,
  tenantId: string,
  coCode: string,
): Promise<RoundingFlagValues | null> {
  try {
    const policy = await resolveRoundingPolicyTx(prisma, {
      tenantId,
      coCode,
    } as VoucherScope);
    // Return the resolved decimals as flags: the web passes them back through resolveRoundingPolicy and gets
    // the same policy. A configured flag keeps its decimal count; an unconfigured one is omitted so the web's
    // rule applies its own 2dp default (and banker's-vs-half-up matches, since `configured` is re-derived).
    const flags: RoundingFlagValues = {};
    if (policy.configured.tax) flags.TAX_ROF = String(policy.taxDecimals);
    if (policy.configured.labour) flags.LBR_ROF = String(policy.labourDecimals);
    if (policy.configured.itemRate) flags.ITM_RATE_ROF = String(policy.itemRateDecimals);
    if (policy.configured.billTotal) flags.TOT_AMT_ROF = String(policy.billTotalDecimals);
    if (policy.configured.purchaseRate) flags.PR_RATE_ROF = String(policy.purchaseRateDecimals);
    return flags;
  } catch (err) {
    if (err instanceof RoundingPolicyValidationError) return null;
    throw err;
  }
}
