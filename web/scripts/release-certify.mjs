#!/usr/bin/env node
/**
 * Release certification runner (P0-07 / WP-03).
 *
 * Developer CI answers "did this change break anything visible". This answers a different and much harder
 * question: "is there fresh, real, attributable evidence that this exact commit is releasable". The two must
 * not share a job, because the first has to stay actionable — the main workflow deliberately runs the desktop
 * comparison under `continue-on-error` so a known-red parity capture does not block ordinary work — and the
 * second must refuse everything that is not proven.
 *
 * This script only OBSERVES: it runs each gate command, records the exit code and output, reads each required
 * artefact, and hands the observations to `releaseCertification.certify`, which owns every decision and is
 * unit tested for each refusal reason. Keeping judgement out of the runner is what makes the rules testable
 * without a release.
 *
 *   Required inputs, all fail-closed:
 *     RELEASE_SHA                        the 40-character commit being certified
 *     RELEASE_LOCK_SHA256                SHA-256 of this candidate's exact pnpm lockfile bytes
 *     RELEASE_SCHEMA_SHA256              SHA-256 of the canonical database-schema bundle manifest
 *     RELEASE_TEMPLATE_SHA256            SHA-256 of the validated tracked web-template bundle manifest
 *     RELEASE_REQUIREMENT_SET_SHA256     owner-reviewed digest printed by --plan before execution
 *     RELEASE_EVIDENCE_MAX_AGE_HOURS     the freshness window — an OWNER decision (plan §8.1), never defaulted
 *
 *   Usage:
 *     RELEASE_SHA=<reviewed commit> RELEASE_LOCK_SHA256=<reviewed digest> \
 *       RELEASE_SCHEMA_SHA256=<reviewed digest> RELEASE_TEMPLATE_SHA256=<reviewed digest> \
 *       RELEASE_REQUIREMENT_SET_SHA256=<reviewed digest> \
 *       RELEASE_EVIDENCE_MAX_AGE_HOURS=24 \
 *       node scripts/release-certify.mjs
 *     node scripts/release-certify.mjs --plan     # list the gate set and exit, running nothing
 *
 * There is deliberately no flag that turns a refusal into a pass. The record is written whether the verdict is
 * pass or fail, because a refusal is itself evidence: it says which gate was not satisfied, when, and for
 * which commit.
 */
import { createHash } from 'node:crypto';
import { execFileSync } from 'node:child_process';
import { mkdirSync, mkdtempSync, readFileSync, rmSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';
import {
  candidateInputIdentityProblems,
  candidateIdentityProblems,
  expectedCandidateInputIdentities,
  observeCandidateInputIdentities,
  observeCandidateIdentity,
} from './lib/release-candidate-identity.mjs';
import { writePreflightRefusalRecord } from './lib/release-certification-record.mjs';
import {
  candidateTemplateBundleProblems,
  expectedCandidateTemplateBundle,
  observeCandidateTemplateBundle,
} from './lib/release-template-bundle-identity.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const webRoot = resolve(here, '..');
const repoRoot = resolve(webRoot, '..');
const recordDir = resolve(repoRoot, 'project-memory/parity/release');
const planning = process.argv.includes('--plan');
const releaseSha = (process.env.RELEASE_SHA ?? '').trim();
const approvedRequirementSetHash = (process.env.RELEASE_REQUIREMENT_SET_SHA256 ?? '').trim();
const workflowRunIdRaw = (process.env.RELEASE_WORKFLOW_RUN_ID ?? '').trim();
const workflowRunId = /^[1-9][0-9]*-[1-9][0-9]*$/.test(workflowRunIdRaw) ? workflowRunIdRaw : null;
const windowRaw = (process.env.RELEASE_EVIDENCE_MAX_AGE_HOURS ?? '').trim();
const freshnessWindowHours = windowRaw === '' ? undefined : Number(windowRaw);
const candidateIdentity = observeCandidateIdentity(repoRoot);
const candidateInputIdentity = observeCandidateInputIdentities(repoRoot);
const candidateTemplateIdentity = observeCandidateTemplateBundle(repoRoot);
const certifierSourcePath = resolve(webRoot, 'apps/api/src/modules/ops/releaseCertification.ts');

let certifier;
let certifierSourceSha256;
let certifierBuildDir;
let certifierLoadError;
try {
  // Read exactly once: the bytes hashed for owner approval are also the bytes compiled below. This closes the
  // hash/compile race in which a concurrent writer could otherwise swap the decision module between reads.
  const certifierSource = readFileSync(certifierSourcePath);
  certifierSourceSha256 = createHash('sha256').update(certifierSource).digest('hex');
  // dist is ignored and may contain obsolete outputs that tsc does not delete. Compile the captured source as
  // an `.mts` snapshot in a brand-new private directory and import only that emitted `.mjs` file.
  certifierBuildDir = mkdtempSync(resolve(tmpdir(), 'datacare-release-certifier-'));
  const certifierSnapshot = resolve(certifierBuildDir, 'releaseCertification.mts');
  writeFileSync(certifierSnapshot, certifierSource);
  execFileSync(
    'pnpm',
    [
      'exec',
      'tsc',
      certifierSnapshot,
      '--target',
      'ES2022',
      '--module',
      'NodeNext',
      '--moduleResolution',
      'NodeNext',
      '--strict',
      '--types',
      'node',
      '--typeRoots',
      resolve(webRoot, 'node_modules/@types'),
      '--skipLibCheck',
      '--outDir',
      certifierBuildDir,
      '--declaration',
      'false',
    ],
    {
      cwd: webRoot,
      stdio: ['ignore', 'inherit', 'inherit'],
    },
  );
  certifier = await import(resolve(certifierBuildDir, 'releaseCertification.mjs'));
} catch (error) {
  certifierLoadError = error;
} finally {
  if (certifierBuildDir) rmSync(certifierBuildDir, { recursive: true, force: true });
}
if (certifierLoadError) {
  if (!planning) {
    const refusal = writePreflightRefusalRecord(recordDir, {
      releaseSha,
      approvedRequirementSetHash,
      workflowRunId,
      certifierSourceSha256,
      candidateIdentity,
      candidateInputIdentity,
      candidateTemplateIdentity,
      problems: ['certifier decision module could not be built and loaded from candidate source'],
    });
    console.error(`record: ${refusal.named.replace(`${repoRoot}/`, '')}`);
  }
  console.error(
    'RELEASE_CERTIFY_UNAVAILABLE: could not build and load the candidate decision module.\n' +
      String(certifierLoadError?.message ?? certifierLoadError),
  );
  process.exit(1);
}
const {
  RELEASE_GATES,
  certify,
  contextProblems,
  requirementSetFingerprint,
  requirementSetProblems,
} = certifier;
const candidateRequirementSetHash = requirementSetFingerprint(RELEASE_GATES, certifierSourceSha256);

if (planning) {
  console.log(`Release gate set (${RELEASE_GATES.length} gates)`);
  console.log(`Requirement set SHA-256: ${candidateRequirementSetHash}\n`);
  for (const gate of RELEASE_GATES) {
    console.log(`  ${gate.id}`);
    console.log(`      ${gate.title}`);
    console.log(`      because: ${gate.because}`);
    if (gate.command) console.log(`      command: ${gate.command}`);
    if (gate.evidence) console.log(`      evidence: ${gate.evidence.path}`);
  }
  process.exit(0);
}

// Refuse before spending the full release run on a verdict already determined.
const setup = [
  ...requirementSetProblems(RELEASE_GATES),
  ...contextProblems({
    releaseSha,
    freshnessWindowHours,
    approvedRequirementSetHash,
    certifierSourceSha256,
    actualRequirementSetHash: candidateRequirementSetHash,
    now: new Date(),
  }),
  ...candidateIdentityProblems(releaseSha, candidateIdentity),
  ...candidateInputIdentityProblems(
    expectedCandidateInputIdentities(process.env),
    candidateInputIdentity,
  ),
  ...candidateTemplateBundleProblems(
    expectedCandidateTemplateBundle(process.env),
    candidateTemplateIdentity,
  ),
];
if (setup.length) {
  const refusal = writePreflightRefusalRecord(recordDir, {
    releaseSha,
    approvedRequirementSetHash,
    workflowRunId,
    certifierSourceSha256,
    actualRequirementSetHash: candidateRequirementSetHash,
    candidateIdentity,
    candidateInputIdentity,
    candidateTemplateIdentity,
    problems: setup,
  });
  console.error('RELEASE_NOT_CERTIFIED: this certification run cannot judge anything.\n');
  for (const problem of setup) console.error(`  - ${problem}`);
  console.error('\nNo gate was run, because a green gate would not change this outcome.');
  console.error(`record: ${refusal.named.replace(`${repoRoot}/`, '')}`);
  process.exit(1);
}

console.log(
  `Candidate checkout: commit=${candidateIdentity.headSha} tree=${candidateIdentity.treeOid} clean=true ` +
    `lock=${candidateInputIdentity.lockSha256} schema=${candidateInputIdentity.schemaSha256} ` +
    `schemaFiles=${candidateInputIdentity.schemaFileCount} ` +
    `templates=${candidateTemplateIdentity.templateSha256} ` +
    `templateFiles=${candidateTemplateIdentity.templateFileCount}`,
);

/** Run one gate command, capturing what it did rather than letting it abort this process. */
let finalCandidateIdentity = candidateIdentity;
let finalCandidateInputIdentity = candidateInputIdentity;
let finalCandidateTemplateIdentity = candidateTemplateIdentity;
function observeCommand(gate) {
  if (gate.runnerCheck === 'candidate-identity-postflight') {
    process.stdout.write(`\n── ${gate.id}: internal candidate identity recheck\n`);
    finalCandidateIdentity = observeCandidateIdentity(repoRoot);
    finalCandidateInputIdentity = observeCandidateInputIdentities(repoRoot);
    finalCandidateTemplateIdentity = observeCandidateTemplateBundle(repoRoot);
    const problems = [
      ...candidateIdentityProblems(releaseSha, finalCandidateIdentity),
      ...candidateInputIdentityProblems(
        expectedCandidateInputIdentities(process.env),
        finalCandidateInputIdentity,
      ),
      ...candidateTemplateBundleProblems(
        expectedCandidateTemplateBundle(process.env),
        finalCandidateTemplateIdentity,
      ),
    ];
    return {
      exitCode: problems.length ? 1 : 0,
      stdout: problems.length ? '' : 'CANDIDATE_IDENTITY_POSTFLIGHT_OK',
      stderr: problems.join('\n'),
    };
  }
  if (!gate.command) return {};
  process.stdout.write(`\n── ${gate.id}: ${gate.command}\n`);
  try {
    const stdout = execFileSync('sh', ['-c', gate.command], {
      cwd: webRoot,
      encoding: 'utf8',
      stdio: ['ignore', 'pipe', 'pipe'],
      env: process.env,
      maxBuffer: 64 * 1024 * 1024,
    });
    return { exitCode: 0, stdout, stderr: '' };
  } catch (error) {
    return {
      exitCode: typeof error?.status === 'number' ? error.status : 1,
      stdout: String(error?.stdout ?? ''),
      stderr: String(error?.stderr ?? error?.message ?? ''),
    };
  }
}

/** Read one required artefact. Absence and unparseable content are both observations, not crashes. */
function observeEvidence(gate) {
  if (!gate.evidence) return undefined;
  const full = resolve(repoRoot, gate.evidence.path);
  try {
    return {
      path: gate.evidence.path,
      present: true,
      json: JSON.parse(readFileSync(full, 'utf8')),
    };
  } catch {
    return { path: gate.evidence.path, present: false };
  }
}

const observations = RELEASE_GATES.map((gate) => ({
  id: gate.id,
  command: gate.command,
  ...observeCommand(gate),
  artefact: observeEvidence(gate),
}));

const decision = certify(RELEASE_GATES, observations, {
  releaseSha,
  freshnessWindowHours,
  approvedRequirementSetHash,
  certifierSourceSha256,
  actualRequirementSetHash: candidateRequirementSetHash,
  now: new Date(),
});
const record = {
  ...decision,
  workflowRunId,
  candidate: {
    headSha: finalCandidateIdentity.headSha,
    treeOid: finalCandidateIdentity.treeOid,
    clean: finalCandidateIdentity.dirtyPathRecords === 0,
    dirtyPathRecords: finalCandidateIdentity.dirtyPathRecords,
    lockSha256: finalCandidateInputIdentity.lockSha256,
    schemaSha256: finalCandidateInputIdentity.schemaSha256,
    schemaFileCount: finalCandidateInputIdentity.schemaFileCount,
    templateSha256: finalCandidateTemplateIdentity.templateSha256,
    templateFileCount: finalCandidateTemplateIdentity.templateFileCount,
    formTemplateSha256: finalCandidateTemplateIdentity.formTemplateSha256,
    formTemplateFileCount: finalCandidateTemplateIdentity.formTemplateFileCount,
    formSpecCount: finalCandidateTemplateIdentity.formSpecCount,
    formLayoutCount: finalCandidateTemplateIdentity.formLayoutCount,
    reportTemplateSha256: finalCandidateTemplateIdentity.reportTemplateSha256,
    reportTemplateFileCount: finalCandidateTemplateIdentity.reportTemplateFileCount,
    reportSpecCount: finalCandidateTemplateIdentity.reportSpecCount,
  },
};

mkdirSync(recordDir, { recursive: true });
const stamp = record.evaluatedAt.replace(/[:.]/g, '-');
const named = resolve(recordDir, `certification-${record.releaseSha ?? 'unknown'}-${stamp}.json`);
const serialised = `${JSON.stringify(record, null, 2)}\n`;
writeFileSync(named, serialised);
writeFileSync(resolve(recordDir, 'certification-latest.json'), serialised);

const WIDTH = Math.max(...record.gates.map((g) => g.id.length));
console.log('\n──────── release certification ────────');
console.log(`commit           ${record.releaseSha ?? '(unknown)'}`);
console.log(`freshness window ${record.freshnessWindowHours ?? '(unconfigured)'}h`);
console.log(`requirement set  ${record.requirementSetHash}`);
console.log(`owner approved   ${record.approvedRequirementSetHash ?? '(unconfigured)'}`);
console.log(`evaluated at     ${record.evaluatedAt}\n`);
for (const gate of record.gates) {
  const mark = gate.outcome === 'passed' ? 'PASS' : gate.outcome.toUpperCase();
  console.log(`  ${gate.id.padEnd(WIDTH)}  ${mark.padEnd(13)} ${gate.reason}`);
}
const counted = Object.entries(record.totals)
  .filter(([, n]) => n > 0)
  .map(([outcome, n]) => `${outcome}=${n}`)
  .join(' ');
console.log(`\n${counted}`);
console.log(`record: ${named.replace(`${repoRoot}/`, '')}`);

if (record.verdict !== 'passed') {
  console.error(
    '\nRELEASE_NOT_CERTIFIED: every gate above must read PASS. RED, SKIP, stale, synthetic, missing and\n' +
      'self-approved results are all refusals — produce the evidence rather than adjusting the gate.',
  );
  process.exit(1);
}
console.log('\nRELEASE_CERTIFIED');
