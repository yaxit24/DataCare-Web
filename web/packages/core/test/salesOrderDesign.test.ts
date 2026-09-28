import { describe, expect, it } from 'vitest';
import {
  applySalesOrderDesignSelection,
  clearSalesOrderDesignSelection,
  type SalesOrderDesignOption,
} from '../src/salesOrderDesign.js';

const source: SalesOrderDesignOption = {
  source: { prCode: 'RG', bookName: 'BOOK', srNo: 17, oldSrNo: 42, version: 'v1' },
  designNo: 'DESIGN',
  bookName: 'BOOK',
  productName: 'Ring',
  remark: 'Remark',
  itmSize: '12',
  karigarName: 'K01',
  grossWt: '999.999',
  touch: '91.625',
  westPct: '2.3450',
  labourPct: '5.5550',
  labourRate: '77.25',
  designImageId: 'SAVED-ID',
};
const draft = () => ({
  srNo: 23,
  oldSrNo: 81,
  clientKey: 'stable',
  designNo: 'OLD',
  itmSize: '2',
  karigarName: 'K02',
  designImageId: 'OLD-ID',
  touch: '12',
  westPct: '7',
  labourPct: '8',
  labourRate: '91',
  grossWt: '3.333',
  fineWt: '0.444',
  itemAmount: '123.45',
  lineNetAmount: '155.67',
  making: '22.22',
  components: [{ isrNo: 9, amount: null, hidden: 'imported' }],
  loadedData: { hidden: 'untouched' },
});
describe('Sales F1 source copy contract', () => {
  it('copies only source-defined cells, preserves identities, children and cached amounts without mutating', () => {
    const before = draft();
    const next = applySalesOrderDesignSelection(before, source, { existing: false });
    expect(next).toEqual({
      ...before,
      designNo: 'DESIGN',
      itmSize: '12',
      karigarName: 'K01',
      designImageId: 'SAVED-ID',
      touch: '91.63',
      westPct: '2.35',
      labourPct: '5.56',
    });
    expect(next.components).toBe(before.components);
    expect(next.loadedData).toBe(before.loadedData);
    expect(before.designNo).toBe('OLD');
  });
  it('does not apply any numeric defaults to a saved E parent', () => {
    const before = draft();
    expect(applySalesOrderDesignSelection(before, source, { existing: true })).toEqual({
      ...before,
      designNo: 'DESIGN',
      itmSize: '12',
      karigarName: 'K01',
      designImageId: 'SAVED-ID',
    });
  });
  it('preserves zero/null numeric source values and copies rate only with raw zero percentage', () => {
    const before = draft();
    expect(
      applySalesOrderDesignSelection(
        before,
        { ...source, touch: null, westPct: '0.0000', labourPct: '0', labourRate: '77.25' },
        { existing: false },
      ),
    ).toEqual({
      ...before,
      designNo: 'DESIGN',
      itmSize: '12',
      karigarName: 'K01',
      designImageId: 'SAVED-ID',
      labourRate: '77.25',
    });
  });
  it('tests nonzero before formatting, including negative values and tiny percentage blocking rate', () => {
    const next = applySalesOrderDesignSelection(
      draft(),
      { ...source, touch: '-1.235', westPct: '0.0001', labourPct: '0.0001' },
      { existing: false },
    );
    expect([next.touch, next.westPct, next.labourPct, next.labourRate]).toEqual([
      '-1.24',
      '0.00',
      '0.00',
      '91',
    ]);
  });
  it('keeps numeric server values numeric and maps a nullable image to the actual empty source cell', () => {
    const next = applySalesOrderDesignSelection(
      { touch: 0, westPct: 0, labourPct: 0, labourRate: 2, designImageId: 'N' },
      { ...source, designImageId: null },
      { existing: false },
    );
    expect(next).toMatchObject({
      touch: 91.63,
      westPct: 2.35,
      labourPct: 5.56,
      labourRate: 2,
      designImageId: '',
    });
  });
  it('clear and selected empty design remove only design/image; cancellation is no event', () => {
    const before = draft();
    const cleared = { ...before, designNo: '', designImageId: 'N' };
    expect(clearSalesOrderDesignSelection(before)).toEqual(cleared);
    expect(
      applySalesOrderDesignSelection(before, { ...source, designNo: '' }, { existing: false }),
    ).toEqual(cleared);
  });
  it('later manual input wins and invalid unrelated drafts are retained', () => {
    const before = { ...draft(), grossWt: 'invalid weight', labourRate: 'invalid manual rate' };
    const selected = applySalesOrderDesignSelection(before, source, { existing: false });
    const edited = { ...selected, touch: '88.88' };
    expect(edited.touch).toBe('88.88');
    expect(edited.grossWt).toBe('invalid weight');
    expect(edited.labourRate).toBe('invalid manual rate');
    expect(edited.srNo).toBe(23);
  });
  it('preserves full supported source decimal strings and refuses lossy numeric targets', () => {
    const large = { ...source, labourPct: '0', labourRate: '9007199254740992.23' };
    expect(applySalesOrderDesignSelection(draft(), large, { existing: false }).labourRate).toBe(
      '9007199254740992.23',
    );
    expect(() =>
      applySalesOrderDesignSelection({ labourRate: 0 }, large, { existing: false }),
    ).toThrow('exact decimal storage');
  });
});
