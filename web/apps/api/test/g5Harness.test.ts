import { describe, expect, it } from 'vitest';
import {
  aggregateLiveReport,
  buildDegradedReport,
  buildFormArtifact,
  type G5LiveChecks,
} from '../src/modules/parity/g5Harness.js';
import type { ParityResult } from '../src/modules/parity/golden.js';

const generatedAt = '2026-07-28T00:00:00.000Z';
const golden = (failed = 0): ParityResult => ({
  passed: 14 - failed,
  failed,
  total: 14,
  results: [],
});
const passedChecks = (): G5LiveChecks => ({
  sigma: { status: 'passed', result: { numericSumDiff: 0 } },
  footprint: { status: 'passed', result: { footprintDiffCount: 0 } },
  voucherColumns: { status: 'passed', result: { columnDiffCount: 0 } },
  calcRecomputation: { status: 'passed', result: { unexplainedDiffCount: 0 } },
});

function zeroDiffForm() {
  return buildFormArtifact(generatedAt, {
    formId: 'TR_SALE',
    tablesCompared: ['SL_DETL', 'SL_DATA', 'SL_DATA'],
    columnDiffCount: 0,
    numericSumDiff: 0,
    footprintDiffCount: 0,
    completed: true,
  });
}

describe('G5 harness report logic', () => {
  it('aggregates a complete zero-diff live comparison into a passing report', () => {
    const report = aggregateLiveReport({
      generatedAt,
      golden: golden(),
      identity: { host: 'desktop.internal', port: 1433, database: 'Next24' },
      checks: passedChecks(),
      forms: [zeroDiffForm()],
    });

    expect(report).toMatchObject({
      mode: 'LIVE',
      verdict: 'passed',
      source: { configured: true, reachable: true },
      goldenVectors: { status: 'passed' },
      skippedChecks: [],
    });
    expect(report.forms[0]).toMatchObject({
      formId: 'TR_SALE',
      tablesCompared: ['SL_DATA', 'SL_DETL'],
      verdict: 'zero-diff',
    });
  });

  it('uses an honest DEGRADED fallback and records every skipped live check', () => {
    const report = buildDegradedReport({
      generatedAt,
      golden: golden(),
      sourceConfigured: false,
      reason: 'CUTOVER_SOURCE_HOST is not configured.',
    });

    expect(report.mode).toBe('DEGRADED');
    expect(report.verdict).toBe('degraded');
    expect(report.forms).toEqual([]);
    expect(report.skippedChecks.map(({ check }) => check)).toEqual([
      'sigma',
      'footprint',
      'voucherColumns',
      'calcRecomputation',
    ]);
    expect(
      Object.values(report.checks).every(
        (check) => check.status === 'skipped' && check.reason?.includes('not configured'),
      ),
    ).toBe(true);
  });

  it.each([
    ['column', { columnDiffCount: 1, numericSumDiff: 0, footprintDiffCount: 0 }],
    ['numeric sum', { columnDiffCount: 0, numericSumDiff: 1, footprintDiffCount: 0 }],
    ['footprint', { columnDiffCount: 0, numericSumDiff: 0, footprintDiffCount: 1 }],
  ])('fails a form and the aggregate when any %s diff is nonzero', (_name, metrics) => {
    const form = buildFormArtifact(generatedAt, {
      formId: 'TR_SALE',
      tablesCompared: ['SL_DATA'],
      completed: true,
      ...metrics,
    });
    const report = aggregateLiveReport({
      generatedAt,
      golden: golden(),
      identity: { host: 'desktop.internal', port: 1433, database: 'Next24' },
      checks: passedChecks(),
      forms: [form],
    });

    expect(form.verdict).toBe('diff');
    expect(report.verdict).toBe('failed');
  });

  it('fails rather than inventing zero metrics for an incomplete form', () => {
    const form = buildFormArtifact(generatedAt, {
      formId: 'TR_PURC',
      tablesCompared: [],
      columnDiffCount: null,
      numericSumDiff: null,
      footprintDiffCount: null,
      completed: false,
      error: 'query timed out',
    });

    expect(form.verdict).toBe('incomplete');
  });
});
