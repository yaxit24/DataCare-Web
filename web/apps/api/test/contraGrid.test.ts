import { describe, expect, it } from 'vitest';
import { contraLines, contraRows } from '../src/modules/finance/contra.js';

/**
 * WP-31 (N246 / G258): the Contra Entry grid rules, with no database.
 * Cases: contra.grid.row1-positional, contra.grid.empty-refused, contra.grid.negative-amount,
 * contra.grid.rounding, contra.grid.mixed-sides-refused (unit part), contra.create.mirror-description.
 */
const NOT_SAME = 'You Cant Save This Voucher Becouse Cr Value and Dr Value is not same....';
const input = (lines: unknown[]) => ({ scope: {} as never, lines: lines as never });

describe('contraLines (TR_CONTRA grid rules)', () => {
  it('keeps row 1 positional: a blank row 1 is not replaced by row 2 (TR_CONTRA.cs:2781)', () => {
    // Dr total 0 (row 1 blank), Cr total 100 + 0.
    expect(() =>
      contraLines(
        input([
          { crdr: 'DR', acCode: '', amount: 0 },
          { crdr: 'CR', acCode: '00001', amount: 100 },
        ]),
      ),
    ).toThrow(NOT_SAME);
  });

  it.each([
    ['no rows', []],
    ['three blank rows', [{ acCode: '', amount: 0 }, { acCode: '', amount: 0 }, { amount: 0 }]],
    ['one filled row', [{ crdr: 'DR', acCode: '00008', amount: 100 }]],
  ])('refuses %s with the desktop Cr/Dr text (TR_CONTRA.cs:2694)', (_name, lines) => {
    expect(() => contraLines(input(lines))).toThrow(NOT_SAME);
  });

  it('refuses a negative amount on a row', () => {
    expect(() =>
      contraLines(
        input([
          { crdr: 'DR', acCode: '00008', amount: -100 },
          { crdr: 'CR', acCode: '00001', amount: -100 },
        ]),
      ),
    ).toThrow('Amount cannot be negative on row 1');
  });

  it('refuses an amount with no account (the desktop would drop the row and unbalance the ledger)', () => {
    expect(() =>
      contraLines(
        input([
          { crdr: 'DR', acCode: '00008', amount: 100 },
          { crdr: 'CR', acCode: '00001', amount: 60 },
          { crdr: 'CR', acCode: '', amount: 40 },
        ]),
      ),
    ).toThrow('Account code is required on row 3');
  });

  it('refuses a later row on the same side as row 1 (TR_CONTRA.cs:1538: later rows take the other side)', () => {
    expect(() =>
      contraLines(
        input([
          { crdr: 'DR', acCode: '00008', amount: 100 },
          { crdr: 'DR', acCode: '00001', amount: 50 },
          { crdr: 'CR', acCode: '00009', amount: 150 },
        ]),
      ),
    ).toThrow('A contra row after the first must take the opposite side of row 1');
  });

  it('skips a blank later row and rounds every cell to 2 decimals (TR_CONTRA.cs:1695)', () => {
    const lines = contraLines(
      input([
        { crdr: 'DR', acCode: '00008', amount: 1234.567 },
        { crdr: 'CR', acCode: '', amount: 0 },
        { crdr: 'CR', acCode: '00001', amount: 1234.567 },
      ]),
    );
    expect(lines.map((l) => [l.acCode, l.amount])).toEqual([
      ['00008', 1234.57],
      ['00001', 1234.57],
    ]);
  });

  it('accepts 0.04 + 0.06 = 0.1 although the float sum is 0.09999999999999999', () => {
    const lines = contraLines(
      input([
        { crdr: 'DR', acCode: '00008', amount: 0.1 },
        { crdr: 'CR', acCode: '00001', amount: 0.04 },
        { crdr: 'CR', acCode: '00009', amount: 0.06 },
      ]),
    );
    expect(lines).toHaveLength(3);
  });

  it('a first row on CR makes every later row DR', () => {
    const lines = contraLines(
      input([
        { crdr: 'CR', acCode: '00008', amount: 100 },
        { crdr: 'DR', acCode: '00001', amount: 60 },
        { crdr: 'DR', acCode: '00009', amount: 40 },
      ]),
    );
    expect(lines.map((l) => l.crdr)).toEqual(['CR', 'DR', 'DR']);
  });
});

describe('contraRows (CONTRA_DATA pairs, TR_CONTRA.cs:2760-2866)', () => {
  const grid = contraLines(
    input([
      { crdr: 'DR', acCode: '00008', itDesc: 'DEPOSIT', amount: 3000.5 },
      { crdr: 'CR', acCode: '00001', itDesc: 'FROM CASH', amount: 1000.25 },
      { crdr: 'CR', acCode: '00009', itDesc: 'FROM B2', amount: 2000.25 },
    ]),
  );

  it('writes counter and mirror rows with one running SR_NO', () => {
    const rows = contraRows(grid).map((r) => [
      r.SR_NO,
      r.LDR_TYPE,
      r.CRDR_TYPE,
      r.AC_CODE,
      r.DR_AMT,
      r.CR_AMT,
    ]);
    expect(rows).toEqual([
      [1, '0', 'CR', '00001', 0, 1000.25],
      [2, '1', 'DR', '00008', 1000.25, 0],
      [3, '0', 'CR', '00009', 0, 2000.25],
      [4, '1', 'DR', '00008', 2000.25, 0],
    ]);
  });

  it("gives the mirror row 1's description (TR_CONTRA.cs:2868), the counter its own", () => {
    expect(contraRows(grid).map((r) => r.IT_DESC)).toEqual([
      'FROM CASH',
      'DEPOSIT',
      'FROM B2',
      'DEPOSIT',
    ]);
  });
});
