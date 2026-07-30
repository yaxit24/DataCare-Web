import type { PrismaClient, Prisma } from '@prisma/client';

export type Tx = Prisma.TransactionClient;

/**
 * Run `fn` inside an interactive transaction that first binds the RLS tenant via
 * `set_config('app.tenant_id', tenantId, true)` (transaction-local), so Row-Level Security
 * scopes every statement to the tenant (Req 5.x). The app MUST connect as a non-superuser role
 * (e.g. app_user) for RLS to apply. Throws → the whole transaction rolls back (Req 5.5).
 */
export async function withTenant<T>(
  prisma: PrismaClient,
  tenantId: string,
  fn: (tx: Tx) => Promise<T>,
): Promise<T> {
  return prisma.$transaction(async (tx) => {
    await tx.$executeRawUnsafe("SELECT set_config('app.tenant_id', $1, true)", tenantId);
    return fn(tx);
  });
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
