import { describe, expect, it } from 'vitest';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';

/** Every desktop voucher form shows one lock-date text (TR_SALE.cs:15066, TR_KR_ISU.cs:4980, TR_CASH.cs, TR_CONTRA.cs). */
describe('PeriodLockValidationError', () => {
  it('carries the desktop text with the lock date as dd/MM/yyyy', () => {
    const error = new PeriodLockValidationError('2020-01-10', '2020-01-15');
    expect(error.message).toBe(
      'You Cant Save and Delete This Voucher Becouse Lock Date is = 15/01/2020 ....',
    );
    expect(error.name).toBe('PeriodLockValidationError');
  });
});
