import assert from 'node:assert/strict';

const isRecord = (value) => value !== null && typeof value === 'object' && !Array.isArray(value);

function indicatorKind(key) {
  const normalized = key.toLowerCase();
  if (!/(mock|intercept)/.test(normalized)) return null;
  if (normalized.includes('mock') && normalized.includes('request')) return 'mockedRequests';
  if (normalized.includes('mock') && normalized.includes('response')) return 'mockedResponses';
  return 'interceptionIndicators';
}

function indicatorCount(kind, value) {
  if (typeof value === 'number' && Number.isSafeInteger(value) && value >= 0) return value;
  if (kind !== 'interceptionIndicators') return null;
  if (typeof value === 'boolean') return value ? 1 : 0;
  if (Array.isArray(value)) return value.length;
  return null;
}

function collectIndicators(value, path, totals, problems, seen) {
  if ((!isRecord(value) && !Array.isArray(value)) || seen.has(value)) return;
  seen.add(value);
  if (Array.isArray(value)) {
    value.forEach((child, index) =>
      collectIndicators(child, `${path}[${index}]`, totals, problems, seen),
    );
    return;
  }
  for (const [key, child] of Object.entries(value)) {
    const childPath = `${path}.${key}`;
    const kind = indicatorKind(key);
    if (kind) {
      const count = indicatorCount(kind, child);
      if (count === null)
        problems.push(
          kind === 'interceptionIndicators'
            ? `${childPath} must be a non-negative count or boolean`
            : `${childPath} must be a non-negative integer`,
        );
      else {
        totals[kind] += count;
        if (count !== 0) problems.push(`${childPath} reports ${count}`);
      }
      continue;
    }
    collectIndicators(child, childPath, totals, problems, seen);
  }
}

/** Convert one completed journey's assertion-backed result into bounded certification evidence. */
export function summarizeJourneyEvidence(journeyId, detail) {
  assert.match(journeyId, /^[a-z0-9]+(?:-[a-z0-9]+)*$/, 'invalid journey id');
  const totals = { mockedRequests: 0, mockedResponses: 0, interceptionIndicators: 0 };
  const problems = [];
  if (!isRecord(detail)) problems.push('journey did not return a result object');
  else {
    if (
      !Array.isArray(detail.checks) ||
      detail.checks.length === 0 ||
      detail.checks.some((check) => typeof check !== 'string' || check.trim() === '')
    )
      problems.push('journey did not report nonempty checks');
    if (detail.status !== undefined && detail.status !== 'passed')
      problems.push(`journey status is ${String(detail.status)}`);
    collectIndicators(detail, journeyId, totals, problems, new Set());
  }
  return {
    journey: { journeyId, status: problems.length === 0 ? 'passed' : 'failed' },
    provenance: totals,
    problems,
  };
}

/** Aggregate journey counters plus interception registrations observed by the runner itself. */
export function aggregateRealStackEvidence(summaries, runnerInterceptionRegistrations = 0) {
  assert(
    Number.isSafeInteger(runnerInterceptionRegistrations) && runnerInterceptionRegistrations >= 0,
    'runner interception registrations must be a non-negative integer',
  );
  const totals = {
    mockedRequests: 0,
    mockedResponses: 0,
    interceptionIndicators: runnerInterceptionRegistrations,
  };
  const problems = [];
  for (const summary of summaries) {
    totals.mockedRequests += summary.provenance.mockedRequests;
    totals.mockedResponses += summary.provenance.mockedResponses;
    totals.interceptionIndicators += summary.provenance.interceptionIndicators;
    problems.push(...summary.problems);
  }
  if (runnerInterceptionRegistrations !== 0)
    problems.push(
      `runner registered ${runnerInterceptionRegistrations} request interception route(s)`,
    );
  return { ...totals, problems };
}
