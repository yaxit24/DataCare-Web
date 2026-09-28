#!/usr/bin/env node
import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import {
  observeCandidateInputIdentities,
  observeCandidateIdentity,
} from './lib/release-candidate-identity.mjs';
import { ensureWorkflowRefusalRecord } from './lib/release-certification-workflow-refusal.mjs';
import { observeCandidateTemplateBundle } from './lib/release-template-bundle-identity.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const webRoot = resolve(here, '..');
const repoRoot = resolve(webRoot, '..');
const certifierSourcePath = resolve(webRoot, 'apps/api/src/modules/ops/releaseCertification.ts');

let certifierSourceSha256;
try {
  certifierSourceSha256 = createHash('sha256')
    .update(readFileSync(certifierSourcePath))
    .digest('hex');
} catch {
  certifierSourceSha256 = null;
}

try {
  const outcome = ensureWorkflowRefusalRecord(resolve(repoRoot, 'project-memory/parity/release'), {
    workflowRunId: process.env.RELEASE_WORKFLOW_RUN_ID,
    releaseSha: process.env.RELEASE_SHA || process.env.GITHUB_SHA,
    approvedRequirementSetHash: process.env.RELEASE_REQUIREMENT_SET_SHA256,
    certifierSourceSha256,
    candidateIdentity: observeCandidateIdentity(repoRoot),
    candidateInputIdentity: observeCandidateInputIdentities(repoRoot),
    candidateTemplateIdentity: observeCandidateTemplateBundle(repoRoot),
  });
  console.log(
    outcome.created
      ? 'RELEASE_WORKFLOW_REFUSAL_RECORDED'
      : 'RELEASE_WORKFLOW_REFUSAL_PRESERVED_EXISTING_DECISION',
  );
} catch (error) {
  console.error(`RELEASE_WORKFLOW_REFUSAL_ERROR: ${String(error?.message ?? error)}`);
  process.exit(1);
}
