import { describe, expect, it } from 'vitest';
import {
  billNoForSave,
  derivedCellsToClear,
  editedLinePayload,
  savedLineCells,
} from '../lib/saleReturnEdit';

/**
 * WP-27 (N242): a reopened Sales Return line goes back to the server as the input that saved it, with the grid's
 * cells laid over it, so "open, change nothing, save" rewrites identical rows (cases.md reopen.lossless-no-op).
 */
const GRID = ['itCode', 'tagNo', 'pcs', 'netWt', 'rate', 'labourFixed', 'huid'];

describe('sales return reopen payload', () => {
  it('keeps every stored input the grid does not show', () => {
    const saved = {
      itCode: 'GOLD',
      tagNo: 'T1',
      pcs: 1,
      netWt: 10,
      rate: 6123.45,
      labourType: 'per_gram',
      labourRate: 237.5,
      oldSrNo: 3,
      itType: 'G',
      huid: 'HM1',
    };
    const cells = savedLineCells(saved, GRID);
    expect(cells).toMatchObject({ itCode: 'GOLD', netWt: '10', making: '237.5', huid: 'HM1' });
    const payload = editedLinePayload(
      saved,
      {
        itCode: 'GOLD',
        tagNo: 'T1',
        pcs: 1,
        netWt: 9,
        rate: 6123.45,
        labourType: 'per_gram',
        labourRate: 237.5,
      },
      GRID,
    );
    expect(payload).toEqual({
      oldSrNo: 3,
      itType: 'G',
      itCode: 'GOLD',
      tagNo: 'T1',
      pcs: 1,
      netWt: 9,
      rate: 6123.45,
      labourType: 'per_gram',
      labourRate: 237.5,
    });
  });

  it('keeps a fixed charge when the making cell is empty, and drops a cleared grid cell', () => {
    const saved = { itCode: 'LOOSE', labourType: 'fixed', labourFixed: 25, huid: 'HM1' };
    expect(savedLineCells(saved, GRID).making).toBe('');
    expect(editedLinePayload(saved, { itCode: 'LOOSE', labourFixed: 25 }, GRID)).toEqual({
      labourType: 'fixed',
      itCode: 'LOOSE',
      labourFixed: 25,
    });
  });

  it('a new line is sent as the grid shows it', () => {
    expect(editedLinePayload(undefined, { itCode: 'GOLD' }, GRID)).toEqual({ itCode: 'GOLD' });
  });

  it('keeps the stored BILL_NO on an edit (12 stays 12, not the padded 00012 of the bill box)', () => {
    expect(billNoForSave('12', '00012')).toBe('12');
    expect(billNoForSave(undefined, '12')).toBe('12');
    expect(billNoForSave(undefined, '')).toBeUndefined();
  });

  it('a changed weight or rate re-prices the line; only weight, touch and wastage re-derive the fine', () => {
    expect(derivedCellsToClear('netWt')).toEqual(['metalAmount', 'fineWt']);
    expect(derivedCellsToClear('rate')).toEqual(['metalAmount']);
    expect(derivedCellsToClear('remark')).toEqual([]);
  });
});
