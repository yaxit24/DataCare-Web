import { describe, expect, it } from 'vitest';
import {
  blank,
  blankOrderHeader,
  hydrateSalesOrder,
  salesOrderPayload,
  salesOrderQuery,
  localOrderDate,
  validateSalesOrderDate,
  setSalesOrderCell,
  commitSalesOrderLabour,
  salesOrderLineNet,
  selectSalesOrderDesign,
} from '../lib/salesOrderForm';
import type { SalesOrderDesignOption } from '@datacare/core';

const stored = {
  voucherNo: '00017',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  coBook: 'S41',
  version: 'saved-digest',
  acCode: 'TOURAC',
  acName: 'Customer',
  vchDate: '2024-07-10',
  vchTime: '12:13:14.123456',
  taxRatePct: '3.0000',
  advanceAmount: '0.00',
  billNo: '000071',
  address3: null,
  chequeNo: '',
  interState: true,
  netAmount: '123456789.01',
  lines: [
    {
      srNo: 17,
      itCode: 'GOLD',
      tagNo: 'IMPORTED',
      oldSrNo: 42,
      vchSrno: 6,
      designNo: 'D017',
      designImageId: '',
      netWt: '3.123',
      touch: '91.600',
      making: '37.320845341018256',
      labourType: 'P',
      labourRate: '10.25',
      labourAmount: '77.37',
      fineWeight: '0.014',
      itemAmount: '100.00',
      lineNetAmount: '177.37',
      lineTotalAmount: '182.69',
      pcs: '3.000',
      grossWt: '4.000',
      ghtWt: '0.100',
      rate: '7000.00',
      remark: ' original spaces ',
      bagWt: null,
      tagCost: '0.00',
      components: [
        {
          isrNo: 3,
          itCode: 'STONE',
          dmName: 'Ruby',
          pcs: '0.000',
          grossWt: '0.123',
          lbrAmount: null,
          rate: '0.00',
          oldItmIsu: 'Y',
        },
        {
          isrNo: 9,
          itCode: 'STONE',
          dmName: 'Diamond',
          pcs: '2.000',
          grossWt: '0.234',
          lbrAmount: '20.00',
          karigarNetAmount: '29.17',
        },
      ],
    },
  ],
};
const policy = { includesGhat: true, rateDecimals: 2 };
const option: SalesOrderDesignOption = {
  source: { prCode: 'G01', bookName: 'CATALOG', srNo: 4, oldSrNo: 91, version: 'design-version' },
  designNo: 'D004',
  bookName: 'CATALOG',
  productName: 'Gold',
  remark: 'Design',
  itmSize: '16',
  karigarName: 'Maker',
  grossWt: '999',
  touch: '92',
  westPct: '1',
  labourPct: '0',
  labourRate: '12.50',
  designImageId: 'G01-CATALOG-4',
};

describe('Sales Order complete editor lifecycle values', () => {
  it('keeps saved zero/null/text precision, wall clock and noncontiguous children unchanged', () => {
    const editor = hydrateSalesOrder(stored);
    const result = salesOrderPayload(editor.f, editor.header, editor.rows, stored.version, stored);
    expect(result).toMatchObject({
      vchTime: '12:13:14.123456',
      taxRatePct: '3.0000',
      advanceAmount: '0.00',
      address3: null,
      chequeNo: '',
      interState: true,
      expectedVersion: 'saved-digest',
    });
    expect(result).not.toHaveProperty('coBook');
    expect(result.lines[0]).toMatchObject({
      srNo: 17,
      oldSrNo: 42,
      vchSrno: 6,
      designImageId: '',
      bagWt: null,
      tagCost: '0.00',
      remark: ' original spaces ',
      labourAmount: '77.37',
    });
    expect(result.lines[0].components).toEqual(
      stored.lines[0].components.map((child) => ({ ...child, dirtyFields: [] })),
    );
    expect(result.lines[0]).not.toHaveProperty('clientKey');
    expect(result.lines[0]).not.toHaveProperty('lineNetAmount');
    expect(result.lines[0]).not.toHaveProperty('fineWeight');
  });
  it('edits one component without changing hidden values on its sibling or parent', () => {
    const editor = hydrateSalesOrder(stored);
    editor.rows[0]!.components[1]!.grossWt = '0.345';
    const result = salesOrderPayload(editor.f, editor.header, editor.rows, stored.version, stored);
    expect(result.lines[0].components[1]).toMatchObject({
      isrNo: 9,
      grossWt: 0.345,
      karigarNetAmount: '29.17',
    });
    expect(result.lines[0].components[0]).toEqual({
      ...stored.lines[0].components[0],
      dirtyFields: [],
    });
    expect(result.lines[0].labourAmount).toBe('77.37');
  });
  it('retains an explicit empty component collection and rejects a silently cleared saved item', () => {
    const editor = hydrateSalesOrder(stored);
    editor.rows[0]!.components = [];
    expect(
      salesOrderPayload(editor.f, editor.header, editor.rows, stored.version, stored).lines[0]
        .components,
    ).toEqual([]);
    editor.rows[0]!.itCode = '';
    expect(() =>
      salesOrderPayload(editor.f, editor.header, editor.rows, stored.version, stored),
    ).toThrow('remove its row explicitly');
  });
  it('starts a clean new header and independent row/image identity after a saved form', () => {
    const hydrated = hydrateSalesOrder(stored);
    const first = blank(18),
      second = blank(19);
    expect(first.designImageId).toBe('N');
    expect(first.clientKey).not.toBe(second.clientKey);
    expect(first.srNo).toBe('18');
    expect(blankOrderHeader()).not.toHaveProperty('billNo');
    expect(blankOrderHeader().acCode).toBe('');
    expect(hydrated.header.vchTime).toBe('12:13:14.123456');
  });
  it('validates real calendar dates and uses an explicit full request scope', () => {
    expect(validateSalesOrderDate('2024-02-29')).toBe('2024-02-29');
    for (const date of ['', '2024-02-30', '2023-02-29', '2024-13-01', '2024-07-10T00:00:00Z'])
      expect(() => validateSalesOrderDate(date)).toThrow('valid order date');
    expect(localOrderDate(new Date(2024, 6, 1, 0, 15))).toBe('2024-07-01');
    expect(
      Object.fromEntries(
        new URLSearchParams(
          salesOrderQuery({ coCode: '02', lcCode: '03', coYear: '2024-2025' }, 'S41'),
        ),
      ),
    ).toEqual({ coCode: '02', lcCode: '03', coYear: '2024-2025', coBook: 'S41' });
  });
  it('rejects invalid editable numbers while retaining the current draft', () => {
    const editor = hydrateSalesOrder(stored);
    editor.rows[0]!.components[1]!.grossWt = 'not-a-weight';
    expect(() =>
      salesOrderPayload(editor.f, editor.header, editor.rows, stored.version, stored),
    ).toThrow('grossWt must be a valid number');
    expect(editor.rows[0]!.components[1]!.grossWt).toBe('not-a-weight');
  });
  it('conveys explicit null-to-zero intent without replacing unrelated imported nulls', () => {
    const editor = hydrateSalesOrder(stored);
    editor.rows[0] = setSalesOrderCell(editor.rows[0]!, 'bagWt', '0');
    editor.rows[0]!.components[0]!.lbrAmount = '0';
    editor.rows[0]!.componentDirty['3'] = ['lbrAmount'];
    const result = salesOrderPayload(editor.f, editor.header, editor.rows, stored.version, stored, [
      'address3',
    ]);
    expect(result.dirtyFields).toEqual(['address3']);
    expect(result.lines[0]).toMatchObject({ bagWt: 0, dirtyFields: ['bagWt'] });
    expect(result.lines[0].components[0]).toMatchObject({
      lbrAmount: 0,
      dirtyFields: ['lbrAmount'],
    });
    expect(result.lines[0].components[1].karigarNetAmount).toBe('29.17');
  });
});
describe('Sales Order labour and Design selection chronology', () => {
  it('preserves imported manual amount on a basis-only edit and uses the saved preview', () => {
    const row = hydrateSalesOrder(stored).rows[0]!;
    const changed = setSalesOrderCell(row, 'labourType', 'G');
    expect(commitSalesOrderLabour(row, changed, 'labourType', policy).labourAmount).toBe('77.37');
    expect(salesOrderLineNet(changed, policy)).toBe(177.37);
  });
  it('replays actual rate-before-ghat commits and retains whole-rupee117', () => {
    let row = setSalesOrderCell(blank(1), 'itCode', 'GOLD');
    let previous = row;
    row = commitSalesOrderLabour(
      previous,
      setSalesOrderCell(row, 'netWt', '3.123'),
      'netWt',
      policy,
    );
    previous = row;
    row = commitSalesOrderLabour(
      previous,
      setSalesOrderCell(row, 'labourRate', '37.32'),
      'labourRate',
      policy,
    );
    expect(row.labourAmount).toBe('117');
    // The rate branch intentionally leaves hidden cache85 at0 until the next trigger.
    expect(row.labourCache.labourAmount).toBe(0);
    previous = row;
    row = commitSalesOrderLabour(previous, setSalesOrderCell(row, 'ghtWt', '0.1'), 'ghtWt', policy);
    expect(row.labourAmount).toBe('117');
    expect(row.labourCache.labourAmount).toBe(117);
    expect(row.labourEdits[0]!.basis.ghatWt).toBe(0);
    const result = salesOrderPayload({ ...blankOrderHeader(), acCode: 'TOURAC' }, {}, [row]);
    expect(result.lines[0].orderEdits.slice(-2)).toEqual([
      { kind: 'labour', edit: row.labourEdits[0] },
      { kind: 'field', field: 'ghtWt', value: 0.1 },
    ]);
    expect(result.lines[0]).not.toHaveProperty('labourEdits');
  });
  it('retains calculated totals across F1 until the next actual numeric blur', () => {
    let row = setSalesOrderCell(blank(1), 'itCode', 'GOLD');
    for (const [field, value] of [
      ['grossWt', '4'],
      ['netWt', '3'],
      ['pcs', '3'],
      ['touch', '90'],
      ['rate', '100'],
    ] as const)
      row = commitSalesOrderLabour(row, setSalesOrderCell(row, field, value), field, policy);
    const children = row.components;
    const before = { fine: row.fineWeight, metal: row.itemAmount, net: row.lineNetAmount };
    row = selectSalesOrderDesign(row, option, false);
    expect(row).toMatchObject({
      designNo: 'D004',
      grossWt: '4',
      touch: '92.00',
      labourRate: '12.50',
      labourAmount: '0',
      fineWeight: before.fine,
      itemAmount: before.metal,
      lineNetAmount: before.net,
    });
    expect(row.components).toBe(children);
    expect(row.labourCache).toEqual({ labourRate: 0, labourAmount: 0, labourPct: 0 });
    // Focusing and leaving the now-visible touch cell is a calculation trigger even
    // though its displayed value has not changed since F1 copied it.
    row = commitSalesOrderLabour(row, row, 'touch', policy);
    expect(row.fineWeight).not.toBe(before.fine);
    expect(row.labourAmount).toBe('38');
    expect(row.lineNetAmount).not.toBe(before.net);
    const result = salesOrderPayload({ ...blankOrderHeader(), acCode: 'TOURAC' }, {}, [row]);
    expect(result.lines[0].orderEdits.slice(-2)).toEqual([
      { kind: 'design', source: option.source },
      { kind: 'field', field: 'touch', value: 92 },
    ]);
    expect(result.lines[0]).not.toHaveProperty('labourEdits');
  });
  it('allows F1 with an unrelated invalid numeric draft without hiding it or changing the cached amount', () => {
    const original = hydrateSalesOrder(stored).rows[0]!;
    const draft = setSalesOrderCell(original, 'grossWt', 'invalid weight');
    const selected = selectSalesOrderDesign(draft, option, true);
    expect(selected.grossWt).toBe('invalid weight');
    expect(selected.lineNetAmount).toBe(original.lineNetAmount);
    expect(selected.labourCache).toEqual(original.labourCache);
    expect(() =>
      salesOrderPayload({ ...blankOrderHeader(), acCode: 'TOURAC' }, {}, [selected]),
    ).toThrow('grossWt must be a valid number');
    expect(() => commitSalesOrderLabour(original, selected, 'grossWt', policy)).toThrow(
      'grossWt must be a valid number',
    );
    expect(selected.grossWt).toBe('invalid weight');
  });
  it('retains imported cached metal on an unrelated amount trigger and reprices only after a metal-basis change', () => {
    const imported = hydrateSalesOrder(stored).rows[0]!;
    const changed = commitSalesOrderLabour(
      imported,
      setSalesOrderCell(imported, 'otherAmount', '10'),
      'otherAmount',
      policy,
    );
    expect(changed.fineWeight).toBe('0.014');
    expect(changed.itemAmount).toBe('100.00');
    expect(changed.lineNetAmount).toBe('187.37');
    const reselected = selectSalesOrderDesign(changed, option, true);
    const unrelated = commitSalesOrderLabour(reselected, reselected, 'pcs', policy);
    expect(unrelated.itemAmount).toBe('100.00');
    expect(unrelated.lineNetAmount).toBe('187.37');
    const repriced = commitSalesOrderLabour(
      unrelated,
      setSalesOrderCell(unrelated, 'touch', '92'),
      'touch',
      policy,
    );
    expect(repriced.itemAmount).not.toBe('100.00');
    expect(repriced.fineWeight).not.toBe('0.014');
  });
  it('does not manufacture a labour edit when an unchanged imported manual cell is focused and left', () => {
    const row = hydrateSalesOrder(stored).rows[0]!;
    const committed = commitSalesOrderLabour(row, row, 'labourAmount', policy);
    expect(committed).toBe(row);
    expect(committed.orderEdits).toEqual([]);
    expect(committed.labourAmount).toBe('77.37');
  });
  it('sends explicit empty Design source text while preserving unrelated unchanged nullable fields', () => {
    const document = {
      ...stored,
      lines: [
        {
          ...stored.lines[0],
          designImageId: 'OLD-SOURCE',
          itmSize: null,
          karigarName: null,
        },
      ],
    };
    const editor = hydrateSalesOrder(document);
    editor.rows[0] = selectSalesOrderDesign(
      editor.rows[0]!,
      { ...option, designImageId: null, itmSize: '', karigarName: '' },
      true,
    );
    const payload = salesOrderPayload(
      editor.f,
      editor.header,
      editor.rows,
      document.version,
      document,
    );
    const sent = JSON.parse(JSON.stringify(payload));
    expect(sent.lines[0]).toMatchObject({
      designImageId: '',
      itmSize: '',
      karigarName: '',
      bagWt: null,
    });
    expect(sent.address3).toBeNull();
    expect(sent.lines[0].orderEdits).toEqual([{ kind: 'design', source: option.source }]);
  });
  it('applies only identification fields to saved rows and distinguishes clear from cancellation', () => {
    const original = hydrateSalesOrder(stored).rows[0]!;
    const selected = selectSalesOrderDesign(original, option, true);
    expect(selected.touch).toBe(original.touch);
    expect(selected.labourRate).toBe(original.labourRate);
    const cleared = setSalesOrderCell(selected, 'designNo', '');
    expect(cleared.designImageId).toBe('N');
    expect(cleared.orderEdits.at(-1)).toEqual({ kind: 'clearDesign' });
    expect(original.orderEdits).toEqual([]);
  });
});

// N196 (G205): with the company's SL_AMT_TYPE in the policy, the preview prices the metal like TR_SALE_ORD
// (TR_SALE_ORD.cs:6571-6672): net + ghat for N, fine for F, in whole rupees. Without it (the Tour Order) the
// previous fine-weight, two-decimal preview stays.
describe('Sales Order preview on the company amount basis (N196)', () => {
  const enter = (amountType?: string) => {
    const pricing = amountType ? { ...policy, itemAmountType: amountType } : policy;
    let row = setSalesOrderCell(blank(1), 'itCode', 'GLD22');
    for (const [field, value] of [
      ['grossWt', '10.25'],
      ['netWt', '10'],
      ['pcs', '1'],
      ['touch', '91.6'],
      ['rate', '6123.45'],
      ['labourRate', '237.5'],
    ] as const)
      row = commitSalesOrderLabour(row, setSalesOrderCell(row, field, value), field, pricing);
    return row;
  };
  it('prices net 10 g at 6,123.45 as 61,234 and the line as 63,609 on SL_AMT_TYPE N', () => {
    const row = enter('N');
    expect([row.itemAmount, row.labourAmount, row.lineNetAmount]).toEqual([
      '61234',
      '2375',
      '63609',
    ]);
  });
  it('prices the fine weight 9.16 g as 56,091 on SL_AMT_TYPE F', () => {
    expect(enter('F').itemAmount).toBe('56091');
  });
  it('keeps the fine-weight two-decimal preview when no amount basis is given', () => {
    expect(enter().itemAmount).toBe('56090.8');
  });
});

// N197 (G206): the cheque and card tenders travel with the order and come back on reopen.
describe('Sales Order cheque and card tenders (N197)', () => {
  it('sends the cheque and card amounts and hydrates them', () => {
    const row = setSalesOrderCell(setSalesOrderCell(blank(1), 'itCode', 'GLD22'), 'netWt', '5');
    const payload = salesOrderPayload(
      { ...blankOrderHeader(), acCode: 'TOURAC', advanceAmount: '3000' },
      {
        chequeAmount: '2000',
        bankAc: 'BANKX',
        chequeNo: '654321',
        cardAmount: '1000',
        cardAc: 'BANKX',
      },
      [row],
    );
    expect([payload.advanceAmount, payload.chequeAmount, payload.cardAmount]).toEqual([
      3000, 2000, 1000,
    ]);
    expect([payload.bankAc, payload.chequeNo, payload.cardAc]).toEqual([
      'BANKX',
      '654321',
      'BANKX',
    ]);
    const hydrated = hydrateSalesOrder({ ...stored, chequeAmount: 2000, cardAmount: 0 });
    expect([hydrated.header.chequeAmount, hydrated.header.cardAmount]).toEqual(['2000', '']);
  });
  it('refuses a cheque amount that is not a number', () => {
    expect(() =>
      salesOrderPayload({ ...blankOrderHeader(), acCode: 'TOURAC' }, { chequeAmount: 'two' }, [
        setSalesOrderCell(blank(1), 'itCode', 'GLD22'),
      ]),
    ).toThrow('Cheque Amt must be a valid number');
  });
});
