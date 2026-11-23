import { describe, expect, it } from 'vitest';
import { reportTitle } from '../src/modules/reports/rpAll/engine.js';
import { parseRpAllFilters } from '../src/modules/reports/rpAll/filters.js';
import { exportTable } from '../src/modules/reports/rpAll/exportRows.js';
import {
  parseRpAllRequest,
  shapeOrderResult,
  type RpAllRequest,
} from '../src/modules/reports/rpAll/index.js';
import { ORDER_SPECS, type OrderMode } from '../src/modules/reports/rpAll/orderLayouts.js';
import { buildOrderQuery } from '../src/modules/reports/rpAll/orderQuery.js';
import type { RpAllRecord } from '../src/modules/reports/rpAll/types.js';

/**
 * WP-14: the Order branch of RP_ALL as pure logic, run through the REAL mode table (ORDER_SPECS), the real
 * shaping (shapeOrderResult) and the real SQL builder (buildOrderQuery). Records are given in the shape the
 * adapter returns for each template's record set; every expected value is computed here from the fixture
 * with the template formula, never read back from the implementation.
 *
 * Fixture (cases.md "Test data"): an SL_ORD_ADJ row's own keys are the voucher that wrote it — the order
 * for its `+` advance row, the sale bill for a `-` adjustment — and ORD_* point at the order
 * (Ac_Tax.cs:71-73; OrdAdvAdj.xml / OrdAdjBillWise.xml TableLinks on ORD_NO/ORD_YRCD/ORD_DBCD).
 */

const SESSION = { tenantId: 't', coCode: '01', lcCode: '01', coYear: '2025-2026' };
const FROM_DATE = '2026-01-01';
const TO_DATE = '2026-01-31';
const Q = { fromDate: FROM_DATE, toDate: TO_DATE };
const YEAR = '2025-2026';

interface Order {
  book: string;
  vch: string;
  date: string;
  acCode: string;
  acName: string;
  advAmt: number;
  lines: { sr: number; designNo: string; tagNo: string; pcs: number; nwt: number; isu: string }[];
}
const ORDERS: Order[] = [
  {
    book: 'B1',
    vch: 'O1',
    date: '2026-01-05',
    acCode: 'P1',
    acName: 'ALPHA JEWELS',
    advAmt: 5000,
    lines: [
      { sr: 1, designNo: 'D1', tagNo: 'T1', pcs: 1, nwt: 10.5, isu: 'N' },
      { sr: 2, designNo: '', tagNo: 'T2', pcs: 2, nwt: 5.25, isu: 'N' },
    ],
  },
  {
    book: 'B2',
    vch: 'O2',
    date: '2026-01-10',
    acCode: 'P2',
    acName: 'BETA TRADERS',
    advAmt: 0,
    lines: [{ sr: 1, designNo: 'D1', tagNo: 'T1', pcs: 3, nwt: 7.125, isu: 'N' }],
  },
  {
    book: 'B1',
    vch: 'O3',
    date: '2026-01-15',
    acCode: 'P1',
    acName: 'ALPHA JEWELS',
    advAmt: 3000,
    lines: [{ sr: 1, designNo: 'D3', tagNo: 'T4', pcs: 1, nwt: 4, isu: 'N' }],
  },
  {
    book: 'B1',
    vch: 'O8',
    date: '2026-01-20',
    acCode: 'P2',
    acName: 'BETA TRADERS',
    advAmt: 0,
    lines: [{ sr: 1, designNo: 'D8', tagNo: 'T9', pcs: 1, nwt: 3, isu: 'Y' }],
  },
];
interface Adj {
  book: string;
  vch: string;
  sr: number;
  date: string;
  sign: string;
  amt: number;
  ord: string;
  bill?: { tot: number; adv: number; acName: string; party: string };
}
const ADJ: Adj[] = [
  { book: 'B1', vch: 'O1', sr: 1, date: '2026-01-05', sign: '+', amt: 5000, ord: 'O1' },
  {
    book: 'SB',
    vch: 'S1',
    sr: 1,
    date: '2026-01-18',
    sign: '-',
    amt: 1500,
    ord: 'O1',
    bill: { tot: 12000, adv: 2000, acName: 'ALPHA JEWELS', party: 'ALPHA JEWELS' },
  },
  {
    book: 'SB',
    vch: 'S1',
    sr: 2,
    date: '2026-01-18',
    sign: '-',
    amt: 500,
    ord: 'O1',
    bill: { tot: 12000, adv: 2000, acName: 'ALPHA JEWELS', party: 'ALPHA JEWELS' },
  },
  { book: 'B1', vch: 'O3', sr: 1, date: '2026-01-15', sign: '+', amt: 3000, ord: 'O3' },
  // SR_NO 1 again on another voucher: the adjustment key is the row's own voucher + SR_NO, not SR_NO alone.
  {
    book: 'SB',
    vch: 'S2',
    sr: 1,
    date: '2026-01-22',
    sign: '-',
    amt: 1500,
    ord: 'O3',
    bill: { tot: 9000, adv: 3000, acName: 'ALPHA JEWELS', party: 'ALPHA JEWELS' },
  },
  { book: '081', vch: 'C1', sr: 1, date: '2026-01-25', sign: '-', amt: 1500, ord: 'O3' },
];
const orderOf = (vch: string) => ORDERS.find((o) => o.vch === vch)!;

const header = (o: Order): Record<string, RpAllValueLike> => ({
  coCode: '01',
  lcCode: '01',
  coYear: YEAR,
  coBook: o.book,
  vchNo: o.vch,
  vchDate: o.date,
  acCode: o.acCode,
  acName: o.acName,
  advAmt: o.advAmt,
  bookSName: `S${o.book}`,
});
type RpAllValueLike = string | number | null;
/** SL_ORD_DATA ⟕ SL_ORD_DETL. */
const lineRecords = (): RpAllRecord[] =>
  ORDERS.flatMap((o) =>
    o.lines.map((l) => ({
      ...header(o),
      srNo: l.sr,
      designNo: l.designNo,
      tagNo: l.tagNo,
      pcs: l.pcs,
      nwt: l.nwt,
      designIsu: l.isu,
    })),
  );
const adjCols = (a: Adj) => ({
  adjLc: '01',
  adjYear: YEAR,
  adjBook: a.book,
  adjVchNo: a.vch,
  adjSr: a.sr,
  adjVchDate: a.date,
  adjAcName: null,
  ordSign: a.sign,
  ordAmt: a.amt,
  ordLc: '01',
  ordYrcd: YEAR,
  ordDbcd: orderOf(a.ord).book,
  ordNo: a.ord,
});
/** SL_ORD_DATA ⟕ SL_ORD_ADJ on ORD_* (an order without adjustments keeps one NULL record). */
const adjustRecords = (withBill: boolean): RpAllRecord[] =>
  ORDERS.flatMap((o): RpAllRecord[] => {
    const mine = ADJ.filter((a) => a.ord === o.vch);
    if (!mine.length) return [{ ...header(o), adjSr: null, ordSign: null, ordAmt: null }];
    return mine.map((a) => ({
      ...header(o),
      ...adjCols(a),
      ...(withBill ? { billTotAmt: a.bill?.tot ?? 0, billPartyName: a.bill?.party ?? null } : {}),
    }));
  });

const request = (mode: OrderMode, extra: Record<string, unknown> = {}): RpAllRequest =>
  parseRpAllRequest('order', { ...Q, mode, ...extra }, SESSION);
const run = (mode: OrderMode, records: RpAllRecord[], extra: Record<string, unknown> = {}) =>
  shapeOrderResult(request(mode, extra), records);
const round = (x: number, dp: number) => Number(x.toFixed(dp));

describe('Order Report (BtnOrdRpt → OrdDetlRpt)', () => {
  const r = run('report', lineRecords());
  const lines = ORDERS.flatMap((o) => o.lines);
  it('prints one header row per order and one row per line, every line (no status filter, D3)', () => {
    expect(r.rows.filter((x) => x.level === 'voucher').map((x) => x.cells.vchNo)).toEqual([
      'O1',
      'O2',
      'O3',
      'O8',
    ]);
    expect(r.rows.filter((x) => x.level === 'line')).toHaveLength(lines.length);
    const o1 = r.rows.find((x) => x.level === 'voucher' && x.cells.vchNo === 'O1')!;
    expect(o1.cells).toMatchObject({ vchDate: '2026-01-05', acName: 'ALPHA JEWELS', advAmt: 5000 });
  });
  it('report footer "Total :" sums ITM_PCS and ITM_NWT once per line (OrdDetlRpt.xml Sum fields)', () => {
    expect(r.totals.pcs).toBe(lines.reduce((s, l) => s + l.pcs, 0));
    expect(r.totals.nwt).toBe(
      round(
        lines.reduce((s, l) => s + l.nwt, 0),
        3,
      ),
    );
    expect(r.grandTotalCaption).toBe('Total :');
    expect(r.title).toBe('Order Report From 01/01/2026 To 31/01/2026');
  });
});

describe('Order Adjust (BtnOrdAdj → OrdAdvAdj)', () => {
  const r = run('adjust', adjustRecords(false));
  const net = (vch: string, sign: string) =>
    ADJ.filter((a) => a.ord === vch && a.sign === sign).reduce((s, a) => s + a.amt, 0);
  it('prints each order as its @OrdGroup header band with the three sums; the detail band is suppressed', () => {
    expect(r.rows).toHaveLength(0);
    for (const vch of ['O1', 'O3']) {
      const o = orderOf(vch);
      const g = r.groups.find((x) => x.key === `01${YEAR}${o.book}${vch}`)!;
      expect(g.label).toBe(`${vch} ${o.date.split('-').reverse().join('/')} ${o.acName}`);
      expect(g.totals).toEqual({
        plusAmt: net(vch, '+'),
        minusAmt: net(vch, '-'),
        balAmt: net(vch, '+') - net(vch, '-'),
      });
    }
  });
  it('"TOTAL :" grand sums count every adjustment row once, even when SR_NO repeats across vouchers', () => {
    const plus = ADJ.filter((a) => a.sign === '+').reduce((s, a) => s + a.amt, 0);
    const minus = ADJ.filter((a) => a.sign === '-').reduce((s, a) => s + a.amt, 0);
    expect(r.totals).toEqual({ plusAmt: plus, minusAmt: minus, balAmt: plus - minus });
    expect(r.grandTotalCaption).toBe('TOTAL :');
  });
});

describe('Order Wise Bill (BtnOrdWithBill → OrdAdjBillWise)', () => {
  const r = run('with-bill', adjustRecords(true));
  it('order band: ADV_AMT, Sum(@AdjAmt) of the minus rows and @PandingTot = ADV_AMT - Sum', () => {
    for (const vch of ['O1', 'O3']) {
      const adj = ADJ.filter((a) => a.ord === vch && a.sign === '-').reduce((s, a) => s + a.amt, 0);
      const g = r.groups.find((x) => x.depth === 1 && x.key === vch)!;
      expect(g.totals).toEqual({
        advAmt: orderOf(vch).advAmt,
        adjAmt: adj,
        pendingAmt: orderOf(vch).advAmt - adj,
      });
    }
  });
  it('detail rows carry the adjusting voucher, @AcName and the bill amount', () => {
    const o3 = r.rows.filter((x) => x.voucherKey.endsWith('|O3')).map((x) => x.cells);
    expect(o3).toEqual([
      {
        adjBook: 'B1',
        adjVchNo: 'O3',
        adjVchDate: '2026-01-15',
        billParty: null,
        billTotAmt: 0,
        adjAmt: 0,
      },
      {
        adjBook: 'SB',
        adjVchNo: 'S2',
        adjVchDate: '2026-01-22',
        billParty: 'ALPHA JEWELS',
        billTotAmt: 9000,
        adjAmt: 1500,
      },
      // @AcName: book 081 prints the fixed text "ORDER CANCEL".
      {
        adjBook: '081',
        adjVchNo: 'C1',
        adjVchDate: '2026-01-25',
        billParty: 'ORDER CANCEL',
        billTotAmt: 0,
        adjAmt: 1500,
      },
    ]);
    expect(r.grandTotal).toBe(false);
  });
});

describe('Making Panding / Making Summ (OrdDetlPanding / OrdDesignSumm)', () => {
  const pendingLines = ORDERS.flatMap((o) =>
    o.lines.filter((l) => l.isu === 'N').map((l) => ({ o, l })),
  );
  // The adapter returns only DESIGN_ISU = 'N' lines (RP_ALL.cs:10940); feed exactly that set.
  const recs = lineRecords().filter((x) => x.designIsu === 'N');
  it('Making Panding groups per order and prints @Design = DESIGN_NO, or TAG_NO when it is empty', () => {
    const r = run('pending', recs);
    expect(r.groups.map((g) => g.key)).toEqual(
      pendingLines
        .filter((x, i, a) => a.findIndex((y) => y.o === x.o) === i)
        .map((x) => `${YEAR}${x.o.book}${x.o.vch}`)
        .sort(),
    );
    expect(r.rows.filter((x) => x.level === 'line').map((x) => x.cells.design)).toEqual([
      'D1',
      'T2',
      'D3',
      'D1',
    ]);
    expect(r.totals.pcs).toBe(pendingLines.reduce((s, x) => s + x.l.pcs, 0));
    expect(r.totals.nwt).toBe(
      round(
        pendingLines.reduce((s, x) => s + x.l.nwt, 0),
        3,
      ),
    );
  });
  it('Making Summ groups on @VchGroup = TAG_NO&DESIGN_NO with header sums; OnlySumm=Y hides only the detail', () => {
    const no = run('summary', recs);
    const yes = run('summary', recs, { onlySummary: 'yes' });
    const t1d1 = pendingLines.filter((x) => x.l.tagNo === 'T1' && x.l.designNo === 'D1');
    const g = no.groups.find((x) => x.key === 'T1D1')!;
    expect(g.label).toBe('T1D1');
    expect(g.totals).toEqual({
      pcs: t1d1.reduce((s, x) => s + x.l.pcs, 0),
      nwt: round(
        t1d1.reduce((s, x) => s + x.l.nwt, 0),
        3,
      ),
    });
    expect(no.rows).toHaveLength(pendingLines.length);
    expect(yes.rows).toHaveLength(0);
    expect(yes.totals).toEqual(no.totals);
    expect(yes.groups.map((x) => x.totals)).toEqual(no.groups.map((x) => x.totals));
  });
});

describe('Bill Wise Adjust (btnbillwiseordadj → BillWiseOrderAdjust)', () => {
  const recs: RpAllRecord[] = ADJ.filter((a) => a.bill).map((a) => ({
    coCode: '01',
    lcCode: '01',
    coYear: YEAR,
    coBook: a.book,
    vchNo: a.vch,
    vchDate: a.date,
    billAcCode: 'P1',
    billAcName: a.bill!.acName,
    billTotAmt: a.bill!.tot,
    billAdvAmt: a.bill!.adv,
    bookName: 'Sales Bill',
    ...adjCols(a),
    orderPartyName: orderOf(a.ord).acName,
  }));
  const r = run('bill-wise', recs);
  it('one band per bill with its amounts, then one row per adjustment with the raw ORD_AMT; no totals (D13)', () => {
    expect(
      r.rows.map((x) => [
        x.level,
        x.level === 'voucher' ? x.cells.vchNo : x.cells.ordNo,
        x.level === 'voucher' ? x.cells.billTotAmt : x.cells.ordAmt,
      ]),
    ).toEqual([
      ['voucher', 'S1', 12000],
      ['line', 'O1', 1500],
      ['line', 'O1', 500],
      ['voucher', 'S2', 9000],
      ['line', 'O3', 1500],
    ]);
    expect(r.rows[0]!.cells.billAdvAmt).toBe(2000);
    expect(r.rows[1]!.cells.orderPartyName).toBe('ALPHA JEWELS');
    expect(r.grandTotal).toBe(false);
  });
});

describe('Order SQL follows the template record sets and binds every value', () => {
  const sql = (mode: OrderMode, extra: Record<string, unknown> = {}) => {
    const req = request(mode, extra);
    const spec = ORDER_SPECS[mode];
    return buildOrderQuery({
      shape: spec.variant.query,
      scope: SESSION,
      filters: req.filters,
      applied: new Set(spec.filters),
    });
  };
  const flat = (s: string) => s.replace(/\s+/g, ' ');
  it('Order Adjust reaches adjustments through ORD_NO/ORD_LC/ORD_YRCD/ORD_DBCD (OrdAdvAdj.xml TableLink)', () => {
    expect(flat(sql('adjust').text)).toContain(
      'a."ORD_NO" = d."VCH_NO" AND a."ORD_LC" = d."LC_CODE" AND a."ORD_YRCD" = d."CO_YEAR" AND a."ORD_DBCD" = d."CO_BOOK"',
    );
  });
  it("Order Wise Bill links ORD_* without the location and the bill through the adjustment's own keys", () => {
    const t = flat(sql('with-bill').text);
    expect(t).toContain(
      'a."ORD_NO" = d."VCH_NO" AND a."ORD_YRCD" = d."CO_YEAR" AND a."ORD_DBCD" = d."CO_BOOK"',
    );
    expect(t).not.toContain('a."ORD_LC" = d."LC_CODE"');
    expect(t).toContain(
      's."CO_CODE" = a."CO_CODE" AND s."LC_CODE" = a."LC_CODE" AND s."CO_YEAR" = a."CO_YEAR" AND s."CO_BOOK" = a."CO_BOOK" AND s."VCH_NO" = a."VCH_NO"',
    );
  });
  it('Bill Wise Adjust inner-joins SL_DATA to SL_ORD_ADJ and applies all six selectors (RP_ALL.cs:12609-12632)', () => {
    const q = sql('bill-wise', {
      coBook: 'SB',
      acCode: 'P1',
      city: 'SURAT',
      area: 'ADAJAN',
      custName: "O'NEIL",
    });
    const t = flat(q.text);
    expect(t).toMatch(/FROM "SL_DATA" d JOIN "SL_ORD_ADJ" a/);
    expect(t).toContain('m."AC_CODE" = a."ORD_AC_CODE"');
    for (const c of [
      'd."LC_CODE" = $',
      'd."CO_BOOK" = $',
      'd."AC_CODE" = $',
      'ac."AC_CITY" = $',
      'ac."AC_AREA" = $',
      'd."AC_NAME" = $',
    ])
      expect(t).toContain(c);
    expect(q.values).toEqual([
      '01',
      FROM_DATE,
      TO_DATE,
      '01',
      'SB',
      'P1',
      'SURAT',
      'ADAJAN',
      "O'NEIL",
    ]);
    expect(q.text).not.toContain("O'NEIL");
  });
  it("Making Panding filters DESIGN_ISU = N only (the fully-adjusted flagging is one registration's branch, RP_ALL.cs:10925)", () => {
    const t = flat(sql('pending').text);
    expect(t).toContain(`l."DESIGN_ISU" = 'N'`);
    expect(t).not.toContain('HAVING');
    expect(flat(sql('report').text)).not.toContain('DESIGN_ISU" =');
  });
});

describe('Export rows are built from the same result as the grid', () => {
  it('Order Report export: every header and line row, then the "Total :" line', () => {
    const r = run('report', lineRecords());
    const table = exportTable(r);
    const body = table.lines.filter((l) => l._band === 'voucher' || l._band === 'line');
    expect(body).toHaveLength(r.rows.length);
    expect(table.lines[table.lines.length - 1]).toMatchObject({
      _band: 'Total :',
      pcs: String(r.totals.pcs),
    });
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
