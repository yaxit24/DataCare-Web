/**
 * The settings loader must accept the values REAL customer databases actually contain.
 *
 * WHY THIS FILE EXISTS
 * ====================
 * Both defects below were found by replaying real vouchers through the posting engine with masters imported
 * straight out of the desktop database (`parity-import-masters.mjs` + `parity-replay-generic.mjs`). Neither
 * was visible to the existing unit tests, because those tests construct settings objects by hand and so only
 * ever exercised values someone had already decided were valid.
 *
 * Every replay of every voucher failed at `resolveSettingsBehavior` before reaching any posting logic:
 *
 *   1. `CO_SET.CASH_LIMIT must be positive`
 *      CASH_LIMIT is 0 in EVERY CO_SET row of all four customer databases examined — Live24, Next23, Next24
 *      and Next25 — while those shops post cash vouchers freely (Live24 alone: 133 CASH PAY, 56 CASH REC).
 *      0 means "no cash ceiling". The old loader threw on it.
 *      The pre-existing test 'CASH_LIMIT zero disables only the cash ceiling' passed `cashLimit: 0` directly
 *      into `tenderThresholdDecision`, bypassing the loader — it proved the consumer, never the producer.
 *
 *   2. `CO_SET.FINE_STK_TYPE is invalid: F`
 *      The enum listed A/N/G, taken from the values one REPORT accepts (RP_STOCK_FINE.cs:2963-2977). But the
 *      desktop STORES and defaults to 'F' (MS_OPNCOMP.cs:765-767), and 'F' is present in all four databases.
 *
 * The lesson these encode: a settings loader must be tested against values taken from real installations, not
 * against values chosen by whoever wrote the loader.
 */
import { describe, expect, it } from 'vitest';
import { resolveSettingsBehavior } from '../src/modules/shared/settingsBehavior.js';

/**
 * CO_SET values observed in the four real customer databases (Live24, Next23, Next24, Next25).
 * Only settings-relevant columns; no customer-identifying data.
 */
const REAL_CO_SET_VALUES = {
  CASH_LIMIT: 0,
  FINE_STK_TYPE: 'F',
} as const;

describe('settings loader accepts real installation values', () => {
  it('loads a CO_SET carrying the values every real database ships', () => {
    const behavior = resolveSettingsBehavior({ ...REAL_CO_SET_VALUES });
    expect(behavior.cashLimit).toBe(0);
    expect(behavior.fineStockType).toBe('F');
  });

  it('CASH_LIMIT=0 means no ceiling and is not an error', () => {
    // Both the numeric and the string form: the column is varchar in some installs and numeric in others.
    expect(resolveSettingsBehavior({ CASH_LIMIT: 0 }).cashLimit).toBe(0);
    expect(resolveSettingsBehavior({ CASH_LIMIT: '0' }).cashLimit).toBe(0);
  });

  it('a BLANK CASH_LIMIT still falls back to the documented default, not to 0', () => {
    // Blank and explicit-zero are different states and must stay different: blank means "not configured".
    expect(resolveSettingsBehavior({ CASH_LIMIT: '' }).cashLimit).toBe(200_000);
    expect(resolveSettingsBehavior({ CASH_LIMIT: null }).cashLimit).toBe(200_000);
  });

  it("FINE_STK_TYPE='F' loads, and behaves as the persisted-fine mode", () => {
    expect(resolveSettingsBehavior({ FINE_STK_TYPE: 'F' }).fineStockType).toBe('F');
    // 'A' and 'G' are the only modes that recompute fine; F and blank both keep the persisted value, so
    // widening the enum to include F is behaviour-neutral downstream.
    expect(resolveSettingsBehavior({ FINE_STK_TYPE: 'A' }).fineStockType).toBe('A');
    expect(resolveSettingsBehavior({ FINE_STK_TYPE: 'G' }).fineStockType).toBe('G');
  });

  it('still rejects values that are genuinely not members', () => {
    expect(() => resolveSettingsBehavior({ FINE_STK_TYPE: 'X' })).toThrow();
    expect(() => resolveSettingsBehavior({ CASH_LIMIT: 'abc' })).toThrow();
  });
});
