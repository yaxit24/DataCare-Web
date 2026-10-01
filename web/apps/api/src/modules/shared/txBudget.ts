import { withTenant, type Tx } from '@datacare/db';

/**
 * Explicit interactive-transaction budgets (N53 / G30).
 *
 * About 525 `withTenant` calls ran under Prisma's implicit default: 5 s to finish, 2 s to start. A voucher
 * save does real work inside that window (numbering lock, ledger, stock, day book, audit). Under load it ran
 * past 5 s, and the caller received an opaque 500 after Prisma had already rolled back.
 *
 * Each command now declares its class:
 *   read     5 s, 2 s to start   documents, lookups, previews
 *   voucher 20 s, 5 s to start   one voucher's create / edit / delete
 *   heavy   30 s, 10 s to start  multi-voucher and bulk commands
 *
 * A timeout still rolls back the whole transaction. `app.ts` maps it to `503 {error:'transaction-timeout',
 * retryable:true}` with `Retry-After: 1`. Nothing retries automatically; a manual retry becomes safe once
 * N52 adds idempotency keys.
 *
 * Operators can tune a class with DATACARE_TX_BUDGET_<CLASS>_MS (100 ms to 10 min). Its start wait stays the
 * class default, capped at the new timeout.
 */
export type TxBudgetClass = 'read' | 'voucher' | 'heavy';

export interface TxBudget {
  readonly timeout: number;
  readonly maxWait: number;
}

export const COMMAND_TX_BUDGETS: Readonly<Record<TxBudgetClass, TxBudget>> = Object.freeze({
  read: Object.freeze({ timeout: 5_000, maxWait: 2_000 }),
  voucher: Object.freeze({ timeout: 20_000, maxWait: 5_000 }),
  heavy: Object.freeze({ timeout: 30_000, maxWait: 10_000 }),
});

export const TX_BUDGET_CLASSES = Object.keys(COMMAND_TX_BUDGETS) as TxBudgetClass[];

export class TxBudgetConfigurationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'TxBudgetConfigurationError';
  }
}

/** The effective budget for a class: the declared default, or a validated operator override. */
export function txBudget(budgetClass: TxBudgetClass): TxBudget {
  const base = COMMAND_TX_BUDGETS[budgetClass];
  const variable = `DATACARE_TX_BUDGET_${budgetClass.toUpperCase()}_MS`;
  const raw = process.env[variable]?.trim();
  if (!raw) return base;
  const timeout = Number(raw);
  if (!/^\d+$/.test(raw) || timeout < 100 || timeout > 600_000) {
    throw new TxBudgetConfigurationError(
      `${variable} must be a whole number of milliseconds from 100 to 600000`,
    );
  }
  return { timeout, maxWait: Math.min(base.maxWait, timeout) };
}

const TIMEOUT_MESSAGES = [
  /Transaction already closed/i,
  /expired transaction/i,
  /Unable to start a transaction in the given time/i,
  /Transaction API error/i,
  // PostgreSQL cancelling a statement at the budget's statement_timeout (57014) or a lock_timeout (55P03).
  /canceling statement due to (statement|lock) timeout/i,
];

/**
 * True for a transaction-budget failure:
 *  - Prisma P2028 ("Transaction API error"): the transaction expired, or could not start within `maxWait`;
 *  - PostgreSQL cancelling a statement at the budget's `statement_timeout` (57014) or at a lock timeout
 *    (55P03). Prisma reports these as P2010 "Raw query failed".
 * Also matches a wrapped cause.
 */
export function isTransactionTimeout(error: unknown): boolean {
  for (let e: unknown = error, depth = 0; e && depth < 4; depth++) {
    const candidate = e as { code?: unknown; message?: unknown; cause?: unknown; meta?: unknown };
    if (candidate.code === 'P2028') return true;
    const meta = candidate.meta as { code?: unknown } | undefined;
    if (meta?.code === '57014' || meta?.code === '55P03') return true;
    const message = typeof candidate.message === 'string' ? candidate.message : '';
    if (TIMEOUT_MESSAGES.some((pattern) => pattern.test(message))) return true;
    e = candidate.cause;
  }
  return false;
}

export type TxOutcome = 'committed' | 'rolled_back' | 'timeout';

/** Upper bounds, in milliseconds, of the transaction-duration histogram. */
export const TX_DURATION_BUCKETS_MS = [
  50, 100, 250, 500, 1_000, 2_500, 5_000, 10_000, 20_000, 30_000,
];

interface ClassDurations {
  buckets: number[];
  sum: number;
  count: number;
  outcomes: Record<TxOutcome, number>;
}

/** Process-wide histogram of budgeted transaction durations, per budget class. */
export class TransactionDurations {
  private readonly classes = new Map<TxBudgetClass, ClassDurations>();

  observe(budgetClass: TxBudgetClass, durationMs: number, outcome: TxOutcome): void {
    let entry = this.classes.get(budgetClass);
    if (!entry) {
      entry = {
        buckets: TX_DURATION_BUCKETS_MS.map(() => 0),
        sum: 0,
        count: 0,
        outcomes: { committed: 0, rolled_back: 0, timeout: 0 },
      };
      this.classes.set(budgetClass, entry);
    }
    const ms = Math.max(0, durationMs);
    TX_DURATION_BUCKETS_MS.forEach((bound, i) => {
      if (ms <= bound) entry.buckets[i] = (entry.buckets[i] ?? 0) + 1;
    });
    entry.sum += ms;
    entry.count += 1;
    entry.outcomes[outcome] += 1;
  }

  /** Prometheus exposition lines: a cumulative histogram and an outcome counter per class. */
  prometheus(): string[] {
    const lines = [
      '# HELP datacare_transaction_duration_ms Budgeted interactive transaction duration by budget class.',
      '# TYPE datacare_transaction_duration_ms histogram',
    ];
    for (const budgetClass of TX_BUDGET_CLASSES) {
      const entry = this.classes.get(budgetClass);
      TX_DURATION_BUCKETS_MS.forEach((bound, i) => {
        lines.push(
          `datacare_transaction_duration_ms_bucket{budget="${budgetClass}",le="${bound}"} ${entry?.buckets[i] ?? 0}`,
        );
      });
      lines.push(
        `datacare_transaction_duration_ms_bucket{budget="${budgetClass}",le="+Inf"} ${entry?.count ?? 0}`,
        `datacare_transaction_duration_ms_sum{budget="${budgetClass}"} ${(entry?.sum ?? 0).toFixed(3)}`,
        `datacare_transaction_duration_ms_count{budget="${budgetClass}"} ${entry?.count ?? 0}`,
      );
    }
    lines.push(
      '# HELP datacare_transactions_total Budgeted interactive transactions by budget class and outcome.',
      '# TYPE datacare_transactions_total counter',
    );
    for (const budgetClass of TX_BUDGET_CLASSES) {
      for (const outcome of ['committed', 'rolled_back', 'timeout'] as const) {
        lines.push(
          `datacare_transactions_total{budget="${budgetClass}",outcome="${outcome}"} ${this.classes.get(budgetClass)?.outcomes[outcome] ?? 0}`,
        );
      }
    }
    return lines;
  }
}

export const transactionDurations = new TransactionDurations();

/**
 * Run `fn` in a tenant-scoped transaction under the declared budget, and record its duration and outcome.
 * A drop-in replacement for `withTenant(prisma, tenantId, fn)` in command coordinators.
 */
export async function withTxBudget<T>(
  prisma: any,
  tenantId: string,
  budgetClass: TxBudgetClass,
  fn: (tx: Tx) => Promise<T>,
): Promise<T> {
  const budget = txBudget(budgetClass);
  const started = performance.now();
  let outcome: TxOutcome = 'committed';
  try {
    return await withTenant(
      prisma,
      tenantId,
      async (tx) => {
        // Prisma's timeout is only checked between statements. It cannot interrupt a statement already
        // waiting on a lock: measured, a save queued behind another session's numbering lock waited for
        // as long as that lock was held. statement_timeout makes PostgreSQL cancel such a statement
        // within the budget. Transaction-local, so the pooled connection is unaffected afterwards.
        await tx.$executeRawUnsafe(
          "SELECT set_config('statement_timeout', $1, true)",
          String(budget.timeout),
        );
        return fn(tx);
      },
      budget,
    );
  } catch (error) {
    outcome = isTransactionTimeout(error) ? 'timeout' : 'rolled_back';
    throw error;
  } finally {
    transactionDurations.observe(budgetClass, performance.now() - started, outcome);
  }
}
