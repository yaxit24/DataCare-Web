import { createHash } from 'node:crypto';

/**
 * Voucher version tokens (N51, decision D17, gap G170).
 *
 * Every voucher GET returns `version`: the SHA-256 (64 hex) of the voucher's complete write set, the rows an edit or
 * a delete replaces. PUT and DELETE must send that `expectedVersion`. The writer locks the voucher, recomputes the
 * version in the same transaction and refuses a stale one with `409 voucher-version-conflict` before changing
 * anything, so two operators who loaded the same voucher cannot silently overwrite each other's save.
 * The canonical form follows the sales-order token (`sales/salesOrder.ts`): row keys sorted, dates as ISO strings,
 * big integers as strings; the database row ids are part of it, so even an unchanged save issues a new version.
 */
export interface VersionedVoucherKey {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
  voucherNo: string;
}

/** The key of a voucher whose scope has been completed (company, location, year and book all set). */
export const versionKeyOf = (
  scope: { tenantId: string; coCode: string; lcCode?: string; coYear?: string; coBook?: string },
  voucherNo: string,
): VersionedVoucherKey => ({
  tenantId: scope.tenantId,
  coCode: scope.coCode,
  lcCode: String(scope.lcCode),
  coYear: String(scope.coYear),
  coBook: String(scope.coBook),
  voucherNo,
});

export class VoucherVersionConflictError extends Error {
  readonly code = 'voucher-version-conflict';
  constructor() {
    super(
      'This voucher was changed by someone else after you opened it. Reload it before saving or deleting.',
    );
    this.name = 'VoucherVersionConflictError';
  }
}

export class VoucherVersionValidationError extends Error {
  constructor() {
    super('expectedVersion (the version returned when the voucher was opened) is required');
    this.name = 'VoucherVersionValidationError';
  }
}

const VERSION_PATTERN = /^[0-9a-f]{64}$/;

/** The submitted token, or a refusal when it is missing or not 64 lower-case hex characters. */
export function requiredVersion(raw: unknown): string {
  const value = typeof raw === 'string' ? raw.trim() : '';
  if (!VERSION_PATTERN.test(value)) throw new VoucherVersionValidationError();
  return value;
}

const canonical = (value: any): any => {
  if (value == null || typeof value !== 'object')
    return typeof value === 'bigint' ? String(value) : value;
  if (value instanceof Date) return value.toISOString();
  if (typeof value.toJSON === 'function') return canonical(value.toJSON());
  if (Array.isArray(value)) return value.map(canonical);
  return Object.fromEntries(
    Object.keys(value)
      .sort()
      .map((key) => [key, canonical(value[key])]),
  );
};

/** SHA-256 of the canonical write-set rows. */
export function versionOf(state: Record<string, unknown[]>): string {
  return createHash('sha256')
    .update(JSON.stringify(canonical(state)))
    .digest('hex');
}

const quoted = (table: string): string => '"' + table.replace(/[^A-Za-z0-9_]/g, '') + '"';

/** Every row of the write set, per table, in a stable order. */
export async function writeSetStateTx(
  tx: any,
  tables: readonly string[],
  key: VersionedVoucherKey,
): Promise<Record<string, unknown[]>> {
  const state: Record<string, unknown[]> = {};
  for (const table of tables) {
    state[table] = await tx.$queryRawUnsafe(
      `SELECT r.* FROM ${quoted(table)} r
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        ORDER BY to_jsonb(r)::text`,
      key.tenantId,
      key.coCode,
      key.lcCode,
      key.coYear,
      key.coBook,
      key.voucherNo,
    );
  }
  return state;
}

/** The voucher's current version. */
export async function voucherVersionTx(
  tx: any,
  tables: readonly string[],
  key: VersionedVoucherKey,
): Promise<string> {
  return versionOf(await writeSetStateTx(tx, tables, key));
}

/**
 * Refuse a stale token. Call it after the voucher header is locked (FOR UPDATE) and before any write, so a concurrent
 * writer cannot change the write set between the check and the change.
 */
export async function assertVoucherVersionTx(
  tx: any,
  tables: readonly string[],
  key: VersionedVoucherKey,
  expectedVersion: string,
): Promise<void> {
  if ((await voucherVersionTx(tx, tables, key)) !== expectedVersion)
    throw new VoucherVersionConflictError();
}
