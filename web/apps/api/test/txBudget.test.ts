import { afterEach, describe, expect, it, vi } from 'vitest';
import { MetricsRegistry } from '../src/modules/ops/metrics.js';
import {
  COMMAND_TX_BUDGETS,
  isTransactionTimeout,
  READ_COMMITTED_VOUCHER,
  SERIALIZABLE_VOUCHER,
  SNAPSHOT_READ,
  TransactionDurations,
  transactionDurations,
  TxBudgetConfigurationError,
  txBudget,
  withTxBudget,
  type TxBudgetPrisma,
} from '../src/modules/shared/txBudget.js';

/** N53 / G30: explicit transaction budgets instead of Prisma's implicit 5-second default. */
describe('command transaction budgets', () => {
  afterEach(() => {
    vi.unstubAllEnvs();
  });

  it('declares the three budget classes from the plan', () => {
    expect(COMMAND_TX_BUDGETS).toEqual({
      read: { timeout: 5_000, maxWait: 2_000 },
      voucher: { timeout: 20_000, maxWait: 5_000 },
      heavy: { timeout: 30_000, maxWait: 10_000 },
    });
    expect(Object.isFrozen(COMMAND_TX_BUDGETS)).toBe(true);
    expect(Object.isFrozen(COMMAND_TX_BUDGETS.voucher)).toBe(true);
  });

  it('applies a validated operator override, capping the start wait at the new timeout', () => {
    vi.stubEnv('DATACARE_TX_BUDGET_VOUCHER_MS', '45000');
    expect(txBudget('voucher')).toEqual({ timeout: 45_000, maxWait: 5_000 });
    vi.stubEnv('DATACARE_TX_BUDGET_VOUCHER_MS', '1500');
    expect(txBudget('voucher')).toEqual({ timeout: 1_500, maxWait: 1_500 });
    expect(txBudget('read')).toEqual({ timeout: 5_000, maxWait: 2_000 });
  });

  it('refuses a malformed or out-of-range override instead of silently using it', () => {
    for (const bad of ['abc', '-5', '99', '600001', '1.5', '20s']) {
      vi.stubEnv('DATACARE_TX_BUDGET_HEAVY_MS', bad);
      expect(() => txBudget('heavy'), bad).toThrow(TxBudgetConfigurationError);
    }
  });

  it('recognises Prisma transaction-budget failures, including a wrapped cause', () => {
    expect(isTransactionTimeout({ code: 'P2028', message: 'Transaction API error: x' })).toBe(true);
    expect(
      isTransactionTimeout(
        new Error(
          'Transaction already closed: A query cannot be executed on an expired transaction. The timeout for this transaction was 5000 ms',
        ),
      ),
    ).toBe(true);
    expect(
      isTransactionTimeout(new Error('Unable to start a transaction in the given time.')),
    ).toBe(true);
    expect(
      isTransactionTimeout(new Error('save failed', { cause: { code: 'P2028', message: '' } })),
    ).toBe(true);
    // PostgreSQL cancelling a statement at the budget's statement_timeout, as Prisma reports it.
    expect(
      isTransactionTimeout({
        code: 'P2010',
        meta: { code: '57014', message: 'canceling statement due to statement timeout' },
        message:
          'Raw query failed. Code: `57014`. Message: `canceling statement due to statement timeout`',
      }),
    ).toBe(true);
    expect(isTransactionTimeout({ code: 'P2010', meta: { code: '55P03' }, message: '' })).toBe(
      true,
    );
    expect(
      isTransactionTimeout({ code: 'P2010', meta: { code: '23505' }, message: 'Raw query failed' }),
    ).toBe(false);
    expect(isTransactionTimeout({ code: 'P2010', message: 'Raw query failed' })).toBe(false);
    expect(isTransactionTimeout(new Error('redeem 80 exceeds balance 20'))).toBe(false);
    expect(isTransactionTimeout(undefined)).toBe(false);
  });
});

describe('transaction duration histogram', () => {
  it('renders cumulative buckets, sum, count and outcomes per budget class', () => {
    const durations = new TransactionDurations();
    durations.observe('voucher', 40, 'committed');
    durations.observe('voucher', 300, 'committed');
    durations.observe('voucher', 25_000, 'timeout');
    durations.observe('read', 10, 'rolled_back');
    const text = new MetricsRegistry(durations).prometheus();

    expect(text).toContain('# TYPE datacare_transaction_duration_ms histogram');
    expect(text).toContain('datacare_transaction_duration_ms_bucket{budget="voucher",le="50"} 1');
    expect(text).toContain('datacare_transaction_duration_ms_bucket{budget="voucher",le="500"} 2');
    expect(text).toContain(
      'datacare_transaction_duration_ms_bucket{budget="voucher",le="20000"} 2',
    );
    expect(text).toContain(
      'datacare_transaction_duration_ms_bucket{budget="voucher",le="30000"} 3',
    );
    expect(text).toContain('datacare_transaction_duration_ms_bucket{budget="voucher",le="+Inf"} 3');
    expect(text).toContain('datacare_transaction_duration_ms_sum{budget="voucher"} 25340.000');
    expect(text).toContain('datacare_transaction_duration_ms_count{budget="voucher"} 3');
    expect(text).toContain('datacare_transaction_duration_ms_count{budget="heavy"} 0');
    expect(text).toContain('datacare_transactions_total{budget="voucher",outcome="timeout"} 1');
    expect(text).toContain('datacare_transactions_total{budget="read",outcome="rolled_back"} 1');
    expect(text).toContain('datacare_transactions_total{budget="heavy",outcome="committed"} 0');
    expect(text.endsWith('\n')).toBe(true);
  });
});

describe('withTxBudget', () => {
  afterEach(() => {
    vi.unstubAllEnvs();
  });

  function fakePrisma(fail?: unknown) {
    const statements: Array<{ sql: string; params: unknown[] }> = [];
    const tx = {
      $executeRawUnsafe: vi.fn(async (sql: string, ...params: unknown[]) => {
        statements.push({ sql, params });
        return 1;
      }),
    };
    const $transaction = vi.fn(async (fn: (value: unknown) => Promise<unknown>, _o?: unknown) => {
      const result = await fn(tx);
      if (fail) throw fail;
      return result;
    });
    return { prisma: { $transaction } as unknown as TxBudgetPrisma, $transaction, statements };
  }
  const BIND =
    "SELECT set_config('app.tenant_id', $1, true), set_config('statement_timeout', $2, true)";

  it('runs a class with its time limits and binds tenant and statement_timeout in one statement', async () => {
    const { prisma, $transaction, statements } = fakePrisma();
    expect(await withTxBudget(prisma, 'tenant-a', 'voucher', async () => 'saved')).toBe('saved');
    expect($transaction.mock.calls[0]?.[1]).toEqual({ timeout: 20_000, maxWait: 5_000 });
    expect(statements).toEqual([{ sql: BIND, params: ['tenant-a', '20000'] }]);
  });

  it('runs a profile with its class limits and its isolation level', async () => {
    for (const [profile, expected] of [
      [SNAPSHOT_READ, { timeout: 5_000, maxWait: 2_000, isolationLevel: 'RepeatableRead' }],
      [SERIALIZABLE_VOUCHER, { timeout: 20_000, maxWait: 5_000, isolationLevel: 'Serializable' }],
      [
        READ_COMMITTED_VOUCHER,
        { timeout: 20_000, maxWait: 5_000, isolationLevel: 'ReadCommitted' },
      ],
    ] as const) {
      const { prisma, $transaction, statements } = fakePrisma();
      await withTxBudget(prisma, 'tenant-a', profile, async () => undefined);
      expect($transaction.mock.calls[0]?.[1]).toEqual(expected);
      expect(statements[0]?.params).toEqual(['tenant-a', String(expected.timeout)]);
    }
    expect(Object.isFrozen(SNAPSHOT_READ)).toBe(true);
  });

  it('applies an operator override to both the Prisma timeout and the statement timeout', async () => {
    vi.stubEnv('DATACARE_TX_BUDGET_HEAVY_MS', '45000');
    const { prisma, $transaction, statements } = fakePrisma();
    await withTxBudget(prisma, 'tenant-a', 'heavy', async () => undefined);
    expect($transaction.mock.calls[0]?.[1]).toEqual({ timeout: 45_000, maxWait: 10_000 });
    expect(statements[0]?.params).toEqual(['tenant-a', '45000']);
  });

  it('records each outcome in the histogram and rethrows failures unchanged', async () => {
    const count = (budget: string, outcome: string) =>
      Number(
        new MetricsRegistry(transactionDurations)
          .prometheus()
          .match(
            new RegExp(
              `datacare_transactions_total\\{budget="${budget}",outcome="${outcome}"\\} (\\d+)`,
            ),
          )?.[1],
      );
    const before = {
      committed: count('read', 'committed'),
      rolledBack: count('read', 'rolled_back'),
      timeout: count('read', 'timeout'),
    };
    await withTxBudget(fakePrisma().prisma, 't', 'read', async () => 1);
    const businessError = new Error('redeem 80 exceeds balance 20');
    await expect(
      withTxBudget(fakePrisma(businessError).prisma, 't', 'read', async () => 1),
    ).rejects.toBe(businessError);
    const expired = { code: 'P2028', message: 'Transaction API error: expired' };
    await expect(withTxBudget(fakePrisma(expired).prisma, 't', 'read', async () => 1)).rejects.toBe(
      expired,
    );
    expect(count('read', 'committed')).toBe(before.committed + 1);
    expect(count('read', 'rolled_back')).toBe(before.rolledBack + 1);
    expect(count('read', 'timeout')).toBe(before.timeout + 1);
  });
});
