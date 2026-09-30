import { readFileSync } from 'node:fs';
import { resolve } from 'node:path';
import { describe, expect, it } from 'vitest';
import { financeMainBooks, initialFinanceMode } from '../lib/financeBooks';
import { companyFlag, companySetting } from '../lib/companySettings';

/**
 * D1 contract table (parity-plan-2026-09-10/evidence/implementation-2026-09-29-eval-defects/contract.md).
 * The same table is enforced by the API on save. The literal below pins both halves, so neither can
 * drift from the contract alone.
 */
describe('finance book families (D1)', () => {
  it.each([
    ['receipt', 'cash', ['CASH REC', 'RECEIPT']],
    ['receipt', 'bank', ['BANK REC', 'RECEIPT']],
    ['receipt', 'cheque', ['BANK REC', 'RECEIPT']],
    ['receipt', 'card', ['BANK REC', 'RECEIPT']],
    ['receipt', 'upi', ['BANK REC', 'RECEIPT']],
    ['payment', 'cash', ['CASH PAY', 'PAYMENT']],
    ['payment', 'bank', ['BANK PAY', 'PAYMENT']],
    ['payment', 'cheque', ['BANK PAY', 'PAYMENT']],
  ] as const)('%s in %s mode lists %j', (kind, mode, expected) => {
    expect(financeMainBooks(kind, mode)).toEqual(expected);
  });

  it('the API enforces the same families on save', () => {
    const source = readFileSync(
      resolve(__dirname, '../../api/src/modules/finance/finance.ts'),
      'utf8',
    );
    expect(source).toContain("receipt: { 'CASH REC': 'cash', 'BANK REC': 'bank', RECEIPT: 'any' }");
    expect(source).toContain("payment: { 'CASH PAY': 'cash', 'BANK PAY': 'bank', PAYMENT: 'any' }");
  });

  it('Ctrl+F8/F9 (?mode=BANK) opens in bank mode; anything else opens in cash', () => {
    expect(initialFinanceMode('?mode=BANK')).toBe('bank');
    expect(initialFinanceMode('?mode=bank')).toBe('bank');
    expect(initialFinanceMode('')).toBe('cash');
    expect(initialFinanceMode('?mode=CARD')).toBe('cash');
  });
});

describe('company settings are read by column name from descriptor-keyed values', () => {
  // GET /settings keys values by descriptor id. Reading the bare column name returned undefined, so
  // every UI-honoured setting silently took its blank default.
  const values = {
    'CO_SET.SL_AMT_TYPE': 'G',
    'CO_SET_NEW.LBR_WITH_GHT': 'N',
    'CO_SET_NEW.SL_NWT_LOCK': 'Y',
  };

  it('finds CO_SET and CO_SET_NEW values by column name', () => {
    expect(companySetting(values, 'SL_AMT_TYPE')).toBe('G');
    expect(companyFlag(values, 'LBR_WITH_GHT', 'Y')).toBe(false);
    expect(companyFlag(values, 'SL_NWT_LOCK', 'N')).toBe(true);
  });

  it('still falls back to the blank default when the column is absent', () => {
    expect(companySetting(values, 'MISSING')).toBeUndefined();
    expect(companyFlag(values, 'MISSING', 'Y')).toBe(true);
    expect(companyFlag(null, 'LBR_WITH_GHT', 'Y')).toBe(true);
  });
});
