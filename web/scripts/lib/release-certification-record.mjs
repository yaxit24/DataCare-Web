import { mkdirSync, writeFileSync } from 'node:fs';
import { resolve } from 'node:path';

const COMMIT_SHA = /^[0-9a-f]{40}$/i;
const SHA256 = /^[0-9a-f]{64}$/i;
const WORKFLOW_RUN_ID = /^[1-9][0-9]*-[1-9][0-9]*$/;

const digestOrNull = (value, pattern) => {
  const normalized = String(value ?? '')
    .trim()
    .toLowerCase();
  return pattern.test(normalized) ? normalized : null;
};

/**
 * Persist a fail-closed preflight result before the runner exits.
 *
 * This record intentionally carries only bounded identity observations and refusal reasons. It never lists
 * dirty paths or serializes process.env, so an accidentally untracked secret name/value cannot enter an
 * uploaded Actions artifact.
 */
export function writePreflightRefusalRecord(
  recordDir,
  {
    releaseSha,
    approvedRequirementSetHash,
    certifierSourceSha256,
    actualRequirementSetHash,
    workflowRunId,
    candidateIdentity = {},
    candidateInputIdentity = {},
    candidateTemplateIdentity = {},
    problems,
    now = new Date(),
  },
) {
  if (!Array.isArray(problems) || problems.length === 0) {
    throw new Error('a preflight refusal record requires at least one problem');
  }
  const evaluatedAt = now.toISOString();
  const normalizedReleaseSha = digestOrNull(releaseSha, COMMIT_SHA);
  const record = {
    kind: 'datacare.release-certification-preflight/1.0',
    verdict: 'failed',
    stage: 'preflight',
    evaluatedAt,
    releaseSha: normalizedReleaseSha,
    workflowRunId: WORKFLOW_RUN_ID.test(String(workflowRunId ?? '').trim())
      ? String(workflowRunId).trim()
      : null,
    approvedRequirementSetHash: digestOrNull(approvedRequirementSetHash, SHA256),
    certifierSourceSha256: digestOrNull(certifierSourceSha256, SHA256),
    requirementSetHash: digestOrNull(actualRequirementSetHash, SHA256),
    candidate: {
      headSha: digestOrNull(candidateIdentity.headSha, COMMIT_SHA),
      treeOid: digestOrNull(candidateIdentity.treeOid, COMMIT_SHA),
      clean: candidateIdentity.dirtyPathRecords === 0,
      dirtyPathRecords: Number.isInteger(candidateIdentity.dirtyPathRecords)
        ? candidateIdentity.dirtyPathRecords
        : null,
      lockSha256: digestOrNull(candidateInputIdentity.lockSha256, SHA256),
      schemaSha256: digestOrNull(candidateInputIdentity.schemaSha256, SHA256),
      schemaFileCount: Number.isSafeInteger(candidateInputIdentity.schemaFileCount)
        ? candidateInputIdentity.schemaFileCount
        : null,
      templateSha256: digestOrNull(candidateTemplateIdentity.templateSha256, SHA256),
      templateFileCount: Number.isSafeInteger(candidateTemplateIdentity.templateFileCount)
        ? candidateTemplateIdentity.templateFileCount
        : null,
      formTemplateSha256: digestOrNull(candidateTemplateIdentity.formTemplateSha256, SHA256),
      formTemplateFileCount: Number.isSafeInteger(candidateTemplateIdentity.formTemplateFileCount)
        ? candidateTemplateIdentity.formTemplateFileCount
        : null,
      formSpecCount: Number.isSafeInteger(candidateTemplateIdentity.formSpecCount)
        ? candidateTemplateIdentity.formSpecCount
        : null,
      formLayoutCount: Number.isSafeInteger(candidateTemplateIdentity.formLayoutCount)
        ? candidateTemplateIdentity.formLayoutCount
        : null,
      reportTemplateSha256: digestOrNull(candidateTemplateIdentity.reportTemplateSha256, SHA256),
      reportTemplateFileCount: Number.isSafeInteger(
        candidateTemplateIdentity.reportTemplateFileCount,
      )
        ? candidateTemplateIdentity.reportTemplateFileCount
        : null,
      reportSpecCount: Number.isSafeInteger(candidateTemplateIdentity.reportSpecCount)
        ? candidateTemplateIdentity.reportSpecCount
        : null,
    },
    problems: problems.map((problem) => String(problem)),
    gatesRun: 0,
  };

  mkdirSync(recordDir, { recursive: true });
  const stamp = evaluatedAt.replace(/[:.]/g, '-');
  const named = resolve(
    recordDir,
    `certification-${normalizedReleaseSha ?? 'unknown'}-${stamp}.json`,
  );
  const serialized = `${JSON.stringify(record, null, 2)}\n`;
  writeFileSync(named, serialized);
  writeFileSync(resolve(recordDir, 'certification-latest.json'), serialized);
  return Object.freeze({ named, record: Object.freeze(record) });
}
