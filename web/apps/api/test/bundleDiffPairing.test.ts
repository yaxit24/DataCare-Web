/**
 * Row pairing across schemas that declare different numeric scales.
 *
 * The two systems do not agree on scale: SQL Server holds `SL_DETL.SR_NO` as `numeric(18,6)` and Postgres as
 * `numeric(_,2)` or an integer. Row KEYS were built with `comparisonScale(hit.column, hit.column)` — the same
 * column twice, meaning each side's own scale — so the same serial rendered `SR_NO=1` on one side and
 * `SR_NO=1.000000` on the other, the keys never matched, and the rows never paired.
 *
 * The consequence was severe and silent: `AC_DATA` (every ledger leg) and `SL_DETL` (every line) were reported
 * as "missing" plus "extra" instead of being diffed. On the first real voucher comparison the differ examined
 * 271 fields; with pairing fixed it examines 540. **Half the comparison surface was never compared**, while the
 * report looked healthy, and a genuine difference in `SL_DETL.ITM_AMT` — 354.00 against 354.20 — went
 * unreported through three consecutive runs.
 *
 * These tests use the smallest bundles that reproduce it, so they fail if the common scale is ever removed.
 */
import { describe, expect, it } from 'vitest';
import { diffBundles } from '../src/modules/parity/bundleDiff.js';

/** A bundle shaped like the real extractors produce, with the declared scale under the caller's control. */
// TWO rows per side, deliberately. `diffBundles` pairs a lone row on each side positionally regardless of its
// key, so a single-row fixture bypasses key construction entirely and cannot detect the defect - a first
// version of this test passed against the broken code for exactly that reason. It also explains which real
// tables were affected: SL_DATA has one row and was compared, while SL_DETL (2 lines) and AC_DATA (3 legs)
// were not.
function bundle(side: 'desktop' | 'web', scale: number | null, rows: unknown[][]) {
  return {
    kind: 'datacare.parity-bundle/1.0',
    side,
    capturedAt: '2026-08-01T00:00:00.000Z',
    source: {
      engine: side === 'desktop' ? 'sqlserver' : 'postgres',
      database: side === 'desktop' ? 'Live24' : 'datacare',
    },
    scope: { coCode: '01', lcCode: '00' },
    cases: [
      {
        caseId: 'sale-027-00001',
        description: 'scale-divergent row key',
        voucher: { book: '027', vchNo: '00001' },
        tables: {
          SL_DETL: {
            columns: [
              { name: 'SR_NO', type: 'numeric', scale },
              { name: 'ITM_AMT', type: 'numeric', scale },
            ],
            rows,
          },
        },
      },
    ],
  };
}

describe('bundle diff row pairing', () => {
  it('pairs rows whose key columns declare different scales', () => {
    // Same serial, same amount. Only the declared scale differs.
    const d = bundle('desktop', 6, [
      [1, 1087],
      [2, 354],
    ]);
    const w = bundle('web', 2, [
      [1, 1087],
      [2, 354],
    ]);
    const result = diffBundles(d as never, w as never);
    const c = result.cases[0]!.tables.find((t) => t.table === 'SL_DETL')!;
    expect(c.missingRows).toEqual([]);
    expect(c.extraRows).toEqual([]);
    // Paired, so the fields were actually compared rather than skipped.
    expect(c.fieldsCompared).toBeGreaterThan(0);
    expect(c.differences).toEqual([]);
  });

  it('reports a real difference once the rows pair, instead of hiding it as missing plus extra', () => {
    // This is the exact difference that went unreported: the desktop rounds the component, the web does not.
    const d = bundle('desktop', 6, [
      [1, 1087],
      [2, 354],
    ]);
    const w = bundle('web', 2, [
      [1, 1087],
      [2, 354.2],
    ]);
    const c = diffBundles(d as never, w as never).cases[0]!.tables.find(
      (t) => t.table === 'SL_DETL',
    )!;
    expect(c.missingRows).toEqual([]);
    expect(c.extraRows).toEqual([]);
    const cols = c.differences.map((x) => x.column);
    expect(cols).toContain('ITM_AMT');
  });

  it('reports forcedPairs when rows are compared without a key match', () => {
    // A key column that is itself under test guarantees non-pairing. The differ still compares the rows - which
    // is useful - but it must SAY it did so without a key match, because otherwise a broken key on a table
    // whose values happen to agree looks perfectly clean. That is not hypothetical: the first version of the
    // test above passed against broken code for exactly this reason.
    const d = bundle('desktop', 6, [
      [1, 1087],
      [2, 354],
    ]);
    const w = bundle('web', 2, [
      [1, 1087],
      [2, 354],
    ]);
    // Row 1 pairs by key; row 2 does not. That leaves exactly ONE unpaired row on each side, which is the
    // condition under which the differ forces a pair - and the condition it must report.
    (w.cases[0]!.tables as Record<string, { rows: unknown[][] }>).SL_DETL!.rows = [
      [1, 1087],
      [9, 354],
    ];
    const c = diffBundles(d as never, w as never).cases[0]!.tables.find(
      (t) => t.table === 'SL_DETL',
    )!;
    // 2 rows each, none pairing by key: one gets forced, the rest are missing/extra.
    expect(c.forcedPairs).toBeGreaterThan(0);
  });

  it('reports forcedPairs as zero when every row pairs by key', () => {
    const d = bundle('desktop', 6, [
      [1, 1087],
      [2, 354],
    ]);
    const w = bundle('web', 2, [
      [1, 1087],
      [2, 354],
    ]);
    const c = diffBundles(d as never, w as never).cases[0]!.tables.find(
      (t) => t.table === 'SL_DETL',
    )!;
    expect(c.forcedPairs).toBe(0);
  });

  it('still reports a genuinely absent row as missing', () => {
    // The pairing fix must not make everything pair. A row the web never wrote is still missing.
    const d = bundle('desktop', 6, [
      [1, 1087],
      [2, 354],
    ]);
    const w = bundle('web', 2, [[1, 1087]]);
    const c = diffBundles(d as never, w as never).cases[0]!.tables.find(
      (t) => t.table === 'SL_DETL',
    )!;
    expect(c.missingRows.length).toBe(1);
  });
});
