import { AsyncLocalStorage } from 'node:async_hooks';

/**
 * The company a request writes, for the per-company write lock (company reset, masters/companyReset.ts).
 *
 * Every route handler runs inside `runWithCompanyWriteScope` (app.ts, next to the data-type context), and every
 * transaction goes through `withTxBudget`. A write transaction (any budget but `read` and `maintenance`) of a request
 * whose session is in company C takes `pg_try_advisory_xact_lock_shared` on C's key; a company reset takes the same key
 * EXCLUSIVE. So while company 02 is reset, a write to 02 is refused at once with a retryable 503 (`CompanyBusyError`),
 * and writes to 03 or to another tenant never touch the key. The lock is transaction-scoped: nothing outlives a
 * rollback.
 */
export interface CompanyWriteScope {
  tenantId: string;
  coCode: string;
}

const scope = new AsyncLocalStorage<CompanyWriteScope | undefined>();

export function runWithCompanyWriteScope<T>(
  session: { tenantId?: string; coCode?: string } | undefined,
  fn: () => T,
): T {
  return scope.run(
    session?.tenantId && session.coCode
      ? { tenantId: session.tenantId, coCode: session.coCode }
      : undefined,
    fn,
  );
}

export function companyWriteScope(): CompanyWriteScope | undefined {
  return scope.getStore();
}

/** The advisory-lock key text for one company; callers hash it with `hashtextextended($1, 0)`. */
export const companyWriteLockKey = (tenantId: string, coCode: string) =>
  `company-write:${tenantId}:${coCode}`;
