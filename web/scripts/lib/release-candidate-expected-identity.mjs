import { execFileSync } from 'node:child_process';
import {
  RELEASE_LOCK_IDENTITY_MANIFEST,
  RELEASE_SCHEMA_IDENTITY_MANIFEST,
  schemaIdentityTreeEntries,
  schemaIdentitySha256,
  sha256Bytes,
} from './release-candidate-identity.mjs';

const COMMIT_SHA = /^[0-9a-f]{40}$/i;
const SHA256 = /^[0-9a-f]{64}$/;

const gitObject = (repoRoot, args) =>
  execFileSync('git', args, {
    cwd: repoRoot,
    stdio: ['ignore', 'pipe', 'pipe'],
  });

const bytes = (value) => (Buffer.isBuffer(value) ? value : Buffer.from(String(value), 'utf8'));

/**
 * Derive independently supplied release identities from immutable Git objects.
 *
 * This function never reads a worktree file. The caller supplies an exact commit, `ls-tree` freezes the schema
 * file set at that commit, and `cat-file blob` supplies each exact byte sequence. The release runner separately
 * reads live worktree bytes and requires a clean checkout, so agreement binds both sides to the same candidate.
 */
export function expectedCandidateInputIdentitiesFromGit(repoRoot, releaseSha, runGit = gitObject) {
  const candidate = String(releaseSha ?? '')
    .trim()
    .toLowerCase();
  if (!COMMIT_SHA.test(candidate)) {
    throw new Error('release commit must be an exact 40-character hexadecimal object id');
  }

  const resolved = bytes(runGit(repoRoot, ['rev-parse', '--verify', `${candidate}^{commit}`]))
    .toString('utf8')
    .trim()
    .toLowerCase();
  if (!COMMIT_SHA.test(resolved) || resolved !== candidate) {
    throw new Error(`release commit ${candidate} did not resolve to that exact commit object`);
  }

  const listing = runGit(repoRoot, [
    'ls-tree',
    '-r',
    '-z',
    candidate,
    '--',
    ...RELEASE_SCHEMA_IDENTITY_MANIFEST.pathspecs,
  ]);
  const schemaTreeEntries = schemaIdentityTreeEntries(bytes(listing));
  const lockBytes = bytes(
    runGit(repoRoot, ['cat-file', 'blob', `${candidate}:${RELEASE_LOCK_IDENTITY_MANIFEST.path}`]),
  );
  const schemaEntries = schemaTreeEntries.map(({ oid, path }) => ({
    path,
    sha256: sha256Bytes(bytes(runGit(repoRoot, ['cat-file', 'blob', oid]))),
  }));

  return Object.freeze({
    releaseSha: candidate,
    lockSha256: sha256Bytes(lockBytes),
    schemaSha256: schemaIdentitySha256(schemaEntries),
    schemaFileCount: schemaEntries.length,
    schemaEntries: Object.freeze(schemaEntries.map((entry) => Object.freeze(entry))),
  });
}

/**
 * Encode fixed, single-line GitHub step outputs.
 *
 * Every value is validated before serialization, so none can introduce a newline, output key, or workflow
 * command. The CLI writes these lines to stdout for a workflow step to append to `$GITHUB_OUTPUT` itself.
 */
export function candidateIdentityGitHubOutput(identity) {
  const releaseSha = String(identity?.releaseSha ?? '').toLowerCase();
  const lockSha256 = String(identity?.lockSha256 ?? '').toLowerCase();
  const schemaSha256 = String(identity?.schemaSha256 ?? '').toLowerCase();
  const schemaFileCount = identity?.schemaFileCount;
  const templateSha256 = String(identity?.templateSha256 ?? '').toLowerCase();
  const templateFileCount = identity?.templateFileCount;
  if (!COMMIT_SHA.test(releaseSha)) throw new Error('release_sha is not a safe full commit id');
  if (!SHA256.test(lockSha256)) throw new Error('lock_sha256 is not a safe SHA-256 digest');
  if (!SHA256.test(schemaSha256)) throw new Error('schema_sha256 is not a safe SHA-256 digest');
  if (!(Number.isSafeInteger(schemaFileCount) && schemaFileCount > 0)) {
    throw new Error('schema_file_count is not a safe positive integer');
  }
  if (!SHA256.test(templateSha256)) {
    throw new Error('template_sha256 is not a safe SHA-256 digest');
  }
  if (!(Number.isSafeInteger(templateFileCount) && templateFileCount > 0)) {
    throw new Error('template_file_count is not a safe positive integer');
  }
  return (
    [
      `release_sha=${releaseSha}`,
      `lock_sha256=${lockSha256}`,
      `schema_sha256=${schemaSha256}`,
      `schema_file_count=${schemaFileCount}`,
      `template_sha256=${templateSha256}`,
      `template_file_count=${templateFileCount}`,
    ].join('\n') + '\n'
  );
}
