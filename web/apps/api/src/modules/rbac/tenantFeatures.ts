/**
 * Per-tenant plan feature flags (`tenant_feature`, operator-provisioned; a missing row means ON).
 *
 * Owner rule (2026-11-27): a web extension the desktop does not have may stay when it is useful to real shops, behind a
 * per-tenant flag that defaults on. With the flag off the screen behaves exactly as the desktop form.
 */

/**
 * CARD and UPI modes on the four Cash/Bank menus (Cash Received, Bank Received, Cash Payment, Bank Payment).
 * Desktop TR_CASH has no such mode: the book alone decides cash or bank (TR_CASH.cs:1743-1797) and Save writes CASH_DATA
 * only (TR_CASH.cs:2995-3060). The web CARD/UPI modes additionally write CARD_DATA / UPI_DATA for a receipt.
 */
export const CASH_BANK_CARD_UPI = 'cashBankCardUpi';

export const TENANT_FEATURES = [CASH_BANK_CARD_UPI] as const;
export type TenantFeatureName = (typeof TENANT_FEATURES)[number];

export async function tenantFeatureEnabledTx(
  tx: { $queryRawUnsafe: <T>(sql: string, ...values: unknown[]) => Promise<T> },
  tenantId: string,
  feature: TenantFeatureName,
): Promise<boolean> {
  const rows = await tx.$queryRawUnsafe<Array<{ enabled: boolean }>>(
    `SELECT enabled FROM "tenant_feature" WHERE tenant_id=$1 AND feature=$2`,
    tenantId,
    feature,
  );
  return rows[0]?.enabled !== false;
}
