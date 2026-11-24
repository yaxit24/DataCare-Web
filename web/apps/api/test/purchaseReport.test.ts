import { describe, expect, it } from 'vitest';
import {
  parsePurchaseRequest,
  purchaseOutputTable,
  purchaseReportHtml,
  selectionTotals,
  shapePurchaseResult,
  RpAllRequestError,
  type PurchaseRequest,
} from '../src/modules/reports/purchaseReport.js';
import { exportCsv } from '../src/modules/reports/rpAll/exportRows.js';
import { PURCHASE_SPECS, type PurchaseMode } from '../src/modules/reports/rpAll/purchaseLayouts.js';
import { buildPurchaseQuery } from '../src/modules/reports/rpAll/purchaseQuery.js';
import type { RpAllRecord } from '../src/modules/reports/rpAll/types.js';

/**
 * WP-12: the Purchase branch of RP_ALL as pure logic. Fixture vouchers are written as the Purchase Invoice and
 * Purchase Return screens store them (PR_DATA + PR_DETL); `joined()` turns them into the outer-joined record set
 * the templates read. Every expected number is added up here from the vouchers with the template's formula,
 * cited beside it, never read back from the code under test.
 */

const SESSION = { tenantId: 't', coCode: '01', lcCode: '01', coYear: '2026-2027' };
const Q = { fromDate: '2026-11-01', toDate: '2026-11-30' };

interface Line {
  sr: number;
  it: string;
  itName: string;
  itType: string;
  pr: string;
  gr: string;
  grName: string;
  pcs: number;
  gwt: number;
  nwt: number;
  touch: number;
  west: number;
  fine: number;
  rate: number;
  amt: number;
  lbr: number;
  oth: number;
  net: number;
}
interface Voucher {
  book: string;
  bookName: string;
  inout: 'I' | 'O';
  vch: string;
  date: string;
  ac: string;
  party: string;
  net: number;
  disc: number;
  tax: number;
  tot: number;
  cash: number;
  lines: Line[];
}

const GOLD: Line = {
  sr: 1,
  it: 'G22',
  itName: 'GOLD 22K',
  itType: 'G',
  pr: 'P01',
  gr: 'G1',
  grName: 'GOLD ORNAMENTS',
  pcs: 1,
  gwt: 20,
  nwt: 20,
  touch: 91.6,
  west: 0,
  fine: 18.32,
  rate: 6050,
  amt: 110836,
  lbr: 3000,
  oth: 0,
  net: 113836,
};
const SILVER: Line = {
  ...GOLD,
  it: 'S99',
  itName: 'SILVER 99',
  itType: 'S',
  pr: 'P02',
  gr: 'G2',
  grName: 'SILVER BARS',
  gwt: 100,
  nwt: 100,
  touch: 92.5,
  fine: 92.5,
  rate: 74,
  amt: 7400,
  lbr: 0,
  net: 7400,
};
// 3% GST: gold 113836 * 3% = 3415.08, silver 7400 * 3% = 222.
const V1: Voucher = {
  book: 'PURCHASE',
  bookName: 'PURCHASE',
  inout: 'I',
  vch: '00001',
  date: '2026-11-05',
  ac: 'LOCAL',
  party: 'E2E LOCAL SUPPLIER',
  net: 113836,
  disc: 0,
  tax: 3415.08,
  tot: 117251.08,
  cash: 1000,
  lines: [GOLD],
};
const V2: Voucher = {
  ...V1,
  vch: '00002',
  ac: 'INTER',
  party: 'E2E INTERSTATE SUPPLIER',
  net: 7400,
  tax: 222,
  tot: 7622,
  cash: 0,
  lines: [SILVER],
};
// A purchase return in its own book (BOOK_INOUT 'O'): 10 g of gold at 5000.
const V3: Voucher = {
  ...V1,
  book: 'PRRTN',
  bookName: 'PURCHASE RETURN',
  inout: 'O',
  vch: '00001',
  date: '2026-11-06',
  net: 5000,
  tax: 150,
  tot: 5150,
  cash: 0,
  lines: [{ ...GOLD, gwt: 10, nwt: 10, fine: 9.16, amt: 5000, lbr: 0, net: 5000 }],
};

const joined = (vs: Voucher[]): RpAllRecord[] =>
  vs.flatMap((v) =>
    v.lines.map((l) => ({
      lcCode: '01',
      coYear: '2026-2027',
      coBook: v.book,
      vchNo: v.vch,
      vchDate: v.date,
      billNo: '',
      acCode: v.ac,
      acName: v.party,
      netAmt: v.net,
      discAmt: v.disc,
      taxAmt: v.tax,
      rofAmt: 0,
      totAmt: v.tot,
      cgstTax: v.tax / 2,
      sgstTax: v.tax / 2,
      igstTax: 0,
      cashAmt: v.cash,
      cardAmt: 0,
      chqAmt: 0,
      kasarAmt: 0,
      billOs: 0,
      partyName: v.party,
      city: 'SURAT',
      bookName: v.bookName,
      bookSName: v.book,
      bookSrName: v.book.slice(0, 2),
      bookInout: v.inout,
      srNo: l.sr,
      tagNo: '',
      itCode: l.it,
      itName: l.itName,
      itType: l.itType,
      prCode: l.pr,
      grCode: l.gr,
      grName: l.grName,
      hsn: '7113',
      pcs: l.pcs,
      gwt: l.gwt,
      nwt: l.nwt,
      touch: l.touch,
      westPrc: l.west,
      fine: l.fine,
      rate: l.rate,
      lbrRate: 0,
      lbrAmt: l.lbr,
      othAmt: l.oth,
      itmAmtLine: l.amt,
      mrp: 0,
      lineTotAmt: l.net,
      lineNetAmt: l.net,
    })),
  );

const run = (mode: PurchaseMode, vs: Voucher[] = [V1, V2]) => {
  const request: PurchaseRequest = parsePurchaseRequest({ mode, ...Q }, SESSION);
  return shapePurchaseResult(request, joined(vs));
};
const lineOf = (r: ReturnType<typeof run>, band: string) =>
  r.table.lines.find((l) => l._band === band);

describe('Purchase Rpt request (RP_ALL.cs:7946-8187)', () => {
  it('opens with the seven PanelPurc buttons, and refuses anything else', () => {
    expect(parsePurchaseRequest({ ...Q }, SESSION).mode).toBe('report');
    expect(() => parsePurchaseRequest({ mode: 'sales', ...Q }, SESSION)).toThrow(RpAllRequestError);
  });

  it('defaults both dates to the system date, as the form opens (RP_ALL.cs:7195-7202)', () => {
    const r = parsePurchaseRequest({ mode: 'register' }, SESSION, '2026-11-23');
    expect([r.filters.fromDate, r.filters.toDate]).toEqual(['2026-11-23', '2026-11-23']);
  });

  it('does not refuse From after To: the desktop prints an empty report (RP_ALL.cs:7957)', () => {
    const r = parsePurchaseRequest(
      { mode: 'register', fromDate: '2026-12-31', toDate: '2026-01-01' },
      SESSION,
    );
    expect(r.filters.fromDate > r.filters.toDate).toBe(true);
  });

  it('refuses city and area on Group Purc: PurcGroupWise has no AC_MAST', () => {
    expect(() => parsePurchaseRequest({ mode: 'group', city: 'SURAT', ...Q }, SESSION)).toThrow(
      /no party master/,
    );
    expect(() =>
      parsePurchaseRequest({ mode: 'item', city: 'SURAT', ...Q }, SESSION),
    ).not.toThrow();
  });

  it('locks the location to the session unless it is head office 00 (RP_ALL.cs:6660-6671)', () => {
    expect(() => parsePurchaseRequest({ lcCode: '02', ...Q }, SESSION)).toThrow(/session location/);
    expect(
      parsePurchaseRequest({ lcCode: '', ...Q }, { ...SESSION, lcCode: '00' }).filters.lcCode,
    ).toBeNull();
  });
});

describe('Purchase Rpt SQL (parameterised, scoped)', () => {
  const build = (mode: PurchaseMode, extra: Record<string, string> = {}) => {
    const spec = PURCHASE_SPECS[mode];
    const request = parsePurchaseRequest({ mode, ...Q, ...extra }, SESSION);
    return buildPurchaseQuery({
      shape: spec.query,
      scope: SESSION,
      filters: request.filters,
      applied: new Set(spec.filters),
    });
  };

  it('scopes by company, year, inclusive dates and location, all bound', () => {
    const q = build('register');
    expect(q.text).toContain(`d."CO_CODE" = $1`);
    expect(q.text).toContain(`d."CO_YEAR" = $2`);
    expect(q.text).toContain(`d."VCH_DATE"::date >= $3::date`);
    expect(q.text).toContain(`d."VCH_DATE"::date <= $4::date`);
    expect(q.values).toEqual(['01', '2026-2027', Q.fromDate, Q.toDate, '01']);
    expect(q.text).not.toContain('2026');
  });

  it('adds the item predicates only where the handler does (Item Wise, Group Purc)', () => {
    const extra = { prCode: 'P02', grCode: 'G2', itemType: 'Silver' };
    for (const mode of ['item', 'group'] as const) {
      const q = build(mode, extra);
      expect(q.text).toContain(`im."PR_CODE" =`);
      expect(q.text).toContain(`im."GR_CODE" =`);
      expect(q.text).toContain(`im."IT_TYPE" =`);
      expect(q.values).toEqual(expect.arrayContaining(['P02', 'G2', 'S']));
    }
    expect(build('register', extra).text).not.toContain('im."PR_CODE"');
    expect(build('register', extra).text).not.toContain('PR_DETL');
  });

  it('guards Group Purc with NET_AMT <> 0 and no other mode (RP_ALL.cs:12125)', () => {
    expect(build('group').text).toContain(`d."NET_AMT" <> 0`);
    for (const mode of PURCHASE_SPECS.report.mode
      ? (['report', 'register', 'item', 'party'] as const)
      : [])
      expect(build(mode).text).not.toContain(`"NET_AMT" <> 0`);
  });

  it('never puts a request value in the SQL text', () => {
    const q = build('item', { city: "X'; DROP TABLE PR_DATA;--" });
    expect(q.text).not.toContain('DROP');
    expect(q.values).toContain("X'; DROP TABLE PR_DATA;--");
    // A code with SQL punctuation is not even a valid selector.
    expect(() => parsePurchaseRequest({ acCode: "X'; DROP", ...Q }, SESSION)).toThrow(/valid code/);
  });
});

describe('Purc Reg → PurcSumm (RP_ALL.cs:8017-8086)', () => {
  const r = run('register');
  it('prints one row per voucher with TOT_AMT, CASH, CARD, CREDIT = TOT_AMT - CASH_AMT', () => {
    const rows = r.table.lines.filter((l) => l._kind === 'voucher');
    expect(rows).toHaveLength(2);
    expect(rows[0]).toMatchObject({
      vchNo: '00001',
      totAmt: '117251.08',
      cashAmt: '1000.00',
      creditAmt: '116251.08',
    });
  });
  it('totals per day and overall: 117251.08 + 7622 = 124873.08', () => {
    expect(lineOf(r, 'DATE TOTAL :')).toMatchObject({
      totAmt: '124873.08',
      cashAmt: '1000.00',
      creditAmt: '123873.08',
    });
    expect(lineOf(r, 'GRAND TOTAL :')).toMatchObject({ totAmt: '124873.08' });
  });
  it('carries the voucher totals of the selection: net 121236, tax 3637.08, bill 124873.08', () => {
    expect(r.selection).toEqual({
      voucherCount: 2,
      netAmt: 121236,
      taxAmt: 3637.08,
      totAmt: 124873.08,
      fine: null,
      nwt: null,
    });
    expect(purchaseOutputTable(r).lines.at(-1)?._band).toBe(
      'Voucher totals: Vouchers 2  Net Amt 121236.00  Tax 3637.08  Bill Total 124873.08',
    );
  });
});

describe('selection totals count each voucher and line once', () => {
  it('two-line vouchers do not double the header amounts', () => {
    const twoLines: Voucher = { ...V1, lines: [GOLD, { ...GOLD, sr: 2 }] };
    const s = selectionTotals(joined([twoLines]), true);
    expect(s).toMatchObject({
      voucherCount: 1,
      netAmt: 113836,
      totAmt: 117251.08,
      nwt: 40,
      fine: 36.64,
    });
  });
});

describe('Purc Report → PurcReport', () => {
  const r = run('report');
  it('prints the voucher band then its lines, grouped by book', () => {
    expect(r.table.lines.map((l) => l._kind).slice(0, 5)).toEqual([
      'group',
      'voucher',
      'line',
      'voucher',
      'line',
    ]);
    expect(r.table.lines[0]?._band).toBe('PURCHASE PURCHASE');
  });
  it('totals the voucher amounts once and the line weights', () => {
    expect(r.totals).toMatchObject({
      itmAmt: 121236,
      taxAmt: 3637.08,
      vchAmt: 124873.08,
      pcs: 2,
      gwt: 120,
      nwt: 120,
      lbrAmt: 3000,
    });
  });
});

describe('Item Wise → PurcItem', () => {
  const r = run('item');
  it('groups book → item → day and totals the lines under the book footer', () => {
    expect(lineOf(r, 'Total :')).toMatchObject({
      pcs: '2',
      nwt: '120.000',
      fine: '110.820',
      itmAmtLine: '118236.00',
      lineNetAmt: '121236.00',
    });
  });
  it('prints the detail line with the voucher, party and line values', () => {
    const line = r.table.lines.find((l) => l._kind === 'line' && l.vchNo === '00002');
    expect(line).toMatchObject({
      partyName: 'E2E INTERSTATE SUPPLIER',
      nwt: '100.000',
      fine: '92.500',
    });
  });
});

describe('Group Purc → PurcGroupWise', () => {
  const r = run('group');
  it('prints GOLD then SILVER bands with their group sums', () => {
    const bands = r.table.lines.filter((l) => l._kind === 'group').map((l) => l._band);
    expect(bands).toEqual(['GOLD', '  GOLD ORNAMENTS', 'SILVER', '  SILVER BARS']);
    expect(r.table.lines[0]).toMatchObject({
      nwt: '20.000',
      itmAmtLine: '110836.00',
      lineNetAmt: '113836.00',
    });
  });
  it('suppresses the Detail band like PurcGroupWise Section8 (EnableSuppress=True): group bands only', () => {
    // RP_ALL.cs:12121 opens PurcGroupWise.RPT; its Detail section (Section8) is suppressed, so no voucher line
    // prints, only the item-type and group header sums and the grand total (as SalesGroupWise in the Sales branch).
    expect(r.table.lines.filter((l) => l._kind === 'line')).toEqual([]);
    expect(JSON.stringify(r.table.lines)).not.toContain(V1.vch);
  });
  it('totals Net Amt of the lines: 113836 + 7400 = 121236', () => {
    expect(r.totals).toMatchObject({
      nwt: 120,
      lineNetAmt: 121236,
      itmAmtLine: 118236,
      lbrAmt: 3000,
    });
  });
});

describe('Party Purc and Party Summ → AcPurcRpt, AcPurcSummRpt', () => {
  const vouchers = [V1, V2, V3];
  it('signs the party total by BOOK_INOUT: purchase − return (I = +, O = −)', () => {
    const r = run('party-summary', vouchers);
    // Parties print in code order. INTER: +100 g. LOCAL: +20 g (V1) − 10 g (V3), net 113836 − 5000 = 108836.
    const parties = r.table.lines.filter((l) => l._band === 'Party Total :');
    expect(parties[0]).toMatchObject({ nwt: '100.000', fine: '92.500', lineNetAmt: '7400.00' });
    expect(parties[1]).toMatchObject({ nwt: '10.000', fine: '9.160', lineNetAmt: '108836.00' });
    expect(r.totals).toMatchObject({ nwt: 110, fine: 101.66, lineNetAmt: 116236 });
  });
  it('totals each in/out type with the raw fields', () => {
    const r = run('party-summary', vouchers);
    const totals = r.table.lines.filter((l) => l._band === 'Total :');
    expect(totals).toHaveLength(4); // INTER in, LOCAL in, LOCAL out, then the signed grand total
    expect(totals[0]).toMatchObject({ nwt: '100.000', lineNetAmt: '7400.00' });
    expect(totals[1]).toMatchObject({ nwt: '20.000', lineNetAmt: '113836.00' });
    expect(totals[2]).toMatchObject({ nwt: '10.000', lineNetAmt: '5000.00' });
    expect(totals[3]).toMatchObject({ nwt: '110.000', lineNetAmt: '116236.00' }); // 100 + 20 − 10
  });
  it('prints the voucher sums on the header for Party Summ and after the lines for Party Purc', () => {
    const kinds = (m: PurchaseMode) =>
      run(m, [V1])
        .table.lines.filter((l) => l._kind === 'voucher' || l._kind === 'line')
        .map((l) => l._kind);
    expect(kinds('party-summary')).toEqual(['voucher', 'line']);
    expect(kinds('party')).toEqual(['line', 'voucher']);
    expect(run('party-summary', [V1]).table.lines.find((l) => l._kind === 'voucher')).toMatchObject(
      {
        vPcs: '1',
        vNwt: '20.000',
        vFine: '18.320',
        vLbrOth: '3000.00',
        totAmt: '117251.08',
      },
    );
  });
});

describe('Purchase Bill → PurcBillA4Gst', () => {
  const r = run('bill', [V1]);
  it('prints the bill lines and then the bill footer of the voucher', () => {
    expect(r.table.lines.map((l) => l._kind)).toEqual(['line', 'voucher']);
    expect(r.table.lines[0]).toMatchObject({
      itName: 'GOLD 22K',
      hsn: '7113',
      itmAmtLine: '110836.00',
      otherChg: '3000.00',
    });
    expect(r.table.lines[1]).toMatchObject({
      refNo: 'PU-00001',
      netAmt: '113836.00',
      cgstTax: '1707.54',
      totAmt: '117251.08',
    });
  });
});

describe('outputs', () => {
  it('CSV carries the same lines as the screen, the voucher totals line included', () => {
    const r = run('register');
    const csv = exportCsv(r as never, purchaseOutputTable(r));
    expect(csv.split('\r\n').filter(Boolean)).toHaveLength(1 + purchaseOutputTable(r).lines.length);
    expect(csv).toContain('GRAND TOTAL :');
    expect(csv).toContain('124873.08');
  });
  it('PDF html escapes the text and holds every voucher', () => {
    const html = purchaseReportHtml(run('item'));
    expect(html).toContain('Item Wise Purchase Register From 01/11/2026 To 30/11/2026');
    expect(html).toContain('00001');
    expect(html).toContain('00002');
    expect(html).not.toContain('<script');
  });
});
