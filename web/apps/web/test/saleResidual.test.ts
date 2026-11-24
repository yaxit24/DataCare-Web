import { describe, expect, it } from 'vitest';
import { cell, keepFine, saleLineFromView } from '../lib/saleResidual';

/** WP-26 review of #250: the reopened line carries the stored ITM_AMT, ITM_FINE and KR_* back, zero included. */
describe('Sales Invoice reopen line (TR_SALE.cs:14365-14412)', () => {
  it('keeps typed ITM_AMT, ITM_FINE and a zero KR_NET_WT as stored', () => {
    const row = saleLineFromView({
      itCode: 'G',
      metalAmount: 61000,
      fineWt: 9.2,
      karigarNetWt: 0,
      karigarFine: 0,
    });
    expect([row.metalAmount, row.fineWt, row.karigarNetWt, row.karigarFine]).toEqual([
      '61000',
      '9.2',
      '0',
      '0',
    ]);
    expect([cell(row.metalAmount as string), cell(row.karigarNetWt as string), cell('')]).toEqual([
      61000,
      0,
      undefined,
    ]);
  });

  it('a weight or touch edit drops the reopened fine; other edits keep it', () => {
    expect(keepFine({ fineWt: '9.2' }, 'netWt').fineWt).toBe('');
    expect(keepFine({ fineWt: '9.2' }, 'remark').fineWt).toBe('9.2');
  });
});
