import { describe, expect, it } from 'vitest';
import {
  canonicalise,
  comparisonScale,
  exclusionReason,
  EXCLUDED_FIELDS,
  NULL_SENTINEL,
  RECLAIMED_FIELDS,
  type BundleCase,
  type BundleTable,
  type ParityBundle,
} from '../src/modules/parity/bundle.js';
import { diffBundles, formatDiff } from '../src/modules/parity/bundleDiff.js';

/**
 * The desktop-vs-web differ.
 *
 * This is the instrument that will produce the only objective evidence of parity, so its own correctness has
 * to be established BEFORE it is pointed at real data. The predecessor was never tested and had six defects
 * that each made the comparison unable to fail; every one is asserted against here, so the same class of bug
 * cannot return.
 *
 * Each test states the defect it guards, with the value pair that used to pass.
 */

const col = (name: string, type: string, scale: number | null = null) => ({ name, type, scale });

/** Build a one-table, one-case bundle. */
function bundle(
  side: 'desktop' | 'web',
  table: string,
  columns: ReturnType<typeof col>[],
  rows: unknown[][],
  caseId = 'case-1',
): ParityBundle {
  return {
    kind: 'datacare.parity-bundle/1.0',
    side,
    capturedAt: '2026-07-30T00:00:00.000Z',
    source: {
      engine: side === 'desktop' ? 'sqlserver' : 'postgres',
      database: side === 'desktop' ? 'DataCare' : 'datacare',
    },
    scope: { coCode: '01', lcCode: '01' },
    cases: [
      {
        caseId,
        description: 'synthetic',
        voucher: { book: 'SL', vchNo: side === 'desktop' ? '00007' : '00001' },
        tables: { [table]: { columns, rows } satisfies BundleTable },
      } satisfies BundleCase,
    ],
  };
}

describe('parity bundle canonicalisation', () => {
  it('DEFECT 1: dates are compared, not erased', () => {
    // The predecessor returned '' for every Date, so 64 date/datetime columns across 42 tables always
    // matched. A voucher dated 2099 compared equal to one dated 2024.
    const a = canonicalise(new Date('2024-06-10T00:00:00Z'), 'date', 0);
    const b = canonicalise(new Date('2099-01-01T00:00:00Z'), 'date', 0);
    expect(a).toBe('2024-06-10');
    expect(b).toBe('2099-01-01');
    expect(a).not.toBe(b);
  });

  it('DEFECT 1b: a real date is not equal to NULL', () => {
    expect(canonicalise(new Date('2024-06-10T00:00:00Z'), 'date', 0)).not.toBe(
      canonicalise(null, 'date', 0),
    );
    expect(canonicalise(null, 'date', 0)).toBe(NULL_SENTINEL);
  });

  it('preserves time of day on a datetime, rather than truncating to the day', () => {
    const morning = canonicalise(new Date('2024-06-10T09:30:00Z'), 'datetime', 0);
    const evening = canonicalise(new Date('2024-06-10T18:45:00Z'), 'datetime', 0);
    expect(morning).not.toBe(evening);
    expect(morning).toBe('2024-06-10T09:30:00');
  });

  it('DEFECT 2: precision comes from the declared scale', () => {
    // ITM_WEST_PRC is numeric scale 4. Rounding to 3 made 1.5000 and 1.5004 equal.
    const s4 = comparisonScale(
      col('ITM_WEST_PRC', 'numeric', 4),
      col('ITM_WEST_PRC', 'numeric', 4),
    );
    expect(s4).toBe(4);
    expect(canonicalise('1.5000', 'numeric', s4)).not.toBe(canonicalise('1.5004', 'numeric', s4));
    // At the coarser scale the two ARE the same value, which is correct: neither store can distinguish them.
    const s3 = comparisonScale(col('x', 'numeric', 3), col('x', 'numeric', 4));
    expect(s3, 'the coarser of the two declared scales').toBe(3);
    expect(canonicalise('1.5000', 'numeric', s3)).toBe(canonicalise('1.5004', 'numeric', s3));
  });

  it('falls back to a tight default when neither side declares a scale', () => {
    // The desktop declares most numerics as FLOAT, which has no scale.
    expect(comparisonScale(col('x', 'float', null), col('y', 'double precision', null))).toBe(6);
  });

  it('DEFECT 3: NULL and the empty string are different values', () => {
    expect(canonicalise(null, 'varchar', 0)).not.toBe(canonicalise('', 'varchar', 0));
  });

  it('DEFECT 5: text case is preserved', () => {
    // Upper-casing made a genuine code difference invisible.
    expect(canonicalise('abc', 'varchar', 0)).not.toBe(canonicalise('ABC', 'varchar', 0));
  });

  it('normalises Y/N and bit flags to a single representation', () => {
    for (const yes of ['Y', 'y', '1', 'true', true]) {
      expect(canonicalise(yes, 'bit', 0), String(yes)).toBe('1');
    }
    for (const no of ['N', 'n', '0', 'false', false]) {
      expect(canonicalise(no, 'bit', 0), String(no)).toBe('0');
    }
  });

  it('reads a date stored in a varchar column by shape', () => {
    // YEAR_MAST.OP_DATE and several others hold ISO dates in varchar columns.
    expect(canonicalise('2024-06-10 00:00:00', 'date', 0)).toBe('2024-06-10');
    expect(canonicalise('2024-06-10', 'date', 0)).toBe('2024-06-10');
  });

  it('is timezone-proof for text dates', () => {
    // A real bug this test caught: `new Date('2024-06-10 00:00:00')` has no timezone marker, so it is read as
    // LOCAL time, and `toISOString()` then shifted it to 2024-06-09 in a +05:30 zone. Every text date field
    // would have reported a false one-day difference. The components are now read literally.
    expect(process.env.TZ ?? '(system)').toBeDefined();
    for (const shape of [
      '2024-06-10',
      '2024-06-10 00:00:00',
      '2024-06-10T00:00:00',
      '2024-06-10 00:00:00.000',
    ]) {
      expect(canonicalise(shape, 'date', 0), shape).toBe('2024-06-10');
    }
    // And the boundary that would flip: midnight and one minute before midnight stay on their own days.
    expect(canonicalise('2024-06-10 23:59:00', 'date', 0)).toBe('2024-06-10');
    expect(canonicalise('2024-06-11 00:00:00', 'date', 0)).toBe('2024-06-11');
  });

  it('surfaces junk in a numeric column instead of coercing it to zero', () => {
    // Silently reading 'abc' as 0 would make a corrupt value match a legitimate zero.
    expect(canonicalise('abc', 'numeric', 2)).toContain('NaN');
    expect(canonicalise('abc', 'numeric', 2)).not.toBe(canonicalise(0, 'numeric', 2));
  });

  it('treats negative zero as zero', () => {
    expect(canonicalise(-0, 'numeric', 2)).toBe(canonicalise(0, 'numeric', 2));
  });

  it('every exclusion carries a reason, and business fields are NOT excluded', () => {
    for (const [field, reason] of Object.entries(EXCLUDED_FIELDS)) {
      expect(reason.length, `${field} must explain itself`).toBeGreaterThan(20);
    }
    // The predecessor skipped these. VCH_DATE is the accounting date of the voucher; skipping it meant a
    // voucher posted to the wrong day could not be detected.
    for (const field of RECLAIMED_FIELDS) {
      expect(exclusionReason(field), `${field} must be compared`).toBeNull();
    }
  });
});

describe('parity bundle diff', () => {
  const cols = [col('SR_NO', 'int', 0), col('ITM_NWT', 'numeric', 3), col('TOT_AMT', 'numeric', 2)];

  it('reports a match when both sides agree', () => {
    const d = bundle('desktop', 'SL_DETL', cols, [[1, 10.5, 1000]]);
    const w = bundle('web', 'SL_DETL', cols, [[1, 10.5, 1000]]);
    const r = diffBundles(d, w);
    expect(r.matched).toBe(true);
    expect(r.totals.fieldDifferences).toBe(0);
    // The denominator travels with the verdict: "matched" is meaningless without it.
    expect(r.totals.fieldsCompared).toBeGreaterThan(0);
  });

  it('DEFECT 6: a table the web never wrote is a finding, not an exclusion', () => {
    // The predecessor intersected the two schemas, so a missing write was silently dropped — the single most
    // important parity failure it could have caught.
    const d: ParityBundle = bundle('desktop', 'SL_DETL', cols, [[1, 10.5, 1000]]);
    d.cases[0]!.tables.TAX_DATA = {
      columns: [col('TAX_CODE', 'varchar', null), col('IT_TAX_AMT', 'numeric', 2)],
      rows: [['CGST', 15]],
    };
    const w = bundle('web', 'SL_DETL', cols, [[1, 10.5, 1000]]);

    const r = diffBundles(d, w);
    expect(r.matched, 'a missing write must fail the comparison').toBe(false);
    expect(r.totals.tablesDesktopOnly).toBe(1);
    const tax = r.cases[0]!.tables.find((t) => t.table === 'TAX_DATA')!;
    expect(tax.presentOn).toBe('desktop-only');
    expect(tax.missingRows.length).toBe(1);
    expect(formatDiff(r)).toContain('WEB NEVER WROTE THIS TABLE');
  });

  it('DEFECT 4: per-row comparison catches compensating differences', () => {
    // Column sums matched [100,-100] against [250,-250]. Every row is compared now.
    const d = bundle(
      'desktop',
      'AC_DATA',
      [col('AC_CODE', 'varchar', null), col('DR_AMT', 'numeric', 2), col('CR_AMT', 'numeric', 2)],
      [
        ['CASH', 100, 0],
        ['SALES', 0, 100],
      ],
    );
    const w = bundle(
      'web',
      'AC_DATA',
      [col('AC_CODE', 'varchar', null), col('DR_AMT', 'numeric', 2), col('CR_AMT', 'numeric', 2)],
      [
        ['CASH', 250, 0],
        ['SALES', 0, 250],
      ],
    );
    const r = diffBundles(d, w);
    expect(r.matched).toBe(false);
    // AC_DATA is keyed by account AND amounts, so a changed amount reads as a missing + extra row.
    const ac = r.cases[0]!.tables.find((t) => t.table === 'AC_DATA')!;
    expect(ac.missingRows.length + ac.extraRows.length).toBeGreaterThan(0);
  });

  it('detects a wrong voucher date, which the predecessor could not', () => {
    const c = [col('SR_NO', 'int', 0), col('VCH_DATE', 'date', null)];
    const d = bundle('desktop', 'SL_DETL', c, [[1, new Date('2024-06-10T00:00:00Z')]]);
    const w = bundle('web', 'SL_DETL', c, [[1, new Date('2024-06-11T00:00:00Z')]]);
    const r = diffBundles(d, w);
    expect(r.matched).toBe(false);
    const diff = r.cases[0]!.tables[0]!.differences.find((x) => x.column === 'VCH_DATE')!;
    expect(diff.desktop).toBe('2024-06-10');
    expect(diff.web).toBe('2024-06-11');
  });

  it('records the actual differing values, not just a count', () => {
    // "17 differences" is not evidence. A reviewer needs to see what disagreed.
    const d = bundle('desktop', 'SL_DETL', cols, [[1, 10.5, 1000]]);
    const w = bundle('web', 'SL_DETL', cols, [[1, 10.5, 1250]]);
    const r = diffBundles(d, w);
    const diff = r.cases[0]!.tables[0]!.differences[0]!;
    expect(diff).toMatchObject({
      table: 'SL_DETL',
      column: 'TOT_AMT',
      desktop: '1000.00',
      web: '1250.00',
      scale: 2,
    });
    expect(diff.rowKey).toContain('SR_NO=1');
  });

  it('pairs rows by business key rather than by position', () => {
    // Index pairing produced phantom differences whenever row order differed. The same two lines in the
    // opposite order must still match.
    const d = bundle('desktop', 'SL_DETL', cols, [
      [1, 10.5, 1000],
      [2, 20.25, 2000],
    ]);
    const w = bundle('web', 'SL_DETL', cols, [
      [2, 20.25, 2000],
      [1, 10.5, 1000],
    ]);
    expect(diffBundles(d, w).matched).toBe(true);
  });

  it('reports a missing row and an extra row separately', () => {
    const d = bundle('desktop', 'SL_DETL', cols, [
      [1, 10.5, 1000],
      [2, 20.25, 2000],
    ]);
    const w = bundle('web', 'SL_DETL', cols, [[1, 10.5, 1000]]);
    const r = diffBundles(d, w);
    expect(r.matched).toBe(false);
    expect(r.cases[0]!.tables[0]!.missingRows).toEqual(['SR_NO=2']);
    expect(r.cases[0]!.tables[0]!.extraRows).toEqual([]);
  });

  it('reports a column the web schema lacks entirely', () => {
    const d = bundle(
      'desktop',
      'SL_DETL',
      [...cols, col('KUNDAN_WT', 'float', null)],
      [[1, 10.5, 1000, 2.5]],
    );
    const w = bundle('web', 'SL_DETL', cols, [[1, 10.5, 1000]]);
    const r = diffBundles(d, w);
    expect(r.matched).toBe(false);
    expect(r.cases[0]!.tables[0]!.missingColumns).toEqual(['KUNDAN_WT']);
  });

  it('a case entered on only one side is not a pass', () => {
    // Otherwise a scenario nobody exercised would count as agreement.
    const d = bundle('desktop', 'SL_DETL', cols, [[1, 10.5, 1000]], 'sale-basic');
    const w = bundle('web', 'SL_DETL', cols, [[1, 10.5, 1000]], 'something-else');
    const r = diffBundles(d, w);
    expect(r.matched).toBe(false);
    expect(r.desktopOnlyCases).toEqual(['sale-basic']);
    expect(r.webOnlyCases).toEqual(['something-else']);
  });

  it('an empty comparison is not a pass', () => {
    // Zero cases must never read as success.
    const empty = { ...bundle('desktop', 'SL_DETL', cols, []), cases: [] };
    const w = { ...bundle('web', 'SL_DETL', cols, []), cases: [] };
    expect(diffBundles(empty, w).matched).toBe(false);
  });

  it('ignores excluded identity fields so they cannot mask real differences', () => {
    const c = [
      col('SR_NO', 'int', 0),
      col('MAIN_USER', 'varchar', null),
      col('TOT_AMT', 'numeric', 2),
    ];
    const d = bundle('desktop', 'SL_DETL', c, [[1, 'desktopuser', 1000]]);
    const w = bundle('web', 'SL_DETL', c, [[1, 'apiuser', 1000]]);
    const r = diffBundles(d, w);
    expect(r.matched, 'operator identity legitimately differs').toBe(true);
    expect(r.totals.fieldsExcluded, 'and the exclusion is counted').toBeGreaterThan(0);
  });
});
