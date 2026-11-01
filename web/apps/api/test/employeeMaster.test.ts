import { describe, expect, it } from 'vitest';
import {
  codeTakenMessage,
  nameTakenMessage,
  nextEmployeeCode,
} from '../src/modules/masters/employeeMaster.js';

/** N211 / G224: MS_EMP's next code (CLEAR_DATA, MS_EMP.cs:1260-1268) and its validating texts (:1360, :1401). */
describe('Employee master rules', () => {
  it("numbers a company without employees '001' and otherwise the highest code + 1 as three digits", () => {
    expect(nextEmployeeCode([])).toBe('001');
    expect(nextEmployeeCode(['001', '002'])).toBe('003');
    expect(nextEmployeeCode(['001', '010', '009'])).toBe('011');
    expect(nextEmployeeCode(['7'])).toBe('008');
    expect(nextEmployeeCode(['099'])).toBe('100');
  });

  it('skips a code that is not a number, where the desktop would offer a code already used', () => {
    // ORDER BY EMP_CODE DESC puts 'X1' first and Val('X1') + 1 is 1, so the desktop offers '001' again.
    expect(nextEmployeeCode(['001', 'X1'])).toBe('002');
    expect(nextEmployeeCode(['ABC'])).toBe('001');
  });

  it('words the duplicate code and name refusals as the desktop does', () => {
    expect(codeTakenMessage('ANIL SHAH')).toBe(
      "This Employee Code already Exist in  'ANIL SHAH'  Employee Name...Please Change Employee Code...",
    );
    expect(nameTakenMessage('002')).toBe(
      "This Employee Name already Exist in  '002'  Employee Code...Please Change Employee Name...",
    );
  });
});
