import { afterEach, describe, expect, it, vi } from 'vitest';
import { MetricsRegistry } from '../src/modules/ops/metrics.js';
import {
  COMMAND_TX_BUDGETS,
  isTransactionTimeout,
  TransactionDurations,
  TxBudgetConfigurationError,
  txBudget,
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
