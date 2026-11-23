import { describe, expect, it } from 'vitest';
import { formatDate, reportTitle, runLayout } from '../src/modules/reports/rpAll/engine.js';
import { parseRpAllFilters } from '../src/modules/reports/rpAll/filters.js';
import { exportTable } from '../src/modules/reports/rpAll/exportRows.js';
import type { RpAllLayout, RpAllRecord, RpAllValue } from '../src/modules/reports/rpAll/types.js';
import type { RpAllResult } from '../src/modules/reports/rpAll/index.js';

/**
 * WP-14: the Order Report branch of RP_ALL as pure logic. The web adapter does not exist yet, so these
 * tests exercise the shared engine and filters with the record shapes the desktop templates read.
 *
 * Every expected value is computed from the fixture orders and adjustments with the desktop formula
 * (OrdDetlRpt.xml, OrdAdvRpt.xml, OrdAdvAdj.xml, OrdAdjBillWise.xml, OrdDetlPanding.xml,
 * OrdDesignSumm.xml, BillWiseOrderAdjust.xml), never read back from a web implementation.
 */

const SESSION = { tenantId: 't', coCode: '01', lcCode: '01', coYear: '2025-2026' };
const FROM_DATE = '2026-01-01';
const TO_DATE = '2026-01-31';
const Q = { fromDate: FROM_DATE, toDate: TO_DATE };

const ord = (over: Partial<RpAllRecord> = {}): RpAllRecord => ({
  tenantId: 't',
  coCode: '01',
  lcCode: '01',
  coYear: '2025-2026',
  coBook: 'B1',
  vchNo: 'O1',
  vchDate: '2026-01-05',
  acCode: 'P1',
  acName: 'ALPHA JEWELS',
  totAmt: 20000,
  advAmt: 5000,
  cashAmt: 5000,
  cardAmt: 0,
  chqAmt: 0,
  oldGlAmt: 0,
  oldSlAmt: 0,
  itCode: 'I1',
  itName: 'Gold Ring',
  designNo: 'D1',
  tagNo: 'T1',
  pcs: 1,
  nwt: 10.5,
  designIsu: 'N',
  ...over,
});

const lineKey = (r: RpAllRecord) => `${r.coBook}|${r.vchNo}|${r.srNo}`;

const ORDER_LINES: RpAllRecord[] = [
  ord({
    srNo: 1,
    pcs: 1,
    nwt: 10.5,
    itCode: 'I1',
    itName: 'Gold Ring',
    designNo: 'D1',
    tagNo: 'T1',
  }),
  ord({
    srNo: 2,
    pcs: 2,
    nwt: 5.25,
    itCode: 'I2',
    itName: 'Gold Chain',
    designNo: 'D2',
    tagNo: 'T2',
  }),
  ord({
    coBook: 'B2',
    vchNo: 'O2',
    vchDate: '2026-01-10',
    acCode: 'P2',
    acName: 'BETA TRADERS',
    totAmt: 9000,
    advAmt: 0,
    cashAmt: 0,
    srNo: 1,
    pcs: 3,
    nwt: 7.125,
    itCode: 'I1',
    itName: 'Gold Ring',
    designNo: 'D1',
    tagNo: 'T3',
  }),
  ord({
    coBook: 'B1',
    vchNo: 'O3',
    vchDate: '2026-01-15',
    acCode: 'P1',
    acName: 'ALPHA JEWELS',
    totAmt: 9000,
    advAmt: 3000,
    cashAmt: 0,
    srNo: 1,
    pcs: 1,
    nwt: 4.0,
    itCode: 'I2',
    itName: 'Gold Chain',
    designNo: 'D3',
    tagNo: 'T4',
  }),
  ord({
    coBook: 'B1',
    vchNo: 'O4',
    vchDate: '2026-01-12',
    acCode: '',
    acName: 'WALK IN CUSTOMER',
    totAmt: 0,
    advAmt: 0,
    cashAmt: 0,
    srNo: 1,
    pcs: 1,
    nwt: 2.0,
    itCode: 'I1',
    itName: 'Gold Ring',
    designNo: 'D4',
    tagNo: 'T5',
  }),
  ord({
    coBook: 'B1',
    vchNo: 'O8',
    vchDate: '2026-01-20',
    acCode: 'P2',
    acName: 'BETA TRADERS',
    totAmt: 0,
    advAmt: 0,
    cashAmt: 0,
    srNo: 1,
    pcs: 1,
    nwt: 3.0,
    itCode: 'I2',
    itName: 'Gold Chain',
    designNo: 'D5',
    tagNo: 'T6',
    designIsu: 'Y',
  }),
];

const ORDER_HEADERS: RpAllRecord[] = [
  {
    coBook: 'B1',
    vchNo: 'O1',
    vchDate: '2026-01-05',
    acCode: 'P1',
    acName: 'ALPHA JEWELS',
    totAmt: 20000,
    cashAmt: 5000,
    cardAmt: 0,
    chqAmt: 0,
    oldGlAmt: 0,
    oldSlAmt: 0,
    advAmt: 5000,
  },
  {
    coBook: 'B2',
    vchNo: 'O2',
    vchDate: '2026-01-10',
    acCode: 'P2',
    acName: 'BETA TRADERS',
    totAmt: 9000,
    cashAmt: 0,
    cardAmt: 0,
    chqAmt: 0,
    oldGlAmt: 0,
    oldSlAmt: 0,
    advAmt: 0,
  },
  {
    coBook: 'B1',
    vchNo: 'O3',
    vchDate: '2026-01-15',
    acCode: 'P1',
    acName: 'ALPHA JEWELS',
    totAmt: 9000,
    cashAmt: 0,
    cardAmt: 0,
    chqAmt: 0,
    oldGlAmt: 0,
    oldSlAmt: 0,
    advAmt: 3000,
  },
  {
    coBook: 'B1',
    vchNo: 'O4',
    vchDate: '2026-01-12',
    acCode: '',
    acName: 'WALK IN CUSTOMER',
    totAmt: 0,
    cashAmt: 0,
    cardAmt: 0,
    chqAmt: 0,
    oldGlAmt: 0,
    oldSlAmt: 0,
    advAmt: 0,
  },
  {
    coBook: 'B1',
    vchNo: 'O8',
    vchDate: '2026-01-20',
    acCode: 'P2',
    acName: 'BETA TRADERS',
    totAmt: 0,
    cashAmt: 0,
    cardAmt: 0,
    chqAmt: 0,
    oldGlAmt: 0,
    oldSlAmt: 0,
    advAmt: 0,
  },
];

const adjustments: RpAllRecord[] = [
  {
    coBook: 'B1',
    vchNo: 'O1',
    adjSr: 1,
    ordSign: '+',
    ordAmt: 5000,
    ordLc: '01',
    ordYrcd: '2025-2026',
    ordDbcd: 'B1',
    ordNo: 'O1',
    acName: 'ALPHA JEWELS',
    vchDate: '2026-01-05',
  },
  {
    coBook: 'B1',
    vchNo: 'O1',
    adjSr: 2,
    ordSign: '-',
    ordAmt: 1500,
    ordLc: '01',
    ordYrcd: '2025-2026',
    ordDbcd: 'B1',
    ordNo: 'O1',
    acName: 'ALPHA JEWELS',
    vchDate: '2026-01-18',
    billBook: 'SB',
    billNo: 'S1',
    billTotAmt: 12000,
    billAcName: 'ALPHA JEWELS',
  },
  {
    coBook: 'B1',
    vchNo: 'O1',
    adjSr: 3,
    ordSign: '-',
    ordAmt: 500,
    ordLc: '01',
    ordYrcd: '2025-2026',
    ordDbcd: 'B1',
    ordNo: 'O1',
    acName: 'ALPHA JEWELS',
    vchDate: '2026-01-18',
    billBook: 'SB',
    billNo: 'S1',
    billTotAmt: 12000,
    billAcName: 'ALPHA JEWELS',
  },
  {
    coBook: 'B1',
    vchNo: 'O3',
    adjSr: 1,
    ordSign: '+',
    ordAmt: 3000,
    ordLc: '01',
    ordYrcd: '2025-2026',
    ordDbcd: 'B1',
    ordNo: 'O3',
    acName: 'ALPHA JEWELS',
    vchDate: '2026-01-15',
  },
  {
    coBook: 'B1',
    vchNo: 'O3',
    adjSr: 2,
    ordSign: '-',
    ordAmt: 1500,
    ordLc: '01',
    ordYrcd: '2025-2026',
    ordDbcd: 'B1',
    ordNo: 'O3',
    acName: 'ALPHA JEWELS',
    vchDate: '2026-01-22',
    billBook: 'SB',
    billNo: 'S2',
    billTotAmt: 9000,
    billAcName: 'ALPHA JEWELS',
  },
  {
    coBook: 'B1',
    vchNo: 'O3',
    adjSr: 3,
    ordSign: '-',
    ordAmt: 1500,
    ordLc: '01',
    ordYrcd: '2025-2026',
    ordDbcd: 'B1',
    ordNo: 'O3',
    acName: 'ALPHA JEWELS',
    vchDate: '2026-01-22',
    billBook: 'SB',
    billNo: 'S2',
    billTotAmt: 9000,
    billAcName: 'ALPHA JEWELS',
  },
];

const sum = (xs: RpAllRecord[], f: (x: RpAllRecord) => number, dp = 3) =>
  Number(xs.reduce((s, x) => s + f(x), 0).toFixed(dp));

const col = (key: string, caption: string, kind: any, level: any, total = false) => ({
  key,
  caption,
  kind,
  level,
  total,
});

describe('Order Report (BtnOrdRpt → OrdDetlRpt)', () => {
  const layout: RpAllLayout = {
    template: 'OrdDetlRpt',
    titlePrefix: 'Order Report',
    columns: [
      col('acName', 'Customer', 'text', 'voucher'),
      col('vchNo', 'Vch No', 'text', 'voucher'),
      col('vchDate', 'Date', 'date', 'voucher'),
      col('srNo', 'Sr', 'text', 'line'),
      col('itName', 'Item', 'text', 'line'),
      col('designNo', 'Design', 'text', 'line'),
      col('pcs', 'Pcs', 'pcs', 'line', true),
      col('nwt', 'Net Wt', 'weight', 'line', true),
    ],
    groups: [{ key: 'vchNo', labelKeys: ['vchNo'], subtotal: 'none' }],
    sort: [{ key: 'acName' }],
    keys: { voucher: ['coBook', 'vchNo'], line: ['srNo'] },
    rowLevels: ['line'],
    grandTotal: true,
  };
  const result = runLayout(layout, ORDER_LINES);

  it('lists every order line in the date range with no status filter (D3)', () => {
    expect(result.rows).toHaveLength(ORDER_LINES.length);
    expect(result.rows.map((r) => `${r.voucherKey}|${r.cells.srNo}`)).toEqual(
      ORDER_LINES.map(lineKey),
    );
  });

  it('totals pieces and net weight from the vouchers (OrdDetlRpt.xml:309-310)', () => {
    // RP_ALL.cs:10927 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  = 0}}
    // is the pending-set rule, not this mode; mode 1 simply sums every line.
    expect(result.totals.pcs).toBe(sum(ORDER_LINES, (r) => Number(r.pcs), 0));
    expect(result.totals.nwt).toBe(sum(ORDER_LINES, (r) => Number(r.nwt)));
    expect(result.totals.pcs).toBe(9);
    expect(result.totals.nwt).toBe(31.875);
  });
});

describe('Order Advance (BtnOrdAdvance → OrdAdvRpt)', () => {
  const layout: RpAllLayout = {
    template: 'OrdAdvRpt',
    titlePrefix: 'Order Advance Report',
    columns: [
      col('acName', 'Customer', 'text', 'voucher'),
      col('vchNo', 'Vch No', 'text', 'voucher'),
      col('vchDate', 'Date', 'date', 'voucher'),
      col('totAmt', 'Order Total', 'money', 'voucher'),
      col('cashAmt', 'Cash', 'money', 'voucher'),
      col('cardAmt', 'Card', 'money', 'voucher'),
      col('chqAmt', 'Cheque', 'money', 'voucher'),
      col('oldGlAmt', 'Old Gold', 'money', 'voucher'),
      col('oldSlAmt', 'Old Silver', 'money', 'voucher'),
      col('advAmt', 'Advance', 'money', 'voucher'),
    ],
    groups: [{ key: 'acName', labelKeys: ['acName'], subtotal: 'none' }],
    sort: [{ key: 'acName' }],
    keys: { voucher: ['coBook', 'vchNo'] },
    rowLevels: ['voucher'],
    grandTotal: false,
  };
  const result = runLayout(layout, ORDER_HEADERS);

  it('prints one row per order header, grouped by customer name ascending', () => {
    expect(result.rows).toHaveLength(ORDER_HEADERS.length);
    expect(result.rows.map((r) => r.cells.vchNo)).toEqual(['O1', 'O3', 'O2', 'O8', 'O4']);
  });

  it('keeps every tender column from SL_ORD_DATA and prints no grand total (OrdAdvRpt.xml has no SummaryFieldDefinition)', () => {
    const o1 = result.rows.find((r) => r.cells.vchNo === 'O1')!;
    expect(o1.cells.totAmt).toBe(20000);
    expect(o1.cells.cashAmt).toBe(5000);
    expect(o1.cells.advAmt).toBe(5000);
    expect(Object.keys(result.totals)).toHaveLength(0);
    expect(layout.grandTotal).toBe(false);
  });
});

describe('Order Adjust (BtnOrdAdj → OrdAdvAdj)', () => {
  const withDerived = adjustments.map((r) => {
    const ordAmt = Number(r.ordAmt);
    const isPlus = r.ordSign === '+';
    return {
      ...r,
      ordGroup: `${r.ordLc}${r.ordYrcd}${r.ordDbcd}${r.ordNo}`,
      ordAmtVal: ordAmt,
      plusAmt: isPlus ? ordAmt : 0,
      minusAmt: isPlus ? 0 : ordAmt,
      balAmt: isPlus ? ordAmt : -ordAmt,
    };
  });
  const layout: RpAllLayout = {
    template: 'OrdAdvAdj',
    titlePrefix: 'Order Adjust Report',
    columns: [
      col('vchNo', 'Vch No', 'text', 'line'),
      col('vchDate', 'Date', 'date', 'line'),
      col('acName', 'Customer', 'text', 'line'),
      col('ordSign', 'Sign', 'text', 'line'),
      col('ordAmt', 'Amount', 'money', 'line'),
      col('plusAmt', 'Ord Amt', 'money', 'line', true),
      col('minusAmt', 'Ord Adj Amt', 'money', 'line', true),
      col('balAmt', 'Bal Amt', 'money', 'line', true),
    ],
    groups: [
      { key: 'ordGroup', labelKeys: ['ordGroup'], subtotal: 'footer', subtotalCaption: 'Total' },
    ],
    sort: [{ key: 'coYear' }, { key: 'vchDate' }, { key: 'vchNo' }],
    keys: { voucher: ['coBook', 'vchNo'], line: ['adjSr'] },
    rowLevels: ['line'],
    grandTotal: true,
  };
  const result = runLayout(layout, withDerived);

  it('groups by @OrdGroup = ORD_LC+ORD_YRCD+ORD_DBCD+ORD_NO (OrdAdvAdj.xml:252-253)', () => {
    const groups = result.groups.filter((g) => g.depth === 0);
    expect(groups.map((g) => g.key).sort()).toEqual(['012025-2026B1O1', '012025-2026B1O3']);
  });

  it('computes signed amounts as the desktop balance rule does (RP_ALL.cs:10927)', () => {
    const o1 = result.groups.find((g) => g.key === '012025-2026B1O1')!;
    const o3 = result.groups.find((g) => g.key === '012025-2026B1O3')!;
    expect(o1.totals.plusAmt).toBe(5000);
    expect(o1.totals.minusAmt).toBe(2000);
    expect(o1.totals.balAmt).toBe(3000);
    expect(o3.totals.plusAmt).toBe(3000);
    expect(o3.totals.minusAmt).toBe(3000);
    expect(o3.totals.balAmt).toBe(0);
    expect(result.totals.plusAmt).toBe(8000);
    expect(result.totals.minusAmt).toBe(5000);
    expect(result.totals.balAmt).toBe(3000);
  });
});

describe('Order Wise Bill (BtnOrdWithBill → OrdAdjBillWise)', () => {
  const withDerived = adjustments.map((r) => ({
    ...r,
    adjAmt: r.ordSign === '-' ? Number(r.ordAmt) : 0,
  }));
  const layout: RpAllLayout = {
    template: 'OrdAdjBillWise',
    titlePrefix: 'Bill Wise Order Adjust Report',
    columns: [
      col('acName', 'Customer', 'text', 'line'),
      col('vchNo', 'Order Vch', 'text', 'line'),
      col('ordSign', 'Sign', 'text', 'line'),
      col('ordAmt', 'Ord Amt', 'money', 'line'),
      col('billNo', 'Bill No', 'text', 'line'),
      col('billTotAmt', 'Bill Total', 'money', 'line'),
      col('adjAmt', 'Adj Amt', 'money', 'line', true),
    ],
    groups: [
      { key: 'acName', labelKeys: ['acName'], subtotal: 'none' },
      { key: 'vchNo', labelKeys: ['vchNo'], subtotal: 'footer', subtotalCaption: 'Total' },
    ],
    sort: [{ key: 'acCode' }],
    keys: { voucher: ['coBook', 'vchNo'], line: ['adjSr'] },
    rowLevels: ['line'],
    grandTotal: false,
  };
  // Pad O2/O4/O8 with one empty adjustment row each, as the left join would.
  const padded: RpAllRecord[] = [
    ...withDerived,
    {
      coBook: 'B2',
      vchNo: 'O2',
      adjSr: 1,
      ordSign: '',
      ordAmt: 0,
      adjAmt: 0,
      billNo: '',
      billTotAmt: 0,
      acName: 'BETA TRADERS',
    },
    {
      coBook: 'B1',
      vchNo: 'O4',
      adjSr: 1,
      ordSign: '',
      ordAmt: 0,
      adjAmt: 0,
      billNo: '',
      billTotAmt: 0,
      acName: 'WALK IN CUSTOMER',
    },
    {
      coBook: 'B1',
      vchNo: 'O8',
      adjSr: 1,
      ordSign: '',
      ordAmt: 0,
      adjAmt: 0,
      billNo: '',
      billTotAmt: 0,
      acName: 'BETA TRADERS',
    },
  ];
  const result = runLayout(layout, padded);

  it('totals only the minus rows per order (OrdAdjBillWise.xml:419)', () => {
    const totals = new Map(
      result.groups.filter((g) => g.depth === 1).map((g) => [g.key, g.totals.adjAmt]),
    );
    expect(totals.get('O1')).toBe(2000);
    expect(totals.get('O3')).toBe(3000);
    expect(totals.get('O2')).toBe(0);
    expect(totals.get('O4')).toBe(0);
    expect(totals.get('O8')).toBe(0);
  });

  it('prints no grand total across orders', () => {
    expect(layout.grandTotal).toBe(false);
  });
});

describe('Making Panding (BtnOrdMakePan → OrdDetlPanding)', () => {
  // The desktop pending set is derived, never written here (D2):
  //   DESIGN_ISU = 'N' AND the order is NOT in the fully-adjusted set
  //   (RP_ALL.cs:10940 {{AND {SL_ORD_DETL.DESIGN_ISU} = 'N'}};
  //    RP_ALL.cs:10927 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  = 0}}).
  const fullyAdjusted = new Set(['O3', 'O5']);
  const pending = ORDER_LINES.filter(
    (r) => r.designIsu === 'N' && !fullyAdjusted.has(String(r.vchNo)),
  );
  const layout: RpAllLayout = {
    template: 'OrdDetlPanding',
    titlePrefix: 'Order Design Issue Panding Report',
    columns: [
      col('vchNo', 'Vch No', 'text', 'line'),
      col('acName', 'Customer', 'text', 'line'),
      col('pcs', 'Pcs', 'pcs', 'line', true),
      col('nwt', 'Net Wt', 'weight', 'line', true),
    ],
    groups: [{ key: 'vchGroup', labelKeys: ['vchGroup'], subtotal: 'none' }],
    sort: [{ key: 'acName' }],
    keys: { voucher: ['coBook', 'vchNo'], line: ['srNo'] },
    rowLevels: ['line'],
    grandTotal: true,
  };
  const records: RpAllRecord[] = pending.map((r) => ({
    ...r,
    vchGroup: `${r.coYear}${r.coBook}${r.vchNo}` as RpAllValue,
  }));
  const result = runLayout(layout, records);

  it('excludes fully-adjusted orders and lines already flagged Y', () => {
    expect(result.rows.map((r) => r.cells.vchNo)).toEqual(['O1', 'O1', 'O4', 'O2']);
  });

  it('grand-totals the same pcs and nwt as the detail band (OrdDetlPanding.xml:403-404)', () => {
    expect(result.totals.pcs).toBe(7);
    expect(result.totals.nwt).toBe(24.875);
  });
});

describe('Making Summ (BtnDesignSumm → OrdDesignSumm)', () => {
  const fullyAdjusted = new Set(['O3', 'O5']);
  const pending = ORDER_LINES.filter(
    (r) => r.designIsu === 'N' && !fullyAdjusted.has(String(r.vchNo)),
  );
  const layout = (onlySumm: boolean): RpAllLayout => ({
    template: 'OrdDesignSumm',
    titlePrefix: 'Order Design Issue Panding Report',
    columns: [
      col('design', 'Design', 'text', 'line'),
      col('vchNo', 'Vch No', 'text', 'line'),
      col('pcs', 'Pcs', 'pcs', 'line', true),
      col('nwt', 'Net Wt', 'weight', 'line', true),
    ],
    groups: [{ key: 'vchGroup', labelKeys: ['vchGroup'], subtotal: 'none' }],
    sort: [{ key: 'acName' }],
    keys: { voucher: ['coBook', 'vchNo'], line: ['srNo'] },
    rowLevels: ['line'],
    grandTotal: true,
    suppress: { line: (r: RpAllRecord) => onlySumm },
  });
  const designOf = (r: RpAllRecord): RpAllValue =>
    (r.designNo === '' ? r.tagNo : r.designNo) as RpAllValue;
  const records: RpAllRecord[] = pending.map((r) => ({
    ...r,
    design: designOf(r),
    vchGroup: `${r.tagNo}${r.designNo}` as RpAllValue,
  }));

  it('groups by tag+design and keeps totals unchanged when OnlySumm=Y (OrdDesignSumm.xml:685)', () => {
    const no = runLayout(layout(false), records);
    const yes = runLayout(layout(true), records);
    expect(no.rows.length).toBeGreaterThan(0);
    expect(yes.rows).toHaveLength(0);
    expect(yes.totals.pcs).toBe(no.totals.pcs);
    expect(yes.totals.nwt).toBe(no.totals.nwt);
  });
});

describe('Bill Wise Adjust (BtnBillWiseOrdAdj → BillWiseOrderAdjust)', () => {
  const bills: RpAllRecord[] = [
    {
      coBook: 'SB',
      vchNo: 'S1',
      vchDate: '2026-01-18',
      billAcCode: 'P1',
      billAcName: 'ALPHA JEWELS',
      billTotAmt: 12000,
    },
    {
      coBook: 'SB',
      vchNo: 'S2',
      vchDate: '2026-01-22',
      billAcCode: 'P1',
      billAcName: 'ALPHA JEWELS',
      billTotAmt: 9000,
    },
  ];
  const billRows: RpAllRecord[] = [];
  for (const bill of bills) {
    const children = adjustments.filter((a) => a.billNo === bill.vchNo);
    for (const a of children) {
      billRows.push({
        ...a,
        coBook: bill.coBook as RpAllValue,
        vchNo: bill.vchNo as RpAllValue,
        vchDate: bill.vchDate as RpAllValue,
        billAcCode: bill.billAcCode as RpAllValue,
        billAcName: bill.billAcName as RpAllValue,
        billTotAmt: bill.billTotAmt as RpAllValue,
        billVchGroup: `${a.coCode}${a.lcCode}${a.coYear}${bill.coBook}${bill.vchNo}` as RpAllValue,
        adjAmt: Number(a.ordAmt),
      });
    }
  }
  const layout: RpAllLayout = {
    template: 'BillWiseOrderAdjust',
    titlePrefix: 'Bill Wise Order Adjust Report',
    columns: [
      col('billAcName', 'Party', 'text', 'line'),
      col('coBook', 'Book', 'text', 'line'),
      col('vchNo', 'Bill No', 'text', 'line'),
      col('vchDate', 'Date', 'date', 'line'),
      col('billTotAmt', 'Bill Total', 'money', 'line'),
      col('ordNo', 'Order No', 'text', 'line'),
      col('adjAmt', 'Adjusted Amt', 'money', 'line'),
    ],
    groups: [
      { key: 'billAcCode', labelKeys: ['billAcName'], subtotal: 'none' },
      { key: 'billVchGroup', labelKeys: ['vchNo'], subtotal: 'none' },
    ],
    sort: [{ key: 'vchNo' }],
    keys: { voucher: ['coBook', 'vchNo'], line: ['adjSr'] },
    rowLevels: ['line'],
    grandTotal: false,
  };
  const result = runLayout(layout, billRows);

  it('bases rows on the sale bill and prints the raw adjustment amount (BillWiseOrderAdjust.xml:378-379)', () => {
    expect(result.rows).toHaveLength(4);
    const s1 = result.rows.filter((r) => r.cells.vchNo === 'S1');
    expect(s1.map((r) => r.cells.adjAmt)).toEqual([1500, 500]);
  });

  it('has no summary band (BillWiseOrderAdjust.xml:398)', () => {
    expect(layout.grandTotal).toBe(false);
  });
});

describe('RP_ALL Order Report titles', () => {
  it('formats the seven fixed title prefixes with dd/MM/yyyy dates', () => {
    // RP_ALL.cs:8416 {{DC_Main.MsRptTitelStr = "'Order Report From "}}
    expect(reportTitle('Order Report', '2026-01-01', '2026-01-31')).toBe(
      'Order Report From 01/01/2026 To 31/01/2026',
    );
    // RP_ALL.cs:8482 {{DC_Main.MsRptTitelStr = "'Order Advance Report From "}}
    expect(reportTitle('Order Advance Report', '2026-01-01', '2026-01-31')).toBe(
      'Order Advance Report From 01/01/2026 To 31/01/2026',
    );
    // RP_ALL.cs:8548 {{DC_Main.MsRptTitelStr = "'Order Adjust Report From "}}
    expect(reportTitle('Order Adjust Report', '2026-01-01', '2026-01-31')).toBe(
      'Order Adjust Report From 01/01/2026 To 31/01/2026',
    );
    // RP_ALL.cs:9774 {{DC_Main.MsRptTitelStr = "'Bill Wise Order Adjust Report From "}}
    // RP_ALL.cs:12644 {{DC_Main.MsRptTitelStr = "'Bill Wise Order Adjust Report From "}}
    expect(reportTitle('Bill Wise Order Adjust Report', '2026-01-01', '2026-01-31')).toBe(
      'Bill Wise Order Adjust Report From 01/01/2026 To 31/01/2026',
    );
    // RP_ALL.cs:10976 {{DC_Main.MsRptTitelStr = "'Order Design Issue Panding Report From "}}
    // RP_ALL.cs:11887 {{DC_Main.MsRptTitelStr = "'Order Design Issue Panding Report From "}}
    expect(reportTitle('Order Design Issue Panding Report', '2026-01-01', '2026-01-31')).toBe(
      'Order Design Issue Panding Report From 01/01/2026 To 31/01/2026',
    );
  });
});

describe('Shared selectors for the Order branch', () => {
  it('accepts From after To (the desktop prints an empty report)', () => {
    const f = parseRpAllFilters({ fromDate: '2026-01-31', toDate: '2026-01-01' }, SESSION);
    expect(f.fromDate).toBe('2026-01-31');
    expect(f.toDate).toBe('2026-01-01');
  });

  it('rejects an impossible date, matching the web guard added in D10', () => {
    expect(() =>
      parseRpAllFilters({ fromDate: '2026-02-30', toDate: '2026-01-31' }, SESSION),
    ).toThrow(/fromDate/);
  });

  it('locks location to the session unless the session is head office 00', () => {
    expect(parseRpAllFilters(Q, SESSION).lcCode).toBe('01');
    expect(() => parseRpAllFilters({ ...Q, lcCode: '02' }, SESSION)).toThrow(/fixed/);
    const ho = { ...SESSION, lcCode: '00' };
    expect(parseRpAllFilters(Q, ho).lcCode).toBe('00');
    expect(parseRpAllFilters({ ...Q, lcCode: '' }, ho).lcCode).toBeNull();
  });

  it('ignores Pr Code, Gr Code and Item Type for Order handlers, exactly as the desktop does (D4, D8)', () => {
    const f = parseRpAllFilters({ ...Q, prCode: 'I1', grCode: 'G1', itemType: 'Gold' }, SESSION);
    expect(f.prCode).toBe('I1');
    expect(f.grCode).toBe('G1');
    expect(f.itemType).toBe('G');
    // These selectors exist in the shared parser but an Order adapter must not apply them.
  });
});

describe('Export rows are built from the same result as the grid', () => {
  const layout: RpAllLayout = {
    template: 'OrdDetlRpt',
    titlePrefix: 'Order Report',
    columns: [col('vchNo', 'Vch No', 'text', 'line'), col('pcs', 'Pcs', 'pcs', 'line', true)],
    groups: [],
    sort: [{ key: 'vchNo' }],
    keys: { voucher: ['coBook', 'vchNo'], line: ['srNo'] },
    rowLevels: ['line'],
    grandTotal: true,
  };
  const engineResult = runLayout(layout, ORDER_LINES);
  const result: RpAllResult = {
    branch: 'order' as any,
    mode: 'report' as any,
    caption: 'Order Report',
    variant: 'sale',
    template: layout.template,
    title: reportTitle(layout.titlePrefix, FROM_DATE, TO_DATE),
    columns: [...layout.columns],
    groups: engineResult.groups,
    groupLevels: [],
    rows: engineResult.rows,
    totals: engineResult.totals,
    grandTotal: layout.grandTotal,
    grandTotalCaption: 'Total',
    voucherCount: engineResult.voucherCount,
    filters: { fromDate: FROM_DATE, toDate: TO_DATE, lcCode: '01' },
    ignoredFilters: [],
    cite: '',
  };
  const table = exportTable(result);

  it('includes every detail row and a grand total line', () => {
    expect(table.lines).toHaveLength(ORDER_LINES.length + 1);
    expect(table.lines[table.lines.length - 1]!._band).toBe('Total');
  });
});
