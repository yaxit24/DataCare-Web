#!/usr/bin/env node
/**
 * Emit immutable candidate identities for a GitHub Actions step.
 *
 * Usage:
 *   node scripts/release-candidate-expected-identity.mjs <exact-40-hex-commit> >> "$GITHUB_OUTPUT"
 *
 * The module reads Git objects only. It never derives the expected values from the live worktree that the
 * release runner subsequently judges.
 */
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';
import {
  candidateIdentityGitHubOutput,
  expectedCandidateInputIdentitiesFromGit,
} from './lib/release-candidate-expected-identity.mjs';
import { expectedCandidateTemplateBundleFromGit } from './lib/release-template-bundle-identity.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const repoRoot = resolve(here, '../..');
const args = process.argv.slice(2);

if (args.length !== 1) {
  console.error(
    'Usage: node scripts/release-candidate-expected-identity.mjs <exact-40-hex-commit>',
  );
  process.exit(2);
}

try {
  const identity = {
    ...expectedCandidateInputIdentitiesFromGit(repoRoot, args[0]),
    ...expectedCandidateTemplateBundleFromGit(repoRoot, args[0]),
  };
  process.stdout.write(candidateIdentityGitHubOutput(identity));
} catch (error) {
  const detail = String(error?.stderr ?? error?.message ?? error)
    .split(/\r?\n/)
    .find((line) => line.trim())
    ?.trim();
  console.error(`RELEASE_CANDIDATE_IDENTITY_ERROR: ${detail || 'identity could not be derived'}`);
  process.exit(1);
}
