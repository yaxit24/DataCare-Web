import type { PrismaClient, Prisma } from './generated/prisma/client.js';

export type Tx = Prisma.TransactionClient;

/**
 * Run `fn` inside an interactive transaction that first binds the RLS tenant via
 * `set_config('app.tenant_id', tenantId, true)` (transaction-local), so Row-Level Security
 * scopes every statement to the tenant (Req 5.x). The app MUST connect as a non-superuser role
 * (e.g. app_user) for RLS to apply. Throws → the whole transaction rolls back (Req 5.5).
 */
export interface TenantTransactionOptions {
  maxWait?: number;
  timeout?: number;
  isolationLevel?: Prisma.TransactionIsolationLevel;
  /**
   * Transaction-local `statement_timeout` in milliseconds. Prisma checks `timeout` only between
   * statements, so a statement waiting on a lock is not interrupted by it; PostgreSQL cancels such a
   * statement at this limit. Bound in the same statement as the tenant, so it costs no extra round trip.
   */
  statementTimeoutMs?: number;
}

export async function withTenant<T>(
  prisma: PrismaClient,
  tenantId: string,
  fn: (tx: Tx) => Promise<T>,
  options?: TenantTransactionOptions,
): Promise<T> {
  const { statementTimeoutMs, ...transactionOptions } = options ?? {};
  if (
    statementTimeoutMs !== undefined &&
    (!Number.isInteger(statementTimeoutMs) || statementTimeoutMs <= 0)
  )
    throw new RangeError('statementTimeoutMs must be a positive whole number of milliseconds');
  return prisma.$transaction(
    async (tx) => {
      if (statementTimeoutMs === undefined)
        await tx.$executeRawUnsafe("SELECT set_config('app.tenant_id', $1, true)", tenantId);
      else
        await tx.$executeRawUnsafe(
          "SELECT set_config('app.tenant_id', $1, true), set_config('statement_timeout', $2, true)",
          tenantId,
          String(statementTimeoutMs),
        );
      return fn(tx);
    },
    options === undefined ? undefined : transactionOptions,
  );
}

/**
 * Atomic multi-write: all operations run in one tenant-scoped transaction; if any throws,
 * the entire unit of work is rolled back and the database is left unchanged (Req 5.4/5.5).
 */
export async function atomic(
  prisma: PrismaClient,
  tenantId: string,
  ops: Array<(tx: Tx) => Promise<unknown>>,
): Promise<void> {
  await withTenant(prisma, tenantId, async (tx) => {
    for (const op of ops) await op(tx);
  });
}
