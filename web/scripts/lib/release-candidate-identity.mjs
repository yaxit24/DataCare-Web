import { execFileSync } from 'node:child_process';
import { createHash } from 'node:crypto';
import { lstatSync, readFileSync } from 'node:fs';
import { resolve } from 'node:path';
import { TextDecoder } from 'node:util';

const COMMIT_SHA = /^[0-9a-f]{40}$/i;
const SHA256 = /^[0-9a-f]{64}$/i;
const REGULAR_FILE_MODE = /^100(?:644|755)$/;

/**
 * Exact dependency-lock identity contract.
 *
 * The digest is the SHA-256 of the file's bytes, with no newline or text normalization. This intentionally
 * matches ordinary `sha256sum web/pnpm-lock.yaml` output and makes the package graph independently anchorable.
 */
export const RELEASE_LOCK_IDENTITY_MANIFEST = Object.freeze({
  kind: 'datacare.release-lock-identity/1.0',
  algorithm: 'sha256(raw-file-bytes)',
  path: 'web/pnpm-lock.yaml',
});

const SCHEMA_REQUIRED_FILES = Object.freeze([
  'web/packages/db/prisma/schema.prisma',
  'web/packages/db/prisma/migrations/migration_lock.toml',
  'web/packages/db/prisma/rls.sql',
  'web/packages/db/setup_roles.sql',
]);

const SCHEMA_PATHSPECS = Object.freeze([
  'web/packages/db/prisma',
  'web/packages/db/setup_roles.sql',
]);

/**
 * Exact database-schema bundle identity contract.
 *
 * Selection comes from the candidate commit, not an ad-hoc filesystem glob: every Git entry below the two
 * pathspecs is included. Each selected worktree file is hashed byte-for-byte. Entries are sorted by UTF-8 path
 * bytes, encoded as compact JSON objects with exactly `path` then `sha256`, and that JSON byte string is hashed.
 * Consequently a file add/delete/rename, a migration reorder/name change, or any byte change alters the bundle.
 */
export const RELEASE_SCHEMA_IDENTITY_MANIFEST = Object.freeze({
  kind: 'datacare.release-schema-identity/1.0',
  algorithm: 'sha256(utf8(JSON.stringify([{path,sha256},...])))',
  selection: 'git ls-tree -r -z <commit> -- <pathspecs>',
  pathspecs: SCHEMA_PATHSPECS,
  requiredFiles: SCHEMA_REQUIRED_FILES,
  requiredMigrationPattern: 'web/packages/db/prisma/migrations/*/migration.sql',
});

const git = (repoRoot, args) =>
  execFileSync('git', args, {
    cwd: repoRoot,
    encoding: 'utf8',
    stdio: ['ignore', 'pipe', 'pipe'],
  });
const gitBytes = (repoRoot, args) =>
  execFileSync('git', args, {
    cwd: repoRoot,
    stdio: ['ignore', 'pipe', 'pipe'],
  });

const pathOrder = (left, right) =>
  Buffer.compare(Buffer.from(left, 'utf8'), Buffer.from(right, 'utf8'));
const utf8 = new TextDecoder('utf-8', { fatal: true });
const asBytes = (value) => (Buffer.isBuffer(value) ? value : Buffer.from(String(value), 'utf8'));

function decodeGitListing(value) {
  try {
    return utf8.decode(asBytes(value));
  } catch {
    throw new Error('candidate schema Git tree listing is not valid UTF-8');
  }
}

function schemaPathIsInScope(path) {
  const segments = path.split('/');
  const isCanonicalRelativePath =
    !path.startsWith('/') &&
    !path.includes('\\') &&
    segments.every((segment) => segment && segment !== '.' && segment !== '..');
  return (
    isCanonicalRelativePath &&
    (path === 'web/packages/db/setup_roles.sql' || path.startsWith('web/packages/db/prisma/'))
  );
}

/** SHA-256 exact bytes without text or newline normalization. */
export const sha256Bytes = (bytes) => createHash('sha256').update(bytes).digest('hex');

/** Parse and validate the candidate commit's exact schema blob set. */
export function schemaIdentityTreeEntries(gitListing) {
  const listing = decodeGitListing(gitListing);
  if (listing && !listing.endsWith('\0')) {
    throw new Error('candidate schema Git tree listing is not NUL terminated');
  }

  const records = listing ? listing.slice(0, -1).split('\0') : [];
  if (records.some((record) => !record)) {
    throw new Error('candidate schema Git tree listing contains an invalid entry');
  }

  const entries = records.map((record) => {
    const separator = record.indexOf('\t');
    const metadata = separator < 0 ? '' : record.slice(0, separator);
    const path = separator < 0 ? '' : record.slice(separator + 1);
    const match = metadata.match(/^([0-7]{6}) ([a-z]+) ([0-9a-f]{40}|[0-9a-f]{64})$/i);
    if (!match || !path) {
      throw new Error('candidate schema Git tree listing contains an invalid entry');
    }
    const [, mode, type, oid] = match;
    if (type !== 'blob' || !REGULAR_FILE_MODE.test(mode)) {
      throw new Error(`candidate schema path ${path} is not a regular Git blob`);
    }
    if (!schemaPathIsInScope(path)) {
      throw new Error(`candidate schema manifest contains out-of-scope path ${path}`);
    }
    return Object.freeze({ mode, type, oid: oid.toLowerCase(), path });
  });

  const schemaPaths = entries.map(({ path }) => path);
  if (new Set(schemaPaths).size !== schemaPaths.length) {
    throw new Error('candidate schema manifest contains duplicate paths');
  }
  for (const required of RELEASE_SCHEMA_IDENTITY_MANIFEST.requiredFiles) {
    if (!schemaPaths.includes(required)) {
      throw new Error(`candidate schema manifest is missing required tracked file ${required}`);
    }
  }
  const migrationPrefix = 'web/packages/db/prisma/migrations/';
  const migrationFiles = schemaPaths.filter(
    (path) => path.startsWith(migrationPrefix) && path.endsWith('/migration.sql'),
  );
  if (migrationFiles.length === 0) {
    throw new Error('candidate schema manifest contains no tracked Prisma migration.sql files');
  }
  return Object.freeze(entries.sort((left, right) => pathOrder(left.path, right.path)));
}

/** Return the validated canonical path set for independent implementations of the digest contract. */
export function schemaIdentityPaths(gitListing) {
  return Object.freeze(schemaIdentityTreeEntries(gitListing).map(({ path }) => path));
}

/** Hash the canonical schema entry manifest. Exported so independent tooling can implement the same contract. */
export function schemaIdentitySha256(entries) {
  const stable = entries
    .map(({ path, sha256: digest }) => ({ path, sha256: digest }))
    .sort((left, right) => pathOrder(left.path, right.path));
  return sha256Bytes(Buffer.from(JSON.stringify(stable), 'utf8'));
}

/**
 * Observe lock and schema identities from the files that are actually checked out.
 *
 * Git supplies only the schema file SET from HEAD. Bytes always come from the worktree; the separate clean-tree
 * check guarantees that a release cannot substitute staged, unstaged, or untracked schema content.
 */
export function observeCandidateInputIdentities(
  repoRoot,
  runGit = gitBytes,
  readFile = readFileSync,
  lstat = lstatSync,
) {
  try {
    const lockBytes = readFile(resolve(repoRoot, RELEASE_LOCK_IDENTITY_MANIFEST.path));
    const listed = runGit(repoRoot, [
      'ls-tree',
      '-r',
      '-z',
      'HEAD',
      '--',
      ...RELEASE_SCHEMA_IDENTITY_MANIFEST.pathspecs,
    ]);
    const schemaTreeEntries = schemaIdentityTreeEntries(listed);

    const schemaEntries = schemaTreeEntries.map(({ path }) => {
      const fullPath = resolve(repoRoot, path);
      if (!lstat(fullPath).isFile()) {
        throw new Error(`candidate schema path ${path} is not a regular worktree file`);
      }
      return {
        path,
        sha256: sha256Bytes(readFile(fullPath)),
      };
    });
    return Object.freeze({
      lockSha256: sha256Bytes(lockBytes),
      schemaSha256: schemaIdentitySha256(schemaEntries),
      schemaFileCount: schemaEntries.length,
      schemaEntries: Object.freeze(schemaEntries.map((entry) => Object.freeze(entry))),
    });
  } catch (error) {
    return Object.freeze({
      lockSha256: null,
      schemaSha256: null,
      schemaFileCount: null,
      schemaEntries: Object.freeze([]),
      error: String(error?.stderr ?? error?.message ?? error),
    });
  }
}

/** Read the independently supplied expected identities without silently defaulting either one. */
export function expectedCandidateInputIdentities(env) {
  return Object.freeze({
    lockSha256: String(env.RELEASE_LOCK_SHA256 ?? '')
      .trim()
      .toLowerCase(),
    schemaSha256: String(env.RELEASE_SCHEMA_SHA256 ?? '')
      .trim()
      .toLowerCase(),
  });
}

/** Fail closed when either expected digest is absent, malformed, unreadable, or does not match this checkout. */
export function candidateInputIdentityProblems(expected, observed) {
  const problems = [];
  const checks = [
    ['RELEASE_LOCK_SHA256', expected?.lockSha256, observed?.lockSha256],
    ['RELEASE_SCHEMA_SHA256', expected?.schemaSha256, observed?.schemaSha256],
  ];

  for (const [name, supplied, actual] of checks) {
    const value = String(supplied ?? '')
      .trim()
      .toLowerCase();
    if (!value) {
      problems.push(
        `${name} is required to bind certification to independently supplied candidate inputs`,
      );
      continue;
    }
    if (!SHA256.test(value)) {
      problems.push(`${name} must be an exact 64-character SHA-256 digest`);
      continue;
    }
    const observedValue = String(actual ?? '').toLowerCase();
    if (!SHA256.test(observedValue)) {
      problems.push(`${name} could not be observed from the candidate checkout`);
    } else if (observedValue !== value) {
      problems.push(`${name} ${value} does not match candidate checkout ${observedValue}`);
    }
  }
  if (observed?.error) {
    problems.push(`candidate lock/schema identity could not be observed: ${observed.error}`);
  }
  return problems;
}

/**
 * Observe the exact Git checkout the release runner is about to certify.
 *
 * Porcelain v1 with NUL delimiters is stable and does not misparse spaces or newlines in paths. The caller
 * deliberately receives only a count: release logs must not disclose an accidentally untracked secret name.
 */
export function observeCandidateIdentity(repoRoot, runGit = git) {
  try {
    const headSha = runGit(repoRoot, ['rev-parse', '--verify', 'HEAD']).trim().toLowerCase();
    const treeOid = runGit(repoRoot, ['rev-parse', '--verify', 'HEAD^{tree}']).trim().toLowerCase();
    const porcelain = runGit(repoRoot, [
      'status',
      '--porcelain=v1',
      '-z',
      '--untracked-files=all',
      '--ignore-submodules=none',
    ]);
    const dirtyPathRecords = porcelain.split('\0').filter(Boolean).length;
    return Object.freeze({ headSha, treeOid, dirtyPathRecords });
  } catch (error) {
    return Object.freeze({
      headSha: null,
      treeOid: null,
      dirtyPathRecords: null,
      error: String(error?.stderr ?? error?.message ?? error),
    });
  }
}

/** Fail-closed checks that bind RELEASE_SHA to the actual clean checkout. */
export function candidateIdentityProblems(releaseSha, observed) {
  const problems = [];
  const expected = String(releaseSha ?? '')
    .trim()
    .toLowerCase();
  if (!COMMIT_SHA.test(expected)) return problems; // contextProblems owns the clearer syntax diagnostic.

  if (observed.error) {
    problems.push(`candidate Git identity could not be observed: ${observed.error}`);
    return problems;
  }
  if (!COMMIT_SHA.test(String(observed.headSha ?? ''))) {
    problems.push('candidate checkout did not resolve HEAD to an exact 40-character commit');
  } else if (observed.headSha !== expected) {
    problems.push(`RELEASE_SHA ${expected} does not match checked-out HEAD ${observed.headSha}`);
  }
  if (!/^[0-9a-f]{40}$/i.test(String(observed.treeOid ?? ''))) {
    problems.push('candidate checkout did not resolve HEAD^{tree} to an exact Git tree');
  }
  if (observed.dirtyPathRecords !== 0) {
    const count = Number.isInteger(observed.dirtyPathRecords)
      ? String(observed.dirtyPathRecords)
      : 'an unknown number of';
    problems.push(
      `candidate checkout is dirty (${count} changed path record(s)); certification requires the exact committed tree`,
    );
  }
  return problems;
}
