import { describe, it, expect } from 'vitest';
import { shapeRegister, type RegisterRow } from '../src/modules/reports/reports.js';

const row = (o: Partial<RegisterRow>): RegisterRow => ({
  vchNo: '1',
  vchDate: null,
  billNo: null,
  acCode: 'C',
  party: 'C',
  netAmt: 0,
  taxAmt: 0,
  cgst: 0,
  sgst: 0,
  igst: 0,
  totAmt: 0,
  osAmt: 0,
  ...o,
});

describe('report registers', () => {
  it('shapeRegister rolls up totals', () => {
    const reg = shapeRegister([
      row({ netAmt: 1000, taxAmt: 30, cgst: 15, sgst: 15, totAmt: 1030 }),
      row({ netAmt: 2000, taxAmt: 60, igst: 60, totAmt: 2060 }),
    ]);
    expect(reg.rows.length).toBe(2);
    expect(reg.totals.netAmt).toBe(3000);
    expect(reg.totals.totAmt).toBe(3090);
    expect(reg.totals.cgst).toBe(15);
    expect(reg.totals.igst).toBe(60);
  });
  it('empty register totals to zero', () => {
    expect(shapeRegister([]).totals.totAmt).toBe(0);
  });
});
