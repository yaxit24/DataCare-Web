import { describe, expect, it } from 'vitest';
import {
  parseRpAllRequest,
  shapeSalesResult,
  RpAllRequestError,
  type RpAllRequest,
} from '../src/modules/reports/rpAll/index.js';
import { exportCsv, exportTable } from '../src/modules/reports/rpAll/exportRows.js';
import { SALES_SPECS } from '../src/modules/reports/rpAll/salesLayouts.js';
import { buildSalesQuery } from '../src/modules/reports/rpAll/salesQuery.js';
import type { RpAllRecord } from '../src/modules/reports/rpAll/types.js';

/**
 * WP-11: the Sales branch of RP_ALL as pure logic. Fixture vouchers are written as the voucher screens store
 * them (header + lines + sub-lines); `joined()` turns them into the outer-joined record set the template reads
 * (SaleReport.xml TableLinks: SL_DATA ⟕ SL_DETL ⟕ SL_IDTL). Every expected total is added up from the
 * vouchers with the template's formula, cited beside it, never read back from the code under test.
 */

const SESSION = { tenantId: 't', coCode: '01', lcCode: '01', coYear: '2026-2027' };
const Q = { fromDate: '2026-04-01', toDate: '2026-04-30' };

interface Sub {
  isr: number;
  itName: string;
  pcs: number;
  gwt: number;
  rate: number;
  net: number;
}
interface Line {
  sr: number;
  tag: string;
  itCode: string;
  itName: string;
  itType: string;
  prCode: string;
  prName: string;
  grCode: string;
  grName: string;
  pcs: number;
  gwt: number;
  nwt: number;
  rate: number;
  lbrRate: number;
  lbrAmt: number;
  othAmt: number;
  itmAmt: number;
  mrp: number;
  tot: number;
  net: number;
  itTax: number;
  itDisc: number;
  ordNo?: string;
  subs?: Sub[];
}
interface Voucher {
  book: string;
  bookName: string;
  vch: string;
  date: string;
  ac: string;
  acName: string;
  emp: string;
  empName: string;
  net: number;
  disc: number;
  tax: number;
  rof: number;
  tot: number;
  cgst: number;
  sgst: number;
  cash: number;
  chq: number;
  adv: number;
  oldGl: number;
  oldSl: number;
  kasar: number;
  os: number;
  rtnNet?: number;
  rtnTot?: number;
  lines: Line[];
}

const line = (sr: number, over: Partial<Line>): Line => ({
  sr,
  tag: `T${sr}`,
  itCode: 'G22',
  itName: 'Gold 22K',
  itType: 'G',
  prCode: 'P1',
  prName: 'Rings',
  grCode: 'GR1',
  grName: 'Gold Group',
  pcs: 1,
  gwt: 10,
  nwt: 9.5,
  rate: 6000,
  lbrRate: 500,
  lbrAmt: 4750,
  othAmt: 0,
  itmAmt: 57000,
  mrp: 0,
  tot: 61750,
  net: 61750,
  itTax: 1852.5,
  itDisc: 0,
  ...over,
});

// V1: two lines (one with two stone sub-lines), V2: one silver line, V3: a book-SX sale on another day.
const V1: Voucher = {
  book: 'SL',
  bookName: 'Sales',
  vch: '0001',
  date: '2026-04-05',
  ac: 'C1',
  acName: 'Cust One',
  emp: 'E01',
  empName: 'Ravi',
  net: 100000,
  disc: 500,
  tax: 2985,
  rof: 0.4,
  tot: 102485.4,
  cgst: 1492.5,
  sgst: 1492.5,
  cash: 50000,
  chq: 30000,
  adv: 10000,
  oldGl: 5000,
  oldSl: 0,
  kasar: 0.4,
  os: 7485,
  lines: [
    line(1, {
      othAmt: 1500,
      net: 63250,
      tot: 63250,
      subs: [
        { isr: 1, itName: 'Ruby', pcs: 2, gwt: 0.2, rate: 500, net: 1000 },
        { isr: 2, itName: 'Pearl', pcs: 1, gwt: 0.1, rate: 500, net: 500 },
      ],
    }),
    line(2, {
      itCode: 'G18',
      itName: 'Gold 18K',
      prCode: 'P2',
      prName: 'Chains',
      nwt: 4.25,
      gwt: 4.5,
      itmAmt: 30000,
      lbrAmt: 6750,
      net: 36750,
      tot: 36750,
      itTax: 1102.5,
      ordNo: 'O-17',
    }),
  ],
};
const V2: Voucher = {
  book: 'SL',
  bookName: 'Sales',
  vch: '0002',
  date: '2026-04-05',
  ac: 'C2',
  acName: 'Cust Two',
  emp: 'E02',
  empName: 'Mina',
  net: 8000,
  disc: 0,
  tax: 240,
  rof: 0,
  tot: 8240,
  cgst: 120,
  sgst: 120,
  cash: 8240,
  chq: 0,
  adv: 0,
  oldGl: 0,
  oldSl: 0,
  kasar: 0,
  os: 0,
  lines: [
    line(1, {
      itCode: 'S1',
      itName: 'Silver',
      itType: 'S',
      prCode: 'P3',
      prName: 'Payal',
      grCode: 'GR2',
      grName: 'Silver Group',
      gwt: 100,
      nwt: 100,
      rate: 80,
      lbrRate: 0,
      lbrAmt: 0,
      itmAmt: 8000,
      net: 8000,
      tot: 8000,
      itTax: 240,
    }),
  ],
};
const V3: Voucher = {
  book: 'SX',
  bookName: 'Sales X',
  vch: '0001',
  date: '2026-04-06',
  ac: 'C1',
  acName: 'Cust One',
  emp: 'E01',
  empName: 'Ravi',
  net: 20000,
  disc: 0,
  tax: 600,
  rof: 0,
  tot: 20600,
  cgst: 300,
  sgst: 300,
  cash: 600,
  chq: 0,
  adv: 0,
  oldGl: 0,
  oldSl: 0,
  kasar: 600,
  os: 19400,
  rtnNet: 1500,
  rtnTot: 1545,
  lines: [
    line(1, { nwt: 3.333, gwt: 3.5, itmAmt: 20000, lbrAmt: 0, net: 20000, tot: 20000, itTax: 600 }),
  ],
};
const VOUCHERS = [V1, V2, V3];

/** The outer-joined record set of SL_DATA ⟕ SL_DETL ⟕ SL_IDTL, shaped like salesQuery.ts aliases. */
function joined(vouchers: Voucher[], withSubs = true): RpAllRecord[] {
  const out: RpAllRecord[] = [];
  for (const v of vouchers) {
    const head = {
      lcCode: '01',
      coBook: v.book,
      vchNo: v.vch,
      vchDate: v.date,
      billNo: v.vch,
      acCode: v.ac,
      acName: v.acName,
      partyName: v.acName,
      empCode: v.emp,
      empName: v.empName,
      bookName: v.bookName,
      bookSName: v.book,
      netAmt: v.net,
      discAmt: v.disc,
      taxAmt: v.tax,
      rofAmt: v.rof,
      totAmt: v.tot,
      cgstTax: v.cgst,
      sgstTax: v.sgst,
      cashAmt: v.cash,
      chqAmt: v.chq,
      cardAmt: 0,
      advAmt: v.adv,
      oldGlAmt: v.oldGl,
      oldSlAmt: v.oldSl,
      kasarAmt: v.kasar,
      billOs: v.os,
      rtnNetAmt: v.rtnNet ?? 0,
      rtnTotAmt: v.rtnTot ?? 0,
      city: 'Surat',
      mobile: null,
      panNo: null,
      gstNo: null,
    };
    for (const l of v.lines) {
      const ln = {
        srNo: l.sr,
        tagNo: l.tag,
        itCode: l.itCode,
        itName: l.itName,
        itType: l.itType,
        prCode: l.prCode,
        prName: l.prName,
        grCode: l.grCode,
        grName: l.grName,
        pcs: l.pcs,
        gwt: l.gwt,
        nwt: l.nwt,
        rate: l.rate,
        lbrRate: l.lbrRate,
        lbrAmt: l.lbrAmt,
        othAmt: l.othAmt,
        itmAmtLine: l.itmAmt,
        mrp: l.mrp,
        lineTotAmt: l.tot,
        lineNetAmt: l.net,
        itTaxAmt: l.itTax,
        itDiscAmt: l.itDisc,
        ordNo: l.ordNo ?? '',
        vchType: 'S',
      };
      const subs = withSubs ? (l.subs ?? []) : [];
      if (subs.length === 0) out.push({ ...head, ...ln, subSrNo: null });
      for (const s of subs)
        out.push({
          ...head,
          ...ln,
          subSrNo: s.isr,
          subItName: s.itName,
          subPcs: s.pcs,
          subGwt: s.gwt,
          subRate: s.rate,
          subNetAmt: s.net,
        });
    }
  }
  return out;
}

const sum = <T>(xs: T[], f: (x: T) => number) =>
  Math.round(xs.reduce((s, x) => s + f(x), 0) * 1000) / 1000;
const lines = (vs: Voucher[]) => vs.flatMap((v) => v.lines);
const req = (query: Record<string, unknown>, session = SESSION): RpAllRequest =>
  parseRpAllRequest('sales', { ...Q, ...query }, session);

describe('Sales Report (BtnSlRpt → SaleReport)', () => {
  const result = shapeSalesResult(req({ mode: 'report' }), joined(VOUCHERS));

  it('opens SaleReport with the desktop title and groups by book', () => {
    expect(result.template).toBe('SaleReport');
    expect(result.title).toBe('Sales Report From 01/04/2026 To 30/04/2026'); // RP_ALL.cs:7610
    expect(result.groups.map((g) => g.label)).toEqual(['SL Sales', 'SX Sales X']);
  });

  it('totals the footer running totals from the vouchers (SaleReport.xml Section10)', () => {
    expect(result.totals).toEqual({
      itmAmt: sum(VOUCHERS, (v) => v.net), // #RTotal2 = Σ @ItmAmt = Σ SL_DATA.NET_AMT
      discAmt: sum(VOUCHERS, (v) => v.disc), // #RTotal3 = Σ @DiscAmt
      taxAmt: sum(VOUCHERS, (v) => v.tax), // #TotTaxAmt
      vchAmt: sum(VOUCHERS, (v) => v.tot), // #TotBillAmt = Σ @VchAmt = Σ TOT_AMT
      pcs: sum(lines(VOUCHERS), (l) => l.pcs), // #TotPcs
      gwt: sum(lines(VOUCHERS), (l) => l.gwt), // #GrossWt
      nwt: sum(lines(VOUCHERS), (l) => l.nwt), // #NetWt
      lbrAmt: sum(lines(VOUCHERS), (l) => l.lbrAmt), // #RTotal0
    });
  });

  it('prints sub-lines only where the line has other amount (Section6 suppress OTH_AMT = 0)', () => {
    const subs = result.rows.filter((r) => r.level === 'sub');
    expect(subs.map((r) => r.cells.subItName)).toEqual(['Ruby', 'Pearl']);
    expect(result.rows.filter((r) => r.level === 'voucher')).toHaveLength(3);
  });

  it('switches to the return variant on the prompt (SaleRtnReport, RTN_ amounts)', () => {
    const ret = shapeSalesResult(req({ mode: 'report', returns: 'yes' }), joined([V3], false));
    expect(ret.template).toBe('SaleRtnReport');
    expect(ret.title).toBe('Sales Return Report From 01/04/2026 To 30/04/2026');
    expect(ret.totals.itmAmt).toBe(1500); // @ItmAmt = RTN_NET_AMT
    expect(ret.totals.vchAmt).toBe(1545); // @VchAmt = RTN_TOT_AMT
    expect(ret.totals.discAmt).toBeUndefined(); // no Disc total in SaleRtnReport's footer
  });
});

describe('Sales Reg (BtnSalesReg → SalesSumm)', () => {
  const result = shapeSalesResult(req({ mode: 'register' }), joined(VOUCHERS, false));

  it('prints DATE TOTAL per day and the GRAND TOTAL, header amounts once per bill', () => {
    const day1 = [V1, V2];
    const day1Band = result.groups.find((g) => g.key === '2026-04-05')!;
    expect(day1Band.totals.netAmt).toBe(sum(day1, (v) => v.net));
    expect(day1Band.totals.billOs).toBe(sum(day1, (v) => v.os));
    expect(day1Band.totals.nwt).toBe(sum(lines(day1), (l) => l.nwt));
    expect(result.grandTotalCaption).toBe('GRAND TOTAL :');
    expect(result.totals.totAmt).toBe(sum(VOUCHERS, (v) => v.tot));
    expect(result.totals.advAmt).toBe(sum(VOUCHERS, (v) => v.adv));
    expect(result.totals.kasarAmt).toBe(sum(VOUCHERS, (v) => v.kasar));
  });

  it('keeps the desktop column order and captions', () => {
    expect(result.columns.map((c) => c.caption)).toEqual([
      'BIL_NO',
      'BIL_DATE',
      'AC NAME',
      'City',
      'Mobile',
      'Pan No',
      'GST No',
      'Net AMT',
      'CGST',
      'SGST',
      'TOT_AMT',
      'CASH',
      'Bank',
      'Les:Adv',
      'Old Gold',
      'Old Sl',
      'Kasar',
      'Os Amt',
      'Product Name',
      'Net Wt',
    ]);
  });

  it('exports every row with DATE TOTAL and GRAND TOTAL lines, the same numbers as the grid', () => {
    const table = exportTable(result);
    const bands = table.lines.map((l) => l._band);
    expect(bands.filter((b) => b === 'DATE TOTAL :')).toHaveLength(2);
    expect(bands[bands.length - 1]).toBe('GRAND TOTAL :');
    expect(table.lines[table.lines.length - 1]!.netAmt).toBe('128000.00');
    const csv = exportCsv(result);
    expect(csv.split('\r\n')[0]).toBe(
      'Band,BIL_NO,BIL_DATE,AC NAME,City,Mobile,Pan No,GST No,Net AMT,CGST,SGST,TOT_AMT,CASH,Bank,Les:Adv,Old Gold,Old Sl,Kasar,Os Amt,Product Name,Net Wt',
    );
  });
});

describe('Item Wise and Group Sales (SalesItem, SalesGroupWise)', () => {
  it('groups by item type then product with header subtotals', () => {
    const result = shapeSalesResult(req({ mode: 'item' }), joined(VOUCHERS, false));
    const gold = lines(VOUCHERS).filter((l) => l.itType === 'G');
    const band = result.groups.find((g) => g.depth === 0 && g.label === 'GOLD')!;
    expect(band.totals.nwt).toBe(sum(gold, (l) => l.nwt));
    expect(band.totals.itmTotAmt).toBe(sum(gold, (l) => l.tot)); // @ItmTotAmt = SL_DETL.TOT_AMT
    expect(result.groups.filter((g) => g.depth === 0).map((g) => g.label)).toEqual([
      'GOLD',
      'SILVER',
    ]);
    expect(result.groups.filter((g) => g.depth === 1).map((g) => g.label)).toEqual([
      'Rings',
      'Chains',
      'Payal',
    ]);
    expect(result.rows).toHaveLength(4);
  });

  it('Group Sales prints only bands and totals NET_AMT + IT_TAX_AMT - IT_DISC_AMT', () => {
    const result = shapeSalesResult(req({ mode: 'group' }), joined(VOUCHERS, false));
    expect(result.rows).toEqual([]); // Section8 suppressed
    expect(result.totals.itmTotAmt).toBe(sum(lines(VOUCHERS), (l) => l.net + l.itTax - l.itDisc));
  });

  it('refuses party-master filters the template cannot resolve (no AC_MAST in SalesItem.xml)', () => {
    expect(() => req({ mode: 'item', city: 'Surat' })).toThrowError(RpAllRequestError);
    expect(() => req({ mode: 'group', area: 'Adajan' })).toThrowError(/party master/);
  });
});

describe('Employ Sales (EmpSaleReport) and Sale With Order (SalesWithOrder)', () => {
  it('totals Bill Amount, Kasar and Net Amount (TOT_AMT - KASAR_AMT) per employee, no grand total', () => {
    const result = shapeSalesResult(req({ mode: 'employee' }), joined(VOUCHERS));
    const e01 = VOUCHERS.filter((v) => v.emp === 'E01');
    const band = result.groups.find((g) => g.key === 'E01')!;
    expect(band.label).toBe('E01 Ravi');
    expect(band.totals.totAmt).toBe(sum(e01, (v) => v.tot));
    expect(band.totals.kasarAmt).toBe(sum(e01, (v) => v.kasar));
    expect(band.totals.vchAmt).toBe(sum(e01, (v) => v.tot - v.kasar));
    expect(result.grandTotal).toBe(false);
  });

  it('lists order lines with grand totals of pcs, weights and net amount', () => {
    const records = joined(VOUCHERS, false).filter((r) => r.ordNo !== '');
    const result = shapeSalesResult(req({ mode: 'with-order', orderOnly: 'yes' }), records);
    expect(result.rows).toHaveLength(1);
    expect(result.totals).toEqual({ pcs: 1, gwt: 4.5, nwt: 4.25, lineNetAmt: 36750 });
  });
});

describe('RP_ALL selectors (filters.ts) — desktop semantics', () => {
  it('requires real dates but accepts From after To (the desktop prints an empty report)', () => {
    expect(() => req({ fromDate: '2026-02-30' })).toThrowError(/fromDate/);
    expect(() => req({ toDate: '30/04/2026' })).toThrowError(/toDate/);
    expect(req({ fromDate: '2026-05-01', toDate: '2026-04-01' }).filters.fromDate).toBe(
      '2026-05-01',
    );
  });

  it('locks the location to the session unless the session is head office 00', () => {
    expect(req({}).filters.lcCode).toBe('01');
    expect(() => req({ lcCode: '02' })).toThrowError(/fixed/);
    const ho = { ...SESSION, lcCode: '00' };
    expect(req({}, ho).filters.lcCode).toBe('00');
    expect(req({ lcCode: '' }, ho).filters.lcCode).toBeNull();
    expect(req({ lcCode: '02' }, ho).filters.lcCode).toBe('02');
  });

  it('maps the item type caption to its first letter and validates codes', () => {
    expect(req({ itemType: 'Real Stone' }).filters.itemType).toBe('R');
    expect(req({ itemType: 'g' }).filters.itemType).toBe('G');
    expect(() => req({ itemType: 'Bronze' })).toThrowError(/item type/);
    expect(() => req({ acCode: "x' OR '1'='1" })).toThrowError(/code/);
    expect(req({ books: 'SL, SX' }).filters.books).toEqual(['SL', 'SX']);
  });

  it('reports filters the button ignores, as the desktop formula leaves them out', () => {
    const result = shapeSalesResult(req({ mode: 'register', itemType: 'Gold', prCode: 'P1' }), []);
    expect(result.ignoredFilters).toEqual(['prCode', 'itemType']);
  });

  it('offers the return prompt only where the desktop asks it', () => {
    expect(() => req({ mode: 'group', returns: 'yes' })).toThrowError(/no sales-return/);
    expect(() => req({ mode: 'report', orderOnly: 'yes' })).toThrowError(/order-only/);
    expect(() => req({ mode: 'bill' })).toThrowError(/mode must be/);
  });
});

describe('Sales SQL (salesQuery.ts) — parameterised, per-button predicates', () => {
  const build = (
    mode: keyof typeof SALES_SPECS,
    query: Record<string, unknown> = {},
    returns = false,
  ) => {
    const r = req({ mode, ...query });
    const spec = SALES_SPECS[mode];
    const variant = returns && spec.ret ? spec.ret : spec.sale;
    return buildSalesQuery({
      shape: variant.query,
      scope: SESSION,
      filters: r.filters,
      applied: new Set(spec.filters),
      orderOnly: r.orderOnly,
    });
  };

  it('never puts a request value into the SQL text', () => {
    const q = build('report', {
      acCode: 'C1',
      city: "O'Brien Nagar",
      books: 'SL,SX',
      itemType: 'Gold',
    });
    expect(q.text).not.toContain('C1');
    expect(q.text).not.toContain('Brien');
    expect(q.values).toEqual([
      '01',
      '2026-2027',
      '2026-04-01',
      '2026-04-30',
      '01',
      ['SL', 'SX'],
      'C1',
      "O'Brien Nagar",
      'G',
    ]);
    expect(q.text).toMatch(/d\."NET_AMT" <> 0/);
  });

  it('applies only the filters the button appends', () => {
    const reg = build('register', { itemType: 'Gold', prCode: 'P1' });
    expect(reg.text).not.toMatch(/IT_TYPE" = \$/);
    expect(reg.text).not.toMatch(/PR_CODE" = \$/);
    const item = build('item', { itemType: 'Gold', prCode: 'P1', grCode: 'GR1' });
    expect(item.text).toMatch(/im\."IT_TYPE" = \$\d/);
    expect(item.text).toMatch(/im\."PR_CODE" = \$\d/);
    expect(item.text).toMatch(/im\."GR_CODE" = \$\d/);
    const emp = build('employee', { empCode: 'E01' });
    expect(emp.text).not.toMatch(/NET_AMT" <> 0/); // no amount guard (RP_ALL.cs:9146)
    expect(emp.text).toMatch(/d\."EMP_CODE" = \$\d/);
  });

  it('reads SL_DETL alone for Sale With Order and adds ORD_NO only on the prompt', () => {
    expect(build('with-order').text).toMatch(/FROM "SL_DETL" l/);
    expect(build('with-order').text).not.toMatch(/ORD_NO" <> ''/);
    expect(build('with-order', { orderOnly: 'yes' }).text).toMatch(/l\."ORD_NO" <> ''/);
  });

  it('uses RTN_NET_AMT and the return line tables for the return variant', () => {
    const q = build('report', {}, true);
    expect(q.text).toMatch(/d\."RTN_NET_AMT" <> 0/);
    expect(q.text).toMatch(/"SL_DETL_RTN" l/);
    expect(q.text).toMatch(/"BAR_IDTL" s/);
    expect(build('register', {}, true).text).not.toMatch(/JOIN "SL_DETL/);
  });

  it('drops the location predicate only for a head-office "all locations" run', () => {
    const r = parseRpAllRequest('sales', { ...Q, lcCode: '' }, { ...SESSION, lcCode: '00' });
    const q = buildSalesQuery({
      shape: SALES_SPECS.report.sale.query,
      scope: { ...SESSION, lcCode: '00' },
      filters: r.filters,
      applied: new Set(SALES_SPECS.report.filters),
      orderOnly: false,
    });
    expect(q.text).not.toMatch(/d\."LC_CODE" = \$/);
  });
});
