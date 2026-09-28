import { withTenant } from '@datacare/db';

/**
 * Desktop previous-day auto lock (CO_SET.LAST_DAY_LOCK).
 *
 * The desktop does NOT evaluate this flag when saving a voucher. It *writes* the lock date once,
 * at the moment the company is opened:
 *
 *   MS_OPNCOMP.cs:1503-1507   on company open, LAST_DAY_LOCK='Y' ⇒
 *                             UPDATE CO_SET SET LOCK_DATE = <system date - 1 day>
 *   UT_SETTING_MAIN.cs:9159-9165  the same write happens when the setting itself is saved.
 *
 * From then on the ordinary persisted-LOCK_DATE gate (posting.assertPeriodOpen) does the blocking,
 * exactly as it does for a manually chosen lock date. Reproducing the flag inside the save gate
 * would diverge from the desktop (it would also silently re-lock historical data on every write),
 * so the web mirrors the desktop placement: apply on company open, then read LOCK_DATE only.
 *
 * Existing web preservation rule: the lock only moves forward. The primary desktop assignment is
 * unconditional; this monotonic protection is an explicit web difference, not claimed source equality.
 */
export class LastDayLockConfigurationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'LastDayLockConfigurationError';
  }
}

export interface LastDayLockResult {
  applied: boolean;
  lockDate: string | null;
}

/** Apply the desktop previous-day auto lock for one company. Safe to call on every company open. */
export async function applyLastDayLockTx(
  tx: any,
  tenantId: string,
  coCode: string,
): Promise<LastDayLockResult> {
  // LOCK_DATE is stored as text in this schema, so the comparison happens here rather than in SQL.
  const rows: Array<{ flag: unknown; lock_date: unknown; yesterday: unknown }> =
    await tx.$queryRawUnsafe(
      `SELECT upper(btrim(coalesce("LAST_DAY_LOCK"::text,''))) AS flag,
              btrim(coalesce("LOCK_DATE"::text,'')) AS lock_date,
              (current_date - INTERVAL '1 day')::date::text AS yesterday
         FROM "CO_SET"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text
        ORDER BY row_id FOR UPDATE`,
      tenantId,
      coCode,
    );
  // Opening a company must not fail because settings are absent or ambiguous - the desktop simply
  // reads whatever CO_SET holds. The authoritative save-time gate (posting.assertPeriodOpen) still
  // fails closed on a missing or ambiguous row, so no voucher can slip through unlocked.
  if (rows.length !== 1) return { applied: false, lockDate: null };

  const flag = String(rows[0]?.flag ?? '').trim();
  if (flag && flag !== 'Y' && flag !== 'N') {
    throw new LastDayLockConfigurationError(`CO_SET.LAST_DAY_LOCK is invalid: ${flag}`);
  }
  const current = String(rows[0]?.lock_date ?? '')
    .trim()
    .slice(0, 10);
  const yesterday = String(rows[0]?.yesterday ?? '').slice(0, 10);
  if (flag !== 'Y') return { applied: false, lockDate: current || null };
  // The lock only moves forward; an existing later lock date is left untouched.
  if (current && current >= yesterday) return { applied: false, lockDate: current };

  // MS_OPNCOMP.cs:1505 writes the system date minus one day; the database clock is authoritative.
  await tx.$executeRawUnsafe(
    `UPDATE "CO_SET" SET "LOCK_DATE" = $3 WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text`,
    tenantId,
    coCode,
    yesterday,
  );
  return { applied: true, lockDate: yesterday };
}

/** Convenience wrapper for callers outside an open transaction (e.g. company selection). */
export async function applyLastDayLock(
  prisma: any,
  tenantId: string,
  coCode: string,
): Promise<LastDayLockResult> {
  return withTenant(prisma, tenantId, async (tx: any) => applyLastDayLockTx(tx, tenantId, coCode));
}
