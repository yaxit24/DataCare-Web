import type { VoucherScope } from '../vouchers/numbering.js';
import {
  resolveRoundingPolicy,
  RoundingPolicyValidationError,
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
