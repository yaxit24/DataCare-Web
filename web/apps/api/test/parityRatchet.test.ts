import { describe, expect, it } from 'vitest';
import {
  agreementPct,
  compareCaseSets,
  evaluateRatchet,
  metricsFromDiff,
  type ParityMetrics,
  type ParityRatchetRecord,
} from '../src/modules/ops/parityRatchet.js';

/**
 * The ratchet's whole value is that it cannot be satisfied by measuring less. Each test below is one route
 * someone could take to a green run without fixing anything, and asserts that the route is refused.
 */

const BASE: ParityMetrics = {
  cases: 66,
  casesMatched: 0,
  tablesCompared: 368,
  tablesDesktopOnly: 53,
  tablesWebOnly: 105,
  fieldsCompared: 23574,
  fieldsExcluded: 1625,
  fieldDifferences: 3787,
  rowsMissing: 210,
  rowsExtra: 210,
};

const ZERO_CASE: ParityMetrics = {
  cases: 1,
  casesMatched: 0,
  tablesCompared: 0,
  tablesDesktopOnly: 0,
  tablesWebOnly: 0,
  fieldsCompared: 0,
  fieldsExcluded: 0,
  fieldDifferences: 0,
  rowsMissing: 0,
  rowsExtra: 0,
};

const ids = (n: number, prefix = 'purc'): string[] =>
  Array.from({ length: n }, (_, i) => `${prefix}-${String(i + 1).padStart(3, '0')}`);

const ceiling = (over: Partial<ParityMetrics> = {}, caseIds = ids(66)): ParityRatchetRecord => ({
  recordedAt: '2026-08-30T00:00:00.000Z',
  caseIds,
  metrics: { ...BASE, ...over },
});

describe('parity ratchet', () => {
  it('accepts the first run and asks for a baseline instead of refusing it', () => {
    const v = evaluateRatchet({ metrics: BASE, caseIds: ids(66) }, null);
    expect(v.ok).toBe(true);
    expect(v.requiresRebaseline).toBe(true);
    expect(v.notes.join(' ')).toContain('no recorded ceiling');
  });

  it('accepts an unchanged run', () => {
    const v = evaluateRatchet({ metrics: BASE, caseIds: ids(66) }, ceiling());
    expect(v.ok).toBe(true);
    expect(v.caseSet).toBe('identical');
    expect(v.regressions).toEqual([]);
    expect(v.improvements).toEqual([]);
  });

  it('reports real progress as improvement', () => {
    const v = evaluateRatchet(
      { metrics: { ...BASE, fieldDifferences: 2433, rowsMissing: 0 }, caseIds: ids(66) },
      ceiling(),
    );
    expect(v.ok).toBe(true);
    expect(v.improvements.join(' ')).toContain('fieldDifferences improved: 3787 → 2433');
    expect(v.improvements.join(' ')).toContain('rowsMissing improved: 210 → 0');
  });

  it('refuses a genuine regression', () => {
    const v = evaluateRatchet(
      { metrics: { ...BASE, fieldDifferences: 3788 }, caseIds: ids(66) },
      ceiling(),
    );
    expect(v.ok).toBe(false);
    expect(v.regressions.join(' ')).toContain('fieldDifferences worsened: 3787 → 3788');
  });

  // --- The gaming routes ------------------------------------------------------------------------

  it('refuses comparing fewer fields, which is the cheapest fake improvement', () => {
    // Drop half the fields and most differences vanish with them.
    const v = evaluateRatchet(
      { metrics: { ...BASE, fieldsCompared: 12000, fieldDifferences: 1800 }, caseIds: ids(66) },
      ceiling(),
    );
    expect(v.ok).toBe(false);
    expect(v.regressions.join(' ')).toContain('fieldsCompared worsened');
  });

  it('refuses excluding more columns', () => {
    const v = evaluateRatchet(
      { metrics: { ...BASE, fieldsExcluded: 4000, fieldDifferences: 1200 }, caseIds: ids(66) },
      ceiling(),
    );
    expect(v.ok).toBe(false);
    expect(v.regressions.join(' ')).toContain('fieldsExcluded worsened');
  });

  it('refuses comparing fewer tables', () => {
    const v = evaluateRatchet(
      { metrics: { ...BASE, tablesCompared: 200, fieldDifferences: 900 }, caseIds: ids(66) },
      ceiling(),
    );
    expect(v.ok).toBe(false);
    expect(v.regressions.join(' ')).toContain('tablesCompared worsened');
  });

  it('refuses deleting cases, and names the ones that went missing', () => {
    const v = evaluateRatchet(
      { metrics: { ...BASE, cases: 40, fieldDifferences: 100 }, caseIds: ids(40) },
      ceiling(),
    );
    expect(v.ok).toBe(false);
    expect(v.caseSet).toBe('reduced');
    expect(v.removedCases).toHaveLength(26);
    expect(v.regressions.join(' ')).toContain('purc-041');
    // Refused BEFORE metrics are examined: a deleted case makes every metric look better.
    expect(v.regressions).toHaveLength(1);
  });

  it('refuses un-matching a case that used to match', () => {
    const v = evaluateRatchet(
      { metrics: { ...BASE, casesMatched: 2 }, caseIds: ids(66) },
      ceiling({ casesMatched: 3 }),
    );
    expect(v.ok).toBe(false);
    expect(v.regressions.join(' ')).toContain('casesMatched worsened: 3 → 2');
  });

  // --- Expanding the case set, which Phase 1 requires -------------------------------------------

  const flat = (over: Partial<ParityMetrics> = {}): ParityMetrics => ({
    ...ZERO_CASE,
    ...over,
  });

  it('allows absolute growth when the case set expands, comparing only shared cases', () => {
    // 66 known cases unchanged, 66 new ones added. Every total roughly doubles; nothing regressed.
    const recordedPerCase = Object.fromEntries(
      ids(66).map((id) => [
        id,
        flat({ fieldDifferences: 57, tablesCompared: 6, fieldsCompared: 357 }),
      ]),
    );
    const currentPerCase = {
      ...recordedPerCase,
      ...Object.fromEntries(
        // The added cases are simpler: fewer tables each. Averaging totals per case would call that a
        // regression; comparing shared cases correctly does not.
        ids(66, 'sale').map((id) => [
          id,
          flat({ fieldDifferences: 20, tablesCompared: 3, fieldsCompared: 120 }),
        ]),
      ),
    };
    const v = evaluateRatchet(
      {
        metrics: { ...BASE, cases: 132, fieldDifferences: 5082, tablesCompared: 594 },
        caseIds: [...ids(66), ...ids(66, 'sale')],
        perCase: currentPerCase,
      },
      { ...ceiling(), perCase: recordedPerCase },
    );
    expect(v.caseSet).toBe('expanded');
    expect(v.ok).toBe(true);
    expect(v.requiresRebaseline).toBe(true);
    expect(v.notes.join(' ')).toContain('66 shared case(s)');
  });

  it('still refuses a regression on a shared case hidden inside an expansion', () => {
    const recordedPerCase = Object.fromEntries(
      ids(66).map((id) => [
        id,
        flat({ fieldDifferences: 57, tablesCompared: 6, fieldsCompared: 357 }),
      ]),
    );
    const currentPerCase = { ...recordedPerCase };
    // One retained case got worse. Adding sixty clean cases must not hide it.
    currentPerCase['purc-001'] = flat({
      fieldDifferences: 99,
      tablesCompared: 6,
      fieldsCompared: 357,
    });
    for (const id of ids(66, 'sale')) currentPerCase[id] = flat({ fieldsCompared: 10 });
    const v = evaluateRatchet(
      {
        metrics: { ...BASE, cases: 132 },
        caseIds: [...ids(66), ...ids(66, 'sale')],
        perCase: currentPerCase,
      },
      { ...ceiling(), perCase: recordedPerCase },
    );
    expect(v.ok).toBe(false);
    expect(v.regressions.join(' ')).toContain(
      'fieldDifferences worsened over the 66 shared case(s)',
    );
  });

  it('refuses to guess when an expanded run has no per-case detail to compare', () => {
    const v = evaluateRatchet(
      {
        metrics: { ...BASE, cases: 132, fieldDifferences: 10 },
        caseIds: [...ids(66), ...ids(66, 'sale')],
      },
      ceiling(),
    );
    expect(v.caseSet).toBe('expanded');
    expect(v.requiresRebaseline).toBe(true);
    expect(v.regressions).toEqual([]);
    expect(v.improvements).toEqual([]);
    expect(v.notes.join(' ')).toContain('no comparison was made');
  });

  it('treats a swapped case set as reduced, not expanded', () => {
    const v = evaluateRatchet(
      { metrics: { ...BASE, fieldDifferences: 0 }, caseIds: ids(66, 'other') },
      ceiling(),
    );
    expect(v.ok).toBe(false);
    expect(v.caseSet).toBe('disjoint');
    expect(v.regressions.join(' ')).toContain('absent from this run');
  });

  it('classifies case-set relations', () => {
    expect(compareCaseSets(['a', 'b'], ['a', 'b'])).toBe('identical');
    expect(compareCaseSets(['a', 'b', 'c'], ['a', 'b'])).toBe('expanded');
    expect(compareCaseSets(['a'], ['a', 'b'])).toBe('reduced');
    expect(compareCaseSets(['c'], ['a'])).toBe('disjoint');
    // Order must not matter: the sets are compared, not the listings.
    expect(compareCaseSets(['b', 'a'], ['a', 'b'])).toBe('identical');
  });

  // --- Reading the artefact ---------------------------------------------------------------------

  it('reads the metrics out of a real diff artefact shape', () => {
    const m = metricsFromDiff({
      totals: {
        cases: 66,
        casesMatched: 0,
        tablesCompared: 368,
        tablesDesktopOnly: 53,
        tablesWebOnly: 105,
        fieldsCompared: 23574,
        fieldsExcluded: 1625,
        fieldDifferences: 3787,
        rowsMissing: 210,
        rowsExtra: 210,
      },
    });
    expect(m).toEqual(BASE);
  });

  it('treats absent or non-numeric totals as zero rather than NaN', () => {
    const m = metricsFromDiff({ totals: { cases: 'many', fieldDifferences: null } });
    expect(m.cases).toBe(0);
    expect(m.fieldDifferences).toBe(0);
    expect(Number.isNaN(m.rowsMissing)).toBe(false);
  });

  it('reports agreement as a share of compared fields, and 0 when nothing was compared', () => {
    expect(agreementPct(BASE)).toBeCloseTo(83.94, 1);
    expect(agreementPct({ ...BASE, fieldsCompared: 0 })).toBe(0);
  });
});
