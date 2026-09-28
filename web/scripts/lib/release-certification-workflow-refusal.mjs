import { readFileSync } from 'node:fs';
import { resolve } from 'node:path';
import { writePreflightRefusalRecord } from './release-certification-record.mjs';

const WORKFLOW_RUN_ID = /^[1-9][0-9]*-[1-9][0-9]*$/;
const COMMIT_SHA = /^[0-9a-f]{40}$/;
const SHA256 = /^[0-9a-f]{64}$/;
const GATE_ID = /^[a-z0-9]+(?:-[a-z0-9]+)*$/;
const GATE_OUTCOME_VALUES = Object.freeze([
  'passed',
  'failed',
  'skipped',
  'missing',
  'red',
  'stale',
  'synthetic',
  'self-approved',
  'unexpected',
  'duplicate',
  'unconfigured',
]);
const GATE_OUTCOMES = new Set(GATE_OUTCOME_VALUES);
const CANDIDATE_COMMIT_FIELDS = Object.freeze(['headSha', 'treeOid']);
const CANDIDATE_SHA256_FIELDS = Object.freeze([
  'lockSha256',
  'schemaSha256',
  'templateSha256',
  'formTemplateSha256',
  'reportTemplateSha256',
]);
const CANDIDATE_POSITIVE_COUNT_FIELDS = Object.freeze([
  'schemaFileCount',
  'templateFileCount',
  'formTemplateFileCount',
  'formSpecCount',
  'formLayoutCount',
  'reportTemplateFileCount',
  'reportSpecCount',
]);

const isPlainObject = (value) =>
  value !== null && typeof value === 'object' && !Array.isArray(value);
const owns = (value, field) => Object.prototype.hasOwnProperty.call(value, field);
const isDigest = (value, pattern) => typeof value === 'string' && pattern.test(value);
const isNullableDigest = (value, pattern) => value === null || isDigest(value, pattern);
const isPositiveSafeInteger = (value) => Number.isSafeInteger(value) && value > 0;
const isNullablePositiveSafeInteger = (value) => value === null || isPositiveSafeInteger(value);
const isNonBlankTrimmedString = (value) =>
  typeof value === 'string' && value.length > 0 && value === value.trim();

const normalizedCommitSha = (value) => {
  const normalized = String(value ?? '')
    .trim()
    .toLowerCase();
  return COMMIT_SHA.test(normalized) ? normalized : null;
};

const hasCommonRecordContract = (record, workflowRunId, releaseSha) =>
  isPlainObject(record) &&
  record.workflowRunId === workflowRunId &&
  releaseSha !== null &&
  record.releaseSha === releaseSha &&
  (record.verdict === 'passed' || record.verdict === 'failed') &&
  typeof record.evaluatedAt === 'string' &&
  !Number.isNaN(Date.parse(record.evaluatedAt)) &&
  isPlainObject(record.candidate);

const hasCandidateRecordContract = (candidate, allowNullIdentity) => {
  if (
    !isPlainObject(candidate) ||
    !owns(candidate, 'clean') ||
    typeof candidate.clean !== 'boolean' ||
    !owns(candidate, 'dirtyPathRecords') ||
    !(
      candidate.dirtyPathRecords === null ||
      (Number.isSafeInteger(candidate.dirtyPathRecords) && candidate.dirtyPathRecords >= 0)
    ) ||
    candidate.clean !== (candidate.dirtyPathRecords === 0)
  ) {
    return false;
  }

  for (const field of CANDIDATE_COMMIT_FIELDS) {
    if (!owns(candidate, field) || !isNullableDigest(candidate[field], COMMIT_SHA)) return false;
  }
  for (const field of CANDIDATE_SHA256_FIELDS) {
    if (!owns(candidate, field) || !isNullableDigest(candidate[field], SHA256)) return false;
  }
  for (const field of CANDIDATE_POSITIVE_COUNT_FIELDS) {
    if (!owns(candidate, field) || !isNullablePositiveSafeInteger(candidate[field])) return false;
  }

  if (!allowNullIdentity) {
    const identityFields = [
      ...CANDIDATE_COMMIT_FIELDS,
      ...CANDIDATE_SHA256_FIELDS,
      ...CANDIDATE_POSITIVE_COUNT_FIELDS,
    ];
    if (
      !candidate.clean ||
      candidate.dirtyPathRecords !== 0 ||
      identityFields.some((field) => candidate[field] === null)
    ) {
      return false;
    }
  }
  return true;
};

const hasNullableDigestField = (record, field) =>
  owns(record, field) && isNullableDigest(record[field], SHA256);

const hasPreflightRecordContract = (record) =>
  record.kind === 'datacare.release-certification-preflight/1.0' &&
  record.verdict === 'failed' &&
  record.stage === 'preflight' &&
  record.gatesRun === 0 &&
  Array.isArray(record.problems) &&
  record.problems.length > 0 &&
  record.problems.every(isNonBlankTrimmedString) &&
  hasNullableDigestField(record, 'requirementSetHash') &&
  hasNullableDigestField(record, 'approvedRequirementSetHash') &&
  hasNullableDigestField(record, 'certifierSourceSha256') &&
  hasCandidateRecordContract(record.candidate, true);

const hasGateContract = (gate) =>
  isPlainObject(gate) &&
  isNonBlankTrimmedString(gate.id) &&
  GATE_ID.test(gate.id) &&
  isNonBlankTrimmedString(gate.title) &&
  isNonBlankTrimmedString(gate.reason) &&
  GATE_OUTCOMES.has(gate.outcome);

const hasTotalsContract = (totals, gates) => {
  if (
    !isPlainObject(totals) ||
    Object.keys(totals).length !== GATE_OUTCOME_VALUES.length ||
    !Object.keys(totals).every((outcome) => GATE_OUTCOMES.has(outcome))
  ) {
    return false;
  }
  return GATE_OUTCOME_VALUES.every(
    (outcome) =>
      owns(totals, outcome) &&
      Number.isSafeInteger(totals[outcome]) &&
      totals[outcome] >= 0 &&
      totals[outcome] === gates.filter((gate) => gate.outcome === outcome).length,
  );
};

const hasFinalRecordContract = (record) => {
  if (
    record.kind !== 'datacare.release-certification/1.0' ||
    !(typeof record.freshnessWindowHours === 'number') ||
    !Number.isFinite(record.freshnessWindowHours) ||
    record.freshnessWindowHours <= 0 ||
    !isDigest(record.requirementSetHash, SHA256) ||
    !isDigest(record.approvedRequirementSetHash, SHA256) ||
    record.approvedRequirementSetHash !== record.requirementSetHash ||
    !isDigest(record.certifierSourceSha256, SHA256) ||
    !Array.isArray(record.gates) ||
    record.gates.length === 0 ||
    !record.gates.every(hasGateContract) ||
    !hasTotalsContract(record.totals, record.gates) ||
    !hasCandidateRecordContract(record.candidate, record.verdict === 'failed')
  ) {
    return false;
  }

  const everyGatePassed = record.gates.every((gate) => gate.outcome === 'passed');
  if (record.verdict !== (everyGatePassed ? 'passed' : 'failed')) return false;
  return record.verdict !== 'passed' || record.candidate.headSha === record.releaseSha;
};

const isPreservableCertificationRecord = (record, workflowRunId, releaseSha) =>
  // This helper is invoked only by the workflow's `if: failure()` step. A real passing certifier exits 0,
  // so a passed record can never be the decision that explains why this fallback is running. Refusing to
  // preserve one also prevents an earlier candidate-controlled command from planting a structurally plausible
  // partial "pass" and then failing the workflow before the certifier can replace it.
  record?.verdict === 'failed' &&
  hasCommonRecordContract(record, workflowRunId, releaseSha) &&
  (hasPreflightRecordContract(record) || hasFinalRecordContract(record));

/**
 * Guarantee a bounded refusal record when Actions fails before (or crashes inside) the certifier.
 *
 * A valid, precise refusal already written by this workflow run and release SHA always wins. A passing record
 * never does: this helper runs only after a workflow failure, so such a record cannot explain the failing run.
 * Checking the record contract prevents truncated, fabricated or stale same-run JSON from suppressing the
 * fallback.
 */
export function ensureWorkflowRefusalRecord(
  recordDir,
  {
    workflowRunId,
    releaseSha,
    approvedRequirementSetHash,
    certifierSourceSha256,
    actualRequirementSetHash,
    candidateIdentity,
    candidateInputIdentity,
    candidateTemplateIdentity,
    now = new Date(),
  },
) {
  const normalizedRunId = String(workflowRunId ?? '').trim();
  if (!WORKFLOW_RUN_ID.test(normalizedRunId)) {
    throw new Error('RELEASE_WORKFLOW_RUN_ID must be <github.run_id>-<github.run_attempt>');
  }
  const normalizedReleaseSha = normalizedCommitSha(releaseSha);

  try {
    const current = JSON.parse(
      readFileSync(resolve(recordDir, 'certification-latest.json'), 'utf8'),
    );
    if (isPreservableCertificationRecord(current, normalizedRunId, normalizedReleaseSha)) {
      return Object.freeze({ created: false, record: Object.freeze(current) });
    }
  } catch {
    // Missing or malformed prior output is exactly why the fallback exists.
  }

  const written = writePreflightRefusalRecord(recordDir, {
    workflowRunId: normalizedRunId,
    releaseSha,
    approvedRequirementSetHash,
    certifierSourceSha256,
    actualRequirementSetHash,
    candidateIdentity,
    candidateInputIdentity,
    candidateTemplateIdentity,
    problems: [
      'release workflow failed before the certifier produced a decision record for this workflow run',
    ],
    now,
  });
  return Object.freeze({ ...written, created: true });
}
