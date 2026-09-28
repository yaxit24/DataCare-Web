import { describe, expect, it } from 'vitest';
import { readFileSync } from 'node:fs';
import { join } from 'node:path';

const source = readFileSync(join(__dirname, '..', 'app', '(app)', 'txn', 'scheme', 'page.tsx'), 'utf8');

describe('scheme installment UPI wiring', () => {
  it('exposes desktop installment collection fields and forwards them in the payload', () => {
    for (const label of [
      'Month Code',
      'Employee',
      'Settlement A/c',
      'Bank Name',
      'With UPI split/payment (writes UPI_DATA)',
      'UPI A/c',
      'UPI A/c Name',
      'UPI Type',
      'UPI ID',
      'UPI Amount ₹',
    ]) {
      expect(source).toContain(label);
    }

    for (const field of [
      'bankAc: inst.bankAc.trim()',
      'bankName: inst.bankName.trim()',
      'empCode: inst.empCode.trim()',
      'withUpi: wantsUpi',
      'upiAcCode: wantsUpi',
      'upiAcName: wantsUpi',
      'upiType: wantsUpi',
      'upiId: wantsUpi',
      'upiAmount: wantsUpi',
    ]) {
      expect(source).toContain(field);
    }
  });
});
