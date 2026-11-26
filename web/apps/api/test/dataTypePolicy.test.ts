import { expect, it } from 'vitest';
import {
  openingDataType,
  validateDataTypeAccess,
  sessionReportQuery,
} from '../src/modules/auth/dataTypePolicy.js';
it('requires a canonical nonempty allow set containing its default', () => {
  expect(validateDataTypeAccess('AB', 'B')).toEqual({ allowed: 'AB', defaultType: 'B' });
  for (const [allow, def] of [
    ['', 'A'],
    ['BA', 'B'],
    ['A', 'C'],
    ['ABC', 'X'],
  ]) {
    expect(() => validateDataTypeAccess(allow, def)).toThrow('invalid-data-type-access');
  }
});
it('maps All openings to A (MS_ACCT.cs:7861-7895)', () => {
  expect(['A', 'B', 'C'].map(openingDataType)).toEqual(['A', 'B', 'A']);
});
it('ignores every client data type selector', () => {
  expect(sessionReportQuery({ dataType: 'B', orderDataType: 'B', q: 'keep' }, 'A')).toEqual({
    dataType: 'A',
    orderDataType: 'A',
    q: 'keep',
  });
  expect(sessionReportQuery({ dataType: 'B' }, 'C').dataType).toBe('C');
  expect(sessionReportQuery({ q: 'x' }, 'C')).toEqual({ q: 'x' });
  expect(sessionReportQuery({ q: 'x' }, 'B')).toEqual({ q: 'x', dataType: 'B' });
});
