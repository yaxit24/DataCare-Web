import { describe, expect, it } from 'vitest';
import {
  candidateIdentityGitHubOutput,
  expectedCandidateInputIdentitiesFromGit,
} from '../../../scripts/lib/release-candidate-expected-identity.mjs';
import {
  RELEASE_LOCK_IDENTITY_MANIFEST,
  RELEASE_SCHEMA_IDENTITY_MANIFEST,
} from '../../../scripts/lib/release-candidate-identity.mjs';

const SHA = 'a'.repeat(40);
const OTHER_SHA = 'b'.repeat(40);
const LOCK_SHA256 = 'c98d2bd9d0bc739a5937aeba6ebfcb69a2c7ee1bae8e759808d596ef38d9c2b5';
const SCHEMA_SHA256 = '432d4ef43201110ec6a4fbbed5e0202202f7ed6e016075a4174e5c579181b106';
const TEMPLATE_SHA256 = 'd'.repeat(64);
const GIT_FILES = Object.freeze({
  'web/pnpm-lock.yaml': 'lockfileVersion: 9.0\n',
  'web/packages/db/prisma/schema.prisma': 'datasource db { provider = "postgresql" }\n',
  'web/packages/db/prisma/migrations/migration_lock.toml': 'provider = "postgresql"\n',
  'web/packages/db/prisma/migrations/001_init/migration.sql':
    'CREATE TABLE sample (id integer PRIMARY KEY);\n',
  'web/packages/db/prisma/rls.sql': 'ALTER TABLE sample ENABLE ROW LEVEL SECURITY;\n',
  'web/packages/db/setup_roles.sql': 'CREATE ROLE app_user;\n',
});
const SCHEMA_PATHS = Object.freeze(
  Object.keys(GIT_FILES).filter((path) => path !== RELEASE_LOCK_IDENTITY_MANIFEST.path),
);

function schemaTreeFixture(paths, files, { modes = {}, types = {} } = {}) {
  const descriptors = new Map();
  const records = paths.map((path, index) => {
    const oid = (index + 1).toString(16).padStart(40, '0');
    descriptors.set(oid, files[path]);
    return `${modes[path] ?? '100644'} ${types[path] ?? 'blob'} ${oid}\t${path}`;
  });
  return {
    listing: Buffer.from(records.length ? `${records.join('\0')}\0` : '', 'utf8'),
    descriptors,
  };
}

function gitFixture({
  paths = SCHEMA_PATHS,
  files = GIT_FILES,
  resolved = SHA,
  modes,
  types,
  listing,
} = {}) {
  const calls = [];
  const tree = schemaTreeFixture(paths, files, { modes, types });
  const runGit = (_repoRoot, args) => {
    calls.push(args);
    if (args[0] === 'rev-parse') return Buffer.from(`${resolved}\n`, 'utf8');
    if (args[0] === 'ls-tree') return listing ?? tree.listing;
    if (args[0] === 'cat-file') {
      const object = args[2];
      const prefix = `${SHA}:`;
      if (object.startsWith(prefix)) {
        const path = object.slice(prefix.length);
        if (!Object.hasOwn(files, path)) throw new Error(`missing Git blob ${path}`);
        return Buffer.from(files[path], 'utf8');
      }
      const value = tree.descriptors.get(object);
      if (value === undefined) throw new Error(`missing Git blob ${object}`);
      return Buffer.from(value, 'utf8');
    }
    throw new Error(`unexpected Git command ${args.join(' ')}`);
  };
  return { calls, runGit };
}

describe('release candidate expected identities from immutable Git objects', () => {
  it('derives known identities without reading the worktree', () => {
    const fixture = gitFixture({ paths: [...SCHEMA_PATHS].reverse() });
    const identity = expectedCandidateInputIdentitiesFromGit('/repo', SHA, fixture.runGit);

    expect(identity).toMatchObject({
      releaseSha: SHA,
      lockSha256: LOCK_SHA256,
      schemaSha256: SCHEMA_SHA256,
      schemaFileCount: 5,
    });
    expect(identity.schemaEntries.map(({ path }) => path)).toEqual([...SCHEMA_PATHS].sort());
    expect(fixture.calls[0]).toEqual(['rev-parse', '--verify', `${SHA}^{commit}`]);
    expect(fixture.calls[1]).toEqual([
      'ls-tree',
      '-r',
      '-z',
      SHA,
      '--',
      ...RELEASE_SCHEMA_IDENTITY_MANIFEST.pathspecs,
    ]);
    expect(fixture.calls.slice(2).every((args) => args[0] === 'cat-file')).toBe(true);
    expect(fixture.calls.slice(3).every((args) => !args[2].includes(':'))).toBe(true);
  });

  it('is deterministic when Git returns schema paths in a different order', () => {
    const forward = expectedCandidateInputIdentitiesFromGit(
      '/repo',
      SHA,
      gitFixture({ paths: [...SCHEMA_PATHS] }).runGit,
    );
    const reverse = expectedCandidateInputIdentitiesFromGit(
      '/repo',
      SHA,
      gitFixture({ paths: [...SCHEMA_PATHS].reverse() }).runGit,
    );
    expect(reverse).toEqual(forward);
  });

  it('rejects malformed SHA input before invoking Git', () => {
    let invoked = false;
    expect(() =>
      expectedCandidateInputIdentitiesFromGit('/repo', 'HEAD', () => {
        invoked = true;
        return Buffer.alloc(0);
      }),
    ).toThrow('release commit must be an exact 40-character hexadecimal object id');
    expect(invoked).toBe(false);
  });

  it('rejects a SHA that does not resolve to that exact commit object', () => {
    expect(() =>
      expectedCandidateInputIdentitiesFromGit(
        '/repo',
        SHA,
        gitFixture({ resolved: OTHER_SHA }).runGit,
      ),
    ).toThrow(`release commit ${SHA} did not resolve to that exact commit object`);
  });

  it('rejects a missing required schema file and a zero-migration manifest', () => {
    const withoutRls = SCHEMA_PATHS.filter((path) => path !== 'web/packages/db/prisma/rls.sql');
    expect(() =>
      expectedCandidateInputIdentitiesFromGit(
        '/repo',
        SHA,
        gitFixture({ paths: withoutRls }).runGit,
      ),
    ).toThrow('missing required tracked file web/packages/db/prisma/rls.sql');

    const withoutMigrations = SCHEMA_PATHS.filter((path) => !path.endsWith('/migration.sql'));
    expect(() =>
      expectedCandidateInputIdentitiesFromGit(
        '/repo',
        SHA,
        gitFixture({ paths: withoutMigrations }).runGit,
      ),
    ).toThrow('contains no tracked Prisma migration.sql files');
  });

  it('fails when the candidate lock blob is missing', () => {
    const files = { ...GIT_FILES };
    delete files[RELEASE_LOCK_IDENTITY_MANIFEST.path];
    expect(() =>
      expectedCandidateInputIdentitiesFromGit('/repo', SHA, gitFixture({ files }).runGit),
    ).toThrow(`missing Git blob ${RELEASE_LOCK_IDENTITY_MANIFEST.path}`);
  });

  it('rejects symlink and gitlink schema entries before reading their objects', () => {
    const target = 'web/packages/db/prisma/schema.prisma';
    expect(() =>
      expectedCandidateInputIdentitiesFromGit(
        '/repo',
        SHA,
        gitFixture({ modes: { [target]: '120000' } }).runGit,
      ),
    ).toThrow(`${target} is not a regular Git blob`);

    expect(() =>
      expectedCandidateInputIdentitiesFromGit(
        '/repo',
        SHA,
        gitFixture({
          modes: { [target]: '160000' },
          types: { [target]: 'commit' },
        }).runGit,
      ),
    ).toThrow(`${target} is not a regular Git blob`);
  });

  it('rejects malformed, duplicate, and out-of-scope full tree records', () => {
    expect(() =>
      expectedCandidateInputIdentitiesFromGit(
        '/repo',
        SHA,
        gitFixture({ listing: Buffer.from('100644 blob', 'utf8') }).runGit,
      ),
    ).toThrow('not NUL terminated');
    expect(() =>
      expectedCandidateInputIdentitiesFromGit(
        '/repo',
        SHA,
        gitFixture({
          listing: Buffer.from(`100644 blob ${'a'.repeat(41)}\t${SCHEMA_PATHS[0]}\0`, 'utf8'),
        }).runGit,
      ),
    ).toThrow('contains an invalid entry');

    expect(() =>
      expectedCandidateInputIdentitiesFromGit(
        '/repo',
        SHA,
        gitFixture({ paths: [...SCHEMA_PATHS, SCHEMA_PATHS[0]] }).runGit,
      ),
    ).toThrow('duplicate paths');

    expect(() =>
      expectedCandidateInputIdentitiesFromGit(
        '/repo',
        SHA,
        gitFixture({ paths: [...SCHEMA_PATHS, 'web/private/secret.sql'] }).runGit,
      ),
    ).toThrow('out-of-scope path web/private/secret.sql');
  });
});

describe('release candidate GitHub output', () => {
  const identity = {
    releaseSha: SHA,
    lockSha256: LOCK_SHA256,
    schemaSha256: SCHEMA_SHA256,
    schemaFileCount: 5,
    templateSha256: TEMPLATE_SHA256,
    templateFileCount: 431,
  };

  it('emits exactly six fixed single-line outputs', () => {
    expect(candidateIdentityGitHubOutput(identity)).toBe(
      `release_sha=${SHA}\n` +
        `lock_sha256=${LOCK_SHA256}\n` +
        `schema_sha256=${SCHEMA_SHA256}\n` +
        'schema_file_count=5\n' +
        `template_sha256=${TEMPLATE_SHA256}\n` +
        'template_file_count=431\n',
    );
  });

  it('rejects values that could add an output line or are not exact identities', () => {
    expect(() =>
      candidateIdentityGitHubOutput({ ...identity, releaseSha: `${SHA}\nextra=unsafe` }),
    ).toThrow('release_sha is not a safe full commit id');
    expect(() => candidateIdentityGitHubOutput({ ...identity, lockSha256: 'short' })).toThrow(
      'lock_sha256 is not a safe SHA-256 digest',
    );
    expect(() => candidateIdentityGitHubOutput({ ...identity, schemaFileCount: 0 })).toThrow(
      'schema_file_count is not a safe positive integer',
    );
    expect(() => candidateIdentityGitHubOutput({ ...identity, templateSha256: 'short' })).toThrow(
      'template_sha256 is not a safe SHA-256 digest',
    );
    expect(() => candidateIdentityGitHubOutput({ ...identity, templateFileCount: 0 })).toThrow(
      'template_file_count is not a safe positive integer',
    );
  });
});
