/**
 * Parity ratchet — turns the desktop comparison into a number that must improve.
 *
 * WHY THIS EXISTS ALONGSIDE THE G5 GATE
 * =====================================
 * `check-g5-parity.mjs` answers one question correctly: is the web at parity with the desktop? Today the answer
 * is no, and it will stay no for a long time. A gate that only says "not yet" cannot tell anyone whether a
 * month of work helped.
 *
 * That is not hypothetical. The comparison went unrun for a month; when it was finally run, 1,354 of its 3,787
 * field differences turned out to be already fixed by code that had landed weeks earlier, and nobody knew —
 * the web-side bundle predated the fix. Work was invisible in both directions: real progress unmeasured, and a
 * regression would have been equally unmeasured.
 *
 * So this module records the measured counts and refuses a run in which any of them got worse. It is a
 * progress instrument, not a parity certificate; `check-g5-parity.mjs` remains the certificate.
 *
 * WHY IT CANNOT BE GAMED
 * ======================
 * Every obvious way to make a difference count fall without fixing anything is itself a failure:
 *
 *   * comparing FEWER fields             -> `fieldsCompared` must not fall
 *   * excluding more columns             -> `fieldsExcluded` must not rise
 *   * deleting inconvenient cases        -> a reduced case set is refused outright
 *   * comparing fewer tables             -> `tablesCompared` must not fall
 *   * adding easy cases to dilute a rate -> an expanded set is compared PER CASE, not in total
 *
 * The last rule matters because Phase 1 of the parity plan deliberately expands the case set from 66 towards
 * ~300. Absolute counts must rise then, and a naive ratchet would either block that work or be switched off
 * for it.
 *
 * Normalising totals per case does not work either, and the first version of this module got it wrong: metrics
 * like `tablesCompared` and `fieldsCompared` are sums over cases, so their per-case average moves with the
 * COMPOSITION of the set. Adding sixty simple cash sales that touch four tables each, alongside purchases that
 * touch six, lowers the average and would be reported as a regression that never happened.
 *
 * So an expanded set is judged on the cases the two runs SHARE, compared case by case. Added cases are
 * reported and excluded from the verdict. That is exactly the same comparison as the identical-set path, over
 * the subset where a comparison is meaningful, and it leaves no room for dilution.
 */

/** The measurable outcome of one desktop-versus-web comparison. */
export interface ParityMetrics {
  cases: number;
  casesMatched: number;
  tablesCompared: number;
  tablesDesktopOnly: number;
  tablesWebOnly: number;
  fieldsCompared: number;
  fieldsExcluded: number;
  fieldDifferences: number;
  rowsMissing: number;
  rowsExtra: number;
}

/** A recorded ceiling: the metrics of a previous run, and the exact cases it covered. */
export interface ParityRatchetRecord {
  recordedAt: string;
  /** Sorted case identifiers. Stored in full rather than hashed so a reduction can be named, not just detected. */
  caseIds: string[];
  metrics: ParityMetrics;
  /**
   * Per-case metrics, needed to compare a later expanded run over the cases the two runs share.
   * Optional so an older record without it degrades to "no comparison made" rather than a wrong one.
   */
  perCase?: Record<string, ParityMetrics>;
  note?: string;
}

export type CaseSetRelation = 'identical' | 'expanded' | 'reduced' | 'disjoint';

export interface RatchetVerdict {
  ok: boolean;
  /** True when there is no ceiling to compare against, or the case set changed so the ceiling no longer applies. */
  requiresRebaseline: boolean;
  caseSet: CaseSetRelation;
  addedCases: string[];
  removedCases: string[];
  regressions: string[];
  improvements: string[];
  notes: string[];
}

/** Metrics where a HIGHER number is worse. */
const WORSE_WHEN_HIGHER = [
  'fieldDifferences',
  'rowsMissing',
  'rowsExtra',
  'tablesDesktopOnly',
  'tablesWebOnly',
  'fieldsExcluded',
] as const satisfies readonly (keyof ParityMetrics)[];

/**
 * Metrics where a LOWER number is worse.
 *
 * These are the anti-gaming half. Without them the cheapest way to a green ratchet is to compare less: drop a
 * table, exclude a column, stop matching a case.
 */
const WORSE_WHEN_LOWER = [
  'casesMatched',
  'fieldsCompared',
  'tablesCompared',
] as const satisfies readonly (keyof ParityMetrics)[];

const fmt = (n: number): string =>
  Number.isInteger(n) ? String(n) : n.toFixed(4).replace(/0+$/, '').replace(/\.$/, '');

const ZERO: ParityMetrics = {
  cases: 0,
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

const ALL_KEYS = [...WORSE_WHEN_HIGHER, ...WORSE_WHEN_LOWER];

/** Sum the metrics of the named cases. Used to compare two runs over exactly the cases they share. */
function sumOver(
  caseIds: readonly string[],
  perCase: Readonly<Record<string, ParityMetrics>>,
): ParityMetrics {
  const out: ParityMetrics = { ...ZERO };
  for (const id of caseIds) {
    const m = perCase[id];
    if (!m) continue;
    out.cases += 1;
    for (const key of ALL_KEYS) out[key] += Number(m[key] ?? 0);
  }
  return out;
}

export function compareCaseSets(current: string[], recorded: string[]): CaseSetRelation {
  const a = new Set(current);
  const b = new Set(recorded);
  const missing = recorded.filter((id) => !a.has(id));
  const added = current.filter((id) => !b.has(id));
  if (!missing.length && !added.length) return 'identical';
  if (!missing.length) return 'expanded';
  if (!added.length) return 'reduced';
  return 'disjoint';
}

/**
 * Decide whether a comparison result may be accepted against a recorded ceiling.
 *
 * `recorded` of `null` means no ceiling exists yet: the run is accepted and reported as needing a baseline.
 * That is deliberate — refusing the first run would mean the ratchet could never be adopted.
 */
export function evaluateRatchet(
  current: { metrics: ParityMetrics; caseIds: string[]; perCase?: Record<string, ParityMetrics> },
  recorded: ParityRatchetRecord | null,
): RatchetVerdict {
  const caseIds = [...current.caseIds].sort();
  const verdict: RatchetVerdict = {
    ok: true,
    requiresRebaseline: false,
    caseSet: 'identical',
    addedCases: [],
    removedCases: [],
    regressions: [],
    improvements: [],
    notes: [],
  };

  if (!recorded) {
    verdict.requiresRebaseline = true;
    verdict.notes.push(
      `no recorded ceiling: this run establishes one (${caseIds.length} cases, ` +
        `${current.metrics.fieldDifferences} field differences)`,
    );
    return verdict;
  }

  const recordedIds = [...recorded.caseIds].sort();
  verdict.caseSet = compareCaseSets(caseIds, recordedIds);
  const present = new Set(caseIds);
  verdict.removedCases = recordedIds.filter((id) => !present.has(id));
  const known = new Set(recordedIds);
  verdict.addedCases = caseIds.filter((id) => !known.has(id));

  // Removing a case cannot be progress: the evidence it carried is simply gone. This is refused before any
  // metric is examined, because every metric would look better for the wrong reason.
  if (verdict.removedCases.length) {
    verdict.ok = false;
    verdict.regressions.push(
      `${verdict.removedCases.length} case(s) present in the ceiling are absent from this run: ` +
        `${verdict.removedCases.slice(0, 8).join(', ')}${verdict.removedCases.length > 8 ? ', …' : ''}`,
    );
    return verdict;
  }

  // Compare over exactly the cases both runs contain. For an identical set that is the whole run, and the
  // recorded totals are used directly so the ratchet does not depend on per-case detail being retained.
  let nowMetrics = current.metrics;
  let wasMetrics = recorded.metrics;
  let scope = '';

  if (verdict.caseSet === 'expanded') {
    verdict.requiresRebaseline = true;
    if (current.perCase && recorded.perCase) {
      nowMetrics = sumOver(recordedIds, current.perCase);
      wasMetrics = sumOver(recordedIds, recorded.perCase);
      scope = ` over the ${recordedIds.length} shared case(s)`;
      verdict.notes.push(
        `case set expanded by ${verdict.addedCases.length} (${recordedIds.length} → ${caseIds.length}); ` +
          `compared over the ${recordedIds.length} shared case(s), and the ceiling should be re-recorded`,
      );
    } else {
      // Without per-case detail on both sides the shared subset cannot be isolated, and comparing totals
      // across different case sets would be meaningless. Say so instead of guessing.
      verdict.notes.push(
        `case set expanded by ${verdict.addedCases.length} (${recordedIds.length} → ${caseIds.length}); ` +
          'per-case metrics are absent on one side, so no comparison was made — re-record the ceiling',
      );
      return verdict;
    }
  }

  const check = (
    key: keyof ParityMetrics,
    direction: 'higher-is-worse' | 'lower-is-worse',
  ): void => {
    const a = Number(nowMetrics[key] ?? 0);
    const b = Number(wasMetrics[key] ?? 0);
    const worse = direction === 'higher-is-worse' ? a > b : a < b;
    const better = direction === 'higher-is-worse' ? a < b : a > b;
    if (worse) {
      verdict.ok = false;
      verdict.regressions.push(`${key} worsened${scope}: ${fmt(b)} → ${fmt(a)}`);
    } else if (better) {
      verdict.improvements.push(`${key} improved${scope}: ${fmt(b)} → ${fmt(a)}`);
    }
  };

  for (const key of WORSE_WHEN_HIGHER) check(key, 'higher-is-worse');
  for (const key of WORSE_WHEN_LOWER) check(key, 'lower-is-worse');

  return verdict;
}

/** Per-case metrics keyed by case id, for the shared-case comparison an expanded run needs. */
export function perCaseFromDiff(report: {
  cases?: Array<{ caseId?: string; totals?: Record<string, unknown> }>;
}): Record<string, ParityMetrics> {
  const out: Record<string, ParityMetrics> = {};
  for (const c of report.cases ?? []) {
    const id = String(c.caseId ?? '').trim();
    if (!id) continue;
    out[id] = metricsFromDiff(c);
  }
  return out;
}

/** Extract the metrics this ratchet tracks from a `datacare.parity-diff/1.0` artefact. */
export function metricsFromDiff(report: { totals?: Record<string, unknown> }): ParityMetrics {
  const t = report.totals ?? {};
  const n = (key: string): number => {
    const v = Number(t[key]);
    return Number.isFinite(v) ? v : 0;
  };
  return {
    cases: n('cases'),
    casesMatched: n('casesMatched'),
    tablesCompared: n('tablesCompared'),
    tablesDesktopOnly: n('tablesDesktopOnly'),
    tablesWebOnly: n('tablesWebOnly'),
    fieldsCompared: n('fieldsCompared'),
    fieldsExcluded: n('fieldsExcluded'),
    fieldDifferences: n('fieldDifferences'),
    rowsMissing: n('rowsMissing'),
    rowsExtra: n('rowsExtra'),
  };
}

/**
 * The share of compared fields that agree.
 *
 * Reported rather than gated: it is the number a reader wants ("how close are we?"), but it moves for reasons
 * the gate must judge separately — comparing fewer fields raises it.
 */
export function agreementPct(m: ParityMetrics): number {
  if (!(m.fieldsCompared > 0)) return 0;
  return ((m.fieldsCompared - m.fieldDifferences) / m.fieldsCompared) * 100;
}
