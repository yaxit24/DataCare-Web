import { describe, it, expect } from 'vitest';
import {
  assertPeriodOpen,
  ledgerBalance,
  assertBalanced,
  PeriodLockConfigurationValidationError,
  PeriodLockValidationError,
  UnbalancedError,
} from '../src/modules/posting/posting.js';

describe('ledger balance', () => {
  it('balanced when Σ CR = Σ DR', () => {
    const lines = [{ DR_AMT: 1000 }, { CR_AMT: 600 }, { CR_AMT: 400 }];
    expect(ledgerBalance(lines)).toEqual({ cr: 1000, dr: 1000, balanced: true });
    expect(() => assertBalanced(lines)).not.toThrow();
  });
  it('detects imbalance to 2dp', () => {
    const lines = [{ DR_AMT: 1000 }, { CR_AMT: 999.99 }];
    expect(ledgerBalance(lines).balanced).toBe(false);
    expect(() => assertBalanced(lines)).toThrow(UnbalancedError);
  });
});

describe('period lock', () => {
  const voucher = (date?: unknown) => ({
    ledger: {
      table: 'AC_DATA',
      lines: [{ CO_CODE: '01', ...(date === undefined ? {} : { VCH_DATE: date }) }],
    },
  });

  it('blocks dates on/before the configured lock and permits later dates', async () => {
    const tx = { $queryRawUnsafe: async () => [{ d: '2024-03-31' }] };
    await expect(assertPeriodOpen(tx, 'tenant', voucher('2024-03-31'))).rejects.toBeInstanceOf(
      PeriodLockValidationError,
    );
    await expect(assertPeriodOpen(tx, 'tenant', voucher('2024-04-01'))).resolves.toBeUndefined();
  });

  it('fails closed for malformed lock values and missing voucher dates', async () => {
    const invalid = { $queryRawUnsafe: async () => [{ d: 'not-a-date' }] };
    await expect(assertPeriodOpen(invalid, 'tenant', voucher('2024-04-01'))).rejects.toBeInstanceOf(
      PeriodLockConfigurationValidationError,
    );
    const missing = { $queryRawUnsafe: async () => [] };
    await expect(assertPeriodOpen(missing, 'tenant', voucher('2024-04-01'))).rejects.toBeInstanceOf(
      PeriodLockConfigurationValidationError,
    );
    await expect(assertPeriodOpen(missing, 'tenant', voucher())).rejects.toBeInstanceOf(
      PeriodLockConfigurationValidationError,
    );
  });
});

describe('persisted lock date gate', () => {
  const voucher = (date: string) => ({
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: '01', VCH_DATE: date }] },
  });

  // Desktop applies LAST_DAY_LOCK by writing CO_SET.LOCK_DATE at company open
  // (MS_OPNCOMP.cs:1503-1507), so the save gate reads the persisted lock date only.
  it('blocks dates on or before the persisted lock date and allows later ones', async () => {
    const tx = { $queryRawUnsafe: async () => [{ d: '2024-04-09' }] };
    await expect(assertPeriodOpen(tx, 'tenant', voucher('2024-04-09'))).rejects.toBeInstanceOf(
      PeriodLockValidationError,
    );
    await expect(assertPeriodOpen(tx, 'tenant', voucher('2024-04-10'))).resolves.toBeUndefined();
  });
});
