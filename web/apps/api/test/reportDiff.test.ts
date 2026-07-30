import { describe, expect, it } from 'vitest';
import { csvCell, parseReportCsv, toCsv } from '../src/modules/reports/reportCsv.js';
import {
  diffReportCsv,
  formatReportDiff,
  type ReportColumnMap,
} from '../src/modules/reports/reportDiff.js';

/**
 * Report data comparison (plan layer L4).
 *
 * Compares the DATA a report produced — rows and totals — between a Crystal export and the web's. Not layout:
 * Crystal pixel parity is not claimed anywhere, and the 254 layout baselines only detect regressions in the
 * web's own renderer.
 *
 * The tests fall into two groups, and the first matters as much as the second:
 *
 *  1. Crystal's export artefacts must NOT be read as data. A paginated, grouped report carries repeated
 *     headers, group captions, blank separators and a grand total. Counting any of those as a record makes the
 *     row counts disagree for reasons unrelated to the business logic, and sends someone hunting a defect that
 *     does not exist.
 *  2. A real difference must be caught and named.
 */

/** A Crystal export of a day book, with the artefacts a real one carries. */
const CRYSTAL_DAY_BOOK = [
  '\uFEFFDataCare Jewellers',
  'Day Book  01-Apr-2024 to 30-Apr-2024',
  '',
  'VchNo,AcName,Dr Amount,Cr Amount',
  '00001,Cash A/c,"1,000.00",0.00',
  '00001,Sales A/c,0.00,"1,000.00"',
  '',
  'VchNo,AcName,Dr Amount,Cr Amount',
  '00002,Party One,"2,500.50",0.00',
  '00002,Sales A/c,0.00,"2,500.50"',
  'GRAND TOTAL,,"3,500.50","3,500.50"',
  '',
].join('\r\n');

/** The web's export of the same report. Column names differ, which is the normal case. */
const WEB_DAY_BOOK = [
  'vchNo,party,dr,cr',
  '00001,Cash A/c,1000.00,0.00',
  '00001,Sales A/c,0.00,1000.00',
  '00002,Party One,2500.50,0.00',
  '00002,Sales A/c,0.00,2500.50',
  'TOTAL,,3500.50,3500.50',
].join('\n');

const MAP: ReportColumnMap = {
  report: 'day-book',
  columns: {
    VchNo: 'vchNo',
    AcName: 'party',
    'Dr Amount': 'dr',
    'Cr Amount': 'cr',
  },
  numeric: ['dr', 'cr'],
  key: ['vchNo', 'party'],
  scale: { dr: 2, cr: 2 },
};

describe('report CSV writing', () => {
  it('quotes separators, quotes and newlines', () => {
    expect(csvCell('a,b')).toBe('"a,b"');
    expect(csvCell('say "hi"')).toBe('"say ""hi"""');
    expect(csvCell('line1\nline2')).toBe('"line1\nline2"');
    expect(csvCell('plain')).toBe('plain');
  });

  it('neutralises a leading character that a spreadsheet would treat as a formula', () => {
    // A cell starting with = + - or @ becomes an executable formula when the file is opened. The same class of
    // hazard the XLSX writer closes by emitting every value as a string cell.
    for (const risky of ['=SUM(A1)', '+1', '-1+2', '@cmd']) {
      const cell = csvCell(risky);
      expect(cell.startsWith('"\''), `${risky} must be neutralised`).toBe(true);
    }
  });

  it('emits a deterministic column order and marks the totals line', () => {
    const csv = toCsv([{ b: 2, a: 1 }], { columns: ['a', 'b'], totals: { a: 1, b: 2 } });
    expect(csv.split('\n')[0]).toBe('a,b');
    expect(csv).toContain('TOTAL,2');
  });
});

describe('Crystal export artefacts are not read as data', () => {
  const parsed = parseReportCsv(CRYSTAL_DAY_BOOK, { headerHint: 'VchNo' });

  it('finds the header below the title block', () => {
    expect(parsed.columns).toEqual(['VchNo', 'AcName', 'Dr Amount', 'Cr Amount']);
  });

  it('reads exactly the four data rows', () => {
    // Four records: two vouchers of two legs each. The title, blank lines, repeated header and grand total are
    // all excluded — miscounting any of them would make the row counts disagree spuriously.
    expect(parsed.rows).toHaveLength(4);
    expect(parsed.rows.map((r) => r.VchNo)).toEqual(['00001', '00001', '00002', '00002']);
  });

  it('captures the grand total separately rather than as a row', () => {
    expect(parsed.totals?.['Dr Amount']).toBe('3,500.50');
  });

  it('accounts for everything it discarded', () => {
    // The reader publishes what it skipped so a human can reconcile the row count rather than trust it.
    expect(parsed.skipped.repeatedHeader).toBe(1);
    expect(parsed.skipped.total).toBe(1);
    expect(parsed.skipped.blank).toBeGreaterThan(0);
  });

  it('strips the UTF-8 BOM a Windows export carries', () => {
    expect(parsed.columns[0]).toBe('VchNo');
    expect(parsed.columns[0]!.charCodeAt(0)).not.toBe(0xfeff);
  });

  it('treats a single-populated-field line as a group caption', () => {
    const withGroup = ['A,B,C', 'Gold Group,,', '1,2,3'].join('\n');
    const p = parseReportCsv(withGroup);
    expect(p.rows).toHaveLength(1);
    expect(p.skipped.groupOrSubtotal).toBe(1);
  });
});

describe('report comparison', () => {
  it('matches two exports that agree, despite different column names and formatting', () => {
    // Thousands separators, a BOM, repeated headers and a differently named header row must not stop a match.
    const d = diffReportCsv(CRYSTAL_DAY_BOOK, WEB_DAY_BOOK, MAP, { crystalHeaderHint: 'VchNo' });
    expect(d.matched).toBe(true);
    expect(d.crystal.rows).toBe(4);
    expect(d.web.rows).toBe(4);
    expect(d.crystal.sums.dr).toBeCloseTo(3500.5, 2);
    expect(d.rowLevel?.differences).toEqual([]);
    // The denominator travels with the verdict.
    expect(d.rowLevel?.compared).toBeGreaterThan(0);
  });

  it('catches a changed amount and names the row and column', () => {
    const tampered = WEB_DAY_BOOK.replace('2500.50,0.00', '2500.51,0.00');
    const d = diffReportCsv(CRYSTAL_DAY_BOOK, tampered, MAP, { crystalHeaderHint: 'VchNo' });
    expect(d.matched).toBe(false);
    const diff = d.rowLevel!.differences.find((x) => x.column === 'dr')!;
    expect(diff.crystal).toBe('2500.50');
    expect(diff.web).toBe('2500.51');
    expect(diff.rowKey).toContain('Party One');
  });

  it('catches a missing row', () => {
    const short = WEB_DAY_BOOK.split('\n')
      .filter((l) => !l.startsWith('00002,Party One'))
      .join('\n');
    const d = diffReportCsv(CRYSTAL_DAY_BOOK, short, MAP, { crystalHeaderHint: 'VchNo' });
    expect(d.matched).toBe(false);
    expect(d.rowCountMatches).toBe(false);
    expect(d.rowLevel!.differences.some((x) => x.web === 'absent')).toBe(true);
  });

  it('catches an extra row the web produced', () => {
    const extra = `${WEB_DAY_BOOK}\n00003,Ghost A/c,1.00,0.00`;
    const d = diffReportCsv(CRYSTAL_DAY_BOOK, extra, MAP, { crystalHeaderHint: 'VchNo' });
    expect(d.matched).toBe(false);
    expect(d.rowLevel!.differences.some((x) => x.crystal === 'absent')).toBe(true);
  });

  it('catches disagreeing control totals even when the row count matches', () => {
    // Two rows swapped in value: the count is identical and only the sums reveal it.
    const swapped = WEB_DAY_BOOK.replace('1000.00,0.00', '900.00,0.00').replace(
      '0.00,1000.00',
      '0.00,900.00',
    );
    const d = diffReportCsv(CRYSTAL_DAY_BOOK, swapped, MAP, { crystalHeaderHint: 'VchNo' });
    expect(d.rowCountMatches, 'the row count is unchanged').toBe(true);
    expect(d.totalsMatch, 'but the totals are not').toBe(false);
    expect(d.matched).toBe(false);
  });

  it('reports an unmapped Crystal column instead of ignoring it', () => {
    // Silently dropping a column would let the comparison claim agreement on data it never looked at.
    const withExtra = CRYSTAL_DAY_BOOK.replace(
      'VchNo,AcName,Dr Amount,Cr Amount',
      'VchNo,AcName,Dr Amount,Cr Amount,Narration',
    );
    const d = diffReportCsv(withExtra, WEB_DAY_BOOK, MAP, { crystalHeaderHint: 'VchNo' });
    expect(d.unmappedCrystalColumns).toContain('Narration');
  });

  it('refuses a row-level verdict when a mapped column is absent from the web export', () => {
    // A row-level result here would be a statement about the mapping, not about the data.
    const noParty = WEB_DAY_BOOK.replace('vchNo,party,dr,cr', 'vchNo,name,dr,cr');
    const d = diffReportCsv(CRYSTAL_DAY_BOOK, noParty, MAP, { crystalHeaderHint: 'VchNo' });
    expect(d.missingWebColumns).toContain('party');
    expect(d.rowLevel, 'row level must not run on an incomplete mapping').toBeUndefined();
    expect(d.matched).toBe(false);
    expect(formatReportDiff(d)).toContain('NOT run');
  });

  it('an empty report is not a pass', () => {
    // Two files with no rows agree about nothing.
    const d = diffReportCsv('A,B\n', 'a,b\n', {
      report: 'empty',
      columns: { A: 'a', B: 'b' },
      numeric: [],
    });
    expect(d.matched).toBe(false);
  });

  it('reads parenthesised negatives, as Crystal writes them', () => {
    const crystal = ['VchNo,AcName,Dr Amount,Cr Amount', '00001,Adj,"(500.00)",0.00'].join('\n');
    const web = ['vchNo,party,dr,cr', '00001,Adj,-500.00,0.00'].join('\n');
    const d = diffReportCsv(crystal, web, MAP, { crystalHeaderHint: 'VchNo' });
    expect(d.crystal.sums.dr).toBeCloseTo(-500, 2);
    expect(d.matched).toBe(true);
  });

  it('compares at the declared scale, not at full float precision', () => {
    // A difference finer than either side stores is not a finding; one at the stored scale is.
    const crystal = ['VchNo,AcName,Dr Amount,Cr Amount', '00001,A,100.004,0.00'].join('\n');
    const web = ['vchNo,party,dr,cr', '00001,A,100.001,0.00'].join('\n');
    expect(diffReportCsv(crystal, web, MAP, { crystalHeaderHint: 'VchNo' }).totalsMatch).toBe(true);
    const wider = { ...MAP, scale: { dr: 3, cr: 3 } };
    expect(diffReportCsv(crystal, web, wider, { crystalHeaderHint: 'VchNo' }).totalsMatch).toBe(
      false,
    );
  });
});
