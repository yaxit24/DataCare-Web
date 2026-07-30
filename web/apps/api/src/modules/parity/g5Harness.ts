import type { ParityResult } from './golden.js';

export type G5CheckStatus = 'passed' | 'failed' | 'skipped';
export type G5Mode = 'DEGRADED' | 'LIVE';
export type G5FormVerdict = 'zero-diff' | 'diff' | 'incomplete';

export interface G5Check<T = unknown> {
  status: G5CheckStatus;
  reason?: string;
  result?: T;
}

export interface G5FormComparisonInput {
  formId: string;
  tablesCompared: string[];
  columnDiffCount: number | null;
  numericSumDiff: number | null;
  footprintDiffCount: number | null;
  completed: boolean;
  error?: string;
}

export interface G5FormArtifact extends G5FormComparisonInput {
  schemaVersion: 1;
  generatedAt: string;
  verdict: G5FormVerdict;
}

export interface G5SourceIdentity {
  host: string;
  port: number;
  database: string;
}

export interface G5LiveChecks {
  sigma: G5Check;
  footprint: G5Check;
  voucherColumns: G5Check;
  calcRecomputation: G5Check;
}

export interface G5Report {
  schemaVersion: 1;
  generatedAt: string;
  mode: G5Mode;
  verdict: 'passed' | 'failed' | 'degraded';
  source: { configured: boolean; reachable: boolean; identity?: G5SourceIdentity };
  goldenVectors: G5Check<ParityResult>;
  checks: G5LiveChecks;
  forms: G5FormArtifact[];
  skippedChecks: Array<{ check: keyof G5LiveChecks; reason: string }>;
  requiredExternalInputs: string[];
}

export const LIVE_CHECK_NAMES: Array<keyof G5LiveChecks> = [
  'sigma',
  'footprint',
  'voucherColumns',
  'calcRecomputation',
];

export const REQUIRED_EXTERNAL_INPUTS = [
  'A reachable desktop SQL Server runtime containing sanitized representative shop data.',
  'Read-only desktop source credentials in CUTOVER_SOURCE_* environment variables.',
  'A matching migrated PostgreSQL target tenant in DATABASE_URL and G5_TARGET_TENANT.',
  'G5_FORMS JSON identifying matching desktop and web vouchers for each form.',
] as const;

function goldenCheck(golden: ParityResult): G5Check<ParityResult> {
  return {
    status: golden.failed === 0 ? 'passed' : 'failed',
    ...(golden.failed ? { reason: `${golden.failed}/${golden.total} golden vectors failed` } : {}),
    result: golden,
  };
}

export function buildFormArtifact(
  generatedAt: string,
  input: G5FormComparisonInput,
): G5FormArtifact {
  const completeMetrics =
    input.completed &&
    input.columnDiffCount !== null &&
    input.numericSumDiff !== null &&
    input.footprintDiffCount !== null;
  const zeroDiff =
    completeMetrics &&
    input.columnDiffCount === 0 &&
    input.numericSumDiff === 0 &&
    input.footprintDiffCount === 0;
  return {
    schemaVersion: 1,
    generatedAt,
    ...input,
    tablesCompared: [...new Set(input.tablesCompared)].sort(),
    verdict: zeroDiff ? 'zero-diff' : completeMetrics ? 'diff' : 'incomplete',
  };
}

export function buildDegradedReport(args: {
  generatedAt: string;
  golden: ParityResult;
  sourceConfigured: boolean;
  sourceReachable?: boolean;
  reason: string;
  identity?: G5SourceIdentity;
}): G5Report {
  const checks = Object.fromEntries(
    LIVE_CHECK_NAMES.map((check) => [check, { status: 'skipped', reason: args.reason }]),
  ) as unknown as G5LiveChecks;
  return {
    schemaVersion: 1,
    generatedAt: args.generatedAt,
    mode: 'DEGRADED',
    verdict: args.golden.failed === 0 ? 'degraded' : 'failed',
    source: {
      configured: args.sourceConfigured,
      reachable: args.sourceReachable ?? false,
      ...(args.identity ? { identity: args.identity } : {}),
    },
    goldenVectors: goldenCheck(args.golden),
    checks,
    forms: [],
    skippedChecks: LIVE_CHECK_NAMES.map((check) => ({ check, reason: args.reason })),
    requiredExternalInputs: [...REQUIRED_EXTERNAL_INPUTS],
  };
}

export function aggregateLiveReport(args: {
  generatedAt: string;
  golden: ParityResult;
  identity: G5SourceIdentity;
  checks: G5LiveChecks;
  forms: G5FormArtifact[];
}): G5Report {
  const skippedChecks = LIVE_CHECK_NAMES.flatMap((check) => {
    const value = args.checks[check];
    return value.status === 'skipped'
      ? [{ check, reason: value.reason ?? 'No reason was recorded.' }]
      : [];
  });
  const liveChecksPass = LIVE_CHECK_NAMES.every((check) => args.checks[check].status === 'passed');
  const formsPass =
    args.forms.length > 0 && args.forms.every((form) => form.verdict === 'zero-diff');
  const passed = args.golden.failed === 0 && liveChecksPass && formsPass;
  return {
    schemaVersion: 1,
    generatedAt: args.generatedAt,
    mode: 'LIVE',
    verdict: passed ? 'passed' : 'failed',
    source: { configured: true, reachable: true, identity: args.identity },
    goldenVectors: goldenCheck(args.golden),
    checks: args.checks,
    forms: args.forms,
    skippedChecks,
    requiredExternalInputs: [],
  };
}
