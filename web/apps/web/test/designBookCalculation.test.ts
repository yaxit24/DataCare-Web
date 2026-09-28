import { describe, expect, it } from 'vitest';
import {
  blankDesign,
  designFromDb,
  designToPayload,
  initializeDesignCalculations,
  commitDesignField,
  commitPendingDesignFields,
  addDesignComponent,
  removeDesignComponent,
  selectDesignComponentItem,
  refreshDesignParent,
  configuredDesignColumns,
  type DesignCalculationConfig,
  type DesignDraft,
} from '../lib/designBookDraft';
const config: DesignCalculationConfig = {
  defaultLabourType: 'N',
  automaticCost: false,
  tagCostVisible: true,
  version: 'fixture-config',
  columns: [],
};
const edit = (row: DesignDraft, field: string, value: string, isrNo?: number) => {
  const next =
    isrNo === undefined
      ? { ...row, values: { ...row.values, [field]: value } }
      : {
          ...row,
          components: row.components.map((child) =>
            Number(child.values.isrNo) === isrNo
              ? { ...child, values: { ...child.values, [field]: value } }
              : child,
          ),
        };
  return commitDesignField(next, field, value, isrNo);
};
describe('Design Book calculation editor', () => {
  it('hydrates with no mutation or replay history, including legacy nulls, blanks and child piece weight', () => {
    const saved = {
      SR_NO: 10,
      DESIGN_NO: 'OLD',
      ITM_GWT: '3.125',
      ITM_RATE: null,
      TAG_COST: '19.25',
      LBR_TYPE: '',
      components: [
        { ISR_NO: 7, IT_CODE: 'STONE', IT_PCS_WT: '0.251', IT_GWT: '0.123', IT_LBR_AMT: null },
      ],
    };
    const plain = designFromDb(saved);
    let draft = initializeDesignCalculations(plain, config, false);
    draft = commitPendingDesignFields(draft);
    expect(designToPayload(draft)).toEqual(designToPayload(plain));
    expect(draft.calculation?.events).toEqual([]);
  });
  it('updates visible cells on ordered commits and sends only item code for server-side master resolution', () => {
    let draft = initializeDesignCalculations(blankDesign(10), config, true);
    draft.values.designNo = 'NEW';
    expect(draft.values).toMatchObject({ pcs: '1', labourType: 'N' });
    draft = edit(draft, 'grossWt', '10');
    draft = edit(draft, 'touch', '90');
    draft = addDesignComponent(draft);
    draft = selectDesignComponentItem(draft, 1, 'STONE', {
      itType: 'S',
      conversionPct: 0.2,
      rateType: 'P',
      rate: 50,
    });
    draft = edit(draft, 'pcs', '4', 1);
    draft = edit(draft, 'pcsWt', '2', 1);
    draft = edit(draft, 'karigarLessPct', '10', 1);
    draft = edit(draft, 'labourRate', '2', 1);
    expect(draft.components[0]?.values).toMatchObject({
      karigarWt: '8',
      grossWt: '0.8',
      conversionWt: '0.16',
      amount: '200',
      labourAmount: '8',
      netAmount: '208',
    });
    draft = refreshDesignParent(draft);
    draft = edit(draft, 'rate', '100');
    expect(draft.values).toMatchObject({
      otherWt: '0.16',
      netWt: '9.84',
      fineWt: '8.856',
      amount: '886',
      otherAmount: '208',
    });
    const output = designToPayload(draft);
    expect(output.calculationVersion).toBe('fixture-config');
    expect(output.calculationEvents).toContainEqual({ kind: 'item', isrNo: 1, itCode: 'STONE' });
    expect(JSON.stringify(output.calculationEvents)).not.toContain('defaults');
  });
  it('flushes an actively edited numeric cell and rejects invalid text without dropping it', () => {
    let draft = initializeDesignCalculations(blankDesign(1), config, true);
    draft.values.grossWt = '12.3456';
    draft = commitPendingDesignFields(draft);
    expect(draft.values).toMatchObject({ grossWt: '12.346', netWt: '12.346' });
    draft.values.rate = 'bad';
    expect(() => commitPendingDesignFields(draft)).toThrow('finite');
    expect(draft.values.rate).toBe('bad');
  });
  it('logs removals with stable serials and preserves parent nonzero aggregates when the last child is removed', () => {
    let draft = initializeDesignCalculations(
      designFromDb({
        SR_NO: 10,
        DESIGN_NO: 'OLD',
        ITM_GWT: 10,
        ITM_OTH_WT: 0.4,
        OTH_AMT: 100,
        components: [{ ISR_NO: 7, IT_CODE: 'STONE', IT_CON_WT: 0.4, IT_NET_AMT: 100 }],
      }),
      config,
      false,
    );
    draft = removeDesignComponent(draft, 0);
    expect(draft.values).toMatchObject({ otherWt: '0.4', otherAmount: '100' });
    draft = addDesignComponent(draft);
    expect(draft.components[0]?.values.isrNo).toBe('8');
    expect(draft.calculation?.events).toEqual([
      { kind: 'removeComponent', isrNo: 7 },
      { kind: 'addComponent', isrNo: 8 },
    ]);
  });
  it('applies configured desktop column names while retaining hidden values in save payloads', () => {
    const custom = {
      ...config,
      columns: [
        {
          bookName: 'DESIGN DETL',
          name: 'TagCost',
          label: 'Private cost',
          visible: false,
          repeat: false,
        },
        {
          bookName: 'TAG_IDTL',
          name: 'Weight',
          label: 'Customer gold',
          visible: true,
          repeat: false,
        },
      ],
    };
    expect(configuredDesignColumns(custom).some((column) => column.key === 'tagCost')).toBe(false);
    expect(
      configuredDesignColumns(custom, true).find((column) => column.key === 'grossWt')?.label,
    ).toBe('Customer gold');
    const draft = initializeDesignCalculations(
      designFromDb({ SR_NO: 1, DESIGN_NO: 'HIDDEN', TAG_COST: '45.23' }),
      custom,
      false,
    );
    expect(designToPayload(draft).tagCost).toBe('45.23');
  });
});
