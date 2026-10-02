/**
 * What a budgeted transaction asks of the database (N53): the tenant and a transaction-local
 * statement_timeout bound in one statement, and Prisma's timeout / maxWait set to the class budget.
 *
 * The budgets are the plan's table (document 11, N53 step 2: reads 5 s with 2 s to start, vouchers 20 s
 * with 5 s, heavy commands 30 s with 10 s), written out here rather than read from the implementation.
 */
export const BUDGETED_BIND_SQL =
  "SELECT set_config('app.tenant_id', $1, true), set_config('statement_timeout', $2, true)";

export const READ_BUDGET = { timeout: 5_000, maxWait: 2_000 } as const;
export const VOUCHER_BUDGET = { timeout: 20_000, maxWait: 5_000 } as const;
export const HEAVY_BUDGET = { timeout: 30_000, maxWait: 10_000 } as const;

/** The bind parameters a budgeted transaction sends for a tenant under a budget. */
export function budgetedBindParams(tenantId: string, budget: { timeout: number }): unknown[] {
  return [tenantId, String(budget.timeout)];
}
