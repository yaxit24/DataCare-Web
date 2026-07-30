import { describe, it, expect } from 'vitest';
import {
  postLedgerAdjust,
  LedgerAdjustValidationError,
} from '../src/modules/finance/ledgerAdjust.js';
import { postEmployeeJv, EmployeeJvValidationError } from '../src/modules/finance/employeeJv.js';

// Validation runs BEFORE any DB access, so these guard cases need no prisma/tenant.
const scope = { tenantId: 't', coCode: '01', lcCode: '01', coYear: '' };
const noDb = {} as any;

describe('ledger-adjust (TR_LEDR_ADJ → LDR_ADJ_DATA) validation', () => {
  it('rejects missing account', async () => {
    await expect(
      postLedgerAdjust(noDb, { scope, acCode: '', amount: 100, direction: 'debit' }),
    ).rejects.toThrow(LedgerAdjustValidationError);
  });
  it('rejects non-positive amount', async () => {
    await expect(
      postLedgerAdjust(noDb, { scope, acCode: 'CUST', amount: 0, direction: 'debit' }),
    ).rejects.toThrow(LedgerAdjustValidationError);
  });
  it('rejects adjustment account equal to the account', async () => {
    await expect(
      postLedgerAdjust(noDb, {
        scope,
        acCode: 'CUST',
        adjAc: 'CUST',
        amount: 100,
        direction: 'debit',
      }),
    ).rejects.toThrow(LedgerAdjustValidationError);
  });
});

describe('employee-JV (TR_EMP_JV → EMP_DATA) validation', () => {
  it('rejects missing employee account', async () => {
    await expect(postEmployeeJv(noDb, { scope, empAc: '', salaryAmt: 1000 })).rejects.toThrow(
      EmployeeJvValidationError,
    );
  });
  it('rejects non-positive salary', async () => {
    await expect(postEmployeeJv(noDb, { scope, empAc: 'EMP1', salaryAmt: 0 })).rejects.toThrow(
      EmployeeJvValidationError,
    );
  });
  it('rejects TDS+PF exceeding salary', async () => {
    await expect(
      postEmployeeJv(noDb, { scope, empAc: 'EMP1', salaryAmt: 1000, tdsAmt: 800, pfAmt: 300 }),
    ).rejects.toThrow(EmployeeJvValidationError);
  });
});

describe('finance-writer error → HTTP 400 mapping', () => {
  it('error names end in ValidationError', () => {
    expect(new LedgerAdjustValidationError('x').name).toMatch(/ValidationError$/);
    expect(new EmployeeJvValidationError('x').name).toMatch(/ValidationError$/);
  });
});
