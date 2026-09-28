import { mkdirSync, mkdtempSync, rmSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { dirname, join } from 'node:path';
import { describe, expect, it } from 'vitest';
import {
  candidateInputIdentityProblems,
  candidateIdentityProblems,
  expectedCandidateInputIdentities,
  observeCandidateInputIdentities,
  observeCandidateIdentity,
  RELEASE_LOCK_IDENTITY_MANIFEST,
  RELEASE_SCHEMA_IDENTITY_MANIFEST,
} from '../../../scripts/lib/release-candidate-identity.mjs';

const SHA = 'a'.repeat(40);
const TREE = 'b'.repeat(40);
const clean = Object.freeze({ headSha: SHA, treeOid: TREE, dirtyPathRecords: 0 });

const LOCK = 'lockfileVersion: 9.0\n';
const INPUT_FILES = Object.freeze({
  'web/pnpm-lock.yaml': LOCK,
  'web/packages/db/prisma/schema.prisma': 'datasource db { provider = "postgresql" }\n',
  'web/packages/db/prisma/migrations/migration_lock.toml': 'provider = "postgresql"\n',
  'web/packages/db/prisma/migrations/001_init/migration.sql':
    'CREATE TABLE sample (id integer PRIMARY KEY);\n',
  'web/packages/db/prisma/rls.sql': 'ALTER TABLE sample ENABLE ROW LEVEL SECURITY;\n',
  'web/packages/db/setup_roles.sql': 'CREATE ROLE app_user;\n',
});
const LOCK_SHA256 = 'c98d2bd9d0bc739a5937aeba6ebfcb69a2c7ee1bae8e759808d596ef38d9c2b5';
const SCHEMA_SHA256 = '432d4ef43201110ec6a4fbbed5e0202202f7ed6e016075a4174e5c579181b106';

function schemaTreeListing(paths, { modes = {}, types = {} } = {}) {
  if (paths.length === 0) return '';
  return `${paths
    .map((path, index) => {
      const mode = modes[path] ?? '100644';
      const type = types[path] ?? 'blob';
      const oid = (index + 1).toString(16).padStart(40, '0');
      return `${mode} ${type} ${oid}\t${path}`;
    })
    .join('\0')}\0`;
}

function inputFixture(check) {
  const root = mkdtempSync(join(tmpdir(), 'release-candidate-identity-'));
  const schemaPaths = Object.keys(INPUT_FILES).filter((path) => path !== 'web/pnpm-lock.yaml');
  try {
    for (const [path, contents] of Object.entries(INPUT_FILES)) {
      mkdirSync(dirname(join(root, path)), { recursive: true });
      writeFileSync(join(root, path), contents);
    }
    const runGit = (_root, args) => {
      expect(args).toEqual([
        'ls-tree',
        '-r',
        '-z',
        'HEAD',
        '--',
        ...RELEASE_SCHEMA_IDENTITY_MANIFEST.pathspecs,
      ]);
      // Deliberately reverse Git's output: the digest contract owns canonical ordering.
      return schemaTreeListing([...schemaPaths].reverse());
    };
    check({ root, schemaPaths, runGit });
  } finally {
    rmSync(root, { recursive: true, force: true });
  }
}

describe('release candidate identity preflight', () => {
  it('accepts only the exact clean checked-out commit', () => {
    expect(candidateIdentityProblems(SHA, clean)).toEqual([]);
    expect(candidateIdentityProblems(SHA.toUpperCase(), clean)).toEqual([]);
  });

  it('rejects a syntactically valid SHA that is not checked out', () => {
    expect(candidateIdentityProblems('c'.repeat(40), clean)).toEqual([
      `RELEASE_SHA ${'c'.repeat(40)} does not match checked-out HEAD ${SHA}`,
    ]);
  });

  it('rejects staged, unstaged, untracked, or submodule dirtiness reported by Git', () => {
    const problems = candidateIdentityProblems(SHA, { ...clean, dirtyPathRecords: 3 });
    expect(problems).toEqual([
      'candidate checkout is dirty (3 changed path record(s)); certification requires the exact committed tree',
    ]);
  });

  it('rejects an unreadable repository and malformed observed identities', () => {
    expect(
      candidateIdentityProblems(SHA, {
        headSha: null,
        treeOid: null,
        dirtyPathRecords: null,
        error: 'not a work tree',
      }),
    ).toEqual(['candidate Git identity could not be observed: not a work tree']);

    expect(
      candidateIdentityProblems(SHA, {
        headSha: 'HEAD',
        treeOid: 'tree',
        dirtyPathRecords: 0,
      }),
    ).toEqual([
      'candidate checkout did not resolve HEAD to an exact 40-character commit',
      'candidate checkout did not resolve HEAD^{tree} to an exact Git tree',
    ]);
  });

  it('uses exact non-shell Git invocations and NUL-safe dirty path records', () => {
    const calls = [];
    const result = observeCandidateIdentity('/repo', (_root, args) => {
      calls.push(args);
      if (args[0] === 'status') return ' M ordinary.ts\0?? name with spaces.ts\0';
      return args.at(-1) === 'HEAD^{tree}' ? `${TREE}\n` : `${SHA}\n`;
    });

    expect(result).toEqual({ headSha: SHA, treeOid: TREE, dirtyPathRecords: 2 });
    expect(calls).toEqual([
      ['rev-parse', '--verify', 'HEAD'],
      ['rev-parse', '--verify', 'HEAD^{tree}'],
      ['status', '--porcelain=v1', '-z', '--untracked-files=all', '--ignore-submodules=none'],
    ]);
  });

  it('leaves malformed RELEASE_SHA reporting to the existing context validator', () => {
    expect(candidateIdentityProblems('HEAD', clean)).toEqual([]);
  });
});

describe('release candidate lock and schema identities', () => {
  it('exports and pins the exact candidate-input manifest definitions', () => {
    expect(RELEASE_LOCK_IDENTITY_MANIFEST).toEqual({
      kind: 'datacare.release-lock-identity/1.0',
      algorithm: 'sha256(raw-file-bytes)',
      path: 'web/pnpm-lock.yaml',
    });
    expect(RELEASE_SCHEMA_IDENTITY_MANIFEST).toEqual({
      kind: 'datacare.release-schema-identity/1.0',
      algorithm: 'sha256(utf8(JSON.stringify([{path,sha256},...])))',
      selection: 'git ls-tree -r -z <commit> -- <pathspecs>',
      pathspecs: ['web/packages/db/prisma', 'web/packages/db/setup_roles.sql'],
      requiredFiles: [
        'web/packages/db/prisma/schema.prisma',
        'web/packages/db/prisma/migrations/migration_lock.toml',
        'web/packages/db/prisma/rls.sql',
        'web/packages/db/setup_roles.sql',
      ],
      requiredMigrationPattern: 'web/packages/db/prisma/migrations/*/migration.sql',
    });
  });

  it('hashes exact lock bytes and a path-sorted schema manifest deterministically', () => {
    inputFixture(({ root, runGit }) => {
      const observed = observeCandidateInputIdentities(root, runGit);
      expect(observed).toMatchObject({
        lockSha256: LOCK_SHA256,
        schemaSha256: SCHEMA_SHA256,
        schemaFileCount: 5,
      });
      expect(observed.schemaEntries.map(({ path }) => path)).toEqual(
        [...observed.schemaEntries.map(({ path }) => path)].sort(),
      );
    });
  });

  it('accepts executable regular Git blobs without changing the byte identity', () => {
    inputFixture(({ root, schemaPaths, runGit }) => {
      const ordinary = observeCandidateInputIdentities(root, runGit);
      const executable = observeCandidateInputIdentities(root, () =>
        schemaTreeListing(schemaPaths, {
          modes: { 'web/packages/db/setup_roles.sql': '100755' },
        }),
      );
      expect(executable.schemaSha256).toBe(ordinary.schemaSha256);
      expect(executable.schemaFileCount).toBe(ordinary.schemaFileCount);
    });
  });

  it('changes the schema identity for changed bytes and newly tracked migrations', () => {
    inputFixture(({ root, schemaPaths, runGit }) => {
      const before = observeCandidateInputIdentities(root, runGit);
      writeFileSync(
        join(root, 'web/packages/db/prisma/rls.sql'),
        'ALTER TABLE sample FORCE ROW LEVEL SECURITY;\n',
      );
      const changed = observeCandidateInputIdentities(root, runGit);
      expect(changed.schemaSha256).not.toBe(before.schemaSha256);

      const addedPath = 'web/packages/db/prisma/migrations/002_more/migration.sql';
      mkdirSync(dirname(join(root, addedPath)), { recursive: true });
      writeFileSync(join(root, addedPath), 'ALTER TABLE sample ADD COLUMN code text;\n');
      schemaPaths.push(addedPath);
      const added = observeCandidateInputIdentities(root, runGit);
      expect(added.schemaFileCount).toBe(6);
      expect(added.schemaSha256).not.toBe(changed.schemaSha256);
    });
  });

  it('changes the lock identity for any exact-byte change', () => {
    inputFixture(({ root, runGit }) => {
      const before = observeCandidateInputIdentities(root, runGit);
      writeFileSync(join(root, RELEASE_LOCK_IDENTITY_MANIFEST.path), `${LOCK}# reviewed change\n`);
      const changed = observeCandidateInputIdentities(root, runGit);
      expect(changed.lockSha256).not.toBe(before.lockSha256);
      expect(changed.schemaSha256).toBe(before.schemaSha256);
    });
  });

  it('requires the independently supplied values and rejects malformed or mismatched hashes', () => {
    const observed = {
      lockSha256: LOCK_SHA256,
      schemaSha256: SCHEMA_SHA256,
      schemaFileCount: 5,
      schemaEntries: [],
    };
    expect(
      candidateInputIdentityProblems(
        expectedCandidateInputIdentities({
          RELEASE_LOCK_SHA256: LOCK_SHA256.toUpperCase(),
          RELEASE_SCHEMA_SHA256: SCHEMA_SHA256.toUpperCase(),
        }),
        observed,
      ),
    ).toEqual([]);
    expect(candidateInputIdentityProblems(expectedCandidateInputIdentities({}), observed)).toEqual([
      'RELEASE_LOCK_SHA256 is required to bind certification to independently supplied candidate inputs',
      'RELEASE_SCHEMA_SHA256 is required to bind certification to independently supplied candidate inputs',
    ]);
    expect(
      candidateInputIdentityProblems(
        { lockSha256: 'e'.repeat(64), schemaSha256: SCHEMA_SHA256 },
        observed,
      ),
    ).toEqual([
      `RELEASE_LOCK_SHA256 ${'e'.repeat(64)} does not match candidate checkout ${LOCK_SHA256}`,
    ]);
    expect(
      candidateInputIdentityProblems(
        { lockSha256: LOCK_SHA256, schemaSha256: 'f'.repeat(64) },
        observed,
      ),
    ).toEqual([
      `RELEASE_SCHEMA_SHA256 ${'f'.repeat(64)} does not match candidate checkout ${SCHEMA_SHA256}`,
    ]);
    expect(
      candidateInputIdentityProblems(
        expectedCandidateInputIdentities({
          RELEASE_LOCK_SHA256: 'not-a-digest',
          RELEASE_SCHEMA_SHA256: 'f'.repeat(64),
        }),
        observed,
      ),
    ).toEqual([
      'RELEASE_LOCK_SHA256 must be an exact 64-character SHA-256 digest',
      `RELEASE_SCHEMA_SHA256 ${'f'.repeat(64)} does not match candidate checkout ${SCHEMA_SHA256}`,
    ]);
  });

  it('fails closed when required tracked schema inputs cannot be observed', () => {
    inputFixture(({ root, schemaPaths }) => {
      const withoutRls = schemaPaths.filter((path) => path !== 'web/packages/db/prisma/rls.sql');
      const observed = observeCandidateInputIdentities(root, () => schemaTreeListing(withoutRls));
      expect(observed).toMatchObject({
        lockSha256: null,
        schemaSha256: null,
        schemaFileCount: null,
        error: expect.stringContaining(
          'missing required tracked file web/packages/db/prisma/rls.sql',
        ),
      });
      expect(
        candidateInputIdentityProblems(
          { lockSha256: LOCK_SHA256, schemaSha256: SCHEMA_SHA256 },
          observed,
        ),
      ).toEqual([
        'RELEASE_LOCK_SHA256 could not be observed from the candidate checkout',
        'RELEASE_SCHEMA_SHA256 could not be observed from the candidate checkout',
        expect.stringContaining('candidate lock/schema identity could not be observed:'),
      ]);

      const withoutMigrations = schemaPaths.filter((path) => !path.endsWith('/migration.sql'));
      expect(
        observeCandidateInputIdentities(root, () => schemaTreeListing(withoutMigrations)).error,
      ).toContain('contains no tracked Prisma migration.sql files');
    });
  });

  it('rejects symlink and gitlink modes before reading schema bytes', () => {
    inputFixture(({ root, schemaPaths }) => {
      const target = 'web/packages/db/prisma/schema.prisma';
      const symlink = observeCandidateInputIdentities(root, () =>
        schemaTreeListing(schemaPaths, { modes: { [target]: '120000' } }),
      );
      expect(symlink.error).toContain(`${target} is not a regular Git blob`);

      const gitlink = observeCandidateInputIdentities(root, () =>
        schemaTreeListing(schemaPaths, {
          modes: { [target]: '160000' },
          types: { [target]: 'commit' },
        }),
      );
      expect(gitlink.error).toContain(`${target} is not a regular Git blob`);
    });
  });

  it('rejects malformed, duplicate, and out-of-scope full tree records', () => {
    inputFixture(({ root, schemaPaths }) => {
      expect(observeCandidateInputIdentities(root, () => '100644 blob').error).toContain(
        'not NUL terminated',
      );
      expect(
        observeCandidateInputIdentities(
          root,
          () => `100644 blob ${'a'.repeat(41)}\t${schemaPaths[0]}\0`,
        ).error,
      ).toContain('contains an invalid entry');

      const duplicate = schemaTreeListing([...schemaPaths, schemaPaths[0]]);
      expect(observeCandidateInputIdentities(root, () => duplicate).error).toContain(
        'duplicate paths',
      );

      const outOfScope = schemaTreeListing([...schemaPaths, 'web/private/secret.sql']);
      expect(observeCandidateInputIdentities(root, () => outOfScope).error).toContain(
        'out-of-scope path web/private/secret.sql',
      );

      const traversal = schemaTreeListing([
        ...schemaPaths,
        'web/packages/db/prisma/../../private/secret.sql',
      ]);
      expect(observeCandidateInputIdentities(root, () => traversal).error).toContain(
        'out-of-scope path web/packages/db/prisma/../../private/secret.sql',
      );
    });
  });

  it('rejects a non-regular live worktree entry even when HEAD names a regular blob', () => {
    inputFixture(({ root, runGit }) => {
      const target = 'web/packages/db/prisma/schema.prisma';
      const observed = observeCandidateInputIdentities(
        root,
        runGit,
        (path) => INPUT_FILES[path.slice(root.length + 1)],
        (path) => ({ isFile: () => !path.endsWith(target) }),
      );
      expect(observed.error).toContain(`${target} is not a regular worktree file`);
    });
  });
});
