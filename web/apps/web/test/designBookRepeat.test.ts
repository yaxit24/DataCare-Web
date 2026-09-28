import { describe, expect, it } from 'vitest';
import {
  blankDesign,
  designFromDb,
  designToPayload,
  initializeDesignCalculations,
  newDesignWithRepeat,
  addDesignComponent,
  enterDesignField,
  discardEmptyDesignComponent,
  commitPendingDesignFields,
  type DesignCalculationConfig,
} from '../lib/designBookDraft';
import {
  designGridAction,
  designComponentReturnField,
  DESIGN_KEY_FIELDS,
  COMPONENT_KEY_FIELDS,
} from '../lib/designBookKeyboard';
const config: DesignCalculationConfig = {
  version: 'repeat-test',
  defaultLabourType: 'N',
  automaticCost: false,
  tagCostVisible: true,
  columns: [
    { bookName: 'DESIGN DETL', name: 'GrWt', label: 'Customer gross', visible: true, repeat: true },
    {
      bookName: 'DESIGN DETL',
      name: 'TagCost',
      label: 'Hidden cost',
      visible: false,
      repeat: true,
    },
    { bookName: 'DESIGN DETL', name: 'Style', label: 'Style', visible: true, repeat: true },
    { bookName: 'TAG_IDTL', name: 'ItCode', label: 'Stone item', visible: true, repeat: true },
    { bookName: 'TAG_IDTL', name: 'PcsWt', label: 'Each weight', visible: true, repeat: true },
    { bookName: 'TAG_IDTL', name: 'ItAmt', label: 'Stone amount', visible: false, repeat: true },
  ],
};
describe('Design repeat draft and identity contract', () => {
  it('creates a separate parent with configured raw values, new IDs and no copied child/image/saved snapshot', () => {
    const previous = initializeDesignCalculations(
      designFromDb({
        SR_NO: 17,
        OLD_SRNO: 42,
        DESIGN_NO: 'OLD',
        ITM_STYLE: 'Style A',
        ITM_GWT: '1.23456',
        TAG_COST: '71.23',
        DESIGN_IMG_ID: 'saved-photo',
        components: [{ ISR_NO: 9, IT_CODE: 'STONE', IT_PCS_WT: '0.251' }],
      }),
      config,
      false,
    );
    const snapshot = designToPayload(previous);
    const next = newDesignWithRepeat(23, previous, config, false);
    expect(next.values).toMatchObject({
      srNo: '23',
      oldSrNo: '23',
      designNo: '',
      style: 'Style A',
      grossWt: '1.23456',
      tagCost: '71.23',
      pcs: '1',
      labourType: 'N',
    });
    expect(next.values.netWt).toBe('');
    expect(next.components).toEqual([]);
    expect(next.saved).toBeUndefined();
    expect(next.calculation?.events).toEqual([
      { kind: 'repeatParent', values: { grossWt: '1.23456', tagCost: '71.23' } },
    ]);
    expect(designToPayload(previous)).toEqual(snapshot);
  });
  it('copies only the preceding child of the same parent and retains zero/manual totals without calculation', () => {
    const loaded = initializeDesignCalculations(
      designFromDb({
        SR_NO: 17,
        OLD_SRNO: 42,
        DESIGN_NO: 'OLD',
        ITM_GWT: 10,
        OTH_AMT: 91,
        components: [
          { ISR_NO: 3, IT_CODE: 'FIRST', IT_PCS_WT: '0.1' },
          { ISR_NO: 9, IT_CODE: 'LAST', IT_PCS_WT: '0.251', IT_AMT: '17.29', IT_LBR_AMT: null },
        ],
      }),
      config,
      false,
    );
    const next = addDesignComponent(loaded);
    expect(next.components.map((child) => child.values.isrNo)).toEqual(['3', '9', '10']);
    expect(next.components[2]?.values).toMatchObject({
      itCode: 'LAST',
      pcsWt: '0.251',
      amount: '17.29',
      pcs: '',
      labourAmount: '',
    });
    expect(next.values.otherAmount).toBe('91');
    expect(next.components[0]).toEqual(loaded.components[0]);
    expect(next.components[1]).toEqual(loaded.components[1]);
    expect(next.calculation?.events).toEqual([
      { kind: 'addComponent', isrNo: 10 },
      { kind: 'repeatComponent', isrNo: 10, fromIsrNo: 9 },
    ]);
  });
  it('keeps invalid pending drafts intact and does not allocate a repeated child', () => {
    const row = initializeDesignCalculations(blankDesign(17), config, true);
    row.values.grossWt = 'invalid';
    expect(() => addDesignComponent(row)).toThrow('finite');
    expect(row.values.grossWt).toBe('invalid');
    expect(row.components).toEqual([]);
    expect(row.nextComponentSerial).toBe(1);
  });
  it('retains imported snapshots on focus/unchanged blur but treats explicit Enter as a source calculation trigger', () => {
    const row = initializeDesignCalculations(
      designFromDb({
        SR_NO: 17,
        OLD_SRNO: 42,
        DESIGN_NO: 'OLD',
        ITM_GWT: 10,
        ITM_NWT: 7,
        ITM_FINE: 3,
        ITM_RATE: 5,
        ITM_AMT: 91,
        components: [],
      }),
      config,
      false,
    );
    expect(designToPayload(commitPendingDesignFields(row))).toEqual(designToPayload(row));
    const entered = enterDesignField(row, 'grossWt', '10');
    // CommPassTotal zero touch+west assigns fine=net+ghat, then amount=7*5.
    expect(entered.values.amount).toBe('35');
    expect(entered.values.srNo).toBe('17');
    expect(entered.values.oldSrNo).toBe('42');
    expect(entered.calculation?.events).toEqual([
      { kind: 'parent', field: 'grossWt', value: '10' },
    ]);
  });
  it('requires nonzero gross except P basis and rejects invalid Enter without mutating the draft', () => {
    const row = initializeDesignCalculations(blankDesign(17), config, true);
    expect(() => enterDesignField(row, 'grossWt', '0')).toThrow('nonzero');
    expect(() => enterDesignField(row, 'grossWt', 'bad')).toThrow('finite');
    const pieces = { ...row, values: { ...row.values, rateType: 'P' } };
    expect(enterDesignField(pieces, 'grossWt', '0').values.grossWt).toBe('0');
    expect(row.calculation?.events).toEqual([]);
  });
  it('strips master defaults from keyboard replay payload and discards only an untouched new blank child', () => {
    const plain = { ...config, columns: [] };
    let row = initializeDesignCalculations(blankDesign(17), plain, true);
    row.values.designNo = 'NEW';
    row = addDesignComponent(row);
    const discarded = discardEmptyDesignComponent(row, 1);
    expect(discarded.components).toEqual([]);
    expect(discarded.calculation?.events).toEqual([
      { kind: 'addComponent', isrNo: 1 },
      { kind: 'discardEmptyComponent', isrNo: 1 },
    ]);
    row.components[0]!.values.itCode = 'STONE';
    const edited = enterDesignField(row, 'grossWt', '0', 1, {
      itType: 'S',
      conversionPct: 0,
      rateType: 'F',
      rate: 77,
    });
    const payload = designToPayload(edited);
    expect(JSON.stringify(payload.calculationEvents)).not.toContain('defaults');
    expect(discardEmptyDesignComponent(edited, 1)).toBe(edited);
  });
});

const navigation = (changes: Partial<Parameters<typeof designGridAction>[0]> = {}) =>
  designGridAction({
    key: 'Enter',
    field: 'grossWt',
    value: '10',
    row: 0,
    rowCount: 2,
    fields: DESIGN_KEY_FIELDS,
    ...changes,
  });
describe('Design page source grid focus contract', () => {
  it('routes Gross Enter to components and blank child Item Enter back to the parent', () => {
    expect(navigation()).toEqual({ kind: 'enterComponents' });
    expect(
      navigation({ components: true, field: 'itCode', value: '', fields: COMPONENT_KEY_FIELDS }),
    ).toEqual({ kind: 'leaveComponents' });
    expect(designComponentReturnField('grossWt', DESIGN_KEY_FIELDS)).toBe('otherWt');
    expect(
      designComponentReturnField(
        'grossWt',
        DESIGN_KEY_FIELDS.filter((field) => field !== 'otherWt'),
      ),
    ).toBe('netWt');
  });
  it('Net Amount Enter moves to the next child, appending only at the final child', () => {
    expect(
      navigation({ components: true, field: 'netAmount', fields: COMPONENT_KEY_FIELDS }),
    ).toEqual({ kind: 'move', row: 1, field: 'itCode' });
    expect(
      navigation({ components: true, field: 'netAmount', fields: COMPONENT_KEY_FIELDS, row: 1 }),
    ).toEqual({ kind: 'append', field: 'itCode' });
  });
  it('Karigar Enter advances to Page No and creates a row only at the final design', () => {
    expect(navigation({ field: 'karigarName' })).toEqual({ kind: 'move', row: 1, field: 'pageNo' });
    expect(navigation({ field: 'karigarName', row: 1 })).toEqual({
      kind: 'append',
      field: 'pageNo',
    });
  });
  it('skips hidden columns and excludes stable identities from keyboard navigation', () => {
    expect(
      navigation({ field: 'pcs', fields: ['srNo', 'oldSrNo', 'pcs', 'netWt', 'rate'] }),
    ).toEqual({ kind: 'move', row: 0, field: 'netWt' });
    expect(navigation({ field: 'srNo', fields: ['srNo', 'pcs'] })).toEqual({ kind: 'none' });
  });
  it('preserves caret editing, row boundaries, lookup handling and native command keys', () => {
    expect(navigation({ key: 'ArrowLeft', field: 'pcs', atStart: false })).toEqual({
      kind: 'none',
    });
    expect(navigation({ key: 'ArrowLeft', field: 'pcs', atStart: true })).toEqual({
      kind: 'move',
      row: 0,
      field: 'dieNo',
    });
    expect(navigation({ key: 'ArrowUp', row: 0 })).toEqual({ kind: 'none' });
    expect(navigation({ defaultPrevented: true })).toEqual({ kind: 'none' });
    expect(navigation({ command: true })).toEqual({ kind: 'none' });
    expect(navigation({ shift: true })).toEqual({ kind: 'none' });
  });
  it('Ctrl/Cmd+D requests confirmation for the addressed row', () => {
    expect(navigation({ key: 'd', command: true })).toEqual({ kind: 'confirmRemove' });
  });
});
