import { afterEach, describe, expect, it, vi } from 'vitest';
import { nextHiddenVoucherNoTx, voucherTimestamp } from '../src/modules/vouchers/lifecycle.js';

const date = new Date('2026-07-27T00:00:00.000Z');

afterEach(() => vi.useRealTimers());

describe('voucher lifecycle primitives', () => {
  it('preserves a persisted wall-clock value onto a new voucher date', () => {
    expect(voucherTimestamp(date, '09:08:07.123')).toEqual(new Date('2026-07-27T09:08:07.123'));
  });

  it('preserves the UTC time from a Date input', () => {
    expect(voucherTimestamp(date, new Date('2021-02-03T04:05:06.789Z'))).toEqual(
      new Date('2026-07-27T04:05:06.789Z'),
    );
  });

  it('uses the current UTC time when the prior value is missing', () => {
    vi.useFakeTimers();
    vi.setSystemTime(new Date('2024-01-02T13:14:15.678Z'));
    expect(voucherTimestamp(date)).toEqual(new Date('2026-07-27T13:14:15.678Z'));
  });

  it('formats the next hidden voucher number to five digits', async () => {
    const tx = {
      $executeRawUnsafe: vi.fn().mockResolvedValue(undefined),
      $queryRawUnsafe: vi.fn().mockResolvedValue([{ max_no: 41 }]),
    };
    const result = await nextHiddenVoucherNoTx(tx, {
      tenantId: 'tenant',
      coCode: '01',
      lcCode: '02',
      coBook: 'MLT',
    });

    expect(result).toBe('00042');
    expect(tx.$executeRawUnsafe).toHaveBeenCalledWith(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      'melting-temp|tenant|01|02|MLT',
    );
    expect(tx.$queryRawUnsafe.mock.calls[0]?.slice(1)).toEqual(['tenant', '01', '02', 'MLT']);
    expect(tx.$queryRawUnsafe.mock.calls[0]?.[0]).not.toContain('CO_YEAR');
  });
});
