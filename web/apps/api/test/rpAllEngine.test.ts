import { describe, expect, it } from 'vitest';
import {
  compareValues,
  countOnceTotals,
  formatCell,
  formatDate,
  reportTitle,
  runLayout,
  sortRecords,
} from '../src/modules/reports/rpAll/engine.js';
import type { RpAllLayout, RpAllRecord } from '../src/modules/reports/rpAll/types.js';

/**
 * WP-11: the pure RP_ALL engine — sort, group bands, count-once totals, band suppression and formatting.
 * Every expected number is added up by hand from the fixture vouchers below, never read back from the engine.
 */

// Two vouchers on one day and one on the next. Voucher A has two lines, line A1 has two sub-lines; so the
// joined record set has 4 records for A (A1×2 subs, A2×1 with no sub), 1 for B and 1 for C.
const A = {
  lcCode: '01',
  coBook: 'SL',
  vchNo: '0002',
  vchDate: '2026-04-05',
  netAmt: 1000.1,
  totAmt: 1030.4,
};
const B = {
  lcCode: '01',
  coBook: 'SL',
  vchNo: '0001',
  vchDate: '2026-04-05',
  netAmt: 500.25,
  totAmt: 515.26,
};
const C = {
  lcCode: '01',
  coBook: 'SX',
  vchNo: '0001',
  vchDate: '2026-04-06',
  netAmt: 200,
  totAmt: 206,
};
const records: RpAllRecord[] = [
  { ...A, srNo: 1, nwt: 5.125, subSrNo: 1, subAmt: 10, oth: 30 },
  { ...A, srNo: 1, nwt: 5.125, subSrNo: 2, subAmt: 20, oth: 30 },
  { ...A, srNo: 2, nwt: 2.5, subSrNo: null, subAmt: null, oth: 0 },
  { ...B, srNo: 1, nwt: 1.001, subSrNo: null, subAmt: null, oth: 0 },
  { ...C, srNo: 1, nwt: 0.874, subSrNo: null, subAmt: null, oth: 0 },
];

const layout: RpAllLayout = {
  template: 'Fixture',
  titlePrefix: 'Fixture Report',
  groups: [
    { key: 'vchDate', labelKeys: ['vchDate'], subtotal: 'footer', subtotalCaption: 'DATE TOTAL :' },
  ],
  sort: [{ key: 'vchNo' }, { key: 'srNo' }, { key: 'coBook' }],
  keys: { voucher: ['lcCode', 'coBook', 'vchNo'], line: ['srNo'], sub: ['subSrNo'] },
  rowLevels: ['voucher', 'line', 'sub'],
  columns: [
    { key: 'vchNo', caption: 'BIL_NO', kind: 'text', level: 'voucher' },
    { key: 'vchDate', caption: 'BIL_DATE', kind: 'date', level: 'voucher' },
    { key: 'netAmt', caption: 'Net AMT', kind: 'money', level: 'voucher', total: true },
    { key: 'totAmt', caption: 'TOT_AMT', kind: 'money', level: 'voucher', total: true },
    { key: 'nwt', caption: 'Net Wt', kind: 'weight', level: 'line', total: true },
    { key: 'subAmt', caption: 'Sub', kind: 'money', level: 'sub', total: true },
  ],
  grandTotal: true,
  grandTotalCaption: 'GRAND TOTAL :',
  suppress: { sub: (r) => r.oth === 0 },
};

describe('RP_ALL engine — count-once totals', () => {
  it('counts a header value once per voucher, a line value once per line, a sub value once per sub-line', () => {
    const totals = countOnceTotals(layout, records);
    // Hand sums: Net = 1000.10 + 500.25 + 200 ; Tot = 1030.40 + 515.26 + 206
    expect(totals.netAmt).toBe(1700.35);
    expect(totals.totAmt).toBe(1751.66);
    // Net Wt = A1 5.125 + A2 2.5 + B1 1.001 + C1 0.874 (A1 appears on two records but is one line)
    expect(totals.nwt).toBe(9.5);
    // Sub = 10 + 20 (records without a sub-line add nothing)
    expect(totals.subAmt).toBe(30);
  });

  it('differs from a literal per-record Crystal Sum, which repeats header values per joined record', () => {
    const literal = records.reduce((s, r) => s + Number(r.netAmt), 0);
    // A is joined 3 times: 3 × 1000.10 + 500.25 + 200
    expect(Math.abs(literal - 3700.55)).toBeLessThan(1e-9);
    expect(countOnceTotals(layout, records).netAmt).not.toBe(literal);
  });

  it('rounds money to 2 and weight to 3 decimals without float drift', () => {
    const many: RpAllRecord[] = Array.from({ length: 10 }, (_, i) => ({
      lcCode: '01',
      coBook: 'SL',
      vchNo: String(i),
      vchDate: '2026-04-05',
      netAmt: 0.1,
      totAmt: 0.2,
      srNo: 1,
      nwt: 0.001,
      subSrNo: null,
      subAmt: null,
      oth: 0,
    }));
    const t = countOnceTotals(layout, many);
    expect(t.netAmt).toBe(1);
    expect(t.totAmt).toBe(2);
    expect(t.nwt).toBe(0.01);
  });
});

describe('RP_ALL engine — order, bands and rows', () => {
  it('sorts by group keys then record sort keys, nulls first, numbers numerically', () => {
    expect(compareValues(null, 'a')).toBeLessThan(0);
    expect(compareValues(2, 10)).toBeLessThan(0);
    expect(compareValues('10', '2')).toBeLessThan(0); // text compares by code point, as VCH_NO text does
    const order = sortRecords(layout, records).map(
      (r) => `${r.vchDate}/${r.vchNo}/${r.srNo}/${r.subSrNo}`,
    );
    expect(order).toEqual([
      '2026-04-05/0001/1/null',
      '2026-04-05/0002/1/1',
      '2026-04-05/0002/1/2',
      '2026-04-05/0002/2/null',
      '2026-04-06/0001/1/null',
    ]);
  });

  it('emits a voucher row before its lines and a line before its printed sub-lines', () => {
    const result = runLayout(layout, records);
    expect(result.rows.map((r) => `${r.level}:${r.voucherKey}`)).toEqual([
      'voucher:01|SL|0001',
      'line:01|SL|0001',
      'voucher:01|SL|0002',
      'line:01|SL|0002',
      'sub:01|SL|0002',
      'sub:01|SL|0002',
      'line:01|SL|0002',
      'voucher:01|SX|0001',
      'line:01|SX|0001',
    ]);
    expect(result.voucherCount).toBe(3);
    // A row carries only its own level's cells.
    expect(Object.keys(result.rows[0]!.cells).sort()).toEqual([
      'netAmt',
      'totAmt',
      'vchDate',
      'vchNo',
    ]);
    expect(result.rows[1]!.cells).toEqual({ nwt: 1.001 });
  });

  it('a suppressed band hides rows but never changes a total', () => {
    const hidden = runLayout({ ...layout, suppress: { sub: () => true } }, records);
    expect(hidden.rows.filter((r) => r.level === 'sub')).toHaveLength(0);
    expect(hidden.totals.subAmt).toBe(30);
  });

  it('closes each group band with its own count-once subtotal', () => {
    const result = runLayout(layout, records);
    expect(result.groups.map((g) => [g.label, g.totals])).toEqual([
      ['05/04/2026', { netAmt: 1500.35, totAmt: 1545.66, nwt: 8.626, subAmt: 30 }],
      ['06/04/2026', { netAmt: 200, totAmt: 206, nwt: 0.874, subAmt: 0 }],
    ]);
    expect(result.totals).toEqual({ netAmt: 1700.35, totAmt: 1751.66, nwt: 9.5, subAmt: 30 });
  });

  it('nests two group levels and maps a group label (Crystal @ItemType)', () => {
    const two: RpAllLayout = {
      ...layout,
      groups: [
        {
          key: 'it',
          labelKeys: ['it'],
          subtotal: 'header',
          labelMap: { G: 'GOLD', S: 'SILVER' },
          labelDefault: 'OTHER',
        },
        { key: 'pr', labelKeys: ['prName'], subtotal: 'header' },
      ],
      columns: [{ key: 'amt', caption: 'Amt', kind: 'money', level: 'line', total: true }],
      rowLevels: ['line'],
      suppress: undefined,
    };
    const rs: RpAllRecord[] = [
      {
        lcCode: '01',
        coBook: 'SL',
        vchNo: '1',
        srNo: 1,
        it: 'S',
        pr: 'P2',
        prName: 'Chain',
        amt: 5,
      },
      {
        lcCode: '01',
        coBook: 'SL',
        vchNo: '1',
        srNo: 2,
        it: 'G',
        pr: 'P1',
        prName: 'Ring',
        amt: 7,
      },
      {
        lcCode: '01',
        coBook: 'SL',
        vchNo: '2',
        srNo: 1,
        it: 'G',
        pr: 'P1',
        prName: 'Ring',
        amt: 3,
      },
      {
        lcCode: '01',
        coBook: 'SL',
        vchNo: '2',
        srNo: 2,
        it: 'D',
        pr: 'P3',
        prName: 'Stud',
        amt: 11,
      },
    ];
    const result = runLayout(two, rs);
    expect(result.groups.map((g) => [g.depth, g.label, g.totals.amt])).toEqual([
      [0, 'OTHER', 11],
      [1, 'Stud', 11],
      [0, 'GOLD', 10],
      [1, 'Ring', 10],
      [0, 'SILVER', 5],
      [1, 'Chain', 5],
    ]);
    expect(result.rows).toHaveLength(4);
  });

  it('returns an empty report (no rows, zero totals) for an empty record set', () => {
    const result = runLayout(layout, []);
    expect(result.rows).toEqual([]);
    expect(result.groups).toEqual([]);
    expect(result.totals).toEqual({ netAmt: 0, totAmt: 0, nwt: 0, subAmt: 0 });
    expect(result.voucherCount).toBe(0);
  });
});

describe('RP_ALL engine — formatting', () => {
  it('prints dates dd/MM/yyyy and numbers at the desktop precision', () => {
    expect(formatDate('2026-04-05')).toBe('05/04/2026');
    expect(formatCell('date', '2026-12-31')).toBe('31/12/2026');
    expect(formatCell('money', 1234.5)).toBe('1234.50');
    expect(formatCell('money', 0.005)).toBe('0.01'); // half-up, as Strings.Format "0.00"
    expect(formatCell('weight', 1.2345)).toBe('1.235');
    expect(formatCell('pcs', 3)).toBe('3');
    expect(formatCell('text', null)).toBe('');
  });

  it('builds the RptTitel the desktop passes', () => {
    expect(reportTitle('Sales Report', '2026-04-01', '2026-04-30')).toBe(
      'Sales Report From 01/04/2026 To 30/04/2026',
    );
  });
});
